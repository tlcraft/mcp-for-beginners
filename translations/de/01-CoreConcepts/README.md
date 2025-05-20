<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "154c00dc3b2c792102e4845c19fbd166",
  "translation_date": "2025-05-20T15:40:48+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "de"
}
-->
# 📖 MCP Kernkonzepte: Das Model Context Protocol für die Integration von KI meistern

Das Model Context Protocol (MCP) ist ein leistungsstarkes, standardisiertes Framework, das die Kommunikation zwischen Large Language Models (LLMs) und externen Werkzeugen, Anwendungen und Datenquellen optimiert. Dieser SEO-optimierte Leitfaden führt Sie durch die Kernkonzepte von MCP und sorgt dafür, dass Sie die Client-Server-Architektur, wesentliche Komponenten, Kommunikationsmechanismen und bewährte Implementierungspraktiken verstehen.

## Überblick

Diese Lektion behandelt die grundlegende Architektur und die Bausteine des Model Context Protocol (MCP) Ökosystems. Sie lernen die Client-Server-Architektur, wichtige Komponenten und Kommunikationsmechanismen kennen, die die MCP-Interaktionen ermöglichen.

## 👩‍🎓 Wichtige Lernziele

Am Ende dieser Lektion werden Sie:

- Die MCP Client-Server-Architektur verstehen.
- Die Rollen und Verantwortlichkeiten von Hosts, Clients und Servern identifizieren.
- Die Kernfunktionen analysieren, die MCP zu einer flexiblen Integrationsschicht machen.
- Verstehen, wie Informationen im MCP-Ökosystem fließen.
- Praktische Einblicke durch Codebeispiele in .NET, Java, Python und JavaScript gewinnen.

## 🔎 MCP Architektur: Ein genauerer Blick

Das MCP-Ökosystem basiert auf einem Client-Server-Modell. Diese modulare Struktur ermöglicht es KI-Anwendungen, effizient mit Werkzeugen, Datenbanken, APIs und kontextuellen Ressourcen zu interagieren. Lassen Sie uns diese Architektur in ihre Kernkomponenten zerlegen.

### 1. Hosts

Im Model Context Protocol (MCP) spielen Hosts eine entscheidende Rolle als primäre Schnittstelle, über die Nutzer mit dem Protokoll interagieren. Hosts sind Anwendungen oder Umgebungen, die Verbindungen zu MCP-Servern herstellen, um auf Daten, Werkzeuge und Prompts zuzugreifen. Beispiele für Hosts sind integrierte Entwicklungsumgebungen (IDEs) wie Visual Studio Code, KI-Tools wie Claude Desktop oder speziell entwickelte Agenten für bestimmte Aufgaben.

**Hosts** sind LLM-Anwendungen, die Verbindungen initiieren. Sie:

- Führen KI-Modelle aus oder interagieren mit ihnen, um Antworten zu generieren.
- Stellen Verbindungen zu MCP-Servern her.
- Steuern den Gesprächsverlauf und die Benutzeroberfläche.
- Kontrollieren Berechtigungen und Sicherheitsvorgaben.
- Verwalten die Zustimmung der Nutzer für Datenfreigabe und Werkzeugausführung.

### 2. Clients

Clients sind zentrale Komponenten, die die Interaktion zwischen Hosts und MCP-Servern ermöglichen. Sie fungieren als Vermittler und erlauben Hosts, die vom MCP-Server bereitgestellten Funktionen zu nutzen. Sie spielen eine wichtige Rolle für eine reibungslose Kommunikation und effizienten Datenaustausch innerhalb der MCP-Architektur.

**Clients** sind Verbindungsstücke innerhalb der Host-Anwendung. Sie:

- Senden Anfragen mit Prompts oder Anweisungen an Server.
- Verhandeln Fähigkeiten mit Servern.
- Verwalten Ausführungsanfragen von Werkzeugen durch Modelle.
- Verarbeiten und zeigen Antworten für Nutzer an.

### 3. Server

Server sind für die Bearbeitung von Anfragen der MCP-Clients und die Bereitstellung passender Antworten verantwortlich. Sie übernehmen verschiedene Aufgaben wie Datenabruf, Werkzeugausführung und Prompt-Generierung. Server sorgen für eine effiziente und zuverlässige Kommunikation zwischen Clients und Hosts und erhalten die Integrität des Interaktionsprozesses.

**Server** sind Dienste, die Kontext und Funktionen bereitstellen. Sie:

