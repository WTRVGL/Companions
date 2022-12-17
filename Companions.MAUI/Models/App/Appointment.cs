using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Models.App
{
    public class Appointment : ObservableObject
    {
        private string _appointmentName;

        public string AppointmentName
        {
            get => _appointmentName;
            set => SetProperty(ref _appointmentName, value);
        }

        private string _appointmentType;

        public string AppointmentType
        {
            get => _appointmentType;
            set => SetProperty(ref _appointmentType, value);
        }

        private string _description;

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        private Buddy _buddy;

        public Buddy Buddy
        {
            get => _buddy;
            set => SetProperty(ref _buddy, value);
        }

        private DateTime _appointmentDate;

        public DateTime AppointmentDate
        {
            get => _appointmentDate;
            set => SetProperty(ref _appointmentDate, value);
        }

        private string _locationName;

        public string LocationName
        {
            get => _locationName;
            set => SetProperty(ref _locationName, value);
        }


        public string Id { get; set; }
        public Location LocationCoordinates { get; set; }
    }
}
