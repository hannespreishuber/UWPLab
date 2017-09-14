using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace lab4
{
    public class AdressenVM
    {
        public ObservableCollection<Person> Personen { get; set; } = new ObservableCollection<Person>();
        public AdressenVM()
        {

        }
        public async Task load()
        {
            var file = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///namen.txt"));
            var lines = await FileIO.ReadLinesAsync(file);
            int i = 0;

            foreach (var line in lines)
            {
             
                Personen.Add(new Person() { ID = i, Name = line });
                i++;
            }

        }
    }
}