using Article.Service.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Article.Service.Map
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleDto, Model.Entities.Article>();
            CreateMap<Model.Entities.Article, ArticleDto>();

        }
    }
}
