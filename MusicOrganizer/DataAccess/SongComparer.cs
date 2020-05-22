using MusicOrganizer.Entities;

using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MusicOrganizer.DataAccess
{
    public class SongComparer
    {
        private Func<Song, bool>[] Checks;

        public SongComparer(Song search)
        {
            Search = search;

            Checks = new Func<Song, bool>[]
            {
                SongIsNotEmpty(),
                MaybeCheckString((s) => s.Album),
                MaybeCheckString((s) => s.Art),
                MaybeCheckString((s) => s.Bemerkungen),
                MaybeCheckString((s) => s.Interpret),
                MaybeCheckString((s) => s.Komponist),
                MaybeCheckString((s) => s.Title),
                MaybeCheckInt((s) => s.CD),
                MaybeCheckInt((s) => s.Jahr),
            };
        }

        private Song Search { get; }

        public bool IsLike(Song entity)
        {
            return Checks.All(s => s(entity));
        }

        private Func<Song, bool> MaybeCheckInt(Func<Song, int?> selector)
        {
            return selector(Search) == null
                ? (Func<Song, bool>)((_) => true)
                : (s) => selector(Search) == selector(s);
        }

        private Func<Song, bool> MaybeCheckString(Func<Song, string> selector)
        {
            return string.IsNullOrEmpty(selector(Search))
                ? (Func<Song, bool>)((_) => true)
                : (s => (Regex.IsMatch(selector(s), selector(Search))));
        }

        private Func<Song, bool> SongIsNotEmpty()
        {
            var isEmtpy = string.IsNullOrEmpty(Search.Album)
                && string.IsNullOrEmpty(Search.Art)
                && string.IsNullOrEmpty(Search.Bemerkungen)
                && string.IsNullOrEmpty(Search.Interpret)
                && string.IsNullOrEmpty(Search.Komponist)
                && string.IsNullOrEmpty(Search.Title)
                && Search.CD == null
                && Search.Jahr == null;

            return (s) => !isEmtpy;
        }
    }
}