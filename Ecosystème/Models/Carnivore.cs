using System;
using System.Numerics;

namespace Ecosystème.Models
{
    public class Carnivore : LifeForm
    {
        // Constructeur avec le sexe pour définir l'emoji 
        public Carnivore(bool isFemale)
        {
            Emoji = isFemale ? "🐆" : "🦁";
            VisionRadius = 5;
            ContactRadius = 1;
            Health = 100;  // Initialisation de la santé
            Energy = 100;  // Initialisation de l'énergie
        }

        // Mise à jour du carnivore dans l'écosystème
        public override void Update(Ecosystem ecosystem)
        {
            Health -= 0.5f; // Décrément de la santé à chaque mise à jour

            // Trouver la proie la plus proche
            var prey = ecosystem.FindNearestHerbivore(this);
            if (prey != null)
            {
                // Déplacer le carnivore vers la proie
                Vector2 direction = new Vector2(prey.Position.X - Position.X, prey.Position.Y - Position.Y);
                direction = Vector2.Normalize(direction); // Normalisation pour garantir un mouvement cohérent
                Move(direction); // Déplacer le carnivore

                // Si le carnivore atteint la proie, la consommer
                if (Vector2.Distance(Position, prey.Position) <= ContactRadius)
                {
                    ecosystem.Consume(this, prey); // Consommer l'herbivore
                }
            }

            // Réduction de l'énergie du carnivore
            Energy -= 1;

            // Si l'énergie est épuisée, la santé se réduit
            if (Energy <= 0)
            {
                Health -= 1;
            }

            // Si la santé tombe à 0, le carnivore est éliminé et remplacé par de la viande
            if (Health <= 0)
            {
                ecosystem.AddMeat(Position); // Ajouter de la viande à la position du carnivore
                ecosystem.RemoveLifeForm(this); // Retirer le carnivore de l'écosystème
            }
        }
    }
}

