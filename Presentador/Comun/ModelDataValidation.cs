using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Veterinaria.Presentador.Comun
{
    internal class ModelDataValidation
    {
        public void Validate(object model)
        {
            string ErrorMessage = "";
            List<ValidationResult> results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(model);
            bool isValid = Validator.TryValidateObject(model, context, results, true);
            if (isValid == false)
            {
                foreach (var item in results)
                {
                    ErrorMessage += item.ErrorMessage;
                    throw new Exception(ErrorMessage);
                }
            }

        }
    }
}
