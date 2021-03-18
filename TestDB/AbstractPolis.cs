using System;
using System.Collections.Generic;
using System.Text;

namespace TestDB
{
    public class AbstractPolis
    {
        public readonly DateTime startDate;
        public readonly DateTime closeDate;
        public readonly string ID;
        public readonly string ownerName;
        public readonly string ownerSurname;
        public readonly DateTime birthDate;
        string insuredObjectName;
        string insuredObjectType;
        string status;
        DateTime lastUpdate;

        public AbstractPolis(DateTime startDate, DateTime closeDate, string ID, string ownerName, string ownerSurname, DateTime birthDate, string insuredObjectName, string insuredObjectType, string status, DateTime lastUpdate)
        {
            this.startDate = startDate;
            this.closeDate = startDate;
        }
    }
}
