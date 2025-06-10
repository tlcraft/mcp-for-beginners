<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-06-10T07:00:05+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "fr"
}
-->
# Weather MCP Server

Ceci est un exemple de MCP Server en Python implémentant des outils météo avec des réponses simulées. Il peut servir de base pour votre propre MCP Server. Il inclut les fonctionnalités suivantes :

- **Weather Tool** : Un outil qui fournit des informations météo simulées en fonction de la localisation donnée.
- **Git Clone Tool** : Un outil qui clone un dépôt git dans un dossier spécifié.
- **VS Code Open Tool** : Un outil qui ouvre un dossier dans VS Code ou VS Code Insiders.
- **Connect to Agent Builder** : Une fonctionnalité qui vous permet de connecter le MCP server à l’Agent Builder pour tester et déboguer.
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)** : Une fonctionnalité qui permet de déboguer le MCP Server avec MCP Inspector.

## Commencer avec le modèle Weather MCP Server

> **Prérequis**
>
> Pour exécuter le MCP Server sur votre machine de développement locale, vous aurez besoin de :
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (Requis pour l’outil git_clone_repo)
> - [VS Code](https://code.visualstudio.com/) ou [VS Code Insiders](https://code.visualstudio.com/insiders/) (Requis pour l’outil open_in_vscode)
> - (*Optionnel - si vous préférez uv*) [uv](https://github.com/astral-sh/uv)
> - [Extension Python Debugger](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Préparer l’environnement

Deux méthodes sont possibles pour configurer l’environnement de ce projet. Vous pouvez choisir celle qui vous convient le mieux.

> Note : Rechargez VSCode ou le terminal pour vous assurer que le python de l’environnement virtuel est utilisé après sa création.

| Méthode | Étapes |
| -------- | ----- |
| Avec `uv` | 1. Créez un environnement virtuel : `uv venv` <br>2. Lancez la commande VSCode "***Python: Select Interpreter***" et sélectionnez le python de l’environnement virtuel créé <br>3. Installez les dépendances (y compris les dépendances de développement) : `uv pip install -r pyproject.toml --extra dev` |
| Avec `pip` | 1. Créez un environnement virtuel : `python -m venv .venv` <br>2. Lancez la commande VSCode "***Python: Select Interpreter***" et sélectionnez le python de l’environnement virtuel créé<br>3. Installez les dépendances (y compris les dépendances de développement) : `pip install -e .[dev]` |

Une fois l’environnement configuré, vous pouvez lancer le serveur sur votre machine locale via Agent Builder en tant que MCP Client pour démarrer :
1. Ouvrez le panneau Debug de VS Code. Sélectionnez `Debug in Agent Builder` ou appuyez sur `F5` pour commencer à déboguer le MCP server.
2. Utilisez AI Toolkit Agent Builder pour tester le serveur avec [ce prompt](../../../../../../../../../../../open_prompt_builder). Le serveur se connectera automatiquement à l’Agent Builder.
3. Cliquez sur `Run` pour tester le serveur avec ce prompt.

**Félicitations** ! Vous avez lancé avec succès le Weather MCP Server sur votre machine locale via Agent Builder en tant que MCP Client.  
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Contenu du modèle

| Dossier / Fichier | Contenu                                    |
| ----------------- | ------------------------------------------ |
| `.vscode`       | Fichiers VSCode pour le débogage            |
| `.aitk`         | Configurations pour AI Toolkit                |
| `src`           | Code source du serveur weather mcp            |

## Comment déboguer le Weather MCP Server

> Notes :  
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) est un outil visuel pour développeurs permettant de tester et déboguer les MCP servers.  
> - Tous les modes de débogage supportent les points d’arrêt, vous pouvez donc en ajouter dans le code d’implémentation des outils.

## Outils disponibles

### Weather Tool  
L’outil `get_weather` fournit des informations météo simulées pour une localisation donnée.

| Paramètre | Type | Description |
| --------- | ---- | ----------- |
| `location` | string | Localisation pour laquelle obtenir la météo (ex. : nom de ville, état ou coordonnées) |

### Git Clone Tool  
L’outil `git_clone_repo` clone un dépôt git dans un dossier spécifié.

| Paramètre | Type | Description |
| --------- | ---- | ----------- |
| `repo_url` | string | URL du dépôt git à cloner |
| `target_folder` | string | Chemin du dossier où le dépôt doit être cloné |

L’outil retourne un objet JSON contenant :  
- `success` : Booléen indiquant si l’opération a réussi  
- `target_folder` ou `error` : Le chemin du dépôt cloné ou un message d’erreur

### VS Code Open Tool  
L’outil `open_in_vscode` ouvre un dossier dans VS Code ou VS Code Insiders.

| Paramètre | Type | Description |
| --------- | ---- | ----------- |
| `folder_path` | string | Chemin du dossier à ouvrir |
| `use_insiders` | boolean (optionnel) | Indique s’il faut utiliser VS Code Insiders au lieu de la version classique |

L’outil retourne un objet JSON contenant :  
- `success` : Booléen indiquant si l’opération a réussi  
- `message` ou `error` : Un message de confirmation ou un message d’erreur

## Mode Debug | Description | Étapes pour déboguer |
| ---------- | ----------- | -------------------- |
| Agent Builder | Déboguer le MCP server dans Agent Builder via AI Toolkit. | 1. Ouvrez le panneau Debug de VS Code. Sélectionnez `Debug in Agent Builder` et appuyez sur `F5` pour commencer à déboguer le MCP server.<br>2. Utilisez AI Toolkit Agent Builder pour tester le serveur avec [ce prompt](../../../../../../../../../../../open_prompt_builder). Le serveur se connectera automatiquement à l’Agent Builder.<br>3. Cliquez sur `Run` pour tester le serveur avec ce prompt. |
| MCP Inspector | Déboguer le MCP server avec MCP Inspector. | 1. Installez [Node.js](https://nodejs.org/)<br> 2. Configurez Inspector : `cd inspector` && `npm install` <br> 3. Ouvrez le panneau Debug de VS Code. Sélectionnez `Debug SSE in Inspector (Edge)` ou `Debug SSE in Inspector (Chrome)`. Appuyez sur F5 pour démarrer le débogage.<br> 4. Quand MCP Inspector se lance dans le navigateur, cliquez sur le bouton `Connect` pour connecter ce MCP server.<br> 5. Ensuite, vous pouvez `List Tools`, sélectionner un outil, saisir des paramètres et `Run Tool` pour déboguer votre code serveur.<br> |

## Ports par défaut et personnalisations

| Mode Debug | Ports | Définitions | Personnalisations | Remarque |
| ---------- | ----- | ----------- | ----------------- | -------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Modifiez [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) pour changer ces ports. | N/A |
| MCP Inspector | 3001 (Serveur); 5173 et 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Modifiez [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) pour changer ces ports. | N/A |

## Retour d’expérience

Si vous avez des retours ou des suggestions concernant ce modèle, veuillez ouvrir une issue sur le [dépôt GitHub AI Toolkit](https://github.com/microsoft/vscode-ai-toolkit/issues)

**Avertissement** :  
Ce document a été traduit à l'aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d'assurer l'exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d'origine doit être considéré comme la source faisant foi. Pour les informations critiques, il est recommandé de recourir à une traduction professionnelle humaine. Nous ne sommes pas responsables des malentendus ou des interprétations erronées résultant de l'utilisation de cette traduction.