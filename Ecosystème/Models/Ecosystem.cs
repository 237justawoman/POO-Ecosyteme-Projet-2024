using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Ecosystème.Models
{
    public class Ecosystem
    {
        public List<LifeForm> lifeForms = new List<LifeForm>(); //Liste des formes de vie
        public List<OrganicWaste> OrganicWastes = new List<OrganicWaste>();  // Gérer séparément les déchets organiques

        public Ecosystem()
        {
            // Ajouter des formes de vie initiales, 4 carnivores, 6 herbivores; tous moitié femelles moitié mâles
            lifeForms.Add(new Carnivore(true));
            lifeForms.Add(new Carnivore(true));
            lifeForms.Add(new Carnivore(false));
            lifeForms.Add(new Carnivore(false));
            lifeForms.Add(new Herbivore(true));
            lifeForms.Add(new Herbivore(true));
            lifeForms.Add(new Herbivore(true));
            lifeForms.Add(new Herbivore(false));
            lifeForms.Add(new Herbivore(false));
            lifeForms.Add(new Herbivore(false));
            lifeForms.Add(new Plant());
            lifeForms.Add(new Plant());
            lifeForms.Add(new Plant());
            lifeForms.Add(new Plant());
        }

        public void Update()
        {

            Console.WriteLine($"Tick - Carnivores: {lifeForms.OfType<Carnivore>().Count()}, Herbivores: {lifeForms.OfType<Herbivore>().Count()}, Plantes: {lifeForms.OfType<Plant>().Count()}");

            // Mettre à jour toutes les formes de vie
            foreach (var lifeForm in lifeForms.ToList())
            {
                lifeForm.Update(this);
            }

            //compte toutes les formes de vie
            

            // Mettre à jour les déchets organiques
            foreach (var waste in OrganicWastes.ToList())
            {
                waste.Update(this);
            }
        }

        // Ajouter de la viande à l'écosystème
        public void AddMeat(Vector2 position)
        {
            lifeForms.Add(new Meat(position));
        }

        // Ajouter des déchets organiques à l'écosystème
        public void AddOrganicWaste(Vector2 position)
        {
            OrganicWastes.Add(new OrganicWaste(position)); // Ajouter à la liste des déchets organiques
        }

        // Créer une nouvelle plante à partir d'une plante parente
        public void SeedNewPlant(Plant parentPlant)
        {
            Vector2 newPosition = new Vector2(
                parentPlant.Position.X + Random.Shared.Next(-5, 5),
                parentPlant.Position.Y + Random.Shared.Next(-5, 5));
            
            lifeForms.Add(new Plant(newPosition)); // Ajouter la nouvelle plante à lifeForms
        }

        // Trouver l'herbivore le plus proche d'un carnivore
        public Herbivore? FindNearestHerbivore(Carnivore predator)
        {
            return lifeForms
                .OfType<Herbivore>()
                .OrderBy(h => Vector2.Distance(h.Position, predator.Position))
                .FirstOrDefault();
        }

        // Trouver la plante la plus proche d'un herbivore
        public Plant? FindNearestPlant(Herbivore herbivore)
        {
            return lifeForms
                .OfType<Plant>()
                .OrderBy(p => Vector2.Distance(p.Position, herbivore.Position))
                .FirstOrDefault();
        }

        // Consommer une forme de vie par une autre
        public void Consume(LifeForm consumer, LifeForm food)
        {
            if (consumer is Carnivore carnivore && food is Herbivore herbivore)
            {
                carnivore.Energy += 10;
                lifeForms.Remove(herbivore);
                lifeForms.Add(new Meat(herbivore.Position));
            }
            else if (consumer is Herbivore herb && food is Plant plant)
            {
                herb.Energy += 10;
                lifeForms.Remove(plant);
                lifeForms.Add(new OrganicWaste(plant.Position));
            }
        }

        // Supprimer une forme de vie de l'écosystème
        public void RemoveLifeForm(LifeForm lifeForm)
        {
            lifeForms.Remove(lifeForm);
        }
    }
}

