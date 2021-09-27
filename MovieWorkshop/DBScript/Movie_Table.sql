-- MovieWorkshopDB.dbo.Movie definition

-- Drop table

-- DROP TABLE MovieWorkshopDB.dbo.Movie;

CREATE TABLE MovieWorkshopDB.dbo.Movie (
	id int IDENTITY(1,1) NOT NULL,
	name nvarchar(MAX) COLLATE Thai_CI_AS NOT NULL,
	type_id int NOT NULL,
	description nvarchar(MAX) COLLATE Thai_CI_AS NOT NULL,
	image_url nvarchar(MAX) COLLATE Thai_CI_AS NOT NULL,
	trailer_url nvarchar(MAX) COLLATE Thai_CI_AS NOT NULL,
	CONSTRAINT PK__Movie__3213E83F22AA10EA PRIMARY KEY (id)
);


-- MovieWorkshopDB.dbo.Movie foreign keys

ALTER TABLE MovieWorkshopDB.dbo.Movie ADD CONSTRAINT FK__Movie__type_id__3B75D760 FOREIGN KEY (type_id) REFERENCES MovieWorkshopDB.dbo.MovieType(id);