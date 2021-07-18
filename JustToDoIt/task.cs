using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustToDoIt
{
    public class Task
    {
        public string taskName;
        public int identidication;
        public bool done;

        public Task(string aTaskName, int aIdentification, bool aDone)
        {
            taskName = aTaskName;
            identidication = aIdentification;
            done = aDone;
        }
    }
}
