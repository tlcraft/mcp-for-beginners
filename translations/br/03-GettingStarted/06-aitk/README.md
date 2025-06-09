<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:35:56+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "br"
}
-->
# Konsommer un serveur depuis l’extension AI Toolkit pour Visual Studio Code

Quand vous créez un agent IA, il ne s'agit pas seulement de générer des réponses intelligentes ; il faut aussi donner à votre agent la capacité d’agir. C’est là qu’intervient le Model Context Protocol (MCP). MCP facilite l’accès des agents à des outils et services externes de manière cohérente. Imaginez-le comme une boîte à outils dans laquelle votre agent peut *vraiment* puiser.

Par exemple, si vous connectez un agent à votre serveur MCP calculatrice, votre agent pourra effectuer des opérations mathématiques simplement en recevant une requête comme « Combien font 47 fois 89 ? » — sans avoir à coder la logique ou créer des API personnalisées.

## Vue d’ensemble

Cette leçon explique comment connecter un serveur MCP calculatrice à un agent avec l’extension [AI Toolkit](https://aka.ms/AIToolkit) dans Visual Studio Code, permettant à votre agent de réaliser des opérations mathématiques telles que addition, soustraction, multiplication et division via le langage naturel.

AI Toolkit est une extension puissante pour Visual Studio Code qui simplifie le développement d’agents. Les ingénieurs IA peuvent facilement créer des applications IA en développant et testant des modèles génératifs, localement ou dans le cloud. L’extension prend en charge la plupart des modèles génératifs majeurs disponibles aujourd’hui.

*Note* : AI Toolkit supporte actuellement Python et TypeScript.

## Objectifs d’apprentissage

À la fin de cette leçon, vous serez capable de :

- Consommer un serveur MCP via AI Toolkit.
- Configurer un agent pour lui permettre de découvrir et utiliser les outils fournis par le serveur MCP.
- Utiliser les outils MCP via le langage naturel.

## Approche

Voici comment aborder cela à un niveau global :

- Créer un agent et définir son prompt système.
- Créer un serveur MCP avec des outils calculatrice.
- Connecter l’Agent Builder au serveur MCP.
- Tester l’invocation des outils de l’agent via langage naturel.

Parfait, maintenant que nous comprenons le déroulé, configurons un agent IA pour exploiter des outils externes via MCP et ainsi augmenter ses capacités !

## Prérequis

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit pour Visual Studio Code](https://aka.ms/AIToolkit)

## Exercice : Consommer un serveur

Dans cet exercice, vous allez construire, exécuter et améliorer un agent IA avec des outils d’un serveur MCP dans Visual Studio Code grâce à AI Toolkit.

### -0- Étape préalable, ajoutez le modèle OpenAI GPT-4o à Mes Modèles

L’exercice utilise le modèle **GPT-4o**. Ce modèle doit être ajouté à **Mes Modèles** avant de créer l’agent.

![Capture d’écran de l’interface de sélection de modèle dans l’extension AI Toolkit de Visual Studio Code. Le titre indique « Find the right model for your AI Solution » avec un sous-titre invitant à découvrir, tester et déployer des modèles IA. Sous « Popular Models », six cartes de modèles sont affichées : DeepSeek-R1 (hébergé sur GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), et DeepSeek-R1 (hébergé sur Ollama). Chaque carte propose des options « Add » ou « Try in Playground ».](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.br.png)

1. Ouvrez l’extension **AI Toolkit** depuis la **Barre d’activité**.
2. Dans la section **Catalog**, sélectionnez **Models** pour ouvrir le **Model Catalog**. Cette action ouvre le catalogue dans un nouvel onglet.
3. Dans la barre de recherche du **Model Catalog**, saisissez **OpenAI GPT-4o**.
4. Cliquez sur **+ Add** pour ajouter le modèle à votre liste **My Models**. Vérifiez que vous avez choisi le modèle **Hosted by GitHub**.
5. Dans la **Barre d’activité**, assurez-vous que le modèle **OpenAI GPT-4o** apparaît dans la liste.

### -1- Créer un agent

L’**Agent (Prompt) Builder** vous permet de créer et personnaliser vos propres agents IA. Ici, vous allez créer un nouvel agent et lui attribuer un modèle pour alimenter la conversation.

![Capture d’écran de l’interface du builder « Calculator Agent » dans l’extension AI Toolkit de Visual Studio Code. Sur le panneau de gauche, le modèle sélectionné est « OpenAI GPT-4o (via GitHub) ». Un prompt système indique « You are a professor in university teaching math », et le prompt utilisateur dit « Explain to me the Fourier equation in simple terms. » Des options supplémentaires incluent des boutons pour ajouter des outils, activer MCP Server, et choisir une sortie structurée. Un bouton bleu « Run » est en bas. Sur le panneau de droite, sous « Get Started with Examples », trois agents exemples sont listés : Web Developer (avec MCP Server), Second-Grade Simplifier, et Dream Interpreter, chacun avec une brève description.](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.br.png)

1. Ouvrez l’extension **AI Toolkit** depuis la **Barre d’activité**.
2. Dans la section **Tools**, sélectionnez **Agent (Prompt) Builder**. Cela ouvre le builder dans un nouvel onglet.
3. Cliquez sur le bouton **+ New Agent**. L’extension lance un assistant via la **Palette de commandes**.
4. Entrez le nom **Calculator Agent** et appuyez sur **Entrée**.
5. Dans le builder, pour le champ **Model**, sélectionnez le modèle **OpenAI GPT-4o (via GitHub)**.

### -2- Créer un prompt système pour l’agent

Avec l’agent créé, il est temps de définir sa personnalité et son objectif. Ici, vous allez utiliser la fonction **Generate system prompt** pour décrire le comportement attendu de l’agent — un agent calculatrice — et laisser le modèle générer ce prompt système.

![Capture d’écran de l’interface « Calculator Agent » dans AI Toolkit avec une fenêtre modale intitulée « Generate a prompt ». La modale explique qu’un template de prompt peut être généré en fournissant des détails de base et inclut une zone de texte avec un exemple : « You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result. » Sous la zone, les boutons « Close » et « Generate ». En arrière-plan, une partie de la configuration de l’agent est visible, avec le modèle sélectionné « OpenAI GPT-4o (via GitHub) » et les champs prompts système et utilisateur.](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.br.png)

1. Dans la section **Prompts**, cliquez sur le bouton **Generate system prompt**. Ce bouton ouvre le générateur de prompt qui utilise l’IA pour créer un prompt système.
2. Dans la fenêtre **Generate a prompt**, saisissez : `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. Cliquez sur **Generate**. Une notification apparaît en bas à droite pour confirmer que le prompt est en cours de génération. Une fois terminé, le prompt s’affiche dans le champ **System prompt** du builder.
4. Relisez le **System prompt** et modifiez-le si besoin.

### -3- Créer un serveur MCP

Maintenant que vous avez défini le prompt système de l’agent — qui guide son comportement et ses réponses — il est temps de lui donner des capacités concrètes. Ici, vous allez créer un serveur MCP calculatrice avec des outils pour effectuer addition, soustraction, multiplication et division. Ce serveur permettra à votre agent d’exécuter des opérations mathématiques en temps réel à partir de requêtes en langage naturel.

![Capture d’écran de la partie basse de l’interface Calculator Agent dans AI Toolkit. On y voit des menus dépliables « Tools » et « Structure output », un menu déroulant « Choose output format » réglé sur « text », et un bouton « + MCP Server » pour ajouter un serveur Model Context Protocol. Une icône image est affichée au-dessus de la section Tools.](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.br.png)

AI Toolkit propose des templates pour faciliter la création de serveurs MCP. Nous utiliserons le template Python pour créer ce serveur calculatrice.

*Note* : AI Toolkit supporte actuellement Python et TypeScript.

1. Dans la section **Tools** de l’**Agent (Prompt) Builder**, cliquez sur le bouton **+ MCP Server**. L’extension lance un assistant via la **Palette de commandes**.
2. Sélectionnez **+ Add Server**.
3. Sélectionnez **Create a New MCP Server**.
4. Choisissez le template **python-weather**.
5. Sélectionnez **Default folder** pour sauvegarder le template.
6. Nommez le serveur : **Calculator**
7. Une nouvelle fenêtre Visual Studio Code s’ouvre. Sélectionnez **Yes, I trust the authors**.
8. Dans le terminal (**Terminal** > **New Terminal**), créez un environnement virtuel : `python -m venv .venv`
9. Activez l’environnement virtuel via le terminal :
    1. Windows - `.venv\Scripts\activate`
    2. macOS/Linux - `source venv/bin/activate`
10. Installez les dépendances via le terminal : `pip install -e .[dev]`
11. Dans l’explorateur de fichiers (**Activity Bar**), développez le dossier **src** et ouvrez **server.py**.
12. Remplacez le contenu du fichier **server.py** par le code suivant et enregistrez :

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

Maintenant que votre agent dispose d’outils, il est temps de les utiliser ! Ici, vous allez envoyer des requêtes à l’agent pour vérifier qu’il utilise bien les outils appropriés du serveur MCP calculatrice.

![Capture d’écran de l’interface Calculator Agent dans AI Toolkit. Sur le panneau gauche, sous « Tools », un serveur MCP nommé local-server-calculator_server est ajouté, montrant quatre outils disponibles : add, subtract, multiply, et divide. Un badge indique que quatre outils sont actifs. En dessous, la section « Structure output » est repliée et un bouton bleu « Run » est visible. Sur le panneau droit, sous « Model Response », l’agent invoque les outils multiply et subtract avec les entrées {"a": 3, "b": 25} et {"a": 75, "b": 20} respectivement. La réponse finale de l’outil est affichée comme 75.0. Un bouton « View Code » est en bas.](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.br.png)

Vous allez exécuter le serveur MCP calculatrice sur votre machine locale en tant que client MCP via l’**Agent Builder**.

1. Appuyez sur `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `J’ai acheté 3 articles à 25 $ chacun, puis utilisé une remise de 20 $. Combien ai-je payé ?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` sont assignées à l’outil **subtract**.
    - La réponse de chaque outil apparaît dans la section **Tool Response** correspondante.
    - Le résultat final du modèle est affiché dans la section **Model Response**.
2. Soumettez d’autres requêtes pour tester davantage l’agent. Vous pouvez modifier le prompt existant dans le champ **User prompt** en cliquant dedans et en remplaçant le texte.
3. Une fois vos tests terminés, vous pouvez arrêter le serveur via le **terminal** en tapant **CTRL/CMD+C**.

## Exercice à réaliser

Essayez d’ajouter une nouvelle fonction dans votre fichier **server.py** (par exemple : retourner la racine carrée d’un nombre). Envoyez des requêtes supplémentaires qui obligeraient l’agent à utiliser votre nouvel outil (ou les outils existants). N’oubliez pas de redémarrer le serveur pour prendre en compte les nouveaux outils.

## Solution

[Solution](./solution/README.md)

## Points clés à retenir

Voici les points clés de ce chapitre :

- L’extension AI Toolkit est un excellent client qui vous permet de consommer des serveurs MCP et leurs outils.
- Vous pouvez ajouter de nouveaux outils aux serveurs MCP, étendant ainsi les capacités de l’agent pour répondre à des besoins évolutifs.
- AI Toolkit inclut des templates (par exemple, des templates Python pour serveurs MCP) pour simplifier la création d’outils personnalisés.

## Ressources supplémentaires

- [Documentation AI Toolkit](https://aka.ms/AIToolkit/doc)

## Et après ?

Suivant : [Leçon 4 Mise en pratique](/04-PracticalImplementation/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte oficial. Para informações críticas, recomenda-se a tradução profissional realizada por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.