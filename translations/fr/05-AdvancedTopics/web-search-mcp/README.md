<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b0660b689ab793a8e9aefe29fb7f8b6a",
  "translation_date": "2025-06-02T12:59:40+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "fr"
}
-->
# Leçon : Construire un serveur MCP de recherche web

Ce chapitre montre comment créer un agent IA concret qui s’intègre à des API externes, gère différents types de données, traite les erreurs et orchestre plusieurs outils — le tout dans un format prêt pour la production. Vous découvrirez :

- **Intégration avec des API externes nécessitant une authentification**
- **Gestion de types de données variés provenant de plusieurs points d’accès**
- **Stratégies robustes de gestion des erreurs et de journalisation**
- **Orchestration multi-outils dans un serveur unique**

À la fin, vous aurez une expérience pratique des modèles et bonnes pratiques indispensables pour des applications avancées basées sur l’IA et les LLM.

## Introduction

Dans cette leçon, vous apprendrez à construire un serveur MCP avancé et un client qui étendent les capacités des LLM avec des données web en temps réel grâce à SerpAPI. C’est une compétence clé pour développer des agents IA dynamiques capables d’accéder à des informations actualisées sur le web.

## Objectifs d’apprentissage

À la fin de cette leçon, vous serez capable de :

- Intégrer des API externes (comme SerpAPI) de manière sécurisée dans un serveur MCP
- Implémenter plusieurs outils pour la recherche web, d’actualités, de produits et de questions-réponses
- Analyser et formater des données structurées pour une utilisation par les LLM
- Gérer efficacement les erreurs et les limites de taux des API
- Construire et tester des clients MCP automatisés et interactifs

## Serveur MCP de recherche web

Cette section présente l’architecture et les fonctionnalités du serveur MCP de recherche web. Vous verrez comment FastMCP et SerpAPI sont utilisés ensemble pour étendre les capacités des LLM avec des données web en temps réel.

### Vue d’ensemble

Cette implémentation propose quatre outils illustrant la capacité de MCP à gérer des tâches variées basées sur des API externes, de façon sécurisée et efficace :

- **general_search** : Pour des résultats web larges
- **news_search** : Pour les dernières actualités
- **product_search** : Pour les données e-commerce
- **qna** : Pour des extraits questions-réponses

### Fonctionnalités
- **Exemples de code** : Comprend des blocs de code spécifiques au langage Python (et facilement extensibles à d’autres langages) avec des sections repliables pour plus de clarté

<details>  
<summary>Python</summary>  

```python
# Example usage of the general_search tool
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("general_search", arguments={"query": "open source LLMs"})
            print(result)
```
</details>

