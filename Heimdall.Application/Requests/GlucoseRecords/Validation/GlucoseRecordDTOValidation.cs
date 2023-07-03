using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Heimdall.Domain;

namespace Heimdall.Application.Requests.GlucoseRecords.Validation
{
    public class GlucoseRecordDTOValidation : AbstractValidator<GlucoseRecordDTO>
    {
        public GlucoseRecordDTOValidation()
        {
            RuleFor(x => x.DateRegistered).Must(BeValidDate).WithMessage("Date not in correct format");
            RuleFor(x => x.RegisteredAfter).Must(x => MealTypes.types.Contains(x)).WithMessage("Invalid meal type");

        }

        private bool BeValidDate(string? date)
        {
            if (DateTime.TryParseExact(date, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            {
                return true;
            }

            return false;
        }
    }
}
