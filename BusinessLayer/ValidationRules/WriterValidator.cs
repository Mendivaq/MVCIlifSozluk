﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş geçilemez! ");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar Açıklaması boş geçilemez!");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda kısmı boş geçilemez!");
            RuleFor(x => x.WriterSurName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriniz!");
            RuleFor(x => x.WriterSurName).MaximumLength(50).WithMessage("Yazar adı 50 karakterden fazla olamaz!");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Ünvan boş geçilemez");
            RuleFor(x => x.WriterAbout).Must(IsAboutValid).WithMessage("Hakkında kısmında en az bir defa a harfi kullanılmalıdır");
        }
        private bool IsAboutValid(string arg)
        {
            try
            {
                Regex regex = new Regex(@"^(?=.*[a,A])");
                return regex.IsMatch(arg);
            }
            catch (Exception)
            {

                return false;
            }
        }



    }
}