Avant de lancer le client, il est utile de comprendre ce que fait le serveur. Le fichier [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

Voici un bref exemple de la manière dont le serveur définit et enregistre un outil :

<details>  
<summary>Serveur Python</summary> 

```python
# server.py (excerpt)
from mcp.server import MCPServer, Tool

async def general_search(query: str):
    # ...implementation...

server = MCPServer()
server.add_tool(Tool("general_search", general_search))

if __name__ == "__main__":
    server.run()
```
</details>

- **Intégration d’API externes** : Montre la gestion sécurisée des clés API et des requêtes externes
- **Analyse des données structurées** : Explique comment transformer les réponses API en formats adaptés aux LLM
- **Gestion des erreurs** : Gestion robuste des erreurs avec journalisation appropriée
- **Client interactif** : Comprend des tests automatisés et un mode interactif pour les essais
- **Gestion du contexte** : Utilise MCP Context pour la journalisation et le suivi des requêtes

## Prérequis

Avant de commencer, assurez-vous que votre environnement est correctement configuré en suivant ces étapes. Cela garantira que toutes les dépendances sont installées et que vos clés API sont bien configurées pour un développement et des tests sans accroc.

- Python 3.8 ou supérieur
- Clé API SerpAPI (Inscrivez-vous sur [SerpAPI](https://serpapi.com/) — offre gratuite disponible)

## Installation

Pour démarrer, suivez ces étapes pour configurer votre environnement :

1. Installez les dépendances avec uv (recommandé) ou pip :

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. Créez un fichier `.env` à la racine du projet avec votre clé SerpAPI :

```
SERPAPI_KEY=your_serpapi_key_here
```

## Utilisation

Le serveur MCP de recherche web est le composant central qui expose des outils pour la recherche web, d’actualités, de produits et de questions-réponses via l’intégration avec SerpAPI. Il traite les requêtes entrantes, gère les appels API, analyse les réponses et renvoie des résultats structurés au client.

Vous pouvez consulter l’implémentation complète dans [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### Démarrage du serveur

Pour lancer le serveur MCP, utilisez la commande suivante :

```bash
python server.py
```

Le serveur fonctionnera en mode MCP basé sur stdio, auquel le client pourra se connecter directement.

### Modes client

Le client (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### Lancer le client

Pour exécuter les tests automatisés (cela démarre automatiquement le serveur) :

```bash
python client.py
```

Ou pour un mode interactif :

```bash
python client.py --interactive
```

### Tester avec différentes méthodes

Plusieurs façons existent pour tester et interagir avec les outils fournis par le serveur, selon vos besoins et votre flux de travail.

#### Écrire des scripts de test personnalisés avec le SDK Python MCP
Vous pouvez aussi créer vos propres scripts de test en utilisant le SDK Python MCP :

<details>
<summary>Python</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def test_custom_query():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            # Call tools with your custom parameters
            result = await session.call_tool("general_search", 
                                           arguments={"query": "your custom query"})
            # Process the result
```
</details>

Ici, un « script de test » désigne un programme Python personnalisé que vous écrivez pour agir en tant que client du serveur MCP. Plutôt qu’un test unitaire formel, ce script vous permet de vous connecter au serveur, d’appeler n’importe lequel de ses outils avec les paramètres de votre choix et d’examiner les résultats. Cette approche est utile pour :
- Prototyper et expérimenter avec les appels aux outils
- Valider les réponses du serveur selon différents inputs
- Automatiser des appels répétitifs aux outils
- Construire vos propres workflows ou intégrations au-dessus du serveur MCP

Les scripts de test vous permettent d’essayer rapidement de nouvelles requêtes, de déboguer le comportement des outils ou même de servir de base à une automatisation plus avancée. Voici un exemple d’utilisation du SDK Python MCP pour créer un tel script :

## Description des outils

Vous pouvez utiliser les outils suivants fournis par le serveur pour effectuer différents types de recherches et requêtes. Chaque outil est décrit ci-dessous avec ses paramètres et un exemple d’utilisation.

Cette section détaille chaque outil disponible ainsi que leurs paramètres.

### general_search

Effectue une recherche web générale et retourne des résultats formatés.

**Comment appeler cet outil :**

Vous pouvez appeler `general_search` depuis votre propre script en utilisant le SDK Python MCP, ou de manière interactive via l’Inspector ou le mode client interactif. Voici un exemple de code avec le SDK :

<details>
<summary>Exemple Python</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_general_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("general_search", arguments={"query": "latest AI trends"})
            print(result)
```
</details>

Sinon, en mode interactif, sélectionnez `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string) : La requête de recherche

**Exemple de requête :**

```json
{
  "query": "latest AI trends"
}
```

### news_search

Recherche des articles d’actualité récents liés à une requête.

**Comment appeler cet outil :**

Vous pouvez appeler `news_search` depuis votre propre script en utilisant le SDK Python MCP, ou de manière interactive via l’Inspector ou le mode client interactif. Voici un exemple de code avec le SDK :

<details>
<summary>Exemple Python</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_news_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("news_search", arguments={"query": "AI policy updates"})
            print(result)
```
</details>

Sinon, en mode interactif, sélectionnez `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string) : La requête de recherche

**Exemple de requête :**

```json
{
  "query": "AI policy updates"
}
```

### product_search

Recherche des produits correspondant à une requête.

**Comment appeler cet outil :**

Vous pouvez appeler `product_search` depuis votre propre script en utilisant le SDK Python MCP, ou de manière interactive via l’Inspector ou le mode client interactif. Voici un exemple de code avec le SDK :

<details>
<summary>Exemple Python</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_product_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("product_search", arguments={"query": "best AI gadgets 2025"})
            print(result)
```
</details>

Sinon, en mode interactif, sélectionnez `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string) : La requête de recherche produit

**Exemple de requête :**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

Obtient des réponses directes à des questions issues des moteurs de recherche.

**Comment appeler cet outil :**

Vous pouvez appeler `qna` depuis votre propre script en utilisant le SDK Python MCP, ou de manière interactive via l’Inspector ou le mode client interactif. Voici un exemple de code avec le SDK :

<details>
<summary>Exemple Python</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_qna():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("qna", arguments={"question": "what is artificial intelligence"})
            print(result)
```
</details>

Sinon, en mode interactif, sélectionnez `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string) : La question à laquelle trouver une réponse

**Exemple de requête :**

```json
{
  "question": "what is artificial intelligence"
}
```

## Détails du code

Cette section fournit des extraits de code et des références pour les implémentations serveur et client.

<details>
<summary>Python</summary>

Consultez [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) pour les détails complets de l’implémentation.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## Concepts avancés dans cette leçon

Avant de commencer à coder, voici quelques concepts avancés importants qui apparaîtront tout au long de ce chapitre. Les comprendre vous aidera à suivre, même si vous n’y êtes pas encore familier :

- **Orchestration multi-outils** : Cela signifie faire fonctionner plusieurs outils différents (comme la recherche web, d’actualités, de produits et Q&A) dans un seul serveur MCP. Cela permet à votre serveur de gérer une variété de tâches, pas seulement une.
- **Gestion des limites de taux API** : De nombreuses API externes (comme SerpAPI) limitent le nombre de requêtes que vous pouvez faire dans un certain laps de temps. Un bon code vérifie ces limites et les gère proprement, pour que votre application ne plante pas si vous atteignez un seuil.
- **Analyse des données structurées** : Les réponses API sont souvent complexes et imbriquées. Ce concept consiste à transformer ces réponses en formats propres et faciles à utiliser, adaptés aux LLM ou autres programmes.
- **Récupération en cas d’erreur** : Parfois, ça coince — réseau défaillant, API qui ne répond pas comme prévu, etc. La récupération d’erreur signifie que votre code peut gérer ces problèmes et fournir un retour utile, sans planter.
- **Validation des paramètres** : Cela consiste à vérifier que toutes les entrées de vos outils sont correctes et sûres à utiliser. Cela inclut la définition de valeurs par défaut et la vérification des types, ce qui aide à éviter bugs et confusions.

Cette section vous aidera à diagnostiquer et résoudre les problèmes courants que vous pourriez rencontrer en travaillant avec le serveur MCP de recherche web. Si vous rencontrez des erreurs ou un comportement inattendu, cette section de dépannage offre des solutions aux problèmes les plus fréquents. Consultez ces conseils avant de demander de l’aide — ils résolvent souvent rapidement les soucis.

## Dépannage

Lorsque vous travaillez avec le serveur MCP de recherche web, il peut arriver que vous rencontriez des problèmes — c’est normal lors du développement avec des API externes et de nouveaux outils. Cette section propose des solutions pratiques aux problèmes les plus courants, pour vous remettre rapidement sur les rails. En cas d’erreur, commencez ici : les conseils ci-dessous couvrent les problèmes que la plupart des utilisateurs rencontrent et peuvent souvent résoudre votre souci sans aide supplémentaire.

### Problèmes fréquents

Voici quelques-uns des problèmes les plus courants rencontrés par les utilisateurs, avec des explications claires et des étapes pour les résoudre :

1. **Clé SERPAPI_KEY manquante dans le fichier .env**
   - Si vous voyez l’erreur `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env`, créez un fichier `.env` si nécessaire. Si votre clé est correcte mais que l’erreur persiste, vérifiez que votre quota gratuit n’est pas épuisé.

### Mode debug

Par défaut, l’application ne journalise que les informations importantes. Si vous souhaitez voir plus de détails sur ce qui se passe (par exemple pour diagnostiquer des problèmes complexes), vous pouvez activer le mode DEBUG. Cela affichera beaucoup plus d’informations à chaque étape.

**Exemple : sortie normale**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**Exemple : sortie DEBUG**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

Notez que le mode DEBUG inclut des lignes supplémentaires sur les requêtes HTTP, les réponses et d’autres détails internes. Cela peut être très utile pour le dépannage.

Pour activer le mode DEBUG, définissez le niveau de journalisation sur DEBUG en haut de votre fichier `client.py` or `server.py` :

<details>
<summary>Python</summary>

```python
# At the top of your client.py or server.py
import logging
logging.basicConfig(
    level=logging.DEBUG,  # Change from INFO to DEBUG
    format="%(asctime)s - %(name)s - %(levelname)s - %(message)s"
)
```
</details>

---

## Et après ?

- [6. Contributions de la communauté](../../06-CommunityContributions/README.md)

**Avertissement** :  
Ce document a été traduit à l'aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d'assurer l'exactitude, veuillez noter que les traductions automatisées peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d'origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou d'interprétations erronées résultant de l'utilisation de cette traduction.