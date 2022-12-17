﻿using Companions.MAUI.Models.App;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Services
{
    public interface IAppointmentService
    {
        ObservableCollection<Appointment> GetAppointments();
        Appointment UpdateAppointment(Appointment appointment);
        Appointment AddAppointment(Appointment appointment);
        bool DeleteAppointment(Appointment appointment);
    }
}