<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "748c61250d4a326206b72b28f6154615",
  "translation_date": "2025-07-02T10:02:28+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "sl"
}
-->
# Napredne teme v MCP

Ta poglavje zajema vrsto naprednih tem pri implementaciji Model Context Protocol (MCP), vključno z večmodalno integracijo, skalabilnostjo, najboljšimi praksami varnosti in integracijo v podjetjih. Te teme so ključne za razvoj robustnih in produkcijsko pripravljenih MCP aplikacij, ki lahko zadostijo zahtevam sodobnih AI sistemov.

## Pregled

Ta lekcija raziskuje napredne koncepte implementacije Model Context Protocol, s poudarkom na večmodalni integraciji, skalabilnosti, najboljših praksah varnosti in integraciji v podjetjih. Te teme so bistvenega pomena za razvoj produkcijsko usmerjenih MCP aplikacij, ki zmorejo obvladovati kompleksne zahteve v poslovnih okoljih.

## Cilji učenja

Ob koncu te lekcije boste znali:

- Implementirati večmodalne zmogljivosti znotraj MCP okvirov
- Oblikovati skalabilne MCP arhitekture za scenarije z visokimi zahtevami
- Uporabiti najboljše varnostne prakse v skladu s varnostnimi načeli MCP
- Integrirati MCP s poslovnimi AI sistemi in okviri
- Optimizirati zmogljivost in zanesljivost v produkcijskih okoljih

## Lekcije in vzorčni projekti

| Povezava | Naslov | Opis |
|----------|--------|-------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integracija z Azure | Naučite se, kako integrirati vaš MCP Server na Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP večmodalni primeri | Primeri za avdio, sliko in večmodalne odzive |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimalna Spring Boot aplikacija, ki prikazuje OAuth2 z MCP, kot Authorization in Resource Server. Prikazuje varno izdajo žetonov, zaščitene končne točke, namestitev na Azure Container Apps in integracijo z API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root konteksti | Spoznajte več o root kontekstu in kako jih implementirati |
| [5.5 Routing](./mcp-routing/README.md) | Usmerjanje | Spoznajte različne vrste usmerjanja |
| [5.6 Sampling](./mcp-sampling/README.md) | Vzorcevanje | Naučite se delati z vzorčenjem |
| [5.7 Scaling](./mcp-scaling/README.md) | Skaliranje | Spoznajte, kako skalirati |
| [5.8 Security](./mcp-security/README.md) | Varnost | Zavarujte svoj MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP strežnik in odjemalec, ki se povezuje s SerpAPI za iskanje po spletu, novicah, izdelkih in Q&A v realnem času. Prikazuje orkestracijo več orodij, integracijo zunanjih API-jev in robustno obravnavo napak. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Pretakanje v realnem času | Pretakanje podatkov v realnem času je postalo ključno v današnjem svetu, kjer podjetja in aplikacije potrebujejo takojšen dostop do informacij za pravočasno odločanje. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Iskanje po spletu v realnem času | Kako MCP spreminja iskanje po spletu v realnem času z zagotavljanjem standardiziranega pristopa k upravljanju konteksta med AI modeli, iskalniki in aplikacijami. |
| [5.12 Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID avtentikacija | Microsoft Entra ID zagotavlja robustno rešitev za upravljanje identitete in dostopa v oblaku, ki pomaga zagotoviti, da lahko do vašega MCP strežnika dostopajo le pooblaščeni uporabniki in aplikacije. |
| [5.13 Azure AI Foundry Agent Integration](./mcp-foundry-agent-integration/README.md) | Integracija Azure AI Foundry | Naučite se, kako integrirati Model Context Protocol strežnike z Azure AI Foundry agenti, kar omogoča zmogljivo orkestracijo orodij in podjetniške AI zmogljivosti z enotnimi povezavami do zunanjih virov podatkov. |

## Dodatne reference

Za najnovejše informacije o naprednih temah MCP si oglejte:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Ključne ugotovitve

- Večmodalne implementacije MCP razširjajo AI zmogljivosti onkraj obdelave besedila
- Skalabilnost je ključna za implementacije v podjetjih in jo je mogoče doseči z horizontalnim in vertikalnim skaliranjem
- Celovite varnostne ukrepe ščitijo podatke in zagotavljajo ustrezno kontrolo dostopa
- Podjetniška integracija s platformami, kot sta Azure OpenAI in Microsoft AI Foundry, izboljšuje zmogljivosti MCP
- Napredne implementacije MCP koristijo od optimiziranih arhitektur in skrbnega upravljanja virov

## Vaja

Oblikujte MCP implementacijo na ravni podjetja za določen primer uporabe:

1. Določite večmodalne zahteve za vaš primer uporabe
2. Opredelite varnostne kontrole za zaščito občutljivih podatkov
3. Oblikujte skalabilno arhitekturo, ki lahko obvladuje različne obremenitve
4. Načrtujte integracijske točke s poslovnimi AI sistemi
5. Dokumentirajte možne ozka grla zmogljivosti in strategije za njihovo omilitev

## Dodatni viri

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Kaj sledi

- [5.1 MCP Integration](./mcp-integration/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, upoštevajte, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za kritične informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.