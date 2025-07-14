<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "fbe345ba124324648cfb3aef9a9120b8",
  "translation_date": "2025-07-13T20:48:37+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "sw"
}
-->
# Uchezaji wa HTTPS kwa Itifaki ya Muktadha wa Mfano (MCP)

Sura hii inatoa mwongozo kamili wa kutekeleza uchezaji salama, unaoweza kupanuka, na wa wakati halisi kwa kutumia Itifaki ya Muktadha wa Mfano (MCP) kwa kutumia HTTPS. Inajumuisha sababu za uchezaji, mifumo ya usafirishaji inayopatikana, jinsi ya kutekeleza HTTP inayoweza kuchezwa katika MCP, mbinu bora za usalama, uhamishaji kutoka SSE, na mwongozo wa vitendo wa kujenga programu zako za uchezaji za MCP.

## Mifumo ya Usafirishaji na Uchezaji katika MCP

Sehemu hii inachunguza mifumo tofauti ya usafirishaji inayopatikana katika MCP na nafasi yao katika kuwezesha uwezo wa uchezaji kwa mawasiliano ya wakati halisi kati ya wateja na seva.

### Nini maana ya Mfumo wa Usafirishaji?

Mfumo wa usafirishaji unaelezea jinsi data inavyobadilishana kati ya mteja na seva. MCP inaunga mkono aina mbalimbali za usafirishaji ili kufaa mazingira na mahitaji tofauti:

- **stdio**: Ingizo/Toleo la kawaida, linafaa kwa zana za eneo la kompyuta na zile zinazotumia CLI. Rahisi lakini halifai kwa wavuti au wingu.
- **SSE (Matukio Yanayotumwa na Seva)**: Inaruhusu seva kusukuma masasisho ya wakati halisi kwa wateja kupitia HTTP. Inafaa kwa UI za wavuti, lakini ina mipaka katika upanuzi na kubadilika.
- **Streamable HTTP**: Usafirishaji wa kisasa wa uchezaji unaotegemea HTTP, unaounga mkono arifa na upanuzi bora. Inapendekezwa kwa hali nyingi za uzalishaji na wingu.

### Jedwali la Ulinganisho

Tazama jedwali la ulinganisho hapa chini kuelewa tofauti kati ya mifumo hii ya usafirishaji:

| Usafirishaji      | Masasisho ya Wakati Halisi | Uchezaji | Upanuzi | Matumizi                  |
|-------------------|----------------------------|----------|---------|---------------------------|
| stdio             | Hapana                     | Hapana   | Chini   | Zana za eneo la CLI       |
| SSE               | Ndiyo                      | Ndiyo    | Kati    | Wavuti, masasisho ya wakati halisi |
| Streamable HTTP   | Ndiyo                      | Ndiyo    | Juu     | Wingu, wateja wengi       |

> **Tip:** Kuchagua usafirishaji sahihi huathiri utendaji, upanuzi, na uzoefu wa mtumiaji. **Streamable HTTP** inapendekezwa kwa programu za kisasa, zinazoweza kupanuka, na zinazotegemewa kwa wingu.

Kumbuka usafirishaji stdio na SSE ulioonyeshwa katika sura zilizopita na jinsi streamable HTTP inavyoshughulikiwa katika sura hii.

## Uchezaji: Dhana na Sababu

Kuelewa dhana za msingi na sababu za uchezaji ni muhimu kwa kutekeleza mifumo madhubuti ya mawasiliano ya wakati halisi.

**Uchezaji** ni mbinu katika programu za mtandao inayoruhusu data kutumwa na kupokelewa kwa vipande vidogo vinavyoweza kudhibitiwa au kama mfululizo wa matukio, badala ya kusubiri jibu lote liwe tayari. Hii ni muhimu hasa kwa:

- Faili kubwa au seti za data.
- Masasisho ya wakati halisi (mfano, mazungumzo, vipimo vya maendeleo).
- Hesabu za muda mrefu ambapo unataka kumjulisha mtumiaji.

Hapa ni mambo muhimu kuhusu uchezaji kwa kiwango cha juu:

