<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "056918462dca9b8f75901709fb8f470c",
  "translation_date": "2025-05-17T06:52:55+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "tl"
}
-->
# 📖 MCP Core Concepts: Pagmaster sa Model Context Protocol para sa AI Integration

Ang Model Context Protocol (MCP) ay isang makapangyarihan, pamantayang balangkas na nag-o-optimize sa komunikasyon sa pagitan ng Large Language Models (LLMs) at mga panlabas na kagamitan, aplikasyon, at mga pinagmumulan ng data. Ang SEO-optimized na gabay na ito ay maglalakad sa iyo sa mga pangunahing konsepto ng MCP, na sinisiguro ang iyong pag-unawa sa client-server architecture, mahahalagang sangkap, mekanismo ng komunikasyon, at mga pinakamahusay na kasanayan sa pagpapatupad.

## Overview

Ang araling ito ay nag-eeksplora sa pundamental na arkitektura at mga sangkap na bumubuo sa Model Context Protocol (MCP) ecosystem. Matututo ka tungkol sa client-server architecture, mga pangunahing sangkap, at mga mekanismo ng komunikasyon na nagpapagana sa MCP interactions.

## 👩‍🎓 Key Learning Objectives

Sa pagtatapos ng araling ito, ikaw ay:

- Mauunawaan ang MCP client-server architecture.
- Matutukoy ang mga papel at responsibilidad ng Hosts, Clients, at Servers.
- Susuriin ang mga pangunahing tampok na gumagawa sa MCP bilang isang flexible integration layer.
- Matututo kung paano dumadaloy ang impormasyon sa loob ng MCP ecosystem.
- Makakakuha ng praktikal na pananaw sa pamamagitan ng mga halimbawa ng code sa .NET, Java, Python, at JavaScript.

## 🔎 MCP Architecture: Isang Mas Malalim na Pagsusuri

Ang MCP ecosystem ay binuo sa isang client-server model. Ang modular na istruktura na ito ay nagpapahintulot sa mga AI application na makipag-ugnayan sa mga kagamitan, databases, APIs, at mga contextual resources nang mahusay. I-breakdown natin ang arkitektura na ito sa mga pangunahing sangkap nito.

### 1. Hosts

Sa Model Context Protocol (MCP), ang Hosts ay may mahalagang papel bilang pangunahing interface kung saan nakikipag-ugnayan ang mga gumagamit sa protocol. Ang Hosts ay mga aplikasyon o kapaligiran na nagsisimula ng mga koneksyon sa MCP servers upang ma-access ang data, kagamitan, at mga prompt. Mga halimbawa ng Hosts ay mga integrated development environments (IDEs) tulad ng Visual Studio Code, AI tools tulad ng Claude Desktop, o mga custom-built agents na dinisenyo para sa mga tiyak na gawain.

**Hosts** ay mga LLM application na nagsisimula ng mga koneksyon. Sila ay:

- Nagpapatupad o nakikipag-ugnayan sa mga AI models upang makabuo ng mga tugon.
- Nagsisimula ng mga koneksyon sa MCP servers.
- Nag-aasikaso ng daloy ng pag-uusap at user interface.
- Kinokontrol ang mga pahintulot at mga limitasyon sa seguridad.
- Nag-aasikaso ng pahintulot ng gumagamit para sa pagbabahagi ng data at pagpapatupad ng tool.

### 2. Clients

Ang Clients ay mahahalagang sangkap na nagpapadali sa pakikipag-ugnayan sa pagitan ng Hosts at MCP servers. Ang Clients ay kumikilos bilang mga tagapamagitan, na nagpapahintulot sa Hosts na ma-access at magamit ang mga functionality na ibinibigay ng MCP servers. Sila ay may mahalagang papel sa pagtiyak ng maayos na komunikasyon at mahusay na pagpapalitan ng data sa loob ng MCP architecture.

**Clients** ay mga konektor sa loob ng host application. Sila ay:

