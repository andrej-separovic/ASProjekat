// <auto-generated />
using System;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFDataAccess.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2021, 8, 29, 20, 58, 44, 242, DateTimeKind.Utc).AddTicks(1093),
                            IsDeleted = false,
                            Name = "Asus"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2021, 8, 29, 20, 58, 44, 242, DateTimeKind.Utc).AddTicks(1684),
                            IsDeleted = false,
                            Name = "Alienware"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2021, 8, 29, 20, 58, 44, 242, DateTimeKind.Utc).AddTicks(1700),
                            IsDeleted = false,
                            Name = "Lenovo"
                        });
                });

            modelBuilder.Entity("Domain.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShippingAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Domain.OrderLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderLines");
                });

            modelBuilder.Entity("Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("CPU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FormFactor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GPU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OS")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PSU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("RAM")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Storage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Warranty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            CPU = "AMD Ryzen 7 3700X",
                            CreatedAt = new DateTime(2021, 8, 29, 20, 58, 44, 242, DateTimeKind.Utc).AddTicks(2616),
                            FormFactor = "Tower",
                            GPU = "NVIDIA GeForce GTX 1650 4GB",
                            ImageUrl = "image1",
                            IsDeleted = false,
                            Name = "ASUS ROG Strix GL10DH Gaming Desktop",
                            OS = "Windows 10 Pro",
                            PSU = "500W",
                            Price = 949.99m,
                            Quantity = 10,
                            RAM = "8GB DDR4 2666MHz",
                            Storage = "1TB PCIe NVMe M.2 SSD + 1TB 7200RPM HDD",
                            Warranty = 36
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 1,
                            CPU = "Intel Core i5-10400F",
                            CreatedAt = new DateTime(2021, 8, 29, 20, 58, 44, 242, DateTimeKind.Utc).AddTicks(5374),
                            FormFactor = "Tower",
                            GPU = "NVIDIA GeForce GTX 1660 SUPER 6GB",
                            ImageUrl = "image2",
                            IsDeleted = false,
                            Name = "ASUS ROG Strix G15CK Gaming Desktop",
                            OS = "Windows 10 Pro",
                            PSU = "500W",
                            Price = 999.99m,
                            Quantity = 10,
                            RAM = "8GB DDR4 2666MHz",
                            Storage = "512GB PCIe NVMe M.2 SSD",
                            Warranty = 36
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 1,
                            CPU = "Intel Core i7-9700K",
                            CreatedAt = new DateTime(2021, 8, 29, 20, 58, 44, 242, DateTimeKind.Utc).AddTicks(5470),
                            FormFactor = "Tower",
                            GPU = "NVIDIA GeForce RTX 2070 8GB",
                            ImageUrl = "image3",
                            IsDeleted = false,
                            Name = "ASUS ROG Strix GL12 Gaming Desktop",
                            OS = "Windows 10 Pro",
                            PSU = "750W",
                            Price = 1799.99m,
                            Quantity = 10,
                            RAM = "16GB DDR4 2666MHz",
                            Storage = "1TB HyperDrive M.2 SSD",
                            Warranty = 36
                        },
                        new
                        {
                            Id = 4,
                            BrandId = 2,
                            CPU = "AMD Ryzen 5 5600X",
                            CreatedAt = new DateTime(2021, 8, 29, 20, 58, 44, 242, DateTimeKind.Utc).AddTicks(5473),
                            FormFactor = "MidTower",
                            GPU = "AMD Radeon RX 6800 XT 16GB",
                            ImageUrl = "image4",
                            IsDeleted = false,
                            Name = "ALIENWARE AURORA R10 Gaming Desktop",
                            OS = "Windows 10 Home",
                            PSU = "750W",
                            Price = 1989.99m,
                            Quantity = 10,
                            RAM = "8GB DDR4 3200MHz",
                            Storage = "1TB M.2 PCIe NVMe SSD + 1TB 7200RPM HDD",
                            Warranty = 36
                        },
                        new
                        {
                            Id = 5,
                            BrandId = 2,
                            CPU = "Intel Core i5 11400F",
                            CreatedAt = new DateTime(2021, 8, 29, 20, 58, 44, 242, DateTimeKind.Utc).AddTicks(5476),
                            FormFactor = "MidTower",
                            GPU = "NVIDIA GeForce GTX 1650 SUPER 4GB",
                            ImageUrl = "image5",
                            IsDeleted = false,
                            Name = "ALIENWARE AURORA R12 Gaming Desktop",
                            OS = "Windows 10 Home",
                            PSU = "550W",
                            Price = 1129.99m,
                            Quantity = 10,
                            RAM = "8GB DDR4 3200MHz",
                            Storage = "1TB 7200RPM HDD",
                            Warranty = 36
                        },
                        new
                        {
                            Id = 6,
                            BrandId = 2,
                            CPU = "AMD Ryzen 7 5800",
                            CreatedAt = new DateTime(2021, 8, 29, 20, 58, 44, 242, DateTimeKind.Utc).AddTicks(5549),
                            FormFactor = "MidTower",
                            GPU = "NVIDIA GeForce RTX 3060Ti 8GB",
                            ImageUrl = "image6",
                            IsDeleted = false,
                            Name = "ALIENWARE AURORA R11 Gaming Desktop",
                            OS = "Windows 10 Home",
                            PSU = "750W",
                            Price = 1799.99m,
                            Quantity = 10,
                            RAM = "16GB DDR4 3200MHz",
                            Storage = "512GB M.2 PCIe NVMe SSD",
                            Warranty = 36
                        },
                        new
                        {
                            Id = 7,
                            BrandId = 3,
                            CPU = "Intel Core i7-10700",
                            CreatedAt = new DateTime(2021, 8, 29, 20, 58, 44, 242, DateTimeKind.Utc).AddTicks(5552),
                            FormFactor = "Tower",
                            GPU = "NVIDIA GeForce GTX 1660 Super 6GB",
                            ImageUrl = "image7",
                            IsDeleted = false,
                            Name = "LENOVO Legion Tower 5i",
                            OS = "Windows 10 Home",
                            PSU = "550W",
                            Price = 1214.99m,
                            Quantity = 10,
                            RAM = "8GB DDR4 2933MHz",
                            Storage = "256GB PCIe SSD + 1TB 7200RPM HDD",
                            Warranty = 36
                        },
                        new
                        {
                            Id = 8,
                            BrandId = 3,
                            CPU = "Intel Core i7-11700F",
                            CreatedAt = new DateTime(2021, 8, 29, 20, 58, 44, 242, DateTimeKind.Utc).AddTicks(5554),
                            FormFactor = "Tower",
                            GPU = "NVIDIA GeForce RTX 3070 8GB",
                            ImageUrl = "image8",
                            IsDeleted = false,
                            Name = "LENOVO Legion Tower 6i",
                            OS = "Windows 10 Home",
                            PSU = "750W",
                            Price = 1783.99m,
                            Quantity = 10,
                            RAM = "16GB DDR4 3200MHz",
                            Storage = "512GB PCIe SSD + 1TB 7200RPM HDD",
                            Warranty = 36
                        });
                });

            modelBuilder.Entity("Domain.UseCaseLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Actor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("UseCaseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UseCaseLogs");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2021, 8, 29, 20, 58, 44, 242, DateTimeKind.Utc).AddTicks(7753),
                            Email = "admin@email.com",
                            FirstName = "Admin",
                            IsDeleted = false,
                            LastName = "Adminovic",
                            Password = "sifra123",
                            Username = "adminuser"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2021, 8, 29, 20, 58, 44, 242, DateTimeKind.Utc).AddTicks(9043),
                            Email = "micko@email.com",
                            FirstName = "Micko",
                            IsDeleted = false,
                            LastName = "Mickovic",
                            Password = "sifra123",
                            Username = "mickuser"
                        });
                });

            modelBuilder.Entity("Domain.UserUseCase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UseCaseId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserUseCases");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UseCaseId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            UseCaseId = 2,
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            UseCaseId = 3,
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            UseCaseId = 4,
                            UserId = 1
                        },
                        new
                        {
                            Id = 5,
                            UseCaseId = 5,
                            UserId = 1
                        },
                        new
                        {
                            Id = 6,
                            UseCaseId = 6,
                            UserId = 1
                        },
                        new
                        {
                            Id = 7,
                            UseCaseId = 7,
                            UserId = 1
                        },
                        new
                        {
                            Id = 8,
                            UseCaseId = 8,
                            UserId = 1
                        },
                        new
                        {
                            Id = 9,
                            UseCaseId = 9,
                            UserId = 1
                        },
                        new
                        {
                            Id = 10,
                            UseCaseId = 10,
                            UserId = 1
                        },
                        new
                        {
                            Id = 11,
                            UseCaseId = 11,
                            UserId = 1
                        },
                        new
                        {
                            Id = 12,
                            UseCaseId = 12,
                            UserId = 1
                        },
                        new
                        {
                            Id = 13,
                            UseCaseId = 13,
                            UserId = 1
                        },
                        new
                        {
                            Id = 14,
                            UseCaseId = 14,
                            UserId = 1
                        },
                        new
                        {
                            Id = 15,
                            UseCaseId = 15,
                            UserId = 1
                        },
                        new
                        {
                            Id = 16,
                            UseCaseId = 16,
                            UserId = 1
                        },
                        new
                        {
                            Id = 17,
                            UseCaseId = 17,
                            UserId = 1
                        },
                        new
                        {
                            Id = 18,
                            UseCaseId = 18,
                            UserId = 1
                        },
                        new
                        {
                            Id = 19,
                            UseCaseId = 1,
                            UserId = 2
                        },
                        new
                        {
                            Id = 20,
                            UseCaseId = 2,
                            UserId = 2
                        },
                        new
                        {
                            Id = 21,
                            UseCaseId = 3,
                            UserId = 2
                        },
                        new
                        {
                            Id = 22,
                            UseCaseId = 4,
                            UserId = 2
                        },
                        new
                        {
                            Id = 23,
                            UseCaseId = 5,
                            UserId = 2
                        },
                        new
                        {
                            Id = 24,
                            UseCaseId = 6,
                            UserId = 2
                        },
                        new
                        {
                            Id = 25,
                            UseCaseId = 18,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("Domain.Order", b =>
                {
                    b.HasOne("Domain.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.OrderLine", b =>
                {
                    b.HasOne("Domain.Order", "Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Product", "Product")
                        .WithMany("OrderLines")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Product", b =>
                {
                    b.HasOne("Domain.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Domain.UserUseCase", b =>
                {
                    b.HasOne("Domain.User", "User")
                        .WithMany("UserUseCases")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Domain.Order", b =>
                {
                    b.Navigation("OrderLines");
                });

            modelBuilder.Entity("Domain.Product", b =>
                {
                    b.Navigation("OrderLines");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("UserUseCases");
                });
#pragma warning restore 612, 618
        }
    }
}