- Registrieren verfügbare Features (Ressourcen, Prompts, Werkzeuge).
- Empfangen und führen Werkzeugaufrufe vom Client aus.
- Liefern kontextuelle Informationen zur Verbesserung der Modellantworten.
- Geben Ergebnisse an den Client zurück.
- Verwalten bei Bedarf den Zustand über Interaktionen hinweg.

Server können von jedem entwickelt werden, um Modellfähigkeiten mit spezialisierten Funktionen zu erweitern.

### 4. Server-Features

Server im Model Context Protocol (MCP) bieten grundlegende Bausteine, die reichhaltige Interaktionen zwischen Clients, Hosts und Sprachmodellen ermöglichen. Diese Features sind darauf ausgelegt, die Fähigkeiten von MCP durch strukturierte Kontexte, Werkzeuge und Prompts zu erweitern.

MCP-Server können eine oder mehrere der folgenden Features bereitstellen:

#### 📑 Ressourcen

Ressourcen im Model Context Protocol (MCP) umfassen verschiedene Arten von Kontext und Daten, die von Nutzern oder KI-Modellen verwendet werden können. Dazu gehören:

- **Kontextuelle Daten**: Informationen und Kontext, die für Entscheidungsfindung und Aufgabenausführung genutzt werden können.
- **Wissensdatenbanken und Dokumentenarchive**: Sammlungen strukturierter und unstrukturierter Daten wie Artikel, Handbücher und Forschungsarbeiten, die wertvolle Einblicke bieten.
- **Lokale Dateien und Datenbanken**: Daten, die lokal auf Geräten oder in Datenbanken gespeichert sind und für Verarbeitung und Analyse zugänglich sind.
- **APIs und Webservices**: Externe Schnittstellen und Dienste, die zusätzliche Daten und Funktionen bereitstellen und die Integration mit verschiedenen Online-Ressourcen und Werkzeugen ermöglichen.

Ein Beispiel für eine Ressource kann ein Datenbankschema oder eine Datei sein, die folgendermaßen abgerufen wird:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Prompts im Model Context Protocol (MCP) umfassen verschiedene vordefinierte Vorlagen und Interaktionsmuster, die dazu dienen, Arbeitsabläufe zu vereinfachen und die Kommunikation zu verbessern. Dazu gehören:

- **Vorstrukturierte Nachrichten und Workflows**: Vorgefertigte Nachrichten und Abläufe, die Nutzer durch bestimmte Aufgaben und Interaktionen führen.
- **Vordefinierte Interaktionsmuster**: Standardisierte Abfolgen von Aktionen und Antworten, die eine konsistente und effiziente Kommunikation fördern.
- **Spezialisierte Gesprächsvorlagen**: Anpassbare Templates, die für bestimmte Gesprächsarten optimiert sind und relevante, kontextbezogene Interaktionen sicherstellen.

Eine Prompt-Vorlage könnte so aussehen:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Werkzeuge

Werkzeuge im Model Context Protocol (MCP) sind Funktionen, die das KI-Modell ausführen kann, um bestimmte Aufgaben zu erledigen. Diese Werkzeuge erweitern die Fähigkeiten des Modells durch strukturierte und verlässliche Operationen. Wichtige Merkmale sind:

- **Funktionen, die das KI-Modell ausführen kann**: Werkzeuge sind ausführbare Funktionen, die vom Modell aufgerufen werden können, um verschiedene Aufgaben zu erledigen.
- **Eindeutiger Name und Beschreibung**: Jedes Werkzeug hat einen klaren Namen und eine ausführliche Beschreibung, die Zweck und Funktion erklärt.
- **Parameter und Ausgaben**: Werkzeuge akzeptieren bestimmte Parameter und liefern strukturierte Ergebnisse, um konsistente und vorhersehbare Resultate zu gewährleisten.
- **Abgegrenzte Funktionen**: Werkzeuge führen klar definierte Aufgaben aus, wie Websuchen, Berechnungen oder Datenbankabfragen.

Ein Beispiel für ein Werkzeug könnte so aussehen:

```typescript
server.tool(
  "GetProducts",
  {
    pageSize: z.string().optional(),
    pageCount: z.string().optional()
  }, () => {
    // return results from API
  }
)
```

## Client-Features

Im Model Context Protocol (MCP) bieten Clients mehrere wichtige Funktionen für Server, die die Gesamtheit der Interaktion verbessern. Eine davon ist Sampling.

### 👉 Sampling

