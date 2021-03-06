﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OneStop.Models;

namespace OneStop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){}

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<JobTicket> JobTickets { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ApplicationUser user = new ApplicationUser
            {
                FirstName = "admin",
                LastName = "admin",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            var passwordHash = new PasswordHasher<ApplicationUser>();
            //Returns a hased representation of the entered passwrod for the user
            user.PasswordHash = passwordHash.HashPassword(user, "Samantha21!");
            builder.Entity<ApplicationUser>().HasData(user);

            //Status Table  
            builder.Entity<Status>().HasData(
                new Status()
                {
                    StatusId = 1,
                    StatusName = "Interested"
                },
                new Status()
                {
                    StatusId = 2,
                    StatusName = "Applied"
                },
                new Status()
                {
                    StatusId = 3,
                    StatusName = "Interviewed"
                },
                new Status()
                {
                    StatusId = 4,
                    StatusName = "Rejected"
                },
                new Status()
                {
                    StatusId = 5,
                    StatusName = "Hired"
                }
            );
            //Seeding the company Table
            builder.Entity<Company>().HasData(
                new Company()
                {
                    Id = 1,
                    CreatorId = user.Id,
                    CompanyName = "Google",
                    CompanyWebsite = "www.google.com",
                    Address = "1234 Google rd",
                    CityState = "San francisco, CA"
                },
                new Company()
                {
                    Id = 2,
                    CreatorId = user.Id,
                    CompanyName = "Facebook",
                    CompanyWebsite = "www.Facebook.com",
                    Address = "1234 Facebook rd",
                    CityState = "San francisco, CA"
                }
            );

            builder.Entity<JobTicket>().HasData(
                new JobTicket()
                {
                    JobTicketId = 1,
                    UserId = user.Id,
                    CompanyId = 1,
                    Position = "Software Developer",
                    DateCreated = new DateTime(2019, 4, 28),
                    StatusId = 1
                },
                new JobTicket()
                {
                    JobTicketId = 2,
                    UserId = user.Id,
                    CompanyId = 2,
                    Position = "Software Developer",
                    DateCreated = new DateTime(2019, 1, 12),
                    StatusId = 2
                }
            );
        }
    }
}
