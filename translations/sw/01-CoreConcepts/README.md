<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "788eb17750e970a0bc3b5e7f2e99975b",
  "translation_date": "2025-05-18T15:30:06+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "sw"
}
-->
# 📖 MCP Core Concepts: Kujuwa Model Context Protocol kwa Uingizaji wa AI

Model Context Protocol (MCP) ni mfumo thabiti na wenye nguvu unaoimarisha mawasiliano kati ya Large Language Models (LLMs) na zana za nje, programu, na vyanzo vya data. Mwongozo huu ulioandaliwa kwa SEO utakuelekeza kupitia dhana kuu za MCP, kuhakikisha unaelewa usanifu wake wa mteja-server, vipengele muhimu, mbinu za mawasiliano, na mbinu bora za utekelezaji.

## Muhtasari

Somo hili linachunguza usanifu wa msingi na vipengele vinavyounda mfumo wa Model Context Protocol (MCP). Utajifunza kuhusu usanifu wa mteja-server, vipengele muhimu, na mbinu za mawasiliano zinazowezesha mwingiliano wa MCP.

## 👩‍🎓 Malengo Muhimu ya Kujifunza

Mwisho wa somo hili, utakuwa na uwezo wa:

- Kuelewa usanifu wa mteja-server wa MCP.
- Kutambua majukumu ya Hosts, Clients, na Servers.
- Kuchambua vipengele kuu vinavyofanya MCP kuwa safu ya kuunganisha yenye kubadilika.
- Kujifunza jinsi taarifa zinavyotiririka ndani ya mfumo wa MCP.
- Kupata maarifa ya vitendo kupitia mifano ya msimbo katika .NET, Java, Python, na JavaScript.

## 🔎 Usanifu wa MCP: Mtazamo wa Kina

Mfumo wa MCP umejengwa kwa mfano wa mteja-server. Muundo huu wa moduli unaruhusu programu za AI kuunganishwa kwa ufanisi na zana, hifadhidata, APIs, na rasilimali za muktadha. Hebu tugawanye usanifu huu katika vipengele vyake muhimu.

### 1. Hosts

Katika Model Context Protocol (MCP), Hosts ni sehemu muhimu kama kiolesura kikuu ambacho watumiaji hutumia kuingiliana na itifaki. Hosts ni programu au mazingira yanayoanzisha muunganisho na seva za MCP ili kupata data, zana, na maelekezo. Mfano wa Hosts ni mazingira ya maendeleo kama Visual Studio Code, zana za AI kama Claude Desktop, au mawakala waliotengenezwa maalum kwa kazi fulani.

**Hosts** ni programu za LLM zinazozindua muunganisho. Wanap:

- Kutekeleza au kuingiliana na modeli za AI ili kutoa majibu.
- Kuanzisha muunganisho na seva za MCP.
- Kusimamia mtiririko wa mazungumzo na kiolesura cha mtumiaji.
- Kudhibiti ruhusa na vizingiti vya usalama.
- Kushughulikia idhini ya mtumiaji kwa kushiriki data na kutekeleza zana.

### 2. Clients

Clients ni vipengele muhimu vinavyorahisisha mwingiliano kati ya Hosts na seva za MCP. Clients hufanya kama madalali, kuruhusu Hosts kufikia na kutumia kazi zinazotolewa na seva za MCP. Wanahakikisha mawasiliano laini na kubadilishana data kwa ufanisi ndani ya usanifu wa MCP.

**Clients** ni viunganishi ndani ya programu ya host. Wanap:

- Kutuma maombi kwa seva kwa maelekezo/maagizo.
- Kujadiliana kuhusu uwezo na seva.
- Kusimamia maombi ya utekelezaji wa zana kutoka kwa modeli.
- Kuchakata na kuonyesha majibu kwa watumiaji.

### 3. Servers

Servers zinahusika na kushughulikia maombi kutoka kwa clients wa MCP na kutoa majibu yanayofaa. Zinadhibiti shughuli mbalimbali kama upokeaji data, utekelezaji wa zana, na uundaji wa maelekezo. Servers huhakikisha mawasiliano kati ya clients na Hosts ni ya ufanisi na ya kuaminika, huku zikidumisha uadilifu wa mchakato wa mwingiliano.

**Servers** ni huduma zinazotoa muktadha na uwezo. Wanap:

- Kusajili vipengele vinavyopatikana (rasilimali, maelekezo, zana)
- Kupokea na kutekeleza maombi ya zana kutoka kwa client
- Kutoa taarifa za muktadha ili kuboresha majibu ya modeli
- Kurudisha matokeo kwa client
- Kudumisha hali katika mwingiliano inapohitajika

