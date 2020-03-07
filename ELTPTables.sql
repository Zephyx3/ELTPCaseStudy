-- Create Database (if you need)
create database ELTPCaseStudy
go
-- Rename ELTPCaseStudy to your DB name below
use ELTPCaseStudy
go

create table Users(
UserID int primary key identity(1,1),
Email nvarchar(max),
PasswordHash nvarchar(max),
Name nvarchar(max),
Mobile nvarchar(max),
IsAdmin bit default(0))
go


create table Movies(
MovieID int primary key identity(1,1),
MovieName nvarchar(max),
MovieReleaseDate date,
MovieGenre nvarchar(max),
MovieDescription nvarchar(max),
ReviewsCount int)
go

create table Reviews(
ReviewID int primary key identity(1,1),
ReviewText nvarchar(max),
ReviewDateAndTime datetime,
UserID int references Users(UserID),
MovieID int references Movies(MovieID) on delete cascade,
ReviewCount int)
go

create table Rentals(
RentalID int primary key identity(1,1),
RentalDateAndTime datetime,
RentalDuration datetime,
MovieID int references Movies(MovieID) on delete cascade)
go




insert into Users values('admin@gmail.com', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9',
'Admin', '0000000000', 1)

insert into Users values('admin@gmail.com', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9',
'Admin', '0000000000', 0)

insert into Movies values('Sonic', '2020-02-20', 'Action & Adventure, Comedy', 'SONIC THE HEDGEHOG is a live-action adventure comedy based on the global blockbuster video game franchise from Sega that centers on the infamously brash bright blue hedgehog. The film follows the (mis)adventures of Sonic as he navigates the complexities of life on Earth with his newfound -- human -- best friend Tom Wachowski (James Marsden). Sonic and Tom join forces to try and stop the villainous Dr. Robotnik (Jim Carrey) from capturing Sonic and using his immense powers for world domination. The film also stars Tika Sumpter and Ben Schwartz as the voice of Sonic.',
 0)
go

select * from Movies
select * from users

-- password:  admin123

