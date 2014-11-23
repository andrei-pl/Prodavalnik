using GalaSoft.MvvmLight;
using Parse;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Media.Imaging;

namespace Prodavalnik.ViewModel
{
    [ParseClassName("Notices")]
    class NoticeViewModel : ParseObject
    {
        [ParseFieldName("Id")]
        public string Id { get; set; }

        [ParseFieldName("Title")]
        public string Title { get; set; }

        [ParseFieldName("Description")]
        public string Description { get; set; } 

        [ParseFieldName("Image")]
        public BitmapImage Image { get; set; }

        [ParseFieldName("ImageName")]
        public string ImageName { get; set; }

        [ParseFieldName("Price")]
        public string Price { get; set; }

        [ParseFieldName("Name")]
        public string Name { get; set; }

        [ParseFieldName("Address")]
        public string Address { get; set; }

        [ParseFieldName("Phone")]
        public string Phone { get; set; }

        [ParseFieldName("Category")]
        public string Category { get; set; }

        public NoticeViewModel()
            : this("Title", "Description", new BitmapImage(), "New Category", "3", "Pesho", "Sofia", "00000")
        {
            
        }

        public NoticeViewModel(string title, string description, BitmapImage image, string category, string price, string name, string address, string phone)
        {
            this.Title = title;
            this.Description = description;
            //this.Image = image;
            this.Category = category;
            this.Price = price;
            this.Name = name;
            this.Address = address;
            this.Phone = phone;
        }
    }
}