Servers zinaweza kutengenezwa na mtu yeyote kuongeza uwezo wa modeli kwa kazi maalum.

### 4. Vipengele vya Server

Servers katika Model Context Protocol (MCP) hutoa vipengele msingi vinavyowezesha mwingiliano tajiri kati ya clients, hosts, na modeli za lugha. Vipengele hivi vimeundwa kuongeza uwezo wa MCP kwa kutoa muktadha uliopangwa, zana, na maelekezo.

Seva za MCP zinaweza kutoa vipengele vifuatavyo:

#### 📑 Rasilimali

Rasilimali katika Model Context Protocol (MCP) ni aina mbalimbali za muktadha na data zinazoweza kutumiwa na watumiaji au modeli za AI. Hizi ni pamoja na:

- **Data za Muktadha**: Taarifa na muktadha ambao watumiaji au modeli za AI wanaweza kutumia kwa maamuzi na utekelezaji wa kazi.
- **Misingi ya Maarifa na Hifadhidata za Nyaraka**: Mkusanyiko wa data zilizopangwa na zisizopangwa, kama makala, mwongozo, na tafiti, zinazotoa maarifa na taarifa muhimu.
- **Faili za Kiwanda na Hifadhidata**: Data zilizohifadhiwa ndani ya vifaa au hifadhidata, zinazopatikana kwa uchakataji na uchambuzi.
- **APIs na Huduma za Mtandao**: Kiolesura na huduma za nje zinazotoa data na uwezo zaidi, kuruhusu ushirikiano na rasilimali na zana mbalimbali mtandaoni.

Mfano wa rasilimali unaweza kuwa muundo wa hifadhidata au faili inayopatikana kwa njia hii:

```text
file://log.txt
database://schema
```

### 🤖 Maelekezo

Maelekezo katika Model Context Protocol (MCP) ni templeti na mifumo ya mwingiliano iliyotanguliwa iliyoundwa kuwezesha mtiririko wa kazi kwa watumiaji na kuboresha mawasiliano. Hizi ni pamoja na:

- **Ujumbe na Mtiririko wa Kazi uliopangwa**: Ujumbe na michakato iliyopangwa ambayo huongoza watumiaji kupitia kazi maalum na mwingiliano.
- **Mifumo ya Mwingiliano Iliyotanguliwa**: Mfululizo wa hatua na majibu yaliyopangwa ili kuwezesha mawasiliano thabiti na yenye ufanisi.
- **Templeti Maalum za Mazungumzo**: Templeti zinazoweza kubadilishwa kwa aina maalum za mazungumzo, kuhakikisha mwingiliano unaofaa na wenye muktadha.

Templeti ya maelekezo inaweza kuonekana kama ifuatavyo:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Zana

Zana katika Model Context Protocol (MCP) ni kazi ambazo modeli ya AI inaweza kutekeleza kufanya kazi maalum. Zana hizi zimetengenezwa kuongeza uwezo wa modeli kwa kutoa operesheni zilizopangwa na za kuaminika. Vipengele muhimu ni:

- **Kazi za Kutekelezwa na Modeli ya AI**: Zana ni kazi zinazotekelezwa ambazo modeli ya AI inaweza kuitumia kutekeleza kazi mbalimbali.
- **Jina la Kipekee na Maelezo**: Kila zana ina jina la kipekee na maelezo ya kina yanayoelezea kusudi na kazi zake.
- **Vigezo na Matokeo**: Zana zinapokea vigezo maalum na kurudisha matokeo yaliyopangwa, kuhakikisha matokeo thabiti na yanayotarajiwa.
- **Kazi Zilizojitenga**: Zana hufanya kazi maalum kama utafutaji mtandaoni, mahesabu, na maswali ya hifadhidata.

Mfano wa zana unaweza kuonekana kama ifuatavyo:

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

## Vipengele vya Client

Katika Model Context Protocol (MCP), clients hutoa vipengele muhimu kwa seva, vinavyoongeza utendaji na mwingiliano ndani ya itifaki. Mojawapo ya vipengele maarufu ni Sampling.

### 👉 Sampling

- **Tabia za Wakala Zinazoanzishwa na Seva**: Clients huruhusu seva kuanzisha vitendo au tabia fulani kwa uhuru, kuongeza uwezo wa mfumo.
- **Mwingiliano wa Kurudia na LLM**: Kipengele hiki huruhusu mwingiliano wa kurudia na modeli kubwa za lugha (LLMs), kuwezesha usindikaji mgumu na wa hatua kwa hatua wa kazi.
- **Kuomba Makamilisho Zaidi ya Modeli**: Seva zinaweza kuomba makamilisho ya ziada kutoka kwa modeli, kuhakikisha majibu ni kamili na yanayolingana na muktadha.

