<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "873741da08dd6537858d5e14c3a386e1",
  "translation_date": "2025-07-04T17:43:04+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "no"
}
-->
# MCP i praksis: Virkelige casestudier

Model Context Protocol (MCP) endrer hvordan AI-applikasjoner samhandler med data, verktøy og tjenester. Denne seksjonen presenterer virkelige casestudier som viser praktiske anvendelser av MCP i ulike bedriftsmiljøer.

## Oversikt

Her vises konkrete eksempler på MCP-implementasjoner, med fokus på hvordan organisasjoner bruker denne protokollen for å løse komplekse forretningsutfordringer. Ved å studere disse casestudiene får du innsikt i MCPs allsidighet, skalerbarhet og praktiske fordeler i virkelige situasjoner.

## Viktige læringsmål

Ved å utforske disse casestudiene vil du:

- Forstå hvordan MCP kan brukes til å løse spesifikke forretningsproblemer
- Lære om ulike integrasjonsmønstre og arkitektoniske tilnærminger
- Kjenne til beste praksis for implementering av MCP i bedriftsmiljøer
- Få innsikt i utfordringer og løsninger som oppstår i virkelige implementasjoner
- Identifisere muligheter for å bruke lignende mønstre i egne prosjekter

## Utvalgte casestudier

### 1. [Azure AI Travel Agents – Referanseimplementasjon](./travelagentsample.md)

Denne casestudien undersøker Microsofts omfattende referanseløsning som viser hvordan man bygger en multi-agent, AI-drevet reiseplanleggingsapplikasjon ved hjelp av MCP, Azure OpenAI og Azure AI Search. Prosjektet demonstrerer:

- Multi-agent orkestrering gjennom MCP
- Integrasjon av bedriftsdata med Azure AI Search
- Sikker og skalerbar arkitektur med Azure-tjenester
- Utvidbare verktøy med gjenbrukbare MCP-komponenter
- Samtaleorientert brukeropplevelse drevet av Azure OpenAI

Arkitekturen og implementasjonsdetaljene gir verdifull innsikt i hvordan man bygger komplekse multi-agent systemer med MCP som koordineringslag.

### 2. [Oppdatering av Azure DevOps-elementer fra YouTube-data](./UpdateADOItemsFromYT.md)

Denne casestudien viser en praktisk bruk av MCP for automatisering av arbeidsflyter. Den demonstrerer hvordan MCP-verktøy kan brukes til å:

- Hente data fra nettplattformer (YouTube)
- Oppdatere arbeidsoppgaver i Azure DevOps-systemer
- Lage repeterbare automatiseringsprosesser
- Integrere data på tvers av ulike systemer

Dette eksempelet illustrerer hvordan selv relativt enkle MCP-implementasjoner kan gi betydelige effektivitetsgevinster ved å automatisere rutineoppgaver og forbedre datakonsistens på tvers av systemer.

### 3. [Sanntidsdokumentasjon med MCP](./docs-mcp/README.md)

Denne casestudien viser hvordan du kobler en Python-konsollklient til en Model Context Protocol (MCP)-server for å hente og logge sanntids, kontekstbevisst Microsoft-dokumentasjon. Du lærer hvordan du kan:

- Koble til en MCP-server med en Python-klient og den offisielle MCP SDK-en
- Bruke streaming HTTP-klienter for effektiv sanntidshenting av data
- Kalle dokumentasjonsverktøy på serveren og logge svar direkte til konsollen
- Integrere oppdatert Microsoft-dokumentasjon i arbeidsflyten uten å forlate terminalen

Kapittelet inkluderer en praktisk oppgave, et minimalt fungerende kodeeksempel og lenker til flere ressurser for dypere læring. Se hele gjennomgangen og koden i det tilknyttede kapittelet for å forstå hvordan MCP kan revolusjonere tilgang til dokumentasjon og utviklerproduktivitet i konsollbaserte miljøer.

### 4. [Interaktiv studieplan-generator webapp med MCP](./docs-mcp/README.md)

