using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace RunningApp.Views
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CriarTreino : ContentPage
    {
        public CriarTreino()
        {
            InitializeComponent();
        }
        void OnSliderDuracaoValueChanged(object sender, ValueChangedEventArgs e)
        {
            int value = (int) e.NewValue;
            _displayLabel.Text = string.Format("{0}", value);
        }
        void OnSliderVelocidadeValueChanged(object sender, ValueChangedEventArgs e)
        {
            int value = (int)e.NewValue;
            _displayLabel2.Text = string.Format("{0}", value);
        }

    }
}