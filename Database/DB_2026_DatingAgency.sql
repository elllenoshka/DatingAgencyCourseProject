USE master;
GO

IF DB_ID('DatingAgency') IS NOT NULL
BEGIN
    ALTER DATABASE DatingAgency SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE DatingAgency;
END
GO

CREATE DATABASE DatingAgency;
GO

USE DatingAgency;
GO

CREATE TABLE Roles (
    RoleId INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(40) NOT NULL UNIQUE
);
GO

CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(120) NOT NULL,
    Email NVARCHAR(120) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    RoleId INT NOT NULL,
    Phone NVARCHAR(30),
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    FOREIGN KEY (RoleId) REFERENCES Roles(RoleId)
);
GO

CREATE TABLE ClientProfiles (
    ClientProfileId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL UNIQUE,
    Gender NVARCHAR(20) NOT NULL,
    BirthDate DATE NOT NULL,
    City NVARCHAR(60) NOT NULL,
    Height INT CHECK (Height BETWEEN 120 AND 230),
    Education NVARCHAR(80),
    Occupation NVARCHAR(80),
    Interests NVARCHAR(400),
    AboutMe NVARCHAR(600),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);
GO

CREATE TABLE PartnerPreferences (
    PreferenceId INT PRIMARY KEY IDENTITY(1,1),
    ClientProfileId INT NOT NULL,
    PreferredGender NVARCHAR(20),
    MinAge INT CHECK (MinAge >= 18),
    MaxAge INT CHECK (MaxAge >= 18),
    PreferredCity NVARCHAR(60),
    ImportantInterests NVARCHAR(300),
    FOREIGN KEY (ClientProfileId) REFERENCES ClientProfiles(ClientProfileId)
);
GO

CREATE TABLE MatchRequests (
    RequestId INT PRIMARY KEY IDENTITY(1,1),
    ClientProfileId INT NOT NULL,
    EmployeeId INT NULL,
    Status NVARCHAR(40) NOT NULL DEFAULT N'Нова заявка',
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    Comment NVARCHAR(500),
    FOREIGN KEY (ClientProfileId) REFERENCES ClientProfiles(ClientProfileId),
    FOREIGN KEY (EmployeeId) REFERENCES Users(UserId)
);
GO

CREATE TABLE Matches (
    MatchId INT PRIMARY KEY IDENTITY(1,1),
    FirstClientId INT NOT NULL,
    SecondClientId INT NOT NULL,
    CompatibilityScore INT NOT NULL CHECK (CompatibilityScore BETWEEN 0 AND 100),
    Status NVARCHAR(40) NOT NULL DEFAULT N'Запропоновано',
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    FOREIGN KEY (FirstClientId) REFERENCES ClientProfiles(ClientProfileId),
    FOREIGN KEY (SecondClientId) REFERENCES ClientProfiles(ClientProfileId)
);
GO

CREATE TABLE Meetings (
    MeetingId INT PRIMARY KEY IDENTITY(1,1),
    MatchId INT NOT NULL,
    EmployeeId INT NULL,
    MeetingDate DATETIME2 NOT NULL,
    Format NVARCHAR(30) NOT NULL,
    Location NVARCHAR(120),
    Result NVARCHAR(50) NOT NULL DEFAULT N'Заплановано',
    Notes NVARCHAR(600),
    FOREIGN KEY (MatchId) REFERENCES Matches(MatchId),
    FOREIGN KEY (EmployeeId) REFERENCES Users(UserId)
);
GO

CREATE TABLE MatchArchive (
    ArchiveId INT PRIMARY KEY IDENTITY(1,1),
    MatchId INT NOT NULL,
    ArchivedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    ArchiveReason NVARCHAR(500) NOT NULL,
    FOREIGN KEY (MatchId) REFERENCES Matches(MatchId)
);
GO

INSERT INTO Roles (RoleName)
VALUES 
(N'Client'),
(N'Employee'),
(N'Administrator');
GO

