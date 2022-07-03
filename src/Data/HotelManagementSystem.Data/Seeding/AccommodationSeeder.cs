namespace HotelManagementSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using HotelManagementSystem.Data.Models;

    public class AccommodationSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Accommodations.Any())
            {
                return;
            }

            var doubleCoach = dbContext.BedTypes.First(x => x.Name == "Double coach").Id;
            var doubleBed = dbContext.BedTypes.First(x => x.Name == "Double bed").Id;
            var singleBed = dbContext.BedTypes.First(x => x.Name == "Single bed").Id;
            var singleCoach = dbContext.BedTypes.First(x => x.Name == "Single coach").Id;

            var accommodations = new List<Accommodation>();

            var single = new Accommodation
            {
                Name = "Single room",
                ImageName = "single.jpg",
                Count = 5,
                AdditionalPrice = 10,
                Description = "A room assigned to one person.",
            };
            await dbContext.AccommodationBedTypes.AddAsync(new AccommodationBedType { AccommodationId = single.Id, BedTypeId = singleBed });
            accommodations.Add(single);

            var @double = new Accommodation
            {
                Name = "Double room",
                ImageName = "double.jpg",
                Count = 5,
                AdditionalPrice = 15,
                Description = "A room assigned to two people.",
            };
            await dbContext.AccommodationBedTypes.AddAsync(new AccommodationBedType { AccommodationId = @double.Id, BedTypeId = doubleBed });
            accommodations.Add(@double);

            var singleQuad = new Accommodation
            {
                Name = "Single-Quad room",
                ImageName = "quad.jpg",
                Count = 5,
                AdditionalPrice = 10,
                Description = "A room assigned to four people - all beds separated.",
            };
            await dbContext.AccommodationBedTypes.AddAsync(new AccommodationBedType { AccommodationId = singleQuad.Id, BedTypeId = singleBed });
            await dbContext.AccommodationBedTypes.AddAsync(new AccommodationBedType { AccommodationId = singleQuad.Id, BedTypeId = singleBed });
            await dbContext.AccommodationBedTypes.AddAsync(new AccommodationBedType { AccommodationId = singleQuad.Id, BedTypeId = singleBed });
            await dbContext.AccommodationBedTypes.AddAsync(new AccommodationBedType { AccommodationId = singleQuad.Id, BedTypeId = singleBed });
            accommodations.Add(singleQuad);

            var quad = new Accommodation
            {
                Name = "Quad room",
                ImageName = "quad-doubles.jpg",
                Count = 5,
                AdditionalPrice = 15,
                Description = "A room assigned to four people - double beds.",
            };
            await dbContext.AccommodationBedTypes.AddAsync(new AccommodationBedType { AccommodationId = quad.Id, BedTypeId = doubleBed });
            await dbContext.AccommodationBedTypes.AddAsync(new AccommodationBedType { AccommodationId = quad.Id, BedTypeId = doubleBed });
            accommodations.Add(quad);

            var singleTriple = new Accommodation
            {
                Name = "Single-Triple room",
                ImageName = "triple.jpg",
                Count = 5,
                AdditionalPrice = 10,
                Description = "A room assigned to three people - all beds separated.",
            };
            await dbContext.AccommodationBedTypes.AddAsync(new AccommodationBedType { AccommodationId = singleTriple.Id, BedTypeId = singleBed });
            await dbContext.AccommodationBedTypes.AddAsync(new AccommodationBedType { AccommodationId = singleTriple.Id, BedTypeId = singleBed });
            await dbContext.AccommodationBedTypes.AddAsync(new AccommodationBedType { AccommodationId = singleTriple.Id, BedTypeId = singleBed });
            accommodations.Add(singleTriple);

            var triple = new Accommodation
            {
                Name = "Triple room",
                ImageName = "tripple-one-with-doubles.jpg",
                Count = 5,
                AdditionalPrice = 18,
                Description = "A room assigned to three people - one double and one single bed.",
            };
            await dbContext.AccommodationBedTypes.AddAsync(new AccommodationBedType { AccommodationId = triple.Id, BedTypeId = singleBed });
            await dbContext.AccommodationBedTypes.AddAsync(new AccommodationBedType { AccommodationId = triple.Id, BedTypeId = doubleBed });
            accommodations.Add(triple);

            var queen = new Accommodation
            {
                Name = "Queen room",
                ImageName = "queen.jpg",
                Count = 5,
                AdditionalPrice = 30,
                Description = "A room with a queen-sized bed.",
            };
            await dbContext.AccommodationBedTypes.AddAsync(new AccommodationBedType { AccommodationId = queen.Id, BedTypeId = singleBed });
            accommodations.Add(queen);

            var king = new Accommodation
            {
                Name = "King room",
                ImageName = "king.jpg",
                Count = 5,
                AdditionalPrice = 30,
                Description = "A room with a king-sized bed.",
            };
            await dbContext.AccommodationBedTypes.AddAsync(new AccommodationBedType { AccommodationId = king.Id, BedTypeId = singleBed });
            accommodations.Add(king);

            var apartment = new Accommodation
            {
                Name = "Apartment",
                ImageName = "apartment.jpg",
                Count = 5,
                AdditionalPrice = 50,
                Description = "This room type can be found in service apartments and hotels which target for long stay guests.",
            };
            await dbContext.AccommodationBedTypes.AddAsync(new AccommodationBedType { AccommodationId = apartment.Id, BedTypeId = doubleBed });
            await dbContext.AccommodationBedTypes.AddAsync(new AccommodationBedType { AccommodationId = apartment.Id, BedTypeId = singleBed });
            await dbContext.AccommodationBedTypes.AddAsync(new AccommodationBedType { AccommodationId = apartment.Id, BedTypeId = doubleCoach });
            accommodations.Add(apartment);

            var studio = new Accommodation
            {
                Name = "Studio",
                ImageName = "studio.jpeg",
                Count = 5,
                AdditionalPrice = 12,
                Description = "A room with a studio bed- a couch which can be converted into a bed.",
            };
            await dbContext.AccommodationBedTypes.AddAsync(new AccommodationBedType { AccommodationId = studio.Id, BedTypeId = singleBed });
            await dbContext.AccommodationBedTypes.AddAsync(new AccommodationBedType { AccommodationId = studio.Id, BedTypeId = singleCoach });
            accommodations.Add(studio);

            var president = new Accommodation
            {
                Name = "President Suite",
                ImageName = "president.jpg",
                Count = 1,
                AdditionalPrice = 150,
                Description = "The most expensive room provided by a hotel.",
            };
            await dbContext.AccommodationBedTypes.AddAsync(new AccommodationBedType { AccommodationId = president.Id, BedTypeId = doubleBed });
            await dbContext.AccommodationBedTypes.AddAsync(new AccommodationBedType { AccommodationId = president.Id, BedTypeId = doubleCoach });
            accommodations.Add(president);

            await dbContext.AddRangeAsync(accommodations);
        }
    }
}
