<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b6b1bc868efed4cf02c52f8deada559d",
  "translation_date": "2025-05-17T17:29:46+00:00",
  "source_file": "09-CaseStudy/Readme.md",
  "language_code": "da"
}
-->
# Case Study: Azure AI Travel Agents – Reference Implementation

## Oversigt

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) er en omfattende referencesolution udviklet af Microsoft, der viser, hvordan man bygger en multi-agent, AI-drevet rejseplanlægningsapplikation ved hjælp af Model Context Protocol (MCP), Azure OpenAI og Azure AI Search. Dette projekt fremhæver bedste praksis for orkestrering af flere AI-agenter, integration af virksomhedsdata og levering af en sikker, udvidelig platform til virkelige scenarier.

## Nøglefunktioner
- **Multi-Agent Orkestrering:** Udnytter MCP til at koordinere specialiserede agenter (f.eks. fly-, hotel- og rejseplanlægningsagenter), der samarbejder om at opfylde komplekse rejseplanlægningsopgaver.
- **Integration af virksomhedsdata:** Forbinder til Azure AI Search og andre virksomhedsdatakilder for at give opdateret, relevant information til rejseanbefalinger.
- **Sikker, skalerbar arkitektur:** Udnytter Azure-tjenester til autentificering, autorisation og skalerbar udrulning, i overensstemmelse med virksomhedens sikkerheds bedste praksis.
- **Udvidelige værktøjer:** Implementerer genanvendelige MCP-værktøjer og promptskabeloner, der muliggør hurtig tilpasning til nye domæner eller forretningskrav.
- **Brugeroplevelse:** Giver en samtalegrænseflade for brugere til at interagere med rejseagenterne, drevet af Azure OpenAI og MCP.

