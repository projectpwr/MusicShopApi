using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Services.Tests.Models
{
    public class MusicShopModel
    {
        public bool HasValidState { get; private set; }

        public void validateModel()
        {
            var context = new ValidationContext(this, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(this, context, results);
            if (isValid)
            {
                this.HasValidState = true;
            }
            else
            {
                //this.HasValidState = false;
                foreach (var validationResult in results)
                {
                    throw new ArgumentOutOfRangeException(validationResult.ErrorMessage);
                }
            }
            
        }
    }

}
