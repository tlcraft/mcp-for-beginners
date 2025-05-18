<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "788eb17750e970a0bc3b5e7f2e99975b",
  "translation_date": "2025-05-18T15:28:49+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "tl"
}
-->
# 📖 MCP Core Concepts: Mastering the Model Context Protocol for AI Integration

Ang Model Context Protocol (MCP) ay isang malakas at standardized na framework na nag-o-optimize ng komunikasyon sa pagitan ng Large Language Models (LLMs) at mga external na tools, applications, at data sources. Ang SEO-optimized na gabay na ito ay maglalakad sa'yo sa mga pangunahing konsepto ng MCP, tinitiyak na maiintindihan mo ang client-server architecture nito, mga mahahalagang bahagi, mekanismo ng komunikasyon, at mga best practice sa implementasyon.

## Overview

Tinutuklas ng leksyong ito ang pundamental na arkitektura at mga bahagi na bumubuo sa Model Context Protocol (MCP) ecosystem. Matututuhan mo ang client-server architecture, mga pangunahing bahagi, at mekanismo ng komunikasyon na nagpapatakbo sa MCP interactions.

## 👩‍🎓 Key Learning Objectives

Pagkatapos ng leksyong ito, magagawa mong:

- Maunawaan ang MCP client-server architecture.
- Matukoy ang mga papel at responsibilidad ng Hosts, Clients, at Servers.
- Suriin ang mga pangunahing tampok na nagpapalawak ng flexibility ng MCP bilang integration layer.
- Matutunan kung paano dumadaloy ang impormasyon sa loob ng MCP ecosystem.
- Makakuha ng praktikal na kaalaman sa pamamagitan ng mga code example sa .NET, Java, Python, at JavaScript.

## 🔎 MCP Architecture: A Deeper Look

Ang MCP ecosystem ay nakabase sa client-server model. Ang modular na istrukturang ito ay nagpapahintulot sa AI applications na makipag-ugnayan sa mga tools, databases, APIs, at contextual resources nang epektibo. Hatiin natin ang arkitekturang ito sa mga pangunahing bahagi.

### 1. Hosts

Sa Model Context Protocol (MCP), mahalaga ang papel ng Hosts bilang pangunahing interface kung saan nakikipag-ugnayan ang mga user sa protocol. Ang Hosts ay mga aplikasyon o environment na nagsisimula ng koneksyon sa MCP servers para ma-access ang data, tools, at prompts. Halimbawa ng Hosts ay mga integrated development environments (IDEs) tulad ng Visual Studio Code, AI tools gaya ng Claude Desktop, o mga custom-built agents na ginawa para sa partikular na gawain.

**Hosts** ay mga LLM application na nagsisimula ng koneksyon. Sila ay:

- Nag-eexecute o nakikipag-interact sa AI models para gumawa ng mga sagot.
- Nagsisimula ng koneksyon sa MCP servers.
- Namamahala sa daloy ng usapan at user interface.
- Kinokontrol ang permission at security constraints.
- Humahawak ng user consent para sa data sharing at tool execution.

### 2. Clients

Ang Clients ay mahalagang bahagi na nagpapadali ng interaksyon sa pagitan ng Hosts at MCP servers. Gumaganap ang Clients bilang mga tagapamagitan, pinapahintulutan ang Hosts na ma-access at magamit ang mga functionality na ibinibigay ng MCP servers. Mahalaga ang papel nila sa maayos na komunikasyon at epektibong palitan ng data sa loob ng MCP architecture.

**Clients** ay mga connector sa loob ng host application. Sila ay:

- Nagpapadala ng requests sa servers kasama ang prompts/instructions.
- Nakikipag-negosasyon ng capabilities sa servers.
- Namamahala ng mga tool execution requests mula sa models.
- Nagpo-proseso at nagpapakita ng mga sagot sa mga user.

### 3. Servers

Ang Servers ang responsable sa paghawak ng mga request mula sa MCP clients at pagbibigay ng angkop na tugon. Pinangangasiwaan nila ang iba't ibang operasyon tulad ng pagkuha ng data, pag-eexecute ng tools, at paggawa ng prompts. Tinitiyak ng Servers na ang komunikasyon sa pagitan ng clients at Hosts ay epektibo at maaasahan, pinananatili ang integridad ng proseso ng interaksyon.

**Servers** ay mga serbisyo na nagbibigay ng context at capabilities. Sila ay:

- Nagrerehistro ng mga available na features (resources, prompts, tools).
- Tumanggap at nag-eexecute ng tool calls mula sa client.
- Nagbibigay ng contextual na impormasyon para mapabuti ang mga sagot ng model.
- Nagbabalik ng output pabalik sa client.
- Nananatili ang estado sa mga interaksyon kung kinakailangan.

Maaaring gawin ng kahit sino ang mga Servers para palawakin ang kakayahan ng model gamit ang espesyal na functionality.

