<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1681ca3633aeb49ee03766abdbb94a93",
  "translation_date": "2025-06-17T22:23:11+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "tl"
}
-->
Ngayon na alam na natin nang kaunti pa tungkol sa SSE, gawin natin ang isang SSE server.

## Ehersisyo: Paglikha ng SSE Server

Para makagawa ng server, kailangan nating tandaan ang dalawang bagay:

- Kailangan nating gumamit ng web server para ilantad ang mga endpoint para sa koneksyon at mga mensahe.
- Gawin ang server tulad ng dati gamit ang mga tools, resources, at prompts na ginamit natin noong gumagamit pa tayo ng stdio.

### -1- Gumawa ng server instance

Para gumawa ng server, gagamitin natin ang parehong mga uri tulad ng sa stdio. Ngunit, para sa transport, kailangan nating piliin ang SSE.

---

Idagdag naman natin ang mga kinakailangang ruta.

### -2- Magdagdag ng mga ruta

Idagdag natin ang mga ruta na humahawak sa koneksyon at mga papasok na mensahe:

---

Idagdag naman natin ang mga kakayahan ng server.

### -3- Pagdaragdag ng mga kakayahan ng server

Ngayon na naitakda na natin ang lahat ng bagay na partikular sa SSE, idagdag natin ang mga kakayahan ng server tulad ng mga tools, prompts, at resources.

---

Ang buong code mo ay dapat ganito ang hitsura:

---

Magaling, mayroon na tayong server gamit ang SSE, subukan natin ito ngayon.

## Ehersisyo: Pag-debug ng SSE Server gamit ang Inspector

Ang Inspector ay isang mahusay na tool na nakita natin sa nakaraang aralin [Paglikha ng iyong unang server](/03-GettingStarted/01-first-server/README.md). Tingnan natin kung magagamit din natin ang Inspector dito:

### -1- Pagpapatakbo ng inspector

Para patakbuhin ang inspector, kailangan mo munang patakbuhin ang SSE server, kaya gawin muna natin iyon:

1. Patakbuhin ang server

---

1. Patakbuhin ang inspector

    > ![NOTE]
    > Patakbuhin ito sa hiwalay na terminal window mula sa window kung saan tumatakbo ang server. Tandaan din, kailangan mong i-adjust ang command sa ibaba upang tumugma sa URL kung saan tumatakbo ang iyong server.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Pareho lang ang hitsura ng pagpapatakbo ng inspector sa lahat ng runtimes. Pansinin na sa halip na ipasa ang path ng server at command para simulan ang server, ipinapasa natin ang URL kung saan tumatakbo ang server at tinutukoy din natin ang ruta na `/sse`.

### -2- Pagsubok ng tool

Ikonekta ang server sa pamamagitan ng pagpili ng SSE sa droplist at punan ang url field kung saan tumatakbo ang iyong server, halimbawa http:localhost:4321/sse. Ngayon, i-click ang "Connect" button. Tulad ng dati, piliin ang listahan ng mga tools, pumili ng tool at magbigay ng input values. Dapat kang makakita ng resulta tulad ng nasa ibaba:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.tl.png)

Magaling, kaya mong gumamit ng inspector, tingnan natin kung paano tayo gagamit ng Visual Studio Code.

## Takdang-Aralin

Subukang palawakin ang iyong server gamit ang higit pang mga kakayahan. Tingnan ang [pahina na ito](https://api.chucknorris.io/) para, halimbawa, magdagdag ng tool na tumatawag sa isang API. Ikaw ang magpapasya kung ano ang magiging itsura ng server. Mag-enjoy :)

## Solusyon

[Solusyon](./solution/README.md) Narito ang posibleng solusyon na may gumaganang code.

## Pangunahing Mga Aral

Ang mga pangunahing aral mula sa kabanatang ito ay ang mga sumusunod:

- Ang SSE ang pangalawang suportadong transport maliban sa stdio.
- Para suportahan ang SSE, kailangan mong pamahalaan ang mga papasok na koneksyon at mga mensahe gamit ang isang web framework.
- Maaari mong gamitin ang parehong Inspector at Visual Studio Code para gamitin ang SSE server, tulad ng sa stdio servers. Pansinin ang kaunting pagkakaiba sa pagitan ng stdio at SSE. Para sa SSE, kailangan mong patakbuhin ang server nang hiwalay bago patakbuhin ang iyong inspector tool. Para sa inspector tool, may ilang pagkakaiba rin sa kailangan mong tukuyin ang URL.

## Mga Halimbawa

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Karagdagang Mga Mapagkukunan

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Ano ang Susunod

- Susunod: [HTTP Streaming gamit ang MCP (Streamable HTTP)](/03-GettingStarted/06-http-streaming/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang serbisyong AI na pagsasalin na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagama't nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pinagmumulan ng tama at opisyal. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasaling-tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.