Denne casestudien viser hvordan man bygger en interaktiv webapplikasjon ved hjelp av Chainlit og Model Context Protocol (MCP) for å generere personlige studieplaner for ethvert emne. Brukere kan spesifisere et fag (for eksempel "AI-900 sertifisering") og en studietid (f.eks. 8 uker), og appen gir en uke-for-uke oversikt over anbefalt innhold. Chainlit muliggjør en samtaleorientert chatgrensesnitt som gjør opplevelsen engasjerende og tilpasningsdyktig.

- Samtaleorientert webapp drevet av Chainlit
- Brukerstyrte spørsmål om tema og varighet
- Uke-for-uke innholds-anbefalinger ved hjelp av MCP
- Sanntids, adaptive svar i chatgrensesnitt

Prosjektet viser hvordan samtale-AI og MCP kan kombineres for å lage dynamiske, brukerstyrte læringsverktøy i et moderne webmiljø.

### 5. [Dokumentasjon i editor med MCP-server i VS Code](./docs-mcp/README.md)

Denne casestudien viser hvordan du kan hente Microsoft Learn Docs direkte inn i VS Code-miljøet ditt ved hjelp av MCP-serveren – ingen flere bytter mellom nettleserfaner! Du vil se hvordan du kan:

- Søke og lese dokumentasjon umiddelbart i VS Code via MCP-panelet eller kommandopaletten
- Referere dokumentasjon og sette inn lenker direkte i README- eller kursmarkdown-filer
- Bruke GitHub Copilot og MCP sammen for sømløse, AI-drevne dokumentasjons- og kodearbeidsflyter
- Validere og forbedre dokumentasjonen med sanntids tilbakemeldinger og Microsoft-godkjent nøyaktighet
- Integrere MCP med GitHub-arbeidsflyter for kontinuerlig dokumentasjonsvalidering

Implementeringen inkluderer:
- Eksempel på `.vscode/mcp.json`-konfigurasjon for enkel oppsett
- Skjermbildebaserte gjennomganger av opplevelsen i editoren
- Tips for å kombinere Copilot og MCP for maksimal produktivitet

Dette scenariet passer perfekt for kursforfattere, dokumentasjonsforfattere og utviklere som ønsker å holde fokus i editoren mens de jobber med dokumentasjon, Copilot og valideringsverktøy – alt drevet av MCP.

### 6. [Opprettelse av APIM MCP-server](./apimsample.md)

Denne casestudien gir en steg-for-steg guide for hvordan man oppretter en MCP-server ved hjelp av Azure API Management (APIM). Den dekker:

- Oppsett av MCP-server i Azure API Management
- Eksponering av API-operasjoner som MCP-verktøy
- Konfigurering av policyer for ratebegrensning og sikkerhet
- Testing av MCP-serveren med Visual Studio Code og GitHub Copilot

Dette eksempelet viser hvordan man kan utnytte Azures muligheter for å lage en robust MCP-server som kan brukes i ulike applikasjoner, og forbedre integrasjonen av AI-systemer med bedrifts-API-er.

## Konklusjon

Disse casestudiene fremhever MCPs allsidighet og praktiske anvendelser i virkelige situasjoner. Fra komplekse multi-agent systemer til målrettede automatiseringsarbeidsflyter gir MCP en standardisert måte å koble AI-systemer til verktøy og data de trenger for å skape verdi.

Ved å studere disse implementasjonene kan du få innsikt i arkitekturmønstre, implementeringsstrategier og beste praksis som kan brukes i dine egne MCP-prosjekter. Eksemplene viser at MCP ikke bare er et teoretisk rammeverk, men en praktisk løsning på reelle forretningsutfordringer.

## Ytterligere ressurser

- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP Server](https://github.com/MicrosoftDocs/mcp)
- [MCP Community Examples](https://github.com/microsoft/mcp)

Neste: Hands on Lab [Streamlining AI Workflows: Building an MCP Server with AI Toolkit](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på originalspråket skal anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.