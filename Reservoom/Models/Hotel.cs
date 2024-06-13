using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Models
{
    public class Hotel
    {
        private readonly ReservationBook m_reservationBook;    
        
        public string m_Name {  get; }

        public Hotel(string name, ReservationBook reservationBook)
        {
            m_reservationBook = reservationBook;
            m_Name = name;
        }

        /// <summary>
        /// Get all reservations.
        /// </summary>
        /// <returns>All reservations</returns>
        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await m_reservationBook.GetAllReservations();
        }


        /// <summary>
        /// Make a reservation.
        /// </summary>
        /// <param name="reservation">The incoming reservation.</param>
        /// <exception cref="ReservationConflictException">Thrown if incoming reservation conflicts with existing reservation.</exception>
        public async Task makeReservation(Reservation reservation)
        {
            await m_reservationBook.addReservation(reservation);
        }
    }


}
