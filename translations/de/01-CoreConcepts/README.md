<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4bf553c18e7e226c3d76ab0cde627d26",
  "translation_date": "2025-05-20T20:14:15+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "de"
}
-->
# 📖 MCP Kernkonzepte: Das Model Context Protocol für die KI-Integration meistern

Das Model Context Protocol (MCP) ist ein leistungsstarkes, standardisiertes Framework, das die Kommunikation zwischen großen Sprachmodellen (LLMs) und externen Tools, Anwendungen sowie Datenquellen optimiert. Dieser SEO-optimierte Leitfaden führt dich durch die Kernkonzepte von MCP und stellt sicher, dass du die Client-Server-Architektur, die wesentlichen Komponenten, die Kommunikationsmechanismen und bewährte Implementierungspraktiken verstehst.

## Überblick

Diese Lektion behandelt die grundlegende Architektur und die Komponenten, die das MCP-Ökosystem ausmachen. Du lernst die Client-Server-Architektur, zentrale Bausteine und die Kommunikationsmechanismen kennen, die MCP-Interaktionen ermöglichen.

## 👩‍🎓 Wichtige Lernziele

Am Ende dieser Lektion wirst du:

- Die MCP Client-Server-Architektur verstehen.
- Die Rollen und Verantwortlichkeiten von Hosts, Clients und Servern benennen können.
- Die Kernfunktionen analysieren, die MCP zu einer flexiblen Integrationsschicht machen.
- Verstehen, wie Informationen im MCP-Ökosystem fließen.
- Praktische Einblicke anhand von Codebeispielen in .NET, Java, Python und JavaScript erhalten.

## 🔎 MCP Architektur: Ein genauerer Blick

Das MCP-Ökosystem basiert auf einem Client-Server-Modell. Diese modulare Struktur ermöglicht es KI-Anwendungen, effizient mit Tools, Datenbanken, APIs und kontextuellen Ressourcen zu interagieren. Schauen wir uns diese Architektur anhand ihrer Kernkomponenten genauer an.

### 1. Hosts

Im Model Context Protocol (MCP) spielen Hosts eine zentrale Rolle als primäre Schnittstelle, über die Nutzer mit dem Protokoll interagieren. Hosts sind Anwendungen oder Umgebungen, die Verbindungen zu MCP-Servern herstellen, um auf Daten, Tools und Prompts zuzugreifen. Beispiele für Hosts sind integrierte Entwicklungsumgebungen (IDEs) wie Visual Studio Code, KI-Tools wie Claude Desktop oder speziell entwickelte Agenten für bestimmte Aufgaben.

**Hosts** sind LLM-Anwendungen, die Verbindungen initiieren. Sie:

- Führen KI-Modelle aus oder interagieren mit ihnen, um Antworten zu generieren.
- Stellen Verbindungen zu MCP-Servern her.
- Steuern den Gesprächsfluss und die Benutzeroberfläche.
- Kontrollieren Berechtigungen und Sicherheitsvorgaben.
- Verwalten die Einwilligung der Nutzer für Datenaustausch und Tool-Ausführung.

### 2. Clients

Clients sind essenzielle Komponenten, die die Interaktion zwischen Hosts und MCP-Servern ermöglichen. Sie fungieren als Vermittler, die Hosts den Zugriff auf die Funktionen der MCP-Server erlauben. Sie spielen eine wichtige Rolle, um eine reibungslose Kommunikation und einen effizienten Datenaustausch innerhalb der MCP-Architektur sicherzustellen.

**Clients** sind Verbindungsstücke innerhalb der Host-Anwendung. Sie:

- Senden Anfragen mit Prompts/Instruktionen an Server.
- Verhandeln Fähigkeiten mit den Servern.
- Verwalten Ausführungsanfragen für Tools von Modellen.
- Verarbeiten und zeigen Antworten für die Nutzer an.

### 3. Server

Server sind für die Bearbeitung von Anfragen der MCP-Clients und die Bereitstellung entsprechender Antworten zuständig. Sie verwalten verschiedene Operationen wie Datenabruf, Tool-Ausführung und Prompt-Generierung. Server sorgen dafür, dass die Kommunikation zwischen Clients und Hosts effizient und zuverlässig ist und die Integrität des Interaktionsprozesses gewahrt bleibt.

**Server** sind Dienste, die Kontext und Funktionen bereitstellen. Sie:

