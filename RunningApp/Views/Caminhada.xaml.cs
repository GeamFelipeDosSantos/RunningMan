﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;

using RunningApp.Models;

namespace RunningApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class Caminhada : ContentPage
    {
        public Item Item { get; set; }

        public Caminhada()
        {
            InitializeComponent();

            Item = new Item
            {
                Text = "Item name",
                Description = "This is an item description."
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }

        void OnMapClicked(object sender, MapClickedEventArgs e)
        {
           // Debug.WriteLine($"MapClick: {e.Position.Latitude}, {e.Position.Longitude}");
        }
    }
}