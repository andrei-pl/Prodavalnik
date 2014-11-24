using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodavalnik.ViewModel
{
    class RootViewModel : ViewModelBase
    {
        public IList<CategoryViewModel> Categories { get; set; }

        public List<string> CategoriesList { get; set; }

        public RootViewModel()
        {
            this.Categories = new List<CategoryViewModel>();
            CategoriesList = new List<string>{
                "Home",
                "Garden",
                "Cars",
                "Phones",
                "Computers",
                "Other"
            };
        }
    }
}
