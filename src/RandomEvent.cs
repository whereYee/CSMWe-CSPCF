using System;
using System.Collections.Generic;
using Akequ.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Additional
{
    class RandomEvent : Room
    {
        public override void Init()
        {
            this.OnInit();
            this.Updata();
        }

        public void addTimer(Action action, float time, int id)
        {
            Invoke(action, time);
            Invoke(() =>
            {
                OnEventFinish(id);
            }, time);
        }

        public void Updata()
        {
            Invoke(() =>
            {
                this.OnUpData();
            }, 60);
        }

        public virtual void OnInit()
        {

        }

        public virtual void OnUpData()
        {

        }

        public virtual void OnEventFinish(int id)
        {

        }
    }
}

