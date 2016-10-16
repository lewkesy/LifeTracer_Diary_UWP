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
    public sealed partial class Search : Page
    {
        private int startYear;
        private int startMonth;
        private int startDay;
        private int endYear;
        private int endMonth;
        private int endDay;
        private string mood;
        private Boolean restrictMood;
        private ArrayList results;
        private string[] keyWords;
        private int kwCount;

        public Search()
        {
            this.InitializeComponent();
            filterMood.SelectedIndex = 0;
            filterYear1.SelectedIndex = 0;
            filterYear2.SelectedIndex = 0;
            filterMonth1.SelectedIndex = 0;
            filterMonth2.SelectedIndex = 0;
            filterDay1.SelectedIndex = 0;
            filterDay2.SelectedIndex = 0;
        }

        private void getKeyWords()
        {
            string temp = SearchContent.Text;
            int i = -1;
            int n;
            kwCount = 0;
            keyWords = new string[5];
            if (temp.Length == 0) return;
            while (i < temp.Length && temp[++i] == ' ') ;
            for(n = 0; n < 5; ++n)
            {
                int j;
                for (j = 0; i + j < temp.Length && temp[i + j] != ' '; ++j) ;
                keyWords[n] = temp.Substring(i, j);
                i += j;
                while (i < temp.Length && temp[++i] == ' ') ;
                if(i == temp.Length)
                {
                    kwCount++;
                    break;
                }
            }
            kwCount += n;
        }

        private void beginSearch_Click(object sender, RoutedEventArgs e)
        {
            getKeyWords();
            startYear = (filterYear1.SelectedIndex == 0) ? 2016 : Int32.Parse(filterYear1.SelectedItem.ToString());
            endYear = (filterYear2.SelectedIndex == 0) ? 2050 : Int32.Parse(filterYear2.SelectedItem.ToString());
            startMonth = Int32.Parse(filterMonth1.SelectedItem.ToString());
            endMonth = Int32.Parse(filterMonth2.SelectedItem.ToString());
            startDay = Int32.Parse(filterDay1.SelectedItem.ToString());
            endDay = Int32.Parse(filterDay2.SelectedItem.ToString());
            restrictMood = (filterMood.SelectedIndex == 0) ? false : true;
            mood = filterMood.SelectedItem.ToString();
            results = new ArrayList();
            int i;
            for(i = 0; i < DiaryManage.getCount(); ++i)
            {
                DailyDiary temp = DiaryManage.getDiary(i);
                if (temp.getYear() >= startYear && temp.getMonth() >= startMonth && temp.getDay() >= startDay)
                {
                    break;
                }
            }
            for(; i < DiaryManage.getCount(); ++i)
            {
                DailyDiary temp = DiaryManage.getDiary(i);
                if (temp.getYear() > endYear || 
                    temp.getYear() == endYear && temp.getMonth() > endMonth ||
                    temp.getYear() == endYear && temp.getMonth() == endMonth && temp.getDay() > endDay)
                {
                    break;
                }
                if (restrictMood && !mood.Equals(temp.getEmotion()))
                {
                    continue;
                }
                ArrayList tempTags = temp.getTags();
                Boolean flag1 = true;
                for(int n = 0; n < kwCount; ++n)
                {
                    Boolean flag2 = false;
                    for(int j = 0; j < tempTags.Count; ++j)
                    {
                        if (keyWords[n].Equals(tempTags[j]))
                        {
                            flag2 = true;
                            break;
                        }
                    }
                    if (!flag2)
                    {
                        flag1 = false;
                        break;
                    }
                }
                if (flag1 || kwCount == 0)
                {
                    results.Add(i);
                }
            }
            Frame.Navigate(typeof(SearchResults), results);
        }

        private void QuickSearch_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CheckQuickDiary));
        }
    }
}
