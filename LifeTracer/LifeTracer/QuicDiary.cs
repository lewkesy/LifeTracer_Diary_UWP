using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeTracer
{
    class QuicDiary
    {
        private string emotion;
        private int[] createTime;
        private string content;

        public QuicDiary(string emotion, int[] createTime, string content)
        {
            this.emotion = emotion;
            this.createTime = new int[3];
            this.createTime[0] = createTime[0];
            this.createTime[1] = createTime[1];
            this.createTime[2] = createTime[2];
            this.content = content;
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

        public string getContent()
        {
            return content;
        }
    }
}
