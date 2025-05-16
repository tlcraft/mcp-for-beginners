<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "056918462dca9b8f75901709fb8f470c",
  "translation_date": "2025-05-16T15:45:33+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "de"
}
-->
# 📖 MCP Kernkonzepte: Das Model Context Protocol für die KI-Integration meistern

Das Model Context Protocol (MCP) ist ein leistungsstarkes, standardisiertes Framework, das die Kommunikation zwischen Large Language Models (LLMs) und externen Werkzeugen, Anwendungen und Datenquellen optimiert. Dieser SEO-optimierte Leitfaden führt Sie durch die Kernkonzepte von MCP, damit Sie die Client-Server-Architektur, die wesentlichen Komponenten, die Kommunikationsmechanismen und bewährte Implementierungspraktiken verstehen.

## Überblick

Diese Lektion behandelt die grundlegende Architektur und die Komponenten, die das MCP-Ökosystem ausmachen. Sie lernen die Client-Server-Architektur, die wichtigsten Bausteine und die Kommunikationsmechanismen kennen, die MCP-Interaktionen ermöglichen.

## 👩‍🎓 Wichtige Lernziele

Am Ende dieser Lektion werden Sie:

- Die MCP Client-Server-Architektur verstehen.
- Die Rollen und Verantwortlichkeiten von Hosts, Clients und Servern identifizieren.
- Die Kernfunktionen analysieren, die MCP zu einer flexiblen Integrationsschicht machen.
- Lernen, wie Informationen im MCP-Ökosystem fließen.
- Praktische Einblicke durch Codebeispiele in .NET, Java, Python und JavaScript gewinnen.

## 🔎 MCP Architektur: Ein genauerer Blick

Das MCP-Ökosystem basiert auf einem Client-Server-Modell. Diese modulare Struktur ermöglicht es KI-Anwendungen, effizient mit Werkzeugen, Datenbanken, APIs und kontextuellen Ressourcen zu interagieren. Lassen Sie uns diese Architektur in ihre Kernkomponenten zerlegen.

### 1. Hosts

Im Model Context Protocol (MCP) spielen Hosts eine entscheidende Rolle als primäre Schnittstelle, über die Nutzer mit dem Protokoll interagieren. Hosts sind Anwendungen oder Umgebungen, die Verbindungen zu MCP-Servern herstellen, um auf Daten, Werkzeuge und Prompts zuzugreifen. Beispiele für Hosts sind integrierte Entwicklungsumgebungen (IDEs) wie Visual Studio Code, KI-Tools wie Claude Desktop oder speziell entwickelte Agenten für bestimmte Aufgaben.

**Hosts** sind LLM-Anwendungen, die Verbindungen initiieren. Sie:

- Führen KI-Modelle aus oder interagieren mit ihnen, um Antworten zu generieren.
- Stellen Verbindungen zu MCP-Servern her.
- Steuern den Gesprächsverlauf und die Benutzeroberfläche.
- Kontrollieren Berechtigungen und Sicherheitsbeschränkungen.
- Verwalten die Zustimmung der Nutzer zur Datenfreigabe und Werkzeugausführung.

### 2. Clients

Clients sind wichtige Komponenten, die die Interaktion zwischen Hosts und MCP-Servern ermöglichen. Clients fungieren als Vermittler, die Hosts den Zugriff auf die Funktionen der MCP-Server erlauben. Sie spielen eine zentrale Rolle für eine reibungslose Kommunikation und einen effizienten Datenaustausch innerhalb der MCP-Architektur.

**Clients** sind Connectoren innerhalb der Host-Anwendung. Sie:

- Senden Anfragen mit Prompts oder Anweisungen an Server.
- Verhandeln Fähigkeiten mit den Servern.
- Verwalten Ausführungsanfragen von Werkzeugen, die vom Modell kommen.
- Verarbeiten und zeigen Antworten für die Nutzer an.

### 3. Server

Server sind verantwortlich für die Bearbeitung von Anfragen der MCP-Clients und die Bereitstellung entsprechender Antworten. Sie verwalten verschiedene Operationen wie Datenabruf, Werkzeugausführung und Prompt-Generierung. Server sorgen dafür, dass die Kommunikation zwischen Clients und Hosts effizient und zuverlässig ist und erhalten die Integrität des Interaktionsprozesses.

