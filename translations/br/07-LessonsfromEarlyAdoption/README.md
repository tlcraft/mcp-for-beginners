<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1ccfe1a6ea77e42862b92ae53cb6cddf",
  "translation_date": "2025-05-20T16:50:14+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "br"
}
-->
# Les leçons des premiers adopteurs

## Vue d’ensemble

Cette leçon explore comment les premiers adopteurs ont utilisé le Model Context Protocol (MCP) pour résoudre des défis concrets et stimuler l’innovation dans différents secteurs. À travers des études de cas détaillées et des projets pratiques, vous découvrirez comment MCP permet une intégration IA standardisée, sécurisée et évolutive — reliant grands modèles de langage, outils et données d’entreprise dans un cadre unifié. Vous gagnerez en expérience pratique en concevant et construisant des solutions basées sur MCP, apprendrez des modèles d’implémentation éprouvés et découvrirez les bonnes pratiques pour déployer MCP en production. La leçon met aussi en lumière les tendances émergentes, les orientations futures et les ressources open source pour vous aider à rester à la pointe de la technologie MCP et de son écosystème en évolution.

## Objectifs d’apprentissage

- Analyser des implémentations MCP concrètes dans différents secteurs  
- Concevoir et développer des applications complètes basées sur MCP  
- Explorer les tendances émergentes et les orientations futures de la technologie MCP  
- Appliquer les bonnes pratiques dans des scénarios de développement réels  

## Implémentations MCP dans le monde réel

### Étude de cas 1 : Automatisation du support client en entreprise

Une multinationale a déployé une solution basée sur MCP pour standardiser les interactions IA dans ses systèmes de support client. Cela leur a permis de :

- Créer une interface unifiée pour plusieurs fournisseurs de LLM  
- Maintenir une gestion cohérente des prompts entre les départements  
- Mettre en place des contrôles stricts de sécurité et conformité  
- Basculer facilement entre différents modèles IA selon les besoins spécifiques  

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

**Résultats :** réduction de 30 % des coûts liés aux modèles, amélioration de 45 % de la cohérence des réponses, et renforcement de la conformité à l’échelle mondiale.

### Étude de cas 2 : Assistant de diagnostic en santé

Un prestataire de soins de santé a développé une infrastructure MCP pour intégrer plusieurs modèles IA médicaux spécialisés tout en garantissant la protection des données sensibles des patients :

- Passage fluide entre modèles médicaux généralistes et spécialistes  
- Contrôles de confidentialité stricts et pistes d’audit  
- Intégration avec les systèmes existants de dossiers médicaux électroniques (EHR)  
- Ingénierie des prompts cohérente pour la terminologie médicale  

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

**Résultats :** suggestions diagnostiques améliorées pour les médecins, respect total de la conformité HIPAA et réduction significative des changements de contexte entre systèmes.

### Étude de cas 3 : Analyse des risques dans les services financiers

Une institution financière a adopté MCP pour standardiser ses processus d’analyse des risques à travers plusieurs départements :

- Interface unifiée pour les modèles de risque de crédit, détection de fraude et risque d’investissement  
- Contrôles d’accès stricts et gestion des versions des modèles  
- Auditabilité garantie de toutes les recommandations IA  
- Formatage cohérent des données entre systèmes variés  

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

**Résultats :** conformité réglementaire renforcée, cycles de déploiement des modèles accélérés de 40 %, et meilleure cohérence des évaluations des risques entre départements.

### Étude de cas 4 : Serveur MCP Microsoft Playwright pour l’automatisation navigateur

Microsoft a développé le [serveur Playwright MCP](https://github.com/microsoft/playwright-mcp) pour permettre une automatisation navigateur sécurisée et standardisée via le Model Context Protocol. Cette solution autorise les agents IA et LLM à interagir avec les navigateurs web de manière contrôlée, traçable et extensible — pour des cas d’usage comme les tests web automatisés, l’extraction de données, et les workflows de bout en bout.

- Expose les capacités d’automatisation du navigateur (navigation, remplissage de formulaires, capture d’écran, etc.) en tant qu’outils MCP  
- Implémente des contrôles d’accès stricts et un sandboxing pour éviter les actions non autorisées  
- Fournit des journaux d’audit détaillés pour toutes les interactions navigateur  
- Supporte l’intégration avec Azure OpenAI et autres fournisseurs LLM pour l’automatisation pilotée par agents  

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
- Cadre réutilisable et extensible pour l’intégration d’outils basés sur navigateur en environnement d’entreprise  

**Références :**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Étude de cas 5 : Azure MCP – Model Context Protocol entreprise en tant que service

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) est l’implémentation managée et entreprise du Model Context Protocol par Microsoft, conçue pour offrir des capacités de serveur MCP scalables, sécurisées et conformes en mode cloud. Azure MCP permet aux organisations de déployer, gérer et intégrer rapidement des serveurs MCP avec les services Azure AI, données et sécurité, réduisant ainsi la charge opérationnelle et accélérant l’adoption de l’IA.

