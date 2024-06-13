using Reservoom.Exceptions;
using Reservoom.Models;
using Reservoom.Services;
using Reservoom.Stores;
using Reservoom.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Reservoom.Commands
{
    public class MakeReservationCommand : AsyncCommandBase
    {
        private readonly HotelStore m_hotelStore;
        private readonly NavigationService<ReservationListingViewModel> m_reservationViewNavigationService;
        private readonly MakeReservationViewModel m_makeReservationViewModel;

        public MakeReservationCommand(MakeReservationViewModel makeReservationViewModel,
            HotelStore hotelStore,
            NavigationService<ReservationListingViewModel> reservationViewNavigationService)
        {
            m_hotelStore = hotelStore;
            m_reservationViewNavigationService = reservationViewNavigationService;
            m_makeReservationViewModel = makeReservationViewModel;

            //By using +=, you're telling the C# compiler that you want the OnViewModelPropertyChanged method
            //to be executed whenever the PropertyChanged event occurs in the m_makeReservationViewModel object.
            //This mechanism enables the object (m_makeReservationViewModel in this case) to notify external
            //parts of the code, like UI elements, when a specific property changes, allowing for dynamic updates
            //and synchronization between different parts of your application.
            m_makeReservationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(m_makeReservationViewModel.Username) &&
                m_makeReservationViewModel.FloorNumber > 0 &&
                m_makeReservationViewModel.RoomNumber > 0 &&
                base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            Reservation reservation = new Reservation(
                new RoomID(m_makeReservationViewModel.FloorNumber, m_makeReservationViewModel.RoomNumber),
                m_makeReservationViewModel.Username,
                m_makeReservationViewModel.StartDate,
                m_makeReservationViewModel.EndDate
                );
                
            try
            {
                await m_hotelStore.MakeReservation( reservation );
                MessageBox.Show("Successfully reserved room.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                m_reservationViewNavigationService.Navigate();
            }
            catch(ReservationConflictException)
            {
                MessageBox.Show("This room is already taken.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to make reservation", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            // Handle property changes here
            // 'sender' is the object (m_makeReservationViewModel) that raised the event
            // 'e.PropertyName' contains the name of the property that changed
            if (e.PropertyName == nameof(MakeReservationViewModel.Username) ||
                e.PropertyName == nameof(MakeReservationViewModel.FloorNumber) ||
                e.PropertyName == nameof(MakeReservationViewModel.RoomNumber))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
