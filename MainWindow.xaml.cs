using _Beauties_Shop.AppData;
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

namespace _Beauties_Shop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BeautyShopDBEntities _beautyShopDBEntities = new BeautyShopDBEntities();
        public MainWindow()
        {
            InitializeComponent();
            connectDb.DBEntities = new BeautyShopDBEntities();
            UpdateProducts();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void frmMain_ContentRendered(object sender, EventArgs e)
        {
            
            if (frmMain.CanGoBack)
            {
                BackBtn.Visibility = Visibility.Visible;
            }
            else
            {
                BackBtn.Visibility = Visibility.Collapsed;
            }


        }

        private void UpdateProducts()
        {
            var currProducts = _beautyShopDBEntities.Product.OrderBy(product=>product.Title).ToList();
            currProducts = currProducts.Where(product => product.Title.ToLower().Contains(srchTxtbx.Text.ToLower())).ToList();
            if (IsactualChkbx.IsChecked.Value)
            {
                currProducts = currProducts.Where(product => product.IsActive).ToList();
            }
            ProductList.ItemsSource = currProducts;
        }

        private void IsactualChkbx_Checked(object sender, RoutedEventArgs e)
        {
            UpdateProducts();
        }

        private void srchTxtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProducts();
        }

        private void IsactualChkbx_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateProducts();
        }
    }
}
