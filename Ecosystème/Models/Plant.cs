using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Ecosystème.Models
{
    public class Plant : LifeForm
    {
        public float RootRadius { get; private set; }
        public float SeedingRadius { get; private set; }

        // Constructeur par défaut
        public Plant()
        {
            Emoji = "🌿";
            RootRadius = 2;
            SeedingRadius = 3;
        }

        // Constructeur avec la position
        public Plant(Vector2 position) : this()
        {
            this.Position = position;
        }

        // Méthode pour obtenir les déchets organiques à proximité
        public List<OrganicWaste> GetNearbyOrganicWastes(Ecosystem ecosystem)
        {
            return ecosystem.OrganicWastes.Where(waste => Vector2.Distance(waste.Position, this.Position) <= this.RootRadius).ToList();
        }

        // Méthode pour absorber les déchets organiques à proximité
        public void AbsorbOrganicWaste(Ecosystem ecosystem)
        {
            var absorbableWaste = GetNearbyOrganicWastes(ecosystem);
            foreach (var waste in absorbableWaste.ToList()) // Créer une copie pour éviter modification pendant l'itération
            {
                Energy += 10; // Augmenter l'énergie
                ecosystem.RemoveLifeForm(waste); // Suppression de l'élément après l'absorption
            }
        }

        // Méthode de mise à jour de la plante
        public override void Update(Ecosystem ecosystem)
        {
            Health -= 0.5f; // Diminuer la santé
            AbsorbOrganicWaste(ecosystem); // Absorber les déchets organiques

            if (Health <= 0) 
            {
                ecosystem.AddOrganicWaste(Position); // Ajouter un déchet organique si la santé atteint 0
            }

            // Chance de semer une nouvelle plante
            if (new Random().NextDouble() < 0.05)
            {
                ecosystem.SeedNewPlant(this); // Planter une nouvelle plante
            }
        }
    }
}

