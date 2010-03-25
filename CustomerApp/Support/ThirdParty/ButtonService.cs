using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace CustomerApp.Support.ThirdParty
{
    // This class created by Patrick Cauldwell in his blog entry, 
    // here: http://www.cauldwell.net/patrick/blog/MVVMBindingToCommandsInSilverlight.aspx
    public static class ButtonService
    {
                /// <summary>
        /// CommandParameter Attached Dependency Property
        /// </summary>
        private static readonly DependencyProperty _commandProperty;

        static ButtonService()
        {
             _commandProperty = DependencyProperty.RegisterAttached("Command", typeof(string), typeof(ButtonService),
                new PropertyMetadata(OnCommandChanged));
        }

        /// <summary>
        /// Gets the Command property.
        /// </summary>
        public static ICommand GetCommand(DependencyObject d)
        {
            return (ICommand)d.GetValue(_commandProperty);
        }

        /// <summary>
        /// Sets the Command property.
        /// </summary>
        public static void SetCommand(DependencyObject d, ICommand value)
        {
            d.SetValue(_commandProperty, value);
        }

        /// <summary>
        /// Handles changes to the Command property.
        /// </summary>
        private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Button)
            {
                string parameter = d.GetValue(_commandProperty) as string;
                Button b = d as Button;
                ICommand c = e.NewValue as ICommand;
                b.Click += delegate(object sender, RoutedEventArgs arg) { c.Execute(parameter); };
            }
        }
    }
}
