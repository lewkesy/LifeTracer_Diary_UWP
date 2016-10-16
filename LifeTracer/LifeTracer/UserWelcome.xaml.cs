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
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace LifeTracer
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    class TargetDiary
    {
        public Boolean dExist { get; set; }
        public Boolean qExist { get; set; }
        public int dIndex { get; set; }
        public int qIndex { get; set; }
    }

    public sealed partial class UserWelcome : Page
    {
        

        public UserWelcome()
        {
            this.InitializeComponent();
            DateTime currentTime = DateTime.Now;
            int year = (int)DataUnit.GetData("7");
            int month = (int)DataUnit.GetData("8");
            int day = (int)DataUnit.GetData("9");
            DateTime StartTime = new DateTime( (int)DataUnit.GetData("7"), (int)DataUnit.GetData("8"), (int)DataUnit.GetData("9"));
            int totalDiarys = DiaryManage.getCount();

            int totalDays = (int)currentTime.Subtract(StartTime).TotalDays;
            if (totalDays == 0)
            {
                cal.Text = "欢迎使用Life Tracer~愿与你共度未来的长久时光~";
            }
            else
            {
                cal.Text = "Life Tracer已经陪你走过了" + totalDays + "天，这些天里你一共写过" + totalDiarys +
                    "篇日记";
                float ratio = (float)totalDiarys / (float)totalDays;
                if (ratio >= 0.7)
                {
                    tips.Text = "当前写日记习惯非常良好，请继续保持~";
                }
                else if (ratio >= 0.4)
                {
                    tips.Text = "写日记是个好习惯，再接再厉~";
                }
                else
                {
                    tips.Text = "最近工作繁忙吗？最好不要放弃写日记的习惯~";
                }
            }
        }

       
    }
}
