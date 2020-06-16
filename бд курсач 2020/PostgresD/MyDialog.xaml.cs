using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BDcource2020
{
    /// <summary>
    /// Логика взаимодействия для MyDialog.xaml
    /// </summary>
    public partial class MyDialog : Window
    {
        public MyDialog(string title, string text)
        {
            InitializeComponent();
            this.Title = title;
            Ask.Text = text;
        }

        public string ResponseText
        {
            get { return ResponseTextBox.Text; }
            set { ResponseTextBox.Text = value; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
