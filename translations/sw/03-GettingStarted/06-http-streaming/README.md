<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eda412c63b61335a047f39c44d1b55bc",
  "translation_date": "2025-06-13T01:50:17+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "sw"
}
-->
# HTTPS Streaming with Model Context Protocol (MCP)

Sura hii inatoa mwongozo kamili wa kutekeleza usambazaji salama, unaoweza kupanuka, na wa wakati halisi kwa kutumia Model Context Protocol (MCP) kupitia HTTPS. Inajumuisha sababu za usambazaji, njia za usafirishaji zinazopatikana, jinsi ya kutekeleza HTTP inayoweza kusambazwa ndani ya MCP, mbinu bora za usalama, mabadiliko kutoka SSE, na mwongozo wa vitendo wa kujenga programu zako za MCP zinazoweza kusambazwa.

## Njia za Usafirishaji na Usambazaji katika MCP

Sehemu hii inachunguza njia tofauti za usafirishaji zinazopatikana ndani ya MCP na jukumu lao katika kuwezesha uwezo wa usambazaji kwa mawasiliano ya wakati halisi kati ya wateja na seva.

### Njia ya Usafirishaji ni Nini?

Njia ya usafirishaji inaelezea jinsi data inavyobadilishana kati ya mteja na seva. MCP inaunga mkono aina mbalimbali za usafirishaji ili kufaa mazingira na mahitaji tofauti:

- **stdio**: Ingizo/Output ya kawaida, inayofaa kwa zana za eneo la kazi na za CLI. Rahisi lakini haitafaa kwa wavuti au wingu.
- **SSE (Server-Sent Events)**: Inaruhusu seva kusukuma masasisho ya wakati halisi kwa wateja kupitia HTTP. Inafaa kwa UI za wavuti, lakini ina mipaka ya upanuzi na kubadilika.
- **Streamable HTTP**: Usafirishaji wa kisasa unaotegemea HTTP, unaounga mkono arifa na upanuzi bora. Inapendekezwa kwa hali nyingi za uzalishaji na wingu.

### Jedwali la Ulinganisho

Tazama jedwali la ulinganisho hapa chini kuelewa tofauti kati ya njia hizi za usafirishaji:

| Usafirishaji     | Masasisho ya Wakati Halisi | Usambazaji | Upanuzi | Matumizi                    |
|------------------|----------------------------|------------|---------|-----------------------------|
| stdio            | Hapana                     | Hapana     | Chini   | Zana za eneo la kazi za CLI |
| SSE              | Ndiyo                      | Ndiyo      | Kati    | Wavuti, masasisho ya wakati halisi |
| Streamable HTTP  | Ndiyo                      | Ndiyo      | Juu     | Wingu, wateja wengi         |

> **Tip:** Kuchagua njia sahihi ya usafirishaji huathiri utendaji, upanuzi, na uzoefu wa mtumiaji. **Streamable HTTP** inapendekezwa kwa programu za kisasa, zinazoweza kupanuka, na zenye maandalizi ya wingu.

Tambua njia za usafirishaji stdio na SSE ulizojifunza katika sura zilizopita na jinsi Streamable HTTP inavyofunikwa katika sura hii.

## Usambazaji: Dhana na Sababu

Kuelewa dhana za msingi na sababu za usambazaji ni muhimu kwa kutekeleza mifumo madhubuti ya mawasiliano ya wakati halisi.

**Usambazaji** ni mbinu katika programu za mtandao inayoruhusu data kutumwa na kupokelewa vipande vidogo vinavyoweza kudhibitiwa au kama mlolongo wa matukio, badala ya kusubiri jibu lote liwe tayari. Hii ni muhimu hasa kwa:

- Faili kubwa au seti za data.
- Masasisho ya wakati halisi (mfano, mazungumzo, vipimo vya maendeleo).
- Hisabati za muda mrefu ambapo unataka kumjulisha mtumiaji.

