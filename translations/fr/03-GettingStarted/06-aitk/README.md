<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:19:50+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "fr"
}
-->
# Consommer un serveur depuis l’extension AI Toolkit pour Visual Studio Code

Lorsque vous créez un agent IA, il ne s'agit pas seulement de générer des réponses intelligentes ; il s'agit aussi de donner à votre agent la capacité d’agir. C’est là qu’intervient le Model Context Protocol (MCP). MCP facilite l’accès des agents à des outils et services externes de manière cohérente. Imaginez-le comme un moyen de brancher votre agent à une boîte à outils qu’il peut *réellement* utiliser.

Par exemple, si vous connectez un agent à votre serveur MCP calculatrice, votre agent pourra effectuer des opérations mathématiques simplement en recevant une requête comme « Combien font 47 fois 89 ? » — sans avoir à coder la logique ou créer des API personnalisées.

## Vue d’ensemble

Cette leçon explique comment connecter un serveur MCP calculatrice à un agent via l’extension [AI Toolkit](https://aka.ms/AIToolkit) dans Visual Studio Code, permettant à votre agent d’effectuer des opérations mathématiques telles que addition, soustraction, multiplication et division en langage naturel.

AI Toolkit est une extension puissante pour Visual Studio Code qui simplifie le développement d’agents. Les ingénieurs IA peuvent facilement créer des applications IA en développant et testant des modèles génératifs—localement ou dans le cloud. L’extension supporte la plupart des modèles génératifs majeurs disponibles aujourd’hui.

*Note* : AI Toolkit supporte actuellement Python et TypeScript.

## Objectifs d’apprentissage

À la fin de cette leçon, vous serez capable de :

- Consommer un serveur MCP via AI Toolkit.
- Configurer une configuration d’agent pour lui permettre de découvrir et utiliser les outils fournis par le serveur MCP.
- Utiliser les outils MCP via le langage naturel.

## Méthodologie

Voici comment aborder cela à un niveau global :

- Créer un agent et définir son prompt système.
- Créer un serveur MCP avec des outils calculatrice.
- Connecter l’Agent Builder au serveur MCP.
- Tester l’invocation des outils de l’agent via le langage naturel.

Parfait, maintenant que nous comprenons le déroulement, configurons un agent IA pour exploiter des outils externes via MCP et ainsi augmenter ses capacités !

## Prérequis

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit pour Visual Studio Code](https://aka.ms/AIToolkit)

## Exercice : Consommer un serveur

Dans cet exercice, vous allez construire, lancer et améliorer un agent IA avec des outils provenant d’un serveur MCP dans Visual Studio Code en utilisant AI Toolkit.

### -0- Étape préalable, ajouter le modèle OpenAI GPT-4o à Mes Modèles

L’exercice utilise le modèle **GPT-4o**. Ce modèle doit être ajouté à **Mes Modèles** avant de créer l’agent.

![Capture d’écran de l’interface de sélection de modèle dans l’extension AI Toolkit de Visual Studio Code. Le titre indique « Trouvez le modèle adapté à votre solution IA » avec un sous-titre invitant à découvrir, tester et déployer des modèles IA. Sous “Popular Models,” six cartes modèles sont affichées : DeepSeek-R1 (hébergé sur GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Petit, Rapide), et DeepSeek-R1 (hébergé sur Ollama). Chaque carte propose les options “Ajouter” ou “Essayer dans Playground”.](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.fr.png)

1. Ouvrez l’extension **AI Toolkit** depuis la **Barre d’activités**.
1. Dans la section **Catalog**, sélectionnez **Models** pour ouvrir le **Model Catalog**. Cette sélection ouvre le **Model Catalog** dans un nouvel onglet éditeur.
1. Dans la barre de recherche du **Model Catalog**, tapez **OpenAI GPT-4o**.
1. Cliquez sur **+ Add** pour ajouter le modèle à votre liste **Mes Modèles**. Assurez-vous de choisir le modèle **hébergé par GitHub**.
1. Dans la **Barre d’activités**, vérifiez que le modèle **OpenAI GPT-4o** apparaît dans la liste.

### -1- Créer un agent

L’**Agent (Prompt) Builder** vous permet de créer et personnaliser vos propres agents IA. Dans cette section, vous allez créer un nouvel agent et lui attribuer un modèle pour alimenter la conversation.

![Capture d’écran de l’interface du builder “Calculator Agent” dans l’extension AI Toolkit pour Visual Studio Code. Sur le panneau gauche, le modèle sélectionné est “OpenAI GPT-4o (via GitHub).” Un prompt système indique “Vous êtes un professeur d’université enseignant les mathématiques,” et le prompt utilisateur dit “Explique-moi l’équation de Fourier en termes simples.” Des options supplémentaires incluent des boutons pour ajouter des outils, activer MCP Server, et sélectionner une sortie structurée. Un bouton bleu “Run” est en bas. Sur le panneau droit, sous “Get Started with Examples,” trois agents exemples sont listés : Web Developer (avec MCP Server, Simplificateur de CE2, et Interprète de rêves, chacun avec une brève description de leurs fonctions).](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.fr.png)

1. Ouvrez l’extension **AI Toolkit** depuis la **Barre d’activités**.
1. Dans la section **Tools**, sélectionnez **Agent (Prompt) Builder**. Cette sélection ouvre l’**Agent (Prompt) Builder** dans un nouvel onglet éditeur.
1. Cliquez sur le bouton **+ New Agent**. L’extension lancera un assistant de configuration via la **Palette de commandes**.
1. Entrez le nom **Calculator Agent** puis appuyez sur **Entrée**.
1. Dans l’**Agent (Prompt) Builder**, pour le champ **Model**, sélectionnez le modèle **OpenAI GPT-4o (via GitHub)**.

### -2- Créer un prompt système pour l’agent

Avec l’agent créé, il est temps de définir sa personnalité et son objectif. Dans cette section, vous allez utiliser la fonction **Generate system prompt** pour décrire le comportement attendu de l’agent — ici, un agent calculatrice — et laisser le modèle rédiger le prompt système pour vous.

![Capture d’écran de l’interface “Calculator Agent” dans AI Toolkit pour Visual Studio Code avec une fenêtre modale ouverte intitulée “Generate a prompt.” La fenêtre explique qu’un template de prompt peut être généré en partageant des détails de base et inclut une zone de texte avec un exemple de prompt système : “Vous êtes un assistant mathématique utile et efficace. Lorsqu’on vous présente un problème d’arithmétique de base, vous répondez avec le résultat correct.” Sous la zone de texte se trouvent les boutons “Close” et “Generate.” En arrière-plan, une partie de la configuration de l’agent est visible, incluant le modèle sélectionné “OpenAI GPT-4o (via GitHub)” et les champs pour les prompts système et utilisateur.](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.fr.png)

1. Dans la section **Prompts**, cliquez sur le bouton **Generate system prompt**. Ce bouton ouvre le générateur de prompt qui utilise l’IA pour créer un prompt système pour l’agent.
1. Dans la fenêtre **Generate a prompt**, entrez ce qui suit : `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Cliquez sur **Generate**. Une notification apparaîtra en bas à droite pour confirmer que le prompt système est en cours de génération. Une fois terminé, le prompt apparaîtra dans le champ **System prompt** de l’**Agent (Prompt) Builder**.
1. Relisez le **System prompt** et modifiez-le si nécessaire.

### -3- Créer un serveur MCP

Maintenant que vous avez défini le prompt système de votre agent — qui guide son comportement et ses réponses — il est temps de lui fournir des capacités pratiques. Dans cette section, vous allez créer un serveur MCP calculatrice avec des outils pour effectuer des additions, soustractions, multiplications et divisions. Ce serveur permettra à votre agent d’exécuter des opérations mathématiques en temps réel à partir de requêtes en langage naturel.

![Capture d’écran de la section inférieure de l’interface Calculator Agent dans l’extension AI Toolkit pour Visual Studio Code. On y voit des menus déroulants pour “Tools” et “Structure output,” ainsi qu’un menu déroulant “Choose output format” réglé sur “text.” À droite, un bouton “+ MCP Server” pour ajouter un serveur Model Context Protocol. Une icône d’image en placeholder est visible au-dessus de la section Tools.](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.fr.png)

AI Toolkit est fourni avec des templates pour faciliter la création de votre propre serveur MCP. Nous utiliserons le template Python pour créer le serveur MCP calculatrice.

*Note* : AI Toolkit supporte actuellement Python et TypeScript.

1. Dans la section **Tools** de l’**Agent (Prompt) Builder**, cliquez sur le bouton **+ MCP Server**. L’extension lancera un assistant de configuration via la **Palette de commandes**.
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
1. Dans la vue **Explorer** de la **Barre d’activités**, développez le répertoire **src** et ouvrez le fichier **server.py** dans l’éditeur.
1. Remplacez le code dans le fichier **server.py** par ce qui suit et enregistrez :

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

### -4- Exécuter l’agent avec le serveur MCP calculatrice

Maintenant que votre agent dispose d’outils, il est temps de les utiliser ! Dans cette section, vous allez envoyer des requêtes à l’agent pour tester et vérifier qu’il utilise bien l’outil adéquat du serveur MCP calculatrice.

![Capture d’écran de l’interface Calculator Agent dans l’extension AI Toolkit pour Visual Studio Code. Sur le panneau gauche, sous “Tools,” un serveur MCP nommé local-server-calculator_server est ajouté, affichant quatre outils disponibles : add, subtract, multiply, et divide. Un badge indique que quatre outils sont actifs. En dessous, une section “Structure output” est repliée et un bouton bleu “Run” est visible. Sur le panneau droit, sous “Model Response,” l’agent invoque les outils multiply et subtract avec les entrées {"a": 3, "b": 25} et {"a": 75, "b": 20} respectivement. La réponse finale de l’outil est affichée comme 75.0. Un bouton “View Code” est visible en bas.](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.fr.png)

Vous allez exécuter le serveur MCP calculatrice sur votre machine locale en tant que client MCP via l’**Agent Builder**.

1. Appuyez sur `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `J’ai acheté 3 articles à 25 $ chacun, puis j’ai utilisé une remise de 20 $. Combien ai-je payé ?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` les valeurs sont assignées pour l’outil **subtract**.
    - La réponse de chaque outil est affichée dans la section **Tool Response** correspondante.
    - La sortie finale du modèle est affichée dans la section **Model Response** finale.
1. Soumettez d’autres requêtes pour tester davantage l’agent. Vous pouvez modifier la requête existante dans le champ **User prompt** en cliquant dedans et en remplaçant le texte.
1. Une fois les tests terminés, vous pouvez arrêter le serveur via le **terminal** en tapant **CTRL/CMD+C** pour quitter.

## Travail à faire

Essayez d’ajouter une nouvelle entrée d’outil dans votre fichier **server.py** (par exemple : calculer la racine carrée d’un nombre). Soumettez des requêtes supplémentaires qui nécessiteraient que l’agent utilise votre nouvel outil (ou les outils existants). N’oubliez pas de redémarrer le serveur pour charger les outils nouvellement ajoutés.

## Solution

[Solution](./solution/README.md)

## Points clés à retenir

Voici les points clés de ce chapitre :

- L’extension AI Toolkit est un excellent client qui vous permet de consommer des serveurs MCP et leurs outils.
- Vous pouvez ajouter de nouveaux outils aux serveurs MCP, élargissant ainsi les capacités de l’agent pour répondre à des besoins évolutifs.
- AI Toolkit inclut des templates (par exemple, des templates Python pour serveurs MCP) pour simplifier la création d’outils personnalisés.

## Ressources supplémentaires

- [Documentation AI Toolkit](https://aka.ms/AIToolkit/doc)

## Et après ?

Suivant : [Leçon 4 Mise en œuvre pratique](/04-PracticalImplementation/README.md)

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle humaine est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.