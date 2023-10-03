using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.Mapping;

namespace WebAppMVC.Application.ViewModel.Item
{
    public class DescriptionForListVM : IMapFrom<Domain.Model.ItemDescription>
    {
        public int id {  get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public void Mapping (Profile profile)
        {
            profile.CreateMap<DescriptionForListVM, Domain.Model.ItemDescription>().ReverseMap();
        }
    }
}