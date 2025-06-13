<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "64645691bf0985f1760b948123edf269",
  "translation_date": "2025-06-13T10:55:20+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "tl"
}
-->
Ngayon na may alam na tayo tungkol sa SSE, gawin natin ang isang SSE server.

## Ehersisyo: Paggawa ng SSE Server

Para gumawa ng server, kailangan nating tandaan ang dalawang bagay:

- Kailangan nating gumamit ng web server para i-expose ang mga endpoints para sa connection at mga mensahe.
- I-build ang server tulad ng karaniwan nating ginagawa gamit ang mga tools, resources, at prompts noong ginagamit pa natin ang stdio.

### -1- Gumawa ng server instance

Para gumawa ng server, gagamit tayo ng parehong mga uri tulad ng sa stdio. Ngunit, para sa transport, kailangan nating piliin ang SSE.

### -2- Magdagdag ng mga ruta

Idagdag natin ang mga ruta na humahawak sa connection at papasok na mga mensahe:

### -3- Magdagdag ng kakayahan sa server

Ngayon na na-define na natin ang lahat ng SSE-specific, idagdag natin ang mga kakayahan ng server tulad ng tools, prompts, at resources.

Dapat ganito ang hitsura ng buong code mo:

Maganda, may server na tayo gamit ang SSE, subukan natin ito.

## Ehersisyo: Pag-debug ng SSE Server gamit ang Inspector

Ang Inspector ay isang mahusay na tool na nakita natin sa nakaraang leksyon [Creating your first server](/03-GettingStarted/01-first-server/README.md). Tingnan natin kung magagamit din natin ang Inspector dito:

### -1- Pagpapatakbo ng inspector

Para patakbuhin ang inspector, kailangan mo munang patakbuhin ang SSE server, gawin natin iyon:

1. Patakbuhin ang server

1. Patakbuhin ang inspector

    > ![NOTE]
    > Patakbuhin ito sa hiwalay na terminal window mula sa kung saan tumatakbo ang server. Tandaan din, kailangan mong i-adjust ang command sa ibaba para umangkop sa URL kung saan tumatakbo ang iyong server.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Pareho lang ang hitsura ng pagpapatakbo ng inspector sa lahat ng runtime. Pansinin na sa halip na magpasa ng path sa server at command para simulan ang server, ipinapasa natin ang URL kung saan tumatakbo ang server at tinutukoy din natin ang `/sse` na ruta.

### -2- Pagsubok ng tool

Ikonekta ang server sa pagpili ng SSE sa droplist at ilagay ang url field kung saan tumatakbo ang iyong server, halimbawa http:localhost:4321/sse. Ngayon i-click ang "Connect" button. Tulad ng dati, piliin ang listahan ng mga tools, pumili ng tool at magbigay ng input values. Makikita mo ang resulta tulad ng nasa ibaba:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.tl.png)

Magaling, nagagamit mo ang inspector, tingnan natin kung paano gamitin ang Visual Studio Code.

## Takdang Aralin

Subukang palawakin ang iyong server ng mas maraming kakayahan. Tingnan ang [pahina na ito](https://api.chucknorris.io/) para halimbawa magdagdag ng tool na tumatawag sa isang API, ikaw ang magdedesisyon kung ano ang itsura ng server. Mag-enjoy :)

## Solusyon

[Solusyon](./solution/README.md) Narito ang posibleng solusyon na may gumaganang code.

## Mga Pangunahing Aral

Narito ang mga mahahalagang aral mula sa kabanatang ito:

- Ang SSE ang pangalawang suportadong transport pagkatapos ng stdio.
- Para suportahan ang SSE, kailangan mong pamahalaan ang papasok na mga koneksyon at mensahe gamit ang web framework.
- Maaari mong gamitin ang parehong Inspector at Visual Studio Code para i-consume ang SSE server, tulad ng sa stdio servers. Pansinin na may kaunting pagkakaiba sa pagitan ng stdio at SSE. Para sa SSE, kailangan mong patakbuhin muna ang server nang hiwalay bago patakbuhin ang iyong inspector tool. Sa inspector tool, may kaunting pagkakaiba rin na kailangan mong tukuyin ang URL.

## Mga Halimbawa

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Karagdagang Mga Mapagkukunan

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Ano ang Susunod

- Susunod: [HTTP Streaming with MCP (Streamable HTTP)](/03-GettingStarted/06-http-streaming/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat aming pinagsisikapang maging tumpak ang salin, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi pagkakatugma. Ang orihinal na dokumento sa kanyang orihinal na wika ang dapat ituring na opisyal na sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng salin na ito.