- Hébergement managé complet de serveurs MCP avec montée en charge, monitoring et sécurité intégrés  
- Intégration native avec Azure OpenAI, Azure AI Search et autres services Azure  
- Authentification et autorisation d’entreprise via Microsoft Entra ID  
- Support des outils personnalisés, modèles de prompts et connecteurs de ressources  
- Conformité aux exigences de sécurité et réglementaires d’entreprise  

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
- Réduction du time-to-value des projets IA grâce à une plateforme MCP prête à l’emploi et conforme  
- Simplification de l’intégration des LLM, outils et sources de données d’entreprise  
- Sécurité, observabilité et efficacité opérationnelle accrues pour les charges MCP  

**Références :**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Étude de cas 6 : NLWeb

MCP (Model Context Protocol) est un protocole émergent permettant aux chatbots et assistants IA d’interagir avec des outils. Chaque instance NLWeb est aussi un serveur MCP, supportant une méthode principale, ask, utilisée pour poser une question en langage naturel à un site web. La réponse renvoyée utilise schema.org, un vocabulaire largement adopté pour décrire les données web. Pour simplifier, MCP est à NLWeb ce que HTTP est à HTML. NLWeb combine protocoles, formats Schema.org et exemples de code pour aider les sites à créer rapidement ces points d’accès, bénéficiant aux humains via des interfaces conversationnelles et aux machines via des interactions agent-à-agent naturelles.

NLWeb se compose de deux éléments distincts :  
- Un protocole très simple pour interagir en langage naturel avec un site et un format s’appuyant sur json et schema.org pour la réponse. Voir la documentation REST API pour plus de détails.  
- Une implémentation simple de (1) qui exploite le balisage existant, pour les sites pouvant être vus comme des listes d’éléments (produits, recettes, attractions, avis, etc.). Avec un ensemble de widgets d’interface utilisateur, les sites peuvent facilement proposer des interfaces conversationnelles à leur contenu. Voir la documentation Life of a chat query pour comprendre le fonctionnement.  

**Références :**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Étude de cas 7 : MCP pour Foundry – Intégration des agents Azure AI

Les serveurs Azure AI Foundry MCP montrent comment MCP peut orchestrer et gérer agents IA et workflows en environnement d’entreprise. En intégrant MCP avec Azure AI Foundry, les organisations standardisent les interactions agents, tirent parti de la gestion des workflows de Foundry, et garantissent des déploiements sécurisés et scalables. Cette approche permet le prototypage rapide, un monitoring robuste, et une intégration fluide avec les services Azure AI, supportant des scénarios avancés comme la gestion des connaissances et l’évaluation des agents. Les développeurs bénéficient d’une interface unifiée pour construire, déployer et superviser les pipelines d’agents, tandis que les équipes IT gagnent en sécurité, conformité et efficacité opérationnelle. La solution est idéale pour les entreprises souhaitant accélérer l’adoption de l’IA tout en gardant le contrôle sur des processus complexes pilotés par agents.

**Références :**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Étude de cas 8 : Foundry MCP Playground – Expérimentation et prototypage

Le Foundry MCP Playground offre un environnement prêt à l’emploi pour expérimenter avec les serveurs MCP et les intégrations Azure AI Foundry. Les développeurs peuvent rapidement prototyper, tester et évaluer modèles IA et workflows agents à partir des ressources du catalogue et des labs Azure AI Foundry. Le playground simplifie la mise en place, propose des projets exemples, et soutient le développement collaboratif, facilitant l’exploration des bonnes pratiques et de nouveaux scénarios avec un minimum de contraintes. Il est particulièrement utile pour les équipes souhaitant valider des idées, partager leurs expériences, et accélérer l’apprentissage sans infrastructure complexe. En abaissant la barrière à l’entrée, le playground favorise l’innovation et les contributions communautaires dans l’écosystème MCP et Azure AI Foundry.

