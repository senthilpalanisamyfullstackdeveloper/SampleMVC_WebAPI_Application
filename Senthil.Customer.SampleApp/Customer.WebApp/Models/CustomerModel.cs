namespace Customer.WebApp.Models
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;

    //[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CustomerModel
    {
        [Required]
      //  [JsonProperty(PropertyName = "CustomerID")]
        public int CustomerID { get; set; }

        [Required]
        //[JsonProperty(PropertyName = "CustomerName")]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        //[JsonProperty(PropertyName = "Address")]
        public string Address { get; set; }

        //[JsonProperty(PropertyName = "VehicleType")]
        public string VehicleType { get; set; }

        //[JsonProperty(PropertyName = "Category")]
        public string Category { get; set; }

        //[JsonProperty(PropertyName = "CountryName")]
        [Required]
        [Display(Name = "Country")]
        public string CountryName { get; set; }

        //[JsonProperty(PropertyName = "CreatedOn")]
        [Display(Name = "Create On")]
        public DateTime? CreatedOn { get; set; }

        //[JsonProperty(PropertyName = "CreatedBy")]
        [Display(Name = "Create By")]
        public string CreatedBy { get; set; }

        //[JsonProperty(PropertyName = "UpdatedOn")]
        [Display(Name = "Updated On")]
        public DateTime? UpdatedOn { get; set; }

        //[JsonProperty(PropertyName = "UpdatedBy")]
        [Display(Name = "Updated By")]
        public String UpdatedBy { get; set; }
    }

    //public class CustomerObject
    //{
    //    public int CustomerID { get; set; }
    //    public string CustomerName { get; set; }
    //    public string Address { get; set; }
    //    public string VehicleType { get; set; }
    //    public string Category { get; set; }
    //    public string CountryName { get; set; }
    //    //public Nullable<System.DateTime> CreatedOn { get; set; }
    //    //public string CreatedBy { get; set; }
    //    //public Nullable<System.DateTime> UpdatedOn { get; set; }
    //    //public string UpdatedBy { get; set; }
    //}
}