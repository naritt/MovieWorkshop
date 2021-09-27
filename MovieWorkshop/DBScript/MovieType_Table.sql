-- MovieWorkshopDB.dbo.MovieType definition

-- Drop table

-- DROP TABLE MovieWorkshopDB.dbo.MovieType;

CREATE TABLE MovieWorkshopDB.dbo.MovieType (
	id int IDENTITY(1,1) NOT NULL,
	name nvarchar(100) COLLATE Thai_CI_AS NOT NULL,
	CONSTRAINT PK__MovieTyp__3213E83FA0A38FDC PRIMARY KEY (id)
);