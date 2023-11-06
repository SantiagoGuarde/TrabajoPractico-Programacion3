﻿    using Microsoft.EntityFrameworkCore;
using TrabajoPracticoP3.Data.Entities;

namespace TrabajoPracticoP3.DBContext
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderProduct> OrderProducts { get; set; }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);


            modelBuilder.Entity<Admin>().HasData(new Admin
            {
                Id = 1,
                Name = "Juan",
                SurName = "Perez",
                Email = "JuanPerez@gmail.com",
                UserName = "JuancitoPerez",
                UserType = "Admin",
                Password = "987654"
            });

            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    Id = 2,
                    Name = "Ernesto",
                    SurName = "Gutierrez",
                    Email = "Erne22@gmail.com",
                    UserName = "ElGuason21",
                    UserType = "Client",
                    Password = "123321",
                    PhoneNumber = "3415123212",
                    Adress = "Pellegrini 211"
                },
                new Client
                {
                    Id = 3,
                    Name = "Sebastuan",
                    SurName = "Gonzalez",
                    Email = "Seba25@gmail.com",
                    UserName = "Batman21",
                    UserType = "Client",
                    Password = "554466",
                    PhoneNumber = "3415123333",
                    Adress = "Mendoza 211"
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Pizza de Muzzarella",
                    Price = "3000"
                },
                new Product
                {
                    Id = 2,
                    Name = "Pizza de Jamon",
                    Price = "3500"
                },
                new Product
                {
                    Id = 3,
                    Name = "Pizza de Pepperoni",
                    Price = "4000"
                }
            );




            modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany()
                .HasForeignKey(op => op.ProductId);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderProducts)
                .WithOne()
                .HasForeignKey(op => op.OrderId);

            // Configurar la relación uno a muchos entre Admin y Product
            /*modelBuilder.Entity<Product>()
                .HasOne(p => p.ModifiedByAdmin)
                .WithMany(a => a.Products)
                .HasForeignKey(p => p.ModifiedByAdminId)
                .OnDelete(DeleteBehavior.Restrict); // Esto evita la eliminación en cascada si se elimina un admin*/

            base.OnModelCreating(modelBuilder);
        }
    }
}


