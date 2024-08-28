using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.AnnouncementValidationRules
{
    public class AnnouncementUpdateValidator:AbstractValidator<AnnouncementUpdateDto>
    {
        public AnnouncementUpdateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen başlığı boş geçmeyin");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Lütfen başlığı boş geçmeyin");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Lütfen en az 5 Karakter Girin");
            RuleFor(x => x.Content).MaximumLength(20).WithMessage("Lütfen en az 20 Karakter Girin");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Lütfen en fazla 50 Karakter Girin");
            RuleFor(x => x.Content).MaximumLength(500).WithMessage("Lütfen en fazla 500 Karakter Girin");
        }
    }
}
