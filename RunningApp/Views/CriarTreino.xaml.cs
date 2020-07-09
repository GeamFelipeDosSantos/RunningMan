using RunningApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace RunningApp.Views
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CriarTreino : ContentPage
    {
        ObservableCollection<Passo> passos;
        int sliderDuracaoValor;
        int sliderVelocidadeValor;
        string pickerTipo;

        public CriarTreino()
        {
            InitializeComponent();

            sliderDuracaoValor = 1;
            sliderVelocidadeValor = 1;

            passos = new ObservableCollection<Passo>();
            listView.ItemsSource = passos;

            // ObservableCollection allows items to be added after ItemsSource
            // is set and the UI will react to changes
            passos.Add(new Passo { tipo = "Corrida", velocidade = 5, duracao = 50 });
            passos.Add(new Passo { tipo = "Caminhada", velocidade = 10, duracao = 30 });

            
        }
        public ObservableCollection<Passo> Passos { get { return passos; } }

        
        private async void yaya(object sender, EventArgs e)
        {


            passos.Add(new Passo { tipo = pickerTipo,  velocidade = sliderVelocidadeValor, duracao = sliderDuracaoValor });
        }
        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var pickerTipo =(string) picker.SelectedItem; // This is the model selected in the picker
        }

        void OnSliderDuracaoValueChanged(object sender, ValueChangedEventArgs e)
        {
            sliderDuracaoValor = (int)e.NewValue;
            int value = (int) e.NewValue;
            _displayLabel.Text = string.Format("{0}", value);
        }
        void OnSliderVelocidadeValueChanged(object sender, ValueChangedEventArgs e)
        {
            sliderVelocidadeValor = (int)e.NewValue;
            int value = (int)e.NewValue;
            _displayLabel2.Text = string.Format("{0}", value);
        }

    }
}