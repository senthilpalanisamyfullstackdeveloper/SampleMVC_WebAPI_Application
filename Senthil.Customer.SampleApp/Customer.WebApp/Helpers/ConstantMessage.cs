using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Customer.WebApp.Helpers
{
    public static class ConstantMessage
    {
        public const string GeneralError = "Failed to retrieve the customer details from the database, please try again...";
        public const string CreateRecordError = "Error while creating the customer record and the API service call statuscode is - ";
        public const string UpdateRecordError = "Error while updating the customer record and the API service call statuscode is - ";
        public const string ViewRecordError = "Error while retrieving the customer details and the API service call statuscode is -";
        public const string DeleteRecordError = "Error while deleting the customer record and the API service call statuscode is - ";
    }
}