<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "154c00dc3b2c792102e4845c19fbd166",
  "translation_date": "2025-05-20T17:51:22+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "tl"
}
-->
# 📖 MCP Core Concepts: Mastering the Model Context Protocol for AI Integration

Ang Model Context Protocol (MCP) ay isang malakas at standardisadong framework na nagpapahusay ng komunikasyon sa pagitan ng Large Language Models (LLMs) at mga external na tools, aplikasyon, at mga pinagkukunan ng datos. Ang gabay na ito, na SEO-optimized, ay magtuturo sa iyo ng mga pangunahing konsepto ng MCP, upang maintindihan mo ang client-server architecture nito, mga mahahalagang bahagi, mekanismo ng komunikasyon, at mga pinakamahusay na praktis sa implementasyon.

## Overview

Tatalakayin sa araling ito ang pundamental na arkitektura at mga bahagi na bumubuo sa Model Context Protocol (MCP) ecosystem. Malalaman mo ang tungkol sa client-server architecture, mga pangunahing bahagi, at mga mekanismo ng komunikasyon na nagpapatakbo sa mga MCP interaction.

## 👩‍🎓 Mga Pangunahing Layunin ng Pagkatuto

Pagkatapos ng araling ito, magagawa mong:

- Maintindihan ang MCP client-server architecture.
- Tukuyin ang mga tungkulin at responsibilidad ng Hosts, Clients, at Servers.
- Suriin ang mga pangunahing katangian na nagpapaluwag sa MCP bilang integration layer.
- Matutunan kung paano dumadaloy ang impormasyon sa loob ng MCP ecosystem.
- Makakuha ng praktikal na kaalaman gamit ang mga code examples sa .NET, Java, Python, at JavaScript.

## 🔎 MCP Architecture: Mas Malalim na Pagsilip

Ang MCP ecosystem ay nakabatay sa client-server model. Ang modular na istrukturang ito ay nagpapahintulot sa mga AI application na makipag-ugnayan sa mga tools, databases, APIs, at mga contextual resources nang mas epektibo. Hatiin natin ang arkitekturang ito sa mga pangunahing bahagi.

### 1. Hosts

Sa Model Context Protocol (MCP), ang Hosts ay may mahalagang papel bilang pangunahing interface kung saan nakikipag-ugnayan ang mga user sa protocol. Ang Hosts ay mga aplikasyon o kapaligiran na nag-uumpisa ng koneksyon sa MCP servers upang ma-access ang data, tools, at prompts. Halimbawa ng Hosts ay ang mga integrated development environments (IDEs) tulad ng Visual Studio Code, mga AI tools tulad ng Claude Desktop, o mga custom-built na agents para sa partikular na mga gawain.

**Ang Hosts** ay mga LLM application na nag-uumpisa ng koneksyon. Sila ay:

- Nagpapatakbo o nakikipag-ugnayan sa AI models upang makabuo ng mga sagot.
- Nag-uumpisa ng koneksyon sa MCP servers.
- Namamahala sa daloy ng usapan at user interface.
- Kinokontrol ang mga permiso at mga security constraints.
- Nangangalaga ng pahintulot ng user para sa pagbabahagi ng data at pagpapatakbo ng tools.

### 2. Clients

Ang Clients ay mahahalagang bahagi na nagpapadali sa interaksyon sa pagitan ng Hosts at MCP servers. Gumaganap ang Clients bilang mga tagapamagitan, na nagpapahintulot sa Hosts na ma-access at magamit ang mga kakayahan ng MCP servers. Mahalaga ang kanilang papel sa pagtiyak ng maayos na komunikasyon at episyenteng palitan ng datos sa loob ng MCP architecture.

**Ang Clients** ay mga connector sa loob ng host application. Sila ay:

