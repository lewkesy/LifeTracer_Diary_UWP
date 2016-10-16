using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.Storage;
using System.Collections;
using System.Threading.Tasks;
using System.IO;

namespace LifeTracer
{
    class DailyDiary
    {
        private string emotion;
        private string content;
        private int[] createTime;
        private int background;
        private Boolean haveRead;
        private ArrayList tags = new ArrayList();
        private string fileName;
        private StorageFolder folder;
        private StorageFile chart;

        public DailyDiary(string emotion, int[] createTime, int background, ArrayList tags, string fileName)
        {
            this.tags = new ArrayList();
            this.emotion = emotion;
            this.createTime = new int[3];
            this.createTime[0] = createTime[0];
            this.createTime[1] = createTime[1];
            this.createTime[2] = createTime[2];
            this.background = background;
            for (int i = 0; i < tags.Count; ++i)
            {
                this.tags.Add(tags[i]);
            }
            this.fileName = fileName;
        }

        public string getEmotion()
        {
            return emotion;
        }

        public int getYear()
        {
            return createTime[0];
        }

        public int getMonth()
        {
            return createTime[1];
        }

        public int getDay()
        {
            return createTime[2];
        }

        public ArrayList getTags()
        {
            return tags;
        }

        public int getBackground()
        {
            return background;
        }

        public string getFileName()
        {
            return fileName;
        }

        public string getContent()
        {
            return content;
        }

        public Boolean getHaveRead()
        {
            return haveRead;
        }

        public async void readContent()
        {
            haveRead = false;
            folder = ApplicationData.Current.LocalFolder;
            chart = await folder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);


            using (Stream file = await chart.OpenStreamForReadAsync())
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    content = reader.ReadToEnd();
                    haveRead = true;
                }
            }
            
        } 
    }
}
