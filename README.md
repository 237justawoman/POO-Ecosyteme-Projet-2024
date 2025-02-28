# Rapport de Projet : Simulation d'Écosystème

## Introduction

Ce projet est une simulation d'écosystème en C# avec Avalonia UI. Il met en scène différents types de formes de vie (êtres vivants) qui interagissent dans un environnement en 2D. L'objectif est de modéliser les cycles biologiques (nutrition, reproduction, décomposition) et les interactions prédateur-proie de manière simple mais extensible.

## Représentation des Entités
La représentation des espèces est porté sur des emojis.
### Carnivore
**Mâle** : 🦁
**Femelle** : 🐆
### Herbivore
**Mâle** : 🐇
**Femelle** : 🦌
### Plant: 🌿
### Meat : 🥩
### OrganicWaste : 💩 
## Diagramme de Classes

Le diagramme de classes ci-dessous représente la structure du projet, avec les différentes entités et leurs relations.
<p align="center">
        <img src="Ecosystème/Diagrammes/Diagramme_De_Classe.png" width="700">
</p>


### Explication :

- **LifeForm** : Classe de base pour toutes les formes de vie. Elle contient les attributs communs comme `Position`, `Health`, `Energy`, etc.
- **Carnivore, Herbivore, Plant** : Spécialisations de `LifeForm` représentant respectivement les carnivores, herbivores et plantes.
- **Meat, OrganicWaste** : Types de ressources produites à la mort des organismes.
- **Ecosystem** : Gère l'ensemble des interactions et met à jour l'état du système.


## Diagramme de Séquence

Le diagramme de séquence ci-dessous illustre le scénario d'un carnivore chassant un herbivore.
<p align="center">
        <img src="Ecosystème/Diagrammes/Diagramme_De_Sequence.png" width="700">
</p>

### Explication :

1. Le **Carnivore** demande à l'**écosystème** de trouver un herbivore.
2. S'il en trouve un, il se déplace et attaque.
3. Si l'herbivore meurt, il est remplacé par de la viande.
4. Le carnivore consomme la viande, récupère de l'énergie et la viande se transforme en déchet organique.

## Diagramme d'Activité

Le diagramme suivant montre le cycle de vie des formes de vie dans l'écosystème.
<p align="center">
        <img src="Ecosystème/Diagrammes/Diagramme_D_Activite.png" width="700">
</p>

### Explication :

1. Chaque organisme perd progressivement de l'énergie.
2. Il cherche de la nourriture pour survivre (carnivore chasse, herbivore mange des plantes, plante absorbe des déchets).
3. S'il ne se nourrit pas et que son énergie atteint `0`, il commence à consommer ses points de vie.
4. S'il meurt, il devient une ressource pour d'autres formes de vie (viande ou déchets organiques).
5. L'écosystème est mis à jour en boucle.

## Principes SOLID Utilisés

### 1️⃣ Principe de Responsabilité Unique (SRP - Single Responsibility Principle)

```csharp
public class LifeForm {
    public Vector2 Position { get; set; }
    public float Health { get; set; }
    public float Energy { get; set; }
    public string Emoji { get; set; }
    public float VisionRadius { get; protected set; }
    public float ContactRadius { get; protected set; }
    public float PositionX => Position.X;
    public float PositionY => Position.Y;
}
```

**Justification :**

Chaque classe du projet a une seule raison de changer :

- `LifeForm` définit les caractéristiques communes aux êtres vivants.
- `Carnivore`, `Herbivore` et `Plant` gèrent des comportements spécifiques à chaque type d'entité.
- `Ecosystem` orchestre l'ensemble des interactions sans gérer directement la logique interne des entités.

Cela permet une meilleure maintenance et évolution du code.

### 2️⃣ Principe Ouvert/Fermé (OCP - Open/Closed Principle)

```csharp
public abstract class LifeForm {
    public abstract void Update(Ecosystem ecosystem);
}

public class Carnivore : LifeForm {
    public override void Update(Ecosystem ecosystem) {
        // Comportement spécifique aux carnivores
    }
}
```

**Justification :**

Le système est ouvert à l'extension, mais fermé à la modification.

- Si on veut ajouter une nouvelle espèce (ex: `Omnivore`), on peut créer une nouvelle classe sans modifier `LifeForm`.
- Les classes existantes n'ont pas besoin d'être réécrites ou modifiées, ce qui assure la stabilité du code.

## Conclusion

Ce projet d'écosystème illustre un modèle extensible et bien structuré en C# avec Avalonia UI. Il respecte les principes SOLID pour garantir une maintenance et une évolutivité optimales.

Le code est conçu pour permettre l'ajout de nouvelles espèces ou de nouvelles interactions sans perturber les structures existantes.

