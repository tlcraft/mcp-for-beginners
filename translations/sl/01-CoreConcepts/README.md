<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "154c00dc3b2c792102e4845c19fbd166",
  "translation_date": "2025-05-20T18:27:12+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "sl"
}
-->
# 📖 MCP Core Concepts: Mojtama Model Context Protocol par AI Integration

Model Context Protocol (MCP) ek takatwar, standardized framework hai jo Large Language Models (LLMs) aur external tools, applications, aur data sources ke darmiyan communication ko optimize karta hai. Yeh SEO-optimized guide aapko MCP ke core concepts samjhata hai, jisme client-server architecture, zaroori components, communication ke tareeqe, aur implementation ke best practices shamil hain.

## Overview

Is sabaq mein hum Model Context Protocol (MCP) ke bunyadi architecture aur components ka jaiza lenge. Aap client-server architecture, key components, aur communication ke tareeqe samjhenge jo MCP interactions ko chalate hain.

## 👩‍🎓 Key Learning Objectives

Is sabaq ke end tak aap:

- MCP client-server architecture ko samjhenge.
- Hosts, Clients, aur Servers ke roles aur zimmedariyan pehchanenge.
- MCP ko ek flexible integration layer banane wale core features ka tajziya karenge.
- MCP ecosystem mein information ke flow ko samjhenge.
- .NET, Java, Python, aur JavaScript mein code examples ke zariye practical insights hasil karenge.

## 🔎 MCP Architecture: Ek Gehri Nazar

MCP ecosystem client-server model par mabni hai. Yeh modular structure AI applications ko tools, databases, APIs, aur contextual resources ke saath asaani se interact karne deta hai. Aaiye is architecture ko uske bunyadi components mein todte hain.

### 1. Hosts

Model Context Protocol (MCP) mein Hosts ek aham kirdar ada karte hain jo users ko protocol ke primary interface ke taur par connect karte hain. Hosts woh applications ya environments hain jo MCP servers se data, tools, aur prompts hasil karne ke liye connections shuru karte hain. Misal ke taur par Visual Studio Code jaise IDEs, Claude Desktop jese AI tools, ya khas tasks ke liye banaye gaye custom agents.

**Hosts** LLM applications hain jo connections initiate karte hain. Yeh:

- AI models ke saath interact ya execute kar ke responses banate hain.
- MCP servers se connections shuru karte hain.
- Conversation flow aur user interface ko manage karte hain.
- Permissions aur security constraints ko control karte hain.
- Data sharing aur tool execution ke liye user consent handle karte hain.

### 2. Clients

Clients woh zaroori components hain jo Hosts aur MCP servers ke darmiyan interaction ko asaan banate hain. Yeh intermediaries ka kirdar ada karte hain, jisse Hosts MCP servers ki functionalities tak access aur istemal kar sakte hain. Yeh MCP architecture mein smooth communication aur efficient data exchange ko yaqini banate hain.

**Clients** host application ke andar connectors hote hain. Yeh:

- Servers ko prompts/instructions ke saath requests bhejte hain.
- Servers ke saath capabilities negotiate karte hain.
- Models se tool execution requests ko manage karte hain.
- Users ko responses process aur display karte hain.

### 3. Servers

Servers MCP clients se requests receive karte hain aur munasib responses dete hain. Yeh data retrieval, tool execution, aur prompt generation jaise operations ko manage karte hain. Servers ensure karte hain ke clients aur Hosts ke darmiyan communication efficient aur reliable ho, interaction process ki integrity barqarar rahe.

**Servers** services hain jo context aur capabilities provide karte hain. Yeh:

- Available features (resources, prompts, tools) ko register karte hain.
- Client se tool calls receive aur execute karte hain.
- Model responses ko behtar banane ke liye contextual information dete hain.
- Outputs client ko wapas bhejte hain.
- Zarurat par state ko interactions ke darmiyan maintain karte hain.

Servers kisi bhi developer ke zariye banaye ja sakte hain taake model capabilities ko specialized functionalities ke saath barhaya ja sake.

### 4. Server Features

MCP servers aise bunyadi building blocks provide karte hain jo clients, hosts, aur language models ke darmiyan rich interactions ko mumkin banate hain. Yeh features MCP ki capabilities ko structured context, tools, aur prompts ke zariye enhance karte hain.

MCP servers in features mein se koi bhi offer kar sakte hain:

#### 📑 Resources

Model Context Protocol (MCP) mein Resources mukhtalif qisam ke context aur data hain jo users ya AI models istemal kar sakte hain. In mein shamil hain:

- **Contextual Data**: Maloomat aur context jo users ya AI models decision-making aur task execution ke liye istemal karte hain.
- **Knowledge Bases aur Document Repositories**: Structured aur unstructured data ka majmua, jaise articles, manuals, research papers, jo qeemti maloomat faraham karte hain.
- **Local Files aur Databases**: Aise data jo devices par ya databases mein local tor par store hota hai, jo processing aur analysis ke liye dastiyab hota hai.
- **APIs aur Web Services**: External interfaces aur services jo mazeed data aur functionalities faraham karte hain, jisse online resources aur tools ke saath integration mumkin hota hai.

Resource ki ek misaal database schema ya file ho sakti hai jo is tarah access ki ja sakti hai:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Model Context Protocol (MCP) mein Prompts mukhtalif pre-defined templates aur interaction patterns hote hain jo user workflows ko streamline karte hain aur communication behtar banate hain. In mein shamil hain:

- **Templated Messages aur Workflows**: Pehle se tayar shuda messages aur processes jo users ko specific tasks aur interactions mein guide karte hain.
- **Pre-defined Interaction Patterns**: Standard sequences of actions aur responses jo consistent aur efficient communication ko facilitate karte hain.
- **Specialized Conversation Templates**: Customizable templates jo mukhtalif conversation types ke liye banaye gaye hain, taake relevant aur contextually munasib interactions ho sakein.

Prompt template kuch is tarah lag sakta hai:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Tools

Model Context Protocol (MCP) mein Tools woh functions hain jo AI model specific tasks perform karne ke liye execute kar sakta hai. Yeh tools AI model ki capabilities ko structured aur reliable operations ke zariye barhate hain. Key aspects yeh hain:

- **AI model ke liye executable functions**: Tools aise functions hain jo AI model invoke kar sakta hai taake mukhtalif tasks anjaam de.
- **Unique Name aur Description**: Har tool ka ek munfarid naam aur tafseeli wazahat hoti hai jo uske maqsad aur functionality ko bayan karti hai.
- **Parameters aur Outputs**: Tools specific parameters accept karte hain aur structured outputs dete hain, jo consistent aur predictable results ko yaqini banata hai.
- **Discrete Functions**: Tools alag alag functions perform karte hain jaise web searches, calculations, aur database queries.

Ek misaal tool kuch is tarah ho sakta hai:

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

Model Context Protocol (MCP) mein clients servers ko kuch key features provide karte hain jo protocol ki overall functionality aur interaction ko behtar banate hain. In mein se ek aham feature Sampling hai.

### 👉 Sampling

- **Server-Initiated Agentic Behaviors**: Clients servers ko yeh ijazat dete hain ke wo specific actions ya behaviors apne aap initiate kar saken, jis se system ki dynamic capabilities barhti hain.
- **Recursive LLM Interactions**: Yeh feature large language models (LLMs) ke recursive interactions ko mumkin banata hai, jo zyada complex aur iterative task processing ko support karta hai.
- **Additional Model Completions ki Request**: Servers model se mazeed completions ki darkhwast kar sakte hain, taake responses mukammal aur context ke mutabiq hon.

## MCP mein Information Flow

Model Context Protocol (MCP) hosts, clients, servers, aur models ke darmiyan structured information flow define karta hai. Is flow ko samajhne se yeh wazeh hota hai ke user requests kaise process hoti hain aur external tools aur data model responses mein kaise shamil hote hain.

- **Host Connection Initiate karta hai**  
  Host application (jaise IDE ya chat interface) MCP server se connection establish karta hai, aam tor par STDIO, WebSocket, ya kisi aur supported transport ke zariye.

- **Capability Negotiation**  
  Client (jo host mein embedded hota hai) aur server apni supported features, tools, resources, aur protocol versions ke mutaliq maloomat ka tabadla karte hain. Is se dono taraf ko pata chalta hai ke session ke liye kaun si capabilities available hain.

- **User Request**  
  User host ke saath interact karta hai (jaise prompt ya command type karta hai). Host yeh input collect karta hai aur client ko processing ke liye bhejta hai.

- **Resource ya Tool Use**  
  - Client server se mazeed context ya resources (files, database entries, ya knowledge base articles) maang sakta hai taake model ki samajh behtar ho.
  - Agar model ko lagta hai ke tool ki zarurat hai (jaise data fetch karna, calculation karna, ya API call karna), client server ko tool invocation request bhejta hai, jisme tool ka naam aur parameters specified hote hain.

