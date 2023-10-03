using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.Mapping;

namespace WebAppMVC.Application.ViewModel.Item
{
    public class TypeForListVM : IMapFrom<Domain.Model.Type>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void Mapping (Profile profile)
        {
            profile.CreateMap<TypeForListVM, Domain.Model.Type>().ReverseMap();
        }
    }
}