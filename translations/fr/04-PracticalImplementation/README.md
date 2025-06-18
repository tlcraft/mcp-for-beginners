<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d88dbf928fa0f159b82312e9a6757ba0",
  "translation_date": "2025-06-18T08:30:19+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "fr"
}
-->
# Mise en œuvre pratique

La mise en œuvre pratique est le moment où la puissance du Model Context Protocol (MCP) devient concrète. Bien que comprendre la théorie et l’architecture derrière le MCP soit important, la vraie valeur apparaît lorsque vous appliquez ces concepts pour construire, tester et déployer des solutions qui répondent à des problèmes réels. Ce chapitre fait le lien entre la connaissance conceptuelle et le développement pratique, en vous guidant à travers le processus de création d’applications basées sur MCP.

Que vous développiez des assistants intelligents, intégriez l’IA dans des flux de travail métier ou créiez des outils personnalisés pour le traitement des données, MCP offre une base flexible. Sa conception indépendante du langage et ses SDK officiels pour les langages de programmation populaires le rendent accessible à un large éventail de développeurs. En tirant parti de ces SDK, vous pouvez rapidement prototyper, itérer et faire évoluer vos solutions sur différentes plateformes et environnements.

Dans les sections suivantes, vous trouverez des exemples pratiques, des extraits de code et des stratégies de déploiement qui montrent comment implémenter MCP en C#, Java, TypeScript, JavaScript et Python. Vous apprendrez également à déboguer et tester vos serveurs MCP, gérer les API et déployer des solutions dans le cloud avec Azure. Ces ressources pratiques sont conçues pour accélérer votre apprentissage et vous aider à construire avec confiance des applications MCP robustes et prêtes pour la production.

## Vue d’ensemble

Cette leçon se concentre sur les aspects pratiques de l’implémentation MCP dans plusieurs langages de programmation. Nous explorerons comment utiliser les SDK MCP en C#, Java, TypeScript, JavaScript et Python pour construire des applications robustes, déboguer et tester les serveurs MCP, ainsi que créer des ressources, prompts et outils réutilisables.

## Objectifs d’apprentissage

À la fin de cette leçon, vous serez capable de :
- Implémenter des solutions MCP en utilisant les SDK officiels dans différents langages de programmation
- Déboguer et tester systématiquement les serveurs MCP
- Créer et utiliser les fonctionnalités serveur (Resources, Prompts et Tools)
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

Cette section fournit des exemples pratiques d’implémentation MCP dans plusieurs langages de programmation. Vous trouverez des exemples de code dans le répertoire `samples`, organisé par langage.

### Exemples disponibles

Le dépôt inclut des [implémentations exemples](../../../04-PracticalImplementation/samples) dans les langages suivants :

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Chaque exemple illustre les concepts clés du MCP et les modèles d’implémentation spécifiques à ce langage et écosystème.

## Fonctionnalités principales des serveurs

Les serveurs MCP peuvent implémenter n’importe quelle combinaison des fonctionnalités suivantes :

### Resources  
Les resources fournissent le contexte et les données à utiliser par l’utilisateur ou le modèle d’IA :  
- Dépôts de documents  
- Bases de connaissances  
- Sources de données structurées  
- Systèmes de fichiers  

### Prompts  
Les prompts sont des messages et workflows modélisés pour les utilisateurs :  
- Modèles de conversation prédéfinis  
- Schémas d’interaction guidée  
- Structures de dialogue spécialisées  

### Tools  
Les tools sont des fonctions que le modèle d’IA peut exécuter :  
- Utilitaires de traitement de données  
- Intégrations d’API externes  
- Capacités de calcul  
- Fonctionnalités de recherche  

## Exemples d’implémentation : C#

Le dépôt officiel du SDK C# contient plusieurs exemples illustrant différents aspects du MCP :

- **Client MCP basique** : Exemple simple montrant comment créer un client MCP et appeler des tools  
- **Serveur MCP basique** : Implémentation minimale de serveur avec enregistrement simple de tools  
- **Serveur MCP avancé** : Serveur complet avec enregistrement de tools, authentification et gestion des erreurs  
- **Intégration ASP.NET** : Exemples montrant l’intégration avec ASP.NET Core  
- **Modèles d’implémentation de tools** : Divers modèles pour implémenter des tools avec différents niveaux de complexité  

Le SDK MCP C# est en préversion et les API peuvent évoluer. Ce blog sera mis à jour régulièrement au fur et à mesure de l’évolution du SDK.

### Fonctionnalités clés  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Construisez votre [premier serveur MCP](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Pour des exemples complets d’implémentation C#, consultez le [dépôt officiel des exemples C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Exemple d’implémentation : Java

Le SDK Java offre des options robustes d’implémentation MCP avec des fonctionnalités de niveau entreprise.

### Fonctionnalités clés

- Intégration avec Spring Framework  
- Forte sécurité des types  
- Support de la programmation réactive  
- Gestion complète des erreurs  

Pour un exemple complet d’implémentation Java, consultez [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) dans le répertoire des exemples.

## Exemple d’implémentation : JavaScript

Le SDK JavaScript propose une approche légère et flexible pour l’implémentation MCP.

### Fonctionnalités clés

