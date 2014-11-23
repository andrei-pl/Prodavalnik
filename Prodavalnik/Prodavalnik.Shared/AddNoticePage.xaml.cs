using Newtonsoft.Json.Linq;
using Prodavalnik.Common;
using Prodavalnik.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Parse;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Prodavalnik
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class AddNoticePage : Page
    {

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        private MediaCapture captureManager;
        private Geolocator locator;
        private BitmapImage bmpImage;
        private bool isCapturingStoped;

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public AddNoticePage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;

            locator = null;
            isCapturingStoped = false;

            LoadLocation();
            InitCamera();
        }

        private async void LoadLocation()
        {
            if (locator == null)
            {
                locator = new Geolocator();
            }

            locator.DesiredAccuracy = PositionAccuracy.Default;
            locator.MovementThreshold = 100;

            Geoposition position = await locator.GetGeopositionAsync();
            var latitude = position.Coordinate.Latitude;
            var longitude = position.Coordinate.Longitude;
            string address = await GetAddress(latitude, longitude);

            this.edtAddress.Text = address;
        }

        private static async Task<string> GetAddress(double latitude, double longitude)
        {
            string url = "http://maps.google.com/maps/api/geocode/json?latlng=" + latitude + "," + longitude + "&sensor=false";
            string address = "";
            string jsonAddress = "";

            // Create the web request  
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

            // Get response  
            using (HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse)
            {
                // Get the response stream  

                StreamReader reader = new StreamReader(response.GetResponseStream());

                // Read the whole contents and return as a string  
                jsonAddress = reader.ReadToEnd();

                JObject jsonObj = JObject.Parse(jsonAddress);
                address = jsonObj["results"][0]["address_components"][2]["long_name"].ToString();
            }

            return address;
        }

        async private void InitCamera()
        {
            captureManager = new MediaCapture();
            await captureManager.InitializeAsync();

            imagePreivew.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            capturePreview.Visibility = Windows.UI.Xaml.Visibility.Visible;
            StartCapturePreview();
        }

        async private void StartCapturePreview()
        {
            capturePreview.Height = 300;
            capturePreview.Width = 400;
            capturePreview.Source = captureManager;
            await captureManager.StartPreviewAsync();
        }

        async private void StopCapturePreview()
        {
            if (!isCapturingStoped)
            {
                await captureManager.StopPreviewAsync();
                isCapturingStoped = true;
            }
        }

        async private void CapturePhoto_Click(object sender, RoutedEventArgs e)
        {
            if (((ToggleButton)sender).IsChecked == true)
            {
                ImageEncodingProperties imgFormat = ImageEncodingProperties.CreateJpeg();
                imgFormat.Width = 400;
                imgFormat.Height = 340;

                // create storage file in local app storage
                StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(
                    "Notice.jpg",
                    CreationCollisionOption.GenerateUniqueName);

                // take photo
                await captureManager.CapturePhotoToStorageFileAsync(imgFormat, file);

                // Get photo as a BitmapImage
                bmpImage = new BitmapImage(new Uri(file.Path));

                // imagePreivew is a <Image> object defined in XAML
                capturePreview.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                imagePreivew.Visibility = Windows.UI.Xaml.Visibility.Visible;
                imagePreivew.Source = bmpImage;
                StopCapturePreview();
            }
            else
            {
                InitCamera();
                isCapturingStoped = false;
                imagePreivew.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                capturePreview.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
        }

        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session. The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.DataContext = e.Parameter as RootViewModel;
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            StopCapturePreview();
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void AddNotice_Click(object sender, RoutedEventArgs e)
        {
            string title = this.edtTitle.Text;
            string description = this.edtDescription.Text;
            string price = this.edtPrice.Text;
            string phone = this.edtPhone.Text;
            string address = this.edtAddress.Text;
            string name = this.edtName.Text;
            string category = this.cmbCategories.SelectedValue.ToString();

            var notice = new NoticeViewModel(title, description, bmpImage, category, price, name, address, phone);
            var parseObject = new ParseObject("Notices");
            parseObject["Title"] = title;
            parseObject["Description"] = description;
            parseObject["Price"] = price;
            parseObject["Phone"] = phone;
            parseObject["Address"] = address;
            parseObject["Name"] = name;
            parseObject["Category"] = category;
            //parseObject["Picture"] = bmpImage;
            parseObject.SaveAsync();
            //notice.SaveAsync();
            notice.Id = parseObject.ObjectId; //It's for the SQLite
        }
    }
}
