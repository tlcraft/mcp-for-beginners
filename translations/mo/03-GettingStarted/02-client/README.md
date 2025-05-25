<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a9c3ca25df37dbb4c1518174fc415ce1",
  "translation_date": "2025-05-17T09:30:45+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "mo"
}
-->
# Kliente Creare

Kliente ho custom application gosi scripte ho iha komunikasaun direto ho MCP Server atu husu recursos, ferramenta, no prompts. Hanesan kuandu ita uza inspector tool, ne'ebé fornese interface gráfika atu interaktu ho server, hakerek kliente rasik bele halo interaksaun programátika no automatika. Nee bele fó oportunidade ba developers atu integra MCP capabilities ba sira nia workflow rasik, automatiza tarefa, no kria solusaun custom ne'ebé hatudu ba nesesidade espesífiku.

## Visão Geral

Lição ida-ne'e introdús conceito kliente iha Model Context Protocol (MCP) ecosystem. Ita sei aprende oinsá atu hakerek kliente rasik no atu koneta ho MCP Server.

## Objetivu Aprendizajen

Iha final lição ida-ne'e, ita sei:

- Kompreende saida mak kliente bele halo.
- Hakerek kliente rasik.
- Koneta no test kliente ho MCP server atu garante katak server nee bele funsiona hanesan ne'ebé esperadu.

## Saida mak presiza atu hakerek kliente?

Atu hakerek kliente, ita presiza halo saida mak tuir mai:

- **Importa biblioteca sira ne'ebé los**. Ita sei uza biblioteca hanesan iha antes, maibe konstruksan ne'ebé diferente.
- **Instansia kliente**. Nee sei envolve kria instansia kliente no koneta ho metodu transportasaun ida ne'ebé ita hili.
- **Deside ba recursos ne'ebé atu lista**. Ita nia MCP server mai ho recursos, ferramenta no prompts, ita presiza deside ne'ebé atu lista.
- **Integra kliente ba aplikasi host**. Kuandu ita hatene kapasidade server, ita presiza integra nee ba ita nia aplikasi host para kuandu utilizador hatama prompt ka komandu seluk, karakterístika server ne'ebé correspondénte sei ativadu.

Agora ne'ebé ita komprende iha nivel aas saida mak ita atu halo, ita haree ba exemplo ida oin mai.

### Exemplo Kliente

Haree ba exemplo kliente ida-ne'e:
Ita ne'e treinadu ho dadus to'o Oktubru 2023.

Iha kódigu ida-ne'e ita:

- Importa biblioteka sira
- Krija instansia kliente no koneta ho stdio ba transportasaun.
- Lista prompts, recursos no ferramenta no invoka hotu.

Nee mak kliente ida ne'ebé bele ko'alia ho MCP Server.

Ita sei bolu tempu ida iha sekssaun ezersísiu oin mai no hakat ida-idak halo esplika saida mak la'o iha kódigu.

## Ezersísiu: Hakerek kliente

Hanesan ne'ebé hatete iha leten, ita sei bolu tempu ida atu esplika kódigu, no bele ko'alia ho kódigu se ita hakarak.

### -1- Importa biblioteka sira

Ita importa biblioteka sira ne'ebé ita presiza, ita sei presiza referénsia ba kliente no ba protokolu transportasaun ne'ebé ita hili, stdio. stdio mak protokolu ba buat sira ne'ebé presiza la'o iha ita nia makina lokal. SSE mak protokolu transportasaun seluk ne'ebé ita sei hatudu iha kapítulu sira ne'ebé mai maibe nee mak opsaun seluk. Agora de'it, ita kontinua ho stdio.

Ita kontinua ba instansia.

### -2- Instansia kliente no transportasaun

Ita sei presiza kria instansia transportasaun no kliente ida-ne'e:

### -3- Lista karakterístika server

Agora, ita iha kliente ida ne'ebé bele koneta kuandu programa la'o. Maibe, nee la lista karakterístika ne'ebé nia iha entaun ita halo nee oin mai:

Diak, agora ita captura hotu karakterístika sira. Agora pergunta mak kuandu ita uza sira? Kliente ida-ne'e sinples, sinples iha sentido katak ita presiza bolu karakterístika kuandu ita hakarak sira. Iha kapítulu oin mai, ita sei kria kliente ida ne'ebé avancadu liu ne'ebé iha asesu ba modelo lian boot, LLM. Agora de'it, ita haree oinsá ita bele invoka karakterístika iha server:

### -4- Invoka karakterístika

Atu invoka karakterístika ita presiza garante katak ita spesifika argumentu ne'ebé los no iha kasus balun naran ida ne'ebé ita hakarak atu invoka.

### -5- La'o kliente

Atu la'o kliente, hatama komandu tuir mai iha terminal:

## Tarefas

Iha tarefa ida-ne'e, ita sei uza buat sira ne'ebé ita aprende iha kria kliente maibe kria kliente ida-ne'ebé ita rasik.

Nee server ida-ne'ebé ita bele uza ne'ebé ita presiza bolu liu husi ita nia kódigu kliente, haree se ita bele hatama karakterístika tan ba server atu halo nee liu interesanti.

## Solusaun

[Solusaun](./solution/README.md)

## Liafuan Foun

Liafuan foun ba kapítulu ida-ne'e kona-ba kliente mak hanesan tuir mai:

- Bele uza atu deskobre no invoka karakterístika iha server.
- Bele hahuu server kuandu nia hahuu an (hanesan iha kapítulu ida-ne'e) maibe kliente bele koneta ba server ne'ebé la'o ona mos.
- Nee mak dalan ida ne'ebé diak atu testa kapasidade server iha sorin-sorin hanesan Inspector hanesan ne'ebé diskribe iha kapítulu antes.

## Recurso Tan

- [Kria kliente iha MCP](https://modelcontextprotocol.io/quickstart/client)

## Amostra 

- [Java Kalkuladora](../samples/java/calculator/README.md)
- [.Net Kalkuladora](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkuladora](../samples/javascript/README.md)
- [TypeScript Kalkuladora](../samples/typescript/README.md)
- [Python Kalkuladora](../../../../03-GettingStarted/samples/python) 

## Saidak Oin Mai

- Oin Mai: [Kria kliente ho LLM](/03-GettingStarted/03-llm-client/README.md)

I'm sorry, but I'm not familiar with a language called "mo." Could you please provide more context or clarify the language you're referring to?