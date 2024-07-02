/*
CREATE DATABASE university;
USE university;
-----------------------------------------------
CREATE TABLE professors (
	id INT AUTO_INCREMENT PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL
);
-----------------------------------------------
CREATE TABLE courses (
	id INT AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE courses_professor (
	course_id INT NOT NULL,
    professor INT,
    FOREIGN KEY(course_id) REFERENCES courses(id),
    FOREIGN KEY(professor) REFERENCES professors(id),
    PRIMARY KEY(course_id,professor)
);

CREATE TABLE courses_student (
	course_id INT NOT NULL,
    student INT,
    FOREIGN KEY(course_id) REFERENCES courses(id),
    FOREIGN KEY(student) REFERENCES students(id),
    PRIMARY KEY(course_id,student)
);
-----------------------------------------------
CREATE TABLE students (
	id INT AUTO_INCREMENT PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    age INT NOT NULL,
    academic_year INT,
    birth_date DATE NOT NULL,
    application_date DATE NOT NULL
);

ALTER TABLE students
ADD CHECK (age >= 18);
-----------------------------------------------
CREATE TABLE exams (
	id INT AUTO_INCREMENT PRIMARY KEY,
    exam_date DATE NOT NULL,
    exam_hour TIME,
    course INT NOT NULL,
    professor INT,
    FOREIGN KEY(course) REFERENCES courses(id),
    FOREIGN KEY(professor) REFERENCES professors(id)
);

CREATE TABLE exams_scores (
	id INT NOT NULL,
    student INT NOT NULL,
    mark INT NOT NULL,
    FOREIGN KEY(id) REFERENCES exams(id),
    FOREIGN KEY(student) REFERENCES students(id),
    PRIMARY KEY(id,student,mark)
);
ALTER TABLE exams_scores
ADD CHECK (mark >= 10 AND mark <= 31);
*/



