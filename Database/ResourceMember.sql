CREATE DATABASE ResourceMember;
USE ResourceMember;

CREATE TABLE regCodes(
	nic			VARCHAR(10)		NOT NULL,
	sid			VARCHAR(20)		NOT NULL,
	regCode		VARCHAR(10)		NOT NULL,
	regDate		DATETIME		NOT NULL DEFAULT Current_Timestamp,
	activated	CHAR(1)		 	NOT NULL DEFAULT '0',
	pic			VARCHAR(15)		NOT NULL,
	
	CONSTRAINT reGC_uq_nic UNIQUE (nic, sid),
	CONSTRAINT reGC_pk_regCode PRIMARY KEY (regCode)
);

CREATE TABLE loginDetails(
	regCode		VARCHAR(10)		NOT NULL,
	username	VARCHAR(20)		NOT NULL,
	password	VARCHAR(60)		NOT NULL,
	email		VARCHAR(60)		NOT NULL,
	
	CONSTRAINT logD_uq_email UNIQUE (email),
	CONSTRAINT logD_pk_regU PRIMARY KEY (username),
	
	CONSTRAINT	logD_fk_regCode	FOREIGN KEY (regCode) 
		REFERENCES regCodes (regCode) ON DELETE CASCADE
);
CREATE TABLE personalDetails(	
	username	VARCHAR(20)		NOT NULL,
	firstName	VARCHAR(20)		NOT NULL,
	lastName	VARCHAR(30)		NOT NULL,
	street		VARCHAR(60)		NOT NULL,
	city		VARCHAR(30)		NOT NULL,
	
	CONSTRAINT perD_pk_user PRIMARY KEY (username),
	
	CONSTRAINT perD_fk_user	FOREIGN KEY (username) 
		REFERENCES loginDetails (username) ON DELETE CASCADE
);
CREATE TABLE contactDetails(
	username	VARCHAR(20)		NOT NULL,
	mobile		INTEGER,
	home		INTEGER,
	
	CONSTRAINT conD_pk_user PRIMARY KEY (username),
	
	CONSTRAINT	conD_fk_regCode	FOREIGN KEY (username) 
		REFERENCES loginDetails (username) ON DELETE CASCADE
);

CREATE TABLE books(
	isbn		VARCHAR(20)		NOT NULL,
	title		VARCHAR(30)		NOT NULL,
	fname		VARCHAR(30)		NOT NULL,
	lname		VARCHAR(30)		NOT NULL,
	genre		VARCHAR(20)		NOT NULL,
	published	DATE			NOT NULL,
	pic			VARCHAR(10)		NOT NULL,
	publisher	VARCHAR(40)		NOT NULL,
	lang		VARCHAR(20)		NOT NULL,
	bType		VARCHAR(1)		NOT NULL DEFAULT 'N',/*N,E*/
	
	CONSTRAINT book_pk_user PRIMARY KEY (isbn)
);
CREATE TABLE newspapersMags(
	nmId		INT				NOT NULL IDENTITY (1,1),
	title		VARCHAR(30)		NOT NULL,
	genre		VARCHAR(20)		NOT NULL,
	published	DATE			NOT NULL,
	lang		VARCHAR(20)		NOT NULL,
	pic			VARCHAR(10)		NOT NULL,
	publisher	VARCHAR(40)		NOT NULL,
	bType		VARCHAR(1)		NOT NULL DEFAULT 'N',/*N,M*/
	
	CONSTRAINT newm_pk_user PRIMARY KEY (nmId)
);
CREATE TABLE comics(
	coId		INT				NOT NULL IDENTITY (1,1),
	title		VARCHAR(30)		NOT NULL,
	genre		VARCHAR(20)		NOT NULL,
	published	DATE			NOT NULL,
	lang		VARCHAR(20)		NOT NULL,
	pic			VARCHAR(10)		NOT NULL,
	publisher	VARCHAR(40)		NOT NULL,
	volume		VARCHAR(4)		NOT NULL,
	
	CONSTRAINT comi_pk_user PRIMARY KEY (coId)
);
CREATE TABLE vidDoc(
	vdId		INT				NOT NULL IDENTITY (1,1),
	title		VARCHAR(30)		NOT NULL,
	genre		VARCHAR(20)		NOT NULL,
	lang		VARCHAR(20)		NOT NULL,
	fname		VARCHAR(30),
	lname		VARCHAR(30),
	duration	INT,
	pic			VARCHAR(10)		NOT NULL,
	vdType		VARCHAR(1)		NOT NULL DEFAULT 'T',/*T,D*/
	
	CONSTRAINT vidD_pk_user PRIMARY KEY (vdId)
);
CREATE TABLE pastPapers(
	ppID		INT				NOT NULL IDENTITY (1,1),
	title		VARCHAR(30)		NOT NULL,
	programme	VARCHAR(30)		NOT NULL,
	eyear		INT				NOT NULL,
	semester	INT				NOT NULL,
	fname		VARCHAR(30),
	lname		VARCHAR(30),
	eDate		DATE			NOT NULL,
	pic			VARCHAR(10)		NOT NULL,
	
	CONSTRAINT ppap_pk_user PRIMARY KEY (ppID)
);

CREATE TABLE resourceCodes(
	rID			INT				NOT NULL IDENTITY (1,1),
	rCode		VARCHAR(50)		NOT NULL,	
	rType 		VARCHAR(50)		NOT NULL,
	
	CONSTRAINT resCode_pk_user PRIMARY KEY (rID)
);
	
	


