<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b6b1bc868efed4cf02c52f8deada559d",
  "translation_date": "2025-05-17T17:29:20+00:00",
  "source_file": "09-CaseStudy/Readme.md",
  "language_code": "sv"
}
-->
# Fallstudie: Azure AI Travel Agents – Referensimplementation

## Översikt

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) är en omfattande referenslösning utvecklad av Microsoft som visar hur man bygger en AI-driven reseplaneringsapplikation med flera agenter genom att använda Model Context Protocol (MCP), Azure OpenAI och Azure AI Search. Projektet visar bästa praxis för att orkestrera flera AI-agenter, integrera företagsdata och tillhandahålla en säker, utbyggbar plattform för verkliga scenarier.

## Viktiga funktioner
- **Orkestrering av flera agenter:** Använder MCP för att samordna specialiserade agenter (t.ex. flyg-, hotell- och resplaneringsagenter) som samarbetar för att utföra komplexa reseplaneringsuppgifter.
- **Integration av företagsdata:** Ansluter till Azure AI Search och andra företagsdatakällor för att tillhandahålla aktuell, relevant information för reseförslag.
- **Säker, skalbar arkitektur:** Utnyttjar Azure-tjänster för autentisering, auktorisering och skalbar distribution, i enlighet med företagens säkerhetsbästa praxis.
- **Utbyggbara verktyg:** Implementerar återanvändbara MCP-verktyg och promptmallar, vilket möjliggör snabb anpassning till nya domäner eller affärskrav.
- **Användarupplevelse:** Erbjuder ett konversationsgränssnitt för användare att interagera med reseagenterna, drivet av Azure OpenAI och MCP.