/*
16 insegnanti
INSERT INTO professors (first_name,last_name)
VALUES  ('Matt','Smith'),
		('Jack','Knight'),
        ('Rose','Chalane'),
        ('Andrea','DeCarlo'),
        ('Ben','Brown'),
        ('Jon','Carlisle'),
        ('Leslie','Hopper'),
        ('Anya','von Tran'),
		('Matthew','Mercer'),
		('Jennifer','Lamp'),
        ('Ronald','Pile'),
        ('Jack','Cage'),
        ('Page','Gilmore'),
        ('Elisabeth','Willow'),
        ('Leslie','Jude'),
        ('Irina','Kalistav');
----------------------------------------------------------------------------------------------
24 studenti
INSERT INTO students (first_name,last_name,age,academic_year,birth_date,application_date)
VALUES  ('Jon',			'Snow',			23,3,	'2001-01-01',	'2021-08-01'),
		('Robb',		'Stark',		23,3,	'2001-03-16',	'2021-08-01'),
        ('Bran',		'Stark',		21,1,	'2003-05-27',	'2023-09-10'),
        ('Sansa',		'Stark',		22,2,	'2002-08-25',	'2022-08-01'),
        ('Tyene',		'Sand',			23,5,	'2001-08-17',	'2019-06-14'),
        ('Daenerys',	'Targaryen',	23,3,	'2001-10-02',	'2021-09-15'),
        ('Rhaegar',		'Targaryen',	26,4,	'1998-12-05',	'2018-06-13'),
        ('Jaime',		'Lannister',	26,4,	'1998-03-29',	'2018-08-21'),
        ('Cersei',		'Lannister',	26,6,	'1998-03-29',	'2018-08-21'),
		('Margaery', 	'Tyrell', 		24, 2,  '2000-12-08', 	'2022-07-25'),
		('Jon', 		'Connington', 	25, 2,  '1999-09-19', 	'2022-07-07'),
		('Robert', 		'Baratheon', 	26, 1,  '1998-05-03', 	'2023-12-05'),
		('Quentyn', 	'Martell', 		22, 3,  '2002-04-07', 	'2021-03-02'),
		('Trystane', 	'Martell', 		21, 1,  '2003-07-19', 	'2023-10-03'),
		('Myrcella', 	'Hightower', 	21, 1,  '2003-06-09', 	'2023-07-23'),
		('Mathis', 		'Rowan', 		25, 2,  '1999-05-11', 	'2022-08-07'),
		('Ashara', 		'Arryn', 		24, 4,  '2000-08-26', 	'2020-05-21'),
		('Arthur', 		'Dayne', 		21, 3,  '2003-10-02', 	'2021-04-19'),
		('Leonard', 	'Royce', 		24, 5,  '2000-02-09', 	'2019-05-29'),
		('Lynesse', 	'Caron', 		19, 1,  '2005-08-26', 	'2023-05-21'),
		('Edric', 		'Dayne', 		23, 4,  '2001-08-26', 	'2020-02-12'),
		('Arianne', 	'Karstark', 	23, 4,  '2001-08-26', 	'2020-12-03'),
		('Garlan', 		'Velaryon', 	18, 1,  '2006-11-08', 	'2024-05-21'),
		('Lyanna', 		'Blackwood', 	18, 1,  '2006-08-10', 	'2024-06-20'),
		('Loras', 		'Mallister', 	19, 2,  '2004-08-26', 	'2022-01-22');
----------------------------------------------------------------------------------------------
INSERT INTO courses_professor (course_id,professor)
VALUES  (1,1),
		(1,2),
        (2,3),
        (3,4),
        (4,5),
        (4,12),
        (5,6),
        (6,7),
        (7,7),
        (8,6),
        -- -- -- -- --
        (9,8),
		(10,10),
        (11,11),
        (12,12),
        (13,13),
        (14,14),
        (15,15),
        -- -- -- -- --
        (16,2),
        (17,8),
        (18,3),
        (19,12),
        (20,15),
        (21,7),
        (22,9),
        (23,16),
        (24,16);
----------------------------------------------------------------------------------------------        
24 corsi
INSERT INTO courses (title)
VALUES  ('Matematica 1'),
		('Geometria'),
		('Informatica 1'),
        ('Informatica 2'),
		('Basi di Chimica'),
        ('Basi di Fisica'),
        ('Fisica 1'),
        ('Chimica 1'),
        -- -- -- -- -- --
        ('Statistica'),
        ('Matematica 2'),
        ('Algoritmi 1'),
        ('Strutture Dati'),
        ('Fisica 2'),
        ('Astronomia'),
        ('Biologia'),
        ('Analisi di Laboratorio'),
        -- -- -- -- -- --
        ('Matematica 3'),
        ('Analisi Operativa'),
        ('Algoritmi 2'),
        ('Intelligenza Artificiale'),
        ('Fisica 3'),
        ('Fluidi e Magnetismo'),
        ('Chimica 2'),
        ('Microbiologia');

----------------------------------------------------------------------------------------------
1 17 11
2 12 17 
3 1
4 6
5 6
6 16
7 13 21
8 16 5 22
9 14
10 4
11 20 23
12 18
13 7 2
14 2
15 13 19
16 10
17 24
18 8 10
insert into courses_student (course_id,student) 
values  (16,8),
(3,16),
(7,13),
(12,2),
(8,18),
(10,18),
(18,12),
(5,8),
(14,9),
(17,2),
(17,1),
(11,1),
(2,13),
(16,6),
(9,19),
(2,14),
(4,10),
(1,3),
(22,8),
(10,16),
(6,4),
(6,5),
(13,7),
(13,15),
(19,15),
(20,11),
(21,7),
(23,11),
(5,17),
(24,17);
----------------------------------------------------------------------------------------------
30 esami (modifica dati in cui professore deve essere prof del corso)
insert into exams (exam_date,exam_hour,course,professor) 
values  
('2024-05-04' , '15:06'	, 21 , 15),
('2024-08-11' , '7:02'	, 16 , 10),
('2024-11-06' , '9:53'	, 13 , 15),
('2024-05-07' , '12:07'	, 20 , 7),
('2024-07-19' , '10:58'	, 3 , 8),
('2024-08-02' , '2:45'	, 10 , 14),
('2024-10-29' , '1:08'	, 3 , 13),
('2024-10-31' , '10:04'	, 17 , 9),
('2024-02-14' , '20:53'	, 14 , 1),
('2024-06-04' , '19:31'	, 9 , 10),
('2024-07-05' , '11:39'	, 20 , 15),
('2024-12-10' , '15:12'	, 19 , 10),
('2024-08-29' , '6:23'	, 12 , 11),
('2024-02-06' , '9:00'	, 12 , 9),
('2024-02-09' , '7:03'	, 6 , 7),
('2024-12-10' , '17:45'	, 4 , 10),
('2024-05-30' , '10:26'	, 24 , 12),
('2024-12-12' , '21:47'	, 4 , 16),
('2024-08-02' , '17:50'	, 14 , 13),
('2024-02-23' , '14:18'	, 2 , 12),
('2024-10-04' , '11:45'	, 1 , 8),
('2024-12-16' , '0:36'	, 7 , 8),
('2024-12-19' , '17:58'	, 13 , 1),
('2024-12-19' , '9:54'	, 7 , 5),
('2024-09-11' , '3:29'	, 11 , 7),
('2024-04-16' , '20:54'	, 3 , 1),
('2024-12-15' , '5:21'	, 9 , 12),
('2024-07-11' , '23:08'	, 13 , 10),
('2024-09-24' , '19:14'	, 6	, 4),
('2024-02-03' , '8:51'  , 9	, 2);
----------------------------------------------------------------------------------------------
insert exams_scores(exam, student, mark) 
values 
(16, 16, 27),
(5, 5, 25),
(10, 16, 7),
(23, 23, 18),
(22, 3, 6),
(26, 8, 20),
(20, 23, 13),
(7, 13, 29),
 (22, 5, 9),
 (20, 17, 19),
 (23, 13, 17),
 (23, 13, 19),
 (21, 12, 4),
 (6, 13, 28),
 (24, 19, 25),
 (11, 4, 15),
 (21, 20, 28),
 (22, 8, 27),
 (18, 11, 11),
 (9, 18, 21),
 (11, 3, 30),
 (24, 20, 13),
 (26, 11, 19),
 (13, 23, 24),
 (12, 2, 13),
 (1, 10, 20),
 (15, 7, 2),
 (30, 22, 14),
 (24, 2, 2),
 (1, 18, 8),
 (29, 11, 22),
 (21, 19, 24),
 (6, 8, 26),
 (7, 17, 6),
 (15, 19, 25),
 (5, 13, 27),
 (29, 21, 3),
 (18, 1, 3),
 (9, 15, 9),
 (5, 1, 31),
 (28, 21, 0),
 (29, 6, 18),
 (10, 19, 21),
 (19, 8, 27),
 (10, 2, 19),
 (7, 18, 14),
 (25, 4, 8),
 (23, 16, 15),
 (14, 23, 7),
 (21, 23, 3),
 (12, 10, 29),
 (3, 22, 29),
 (4, 2, 31),
 (8, 3, 7),
 (18, 6, 31),
 (5, 7, 7),
 (4, 22, 18),
 (28, 11, 23),
 (8, 9, 14),
 (1, 15, 18),
 (16, 4, 5),
 (23, 22, 1),
 (14, 15, 4),
 (20, 20, 8),
 (17, 12, 28),
 (18, 1, 19),
 (11, 14, 29),
 (5, 6, 21),
 (4, 1, 27),
 (11, 2, 24),
 (4, 2, 14),
 (6, 24, 17),
 (30, 19, 30),
 (13, 14, 26),
 (14, 10, 21),
 (1, 8, 1),
 (4, 17, 27),
 (13, 3, 29),
 (23, 7, 8),
 (6, 3, 15),
 (14, 12, 17),
 (17, 15, 6),
 (28, 9, 2),
 (11, 12, 30),
 (17, 5, 14),
 (9, 7, 24),
 (2, 15, 4),
 (18, 11, 1),
 (24, 16, 27),
 (28, 24, 24),
 (20, 17, 18),
 (13, 18, 21),
 (30, 4, 15),
 (21, 9, 31),
 (8, 24, 31),
 (17, 20, 26),
 (15, 8, 17),
 (7, 13, 13),
 (17, 24, 31),
 (1, 14, 21),
 (26, 22, 9),
 (12, 2, 20),
 (5, 11, 18),
 (1, 11, 10),
 (13, 5, 23),
 (30, 22, 8),
 (19, 18, 26),
 (3, 19, 27),
 (29, 7, 5),
 (24, 13, 4),
 (2, 4, 11),
 (17, 1, 20),
 (4, 22, 20),
 (1, 9, 21),
 (11, 4, 2),
 (2, 15, 29),
 (3, 13, 7),
 (16, 24, 2),
 (10, 22, 14),
 (3, 17, 9),
 (11, 9, 27),
 (18, 7, 27),
 (26, 10, 13),
 (4, 16, 5),
 (3, 14, 31),
 (30, 19, 24),
 (17, 22, 11),
 (24, 21, 15),
 (5, 6, 21),
 (16, 6, 14),
 (14, 3, 8),
 (21, 8, 19),
 (27, 14, 7),
 (18, 4, 24),
 (23, 16, 1),
 (6, 1, 3),
 (25, 3, 13),
 (3, 3, 30),
 (24, 6, 26),
 (7, 3, 8),
 (6, 16, 23),
 (25, 21, 27),
 (1, 4, 4),
 (21, 1, 0),
 (11, 13, 2),
 (20, 24, 3),
 (20, 21, 5),
 (5, 11, 4),
 (28, 8, 18),
 (16, 19, 0);
*/


 /*
 DataTable courses_student = new DataTable("Courses_Student");
 DataColumn column = new DataColumn();
 column.DataType = System.Type.GetType("System.Int32");
 column.ColumnName = "course_id";
 courses_student.Columns.Add(column);
 column = new DataColumn();
 column.DataType = System.Type.GetType("System.Int32");
 column.ColumnName = "student_id";
 courses_student.Columns.Add(column);

 DataRow row;
 for (int i = 0; i <= 2; i++) {
     row = courses_student.NewRow();
     row["course_id"] = i;
     row["student_id"] = i;
     courses_student.Rows.Add(row);
 }
 */
 
 
 
 SELECT students.id AS 'ID', students.first_name AS 'Name', 
students.last_name AS 'Surname', students.age AS 'Age', students.academic_year AS 'Academic year', 
students.birth_date AS 'Birth Date'
FROM students 
JOIN courses_student ON courses_student.student = students.id
JOIN courses ON courses_student.course_id = courses.id AND courses_student.course_id = "Algoritmi 2";