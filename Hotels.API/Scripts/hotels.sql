
-- Script date 9.1.2023. 13:28:10
-- Server version: 15.00.4153
--


SET DATEFORMAT ymd
SET ARITHABORT, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER, ANSI_NULLS, NOCOUNT ON
SET NUMERIC_ROUNDABORT, IMPLICIT_TRANSACTIONS, XACT_ABORT OFF
GO

USE Hotels
GO

IF DB_NAME() <> N'Hotels' SET NOEXEC ON
GO

--
-- Create table [dbo].[Hotels]
--
PRINT (N'Create table [dbo].[Hotels]')
GO
IF OBJECT_ID(N'dbo.Hotels', 'U') IS NULL
CREATE TABLE dbo.Hotels (
  Id int IDENTITY,
  Name nvarchar(max) NOT NULL,
  Price decimal(18, 2) NOT NULL,
  Longitude float NOT NULL,
  Latutude float NOT NULL,
  CONSTRAINT PK_Hotels PRIMARY KEY CLUSTERED (Id)
)
ON [PRIMARY]
TEXTIMAGE_ON [PRIMARY]
GO

-- 
-- Dumping data for table Hotels
--
PRINT (N'Dumping data for table Hotels')
SET IDENTITY_INSERT dbo.Hotels ON
GO
INSERT dbo.Hotels(Id, Name, Price, Longitude, Latutude) VALUES (1, N'Adrion Aparthotel', 103.00, 13.8131321, 44.8950001)
INSERT dbo.Hotels(Id, Name, Price, Longitude, Latutude) VALUES (2, N'B&B Sonia', 56.00, 13.8263311, 44.8921259)
INSERT dbo.Hotels(Id, Name, Price, Longitude, Latutude) VALUES (3, N'Crazy House Hostel', 53.00, 13.826331, 44.8920093)
INSERT dbo.Hotels(Id, Name, Price, Longitude, Latutude) VALUES (4, N'Villa Brandestini', 217.00, 13.8200907, 44.8953402)
INSERT dbo.Hotels(Id, Name, Price, Longitude, Latutude) VALUES (5, N'Milan Hotel', 150.00, 13.7962011, 44.8982558)
GO
SET IDENTITY_INSERT dbo.Hotels OFF
GO
SET NOEXEC OFF
GO