using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Translate_Data_Into_Bulgarian : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "468c33a6-8a2d-42cd-8d3b-366f23d91cd8", "Иван", "Иванов", "AQAAAAIAAYagAAAAENymRjqMWuNrHu5SNcAYua8lApAEFITgCXdH6sIhWV3KOeWH6sS2XB8TFlm4YhLZsQ==", "e67ebc9a-426c-4c6e-8bd6-133e721c897c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a135434-74a7-48fe-a730-13b74d5cc114", "Петър", "Петров", "AQAAAAIAAYagAAAAEH96Y/ip3SFXdSfOUIWvZU7sZ0vYMn/YxeLoyHNAFj1IYuqBYfm3IfsuT9mkybpGWg==", "a9667e8b-a948-4e63-b37d-7ef0a5814d1d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5edb4f3-8491-4136-84fb-4ec706db7905", "Михаил", "Петров", "AQAAAAIAAYagAAAAEGH12xkZarHZShki46hN30S6TgHmjBrkKwOKON4G4C9yOL6tS08uoMN5xBl5yzlP6Q==", "aefdf89f-242d-4b53-a1ad-5d082fbb6b3b" });

            migrationBuilder.UpdateData(
                table: "CVs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Citizenship", "FirstName", "Gender", "Languages", "LastName", "Skills" },
                values: new object[] { "Сливен, България, Европа", "Българско", "Михаил", "Мъж", "Български C2, Немски B1, Английски B1", "Петров", "Математика, Програмиране, История, Тенис на маса, Футбол" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Софтуерно инженерство");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Медицина");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Мениджмънт");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "Маркетинг" },
                    { 5, "Образование" },
                    { 6, "Финанси" },
                    { 7, "Графичен дизайн" },
                    { 8, "Строителство" },
                    { 9, "Търговия на дребно" },
                    { 10, "Логистика" },
                    { 11, "Хотелиерство и туризъм" },
                    { 12, "Право" },
                    { 13, "Производство" }
                });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Country", "Description", "Name" },
                values: new object[] { "Редмънд, Вашингтон, САЩ", "САЩ", "Майкрософт е глобална технологична компания, позната заради софтуера и хардуера, който произвеждат.", "Майкрософт" });

            migrationBuilder.UpdateData(
                table: "Conferences",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "End", "Start", "Topic" },
                values: new object[] { "На тази конференция ще си говорим как да си намерим лесно работа и дали е толкова трудно.", new DateTime(2025, 2, 21, 16, 59, 57, 643, DateTimeKind.Utc).AddTicks(6797), new DateTime(2025, 2, 21, 14, 59, 57, 643, DateTimeKind.Utc).AddTicks(6797), "Как да си намерим работа? Наистина ли е толкова трудно?" });

            migrationBuilder.UpdateData(
                table: "Degrees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "City", "Description", "EducationLevel", "EducationalInstitution", "Major" },
                values: new object[] { "Сливен", "Тук научих много нови неща", "средно", "ППМГ \"Добри Чинтулов\"", "Математика и Информатика" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2025, 2, 21, 14, 59, 57, 133, DateTimeKind.Utc).AddTicks(8873));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "CreatedOn", "Description", "RequiredDegree", "RequiredLanguage", "RequiredSkills", "Title" },
                values: new object[] { "Редмънд, Вашингтон, САЩ", new DateTime(2025, 2, 21, 14, 59, 57, 7, DateTimeKind.Utc).AddTicks(1224), "C# junior програмистът трябва да знае ООП, Design Patterns, .NET, дебъгване и SQL.", "Висше образование", "Аниглийски C2", "ООП, SQL, .NET, Design Patterns, Структури от данни и алгоритми", "Junior C# програмист" });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "CreatedOn", "Description", "RequiredDegree", "RequiredLanguage", "RequiredSkills", "Title" },
                values: new object[] { "Редмънд, Вашингтон, САЩ", new DateTime(2025, 2, 21, 14, 59, 57, 7, DateTimeKind.Utc).AddTicks(1231), "C# Senior програмистът трябва да има отлични знания в .NET, архитектура на приложенията, оптимизация на код.", "Висше образование", "Английски C2", "ООП, SQL, .NET, архитектура, оптимизация на код", "Senior C# програмист" });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "CreatedOn", "Description", "RequiredDegree", "RequiredExperience", "RequiredLanguage", "RequiredSkills", "Title" },
                values: new object[] { "Редмънд, Вашингтон, САЩ", new DateTime(2025, 2, 21, 14, 59, 57, 7, DateTimeKind.Utc).AddTicks(1233), "Търси се динамичен мениджър в Майкрософт, който да ръководи екипи и да стимулира иновации.", "Висше образование", "10 години", "Английски C2", "Управление на проекти, Добра комуникация, Лидерство, Решаване на проблеми", "Търси се мениджър за ръководене на Майкрософт" });

            migrationBuilder.UpdateData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Стажантска работа");

            migrationBuilder.UpdateData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Работа на пълен работен ден");

            migrationBuilder.UpdateData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Работа на непълен работен ден");

            migrationBuilder.UpdateData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Временна работа");

            migrationBuilder.UpdateData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Сезонна работа");

            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Лектор с дългогодишен опит в сферата, един от най-добрите в работата си. Може да ви научи на много неща.");

            migrationBuilder.UpdateData(
                table: "ProfessionalExperiences",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "City", "CompanyName", "Description" },
                values: new object[] { "София", "Софтуни", "Тук работих много и научих много нови неща" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Чат стая");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48319e88-ca78-47a1-8a8d-a4bcf6be23e2", "Guest", "Guestov", "AQAAAAIAAYagAAAAEENxnLikkAR8ilb5DFyqNt5jb5HrsRKTQD4sDFSAznB3QYlFY27UOGZVZ/ALYk9Cig==", "a094396d-c76b-4ee5-b323-dd2df6b185e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b15ce96-c599-4b25-949b-d694ad172bf9", "Owner", "Ownerov", "AQAAAAIAAYagAAAAEAx2CWome7O5zgARQ9GdD1IWnXa8lBywyvAaJlxQF5hQ493ocB1YU27xXVLQPMgVGA==", "6a63a5b9-6134-4454-825a-ca56e8d58895" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b06cc072-bd0f-4c29-8522-f6ceba448e9f", "Admin", "Adminov", "AQAAAAIAAYagAAAAEPIlhZ7XGyxXn1Xg/xViT9ObJJJdU2uzBqJVGEBoJOjlrgm77fxogvETL8E17kh+OA==", "3eb1d5a7-761c-4ba1-8187-1e9d1f15150e" });

            migrationBuilder.UpdateData(
                table: "CVs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Citizenship", "FirstName", "Gender", "Languages", "LastName", "Skills" },
                values: new object[] { "Somewhere in Bulgaria, Europe", "Bulgarian", "Mihail", "Male", "Bulgarian C2, German B1, English B1", "Petrov", "Math, Programming, History, Table Tennis, Football" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Software Engineering");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Health Care");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Management");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Country", "Description", "Name" },
                values: new object[] { "Redmond, Washington, USA", "USA", "Microsoft is a global technology company known for software and hardware.", "Microsoft" });

            migrationBuilder.UpdateData(
                table: "Conferences",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "End", "Start", "Topic" },
                values: new object[] { "In this conference we will talk about that, how to find easy work and is it that hard.", new DateTime(2024, 12, 11, 21, 34, 50, 250, DateTimeKind.Utc).AddTicks(712), new DateTime(2024, 12, 11, 19, 34, 50, 250, DateTimeKind.Utc).AddTicks(710), "How to find easy Job? Is it really hard?" });

            migrationBuilder.UpdateData(
                table: "Degrees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "City", "Description", "EducationLevel", "EducationalInstitution", "Major" },
                values: new object[] { "secondary", "I learned a lot of here", "secondary", "PPMG \"Dobri Chintulov\"", "Math and Informatik" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 12, 11, 19, 34, 49, 719, DateTimeKind.Utc).AddTicks(6340));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "CreatedOn", "Description", "RequiredDegree", "RequiredLanguage", "RequiredSkills", "Title" },
                values: new object[] { "Redmond, Washington, USA", new DateTime(2024, 12, 11, 19, 34, 49, 579, DateTimeKind.Utc).AddTicks(4509), "A C# junior programmer should know OOP, Design Patterns, .NET, debugging and SQL.", "Higher Education", "English C2", "OOP, SQL, .NET, Design Patterns, Data Structures and Algorithms", "Junior C# Programmer" });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "CreatedOn", "Description", "RequiredDegree", "RequiredLanguage", "RequiredSkills", "Title" },
                values: new object[] { "Reading, Thames Valley Park, UK", new DateTime(2024, 12, 11, 19, 34, 49, 579, DateTimeKind.Utc).AddTicks(4516), "C# Senior Developer must have excellent knowledge of .NET, architecture, code optimization.", "Higher Education", "English C2", "OOP, SQL, .NET, Architecture, Code Optimization", "Senior C# Programmer" });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "CreatedOn", "Description", "RequiredDegree", "RequiredExperience", "RequiredLanguage", "RequiredSkills", "Title" },
                values: new object[] { "Reading, Thames Valley Park, UK", new DateTime(2024, 12, 11, 19, 34, 49, 579, DateTimeKind.Utc).AddTicks(4519), "Dynamic manager needed at Microsoft to lead teams and drive innovation.", "Higher Education", "10 years", "English C2", " Project Management, Strong Communication, Leadership, Problem-Solving", "Looking for a manager to lead Microsoft" });

            migrationBuilder.UpdateData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Internship Job");

            migrationBuilder.UpdateData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Full Time Job");

            migrationBuilder.UpdateData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Part Time Job");

            migrationBuilder.UpdateData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Temporary Job");

            migrationBuilder.UpdateData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Seasonal Job");

            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Very good lecturer. He has experience of 15 years, one of the best.");

            migrationBuilder.UpdateData(
                table: "ProfessionalExperiences",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "City", "CompanyName", "Description" },
                values: new object[] { "Sofia", "Softuni", "Ï worked a lot of there" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Chat Room");
        }
    }
}
