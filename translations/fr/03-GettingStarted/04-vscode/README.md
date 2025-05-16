<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c37fabfbc0dcbc9a4afb6d17e7d3be9f",
  "translation_date": "2025-05-16T15:13:17+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "fr"
}
-->
Parlons un peu plus de l'utilisation de l'interface visuelle dans les sections suivantes.

## Approche

Voici comment nous devons procéder à un niveau général :

- Configurer un fichier pour localiser notre MCP Server.
- Démarrer/Se connecter au serveur pour qu'il liste ses capacités.
- Utiliser ces capacités via l'interface de chat de GitHub Copilot.

Parfait, maintenant que nous comprenons le processus, essayons d'utiliser un MCP Server via Visual Studio Code à travers un exercice.

## Exercice : Consommer un serveur

Dans cet exercice, nous allons configurer Visual Studio Code pour qu'il puisse trouver votre MCP Server afin de l'utiliser depuis l'interface de chat de GitHub Copilot.

### -0- Étape préalable, activer la découverte du MCP Server

Il se peut que vous deviez activer la découverte des MCP Servers.

1. Allez dans `File -> Preferences -> Settings` in Visual Studio Code.

1. Search for "MCP" and enable `chat.mcp.discovery.enabled` dans le fichier settings.json.

### -1- Créer le fichier de configuration

Commencez par créer un fichier de configuration à la racine de votre projet, vous aurez besoin d'un fichier nommé MCP.json à placer dans un dossier appelé .vscode. Il devrait ressembler à ceci :

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
           "command": "cmd",
           "args": [
               "/c", "node", "<absolute path>\\build\\index.js"
           ]
       }
    }
}
```

Voici un exemple simple ci-dessus montrant comment démarrer un serveur écrit en Node.js. Pour d'autres environnements, indiquez la commande appropriée pour lancer le serveur en utilisant `command` and `args`.

### -3- Démarrer le serveur

Maintenant que vous avez ajouté une entrée, lançons le serveur :

1. Trouvez votre entrée dans *mcp.json* et assurez-vous de voir l'icône "play" :

  ![Démarrage du serveur dans Visual Studio Code](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.fr.png)  

1. Cliquez sur l'icône "play", vous devriez voir l'icône des outils dans le chat GitHub Copilot augmenter le nombre d'outils disponibles. En cliquant sur cette icône, vous verrez la liste des outils enregistrés. Vous pouvez cocher/décocher chaque outil selon que vous souhaitez que GitHub Copilot les utilise comme contexte :

  ![Outils dans Visual Studio Code](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.fr.png)

1. Pour exécuter un outil, tapez une requête correspondant à la description d'un de vos outils, par exemple une requête comme "add 22 to 1" :

  ![Exécution d'un outil depuis GitHub Copilot](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.fr.png)

  Vous devriez voir une réponse indiquant 23.

## Exercice à réaliser

Essayez d'ajouter une entrée serveur dans votre fichier *mcp.json* et assurez-vous de pouvoir démarrer/arrêter le serveur. Vérifiez également que vous pouvez communiquer avec les outils de votre serveur via l'interface de chat de GitHub Copilot.

## Solution

[Solution](./solution/README.md)

## Points clés à retenir

Voici les points importants de ce chapitre :

- Visual Studio Code est un excellent client qui vous permet de consommer plusieurs MCP Servers et leurs outils.
- L'interface de chat de GitHub Copilot est le moyen d'interagir avec les serveurs.
- Vous pouvez demander à l'utilisateur des informations comme des clés API qui seront transmises au MCP Server lors de la configuration de l'entrée serveur dans le fichier *mcp.json*.

## Exemples

- [Calculatrice Java](../samples/java/calculator/README.md)
- [Calculatrice .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculatrice JavaScript](../samples/javascript/README.md)
- [Calculatrice TypeScript](../samples/typescript/README.md)
- [Calculatrice Python](../../../../03-GettingStarted/samples/python)

## Ressources supplémentaires

- [Documentation Visual Studio](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Et après ?

- Suivant : [Créer un serveur SSE](/03-GettingStarted/05-sse-server/README.md)

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatisées peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, il est recommandé de recourir à une traduction professionnelle humaine. Nous ne sommes pas responsables des malentendus ou des mauvaises interprétations résultant de l’utilisation de cette traduction.