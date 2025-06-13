<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a0acf3093691b1cfcc008a8c6648ea26",
  "translation_date": "2025-06-13T06:50:26+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "tl"
}
-->
Sa naunang code ginawa natin ang mga sumusunod:

- In-import ang mga libraries
- Gumawa ng instance ng client at ikinonekta ito gamit ang stdio bilang transport.
- Nilista ang prompts, resources, at tools at tinawag ang mga ito lahat.

Ayan, may client ka na na kayang makipag-usap sa isang MCP Server.

Maglalaan tayo ng oras sa susunod na bahagi ng ehersisyo para himayin ang bawat bahagi ng code at ipaliwanag kung ano ang nangyayari.

## Ehersisyo: Pagsusulat ng client

Gaya ng sinabi kanina, maglalaan tayo ng oras sa pagpapaliwanag ng code, at kung gusto mo, sabayan mo rin ng pag-code.

### -1- Pag-import ng mga library

I-import natin ang mga kailangang library, kakailanganin natin ng mga reference sa client at sa napiling transport protocol, ang stdio. Ang stdio ay isang protocol para sa mga bagay na tatakbo sa iyong lokal na makina. Ang SSE ay isa pang transport protocol na ipapakita natin sa mga susunod na kabanata ngunit ito ang isa pang opsyon mo. Sa ngayon, magpapatuloy tayo gamit ang stdio.

### -2- Pag-instansya ng client at transport

Kailangan nating gumawa ng instance ng transport at ng client natin:

### -3- Paglilista ng mga tampok ng server

Ngayon, may client na tayo na kayang kumonekta kapag pinaandar ang programa. Ngunit hindi pa nito nililista ang mga tampok nito kaya gawin natin iyon ngayon:

Maganda, nakuha na natin lahat ng mga tampok. Ngayon, kailan ba natin ito gagamitin? Ang client na ito ay medyo simple, ibig sabihin kailangan nating tawagin nang tahasan ang mga tampok kapag gusto natin silang gamitin. Sa susunod na kabanata, gagawa tayo ng mas advanced na client na may access sa sarili nitong malaking language model, LLM. Sa ngayon, tingnan muna natin kung paano tawagin ang mga tampok sa server:

### -4- Pagtawag sa mga tampok

Para tawagin ang mga tampok, kailangan nating siguraduhin na tama ang mga argumentong ibibigay at sa ilang kaso, ang pangalan ng tinatawag natin.

### -5- Pagpapatakbo ng client

Para patakbuhin ang client, i-type ang sumusunod na utos sa terminal:

## Assignment

Sa assignment na ito, gagamitin mo ang mga natutunan mo sa paggawa ng client pero gagawa ka ng sarili mong client.

Narito ang isang server na maaari mong gamitin na kailangang tawagin gamit ang iyong client code, subukan mong magdagdag ng mas maraming tampok sa server para maging mas interesante ito.

## Solution

[Solution](./solution/README.md)

## Mga Pangunahing Natutunan

Ang mga pangunahing natutunan sa kabanatang ito tungkol sa mga client ay:

- Maaaring gamitin upang tuklasin at tawagin ang mga tampok sa server.
- Maaaring mag-umpisa ng server habang nagsisimula rin ang client (gaya ng sa kabanatang ito) pero maaari ring kumonekta ang client sa mga tumatakbong server.
- Isang mahusay na paraan upang subukan ang kakayahan ng server katabi ng mga alternatibo tulad ng Inspector na ipinaliwanag sa nakaraang kabanata.

## Karagdagang Mga Sanggunian

- [Pagbuo ng mga client sa MCP](https://modelcontextprotocol.io/quickstart/client)

## Mga Halimbawa

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Ano ang Susunod

- Susunod: [Paggawa ng client gamit ang LLM](/03-GettingStarted/03-llm-client/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o kamalian. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.