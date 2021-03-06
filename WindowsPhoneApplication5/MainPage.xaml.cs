﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Navigation;

namespace WindowsPhoneApplication5
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded +=new RoutedEventHandler(MainPage_Loaded);
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected index is -1 (no selection) do nothing
            if (ListBox.SelectedIndex == -1)
                return;

            string content = "";
            string name = "";


            Expression.Blend.SampleData.SampleDataSource.Item selectedItem = e.AddedItems[0] as Expression.Blend.SampleData.SampleDataSource.Item;
            content = selectedItem.Contents;
            name = selectedItem.Name;
            
            textBlock1.Text = name + "\r" + content;
            image1.Source = selectedItem.Image;

            // Navigate to the new page
            jwPivot.SelectedIndex = 1;

            // Reset selected index to -1 (no selection)
            ListBox.SelectedIndex = -1;
        }

        private void jwPivot_GotFocus(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Hey!");
        }
    }
}