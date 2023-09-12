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
        public string  Job { get; set; } 
        public DateTime Date { get; set; } 
        public double Height { get; set; }
        public double Weight { get; set; }
        public Gender Gender { get; set; }
        public BMI BMI { get; set; }
        public string Phone{ get; set; }
        public Station Station{ get; set; }

        [InverseProperty("Client")]
        public ICollection<BMI> BMIs { get; set; }

        public bool HasChronicDisease { get; set; }
        public string ChronicDiseaseDescription { get; set; }
        public bool HasRegularMedications { get; set; }
        public string MedicationsDescription { get; set; }
        public bool HasFoodAllergy { get; set; }
        public string FoodAllergyDescription { get; set; }
        public bool HasSurgeryOrProcedure { get; set; }
        public string SurgeryOrProcedureDescription { get; set; }
        public bool UsesWeightLossOrDiureticDrugs { get; set; }
        public string WeightLossOrDiureticDrugsDescription { get; set; }
        public int DailySleepHours { get; set; }
        public bool HasRegularToiletHabits { get; set; }
        public bool HasFoodDiscomfort { get; set; }
        public string FoodDiscomfortDescription { get; set; }
        public bool HasDigestiveSystemDisease { get; set; }
        public string DigestiveSystemDiseaseDescription { get; set; }
        public bool HasRegularPhysicalActivity { get; set; }
        public string PhysicalActivityDescription { get; set; }
        public string DailyWaterConsumption { get; set; }
        public bool ConsumesTobaccoOrAlcohol { get; set; }
        public string TobaccoOrAlcoholFrequency { get; set; }

        public bool MenstrualCycle { get; set; }
    }
}