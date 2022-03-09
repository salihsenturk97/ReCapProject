using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Entities.Concrete;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).Must(ToUpper).WithMessage("Şifrende büyük harf olmalıdır.");
            RuleFor(u => u.Password).MinimumLength(8);
            RuleFor(u => u.Id).NotEmpty();
        }

        private bool ToUpper(string arg)
        {
            return arg.Any(u => arg.Contains(u));
        }
    }
}
