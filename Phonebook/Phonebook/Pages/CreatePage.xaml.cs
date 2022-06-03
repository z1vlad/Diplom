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
    /// Логика взаимодействия для CreatePage.xaml
    /// </summary>
    public partial class CreatePage : Page
    {
        private AddressService _addressService;
        private DistrictService _districtService;
        private VillageService _villageService;
        private UserService _userService;
        public CreatePage()
        {
            InitializeComponent();
            _addressService = new AddressService();
            _districtService = new DistrictService();
            _villageService = new VillageService();
            _userService = new UserService();
        }

        private async void sity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cityid = (int)sity.SelectedValue;
            village.ItemsSource = await _villageService.GetByDistrictId(cityid);
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            sity.ItemsSource = await _districtService.GetAll();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var number = numberBox.Text.Replace(" ","");
            if (decimal.TryParse(number, out decimal numberInt) == false)
            {
                MessageBox.Show("Не правильно заполнен телефон", "Ошибка");
                return;
            } 
            var surname = SurnameBox.Text;
            if (surname.Length < 2)
            {
                MessageBox.Show("Не правильно заполнена фамилия", "Ошибка");
                return;
            }
            var name = NameBox.Text;
            if (name.Length < 2)
            {
                MessageBox.Show("Не правильно заполнено имя", "Ошибка");
                return;
            }
            var patronimic = PatronimicBox.Text;

            var city = (District)sity.SelectedItem;
            if (city == null)
            {
                MessageBox.Show("Не правильно заполнен город", "Ошибка");
                return;
            }
            var villag = (Village)village.SelectedItem;
            var street = yl.Text;
            if (street.Length < 3)
            {
                MessageBox.Show("Не правильно заполнена улица", "Ошибка");
                return;
            }
            var house = dom.Text;
            if (house.Length < 1)
            {
                MessageBox.Show("Не правильно заполнен дом", "Ошибка");
                return;
            }
            var entrance = pod.Text;
            var apartment = kv.Text;
            var cityId = city.DistrictId;
            int? villageId = null;
            if(villag != null) villageId=villag.DistrictId;

            var userId = await _userService.Create(new User() { Surname = surname, Name = name, Patronymic = patronimic, Number = number });
            await _addressService.Create(new Address() { UserId = userId, DistrictId = cityId, VillageId = villageId, Street = street, House = house, Entrance = entrance, Apartment = apartment });
            NavigationService.Navigate(new Pages.AddressesList());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddressesList());
        }
    }
}
