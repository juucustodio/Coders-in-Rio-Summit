using System;
using ConfigCat.Client;
using DemoCoders.Models;
using MVVMCoffee.ViewModels;
using Xamarin.Forms;

namespace DemoCoders.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        //Toggle A
        private string _toggleALabel;
        public string ToggleALabel
        {
            get { return _toggleALabel; }
            set { SetProperty(ref _toggleALabel, value); }
        }

        private Color _toggleACor;
        public Color ToggleACor
        {
            get { return _toggleACor; }
            set { SetProperty(ref _toggleACor, value); }
        }

        private bool _toggleA;
        public bool ToggleA
        {
            get { return _toggleA; }
            set
            {
                SetProperty(ref _toggleA, value);
                ToggleALabel = ToggleA ? "ON" : "OFF";
                ToggleACor = ToggleA ? Color.Green : Color.Red;
            }
        }


        //Toggle B
        private string _toggleBLabel;
        public string ToggleBLabel
        {
            get { return _toggleBLabel; }
            set { SetProperty(ref _toggleBLabel, value); }
        }

        private Color _toggleBCor;
        public Color ToggleBCor
        {
            get { return _toggleBCor; }
            set { SetProperty(ref _toggleBCor, value); }
        }

        private bool _toggleB;
        public bool ToggleB
        {
            get { return _toggleB; }
            set
            {
                SetProperty(ref _toggleB, value);
                ToggleBLabel = ToggleB ? "ON" : "OFF";
                ToggleBCor = ToggleB ? Color.Green : Color.Red;
            }
        }

        public Command VerificarCommand { get; }
        public Command AutoCommand { get; }
        public Command ManualCommand { get; }
        public Command LazyCommand { get; }


        ConfigCatClient client_verificar;
        ConfigCatClient client_auto;
        ConfigCatClient client_manual;
        ConfigCatClient client_lazy;


        public MainViewModel()
        {
            ToggleA = false;
            ToggleB = false;

            VerificarCommand = new Command(ExecuteVerificarCommand);
            AutoCommand = new Command(ExecuteAutoCommand);
            ManualCommand = new Command(ExecuteManualCommand);
            LazyCommand = new Command(ExecuteLazyCommand);


            //Verificar Toggle A
            client_verificar = new ConfigCatClient(Session.ApiKey);


            //Verificar Toggle B - Auto Pooling
            AutoPollConfiguration autoConfiguration = new AutoPollConfiguration
            {
                ApiKey = Session.ApiKey,
                PollIntervalSeconds = 20
            };
            client_auto = new ConfigCatClient(autoConfiguration);


            //Verificar Toggle B - Manual Pooling
            ManualPollConfiguration manualConfiguration = new ManualPollConfiguration
            {
                ApiKey = Session.ApiKey
            };
            client_manual = new ConfigCatClient(manualConfiguration);


            //Verificar Toggle B - Lazy Pooling
            LazyLoadConfiguration lazyConfiguration = new LazyLoadConfiguration
            {
                ApiKey = Session.ApiKey,
                CacheTimeToLiveSeconds = 40
            };

            client_lazy = new ConfigCatClient(lazyConfiguration);

        }


        private void ExecuteVerificarCommand()
        {
            ToggleA = client_verificar.GetValue("togglea", false);
        }

        private void ExecuteAutoCommand()
        {
            ToggleB = client_auto.GetValue("toggleb", false);
        }

        private void ExecuteManualCommand()
        {
            client_manual.ForceRefresh();

            ToggleB = client_manual.GetValue("toggleb", false);
        }

        private void ExecuteLazyCommand()
        {
            ToggleB = client_lazy.GetValueAsync("toggleb", false).Result;
        }
    }
}
