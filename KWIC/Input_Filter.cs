using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWIC
{
    public class Input_Filter:Filter
    {
        StreamReader Sr; //读取文件流
        public Input_Filter(FileStream fs, Pipe outpipe1)
            : base(null, outpipe1) //初始化基类继承来的 //outpipe子对象
        {
            //自己写代码 实现：利用fs 创建StreamReader 文本读取流对象Sr
            //fs = new FileStream();
             Sr = new StreamReader(fs);
        }
         public override void transform() //转换 将Sr文本输入流对象读取的每行字符串 写到 outpipe管道中
       {
           String st;
          //自己编程实现：通过循环不断从Sr流对象中，读取一行字符串存入st中， 并将st写入管道outpipe，直到Sr中读取的为null
           //int len = 0;
           while ((st=Sr.ReadLine()) != null)
           {
               //Console.WriteLine(len);
               //st = Sr.ReadLine();
               //char t = (char)len;
               outpipe.Write(st);
           }
          Sr.Close();
       }
    }
}
