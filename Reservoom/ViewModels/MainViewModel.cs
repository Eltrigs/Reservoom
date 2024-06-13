using Reservoom.Models;
using Reservoom.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore m_navigationStore;
        public ViewModelBase CurrentViewModel => m_navigationStore.CurrentViewModel;

        public MainViewModel(NavigationStore navigationStore)
        {
            m_navigationStore = navigationStore;

            m_navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            //With this, the UI will re-grab the viewmodel and change the view
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
