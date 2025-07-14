<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bb1ab5c924f58cf75ef1732d474f008a",
  "translation_date": "2025-07-14T17:02:50+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "fr"
}
-->
# Mise en œuvre pratique

La mise en œuvre pratique est le moment où la puissance du Model Context Protocol (MCP) devient concrète. Comprendre la théorie et l’architecture derrière le MCP est important, mais la vraie valeur apparaît lorsque vous appliquez ces concepts pour construire, tester et déployer des solutions qui répondent à des problèmes réels. Ce chapitre fait le lien entre les connaissances conceptuelles et le développement pratique, en vous guidant à travers le processus de création d’applications basées sur MCP.

Que vous développiez des assistants intelligents, intégriez l’IA dans des flux de travail métier ou construisiez des outils personnalisés pour le traitement des données, MCP offre une base flexible. Son design indépendant du langage et ses SDK officiels pour les langages de programmation populaires le rendent accessible à un large éventail de développeurs. En tirant parti de ces SDK, vous pouvez rapidement prototyper, itérer et faire évoluer vos solutions sur différentes plateformes et environnements.

Dans les sections suivantes, vous trouverez des exemples pratiques, des extraits de code et des stratégies de déploiement qui montrent comment implémenter MCP en C#, Java, TypeScript, JavaScript et Python. Vous apprendrez également à déboguer et tester vos serveurs MCP, gérer les API et déployer des solutions dans le cloud avec Azure. Ces ressources pratiques sont conçues pour accélérer votre apprentissage et vous aider à construire en toute confiance des applications MCP robustes et prêtes pour la production.

## Vue d’ensemble

Cette leçon se concentre sur les aspects pratiques de l’implémentation MCP dans plusieurs langages de programmation. Nous explorerons comment utiliser les SDK MCP en C#, Java, TypeScript, JavaScript et Python pour construire des applications robustes, déboguer et tester des serveurs MCP, et créer des ressources, prompts et outils réutilisables.

## Objectifs d’apprentissage

À la fin de cette leçon, vous serez capable de :
- Implémenter des solutions MCP en utilisant les SDK officiels dans différents langages de programmation
- Déboguer et tester systématiquement des serveurs MCP
- Créer et utiliser des fonctionnalités serveur (Ressources, Prompts et Outils)
- Concevoir des workflows MCP efficaces pour des tâches complexes
- Optimiser les implémentations MCP pour la performance et la fiabilité

## Ressources des SDK officiels

Le Model Context Protocol propose des SDK officiels pour plusieurs langages :

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Travailler avec les SDK MCP

Cette section fournit des exemples pratiques d’implémentation MCP dans plusieurs langages. Vous trouverez des exemples de code dans le répertoire `samples` organisé par langage.

### Exemples disponibles

Le dépôt inclut des [implémentations exemples](../../../04-PracticalImplementation/samples) dans les langages suivants :

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Chaque exemple illustre les concepts clés de MCP et les modèles d’implémentation propres à ce langage et écosystème.

## Fonctionnalités principales du serveur

Les serveurs MCP peuvent implémenter n’importe quelle combinaison des fonctionnalités suivantes :

### Ressources  
Les ressources fournissent le contexte et les données que l’utilisateur ou le modèle IA peut utiliser :  
- Dépôts de documents  
- Bases de connaissances  
- Sources de données structurées  
- Systèmes de fichiers  

### Prompts  
Les prompts sont des messages et workflows modélisés pour les utilisateurs :  
- Modèles de conversation prédéfinis  
- Schémas d’interaction guidée  
- Structures de dialogue spécialisées  

### Outils  
Les outils sont des fonctions que le modèle IA peut exécuter :  
- Utilitaires de traitement de données  
- Intégrations d’API externes  
- Capacités de calcul  
- Fonctionnalités de recherche  

## Exemples d’implémentations : C#

Le dépôt officiel du SDK C# contient plusieurs exemples illustrant différents aspects de MCP :

- **Client MCP basique** : Exemple simple montrant comment créer un client MCP et appeler des outils  
- **Serveur MCP basique** : Implémentation minimale de serveur avec enregistrement d’outils basique  
- **Serveur MCP avancé** : Serveur complet avec enregistrement d’outils, authentification et gestion des erreurs  
- **Intégration ASP.NET** : Exemples montrant l’intégration avec ASP.NET Core  
- **Modèles d’implémentation d’outils** : Divers modèles pour implémenter des outils avec différents niveaux de complexité  

Le SDK MCP C# est en version preview et les API peuvent évoluer. Ce blog sera mis à jour régulièrement au fur et à mesure de l’évolution du SDK.

### Fonctionnalités clés  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Construisez votre [premier serveur MCP](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Pour des exemples complets d’implémentation en C#, consultez le [dépôt officiel des exemples C#](https://github.com/modelcontextprotocol/csharp-sdk)

## Exemple d’implémentation : Java

Le SDK Java offre des options robustes d’implémentation MCP avec des fonctionnalités adaptées aux entreprises.

### Fonctionnalités clés

- Intégration avec Spring Framework  
- Forte sécurité de type  
- Support de la programmation réactive  
- Gestion complète des erreurs  

Pour un exemple complet d’implémentation Java, consultez le [Java sample](samples/java/containerapp/README.md) dans le répertoire des exemples.

## Exemple d’implémentation : JavaScript

Le SDK JavaScript propose une approche légère et flexible pour l’implémentation MCP.

### Fonctionnalités clés

- Support Node.js et navigateur  
- API basée sur les Promises  
- Intégration facile avec Express et autres frameworks  
- Support WebSocket pour le streaming  

Pour un exemple complet d’implémentation JavaScript, consultez le [JavaScript sample](samples/javascript/README.md) dans le répertoire des exemples.

