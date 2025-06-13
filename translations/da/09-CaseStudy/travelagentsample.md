<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-06-13T21:48:58+00:00",
  "source_file": "09-CaseStudy/travelagentsample.md",
  "language_code": "da"
}
-->
# Case Study: Azure AI Travel Agents – Reference Implementation

## Oversigt

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) er en omfattende referencesolution udviklet af Microsoft, som viser, hvordan man bygger en multi-agent, AI-drevet rejseplanlægningsapplikation ved brug af Model Context Protocol (MCP), Azure OpenAI og Azure AI Search. Projektet demonstrerer bedste praksis for orkestrering af flere AI-agenter, integration af virksomhedsdata og levering af en sikker, udvidelsesvenlig platform til virkelige scenarier.

## Nøglefunktioner
- **Multi-Agent Orkestrering:** Benytter MCP til at koordinere specialiserede agenter (f.eks. fly-, hotel- og rejseplanlægningsagenter), der samarbejder om at løse komplekse rejseplanlægningsopgaver.
- **Integration af Virksomhedsdata:** Forbinder til Azure AI Search og andre virksomhedsdatakilder for at levere opdaterede, relevante oplysninger til rejseforslag.
- **Sikker og Skalerbar Arkitektur:** Udnytter Azure-tjenester til autentificering, autorisation og skalerbar implementering, i overensstemmelse med bedste praksis inden for virksomhedssikkerhed.
- **Udvidelsesvenlige Værktøjer:** Implementerer genanvendelige MCP-værktøjer og promptskabeloner, som muliggør hurtig tilpasning til nye domæner eller forretningsbehov.
- **Brugeroplevelse:** Tilbyder en samtalegrænseflade, hvor brugerne kan interagere med rejseagentene, drevet af Azure OpenAI og MCP.

## Arkitektur
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Beskrivelse af Arkitekturdiagram

Azure AI Travel Agents-løsningen er designet til modularitet, skalerbarhed og sikker integration af flere AI-agenter og virksomhedsdatakilder. Hovedkomponenterne og dataflowet er som følger:

- **Brugergrænseflade:** Brugere interagerer med systemet via en samtalegrænseflade (f.eks. en webchat eller Teams-bot), som sender brugerforespørgsler og modtager rejseforslag.
- **MCP Server:** Fungerer som central orkestrator, modtager brugerinput, styrer konteksten og koordinerer handlingerne for specialiserede agenter (f.eks. FlightAgent, HotelAgent, ItineraryAgent) via Model Context Protocol.
- **AI-agenter:** Hver agent er ansvarlig for et specifikt domæne (fly, hoteller, rejseplaner) og er implementeret som et MCP-værktøj. Agenterne bruger promptskabeloner og logik til at behandle forespørgsler og generere svar.
- **Azure OpenAI Service:** Tilbyder avanceret naturlig sprogforståelse og -generering, som gør det muligt for agenterne at tolke brugerens intention og generere samtalesvar.
- **Azure AI Search & Virksomhedsdata:** Agenterne søger i Azure AI Search og andre virksomhedsdatakilder for at hente opdaterede oplysninger om fly, hoteller og rejsemuligheder.
- **Autentificering & Sikkerhed:** Integreres med Microsoft Entra ID for sikker autentificering og anvender mindst-privilegium adgangskontrol til alle ressourcer.
- **Implementering:** Designet til implementering på Azure Container Apps, hvilket sikrer skalerbarhed, overvågning og effektiv drift.

Denne arkitektur muliggør problemfri orkestrering af flere AI-agenter, sikker integration med virksomhedsdata og en robust, udvidelsesvenlig platform til at bygge domænespecifikke AI-løsninger.

## Trin-for-trin Forklaring af Arkitekturdiagrammet
Forestil dig, at du planlægger en stor rejse og har et team af eksperthjælpere, der hjælper dig med alle detaljer. Azure AI Travel Agents-systemet fungerer på samme måde, ved at bruge forskellige dele (som teammedlemmer), der hver har en særlig opgave. Sådan hænger det hele sammen:

