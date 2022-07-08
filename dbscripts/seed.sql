

CREATE TABLE facults
(
	id int primary Key
	,
	name text not null
	
);

CREATE TABLE facultComments
(
    id int PRIMARY KEY,
    facultId int,
    info text,
    FOREIGN KEY (facultId) REFERENCES facults (id)
);

CREATE TABLE directions
(
	id int PRIMARY KEY,
    facultId int,
    name text not null,
    FOREIGN KEY (facultId) REFERENCES facults (id)
	
);
CREATE TABLE directionComments
(
    id int PRIMARY KEY,
    directionId int,
    info text,
    FOREIGN KEY (directionId) REFERENCES directions (id)
);


CREATE TABLE courses
(
    id int PRIMARY KEY,
    directionId int,
    name text,
    FOREIGN KEY (directionId) REFERENCES directions (id)
);

CREATE TABLE coursesComments
(
    id int PRIMARY KEY,
    courseId int,
    info text,
    FOREIGN KEY (courseId) REFERENCES courses (id)
);


insert into facults values
(1,'ФКН'),
(2,'ФГН'),
(3,'МИЭМ'),
(4,'ФЭН');
insert into directions values
(1,1,'ПИ');
insert into courses values
(1,1,'Программирование на C#');

