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
        public string Id { get; set; }

        private string _appointmentName;
        private string _description;
        private Buddy _buddy;
        private DateTime _appointmentDate;
        private DateTime _appointmentTime;
        private Place _place;


        public Place Place
        {
            get => _place;
            set => SetProperty(ref _place, value);
        }

        public string AppointmentName
        {
            get => _appointmentName;
            set => SetProperty(ref _appointmentName, value);
        }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public Buddy Buddy
        {
            get => _buddy;
            set => SetProperty(ref _buddy, value);
        }

        public DateTime AppointmentDate
        {
            get => _appointmentDate;
            set => SetProperty(ref _appointmentDate, value);
        }

        public DateTime AppointmentTime
        {
            get => _appointmentTime;
            set => SetProperty(ref _appointmentTime, value);
        }
    }
}
