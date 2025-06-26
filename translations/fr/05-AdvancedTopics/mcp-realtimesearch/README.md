<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eb12652eb7bd17f2193b835a344425c6",
  "translation_date": "2025-06-26T13:33:57+00:00",
  "source_file": "05-AdvancedTopics/mcp-realtimesearch/README.md",
  "language_code": "fr"
}
-->
## Avertissement concernant les exemples de code

> **Note importante** : Les exemples de code ci-dessous démontrent l’intégration du Model Context Protocol (MCP) avec la fonctionnalité de recherche web. Bien qu’ils suivent les modèles et structures des SDK MCP officiels, ils ont été simplifiés à des fins pédagogiques.
> 
> Ces exemples illustrent :
> 
> 1. **Implémentation Python** : Une implémentation serveur FastMCP qui fournit un outil de recherche web et se connecte à une API de recherche externe. Cet exemple montre la gestion correcte du cycle de vie, la gestion du contexte et la mise en œuvre de l’outil en suivant les modèles du [SDK Python MCP officiel](https://github.com/modelcontextprotocol/python-sdk). Le serveur utilise le transport HTTP Streamable recommandé, qui a remplacé l’ancien transport SSE pour les déploiements en production.
> 
> 2. **Implémentation JavaScript** : Une implémentation TypeScript/JavaScript utilisant le modèle FastMCP du [SDK TypeScript MCP officiel](https://github.com/modelcontextprotocol/typescript-sdk) pour créer un serveur de recherche avec des définitions d’outils et des connexions clients appropriées. Elle suit les derniers modèles recommandés pour la gestion des sessions et la préservation du contexte.
> 
> Ces exemples nécessiteraient une gestion des erreurs, une authentification et un code d’intégration API spécifiques supplémentaires pour un usage en production. Les points de terminaison de l’API de recherche montrés (`https://api.search-service.example/search`) sont des espaces réservés et devraient être remplacés par de véritables points de terminaison de service de recherche.
> 
> Pour les détails complets d’implémentation et les approches les plus récentes, veuillez consulter la [spécification MCP officielle](https://spec.modelcontextprotocol.io/) et la documentation des SDK.

## Concepts Clés

### Le cadre du Model Context Protocol (MCP)

À sa base, le Model Context Protocol fournit une méthode standardisée permettant aux modèles IA, applications et services d’échanger du contexte. Dans la recherche web en temps réel, ce cadre est essentiel pour créer des expériences de recherche cohérentes et multi-interactions. Les composants clés comprennent :

1. **Architecture client-serveur** : MCP établit une séparation claire entre les clients de recherche (demandeurs) et les serveurs de recherche (fournisseurs), permettant des modèles de déploiement flexibles.

2. **Communication JSON-RPC** : Le protocole utilise JSON-RPC pour l’échange de messages, ce qui le rend compatible avec les technologies web et facile à implémenter sur différentes plateformes.

3. **Gestion du contexte** : MCP définit des méthodes structurées pour maintenir, mettre à jour et exploiter le contexte de recherche à travers plusieurs interactions.

4. **Définitions d’outils** : Les capacités de recherche sont exposées sous forme d’outils standardisés avec des paramètres et valeurs de retour bien définis.

5. **Support du streaming** : Le protocole supporte la diffusion progressive des résultats, essentielle pour la recherche en temps réel où les résultats peuvent arriver de façon incrémentale.

### Modèles d’intégration pour la recherche web

Lors de l’intégration du MCP avec la recherche web, plusieurs modèles émergent :

#### 1. Intégration directe avec un fournisseur de recherche

```mermaid
graph LR
    Client[MCP Client] --> |MCP Request| Server[MCP Server]
    Server --> |API Call| SearchAPI[Search API]
    SearchAPI --> |Results| Server
    Server --> |MCP Response| Client
```

Dans ce modèle, le serveur MCP interagit directement avec une ou plusieurs API de recherche, traduisant les requêtes MCP en appels spécifiques à l’API et formatant les résultats en réponses MCP.

#### 2. Recherche fédérée avec préservation du contexte

```mermaid
graph LR
    Client[MCP Client] --> |MCP Request| Federation[MCP Federation Layer]
    Federation --> |MCP Request 1| Search1[Search Provider 1]
    Federation --> |MCP Request 2| Search2[Search Provider 2]
    Federation --> |MCP Request 3| Search3[Search Provider 3]
    Search1 --> |MCP Response 1| Federation
    Search2 --> |MCP Response 2| Federation
    Search3 --> |MCP Response 3| Federation
    Federation --> |Aggregated MCP Response| Client
```

Ce modèle répartit les requêtes de recherche entre plusieurs fournisseurs compatibles MCP, chacun pouvant se spécialiser dans différents types de contenu ou capacités de recherche, tout en maintenant un contexte unifié.

#### 3. Chaîne de recherche enrichie par le contexte

```mermaid
graph LR
    Client[MCP Client] --> |Query + Context| Server[MCP Server]
    Server --> |1. Query Analysis| NLP[NLP Service]
    NLP --> |Enhanced Query| Server
    Server --> |2. Search Execution| Search[Search Engine]
    Search --> |Raw Results| Server
    Server --> |3. Result Processing| Enhancement[Result Enhancement]
    Enhancement --> |Enhanced Results| Server
    Server --> |Final Results + Updated Context| Client
```

Ici, le processus de recherche est divisé en plusieurs étapes, avec un enrichissement du contexte à chaque étape, produisant des résultats de plus en plus pertinents.

### Composants du contexte de recherche

Dans la recherche web basée sur MCP, le contexte inclut généralement :

- **Historique des requêtes** : Les recherches précédentes dans la session
- **Préférences utilisateur** : Langue, région, paramètres de recherche sécurisée
- **Historique d’interaction** : Résultats cliqués, temps passé sur les résultats
- **Paramètres de recherche** : Filtres, ordres de tri et autres modificateurs de recherche
- **Connaissances de domaine** : Contexte spécifique au sujet pertinent pour la recherche
- **Contexte temporel** : Facteurs de pertinence basés sur le temps
- **Préférences de sources** : Sources d’information de confiance ou préférées

## Cas d’usage et applications

### Recherche et collecte d’informations

MCP améliore les flux de travail de recherche en :

- Préservant le contexte de recherche entre les sessions
- Permettant des requêtes plus sophistiquées et contextuellement pertinentes
- Supportant la fédération de recherche multi-sources
- Facilitant l’extraction de connaissances à partir des résultats de recherche

### Surveillance en temps réel des actualités et tendances

La recherche propulsée par MCP offre des avantages pour la surveillance de l’actualité :

- Découverte quasi instantanée des actualités émergentes
- Filtrage contextuel des informations pertinentes
- Suivi des sujets et entités à travers plusieurs sources
- Alertes personnalisées basées sur le contexte utilisateur

### Navigation et recherche augmentées par l’IA

MCP ouvre de nouvelles possibilités pour la navigation augmentée par l’IA :

- Suggestions de recherche contextuelles basées sur l’activité actuelle du navigateur
- Intégration fluide de la recherche web avec des assistants pilotés par LLM
- Affinage multi-interactions de la recherche avec conservation du contexte
- Vérification des faits et validation d’informations améliorées

## Tendances et innovations futures

### Évolution du MCP dans la recherche web

À l’avenir, on prévoit que le MCP évoluera pour aborder :

- **Recherche multimodale** : Intégration de la recherche texte, image, audio et vidéo avec contexte préservé
- **Recherche décentralisée** : Support des écosystèmes de recherche distribuée et fédérée
- **Confidentialité de la recherche** : Mécanismes de recherche respectueux de la vie privée et sensibles au contexte
- **Compréhension des requêtes** : Analyse sémantique approfondie des requêtes en langage naturel

### Avancées technologiques potentielles

Les technologies émergentes qui façonneront l’avenir de la recherche MCP :

1. **Architectures de recherche neuronale** : Systèmes de recherche basés sur l’encodage optimisés pour MCP
2. **Contexte de recherche personnalisé** : Apprentissage des habitudes de recherche individuelles au fil du temps
3. **Intégration de graphes de connaissances** : Recherche contextuelle enrichie par des graphes de connaissances spécifiques aux domaines
4. **Contexte intermodal** : Maintien du contexte à travers différentes modalités de recherche

## Exercices pratiques

### Exercice 1 : Mise en place d’un pipeline de recherche MCP basique

Dans cet exercice, vous apprendrez à :
- Configurer un environnement de recherche MCP basique
- Implémenter des gestionnaires de contexte pour la recherche web
- Tester et valider la préservation du contexte à travers les itérations de recherche

### Exercice 2 : Création d’un assistant de recherche avec MCP

Créez une application complète qui :
- Traite des questions de recherche en langage naturel
- Effectue des recherches web contextuelles
- Synthétise l’information provenant de multiples sources
- Présente les résultats de recherche organisés

### Exercice 3 : Implémentation de la fédération de recherche multi-sources avec MCP

Exercice avancé couvrant :
- L’envoi contextuel de requêtes à plusieurs moteurs de recherche
- Le classement et l’agrégation des résultats
- La déduplication contextuelle des résultats de recherche
- La gestion des métadonnées spécifiques aux sources

## Ressources supplémentaires

- [Spécification du Model Context Protocol](https://spec.modelcontextprotocol.io/) - Spécification officielle MCP et documentation détaillée du protocole
- [Documentation du Model Context Protocol](https://modelcontextprotocol.io/) - Tutoriels détaillés et guides d’implémentation
- [SDK Python MCP](https://github.com/modelcontextprotocol/python-sdk) - Implémentation Python officielle du protocole MCP
- [SDK TypeScript MCP](https://github.com/modelcontextprotocol/typescript-sdk) - Implémentation TypeScript officielle du protocole MCP
- [Serveurs de référence MCP](https://github.com/modelcontextprotocol/servers) - Implémentations de référence des serveurs MCP
- [Documentation Bing Web Search API](https://learn.microsoft.com/en-us/bing/search-apis/bing-web-search/overview) - API de recherche web de Microsoft
- [Google Custom Search JSON API](https://developers.google.com/custom-search/v1/overview) - Moteur de recherche programmable de Google
- [Documentation SerpAPI](https://serpapi.com/search-api) - API des pages de résultats de moteurs de recherche
- [Documentation Meilisearch](https://www.meilisearch.com/docs) - Moteur de recherche open-source
- [Documentation Elasticsearch](https://www.elastic.co/guide/index.html) - Moteur de recherche et d’analyse distribué
- [Documentation LangChain](https://python.langchain.com/docs/get_started/introduction) - Création d’applications avec des LLM

## Résultats d’apprentissage

En complétant ce module, vous serez capable de :

- Comprendre les fondamentaux de la recherche web en temps réel et ses défis
- Expliquer comment le Model Context Protocol (MCP) améliore les capacités de recherche web en temps réel
- Implémenter des solutions de recherche basées sur MCP en utilisant des frameworks et API populaires
- Concevoir et déployer des architectures de recherche évolutives et performantes avec MCP
- Appliquer les concepts MCP à divers cas d’usage incluant la recherche sémantique, l’assistance à la recherche et la navigation augmentée par IA
- Évaluer les tendances émergentes et les innovations futures dans les technologies de recherche basées sur MCP

### Considérations de confiance et de sécurité

Lors de la mise en œuvre de solutions de recherche web basées sur MCP, gardez à l’esprit ces principes importants issus de la spécification MCP :

1. **Consentement et contrôle utilisateur** : Les utilisateurs doivent consentir explicitement et comprendre toutes les opérations et accès aux données. Ceci est particulièrement crucial pour les implémentations de recherche web pouvant accéder à des sources de données externes.

2. **Confidentialité des données** : Assurez-vous d’un traitement approprié des requêtes et résultats de recherche, notamment lorsqu’ils peuvent contenir des informations sensibles. Mettez en place des contrôles d’accès adaptés pour protéger les données utilisateur.

3. **Sécurité des outils** : Implémentez une autorisation et une validation rigoureuses pour les outils de recherche, car ils représentent des risques potentiels de sécurité via l’exécution de code arbitraire. Les descriptions du comportement des outils doivent être considérées comme non fiables sauf si elles proviennent d’un serveur de confiance.

4. **Documentation claire** : Fournissez une documentation claire sur les capacités, limites et considérations de sécurité de votre implémentation de recherche MCP, en suivant les directives d’implémentation de la spécification MCP.

5. **Flux de consentement robustes** : Construisez des flux de consentement et d’autorisation robustes qui expliquent clairement ce que fait chaque outil avant d’autoriser son utilisation, notamment pour les outils interagissant avec des ressources web externes.

Pour plus de détails sur la sécurité et les considérations de confiance MCP, consultez la [documentation officielle](https://modelcontextprotocol.io/specification/2025-03-26#security-and-trust-%26-safety).

## Et ensuite

- [5.11 Authentification Entra ID pour les serveurs Model Context Protocol](../mcp-security-entra/README.md)

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, il est recommandé de recourir à une traduction professionnelle humaine. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.