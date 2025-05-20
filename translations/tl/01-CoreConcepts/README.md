<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4bf553c18e7e226c3d76ab0cde627d26",
  "translation_date": "2025-05-20T22:11:53+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "tl"
}
-->
# 📖 MCP Core Concepts: Mastering the Model Context Protocol for AI Integration

Ang Model Context Protocol (MCP) ay isang makapangyarihan at standardized na framework na nagpapahusay ng komunikasyon sa pagitan ng Large Language Models (LLMs) at mga external na tools, aplikasyon, at data sources. Ang gabay na ito na SEO-optimized ay maglalakad sa iyo sa mga pangunahing konsepto ng MCP, upang maintindihan mo ang client-server architecture nito, mga mahahalagang bahagi, mekanismo ng komunikasyon, at mga pinakamahusay na kasanayan sa implementasyon.

## Overview

Tatalakayin sa araling ito ang pangunahing arkitektura at mga bahagi na bumubuo sa Model Context Protocol (MCP) ecosystem. Malalaman mo ang tungkol sa client-server architecture, mga pangunahing bahagi, at mekanismo ng komunikasyon na nagpapatakbo sa mga interaksyon ng MCP.

## 👩‍🎓 Key Learning Objectives

Sa pagtatapos ng araling ito, matututuhan mo:

- Ang client-server architecture ng MCP.
- Ang mga papel at responsibilidad ng Hosts, Clients, at Servers.
- Suriin ang mga pangunahing katangian na nagpapalawak ng kakayahan ng MCP bilang isang flexible integration layer.
- Paano dumadaloy ang impormasyon sa loob ng MCP ecosystem.
- Makakuha ng praktikal na kaalaman sa pamamagitan ng mga halimbawa ng code sa .NET, Java, Python, at JavaScript.

## 🔎 MCP Architecture: A Deeper Look

Ang MCP ecosystem ay nakabase sa client-server model. Ang modular na istrukturang ito ay nagpapahintulot sa mga AI application na makipag-ugnayan sa mga tools, databases, APIs, at mga contextual resources nang mas epektibo. Hatiin natin ang arkitekturang ito sa mga pangunahing bahagi nito.

### 1. Hosts

Sa Model Context Protocol (MCP), mahalaga ang papel ng Hosts bilang pangunahing interface kung saan nakikipag-ugnayan ang mga user sa protocol. Ang Hosts ay mga aplikasyon o kapaligiran na nagsisimula ng koneksyon sa MCP servers para ma-access ang data, tools, at prompts. Halimbawa ng Hosts ay mga integrated development environments (IDEs) tulad ng Visual Studio Code, AI tools tulad ng Claude Desktop, o mga custom-built agents para sa partikular na gawain.

**Hosts** ay mga LLM application na nagsisimula ng koneksyon. Sila ay:

- Nagpapatakbo o nakikipag-ugnayan sa AI models para gumawa ng mga sagot.
- Nagsisimula ng koneksyon sa MCP servers.
- Namamahala sa daloy ng usapan at user interface.
- Kumokontrol sa mga permiso at seguridad.
- Humahawak ng pahintulot ng user para sa data sharing at pagpapatakbo ng tools.

### 2. Clients

Ang Clients ay mahalagang bahagi na nagpapadali ng interaksyon sa pagitan ng Hosts at MCP servers. Gumaganap ang Clients bilang mga tagapamagitan, na nagbibigay-daan sa Hosts na ma-access at magamit ang mga functionality na ibinibigay ng MCP servers. Mahalaga ang papel nila para sa maayos na komunikasyon at episyenteng palitan ng data sa loob ng MCP architecture.

**Clients** ay mga connector sa loob ng host application. Sila ay:

- Nagpapadala ng mga request sa servers kasama ang prompts o instructions.
- Nakikipag-negosasyon sa mga kakayahan sa servers.
- Namamahala ng mga kahilingan para sa pagpapatakbo ng tools mula sa mga modelo.
- Nagpoproseso at nagpapakita ng mga sagot sa mga user.

### 3. Servers

Ang Servers ang responsable sa pagtanggap ng mga request mula sa MCP clients at pagbibigay ng angkop na tugon. Pinamamahalaan nila ang iba't ibang operasyon tulad ng pagkuha ng data, pagpapatakbo ng tools, at paggawa ng prompts. Tinitiyak ng servers na ang komunikasyon sa pagitan ng clients at Hosts ay episyente at maaasahan, pinananatili ang integridad ng proseso ng interaksyon.

**Servers** ay mga serbisyo na nagbibigay ng konteksto at kakayahan. Sila ay:

- Nagrerehistro ng mga available na features (resources, prompts, tools).
- Tumatanggap at nagpapatakbo ng tool calls mula sa client.
- Nagbibigay ng contextual na impormasyon para mapahusay ang mga sagot ng modelo.
- Nagbabalik ng outputs pabalik sa client.
- Nananatili ang estado sa mga interaksyon kung kinakailangan.