## Mtiririko wa Taarifa katika MCP

Model Context Protocol (MCP) huainisha mtiririko uliopangwa wa taarifa kati ya hosts, clients, servers, na modeli. Kuelewa mtiririko huu kunasaidia kufafanua jinsi maombi ya mtumiaji yanavyosindikwa na jinsi zana za nje na data zinavyojumuishwa katika majibu ya modeli.

- **Host Huanzisha Muunganisho**  
  Programu ya host (kama IDE au kiolesura cha mazungumzo) huanzisha muunganisho na seva ya MCP, kawaida kupitia STDIO, WebSocket, au usafirishaji mwingine unaoungwa mkono.

- **Mazungumzo ya Uwezo**  
  Client (iliyomo ndani ya host) na seva hubadilishana taarifa kuhusu vipengele, zana, rasilimali, na toleo la itifaki wanazounga mkono. Hii huhakikisha pande zote zinaelewa uwezo uliopo kwa kikao.

- **Ombi la Mtumiaji**  
  Mtumiaji huingiliana na host (mfano, kuingiza maelekezo au amri). Host hukusanya ingizo hili na kupeleka kwa client kwa usindikaji.

- **Matumizi ya Rasilimali au Zana**  
  - Client inaweza kuomba muktadha au rasilimali zaidi kutoka kwa seva (kama faili, rekodi za hifadhidata, au makala za misingi ya maarifa) ili kuongeza ufahamu wa modeli.
  - Ikiwa modeli inaamua zana inahitajika (mfano, kupata data, kufanya mahesabu, au kuita API), client hutuma ombi la kuitisha zana kwa seva, ikibainisha jina la zana na vigezo.

- **Utekelezaji wa Seva**  
  Seva hupokea ombi la rasilimali au zana, hutekeleza shughuli zinazohitajika (kama kuendesha kazi, kuuliza hifadhidata, au kupata faili), na kurudisha matokeo kwa client kwa muundo uliopangwa.

- **Uundaji wa Majibu**  
  Client huunganisha majibu ya seva (data za rasilimali, matokeo ya zana, nk) katika mwingiliano unaoendelea wa modeli. Modeli hutumia taarifa hii kutoa jibu kamili na linalolingana na muktadha.

- **Uwasilishaji wa Matokeo**  
  Host hupokea matokeo ya mwisho kutoka kwa client na kuyaonyesha kwa mtumiaji, mara nyingi ikiwa ni pamoja na maandishi yaliyotengenezwa na modeli pamoja na matokeo yoyote ya utekelezaji wa zana au utafutaji wa rasilimali.

Mtiririko huu unaruhusu MCP kuunga mkono programu za AI zenye mwingiliano wa hali ya juu, zenye ufahamu wa muktadha kwa kuunganisha modeli na zana za nje na vyanzo vya data kwa urahisi.

## Maelezo ya Itifaki

