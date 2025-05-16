<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a6482c201133cb6cb0742918b373a523",
  "translation_date": "2025-05-16T14:49:40+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "de"
}
-->
# Lektionen von Early Adopters

## Überblick

Diese Lektion zeigt, wie Early Adopters das Model Context Protocol (MCP) genutzt haben, um reale Herausforderungen zu meistern und Innovationen in verschiedenen Branchen voranzutreiben. Anhand detaillierter Fallstudien und praktischer Projekte sehen Sie, wie MCP eine standardisierte, sichere und skalierbare KI-Integration ermöglicht – indem große Sprachmodelle, Tools und Unternehmensdaten in einem einheitlichen Rahmen verbunden werden. Sie sammeln praktische Erfahrungen beim Entwerfen und Erstellen von MCP-basierten Lösungen, lernen bewährte Implementierungsmuster kennen und entdecken Best Practices für den produktiven Einsatz von MCP. Die Lektion hebt außerdem aufkommende Trends, zukünftige Entwicklungen und Open-Source-Ressourcen hervor, damit Sie immer am Puls der MCP-Technologie und ihres sich entwickelnden Ökosystems bleiben.

## Lernziele

- Analyse realer MCP-Implementierungen in verschiedenen Branchen
- Entwurf und Entwicklung vollständiger MCP-basierter Anwendungen
- Erkundung neuer Trends und zukünftiger Richtungen in der MCP-Technologie
- Anwendung bewährter Praktiken in realen Entwicklungsszenarien

## Reale MCP-Implementierungen

### Fallstudie 1: Automatisierung des Enterprise-Kundensupports

Ein multinationales Unternehmen implementierte eine MCP-basierte Lösung, um KI-Interaktionen über ihre Kundensupportsysteme hinweg zu standardisieren. Dadurch konnten sie:

- Eine einheitliche Schnittstelle für mehrere LLM-Anbieter schaffen
- Einheitliches Prompt-Management über Abteilungen hinweg gewährleisten
- Robuste Sicherheits- und Compliance-Kontrollen implementieren
- Einfach zwischen verschiedenen KI-Modellen je nach Bedarf wechseln

**Technische Implementierung:**  
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

**Ergebnisse:** 30 % Kostenreduktion bei Modellen, 45 % Verbesserung der Antwortkonsistenz und verbesserte Compliance in globalen Abläufen.

### Fallstudie 2: Diagnostischer Assistent im Gesundheitswesen

Ein Gesundheitsdienstleister entwickelte eine MCP-Infrastruktur, um mehrere spezialisierte medizinische KI-Modelle zu integrieren und gleichzeitig sensible Patientendaten zu schützen:

- Nahtloser Wechsel zwischen generalistischen und spezialisierten medizinischen Modellen
- Strenge Datenschutzkontrollen und Audit-Trails
- Integration mit bestehenden Electronic Health Record (EHR)-Systemen
- Konsistente Prompt-Gestaltung für medizinische Terminologie

**Technische Implementierung:**  
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

**Ergebnisse:** Verbesserte Diagnostikvorschläge für Ärzte bei voller HIPAA-Konformität und deutliche Reduzierung des Kontextwechsels zwischen Systemen.

### Fallstudie 3: Risikoanalyse im Finanzsektor

Eine Finanzinstitution setzte MCP ein, um ihre Risikoanalyseprozesse in verschiedenen Abteilungen zu standardisieren:

- Einheitliche Schnittstelle für Kreditrisiko-, Betrugserkennungs- und Investitionsrisikomodelle geschaffen
- Strenge Zugriffskontrollen und Modellversionierung implementiert
- Auditierbarkeit aller KI-Empfehlungen sichergestellt
- Einheitliche Datenformate über diverse Systeme hinweg aufrechterhalten

**Technische Implementierung:**  
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

**Ergebnisse:** Verbesserte regulatorische Compliance, 40 % schnellere Modellentwicklungszyklen und gesteigerte Konsistenz bei der Risikoabschätzung in den Abteilungen.

### Fallstudie 4: Microsoft Playwright MCP Server für Browser-Automatisierung

