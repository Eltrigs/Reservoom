using Reservoom.Stores;
using Reservoom.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Services
{
    public class NavigationService<TViewModel> where TViewModel : ViewModelBase
    {
        private readonly NavigationStore m_navigationStore;
        private readonly Func<TViewModel> m_createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            m_navigationStore = navigationStore;
            m_createViewModel = createViewModel;
        }

        public void Navigate()
        {
            m_navigationStore.CurrentViewModel = m_createViewModel();
        }
    }
}
