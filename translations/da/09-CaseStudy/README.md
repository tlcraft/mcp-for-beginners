<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-05-20T23:39:53+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "da"
}
-->
# Case Study: Azure AI Travel Agents – Reference Implementation

## Oversigt

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) er en omfattende referencesolution udviklet af Microsoft, som viser, hvordan man bygger en multi-agent, AI-drevet rejseplanlægningsapplikation ved hjælp af Model Context Protocol (MCP), Azure OpenAI og Azure AI Search. Projektet demonstrerer bedste praksis for orkestrering af flere AI-agenter, integration af virksomhedens data og levering af en sikker, udvidelsesvenlig platform til virkelige scenarier.

## Nøglefunktioner
- **Multi-Agent Orkestrering:** Anvender MCP til at koordinere specialiserede agenter (f.eks. flight-, hotel- og rejseplanlægningsagenter), som samarbejder om at løse komplekse rejseplanlægningsopgaver.
- **Integration af Virksomhedsdata:** Forbinder til Azure AI Search og andre virksomhedskilder for at levere opdaterede og relevante oplysninger til rejseanbefalinger.
- **Sikker og Skalerbar Arkitektur:** Udnytter Azure-tjenester til autentificering, autorisation og skalerbar implementering, i overensstemmelse med virksomhedens sikkerhedspraksis.
- **Udvidelsesvenlige Værktøjer:** Implementerer genanvendelige MCP-værktøjer og promptskabeloner, der muliggør hurtig tilpasning til nye domæner eller forretningsbehov.
- **Brugeroplevelse:** Tilbyder en samtalegrænseflade, hvor brugere kan interagere med rejseagenternes AI, drevet af Azure OpenAI og MCP.

## Arkitektur
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Beskrivelse af Arkitekturdiagrammet

Azure AI Travel Agents-løsningen er designet med modularitet, skalerbarhed og sikker integration af flere AI-agenter og virksomhedskilder for øje. Hovedkomponenterne og dataflowet er som følger:

- **Brugergrænseflade:** Brugere interagerer med systemet via en samtalegrænseflade (f.eks. en webchat eller Teams-bot), som sender brugerforespørgsler og modtager rejseanbefalinger.
- **MCP Server:** Fungerer som central orkestrator, modtager brugerinput, håndterer kontekst og koordinerer handlinger mellem specialiserede agenter (f.eks. FlightAgent, HotelAgent, ItineraryAgent) via Model Context Protocol.
- **AI-agenter:** Hver agent har ansvar for et specifikt område (fly, hoteller, rejseplaner) og er implementeret som et MCP-værktøj. Agenterne bruger promptskabeloner og logik til at behandle forespørgsler og generere svar.
- **Azure OpenAI Service:** Leverer avanceret naturlig sprogforståelse og generering, så agenter kan fortolke brugerens intention og skabe samtalebaserede svar.
- **Azure AI Search & Virksomhedsdata:** Agenter henter opdaterede oplysninger om fly, hoteller og rejsemuligheder fra Azure AI Search og andre virksomhedskilder.
- **Autentificering & Sikkerhed:** Integreres med Microsoft Entra ID for sikker autentificering og anvender mindst-privilegium adgangskontrol på alle ressourcer.
- **Implementering:** Designet til implementering på Azure Container Apps, hvilket sikrer skalerbarhed, overvågning og effektiv drift.

Denne arkitektur muliggør gnidningsfri orkestrering af flere AI-agenter, sikker integration med virksomhedens data og en robust, udvidelsesvenlig platform til at bygge domænespecifikke AI-løsninger.

## Trin-for-trin Forklaring af Arkitekturdiagrammet
Forestil dig, at du planlægger en stor rejse og har et team af eksperthjælpere, der assisterer med alle detaljer. Azure AI Travel Agents-systemet fungerer på samme måde ved at bruge forskellige dele (som teammedlemmer), der hver har en særlig rolle. Her er hvordan det hele hænger sammen:

