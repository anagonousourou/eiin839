# EIIN839 - ECUE Service oriented computing/WS

## ANAGONOU Sourou Patrick - Groupe 3

## Rendu 2
- Le dossier *HTTPListener* contient le rendu de la question 1 du TD2. Pour illustrer l'utilisation des headers on affiche le logo du navigateur à partir duquel on accède au serveur
- Le dossier WebDynamic contient la solution Visual Studio des autres questions du TD2. 

### ReflectionSample
Ce projet contient la réponse à la *Question 4*
Pour tester il faut activer le projet ReflectionSample et le lancer. Ensuite tester par exemple les urls
- http://localhost:8080/Add?arg1=8&arg2=7&arg3=50
```
Parametres : 8, 7, 50 ; Result : 65 
```
- http://localhost:8080/Xor?arg1=8&arg2=7&arg3=50
```
Parametres : 8, 7, 50 ; Result : 61 
```
- http://localhost:8080/Mult?arg1=8&arg2=7&arg3=50&arg4=12
```
Parametres : 8, 7, 50, 12 ; Result : 33600 
```

Le programme permet d'appliquer les opérateurs d'addition , multiplication et ou exclusif sur un nombre quelconque de paramètres entiers. Le nom des paramètre n'est pas important.

### ExternalExeCall
Ce projet contient la réponse à la *Question 5". Il dépend du projet ExecTest

Exemple d'url
- http://localhost:8080/add?aug1=1&aug2=8
```
1 + 8 = 9
```
Ici il faut respecter le nom des paramètres et leur nombre.


### AppelScript
Ce projet contient le code pour la question bonus
Il permet d'appeler un script batch qui a son tour fait appel à python pour exécuter le code passé dans l'url.  On affiche dans le navigateur le contenu qu'on n'aurait dans la console.
Un chemin relatif est mis pour  le chemin du fichier `script.bat` dans le fichier ScriptAnswerMaker ligne ~ 26, si il ne marche pas il peut ête nécessaire de le changer.

Exemple d'url
- http://localhost:8080/print(4+4);print(7+9);
```
C:\Users\...\Debug\netcoreapp3.1>python -c "print(4+4);print(7+9);" 
8
16

```



