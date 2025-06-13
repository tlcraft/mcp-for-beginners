<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a0acf3093691b1cfcc008a8c6648ea26",
  "translation_date": "2025-06-13T06:35:51+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "fr"
}
-->
Dans le code précédent, nous avons :

- Importé les bibliothèques
- Créé une instance d'un client et l'avons connecté en utilisant stdio comme transport.
- Listé les prompts, ressources et outils, puis les avons tous invoqués.

Voilà, un client capable de communiquer avec un serveur MCP.

Prenons notre temps dans la prochaine section d'exercice pour analyser chaque extrait de code et expliquer ce qui se passe.

## Exercice : Écrire un client

Comme dit précédemment, prenons le temps d'expliquer le code, et n'hésitez pas à coder en même temps si vous le souhaitez.

### -1- Importer les bibliothèques

Importons les bibliothèques dont nous avons besoin, il nous faudra des références à un client et au protocole de transport choisi, stdio. stdio est un protocole destiné aux applications qui s'exécutent sur votre machine locale. SSE est un autre protocole de transport que nous présenterons dans les chapitres suivants, mais c'est votre autre option. Pour l'instant, continuons avec stdio.

Passons maintenant à l'instanciation.

### -2- Instancier le client et le transport

Nous devons créer une instance du transport ainsi que celle de notre client :

### -3- Lister les fonctionnalités du serveur

Maintenant, nous avons un client qui peut se connecter lorsque le programme est exécuté. Cependant, il ne liste pas encore ses fonctionnalités, faisons-le maintenant :

Parfait, nous avons capturé toutes les fonctionnalités. La question est maintenant : quand les utilisons-nous ? Ce client est assez simple, simple dans le sens où nous devons explicitement appeler les fonctionnalités lorsque nous en avons besoin. Dans le chapitre suivant, nous créerons un client plus avancé qui aura accès à son propre grand modèle de langage (LLM). Pour l'instant, voyons comment invoquer les fonctionnalités sur le serveur :

### -4- Invoquer les fonctionnalités

Pour invoquer les fonctionnalités, nous devons nous assurer de spécifier les arguments corrects et, dans certains cas, le nom de ce que nous essayons d'invoquer.

### -5- Exécuter le client

Pour exécuter le client, tapez la commande suivante dans le terminal :

## Exercice

Dans cet exercice, vous allez utiliser ce que vous avez appris pour créer un client, mais cette fois, créez votre propre client.

Voici un serveur que vous pouvez utiliser et que vous devez appeler via votre code client. Essayez d'ajouter plus de fonctionnalités au serveur pour le rendre plus intéressant.

## Solution

[Solution](./solution/README.md)

## Points clés à retenir

Les points clés à retenir de ce chapitre concernant les clients sont les suivants :

- Ils peuvent être utilisés à la fois pour découvrir et invoquer des fonctionnalités sur le serveur.
- Ils peuvent démarrer un serveur tout en se lançant eux-mêmes (comme dans ce chapitre), mais les clients peuvent aussi se connecter à des serveurs déjà en fonctionnement.
- C’est un excellent moyen de tester les capacités du serveur en complément d’autres alternatives comme l’Inspector, présenté dans le chapitre précédent.

## Ressources supplémentaires

- [Créer des clients dans MCP](https://modelcontextprotocol.io/quickstart/client)

## Exemples

- [Calculatrice Java](../samples/java/calculator/README.md)
- [Calculatrice .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculatrice JavaScript](../samples/javascript/README.md)
- [Calculatrice TypeScript](../samples/typescript/README.md)
- [Calculatrice Python](../../../../03-GettingStarted/samples/python)

## Ce qui suit

- Suivant : [Créer un client avec un LLM](/03-GettingStarted/03-llm-client/README.md)

**Avertissement** :  
Ce document a été traduit à l'aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforçons d'assurer l'exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d'origine doit être considéré comme la source faisant foi. Pour des informations critiques, il est recommandé de recourir à une traduction professionnelle humaine. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l'utilisation de cette traduction.