- Support Node.js et navigateurs  
- API basée sur les Promises  
- Intégration facile avec Express et autres frameworks  
- Support WebSocket pour le streaming  

Pour un exemple complet d’implémentation JavaScript, consultez [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) dans le répertoire des exemples.

## Exemple d’implémentation : Python

Le SDK Python offre une approche pythonique de l’implémentation MCP avec d’excellentes intégrations de frameworks ML.

### Fonctionnalités clés

- Support async/await avec asyncio  
- Intégration Flask et FastAPI  
- Enregistrement simple des tools  
- Intégration native avec les bibliothèques ML populaires  

Pour un exemple complet d’implémentation Python, consultez [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) dans le répertoire des exemples.

## Gestion des API

Azure API Management est une excellente solution pour sécuriser les serveurs MCP. L’idée est de placer une instance Azure API Management devant votre serveur MCP et de lui déléguer des fonctionnalités telles que :

- limitation du débit  
- gestion des tokens  
- supervision  
- répartition de charge  
- sécurité  

### Exemple Azure

Voici un exemple Azure qui fait exactement cela, c’est-à-dire [créer un serveur MCP et le sécuriser avec Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Voici comment se déroule le flux d’autorisation dans l’image ci-dessous :

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Dans l’image précédente, les étapes suivantes ont lieu :

- L’authentification/autorisation se fait via Microsoft Entra.  
- Azure API Management agit comme une passerelle et utilise des politiques pour diriger et gérer le trafic.  
- Azure Monitor enregistre toutes les requêtes pour une analyse ultérieure.  

#### Flux d’autorisation

Examinons le flux d’autorisation plus en détail :

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

2. Enregistrez `Microsoft.App`  
   ` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `  
   `. Then run `Register-AzResourceProvider -ProviderNamespace Microsoft.App` after some time to check if the registration is complete.

2. Run this [azd](https://aka.ms/azd) command to provision the api management service, function app(with code) and all other required Azure resources

    `  
   (Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState  
   Après un certain temps, vérifiez si l’enregistrement est terminé.

3. Exécutez cette commande [azd](https://aka.ms/azd) pour provisionner le service de gestion d’API, l’application fonctionnelle (avec le code) et toutes les autres ressources Azure nécessaires

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

2. Ctrl-clic pour charger l’application web MCP Inspector à partir de l’URL affichée par l’application (ex. http://127.0.0.1:6274/#resources)  
3. Réglez le type de transport sur `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` et **Connectez-vous** :

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Lister les Tools**. Cliquez sur un tool et **Exécutez-le**.  

Si toutes les étapes ont fonctionné, vous êtes maintenant connecté au serveur MCP et avez pu appeler un tool.

## Serveurs MCP pour Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) : Cet ensemble de dépôts constitue un modèle de démarrage rapide pour construire et déployer des serveurs MCP distants personnalisés utilisant Azure Functions avec Python, C# .NET ou Node/TypeScript.

Les exemples fournissent une solution complète qui permet aux développeurs de :

- Construire et exécuter localement : développer et déboguer un serveur MCP sur une machine locale  
- Déployer sur Azure : déployer facilement dans le cloud avec une simple commande azd up  
- Se connecter depuis des clients : se connecter au serveur MCP depuis divers clients, y compris le mode agent Copilot de VS Code et l’outil MCP Inspector  

### Fonctionnalités clés :

- Sécurité intégrée : le serveur MCP est sécurisé via des clés et HTTPS  
- Options d’authentification : supporte OAuth avec authentification intégrée et/ou API Management  
- Isolation réseau : permet l’isolation réseau via Azure Virtual Networks (VNET)  
- Architecture sans serveur : utilise Azure Functions pour une exécution scalable et événementielle  
- Développement local : support complet pour le développement et le débogage local  
- Déploiement simplifié : processus de déploiement fluide vers Azure  

Le dépôt inclut tous les fichiers de configuration nécessaires, le code source et les définitions d’infrastructure pour démarrer rapidement avec une implémentation MCP prête pour la production.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Exemple d’implémentation MCP utilisant Azure Functions avec Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Exemple d’implémentation MCP utilisant Azure Functions avec C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Exemple d’implémentation MCP utilisant Azure Functions avec Node/TypeScript.

## Points clés à retenir

- Les SDK MCP fournissent des outils spécifiques aux langages pour implémenter des solutions MCP robustes  
- Le processus de débogage et de test est crucial pour des applications MCP fiables  
- Les modèles de prompts réutilisables assurent des interactions IA cohérentes  
- Des workflows bien conçus peuvent orchestrer des tâches complexes en utilisant plusieurs tools  
- La mise en œuvre des solutions MCP nécessite de prendre en compte la sécurité, la performance et la gestion des erreurs  

## Exercice

Concevez un workflow MCP pratique qui répond à un problème réel dans votre domaine :

1. Identifiez 3 à 4 tools qui seraient utiles pour résoudre ce problème  
2. Créez un diagramme de workflow montrant comment ces tools interagissent  
3. Implémentez une version basique de l’un des tools dans le langage de votre choix  
4. Créez un modèle de prompt qui aiderait le modèle à utiliser efficacement votre tool  

## Ressources supplémentaires


---

Suivant : [Sujets avancés](../05-AdvancedTopics/README.md)

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatisées peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue native doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle humaine est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.