- Data hutolewa hatua kwa hatua, si zote kwa wakati mmoja.
- Mteja anaweza kuchakata data anapopokea.
- Hupunguza ucheleweshaji unaoonekana na kuboresha uzoefu wa mtumiaji.

### Kwa Nini Tumia Uchezaji?

Sababu za kutumia uchezaji ni kama ifuatavyo:

- Watumiaji hupata mrejesho mara moja, si tu mwishoni
- Inaruhusu programu za wakati halisi na UI zinazojibu haraka
- Matumizi bora ya rasilimali za mtandao na kompyuta

### Mfano Rahisi: Seva na Mteja wa Uchezaji wa HTTP

Hapa kuna mfano rahisi wa jinsi uchezaji unavyoweza kutekelezwa:

<details>
<summary>Python</summary>

**Seva (Python, kutumia FastAPI na StreamingResponse):**
<details>
<summary>Python</summary>

```python
from fastapi import FastAPI
from fastapi.responses import StreamingResponse
import time

app = FastAPI()

async def event_stream():
    for i in range(1, 6):
        yield f"data: Message {i}\n\n"
        time.sleep(1)

@app.get("/stream")
def stream():
    return StreamingResponse(event_stream(), media_type="text/event-stream")
```

</details>

**Mteja (Python, kutumia requests):**
<details>
<summary>Python</summary>

```python
import requests

with requests.get("http://localhost:8000/stream", stream=True) as r:
    for line in r.iter_lines():
        if line:
            print(line.decode())
```

</details>

Mfano huu unaonyesha seva ikituma mfululizo wa ujumbe kwa mteja anapopatikana, badala ya kusubiri ujumbe wote uwe tayari.

**Jinsi inavyofanya kazi:**
- Seva hutuma kila ujumbe linapokuwa tayari.
- Mteja hupokea na kuchapisha kila kipande anapopokea.

**Mahitaji:**
- Seva lazima itumie jibu la uchezaji (mfano, `StreamingResponse` katika FastAPI).
- Mteja lazima achakathe jibu kama mto (`stream=True` katika requests).
- Aina ya maudhui kawaida ni `text/event-stream` au `application/octet-stream`.

</details>

<details>
<summary>Java</summary>

**Seva (Java, kutumia Spring Boot na Server-Sent Events):**

```java
@RestController
public class CalculatorController {

    @GetMapping(value = "/calculate", produces = MediaType.TEXT_EVENT_STREAM_VALUE)
    public Flux<ServerSentEvent<String>> calculate(@RequestParam double a,
                                                   @RequestParam double b,
                                                   @RequestParam String op) {
        
        double result;
        switch (op) {
            case "add": result = a + b; break;
            case "sub": result = a - b; break;
            case "mul": result = a * b; break;
            case "div": result = b != 0 ? a / b : Double.NaN; break;
            default: result = Double.NaN;
        }

        return Flux.<ServerSentEvent<String>>just(
                    ServerSentEvent.<String>builder()
                        .event("info")
                        .data("Calculating: " + a + " " + op + " " + b)
                        .build(),
                    ServerSentEvent.<String>builder()
                        .event("result")
                        .data(String.valueOf(result))
                        .build()
                )
                .delayElements(Duration.ofSeconds(1));
    }
}
```

**Mteja (Java, kutumia Spring WebFlux WebClient):**

```java
@SpringBootApplication
public class CalculatorClientApplication implements CommandLineRunner {

    private final WebClient client = WebClient.builder()
            .baseUrl("http://localhost:8080")
            .build();

    @Override
    public void run(String... args) {
        client.get()
                .uri(uriBuilder -> uriBuilder
                        .path("/calculate")
                        .queryParam("a", 7)
                        .queryParam("b", 5)
                        .queryParam("op", "mul")
                        .build())
                .accept(MediaType.TEXT_EVENT_STREAM)
                .retrieve()
                .bodyToFlux(String.class)
                .doOnNext(System.out::println)
                .blockLast();
    }
}
```

