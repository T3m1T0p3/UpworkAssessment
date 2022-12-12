using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpworkAssessment.Model;

namespace UpworkAssessment.Controllers.Mapper
{
    public class Profiles: Profile
    {
        public Profiles()
        {
            CreateMap<Product,ProductDto>().ReverseMap();
        }
    }
}