## Arkitektur
![Arkitektur](https://github.com/Azure-Samples/azure-ai-travel-agents/blob/main/docs/ai-travel-agents-architecture-diagram.png)

### Beskrivelse af arkitekturdiagram

Azure AI Travel Agents-løsningen er designet til modularitet, skalerbarhed og sikker integration af flere AI-agenter og virksomhedsdatakilder. De vigtigste komponenter og dataflow er som følger:

- **Brugergrænseflade:** Brugere interagerer med systemet gennem en samtalegrænseflade (som en webchat eller Teams-bot), der sender brugerforespørgsler og modtager rejseanbefalinger.
- **MCP Server:** Fungerer som den centrale orkestrator, der modtager brugerinput, administrerer kontekst og koordinerer handlingerne fra specialiserede agenter (f.eks. FlightAgent, HotelAgent, ItineraryAgent) via Model Context Protocol.
- **AI-agenter:** Hver agent er ansvarlig for et specifikt domæne (fly, hoteller, rejseplaner) og er implementeret som et MCP-værktøj. Agenter bruger promptskabeloner og logik til at behandle forespørgsler og generere svar.
- **Azure OpenAI Service:** Leverer avanceret naturlig sprogforståelse og -generering, der gør det muligt for agenter at tolke brugerens hensigt og generere samtalesvar.
- **Azure AI Search & Enterprise Data:** Agenter forespørger Azure AI Search og andre virksomhedsdatakilder for at hente opdateret information om fly, hoteller og rejsemuligheder.
- **Autentificering & Sikkerhed:** Integrerer med Microsoft Entra ID for sikker autentificering og anvender mindst privilegeret adgangskontrol til alle ressourcer.
- **Udrulning:** Designet til udrulning på Azure Container Apps, der sikrer skalerbarhed, overvågning og operationel effektivitet.

Denne arkitektur muliggør problemfri orkestrering af flere AI-agenter, sikker integration med virksomhedsdata og en robust, udvidelig platform til opbygning af domænespecifikke AI-løsninger.

## Trin-for-trin Forklaring af Arkitekturdiagram
Forestil dig at planlægge en stor rejse og have et team af eksperthjælpere til at hjælpe dig med hver detalje. Azure AI Travel Agents-systemet fungerer på en lignende måde, ved at bruge forskellige dele (som teammedlemmer), der hver har en speciel opgave. Her er hvordan det hele passer sammen:

### Brugergrænseflade (UI):
Tænk på dette som din rejseagents reception. Det er her, du (brugeren) stiller spørgsmål eller laver forespørgsler, som "Find mig et fly til Paris." Dette kunne være et chatvindue på en hjemmeside eller en beskedapp.

### MCP Server (Koordinatoren):
MCP Serveren er som lederen, der lytter til din forespørgsel ved receptionen og beslutter, hvilken specialist der skal håndtere hver del. Den holder styr på din samtale og sikrer, at alt kører glat.

### AI-agenter (Specialistassistenter):
Hver agent er ekspert inden for et specifikt område - én ved alt om fly, en anden om hoteller og en tredje om planlægning af din rejseplan. Når du beder om en rejse, sender MCP Serveren din forespørgsel til den rigtige agent(er). Disse agenter bruger deres viden og værktøjer til at finde de bedste muligheder for dig.

### Azure OpenAI Service (Sprogekspert):
Dette er som at have en sprogekspert, der forstår præcis, hvad du spørger om, uanset hvordan du formulerer det. Det hjælper agenterne med at forstå dine forespørgsler og svare i naturligt, samtalesprog.

### Azure AI Search & Enterprise Data (Informationsbibliotek):
Forestil dig et stort, opdateret bibliotek med alle de nyeste rejseoplysninger - flyplaner, hoteltilgængelighed og mere. Agenterne søger i dette bibliotek for at få de mest præcise svar til dig.

### Autentificering & Sikkerhed (Sikkerhedsvagt):
Ligesom en sikkerhedsvagt kontrollerer, hvem der kan komme ind i bestemte områder, sikrer denne del, at kun autoriserede personer og agenter kan få adgang til følsomme oplysninger. Det holder dine data sikre og private.

### Udrulning på Azure Container Apps (Bygningen):
Alle disse assistenter og værktøjer arbejder sammen inde i en sikker, skalerbar bygning (skyen). Dette betyder, at systemet kan håndtere mange brugere på én gang og altid er tilgængeligt, når du har brug for det.

## Hvordan det hele fungerer sammen:

Du starter med at stille et spørgsmål ved receptionen (UI).
Lederen (MCP Server) finder ud af, hvilken specialist (agent) der skal hjælpe dig.
Specialisten bruger sprogeksperten (OpenAI) til at forstå din forespørgsel og biblioteket (AI Search) til at finde det bedste svar.
Sikkerhedsvagten (Autentificering) sikrer, at alt er sikkert.
Alt dette sker inden for en pålidelig, skalerbar bygning (Azure Container Apps), så din oplevelse er glat og sikker.
Dette teamwork gør det muligt for systemet hurtigt og sikkert at hjælpe dig med at planlægge din rejse, ligesom et team af ekspertrejseagenter, der arbejder sammen i et moderne kontor!

## Teknisk Implementering
- **MCP Server:** Værter den centrale orkestreringslogik, eksponerer agentværktøjer og administrerer kontekst for multi-trins rejseplanlægningsarbejdsgange.
- **Agenter:** Hver agent (f.eks. FlightAgent, HotelAgent) er implementeret som et MCP-værktøj med sine egne promptskabeloner og logik.
- **Azure Integration:** Bruger Azure OpenAI til naturlig sprogforståelse og Azure AI Search til dataindhentning.
- **Sikkerhed:** Integrerer med Microsoft Entra ID til autentificering og anvender mindst privilegeret adgangskontrol til alle ressourcer.
- **Udrulning:** Understøtter udrulning til Azure Container Apps for skalerbarhed og operationel effektivitet.

## Resultater og Indvirkning
- Demonstrerer, hvordan MCP kan bruges til at orkestrere flere AI-agenter i et virkeligt, produktionsklart scenarie.
- Fremskynder løsningens udvikling ved at give genanvendelige mønstre for agentkoordination, dataintegration og sikker udrulning.
- Tjener som en plan for opbygning af domænespecifikke, AI-drevne applikationer ved hjælp af MCP og Azure-tjenester.

## Referencer
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Mens vi bestræber os på nøjagtighed, skal du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det originale dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi er ikke ansvarlige for eventuelle misforståelser eller fejltolkninger, der måtte opstå som følge af brugen af denne oversættelse.