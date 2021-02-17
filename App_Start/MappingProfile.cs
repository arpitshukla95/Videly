using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Videly.Dtos;
using Videly.Models;

namespace Videly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            // CreateMap<Customer, CustomerDto>()
            //   .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<Movie, MovieDto>();
           // Mapper.CreateMap<MovieDto,Movie>();
             Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore());

        }
    }
}