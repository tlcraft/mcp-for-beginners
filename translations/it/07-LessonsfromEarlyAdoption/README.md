<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "296d5c8913271ef3bd696fd46d998711",
  "translation_date": "2025-05-20T21:19:23+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "it"
}
-->
# Lezioni dagli Early Adopters

## Panoramica

Questa lezione esplora come gli early adopters hanno sfruttato il Model Context Protocol (MCP) per risolvere sfide reali e guidare l’innovazione in diversi settori. Attraverso casi di studio dettagliati e progetti pratici, vedrai come MCP consente un’integrazione AI standardizzata, sicura e scalabile—collegando grandi modelli linguistici, strumenti e dati aziendali in un framework unificato. Acquisirai esperienza pratica nella progettazione e costruzione di soluzioni basate su MCP, imparerai da modelli di implementazione consolidati e scoprirai le migliori pratiche per il deployment di MCP in ambienti di produzione. La lezione evidenzia anche le tendenze emergenti, le direzioni future e le risorse open-source per aiutarti a rimanere all’avanguardia nella tecnologia MCP e nel suo ecosistema in evoluzione.

## Obiettivi di Apprendimento

- Analizzare implementazioni reali di MCP in diversi settori
- Progettare e sviluppare applicazioni complete basate su MCP
- Esplorare tendenze emergenti e direzioni future nella tecnologia MCP
- Applicare le migliori pratiche in scenari di sviluppo concreti

## Implementazioni Real-World di MCP

### Caso di Studio 1: Automazione del Supporto Clienti Enterprise

Una multinazionale ha implementato una soluzione basata su MCP per standardizzare le interazioni AI nei loro sistemi di supporto clienti. Questo ha permesso di:

- Creare un’interfaccia unificata per diversi fornitori di LLM
- Mantenere una gestione coerente dei prompt tra i reparti
- Implementare controlli robusti di sicurezza e conformità
- Passare facilmente da un modello AI all’altro in base alle esigenze specifiche

**Implementazione Tecnica:**  
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

**Risultati:** Riduzione del 30% dei costi dei modelli, miglioramento del 45% nella coerenza delle risposte e maggiore conformità nelle operazioni globali.

### Caso di Studio 2: Assistente Diagnostico in Sanità

Un fornitore sanitario ha sviluppato un’infrastruttura MCP per integrare diversi modelli AI medici specializzati, garantendo al contempo la protezione dei dati sensibili dei pazienti:

- Passaggio fluido tra modelli medici generalisti e specialistici
- Controlli rigorosi sulla privacy e tracciabilità degli audit
- Integrazione con i sistemi di Electronic Health Record (EHR) esistenti
- Ingegneria coerente dei prompt per la terminologia medica

**Implementazione Tecnica:**  
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

**Risultati:** Miglioramento delle diagnosi suggerite ai medici mantenendo piena conformità HIPAA e significativa riduzione del cambio di contesto tra sistemi.

### Caso di Studio 3: Analisi del Rischio nei Servizi Finanziari

Un’istituzione finanziaria ha adottato MCP per standardizzare i processi di analisi del rischio tra diversi reparti:

- Creazione di un’interfaccia unificata per modelli di rischio credito, rilevamento frodi e rischio investimenti
- Implementazione di controlli di accesso rigorosi e versioning dei modelli
- Garanzia di auditabilità per tutte le raccomandazioni AI
- Mantenimento di un formato dati coerente tra sistemi diversi

**Implementazione Tecnica:**  
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

**Risultati:** Migliorata conformità regolatoria, cicli di deployment dei modelli più veloci del 40% e maggiore coerenza nelle valutazioni di rischio tra i reparti.

### Caso di Studio 4: Microsoft Playwright MCP Server per l’Automazione Browser

