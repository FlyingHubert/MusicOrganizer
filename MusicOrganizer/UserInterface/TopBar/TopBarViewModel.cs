using MusicOrganizer.BusinessLogic;

namespace MusicOrganizer.UserInterface.TopBar
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
            }
        }

        public SongManager SongManager { get; }
    }
}
