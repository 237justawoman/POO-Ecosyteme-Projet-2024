using System;
using System.Numerics;

namespace Ecosystème.Models
{
    public class Meat : LifeForm
    {
        // Constructeur
        public Meat(Vector2 position)
        {
            Position = position;
            Emoji = "🥩";
            Health = 10;  // Initialisation de la santé (par exemple 10 pour commencer)
        }

        // Méthode de mise à jour de la viande
        public override void Update(Ecosystem ecosystem)
        {
            Health -= 1; // Décrémenter la santé à chaque mise à jour

            // Si la santé atteint 0 ou en dessous, la viande devient des déchets organiques
            if (Health <= 0)
            {
                ecosystem.AddOrganicWaste(Position); // Ajouter des déchets organiques à la position de la viande
                ecosystem.RemoveLifeForm(this); // Supprimer la viande de l'écosystème
            }
        }
    }
}

