CREATE DATABASE LibraryTransactions;
USE LibraryTransactions;

CREATE TABLE issueBook(
	ibNo		INT				NOT NULL IDENTITY (1,1),
	memberId	VARCHAR(10)		NOT NULL,
	bookId		VARCHAR(20)		NOT NULL,
	bType		VARCHAR(1)		NOT NULL DEFAULT 'N',/*N,E*/
	issueDate	DATE			NOT NULL,
	returnDate	DATE			NOT NULL,
	returned	VARCHAR(1)		NOT NULL DEFAULT 'N',
	
	CONSTRAINT iBook_pk_user PRIMARY KEY (ibNo)
);

CREATE TABLE issueComic(
	icNo		INT				NOT NULL IDENTITY (1,1),
	memberId	VARCHAR(10)		NOT NULL,
	comicId		VARCHAR(20)		NOT NULL,
	issueDate	DATE			NOT NULL,
	returnDate	DATE			NOT NULL,
	returned	VARCHAR(1)		NOT NULL DEFAULT 'N',
	
	CONSTRAINT iComic_pk_user PRIMARY KEY (icNo)
);

CREATE TABLE issuePastP(
	ipNo		INT				NOT NULL IDENTITY (1,1),
	memberId	VARCHAR(10)		NOT NULL,
	pastPId		VARCHAR(20)		NOT NULL,
	issueDate	DATE			NOT NULL,
	returnDate	DATE			NOT NULL,
	returned	VARCHAR(1)		NOT NULL DEFAULT 'N',
	
	CONSTRAINT iPastP_pk_user PRIMARY KEY (ipNo)
);

CREATE TABLE issueVidD(
	ivNo		INT				NOT NULL IDENTITY (1,1),
	memberId	VARCHAR(10)		NOT NULL,
	vidDId		VARCHAR(20)		NOT NULL,
	issueDate	DATE			NOT NULL,
	returnDate	DATE			NOT NULL,
	returned	VARCHAR(1)		NOT NULL DEFAULT 'N',
	
	CONSTRAINT iVidD_pk_user PRIMARY KEY (ivNo)
);


CREATE TABLE issuedCount(
	memberId	VARCHAR(10)		NOT NULL,
	rCount		INT				NOT NULL,
	
	CONSTRAINT iCount_pk_memrc PRIMARY KEY (memberId, rCount)
);