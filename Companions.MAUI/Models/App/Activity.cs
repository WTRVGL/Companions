using System;

namespace Companions.MAUI.Models.App
{
    public class Activity
    {
        public string Id { get; set; }
        public ActivityType ActivityType { get; set; }
        public string ImageURL { get { return GetRandomActivityImage(); } }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        private string GetRandomActivityImage()
        {
            var rng = new Random();
            string[] walkingImages = 
            { 
                "https://storage.googleapis.com/companions_bucket01/honest-paws-J2c_lqMX1AM-unsplash-20230103105118.jpg" ,
                "https://storage.googleapis.com/companions_bucket01/humphrey-muleba-mmqPwkaTGCs-unsplash-20230103105114.jpg",
                "https://storage.googleapis.com/companions_bucket01/jordon-conner-sjYKio1FfZw-unsplash-20230103105105.jpg",
                "https://storage.googleapis.com/companions_bucket01/juli-kosolapova-03BdGsyZdAk-unsplash-20230103105110.jpg"
            };

            string[] feedingImages =
            {
                "https://storage.googleapis.com/companions_bucket01/bonnie-kittle-MUcxe_wDurE-unsplash-20230103111821.jpg",
                "https://storage.googleapis.com/companions_bucket01/joshua-j-cotten-8oPPUxfTsmQ-unsplash-20230103111815.jpg",
                "https://storage.googleapis.com/companions_bucket01/juan-camilo-guarin-p-G4jOCMCXxhE-unsplash-20230103111810.jpg",
                "https://storage.googleapis.com/companions_bucket01/marek-szturc-dFgtAO0qBVk-unsplash-20230103111818.jpg"
            };

            switch (ActivityType.Name)
            {
                case "Walk":
                    return walkingImages[rng.Next(walkingImages.Length)];
                case "Feeding":
                    return feedingImages[rng.Next(walkingImages.Length)];
                default:
                    return "https://storage.googleapis.com/companions_bucket01/honest-paws-J2c_lqMX1AM-unsplash-20230103105118.jpg";
            }
        }

    }
}