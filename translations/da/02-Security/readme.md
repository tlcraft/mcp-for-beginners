<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-17T07:34:18+00:00",
  "source_file": "02-Security/readme.md",
  "language_code": "da"
}
-->
# Sikkerhedsbedste Praksis

At tage Model Context Protocol (MCP) i brug giver stærke nye muligheder for AI-drevne applikationer, men introducerer også unikke sikkerhedsudfordringer, der går ud over traditionelle software risici. Ud over etablerede bekymringer som sikker kodning, mindst privilegium og forsyningskædesikkerhed, står MCP og AI-arbejdsbelastninger over for nye trusler som prompt injection, værktøjsforgiftning og dynamisk værktøjsmodifikation. Disse risici kan føre til dataudtrækning, brud på privatlivets fred og utilsigtet systemadfærd, hvis de ikke håndteres korrekt.

Denne lektion undersøger de mest relevante sikkerhedsrisici forbundet med MCP - inklusive autentifikation, autorisation, overdrevne tilladelser, indirekte prompt injection og forsyningskædesårbarheder - og giver handlingsrettede kontroller og bedste praksis til at afbøde dem. Du vil også lære, hvordan du udnytter Microsoft-løsninger som Prompt Shields, Azure Content Safety og GitHub Advanced Security til at styrke din MCP-implementering. Ved at forstå og anvende disse kontroller kan du betydeligt reducere sandsynligheden for et sikkerhedsbrud og sikre, at dine AI-systemer forbliver robuste og pålidelige.

# Læringsmål

Ved slutningen af denne lektion vil du være i stand til at:

- Identificere og forklare de unikke sikkerhedsrisici, der introduceres af Model Context Protocol (MCP), herunder prompt injection, værktøjsforgiftning, overdrevne tilladelser og forsyningskædesårbarheder.
- Beskrive og anvende effektive afbødende kontroller for MCP-sikkerhedsrisici, såsom robust autentifikation, mindst privilegium, sikker tokenhåndtering og forsyningskædeverifikation.
- Forstå og udnytte Microsoft-løsninger som Prompt Shields, Azure Content Safety og GitHub Advanced Security til at beskytte MCP og AI-arbejdsbelastninger.
- Genkende vigtigheden af at validere værktøjsmetadata, overvåge dynamiske ændringer og forsvare mod indirekte prompt injection angreb.
- Integrere etablerede sikkerhedsbedste praksis - såsom sikker kodning, serverhærdning og nul tillid arkitektur - i din MCP-implementering for at reducere sandsynligheden og virkningen af sikkerhedsbrud.

# MCP sikkerhedskontroller

Ethvert system, der har adgang til vigtige ressourcer, har implicitte sikkerhedsudfordringer. Sikkerhedsudfordringer kan generelt adresseres gennem korrekt anvendelse af grundlæggende sikkerhedskontroller og koncepter. Da MCP kun er nyligt defineret, ændrer specifikationen sig meget hurtigt, og efterhånden som protokollen udvikler sig. Til sidst vil sikkerhedskontrollerne inden for den modnes, hvilket muliggør en bedre integration med virksomheds- og etablerede sikkerhedsarkitekturer og bedste praksis.

