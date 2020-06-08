using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimaAviContext 
{
    public class ClimaAviContext : DbContext
    {
        public ClimaAviContext(DbContextOptions<ClimaAviContext> options)
            :base (options)
        { 
        }
    }
}