### Brugergrænseflade (UI):
Tænk på dette som rejseagentens reception. Det er her, du (brugeren) stiller spørgsmål eller fremsætter ønsker, som "Find mig en flybillet til Paris." Det kan være et chatvindue på en hjemmeside eller en beskedapp.

### MCP Server (Koordinatoren):
MCP Serveren er som lederen, der lytter til din forespørgsel ved receptionen og beslutter, hvilken specialist der skal håndtere hver del. Den holder styr på samtalen og sikrer, at alt kører glat.

### AI-agenter (Specialistassistenter):
Hver agent er ekspert inden for et bestemt område – en ved alt om fly, en anden om hoteller, og en tredje om rejseplanlægning. Når du beder om en rejse, sender MCP Serveren din forespørgsel til den eller de rette agenter. Disse agenter bruger deres viden og værktøjer til at finde de bedste muligheder for dig.

### Azure OpenAI Service (Sprogeksperten):
Dette er som at have en sprogkyndig, der forstår præcis, hvad du spørger om, uanset hvordan du formulerer dig. Den hjælper agenterne med at forstå dine forespørgsler og svare i naturligt, samtalebaseret sprog.

### Azure AI Search & Virksomhedsdata (Informationsbiblioteket):
Forestil dig et stort, opdateret bibliotek med al den nyeste rejseinformation – flytider, hoteltilgængelighed og meget mere. Agenterne søger i dette bibliotek for at finde de mest præcise svar til dig.

### Autentificering & Sikkerhed (Sikkerhedsvagten):
Ligesom en sikkerhedsvagt kontrollerer, hvem der må komme ind i bestemte områder, sikrer denne del, at kun autoriserede personer og agenter har adgang til følsomme oplysninger. Den beskytter dine data og privatliv.

### Implementering på Azure Container Apps (Bygningen):
Alle disse assistenter og værktøjer arbejder sammen inden for en sikker, skalerbar bygning (skyen). Det betyder, at systemet kan håndtere mange brugere samtidig og altid er tilgængeligt, når du har brug for det.

## Hvordan det hele fungerer sammen:

Du starter med at stille et spørgsmål ved receptionen (UI).
Lederen (MCP Server) finder ud af, hvilken specialist (agent) der kan hjælpe dig.
Specialisten bruger sprogkyndigen (OpenAI) til at forstå din forespørgsel og biblioteket (AI Search) til at finde det bedste svar.
Sikkerhedsvagten (Autentificering) sørger for, at alt foregår sikkert.
Alt dette sker inde i en pålidelig, skalerbar bygning (Azure Container Apps), så din oplevelse er smidig og sikker.
Dette samarbejde gør det muligt for systemet hurtigt og sikkert at hjælpe dig med at planlægge din rejse, ligesom et team af ekspertrejseagenter, der arbejder sammen på et moderne kontor!

## Teknisk Implementering
- **MCP Server:** Værtsfunktioner for kerneorkestreringslogikken, eksponerer agentværktøjer og håndterer kontekst til flerstegs rejseplanlægningsarbejdsgange.
- **Agenter:** Hver agent (f.eks. FlightAgent, HotelAgent) er implementeret som et MCP-værktøj med egne promptskabeloner og logik.
- **Azure Integration:** Bruger Azure OpenAI til naturlig sprogforståelse og Azure AI Search til datahentning.
- **Sikkerhed:** Integreres med Microsoft Entra ID til autentificering og anvender mindst-privilegium adgangskontrol på alle ressourcer.
- **Implementering:** Understøtter implementering på Azure Container Apps for skalerbarhed og effektiv drift.

## Resultater og Effekt
- Demonstrerer, hvordan MCP kan bruges til at orkestrere flere AI-agenter i et virkeligt, produktionsklart scenarie.
- Fremskynder udvikling af løsninger ved at tilbyde genanvendelige mønstre til agentkoordinering, dataintegration og sikker implementering.
- Tjener som en skabelon til at bygge domænespecifikke, AI-drevne applikationer ved brug af MCP og Azure-tjenester.

## Referencer
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, skal du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det originale dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.