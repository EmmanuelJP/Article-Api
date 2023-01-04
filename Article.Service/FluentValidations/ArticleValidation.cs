using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Article.Service.DTOs;
using FluentValidation;

namespace Article.Service.FluentValidations
{


    public class ArticleValidator : AbstractValidator<ArticleDto>
    {
        public ArticleValidator()
        {
            RuleFor(customer => customer.Title).NotNull();
            RuleFor(customer => customer.Description).NotNull();
        }
    }
}
