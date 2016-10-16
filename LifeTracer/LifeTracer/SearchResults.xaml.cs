using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class SearchResults : Page
    {
        private ArrayList results;
        public SearchResults()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.results = e.Parameter as ArrayList;
            showResults();
        }

        private void showResults()
        {
            if(results.Count != 0)
            {
                noResult.Visibility = Visibility.Collapsed;
                foreach(int i in results)
                {
                    DailyDiary temp = DiaryManage.getDiary(i);
                    string diaryDate = temp.getYear().ToString() + "年" + temp.getMonth().ToString() + '月' + temp.getDay().ToString() + "日";
                    ListViewItem diaryItem = new ListViewItem();
                    diaryItem.Content = diaryDate;
                    diaryItem.FontSize = 48;
                    diaryItem.Name = i.ToString();
                    resultsList.Items.Add(diaryItem);
                }
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Search));
        }

        private void resultsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListViewItem temp = resultsList.SelectedItem as ListViewItem;
            int index = Int32.Parse(temp.Name);
            Frame.Navigate(typeof(ShowSearchResult), index);
        }
    }
}
