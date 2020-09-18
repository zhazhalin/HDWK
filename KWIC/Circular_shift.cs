using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;


namespace KWIC
{
    class Circular_shift : Filter
    {
        public Circular_shift(Pipe input, Pipe output) : base(input, output) //初始化 基类 管道
        {
            this.inpipe = input;
            this.outpipe = output;
        }
        public override void transform()
        {
            //循环从input管道中 读取 字符串，
            // 对每个字符串 处理：
            // （1）对每个字符串 分离单词 
            // （2)对分离的单词重新组合
            //直到字符串循环移位完成
            String str1;
            ArrayList al = new ArrayList(); //将每行分离的单词 放入al中
            StringBuilder sb = new StringBuilder();//重新构造字符串 单词间只包含一个空格
            String[] words; //分离单词 可用str1.split(‘ ‘)实现 并存放于words中

            while ((str1 = inpipe.Read()) != null) //对从输入管道中 读取每行进行处理，将移位后的//字符串 写入outpipe 管道中 
            {
                //自己编程实现  
                //需要实现的步骤：
                // 将str1按分隔符’ ‘分离单词,放入words数组中，由于字符串中有可能有多个空格，//所以需对words数组 进行再处理            
                //对words数组 进行再处理，将””空串去掉，保存与al中
                //将al中的元素 组合成新的单词字符串 到sb中 需要调用sb.append()方法，然后将//sb写到outpipe管道中

                words = str1.Split(' '); //先拆分每次读到的一行数据
                List<string> temp_words = new List<string>(); //建立一个临时数组，存放每次移位过的数组
                temp_words.Add(str1);  //首先先初始化数组，添加进去初始数组
                String temp_line = "";  //定义一个中间字符串，用于存放每次移位过的一行数据
                outpipe.Write(str1);
                for (int i = 0; i < words.Length-1; i++)  //用于移位的循环
                {
                    /*temp_line = temp_words[temp_words.Count - 1];  //首先每次获取到上一次移位的字符串
                    String lastWord = temp_line.Split(' ')[words.Length - 1];  //通过“ ”分隔符获取到最后一个单词 
                    String leftWord = temp_line.Substring(0, (temp_line.Length - lastWord.Length - 1));  //获取除了最后一个单词以外的单词
                    outpipe.Write(lastWord + " " + leftWord); //将移位后的字符串回写
                    temp_words.Add(lastWord + " " + leftWord);*/
                    temp_line = temp_words[temp_words.Count - 1]; //首先每次获取到上一次移位的字符串
                    String lastWord = temp_line.Split(' ')[0];    //通过“ ”分隔符获取到第一个单词       
                    //从第一个单词开始截取剩下的部分
                    String leftWord = temp_line.Substring(lastWord.Length+1, (temp_line.Length - lastWord.Length - 1));
                    outpipe.Write(leftWord + " " + lastWord); //将移位后的字符串回写
                    temp_words.Add(leftWord + " " + lastWord); //将当前移位过的字符串添加到List里
                }
            }  
        }
    }
 }
