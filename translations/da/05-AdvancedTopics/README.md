<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "494d87e1c4b9239c70f6a341fcc59a48",
  "translation_date": "2025-06-02T19:09:27+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "da"
}
-->
# Avancerede emner i MCP

Dette kapitel dækker en række avancerede emner inden for implementering af Model Context Protocol (MCP), herunder multimodal integration, skalerbarhed, sikkerhedspraksis og enterprise-integration. Disse emner er afgørende for at bygge robuste og produktionsklare MCP-applikationer, der kan imødekomme kravene fra moderne AI-systemer.

## Oversigt

Denne lektion udforsker avancerede koncepter i implementeringen af Model Context Protocol med fokus på multimodal integration, skalerbarhed, sikkerhedspraksis og enterprise-integration. Disse emner er essentielle for at udvikle produktionsmodne MCP-applikationer, som kan håndtere komplekse krav i enterprise-miljøer.

## Læringsmål

Når du har gennemført denne lektion, vil du kunne:

- Implementere multimodale funktioner inden for MCP-rammer
- Designe skalerbare MCP-arkitekturer til scenarier med høje krav
- Anvende sikkerhedspraksis, der er i overensstemmelse med MCP's sikkerhedsprincipper
- Integrere MCP med enterprise AI-systemer og -rammer
- Optimere ydeevne og pålidelighed i produktionsmiljøer

## Lektioner og eksempler

| Link | Titel | Beskrivelse |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrer med Azure | Lær hvordan du integrerer din MCP Server på Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP Multimodale eksempler | Eksempler på lyd, billede og multimodale svar |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimal Spring Boot-app, der viser OAuth2 med MCP, både som Authorization og Resource Server. Demonstrerer sikker tokenudstedelse, beskyttede endpoints, deployment på Azure Container Apps og integration med API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contexts | Lær mere om root context og hvordan man implementerer dem |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Lær om forskellige typer routing |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Lær hvordan man arbejder med sampling |
| [5.7 Scaling](./mcp-scaling/README.md) | Skalering | Lær om skalering |
| [5.8 Security](./mcp-security/README.md) | Sikkerhed | Sikr din MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP-server og klient, der integrerer med SerpAPI til realtids web-, nyheds-, produkt-søgning og Q&A. Demonstrerer multi-tool orkestrering, ekstern API-integration og robust fejlhåndtering. |

## Yderligere referencer

For den mest opdaterede information om avancerede MCP-emner, se:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Vigtige pointer

- Multimodale MCP-implementeringer udvider AI's kapaciteter ud over tekstbehandling
- Skalerbarhed er afgørende for enterprise-udrulninger og kan håndteres gennem horisontal og vertikal skalering
- Omfattende sikkerhedsforanstaltninger beskytter data og sikrer korrekt adgangskontrol
- Enterprise-integration med platforme som Azure OpenAI og Microsoft AI Foundry forbedrer MCP's muligheder
- Avancerede MCP-implementeringer drager fordel af optimerede arkitekturer og omhyggelig ressourceforvaltning

## Øvelse

Design en enterprise-grade MCP-implementering til et specifikt brugstilfælde:

1. Identificer multimodale krav til dit brugstilfælde
2. Skitser de nødvendige sikkerhedskontroller for at beskytte følsomme data
3. Design en skalerbar arkitektur, der kan håndtere varierende belastning
4. Planlæg integrationspunkter med enterprise AI-systemer
5. Dokumenter potentielle flaskehalse i ydeevnen og strategier til at afbøde dem

## Yderligere ressourcer

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Hvad er det næste

- [5.1 MCP Integration](./mcp-integration/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, skal du være opmærksom på, at automatiske oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.