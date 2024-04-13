using FluentValidation;

namespace Domain.Models
{
    public class InquiryValidator : AbstractValidator<Inquiry>
    {
        public InquiryValidator()
        {
            //RuleFor(x => x.Capital).Must((inquiry, capital) => ValidateCapitalForSurgery(inquiry)).When(x => x.Covers.Contains(Cover.Surgery))
            //    .WithMessage("For Surgery cover, Capital must be between 5000 and 500000000.");
            //RuleFor(s => s.Capital).Must((inquiry, capital) => )
            //.When(p => p.Capital >= 5000 && p.Capital <= 500000000)
            //RuleFor(p => p.Capital).GreaterThan(4999).LessThan(4999999).WithMessage("For Surgery cover, Capital must be between 5000 and 500000000.");

            RuleFor(p => p.Capital).NotNull().Must(p => p >= 5000 && p <= 500000000).WithMessage("For Surgery cover, Capital must be between 5000 and 500000000.");

            RuleFor(p => p.Covers).Must((inquiry, capital) =>
            ValidateCapital(inquiry.Covers.Where(p => p == Cover.Surgery).ToList(), inquiry.Capital))
                .WithMessage("For Surgery cover, Capital must be between 5000 and 500000000.");


            RuleFor(p => p.Covers).Must((inquiry, capital) =>
            ValidateCapital(inquiry.Covers.Where(p => p == Cover.Dental).ToList(), inquiry.Capital))
                .WithMessage("For Dental cover, Capital must be between 4000 and 400000000.");

            RuleFor(p => p.Covers).Must((inquiry, capital) =>
            ValidateCapital(inquiry.Covers.Where(p => p == Cover.Hospitalization).ToList(), inquiry.Capital))
                   .WithMessage("For Hospitalization cover, Capital must be between 2000 and 200000000.");
        }

        private bool ValidateCapital(List<Cover> covers, decimal capital)
        {
            foreach (var cover in covers)
            {
                return cover switch
                {
                    Cover.Dental => capital >= 4000 && capital <= 400000000,
                    Cover.Surgery => capital >= 5000 && capital <= 500000000,
                    Cover.Hospitalization => capital >= 2000 && capital <= 200000000,
                    _ => false,
                };
            }

            return true;
        }
    }
}