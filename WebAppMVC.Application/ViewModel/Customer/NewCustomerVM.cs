using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.Mapping;

namespace WebAppMVC.Application.ViewModel.Customer
{
    public class NewCustomerVM : IMapFrom<WebAppMVC.Domain.Model.Customer>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string NIP { get; set; }

        public string REGON {  get; set; }

        public string PhoneNumber { get; set; }

        public string AddressEmail { get; set; }

        public bool isActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewCustomerVM, WebAppMVC.Domain.Model.Customer>().ReverseMap();
        }
    }

    public class NewCustomerValidation : AbstractValidator<NewCustomerVM>
    {
        public NewCustomerValidation()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.NIP).Length(10);
            RuleFor(x => x.REGON).Length(9,14);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(150);
            RuleFor(x => x.AddressEmail).NotEmpty();
            RuleFor(x => x.AddressEmail).EmailAddress();
        }
    }
}