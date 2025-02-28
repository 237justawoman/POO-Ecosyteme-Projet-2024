using Avalonia.Controls;
using Avalonia.Threading;
using Avalonia.Markup.Xaml;
using Ecosystème.Models;
using System;
using System.Collections;
using System.Numerics;

namespace Ecosystème.Views
{
    public partial class MainWindow : Window
    {
        private Ecosystem _ecosystem;
        private DispatcherTimer _timer;

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        public MainWindow()
        {
            InitializeComponent();
            _ecosystem = new Ecosystem();
            DataContext = _ecosystem; // Lien avec l'UI

            // Initialisation du Timer pour mettre à jour la simulation
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(100) // 10 FPS
            };
            _timer.Tick += (sender, e) => UpdateSimulation();
            _timer.Start();
        }

        private void UpdateSimulation()
        {
            _ecosystem.Update(); // Met à jour l'écosystème
            
            Console.WriteLine("j'affiche bien les animaux");

        }
        
    }
}