- Nagpapadala ng mga request sa servers kasama ang mga prompt/instructions.
- Nakikipag-ayos ng mga kakayahan sa servers.
- Nag-aasikaso ng mga request sa pagpapatupad ng tool mula sa mga modelo.
- Nagpoproseso at nagpapakita ng mga tugon sa mga gumagamit.

### 3. Servers

Ang Servers ay responsable sa pag-aasikaso ng mga request mula sa MCP clients at pagbibigay ng naaangkop na mga tugon. Sila ay namamahala sa iba't ibang operasyon tulad ng pagkuha ng data, pagpapatupad ng tool, at pagbuo ng prompt. Ang Servers ay nagtitiyak na ang komunikasyon sa pagitan ng clients at Hosts ay mahusay at maaasahan, pinapanatili ang integridad ng proseso ng pakikipag-ugnayan.

**Servers** ay mga serbisyo na nagbibigay ng konteksto at kakayahan. Sila ay:

- Nirehistro ang mga available na tampok (resources, prompts, tools).
- Tumanggap at magpatupad ng mga tawag sa tool mula sa client.
- Nagbibigay ng contextual information upang mapahusay ang mga tugon ng modelo.
- Nagbabalik ng mga output pabalik sa client.
- Pinapanatili ang estado sa mga pakikipag-ugnayan kapag kinakailangan.

Ang Servers ay maaaring idevelop ng kahit sino upang palawakin ang kakayahan ng modelo sa mga specialized functionality.

### 4. Server Features

Ang Servers sa Model Context Protocol (MCP) ay nagbibigay ng mga pundamental na building blocks na nagpapahintulot sa mas mayamang pakikipag-ugnayan sa pagitan ng clients, hosts, at language models. Ang mga tampok na ito ay idinisenyo upang mapahusay ang mga kakayahan ng MCP sa pamamagitan ng pag-aalok ng structured context, tools, at prompts.

Ang MCP servers ay maaaring mag-alok ng alinman sa mga sumusunod na tampok:

#### 📑 Resources

Ang Resources sa Model Context Protocol (MCP) ay sumasaklaw sa iba't ibang uri ng konteksto at data na maaaring magamit ng mga gumagamit o AI models. Kabilang dito ang:

- **Contextual Data**: Impormasyon at konteksto na maaaring magamit ng mga gumagamit o AI models para sa paggawa ng desisyon at pagpapatupad ng gawain.
- **Knowledge Bases at Document Repositories**: Mga koleksyon ng structured at unstructured data, tulad ng mga artikulo, manual, at research papers, na nagbibigay ng mahalagang pananaw at impormasyon.
- **Local Files at Databases**: Data na nakaimbak nang lokal sa mga device o sa loob ng databases, na naa-access para sa pagproseso at pagsusuri.
- **APIs at Web Services**: Mga panlabas na interface at serbisyo na nag-aalok ng karagdagang data at functionality, na nagpapahintulot sa integrasyon sa iba't ibang online resources at tools.

Ang halimbawa ng resource ay maaaring isang database schema o isang file na maa-access tulad ng ganito:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Ang Prompts sa Model Context Protocol (MCP) ay kinabibilangan ng iba't ibang pre-defined templates at interaction patterns na dinisenyo upang gawing mas madali ang mga workflow ng gumagamit at mapahusay ang komunikasyon. Kabilang dito ang:

- **Templated Messages at Workflows**: Pre-structured messages at processes na gumagabay sa mga gumagamit sa pamamagitan ng tiyak na gawain at pakikipag-ugnayan.
- **Pre-defined Interaction Patterns**: Standardized sequences ng mga aksyon at tugon na nagpapadali ng pare-pareho at mahusay na komunikasyon.
- **Specialized Conversation Templates**: Mga customizable templates na iniakma para sa tiyak na uri ng mga pag-uusap, na tinitiyak ang may kaugnayan at kontekstwal na naaangkop na mga pakikipag-ugnayan.

Ang template ng prompt ay maaaring magmukhang ganito:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Tools

