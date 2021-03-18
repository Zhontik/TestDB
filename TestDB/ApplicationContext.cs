using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace TestDB
{
    class ApplicationContext : DbContext
    {
        public DbSet<AbstractPolis> polises { get; set; }

    }
}