- Registrieren verfügbare Features (Ressourcen, Prompts, Tools).
- Empfangen und führen Tool-Aufrufe vom Client aus.
- Liefern kontextuelle Informationen zur Verbesserung der Modellantworten.
- Geben Ergebnisse an den Client zurück.
- Bewahren bei Bedarf den Zustand über Interaktionen hinweg.

Server können von jedem entwickelt werden, um die Modellfähigkeiten mit spezialisierten Funktionen zu erweitern.

### 4. Server-Features

Server im Model Context Protocol (MCP) bieten grundlegende Bausteine, die reichhaltige Interaktionen zwischen Clients, Hosts und Sprachmodellen ermöglichen. Diese Features sind darauf ausgelegt, die Fähigkeiten von MCP durch strukturierte Kontexte, Tools und Prompts zu erweitern.

MCP-Server können eine oder mehrere der folgenden Features anbieten:

#### 📑 Ressourcen

Ressourcen im Model Context Protocol (MCP) umfassen verschiedene Arten von Kontexten und Daten, die von Nutzern oder KI-Modellen genutzt werden können. Dazu gehören:

- **Kontextuelle Daten**: Informationen und Kontext, die Nutzer oder KI-Modelle für Entscheidungen und Aufgaben verwenden können.
- **Wissensdatenbanken und Dokumentensammlungen**: Strukturiertes und unstrukturiertes Material wie Artikel, Handbücher und Forschungsarbeiten, die wertvolle Einblicke bieten.
- **Lokale Dateien und Datenbanken**: Daten, die lokal auf Geräten oder in Datenbanken gespeichert sind und für Verarbeitung und Analyse zugänglich sind.
- **APIs und Webservices**: Externe Schnittstellen und Dienste, die zusätzliche Daten und Funktionen bereitstellen und die Integration verschiedener Online-Ressourcen und Tools ermöglichen.

Ein Beispiel für eine Ressource könnte ein Datenbankschema oder eine Datei sein, die folgendermaßen abgerufen wird:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Prompts im Model Context Protocol (MCP) umfassen verschiedene vordefinierte Vorlagen und Interaktionsmuster, die darauf ausgelegt sind, Arbeitsabläufe zu vereinfachen und die Kommunikation zu verbessern. Dazu gehören:

- **Vorstrukturierte Nachrichten und Workflows**: Vorgefertigte Nachrichten und Abläufe, die Nutzer durch spezifische Aufgaben und Interaktionen führen.
- **Vordefinierte Interaktionsmuster**: Standardisierte Abfolgen von Aktionen und Antworten, die eine konsistente und effiziente Kommunikation fördern.
- **Spezialisierte Gesprächsvorlagen**: Anpassbare Vorlagen, die auf bestimmte Gesprächstypen zugeschnitten sind und relevante sowie kontextuell passende Interaktionen sicherstellen.

Eine Prompt-Vorlage könnte so aussehen:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Tools

Tools im Model Context Protocol (MCP) sind Funktionen, die das KI-Modell ausführen kann, um bestimmte Aufgaben zu erledigen. Diese Tools erweitern die Fähigkeiten des KI-Modells durch strukturierte und verlässliche Operationen. Wichtige Aspekte sind:

- **Funktionen, die vom KI-Modell ausgeführt werden**: Tools sind ausführbare Funktionen, die das Modell aufrufen kann, um Aufgaben zu erledigen.
- **Eindeutiger Name und Beschreibung**: Jedes Tool hat einen klaren Namen und eine detaillierte Beschreibung, die Zweck und Funktion erläutert.
- **Parameter und Ausgaben**: Tools akzeptieren spezifische Parameter und liefern strukturierte Ausgaben, was konsistente und vorhersagbare Ergebnisse sicherstellt.
- **Abgegrenzte Funktionen**: Tools führen diskrete Aufgaben aus, wie Websuchen, Berechnungen oder Datenbankabfragen.

Ein Beispiel für ein Tool könnte so aussehen:

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

Im Model Context Protocol (MCP) bieten Clients mehrere wichtige Features für Server, die die Funktionalität und Interaktion im Protokoll verbessern. Eines der bemerkenswerten Features ist Sampling.

### 👉 Sampling

- **Server-initiiertes agentenbasiertes Verhalten**: Clients ermöglichen es Servern, bestimmte Aktionen oder Verhaltensweisen autonom zu starten und erweitern so die dynamischen Fähigkeiten des Systems.
- **Rekursive LLM-Interaktionen**: Dieses Feature erlaubt rekursive Interaktionen mit großen Sprachmodellen (LLMs), was komplexere und iterative Aufgabenverarbeitung ermöglicht.
- **Anforderung zusätzlicher Modell-Ergänzungen**: Server können weitere Modellantworten anfordern, um sicherzustellen, dass die Antworten umfassend und kontextuell passend sind.

