﻿using System;
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

namespace MusicOrganizer.Entry
{
    /// <summary>
    /// Interaktionslogik für NamedTextBox.xaml
    /// </summary>
    public partial class NamedTextBox : UserControl
    {


        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(NamedTextBox), new FrameworkPropertyMetadata()
            {
                BindsTwoWayByDefault = true,
            });



        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(NamedTextBox), new FrameworkPropertyMetadata());

        public ICommand F10Command
        {
            get { return (ICommand)GetValue(F10CommandProperty); }
            set { SetValue(F10CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for F10Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty F10CommandProperty =
            DependencyProperty.Register("F10Command", typeof(ICommand), typeof(NamedTextBox), new FrameworkPropertyMetadata());

        public ICommand F5Command
        {
            get { return (ICommand)GetValue(F5CommandProperty); }
            set { SetValue(F5CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for F5Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty F5CommandProperty =
            DependencyProperty.Register("F5Command", typeof(ICommand), typeof(NamedTextBox), new FrameworkPropertyMetadata());

        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Label.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(NamedTextBox), new PropertyMetadata(""));

        public NamedTextBox()
        {
            InitializeComponent();
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if((F10Command?.CanExecute(null) ?? false) && e.SystemKey == Key.F10)
            {
                F10Command.Execute(CommandParameter);
            }

            if ((F5Command?.CanExecute(null) ?? false) && e.SystemKey == Key.F5)
            {
                F5Command.Execute(CommandParameter);
            }
        }
    }
}
