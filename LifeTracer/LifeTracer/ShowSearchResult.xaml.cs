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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace LifeTracer
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ShowSearchResult : Page
    {
        private int index;
        private ImageBrush Emotion = new ImageBrush();
        private ImageBrush GridBackground = new ImageBrush();
        private StorageFolder folder;
        private StorageFile file;
        public ShowSearchResult()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.index = (int)e.Parameter;
            folder = ApplicationData.Current.LocalFolder;
            file = await StorageFile.GetFileFromPathAsync(ApplicationData.Current.LocalFolder.Path +"\\" + DiaryManage.getDiary(index).getFileName());
            Emotion.ImageSource = new BitmapImage(new Uri("ms-appx:/Assets/emotion/" + DiaryManage.getDiary(index).getEmotion() + ".png"));
            GridBackground.ImageSource = new BitmapImage(new Uri("ms-appx:/Assets/background/bg" + DiaryManage.getDiary(index).getBackground().ToString() + ".jpg"));
            Emoji.Background = Emotion;
            background.Background = GridBackground;
            switch (DiaryManage.getDiary(index).getEmotion())
            {
                default:
                    Describtion.Text = "";
                    break;
                case "smiling":
                    Describtion.Text = "今天过的不错！~";
                    break;
                case "angry":Describtion.Text = "烦死了烦死了烦死了！！！"; break;
                case "boring":Describtion.Text = "=_= 今天好无聊啊"; break;
                case "depressed":Describtion.Text = "有些小失落……"; break;
                case "happy":Describtion.Text = "Oh~Year！太开心了！~>_<!!"; break;
                case "jealous":Describtion.Text = "哼，那些家伙肯定作弊了！"; break;
                case "sad":Describtion.Text = "T_T 欲语泪先流……"; break;
                case "upsetting": Describtion.Text = "唉……"; break;
                

            }
            //下面一句写QuickDiary的text内容
            using (Stream diary = await file.OpenStreamForReadAsync())
            {
                using (StreamReader read = new StreamReader(diary))
                {
                    DailyDiary.Text = read.ReadToEnd();
                }
            }
        }
    }
}