**Maelezo ya Utekelezaji wa Java:**
- Inatumia stack ya reactive ya Spring Boot na `Flux` kwa uchezaji
- `ServerSentEvent` hutoa uchezaji wa matukio uliopangwa na aina za matukio
- `WebClient` na `bodyToFlux()` huruhusu matumizi ya uchezaji wa reactive
- `delayElements()` huiga muda wa usindikaji kati ya matukio
- Matukio yanaweza kuwa na aina (`info`, `result`) kwa usimamizi bora wa mteja

</details>

### Ulinganisho: Uchezaji wa Klasiki vs Uchezaji wa MCP

Tofauti kati ya jinsi uchezaji unavyofanya kazi kwa njia ya "klasiki" na jinsi unavyofanya kazi katika MCP inaweza kuonyeshwa kama ifuatavyo:

| Kipengele              | Uchezaji wa HTTP wa Klasiki    | Uchezaji wa MCP (Arifa)          |
|-----------------------|-------------------------------|---------------------------------|
| Jibu kuu              | Vipande                       | Moja, mwishoni                   |
| Masasisho ya maendeleo | Hutumwa kama vipande vya data | Hutumwa kama arifa               |
| Mahitaji ya mteja     | Lazima achakathe mto          | Lazima aweke mtekelezaji wa ujumbe |
| Matumizi              | Faili kubwa, mfululizo wa token za AI | Maendeleo, kumbukumbu, mrejesho wa wakati halisi |

### Tofauti Muhimu Zinazojitokeza

Zaidi ya hayo, hapa kuna tofauti muhimu:

- **Mfumo wa Mawasiliano:**
   - Uchezaji wa HTTP wa klasiki: Hutumia usafirishaji wa vipande rahisi kutuma data
   - Uchezaji wa MCP: Hutumia mfumo wa arifa uliopangwa kwa itifaki ya JSON-RPC

- **Muundo wa Ujumbe:**
   - HTTP wa klasiki: Vipande vya maandishi ya kawaida na mistari mipya
   - MCP: Vitu vya arifa vya LoggingMessageNotification vilivyo na metadata

- **Utekelezaji wa Mteja:**
   - HTTP wa klasiki: Mteja rahisi anayechakata majibu ya uchezaji
   - MCP: Mteja wa hali ya juu mwenye mtekelezaji wa ujumbe kuchakata aina tofauti za ujumbe

- **Masasisho ya Maendeleo:**
   - HTTP wa klasiki: Maendeleo ni sehemu ya mto wa jibu kuu
   - MCP: Maendeleo hutumwa kupitia arifa tofauti wakati jibu kuu linakuja mwishoni

### Mapendekezo

Kuna mambo tunayopendekeza kuhusu kuchagua kati ya kutekeleza uchezaji wa klasiki (kama tulivyoonyesha hapo juu kwa kutumia `/stream`) dhidi ya kuchagua uchezaji kupitia MCP.

- **Kwa mahitaji rahisi ya uchezaji:** Uchezaji wa HTTP wa klasiki ni rahisi kutekeleza na unatosha kwa mahitaji ya msingi.

- **Kwa programu tata, zinazoingiliana:** Uchezaji wa MCP hutoa njia iliyopangwa zaidi yenye metadata tajiri na utofauti kati ya arifa na matokeo ya mwisho.

- **Kwa programu za AI:** Mfumo wa arifa wa MCP ni muhimu hasa kwa kazi za AI zinazochukua muda mrefu ambapo unataka kuwajulisha watumiaji maendeleo.

## Uchezaji katika MCP

Sawa, umeona mapendekezo na ulinganisho hadi sasa kuhusu tofauti kati ya uchezaji wa klasiki na uchezaji katika MCP. Hebu tuchunguze kwa undani jinsi unavyoweza kutumia uchezaji katika MCP.

Kuelewa jinsi uchezaji unavyofanya kazi ndani ya mfumo wa MCP ni muhimu kwa kujenga programu zinazojibu haraka na kutoa mrejesho wa wakati halisi kwa watumiaji wakati wa shughuli za muda mrefu.

Katika MCP, uchezaji siyo kutuma jibu kuu kwa vipande, bali ni kutuma **arifa** kwa mteja wakati zana inashughulikia ombi. Arifa hizi zinaweza kujumuisha masasisho ya maendeleo, kumbukumbu, au matukio mengine.