Microsoft ha sviluppato il [Playwright MCP server](https://github.com/microsoft/playwright-mcp) per abilitare un’automazione browser sicura e standardizzata tramite il Model Context Protocol. Questa soluzione consente ad agenti AI e LLM di interagire con i browser web in modo controllato, tracciabile ed estensibile, permettendo casi d’uso come test web automatizzati, estrazione dati e workflow end-to-end.

- Espone funzionalità di automazione browser (navigazione, compilazione form, cattura screenshot, ecc.) come strumenti MCP
- Implementa controlli di accesso rigorosi e sandboxing per evitare azioni non autorizzate
- Fornisce log dettagliati di audit per tutte le interazioni browser
- Supporta integrazione con Azure OpenAI e altri provider LLM per automazione guidata da agenti

**Implementazione Tecnica:**  
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

**Risultati:**  
- Automazione browser programmabile e sicura per agenti AI e LLM  
- Riduzione dello sforzo nei test manuali e miglioramento della copertura dei test web  
- Framework riutilizzabile ed estensibile per l’integrazione di strumenti basati su browser in ambienti enterprise  

**Riferimenti:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Caso di Studio 5: Azure MCP – Model Context Protocol Enterprise-Grade as a Service

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) è l’implementazione gestita e enterprise-grade di Microsoft del Model Context Protocol, progettata per offrire capacità MCP server scalabili, sicure e conformi come servizio cloud. Azure MCP consente alle organizzazioni di distribuire, gestire e integrare rapidamente server MCP con servizi Azure AI, dati e sicurezza, riducendo l’overhead operativo e accelerando l’adozione AI.

- Hosting completamente gestito di server MCP con scaling, monitoraggio e sicurezza integrati
- Integrazione nativa con Azure OpenAI, Azure AI Search e altri servizi Azure
- Autenticazione e autorizzazione enterprise tramite Microsoft Entra ID
- Supporto per strumenti personalizzati, template di prompt e connettori di risorse
- Conformità ai requisiti di sicurezza e regolamentazione enterprise

**Implementazione Tecnica:**  
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

**Risultati:**  
- Riduzione del time-to-value per progetti AI enterprise grazie a una piattaforma MCP pronta all’uso e conforme  
- Integrazione semplificata di LLM, strumenti e fonti dati aziendali  
- Maggiore sicurezza, osservabilità ed efficienza operativa per i workload MCP  

**Riferimenti:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Caso di Studio 6: NLWeb  
MCP (Model Context Protocol) è un protocollo emergente per chatbot e assistenti AI per interagire con strumenti. Ogni istanza NLWeb è anche un server MCP, che supporta un metodo principale, ask, usato per porre domande in linguaggio naturale a un sito web. La risposta restituita utilizza schema.org, un vocabolario ampiamente usato per descrivere dati web. In termini semplici, MCP è per NLWeb ciò che Http è per HTML. NLWeb combina protocolli, formati Schema.org e codice di esempio per aiutare i siti a creare rapidamente questi endpoint, beneficiando sia gli umani tramite interfacce conversazionali sia le macchine tramite interazioni agent-to-agent naturali.

NLWeb si compone di due componenti distinti.  
- Un protocollo, molto semplice da iniziare, per interfacciarsi con un sito in linguaggio naturale e un formato che sfrutta json e schema.org per la risposta restituita. Consulta la documentazione sull’API REST per maggiori dettagli.  
- Un’implementazione semplice di (1) che sfrutta il markup esistente, per siti che possono essere astratti come liste di elementi (prodotti, ricette, attrazioni, recensioni, ecc.). Insieme a una serie di widget per l’interfaccia utente, i siti possono facilmente offrire interfacce conversazionali ai loro contenuti. Consulta la documentazione su Life of a chat query per maggiori dettagli su come funziona.

**Riferimenti:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Caso di Studio 7: MCP per Foundry – Integrazione di Azure AI Agents

I server MCP di Azure AI Foundry mostrano come MCP possa essere usato per orchestrare e gestire agenti AI e workflow in ambienti enterprise. Integrando MCP con Azure AI Foundry, le organizzazioni possono standardizzare le interazioni tra agenti, sfruttare la gestione dei workflow di Foundry e garantire deployment sicuri e scalabili. Questo approccio consente prototipazione rapida, monitoraggio robusto e integrazione fluida con i servizi Azure AI, supportando scenari avanzati come gestione della conoscenza e valutazione degli agenti. Gli sviluppatori beneficiano di un’interfaccia unificata per costruire, distribuire e monitorare pipeline di agenti, mentre i team IT ottengono maggiore sicurezza, conformità ed efficienza operativa. La soluzione è ideale per le aziende che vogliono accelerare l’adozione AI mantenendo il controllo su processi complessi guidati da agenti.

**Riferimenti:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Caso di Studio 8: Foundry MCP Playground – Sperimentazione e Prototipazione

