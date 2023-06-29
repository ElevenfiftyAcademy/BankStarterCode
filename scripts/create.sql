USE master
GO

CREATE DATABASE BankDb
GO

USE BankDb
GO

CREATE TABLE [dbo].[Users]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(50) NOT NULL,
    [Email] NVARCHAR(50) NOT NULL
);

CREATE TABLE [dbo].[Accounts]
(
    [AccountNumber] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Label] NVARCHAR(50) NULL,
    [AccountHolderId] INT FOREIGN KEY REFERENCES [dbo].[Users]([Id])
);

CREATE TABLE [dbo].[Transactions]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [DateTime] DATETIME2 NOT NULL,
    [Amount] float NOT NULL,
    [Type] INT NOT NULL CHECK ([Type] >= 0 AND [Type] < 2),
    [AccountNumber] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Accounts]([AccountNumber])
)
GO

INSERT INTO [dbo].[Users]
    ([Name], [Email])
VALUES
    ('Joshua', 'jtucker@elevenfifty.org'),
    ('Andrew', 'atorr@elevenfifty.org'),
    ('John', 'john@elevenfifty.org')
GO

INSERT INTO [dbo].[Accounts]
    ([AccountHolderId], [Label])
VALUES
    (1, 'Checking'),
    (1, 'My Savings'),
    (2, 'Checking'),
    (2, 'Savings'),
    (2, 'Credit'),
    (3, 'My Account')
GO

INSERT INTO [dbo].[Transactions]
    ([AccountNumber], [Amount], [Type], [DateTime])
VALUES
    (1, 1000, 0, GETDATE()),
    (1, 100, 1, GETDATE()),
    (1, 50, 1, GETDATE()),
    (2, 25, 0, GETDATE()),
    (3, 5000, 0, GETDATE()),
    (4, 7500, 0, GETDATE()),
    (6, 10000, 0, GETDATE()),
    (6, 1150, 1, GETDATE())
GO