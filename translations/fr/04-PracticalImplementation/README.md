<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-16T15:32:35+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "fr"
}
-->
# Mise en œuvre pratique

La mise en œuvre pratique est le moment où la puissance du Model Context Protocol (MCP) devient concrète. Bien qu'il soit important de comprendre la théorie et l'architecture derrière le MCP, la vraie valeur apparaît lorsque vous appliquez ces concepts pour construire, tester et déployer des solutions qui répondent à des problèmes réels. Ce chapitre fait le lien entre les connaissances conceptuelles et le développement pratique, en vous guidant tout au long du processus pour donner vie à des applications basées sur MCP.

Que vous développiez des assistants intelligents, intégriez l'IA dans des flux de travail métier ou créiez des outils personnalisés pour le traitement de données, MCP offre une base flexible. Sa conception indépendante du langage et ses SDK officiels pour les langages de programmation populaires le rendent accessible à un large éventail de développeurs. En tirant parti de ces SDK, vous pouvez rapidement prototyper, itérer et faire évoluer vos solutions sur différentes plateformes et environnements.

Dans les sections suivantes, vous trouverez des exemples pratiques, des extraits de code et des stratégies de déploiement qui montrent comment implémenter MCP en C#, Java, TypeScript, JavaScript et Python. Vous apprendrez également à déboguer et tester vos serveurs MCP, gérer les API et déployer des solutions dans le cloud avec Azure. Ces ressources pratiques sont conçues pour accélérer votre apprentissage et vous aider à construire en toute confiance des applications MCP robustes et prêtes pour la production.

## Vue d'ensemble

Cette leçon se concentre sur les aspects pratiques de l’implémentation MCP dans plusieurs langages de programmation. Nous explorerons comment utiliser les SDK MCP en C#, Java, TypeScript, JavaScript et Python pour construire des applications solides, déboguer et tester les serveurs MCP, et créer des ressources, prompts et outils réutilisables.

## Objectifs d’apprentissage

À la fin de cette leçon, vous serez capable de :
- Implémenter des solutions MCP en utilisant les SDK officiels dans différents langages de programmation
- Déboguer et tester systématiquement les serveurs MCP
- Créer et utiliser des fonctionnalités serveur (Resources, Prompts et Tools)
- Concevoir des workflows MCP efficaces pour des tâches complexes
- Optimiser les implémentations MCP en termes de performance et de fiabilité

## Ressources des SDK officiels

Le Model Context Protocol propose des SDK officiels pour plusieurs langages :

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Travailler avec les SDK MCP

Cette section fournit des exemples pratiques d’implémentation MCP dans plusieurs langages de programmation. Vous pouvez trouver des exemples de code dans le répertoire `samples` organisé par langage.

### Échantillons disponibles

Le dépôt inclut des exemples d’implémentation dans les langages suivants :

- C#
- Java
- TypeScript
- JavaScript
- Python

Chaque exemple illustre des concepts clés et des modèles d’implémentation MCP spécifiques à ce langage et écosystème.

## Fonctionnalités principales du serveur

Les serveurs MCP peuvent implémenter n’importe quelle combinaison des fonctionnalités suivantes :

### Resources  
Les Resources fournissent le contexte et les données que l’utilisateur ou le modèle IA peut utiliser :  
- Dépôts de documents  
- Bases de connaissances  
- Sources de données structurées  
- Systèmes de fichiers  

### Prompts  
Les Prompts sont des messages et workflows modélisés pour les utilisateurs :  
- Modèles de conversation prédéfinis  
- Schémas d’interaction guidée  
- Structures de dialogue spécialisées  

### Tools  
Les Tools sont des fonctions que le modèle IA peut exécuter :  
- Utilitaires de traitement de données  
- Intégrations d’API externes  
- Capacités de calcul  
- Fonctionnalités de recherche  

## Exemples d’implémentation : C#

Le dépôt officiel du SDK C# contient plusieurs exemples illustrant différents aspects du MCP :

- **Basic MCP Client** : Exemple simple montrant comment créer un client MCP et appeler des outils  
- **Basic MCP Server** : Implémentation minimale d’un serveur avec enregistrement basique d’outils  
- **Advanced MCP Server** : Serveur complet avec enregistrement d’outils, authentification et gestion des erreurs  
- **Intégration ASP.NET** : Exemples démontrant l’intégration avec ASP.NET Core  
- **Patterns d’implémentation des Tools** : Divers patterns pour implémenter des outils avec différents niveaux de complexité  

Le SDK MCP C# est en version preview et les API peuvent évoluer. Ce blog sera mis à jour régulièrement au fur et à mesure de l’évolution du SDK.

### Fonctionnalités clés  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)  

- Construire votre [premier serveur MCP](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).  

Pour des exemples complets d’implémentation en C#, consultez le [dépôt officiel des exemples C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Exemple d’implémentation : Java

Le SDK Java propose des options robustes d’implémentation MCP avec des fonctionnalités adaptées aux entreprises.

### Fonctionnalités clés

- Intégration avec Spring Framework  
- Typage fort  
- Support de la programmation réactive  
- Gestion complète des erreurs  

Pour un exemple complet d’implémentation Java, consultez [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) dans le répertoire samples.

## Exemple d’implémentation : JavaScript

Le SDK JavaScript offre une approche légère et flexible pour l’implémentation MCP.

### Fonctionnalités clés

- Support Node.js et navigateur  
- API basée sur les Promises  
- Intégration facile avec Express et autres frameworks  
- Support WebSocket pour le streaming  

