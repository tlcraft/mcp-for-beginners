<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00defb149ee1ac4a799e44a9783c7fc",
  "translation_date": "2025-06-06T18:40:26+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "tl"
}
-->
# 📖 MCP Core Concepts: Mastering the Model Context Protocol for AI Integration

Ang Model Context Protocol (MCP) ay isang makapangyarihan at standardized na balangkas na nag-o-optimize ng komunikasyon sa pagitan ng Large Language Models (LLMs) at mga external na tools, aplikasyon, at data sources. Ang gabay na ito, na naka-SEO optimize, ay maglalakad sa iyo sa mga pangunahing konsepto ng MCP, tinitiyak na maiintindihan mo ang client-server architecture nito, mahahalagang bahagi, mekanismo ng komunikasyon, at mga pinakamahusay na kasanayan sa implementasyon.

## Overview

Tatalakayin sa araling ito ang pangunahing arkitektura at mga bahagi na bumubuo sa Model Context Protocol (MCP) ecosystem. Matututuhan mo ang tungkol sa client-server architecture, mga pangunahing bahagi, at mekanismo ng komunikasyon na nagpapatakbo sa MCP interactions.

## 👩‍🎓 Key Learning Objectives

Sa pagtatapos ng araling ito, magagawa mong:

- Maunawaan ang MCP client-server architecture.
- Tukuyin ang mga papel at responsibilidad ng Hosts, Clients, at Servers.
- Suriin ang mga pangunahing katangian na nagpapalawak sa MCP bilang isang flexible na integration layer.
- Matutunan kung paano dumadaloy ang impormasyon sa loob ng MCP ecosystem.
- Makakuha ng praktikal na kaalaman sa pamamagitan ng mga code examples sa .NET, Java, Python, at JavaScript.

## 🔎 MCP Architecture: A Deeper Look

Ang MCP ecosystem ay nakabase sa isang client-server model. Ang modular na estrukturang ito ay nagpapahintulot sa mga AI application na makipag-ugnayan sa mga tools, databases, APIs, at contextual resources nang epektibo. Hatiin natin ang arkitekturang ito sa mga pangunahing bahagi nito.

### 1. Hosts

Sa Model Context Protocol (MCP), mahalaga ang papel ng Hosts bilang pangunahing interface kung saan nakikipag-ugnayan ang mga user sa protocol. Ang Hosts ay mga aplikasyon o kapaligiran na nagsisimula ng koneksyon sa MCP servers para ma-access ang data, tools, at prompts. Halimbawa ng Hosts ay mga integrated development environments (IDEs) tulad ng Visual Studio Code, mga AI tool tulad ng Claude Desktop, o mga custom-built agents na ginawa para sa partikular na mga gawain.

**Hosts** ay mga LLM application na nagsisimula ng koneksyon. Sila ay:

- Nagpapatakbo o nakikipag-ugnayan sa AI models para bumuo ng mga sagot.
- Nagsisimula ng koneksyon sa MCP servers.
- Nagmamaneho ng daloy ng usapan at user interface.
- Kumokontrol sa permiso at seguridad.
- Nangangalaga sa pahintulot ng user para sa data sharing at pagpapatakbo ng mga tools.

### 2. Clients

Ang Clients ay mga mahalagang bahagi na nagpapadali ng interaksyon sa pagitan ng Hosts at MCP servers. Ang Clients ay nagsisilbing tagapamagitan, na nagbibigay-daan sa Hosts na ma-access at magamit ang mga functionality na ibinibigay ng MCP servers. Mahalaga ang papel nila sa pagtiyak ng maayos na komunikasyon at epektibong palitan ng data sa loob ng MCP architecture.

**Clients** ay mga connector sa loob ng host application. Sila ay:

- Nagpapadala ng mga request sa servers kasama ang prompts/instructions.
- Nakikipagnegosasyon ng kakayahan sa servers.
- Namamahala sa mga kahilingan para sa pagpapatakbo ng tools mula sa mga modelo.
- Nagpoproseso at nagpapakita ng mga sagot sa mga user.

### 3. Servers

Ang Servers ang responsable sa paghawak ng mga request mula sa MCP clients at pagbibigay ng angkop na mga sagot. Pinangangasiwaan nila ang iba't ibang operasyon tulad ng pagkuha ng data, pagpapatakbo ng tools, at pagbuo ng prompts. Tinitiyak ng Servers na ang komunikasyon sa pagitan ng clients at Hosts ay epektibo at maaasahan, pinananatili ang integridad ng proseso ng interaksyon.

**Servers** ay mga serbisyo na nagbibigay ng konteksto at kakayahan. Sila ay:

- Nagrerehistro ng mga available na features (resources, prompts, tools).
- Tumatanggap at nagpapatupad ng mga tool calls mula sa client.
- Nagbibigay ng contextual information para mapahusay ang mga sagot ng modelo.
- Nagbabalik ng output pabalik sa client.
- Nananatili ang estado sa mga interaksyon kung kinakailangan.