Hapa ni mambo unayopaswa kuyajua kuhusu usambazaji kwa kiwango cha juu:

- Data hutolewa hatua kwa hatua, si yote mara moja.
- Mteja anaweza kushughulikia data anapopokea.
- Hupunguza ucheleweshaji unaohisiwa na kuboresha uzoefu wa mtumiaji.

### Kwa Nini Utumie Usambazaji?

Sababu za kutumia usambazaji ni kama ifuatavyo:

- Watumiaji hupokea mrejesho mara moja, si tu mwishoni
- Huwezesha programu za wakati halisi na UI zinazojibu haraka
- Matumizi bora ya rasilimali za mtandao na kompyuta

### Mfano Rahisi: Seva na Mteja wa HTTP Streaming

Hapa kuna mfano rahisi wa jinsi usambazaji unavyoweza kutekelezwa:

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
- Seva hutuma kila ujumbe anapokuwa tayari.
- Mteja hupokea na kuchapisha kila kipande anapokipokea.

**Mahitaji:**
- Seva lazima itumie jibu la usambazaji (mfano, `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`.

</details>

### Comparison: Classic Streaming vs MCP Streaming

The differences between how streaming works in a "classical" manner versus how it works in MCP can be depicted like so:

| Feature                | Classic HTTP Streaming         | MCP Streaming (Notifications)      |
|------------------------|-------------------------------|-------------------------------------|
| Main response          | Chunked                       | Single, at end                      |
| Progress updates       | Sent as data chunks           | Sent as notifications               |
| Client requirements    | Must process stream           | Must implement message handler      |
| Use case               | Large files, AI token streams | Progress, logs, real-time feedback  |

### Key Differences Observed

Additionally, here are some key differences:

- **Communication Pattern:**
   - Classic HTTP streaming: Uses simple chunked transfer encoding to send data in chunks
   - MCP streaming: Uses a structured notification system with JSON-RPC protocol

- **Message Format:**
   - Classic HTTP: Plain text chunks with newlines
   - MCP: Structured LoggingMessageNotification objects with metadata

- **Client Implementation:**
   - Classic HTTP: Simple client that processes streaming responses
   - MCP: More sophisticated client with a message handler to process different types of messages

- **Progress Updates:**
   - Classic HTTP: The progress is part of the main response stream
   - MCP: Progress is sent via separate notification messages while the main response comes at the end

### Recommendations

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) badala ya kuchagua usambazaji kupitia MCP.

- **Kwa mahitaji rahisi ya usambazaji:** Usambazaji wa HTTP wa kawaida ni rahisi kutekeleza na unatosha kwa mahitaji ya msingi.

- **Kwa programu tata na za mwingiliano:** Usambazaji wa MCP hutoa mbinu iliyo na muundo zaidi na metadata tajiri pamoja na utofauti kati ya arifa na matokeo ya mwisho.

- **Kwa programu za AI:** Mfumo wa arifa wa MCP ni muhimu hasa kwa kazi za AI zinazochukua muda mrefu ambapo unataka kuwajulisha watumiaji maendeleo.

## Usambazaji katika MCP

Sasa, umeona mapendekezo na ulinganisho kuhusu tofauti kati ya usambazaji wa kawaida na ule wa MCP. Hebu tuchambue kwa kina jinsi unavyoweza kutumia usambazaji ndani ya MCP.

Kuelewa jinsi usambazaji unavyofanya kazi ndani ya mfumo wa MCP ni muhimu kwa kujenga programu zinazojibu na kutoa mrejesho wa wakati halisi kwa watumiaji wakati wa shughuli za muda mrefu.

Katika MCP, usambazaji siyo kutuma jibu kuu vipande vipande, bali kutuma **arifa** kwa mteja wakati zana inashughulikia ombi. Arifa hizi zinaweza kujumuisha masasisho ya maendeleo, kumbukumbu, au matukio mengine.

### Jinsi Inavyofanya Kazi

