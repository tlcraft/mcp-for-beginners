<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:19:16+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "fr"
}
-->
# Étude de cas : Exposer une API REST dans API Management en tant que serveur MCP

Azure API Management est un service qui fournit une passerelle au-dessus de vos points de terminaison API. Son fonctionnement repose sur le fait qu’Azure API Management agit comme un proxy devant vos APIs et peut décider quoi faire des requêtes entrantes.

En l’utilisant, vous bénéficiez d’un ensemble complet de fonctionnalités telles que :

- **Sécurité**, vous pouvez utiliser tout, des clés API, JWT à l’identité gérée.
- **Limitation du débit**, une fonctionnalité très utile qui permet de décider combien d’appels sont autorisés par unité de temps. Cela garantit une bonne expérience pour tous les utilisateurs et évite que votre service soit submergé par les requêtes.
- **Mise à l’échelle et répartition de charge**. Vous pouvez configurer plusieurs points de terminaison pour répartir la charge et choisir la méthode de répartition.
- **Fonctionnalités IA comme la mise en cache sémantique**, la limitation et le suivi des jetons, et plus encore. Ce sont d’excellentes fonctionnalités qui améliorent la réactivité tout en vous aidant à maîtriser vos dépenses en jetons. [En savoir plus ici](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## Pourquoi MCP + Azure API Management ?

Le Model Context Protocol devient rapidement une norme pour les applications IA agentiques et la manière d’exposer outils et données de façon cohérente. Azure API Management est un choix naturel lorsque vous devez « gérer » des APIs. Les serveurs MCP s’intègrent souvent avec d’autres APIs pour résoudre des requêtes vers un outil, par exemple. Combiner Azure API Management et MCP est donc très pertinent.

## Vue d’ensemble

Dans ce cas d’usage spécifique, nous allons apprendre à exposer des points de terminaison API en tant que serveur MCP. Cela nous permet d’intégrer facilement ces points de terminaison dans une application agentique tout en tirant parti des fonctionnalités d’Azure API Management.

## Fonctionnalités clés

- Vous sélectionnez les méthodes du point de terminaison que vous souhaitez exposer en tant qu’outils.
- Les fonctionnalités supplémentaires dépendent de ce que vous configurez dans la section politique de votre API. Ici, nous vous montrerons comment ajouter une limitation du débit.

## Étape préalable : importer une API

Si vous avez déjà une API dans Azure API Management, parfait, vous pouvez passer cette étape. Sinon, consultez ce lien, [importer une API dans Azure API Management](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## Exposer l’API en tant que serveur MCP

Pour exposer les points de terminaison API, suivez ces étapes :

1. Rendez-vous sur le portail Azure à l’adresse suivante <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
Accédez à votre instance API Management.

1. Dans le menu de gauche, sélectionnez APIs > MCP Servers > + Créer un nouveau serveur MCP.

1. Dans API, sélectionnez une API REST à exposer en tant que serveur MCP.

1. Sélectionnez une ou plusieurs opérations API à exposer en tant qu’outils. Vous pouvez choisir toutes les opérations ou seulement certaines.

    ![Sélectionner les méthodes à exposer](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. Cliquez sur **Créer**.

1. Allez dans le menu **APIs** puis **MCP Servers**, vous devriez voir ceci :

    ![Voir le serveur MCP dans le panneau principal](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    Le serveur MCP est créé et les opérations API sont exposées en tant qu’outils. Le serveur MCP apparaît dans le panneau MCP Servers. La colonne URL affiche le point de terminaison du serveur MCP que vous pouvez appeler pour tester ou depuis une application cliente.

## Optionnel : Configurer les politiques

Azure API Management repose sur le concept central de politiques où vous définissez différentes règles pour vos points de terminaison, comme par exemple la limitation du débit ou la mise en cache sémantique. Ces politiques sont écrites en XML.

Voici comment configurer une politique pour limiter le débit de votre serveur MCP :

1. Dans le portail, sous APIs, sélectionnez **MCP Servers**.

1. Choisissez le serveur MCP que vous avez créé.

1. Dans le menu de gauche, sous MCP, sélectionnez **Politiques**.

1. Dans l’éditeur de politiques, ajoutez ou modifiez les politiques que vous souhaitez appliquer aux outils du serveur MCP. Les politiques sont définies en XML. Par exemple, vous pouvez ajouter une politique pour limiter les appels aux outils du serveur MCP (ici, 5 appels toutes les 30 secondes par adresse IP client). Voici le XML qui applique cette limitation :

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    Voici une image de l’éditeur de politiques :

    ![Éditeur de politiques](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## Essayez-le

Assurons-nous que notre serveur MCP fonctionne comme prévu.

Pour cela, nous utiliserons Visual Studio Code avec GitHub Copilot en mode Agent. Nous allons ajouter le serveur MCP dans un fichier *mcp.json*. Ainsi, Visual Studio Code agira comme un client avec des capacités agentiques et les utilisateurs pourront saisir une requête et interagir avec ce serveur.

Voici comment ajouter le serveur MCP dans Visual Studio Code :

1. Utilisez la commande MCP : **Add Server depuis la palette de commandes**.

1. Lorsque demandé, sélectionnez le type de serveur : **HTTP (HTTP ou Server Sent Events)**.

1. Saisissez l’URL du serveur MCP dans API Management. Exemple : **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (pour le point de terminaison SSE) ou **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (pour le point de terminaison MCP), notez la différence entre les transports `/sse` ou `/mcp`.

1. Entrez un ID serveur de votre choix. Ce n’est pas une valeur critique mais cela vous aidera à identifier cette instance serveur.

1. Choisissez d’enregistrer la configuration dans les paramètres de l’espace de travail ou dans les paramètres utilisateur.

  - **Paramètres de l’espace de travail** - La configuration du serveur est enregistrée dans un fichier .vscode/mcp.json disponible uniquement dans l’espace de travail courant.

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    ou si vous choisissez le transport HTTP en streaming, ce sera légèrement différent :

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **Paramètres utilisateur** - La configuration du serveur est ajoutée au fichier global *settings.json* et est disponible dans tous les espaces de travail. La configuration ressemble à ceci :

    ![Paramètre utilisateur](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. Vous devez aussi ajouter une configuration, un en-tête pour vous assurer que l’authentification vers Azure API Management fonctionne correctement. Il utilise un en-tête appelé **Ocp-Apim-Subscription-Key**.

    - Voici comment l’ajouter dans les paramètres :

    ![Ajout de l’en-tête pour l’authentification](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png), cela affichera une invite pour saisir la clé API que vous trouverez dans le portail Azure pour votre instance Azure API Management.

   - Pour l’ajouter dans *mcp.json*, vous pouvez faire comme suit :

    ```json
    "inputs": [
      {
        "type": "promptString",
        "id": "apim_key",
        "description": "API Key for Azure API Management",
        "password": true
      }
    ]
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp",
            "headers": {
                "Ocp-Apim-Subscription-Key": "Bearer ${input:apim_key}"
            }
        }
    }
    ```

### Utiliser le mode Agent

Nous sommes maintenant prêts, que ce soit dans les paramètres ou dans *.vscode/mcp.json*. Testons-le.

Vous devriez voir une icône Outils comme celle-ci, où les outils exposés par votre serveur sont listés :

![Outils du serveur](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Cliquez sur l’icône outils et vous verrez une liste d’outils comme ceci :

    ![Outils](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. Saisissez une requête dans le chat pour invoquer un outil. Par exemple, si vous avez sélectionné un outil pour obtenir des informations sur une commande, vous pouvez demander à l’agent à propos d’une commande. Voici un exemple de requête :

    ```text
    get information from order 2
    ```

    Une icône outils vous invitera à poursuivre l’appel de l’outil. Sélectionnez pour continuer l’exécution de l’outil, vous devriez voir un résultat comme ceci :

    ![Résultat de la requête](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **Ce que vous voyez dépend des outils que vous avez configurés, mais l’idée est d’obtenir une réponse textuelle comme ci-dessus.**

## Références

Voici comment en apprendre davantage :

- [Tutoriel sur Azure API Management et MCP](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Exemple Python : sécuriser des serveurs MCP distants avec Azure API Management (expérimental)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [Laboratoire d’autorisation client MCP](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [Utiliser l’extension Azure API Management pour VS Code pour importer et gérer des APIs](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Enregistrer et découvrir des serveurs MCP distants dans Azure API Center](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Excellent dépôt montrant de nombreuses capacités IA avec Azure API Management
- [Ateliers AI Gateway](https://azure-samples.github.io/AI-Gateway/) Contient des ateliers utilisant le portail Azure, une excellente façon de commencer à évaluer les capacités IA.

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.