CREATE TABLE [dbo].[Account] (
    [accountID] INT          IDENTITY (1, 1) NOT NULL,
    [name]      VARCHAR (50) NOT NULL,
    [email]     VARCHAR (50) NOT NULL,
    [address]   VARCHAR (30) NOT NULL,
    [birthdate] DATETIME     NOT NULL,
    PRIMARY KEY CLUSTERED ([accountID] ASC),
    UNIQUE NONCLUSTERED ([email] ASC)
);

CREATE TABLE [dbo].[Car] (
    [plate]      VARCHAR (7)  NOT NULL,
    [brand]      VARCHAR (30) NOT NULL,
    [model]      VARCHAR (30) NOT NULL,
    [battery]    INT          NOT NULL,
    [extraPrice] INT          NULL,
    PRIMARY KEY CLUSTERED ([plate] ASC),
    CONSTRAINT [car_battery_chk] CHECK ([battery]>=(0) AND [battery]<=(100))
);

CREATE TABLE [dbo].[License] (
    [licenseID]     VARCHAR (10) NOT NULL,
    [accountID]     INT          NOT NULL,
    [category]      VARCHAR (3)  NOT NULL,
    [startDate]     DATETIME     NOT NULL,
    [expiryDate]    DATETIME     NOT NULL,
    [penaltyPoints] INT          NULL,
    PRIMARY KEY CLUSTERED ([licenseID] ASC),
    CONSTRAINT [license_accountid] FOREIGN KEY ([accountID]) REFERENCES [dbo].[Account] ([accountID])
);

CREATE TABLE [dbo].[Subscription] (
    [subID]     INT IDENTITY (1, 1) NOT NULL,
    [accountID] INT NOT NULL,
    [minute]    INT NULL,
    [monthly]   INT NULL,
    [company]   INT NULL,
    PRIMARY KEY CLUSTERED ([subID] ASC),
    CONSTRAINT [subscriptions_accid] FOREIGN KEY ([accountID]) REFERENCES [dbo].[Account] ([accountID]),
    CONSTRAINT [subscriptions_company] CHECK ([company]=(0) OR [company]=(1))
);

CREATE TABLE [dbo].[Rent] (
    [rentID]    INT           IDENTITY (1, 1) NOT NULL,
    [accountID] INT           NOT NULL,
    [carID]     VARCHAR (7)   NOT NULL,
    [starttime] DATETIME2 (0) NOT NULL,
    [endtime]   DATETIME2 (0) NULL,
    [distance]  INT           NULL,
    PRIMARY KEY CLUSTERED ([rentID] ASC),
    CONSTRAINT [rents_accountid] FOREIGN KEY ([accountID]) REFERENCES [dbo].[Account] ([accountID]),
    CONSTRAINT [rents_carid] FOREIGN KEY ([carID]) REFERENCES [dbo].[Car] ([plate])
);

CREATE TABLE [dbo].[Invoice] (
    [invoiceID] INT      IDENTITY (1, 1) NOT NULL,
    [rentID]    INT      NOT NULL,
    [total]     INT      NULL,
    [completed] INT      NOT NULL,
    [time]      DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([invoiceID] ASC),
    CONSTRAINT [invoice_rentid] FOREIGN KEY ([rentID]) REFERENCES [dbo].[Rent] ([rentID]),
    CONSTRAINT [completion_chk] CHECK ([completed]=(0) OR [completed]=(1))
);
CREATE TABLE [dbo].[Complaint] (
    [complaintID] INT           IDENTITY (1, 1) NOT NULL,
    [rentID]      INT           NOT NULL,
    [description] VARCHAR (256) NOT NULL,
    [time]        DATETIME      NOT NULL,
    [checked]     INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([complaintID] ASC),
    CONSTRAINT [complaints_rentid] FOREIGN KEY ([rentID]) REFERENCES [dbo].[Rent] ([rentID]),
    CONSTRAINT [complaints_chk] CHECK ([checked]=(0) OR [checked]=(1))
);

