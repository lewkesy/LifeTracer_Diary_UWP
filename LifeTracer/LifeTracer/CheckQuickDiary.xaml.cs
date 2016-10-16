using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    public sealed partial class CheckQuickDiary : Page
    {
        private StorageFolder folder;
        private StorageFile QuickDiaryFile;
        public CheckQuickDiary()
        {
            this.InitializeComponent();
            ShowResult();
        }

        private async void ShowResult()
        {
            folder = ApplicationData.Current.LocalFolder;
            QuickDiaryFile = await folder.GetFileAsync("QuickDiaryCharts.ltr");


            using (Stream file = await QuickDiaryFile.OpenStreamForReadAsync())
            {
                if (file.Length == 0) return;
                using (StreamReader chartsReader = new StreamReader(file))
                {
                    while (!chartsReader.EndOfStream)
                    {
                        int i, j;
                        string Content;
                        string emotion;
                        int[] createTime = new int[3];
                        string ShowContent;
                        string temp = chartsReader.ReadLine();

                        for (i = 0; temp[i] != ' '; ++i) ;
                        emotion = temp.Substring(0, i);
                        while (temp[++i] == ' ') ;

                        for (j = 0; temp[i + j] >= '0' && temp[i + j] <= '9'; ++j) ;
                        createTime[0] = Int32.Parse(temp.Substring(i, j));
                        ShowContent = createTime[0].ToString() + " ";
                        i = i + j;
                        while (temp[++i] == ' ') ;

                        for (j = 0; temp[i + j] >= '0' && temp[i + j] <= '9'; ++j) ;
                        createTime[1] = Int32.Parse(temp.Substring(i, j));
                        ShowContent += createTime[1].ToString() + " ";
                        i = i + j;
                        while (temp[++i] == ' ') ;

                        for (j = 0; temp[i + j] >= '0' && temp[i + j] <= '9'; ++j) ;
                        createTime[2] = Int32.Parse(temp.Substring(i, j));
                        ShowContent += createTime[2].ToString() + "  ";
                        i = i + j;
                        ShowContent += "心情: " + emotion + " ";
                        while (temp[++i] == ' ') ;
                        for (j = 0; i + j < temp.Length; ++j) ;
                        Content = temp.Substring(i, j);
                        ShowContent += "每天一句话: " + Content;

                        ListViewItem item = new ListViewItem();
                        item.Content = ShowContent;
                        item.FontSize = 34;
                        QuickDiaryList.Items.Add(item);

                    }
                }
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Search));
        }
    }
}
