using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class simpleVM
    {
        public ToDo MyToDo { get; set; }
        public simpleVM()
        {
            MyToDo = new ToDo();
        }
    }
}
