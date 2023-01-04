using Companions.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Data;

namespace Companions.API
{

    public static class DbInitializer
    {
        public static void InitializeDb(AppDbContext context)
        {
            List<FeedProduct> _feedProducts;
            List<ActivityType> _activityTypes;
            List<FeedBrand> _feedBrands;
            List<BuddyWeight> _buddyWeights;
            List<Buddy> _buddies;
            List<Activity> _activities;
            List<FeedingSchedule> _feedingSchedules;
            List<Appointment> _appointments;
            List<User> _users;
            List<Place> _places;

            if (context.Users.Any())
            {
                return;
            }

            _activityTypes = new List<ActivityType>() {
                new ActivityType { Name = "Walk" },
                new ActivityType { Name= "Feeding" }
            };

            context.ActivityTypes.AddRange(_activityTypes);
            context.SaveChanges();

            _feedBrands = new List<FeedBrand>()
            {
                new FeedBrand { Name = "Hill's"},
                new FeedBrand { Name = "Royal Canin"},
                new FeedBrand { Name = "Rocco"},
                new FeedBrand { Name = "Whiskas"}
            };

            context.FeedBrands.AddRange(_feedBrands);
            context.SaveChanges();

            _feedProducts = new List<FeedProduct>
            {
                new FeedProduct { BrandName = _feedBrands.First(b => b.Name == "Hill's"), Name = "Science Plan Adult No Grain Medium", ProductURL = "https://shop-cdn-m.mediazs.com/bilder/hills/science/plan/adult/no/grain/medium/met/kip/0/800/4_new_project_0.jpg" },
                new FeedProduct { BrandName = _feedBrands.First(b => b.Name == "Hill's"), Name = "Science Plan Adult Perfect Digestion", ProductURL = "https://shop-cdn-m.mediazs.com/bilder/hills/science/plan/adult/perfect/digestion/medium/breed/hondenvoer/1/800/thumbnail_18__1.jpg" },
                new FeedProduct { BrandName = _feedBrands.First(b => b.Name == "Hill's"), Name = "Science Plan Adult Healthy Mobility Small", ProductURL = "https://shop-cdn-m.mediazs.com/bilder/hills/science/plan/adult/healthy/mobility/small/mini/met/kip/hondenvoer/8/800/7_new_project_8.jpg" },
                new FeedProduct { BrandName = _feedBrands.First(b => b.Name == "Royal Canin"), Name = "Maxi Adult", ProductURL = "https://shop-cdn-m.mediazs.com/bilder/royal/canin/maxi/adult/hondenvoer/8/800/80729_pla_royalcanin_maxiadult_15kg_hs_01_8.jpg" },
                new FeedProduct { BrandName = _feedBrands.First(b => b.Name == "Rocco"), Name = "Classic", ProductURL = "https://shop-cdn-m.mediazs.com/bilder/rocco/classic/x/g/8/800/28021_pla_megapack_rocc_classic_rindpur_400g_hs_01_8.jpg" },
                new FeedProduct { BrandName = _feedBrands.First(b => b.Name == "Whiskas"), Name = "1+ Rund", ProductURL = "https://shop-cdn-m.mediazs.com/bilder/korting/whiskas/droogvoer/7/800/908518_7.jpg" },
            };

            context.FeedProducts.AddRange(_feedProducts);
            context.SaveChanges();

            _feedingSchedules = new List<FeedingSchedule>
            {
                new FeedingSchedule { Amount = 100, FeedProduct = _feedProducts[0], TimeOfDay = "Morning"},
                new FeedingSchedule { Amount = 100, FeedProduct = _feedProducts[0], TimeOfDay = "Evening"},

                new FeedingSchedule { Amount = 80, FeedProduct = _feedProducts[1], TimeOfDay = "Morning"},
                new FeedingSchedule { Amount = 80, FeedProduct = _feedProducts[1], TimeOfDay = "Evening"},

                new FeedingSchedule { Amount = 120, FeedProduct = _feedProducts[4], TimeOfDay = "Morning"},
                new FeedingSchedule { Amount = 800, FeedProduct = _feedProducts[5], TimeOfDay = "Evening"},
            };

            context.FeedingSchedules.AddRange(_feedingSchedules);
            context.SaveChanges();

            _activities = new List<Activity>
            {
                new Activity { ActivityType = _activityTypes.First(a => a.Name == "Walk"), StartDate = new DateTime(2022,11,01,08,15,00), EndDate = new DateTime(2022,11,01,09,31,00) },
                new Activity { ActivityType = _activityTypes.First(a => a.Name == "Feeding"), StartDate = new DateTime(2022,11,01,12,00,00), EndDate = new DateTime(2022,11,01,12,31,00) },
                new Activity { ActivityType = _activityTypes.First(a => a.Name == "Walk"), StartDate = new DateTime(2022,11,01,16,15,00), EndDate = new DateTime(2022,11,01,16,42,00) },
                new Activity { ActivityType = _activityTypes.First(a => a.Name == "Walk"), StartDate = new DateTime(2022,11,02,09,15,00), EndDate = new DateTime(2022,11,02,09,51,00) },
                new Activity { ActivityType = _activityTypes.First(a => a.Name == "Feeding"), StartDate = new DateTime(2022,11,02,13,15,00), EndDate = new DateTime(2022,11,02,14,03,00) },
                new Activity { ActivityType = _activityTypes.First(a => a.Name == "Walk"), StartDate = new DateTime(2022,11,02,16,15,00), EndDate = new DateTime(2022,11,02,17,02,00) },
                new Activity { ActivityType = _activityTypes.First(a => a.Name == "Walk"), StartDate = new DateTime(2022,11,02,20,15,00), EndDate = new DateTime(2022,11,02,21,01,00) },
                new Activity { ActivityType = _activityTypes.First(a => a.Name == "Feeding"), StartDate = new DateTime(2022,11,03,08,30,00), EndDate = new DateTime(2022,11,03,09,02,00) },
                new Activity { ActivityType = _activityTypes.First(a => a.Name == "Walk"), StartDate = new DateTime(2022,11,03,12,15,00), EndDate = new DateTime(2022,11,03,12,31,00) },
                new Activity { ActivityType = _activityTypes.First(a => a.Name == "Walk"), StartDate = new DateTime(2022,11,03,15,15,00), EndDate = new DateTime(2022,11,03,15,44,00) },
                new Activity { ActivityType = _activityTypes.First(a => a.Name == "Feeding"), StartDate = new DateTime(2022,11,03,20,15,00), EndDate = new DateTime(2022,11,03,20,41,00) },
                new Activity { ActivityType = _activityTypes.First(a => a.Name == "Walk"), StartDate = new DateTime(2022,11,03,23,15,00), EndDate = new DateTime(2022,11,03,23,34,00) },
            };

            context.Activities.AddRange(_activities);
            context.SaveChanges();

            _users = new List<User>()
            {
                new User { FirstName = "Wouter", LastName = "Vangeel", UserName = "admin", PasswordHash = "4jwzl+ml7TFb2tL7sDV5biYluCQ=", PasswordSalt = "EkhfFEzSfey9+jnp6jg=", Role = "admin" },
                new User { FirstName = "Test", LastName = "Account", UserName = "test", PasswordHash = "NkMp2QoHDJG+yJ7tFm6zQW4TQoI=", PasswordSalt = "ClfbpELGxImZtX6nhXE=", Role = "admin" }
            };


            context.Users.AddRange(_users);
            context.SaveChanges();

            var _bassieWeights = new List<BuddyWeight>()
            {
                new BuddyWeight { Weight = 10.2, DateWeighed = DateTime.Parse("2022-09-14") },
                new BuddyWeight { Weight = 10.1, DateWeighed = DateTime.Parse("2022-09-15") },
                new BuddyWeight { Weight = 10.2, DateWeighed = DateTime.Parse("2022-09-16") },
                new BuddyWeight { Weight = 10.3, DateWeighed = DateTime.Parse("2022-09-17") },
                new BuddyWeight { Weight = 10.4, DateWeighed = DateTime.Parse("2022-09-18") },
                new BuddyWeight { Weight = 10.6, DateWeighed = DateTime.Parse("2022-09-19") },
                new BuddyWeight { Weight = 10.4, DateWeighed = DateTime.Parse("2022-09-20") },
                new BuddyWeight { Weight = 10.0, DateWeighed = DateTime.Parse("2022-09-21") },
                new BuddyWeight { Weight = 10.1, DateWeighed = DateTime.Parse("2022-09-22") },
            };

            var _oriWeights = new List<BuddyWeight>()
            {
                new BuddyWeight { Weight = 7.2, DateWeighed = DateTime.Parse("2022-09-14") },
                new BuddyWeight { Weight = 7.1, DateWeighed = DateTime.Parse("2022-09-15") },
                new BuddyWeight { Weight = 7.2, DateWeighed = DateTime.Parse("2022-09-16") },
                new BuddyWeight { Weight = 7.3, DateWeighed = DateTime.Parse("2022-09-17") },
                new BuddyWeight { Weight = 7.4, DateWeighed = DateTime.Parse("2022-09-18") },
                new BuddyWeight { Weight = 7.6, DateWeighed = DateTime.Parse("2022-09-19") },
                new BuddyWeight { Weight = 7.4, DateWeighed = DateTime.Parse("2022-09-20") },
                new BuddyWeight { Weight = 7.0, DateWeighed = DateTime.Parse("2022-09-21") },
                new BuddyWeight { Weight = 7.1, DateWeighed = DateTime.Parse("2022-09-22") },
            };

            var _robotWeights = new List<BuddyWeight>()
            {
                new BuddyWeight { Weight = 4.2, DateWeighed = DateTime.Parse("2022-09-14") },
                new BuddyWeight { Weight = 4.1, DateWeighed = DateTime.Parse("2022-09-15") },
                new BuddyWeight { Weight = 4.2, DateWeighed = DateTime.Parse("2022-09-16") },
                new BuddyWeight { Weight = 4.3, DateWeighed = DateTime.Parse("2022-09-17") },
                new BuddyWeight { Weight = 4.4, DateWeighed = DateTime.Parse("2022-09-18") },
                new BuddyWeight { Weight = 4.6, DateWeighed = DateTime.Parse("2022-09-19") },
                new BuddyWeight { Weight = 4.4, DateWeighed = DateTime.Parse("2022-09-20") },
                new BuddyWeight { Weight = 4.0, DateWeighed = DateTime.Parse("2022-09-21") },
                new BuddyWeight { Weight = 4.1, DateWeighed = DateTime.Parse("2022-09-22") },
            };


            _buddies = new List<Buddy>()
            {
                new Buddy {
                    Name = "Bassie",
                    User = _users.First(u => u.UserName == "admin"),
                    DateOfBirth = DateTime.Parse("2015-09-14"),
                    Race = "Mixed",
                    Gender = "Male",
                    BuddyWeights = new List<BuddyWeight>(),
                    ImageURL = "https://i.imgur.com/GJe4t90.jpg",
                    Activities = new List<Activity>(),
                    FeedingSchedules = _feedingSchedules.GetRange(0, 3),
                },
                new Buddy {
                    Name = "Ori",
                    User = _users.First(u => u.UserName == "admin"),
                    DateOfBirth = DateTime.Parse("2016-09-14"),
                    Race = "Mixed",
                    BuddyWeights = new List<BuddyWeight>(),
                    Gender = "Male",
                    ImageURL="https://i.imgur.com/UUzY06O.png",
                    Activities = new List<Activity>(),
                    FeedingSchedules = _feedingSchedules.GetRange(1, 3)
                },
                new Buddy {
                    Name = "Robot",
                    User = _users.First(u => u.UserName == "admin"),
                    DateOfBirth = DateTime.Parse("2018-09-14"),
                    Race = "Tabby",
                    Gender = "Male",
                    BuddyWeights = new List<BuddyWeight>(),
                    ImageURL="https://i.imgur.com/Z0J26m6.png",
                    Activities = new List<Activity>(),
                    FeedingSchedules = _feedingSchedules.GetRange(2, 3)
                },
                new Buddy {
                    Name = "Test Buddy",
                    User = _users.First(u => u.UserName == "test"),
                    DateOfBirth = DateTime.Parse("2018-09-14"),
                    Race = "Awesome Colored Cat",
                    Gender = "Male",
                    BuddyWeights = new List<BuddyWeight>(),
                    ImageURL="https://i.imgur.com/Z0J26m6.png",
                    Activities = new List<Activity>(),
                    FeedingSchedules = _feedingSchedules.GetRange(1, 4)
                }
            };

            _buddies.First(b => b.Name == "Bassie").BuddyWeights.AddRange(_bassieWeights);
            _buddies.First(b => b.Name == "Ori").BuddyWeights.AddRange(_oriWeights);
            _buddies.First(b => b.Name == "Robot").BuddyWeights.AddRange(_robotWeights);

            _buddies.First(b => b.Name == "Bassie").Activities.AddRange(_activities.GetRange(0, _activities.Count));

            _buddies.First(b => b.Name == "Ori").Activities.AddRange(_activities.GetRange(0, _activities.Count));

            _buddies.First(b => b.Name == "Robot").Activities.AddRange(_activities.Where(x => x.ActivityType.Name == "Feeding").ToList());


            context.Buddies.AddRange(_buddies);
            context.SaveChanges();


            _places = new List<Place>
            {
                new Place { Name = "DAC Prinsenhof", Address = "Nieuwstraat 143, 3511 Hasselt", Latitude = 50.956659, Longitude = 5.328609, Description = "Dierenarts"},
                new Place { Name = "Ine's Trimpaleis", Address = "Nieuwstraat 51, 3520 Zonhoven", Latitude = 51.000720, Longitude = 5.339853, Description = "Kapper"}
            };

            context.Places.AddRange(_places);
            context.SaveChanges();

            _appointments = new List<Appointment>()
            {
                new Appointment {
                    Buddy =  _buddies.FirstOrDefault(b => b.Name == "Ori"),
                    AppointmentName = "CPV Vaccinatie",
                    AppointmentDate = new DateTime(2022,12,24,10,10,00),
                    Description = "Tweede herhalingsprik voor CPV. Nog één vaccinatiemoment vereist tot volledige immunisatie. Standaard checkup wordt ook uitgevoerd en voedingsschema wordt nagekeken. Gewichtsverlies zal gecheckt worden.",
                    Place = _places[0]
                },
                new Appointment {
                    AppointmentName = "Jaarlijkse checkup",
                    Buddy = _buddies.FirstOrDefault(b => b.Name == "Bassie"),
                    Description = "Routine checkup ter controle gewicht en voedings.",
                    AppointmentDate = new DateTime(2022,12,24,10,10,00),
                    Place = _places[0]
                },
                new Appointment {
                    AppointmentName = "Gewone afspraak",
                    Buddy = _buddies.FirstOrDefault(b => b.Name == "Ori"),
                    Description = "Routine checkup ter controle gewicht en voedings.",
                    AppointmentDate = new DateTime(2023,02,03,10,10,00),
                    Place = _places[0]
                },
                new Appointment {
                    AppointmentName = "Halfjaarlijkse checkup",
                    Buddy = _buddies.FirstOrDefault(b => b.Name == "Robot"),
                    Description = "Routine checkup ter controle gewicht en voedings.",
                    AppointmentDate = new DateTime(2023,02,03,10,10,00),
                    Place = _places[0]
                },
                new Appointment {
                    AppointmentName = "Kappersbezoek",
                    Buddy = _buddies.FirstOrDefault(b => b.Name == "Ori"),
                    Description = "Gewone kappersbezoek",
                    AppointmentDate = new DateTime(2023,01,04,10,10,00),
                    Place = _places[1]
                },
            };

            context.Appointments.AddRange(_appointments);
            context.SaveChanges();



            //var userRoles = new List<IdentityUserRole<string>>
            //{
            //    new IdentityUserRole<string>{ UserId = gebruikers[0].Id, RoleId = roles[1].Id },
            //    new IdentityUserRole<string>{ UserId = gebruikers[1].Id, RoleId = roles[0].Id },
            //    new IdentityUserRole<string>{ UserId = gebruikers[2].Id, RoleId = roles[0].Id },
            //    new IdentityUserRole<string>{ UserId = gebruikers[3].Id, RoleId = roles[0].Id },
            //    new IdentityUserRole<string>{ UserId = gebruikers[4].Id, RoleId = roles[0].Id },
            //    new IdentityUserRole<string>{ UserId = gebruikers[5].Id, RoleId = roles[0].Id },
            //    new IdentityUserRole<string>{ UserId = gebruikers[6].Id, RoleId = roles[0].Id },
            //    new IdentityUserRole<string>{ UserId = gebruikers[7].Id, RoleId = roles[0].Id },
            //    new IdentityUserRole<string>{ UserId = gebruikers[8].Id, RoleId = roles[0].Id },
            //    new IdentityUserRole<string>{ UserId = gebruikers[9].Id, RoleId = roles[2].Id },
            //    new IdentityUserRole<string>{ UserId = gebruikers[10].Id, RoleId = roles[2].Id },
            //    new IdentityUserRole<string>{ UserId = gebruikers[11].Id, RoleId = roles[2].Id },
            //    new IdentityUserRole<string>{ UserId = gebruikers[12].Id, RoleId = roles[2].Id },
            //    new IdentityUserRole<string>{ UserId = gebruikers[13].Id, RoleId = roles[0].Id },
            //    new IdentityUserRole<string>{ UserId = gebruikers[14].Id, RoleId = roles[1].Id },
            //};

            //context.UserRoles.AddRange(userRoles);
            //context.SaveChanges();

            //var vakken = new List<Vak>
            //{
            //    new Vak { Studiepunten= 5, VakNaam= "C# Web"},
            //    new Vak { Studiepunten= 4, VakNaam= "Web Advanced"},
            //    new Vak { Studiepunten= 6, VakNaam= "C# Advanced"},
            //    new Vak { Studiepunten= 2, VakNaam= "Data Essentials"},
            //    new Vak { Studiepunten= 3, VakNaam= "Data Advanced"},
            //    new Vak { Studiepunten= 4, VakNaam= "C# Mobile"},
            //    new Vak { Studiepunten= 5, VakNaam= "C# Essentials"},

            //};

            //context.Vakken.AddRange(vakken);
            //context.SaveChanges();

            //var academiejaren = new List<Academiejaar>
            //{
            //    new Academiejaar { Startdatum= DateTime.Parse("2013-09-14"), JarenGeformatteerd = "2013 - 2014"},
            //    new Academiejaar { Startdatum= DateTime.Parse("2014-09-14"), JarenGeformatteerd = "2014 - 2015"},
            //    new Academiejaar { Startdatum= DateTime.Parse("2015-09-14"), JarenGeformatteerd = "2015 - 2016"},
            //    new Academiejaar { Startdatum= DateTime.Parse("2016-09-14"), JarenGeformatteerd = "2016 - 2017"},
            //    new Academiejaar { Startdatum= DateTime.Parse("2017-09-14"), JarenGeformatteerd = "2017 - 2018"},
            //    new Academiejaar { Startdatum= DateTime.Parse("2018-09-14"), JarenGeformatteerd = "2018 - 2019"},
            //    new Academiejaar { Startdatum= DateTime.Parse("2019-09-14"), JarenGeformatteerd = "2019 - 2020"},
            //    new Academiejaar { Startdatum= DateTime.Parse("2020-09-14"), JarenGeformatteerd = "2020 - 2021"},
            //    new Academiejaar { Startdatum= DateTime.Parse("2021-09-14"), JarenGeformatteerd = "2021 - 2022"},
            //    new Academiejaar { Startdatum= DateTime.Parse("2022-09-14"), JarenGeformatteerd = "2022 - 2023"},

            //};

            //context.Academiejaren.AddRange(academiejaren);
            //context.SaveChanges();

            //var inschrijvingen = new List<Inschrijving>
            //{
            //    new Inschrijving {
            //        AcademiejaarId = 2,
            //        Vak = vakken.FirstOrDefault<Vak>(vak => vak.VakNaam == "C# Web"),
            //        Studenten = new List<Student>(),
            //        Vaklectors = new List<Vaklector>()
            //    },
            //    new Inschrijving {
            //        AcademiejaarId = 2,
            //        Vak = vakken.FirstOrDefault<Vak>(vak => vak.VakNaam == "Data Essentials"),
            //        Studenten = new List<Student>(),
            //        Vaklectors = new List<Vaklector>()
            //    },
            //    new Inschrijving {
            //        AcademiejaarId = 2,
            //        Vak = vakken.FirstOrDefault<Vak>(vak => vak.VakNaam == "C# Advanced"),
            //        Studenten = new List<Student>(),
            //        Vaklectors = new List<Vaklector>()
            //    },
            //    new Inschrijving {
            //        AcademiejaarId = 2,
            //        Vak = vakken.FirstOrDefault<Vak>(vak => vak.VakNaam == "Web Advanced"),
            //        Studenten = new List<Student>(),
            //        Vaklectors = new List<Vaklector>()
            //    },
            //    new Inschrijving {
            //        AcademiejaarId = 2,
            //        Vak = vakken.FirstOrDefault<Vak>(vak => vak.VakNaam == "C# Essentials"),
            //        Studenten = new List<Student>(),
            //        Vaklectors = new List<Vaklector>()
            //    }

            //};


            //context.Inschrijvingen.AddRange(inschrijvingen);
            //context.SaveChanges();

            //var studenten = new List<Student>
            //{
            //    new Student { GebruikerId = gebruikers[0].Id, Handboeken = new List<Handboek>(), Inschrijvingen = new List<Inschrijving>()},
            //    new Student { GebruikerId = gebruikers[1].Id, Handboeken = new List<Handboek>(), Inschrijvingen = new List<Inschrijving>()},
            //    new Student { GebruikerId = gebruikers[2].Id, Handboeken = new List<Handboek>(), Inschrijvingen = new List<Inschrijving>()},
            //    new Student { GebruikerId = gebruikers[3].Id, Handboeken = new List<Handboek>(), Inschrijvingen = new List<Inschrijving>()},
            //    new Student { GebruikerId = gebruikers[4].Id, Handboeken = new List<Handboek>(), Inschrijvingen = new List<Inschrijving>()},
            //    new Student { GebruikerId = gebruikers[5].Id, Handboeken = new List<Handboek>(), Inschrijvingen = new List<Inschrijving>()},
            //    new Student { GebruikerId = gebruikers[6].Id, Handboeken = new List<Handboek>(), Inschrijvingen = new List<Inschrijving>()},
            //    new Student { GebruikerId = gebruikers[7].Id, Handboeken = new List<Handboek>(), Inschrijvingen = new List<Inschrijving>()},
            //    new Student { GebruikerId = gebruikers[8].Id, Handboeken = new List<Handboek>(), Inschrijvingen = new List<Inschrijving>()},

            //};

            //// Voeg voor elke Student willekeurige inschrijving toe.
            //studenten.ForEach(student =>
            //{
            //    var rngInschrijvingen = new Random().Next(inschrijvingen.Count);
            //    for (int i = 0; i < rngInschrijvingen; i++)
            //    {
            //        student.Inschrijvingen.Add(inschrijvingen[i]);
            //    }
            //});

            //context.Studenten.AddRange(studenten);
            //context.SaveChanges();

            //var lectoren = new List<Lector>(){
            //    new Lector { Gebruiker = gebruikers.First<Gebruiker>(g => g.Voornaam == "Jeffry") },
            //    new Lector { Gebruiker = gebruikers.First<Gebruiker>(g => g.Voornaam == "Kristof") },
            //    new Lector { Gebruiker = gebruikers.First<Gebruiker>(g => g.Voornaam == "Paul") },
            //    new Lector { Gebruiker = gebruikers.First<Gebruiker>(g => g.Voornaam == "Patricia") }
            //};

            //context.Lectoren.AddRange(lectoren);
            //context.SaveChanges();

            //var vaklectoren = new List<Vaklector>()
            //{
            //    new Vaklector { LectorId = 1, Inschrijvingen = new List<Inschrijving>() },
            //    new Vaklector { LectorId = 2, Inschrijvingen = new List<Inschrijving>() },
            //    new Vaklector { LectorId = 3, Inschrijvingen = new List <Inschrijving >() },
            //    new Vaklector { LectorId = 4, Inschrijvingen = new List <Inschrijving >() }
            //};

            ////Web Advanced
            //vaklectoren[3].Inschrijvingen.Add(inschrijvingen[3]);
            ////C# Web
            //vaklectoren[2].Inschrijvingen.Add(inschrijvingen[0]);
            ////C# Advanced
            //vaklectoren[1].Inschrijvingen.Add(inschrijvingen[2]);
            ////C# Essentials
            //vaklectoren[1].Inschrijvingen.Add(inschrijvingen[4]);
            ////Data Essentials
            //vaklectoren[0].Inschrijvingen.Add(inschrijvingen[1]);

            //context.Vaklectoren.AddRange(vaklectoren);
            //context.SaveChanges();

            //var handboeken = new List<Handboek>()
            //{
            //    new Handboek {
            //        Kostprijs = 25,
            //        Studenten = new List<Student>(),
            //        Titel = "Pro ASP.NET Core 6",
            //        Vak = vakken.FirstOrDefault(vak => vak.VakNaam == "C# Web"),
            //        Afbeelding = "",
            //        UitgifteDatum = new DateTime(2021, 1, 5)
            //    },
            //    new Handboek {
            //        Kostprijs = 30,
            //        Studenten = new List<Student>(),
            //        Titel = "JavaScript voor gevorderden",
            //        Vak = vakken.FirstOrDefault(vak => vak.VakNaam == "Web Advanced"),
            //        Afbeelding = "",
            //        UitgifteDatum = new DateTime(2016,2, 5)
            //    },
            //    new Handboek {
            //        Kostprijs = 50,
            //        Studenten = new List<Student>(),
            //        Titel = "C# Programming Basics",
            //        Vak = vakken.FirstOrDefault(vak => vak.VakNaam == "C# Essentials"),
            //        Afbeelding = "",
            //        UitgifteDatum = new DateTime(2021, 1, 5)
            //    },
            //    new Handboek {
            //        Kostprijs = 40,
            //        Studenten = new List<Student>(),
            //        Titel = "C# 9.0 in a Nutshell",
            //        Vak = vakken.FirstOrDefault(vak => vak.VakNaam == "C# Advanced"),
            //        Afbeelding = "",
            //        UitgifteDatum = new DateTime(2021, 1, 5)
            //    },
            //    new Handboek {
            //        Kostprijs = 60,
            //        Studenten = new List<Student>(),
            //        Titel = "SQL Cookbook",
            //        Vak = vakken.FirstOrDefault(vak => vak.VakNaam == "Data Essentials"),
            //        Afbeelding = "",
            //        UitgifteDatum = new DateTime(2021, 1, 5)
            //    },
            //};

            ////Assign random students to Handboek

            //handboeken.ForEach(handboek =>
            //{
            //    var rngHandboek = new Random().Next(handboeken.Count);
            //    for (int i = 0; i < rngHandboek; i++)
            //    {
            //        handboek.Studenten.Add(studenten[i]);
            //    }
            //});

            //context.Handboeken.AddRange(handboeken);
            //context.SaveChanges();

            //vakken.FirstOrDefault(vak => vak.VakNaam == "C# Web").Handboeken.Add(handboeken[0]);
            //context.Vakken.UpdateRange(vakken);
            //context.SaveChanges();

        }
    }
}
