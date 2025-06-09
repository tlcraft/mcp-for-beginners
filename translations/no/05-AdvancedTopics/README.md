<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "494d87e1c4b9239c70f6a341fcc59a48",
  "translation_date": "2025-06-02T19:11:05+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "no"
}
-->
# Avanserte emner i MCP

Dette kapittelet dekker en rekke avanserte temaer innen implementering av Model Context Protocol (MCP), inkludert multimodal integrasjon, skalerbarhet, sikkerhetspraksis og bedriftsintegrasjon. Disse temaene er viktige for å bygge robuste og produksjonsklare MCP-applikasjoner som kan møte kravene til moderne AI-systemer.

## Oversikt

Denne leksjonen utforsker avanserte konsepter i implementeringen av Model Context Protocol, med fokus på multimodal integrasjon, skalerbarhet, sikkerhetspraksis og bedriftsintegrasjon. Disse temaene er avgjørende for å utvikle produksjonsklare MCP-applikasjoner som kan håndtere komplekse krav i bedriftsmiljøer.

## Læringsmål

Etter denne leksjonen vil du kunne:

- Implementere multimodale funksjoner innen MCP-rammeverk
- Designe skalerbare MCP-arkitekturer for høybelastede scenarioer
- Anvende sikkerhetspraksis i tråd med MCPs sikkerhetsprinsipper
- Integrere MCP med bedrifts-AI-systemer og rammeverk
- Optimalisere ytelse og pålitelighet i produksjonsmiljøer

## Leksjoner og eksempler på prosjekter

| Lenke | Tittel | Beskrivelse |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrasjon med Azure | Lær hvordan du integrerer MCP Serveren din på Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP multimodale eksempler | Eksempler på lyd, bilde og multimodale responser |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimal Spring Boot-app som viser OAuth2 med MCP, både som autorisasjons- og ressursserver. Demonstrerer sikker token-utstedelse, beskyttede endepunkter, Azure Container Apps-distribusjon og API Management-integrasjon. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root-kontekster | Lær mer om root-kontekster og hvordan implementere dem |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Lær om ulike typer routing |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Lær hvordan du jobber med sampling |
| [5.7 Scaling](./mcp-scaling/README.md) | Skalering | Lær om skalering |
| [5.8 Security](./mcp-security/README.md) | Sikkerhet | Sikre MCP Serveren din |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP-server og klient som integrerer med SerpAPI for sanntidssøk på web, nyheter, produkter og Q&A. Demonstrerer multi-verktøyorchestrering, ekstern API-integrasjon og robust feilhåndtering. |

## Ytterligere referanser

For oppdatert informasjon om avanserte MCP-temaer, se:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Viktige punkter

- Multimodale MCP-implementeringer utvider AI-kapasiteter utover tekstbehandling
- Skalerbarhet er avgjørende for bedriftsdistribusjoner og kan løses gjennom horisontal og vertikal skalering
- Omfattende sikkerhetstiltak beskytter data og sikrer riktig tilgangskontroll
- Bedriftsintegrasjon med plattformer som Azure OpenAI og Microsoft AI Foundry styrker MCP-kapasiteter
- Avanserte MCP-implementeringer drar nytte av optimaliserte arkitekturer og nøye ressursstyring

## Øvelse

Design en bedriftsklar MCP-implementering for et spesifikt bruksområde:

1. Identifiser multimodale krav for ditt bruksområde
2. Skisser sikkerhetskontroller som trengs for å beskytte sensitiv data
3. Design en skalerbar arkitektur som kan håndtere varierende belastning
4. Planlegg integrasjonspunkter med bedrifts-AI-systemer
5. Dokumenter potensielle ytelsesflaskehalser og strategier for å håndtere disse

## Ytterligere ressurser

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Hva nå

- [5.1 MCP Integration](./mcp-integration/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiserte oversettelser kan inneholde feil eller unøyaktigheter. Det originale dokumentet på dets opprinnelige språk bør betraktes som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.