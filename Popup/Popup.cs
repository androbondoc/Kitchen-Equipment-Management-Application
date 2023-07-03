﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using KEMA;
using KEMA.Models;
using KEMA.Models.ModelBase;

namespace KEMA.Popup
{
    public class Popup : BindableBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _imageUrl;
        public string ImageUrl
        {
            get { return _imageUrl; }
            set { SetProperty(ref _imageUrl, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _bgcolor;
        public string BGColor
        {
            get
            {
                if (_bgcolor == null) _bgcolor = "#fff";
                return _bgcolor;
            }
            set { SetProperty(ref _bgcolor, value); }
        }

        private string _textcolor;
        public string TextColor
        {
            get
            {
                if (_textcolor == null) _textcolor = "White";
                return _textcolor;
            }
            set { SetProperty(ref _textcolor, value); }
        }
    }

    public class PopupCollection : ObservableCollection<Popup> { }

}
