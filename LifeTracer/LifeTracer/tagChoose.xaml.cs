using System;
using System.Collections;
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


namespace LifeTracer
{
    public sealed partial class tagChoose : UserControl
    {
        private string tagInputContent;
        private bool NewTag = true;
        private ListBoxItem []TagList = new ListBoxItem[5];

        public tagChoose()
        {
            this.InitializeComponent();
            TagList = new ListBoxItem[5];
            TagList[0] = tag1;
            TagList[1] = tag2;
            TagList[2] = tag3;
            TagList[3] = tag4;
            TagList[4] = tag5;

            int i = 0;
            while(DataUnit.GetData(i.ToString()) != null && i < 5)
            {
                TagList[i].Content = DataUnit.GetData(i.ToString()) as string;
                i++;
            }
            for(;i < 5; i++)
            {
                TagList[i].Content = "";
            }

        }

        private void tagInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            tagInputContent = tagInput.Text;
        }

        public string tag()
        {
            return tagInputContent;
        }

        private void RecentTag_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tag1.IsSelected && tag1.Content.ToString() != "没有最近添加的tag")
            {
                tagInput.Text = tag1.Content.ToString();
                NewTag = false;
            }
            else if (tag2.IsSelected)
            {
                tagInput.Text = tag2.Content.ToString();
                NewTag = false;
            }
            else if (tag3.IsSelected)
            {
                tagInput.Text = tag3.Content.ToString();
                NewTag = false;
            }
            else if (tag4.IsSelected)
            {
                tagInput.Text = tag4.Content.ToString();
                NewTag = false;
            }
            else if (tag5.IsSelected)
            {
                tagInput.Text = tag5.Content.ToString();
                NewTag = false;
            }
        }

        public void ChangeTag(string ChoosedTag)
        {
            for (int i = 0; i < 5 && TagList[i] != null; i++)
            {
                if(TagList[i].Content.ToString() == ChoosedTag)
                {
                    NewTag = false;
                    break;
                }
            }
            if (NewTag)
            {
                for(int i = 4; i != 0; i--)
                {
                    TagList[i].Content = TagList[i - 1].Content;
                }
                TagList[0].Content = ChoosedTag;
            }
            for(int i = 0; i < 5 && ChoosedTag != null; i++)
            {
                DataUnit.SaveData(i.ToString(), TagList[i].Content.ToString());
            }
        }
    }
}
