
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
	id				int					identity(1,1),
	username			varchar(50)			not null,
	password			varchar(50)			not null,
	salt				varchar(50)			not null,
	role				varchar(50)			default('standard'),
	bio					varchar(500),
	favorites			varchar(150),
	user_image			varchar(75),

	constraint pk_users primary key (id)
);

CREATE TABLE collection
(
	collection_id		int					identity(1,1),
	user_id				int					not null,
	title				varchar(100)		not null,
	description			varchar(500)		not null,
	public_access		varchar(100)		not null,

	CONSTRAINT pk_collection PRIMARY KEY (collection_id),
	FOREIGN KEY (user_id) REFERENCES users (id)

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
	FOREIGN KEY (user_id) REFERENCES users (id),
	FOREIGN KEY (friend_id) REFERENCES users (id)
);
COMMIT TRANSACTION;

INSERT INTO comic (description, deck, image, issue_number, name, volume, cover_date, person_credits)
VALUES ('Man looking to find his dog', 'dog finder', '=)', '1', 'Dog Finder Man', '2', '1/1/2019', 'Forrest Rojas')

SELECT * FROM collection
SELECT * FROM comic

INSERT INTO users (username, password, salt, role, bio, favorites, user_image)
VALUES ('frojas', '123456', '1a2b3c4d5e6f', 'standard', 'I wear Free Hug shirts', 'Dog Finder Man', '=0')

INSERT INTO collection (user_id, title, description, public_access)
VALUES ('2', 'Forrest Favorties', 'My favorite comic book', 'standard')

INSERT INTO collection_comic (collection_id, comic_id)
VALUES ('2', '1')

