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
    public class UpdateGlucoseRecordRequestValidation : AbstractValidator<UpdateGlucoseRecordRequest>
    {
        public UpdateGlucoseRecordRequestValidation()
        {
            RuleFor(x => x.GlucoseRecordDTO!.DateRegistered).Must(BeValidDate).WithMessage("Date not in correct format");
            RuleFor(x => x.GlucoseRecordDTO!.RegisteredAfter).Must(x => MealTypes.types.Contains(x)).WithMessage("Invalid meal type");

        }

        private bool BeValidDate(string? date)
        {
            if (DateTime.TryParseExact(date, "MM-dd-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            {
                return true;
            }

            return false;
        }
    }
}