# VersionBase

Roadmap :
* [X] Merge couleur et image
* [X] Terrain = image OU couleur + image, liste
* [X] Virer la lettre
* [X] Virer la limitation de taille
* [X] Virer le Switch Terrain
* [ ] Interface gauche
* [ ] Menu déroulant Terrain
* [ ] Clic + Terrain = changement terrain cible
* [ ] Sortir la logique de gestion des clics dans une interface + classe XXXX
* [ ] Sortir la logique de remplissage de la carte dans une interface + classe YYYY
* [ ] Interface UI : afficher le type de terrain sélectionné si la liste déroulante est sur "rien"
* [ ] Interface UI : Menu en haut
* [ ] Au lancement, demander dimensions (et type terrain de base ?)
* [ ] Regénération d'une carte (avec demande dimensions)
* [ ] Création d'un objet Map, contenant les données de dimension, la liste des Hex
* [ ] Créer un objet TileSet, contenant la liste des types de terrain, référencé dans Map ?
* [ ] Ajouter toutes les tiles d'origine dans l'objet TileSet (interface ?), et en faire une version pour chaque set de tiles que j'ai, et faire un Enum + ue fonction pour récupérer le bon

* Sauvegarde / rechargement de Map par BDD



Ressources :
* "Adam, unity":http://t-machine.org/index.php/author/adam/
* "Son blog":http://growthofages.com/
* "Honeycom Csharp xaml wpf":https://rosettacode.org/wiki/Honeycombs#C.23
* "Tutoriaux unity":http://quill18.com/unity_tutorials/
* "Super tuto XAML":https://www.tutorialspoint.com/mvvm/index.htm

Feuille de route :
* Vérifier les "A faire"
* Créer un projet pour travailler :
** Installer / configurer Unity, version 2017.1.0 au moins
** Installer Microsoft Visual Studio (Community)
* Lier VS et Unity via :
** "Ceci":https://msdn.microsoft.com/fr-fr/library/dn940025.aspx
** "Ceci":https://www.visualstudio.com/fr/vs/unity-tools/?rr=https%3A%2F%2Fwww.google.fr%2F
** "Ceci":https://docs.unity3d.com/Manual/VisualStudioIntegration.html
** Pour finir, compléter "ce petit tutorial":https://unity3d.com/fr/learn/tutorials/topics/scripting/building-your-first-unity-game-visual-studio , qui lie Unity et C# VS
* Progresser dans les Tutoriaux pour atteindre l'Hex Map :
** "La base 1/2":http://catlikecoding.com/unity/tutorials/basics/game-objects-and-scripts/
** "La base 2/2":http://catlikecoding.com/unity/tutorials/constructing-a-fractal/
** La série Mesh Basics, à faire :
*** "1/4 - Procedural Grid":http://catlikecoding.com/unity/tutorials/procedural-grid/
*** "2/4 - Rounded Cube":http://catlikecoding.com/unity/tutorials/rounded-cube/
*** "3/4 - Cube Sphere":http://catlikecoding.com/unity/tutorials/cube-sphere/
*** "4/4 - Mesh Deformation":http://catlikecoding.com/unity/tutorials/mesh-deformation/
* Suivre les tutoriaux Hexf Map (il y en a 22)
** "1/22 - Creating a Hexagonal Grid : Generate a simple hex grid and support in-game editing of cell colors.":http://catlikecoding.com/unity/tutorials/hex-map/part-1/
** "2/22 - Blending Cell Colors : Connect cell with each other and blend their colors.":http://catlikecoding.com/unity/tutorials/hex-map/part-2/
** "3/22 - Elevation and Terraces : Give cells different elevation levels and connect them with terraces.":http://catlikecoding.com/unity/tutorials/hex-map/part-3/
** "4/22 - Irregularity : Perturb cell edges and elevations to produce a more natural map.":http://catlikecoding.com/unity/tutorials/hex-map/part-4/
** "5/22 - Larger Maps : Make large maps possible, and provide the tools to edit them.":http://catlikecoding.com/unity/tutorials/hex-map/part-5/
** "6/22 - Rivers : Draw rivers across the terrain, and animate them.":http://catlikecoding.com/unity/tutorials/hex-map/part-6/
** "7/22 - Roads : Add roads to the map, and make them play nice with rivers.":http://catlikecoding.com/unity/tutorials/hex-map/part-7/
** "8/22 - Water : Create bodies of water at various elevations, and flow rivers in and out of them.":http://catlikecoding.com/unity/tutorials/hex-map/part-8/
** "9/22 - Terrain Features : Add detail objects to the terrain to represent plants, farmland, and urban development.":http://catlikecoding.com/unity/tutorials/hex-map/part-9/
** "10/22 - Walls : Segregate cells by placing walls along their edges.":http://catlikecoding.com/unity/tutorials/hex-map/part-10/
** "11/22 - More Features : Support wall towers, bridges, and larger features.":http://catlikecoding.com/unity/tutorials/hex-map/part-11/
** "12/22 - Saving and Loading : Write maps to a file, and read them back.":http://catlikecoding.com/unity/tutorials/hex-map/part-12/
** "13/22 - Managing Maps : Make it possible to work with multiple maps of various sizes.":http://catlikecoding.com/unity/tutorials/hex-map/part-13/
** "14/22 - Terrain Textures : Cover the terrain with textures.":http://catlikecoding.com/unity/tutorials/hex-map/part-14/
** "15/22 - Distances : Find the shortest distances to a cell.":http://catlikecoding.com/unity/tutorials/hex-map/part-15/
** "16/22 - Pathfinding : Search for the shortest path between two cells.":http://catlikecoding.com/unity/tutorials/hex-map/part-16/
** "17/22 - Limited Movement : Split movement into turns and find paths as quickly as possible.":http://catlikecoding.com/unity/tutorials/hex-map/part-17/
** "18/22 - Units : Add unit to the map and move them around.":http://catlikecoding.com/unity/tutorials/hex-map/part-18/
** "19/22 - Animating Movement : Send units on a journey across the map.":http://catlikecoding.com/unity/tutorials/hex-map/part-19/
** "20/22 - Fog of War : Distinguish between visible and invisible cells.":http://catlikecoding.com/unity/tutorials/hex-map/part-20/
** "21/22 - Exploration : Only show parts of the map that have been explored.":http://catlikecoding.com/unity/tutorials/hex-map/part-21/
** "22/22 - Advanced Vision : Base vision range on elevation and smoothly transition between hidden and visible cells.":http://catlikecoding.com/unity/tutorials/hex-map/part-22/
** NOTE : il n'est pas nécessaire de faire tous les tutoriaux pour arriver à quelque chose d'utile. En théorie, tout jusqu'au 14 est nécessaire. Les unités permettent de représenter les Patrouilleurs, et le temps de déplacement permet de répondre aux joueurs sur le temps qu'ils vont mettre (15 à 18, OSEF de l'animation).
* A partir de là, il faut :
** Ajouter les types de terrain disponibles sur la carte d'origine(cf. tuto 14)
** Gérer l'ajout des communautés, ruines, etc., avec informations
** Gérer la récupération d'informations sur l'hex sélectionné
** Gérer le stockage des informations

Liens utiles :
* "Superbe ressource pour programmer une gestion d'hexagones très complète sous Unity (chercher hex)":http://catlikecoding.com/unity/tutorials/
