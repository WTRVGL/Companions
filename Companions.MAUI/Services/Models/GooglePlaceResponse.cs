using Newtonsoft.Json;

namespace Companions.MAUI.Services.Models
{
    public class GooglePlaceResponse
    {
        [JsonProperty("html_attributions")]
        public List<object> HtmlAttributions { get; set; }

        [JsonProperty("results")]
        public List<Result> Results { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }


        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Geometry
        {
            [JsonProperty("location")]
            public Location Location { get; set; }

            [JsonProperty("viewport")]
            public Viewport Viewport { get; set; }
        }

        public class Location
        {
            [JsonProperty("lat")]
            public double Lat { get; set; }

            [JsonProperty("lng")]
            public double Lng { get; set; }
        }

        public class Northeast
        {
            [JsonProperty("lat")]
            public double Lat { get; set; }

            [JsonProperty("lng")]
            public double Lng { get; set; }
        }

        public class OpeningHours
        {
            [JsonProperty("open_now")]
            public bool OpenNow { get; set; }
        }

        public class Photo
        {
            [JsonProperty("height")]
            public int Height { get; set; }

            [JsonProperty("html_attributions")]
            public List<string> HtmlAttributions { get; set; }

            [JsonProperty("photo_reference")]
            public string PhotoReference { get; set; }

            [JsonProperty("width")]
            public int Width { get; set; }
        }

        public class PlusCode
        {
            [JsonProperty("compound_code")]
            public string CompoundCode { get; set; }

            [JsonProperty("global_code")]
            public string GlobalCode { get; set; }
        }

        public class Result
        {
            [JsonProperty("business_status")]
            public string BusinessStatus { get; set; }

            [JsonProperty("geometry")]
            public Geometry Geometry { get; set; }

            [JsonProperty("icon")]
            public string Icon { get; set; }

            [JsonProperty("icon_background_color")]
            public string IconBackgroundColor { get; set; }

            [JsonProperty("icon_mask_base_uri")]
            public string IconMaskBaseUri { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("opening_hours")]
            public OpeningHours OpeningHours { get; set; }

            [JsonProperty("photos")]
            public List<Photo> Photos { get; set; }

            [JsonProperty("place_id")]
            public string PlaceId { get; set; }

            [JsonProperty("plus_code")]
            public PlusCode PlusCode { get; set; }

            [JsonProperty("price_level")]
            public int PriceLevel { get; set; }

            [JsonProperty("rating")]
            public double Rating { get; set; }

            [JsonProperty("reference")]
            public string Reference { get; set; }

            [JsonProperty("scope")]
            public string Scope { get; set; }

            [JsonProperty("types")]
            public List<string> Types { get; set; }

            [JsonProperty("user_ratings_total")]
            public int UserRatingsTotal { get; set; }

            [JsonProperty("vicinity")]
            public string Vicinity { get; set; }
        }


        public class Southwest
        {
            [JsonProperty("lat")]
            public double Lat { get; set; }

            [JsonProperty("lng")]
            public double Lng { get; set; }
        }

        public class Viewport
        {
            [JsonProperty("northeast")]
            public Northeast Northeast { get; set; }

            [JsonProperty("southwest")]
            public Southwest Southwest { get; set; }
        }


    }
}