- Nagpapadala ng mga request sa servers kasama ang prompts/instructions.
- Nakikipagnegosasyon sa mga kakayahan ng servers.
- Namamahala ng mga kahilingan para sa pagpapatakbo ng tools mula sa mga modelo.
- Nagpoproseso at nagpapakita ng mga sagot sa mga user.

### 3. Servers

Ang Servers ay responsable sa paghawak ng mga request mula sa MCP clients at pagbibigay ng angkop na mga sagot. Pinamamahalaan nila ang iba't ibang operasyon tulad ng pagkuha ng datos, pagpapatakbo ng mga tool, at paggawa ng prompts. Tinitiyak ng Servers na ang komunikasyon sa pagitan ng clients at Hosts ay episyente at maaasahan, pinananatili ang integridad ng proseso ng interaksyon.

**Ang Servers** ay mga serbisyo na nagbibigay ng konteksto at mga kakayahan. Sila ay:

- Nagrerehistro ng mga available na features (resources, prompts, tools)
- Tumanggap at nagpapatupad ng mga tool calls mula sa client
- Nagbibigay ng contextual information para mapahusay ang mga sagot ng modelo
- Nagbabalik ng output pabalik sa client
- Nagpapanatili ng estado sa mga interaksyon kapag kinakailangan

Maaaring gawin ng sinuman ang mga Servers upang palawakin ang kakayahan ng modelo gamit ang espesyal na functionality.

### 4. Server Features

Ang mga Server sa Model Context Protocol (MCP) ay nagbibigay ng mga pangunahing bahagi na nagpapahintulot ng malalim na interaksyon sa pagitan ng clients, hosts, at mga language model. Dinisenyo ang mga ito upang mapahusay ang kakayahan ng MCP sa pamamagitan ng pagbibigay ng istrukturadong konteksto, tools, at prompts.

Maaaring mag-alok ang MCP servers ng alinman sa mga sumusunod na features:

#### 📑 Resources

Saklaw ng Resources sa Model Context Protocol (MCP) ang iba't ibang uri ng konteksto at datos na maaaring gamitin ng mga user o AI models. Kasama rito ang:

- **Contextual Data**: Impormasyon at konteksto na maaaring gamitin ng mga user o AI models para sa paggawa ng desisyon at pagsasagawa ng mga gawain.
- **Knowledge Bases at Document Repositories**: Mga koleksyon ng istrukturado at hindi istrukturadong datos, tulad ng mga artikulo, manwal, at mga research paper, na nagbibigay ng mahahalagang kaalaman at impormasyon.
- **Local Files at Databases**: Datos na nakaimbak lokal sa mga device o sa loob ng mga database, na maaaring gamitin para sa pagproseso at pagsusuri.
- **APIs at Web Services**: Mga external na interface at serbisyo na nag-aalok ng dagdag na datos at functionality, na nagpapahintulot sa integrasyon sa iba't ibang online resources at tools.

Halimbawa ng resource ay maaaring isang database schema o isang file na maaaring ma-access tulad nito:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Kasama sa Prompts sa Model Context Protocol (MCP) ang iba't ibang pre-defined na mga template at pattern ng interaksyon na dinisenyo upang pasimplehin ang workflow ng user at mapabuti ang komunikasyon. Kasama rito ang:

- **Templated Messages at Workflows**: Mga paunang istrukturadong mensahe at proseso na gumagabay sa mga user sa mga partikular na gawain at interaksyon.
- **Pre-defined Interaction Patterns**: Standardisadong mga sunod-sunod na aksyon at sagot na nagpapadali ng pare-pareho at episyenteng komunikasyon.
- **Specialized Conversation Templates**: Mga template na na-customize para sa partikular na uri ng pag-uusap, na tinitiyak na ang interaksyon ay may kaugnayan at angkop sa konteksto.

Ganito ang hitsura ng isang prompt template:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Tools

