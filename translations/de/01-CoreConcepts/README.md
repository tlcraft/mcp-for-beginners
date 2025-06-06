<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00defb149ee1ac4a799e44a9783c7fc",
  "translation_date": "2025-06-06T17:55:15+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "de"
}
-->
# 📖 MCP Kernkonzepte: Das Model Context Protocol für die KI-Integration meistern

Das Model Context Protocol (MCP) ist ein leistungsfähiger, standardisierter Rahmen, der die Kommunikation zwischen großen Sprachmodellen (LLMs) und externen Werkzeugen, Anwendungen und Datenquellen optimiert. Dieser SEO-optimierte Leitfaden führt Sie durch die Kernkonzepte von MCP und stellt sicher, dass Sie die Client-Server-Architektur, die wesentlichen Komponenten, die Kommunikationsmechanismen und bewährte Implementierungspraktiken verstehen.

## Überblick

Diese Lektion behandelt die grundlegende Architektur und die Komponenten, die das MCP-Ökosystem ausmachen. Sie lernen die Client-Server-Architektur, die wichtigsten Komponenten und die Kommunikationsmechanismen kennen, die die MCP-Interaktionen ermöglichen.

## 👩‍🎓 Wichtige Lernziele

Am Ende dieser Lektion werden Sie:

- Die MCP Client-Server-Architektur verstehen.
- Die Rollen und Verantwortlichkeiten von Hosts, Clients und Servern identifizieren.
- Die Kernfunktionen analysieren, die MCP zu einer flexiblen Integrationsschicht machen.
- Verstehen, wie Informationen innerhalb des MCP-Ökosystems fließen.
- Praktische Einblicke durch Codebeispiele in .NET, Java, Python und JavaScript gewinnen.

## 🔎 MCP Architektur: Ein tieferer Einblick

Das MCP-Ökosystem basiert auf einem Client-Server-Modell. Diese modulare Struktur ermöglicht es KI-Anwendungen, effizient mit Werkzeugen, Datenbanken, APIs und kontextuellen Ressourcen zu interagieren. Lassen Sie uns diese Architektur in ihre Kernkomponenten aufschlüsseln.

### 1. Hosts

Im Model Context Protocol (MCP) spielen Hosts eine zentrale Rolle als primäre Schnittstelle, über die Nutzer mit dem Protokoll interagieren. Hosts sind Anwendungen oder Umgebungen, die Verbindungen zu MCP-Servern herstellen, um auf Daten, Werkzeuge und Prompts zuzugreifen. Beispiele für Hosts sind integrierte Entwicklungsumgebungen (IDEs) wie Visual Studio Code, KI-Werkzeuge wie Claude Desktop oder speziell entwickelte Agenten für bestimmte Aufgaben.

**Hosts** sind LLM-Anwendungen, die Verbindungen initiieren. Sie:

- Führen KI-Modelle aus oder interagieren mit ihnen, um Antworten zu generieren.
- Stellen Verbindungen zu MCP-Servern her.
- Steuern den Gesprächsfluss und die Benutzeroberfläche.
- Kontrollieren Berechtigungen und Sicherheitsbeschränkungen.
- Verwalten die Zustimmung der Nutzer zur Datenfreigabe und Ausführung von Werkzeugen.

### 2. Clients

Clients sind wesentliche Komponenten, die die Interaktion zwischen Hosts und MCP-Servern erleichtern. Sie fungieren als Vermittler, die Hosts den Zugriff auf die vom MCP-Server bereitgestellten Funktionen ermöglichen. Sie spielen eine entscheidende Rolle bei der reibungslosen Kommunikation und dem effizienten Datenaustausch innerhalb der MCP-Architektur.

**Clients** sind Verbindungsstellen innerhalb der Host-Anwendung. Sie:

- Senden Anfragen mit Prompts oder Anweisungen an Server.
- Verhandeln Fähigkeiten mit den Servern.
- Verwalten Anfragen zur Ausführung von Werkzeugen durch Modelle.
- Verarbeiten und zeigen Antworten für die Nutzer an.

### 3. Server

Server sind verantwortlich für die Bearbeitung von Anfragen der MCP-Clients und liefern entsprechende Antworten. Sie verwalten verschiedene Operationen wie Datenabruf, Werkzeugausführung und Prompt-Erstellung. Server sorgen dafür, dass die Kommunikation zwischen Clients und Hosts effizient und zuverlässig ist und die Integrität des Interaktionsprozesses gewahrt bleibt.