**Server** sind Dienste, die Kontext und Funktionen bereitstellen. Sie:

- Registrieren verfügbare Funktionen (Ressourcen, Prompts, Werkzeuge).
- Empfangen und führen Werkzeugaufrufe vom Client aus.
- Stellen kontextuelle Informationen bereit, um Modellantworten zu verbessern.
- Liefern Ergebnisse zurück an den Client.
- Bewahren bei Bedarf den Zustand über mehrere Interaktionen hinweg.

Server können von jedem entwickelt werden, um die Modellfähigkeiten mit spezialisierten Funktionen zu erweitern.

### 4. Serverfunktionen

Server im Model Context Protocol (MCP) bieten grundlegende Bausteine, die reiche Interaktionen zwischen Clients, Hosts und Sprachmodellen ermöglichen. Diese Funktionen sind darauf ausgelegt, die Fähigkeiten von MCP durch strukturierte Kontexte, Werkzeuge und Prompts zu erweitern.

MCP-Server können folgende Funktionen anbieten:

#### 📑 Ressourcen

Ressourcen im Model Context Protocol (MCP) umfassen verschiedene Arten von Kontext und Daten, die von Nutzern oder KI-Modellen genutzt werden können. Dazu gehören:

- **Kontextuelle Daten**: Informationen und Kontext, die Nutzer oder KI-Modelle für Entscheidungsfindung und Aufgabenausführung nutzen können.
- **Wissensdatenbanken und Dokumentenarchive**: Sammlungen strukturierter und unstrukturierter Daten, wie Artikel, Handbücher und Forschungsarbeiten, die wertvolle Einblicke und Informationen bieten.
- **Lokale Dateien und Datenbanken**: Daten, die lokal auf Geräten oder in Datenbanken gespeichert sind und für Verarbeitung und Analyse zugänglich sind.
- **APIs und Webdienste**: Externe Schnittstellen und Dienste, die zusätzliche Daten und Funktionen bereitstellen und die Integration mit verschiedenen Online-Ressourcen und Werkzeugen ermöglichen.

Ein Beispiel für eine Ressource kann ein Datenbankschema oder eine Datei sein, auf die so zugegriffen wird:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Prompts im Model Context Protocol (MCP) umfassen verschiedene vordefinierte Vorlagen und Interaktionsmuster, die darauf ausgelegt sind, Arbeitsabläufe der Nutzer zu vereinfachen und die Kommunikation zu verbessern. Dazu gehören:

- **Vorstrukturierte Nachrichten und Workflows**: Vorgefertigte Nachrichten und Abläufe, die Nutzer durch bestimmte Aufgaben und Interaktionen führen.
- **Vordefinierte Interaktionsmuster**: Standardisierte Aktions- und Antwortsequenzen, die eine konsistente und effiziente Kommunikation fördern.
- **Spezialisierte Gesprächsvorlagen**: Anpassbare Vorlagen, die für bestimmte Gesprächsarten optimiert sind und relevante sowie kontextuell passende Interaktionen sicherstellen.

Eine Prompt-Vorlage kann beispielsweise so aussehen:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Werkzeuge

Werkzeuge im Model Context Protocol (MCP) sind Funktionen, die das KI-Modell ausführen kann, um bestimmte Aufgaben zu erledigen. Diese Werkzeuge sollen die Fähigkeiten des Modells durch strukturierte und verlässliche Operationen erweitern. Wichtige Aspekte sind:

- **Funktionen, die das KI-Modell ausführen kann**: Werkzeuge sind ausführbare Funktionen, die das Modell aufrufen kann, um verschiedene Aufgaben zu erledigen.
- **Einzigartiger Name und Beschreibung**: Jedes Werkzeug hat einen eindeutigen Namen und eine ausführliche Beschreibung, die Zweck und Funktion erklären.
- **Parameter und Ausgaben**: Werkzeuge akzeptieren spezifische Parameter und liefern strukturierte Ausgaben, um konsistente und vorhersehbare Ergebnisse zu gewährleisten.
- **Abgegrenzte Funktionen**: Werkzeuge führen diskrete Funktionen aus, wie Websuchen, Berechnungen oder Datenbankabfragen.

