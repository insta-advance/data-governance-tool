using System;
using Microsoft.EntityFrameworkCore;

namespace IntopaloApi.Data.Access
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
