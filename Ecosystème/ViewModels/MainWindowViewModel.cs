using System;
using System.Collections.ObjectModel;
using Ecosystème.Models;

namespace Ecosystème.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        // Propriété pour la collection d'entités à afficher dans l'UI
        public ObservableCollection<LifeForm> Entities { get; set; }

        // Propriété de message de bienvenue
        public string Greeting { get; } = "Welcome to Avalonia!";

        // Constructeur
        public MainWindowViewModel()
        {
            // Initialiser la collection d'entités
            Entities = new ObservableCollection<LifeForm>
            {
                new Carnivore(true) { Position = new System.Numerics.Vector2(100, 250) },
                new Carnivore(false) { Position = new System.Numerics.Vector2(250, 250) },
                new Carnivore(true) { Position = new System.Numerics.Vector2(400, 200) },
                new Carnivore(false) { Position = new System.Numerics.Vector2(550, 300) },
                new Herbivore(true) { Position = new System.Numerics.Vector2(200, 150) },
                new Herbivore(false) { Position = new System.Numerics.Vector2(300, 150) },
                new Herbivore(false) { Position = new System.Numerics.Vector2(500, 200) },
                new Herbivore(true) { Position = new System.Numerics.Vector2(300, 250) },
                new Plant() { Position = new System.Numerics.Vector2(300, 150) },
                new Plant() { Position = new System.Numerics.Vector2(550, 250) },
                new Plant() { Position = new System.Numerics.Vector2(600, 300) },
                new Plant() { Position = new System.Numerics.Vector2(700, 250) },
                new Plant() { Position = new System.Numerics.Vector2(650, 250) },
                new Plant() { Position = new System.Numerics.Vector2(100, 300) },
                new Plant() { Position = new System.Numerics.Vector2(200, 150) },
                new Plant() { Position = new System.Numerics.Vector2(300, 150) },
                new Plant() { Position = new System.Numerics.Vector2(550, 250) },
                new Plant() { Position = new System.Numerics.Vector2(300, 350) },
                new Plant() { Position = new System.Numerics.Vector2(450, 250) },
                new Plant() { Position = new System.Numerics.Vector2(400, 250) },
                //new Meat() { Position = new System.Numerics.Vector2(700, 300) },
                new OrganicWaste() { Position = new System.Numerics.Vector2(500, 250) }
            };
        }
    }
}