Ein Beispiel für ein Werkzeug könnte so aussehen:

```typescript
server.tool(
  "GetProducts"
  {
    pageSize: z.string().optional(),
    pageCount: z.string().optional()
  }, () => {
    // return results from API
  }
)
```

## Client-Funktionen

Im Model Context Protocol (MCP) bieten Clients mehrere wichtige Funktionen für Server, die die Gesamtfunktionalität und Interaktion im Protokoll verbessern. Eine der bemerkenswerten Funktionen ist Sampling.

### 👉 Sampling

- **Vom Server initiierte agentenbasierte Verhaltensweisen**: Clients ermöglichen es Servern, bestimmte Aktionen oder Verhaltensweisen autonom zu initiieren, was die dynamischen Fähigkeiten des Systems erweitert.
- **Rekursive LLM-Interaktionen**: Diese Funktion erlaubt rekursive Interaktionen mit großen Sprachmodellen (LLMs) und ermöglicht komplexere und iterative Aufgabenverarbeitung.
- **Anforderung zusätzlicher Modellvervollständigungen**: Server können zusätzliche Vervollständigungen vom Modell anfordern, um sicherzustellen, dass die Antworten umfassend und kontextuell relevant sind.

## Informationsfluss im MCP

Das Model Context Protocol (MCP) definiert einen strukturierten Informationsfluss zwischen Hosts, Clients, Servern und Modellen. Das Verständnis dieses Flusses hilft, zu klären, wie Benutzeranfragen verarbeitet werden und wie externe Werkzeuge und Daten in Modellantworten integriert werden.

- **Host initiiert Verbindung**  
  Die Host-Anwendung (z. B. eine IDE oder Chat-Oberfläche) stellt eine Verbindung zu einem MCP-Server her, typischerweise über STDIO, WebSocket oder einen anderen unterstützten Transport.

- **Fähigkeitsverhandlung**  
  Der Client (eingebettet im Host) und der Server tauschen Informationen über ihre unterstützten Funktionen, Werkzeuge, Ressourcen und Protokollversionen aus. So wird sichergestellt, dass beide Seiten die verfügbaren Fähigkeiten für die Sitzung kennen.

- **Benutzeranfrage**  
  Der Nutzer interagiert mit dem Host (z. B. gibt einen Prompt oder Befehl ein). Der Host sammelt diese Eingabe und übergibt sie zur Verarbeitung an den Client.

- **Ressourcen- oder Werkzeugnutzung**  
  - Der Client kann zusätzliche Kontextinformationen oder Ressourcen vom Server anfordern (wie Dateien, Datenbankeinträge oder Wissensdatenbankartikel), um das Verständnis des Modells zu erweitern.
  - Wenn das Modell feststellt, dass ein Werkzeug benötigt wird (z. B. zum Abrufen von Daten, zur Durchführung einer Berechnung oder zum Aufruf einer API), sendet der Client eine Werkzeugaufruf-Anfrage an den Server, die den Werkzeugnamen und die Parameter enthält.

- **Serverausführung**  
  Der Server empfängt die Ressourcen- oder Werkzeuganfrage, führt die notwendigen Operationen aus (z. B. Funktion ausführen, Datenbank abfragen oder Datei abrufen) und liefert die Ergebnisse in strukturierter Form an den Client zurück.

- **Antwortgenerierung**  
  Der Client integriert die Antworten des Servers (Ressourcendaten, Werkzeugausgaben usw.) in die laufende Modellinteraktion. Das Modell nutzt diese Informationen, um eine umfassende und kontextuell passende Antwort zu generieren.

- **Ergebnispräsentation**  
  Der Host erhält die finale Ausgabe vom Client und präsentiert sie dem Nutzer, oft inklusive des vom Modell generierten Texts sowie aller Ergebnisse aus Werkzeugausführungen oder Ressourcensuchen.

Dieser Ablauf ermöglicht es MCP, fortschrittliche, interaktive und kontextbewusste KI-Anwendungen zu unterstützen, indem Modelle nahtlos mit externen Werkzeugen und Datenquellen verbunden werden.

