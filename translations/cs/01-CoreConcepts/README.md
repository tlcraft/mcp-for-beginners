<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0a6a7bcb289c024a91289e0444cb370b",
  "translation_date": "2025-08-19T15:26:46+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "cs"
}
-->
# MCP Základní koncepty: Ovládnutí Model Context Protocol pro integraci AI

[![MCP Základní koncepty](../../../translated_images/02.8203e26c6fb5a797f38a10012061013ec66c95bb3260f6c9cfd2bf74b00860e1.cs.png)](https://youtu.be/earDzWGtE84)

_(Klikněte na obrázek výše pro zhlédnutí videa této lekce)_

[Model Context Protocol (MCP)](https://gi- **Explicitní souhlas uživatele**: Veškerý přístup k datům a operace vyžadují explicitní schválení uživatelem před jejich provedením. Uživatelé musí jasně rozumět tomu, jaká data budou přístupná a jaké akce budou provedeny, s možností detailního nastavení oprávnění a autorizací.

- **Ochrana soukromí dat**: Uživatelská data jsou zpřístupněna pouze s explicitním souhlasem a musí být chráněna robustními kontrolami přístupu po celou dobu interakce. Implementace musí zabránit neoprávněnému přenosu dat a udržovat přísné hranice soukromí.

- **Bezpečnost při spuštění nástrojů**: Každé spuštění nástroje vyžaduje explicitní souhlas uživatele s jasným pochopením funkcionality nástroje, parametrů a možného dopadu. Robustní bezpečnostní hranice musí zabránit nechtěnému, nebezpečnému nebo škodlivému spuštění nástroje.

- **Transportní vrstva zabezpečení**: Všechny komunikační kanály by měly používat vhodné šifrovací a autentizační mechanismy. Vzdálené připojení by mělo implementovat bezpečné transportní protokoly a správu přihlašovacích údajů.

#### Pokyny k implementaci:

- **Správa oprávnění**: Implementujte detailní systémy oprávnění, které umožní uživatelům kontrolovat, ke kterým serverům, nástrojům a zdrojům mají přístup  
- **Autentizace a autorizace**: Používejte bezpečné metody autentizace (OAuth, API klíče) s řádnou správou tokenů a jejich expirací  
- **Validace vstupů**: Validujte všechny parametry a vstupy dat podle definovaných schémat, aby se zabránilo útokům typu injekce  
- **Auditní logování**: Udržujte komplexní záznamy všech operací pro monitorování bezpečnosti a dodržování předpisůcom/modelcontextprotocol) je výkonný, standardizovaný rámec, který optimalizuje komunikaci mezi velkými jazykovými modely (LLMs) a externími nástroji, aplikacemi a datovými zdroji. Tento průvodce vás provede základními koncepty MCP, aby vám zajistil pochopení jeho klient-server architektury, klíčových komponent, komunikačních mechanismů a osvědčených postupů implementace.

## Přehled

Tato lekce zkoumá základní architekturu a komponenty, které tvoří ekosystém Model Context Protocol (MCP). Naučíte se o klient-server architektuře, klíčových komponentách a komunikačních mechanismech, které pohánějí interakce MCP.

## Klíčové cíle učení

Na konci této lekce budete:

- Rozumět klient-server architektuře MCP.
- Identifikovat role a odpovědnosti Hostů, Klientů a Serverů.
- Analyzovat klíčové vlastnosti, které dělají MCP flexibilní integrační vrstvou.
- Naučit se, jak informace proudí v ekosystému MCP.
- Získat praktické poznatky prostřednictvím ukázek kódu v .NET, Java, Python a JavaScript.

## MCP Architektura: Podrobnější pohled

Ekosystém MCP je postaven na modelu klient-server. Tato modulární struktura umožňuje AI aplikacím efektivně komunikovat s nástroji, databázemi, API a kontextovými zdroji. Pojďme si rozdělit tuto architekturu na její základní komponenty.

V jádru MCP následuje klient-server architekturu, kde hostitelská aplikace může připojit více serverů:

```mermaid
flowchart LR
    subgraph "Your Computer"
        Host["Host with MCP (Visual Studio, VS Code, IDEs, Tools)"]
        S1["MCP Server A"]
        S2["MCP Server B"]
        S3["MCP Server C"]
        Host <-->|"MCP Protocol"| S1
        Host <-->|"MCP Protocol"| S2
        Host <-->|"MCP Protocol"| S3
        S1 <--> D1[("Local\Data Source A")]
        S2 <--> D2[("Local\Data Source B")]
    end
    subgraph "Internet"
        S3 <-->|"Web APIs"| D3[("Remote\Services")]
    end
```

- **MCP Hosté**: Programy jako VSCode, Claude Desktop, IDE nebo AI nástroje, které chtějí přistupovat k datům prostřednictvím MCP  
- **MCP Klienti**: Protokoloví klienti, kteří udržují 1:1 spojení se servery  
- **MCP Servery**: Lehká programy, které každý vystavují specifické schopnosti prostřednictvím standardizovaného Model Context Protocol  
- **Lokální datové zdroje**: Soubory, databáze a služby vašeho počítače, ke kterým mohou MCP servery bezpečně přistupovat  
- **Vzdálené služby**: Externí systémy dostupné přes internet, ke kterým se MCP servery mohou připojit prostřednictvím API.

Protokol MCP je vyvíjející se standard používající verzování založené na datu (formát YYYY-MM-DD). Aktuální verze protokolu je **2025-06-18**. Nejnovější aktualizace specifikace protokolu najdete [zde](https://modelcontextprotocol.io/specification/2025-06-18/)

### 1. Hosté

V Model Context Protocol (MCP) jsou **Hosté** AI aplikace, které slouží jako primární rozhraní, prostřednictvím kterého uživatelé interagují s protokolem. Hosté koordinují a spravují připojení k více MCP serverům tím, že vytvářejí dedikované MCP klienty pro každé serverové spojení. Příklady Hostů zahrnují:

- **AI aplikace**: Claude Desktop, Visual Studio Code, Claude Code  
- **Vývojová prostředí**: IDE a editory kódu s integrací MCP  
- **Vlastní aplikace**: Speciálně vytvoření AI agenti a nástroje  

**Hosté** jsou aplikace, které koordinují interakce AI modelů. Provádějí:

- **Orchestraci AI modelů**: Spouštění nebo interakci s LLMs za účelem generování odpovědí a koordinace AI pracovních postupů  
- **Správu klientských spojení**: Vytváření a udržování jednoho MCP klienta na každé spojení MCP serveru  
- **Kontrolu uživatelského rozhraní**: Řízení toku konverzace, interakcí uživatele a prezentace odpovědí  
- **Zajištění bezpečnosti**: Kontrola oprávnění, bezpečnostních omezení a autentizace  
- **Správu souhlasu uživatele**: Řízení schválení uživatele pro sdílení dat a spuštění nástrojů  

### 2. Klienti

**Klienti** jsou klíčové komponenty, které udržují dedikované spojení 1:1 mezi Hosty a MCP servery. Každý MCP klient je vytvořen Hostem, aby se připojil ke konkrétnímu MCP serveru, což zajišťuje organizované a bezpečné komunikační kanály. Více klientů umožňuje Hostům připojit se k více serverům současně.

**Klienti** jsou konektorové komponenty v hostitelské aplikaci. Provádějí:

- **Komunikaci protokolu**: Posílání JSON-RPC 2.0 požadavků serverům s výzvami a instrukcemi  
- **Vyjednávání schopností**: Vyjednávání podporovaných funkcí a verzí protokolu se servery během inicializace  
- **Spuštění nástrojů**: Správa požadavků na spuštění nástrojů od modelů a zpracování odpovědí  
- **Aktualizace v reálném čase**: Správa notifikací a aktualizací v reálném čase od serverů  
- **Zpracování odpovědí**: Zpracování a formátování odpovědí serverů pro zobrazení uživatelům  

### 3. Servery

**Servery** jsou programy, které poskytují kontext, nástroje a schopnosti MCP klientům. Mohou být spuštěny lokálně (na stejném zařízení jako Host) nebo vzdáleně (na externích platformách) a jsou odpovědné za zpracování požadavků klientů a poskytování strukturovaných odpovědí. Servery vystavují specifickou funkcionalitu prostřednictvím standardizovaného Model Context Protocol.

**Servery** jsou služby, které poskytují kontext a schopnosti. Provádějí:

- **Registraci funkcí**: Registraci a vystavení dostupných primitiv (zdrojů, výzev, nástrojů) klientům  
- **Zpracování požadavků**: Přijímání a provádění volání nástrojů, požadavků na zdroje a výzev od klientů  
- **Poskytování kontextu**: Poskytování kontextových informací a dat pro zlepšení odpovědí modelu  
- **Správu stavu**: Udržování stavu relace a správa stavových interakcí, pokud je to potřeba  
- **Notifikace v reálném čase**: Posílání notifikací o změnách schopností a aktualizacích připojeným klientům  

Servery mohou být vyvíjeny kýmkoliv, aby rozšířily schopnosti modelu o specializovanou funkcionalitu, a podporují jak lokální, tak vzdálené scénáře nasazení.

### 4. Primitivy serveru

Servery v Model Context Protocol (MCP) poskytují tři základní **primitivy**, které definují základní stavební bloky pro bohaté interakce mezi klienty, hosty a jazykovými modely. Tyto primitivy specifikují typy kontextových informací a akcí dostupných prostřednictvím protokolu.

MCP servery mohou vystavit libovolnou kombinaci následujících tří základních primitiv:

#### Zdroje

**Zdroje** jsou datové zdroje, které poskytují kontextové informace AI aplikacím. Reprezentují statický nebo dynamický obsah, který může zlepšit porozumění modelu a rozhodování:

- **Kontextová data**: Strukturované informace a kontext pro spotřebu AI modelu  
- **Znalostní báze**: Repozitáře dokumentů, články, manuály a výzkumné práce  
- **Lokální datové zdroje**: Soubory, databáze a informace lokálního systému  
- **Externí data**: Odpovědi API, webové služby a data vzdálených systémů  
- **Dynamický obsah**: Data v reálném čase, která se aktualizují na základě externích podmínek  

Zdroje jsou identifikovány pomocí URI a podporují objevování prostřednictvím metod `resources/list` a získávání prostřednictvím `resources/read`:

```text
file://documents/project-spec.md
database://production/users/schema
api://weather/current
```

#### Výzvy

**Výzvy** jsou opakovaně použitelné šablony, které pomáhají strukturovat interakce s jazykovými modely. Poskytují standardizované vzory interakcí a šablonované pracovní postupy:

- **Interakce založené na šablonách**: Předem strukturované zprávy a zahájení konverzací  
- **Šablony pracovních postupů**: Standardizované sekvence pro běžné úkoly a interakce  
- **Příklady few-shot**: Šablony založené na příkladech pro instrukce modelu  
- **Systémové výzvy**: Základní výzvy, které definují chování modelu a kontext  
- **Dynamické šablony**: Šablony s parametry, které se přizpůsobují specifickým kontextům  

Výzvy podporují substituci proměnných a mohou být objeveny prostřednictvím `prompts/list` a získány pomocí `prompts/get`:

```markdown
Generate a {{task_type}} for {{product}} targeting {{audience}} with the following requirements: {{requirements}}
```

#### Nástroje

**Nástroje** jsou spustitelné funkce, které mohou jazykové modely vyvolat k provedení specifických akcí. Reprezentují "slovesa" ekosystému MCP, umožňující modelům interakci s externími systémy:

- **Spustitelné funkce**: Diskrétní operace, které modely mohou vyvolat s konkrétními parametry  
- **Integrace externích systémů**: Volání API, dotazy na databáze, operace se soubory, výpočty  
- **Jedinečná identita**: Každý nástroj má jedinečný název, popis a schéma parametrů  
- **Strukturované I/O**: Nástroje přijímají validované parametry a vracejí strukturované, typované odpovědi  
- **Akční schopnosti**: Umožňují modelům provádět reálné akce a získávat aktuální data  

Nástroje jsou definovány pomocí JSON Schema pro validaci parametrů a objeveny prostřednictvím `tools/list` a spuštěny pomocí `tools/call`:

```typescript
server.tool(
  "search_products", 
  {
    query: z.string().describe("Search query for products"),
    category: z.string().optional().describe("Product category filter"),
    max_results: z.number().default(10).describe("Maximum results to return")
  }, 
  async (params) => {
    // Execute search and return structured results
    return await productService.search(params);
  }
);
```

## Primitivy klienta

V Model Context Protocol (MCP) mohou **klienti** vystavit primitivy, které umožňují serverům požadovat další schopnosti od hostitelské aplikace. Tyto primitivy na straně klienta umožňují bohatší, interaktivnější implementace serverů, které mohou přistupovat ke schopnostem AI modelů a interakcím uživatelů.

### Sampling

**Sampling** umožňuje serverům požadovat dokončení jazykového modelu od AI aplikace klienta. Tento primitiv umožňuje serverům přístup ke schopnostem LLM bez nutnosti vlastních závislostí na modelech:

- **Přístup nezávislý na modelu**: Servery mohou požadovat dokončení bez zahrnutí SDK LLM nebo správy přístupu k modelu  
- **AI iniciované servery**: Umožňuje serverům autonomně generovat obsah pomocí AI modelu klienta  
- **Rekurzivní interakce LLM**: Podporuje složité scénáře, kde servery potřebují AI asistenci pro zpracování  
- **Generování dynamického obsahu**: Umožňuje serverům vytvářet kontextové odpovědi pomocí modelu hostitele  

Sampling je iniciován prostřednictvím metody `sampling/complete`, kde servery posílají požadavky na dokončení klientům.

### Elicitation  

**Elicitation** umožňuje serverům požadovat další informace nebo potvrzení od uživatelů prostřednictvím rozhraní klienta:

- **Požadavky na vstup uživatele**: Servery mohou požádat o další informace potřebné pro spuštění nástroje  
- **Dialogy potvrzení**: Požadavek na schválení uživatele pro citlivé nebo významné operace  
- **Interaktivní pracovní postupy**: Umožňuje serverům vytvářet krok za krokem interakce s uživatelem  
- **Dynamické shromažďování parametrů**: Sběr chybějících nebo volitelných parametrů během spuštění nástroje  

Požadavky na elicitation jsou prováděny pomocí metody `elicitation/request` pro sběr vstupů uživatele prostřednictvím rozhraní klienta.

### Logging

**Logging** umožňuje serverům posílat strukturované logovací zprávy klientům pro ladění, monitorování a viditelnost operací:

- **Podpora ladění**: Umožňuje serverům poskytovat podrobné logy provádění pro odstraňování problémů  
- **Monitorování operací**: Posílání aktualizací stavu a metrik výkonu klientům  
- **Hlášení chyb**: Poskytování podrobného kontextu chyb a diagnostických informací  
- **Auditní stopy**: Vytváření komplexních záznamů operací serveru a rozhodnutí  

Logovací zprávy jsou posílány klientům, aby poskytly transparentnost operací serveru a usnadnily ladění.

## Tok informací v MCP

Model Context Protocol (MCP) definuje strukturovaný tok informací mezi hosty, klienty, servery a modely. Porozumění tomuto toku pomáhá objasnit, jak jsou uživatelské požadavky zpracovány a jak jsou externí nástroje a data integrovány do odpovědí modelu.

- **Host iniciuje spojení**  
  Hostitelská aplikace (například IDE nebo chatovací rozhraní) naváže spojení s MCP serverem, obvykle prostřednictvím STDIO, WebSocket nebo jiného podporovaného transportu.

- **Vyjednávání schopností**  
  Klient (vložený v hostiteli) a server si vyměňují informace o svých podporovaných funkcích, nástrojích, zdrojích a verzích protokolu. To zajišťuje, že obě strany rozumí dostupným schopnostem pro relaci.

- **Požadavek uživatele**  
  Uživatel interaguje s hostem (např. zadá výzvu nebo příkaz). Host shromáždí tento vstup a
- **Správa životního cyklu**: Zajišťuje inicializaci připojení, vyjednávání schopností a ukončení relace mezi klienty a servery  
- **Serverové primitivy**: Umožňuje serverům poskytovat základní funkce prostřednictvím nástrojů, zdrojů a šablon  
- **Klientské primitivy**: Umožňuje serverům požadovat vzorkování od LLM, získávat vstupy od uživatelů a odesílat logovací zprávy  
- **Notifikace v reálném čase**: Podporuje asynchronní notifikace pro dynamické aktualizace bez nutnosti opakovaného dotazování  

#### Klíčové funkce:

- **Vyjednávání verze protokolu**: Používá verzování na základě data (YYYY-MM-DD) pro zajištění kompatibility  
- **Objevování schopností**: Klienti a servery si během inicializace vyměňují informace o podporovaných funkcích  
- **Stavové relace**: Udržuje stav připojení napříč více interakcemi pro zachování kontextu  

### Transportní vrstva

**Transportní vrstva** spravuje komunikační kanály, rámcování zpráv a autentizaci mezi účastníky MCP:

#### Podporované transportní mechanismy:

1. **STDIO Transport**:  
   - Používá standardní vstupní/výstupní proudy pro přímou komunikaci mezi procesy  
   - Optimální pro lokální procesy na stejném zařízení bez síťové režie  
   - Běžně používané pro lokální implementace MCP serverů  

2. **Streamovatelné HTTP Transport**:  
   - Používá HTTP POST pro zprávy od klienta k serveru  
   - Volitelné Server-Sent Events (SSE) pro streamování od serveru ke klientovi  
   - Umožňuje vzdálenou komunikaci se servery přes sítě  
   - Podporuje standardní HTTP autentizaci (bearer tokeny, API klíče, vlastní hlavičky)  
   - MCP doporučuje OAuth pro bezpečnou autentizaci na bázi tokenů  

#### Abstrakce transportu:

Transportní vrstva abstrahuje detaily komunikace od datové vrstvy, což umožňuje použití stejného formátu zpráv JSON-RPC 2.0 napříč všemi transportními mechanismy. Tato abstrakce umožňuje aplikacím snadno přepínat mezi lokálními a vzdálenými servery.

### Bezpečnostní aspekty

Implementace MCP musí dodržovat několik klíčových bezpečnostních principů, aby zajistily bezpečné, důvěryhodné a zabezpečené interakce napříč všemi operacemi protokolu:

- **Souhlas a kontrola uživatele**: Uživatelé musí poskytnout výslovný souhlas před přístupem k jakýmkoli datům nebo provedením operací. Měli by mít jasnou kontrolu nad tím, jaká data jsou sdílena a jaké akce jsou autorizovány, podpořenou intuitivním uživatelským rozhraním pro přezkoumání a schválení aktivit.

- **Ochrana soukromí dat**: Data uživatelů by měla být zpřístupněna pouze s výslovným souhlasem a musí být chráněna vhodnými přístupovými kontrolami. Implementace MCP musí zabránit neoprávněnému přenosu dat a zajistit, že soukromí je zachováno během všech interakcí.

- **Bezpečnost nástrojů**: Před použitím jakéhokoli nástroje je vyžadován výslovný souhlas uživatele. Uživatelé by měli mít jasné pochopení funkcionality každého nástroje a musí být zajištěny robustní bezpečnostní hranice, aby se zabránilo neúmyslnému nebo nebezpečnému spuštění nástrojů.

Dodržováním těchto bezpečnostních principů MCP zajišťuje důvěru uživatelů, ochranu soukromí a bezpečnost napříč všemi interakcemi protokolu, přičemž umožňuje výkonné integrace AI.

## Ukázky kódu: Klíčové komponenty

Níže jsou uvedeny ukázky kódu v několika populárních programovacích jazycích, které ilustrují, jak implementovat klíčové komponenty a nástroje MCP serveru.

### Příklad v .NET: Vytvoření jednoduchého MCP serveru s nástroji

Zde je praktický příklad kódu v .NET, který ukazuje, jak implementovat jednoduchý MCP server s vlastními nástroji. Tento příklad demonstruje, jak definovat a registrovat nástroje, zpracovávat požadavky a připojit server pomocí Model Context Protocol.

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

### Příklad v Javě: Komponenty MCP serveru

Tento příklad demonstruje stejný MCP server a registraci nástrojů jako výše uvedený příklad v .NET, ale implementovaný v Javě.

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

### Příklad v Pythonu: Vytvoření MCP serveru

V tomto příkladu ukazujeme, jak vytvořit MCP server v Pythonu. Jsou zde také ukázány dva různé způsoby, jak vytvořit nástroje.

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

### Příklad v JavaScriptu: Vytvoření MCP serveru

Tento příklad ukazuje vytvoření MCP serveru v JavaScriptu a jak registrovat dva nástroje související s počasím.

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

Tento příklad v JavaScriptu demonstruje, jak vytvořit MCP klienta, který se připojí k serveru, odešle výzvu a zpracuje odpověď včetně jakýchkoli volání nástrojů.

## Bezpečnost a autorizace

MCP zahrnuje několik vestavěných konceptů a mechanismů pro správu bezpečnosti a autorizace v rámci protokolu:

1. **Kontrola oprávnění nástrojů**:  
   Klienti mohou specifikovat, které nástroje může model během relace používat. To zajišťuje, že jsou přístupné pouze výslovně autorizované nástroje, čímž se snižuje riziko neúmyslných nebo nebezpečných operací. Oprávnění lze dynamicky konfigurovat na základě preferencí uživatele, organizačních politik nebo kontextu interakce.

2. **Autentizace**:  
   Servery mohou vyžadovat autentizaci před udělením přístupu k nástrojům, zdrojům nebo citlivým operacím. To může zahrnovat API klíče, OAuth tokeny nebo jiné autentizační schémata. Správná autentizace zajišťuje, že pouze důvěryhodní klienti a uživatelé mohou využívat schopnosti serveru.

3. **Validace**:  
   Validace parametrů je vynucována pro všechna volání nástrojů. Každý nástroj definuje očekávané typy, formáty a omezení pro své parametry a server validuje příchozí požadavky odpovídajícím způsobem. To zabraňuje tomu, aby se k implementacím nástrojů dostaly chybné nebo škodlivé vstupy, a pomáhá udržovat integritu operací.

4. **Omezení rychlosti**:  
   Aby se zabránilo zneužití a zajistilo spravedlivé využití serverových zdrojů, mohou MCP servery implementovat omezení rychlosti pro volání nástrojů a přístup ke zdrojům. Omezení rychlosti lze aplikovat na uživatele, relace nebo globálně a pomáhají chránit před útoky typu denial-of-service nebo nadměrným využíváním zdrojů.

Kombinací těchto mechanismů poskytuje MCP bezpečný základ pro integraci jazykových modelů s externími nástroji a datovými zdroji, přičemž uživatelům a vývojářům nabízí detailní kontrolu nad přístupem a využitím.

## Zprávy protokolu a tok komunikace

Komunikace MCP využívá strukturované zprávy **JSON-RPC 2.0** k usnadnění jasných a spolehlivých interakcí mezi hostiteli, klienty a servery. Protokol definuje specifické vzory zpráv pro různé typy operací:

### Základní typy zpráv:

#### **Inicializační zprávy**
- **`initialize` Požadavek**: Navazuje připojení a vyjednává verzi protokolu a schopnosti  
- **`initialize` Odpověď**: Potvrzuje podporované funkce a informace o serveru  
- **`notifications/initialized`**: Signalizuje, že inicializace je dokončena a relace je připravena  

#### **Zprávy pro objevování**
- **`tools/list` Požadavek**: Zjišťuje dostupné nástroje na serveru  
- **`resources/list` Požadavek**: Vypisuje dostupné zdroje (datové zdroje)  
- **`prompts/list` Požadavek**: Získává dostupné šablony výzev  

#### **Zprávy pro provádění**  
- **`tools/call` Požadavek**: Spouští konkrétní nástroj s poskytnutými parametry  
- **`resources/read` Požadavek**: Získává obsah z konkrétního zdroje  
- **`prompts/get` Požadavek**: Načítá šablonu výzvy s volitelnými parametry  

#### **Zprávy na straně klienta**
- **`sampling/complete` Požadavek**: Server požaduje dokončení LLM od klienta  
- **`elicitation/request`**: Server požaduje vstup uživatele prostřednictvím klientského rozhraní  
- **Logovací zprávy**: Server odesílá strukturované logovací zprávy klientovi  

#### **Notifikační zprávy**
- **`notifications/tools/list_changed`**: Server upozorňuje klienta na změny nástrojů  
- **`notifications/resources/list_changed`**: Server upozorňuje klienta na změny zdrojů  
- **`notifications/prompts/list_changed`**: Server upozorňuje klienta na změny šablon  

### Struktura zpráv:

Všechny zprávy MCP dodržují formát JSON-RPC 2.0 s:  
- **Požadavky**: Obsahují `id`, `method` a volitelné `params`  
- **Odpovědi**: Obsahují `id` a buď `result`, nebo `error`  
- **Notifikace**: Obsahují `method` a volitelné `params` (bez `id` nebo očekávané odpovědi)  

Tato strukturovaná komunikace zajišťuje spolehlivé, sledovatelné a rozšiřitelné interakce podporující pokročilé scénáře, jako jsou aktualizace v reálném čase, řetězení nástrojů a robustní zpracování chyb.

## Klíčové poznatky

- **Architektura**: MCP využívá architekturu klient-server, kde hostitelé spravují více připojení klientů k serverům  
- **Účastníci**: Ekosystém zahrnuje hostitele (AI aplikace), klienty (konektory protokolu) a servery (poskytovatele schopností)  
- **Transportní mechanismy**: Komunikace podporuje STDIO (lokální) a Streamovatelné HTTP s volitelným SSE (vzdálené)  
- **Základní primitivy**: Servery zpřístupňují nástroje (spustitelné funkce), zdroje (datové zdroje) a šablony (výzvy)  
- **Klientské primitivy**: Servery mohou požadovat vzorkování (LLM dokončení), získávání vstupů (uživatelský vstup) a logování od klientů  
- **Základ protokolu**: Postaveno na JSON-RPC 2.0 s verzováním na základě data (aktuální: 2025-06-18)  
- **Schopnosti v reálném čase**: Podporuje notifikace pro dynamické aktualizace a synchronizaci v reálném čase  
- **Bezpečnost na prvním místě**: Výslovný souhlas uživatele, ochrana soukromí dat a zabezpečený transport jsou klíčové požadavky  

## Cvičení

Navrhněte jednoduchý MCP nástroj, který by byl užitečný ve vašem oboru. Definujte:  
1. Jak by se nástroj jmenoval  
2. Jaké parametry by přijímal  
3. Jaký výstup by vracel  
4. Jak by model mohl tento nástroj použít k řešení problémů uživatele  

---

## Co dál

Další: [Kapitola 2: Bezpečnost](../02-Security/README.md)

**Upozornění**:  
Tento dokument byl přeložen pomocí služby pro automatický překlad [Co-op Translator](https://github.com/Azure/co-op-translator). I když se snažíme o co největší přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Za autoritativní zdroj by měl být považován původní dokument v jeho původním jazyce. Pro důležité informace doporučujeme profesionální lidský překlad. Neodpovídáme za žádná nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.