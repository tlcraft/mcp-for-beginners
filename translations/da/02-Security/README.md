<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "382fddb4ee4d9c1bdc806e2ee99b70c8",
  "translation_date": "2025-07-17T06:32:46+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "da"
}
-->
# Sikkerhedsbedste praksis

Implementering af Model Context Protocol (MCP) giver kraftfulde nye muligheder for AI-drevne applikationer, men medfører også unikke sikkerhedsudfordringer, der går ud over traditionelle software-risici. Ud over velkendte bekymringer som sikker kodning, mindst privilegium og forsyningskædesikkerhed, står MCP og AI-arbejdsbelastninger over for nye trusler som prompt injection, tool poisoning, dynamisk værktøjsmodifikation, session hijacking, confused deputy-angreb og token passthrough-sårbarheder. Disse risici kan føre til dataudtræk, brud på privatlivets fred og utilsigtet systemadfærd, hvis de ikke håndteres korrekt.

Denne lektion gennemgår de mest relevante sikkerhedsrisici forbundet med MCP—herunder autentificering, autorisation, overdrevne tilladelser, indirekte prompt injection, sessionssikkerhed, confused deputy-problemer, token passthrough-sårbarheder og forsyningskædesårbarheder—og giver handlingsorienterede kontroller og bedste praksis til at afbøde dem. Du vil også lære, hvordan du kan udnytte Microsoft-løsninger som Prompt Shields, Azure Content Safety og GitHub Advanced Security til at styrke din MCP-implementering. Ved at forstå og anvende disse kontroller kan du markant reducere sandsynligheden for et sikkerhedsbrud og sikre, at dine AI-systemer forbliver robuste og pålidelige.

# Læringsmål

Når du har gennemført denne lektion, vil du kunne:

- Identificere og forklare de unikke sikkerhedsrisici, som Model Context Protocol (MCP) medfører, herunder prompt injection, tool poisoning, overdrevne tilladelser, session hijacking, confused deputy-problemer, token passthrough-sårbarheder og forsyningskædesårbarheder.
- Beskrive og anvende effektive afbødende kontroller for MCP-sikkerhedsrisici, såsom robust autentificering, mindst privilegium, sikker tokenhåndtering, sessionssikkerhedskontroller og verifikation af forsyningskæden.
- Forstå og udnytte Microsoft-løsninger som Prompt Shields, Azure Content Safety og GitHub Advanced Security til at beskytte MCP og AI-arbejdsbelastninger.
- Genkende vigtigheden af at validere værktøjsmetadata, overvåge dynamiske ændringer, forsvare mod indirekte prompt injection-angreb og forhindre session hijacking.
- Integrere etablerede sikkerhedsbedste praksisser—såsom sikker kodning, serverhærde og zero trust-arkitektur—i din MCP-implementering for at reducere sandsynligheden og konsekvenserne af sikkerhedsbrud.

# MCP sikkerhedskontroller

Enhver system, der har adgang til vigtige ressourcer, har implicitte sikkerhedsudfordringer. Sikkerhedsudfordringer kan generelt håndteres gennem korrekt anvendelse af grundlæggende sikkerhedskontroller og koncepter. Da MCP kun er nyligt defineret, ændrer specifikationen sig meget hurtigt, efterhånden som protokollen udvikler sig. Med tiden vil sikkerhedskontrollerne i MCP modne, hvilket muliggør bedre integration med virksomheders og etablerede sikkerhedsarkitekturer og bedste praksisser.

