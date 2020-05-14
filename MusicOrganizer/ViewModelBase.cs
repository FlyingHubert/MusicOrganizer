using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MusicOrganizer
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void Notify([CallerMemberName]string propertyName = "", List<string> additionalPropertyNames = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
         
            if(additionalPropertyNames!= null)
            {
                foreach (var name in additionalPropertyNames)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
                }
            }
        }
    }
}
