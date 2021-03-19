using System;
using System.Collections.Generic;
using System.Text;

namespace TestDB
{
    class DataBaseEditor
    {
        ApplicationContext datab;

        public int AddNewPolicy(DateTime closeDate, string ownerName, string ownerSurname, DateTime birthDate, string insuredObjectName, string TypeinsuredObjectType)
        {



            AbstractPolicy pol = new AbstractPolicy(DateTime.Now, DateTime.Now.AddDays(31), ++num, "Alex", "Pichuev", new DateTime(1997, 8, 28), "MyLife", "Life");
            return 0;
        }

        /*public List<AbstractPolicy> get()
        {

            return 0;
        }*/
    }
}
