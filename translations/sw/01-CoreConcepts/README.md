<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "154c00dc3b2c792102e4845c19fbd166",
  "translation_date": "2025-05-20T17:55:43+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "sw"
}
-->
# 📖 MCP Core Concepts: Ujifunzaji wa Model Context Protocol kwa Muungano wa AI

Model Context Protocol (MCP) ni mfumo wenye nguvu na uliopangwa viwango unaoboreshwa mawasiliano kati ya Large Language Models (LLMs) na zana za nje, programu, na vyanzo vya data. Mwongozo huu ulioboreshwa kwa SEO utakufundisha dhana kuu za MCP, kuhakikisha unaelewa usanifu wa client-server, vipengele muhimu, mbinu za mawasiliano, na mbinu bora za utekelezaji.

## Muhtasari

Somo hili linaangazia usanifu wa msingi na vipengele vinavyounda mfumo wa Model Context Protocol (MCP). Utajifunza kuhusu usanifu wa client-server, vipengele muhimu, na mbinu za mawasiliano zinazochochea mwingiliano wa MCP.

## 👩‍🎓 Malengo Muhimu ya Kujifunza

Mwisho wa somo hili, utakuwa umeweza:

- Kuelewa usanifu wa MCP wa client-server.
- Kutambua majukumu ya Hosts, Clients, na Servers.
- Kuchambua sifa kuu zinazofanya MCP kuwa safu rahisi ya muungano.
- Kujifunza jinsi taarifa zinavyosambaa ndani ya mfumo wa MCP.
- Kupata maarifa ya vitendo kupitia mifano ya msimbo katika .NET, Java, Python, na JavaScript.

## 🔎 Usanifu wa MCP: Muangalia Zaidi

Mfumo wa MCP umejengwa kwa mfano wa client-server. Muundo huu wa moduli unaruhusu programu za AI kuingiliana na zana, hifadhidata, APIs, na rasilimali za muktadha kwa ufanisi. Hebu tuchambue usanifu huu kwa vipengele vyake muhimu.

### 1. Hosts

Katika Model Context Protocol (MCP), Hosts ni sehemu muhimu kama kiolesura cha msingi ambacho watumiaji hutumia kuingiliana na itifaki. Hosts ni programu au mazingira yanayoanzisha muunganisho na seva za MCP ili kupata data, zana, na maagizo. Mifano ya Hosts ni pamoja na mazingira ya maendeleo yaliyojumuishwa (IDEs) kama Visual Studio Code, zana za AI kama Claude Desktop, au mawakala maalum yaliyojengwa kwa kazi fulani.

**Hosts** ni programu za LLM zinazozindua muunganisho. Wanahakikisha:

- Kutekeleza au kuingiliana na mifano ya AI ili kutoa majibu.
- Kuanzisha muunganisho na seva za MCP.
- Kusimamia mtiririko wa mazungumzo na kiolesura cha mtumiaji.
- Kudhibiti ruhusa na vizingiti vya usalama.
- Kushughulikia ridhaa za mtumiaji kwa kushiriki data na kutekeleza zana.

### 2. Clients

Clients ni vipengele muhimu vinavyorahisisha mwingiliano kati ya Hosts na seva za MCP. Clients hufanya kazi kama wasuluhishi, kuruhusu Hosts kufikia na kutumia huduma zinazotolewa na seva za MCP. Wanachukua jukumu muhimu kuhakikisha mawasiliano laini na kubadilishana data kwa ufanisi ndani ya usanifu wa MCP.

**Clients** ni viunganishi ndani ya programu ya host. Wanahakikisha:

- Kutuma maombi kwa seva kwa maagizo/maelekezo.
- Kujadiliana uwezo na seva.
- Kusimamia maombi ya utekelezaji wa zana kutoka kwa mifano.
- Kuchakata na kuonyesha majibu kwa watumiaji.

### 3. Servers

Seva zinahusika na kushughulikia maombi kutoka kwa clients wa MCP na kutoa majibu yanayofaa. Zinadhibiti shughuli mbalimbali kama upokeaji wa data, utekelezaji wa zana, na utengenezaji wa maagizo. Seva zinahakikisha mawasiliano kati ya clients na Hosts ni ya ufanisi na ya kuaminika, zikidumisha uadilifu wa mchakato wa mwingiliano.

**Servers** ni huduma zinazotoa muktadha na uwezo. Wanahakikisha:

- Kusajili vipengele vinavyopatikana (rasilimali, maagizo, zana)
- Kupokea na kutekeleza maombi ya zana kutoka kwa client
- Kutoa taarifa za muktadha ili kuboresha majibu ya modeli
- Kurudisha matokeo kwa client
- Kudumisha hali katika mwingiliano inapohitajika

