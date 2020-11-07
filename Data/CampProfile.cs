using AutoMapper;
using CoreCodeCamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCodeCamp.Data
{
    public class CampProfile: Profile
    {
        public CampProfile()
        {
            this.CreateMap<Speaker, SpeakerModel>();
            this.CreateMap<Talk, TalkModel>();
            this.CreateMap<Camp, CampModel>()
                .ForMember(d => d.VenueName, o => o.MapFrom(m => m.Location.VenueName))
                .ForMember(d => d.Address1, o => o.MapFrom(m => m.Location.Address1))
                .ForMember(d => d.Address2, o => o.MapFrom(m => m.Location.Address2))
                .ForMember(d => d.CityTown, o => o.MapFrom(m => m.Location.CityTown))
                .ForMember(d => d.StateProvince, o => o.MapFrom(m => m.Location.StateProvince))
                .ForMember(d => d.PostalCode, o => o.MapFrom(m => m.Location.PostalCode))
                .ForMember(d => d.Country, o => o.MapFrom(m => m.Location.Country))
                .ReverseMap();
        }
    }
}