**Server** sind Dienste, die Kontext und Funktionen bereitstellen. Sie:

- Registrieren verfügbare Features (Ressourcen, Prompts, Werkzeuge)
- Empfangen und führen Werkzeugaufrufe vom Client aus
- Stellen kontextuelle Informationen bereit, um Modellantworten zu verbessern
- Liefern Ergebnisse zurück an den Client
- Pflegen bei Bedarf den Zustand über mehrere Interaktionen hinweg

Server können von jedem entwickelt werden, um Modellfähigkeiten mit spezialisierten Funktionen zu erweitern.

### 4. Server-Funktionen

Server im Model Context Protocol (MCP) bieten grundlegende Bausteine, die reichhaltige Interaktionen zwischen Clients, Hosts und Sprachmodellen ermöglichen. Diese Funktionen sind darauf ausgelegt, die Fähigkeiten von MCP durch strukturierte Kontexte, Werkzeuge und Prompts zu erweitern.

MCP-Server können folgende Funktionen anbieten:

#### 📑 Ressourcen

Ressourcen im Model Context Protocol (MCP) umfassen verschiedene Arten von Kontext und Daten, die von Nutzern oder KI-Modellen verwendet werden können. Dazu gehören:

- **Kontextuelle Daten**: Informationen und Kontext, die Nutzer oder KI-Modelle für Entscheidungsfindung und Aufgabenbearbeitung nutzen können.
- **Wissensdatenbanken und Dokumentenarchive**: Sammlungen strukturierter und unstrukturierter Daten, wie Artikel, Handbücher und Forschungsarbeiten, die wertvolle Einblicke und Informationen bieten.
- **Lokale Dateien und Datenbanken**: Lokal gespeicherte Daten auf Geräten oder in Datenbanken, die für Verarbeitung und Analyse zugänglich sind.
- **APIs und Webdienste**: Externe Schnittstellen und Dienste, die zusätzliche Daten und Funktionen bieten und die Integration mit verschiedenen Online-Ressourcen und Werkzeugen ermöglichen.

Ein Beispiel für eine Ressource könnte ein Datenbankschema oder eine Datei sein, die folgendermaßen abgerufen wird:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Prompts im Model Context Protocol (MCP) umfassen verschiedene vordefinierte Vorlagen und Interaktionsmuster, die darauf ausgelegt sind, Arbeitsabläufe zu vereinfachen und die Kommunikation zu verbessern. Dazu gehören:

- **Vorstrukturierte Nachrichten und Workflows**: Vorgefertigte Nachrichten und Prozesse, die Nutzer durch bestimmte Aufgaben und Interaktionen führen.
- **Vordefinierte Interaktionsmuster**: Standardisierte Abläufe von Aktionen und Antworten, die eine konsistente und effiziente Kommunikation ermöglichen.
- **Spezialisierte Gesprächsvorlagen**: Anpassbare Vorlagen für bestimmte Gesprächsarten, die relevante und kontextuell passende Interaktionen sicherstellen.

Eine Prompt-Vorlage könnte so aussehen:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Werkzeuge

Werkzeuge im Model Context Protocol (MCP) sind Funktionen, die das KI-Modell ausführen kann, um bestimmte Aufgaben zu erledigen. Diese Werkzeuge sind darauf ausgelegt, die Fähigkeiten des KI-Modells durch strukturierte und verlässliche Operationen zu erweitern. Wichtige Aspekte sind:

- **Funktionen, die das KI-Modell ausführen kann**: Werkzeuge sind ausführbare Funktionen, die das Modell aufrufen kann, um verschiedene Aufgaben zu erledigen.
- **Einzigartiger Name und Beschreibung**: Jedes Werkzeug hat einen eindeutigen Namen und eine detaillierte Beschreibung, die Zweck und Funktion erklärt.
- **Parameter und Ausgaben**: Werkzeuge akzeptieren bestimmte Parameter und liefern strukturierte Ergebnisse, um konsistente und vorhersehbare Resultate zu gewährleisten.
- **Abgegrenzte Funktionen**: Werkzeuge führen abgegrenzte Funktionen aus, wie Websuchen, Berechnungen und Datenbankabfragen.

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

## Client-Funktionen

Im Model Context Protocol (MCP) bieten Clients verschiedene wichtige Funktionen für Server, die die Gesamtfunktionalität und Interaktion innerhalb des Protokolls verbessern. Eine der hervorstechenden Funktionen ist Sampling.

### 👉 Sampling