### 4. Server Features

Ang mga Servers sa Model Context Protocol (MCP) ay nagbibigay ng mga pundamental na bahagi na nagpapahintulot ng malalim na interaksyon sa pagitan ng clients, hosts, at language models. Dinisenyo ang mga tampok na ito upang mapahusay ang kakayahan ng MCP sa pamamagitan ng pagbibigay ng structured context, tools, at prompts.

Maaaring mag-alok ang MCP servers ng alinman sa mga sumusunod na features:

#### 📑 Resources

Ang Resources sa Model Context Protocol (MCP) ay sumasaklaw sa iba't ibang uri ng context at data na maaaring gamitin ng mga user o AI models. Kasama dito ang:

- **Contextual Data**: Impormasyon at konteksto na maaaring gamitin ng user o AI models para sa paggawa ng desisyon at pagsasagawa ng mga gawain.
- **Knowledge Bases and Document Repositories**: Koleksyon ng structured at unstructured data, tulad ng mga artikulo, manwal, at research papers, na nagbibigay ng mahalagang impormasyon.
- **Local Files and Databases**: Data na nakaimbak sa lokal na device o databases na maaaring gamitin para sa pagproseso at pagsusuri.
- **APIs and Web Services**: Mga external na interface at serbisyo na nag-aalok ng dagdag na data at functionality, na nagpapahintulot ng integrasyon sa iba't ibang online resources at tools.

Halimbawa ng resource ay maaaring isang database schema o file na maaaring ma-access tulad nito:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Ang Prompts sa Model Context Protocol (MCP) ay kinabibilangan ng iba't ibang pre-defined na templates at interaction patterns na dinisenyo para gawing mas madali ang user workflows at mapabuti ang komunikasyon. Kasama dito ang:

- **Templated Messages and Workflows**: Pre-istrukturang mga mensahe at proseso na gumagabay sa user sa partikular na mga gawain at interaksyon.
- **Pre-defined Interaction Patterns**: Standard na mga pagkakasunod-sunod ng mga aksyon at tugon na nagpapadali ng consistent at epektibong komunikasyon.
- **Specialized Conversation Templates**: Mga template na maaaring i-customize para sa partikular na uri ng pag-uusap, na tinitiyak ang kaugnayan at angkop na konteksto.

Ganito ang itsura ng isang prompt template:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Tools

Ang Tools sa Model Context Protocol (MCP) ay mga function na maaaring i-execute ng AI model para magsagawa ng partikular na mga gawain. Dinisenyo ang mga tools na ito para mapalawak ang kakayahan ng AI model sa pamamagitan ng pagbibigay ng structured at maaasahang operasyon. Mga pangunahing aspeto nito ay:

- **Mga Function na Pwedeng I-execute ng AI Model**: Ang mga tools ay mga function na maaaring tawagin ng AI model para gawin ang iba't ibang gawain.
- **Natanging Pangalan at Deskripsyon**: Bawat tool ay may kakaibang pangalan at detalyadong paglalarawan ng layunin at functionality nito.
- **Mga Parameter at Output**: Tumanggap ang mga tools ng partikular na mga parameter at nagbabalik ng structured na output para sa consistent at predictable na resulta.
- **Discrete Functions**: Gumaganap ang tools ng mga discrete na gawain tulad ng web searches, kalkulasyon, at database queries.

Ganito ang itsura ng isang halimbawa ng tool:

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

## Client Features

Sa Model Context Protocol (MCP), nag-aalok ang mga clients ng ilang mahahalagang features sa servers para mapabuti ang kabuuang functionality at interaksyon sa protocol. Isa sa mga kapansin-pansin na feature ay ang Sampling.

### 👉 Sampling

- **Server-Initiated Agentic Behaviors**: Pinapahintulutan ng clients ang servers na mag-umpisa ng partikular na mga aksyon o kilos nang autonomously, na nagpapalawak sa dynamic capabilities ng sistema.
- **Recursive LLM Interactions**: Pinapayagan ng feature na ito ang recursive na interaksyon sa mga malalaking language models (LLMs), na nagpapahintulot ng mas kumplikado at paulit-ulit na pagproseso ng mga gawain.
- **Requesting Additional Model Completions**: Maaaring humiling ang servers ng karagdagang mga sagot mula sa model para matiyak na kumpleto at kontekstwal ang mga tugon.

## Information Flow in MCP

Itinatakda ng Model Context Protocol (MCP) ang isang istrukturadong daloy ng impormasyon sa pagitan ng hosts, clients, servers, at models. Ang pag-unawa sa daloy na ito ay nakakatulong para malinawan kung paano pinoproseso ang mga user request at paano iniintegrate ang mga external tools at data sa mga sagot ng model.

