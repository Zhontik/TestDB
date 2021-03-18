using System;
using System.Collections.Generic;
using System.Text;

namespace TestDB
{
    public class AbstractPolis
    {
        public readonly DateTime startDate;
        public readonly DateTime closeDate;
        public readonly string Id;
        public readonly string ownerName;
        public readonly string ownerSurname;
        public readonly DateTime birthDate;
        string insuredObjectName;
        string insuredObjectType;
        string status;
        DateTime lastUpdate;

        /// <summary>
        /// Create already existed polis.
        /// </summary>
        /// <param name="startDate">Can't be changed.</param>
        /// <param name="closeDate">Date must be after start.Can't be changed.</param>
        /// <param name="Id">Can't be changed.</param>
        /// <param name="ownerName">Can't be changed.</param>
        /// <param name="ownerSurname"><Can't be changed./param>
        /// <param name="birthDate">Owner must be 18+. Can't be changed.</param>
        /// <param name="insuredObjectName"></param>
        /// <param name="insuredObjectType">Must be one of list: "Car","House","Live".</param>
        /// <param name="status">Must be one of list: "Active","Closed","Waiting".</param>
        /// <param name="lastUpdate">Date must be after start.</param>
        public AbstractPolis(DateTime startDate, DateTime closeDate, string Id, string ownerName, string ownerSurname, DateTime birthDate, string insuredObjectName, string insuredObjectType, string status, DateTime lastUpdate)
        {
            this.startDate = startDate > DateTime.Now ? startDate : DateTime.Now;
            this.closeDate = closeDate > startDate ? closeDate : startDate;
            this.Id = Id;
            this.ownerName = ownerName;
            this.ownerSurname = ownerSurname;
            this.birthDate = DateTime.Now.Subtract(birthDate) > TimeSpan.FromSeconds(1) ? birthDate : DateTime.Now.AddYears(-18);
            this.insuredObjectName = insuredObjectName;
            this.insuredObjectType = insuredObjectType;
            this.status = status;
            this.lastUpdate = lastUpdate > startDate ? lastUpdate : startDate;
        }

        /// <summary>
        /// Create new Polis.
        /// </summary>
        /// <param name="startDate">Can't be changed.</param>
        /// <param name="closeDate">Date must be after start.Can't be changed.</param>
        /// <param name="number">Polis number</param>
        /// <param name="ownerName">Can't be changed.</param>
        /// <param name="ownerSurname"><Can't be changed./param>
        /// <param name="birthDate">Owner must be 18+. Can't be changed.</param>
        /// <param name="insuredObjectName"></param>
        /// <param name="insuredObjectType">Must be one of list: "Car","House","Live".</param>
        public AbstractPolis(DateTime startDate, DateTime closeDate, int number, string ownerName, string ownerSurname, DateTime birthDate, string insuredObjectName, string insuredObjectType)
        {
            this.startDate = startDate > DateTime.Now ? startDate : DateTime.Now;
            this.closeDate = closeDate > startDate ? closeDate : startDate;
            this.Id = startDate.ToString("MMM") + number.ToString();
            this.ownerName = ownerName;
            this.ownerSurname = ownerSurname;
            this.birthDate = DateTime.Now.Subtract(birthDate) > TimeSpan.FromSeconds(1) ? birthDate : DateTime.Now.AddYears(-18);
            this.insuredObjectName = insuredObjectName;
            this.insuredObjectType = insuredObjectType;
            this.status = "Active";
            this.lastUpdate = startDate;
        }
    }
}
