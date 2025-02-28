using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Ecosystème.Models
{
    public class OrganicWaste : LifeForm
    {
        // Constructeur avec position
        public OrganicWaste(Vector2 position)
        {
            Position = position;
            Emoji = "💩";
            Health = 10;  // Exemple d'une valeur initiale pour la santé
            Energy = 0;   // L'énergie pourrait être à 0, selon votre logique de décomposition
        }

        // Constructeur sans paramètre (optionnel)
        public OrganicWaste() : this(new Vector2(0, 0)) { }

        // Méthode Update pour gérer la décomposition progressive
        public override void Update(Ecosystem ecosystem)
        {
            // Décomposons progressivement l'OrganicWaste
            Health -= 0.2f; // La santé se réduit avec le temps

            // Si la santé est trop basse, l'OrganicWaste se "dissout" ou se supprime
            if (Health <= 0)
            {
                //ecosystem.RemoveOrganicWaste(this); // Retirer de l'écosystème
            }
        }
    }
}

