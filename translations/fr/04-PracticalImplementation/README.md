<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-11T17:55:32+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "fr"
}
-->
# Mise en œuvre pratique

La mise en œuvre pratique est le moment où la puissance du Model Context Protocol (MCP) devient concrète. Bien qu’il soit important de comprendre la théorie et l’architecture derrière le MCP, la vraie valeur apparaît lorsque vous appliquez ces concepts pour construire, tester et déployer des solutions qui répondent à des problèmes réels. Ce chapitre fait le lien entre les connaissances conceptuelles et le développement pratique, en vous guidant dans le processus de création d’applications basées sur MCP.

Que vous développiez des assistants intelligents, intégriez l’IA dans des flux de travail professionnels ou construisiez des outils personnalisés pour le traitement des données, MCP offre une base flexible. Son design indépendant du langage et ses SDK officiels pour les langages de programmation populaires le rendent accessible à un large éventail de développeurs. En tirant parti de ces SDK, vous pouvez rapidement prototyper, itérer et faire évoluer vos solutions sur différentes plateformes et environnements.

Dans les sections suivantes, vous trouverez des exemples pratiques, du code d’exemple et des stratégies de déploiement qui montrent comment implémenter MCP en C#, Java, TypeScript, JavaScript et Python. Vous apprendrez également à déboguer et tester vos serveurs MCP, gérer les API et déployer des solutions dans le cloud avec Azure. Ces ressources pratiques sont conçues pour accélérer votre apprentissage et vous aider à construire avec confiance des applications MCP robustes et prêtes pour la production.

## Vue d’ensemble

Cette leçon se concentre sur les aspects pratiques de la mise en œuvre de MCP dans plusieurs langages de programmation. Nous verrons comment utiliser les SDK MCP en C#, Java, TypeScript, JavaScript et Python pour créer des applications solides, déboguer et tester des serveurs MCP, ainsi que créer des ressources, prompts et outils réutilisables.

## Objectifs d’apprentissage

À la fin de cette leçon, vous serez capable de :
- Mettre en œuvre des solutions MCP en utilisant les SDK officiels dans différents langages de programmation
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

Cette section fournit des exemples pratiques d’implémentation de MCP dans plusieurs langages de programmation. Vous trouverez des exemples de code dans le répertoire `samples` organisé par langage.

### Exemples disponibles

Le dépôt inclut des exemples d’implémentations dans les langages suivants :

- C#
- Java
- TypeScript
- JavaScript
- Python

Chaque exemple illustre les concepts clés du MCP et les modèles d’implémentation propres à ce langage et écosystème.

## Fonctionnalités principales des serveurs

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
- Utilitaires de traitement des données  
- Intégrations d’API externes  
- Capacités de calcul  
- Fonctionnalités de recherche  

## Exemples d’implémentations : C#

Le dépôt officiel du SDK C# contient plusieurs exemples illustrant différents aspects du MCP :

- **Client MCP basique** : exemple simple montrant comment créer un client MCP et appeler des outils  
- **Serveur MCP basique** : implémentation minimale de serveur avec enregistrement d’outils basique  
- **Serveur MCP avancé** : serveur complet avec enregistrement d’outils, authentification et gestion des erreurs  
- **Intégration ASP.NET** : exemples montrant l’intégration avec ASP.NET Core  
- **Modèles d’implémentation d’outils** : différents modèles pour implémenter des outils avec divers niveaux de complexité  

Le SDK MCP C# est en version preview et les API peuvent évoluer. Nous mettrons à jour ce blog régulièrement au fur et à mesure de l’évolution du SDK.

### Fonctionnalités clés  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Construisez votre [premier serveur MCP](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Pour des exemples complets d’implémentation en C#, consultez le [dépôt officiel des exemples du SDK C#](https://github.com/modelcontextprotocol/csharp-sdk)

## Exemple d’implémentation : Java

Le SDK Java offre des options d’implémentation MCP robustes avec des fonctionnalités adaptées aux entreprises.

### Fonctionnalités clés

- Intégration avec le framework Spring  
- Typage fort  
- Support de la programmation réactive  
- Gestion complète des erreurs  

Pour un exemple complet d’implémentation Java, consultez [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) dans le répertoire des exemples.

## Exemple d’implémentation : JavaScript

Le SDK JavaScript propose une approche légère et flexible pour l’implémentation MCP.

### Fonctionnalités clés

- Support Node.js et navigateur  
- API basée sur les Promises  
- Intégration facile avec Express et autres frameworks  
- Support WebSocket pour le streaming  

Pour un exemple complet d’implémentation JavaScript, consultez [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) dans le répertoire des exemples.

