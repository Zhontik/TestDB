using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TestDB
{
    class DataBaseEditor
    {
        private readonly ApplicationContext datab;
        private string[][] param;

        public DataBaseEditor(ApplicationContext datab)
        {
            this.datab = datab;
        }
        
        /// <summary>
        /// Create new policy and save it into the database
        /// </summary>
        /// <param name="closeDate">Date must be after start.Can't be changed.</param>
        /// <param name="ownerName">Must be shorter than 50 symbols. Can't be changed.</param>
        /// <param name="ownerSurname">Must be shorter than 50 symbols. Can't be changed.</param>
        /// <param name="birthDate">Owner must be older than 18</param>
        /// <param name="insuredObjectName">Must be shorter than 50 symbols.</param>
        /// <param name="TypeinsuredObjectType">Must be one of the list: "Car","House","Life".</param>
        /// <returns> Return true, if function created new policy and return false, if parametres are wrong. </returns>
        public bool AddNewPolicy(DateTime startDate,DateTime closeDate, string ownerName, string ownerSurname, DateTime birthDate, string insuredObjectName, string insuredObjectType)
        {
            if (startDate < DateTime.Now)
            {
                Console.WriteLine("StartDate must be later than today");
                return false;
            }
            if (closeDate < startDate)
            {
                Console.WriteLine("CloseDate must be later than StartDate");
                return false;
            }
            int num = datab.Policies.Count();
            if (ownerName.Length > 50)
            {
                Console.WriteLine("Owner name must be shorter than 50 symbols");
                return false;
            }
            if (ownerSurname.Length > 50)
            {
                Console.WriteLine("Owner surname must be shorter than 50 symbols");
                return false;
            }
            if (DateTime.Now < birthDate.AddYears(18))
            {
                Console.WriteLine("Owner must be older than 18");
                return false;
            }
            if (insuredObjectName.Length > 50)
            {
                Console.WriteLine("Insured object name must be shorter than 50 symbols");
                return false;
            }
            if ((insuredObjectType != "Car") && (insuredObjectType != "House") && (insuredObjectType != "Life"))
            {
                Console.WriteLine("Insured object type must be 'Car' or 'House' or 'Life' ");
                return false;
            }

            Policy pol = new Policy(startDate, closeDate, ++num, ownerName, ownerSurname, birthDate, insuredObjectName, insuredObjectType);
            datab.Policies.Add(pol);
            datab.SaveChanges();
            return true;
        }

        public void Info()
        {
            Console.WriteLine("Список объектов:");
            foreach (Policy p in datab.Policies.ToList())
            {
                Console.WriteLine($"{p.number}-{p.startDate}-{p.closeDate}-{p.lastUpdate}-{p.ownerName}-{p.ownerSurname}-{p.birthDate}-{p.insuredObjectName}-{p.insuredObjectType}");
            }
        }

        public bool UpdatePolicy(string number, string field, string value)
        {
            Policy pol = FindNumber(number);
            switch (field)
            {
                case "insuredName":
                    if(value.Length <= 50)
                    {
                        pol.insuredObjectName = value;
                        pol.lastUpdate = DateTime.Now;
                        datab.SaveChanges();
                    }
                    break;
                case "insuredType":
                    if ((value == "Car")||(value == "House")||(value == "Life"))
                    {
                        pol.insuredObjectType = value;
                        pol.lastUpdate = DateTime.Now;
                        datab.SaveChanges();
                    }
                    break;
            }
            return true;
        }

        public Policy FindNumber(string number)
        {
            var result = (from pol in datab.Policies
                          where pol.number == number
                          select pol).ToList();
            if (result.Count() == 0)
            {
                Console.WriteLine("There is no such policy");
                return null;
            }
            else
            {
                Policy res = result[0];
                Console.WriteLine($"{res.number}-{res.startDate}-{res.closeDate}-{res.lastUpdate}-{res.ownerName}-{res.ownerSurname}-{res.birthDate}-{res.insuredObjectName}-{res.insuredObjectType}");
                return res;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param">Array 2xN. [0] - parameter name: "Before(DateTime)","After(DateTime)",Datetime Example("22.03.2021"),"Name(String)","Surname(String)","Status(String)","ObjectName(String)". [1] - parameter condition.</param>
        /// <param name="pol"></param>
        /// <returns></returns>
        private bool IsGood(Policy pol)
        {
            foreach(string[] arr in param)
            {
                switch (arr[0])
                {
                    case "Before":
                        if(pol.lastUpdate > DateTime.Parse(arr[1]))
                        {
                            return false;
                        }
                        break;
                    case "After":
                        if (pol.lastUpdate < DateTime.Parse(arr[1]))
                        {
                            return false;
                        }
                        break;
                    case "Name":
                        if (pol.ownerName != arr[1])
                        {
                            return false;
                        }
                        break;
                    case "Surname":
                        if (pol.ownerSurname != arr[1])
                        {
                            return false;
                        }
                        break;
                    case "Status":
                        if (pol.status != arr[1])
                        {
                            return false;
                        }
                        break;
                    case "ObjectName":
                        if (!pol.insuredObjectName.Contains(arr[1]))
                        {
                            return false;
                        }
                        break;
                }
            }
            return true;
        }

        public List<Policy> Get(string[][] param)
        {
            this.param = param;
            var result = datab.Policies.Where(IsGood).ToList();
            this.param = null;
            if (result.Count() == 0)
            {
                Console.WriteLine("There is no such policy");
                return null;     
            }
            else
            {
                foreach(Policy res in result)
                    Console.WriteLine($"{res.number}-{res.startDate}-{res.closeDate}-{res.lastUpdate}-{res.ownerName}-{res.ownerSurname}-{res.birthDate}-{res.insuredObjectName}-{res.insuredObjectType}");
                return result;
            }
        }
    }
}
