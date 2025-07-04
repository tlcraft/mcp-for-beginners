<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c69f9df7f3215dac8d056020539bac36",
  "translation_date": "2025-07-04T17:42:27+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "da"
}
-->
# Security Best Practices

At implementere Model Context Protocol (MCP) giver kraftfulde nye muligheder for AI-drevne applikationer, men medfører også unikke sikkerhedsudfordringer, der går ud over traditionelle software-risici. Ud over velkendte bekymringer som sikker kodning, mindst privilegium og forsyningskædesikkerhed, står MCP og AI-arbejdsbelastninger over for nye trusler som prompt injection, tool poisoning og dynamisk værktøjsmodifikation. Disse risici kan føre til dataudtræk, brud på privatlivets fred og utilsigtet systemadfærd, hvis de ikke håndteres korrekt.

Denne lektion gennemgår de mest relevante sikkerhedsrisici forbundet med MCP—herunder autentificering, autorisation, overdrevne tilladelser, indirekte prompt injection og forsyningskædevulnerabiliteter—og giver handlingsorienterede kontroller og bedste praksis til at afbøde dem. Du vil også lære, hvordan du kan udnytte Microsoft-løsninger som Prompt Shields, Azure Content Safety og GitHub Advanced Security til at styrke din MCP-implementering. Ved at forstå og anvende disse kontroller kan du markant reducere sandsynligheden for et sikkerhedsbrud og sikre, at dine AI-systemer forbliver robuste og pålidelige.

# Learning Objectives

Når du har gennemført denne lektion, vil du kunne:

- Identificere og forklare de unikke sikkerhedsrisici, som Model Context Protocol (MCP) introducerer, herunder prompt injection, tool poisoning, overdrevne tilladelser og forsyningskædevulnerabiliteter.
- Beskrive og anvende effektive afbødende kontroller for MCP-sikkerhedsrisici, såsom robust autentificering, mindst privilegium, sikker tokenhåndtering og verifikation af forsyningskæden.
- Forstå og udnytte Microsoft-løsninger som Prompt Shields, Azure Content Safety og GitHub Advanced Security til at beskytte MCP og AI-arbejdsbelastninger.
- Genkende vigtigheden af at validere værktøjsmetadata, overvåge dynamiske ændringer og forsvare mod indirekte prompt injection-angreb.
- Integrere etablerede sikkerhedsbest practices—såsom sikker kodning, serverhærde og zero trust-arkitektur—i din MCP-implementering for at mindske sandsynligheden og konsekvenserne af sikkerhedsbrud.

# MCP security controls

Enhver system, der har adgang til vigtige ressourcer, har implicitte sikkerhedsudfordringer. Sikkerhedsudfordringer kan generelt håndteres gennem korrekt anvendelse af grundlæggende sikkerhedskontroller og koncepter. Da MCP kun er nyligt defineret, ændrer specifikationen sig meget hurtigt, efterhånden som protokollen udvikler sig. Til sidst vil sikkerhedskontrollerne i den modne, hvilket muliggør bedre integration med virksomheders og etablerede sikkerhedsarkitekturer og bedste praksis.

