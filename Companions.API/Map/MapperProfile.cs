using AutoMapper;
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
            CreateMap<ActivityDTO, Activity>();
            CreateMap<ActivityType, ActivityTypeDTO>();
            CreateMap<DailyFeeding, DailyFeedingDTO>();
            CreateMap<FeedingSchedule, FeedingScheduleDTO>();
            CreateMap<FeedProduct, FeedProductDTO>();
            CreateMap<Place, PlaceDTO>();
            CreateMap<Place, PlaceDTO>();
            
            CreateMap<BuddyWeight, BuddyWeightDTO>();

            CreateMap<User, UserDTO>();

            CreateMap<Buddy, BuddyDTO>();
            CreateMap<CreateBuddyDTO, Buddy>();
            CreateMap<BuddyDTO, Buddy>();

            CreateMap<UpdateBuddyDTO, Buddy>();
            CreateMap<Buddy, UpdateBuddyDTO>();


            CreateMap<UpdateAppointmentDTO, Appointment>();
            CreateMap<Appointment, UpdateAppointmentDTO>();
            CreateMap<Appointment, AppointmentDTO>();

        }
    }
}