**Références :**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

## Projets pratiques

### Projet 1 : Construire un serveur MCP multi-fournisseurs

**Objectif :** Créer un serveur MCP capable de router les requêtes vers plusieurs fournisseurs de modèles IA selon des critères spécifiques.

**Exigences :**  
- Supporter au moins trois fournisseurs de modèles différents (ex. OpenAI, Anthropic, modèles locaux)  
- Implémenter un mécanisme de routage basé sur les métadonnées des requêtes  
- Créer un système de configuration pour gérer les identifiants fournisseurs  
- Ajouter un cache pour optimiser performances et coûts  
- Construire un tableau de bord simple pour le suivi de l’utilisation  

**Étapes de mise en œuvre :**  
1. Mettre en place l’infrastructure serveur MCP de base  
2. Implémenter les adaptateurs fournisseurs pour chaque service de modèle IA  
3. Créer la logique de routage basée sur les attributs des requêtes  
4. Ajouter les mécanismes de cache pour les requêtes fréquentes  
5. Développer le tableau de bord de monitoring  
6. Tester avec différents profils de requêtes  

**Technologies :** Choix entre Python (.NET/Java/Python selon préférence), Redis pour le cache, et un framework web simple pour le tableau de bord.

### Projet 2 : Système d’administration centralisée des prompts en entreprise

**Objectif :** Développer un système MCP pour gérer, versionner et déployer des modèles de prompts dans une organisation.

**Exigences :**  
- Créer un dépôt centralisé pour les modèles de prompts  
- Mettre en place un système de versioning et workflows d’approbation  
- Construire des capacités de test des templates avec exemples d’entrées  
- Développer des contrôles d’accès basés sur les rôles  
- Créer une API pour la récupération et le déploiement des templates  

**Étapes de mise en œuvre :**  
1. Concevoir le schéma de base de données pour stocker les templates  
2. Créer l’API principale pour les opérations CRUD sur les templates  
3. Implémenter le système de versioning  
4. Construire le workflow d’approbation  
5. Développer le framework de test  
6. Créer une interface web simple pour la gestion  
7. Intégrer avec un serveur MCP  

**Technologies :** Choix libre du framework backend, base SQL ou NoSQL, et framework frontend pour l’interface.

### Projet 3 : Plateforme de génération de contenu basée sur MCP

**Objectif :** Construire une plateforme de génération de contenu utilisant MCP pour garantir des résultats cohérents sur différents types de contenu.

**Exigences :**  
- Supporter plusieurs formats de contenu (articles de blog, réseaux sociaux, textes marketing)  
- Implémenter une génération basée sur templates avec options de personnalisation  
- Créer un système de revue et feedback du contenu  
- Suivre les métriques de performance du contenu  
- Supporter le versioning et l’itération des contenus  

**Étapes de mise en œuvre :**  
1. Mettre en place l’infrastructure client MCP  
2. Créer les templates pour chaque type de contenu  
3. Construire la chaîne de génération de contenu  
4. Implémenter le système de revue  
5. Développer le suivi des métriques  
6. Créer une interface utilisateur pour la gestion des templates et la génération  

**Technologies :** Langage de programmation, framework web et base de données au choix.

## Orientations futures de la technologie MCP

### Tendances émergentes

1. **MCP multimodal**  
   - Extension de MCP pour standardiser les interactions avec modèles image, audio et vidéo  
   - Développement de capacités de raisonnement intermodal  
   - Formats de prompts standardisés pour différentes modalités  

2. **Infrastructure MCP fédérée**  
   - Réseaux MCP distribués partageant ressources entre organisations  
   - Protocoles standardisés pour le partage sécurisé de modèles  
   - Techniques de calcul préservant la confidentialité  

3. **Marchés MCP**  
   - Écosystèmes pour partager et monétiser templates et plugins MCP  
   - Processus d’assurance qualité et certification  
   - Intégration avec les marketplaces de modèles  

4. **MCP pour edge computing**  
   - Adaptation des standards MCP aux appareils edge à ressources limitées  
   - Protocoles optimisés pour environnements à faible bande passante  
   - Implémentations spécialisées pour écosystèmes IoT  

