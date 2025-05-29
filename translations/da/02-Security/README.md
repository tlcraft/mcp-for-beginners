<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00aedb7b1d11b7eaacb0618d8791c65",
  "translation_date": "2025-05-29T23:22:58+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "da"
}
-->
# Security Best Practices

Implementering af Model Context Protocol (MCP) bringer kraftfulde nye muligheder til AI-drevne applikationer, men introducerer også unikke sikkerhedsudfordringer, som går ud over traditionelle softwarerisici. Ud over velkendte bekymringer som sikker kodning, mindst privilegium og forsyningskædesikkerhed, står MCP og AI-arbejdsbelastninger over for nye trusler som prompt-injektion, værktøjsforgiftning og dynamisk værktøjsændring. Disse risici kan føre til dataudtræk, brud på privatlivets fred og utilsigtet systemadfærd, hvis de ikke håndteres korrekt.

Denne lektion gennemgår de mest relevante sikkerhedsrisici forbundet med MCP—herunder autentificering, autorisation, overdrevne tilladelser, indirekte prompt-injektion og sårbarheder i forsyningskæden—og giver konkrete kontroller og bedste praksis til at afbøde dem. Du vil også lære, hvordan du kan udnytte Microsoft-løsninger som Prompt Shields, Azure Content Safety og GitHub Advanced Security til at styrke din MCP-implementering. Ved at forstå og anvende disse kontroller kan du markant reducere sandsynligheden for et sikkerhedsbrud og sikre, at dine AI-systemer forbliver robuste og pålidelige.

# Learning Objectives

Når du har gennemført denne lektion, vil du kunne:

- Identificere og forklare de unikke sikkerhedsrisici, som Model Context Protocol (MCP) introducerer, herunder prompt-injektion, værktøjsforgiftning, overdrevne tilladelser og sårbarheder i forsyningskæden.
- Beskrive og anvende effektive afbødende kontroller for MCP’s sikkerhedsrisici, såsom robust autentificering, mindst privilegium, sikker tokenhåndtering og verifikation af forsyningskæden.
- Forstå og udnytte Microsoft-løsninger som Prompt Shields, Azure Content Safety og GitHub Advanced Security til at beskytte MCP og AI-arbejdsbelastninger.
- Genkende vigtigheden af at validere værktøjsmetadata, overvåge dynamiske ændringer og forsvare mod indirekte prompt-injektion.
- Integrere etablerede sikkerhedsbest practices—såsom sikker kodning, serverhærde, og zero trust-arkitektur—i din MCP-implementering for at mindske sandsynligheden og konsekvenserne af sikkerhedsbrud.

# MCP security controls

Enhver system med adgang til vigtige ressourcer har iboende sikkerhedsudfordringer. Disse kan som regel håndteres gennem korrekt anvendelse af grundlæggende sikkerhedskontroller og -principper. Da MCP er nydefineret, ændrer specifikationen sig hurtigt, og protokollen udvikler sig løbende. Med tiden vil sikkerhedskontrollerne i MCP modne, hvilket muliggør bedre integration med virksomheders eksisterende sikkerhedsarkitektur og bedste praksis.

