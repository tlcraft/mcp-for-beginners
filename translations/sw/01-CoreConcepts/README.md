<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00defb149ee1ac4a799e44a9783c7fc",
  "translation_date": "2025-06-06T18:41:55+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "sw"
}
-->
# 📖 MCP Core Concepts: Kufahamu Protocol ya Muktadha wa Mfano kwa Uunganishaji wa AI

Protocol ya Muktadha wa Mfano (MCP) ni mfumo thabiti na wenye nguvu unaoboreshwa kuwasiliana kati ya Modeli Kubwa za Lugha (LLMs) na zana, programu, na vyanzo vya data vya nje. Mwongozo huu ulioandaliwa kwa SEO utakuelekeza kupitia dhana za msingi za MCP, kuhakikisha unaelewa usanifu wake wa mteja-mtumiaji, vipengele muhimu, mbinu za mawasiliano, na mbinu bora za utekelezaji.

## Muhtasari

Somo hili linachunguza usanifu wa msingi na vipengele vinavyounda mfumo wa MCP. Utajifunza kuhusu usanifu wa mteja-mtumiaji, vipengele muhimu, na mbinu za mawasiliano zinazowezesha mwingiliano wa MCP.

## 👩‍🎓 Malengo Muhimu ya Kujifunza

Mwisho wa somo hili, utakuwa umeweza:

- Kuelewa usanifu wa mteja-mtumiaji wa MCP.
- Kubaini majukumu ya Hosts, Clients, na Servers.
- Kuchambua sifa kuu zinazofanya MCP kuwa tabaka rahisi la uunganishaji.
- Kujifunza jinsi taarifa zinavyotiririka ndani ya mfumo wa MCP.
- Kupata maarifa ya vitendo kupitia mifano ya msimbo katika .NET, Java, Python, na JavaScript.

## 🔎 Usanifu wa MCP: Mtazamo wa Kina

Mfumo wa MCP umejengwa kwa mfano wa mteja-mtumiaji. Muundo huu wa moduli unaruhusu programu za AI kuwasiliana kwa ufanisi na zana, hifadhidata, API, na rasilimali za muktadha. Hebu tugawanye usanifu huu vipengele vyake vya msingi.

### 1. Hosts

Katika Protocol ya Muktadha wa Mfano (MCP), Hosts ni sehemu muhimu kama kiolesura cha msingi ambacho watumiaji hutumia kuingiliana na protocol. Hosts ni programu au mazingira yanayozindua muunganisho na seva za MCP kupata data, zana, na maagizo. Mifano ya Hosts ni mazingira ya maendeleo kama Visual Studio Code, zana za AI kama Claude Desktop, au mawakala maalum yaliyotengenezwa kwa kazi fulani.

**Hosts** ni programu za LLM zinazozindua muunganisho. Wanahakikisha:

- Kutekeleza au kuingiliana na modeli za AI ili kutoa majibu.
- Kuzindua muunganisho na seva za MCP.
- Kusimamia mtiririko wa mazungumzo na kiolesura cha mtumiaji.
- Kudhibiti ruhusa na vizingiti vya usalama.
- Kushughulikia ridhaa za mtumiaji kwa kushiriki data na kutekeleza zana.

### 2. Clients

Clients ni vipengele muhimu vinavyorahisisha mwingiliano kati ya Hosts na seva za MCP. Clients hufanya kazi kama wasuluhishi, kuruhusu Hosts kufikia na kutumia huduma zinazotolewa na seva za MCP. Wanahakikisha mawasiliano laini na kubadilishana data kwa ufanisi ndani ya usanifu wa MCP.

**Clients** ni viunganishi ndani ya programu ya host. Wanahakikisha:

- Kutuma maombi kwa seva kwa maagizo/maelekezo.
- Kujadiliana uwezo na seva.
- Kusimamia maombi ya kutekeleza zana kutoka kwa modeli.
- Kuchakata na kuonyesha majibu kwa watumiaji.

### 3. Servers

Servers ni wale wanaoshughulikia maombi kutoka kwa clients wa MCP na kutoa majibu yanayofaa. Wanadhibiti shughuli mbalimbali kama kupata data, kutekeleza zana, na kuunda maagizo. Servers huhakikisha mawasiliano kati ya clients na Hosts ni ya ufanisi na ya kuaminika, wakidumisha uadilifu wa mchakato wa mwingiliano.

**Servers** ni huduma zinazotoa muktadha na uwezo. Wanahakikisha:

- Kusajili sifa zinazopatikana (rasilimali, maagizo, zana)
- Kupokea na kutekeleza simu za zana kutoka kwa client
- Kutoa taarifa za muktadha ili kuboresha majibu ya modeli
- Kurudisha matokeo kwa client
- Kudumisha hali ya mwingiliano inapohitajika

