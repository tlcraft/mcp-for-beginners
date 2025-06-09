<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "494d87e1c4b9239c70f6a341fcc59a48",
  "translation_date": "2025-06-02T19:36:28+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "sr"
}
-->
# Napredne teme u MCP-u

Ovo poglavlje pokriva niz naprednih tema u implementaciji Model Context Protocol (MCP), uključujući multi-modalnu integraciju, skalabilnost, najbolje prakse za bezbednost i integraciju u preduzeća. Ove teme su ključne za izgradnju robusnih i spremnih za produkciju MCP aplikacija koje mogu da zadovolje zahteve savremenih AI sistema.

## Pregled

Ova lekcija istražuje napredne koncepte u implementaciji Model Context Protocol-a, sa fokusom na multi-modalnu integraciju, skalabilnost, najbolje prakse u bezbednosti i integraciju u preduzeća. Ove teme su neophodne za izgradnju MCP aplikacija spremnih za produkciju koje mogu da odgovore na složene zahteve u poslovnim okruženjima.

## Ciljevi učenja

Na kraju ove lekcije bićete u stanju da:

- Implementirate multi-modalne mogućnosti unutar MCP okvira
- Dizajnirate skalabilne MCP arhitekture za scenario sa velikim zahtevima
- Primetite najbolje prakse u bezbednosti u skladu sa MCP bezbednosnim principima
- Integrirate MCP sa AI sistemima i okvirima za preduzeća
- Optimizujete performanse i pouzdanost u produkcionim okruženjima

## Lekcije i primeri projekata

| Link | Naslov | Opis |
|------|--------|-------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integracija sa Azure | Naučite kako da integrišete svoj MCP Server na Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP Multi modalni primeri | Primeri za audio, slike i multi-modalne odgovore |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimalna Spring Boot aplikacija koja prikazuje OAuth2 sa MCP-om, kako kao Authorization, tako i Resource Server. Prikazuje bezbedno izdavanje tokena, zaštićene krajnje tačke, deployment na Azure Container Apps i integraciju sa API Management-om. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root konteksti | Saznajte više o root kontekstu i kako ih implementirati |
| [5.5 Routing](./mcp-routing/README.md) | Rutiranje | Naučite različite tipove rutiranja |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Naučite kako da radite sa samplingom |
| [5.7 Scaling](./mcp-scaling/README.md) | Skaliranje | Naučite o skaliranju |
| [5.8 Security](./mcp-security/README.md) | Bezbednost | Osigurajte svoj MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP server i klijent koji integrišu SerpAPI za pretragu veba, vesti, proizvoda i pitanja i odgovora u realnom vremenu. Prikazuje orkestraciju više alata, integraciju eksternih API-ja i robusno rukovanje greškama. |

## Dodatne reference

Za najnovije informacije o naprednim MCP temama, pogledajte:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Ključne poruke

- Multi-modalne MCP implementacije proširuju AI mogućnosti van obrade teksta
- Skalabilnost je ključna za primenu u preduzećima i može se rešavati horizontalnim i vertikalnim skaliranjem
- Sveobuhvatne mere bezbednosti štite podatke i obezbeđuju odgovarajuću kontrolu pristupa
- Integracija u preduzeća sa platformama kao što su Azure OpenAI i Microsoft AI Foundry poboljšava MCP mogućnosti
- Napredne MCP implementacije imaju koristi od optimizovanih arhitektura i pažljivog upravljanja resursima

## Vežba

Dizajnirajte MCP implementaciju za preduzeće za specifičan slučaj upotrebe:

1. Identifikujte multi-modalne zahteve za vaš slučaj upotrebe
2. Nacrtajte bezbednosne kontrole potrebne za zaštitu osetljivih podataka
3. Dizajnirajte skalabilnu arhitekturu koja može da podnese promenljive opterećenja
4. Planirajte tačke integracije sa AI sistemima u preduzeću
5. Dokumentujte moguće uska grla u performansama i strategije za njihovo ublažavanje

## Dodatni resursi

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Šta sledi

- [5.1 MCP Integration](./mcp-integration/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korišćenjem AI servisa za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo tačnosti, imajte na umu da automatski prevodi mogu sadržati greške ili netačnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prevod. Ne snosimo odgovornost za bilo kakva nesporazumevanja ili pogrešna tumačenja nastala korišćenjem ovog prevoda.