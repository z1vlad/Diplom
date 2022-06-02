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
    /// Логика взаимодействия для AddressesList.xaml
    /// </summary>
    public partial class AddressesList : Page
    {
        private AddressService _addressService;
        private DistrictService _districtService;
        private VillageService _villageService;
        private Address _selectedObj;
        public AddressesList()
        {
            InitializeComponent();
            _addressService = new AddressService();
            _districtService = new DistrictService();
            _villageService = new VillageService();
            Update();
        }
        public void Update()
        {
            ListAddress.ItemsSource = _addressService.GetAll().GetAwaiter().GetResult();
        }

        private async void ListAddress_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            sity.SelectionChanged -= sity_SelectionChanged;
            var selected = (Address)ListAddress.SelectedItem;
            if (selected == null) return;
            _selectedObj = selected;
            sity.ItemsSource = await _districtService.GetAll();
            village.ItemsSource = await _villageService.GetByDistrictId(_selectedObj.DistrictId);
            sity.SelectedValue = _selectedObj.DistrictId;
            if (_selectedObj.VillageId.HasValue) village.SelectedValue = _selectedObj.VillageId.Value;
            yl.Text = _selectedObj.Street;
            dom.Text = _selectedObj.House;
            pod.Text = _selectedObj.Entrance;
            kv.Text = _selectedObj.Apartment;
            sity.SelectionChanged += sity_SelectionChanged;
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var selected = (Address)ListAddress.SelectedItem;
            if (selected == null) return;
            _selectedObj.DistrictId = ((District)sity.SelectedItem).DistrictId;
            if (village.SelectedItem != null)
                _selectedObj.VillageId = ((Village)village.SelectedItem).VillageId;
            _selectedObj.Street = yl.Text;
            _selectedObj.House = dom.Text;
            _selectedObj.Entrance = pod.Text;
            _selectedObj.Apartment = kv.Text;
            await _addressService.Update(_selectedObj);
            Update();
        }
        private async void sity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cityid = (int)sity.SelectedValue;
            village.ItemsSource = await _villageService.GetByDistrictId(cityid);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.SearchPage());
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var selected = (Address)ListAddress.SelectedItem;
            if (selected == null) return;
            await _addressService.Delete(selected);
            Update();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.CreatePage());
        }
    }
}
