using MusicOrganizer.Entities;

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicOrganizer.Table
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
                var searchString = e.NewValue as string;

                if (o is Song song)
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
