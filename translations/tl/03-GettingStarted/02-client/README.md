<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2342baa570312086fc19edcf41320250",
  "translation_date": "2025-06-17T16:04:00+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "tl"
}
-->
Sa naunang code, ginawa natin ang mga sumusunod:

- In-import ang mga library
- Gumawa ng instance ng isang client at ikinonekta ito gamit ang stdio para sa transport.
- Ipinakita ang listahan ng prompts, resources, at tools at pinatakbo ang lahat ng ito.

Ayan, may client ka na na kayang makipag-usap sa isang MCP Server.

Maglalaan tayo ng oras sa susunod na bahagi ng ehersisyo upang himayin ang bawat bahagi ng code at ipaliwanag kung ano ang nangyayari.

## Ehersisyo: Pagsusulat ng client

Gaya ng sinabi sa itaas, maglalaan tayo ng oras para ipaliwanag ang code, at malaya kang sumabay sa pag-code kung nais mo.

### -1- Pag-import ng mga library

I-import natin ang mga library na kailangan natin, kakailanganin natin ng mga reference para sa client at sa napiling transport protocol, ang stdio. Ang stdio ay isang protocol para sa mga bagay na tatakbo sa iyong lokal na makina. Ang SSE ay isa pang transport protocol na ipapakita natin sa mga susunod na kabanata pero ito ang isa mong opsyon. Sa ngayon, magpapatuloy tayo gamit ang stdio.

### -2- Paglikha ng instance ng client at transport

Kakailanganin nating gumawa ng instance ng transport at ng ating client:

### -3- Paglista ng mga tampok ng server

Ngayon, mayroon na tayong client na maaaring kumonekta kapag pinatakbo ang programa. Gayunpaman, hindi pa nito inililista ang mga tampok nito kaya gawin natin iyon ngayon:

Maganda, nakuha na natin lahat ng mga tampok. Ngayon, kailan natin ito gagamitin? Simple lang ang client na ito, ibig sabihin kailangan nating tawagin nang tahasan ang mga tampok kapag gusto natin ito. Sa susunod na kabanata, gagawa tayo ng mas advanced na client na may access sa sarili nitong malaking language model, LLM. Sa ngayon, tingnan natin kung paano tawagin ang mga tampok sa server:

### -4- Pagtawag sa mga tampok

Para tawagin ang mga tampok, kailangan nating tiyakin na tinutukoy natin ang tamang mga argumento at sa ilang kaso, ang pangalan ng tinatawag natin.

### -5- Patakbuhin ang client

Para patakbuhin ang client, i-type ang sumusunod na utos sa terminal:

## Takdang-Aralin

Sa takdang-aralin na ito, gagamitin mo ang natutunan mo sa paggawa ng client pero gagawa ka ng sarili mong client.

Narito ang isang server na maaari mong gamitin na kailangan mong tawagan sa pamamagitan ng iyong client code, tingnan kung kaya mong magdagdag ng higit pang mga tampok sa server upang maging mas kawili-wili ito.

## Solusyon

[Solution](./solution/README.md)

## Mahahalagang Punto

Ang mga mahahalagang punto para sa kabanatang ito tungkol sa mga client ay ang mga sumusunod:

- Maaari itong gamitin upang tuklasin at tawagin ang mga tampok sa server.
- Maaari nitong simulan ang server habang sinisimulan din nito ang sarili (gaya sa kabanatang ito) ngunit maaaring kumonekta ang mga client sa mga tumatakbong server din.
- Isa itong mahusay na paraan upang subukan ang kakayahan ng server katabi ng mga alternatibo tulad ng Inspector na ipinaliwanag sa nakaraang kabanata.

## Karagdagang Mga Sanggunian

- [Paggawa ng mga client sa MCP](https://modelcontextprotocol.io/quickstart/client)

## Mga Halimbawa

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Ano ang Susunod

- Susunod: [Paggawa ng client na may LLM](/03-GettingStarted/03-llm-client/README.md)

**Pagtatangi**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa kanyang orihinal na wika ang dapat ituring na opisyal na sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasaling-tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.