Pour un exemple complet d’implémentation JavaScript, consultez [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) dans le répertoire samples.

## Exemple d’implémentation : Python

Le SDK Python propose une approche pythonique pour l’implémentation MCP avec d’excellentes intégrations aux frameworks ML.

### Fonctionnalités clés

- Support async/await avec asyncio  
- Intégration avec Flask et FastAPI  
- Enregistrement simple des outils  
- Intégration native avec les bibliothèques ML populaires  

Pour un exemple complet d’implémentation Python, consultez [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) dans le répertoire samples.

## Gestion des API

Azure API Management est une excellente solution pour sécuriser les serveurs MCP. L’idée est de placer une instance Azure API Management devant votre serveur MCP et de lui confier des fonctionnalités que vous souhaitez, comme :

- limitation du débit  
- gestion des jetons  
- surveillance  
- équilibrage de charge  
- sécurité  

### Exemple Azure

Voici un exemple Azure qui fait exactement cela, c’est-à-dire [créer un serveur MCP et le sécuriser avec Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Voyez comment se déroule le flux d’autorisation dans l’image ci-dessous :

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)  

Sur l’image précédente, les étapes suivantes ont lieu :

- L’authentification/l’autorisation se fait via Microsoft Entra.  
- Azure API Management agit comme une passerelle et utilise des politiques pour diriger et gérer le trafic.  
- Azure Monitor enregistre toutes les requêtes pour une analyse ultérieure.  

#### Flux d’autorisation

Voyons le flux d’autorisation plus en détail :

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Spécification d’autorisation MCP

En savoir plus sur la [spécification d’autorisation MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

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

3. Exécuter cette commande [azd](https://aka.ms/azd) pour provisionner le service de gestion d’API, la fonction app (avec le code) et toutes les autres ressources Azure nécessaires

    ```shell
    azd up
    ```

    Cette commande devrait déployer toutes les ressources cloud sur Azure

### Tester votre serveur avec MCP Inspector

1. Dans une **nouvelle fenêtre de terminal**, installez et lancez MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Vous devriez voir une interface similaire à :

    ![Connect to Node inspector](../../../translated_images/connect.9f4ccffc595d24b85ce22579ddf26016b5f21d941d544568c1b9752a51d0a4b1.fr.png)

2. CTRL-clic pour charger l’application web MCP Inspector depuis l’URL affichée par l’application (ex. http://127.0.0.1:6274/#resources)  
3. Définissez le type de transport sur `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` et **Connecter** :

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Lister les Tools**. Cliquez sur un outil puis **Exécuter l’outil**.  

Si toutes les étapes ont fonctionné, vous êtes maintenant connecté au serveur MCP et avez pu appeler un outil.

## Serveurs MCP pour Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) : Cet ensemble de dépôts est un modèle de démarrage rapide pour construire et déployer des serveurs MCP distants personnalisés en utilisant Azure Functions avec Python, C# .NET ou Node/TypeScript.

Les exemples fournissent une solution complète permettant aux développeurs de :

- Construire et exécuter localement : développer et déboguer un serveur MCP sur une machine locale  
- Déployer sur Azure : déployer facilement dans le cloud avec une simple commande azd up  
- Se connecter depuis les clients : se connecter au serveur MCP depuis divers clients, y compris le mode agent Copilot de VS Code et l’outil MCP Inspector  

### Fonctionnalités clés :

- Sécurité intégrée : le serveur MCP est sécurisé avec des clés et HTTPS  
- Options d’authentification : supporte OAuth avec authentification intégrée et/ou API Management  
- Isolation réseau : permet l’isolation réseau via Azure Virtual Networks (VNET)  
- Architecture serverless : utilise Azure Functions pour une exécution évolutive et événementielle  
- Développement local : support complet pour le développement et le débogage local  
- Déploiement simplifié : processus de déploiement fluide vers Azure  

Le dépôt inclut tous les fichiers de configuration nécessaires, le code source et les définitions d’infrastructure pour démarrer rapidement avec une implémentation de serveur MCP prête pour la production.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Exemple d’implémentation MCP avec Azure Functions en Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Exemple d’implémentation MCP avec Azure Functions en C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Exemple d’implémentation MCP avec Azure Functions en Node/TypeScript.

## Points clés à retenir

- Les SDK MCP fournissent des outils spécifiques aux langages pour implémenter des solutions MCP robustes  
- Le processus de débogage et de test est crucial pour des applications MCP fiables  
- Les templates de prompts réutilisables permettent des interactions IA cohérentes  
- Des workflows bien conçus peuvent orchestrer des tâches complexes en utilisant plusieurs outils  
- Implémenter des solutions MCP nécessite de prendre en compte la sécurité, la performance et la gestion des erreurs  

## Exercice

Concevez un workflow MCP pratique qui répond à un problème réel dans votre domaine :

1. Identifiez 3 à 4 outils qui seraient utiles pour résoudre ce problème  
2. Créez un diagramme de workflow montrant comment ces outils interagissent  
3. Implémentez une version basique de l’un des outils dans votre langage préféré  
4. Créez un template de prompt qui aidera le modèle à utiliser efficacement votre outil  

## Ressources supplémentaires


---

Suivant : [Sujets avancés](../05-AdvancedTopics/README.md)

**Avertissement** :  
Ce document a été traduit à l'aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforçons d'assurer l'exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue native doit être considéré comme la source faisant foi. Pour les informations critiques, il est recommandé de faire appel à une traduction professionnelle réalisée par un humain. Nous ne sommes pas responsables des malentendus ou des mauvaises interprétations résultant de l'utilisation de cette traduction.