Maaaring idevelop ng sinuman ang mga Servers para palawakin ang kakayahan ng modelo gamit ang espesyal na functionality.

### 4. Server Features

Ang mga Servers sa Model Context Protocol (MCP) ay nagbibigay ng mga pangunahing bahagi na nagpapahintulot ng masiglang interaksyon sa pagitan ng clients, hosts, at language models. Dinisenyo ang mga features na ito para mapalawak ang kakayahan ng MCP sa pamamagitan ng pag-aalok ng structured context, tools, at prompts.

Maaaring mag-alok ang MCP servers ng alinman sa mga sumusunod na features:

#### 📑 Resources 

Ang mga Resources sa Model Context Protocol (MCP) ay sumasaklaw sa iba't ibang uri ng konteksto at data na maaaring gamitin ng mga user o AI models. Kabilang dito ang:

- **Contextual Data**: Impormasyon at konteksto na maaaring gamitin ng mga user o AI models para sa paggawa ng desisyon at pagtupad ng gawain.
- **Knowledge Bases at Document Repositories**: Koleksyon ng structured at unstructured na data, tulad ng mga artikulo, manual, at research papers, na nagbibigay ng mahalagang insight at impormasyon.
- **Local Files at Databases**: Data na nakaimbak lokal sa mga device o sa loob ng mga databases, na maaaring ma-access para sa pagproseso at pagsusuri.
- **APIs at Web Services**: Mga external na interface at serbisyo na nag-aalok ng karagdagang data at functionality, na nagpapahintulot ng integrasyon sa iba't ibang online na resources at tools.

Isang halimbawa ng resource ay maaaring isang database schema o isang file na maaaring ma-access tulad nito:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Ang mga Prompts sa Model Context Protocol (MCP) ay kinabibilangan ng iba't ibang pre-defined na mga template at pattern ng interaksyon na dinisenyo para gawing mas madali ang workflow ng user at mapahusay ang komunikasyon. Kabilang dito ang:

- **Templated Messages at Workflows**: Mga pre-istrukturang mensahe at proseso na gumagabay sa mga user sa partikular na mga gawain at interaksyon.
- **Pre-defined Interaction Patterns**: Standardized na pagkakasunod-sunod ng mga aksyon at sagot na nagpapadali ng consistent at epektibong komunikasyon.
- **Specialized Conversation Templates**: Mga customizable na template na nakaangkop para sa partikular na uri ng mga pag-uusap, na tinitiyak na may kaugnayan at angkop sa konteksto ang mga interaksyon.

Ganito ang hitsura ng isang prompt template:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Tools

Ang mga Tools sa Model Context Protocol (MCP) ay mga function na maaaring patakbuhin ng AI model para gawin ang partikular na mga gawain. Dinisenyo ang mga ito para palawakin ang kakayahan ng AI model sa pamamagitan ng pagbibigay ng structured at maaasahang operasyon. Pangunahing aspeto nito ay:

- **Mga Function na maaaring patakbuhin ng AI model**: Ang tools ay mga executable function na maaaring tawagin ng AI model para isagawa ang iba't ibang gawain.
- **Natanging Pangalan at Deskripsyon**: Bawat tool ay may sariling pangalan at detalyadong paglalarawan na nagpapaliwanag ng layunin at functionality nito.
- **Mga Parameter at Output**: Tumanggap ang tools ng partikular na mga parameter at nagbabalik ng structured na output, na tinitiyak ang consistent at predictable na resulta.
- **Discrete Functions**: Gumaganap ang tools ng mga discrete na function tulad ng web searches, kalkulasyon, at mga query sa database.

Ganito ang halimbawa ng isang tool:

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

Sa Model Context Protocol (MCP), nag-aalok ang mga clients ng ilang mahahalagang feature sa mga servers na nagpapalawak sa kabuuang functionality at interaksyon sa loob ng protocol. Isa sa mga kapansin-pansing feature ay ang Sampling.

### 👉 Sampling

- **Server-Initiated Agentic Behaviors**: Pinapahintulutan ng clients ang servers na magsimula ng partikular na aksyon o behavior nang autonomously, na nagpapalawak sa dynamic na kakayahan ng sistema.
- **Recursive LLM Interactions**: Pinapahintulutan nito ang recursive na interaksyon sa mga large language models (LLMs), na nagpapagana ng mas komplikado at paulit-ulit na pagproseso ng mga gawain.
- **Requesting Additional Model Completions**: Maaaring humiling ang servers ng karagdagang mga sagot mula sa modelo, tinitiyak na ang mga tugon ay mas malawak at naaayon sa konteksto.

## Information Flow in MCP