## Exemple d’implémentation : Python

Le SDK Python offre une approche pythonique de l’implémentation MCP avec d’excellentes intégrations aux frameworks ML.

### Fonctionnalités clés

- Support async/await avec asyncio  
- Intégration FastAPI  
- Enregistrement simple des outils  
- Intégration native avec les bibliothèques ML populaires  

Pour un exemple complet d’implémentation Python, consultez le [Python sample](samples/python/README.md) dans le répertoire des exemples.

## Gestion des API

Azure API Management est une excellente solution pour sécuriser les serveurs MCP. L’idée est de placer une instance Azure API Management devant votre serveur MCP et de lui confier des fonctionnalités que vous souhaitez, telles que :

- limitation du débit  
- gestion des tokens  
- surveillance  
- équilibrage de charge  
- sécurité  

### Exemple Azure

Voici un exemple Azure qui fait exactement cela, c’est-à-dire [créer un serveur MCP et le sécuriser avec Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Voyez comment se déroule le flux d’autorisation dans l’image ci-dessous :

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Sur l’image précédente, les étapes suivantes ont lieu :

- L’authentification/autorisation se fait via Microsoft Entra.  
- Azure API Management agit comme une passerelle et utilise des politiques pour diriger et gérer le trafic.  
- Azure Monitor enregistre toutes les requêtes pour une analyse ultérieure.  

#### Flux d’autorisation

Examinons plus en détail le flux d’autorisation :

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Spécification d’autorisation MCP

En savoir plus sur la [spécification d’autorisation MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Déployer un serveur MCP distant sur Azure

Voyons si nous pouvons déployer l’exemple mentionné précédemment :

1. Clonez le dépôt

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Enregistrez le fournisseur de ressources `Microsoft.App`.  
    * Si vous utilisez Azure CLI, exécutez `az provider register --namespace Microsoft.App --wait`.  
    * Si vous utilisez Azure PowerShell, exécutez `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Puis vérifiez l’état avec `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` après un moment.  

2. Exécutez cette commande [azd](https://aka.ms/azd) pour provisionner le service API Management, la function app (avec le code) et toutes les autres ressources Azure nécessaires

    ```shell
    azd up
    ```

    Cette commande doit déployer toutes les ressources cloud sur Azure

### Tester votre serveur avec MCP Inspector

1. Dans une **nouvelle fenêtre de terminal**, installez et lancez MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Vous devriez voir une interface similaire à :

    ![Connect to Node inspector](/03-GettingStarted/01-first-server/assets/connect.png) 

1. CTRL-clic pour charger l’application web MCP Inspector depuis l’URL affichée par l’application (ex. http://127.0.0.1:6274/#resources)  
1. Réglez le type de transport sur `SSE`  
1. Mettez l’URL sur votre point de terminaison SSE API Management en cours d’exécution affiché après `azd up` et **Connectez-vous** :

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Lister les outils**. Cliquez sur un outil et **Exécutez l’outil**.  

Si toutes les étapes ont fonctionné, vous êtes maintenant connecté au serveur MCP et avez pu appeler un outil.

## Serveurs MCP pour Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) : Cet ensemble de dépôts est un modèle de démarrage rapide pour construire et déployer des serveurs MCP distants personnalisés utilisant Azure Functions avec Python, C# .NET ou Node/TypeScript.

Les exemples fournissent une solution complète permettant aux développeurs de :

- Construire et exécuter localement : développer et déboguer un serveur MCP sur une machine locale  
- Déployer sur Azure : déployer facilement dans le cloud avec une simple commande azd up  
- Se connecter depuis des clients : se connecter au serveur MCP depuis divers clients, y compris le mode agent Copilot de VS Code et l’outil MCP Inspector  

### Fonctionnalités clés :

- Sécurité intégrée : le serveur MCP est sécurisé avec des clés et HTTPS  
- Options d’authentification : supporte OAuth via l’authentification intégrée et/ou API Management  
- Isolation réseau : permet l’isolation réseau via Azure Virtual Networks (VNET)  
- Architecture serverless : utilise Azure Functions pour une exécution scalable et événementielle  
- Développement local : support complet pour le développement et le débogage local  
- Déploiement simple : processus de déploiement simplifié vers Azure  

Le dépôt inclut tous les fichiers de configuration nécessaires, le code source et les définitions d’infrastructure pour démarrer rapidement avec une implémentation MCP prête pour la production.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Exemple d’implémentation MCP avec Azure Functions en Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Exemple d’implémentation MCP avec Azure Functions en C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Exemple d’implémentation MCP avec Azure Functions en Node/TypeScript.

## Points clés à retenir

- Les SDK MCP fournissent des outils spécifiques aux langages pour implémenter des solutions MCP robustes  
- Le processus de débogage et de test est crucial pour des applications MCP fiables  
- Les modèles de prompts réutilisables permettent des interactions IA cohérentes  
- Des workflows bien conçus peuvent orchestrer des tâches complexes en utilisant plusieurs outils  
- Implémenter des solutions MCP nécessite de prendre en compte la sécurité, la performance et la gestion des erreurs  

## Exercice

Concevez un workflow MCP pratique qui répond à un problème réel dans votre domaine :

1. Identifiez 3 à 4 outils qui seraient utiles pour résoudre ce problème  
2. Créez un diagramme de workflow montrant comment ces outils interagissent  
3. Implémentez une version basique de l’un des outils dans votre langage préféré  
4. Créez un modèle de prompt qui aiderait le modèle à utiliser efficacement votre outil  

## Ressources supplémentaires


---

Suivant : [Sujets avancés](../05-AdvancedTopics/README.md)

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.