## Exemple d’implémentation : Python

Le SDK Python offre une approche pythonique pour l’implémentation MCP avec d’excellentes intégrations aux frameworks ML.

### Fonctionnalités clés

- Support async/await avec asyncio  
- Intégration Flask et FastAPI  
- Enregistrement simple des outils  
- Intégration native avec les bibliothèques ML populaires  

Pour un exemple complet d’implémentation Python, consultez [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) dans le répertoire des exemples.

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

Dans l’image précédente, les étapes suivantes ont lieu :

- L’authentification/autorisation se fait via Microsoft Entra.  
- Azure API Management agit comme une passerelle et utilise des politiques pour diriger et gérer le trafic.  
- Azure Monitor enregistre toutes les requêtes pour une analyse ultérieure.  

#### Flux d’autorisation

Examinons le flux d’autorisation plus en détail :

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Spécification d’autorisation MCP

Pour en savoir plus, consultez la [spécification d’autorisation MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Déployer un serveur MCP distant sur Azure

Voyons si nous pouvons déployer l’exemple mentionné précédemment :

1. Cloner le dépôt

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. Enregistrer `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` puis attendre un moment pour vérifier si l’enregistrement est terminé.

3. Exécuter cette commande [azd](https://aka.ms/azd) pour provisionner le service de gestion d’API, l’application fonction (avec le code) et toutes les autres ressources Azure nécessaires

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

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.fr.png)

2. CTRL clic pour charger l’application web MCP Inspector à partir de l’URL affichée par l’application (ex. http://127.0.0.1:6274/#resources)  
3. Définissez le type de transport sur `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` et **Connecter** :

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Lister les outils**. Cliquez sur un outil et **Exécuter l’outil**.  

Si toutes les étapes ont fonctionné, vous devriez maintenant être connecté au serveur MCP et avoir pu appeler un outil.

## Serveurs MCP pour Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) : cet ensemble de dépôts est un modèle de démarrage rapide pour construire et déployer des serveurs MCP distants personnalisés utilisant Azure Functions avec Python, C# .NET ou Node/TypeScript.

Les exemples fournissent une solution complète qui permet aux développeurs de :

- Construire et exécuter localement : développer et déboguer un serveur MCP sur une machine locale  
- Déployer sur Azure : déployer facilement dans le cloud avec une simple commande azd up  
- Se connecter depuis des clients : se connecter au serveur MCP depuis divers clients, y compris le mode agent Copilot de VS Code et l’outil MCP Inspector  

### Fonctionnalités clés :

- Sécurité intégrée : le serveur MCP est sécurisé avec des clés et HTTPS  
- Options d’authentification : supporte OAuth avec authentification intégrée et/ou API Management  
- Isolation réseau : permet l’isolation réseau avec les réseaux virtuels Azure (VNET)  
- Architecture serverless : utilise Azure Functions pour une exécution scalable et événementielle  
- Développement local : support complet pour le développement et le débogage local  
- Déploiement simple : processus de déploiement simplifié vers Azure  

Le dépôt inclut tous les fichiers de configuration nécessaires, le code source et les définitions d’infrastructure pour démarrer rapidement avec une implémentation MCP prête pour la production.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Exemple d’implémentation MCP utilisant Azure Functions avec Python  

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Exemple d’implémentation MCP utilisant Azure Functions avec C# .NET  

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Exemple d’implémentation MCP utilisant Azure Functions avec Node/TypeScript.

## Points clés à retenir

- Les SDK MCP fournissent des outils spécifiques aux langages pour implémenter des solutions MCP robustes  
- Le processus de débogage et de test est essentiel pour des applications MCP fiables  
- Les modèles de prompts réutilisables permettent des interactions IA cohérentes  
- Des workflows bien conçus peuvent orchestrer des tâches complexes avec plusieurs outils  
- La mise en œuvre de solutions MCP nécessite de prendre en compte la sécurité, la performance et la gestion des erreurs  

## Exercice

Concevez un workflow MCP pratique qui résout un problème réel dans votre domaine :

1. Identifiez 3 à 4 outils qui seraient utiles pour résoudre ce problème  
2. Créez un diagramme de workflow montrant comment ces outils interagissent  
3. Implémentez une version basique de l’un des outils dans votre langage préféré  
4. Créez un modèle de prompt qui aiderait le modèle à utiliser efficacement votre outil  

## Ressources supplémentaires


---

Suivant : [Sujets avancés](../05-AdvancedTopics/README.md)

**Avertissement** :  
Ce document a été traduit à l'aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d'assurer l'exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue native doit être considéré comme la source faisant autorité. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l'utilisation de cette traduction.