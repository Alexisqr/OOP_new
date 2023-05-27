using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ShelterBLL.Dto;

namespace ShelterBLL.Validation
{
   

    public class PersonDTOValidator : AbstractValidator<AnimalsResponceDto>
    {
        public PersonDTOValidator()
        {
            RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

            RuleFor(dto => dto.Age)
                .InclusiveBetween(0, 100).WithMessage("Age must be between 0 and 100.");
        }
    }
}
