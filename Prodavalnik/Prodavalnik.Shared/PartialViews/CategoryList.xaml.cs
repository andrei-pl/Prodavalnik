using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Prodavalnik.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Prodavalnik.PartialViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CategoryList : Page
    {
        private List<Notice> notices;
        private Notice note;
        private string Title;
        private string Description;
        private string Image;
        public CategoryList()
        {
            this.InitializeComponent();
            Title = "Title";
            Description = "Description";
            Image = "image";
            note = new Notice("Title1", "Description1", "Image1");
            
            Notice n1 = new Notice("Title1", "Description1", "Image1");
            Notice n2 = new Notice("Title2", "Description2", "Image2");
            Notice n3 = new Notice("Title3", "Description3", "Image3");
            Notice n4 = new Notice("Title4", "Description4", "Image4");
            Notice n5 = new Notice("Title5", "Description5", "Image5");

            notices = new List<Notice> { n1, n2, n3, n4, n5 };
        }
    }
}
