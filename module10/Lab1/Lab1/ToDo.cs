using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace Lab1
{
    class ToDo: INotifyPropertyChanged

    {

        public int ID { get; set; }
        private string _Task;

        public string Task
        {
            get { return _Task; }
            set { _Task = value;
                RaisePropertyChanged();
            }
        }

        
        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
