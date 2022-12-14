using AutoMapper;
using Companions.API.DTOs;
using Companions.API.Services;
using Companions.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Companions.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly IPlaceService _placeService;
        private readonly IMapper _mapper;

        public PlacesController(IPlaceService placeService, IMapper mapper)
        {
            _placeService = placeService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [SwaggerOperation("Gets a Place by Id")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(PlaceDTO), Description = "Gets a Place")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Unauthorized")]
        [Authorize]
        public ActionResult<PlaceDTO> GetPlaceById(string id)
        {
            var place = _placeService.GetPlaceById(id);
            if (place == null) return NotFound();

            return _mapper.Map<PlaceDTO>(place);
        }

        [HttpGet]
        [SwaggerOperation("Return all existing Places")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<PlaceDTO>), Description = "List of places returned")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Unauthorized")]
        [Authorize]
        public ActionResult<List<PlaceDTO>> GetAllPlaces()
        {
            var places = _placeService.GetAllPlaces();
            if (places == null) return NotFound();

            var placesDTO = new List<PlaceDTO>();
            places.ForEach(p =>
            {
                var placeDTO = _mapper.Map<PlaceDTO>(p);
                placesDTO.Add(placeDTO);
            });

            return placesDTO;
        }

        [HttpPost]
        [SwaggerOperation("Create a new Place")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(PlaceDTO), Description = "Returns the newly created Place")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Unauthorized")]
        [Authorize]
        public ActionResult<PlaceDTO> CreatePlace(PlaceDTO placeDTO)
        {
            var place = _mapper.Map<Place>(placeDTO);
            var createdPlace = _placeService.CreatePlace(place);
            return placeDTO;
        }
    }
}
