using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KEMA.Popup
{
    class PopupProvider
    {
        private const double _topOffset = 100;
        private const double _leftOffset = 400;
        public static DisplayPopup displayPopups { get; set; }

        static PopupProvider()
        {
            displayPopups = new DisplayPopup();
            displayPopups.Top = SystemParameters.WorkArea.Top + SystemParameters.WorkArea.Height - _topOffset;
            displayPopups.Left = SystemParameters.WorkArea.Left + SystemParameters.WorkArea.Width - _leftOffset;
        }

        public static void Error(string msgTitle, string msgMessage)
        {
            displayPopups.AddPopup(
                new Popup {
                    TextColor = "White",
                    BGColor = "Red",
                    Title = msgTitle,
                    ImageUrl = "pack://application:,,,/Notifications/Resources/error.png",
                    Message = msgMessage
                });
        }

        public static void Alert(string msgTitle, string msgMessage)
        {
            displayPopups.AddPopup(
                new Popup {
                    TextColor = "White",
                    BGColor = "Orange",
                    Title = msgTitle,
                    ImageUrl = "pack://application:,,,/Notifications/Resources/alert.png",
                    Message = msgMessage
                });
        }

        public static void Info(string msgTitle, string msgMessage)
        {
            displayPopups.AddPopup(
                new Popup {
                    TextColor = "Black",
                    BGColor = "Lime",
                    Title = msgTitle,
                    ImageUrl = "pack://application:,,,/Notifications/Resources/info.png",
                    Message = msgMessage
                });
        }

        public static void Close()
        {
            displayPopups.Close();
        }

    }
}