Servers zinaweza kuundwa na mtu yeyote kuongeza uwezo wa modeli kwa huduma maalum.

### 4. Sifa za Server

Servers katika Protocol ya Muktadha wa Mfano (MCP) hutoa vipengele vya msingi vinavyorahisisha mwingiliano kati ya clients, hosts, na modeli za lugha. Vipengele hivi vimeundwa kuongeza uwezo wa MCP kwa kutoa muktadha uliopangwa, zana, na maagizo.

Servers za MCP zinaweza kutoa mojawapo ya vipengele vifuatavyo:

#### 📑 Rasilimali

Rasilimali katika MCP ni aina mbalimbali za muktadha na data zinazoweza kutumiwa na watumiaji au modeli za AI. Hizi ni pamoja na:

- **Data za Muktadha**: Taarifa na muktadha ambao watumiaji au modeli za AI wanaweza kutumia kwa maamuzi na utekelezaji wa kazi.
- **Misingi ya Maarifa na Hifadhidata za Nyaraka**: Mkusanyiko wa data zilizopangwa na zisizopangwa, kama makala, mwongozo, na makala za utafiti, zinazotoa maarifa na taarifa muhimu.
- **Faili za Ndani na Hifadhidata**: Data zilizohifadhiwa ndani ya vifaa au hifadhidata, zinazopatikana kwa ajili ya usindikaji na uchambuzi.
- **API na Huduma za Mtandao**: Violesura na huduma za nje zinazotoa data na huduma za ziada, kuruhusu uunganishaji na rasilimali na zana mbalimbali mtandaoni.

Mfano wa rasilimali unaweza kuwa muundo wa hifadhidata au faili inayoweza kufikiwa kama ifuatavyo:

```text
file://log.txt
database://schema
```

### 🤖 Maagizo

Maagizo katika MCP ni templeti mbalimbali zilizopangwa awali na mifumo ya mwingiliano iliyoundwa kurahisisha kazi za watumiaji na kuboresha mawasiliano. Hizi ni pamoja na:

- **Ujumbe na Mifumo ya Kazi Iliyopangwa**: Ujumbe na michakato iliyopangwa kabla inayowaongoza watumiaji kupitia kazi na mwingiliano maalum.
- **Mifumo ya Mwingiliano Iliyobainishwa Kabla**: Mfuatano wa hatua na majibu uliowekwa sanjari kurahisisha mawasiliano ya ufanisi na ya kawaida.
- **Templeti Maalum za Mazungumzo**: Templeti zinazoweza kubadilishwa kwa aina maalum za mazungumzo, kuhakikisha mwingiliano unaofaa na wa muktadha.

Templeti ya agizo inaweza kuonekana kama ifuatavyo:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Zana

Zana katika MCP ni kazi ambazo modeli ya AI inaweza kutekeleza kufanya kazi maalum. Zana hizi zimeundwa kuongeza uwezo wa modeli kwa kutoa operesheni zilizo wazi na za kuaminika. Vipengele muhimu ni:

- **Kazi za kutekelezwa na modeli ya AI**: Zana ni kazi zinazoweza kuitwa na modeli ya AI kutekeleza kazi mbalimbali.
- **Jina la Kipekee na Maelezo**: Kila zana ina jina la kipekee na maelezo ya kina yanayoelezea kusudi na kazi yake.
- **Vigezo na Matokeo**: Zana zinapokea vigezo maalum na kurudisha matokeo yaliyopangwa, kuhakikisha matokeo ya kawaida na yanayotarajiwa.
- **Kazi Zilizojitenga**: Zana hufanya kazi zilizojitenga kama utafutaji mtandaoni, hesabu, na maswali ya hifadhidata.

Mfano wa zana unaweza kuonekana kama ifuatavyo:

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

## Sifa za Client

Katika MCP, clients hutoa sifa kadhaa muhimu kwa seva, zikiongeza utendaji na mwingiliano ndani ya protocol. Moja ya sifa maarufu ni Sampuli.

### 👉 Sampuli

- **Tabia za Agentic Zinazozinduliwa na Seva**: Clients huruhusu seva kuzindua vitendo maalum au tabia kwa uhuru, kuongeza uwezo wa mfumo kuwa wa nguvu zaidi.
- **Mwingiliano wa Rudufu na LLM**: Sifa hii inaruhusu mwingiliano wa kurudiwa na modeli kubwa za lugha (LLMs), kuwezesha usindikaji wa kazi ngumu na wa mfululizo.
- **Kutoa Maombi ya Kukamilisha Zaidi ya Modeli**: Seva zinaweza kuomba kukamilisha zaidi kutoka kwa modeli, kuhakikisha majibu ni kamili na yanayofaa kwa muktadha.

## Mtiririko wa Taarifa katika MCP