Matokeo makuu bado hutumwa kama jibu moja. Hata hivyo, arifa zinaweza kutumwa kama ujumbe tofauti wakati wa usindikaji na hivyo kusasisha mteja kwa wakati halisi. Mteja lazima aweze kushughulikia na kuonyesha arifa hizi.

## Arifa ni Nini?

Tulizungumza kuhusu "Arifa", maana yake ni nini katika muktadha wa MCP?

Arifa ni ujumbe unaotumwa kutoka seva kwenda kwa mteja kuarifu kuhusu maendeleo, hali, au matukio mengine wakati wa shughuli za muda mrefu. Arifa huongeza uwazi na uzoefu wa mtumiaji.

Kwa mfano, mteja anapaswa kutuma arifa mara tu makubaliano ya awali na seva yametimizwa.

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

Arifa zinahusiana na mada ndani ya MCP inayojulikana kama ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Ili logging ifanye kazi, seva inahitaji kuizima kama kipengele/uwezo kama ifuatavyo:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Kulingana na SDK inayotumika, logging inaweza kuwa imewezeshwa kwa chaguo-msingi, au unaweza kuhitaji kuiwezesha waziwazi katika usanidi wa seva yako.

Kuna aina mbalimbali za arifa:

| Kiwango   | Maelezo                       | Mfano wa Matumizi             |
|-----------|-------------------------------|-------------------------------|
| debug     | Taarifa za kina za ufuatiliaji | Ingizo/matokeo ya kazi za kazi |
| info      | Ujumbe wa taarifa za jumla     | Masasisho ya maendeleo ya operesheni |
| notice    | Matukio ya kawaida lakini muhimu | Mabadiliko ya usanidi          |
| warning   | Hali za onyo                   | Matumizi ya vipengele vilivyotangazwa kuwa havitumiki |
| error     | Hali za makosa                | Kushindwa kwa operesheni       |
| critical  | Hali za hatari kubwa          | Kushindwa kwa vipengele vya mfumo |
| alert     | Hatua ya haraka inahitajika   | Ugundaji wa uharibifu wa data  |
| emergency | Mfumo hauwezi kutumika         | Kushindwa kabisa kwa mfumo    |

## Kutekeleza Arifa katika MCP

Ili kutekeleza arifa katika MCP, unahitaji kuandaa pande zote za seva na mteja kushughulikia masasisho ya wakati halisi. Hii inaruhusu programu yako kutoa mrejesho wa papo hapo kwa watumiaji wakati wa shughuli za muda mrefu.

### Seva: Kutuma Arifa

Tuanze na upande wa seva. Katika MCP, unaeleza zana zinazoweza kutuma arifa wakati zinashughulikia maombi. Seva hutumia kitu cha muktadha (kawaida `ctx`) kutuma ujumbe kwa mteja.

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

Katika mfano uliotangulia, `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` usafirishaji:

```python
mcp.run(transport="streamable-http")
```

</details>

### Mteja: Kupokea Arifa

Mteja lazima atekeleze mshughulikiaji wa ujumbe ili kushughulikia na kuonyesha arifa anazopokea.

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

