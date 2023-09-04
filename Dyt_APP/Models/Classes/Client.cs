using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dyt_APP.Models.Classes
{
    public enum Gender
    {
        Male,
        Female
    }

    public enum Station
    {
        Active,
        Pasive
    }
    public class Client
    {
        [Key]
        public int ID { get; set; }
        public int Age { get; set; }
        public string Name { get; set; } 
        public string Surname { get; set; } 
        public DateTime Date { get; set; } 
        public double Height { get; set; }
        public double Weight { get; set; }
        public Gender Gender { get; set; }
        public BMI BMI { get; set; }
        public string Phone{ get; set; }
        public Station Station{ get; set; }

        [InverseProperty("Client")]
        public ICollection<BMI> BMIs { get; set; }
    }
}