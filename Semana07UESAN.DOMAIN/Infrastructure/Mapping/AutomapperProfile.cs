using AutoMapper;
using Semana07UESAN.DOMAIN.Core.DTOs;
using Semana07UESAN.DOMAIN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana07UESAN.DOMAIN.Infrastructure.Mapping
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();
            CreateMap<CustomerCountryDTO, Customer>();
            CreateMap<Customer, CustomerCountryDTO>();
            CreateMap<CustomerPostDTO, Customer>();
            CreateMap<Customer, CustomerPostDTO>();
        }
        
    }
}
