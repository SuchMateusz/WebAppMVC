using AutoMapper;

namespace WebAppMVC.Application.ViewModel.Customer
{
    public class CustomerContactInformactionForListVm
    {
        public string Name { get; set; }

        public string LastNameUser { get; set; }

        public string Position { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<WebAppMVC.Domain.Model.Customer, CustomerContactInformactionForListVm>();
        }
    }
}