- **Host Initiates Connection**  
  Ang host application (tulad ng IDE o chat interface) ay nagtatatag ng koneksyon sa MCP server, karaniwan gamit ang STDIO, WebSocket, o iba pang suportadong transport.

- **Capability Negotiation**  
  Nagpapalitan ang client (na naka-embed sa host) at server ng impormasyon tungkol sa mga suportadong features, tools, resources, at protocol versions. Tinitiyak nito na pareho nilang nauunawaan kung anong kakayahan ang available para sa session.

- **User Request**  
  Nakikipag-ugnayan ang user sa host (halimbawa, nagta-type ng prompt o command). Kinokolekta ng host ang input na ito at ipinapasa ito sa client para iproseso.

- **Resource or Tool Use**  
  - Maaaring humiling ang client ng dagdag na context o resources mula sa server (tulad ng mga file, database entries, o knowledge base articles) para mapalawak ang pagkaintindi ng model.
  - Kapag natukoy ng model na kailangan ng tool (halimbawa, para kumuha ng data, magsagawa ng kalkulasyon, o tumawag ng API), nagpapadala ang client ng tool invocation request sa server, na tinutukoy ang pangalan ng tool at mga parameter.

- **Server Execution**  
  Tinatanggap ng server ang request para sa resource o tool, isinasagawa ang kinakailangang operasyon (tulad ng pagpapatakbo ng function, pag-query sa database, o pagkuha ng file), at ibinabalik ang resulta sa client sa isang structured na format.

- **Response Generation**  
  Isinasama ng client ang mga sagot mula sa server (data ng resource, output ng tool, atbp.) sa kasalukuyang interaksyon ng model. Ginagamit ng model ang impormasyong ito para gumawa ng komprehensibo at kontekstwal na tugon.

- **Result Presentation**  
  Natatanggap ng host ang huling output mula sa client at ipinapakita ito sa user, kadalasan kasama ang text na ginawa ng model at anumang resulta mula sa tool execution o resource lookup.

Pinapayagan ng daloy na ito ang MCP na suportahan ang advanced, interactive, at context-aware na AI applications sa pamamagitan ng seamless na pagkonekta ng mga model sa external tools at data sources.

## Protocol Details

