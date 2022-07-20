using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

CarManager carManager = new CarManager(new EfCarDal());
//carManager.Add(new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 1000, ModelYear = 2021, Description = "Coupe" });
BrandManager brandManager = new BrandManager(new EfBrandDal());
//brandManager.Add(new Brand { Id = 1, BrandName = "Audi" });
//brandManager.Add(new Brand { Id = 2, BrandName = "Mercedes" });
//brandManager.Add(new Brand { Id = 3, BrandName = "Porsche" });
//brandManager.Add(new Brand { Id = 4, BrandName = "BMW" });
//brandManager.Add(new Brand { Id = 5, BrandName = "Volkswagen" });
//brandManager.Add(new Brand { Id = 6, BrandName = "Seat" });

ColorManager colorManager = new ColorManager(new EfColorDal());
//colorManager.Add(new Color { Id = 1, ColorName = "Black" }); 
//colorManager.Add(new Color { Id = 2, ColorName = "White" });
//colorManager.Add(new Color { Id = 3, ColorName = "Red" });
//colorManager.Add(new Color { Id = 4, ColorName = "Dark Blue" });


//carManager.Update(new Car { Id = 1, BrandId = 6, ColorId = 1, DailyPrice = 900, Description = "Hatchback", ModelYear = 2021 });


//foreach (var item in carManager.GetAll())
//{
//    Console.WriteLine(item.BrandId + " " + item.Description + " " + item.ModelYear);

//}

//foreach (var brand in brandManager.GetAll())
//{
//    Console.WriteLine(brand.BrandName);
//}
//Console.WriteLine("---------------");
foreach (var car in carManager.GetCarDetails())
{
    Console.WriteLine("{0}-{1}-{2}-{3}", car.Id, car.Description, car.BrandName, car.ColorName);
}

//Console.WriteLine("***********");
//carManager.Delete(new Car { Id = 7});
//Console.WriteLine("***********");
//Console.WriteLine("GetByID");
//Console.WriteLine(carManager.GetById(1).Description);