Katika msimbo uliotangulia, `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) na mteja wako hutekeleza mshughulikiaji wa ujumbe kushughulikia arifa.

## Arifa za Maendeleo & Mifano

Sehemu hii inaelezea dhana ya arifa za maendeleo katika MCP, kwa nini ni muhimu, na jinsi ya kuzitekeleza kwa kutumia Streamable HTTP. Pia utapata zoezi la vitendo kusaidia kuelewa.

Arifa za maendeleo ni ujumbe wa wakati halisi unaotumwa kutoka seva kwenda kwa mteja wakati wa shughuli za muda mrefu. Badala ya kusubiri mchakato mzima ukamilike, seva inaendelea kumjulisha mteja kuhusu hali ya sasa. Hii huongeza uwazi, uzoefu wa mtumiaji, na kurahisisha ufuatiliaji.

**Mfano:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Kwa Nini Utumie Arifa za Maendeleo?

Arifa za maendeleo ni muhimu kwa sababu kadhaa:

- **Uzoefu bora wa mtumiaji:** Watumiaji wanaona masasisho wanapofanya kazi, si tu mwishoni.
- **Mrejesho wa wakati halisi:** Wateja wanaweza kuonyesha vipimo vya maendeleo au kumbukumbu, na kufanya programu ionekane ya haraka.
- **Kufanya ufuatiliaji na uchunguzi kuwa rahisi:** Waendelezaji na watumiaji wanaweza kuona sehemu inayochelewa au kushindwa.

### Jinsi ya Kutekeleza Arifa za Maendeleo

Hapa ni jinsi unavyoweza kutekeleza arifa za maendeleo katika MCP:

- **Seva:** Tumia `ctx.info()` or `ctx.log()` kutuma arifa kila kipengele kinaposhughulikiwa. Hii hutuma ujumbe kwa mteja kabla ya matokeo makuu kuwa tayari.
- **Mteja:** Tekeleza mshughulikiaji wa ujumbe unaosikiliza na kuonyesha arifa anazopokea. Mshughulikiaji huyu hutofautisha kati ya arifa na matokeo ya mwisho.

**Mfano wa Seva:**

<details>
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

## Mambo ya Usalama

Unapotekeleza seva za MCP kwa kutumia usafirishaji wa HTTP, usalama unakuwa jambo la msingi linalohitaji umakini mkubwa dhidi ya aina mbalimbali za mashambulizi na mbinu za ulinzi.

### Muhtasari

Usalama ni muhimu sana wakati seva za MCP zinapowekwa wazi kupitia HTTP. Streamable HTTP huleta maeneo mapya ya mashambulizi na inahitaji usanidi makini.

### Vidokezo Muhimu
- **Uthibitishaji wa kichwa cha Origin**: Daima hakikisha `Origin` header to prevent DNS rebinding attacks.
- **Localhost Binding**: For local development, bind servers to `localhost` to avoid exposing them to the public internet.
- **Authentication**: Implement authentication (e.g., API keys, OAuth) for production deployments.
- **CORS**: Configure Cross-Origin Resource Sharing (CORS) policies to restrict access.
- **HTTPS**: Use HTTPS in production to encrypt traffic.

### Best Practices
- Never trust incoming requests without validation.
- Log and monitor all access and errors.
- Regularly update dependencies to patch security vulnerabilities.

### Challenges
- Balancing security with ease of development
- Ensuring compatibility with various client environments


## Upgrading from SSE to Streamable HTTP

For applications currently using Server-Sent Events (SSE), migrating to Streamable HTTP provides enhanced capabilities and better long-term sustainability for your MCP implementations.

### Why Upgrade?
- Streamable HTTP offers better scalability, compatibility, and richer notification support than SSE.
- It is the recommended transport for new MCP applications.

### Migration Steps
- **Update server code** to use `transport="streamable-http"` in `mcp.run()`.
- **Update client code** to use `streamablehttp_client` instead of SSE client.
- **Implement a message handler** in the client to process notifications.
- **Test for compatibility** with existing tools and workflows.

### Maintaining Compatibility
- You can support both SSE and Streamable HTTP by running both transports on different endpoints.
- Gradually migrate clients to the new transport.

### Challenges
- Ensuring all clients are updated
- Handling differences in notification delivery

## Security Considerations

Security should be a top priority when implementing any server, especially when using HTTP-based transports like Streamable HTTP in MCP. 

When implementing MCP servers with HTTP-based transports, security becomes a paramount concern that requires careful attention to multiple attack vectors and protection mechanisms.

### Overview

Security is critical when exposing MCP servers over HTTP. Streamable HTTP introduces new attack surfaces and requires careful configuration.

Here are some key security considerations:

- **Origin Header Validation**: Always validate the `Origin` header to prevent DNS rebinding attacks.
- **Localhost Binding**: For local development, bind servers to `localhost` to avoid exposing them to the public internet.
- **Authentication**: Implement authentication (e.g., API keys, OAuth) for production deployments.
- **CORS**: Configure Cross-Origin Resource Sharing (CORS) policies to restrict access.
- **HTTPS**: Use HTTPS in production to encrypt traffic.

### Best Practices

Additionally, here are some best practices to follow when implementing security in your MCP streaming server:

- Never trust incoming requests without validation.
- Log and monitor all access and errors.
- Regularly update dependencies to patch security vulnerabilities.

### Challenges

You will face some challenges when implementing security in MCP streaming servers:

- Balancing security with ease of development
- Ensuring compatibility with various client environments


## Upgrading from SSE to Streamable HTTP

For applications currently using Server-Sent Events (SSE), migrating to Streamable HTTP provides enhanced capabilities and better long-term sustainability for your MCP implementations.

### Why Upgrade?

There are two compelling reasons to upgrade from SSE to Streamable HTTP:

- Streamable HTTP offers better scalability, compatibility, and richer notification support than SSE.
- It is the recommended transport for new MCP applications.

### Migration Steps

Here's how you can migrate from SSE to Streamable HTTP in your MCP applications:

1. **Update server code** to use `transport="streamable-http"` in `mcp.run()`.
2. **Update client code** to use `streamablehttp_client` badala ya mteja wa SSE.
3. **Tekeleza mshughulikiaji wa ujumbe** katika mteja kushughulikia arifa.
4. **Fanya majaribio ya ulinganifu** na zana na njia za kazi zilizopo.

### Kudumisha Ulinganifu

Inashauriwa kudumisha ulinganifu na wateja wa SSE waliopo wakati wa mchakato wa mabadiliko. Hapa kuna mikakati:

- Unaweza kuunga mkono SSE na Streamable HTTP kwa kuendesha usafirishaji wote kwenye sehemu tofauti.
- Polepole hamisha wateja kwenye usafirishaji mpya.

### Changamoto

Hakikisha unashughulikia changamoto zifuatazo wakati wa mabadiliko:

- Kuhakikisha wateja wote wameboreshwa
- Kushughulikia tofauti katika utoaji wa arifa

### Zoeezi: Jenga Programu Yako ya MCP Inayoweza Kusambazwa

**Hali:**
Jenga seva na mteja wa MCP ambapo seva inashughulikia orodha ya vitu (mfano, faili au nyaraka) na kutuma arifa kwa kila kipengele kinachoshughulikiwa. Mteja aonyeshe kila arifa anapopokea.

**Hatua:**

1. Tekeleza zana ya seva inayoshughulikia orodha na kutuma arifa kwa kila kipengele.
2. Tekeleza mteja mwenye mshughulikiaji wa ujumbe kuonyesha arifa kwa wakati halisi.
3. Jaribu utekelezaji wako kwa kuendesha seva na mteja, kisha angalia arifa.

[Solution](./solution/README.md)

## Kusoma Zaidi & Hatua Zifuatazo

Ili kuendelea na safari yako na MCP streaming na kupanua maarifa yako, sehemu hii inatoa rasilimali za ziada na mapendekezo ya hatua zinazofuata za kujenga programu za hali ya juu zaidi.

### Kusoma Zaidi

- [Microsoft: Utangulizi wa HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS katika ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Maombi ya Usambazaji](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Hatua Zifuatazo

- Jaribu kujenga zana za MCP za hali ya juu zinazotumia usambazaji kwa uchambuzi wa wakati halisi, mazungumzo, au uhariri wa pamoja.
- Chunguza kuunganisha MCP streaming na mifumo ya mbele (React, Vue, n.k.) kwa masasisho ya moja kwa moja ya UI.
- Ifuatayo: [Kutumia AI Toolkit kwa VSCode](../07-aitk/README.md)

**Kisahafu**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au kasoro. Nyaraka asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha kuaminika. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na watu inashauriwa. Hatubebeki dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.