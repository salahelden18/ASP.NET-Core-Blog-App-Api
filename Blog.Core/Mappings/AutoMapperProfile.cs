using AutoMapper;
using Blog.Core.Domain.Entities;
using Blog.Core.Models.Dtos;
using Blog.Core.Models.Dtos.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<ApplicationRole, GetAllRolesDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryResponseDto>().ReverseMap();
            CreateMap<Tags, TagRequestDto>().ReverseMap();
            CreateMap<Tags, TagResponseDto>().ReverseMap();
        }
    }
}
