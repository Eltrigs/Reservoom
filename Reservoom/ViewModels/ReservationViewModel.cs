using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.ViewModels
{
    public class ReservationViewModel : ViewModelBase
    {
        private readonly Reservation m_reservation;

        public string RoomID => m_reservation.RoomID?.ToString();
        public string Username => m_reservation.username;
        public string StartDate => m_reservation.startTime.ToString("d");
        public string EndDate => m_reservation.endTime.ToString("d");

        public ReservationViewModel(Reservation reservation)
        {
            m_reservation = reservation;
        }
    }
}
