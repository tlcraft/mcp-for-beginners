<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-06-13T16:42:31+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "fr"
}
-->
# Leçons des premiers utilisateurs

## Aperçu

Cette leçon explore comment les premiers utilisateurs ont exploité le Model Context Protocol (MCP) pour résoudre des défis concrets et stimuler l'innovation dans divers secteurs. À travers des études de cas détaillées et des projets pratiques, vous découvrirez comment MCP permet une intégration standardisée, sécurisée et évolutive de l’IA — connectant les grands modèles de langage, les outils et les données d’entreprise dans un cadre unifié. Vous gagnerez une expérience concrète en concevant et en construisant des solutions basées sur MCP, apprendrez des modèles d’implémentation éprouvés et découvrirez les meilleures pratiques pour déployer MCP en production. La leçon met également en lumière les tendances émergentes, les orientations futures et les ressources open source pour vous aider à rester à la pointe de la technologie MCP et de son écosystème en évolution.

## Objectifs d’apprentissage

- Analyser des implémentations réelles de MCP dans différents secteurs
- Concevoir et développer des applications complètes basées sur MCP
- Explorer les tendances émergentes et les orientations futures de la technologie MCP
- Appliquer les meilleures pratiques dans des scénarios de développement concrets

## Implémentations réelles de MCP

### Étude de cas 1 : Automatisation du support client en entreprise

Une multinationale a mis en place une solution basée sur MCP pour standardiser les interactions IA dans ses systèmes de support client. Cela leur a permis de :

- Créer une interface unifiée pour plusieurs fournisseurs de LLM
- Maintenir une gestion cohérente des prompts entre les départements
- Mettre en œuvre des contrôles de sécurité et de conformité robustes
- Passer facilement d’un modèle IA à un autre selon les besoins spécifiques

**Implémentation technique :**  
```python
# Python MCP server implementation for customer support
import logging
import asyncio
from modelcontextprotocol import create_server, ServerConfig
from modelcontextprotocol.server import MCPServer
from modelcontextprotocol.transports import create_http_transport
from modelcontextprotocol.resources import ResourceDefinition
from modelcontextprotocol.prompts import PromptDefinition
from modelcontextprotocol.tool import ToolDefinition

# Configure logging
logging.basicConfig(level=logging.INFO)

async def main():
    # Create server configuration
    config = ServerConfig(
        name="Enterprise Customer Support Server",
        version="1.0.0",
        description="MCP server for handling customer support inquiries"
    )
    
    # Initialize MCP server
    server = create_server(config)
    
    # Register knowledge base resources
    server.resources.register(
        ResourceDefinition(
            name="customer_kb",
            description="Customer knowledge base documentation"
        ),
        lambda params: get_customer_documentation(params)
    )
    
    # Register prompt templates
    server.prompts.register(
        PromptDefinition(
            name="support_template",
            description="Templates for customer support responses"
        ),
        lambda params: get_support_templates(params)
    )
    
    # Register support tools
    server.tools.register(
        ToolDefinition(
            name="ticketing",
            description="Create and update support tickets"
        ),
        handle_ticketing_operations
    )
    
    # Start server with HTTP transport
    transport = create_http_transport(port=8080)
    await server.run(transport)

if __name__ == "__main__":
    asyncio.run(main())
```

**Résultats :** Réduction de 30 % des coûts liés aux modèles, amélioration de 45 % de la cohérence des réponses, et conformité renforcée à l’échelle mondiale.

### Étude de cas 2 : Assistant diagnostique en santé

Un prestataire de santé a développé une infrastructure MCP pour intégrer plusieurs modèles IA médicaux spécialisés tout en garantissant la protection des données sensibles des patients :

- Passage fluide entre modèles médicaux généralistes et spécialistes
- Contrôles stricts de confidentialité et traçabilité des audits
- Intégration avec les systèmes de dossiers médicaux électroniques (DME) existants
- Ingénierie de prompts cohérente pour la terminologie médicale

