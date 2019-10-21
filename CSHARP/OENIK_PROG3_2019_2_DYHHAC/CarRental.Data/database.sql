CREATE TABLE users
(
	userID INT,
	name VARCHAR(50) NOT NULL,
	email VARCHAR(50) NOT NULL UNIQUE,
	address VARCHAR(30) NOT NULL,
	birthdate DATETIME NOT NULL,
	CONSTRAINT users_pk PRIMARY KEY (userID)
);
CREATE TABLE licenses
(
	licenseID VARCHAR(10),
	userID INT NOT NULL,
	category VARCHAR(3) NOT NULL,
	startDate DATETIME NOT NULL,
	expiryDate DATETIME NOT NULL,
	penaltyPoints INT,
	CONSTRAINT license_userid FOREIGN KEY (userID) REFERENCES users(userID),
	CONSTRAINT licenses_pk PRIMARY KEY (licenseID)
);
CREATE TABLE cars
(
	plate VARCHAR(7) NOT NULL,
	brand VARCHAR(30) NOT NULL,
	model VARCHAR(30) NOT NULL,
	battery INT NOT NULL,
	extraPrice INT,
	CONSTRAINT cars_pk PRIMARY KEY (plate),
	CONSTRAINT cars_battery_chk CHECK ( battery BETWEEN 0 AND 100)
);
CREATE TABLE rents
(
	rentID INT NOT NULL,
	userID INT NOT NULL,
	carID VARCHAR(7) NOT NULL,
	starttime DATETIME2(0) NOT NULL,
	endtime DATETIME2(0),
	distance INT,
	CONSTRAINT rents_userid FOREIGN KEY (userID) REFERENCES users(userID),
	CONSTRAINT rents_carid FOREIGN KEY (carID) REFERENCES cars(plate),
	CONSTRAINT rents_pk PRIMARY KEY (rentID)
);
CREATE TABLE complaints
(
	complaintID INT NOT NULL,
	rentID INT NOT NULL,
	description VARCHAR(256) NOT NULL,
	CONSTRAINT complaints_rentid FOREIGN KEY (rentID) REFERENCES rents(rentID),
	CONSTRAINT complaints_pk PRIMARY KEY (complaintID)
);

CREATE TABLE subscriptions
(
	subID INT NOT NULL,
	userID INT NOT NULL,
	minute INT,
	monthly INT,
	CONSTRAINT subscriptions_userid FOREIGN KEY (userID) REFERENCES users(userID),
	CONSTRAINT subscriptions_pk PRIMARY KEY (subID)
);

CREATE TABLE invoices
(
	invoiceID INT NOT NULL,
	rentID INT NOT NULL,
	total INT,
	completed INT NOT NULL,
	CONSTRAINT invoices_rentid FOREIGN KEY (rentID) REFERENCES rents(rentID),
	CONSTRAINT completion_chk CHECK (completed = 0 OR completed = 1),
	CONSTRAINT invoices_pk PRIMARY KEY (invoiceID)
);