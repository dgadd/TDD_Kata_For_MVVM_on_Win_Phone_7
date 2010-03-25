using System;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace CustomerApp.Support.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public void VerifyPropertyName(string propertyName)
        {
            if (this.GetType().GetProperties().Any(propertyInfo => propertyInfo.Name.Equals(propertyName)))
            {
                return;
            }
            throw new VerifyPropertyNameException();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.VerifyPropertyName(propertyName);

            var handler = this.PropertyChanged;
            if (handler == null) return;
            var e = new PropertyChangedEventArgs(propertyName);
            handler(this, e);
        }
    }
}
