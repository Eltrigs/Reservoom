using Reservoom.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Stores
{
    public class NavigationStore
    {
        private ViewModelBase m_currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => m_currentViewModel;
            set
            {
                m_currentViewModel?.Dispose();
                m_currentViewModel = value;
                //Every time the setter is called this function is called aswell
                OnCurrentViewModelChanged();
            }
        }
        
        public event Action CurrentViewModelChanged;

        private void OnCurrentViewModelChanged()
        {
            //Every time this function is called, it "invokes" this Action class method, whatever this means.
            //I'm thinking everything that is subscribed to this specific variable, get notified. 
            CurrentViewModelChanged?.Invoke();
        }

        
    }
}
