using KEMA.ViewModels.Login;
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
using System.Windows.Shapes;

namespace KEMA.Views.Login
{
    /// <summary>
    /// Interaction logic for NewUserView.xaml
    /// </summary>
    public partial class CreateUserView : Window
    {
        public CreateUserView()
        {
            InitializeComponent();
            CreateUserViewModel CUVM = new CreateUserViewModel();
            CUVM.CreateUserView = this;
            this.DataContext = CUVM;
        }
    }
}
