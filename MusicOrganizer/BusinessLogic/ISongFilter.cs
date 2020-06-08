using MusicOrganizer.Entities;

using System;

namespace MusicOrganizer.BusinessLogic
{
    public interface ISongFilter
    {
        public event EventHandler<Predicate<object>> FilterChanged;
    }
}