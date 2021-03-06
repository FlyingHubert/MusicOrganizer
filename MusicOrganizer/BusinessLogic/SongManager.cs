﻿
using MusicOrganizer.DataAccess;
using MusicOrganizer.DI;
using MusicOrganizer.Entities;

using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicOrganizer.BusinessLogic
{
    public enum State { Editing, Adding }

    public class SongManager
    {
        public SongManager(Database database)
        {
            Database = database;
            EditableSong = new SongModel(new Song());
            StateChanged?.Invoke(this, State.Adding);
        }

        private SongModel editableSong;

        public event EventHandler EditableSongChanged;
        public event EventHandler<State> StateChanged;

        public SongModel EditableSong
        {
            get => editableSong;
            private set
            {
                PreviousEditableSong = editableSong;
                editableSong = value;
                EditableSongChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        internal void FinishEditing()
        {
            EditableSong = new SongModel(new Song());
            StateChanged?.Invoke(this, State.Adding);
        }

        public SongModel PreviousEditableSong { get; set; }

        private Database Database { get; }

        public event EventHandler<SongModel> SongAdded;
        public event EventHandler<SongModel> SongRemoved;
        public IEnumerable<SongModel> Songs => Database.Songs.Select(s => new SongModel(s));

        public void AddSongToDatabase()
        {
            Database.Insert(EditableSong.Song);
            SongAdded.Invoke(this, EditableSong);
            EditableSong = new SongModel(new Song());
            StateChanged?.Invoke(this,State.Adding);
        }


        public void Remove(SongModel songModel)
        {
            Database.Delete(songModel.Song);
            SongRemoved.Invoke(this, songModel);
        }

        public void EditThisSong(SongModel song)
        {
            EditableSong = song;
            StateChanged?.Invoke(this,State.Editing);
        }
    }
}
