﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TestDB
{
    public class AbstractPolicy
    {
        [Key] public int Id { get; set; }
        public string number { get; set; }
        public DateTime closeDate { get; set; }
        public DateTime startDate { get; set; }
        public string ownerName { get; set; }
        public string ownerSurname { get; set; }
        public DateTime birthDate { get; set; }
        public string insuredObjectName { get; set; }
        public string insuredObjectType { get; set; }
        public string status { get; set; }
        public DateTime lastUpdate { get; set; }

        public AbstractPolicy(){}

        /// <summary>
        /// Create already existed polis.
        /// </summary>
        /// <param name="startDate">Can't be changed.</param>
        /// <param name="closeDate">Date must be after start.Can't be changed.</param>
        /// <param name="number">Polis number</param>
        /// <param name="ownerName">Can't be changed.</param>
        /// <param name="ownerSurname"><Can't be changed./param>
        /// <param name="birthDate">Owner must be 18+. Can't be changed.</param>
        /// <param name="insuredObjectName"></param>
        /// <param name="insuredObjectType">Must be one of list: "Car","House","Life".</param>
        /// <param name="status">Must be one of list: "Active","Closed","Waiting".</param>
        /// <param name="lastUpdate">Date must be after start.</param>
        public AbstractPolicy(DateTime startDate, DateTime closeDate, string number, string ownerName, string ownerSurname, DateTime birthDate, string insuredObjectName, string insuredObjectType, string status, DateTime lastUpdate)
        {
            this.startDate = startDate > DateTime.Now ? startDate : DateTime.Now;
            this.closeDate = closeDate > startDate ? closeDate : startDate;
            this.number = number;
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
        /// <param name="Id">Polis number without month</param>
        /// <param name="ownerName">Can't be changed.</param>
        /// <param name="ownerSurname"><Can't be changed./param>
        /// <param name="birthDate">Owner must be 18+. Can't be changed.</param>
        /// <param name="insuredObjectName"></param>
        /// <param name="insuredObjectType">Must be one of list: "Car","House","Life".</param>
        public AbstractPolicy(DateTime startDate, DateTime closeDate, int Id, string ownerName, string ownerSurname, DateTime birthDate, string insuredObjectName, string insuredObjectType)
        {
            this.startDate = startDate > DateTime.Now ? startDate : DateTime.Now;
            this.closeDate = closeDate > startDate ? closeDate : startDate;
            this.number = startDate.ToString("MMM") + Id.ToString();
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