Forskning offentliggjort i [Microsoft Digital Defense Report](https://aka.ms/mddr) viser, at 98% af rapporterede brud kunne være forhindret med robust sikkerhedshygiejne. Den bedste beskyttelse mod ethvert brud er at have styr på basale sikkerhedshygiejne, sikre kodningspraksisser og forsyningskædesikkerhed – de velafprøvede metoder, vi allerede kender, har stadig størst effekt på at reducere sikkerhedsrisici.

Lad os se på nogle måder, hvorpå du kan begynde at håndtere sikkerhedsrisici, når du tager MCP i brug.

> **Note:** Følgende information er korrekt pr. **29. maj 2025**. MCP-protokollen udvikler sig løbende, og fremtidige implementeringer kan introducere nye autentificeringsmønstre og kontroller. For de seneste opdateringer og vejledning henvises altid til [MCP Specification](https://spec.modelcontextprotocol.io/) samt den officielle [MCP GitHub repository](https://github.com/modelcontextprotocol) og [security best practice page](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Problem statement  
Den oprindelige MCP-specifikation antog, at udviklere selv ville skrive deres autentificeringsserver. Dette krævede kendskab til OAuth og relaterede sikkerhedsbegrænsninger. MCP-servere fungerede som OAuth 2.0 Authorization Servers, der håndterede brugerautentificering direkte i stedet for at delegere den til en ekstern tjeneste som Microsoft Entra ID. Fra og med **26. april 2025** tillader en opdatering til MCP-specifikationen, at MCP-servere kan delegere brugerautentificering til en ekstern tjeneste.

### Risks
- Forkert konfigureret autorisationslogik i MCP-serveren kan føre til eksponering af følsomme data og fejlagtigt anvendte adgangskontroller.
- Tyveri af OAuth-token på den lokale MCP-server. Hvis tokenet stjæles, kan det bruges til at udgive sig for MCP-serveren og få adgang til ressourcer og data fra den tjeneste, som OAuth-tokenet gælder for.

#### Token Passthrough  
Token passthrough er udtrykkeligt forbudt i autorisationsspecifikationen, da det medfører flere sikkerhedsrisici, herunder:

#### Omgåelse af sikkerhedskontroller  
MCP-serveren eller efterfølgende API’er kan implementere vigtige sikkerhedskontroller som ratebegrænsning, forespørgselsvalidering eller trafikovervågning, som er afhængige af tokenets målgruppe eller andre legitimationsbegrænsninger. Hvis klienter kan opnå og bruge tokens direkte med efterfølgende API’er uden, at MCP-serveren validerer dem korrekt eller sikrer, at tokenet er udstedt til den rette tjeneste, omgår de disse kontroller.

#### Ansvar og revisionsspor  
MCP-serveren kan ikke identificere eller skelne mellem MCP-klienter, når klienter kalder med et upstream-udstedt adgangstoken, som kan være uigennemsigtigt for MCP-serveren.  
Logfilerne på den efterfølgende ressource-server kan vise anmodninger, der ser ud til at komme fra en anden kilde med en anden identitet end den MCP-server, der faktisk videresender tokenet.  
Begge faktorer gør hændelsesundersøgelser, kontrol og revision mere vanskelige.  
Hvis MCP-serveren videresender tokens uden at validere deres claims (f.eks. roller, privilegier eller målgruppe) eller anden metadata, kan en ondsindet aktør med et stjålet token bruge serveren som en proxy til dataudtræk.

#### Problemer med tillidsgrænse  
Den efterfølgende ressource-server giver tillid til specifikke enheder. Denne tillid kan inkludere antagelser om oprindelse eller klientadfærdsmønstre. At bryde denne tillidsgrænse kan føre til uventede problemer.  
Hvis tokenet accepteres af flere tjenester uden korrekt validering, kan en angriber, der kompromitterer én tjeneste, bruge tokenet til at få adgang til andre tilknyttede tjenester.

#### Risiko for fremtidig kompatibilitet  
Selvom en MCP-server i dag starter som en “ren proxy”, kan den senere få behov for at tilføje sikkerhedskontroller. At starte med korrekt adskillelse af tokenmålgrupper gør det nemmere at udvikle sikkerhedsmodellen.

### Mitigating controls

**MCP-servere MÅ IKKE acceptere tokens, der ikke eksplicit er udstedt til MCP-serveren**

- **Gennemgå og styrk autorisationslogikken:** Revider omhyggeligt din MCP-servers autorisationsimplementering for at sikre, at kun tilsigtede brugere og klienter får adgang til følsomme ressourcer. For praktisk vejledning, se [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) og [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Håndhæv sikre token-praksisser:** Følg [Microsofts bedste praksis for tokenvalidering og levetid](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) for at forhindre misbrug af adgangstokens og reducere risikoen for token replay eller tyveri.
- **Beskyt tokenlagring:** Opbevar altid tokens sikkert og brug kryptering for at beskytte dem i hvile og under overførsel. For implementeringstips, se [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Excessive permissions for MCP servers

### Problem statement  
MCP-servere kan have fået tildelt overdrevne tilladelser til den tjeneste/ressource, de tilgår. For eksempel bør en MCP-server, der er en del af en AI-salgsapplikation, som forbinder til en virksomhedsdatabutik, kun have adgang begrænset til salgsdata og ikke adgang til alle filer i butikken. Tilbage til princippet om mindst privilegium (et af de ældste sikkerhedsprincipper): ingen ressource bør have tilladelser ud over det, der er nødvendigt for at udføre de opgaver, den er tiltænkt. AI udgør en øget udfordring her, da fleksibilitet gør det svært at definere præcist, hvilke tilladelser der kræves.

### Risks  
- At give overdrevne tilladelser kan tillade udtræk eller ændring af data, som MCP-serveren ikke skulle have adgang til. Dette kan også udgøre et privatlivsproblem, hvis dataene indeholder personligt identificerbare oplysninger (PII).

### Mitigating controls  
- **Anvend princippet om mindst privilegium:** Giv MCP-serveren kun de minimale tilladelser, der er nødvendige for at udføre de krævede opgaver. Gennemgå og opdater disse tilladelser regelmæssigt for at sikre, at de ikke overstiger, hvad der er nødvendigt. For detaljeret vejledning, se [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Brug rollebaseret adgangskontrol (RBAC):** Tildel roller til MCP-serveren, der er stramt afgrænset til specifikke ressourcer og handlinger, og undgå brede eller unødvendige tilladelser.
- **Overvåg og revider tilladelser:** Overvåg løbende brugen af tilladelser og revider adgangslogs for hurtigt at opdage og rette overdrevne eller ubrugte privilegier.

# Indirect prompt injection attacks

### Problem statement

Ondsindede eller kompromitterede MCP-servere kan udgøre betydelige risici ved at eksponere kundedata eller muliggøre utilsigtede handlinger. Disse risici er særligt relevante i AI- og MCP-baserede arbejdsbelastninger, hvor:

- **Prompt Injection Attacks:** Angribere indlejrer ondsindede instruktioner i prompts eller eksternt indhold, hvilket får AI-systemet til at udføre utilsigtede handlinger eller lække følsomme data. Læs mere: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning:** Angribere manipulerer værktøjsmetadata (såsom beskrivelser eller parametre) for at påvirke AI’ens adfærd, potentielt forbigå sikkerhedskontroller eller udtrække data. Detaljer: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection:** Ondsindede instruktioner indlejres i dokumenter, websider eller e-mails, som derefter behandles af AI’en, hvilket fører til datalækage eller manipulation.
- **Dynamic Tool Modification (Rug Pulls):** Værktøjsdefinitioner kan ændres efter brugerens godkendelse og introducere nye ondsindede handlinger uden brugerens viden.

Disse sårbarheder understreger behovet for robust validering, overvågning og sikkerhedskontroller, når MCP-servere og værktøjer integreres i dit miljø. For en dybere gennemgang, se de linkede referencer ovenfor.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.da.png)

**Indirect Prompt Injection** (også kendt som cross-domain prompt injection eller XPIA) er en kritisk sårbarhed i generative AI-systemer, inklusive dem der bruger Model Context Protocol (MCP). Ved dette angreb skjules ondsindede instruktioner i eksternt indhold—såsom dokumenter, websider eller e-mails. Når AI-systemet behandler dette indhold, kan det tolke de indlejrede instruktioner som legitime brugerkommandoer, hvilket resulterer i utilsigtede handlinger som datalækage, generering af skadeligt indhold eller manipulation af brugerinteraktioner. For en detaljeret forklaring og eksempler fra virkeligheden, se [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

En særlig farlig form for dette angreb er **Tool Poisoning**. Her injicerer angribere ondsindede instruktioner i metadata for MCP-værktøjer (såsom værktøjsbeskrivelser eller parametre). Da store sprogmodeller (LLM’er) baserer deres valg af værktøjer på denne metadata, kan kompromitterede beskrivelser narre modellen til at udføre uautoriserede værktøjskald eller omgå sikkerhedskontroller. Disse manipulationer er ofte usynlige for slutbrugere, men kan tolkes og eksekveres af AI-systemet. Denne risiko forstærkes i hostede MCP-servermiljøer, hvor værktøjsdefinitioner kan opdateres efter brugerens godkendelse—et scenarie, der nogle gange kaldes en "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". I sådanne tilfælde kan et tidligere sikkert værktøj senere ændres til at udføre ondsindede handlinger, som dataudtræk eller ændring af systemadfærd, uden brugerens viden. For mere om denne angrebsvektor, se [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.da.png)

## Risks  
Utilsigtede AI-handlinger udgør en række sikkerhedsrisici, herunder dataudtræk og brud på privatlivets fred.

### Mitigating controls  
### Using prompt shields to protect against Indirect Prompt Injection attacks  
-----------------------------------------------------------------------------

**AI Prompt Shields** er en løsning udviklet af Microsoft til at beskytte mod både direkte og indirekte prompt-injektion. De hjælper gennem:

1.  **Detektion og filtrering:** Prompt Shields anvender avancerede maskinlæringsalgoritmer og naturlig sprogbehandling til at opdage og filtrere ondsindede instruktioner indlejret i eksternt indhold som dokumenter, websider eller e-mails.
    
2.  **Spotlighting:** Denne teknik hjælper AI-systemet med at skelne mellem gyldige systeminstruktioner og potentielt upålidelige eksterne input. Ved at transformere inputteksten, så den bliver mere relevant for modellen, sikrer Spotlighting, at AI’en bedre kan identificere og ignorere ondsindede instruktioner.
    
3.  **Afgrænsere og datamarkering:** Inkludering af afgrænsere i systemmeddelelsen tydeliggør placeringen af inputteksten, hvilket hjælper AI-systemet med at genkende og adskille brugerinput fra potentielt skadeligt eksternt indhold. Datamarkering udvider dette koncept ved at bruge særlige markører til at fremhæve grænserne mellem betroede og ikke-betroede data.
    
4.  **Kontinuerlig overvågning og opdateringer:** Microsoft overvåger og opdaterer løbende Prompt Shields for at imødekomme nye og udviklende trusler. Denne proaktive tilgang sikrer, at forsvaret forbliver effektivt mod de nyeste angrebsteknikker.
    
5. **Integration med Azure Content Safety:** Prompt Shields er en del af den bredere Azure AI Content Safety-suite, som tilbyder yderligere værktøjer til at opdage jailbreak-forsøg, skadeligt indhold og andre sikkerhedsrisici i AI-applikationer.

Du kan læse mere om AI prompt shields i [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.da.png)

### Supply chain security

Forsyningskædesikkerhed er stadig grundlæggende i AI-æraen, men omfanget af, hvad der udgør din forsyningskæde, er udvidet. Ud over traditionelle kodepakker skal du nu grundigt verificere og overvåge alle AI-relaterede komponenter, inklusive grundmodeller, embeddings-tjenester, kontekstleverandører og tredjeparts-API’er. Hver af disse kan introducere sårbarheder eller risici, hvis de ikke håndteres korrekt.

**Nøglepraksis for forsyningskædesikkerhed i AI og MCP:**  
- **Verificer alle komponenter før integration:** Dette inkluderer ikke kun open source-biblioteker, men også AI-modeller, datakilder og eksterne API’er. Tjek altid oprindelse, licenser og kendte sårbarheder.  
- **Oprethold sikre deployments pipelines:** Brug automatiserede CI/CD-pipelines med
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Rejsen mod at sikre softwareforsyningskæden hos Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Sikker mindst-privilegeret adgang (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Bedste praksis for tokenvalidering og levetid](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Brug sikker tokenlagring og krypter tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management som Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [MCP sikkerheds bedste praksis](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Brug af Microsoft Entra ID til autentificering med MCP-servere](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Næste

Næste: [Kapitel 3: Kom godt i gang](/03-GettingStarted/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, skal du være opmærksom på, at automatiske oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets modersmål bør betragtes som den autoritative kilde. For kritiske oplysninger anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.