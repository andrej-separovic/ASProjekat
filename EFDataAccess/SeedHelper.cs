using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess
{
    public class SeedHelper
    {
        public void Seeder(ModelBuilder modelBuilder)
        {
            var brands = new List<Brand>
            {
                new Brand
                {
                    Id = 1,
                    Name = "Asus"
                },
                new Brand
                {
                    Id = 2,
                    Name = "Alienware"
                },
                new Brand
                {
                    Id = 3,
                    Name = "Lenovo"
                }
            };

            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "ASUS ROG Strix GL10DH Gaming Desktop",
                    OS = "Windows 10 Pro",
                    CPU = "AMD Ryzen 7 3700X",
                    GPU="NVIDIA GeForce GTX 1650 4GB",
                    RAM="8GB DDR4 2666MHz",
                    Storage="1TB PCIe NVMe M.2 SSD + 1TB 7200RPM HDD",
                    PSU="500W",
                    FormFactor="Tower",
                    ImageUrl="image1",
                    Warranty=36,
                    Price=(decimal)949.99,
                    Quantity=10,
                    BrandId=1
                },
                new Product
                {
                    Id = 2,
                    Name = "ASUS ROG Strix G15CK Gaming Desktop",
                    OS = "Windows 10 Pro",
                    CPU = "Intel Core i5-10400F",
                    GPU="NVIDIA GeForce GTX 1660 SUPER 6GB",
                    RAM="8GB DDR4 2666MHz",
                    Storage="512GB PCIe NVMe M.2 SSD",
                    PSU="500W",
                    FormFactor="Tower",
                    ImageUrl="image2",
                    Warranty=36,
                    Price=(decimal)999.99,
                    Quantity=10,
                    BrandId=1
                },
                new Product
                {
                    Id = 3,
                    Name = "ASUS ROG Strix GL12 Gaming Desktop",
                    OS = "Windows 10 Pro",
                    CPU = "Intel Core i7-9700K",
                    GPU="NVIDIA GeForce RTX 2070 8GB",
                    RAM="16GB DDR4 2666MHz",
                    Storage="1TB HyperDrive M.2 SSD",
                    PSU="750W",
                    FormFactor="Tower",
                    ImageUrl="image3",
                    Warranty=36,
                    Price=(decimal)1799.99,
                    Quantity=10,
                    BrandId=1
                },
                new Product
                {
                    Id = 4,
                    Name = "ALIENWARE AURORA R10 Gaming Desktop",
                    OS = "Windows 10 Home",
                    CPU = "AMD Ryzen 5 5600X",
                    GPU="AMD Radeon RX 6800 XT 16GB",
                    RAM="8GB DDR4 3200MHz",
                    Storage="1TB M.2 PCIe NVMe SSD + 1TB 7200RPM HDD",
                    PSU="750W",
                    FormFactor="MidTower",
                    ImageUrl="image4",
                    Warranty=36,
                    Price=(decimal)1989.99,
                    Quantity=10,
                    BrandId=2
                },
                new Product
                {
                    Id = 5,
                    Name = "ALIENWARE AURORA R12 Gaming Desktop",
                    OS = "Windows 10 Home",
                    CPU = "Intel Core i5 11400F",
                    GPU="NVIDIA GeForce GTX 1650 SUPER 4GB",
                    RAM="8GB DDR4 3200MHz",
                    Storage="1TB 7200RPM HDD",
                    PSU="550W",
                    FormFactor="MidTower",
                    ImageUrl="image5",
                    Warranty=36,
                    Price=(decimal)1129.99,
                    Quantity=10,
                    BrandId=2
                },
                new Product
                {
                    Id = 6,
                    Name = "ALIENWARE AURORA R11 Gaming Desktop",
                    OS = "Windows 10 Home",
                    CPU = "AMD Ryzen 7 5800",
                    GPU="NVIDIA GeForce RTX 3060Ti 8GB",
                    RAM="16GB DDR4 3200MHz",
                    Storage="512GB M.2 PCIe NVMe SSD",
                    PSU="750W",
                    FormFactor="MidTower",
                    ImageUrl="image6",
                    Warranty=36,
                    Price=(decimal)1799.99,
                    Quantity=10,
                    BrandId=2
                },
                new Product
                {
                    Id = 7,
                    Name = "LENOVO Legion Tower 5i",
                    OS = "Windows 10 Home",
                    CPU = "Intel Core i7-10700",
                    GPU="NVIDIA GeForce GTX 1660 Super 6GB",
                    RAM="8GB DDR4 2933MHz",
                    Storage="256GB PCIe SSD + 1TB 7200RPM HDD",
                    PSU="550W",
                    FormFactor="Tower",
                    ImageUrl="image7",
                    Warranty=36,
                    Price=(decimal)1214.99,
                    Quantity=10,
                    BrandId=3
                },
                new Product
                {
                    Id = 8,
                    Name = "LENOVO Legion Tower 6i",
                    OS = "Windows 10 Home",
                    CPU = "Intel Core i7-11700F",
                    GPU="NVIDIA GeForce RTX 3070 8GB",
                    RAM="16GB DDR4 3200MHz",
                    Storage="512GB PCIe SSD + 1TB 7200RPM HDD",
                    PSU="750W",
                    FormFactor="Tower",
                    ImageUrl="image8",
                    Warranty=36,
                    Price=(decimal)1783.99,
                    Quantity=10,
                    BrandId=3
                }
            };

            var userUseCases = new List<UserUseCase>
            {
                new UserUseCase
                {
                    Id = 1,
                    UseCaseId = 1,
                    UserId = 1
                },
                new UserUseCase
                {
                    Id = 2,
                    UseCaseId = 2,
                    UserId = 1
                },
                new UserUseCase
                {
                    Id = 3,
                    UseCaseId = 3,
                    UserId = 1
                },
                new UserUseCase
                {
                    Id = 4,
                    UseCaseId = 4,
                    UserId = 1
                },
                new UserUseCase
                {
                    Id = 5,
                    UseCaseId = 5,
                    UserId = 1
                },
                new UserUseCase
                {
                    Id = 6,
                    UseCaseId = 6,
                    UserId = 1
                },
                new UserUseCase
                {
                    Id = 7,
                    UseCaseId = 7,
                    UserId = 1
                },
                new UserUseCase
                {
                    Id = 8,
                    UseCaseId = 8,
                    UserId = 1
                },
                new UserUseCase
                {
                    Id = 9,
                    UseCaseId = 9,
                    UserId = 1
                },
                new UserUseCase
                {
                    Id = 10,
                    UseCaseId = 10,
                    UserId = 1
                },
                new UserUseCase
                {
                    Id = 11,
                    UseCaseId = 11,
                    UserId = 1
                },
                new UserUseCase
                {
                    Id = 12,
                    UseCaseId = 12,
                    UserId = 1
                },
                new UserUseCase
                {
                    Id = 13,
                    UseCaseId = 13,
                    UserId = 1
                },
                new UserUseCase
                {
                    Id = 14,
                    UseCaseId = 14,
                    UserId = 1
                },
                new UserUseCase
                {
                    Id = 15,
                    UseCaseId = 15,
                    UserId = 1
                },
                new UserUseCase
                {
                    Id = 16,
                    UseCaseId = 16,
                    UserId = 1
                },
                new UserUseCase
                {
                    Id = 17,
                    UseCaseId = 17,
                    UserId = 1
                },
                new UserUseCase
                {
                    Id = 18,
                    UseCaseId = 18,
                    UserId = 1
                },
                new UserUseCase
                {
                    Id =19,
                    UseCaseId = 1,
                    UserId = 2
                },
                new UserUseCase
                {
                    Id =20,
                    UseCaseId = 2,
                    UserId = 2
                },
                new UserUseCase
                {
                    Id =21,
                    UseCaseId = 3,
                    UserId = 2
                },
                new UserUseCase
                {
                    Id =22,
                    UseCaseId = 4,
                    UserId = 2
                },
                new UserUseCase
                {
                    Id =23,
                    UseCaseId = 5,
                    UserId = 2
                },
                new UserUseCase
                {
                    Id =24,
                    UseCaseId = 6,
                    UserId = 2
                },
                new UserUseCase
                {
                    Id =25,
                    UseCaseId = 18,
                    UserId = 2
                },
            };

            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "Admin",
                    LastName = "Adminovic",
                    Email = "admin@email.com",
                    Username = "adminuser",
                    Password = "sifra123",
                    UserUseCases = new List<UserUseCase>()
                },
                new User
                {
                    Id = 2,
                    FirstName = "Micko",
                    LastName = "Mickovic",
                    Email = "micko@email.com",
                    Username = "mickuser",
                    Password = "sifra123",
                    UserUseCases = new List<UserUseCase>()
                }
            };

            modelBuilder.Entity<Brand>().HasData(brands);
            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<UserUseCase>().HasData(userUseCases);
        }
    }
}
