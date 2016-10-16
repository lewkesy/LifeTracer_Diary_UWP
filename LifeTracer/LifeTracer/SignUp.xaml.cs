using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace LifeTracer
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>

    public class UserAccount
    {
        private string Account;
        private string Password;

        public void getAccount(string s)
        {
            Account = s;
        }

        public void getPassword(string s)
        {
            Password = s;
        }

        public string  setAccount()
        {
            return Account;
        }

        public string setPassword()
        {
            return Password;
        }
    }

    public sealed partial class SignUp : Page
    {
        private UserAccount UserAccount;
        private string account;
        private string password;
        public SignUp()
        {
            this.InitializeComponent();
            UserAccount = new UserAccount();
        }

        private void EnsureButton_Click(object sender, RoutedEventArgs e)
        {
            UserAccount.getAccount(account);
            UserAccount.getPassword(password);
            DataUnit.SaveData("5", AccountBox.Text);
            DataUnit.SaveData("6", PasswordBox.Text);
            DataUnit.IsSignUp = true;
            DataUnit.SaveData("7",DateTime.Now.Year);
            DataUnit.SaveData("8", DateTime.Now.Month);
            DataUnit.SaveData("9", DateTime.Now.Day);
            Frame.Navigate(typeof(UserWelcome), UserAccount);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Welcome));
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           account = AccountBox.Text;
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            password = PasswordBox.Text;
        }
    }
}