Ang Tools sa Model Context Protocol (MCP) ay mga function na maaaring patakbuhin ng AI model para magsagawa ng partikular na gawain. Dinisenyo ang mga tools na ito upang mapahusay ang kakayahan ng AI model sa pamamagitan ng pagbibigay ng istrukturado at maaasahang operasyon. Mga pangunahing aspeto nito ay:

- **Mga function na maaaring patakbuhin ng AI model**: Ang tools ay mga executable na function na maaaring tawagin ng AI model para magsagawa ng iba't ibang gawain.
- **Natanging Pangalan at Deskripsyon**: Bawat tool ay may natatanging pangalan at detalyadong paglalarawan na nagpapaliwanag ng layunin at functionality nito.
- **Mga Parameter at Output**: Tumatanggap ang tools ng partikular na mga parameter at nagbabalik ng istrukturadong output, na tinitiyak ang consistent at predictable na resulta.
- **Mga Hiwa-hiwalay na Function**: Ang mga tools ay nagsasagawa ng mga hiwa-hiwalay na function tulad ng web search, kalkulasyon, at database query.

Ganito ang hitsura ng isang halimbawa ng tool:

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

## Client Features

Sa Model Context Protocol (MCP), nag-aalok ang mga client ng ilang mahahalagang feature sa mga server upang mapahusay ang pangkalahatang functionality at interaksyon sa loob ng protocol. Isa sa mga kilalang feature ay ang Sampling.

### 👉 Sampling

- **Server-Initiated Agentic Behaviors**: Pinapayagan ng clients ang servers na mag-umpisa ng mga partikular na aksyon o pag-uugali nang autonomously, na nagpapalawak ng dynamic na kakayahan ng sistema.
- **Recursive LLM Interactions**: Pinahihintulutan ng feature na ito ang recursive na interaksyon sa mga large language models (LLMs), na nagpapahintulot ng mas kumplikado at paulit-ulit na pagproseso ng mga gawain.
- **Requesting Additional Model Completions**: Maaaring humiling ang servers ng karagdagang mga sagot mula sa modelo, upang matiyak na ang mga tugon ay masusing at naaayon sa konteksto.

## Daloy ng Impormasyon sa MCP

Itinatakda ng Model Context Protocol (MCP) ang istrukturadong daloy ng impormasyon sa pagitan ng hosts, clients, servers, at models. Ang pag-unawa sa daloy na ito ay nakakatulong upang linawin kung paano pinoproseso ang mga kahilingan ng user at kung paano isinama ang mga external na tools at datos sa mga sagot ng modelo.

- **Host Nag-uumpisa ng Koneksyon**  
  Ang host application (tulad ng IDE o chat interface) ay nagtatatag ng koneksyon sa isang MCP server, karaniwang gamit ang STDIO, WebSocket, o iba pang suportadong transport.

- **Capability Negotiation**  
  Nagpapalitan ang client (na naka-embed sa host) at server ng impormasyon tungkol sa mga suportadong features, tools, resources, at mga bersyon ng protocol. Tinitiyak nito na pareho nilang nauunawaan ang mga kakayahang available para sa session.

- **User Request**  
  Nakikipag-ugnayan ang user sa host (halimbawa, naglalagay ng prompt o command). Kinokolekta ng host ang input na ito at ipinapasa ito sa client para iproseso.

- **Paggamit ng Resource o Tool**  
  - Maaaring humiling ang client ng dagdag na konteksto o resources mula sa server (tulad ng mga file, database entries, o knowledge base articles) upang mapalawak ang pag-unawa ng modelo.
  - Kapag natukoy ng modelo na kailangan ang isang tool (halimbawa, para kumuha ng datos, magsagawa ng kalkulasyon, o tumawag ng API), nagpapadala ang client ng kahilingan para sa tool invocation sa server, kasama ang pangalan ng tool at mga parameter.

- **Pagpapatupad ng Server**  
  Tinatanggap ng server ang kahilingan para sa resource o tool, isinasagawa ang kinakailangang operasyon (tulad ng pagpapatakbo ng function, pag-query sa database, o pagkuha ng file), at ibinabalik ang resulta sa client sa isang istrukturadong format.

