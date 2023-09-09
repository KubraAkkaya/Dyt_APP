using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dyt_APP.Models.Classes
{
    public class Questionnaire
    {
        [Key]
        public int ID { get; set; }
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
        public string DailyWaterConsumption { get; set; }
        public bool ConsumesTobaccoOrAlcohol { get; set; }
        public string TobaccoOrAlcoholFrequency { get; set; }

        [ForeignKey("Client")]
        public int ClientID { get; set; }
        public Client Client { get; set; }
    }
}