using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Text;

namespace GEMEscolar.Helpers
{
    public static class Helpers
    {
        public static string[] ErrorsMessageModelSatate(this ModelStateDictionary.ValueEnumerable modelState)
        {
            StringBuilder messages = new StringBuilder();

            foreach (var item in modelState)
            {
                var errors = item.Errors;
                foreach (var error in errors)
                {
                    messages.Append(error.ErrorMessage).Append(Environment.NewLine);
                }
            }

            return messages.ToString().Split(Environment.NewLine);
        }
    }
}
