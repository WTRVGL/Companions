using AutoMapper;
using Companions.API.DTOs;
using Companions.API.DTOs.Appointment;
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
            CreateMap<Location, LocationDTO>();
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
