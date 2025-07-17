<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1949cb32394aeb1bdec8870f309005a3",
  "translation_date": "2025-07-17T12:04:56+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "hr"
}
-->
# Napredne teme u MCP-u

Ovo poglavlje obuhvaća niz naprednih tema u implementaciji Model Context Protocola (MCP), uključujući multimodalnu integraciju, skalabilnost, najbolje sigurnosne prakse i integraciju u poslovna okruženja. Ove teme su ključne za izgradnju robusnih i spremnih za produkciju MCP aplikacija koje mogu zadovoljiti zahtjeve suvremenih AI sustava.

## Pregled

Ova lekcija istražuje napredne koncepte u implementaciji Model Context Protocola, s naglaskom na multimodalnu integraciju, skalabilnost, najbolje sigurnosne prakse i integraciju u poslovna okruženja. Ove teme su neophodne za izradu MCP aplikacija proizvodne razine koje mogu podnijeti složene zahtjeve u poslovnim okruženjima.

## Ciljevi učenja

Na kraju ove lekcije moći ćete:

- Implementirati multimodalne mogućnosti unutar MCP okvira
- Dizajnirati skalabilne MCP arhitekture za zahtjevne scenarije
- Primijeniti najbolje sigurnosne prakse usklađene s MCP sigurnosnim principima
- Integrirati MCP s poslovnim AI sustavima i okvirima
- Optimizirati performanse i pouzdanost u produkcijskim okruženjima

## Lekcije i primjeri projekata

| Link | Naslov | Opis |
|------|--------|-------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integracija s Azureom | Naučite kako integrirati svoj MCP Server na Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP multimodalni primjeri | Primjeri za audio, slike i multimodalne odgovore |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimalna Spring Boot aplikacija koja prikazuje OAuth2 s MCP-om, kao Authorization i Resource Server. Demonstrira sigurno izdavanje tokena, zaštićene krajnje točke, implementaciju na Azure Container Apps i integraciju s API Managementom. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root konteksti | Saznajte više o root kontekstu i kako ih implementirati |
| [5.5 Routing](./mcp-routing/README.md) | Usmjeravanje | Naučite različite vrste usmjeravanja |
| [5.6 Sampling](./mcp-sampling/README.md) | Uzorkovanje | Naučite kako raditi s uzorkovanjem |
| [5.7 Scaling](./mcp-scaling/README.md) | Skaliranje | Naučite o skaliranju |
| [5.8 Security](./mcp-security/README.md) | Sigurnost | Osigurajte svoj MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web pretraživanje MCP | Python MCP server i klijent integrirani sa SerpAPI za pretraživanje weba, vijesti, proizvoda i Q&A u stvarnom vremenu. Prikazuje orkestraciju više alata, integraciju vanjskih API-ja i robusno rukovanje pogreškama. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Streaming podataka u stvarnom vremenu postao je ključan u današnjem svijetu vođenom podacima, gdje tvrtke i aplikacije zahtijevaju trenutni pristup informacijama za pravovremene odluke. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Web pretraživanje | Kako MCP transformira pretraživanje weba u stvarnom vremenu pružajući standardizirani pristup upravljanju kontekstom između AI modela, tražilica i aplikacija. |
| [5.12  Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID autentikacija | Microsoft Entra ID pruža snažno rješenje za upravljanje identitetom i pristupom u oblaku, pomažući osigurati da samo ovlašteni korisnici i aplikacije mogu komunicirati s vašim MCP serverom. |
| [5.13 Azure AI Foundry Agent Integration](./mcp-foundry-agent-integration/README.md) | Integracija Azure AI Foundry | Naučite kako integrirati Model Context Protocol servere s Azure AI Foundry agentima, omogućujući snažnu orkestraciju alata i poslovne AI mogućnosti s standardiziranim vezama prema vanjskim izvorima podataka. |

## Dodatne reference

Za najnovije informacije o naprednim MCP temama, pogledajte:
- [MCP Dokumentacija](https://modelcontextprotocol.io/)
- [MCP Specifikacija](https://spec.modelcontextprotocol.io/)
- [GitHub Repozitorij](https://github.com/modelcontextprotocol)

## Ključne spoznaje

- Multimodalne MCP implementacije proširuju AI mogućnosti izvan obrade teksta
- Skalabilnost je ključna za poslovne implementacije i može se postići horizontalnim i vertikalnim skaliranjem
- Sveobuhvatne sigurnosne mjere štite podatke i osiguravaju pravilnu kontrolu pristupa
- Integracija u poslovna okruženja s platformama poput Azure OpenAI i Microsoft AI Foundry povećava MCP mogućnosti
- Napredne MCP implementacije imaju koristi od optimiziranih arhitektura i pažljivog upravljanja resursima

## Vježba

Dizajnirajte MCP implementaciju poslovne razine za specifičan slučaj upotrebe:

1. Identificirajte multimodalne zahtjeve za svoj slučaj upotrebe
2. Nacrtajte sigurnosne kontrole potrebne za zaštitu osjetljivih podataka
3. Dizajnirajte skalabilnu arhitekturu koja može podnijeti varijabilno opterećenje
4. Planirajte točke integracije s poslovnim AI sustavima
5. Dokumentirajte moguće uska grla u performansama i strategije za njihovo ublažavanje

## Dodatni resursi

- [Azure OpenAI Dokumentacija](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Dokumentacija](https://learn.microsoft.com/en-us/ai-services/)

---

## Što slijedi

- [5.1 MCP Integration](./mcp-integration/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.