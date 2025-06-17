<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0eb9557780cd0a2551cdb8a16c886b51",
  "translation_date": "2025-06-17T15:08:16+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "fr"
}
-->
Parlons davantage de l'utilisation de l'interface visuelle dans les sections suivantes.

## Approche

Voici comment nous devons aborder cela à un niveau global :

- Configurer un fichier pour localiser notre MCP Server.
- Démarrer/Se connecter à ce serveur pour qu'il liste ses capacités.
- Utiliser ces capacités via l'interface GitHub Copilot Chat.

Parfait, maintenant que nous comprenons le déroulement, essayons d’utiliser un MCP Server via Visual Studio Code à travers un exercice.

## Exercice : Consommer un serveur

Dans cet exercice, nous allons configurer Visual Studio Code pour qu’il trouve votre MCP server afin qu’il puisse être utilisé depuis l’interface GitHub Copilot Chat.

### -0- Étape préalable, activer la découverte des MCP Servers

Vous devrez peut-être activer la découverte des MCP Servers.

1. Allez dans `Fichier -> Préférences -> Paramètres` in Visual Studio Code.

1. Search for "MCP" and enable `chat.mcp.discovery.enabled` dans le fichier settings.json.

### -1- Créer un fichier de configuration

Commencez par créer un fichier de configuration à la racine de votre projet, vous aurez besoin d’un fichier nommé MCP.json à placer dans un dossier appelé .vscode. Cela devrait ressembler à ceci :

```text
.vscode
|-- mcp.json
```

Ensuite, voyons comment ajouter une entrée serveur.

### -2- Configurer un serveur

Ajoutez le contenu suivant dans *mcp.json* :

```json
{
    "inputs": [],
    "servers": {
       "hello-mcp": {
           "command": "node",
           "args": [
               "build/index.js"
           ]
       }
    }
}
```

Voici un exemple simple ci-dessus montrant comment démarrer un serveur écrit en Node.js, pour d’autres environnements, indiquez la commande appropriée pour démarrer le serveur en utilisant `command` and `args`.

### -3- Démarrer le serveur

Maintenant que vous avez ajouté une entrée, lançons le serveur :

1. Localisez votre entrée dans *mcp.json* et assurez-vous de voir l’icône "play" :

  ![Démarrage du serveur dans Visual Studio Code](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.fr.png)  

1. Cliquez sur l’icône "play", vous devriez voir l’icône des outils dans GitHub Copilot Chat augmenter le nombre d’outils disponibles. Si vous cliquez sur cette icône, vous verrez la liste des outils enregistrés. Vous pouvez cocher/décocher chaque outil selon si vous souhaitez que GitHub Copilot les utilise comme contexte :

  ![Démarrage du serveur dans Visual Studio Code](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.fr.png)

1. Pour exécuter un outil, tapez une requête qui correspond à la description d’un de vos outils, par exemple une requête comme « ajouter 22 à 1 » :

  ![Exécution d’un outil depuis GitHub Copilot](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.fr.png)

  Vous devriez voir une réponse indiquant 23.

## Devoir

Essayez d’ajouter une entrée serveur dans votre fichier *mcp.json* et assurez-vous de pouvoir démarrer/arrêter le serveur. Vérifiez aussi que vous pouvez communiquer avec les outils de votre serveur via l’interface GitHub Copilot Chat.

## Solution

[Solution](./solution/README.md)

## Points clés à retenir

Les points clés de ce chapitre sont les suivants :

- Visual Studio Code est un excellent client qui vous permet de consommer plusieurs MCP Servers et leurs outils.
- L’interface GitHub Copilot Chat est la manière d’interagir avec les serveurs.
- Vous pouvez demander à l’utilisateur des entrées comme des clés API qui peuvent être transmises au MCP Server lors de la configuration de l’entrée serveur dans le fichier *mcp.json*.

## Exemples

- [Calculatrice Java](../samples/java/calculator/README.md)
- [Calculatrice .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculatrice JavaScript](../samples/javascript/README.md)
- [Calculatrice TypeScript](../samples/typescript/README.md)
- [Calculatrice Python](../../../../03-GettingStarted/samples/python)

## Ressources supplémentaires

- [Documentation Visual Studio](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Et ensuite

- Suivant : [Créer un serveur SSE](/03-GettingStarted/05-sse-server/README.md)

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.