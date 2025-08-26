<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "88b863a69b4f18b15e82da358ffd3489",
  "translation_date": "2025-08-26T18:39:04+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "lt"
}
-->
# MCP Pagrindinės Sąvokos: Model Context Protocol įvaldymas AI integracijai

[![MCP Pagrindinės Sąvokos](../../../translated_images/02.8203e26c6fb5a797f38a10012061013ec66c95bb3260f6c9cfd2bf74b00860e1.lt.png)](https://youtu.be/earDzWGtE84)

_(Spustelėkite aukščiau esančią nuotrauką, kad peržiūrėtumėte šios pamokos vaizdo įrašą)_

[Model Context Protocol (MCP)](https://github.com/modelcontextprotocol) yra galingas, standartizuotas pagrindas, optimizuojantis komunikaciją tarp didelių kalbos modelių (LLM) ir išorinių įrankių, programų bei duomenų šaltinių. Šis vadovas supažindins jus su pagrindinėmis MCP sąvokomis. Sužinosite apie jo klient-serverio architektūrą, esminius komponentus, komunikacijos mechaniką ir geriausias įgyvendinimo praktikas.

- **Aiškus vartotojo sutikimas**: Visiems duomenų prieigos ir operacijų veiksmams būtinas aiškus vartotojo patvirtinimas prieš vykdymą. Vartotojai turi aiškiai suprasti, kokie duomenys bus pasiekiami ir kokie veiksmai bus atliekami, turėdami detalią kontrolę dėl leidimų ir autorizacijų.

- **Duomenų privatumo apsauga**: Vartotojo duomenys atskleidžiami tik gavus aiškų sutikimą ir turi būti apsaugoti stipriomis prieigos kontrolėmis per visą sąveikos ciklą. Įgyvendinimas turi užkirsti kelią neautorizuotam duomenų perdavimui ir išlaikyti griežtas privatumo ribas.

- **Įrankių vykdymo saugumas**: Kiekvienam įrankio iškvietimui būtinas aiškus vartotojo sutikimas, suprantant įrankio funkcionalumą, parametrus ir galimą poveikį. Turi būti užtikrintos tvirtos saugumo ribos, kad būtų išvengta netyčinio, nesaugaus ar kenkėjiško įrankių vykdymo.

- **Transporto sluoksnio saugumas**: Visos komunikacijos turi naudoti tinkamus šifravimo ir autentifikavimo mechanizmus. Nuotoliniai ryšiai turi įgyvendinti saugius transporto protokolus ir tinkamą kredencialų valdymą.

#### Įgyvendinimo gairės:

- **Leidimų valdymas**: Įgyvendinkite detalius leidimų sistemas, leidžiančias vartotojams kontroliuoti, kurie serveriai, įrankiai ir resursai yra pasiekiami.
- **Autentifikacija ir autorizacija**: Naudokite saugius autentifikacijos metodus (OAuth, API raktus) su tinkamu žetonų valdymu ir galiojimo pabaiga.  
- **Įvesties validacija**: Patikrinkite visus parametrus ir duomenų įvestis pagal apibrėžtas schemas, kad išvengtumėte injekcijos atakų.
- **Audito žurnalai**: Palaikykite išsamius visų operacijų žurnalus saugumo stebėjimui ir atitikties užtikrinimui.

## Apžvalga

Šioje pamokoje nagrinėjama pagrindinė architektūra ir komponentai, sudarantys Model Context Protocol (MCP) ekosistemą. Sužinosite apie klient-serverio architektūrą, pagrindinius komponentus ir komunikacijos mechanizmus, kurie palaiko MCP sąveikas.

## Pagrindiniai mokymosi tikslai

Šios pamokos pabaigoje jūs:

- Suprasite MCP klient-serverio architektūrą.
- Atpažinsite Host, Client ir Server vaidmenis bei atsakomybes.
- Analizuosite pagrindines MCP savybes, kurios daro jį lanksčiu integracijos sluoksniu.
- Suprasite, kaip informacija teka MCP ekosistemoje.
- Įgysite praktinių įžvalgų per kodo pavyzdžius .NET, Java, Python ir JavaScript kalbomis.

## MCP Architektūra: Išsamesnis žvilgsnis

MCP ekosistema yra sukurta remiantis klient-serverio modeliu. Ši modulinė struktūra leidžia AI programoms efektyviai sąveikauti su įrankiais, duomenų bazėmis, API ir kontekstiniais resursais. Išskaidykime šią architektūrą į pagrindinius komponentus.

MCP esmė yra klient-serverio architektūra, kurioje pagrindinė programa gali prisijungti prie kelių serverių:

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

- **MCP Hostai**: Programos, tokios kaip VSCode, Claude Desktop, IDE ar AI įrankiai, norintys pasiekti duomenis per MCP.
- **MCP Klientai**: Protokolo klientai, palaikantys 1:1 ryšius su serveriais.
- **MCP Serveriai**: Lengvos programos, kurios per standartizuotą Model Context Protocol atskleidžia specifines galimybes.
- **Vietiniai duomenų šaltiniai**: Jūsų kompiuterio failai, duomenų bazės ir paslaugos, kurias MCP serveriai gali saugiai pasiekti.
- **Nuotolinės paslaugos**: Išorinės sistemos, pasiekiamos internetu, prie kurių MCP serveriai gali prisijungti per API.

MCP protokolas yra besivystantis standartas, naudojantis datos pagrindu versijavimą (YYYY-MM-DD formatas). Dabartinė protokolo versija yra **2025-06-18**. Naujausius atnaujinimus galite rasti [protokolo specifikacijoje](https://modelcontextprotocol.io/specification/2025-06-18/).

### 1. Hostai

Model Context Protocol (MCP) sistemoje **Hostai** yra AI programos, kurios veikia kaip pagrindinė sąsaja, per kurią vartotojai sąveikauja su protokolu. Hostai koordinuoja ir valdo ryšius su keliais MCP serveriais, sukurdami dedikuotus MCP klientus kiekvienam serverio ryšiui. Hostų pavyzdžiai:

- **AI Programos**: Claude Desktop, Visual Studio Code, Claude Code.
- **Kūrimo aplinkos**: IDE ir kodo redaktoriai su MCP integracija.  
- **Individualios programos**: Specialiai sukurtos AI agentai ir įrankiai.

**Hostai** yra programos, koordinuojančios AI modelių sąveikas. Jie:

- **Orkestruoja AI modelius**: Vykdo arba sąveikauja su LLM, kad generuotų atsakymus ir koordinuotų AI darbo eigas.
- **Valdo klientų ryšius**: Kuria ir palaiko vieną MCP klientą kiekvienam MCP serverio ryšiui.
- **Kontroliuoja vartotojo sąsają**: Tvarko pokalbių eigą, vartotojo sąveikas ir atsakymų pateikimą.  
- **Užtikrina saugumą**: Valdo leidimus, saugumo apribojimus ir autentifikaciją.
- **Tvarko vartotojo sutikimą**: Valdo vartotojo patvirtinimus dėl duomenų dalijimosi ir įrankių vykdymo.

### 2. Klientai

**Klientai** yra esminiai komponentai, palaikantys dedikuotus vienas su vienu ryšius tarp Hostų ir MCP serverių. Kiekvienas MCP klientas yra inicijuojamas Host'o, kad prisijungtų prie specifinio MCP serverio, užtikrinant organizuotus ir saugius komunikacijos kanalus. Keli klientai leidžia Hostams vienu metu prisijungti prie kelių serverių.

**Klientai** yra jungiamieji komponentai Host programoje. Jie:

- **Protokolo komunikacija**: Siunčia JSON-RPC 2.0 užklausas serveriams su užklausomis ir instrukcijomis.
- **Galimybių derinimas**: Derina palaikomas funkcijas ir protokolo versijas su serveriais inicijavimo metu.
- **Įrankių vykdymas**: Tvarko įrankių vykdymo užklausas iš modelių ir apdoroja atsakymus.
- **Realaus laiko atnaujinimai**: Tvarko pranešimus ir realaus laiko atnaujinimus iš serverių.
- **Atsakymų apdorojimas**: Apdoroja ir formatuoja serverių atsakymus vartotojui pateikti.

### 3. Serveriai

**Serveriai** yra programos, teikiančios kontekstą, įrankius ir galimybes MCP klientams. Jie gali veikti lokaliai (toje pačioje mašinoje kaip Hostas) arba nuotoliniu būdu (išorinėse platformose) ir yra atsakingi už klientų užklausų tvarkymą bei struktūruotų atsakymų pateikimą. Serveriai atskleidžia specifinį funkcionalumą per standartizuotą Model Context Protocol.

**Serveriai** yra paslaugos, teikiančios kontekstą ir galimybes. Jie:

- **Funkcijų registracija**: Registruoja ir atskleidžia galimus primityvus (resursus, užklausas, įrankius) klientams.
- **Užklausų apdorojimas**: Priima ir vykdo įrankių iškvietimus, resursų užklausas ir užklausų šablonus iš klientų.
- **Konteksto teikimas**: Pateikia kontekstinę informaciją ir duomenis, kad pagerintų modelio atsakymus.
- **Būsenos valdymas**: Palaiko sesijos būseną ir tvarko būsenos reikalaujančias sąveikas, kai to reikia.
- **Realaus laiko pranešimai**: Siunčia pranešimus apie galimybių pokyčius ir atnaujinimus prijungtiems klientams.

Serverius gali kurti bet kas, norintis išplėsti modelio galimybes specializuotu funkcionalumu, ir jie palaiko tiek lokalaus, tiek nuotolinio diegimo scenarijus.

### 4. Serverių primityvai

Serveriai Model Context Protocol (MCP) sistemoje teikia tris pagrindinius **primityvus**, kurie apibrėžia pagrindinius sąveikos elementus tarp klientų, hostų ir kalbos modelių. Šie primityvai nurodo kontekstinės informacijos ir veiksmų tipus, pasiekiamus per protokolą.

MCP serveriai gali atskleisti bet kokią šių trijų pagrindinių primityvų kombinaciją:

#### Resursai

**Resursai** yra duomenų šaltiniai, teikiantys kontekstinę informaciją AI programoms. Jie atspindi statinį arba dinaminį turinį, kuris gali pagerinti modelio supratimą ir sprendimų priėmimą:

- **Kontekstiniai duomenys**: Struktūruota informacija ir kontekstas AI modelio suvokimui.
- **Žinių bazės**: Dokumentų saugyklos, straipsniai, vadovai ir moksliniai darbai.
- **Vietiniai duomenų šaltiniai**: Failai, duomenų bazės ir vietinė sistemos informacija.  
- **Išoriniai duomenys**: API atsakymai, interneto paslaugos ir nuotolinės sistemos duomenys.
- **Dinaminis turinys**: Realaus laiko duomenys, atnaujinami pagal išorines sąlygas.

Resursai identifikuojami pagal URI ir palaiko atradimą per `resources/list` bei gavimą per `resources/read` metodus:

```text
file://documents/project-spec.md
database://production/users/schema
api://weather/current
```

#### Užklausos

**Užklausos** yra pakartotinai naudojami šablonai, padedantys struktūrizuoti sąveikas su kalbos modeliais. Jie teikia standartizuotus sąveikos modelius ir šabloninius darbo srautus:

- **Šabloninės sąveikos**: Iš anksto struktūrizuotos žinutės ir pokalbių pradžios.
- **Darbo srautų šablonai**: Standartizuotos sekos įprastoms užduotims ir sąveikoms.
- **Few-shot pavyzdžiai**: Pavyzdžiais pagrįsti šablonai modelio instrukcijoms.
- **Sisteminės užklausos**: Pagrindinės užklausos, apibrėžiančios modelio elgesį ir kontekstą.
- **Dinaminiai šablonai**: Parametruoti šablonai, prisitaikantys prie specifinių kontekstų.

Užklausos palaiko kintamųjų pakeitimą ir gali būti atrandamos per `prompts/list` bei gaunamos su `prompts/get`:

```markdown
Generate a {{task_type}} for {{product}} targeting {{audience}} with the following requirements: {{requirements}}
```

#### Įrankiai

**Įrankiai** yra vykdomos funkcijos, kurias AI modeliai gali iškviesti tam, kad atliktų specifinius veiksmus. Jie atspindi MCP ekosistemos „veiksmus“, leidžiančius modeliams sąveikauti su išorinėmis sistemomis:

- **Vykdomos funkcijos**: Konkretūs veiksmai, kuriuos modeliai gali iškviesti su specifiniais parametrais.
- **Išorinių sistemų integracija**: API iškvietimai, duomenų bazės užklausos, failų operacijos, skaičiavimai.
- **Unikali tapatybė**: Kiekvienas įrankis turi unikalų pavadinimą, aprašymą ir parametrų schemą.
- **Struktūruota I/O**: Įrankiai priima validuotus parametrus ir grąžina struktūruotus, tipizuotus atsakymus.
- **Veiksmų galimybės**: Leidžia modeliams atlikti realius veiksmus ir gauti tiesioginius duomenis.

Įrankiai apibrėžiami JSON Schema parametru validacijai ir atrandami per `tools/list`, o vykdomi per `tools/call`:

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

## Klientų primityvai

Model Context Protocol (MCP) sistemoje **klientai** gali atskleisti primityvus, leidžiančius serveriams prašyti papildomų galimybių iš host programos. Šie klientų pusės primityvai leidžia kurti turtingesnes, interaktyvesnes serverių implementacijas, kurios gali pasiekti AI modelio galimybes ir vartotojo sąveikas.

### Pavyzdžių generavimas

**Pavyzdžių generavimas** leidžia serveriams prašyti kalbos modelio užbaigimų iš kliento AI programos. Šis primityvas leidžia serveriams pasiekti LLM galimybes be savo modelio priklausomybių:

- **Modelio nepriklausoma prieiga**: Serveriai gali prašyti užbaigimų be LLM SDK ar modelio prieigos valdymo.
- **Serverio inicijuotas AI**: Leidžia serveriams autonomiškai generuoti turinį naudojant kliento AI modelį.
- **Rekursinės LLM sąveikos**: Palaiko sudėtingus scenarijus, kai serveriams reikia AI pagalbos apdorojimui.
- **Dinaminis turinio generavimas**: Leidžia serveriams kurti kontekstinius atsakymus naudojant host modelį.

Pavyzdžių generavimas inicijuojamas per `sampling/complete` metodą, kur serveriai siunčia užbaigimo užklausas klientams.

### Informacijos rinkimas

**Informacijos rinkimas** leidžia serveriams prašyti papildomos informacijos ar patvirtinimo iš vartotojų per kliento sąsają:

- **Vartotojo įvesties užklausos**: Serveriai gali prašyti papildomos informacijos, reikalingos įrankių vykdymui.
- **Patvirtinimo dialogai**: Prašo vartotojo patvirtinimo jautriems ar reikšmingiems veiksmams.
- **Interaktyvūs darbo srautai**: Leidžia serveriams kurti žingsnis po žingsnio vartotojo sąveikas.
- **Dinaminis parametrų rinkimas**: Surenka trūkstamus ar pasirenkamus parametrus įrankių vykdymo metu.

Informacijos rinkimo užklausos siunčiamos naudojant `elicitation/request` metodą, kad būtų surinkta vartotojo įvestis per kliento sąsają.

### Žurnalavimas

**Žurnalavimas** leidžia serveriams siųsti struktūruotus žurnalo pranešimus klientams, skirtus derinimui, stebėjimui ir operaciniam matomumui:

- **Derinimo palaikymas**: Leidžia serveriams pateikti detalius vykdymo žurnalus problemų sprendimui.
- **Operacinis stebėjimas**: Siunčia būsenos atnaujinimus ir našumo metrikas klientams.
- **Klaidų ataskaitos**: Pateikia detalią klaidų kontekstą ir diagnostinę informaciją.
- **Audito pėdsakai**: Kuria išsamius serverio operacijų ir sprendimų ž
- **JSON-RPC 2.0 Protokolas**: Visa komunikacija naudoja standartizuotą JSON-RPC 2.0 žinučių formatą metodų iškvietimams, atsakymams ir pranešimams
- **Gyvavimo ciklo valdymas**: Tvarko ryšio inicializavimą, galimybių derinimą ir sesijos užbaigimą tarp klientų ir serverių
- **Serverio primityvai**: Leidžia serveriams teikti pagrindines funkcijas per įrankius, išteklius ir užklausas
- **Kliento primityvai**: Leidžia serveriams prašyti LLM pavyzdžių, gauti vartotojo įvestį ir siųsti žurnalo pranešimus
- **Pranešimai realiuoju laiku**: Palaiko asinchroninius pranešimus dinamiškiems atnaujinimams be apklausos

#### Pagrindinės funkcijos:

- **Protokolo versijos derinimas**: Naudoja datomis pagrįstą versijavimą (YYYY-MM-DD), kad užtikrintų suderinamumą
- **Galimybių atradimas**: Klientai ir serveriai keičiasi palaikomų funkcijų informacija inicializacijos metu
- **Būsenos sesijos**: Išlaiko ryšio būseną per kelias sąveikas, kad būtų užtikrintas konteksto tęstinumas

### Transporto sluoksnis

**Transporto sluoksnis** valdo komunikacijos kanalus, žinučių rėminimą ir autentifikaciją tarp MCP dalyvių:

#### Palaikomi transporto mechanizmai:

1. **STDIO transportas**:
   - Naudoja standartinius įvesties/išvesties srautus tiesioginei procesų komunikacijai
   - Optimalus vietiniams procesams toje pačioje mašinoje be tinklo apkrovos
   - Dažnai naudojamas vietinėse MCP serverio implementacijose

2. **Srautinio HTTP transportas**:
   - Naudoja HTTP POST klientų ir serverių žinutėms  
   - Pasirenkami serverio siunčiami įvykiai (SSE) serverio ir kliento srautui
   - Leidžia nuotolinę serverio komunikaciją per tinklus
   - Palaiko standartinę HTTP autentifikaciją (autentifikacijos žetonai, API raktai, pasirinktinės antraštės)
   - MCP rekomenduoja OAuth saugiam autentifikavimui žetonais

#### Transporto abstrakcija:

Transporto sluoksnis abstrahuoja komunikacijos detales nuo duomenų sluoksnio, leidžiant naudoti tą patį JSON-RPC 2.0 žinučių formatą visuose transporto mechanizmuose. Ši abstrakcija leidžia programoms sklandžiai pereiti tarp vietinių ir nuotolinių serverių.

### Saugumo aspektai

MCP implementacijos turi laikytis kelių svarbių saugumo principų, kad užtikrintų saugias, patikimas ir saugias sąveikas visose protokolo operacijose:

- **Vartotojo sutikimas ir kontrolė**: Vartotojai turi aiškiai sutikti prieš prieinant prie duomenų ar atliekant operacijas. Jie turi turėti aiškią kontrolę, kokie duomenys yra dalijami ir kokie veiksmai yra leidžiami, palaikomi intuityvių vartotojo sąsajų peržiūrai ir veiklų patvirtinimui.

- **Duomenų privatumas**: Vartotojo duomenys turėtų būti atskleidžiami tik su aiškiu sutikimu ir turi būti apsaugoti tinkamomis prieigos kontrolėmis. MCP implementacijos turi apsaugoti nuo neteisėto duomenų perdavimo ir užtikrinti privatumo išlaikymą visose sąveikose.

- **Įrankių saugumas**: Prieš naudojant bet kokį įrankį, reikalingas aiškus vartotojo sutikimas. Vartotojai turi aiškiai suprasti kiekvieno įrankio funkcionalumą, o tvirtos saugumo ribos turi būti užtikrintos, kad būtų išvengta netyčinio ar nesaugaus įrankio vykdymo.

Laikydamasis šių saugumo principų, MCP užtikrina vartotojų pasitikėjimą, privatumą ir saugumą visose protokolo sąveikose, tuo pačiu leidžiant galingas AI integracijas.

## Kodo pavyzdžiai: pagrindiniai komponentai

Žemiau pateikiami kelių populiarių programavimo kalbų kodo pavyzdžiai, iliustruojantys, kaip įgyvendinti pagrindinius MCP serverio komponentus ir įrankius.

### .NET pavyzdys: paprasto MCP serverio kūrimas su įrankiais

Praktinis .NET kodo pavyzdys, rodantis, kaip įgyvendinti paprastą MCP serverį su pasirinktiniais įrankiais. Šis pavyzdys parodo, kaip apibrėžti ir registruoti įrankius, tvarkyti užklausas ir prijungti serverį naudojant Model Context Protocol.

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

### Java pavyzdys: MCP serverio komponentai

Šis pavyzdys demonstruoja tą patį MCP serverį ir įrankių registraciją kaip aukščiau pateiktame .NET pavyzdyje, tačiau įgyvendintą Java kalba.

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

### Python pavyzdys: MCP serverio kūrimas

Šiame pavyzdyje parodoma, kaip sukurti MCP serverį Python kalba. Taip pat pateikiami du skirtingi būdai, kaip sukurti įrankius.

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

### JavaScript pavyzdys: MCP serverio kūrimas

Šis pavyzdys rodo MCP serverio kūrimą JavaScript kalba ir kaip registruoti du su oru susijusius įrankius.

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

Šis JavaScript pavyzdys demonstruoja, kaip sukurti MCP klientą, kuris prisijungia prie serverio, siunčia užklausą ir apdoroja atsakymą, įskaitant bet kokius įrankių iškvietimus.

## Saugumas ir autorizacija

MCP apima kelias įmontuotas sąvokas ir mechanizmus saugumo ir autorizacijos valdymui visame protokole:

1. **Įrankių leidimų kontrolė**:  
   Klientai gali nurodyti, kokius įrankius modelis gali naudoti sesijos metu. Tai užtikrina, kad prieinami tik aiškiai leidžiami įrankiai, sumažinant netyčinių ar nesaugių operacijų riziką. Leidimai gali būti dinamiškai konfigūruojami pagal vartotojo pageidavimus, organizacines politiką ar sąveikos kontekstą.

2. **Autentifikacija**:  
   Serveriai gali reikalauti autentifikacijos prieš suteikiant prieigą prie įrankių, išteklių ar jautrių operacijų. Tai gali apimti API raktus, OAuth žetonus ar kitas autentifikacijos schemas. Tinkama autentifikacija užtikrina, kad tik patikimi klientai ir vartotojai gali naudotis serverio galimybėmis.

3. **Validacija**:  
   Parametrų validacija yra privaloma visiems įrankių iškvietimams. Kiekvienas įrankis apibrėžia laukiamus tipus, formatus ir apribojimus savo parametrams, o serveris atitinkamai validuoja gaunamas užklausas. Tai apsaugo nuo neteisingos ar kenksmingos įvesties pasiekimo įrankių implementacijas ir padeda išlaikyti operacijų vientisumą.

4. **Naudojimo apribojimai**:  
   Siekiant užkirsti kelią piktnaudžiavimui ir užtikrinti sąžiningą serverio išteklių naudojimą, MCP serveriai gali įgyvendinti naudojimo apribojimus įrankių iškvietimams ir išteklių prieigai. Apribojimai gali būti taikomi vartotojui, sesijai ar globaliai ir padeda apsaugoti nuo paslaugų atsisakymo atakų ar per didelio išteklių naudojimo.

Sujungus šiuos mechanizmus, MCP suteikia saugų pagrindą kalbos modelių integracijai su išoriniais įrankiais ir duomenų šaltiniais, tuo pačiu suteikiant vartotojams ir kūrėjams detalią prieigos ir naudojimo kontrolę.

## Protokolo žinutės ir komunikacijos eiga

MCP komunikacija naudoja struktūrizuotas **JSON-RPC 2.0** žinutes, kad palengvintų aiškias ir patikimas sąveikas tarp hostų, klientų ir serverių. Protokolas apibrėžia specifinius žinučių modelius skirtingoms operacijų rūšims:

### Pagrindinės žinučių rūšys:

#### **Inicializacijos žinutės**
- **`initialize` užklausa**: Užmezga ryšį ir derina protokolo versiją bei galimybes
- **`initialize` atsakymas**: Patvirtina palaikomas funkcijas ir serverio informaciją  
- **`notifications/initialized`**: Signalizuoja, kad inicializacija baigta ir sesija paruošta

#### **Atradimo žinutės**
- **`tools/list` užklausa**: Atranda galimus serverio įrankius
- **`resources/list` užklausa**: Išvardija galimus išteklius (duomenų šaltinius)
- **`prompts/list` užklausa**: Gauti galimus užklausų šablonus

#### **Vykdymo žinutės**  
- **`tools/call` užklausa**: Vykdo konkretų įrankį su pateiktais parametrais
- **`resources/read` užklausa**: Gauti turinį iš konkretaus ištekliaus
- **`prompts/get` užklausa**: Gauti užklausos šabloną su pasirenkamais parametrais

#### **Kliento pusės žinutės**
- **`sampling/complete` užklausa**: Serveris prašo LLM užbaigimo iš kliento
- **`elicitation/request`**: Serveris prašo vartotojo įvesties per kliento sąsają
- **Žurnalo žinutės**: Serveris siunčia struktūrizuotas žurnalo žinutes klientui

#### **Pranešimų žinutės**
- **`notifications/tools/list_changed`**: Serveris praneša klientui apie įrankių pokyčius
- **`notifications/resources/list_changed`**: Serveris praneša klientui apie išteklių pokyčius  
- **`notifications/prompts/list_changed`**: Serveris praneša klientui apie užklausų pokyčius

### Žinučių struktūra:

Visos MCP žinutės atitinka JSON-RPC 2.0 formatą su:
- **Užklausų žinutėmis**: Įtraukia `id`, `method` ir pasirenkamus `params`
- **Atsakymų žinutėmis**: Įtraukia `id` ir arba `result`, arba `error`  
- **Pranešimų žinutėmis**: Įtraukia `method` ir pasirenkamus `params` (be `id` ar atsakymo)

Ši struktūrizuota komunikacija užtikrina patikimas, atsekamas ir išplečiamas sąveikas, palaikančias pažangius scenarijus, tokius kaip atnaujinimai realiuoju laiku, įrankių grandinės ir tvirtas klaidų tvarkymas.

## Pagrindiniai akcentai

- **Architektūra**: MCP naudoja klientų-serverių architektūrą, kur hostai valdo kelis klientų ryšius su serveriais
- **Dalyviai**: Ekosistemą sudaro hostai (AI programos), klientai (protokolo jungtys) ir serveriai (galimybių teikėjai)
- **Transporto mechanizmai**: Komunikacija palaiko STDIO (vietinį) ir srautinį HTTP su pasirenkamu SSE (nuotolinį)
- **Pagrindiniai primityvai**: Serveriai teikia įrankius (vykdomas funkcijas), išteklius (duomenų šaltinius) ir užklausas (šablonus)
- **Kliento primityvai**: Serveriai gali prašyti pavyzdžių (LLM užbaigimų), vartotojo įvesties ir žurnalų iš klientų
- **Protokolo pagrindas**: Sukurtas ant JSON-RPC 2.0 su datomis pagrįstu versijavimu (dabartinis: 2025-06-18)
- **Realaus laiko galimybės**: Palaiko pranešimus dinamiškiems atnaujinimams ir sinchronizacijai realiuoju laiku
- **Saugumas pirmiausia**: Aiškus vartotojo sutikimas, duomenų privatumo apsauga ir saugus transportas yra pagrindiniai reikalavimai

## Užduotis

Sukurkite paprastą MCP įrankį, kuris būtų naudingas jūsų srityje. Apibrėžkite:
1. Įrankio pavadinimą
2. Kokius parametrus jis priims
3. Kokį rezultatą jis grąžins
4. Kaip modelis galėtų naudoti šį įrankį vartotojo problemoms spręsti


---

## Kas toliau

Toliau: [2 skyrius: Saugumas](../02-Security/README.md)

---

**Atsakomybės atsisakymas**:  
Šis dokumentas buvo išverstas naudojant AI vertimo paslaugą [Co-op Translator](https://github.com/Azure/co-op-translator). Nors stengiamės užtikrinti tikslumą, prašome atkreipti dėmesį, kad automatiniai vertimai gali turėti klaidų ar netikslumų. Originalus dokumentas jo gimtąja kalba turėtų būti laikomas autoritetingu šaltiniu. Kritinei informacijai rekomenduojama naudoti profesionalų žmogaus vertimą. Mes neprisiimame atsakomybės už nesusipratimus ar klaidingus interpretavimus, atsiradusius dėl šio vertimo naudojimo.