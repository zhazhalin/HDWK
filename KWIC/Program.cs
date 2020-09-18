using Kwic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWIC
{
    class Program
    {
        static void Main(string[] args)
        {
            /* FileStream fr = new FileStream("d:\\input.txt", FileMode.Open);
             FileStream fw = new FileStream("d:\\output.txt", FileMode.Create);
             Pipe in_cs,cs_al,al_ou;
             in_cs = new Pipe();
             cs_al = new Pipe();
             al_ou = new Pipe();
             Input_Filter input = new Input_Filter(fr, in_cs);// 装配Input_Filter过滤器输入fs，输出 管道//p1
             Circular_shift cs = new Circular_shift(in_cs, cs_al);// //装配Circular_shift过滤器输入管道//in_cs，输出 管道cs_al
             Alphabetizer al = new Alphabetizer(cs_al, al_ou);//装配Circular_shift过滤器输入管道cs_al，输出 管道//al_ou
             Output_Filter of = new Output_Filter(al_ou, fw);
             input.run();
             cs.run();//启动 移位过滤器
             al.run();
             of.run();
             //输出in_cs管道数据 观察和input.txt文件内容是否一致
             String str;
             while((str=al_ou.Read())!=null)
             Console.WriteLine(str);
             Console.Read();*/
            FileStream fr = new FileStream("d:\\input.txt", FileMode.Open);
            Pipe in_cs, cs_al, al_ou;
            in_cs = new Pipe();
            Input_Filter input = new Input_Filter(fr, in_cs);// 装配Input_Filter过滤器输入fs，输出 管道//p1
            input.run();

            //输出in_cs管道数据 观察和input.txt文件内容是否一致
            String str;
            while ((str = in_cs.Read()) != null)
                Console.WriteLine(str);
            Console.Read();


        }


    }
}