- **Vom Server initiierte agentische Verhaltensweisen**: Clients ermöglichen es Servern, bestimmte Aktionen oder Verhaltensweisen autonom zu starten, was die dynamischen Fähigkeiten des Systems verbessert.
- **Rekursive LLM-Interaktionen**: Diese Funktion erlaubt rekursive Interaktionen mit großen Sprachmodellen (LLMs) und ermöglicht komplexere und iterative Aufgabenbearbeitung.
- **Anforderung zusätzlicher Modell-Vervollständigungen**: Server können zusätzliche Vervollständigungen vom Modell anfordern, um sicherzustellen, dass Antworten umfassend und kontextuell relevant sind.

## Informationsfluss im MCP

Das Model Context Protocol (MCP) definiert einen strukturierten Informationsfluss zwischen Hosts, Clients, Servern und Modellen. Das Verständnis dieses Flusses hilft dabei, zu klären, wie Nutzeranfragen verarbeitet werden und wie externe Werkzeuge und Daten in Modellantworten integriert werden.

- **Host stellt Verbindung her**  
  Die Host-Anwendung (z. B. eine IDE oder Chat-Oberfläche) baut eine Verbindung zu einem MCP-Server auf, typischerweise über STDIO, WebSocket oder einen anderen unterstützten Transport.

- **Fähigkeitsverhandlung**  
  Der Client (eingebettet im Host) und der Server tauschen Informationen über ihre unterstützten Funktionen, Werkzeuge, Ressourcen und Protokollversionen aus. So stellen beide Seiten sicher, welche Fähigkeiten für die Sitzung verfügbar sind.

- **Nutzeranfrage**  
  Der Nutzer interagiert mit dem Host (z. B. durch Eingabe eines Prompts oder Befehls). Der Host sammelt diese Eingabe und leitet sie zur Verarbeitung an den Client weiter.

- **Ressourcen- oder Werkzeugnutzung**  
  - Der Client kann zusätzliche Kontexte oder Ressourcen vom Server anfordern (z. B. Dateien, Datenbankeinträge oder Wissensdatenbankartikel), um das Modellverständnis zu erweitern.
  - Wenn das Modell feststellt, dass ein Werkzeug benötigt wird (z. B. um Daten abzurufen, eine Berechnung durchzuführen oder eine API aufzurufen), sendet der Client eine Werkzeugaufruf-Anfrage an den Server, in der der Werkzeugname und die Parameter angegeben sind.

- **Serverausführung**  
  Der Server erhält die Ressourcen- oder Werkzeuganfrage, führt die notwendigen Operationen aus (z. B. eine Funktion ausführen, eine Datenbank abfragen oder eine Datei abrufen) und liefert die Ergebnisse in strukturierter Form an den Client zurück.

- **Antwortgenerierung**  
  Der Client integriert die Antworten des Servers (Ressourcendaten, Werkzeugergebnisse usw.) in die laufende Modellinteraktion. Das Modell verwendet diese Informationen, um eine umfassende und kontextuell passende Antwort zu generieren.

- **Ergebnispräsentation**  
  Der Host erhält die finale Ausgabe vom Client und stellt sie dem Nutzer dar, oft einschließlich des vom Modell generierten Texts sowie der Ergebnisse von Werkzeugausführungen oder Ressourcenzugriffen.

Dieser Ablauf ermöglicht es MCP, fortschrittliche, interaktive und kontextbewusste KI-Anwendungen zu unterstützen, indem Modelle nahtlos mit externen Werkzeugen und Datenquellen verbunden werden.

## Protokolldetails

