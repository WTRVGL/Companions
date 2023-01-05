using AutoMapper;
using Companions.API.DTOs;
using Companions.API.DTOs.Activity;
using Companions.API.DTOs.Appointment;
using Companions.API.DTOs.Buddy;
using Companions.Domain;

namespace Companions.API.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            CreateMap<ActivityType, ActivityTypeDTO>();
            CreateMap<DailyFeeding, DailyFeedingDTO>();
            CreateMap<FeedingSchedule, FeedingScheduleDTO>();
            CreateMap<FeedProduct, FeedProductDTO>();

            CreateMap<User, UserDTO>();

            CreateMap<BuddyWeight, BuddyWeightDTO>();
            CreateMap<BuddyWeightDTO, BuddyWeight>();
            CreateMap<CreateBuddyWeightDTO, BuddyWeight>();
            CreateMap<BuddyWeight, CreateBuddyWeightDTO>();

            CreateMap<Place, PlaceDTO>();
            CreateMap<Place, PlaceDTO>();

            CreateMap<Buddy, BuddyDTO>();
            CreateMap<CreateBuddyDTO, Buddy>();
            CreateMap<BuddyDTO, Buddy>();

            CreateMap<Activity, ActivityDTO>();
            CreateMap<ActivityDTO, Activity>();
            CreateMap<CreateActivityDTO, Activity>();

            CreateMap<UpdateBuddyDTO, Buddy>();
            CreateMap<Buddy, UpdateBuddyDTO>();

            CreateMap<UpdateAppointmentDTO, Appointment>();
            CreateMap<Appointment, UpdateAppointmentDTO>();
            CreateMap<Appointment, AppointmentDTO>();

        }
    }
}
