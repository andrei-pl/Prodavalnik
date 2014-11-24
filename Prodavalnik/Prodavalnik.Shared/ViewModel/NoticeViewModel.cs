using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Media.Imaging;

namespace Prodavalnik.ViewModel
{
    class NoticeViewModel : ViewModelBase
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; } 

        public BitmapImage Image { get; set; }

        public string ImageName { get; set; }

        public string Price { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Category { get; set; }

        public NoticeViewModel()
            : this("Title", "Description", new BitmapImage(), "New Category", "3", "Pesho", "Sofia", "00000")
        {
            
        }

        public NoticeViewModel(string title, string description, BitmapImage image, string category, string price, string name, string address, string phone)
        {
            this.Title = title;
            this.Description = description;
            this.Image = image;
            this.Category = category;
            this.Price = price;
            this.Name = name;
            this.Address = address;
            this.Phone = phone;
        }
    }
}
