﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using KWIC;

namespace Kwic
{
    class Alphabetizer : Filter
    {
        public Alphabetizer(Pipe input, Pipe output) : base(input, output) //初始化基类的inpipe和outpipe管//道子对象
        {
            this.inpipe = input;
            this.outpipe = output;
        }
        public override void transform()
        {

            String str;
            ArrayList al = new ArrayList();
            //基本思想：从inpipe管道中调用Read方法读出字符串到str，然后将str放入al动态数组中，//直到所有字符串到放入al中
            //对al调用sort方法 排序
            //最后将al中的每个元素写入outpipe管道中
            //以下 自己编程实现 以上思想
            while ((str=inpipe.Read() )!= null)
            {
                al.Add(str);
            }
            al.Sort();
            for(int i = 0; i < al.Count; i++)
            {
                outpipe.Write((String)al[i]);
            }
        }
    }
}
