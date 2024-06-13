using Reservoom.Commands;
using Reservoom.Models;
using Reservoom.Services;
using Reservoom.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Reservoom.ViewModels
{
    public class ReservationListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ReservationViewModel> m_reservations;
        private HotelStore m_hotelStore;

        public IEnumerable<ReservationViewModel> Reservations => m_reservations;

        private bool m_isLoading;

        public bool IsLoading
        {
            get { return m_isLoading; }
            set 
            { 
                m_isLoading = value; 
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

        public ICommand LoadReservationsCommand{ get; }

        public ICommand MakeReservationCommand { get; }

        public ReservationListingViewModel(HotelStore hotelStore, NavigationService<MakeReservationViewModel> makeReservationNavigationService) 
        {
            m_hotelStore = hotelStore;
            m_reservations = new ObservableCollection<ReservationViewModel>();
            LoadReservationsCommand = new LoadReservationsCommand(this, hotelStore);
            MakeReservationCommand = new NavigateCommand<MakeReservationViewModel>(makeReservationNavigationService);

            m_hotelStore.ReservationMade += OnReservationMade;
        }

        private void OnReservationMade(Reservation reservation)
        {
            ReservationViewModel reservationViewModel = new ReservationViewModel(reservation);
            m_reservations.Add(reservationViewModel);
        }

        public override void Dispose()
        {
            m_hotelStore.ReservationMade -= OnReservationMade;
            base.Dispose();
        }

        public static ReservationListingViewModel LoadViewModel(HotelStore hotelStore, NavigationService<MakeReservationViewModel> makeReservationNavigationService)
        {
            ReservationListingViewModel viewModel = new ReservationListingViewModel(hotelStore, makeReservationNavigationService);

            viewModel.LoadReservationsCommand.Execute(null);
            return viewModel;
        }

        public void UpdateReservations(IEnumerable<Reservation> reservations)
        {
            m_reservations.Clear();

            foreach (Reservation reservation in reservations)
            {
                ReservationViewModel reservationViewModel = new ReservationViewModel(reservation);
                m_reservations.Add(reservationViewModel);
            }
        }
    }
}
