<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc3ae5af5973160abba9976cb5a4704c",
  "translation_date": "2025-06-13T11:24:46+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "fr"
}
-->
Super, pour notre prochaine étape, listons les capacités du serveur.

### -2 Lister les capacités du serveur

Maintenant, nous allons nous connecter au serveur et demander ses capacités :

### -3- Convertir les capacités du serveur en outils LLM

L'étape suivante après avoir listé les capacités du serveur est de les convertir dans un format que le LLM comprend. Une fois cela fait, nous pouvons fournir ces capacités comme outils à notre LLM.

Super, nous sommes maintenant prêts à gérer les requêtes des utilisateurs, passons à cette étape.

### -4- Gérer les requêtes des utilisateurs

Dans cette partie du code, nous allons gérer les requêtes des utilisateurs.

Super, vous l'avez fait !

## Exercice

Prenez le code de l'exercice et développez le serveur avec quelques outils supplémentaires. Ensuite, créez un client avec un LLM, comme dans l'exercice, et testez-le avec différents prompts pour vous assurer que tous vos outils serveur sont appelés dynamiquement. Cette façon de construire un client garantit une excellente expérience utilisateur, car ils peuvent utiliser des prompts, au lieu de commandes client exactes, sans se soucier d'un éventuel appel au serveur MCP.

## Solution

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Points clés à retenir

- Ajouter un LLM à votre client offre une meilleure manière pour les utilisateurs d'interagir avec les serveurs MCP.
- Vous devez convertir la réponse du serveur MCP en quelque chose que le LLM peut comprendre.

## Exemples

- [Calculatrice Java](../samples/java/calculator/README.md)
- [Calculatrice .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculatrice JavaScript](../samples/javascript/README.md)
- [Calculatrice TypeScript](../samples/typescript/README.md)
- [Calculatrice Python](../../../../03-GettingStarted/samples/python)

## Ressources supplémentaires

## Et ensuite

- Suivant : [Consommer un serveur avec Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Avertissement** :  
Ce document a été traduit à l'aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d'assurer l'exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d'origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle humaine est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l'utilisation de cette traduction.