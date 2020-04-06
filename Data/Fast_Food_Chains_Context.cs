using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Fast_Food_Chains_Web_API.Model;

namespace Fast_Food_Chains_Web_API.Models
{
    public class Fast_Food_Chains_Context : DbContext
    {
        public Fast_Food_Chains_Context (DbContextOptions<Fast_Food_Chains_Context> options)
            : base(options)
        {
        }

        public DbSet<Fast_Food_Chains_Web_API.Model.FastFoodChain> FastFoodChain { get; set; }
    }
}
