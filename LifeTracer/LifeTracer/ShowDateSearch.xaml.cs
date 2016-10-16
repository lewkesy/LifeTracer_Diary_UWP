using System;
using System.Collections.Generic;
using System.IO;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace LifeTracer
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ShowDateSearch : Page
    {
        private TargetDiary target;
        private ImageBrush EmojiBrush = new ImageBrush();
        public ShowDateSearch()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.target = e.Parameter as TargetDiary;
            if (target.qExist)
            {
                QuickDiary.Text = DiaryManage.getQuickDiary(target.qIndex).getContent();
                EmojiBrush.ImageSource = new BitmapImage(new Uri("ms-appx:/Assets/emotion/" + DiaryManage.getQuickDiary(target.qIndex).getEmotion() +".png"));
                Emoji.Background = EmojiBrush;
            }
            else
            {
                QuickDiary.Text = "No QuickDiary record";
            }

            if (target.dExist)
            {
                //DiaryManage.getDiary(target.dIndex).readContent();
                while (!DiaryManage.getDiary(target.dIndex).getHaveRead()) ;
                DailyDiary.Text = DiaryManage.getDiary(target.dIndex).getContent();
            }
            else
            {
                DailyDiary.Text = "No diary record";
            }
        }
    }
}
