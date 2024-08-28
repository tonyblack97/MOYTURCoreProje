using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AppUserRegisterValidator :AbstractValidator<AppUserRegisterDTOs>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x =>x.Name).NotEmpty().WithMessage("Ad alanı Boş Geçilemez");
            RuleFor(x =>x.Surname).NotEmpty().WithMessage("Soyad alanı Boş Geçilemez");
            RuleFor(x =>x.Mail).NotEmpty().WithMessage("Mail alanı Boş Geçilemez");
            RuleFor(x =>x.Username).NotEmpty().WithMessage("Kullanıcı adı alanı Boş Geçilemez");
            RuleFor(x =>x.Password).NotEmpty().WithMessage("Şifre alanı Boş Geçilemez");
            RuleFor(x =>x.ConfirmPassword).NotEmpty().WithMessage("Şifre alanı Boş Geçilemez");
            RuleFor(x => x.Username).MinimumLength(5).WithMessage("lütfen en az 5 karakter girin");
            RuleFor(x => x.Username).MaximumLength(20).WithMessage("lütfen en fazla 20 karakter girin");
            RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("Şifreler uyuşmuyor");

        }
    }
}
