using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodavalnik.ViewModel
{
    class CategoryViewModel : ViewModelBase
    {
        public CategoryViewModel() 
            : this ("")
        {
        }

        public CategoryViewModel(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }

        public IEnumerable<NoticeViewModel> Notices { get; set; }
    }
}
