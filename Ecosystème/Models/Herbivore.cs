using System;
using System.Numerics;

namespace Ecosystème.Models
{
    public class Herbivore : LifeForm
    {
        // Constructeur avec sexe pour définir l'emoji
        public Herbivore(bool isFemale)
        {
            Emoji = isFemale ? "🦌" : "🐇";
            VisionRadius = 4;
            ContactRadius = 1;
            Health = 100;  // Initialisation de la santé
            Energy = 100;  // Initialisation de l'énergie
        }

        // Mise à jour de l'herbivore dans l'écosystème
        public override void Update(Ecosystem ecosystem)
        {
            Health -= 0.5f; // Réduire la santé à chaque mise à jour

            // Chercher la plante la plus proche
            var plant = ecosystem.FindNearestPlant(this);
            if (plant != null)
            {
                // Calculer la direction vers la plante
                Vector2 direction = new Vector2(plant.Position.X - Position.X, plant.Position.Y - Position.Y);
                direction = Vector2.Normalize(direction); // Normaliser pour un déplacement directionnel
                Move(direction); // Déplacer l'herbivore

                // Consommer la plante si l'herbivore est à proximité
                if (Vector2.Distance(Position, plant.Position) <= ContactRadius)
                {
                    ecosystem.Consume(this, plant); // Consommer la plante
                }
            }

            // Réduire l'énergie de l'herbivore à chaque mise à jour
            Energy -= 1;

            // Si l'énergie atteint 0, réduire la santé
            if (Energy <= 0)
            {
                Health -= 1;
            }

            // Si la santé atteint 0, l'herbivore se transforme en viande
            if (Health <= 0)
            {
                ecosystem.AddMeat(Position); // Ajouter de la viande à la position de l'herbivore
                ecosystem.RemoveLifeForm(this); // Retirer l'herbivore de l'écosystème
            }
        }
    }
}

