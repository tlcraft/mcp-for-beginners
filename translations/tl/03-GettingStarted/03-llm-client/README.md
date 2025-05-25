<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abbb199eb22fdffa44a0de4db6a5ea49",
  "translation_date": "2025-05-17T10:26:05+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "tl"
}
-->
# Paglikha ng kliyente gamit ang LLM

Sa ngayon, nakita mo na kung paano gumawa ng server at kliyente. Ang kliyente ay nagawang tawagin ang server nang direkta upang ilista ang mga kasangkapan, mapagkukunan, at mga prompt nito. Gayunpaman, hindi ito praktikal na pamamaraan. Ang iyong gumagamit ay nabubuhay sa panahong agentic at inaasahan na gagamit ng mga prompt at makikipag-usap sa isang LLM upang gawin ito. Para sa iyong gumagamit, hindi mahalaga kung gagamit ka ng MCP o hindi upang itago ang iyong mga kakayahan ngunit inaasahan nilang makipag-ugnayan gamit ang natural na wika. Paano natin ito malulutas? Ang solusyon ay tungkol sa pagdaragdag ng isang LLM sa kliyente.

## Pangkalahatang-ideya

Sa araling ito, tututok tayo sa pagdaragdag ng isang LLM upang gawin ang iyong kliyente at ipakita kung paano ito nagbibigay ng mas magandang karanasan para sa iyong gumagamit.

## Mga Layunin sa Pagkatuto

Sa pagtatapos ng araling ito, magagawa mong:

- Lumikha ng kliyente gamit ang isang LLM.
- Walang kahirap-hirap na makipag-ugnayan sa isang MCP server gamit ang isang LLM.
- Magbigay ng mas mahusay na karanasan para sa end user sa panig ng kliyente.

## Pamamaraan

Subukan nating intindihin ang pamamaraan na kailangan nating gawin. Ang pagdaragdag ng isang LLM ay mukhang simple, ngunit paano nga ba natin ito gagawin?

Ganito makikipag-ugnayan ang kliyente sa server:

1. Magtatag ng koneksyon sa server.

1. Ililista ang mga kakayahan, prompt, mapagkukunan, at kasangkapan, at i-save ang kanilang schema.

1. Magdagdag ng isang LLM at ipasa ang na-save na mga kakayahan at ang kanilang schema sa format na naiintindihan ng LLM.

1. Pangasiwaan ang prompt ng gumagamit sa pamamagitan ng pagpasa nito sa LLM kasama ang mga kasangkapan na nakalista ng kliyente.

Magaling, ngayon nauunawaan natin kung paano natin ito magagawa sa mataas na antas, subukan natin ito sa ibaba ng ehersisyo.

## Ehersisyo: Paglikha ng kliyente gamit ang isang LLM

Sa ehersisyong ito, matutunan nating magdagdag ng isang LLM sa ating kliyente.

### -1- Kumonekta sa server

Gawin muna natin ang ating kliyente:
Ikaw ay sinanay sa data hanggang Oktubre 2023.

Magaling, para sa susunod na hakbang, ilista natin ang mga kakayahan sa server.

### -2 Ilista ang mga kakayahan ng server

Ngayon ay kokonekta tayo sa server at hihilingin ang mga kakayahan nito:

### -3- I-convert ang mga kakayahan ng server sa mga kasangkapan ng LLM

Susunod na hakbang pagkatapos ilista ang mga kakayahan ng server ay i-convert ang mga ito sa format na naiintindihan ng LLM. Kapag nagawa natin iyon, maibibigay natin ang mga kakayahang ito bilang mga kasangkapan sa ating LLM.

Magaling, hindi pa tayo nakahanda para pangasiwaan ang anumang kahilingan ng gumagamit, kaya't harapin natin iyon sa susunod.

### -4- Pangasiwaan ang kahilingan ng prompt ng gumagamit

Sa bahaging ito ng code, pangasiwaan natin ang mga kahilingan ng gumagamit.

Magaling, nagawa mo!

## Takdang Aralin

Kunin ang code mula sa ehersisyo at bumuo ng server na may mas maraming kasangkapan. Pagkatapos lumikha ng kliyente na may isang LLM, tulad ng sa ehersisyo, at subukan ito sa iba't ibang prompt upang masiguro na lahat ng iyong mga kasangkapan sa server ay tinatawag nang dinamiko. Ang ganitong paraan ng pagbuo ng kliyente ay nangangahulugang ang end user ay magkakaroon ng mahusay na karanasan dahil magagamit nila ang mga prompt, sa halip na eksaktong mga utos ng kliyente, at hindi nila alam na may tinatawag na MCP server.

## Solusyon

[Solusyon](/03-GettingStarted/03-llm-client/solution/README.md)

## Mahahalagang Punto

- Ang pagdaragdag ng isang LLM sa iyong kliyente ay nagbibigay ng mas magandang paraan para sa mga gumagamit na makipag-ugnayan sa MCP Servers.
- Kailangan mong i-convert ang tugon ng MCP Server sa isang bagay na naiintindihan ng LLM.

## Mga Halimbawa

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Karagdagang Mga Mapagkukunan

## Ano ang Susunod

- Susunod: [Paggamit ng server gamit ang Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Pagtatatuwa**:  
Ang dokumentong ito ay isinalin gamit ang serbisyo ng AI translation na [Co-op Translator](https://github.com/Azure/co-op-translator). Habang pinagsisikapan namin ang katumpakan, mangyaring tandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi pagkakatumpak. Ang orihinal na dokumento sa kanyang katutubong wika ay dapat ituring na mapagkakatiwalaang mapagkukunan. Para sa kritikal na impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot para sa anumang hindi pagkakaintindihan o maling interpretasyon na dulot ng paggamit ng pagsasaling ito.