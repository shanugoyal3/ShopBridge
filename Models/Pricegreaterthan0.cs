using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ShopBridge.Models
{
   
    public class Pricegreaterthan0 : ValidationAttribute

    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //this isvalid is a method which provides a validation context for the model in which we want to add vaidation
            //we need to use validationcontext.objectinstance and we need to cast it fo customer

            var product = (Product)validationContext.ObjectInstance;
            if (product.Price > 0)
                return ValidationResult.Success;
            else
                 return new ValidationResult("Price Should be Greater than Zero");

        }


    }
}
