using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Exceptions
{
    public class ReservationConflictException : Exception
    {
        public Reservation existingReservation { get; }
        public Reservation incomingReservation { get; }


        public ReservationConflictException(Reservation existingReservation, Reservation incomingReservation)
        {
            this.existingReservation = existingReservation;
            this.incomingReservation = incomingReservation;
        }

        public ReservationConflictException(string? message, Reservation existingReservation, Reservation incomingReservation) : base(message)
        {
            this.existingReservation = existingReservation;
            this.incomingReservation = incomingReservation;
        }

        public ReservationConflictException(string? message, Exception? innerException, Reservation existingReservation, Reservation incomingReservation) : base(message, innerException)
        {
            this.existingReservation = existingReservation;
            this.incomingReservation = incomingReservation;
        }
    }
}