Il Foundry MCP Playground offre un ambiente pronto all’uso per sperimentare con server MCP e integrazioni Azure AI Foundry. Gli sviluppatori possono prototipare, testare e valutare modelli AI e workflow di agenti utilizzando risorse dal catalogo e dai laboratori Azure AI Foundry. Il playground semplifica la configurazione, offre progetti di esempio e supporta lo sviluppo collaborativo, facilitando l’esplorazione di best practice e nuovi scenari con un overhead minimo. È particolarmente utile per team che vogliono validare idee, condividere esperimenti e accelerare l’apprendimento senza infrastrutture complesse. Abbassando la barriera d’ingresso, il playground favorisce innovazione e contributi della community nell’ecosistema MCP e Azure AI Foundry.

**Riferimenti:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

## Progetti Pratici

### Progetto 1: Costruire un Server MCP Multi-Provider

**Obiettivo:** Creare un server MCP che possa indirizzare le richieste a diversi fornitori di modelli AI in base a criteri specifici.

**Requisiti:**  
- Supportare almeno tre diversi provider di modelli (es. OpenAI, Anthropic, modelli locali)  
- Implementare un meccanismo di routing basato sui metadati della richiesta  
- Creare un sistema di configurazione per gestire le credenziali dei provider  
- Aggiungere caching per ottimizzare performance e costi  
- Costruire una dashboard semplice per il monitoraggio dell’uso

**Passi di Implementazione:**  
1. Configurare l’infrastruttura base del server MCP  
2. Implementare gli adapter per ogni servizio modello AI  
3. Creare la logica di routing basata sugli attributi della richiesta  
4. Aggiungere meccanismi di caching per le richieste frequenti  
5. Sviluppare la dashboard di monitoraggio  
6. Testare con diversi pattern di richiesta

**Tecnologie:** Python (.NET/Java/Python a seconda della preferenza), Redis per caching, e un framework web semplice per la dashboard.

### Progetto 2: Sistema Enterprise di Gestione dei Prompt

**Obiettivo:** Sviluppare un sistema basato su MCP per gestire, versionare e distribuire template di prompt in un’organizzazione.

**Requisiti:**  
- Creare un repository centralizzato per i template di prompt  
- Implementare versioning e workflow di approvazione  
- Costruire capacità di test dei template con input di esempio  
- Sviluppare controlli di accesso basati sui ruoli  
- Creare un’API per il recupero e il deployment dei template

**Passi di Implementazione:**  
1. Progettare lo schema del database per lo storage dei template  
2. Creare l’API core per le operazioni CRUD sui template  
3. Implementare il sistema di versioning  
4. Costruire il workflow di approvazione  
5. Sviluppare il framework di testing  
6. Creare una semplice interfaccia web per la gestione  
7. Integrare con un server MCP

**Tecnologie:** Framework backend a scelta, database SQL o NoSQL, e framework frontend per l’interfaccia di gestione.

### Progetto 3: Piattaforma di Generazione Contenuti Basata su MCP

**Obiettivo:** Costruire una piattaforma di generazione contenuti che sfrutti MCP per fornire risultati coerenti su diversi tipi di contenuto.

**Requisiti:**  
- Supportare più formati di contenuto (post blog, social media, copy marketing)  
- Implementare generazione basata su template con opzioni di personalizzazione  
- Creare un sistema di revisione e feedback sui contenuti  
- Tracciare metriche di performance dei contenuti  
- Supportare versioning e iterazione dei contenuti

**Passi di Implementazione:**  
1. Configurare l’infrastruttura client MCP  
2. Creare template per i vari tipi di contenuto  
3. Costruire la pipeline di generazione contenuti  
4. Implementare il sistema di revisione  
5. Sviluppare il sistema di tracciamento metriche  
6. Creare un’interfaccia utente per la gestione template e generazione contenuti

**Tecnologie:** Linguaggio di programmazione preferito, framework web e sistema database.

## Direzioni Future per la Tecnologia MCP

### Tendenze Emergenti

1. **MCP Multi-Modale**  
   - Espansione di MCP per standardizzare le interazioni con modelli di immagini, audio e video  
   - Sviluppo di capacità di ragionamento cross-modale  
   - Formati di prompt standardizzati per diverse modalità

