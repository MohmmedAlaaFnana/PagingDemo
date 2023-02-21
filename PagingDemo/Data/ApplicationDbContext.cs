using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PagingDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PagingDemo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CustomerEntity> CustomerEntities { get; set; }
    }
}
