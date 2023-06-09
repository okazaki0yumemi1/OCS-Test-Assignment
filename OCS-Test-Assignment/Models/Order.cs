﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Text.Json.Serialization;

namespace OCS_Test_Assignment.Models
{
    [Table("Orders")]
    public class Order : Entity
    {
        [Key]
        public Guid Id { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; }
        public List<OrderDetails>? Lines { get; set; }
        public Order() 
        {
            Status = "New";
            Created = DateTime.Now.ToUniversalTime();
        }
        public Order(string id, List<OrderDetails> orderDetails)
        {
            Guid.TryParse(id, out Guid result);
            Id = result;
            Status = "New";
            Created = DateTime.Now.ToUniversalTime();
            Lines = orderDetails;
        }
        public bool ChangeStatus(string newStatus)
        {
            switch (newStatus)
            {
                case "Paid": this.Status = newStatus; return true;
                case "Sent": this.Status = newStatus; return true;
                case "Delivered": this.Status = newStatus; return true;
                case "Completed": this.Status = newStatus; return true;
                case "Pending payment": this.Status = newStatus; return true;
                default: return false;
            }
        }
        public bool DataIsValid()
        {
            //Checking if status is correct:
            switch (this.Status)
            {
                case "Paid": break;
                case "Sent": break;
                case "Delivered": break;
                case "Completed": break;
                case "Pending payment": break;
                default: return false;
            }

            //Checking if order has no items in it:
            if (this.Lines.Count() == 0) return false;

            //Checking validity of items inside Order:
            foreach (var line in this.Lines)
            {
                if (line.IsValid() == false) return false; 
            }
            //Guid can be checked via regex,
            //DateTime is assigned automatically but still needs to be checked.
            return true;
        }
        public bool CanBeUpdated()
        {
            //Orders can be updated (HTTP PUT) if they have certain statuses: "New" and "Pending payment":
            if ((this.Status == "New") || (this.Status == "Pending payment")) return true;
            else return false;
        }
        public bool CanBeDeleted()
        {
            //Orders can be deleted if they have statuses "New" and "Pendidng payment", plus "Paid":
            if ((this.Status == "Paid") || (this.CanBeUpdated() == true)) return true;
            else return false;
        }
        //public bool AddOrUpdateLine(OrderDetails newLine)
        //{
        //    if (newLine.IsValid() == false) return false;
        //    if (this.Lines.Where(x => x.Id == newLine.Id)) return true;
        //    //If (...) is true, then there was no line with newLine.id -> add newLine.
        //    //If (...) is false, then there are either one item with newLine.id or many:
        //    if (oldLines.Count() == this.Lines.Count()) { this.Lines.Append(newLine); return true; }
        //    //If (...) is true, then there is one line that will be updated.
        //    //If (...) is false, then there are >=2 lines with same id's, and something is wrong:
        //    else if ((this.Lines.Count() - oldLines.Count()) == 1)
        //    {
        //        this.Lines.Add(newLine);
        //        return true;
        //    }
        //    else return false;
        //}
        public string GetStatus()
        {
            return Status;
        }
    }
}
