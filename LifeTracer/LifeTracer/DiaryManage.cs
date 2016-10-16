using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace LifeTracer
{
    static class DiaryManage
    {
        private static DailyDiary[] Diarys;
        private static QuicDiary[] quickDiarys;
        private static int count;
        private static int qcount;
        private static string emotion;
        private static int[] createTime;
        private static int background;
        private static ArrayList tags;
        private static string fileName;
        private static string content;
        private static StorageFolder folder;
        private static StorageFile Chart;
        static DiaryManage()
        {
            Diarys = new DailyDiary[5000];
            quickDiarys = new QuicDiary[5000];
            count = 0;
            qcount = 0;
        }

        public static int getCount()
        {
            return count;
        }

        public static int getQcount()
        {
            return qcount;
        }

        public static DailyDiary getDiary(int index)
        {
            return Diarys[index];
        }

        public static QuicDiary getQuickDiary(int index)
        {
            return quickDiarys[index];
        }

        public static async void readData()
        {
            folder = ApplicationData.Current.LocalFolder;
            Chart = await folder.CreateFileAsync("DiaryCharts.ltr", CreationCollisionOption.OpenIfExists);
            using (Stream file = await Chart.OpenStreamForReadAsync())
            {
                if (file.Length == 0) return;
                using (StreamReader chartsReader = new StreamReader(file))
                {
                    while (!chartsReader.EndOfStream)
                    {
                        int i, j, tagn;
                        string[] tagData;
                        createTime = new int[3];
                        string temp = chartsReader.ReadLine();
                        for (i = 0; temp[i] != ' '; ++i) ;
                        emotion = temp.Substring(0, i);
                        while (temp[++i] == ' ') ;
                        for (j = 0; temp[i + j] >= '0' && temp[i + j] <= '9'; ++j) ;
                        createTime[0] = Int32.Parse(temp.Substring(i, j));
                        i = i + j;
                        while (temp[++i] == ' ') ;
                        for (j = 0; temp[i + j] >= '0' && temp[i + j] <= '9'; ++j) ;
                        createTime[1] = Int32.Parse(temp.Substring(i, j));
                        i = i + j;
                        while (temp[++i] == ' ') ;
                        for (j = 0; temp[i + j] >= '0' && temp[i + j] <= '9'; ++j) ;
                        createTime[2] = Int32.Parse(temp.Substring(i, j));
                        i = i + j;
                        while (temp[++i] == ' ') ;
                        for (j = 0; temp[i + j] >= '0' && temp[i + j] <= '9'; ++j) ;
                        background = Int32.Parse(temp.Substring(i, j));
                        i = i + j;
                        while (temp[++i] == ' ') ;
                        for (j = 0; temp[i + j] >= '0' && temp[i + j] <= '9'; ++j) ;
                        tagn = Int32.Parse(temp.Substring(i, j));
                        i = i + j;
                        tagData = new string[tagn];
                        for (int k = 0; k < tagn; ++k)
                        {
                            while (temp[++i] == ' ') ;
                            for (j = 0; temp[i + j] != ' '; ++j) ;
                            tagData[k] = temp.Substring(i, j);
                            i += j;
                        }
                        tags = new ArrayList(tagData);
                        while (temp[++i] == ' ') ;
                        for (j = 0; i + j < temp.Length; ++j) ;
                        fileName = temp.Substring(i, j);
                        Diarys[count++] = new DailyDiary(emotion, createTime, background, tags, fileName);
                    }
                }
            }
        }

        public async static void readQuickData()
        {
            folder = ApplicationData.Current.LocalFolder;
            Chart = await folder.CreateFileAsync("QuickDiaryCharts.ltr", CreationCollisionOption.OpenIfExists);
            using (Stream file = await Chart.OpenStreamForReadAsync())
            {
                if (file.Length == 0) return;
                using (StreamReader chartsReader = new StreamReader(file))
                {
                    while (!chartsReader.EndOfStream)
                    {
                        int i, j;
                        createTime = new int[3];
                        string temp = chartsReader.ReadLine();
                        for (i = 0; temp[i] != ' '; ++i) ;
                        emotion = temp.Substring(0, i);
                        while (temp[++i] == ' ') ;
                        for (j = 0; temp[i + j] >= '0' && temp[i + j] <= '9'; ++j) ;
                        createTime[0] = Int32.Parse(temp.Substring(i, j));
                        i = i + j;
                        while (temp[++i] == ' ') ;
                        for (j = 0; temp[i + j] >= '0' && temp[i + j] <= '9'; ++j) ;
                        createTime[1] = Int32.Parse(temp.Substring(i, j));
                        i = i + j;
                        while (temp[++i] == ' ') ;
                        for (j = 0; temp[i + j] >= '0' && temp[i + j] <= '9'; ++j) ;
                        createTime[2] = Int32.Parse(temp.Substring(i, j));
                        i = i + j;
                        while (temp[++i] == ' ') ;
                        for (j = 0; i + j < temp.Length; ++j) ;
                        content = temp.Substring(i, j);
                        quickDiarys[qcount++] = new QuicDiary(emotion, createTime, content);
                    }
                }
            }
        }

        public static void addDiary(DailyDiary newDiary)
        {
            Boolean cover = false;
            if (count > 0 && Diarys[count - 1].getFileName().Equals(newDiary.getFileName()))
            {
                Diarys[count - 1] = newDiary;
                cover = true;
            }
            else
            {
                Diarys[count++] = newDiary;
            }
            writeData(count - 1, cover);
        }

        public static void addQuickDiary(QuicDiary newQuickDiary)
        {
            Boolean cover = false;
            if (qcount > 0 && quickDiarys[qcount - 1].getYear() == newQuickDiary.getYear()
                && quickDiarys[qcount - 1].getMonth() == newQuickDiary.getMonth()
                && quickDiarys[qcount - 1].getDay() == newQuickDiary.getDay())
            {
                quickDiarys[qcount - 1] = newQuickDiary;
                cover = true;
            }
            else
            {
                quickDiarys[qcount++] = newQuickDiary;
            }
            writeQuickData(qcount - 1, cover);
        }

        public static async void writeData(int count, Boolean cover)
        {
            string[] lines = { " " };

            folder = ApplicationData.Current.LocalFolder;
            Chart = await folder.CreateFileAsync("DiaryCharts.ltr", CreationCollisionOption.OpenIfExists);
            using (Stream file = await Chart.OpenStreamForWriteAsync())
            {
                if (cover)
                {
                    using (StreamReader chartsReader = new StreamReader(file))
                    {
                        string fileData = chartsReader.ReadToEnd();
                        lines = fileData.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        string currentInfo = Diarys[count].getEmotion() + ' ' + Diarys[count].getYear() + ' '
                             + Diarys[count].getMonth() + ' ' + Diarys[count].getDay() + ' ' + Diarys[count].getBackground() + ' ' + Diarys[count].getTags().Count + ' ';
                        for (int i = 0; i < Diarys[count].getTags().Count; ++i)
                        {
                            currentInfo += Diarys[count].getTags()[i] + " ";
                        }
                        currentInfo += Diarys[count].getFileName();
                        lines[lines.Length - 1] = currentInfo;
                    }
                }
                else
                {
                    file.Seek(0, SeekOrigin.End);
                    using (StreamWriter chartsWriter = new StreamWriter(file))
                    {
                        chartsWriter.Write(Diarys[count].getEmotion() + ' ' + Diarys[count].getYear() + ' '
                             + Diarys[count].getMonth() + ' ' + Diarys[count].getDay() + ' ' + Diarys[count].getBackground() + ' ' + Diarys[count].getTags().Count + ' ');
                        for (int i = 0; i < Diarys[count].getTags().Count; ++i)
                        {
                            chartsWriter.Write(Diarys[count].getTags()[i]);
                            chartsWriter.Write(' ');
                        }
                        chartsWriter.WriteLine(Diarys[count].getFileName());
                    }
                }
            }

            if (cover)
            {
                Chart = await folder.CreateFileAsync("DiaryCharts.ltr", CreationCollisionOption.ReplaceExisting);
                using (Stream file = await Chart.OpenStreamForWriteAsync())
                {
                    using (StreamWriter chartsWriter = new StreamWriter(file))
                    {
                        for (int i = 0; i < lines.Length; ++i)
                        {
                            chartsWriter.WriteLine(lines[i]);
                        }
                    }
                }
            }

        }

        public static async void writeQuickData(int qcount, Boolean cover)
        {
            string[] lines = { " " };
            folder = ApplicationData.Current.LocalFolder;
            Chart = await folder.CreateFileAsync("QuickDiaryCharts.ltr", CreationCollisionOption.OpenIfExists);
            using (Stream file = await Chart.OpenStreamForWriteAsync())
            {
                if (cover)
                {
                    using (StreamReader chartsReader = new StreamReader(file))
                    {
                        string fileData = chartsReader.ReadToEnd();
                        lines = fileData.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        string currentInfo = quickDiarys[qcount].getEmotion() + ' ' + quickDiarys[qcount].getYear() + ' '
                             + quickDiarys[qcount].getMonth() + ' ' + quickDiarys[qcount].getDay() + ' ' + quickDiarys[qcount].getContent();
                        lines[lines.Length - 1] = currentInfo;
                    }
                }
                else
                {
                    file.Seek(0, SeekOrigin.End);
                    using (StreamWriter chartsWriter = new StreamWriter(file))
                    {
                        chartsWriter.WriteLine(quickDiarys[qcount].getEmotion() + ' ' + quickDiarys[qcount].getYear() + ' '
                             + quickDiarys[qcount].getMonth() + ' ' + quickDiarys[qcount].getDay() + ' ' + quickDiarys[qcount].getContent());
                    }
                }
            }
            if (cover)
            {
                Chart = await folder.CreateFileAsync("QuickDiaryCharts.ltr", CreationCollisionOption.ReplaceExisting);
                using (Stream file = await Chart.OpenStreamForWriteAsync())
                {
                    using (StreamWriter chartsWriter = new StreamWriter(file))
                    {
                        for (int i = 0; i < lines.Length; ++i)
                        {
                            chartsWriter.WriteLine(lines[i]);
                        }
                    }
                }
            }
        }
    }
}