Ang Tools sa Model Context Protocol (MCP) ay mga function na maaaring isagawa ng AI model upang magsagawa ng tiyak na mga gawain. Ang mga tools na ito ay dinisenyo upang mapahusay ang kakayahan ng AI model sa pamamagitan ng pagbibigay ng structured at maaasahang mga operasyon. Mahahalagang aspeto ay kinabibilangan ng:

- **Mga Function para sa AI Model na Ipatupad**: Ang Tools ay mga executable functions na maaaring i-invoke ng AI model upang magsagawa ng iba't ibang gawain.
- **Natatanging Pangalan at Paglalarawan**: Ang bawat tool ay may natatanging pangalan at detalyadong paglalarawan na nagpapaliwanag ng layunin at functionality nito.
- **Parameters at Outputs**: Ang Tools ay tumatanggap ng tiyak na parameters at nagbabalik ng structured outputs, na tinitiyak ang pare-pareho at predictable na resulta.
- **Discrete Functions**: Ang Tools ay nagsasagawa ng discrete functions tulad ng web searches, calculations, at database queries.

Ang halimbawa ng tool ay maaaring magmukhang ganito:

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

Sa Model Context Protocol (MCP), ang clients ay nag-aalok ng ilang pangunahing tampok sa servers, na nagpapahusay sa kabuuang functionality at pakikipag-ugnayan sa loob ng protocol. Isa sa mga kapansin-pansing tampok ay ang Sampling.

### 👉 Sampling

- **Server-Initiated Agentic Behaviors**: Ang Clients ay nagpapahintulot sa servers na magsimula ng tiyak na mga aksyon o pag-uugali nang autonomously, na nagpapahusay sa dynamic capabilities ng sistema.
- **Recursive LLM Interactions**: Ang tampok na ito ay nagpapahintulot sa recursive interactions sa large language models (LLMs), na nagbibigay-daan sa mas kumplikado at iterative na pagproseso ng mga gawain.
- **Requesting Additional Model Completions**: Ang Servers ay maaaring humiling ng karagdagang completions mula sa modelo, na tinitiyak na ang mga tugon ay masusing at kontekstwal na may kaugnayan.

## Information Flow in MCP

Ang Model Context Protocol (MCP) ay nagtatakda ng structured flow ng impormasyon sa pagitan ng hosts, clients, servers, at models. Ang pag-unawa sa daloy na ito ay tumutulong sa paglinaw kung paano pinoproseso ang mga kahilingan ng gumagamit at kung paano isinasama ang mga panlabas na tools at data sa mga tugon ng modelo.

- **Host Initiates Connection**  
  Ang host application (tulad ng isang IDE o chat interface) ay nagtatatag ng koneksyon sa isang MCP server, karaniwang sa pamamagitan ng STDIO, WebSocket, o iba pang suportadong transport.

- **Capability Negotiation**  
  Ang client (embedded sa host) at ang server ay nagpapalitan ng impormasyon tungkol sa kanilang mga suportadong tampok, tools, resources, at protocol versions. Ito ay tinitiyak na ang parehong panig ay nauunawaan kung ano ang mga kakayahan na available para sa session.

- **User Request**  
  Ang gumagamit ay nakikipag-ugnayan sa host (halimbawa, naglalagay ng prompt o command). Ang host ay kinokolekta ang input na ito at ipinapasa ito sa client para sa pagproseso.

- **Resource or Tool Use**  
  - Ang client ay maaaring humiling ng karagdagang konteksto o resources mula sa server (tulad ng mga files, database entries, o knowledge base articles) upang pagyamanin ang pag-unawa ng modelo.
  - Kung ang modelo ay nagpapasiya na kailangan ng tool (halimbawa, upang kumuha ng data, magsagawa ng kalkulasyon, o tumawag ng API), ang client ay nagpapadala ng tool invocation request sa server, na tinutukoy ang pangalan ng tool at mga parameters.

- **Server Execution**  
  Ang server ay tumatanggap ng resource o tool request, isinasagawa ang kinakailangang operasyon (tulad ng pagpapatakbo ng function, pag-query sa database, o pagkuha ng file), at ibinabalik ang mga resulta sa client sa isang structured format.

