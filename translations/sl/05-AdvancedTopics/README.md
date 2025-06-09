<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "494d87e1c4b9239c70f6a341fcc59a48",
  "translation_date": "2025-06-02T19:40:03+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "sl"
}
-->
# Napredne teme u MCP-u

Ovo poglavlje pokriva niz naprednih tema u implementaciji Model Context Protocola (MCP), uključujući multimodalnu integraciju, skalabilnost, najbolje sigurnosne prakse i integraciju u poduzećima. Ove teme su ključne za izgradnju robusnih i spremnih za produkciju MCP aplikacija koje mogu zadovoljiti zahtjeve modernih AI sustava.

## Pregled

Ova lekcija istražuje napredne koncepte u implementaciji Model Context Protocol-a, s fokusom na multimodalnu integraciju, skalabilnost, najbolje sigurnosne prakse i integraciju u poduzećima. Ove teme su važne za razvoj MCP aplikacija za produkciju koje mogu podnijeti složene zahtjeve u poslovnim okruženjima.

## Ciljevi učenja

Na kraju ove lekcije moći ćete:

- Implementirati multimodalne mogućnosti unutar MCP okvira
- Dizajnirati skalabilne MCP arhitekture za scenarije visokih zahtjeva
- Primijeniti najbolje sigurnosne prakse usklađene sa sigurnosnim principima MCP-a
- Integrirati MCP s AI sustavima i okvirima u poduzećima
- Optimizirati performanse i pouzdanost u produkcijskim okruženjima

## Lekcije i primjeri projekata

| Link | Naslov | Opis |
|------|--------|-------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integracija s Azureom | Naučite kako integrirati svoj MCP Server na Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP multimodalni primjeri | Primjeri za audio, sliku i multimodalne odgovore |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 demo | Minimalna Spring Boot aplikacija koja pokazuje OAuth2 s MCP-om, kao Authorization i Resource Server. Demonstrira sigurno izdavanje tokena, zaštićene endpoint-e, implementaciju na Azure Container Apps i integraciju s API Managementom. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root konteksti | Saznajte više o root kontekstu i kako ih implementirati |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Naučite različite vrste usmjeravanja |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Naučite kako raditi sa samplingom |
| [5.7 Scaling](./mcp-scaling/README.md) | Skaliranje | Naučite o skaliranju |
| [5.8 Security](./mcp-security/README.md) | Sigurnost | Osigurajte svoj MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP server i klijent integrirani sa SerpAPI za pretraživanje weba, vijesti, proizvoda i Q&A u stvarnom vremenu. Demonstrira orkestraciju više alata, integraciju vanjskih API-ja i robusno rukovanje greškama. |

## Dodatne reference

Za najnovije informacije o naprednim MCP temama, pogledajte:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Ključni zaključci

- Multimodalne MCP implementacije proširuju AI mogućnosti izvan obrade teksta
- Skalabilnost je ključna za implementacije u poduzećima i može se riješiti horizontalnim i vertikalnim skaliranjem
- Sveobuhvatne sigurnosne mjere štite podatke i osiguravaju pravilnu kontrolu pristupa
- Integracija u poduzećima s platformama poput Azure OpenAI i Microsoft AI Foundry povećava mogućnosti MCP-a
- Napredne MCP implementacije koriste optimizirane arhitekture i pažljivo upravljanje resursima

## Vježba

Dizajnirajte MCP implementaciju za poduzeće za određeni slučaj upotrebe:

1. Identificirajte multimodalne zahtjeve za vaš slučaj upotrebe
2. Nacrtajte sigurnosne kontrole potrebne za zaštitu osjetljivih podataka
3. Dizajnirajte skalabilnu arhitekturu koja može podnijeti varijabilno opterećenje
4. Planirajte točke integracije s AI sustavima u poduzeću
5. Dokumentirajte moguće uska grla u performansama i strategije za njihovo ublažavanje

## Dodatni resursi

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Što slijedi

- [5.1 MCP Integration](./mcp-integration/README.md)

**Opozorilo**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvor­nem jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Za morebitne nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.