Seva zinaweza kuundwa na mtu yeyote kuongeza uwezo wa modeli kwa huduma maalum.

### 4. Vipengele vya Server

Seva katika Model Context Protocol (MCP) hutoa vipengele vya msingi vinavyowezesha mwingiliano tajiri kati ya clients, hosts, na modeli za lugha. Vipengele hivi vimeundwa kuongeza uwezo wa MCP kwa kutoa muktadha uliopangwa, zana, na maagizo.

Seva za MCP zinaweza kutoa vipengele vifuatavyo:

#### 📑 Rasilimali

Rasilimali katika Model Context Protocol (MCP) ni aina mbalimbali za muktadha na data zinazoweza kutumiwa na watumiaji au mifano ya AI. Hizi ni pamoja na:

- **Data za Muktadha**: Taarifa na muktadha ambao watumiaji au mifano ya AI wanaweza kutumia kwa maamuzi na utekelezaji wa kazi.
- **Misingi ya Maarifa na Hifadhidata za Nyaraka**: Mkusanyiko wa data zilizopangwa na zisizopangwa, kama makala, mwongozo, na karatasi za utafiti, zinazotoa maarifa muhimu.
- **Faili za Kiasili na Hifadhidata**: Data iliyohifadhiwa ndani ya vifaa au hifadhidata, inayopatikana kwa uchakataji na uchambuzi.
- **APIs na Huduma za Mtandao**: Kiolesura na huduma za nje zinazotoa data na uwezo zaidi, kuruhusu muunganisho na rasilimali na zana mbalimbali mtandaoni.

Mfano wa rasilimali inaweza kuwa schema ya hifadhidata au faili inayoweza kufikiwa kama ifuatavyo:

```text
file://log.txt
database://schema
```

### 🤖 Maagizo

Maagizo katika Model Context Protocol (MCP) ni templeti mbalimbali zilizotanguliwa na mifumo ya mwingiliano iliyoundwa kurahisisha mtiririko wa kazi za watumiaji na kuboresha mawasiliano. Hizi ni pamoja na:

- **Ujumbe wa Templeti na Mtiririko wa Kazi**: Ujumbe na michakato iliyopangwa kabla inayowaongoza watumiaji kupitia kazi maalum na mwingiliano.
- **Mifumo ya Mwingiliano Iliyo Tanguliwa**: Mfuatano wa hatua na majibu yaliyopangwa kwa lengo la mawasiliano thabiti na yenye ufanisi.
- **Templeti Maalum za Mazungumzo**: Templeti zinazoweza kubadilishwa kwa aina maalum za mazungumzo, kuhakikisha mwingiliano unaofaa na wenye muktadha.

Templeti ya agizo inaweza kuonekana kama ifuatavyo:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Zana

Zana katika Model Context Protocol (MCP) ni kazi ambazo modeli ya AI inaweza kutekeleza kufanya kazi maalum. Zana hizi zimeundwa kuongeza uwezo wa modeli ya AI kwa kutoa operesheni zilizopangwa na za kuaminika. Vipengele muhimu ni:

- **Kazi za AI kutekeleza**: Zana ni kazi zinazoweza kutekelezwa ambazo modeli ya AI inaweza kuitumia kutekeleza kazi mbalimbali.
- **Jina la Kipekee na Maelezo**: Kila zana ina jina la kipekee na maelezo ya kina yanayoelezea madhumuni na utendaji wake.
- **Vigezo na Matokeo**: Zana zinakubali vigezo maalum na kurudisha matokeo yaliyopangwa, kuhakikisha matokeo thabiti na yanayotarajiwa.
- **Kazi Zilizojitenga**: Zana hufanya kazi maalum kama utafutaji wa mtandao, mahesabu, na maswali ya hifadhidata.

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

## Vipengele vya Client

Katika Model Context Protocol (MCP), clients hutoa vipengele kadhaa muhimu kwa seva, vinavyoongeza utendaji wa jumla na mwingiliano ndani ya itifaki. Moja ya vipengele vinavyoonekana ni Sampling.

### 👉 Sampling

- **Tabia za Wakala Zilizozinduliwa na Seva**: Clients huruhusu seva kuanzisha hatua maalum au tabia kwa kujitegemea, kuongeza uwezo wa mfumo kwa mabadiliko ya hali.
- **Mwingiliano Rudufu wa LLM**: Kipengele hiki huruhusu mwingiliano wa rudufu na mifano mikubwa ya lugha (LLMs), kuwezesha usindikaji wa kazi ngumu na wa mara kwa mara.
- **Kutoa Maombi ya Ukamilisho Zaidi wa Modeli**: Seva zinaweza kuomba ukamilisho zaidi kutoka kwa modeli, kuhakikisha majibu ni kamili na yanayohusiana na muktadha.

