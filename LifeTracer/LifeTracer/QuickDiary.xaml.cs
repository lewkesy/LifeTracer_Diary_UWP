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
    
    public sealed partial class QuickDiary : Page
    {
        QuickDiaryObjective QuickDiaryObject = new QuickDiaryObjective();
        //这个QuickDiaryObject里面存了QuickDiary的emoji和content，存QuickDiary的时候把这个东西传到存储的.cs里面运行就好
        string sentence;
        public QuickDiary()
        {
            this.InitializeComponent();
        }

        private void QuickDiaryContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            sentence = QuickDiaryContent.Text;
            QuickDiaryObject.setQuickDiary(sentence);
        }

        private void smiling_Click(object sender, RoutedEventArgs e)
        {
            QuickDiaryObject.setEmoji("smiling");

        }
        //现在需要做的工作是将所选择的emoji的背景换掉，并且以此只能选择一个emoji，如果选择了多个则取最新选择的那个，学一下
        private void happy_Click(object sender, RoutedEventArgs e)
        {
            QuickDiaryObject.setEmoji("happy");
        }

        private void boring_Click(object sender, RoutedEventArgs e)
        {
            QuickDiaryObject.setEmoji("boring");
        }

        private void sad_Click(object sender, RoutedEventArgs e)
        {
            QuickDiaryObject.setEmoji("sad");
        }

        private void depressed_Click(object sender, RoutedEventArgs e)
        {
            QuickDiaryObject.setEmoji("depressed");
        }

        private void jealous_Click(object sender, RoutedEventArgs e)
        {
            QuickDiaryObject.setEmoji("jealous");
        }

        private void plain_Click(object sender, RoutedEventArgs e)
        {
            QuickDiaryObject.setEmoji("plain");
        }

        private void upset_Click(object sender, RoutedEventArgs e)
        {
            QuickDiaryObject.setEmoji("upset");
        }

        //跳转到成功签到这个activity，并且将objective传到数据库中
        private async void ensure_Click(object sender, RoutedEventArgs e)
        {
            if (QuickDiaryObject.getEmoji().Length == 0)
            {
                MessageDialog saves = new MessageDialog("Please choose your mood", "Message");
                saves.Commands.Add(new UICommand("ok"));
                await saves.ShowAsync();
                return;
            }
            DateTime currentTime = DateTime.Now;
            int[] createTime = new int[3];
            createTime[0] = currentTime.Year;
            createTime[1] = currentTime.Month;
            createTime[2] = currentTime.Day;
            QuicDiary newQuickDiary = new QuicDiary(QuickDiaryObject.getEmoji(), createTime, QuickDiaryObject.getQuickDiary());
            DiaryManage.addQuickDiary(newQuickDiary);

            MessageDialog save = new MessageDialog("Save successfully", "Message");
            save.Commands.Add(new UICommand("ok", uicommand =>
            {
                Frame.Navigate(typeof(UserWelcome));
            })
            );
            await save.ShowAsync();
        }

        private async void cancel_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog save = new MessageDialog("Are you sure to go back without saving?", "Message");
            save.Commands.Add(new UICommand("ok", uicommand =>
            {
                Frame.Navigate(typeof(Welcome));
            })
            );
            save.Commands.Add(new UICommand("no"));
            await save.ShowAsync();
        }



    }
}