INSERT INTO Users (FullName, Email, PasswordHash, RoleId, Phone)
VALUES
(N'Олена Постнікова', 'admin.olena@agency.local', 'admin2026', 3, '+380662440509'),
(N'Влад Ковальчук', 'manager.vlad@agency.local', 'manager2026', 2, '+380994319412'),
(N'Ольга Мелєщук', 'consultant.olga@agency.local', 'consult2026', 2, '+380986535883'),
(N'Софія Гришко', 'sofia.grishko@gmail.com', 'client01', 1, '+380663736640'),
(N'Максим Степанець', 'maksym.stepanec@gmail.com', 'client02', 1, '+380960989377'),
(N'Юля Ломова', 'yulia.lomova@gmail.com', 'client03', 1, '+380678896391'),
(N'Артем Арсельниковий', 'artem.arsen@gmail.com', 'client04', 1, '+380733174314'),
(N'Микита Барикін', 'mykyta.barykin@gmail.com', 'client05', 1, '+380977715218'),
(N'Ільдар Хабібулін', 'ildar.khabibulin@gmail.com', 'client06', 1, '+380991493812');
GO

INSERT INTO ClientProfiles 
(UserId, Gender, BirthDate, City, Height, Education, Occupation, Interests, AboutMe)
VALUES
(4, N'Жінка', '1999-09-15', N'Харків', 166, N'Вища', N'Дизайнерка', N'мистецтво, подорожі, фотографія', N'Ціную відкритість, спокійне спілкування та почуття гумору.'),
(5, N'Чоловік', '1995-09-22', N'Харків', 181, N'Середня', N'Тренер', N'спорт, музика', N'Шукаю людину для серйозних стосунків і спільного розвитку.'),
(6, N'Жінка', '2004-01-30', N'Київ', 164, N'Незакінчена вища', N'Маркетологиня', N'кіно, книги, психологія', N'Люблю живе спілкування, нові місця та людей із власною думкою.'),
(7, N'Чоловік', '1993-07-11', N'Львів', 188, N'Вища', N'Інженер', N'велосипед, кулінарія', N'Відповідальний, спокійний, люблю планувати майбутнє.'),
(8, N'Чоловік', '1997-12-05', N'Харків', 170, N'Вища', N'Вчитель', N'театр, мови', N'Важливі чесність, підтримка та повага до особистих меж.'),
(9, N'Чоловік', '2000-03-21', N'Київ', 179, N'Середня', N'Продавець', N'біг, документальні фільми', N'Цікавлюсь фільмами й хочу знайти партнерку зі схожими цінностями.');
GO

INSERT INTO PartnerPreferences
(ClientProfileId, PreferredGender, MinAge, MaxAge, PreferredCity, ImportantInterests)
VALUES
(1, N'Чоловік', 24, 34, N'Харків', N'спорт, подорожі або музика'),
(2, N'Жінка', 22, 30, N'Харків', N'мистецтво, фотографія або прогулянки'),
(3, N'Чоловік', 22, 32, NULL, N'кіно, книги, психологія'),
(4, N'Жінка', 24, 34, NULL, N'подорожі, кулінарія, активний відпочинок'),
(5, N'Жінка', 23, 33, N'Харків', N'театр, мови, спокійне дозвілля'),
(6, N'Жінка', 22, 31, N'Київ', N'спорт, фільми, прогулянки');
GO

INSERT INTO MatchRequests (ClientProfileId, EmployeeId, Status, Comment)
VALUES
(1, 2, N'В обробці', N'Клієнтка просить підібрати кандидата з Харкова.'),
(2, 2, N'В обробці', N'Перевага надається спокійному формату першої зустрічі.'),
(3, 3, N'Нова заявка', N'Можливий онлайн-формат знайомства.'),
(5, 3, N'Завершено', N'Запропоновано сумісного кандидата.');
GO

INSERT INTO Matches (FirstClientId, SecondClientId, CompatibilityScore, Status)
VALUES
(1, 2, 87, N'Очікує підтвердження'),
(3, 6, 73, N'Запропоновано'),
(5, 2, 81, N'Зустріч заплановано'),
(4, 6, 68, N'На розгляді');
GO

INSERT INTO Meetings (MatchId, EmployeeId, MeetingDate, Format, Location, Result, Notes)
VALUES
(1, 2, '2026-04-10 17:30', N'Офлайн', N'Кав’ярня на Сумській, Харків', N'Заплановано', N'Погодити час за день до зустрічі.'),
(2, 3, '2026-04-12 19:00', N'Онлайн', N'Google Meet', N'Заплановано', N'Посилання надсилає консультант.'),
(3, 2, '2026-04-15 16:00', N'Офлайн', N'Парк Шевченка, Харків', N'Заплановано', N'Клієнти обрали неформальну зустріч.');
GO

INSERT INTO MatchArchive (MatchId, ArchiveReason)
VALUES
(4, N'Пару перенесено до архіву через відсутність взаємної зацікавленості.');
GO