SET IDENTITY_INSERT [dbo].[Account] ON
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (1, N'Szabó Sándor', N'sandor.szabo@uni-obuda.hu', N'Érd', N'1976-12-06 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (2, N'Kovács Ádám', N'adam.kovacs@icloud.com', N'Csömör', N'1964-07-18 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (3, N'Lakatos Sándor', N'sandor.lakatos@outlook.com', N'Budakeszi', N'1984-11-01 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (4, N'Vincze Dániel', N'daniel.vincze@outlook.com', N'Solymár', N'1966-07-23 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (5, N'Szabó Ádám', N'adam.szabo@hotmail.com', N'Csömör', N'2002-07-22 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (6, N'Simon András', N'andras.simon@uni-obuda.hu', N'Solymár', N'1950-01-17 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (7, N'Szabó András', N'andras.szabo@freemail.hu', N'Dunakeszi', N'1992-04-26 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (8, N'Vincze Béla', N'bela.vincze@freemail.hu', N'Gyál', N'1976-04-28 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (9, N'Lakatos Tamás', N'tamas.lakatos@gmail.com', N'Gyál', N'1993-05-05 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (10, N'Simon Anna', N'anna.simon@gmail.com', N'Vecsés', N'1981-11-09 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (11, N'Nagy Sándor', N'sandor.nagy@icloud.com', N'Csömör', N'1976-05-18 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (12, N'Horváth Tamás', N'tamas.horvath@hotmail.com', N'Gödöllo', N'1983-11-15 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (13, N'Lakatos Ádám', N'adam.lakatos@icloud.com', N'Budakeszi', N'1967-05-12 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (14, N'Tóth Tamás', N'tamas.toth@uni-obuda.hu', N'Dunakeszi', N'1960-04-15 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (15, N'Molnár Ádám', N'adam.molnar@freemail.hu', N'Szentendre', N'1998-05-14 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (16, N'Kiss Dániel', N'daniel.kiss@citromail.hu', N'Vecsés', N'1976-09-04 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (17, N'Vincze Ádám', N'adam.vincze@outlook.com', N'Budakeszi', N'1951-07-22 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (18, N'Papp Ádám', N'adam.papp@outlook.com', N'Dunakeszi', N'2003-09-06 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (19, N'Nagy Ádám', N'adam.nagy@hotmail.com', N'Budakeszi', N'1966-03-25 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (20, N'Kiss József', N'jozsef.kiss@freemail.hu', N'Érd', N'1974-01-10 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (21, N'Lakatos Kata', N'kata.lakatos@hotmail.com', N'Solymár', N'1992-01-05 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (22, N'Kovács Béla', N'bela.kovacs@gmail.com', N'Érd', N'1993-06-12 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (23, N'Vincze Kata', N'kata.vincze@freemail.hu', N'Csömör', N'1963-12-22 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (24, N'Lakatos Anna', N'anna.lakatos@freemail.hu', N'Dunakeszi', N'1994-05-23 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (25, N'Papp Anna', N'anna.papp@hotmail.com', N'Budakalász', N'1978-04-13 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (26, N'Molnár Tamás', N'tamas.molnar@gmail.com', N'Dunakeszi', N'1966-05-26 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (27, N'Horváth Andrea', N'andrea.horvath@uni-obuda.hu', N'Budakeszi', N'1977-04-02 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (28, N'Simon Kata', N'kata.simon@hotmail.com', N'Budakalász', N'1999-09-14 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (29, N'Kovács Andrea', N'andrea.kovacs@outlook.com', N'Budakeszi', N'1966-03-14 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (30, N'Tóth András', N'andras.toth@icloud.com', N'Budakeszi', N'1953-07-22 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (31, N'Tóth Ádám', N'adam.toth@citromail.hu', N'Budakalász', N'1987-11-27 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (32, N'Papp Andrea', N'andrea.papp@citromail.hu', N'Budapest', N'1994-10-10 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (33, N'Papp Dániel', N'daniel.papp@gmail.com', N'Solymár', N'1978-12-18 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (34, N'Papp András', N'andras.papp@icloud.com', N'Dunakeszi', N'1986-06-28 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (35, N'Papp Tamás', N'tamas.papp@gmail.com', N'Mogyoród', N'1994-04-13 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (36, N'Simon Dávid', N'david.simon@uni-obuda.hu', N'Budaörs', N'1967-04-02 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (37, N'Tóth Sándor', N'sandor.toth@hotmail.com', N'Budapest', N'1980-10-25 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (38, N'Tóth Anna', N'anna.toth@hotmail.com', N'Dunakeszi', N'1971-12-12 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (39, N'Simon László', N'laszlo.simon@citromail.hu', N'Gödöllo', N'1950-07-26 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (40, N'Kiss Béla', N'bela.kiss@gmail.com', N'Mogyoród', N'1964-06-12 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (41, N'Papp Kata', N'kata.papp@hotmail.com', N'Mogyoród', N'1968-04-15 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (42, N'Papp Dávid', N'david.papp@gmail.com', N'Dunakeszi', N'1978-02-25 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (43, N'Kiss Andrea', N'andrea.kiss@uni-obuda.hu', N'Budakeszi', N'1964-07-06 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (44, N'Simon Tamás', N'tamas.simon@gmail.com', N'Vecsés', N'1952-03-14 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (45, N'Tóth László', N'laszlo.toth@icloud.com', N'Budaörs', N'1979-07-13 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (46, N'Vincze András', N'andras.vincze@uni-obuda.hu', N'Érd', N'1979-03-07 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (47, N'Tóth József', N'jozsef.toth@gmail.com', N'Budakeszi', N'1979-12-15 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (48, N'Kiss Dávid', N'david.kiss@freemail.hu', N'Vecsés', N'1967-11-03 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (49, N'Nagy Tamás', N'tamas.nagy@outlook.com', N'Szentendre', N'1970-03-26 00:00:00')
INSERT INTO [dbo].[Account] ([accountID], [name], [email], [address], [birthdate]) VALUES (50, N'Kovács Kata', N'kata.kovacs@gmail.com', N'Csömör', N'1950-07-07 00:00:00')
SET IDENTITY_INSERT [dbo].[Account] OFF

INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'AD139169', 18, N'C', N'2017-08-02 00:00:00', N'2022-08-02 00:00:00', 3)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'AN792219', 35, N'C', N'2012-10-08 00:00:00', N'2017-10-08 00:00:00', 3)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'AO956806', 3, N'C', N'2018-11-11 00:00:00', N'2023-11-11 00:00:00', 1)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'CA341269', 38, N'C', N'2013-01-16 00:00:00', N'2018-01-16 00:00:00', 3)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'CL064629', 28, N'AM', N'2015-11-28 00:00:00', N'2020-11-28 00:00:00', 1)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'CL501275', 30, N'C', N'2013-12-09 00:00:00', N'2018-12-09 00:00:00', 1)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'CY070357', 45, N'A', N'2014-12-09 00:00:00', N'2019-12-09 00:00:00', 0)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'CZ495969', 7, N'C', N'2016-01-11 00:00:00', N'2021-01-11 00:00:00', 3)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'DZ167847', 29, N'A', N'2012-06-07 00:00:00', N'2017-06-07 00:00:00', 3)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'FB162550', 25, N'A', N'2018-05-08 00:00:00', N'2023-05-08 00:00:00', 1)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'FC773148', 11, N'B', N'2013-05-16 00:00:00', N'2018-05-16 00:00:00', 1)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'GH943697', 48, N'D', N'2017-01-09 00:00:00', N'2022-01-09 00:00:00', 0)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'GI996281', 47, N'C', N'2014-02-25 00:00:00', N'2019-02-25 00:00:00', 0)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'GJ979364', 6, N'D', N'2016-07-21 00:00:00', N'2021-07-21 00:00:00', 1)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'GV028018', 41, N'AM', N'2012-12-12 00:00:00', N'2017-12-12 00:00:00', 1)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'HA342934', 2, N'AM', N'2015-06-06 00:00:00', N'2020-06-06 00:00:00', 1)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'HY693753', 20, N'D', N'2017-09-08 00:00:00', N'2022-09-08 00:00:00', 2)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'HZ471527', 19, N'AM', N'2013-06-07 00:00:00', N'2018-06-07 00:00:00', 2)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'IG130069', 31, N'D', N'2015-09-20 00:00:00', N'2020-09-20 00:00:00', 1)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'JG099603', 15, N'D', N'2012-09-10 00:00:00', N'2017-09-10 00:00:00', 3)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'KG192819', 46, N'B', N'2018-06-13 00:00:00', N'2023-06-13 00:00:00', 1)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'KS187585', 43, N'B', N'2015-01-02 00:00:00', N'2020-01-02 00:00:00', 3)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'KY741577', 44, N'B', N'2014-12-09 00:00:00', N'2019-12-09 00:00:00', 3)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'LA042657', 9, N'A', N'2014-09-04 00:00:00', N'2019-09-04 00:00:00', 3)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'LB100432', 1, N'D', N'2017-12-16 00:00:00', N'2022-12-16 00:00:00', 1)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'LH296279', 13, N'D', N'2013-07-27 00:00:00', N'2018-07-27 00:00:00', 3)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'MP393755', 26, N'C', N'2016-02-28 00:00:00', N'2021-02-28 00:00:00', 1)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'MX353851', 21, N'A', N'2018-06-27 00:00:00', N'2023-06-27 00:00:00', 1)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'NA094115', 4, N'B', N'2016-08-08 00:00:00', N'2021-08-08 00:00:00', 1)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'NF346224', 24, N'B', N'2018-06-05 00:00:00', N'2023-06-05 00:00:00', 0)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'OV504165', 10, N'AM', N'2012-09-21 00:00:00', N'2017-09-21 00:00:00', 0)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'OZ919710', 27, N'B', N'2017-03-28 00:00:00', N'2022-03-28 00:00:00', 3)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'PS777923', 5, N'B', N'2017-12-12 00:00:00', N'2022-12-12 00:00:00', 1)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'QD504540', 16, N'D', N'2017-12-06 00:00:00', N'2022-12-06 00:00:00', 3)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'QE500362', 8, N'C', N'2013-07-26 00:00:00', N'2018-07-26 00:00:00', 2)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'RB628181', 14, N'C', N'2018-05-07 00:00:00', N'2023-05-07 00:00:00', 3)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'RN635550', 37, N'B', N'2012-03-04 00:00:00', N'2017-03-04 00:00:00', 0)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'RO652974', 34, N'AM', N'2012-03-01 00:00:00', N'2017-03-01 00:00:00', 0)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'SI981765', 42, N'AM', N'2015-02-19 00:00:00', N'2020-02-19 00:00:00', 2)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'SQ974440', 22, N'C', N'2012-06-17 00:00:00', N'2017-06-17 00:00:00', 1)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'TD274006', 32, N'A', N'2016-04-17 00:00:00', N'2021-04-17 00:00:00', 0)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'UP655330', 36, N'C', N'2016-02-13 00:00:00', N'2021-02-13 00:00:00', 2)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'VG526328', 50, N'B', N'2012-03-04 00:00:00', N'2017-03-04 00:00:00', 1)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'VH776081', 17, N'C', N'2017-08-05 00:00:00', N'2022-08-05 00:00:00', 3)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'VK817439', 23, N'A', N'2014-12-14 00:00:00', N'2019-12-14 00:00:00', 1)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'WL252833', 39, N'A', N'2016-03-17 00:00:00', N'2021-03-17 00:00:00', 0)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'XW370489', 40, N'B', N'2012-01-23 00:00:00', N'2017-01-23 00:00:00', 3)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'YY852077', 33, N'A', N'2018-03-07 00:00:00', N'2023-03-07 00:00:00', 1)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'ZM285239', 49, N'C', N'2014-07-22 00:00:00', N'2019-07-22 00:00:00', 0)
INSERT INTO [dbo].[License] ([licenseID], [accountID], [category], [startDate], [expiryDate], [penaltyPoints]) VALUES (N'ZR693232', 12, N'C', N'2012-05-08 00:00:00', N'2017-05-08 00:00:00', 1)