## Informationsfluss im MCP

Das Model Context Protocol (MCP) definiert einen strukturierten Informationsfluss zwischen Hosts, Clients, Servern und Modellen. Das Verständnis dieses Ablaufs hilft zu klären, wie Benutzeranfragen verarbeitet werden und wie externe Tools und Daten in Modellantworten integriert werden.

- **Host stellt Verbindung her**  
  Die Host-Anwendung (z.B. eine IDE oder Chat-Oberfläche) baut eine Verbindung zu einem MCP-Server auf, typischerweise über STDIO, WebSocket oder einen anderen unterstützten Transport.

- **Fähigkeitsverhandlung**  
  Client (eingebettet im Host) und Server tauschen Informationen über ihre unterstützten Features, Tools, Ressourcen und Protokollversionen aus. So verstehen beide Seiten, welche Fähigkeiten für die Sitzung verfügbar sind.

- **Benutzeranfrage**  
  Der Nutzer interagiert mit dem Host (z.B. gibt einen Prompt oder Befehl ein). Der Host sammelt diese Eingabe und leitet sie an den Client zur Verarbeitung weiter.

- **Nutzung von Ressourcen oder Tools**  
  - Der Client kann zusätzliche Kontextinformationen oder Ressourcen vom Server anfordern (z.B. Dateien, Datenbankeinträge oder Artikel aus Wissensdatenbanken), um das Modellverständnis zu erweitern.
  - Wenn das Modell entscheidet, dass ein Tool benötigt wird (z.B. um Daten abzurufen, Berechnungen durchzuführen oder eine API aufzurufen), sendet der Client eine Tool-Aufruf-Anfrage an den Server, in der der Tool-Name und die Parameter angegeben sind.

- **Server-Ausführung**  
  Der Server empfängt die Anfrage zu Ressourcen oder Tools, führt die erforderlichen Operationen aus (z.B. Funktionsaufruf, Datenbankabfrage oder Dateizugriff) und gibt die Ergebnisse in strukturierter Form an den Client zurück.

- **Antwortgenerierung**  
  Der Client integriert die Serverantworten (Ressourcendaten, Tool-Ausgaben etc.) in die laufende Modellinteraktion. Das Modell nutzt diese Informationen, um eine umfassende und kontextuell passende Antwort zu erzeugen.

- **Ergebnispräsentation**  
  Der Host erhält die finale Ausgabe vom Client und stellt sie dem Nutzer dar – meist sowohl den vom Modell generierten Text als auch Ergebnisse von Tool-Ausführungen oder Ressourcenzugriffen.

Dieser Ablauf ermöglicht es MCP, fortschrittliche, interaktive und kontextbewusste KI-Anwendungen zu unterstützen, indem Modelle nahtlos mit externen Tools und Datenquellen verbunden werden.

## Protokolldetails

