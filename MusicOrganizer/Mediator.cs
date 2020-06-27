using MusicOrganizer.Entry;
using MusicOrganizer.Table;
using MusicOrganizer.TopBar;
using MusicOrganizer.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicOrganizer
{
    public class Mediator
    {
        public Mediator()
        {
            TopBar.PropertyChanged += TopBar_PropertyChanged;
            Table.PropertyChanged += Table_PropertyChanged;
        }

        private void Table_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(Table.SelectedSong))
            {
                Entry.EditThisSong(Table?.SelectedSong?.Song);
            }
        }

        private void TopBar_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(TopBar.SearchString))
            {
                Table.Filter = TopBar.SearchString;
            }
        }

        public static TableViewModel Table { get; set; } = Ninja.Get<TableViewModel>();
        public static TopBarViewModel TopBar { get; set; } = Ninja.Get<TopBarViewModel>();
        public static EntryViewModel Entry { get; set; } = Ninja.Get<EntryViewModel>();
    }
}