### Jinsi inavyofanya kazi

Matokeo kuu bado hutumwa kama jibu moja. Hata hivyo, arifa zinaweza kutumwa kama ujumbe tofauti wakati wa usindikaji na hivyo kusasisha mteja kwa wakati halisi. Mteja lazima aweze kushughulikia na kuonyesha arifa hizi.

## Nini maana ya Arifa?

Tulisema "Arifa", maana yake ni nini katika muktadha wa MCP?

Arifa ni ujumbe unaotumwa kutoka seva kwenda kwa mteja kuarifu kuhusu maendeleo, hali, au matukio mengine wakati wa shughuli za muda mrefu. Arifa huongeza uwazi na uzoefu wa mtumiaji.

Kwa mfano, mteja anapaswa kutuma arifa mara baada ya mkutano wa awali na seva kufanyika.

Arifa inaonekana kama ujumbe wa JSON kama ifuatavyo:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Arifa zinahusiana na mada katika MCP inayojulikana kama ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Ili kuwezesha logging, seva inahitaji kuiwezesha kama kipengele/uwezo kama ifuatavyo:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Kulingana na SDK inayotumika, logging inaweza kuwa imewezeshwa kwa chaguo-msingi, au unaweza kuhitaji kuiwezesha waziwazi katika usanidi wa seva yako.

Kuna aina tofauti za arifa:

| Kiwango    | Maelezo                      | Mfano wa Matumizi             |
|------------|------------------------------|------------------------------|
| debug      | Maelezo ya kina ya ufuatiliaji | Mambo ya kuingia/kuondoka ya kazi |
| info       | Ujumbe wa taarifa za jumla    | Masasisho ya maendeleo ya operesheni |
| notice     | Matukio ya kawaida lakini muhimu | Mabadiliko ya usanidi         |
| warning    | Hali za onyo                  | Matumizi ya kipengele kilichokataliwa |
| error      | Hali za makosa               | Kushindwa kwa operesheni      |
| critical   | Hali za hatari                | Kushindwa kwa sehemu ya mfumo |
| alert      | Hatua lazima zichukuliwe mara moja | Ugonjwa wa data umegunduliwa |
| emergency  | Mfumo hauwezi kutumika        | Kushindwa kabisa kwa mfumo   |

## Kutekeleza Arifa katika MCP

Ili kutekeleza arifa katika MCP, unahitaji kuandaa pande zote za seva na mteja kushughulikia masasisho ya wakati halisi. Hii inaruhusu programu yako kutoa mrejesho wa papo hapo kwa watumiaji wakati wa shughuli za muda mrefu.

### Seva: Kutuma Arifa

Tuanze na upande wa seva. Katika MCP, unaelezea zana zinazoweza kutuma arifa wakati wa kushughulikia maombi. Seva hutumia kitu cha muktadha (kawaida `ctx`) kutuma ujumbe kwa mteja.

<details>
<summary>Python</summary>

<details>
<summary>Python</summary>

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    await ctx.info("Processing file 1/3...")
    await ctx.info("Processing file 2/3...")
    await ctx.info("Processing file 3/3...")
    return TextContent(type="text", text=f"Done: {message}")
