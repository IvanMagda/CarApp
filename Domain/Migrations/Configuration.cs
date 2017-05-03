namespace Domain.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Model;

    internal sealed class Configuration : DbMigrationsConfiguration<Domain.EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EFDbContext context)
        {
            var cars = new List<Car>
            {
            new Car{Model="750XDRIVE", Brand="BMW", CarType=CarType.Passenger, Price=46900, ProductionYear=2011, Owners = new List<Owner>()},
            new Car{Model="Berlingo", Brand="Citroen", CarType=CarType.Cargo, Price=16240, ProductionYear=2015, Owners = new List<Owner>()},
            new Car{Model="Sorento", Brand="Kia", CarType=CarType.Passenger, Price=38424, ProductionYear=2015, Owners = new List<Owner>()},
            new Car{Model="LX 570", Brand="Lexus", CarType=CarType.Passenger, Price=84103, ProductionYear=2014, Owners = new List<Owner>()},
            new Car{Model="Ducato", Brand="Fiat", CarType=CarType.Cargo, Price=6500, ProductionYear=1999, Owners = new List<Owner>()},
            new Car{Model="L 2000", Brand="MAN", CarType=CarType.Cargo, Price=16500, ProductionYear=2000, Owners = new List<Owner>()},
            new Car{Model="Q3MTM", Brand="Audi", CarType=CarType.Passenger, Price=37500, ProductionYear=2012, Owners = new List<Owner>()},
            new Car{Model="Midliner", Brand="Renault", CarType=CarType.Cargo, Price=5900, ProductionYear=1999, Owners = new List<Owner>()},
            new Car{Model="Q7", Brand="Audi", CarType=CarType.Passenger, Price=81000, ProductionYear=2015, Owners = new List<Owner>()},
            new Car{Model="Fabia", Brand="Skoda", CarType=CarType.Passenger, Price=19696, ProductionYear=2015, Owners = new List<Owner>()},
            new Car{Model="FH", Brand="Volvo", CarType=CarType.Cargo, Price=10000, ProductionYear=1996, Owners = new List<Owner>()},
            new Car{Model="Major", Brand="Renault", CarType=CarType.Passenger, Price=8500, ProductionYear=1995, Owners = new List<Owner>()}
            };

            var owners = new List<Owner>
            {
            new Owner{FirstName="Carson",LastName="Alexander",DrivingExperience=3, Cars = new List<Car>()},
            new Owner{FirstName="Meredith",LastName="Alonso",DrivingExperience=5, Cars = new List<Car>()},
            new Owner{FirstName="Arturo",LastName="Anand",DrivingExperience=2, Cars = new List<Car>()},
            new Owner{FirstName="Gytis",LastName="Barzdukas",DrivingExperience=8, Cars = new List<Car>()},
            new Owner{FirstName="Yan",LastName="Li",DrivingExperience=1, Cars = new List<Car>()},
            new Owner{FirstName="Peggy",LastName="Justice",DrivingExperience=2, Cars = new List<Car>()},
            new Owner{FirstName="Laura",LastName="Norman",DrivingExperience=9, Cars = new List<Car>()},
            new Owner{FirstName="Nino",LastName="Olivetto",DrivingExperience=12, Cars = new List<Car>()}
            };

            cars[0].Owners.Add(owners[0]);
            cars[0].Owners.Add(owners[1]);
            cars[0].Owners.Add(owners[2]);
            cars[1].Owners.Add(owners[3]);
            cars[1].Owners.Add(owners[4]);
            cars[1].Owners.Add(owners[5]);
            cars[2].Owners.Add(owners[6]);
            cars[3].Owners.Add(owners[7]);
            cars[3].Owners.Add(owners[0]);
            cars[4].Owners.Add(owners[1]);
            cars[5].Owners.Add(owners[2]);
            cars[6].Owners.Add(owners[3]);
            cars[6].Owners.Add(owners[4]);
            cars[7].Owners.Add(owners[5]);
            cars[7].Owners.Add(owners[6]);
            cars[8].Owners.Add(owners[7]);
            cars[9].Owners.Add(owners[0]);
            cars[10].Owners.Add(owners[1]);
            cars[11].Owners.Add(owners[2]);

            cars.ForEach(c => context.Cars.Add(c));
            owners.ForEach(o => context.Owners.Add(o));
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
