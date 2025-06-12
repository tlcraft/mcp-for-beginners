<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1980763f2a545ca6648363bf5757b5a",
  "translation_date": "2025-06-12T22:26:32+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "fr"
}
-->
# Consommer un serveur depuis l’extension AI Toolkit pour Visual Studio Code

Lorsque vous créez un agent IA, il ne s'agit pas seulement de générer des réponses intelligentes ; il s'agit aussi de donner à votre agent la capacité d’agir. C’est là qu’intervient le Model Context Protocol (MCP). MCP facilite l’accès des agents à des outils et services externes de manière cohérente. Imaginez-le comme une boîte à outils dans laquelle votre agent peut *vraiment* puiser.

Supposons que vous connectiez un agent à votre serveur MCP de calculatrice. Soudainement, votre agent peut effectuer des opérations mathématiques simplement en recevant une question comme « Combien font 47 fois 89 ? » — sans avoir besoin de coder la logique ou de créer des API personnalisées.

## Aperçu

Cette leçon explique comment connecter un serveur MCP de calculatrice à un agent avec l’extension [AI Toolkit](https://aka.ms/AIToolkit) dans Visual Studio Code, permettant à votre agent d’effectuer des opérations mathématiques telles que l’addition, la soustraction, la multiplication et la division via un langage naturel.

AI Toolkit est une extension puissante pour Visual Studio Code qui simplifie le développement d’agents. Les ingénieurs IA peuvent facilement créer des applications IA en développant et testant des modèles génératifs, localement ou dans le cloud. L’extension supporte la plupart des modèles génératifs majeurs disponibles aujourd’hui.

*Note* : AI Toolkit supporte actuellement Python et TypeScript.

## Objectifs d’apprentissage

À la fin de cette leçon, vous serez capable de :

- Consommer un serveur MCP via AI Toolkit.
- Configurer une configuration d’agent pour lui permettre de découvrir et d’utiliser les outils fournis par le serveur MCP.
- Utiliser les outils MCP via un langage naturel.

## Approche

Voici comment aborder cela de manière globale :

- Créer un agent et définir son prompt système.
- Créer un serveur MCP avec des outils de calculatrice.
- Connecter l’Agent Builder au serveur MCP.
- Tester l’invocation des outils de l’agent via un langage naturel.

Parfait, maintenant que nous comprenons le déroulement, configurons un agent IA pour exploiter des outils externes via MCP, afin d’enrichir ses capacités !

## Prérequis

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit pour Visual Studio Code](https://aka.ms/AIToolkit)

## Exercice : Consommer un serveur

Dans cet exercice, vous allez construire, exécuter et améliorer un agent IA avec des outils provenant d’un serveur MCP dans Visual Studio Code en utilisant AI Toolkit.

### -0- Étape préalable, ajouter le modèle OpenAI GPT-4o à Mes Modèles

L’exercice utilise le modèle **GPT-4o**. Ce modèle doit être ajouté à **Mes Modèles** avant de créer l’agent.

![Capture d’écran de l’interface de sélection de modèle dans l’extension AI Toolkit de Visual Studio Code. Le titre indique "Find the right model for your AI Solution" avec un sous-titre encourageant à découvrir, tester et déployer des modèles IA. Sous “Popular Models,” six cartes de modèles sont affichées : DeepSeek-R1 (hébergé sur GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Petit, Rapide), et DeepSeek-R1 (hébergé sur Ollama). Chaque carte propose des options pour “Add” le modèle ou “Try in Playground”.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.fr.png)

1. Ouvrez l’extension **AI Toolkit** depuis la **Barre d’activité**.
1. Dans la section **Catalog**, sélectionnez **Models** pour ouvrir le **Model Catalog**. Sélectionner **Models** ouvre le **Model Catalog** dans un nouvel onglet de l’éditeur.
1. Dans la barre de recherche du **Model Catalog**, tapez **OpenAI GPT-4o**.
1. Cliquez sur **+ Add** pour ajouter le modèle à votre liste **Mes Modèles**. Assurez-vous de sélectionner le modèle **hébergé par GitHub**.
1. Dans la **Barre d’activité**, vérifiez que le modèle **OpenAI GPT-4o** apparaît bien dans la liste.

### -1- Créer un agent

L’**Agent (Prompt) Builder** vous permet de créer et personnaliser vos propres agents IA. Dans cette section, vous allez créer un nouvel agent et lui assigner un modèle pour alimenter la conversation.

![Capture d’écran de l’interface “Calculator Agent” dans l’extension AI Toolkit pour Visual Studio Code. Sur le panneau de gauche, le modèle sélectionné est "OpenAI GPT-4o (via GitHub)." Un prompt système indique "Vous êtes un professeur d’université enseignant les mathématiques," et le prompt utilisateur dit, "Explique-moi l’équation de Fourier en termes simples." Des options supplémentaires incluent des boutons pour ajouter des outils, activer MCP Server, et sélectionner la sortie structurée. Un bouton bleu “Run” est en bas. Sur le panneau de droite, sous "Get Started with Examples," trois agents exemples sont listés : Web Developer (avec MCP Server, Simplificateur de CE1, et Interprète de rêves, chacun avec une courte description de leurs fonctions).](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.fr.png)

1. Ouvrez l’extension **AI Toolkit** depuis la **Barre d’activité**.
1. Dans la section **Tools**, sélectionnez **Agent (Prompt) Builder**. Cela ouvre l’**Agent (Prompt) Builder** dans un nouvel onglet de l’éditeur.
1. Cliquez sur le bouton **+ New Agent**. L’extension lancera un assistant via la **Palette de commandes**.
1. Entrez le nom **Calculator Agent** et appuyez sur **Entrée**.
1. Dans l’**Agent (Prompt) Builder**, pour le champ **Model**, sélectionnez le modèle **OpenAI GPT-4o (via GitHub)**.

### -2- Créer un prompt système pour l’agent

Une fois l’agent créé, il est temps de définir sa personnalité et sa mission. Dans cette section, vous allez utiliser la fonction **Generate system prompt** pour décrire le comportement attendu de l’agent — ici, un agent calculatrice — et laisser le modèle générer le prompt système pour vous.

![Capture d’écran de l’interface “Calculator Agent” dans AI Toolkit pour Visual Studio Code avec une fenêtre modale ouverte intitulée "Generate a prompt." La modale explique qu’un template de prompt peut être généré en partageant des informations basiques et inclut une zone de texte avec l’exemple de prompt système : "Vous êtes un assistant mathématique utile et efficace. Lorsqu’on vous donne un problème d’arithmétique de base, vous répondez avec le résultat correct." Sous la zone de texte, les boutons "Close" et "Generate" sont visibles. En arrière-plan, une partie de la configuration de l’agent est visible, incluant le modèle sélectionné "OpenAI GPT-4o (via GitHub)" et les champs pour les prompts système et utilisateur.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.fr.png)

1. Dans la section **Prompts**, cliquez sur le bouton **Generate system prompt**. Ce bouton ouvre le générateur de prompt qui utilise l’IA pour créer un prompt système pour l’agent.
1. Dans la fenêtre **Generate a prompt**, saisissez ce qui suit : `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Cliquez sur le bouton **Generate**. Une notification apparaîtra en bas à droite confirmant la génération du prompt système. Une fois la génération terminée, le prompt apparaîtra dans le champ **System prompt** de l’**Agent (Prompt) Builder**.
1. Relisez le **System prompt** et modifiez-le si nécessaire.

### -3- Créer un serveur MCP

Maintenant que vous avez défini le prompt système de votre agent — qui guide son comportement et ses réponses — il est temps de lui donner des capacités pratiques. Dans cette section, vous allez créer un serveur MCP de calculatrice avec des outils pour effectuer des additions, soustractions, multiplications et divisions. Ce serveur permettra à votre agent d’exécuter des opérations mathématiques en temps réel en réponse à des requêtes en langage naturel.

![Capture d’écran de la partie basse de l’interface Calculator Agent dans l’extension AI Toolkit pour Visual Studio Code. On y voit des menus extensibles “Tools” et “Structure output,” ainsi qu’un menu déroulant “Choose output format” réglé sur “text.” À droite, un bouton “+ MCP Server” pour ajouter un serveur Model Context Protocol. Un espace réservé d’icône d’image est visible au-dessus de la section Tools.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.fr.png)

AI Toolkit est fourni avec des templates pour faciliter la création de votre propre serveur MCP. Nous utiliserons le template Python pour créer le serveur MCP de calculatrice.

*Note* : AI Toolkit supporte actuellement Python et TypeScript.

1. Dans la section **Tools** de l’**Agent (Prompt) Builder**, cliquez sur le bouton **+ MCP Server**. L’extension lancera un assistant via la **Palette de commandes**.
1. Sélectionnez **+ Add Server**.
1. Sélectionnez **Create a New MCP Server**.
1. Sélectionnez le template **python-weather**.
1. Sélectionnez **Default folder** pour enregistrer le template du serveur MCP.
1. Entrez le nom suivant pour le serveur : **Calculator**
1. Une nouvelle fenêtre Visual Studio Code s’ouvrira. Sélectionnez **Yes, I trust the authors**.
1. Dans le terminal (**Terminal** > **New Terminal**), créez un environnement virtuel : `python -m venv .venv`
1. Dans le terminal, activez l’environnement virtuel :
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Dans le terminal, installez les dépendances : `pip install -e .[dev]`
1. Dans la vue **Explorer** de la **Barre d’activité**, développez le répertoire **src** et ouvrez le fichier **server.py** dans l’éditeur.
1. Remplacez le code dans le fichier **server.py** par ce qui suit, puis enregistrez :

    ```python
    """
    Sample MCP Calculator Server implementation in Python.

    
    This module demonstrates how to create a simple MCP server with calculator tools
    that can perform basic arithmetic operations (add, subtract, multiply, divide).
    """
    
    from mcp.server.fastmcp import FastMCP
    
    server = FastMCP("calculator")
    
    @server.tool()
    def add(a: float, b: float) -> float:
        """Add two numbers together and return the result."""
        return a + b
    
    @server.tool()
    def subtract(a: float, b: float) -> float:
        """Subtract b from a and return the result."""
        return a - b
    
    @server.tool()
    def multiply(a: float, b: float) -> float:
        """Multiply two numbers together and return the result."""
        return a * b
    
    @server.tool()
    def divide(a: float, b: float) -> float:
        """
        Divide a by b and return the result.
        
        Raises:
            ValueError: If b is zero
        """
        if b == 0:
            raise ValueError("Cannot divide by zero")
        return a / b
    ```

### -4- Exécuter l’agent avec le serveur MCP de calculatrice

Maintenant que votre agent dispose d’outils, il est temps de les utiliser ! Dans cette section, vous allez soumettre des requêtes à l’agent pour tester et vérifier s’il utilise bien l’outil approprié du serveur MCP de calculatrice.

![Capture d’écran de l’interface Calculator Agent dans l’extension AI Toolkit pour Visual Studio Code. Sur le panneau gauche, sous “Tools,” un serveur MCP nommé local-server-calculator_server est ajouté, affichant quatre outils disponibles : add, subtract, multiply, et divide. Un badge indique que quatre outils sont actifs. En dessous, la section “Structure output” est repliée, et un bouton bleu “Run” est visible. Sur le panneau de droite, sous “Model Response,” l’agent invoque les outils multiply et subtract avec les entrées {"a": 3, "b": 25} et {"a": 75, "b": 20} respectivement. La “Tool Response” finale est affichée comme 75.0. Un bouton “View Code” apparaît en bas.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.fr.png)

Vous exécuterez le serveur MCP de calculatrice sur votre machine locale via **Agent Builder** en tant que client MCP.

1. Appuyez sur `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `J’ai acheté 3 articles à 25 $ chacun, puis utilisé une remise de 20 $. Combien ai-je payé ?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` sont assignées pour l’outil **subtract**.
    - La réponse de chaque outil est affichée dans la section **Tool Response** correspondante.
    - La sortie finale du modèle est affichée dans la section **Model Response** finale.
1. Soumettez d’autres requêtes pour tester davantage l’agent. Vous pouvez modifier le prompt existant dans le champ **User prompt** en cliquant dans le champ et en remplaçant le texte.
1. Une fois vos tests terminés, vous pouvez arrêter le serveur via le **terminal** en entrant **CTRL/CMD+C** pour quitter.

## Travail à réaliser

Essayez d’ajouter une entrée d’outil supplémentaire dans votre fichier **server.py** (par exemple : retourner la racine carrée d’un nombre). Soumettez des requêtes qui obligeraient l’agent à utiliser votre nouvel outil (ou les outils existants). N’oubliez pas de redémarrer le serveur pour charger les outils nouvellement ajoutés.

## Solution

[Solution](./solution/README.md)

## Points clés à retenir

Voici les points clés de ce chapitre :

- L’extension AI Toolkit est un excellent client qui vous permet de consommer des serveurs MCP et leurs outils.
- Vous pouvez ajouter de nouveaux outils aux serveurs MCP, élargissant ainsi les capacités de l’agent pour répondre à des besoins évolutifs.
- AI Toolkit inclut des templates (par exemple, des templates de serveur MCP en Python) pour simplifier la création d’outils personnalisés.

## Ressources supplémentaires

- [Documentation AI Toolkit](https://aka.ms/AIToolkit/doc)

## Et après ?

- Suivant : [Testing & Debugging](/03-GettingStarted/08-testing/README.md)

**Avertissement** :  
Ce document a été traduit à l'aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforçons d'assurer l'exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d'origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle humaine est recommandée. Nous ne sommes pas responsables des malentendus ou des erreurs d'interprétation résultant de l'utilisation de cette traduction.