Maaaring gawin ng kahit sino ang mga servers upang palawakin ang kakayahan ng modelo gamit ang espesyal na functionality.

### 4. Server Features

Ang mga servers sa Model Context Protocol (MCP) ay nagbibigay ng mga pangunahing bahagi na nagpapahintulot sa mas malawak na interaksyon sa pagitan ng clients, hosts, at language models. Dinisenyo ang mga ito para palawakin ang kakayahan ng MCP sa pamamagitan ng pagbibigay ng istrukturadong konteksto, tools, at prompts.

Maaaring mag-alok ang MCP servers ng alinman sa mga sumusunod na features:

#### 📑 Resources

Ang Resources sa Model Context Protocol (MCP) ay sumasaklaw sa iba't ibang uri ng konteksto at data na maaaring gamitin ng mga user o AI models. Kasama dito ang:

- **Contextual Data**: Impormasyon at konteksto na maaaring gamitin ng user o AI models para sa paggawa ng desisyon at pagsasagawa ng gawain.
- **Knowledge Bases at Document Repositories**: Koleksyon ng istrukturado at hindi istrukturadong data, tulad ng mga artikulo, manwal, at research papers, na nagbibigay ng mahahalagang impormasyon.
- **Local Files at Databases**: Data na nakaimbak lokal sa mga device o databases, na maaaring gamitin para sa pagproseso at pagsusuri.
- **APIs at Web Services**: Mga external na interface at serbisyo na nagbibigay ng dagdag na data at functionality, na nagpapahintulot sa integrasyon sa iba't ibang online na resources at tools.

Halimbawa ng resource ay maaaring isang database schema o file na maaaring ma-access tulad nito:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Ang Prompts sa Model Context Protocol (MCP) ay kinabibilangan ng iba't ibang pre-defined na templates at interaction patterns na dinisenyo para gawing mas madali ang workflow ng user at mapahusay ang komunikasyon. Kasama dito ang:

- **Templated Messages at Workflows**: Mga pre-istrukturadong mensahe at proseso na gumagabay sa user sa mga partikular na gawain at interaksyon.
- **Pre-defined Interaction Patterns**: Standardized na mga sunod-sunod ng aksyon at tugon na nagpapadali ng consistent at episyenteng komunikasyon.
- **Specialized Conversation Templates**: Mga nababagay na template para sa partikular na uri ng pag-uusap, na tinitiyak na ang interaksyon ay angkop sa konteksto.

Ganito ang hitsura ng isang prompt template:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Tools

Ang Tools sa Model Context Protocol (MCP) ay mga function na maaaring patakbuhin ng AI model para magsagawa ng partikular na gawain. Dinisenyo ang mga ito para palawakin ang kakayahan ng AI model sa pamamagitan ng pagbibigay ng istrukturado at maaasahang operasyon. Pangunahing aspeto ay:

- **Mga function na maaaring patakbuhin ng AI model**: Ang tools ay mga executable na function na maaaring tawagin ng AI model para gawin ang iba't ibang gawain.
- **Natanging Pangalan at Deskripsyon**: Bawat tool ay may kakaibang pangalan at detalyadong paglalarawan na nagpapaliwanag ng layunin at functionality nito.
- **Mga Parameter at Output**: Tumanggap ang mga tools ng partikular na mga parameter at nagbabalik ng istrukturadong output, na tinitiyak ang consistent at predictable na resulta.
- **Discrete Functions**: Ang mga tools ay nagsasagawa ng discrete functions tulad ng web searches, kalkulasyon, at database queries.

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

Sa Model Context Protocol (MCP), nag-aalok ang clients ng ilang mahahalagang features sa servers, na nagpapahusay sa pangkalahatang functionality at interaksyon sa protocol. Isa sa mga kapansin-pansing feature ay ang Sampling.

### 👉 Sampling

- **Server-Initiated Agentic Behaviors**: Pinapahintulutan ng clients ang servers na magsimula ng partikular na aksyon o pag-uugali nang autonomously, na nagpapalawak ng dynamic na kakayahan ng sistema.
- **Recursive LLM Interactions**: Pinapayagan ng feature na ito ang recursive na interaksyon sa mga large language models (LLMs), na nagbibigay-daan sa mas kumplikado at paulit-ulit na pagproseso ng mga gawain.
- **Requesting Additional Model Completions**: Maaaring humiling ang servers ng karagdagang mga completion mula sa modelo, na tinitiyak na ang mga sagot ay kumpleto at naaayon sa konteksto.

## Information Flow in MCP