Protocol ya Muktadha wa Mfano (MCP) inaeleza mtiririko uliopangwa wa taarifa kati ya hosts, clients, servers, na modeli. Kuelewa mtiririko huu husaidia kufafanua jinsi maombi ya mtumiaji yanavyoshughulikiwa na jinsi zana na data za nje zinavyojumuishwa katika majibu ya modeli.

- **Host Inazindua Muunganisho**  
  Programu ya host (kama IDE au kiolesura cha mazungumzo) huanzisha muunganisho na seva ya MCP, kawaida kupitia STDIO, WebSocket, au usafirishaji mwingine unaoungwa mkono.

- **Mazungumzo ya Uwezo**  
  Client (iliyomo ndani ya host) na seva hubadilishana taarifa kuhusu sifa, zana, rasilimali, na matoleo ya protocol wanayounga mkono. Hii huhakikisha pande zote zinajua uwezo uliopo kwa kikao hicho.

- **Ombi la Mtumiaji**  
  Mtumiaji huingiliana na host (mfano, kuingiza agizo au amri). Host hukusanya maingizo haya na kuyapeleka kwa client kwa usindikaji.

- **Matumizi ya Rasilimali au Zana**  
  - Client inaweza kuomba muktadha au rasilimali zaidi kutoka kwa seva (kama faili, rekodi za hifadhidata, au makala za msingi wa maarifa) ili kuongeza ufahamu wa modeli.
  - Ikiwa modeli inaona zana inahitajika (mfano, kupata data, kufanya hesabu, au kuita API), client hutuma ombi la kuitisha zana kwa seva, ikielezea jina la zana na vigezo.

- **Utekelezaji wa Seva**  
  Seva hupokea ombi la rasilimali au zana, hutekeleza shughuli zinazohitajika (kama kuendesha kazi, kuuliza hifadhidata, au kupata faili), na hurudisha matokeo kwa client kwa muundo uliopangwa.

- **Uundaji wa Majibu**  
  Client huunganisha majibu ya seva (data za rasilimali, matokeo ya zana, n.k.) katika mwingiliano unaoendelea wa modeli. Modeli hutumia taarifa hii kutoa jibu kamili na linalofaa kwa muktadha.

- **Uwasilishaji wa Matokeo**  
  Host hupokea matokeo ya mwisho kutoka kwa client na kuonyesha kwa mtumiaji, mara nyingi ikijumuisha maandishi yaliyotengenezwa na modeli pamoja na matokeo yoyote ya utekelezaji wa zana au upatikanaji wa rasilimali.

Mtiririko huu unaiwezesha MCP kuunga mkono programu za AI zenye mwingiliano wa hali ya juu, zenye uelewa wa muktadha kwa kuunganisha modeli na zana na data za nje kwa urahisi.

## Maelezo ya Protocol

