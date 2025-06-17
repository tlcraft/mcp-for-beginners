<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T22:23:22+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "sw"
}
-->
# Uchezaji wa HTTPS kwa Protokoli ya Muktadha wa Mfano (MCP)

Sura hii inatoa mwongozo kamili wa kutekeleza uchezaji salama, unaoweza kupanuka, na wa wakati halisi kwa kutumia Protokoli ya Muktadha wa Mfano (MCP) kwa kutumia HTTPS. Inajumuisha sababu za uchezaji, mifumo ya usafirishaji inayopatikana, jinsi ya kutekeleza HTTP inayoweza kuchezwa katika MCP, mbinu bora za usalama, uhamisho kutoka SSE, na mwongozo wa vitendo wa kujenga programu zako za MCP zinazocheza.

## Mifumo ya Usafirishaji na Uchezaji katika MCP

Sehemu hii inachunguza mifumo tofauti ya usafirishaji inayopatikana katika MCP na nafasi yake katika kuwezesha uwezo wa uchezaji kwa mawasiliano ya wakati halisi kati ya wateja na seva.

### Nini maana ya Mfumo wa Usafirishaji?

Mfumo wa usafirishaji unaeleza jinsi data inavyobadilishana kati ya mteja na seva. MCP inaunga mkono aina mbalimbali za usafirishaji ili kufaa mazingira na mahitaji tofauti:

- **stdio**: Ingizo/tokwa la kawaida, linafaa kwa zana za eneo la kazi na zile zinazotumia CLI. Rahisi lakini halifai kwa wavuti au wingu.
- **SSE (Server-Sent Events)**: Inaruhusu seva kusukuma masasisho ya wakati halisi kwa wateja kupitia HTTP. Inafaa kwa interface za wavuti, lakini ina mipaka katika upanuzi na kubadilika.
- **Streamable HTTP**: Usafirishaji wa kisasa wa uchezaji unaotegemea HTTP, unaounga mkono taarifa na upanuzi bora. Inapendekezwa kwa hali nyingi za uzalishaji na wingu.

### Jedwali la Mlinganifu

Angalia jedwali la mlinganifu hapa chini kuelewa tofauti kati ya mifumo hii ya usafirishaji:

| Usafirishaji     | Masasisho ya Wakati Halisi | Uchezaji | Upanuzi | Matumizi                   |
|------------------|----------------------------|----------|---------|----------------------------|
| stdio            | Hapana                     | Hapana   | Chini   | Zana za eneo la kazi CLI   |
| SSE              | Ndiyo                      | Ndiyo    | Kati    | Wavuti, masasisho ya wakati halisi |
| Streamable HTTP  | Ndiyo                      | Ndiyo    | Juu     | Wingu, wateja wengi        |

> **Tip:** Kuchagua usafirishaji sahihi huathiri utendaji, upanuzi, na uzoefu wa mtumiaji. **Streamable HTTP** inapendekezwa kwa programu za kisasa, zinazopanuka, na zinazofaa kwa wingu.

Tambua mifumo ya usafirishaji stdio na SSE ulioonyeshwa katika sura zilizopita na jinsi Streamable HTTP inavyoshughulikiwa katika sura hii.

## Uchezaji: Dhana na Sababu

Kuelewa dhana za msingi na sababu za uchezaji ni muhimu kwa kutekeleza mifumo madhubuti ya mawasiliano ya wakati halisi.

**Uchezaji** ni mbinu katika programu za mtandao inayoruhusu data kutumwa na kupokelewa kwa vipande vidogo vinavyoweza kudhibitiwa au kama mfululizo wa matukio, badala ya kusubiri majibu yote kuwa tayari. Hii ni muhimu hasa kwa:

- Faili kubwa au seti za data.
- Masasisho ya wakati halisi (mfano, mazungumzo, vipimo vya maendeleo).
- Hesabu za muda mrefu ambapo unataka mtumiaji afahamishwe mara kwa mara.

