<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "adaf47734a5839447b5c60a27120fbaf",
  "translation_date": "2025-06-11T16:33:45+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "sl"
}
-->
# Napredne teme v MCP

To poglavje zajema vrsto naprednih tem pri implementaciji Model Context Protocol (MCP), vključno z večmodalno integracijo, razširljivostjo, najboljšimi varnostnimi praksami in integracijo v podjetja. Te teme so ključne za razvoj robustnih in produkcijsko pripravljenih MCP aplikacij, ki lahko zadostijo zahtevam sodobnih AI sistemov.

## Pregled

Ta lekcija raziskuje napredne koncepte implementacije Model Context Protocol, s poudarkom na večmodalni integraciji, razširljivosti, najboljših varnostnih praksah in integraciji v podjetja. Te teme so bistvene za gradnjo produkcijsko kakovostnih MCP aplikacij, ki lahko obvladujejo kompleksne zahteve v poslovnem okolju.

## Cilji učenja

Na koncu te lekcije boste znali:

- Implementirati večmodalne zmogljivosti znotraj MCP okvirjev
- Načrtovati razširljive MCP arhitekture za scenarije z velikim povpraševanjem
- Uporabiti najboljše varnostne prakse v skladu z varnostnimi načeli MCP
- Integrirati MCP s poslovnimi AI sistemi in okvirji
- Optimizirati zmogljivost in zanesljivost v produkcijskem okolju

## Lekcije in vzorčni projekti

| Link | Naslov | Opis |
|------|--------|-------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integracija z Azure | Naučite se, kako integrirati vaš MCP strežnik na Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP večmodalni primeri | Primeri za avdio, sliko in večmodalne odzive |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimalna Spring Boot aplikacija, ki prikazuje OAuth2 z MCP, kot Avtorizacijski in Vir strežnik. Prikazuje varno izdajo žetonov, zaščitene končne točke, namestitev na Azure Container Apps in integracijo API upravljanja. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root konteksti | Naučite se več o root kontekstu in kako jih implementirati |
| [5.5 Routing](./mcp-routing/README.md) | Usmerjanje | Spoznajte različne vrste usmerjanja |
| [5.6 Sampling](./mcp-sampling/README.md) | Vzorcevanje | Naučite se delati z vzorčenjem |
| [5.7 Scaling](./mcp-scaling/README.md) | Skaliranje | Spoznajte, kako skalirati |
| [5.8 Security](./mcp-security/README.md) | Varnost | Zavarujte vaš MCP strežnik |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP strežnik in odjemalec, ki integrirata SerpAPI za iskanje v realnem času po spletu, novicah, izdelkih in Q&A. Prikazuje orkestracijo več orodij, integracijo zunanjih API-jev in robustno obravnavo napak. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Pretakanje | Pretakanje podatkov v realnem času je danes nujno, saj podjetja in aplikacije potrebujejo takojšen dostop do informacij za pravočasne odločitve.|

## Dodatne reference

Za najnovejše informacije o naprednih temah MCP si oglejte:
- [MCP Dokumentacija](https://modelcontextprotocol.io/)
- [MCP Specifikacija](https://spec.modelcontextprotocol.io/)
- [GitHub Repozitorij](https://github.com/modelcontextprotocol)

## Ključne ugotovitve

- Večmodalne implementacije MCP razširjajo AI zmogljivosti onkraj obdelave besedila
- Razširljivost je ključna za poslovne implementacije in jo lahko rešujemo z horizontalnim in vertikalnim skaliranjem
- Celoviti varnostni ukrepi ščitijo podatke in zagotavljajo ustrezno kontrolo dostopa
- Integracija v podjetja s platformami, kot sta Azure OpenAI in Microsoft AI Foundry, izboljšuje zmogljivosti MCP
- Napredne MCP implementacije koristijo od optimiziranih arhitektur in skrbnega upravljanja virov

## Vaja

Načrtujte MCP implementacijo na ravni podjetja za določen primer uporabe:

1. Določite večmodalne zahteve za vaš primer uporabe
2. Opredelite varnostne kontrole za zaščito občutljivih podatkov
3. Načrtujte razširljivo arhitekturo, ki lahko obvladuje spreminjajoče se obremenitve
4. Načrtujte točke integracije s poslovnimi AI sistemi
5. Dokumentirajte morebitne ozka grla zmogljivosti in strategije za njihovo omilitev

## Dodatni viri

- [Azure OpenAI Dokumentacija](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Dokumentacija](https://learn.microsoft.com/en-us/ai-services/)

---

## Kaj sledi

- [5.1 MCP Integration](./mcp-integration/README.md)

**Opozorilo**:  
Ta dokument je bil preveden z uporabo storitve za prevajanje z umetno inteligenco [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za kritične informacije priporočamo strokovni človeški prevod. Za kakršnekoli nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne prevzemamo odgovornosti.