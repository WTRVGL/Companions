using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Models.App
{
    public class ScheduleAppointment : ObservableObject
    {
        
        private DateTime _from;
        private DateTime _to;
        private string _notes;
        private string _eventName;


        public string EventName
        {
            get => _eventName;
            set => SetProperty(ref _eventName, value);
        }

        public string Notes
        {
            get => _notes;
            set => SetProperty(ref _notes, value);
        }

        public DateTime From
        {
            get => _from;
            set => SetProperty(ref _from, value);
        }

        public DateTime To
        {
            get => _to;
            set => SetProperty(ref _to, value);
        }

    }
}
