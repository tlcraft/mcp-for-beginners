<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d90ca3d326c48fab2ac0ebd3a9876f59",
  "translation_date": "2025-07-13T19:59:40+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "tl"
}
-->
Ngayon na may kaunting kaalaman na tayo tungkol sa SSE, gawin naman natin ang isang SSE server.

## Ehersisyo: Paggawa ng SSE Server

Para gumawa ng server, kailangan nating tandaan ang dalawang bagay:

- Kailangan nating gumamit ng web server para ipakita ang mga endpoint para sa koneksyon at mga mensahe.
- Gawin ang server tulad ng dati gamit ang mga tools, resources, at prompts na ginamit natin noong gumagamit pa tayo ng stdio.

### -1- Gumawa ng server instance

Para gumawa ng server, gagamitin natin ang parehong mga uri tulad ng sa stdio. Ngunit, para sa transport, kailangan nating piliin ang SSE.

### -2- Magdagdag ng mga ruta

Magdagdag tayo ng mga ruta na humahawak sa koneksyon at mga papasok na mensahe:

### -3- Magdagdag ng kakayahan sa server

Ngayon na naitakda na natin ang lahat ng partikular sa SSE, idagdag naman natin ang mga kakayahan ng server tulad ng mga tools, prompts, at resources.

Ang buong code mo ay dapat ganito ang hitsura:

Magaling, mayroon na tayong server gamit ang SSE, subukan naman natin ito.

## Ehersisyo: Pag-debug ng SSE Server gamit ang Inspector

Ang Inspector ay isang mahusay na tool na nakita natin sa nakaraang aralin [Paglikha ng iyong unang server](/03-GettingStarted/01-first-server/README.md). Tingnan natin kung magagamit din natin ang Inspector dito:

### -1- Pagpapatakbo ng inspector

Para patakbuhin ang inspector, kailangan mo munang patakbuhin ang SSE server, kaya gawin natin iyon:

1. Patakbuhin ang server

1. Patakbuhin ang inspector

    > ![NOTE]
    > Patakbuhin ito sa hiwalay na terminal window mula sa pinapatakbuhan ng server. Tandaan din, kailangan mong i-adjust ang command sa ibaba upang umangkop sa URL kung saan tumatakbo ang iyong server.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Ang pagpapatakbo ng inspector ay pareho sa lahat ng runtime. Pansinin na sa halip na magpasa ng path sa server at command para simulan ang server, ipinapasa natin ang URL kung saan tumatakbo ang server at tinutukoy din natin ang ruta na `/sse`.

### -2- Pagsubok sa tool

Ikonekta ang server sa pamamagitan ng pagpili ng SSE sa droplist at punan ang url field kung saan tumatakbo ang iyong server, halimbawa http:localhost:4321/sse. Ngayon, i-click ang "Connect" button. Tulad ng dati, piliin ang listahan ng mga tools, pumili ng tool at magbigay ng mga input na halaga. Dapat kang makakita ng resulta tulad ng nasa ibaba:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.tl.png)

Magaling, nagawa mong gamitin ang inspector, tingnan natin kung paano gamitin ang Visual Studio Code.

## Takdang Aralin

Subukang palawakin ang iyong server ng mas maraming kakayahan. Tingnan ang [pahina na ito](https://api.chucknorris.io/) para, halimbawa, magdagdag ng tool na tumatawag ng API. Ikaw ang magpapasya kung ano ang hitsura ng server. Mag-enjoy :)

## Solusyon

[Solusyon](./solution/README.md) Narito ang isang posibleng solusyon na may gumaganang code.

## Mahahalagang Punto

Ang mga mahahalagang punto mula sa kabanatang ito ay ang mga sumusunod:

- Ang SSE ang pangalawang suportadong transport maliban sa stdio.
- Para suportahan ang SSE, kailangan mong pamahalaan ang mga papasok na koneksyon at mga mensahe gamit ang web framework.
- Maaari mong gamitin ang parehong Inspector at Visual Studio Code para gamitin ang SSE server, tulad ng mga stdio server. Pansinin ang kaunting pagkakaiba sa pagitan ng stdio at SSE. Para sa SSE, kailangan mong patakbuhin ang server nang hiwalay at saka patakbuhin ang iyong inspector tool. Para sa inspector tool, may ilang pagkakaiba rin na kailangan mong tukuyin ang URL.

## Mga Halimbawa

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Karagdagang Mga Mapagkukunan

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Ano ang Susunod

- Susunod: [HTTP Streaming gamit ang MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa kanyang sariling wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.