## Arkitektur
![Arkitektur](https://github.com/Azure-Samples/azure-ai-travel-agents/blob/main/docs/ai-travel-agents-architecture-diagram.png)

### Beskrivning av arkitekturdiagrammet

Lösningen Azure AI Travel Agents är utformad för modularitet, skalbarhet och säker integration av flera AI-agenter och företagsdatakällor. De viktigaste komponenterna och dataflödet är som följer:

- **Användargränssnitt:** Användare interagerar med systemet via ett konversationsgränssnitt (som en webbchatt eller Teams-bot), som skickar användarförfrågningar och tar emot reserekomendationer.
- **MCP Server:** Tjänar som den centrala orkestratorn, tar emot användarinmatningar, hanterar kontext och koordinerar specialiserade agenters handlingar (t.ex. FlightAgent, HotelAgent, ItineraryAgent) via Model Context Protocol.
- **AI-agenter:** Varje agent ansvarar för ett specifikt område (flyg, hotell, resplaner) och implementeras som ett MCP-verktyg. Agenter använder promptmallar och logik för att behandla förfrågningar och generera svar.
- **Azure OpenAI-tjänst:** Tillhandahåller avancerad förståelse och generering av naturligt språk, vilket gör det möjligt för agenter att tolka användarens avsikter och generera konverserande svar.
- **Azure AI Search & företagsdata:** Agenter söker i Azure AI Search och andra företagsdatakällor för att hämta aktuell information om flyg, hotell och resealternativ.
- **Autentisering & säkerhet:** Integreras med Microsoft Entra ID för säker autentisering och tillämpar minsta möjliga åtkomstkontroller till alla resurser.
- **Distribution:** Designad för distribution på Azure Container Apps, vilket säkerställer skalbarhet, övervakning och operativ effektivitet.

Denna arkitektur möjliggör sömlös orkestrering av flera AI-agenter, säker integration med företagsdata och en robust, utbyggbar plattform för att bygga domänspecifika AI-lösningar.

## Steg-för-steg-förklaring av arkitekturdiagrammet
Tänk dig att planera en stor resa och ha ett team av experthjälpare som hjälper dig med varje detalj. Azure AI Travel Agents-systemet fungerar på ett liknande sätt, med olika delar (som teammedlemmar) som var och en har ett speciellt jobb. Så här passar allt ihop:

### Användargränssnitt (UI):
Tänk på detta som din reseagents reception. Det är där du (användaren) ställer frågor eller gör förfrågningar, som "Hitta ett flyg till Paris." Detta kan vara ett chattfönster på en webbplats eller en meddelandeapp.

### MCP Server (Koordinatorn):
MCP Server är som chefen som lyssnar på din förfrågan vid receptionen och bestämmer vilken specialist som ska hantera varje del. Den håller reda på din konversation och ser till att allt flyter på smidigt.

### AI-agenter (Specialistassistenter):
Varje agent är expert inom ett specifikt område – en kan allt om flyg, en annan om hotell och en annan om att planera din resplan. När du begär en resa skickar MCP Server din förfrågan till rätt agent(er). Dessa agenter använder sin kunskap och sina verktyg för att hitta de bästa alternativen för dig.

### Azure OpenAI-tjänst (Språkexpert):
Detta är som att ha en språkexpert som förstår exakt vad du frågar efter, oavsett hur du uttrycker det. Det hjälper agenterna att förstå dina förfrågningar och svara på ett naturligt, konverserande språk.

### Azure AI Search & företagsdata (Informationsbibliotek):
Föreställ dig ett stort, aktuellt bibliotek med all den senaste reseinformationen – flygscheman, hotelltillgänglighet och mer. Agenterna söker i detta bibliotek för att få de mest exakta svaren åt dig.

### Autentisering & säkerhet (Säkerhetsvakt):
Precis som en säkerhetsvakt kontrollerar vem som kan komma in i vissa områden, ser denna del till att endast auktoriserade personer och agenter kan komma åt känslig information. Det håller dina data säkra och privata.

### Distribution på Azure Container Apps (Byggnaden):
Alla dessa assistenter och verktyg arbetar tillsammans inom en säker, skalbar byggnad (molnet). Detta innebär att systemet kan hantera många användare samtidigt och alltid är tillgängligt när du behöver det.

## Hur allt fungerar tillsammans:

Du börjar med att ställa en fråga vid receptionen (UI).
Chefen (MCP Server) listar ut vilken specialist (agent) som ska hjälpa dig.
Specialisten använder språkexperten (OpenAI) för att förstå din förfrågan och biblioteket (AI Search) för att hitta det bästa svaret.
Säkerhetsvakten (Autentisering) ser till att allt är säkert.
Allt detta sker inom en pålitlig, skalbar byggnad (Azure Container Apps), så din upplevelse är smidig och säker.
Detta teamwork gör det möjligt för systemet att snabbt och säkert hjälpa dig att planera din resa, precis som ett team av expertreseagenter som arbetar tillsammans i ett modernt kontor!

## Teknisk implementering
- **MCP Server:** Värd för den centrala orkestreringslogiken, exponerar agentverktyg och hanterar kontext för reseplaneringsarbetsflöden i flera steg.
- **Agenter:** Varje agent (t.ex. FlightAgent, HotelAgent) implementeras som ett MCP-verktyg med egna promptmallar och logik.
- **Azure-integration:** Använder Azure OpenAI för förståelse av naturligt språk och Azure AI Search för datahämtning.
- **Säkerhet:** Integreras med Microsoft Entra ID för autentisering och tillämpar minsta möjliga åtkomstkontroller till alla resurser.
- **Distribution:** Stöder distribution till Azure Container Apps för skalbarhet och operativ effektivitet.

## Resultat och påverkan
- Visar hur MCP kan användas för att orkestrera flera AI-agenter i ett verkligt, produktionsklart scenario.
- Påskyndar lösningsutveckling genom att tillhandahålla återanvändbara mönster för agentkoordination, dataintegration och säker distribution.
- Tjänar som en mall för att bygga domänspecifika, AI-drivna applikationer med MCP och Azure-tjänster.

## Referenser
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, var medveten om att automatiska översättningar kan innehålla fel eller felaktigheter. Det ursprungliga dokumentet på dess ursprungliga språk bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för eventuella missförstånd eller feltolkningar som uppstår vid användning av denna översättning.