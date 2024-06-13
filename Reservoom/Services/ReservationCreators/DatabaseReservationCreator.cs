using Reservoom.DbContexts;
using Reservoom.DTOs;
using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Services.ReservationCreators
{
    public class DatabaseReservationCreator : IReservationCreator
    {
        private readonly ReservoomDbContextFactory _dbContextFactory;

        public DatabaseReservationCreator(ReservoomDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateReservation(Reservation reservation)
        {
            using(ReservoomDbContext context = _dbContextFactory.CreateDbContext())
            {
                ReservationDTO reservationDTO = ToReservationDTO(reservation);

                context.Reservations.Add(reservationDTO);
                await context.SaveChangesAsync();
            }
        }

        //Could possibly use AutoMapper to get the transition from Reservation <-> ReservationDTO
        private ReservationDTO ToReservationDTO(Reservation reservation)
        {
            return new ReservationDTO()
            {
                FloorNumber = reservation.RoomID?.floorNumber ?? 0,
                RoomNumber = reservation.RoomID?.roomNumber ?? 0,
                Username = reservation.username,
                StartTime = reservation.startTime,
                EndTime = reservation.endTime,
            };
        }
    }
}
