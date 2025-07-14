<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "222e01c3002a33355806d60d558d9429",
  "translation_date": "2025-07-14T09:40:35+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "sw"
}
-->
Tuzungumzie zaidi jinsi tunavyotumia kiolesura cha kuona katika sehemu zinazofuata.

## Mbinu

Hivi ndivyo tunavyopaswa kuishughulikia kwa kiwango cha juu:

- Sanidi faili ili kupata MCP Server yetu.
- Anzisha/Unganisha na server hiyo ili ionyeshe uwezo wake.
- Tumia uwezo huo kupitia kiolesura cha GitHub Copilot Chat.

Nzuri, sasa tunapoelewa mtiririko, hebu tujaribu kutumia MCP Server kupitia Visual Studio Code kwa mazoezi.

## Mazoezi: Kutumia server

Katika zoezi hili, tutasanidi Visual Studio Code ili ipate MCP server yako ili iweze kutumika kutoka kwenye kiolesura cha GitHub Copilot Chat.

### -0- Hatua ya awali, wezesha ugunduzi wa MCP Server

Huenda ukahitaji kuwezesha ugunduzi wa MCP Servers.

1. Nenda `File -> Preferences -> Settings` katika Visual Studio Code.

1. Tafuta "MCP" na wezesha `chat.mcp.discovery.enabled` katika faili la settings.json.

### -1- Tengeneza faili la usanidi

Anza kwa kutengeneza faili la usanidi kwenye mzizi wa mradi wako, utahitaji faili liitwalo MCP.json na uliweke kwenye folda iitwayo .vscode. Inapaswa kuonekana kama ifuatavyo:

```text
.vscode
|-- mcp.json
```

Sasa, tazama jinsi tunavyoweza kuongeza rekodi ya server.

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

Hapa juu kuna mfano rahisi wa kuanzisha server iliyoandikwa kwa Node.js, kwa runtimes nyingine taja amri sahihi ya kuanzisha server ukitumia `command` na `args`.

### -3- Anzisha server

Sasa umeongeza rekodi, hebu anzisha server:

1. Tafuta rekodi yako katika *mcp.json* na hakikisha unaona ikoni ya "play":

  ![Kuanza server katika Visual Studio Code](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.sw.png)  

1. Bonyeza ikoni ya "play", unapaswa kuona ikoni ya zana katika GitHub Copilot Chat ikiongezeka idadi ya zana zinazopatikana. Ukibonyeza ikoni hiyo ya zana, utaona orodha ya zana zilizosajiliwa. Unaweza kuchagua/kutoa alama zana yoyote kulingana na kama unataka GitHub Copilot izitumie kama muktadha:

  ![Kuanza server katika Visual Studio Code](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.sw.png)

1. Kuendesha zana, andika ombi ambalo unajua litaendana na maelezo ya moja ya zana zako, kwa mfano ombi kama "ongeza 22 kwa 1":

  ![Kuendesha zana kutoka GitHub Copilot](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.sw.png)

  Unapaswa kuona jibu linasema 23.

## Kazi ya Nyumbani

Jaribu kuongeza rekodi ya server kwenye faili lako *mcp.json* na hakikisha unaweza kuanzisha/kuzima server. Hakikisha pia unaweza kuwasiliana na zana kwenye server yako kupitia kiolesura cha GitHub Copilot Chat.

## Suluhisho

[Suluhisho](./solution/README.md)

## Muhimu Kukumbuka

Mambo muhimu ya kuchukua kutoka sura hii ni yafuatayo:

- Visual Studio Code ni mteja mzuri unaokuwezesha kutumia MCP Servers kadhaa na zana zao.
- Kiolesura cha GitHub Copilot Chat ndicho unachotumia kuwasiliana na server.
- Unaweza kumuomba mtumiaji maingizo kama funguo za API ambazo zinaweza kupitishwa kwa MCP Server wakati wa kusanidi rekodi ya server katika faili *mcp.json*.

## Sampuli

- [Kalkuleta ya Java](../samples/java/calculator/README.md)
- [Kalkuleta ya .Net](../../../../03-GettingStarted/samples/csharp)
- [Kalkuleta ya JavaScript](../samples/javascript/README.md)
- [Kalkuleta ya TypeScript](../samples/typescript/README.md)
- [Kalkuleta ya Python](../../../../03-GettingStarted/samples/python)

## Rasilimali Zaidi

- [Nyaraka za Visual Studio](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Kinachofuata

- Ifuatayo: [Kuunda SSE Server](../05-sse-server/README.md)

**Kiarifu cha Kutotegemea**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inapendekezwa. Hatubebei dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.