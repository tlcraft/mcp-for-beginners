<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-06-13T21:48:40+00:00",
  "source_file": "09-CaseStudy/travelagentsample.md",
  "language_code": "sv"
}
-->
# Fallstudie: Azure AI Travel Agents – Referensimplementation

## Översikt

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) är en omfattande referenslösning utvecklad av Microsoft som visar hur man bygger en AI-driven reseplaneringsapplikation med flera agenter, med hjälp av Model Context Protocol (MCP), Azure OpenAI och Azure AI Search. Projektet demonstrerar bästa praxis för att samordna flera AI-agenter, integrera företagsdata och erbjuda en säker och utbyggbar plattform för verkliga scenarier.

## Huvudfunktioner
- **Multi-Agent Orkestrering:** Använder MCP för att koordinera specialiserade agenter (t.ex. FlightAgent, HotelAgent och ItineraryAgent) som samarbetar för att lösa komplexa reseplaneringsuppgifter.
- **Integration av företagsdata:** Kopplar till Azure AI Search och andra företagsdatakällor för att tillhandahålla aktuell och relevant information för reseförslag.
- **Säker och skalbar arkitektur:** Utnyttjar Azure-tjänster för autentisering, auktorisering och skalbar distribution, enligt företagets säkerhetsriktlinjer.
- **Utbyggbara verktyg:** Implementerar återanvändbara MCP-verktyg och promptmallar, vilket möjliggör snabb anpassning till nya områden eller affärsbehov.
- **Användarupplevelse:** Erbjuder ett konversationsgränssnitt där användare kan interagera med reseagenterna, drivna av Azure OpenAI och MCP.

## Arkitektur
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Beskrivning av arkitekturdiagrammet

Azure AI Travel Agents-lösningen är designad för modularitet, skalbarhet och säker integration av flera AI-agenter och företagsdatakällor. Huvudkomponenterna och dataflödet är följande:

- **User Interface:** Användare interagerar med systemet via ett konversationsgränssnitt (t.ex. en webbchatt eller Teams-bot), som skickar användarfrågor och tar emot reseförslag.
- **MCP Server:** Fungerar som central orkestrator, tar emot användarinmatning, hanterar kontext och koordinerar specialiserade agenter (t.ex. FlightAgent, HotelAgent, ItineraryAgent) via Model Context Protocol.
- **AI Agents:** Varje agent ansvarar för ett specifikt område (flyg, hotell, resplaner) och är implementerad som ett MCP-verktyg. Agenterna använder promptmallar och logik för att bearbeta förfrågningar och generera svar.
- **Azure OpenAI Service:** Erbjuder avancerad naturlig språkförståelse och generering, vilket gör att agenterna kan tolka användarens avsikt och ge konverserande svar.
- **Azure AI Search & Enterprise Data:** Agenterna söker i Azure AI Search och andra företagsdatakällor för att hämta aktuell information om flyg, hotell och resealternativ.
- **Authentication & Security:** Integreras med Microsoft Entra ID för säker autentisering och tillämpar principen om minsta privilegium för åtkomstkontroller till alla resurser.
- **Deployment:** Designad för distribution på Azure Container Apps, vilket säkerställer skalbarhet, övervakning och effektiv drift.

Denna arkitektur möjliggör smidig orkestrering av flera AI-agenter, säker integration med företagsdata och en robust, utbyggbar plattform för att skapa domänspecifika AI-lösningar.

## Steg-för-steg förklaring av arkitekturdiagrammet
Föreställ dig att du planerar en stor resa och har ett team av experthjälpare som assisterar dig med varje detalj. Azure AI Travel Agents-systemet fungerar på liknande sätt, med olika delar (som teammedlemmar) där varje har en särskild uppgift. Så här hänger allt ihop:

### User Interface (UI):
Tänk på detta som din reseagents reception. Här ställer du frågor eller gör förfrågningar, som ”Hitta en flygning till Paris.” Det kan vara ett chattfönster på en webbplats eller en meddelandeapp.

### MCP Server (Koordinatorn):
MCP Server är som chefen som lyssnar på din förfrågan vid receptionen och bestämmer vilken specialist som ska hantera varje del. Den håller koll på din konversation och ser till att allt flyter på smidigt.

### AI Agents (Specialistassistenter):
Varje agent är expert inom sitt område – en kan allt om flyg, en annan om hotell och en tredje om resplanering. När du ber om en resa skickar MCP Server din förfrågan till rätt agent(er). Dessa agenter använder sin kunskap och sina verktyg för att hitta de bästa alternativen åt dig.

### Azure OpenAI Service (Språkexpert):
Detta är som att ha en språkexpert som förstår exakt vad du menar, oavsett hur du formulerar dig. Den hjälper agenterna att tolka dina förfrågningar och svara på ett naturligt, konverserande sätt.

### Azure AI Search & Enterprise Data (Informationsbibliotek):
Föreställ dig ett enormt, uppdaterat bibliotek med all den senaste reseinformationen – flygtider, hotellrumstillgänglighet och mer. Agenterna söker i detta bibliotek för att ge dig de mest korrekta svaren.

### Authentication & Security (Vakt):
Precis som en vakt kontrollerar vem som får komma in på vissa områden, ser denna del till att endast auktoriserade personer och agenter kan nå känslig information. Den skyddar dina data och din integritet.

### Deployment på Azure Container Apps (Byggnaden):
Alla dessa assistenter och verktyg arbetar tillsammans i en säker och skalbar byggnad (molnet). Det innebär att systemet kan hantera många användare samtidigt och alltid finns tillgängligt när du behöver det.

## Hur allt fungerar tillsammans:

Du börjar med att ställa en fråga vid receptionen (UI).
Chefen (MCP Server) avgör vilken specialist (agent) som ska hjälpa dig.
Specialisten använder språkexperten (OpenAI) för att förstå din förfrågan och biblioteket (AI Search) för att hitta bästa svaret.
Vakten (Authentication) ser till att allt är säkert.
Allt detta sker i en pålitlig, skalbar byggnad (Azure Container Apps), så din upplevelse blir smidig och trygg.
Detta samarbete gör att systemet snabbt och säkert kan hjälpa dig att planera din resa, precis som ett team av expertreseagenter som jobbar tillsammans på ett modernt kontor!

## Teknisk implementation
- **MCP Server:** Hanterar kärnlogiken för orkestrering, exponerar agentverktyg och hanterar kontext för flerstegs reseplaneringsflöden.
- **Agents:** Varje agent (t.ex. FlightAgent, HotelAgent) är implementerad som ett MCP-verktyg med egna promptmallar och logik.
- **Azure Integration:** Använder Azure OpenAI för naturlig språkförståelse och Azure AI Search för datahämtning.
- **Security:** Integreras med Microsoft Entra ID för autentisering och tillämpar principen om minsta privilegium för åtkomstkontroller.
- **Deployment:** Stöder distribution till Azure Container Apps för skalbarhet och effektiv drift.

## Resultat och påverkan
- Visar hur MCP kan användas för att orkestrera flera AI-agenter i ett verkligt, produktionsklart scenario.
- Påskyndar lösningsutveckling genom att tillhandahålla återanvändbara mönster för agentkoordinering, dataintegration och säker distribution.
- Fungerar som en mall för att bygga domänspecifika, AI-drivna applikationer med MCP och Azure-tjänster.

## Referenser
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, var vänlig observera att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För viktig information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för några missförstånd eller feltolkningar som uppstår vid användning av denna översättning.