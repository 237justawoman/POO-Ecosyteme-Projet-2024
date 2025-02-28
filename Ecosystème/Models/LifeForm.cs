using System;
using System.Numerics;

namespace Ecosystème.Models
{
    public abstract class LifeForm
    {
        // Propriétés de base pour toutes les formes de vie
        public Vector2 Position { get; set; }
        public float Energy { get; set; } = 100;
        public float Health { get; set; } = 100;
        public string Emoji { get; set; } = "❓";

        // Propriétés pour la vision et la portée de contact
        public float VisionRadius { get; protected set; }
        public float ContactRadius { get; protected set; }

        // Propriétés supplémentaires pour Avalonia (facilite la liaison dans XAML)
        public float PositionX => Position.X;
        public float PositionY => Position.Y;

        // Méthode abstraite de mise à jour, à implémenter dans les classes dérivées
        public abstract void Update(Ecosystem ecosystem);

        // Méthode pour déplacer la forme de vie
        public void Move(Vector2 direction)
        {
            Position = new Vector2(Position.X + direction.X, Position.Y + direction.Y);
        }
    }
}


