<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-02T10:07:55+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "fr"
}
-->
# Intégration du Model Context Protocol (MCP) avec Azure AI Foundry

Ce guide montre comment intégrer les serveurs Model Context Protocol (MCP) avec les agents Azure AI Foundry, permettant une orchestration avancée des outils et des capacités d’IA d’entreprise.

## Introduction

Model Context Protocol (MCP) est une norme ouverte qui permet aux applications d’IA de se connecter de manière sécurisée à des sources de données et outils externes. Lorsqu’il est intégré à Azure AI Foundry, MCP permet aux agents d’accéder et d’interagir avec divers services externes, API et sources de données de façon standardisée.

Cette intégration combine la flexibilité de l’écosystème d’outils MCP avec la robustesse du framework d’agents Azure AI Foundry, offrant des solutions d’IA de niveau entreprise avec de larges possibilités de personnalisation.

**Note :** Si vous souhaitez utiliser MCP dans Azure AI Foundry Agent Service, seules les régions suivantes sont actuellement prises en charge : westus, westus2, uaenorth, southindia et switzerlandnorth.

## Objectifs d’apprentissage

À la fin de ce guide, vous serez capable de :

- Comprendre le Model Context Protocol et ses avantages
- Configurer des serveurs MCP pour une utilisation avec les agents Azure AI Foundry
- Créer et configurer des agents avec intégration des outils MCP
- Mettre en œuvre des exemples pratiques avec de vrais serveurs MCP
- Gérer les réponses des outils et les citations dans les conversations des agents

## Prérequis

Avant de commencer, assurez-vous de disposer de :

- Un abonnement Azure avec accès à AI Foundry
- Python 3.10+
- Azure CLI installé et configuré
- Les permissions nécessaires pour créer des ressources AI

## Qu’est-ce que le Model Context Protocol (MCP) ?

Model Context Protocol est une méthode standardisée permettant aux applications d’IA de se connecter à des sources de données et outils externes. Ses principaux avantages sont :

- **Intégration standardisée** : interface cohérente entre différents outils et services
- **Sécurité** : mécanismes sécurisés d’authentification et d’autorisation
- **Flexibilité** : prise en charge de diverses sources de données, API et outils personnalisés
- **Extensibilité** : ajout facile de nouvelles fonctionnalités et intégrations

## Configuration de MCP avec Azure AI Foundry

### 1. Configuration de l’environnement

Commencez par configurer vos variables d’environnement et dépendances :

```python
import os
import time
import json
from azure.ai.agents.models import MessageTextContent, ListSortOrder
from azure.ai.projects import AIProjectClient
from azure.identity import DefaultAzureCredential


### 1. Initialize the AI Project Client

```python
project_client = AIProjectClient(
    endpoint="https://your-project-endpoint.services.ai.azure.com/api/projects/your-project",
    credential=DefaultAzureCredential(),
)
```

### 2. Create an Agent with MCP Tools

Configure an agent with MCP server integration:

```python
with project_client:
    agent = project_client.agents.create_agent(
        model="gpt-4.1-nano", 
        name="mcp_agent", 
        instructions="Vous êtes un assistant utile. Utilisez les outils fournis pour répondre aux questions. Veillez à citer vos sources.",
        tools=[
            {
                "type": "mcp",
                "server_label": "microsoft_docs",
                "server_url": "https://learn.microsoft.com/api/mcp",
                "require_approval": "never"
            }
        ],
        tool_resources=None
    )
    print(f"Agent créé, ID de l’agent : {agent.id}")
```

## MCP Tool Configuration Options

When configuring MCP tools for your agent, you can specify several important parameters:

### Configuration

```python
mcp_tool = {
    "type": "mcp",
    "server_label": "unique_server_name",      # Identifiant du serveur MCP
    "server_url": "https://api.example.com/mcp", # Point de terminaison du serveur MCP
    "require_approval": "never"                 # Politique d’approbation : pour l’instant, seule la valeur "never" est supportée
}
```

## Complete Example: Using Microsoft Learn MCP Server

Here's a complete example that demonstrates creating an agent with MCP integration and processing a conversation:

```python
import time
import json
import os
from azure.ai.agents.models import MessageTextContent, ListSortOrder
from azure.ai.projects import AIProjectClient
from azure.identity import DefaultAzureCredential

def create_mcp_agent_example():

    project_client = AIProjectClient(
        endpoint="https://your-endpoint.services.ai.azure.com/api/projects/your-project",
        credential=DefaultAzureCredential(),
    )

    with project_client:
        # Créer un agent avec des outils MCP
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="Vous êtes un assistant utile spécialisé dans la documentation Microsoft. Utilisez le serveur MCP Microsoft Learn pour rechercher des informations précises et à jour. Citez toujours vos sources.",
            tools=[
                {
                    "type": "mcp",
                    "server_label": "mslearn",
                    "server_url": "https://learn.microsoft.com/api/mcp",
                    "require_approval": "never"
                }
            ],
            tool_resources=None
        )
        print(f"Agent créé, ID de l’agent : {agent.id}")    
        
        # Créer un fil de conversation
        thread = project_client.agents.threads.create()
        print(f"Fil créé, ID du fil : {thread.id}")

        # Envoyer un message
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="Qu’est-ce que .NET MAUI ? Comment se compare-t-il à Xamarin.Forms ?",
        )
        print(f"Message créé, ID du message : {message.id}")

        # Exécuter l’agent
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # Attendre la fin de l’exécution
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Statut de l’exécution : {run.status}")

        # Examiner les étapes d’exécution et les appels aux outils
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Étape d’exécution : {step.id}, statut : {step.status}, type : {step.type}")
            if step.type == "tool_calls":
                print("Détails des appels aux outils :")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # Afficher la conversation
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role} : {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()
  

## Résolution des problèmes courants

### 1. Problèmes de connexion
- Vérifiez que l’URL du serveur MCP est accessible
- Contrôlez les identifiants d’authentification
- Assurez-vous de la connectivité réseau

### 2. Échecs d’appels aux outils
- Vérifiez les arguments et leur format
- Contrôlez les exigences spécifiques au serveur
- Implémentez une gestion correcte des erreurs

### 3. Problèmes de performance
- Optimisez la fréquence des appels aux outils
- Mettez en place un cache si nécessaire
- Surveillez les temps de réponse du serveur

## Étapes suivantes

Pour améliorer davantage votre intégration MCP :

1. **Explorez les serveurs MCP personnalisés** : développez vos propres serveurs MCP pour des sources de données propriétaires
2. **Implémentez une sécurité avancée** : ajoutez OAuth2 ou des mécanismes d’authentification personnalisés
3. **Surveillance et analyse** : mettez en place des journaux et un suivi de l’utilisation des outils
4. **Mettez à l’échelle votre solution** : envisagez l’équilibrage de charge et des architectures de serveurs MCP distribués

## Ressources supplémentaires

- [Documentation Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- [Exemples Model Context Protocol](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Présentation des agents Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [Spécification MCP](https://spec.modelcontextprotocol.io/)

## Support

Pour un support supplémentaire et des questions :
- Consultez la [documentation Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- Parcourez les [ressources communautaires MCP](https://modelcontextprotocol.io/)

## Et après

- [6. Contributions de la communauté](../../06-CommunityContributions/README.md)

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue native doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.