Hapa ni mambo muhimu unayopaswa kuyajua kuhusu uchezaji kwa kiwango cha juu:

- Data hutolewa kwa hatua, si mara moja.
- Mteja anaweza kushughulikia data anapopokea.
- Hupunguza ucheleweshaji unaoonekana na kuboresha uzoefu wa mtumiaji.

### Kwa nini tumia uchezaji?

Sababu za kutumia uchezaji ni zifuatazo:

- Watumiaji wanapata mrejesho mara moja, si tu mwishoni
- Huwezesha programu za wakati halisi na interface zinazojibu haraka
- Matumizi bora ya rasilimali za mtandao na kompyuta

### Mfano Rahisi: Seva na Mteja wa Uchezaji wa HTTP

Hapa kuna mfano rahisi wa jinsi uchezaji unavyoweza kutekelezwa:

<details>
<summary>Python</summary>

**Seva (Python, ikitumia FastAPI na StreamingResponse):**
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

**Mteja (Python, ikitumia requests):**
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

Mfano huu unaonyesha seva ikituma mfululizo wa ujumbe kwa mteja anapopatikana, badala ya kusubiri ujumbe wote kuwa tayari.

**Jinsi inavyofanya kazi:**
- Seva hutuma kila ujumbe linapokuwa tayari.
- Mteja anapokea na kuchapisha kila kipande anapopokea.

