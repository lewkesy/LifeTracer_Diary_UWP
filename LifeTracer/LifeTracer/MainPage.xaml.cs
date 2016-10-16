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

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace LifeTracer
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    
    public sealed partial class MainPage : Page
    {
        public bool exist = false;
        public MainPage()
        {
            this.InitializeComponent();
            DiaryManage.readData();
            DiaryManage.readQuickData();
            MainView.Navigate(typeof(Welcome));
            Back.Visibility = Visibility.Collapsed;
        }

        private void Optional_Click(object sender, RoutedEventArgs e)
        {
            SplitVIew.IsPaneOpen = !SplitVIew.IsPaneOpen;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (HomeItem.IsSelected)
            {
                if (!DataUnit.IsSignUp)
                {
                    UnsignedError();
                }
                else
                {
                    MainView.Navigate(typeof(UserWelcome));
                    SplitVIew.IsPaneOpen = false;
                }
            }
            else if (QuickDiaryItem.IsSelected)
            {
                if (!DataUnit.IsSignUp)
                {
                    UnsignedError();
                }
                else
                {
                    MainView.Navigate(typeof(QuickDiary));
                    SplitVIew.IsPaneOpen = false;
                }

            }
            else if (DailyDiaryItem.IsSelected)
            {
                if (!DataUnit.IsSignUp)
                {
                    UnsignedError();
                }
                else
                {
                    MainView.Navigate(typeof(Diary));
                    SplitVIew.IsPaneOpen = false;
                }
            }
            else if (SearchItem.IsSelected)
            {
                if (!DataUnit.IsSignUp)
                {
                    UnsignedError();
                }
                else
                {
                    MainView.Navigate(typeof(Search));
                    SplitVIew.IsPaneOpen = false;
                }
            }
            /*else if (AboutUsItem.IsSelected)
            {
                if (!DataUnit.IsSignUp)
                {
                    MainView.Navigate(typeof(Welcome));
                    SplitVIew.IsPaneOpen = false;
                }
                else
                {
                    MainView.Navigate(typeof(UserWelcome));
                    SplitVIew.IsPaneOpen = false;
                }
            }*/
        }

        private async void UnsignedError()
        {
            MessageDialog save = new MessageDialog("You haven't sign up", "Message");
            save.Commands.Add(new UICommand("ok", uicommand =>
            {
                ;
            })
            );
            await save.ShowAsync();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }
    }
}
