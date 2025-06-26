<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b96f2864e0bcb6fae9b4926813c3feb1",
  "translation_date": "2025-06-26T14:26:20+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "sl"
}
-->
# Napredne teme v MCP

Ta poglavje obravnava vrsto naprednih tem pri implementaciji Model Context Protocol (MCP), vključno z večmodalno integracijo, skalabilnostjo, najboljšimi praksami za varnost in integracijo v podjetja. Te teme so ključne za gradnjo robustnih in produkcijsko pripravljenih MCP aplikacij, ki lahko zadostijo zahtevam sodobnih AI sistemov.

## Pregled

Ta lekcija raziskuje napredne koncepte pri implementaciji Model Context Protocol, s poudarkom na večmodalni integraciji, skalabilnosti, najboljših praksah za varnost in integraciji v podjetja. Te teme so bistvene za izdelavo MCP aplikacij na produkcijski ravni, ki lahko obvladujejo kompleksne zahteve v poslovnih okoljih.

## Cilji učenja

Ob koncu te lekcije boste znali:

- Implementirati večmodalne zmogljivosti znotraj MCP okvirov
- Oblikovati skalabilne MCP arhitekture za scenarije z visoko obremenitvijo
- Uporabiti varnostne najboljše prakse, usklajene z varnostnimi načeli MCP
- Integrirati MCP s podjetniškimi AI sistemi in okviri
- Optimizirati zmogljivost in zanesljivost v produkcijskih okoljih

## Lekcije in primeri projektov

| Povezava | Naslov | Opis |
|----------|--------|-------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integracija z Azure | Naučite se, kako integrirati svoj MCP strežnik na Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP večmodalni primeri | Primeri za avdio, slike in večmodalne odzive |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimalna Spring Boot aplikacija, ki prikazuje OAuth2 z MCP, kot avtoritativni in virni strežnik. Prikazuje varno izdajo žetonov, zaščitene končne točke, namestitev v Azure Container Apps in integracijo z API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contexts | Spoznajte več o root context in kako jih implementirati |
| [5.5 Routing](./mcp-routing/README.md) | Usmerjanje | Spoznajte različne vrste usmerjanja |
| [5.6 Sampling](./mcp-sampling/README.md) | Vzorcevanje | Naučite se, kako delati z vzorcevanjem |
| [5.7 Scaling](./mcp-scaling/README.md) | Skaliranje | Spoznajte, kako skalirati |
| [5.8 Security](./mcp-security/README.md) | Varnost | Zavarujte svoj MCP strežnik |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP strežnik in odjemalec, ki se integrirata s SerpAPI za iskanje v spletu, novicah, izdelkih in Q&A v realnem času. Prikazuje orkestracijo več orodij, integracijo zunanjih API-jev in robustno obravnavo napak. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Pretakanje | Pretakanje podatkov v realnem času je postalo ključnega pomena v današnjem svetu, ki temelji na podatkih, kjer podjetja in aplikacije potrebujejo takojšen dostop do informacij za pravočasno odločanje. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Iskanje v realnem času | Kako MCP spreminja iskanje v spletu v realnem času z zagotavljanjem standardiziranega pristopa k upravljanju konteksta med AI modeli, iskalniki in aplikacijami. |
| [5.12  Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID avtentikacija | Microsoft Entra ID ponuja robustno rešitev za upravljanje identitete in dostopa v oblaku, ki zagotavlja, da lahko z vašim MCP strežnikom komunicirajo samo pooblaščeni uporabniki in aplikacije. |

## Dodatne reference

Za najnovejše informacije o naprednih temah MCP si oglejte:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Ključne ugotovitve

- Večmodalne implementacije MCP razširjajo AI zmogljivosti onkraj obdelave besedila
- Skalabilnost je ključna za podjetniške namestitve in jo lahko dosežemo s horizontalnim in vertikalnim skaliranjem
- Celovite varnostne ukrepe ščitijo podatke in zagotavljajo ustrezno kontrolo dostopa
- Integracija v podjetja s platformami, kot sta Azure OpenAI in Microsoft AI Foundry, izboljšuje zmogljivosti MCP
- Napredne implementacije MCP imajo koristi od optimiziranih arhitektur in skrbnega upravljanja virov

## Vaja

Oblikujte MCP implementacijo na ravni podjetja za določen primer uporabe:

1. Določite večmodalne zahteve za vaš primer uporabe
2. Opredelite varnostne kontrole, potrebne za zaščito občutljivih podatkov
3. Oblikujte skalabilno arhitekturo, ki lahko obvladuje različne obremenitve
4. Načrtujte integracijske točke s podjetniškimi AI sistemi
5. Dokumentirajte možne ozka grla zmogljivosti in strategije za njihovo odpravo

## Dodatni viri

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Kaj sledi

- [5.1 MCP Integration](./mcp-integration/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za avtomatski prevod AI [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da lahko avtomatski prevodi vsebujejo napake ali netočnosti. Izvirni dokument v izvirnem jeziku velja za avtoritativni vir. Za kritične informacije priporočamo strokovni človeški prevod. Nismo odgovorni za morebitna nesporazume ali napačne razlage, ki izhajajo iz uporabe tega prevoda.