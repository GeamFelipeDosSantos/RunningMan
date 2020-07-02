using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using RunningApp.Models;
using RunningApp.Views;
using RunningApp.ViewModels;

namespace RunningApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (Item)layout.BindingContext;
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
        }

        

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
        }
        private async void DirecionarTelaCaminhada(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Caminhada());
        }
        private async void DirecionarTelaTreinoLeve(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Leve());
        }

        private async void DirecionarTelaTreinoIniciante(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Iniciante());
        }

        private async void DirecionarTelaTreinoIntermediario(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Intermediario());
        }

        private async void DirecionarTelaTreinoAvancado(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Avancado());
        }

        private async void DirecionarTelaTreinoAtleta (object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Atleta());
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click me again!";
        }

        private async void CriarTreino(object sender, EventArgs e) {
            await Navigation.PushAsync(new CriarTreino());
        }
        void EncerrarApp(object sender, EventArgs e)
        {
            //Fechar a aplicação
            //this.FinishAffinity();
            System.Environment.Exit(0);
            
        }
    }
    
}