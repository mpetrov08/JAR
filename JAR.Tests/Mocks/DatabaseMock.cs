using JAR.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Tests.Mocks
{
    public static class DatabaseMock
    {
        public static JarDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<JarDbContext>()
                    .UseInMemoryDatabase("JarMemoryDb" + DateTime.Now.Ticks.ToString())
                    .Options;

                return new JarDbContext(dbContextOptions, false);
            }
        }
    }
}
