<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-13T21:23:48+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "fr"
}
-->
# Consommer un serveur depuis l’extension AI Toolkit pour Visual Studio Code

Lorsque vous créez un agent IA, il ne s’agit pas seulement de générer des réponses intelligentes ; il faut aussi donner à votre agent la capacité d’agir. C’est là qu’intervient le Model Context Protocol (MCP). MCP facilite l’accès des agents à des outils et services externes de manière cohérente. Imaginez-le comme une boîte à outils dans laquelle votre agent peut *vraiment* puiser.

Supposons que vous connectiez un agent à votre serveur MCP calculatrice. Soudain, votre agent peut effectuer des opérations mathématiques simplement en recevant une question comme « Combien font 47 fois 89 ? » — sans avoir à coder la logique ou créer des API personnalisées.

## Vue d’ensemble

Cette leçon explique comment connecter un serveur MCP calculatrice à un agent avec l’extension [AI Toolkit](https://aka.ms/AIToolkit) dans Visual Studio Code, permettant à votre agent d’effectuer des opérations mathématiques telles que l’addition, la soustraction, la multiplication et la division via le langage naturel.

AI Toolkit est une extension puissante pour Visual Studio Code qui simplifie le développement d’agents. Les ingénieurs IA peuvent facilement créer des applications IA en développant et testant des modèles génératifs, localement ou dans le cloud. L’extension prend en charge la plupart des modèles génératifs majeurs disponibles aujourd’hui.

*Note* : AI Toolkit supporte actuellement Python et TypeScript.

## Objectifs d’apprentissage

À la fin de cette leçon, vous serez capable de :

- Consommer un serveur MCP via AI Toolkit.
- Configurer une configuration d’agent pour lui permettre de découvrir et utiliser les outils fournis par le serveur MCP.
- Utiliser les outils MCP via le langage naturel.

## Approche

Voici comment aborder cela à un niveau global :

- Créer un agent et définir son prompt système.
- Créer un serveur MCP avec des outils calculatrice.
- Connecter l’Agent Builder au serveur MCP.
- Tester l’invocation des outils de l’agent via le langage naturel.

Parfait, maintenant que nous comprenons le déroulement, configurons un agent IA pour exploiter des outils externes via MCP, afin d’enrichir ses capacités !

## Prérequis

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit pour Visual Studio Code](https://aka.ms/AIToolkit)

## Exercice : Consommer un serveur

Dans cet exercice, vous allez construire, exécuter et améliorer un agent IA avec des outils provenant d’un serveur MCP dans Visual Studio Code en utilisant AI Toolkit.

### -0- Étape préalable, ajouter le modèle OpenAI GPT-4o à Mes Modèles

L’exercice utilise le modèle **GPT-4o**. Ce modèle doit être ajouté à **Mes Modèles** avant de créer l’agent.

![Capture d’écran de l’interface de sélection de modèle dans l’extension AI Toolkit de Visual Studio Code. Le titre indique « Trouvez le modèle adapté à votre solution IA » avec un sous-titre invitant à découvrir, tester et déployer des modèles IA. Sous « Modèles populaires », six cartes de modèles sont affichées : DeepSeek-R1 (hébergé sur GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Petit, Rapide), et DeepSeek-R1 (hébergé sur Ollama). Chaque carte propose des options « Ajouter » ou « Essayer dans le Playground ».](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.fr.png)

1. Ouvrez l’extension **AI Toolkit** depuis la **Barre d’activité**.
1. Dans la section **Catalogue**, sélectionnez **Modèles** pour ouvrir le **Catalogue de modèles**. La sélection ouvre le catalogue dans un nouvel onglet d’éditeur.
1. Dans la barre de recherche du **Catalogue de modèles**, saisissez **OpenAI GPT-4o**.
1. Cliquez sur **+ Ajouter** pour ajouter le modèle à votre liste **Mes Modèles**. Assurez-vous de choisir le modèle **hébergé par GitHub**.
1. Dans la **Barre d’activité**, vérifiez que le modèle **OpenAI GPT-4o** apparaît dans la liste.

### -1- Créer un agent

Le **Agent (Prompt) Builder** vous permet de créer et personnaliser vos propres agents IA. Dans cette section, vous allez créer un nouvel agent et lui assigner un modèle pour alimenter la conversation.

![Capture d’écran de l’interface du constructeur « Calculator Agent » dans l’extension AI Toolkit pour Visual Studio Code. Dans le panneau de gauche, le modèle sélectionné est « OpenAI GPT-4o (via GitHub) ». Un prompt système indique « Vous êtes un professeur d’université enseignant les mathématiques », et le prompt utilisateur dit « Expliquez-moi l’équation de Fourier en termes simples. » Des options supplémentaires incluent des boutons pour ajouter des outils, activer MCP Server, et sélectionner une sortie structurée. Un bouton bleu « Exécuter » est en bas. Dans le panneau de droite, sous « Commencer avec des exemples », trois agents exemples sont listés : Développeur Web (avec MCP Server, Simplificateur de CE1, et Interprète de rêves, chacun avec une brève description de leurs fonctions).](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.fr.png)

1. Ouvrez l’extension **AI Toolkit** depuis la **Barre d’activité**.
1. Dans la section **Outils**, sélectionnez **Agent (Prompt) Builder**. Cela ouvre le constructeur dans un nouvel onglet d’éditeur.
1. Cliquez sur le bouton **+ Nouvel Agent**. L’extension lance un assistant via la **Palette de commandes**.
1. Entrez le nom **Calculator Agent** et appuyez sur **Entrée**.
1. Dans le **Agent (Prompt) Builder**, pour le champ **Modèle**, sélectionnez le modèle **OpenAI GPT-4o (via GitHub)**.

### -2- Créer un prompt système pour l’agent

Avec l’agent créé, il est temps de définir sa personnalité et son objectif. Dans cette section, vous utiliserez la fonction **Générer un prompt système** pour décrire le comportement attendu de l’agent — ici, un agent calculatrice — et laisser le modèle rédiger le prompt système pour vous.

![Capture d’écran de l’interface « Calculator Agent » dans AI Toolkit pour Visual Studio Code avec une fenêtre modale ouverte intitulée « Générer un prompt ». La modale explique qu’un modèle de prompt peut être généré en partageant des informations de base et inclut une zone de texte avec l’exemple de prompt système : « Vous êtes un assistant mathématique utile et efficace. Lorsqu’on vous présente un problème d’arithmétique de base, vous répondez avec le résultat correct. » Sous la zone de texte, les boutons « Fermer » et « Générer » sont visibles. En arrière-plan, une partie de la configuration de l’agent est visible, incluant le modèle sélectionné « OpenAI GPT-4o (via GitHub) » et les champs pour les prompts système et utilisateur.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.fr.png)

1. Dans la section **Prompts**, cliquez sur le bouton **Générer un prompt système**. Ce bouton ouvre le générateur de prompt qui utilise l’IA pour créer un prompt système pour l’agent.
1. Dans la fenêtre **Générer un prompt**, saisissez : `Vous êtes un assistant mathématique utile et efficace. Lorsqu’on vous présente un problème d’arithmétique de base, vous répondez avec le résultat correct.`
1. Cliquez sur le bouton **Générer**. Une notification apparaîtra en bas à droite confirmant la génération du prompt. Une fois terminée, le prompt apparaîtra dans le champ **Prompt système** du **Agent (Prompt) Builder**.
1. Relisez le **Prompt système** et modifiez-le si nécessaire.

### -3- Créer un serveur MCP

Maintenant que vous avez défini le prompt système de votre agent — qui guide son comportement et ses réponses — il est temps de lui fournir des capacités pratiques. Dans cette section, vous allez créer un serveur MCP calculatrice avec des outils pour effectuer des additions, soustractions, multiplications et divisions. Ce serveur permettra à votre agent d’exécuter des opérations mathématiques en temps réel en réponse à des requêtes en langage naturel.

!["Capture d’écran de la section inférieure de l’interface Calculator Agent dans l’extension AI Toolkit pour Visual Studio Code. On y voit des menus déroulants pour « Outils » et « Sortie structurée », ainsi qu’un menu déroulant « Choisir le format de sortie » réglé sur « texte ». À droite, un bouton « + MCP Server » pour ajouter un serveur Model Context Protocol. Un espace réservé pour une icône d’image est visible au-dessus de la section Outils.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.fr.png)

AI Toolkit est équipé de modèles pour faciliter la création de votre propre serveur MCP. Nous utiliserons le modèle Python pour créer le serveur MCP calculatrice.

*Note* : AI Toolkit supporte actuellement Python et TypeScript.

1. Dans la section **Outils** du **Agent (Prompt) Builder**, cliquez sur le bouton **+ MCP Server**. L’extension lance un assistant via la **Palette de commandes**.
1. Sélectionnez **+ Ajouter un serveur**.
1. Sélectionnez **Créer un nouveau serveur MCP**.
1. Sélectionnez **python-weather** comme modèle.
1. Sélectionnez **Dossier par défaut** pour enregistrer le modèle de serveur MCP.
1. Entrez le nom suivant pour le serveur : **Calculator**
1. Une nouvelle fenêtre Visual Studio Code s’ouvrira. Sélectionnez **Oui, je fais confiance aux auteurs**.
1. Dans le terminal (**Terminal** > **Nouveau terminal**), créez un environnement virtuel : `python -m venv .venv`
1. Activez l’environnement virtuel dans le terminal :
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Installez les dépendances dans le terminal : `pip install -e .[dev]`
1. Dans la vue **Explorateur** de la **Barre d’activité**, développez le répertoire **src** et ouvrez le fichier **server.py**.
1. Remplacez le code dans **server.py** par ce qui suit et enregistrez :

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

Maintenant que votre agent dispose d’outils, il est temps de les utiliser ! Dans cette section, vous soumettrez des requêtes à l’agent pour tester et valider s’il utilise bien l’outil approprié du serveur MCP calculatrice.

![Capture d’écran de l’interface Calculator Agent dans l’extension AI Toolkit pour Visual Studio Code. Dans le panneau de gauche, sous « Outils », un serveur MCP nommé local-server-calculator_server est ajouté, affichant quatre outils disponibles : add, subtract, multiply, et divide. Un badge indique que quatre outils sont actifs. En dessous, une section « Sortie structurée » est repliée et un bouton bleu « Exécuter » est visible. Dans le panneau de droite, sous « Réponse du modèle », l’agent invoque les outils multiply et subtract avec les entrées {"a": 3, "b": 25} et {"a": 75, "b": 20} respectivement. La « Réponse de l’outil » finale est affichée comme 75.0. Un bouton « Voir le code » apparaît en bas.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.fr.png)

Vous allez exécuter le serveur MCP calculatrice sur votre machine de développement locale via l’**Agent Builder** en tant que client MCP.

1. Appuyez sur `F5` pour démarrer le débogage du serveur MCP. Le **Agent (Prompt) Builder** s’ouvrira dans un nouvel onglet d’éditeur. Le statut du serveur est visible dans le terminal.
1. Dans le champ **Prompt utilisateur** du **Agent (Prompt) Builder**, saisissez la requête suivante : `J’ai acheté 3 articles à 25 $ chacun, puis utilisé une remise de 20 $. Combien ai-je payé ?`
1. Cliquez sur le bouton **Exécuter** pour générer la réponse de l’agent.
1. Examinez la sortie de l’agent. Le modèle devrait conclure que vous avez payé **55 $**.
1. Voici ce qui devrait se passer :
    - L’agent sélectionne les outils **multiply** et **subtract** pour aider au calcul.
    - Les valeurs `a` et `b` sont assignées pour l’outil **multiply**.
    - Les valeurs `a` et `b` sont assignées pour l’outil **subtract**.
    - La réponse de chaque outil est fournie dans la section **Réponse de l’outil** respective.
    - La sortie finale du modèle est affichée dans la section **Réponse du modèle**.
1. Soumettez d’autres requêtes pour tester davantage l’agent. Vous pouvez modifier la requête existante dans le champ **Prompt utilisateur** en cliquant dedans et en remplaçant le texte.
1. Une fois vos tests terminés, vous pouvez arrêter le serveur via le **terminal** en appuyant sur **CTRL/CMD+C**.

## Exercice à réaliser

Essayez d’ajouter un outil supplémentaire dans votre fichier **server.py** (par exemple : retourner la racine carrée d’un nombre). Soumettez des requêtes qui nécessiteraient que l’agent utilise votre nouvel outil (ou les outils existants). N’oubliez pas de redémarrer le serveur pour charger les outils ajoutés.

## Solution

[Solution](./solution/README.md)

## Points clés à retenir

Voici les points clés de ce chapitre :

- L’extension AI Toolkit est un excellent client qui vous permet de consommer des serveurs MCP et leurs outils.
- Vous pouvez ajouter de nouveaux outils aux serveurs MCP, élargissant ainsi les capacités de l’agent pour répondre à des besoins évolutifs.
- AI Toolkit inclut des modèles (par exemple, des modèles de serveur MCP en Python) pour simplifier la création d’outils personnalisés.

## Ressources supplémentaires

- [Documentation AI Toolkit](https://aka.ms/AIToolkit/doc)

## Et après ?
- Suivant : [Tests & Débogage](../08-testing/README.md)

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.