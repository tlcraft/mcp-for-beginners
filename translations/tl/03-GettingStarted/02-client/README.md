<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4cc245e2f4ea5db5e2b8c2cd1dadc4b4",
  "translation_date": "2025-07-04T18:19:02+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "tl"
}
-->
Sa naunang code, ginawa natin ang mga sumusunod:

- In-import ang mga library
- Gumawa ng instance ng client at kinonekta ito gamit ang stdio para sa transport.
- Nilista ang mga prompt, resources, at tools at tinawag ang mga ito lahat.

Ayan, may client ka na na kayang makipag-usap sa isang MCP Server.

Maglalaan tayo ng oras sa susunod na bahagi ng ehersisyo para himayin ang bawat bahagi ng code at ipaliwanag kung ano ang nangyayari.

## Ehersisyo: Pagsusulat ng client

Tulad ng sinabi sa itaas, maglaan tayo ng oras sa pagpapaliwanag ng code, at kung gusto mo, sabayan mo rin ang pag-code.

### -1- Pag-import ng mga library

I-import natin ang mga library na kailangan natin, kakailanganin natin ng mga reference sa client at sa napiling transport protocol, ang stdio. Ang stdio ay isang protocol para sa mga bagay na tatakbo sa iyong lokal na makina. Ang SSE ay isa pang transport protocol na ipapakita natin sa mga susunod na kabanata ngunit iyon ang isa pang opsyon mo. Sa ngayon, magpatuloy muna tayo gamit ang stdio.

### -2- Paglikha ng instance ng client at transport

Kailangan nating gumawa ng instance ng transport at ng ating client:

### -3- Paglilista ng mga tampok ng server

Ngayon, may client na tayo na kayang kumonekta kapag pinatakbo ang programa. Gayunpaman, hindi pa nito nililista ang mga tampok nito kaya gawin natin iyon ngayon:

Maganda, nakuha na natin lahat ng mga tampok. Ngayon, kailan natin ito gagamitin? Simple lang ang client na ito, ibig sabihin kailangan nating tawagin nang tahasan ang mga tampok kapag gusto natin silang gamitin. Sa susunod na kabanata, gagawa tayo ng mas advanced na client na may access sa sarili nitong malaking language model, LLM. Sa ngayon, tingnan natin kung paano tawagin ang mga tampok sa server:

### -4- Pagtawag sa mga tampok

Para tawagin ang mga tampok, kailangan nating tiyakin na tama ang mga argumento at sa ilang kaso ang pangalan ng tinatawag natin.

### -5- Patakbuhin ang client

Para patakbuhin ang client, i-type ang sumusunod na utos sa terminal:

## Takdang-Aralin

Sa takdang-aralin na ito, gagamitin mo ang mga natutunan mo sa paggawa ng client pero gagawa ka ng sarili mong client.

Narito ang isang server na maaari mong gamitin na kailangan mong tawagan gamit ang iyong client code, tingnan kung kaya mong magdagdag ng mas maraming tampok sa server para maging mas kawili-wili ito.

## Solusyon

[Solusyon](./solution/README.md)

## Mahahalagang Punto

Ang mga mahahalagang punto para sa kabanatang ito tungkol sa mga client ay ang mga sumusunod:

- Maaari itong gamitin upang tuklasin at tawagin ang mga tampok sa server.
- Maaari itong magsimula ng server habang nagsisimula rin ito (tulad sa kabanatang ito) ngunit ang mga client ay maaari ring kumonekta sa mga tumatakbong server.
- Isang mahusay na paraan upang subukan ang mga kakayahan ng server kasabay ng mga alternatibo tulad ng Inspector na ipinaliwanag sa nakaraang kabanata.

## Karagdagang Mga Mapagkukunan

- [Paggawa ng mga client sa MCP](https://modelcontextprotocol.io/quickstart/client)

## Mga Halimbawa

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Ano ang Susunod

- Susunod: [Paggawa ng client na may LLM](../03-llm-client/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.