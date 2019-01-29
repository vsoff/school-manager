using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDatabaseCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            Log("Эта программа предназначена для инициализации таблиц для `SportSchoolDesktopApp`");
            Console.WriteLine();
            Log("Нажмите `Enter` чтобы продолжить...");

            var connStrPattern = "data source={0};initial catalog={1};integrated security={2};User ID={3};Password={4};";

            Log("Введите `Data Source`...");
            string datasource = Console.ReadLine();
            Log("Введите название Базы данных...");
            string database = Console.ReadLine();
            Log("Введите `User Id` или просто нажмите Enter, если БД использует Windows-аунтефикацию");
            string userid = Console.ReadLine();
            Log("Введите `Password` или просто нажмите Enter, если БД использует Windows-аунтефикацию");
            string pass = Console.ReadLine();

            var conStr = string.Format(connStrPattern, datasource, database, userid == "", userid, pass);

            try
            {
                using (SqlConnection sq = new SqlConnection(conStr))
                {
                    sq.Open();
                    try
                    {
                        List<SqlCommand> scs = new List<SqlCommand> {
                        new SqlCommand("CREATE TABLE  [dbo].[Trainers]([TrainerId] INT NOT NULL PRIMARY KEY IDENTITY,     [FirstName] VARCHAR(30) NOT NULL,     [LastName] VARCHAR(30) NOT NULL,     [MiddleName] VARCHAR(30) NULL )",sq),
                        new SqlCommand("CREATE TABLE  [dbo].[Groups]([GroupId] INT NOT NULL PRIMARY KEY IDENTITY,     [Name] VARCHAR(30) NOT NULL,     [Description] TEXT NULL,     [TrainerId] INT NOT NULL,CONSTRAINT [FK_Groups_Trainers] FOREIGN KEY ([TrainerId]) REFERENCES [Trainers]([TrainerId]),)",sq),
                        new SqlCommand("CREATE TABLE  [dbo].[Sessions]([SessionId] INT NOT NULL PRIMARY KEY IDENTITY,     [GroupId] INT NOT NULL,     [Time] TIME NOT NULL,     [Date] DATE NOT NULL,    CONSTRAINT [FK_Sessions_Groups] FOREIGN KEY ([GroupId]) REFERENCES [Groups]([GroupId]),)",sq),
                        new SqlCommand("CREATE TABLE  [dbo].[Students]([StudentId] INT NOT NULL PRIMARY KEY IDENTITY,     [FirstName] VARCHAR(30) NOT NULL,     [LastName] VARCHAR(30) NOT NULL,     [MiddleName] VARCHAR(30) NULL,     [Birdth] SMALLDATETIME NULL,     [Phone] VARCHAR(15) NULL, )",sq),
                        new SqlCommand("CREATE TABLE  [dbo].[Schedule]([Id] INT NOT NULL PRIMARY KEY IDENTITY,     [Days] VARCHAR(7) NOT NULL,     [TimeStart] INT NOT NULL,     [Hall] INT NOT NULL,     [IsPeriodic] BIT NOT NULL,     [GroupId] INT NOT NULL,     CONSTRAINT [FK_Schedule_Groups] FOREIGN KEY ([GroupId]) REFERENCES [Groups]([GroupId]),)",sq),
                        new SqlCommand("CREATE TABLE  [dbo].[StudentsInSessions]([Id] INT NOT NULL PRIMARY KEY IDENTITY,     [StudentId] INT NOT NULL,     [SessionId] INT NOT NULL,    CONSTRAINT [FK_StudentsInSessions_Students] FOREIGN KEY ([StudentId]) REFERENCES [Students]([StudentId]),    CONSTRAINT [FK_StudentsInSessions_Sessions] FOREIGN KEY ([SessionId]) REFERENCES [Sessions]([SessionId]),)",sq),
                        new SqlCommand("CREATE TABLE  [dbo].[Subscriptions]([SubscriptionId] INT NOT NULL PRIMARY KEY IDENTITY,     [StudentId] INT NOT NULL,     [GroupId] INT NOT NULL,     [BuyTime] SMALLDATETIME NOT NULL,     [IsUnlimited] BIT NOT NULL,     [DateStart] DATE NOT NULL,     [DateEnd] DATE NOT NULL,     [SubHoursMax] INT NULL,     [SubHoursLeft] INT NOT NULL,     CONSTRAINT [FK_Subscriptions_Students] FOREIGN KEY ([StudentId]) REFERENCES [Students]([StudentId]),    CONSTRAINT [FK_Subscriptions_Groups] FOREIGN KEY ([GroupId]) REFERENCES [Groups]([GroupId]))",sq),

                        };
                        foreach (var sc in scs)
                            sc.ExecuteNonQuery();
                        Log("Всё прошло успешно!");
                    }
                    catch (Exception ex)
                    {
                        Bug("Произошла ошибка при создании таблиц. Подробности: " + ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Bug("Неудалось подключиться к базе данных. Подробности: " + ex);
            }

            Log("Нажмите Enter, чтобы завершить программу...");
            Console.ReadLine();
        }

        static void Log(string msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void Bug(string msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}