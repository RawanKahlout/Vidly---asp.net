using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using myvidly.Dto;
using myvidly.Models;

namespace myvidly.App_Start
{
    public class mappingprofile : Profile
    {
        public mappingprofile()
        {
            CreateMap<customer, customerDto>();
            CreateMap<customerDto, customer>();
        }
    }
}