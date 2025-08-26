<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "61a160248efabe92b09d7b08293d17db",
  "translation_date": "2025-08-18T15:05:31+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "da"
}
-->
# MCP i Aktion: Virkelige Case Studier

[![MCP i Aktion: Virkelige Case Studier](../../../translated_images/10.3262cc80b4de5071fde8ba74c5c5d6738a0a9f398dcc0423f0210f632e2238b8.da.png)](https://youtu.be/IxshWb2Az5w)

_(Klik på billedet ovenfor for at se videoen til denne lektion)_

Model Context Protocol (MCP) revolutionerer, hvordan AI-applikationer interagerer med data, værktøjer og tjenester. Denne sektion præsenterer virkelige case studier, der viser praktiske anvendelser af MCP i forskellige virksomhedsscenarier.

## Oversigt

Denne sektion fremhæver konkrete eksempler på MCP-implementeringer og viser, hvordan organisationer bruger protokollen til at løse komplekse forretningsudfordringer. Ved at undersøge disse case studier får du indsigt i MCP's alsidighed, skalerbarhed og praktiske fordele i virkelige situationer.

## Centrale Læringsmål

Ved at udforske disse case studier vil du:

- Forstå, hvordan MCP kan anvendes til at løse specifikke forretningsproblemer
- Lære om forskellige integrationsmønstre og arkitektoniske tilgange
- Genkende bedste praksis for implementering af MCP i virksomhedsmiljøer
- Få indsigt i de udfordringer og løsninger, der opstår i virkelige implementeringer
- Identificere muligheder for at anvende lignende mønstre i dine egne projekter

## Udvalgte Case Studier

### 1. [Azure AI Rejseagenter – Referenceimplementering](./travelagentsample.md)

Denne case studie undersøger Microsofts omfattende referencesolution, der viser, hvordan man bygger en multi-agent, AI-drevet rejseplanlægningsapplikation ved hjælp af MCP, Azure OpenAI og Azure AI Search. Projektet fremhæver:

- Multi-agent orkestrering via MCP
- Integration af virksomhedsdata med Azure AI Search
- Sikker, skalerbar arkitektur ved brug af Azure-tjenester
- Udvidelige værktøjer med genanvendelige MCP-komponenter
- Konversationsbaseret brugeroplevelse drevet af Azure OpenAI

Arkitekturen og implementeringsdetaljerne giver værdifuld indsigt i opbygningen af komplekse, multi-agent systemer med MCP som koordineringslag.

### 2. [Opdatering af Azure DevOps-elementer fra YouTube-data](./UpdateADOItemsFromYT.md)

Denne case studie viser en praktisk anvendelse af MCP til automatisering af arbejdsprocesser. Den demonstrerer, hvordan MCP-værktøjer kan bruges til at:

- Udtrække data fra online platforme (YouTube)
- Opdatere arbejdsopgaver i Azure DevOps-systemer
- Skabe gentagelige automatiseringsarbejdsgange
- Integrere data på tværs af forskellige systemer

Dette eksempel illustrerer, hvordan selv relativt simple MCP-implementeringer kan give betydelige effektivitetsgevinster ved at automatisere rutineopgaver og forbedre datakonsistens på tværs af systemer.

### 3. [Dokumentationshentning i realtid med MCP](./docs-mcp/README.md)

Denne case studie guider dig gennem processen med at forbinde en Python-konsolklient til en Model Context Protocol (MCP)-server for at hente og logge realtids-, kontekstafhængig Microsoft-dokumentation. Du lærer, hvordan man:

- Forbinder til en MCP-server ved hjælp af en Python-klient og den officielle MCP SDK
- Bruger streaming HTTP-klienter til effektiv datahentning i realtid
- Kalder dokumentationsværktøjer på serveren og logger svar direkte til konsollen
- Integrerer opdateret Microsoft-dokumentation i din arbejdsgang uden at forlade terminalen

Kapitlet inkluderer en praktisk opgave, en minimal fungerende kodeeksempel og links til yderligere ressourcer for dybere læring. Se den fulde gennemgang og kode i det linkede kapitel for at forstå, hvordan MCP kan transformere dokumentationsadgang og udviklerproduktivitet i konsolbaserede miljøer.

### 4. [Interaktiv Studieplan Generator Web App med MCP](./docs-mcp/README.md)

Denne case studie viser, hvordan man bygger en interaktiv webapplikation ved hjælp af Chainlit og Model Context Protocol (MCP) til at generere personlige studieplaner for ethvert emne. Brugere kan angive et emne (såsom "AI-900 certificering") og en studielængde (f.eks. 8 uger), og appen vil levere en uge-for-uge oversigt over anbefalet indhold. Chainlit muliggør en konversationsbaseret chatgrænseflade, der gør oplevelsen engagerende og tilpasselig.

- Konversationsbaseret webapp drevet af Chainlit
- Brugerstyrede prompts for emne og varighed
- Uge-for-uge indholdsanbefalinger ved hjælp af MCP
- Realtids, adaptive svar i en chatgrænseflade

Projektet illustrerer, hvordan konversationsbaseret AI og MCP kan kombineres for at skabe dynamiske, brugerdrevne uddannelsesværktøjer i et moderne webmiljø.

### 5. [Dokumentation i Editor med MCP Server i VS Code](./docs-mcp/README.md)

Denne case studie viser, hvordan du kan bringe Microsoft Learn Docs direkte ind i dit VS Code-miljø ved hjælp af MCP-serveren—ingen flere skift mellem browserfaner! Du vil se, hvordan man:

- Søger og læser dokumentation direkte i VS Code ved hjælp af MCP-panelet eller kommandopaletten
- Refererer dokumentation og indsætter links direkte i dine README- eller kursus-markdownfiler
- Bruger GitHub Copilot og MCP sammen for sømløse, AI-drevne dokumentations- og kodearbejdsgange
- Validerer og forbedrer din dokumentation med realtidsfeedback og Microsoft-sourced nøjagtighed
- Integrerer MCP med GitHub-arbejdsgange for kontinuerlig dokumentationsvalidering

Implementeringen inkluderer:

- Eksempel på `.vscode/mcp.json` konfiguration for nem opsætning
- Skærmbaserede gennemgange af editoroplevelsen
- Tips til at kombinere Copilot og MCP for maksimal produktivitet

Dette scenarie er ideelt for kursusforfattere, dokumentationsskrivere og udviklere, der ønsker at forblive fokuserede i deres editor, mens de arbejder med dokumentation, Copilot og valideringsværktøjer—alt sammen drevet af MCP.

### 6. [Oprettelse af APIM MCP Server](./apimsample.md)

Denne case studie giver en trin-for-trin guide til, hvordan man opretter en MCP-server ved hjælp af Azure API Management (APIM). Den dækker:

- Opsætning af en MCP-server i Azure API Management
- Eksponering af API-operationer som MCP-værktøjer
- Konfiguration af politikker for hastighedsbegrænsning og sikkerhed
- Test af MCP-serveren ved hjælp af Visual Studio Code og GitHub Copilot

Dette eksempel illustrerer, hvordan man kan udnytte Azures kapaciteter til at oprette en robust MCP-server, der kan bruges i forskellige applikationer og forbedre integrationen af AI-systemer med virksomhedens API'er.

## Konklusion

Disse case studier fremhæver MCP's alsidighed og praktiske anvendelser i virkelige scenarier. Fra komplekse multi-agent systemer til målrettede automatiseringsarbejdsgange giver MCP en standardiseret måde at forbinde AI-systemer med de værktøjer og data, de har brug for for at levere værdi.

Ved at studere disse implementeringer kan du få indsigt i arkitektoniske mønstre, implementeringsstrategier og bedste praksis, der kan anvendes i dine egne MCP-projekter. Eksemplerne viser, at MCP ikke kun er en teoretisk ramme, men en praktisk løsning på reelle forretningsudfordringer.

## Yderligere Ressourcer

- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP Server](https://github.com/MicrosoftDocs/mcp)
- [MCP Community Examples](https://github.com/microsoft/mcp)

Næste: Hands on Lab [Streamlining AI Workflows: Building an MCP Server with AI Toolkit](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, skal du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det originale dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os ikke ansvar for eventuelle misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.