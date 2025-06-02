<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "494d87e1c4b9239c70f6a341fcc59a48",
  "translation_date": "2025-06-02T19:38:23+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "hr"
}
-->
# Napredne teme u MCP-u

Ovo poglavlje pokriva niz naprednih tema u implementaciji Model Context Protocola (MCP), uključujući višemodalnu integraciju, skalabilnost, najbolje sigurnosne prakse i integraciju u poslovna okruženja. Ove teme su ključne za izgradnju robusnih i spremnih za produkciju MCP aplikacija koje mogu zadovoljiti zahtjeve suvremenih AI sustava.

## Pregled

Ova lekcija istražuje napredne koncepte u implementaciji Model Context Protocol-a, fokusirajući se na višemodalnu integraciju, skalabilnost, najbolje sigurnosne prakse i integraciju u poslovna okruženja. Ove teme su neophodne za razvoj produkcijski orijentiranih MCP aplikacija koje mogu upravljati složenim zahtjevima u poslovnim okruženjima.

## Ciljevi učenja

Do kraja ove lekcije moći ćete:

- Implementirati višemodalne mogućnosti unutar MCP okvira
- Dizajnirati skalabilne MCP arhitekture za scenarije velike potražnje
- Primijeniti najbolje sigurnosne prakse usklađene s MCP sigurnosnim principima
- Integrirati MCP s poslovnim AI sustavima i okvirima
- Optimizirati performanse i pouzdanost u produkcijskim okruženjima

## Lekcije i primjeri projekata

| Link | Naslov | Opis |
|------|--------|-------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integracija s Azureom | Naučite kako integrirati svoj MCP Server na Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP višemodalni primjeri | Primjeri za audio, slike i višemodalne odgovore |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimalna Spring Boot aplikacija koja pokazuje OAuth2 s MCP-om, kao Authorization i Resource Server. Prikazuje sigurno izdavanje tokena, zaštićene krajnje točke, implementaciju na Azure Container Apps i integraciju API Managementa. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root konteksti | Saznajte više o root kontekstu i kako ih implementirati |
| [5.5 Routing](./mcp-routing/README.md) | Usmjeravanje | Naučite različite vrste usmjeravanja |
| [5.6 Sampling](./mcp-sampling/README.md) | Uzorkovanje | Naučite kako raditi s uzorkovanjem |
| [5.7 Scaling](./mcp-scaling/README.md) | Skaliranje | Naučite o skaliranju |
| [5.8 Security](./mcp-security/README.md) | Sigurnost | Osigurajte svoj MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web pretraživanje MCP | Python MCP server i klijent integrirani sa SerpAPI za pretraživanje weba, vijesti, proizvoda i Q&A u stvarnom vremenu. Pokazuje višestruku orkestraciju alata, integraciju vanjskih API-ja i robusno upravljanje greškama. |

## Dodatne reference

Za najnovije informacije o naprednim MCP temama, pogledajte:
- [MCP Dokumentacija](https://modelcontextprotocol.io/)
- [MCP Specifikacija](https://spec.modelcontextprotocol.io/)
- [GitHub Repozitorij](https://github.com/modelcontextprotocol)

## Ključne spoznaje

- Višemodalne MCP implementacije proširuju AI mogućnosti izvan obrade teksta
- Skalabilnost je ključna za poslovne implementacije i može se postići horizontalnim i vertikalnim skaliranjem
- Sveobuhvatne sigurnosne mjere štite podatke i osiguravaju pravilnu kontrolu pristupa
- Poslovna integracija s platformama poput Azure OpenAI i Microsoft AI Foundry povećava mogućnosti MCP-a
- Napredne MCP implementacije koriste optimizirane arhitekture i pažljivo upravljanje resursima

## Vježba

Dizajnirajte MCP implementaciju za poslovne potrebe za određeni slučaj upotrebe:

1. Identificirajte višemodalne zahtjeve za vaš slučaj upotrebe
2. Nacrtajte sigurnosne kontrole potrebne za zaštitu osjetljivih podataka
3. Dizajnirajte skalabilnu arhitekturu koja može podnijeti varijabilno opterećenje
4. Planirajte točke integracije s poslovnim AI sustavima
5. Dokumentirajte moguće uska grla u performansama i strategije za njihovo rješavanje

## Dodatni resursi

- [Azure OpenAI Dokumentacija](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Dokumentacija](https://learn.microsoft.com/en-us/ai-services/)

---

## Što slijedi

- [5.1 MCP Integration](./mcp-integration/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument preveden je korištenjem AI prevoditeljskog servisa [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili kriva tumačenja koja proizlaze iz korištenja ovog prijevoda.