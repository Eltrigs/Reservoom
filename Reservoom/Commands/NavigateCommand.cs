using Reservoom.Services;
using Reservoom.Stores;
using Reservoom.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Reservoom.Commands
{
    public class NavigateCommand<TViewModel> : CommandBase where TViewModel : ViewModelBase
    {
        private readonly NavigationService<TViewModel> m_navigationService;

        public NavigateCommand(NavigationService<TViewModel> navigationService)
        {
            m_navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            m_navigationService.Navigate();
        }
    }
}
