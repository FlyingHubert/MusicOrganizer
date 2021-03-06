﻿using MusicOrganizer.BusinessLogic;
using MusicOrganizer.Entities;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace MusicOrganizer.UserInterface.Table
{
    /// <summary>
    /// Interaktionslogik für TableView.xaml
    /// </summary>
    public partial class TableView : UserControl
    {
        public TableView()
        {
            InitializeComponent();
        }

        public string Filter
        {
            get { return (string)GetValue(FilterProperty); }
            set { SetValue(FilterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Filter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilterProperty =
            DependencyProperty.Register("Filter", typeof(string), typeof(TableView), new FrameworkPropertyMetadata()
            {
                BindsTwoWayByDefault = true,
                PropertyChangedCallback = new PropertyChangedCallback(OnFilterChanged)
            });

        private static void OnFilterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var view = d as TableView;

            var collectionView = view.listView.ItemsSource as CollectionView;

            collectionView.Filter = o =>
            {
                var searchString = (e.NewValue as string).ToLower();

                if (o is SongModel song)
                {
                    return (song.Album != null && song.Album.ToLower().Contains(searchString))
                          || (song.Art != null && song.Art.ToLower().Contains(searchString))
                          || (song.Bemerkungen != null && song.Bemerkungen.ToLower().Contains(searchString))
                          || (song.Interpret != null && song.Interpret.ToLower().Contains(searchString))
                          || (song.Komponist != null && song.Komponist.ToLower().Contains(searchString))
                          || (song.Title != null && song.Title.ToLower().Contains(searchString))
                          || (song.single != null && song.single.ToString().Contains(searchString))
                          || (song.LP != null && song.LP.ToString().ToLower().Contains(searchString))
                          || (song.Jahr != null && song.Jahr.ToString().ToLower().Contains(searchString))
                          || (song.CD != null && song.CD.ToString().ToLower().Contains(searchString));
                }
                else
                {
                    return true;
                }
            };
        }
    }
}