MCP (Protocol ya Muktadha wa Mfano) imejengwa juu ya [JSON-RPC 2.0](https://www.jsonrpc.org/), ikitoa muundo wa ujumbe wa kawaida, usioegemea lugha, kwa mawasiliano kati ya hosts, clients, na servers. Msingi huu unaruhusu mwingiliano thabiti, uliopangwa, na unaoweza kupanuka kati ya majukwaa na lugha mbalimbali za programu.

### Sifa Muhimu za Protocol

MCP inaongeza JSON-RPC 2.0 kwa makubaliano ya ziada kwa kuitisha zana, upatikanaji wa rasilimali, na usimamizi wa maagizo. Inasaidia tabaka mbalimbali za usafirishaji (STDIO, WebSocket, SSE) na inaruhusu mawasiliano salama, yanayoweza kupanuka, na yasiyoegemea lugha kati ya vipengele.

#### 🧢 Protocol ya Msingi

- **Muundo wa Ujumbe wa JSON-RPC**: Maombi na majibu yote hutumia vipimo vya JSON-RPC 2.0, kuhakikisha muundo thabiti kwa simu za njia, vigezo, matokeo, na usimamizi wa makosa.
- **Muunganisho wenye Hali**: Kikao cha MCP hudumisha hali kati ya maombi mengi, kuunga mkono mazungumzo yanayoendelea, ukusanyaji wa muktadha, na usimamizi wa rasilimali.
- **Mazungumzo ya Uwezo**: Wakati wa kuanzisha muunganisho, clients na servers hubadilishana taarifa kuhusu sifa zinazoungwa mkono, matoleo ya protocol, zana na rasilimali zinazopatikana. Hii huhakikisha pande zote zinaelewana na kuweza kubadilika ipasavyo.

#### ➕ Zana Zaidi

Hapa chini kuna zana na nyongeza za protocol MCP hutoa ili kuboresha uzoefu wa mendelezaji na kuwezesha hali za juu:

- **Chaguo za Usanidi**: MCP inaruhusu usanidi wa vigezo vya kikao, kama ruhusa za zana, upatikanaji wa rasilimali, na mipangilio ya modeli, iliyobinafsishwa kwa kila mwingiliano.
- **Ufuatiliaji wa Maendeleo**: Shughuli ndefu zinaweza kutoa taarifa za maendeleo, kuruhusu violesura vya mtumiaji kuwa na majibu na kuboresha uzoefu wakati wa kazi ngumu.
- **Kughairi Maombi**: Clients wanaweza kughairi maombi yanayoendelea, kuruhusu watumiaji kusitisha shughuli ambazo hazihitajiki tena au zinachukua muda mrefu.
- **Ripoti za Makosa**: Ujumbe na nambari za makosa zilizobainishwa husaidia kugundua matatizo, kushughulikia makosa kwa upole, na kutoa maoni yanayoweza kutekelezwa kwa watumiaji na mendelezaji.
- **Kufuatilia Logi**: Clients na servers wanaweza kutoa logi zilizopangwa kwa ajili ya ukaguzi, utatuzi wa matatizo, na ufuatiliaji wa mwingiliano wa protocol.

Kwa kutumia sifa hizi za protocol, MCP huhakikisha mawasiliano thabiti, salama, na yenye kubadilika kati ya modeli za lugha na zana au vyanzo vya data vya nje.

### 🔐 Mambo ya Usalama

Matumizi ya MCP yanapaswa kufuata kanuni muhimu za usalama kuhakikisha mwingiliano salama na wa kuaminika:

- **Ridhaa na Udhibiti wa Mtumiaji**: Watumiaji wanapaswa kutoa ridhaa wazi kabla data yoyote kuingiliwa au shughuli kufanywa. Wanapaswa kuwa na udhibiti wazi juu ya data inayoshirikiwa na hatua zinazoruhusiwa, zikiwa na violesura rahisi vya mtumiaji vya kupitia na kuidhinisha shughuli.
- **Faragha ya Data**: Data za watumiaji zinapaswa kufichwa tu kwa ridhaa wazi na kulindwa kwa udhibiti wa upatikanaji unaofaa. Matumizi ya MCP yanapaswa kuzuia usambazaji usioidhinishwa wa data na kuhakikisha faragha inadumishwa katika mwingiliano wote.
- **Usalama wa Zana**: Kabla ya kuitisha zana yoyote, ridhaa wazi ya mtumiaji inahitajika. Watumiaji wanapaswa kuelewa kazi za kila zana, na mipaka thabiti ya usalama inapaswa kuwekwa kuzuia utekelezaji usiofaa au hatari wa zana.

Kwa kufuata kanuni hizi, MCP huhakikisha kuwa imani, faragha, na usalama wa mtumiaji vinadumishwa katika mwingiliano yote ya protocol.

## Mifano ya Msimbo: Vipengele Muhimu

Hapa chini kuna mifano ya msimbo katika lugha maarufu kadhaa inayoonyesha jinsi ya kutekeleza vipengele muhimu vya seva ya MCP na zana.

### Mfano wa .NET: Kuunda Seva Rahisi ya MCP yenye Zana

Huu ni mfano wa msimbo wa .NET unaoonyesha jinsi ya kutekeleza seva rahisi ya MCP yenye zana maalum. Mfano huu unaonyesha jinsi ya kufafanua na kusajili zana, kushughulikia maombi, na kuunganisha seva kwa kutumia Protocol ya Muktadha wa Mfano.

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

### Mfano wa Java: Vipengele vya Seva ya MCP

Mfano huu unaonyesha seva ile ile ya MCP na usajili wa zana kama ilivyo kwenye mfano wa .NET hapo juu, lakini imeandikwa kwa Java.

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

### Mfano wa Python: Kujenga Seva ya MCP

Katika mfano huu tunaonyesha jinsi ya kujenga seva ya MCP kwa Python. Pia unaonyeshwa njia mbili tofauti za kuunda zana.

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

### Mfano wa JavaScript: Kuunda Seva ya MCP

Mfano huu unaonyesha uundaji wa seva ya MCP kwa JavaScript na jinsi ya kusajili zana mbili zinazohusiana na hali ya hewa.

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

Mfano huu wa JavaScript unaonyesha jinsi ya kuunda client wa MCP anayehudhuria seva, kutuma agizo, na kushughulikia jibu ikiwa ni pamoja na simu za zana zilizofanywa.

## Usalama na Idhini

MCP ina dhana na mbinu kadhaa za ndani za kusimamia usalama na idhini katika protocol nzima:

1. **Udhibiti wa Ruhusa za Zana**:  
  Clients wanaweza kubainisha zana gani modeli inaruhusiwa kutumia wakati

**Maelezo ya kukanusha**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha kuaminika. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inashauriwa. Hatuna dhamana kwa kutoelewana au tafsiri potofu zitokanazo na matumizi ya tafsiri hii.