MCP (Model Context Protocol) basiert auf [JSON-RPC 2.0](https://www.jsonrpc.org/) und bietet ein standardisiertes, sprachunabhängiges Nachrichtenformat für die Kommunikation zwischen Hosts, Clients und Servern. Diese Grundlage ermöglicht zuverlässige, strukturierte und erweiterbare Interaktionen über verschiedene Plattformen und Programmiersprachen hinweg.

### Wichtige Protokollfunktionen

MCP erweitert JSON-RPC 2.0 um zusätzliche Konventionen für Werkzeugaufrufe, Ressourcen-Zugriff und Prompt-Verwaltung. Es unterstützt mehrere Transportebenen (STDIO, WebSocket, SSE) und ermöglicht sichere, erweiterbare und sprachunabhängige Kommunikation zwischen den Komponenten.

#### 🧢 Basisprotokoll

- **JSON-RPC Nachrichtenformat**: Alle Anfragen und Antworten verwenden die JSON-RPC 2.0 Spezifikation, die eine konsistente Struktur für Methodenaufrufe, Parameter, Ergebnisse und Fehlerbehandlung gewährleistet.
- **Zustandsbehaftete Verbindungen**: MCP-Sitzungen behalten den Zustand über mehrere Anfragen hinweg bei, unterstützen fortlaufende Gespräche, Kontextakkumulation und Ressourcenverwaltung.
- **Fähigkeitsverhandlung**: Während der Verbindungsherstellung tauschen Clients und Server Informationen über unterstützte Funktionen, Protokollversionen, verfügbare Werkzeuge und Ressourcen aus. So verstehen beide Seiten die Fähigkeiten des Gegenübers und können sich entsprechend anpassen.

#### ➕ Zusätzliche Hilfsmittel

Nachfolgend einige zusätzliche Hilfsmittel und Protokollerweiterungen, die MCP bietet, um die Entwicklererfahrung zu verbessern und erweiterte Szenarien zu ermöglichen:

- **Konfigurationsoptionen**: MCP erlaubt die dynamische Konfiguration von Sitzungsparametern, wie Werkzeugberechtigungen, Ressourcenzugriff und Modelleinstellungen, individuell angepasst an jede Interaktion.
- **Fortschrittsverfolgung**: Lang andauernde Operationen können Fortschrittsupdates melden, was reaktionsfähige Benutzeroberflächen und bessere Nutzererfahrungen bei komplexen Aufgaben ermöglicht.
- **Anfrageabbruch**: Clients können laufende Anfragen abbrechen, sodass Nutzer Vorgänge unterbrechen können, die nicht mehr benötigt werden oder zu lange dauern.
- **Fehlermeldung**: Standardisierte Fehlermeldungen und Codes helfen bei der Diagnose von Problemen, erlauben eine elegante Fehlerbehandlung und liefern umsetzbares Feedback für Nutzer und Entwickler.
- **Protokollierung**: Sowohl Clients als auch Server können strukturierte Logs für Audits, Debugging und Überwachung der Protokollinteraktionen ausgeben.

Durch die Nutzung dieser Protokollfunktionen stellt MCP eine robuste, sichere und flexible Kommunikation zwischen Sprachmodellen und externen Werkzeugen oder Datenquellen sicher.

### 🔐 Sicherheitsaspekte

MCP-Implementierungen sollten mehrere zentrale Sicherheitsprinzipien beachten, um sichere und vertrauenswürdige Interaktionen zu gewährleisten:

- **Nutzerzustimmung und Kontrolle**: Nutzer müssen ausdrücklich zustimmen, bevor auf Daten zugegriffen oder Operationen ausgeführt werden. Sie sollten klare Kontrolle darüber haben, welche Daten geteilt und welche Aktionen autorisiert werden, unterstützt durch intuitive Benutzeroberflächen zur Überprüfung und Genehmigung von Aktivitäten.

- **Datenschutz**: Nutzerdaten dürfen nur mit ausdrücklicher Zustimmung offengelegt werden und müssen durch angemessene Zugriffskontrollen geschützt sein. MCP-Implementierungen müssen unbefugte Datenübertragungen verhindern und sicherstellen, dass die Privatsphäre während aller Interaktionen gewahrt bleibt.

- **Werkzeugsicherheit**: Vor dem Aufruf eines Werkzeugs ist eine ausdrückliche Nutzerzustimmung erforderlich. Nutzer sollten die Funktionalität jedes Werkzeugs klar verstehen, und robuste Sicherheitsgrenzen müssen durchgesetzt werden, um unbeabsichtigte oder unsichere Werkzeugausführungen zu verhindern.

Durch die Einhaltung dieser Prinzipien stellt MCP sicher, dass Vertrauen, Datenschutz und Sicherheit der Nutzer in allen Protokollinteraktionen gewahrt bleiben.

## Codebeispiele: Kernkomponenten

Im Folgenden finden Sie Codebeispiele in mehreren populären Programmiersprachen, die zeigen, wie man zentrale MCP-Server-Komponenten und Werkzeuge implementiert.

### .NET Beispiel: Einfachen MCP-Server mit Werkzeugen erstellen

Hier ein praktisches .NET-Beispiel, das zeigt, wie man einen einfachen MCP-Server mit benutzerdefinierten Werkzeugen implementiert. Das Beispiel demonstriert, wie man Werkzeuge definiert und registriert, Anfragen bearbeitet und den Server mit dem Model Context Protocol verbindet.

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

In diesem Beispiel zeigen wir, wie man einen MCP-Server in Python erstellt. Außerdem werden zwei verschiedene Wege gezeigt, Werkzeuge zu erstellen.

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

# Instantiate the class to register its tools
weather_tools = WeatherTools()

# Start the server using stdio transport
if __name__ == "__main__":
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

Dieses JavaScript-Beispiel demonstriert, wie man einen MCP-Client erstellt, der sich mit einem Server verbindet, einen Prompt sendet und die Antwort inklusive etwaiger Werkzeugaufrufe verarbeitet.

## Sicherheit und Autorisierung

MCP beinhaltet mehrere eingebaute Konzepte und Mechanismen zur Verwaltung von Sicherheit und Autorisierung im gesamten Protokoll:

1. **Werkzeug-Berechtigungskontrolle**  
  Clients können festlegen, welche Werkzeuge ein Modell während einer Sitzung nutzen darf. So wird sichergestellt, dass nur ausdrücklich autorisierte Werkzeuge zugänglich sind, was das Risiko unbeabsichtigter oder unsicherer Operationen minimiert. Berechtigungen können dynamisch basierend auf Nutzerpräferenzen, organisatorischen Richtlinien oder dem Kontext der Interaktion konfiguriert werden.

2. **Authentifizierung**  
  Server können vor dem Zugriff auf Werkzeuge, Ressourcen oder sensible Operationen eine Authentifizierung verlangen. Dies kann API-Schlüssel, OAuth-Tokens oder andere Authentifizierungsmethoden umfassen. Eine ordnungsgemäße Authentifizierung stellt sicher, dass nur vertrauenswürdige Clients und Nutzer serverseitige Funktionen aufrufen können.

3. **Validierung**  
  Für alle Werkzeugaufrufe wird eine Parameter-Validierung durchgesetzt. Jedes Werkzeug definiert erwartete Typen, Formate und Einschränkungen für seine Parameter, und der Server überprüft eingehende Anfragen entsprechend. Dies verhindert fehlerhafte oder bösartige Eingaben und hilft, die Integrität der Operationen zu gewährleisten.

4. **Ratenbegrenzung**  
  Um Missbrauch zu verhindern und eine faire Nutzung der Serverressourcen sicherzustellen, können MCP-Server Ratenbegrenzungen für Werkzeugaufrufe und Ressourcenzugriffe implementieren. Limits können pro Nutzer, pro Sitzung oder global angewendet werden und schützen vor Denial-of-Service-Angriffen oder übermäßiger Ressourcennutzung.

Durch die Kombination dieser Mechanismen bietet MCP eine sichere Grundlage zur Integration von Sprachmodellen mit externen Werkzeugen und Datenquellen, während Nutzern und Entwicklern feingranulare Kontrolle über Zugriff und Nutzung ermöglicht wird.

## Protokollnachrichten

Die MCP-Kommunikation verwendet strukturierte JSON-Nachrichten, um klare und zuverlässige Interaktionen zwischen Clients, Servern und Modellen zu ermöglichen. Die Hauptnachrichtentypen sind:

- **Client-Anfrage**  
  Vom Client an den Server gesendet, enthält diese Nachricht typischerweise:
  - Den Prompt oder Befehl des Nutzers
  - Gesprächshistorie für den Kontext
  - Werkzeugkonfiguration und Berechtigungen
  - Zusätzliche Metadaten oder Sitzungsinformationen

- **Modell-Antwort**  
  Vom Modell (über den Client) zurückgegeben, enthält diese Nachricht:
  - Generierten Text oder Vervollständigung basierend auf Prompt und Kontext
  - Optionale Anweisungen zum Werkzeugaufruf, falls das Modell ein Werkzeug aufrufen möchte
  - Verweise auf Ressourcen oder zusätzlichen Kontext bei Bedarf

- **Werkzeug-Anfrage**  
  Vom Client an den Server gesendet, wenn ein Werkzeug ausgeführt werden muss. Diese Nachricht enthält:
  - Den Namen des aufzurufenden Werkzeugs
  - Parameter, die das Werkzeug benötigt (validiert anhand des Werkzeugschemas)
  - Kontextuelle Informationen oder Identifikatoren zur Nachverfolgung der Anfrage

- **Werkzeug-Antwort**  
  Vom Server nach Ausführung

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner ursprünglichen Sprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Verwendung dieser Übersetzung entstehen.