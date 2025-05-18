<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a9c3ca25df37dbb4c1518174fc415ce1",
  "translation_date": "2025-05-17T09:45:41+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "tl"
}
-->
# Paglikha ng kliyente

Ang mga kliyente ay mga custom na aplikasyon o script na direktang nakikipag-ugnayan sa isang MCP Server upang humiling ng mga mapagkukunan, kasangkapan, at mga prompt. Hindi tulad ng paggamit ng inspector tool, na nagbibigay ng graphical interface para makipag-ugnayan sa server, ang pagsusulat ng sarili mong kliyente ay nagbibigay-daan para sa programmatic at automated na pakikipag-ugnayan. Ito ay nagpapahintulot sa mga developer na isama ang mga kakayahan ng MCP sa kanilang sariling mga workflow, awtomatikong gawin ang mga gawain, at bumuo ng mga custom na solusyon na iniakma para sa mga tiyak na pangangailangan.

## Pangkalahatang-ideya

Ipinapakilala ng araling ito ang konsepto ng mga kliyente sa loob ng Model Context Protocol (MCP) ecosystem. Matutunan mo kung paano sumulat ng sarili mong kliyente at ikonekta ito sa isang MCP Server.

## Mga Layunin sa Pagkatuto

Sa pagtatapos ng araling ito, magagawa mong:

- Maunawaan kung ano ang magagawa ng isang kliyente.
- Sumulat ng sarili mong kliyente.
- Ikonekta at subukan ang kliyente sa isang MCP server upang matiyak na gumagana ito ayon sa inaasahan.

## Ano ang kailangan sa pagsusulat ng kliyente?

Upang sumulat ng kliyente, kakailanganin mong gawin ang mga sumusunod:

- **I-import ang tamang mga library**. Gagamitin mo ang parehong library tulad ng dati, ngunit ibang mga constructs.
- **I-instantiate ang isang kliyente**. Kabilang dito ang paglikha ng isang client instance at ikonekta ito sa napiling paraan ng transportasyon.
- **Magpasya kung aling mga mapagkukunan ang ililista**. Ang iyong MCP server ay may mga mapagkukunan, kasangkapan at mga prompt, kailangan mong magpasya kung alin ang ililista.
- **Isama ang kliyente sa isang host application**. Kapag alam mo na ang mga kakayahan ng server, kailangan mong isama ito sa iyong host application upang kapag ang isang user ay nag-type ng isang prompt o ibang command, ang kaukulang tampok ng server ay ma-invoke.

Ngayon na nauunawaan natin sa mataas na antas kung ano ang ating gagawin, tingnan natin ang isang halimbawa sa susunod.

### Isang halimbawa ng kliyente

Tingnan natin ang halimbawang kliyente na ito:
Ikaw ay sinanay sa data hanggang Oktubre 2023.

Sa nakaraang code, ginawa natin:

- I-import ang mga library
- Lumikha ng isang instance ng kliyente at ikonekta ito gamit ang stdio para sa transportasyon.
- Ililista ang mga prompt, mapagkukunan at kasangkapan at i-invoke ang lahat ng mga ito.

Ayan na, isang kliyente na maaaring makipag-usap sa isang MCP Server.

Maglaan tayo ng oras sa susunod na seksyon ng ehersisyo at hatiin ang bawat code snippet at ipaliwanag kung ano ang nangyayari.

## Ehersisyo: Pagsusulat ng kliyente

Tulad ng sinabi sa itaas, maglaan tayo ng oras sa pagpapaliwanag ng code, at kung nais mo, maaari kang mag-code kasabay nito.

### -1- I-import ang mga library

I-import natin ang mga library na kailangan natin, kakailanganin natin ng mga reference sa isang kliyente at sa napiling transport protocol, stdio. Ang stdio ay isang protocol para sa mga bagay na dapat tumakbo sa iyong lokal na makina. Ang SSE ay isa pang transport protocol na ipapakita namin sa mga susunod na kabanata ngunit iyon ang iyong iba pang opsyon. Sa ngayon, ipagpatuloy natin ang stdio.

Magpatuloy tayo sa pag-i-instantiate.

### -2- Pag-i-instantiate ng kliyente at transportasyon

Kakailanganin nating lumikha ng isang instance ng transportasyon at ng ating kliyente:

### -3- Paglilista ng mga tampok ng server

Ngayon, mayroon tayong kliyente na maaaring kumonekta kapag pinatakbo ang programa. Gayunpaman, hindi nito aktwal na inililista ang mga tampok nito kaya gawin natin iyon sa susunod:

Mahusay, ngayon na natin nakapture ang lahat ng mga tampok. Ngayon ang tanong ay kailan natin gagamitin ang mga ito? Well, ang kliyenteng ito ay medyo simple, simple sa kahulugan na kakailanganin nating tawagin ang mga tampok kapag gusto natin ang mga ito. Sa susunod na kabanata, lilikha tayo ng mas advanced na kliyente na may access sa sarili nitong malaking language model, LLM. Sa ngayon, tingnan natin kung paano natin ma-i-invoke ang mga tampok sa server:

### -4- I-invoke ang mga tampok

Upang i-invoke ang mga tampok, kailangan nating tiyakin na tinutukoy natin ang tamang mga argumento at sa ilang mga kaso ang pangalan ng kung ano ang ating sinusubukang i-invoke.

### -5- Patakbuhin ang kliyente

Upang patakbuhin ang kliyente, i-type ang sumusunod na command sa terminal:

## Takdang Aralin

Sa takdang araling ito, gagamitin mo ang iyong natutunan sa paglikha ng kliyente ngunit lumikha ng sarili mong kliyente.

Narito ang isang server na maaari mong gamitin na kailangan mong tawagan sa pamamagitan ng iyong client code, tingnan kung maaari kang magdagdag ng higit pang mga tampok sa server upang gawin itong mas kawili-wili.

## Solusyon

[Solusyon](./solution/README.md)

## Mahahalagang Punto

Ang mahahalagang punto para sa kabanatang ito tungkol sa mga kliyente ay ang mga sumusunod:

- Maaaring gamitin upang parehong tuklasin at i-invoke ang mga tampok sa server.
- Maaaring magsimula ng server habang ito mismo ay nagsisimula (tulad ng sa kabanatang ito) ngunit ang mga kliyente ay maaaring kumonekta sa mga tumatakbong server din.
- Isang mahusay na paraan upang subukan ang mga kakayahan ng server kasunod ng mga alternatibo tulad ng Inspector na inilarawan sa nakaraang kabanata.

## Karagdagang Mga Mapagkukunan

- [Pagbuo ng mga kliyente sa MCP](https://modelcontextprotocol.io/quickstart/client)

## Mga Halimbawa

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Ano ang Susunod

- Susunod: [Paglikha ng kliyente na may LLM](/03-GettingStarted/03-llm-client/README.md)

**Pagtatatuwa**:  
Ang dokumentong ito ay isinalin gamit ang serbisyo ng AI na pagsasalin [Co-op Translator](https://github.com/Azure/co-op-translator). Habang nagsusumikap kami para sa katumpakan, mangyaring tandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga error o hindi pagkakatumpak. Ang orihinal na dokumento sa kanyang katutubong wika ay dapat ituring na mapagkakatiwalaang pinagmulan. Para sa kritikal na impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot para sa anumang hindi pagkakaintindihan o maling interpretasyon na nagmumula sa paggamit ng pagsasaling ito.