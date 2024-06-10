using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Infrastructure
{
    public class AppDbContext: DbContext
    {
        public DbSet<> User {  get; init; }
    }
}
