using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodavalnik.ViewModel
{
    class RootViewModel : ViewModelBase
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; }

        public RootViewModel()
        {
        }
    }
}