Forskning offentliggjort i [Microsoft Digital Defense Report](https://aka.ms/mddr) viser, at 98 % af rapporterede brud kunne være forhindret ved robust sikkerhedshygiejne, og den bedste beskyttelse mod enhver form for brud er at få styr på din grundlæggende sikkerhedshygiejne, sikre kodningspraksisser og forsyningskædesikkerhed — de velafprøvede metoder, vi allerede kender til, har stadig størst effekt på at reducere sikkerhedsrisikoen.

Lad os se på nogle af de måder, du kan begynde at håndtere sikkerhedsrisici ved implementering af MCP.

> **Note:** Følgende information er korrekt pr. **29. maj 2025**. MCP-protokollen udvikler sig løbende, og fremtidige implementeringer kan introducere nye autentificeringsmønstre og kontroller. For de seneste opdateringer og vejledning, henvis altid til [MCP Specification](https://spec.modelcontextprotocol.io/) samt den officielle [MCP GitHub repository](https://github.com/modelcontextprotocol) og [security best practice page](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Problemstilling  
Den oprindelige MCP-specifikation antog, at udviklere selv ville skrive deres egen autentificeringsserver. Dette krævede kendskab til OAuth og relaterede sikkerhedsbegrænsninger. MCP-servere fungerede som OAuth 2.0 Authorization Servers og håndterede den nødvendige brugerautentificering direkte i stedet for at delegere den til en ekstern tjeneste som Microsoft Entra ID. Fra og med **26. april 2025** tillader en opdatering af MCP-specifikationen, at MCP-servere kan delegere brugerautentificering til en ekstern tjeneste.

### Risici
- Forkert konfigureret autorisationslogik i MCP-serveren kan føre til eksponering af følsomme data og forkert anvendte adgangskontroller.
- Tyveri af OAuth-token på den lokale MCP-server. Hvis tokenet bliver stjålet, kan det bruges til at udgive sig for MCP-serveren og få adgang til ressourcer og data fra den tjeneste, som OAuth-tokenet gælder for.

#### Token Passthrough
Token passthrough er udtrykkeligt forbudt i autorisationsspecifikationen, da det medfører en række sikkerhedsrisici, herunder:

#### Omgåelse af sikkerhedskontroller
MCP-serveren eller downstream-API’er kan implementere vigtige sikkerhedskontroller som rate limiting, anmodningsvalidering eller trafikovervågning, der afhænger af tokenets audience eller andre legitimationsbegrænsninger. Hvis klienter kan opnå og bruge tokens direkte med downstream-API’erne uden, at MCP-serveren validerer dem korrekt eller sikrer, at tokens er udstedt til den rette tjeneste, omgår de disse kontroller.

#### Ansvarlighed og revisionsspor-problemer
MCP-serveren vil ikke kunne identificere eller skelne mellem MCP-klienter, når klienter kalder med et upstream-udstedt adgangstoken, som kan være uigennemsigtigt for MCP-serveren.  
Downstream Resource Serverens logs kan vise anmodninger, der ser ud til at komme fra en anden kilde med en anden identitet end den MCP-server, der faktisk videresender tokens.  
Begge faktorer gør hændelsesundersøgelser, kontroller og revision vanskeligere.  
Hvis MCP-serveren videresender tokens uden at validere deres claims (f.eks. roller, privilegier eller audience) eller anden metadata, kan en ondsindet aktør i besiddelse af et stjålet token bruge serveren som proxy til dataudtræk.

#### Tillidsgrænse-problemer
Downstream Resource Server giver tillid til specifikke enheder. Denne tillid kan inkludere antagelser om oprindelse eller klientadfærdsmønstre. At bryde denne tillidsgrænse kan føre til uventede problemer.  
Hvis tokenet accepteres af flere tjenester uden korrekt validering, kan en angriber, der kompromitterer én tjeneste, bruge tokenet til at få adgang til andre tilknyttede tjenester.

#### Risiko for fremtidig kompatibilitet
Selv hvis en MCP-server i dag starter som en "ren proxy", kan det blive nødvendigt at tilføje sikkerhedskontroller senere. At starte med korrekt adskillelse af token audience gør det lettere at udvikle sikkerhedsmodellen.

### Afbødende kontroller

**MCP-servere MÅ IKKE acceptere tokens, der ikke eksplicit er udstedt til MCP-serveren**

- **Gennemgå og styrk autorisationslogikken:** Revider omhyggeligt din MCP-servers autorisationsimplementering for at sikre, at kun tilsigtede brugere og klienter kan få adgang til følsomme ressourcer. For praktisk vejledning, se [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) og [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Håndhæv sikre token-praksisser:** Følg [Microsofts bedste praksis for tokenvalidering og levetid](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) for at forhindre misbrug af adgangstokens og reducere risikoen for token replay eller tyveri.
- **Beskyt tokenlagring:** Opbevar altid tokens sikkert og brug kryptering for at beskytte dem i hvile og under overførsel. For implementeringstips, se [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Overdrevne tilladelser for MCP-servere

### Problemstilling  
MCP-servere kan have fået tildelt overdrevne tilladelser til den tjeneste/ressource, de tilgår. For eksempel bør en MCP-server, der er en del af en AI-salgsapplikation, som forbinder til en virksomhedsdatastore, kun have adgang til salgsdata og ikke til alle filer i lageret. Med henvisning til princippet om mindst privilegium (et af de ældste sikkerhedsprincipper) bør ingen ressource have tilladelser ud over, hvad der er nødvendigt for at udføre de opgaver, den er tiltænkt. AI udgør en øget udfordring her, fordi det kan være svært at definere præcist, hvilke tilladelser der er nødvendige for at gøre den fleksibel.

### Risici  
- At give overdrevne tilladelser kan muliggøre udtræk eller ændring af data, som MCP-serveren ikke burde have adgang til. Dette kan også være et privatlivsproblem, hvis dataene indeholder personligt identificerbare oplysninger (PII).

### Afbødende kontroller  
- **Anvend princippet om mindst privilegium:** Giv MCP-serveren kun de minimale tilladelser, der er nødvendige for at udføre de krævede opgaver. Gennemgå og opdater disse tilladelser regelmæssigt for at sikre, at de ikke overstiger det nødvendige. For detaljeret vejledning, se [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Brug rollebaseret adgangskontrol (RBAC):** Tildel roller til MCP-serveren, der er snævert afgrænsede til specifikke ressourcer og handlinger, og undgå brede eller unødvendige tilladelser.
- **Overvåg og revider tilladelser:** Overvåg løbende brugen af tilladelser og revider adgangslogs for hurtigt at opdage og afhjælpe overdrevne eller ubrugte privilegier.

# Indirekte prompt injection-angreb

### Problemstilling

Ondsindede eller kompromitterede MCP-servere kan udgøre betydelige risici ved at eksponere kundedata eller muliggøre utilsigtede handlinger. Disse risici er særligt relevante i AI- og MCP-baserede arbejdsbelastninger, hvor:

- **Prompt Injection-angreb:** Angribere indlejrer ondsindede instruktioner i prompts eller eksternt indhold, hvilket får AI-systemet til at udføre utilsigtede handlinger eller lække følsomme data. Læs mere: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning:** Angribere manipulerer værktøjsmetadata (såsom beskrivelser eller parametre) for at påvirke AI’ens adfærd, potentielt forbigå sikkerhedskontroller eller udtrække data. Detaljer: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection:** Ondsindede instruktioner indlejres i dokumenter, websider eller e-mails, som derefter behandles af AI’en, hvilket fører til datalækage eller manipulation.
- **Dynamisk værktøjsmodifikation (Rug Pulls):** Værktøjsdefinitioner kan ændres efter brugerens godkendelse, hvilket introducerer nye ondsindede handlinger uden brugerens viden.

Disse sårbarheder understreger behovet for robust validering, overvågning og sikkerhedskontroller, når MCP-servere og værktøjer integreres i dit miljø. For en dybere gennemgang, se de linkede referencer ovenfor.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.da.png)

**Indirekte Prompt Injection** (også kendt som cross-domain prompt injection eller XPIA) er en kritisk sårbarhed i generative AI-systemer, herunder dem, der bruger Model Context Protocol (MCP). I dette angreb skjules ondsindede instruktioner i eksternt indhold—såsom dokumenter, websider eller e-mails. Når AI-systemet behandler dette indhold, kan det fortolke de indlejrede instruktioner som legitime brugerkommandoer, hvilket resulterer i utilsigtede handlinger som datalækage, generering af skadeligt indhold eller manipulation af brugerinteraktioner. For en detaljeret forklaring og eksempler fra virkeligheden, se [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

En særlig farlig form for dette angreb er **Tool Poisoning**. Her injicerer angribere ondsindede instruktioner i metadata for MCP-værktøjer (såsom værktøjsbeskrivelser eller parametre). Da store sprogmodeller (LLMs) baserer deres beslutning om, hvilke værktøjer der skal kaldes, på denne metadata, kan kompromitterede beskrivelser narre modellen til at udføre uautoriserede værktøjskald eller omgå sikkerhedskontroller. Disse manipulationer er ofte usynlige for slutbrugere, men kan fortolkes og udføres af AI-systemet. Denne risiko forstærkes i hostede MCP-servermiljøer, hvor værktøjsdefinitioner kan opdateres efter brugerens godkendelse—et scenarie, der nogle gange kaldes en "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". I sådanne tilfælde kan et tidligere sikkert værktøj senere blive ændret til at udføre ondsindede handlinger, såsom dataudtræk eller ændring af systemadfærd, uden brugerens viden. For mere om denne angrebsvektor, se [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.da.png)

## Risici  
Utilsigtede AI-handlinger udgør en række sikkerhedsrisici, herunder dataudtræk og brud på privatlivets fred.

### Afbødende kontroller  
### Brug af prompt shields til beskyttelse mod indirekte prompt injection-angreb
-----------------------------------------------------------------------------

**AI Prompt Shields** er en løsning udviklet af Microsoft til at forsvare mod både direkte og indirekte prompt injection-angreb. De hjælper ved:

1.  **Detektion og filtrering:** Prompt Shields bruger avancerede maskinlæringsalgoritmer og naturlig sprogbehandling til at opdage og filtrere ondsindede instruktioner indlejret i eksternt indhold, såsom dokumenter, websider eller e-mails.
    
2.  **Spotlighting:** Denne teknik hjælper AI-systemet med at skelne mellem gyldige systeminstruktioner og potentielt utroværdige eksterne input. Ved at transformere inputteksten på en måde, der gør den mere relevant for modellen, sikrer Spotlighting, at AI’en bedre kan identificere og ignorere ondsindede instruktioner.
    
3.  **Afgrænsere og datamarkering:** Inkludering af afgrænsere i systembeskeden angiver eksplicit placeringen af inputteksten, hvilket hjælper AI-systemet med at genkende og adskille brugerinput fra potentielt skadeligt eksternt indhold. Datamarkering udvider dette koncept ved at bruge særlige markører til at fremhæve grænserne mellem betroede og ikke-betroede data.
    
4.  **Kontinuerlig overvågning og opdateringer:** Microsoft overvåger og opdaterer løbende Prompt Shields for at imødegå nye og udviklende trusler. Denne proaktive tilgang sikrer, at forsvaret forbliver effektivt mod de nyeste angrebsteknikker.
    
5. **Integration med Azure Content Safety:** Prompt Shields er en del af den bredere Azure AI Content Safety-suite, som tilbyder yderligere værktøjer til at opdage jailbreak-forsøg, skadeligt indhold og andre sikkerhedsrisici i AI-applikationer.

Du kan læse mere om AI prompt shields i [Prompt Shields dokumentationen](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.da.png)

# Confused Deputy Problem

### Problemstilling
Problemet med den forvirrede stedfortræder er en sikkerhedssårbarhed, der opstår, når en MCP-server fungerer som en proxy mellem MCP-klienter og tredjeparts-API'er. Denne sårbarhed kan udnyttes, når MCP-serveren bruger et statisk klient-ID til at autentificere sig over for en tredjeparts autorisationsserver, som ikke understøtter dynamisk klientregistrering.

### Risici

- **Omgåelse af cookie-baseret samtykke**: Hvis en bruger tidligere har autentificeret sig via MCP-proxyserveren, kan en tredjeparts autorisationsserver sætte en samtykkecookie i brugerens browser. En angriber kan senere udnytte dette ved at sende brugeren et ondsindet link med en manipuleret autorisationsanmodning, der indeholder en ondsindet redirect URI.
- **Tyveri af autorisationskode**: Når brugeren klikker på det ondsindede link, kan tredjeparts autorisationsserveren springe samtykkeskærmen over på grund af den eksisterende cookie, og autorisationskoden kan blive omdirigeret til angriberens server.
- **Uautoriseret API-adgang**: Angriberen kan bytte den stjålne autorisationskode til adgangstokens og udgive sig for at være brugeren for at få adgang til tredjeparts-API'en uden eksplicit godkendelse.

### Afhjælpende foranstaltninger

- **Krav om eksplicit samtykke**: MCP-proxyservere, der bruger statiske klient-ID'er, **SKAL** indhente brugerens samtykke for hver dynamisk registreret klient, før de videresender til tredjeparts autorisationsservere.
- **Korrekt OAuth-implementering**: Følg OAuth 2.1 sikkerhedspraksis, herunder brug af kodeudfordringer (PKCE) til autorisationsanmodninger for at forhindre aflytning.
- **Klientvalidering**: Implementer streng validering af redirect URIs og klientidentifikatorer for at forhindre udnyttelse af ondsindede aktører.


# Token Passthrough-sårbarheder

### Problemstilling

"Token passthrough" er et anti-mønster, hvor en MCP-server accepterer tokens fra en MCP-klient uden at validere, at tokens er korrekt udstedt til MCP-serveren selv, og derefter "videresender" dem til downstream-API'er. Denne praksis overtræder eksplicit MCP-autorisationens specifikation og introducerer alvorlige sikkerhedsrisici.

### Risici

- **Omgåelse af sikkerhedskontroller**: Klienter kan omgå vigtige sikkerhedskontroller som ratebegrænsning, anmodningsvalidering eller trafikovervågning, hvis de kan bruge tokens direkte med downstream-API'er uden korrekt validering.
- **Ansvarlighed og revisionsproblemer**: MCP-serveren vil ikke kunne identificere eller skelne mellem MCP-klienter, når klienter bruger upstream-udstedte adgangstokens, hvilket gør hændelsesundersøgelser og revision vanskeligere.
- **Dataudtrækning**: Hvis tokens videresendes uden korrekt validering af claims, kan en ondsindet aktør med et stjålet token bruge serveren som proxy til dataudtrækning.
- **Brud på tillidsgrænser**: Downstream-ressourceservere kan give tillid til specifikke enheder baseret på antagelser om oprindelse eller adfærdsmønstre. At bryde denne tillidsgrænse kan føre til uventede sikkerhedsproblemer.
- **Misbrug af tokens på tværs af tjenester**: Hvis tokens accepteres af flere tjenester uden korrekt validering, kan en angriber, der kompromitterer én tjeneste, bruge tokenet til at få adgang til andre tilknyttede tjenester.

### Afhjælpende foranstaltninger

- **Tokenvalidering**: MCP-servere **MÅ IKKE** acceptere tokens, der ikke eksplicit er udstedt til MCP-serveren selv.
- **Audience-verifikation**: Valider altid, at tokens har det korrekte audience-claim, der matcher MCP-serverens identitet.
- **Korrekt tokenlivscyklusstyring**: Implementer kortlivede adgangstokens og korrekt tokenrotation for at reducere risikoen for token-tyveri og misbrug.


# Session Hijacking

### Problemstilling

Session hijacking er en angrebsvektor, hvor en klient får tildelt en session-ID af serveren, og en uautoriseret part opnår og bruger den samme session-ID til at udgive sig for at være den oprindelige klient og udføre uautoriserede handlinger på deres vegne. Dette er særligt bekymrende i stateful HTTP-servere, der håndterer MCP-anmodninger.

### Risici

- **Session Hijack Prompt Injection**: En angriber, der opnår en session-ID, kan sende ondsindede hændelser til en server, der deler sessionstilstand med den server, klienten er forbundet til, hvilket potentielt kan udløse skadelige handlinger eller få adgang til følsomme data.
- **Session Hijack Udpegning**: En angriber med en stjålet session-ID kan foretage opkald direkte til MCP-serveren, omgå autentificering og blive behandlet som den legitime bruger.
- **Kompromitterede genoptagelige streams**: Når en server understøtter genlevering/genoptagelige streams, kan en angriber afbryde en anmodning for tidligt, hvilket fører til, at den genoptages senere af den oprindelige klient med potentielt ondsindet indhold.

### Afhjælpende foranstaltninger

- **Autorisation verifikation**: MCP-servere, der implementerer autorisation, **SKAL** verificere alle indgående anmodninger og **MÅ IKKE** bruge sessioner til autentificering.
- **Sikre session-ID'er**: MCP-servere **SKAL** bruge sikre, ikke-deterministiske session-ID'er genereret med sikre tilfældige talgeneratorer. Undgå forudsigelige eller sekventielle identifikatorer.
- **Brugerspecifik sessionsbinding**: MCP-servere **BØR** binde session-ID'er til brugerspecifik information ved at kombinere session-ID'et med information unik for den autoriserede bruger (som deres interne bruger-ID) i et format som `
<user_id>:<session_id>`.
- **Sessionsudløb**: Implementer korrekt sessionsudløb og rotation for at begrænse sårbarhedsvinduet, hvis en session-ID kompromitteres.
- **Transport-sikkerhed**: Brug altid HTTPS til al kommunikation for at forhindre opsnapning af session-ID'er.


# Supply chain-sikkerhed

Supply chain-sikkerhed forbliver grundlæggende i AI-æraen, men omfanget af, hvad der udgør din supply chain, er udvidet. Ud over traditionelle kodepakker skal du nu grundigt verificere og overvåge alle AI-relaterede komponenter, herunder foundation-modeller, embeddings-tjenester, kontekstudbydere og tredjeparts-API'er. Hver af disse kan introducere sårbarheder eller risici, hvis de ikke håndteres korrekt.

**Nøglepraksis for supply chain-sikkerhed for AI og MCP:**
- **Verificer alle komponenter før integration:** Dette inkluderer ikke kun open source-biblioteker, men også AI-modeller, datakilder og eksterne API'er. Tjek altid oprindelse, licensering og kendte sårbarheder.
- **Vedligehold sikre deployments-pipelines:** Brug automatiserede CI/CD-pipelines med integreret sikkerhedsscanning for at opdage problemer tidligt. Sørg for, at kun betroede artefakter deployeres til produktion.
- **Kontinuerlig overvågning og revision:** Implementer løbende overvågning af alle afhængigheder, inklusive modeller og datatjenester, for at opdage nye sårbarheder eller supply chain-angreb.
- **Anvend mindst privilegium og adgangskontrol:** Begræns adgangen til modeller, data og tjenester til kun det, der er nødvendigt for, at din MCP-server kan fungere.
- **Reager hurtigt på trusler:** Hav en proces på plads for at patche eller udskifte kompromitterede komponenter og for at rotere hemmeligheder eller legitimationsoplysninger, hvis et brud opdages.

[GitHub Advanced Security](https://github.com/security/advanced-security) tilbyder funktioner som hemmelighedsscanning, afhængighedsscanning og CodeQL-analyse. Disse værktøjer integreres med [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) og [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) for at hjælpe teams med at identificere og afbøde sårbarheder på tværs af både kode og AI supply chain-komponenter.

Microsoft implementerer også omfattende supply chain-sikkerhedspraksis internt for alle produkter. Læs mere i [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Etablerede sikkerhedspraksisser, der vil styrke sikkerheden i din MCP-implementering

Enhver MCP-implementering arver den eksisterende sikkerhedsholdning i din organisations miljø, som den er bygget på, så når du overvejer sikkerheden i MCP som en komponent i dine samlede AI-systemer, anbefales det at styrke din overordnede eksisterende sikkerhedsholdning. Følgende etablerede sikkerhedskontroller er særligt relevante:

-   Sikker kodning i din AI-applikation – beskyt mod [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), brug sikre vaults til hemmeligheder og tokens, implementer end-to-end sikre kommunikationskanaler mellem alle applikationskomponenter osv.
-   Serverhærde – brug MFA hvor muligt, hold patching opdateret, integrer serveren med en tredjeparts identitetsudbyder til adgang osv.
-   Hold enheder, infrastruktur og applikationer opdaterede med patches
-   Sikkerhedsovervågning – implementer logning og overvågning af en AI-applikation (inklusive MCP-klient/servere) og send disse logs til et centralt SIEM for at opdage unormale aktiviteter
-   Zero trust-arkitektur – isoler komponenter via netværks- og identitetskontroller på en logisk måde for at minimere lateral bevægelse, hvis en AI-applikation kompromitteres.

# Vigtige pointer

- Grundlæggende sikkerhedsprincipper er stadig afgørende: Sikker kodning, mindst privilegium, supply chain-verifikation og kontinuerlig overvågning er essentielle for MCP og AI-arbejdsbelastninger.
- MCP introducerer nye risici – såsom prompt injection, tool poisoning, session hijacking, confused deputy-problemer, token passthrough-sårbarheder og overdrevne tilladelser – som kræver både traditionelle og AI-specifikke kontroller.
- Brug robuste autentificerings-, autorisations- og tokenhåndteringspraksisser, og udnyt eksterne identitetsudbydere som Microsoft Entra ID, hvor det er muligt.
- Beskyt mod indirekte prompt injection og tool poisoning ved at validere tool-metadata, overvåge dynamiske ændringer og bruge løsninger som Microsoft Prompt Shields.
- Implementer sikker sessionhåndtering ved at bruge ikke-deterministiske session-ID'er, binde sessioner til brugeridentiteter og aldrig bruge sessioner til autentificering.
- Forebyg confused deputy-angreb ved at kræve eksplicit bruger-samtykke for hver dynamisk registreret klient og implementere korrekte OAuth-sikkerhedspraksisser.
- Undgå token passthrough-sårbarheder ved at sikre, at MCP-servere kun accepterer tokens, der eksplicit er udstedt til dem, og validerer token-claims korrekt.
- Behandl alle komponenter i din AI supply chain – inklusive modeller, embeddings og kontekstudbydere – med samme omhu som kodeafhængigheder.
- Hold dig opdateret med udviklingen i MCP-specifikationerne og bidrag til fællesskabet for at hjælpe med at forme sikre standarder.

# Yderligere ressourcer

## Eksterne ressourcer
- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Prompt Injection in MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Tool Poisoning Attacks (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls in MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Prompt Shields Documentation (Microsoft)](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Secure Token Storage and Encrypt Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

## Yderligere sikkerhedsdokumenter

For mere detaljeret sikkerhedsguidance, se venligst disse dokumenter:

- [MCP Security Best Practices 2025](./mcp-security-best-practices-2025.md) - Omfattende liste over sikkerhedspraksisser for MCP-implementeringer
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md) - Implementeringseksempler for integration af Azure Content Safety med MCP-servere
- [MCP Security Controls 2025](./mcp-security-controls-2025.md) - Seneste sikkerhedskontroller og teknikker til sikring af MCP-implementeringer
- [MCP Best Practices](./mcp-best-practices.md) - Hurtig referenceguide til MCP-sikkerhed

### Næste

Næste: [Kapitel 3: Kom godt i gang](../03-GettingStarted/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.