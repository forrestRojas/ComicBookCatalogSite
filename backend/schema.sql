
-- Switch to the system (aka master) database
USE master;
GO

-- Delete the DemoDB Database (IF EXISTS)
IF EXISTS(select * from sys.databases where name='ComicCollection')
DROP DATABASE ComicCollection;
GO

-- Create a new DemoDB Database
CREATE DATABASE ComicCollection;
GO

-- Switch to the DemoDB Database
USE ComicCollection
GO

BEGIN TRANSACTION;

CREATE TABLE users
(
	user_id				int					identity(1,1),
	username			varchar(50)			not null,
	password			varchar(50)			not null,
	salt				varchar(50)			not null,
	role				varchar(50)			default('standard'),
	hash				varchar(50)			not null,
	bio					varchar(500),
	favorites			varchar(150),
	user_image			varchar(75),

	constraint pk_users primary key (user_id)
);

CREATE TABLE collection
(
	collection_id		int					identity(1,1),
	user_id				int					not null,
	title				varchar(100)		not null,
	description			varchar(500)		not null,
	public_access		varchar(100)		not null,

	CONSTRAINT pk_collection PRIMARY KEY (collection_id),
	FOREIGN KEY (user_id) REFERENCES users (user_id)

);

CREATE TABLE comic
(
	comic_id			int					identity(1,1),
	description			varchar(500)		not null,
	deck				varchar(500)		not null,
	image				varchar(100)		not null,
	issue_number		int					not null,
	name				varchar(150)		not null,
	volume				int					not null,
	cover_date			date				not null,
	person_credits		varchar(500)		not null

	CONSTRAINT pk_comic PRIMARY KEY (comic_id),
	

);

CREATE TABLE collection_comic
(
	collection_id		int					not null,
	comic_id			int					not null,

	CONSTRAINT pk_collection_comic PRIMARY KEY (collection_id, comic_id),
	FOREIGN KEY (collection_id) REFERENCES collection (collection_id),
	FOREIGN KEY (comic_id) REFERENCES comic (comic_id)
);

CREATE TABLE friends
(
	user_id				int					not null,
	friend_id			int					not null,

	CONSTRAINT pk_friends PRIMARY KEY (user_id, friend_id),
	FOREIGN KEY (user_id) REFERENCES users (user_id),
	FOREIGN KEY (friend_id) REFERENCES users (user_id)
);
COMMIT TRANSACTION;