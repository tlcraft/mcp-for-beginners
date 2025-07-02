<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "748c61250d4a326206b72b28f6154615",
  "translation_date": "2025-07-02T09:34:55+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "no"
}
-->
# Avanserte emner i MCP

Dette kapitlet tar for seg en rekke avanserte temaer innen implementering av Model Context Protocol (MCP), inkludert multimodal integrasjon, skalerbarhet, sikkerhetspraksis og bedriftsintegrasjon. Disse temaene er avgjørende for å bygge robuste og produksjonsklare MCP-applikasjoner som kan møte kravene til moderne AI-systemer.

## Oversikt

Denne leksjonen utforsker avanserte konsepter i implementeringen av Model Context Protocol, med fokus på multimodal integrasjon, skalerbarhet, sikkerhetspraksis og bedriftsintegrasjon. Disse temaene er viktige for å utvikle MCP-applikasjoner av produksjonskvalitet som kan håndtere komplekse krav i bedriftsmiljøer.

## Læringsmål

Etter denne leksjonen skal du kunne:

- Implementere multimodale funksjoner i MCP-rammeverk
- Designe skalerbare MCP-arkitekturer for krevende scenarioer
- Anvende sikkerhetspraksis i tråd med MCPs sikkerhetsprinsipper
- Integrere MCP med bedrifts-AI-systemer og rammeverk
- Optimalisere ytelse og pålitelighet i produksjonsmiljøer

## Leksjoner og eksempelprosjekter

| Link | Tittel | Beskrivelse |
|------|--------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrasjon med Azure | Lær hvordan du integrerer MCP-serveren din på Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP multimodale eksempler | Eksempler for lyd, bilde og multimodale svar |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2-demo | Minimal Spring Boot-app som viser OAuth2 med MCP, både som Authorization og Resource Server. Demonstrerer sikker tokenutstedelse, beskyttede endepunkter, Azure Container Apps-distribusjon og API Management-integrasjon. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contexts | Lær mer om root context og hvordan du implementerer dem |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Lær om forskjellige typer routing |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Lær hvordan du jobber med sampling |
| [5.7 Scaling](./mcp-scaling/README.md) | Skalerbarhet | Lær om skalering |
| [5.8 Security](./mcp-security/README.md) | Sikkerhet | Sikre MCP-serveren din |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP-server og klient som integrerer med SerpAPI for sanntidssøk på web, nyheter, produkter og Q&A. Demonstrerer flerverktøysorkestrering, ekstern API-integrasjon og robust feilhåndtering. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Sanntids datastrømming har blitt essensielt i dagens datadrevne verden, der bedrifter og applikasjoner krever umiddelbar tilgang til informasjon for å ta raske beslutninger. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Web Search | Sanntidssøk på web: hvordan MCP forvandler sanntidssøk ved å tilby en standardisert tilnærming til kontekststyring på tvers av AI-modeller, søkemotorer og applikasjoner. |
| [5.12 Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID-autentisering | Microsoft Entra ID tilbyr en robust skybasert løsning for identitets- og tilgangsstyring, som sikrer at kun autoriserte brukere og applikasjoner kan samhandle med MCP-serveren din. |
| [5.13 Azure AI Foundry Agent Integration](./mcp-foundry-agent-integration/README.md) | Azure AI Foundry-integrasjon | Lær hvordan du integrerer Model Context Protocol-servere med Azure AI Foundry-agenter, som muliggjør kraftig verktøyorkestrering og bedrifts-AI-funksjoner med standardiserte tilkoblinger til eksterne datakilder. |

## Ytterligere referanser

For den mest oppdaterte informasjonen om avanserte MCP-temaer, se:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Viktige punkter

- Multimodale MCP-implementeringer utvider AI-muligheter utover tekstbehandling
- Skalerbarhet er essensielt for bedriftsdistribusjoner og kan løses gjennom horisontal og vertikal skalering
- Omfattende sikkerhetstiltak beskytter data og sikrer riktig tilgangskontroll
- Bedriftsintegrasjon med plattformer som Azure OpenAI og Microsoft AI Foundry styrker MCP-funksjonaliteten
- Avanserte MCP-implementeringer drar nytte av optimaliserte arkitekturer og nøye ressursstyring

## Øvelse

Design en MCP-implementering av bedriftsnivå for en spesifikk brukstilfelle:

1. Identifiser multimodale krav for brukstilfellet ditt
2. Skisser sikkerhetskontroller som trengs for å beskytte sensitiv data
3. Design en skalerbar arkitektur som kan håndtere varierende belastning
4. Planlegg integrasjonspunkter med bedrifts-AI-systemer
5. Dokumenter potensielle ytelsesflaskehalser og strategier for å redusere dem

## Ytterligere ressurser

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Hva skjer videre

- [5.1 MCP Integration](./mcp-integration/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på originalspråket skal anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.