SET IDENTITY_INSERT [dbo].[Subscription] ON
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (1, 49, 100, 0, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (2, 4, 60, 1500, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (3, 41, 35, 4000, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (4, 47, 60, 1500, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (5, 27, 35, 4000, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (6, 24, 60, 1500, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (7, 40, 35, 4000, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (8, 13, 35, 4000, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (9, 31, 100, 0, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (10, 43, 60, 1500, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (11, 30, 100, 0, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (12, 10, 60, 1500, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (13, 5, 60, 1500, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (14, 37, 60, 1500, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (15, 42, 35, 4000, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (16, 46, 60, 1500, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (17, 18, 100, 0, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (18, 29, 100, 0, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (19, 35, 100, 0, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (20, 26, 35, 4000, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (21, 3, 100, 0, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (22, 45, 100, 0, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (23, 25, 35, 4000, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (24, 9, 60, 1500, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (25, 8, 60, 1500, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (26, 34, 35, 4000, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (27, 14, 100, 0, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (28, 22, 60, 1500, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (29, 20, 100, 0, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (30, 32, 35, 4000, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (31, 17, 100, 0, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (32, 28, 60, 1500, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (33, 48, 35, 4000, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (34, 15, 100, 0, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (35, 39, 35, 4000, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (36, 44, 60, 1500, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (37, 2, 60, 1500, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (38, 16, 60, 1500, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (39, 38, 100, 0, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (40, 33, 100, 0, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (41, 21, 35, 4000, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (42, 7, 100, 0, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (43, 12, 100, 0, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (44, 50, 35, 4000, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (45, 11, 100, 0, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (46, 19, 60, 1500, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (47, 6, 100, 0, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (48, 23, 60, 1500, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (49, 1, 100, 0, 0)
INSERT INTO [dbo].[Subscription] ([subID], [accountID], [minute], [monthly], [company]) VALUES (50, 36, 60, 1500, 0)
SET IDENTITY_INSERT [dbo].[Subscription] OFF


INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RAF-627', N'Audi', N'e-Tron', 72, 60)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RAN-742', N'BMW', N'i3', 58, 40)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RCM-590', N'Audi', N'e-Tron', 49, 60)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RDZ-849', N'Nissan', N'Leaf', 100, 20)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RGS-729', N'Audi', N'e-Tron', 73, 60)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RHF-416', N'Nissan', N'Leaf', 68, 20)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RHW-377', N'Volkswagen', N'e-Up', 15, 0)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RJD-122', N'Volkswagen', N'e-Up', 16, 0)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RJN-986', N'Audi', N'e-Tron', 4, 60)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RKI-574', N'Volkswagen', N'e-Golf', 95, 20)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RMA-675', N'Nissan', N'Leaf', 11, 20)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RMI-360', N'Volkswagen', N'e-Up', 9, 0)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RML-693', N'Nissan', N'Leaf', 54, 20)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RNK-327', N'Volkswagen', N'e-Golf', 86, 20)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RNK-571', N'Volkswagen', N'e-Up', 24, 0)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'ROP-441', N'Volkswagen', N'e-Golf', 86, 20)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'ROW-468', N'Volkswagen', N'e-Up', 15, 0)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RPQ-711', N'BMW', N'i3', 51, 40)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RPQ-987', N'BMW', N'i3', 34, 40)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RQA-762', N'Audi', N'e-Tron', 84, 60)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RRE-810', N'Nissan', N'Leaf', 51, 20)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RRJ-555', N'Nissan', N'Leaf', 14, 20)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RRU-535', N'Audi', N'e-Tron', 63, 60)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RTM-414', N'Volkswagen', N'e-Up', 42, 0)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RUJ-412', N'Volkswagen', N'e-Up', 65, 0)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RUT-723', N'Volkswagen', N'e-Golf', 19, 20)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RVC-172', N'Nissan', N'Leaf', 48, 20)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RVE-852', N'BMW', N'i3', 48, 40)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RVI-350', N'Volkswagen', N'e-Golf', 52, 20)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RWV-487', N'Audi', N'e-Tron', 88, 60)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RXQ-883', N'Volkswagen', N'e-Up', 30, 0)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RYM-262', N'Nissan', N'Leaf', 55, 20)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RYO-408', N'Audi', N'e-Tron', 53, 60)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RYS-267', N'Volkswagen', N'e-Up', 23, 0)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RZE-984', N'Nissan', N'Leaf', 76, 20)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RZH-919', N'Volkswagen', N'e-Up', 99, 0)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RZH-925', N'Volkswagen', N'e-Golf', 7, 20)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RZH-978', N'Nissan', N'Leaf', 42, 20)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RZR-150', N'Volkswagen', N'e-Golf', 30, 20)
INSERT INTO [dbo].[Car] ([plate], [brand], [model], [battery], [extraPrice]) VALUES (N'RZR-703', N'Volkswagen', N'e-Up', 12, 0)

SET IDENTITY_INSERT [dbo].[Rent] ON
INSERT INTO [dbo].[Rent] ([rentID], [accountID], [carID], [starttime], [endtime], [distance]) VALUES (1, 41, N'RPQ-711', N'2019-10-12 22:57:00', N'2019-10-12 23:12:00', 8)
INSERT INTO [dbo].[Rent] ([rentID], [accountID], [carID], [starttime], [endtime], [distance]) VALUES (2, 12, N'RRU-535', N'2019-10-14 05:04:00', N'2019-10-14 05:17:00', 6)
INSERT INTO [dbo].[Rent] ([rentID], [accountID], [carID], [starttime], [endtime], [distance]) VALUES (3, 19, N'RZH-978', N'2019-10-12 18:59:00', N'2019-10-12 19:06:00', 4)
INSERT INTO [dbo].[Rent] ([rentID], [accountID], [carID], [starttime], [endtime], [distance]) VALUES (4, 38, N'RRU-535', N'2019-10-04 15:56:00', N'2019-10-04 17:00:00', 31)
INSERT INTO [dbo].[Rent] ([rentID], [accountID], [carID], [starttime], [endtime], [distance]) VALUES (5, 27, N'RAF-627', N'2019-10-21 05:22:00', N'2019-10-21 05:51:00', 15)
INSERT INTO [dbo].[Rent] ([rentID], [accountID], [carID], [starttime], [endtime], [distance]) VALUES (6, 8, N'RML-693', N'2019-10-10 06:43:00', N'2019-10-10 07:21:00', 20)
INSERT INTO [dbo].[Rent] ([rentID], [accountID], [carID], [starttime], [endtime], [distance]) VALUES (7, 13, N'RAN-742', N'2019-10-11 16:59:00', N'2019-10-11 17:24:00', 11)
INSERT INTO [dbo].[Rent] ([rentID], [accountID], [carID], [starttime], [endtime], [distance]) VALUES (8, 26, N'RYS-267', N'2019-10-11 16:59:00', N'2019-10-11 18:00:00', 28)
INSERT INTO [dbo].[Rent] ([rentID], [accountID], [carID], [starttime], [endtime], [distance]) VALUES (9, 48, N'RRE-810', N'2019-10-15 06:03:00', N'2019-10-15 07:05:00', 25)
INSERT INTO [dbo].[Rent] ([rentID], [accountID], [carID], [starttime], [endtime], [distance]) VALUES (10, 25, N'RKI-574', N'2019-10-04 15:56:00', N'2019-10-04 16:31:00', 16)
INSERT INTO [dbo].[Rent] ([rentID], [accountID], [carID], [starttime], [endtime], [distance]) VALUES (11, 50, N'RRE-810', N'2019-10-19 03:58:00', N'2019-10-19 04:25:00', 15)
INSERT INTO [dbo].[Rent] ([rentID], [accountID], [carID], [starttime], [endtime], [distance]) VALUES (12, 17, N'RRU-535', N'2019-10-04 04:03:00', N'2019-10-04 04:30:00', 14)
INSERT INTO [dbo].[Rent] ([rentID], [accountID], [carID], [starttime], [endtime], [distance]) VALUES (13, 10, N'RQA-762', N'2019-10-17 05:37:00', N'2019-10-17 05:59:00', 9)
INSERT INTO [dbo].[Rent] ([rentID], [accountID], [carID], [starttime], [endtime], [distance]) VALUES (14, 46, N'RZR-150', N'2019-10-01 16:16:00', N'2019-10-01 17:01:00', 16)
INSERT INTO [dbo].[Rent] ([rentID], [accountID], [carID], [starttime], [endtime], [distance]) VALUES (15, 45, N'RWV-487', N'2019-10-21 06:14:00', N'2019-10-21 06:39:00', 12)
INSERT INTO [dbo].[Rent] ([rentID], [accountID], [carID], [starttime], [endtime], [distance]) VALUES (16, 18, N'RYO-408', N'2019-10-08 09:41:00', N'2019-10-08 09:50:00', 4)
INSERT INTO [dbo].[Rent] ([rentID], [accountID], [carID], [starttime], [endtime], [distance]) VALUES (17, 12, N'RWV-487', N'2019-10-08 09:41:00', N'2019-10-08 09:46:00', 3)
INSERT INTO [dbo].[Rent] ([rentID], [accountID], [carID], [starttime], [endtime], [distance]) VALUES (18, 4, N'RXQ-883', N'2019-10-04 04:03:00', N'2019-10-04 04:31:00', 10)
INSERT INTO [dbo].[Rent] ([rentID], [accountID], [carID], [starttime], [endtime], [distance]) VALUES (19, 21, N'RUJ-412', N'2019-10-05 16:48:00', N'2019-10-05 17:04:00', 7)
INSERT INTO [dbo].[Rent] ([rentID], [accountID], [carID], [starttime], [endtime], [distance]) VALUES (20, 11, N'RTM-414', N'2019-10-03 05:06:00', N'2019-10-03 05:49:00', 18)
INSERT INTO [dbo].[Rent] ([rentID], [accountID], [carID], [starttime], [endtime], [distance]) VALUES (21, 33, N'RRJ-555', N'2019-10-03 05:06:00', N'2019-10-03 05:29:00', 11)
INSERT INTO [dbo].[Rent] ([rentID], [accountID], [carID], [starttime], [endtime], [distance]) VALUES (22, 45, N'RJN-986', N'2019-10-14 15:12:00', N'2019-10-14 15:58:00', 22)
INSERT INTO [dbo].[Rent] ([rentID], [accountID], [carID], [starttime], [endtime], [distance]) VALUES (23, 21, N'RRE-810', N'2019-10-17 05:37:00', N'2019-10-17 05:42:00', 2)
INSERT INTO [dbo].[Rent] ([rentID], [accountID], [carID], [starttime], [endtime], [distance]) VALUES (24, 4, N'RPQ-711', N'2019-10-17 05:37:00', N'2019-10-17 06:08:00', 12)
INSERT INTO [dbo].[Rent] ([rentID], [accountID], [carID], [starttime], [endtime], [distance]) VALUES (25, 11, N'RRE-810', N'2019-10-12 22:57:00', N'2019-10-12 23:38:00', 21)
INSERT INTO [dbo].[Rent] ([rentID], [accountID], [carID], [starttime], [endtime], [distance]) VALUES (26, 32, N'RAF-627', N'2019-10-08 09:41:00', N'2019-10-08 10:45:00', 29)
INSERT INTO [dbo].[Rent] ([rentID], [accountID], [carID], [starttime], [endtime], [distance]) VALUES (27, 38, N'RZH-925', N'2019-10-21 04:12:00', N'2019-10-21 05:00:00', 24)
INSERT INTO [dbo].[Rent] ([rentID], [accountID], [carID], [starttime], [endtime], [distance]) VALUES (28, 33, N'RZR-150', N'2019-10-05 16:48:00', N'2019-10-05 17:18:00', 17)
INSERT INTO [dbo].[Rent] ([rentID], [accountID], [carID], [starttime], [endtime], [distance]) VALUES (29, 47, N'RHW-377', N'2019-10-12 22:57:00', N'2019-10-12 23:51:00', 27)
INSERT INTO [dbo].[Rent] ([rentID], [accountID], [carID], [starttime], [endtime], [distance]) VALUES (30, 12, N'RGS-729', N'2019-10-05 16:48:00', N'2019-10-05 17:38:00', 21)
SET IDENTITY_INSERT [dbo].[Rent] OFF


SET IDENTITY_INSERT [dbo].[Invoice] ON
INSERT INTO [dbo].[Invoice] ([invoiceID], [rentID], [total], [completed], [time]) VALUES (1, 28, NULL, 0, N'2019-10-05 17:18:00')
INSERT INTO [dbo].[Invoice] ([invoiceID], [rentID], [total], [completed], [time]) VALUES (2, 25, NULL, 0, N'2019-10-12 23:38:00')
INSERT INTO [dbo].[Invoice] ([invoiceID], [rentID], [total], [completed], [time]) VALUES (3, 8, NULL, 0, N'2019-10-11 18:00:00')
INSERT INTO [dbo].[Invoice] ([invoiceID], [rentID], [total], [completed], [time]) VALUES (4, 13, NULL, 0, N'2019-10-17 05:59:00')
INSERT INTO [dbo].[Invoice] ([invoiceID], [rentID], [total], [completed], [time]) VALUES (5, 18, NULL, 1, N'2019-10-04 04:31:00')
INSERT INTO [dbo].[Invoice] ([invoiceID], [rentID], [total], [completed], [time]) VALUES (6, 27, NULL, 1, N'2019-10-21 05:00:00')
INSERT INTO [dbo].[Invoice] ([invoiceID], [rentID], [total], [completed], [time]) VALUES (7, 26, NULL, 0, N'2019-10-08 10:45:00')
INSERT INTO [dbo].[Invoice] ([invoiceID], [rentID], [total], [completed], [time]) VALUES (8, 11, NULL, 0, N'2019-10-19 04:25:00')
INSERT INTO [dbo].[Invoice] ([invoiceID], [rentID], [total], [completed], [time]) VALUES (9, 6, NULL, 0, N'2019-10-10 07:21:00')
INSERT INTO [dbo].[Invoice] ([invoiceID], [rentID], [total], [completed], [time]) VALUES (10, 2, NULL, 1, N'2019-10-14 05:17:00')
INSERT INTO [dbo].[Invoice] ([invoiceID], [rentID], [total], [completed], [time]) VALUES (11, 15, NULL, 0, N'2019-10-21 06:39:00')
INSERT INTO [dbo].[Invoice] ([invoiceID], [rentID], [total], [completed], [time]) VALUES (12, 30, NULL, 1, N'2019-10-05 17:38:00')
INSERT INTO [dbo].[Invoice] ([invoiceID], [rentID], [total], [completed], [time]) VALUES (13, 23, NULL, 1, N'2019-10-17 05:42:00')
INSERT INTO [dbo].[Invoice] ([invoiceID], [rentID], [total], [completed], [time]) VALUES (14, 16, NULL, 1, N'2019-10-08 09:50:00')
INSERT INTO [dbo].[Invoice] ([invoiceID], [rentID], [total], [completed], [time]) VALUES (15, 4, NULL, 0, N'2019-10-04 17:00:00')
INSERT INTO [dbo].[Invoice] ([invoiceID], [rentID], [total], [completed], [time]) VALUES (16, 7, NULL, 1, N'2019-10-11 17:24:00')
INSERT INTO [dbo].[Invoice] ([invoiceID], [rentID], [total], [completed], [time]) VALUES (17, 1, NULL, 0, N'2019-10-12 23:12:00')
INSERT INTO [dbo].[Invoice] ([invoiceID], [rentID], [total], [completed], [time]) VALUES (18, 17, NULL, 0, N'2019-10-08 09:46:00')
INSERT INTO [dbo].[Invoice] ([invoiceID], [rentID], [total], [completed], [time]) VALUES (19, 3, NULL, 0, N'2019-10-12 19:06:00')
INSERT INTO [dbo].[Invoice] ([invoiceID], [rentID], [total], [completed], [time]) VALUES (20, 5, NULL, 1, N'2019-10-21 05:51:00')
INSERT INTO [dbo].[Invoice] ([invoiceID], [rentID], [total], [completed], [time]) VALUES (21, 21, NULL, 0, N'2019-10-03 05:29:00')
INSERT INTO [dbo].[Invoice] ([invoiceID], [rentID], [total], [completed], [time]) VALUES (22, 29, NULL, 1, N'2019-10-12 23:51:00')
INSERT INTO [dbo].[Invoice] ([invoiceID], [rentID], [total], [completed], [time]) VALUES (23, 12, NULL, 0, N'2019-10-04 04:30:00')
INSERT INTO [dbo].[Invoice] ([invoiceID], [rentID], [total], [completed], [time]) VALUES (24, 19, NULL, 0, N'2019-10-05 17:04:00')
INSERT INTO [dbo].[Invoice] ([invoiceID], [rentID], [total], [completed], [time]) VALUES (25, 9, NULL, 0, N'2019-10-15 07:05:00')
INSERT INTO [dbo].[Invoice] ([invoiceID], [rentID], [total], [completed], [time]) VALUES (26, 22, NULL, 1, N'2019-10-14 15:58:00')
INSERT INTO [dbo].[Invoice] ([invoiceID], [rentID], [total], [completed], [time]) VALUES (27, 10, NULL, 0, N'2019-10-04 16:31:00')
INSERT INTO [dbo].[Invoice] ([invoiceID], [rentID], [total], [completed], [time]) VALUES (28, 24, NULL, 0, N'2019-10-17 06:08:00')
INSERT INTO [dbo].[Invoice] ([invoiceID], [rentID], [total], [completed], [time]) VALUES (29, 20, NULL, 1, N'2019-10-03 05:49:00')
INSERT INTO [dbo].[Invoice] ([invoiceID], [rentID], [total], [completed], [time]) VALUES (30, 14, NULL, 1, N'2019-10-01 17:01:00')
SET IDENTITY_INSERT [dbo].[Invoice] OFF


SET IDENTITY_INSERT [dbo].[Complaint] ON
INSERT INTO [dbo].[Complaint] ([complaintID], [rentID], [description], [time], [checked]) VALUES (1, 9, N'Nem megfelelo tisztaságú az autó.', N'2019-10-15 07:07:00', 1)
INSERT INTO [dbo].[Complaint] ([complaintID], [rentID], [description], [time], [checked]) VALUES (2, 27, N'Baleset történt, személyi sérülés nélkül.', N'2019-10-21 05:03:00', 0)
INSERT INTO [dbo].[Complaint] ([complaintID], [rentID], [description], [time], [checked]) VALUES (3, 20, N'Meghúzták az autót amíg parkolt.', N'2019-10-03 05:52:00', 0)
INSERT INTO [dbo].[Complaint] ([complaintID], [rentID], [description], [time], [checked]) VALUES (4, 2, N'Baleset történt, személyi sérülés nélkül.', N'2019-10-14 05:18:00', 0)
INSERT INTO [dbo].[Complaint] ([complaintID], [rentID], [description], [time], [checked]) VALUES (5, 1, N'Nem megfelelo tisztaságú az autó.', N'2019-10-12 23:15:00', 1)
INSERT INTO [dbo].[Complaint] ([complaintID], [rentID], [description], [time], [checked]) VALUES (6, 7, N'Baleset történt, személyi sérülés nélkül.', N'2019-10-11 17:28:00', 1)
INSERT INTO [dbo].[Complaint] ([complaintID], [rentID], [description], [time], [checked]) VALUES (7, 28, N'Baleset történt személyi sérüléssel.', N'2019-10-05 17:20:00', 0)
INSERT INTO [dbo].[Complaint] ([complaintID], [rentID], [description], [time], [checked]) VALUES (8, 14, N'Baleset történt, személyi sérülés nélkül.', N'2019-10-01 17:05:00', 0)
SET IDENTITY_INSERT [dbo].[Complaint] OFF



--számolt mezők értékének beállítása:
update Rents
set Price = (DATEDIFF(minute, Rents.StartTime, Rents.EndTime) * minute + DATEDIFF(minute, Rents.StartTime, Rents.EndTime) * ISNULL(Cars.extraPrice, 0))
from Rents
inner join Cars on (Rents.CarID = Cars.CarID)
inner join Accounts on (Rents.accountId = Accounts.accountID);