Forskning offentliggjort i [Microsoft Digital Defense Report](https://aka.ms/mddr) angiver, at 98% af rapporterede brud ville blive forhindret af robust sikkerhedshygiejne, og den bedste beskyttelse mod enhver form for brud er at få din baseline sikkerhedshygiejne, sikker kodning bedste praksis og forsyningskædesikkerhed rigtigt - de prøvede og testede praksisser, som vi allerede kender til, har stadig den største indflydelse på at reducere sikkerhedsrisikoen.

Lad os se på nogle af de måder, du kan begynde at adressere sikkerhedsrisici, når du adopterer MCP.

# MCP server autentifikation (hvis din MCP implementering var før 26. april 2025)

> **Note:** Følgende information er korrekt pr. 26. april 2025. MCP-protokollen udvikler sig kontinuerligt, og fremtidige implementeringer kan introducere nye autentifikationsmønstre og kontroller. For de nyeste opdateringer og vejledning, henvis altid til [MCP Specification](https://spec.modelcontextprotocol.io/) og den officielle [MCP GitHub repository](https://github.com/modelcontextprotocol).

### Problemstilling 
Den oprindelige MCP-specifikation antog, at udviklere ville skrive deres egen autentifikationsserver. Dette krævede kendskab til OAuth og relaterede sikkerhedsbegrænsninger. MCP-servere fungerede som OAuth 2.0 Autorisationsservere, der administrerede den nødvendige brugerautentifikation direkte i stedet for at delegere den til en ekstern tjeneste såsom Microsoft Entra ID. Fra 26. april 2025 tillader en opdatering til MCP-specifikationen, at MCP-servere kan delegere brugerautentifikation til en ekstern tjeneste.

### Risici
- Mis-konfigureret autorisationslogik i MCP-serveren kan føre til eksponering af følsomme data og forkert anvendte adgangskontroller.
- OAuth token tyveri på den lokale MCP-server. Hvis stjålet, kan tokenet derefter bruges til at udgive sig for MCP-serveren og få adgang til ressourcer og data fra den tjeneste, som OAuth-tokenet er for.

### Afbødende kontroller
- **Gennemgå og Hærd Autorisationslogik:** Gennemgå nøje din MCP-servers autorisationsimplementering for at sikre, at kun tiltænkte brugere og klienter kan få adgang til følsomme ressourcer. For praktisk vejledning, se [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) og [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Gennemfør Sikker Token Praksis:** Følg [Microsoft’s bedste praksis for token validering og levetid](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) for at forhindre misbrug af adgangstokens og reducere risikoen for token-genafspilning eller tyveri.
- **Beskyt Token Opbevaring:** Opbevar altid tokens sikkert og brug kryptering for at beskytte dem i hvile og under transport. For implementeringstips, se [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).


# Overdrevne tilladelser for MCP-servere

### Problemstilling
MCP-servere kan have fået tildelt overdrevne tilladelser til den tjeneste/ressource, de får adgang til. For eksempel bør en MCP-server, der er en del af en AI-salgsapplikation, der forbinder til en virksomhedsdatabutik, have adgang begrænset til salgsdataene og ikke tillades adgang til alle filer i butikken. Med henvisning til princippet om mindst privilegium (et af de ældste sikkerhedsprincipper) bør ingen ressource have tilladelser, der overstiger det, der kræves for at udføre de opgaver, den var tiltænkt for. AI præsenterer en øget udfordring på dette område, fordi det kan være udfordrende at definere de nøjagtige tilladelser, der kræves for at gøre det fleksibelt.

### Risici 
- At give overdrevne tilladelser kan tillade dataudtrækning eller ændring af data, som MCP-serveren ikke var tiltænkt at kunne få adgang til. Dette kan også være et privatlivsproblem, hvis dataene er personligt identificerbare oplysninger (PII).

### Afbødende kontroller
- **Anvend Princippet om Mindst Privilegium:** Giv MCP-serveren kun de minimale tilladelser, der er nødvendige for at udføre dens krævede opgaver. Gennemgå og opdater regelmæssigt disse tilladelser for at sikre, at de ikke overstiger det, der er nødvendigt. For detaljeret vejledning, se [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Brug Rollebaseret Adgangskontrol (RBAC):** Tildel roller til MCP-serveren, der er stramt afgrænset til specifikke ressourcer og handlinger, og undgå brede eller unødvendige tilladelser.
- **Overvåg og Revider Tilladelser:** Overvåg kontinuerligt tilladelsesbrug og revider adgangslogfiler for hurtigt at opdage og afhjælpe overdrevne eller ubrugte privilegier.

# Indirekte prompt injection angreb

### Problemstilling

Ondsindede eller kompromitterede MCP-servere kan introducere betydelige risici ved at eksponere kundedata eller muliggøre utilsigtede handlinger. Disse risici er især relevante i AI og MCP-baserede arbejdsbelastninger, hvor:

- **Prompt Injection Angreb**: Angribere indlejrer ondsindede instruktioner i prompts eller ekstern indhold, hvilket får AI-systemet til at udføre utilsigtede handlinger eller lække følsomme data. Læs mere: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Værktøjsforgiftning**: Angribere manipulerer værktøjsmetadata (såsom beskrivelser eller parametre) for at påvirke AI's adfærd, potentielt omgå sikkerhedskontroller eller udtrække data. Detaljer: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection**: Ondsindede instruktioner indlejres i dokumenter, websider eller e-mails, som derefter behandles af AI, hvilket fører til datalækage eller manipulation.
- **Dynamisk Værktøjsmodifikation (Rug Pulls)**: Værktøjsdefinitioner kan ændres efter brugerens godkendelse, hvilket introducerer nye ondsindede adfærd uden brugerens viden.

Disse sårbarheder fremhæver behovet for robust validering, overvågning og sikkerhedskontroller, når MCP-servere og værktøjer integreres i dit miljø. For en dybere forståelse, se de linkede referencer ovenfor.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.4b2f1af239a32d46221a75c7bc5b6f392ebbacc47eccde241d4c60507232fa43.da.png)

**Indirekte Prompt Injection** (også kendt som cross-domain prompt injection eller XPIA) er en kritisk sårbarhed i generative AI-systemer, inklusive dem, der bruger Model Context Protocol (MCP). I dette angreb skjules ondsindede instruktioner inden for eksternt indhold - såsom dokumenter, websider eller e-mails. Når AI-systemet behandler dette indhold, kan det tolke de indlejrede instruktioner som legitime brugerkommandoer, hvilket resulterer i utilsigtede handlinger som datalækage, generering af skadeligt indhold eller manipulation af brugerinteraktioner. For en detaljeret forklaring og eksempler fra den virkelige verden, se [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

En særlig farlig form for dette angreb er **Værktøjsforgiftning**. Her injicerer angribere ondsindede instruktioner i metadataene for MCP-værktøjer (såsom værktøjsbeskrivelser eller parametre). Da store sproglige modeller (LLMs) er afhængige af disse metadata for at beslutte, hvilke værktøjer der skal anvendes, kan kompromitterede beskrivelser narre modellen til at udføre uautoriserede værktøjskald eller omgå sikkerhedskontroller. Disse manipulationer er ofte usynlige for slutbrugere, men kan tolkes og handles på af AI-systemet. Denne risiko forstærkes i hostede MCP-servermiljøer, hvor værktøjsdefinitioner kan opdateres efter brugerens godkendelse - et scenario, der nogle gange omtales som en "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". I sådanne tilfælde kan et værktøj, der tidligere var sikkert, senere ændres til at udføre ondsindede handlinger, såsom at udtrække data eller ændre systemadfærd, uden brugerens viden. For mere om denne angrebsvektor, se [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).


![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.d4607023f69e16157954001ad81afd763676361f03db0a1cf24ec696b2ddcb88.da.png)


## Risici
Utilsigtede AI-handlinger udgør en række sikkerhedsrisici, der inkluderer dataudtrækning og privatlivsbrud.

### Afbødende kontroller
### Brug af prompt shields til at beskytte mod indirekte prompt injection angreb
-----------------------------------------------------------------------------

**AI Prompt Shields** er en løsning udviklet af Microsoft til at forsvare mod både direkte og indirekte prompt injection angreb. De hjælper gennem:

1.  **Detektion og Filtrering**: Prompt Shields bruger avancerede maskinlæringsalgoritmer og naturlig sprogbehandling til at opdage og filtrere ondsindede instruktioner indlejret i eksternt indhold, såsom dokumenter, websider eller e-mails.
    
2.  **Spotlighting**: Denne teknik hjælper AI-systemet med at skelne mellem gyldige systeminstruktioner og potentielt utroværdige eksterne input. Ved at transformere inputteksten på en måde, der gør den mere relevant for modellen, sikrer Spotlighting, at AI bedre kan identificere og ignorere ondsindede instruktioner.
    
3.  **Afgrænsninger og Datamarkering**: Inkludering af afgrænsninger i systemmeddelelsen beskriver eksplicit placeringen af inputteksten, hvilket hjælper AI-systemet med at genkende og adskille brugerinput fra potentielt skadeligt eksternt indhold. Datamarkering udvider dette koncept ved at bruge specielle markører til at fremhæve grænserne for betroede og utroværdige data.
    
4.  **Kontinuerlig Overvågning og Opdateringer**: Microsoft overvåger og opdaterer kontinuerligt Prompt Shields for at adressere nye og udviklende trusler. Denne proaktive tilgang sikrer, at forsvarene forbliver effektive mod de nyeste angrebsteknikker.
    
5. **Integration med Azure Content Safety:** Prompt Shields er en del af den bredere Azure AI Content Safety suite, som giver yderligere værktøjer til at opdage jailbreak forsøg, skadeligt indhold og andre sikkerhedsrisici i AI-applikationer.

Du kan læse mere om AI prompt shields i [Prompt Shields dokumentationen](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.a4dba28a04ea42d28053f233585290d4862b244ca1e59b8ff695c5530e1bba66.da.png)


### Forsyningskædesikkerhed

Forsyningskædesikkerhed forbliver fundamental i AI-æraen, men omfanget af hvad der udgør din forsyningskæde er udvidet. Ud over traditionelle kodepakker skal du nu grundigt verificere og overvåge alle AI-relaterede komponenter, inklusive grundlæggende modeller, indlejringsservices, kontekstudbydere og tredjeparts API'er. Hver af disse kan introducere sårbarheder eller risici, hvis de ikke håndteres korrekt.

**Vigtige forsyningskædesikkerhedspraksis for AI og MCP:**
- **Verificer alle komponenter før integration:** Dette inkluderer ikke kun open-source biblioteker, men også AI-modeller, datakilder og eksterne API'er. Kontroller altid for oprindelse, licensering og kendte sårbarheder.
- **Oprethold sikre implementeringspipelines:** Brug automatiserede CI/CD-pipelines med integreret sikkerhedsscanning for at fange problemer tidligt. Sørg for, at kun betroede artefakter implementeres i produktion.
- **Kontinuerligt overvåg og revider:** Implementer løbende overvågning af alle afhængigheder, inklusive modeller og dataservices, for at opdage nye sårbarheder eller forsyningskædeangreb.
- **Anvend mindst privilegium og adgangskontroller:** Begræns adgang til modeller, data og services til kun det, der er nødvendigt for din MCP-server at fungere.
- **Reagér hurtigt på trusler:** Hav en proces på plads for at rette eller erstatte kompromitterede komponenter og for at rotere hemmeligheder eller legitimationsoplysninger, hvis et brud opdages.

[GitHub Advanced Security](https://github.com/security/advanced-security) tilbyder funktioner såsom hemmelighedsscanning, afhængighedsscanning og CodeQL-analyse. Disse værktøjer integrerer med [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) og [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) for at hjælpe teams med at identificere og afbøde sårbarheder på tværs af både kode og AI-forsyningskæde komponenter.

Microsoft implementerer også omfattende forsyningskædesikkerhedspraksis internt for alle produkter. Læs mere i [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Etablerede sikkerhedsbedste praksis, der vil forbedre sikkerhedspositionen for din MCP-implementering

Enhver MCP-implementering arver den eksisterende sikkerhedsposition i din organisations miljø, som den er bygget på, så når du overvejer sikkerheden af MCP som en komponent i dine samlede AI-systemer,
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Rejsen mod at sikre softwareforsyningskæden hos Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Sikker mindst privilegeret adgang (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Bedste praksis for tokenvalidering og levetid](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Brug sikker tokenlagring og krypter tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management som autentificeringsgateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Brug af Microsoft Entra ID til autentificering med MCP-servere](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Næste

Næste: [Kapitel 3: Kom godt i gang](/03-GettingStarted/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, skal du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det originale dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi er ikke ansvarlige for eventuelle misforståelser eller fejltolkninger, der måtte opstå ved brugen af denne oversættelse.