```

Katika mfano uliotangulia, zana `process_files` inatuma arifa tatu kwa mteja wakati inashughulikia kila faili. Njia `ctx.info()` hutumika kutuma ujumbe wa taarifa.

</details>

Zaidi ya hayo, ili kuwezesha arifa, hakikisha seva yako inatumia usafirishaji wa uchezaji (kama `streamable-http`) na mteja wako anaweka mtekelezaji wa ujumbe kushughulikia arifa. Hapa ni jinsi unavyoweza kuandaa seva kutumia usafirishaji wa `streamable-http`:

```python
mcp.run(transport="streamable-http")
```

</details>

<details>
<summary>.NET</summary>

```csharp
[Tool("A tool that sends progress notifications")]
public async Task<TextContent> ProcessFiles(string message, ToolContext ctx)
{
    await ctx.Info("Processing file 1/3...");
    await ctx.Info("Processing file 2/3...");
    await ctx.Info("Processing file 3/3...");
    return new TextContent
    {
        Type = "text",
        Text = $"Done: {message}"
    };
}
```

Katika mfano huu wa .NET, zana `ProcessFiles` imewekwa alama na sifa ya `Tool` na inatuma arifa tatu kwa mteja wakati inashughulikia kila faili. Njia `ctx.Info()` hutumika kutuma ujumbe wa taarifa.

Ili kuwezesha arifa katika seva yako ya MCP ya .NET, hakikisha unatumia usafirishaji wa uchezaji:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Mteja: Kupokea Arifa

Mteja lazima aweke mtekelezaji wa ujumbe kushughulikia na kuonyesha arifa zinapowasili.

<details>
<summary>Python</summary>

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)

async with ClientSession(
   read_stream, 
   write_stream,
   logging_callback=logging_collector,
   message_handler=message_handler,
) as session:
```

Katika msimbo uliotangulia, kazi `message_handler` inakagua kama ujumbe unaokuja ni arifa. Ikiwa ni arifa, inachapisha arifa; vinginevyo, inachakata kama ujumbe wa kawaida wa seva. Pia angalia jinsi `ClientSession` inavyoanzishwa na `message_handler` kushughulikia arifa zinazoingia.

</details>

<details>
<summary>.NET</summary>

```csharp
// Define a message handler
void MessageHandler(IJsonRpcMessage message)
{
    if (message is ServerNotification notification)
    {
        Console.WriteLine($"NOTIFICATION: {notification}");
    }
    else
    {
        Console.WriteLine($"SERVER MESSAGE: {message}");
    }
}

// Create and use a client session with the message handler
var clientOptions = new ClientSessionOptions
{
    MessageHandler = MessageHandler,
    LoggingCallback = (level, message) => Console.WriteLine($"[{level}] {message}")
};

using var client = new ClientSession(readStream, writeStream, clientOptions);
await client.InitializeAsync();

// Now the client will process notifications through the MessageHandler
```

Katika mfano huu wa .NET, kazi `MessageHandler` inakagua kama ujumbe unaokuja ni arifa. Ikiwa ni arifa, inachapisha arifa; vinginevyo, inachakata kama ujumbe wa kawaida wa seva. `ClientSession` inaanzishwa na mtekelezaji wa ujumbe kupitia `ClientSessionOptions`.

</details>

Ili kuwezesha arifa, hakikisha seva yako inatumia usafirishaji wa uchezaji (kama `streamable-http`) na mteja wako anaweka mtekelezaji wa ujumbe kushughulikia arifa.

## Arifa za Maendeleo & Hali za Matumizi

Sehemu hii inaelezea dhana ya arifa za maendeleo katika MCP, kwa nini ni muhimu, na jinsi ya kuzitekeleza kwa kutumia Streamable HTTP. Pia utapata zoezi la vitendo kukuza uelewa wako.

Arifa za maendeleo ni ujumbe wa wakati halisi unaotumwa kutoka seva kwenda kwa mteja wakati wa shughuli za muda mrefu. Badala ya kusubiri mchakato mzima ukamilike, seva huendelea kumjulisha mteja kuhusu hali ya sasa. Hii huongeza uwazi, uzoefu wa mtumiaji, na kurahisisha utambuzi wa matatizo.

**Mfano:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Kwa Nini Tumia Arifa za Maendeleo?

Arifa za maendeleo ni muhimu kwa sababu kadhaa:

- **Uzoefu bora wa mtumiaji:** Watumiaji wanaona masasisho wanapofanya kazi, si tu mwishoni.
- **Mrejesho wa wakati halisi:** Wateja wanaweza kuonyesha vipimo vya maendeleo au kumbukumbu, na kufanya programu ionekane inayojibu.
- **Utambuzi rahisi wa matatizo na ufuatiliaji:** Waendelezaji na watumiaji wanaweza kuona sehemu ambapo mchakato unaweza kuwa polepole au umekwama.

### Jinsi ya Kutekeleza Arifa za Maendeleo

