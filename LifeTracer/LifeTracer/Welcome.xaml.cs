using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    

   //In DataUnit，Subscription 5 means account, 6 means password 
    public sealed partial class Welcome : Page
    {
        private UserAccount UserAccount;
        private string account;
        public Welcome()
        {
            this.InitializeComponent();
            UserAccount = new UserAccount();
            if(DataUnit.GetData("5") != null)
            {
                AccountBox.Text = DataUnit.GetData("5").ToString();
            }
            else
            {
                AccountBox.Text = "";
            }
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SignUp));
        }

        private async void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            //写一个判断是不是已经注册了的用户,或者用户和密码对不上,这里需要网络编程！
            //Whether account and password could match the info in the database
            if (DataUnit.GetData("5") != null && AccountBox.Text.Equals(DataUnit.GetData("5").ToString()) && PasswordBox.Password.Equals(DataUnit.GetData("6").ToString()))
            {
                DataUnit.IsSignUp = true;
                Frame.Navigate(typeof(UserWelcome), UserAccount);
            }
            else
            {
                MessageDialog save = new MessageDialog("Wrong account or password", "Message");
                save.Commands.Add(new UICommand("ok", uicommand =>
                {
                    Frame.Navigate(typeof(Welcome));
                })
                );
                await save.ShowAsync();
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            account = AccountBox.Text;
        }




        /*private void Quicy_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(QuickDiary));
        }

        private void Diary_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Diary));
        }
        */


    }
}
