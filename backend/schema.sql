
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
	id					int					identity(1,1),
	username			varchar(500)			not null UNIQUE,
	password			varchar(500)			not null,
	salt				varchar(500)			not null,
	role				varchar(500)			default('standard'),
	bio					varchar(500),
	favorites			varchar(500),
	user_image			varchar(1000),

	constraint pk_users primary key (id)
);

CREATE TABLE collection
(
	collection_id		int					identity(1,1),
	user_id				int					not null,
	image				varchar(5000)		not null,
	title				varchar(500)		not null,
	description			varchar(500)		not null,
	public_access		varchar(500)		not null,

	CONSTRAINT pk_collection PRIMARY KEY (collection_id),
	FOREIGN KEY (user_id) REFERENCES users (id)

);

CREATE TABLE comic
(
	comic_id			int					identity(1,1),
	description			varchar(500),		
	publisher			varchar(500),		
	deck				varchar(500),		
	image				varchar(500),		
	issue_number		int					not null,
	name				varchar(500),	
	volume				int					not null,
	cover_date			date,				
	person_credits		varchar(500),		

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
VALUES ('Man looking to find his dog', 'dog finder', 'https://images.unsplash.com/photo-1530281700549-e82e7bf110d6?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=600&q=60',
 '1', 'Dog Finder Man', '2', '01/01/2019', 'Forrest Rojas')
 DECLARE @newcomic_id int = (SELECT @@IDENTITY)

INSERT INTO comic (description, deck, image, issue_number, name, volume, cover_date, person_credits)
VALUES ('Man who hates kryptonite', 'Smallville guy', 'http://pngimg.com/uploads/superman/superman_PNG77.png',
 '2', 'Superman', '2', '02/02/2019', 'Ryan')
 DECLARE @newcomic2_id int = (SELECT @@IDENTITY)

INSERT INTO comic (description, deck, image, issue_number, name, volume, cover_date, person_credits)
VALUES ('Man gets bit by a spider', 'New Yorker/spider', 'https://static3.cbrimages.com/wordpress/wp-content/uploads/2018/06/spider-man-ps4-game.jpg',
'3', 'Spider-Man', '2', '03/03/2019', 'Richard')
DECLARE @newcomic3_id int = (SELECT @@IDENTITY)

INSERT INTO comic (description, deck, image, issue_number, name, volume, cover_date, person_credits)
VALUES ('Man gets super jacked', 'Green guy goes crazy', 'https://images.unsplash.com/photo-1542623024-a797a755b8d0?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=600&q=60',
'4', 'Hulk', '2', '04/04/2019', 'Peter')
DECLARE @newcomic4_id int = (SELECT @@IDENTITY)

INSERT INTO comic (description, deck, image, issue_number, name, volume, cover_date, person_credits)
VALUES ('Man wears red white and blue', 'super patriotic', 'https://cdn.pixabay.com/photo/2016/01/10/18/58/super-hero-1132272__480.jpg',
'5', 'Captain America', '2', '05/05/2019', 'Mike')
DECLARE @newcomic5_id int = (SELECT @@IDENTITY)


INSERT INTO users (username, password, salt, role, bio, favorites, user_image)
VALUES ('frojas', '123456', '1a2b3c4d5e6f', 'standard', 'I wear Free Hug shirts', 'Dog Finder Man', 'https://images.pexels.com/photos/302804/pexels-photo-302804.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940')
DECLARE @newuser_id int = (SELECT @@IDENTITY)

INSERT INTO users (username, password, salt, role, bio, favorites, user_image)
VALUES ('pscann', 'password', 'p1a2s3s4w5o6r7d8', 'standard', 'Go Browns', 'Dog Finder Man', 'https://media.gettyimages.com/photos/baker-mayfield-of-the-cleveland-browns-runs-off-the-field-after-a-picture-id1036976878?s=2048x2048')
DECLARE @newuser2_id int = (SELECT @@IDENTITY)

INSERT INTO collection (user_id, image, title, description, public_access)
VALUES (@newuser_id, 'https://images.unsplash.com/photo-1514329926535-7f6dbfbfb114?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&w=1000&q=80',
'Forrest Favorties', 'My favorite comic book', 'standard')
DECLARE @newcollection_id int = (SELECT @@IDENTITY)

INSERT INTO collection (user_id, image, title, description, public_access)
VALUES (@newuser2_id, 'https://images.pexels.com/photos/53794/pexels-photo-53794.jpeg?cs=srgb&dl=catalog-comic-book-hero-53794.jpg&fm=jpg',
'Peter Favorties', 'My favorite comic book', 'standard')
DECLARE @newcollection2_id int = (SELECT @@IDENTITY)


INSERT INTO collection_comic (collection_id, comic_id)
VALUES (@newcollection_id, @newcomic_id)


