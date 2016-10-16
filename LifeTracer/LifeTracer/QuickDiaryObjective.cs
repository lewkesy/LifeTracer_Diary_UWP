using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace LifeTracer
{
    class QuickDiaryObjective
    {
        string emoji = "";
        string QuickDiary = "";

        public async void setEmoji(string input_emoji)
        {
            if (input_emoji != null)
            {
                emoji = "";
                for (int i = 0; i < input_emoji.Length; i++)
                {
                    emoji += input_emoji.Substring(i, 1);
                }
            }
            else
            {
                MessageDialog save = new MessageDialog("Please choose your mood", "Message");
                save.Commands.Add(new UICommand("ok"));
                await save.ShowAsync();
            }
        }

        public void setQuickDiary(string sentence)
        {
            QuickDiary = "";
            if (sentence != null)
            {
                for (int i = 0; i < sentence.Length; i++)
                {
                    QuickDiary += sentence.Substring(i, 1);
                }
            }
        }

        public string getEmoji()
        {
            return emoji;
        }

        public string getQuickDiary()
        {
            return QuickDiary;
        }
    }
}
