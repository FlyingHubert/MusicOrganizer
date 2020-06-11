using MusicOrganizer.BusinessLogic;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicOrganizer.TopBar
{
    public class TopBarViewModel : ViewModelBase
    {
        private string searchString;

        public TopBarViewModel(SongManager songManager)
        {
            SongManager = songManager;
        }

        public string SearchString
        {
            get => searchString;
            set
            {
                searchString = value;
                Notify();
                SongManager.FilterForThis(searchString);
            }
        }

        public SongManager SongManager { get; }
    }
}
