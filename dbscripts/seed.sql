

CREATE TABLE facults
(
	   id SERIAL primary key,
	name text not null
	
);

CREATE TABLE facultComments
(
    id SERIAL primary key,
	name text,
	time text,
    info text,
	facultId int,
    FOREIGN KEY (facultId) REFERENCES facults (id)
);

CREATE TABLE directions
(
	id SERIAL primary key,
    externalId int,
    name text not null,
    FOREIGN KEY (externalId) REFERENCES facults (id)
	
);
CREATE TABLE directionComments
(
    id SERIAL primary key,
	name text,
	time text,
    info text,
    directionId int,   
    FOREIGN KEY (directionId) REFERENCES directions (id)
);


CREATE TABLE courses
(
    id SERIAL primary key,
    externalId int,
    name text,
    FOREIGN KEY (externalId) REFERENCES directions (id)
);

CREATE TABLE coursesComments
(
    id SERIAL primary key,
	name text,
	time text,
    info text,
    courseId int,
    FOREIGN KEY (courseId) REFERENCES courses (id)
);


insert into facults(name) values
('ФКН'),
('ФГН'),
('МИЭМ'),
('ФЭН');
insert into directions(externalId,name) values
(1,'ПИ'),
(1,'ПМИ'),
(1,'ПАД'),
(1,'КНАД'),
(2,'Античность'),
(2,'Арабистика: язык, словесность, культура'),
(3,'ПМ'),
(3,'ИВТ');
insert into courses(externalId,name) values
(1,'Программирование на C#'),
(1,'Экономика'),
(1,'Алгебра'),
(1,'Математический анализ'),
(1,'Основы программирования на c++'),
(2,'Алгоритмы и структуры данных'),
(2,'Экономика'),
(2,'Алгебра'),
(2,'Математический анализ');

