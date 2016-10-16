using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
using System.Collections;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI;
using Windows.Storage;
using Windows.UI.Popups;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace LifeTracer
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    
    public class DiaryTag
    {
        public string emoji { get; set; }
        public ArrayList tag { get; set; }
        public int background { get; set; }
    }

    public sealed partial class Diary : Page
    {
        private int addIco;
        private ArrayList tagContent = new ArrayList();//用来保存每一个button上面标注的tag的内容，需要传给搜索的模块，
                                                       //此外还有一个用来保存日记选择出来的emoji，存在一个string里面，例如happy，表情的名字在/assets/emotion里面
        private ImageBrush tagPlus = new ImageBrush();
        private ImageBrush emojiChange = new ImageBrush();
        private ImageBrush backgroundBrush = new ImageBrush();
        private Button[] tagList = new Button[7];
        private tagChoose tagInput;
        private StorageFile diary;
        private StorageFolder folder;
        private string emoji; //选emoji的
        private int background; //选背景图片的

        //从diarycontent移植过来的内容
        public string DiaryText;



        public Diary()
        {
            this.InitializeComponent();
            tagList[0] = tag0;
            tagList[1] = tag1;
            tagList[2] = tag2;
            tagList[3] = tag3;
            tagList[4] = tag4;
            tagList[5] = tag5;
            tagList[6] = tag6;
            addIco = 0;
            setPlusIco(tag0);
            emoji = "";
            background = 0;
        }
        //这个函数用来单击已经加上tag的button，让这个tag消失
        private void remove(int subscript)
        {
            int i = 0;
            tagContent.RemoveAt(subscript);
            for (i = 0; i < tagContent.Count; i++)
            {
                tagList[i].Content = tagContent[i].ToString();
            }
            //此时已经将需要删除的内容remove了，i为当时arraylist中元素的数量
            tagList[i].Content = "";
            if(i != 6)
                ButtonBackgroundClear(tagList[i + 1]);
            else
                ButtonBackgroundClear(tagList[i]);

            addIco--;
            setPlusIco(tagList[addIco]);
        }

        //背景颜色清空为白色
        private void ButtonBackgroundClear(Button button)
        {
            button.Background = new SolidColorBrush(Colors.Cyan);
            button.Opacity = 0.75;
        }

        private void setPlusIco(Button button)
        {
            tagPlus.ImageSource = new BitmapImage(new Uri("ms-appx:/Assets/add.png"));
            tagPlus.Stretch = Stretch.Uniform;
            button.Background = tagPlus;
        }

        private async void tag0_Click(object sender, RoutedEventArgs e)
        {
            if (addIco > 0)
            {
                remove(0);
            }
            else if(addIco == 0)
            {
                tagInput = new tagChoose();
                ContentDialog content_dialog = new ContentDialog()
                {
                    
                    Title = "Choose Tag",
                    Content= tagInput,
                    PrimaryButtonText = "确定",
                    SecondaryButtonText = "取消",
                    FullSizeDesired = false,
                };
                content_dialog.PrimaryButtonClick += (_s, _e) => {
                    tag0.Content = tagInput.tag();
                    tagContent.Add(tagInput.tag());
                    ButtonBackgroundClear(tag0);
                    setPlusIco(tag1);
                    tagInput.ChangeTag(tagInput.tag());
                    addIco++;
                };
                await content_dialog.ShowAsync();


            }
            else
            {
                ;
            }
        }

        private async void tag1_Click(object sender, RoutedEventArgs e)
        {
            if (addIco > 1)
            {
                remove(1);
            }
            else if (addIco == 1)
            {

                //这里写生成tag的弹窗
                tagInput = new tagChoose();
                ContentDialog content_dialog = new ContentDialog()
                {

                    Title = "Choose Tag",
                    Content = tagInput,
                    PrimaryButtonText = "确定",
                    SecondaryButtonText = "取消",
                    FullSizeDesired = false,
                };
                content_dialog.PrimaryButtonClick += (_s, _e) => {
                    tag1.Content = tagInput.tag();
                    tagContent.Add(tagInput.tag());
                    ButtonBackgroundClear(tag1);
                    setPlusIco(tag2);
                    tagInput.ChangeTag(tagInput.tag());
                    addIco++;
                };
                await content_dialog.ShowAsync();


            }
            else
            {
                ;
            }
        }

        private async void tag2_Click(object sender, RoutedEventArgs e)
        {
            if (addIco > 2)
            {
                remove(2);
            }
            else if (addIco == 2)
            {

                //这里写生成tag的弹窗
                tagInput = new tagChoose();
                ContentDialog content_dialog = new ContentDialog()
                {

                    Title = "Choose Tag",
                    Content = tagInput,
                    PrimaryButtonText = "确定",
                    SecondaryButtonText = "取消",
                    FullSizeDesired = false,
                };
                content_dialog.PrimaryButtonClick += (_s, _e) => {
                    tag2.Content = tagInput.tag();
                    tagContent.Add(tagInput.tag());
                    ButtonBackgroundClear(tag2);
                    setPlusIco(tag3);
                    tagInput.ChangeTag(tagInput.tag());
                    addIco++;
                };
                await content_dialog.ShowAsync();


            }
            else
            {
                ;
            }
        }

        private async void tag3_Click(object sender, RoutedEventArgs e)
        {
            if (addIco > 3)
            {
                remove(3);
            }
            else if (addIco == 3)
            {

                //这里写生成tag的弹窗
                tagInput = new tagChoose();
                ContentDialog content_dialog = new ContentDialog()
                {

                    Title = "Choose Tag",
                    Content = tagInput,
                    PrimaryButtonText = "确定",
                    SecondaryButtonText = "取消",
                    FullSizeDesired = false,
                };
                content_dialog.PrimaryButtonClick += (_s, _e) => {
                    tag3.Content = tagInput.tag();
                    tagContent.Add(tagInput.tag());
                    ButtonBackgroundClear(tag3);
                    setPlusIco(tag4);
                    tagInput.ChangeTag(tagInput.tag());
                    addIco++;
                };
                await content_dialog.ShowAsync();

                
            }
            else
            {
                ;
            }
        }

        private async void tag4_Click(object sender, RoutedEventArgs e)
        {
            if (addIco > 4)
            {
                remove(4);
            }
            else if (addIco == 4)
            {

                //这里写生成tag的弹窗
                tagInput = new tagChoose();
                ContentDialog content_dialog = new ContentDialog()
                {

                    Title = "Choose Tag",
                    Content = tagInput,
                    PrimaryButtonText = "确定",
                    SecondaryButtonText = "取消",
                    FullSizeDesired = false,
                };
                content_dialog.PrimaryButtonClick += (_s, _e) => {
                    tag4.Content = tagInput.tag();
                    tagContent.Add(tagInput.tag());
                    ButtonBackgroundClear(tag4);
                    setPlusIco(tag5);
                    tagInput.ChangeTag(tagInput.tag());
                    addIco++;
                };
                await content_dialog.ShowAsync();


            }
            else
            {
                ;
            }
        }

        private async void tag5_Click(object sender, RoutedEventArgs e)
        {
            if (addIco > 5)
            {
                remove(5);
            }
            else if (addIco == 5)
            {

                //这里写生成tag的弹窗
                tagInput = new tagChoose();
                ContentDialog content_dialog = new ContentDialog()
                {

                    Title = "Choose Tag",
                    Content = tagInput,
                    PrimaryButtonText = "确定",
                    SecondaryButtonText = "取消",
                    FullSizeDesired = false,
                };
                content_dialog.PrimaryButtonClick += (_s, _e) => {
                    tag5.Content = tagInput.tag();
                    tagContent.Add(tagInput.tag());
                    ButtonBackgroundClear(tag5);
                    setPlusIco(tag6);
                    tagInput.ChangeTag(tagInput.tag());
                    addIco++;
                };
                await content_dialog.ShowAsync();


            }
            else
            {
                ;
            }
        }

        private async void tag6_Click(object sender, RoutedEventArgs e)
        {
            if (addIco > 6)
            {
                remove(6);
            }
            else if (addIco == 6)
            {

                //这里写生成tag的弹窗
                tagInput = new tagChoose();
                ContentDialog content_dialog = new ContentDialog()
                {

                    Title = "Choose Tag",
                    Content = tagInput,
                    PrimaryButtonText = "确定",
                    SecondaryButtonText = "取消",
                    FullSizeDesired = false,
                };
                content_dialog.PrimaryButtonClick += (_s, _e) => {
                    tag6.Content = tagInput.tag();
                    tagContent.Add(tagInput.tag());
                    ButtonBackgroundClear(tag6);
                    addIco++;
                    tagInput.ChangeTag(tagInput.tag());
                };
                await content_dialog.ShowAsync();


            }
            else
            {
                ;
            }
        }


        //这个按钮用来传值和navigate,这个方法做了修改，覆盖就好，XAML直接全部换成最新的就好


        //下面是部分新添加的内容
        private void smiling_Click(object sender, RoutedEventArgs e)
        {
            emoji = "sminling";
            emojiChange.ImageSource = new BitmapImage(new Uri("ms-appx:/Assets/emotion/smiling.png"));
            emojiChange.Stretch = Stretch.Uniform;
            SelectEmoji.Background = emojiChange;
            EmojiSelecter.Hide();
        }

        private void happy_Click(object sender, RoutedEventArgs e)
        {
            emoji = "happy";
            emojiChange.ImageSource = new BitmapImage(new Uri("ms-appx:/Assets/emotion/happy.png"));
            emojiChange.Stretch = Stretch.Uniform;
            SelectEmoji.Background = emojiChange;
            EmojiSelecter.Hide();
        }

        private void boring_Click(object sender, RoutedEventArgs e)
        {
            emoji = "boring";
            emojiChange.ImageSource = new BitmapImage(new Uri("ms-appx:/Assets/emotion/boring.png"));
            emojiChange.Stretch = Stretch.Uniform;
            SelectEmoji.Background = emojiChange;
            EmojiSelecter.Hide();
        }

        private void sad_Click(object sender, RoutedEventArgs e)
        {
            emoji = "sad";
            emojiChange.ImageSource = new BitmapImage(new Uri("ms-appx:/Assets/emotion/sad.png"));
            emojiChange.Stretch = Stretch.Uniform;
            SelectEmoji.Background = emojiChange;
            EmojiSelecter.Hide();
        }

        private void depressed_Click(object sender, RoutedEventArgs e)
        {
            emoji = "depressed";
            emojiChange.ImageSource = new BitmapImage(new Uri("ms-appx:/Assets/emotion/depressed.png"));
            emojiChange.Stretch = Stretch.Uniform;
            SelectEmoji.Background = emojiChange;
            EmojiSelecter.Hide();
        }

        private void jealous_Click(object sender, RoutedEventArgs e)
        {
            emoji = "jealous";
            emojiChange.ImageSource = new BitmapImage(new Uri("ms-appx:/Assets/emotion/jealous.png"));
            emojiChange.Stretch = Stretch.Uniform;
            SelectEmoji.Background = emojiChange;
            EmojiSelecter.Hide();
        }

        private void plain_Click(object sender, RoutedEventArgs e)
        {
            emoji = "plain";
            emojiChange.ImageSource = new BitmapImage(new Uri("ms-appx:/Assets/emotion/plain.png"));
            emojiChange.Stretch = Stretch.Uniform;
            SelectEmoji.Background = emojiChange;
            EmojiSelecter.Hide();
        }

        private void upset_Click(object sender, RoutedEventArgs e)
        {
            emoji = "upset";
            emojiChange.ImageSource = new BitmapImage(new Uri("ms-appx:/Assets/emotion/upset.png"));
            emojiChange.Stretch = Stretch.Uniform;
            SelectEmoji.Background = emojiChange;
            EmojiSelecter.Hide();
        }

        private void bg1_Checked(object sender, RoutedEventArgs e)
        {
            background = 1;
            backgroundBrush.ImageSource = new BitmapImage(new Uri("ms-appx:/Assets/background/bg" + background.ToString() + ".jpg"));
            backgroundBrush.Stretch = Stretch.UniformToFill;
            ShowBackground.Background = backgroundBrush;
        }

        private void bg2_Checked(object sender, RoutedEventArgs e)
        {
            background = 2;
            backgroundBrush.ImageSource = new BitmapImage(new Uri("ms-appx:/Assets/background/bg" + background.ToString() + ".jpg"));
            backgroundBrush.Stretch = Stretch.UniformToFill;
            ShowBackground.Background = backgroundBrush;
        }

        private void bg3_Checked(object sender, RoutedEventArgs e)
        {
            background = 3;
            backgroundBrush.ImageSource = new BitmapImage(new Uri("ms-appx:/Assets/background/bg" + background.ToString() + ".jpg"));
            backgroundBrush.Stretch = Stretch.UniformToFill;
            ShowBackground.Background = backgroundBrush;
        }

        private void bg4_Checked(object sender, RoutedEventArgs e)
        {
            background = 4;
            backgroundBrush.ImageSource = new BitmapImage(new Uri("ms-appx:/Assets/background/bg" + background.ToString() + ".jpg"));
            backgroundBrush.Stretch = Stretch.UniformToFill;
            ShowBackground.Background = backgroundBrush;
        }

        private void bg5_Checked(object sender, RoutedEventArgs e)
        {
            background = 5;
            backgroundBrush.ImageSource = new BitmapImage(new Uri("ms-appx:/Assets/background/bg" + background.ToString() + ".jpg"));
            backgroundBrush.Stretch = Stretch.UniformToFill;
            ShowBackground.Background = backgroundBrush;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DiaryText = textBox.Text;
        }

        private void bg1_Click(object sender, RoutedEventArgs e)
        {
            background = 1;
            backgroundBrush.ImageSource = new BitmapImage(new Uri("ms-appx:/Assets/background/bg" + background.ToString() + ".jpg"));
            backgroundBrush.Stretch = Stretch.UniformToFill;
            ShowBackground.Background = backgroundBrush;
        }

        private void bg2_Click(object sender, RoutedEventArgs e)
        {
            background = 2;
            backgroundBrush.ImageSource = new BitmapImage(new Uri("ms-appx:/Assets/background/bg" + background.ToString() + ".jpg"));
            backgroundBrush.Stretch = Stretch.UniformToFill;
            ShowBackground.Background = backgroundBrush;
        }

        private void bg3_Click(object sender, RoutedEventArgs e)
        {
            background = 3;
            backgroundBrush.ImageSource = new BitmapImage(new Uri("ms-appx:/Assets/background/bg" + background.ToString() + ".jpg"));
            backgroundBrush.Stretch = Stretch.UniformToFill;
            ShowBackground.Background = backgroundBrush;
        }

        private void bg4_Click(object sender, RoutedEventArgs e)
        {
            background = 4;
            backgroundBrush.ImageSource = new BitmapImage(new Uri("ms-appx:/Assets/background/bg" + background.ToString() + ".jpg"));
            backgroundBrush.Stretch = Stretch.UniformToFill;
            ShowBackground.Background = backgroundBrush;
        }

        private void bg5_Click(object sender, RoutedEventArgs e)
        {
            background = 5;
            backgroundBrush.ImageSource = new BitmapImage(new Uri("ms-appx:/Assets/background/bg" + background.ToString() + ".jpg"));
            backgroundBrush.Stretch = Stretch.UniformToFill;
            ShowBackground.Background = backgroundBrush;
        }

        private void bg6_Click(object sender, RoutedEventArgs e)
        {
            background = 6;
            backgroundBrush.ImageSource = new BitmapImage(new Uri("ms-appx:/Assets/background/bg" + background.ToString() + ".jpg"));
            backgroundBrush.Stretch = Stretch.UniformToFill;
            ShowBackground.Background = backgroundBrush;
        }

        private void bg7_Click(object sender, RoutedEventArgs e)
        {
            background = 7;
            backgroundBrush.ImageSource = new BitmapImage(new Uri("ms-appx:/Assets/background/bg" + background.ToString() + ".jpg"));
            backgroundBrush.Stretch = Stretch.UniformToFill;
            ShowBackground.Background = backgroundBrush;
        }

        private async void next_Click(object sender, RoutedEventArgs e)
        {
            if (emoji.Length == 0)
            {
                MessageDialog saves = new MessageDialog("Please choose your mood", "Message");
                saves.Commands.Add(new UICommand("ok"));
                await saves.ShowAsync();
                return;
            }
            if (background == 0)
            {
                MessageDialog saves = new MessageDialog("Please choose your background", "Message");
                saves.Commands.Add(new UICommand("ok"));
                await saves.ShowAsync();
                return;
            }


            //从diarycontent移植过来的代码
            string fileName;
            DateTime currentTime = DateTime.Now;
            fileName = currentTime.Year.ToString() + "-" + currentTime.Month.ToString() + "-" + currentTime.Day.ToString();
            folder = ApplicationData.Current.LocalFolder;
            diary = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);

            using (Stream file = await diary.OpenStreamForWriteAsync())
            {
                using (StreamWriter diaryWriter = new StreamWriter(file))
                {
                    diaryWriter.Write(DiaryText);
                    int[] createTime = new int[3];
                    createTime[0] = currentTime.Year;
                    createTime[1] = currentTime.Month;
                    createTime[2] = currentTime.Day;
                    DailyDiary newDialyDiary = new DailyDiary(emoji, createTime, background, tagContent, fileName);
                    DiaryManage.addDiary(newDialyDiary);
                }
            }

            MessageDialog save = new MessageDialog("Save successfully", "Message");
            save.Commands.Add(new UICommand("ok", uicommand =>
            {
                Frame.Navigate(typeof(UserWelcome));
            })
            );
            await save.ShowAsync();
        }


    }
}