## Mtiririko wa Taarifa katika MCP

Model Context Protocol (MCP) inaelezea mtiririko uliopangwa wa taarifa kati ya hosts, clients, servers, na modeli. Kuelewa mtiririko huu kunasaidia kufafanua jinsi maombi ya mtumiaji yanavyosindikwa na jinsi zana za nje na data zinavyoingizwa katika majibu ya modeli.

- **Host Huanzisha Muunganisho**  
  Programu ya host (kama IDE au kiolesura cha mazungumzo) huanzisha muunganisho na seva ya MCP, kawaida kupitia STDIO, WebSocket, au usafirishaji mwingine unaoungwa mkono.

- **Majadiliano ya Uwezo**  
  Client (iliyowekwa ndani ya host) na seva hubadilishana taarifa kuhusu vipengele wanavyounga mkono, zana, rasilimali, na matoleo ya itifaki. Hii inahakikisha pande zote zinaelewa uwezo uliopo kwa kikao.

- **Ombi la Mtumiaji**  
  Mtumiaji huingiliana na host (mfano, kuingiza agizo au amri). Host hukusanya maingizo haya na kuyapeleka kwa client kwa usindikaji.

- **Matumizi ya Rasilimali au Zana**  
  - Client inaweza kuomba muktadha zaidi au rasilimali kutoka kwa seva (kama faili, rekodi za hifadhidata, au makala za misingi ya maarifa) ili kuongeza uelewa wa modeli.
  - Ikiwa modeli inaamua zana ni muhimu (mfano, kupata data, kufanya mahesabu, au kuita API), client hutuma ombi la kuitisha zana kwa seva, ikieleza jina la zana na vigezo.

- **Utekelezaji wa Seva**  
  Seva hupokea ombi la rasilimali au zana, hufanya operesheni zinazohitajika (kama kuendesha kazi, kuuliza hifadhidata, au kupata faili), na kurudisha matokeo kwa client kwa muundo uliopangwa.

- **Uundaji wa Majibu**  
  Client huunganisha majibu ya seva (data za rasilimali, matokeo ya zana, nk) katika mwingiliano unaoendelea wa modeli. Modeli hutumia taarifa hii kutoa jibu kamili na linalofaa kimaudhui.

- **Uwasilishaji wa Matokeo**  
  Host hupokea matokeo ya mwisho kutoka kwa client na kuyaonyesha kwa mtumiaji, mara nyingi ikiwa ni pamoja na maandishi yaliyotengenezwa na modeli na matokeo yoyote ya utekelezaji wa zana au upataji wa rasilimali.

Mtiririko huu unaruhusu MCP kuunga mkono programu za AI zenye mwingiliano wa hali ya juu, zinazojua muktadha kwa kuunganisha modeli na zana za nje na vyanzo vya data kwa urahisi.

## Maelezo ya Itifaki