**Implémentation technique :**  
```csharp
// C# MCP host application implementation in healthcare application
using Microsoft.Extensions.DependencyInjection;
using ModelContextProtocol.SDK.Client;
using ModelContextProtocol.SDK.Security;
using ModelContextProtocol.SDK.Resources;

public class DiagnosticAssistant
{
    private readonly MCPHostClient _mcpClient;
    private readonly PatientContext _patientContext;
    
    public DiagnosticAssistant(PatientContext patientContext)
    {
        _patientContext = patientContext;
        
        // Configure MCP client with healthcare-specific settings
        var clientOptions = new ClientOptions
        {
            Name = "Healthcare Diagnostic Assistant",
            Version = "1.0.0",
            Security = new SecurityOptions
            {
                Encryption = EncryptionLevel.Medical,
                AuditEnabled = true
            }
        };
        
        _mcpClient = new MCPHostClientBuilder()
            .WithOptions(clientOptions)
            .WithTransport(new HttpTransport("https://healthcare-mcp.example.org"))
            .WithAuthentication(new HIPAACompliantAuthProvider())
            .Build();
    }
    
    public async Task<DiagnosticSuggestion> GetDiagnosticAssistance(
        string symptoms, string patientHistory)
    {
        // Create request with appropriate resources and tool access
        var resourceRequest = new ResourceRequest
        {
            Name = "patient_records",
            Parameters = new Dictionary<string, object>
            {
                ["patientId"] = _patientContext.PatientId,
                ["requestingProvider"] = _patientContext.ProviderId
            }
        };
        
        // Request diagnostic assistance using appropriate prompt
        var response = await _mcpClient.SendPromptRequestAsync(
            promptName: "diagnostic_assistance",
            parameters: new Dictionary<string, object>
            {
                ["symptoms"] = symptoms,
                patientHistory = patientHistory,
                relevantGuidelines = _patientContext.GetRelevantGuidelines()
            });
            
        return DiagnosticSuggestion.FromMCPResponse(response);
    }
}
```

**Résultats :** Suggestions diagnostiques améliorées pour les médecins, conformité totale avec la HIPAA et réduction significative des changements de contexte entre systèmes.

### Étude de cas 3 : Analyse des risques dans les services financiers

Une institution financière a déployé MCP pour standardiser ses processus d’analyse des risques dans différents départements :

- Interface unifiée pour les modèles de risque de crédit, détection de fraude et risque d’investissement
- Contrôles d’accès stricts et gestion des versions des modèles
- Garantie d’auditabilité pour toutes les recommandations IA
- Uniformisation du format des données entre systèmes variés

**Implémentation technique :**  
```java
// Java MCP server for financial risk assessment
import org.mcp.server.*;
import org.mcp.security.*;

public class FinancialRiskMCPServer {
    public static void main(String[] args) {
        // Create MCP server with financial compliance features
        MCPServer server = new MCPServerBuilder()
            .withModelProviders(
                new ModelProvider("risk-assessment-primary", new AzureOpenAIProvider()),
                new ModelProvider("risk-assessment-audit", new LocalLlamaProvider())
            )
            .withPromptTemplateDirectory("./compliance/templates")
            .withAccessControls(new SOCCompliantAccessControl())
            .withDataEncryption(EncryptionStandard.FINANCIAL_GRADE)
            .withVersionControl(true)
            .withAuditLogging(new DatabaseAuditLogger())
            .build();
            
        server.addRequestValidator(new FinancialDataValidator());
        server.addResponseFilter(new PII_RedactionFilter());
        
        server.start(9000);
        
        System.out.println("Financial Risk MCP Server running on port 9000");
    }
}
```

**Résultats :** Conformité réglementaire renforcée, cycles de déploiement des modèles 40 % plus rapides, et meilleure cohérence dans l’évaluation des risques.

### Étude de cas 4 : Serveur Playwright MCP de Microsoft pour l’automatisation navigateur

