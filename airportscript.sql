USE [master]
GO
/****** Object:  Database [Airport]    Script Date: 09.04.2025 2:16:11 ******/
CREATE DATABASE [Airport]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Airport', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Airport.mdf' , SIZE = 139264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Airport_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Airport_log.ldf' , SIZE = 794624KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Airport] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Airport].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Airport] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Airport] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Airport] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Airport] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Airport] SET ARITHABORT OFF 
GO
ALTER DATABASE [Airport] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Airport] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Airport] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Airport] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Airport] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Airport] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Airport] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Airport] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Airport] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Airport] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Airport] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Airport] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Airport] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Airport] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Airport] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Airport] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Airport] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Airport] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Airport] SET  MULTI_USER 
GO
ALTER DATABASE [Airport] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Airport] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Airport] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Airport] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Airport] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Airport] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Airport] SET QUERY_STORE = ON
GO
ALTER DATABASE [Airport] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Airport]
GO
/****** Object:  Table [dbo].[Airlines]    Script Date: 09.04.2025 2:16:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Airlines](
	[IdAirline] [int] NOT NULL,
	[TitleAirlane] [varchar](max) NULL,
	[CodeAirline] [varchar](10) NULL,
 CONSTRAINT [PK_Airlines] PRIMARY KEY CLUSTERED 
(
	[IdAirline] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Airplane]    Script Date: 09.04.2025 2:16:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Airplane](
	[IdAirplane] [int] IDENTITY(1,1) NOT NULL,
	[TitleAirplane] [varchar](50) NOT NULL,
	[TotalSeats] [int] NOT NULL,
 CONSTRAINT [PK_Airplane] PRIMARY KEY CLUSTERED 
(
	[IdAirplane] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Airports]    Script Date: 09.04.2025 2:16:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Airports](
	[IdAirport] [int] IDENTITY(1,1) NOT NULL,
	[TitleAirport] [varchar](max) NOT NULL,
	[CodeIKAO] [varchar](4) NOT NULL,
	[CodeIATA] [varchar](3) NOT NULL,
	[City] [varchar](max) NULL,
 CONSTRAINT [PK_Airports] PRIMARY KEY CLUSTERED 
(
	[IdAirport] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bagage]    Script Date: 09.04.2025 2:16:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bagage](
	[IdBagage] [int] IDENTITY(1,1) NOT NULL,
	[CountBagage] [int] NULL,
	[WeightBagage] [int] NULL,
 CONSTRAINT [PK_Bagage] PRIMARY KEY CLUSTERED 
(
	[IdBagage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 09.04.2025 2:16:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[IdBooking] [int] IDENTITY(1,1) NOT NULL,
	[BookingCode] [varchar](10) NULL,
	[BookingDate] [date] NULL,
	[TotalPrice] [money] NULL,
	[IdBookingStatus] [int] NULL,
 CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED 
(
	[IdBooking] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookingsStatus]    Script Date: 09.04.2025 2:16:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingsStatus](
	[IdBookingStatus] [int] IDENTITY(1,1) NOT NULL,
	[TitleStatus] [varchar](50) NULL,
 CONSTRAINT [PK_BookingsStatus] PRIMARY KEY CLUSTERED 
(
	[IdBookingStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookingTickets]    Script Date: 09.04.2025 2:16:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingTickets](
	[IdBookingTicket] [int] IDENTITY(1,1) NOT NULL,
	[IdBooking] [int] NULL,
	[IdTicketSelling] [int] NULL,
 CONSTRAINT [PK_BookingTickets] PRIMARY KEY CLUSTERED 
(
	[IdBookingTicket] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flights]    Script Date: 09.04.2025 2:16:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flights](
	[IdFlight] [int] IDENTITY(1,1) NOT NULL,
	[FlightNumber] [varchar](7) NOT NULL,
	[IdAirlane] [int] NOT NULL,
	[AirportDeparturesId] [int] NOT NULL,
	[ArrivalAirportId] [int] NOT NULL,
	[DepartureDate] [date] NOT NULL,
	[DepartureTime] [time](7) NOT NULL,
	[TotalSeatsFree] [int] NOT NULL,
	[IdStatus] [int] NOT NULL,
	[IdAirplane] [int] NOT NULL,
	[IdGate] [int] NULL,
	[ArrivalDate] [date] NOT NULL,
	[ArrivalTime] [time](7) NOT NULL,
 CONSTRAINT [PK_Flights] PRIMARY KEY CLUSTERED 
(
	[IdFlight] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormOfPayments]    Script Date: 09.04.2025 2:16:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormOfPayments](
	[FormOfPaymentId] [int] IDENTITY(1,1) NOT NULL,
	[TitleForm] [varchar](50) NULL,
 CONSTRAINT [PK_FormOfPayments] PRIMARY KEY CLUSTERED 
(
	[FormOfPaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gates]    Script Date: 09.04.2025 2:16:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gates](
	[IdGate] [int] IDENTITY(1,1) NOT NULL,
	[IdStatusGate] [int] NULL,
	[GateNumber] [varchar](50) NULL,
 CONSTRAINT [PK_Gates] PRIMARY KEY CLUSTERED 
(
	[IdGate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 09.04.2025 2:16:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registration](
	[IdRegistration] [int] IDENTITY(1,1) NOT NULL,
	[IdBagage] [int] NULL,
	[IdStatusRegistration] [int] NULL,
	[IdTicketSelling] [int] NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[IdRegistration] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 09.04.2025 2:16:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[IdStatus] [int] IDENTITY(1,1) NOT NULL,
	[TitleStatus] [varchar](50) NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[IdStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusGate]    Script Date: 09.04.2025 2:16:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusGate](
	[IdStatusGate] [int] IDENTITY(1,1) NOT NULL,
	[StatusTitile] [varchar](50) NULL,
 CONSTRAINT [PK_StatusGate] PRIMARY KEY CLUSTERED 
(
	[IdStatusGate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusRegistration]    Script Date: 09.04.2025 2:16:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusRegistration](
	[IdStatusRegistration] [int] IDENTITY(1,1) NOT NULL,
	[TitleStatus] [varchar](50) NULL,
 CONSTRAINT [PK_StatusRegistration] PRIMARY KEY CLUSTERED 
(
	[IdStatusRegistration] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TicketsSelling]    Script Date: 09.04.2025 2:16:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicketsSelling](
	[IdTicketSelling] [int] IDENTITY(1,1) NOT NULL,
	[IdFlight] [int] NOT NULL,
	[NumberTicket] [int] NOT NULL,
	[PassportNumber] [varchar](11) NOT NULL,
	[PlaceOfIssue] [varchar](max) NOT NULL,
	[DateOfIssue] [date] NOT NULL,
	[FirstName] [varchar](max) NOT NULL,
	[SecondName] [varchar](max) NOT NULL,
	[Surname] [varchar](max) NULL,
	[DateOfBirth] [date] NOT NULL,
	[BagageCount] [int] NOT NULL,
	[FormOfPaymentId] [int] NULL,
	[Email] [varchar](150) NOT NULL,
 CONSTRAINT [PK_TicketsSelling] PRIMARY KEY CLUSTERED 
(
	[IdTicketSelling] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 09.04.2025 2:16:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](150) NULL,
	[SecondName] [varchar](150) NULL,
	[Surname] [varchar](150) NULL,
	[Login] [varchar](150) NULL,
	[Password] [varchar](max) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Airlines] ([IdAirline], [TitleAirlane], [CodeAirline]) VALUES (1, N'Aeroflot', N'SU')
INSERT [dbo].[Airlines] ([IdAirline], [TitleAirlane], [CodeAirline]) VALUES (2, N'Turkish Airlines', N'TK')
INSERT [dbo].[Airlines] ([IdAirline], [TitleAirlane], [CodeAirline]) VALUES (3, N'Emirates', N'EK')
INSERT [dbo].[Airlines] ([IdAirline], [TitleAirlane], [CodeAirline]) VALUES (4, N'Lufthansa', N'LH')
INSERT [dbo].[Airlines] ([IdAirline], [TitleAirlane], [CodeAirline]) VALUES (5, N'British Airways', N'BA')
INSERT [dbo].[Airlines] ([IdAirline], [TitleAirlane], [CodeAirline]) VALUES (6, N'Air France', N'AF')
INSERT [dbo].[Airlines] ([IdAirline], [TitleAirlane], [CodeAirline]) VALUES (7, N'Qatar Airways', N'QR')
INSERT [dbo].[Airlines] ([IdAirline], [TitleAirlane], [CodeAirline]) VALUES (8, N'Singapore Airlines', N'SQ')
INSERT [dbo].[Airlines] ([IdAirline], [TitleAirlane], [CodeAirline]) VALUES (9, N'Delta Air Lines', N'DL')
INSERT [dbo].[Airlines] ([IdAirline], [TitleAirlane], [CodeAirline]) VALUES (10, N'American Airlines', N'AA')
GO
SET IDENTITY_INSERT [dbo].[Airplane] ON 

INSERT [dbo].[Airplane] ([IdAirplane], [TitleAirplane], [TotalSeats]) VALUES (1, N'Boeing 737', 189)
INSERT [dbo].[Airplane] ([IdAirplane], [TitleAirplane], [TotalSeats]) VALUES (2, N'Airbus A320', 180)
INSERT [dbo].[Airplane] ([IdAirplane], [TitleAirplane], [TotalSeats]) VALUES (3, N'Boeing 777', 396)
INSERT [dbo].[Airplane] ([IdAirplane], [TitleAirplane], [TotalSeats]) VALUES (4, N'Airbus A380', 853)
INSERT [dbo].[Airplane] ([IdAirplane], [TitleAirplane], [TotalSeats]) VALUES (5, N'Boeing 787', 242)
INSERT [dbo].[Airplane] ([IdAirplane], [TitleAirplane], [TotalSeats]) VALUES (6, N'Airbus A330', 440)
INSERT [dbo].[Airplane] ([IdAirplane], [TitleAirplane], [TotalSeats]) VALUES (7, N'Boeing 747', 660)
INSERT [dbo].[Airplane] ([IdAirplane], [TitleAirplane], [TotalSeats]) VALUES (8, N'Airbus A350', 325)
INSERT [dbo].[Airplane] ([IdAirplane], [TitleAirplane], [TotalSeats]) VALUES (9, N'Embraer E190', 106)
INSERT [dbo].[Airplane] ([IdAirplane], [TitleAirplane], [TotalSeats]) VALUES (10, N'Bombardier CRJ900', 90)
INSERT [dbo].[Airplane] ([IdAirplane], [TitleAirplane], [TotalSeats]) VALUES (11, N'Boeing 737', 189)
INSERT [dbo].[Airplane] ([IdAirplane], [TitleAirplane], [TotalSeats]) VALUES (12, N'Airbus A320', 180)
INSERT [dbo].[Airplane] ([IdAirplane], [TitleAirplane], [TotalSeats]) VALUES (13, N'Boeing 777', 396)
INSERT [dbo].[Airplane] ([IdAirplane], [TitleAirplane], [TotalSeats]) VALUES (14, N'Airbus A380', 853)
INSERT [dbo].[Airplane] ([IdAirplane], [TitleAirplane], [TotalSeats]) VALUES (15, N'Boeing 787', 242)
INSERT [dbo].[Airplane] ([IdAirplane], [TitleAirplane], [TotalSeats]) VALUES (16, N'Airbus A330', 440)
INSERT [dbo].[Airplane] ([IdAirplane], [TitleAirplane], [TotalSeats]) VALUES (17, N'Boeing 747', 660)
INSERT [dbo].[Airplane] ([IdAirplane], [TitleAirplane], [TotalSeats]) VALUES (18, N'Airbus A350', 325)
INSERT [dbo].[Airplane] ([IdAirplane], [TitleAirplane], [TotalSeats]) VALUES (19, N'Embraer E190', 106)
INSERT [dbo].[Airplane] ([IdAirplane], [TitleAirplane], [TotalSeats]) VALUES (20, N'Bombardier CRJ900', 90)
INSERT [dbo].[Airplane] ([IdAirplane], [TitleAirplane], [TotalSeats]) VALUES (21, N'Boeing 737', 189)
INSERT [dbo].[Airplane] ([IdAirplane], [TitleAirplane], [TotalSeats]) VALUES (22, N'Airbus A320', 180)
INSERT [dbo].[Airplane] ([IdAirplane], [TitleAirplane], [TotalSeats]) VALUES (23, N'Boeing 777', 396)
INSERT [dbo].[Airplane] ([IdAirplane], [TitleAirplane], [TotalSeats]) VALUES (24, N'Airbus A380', 853)
INSERT [dbo].[Airplane] ([IdAirplane], [TitleAirplane], [TotalSeats]) VALUES (25, N'Boeing 787', 242)
INSERT [dbo].[Airplane] ([IdAirplane], [TitleAirplane], [TotalSeats]) VALUES (26, N'Airbus A330', 440)
INSERT [dbo].[Airplane] ([IdAirplane], [TitleAirplane], [TotalSeats]) VALUES (27, N'Boeing 747', 660)
INSERT [dbo].[Airplane] ([IdAirplane], [TitleAirplane], [TotalSeats]) VALUES (28, N'Airbus A350', 325)
INSERT [dbo].[Airplane] ([IdAirplane], [TitleAirplane], [TotalSeats]) VALUES (29, N'Embraer E190', 106)
INSERT [dbo].[Airplane] ([IdAirplane], [TitleAirplane], [TotalSeats]) VALUES (30, N'Bombardier CRJ900', 90)
SET IDENTITY_INSERT [dbo].[Airplane] OFF
GO
SET IDENTITY_INSERT [dbo].[Airports] ON 

INSERT [dbo].[Airports] ([IdAirport], [TitleAirport], [CodeIKAO], [CodeIATA], [City]) VALUES (1, N'Sheremetyevo International Airport', N'UUDD', N'SVO', N'Moscow')
INSERT [dbo].[Airports] ([IdAirport], [TitleAirport], [CodeIKAO], [CodeIATA], [City]) VALUES (2, N'Ataturk International Airport', N'LTBA', N'IST', N'Istanbul')
INSERT [dbo].[Airports] ([IdAirport], [TitleAirport], [CodeIKAO], [CodeIATA], [City]) VALUES (3, N'Dubai International Airport', N'OMDB', N'DXB', N'Dubai')
INSERT [dbo].[Airports] ([IdAirport], [TitleAirport], [CodeIKAO], [CodeIATA], [City]) VALUES (4, N'Frankfurt Airport', N'EDDF', N'FRA', N'Frankfurt')
INSERT [dbo].[Airports] ([IdAirport], [TitleAirport], [CodeIKAO], [CodeIATA], [City]) VALUES (5, N'Heathrow Airport', N'EGLL', N'LHR', N'London')
INSERT [dbo].[Airports] ([IdAirport], [TitleAirport], [CodeIKAO], [CodeIATA], [City]) VALUES (6, N'Charles de Gaulle Airport', N'LFPG', N'CDG', N'Paris')
INSERT [dbo].[Airports] ([IdAirport], [TitleAirport], [CodeIKAO], [CodeIATA], [City]) VALUES (7, N'Hamad International Airport', N'OTHH', N'DOH', N'Doha')
INSERT [dbo].[Airports] ([IdAirport], [TitleAirport], [CodeIKAO], [CodeIATA], [City]) VALUES (8, N'Changi Airport', N'WSSS', N'SIN', N'Singapore')
INSERT [dbo].[Airports] ([IdAirport], [TitleAirport], [CodeIKAO], [CodeIATA], [City]) VALUES (9, N'Hartsfield-Jackson Atlanta International Airport', N'KATL', N'ATL', N'Atlanta')
INSERT [dbo].[Airports] ([IdAirport], [TitleAirport], [CodeIKAO], [CodeIATA], [City]) VALUES (10, N'Los Angeles International Airport', N'KLAX', N'LAX', N'Los Angeles')
INSERT [dbo].[Airports] ([IdAirport], [TitleAirport], [CodeIKAO], [CodeIATA], [City]) VALUES (11, N'Sheremetyevo International Airport', N'UUDD', N'SVO', N'Moscow')
INSERT [dbo].[Airports] ([IdAirport], [TitleAirport], [CodeIKAO], [CodeIATA], [City]) VALUES (12, N'Ataturk International Airport', N'LTBA', N'IST', N'Istanbul')
INSERT [dbo].[Airports] ([IdAirport], [TitleAirport], [CodeIKAO], [CodeIATA], [City]) VALUES (13, N'Dubai International Airport', N'OMDB', N'DXB', N'Dubai')
INSERT [dbo].[Airports] ([IdAirport], [TitleAirport], [CodeIKAO], [CodeIATA], [City]) VALUES (14, N'Frankfurt Airport', N'EDDF', N'FRA', N'Frankfurt')
INSERT [dbo].[Airports] ([IdAirport], [TitleAirport], [CodeIKAO], [CodeIATA], [City]) VALUES (15, N'Heathrow Airport', N'EGLL', N'LHR', N'London')
INSERT [dbo].[Airports] ([IdAirport], [TitleAirport], [CodeIKAO], [CodeIATA], [City]) VALUES (16, N'Charles de Gaulle Airport', N'LFPG', N'CDG', N'Paris')
INSERT [dbo].[Airports] ([IdAirport], [TitleAirport], [CodeIKAO], [CodeIATA], [City]) VALUES (17, N'Hamad International Airport', N'OTHH', N'DOH', N'Doha')
INSERT [dbo].[Airports] ([IdAirport], [TitleAirport], [CodeIKAO], [CodeIATA], [City]) VALUES (18, N'Changi Airport', N'WSSS', N'SIN', N'Singapore')
INSERT [dbo].[Airports] ([IdAirport], [TitleAirport], [CodeIKAO], [CodeIATA], [City]) VALUES (19, N'Hartsfield-Jackson Atlanta International Airport', N'KATL', N'ATL', N'Atlanta')
INSERT [dbo].[Airports] ([IdAirport], [TitleAirport], [CodeIKAO], [CodeIATA], [City]) VALUES (20, N'Los Angeles International Airport', N'KLAX', N'LAX', N'Los Angeles')
INSERT [dbo].[Airports] ([IdAirport], [TitleAirport], [CodeIKAO], [CodeIATA], [City]) VALUES (21, N'Sheremetyevo International Airport', N'UUDD', N'SVO', N'Moscow')
INSERT [dbo].[Airports] ([IdAirport], [TitleAirport], [CodeIKAO], [CodeIATA], [City]) VALUES (22, N'Ataturk International Airport', N'LTBA', N'IST', N'Istanbul')
INSERT [dbo].[Airports] ([IdAirport], [TitleAirport], [CodeIKAO], [CodeIATA], [City]) VALUES (23, N'Dubai International Airport', N'OMDB', N'DXB', N'Dubai')
INSERT [dbo].[Airports] ([IdAirport], [TitleAirport], [CodeIKAO], [CodeIATA], [City]) VALUES (24, N'Frankfurt Airport', N'EDDF', N'FRA', N'Frankfurt')
INSERT [dbo].[Airports] ([IdAirport], [TitleAirport], [CodeIKAO], [CodeIATA], [City]) VALUES (25, N'Heathrow Airport', N'EGLL', N'LHR', N'London')
INSERT [dbo].[Airports] ([IdAirport], [TitleAirport], [CodeIKAO], [CodeIATA], [City]) VALUES (26, N'Charles de Gaulle Airport', N'LFPG', N'CDG', N'Paris')
INSERT [dbo].[Airports] ([IdAirport], [TitleAirport], [CodeIKAO], [CodeIATA], [City]) VALUES (27, N'Hamad International Airport', N'OTHH', N'DOH', N'Doha')
INSERT [dbo].[Airports] ([IdAirport], [TitleAirport], [CodeIKAO], [CodeIATA], [City]) VALUES (28, N'Changi Airport', N'WSSS', N'SIN', N'Singapore')
INSERT [dbo].[Airports] ([IdAirport], [TitleAirport], [CodeIKAO], [CodeIATA], [City]) VALUES (29, N'Hartsfield-Jackson Atlanta International Airport', N'KATL', N'ATL', N'Atlanta')
INSERT [dbo].[Airports] ([IdAirport], [TitleAirport], [CodeIKAO], [CodeIATA], [City]) VALUES (30, N'Los Angeles International Airport', N'KLAX', N'LAX', N'Los Angeles')
SET IDENTITY_INSERT [dbo].[Airports] OFF
GO
SET IDENTITY_INSERT [dbo].[Bagage] ON 

INSERT [dbo].[Bagage] ([IdBagage], [CountBagage], [WeightBagage]) VALUES (1, 1, 20)
INSERT [dbo].[Bagage] ([IdBagage], [CountBagage], [WeightBagage]) VALUES (2, 2, 35)
INSERT [dbo].[Bagage] ([IdBagage], [CountBagage], [WeightBagage]) VALUES (3, 1, 15)
INSERT [dbo].[Bagage] ([IdBagage], [CountBagage], [WeightBagage]) VALUES (4, 3, 50)
INSERT [dbo].[Bagage] ([IdBagage], [CountBagage], [WeightBagage]) VALUES (5, 2, 40)
INSERT [dbo].[Bagage] ([IdBagage], [CountBagage], [WeightBagage]) VALUES (6, 1, 25)
INSERT [dbo].[Bagage] ([IdBagage], [CountBagage], [WeightBagage]) VALUES (7, 2, 30)
INSERT [dbo].[Bagage] ([IdBagage], [CountBagage], [WeightBagage]) VALUES (8, 1, 18)
INSERT [dbo].[Bagage] ([IdBagage], [CountBagage], [WeightBagage]) VALUES (9, 3, 45)
INSERT [dbo].[Bagage] ([IdBagage], [CountBagage], [WeightBagage]) VALUES (10, 2, 22)
INSERT [dbo].[Bagage] ([IdBagage], [CountBagage], [WeightBagage]) VALUES (11, 1, 20)
INSERT [dbo].[Bagage] ([IdBagage], [CountBagage], [WeightBagage]) VALUES (12, 2, 35)
INSERT [dbo].[Bagage] ([IdBagage], [CountBagage], [WeightBagage]) VALUES (13, 1, 15)
INSERT [dbo].[Bagage] ([IdBagage], [CountBagage], [WeightBagage]) VALUES (14, 3, 50)
INSERT [dbo].[Bagage] ([IdBagage], [CountBagage], [WeightBagage]) VALUES (15, 2, 40)
INSERT [dbo].[Bagage] ([IdBagage], [CountBagage], [WeightBagage]) VALUES (16, 1, 25)
INSERT [dbo].[Bagage] ([IdBagage], [CountBagage], [WeightBagage]) VALUES (17, 2, 30)
INSERT [dbo].[Bagage] ([IdBagage], [CountBagage], [WeightBagage]) VALUES (18, 1, 18)
INSERT [dbo].[Bagage] ([IdBagage], [CountBagage], [WeightBagage]) VALUES (19, 3, 45)
INSERT [dbo].[Bagage] ([IdBagage], [CountBagage], [WeightBagage]) VALUES (20, 2, 22)
INSERT [dbo].[Bagage] ([IdBagage], [CountBagage], [WeightBagage]) VALUES (21, 1, 20)
INSERT [dbo].[Bagage] ([IdBagage], [CountBagage], [WeightBagage]) VALUES (22, 2, 35)
INSERT [dbo].[Bagage] ([IdBagage], [CountBagage], [WeightBagage]) VALUES (23, 1, 15)
INSERT [dbo].[Bagage] ([IdBagage], [CountBagage], [WeightBagage]) VALUES (24, 3, 50)
INSERT [dbo].[Bagage] ([IdBagage], [CountBagage], [WeightBagage]) VALUES (25, 2, 40)
INSERT [dbo].[Bagage] ([IdBagage], [CountBagage], [WeightBagage]) VALUES (26, 1, 25)
INSERT [dbo].[Bagage] ([IdBagage], [CountBagage], [WeightBagage]) VALUES (27, 2, 30)
INSERT [dbo].[Bagage] ([IdBagage], [CountBagage], [WeightBagage]) VALUES (28, 1, 18)
INSERT [dbo].[Bagage] ([IdBagage], [CountBagage], [WeightBagage]) VALUES (29, 3, 45)
INSERT [dbo].[Bagage] ([IdBagage], [CountBagage], [WeightBagage]) VALUES (30, 2, 22)
SET IDENTITY_INSERT [dbo].[Bagage] OFF
GO
SET IDENTITY_INSERT [dbo].[Bookings] ON 

INSERT [dbo].[Bookings] ([IdBooking], [BookingCode], [BookingDate], [TotalPrice], [IdBookingStatus]) VALUES (1, N'BK00000001', CAST(N'2025-02-20' AS Date), 500.0000, 1)
INSERT [dbo].[Bookings] ([IdBooking], [BookingCode], [BookingDate], [TotalPrice], [IdBookingStatus]) VALUES (2, N'BK00000002', CAST(N'2025-02-21' AS Date), 600.0000, 2)
INSERT [dbo].[Bookings] ([IdBooking], [BookingCode], [BookingDate], [TotalPrice], [IdBookingStatus]) VALUES (3, N'BK00000003', CAST(N'2025-02-22' AS Date), 700.0000, 3)
INSERT [dbo].[Bookings] ([IdBooking], [BookingCode], [BookingDate], [TotalPrice], [IdBookingStatus]) VALUES (4, N'BK00000004', CAST(N'2025-02-23' AS Date), 800.0000, 4)
INSERT [dbo].[Bookings] ([IdBooking], [BookingCode], [BookingDate], [TotalPrice], [IdBookingStatus]) VALUES (5, N'BK00000005', CAST(N'2025-02-24' AS Date), 900.0000, 5)
INSERT [dbo].[Bookings] ([IdBooking], [BookingCode], [BookingDate], [TotalPrice], [IdBookingStatus]) VALUES (6, N'BK00000006', CAST(N'2025-02-25' AS Date), 1000.0000, 6)
INSERT [dbo].[Bookings] ([IdBooking], [BookingCode], [BookingDate], [TotalPrice], [IdBookingStatus]) VALUES (7, N'BK00000007', CAST(N'2025-02-26' AS Date), 1100.0000, 7)
INSERT [dbo].[Bookings] ([IdBooking], [BookingCode], [BookingDate], [TotalPrice], [IdBookingStatus]) VALUES (8, N'BK00000008', CAST(N'2025-02-27' AS Date), 1200.0000, 8)
INSERT [dbo].[Bookings] ([IdBooking], [BookingCode], [BookingDate], [TotalPrice], [IdBookingStatus]) VALUES (9, N'BK00000009', CAST(N'2025-02-28' AS Date), 1300.0000, 9)
INSERT [dbo].[Bookings] ([IdBooking], [BookingCode], [BookingDate], [TotalPrice], [IdBookingStatus]) VALUES (10, N'BK00000010', CAST(N'2025-03-01' AS Date), 1400.0000, 10)
SET IDENTITY_INSERT [dbo].[Bookings] OFF
GO
SET IDENTITY_INSERT [dbo].[BookingsStatus] ON 

INSERT [dbo].[BookingsStatus] ([IdBookingStatus], [TitleStatus]) VALUES (1, N'Confirmed')
INSERT [dbo].[BookingsStatus] ([IdBookingStatus], [TitleStatus]) VALUES (2, N'Pending')
INSERT [dbo].[BookingsStatus] ([IdBookingStatus], [TitleStatus]) VALUES (3, N'Cancelled')
INSERT [dbo].[BookingsStatus] ([IdBookingStatus], [TitleStatus]) VALUES (4, N'Checked-In')
INSERT [dbo].[BookingsStatus] ([IdBookingStatus], [TitleStatus]) VALUES (5, N'Boarded')
INSERT [dbo].[BookingsStatus] ([IdBookingStatus], [TitleStatus]) VALUES (6, N'Delayed')
INSERT [dbo].[BookingsStatus] ([IdBookingStatus], [TitleStatus]) VALUES (7, N'On-Time')
INSERT [dbo].[BookingsStatus] ([IdBookingStatus], [TitleStatus]) VALUES (8, N'Arrived')
INSERT [dbo].[BookingsStatus] ([IdBookingStatus], [TitleStatus]) VALUES (9, N'No-Show')
INSERT [dbo].[BookingsStatus] ([IdBookingStatus], [TitleStatus]) VALUES (10, N'Refunded')
INSERT [dbo].[BookingsStatus] ([IdBookingStatus], [TitleStatus]) VALUES (11, N'Confirmed')
INSERT [dbo].[BookingsStatus] ([IdBookingStatus], [TitleStatus]) VALUES (12, N'Pending')
INSERT [dbo].[BookingsStatus] ([IdBookingStatus], [TitleStatus]) VALUES (13, N'Cancelled')
INSERT [dbo].[BookingsStatus] ([IdBookingStatus], [TitleStatus]) VALUES (14, N'Checked-In')
INSERT [dbo].[BookingsStatus] ([IdBookingStatus], [TitleStatus]) VALUES (15, N'Boarded')
INSERT [dbo].[BookingsStatus] ([IdBookingStatus], [TitleStatus]) VALUES (16, N'Delayed')
INSERT [dbo].[BookingsStatus] ([IdBookingStatus], [TitleStatus]) VALUES (17, N'On-Time')
INSERT [dbo].[BookingsStatus] ([IdBookingStatus], [TitleStatus]) VALUES (18, N'Arrived')
INSERT [dbo].[BookingsStatus] ([IdBookingStatus], [TitleStatus]) VALUES (19, N'No-Show')
INSERT [dbo].[BookingsStatus] ([IdBookingStatus], [TitleStatus]) VALUES (20, N'Refunded')
INSERT [dbo].[BookingsStatus] ([IdBookingStatus], [TitleStatus]) VALUES (21, N'Confirmed')
INSERT [dbo].[BookingsStatus] ([IdBookingStatus], [TitleStatus]) VALUES (22, N'Pending')
INSERT [dbo].[BookingsStatus] ([IdBookingStatus], [TitleStatus]) VALUES (23, N'Cancelled')
INSERT [dbo].[BookingsStatus] ([IdBookingStatus], [TitleStatus]) VALUES (24, N'Checked-In')
INSERT [dbo].[BookingsStatus] ([IdBookingStatus], [TitleStatus]) VALUES (25, N'Boarded')
INSERT [dbo].[BookingsStatus] ([IdBookingStatus], [TitleStatus]) VALUES (26, N'Delayed')
INSERT [dbo].[BookingsStatus] ([IdBookingStatus], [TitleStatus]) VALUES (27, N'On-Time')
INSERT [dbo].[BookingsStatus] ([IdBookingStatus], [TitleStatus]) VALUES (28, N'Arrived')
INSERT [dbo].[BookingsStatus] ([IdBookingStatus], [TitleStatus]) VALUES (29, N'No-Show')
INSERT [dbo].[BookingsStatus] ([IdBookingStatus], [TitleStatus]) VALUES (30, N'Refunded')
SET IDENTITY_INSERT [dbo].[BookingsStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[BookingTickets] ON 

INSERT [dbo].[BookingTickets] ([IdBookingTicket], [IdBooking], [IdTicketSelling]) VALUES (3, 1, 1)
INSERT [dbo].[BookingTickets] ([IdBookingTicket], [IdBooking], [IdTicketSelling]) VALUES (4, 2, 2)
INSERT [dbo].[BookingTickets] ([IdBookingTicket], [IdBooking], [IdTicketSelling]) VALUES (5, 3, 3)
INSERT [dbo].[BookingTickets] ([IdBookingTicket], [IdBooking], [IdTicketSelling]) VALUES (6, 4, 4)
INSERT [dbo].[BookingTickets] ([IdBookingTicket], [IdBooking], [IdTicketSelling]) VALUES (7, 5, 5)
INSERT [dbo].[BookingTickets] ([IdBookingTicket], [IdBooking], [IdTicketSelling]) VALUES (8, 6, 6)
INSERT [dbo].[BookingTickets] ([IdBookingTicket], [IdBooking], [IdTicketSelling]) VALUES (9, 7, 7)
INSERT [dbo].[BookingTickets] ([IdBookingTicket], [IdBooking], [IdTicketSelling]) VALUES (10, 8, 8)
INSERT [dbo].[BookingTickets] ([IdBookingTicket], [IdBooking], [IdTicketSelling]) VALUES (11, 9, 9)
INSERT [dbo].[BookingTickets] ([IdBookingTicket], [IdBooking], [IdTicketSelling]) VALUES (12, 10, 10)
SET IDENTITY_INSERT [dbo].[BookingTickets] OFF
GO
SET IDENTITY_INSERT [dbo].[Flights] ON 

INSERT [dbo].[Flights] ([IdFlight], [FlightNumber], [IdAirlane], [AirportDeparturesId], [ArrivalAirportId], [DepartureDate], [DepartureTime], [TotalSeatsFree], [IdStatus], [IdAirplane], [IdGate], [ArrivalDate], [ArrivalTime]) VALUES (1, N'SU100', 2, 1, 5, CAST(N'2025-03-01' AS Date), CAST(N'08:00:00' AS Time), 150, 4, 4, 10, CAST(N'2025-03-01' AS Date), CAST(N'20:25:00' AS Time))
INSERT [dbo].[Flights] ([IdFlight], [FlightNumber], [IdAirlane], [AirportDeparturesId], [ArrivalAirportId], [DepartureDate], [DepartureTime], [TotalSeatsFree], [IdStatus], [IdAirplane], [IdGate], [ArrivalDate], [ArrivalTime]) VALUES (2, N'TK200', 2, 2, 4, CAST(N'2025-03-02' AS Date), CAST(N'09:30:00' AS Time), 200, 2, 2, 2, CAST(N'2025-03-02' AS Date), CAST(N'11:30:00' AS Time))
INSERT [dbo].[Flights] ([IdFlight], [FlightNumber], [IdAirlane], [AirportDeparturesId], [ArrivalAirportId], [DepartureDate], [DepartureTime], [TotalSeatsFree], [IdStatus], [IdAirplane], [IdGate], [ArrivalDate], [ArrivalTime]) VALUES (3, N'EK300', 3, 3, 5, CAST(N'2025-03-03' AS Date), CAST(N'11:00:00' AS Time), 300, 3, 3, 3, CAST(N'2025-03-03' AS Date), CAST(N'17:00:00' AS Time))
INSERT [dbo].[Flights] ([IdFlight], [FlightNumber], [IdAirlane], [AirportDeparturesId], [ArrivalAirportId], [DepartureDate], [DepartureTime], [TotalSeatsFree], [IdStatus], [IdAirplane], [IdGate], [ArrivalDate], [ArrivalTime]) VALUES (4, N'LH400', 4, 4, 6, CAST(N'2025-03-04' AS Date), CAST(N'12:30:00' AS Time), 250, 4, 4, 4, CAST(N'2025-03-04' AS Date), CAST(N'14:30:00' AS Time))
INSERT [dbo].[Flights] ([IdFlight], [FlightNumber], [IdAirlane], [AirportDeparturesId], [ArrivalAirportId], [DepartureDate], [DepartureTime], [TotalSeatsFree], [IdStatus], [IdAirplane], [IdGate], [ArrivalDate], [ArrivalTime]) VALUES (5, N'BA500', 5, 5, 7, CAST(N'2025-03-05' AS Date), CAST(N'14:00:00' AS Time), 180, 5, 5, 5, CAST(N'2025-03-05' AS Date), CAST(N'20:00:00' AS Time))
INSERT [dbo].[Flights] ([IdFlight], [FlightNumber], [IdAirlane], [AirportDeparturesId], [ArrivalAirportId], [DepartureDate], [DepartureTime], [TotalSeatsFree], [IdStatus], [IdAirplane], [IdGate], [ArrivalDate], [ArrivalTime]) VALUES (6, N'AF600', 6, 6, 8, CAST(N'2025-03-06' AS Date), CAST(N'15:30:00' AS Time), 220, 6, 6, 6, CAST(N'2025-03-06' AS Date), CAST(N'21:30:00' AS Time))
INSERT [dbo].[Flights] ([IdFlight], [FlightNumber], [IdAirlane], [AirportDeparturesId], [ArrivalAirportId], [DepartureDate], [DepartureTime], [TotalSeatsFree], [IdStatus], [IdAirplane], [IdGate], [ArrivalDate], [ArrivalTime]) VALUES (7, N'QR700', 7, 7, 9, CAST(N'2025-03-07' AS Date), CAST(N'17:00:00' AS Time), 350, 7, 7, 7, CAST(N'2025-03-07' AS Date), CAST(N'23:00:00' AS Time))
INSERT [dbo].[Flights] ([IdFlight], [FlightNumber], [IdAirlane], [AirportDeparturesId], [ArrivalAirportId], [DepartureDate], [DepartureTime], [TotalSeatsFree], [IdStatus], [IdAirplane], [IdGate], [ArrivalDate], [ArrivalTime]) VALUES (8, N'SQ800', 8, 8, 10, CAST(N'2025-03-08' AS Date), CAST(N'18:30:00' AS Time), 400, 8, 8, 8, CAST(N'2025-03-08' AS Date), CAST(N'00:30:00' AS Time))
INSERT [dbo].[Flights] ([IdFlight], [FlightNumber], [IdAirlane], [AirportDeparturesId], [ArrivalAirportId], [DepartureDate], [DepartureTime], [TotalSeatsFree], [IdStatus], [IdAirplane], [IdGate], [ArrivalDate], [ArrivalTime]) VALUES (9, N'DL900', 9, 9, 1, CAST(N'2025-03-09' AS Date), CAST(N'20:00:00' AS Time), 160, 9, 9, 9, CAST(N'2025-03-09' AS Date), CAST(N'02:00:00' AS Time))
INSERT [dbo].[Flights] ([IdFlight], [FlightNumber], [IdAirlane], [AirportDeparturesId], [ArrivalAirportId], [DepartureDate], [DepartureTime], [TotalSeatsFree], [IdStatus], [IdAirplane], [IdGate], [ArrivalDate], [ArrivalTime]) VALUES (10, N'AA1000', 10, 10, 2, CAST(N'2025-03-10' AS Date), CAST(N'21:30:00' AS Time), 190, 4, 10, 6, CAST(N'2025-03-10' AS Date), CAST(N'03:30:00' AS Time))
SET IDENTITY_INSERT [dbo].[Flights] OFF
GO
SET IDENTITY_INSERT [dbo].[FormOfPayments] ON 

INSERT [dbo].[FormOfPayments] ([FormOfPaymentId], [TitleForm]) VALUES (1, N'Credit Card')
INSERT [dbo].[FormOfPayments] ([FormOfPaymentId], [TitleForm]) VALUES (2, N'Debit Card')
INSERT [dbo].[FormOfPayments] ([FormOfPaymentId], [TitleForm]) VALUES (3, N'PayPal')
INSERT [dbo].[FormOfPayments] ([FormOfPaymentId], [TitleForm]) VALUES (4, N'Cash')
INSERT [dbo].[FormOfPayments] ([FormOfPaymentId], [TitleForm]) VALUES (5, N'Bank Transfer')
INSERT [dbo].[FormOfPayments] ([FormOfPaymentId], [TitleForm]) VALUES (6, N'Apple Pay')
INSERT [dbo].[FormOfPayments] ([FormOfPaymentId], [TitleForm]) VALUES (7, N'Google Pay')
INSERT [dbo].[FormOfPayments] ([FormOfPaymentId], [TitleForm]) VALUES (8, N'Bitcoin')
INSERT [dbo].[FormOfPayments] ([FormOfPaymentId], [TitleForm]) VALUES (9, N'Gift Card')
INSERT [dbo].[FormOfPayments] ([FormOfPaymentId], [TitleForm]) VALUES (10, N'Installment Plan')
INSERT [dbo].[FormOfPayments] ([FormOfPaymentId], [TitleForm]) VALUES (11, N'Credit Card')
INSERT [dbo].[FormOfPayments] ([FormOfPaymentId], [TitleForm]) VALUES (12, N'Debit Card')
INSERT [dbo].[FormOfPayments] ([FormOfPaymentId], [TitleForm]) VALUES (13, N'PayPal')
INSERT [dbo].[FormOfPayments] ([FormOfPaymentId], [TitleForm]) VALUES (14, N'Cash')
INSERT [dbo].[FormOfPayments] ([FormOfPaymentId], [TitleForm]) VALUES (15, N'Bank Transfer')
INSERT [dbo].[FormOfPayments] ([FormOfPaymentId], [TitleForm]) VALUES (16, N'Apple Pay')
INSERT [dbo].[FormOfPayments] ([FormOfPaymentId], [TitleForm]) VALUES (17, N'Google Pay')
INSERT [dbo].[FormOfPayments] ([FormOfPaymentId], [TitleForm]) VALUES (18, N'Bitcoin')
INSERT [dbo].[FormOfPayments] ([FormOfPaymentId], [TitleForm]) VALUES (19, N'Gift Card')
INSERT [dbo].[FormOfPayments] ([FormOfPaymentId], [TitleForm]) VALUES (20, N'Installment Plan')
INSERT [dbo].[FormOfPayments] ([FormOfPaymentId], [TitleForm]) VALUES (21, N'Credit Card')
INSERT [dbo].[FormOfPayments] ([FormOfPaymentId], [TitleForm]) VALUES (22, N'Debit Card')
INSERT [dbo].[FormOfPayments] ([FormOfPaymentId], [TitleForm]) VALUES (23, N'PayPal')
INSERT [dbo].[FormOfPayments] ([FormOfPaymentId], [TitleForm]) VALUES (24, N'Cash')
INSERT [dbo].[FormOfPayments] ([FormOfPaymentId], [TitleForm]) VALUES (25, N'Bank Transfer')
INSERT [dbo].[FormOfPayments] ([FormOfPaymentId], [TitleForm]) VALUES (26, N'Apple Pay')
INSERT [dbo].[FormOfPayments] ([FormOfPaymentId], [TitleForm]) VALUES (27, N'Google Pay')
INSERT [dbo].[FormOfPayments] ([FormOfPaymentId], [TitleForm]) VALUES (28, N'Bitcoin')
INSERT [dbo].[FormOfPayments] ([FormOfPaymentId], [TitleForm]) VALUES (29, N'Gift Card')
INSERT [dbo].[FormOfPayments] ([FormOfPaymentId], [TitleForm]) VALUES (30, N'Installment Plan')
SET IDENTITY_INSERT [dbo].[FormOfPayments] OFF
GO
SET IDENTITY_INSERT [dbo].[Gates] ON 

INSERT [dbo].[Gates] ([IdGate], [IdStatusGate], [GateNumber]) VALUES (1, 1, N'A1')
INSERT [dbo].[Gates] ([IdGate], [IdStatusGate], [GateNumber]) VALUES (2, 2, N'A2')
INSERT [dbo].[Gates] ([IdGate], [IdStatusGate], [GateNumber]) VALUES (3, 3, N'B1')
INSERT [dbo].[Gates] ([IdGate], [IdStatusGate], [GateNumber]) VALUES (4, 4, N'B2')
INSERT [dbo].[Gates] ([IdGate], [IdStatusGate], [GateNumber]) VALUES (5, 5, N'C1')
INSERT [dbo].[Gates] ([IdGate], [IdStatusGate], [GateNumber]) VALUES (6, 6, N'C2')
INSERT [dbo].[Gates] ([IdGate], [IdStatusGate], [GateNumber]) VALUES (7, 7, N'D1')
INSERT [dbo].[Gates] ([IdGate], [IdStatusGate], [GateNumber]) VALUES (8, 8, N'D2')
INSERT [dbo].[Gates] ([IdGate], [IdStatusGate], [GateNumber]) VALUES (9, 9, N'E1')
INSERT [dbo].[Gates] ([IdGate], [IdStatusGate], [GateNumber]) VALUES (10, 10, N'E2')
INSERT [dbo].[Gates] ([IdGate], [IdStatusGate], [GateNumber]) VALUES (11, 1, N'A1')
INSERT [dbo].[Gates] ([IdGate], [IdStatusGate], [GateNumber]) VALUES (12, 2, N'A2')
INSERT [dbo].[Gates] ([IdGate], [IdStatusGate], [GateNumber]) VALUES (13, 3, N'B1')
INSERT [dbo].[Gates] ([IdGate], [IdStatusGate], [GateNumber]) VALUES (14, 4, N'B2')
INSERT [dbo].[Gates] ([IdGate], [IdStatusGate], [GateNumber]) VALUES (15, 5, N'C1')
INSERT [dbo].[Gates] ([IdGate], [IdStatusGate], [GateNumber]) VALUES (16, 6, N'C2')
INSERT [dbo].[Gates] ([IdGate], [IdStatusGate], [GateNumber]) VALUES (17, 7, N'D1')
INSERT [dbo].[Gates] ([IdGate], [IdStatusGate], [GateNumber]) VALUES (18, 8, N'D2')
INSERT [dbo].[Gates] ([IdGate], [IdStatusGate], [GateNumber]) VALUES (19, 9, N'E1')
INSERT [dbo].[Gates] ([IdGate], [IdStatusGate], [GateNumber]) VALUES (20, 10, N'E2')
INSERT [dbo].[Gates] ([IdGate], [IdStatusGate], [GateNumber]) VALUES (21, 1, N'A1')
INSERT [dbo].[Gates] ([IdGate], [IdStatusGate], [GateNumber]) VALUES (22, 2, N'A2')
INSERT [dbo].[Gates] ([IdGate], [IdStatusGate], [GateNumber]) VALUES (23, 3, N'B1')
INSERT [dbo].[Gates] ([IdGate], [IdStatusGate], [GateNumber]) VALUES (24, 4, N'B2')
INSERT [dbo].[Gates] ([IdGate], [IdStatusGate], [GateNumber]) VALUES (25, 5, N'C1')
INSERT [dbo].[Gates] ([IdGate], [IdStatusGate], [GateNumber]) VALUES (26, 6, N'C2')
INSERT [dbo].[Gates] ([IdGate], [IdStatusGate], [GateNumber]) VALUES (27, 7, N'D1')
INSERT [dbo].[Gates] ([IdGate], [IdStatusGate], [GateNumber]) VALUES (28, 8, N'D2')
INSERT [dbo].[Gates] ([IdGate], [IdStatusGate], [GateNumber]) VALUES (29, 9, N'E1')
INSERT [dbo].[Gates] ([IdGate], [IdStatusGate], [GateNumber]) VALUES (30, 10, N'E2')
SET IDENTITY_INSERT [dbo].[Gates] OFF
GO
SET IDENTITY_INSERT [dbo].[Registration] ON 

INSERT [dbo].[Registration] ([IdRegistration], [IdBagage], [IdStatusRegistration], [IdTicketSelling]) VALUES (1, 1, 1, 1)
INSERT [dbo].[Registration] ([IdRegistration], [IdBagage], [IdStatusRegistration], [IdTicketSelling]) VALUES (2, 2, 2, 2)
INSERT [dbo].[Registration] ([IdRegistration], [IdBagage], [IdStatusRegistration], [IdTicketSelling]) VALUES (3, 3, 3, 3)
INSERT [dbo].[Registration] ([IdRegistration], [IdBagage], [IdStatusRegistration], [IdTicketSelling]) VALUES (4, 4, 4, 4)
INSERT [dbo].[Registration] ([IdRegistration], [IdBagage], [IdStatusRegistration], [IdTicketSelling]) VALUES (5, 5, 5, 5)
INSERT [dbo].[Registration] ([IdRegistration], [IdBagage], [IdStatusRegistration], [IdTicketSelling]) VALUES (6, 6, 6, 6)
INSERT [dbo].[Registration] ([IdRegistration], [IdBagage], [IdStatusRegistration], [IdTicketSelling]) VALUES (7, 7, 7, 7)
INSERT [dbo].[Registration] ([IdRegistration], [IdBagage], [IdStatusRegistration], [IdTicketSelling]) VALUES (8, 8, 8, 8)
INSERT [dbo].[Registration] ([IdRegistration], [IdBagage], [IdStatusRegistration], [IdTicketSelling]) VALUES (9, 9, 9, 9)
INSERT [dbo].[Registration] ([IdRegistration], [IdBagage], [IdStatusRegistration], [IdTicketSelling]) VALUES (10, 10, 10, 10)
INSERT [dbo].[Registration] ([IdRegistration], [IdBagage], [IdStatusRegistration], [IdTicketSelling]) VALUES (11, 1, 1, 1)
INSERT [dbo].[Registration] ([IdRegistration], [IdBagage], [IdStatusRegistration], [IdTicketSelling]) VALUES (12, 2, 2, 2)
INSERT [dbo].[Registration] ([IdRegistration], [IdBagage], [IdStatusRegistration], [IdTicketSelling]) VALUES (13, 3, 3, 3)
INSERT [dbo].[Registration] ([IdRegistration], [IdBagage], [IdStatusRegistration], [IdTicketSelling]) VALUES (14, 4, 4, 4)
INSERT [dbo].[Registration] ([IdRegistration], [IdBagage], [IdStatusRegistration], [IdTicketSelling]) VALUES (15, 5, 5, 5)
INSERT [dbo].[Registration] ([IdRegistration], [IdBagage], [IdStatusRegistration], [IdTicketSelling]) VALUES (16, 6, 6, 6)
INSERT [dbo].[Registration] ([IdRegistration], [IdBagage], [IdStatusRegistration], [IdTicketSelling]) VALUES (17, 7, 7, 7)
INSERT [dbo].[Registration] ([IdRegistration], [IdBagage], [IdStatusRegistration], [IdTicketSelling]) VALUES (18, 8, 8, 8)
INSERT [dbo].[Registration] ([IdRegistration], [IdBagage], [IdStatusRegistration], [IdTicketSelling]) VALUES (19, 9, 9, 9)
INSERT [dbo].[Registration] ([IdRegistration], [IdBagage], [IdStatusRegistration], [IdTicketSelling]) VALUES (20, 10, 10, 10)
INSERT [dbo].[Registration] ([IdRegistration], [IdBagage], [IdStatusRegistration], [IdTicketSelling]) VALUES (21, 1, 1, 1)
INSERT [dbo].[Registration] ([IdRegistration], [IdBagage], [IdStatusRegistration], [IdTicketSelling]) VALUES (22, 2, 2, 2)
INSERT [dbo].[Registration] ([IdRegistration], [IdBagage], [IdStatusRegistration], [IdTicketSelling]) VALUES (23, 3, 3, 3)
INSERT [dbo].[Registration] ([IdRegistration], [IdBagage], [IdStatusRegistration], [IdTicketSelling]) VALUES (24, 4, 4, 4)
INSERT [dbo].[Registration] ([IdRegistration], [IdBagage], [IdStatusRegistration], [IdTicketSelling]) VALUES (25, 5, 5, 5)
INSERT [dbo].[Registration] ([IdRegistration], [IdBagage], [IdStatusRegistration], [IdTicketSelling]) VALUES (26, 6, 6, 6)
INSERT [dbo].[Registration] ([IdRegistration], [IdBagage], [IdStatusRegistration], [IdTicketSelling]) VALUES (27, 7, 7, 7)
INSERT [dbo].[Registration] ([IdRegistration], [IdBagage], [IdStatusRegistration], [IdTicketSelling]) VALUES (28, 8, 8, 8)
INSERT [dbo].[Registration] ([IdRegistration], [IdBagage], [IdStatusRegistration], [IdTicketSelling]) VALUES (29, 9, 9, 9)
INSERT [dbo].[Registration] ([IdRegistration], [IdBagage], [IdStatusRegistration], [IdTicketSelling]) VALUES (30, 10, 10, 10)
SET IDENTITY_INSERT [dbo].[Registration] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([IdStatus], [TitleStatus]) VALUES (1, N'Scheduled')
INSERT [dbo].[Status] ([IdStatus], [TitleStatus]) VALUES (2, N'Delayed')
INSERT [dbo].[Status] ([IdStatus], [TitleStatus]) VALUES (3, N'Cancelled')
INSERT [dbo].[Status] ([IdStatus], [TitleStatus]) VALUES (4, N'Departed')
INSERT [dbo].[Status] ([IdStatus], [TitleStatus]) VALUES (5, N'Arrived')
INSERT [dbo].[Status] ([IdStatus], [TitleStatus]) VALUES (6, N'Boarding')
INSERT [dbo].[Status] ([IdStatus], [TitleStatus]) VALUES (7, N'Check-In Open')
INSERT [dbo].[Status] ([IdStatus], [TitleStatus]) VALUES (8, N'Check-In Closed')
INSERT [dbo].[Status] ([IdStatus], [TitleStatus]) VALUES (9, N'Gate Closed')
INSERT [dbo].[Status] ([IdStatus], [TitleStatus]) VALUES (10, N'Unknown')
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[StatusGate] ON 

INSERT [dbo].[StatusGate] ([IdStatusGate], [StatusTitile]) VALUES (1, N'Open')
INSERT [dbo].[StatusGate] ([IdStatusGate], [StatusTitile]) VALUES (2, N'Closed')
INSERT [dbo].[StatusGate] ([IdStatusGate], [StatusTitile]) VALUES (3, N'Delayed')
INSERT [dbo].[StatusGate] ([IdStatusGate], [StatusTitile]) VALUES (4, N'Cancelled')
INSERT [dbo].[StatusGate] ([IdStatusGate], [StatusTitile]) VALUES (5, N'Boarding')
INSERT [dbo].[StatusGate] ([IdStatusGate], [StatusTitile]) VALUES (6, N'Arrived')
INSERT [dbo].[StatusGate] ([IdStatusGate], [StatusTitile]) VALUES (7, N'Departed')
INSERT [dbo].[StatusGate] ([IdStatusGate], [StatusTitile]) VALUES (8, N'Waiting')
INSERT [dbo].[StatusGate] ([IdStatusGate], [StatusTitile]) VALUES (9, N'Cleaning')
INSERT [dbo].[StatusGate] ([IdStatusGate], [StatusTitile]) VALUES (10, N'Maintenance')
INSERT [dbo].[StatusGate] ([IdStatusGate], [StatusTitile]) VALUES (11, N'Open')
INSERT [dbo].[StatusGate] ([IdStatusGate], [StatusTitile]) VALUES (12, N'Closed')
INSERT [dbo].[StatusGate] ([IdStatusGate], [StatusTitile]) VALUES (13, N'Delayed')
INSERT [dbo].[StatusGate] ([IdStatusGate], [StatusTitile]) VALUES (14, N'Cancelled')
INSERT [dbo].[StatusGate] ([IdStatusGate], [StatusTitile]) VALUES (15, N'Boarding')
INSERT [dbo].[StatusGate] ([IdStatusGate], [StatusTitile]) VALUES (16, N'Arrived')
INSERT [dbo].[StatusGate] ([IdStatusGate], [StatusTitile]) VALUES (17, N'Departed')
INSERT [dbo].[StatusGate] ([IdStatusGate], [StatusTitile]) VALUES (18, N'Waiting')
INSERT [dbo].[StatusGate] ([IdStatusGate], [StatusTitile]) VALUES (19, N'Cleaning')
INSERT [dbo].[StatusGate] ([IdStatusGate], [StatusTitile]) VALUES (20, N'Maintenance')
INSERT [dbo].[StatusGate] ([IdStatusGate], [StatusTitile]) VALUES (21, N'Open')
INSERT [dbo].[StatusGate] ([IdStatusGate], [StatusTitile]) VALUES (22, N'Closed')
INSERT [dbo].[StatusGate] ([IdStatusGate], [StatusTitile]) VALUES (23, N'Delayed')
INSERT [dbo].[StatusGate] ([IdStatusGate], [StatusTitile]) VALUES (24, N'Cancelled')
INSERT [dbo].[StatusGate] ([IdStatusGate], [StatusTitile]) VALUES (25, N'Boarding')
INSERT [dbo].[StatusGate] ([IdStatusGate], [StatusTitile]) VALUES (26, N'Arrived')
INSERT [dbo].[StatusGate] ([IdStatusGate], [StatusTitile]) VALUES (27, N'Departed')
INSERT [dbo].[StatusGate] ([IdStatusGate], [StatusTitile]) VALUES (28, N'Waiting')
INSERT [dbo].[StatusGate] ([IdStatusGate], [StatusTitile]) VALUES (29, N'Cleaning')
INSERT [dbo].[StatusGate] ([IdStatusGate], [StatusTitile]) VALUES (30, N'Maintenance')
SET IDENTITY_INSERT [dbo].[StatusGate] OFF
GO
SET IDENTITY_INSERT [dbo].[StatusRegistration] ON 

INSERT [dbo].[StatusRegistration] ([IdStatusRegistration], [TitleStatus]) VALUES (1, N'Not Checked-In')
INSERT [dbo].[StatusRegistration] ([IdStatusRegistration], [TitleStatus]) VALUES (2, N'Checked-In')
INSERT [dbo].[StatusRegistration] ([IdStatusRegistration], [TitleStatus]) VALUES (3, N'Boarded')
INSERT [dbo].[StatusRegistration] ([IdStatusRegistration], [TitleStatus]) VALUES (4, N'Cancelled')
INSERT [dbo].[StatusRegistration] ([IdStatusRegistration], [TitleStatus]) VALUES (5, N'Delayed')
INSERT [dbo].[StatusRegistration] ([IdStatusRegistration], [TitleStatus]) VALUES (6, N'Completed')
INSERT [dbo].[StatusRegistration] ([IdStatusRegistration], [TitleStatus]) VALUES (7, N'In Progress')
INSERT [dbo].[StatusRegistration] ([IdStatusRegistration], [TitleStatus]) VALUES (8, N'Waiting')
INSERT [dbo].[StatusRegistration] ([IdStatusRegistration], [TitleStatus]) VALUES (9, N'Failed')
INSERT [dbo].[StatusRegistration] ([IdStatusRegistration], [TitleStatus]) VALUES (10, N'Expired')
INSERT [dbo].[StatusRegistration] ([IdStatusRegistration], [TitleStatus]) VALUES (11, N'Not Checked-In')
INSERT [dbo].[StatusRegistration] ([IdStatusRegistration], [TitleStatus]) VALUES (12, N'Checked-In')
INSERT [dbo].[StatusRegistration] ([IdStatusRegistration], [TitleStatus]) VALUES (13, N'Boarded')
INSERT [dbo].[StatusRegistration] ([IdStatusRegistration], [TitleStatus]) VALUES (14, N'Cancelled')
INSERT [dbo].[StatusRegistration] ([IdStatusRegistration], [TitleStatus]) VALUES (15, N'Delayed')
INSERT [dbo].[StatusRegistration] ([IdStatusRegistration], [TitleStatus]) VALUES (16, N'Completed')
INSERT [dbo].[StatusRegistration] ([IdStatusRegistration], [TitleStatus]) VALUES (17, N'In Progress')
INSERT [dbo].[StatusRegistration] ([IdStatusRegistration], [TitleStatus]) VALUES (18, N'Waiting')
INSERT [dbo].[StatusRegistration] ([IdStatusRegistration], [TitleStatus]) VALUES (19, N'Failed')
INSERT [dbo].[StatusRegistration] ([IdStatusRegistration], [TitleStatus]) VALUES (20, N'Expired')
INSERT [dbo].[StatusRegistration] ([IdStatusRegistration], [TitleStatus]) VALUES (21, N'Not Checked-In')
INSERT [dbo].[StatusRegistration] ([IdStatusRegistration], [TitleStatus]) VALUES (22, N'Checked-In')
INSERT [dbo].[StatusRegistration] ([IdStatusRegistration], [TitleStatus]) VALUES (23, N'Boarded')
INSERT [dbo].[StatusRegistration] ([IdStatusRegistration], [TitleStatus]) VALUES (24, N'Cancelled')
INSERT [dbo].[StatusRegistration] ([IdStatusRegistration], [TitleStatus]) VALUES (25, N'Delayed')
INSERT [dbo].[StatusRegistration] ([IdStatusRegistration], [TitleStatus]) VALUES (26, N'Completed')
INSERT [dbo].[StatusRegistration] ([IdStatusRegistration], [TitleStatus]) VALUES (27, N'In Progress')
INSERT [dbo].[StatusRegistration] ([IdStatusRegistration], [TitleStatus]) VALUES (28, N'Waiting')
INSERT [dbo].[StatusRegistration] ([IdStatusRegistration], [TitleStatus]) VALUES (29, N'Failed')
INSERT [dbo].[StatusRegistration] ([IdStatusRegistration], [TitleStatus]) VALUES (30, N'Expired')
SET IDENTITY_INSERT [dbo].[StatusRegistration] OFF
GO
SET IDENTITY_INSERT [dbo].[TicketsSelling] ON 

INSERT [dbo].[TicketsSelling] ([IdTicketSelling], [IdFlight], [NumberTicket], [PassportNumber], [PlaceOfIssue], [DateOfIssue], [FirstName], [SecondName], [Surname], [DateOfBirth], [BagageCount], [FormOfPaymentId], [Email]) VALUES (1, 1, 1001, N'AB1234567', N'Moscow', CAST(N'2025-02-20' AS Date), N'Ivan', N'Petrovich', N'Sidorov', CAST(N'1985-05-15' AS Date), 1, 1, N'ivan.sidorov@example.com')
INSERT [dbo].[TicketsSelling] ([IdTicketSelling], [IdFlight], [NumberTicket], [PassportNumber], [PlaceOfIssue], [DateOfIssue], [FirstName], [SecondName], [Surname], [DateOfBirth], [BagageCount], [FormOfPaymentId], [Email]) VALUES (2, 2, 1002, N'BC2345678', N'Istanbul', CAST(N'2025-02-21' AS Date), N'Maria', N'Ivanovna', N'Kuznetsova', CAST(N'1990-08-20' AS Date), 2, 2, N'maria.kuznetsova@example.com')
INSERT [dbo].[TicketsSelling] ([IdTicketSelling], [IdFlight], [NumberTicket], [PassportNumber], [PlaceOfIssue], [DateOfIssue], [FirstName], [SecondName], [Surname], [DateOfBirth], [BagageCount], [FormOfPaymentId], [Email]) VALUES (3, 3, 1003, N'CD3456789', N'Dubai', CAST(N'2025-02-22' AS Date), N'Alexey', N'Sergeevich', N'Popov', CAST(N'1980-03-10' AS Date), 1, 3, N'alexey.popov@example.com')
INSERT [dbo].[TicketsSelling] ([IdTicketSelling], [IdFlight], [NumberTicket], [PassportNumber], [PlaceOfIssue], [DateOfIssue], [FirstName], [SecondName], [Surname], [DateOfBirth], [BagageCount], [FormOfPaymentId], [Email]) VALUES (4, 4, 1004, N'DE4567890', N'Frankfurt', CAST(N'2025-02-23' AS Date), N'Anna', N'Andreevna', N'Morozova', CAST(N'1995-11-25' AS Date), 3, 4, N'anna.morozova@example.com')
INSERT [dbo].[TicketsSelling] ([IdTicketSelling], [IdFlight], [NumberTicket], [PassportNumber], [PlaceOfIssue], [DateOfIssue], [FirstName], [SecondName], [Surname], [DateOfBirth], [BagageCount], [FormOfPaymentId], [Email]) VALUES (5, 5, 1005, N'EF5678901', N'London', CAST(N'2025-02-24' AS Date), N'Dmitry', N'Vladimirovich', N'Kozlov', CAST(N'1975-07-30' AS Date), 2, 5, N'dmitry.kozlov@example.com')
INSERT [dbo].[TicketsSelling] ([IdTicketSelling], [IdFlight], [NumberTicket], [PassportNumber], [PlaceOfIssue], [DateOfIssue], [FirstName], [SecondName], [Surname], [DateOfBirth], [BagageCount], [FormOfPaymentId], [Email]) VALUES (6, 6, 1006, N'FG6789012', N'Paris', CAST(N'2025-02-25' AS Date), N'Olga', N'Mikhailovna', N'Volkova', CAST(N'1988-01-12' AS Date), 1, 6, N'olga.volkova@example.com')
INSERT [dbo].[TicketsSelling] ([IdTicketSelling], [IdFlight], [NumberTicket], [PassportNumber], [PlaceOfIssue], [DateOfIssue], [FirstName], [SecondName], [Surname], [DateOfBirth], [BagageCount], [FormOfPaymentId], [Email]) VALUES (7, 7, 1007, N'GH7890123', N'Doha', CAST(N'2025-02-26' AS Date), N'Sergey', N'Nikolaevich', N'Lebedev', CAST(N'1970-09-18' AS Date), 2, 7, N'sergey.lebedev@example.com')
INSERT [dbo].[TicketsSelling] ([IdTicketSelling], [IdFlight], [NumberTicket], [PassportNumber], [PlaceOfIssue], [DateOfIssue], [FirstName], [SecondName], [Surname], [DateOfBirth], [BagageCount], [FormOfPaymentId], [Email]) VALUES (8, 8, 1008, N'HI8901234', N'Singapore', CAST(N'2025-02-27' AS Date), N'Elena', N'Vladimirovna', N'Zaytseva', CAST(N'1992-04-22' AS Date), 3, 8, N'elena.zaytseva@example.com')
INSERT [dbo].[TicketsSelling] ([IdTicketSelling], [IdFlight], [NumberTicket], [PassportNumber], [PlaceOfIssue], [DateOfIssue], [FirstName], [SecondName], [Surname], [DateOfBirth], [BagageCount], [FormOfPaymentId], [Email]) VALUES (9, 9, 1009, N'IJ9012345', N'Atlanta', CAST(N'2025-02-28' AS Date), N'Andrey', N'Pavlovich', N'Smirnov', CAST(N'1982-06-05' AS Date), 1, 9, N'andrey.smirnov@example.com')
INSERT [dbo].[TicketsSelling] ([IdTicketSelling], [IdFlight], [NumberTicket], [PassportNumber], [PlaceOfIssue], [DateOfIssue], [FirstName], [SecondName], [Surname], [DateOfBirth], [BagageCount], [FormOfPaymentId], [Email]) VALUES (10, 10, 1010, N'JK0123456', N'Los Angeles', CAST(N'2025-03-01' AS Date), N'Tatiana', N'Sergeevna', N'Fedorova', CAST(N'1998-12-10' AS Date), 2, 10, N'tatiana.fedorova@example.com')
INSERT [dbo].[TicketsSelling] ([IdTicketSelling], [IdFlight], [NumberTicket], [PassportNumber], [PlaceOfIssue], [DateOfIssue], [FirstName], [SecondName], [Surname], [DateOfBirth], [BagageCount], [FormOfPaymentId], [Email]) VALUES (11, 1, 1001, N'AB1234567', N'Moscow', CAST(N'2025-02-20' AS Date), N'Ivan', N'Petrovich', N'Sidorov', CAST(N'1985-05-15' AS Date), 1, 1, N'ivan.sidorov@example.com')
INSERT [dbo].[TicketsSelling] ([IdTicketSelling], [IdFlight], [NumberTicket], [PassportNumber], [PlaceOfIssue], [DateOfIssue], [FirstName], [SecondName], [Surname], [DateOfBirth], [BagageCount], [FormOfPaymentId], [Email]) VALUES (12, 2, 1002, N'BC2345678', N'Istanbul', CAST(N'2025-02-21' AS Date), N'Maria', N'Ivanovna', N'Kuznetsova', CAST(N'1990-08-20' AS Date), 2, 2, N'maria.kuznetsova@example.com')
INSERT [dbo].[TicketsSelling] ([IdTicketSelling], [IdFlight], [NumberTicket], [PassportNumber], [PlaceOfIssue], [DateOfIssue], [FirstName], [SecondName], [Surname], [DateOfBirth], [BagageCount], [FormOfPaymentId], [Email]) VALUES (13, 3, 1003, N'CD3456789', N'Dubai', CAST(N'2025-02-22' AS Date), N'Alexey', N'Sergeevich', N'Popov', CAST(N'1980-03-10' AS Date), 1, 3, N'alexey.popov@example.com')
INSERT [dbo].[TicketsSelling] ([IdTicketSelling], [IdFlight], [NumberTicket], [PassportNumber], [PlaceOfIssue], [DateOfIssue], [FirstName], [SecondName], [Surname], [DateOfBirth], [BagageCount], [FormOfPaymentId], [Email]) VALUES (14, 4, 1004, N'DE4567890', N'Frankfurt', CAST(N'2025-02-23' AS Date), N'Anna', N'Andreevna', N'Morozova', CAST(N'1995-11-25' AS Date), 3, 4, N'anna.morozova@example.com')
INSERT [dbo].[TicketsSelling] ([IdTicketSelling], [IdFlight], [NumberTicket], [PassportNumber], [PlaceOfIssue], [DateOfIssue], [FirstName], [SecondName], [Surname], [DateOfBirth], [BagageCount], [FormOfPaymentId], [Email]) VALUES (15, 5, 1005, N'EF5678901', N'London', CAST(N'2025-02-24' AS Date), N'Dmitry', N'Vladimirovich', N'Kozlov', CAST(N'1975-07-30' AS Date), 2, 5, N'dmitry.kozlov@example.com')
INSERT [dbo].[TicketsSelling] ([IdTicketSelling], [IdFlight], [NumberTicket], [PassportNumber], [PlaceOfIssue], [DateOfIssue], [FirstName], [SecondName], [Surname], [DateOfBirth], [BagageCount], [FormOfPaymentId], [Email]) VALUES (16, 6, 1006, N'FG6789012', N'Paris', CAST(N'2025-02-25' AS Date), N'Olga', N'Mikhailovna', N'Volkova', CAST(N'1988-01-12' AS Date), 1, 6, N'olga.volkova@example.com')
INSERT [dbo].[TicketsSelling] ([IdTicketSelling], [IdFlight], [NumberTicket], [PassportNumber], [PlaceOfIssue], [DateOfIssue], [FirstName], [SecondName], [Surname], [DateOfBirth], [BagageCount], [FormOfPaymentId], [Email]) VALUES (17, 7, 1007, N'GH7890123', N'Doha', CAST(N'2025-02-26' AS Date), N'Sergey', N'Nikolaevich', N'Lebedev', CAST(N'1970-09-18' AS Date), 2, 7, N'sergey.lebedev@example.com')
INSERT [dbo].[TicketsSelling] ([IdTicketSelling], [IdFlight], [NumberTicket], [PassportNumber], [PlaceOfIssue], [DateOfIssue], [FirstName], [SecondName], [Surname], [DateOfBirth], [BagageCount], [FormOfPaymentId], [Email]) VALUES (18, 8, 1008, N'HI8901234', N'Singapore', CAST(N'2025-02-27' AS Date), N'Elena', N'Vladimirovna', N'Zaytseva', CAST(N'1992-04-22' AS Date), 3, 8, N'elena.zaytseva@example.com')
INSERT [dbo].[TicketsSelling] ([IdTicketSelling], [IdFlight], [NumberTicket], [PassportNumber], [PlaceOfIssue], [DateOfIssue], [FirstName], [SecondName], [Surname], [DateOfBirth], [BagageCount], [FormOfPaymentId], [Email]) VALUES (19, 9, 1009, N'IJ9012345', N'Atlanta', CAST(N'2025-02-28' AS Date), N'Andrey', N'Pavlovich', N'Smirnov', CAST(N'1982-06-05' AS Date), 1, 9, N'andrey.smirnov@example.com')
INSERT [dbo].[TicketsSelling] ([IdTicketSelling], [IdFlight], [NumberTicket], [PassportNumber], [PlaceOfIssue], [DateOfIssue], [FirstName], [SecondName], [Surname], [DateOfBirth], [BagageCount], [FormOfPaymentId], [Email]) VALUES (20, 10, 1010, N'JK0123456', N'Los Angeles', CAST(N'2025-03-01' AS Date), N'Tatiana', N'Sergeevna', N'Fedorova', CAST(N'1998-12-10' AS Date), 2, 10, N'tatiana.fedorova@example.com')
INSERT [dbo].[TicketsSelling] ([IdTicketSelling], [IdFlight], [NumberTicket], [PassportNumber], [PlaceOfIssue], [DateOfIssue], [FirstName], [SecondName], [Surname], [DateOfBirth], [BagageCount], [FormOfPaymentId], [Email]) VALUES (21, 1, 1001, N'AB1234567', N'Moscow', CAST(N'2025-02-20' AS Date), N'Ivan', N'Petrovich', N'Sidorov', CAST(N'1985-05-15' AS Date), 1, 1, N'ivan.sidorov@example.com')
INSERT [dbo].[TicketsSelling] ([IdTicketSelling], [IdFlight], [NumberTicket], [PassportNumber], [PlaceOfIssue], [DateOfIssue], [FirstName], [SecondName], [Surname], [DateOfBirth], [BagageCount], [FormOfPaymentId], [Email]) VALUES (22, 2, 1002, N'BC2345678', N'Istanbul', CAST(N'2025-02-21' AS Date), N'Maria', N'Ivanovna', N'Kuznetsova', CAST(N'1990-08-20' AS Date), 2, 2, N'maria.kuznetsova@example.com')
INSERT [dbo].[TicketsSelling] ([IdTicketSelling], [IdFlight], [NumberTicket], [PassportNumber], [PlaceOfIssue], [DateOfIssue], [FirstName], [SecondName], [Surname], [DateOfBirth], [BagageCount], [FormOfPaymentId], [Email]) VALUES (23, 3, 1003, N'CD3456789', N'Dubai', CAST(N'2025-02-22' AS Date), N'Alexey', N'Sergeevich', N'Popov', CAST(N'1980-03-10' AS Date), 1, 3, N'alexey.popov@example.com')
INSERT [dbo].[TicketsSelling] ([IdTicketSelling], [IdFlight], [NumberTicket], [PassportNumber], [PlaceOfIssue], [DateOfIssue], [FirstName], [SecondName], [Surname], [DateOfBirth], [BagageCount], [FormOfPaymentId], [Email]) VALUES (24, 4, 1004, N'DE4567890', N'Frankfurt', CAST(N'2025-02-23' AS Date), N'Anna', N'Andreevna', N'Morozova', CAST(N'1995-11-25' AS Date), 3, 4, N'anna.morozova@example.com')
INSERT [dbo].[TicketsSelling] ([IdTicketSelling], [IdFlight], [NumberTicket], [PassportNumber], [PlaceOfIssue], [DateOfIssue], [FirstName], [SecondName], [Surname], [DateOfBirth], [BagageCount], [FormOfPaymentId], [Email]) VALUES (25, 5, 1005, N'EF5678901', N'London', CAST(N'2025-02-24' AS Date), N'Dmitry', N'Vladimirovich', N'Kozlov', CAST(N'1975-07-30' AS Date), 2, 5, N'dmitry.kozlov@example.com')
INSERT [dbo].[TicketsSelling] ([IdTicketSelling], [IdFlight], [NumberTicket], [PassportNumber], [PlaceOfIssue], [DateOfIssue], [FirstName], [SecondName], [Surname], [DateOfBirth], [BagageCount], [FormOfPaymentId], [Email]) VALUES (26, 6, 1006, N'FG6789012', N'Paris', CAST(N'2025-02-25' AS Date), N'Olga', N'Mikhailovna', N'Volkova', CAST(N'1988-01-12' AS Date), 1, 6, N'olga.volkova@example.com')
INSERT [dbo].[TicketsSelling] ([IdTicketSelling], [IdFlight], [NumberTicket], [PassportNumber], [PlaceOfIssue], [DateOfIssue], [FirstName], [SecondName], [Surname], [DateOfBirth], [BagageCount], [FormOfPaymentId], [Email]) VALUES (27, 7, 1007, N'GH7890123', N'Doha', CAST(N'2025-02-26' AS Date), N'Sergey', N'Nikolaevich', N'Lebedev', CAST(N'1970-09-18' AS Date), 2, 7, N'sergey.lebedev@example.com')
INSERT [dbo].[TicketsSelling] ([IdTicketSelling], [IdFlight], [NumberTicket], [PassportNumber], [PlaceOfIssue], [DateOfIssue], [FirstName], [SecondName], [Surname], [DateOfBirth], [BagageCount], [FormOfPaymentId], [Email]) VALUES (28, 8, 1008, N'HI8901234', N'Singapore', CAST(N'2025-02-27' AS Date), N'Elena', N'Vladimirovna', N'Zaytseva', CAST(N'1992-04-22' AS Date), 3, 8, N'elena.zaytseva@example.com')
INSERT [dbo].[TicketsSelling] ([IdTicketSelling], [IdFlight], [NumberTicket], [PassportNumber], [PlaceOfIssue], [DateOfIssue], [FirstName], [SecondName], [Surname], [DateOfBirth], [BagageCount], [FormOfPaymentId], [Email]) VALUES (29, 9, 1009, N'IJ9012345', N'Atlanta', CAST(N'2025-02-28' AS Date), N'Andrey', N'Pavlovich', N'Smirnov', CAST(N'1982-06-05' AS Date), 1, 9, N'andrey.smirnov@example.com')
INSERT [dbo].[TicketsSelling] ([IdTicketSelling], [IdFlight], [NumberTicket], [PassportNumber], [PlaceOfIssue], [DateOfIssue], [FirstName], [SecondName], [Surname], [DateOfBirth], [BagageCount], [FormOfPaymentId], [Email]) VALUES (30, 10, 1010, N'JK0123456', N'Los Angeles', CAST(N'2025-03-01' AS Date), N'Tatiana', N'Sergeevna', N'Fedorova', CAST(N'1998-12-10' AS Date), 2, 10, N'tatiana.fedorova@example.com')
SET IDENTITY_INSERT [dbo].[TicketsSelling] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([IdUser], [FirstName], [SecondName], [Surname], [Login], [Password]) VALUES (1, N'Admin', N'Adminovich', N'Administrator', N'admin', N'password123')
INSERT [dbo].[User] ([IdUser], [FirstName], [SecondName], [Surname], [Login], [Password]) VALUES (2, N'Manager', N'Managerovich', N'Management', N'manager', N'manager123')
INSERT [dbo].[User] ([IdUser], [FirstName], [SecondName], [Surname], [Login], [Password]) VALUES (3, N'Agent', N'Agentovich', N'TravelAgent', N'agent', N'agent123')
INSERT [dbo].[User] ([IdUser], [FirstName], [SecondName], [Surname], [Login], [Password]) VALUES (4, N'Customer', N'Customerovich', N'Client', N'customer', N'customer123')
INSERT [dbo].[User] ([IdUser], [FirstName], [SecondName], [Surname], [Login], [Password]) VALUES (5, N'Guest', N'Guestovich', N'Visitor', N'guest', N'guest123')
INSERT [dbo].[User] ([IdUser], [FirstName], [SecondName], [Surname], [Login], [Password]) VALUES (6, N'Support', N'Supportovich', N'HelpDesk', N'support', N'support123')
INSERT [dbo].[User] ([IdUser], [FirstName], [SecondName], [Surname], [Login], [Password]) VALUES (7, N'Developer', N'Developovich', N'Programmer', N'developer', N'developer123')
INSERT [dbo].[User] ([IdUser], [FirstName], [SecondName], [Surname], [Login], [Password]) VALUES (8, N'Tester', N'Testovich', N'QA', N'tester', N'tester123')
INSERT [dbo].[User] ([IdUser], [FirstName], [SecondName], [Surname], [Login], [Password]) VALUES (9, N'Analyst', N'Analytovich', N'DataAnalyst', N'analyst', N'analyst123')
INSERT [dbo].[User] ([IdUser], [FirstName], [SecondName], [Surname], [Login], [Password]) VALUES (10, N'Designer', N'Designovich', N'UIUX', N'designer', N'designer123')
INSERT [dbo].[User] ([IdUser], [FirstName], [SecondName], [Surname], [Login], [Password]) VALUES (11, N'Admin', N'Adminovich', N'Administrator', N'admin', N'password123')
INSERT [dbo].[User] ([IdUser], [FirstName], [SecondName], [Surname], [Login], [Password]) VALUES (12, N'Manager', N'Managerovich', N'Management', N'manager', N'manager123')
INSERT [dbo].[User] ([IdUser], [FirstName], [SecondName], [Surname], [Login], [Password]) VALUES (13, N'Agent', N'Agentovich', N'TravelAgent', N'agent', N'agent123')
INSERT [dbo].[User] ([IdUser], [FirstName], [SecondName], [Surname], [Login], [Password]) VALUES (14, N'Customer', N'Customerovich', N'Client', N'customer', N'customer123')
INSERT [dbo].[User] ([IdUser], [FirstName], [SecondName], [Surname], [Login], [Password]) VALUES (15, N'Guest', N'Guestovich', N'Visitor', N'guest', N'guest123')
INSERT [dbo].[User] ([IdUser], [FirstName], [SecondName], [Surname], [Login], [Password]) VALUES (16, N'Support', N'Supportovich', N'HelpDesk', N'support', N'support123')
INSERT [dbo].[User] ([IdUser], [FirstName], [SecondName], [Surname], [Login], [Password]) VALUES (17, N'Developer', N'Developovich', N'Programmer', N'developer', N'developer123')
INSERT [dbo].[User] ([IdUser], [FirstName], [SecondName], [Surname], [Login], [Password]) VALUES (18, N'Tester', N'Testovich', N'QA', N'tester', N'tester123')
INSERT [dbo].[User] ([IdUser], [FirstName], [SecondName], [Surname], [Login], [Password]) VALUES (19, N'Analyst', N'Analytovich', N'DataAnalyst', N'analyst', N'analyst123')
INSERT [dbo].[User] ([IdUser], [FirstName], [SecondName], [Surname], [Login], [Password]) VALUES (20, N'Designer', N'Designovich', N'UIUX', N'designer', N'designer123')
INSERT [dbo].[User] ([IdUser], [FirstName], [SecondName], [Surname], [Login], [Password]) VALUES (21, N'Admin', N'Adminovich', N'Administrator', N'admin', N'password123')
INSERT [dbo].[User] ([IdUser], [FirstName], [SecondName], [Surname], [Login], [Password]) VALUES (22, N'Manager', N'Managerovich', N'Management', N'manager', N'manager123')
INSERT [dbo].[User] ([IdUser], [FirstName], [SecondName], [Surname], [Login], [Password]) VALUES (23, N'Agent', N'Agentovich', N'TravelAgent', N'agent', N'agent123')
INSERT [dbo].[User] ([IdUser], [FirstName], [SecondName], [Surname], [Login], [Password]) VALUES (24, N'Customer', N'Customerovich', N'Client', N'customer', N'customer123')
INSERT [dbo].[User] ([IdUser], [FirstName], [SecondName], [Surname], [Login], [Password]) VALUES (25, N'Guest', N'Guestovich', N'Visitor', N'guest', N'guest123')
INSERT [dbo].[User] ([IdUser], [FirstName], [SecondName], [Surname], [Login], [Password]) VALUES (26, N'Support', N'Supportovich', N'HelpDesk', N'support', N'support123')
INSERT [dbo].[User] ([IdUser], [FirstName], [SecondName], [Surname], [Login], [Password]) VALUES (27, N'Developer', N'Developovich', N'Programmer', N'developer', N'developer123')
INSERT [dbo].[User] ([IdUser], [FirstName], [SecondName], [Surname], [Login], [Password]) VALUES (28, N'Tester', N'Testovich', N'QA', N'tester', N'tester123')
INSERT [dbo].[User] ([IdUser], [FirstName], [SecondName], [Surname], [Login], [Password]) VALUES (29, N'Analyst', N'Analytovich', N'DataAnalyst', N'analyst', N'analyst123')
INSERT [dbo].[User] ([IdUser], [FirstName], [SecondName], [Surname], [Login], [Password]) VALUES (30, N'Designer', N'Designovich', N'UIUX', N'designer', N'designer123')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_BookingsStatus] FOREIGN KEY([IdBookingStatus])
REFERENCES [dbo].[BookingsStatus] ([IdBookingStatus])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_BookingsStatus]
GO
ALTER TABLE [dbo].[BookingTickets]  WITH CHECK ADD  CONSTRAINT [FK_BookingTickets_Bookings] FOREIGN KEY([IdBooking])
REFERENCES [dbo].[Bookings] ([IdBooking])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BookingTickets] CHECK CONSTRAINT [FK_BookingTickets_Bookings]
GO
ALTER TABLE [dbo].[BookingTickets]  WITH CHECK ADD  CONSTRAINT [FK_BookingTickets_TicketsSelling1] FOREIGN KEY([IdTicketSelling])
REFERENCES [dbo].[TicketsSelling] ([IdTicketSelling])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BookingTickets] CHECK CONSTRAINT [FK_BookingTickets_TicketsSelling1]
GO
ALTER TABLE [dbo].[Flights]  WITH CHECK ADD  CONSTRAINT [FK_Flights_Airlines] FOREIGN KEY([IdAirlane])
REFERENCES [dbo].[Airlines] ([IdAirline])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Flights] CHECK CONSTRAINT [FK_Flights_Airlines]
GO
ALTER TABLE [dbo].[Flights]  WITH CHECK ADD  CONSTRAINT [FK_Flights_Airplane] FOREIGN KEY([IdAirplane])
REFERENCES [dbo].[Airplane] ([IdAirplane])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Flights] CHECK CONSTRAINT [FK_Flights_Airplane]
GO
ALTER TABLE [dbo].[Flights]  WITH CHECK ADD  CONSTRAINT [FK_Flights_Airports] FOREIGN KEY([AirportDeparturesId])
REFERENCES [dbo].[Airports] ([IdAirport])
GO
ALTER TABLE [dbo].[Flights] CHECK CONSTRAINT [FK_Flights_Airports]
GO
ALTER TABLE [dbo].[Flights]  WITH CHECK ADD  CONSTRAINT [FK_Flights_Airports1] FOREIGN KEY([ArrivalAirportId])
REFERENCES [dbo].[Airports] ([IdAirport])
GO
ALTER TABLE [dbo].[Flights] CHECK CONSTRAINT [FK_Flights_Airports1]
GO
ALTER TABLE [dbo].[Flights]  WITH CHECK ADD  CONSTRAINT [FK_Flights_Gates] FOREIGN KEY([IdGate])
REFERENCES [dbo].[Gates] ([IdGate])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Flights] CHECK CONSTRAINT [FK_Flights_Gates]
GO
ALTER TABLE [dbo].[Flights]  WITH CHECK ADD  CONSTRAINT [FK_Flights_Status] FOREIGN KEY([IdStatus])
REFERENCES [dbo].[Status] ([IdStatus])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Flights] CHECK CONSTRAINT [FK_Flights_Status]
GO
ALTER TABLE [dbo].[Gates]  WITH CHECK ADD  CONSTRAINT [FK_Gates_StatusGate] FOREIGN KEY([IdStatusGate])
REFERENCES [dbo].[StatusGate] ([IdStatusGate])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Gates] CHECK CONSTRAINT [FK_Gates_StatusGate]
GO
ALTER TABLE [dbo].[Registration]  WITH CHECK ADD  CONSTRAINT [FK_Registration_Bagage] FOREIGN KEY([IdBagage])
REFERENCES [dbo].[Bagage] ([IdBagage])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Registration] CHECK CONSTRAINT [FK_Registration_Bagage]
GO
ALTER TABLE [dbo].[Registration]  WITH CHECK ADD  CONSTRAINT [FK_Registration_StatusRegistration] FOREIGN KEY([IdStatusRegistration])
REFERENCES [dbo].[StatusRegistration] ([IdStatusRegistration])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Registration] CHECK CONSTRAINT [FK_Registration_StatusRegistration]
GO
ALTER TABLE [dbo].[Registration]  WITH CHECK ADD  CONSTRAINT [FK_Registration_TicketsSelling1] FOREIGN KEY([IdTicketSelling])
REFERENCES [dbo].[TicketsSelling] ([IdTicketSelling])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Registration] CHECK CONSTRAINT [FK_Registration_TicketsSelling1]
GO
ALTER TABLE [dbo].[TicketsSelling]  WITH CHECK ADD  CONSTRAINT [FK_TicketsSelling_Flights] FOREIGN KEY([IdFlight])
REFERENCES [dbo].[Flights] ([IdFlight])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TicketsSelling] CHECK CONSTRAINT [FK_TicketsSelling_Flights]
GO
ALTER TABLE [dbo].[TicketsSelling]  WITH CHECK ADD  CONSTRAINT [FK_TicketsSelling_FormOfPayments] FOREIGN KEY([FormOfPaymentId])
REFERENCES [dbo].[FormOfPayments] ([FormOfPaymentId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TicketsSelling] CHECK CONSTRAINT [FK_TicketsSelling_FormOfPayments]
GO
USE [master]
GO
ALTER DATABASE [Airport] SET  READ_WRITE 
GO
