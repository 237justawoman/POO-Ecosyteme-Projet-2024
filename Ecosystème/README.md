Rapport de Projet : Simulation d'Écosystème

1. Introduction

Ce projet est une simulation d'écosystème en C# avec Avalonia UI. Il met en scène différents types de formes de vie (êtres vivants) qui interagissent dans un environnement en 2D. L'objectif est de modéliser les cycles biologiques (nutrition, reproduction, décomposition) et les interactions prédateur-proie de manière simple mais extensible.

2. Diagramme de Classes

Le diagramme de classes ci-dessous représente la structure du projet, avec les différentes entités et leurs relations.



Explication :

LifeForm : Classe de base pour toutes les formes de vie. Elle contient les attributs communs comme Position, Health, Energy, etc.

Carnivore, Herbivore, Plant : Spécialisations de LifeForm représentant respectivement les carnivores, herbivores et plantes.

Meat, OrganicWaste : Types de ressources produites à la mort des organismes.

Ecosystem : Gère l'ensemble des interactions et met à jour l'état du système.

3. Diagramme de Séquence

Le diagramme de séquence ci-dessous illustre le scénario d'un carnivore chassant un herbivore.



Explication :

Le Carnivore demande à l'écosystème de trouver un herbivore.

S'il en trouve un, il se déplace et attaque.

Si l'herbivore meurt, il est remplacé par de la viande.

Le Carnivore consomme la viande, récupère de l'énergie et la viande se transforme en déchet organique.

4. Diagramme d'Activité

Le diagramme suivant montre le cycle de vie des formes de vie dans l'écosystème.



Explication :

Chaque organisme perd progressivement de l'énergie.

Il cherche de la nourriture pour survivre (carnivore chasse, herbivore mange des plantes, plante absorbe des déchets).

S'il ne se nourrit pas et que son énergie atteint 0, il commence à consommer ses points de vie.

S'il meurt, il devient une ressource pour d'autres formes de vie (viande ou déchets organiques).

L'écosystème est mis à jour en boucle.

5. Principes SOLID Utilisés

Le projet respecte plusieurs principes SOLID, notamment :

1️⃣ Principe de Responsabilité Unique (SRP - Single Responsibility Principle)

public class LifeForm {
    public Vector2 Position { get; set; }
    public float Health { get; set; }
    public float Energy { get; set; }
}

Justification :
Chaque classe du projet a une seule raison de changer :

LifeForm définit les caractéristiques communes aux êtres vivants.

Carnivore, Herbivore et Plant gèrent des comportements spécifiques à chaque type d'entité.

Ecosystem orchestre l'ensemble des interactions sans gérer directement la logique interne des entités.

Cela permet une meilleure maintenance et évolution du code.

2️⃣ Principe Ouvert/Fermé (OCP - Open/Closed Principle)

public abstract class LifeForm {
    public abstract void Update(Ecosystem ecosystem);
}

public class Carnivore : LifeForm {
    public override void Update(Ecosystem ecosystem) {
        // Comportement spécifique aux carnivores
    }
}

Justification :

Le système est ouvert à l'extension, mais fermé à la modification.

Si on veut ajouter une nouvelle espèce (ex: Omnivore), on peut créer une nouvelle classe sans modifier LifeForm.

Les classes existantes n'ont pas besoin d'être réécrites ou modifiées, ce qui assure la stabilité du code.

6. Conclusion

Ce projet d'écosystème illustre un modèle extensible et bien structuré en C# avec Avalonia UI. Il respecte les principes SOLID pour garantir une maintenance et une évolutivité optimales.

Le code est conçu pour permettre l'ajout de nouvelles espèces ou de nouvelles interactions sans perturber les structures existantes.