Hapa ni jinsi unavyoweza kutekeleza arifa za maendeleo katika MCP:

- **Kwenye seva:** Tumia `ctx.info()` au `ctx.log()` kutuma arifa kila kipengele kinaposhughulikiwa. Hii hutuma ujumbe kwa mteja kabla ya matokeo kuu kuwa tayari.
- **Kwenye mteja:** Weka mtekelezaji wa ujumbe unaosikiliza na kuonyesha arifa zinapowasili. Mtekelezaji huyu hutofautisha kati ya arifa na matokeo ya mwisho.

**Mfano wa Seva:**

<summary>Python</summary>

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    for i in range(1, 11):
        await ctx.info(f"Processing document {i}/10")
    await ctx.info("Processing complete!")
    return TextContent(type="text", text=f"Done: {message}")
```

</details>

**Mfano wa Mteja:**

<details>
<summary>Python</summary>

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)
```

</details>

## Mambo ya Usalama Kuzingatiwa

Unapotekeleza seva za MCP kwa kutumia usafirishaji wa HTTP, usalama unakuwa jambo la msingi sana linalohitaji umakini mkubwa kwa njia mbalimbali za mashambulizi na mbinu za ulinzi.

### Muhtasari

Usalama ni muhimu sana unapoweka seva za MCP wazi kupitia HTTP. Streamable HTTP huleta maeneo mapya ya mashambulizi na inahitaji usanidi makini.

### Vidokezo Muhimu
- **Uthibitishaji wa Kichwa cha Origin**: Daima hakikisha kichwa cha `Origin` ili kuzuia mashambulizi ya DNS rebinding.
- **Kufunga kwa Localhost**: Kwa maendeleo ya ndani, funga seva kwa `localhost` ili kuepuka kuziweka wazi mtandao wa umma.
- **Uthibitishaji**: Tekeleza uthibitishaji (mfano, API keys, OAuth) kwa matumizi ya uzalishaji.
- **CORS**: Sanidi sera za Cross-Origin Resource Sharing (CORS) ili kudhibiti upatikanaji.
- **HTTPS**: Tumia HTTPS katika uzalishaji ili kusimba trafiki.

### Mbinu Bora
- Usiamini maombi yanayoingia bila uthibitisho.
- Rekodi na fuatilia upatikanaji na makosa yote.
- Sasisha mara kwa mara vyanzo vya programu ili kufunga mianya ya usalama.

### Changamoto
- Kuweka usalama sambamba na urahisi wa maendeleo
- Kuhakikisha ulinganifu na mazingira mbalimbali ya wateja


## Kuboresha kutoka SSE hadi Streamable HTTP

Kwa programu zinazotumia Server-Sent Events (SSE) kwa sasa, kuhama kwenda Streamable HTTP kunatoa uwezo zaidi na uendelevu bora kwa utekelezaji wako wa MCP kwa muda mrefu.

### Kwa Nini Kuboresha?

Kuna sababu mbili muhimu za kuboresha kutoka SSE hadi Streamable HTTP:

- Streamable HTTP hutoa upanuzi bora, ulinganifu, na msaada mzuri wa arifa kuliko SSE.
- Ni usafirishaji unaopendekezwa kwa programu mpya za MCP.

### Hatua za Kuhama

Hivi ndivyo unavyoweza kuhama kutoka SSE hadi Streamable HTTP katika programu zako za MCP:

- **Sasisha msimbo wa seva** kutumia `transport="streamable-http"` katika `mcp.run()`.
- **Sasisha msimbo wa mteja** kutumia `streamablehttp_client` badala ya mteja wa SSE.
- **Tekeleza mshughulikiaji wa ujumbe** katika mteja ili kushughulikia arifa.
- **Jaribu ulinganifu** na zana na taratibu zilizopo.

### Kudumisha Ulinganifu

Inapendekezwa kudumisha ulinganifu na wateja wa SSE waliopo wakati wa mchakato wa kuhama. Hapa kuna mikakati:

- Unaweza kuunga mkono SSE na Streamable HTTP kwa kuendesha usafirishaji wote kwenye anwani tofauti.
- Polepole hamisha wateja kwenda usafirishaji mpya.

