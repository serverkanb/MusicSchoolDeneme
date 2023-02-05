﻿using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Enum;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace MusicSchool.Areas.Database.Controllers
{
    [Area("DB")]
    public class HomeController : Controller
    {
        private readonly MusicSchoolContext _db;

        public HomeController(MusicSchoolContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {

            var students = _db.Students.ToList();
            _db.Students.RemoveRange(students);
            var teachers = _db.Teachers.ToList();
            _db.Teachers.RemoveRange(teachers);
            var classrooms = _db.Classrooms.ToList();
            _db.Classrooms.RemoveRange(classrooms);
            var lessons = _db.Lessons.ToList();
            _db.Lessons.RemoveRange(lessons);
            // var contacts = _db.Contacts.ToList();
            //_db.Contacts.RemoveRange(contacts);
            var instruments = _db.Instruments.ToList();
            _db.Instruments.RemoveRange(instruments);
            var users = _db.Users.ToList();
            _db.Users.RemoveRange(users);


            _db.Lessons.Add(new Lesson()
            {
                Name = "Guitar Online",
                IsOnline = true
            });
            _db.Lessons.Add(new Lesson()
            {
                Name = "Guitar",
                IsOnline = false
            });
            _db.Lessons.Add(new Lesson()
            {
                Name = "Piano Online",
                IsOnline = true
            });
            _db.Lessons.Add(new Lesson()
            {
                Name = "Piano",
                IsOnline = false
            });
            _db.Teachers.Add(new Teacher()
            {
                Name = "Mustafa",
                Surname = "Taş",
                Birthday = new DateTime(2000, 9, 9),
                RegistrationDate = new DateTime(2023, 2, 2),
                TeacherContact = new TeacherContact()
                {
                    Address = "hemen battık",
                    Email = "mustafa@mustafa",
                    Gender = Gender.Man,
                },
                Instrument = new Instrument()
                {
                    Name = "Violin",
                    UnitPrice = 450,
                    StockAmount = 18
                }
            });
            _db.Teachers.Add(new Teacher()
            {
                Name = "Berk",
                Surname = "Kocaman",
                Birthday=new DateTime(2000,10,10),
                RegistrationDate=new DateTime(2023,2,2),
                TeacherContact= new TeacherContact()
                {
                    Address="hemen attık",
                    Email="berk@berk",
                    Gender=Gender.Man,
                },
                Instrument = new Instrument()
                {
                    Name = "Flute",
                    UnitPrice = 25,
                    StockAmount = 12
                }
            });

            _db.Students.Add(new Student()
            {
                Name = "Ali",
                Surname = "Kaya",
                Birthday = new DateTime(2001, 1, 27),
                Gender = Gender.Man,
                ParentName = "Murat",
                ParentSurname = "Kaya",
                StudentContact=new StudentContact()
                {
                    Address="Hemen burada",
                    Email="Ali@ali"
                }
            });
            _db.Students.Add(new Student()
            {
                Name = "Veli",
                Surname = "Konya",
                Birthday = new DateTime(2001, 12, 20),
                Gender = Gender.Man,
                ParentName = "Aybegüm",
                ParentSurname = "Konya",
                StudentContact = new StudentContact()
                {
                    Address = "Hemen orada",
                    Email = "veli@veli"
                }
            });
            _db.Students.Add(new Student()
            {
                Name = "Ebruli",
                Surname = "Osmanlı",
                Birthday = new DateTime(2001, 12, 20),
                Gender = Gender.Woman,
                ParentName = "Murtaza",
                ParentSurname = "Osmanlı",
                StudentContact = new StudentContact()
                {
                    Address = "Hemen şurada",
                    Email = "ebruli@ebruli"
                }
            });
            _db.Students.Add(new Student()
            {
                Name = "Ayşe",
                Surname = "Kulin",
                Birthday = new DateTime(2001, 12, 20),
                Gender = Gender.Woman,
                ParentName = "Kubilay",
                ParentSurname = "Kulin",
                StudentContact = new StudentContact()
                {
                    Address = "Hemen biyerde işte",
                    Email = "ayse@ayse"
                }
            });
            _db.Instruments.Add(new Instrument()
            {
                Name = "Guitar",
                StockAmount = 20,
                UnitPrice = 1350,
                

            });
            _db.Instruments.Add(new Instrument()
            {
                Name = "Piano",
                StockAmount = 10,
                UnitPrice = 4500

            });
            _db.Instruments.Add(new Instrument()
            {
                Name = "Harmonica",
                StockAmount = 20,
                UnitPrice = 750

            });
			_db.Classrooms.Add(new Classroom()
			{
				Name = "Beethoven",
				
			});
			_db.Classrooms.Add(new Classroom()
			{
				Name = "Mozart",

			});
			_db.Classrooms.Add(new Classroom()
			{
				Name = "Bach",

			});
			_db.Classrooms.Add(new Classroom()
			{
				Name = "Haydn",

			});
			_db.Classrooms.Add(new Classroom()
			{
				Name = "Vivaldi",

			});
			_db.Roles.Add(new Role()
            {
                Name = "Admin",
                Users = new List<User>()
                    {
                        new User()
                        {
                            IsActive=true,
                            Password="Server",
                            UserName="Server"
                        },
                        new User()
                        {
                            IsActive=true,
                            Password="Sukru",
                            UserName="Sukru"
                        },
                         new User()
                        {
                            IsActive=true,
                            Password="Ozi",
                            UserName="Ozi"
                        }
                    }


            });
            _db.Roles.Add(new Role()
            {
                Name = "User",
                Users = new List<User>()
                    {
                        new User()
                        {
                            IsActive=true,
                            Password="leo",
                            UserName="leo"
                        },
                         new User()
                        {
                            IsActive=true,
                            Password="luna",
                            UserName="luna"
                        },
                           new User()
                        {
                            IsActive=true,
                            Password="yumak",
                            UserName="yumak"
                        }
                    }

            });

            _db.SaveChanges();
            return Content("<laber style=\"color:red;\"><b>Database seed succesfully.</b></label>", "text/html", Encoding.UTF8);
        }
    }
}
