using System;
using Microsoft.EntityFrameworkCore;

namespace DataGovernanceTool.Data.Access
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