2. **Infrastruttura MCP Federata**  
   - Reti MCP distribuite che condividono risorse tra organizzazioni  
   - Protocolli standardizzati per la condivisione sicura dei modelli  
   - Tecniche di calcolo che preservano la privacy

3. **Marketplace MCP**  
   - Ecosistemi per condividere e monetizzare template e plugin MCP  
   - Processi di certificazione e assicurazione qualità  
   - Integrazione con marketplace di modelli

4. **MCP per Edge Computing**  
   - Adattamento degli standard MCP per dispositivi edge con risorse limitate  
   - Protocolli ottimizzati per ambienti a bassa banda  
   - Implementazioni specializzate MCP per ecosistemi IoT

5. **Quadri Regolatori**  
   - Sviluppo di estensioni MCP per la conformità regolatoria  
   - Tracce di audit standardizzate e interfacce di spiegabilità  
   - Integrazione con framework emergenti di governance AI

### Soluzioni MCP da Microsoft

Microsoft e Azure hanno sviluppato diversi repository open-source per aiutare gli sviluppatori a implementare MCP in vari scenari:

#### Organizzazione Microsoft
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - Server Playwright MCP per automazione e test browser  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - Implementazione server MCP OneDrive per test locali e contributi community  
3. [NLWeb](https://github.com/microsoft/NlWeb) - Collezione di protocolli aperti e strumenti open source, con focus sul layer fondamentale per l’AI Web

#### Organizzazione Azure-Samples
1. [mcp](https://github.com/Azure-Samples/mcp) - Collezione di esempi, strumenti e risorse per costruire e integrare server MCP su Azure in diversi linguaggi  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - Server MCP di riferimento con autenticazione secondo la specifica MCP attuale  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Pagina di atterraggio per implementazioni Remote MCP Server in Azure Functions con link a repo specifici per linguaggi  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Template quickstart per costruire e distribuire Remote MCP Server personalizzati con Azure Functions in Python  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Template quickstart per costruire e distribuire Remote MCP Server personalizzati con Azure Functions in .NET/C#  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Template quickstart per costruire e distribuire Remote MCP Server personalizzati con Azure Functions in TypeScript  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Azure API Management come AI Gateway per Remote MCP Server usando Python  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - Esperimenti APIM ❤️ AI inclusi MCP, con integrazione Azure OpenAI e AI Foundry

Questi repository offrono implementazioni, template e risorse per lavorare con il Model Context Protocol in vari linguaggi di programmazione e servizi Azure. Coprono casi d’uso che vanno da implementazioni base di server ad autenticazione, deployment cloud e integrazione enterprise.

#### Directory Risorse MCP

La [directory MCP Resources](https://github.com/microsoft/mcp/tree/main/Resources) nel repository ufficiale Microsoft MCP offre una raccolta curata di risorse campione, template di prompt e definizioni di strumenti per l’uso con server Model Context Protocol. Questa directory aiuta gli sviluppatori a iniziare rapidamente con MCP offrendo blocchi riutilizzabili e esempi di best practice per:

- **Template di Prompt:** Template pronti all’uso per compiti AI comuni, adattabili per le proprie implementazioni MCP  
- **Definizioni di
- [Documentazione Azure MCP](https://aka.ms/azmcp)
- [Repository GitHub Playwright MCP Server](https://github.com/microsoft/playwright-mcp)
- [Files MCP Server (OneDrive)](https://github.com/microsoft/files-mcp-server)
- [Azure-Samples MCP](https://github.com/Azure-Samples/mcp)
- [MCP Auth Servers (Azure-Samples)](https://github.com/Azure-Samples/mcp-auth-servers)
- [Remote MCP Functions (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions)
- [Remote MCP Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Remote MCP Functions .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Remote MCP Functions TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Soluzioni Microsoft per AI e Automazione](https://azure.microsoft.com/en-us/products/ai-services/)

## Esercizi

1. Analizza uno dei case study e proponi un approccio alternativo di implementazione.
2. Scegli uno dei progetti proposti e crea una specifica tecnica dettagliata.
3. Ricerca un settore non trattato nei case study e descrivi come MCP potrebbe affrontarne le sfide specifiche.
4. Esplora una delle direzioni future e crea un concept per una nuova estensione MCP che la supporti.

Successivo: [Best Practices](../08-BestPractices/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non siamo responsabili per eventuali malintesi o interpretazioni errate derivanti dall’uso di questa traduzione.