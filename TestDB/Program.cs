using System;
using System.Linq;
using System.Globalization;

namespace TestDB
{
    class Program
    {
        static void Main()
        {
            using (ApplicationContext datab = new ApplicationContext())
            {
                DataBaseEditor editor = new DataBaseEditor(datab);


            }
        }

        
    }
}
