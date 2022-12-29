﻿using AutoMapper;
using Companions.API.DTOs;
using Companions.API.DTOs.Appointment;
using Companions.API.DTOs.Buddy;
using Companions.Domain;

namespace Companions.API.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Activity, ActivityDTO>();
            CreateMap<ActivityType, ActivityTypeDTO>();
            CreateMap<Appointment, AppointmentDTO>();
            CreateMap<DailyFeeding, DailyFeedingDTO>();
            CreateMap<FeedingSchedule, FeedingScheduleDTO>();
            CreateMap<FeedProduct, FeedProductDTO>();
            CreateMap<Place, PlaceDTO>();
            CreateMap<Place, PlaceDTO>();
            CreateMap<Activity, ActivityDTO>();
            CreateMap<BuddyWeight, BuddyWeightDTO>();

            CreateMap<User, UserDTO>();

            CreateMap<Buddy, BuddyDTO>();
            CreateMap<CreateBuddyDTO, Buddy>();
            CreateMap<BuddyDTO, Buddy>();



        }
    }
}