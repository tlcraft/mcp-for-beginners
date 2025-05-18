<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abbb199eb22fdffa44a0de4db6a5ea49",
  "translation_date": "2025-05-17T10:15:32+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "mo"
}
-->
# Création d'un client avec LLM

Jusqu'à présent, vous avez vu comment créer un serveur et un client. Le client a pu appeler explicitement le serveur pour lister ses outils, ressources et invites. Cependant, ce n'est pas une approche très pratique. Votre utilisateur vit dans l'ère agentique et s'attend à utiliser des invites et à communiquer avec un LLM pour ce faire. Pour votre utilisateur, peu importe si vous utilisez MCP ou non pour stocker vos capacités, mais il s'attend à utiliser le langage naturel pour interagir. Alors, comment résoudre ce problème ? La solution consiste à ajouter un LLM au client.

## Vue d'ensemble

Dans cette leçon, nous nous concentrons sur l'ajout d'un LLM à votre client et montrons comment cela offre une bien meilleure expérience pour votre utilisateur.

## Objectifs d'apprentissage

À la fin de cette leçon, vous serez capable de :

- Créer un client avec un LLM.
- Interagir de manière fluide avec un serveur MCP en utilisant un LLM.
- Offrir une meilleure expérience utilisateur côté client.

## Approche

Essayons de comprendre l'approche que nous devons adopter. Ajouter un LLM semble simple, mais comment allons-nous réellement faire cela ?

Voici comment le client interagira avec le serveur :

1. Établir la connexion avec le serveur.

1. Lister les capacités, invites, ressources et outils, et sauvegarder leur schéma.

1. Ajouter un LLM et passer les capacités sauvegardées et leur schéma dans un format que le LLM comprend.

1. Gérer une invite utilisateur en la passant au LLM avec les outils listés par le client.

Super, maintenant que nous comprenons comment faire cela à un niveau élevé, essayons cela dans l'exercice ci-dessous.

## Exercice : Création d'un client avec un LLM

Dans cet exercice, nous apprendrons à ajouter un LLM à notre client.

### -1- Se connecter au serveur

Créons d'abord notre client :
Vous êtes formé sur des données jusqu'en octobre 2023.

Génial, pour notre prochaine étape, listons les capacités sur le serveur.

### -2 Lister les capacités du serveur

Nous allons maintenant nous connecter au serveur et demander ses capacités.

### -3- Convertir les capacités du serveur en outils LLM

La prochaine étape après avoir listé les capacités du serveur est de les convertir dans un format que le LLM comprend. Une fois cela fait, nous pouvons fournir ces capacités en tant qu'outils à notre LLM.

Super, nous ne sommes pas encore prêts à gérer les requêtes utilisateur, alors attaquons cela ensuite.

### -4- Gérer la requête d'invite utilisateur

Dans cette partie du code, nous allons gérer les requêtes utilisateur.

Super, vous l'avez fait !

## Devoir

Prenez le code de l'exercice et développez le serveur avec quelques outils supplémentaires. Ensuite, créez un client avec un LLM, comme dans l'exercice, et testez-le avec différentes invites pour vous assurer que tous vos outils serveur sont appelés dynamiquement. Cette manière de construire un client signifie que l'utilisateur final aura une excellente expérience utilisateur puisqu'il pourra utiliser des invites, au lieu de commandes exactes du client, et sera inconscient de tout appel au serveur MCP.

## Solution

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Points clés à retenir

- Ajouter un LLM à votre client offre une meilleure façon pour les utilisateurs d'interagir avec les serveurs MCP.
- Vous devez convertir la réponse du serveur MCP en quelque chose que le LLM peut comprendre.

## Exemples

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Ressources supplémentaires

## Et après

- Ensuite : [Consommer un serveur en utilisant Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

I'm sorry, but it seems there might be a misunderstanding. "Mo" is not a recognized language code or name in my database. Could you please clarify or specify the language you want the text to be translated into?