Forskning offentliggjort i [Microsoft Digital Defense Report](https://aka.ms/mddr) angiver, at 98 % af rapporterede brud kunne forhindres ved robust sikkerhedshygiejne, og den bedste beskyttelse mod enhver form for brud er at få din grundlæggende sikkerhedshygiejne, sikre kodningspraksis og forsyningskædesikkerhed på plads – de velafprøvede metoder, vi allerede kender til, har stadig størst effekt på at reducere sikkerhedsrisiko.

Lad os se på nogle af de måder, hvorpå du kan begynde at håndtere sikkerhedsrisici ved implementering af MCP.

> **Note:** Følgende information er korrekt pr. **29. maj 2025**. MCP-protokollen udvikler sig løbende, og fremtidige implementeringer kan introducere nye autentificeringsmønstre og kontroller. For de seneste opdateringer og vejledning, henvis altid til [MCP Specification](https://spec.modelcontextprotocol.io/) og den officielle [MCP GitHub repository](https://github.com/modelcontextprotocol) samt [security best practice page](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Problem statement  
Den oprindelige MCP-specifikation antog, at udviklere selv ville skrive deres egen autentificeringsserver. Dette krævede kendskab til OAuth og relaterede sikkerhedsbegrænsninger. MCP-servere fungerede som OAuth 2.0 Authorization Servers, der håndterede den nødvendige brugerautentificering direkte i stedet for at delegere den til en ekstern tjeneste som Microsoft Entra ID. Fra og med **26. april 2025** tillader en opdatering af MCP-specifikationen, at MCP-servere kan delegere brugerautentificering til en ekstern tjeneste.

### Risks
- Forkert konfigureret autorisationslogik i MCP-serveren kan føre til eksponering af følsomme data og forkert anvendte adgangskontroller.
- Tyveri af OAuth-token på den lokale MCP-server. Hvis tokenet stjæles, kan det bruges til at udgive sig for MCP-serveren og få adgang til ressourcer og data fra den tjeneste, som OAuth-tokenet gælder for.

#### Token Passthrough
Token passthrough er udtrykkeligt forbudt i autorisationsspecifikationen, da det medfører en række sikkerhedsrisici, herunder:

#### Omgåelse af sikkerhedskontroller
MCP-serveren eller downstream-API’er kan implementere vigtige sikkerhedskontroller som rate limiting, anmodningsvalidering eller trafikovervågning, der afhænger af tokenets audience eller andre legitimationsbegrænsninger. Hvis klienter kan opnå og bruge tokens direkte med downstream-API’erne uden, at MCP-serveren validerer dem korrekt eller sikrer, at tokens er udstedt til den rette tjeneste, omgår de disse kontroller.

#### Ansvarlighed og revisionssporproblemer
MCP-serveren vil ikke kunne identificere eller skelne mellem MCP-klienter, når klienter kalder med et upstream-udstedt adgangstoken, som kan være uigennemsigtigt for MCP-serveren.  
Downstream Resource Server’s logs kan vise anmodninger, der ser ud til at komme fra en anden kilde med en anden identitet, snarere end den MCP-server, der faktisk videresender tokens.  
Begge faktorer gør hændelsesundersøgelser, kontroller og revision vanskeligere.  
Hvis MCP-serveren videresender tokens uden at validere deres claims (f.eks. roller, privilegier eller audience) eller anden metadata, kan en ondsindet aktør i besiddelse af et stjålet token bruge serveren som proxy til dataudtræk.

#### Problemer med tillidsgrænser
Downstream Resource Server giver tillid til specifikke enheder. Denne tillid kan inkludere antagelser om oprindelse eller klientadfærdsmønstre. At bryde denne tillidsgrænse kan føre til uventede problemer.  
Hvis tokenet accepteres af flere tjenester uden korrekt validering, kan en angriber, der kompromitterer én tjeneste, bruge tokenet til at få adgang til andre tilknyttede tjenester.

#### Risiko for fremtidig kompatibilitet
Selv hvis en MCP-server starter som en “ren proxy” i dag, kan den få behov for at tilføje sikkerhedskontroller senere. At starte med korrekt adskillelse af token audience gør det lettere at udvikle sikkerhedsmodellen.

### Mitigerende kontroller

**MCP-servere MÅ IKKE acceptere tokens, der ikke eksplicit er udstedt til MCP-serveren**

- **Gennemgå og styrk autorisationslogikken:** Revider omhyggeligt din MCP-servers autorisationsimplementering for at sikre, at kun tilsigtede brugere og klienter kan få adgang til følsomme ressourcer. For praktisk vejledning, se [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) og [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Håndhæv sikre token-praksisser:** Følg [Microsofts bedste praksis for tokenvalidering og levetid](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) for at forhindre misbrug af adgangstokens og reducere risikoen for token replay eller tyveri.
- **Beskyt tokenlagring:** Opbevar altid tokens sikkert og brug kryptering for at beskytte dem i hvile og under overførsel. For implementeringstips, se [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Excessive permissions for MCP servers

### Problem statement  
MCP-servere kan have fået tildelt overdrevne tilladelser til den tjeneste/ressource, de tilgår. For eksempel bør en MCP-server, der er en del af en AI-salgsapplikation, der forbinder til en virksomhedsdatastore, kun have adgang til salgsdata og ikke tilladelse til at tilgå alle filer i lageret. Med henvisning til princippet om mindst privilegium (et af de ældste sikkerhedsprincipper) bør ingen ressource have tilladelser ud over, hvad der er nødvendigt for at udføre de opgaver, den er tiltænkt. AI udgør en øget udfordring på dette område, fordi det for at gøre den fleksibel kan være svært at definere de præcise nødvendige tilladelser.

### Risks  
- At give overdrevne tilladelser kan muliggøre udtræk eller ændring af data, som MCP-serveren ikke var tiltænkt at få adgang til. Dette kan også være et privatlivsproblem, hvis dataene indeholder personligt identificerbare oplysninger (PII).

### Mitigerende kontroller  
- **Anvend princippet om mindst privilegium:** Giv MCP-serveren kun de minimale tilladelser, der er nødvendige for at udføre de krævede opgaver. Gennemgå og opdater regelmæssigt disse tilladelser for at sikre, at de ikke overstiger det nødvendige. For detaljeret vejledning, se [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Brug rollebaseret adgangskontrol (RBAC):** Tildel roller til MCP-serveren, der er snævert afgrænset til specifikke ressourcer og handlinger, og undgå brede eller unødvendige tilladelser.
- **Overvåg og revider tilladelser:** Overvåg løbende brugen af tilladelser og revider adgangslogs for hurtigt at opdage og afhjælpe overdrevne eller ubrugte privilegier.

# Indirect prompt injection attacks

### Problem statement

Ondsindede eller kompromitterede MCP-servere kan udgøre betydelige risici ved at eksponere kundedata eller muliggøre utilsigtede handlinger. Disse risici er særligt relevante i AI- og MCP-baserede arbejdsbelastninger, hvor:

- **Prompt Injection Attacks**: Angribere indlejrer ondsindede instruktioner i prompts eller eksternt indhold, hvilket får AI-systemet til at udføre utilsigtede handlinger eller lække følsomme data. Læs mere: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning**: Angribere manipulerer værktøjsmetadata (såsom beskrivelser eller parametre) for at påvirke AI’ens adfærd, potentielt omgå sikkerhedskontroller eller udtrække data. Detaljer: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection**: Ondsindede instruktioner indlejres i dokumenter, websider eller e-mails, som derefter behandles af AI’en, hvilket fører til datalækage eller manipulation.
- **Dynamic Tool Modification (Rug Pulls)**: Værktøjsdefinitioner kan ændres efter brugerens godkendelse, hvilket introducerer nye ondsindede handlinger uden brugerens viden.

Disse sårbarheder understreger behovet for robust validering, overvågning og sikkerhedskontroller, når MCP-servere og værktøjer integreres i dit miljø. For en dybere gennemgang, se de linkede referencer ovenfor.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.da.png)

**Indirect Prompt Injection** (også kendt som cross-domain prompt injection eller XPIA) er en kritisk sårbarhed i generative AI-systemer, herunder dem, der bruger Model Context Protocol (MCP). Ved dette angreb skjules ondsindede instruktioner i eksternt indhold—såsom dokumenter, websider eller e-mails. Når AI-systemet behandler dette indhold, kan det fortolke de indlejrede instruktioner som legitime brugerkommandoer, hvilket resulterer i utilsigtede handlinger som datalækage, generering af skadeligt indhold eller manipulation af brugerinteraktioner. For en detaljeret forklaring og eksempler fra virkeligheden, se [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

En særligt farlig form for dette angreb er **Tool Poisoning**. Her injicerer angribere ondsindede instruktioner i metadata for MCP-værktøjer (såsom værktøjsbeskrivelser eller parametre). Da store sprogmodeller (LLMs) baserer deres beslutning om, hvilke værktøjer der skal kaldes, på denne metadata, kan kompromitterede beskrivelser narre modellen til at udføre uautoriserede værktøjskald eller omgå sikkerhedskontroller. Disse manipulationer er ofte usynlige for slutbrugere, men kan fortolkes og udføres af AI-systemet. Denne risiko forstærkes i hostede MCP-servermiljøer, hvor værktøjsdefinitioner kan opdateres efter brugerens godkendelse—et scenarie, der nogle gange kaldes en "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". I sådanne tilfælde kan et værktøj, der tidligere var sikkert, senere blive ændret til at udføre ondsindede handlinger, såsom dataudtræk eller ændring af systemadfærd, uden brugerens viden. For mere om denne angrebsvektor, se [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.da.png)

## Risks  
Utilsigtede AI-handlinger udgør en række sikkerhedsrisici, herunder dataudtræk og brud på privatlivets fred.

### Mitigerende kontroller  
### Brug af prompt shields til beskyttelse mod Indirect Prompt Injection-angreb
-----------------------------------------------------------------------------

**AI Prompt Shields** er en løsning udviklet af Microsoft til at forsvare mod både direkte og indirekte prompt injection-angreb. De hjælper ved:

1.  **Detektion og filtrering:** Prompt Shields bruger avancerede maskinlæringsalgoritmer og naturlig sprogbehandling til at opdage og filtrere ondsindede instruktioner indlejret i eksternt indhold, såsom dokumenter, websider eller e-mails.
    
2.  **Spotlighting:** Denne teknik hjælper AI-systemet med at skelne mellem gyldige systeminstruktioner og potentielt utroværdige eksterne input. Ved at transformere inputteksten på en måde, der gør den mere relevant for modellen, sikrer Spotlighting, at AI’en bedre kan identificere og ignorere ondsindede instruktioner.
    
3.  **Afgrænsere og datamarkering:** Inkludering af afgrænsere i systembeskeden angiver eksplicit placeringen af inputteksten, hvilket hjælper AI-systemet med at genkende og adskille brugerinput fra potentielt skadeligt eksternt indhold. Datamarkering udvider dette koncept ved at bruge særlige markører til at fremhæve grænserne mellem betroede og ikke-betroede data.
    
4.  **Kontinuerlig overvågning og opdateringer:** Microsoft overvåger og opdaterer løbende Prompt Shields for at imødegå nye og udviklende trusler. Denne proaktive tilgang sikrer, at forsvaret forbliver effektivt mod de nyeste angrebsteknikker.
    
5. **Integration med Azure Content Safety:** Prompt Shields er en del af den bredere Azure AI Content Safety-suite, som tilbyder yderligere værktøjer til at opdage jailbreak-forsøg, skadeligt indhold og andre sikkerhedsrisici i AI-applikationer.

Du kan læse mere om AI prompt shields i [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.da.png)

### Supply chain security
Supply chain-sikkerhed forbliver grundlæggende i AI-æraen, men omfanget af, hvad der udgør din supply chain, er udvidet. Ud over traditionelle kodepakker skal du nu nøje verificere og overvåge alle AI-relaterede komponenter, herunder foundation models, embeddings-tjenester, kontekstudbydere og tredjeparts-API’er. Hver af disse kan introducere sårbarheder eller risici, hvis de ikke håndteres korrekt.

**Vigtige sikkerhedspraksisser for supply chain i AI og MCP:**
- **Verificer alle komponenter før integration:** Dette inkluderer ikke kun open source-biblioteker, men også AI-modeller, datakilder og eksterne API’er. Tjek altid oprindelse, licensering og kendte sårbarheder.
- **Oprethold sikre deployments-pipelines:** Brug automatiserede CI/CD-pipelines med integreret sikkerhedsscanning for at opdage problemer tidligt. Sørg for, at kun betroede artefakter deployeres til produktion.
- **Overvåg og auditér løbende:** Implementer kontinuerlig overvågning af alle afhængigheder, inklusive modeller og datatjenester, for at opdage nye sårbarheder eller angreb på supply chain.
- **Anvend mindst privilegium og adgangskontrol:** Begræns adgangen til modeller, data og tjenester til kun det, der er nødvendigt for, at din MCP-server kan fungere.
- **Reager hurtigt på trusler:** Hav en proces for at patch’e eller udskifte kompromitterede komponenter samt for at rotere hemmeligheder eller legitimationsoplysninger, hvis et brud opdages.

[GitHub Advanced Security](https://github.com/security/advanced-security) tilbyder funktioner som secret scanning, dependency scanning og CodeQL-analyse. Disse værktøjer integreres med [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) og [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) for at hjælpe teams med at identificere og afbøde sårbarheder i både kode og AI supply chain-komponenter.

Microsoft implementerer også omfattende supply chain-sikkerhedspraksisser internt for alle produkter. Læs mere i [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Veletablerede sikkerhedspraksisser, der vil styrke sikkerheden i din MCP-implementering

Enhver MCP-implementering arver den eksisterende sikkerhedstilstand i din organisations miljø, som den er bygget ovenpå, så når du overvejer sikkerheden i MCP som en del af dine samlede AI-systemer, anbefales det at styrke din overordnede eksisterende sikkerhedstilstand. Følgende veletablerede sikkerhedskontroller er særligt relevante:

-   Sikker kodning i din AI-applikation – beskyt mod [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), brug sikre vaults til hemmeligheder og tokens, implementer end-to-end sikre kommunikationskanaler mellem alle applikationskomponenter osv.
-   Serverhårdning – brug MFA hvor muligt, hold patching opdateret, integrer serveren med en tredjeparts identitetsudbyder til adgangskontrol osv.
-   Hold enheder, infrastruktur og applikationer opdaterede med patches
-   Sikkerhedsovervågning – implementer logning og overvågning af en AI-applikation (inklusive MCP-klient/servere) og send disse logs til et centralt SIEM for at opdage unormale aktiviteter
-   Zero trust-arkitektur – isoler komponenter via netværks- og identitetskontroller på en logisk måde for at minimere lateral bevægelse, hvis en AI-applikation kompromitteres.

# Vigtige pointer

- Grundlæggende sikkerhedsprincipper er stadig afgørende: Sikker kodning, mindst privilegium, supply chain-verifikation og kontinuerlig overvågning er essentielle for MCP og AI-arbejdsbelastninger.
- MCP introducerer nye risici – såsom prompt injection, tool poisoning og overdrevne tilladelser – som kræver både traditionelle og AI-specifikke kontroller.
- Brug robuste autentificerings-, autorisations- og tokenhåndteringspraksisser, og udnyt eksterne identitetsudbydere som Microsoft Entra ID, hvor det er muligt.
- Beskyt mod indirekte prompt injection og tool poisoning ved at validere tool-metadata, overvåge dynamiske ændringer og bruge løsninger som Microsoft Prompt Shields.
- Behandl alle komponenter i din AI supply chain – inklusive modeller, embeddings og kontekstudbydere – med samme omhu som kodeafhængigheder.
- Hold dig opdateret med de udviklende MCP-specifikationer og bidrag til fællesskabet for at hjælpe med at forme sikre standarder.

# Yderligere ressourcer

- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
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
- [MCP Security Best Practice](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Næste

Næste: [Chapter 3: Getting Started](../03-GettingStarted/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.