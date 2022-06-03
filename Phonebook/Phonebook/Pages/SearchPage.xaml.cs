using Repository.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Phonebook.Pages
{
    /// <summary>
    /// Логика взаимодействия для SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        private AddressService _addressService;
        private DistrictService _districtService;
        private VillageService _villageService;
        public SearchPage()
        {
            InitializeComponent();
            _addressService = new AddressService();
            _districtService = new DistrictService();
            _villageService = new VillageService();
            Update();
        }
        public async void Update()
        {
            ListAddress.ItemsSource = _addressService.GetAll().GetAwaiter().GetResult();
            sity.ItemsSource = await _districtService.GetAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddressesList());
        }
        private async void sity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cityid = (int)sity.SelectedValue;
            village.ItemsSource = await _villageService.GetByDistrictId(cityid);
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var cityId = -1;
            var villageId = -1;
            if (sity.SelectedItem != null) cityId = ((District)sity.SelectedItem).DistrictId;
            if (village.SelectedItem != null)  villageId = ((Village)village.SelectedItem).VillageId;
            var name = userNameBox.Text;
            var number = numberBox.Text;
            var result = await _addressService.Search(number, name, cityId, villageId);
            ListAddress.ItemsSource = result.ToList();
        }
    }
}
