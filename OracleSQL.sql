-- Before you will be able to run this code, you will either need to create 
-- an AtlantisGames schema OR remove the "AtlantisGames." prefix from all 
-- statements to run directly on Apps.

CREATE TABLE ATLANTISGAMES.GAMECATALOG
(	
    ID NUMBER GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) NOT NULL, 
	NAME VARCHAR2(100), 
	GENRE VARCHAR2(100), 
	ESRB_RATING VARCHAR2(50)
);

INSERT INTO ATLANTISGAMES.GAMECATALOG (NAME, GENRE, ESRB_RATING) VALUES('Devil May Cry 5', 'Action', 'Mature');
INSERT INTO ATLANTISGAMES.GAMECATALOG (NAME, GENRE, ESRB_RATING) VALUES('The Witcher 3: Wild Hunt', 'RPG', 'Mature');
INSERT INTO ATLANTISGAMES.GAMECATALOG (NAME, GENRE, ESRB_RATING) VALUES('God of War', 'Action', 'Mature');
INSERT INTO ATLANTISGAMES.GAMECATALOG (NAME, GENRE, ESRB_RATING) VALUES('Tetris', 'Puzzle', 'Everyone');


-- Make sure whatever account you are using in Oracle has permission to create proc in schema
create or replace procedure GetAllGames (Games out sys_refcursor)
is
begin
	open Games for select * from AtlantisGames.GAMECATALOG;
end GetAllGames;
