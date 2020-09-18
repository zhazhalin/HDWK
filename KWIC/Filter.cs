using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWIC
{
    public abstract class Filter
    {
        protected Pipe inpipe;
        protected Pipe outpipe;
        public Filter()
        {
        }
        public Filter(Pipe pipeinput, Pipe pipeoutput)
        {
            //构造函数对 inpipe和outpipe 初始化
            this.inpipe = pipeinput;
            this.outpipe = pipeoutput;
        }
        public abstract void transform(); //抽象函数 完成过滤器的处理
        public void run()
        {
            try
            {
                transform();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