- **Pagbuo ng Sagot**  
  Pinagsasama ng client ang mga sagot mula sa server (data ng resource, output ng tool, atbp.) sa kasalukuyang interaksyon ng modelo. Ginagamit ng modelo ang impormasyong ito upang makabuo ng komprehensibo at kontekstwal na angkop na sagot.

- **Pagpapakita ng Resulta**  
  Natatanggap ng host ang huling output mula sa client at ipinapakita ito sa user, kadalasan kasama ang teksto na ginawa ng modelo at anumang resulta mula sa pagpapatakbo ng tool o pagkuha ng resource.

Pinapahintulutan ng daloy na ito ang MCP na suportahan ang advanced, interactive, at context-aware na AI applications sa pamamagitan ng seamless na pagkonekta ng mga modelo sa mga external na tools at pinagkukunan ng datos.

## Detalye ng Protocol

Ang MCP (Model Context Protocol) ay nakabatay sa [JSON-RPC 2.0](https://www.jsonrpc.org/), na nagbibigay ng standardized, language-agnostic na format ng mensahe para sa komunikasyon sa pagitan ng hosts, clients, at servers. Pinapahintulutan nito ang maaasahan, istrukturado, at extensible na interaksyon sa iba't ibang platform at programming languages.

### Mga Pangunahing Katangian ng Protocol

Pinalalawig ng MCP ang JSON-RPC 2.0 gamit ang karagdagang mga convention para sa tool invocation, resource access, at prompt management. Sinusuportahan nito ang iba't ibang transport layers (STDIO, WebSocket, SSE) at nagpapahintulot ng secure, extensible, at language-agnostic na komunikasyon sa pagitan ng mga bahagi.

#### 🧢 Base Protocol

- **JSON-RPC Message Format**: Lahat ng request at response ay gumagamit ng JSON-RPC 2.0 specification, na tinitiyak ang consistent na istruktura para sa mga tawag sa method, mga parameter, resulta, at paghawak ng error.
- **Stateful Connections**: Pinananatili ng MCP sessions ang estado sa maraming request, sumusuporta sa tuloy-tuloy na usapan, pag-ipon ng konteksto, at pamamahala ng resource.
- **Capability Negotiation**: Sa pagsisimula ng koneksyon, nagpapalitan ang clients at servers ng impormasyon tungkol sa mga suportadong feature, mga bersyon ng protocol, available na tools, at resources. Tinitiyak nito na parehong nauunawaan ng magkabilang panig ang kakayahan ng isa't isa at makakapag-adjust nang naaayon.

#### ➕ Karagdagang Utilities

Narito ang ilang karagdagang utilities at extension ng protocol na ibinibigay ng MCP upang mapabuti ang karanasan ng developer at suportahan ang mga advanced na scenario:

- **Configuration Options**: Pinapayagan ng MCP ang dynamic na configuration ng mga parameter ng session, tulad ng permiso sa tools, access sa resources, at mga setting ng modelo, na iniangkop sa bawat interaksyon.
- **Progress Tracking**: Maaaring mag-ulat ng progreso ang mga long-running na operasyon, na nagpapahintulot ng responsive na user interface at mas magandang karanasan sa mga komplikadong gawain.
- **Request Cancellation**: Maaaring kanselahin ng clients ang mga kasalukuyang request, na nagbibigay-daan sa mga user na ihinto ang mga operasyon na hindi na kailangan o masyadong matagal.
- **Error Reporting**: Standardisadong mga mensahe ng error at mga code ang tumutulong sa pag-diagnose ng problema, maayos na paghawak ng pagkabigo, at pagbibigay ng actionable feedback sa mga user at developer.
- **Logging**: Parehong clients at servers ay maaaring maglabas ng istrukturadong log para sa auditing, debugging, at pagmamanman ng mga interaksyon sa protocol.

Sa paggamit ng mga katangiang ito, tinitiyak ng MCP ang matatag, ligtas, at flexible na komunikasyon sa pagitan ng mga language model at mga external na tools o pinagkukunan ng datos.

### 🔐 Mga Pagsasaalang-alang sa Seguridad

Dapat sundin ng mga implementasyon ng MCP ang ilang mahahalagang prinsipyo sa seguridad upang matiyak ang ligtas at mapagkakatiwalaang interaksyon:

- **Pahintulot at Kontrol ng User**: Dapat magbigay ang mga user ng malinaw na pahintulot bago ma-access ang anumang data o maisagawa ang mga operasyon. Dapat mayroon silang malinaw na kontrol kung anong data ang ibabahagi at kung aling mga aksyon ang pinapayagan, suportado ng mga madaling gamitin na interface para sa pagrepaso at pag-apruba ng mga gawain.

- **Pribadong Datos**: Ang datos ng user ay dapat ibunyag lamang kapag may malinaw na pahintulot at dapat protektado ng angkop na access control. Dapat siguraduhin ng mga implementasyon ng MCP na walang hindi awtorisadong transmisyon ng data at mapanatili ang privacy sa lahat ng interaksyon.

- **Kaligtasan ng Tools**: Bago tumawag ng anumang tool, kinakailangan ang malinaw na pahintulot ng user. Dapat malinaw sa user ang functionality ng bawat tool, at dapat ipatupad ang matibay na mga hangganan sa seguridad upang maiwasan ang hindi inaasahan o delikadong pagpapatakbo ng mga tool.

Sa pagsunod sa mga prinsipyong ito, tinitiyak ng MCP na mapanatili ang tiwala, privacy, at kaligtasan ng user sa lahat ng interaksyon sa protocol.

## Mga Halimbawa ng Code: Mga Pangunahing Bahagi

Narito ang mga halimbawa ng code sa ilang sikat na programming languages na nagpapakita kung paano i-implement ang mga pangunahing bahagi ng MCP server at mga tools.

### Halimbawa sa .NET: Paglikha ng Simpleng MCP Server na may Tools

Ito ay isang praktikal na halimbawa sa .NET na nagpapakita kung paano gumawa ng simpleng MCP server na may custom tools. Ipinapakita nito kung paano ideklara at irehistro ang mga tools, hawakan ang mga request, at ikonekta ang server gamit ang Model Context Protocol.

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

### Halimbawa sa Java: MCP Server Components

Ipinapakita ng halimbawa na ito ang parehong MCP server at tool registration tulad ng halimbawa sa .NET sa itaas, ngunit ipinatupad sa Java.

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

### Halimbawa sa Python: Pagbuo ng MCP Server

Sa halimbawang ito, ipinapakita kung paano bumuo ng MCP server sa Python. Ipinapakita rin dito ang dalawang magkaibang paraan ng paggawa ng tools.

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

### Halimbawa sa JavaScript: Paglikha ng MCP Server

Ipinapakita ng halimbawang ito ang paglikha ng MCP server sa JavaScript at kung paano magrehistro ng dalawang tool na may kaugnayan sa panahon.

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

Ipinapakita rin ng halimbawang JavaScript na ito kung paano gumawa ng MCP client na kumokonekta sa server, nagpapadala ng prompt, at nagpoproseso ng sagot kasama ang anumang tool calls na ginawa.

## Seguridad at Awtorisasyon

Kasama sa MCP ang ilang built-in na konsepto at mekanismo para sa pamamahala ng seguridad at awtorisasyon sa buong protocol:

1. **Kontrol sa Pahintulot ng Tool**:  
  Maaaring tukuyin ng clients kung aling mga tool ang pinapayagang gamitin ng modelo sa panahon

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami na maging tumpak, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi pagkakatugma. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na opisyal na sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.