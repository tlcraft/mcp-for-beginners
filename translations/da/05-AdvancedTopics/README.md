<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b96f2864e0bcb6fae9b4926813c3feb1",
  "translation_date": "2025-06-26T14:05:11+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "da"
}
-->
# Avancerede emner i MCP

Dette kapitel dækker en række avancerede emner inden for implementering af Model Context Protocol (MCP), herunder multimodal integration, skalerbarhed, sikkerhedspraksis og enterprise-integration. Disse emner er afgørende for at bygge robuste og produktionsklare MCP-applikationer, der kan imødekomme kravene fra moderne AI-systemer.

## Oversigt

Denne lektion udforsker avancerede koncepter i implementeringen af Model Context Protocol med fokus på multimodal integration, skalerbarhed, sikkerhedspraksis og enterprise-integration. Disse emner er essentielle for at bygge MCP-applikationer i produktionskvalitet, der kan håndtere komplekse krav i erhvervsmiljøer.

## Læringsmål

Når du har gennemført denne lektion, vil du kunne:

- Implementere multimodale funktioner inden for MCP-rammer
- Designe skalerbare MCP-arkitekturer til scenarier med høj efterspørgsel
- Anvende sikkerhedspraksis i overensstemmelse med MCP's sikkerhedsprincipper
- Integrere MCP med enterprise AI-systemer og -rammer
- Optimere ydeevne og pålidelighed i produktionsmiljøer

## Lektioner og eksempler på projekter

| Link | Titel | Beskrivelse |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrer med Azure | Lær hvordan du integrerer din MCP Server på Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP Multimodale eksempler | Eksempler på lyd, billede og multimodale svar |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimal Spring Boot-app der viser OAuth2 med MCP, både som Authorization og Resource Server. Demonstrerer sikker token-udstedelse, beskyttede endpoints, Azure Container Apps-udrulning og API Management-integration. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contexts | Lær mere om root context og hvordan du implementerer dem |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Lær om forskellige typer routing |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Lær hvordan du arbejder med sampling |
| [5.7 Scaling](./mcp-scaling/README.md) | Skalering | Lær om skalering |
| [5.8 Security](./mcp-security/README.md) | Sikkerhed | Sikr din MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP-server og klient, der integrerer med SerpAPI for realtids web-, nyheds-, produkt-søgning og Q&A. Demonstrerer multi-værktøjs orkestrering, ekstern API-integration og robust fejlhåndtering. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Realtids data-streaming er blevet essentielt i dagens datadrevne verden, hvor virksomheder og applikationer har brug for øjeblikkelig adgang til information for at træffe rettidige beslutninger. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Web Search | Realtids web-søgning – hvordan MCP forvandler realtids web-søgning ved at tilbyde en standardiseret tilgang til kontekststyring på tværs af AI-modeller, søgemaskiner og applikationer. |
| [5.12  Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID Authentication | Microsoft Entra ID tilbyder en robust cloud-baseret identitets- og adgangsstyringsløsning, der sikrer, at kun autoriserede brugere og applikationer kan interagere med din MCP-server. |

## Yderligere referencer

For den mest opdaterede information om avancerede MCP-emner, se:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Vigtige pointer

- Multimodale MCP-implementeringer udvider AI’s kapaciteter ud over tekstbehandling
- Skalerbarhed er afgørende for enterprise-udrulninger og kan håndteres gennem horisontal og vertikal skalering
- Omfattende sikkerhedsforanstaltninger beskytter data og sikrer korrekt adgangskontrol
- Enterprise-integration med platforme som Azure OpenAI og Microsoft AI Foundry styrker MCP’s muligheder
- Avancerede MCP-implementeringer drager fordel af optimerede arkitekturer og omhyggelig ressourcehåndtering

## Øvelse

Design en enterprise-kvalitets MCP-implementering til et specifikt brugstilfælde:

1. Identificer multimodale krav til dit brugstilfælde  
2. Skitser de nødvendige sikkerhedskontroller for at beskytte følsomme data  
3. Design en skalerbar arkitektur, der kan håndtere varierende belastning  
4. Planlæg integrationspunkter med enterprise AI-systemer  
5. Dokumentér potentielle performanceflaskehalse og strategier til at afhjælpe dem

## Yderligere ressourcer

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Hvad er det næste

- [5.1 MCP Integration](./mcp-integration/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.