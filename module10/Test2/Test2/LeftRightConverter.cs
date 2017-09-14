using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Test2
{
    class LeftRightConverter:IValueConverter

    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if((string) value=="Hannes")
            { return true; }
            else
            { return false; }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
