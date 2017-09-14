using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
  public  class BasicVM
    {
        public ObservableCollection<Chat> MyChatList { get; set; } = new ObservableCollection<Chat>();
        public BasicVM()
        {
            MyChatList.Add(new Chat()
            {
                ID = 1,
                Sender = "Hannes",
                ChatText = "Hallo Welt 17:00"
            });
            MyChatList.Add(new Chat()
            {
                ID = 2,
                Sender = "Hannes",
                ChatText = "Hallo Welt2 18:30 "
            });
            MyChatList.Add(new Chat()
            {
                ID = 3,
                Sender = "Alex",
                ChatText = "Hallo Welt 18:40"
            });
            MyChatList.Add(new Chat()
            {
                ID = 4,
                Sender = "Hannes",
                ChatText = "Hallo Welt 18:45"
            });
            MyChatList.Add(new Chat()
            {
                ID = 5,
                Sender = "Alex",
                ChatText = "Hallo Welt 19:00"
            });
        }
    }
}
