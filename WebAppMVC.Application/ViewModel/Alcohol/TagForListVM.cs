﻿using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.Mapping;

namespace WebAppMVC.Application.ViewModel.Item
{
    public class TagForListVM : IMapFrom<Domain.Model.Tag>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TagForListVM, Domain.Model.Tag>().ReverseMap();
        }
    }

    public class NewTagValidation : AbstractValidator<TagForListVM>
    {
        public NewTagValidation()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).Length(1, 30);
        }
    }
}