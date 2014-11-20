using Prodavalnik.ViewModel;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Prodavalnik
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public string Title;
        public string Description;
        public string Image;
        
        public MainPage()
        {
            this.InitializeComponent();

            var viewModel = new CategoryViewModel("New Category");

            var categoryModel = new RootViewModel();

            viewModel.Notices = new List<NoticeViewModel>()
            {
                new NoticeViewModel(),
                new NoticeViewModel("new", "desc", "image", "category1", "new", "desc", "image", "category1", "new", "desc"),
                new NoticeViewModel("new2", "desc2", "image2", "category2", "new2", "desc2", "image2", "category2", "new2", "desc2"),
                new NoticeViewModel("new3", "desc322", "image3", "category3", "new3", "desc322", "image3", "category3", "new3", "desc322"),
            };

            var viewModel2 = new CategoryViewModel("New Category2");

            viewModel2.Notices = new List<NoticeViewModel>()
            {
                new NoticeViewModel(),
                new NoticeViewModel("new1", "desc", "image", "category4", "new", "desc", "image", "category1", "new", "desc"),
                new NoticeViewModel("new4", "desc2", "image2", "category5", "new", "desc", "image", "category1", "new", "desc"),
                new NoticeViewModel("new5", "desc322", "image3", "category6", "new", "desc", "image", "category1", "new", "desc"),
            };


            categoryModel.Categories = new List<CategoryViewModel>()
            {
                viewModel,
                viewModel2
            };

            this.DataContext = categoryModel;
           // this.CategryList.ItemsSource = categoryModel.Categories
        }

        public void OnCategoryChanged(object sender, SelectionChangedEventArgs e)
        {
            this.txtResult.Text = ((CategoryViewModel)e.AddedItems[0]).Name + "haha";
            this.CategryList.ItemsSource = new List<CategoryViewModel>(){(CategoryViewModel)e.AddedItems[0]};
            //var combobox = sender as ComboBox;

            //this.txtResult.Text = combobox.SelectedValue.ToString();
        }
    }
}