- **Server Execution**  
  Server resource ya tool request receive karta hai, zaroori operations execute karta hai (jaise function chalana, database query karna, ya file retrieve karna), aur results client ko structured format mein wapas bhejta hai.

- **Response Generation**  
  Client server ke responses (resource data, tool outputs, waghera) ko model interaction mein integrate karta hai. Model is maloomat ka istemal karke comprehensive aur contextually relevant response banata hai.

- **Result Presentation**  
  Host client se final output receive karta hai aur user ko display karta hai, jisme aam tor par model ki generated text aur tool executions ya resource lookups ke results shamil hote hain.

Yeh flow MCP ko advanced, interactive, aur context-aware AI applications support karne ke qabil banata hai jo models ko external tools aur data sources ke saath seamlessly connect karta hai.

## Protocol Details

MCP (Model Context Protocol) [JSON-RPC 2.0](https://www.jsonrpc.org/) par mabni hai, jo hosts, clients, aur servers ke darmiyan communication ke liye standardized, language-agnostic message format provide karta hai. Yeh bunyad mukhtalif platforms aur programming languages mein reliable, structured, aur extensible interactions ko mumkin banati hai.

### Key Protocol Features

MCP JSON-RPC 2.0 ko tools invocation, resource access, aur prompt management ke liye mazeed conventions ke sath extend karta hai. Yeh multiple transport layers (STDIO, WebSocket, SSE) support karta hai aur components ke darmiyan secure, extensible, aur language-agnostic communication enable karta hai.

#### 🧢 Base Protocol

- **JSON-RPC Message Format**: Tamam requests aur responses JSON-RPC 2.0 specification par mabni hoti hain, jo method calls, parameters, results, aur error handling ke liye consistent structure ensure karti hai.
- **Stateful Connections**: MCP sessions multiple requests ke darmiyan state maintain karte hain, ongoing conversations, context accumulation, aur resource management ko support karte hain.
- **Capability Negotiation**: Connection setup ke dauran clients aur servers apni supported features, protocol versions, available tools, aur resources ke mutaliq maloomat ka tabadla karte hain. Is se dono taraf ko ek doosre ki capabilities ka pata chalta hai aur wo accordingly adapt kar sakte hain.

#### ➕ Additional Utilities

Neeche kuch mazeed utilities aur protocol extensions hain jo MCP developers ke experience ko behtar banane aur advanced scenarios enable karne ke liye provide karta hai:

- **Configuration Options**: MCP session parameters jaise tool permissions, resource access, aur model settings ko dynamic tor par configure karne ki sahulat deta hai, jo har interaction ke mutabiq tailor ki ja sakti hain.
- **Progress Tracking**: Long-running operations progress updates report kar sakte hain, jis se responsive user interfaces aur behtar user experience complex tasks ke dauran mumkin hota hai.
- **Request Cancellation**: Clients in-flight requests cancel kar sakte hain, jis se users un operations ko rok sakte hain jo ab zaroori nahi ya zyada waqt le rahe hain.
- **Error Reporting**: Standardized error messages aur codes issues diagnose karne, failures ko gracefully handle karne, aur users aur developers ko actionable feedback dene mein madadgar hote hain.
- **Logging**: Clients aur servers dono structured logs emit kar sakte hain jo auditing, debugging, aur protocol interactions ki monitoring ke liye zaroori hain.

In protocol features ke zariye MCP robust, secure, aur flexible communication ensure karta hai language models aur external tools ya data sources ke darmiyan.

### 🔐 Security Considerations

MCP implementations ko kuch aham security principles ki pabandi karni chahiye taake safe aur trustworthy interactions ho sakein:

- **User Consent aur Control**: Kisi bhi data access ya operation se pehle users ki wazeh raza mandi zaroori hai. Users ko yeh control milna chahiye ke wo kaunsa data share karte hain aur kaun si actions authorize karte hain, jise samajhne aur approve karne ke liye user-friendly interfaces hon.
- **Data Privacy**: User data sirf explicit consent ke sath expose hona chahiye aur munasib access controls ke zariye mehfooz rehna chahiye. MCP implementations unauthorized data transmission se bachayen aur privacy har interaction mein barqarar rakhen.
- **Tool Safety**: Kisi bhi tool ko invoke karne se pehle user ki explicit consent lena zaroori hai. Users ko har tool ki functionality ka wazeh pata hona chahiye, aur mazboot security boundaries enforce karni chahiye taake tools ka unintended ya unsafe istemal na ho.

In principles par amal karke MCP user trust, privacy, aur safety ko protocol interactions mein barqarar rakhta hai.

## Code Examples: Key Components

Neeche chand mashhoor programming languages mein code examples diye gaye hain jo MCP server components aur tools ko implement karne ka tariqa dikhate hain.

### .NET Example: Simple MCP Server with Tools Banana

Yeh practical .NET code example dikhata hai ke simple MCP server kaise implement kiya jaye custom tools ke sath. Yeh example tools define karne, register karne, requests handle karne, aur Model Context Protocol ke zariye server connect karne ka tariqa batata hai.

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

Yeh example upar wale .NET example jaisa MCP server aur tool registration Java mein implement karta hai.

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

### Python Example: MCP Server Banana

Is example mein dikhaya gaya hai ke Python mein MCP server kaise banaya jaye. Aapko do mukhtalif tareeqe tools banane ke bhi dikhaye gaye hain.

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

### JavaScript Example: MCP Server Banana

Yeh example JavaScript mein MCP server creation aur do weather-related tools register karne ka tariqa dikhata hai.

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

Yeh JavaScript example dikhata hai ke MCP client kaise server se connect karta hai, prompt bhejta hai, aur response process karta hai jisme tool calls bhi shamil hain.

## Security aur Authorization

MCP mein security aur authorization manage karne ke liye kuch built-in concepts aur mechanisms mojood hain:

1. **Tool Permission Control**  
  Clients specify kar sakte hain ke model session ke dauran kaun se tools use kar sakta hai. Yeh ensure karta hai ke sirf explicitly authorized tools accessible hon, jis se unintended ya unsafe operations ka risk kam hota hai. Permissions user preferences, organizational policies, ya interaction context ke mutabiq dynamically configure ki ja sakti hain.

2. **Authentication**  
  Servers tools, resources, ya sensitive operations tak access dene se pehle authentication talab kar sakte hain. Is mein API keys, OAuth tokens, ya dusre authentication schemes shamil ho sakte hain. Proper authentication ensure karti hai ke sirf trusted clients aur users server-side capabilities invoke kar saken.

3. **Validation**  
  Tamam tool invocations ke liye parameter validation enforce ki jati hai. Har tool apne parameters ke expected types, formats, aur constraints define karta hai, aur server incoming requests ko validate karta hai. Yeh malformed ya malicious input ko tool implementations tak pohanchne se rokta hai aur operations ki integrity barqarar rakhta hai.

4. **Rate Limiting**  
  Abuse rokne aur server resources ka munasib istemal yaqini banane ke liye MCP servers tool calls aur resource access par rate limiting implement kar sakte hain. Rate limits per user, per session, ya globally lagayi ja sakti hain, jo denial-of-service attacks ya excessive resource consumption se bachati hain.

In mechanisms ke zariye MCP language models ko external tools aur data sources ke saath secure integration ke liye mazboot bunyad faraham karta hai, aur users aur developers ko access aur usage par fine-grained control deta hai.

## Protocol Messages

MCP communication structured JSON messages ka istemal karta hai taake clients, servers, aur models ke darmiyan wazeh aur reliable interactions ho saken. Main message types yeh hain:

- **Client Request**  
  Client se server ko bheja jata hai, aam tor par is mein shamil hota hai:
  - User ka prompt ya command
  - Conversation history context ke liye
  - Tool configuration aur permissions
  - Mazeed metadata ya session maloomat

- **Model Response**  
  Model (client ke zariye) se wapas aata hai, is mein hota hai:
  - Prompt aur context ke mutabiq generated text ya completion
  - Optional tool call instructions agar model decide kare ke tool invoke karna hai
  - Zarurat par resources ya additional context ke references

- **Tool Request**  
  Client se server ko tab bheja jata hai jab tool execute karna ho. Is message mein shamil hota hai:
  - Invoke karne wale tool ka naam
  - Tool ke parameters (tool ke schema ke mutabiq validate kiye gaye)
  - Contextual information ya request tracking ke liye identifiers

- **Tool Response**  
  Server se tool execution ke baad wapas aata hai. Yeh message deta hai:
  - Tool execution ke results (structured data ya content)
  - Agar tool call fail ho to errors ya status information
  - Zarurat par execution se related mazeed metadata ya logs

Yeh structured messages ensure karte hain ke MCP workflow ke har step mein wazahat, traceability, aur extensibility ho, jo multi-turn conversations, tool chaining, aur robust error handling jaise advanced scenarios ko support karta hai.

## Key Takeaways

- MCP client-server architecture use karta hai taake models ko external

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za avtomatski prevod [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da avtomatski prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvorno jeziku je treba šteti za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Nismo odgovorni za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.