- **Server-initiiertes agentisches Verhalten**: Clients ermöglichen es Servern, autonom bestimmte Aktionen oder Verhaltensweisen auszulösen, was die dynamischen Fähigkeiten des Systems erweitert.
- **Rekursive LLM-Interaktionen**: Dieses Feature erlaubt rekursive Interaktionen mit großen Sprachmodellen (LLMs), wodurch komplexere und iterative Aufgabenbearbeitungen möglich werden.
- **Anforderung zusätzlicher Modell-Antworten**: Server können zusätzliche Antworten vom Modell anfordern, um sicherzustellen, dass die Resultate umfassend und kontextbezogen sind.

## Informationsfluss im MCP

Das Model Context Protocol (MCP) definiert einen strukturierten Informationsfluss zwischen Hosts, Clients, Servern und Modellen. Das Verständnis dieses Flusses klärt, wie Benutzeranfragen verarbeitet und externe Werkzeuge sowie Daten in Modellantworten integriert werden.

- **Host initiiert Verbindung**  
  Die Host-Anwendung (z. B. eine IDE oder Chat-Oberfläche) stellt eine Verbindung zu einem MCP-Server her, typischerweise über STDIO, WebSocket oder einen anderen unterstützten Transport.

- **Fähigkeitsverhandlung**  
  Client (eingebettet im Host) und Server tauschen Informationen über unterstützte Features, Werkzeuge, Ressourcen und Protokollversionen aus. So stellen beide Seiten sicher, welche Fähigkeiten für die Sitzung verfügbar sind.

- **Benutzeranfrage**  
  Der Nutzer interagiert mit dem Host (z. B. durch Eingabe eines Prompts oder Befehls). Der Host sammelt diese Eingabe und leitet sie an den Client zur Verarbeitung weiter.

- **Nutzung von Ressourcen oder Werkzeugen**  
  - Der Client kann zusätzliche Kontextinformationen oder Ressourcen vom Server anfordern (z. B. Dateien, Datenbankeinträge oder Wissensdatenbank-Artikel), um das Verständnis des Modells zu verbessern.  
  - Wenn das Modell entscheidet, dass ein Werkzeug benötigt wird (z. B. zum Abrufen von Daten, zur Durchführung einer Berechnung oder zum Aufruf einer API), sendet der Client eine Werkzeugaufruf-Anfrage an den Server, mit Angabe des Werkzeugnamens und der Parameter.

- **Serverausführung**  
  Der Server empfängt die Anfrage für Ressourcen oder Werkzeuge, führt die erforderlichen Operationen aus (z. B. Funktionsaufruf, Datenbankabfrage oder Dateiabruf) und liefert die Ergebnisse in strukturierter Form an den Client zurück.

- **Antwortgenerierung**  
  Der Client integriert die Serverantworten (Ressourcendaten, Werkzeugausgaben etc.) in die laufende Modellinteraktion. Das Modell nutzt diese Informationen, um eine umfassende und kontextbezogene Antwort zu generieren.

- **Ergebnispräsentation**  
  Der Host erhält die finale Ausgabe vom Client und präsentiert sie dem Nutzer, häufig inklusive des vom Modell generierten Texts sowie aller Ergebnisse aus Werkzeugausführungen oder Ressourcenabfragen.

Dieser Ablauf ermöglicht es MCP, fortschrittliche, interaktive und kontextbewusste KI-Anwendungen zu unterstützen, indem Modelle nahtlos mit externen Werkzeugen und Datenquellen verbunden werden.

## Protokolldetails

