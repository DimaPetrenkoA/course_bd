using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Npgsql;

namespace BDcource2020
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Move_Window(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }



        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btn_authorization_Click(object sender, RoutedEventArgs e)
        {
            string database = "postgres";
            string port = "5432";
            string host = "127.0.0.1";

            string login = txb_login.Text;
            string password = txb_password.Password;

            string connection_string = $"Server={host}; Port={port}; User Id={login}; Password={password}; Database={database}";
            NpgsqlConnection connection = new NpgsqlConnection(connection_string);

            try
            {
                connection.Open();
            }
            catch (Npgsql.PostgresException ex)
            {
                MessageBox.Show("Ошибка авторизации!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }//#FF3E59A0
            MainWindow window = new MainWindow(connection_string, login);
            window.Show();
            this.Close();
        }
    }
}
