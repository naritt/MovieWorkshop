-- MovieWorkshopDB.dbo.Admin definition

-- Drop table

-- DROP TABLE MovieWorkshopDB.dbo.Admin;

CREATE TABLE MovieWorkshopDB.dbo.Admin (
	id int IDENTITY(1,1) NOT NULL,
	username nvarchar(100) COLLATE Thai_CI_AS NOT NULL,
	password nvarchar(100) COLLATE Thai_CI_AS NOT NULL,
	CONSTRAINT PK__Admin__3213E83F9FDDD61D PRIMARY KEY (id)
);