MCP (Model Context Protocol) baut auf [JSON-RPC 2.0](https://www.jsonrpc.org/) auf und bietet ein standardisiertes, sprachunabhängiges Nachrichtenformat für die Kommunikation zwischen Hosts, Clients und Servern. Diese Grundlage ermöglicht zuverlässige, strukturierte und erweiterbare Interaktionen über verschiedene Plattformen und Programmiersprachen hinweg.

### Wichtige Protokollfunktionen

MCP erweitert JSON-RPC 2.0 um zusätzliche Konventionen für Tool-Aufrufe, Ressourcen-Zugriffe und Prompt-Verwaltung. Es unterstützt mehrere Transportebenen (STDIO, WebSocket, SSE) und ermöglicht sichere, erweiterbare und sprachunabhängige Kommunikation zwischen den Komponenten.

#### 🧢 Basisprotokoll

- **JSON-RPC Nachrichtenformat**: Alle Anfragen und Antworten folgen der JSON-RPC 2.0 Spezifikation, was eine konsistente Struktur für Methodenaufrufe, Parameter, Ergebnisse und Fehlerbehandlung gewährleistet.
- **Zustandsbehaftete Verbindungen**: MCP-Sitzungen behalten den Zustand über mehrere Anfragen hinweg bei und unterstützen fortlaufende Gespräche, Kontextansammlungen und Ressourcenverwaltung.
- **Fähigkeitsverhandlung**: Während des Verbindungsaufbaus tauschen Clients und Server Informationen zu unterstützten Features, Protokollversionen, verfügbaren Tools und Ressourcen aus. So verstehen beide Seiten die Fähigkeiten des Gegenübers und können sich entsprechend anpassen.

#### ➕ Zusätzliche Hilfsmittel

Hier einige zusätzliche Utilities und Protokollerweiterungen, die MCP bietet, um die Entwicklererfahrung zu verbessern und fortgeschrittene Szenarien zu ermöglichen:

- **Konfigurationsoptionen**: MCP erlaubt die dynamische Konfiguration von Sitzungsparametern, wie Tool-Berechtigungen, Ressourcen-Zugriff und Modelleinstellungen, maßgeschneidert für jede Interaktion.
- **Fortschrittsanzeige**: Lang andauernde Operationen können Fortschrittsupdates melden, was reaktionsfähige Benutzeroberflächen und bessere Nutzererfahrung bei komplexen Aufgaben ermöglicht.
- **Abbruch von Anfragen**: Clients können laufende Anfragen abbrechen, sodass Nutzer Vorgänge unterbrechen können, die nicht mehr benötigt werden oder zu lange dauern.
- **Fehlermeldung**: Standardisierte Fehlermeldungen und Codes helfen bei der Diagnose, dem Umgang mit Fehlern und der Bereitstellung umsetzbarer Rückmeldungen für Nutzer und Entwickler.
- **Protokollierung**: Sowohl Clients als auch Server können strukturierte Logs für Auditing, Debugging und Überwachung der Protokollinteraktionen erzeugen.

Durch die Nutzung dieser Protokollfunktionen gewährleistet MCP eine robuste, sichere und flexible Kommunikation zwischen Sprachmodellen und externen Tools oder Datenquellen.

### 🔐 Sicherheitsaspekte

MCP-Implementierungen sollten mehrere zentrale Sicherheitsprinzipien einhalten, um sichere und vertrauenswürdige Interaktionen zu gewährleisten:

- **Nutzerzustimmung und Kontrolle**: Nutzer müssen ausdrücklich zustimmen, bevor Daten abgerufen oder Operationen ausgeführt werden. Sie sollten klare Kontrolle darüber haben, welche Daten geteilt und welche Aktionen autorisiert werden – unterstützt durch intuitive Benutzeroberflächen zur Überprüfung und Genehmigung von Aktivitäten.

- **Datenschutz**: Nutzerdaten dürfen nur mit ausdrücklicher Zustimmung offengelegt werden und müssen durch geeignete Zugriffskontrollen geschützt sein. MCP-Implementierungen müssen unbefugte Datenübertragungen verhindern und sicherstellen, dass die Privatsphäre während aller Interaktionen gewahrt bleibt.

- **Tool-Sicherheit**: Vor jedem Tool-Aufruf ist eine explizite Nutzerzustimmung erforderlich. Nutzer sollten genau verstehen, welche Funktion jedes Tool hat, und robuste Sicherheitsgrenzen müssen durchgesetzt werden, um unbeabsichtigte oder unsichere Tool-Ausführungen zu verhindern.

Durch die Einhaltung dieser Prinzipien sorgt MCP dafür, dass Vertrauen, Datenschutz und Sicherheit der Nutzer über alle Protokollinteraktionen hinweg gewährleistet sind.

## Codebeispiele: Zentrale Komponenten

Im Folgenden findest du Codebeispiele in mehreren populären Programmiersprachen, die zeigen, wie man zentrale MCP-Serverkomponenten und Tools implementiert.

### .NET Beispiel: Einen einfachen MCP-Server mit Tools erstellen

Hier ein praktisches .NET-Codebeispiel, das zeigt, wie man einen einfachen MCP-Server mit benutzerdefinierten Tools implementiert. Das Beispiel demonstriert, wie Tools definiert und registriert, Anfragen verarbeitet und der Server mit dem Model Context Protocol verbunden wird.

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

Dieses Beispiel zeigt denselben MCP-Server und Tool-Registrierung wie das .NET-Beispiel oben, jedoch in Java umgesetzt.

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

In diesem Beispiel zeigen wir, wie man einen MCP-Server in Python aufbaut. Außerdem werden zwei verschiedene Methoden zur Erstellung von Tools vorgestellt.

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

Dieses Beispiel demonstriert die Erstellung eines MCP-Servers in JavaScript und wie zwei wetterbezogene Tools registriert werden.

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

Dieses JavaScript-Beispiel zeigt, wie man einen MCP-Client erstellt, der sich mit einem Server verbindet, einen Prompt sendet und die Antwort einschließlich eventuell ausgeführter Tool-Aufrufe verarbeitet.

## Sicherheit und Autorisierung

MCP beinhaltet mehrere eingebaute Konzepte und Mechanismen zur Verwaltung von Sicherheit und Autorisierung im gesamten Protokoll:

1. **Tool-Berechtigungskontrolle**  
  Clients können festlegen, welche Tools ein Modell während einer Sitzung nutzen darf. So wird sichergestellt, dass nur ausdrücklich autorisierte Tools zugänglich sind, was das Risiko unbeabsichtigter oder unsicherer Operationen verringert. Berechtigungen können dynamisch anhand von Nutzerpräferenzen, organisatorischen Richtlinien oder dem Interaktionskontext konfiguriert werden.

2. **Authentifizierung**  
  Server können vor dem Zugriff auf Tools, Ressourcen oder sensible Operationen eine Authentifizierung verlangen. Dies kann API-Schlüssel, OAuth-Token oder andere Authentifizierungsmethoden umfassen. Eine ordnungsgemäße Authentifizierung stellt sicher, dass nur vertrauenswürdige Clients und Nutzer serverseitige Funktionen aufrufen können.

3. **Validierung**  
  Für alle Tool-Aufrufe wird eine Parameter-Validierung durchgesetzt. Jedes Tool definiert erwartete Typen, Formate und Einschränkungen für seine Parameter, und der Server prüft eingehende Anfragen entsprechend. So werden fehlerhafte oder schädliche Eingaben von Tool-Implementierungen ferngehalten und die Integrität der Operationen gewahrt.

4. **Ratenbegrenzung**  
  Um Missbrauch zu verhindern und eine faire Nutzung der Serverressourcen sicherzustellen, können MCP-Server Ratenbegrenzungen für Tool-Aufrufe und Ressourcen-Zugriffe implementieren. Limits können pro Nutzer, Sitzung oder global gelten und schützen vor Denial-of-Service-Angriffen oder übermäßigem Ressourcenverbrauch.

Durch die Kombination dieser Mechanismen bietet MCP eine sichere Basis für die Integration von Sprachmodellen mit externen Tools und Datenquellen, während Nutzern und Entwicklern eine feingranulare Kontrolle über Zugriff und Nutzung ermöglicht wird.

## Protokollnachrichten

Die MCP-Kommunikation verwendet strukturierte JSON-Nachrichten, um klare und zuverlässige Interaktionen zwischen Clients, Servern und Modellen zu ermöglichen. Die Hauptnachrichtentypen sind:

- **Client-Anfrage**  
  Vom Client an den Server gesendet, enthält diese Nachricht typischerweise:
  - Den Prompt oder Befehl des Nutzers
  - Gesprächshistorie für Kontext
  - Tool-Konfiguration und Berechtigungen
  - Weitere Metadaten oder Sitzungsinformationen

- **Modell-Antwort**  
  Vom Modell (über den Client) zurückgegeben, enthält diese Nachricht:
  - Generierten Text oder Completion basierend auf Prompt und Kontext
  - Optionale Tool-Aufruf-Anweisungen, falls das Modell ein Tool aufrufen möchte
  - Verweise auf Ressourcen oder zusätzlichen Kontext nach Bedarf

- **Tool-Anfrage**  
  Vom Client an den Server gesendet, wenn ein Tool ausgeführt werden muss. Diese Nachricht enthält:
  - Den Namen des aufzurufenden Tools
  - Die vom Tool erwarteten Parameter (validiert anhand des Tool-Schemas)
  - Kontextinformationen oder Identifikatoren zur Nachverfolgung der Anfrage

- **Tool-Antwort**  
  Vom Server nach Ausführung eines Tools zurückgegeben. Diese Nachricht liefert:
  - Die Ergebnisse der Tool-Ausführung (strukturierte Daten oder Inhalte)
  - Fehler- oder Statusinformationen, falls der Tool-Aufruf fehlschlug
  - Optional zusätzliche Metadaten oder Logs zur Ausführung

Diese strukturierten

**Haftungsausschluss**:  
Dieses Dokument wurde mithilfe des KI-Übersetzungsdienstes [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir auf Genauigkeit achten, bitten wir zu beachten, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.