5. **Cadres réglementaires**  
   - Développement d’extensions MCP pour conformité réglementaire  
   - Pistes d’audit standardisées et interfaces d’explicabilité  
   - Intégration avec les cadres émergents de gouvernance IA  

### Solutions MCP de Microsoft

Microsoft et Azure ont développé plusieurs dépôts open source pour aider les développeurs à implémenter MCP dans divers scénarios :

#### Organisation Microsoft  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) – Serveur Playwright MCP pour automatisation et tests navigateur  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) – Implémentation serveur MCP OneDrive pour tests locaux et contributions communautaires  
3. [NLWeb](https://github.com/microsoft/NlWeb) – Collection de protocoles ouverts et outils open source, visant à établir une couche fondamentale pour le Web IA  

#### Organisation Azure-Samples  
1. [mcp](https://github.com/Azure-Samples/mcp) – Exemples, outils et ressources pour construire et intégrer des serveurs MCP sur Azure avec plusieurs langages  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) – Serveurs MCP de référence démontrant l’authentification selon la spécification actuelle MCP  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) – Page d’accueil des implémentations Remote MCP Server en Azure Functions avec liens vers repos par langage  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) – Template quickstart pour construire et déployer des serveurs MCP distants personnalisés en Python avec Azure Functions  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) – Template quickstart pour serveurs MCP distants personnalisés en .NET/C# avec Azure Functions  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) – Template quickstart pour serveurs MCP distants personnalisés en TypeScript avec Azure Functions  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) – Azure API Management comme passerelle IA vers serveurs MCP distants en Python  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) – Expériences APIM ❤️ IA incluant capacités MCP, intégration avec Azure OpenAI et AI Foundry  

Ces dépôts offrent diverses implémentations, templates et ressources pour travailler avec le Model Context Protocol dans plusieurs langages et services Azure. Ils couvrent un large éventail de cas d’usage, des serveurs basiques à l’authentification, déploiement cloud et intégration entreprise.

#### Répertoire de ressources MCP

Le [répertoire MCP Resources](https://github.com/microsoft/mcp/tree/main/Resources) dans le dépôt officiel Microsoft MCP fournit une collection sélectionnée d’exemples de ressources, modèles de prompts et définitions d’outils pour une utilisation avec les serveurs Model Context Protocol. Ce répertoire aide les développeurs à démarrer rapidement avec MCP en proposant des blocs réutilisables et des exemples de bonnes pratiques pour :

- **Modèles de prompts :** Templates prêts à l’emploi pour tâches et scénarios IA courants, adaptables à vos implémentations MCP  
- **Définitions d’outils :** Schémas et métadonnées d’exemple pour standardiser l’intégration et l’appel d’outils dans différents serveurs MCP  
- **Exemples de ressources :** Définitions de ressources pour connecter sources de données, API et services externes dans le cadre MCP  
- **Implémentations de référence :** Exemples pratiques montrant comment structurer et organiser ressources, prompts et outils dans des projets MCP réels  

Ces ressources accélèrent le développement, favorisent la standardisation et assurent les bonnes pratiques lors de la construction et du déploiement de solutions basées sur MCP.

#### Répertoire MCP Resources  
- [MCP Resources (exemples de prompts, outils et définitions de ressources)](https://github.com/microsoft/mcp/tree/main/Resources)

### Opportunités de recherche

- Techniques efficaces d’optim
- [Azure MCP Documentation](https://aka.ms/azmcp)
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)
- [Files MCP Server (OneDrive)](https://github.com/microsoft/files-mcp-server)
- [Azure-Samples MCP](https://github.com/Azure-Samples/mcp)
- [MCP Auth Servers (Azure-Samples)](https://github.com/Azure-Samples/mcp-auth-servers)
- [Remote MCP Functions (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions)
- [Remote MCP Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Remote MCP Functions .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Remote MCP Functions TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

## Exercícios

1. Analise um dos estudos de caso e proponha uma abordagem alternativa de implementação.
2. Escolha uma das ideias de projeto e crie uma especificação técnica detalhada.
3. Pesquise um setor que não foi abordado nos estudos de caso e descreva como o MCP poderia solucionar seus desafios específicos.
4. Explore uma das direções futuras e crie um conceito para uma nova extensão MCP que a suporte.

Próximo: [Best Practices](../08-BestPractices/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional feita por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações equivocadas decorrentes do uso desta tradução.