Microsoft a développé le [serveur Playwright MCP](https://github.com/microsoft/playwright-mcp) pour permettre une automatisation navigateur sécurisée et standardisée via le Model Context Protocol. Cette solution permet aux agents IA et LLM d’interagir avec les navigateurs web de manière contrôlée, auditée et extensible — facilitant des cas d’usage tels que les tests web automatisés, l’extraction de données et les workflows de bout en bout.

- Expose les capacités d’automatisation du navigateur (navigation, remplissage de formulaires, capture d’écran, etc.) comme outils MCP
- Met en œuvre des contrôles d’accès stricts et un sandboxing pour éviter les actions non autorisées
- Fournit des journaux d’audit détaillés pour toutes les interactions navigateur
- Supporte l’intégration avec Azure OpenAI et d’autres fournisseurs LLM pour l’automatisation pilotée par agents

**Implémentation technique :**  
```typescript
// TypeScript: Registering Playwright browser automation tools in an MCP server
import { createServer, ToolDefinition } from 'modelcontextprotocol';
import { launch } from 'playwright';

const server = createServer({
  name: 'Playwright MCP Server',
  version: '1.0.0',
  description: 'MCP server for browser automation using Playwright'
});

// Register a tool for navigating to a URL and capturing a screenshot
server.tools.register(
  new ToolDefinition({
    name: 'navigate_and_screenshot',
    description: 'Navigate to a URL and capture a screenshot',
    parameters: {
      url: { type: 'string', description: 'The URL to visit' }
    }
  }),
  async ({ url }) => {
    const browser = await launch();
    const page = await browser.newPage();
    await page.goto(url);
    const screenshot = await page.screenshot();
    await browser.close();
    return { screenshot };
  }
);

// Start the MCP server
server.listen(8080);
```

**Résultats :**  
- Automatisation navigateur sécurisée et programmable pour agents IA et LLM  
- Réduction des efforts de tests manuels et amélioration de la couverture des tests web  
- Cadre réutilisable et extensible pour l’intégration d’outils basés sur navigateur en entreprise

**Références :**  
- [Dépôt GitHub Playwright MCP Server](https://github.com/microsoft/playwright-mcp)  
- [Solutions IA et automatisation Microsoft](https://azure.microsoft.com/en-us/products/ai-services/)

### Étude de cas 5 : Azure MCP – Model Context Protocol de niveau entreprise en tant que service

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) est l’implémentation managée et de niveau entreprise du Model Context Protocol par Microsoft, conçue pour offrir des capacités de serveur MCP évolutives, sécurisées et conformes en mode cloud. Azure MCP permet aux organisations de déployer, gérer et intégrer rapidement des serveurs MCP avec les services Azure AI, données et sécurité, réduisant la charge opérationnelle et accélérant l’adoption de l’IA.

- Hébergement entièrement managé de serveurs MCP avec mise à l’échelle, supervision et sécurité intégrées
- Intégration native avec Azure OpenAI, Azure AI Search et autres services Azure
- Authentification et autorisation d’entreprise via Microsoft Entra ID
- Support des outils personnalisés, modèles de prompts et connecteurs de ressources
- Conformité aux exigences de sécurité et réglementaires des entreprises

**Implémentation technique :**  
```yaml
# Example: Azure MCP server deployment configuration (YAML)
apiVersion: mcp.microsoft.com/v1
kind: McpServer
metadata:
  name: enterprise-mcp-server
spec:
  modelProviders:
    - name: azure-openai
      type: AzureOpenAI
      endpoint: https://<your-openai-resource>.openai.azure.com/
      apiKeySecret: <your-azure-keyvault-secret>
  tools:
    - name: document_search
      type: AzureAISearch
      endpoint: https://<your-search-resource>.search.windows.net/
      apiKeySecret: <your-azure-keyvault-secret>
  authentication:
    type: EntraID
    tenantId: <your-tenant-id>
  monitoring:
    enabled: true
    logAnalyticsWorkspace: <your-log-analytics-id>
```

**Résultats :**  
- Réduction du délai de mise en œuvre des projets IA d’entreprise grâce à une plateforme serveur MCP prête à l’emploi et conforme  
- Simplification de l’intégration des LLM, outils et sources de données d’entreprise  
- Sécurité, observabilité et efficacité opérationnelle accrues pour les charges MCP

**Références :**  
- [Documentation Azure MCP](https://aka.ms/azmcp)  
- [Services Azure AI](https://azure.microsoft.com/en-us/products/ai-services/)

## Étude de cas 6 : NLWeb  
MCP (Model Context Protocol) est un protocole émergent permettant aux chatbots et assistants IA d’interagir avec des outils. Chaque instance NLWeb est également un serveur MCP, supportant une méthode principale, ask, utilisée pour poser une question en langage naturel à un site web. La réponse retournée utilise schema.org, un vocabulaire largement adopté pour décrire les données web. En termes simples, MCP est à NLWeb ce que Http est à HTML. NLWeb combine protocoles, formats Schema.org et code exemple pour aider les sites à créer rapidement ces points d’accès, profitant à la fois aux humains via des interfaces conversationnelles et aux machines par des interactions naturelles agent-à-agent.

NLWeb comprend deux composants distincts :  
- Un protocole, très simple au départ, pour interagir en langage naturel avec un site, et un format utilisant json et schema.org pour la réponse. Voir la documentation sur l’API REST pour plus de détails.  
- Une implémentation simple de (1) qui exploite le balisage existant, pour les sites pouvant être abstraits en listes d’éléments (produits, recettes, attractions, avis, etc.). Avec un ensemble de widgets UI, les sites peuvent facilement offrir des interfaces conversationnelles à leur contenu. Voir la documentation sur Life of a chat query pour plus d’informations sur ce fonctionnement.

**Références :**  
- [Documentation Azure MCP](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Étude de cas 7 : MCP pour Foundry – Intégration des agents Azure AI

Les serveurs Azure AI Foundry MCP montrent comment MCP peut orchestrer et gérer les agents IA et workflows en environnement d’entreprise. En intégrant MCP avec Azure AI Foundry, les organisations peuvent standardiser les interactions des agents, exploiter la gestion des workflows de Foundry et garantir des déploiements sécurisés et évolutifs. Cette approche facilite le prototypage rapide, une supervision robuste et une intégration fluide avec les services Azure AI, soutenant des scénarios avancés comme la gestion des connaissances et l’évaluation des agents. Les développeurs bénéficient d’une interface unifiée pour construire, déployer et superviser les pipelines d’agents, tandis que les équipes IT gagnent en sécurité, conformité et efficacité opérationnelle. La solution est idéale pour les entreprises souhaitant accélérer l’adoption de l’IA tout en gardant le contrôle sur des processus complexes pilotés par agents.

**Références :**  
- [Dépôt GitHub MCP Foundry](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Intégration des agents Azure AI avec MCP (Blog Microsoft Foundry)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Étude de cas 8 : Foundry MCP Playground – Expérimentation et prototypage

Le Foundry MCP Playground offre un environnement prêt à l’emploi pour expérimenter avec les serveurs MCP et les intégrations Azure AI Foundry. Les développeurs peuvent rapidement prototyper, tester et évaluer des modèles IA et workflows d’agents en utilisant les ressources du catalogue et des labs Azure AI Foundry. Le playground simplifie la mise en place, propose des projets exemples et supporte le développement collaboratif, facilitant l’exploration des meilleures pratiques et de nouveaux scénarios avec un minimum de contraintes. Il est particulièrement utile pour les équipes souhaitant valider des idées, partager des expériences et accélérer l’apprentissage sans infrastructure complexe. En abaissant la barrière d’entrée, le playground favorise l’innovation et les contributions communautaires dans l’écosystème MCP et Azure AI Foundry.

**Références :**  
- [Dépôt GitHub Foundry MCP Playground](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### Étude de cas 9 : Microsoft Docs MCP Server – Apprentissage et montée en compétences  
Le Microsoft Docs MCP Server implémente un serveur Model Context Protocol fournissant aux assistants IA un accès en temps réel à la documentation officielle Microsoft. Il réalise une recherche sémantique dans la documentation technique officielle Microsoft.

**Références :**  
- [Microsoft Learn Docs MCP Server](https://github.com/MicrosoftDocs/mcp)

## Projets pratiques

### Projet 1 : Construire un serveur MCP multi-fournisseurs

**Objectif :** Créer un serveur MCP capable de router les requêtes vers plusieurs fournisseurs de modèles IA selon des critères définis.

**Exigences :**  
- Supporter au moins trois fournisseurs de modèles différents (par ex. OpenAI, Anthropic, modèles locaux)  
- Implémenter un mécanisme de routage basé sur les métadonnées des requêtes  
- Créer un système de configuration pour gérer les identifiants des fournisseurs  
- Ajouter un cache pour optimiser les performances et réduire les coûts  
- Construire un tableau de bord simple pour le suivi de l’utilisation

**Étapes d’implémentation :**  
1. Mettre en place l’infrastructure de base du serveur MCP  
2. Développer les adaptateurs fournisseurs pour chaque service de modèle IA  
3. Créer la logique de routage basée sur les attributs des requêtes  
4. Ajouter les mécanismes de cache pour les requêtes fréquentes  
5. Développer le tableau de bord de supervision  
6. Tester avec différents types de requêtes

**Technologies :** Choix libre entre Python (.NET/Java/Python selon préférence), Redis pour le cache, et un framework web simple pour le tableau de bord.

### Projet 2 : Système de gestion de prompts en entreprise

**Objectif :** Développer un système basé sur MCP pour gérer, versionner et déployer des modèles de prompts dans une organisation.

**Exigences :**  
- Créer un dépôt centralisé pour les modèles de prompts  
- Implémenter la gestion des versions et des workflows d’approbation  
- Construire des capacités de test des modèles avec des entrées d’exemple  
- Développer des contrôles d’accès basés sur les rôles  
- Créer une API pour la récupération et le déploiement des modèles

**Étapes d’implémentation :**  
1. Concevoir le schéma de base de données pour le stockage des modèles  
2. Créer l’API principale pour les opérations CRUD sur les modèles  
3. Implémenter le système de gestion des versions  
4. Construire le workflow d’approbation  
5. Développer le cadre de test  
6. Créer une interface web simple pour la gestion  
7. Intégrer avec un serveur MCP

**Technologies :** Choix libre de framework backend, base SQL ou NoSQL, et framework frontend pour l’interface de gestion.

### Projet 3 : Plateforme de génération de contenu basée sur MCP

**Objectif :** Construire une plateforme de génération de contenu exploitant MCP pour garantir des résultats cohérents sur différents types de contenus.

**Exigences :**  
- Supporter plusieurs formats de contenu (articles de blog, réseaux sociaux, textes marketing)  
- Implémenter une génération basée sur des modèles avec options de personnalisation  
- Créer un système de revue et de feedback sur le contenu  
- Suivre les indicateurs de performance du contenu  
- Supporter la gestion des versions et itérations du contenu

**Étapes d’implémentation :**  
1. Mettre en place l’infrastructure cliente MCP  
2. Créer des modèles pour différents types de contenu  
3. Construire la chaîne de génération de contenu  
4. Implémenter le système de revue  
5. Développer le suivi des métriques  
6. Créer une interface utilisateur pour la gestion des modèles et la génération de contenu

**Technologies :** Langage de programmation, framework web et système de base de données au choix.

## Orientations futures pour la technologie MCP

### Tendances émergentes

1. **MCP multimodal**  
   - Extension de MCP pour standardiser les interactions avec les modèles d’images, audio et vidéo  
   - Développement de capacités de raisonnement intermodal  
   - Formats de prompts standardisés pour différentes modalités

2. **Infrastructure MCP fédérée**  
   - Réseaux MCP distribués partageant des ressources entre organisations  
   - Protocoles standardisés pour le partage sécurisé de modèles  
   - Techniques de calcul préservant la confidentialité

3. **Marchés MCP**  
   - Écosystèmes pour partager et monétiser modèles MCP et plugins  
   - Processus d’assurance qualité et de certification  
   - Intégration avec des places de marché de modèles

4. **MCP pour edge computing**  
   - Adaptation des standards MCP pour les dispositifs edge aux ressources limitées  
   - Protocoles optimisés pour les environnements à faible bande passante  
   - Implémentations spécialisées MCP pour les écosystèmes IoT

5. **Cadres réglementaires**  
   - Développement d’extensions MCP pour la conformité réglementaire  
   - Traçabilité standardisée et interfaces d’explicabilité  
   - Intégration avec les cadres émergents de gouvernance IA

### Solutions MCP de Microsoft

Microsoft et Azure ont développé plusieurs dépôts open source pour aider les développeurs à implémenter MCP dans divers scénarios :

#### Organisation Microsoft  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) – Serveur Playwright MCP pour automatisation et tests navigateur  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) – Implémentation serveur MCP OneDrive pour tests locaux et contribution communautaire  
3. [NLWeb](https://github.com/microsoft/NlWeb) – Collection de protocoles ouverts et outils open source, axée sur la couche fondamentale pour le Web IA  

#### Organisation Azure-Samples  
1. [mcp](https://github.com/Azure-Samples/mcp) – Exemples, outils et ressources pour construire et intégrer des serveurs MCP sur Azure avec plusieurs langages  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) – Serveurs MCP de référence démontrant l’authentification selon la spécification MCP actuelle  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) – Page d’accueil pour implémentations Remote MCP Server en Azure Functions avec liens vers dépôts par langage  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) – Template de démarrage rapide pour construire et déployer des serveurs MCP distants avec Azure Functions en Python  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) – Template équivalent en .NET/C#  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) – Template en TypeScript  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) – Azure API Management comme passerelle IA vers serveurs MCP distants en Python  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) – Expériences APIM ❤️ IA incluant capacités MCP, intégration Azure OpenAI et AI Foundry

Ces dépôts offrent diverses implémentations, modèles et ressources pour travailler avec MCP dans plusieurs langages et services Azure, couvrant des cas d’usage allant des serveurs de base à l’authentification, au déploiement cloud et à l’intégration en entreprise.

#### Répertoire des ressources MCP

Le [répertoire des ressources MCP](https://github.com/microsoft/mcp/tree/main/Resources) dans le dépôt officiel Microsoft MCP propose une collection organisée d’exemples, modèles de prompts et définitions d’outils pour les serveurs Model Context Protocol. Ce répertoire aide les développeurs à démarrer rapidement avec MCP en offrant des blocs réutilisables et des exemples de bonnes pratiques pour :

- **Modèles de prompts :** Modèles prêts à l’emploi pour tâches IA courantes, adaptables à vos implémentations MCP  
- **Définitions d’outils :** Schémas et métadonnées d’outils types pour standardiser leur intégration et invocation  
- **Exemples de ressources :** Définitions types pour connecter sources de données, API et services externes dans MCP  
- **Implémentations de référence :** Exemples pratiques montrant comment
- [Communauté MCP & Documentation](https://modelcontextprotocol.io/introduction)
- [Documentation Azure MCP](https://aka.ms/azmcp)
- [Dépôt GitHub Playwright MCP Server](https://github.com/microsoft/playwright-mcp)
- [Files MCP Server (OneDrive)](https://github.com/microsoft/files-mcp-server)
- [Azure-Samples MCP](https://github.com/Azure-Samples/mcp)
- [Serveurs MCP Auth (Azure-Samples)](https://github.com/Azure-Samples/mcp-auth-servers)
- [Fonctions MCP distantes (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions)
- [Fonctions MCP distantes Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Fonctions MCP distantes .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Fonctions MCP distantes TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Fonctions MCP APIM distantes Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Solutions Microsoft AI et Automatisation](https://azure.microsoft.com/en-us/products/ai-services/)

## Exercices

1. Analysez une des études de cas et proposez une approche alternative d’implémentation.
2. Choisissez une des idées de projet et rédigez un cahier des charges technique détaillé.
3. Recherchez un secteur non couvert par les études de cas et décrivez comment MCP pourrait répondre à ses défis spécifiques.
4. Explorez une des pistes d’évolution et créez un concept pour une nouvelle extension MCP afin de la soutenir.

Suivant : [Bonnes Pratiques](../08-BestPractices/README.md)

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle humaine est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.