## Protokolldetails

MCP (Model Context Protocol) baut auf [JSON-RPC 2.0](https://www.jsonrpc.org/) auf und bietet ein standardisiertes, sprachunabhängiges Nachrichtenformat für die Kommunikation zwischen Hosts, Clients und Servern. Diese Grundlage ermöglicht zuverlässige, strukturierte und erweiterbare Interaktionen über verschiedene Plattformen und Programmiersprachen hinweg.

### Wichtige Protokollfunktionen

MCP erweitert JSON-RPC 2.0 um zusätzliche Konventionen für Werkzeugaufrufe, Ressourcen-Zugriffe und Prompt-Verwaltung. Es unterstützt mehrere Transportschichten (STDIO, WebSocket, SSE) und ermöglicht sichere, erweiterbare und sprachunabhängige Kommunikation zwischen den Komponenten.

#### 🧢 Basisprotokoll

- **JSON-RPC Nachrichtenformat**: Alle Anfragen und Antworten verwenden die JSON-RPC 2.0-Spezifikation, die eine konsistente Struktur für Methodenaufrufe, Parameter, Ergebnisse und Fehlerbehandlung gewährleistet.
- **Zustandsbehaftete Verbindungen**: MCP-Sitzungen bewahren den Zustand über mehrere Anfragen hinweg und unterstützen fortlaufende Gespräche, Kontextansammlung und Ressourcenmanagement.
- **Fähigkeitsverhandlung**: Während der Verbindungsherstellung tauschen Clients und Server Informationen über unterstützte Funktionen, Protokollversionen, verfügbare Werkzeuge und Ressourcen aus. So verstehen beide Seiten die Fähigkeiten des Gegenübers und können sich entsprechend anpassen.

#### ➕ Zusätzliche Hilfsmittel

Hier einige zusätzliche Hilfsmittel und Protokollerweiterungen, die MCP bietet, um die Entwicklererfahrung zu verbessern und erweiterte Szenarien zu ermöglichen:

- **Konfigurationsoptionen**: MCP erlaubt die dynamische Konfiguration von Sitzungsparametern wie Werkzeugberechtigungen, Ressourcen-Zugriff und Modelleinstellungen, individuell für jede Interaktion.
- **Fortschrittsanzeige**: Lang laufende Operationen können Fortschrittsupdates melden, was reaktionsfähige Benutzeroberflächen und eine bessere Nutzererfahrung bei komplexen Aufgaben ermöglicht.
- **Anfrageabbruch**: Clients können laufende Anfragen abbrechen, sodass Nutzer Vorgänge unterbrechen können, die nicht mehr benötigt werden oder zu lange dauern.
- **Fehlermeldung**: Standardisierte Fehlermeldungen und Codes helfen bei der Diagnose von Problemen, ermöglichen eine elegante Fehlerbehandlung und liefern umsetzbares Feedback für Nutzer und Entwickler.
- **Protokollierung**: Sowohl Clients als auch Server können strukturierte Logs erzeugen für Audit, Debugging und Überwachung der Protokollinteraktionen.

Durch die Nutzung dieser Protokollfunktionen stellt MCP eine robuste, sichere und flexible Kommunikation zwischen Sprachmodellen und externen Werkzeugen oder Datenquellen sicher.

### 🔐 Sicherheitsaspekte

MCP-Implementierungen sollten mehrere wichtige Sicherheitsprinzipien einhalten, um sichere und vertrauenswürdige Interaktionen zu gewährleisten:

- **Nutzerzustimmung und Kontrolle**: Nutzer müssen ausdrücklich zustimmen, bevor Daten abgerufen oder Operationen ausgeführt werden. Sie sollten klare Kontrolle darüber haben, welche Daten geteilt und welche Aktionen autorisiert werden, unterstützt durch intuitive Benutzeroberflächen zur Überprüfung und Genehmigung von Aktivitäten.

- **Datenschutz**: Nutzerdaten dürfen nur mit ausdrücklicher Zustimmung offengelegt werden und müssen durch geeignete Zugriffskontrollen geschützt sein. MCP-Implementierungen müssen unbefugte Datenübertragungen verhindern und sicherstellen, dass der Datenschutz während aller Interaktionen gewahrt bleibt.

- **Werkzeugsicherheit**: Vor dem Aufruf eines Werkzeugs ist eine explizite Nutzerzustimmung erforderlich. Nutzer sollten die Funktionen jedes Werkzeugs klar verstehen, und es müssen robuste Sicherheitsgrenzen durchgesetzt werden, um unbeabsichtigte oder unsichere Ausführungen zu verhindern.

Durch die Einhaltung dieser Prinzipien stellt MCP sicher, dass Nutzervertrauen, Datenschutz und Sicherheit bei allen Protokollinteraktionen gewahrt bleiben.

## Codebeispiele: Wichtige Komponenten

Nachfolgend finden Sie Codebeispiele in mehreren populären Programmiersprachen, die zeigen, wie wichtige MCP-Serverkomponenten und Werkzeuge implementiert werden.

### .NET Beispiel: Einfachen MCP-Server mit Werkzeugen erstellen

Hier ein praktisches .NET-Beispiel, das zeigt, wie man einen einfachen MCP-Server mit eigenen Werkzeugen implementiert. Dieses Beispiel veranschaulicht, wie Werkzeuge definiert und registriert, Anfragen verarbeitet und der Server mit dem Model Context Protocol verbunden wird.

```csharp
using System;
using System.Threading.Tasks;
using ModelContextProtocol.Server;
using ModelContextProtocol.Server.Transport;
using ModelContextProtocol.Server.Tools;

public class WeatherServer
{
    public static async Task Main(string[] args)
    {
        // Create an MCP server
        var server = new McpServer(
            name: "Weather MCP Server",
            version: "1.0.0"
        );
        
        // Register our custom weather tool
        server.AddTool<string, WeatherData>("weatherTool", 
            description: "Gets current weather for a location",
            execute: async (location) => {
                // Call weather API (simplified)
                var weatherData = await GetWeatherDataAsync(location);
                return weatherData;
            });
        
        // Connect the server using stdio transport
        var transport = new StdioServerTransport();
        await server.ConnectAsync(transport);
        
        Console.WriteLine("Weather MCP Server started");
        
        // Keep the server running until process is terminated
        await Task.Delay(-1);
    }
    
    private static async Task<WeatherData> GetWeatherDataAsync(string location)
    {
        // This would normally call a weather API
        // Simplified for demonstration
        await Task.Delay(100); // Simulate API call
        return new WeatherData { 
            Temperature = 72.5,
            Conditions = "Sunny",
            Location = location
        };
    }
}

public class WeatherData
{
    public double Temperature { get; set; }
    public string Conditions { get; set; }
    public string Location { get; set; }
}
```

### Java Beispiel: MCP Serverkomponenten

Dieses Beispiel zeigt denselben MCP-Server und die Werkzeugregistrierung wie das .NET-Beispiel oben, jedoch in Java umgesetzt.

```java
import io.modelcontextprotocol.server.McpServer;
import io.modelcontextprotocol.server.McpToolDefinition;
import io.modelcontextprotocol.server.transport.StdioServerTransport;
import io.modelcontextprotocol.server.tool.ToolExecutionContext;
import io.modelcontextprotocol.server.tool.ToolResponse;

public class WeatherMcpServer {
    public static void main(String[] args) throws Exception {
        // Create an MCP server
        McpServer server = McpServer.builder()
            .name("Weather MCP Server")
            .version("1.0.0")
            .build();
            
        // Register a weather tool
        server.registerTool(McpToolDefinition.builder("weatherTool")
            .description("Gets current weather for a location")
            .parameter("location", String.class)
            .execute((ToolExecutionContext ctx) -> {
                String location = ctx.getParameter("location", String.class);
                
                // Get weather data (simplified)
                WeatherData data = getWeatherData(location);
                
                // Return formatted response
                return ToolResponse.content(
                    String.format("Temperature: %.1f°F, Conditions: %s, Location: %s", 
                    data.getTemperature(), 
                    data.getConditions(), 
                    data.getLocation())
                );
            })
            .build());
        
        // Connect the server using stdio transport
        try (StdioServerTransport transport = new StdioServerTransport()) {
            server.connect(transport);
            System.out.println("Weather MCP Server started");
            // Keep server running until process is terminated
            Thread.currentThread().join();
        }
    }
    
    private static WeatherData getWeatherData(String location) {
        // Implementation would call a weather API
        // Simplified for example purposes
        return new WeatherData(72.5, "Sunny", location);
    }
}

class WeatherData {
    private double temperature;
    private String conditions;
    private String location;
    
    public WeatherData(double temperature, String conditions, String location) {
        this.temperature = temperature;
        this.conditions = conditions;
        this.location = location;
    }
    
    public double getTemperature() {
        return temperature;
    }
    
    public String getConditions() {
        return conditions;
    }
    
    public String getLocation() {
        return location;
    }
}
```

### Python Beispiel: Einen MCP-Server erstellen

In diesem Beispiel zeigen wir, wie man einen MCP-Server in Python baut. Es werden auch zwei verschiedene Methoden zur Erstellung von Werkzeugen gezeigt.

```python
#!/usr/bin/env python3
import asyncio
from mcp.server.fastmcp import FastMCP
from mcp.server.transports.stdio import serve_stdio

# Create a FastMCP server
mcp = FastMCP(
    name="Weather MCP Server",
    version="1.0.0"
)

@mcp.tool()
def get_weather(location: str) -> dict:
    """Gets current weather for a location."""
    # This would normally call a weather API
    # Simplified for demonstration
    return {
        "temperature": 72.5,
        "conditions": "Sunny",
        "location": location
    }

# Alternative approach using a class
class WeatherTools:
    @mcp.tool()
    def forecast(self, location: str, days: int = 1) -> dict:
        """Gets weather forecast for a location for the specified number of days."""
        # This would normally call a weather API forecast endpoint
        # Simplified for demonstration
        return {
            "location": location,
            "forecast": [
                {"day": i+1, "temperature": 70 + i, "conditions": "Partly Cloudy"}
                for i in range(days)
            ]
        }

# Initialize class for its methods to be registered as tools
weather_tools = WeatherTools()

if __name__ == "__main__":
    # Start the server with stdio transport
    print("Weather MCP Server starting...")
    asyncio.run(serve_stdio(mcp))
```

### JavaScript Beispiel: Einen MCP-Server erstellen

Dieses Beispiel zeigt die Erstellung eines MCP-Servers in JavaScript und demonstriert, wie zwei wetterbezogene Werkzeuge registriert werden.

```javascript
// Using the official Model Context Protocol SDK
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod"; // For parameter validation

// Create an MCP server
const server = new McpServer({
  name: "Weather MCP Server",
  version: "1.0.0"
});

// Define a weather tool
server.tool(
  "weatherTool",
  {
    location: z.string().describe("The location to get weather for")
  },
  async ({ location }) => {
    // This would normally call a weather API
    // Simplified for demonstration
    const weatherData = await getWeatherData(location);
    
    return {
      content: [
        { 
          type: "text", 
          text: `Temperature: ${weatherData.temperature}°F, Conditions: ${weatherData.conditions}, Location: ${weatherData.location}` 
        }
      ]
    };
  }
);

// Define a forecast tool
server.tool(
  "forecastTool",
  {
    location: z.string(),
    days: z.number().default(3).describe("Number of days for forecast")
  },
  async ({ location, days }) => {
    // This would normally call a weather API
    // Simplified for demonstration
    const forecast = await getForecastData(location, days);
    
    return {
      content: [
        { 
          type: "text", 
          text: `${days}-day forecast for ${location}: ${JSON.stringify(forecast)}` 
        }
      ]
    };
  }
);

// Helper functions
async function getWeatherData(location) {
  // Simulate API call
  return {
    temperature: 72.5,
    conditions: "Sunny",
    location: location
  };
}

async function getForecastData(location, days) {
  // Simulate API call
  return Array.from({ length: days }, (_, i) => ({
    day: i + 1,
    temperature: 70 + Math.floor(Math.random() * 10),
    conditions: i % 2 === 0 ? "Sunny" : "Partly Cloudy"
  }));
}

// Connect the server using stdio transport
const transport = new StdioServerTransport();
server.connect(transport).catch(console.error);

console.log("Weather MCP Server started");
```

Dieses JavaScript-Beispiel zeigt, wie man einen MCP-Client erstellt, der sich mit einem Server verbindet, einen Prompt sendet und die Antwort einschließlich aller durchgeführten Werkzeugaufrufe verarbeitet.

## Sicherheit und Autorisierung

MCP beinhaltet mehrere eingebaute Konzepte und Mechanismen zur Verwaltung von Sicherheit und Autorisierung im gesamten Protokoll:

1. **Werkzeug-Berechtigungskontrolle**  
  Clients können festlegen, welche Werkzeuge ein Modell während einer Sitzung nutzen darf. So wird sichergestellt, dass nur ausdrücklich autorisierte Werkzeuge zugänglich sind, was das Risiko unbeabsichtigter oder unsicherer Operationen reduziert. Berechtigungen können dynamisch basierend auf Nutzerpräferenzen, Organisationsrichtlinien oder dem Interaktionskontext konfiguriert werden.

2. **Authentifizierung**  
  Server können vor dem Zugriff auf Werkzeuge, Ressourcen oder sensible Operationen eine Authentifizierung verlangen. Dies kann API-Schlüssel, OAuth-Tokens oder andere Authentifizierungsmethoden umfassen. Eine ordnungsgemäße Authentifizierung stellt sicher, dass nur vertrauenswürdige Clients und Nutzer serverseitige Funktionen aufrufen können.

3. **Validierung**  
  Für alle Werkzeugaufrufe wird eine Parametervalidierung durchgesetzt. Jedes Werkzeug definiert erwartete Typen, Formate und Einschränkungen für seine Parameter, und der Server prüft eingehende Anfragen entsprechend. Dies verhindert fehlerhafte oder bösartige Eingaben und trägt zur Integrität der Operationen bei.

4. **Ratenbegrenzung**  
  Um Missbrauch zu verhindern und eine faire Nutzung der Serverressourcen sicherzustellen, können MCP-Server Ratenbegrenzungen für Werkzeugaufrufe und Ressourcen-Zugriffe implementieren. Limits können pro Nutzer, Sitzung oder global gelten und schützen vor Denial-of-Service-Angriffen oder übermäßigem Ressourcenverbrauch.

Durch die Kombination dieser Mechanismen bietet MCP eine sichere Grundlage für die Integration von Sprachmodellen mit externen Werkzeugen und Datenquellen, während Nutzern und Entwicklern eine feingranulare Kontrolle über Zugriff und Nutzung gegeben wird.

## Protokollnachrichten

Die MCP-Kommunikation verwendet strukturierte JSON-Nachrichten, um klare und zuverlässige Interaktionen zwischen Clients, Servern und Modellen zu ermöglichen. Die wichtigsten Nachrichtentypen sind:

- **Client-Anfrage**  
  Vom Client an den Server gesendet, enthält diese Nachricht typischerweise:
  - Den Prompt oder Befehl des Nutzers
  - Gesprächshistorie für den Kontext
  - Werkzeugkonfiguration und Berechtigungen
  - Weitere Metadaten oder Sitzungsinformationen

- **Modellantwort**  
  Vom Modell (über den Client) zurückgegeben, enthält diese Nachricht:
  - Generierten Text oder Vervollständigung basierend auf Prompt und Kontext
  - Optionale Anweisungen zum Werkzeugaufruf, falls das Modell ein Werkzeug nutzen möchte
  - Verweise auf Ressourcen oder zusätzlichen Kontext bei Bedarf

- **Werkzeug-Anfrage**  
  Vom Client an den Server gesendet, wenn ein Werkzeug ausgeführt werden muss. Diese Nachricht enthält:
  - Den Namen des aufzurufenden Werkzeugs
  - Parameter, die vom Werkzeug benötigt werden (validiert anhand des Schemas)
  - Kontextinformationen oder Identifikatoren zur Nachverfolgung der Anfrage

- **Werkzeug-Antwort**  
  Vom Server nach der Ausführung eines Werkzeugs zurückgegeben. Diese Nachricht liefert:
  - Die Ergebnisse der Werkzeugausführung (strukturierte Daten oder Inhalte)
  - Fehler- oder Statusinformationen, falls der Werkzeugaufruf

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.