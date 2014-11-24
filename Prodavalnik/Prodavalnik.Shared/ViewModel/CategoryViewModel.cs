using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodavalnik.ViewModel
{
    class CategoryViewModel : ViewModelBase
    {
        public CategoryViewModel()
            : this("")
        {

        }

        public CategoryViewModel(string name)
        {
            this.Name = name;
            this.Notices = new List<NoticeViewModel>();
        }

        public string Name { get; set; }

        public IList<NoticeViewModel> Notices { get; set; }
    }
}
