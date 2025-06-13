<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b1cffc51b82049ac3d5e88db0ff4a0a1",
  "translation_date": "2025-06-13T01:16:05+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "sr"
}
-->
# Napredne teme u MCP-u

Ovo poglavlje pokriva niz naprednih tema u implementaciji Model Context Protocol-a (MCP), uključujući multi-modalnu integraciju, skalabilnost, najbolje prakse za bezbednost i integraciju u preduzećima. Ove teme su ključne za izgradnju stabilnih i spremnih za produkciju MCP aplikacija koje mogu zadovoljiti zahteve savremenih AI sistema.

## Pregled

Ova lekcija istražuje napredne koncepte u implementaciji Model Context Protocol-a, sa fokusom na multi-modalnu integraciju, skalabilnost, najbolje bezbednosne prakse i integraciju u preduzećima. Ove teme su neophodne za pravljenje MCP aplikacija proizvodnog kvaliteta koje mogu da odgovore na složene zahteve u poslovnim okruženjima.

## Ciljevi učenja

Na kraju ove lekcije bićete u stanju da:

- Implementirate multi-modalne mogućnosti unutar MCP okvira
- Dizajnirate skalabilne MCP arhitekture za scenarije sa velikim zahtevima
- Primetite najbolje bezbednosne prakse u skladu sa MCP bezbednosnim principima
- Integrirate MCP sa AI sistemima i okvirima u preduzećima
- Optimizujete performanse i pouzdanost u produkcionim okruženjima

## Lekcije i primeri projekata

| Link | Naslov | Opis |
|------|--------|------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integracija sa Azure | Naučite kako da integrišete svoj MCP Server na Azure platformu |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP Multi modal primeri | Primeri za audio, slike i multi-modalne odgovore |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimalna Spring Boot aplikacija koja prikazuje OAuth2 sa MCP, kao Authorization i Resource Server. Demonstrira sigurno izdavanje tokena, zaštićene krajnje tačke, deployment na Azure Container Apps i integraciju sa API Management-om. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root konteksti | Saznajte više o root kontekstu i kako ih implementirati |
| [5.5 Routing](./mcp-routing/README.md) | Rutiranje | Naučite različite tipove rutiranja |
| [5.6 Sampling](./mcp-sampling/README.md) | Uzorkovanje | Naučite kako da radite sa uzorkovanjem |
| [5.7 Scaling](./mcp-scaling/README.md) | Skaliranje | Naučite o skaliranju |
| [5.8 Security](./mcp-security/README.md) | Bezbednost | Osigurajte svoj MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web pretraga MCP | Python MCP server i klijent integrisani sa SerpAPI za real-time pretragu weba, vesti, proizvoda i Q&A. Prikazuje orkestraciju više alata, integraciju eksternih API-ja i robusno rukovanje greškama. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Real-time streaming podataka postao je neophodan u današnjem svetu vođenom podacima, gde preduzeća i aplikacije zahtevaju trenutni pristup informacijama za pravovremene odluke. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Web pretraga | Kako MCP menja real-time web pretragu pružajući standardizovan pristup upravljanju kontekstom između AI modela, pretraživača i aplikacija. |

## Dodatne reference

Za najnovije informacije o naprednim MCP temama, pogledajte:
- [MCP Dokumentacija](https://modelcontextprotocol.io/)
- [MCP Specifikacija](https://spec.modelcontextprotocol.io/)
- [GitHub Repozitorijum](https://github.com/modelcontextprotocol)

## Ključni zaključci

- Multi-modalne MCP implementacije proširuju AI mogućnosti izvan obrade teksta
- Skalabilnost je ključna za primenu u preduzećima i može se postići horizontalnim i vertikalnim skaliranjem
- Sveobuhvatne bezbednosne mere štite podatke i obezbeđuju odgovarajuću kontrolu pristupa
- Integracija u preduzećima sa platformama poput Azure OpenAI i Microsoft AI Foundry unapređuje MCP mogućnosti
- Napredne MCP implementacije imaju koristi od optimizovanih arhitektura i pažljivog upravljanja resursima

## Vežba

Dizajnirajte MCP implementaciju za preduzeće prema sledećem primeru upotrebe:

1. Identifikujte multi-modalne zahteve za vaš slučaj upotrebe
2. Navedite bezbednosne kontrole potrebne za zaštitu osetljivih podataka
3. Dizajnirajte skalabilnu arhitekturu koja može da podnese različita opterećenja
4. Planirajte tačke integracije sa AI sistemima u preduzećima
5. Dokumentujte potencijalna uska grla u performansama i strategije za njihovo rešavanje

## Dodatni resursi

- [Azure OpenAI Dokumentacija](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Dokumentacija](https://learn.microsoft.com/en-us/ai-services/)

---

## Šta sledi

- [5.1 MCP Integration](./mcp-integration/README.md)

**Ограничење одговорности**:  
Овај документ је преведен коришћењем AI услуге за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако тежимо прецизности, имајте у виду да аутоматизовани преводи могу садржати грешке или нетачности. Изворни документ на његовом оригиналном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешна тумачења настала употребом овог превода.