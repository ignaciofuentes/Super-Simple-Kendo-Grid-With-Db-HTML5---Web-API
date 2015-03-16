using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TelerikMvcApp4.Controllers
{

    public class CarsController : ApiController
    {

        CarsDbContext db;
        public CarsController()
        {
            db = new CarsDbContext();
        }

        public IEnumerable<CarViewModel> Get()
        {


            return (from c in db.Cars
                    select new CarViewModel
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Brand = c.Brand,
                        Type = c.Type
                    });
        }

        public CarViewModel Post(CarViewModel car)
        {
            if (car != null && ModelState.IsValid)
            {
                var newCar = new Car { Name = car.Name, Brand = car.Brand, Type = car.Type };
                db.Cars.Add(newCar);
                db.SaveChanges();
                car.Id = newCar.Id;
            }
            return car;
        }
        public void Put(int id, [FromBody]CarViewModel car)
        {

            if (car != null && ModelState.IsValid)
            {
                var dbCar = db.Cars.Where(c => c.Id == car.Id).SingleOrDefault();
                if (dbCar != null)
                {
                    dbCar.Name = car.Name;
                    dbCar.Brand = car.Brand;
                    dbCar.Type = car.Type;

                }


            }
            db.SaveChanges();

        }

        public void Delete(int id)
        {

            var dbCar = db.Cars.Find(id);
            db.Cars.Remove(dbCar);


            db.SaveChanges();
        }
    }
}