- **Response Generation**  
  Ang client ay isinasama ang mga tugon ng server (resource data, tool outputs, etc.) sa patuloy na pakikipag-ugnayan ng modelo. Ang modelo ay gumagamit ng impormasyong ito upang makabuo ng komprehensibo at kontekstwal na naaangkop na tugon.

- **Result Presentation**  
  Ang host ay tumatanggap ng final output mula sa client at ipinapakita ito sa gumagamit, kadalasang kasama ang parehong generated text ng modelo at anumang resulta mula sa tool executions o resource lookups.

Ang daloy na ito ay nagbibigay-daan sa MCP na suportahan ang advanced, interactive, at context-aware na AI applications sa pamamagitan ng seamless na pagkonekta ng mga modelo sa mga panlabas na tools at data sources.

## Protocol Details

Ang MCP (Model Context Protocol) ay binuo sa ibabaw ng [JSON-RPC 2.0](https://www.jsonrpc.org/), na nagbibigay ng standardized, language-agnostic message format para sa komunikasyon sa pagitan ng hosts, clients, at servers. Ang pundasyon na ito ay nagbibigay-daan sa maaasahan, structured, at extensible na pakikipag-ugnayan sa iba't ibang platforms at programming languages.

### Key Protocol Features

Ang MCP ay nagpapalawak sa JSON-RPC 2.0 sa pamamagitan ng karagdagang conventions para sa tool invocation, resource access, at prompt management. Ito ay sumusuporta sa maraming transport layers (STDIO, WebSocket, SSE) at nagbibigay-daan sa secure, extensible, at language-agnostic na komunikasyon sa pagitan ng mga sangkap.

#### 🧢 Base Protocol

- **JSON-RPC Message Format**: Ang lahat ng mga kahilingan at tugon ay gumagamit ng JSON-RPC 2.0 specification, na tinitiyak ang pare-parehong istruktura para sa method calls, parameters, results, at error handling.
- **Stateful Connections**: Ang MCP sessions ay nagpapanatili ng estado sa maraming kahilingan, na sumusuporta sa patuloy na pag-uusap, context accumulation, at resource management.
- **Capability Negotiation**: Sa panahon ng connection setup, ang clients at servers ay nagpapalitan ng impormasyon tungkol sa mga suportadong tampok, protocol versions, available tools, at resources. Ito ay tinitiyak na ang parehong panig ay nauunawaan ang kakayahan ng bawat isa at maaaring umangkop nang naaayon.

#### ➕ Additional Utilities

Sa ibaba ay ilang karagdagang utilities at protocol extensions na ibinibigay ng MCP upang mapahusay ang karanasan ng developer at paganahin ang advanced scenarios:

- **Configuration Options**: Ang MCP ay nagpapahintulot sa dynamic na configuration ng session parameters, tulad ng tool permissions, resource access, at model settings, na iniakma sa bawat pakikipag-ugnayan.
- **Progress Tracking**: Ang mga long-running operations ay maaaring mag-ulat ng progress updates, na nagbibigay-daan sa responsive user interfaces at mas mahusay na karanasan ng gumagamit sa panahon ng mga kumplikadong gawain.
- **Request Cancellation**: Ang Clients ay maaaring mag-cancel ng mga in-flight requests, na nagbibigay-daan sa mga gumagamit na mag-interrupt ng mga operasyon na hindi na kailangan o masyadong matagal.
- **Error Reporting**: Ang standardized error messages at codes ay tumutulong sa pag-diagnose ng mga isyu, graceful handling ng failures, at pagbibigay ng actionable feedback sa mga gumagamit at developers.
- **Logging**: Parehong clients at servers ay maaaring mag-emit ng structured logs para sa auditing, debugging, at monitoring ng protocol interactions.

Sa pamamagitan ng pag-leverage sa mga protocol features na ito, ang MCP ay tinitiyak ang robust, secure, at flexible na komunikasyon sa pagitan ng language models at mga panlabas na tools o data sources.

### 🔐 Security Considerations

Ang MCP implementations ay dapat sumunod sa ilang pangunahing prinsipyo ng seguridad upang matiyak ang ligtas at mapagkakatiwalaang pakikipag-ugnayan:

- **User Consent and Control**: Ang mga gumagamit ay dapat magbigay ng explicit consent bago ang anumang data ay ma-access o ang mga operasyon ay isagawa. Dapat silang magkaroon ng malinaw na kontrol sa kung anong data ang ibabahagi at kung aling mga aksyon ang awtorisado, suportado ng intuitive user interfaces para sa pag-review at pag-apruba ng mga aktibidad.

- **Data Privacy**: Ang user data ay dapat lamang ma-expose sa explicit consent at dapat protektahan ng naaangkop na access controls. Ang MCP implementations ay dapat mag-ingat laban sa hindi awtorisadong data transmission at matiyak na ang privacy ay pinapanatili sa lahat ng pakikipag-ugnayan.

- **Tool Safety**: Bago mag-invoke ng anumang tool, kinakailangan ang explicit user consent. Dapat magkaroon ang mga gumagamit ng malinaw na pag-unawa sa functionality ng bawat tool, at dapat ipatupad ang mga robust security boundaries upang maiwasan ang hindi inaasahan o hindi ligtas na tool execution.

Sa pamamagitan ng pagsunod sa mga prinsipyong ito, ang MCP ay tinitiyak na ang tiwala ng gumagamit, privacy, at kaligtasan ay pinapanatili sa lahat ng protocol interactions.

## Code Examples: Key Components

Sa ibaba ay mga halimbawa ng code sa ilang popular na programming languages na naglalarawan kung paano ipatupad ang mga pangunahing MCP server components at tools.

### .NET Example: Paglikha ng Simpleng MCP Server na may Tools

Narito ang isang praktikal na .NET code example na nagpapakita kung paano ipatupad ang simpleng MCP server na may custom tools. Ang halimbawa na ito ay nagpapakita kung paano mag-define at magrehistro ng tools, mag-aasikaso ng mga request, at ikonekta ang server gamit ang Model Context Protocol.

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

### Java Example: Mga Sangkap ng MCP Server

Ang halimbawa na ito ay nagpapakita ng parehong MCP server at tool registration tulad ng .NET example sa itaas, ngunit ipinatupad sa Java.

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

### Python Example: Pagbuo ng MCP Server

Sa halimbawa na ito, ipinapakita namin kung paano bumuo ng MCP server sa Python. Ipinapakita rin ang dalawang magkaibang paraan ng paglikha ng tools.

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

### JavaScript Example: Paglikha ng MCP Server

Ang halimbawa na ito ay nagpapakita ng paglikha ng MCP server sa JavaScript at ipinapakita kung paano magrehistro ng dalawang tools na may kaugnayan sa panahon.

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

Ang JavaScript example na ito ay nagpapakita kung paano lumikha ng MCP client na kumokonekta sa server, nagpapadala ng prompt, at nagpoproseso ng tugon kabilang ang anumang tool calls na ginawa.

## Security and Authorization

Ang MCP ay nagsasama ng ilang built-in concepts at mekanismo para sa pamamahala ng seguridad at awtorisasyon sa buong protocol:

1. **Tool Permission Control**:  
  Ang Clients ay maaaring tukuyin kung aling mga tools ang pinapayagan ng modelo na gamitin sa panahon ng session. Ito ay tinitiyak na ang mga tools na awtorisado lamang ay maa-access, na nagbabawas ng panganib ng hindi inaasahan o hindi ligtas na operasyon. Ang mga permissions ay maaaring i-configure nang dynamic batay sa mga kagustuhan ng gumagamit

**Paunawa**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Habang nagsusumikap kami para sa katumpakan, mangyaring tandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi pagkaka-ayon. Ang orihinal na dokumento sa sariling wika nito ay dapat ituring na mapagkakatiwalaang sanggunian. Para sa mahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot para sa anumang hindi pagkakaintindihan o maling interpretasyon na dulot ng paggamit ng pagsasaling ito.