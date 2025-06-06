<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9d80e2a99a9aea8d8226253e6baf4c8c",
  "translation_date": "2025-06-06T18:03:13+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "mo"
}
-->
### -2 List server capabilities

Le nun k connecté au server et demandé so capacité: 

### -3- Convert server capabilities to LLM tools

Étape suivante après avoir listé les capacités du serveur est de les convertir dans un format que le LLM comprend. Une fois fait, on peut fournir ces capacités comme outils à notre LLM.

### -4- Handle user prompt request

Dans cette partie du code, on va gérer les requêtes utilisateur.

## Assignment

Prends le code de l’exercice et développe le serveur avec plus d’outils. Ensuite, crée un client avec un LLM, comme dans l’exercice, et teste-le avec différents prompts pour t’assurer que tous les outils du serveur sont appelés dynamiquement. Cette manière de construire un client offre une excellente expérience utilisateur puisque l’utilisateur peut utiliser des prompts au lieu de commandes client exactes, sans se soucier qu’un serveur MCP soit appelé.

## Solution 

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Key Takeaways

- Ajouter un LLM à ton client offre une meilleure façon pour les utilisateurs d’interagir avec les serveurs MCP.
- Il faut convertir la réponse du serveur MCP en quelque chose que le LLM peut comprendre.

## Samples 

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## Additional Resources

## What's Next

- Suivant : [Consommer un serveur avec Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Disclaimer**:  
This document has been translated using AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). While we strive for accuracy, please be aware that automated translations may contain errors or inaccuracies. The original document in its native language should be considered the authoritative source. For critical information, professional human translation is recommended. We are not liable for any misunderstandings or misinterpretations arising from the use of this translation.