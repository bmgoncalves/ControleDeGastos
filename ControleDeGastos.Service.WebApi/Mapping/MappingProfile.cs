using AutoMapper;
using ControleDeGastos.ApplicationCore.Constants;
using ControleDeGastos.ApplicationCore.Entities;
using ControleDeGastos.ApplicationCore.Models;

namespace ControleDeGastos.Service.WebApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EntriesViewModel, Entries>()
                
                .ReverseMap();
            CreateMap<CategoryViewModel, Category>()
                    .ReverseMap();  
        }
    }
}

