using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using CRAWLER.DATA;

namespace NM_CongNghePhanMem
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private String GetContent()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            ServicePointManager.ServerCertificateValidationCallback = delegate {
                return true;
            };

            WebClient webClient = new WebClient();

            string sString = null;
            if(!String.IsNullOrEmpty(tb_Link.Text))
            {
                sString = webClient.DownloadString(tb_Link.Text);
            }
            
            return sString;
        }

        private void LoadData()
        {
            tb_Conference.Text = "";
            try
            {
                string getContent = GetContent();
                if (!String.IsNullOrEmpty(getContent))
                {
                    List<string> containerList = new List<string>();
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(getContent);

                    HtmlNodeCollection textNodes = doc.DocumentNode.SelectNodes("//div[@id='tab1']/div/div");
                    foreach (var containerNode in textNodes)
                    {
                        containerList.Add(containerNode.OuterHtml.Trim());
                    }

                    HtmlAgilityPack.HtmlDocument detailNotes = new HtmlAgilityPack.HtmlDocument();
                    string idNote = null, dayNodes = null, monthNodes = null, titleNodes = null, locationNodes = null;
                    int getIndex = 0;

                    progressBar1.Maximum = containerList.Count;
                    lb_Count.Text= containerList.Count.ToString();

                    conference addConference = new conference();
                    for (int i = 0; i < containerList.Count; i++)
                    {
                        detailNotes.LoadHtml(containerList[i]);
                        if (containerList[i].Contains("data-val="))
                        {
                            getIndex = containerList[i].IndexOf("data-val=") + 10;
                            idNote = containerList[i].Substring(getIndex, 7);//2271790

                            detailNotes.LoadHtml(containerList[i]);
                            dayNodes = " - day: " + detailNotes.DocumentNode.SelectSingleNode("//div/div/h6").InnerHtml;
                            monthNodes = " - month: " + detailNotes.DocumentNode.SelectSingleNode("//div/div/h5").InnerHtml;
                            titleNodes = " - title: " + detailNotes.DocumentNode.SelectSingleNode("//div/div/h3").InnerHtml;
                            locationNodes = detailNotes.DocumentNode.SelectSingleNode("//div/div/div/div/div").InnerHtml;
                            string getLocationNote = locationNodes.Substring(40, locationNodes.Length - 40);
                            locationNodes = " - location: " + getLocationNote;

                            addConference.name = detailNotes.DocumentNode.SelectSingleNode("//div/div/h3").InnerHtml;
                            addConference.country = getLocationNote;
                            addConference.city = getLocationNote;
                            addConference.start_date = DateTime.Now;
                            addConference.end_date = DateTime.Now;
                            addConference.submit_format = "abc";
                            addConference.description = "abcd";
                            addConference.url = idNote;
                            addConference.created_at = (int)DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
                            addConference.AddConference();

                            tb_Conference.Text += i + " - Id: " + idNote + dayNodes + monthNodes + titleNodes + locationNodes + "-----------\r\n";
                            label4.Text = "0";
                        }
                    }
                    
                }
                else
                {
                    tb_Conference.Text = "No data found!";
                }
            }
            catch (Exception ex)
            {
                tb_Conference.Text = ex.ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.Minute.ToString()
                        + ","
                        + DateTime.Now.Second.ToString();

            if (progressBar1.Value != int.Parse(lb_Count.Text))
            {
                progressBar1.Value++;
            }

            if (progressBar1.Value == int.Parse(lb_Count.Text))
            {
                if(label1.Text.Equals(label2.Text))
                {
                    label4.Text = "1";
                    UpdateInterval();
                    LoadData();
                    progressBar1.Value = 0;
                }
                else
                {
                    if(double.Parse(label2.Text)> double.Parse(label1.Text) && label4.Text == "0")
                    {
                        UpdateInterval();
                    }
                }
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable getURL = page.GetUrl("True");
                if (getURL != null)
                {
                    tb_Link.Text = getURL.Rows[0]["url"].ToString();
                    lb_PageID.Text = getURL.Rows[0]["page_id"].ToString();
                    tb_Minute.Text = getURL.Rows[0]["crawled_at_minute"].ToString();
                    tb_Second.Text = getURL.Rows[0]["crawled_at_second"].ToString();

                    timer1.Tick += new EventHandler(timer1_Tick);
                }
            }
            catch
            {
                MessageBox.Show("Connection errors! Please check again.", "Error");
            }
        }

        private void bt_Read_Click(object sender, EventArgs e)
        {
            UpdateInterval();

            bt_Stop.Enabled = true;
            bt_Read.Enabled = false;

            timer1.Enabled = true;
            timer1.Start();

            LoadData();
        }

        private void bt_Stop_Click(object sender, EventArgs e)
        {
            bt_Stop.Enabled = false;
            bt_Read.Enabled = true;

            timer1.Stop();
            timer1.Enabled = false;
            progressBar1.Value =0;
            tb_Conference.Text = "";
            label1.Text = "0";
            label2.Text = "0";
            MessageBox.Show("Stop conference.", "Message");
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_Minute.Text) || string.IsNullOrEmpty(tb_Second.Text))
            {
                MessageBox.Show("Please set a time to retrieve data!", "Warning!");
            }
            else if (tb_Minute.Text == "0" && tb_Second.Text == "0")
            {
                MessageBox.Show("Please set a time to retrieve data!", "Warning!");
            }
            else
            {
                if (int.Parse(tb_Minute.Text) < 0 || int.Parse(tb_Second.Text) < 0)
                {
                    MessageBox.Show("Please check the time to collect data!", "Warning!");
                }
                else
                {
                    if (int.Parse(tb_Minute.Text) == 0 && int.Parse(tb_Second.Text) < 30)
                    {
                        MessageBox.Show("Please set the interval time greater than 30 seconds!", "Warning!");
                    }
                    else
                    {
                        try
                        {
                            page updateTimeStamp = new page();
                            updateTimeStamp.crawled_at_minute = int.Parse(tb_Minute.Text);
                            updateTimeStamp.crawled_at_second = int.Parse(tb_Second.Text);
                            updateTimeStamp.UpdateTimestamp(int.Parse(lb_PageID.Text));
                        }
                        catch
                        {
                            MessageBox.Show("Connection errors! Please check again.", "Error");
                        }
                        finally
                        {
                            tb_Minute.Enabled = false;
                            tb_Second.Enabled = false;
                            bt_Save.Visible = false;
                            bt_Cancel.Visible = false;
                            bt_Modify.Visible = true;

                            bt_Read.Enabled = true;
                            bt_Stop.Enabled = false;

                            MessageBox.Show("Save successful.", "Message");
                        }
                    }
                }
            }
        }

        private void bt_Modify_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(label1.Text) || label1.Text=="0")
            {
                tb_Minute.Enabled = true;
                tb_Second.Enabled = true;
                bt_Save.Visible = true;
                bt_Cancel.Visible = true;
                bt_Modify.Visible = false;
                if (label1.Text == "")
                {
                    bt_Read.Enabled = true;
                    bt_Stop.Enabled = false;
                }
                else
                {
                    bt_Read.Enabled = false;
                    bt_Stop.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Please stop Crawler before change your config!", "Warning!");
            }
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            tb_Minute.Enabled = false;
            tb_Second.Enabled = false;
            bt_Save.Visible = false;
            bt_Cancel.Visible = false;
            bt_Modify.Visible = true;

            if(label1.Text =="")
            {
                bt_Read.Enabled = true;
                bt_Stop.Enabled = false;
            }
            else
            {
                bt_Read.Enabled = false;
                bt_Stop.Enabled = true;
            }
        }

        private void UpdateInterval()
        {
            DateTime getNow = DateTime.Now;
            DateTime setNew;
            setNew = getNow.AddMinutes(int.Parse(tb_Minute.Text));
            setNew = getNow.AddSeconds(int.Parse(tb_Second.Text));
            label1.Text = setNew.Minute.ToString()
                    + ","
                    + setNew.Second.ToString();

        }
    }
}
