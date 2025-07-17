<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1949cb32394aeb1bdec8870f309005a3",
  "translation_date": "2025-07-17T06:39:22+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "no"
}
-->
# Avanserte emner i MCP

Dette kapitlet dekker en rekke avanserte temaer innen implementering av Model Context Protocol (MCP), inkludert multimodal integrasjon, skalerbarhet, sikkerhetsrutiner og bedriftsintegrasjon. Disse temaene er avgjørende for å bygge robuste og produksjonsklare MCP-applikasjoner som kan møte kravene til moderne AI-systemer.

## Oversikt

Denne leksjonen utforsker avanserte konsepter i implementeringen av Model Context Protocol, med fokus på multimodal integrasjon, skalerbarhet, sikkerhetsrutiner og bedriftsintegrasjon. Disse temaene er viktige for å utvikle produksjonsklare MCP-applikasjoner som kan håndtere komplekse krav i bedriftsmiljøer.

## Læringsmål

Etter denne leksjonen skal du kunne:

- Implementere multimodale funksjoner innen MCP-rammeverk
- Designe skalerbare MCP-arkitekturer for krevende scenarier
- Anvende sikkerhetsrutiner i tråd med MCPs sikkerhetsprinsipper
- Integrere MCP med bedrifts-AI-systemer og rammeverk
- Optimalisere ytelse og pålitelighet i produksjonsmiljøer

## Leksjoner og eksempler på prosjekter

| Link | Tittel | Beskrivelse |
|------|--------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrasjon med Azure | Lær hvordan du integrerer MCP-serveren din på Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP multimodale eksempler | Eksempler på lyd, bilde og multimodale svar |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2-demo | Minimal Spring Boot-app som viser OAuth2 med MCP, både som autorisasjons- og ressursserver. Demonstrerer sikker tokenutstedelse, beskyttede endepunkter, distribusjon på Azure Container Apps og integrasjon med API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Rotkontekster | Lær mer om rotkontekst og hvordan du implementerer dem |
| [5.5 Routing](./mcp-routing/README.md) | Rutestyring | Lær om ulike typer rutestyring |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Lær hvordan du jobber med sampling |
| [5.7 Scaling](./mcp-scaling/README.md) | Skalering | Lær om skalering |
| [5.8 Security](./mcp-security/README.md) | Sikkerhet | Sikre MCP-serveren din |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP-server og klient som integrerer med SerpAPI for sanntidssøk på web, nyheter, produkter og Q&A. Demonstrerer flerverktøysorkestrering, ekstern API-integrasjon og robust feilhåndtering. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Sanntidsdatastreaming har blitt essensielt i dagens datadrevne verden, hvor bedrifter og applikasjoner trenger umiddelbar tilgang til informasjon for å ta raske beslutninger. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Web Search | Sanntidssøk på web: hvordan MCP forvandler sanntidssøk ved å tilby en standardisert tilnærming til kontekststyring på tvers av AI-modeller, søkemotorer og applikasjoner. |
| [5.12  Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID-autentisering | Microsoft Entra ID tilbyr en robust skybasert løsning for identitets- og tilgangsstyring, som sikrer at kun autoriserte brukere og applikasjoner kan kommunisere med MCP-serveren din. |
| [5.13 Azure AI Foundry Agent Integration](./mcp-foundry-agent-integration/README.md) | Azure AI Foundry-integrasjon | Lær hvordan du integrerer Model Context Protocol-servere med Azure AI Foundry-agenter, som muliggjør kraftig verktøyorkestrering og bedrifts-AI-funksjonalitet med standardiserte tilkoblinger til eksterne datakilder. |

## Ytterligere referanser

For den mest oppdaterte informasjonen om avanserte MCP-temaer, se:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Viktige punkter

- Multimodale MCP-implementeringer utvider AI-funksjonalitet utover tekstbehandling
- Skalerbarhet er avgjørende for bedriftsdistribusjoner og kan løses gjennom horisontal og vertikal skalering
- Omfattende sikkerhetstiltak beskytter data og sikrer riktig tilgangskontroll
- Bedriftsintegrasjon med plattformer som Azure OpenAI og Microsoft AI Foundry styrker MCP-funksjonaliteten
- Avanserte MCP-implementeringer drar nytte av optimaliserte arkitekturer og nøye ressursstyring

## Øvelse

Design en MCP-implementering på bedriftsnivå for et spesifikt bruksområde:

1. Identifiser multimodale krav for ditt bruksområde
2. Skisser sikkerhetskontroller som trengs for å beskytte sensitiv data
3. Design en skalerbar arkitektur som kan håndtere varierende belastning
4. Planlegg integrasjonspunkter med bedrifts-AI-systemer
5. Dokumenter potensielle ytelsesflaskehalser og strategier for å redusere dem

## Ytterligere ressurser

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Hva nå

- [5.1 MCP Integration](./mcp-integration/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på originalspråket skal anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.