<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8ea28e5e566edd5969337fd0b191ba3f",
  "translation_date": "2025-07-17T10:14:30+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "sw"
}
-->
# Consuming a server from GitHub Copilot Agent mode

Visual Studio Code na GitHub Copilot vinaweza kufanya kazi kama mteja na kutumia MCP Server. Unaweza kuuliza, kwanini tungependa kufanya hivyo? Naam, hiyo inamaanisha kuwa vipengele vyote ambavyo MCP Server ina sasa vinaweza kutumika ndani ya IDE yako. Fikiria unakuongeza kwa mfano MCP server ya GitHub, hii itakuwezesha kudhibiti GitHub kupitia maelekezo badala ya kuandika amri maalum kwenye terminal. Au fikiria chochote kwa ujumla ambacho kinaweza kuboresha uzoefu wako wa maendeleo yote yakidhibitiwa kwa lugha ya asili. Sasa unaanza kuona faida, sivyo?

## Muhtasari

Somo hili linaelezea jinsi ya kutumia Visual Studio Code na GitHub Copilot Agent mode kama mteja kwa MCP Server yako.

## Malengo ya Kujifunza

Mwisho wa somo hili, utaweza:

- Kutumia MCP Server kupitia Visual Studio Code.
- Kuendesha uwezo kama zana kupitia GitHub Copilot.
- Kusanidi Visual Studio Code ili kupata na kusimamia MCP Server yako.

## Matumizi

Unaweza kudhibiti MCP server yako kwa njia mbili tofauti:

- Kiolesura cha mtumiaji, utaona jinsi hii inavyofanywa baadaye katika sura hii.
- Terminal, inawezekana kudhibiti vitu kutoka terminal kwa kutumia executable `code`:

  Kuongeza MCP server kwenye wasifu wako wa mtumiaji, tumia chaguo la amri --add-mcp, na toa usanidi wa server kwa JSON kwa namna {\"name\":\"server-name\",\"command\":...}.

  ```
  code --add-mcp "{\"name\":\"my-server\",\"command\": \"uvx\",\"args\": [\"mcp-server-fetch\"]}"
  ```

### Picha za Skrini

![Usanidi wa MCP server unaoongozwa katika Visual Studio Code](../../../../translated_images/chat-mode-agent.729a22473f822216dd1e723aaee1f7d4a2ede571ee0948037a2d9357a63b9d0b.sw.png)
![Uchaguzi wa zana kwa kila kikao cha agent](../../../../translated_images/agent-mode-select-tools.522c7ba5df0848f8f0d1e439c2e96159431bc620cb39ccf3f5dc611412fd0006.sw.png)
![Kurekebisha makosa kwa urahisi wakati wa maendeleo ya MCP](../../../../translated_images/mcp-list-servers.fce89eefe3f30032bed8952e110ab9d82fadf043fcfa071f7d40cf93fb1ea9e9.sw.png)

Tuzungumze zaidi kuhusu jinsi tunavyotumia kiolesura cha kuona katika sehemu zinazofuata.

## Mbinu

Hivi ndivyo tunavyopaswa kuishughulikia kwa kiwango cha juu:

- Sanidi faili ili kupata MCP Server yetu.
- Anzisha/unganishwa na server hiyo ili ionyeshe uwezo wake.
- Tumia uwezo huo kupitia kiolesura cha mazungumzo cha GitHub Copilot.

Nzuri, sasa tunapoelewa mtiririko, hebu tujaribu kutumia MCP Server kupitia Visual Studio Code kwa mazoezi.

## Mazoezi: Kutumia server

Katika zoezi hili, tuta sanidi Visual Studio Code ili ipate MCP server yako ili itumike kutoka kiolesura cha mazungumzo cha GitHub Copilot.

### -0- Hatua ya awali, wezesha ugunduzi wa MCP Server

Huenda ukahitaji kuwezesha ugunduzi wa MCP Servers.

1. Nenda `File -> Preferences -> Settings` katika Visual Studio Code.

1. Tafuta "MCP" na wezesha `chat.mcp.discovery.enabled` katika faili settings.json.

### -1- Tengeneza faili la usanidi

Anza kwa kutengeneza faili la usanidi kwenye mzizi wa mradi wako, utahitaji faili liitwalo MCP.json na uliweke kwenye folda iitwayo .vscode. Inapaswa kuonekana kama ifuatavyo:

```text
.vscode
|-- mcp.json
```

Sasa, tazama jinsi ya kuongeza rekodi ya server.

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

Hapa juu kuna mfano rahisi wa kuanzisha server iliyoandikwa kwa Node.js, kwa runtimes nyingine taja amri sahihi ya kuanzisha server kwa kutumia `command` na `args`.

### -3- Anzisha server

Sasa umeongeza rekodi, hebu anzisha server:

1. Tafuta rekodi yako katika *mcp.json* na hakikisha unapata ikoni ya "play":

  ![Kuanzisha server katika Visual Studio Code](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.sw.png)  

1. Bonyeza ikoni ya "play", unapaswa kuona ikoni ya zana katika GitHub Copilot Chat ikiongezeka idadi ya zana zinazopatikana. Ukibonyeza ikoni hiyo ya zana, utaona orodha ya zana zilizosajiliwa. Unaweza kuchagua/kutoa alama zana yoyote kulingana na kama unataka GitHub Copilot izitumie kama muktadha:

  ![Kuanzisha server katika Visual Studio Code](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.sw.png)

1. Kuendesha zana, andika maelekezo unayojua yataendana na maelezo ya moja ya zana zako, kwa mfano maelekezo kama "ongeza 22 kwa 1":

  ![Kuendesha zana kutoka GitHub Copilot](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.sw.png)

  Unapaswa kuona jibu linasema 23.

## Kazi ya Nyumbani

Jaribu kuongeza rekodi ya server kwenye faili lako *mcp.json* na hakikisha unaweza kuanzisha/kusitisha server. Hakikisha pia unaweza kuwasiliana na zana kwenye server yako kupitia kiolesura cha mazungumzo cha GitHub Copilot.

## Suluhisho

[Solution](./solution/README.md)

## Muhimu Kukumbuka

Mambo muhimu ya kuchukua kutoka sura hii ni yafuatayo:

- Visual Studio Code ni mteja mzuri unaokuwezesha kutumia MCP Servers kadhaa na zana zao.
- Kiolesura cha mazungumzo cha GitHub Copilot ndicho unachotumia kuwasiliana na server.
- Unaweza kumuomba mtumiaji maingizo kama funguo za API ambazo zinaweza kupitishwa kwa MCP Server wakati wa kusanidi rekodi ya server katika faili *mcp.json*.

## Sampuli

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Rasilimali Zaidi

- [Visual Studio docs](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Nini Kifuatacho

- Ifuatayo: [Creating an SSE Server](../05-sse-server/README.md)

**Kiarifu cha Msamaha**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inapendekezwa. Hatubebwi dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.