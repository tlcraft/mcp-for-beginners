<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0eb9557780cd0a2551cdb8a16c886b51",
  "translation_date": "2025-06-17T16:05:56+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "sw"
}
-->
Tuweze kuzungumza zaidi kuhusu jinsi tunavyotumia kiolesura cha kuona katika sehemu zinazofuata.

## Njia

Hivi ndivyo tunavyopaswa kuishughulikia kwa kiwango cha juu:

- Sanidi faili ili kutafuta MCP Server yetu.
- Anzisha/Unganisha kwa server hiyo ili iweze kuorodhesha uwezo wake.
- Tumia uwezo huo kupitia kiolesura cha GitHub Copilot Chat.

Nzuri, sasa tunapoelewa mtiririko, hebu tujifunze kutumia MCP Server kupitia Visual Studio Code kwa mazoezi.

## Mazoezi: Kutumia server

Katika zoezi hili, tutaweka Visual Studio Code ili itafute MCP server yako ili iweze kutumika kupitia kiolesura cha GitHub Copilot Chat.

### -0- Hatua ya awali, wezesha ugunduzi wa MCP Server

Huenda unahitaji kuwezesha ugunduzi wa MCP Servers.

1. Nenda `File -> Preferences -> Settings` in Visual Studio Code.

1. Search for "MCP" and enable `chat.mcp.discovery.enabled` katika faili ya settings.json.

### -1- Tengeneza faili ya usanidi

Anza kwa kutengeneza faili ya usanidi katika mzizi wa mradi wako, utahitaji faili iitwayo MCP.json na kuiweka kwenye folda iitwayo .vscode. Inapaswa kuonekana kama ifuatavyo:

```text
.vscode
|-- mcp.json
```

Sasa, tazama jinsi tunavyoweza kuongeza kipengele cha server.

### -2- Sanidi server

Ongeza maudhui yafuatayo kwenye *mcp.json*:

```json
{
    "inputs": [],
    "servers": {
       "hello-mcp": {
           "command": "node",
           "args": [
               "build/index.js"
           ]
       }
    }
}
```

Huu ni mfano rahisi wa jinsi ya kuanzisha server iliyotengenezwa kwa Node.js, kwa runtimes nyingine eleza amri sahihi ya kuanzisha server kwa kutumia `command` and `args`.

### -3- Anzisha server

Sasa umeongeza kipengele, hebu anzisha server:

1. Tafuta kipengele chako katika *mcp.json* na hakikisha unaona ikoni ya "play":

  ![Kuanzisha server katika Visual Studio Code](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.sw.png)  

1. Bonyeza ikoni ya "play", utapona ikoni ya zana katika GitHub Copilot Chat kuongeza idadi ya zana zinazopatikana. Ukibonyeza ikoni hiyo ya zana, utaona orodha ya zana zilizosajiliwa. Unaweza kuchagua/kutoa alama kwa kila zana kulingana na kama unataka GitHub Copilot izitumia kama muktadha:

  ![Kuanzisha server katika Visual Studio Code](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.sw.png)

1. Kuendesha zana, andika ombi ambalo unajua litaendana na maelezo ya moja ya zana zako, kwa mfano ombi kama "ongeza 22 kwa 1":

  ![Kuendesha zana kutoka GitHub Copilot](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.sw.png)

  Unapaswa kuona jibu linasema 23.

## Kazi ya nyumbani

Jaribu kuongeza kipengele cha server kwenye faili yako *mcp.json* na hakikisha unaweza kuanzisha/kusitisha server. Hakikisha pia unaweza kuwasiliana na zana kwenye server yako kupitia kiolesura cha GitHub Copilot Chat.

## Suluhisho

[Solution](./solution/README.md)

## Muhimu Kukumbuka

Mambo muhimu ya kuchukua kutoka sura hii ni yafuatayo:

- Visual Studio Code ni mteja mzuri unaokuwezesha kutumia MCP Servers mbalimbali na zana zao.
- Kiolesura cha GitHub Copilot Chat ndicho unachotumia kuwasiliana na servers.
- Unaweza kumuomba mtumiaji kuingiza vitu kama API keys ambazo zinaweza kupitishwa kwa MCP Server wakati wa kusanidi kipengele cha server katika faili ya *mcp.json*.

## Sampuli

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Rasilimali Zaidi

- [Visual Studio docs](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Kile Kinachofuata

- Ifuatayo: [Kuunda SSE Server](/03-GettingStarted/05-sse-server/README.md)

**Tangazo la Kukataa**:  
Nyaraka hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuhakikisha usahihi, tafadhali fahamu kwamba tafsiri za moja kwa moja zinaweza kuwa na makosa au upungufu wa usahihi. Nyaraka ya asili katika lugha yake ya asili inapaswa kuzingatiwa kama chanzo halali. Kwa taarifa muhimu, tafsiri ya kitaalamu ya binadamu inapendekezwa. Hatubeba dhamana yoyote kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.