### Changamoto

Hakikisha unashughulikia changamoto zifuatazo wakati wa kuhama:

- Kuhakikisha wateja wote wamesasishwa
- Kushughulikia tofauti katika utoaji wa arifa

## Mambo ya Usalama Kuzingatiwa

Usalama unapaswa kuwa kipaumbele cha juu unapotekeleza seva yoyote, hasa unapotumia usafirishaji wa HTTP kama Streamable HTTP katika MCP.

Unapotekeleza seva za MCP kwa kutumia usafirishaji wa HTTP, usalama unakuwa jambo la msingi sana linalohitaji umakini mkubwa kwa njia mbalimbali za mashambulizi na mbinu za ulinzi.

### Muhtasari

Usalama ni muhimu sana unapoweka seva za MCP wazi kupitia HTTP. Streamable HTTP huleta maeneo mapya ya mashambulizi na inahitaji usanidi makini.

Hapa kuna mambo muhimu ya kuzingatia kuhusu usalama:

- **Uthibitishaji wa Kichwa cha Origin**: Daima hakikisha kichwa cha `Origin` ili kuzuia mashambulizi ya DNS rebinding.
- **Kufunga kwa Localhost**: Kwa maendeleo ya ndani, funga seva kwa `localhost` ili kuepuka kuziweka wazi mtandao wa umma.
- **Uthibitishaji**: Tekeleza uthibitishaji (mfano, API keys, OAuth) kwa matumizi ya uzalishaji.
- **CORS**: Sanidi sera za Cross-Origin Resource Sharing (CORS) ili kudhibiti upatikanaji.
- **HTTPS**: Tumia HTTPS katika uzalishaji ili kusimba trafiki.

### Mbinu Bora

Zaidi ya hayo, hapa kuna mbinu bora za kufuata unapotekeleza usalama katika seva yako ya MCP inayotiririsha:

- Usiamini maombi yanayoingia bila uthibitisho.
- Rekodi na fuatilia upatikanaji na makosa yote.
- Sasisha mara kwa mara vyanzo vya programu ili kufunga mianya ya usalama.

### Changamoto

Utakumbana na changamoto kadhaa unapotekeleza usalama katika seva za MCP zinazotiririsha:

- Kuweka usalama sambamba na urahisi wa maendeleo
- Kuhakikisha ulinganifu na mazingira mbalimbali ya wateja

### Kazi: Jenga Programu Yako ya MCP Inayotiririsha

**Hali:**
Jenga seva na mteja wa MCP ambapo seva inashughulikia orodha ya vitu (mfano, faili au nyaraka) na kutuma arifa kwa kila kipengee kinachoshughulikiwa. Mteja anapaswa kuonyesha kila arifa anapopokea.

**Hatua:**

1. Tekeleza zana ya seva inayoshughulikia orodha na kutuma arifa kwa kila kipengee.
2. Tekeleza mteja mwenye mshughulikiaji wa ujumbe kuonyesha arifa kwa wakati halisi.
3. Jaribu utekelezaji wako kwa kuendesha seva na mteja, na angalia arifa zinavyotokea.

[Solution](./solution/README.md)

## Kusoma Zaidi & Nini Kifuatayo?

Ili kuendelea na safari yako na MCP inayotiririsha na kuongeza maarifa yako, sehemu hii inatoa rasilimali za ziada na hatua zinazopendekezwa za kujenga programu za hali ya juu zaidi.

### Kusoma Zaidi

- [Microsoft: Utangulizi wa HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS katika ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Maombi ya Streaming](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Nini Kifuatayo?

- Jaribu kujenga zana za MCP za hali ya juu zinazotumia streaming kwa uchambuzi wa wakati halisi, mazungumzo, au uhariri wa pamoja.
- Chunguza kuunganisha MCP streaming na mifumo ya mbele (React, Vue, n.k.) kwa masasisho ya moja kwa moja ya UI.
- Ifuatayo: [Kutumia AI Toolkit kwa VSCode](../07-aitk/README.md)

**Kiarifu cha Kutotegemea**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inapendekezwa. Hatubebei dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.