Ang MCP (Model Context Protocol) ay nakatayo sa ibabaw ng [JSON-RPC 2.0](https://www.jsonrpc.org/), na nagbibigay ng standardized, language-agnostic na format ng mensahe para sa komunikasyon sa pagitan ng hosts, clients, at servers. Pinapahintulutan nito ang maaasahan, istrukturado, at extensible na interaksyon sa iba't ibang platform at programming languages.

### Key Protocol Features

Pinalalawak ng MCP ang JSON-RPC 2.0 gamit ang karagdagang conventions para sa tool invocation, resource access, at prompt management. Sinusuportahan nito ang maraming transport layers (STDIO, WebSocket, SSE) at nagbibigay daan sa secure, extensible, at language-agnostic na komunikasyon sa pagitan ng mga bahagi.

#### 🧢 Base Protocol

- **JSON-RPC Message Format**: Lahat ng requests at responses ay sumusunod sa JSON-RPC 2.0 specification, na tinitiyak ang consistent na istruktura para sa method calls, parameters, resulta, at error handling.
- **Stateful Connections**: Pinananatili ng MCP sessions ang estado sa maraming requests, sinusuportahan ang tuloy-tuloy na pag-uusap, pag-ipon ng konteksto, at pamamahala ng resources.
- **Capability Negotiation**: Sa pagsisimula ng koneksyon, nagpapalitan ang clients at servers ng impormasyon tungkol sa suportadong features, protocol versions, available tools, at resources. Tinitiyak nito na nauunawaan ng bawat panig ang kakayahan ng isa't isa at nakakapag-adjust nang naaayon.

#### ➕ Additional Utilities

Narito ang ilang karagdagang utilities at protocol extensions na ibinibigay ng MCP para mapabuti ang karanasan ng developer at suportahan ang advanced na mga senaryo:

- **Configuration Options**: Pinapayagan ng MCP ang dynamic na configuration ng session parameters, tulad ng tool permissions, resource access, at model settings, na iniangkop sa bawat interaksyon.
- **Progress Tracking**: Ang mga long-running operations ay maaaring mag-ulat ng progress updates, na nagbibigay ng responsive na user interface at mas magandang karanasan sa mga kumplikadong gawain.
- **Request Cancellation**: Maaaring kanselahin ng clients ang mga kasalukuyang request, na nagpapahintulot sa mga user na ihinto ang mga operasyong hindi na kailangan o masyadong matagal.
- **Error Reporting**: Standardized na mga error message at code ang tumutulong sa pag-diagnose ng mga problema, maayos na paghawak ng mga pagkabigo, at pagbibigay ng kapaki-pakinabang na feedback sa mga user at developer.
- **Logging**: Parehong clients at servers ay maaaring maglabas ng structured logs para sa auditing, debugging, at monitoring ng protocol interactions.

Sa paggamit ng mga tampok na ito, tinitiyak ng MCP ang matatag, secure, at flexible na komunikasyon sa pagitan ng language models at mga external tools o data sources.

### 🔐 Security Considerations

Dapat sumunod ang mga implementasyon ng MCP sa ilang mahahalagang prinsipyo sa seguridad para matiyak ang ligtas at mapagkakatiwalaang interaksyon:

- **User Consent and Control**: Kailangang magbigay ang mga user ng malinaw na pahintulot bago ma-access ang anumang data o maisagawa ang anumang operasyon. Dapat may malinaw silang kontrol sa kung anong data ang ibabahagi at kung aling mga aksyon ang pinapayagan, na sinusuportahan ng madaling gamitin na user interface para sa pagsusuri at pag-apruba ng mga gawain.

- **Data Privacy**: Ang data ng user ay dapat ilantad lamang kapag may malinaw na pahintulot at dapat protektahan gamit ang angkop na access controls. Dapat pigilan ng mga implementasyon ng MCP ang hindi awtorisadong paglipat ng data at tiyakin na nananatiling pribado ang data sa lahat ng interaksyon.

- **Tool Safety**: Bago tawagin ang anumang tool, kinakailangan ang malinaw na pahintulot ng user. Dapat malinaw sa user ang functionality ng bawat tool, at dapat ipatupad ang matibay na security boundaries para maiwasan ang hindi sinasadyang o delikadong pag-eexecute ng mga tool.

Sa pagsunod sa mga prinsipyong ito, tinitiyak ng MCP na nananatili ang tiwala, privacy, at kaligtasan ng user sa lahat ng interaksyon sa protocol.

## Code Examples: Key Components

Narito ang mga code example sa ilang sikat na programming languages na nagpapakita kung paano i-implement ang mga pangunahing MCP server components at tools.

### .NET Example: Creating a Simple MCP Server with Tools

Narito ang praktikal na .NET code example na nagpapakita kung paano gumawa ng simpleng MCP server na may custom tools. Ipinapakita ng example kung paano ide-define at i-register ang mga tools, hawakan ang mga request, at ikonekta ang server gamit ang Model Context Protocol.

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

### Java Example: MCP Server Components

Ipinapakita ng example na ito ang parehong MCP server at tool registration tulad ng sa .NET example sa itaas, pero gamit ang Java.

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

### Python Example: Building an MCP Server

Sa example na ito, ipinapakita kung paano gumawa ng MCP server gamit ang Python. Ipinapakita rin dito ang dalawang magkaibang paraan para gumawa ng tools.

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

### JavaScript Example: Creating an MCP Server

Ipinapakita ng example na ito kung paano gumawa ng MCP server gamit ang JavaScript at kung paano i-register ang dalawang tools na may kinalaman sa panahon.

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

Ipinapakita rin ng JavaScript example na ito kung paano gumawa ng MCP client na kumokonekta sa server, nagpapadala ng prompt, at nagpoproseso ng sagot kasama ang anumang tool calls na ginawa.

## Security and Authorization

Kasama sa MCP ang ilang built-in na konsepto at mekanismo para sa pamamahala ng seguridad at awtorisasyon sa buong protocol:

1. **Tool Permission Control**:  
  Maaaring tukuyin ng clients kung aling mga tool ang pinapayagan gamitin ng model sa isang session. Tinitiyak nito na ang mga tool na may malinaw na awtorisasyon lang ang maa-access, na nagpapababa ng panganib ng hindi inaasahan o delikadong operasyon. Maaaring i-configure ang permissions nang dynamic base sa preference ng user, patakaran ng organisasyon, o konteksto ng interaksyon.

2. **Authentication**:  
  Maaaring kailanganin ng servers ang authentication bago payagan ang access sa tools, resources, o sensitibong operasyon. Maaaring gamitin dito ang API keys, OAuth tokens, o iba pang authentication schemes. Tinitiyak ng tamang authentication na ang mga pinagkakatiwalaang clients at user lang ang makakagamit ng server-side capabilities.

3. **Validation**:  
  Ipinapatupad ang parameter validation para sa lahat ng tool invocation. Bawat tool ay nagdedeklara ng inaasahang uri, format, at limitasyon para sa mga parameter nito, at sinusuri ng server ang mga papasok na request ayon dito. Pinipigilan nito ang mga maling o malisyosong input na makarating sa tool implementations at tumutulong panatilihin ang integridad ng mga operasyon.

4. **Rate Limiting**:  
  Para maiwasan ang abuso at matiyak ang patas na paggamit ng

**Pagtatapat**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa kanyang sariling wika ang dapat ituring na opisyal na sanggunian. Para sa mga mahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.