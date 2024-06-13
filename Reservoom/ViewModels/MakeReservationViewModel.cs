using Reservoom.Commands;
using Reservoom.Models;
using Reservoom.Services;
using Reservoom.Stores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Reservoom.ViewModels
{
    public class MakeReservationViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        private string m_username;
        public string Username
        {
            get { return m_username; }
            set { m_username = value; OnPropertyChanged(nameof(Username)); }
        }

        private int m_roomNumber;
        public int RoomNumber
        { 
            get { return m_roomNumber; } 
            set { m_roomNumber = value; OnPropertyChanged(nameof(RoomNumber)); } 
        }

        private int m_floorNumber;
        public int FloorNumber
        {   
            get { return m_floorNumber; } 
            set { m_floorNumber = value; OnPropertyChanged(nameof(FloorNumber)); } 
        }

        private DateTime m_startDate = DateTime.Now;
        public DateTime StartDate
        {
            get { return m_startDate; }
            set 
            {
                m_startDate = value; 
                OnPropertyChanged(nameof(StartDate));
                ClearErrors(nameof(StartDate));
                ClearErrors(nameof(EndDate));
                if (EndDate < StartDate)
                {
                    AddError("The start date cannot be after the end date.", nameof(StartDate));
                }
            }
        }

        private DateTime m_endDate = DateTime.Now;
        public DateTime EndDate
        {   
            get { return m_endDate; }
            set
            {
                m_endDate = value;
                OnPropertyChanged(nameof(EndDate));
                ClearErrors(nameof(StartDate));
                ClearErrors(nameof(EndDate));
                if (EndDate < StartDate)
                {
                    AddError("The end date cannot be before the start date.", nameof(EndDate));
                }
            }
        }

        private void AddError(string errorMessage, string propertyName)
        {
            if(!_propertyNameToErrorsDictionary.ContainsKey(propertyName))
            {
                _propertyNameToErrorsDictionary.Add(propertyName, new List<string>());
            }
            _propertyNameToErrorsDictionary[propertyName].Add(errorMessage);
            OnErrorsChanged(propertyName);
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public ICommand SubmitCommand { get;}
        public ICommand CancelCommand { get;}

        public MakeReservationViewModel(HotelStore hotelStore,
            NavigationService<ReservationListingViewModel> reservationViewNavigationService) 
        {
            SubmitCommand = new MakeReservationCommand(this, hotelStore, reservationViewNavigationService);
            CancelCommand = new NavigateCommand<ReservationListingViewModel>(reservationViewNavigationService);
            _propertyNameToErrorsDictionary = new Dictionary<string, List<string>>();
        }


        private readonly Dictionary<string, List<string>> _propertyNameToErrorsDictionary;
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
        public bool HasErrors => _propertyNameToErrorsDictionary.Any();
        public IEnumerable GetErrors(string propertyName)
        {
            return _propertyNameToErrorsDictionary.GetValueOrDefault(propertyName, new List<string>());
        }

        private void ClearErrors(string propertyName)
        {
            _propertyNameToErrorsDictionary.Remove(propertyName);
            OnErrorsChanged(propertyName);
        }
    }
}
