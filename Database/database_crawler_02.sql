-- Tạo bảng người dùng
CREATE TABLE users (
    user_id INT  PRIMARY KEY,
    username VARCHAR(255) NOT NULL UNIQUE,
    hashed_password VARCHAR(255) NOT NULL,
    first_name VARCHAR(255) NOT NULL,
    last_name VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    role TEXT CHECK(role IN ('admin', 'user', 'reader', 'visitor')) DEFAULT 'visitor'
);

CREATE TABLE permissions (
    permission_id INT  PRIMARY KEY,
    role TEXT CHECK(role IN ('admin', 'user', 'visitor')) DEFAULT 'visitor' NOT NULL,
    permission TEXT CHECK(permission IN ('read', 'write', 'delete')) DEFAULT 'read' NOT NULL,
    description VARCHAR(255),
    CONSTRAINT unique_role_permission UNIQUE (role, permission),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE user_permissions (
    id INT  PRIMARY KEY,
    user_id INT NOT NULL,
    permission_id INT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(user_id),
    FOREIGN KEY (permission_id) REFERENCES permissions(permission_id)
);
CREATE TABLE user_follow_conference(
    conf_code INT NOT NULL,
    user_id INT NOT NULL,
    FOREIGN KEY (conf_code) REFERENCES conference(id),
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);

-- Tạo bảng chứa data crawler
CREATE TABLE conference(
    id INT  PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    country VARCHAR(255) NOT NULL,
    city VARCHAR(255) NOT NULL,
    start_date DATE NOT NULL,
    end_date DATE NOT NULL,
    submit_format VARCHAR(255) NOT NULL,
    description VARCHAR(255),
    url VARCHAR(255) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE speakers (
    id INT  PRIMARY KEY,
    conference_id INT NOT NULL,
    name VARCHAR(255) NOT NULL,
    organization VARCHAR(255),
    bio TEXT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (conference_id) REFERENCES conference(id)
);

CREATE TABLE papers(
    id INT  PRIMARY KEY,
    conference_id INT NOT NULL,
    title VARCHAR(255) NOT NULL,
    abstract TEXT,
    accepted BOOLEAN DEFAULT FALSE,   
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (conference_id) REFERENCES conference(id)    
);

CREATE TABLE attendees(
    id INT  PRIMARY KEY,
    conference_id INT NOT NULL,
    name VARCHAR(255) NOT NULL,
    organization VARCHAR(255),
    email VARCHAR(255),
    registered BOOLEAN DEFAULT FALSE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (conference_id) REFERENCES conference(id)
);

CREATE TABLE deadline(
    conference_code INT PRIMARY KEY,
    date DATE NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (conference_code) REFERENCES conferrence(id),
    FOREIGN KEY (date) REFERENCES conferrence(end_date)   
);

CREATE TABLE notification(
    conference_code INT,
    data VARCHAR(255),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (conference_code) REFERENCES conferrence(id)
);

CREATE TABLE crawler(
    id INT  PRIMARY KEY,
    label VARCHAR(255) NOT NULL,
    config JSON NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE crawler_configuration(
    id INT  PRIMARY KEY,
    crawler_id INT ,
    label VARCHAR(255) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (crawler_id) REFERENCES crawler(id)    
);
   
CREATE TABLE websites(
    id INT  PRIMARY KEY,
    url VARCHAR(255) NOT NULL,
    name VARCHAR(255),
    description VARCHAR(255),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE pages(
    id INT  PRIMARY KEY,
    url VARCHAR(255) NOT NULL,
    title VARCHAR(255),
    content TEXT,
    crawled_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE links(
    id INT  PRIMARY KEY,
    source_page_id INT,
    destination_url VARCHAR(255),
    role TEXT CHECK(link_type IN ('internal', 'external'))
    FOREIGN KEY (source_page_id) REFERENCES pages(id)
);

-- Thêm khóa
ALTER TABLE users
ADD CONSTRAINT unique_email UNIQUE (email);

ALTER TABLE user_permissions
ADD PRIMARY KEY (user_id, permission_id);

-- Thêm dữ liệu mẫu
INSERT INTO users (user_id, username, first_name, last_name, role)
VALUES
    (1, 'BinhBill', 'Duc Binh', 'Nguyen', 'Admin'),
    (2, 'DHHuong', 'Hoai Huong', 'Duong', 'Visitor'),
    (3, 'TranDungSy', 'Dung Sy', 'Tran', 'User'),
    (4, 'TruongHoAnhPha', 'Anh Pha', 'Truong Ho', 'User');
-- fetch some values

-- Cập nhật user
UPDATE Users
SET username = 'new_username'
WHERE id = 1;

UPDATE Users
SET password = 'new_password'
WHERE id = 1;

UPDATE Users
SET role = 'admin'
WHERE id = 1;

UPDATE Users
SET username = 'new_username', password = 'new_password'
WHERE id = 1;
SELECT * FROM students WHERE gender = 'F';

UPDATE users
SET role = 'admin'
WHERE user_id = 1;

-- Hiển thị thông tin user
--- Danh sách người dùng
SELECT * FROM users;
---Thông tin chi tiết về một người dùng cụ thể dựa trên user_id
SELECT * FROM users WHERE user_id = 1;
---Danh sách quyền của một người dùng
SELECT permissions.* FROM permissions
JOIN user_permissions ON permissions.permission_id = user_permissions.permission_id
WHERE user_permissions.user_id = 1;

---Thông tin về người dùng bao gồm user_id, tên người dùng (username), tên (first_name), họ (last_name) và vai trò (role)
SELECT user_id, username, first_name, last_name, role FROM users;
---Thông tin về phân quyền
SELECT * FROM permissions;

---Thông tin về tên người dùng và quyền của người dùng cụ thể
SELECT users.username, permissions.permission 
FROM users 
JOIN user_permissions ON users.user_id = user_permissions.user_id 
JOIN permissions ON user_permissions.permission_id = permissions.permission_id 
WHERE users.user_id = 1;

-- Hiển thị thông tin hội thảo
---Tất cả thông tin về các hội nghị
SELECT * FROM conferences;

---Thông tin về các diễn giả liên quan đến một hội nghị cụ thể
SELECT * FROM speakers WHERE conference_id = 1;

---Thông tin về các bài báo được chấp nhận liên quan đến một hội nghị cụ thể
SELECT * FROM papers WHERE conference_id = 1 AND accepted = TRUE;

---Thông tin về các người tham dự đã đăng ký trong một hội nghị cụ thể
SELECT * FROM attendees WHERE conference_id = 1 AND registered = TRUE;

---Thông tin về một bài báo cụ thể
SELECT * FROM papers WHERE id = 1;

---Thông tin về một diễn giả cụ thể
SELECT * FROM speakers WHERE id = 1;

---Thông tin về các hội nghị và tên diễn giả
SELECT conferences.*, speakers.name AS speaker_name
FROM conferences
JOIN speakers ON conferences.id = speakers.conference_id;

---Thông tin về các hội nghị và tiêu đề bài báo liên quan, trong đó bài báo đã được chấp nhận
SELECT conferences.*, papers.title AS paper_title
FROM conferences
JOIN papers ON conferences.id = papers.conference_id
WHERE papers.accepted = TRUE;

---Thông tin về các hội nghị, bài báo được công bố trong hội nghị đó và diễn giả
SELECT conferences.*, papers.title AS paper_title, speakers.name AS speaker_name
FROM conferences
JOIN papers ON conferences.id = papers.conference_id
JOIN speakers ON papers.id = speakers.paper_id;

---Thông tin về các hội nghị, công bố bài báo, diễn giả và người tham dự liên quan
SELECT conferences.*, papers.title AS paper_title, speakers.name AS speaker_name, Attendees.name AS attendee_name
FROM conferences
JOIN papers ON conferences.id = papers.conference_id
JOIN speakers ON papers.id = speakers.paper_id
JOIN attendees ON conferences.id = attendees.conference_id;

---Danh sách người tham dự một hội nghị cụ thể dựa trên conference_code
SELECT attendees.* FROM attendees
JOIN conference ON attendees.conference_id = conference.code
WHERE conference.code = 1;

---Tất cả các hội nghị mà một người dùng đang theo dõi
SELECT conference.* FROM conference
JOIN user_follow_conference ON conference.code = user_follow_conference.conf_code
WHERE user_follow_conference.user_id = 1;

---Thông tin về hạn chót của một hội nghị dựa trên conference_code
SELECT * FROM deadline WHERE conference_code = 1;

---Danh sách các trang web và các trang liên kết với một trình thu thập (crawler) cụ thể
SELECT websites.*, pages.*, links.* FROM websites
JOIN crawler_configuration ON websites.id = crawler_configuration.website_id
JOIN crawler ON crawler_configuration.crawler_id = crawler.id
JOIN pages ON pages.website_id = websites.id
JOIN links ON links.page_id = pages.id
WHERE crawler.id = 1;

