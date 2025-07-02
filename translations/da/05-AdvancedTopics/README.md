<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "748c61250d4a326206b72b28f6154615",
  "translation_date": "2025-07-02T09:33:18+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "da"
}
-->
# Avancerede emner i MCP

Dette kapitel dækker en række avancerede emner inden for implementering af Model Context Protocol (MCP), herunder multimodal integration, skalerbarhed, sikkerhedspraksis og enterprise-integration. Disse emner er afgørende for at bygge robuste og produktionsklare MCP-applikationer, der kan imødekomme kravene fra moderne AI-systemer.

## Oversigt

Denne lektion udforsker avancerede koncepter i implementeringen af Model Context Protocol med fokus på multimodal integration, skalerbarhed, sikkerhedspraksis og enterprise-integration. Disse emner er essentielle for at bygge produktionsklare MCP-applikationer, der kan håndtere komplekse krav i enterprise-miljøer.

## Læringsmål

Når du har gennemført denne lektion, vil du kunne:

- Implementere multimodale funktioner inden for MCP-rammer
- Designe skalerbare MCP-arkitekturer til højbelastede scenarier
- Anvende sikkerhedspraksis, der er i overensstemmelse med MCP’s sikkerhedsprincipper
- Integrere MCP med enterprise AI-systemer og -rammer
- Optimere ydeevne og pålidelighed i produktionsmiljøer

## Lektioner og eksempler på projekter

| Link | Titel | Beskrivelse |
|------|-------|-------------|
| [5.1 Integration med Azure](./mcp-integration/README.md) | Integration med Azure | Lær hvordan du integrerer din MCP Server på Azure |
| [5.2 Multimodal eksempel](./mcp-multi-modality/README.md) | MCP multimodale eksempler | Eksempler på lyd, billede og multimodale svar |
| [5.3 MCP OAuth2 eksempel](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimal Spring Boot-app der viser OAuth2 med MCP, både som Authorization og Resource Server. Demonstrerer sikker tokenudstedelse, beskyttede endpoints, Azure Container Apps deployment og API Management integration. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contexts | Lær mere om root context og hvordan du implementerer dem |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Lær om forskellige typer routing |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Lær hvordan du arbejder med sampling |
| [5.7 Skalering](./mcp-scaling/README.md) | Skalering | Lær om skalering |
| [5.8 Sikkerhed](./mcp-security/README.md) | Sikkerhed | Sikr din MCP Server |
| [5.9 Web Search eksempel](./web-search-mcp/README.md) | Web Search MCP | Python MCP-server og klient, der integrerer med SerpAPI for realtidsweb-, nyheds-, produkt-søgning og Q&A. Demonstrerer multi-tool orkestrering, ekstern API-integration og robust fejlhåndtering. |
| [5.10 Realtidsstreaming](./mcp-realtimestreaming/README.md) | Streaming | Realtidsdata-streaming er blevet essentielt i nutidens datadrevne verden, hvor virksomheder og applikationer kræver øjeblikkelig adgang til information for at træffe rettidige beslutninger. |
| [5.11 Realtids websøgning](./mcp-realtimesearch/README.md) | Web Search | Realtids websøgning – hvordan MCP transformerer realtids websøgning ved at tilbyde en standardiseret tilgang til kontekststyring på tværs af AI-modeller, søgemaskiner og applikationer. |
| [5.12 Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID Authentication | Microsoft Entra ID tilbyder en robust cloud-baseret identitets- og adgangsstyringsløsning, der hjælper med at sikre, at kun autoriserede brugere og applikationer kan interagere med din MCP-server. |
| [5.13 Azure AI Foundry Agent Integration](./mcp-foundry-agent-integration/README.md) | Azure AI Foundry Integration | Lær hvordan du integrerer Model Context Protocol-servere med Azure AI Foundry-agenter, hvilket muliggør kraftfuld værktøjsorkestrering og enterprise AI-funktioner med standardiserede forbindelser til eksterne datakilder. |

## Yderligere referencer

For den mest opdaterede information om avancerede MCP-emner, se:
- [MCP Dokumentation](https://modelcontextprotocol.io/)
- [MCP Specifikation](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Vigtige pointer

- Multimodale MCP-implementeringer udvider AI’s kapaciteter ud over tekstbehandling
- Skalerbarhed er afgørende for enterprise-implementeringer og kan håndteres gennem horisontal og vertikal skalering
- Omfattende sikkerhedsforanstaltninger beskytter data og sikrer korrekt adgangskontrol
- Enterprise-integration med platforme som Azure OpenAI og Microsoft AI Foundry forbedrer MCP’s kapaciteter
- Avancerede MCP-implementeringer drager fordel af optimerede arkitekturer og omhyggelig ressourcestyring

## Øvelse

Design en enterprise-klasse MCP-implementering til en specifik brugssag:

1. Identificer multimodale krav til din brugssag  
2. Skitser de sikkerhedskontroller, der er nødvendige for at beskytte følsomme data  
3. Design en skalerbar arkitektur, der kan håndtere varierende belastning  
4. Planlæg integrationspunkter med enterprise AI-systemer  
5. Dokumenter potentielle performance-flaskehalse og afhjælpningsstrategier  

## Yderligere ressourcer

- [Azure OpenAI Dokumentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Dokumentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Hvad er næste skridt

- [5.1 MCP Integration](./mcp-integration/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der måtte opstå som følge af brugen af denne oversættelse.