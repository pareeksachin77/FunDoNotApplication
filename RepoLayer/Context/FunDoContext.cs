using RepoLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace RepoLayer.Context
{
    public class FunDoContext : DbContext
    {
        
            public FunDoContext(DbContextOptions options): base(options)
            {
            }
            public DbSet<UserEntity> UsersTable{ get; set; }
        }
    }