Itinatakda ng Model Context Protocol (MCP) ang isang istrukturadong daloy ng impormasyon sa pagitan ng hosts, clients, servers, at models. Ang pag-unawa sa daloy na ito ay tumutulong upang malinawan kung paano pinoproseso ang mga kahilingan ng user at kung paano na-integrate ang mga external na tools at data sa mga sagot ng modelo.

- **Host Initiates Connection**  
  Ang host application (tulad ng IDE o chat interface) ay nagtatatag ng koneksyon sa isang MCP server, karaniwang gamit ang STDIO, WebSocket, o iba pang suportadong transport.

- **Capability Negotiation**  
  Nagpapalitan ng impormasyon ang client (na naka-embed sa host) at ang server tungkol sa kanilang mga suportadong feature, tools, resources, at protocol versions. Tinitiyak nito na parehong nauunawaan ng magkabilang panig ang mga kakayahan na available para sa session.

- **User Request**  
  Nakikipag-ugnayan ang user sa host (halimbawa, nagta-type ng prompt o command). Kinokolekta ng host ang input na ito at ipinapasa ito sa client para sa pagproseso.

- **Resource or Tool Use**  
  - Maaaring humiling ang client ng karagdagang konteksto o resources mula sa server (tulad ng mga file, database entries, o knowledge base articles) upang mapalawak ang pag-unawa ng modelo.
  - Kung matutukoy ng modelo na kailangan ang isang tool (halimbawa, para kumuha ng data, magsagawa ng kalkulasyon, o tumawag ng API), magpapadala ang client ng tool invocation request sa server, na nagsasaad ng pangalan ng tool at mga parameter.

- **Server Execution**  
  Tinatanggap ng server ang request para sa resource o tool, isinasagawa ang kinakailangang operasyon (tulad ng pagpapatakbo ng function, pag-query sa database, o pagkuha ng file), at ibinabalik ang resulta sa client sa isang istrukturadong format.

- **Response Generation**  
  Pinagsasama ng client ang mga sagot mula sa server (data ng resource, output ng tool, atbp.) sa kasalukuyang interaksyon ng modelo. Ginagamit ng modelo ang impormasyong ito para bumuo ng komprehensibo at naaayon sa konteksto na tugon.

- **Result Presentation**  
  Tinatanggap ng host ang panghuling output mula sa client at ipinapakita ito sa user, kadalasan ay kinabibilangan ng parehong teksto na nilikha ng modelo at mga resulta mula sa pagpapatakbo ng tools o pagkuha ng resources.

Pinapahintulutan ng daloy na ito ang MCP na suportahan ang advanced, interactive, at context-aware na mga AI application sa pamamagitan ng seamless na pagkonekta ng mga modelo sa external na tools at data sources.

## Protocol Details

