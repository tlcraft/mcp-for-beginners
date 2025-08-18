<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d204bc94ea6027d06a703b21b711ca57",
  "translation_date": "2025-08-18T17:47:38+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "sl"
}
-->
# Napredne teme v MCP

[![Napredni MCP: Varnostni, razširljivi in večmodalni AI agenti](../../../translated_images/06.42259eaf91fccfc6d06ef1c126c9db04bbff9e5f60a87b782a2ec2616163142f.sl.png)](https://youtu.be/4yjmGvJzYdY)

_(Kliknite na zgornjo sliko za ogled videa te lekcije)_

To poglavje zajema vrsto naprednih tem pri implementaciji protokola Model Context Protocol (MCP), vključno z večmodalno integracijo, razširljivostjo, najboljšimi praksami za varnost in integracijo v podjetjih. Te teme so ključne za gradnjo robustnih in produkcijsko pripravljenih MCP aplikacij, ki lahko zadostijo zahtevam sodobnih AI sistemov.

## Pregled

Ta lekcija raziskuje napredne koncepte implementacije protokola Model Context Protocol, s poudarkom na večmodalni integraciji, razširljivosti, najboljših praksah za varnost in integraciji v podjetjih. Te teme so bistvene za gradnjo produkcijsko pripravljenih MCP aplikacij, ki lahko obvladajo kompleksne zahteve v podjetniških okoljih.

## Cilji učenja

Po koncu te lekcije boste sposobni:

- Implementirati večmodalne zmogljivosti znotraj MCP okvirov
- Oblikovati razširljive MCP arhitekture za scenarije z visokimi zahtevami
- Uporabiti najboljše prakse za varnost, usklajene z varnostnimi načeli MCP
- Integrirati MCP s podjetniškimi AI sistemi in okviri
- Optimizirati zmogljivost in zanesljivost v produkcijskih okoljih

## Lekcije in vzorčni projekti

| Povezava | Naslov | Opis |
|----------|--------|------|
| [5.1 Integracija z Azure](./mcp-integration/README.md) | Integracija z Azure | Naučite se, kako integrirati svoj MCP strežnik na Azure |
| [5.2 Večmodalni vzorec](./mcp-multi-modality/README.md) | MCP večmodalni vzorci | Vzorci za zvok, slike in večmodalne odgovore |
| [5.3 MCP OAuth2 vzorec](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimalna Spring Boot aplikacija, ki prikazuje OAuth2 z MCP, tako kot strežnik za avtorizacijo kot tudi kot strežnik virov. Prikazuje izdajo varnih žetonov, zaščitene končne točke, uvajanje v Azure Container Apps in integracijo z API Management. |
| [5.4 Root konteksti](./mcp-root-contexts/README.md) | Root konteksti | Več o root kontekstih in kako jih implementirati |
| [5.5 Usmerjanje](./mcp-routing/README.md) | Usmerjanje | Naučite se različnih vrst usmerjanja |
| [5.6 Vzorčenje](./mcp-sampling/README.md) | Vzorčenje | Naučite se delati z vzorčenjem |
| [5.7 Razširljivost](./mcp-scaling/README.md) | Razširljivost | Naučite se o razširljivosti |
| [5.8 Varnost](./mcp-security/README.md) | Varnost | Zavarujte svoj MCP strežnik |
| [5.9 Vzorec za spletno iskanje](./web-search-mcp/README.md) | Spletno iskanje MCP | Python MCP strežnik in odjemalec, ki se integrirata s SerpAPI za iskanje v realnem času po spletu, novicah, izdelkih in Q&A. Prikazuje orkestracijo več orodij, integracijo zunanjih API-jev in robustno obravnavo napak. |
| [5.10 Pretakanje v realnem času](./mcp-realtimestreaming/README.md) | Pretakanje | Pretakanje podatkov v realnem času je postalo bistveno v današnjem svetu, ki temelji na podatkih, kjer podjetja in aplikacije potrebujejo takojšen dostop do informacij za pravočasno odločanje. |
| [5.11 Spletno iskanje v realnem času](./mcp-realtimesearch/README.md) | Spletno iskanje | Kako MCP preoblikuje spletno iskanje v realnem času z zagotavljanjem standardiziranega pristopa k upravljanju konteksta med AI modeli, iskalniki in aplikacijami. |
| [5.12 Avtentikacija Entra ID za strežnike Model Context Protocol](./mcp-security-entra/README.md) | Avtentikacija Entra ID | Microsoft Entra ID zagotavlja robustno rešitev za upravljanje identitet in dostopa v oblaku, ki pomaga zagotoviti, da lahko z vašim MCP strežnikom komunicirajo le pooblaščeni uporabniki in aplikacije. |
| [5.13 Integracija z agentom Azure AI Foundry](./mcp-foundry-agent-integration/README.md) | Integracija z Azure AI Foundry | Naučite se, kako integrirati strežnike Model Context Protocol z agenti Azure AI Foundry, kar omogoča močno orkestracijo orodij in podjetniške AI zmogljivosti s standardiziranimi povezavami do zunanjih virov podatkov. |
| [5.14 Inženiring konteksta](./mcp-contextengineering/README.md) | Inženiring konteksta | Prihodnje priložnosti tehnik inženiringa konteksta za MCP strežnike, vključno z optimizacijo konteksta, dinamičnim upravljanjem konteksta in strategijami za učinkovito oblikovanje pozivov znotraj MCP okvirov. |

## Dodatne reference

Za najnovejše informacije o naprednih temah MCP glejte:
- [MCP Dokumentacija](https://modelcontextprotocol.io/)
- [MCP Specifikacija](https://spec.modelcontextprotocol.io/)
- [GitHub Repozitorij](https://github.com/modelcontextprotocol)

## Ključne točke

- Večmodalne implementacije MCP razširjajo AI zmogljivosti onkraj obdelave besedila
- Razširljivost je ključna za podjetniške implementacije in jo je mogoče doseči z vodoravno in navpično razširljivostjo
- Celoviti varnostni ukrepi ščitijo podatke in zagotavljajo ustrezen nadzor dostopa
- Integracija v podjetjih s platformami, kot sta Azure OpenAI in Microsoft AI Foundry, izboljšuje zmogljivosti MCP
- Napredne implementacije MCP koristijo optimiziranim arhitekturam in skrbnemu upravljanju virov

## Vaja

Oblikujte podjetniško implementacijo MCP za določen primer uporabe:

1. Določite večmodalne zahteve za vaš primer uporabe
2. Opišite varnostne kontrole, potrebne za zaščito občutljivih podatkov
3. Oblikujte razširljivo arhitekturo, ki lahko obvlada različno obremenitev
4. Načrtujte točke integracije s podjetniškimi AI sistemi
5. Dokumentirajte morebitna ozka grla zmogljivosti in strategije za njihovo odpravo

## Dodatni viri

- [Dokumentacija Azure OpenAI](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Dokumentacija Microsoft AI Foundry](https://learn.microsoft.com/en-us/ai-services/)

---

## Kaj sledi

- [5.1 MCP Integracija](./mcp-integration/README.md)

**Izjava o omejitvi odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za strojno prevajanje [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku je treba obravnavati kot avtoritativni vir. Za ključne informacije priporočamo strokovno človeško prevajanje. Ne prevzemamo odgovornosti za morebitna nesporazumevanja ali napačne razlage, ki izhajajo iz uporabe tega prevoda.