MCP (Model Context Protocol) imejengwa juu ya [JSON-RPC 2.0](https://www.jsonrpc.org/), ikitoa muundo wa ujumbe uliowekwa viwango, usioegemea lugha kwa mawasiliano kati ya hosts, clients, na servers. Msingi huu unaruhusu mwingiliano thabiti, uliopangwa, na unaoweza kupanuliwa kati ya majukwaa na lugha mbalimbali za programu.

### Vipengele Muhimu vya Itifaki

MCP inaongeza JSON-RPC 2.0 kwa mila za ziada za kuitisha zana, upatikanaji wa rasilimali, na usimamizi wa maagizo. Inasaidia tabaka mbalimbali za usafirishaji (STDIO, WebSocket, SSE) na kuwezesha mawasiliano salama, yanayoweza kupanuliwa, na yasiyoegemea lugha kati ya vipengele.

#### 🧢 Itifaki ya Msingi

- **Muundo wa Ujumbe wa JSON-RPC**: Maombi na majibu yote hutumia sifa ya JSON-RPC 2.0, kuhakikisha muundo thabiti kwa wito wa njia, vigezo, matokeo, na usimamizi wa makosa.
- **Muunganisho wenye Hali**: Vikao vya MCP hudumisha hali kati ya maombi mengi, kuunga mkono mazungumzo yanayoendelea, mkusanyiko wa muktadha, na usimamizi wa rasilimali.
- **Majadiliano ya Uwezo**: Wakati wa kuanzisha muunganisho, clients na servers hubadilishana taarifa kuhusu vipengele vinavyoungwa mkono, matoleo ya itifaki, zana na rasilimali zilizopo. Hii inahakikisha pande zote zinaelewa uwezo wa mwenzake na zinaweza kuendana.

#### ➕ Zana Zaidi

Hapa chini ni zana za ziada na nyongeza za itifaki MCP hutoa ili kuboresha uzoefu wa msanidi na kuwezesha hali za juu:

- **Chaguzi za Usanidi**: MCP inaruhusu usanidi wa mabadiliko ya vigezo vya kikao, kama ruhusa za zana, upatikanaji wa rasilimali, na mipangilio ya modeli, iliyobinafsishwa kwa kila mwingiliano.
- **Ufuatiliaji wa Maendeleo**: Operesheni za muda mrefu zinaweza kutoa taarifa za maendeleo, kuruhusu violesura vya mtumiaji kuwa na majibu na uzoefu bora wakati wa kazi ngumu.
- **Kughairi Maombi**: Clients wanaweza kughairi maombi yanayoendelea, kuruhusu watumiaji kusitisha operesheni ambazo hazihitajiki tena au zinachukua muda mrefu.
- **Ripoti za Makosa**: Ujumbe na nambari za makosa zilizoainishwa husaidia kutambua matatizo, kushughulikia kushindwa kwa heshima, na kutoa mrejesho unaoweza kutekelezeka kwa watumiaji na wasanidi.
- **Kulogiwa**: Clients na servers wanaweza kutoa logi zilizo pangwa kwa ajili ya ukaguzi, utatuzi, na ufuatiliaji wa mwingiliano wa itifaki.

Kwa kutumia vipengele hivi vya itifaki, MCP inahakikisha mawasiliano thabiti, salama, na yenye ufanisi kati ya modeli za lugha na zana za nje au vyanzo vya data.

### 🔐 Mambo ya Usalama

Utekelezaji wa MCP unapaswa kufuata kanuni kuu za usalama kuhakikisha mwingiliano salama na wa kuaminika:

- **Ridhaa na Udhibiti wa Mtumiaji**: Watumiaji wanapaswa kutoa ridhaa wazi kabla ya kufikia data yoyote au kutekeleza operesheni. Wanapaswa kuwa na udhibiti wazi juu ya data inayoshirikiwa na hatua zinazoruhusiwa, zikiwa na violesura vya mtumiaji vinavyorahisisha ukaguzi na idhini ya shughuli.
- **Faragha ya Data**: Data za watumiaji zinapaswa kuonyeshwa tu kwa ridhaa wazi na kulindwa kwa udhibiti wa upatikanaji unaofaa. Utekelezaji wa MCP lazima ulinde dhidi ya usafirishaji usioidhinishwa wa data na kuhakikisha faragha inadumishwa katika mwingiliano wote.
- **Usalama wa Zana**: Kabla ya kuitisha zana yoyote, ridhaa wazi ya mtumiaji inahitajika. Watumiaji wanapaswa kuelewa kwa uwazi kazi za kila zana, na mipaka imara ya usalama inapaswa kutekelezwa kuzuia utekelezaji usiohitajika au hatari wa zana.

Kwa kufuata kanuni hizi, MCP inahakikisha kuwa imani, faragha, na usalama wa mtumiaji vinadumishwa katika mwingiliano yote ya itifaki.

## Mifano ya Msimbo: Vipengele Muhimu

Hapa chini kuna mifano ya msimbo katika lugha maarufu za programu inayoonyesha jinsi ya kutekeleza vipengele muhimu vya seva za MCP na zana.

### Mfano wa .NET: Kuunda Seva Rahisi ya MCP na Zana

Huu ni mfano wa msimbo wa .NET unaoonyesha jinsi ya kutekeleza seva rahisi ya MCP yenye zana maalum. Mfano huu unaonyesha jinsi ya kufafanua na kusajili zana, kushughulikia maombi, na kuunganisha seva kwa kutumia Model Context Protocol.

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

Mfano huu unaonyesha seva ile ile ya MCP na usajili wa zana kama ilivyo katika mfano wa .NET hapo juu, lakini umeandikwa kwa Java.

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

Mfano huu wa JavaScript unaonyesha jinsi ya kuunda client ya MCP inayounganisha na seva, kutuma agizo, na kushughulikia majibu ikiwa ni pamoja na wito wowote wa zana uliofanywa.

## Usalama na Uidhinishaji

MCP

**Kiasi cha majibu**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuhakikisha usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au kasoro. Hati asili katika lugha yake ya asili inapaswa kuzingatiwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu na ya binadamu inapendekezwa. Hatuna dhamana kwa maelewano mabaya au tafsiri zisizo sahihi zinazotokana na matumizi ya tafsiri hii.