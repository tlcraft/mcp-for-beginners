<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "671162f2687253f22af11187919ed02d",
  "translation_date": "2025-06-21T13:55:01+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "da"
}
-->
# MCP i praksis: Virkelige casestudier

Model Context Protocol (MCP) ændrer måden, AI-applikationer interagerer med data, værktøjer og tjenester på. Denne sektion præsenterer virkelige casestudier, der viser praktiske anvendelser af MCP i forskellige virksomhedsscenarier.

## Oversigt

Denne sektion fremviser konkrete eksempler på MCP-implementeringer og fremhæver, hvordan organisationer udnytter denne protokol til at løse komplekse forretningsudfordringer. Ved at gennemgå disse casestudier får du indsigt i MCP’s alsidighed, skalerbarhed og praktiske fordele i virkelige situationer.

## Centrale læringsmål

Ved at udforske disse casestudier vil du:

- Forstå, hvordan MCP kan anvendes til at løse specifikke forretningsproblemer
- Lære om forskellige integrationsmønstre og arkitekturtilgange
- Genkende bedste praksis for implementering af MCP i virksomhedsmiljøer
- Få indsigt i udfordringer og løsninger, der opstår i virkelige implementeringer
- Identificere muligheder for at anvende lignende mønstre i dine egne projekter

## Udvalgte casestudier

### 1. [Azure AI Travel Agents – Reference Implementation](./travelagentsample.md)

Dette casestudie undersøger Microsofts omfattende referencesystem, der demonstrerer, hvordan man bygger en multi-agent, AI-drevet rejseplanlægningsapplikation ved hjælp af MCP, Azure OpenAI og Azure AI Search. Projektet fremviser:

- Multi-agent orkestrering via MCP
- Enterprise data integration med Azure AI Search
- Sikker, skalerbar arkitektur med Azure-tjenester
- Udvidelige værktøjer med genanvendelige MCP-komponenter
- Konversationsbaseret brugeroplevelse drevet af Azure OpenAI

Arkitektur- og implementeringsdetaljerne giver værdifuld indsigt i opbygning af komplekse multi-agent systemer med MCP som koordineringslag.

### 2. [Opdatering af Azure DevOps-elementer fra YouTube-data](./UpdateADOItemsFromYT.md)

Dette casestudie viser en praktisk anvendelse af MCP til automatisering af workflow-processer. Det demonstrerer, hvordan MCP-værktøjer kan bruges til at:

- Udtrække data fra online platforme (YouTube)
- Opdatere arbejdsopgaver i Azure DevOps-systemer
- Oprette gentagelige automatiseringsworkflows
- Integrere data på tværs af forskellige systemer

Dette eksempel illustrerer, hvordan selv relativt simple MCP-implementeringer kan give betydelige effektivitetsgevinster ved at automatisere rutineopgaver og forbedre datakonsistens på tværs af systemer.

### 3. [Hentning af dokumentation i realtid med MCP](./docs-mcp/README.md)

Dette casestudie guider dig gennem at forbinde en Python-konsolklient til en Model Context Protocol (MCP) server for at hente og logge Microsoft-dokumentation i realtid med kontekstbevidsthed. Du lærer at:

- Forbinde til en MCP-server med en Python-klient og den officielle MCP SDK
- Bruge streaming HTTP-klienter til effektiv, realtidsdatahentning
- Kalde dokumentationsværktøjer på serveren og logge svar direkte til konsollen
- Integrere opdateret Microsoft-dokumentation i din arbejdsgang uden at forlade terminalen

Kapitel indeholder en praktisk opgave, et minimalt fungerende kodeeksempel og links til yderligere ressourcer for dybere læring. Se den fulde gennemgang og kode i det linkede kapitel for at forstå, hvordan MCP kan revolutionere adgang til dokumentation og udviklerproduktivitet i konsolbaserede miljøer.

### 4. [Interaktiv studieplan-generator webapp med MCP](./docs-mcp/README.md)

Dette casestudie viser, hvordan man bygger en interaktiv webapplikation ved hjælp af Chainlit og Model Context Protocol (MCP) til at generere personlige studieplaner for ethvert emne. Brugere kan angive et fag (f.eks. "AI-900 certificering") og en studieduration (f.eks. 8 uger), hvorefter appen giver en uge-for-uge oversigt over anbefalet indhold. Chainlit muliggør en konversationsbaseret chatgrænseflade, som gør oplevelsen engagerende og tilpasningsdygtig.

- Konversationsbaseret webapp drevet af Chainlit
- Brugerstyrede input for emne og varighed
- Uge-for-uge indholds-anbefalinger via MCP
- Realtids, adaptive svar i chatgrænsefladen

Projektet illustrerer, hvordan konversations-AI og MCP kan kombineres for at skabe dynamiske, brugerfokuserede undervisningsværktøjer i et moderne webmiljø.

### 5. [In-Editor Docs med MCP-server i VS Code](./docs-mcp/README.md)

Dette casestudie viser, hvordan du kan bringe Microsoft Learn Docs direkte ind i dit VS Code-miljø ved hjælp af MCP-serveren – uden at skifte browserfaner! Du vil se, hvordan du kan:

- Søge og læse dokumentation øjeblikkeligt i VS Code via MCP-panelet eller kommandopaletten
- Referere til dokumentation og indsætte links direkte i dine README- eller kursusmarkdownfiler
- Bruge GitHub Copilot og MCP sammen for problemfri, AI-drevet dokumentations- og kodearbejdsgange
- Validere og forbedre din dokumentation med realtids-feedback og Microsoft-sikret nøjagtighed
- Integrere MCP med GitHub workflows til kontinuerlig dokumentationsvalidering

Implementeringen inkluderer:
- Eksempel på `.vscode/mcp.json` konfiguration for nem opsætning
- Skærmbilleder og trin-for-trin gennemgang af in-editor oplevelsen
- Tips til at kombinere Copilot og MCP for maksimal produktivitet

Dette scenarie er ideelt for kursusforfattere, dokumentationsskrivere og udviklere, der ønsker at forblive fokuserede i deres editor, mens de arbejder med docs, Copilot og valideringsværktøjer – alt sammen drevet af MCP.

## Konklusion

Disse casestudier fremhæver Model Context Protocols alsidighed og praktiske anvendelser i virkelige scenarier. Fra komplekse multi-agent systemer til målrettede automatiseringsworkflows tilbyder MCP en standardiseret måde at forbinde AI-systemer med de værktøjer og data, de har brug for, for at skabe værdi.

Ved at studere disse implementeringer kan du få indsigt i arkitekturmønstre, implementeringsstrategier og bedste praksis, som du kan anvende i dine egne MCP-projekter. Eksemplerne viser, at MCP ikke bare er en teoretisk ramme, men en praktisk løsning på reelle forretningsudfordringer.

## Yderligere ressourcer

- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP Server](https://github.com/MicrosoftDocs/mcp)
- [MCP Community Examples](https://github.com/microsoft/mcp)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for eventuelle misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.