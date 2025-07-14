<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "748c61250d4a326206b72b28f6154615",
  "translation_date": "2025-07-13T23:48:53+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "sl"
}
-->
# Napredne teme v MCP

Ta poglavje pokriva vrsto naprednih tem pri implementaciji Model Context Protocol (MCP), vključno z večmodalno integracijo, razširljivostjo, najboljšimi praksami za varnost in integracijo v podjetja. Te teme so ključne za gradnjo robustnih in produkcijsko pripravljenih MCP aplikacij, ki lahko zadostijo zahtevam sodobnih AI sistemov.

## Pregled

Ta lekcija raziskuje napredne koncepte implementacije Model Context Protocol, s poudarkom na večmodalni integraciji, razširljivosti, najboljših praksah za varnost in integraciji v podjetja. Te teme so bistvene za izdelavo produkcijsko usmerjenih MCP aplikacij, ki lahko obvladujejo kompleksne zahteve v poslovnih okoljih.

## Cilji učenja

Ob koncu te lekcije boste znali:

- Implementirati večmodalne zmogljivosti znotraj MCP okvirov
- Načrtovati razširljive MCP arhitekture za scenarije z visokimi zahtevami
- Uporabiti najboljše varnostne prakse, skladne s varnostnimi načeli MCP
- Integrirati MCP s poslovnimi AI sistemi in okviri
- Optimizirati zmogljivost in zanesljivost v produkcijskih okoljih

## Lekcije in vzorčni projekti

| Povezava | Naslov | Opis |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integracija z Azure | Naučite se, kako integrirati vaš MCP strežnik na Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP večmodalni primeri | Primeri za avdio, sliko in večmodalne odzive |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimalna Spring Boot aplikacija, ki prikazuje OAuth2 z MCP, tako kot Authorization kot Resource Server. Prikazuje varno izdajo žetonov, zaščitene končne točke, nameščanje na Azure Container Apps in integracijo API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root konteksti | Spoznajte več o root kontekstu in kako jih implementirati |
| [5.5 Routing](./mcp-routing/README.md) | Usmerjanje | Spoznajte različne vrste usmerjanja |
| [5.6 Sampling](./mcp-sampling/README.md) | Vzorcevanje | Naučite se, kako delati z vzorčenjem |
| [5.7 Scaling](./mcp-scaling/README.md) | Razširjanje | Spoznajte, kako razširjati |
| [5.8 Security](./mcp-security/README.md) | Varnost | Zavarujte vaš MCP strežnik |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP strežnik in odjemalec, ki se povezuje s SerpAPI za iskanje v spletu, novicah, izdelkih in Q&A v realnem času. Prikazuje orkestracijo več orodij, integracijo zunanjih API-jev in robustno obravnavo napak. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Pretakanje | Pretakanje podatkov v realnem času je postalo ključno v današnjem svetu, ki temelji na podatkih, kjer podjetja in aplikacije potrebujejo takojšen dostop do informacij za pravočasne odločitve. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Iskanje v realnem času | Kako MCP spreminja iskanje v realnem času z zagotavljanjem standardiziranega pristopa k upravljanju konteksta med AI modeli, iskalniki in aplikacijami. |
| [5.12  Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID avtentikacija | Microsoft Entra ID nudi robustno rešitev za upravljanje identitet in dostopa v oblaku, ki zagotavlja, da lahko z vašim MCP strežnikom komunicirajo le pooblaščeni uporabniki in aplikacije. |
| [5.13 Azure AI Foundry Agent Integration](./mcp-foundry-agent-integration/README.md) | Integracija Azure AI Foundry | Naučite se, kako integrirati Model Context Protocol strežnike z Azure AI Foundry agenti, kar omogoča močno orkestracijo orodij in zmogljivosti podjetniške AI s standardiziranimi povezavami do zunanjih virov podatkov. |

## Dodatne reference

Za najnovejše informacije o naprednih temah MCP si oglejte:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Ključne ugotovitve

- Večmodalne implementacije MCP razširjajo AI zmogljivosti onkraj obdelave besedila
- Razširljivost je ključna za poslovne namestitve in jo je mogoče doseči z horizontalnim in vertikalnim razširjanjem
- Celoviti varnostni ukrepi ščitijo podatke in zagotavljajo ustrezno kontrolo dostopa
- Integracija v podjetja s platformami, kot sta Azure OpenAI in Microsoft AI Foundry, izboljšuje zmogljivosti MCP
- Napredne implementacije MCP koristijo od optimiziranih arhitektur in skrbnega upravljanja virov

## Vaja

Načrtujte MCP implementacijo na ravni podjetja za določen primer uporabe:

1. Določite večmodalne zahteve za vaš primer uporabe
2. Opredelite varnostne ukrepe za zaščito občutljivih podatkov
3. Načrtujte razširljivo arhitekturo, ki lahko obvladuje različne obremenitve
4. Načrtujte integracijske točke s poslovnimi AI sistemi
5. Dokumentirajte morebitne ozka grla zmogljivosti in strategije za njihovo omilitev

## Dodatni viri

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Kaj sledi

- [5.1 MCP Integration](./mcp-integration/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za avtomatski prevod AI [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da lahko avtomatski prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.