Microsoft entwickelte den [Playwright MCP server](https://github.com/microsoft/playwright-mcp), um sichere, standardisierte Browser-Automatisierung über das Model Context Protocol zu ermöglichen. Diese Lösung erlaubt es KI-Agenten und LLMs, kontrolliert, prüfbar und erweiterbar mit Webbrowsern zu interagieren – für Anwendungsfälle wie automatisiertes Web-Testing, Datenerfassung und End-to-End-Workflows.

- Stellt Browser-Automatisierungsfunktionen (Navigation, Formularausfüllung, Screenshot-Erfassung usw.) als MCP-Tools bereit
- Implementiert strenge Zugriffskontrollen und Sandboxing zum Schutz vor unbefugten Aktionen
- Liefert detaillierte Audit-Logs für alle Browser-Interaktionen
- Unterstützt Integration mit Azure OpenAI und anderen LLM-Anbietern für agentengesteuerte Automatisierung

**Technische Implementierung:**  
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

**Ergebnisse:**  
- Ermöglichte sichere, programmatische Browser-Automatisierung für KI-Agenten und LLMs  
- Reduzierte manuellen Testaufwand und verbesserte Testabdeckung für Webanwendungen  
- Bietet ein wiederverwendbares, erweiterbares Framework zur Integration browserbasierter Tools in Unternehmensumgebungen

**Verweise:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Fallstudie 5: Azure MCP – Enterprise-Grade Model Context Protocol as a Service

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) ist Microsofts verwaltete, unternehmensgerechte Implementierung des Model Context Protocol, entwickelt, um skalierbare, sichere und konforme MCP-Server-Funktionalitäten als Cloud-Service bereitzustellen. Azure MCP ermöglicht Organisationen, MCP-Server schnell bereitzustellen, zu verwalten und mit Azure AI-, Daten- und Sicherheitsdiensten zu integrieren, wodurch der Betriebsaufwand reduziert und die KI-Einführung beschleunigt wird.

- Vollständig verwaltetes MCP-Server-Hosting mit integrierter Skalierung, Überwachung und Sicherheit  
- Native Integration mit Azure OpenAI, Azure AI Search und anderen Azure-Diensten  
- Unternehmensauthentifizierung und -autorisierung über Microsoft Entra ID  
- Unterstützung für benutzerdefinierte Tools, Prompt-Vorlagen und Ressourcen-Connectoren  
- Einhaltung von Unternehmenssicherheits- und regulatorischen Anforderungen

**Technische Implementierung:**  
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

**Ergebnisse:**  
- Verkürzte Time-to-Value für Unternehmens-KI-Projekte durch eine sofort einsatzbereite, konforme MCP-Server-Plattform  
- Vereinfachte Integration von LLMs, Tools und Unternehmensdatenquellen  
- Verbesserte Sicherheit, Beobachtbarkeit und Betriebseffizienz für MCP-Workloads

**Verweise:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Praktische Projekte

### Projekt 1: Aufbau eines Multi-Provider MCP Servers

**Ziel:** Erstellen Sie einen MCP-Server, der Anfragen basierend auf bestimmten Kriterien an mehrere KI-Modell-Anbieter weiterleitet.

**Anforderungen:**  
- Unterstützung von mindestens drei verschiedenen Modellanbietern (z. B. OpenAI, Anthropic, lokale Modelle)  
- Implementierung eines Routing-Mechanismus basierend auf Anfragemetadaten  
- Erstellung eines Konfigurationssystems zur Verwaltung von Anbieter-Credentials  
- Hinzufügen von Caching zur Optimierung von Leistung und Kosten  
- Aufbau eines einfachen Dashboards zur Überwachung der Nutzung

**Implementierungsschritte:**  
1. Grundlegende MCP-Server-Infrastruktur einrichten  
2. Provider-Adapter für jeden KI-Modell-Dienst implementieren  
3. Routing-Logik basierend auf Anfrageattributen erstellen  
4. Caching-Mechanismen für häufige Anfragen hinzufügen  
5. Überwachungs-Dashboard entwickeln  
6. Tests mit verschiedenen Anfrage-Mustern durchführen

**Technologien:** Wählen Sie aus Python (.NET/Java/Python je nach Präferenz), Redis für Caching und einem einfachen Web-Framework für das Dashboard.

### Projekt 2: Enterprise Prompt Management System

**Ziel:** Entwickeln Sie ein MCP-basiertes System zur Verwaltung, Versionierung und Bereitstellung von Prompt-Vorlagen in einer Organisation.

**Anforderungen:**  
- Zentrale Ablage für Prompt-Vorlagen erstellen  
- Versionierung und Genehmigungs-Workflows implementieren  
- Testmöglichkeiten für Vorlagen mit Beispiel-Eingaben entwickeln  
- Rollenbasierte Zugriffskontrollen umsetzen  
- API zur Vorlagenabfrage und -bereitstellung erstellen