Ang Model Context Protocol (MCP) ay nagtatakda ng istrukturadong daloy ng impormasyon sa pagitan ng hosts, clients, servers, at models. Ang pag-unawa sa daloy na ito ay nakakatulong para malinawan kung paano pinoproseso ang mga kahilingan ng user at paano isinisingit ang mga external tools at data sa mga sagot ng modelo.

- **Host Initiates Connection**  
  Ang host application (tulad ng IDE o chat interface) ay nagtatag ng koneksyon sa MCP server, karaniwang gamit ang STDIO, WebSocket, o iba pang suportadong transport.

- **Capability Negotiation**  
  Nagpapalitan ng impormasyon ang client (na naka-embed sa host) at ang server tungkol sa mga suportadong features, tools, resources, at protocol versions. Tinitiyak nito na parehong nauunawaan ng magkabilang panig ang mga kakayahan na available para sa session.

- **User Request**  
  Nakikipag-ugnayan ang user sa host (halimbawa, naglalagay ng prompt o command). Kinokolekta ng host ang input na ito at ipinapasa sa client para iproseso.

- **Resource or Tool Use**  
  - Maaaring humiling ang client ng karagdagang konteksto o resources mula sa server (tulad ng mga file, database entries, o knowledge base articles) para mapalawak ang pag-unawa ng modelo.
  - Kung napagpasyahan ng modelo na kailangan ang isang tool (halimbawa, para kumuha ng data, magsagawa ng kalkulasyon, o tumawag ng API), nagpapadala ang client ng tool invocation request sa server, kasama ang pangalan ng tool at mga parameter.

- **Server Execution**  
  Tinatanggap ng server ang resource o tool request, isinasagawa ang kinakailangang operasyon (tulad ng pagpapatakbo ng function, pag-query sa database, o pagkuha ng file), at ibinabalik ang resulta sa client sa isang istrukturadong format.

- **Response Generation**  
  Isinasama ng client ang mga sagot mula sa server (data mula sa resource, output ng tool, atbp.) sa kasalukuyang interaksyon ng modelo. Ginagamit ng modelo ang impormasyong ito para gumawa ng komprehensibo at naaayon sa konteksto na sagot.

- **Result Presentation**  
  Natatanggap ng host ang panghuling output mula sa client at ipinapakita ito sa user, madalas na kinabibilangan ng parehong text na ginawa ng modelo at anumang resulta mula sa pagpapatakbo ng tools o pagkuha ng resources.

Pinapahintulutan ng daloy na ito ang MCP na suportahan ang mga advanced, interactive, at context-aware na AI applications sa pamamagitan ng seamless na pagkonekta ng mga modelo sa mga external tools at data sources.

## Protocol Details

