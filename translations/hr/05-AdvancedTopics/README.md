<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "adaf47734a5839447b5c60a27120fbaf",
  "translation_date": "2025-06-11T16:30:59+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "hr"
}
-->
# Napredne teme u MCP-u

Ovo poglavlje pokriva niz naprednih tema u implementaciji Model Context Protocola (MCP), uključujući multi-modalnu integraciju, skalabilnost, najbolje sigurnosne prakse i integraciju u poslovna okruženja. Ove teme su ključne za izgradnju robusnih i spremnih za proizvodnju MCP aplikacija koje mogu zadovoljiti zahtjeve modernih AI sustava.

## Pregled

Ova lekcija istražuje napredne koncepte u implementaciji Model Context Protocola, fokusirajući se na multi-modalnu integraciju, skalabilnost, najbolje sigurnosne prakse i integraciju u poslovna okruženja. Ove teme su neophodne za izgradnju MCP aplikacija za proizvodnju koje mogu podnijeti složene zahtjeve u poslovnim okruženjima.

## Ciljevi učenja

Do kraja ove lekcije moći ćete:

- Implementirati multi-modalne mogućnosti unutar MCP okvira
- Dizajnirati skalabilne MCP arhitekture za scenarije visokih zahtjeva
- Primijeniti najbolje sigurnosne prakse usklađene s principima sigurnosti MCP-a
- Integrirati MCP s poslovnim AI sustavima i okvirima
- Optimizirati performanse i pouzdanost u proizvodnim okruženjima

## Lekcije i primjeri projekata

| Link | Naslov | Opis |
|------|--------|-------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integracija s Azure | Naučite kako integrirati svoj MCP Server na Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP primjeri multi-modalnosti | Primjeri za audio, slike i multi-modalne odgovore |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimalna Spring Boot aplikacija koja pokazuje OAuth2 s MCP-om, kao Authorization i Resource Server. Demonstrira sigurno izdavanje tokena, zaštićene krajnje točke, implementaciju na Azure Container Apps i integraciju s API Managementom. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root konteksti | Saznajte više o root kontekstu i kako ih implementirati |
| [5.5 Routing](./mcp-routing/README.md) | Usmjeravanje | Naučite različite vrste usmjeravanja |
| [5.6 Sampling](./mcp-sampling/README.md) | Uzorkovanje | Naučite kako raditi s uzorkovanjem |
| [5.7 Scaling](./mcp-scaling/README.md) | Skaliranje | Naučite o skaliranju |
| [5.8 Security](./mcp-security/README.md) | Sigurnost | Osigurajte svoj MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web pretraživanje MCP | Python MCP server i klijent integrirani sa SerpAPI za pretraživanje weba, vijesti, proizvoda i Q&A u stvarnom vremenu. Pokazuje orkestraciju više alata, integraciju vanjskih API-ja i robusno upravljanje pogreškama. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Streaming podataka u stvarnom vremenu postao je ključan u današnjem svijetu vođenom podacima, gdje poslovanja i aplikacije zahtijevaju trenutni pristup informacijama za pravovremene odluke.|

## Dodatne reference

Za najnovije informacije o naprednim MCP temama, pogledajte:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Ključni zaključci

- Multi-modalne MCP implementacije proširuju AI mogućnosti izvan obrade teksta
- Skalabilnost je ključna za poslovne implementacije i može se postići horizontalnim i vertikalnim skaliranjem
- Sveobuhvatne sigurnosne mjere štite podatke i osiguravaju pravilnu kontrolu pristupa
- Integracija u poslovna okruženja s platformama poput Azure OpenAI i Microsoft AI Foundry poboljšava MCP mogućnosti
- Napredne MCP implementacije imaju koristi od optimiziranih arhitektura i pažljivog upravljanja resursima

## Vježba

Dizajnirajte MCP implementaciju razine poduzeća za određeni slučaj upotrebe:

1. Identificirajte multi-modalne zahtjeve za svoj slučaj upotrebe
2. Nacrtajte sigurnosne kontrole potrebne za zaštitu osjetljivih podataka
3. Dizajnirajte skalabilnu arhitekturu koja može podnijeti varijabilno opterećenje
4. Planirajte integracijske točke s poslovnim AI sustavima
5. Dokumentirajte moguće uska grla u performansama i strategije za njihovo ublažavanje

## Dodatni resursi

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Što slijedi

- [5.1 MCP Integration](./mcp-integration/README.md)

**Odricanje od odgovornosti**:  
Ovaj je dokument preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba se smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili kriva tumačenja koja proizlaze iz korištenja ovog prijevoda.