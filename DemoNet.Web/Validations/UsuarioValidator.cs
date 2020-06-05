using DemoNet.Core.Entities;
using DemoNet.Web.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoNet.Infrastructure.Validations
{
    public class UsuarioValidator : AbstractValidator<UsuarioDTO>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.Celular).MaximumLength(9);
        }
    }
}