**Implementierungsschritte:**  
1. Datenbankschema für Vorlagen-Speicherung entwerfen  
2. Kern-API für CRUD-Operationen an Vorlagen erstellen  
3. Versionierungssystem implementieren  
4. Genehmigungs-Workflow aufbauen  
5. Testframework entwickeln  
6. Einfache Web-Oberfläche für Verwaltung erstellen  
7. Integration mit einem MCP-Server

**Technologien:** Wahl des Backend-Frameworks, SQL- oder NoSQL-Datenbank und Frontend-Framework für die Verwaltungsoberfläche.

### Projekt 3: MCP-basierte Content-Generierungsplattform

**Ziel:** Erstellen Sie eine Plattform zur Content-Erstellung, die MCP nutzt, um konsistente Ergebnisse für verschiedene Content-Typen zu liefern.

**Anforderungen:**  
- Unterstützung mehrerer Content-Formate (Blogbeiträge, Social Media, Marketingtexte)  
- Template-basierte Generierung mit Anpassungsmöglichkeiten  
- System zur Content-Überprüfung und Feedback  
- Tracking von Content-Performance-Metriken  
- Unterstützung von Content-Versionierung und Iteration

**Implementierungsschritte:**  
1. MCP-Client-Infrastruktur aufbauen  
2. Templates für verschiedene Content-Typen erstellen  
3. Content-Generierungspipeline entwickeln  
4. Review-System implementieren  
5. Metrik-Tracking-System entwickeln  
6. Benutzeroberfläche für Template-Verwaltung und Content-Erstellung gestalten

**Technologien:** Bevorzugte Programmiersprache, Web-Framework und Datenbanksystem.

## Zukunftsaussichten für die MCP-Technologie

### Aufkommende Trends

1. **Multi-Modal MCP**  
   - Erweiterung von MCP zur Standardisierung der Interaktion mit Bild-, Audio- und Videomodellen  
   - Entwicklung von cross-modalem Reasoning  
   - Standardisierte Prompt-Formate für verschiedene Modalitäten

2. **Föderierte MCP-Infrastruktur**  
   - Verteilte MCP-Netzwerke, die Ressourcen organisationsübergreifend teilen können  
   - Standardisierte Protokolle für sicheren Modell-Austausch  
   - Datenschutzwahrende Berechnungstechniken

3. **MCP-Marktplätze**  
   - Ökosysteme zum Teilen und Monetarisieren von MCP-Vorlagen und Plugins  
   - Qualitätssicherung und Zertifizierungsprozesse  
   - Integration mit Modell-Marktplätzen

4. **MCP für Edge Computing**  
   - Anpassung der MCP-Standards für ressourcenbeschränkte Edge-Geräte  
   - Optimierte Protokolle für Umgebungen mit geringer Bandbreite  
   - Spezialisierte MCP-Implementierungen für IoT-Ökosysteme

5. **Regulatorische Rahmenwerke**  
   - Entwicklung von MCP-Erweiterungen für regulatorische Compliance  
   - Standardisierte Audit-Trails und Erklärbarkeits-Schnittstellen  
   - Integration mit aufkommenden AI-Governance-Rahmenwerken

### MCP-Lösungen von Microsoft

Microsoft und Azure haben mehrere Open-Source-Repositories entwickelt, die Entwicklern helfen, MCP in verschiedenen Szenarien umzusetzen:

#### Microsoft-Organisation  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) – Ein Playwright MCP-Server für Browser-Automatisierung und Testing  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) – OneDrive MCP-Server-Implementierung für lokale Tests und Community-Beiträge

