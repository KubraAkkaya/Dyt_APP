using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dyt_APP.Models.Classes
{
    public class BMI
    {
        [Key]
        public int ID { get; set; }
        public double MaxBMI { get; set; }
        public double MinBMI { get; set; }
        public double Weight { get; set; }
        public double BmiCalculation { get; set; }
        public double IdealWeight { get; set; }
        public DateTime CalculationDate { get; set; } 


        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}