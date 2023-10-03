﻿using AutoMapper;
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
}