Ang MCP (Model Context Protocol) ay nakabase sa ibabaw ng [JSON-RPC 2.0](https://www.jsonrpc.org/), na nagbibigay ng standardized, language-agnostic na format ng mensahe para sa komunikasyon sa pagitan ng hosts, clients, at servers. Ang pundasyong ito ay nagpapahintulot ng maaasahan, istrukturado, at extensible na interaksyon sa iba't ibang platform at programming languages.

### Key Protocol Features

Pinalalawak ng MCP ang JSON-RPC 2.0 gamit ang karagdagang conventions para sa tool invocation, resource access, at prompt management. Sinusuportahan nito ang maraming transport layers (STDIO, WebSocket, SSE) at nagpapahintulot ng secure, extensible, at language-agnostic na komunikasyon sa pagitan ng mga bahagi.

#### 🧢 Base Protocol

- **JSON-RPC Message Format**: Lahat ng request at response ay sumusunod sa JSON-RPC 2.0 specification, na tinitiyak ang consistent na istruktura para sa method calls, parameters, results, at error handling.
- **Stateful Connections**: Pinananatili ng MCP sessions ang estado sa maraming request, sumusuporta sa tuloy-tuloy na pag-uusap, pag-iipon ng konteksto, at pamamahala ng resources.
- **Capability Negotiation**: Sa pagsisimula ng koneksyon, nagpapalitan ng impormasyon ang clients at servers tungkol sa mga suportadong feature, protocol versions, available tools, at resources. Tinitiyak nito na nauunawaan ng magkabilang panig ang kakayahan ng isa't isa at maaaring mag-adjust nang naaayon.

#### ➕ Additional Utilities

Narito ang ilang karagdagang utilities at protocol extensions na inaalok ng MCP para mapahusay ang karanasan ng developer at paganahin ang advanced na mga senaryo:

- **Configuration Options**: Pinapayagan ng MCP ang dynamic na pag-configure ng mga session parameter, tulad ng tool permissions, resource access, at model settings, na nakaangkop sa bawat interaksyon.
- **Progress Tracking**: Maaaring mag-ulat ng progreso ang mga long-running operation, na nagpapahintulot ng responsive na user interface at mas magandang karanasan sa user habang nagpapatuloy ang komplikadong mga gawain.
- **Request Cancellation**: Maaaring kanselahin ng clients ang mga kasalukuyang request, na nagbibigay-daan sa mga user na ihinto ang mga operasyong hindi na kailangan o masyadong matagal.
- **Error Reporting**: Standardized na mga mensahe ng error at mga code ang tumutulong sa pag-diagnose ng mga isyu, maayos na paghawak ng mga pagkabigo, at pagbibigay ng actionable na feedback sa mga user at developer.
- **Logging**: Parehong clients at servers ay maaaring maglabas ng istrukturadong logs para sa auditing, debugging, at pagmamanman ng mga interaksyon sa protocol.

Sa pamamagitan ng paggamit ng mga feature ng protocol na ito, tinitiyak ng MCP ang matatag, secure, at flexible na komunikasyon sa pagitan ng mga language model at mga external na tools o data sources.

### 🔐 Security Considerations

Dapat sundin ng mga implementasyon ng MCP ang ilang mahahalagang prinsipyo sa seguridad upang matiyak ang ligtas at mapagkakatiwalaang mga interaksyon:

- **User Consent and Control**: Dapat magbigay ng malinaw na pahintulot ang mga user bago ma-access ang anumang data o maisagawa ang mga operasyon. Dapat may malinaw silang kontrol sa kung anong data ang ibabahagi at kung aling mga aksyon ang pinapayagan, na sinusuportahan ng madaling gamitin na interface para sa pagsusuri at pag-apruba ng mga aktibidad.

- **Data Privacy**: Ang data ng user ay dapat ipakita lamang sa malinaw na pahintulot at kailangang protektahan ng angkop na access controls. Dapat iwasan ng implementasyon ng MCP ang hindi awtorisadong paglipat ng data at siguraduhing nananatiling pribado ang impormasyon sa lahat ng interaksyon.

- **Tool Safety**: Bago tawagin ang anumang tool, kinakailangan ang malinaw na pahintulot ng user. Dapat malinaw sa user ang functionality ng bawat tool, at kailangang ipatupad ang mahigpit na seguridad upang maiwasan ang hindi inaasahang o delikadong pagpapatakbo ng mga tool.

Sa pagsunod sa mga prinsipyong ito, tinitiyak ng MCP na ang tiwala, privacy, at kaligtasan ng user ay nananatili sa lahat ng interaksyon sa protocol.

## Code Examples: Key Components

Narito ang mga halimbawa ng code sa ilang kilalang programming languages na nagpapakita kung paano mag-implement ng mga pangunahing MCP server components at tools.

### .NET Example: Creating a Simple MCP Server with Tools

Narito ang isang praktikal na .NET code example na nagpapakita kung paano gumawa ng simpleng MCP server na may custom tools. Ipinapakita ng example na ito kung paano idefine at irehistro ang mga tools, hawakan ang mga request, at ikonekta ang server gamit ang Model Context Protocol.

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

Ipinapakita ng example na ito ang parehong MCP server at tool registration tulad ng sa .NET example sa itaas, ngunit ginawa sa Java.

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

Sa example na ito, ipinapakita kung paano bumuo ng MCP server sa Python. Ipinapakita rin dito ang dalawang magkaibang paraan para gumawa ng tools.

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

### JavaScript Example: Creating an MCP Server

Ipinapakita ng example na ito kung paano gumawa ng MCP server sa JavaScript at paano irehistro ang dalawang tool na may kinalaman sa panahon.

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

Ipinapakita rin ng JavaScript example na ito kung paano gumawa ng MCP client na kumokonekta sa server, nagpapadala ng prompt, at pinoproseso ang tugon kasama ang anumang tool calls na ginawa.

## Security and Authorization

Kasama sa MCP ang ilang built-in na konsepto at mekanismo para sa pamamahala ng seguridad at authorization sa buong protocol:

1. **Tool Permission Control**:  
  Maaaring tukuyin ng clients kung aling mga tools ang pinapayagan gamitin ng modelo sa isang session. Tinitiyak nito na ang mga tool na accessible ay yaong mga hayagang pinahintulutan lamang, na nagpapababa ng panganib ng hindi inaasahan o delikadong operasyon. Maaaring i-configure ang mga permiso nang dynamic batay sa kagustuhan ng user, mga polisiya ng organisasyon, o konteksto ng interaksyon.

2. **Authentication**:  
  Maaaring hingin ng servers ang authentication bago payagan ang access sa mga tools, resources, o sensitibong operasyon. Maaaring kasama rito ang API keys, OAuth tokens, o iba pang

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa kanyang orihinal na wika ang dapat ituring na opisyal na sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang maling pagkaunawa o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.