MCP (Model Context Protocol) basiert auf [JSON-RPC 2.0](https://www.jsonrpc.org/) und bietet ein standardisiertes, sprachunabhängiges Nachrichtenformat für die Kommunikation zwischen Hosts, Clients und Servern. Diese Grundlage ermöglicht zuverlässige, strukturierte und erweiterbare Interaktionen über verschiedene Plattformen und Programmiersprachen hinweg.

### Wichtige Protokollfunktionen

MCP erweitert JSON-RPC 2.0 um zusätzliche Konventionen für Werkzeugaufrufe, Ressourcen-Zugriffe und Prompt-Verwaltung. Es unterstützt mehrere Transportschichten (STDIO, WebSocket, SSE) und ermöglicht sichere, erweiterbare und sprachunabhängige Kommunikation zwischen den Komponenten.

#### 🧢 Basisprotokoll

- **JSON-RPC Nachrichtenformat**: Alle Anfragen und Antworten verwenden die JSON-RPC 2.0 Spezifikation, die eine konsistente Struktur für Methodenaufrufe, Parameter, Ergebnisse und Fehlerbehandlung sicherstellt.
- **Zustandsbehaftete Verbindungen**: MCP-Sitzungen erhalten den Zustand über mehrere Anfragen hinweg, unterstützen fortlaufende Gespräche, Kontextansammlung und Ressourcenmanagement.
- **Fähigkeitsverhandlung**: Während der Verbindungsherstellung tauschen Clients und Server Informationen über unterstützte Features, Protokollversionen, verfügbare Werkzeuge und Ressourcen aus. So verstehen beide Seiten die Fähigkeiten des Gegenübers und können sich entsprechend anpassen.

#### ➕ Zusätzliche Hilfsmittel

Nachfolgend einige weitere Utilities und Protokollerweiterungen, die MCP zur Verbesserung der Entwicklererfahrung und für erweiterte Anwendungsfälle bietet:

- **Konfigurationsoptionen**: MCP erlaubt die dynamische Konfiguration von Sitzungsparametern wie Werkzeugberechtigungen, Ressourcen-Zugriff und Modelleinstellungen, maßgeschneidert für jede Interaktion.
- **Fortschrittsanzeige**: Lang laufende Operationen können Fortschrittsupdates senden, was reaktive Benutzeroberflächen und bessere Nutzererfahrung bei komplexen Aufgaben ermöglicht.
- **Anfrageabbruch**: Clients können laufende Anfragen abbrechen, sodass Nutzer Vorgänge unterbrechen können, die nicht mehr benötigt werden oder zu lange dauern.
- **Fehlermeldungen**: Standardisierte Fehlermeldungen und Codes helfen bei der Diagnose von Problemen, ermöglichen eine elegante Fehlerbehandlung und liefern verwertbares Feedback für Nutzer und Entwickler.
- **Protokollierung**: Sowohl Clients als auch Server können strukturierte Logs erzeugen, um Protokollierung, Debugging und Monitoring der Protokollinteraktionen zu unterstützen.

Durch diese Protokollfeatures gewährleistet MCP eine robuste, sichere und flexible Kommunikation zwischen Sprachmodellen und externen Werkzeugen oder Datenquellen.

### 🔐 Sicherheitsaspekte

MCP-Implementierungen sollten sich an mehrere wichtige Sicherheitsprinzipien halten, um sichere und vertrauenswürdige Interaktionen zu gewährleisten:

- **Nutzerzustimmung und Kontrolle**: Nutzer müssen vor dem Zugriff auf Daten oder der Ausführung von Operationen ausdrücklich zustimmen. Sie sollten klare Kontrolle darüber haben, welche Daten geteilt und welche Aktionen autorisiert werden, unterstützt durch intuitive Benutzeroberflächen zur Überprüfung und Genehmigung.

- **Datenschutz**: Nutzerdaten dürfen nur mit ausdrücklicher Zustimmung offengelegt werden und müssen durch angemessene Zugriffskontrollen geschützt sein. MCP-Implementierungen müssen unbefugte Datenübertragung verhindern und sicherstellen, dass die Privatsphäre während aller Interaktionen gewahrt bleibt.

- **Werkzeugsicherheit**: Vor dem Aufruf eines Werkzeugs ist eine explizite Nutzerzustimmung erforderlich. Nutzer sollten die Funktionalität jedes Werkzeugs klar verstehen, und robuste Sicherheitsgrenzen müssen durchgesetzt werden, um unbeabsichtigte oder unsichere Ausführungen zu verhindern.

Durch die Einhaltung dieser Prinzipien stellt MCP sicher, dass Vertrauen, Datenschutz und Sicherheit der Nutzer in allen Protokollinteraktionen gewahrt bleiben.

## Codebeispiele: Wichtige Komponenten

Nachfolgend finden Sie Codebeispiele in mehreren populären Programmiersprachen, die zeigen, wie man wichtige MCP-Serverkomponenten und Werkzeuge implementiert.

### .NET Beispiel: Einen einfachen MCP-Server mit Werkzeugen erstellen

Hier ein praktisches .NET-Beispiel, das zeigt, wie man einen einfachen MCP-Server mit benutzerdefinierten Werkzeugen implementiert. Dieses Beispiel demonstriert, wie Werkzeuge definiert und registriert, Anfragen bearbeitet und der Server über das Model Context Protocol verbunden wird.

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

### Java Beispiel: MCP Server-Komponenten

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

### Python Beispiel: Einen MCP-Server bauen

In diesem Beispiel zeigen wir, wie man einen MCP-Server in Python baut. Zudem werden zwei verschiedene Methoden zur Erstellung von Werkzeugen demonstriert.

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

Dieses Beispiel zeigt die Erstellung eines MCP-Servers in JavaScript und wie zwei wetterbezogene Werkzeuge registriert werden.

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

Dieses JavaScript-Beispiel zeigt, wie man einen MCP-Client erstellt, der sich mit einem Server verbindet, einen Prompt sendet und die Antwort einschließlich aller ausgeführten Werkzeugaufrufe verarbeitet.

## Sicherheit und Autorisierung

MCP beinhaltet mehrere eingebaute Konzepte und Mechanismen zur Verwaltung von Sicherheit und Autorisierung im gesamten Protokoll:

1. **Werkzeug-Berechtigungskontrolle**  
  Clients können festlegen, welche Werkzeuge ein Modell während einer Sitzung nutzen darf. Das stellt sicher, dass nur explizit autorisierte Werkzeuge zugänglich sind, was das Risiko unbeabsichtigter oder unsicherer Operationen verringert. Berechtigungen können dynamisch basierend auf Nutzerpräferenzen, Organisationsrichtlinien oder Kontext der Interaktion konfiguriert werden.

2. **Authentifizierung**  
  Server können eine Authentifizierung verlangen, bevor Zugriff auf Werkzeuge, Ressourcen oder sensible Operationen gewährt wird. Dies kann API-Schlüssel, OAuth-Tokens oder andere Authentifizierungsmethoden umfassen. Eine ordnungsgemäße Authentifizierung stellt sicher, dass nur vertrauenswürdige Clients und Nutzer serverseitige Funktionen aufrufen können.

3. **Validierung**  
  Parameter werden bei allen Werkzeugaufrufen überprüft. Jedes Werkzeug definiert erwartete Typen, Formate und Einschränkungen für seine Parameter, und der Server validiert eingehende Anfragen entsprechend. Dies verhindert fehlerhafte oder bösartige Eingaben und trägt zur Integrität der Operationen bei.

4. **Rate Limiting**  
  Um Missbrauch zu verhindern und eine faire Nutzung der Serverressourcen sicherzustellen, können MCP-Server Aufrufraten für Werkzeuge und Ressourcenbegrenzungen implementieren. Diese Limits können pro Nutzer, pro Sitzung oder global gelten und schützen vor Denial-of-Service-Angriffen oder übermäßiger Ressourcennutzung.

Durch die Kombination dieser Mechanismen bietet MCP eine sichere Grundlage für die Integration von Sprachmodellen mit externen Werkzeugen und Datenquellen, während Nutzer und Entwickler feinkörnige Kontrolle über Zugriff und Nutzung erhalten.

## Protokollnachrichten

Die MCP-Kommunikation verwendet strukturierte JSON-Nachrichten, um klare und zuverlässige Interaktionen zwischen Clients, Servern und Modellen zu ermöglichen. Die Hauptnachrichtentypen umfassen:

- **Client-Anfrage**  
  Vom Client an den Server gesendet, enthält diese Nachricht typischerweise:  
  - Den Prompt oder Befehl des Nutzers  
  - Gesprächshistorie als Kontext  
  - Werkzeugkonfiguration und Berechtigungen  
  - Zusätzliche Metadaten oder Sitzungsinformationen

- **Modellantwort**  
  Vom Modell (über den Client) zurückgegeben, enthält diese Nachricht:  
  - Generierten Text oder Completion basierend auf Prompt und Kontext  
  - Optionale Anweisungen zum Werkzeugaufruf, falls das Modell ein Werkzeug nutzen möchte  
  - Verweise auf Ressourcen oder zusätzlichen Kontext nach Bedarf

- **Werkzeug-Anfrage**  
  Vom Client an den Server gesendet, wenn ein Werkzeug ausgeführt werden soll. Diese Nachricht beinhaltet:  
  - Den Namen des aufzurufenden Werkzeugs  
  - Parameter, die vom Werkzeug benötigt werden (validiert anhand des Schemas)  
  - Kontextuelle Informationen oder Identifikatoren zur Nachverfolgung der Anfrage

- **Werkzeug-Antwort**  
  Vom Server nach Ausführung eines Werkzeugs zurückgegeben. Diese Nachricht liefert:  
  - Die Ergebnisse der Werkzeugausführung (strukturierte Daten oder Inhalte)  
  - Fehler- oder Statusinformationen, falls der Werkzeugaufruf fehlschlug  
  - Optional zusätzliche Metadaten oder Protokolle zur Ausführung

Diese strukturierten Nachrichten sorgen dafür, dass jeder Schritt im MCP-Workflow expl

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir auf Genauigkeit achten, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Verwendung dieser Übersetzung entstehen.