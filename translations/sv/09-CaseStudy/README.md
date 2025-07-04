<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "873741da08dd6537858d5e14c3a386e1",
  "translation_date": "2025-07-04T17:33:32+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "sv"
}
-->
# MCP i praktiken: Fallstudier från verkligheten

Model Context Protocol (MCP) förändrar hur AI-applikationer interagerar med data, verktyg och tjänster. Denna sektion presenterar verkliga fallstudier som visar praktiska tillämpningar av MCP i olika företagsmiljöer.

## Översikt

Här visas konkreta exempel på MCP-implementationer, med fokus på hur organisationer använder detta protokoll för att lösa komplexa affärsutmaningar. Genom att studera dessa fallstudier får du insikter i MCP:s mångsidighet, skalbarhet och praktiska fördelar i verkliga situationer.

## Viktiga lärandemål

Genom att utforska dessa fallstudier kommer du att:

- Förstå hur MCP kan användas för att lösa specifika affärsproblem
- Lära dig om olika integrationsmönster och arkitektoniska tillvägagångssätt
- Känna igen bästa praxis för att implementera MCP i företagsmiljöer
- Få insikter i utmaningar och lösningar som uppstått vid verkliga implementationer
- Identifiera möjligheter att använda liknande mönster i dina egna projekt

## Utvalda fallstudier

### 1. [Azure AI Travel Agents – Referensimplementation](./travelagentsample.md)

Denna fallstudie granskar Microsofts omfattande referenslösning som visar hur man bygger en multi-agent, AI-driven reseplaneringsapplikation med MCP, Azure OpenAI och Azure AI Search. Projektet visar:

- Multi-agent orkestrering via MCP
- Företagsdataintegration med Azure AI Search
- Säker och skalbar arkitektur med Azure-tjänster
- Utbyggbara verktyg med återanvändbara MCP-komponenter
- Konversationsbaserad användarupplevelse driven av Azure OpenAI

Arkitekturen och implementationsdetaljerna ger värdefulla insikter i hur man bygger komplexa multi-agent-system med MCP som samordningslager.

### 2. [Uppdatera Azure DevOps-objekt från YouTube-data](./UpdateADOItemsFromYT.md)

Denna fallstudie visar en praktisk användning av MCP för att automatisera arbetsflöden. Den visar hur MCP-verktyg kan användas för att:

- Extrahera data från onlineplattformar (YouTube)
- Uppdatera arbetsobjekt i Azure DevOps-system
- Skapa upprepbara automatiseringsflöden
- Integrera data mellan olika system

Exemplet illustrerar hur även relativt enkla MCP-implementationer kan ge betydande effektivitetsvinster genom att automatisera rutinuppgifter och förbättra datakonsistens mellan system.

### 3. [Dokumentationshämtning i realtid med MCP](./docs-mcp/README.md)

Denna fallstudie guidar dig genom att koppla en Python-konsolklient till en MCP-server för att hämta och logga realtids-, kontextmedveten Microsoft-dokumentation. Du lär dig hur du:

- Ansluter till en MCP-server med en Python-klient och den officiella MCP SDK:n
- Använder streaming HTTP-klienter för effektiv realtidsdatahämtning
- Anropar dokumentationsverktyg på servern och loggar svar direkt i konsolen
- Integrerar uppdaterad Microsoft-dokumentation i ditt arbetsflöde utan att lämna terminalen

Kapitel innehåller en praktisk uppgift, ett minimalt fungerande kodexempel och länkar till ytterligare resurser för fördjupning. Se hela genomgången och koden i det länkade kapitlet för att förstå hur MCP kan förändra tillgången till dokumentation och utvecklarproduktivitet i konsolbaserade miljöer.

### 4. [Interaktiv studieplansgenerator-webbapp med MCP](./docs-mcp/README.md)

Denna fallstudie visar hur man bygger en interaktiv webbapplikation med Chainlit och Model Context Protocol (MCP) för att generera personliga studieplaner för valfritt ämne. Användare kan ange ett ämne (t.ex. "AI-900 certification") och studietid (t.ex. 8 veckor), och appen ger en veckovis uppdelning av rekommenderat innehåll. Chainlit möjliggör en konversationsbaserad chattgränssnitt som gör upplevelsen engagerande och anpassningsbar.

- Konversationsbaserad webbapp driven av Chainlit
- Användardrivna frågor om ämne och tidsram
- Veckovisa innehållsrekommendationer med MCP
- Realtids- och adaptiva svar i chattgränssnitt

Projektet visar hur konversations-AI och MCP kan kombineras för att skapa dynamiska, användardrivna utbildningsverktyg i en modern webbmiljö.

### 5. [Dokumentation i editorn med MCP-server i VS Code](./docs-mcp/README.md)

Denna fallstudie visar hur du kan få Microsoft Learn Docs direkt i din VS Code-miljö med hjälp av MCP-servern – inga fler flikbyten i webbläsaren! Du får se hur du kan:

- Söka och läsa dokumentation direkt i VS Code via MCP-panelen eller kommandopaletten
- Referera dokumentation och infoga länkar direkt i README- eller kursmarkdownfiler
- Använda GitHub Copilot och MCP tillsammans för sömlösa AI-drivna dokumentations- och kodflöden
- Validera och förbättra din dokumentation med realtidsfeedback och Microsoft-säkerställd noggrannhet
- Integrera MCP med GitHub-flöden för kontinuerlig dokumentationsvalidering

Implementationen inkluderar:
- Exempel på `.vscode/mcp.json`-konfiguration för enkel uppsättning
- Skärmdumpsbaserade genomgångar av upplevelsen i editorn
- Tips för att kombinera Copilot och MCP för maximal produktivitet

Detta scenario är perfekt för kursförfattare, dokumentationsskrivare och utvecklare som vill hålla fokus i editorn samtidigt som de arbetar med dokumentation, Copilot och valideringsverktyg – allt drivet av MCP.

### 6. [Skapa MCP-server med APIM](./apimsample.md)

Denna fallstudie ger en steg-för-steg-guide för hur man skapar en MCP-server med Azure API Management (APIM). Den täcker:

- Uppsättning av MCP-server i Azure API Management
- Exponering av API-operationer som MCP-verktyg
- Konfigurering av policyer för hastighetsbegränsning och säkerhet
- Testning av MCP-servern med Visual Studio Code och GitHub Copilot

Exemplet visar hur man kan utnyttja Azures kapabiliteter för att skapa en robust MCP-server som kan användas i olika applikationer och förbättra integrationen av AI-system med företags-API:er.

## Slutsats

Dessa fallstudier belyser Model Context Protocols mångsidighet och praktiska användningsområden i verkliga situationer. Från komplexa multi-agent-system till riktade automatiseringsflöden erbjuder MCP ett standardiserat sätt att koppla AI-system till de verktyg och data de behöver för att skapa värde.

Genom att studera dessa implementationer kan du få insikter i arkitekturmönster, implementeringsstrategier och bästa praxis som kan tillämpas i dina egna MCP-projekt. Exemplen visar att MCP inte bara är en teoretisk ram utan en praktisk lösning på verkliga affärsutmaningar.

## Ytterligare resurser

- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP Server](https://github.com/MicrosoftDocs/mcp)
- [MCP Community Examples](https://github.com/microsoft/mcp)

Nästa: Hands on Lab [Streamlining AI Workflows: Building an MCP Server with AI Toolkit](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen observera att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för några missförstånd eller feltolkningar som uppstår till följd av användningen av denna översättning.