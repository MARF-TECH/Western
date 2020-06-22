# Western

--- Il était une fois, dans l'Ouest... ---

Bienvenue à Tombstone, Arizona, en octobre 1881.
Oui : l'Arizona, 1881... Le Far West ! Les revolvers, les chapeaux, les bourrins... Ca vous parle j'espère !
Et Tombstone, par contre, ça ne vous dit rien ?!
* soupir *
Bon, on va vous détailler tout ça. En selle !


--- Partie I : un Marshall dans la ville ---

Commençons par les bases : dans une bonne ville, il faut un bon... 
Shérif ? Non ! Le Shérif, il s'occupe de tout le Comté. 
Celui qui gère la ville, c'est le Marshall et ses adjoints. Et Tombstone en a bien besoin, d'un Marshall...

Implémentez la classe Marshall (déclarée dans Marshall.cs) en suivant ces spécifications :
- un Marshall est un être humain comme les autres (si, j'vous jure...) : il a un nom, défini à la construction et non-modifiable par la suite.
- un Marshall est un type bien (la plupart du temps). Gérez donc sa valeur de CharacterType en conséquence.
- un Marshall crie "Throw up your hands!" (haut les mains !) quand il doit crier. Il ne crie jamais autre chose !

Objectif : faire passer les tests de "Part1 - Marshall" au vert.
Temps estimé : 10min.



--- Partie II : vous p(r)endrez bien quelques Desperados ? ---

OK, pied tendre ! Maintenant, on l'a notre Marshall. Mais bon, il sert à quoi s'il y a pas de hors-la-loi à coffrer ?
Et à Tombstone, le groupe de hors-la-loi qui fait sa loi, c'est les Cowboys. 
On va vous donner une idée de qui ils sont...

Implémentez la classe Cowboy (Cowboy.cs) ainsi :
- le Cowboy est un crétin, il est ignare, mais il a quand même un nom qu'il ne peut pas changer !
- le Cowboy est mauvais. Toujours !
- le Cowboy passe son temps à crier, mais ce qu'il crie le plus souvent c'est "Die, you sucker!" (ce que je ne traduirai pas).

Objectif : faire passer les tests de "Part2 - Cowboy" au vert.
Temps estimé : 5min - 10min



--- Partie III : une paire d'As et une paire de Huit ? Jettez ça, pauvre fou ! ---

A Tombstone, il y a aussi des gens "normaux". Des marchands, des chercheurs d'or, des croupiers...
Et des joueurs professionnels ! 
C'est un métier très dangereux, celui de joueur. Il nécessite un bon cerveau pour réfléchir, de bon doigts pour tricher...
Et de bonnes mains pour dégainer.

Implémentez la classe Gambler (Gambler.cs) comme suit :
- Il a un nom (vous connaissez la chanson).
- il est ni bon, ni brute. Il est truand !
- Un joueur reste classe et ne crie JAMAIS. Quand il essaye, il se souvient qu'il doit rester cool en permanence et lance une CoolGuyException.

Objectif : faire passer les tests de "Part 3 - Gambler" au vert.
Temps estimé : 5min - 10min



--- Partie IV : la fusillade de O.K. Corral ---

Bon, des Marshall intrépides, des Cowboys vicieux et des joueurs suicidaires. Mais que pourrait-il donc se passer de terrible ?
Oui, c'était de l'ironie...
Le 26 octobre 1881, les trois frères Earp, tous Marshall, assistés du joueur professionnel Doc Holliday, ont tenté de désarmer cinq Cowboys, derrière un enclos baptisé le "OK Corral".
Et étonnament, ça a dégénéré...

Implémentez le plus important : les fusillades !
Un homme peut être indemne, blessé ou tué. A chaque tir encaissé, il passe à l'état de santé suivant.
Quand un homme est tué, il ne peut plus tirer (je précise, je précise !)
Il y a aussi quelques règles spécifiques :
- avant de tirer sur quelqu'un, le Marshall doit crier les sommations règlementaires. 
	-> La première fois qu'on lui demande de tirer sur quelqu'un, il n'inflige donc rien à l'état de santé de son adversaire.
	-> cette règle s'applique pour TOUS ses adversaires, les uns à la suite des autres !
- le joueur est un pistolero hors-pair et n'a pas besoin de seconde chance : s'il vise quelqu'un il le tue, peu importe son état de santé actuel !

Vous avez une liberté totale pour l'implémentation de ces règles. Aucun test n'a été écrit, ça fait partie de votre boulot, pied-tendre !
Utilisez le fichier "Part4 - OK Corral" pour écrire les tests vérifiant votre implémentation.
Temps estimé : 20min



--- Partie V : Tombstone, Arizona ---

Bon, la fusillade, c'était quelque chose ! Heureusement, tous les jours ne se passent pas comme ça à Tombstone.
Il peut s'en passer, des choses, pendant une journée normale à Tombstone, Arizona ! Vous pouvez vérifier dans le journal local.
Comment ça, quel journal ? Ben, le Tombstone Epitaph, pardi !
Comment ça, un torchon sans la moindre info valable ?
Bon, d'accord, en ce moment les infos sont pas toutes fraîches... D'ailleurs on va y remédier !

Les tests écrits dans "Part5 - Tombstone" sont soit en erreur à cause d'un bug, soit vraiment dégueulasses. On veut des tests verts et propres !
Les examinateurs sont là pour discuter, ne l'oubliez pas !
Temps estimé : 20min - 30min