Ang MCP (Model Context Protocol) ay nakabase sa ibabaw ng [JSON-RPC 2.0](https://www.jsonrpc.org/), na nagbibigay ng standardized at language-agnostic na format ng mensahe para sa komunikasyon sa pagitan ng hosts, clients, at servers. Ang pundasyong ito ay nagpapahintulot ng maaasahan, istrukturado, at extensible na interaksyon sa iba't ibang platform at programming languages.

### Key Protocol Features

Pinalalawak ng MCP ang JSON-RPC 2.0 gamit ang karagdagang conventions para sa tool invocation, resource access, at prompt management. Sinusuportahan nito ang iba't ibang transport layers (STDIO, WebSocket, SSE) at nagpapahintulot ng secure, extensible, at language-agnostic na komunikasyon sa pagitan ng mga bahagi.

#### 🧢 Base Protocol

- **JSON-RPC Message Format**: Lahat ng request at response ay gumagamit ng JSON-RPC 2.0 specification, na tinitiyak ang consistent na istruktura para sa mga method calls, parameters, resulta, at error handling.
- **Stateful Connections**: Pinananatili ng MCP sessions ang estado sa maraming request, sumusuporta sa tuloy-tuloy na pag-uusap, pag-iipon ng konteksto, at pamamahala ng resources.
- **Capability Negotiation**: Sa pagsisimula ng koneksyon, nagpapalitan ng impormasyon ang clients at servers tungkol sa mga suportadong features, protocol versions, available tools, at resources. Tinitiyak nito na nauunawaan ng magkabilang panig ang kakayahan ng isa't isa at nakakapag-adapt nang naaayon.

#### ➕ Additional Utilities

Narito ang ilan pang utilities at extension ng protocol na ibinibigay ng MCP para mapahusay ang karanasan ng developer at suportahan ang mga advanced na senaryo:

- **Configuration Options**: Pinapayagan ng MCP ang dynamic na pag-configure ng mga session parameter, tulad ng tool permissions, resource access, at model settings, na iniangkop sa bawat interaksyon.
- **Progress Tracking**: Ang mga mahahabang operasyon ay maaaring mag-ulat ng progreso, na nagpapahintulot ng responsive na user interface at mas magandang karanasan sa mga kumplikadong gawain.
- **Request Cancellation**: Maaaring kanselahin ng clients ang mga kasalukuyang request, na nagbibigay-daan sa mga user na itigil ang mga operasyong hindi na kailangan o masyadong matagal.
- **Error Reporting**: Standardized na mga error message at code ang tumutulong sa pag-diagnose ng mga problema, paghawak ng mga pagkabigo nang maayos, at pagbibigay ng actionable na feedback sa mga user at developer.
- **Logging**: Parehong clients at servers ay maaaring maglabas ng istrukturadong logs para sa auditing, debugging, at pagmamanman ng mga interaksyon sa protocol.

Sa pamamagitan ng paggamit ng mga feature ng protocol na ito, tinitiyak ng MCP ang matatag, ligtas, at flexible na komunikasyon sa pagitan ng language models at mga external tools o data sources.

### 🔐 Security Considerations

Dapat sumunod ang mga implementasyon ng MCP sa ilang mahahalagang prinsipyo ng seguridad upang matiyak ang ligtas at mapagkakatiwalaang interaksyon:

- **User Consent and Control**: Dapat magbigay ang mga user ng malinaw na pahintulot bago ma-access ang anumang data o maisagawa ang mga operasyon. Dapat may malinaw silang kontrol kung anong data ang ibabahagi at kung anong aksyon ang pinapayagan, na sinusuportahan ng madaling gamitin na interface para sa pagsusuri at pag-apruba ng mga gawain.

- **Data Privacy**: Ang data ng user ay dapat ilantad lamang sa malinaw na pahintulot at dapat protektado ng angkop na access control. Dapat maprotektahan ng implementasyon ng MCP laban sa hindi awtorisadong pagpapadala ng data at matiyak ang privacy sa lahat ng interaksyon.

- **Tool Safety**: Bago tumawag ng anumang tool, kinakailangan ang malinaw na pahintulot ng user. Dapat malinaw sa user ang functionality ng bawat tool, at dapat ipatupad ang matibay na mga hangganan ng seguridad upang maiwasan ang hindi sinasadyang o delikadong pagpapatakbo ng mga tools.

Sa pagsunod sa mga prinsipyong ito, tinitiyak ng MCP na ang tiwala, privacy, at kaligtasan ng user ay mapanatili sa lahat ng interaksyon sa protocol.

## Code Examples: Key Components

Narito ang mga halimbawa ng code sa ilang kilalang programming languages na nagpapakita kung paano mag-implement ng mga pangunahing MCP server components at tools.

### .NET Example: Creating a Simple MCP Server with Tools

Narito ang praktikal na halimbawa ng .NET code na nagpapakita kung paano gumawa ng simpleng MCP server na may custom tools. Ipinapakita dito kung paano idefine at irehistro ang mga tools, hawakan ang mga request, at ikonekta ang server gamit ang Model Context Protocol.

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

Ipinapakita ng halimbawa na ito ang parehong MCP server at tool registration tulad ng sa .NET example sa itaas, pero ginawa gamit ang Java.

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

Sa halimbawang ito, ipinapakita kung paano bumuo ng MCP server gamit ang Python. Ipinapakita rin dito ang dalawang magkaibang paraan para gumawa ng tools.

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

Ipinapakita ng halimbawang ito ang paggawa ng MCP server gamit ang JavaScript at kung paano irehistro ang dalawang tools na may kaugnayan sa panahon.

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

Ipinapakita rin ng JavaScript example na ito kung paano gumawa ng MCP client na kumokonekta sa server, nagpapadala ng prompt, at nagpoproseso ng tugon kabilang ang anumang tool calls na ginawa.

## Security and Authorization

Kasama sa MCP ang ilang built-in na konsepto at mekanismo para sa pamamahala ng seguridad at awtorisasyon sa buong protocol:

1. **Tool Permission Control**:  
  Maaaring tukuyin ng clients kung aling mga tools ang pinapayagan gamitin ng modelo sa isang session. Tinitiyak nito na tanging mga tool na malinaw na pinahintulutan lamang ang maa-access, na nagpapababa ng panganib ng hindi sinasadyang o delikadong operasyon. Maaaring i-configure ang mga permiso nang dynamic batay sa kagustuhan ng user, patakaran ng organisasyon, o konteksto ng interaksyon.

2. **Authentication**:  
  Maaaring mangailangan ang servers ng authentication bago payagan ang access sa mga tools, resources, o sensitibong operasyon. Maaaring kabilang dito ang API keys, OAuth tokens, o iba pang mga scheme ng authentication. Tinitiyak ng tamang authentication na tanging mga pinagkakatiwalaang clients at user lang ang makakagamit ng kakayahan ng server.

3. **Validation**:  
  Pinatutupad ang validation ng mga parameter para sa lahat ng tool invocations

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang serbisyong AI na pagsasalin [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o kamalian. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasaling-tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.