#### Azure-Samples-Organisation  
1. [mcp](https://github.com/Azure-Samples/mcp) – Links zu Beispielen, Tools und Ressourcen für den Aufbau und die Integration von MCP-Servern auf Azure in verschiedenen Sprachen  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) – Referenz-MCP-Server, die Authentifizierung mit der aktuellen Model Context Protocol-Spezifikation demonstrieren  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) – Landingpage für Remote MCP Server-Implementierungen in Azure Functions mit Links zu sprachspezifischen Repositories  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) – Quickstart-Vorlage für den Aufbau und die Bereitstellung von Remote MCP-Servern mit Azure Functions in Python  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) – Quickstart-Vorlage für Remote MCP-Server mit Azure Functions in .NET/C#  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) – Quickstart-Vorlage für Remote MCP-Server mit Azure Functions in TypeScript  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) – Azure API Management als AI-Gateway für Remote MCP-Server mit Python  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) – APIM ❤️ AI-Experimente inklusive MCP-Funktionalitäten, Integration mit Azure OpenAI und AI Foundry

Diese Repositories bieten verschiedene Implementierungen, Vorlagen und Ressourcen zur Arbeit mit dem Model Context Protocol in unterschiedlichen Programmiersprachen und Azure-Diensten. Sie decken Anwendungsfälle von einfachen Server-Implementierungen über Authentifizierung, Cloud-Bereitstellung bis hin zu Unternehmensintegrationen ab.

#### MCP Resources Directory

Das [MCP Resources Directory](https://github.com/microsoft/mcp/tree/main/Resources) im offiziellen Microsoft MCP-Repository bietet eine kuratierte Sammlung von Beispielressourcen, Prompt-Vorlagen und Tool-Definitionen für den Einsatz mit MCP-Servern. Dieses Verzeichnis soll Entwicklern den schnellen Einstieg in MCP erleichtern, indem es wiederverwendbare Bausteine und Best-Practice-Beispiele bereitstellt für:

- **Prompt-Vorlagen:** Fertige Vorlagen für gängige KI-Aufgaben und Szenarien, die an eigene MCP-Server-Implementierungen angepasst werden können  
- **Tool-Definitionen:** Beispielhafte Tool-Schemata und Metadaten zur Standardisierung von Tool-Integration und -Aufrufen über verschiedene MCP-Server hinweg  
- **Ressourcen-Beispiele:** Beispielhafte Ressourcendefinitionen zur Anbindung von Datenquellen, APIs und externen Diensten innerhalb des MCP-Rahmens  
- **Referenzimplementierungen:** Praktische Beispiele, die zeigen, wie Ressourcen, Prompts und Tools in realen MCP-Projekten strukturiert und organisiert werden

Diese Ressourcen beschleunigen die Entwicklung, fördern die Standardisierung und unterstützen Best Practices beim Aufbau und der Bereitstellung MCP-basierter Lösungen.

#### MCP Resources Directory  
- [MCP Resources (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)

### Forschungspotenziale

- Effiziente Prompt-Optimierungstechniken innerhalb von MCP-Frameworks  
- Sicherheitsmodelle für Multi-Tenant-MCP-Deployments  
- Performance-Benchmarking verschiedener MCP-Implementierungen  
- Formale Verifikationsmethoden für MCP-Server

## Fazit

Das Model Context Protocol (MCP) gestaltet die Zukunft der standardisierten, sicheren und interoperablen KI-Integration branchenübergreifend maßgeblich mit. Anhand der Fallstudien und praktischen Projekte in dieser Lektion haben Sie gesehen, wie Early Adopters – darunter Microsoft und Azure – MCP nutzen, um reale Herausforderungen zu lösen, die KI-Einführung zu beschleunigen und Compliance, Sicherheit sowie Skalierbarkeit zu gewährleisten. Der modulare Ansatz von MCP ermöglicht es Organisationen, große Sprachmodelle, Tools und Unternehmensdaten in einem einheitlichen, prüfbaren Rahmen zu verbinden. Während MCP sich weiterentwickelt, ist die aktive Beteiligung an der Community, die Nutzung von Open-Source-Ressourcen und die Anwendung bewährter Praktiken entscheidend, um robuste und zukunftssichere KI-Lösungen zu bauen.

## Zusätzliche Ressourcen

- [MCP GitHub Repository (Microsoft)](https://github.com/microsoft/mcp)  
- [MCP Resources Directory (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)  
- [MCP Community & Documentation](https://modelcontextprotocol.io/introduction)  
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

## Übungen

1. Analysiere eine der Fallstudien und schlage einen alternativen Implementierungsansatz vor.
2. Wähle eine der Projektideen aus und erstelle eine detaillierte technische Spezifikation.
3. Recherchiere eine Branche, die in den Fallstudien nicht behandelt wird, und skizziere, wie MCP deren spezifische Herausforderungen angehen könnte.
4. Erkunde eine der zukünftigen Richtungen und entwickle ein Konzept für eine neue MCP-Erweiterung zur Unterstützung dieser.

Weiter: [Best Practices](../08-BestPractices/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir auf Genauigkeit achten, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.