<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-06-13T21:49:16+00:00",
  "source_file": "09-CaseStudy/travelagentsample.md",
  "language_code": "no"
}
-->
# Case Study: Azure AI Reiseagenter – Referanseimplementasjon

## Oversikt

[Azure AI Reiseagenter](https://github.com/Azure-Samples/azure-ai-travel-agents) er en omfattende referanseløsning utviklet av Microsoft som viser hvordan man bygger en fleretatters, AI-drevet reiseplanleggingsapplikasjon ved bruk av Model Context Protocol (MCP), Azure OpenAI og Azure AI Search. Dette prosjektet demonstrerer beste praksis for å koordinere flere AI-agenter, integrere bedriftsdata, og tilby en sikker og utvidbar plattform for virkelige scenarier.

## Nøkkelfunksjoner
- **Multi-Agent Orkestrering:** Bruker MCP for å koordinere spesialiserte agenter (f.eks. fly-, hotell- og reiseruteagenter) som samarbeider for å løse komplekse reiseplanleggingsoppgaver.
- **Integrasjon av bedriftsdata:** Knytter til Azure AI Search og andre bedriftsdatakilder for å levere oppdatert og relevant informasjon til reiseanbefalinger.
- **Sikker og skalerbar arkitektur:** Benytter Azure-tjenester for autentisering, autorisasjon og skalerbar distribusjon, i tråd med beste praksis innen bedriftsikkerhet.
- **Utvidbare verktøy:** Implementerer gjenbrukbare MCP-verktøy og promptmaler, som muliggjør rask tilpasning til nye domener eller forretningsbehov.
- **Brukeropplevelse:** Tilbyr en samtalegrensesnitt der brukere kan samhandle med reiseagentene, drevet av Azure OpenAI og MCP.

## Arkitektur
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Beskrivelse av arkitekturdiagrammet

Azure AI Reiseagenter-løsningen er designet for modularitet, skalerbarhet og sikker integrasjon av flere AI-agenter og bedriftsdatakilder. Hovedkomponentene og dataflyten er som følger:

- **Brukergrensesnitt:** Brukere interagerer med systemet gjennom et samtalegrensesnitt (som en nettprat eller Teams-bot), som sender brukerforespørsler og mottar reiseanbefalinger.
- **MCP Server:** Fungerer som sentral orkestrator, mottar brukerinput, håndterer kontekst og koordinerer handlingene til spesialiserte agenter (f.eks. FlightAgent, HotelAgent, ItineraryAgent) via Model Context Protocol.
- **AI-agenter:** Hver agent har ansvar for et spesifikt område (fly, hotell, reiserute) og er implementert som et MCP-verktøy. Agentene bruker promptmaler og logikk for å behandle forespørsler og generere svar.
- **Azure OpenAI Service:** Tilbyr avansert naturlig språkforståelse og generering, som gjør at agentene kan tolke brukerens intensjon og lage samtalebaserte svar.
- **Azure AI Search & bedriftsdata:** Agentene søker i Azure AI Search og andre bedriftsdatakilder for å hente oppdatert informasjon om fly, hoteller og reisealternativer.
- **Autentisering og sikkerhet:** Integreres med Microsoft Entra ID for sikker autentisering og anvender minste privilegium-prinsippet på alle ressurser.
- **Distribusjon:** Designet for distribusjon på Azure Container Apps, som sikrer skalerbarhet, overvåking og operasjonell effektivitet.

Denne arkitekturen muliggjør sømløs orkestrering av flere AI-agenter, sikker integrasjon med bedriftsdata, og en robust og utvidbar plattform for å bygge domene-spesifikke AI-løsninger.

## Trinnvis forklaring av arkitekturdiagrammet
Tenk deg at du planlegger en stor reise og har et team med ekspertassistenter som hjelper deg med alle detaljer. Azure AI Reiseagenter-systemet fungerer på samme måte, ved å bruke ulike deler (som teammedlemmer) som hver har sin spesielle oppgave. Slik henger det sammen:

### Brukergrensesnitt (UI):
Tenk på dette som resepsjonen til reiseagenten din. Her stiller du spørsmål eller legger inn forespørsler, som «Finn en flyreise til Paris». Dette kan være et chatte-vindu på en nettside eller en meldingsapp.

### MCP Server (Koordinatoren):
MCP Server er som lederen som lytter til forespørselen din i resepsjonen og bestemmer hvilken spesialist som skal håndtere hver del. Den holder styr på samtalen din og sørger for at alt går smidig.

### AI-agenter (Spesialistassistenter):
Hver agent er ekspert på et bestemt område – en kan alt om fly, en annen om hoteller, og en tredje om å planlegge reiseruten. Når du ber om en reise, sender MCP Server forespørselen din til riktig(e) agent(er). Disse agentene bruker sin kunnskap og verktøy for å finne de beste alternativene for deg.

### Azure OpenAI Service (Språkekspert):
Dette er som å ha en språkekspert som forstår nøyaktig hva du spør om, uansett hvordan du formulerer det. Den hjelper agentene å forstå forespørslene dine og svare på en naturlig, samtalemessig måte.

### Azure AI Search & bedriftsdata (Informasjonsbibliotek):
Tenk på et stort, oppdatert bibliotek med all den nyeste reiseinformasjonen – flytider, hotelltilgjengelighet og mer. Agentene søker i dette biblioteket for å finne de mest nøyaktige svarene til deg.

### Autentisering og sikkerhet (Vakthund):
Akkurat som en vakthund sjekker hvem som kan komme inn i visse områder, sørger denne delen for at bare autoriserte personer og agenter får tilgang til sensitiv informasjon. Den holder dataene dine trygge og private.

### Distribusjon på Azure Container Apps (Bygningen):
Alle disse assistentene og verktøyene jobber sammen inne i en sikker, skalerbar bygning (skyen). Det betyr at systemet kan håndtere mange brukere samtidig og alltid være tilgjengelig når du trenger det.

## Hvordan alt fungerer sammen:

Du starter med å stille et spørsmål i resepsjonen (UI).  
Lederen (MCP Server) finner ut hvilken spesialist (agent) som skal hjelpe deg.  
Spesialisten bruker språkeksperten (OpenAI) for å forstå forespørselen din og biblioteket (AI Search) for å finne det beste svaret.  
Vakthunden (Autentisering) sørger for at alt er trygt.  
Alt dette skjer inne i en pålitelig, skalerbar bygning (Azure Container Apps), så opplevelsen din er smidig og sikker.  
Dette samarbeidet gjør at systemet raskt og trygt kan hjelpe deg med å planlegge reisen, akkurat som et team av ekspertreiseagenter som jobber sammen i et moderne kontor!

## Teknisk implementering
- **MCP Server:** Huser kjerneorkestreringslogikken, eksponerer agentverktøy og håndterer kontekst for flertrinns reiseplanleggingsarbeidsflyter.
- **Agenter:** Hver agent (f.eks. FlightAgent, HotelAgent) er implementert som et MCP-verktøy med egne promptmaler og logikk.
- **Azure-integrasjon:** Bruker Azure OpenAI for naturlig språkforståelse og Azure AI Search for datainnhenting.
- **Sikkerhet:** Integreres med Microsoft Entra ID for autentisering og anvender minste privilegium-prinsippet på alle ressurser.
- **Distribusjon:** Støtter distribusjon til Azure Container Apps for skalerbarhet og operasjonell effektivitet.

## Resultater og påvirkning
- Viser hvordan MCP kan brukes til å orkestrere flere AI-agenter i et ekte, produksjonsklart scenario.
- Fremskynder løsningutvikling ved å tilby gjenbrukbare mønstre for agentkoordinering, dataintegrasjon og sikker distribusjon.
- Fungerer som en mal for å bygge domene-spesifikke, AI-drevne applikasjoner ved bruk av MCP og Azure-tjenester.

## Referanser
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på dets opprinnelige språk skal anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår fra bruk av denne oversettelsen.