**Mahitaji:**
- Seva inapaswa kutumia majibu ya uchezaji (mfano, `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) badala ya kuchagua uchezaji kupitia MCP.

- **Kwa mahitaji rahisi ya uchezaji:** Uchezaji wa HTTP wa kawaida ni rahisi kutekeleza na unatosha kwa mahitaji ya msingi.

- **Kwa programu tata na za mwingiliano:** Uchezaji wa MCP hutoa njia yenye muundo zaidi yenye metadata tajiri na utofauti kati ya taarifa na matokeo ya mwisho.

- **Kwa programu za AI:** Mfumo wa taarifa wa MCP ni muhimu hasa kwa kazi za AI za muda mrefu ambapo unataka kuwajulisha watumiaji maendeleo.

## Uchezaji katika MCP

Sawa, umeona mapendekezo na mlinganisho kuhusu tofauti kati ya uchezaji wa kawaida na uchezaji katika MCP. Hebu tuchunguze kwa undani jinsi unavyoweza kutumia uchezaji katika MCP.

Kuelewa jinsi uchezaji unavyofanya kazi ndani ya mfumo wa MCP ni muhimu kwa kujenga programu zinazojibu haraka na kutoa mrejesho wa wakati halisi kwa watumiaji wakati wa shughuli za muda mrefu.

Katika MCP, uchezaji sio kutuma jibu kuu kwa vipande, bali ni kutuma **taarifa** kwa mteja wakati zana inashughulikia ombi. Taarifa hizi zinaweza kujumuisha masasisho ya maendeleo, kumbukumbu, au matukio mengine.

### Jinsi inavyofanya kazi

Matokeo makuu bado hutumwa kama jibu moja. Hata hivyo, taarifa zinaweza kutumwa kama ujumbe tofauti wakati wa usindikaji na hivyo kusasisha mteja kwa wakati halisi. Mteja lazima aweze kushughulikia na kuonyesha taarifa hizi.

## Nini maana ya Taarifa?

Tulisema "Taarifa", maana yake ni nini katika muktadha wa MCP?

Taarifa ni ujumbe unaotumwa kutoka seva kwenda kwa mteja ili kumjulisha kuhusu maendeleo, hali, au matukio mengine wakati wa operesheni ya muda mrefu. Taarifa huboresha uwazi na uzoefu wa mtumiaji.

Kwa mfano, mteja anapaswa kutuma taarifa mara baada ya mkutano wa awali na seva kufanyika.

Taarifa inaonekana kama ujumbe wa JSON kama ifuatavyo:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Taarifa zinahusiana na mada katika MCP inayojulikana kama ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Ili kufanikisha uandishi wa kumbukumbu, seva inahitaji kuwezesha kipengele hiki kama sifa/kifaa kama ifuatavyo:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Kutegemea SDK inayotumika, uandishi wa kumbukumbu unaweza kuwa umewezeshwa kwa chaguo-msingi, au unaweza kuhitaji kuuwezesha waziwazi katika usanidi wa seva yako.

Kuna aina tofauti za taarifa:

| Kiwango    | Maelezo                      | Mfano wa Matumizi             |
|------------|------------------------------|------------------------------|
| debug      | Maelezo ya kina ya utambuzi   | Mambo ya kuingia/kuondoka kwenye kazi |
| info       | Ujumbe wa taarifa za jumla    | Masasisho ya maendeleo ya operesheni  |
| notice     | Matukio ya kawaida lakini muhimu | Mabadiliko ya usanidi         |
| warning    | Hali za onyo                  | Matumizi ya kipengele kilichokatwa |
| error      | Hali za makosa               | Kushindwa kwa operesheni      |
| critical   | Hali za dharura              | Kushindwa kwa sehemu ya mfumo |
| alert      | Hatua lazima zichukuliwe mara moja | Kugunduliwa kwa uharibifu wa data |
| emergency  | Mfumo hauwezi kutumika        | Kushindwa kabisa kwa mfumo   |

## Kutekeleza Taarifa katika MCP

Ili kutekeleza taarifa katika MCP, unahitaji kuandaa pande zote za seva na mteja kushughulikia masasisho ya wakati halisi. Hii inaruhusu programu yako kutoa mrejesho wa papo hapo kwa watumiaji wakati wa shughuli za muda mrefu.

### Seva: Kutuma Taarifa

Tuanze na upande wa seva. Katika MCP, unaeleza zana zinazoweza kutuma taarifa wakati wa kushughulikia maombi. Seva hutumia kitu cha muktadha (kawaida `ctx`) kutuma ujumbe kwa mteja.

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

### Mteja: Kupokea Taarifa

Mteja lazima aweke utekelezaji wa mpokeaji wa ujumbe kushughulikia na kuonyesha taarifa zinapofika.

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

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) na mteja wako anatekeleza mpokeaji wa ujumbe kushughulikia taarifa.

## Taarifa za Maendeleo na Matukio

Sehemu hii inaelezea dhana ya taarifa za maendeleo katika MCP, kwanini ni muhimu, na jinsi ya kuzitekeleza kwa kutumia Streamable HTTP. Pia utapata zoezi la vitendo kuthibitisha uelewa wako.

Taarifa za maendeleo ni ujumbe wa wakati halisi unaotumwa kutoka seva kwenda kwa mteja wakati wa shughuli za muda mrefu. Badala ya kusubiri mchakato mzima kumalizika, seva inaendelea kuwajulisha wateja kuhusu hali ya sasa. Hii huboresha uwazi, uzoefu wa mtumiaji, na kurahisisha utambuzi wa matatizo.

**Mfano:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Kwa nini tumia Taarifa za Maendeleo?

Taarifa za maendeleo ni muhimu kwa sababu kadhaa:

- **Uzoefu bora wa mtumiaji:** Watumiaji wanaona masasisho wanapofanya kazi, si tu mwishoni.
- **Mrejesho wa wakati halisi:** Wateja wanaweza kuonyesha vipimo vya maendeleo au kumbukumbu, kufanya programu ionekane inayojibu.
- **Rahisi kutambua matatizo na kufuatilia:** Waendelezaji na watumiaji wanaweza kuona sehemu gani ya mchakato inaweza kuwa polepole au imekwama.

### Jinsi ya Kutekeleza Taarifa za Maendeleo

Hapa ni jinsi unavyoweza kutekeleza taarifa za maendeleo katika MCP:

- **Kwenye seva:** Tumia `ctx.info()` or `ctx.log()` kutuma taarifa kila kipengele kinaposhughulikiwa. Hii hutuma ujumbe kwa mteja kabla ya matokeo kuu kuwa tayari.
- **Kwenye mteja:** Tekeleza mpokeaji wa ujumbe unaosikiliza na kuonyesha taarifa zinapofika. Mpokeaji huyu hutofautisha kati ya taarifa na matokeo ya mwisho.

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

## Masuala ya Usalama

Unapotekeleza seva za MCP kwa usafirishaji wa HTTP, usalama unakuwa jambo la msingi linalohitaji umakini mkubwa kwa njia mbalimbali za mashambulizi na mbinu za ulinzi.

### Muhtasari

Usalama ni muhimu unapoonyesha seva za MCP kupitia HTTP. Streamable HTTP inaleta maeneo mapya ya mashambulizi na inahitaji usanidi makini.

### Vidokezo Muhimu
- **Uthibitishaji wa Kichwa cha Origin**: Daima thibitisha `Origin` header to prevent DNS rebinding attacks.
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
3. **Tekeleza mpokeaji wa ujumbe** katika mteja kushughulikia taarifa.
4. **Jaribu ushirikiano** na zana na njia za kazi zilizopo.

### Kudumisha Ushirikiano

Inapendekezwa kudumisha ushirikiano na wateja wa SSE waliopo wakati wa mchakato wa uhamisho. Hapa kuna mikakati:

- Unaweza kuunga mkono SSE na Streamable HTTP kwa kuendesha mifumo yote miwili kwenye anwani tofauti.
- Polepole hamisha wateja kwenda kwenye usafirishaji mpya.

### Changamoto

Hakikisha unashughulikia changamoto zifuatazo wakati wa uhamisho:

- Kuhakikisha wateja wote wanapokea masasisho
- Kushughulikia tofauti katika utoaji wa taarifa

### Zozi: Jenga Programu Yako ya Uchezaji ya MCP

**Hali:**
Jenga seva na mteja wa MCP ambapo seva inashughulikia orodha ya vitu (mfano, faili au nyaraka) na kutuma taarifa kwa kila kipengele kinachoshughulikiwa. Mteja anapaswa kuonyesha kila taarifa inaporudi.

**Hatua:**

1. Tekeleza zana ya seva inayoshughulikia orodha na kutuma taarifa kwa kila kipengele.
2. Tekeleza mteja mwenye mpokeaji wa ujumbe kuonyesha taarifa kwa wakati halisi.
3. Jaribu utekelezaji wako kwa kuendesha seva na mteja, kisha angalia taarifa zinazoonekana.

[Solution](./solution/README.md)

## Kusoma Zaidi na Nini Kifuatacho?

Ili kuendelea na safari yako na uchezaji wa MCP na kuongeza maarifa yako, sehemu hii inatoa rasilimali za ziada na hatua zinazopendekezwa za kujenga programu za hali ya juu zaidi.

### Kusoma Zaidi

- [Microsoft: Utangulizi wa Uchezaji wa HTTP](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Matukio Yanayotumwa na Seva (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS katika ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Maombi ya Uchezaji](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Nini Kifuatacho?

- Jaribu kujenga zana za MCP za hali ya juu zinazotumia uchezaji kwa uchambuzi wa wakati halisi, mazungumzo, au uhariri wa pamoja.
- Chunguza kuunganisha uchezaji wa MCP na mifumo ya mbele (React, Vue, nk) kwa masasisho ya moja kwa moja ya UI.
- Ifuatayo: [Kutumia AI Toolkit kwa VSCode](../07-aitk/README.md)

**Tangazo la Hukumu**:  
Nyaraka hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuhakikisha usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Nyaraka asilia katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo halali. Kwa taarifa muhimu, tafsiri ya kitaalamu ya binadamu inapendekezwa. Hatubebwi dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.