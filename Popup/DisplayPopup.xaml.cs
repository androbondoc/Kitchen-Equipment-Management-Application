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

namespace KEMA.Popup
{
    /// <summary>
    /// Interaction logic for DisplayNotifcation.xaml
    /// </summary>
    public partial class DisplayPopup : Window
    {
        private const byte _MAX_Popup = 6;
        private int _count;
        public PopupCollection Popups = new PopupCollection();
        private readonly PopupCollection _buffer = new PopupCollection();

        public DisplayPopup()
        {
            InitializeComponent();
            PopupsControl.DataContext = Popups;
        }

        public void AddPopup(Popup popup)
        {
            popup.Id = _count++;
            if (Popups.Count + 1 > _MAX_Popup)
                _buffer.Add(popup);
            else
                Popups.Add(popup);

            //Show window if there're notifications
            if (Popups.Count > 0 && !IsActive)
                Show();
        }

        public void RemovePopup(Popup popup)
        {
            if (Popups.Contains(popup))
                Popups.Remove(popup);

            if (_buffer.Count > 0)
            {
                Popups.Add(_buffer[0]);
                _buffer.RemoveAt(0);
            }

            //Close window if there's nothing to show
            if (Popups.Count < 1)
                Hide();
        }

        private void PopupWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Height != 0.0)
                return;
            var element = sender as Grid;
            RemovePopup(Popups.First(n => n.Id == Int32.Parse(element.Tag.ToString())));
        }
    }
}