### Brugergrænseflade (UI):
Tænk på dette som din rejseagents reception. Det er her, du (brugeren) stiller spørgsmål eller fremsætter ønsker, som "Find mig en flyrejse til Paris." Det kan være et chatvindue på en hjemmeside eller en beskedapp.

### MCP Server (Koordinatoren):
MCP Serveren er som en leder, der lytter til din forespørgsel ved receptionen og beslutter, hvilken specialist der skal håndtere hver del. Den holder styr på samtalen og sørger for, at alt kører glat.

### AI-agenter (Specialisteassistenter):
Hver agent er ekspert inden for et bestemt område – en kender alt til fly, en anden til hoteller, og en tredje til planlægning af din rejseplan. Når du stiller et spørgsmål, sender MCP Serveren din forespørgsel til den rette agent eller agenter. Disse agenter bruger deres viden og værktøjer til at finde de bedste muligheder for dig.

### Azure OpenAI Service (Sprogekspert):
Det er som at have en sprogekspert, der forstår præcis, hvad du spørger om, uanset hvordan du formulerer det. Den hjælper agenterne med at forstå dine forespørgsler og svare i et naturligt, samtalebaseret sprog.

### Azure AI Search & Virksomhedsdata (Informationsbibliotek):
Forestil dig et kæmpe, opdateret bibliotek med al den nyeste rejseinformation – flytider, hoteltilgængelighed og mere. Agenterne søger i dette bibliotek for at give dig de mest præcise svar.

### Autentificering & Sikkerhed (Vagten):
Ligesom en sikkerhedsvagt kontrollerer, hvem der kan komme ind i visse områder, sikrer denne del, at kun autoriserede personer og agenter kan få adgang til følsomme oplysninger. Det beskytter dine data og privatliv.

### Implementering på Azure Container Apps (Bygningen):
Alle disse hjælpere og værktøjer arbejder sammen inden for en sikker, skalerbar bygning (skyen). Det betyder, at systemet kan håndtere mange brugere på samme tid og altid er tilgængeligt, når du har brug for det.

## Sådan arbejder det hele sammen:

Du starter med at stille et spørgsmål ved receptionen (UI).  
Lederen (MCP Server) finder ud af, hvilken specialist (agent) der skal hjælpe dig.  
Specialisten bruger sprogeksperten (OpenAI) til at forstå din forespørgsel og biblioteket (AI Search) til at finde det bedste svar.  
Vagten (Autentificering) sørger for, at alt er sikkert.  
Alt dette foregår i en pålidelig, skalerbar bygning (Azure Container Apps), så din oplevelse er glat og sikker.  
Dette samarbejde gør det muligt for systemet hurtigt og sikkert at hjælpe dig med at planlægge din rejse, ligesom et team af ekspertrejseagenter, der arbejder sammen i et moderne kontor!

## Teknisk Implementering
- **MCP Server:** Vært for kerneorkestreringslogikken, eksponerer agentværktøjer og styrer konteksten for flerstegs rejseplanlægningsarbejdsgange.
- **Agenter:** Hver agent (f.eks. FlightAgent, HotelAgent) er implementeret som et MCP-værktøj med egne promptskabeloner og logik.
- **Azure Integration:** Bruger Azure OpenAI til naturlig sprogforståelse og Azure AI Search til datahentning.
- **Sikkerhed:** Integreres med Microsoft Entra ID til autentificering og anvender mindst-privilegium adgangskontrol til alle ressourcer.
- **Implementering:** Understøtter implementering på Azure Container Apps for skalerbarhed og effektiv drift.

## Resultater og Effekt
- Viser, hvordan MCP kan bruges til at orkestrere flere AI-agenter i et virkeligt, produktionsklart scenarie.
- Fremskynder løsningudvikling ved at levere genanvendelige mønstre til agentkoordinering, dataintegration og sikker implementering.
- Fungerer som en køreplan for at bygge domænespecifikke, AI-drevne applikationer med MCP og Azure-tjenester.

## Referencer
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Ansvarsfraskrivelse**:  
Dette dokument er oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for eventuelle misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.