using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Best.Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public class ValidatorTools
    {
        //IValidator FluentValidation paketinin içinde
        //Gelen tipe göre validation kontrolü gerçekleştiriyoruz
        public static void FluentValidate(IValidator validator,object entity)
        {
            var result = validator.Validate(entity);
            if (result.Errors.Count>0)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