MCP (Model Context Protocol) imejengwa juu ya [JSON-RPC 2.0](https://www.jsonrpc.org/), ikitoa muundo wa ujumbe uliopangwa, usioegemea lugha, kwa mawasiliano kati ya hosts, clients, na servers. Msingi huu unaruhusu mwingiliano thabiti, uliopangwa, na unaoweza kupanuliwa kati ya majukwaa na lugha za programu mbalimbali.

### Vipengele Muhimu vya Itifaki

MCP inaongeza JSON-RPC 2.0 kwa mila za ziada za kuitisha zana, kupata rasilimali, na usimamizi wa maelekezo. Inasaidia tabaka mbalimbali za usafirishaji (STDIO, WebSocket, SSE) na kuwezesha mawasiliano salama, yanayoweza kupanuliwa, na yasiyoegemea lugha kati ya vipengele.

#### 🧢 Itifaki ya Msingi

- **Muundo wa Ujumbe wa JSON-RPC**: Maombi na majibu yote hutumia vipimo vya JSON-RPC 2.0, kuhakikisha muundo thabiti kwa miito ya mbinu, vigezo, matokeo, na usimamizi wa makosa.
- **Muunganisho wenye Hali**: Vikao vya MCP hudumisha hali kati ya maombi mengi, kuunga mkono mazungumzo yanayoendelea, mkusanyiko wa muktadha, na usimamizi wa rasilimali.
- **Mazungumzo ya Uwezo**: Wakati wa kuanzisha muunganisho, clients na servers hubadilishana taarifa kuhusu vipengele vinavyounga mkono, matoleo ya itifaki, zana, na rasilimali zinazopatikana. Hii huhakikisha pande zote zinaelewa uwezo wa mwenzake na zinaweza kubadilika ipasavyo.

#### ➕ Zana Zaidi

Hapa chini ni zana na nyongeza za itifaki ambazo MCP hutoa ili kuboresha uzoefu wa msanidi na kuwezesha hali za juu:

- **Chaguzi za Usanidi**: MCP huruhusu usanidi wa mabadiliko ya vigezo vya kikao, kama ruhusa za zana, upatikanaji wa rasilimali, na mipangilio ya modeli, iliyobinafsishwa kwa kila mwingiliano.
- **Ufuatiliaji wa Maendeleo**: Shughuli za muda mrefu zinaweza kutoa taarifa za maendeleo, kuwezesha kiolesura cha mtumiaji chenye mwitikio na uzoefu bora wakati wa kazi ngumu.
- **Kufuta Maombi**: Clients wanaweza kufuta maombi yanayoendelea, kuruhusu watumiaji kusitisha shughuli zisizohitajika au zinazochukua muda mrefu.
- **Ripoti za Makosa**: Ujumbe wa makosa uliopangwa na nambari husaidia kutambua matatizo, kushughulikia kushindwa kwa hila, na kutoa mrejesho unaoweza kutekelezeka kwa watumiaji na wasanidi.
- **Kulogiwa**: Clients na servers wote wanaweza kutoa logi zilizoandaliwa kwa ajili ya ukaguzi, utatuzi, na ufuatiliaji wa mwingiliano wa itifaki.

Kwa kutumia vipengele hivi vya itifaki, MCP huhakikisha mawasiliano imara, salama, na yenye kubadilika kati ya modeli za lugha na zana au vyanzo vya data vya nje.

### 🔐 Mambo ya Usalama

Utekelezaji wa MCP unapaswa kufuata kanuni muhimu za usalama ili kuhakikisha mwingiliano salama na wa kuaminika:

- **Idhini na Udhibiti wa Mtumiaji**: Watumiaji lazima watoe idhini wazi kabla data yoyote kupatikana au shughuli kutekelezwa. Wanapaswa kuwa na udhibiti wa wazi juu ya data inayoshirikiwa na vitendo vinavyoruhusiwa, kwa msaada wa kiolesura rahisi cha mtumiaji cha kukagua na kuidhinisha shughuli.
- **Faragha ya Data**: Data za watumiaji zinapaswa kuonyeshwa tu kwa idhini wazi na kulindwa kwa udhibiti mzuri wa upatikanaji. Utekelezaji wa MCP lazima ulinde dhidi ya usambazaji usioidhinishwa wa data na kuhakikisha faragha inahifadhiwa katika mwingiliano wote.
- **Usalama wa Zana**: Kabla ya kuitisha zana yoyote, idhini wazi ya mtumiaji inahitajika. Watumiaji wanapaswa kuelewa wazi kazi za kila zana, na mipaka thabiti ya usalama lazima itekelezwe kuzuia utekelezaji usiofaa au hatari wa zana.

Kwa kufuata kanuni hizi, MCP huhakikisha kuwa imani, faragha, na usalama wa mtumiaji vinahifadhiwa katika mwingiliano yote ya itifaki.

## Mifano ya Msimbo: Vipengele Muhimu

Hapa chini ni mifano ya msimbo katika lugha maarufu mbalimbali inayoonyesha jinsi ya kutekeleza vipengele muhimu vya seva ya MCP na zana.

### Mfano wa .NET: Kuunda Seva Rahisi ya MCP yenye Zana

Huu ni mfano wa vitendo wa .NET unaoonyesha jinsi ya kutekeleza seva rahisi ya MCP yenye zana za kawaida. Mfano huu unaonyesha jinsi ya kufafanua na kusajili zana, kushughulikia maombi, na kuunganisha seva kwa kutumia Model Context Protocol.

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

Mfano huu unaonyesha seva na usajili wa zana kama ilivyo kwenye mfano wa .NET hapo juu, lakini umeandikwa kwa Java.

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

# Initialize class for its methods to be registered as tools
weather_tools = WeatherTools()

if __name__ == "__main__":
    # Start the server with stdio transport
    print("Weather MCP Server starting...")
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

Mfano huu wa JavaScript unaonyesha jinsi ya kuunda client ya MCP inayounganisha na seva, kutuma maelekezo, na kushughulikia majibu pamoja na maombi yoyote ya zana yaliyotolewa.

## Usalama na Idhini

MCP inajumuisha dhana na mbinu kadhaa za kudhibiti usalama na idhini katika itifaki nzima:

1. **Udhibiti wa Ruhusa za Zana

**Kikoso cha lawama**:  
Hati hii imetafsiriwa kwa kutumia huduma ya utafsiri wa AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuhakikisha usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au kasoro. Hati asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha kuaminika. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inapendekezwa. Hatubebwi jukumu lolote kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.