<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-20T23:12:07+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "da"
}
-->
# Security Best Practices

Implementering af Model Context Protocol (MCP) giver stærke nye muligheder for AI-drevne applikationer, men introducerer også unikke sikkerhedsudfordringer, der går ud over traditionelle software-risici. Udover velkendte bekymringer som sikker kodning, mindst privilegium og supply chain-sikkerhed står MCP og AI-arbejdsbelastninger over for nye trusler som prompt injection, tool poisoning og dynamisk værktøjsmodifikation. Disse risici kan føre til dataudtræk, brud på privatlivets fred og utilsigtet systemadfærd, hvis de ikke håndteres korrekt.

Denne lektion gennemgår de mest relevante sikkerhedsrisici forbundet med MCP—herunder autentificering, autorisation, overdrevne tilladelser, indirekte prompt injection og supply chain-sårbarheder—og giver konkrete kontroller og bedste praksis til at afbøde dem. Du vil også lære, hvordan du kan bruge Microsoft-løsninger som Prompt Shields, Azure Content Safety og GitHub Advanced Security til at styrke din MCP-implementering. Ved at forstå og anvende disse kontroller kan du markant reducere sandsynligheden for et sikkerhedsbrud og sikre, at dine AI-systemer forbliver robuste og pålidelige.

# Learning Objectives

Når du er færdig med denne lektion, vil du kunne:

- Identificere og forklare de unikke sikkerhedsrisici, som Model Context Protocol (MCP) medfører, herunder prompt injection, tool poisoning, overdrevne tilladelser og supply chain-sårbarheder.
- Beskrive og anvende effektive afbødende kontroller for MCP-sikkerhedsrisici, såsom robust autentificering, mindst privilegium, sikker token-håndtering og supply chain-verifikation.
- Forstå og udnytte Microsoft-løsninger som Prompt Shields, Azure Content Safety og GitHub Advanced Security til at beskytte MCP og AI-arbejdsbelastninger.
- Anerkende vigtigheden af at validere værktøjsmetadata, overvåge dynamiske ændringer og forsvare mod indirekte prompt injection-angreb.
- Integrere etablerede sikkerhedspraksisser—såsom sikker kodning, serverhårdning og zero trust-arkitektur—i din MCP-implementering for at mindske risikoen og konsekvenserne af sikkerhedsbrud.

# MCP security controls

Enhver system med adgang til vigtige ressourcer har iboende sikkerhedsudfordringer. Disse kan som regel håndteres gennem korrekt anvendelse af grundlæggende sikkerhedskontroller og -koncepter. Da MCP er en relativt ny protokol, ændrer specifikationen sig hurtigt, og efterhånden som protokollen udvikler sig, vil sikkerhedskontrollerne modne, hvilket muliggør bedre integration med virksomheders og etablerede sikkerhedsarkitekturer og bedste praksis.

Forskning offentliggjort i [Microsoft Digital Defense Report](https://aka.ms/mddr) viser, at 98 % af rapporterede brud kunne være forhindret ved robust sikkerhedshygiejne, og den bedste beskyttelse mod ethvert brud er at have styr på grundlæggende sikkerhedshygiejne, sikker kodning og supply chain-sikkerhed — de velafprøvede metoder, vi allerede kender, har stadig størst effekt på at reducere sikkerhedsrisici.

Lad os se på nogle af de måder, du kan begynde at håndtere sikkerhedsrisici, når du implementerer MCP.

# MCP server authentication (if your MCP implementation was before 26th April 2025)

> **Note:** Følgende oplysninger er korrekte pr. 26. april 2025. MCP-protokollen udvikler sig løbende, og fremtidige implementeringer kan introducere nye autentificeringsmønstre og kontroller. For de seneste opdateringer og vejledning henvises altid til [MCP Specification](https://spec.modelcontextprotocol.io/) og den officielle [MCP GitHub repository](https://github.com/modelcontextprotocol).

### Problem statement  
Den oprindelige MCP-specifikation antog, at udviklere selv ville skrive deres egen autentificeringsserver. Dette krævede viden om OAuth og relaterede sikkerhedsbegrænsninger. MCP-servere fungerede som OAuth 2.0 Authorization Servers, der håndterede brugerautentificeringen direkte i stedet for at delegere den til en ekstern tjeneste som Microsoft Entra ID. Fra og med 26. april 2025 tillader en opdatering af MCP-specifikationen, at MCP-servere kan delegere brugerautentificeringen til en ekstern tjeneste.

### Risks
- Forkert konfigureret autorisationslogik i MCP-serveren kan føre til eksponering af følsomme data og forkert anvendte adgangskontroller.
- OAuth-token-tyveri på den lokale MCP-server. Hvis tokenet stjæles, kan det bruges til at udgive sig for MCP-serveren og få adgang til ressourcer og data fra den service, som OAuth-tokenet gælder for.

### Mitigating controls
- **Review and Harden Authorization Logic:** Gennemgå og styrk autorisationslogikken i din MCP-server for at sikre, at kun de tilsigtede brugere og klienter får adgang til følsomme ressourcer. For praktisk vejledning, se [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) og [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Enforce Secure Token Practices:** Følg [Microsofts bedste praksis for tokenvalidering og levetid](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) for at forhindre misbrug af adgangstokens og reducere risikoen for token replay eller tyveri.
- **Protect Token Storage:** Opbevar altid tokens sikkert og brug kryptering for at beskytte dem både i hvile og under overførsel. For implementeringstips, se [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Excessive permissions for MCP servers

### Problem statement  
MCP-servere kan have fået tildelt overdrevne tilladelser til den service/ressource, de tilgår. For eksempel bør en MCP-server, der er en del af en AI-salgsapplikation, der forbinder til en virksomhedsdatabutik, kun have adgang til salgsdata og ikke tilladelse til at tilgå alle filer i butikken. Med henvisning til princippet om mindst privilegium (et af de ældste sikkerhedsprincipper) bør ingen ressource have tilladelser, der overstiger det, der er nødvendigt for at udføre de opgaver, den er tiltænkt. AI udgør en særlig udfordring her, fordi fleksibilitet kan gøre det vanskeligt at definere præcist, hvilke tilladelser der er nødvendige.

### Risks  
- Overdrevne tilladelser kan tillade dataudtræk eller ændringer i data, som MCP-serveren ikke burde have adgang til. Dette kan også være et privatlivsproblem, hvis dataene indeholder personligt identificerbare oplysninger (PII).

### Mitigating controls  
- **Apply the Principle of Least Privilege:** Giv MCP-serveren kun de minimale tilladelser, der er nødvendige for at udføre dens opgaver. Gennemgå og opdater disse tilladelser regelmæssigt for at sikre, at de ikke overstiger behovet. For detaljeret vejledning, se [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Use Role-Based Access Control (RBAC):** Tildel roller til MCP-serveren, der er nøje afgrænsede til specifikke ressourcer og handlinger, og undgå brede eller unødvendige tilladelser.
- **Monitor and Audit Permissions:** Overvåg løbende brugen af tilladelser og gennemgå adgangslogfiler for hurtigt at opdage og afhjælpe overdrevne eller ubrugte privilegier.

# Indirect prompt injection attacks

### Problem statement

Ondsindede eller kompromitterede MCP-servere kan medføre betydelige risici ved at eksponere kundedata eller muliggøre utilsigtede handlinger. Disse risici er særligt relevante i AI- og MCP-baserede arbejdsbelastninger, hvor:

- **Prompt Injection Attacks:** Angribere indlejrer ondsindede instruktioner i prompts eller eksternt indhold, hvilket får AI-systemet til at udføre utilsigtede handlinger eller lække følsomme data. Læs mere: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning:** Angribere manipulerer værktøjsmetadata (som beskrivelser eller parametre) for at påvirke AI’ens adfærd, potentielt forbigå sikkerhedskontroller eller udtrække data. Detaljer: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection:** Ondsindede instruktioner indlejres i dokumenter, websider eller e-mails, som derefter behandles af AI’en, hvilket kan føre til datalækage eller manipulation.
- **Dynamic Tool Modification (Rug Pulls):** Værktøjsdefinitioner kan ændres efter brugerens godkendelse og indføre nye ondsindede handlinger uden brugerens viden.

Disse sårbarheder understreger behovet for solid validering, overvågning og sikkerhedskontroller, når MCP-servere og værktøjer integreres i dit miljø. For en dybere gennemgang, se de ovennævnte referencer.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.da.png)

**Indirect Prompt Injection** (også kendt som cross-domain prompt injection eller XPIA) er en kritisk sårbarhed i generative AI-systemer, inklusive dem der bruger Model Context Protocol (MCP). I dette angreb skjules ondsindede instruktioner i eksternt indhold—såsom dokumenter, websider eller e-mails. Når AI-systemet behandler dette indhold, kan det fortolke de skjulte instruktioner som legitime brugerkommandoer, hvilket fører til utilsigtede handlinger som datalækage, generering af skadeligt indhold eller manipulation af brugerinteraktioner. For en detaljeret forklaring og eksempler fra virkeligheden, se [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

En særlig farlig form for dette angreb er **Tool Poisoning**. Her injicerer angribere ondsindede instruktioner i metadata for MCP-værktøjer (såsom værktøjsbeskrivelser eller parametre). Da store sprogmodeller (LLM’er) baserer deres valg af værktøjer på disse metadata, kan kompromitterede beskrivelser narre modellen til at udføre uautoriserede værktøjskald eller omgå sikkerhedskontroller. Disse manipulationer er ofte usynlige for slutbrugerne, men kan fortolkes og udføres af AI-systemet. Risikoen øges i hosted MCP-servermiljøer, hvor værktøjsdefinitioner kan opdateres efter brugerens godkendelse—et scenarie nogle gange kaldet en "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". I sådanne tilfælde kan et tidligere sikkert værktøj senere ændres til at udføre ondsindede handlinger, såsom dataudtræk eller ændring af systemadfærd, uden brugerens viden. For mere om denne angrebsvektor, se [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.da.png)

## Risks  
Utilsigtede AI-handlinger udgør forskellige sikkerhedsrisici, herunder dataudtræk og brud på privatlivets fred.

### Mitigating controls  
### Using prompt shields to protect against Indirect Prompt Injection attacks  
-----------------------------------------------------------------------------

**AI Prompt Shields** er en løsning udviklet af Microsoft til at beskytte mod både direkte og indirekte prompt injection-angreb. De hjælper ved:

1.  **Detection and Filtering:** Prompt Shields anvender avancerede maskinlæringsalgoritmer og naturlig sprogbehandling til at opdage og filtrere ondsindede instruktioner indlejret i eksternt indhold som dokumenter, websider eller e-mails.
    
2.  **Spotlighting:** Denne teknik hjælper AI-systemet med at skelne mellem gyldige systeminstruktioner og potentielt utroværdige eksterne input. Ved at transformere inputteksten på en måde, der gør den mere relevant for modellen, sikrer Spotlighting, at AI’en bedre kan identificere og ignorere ondsindede instruktioner.
    
3.  **Delimiters and Datamarking:** Inddragelse af afgrænsere i systembeskeden angiver tydeligt placeringen af inputteksten, hvilket hjælper AI-systemet med at genkende og adskille brugerinput fra potentielt skadeligt eksternt indhold. Datamarking udvider dette koncept ved at bruge særlige markører til at fremhæve grænserne mellem betroede og utroværdige data.
    
4.  **Continuous Monitoring and Updates:** Microsoft overvåger og opdaterer løbende Prompt Shields for at håndtere nye og udviklende trusler. Denne proaktive tilgang sikrer, at forsvaret forbliver effektivt mod de nyeste angrebsteknikker.
    
5. **Integration with Azure Content Safety:** Prompt Shields er en del af den bredere Azure AI Content Safety-pakke, som tilbyder yderligere værktøjer til at opdage jailbreak-forsøg, skadeligt indhold og andre sikkerhedsrisici i AI-applikationer.

Du kan læse mere om AI prompt shields i [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.da.png)

### Supply chain security

Supply chain-sikkerhed forbliver grundlæggende i AI-æraen, men omfanget af, hvad der udgør din supply chain, er udvidet. Udover traditionelle kodepakker skal du nu grundigt verificere og overvåge alle AI-relaterede komponenter, herunder foundation models, embeddings-services, context providers og tredjeparts-API’er. Hver af disse kan introducere sårbarheder eller risici, hvis de ikke håndteres korrekt.

**Nøglepraksis for supply chain-sikkerhed i AI og MCP:**
- **Verify all components before integration:** Dette omfatter ikke kun open source-biblioteker, men også AI-modeller, datakilder og eksterne API’er. Kontroller altid oprindelse, licensering og kendte sårbarheder.
- **Maintain secure deployment pipelines:** Brug automatiserede CI/CD-pipelines med integreret sikkerhedsscanning for tidligt at fange problemer. Sørg for, at kun betroede artefakter deployeres til produktion.
- **Continuously monitor and audit:** Implementer løbende overvågning af alle afhængigheder, inklusive modeller og datatjenester, for at opdage nye sårbarheder eller supply chain-angreb.
- **Apply least privilege and access controls:** Begræns adgangen til modeller, data og tjenester til kun det, der er nødvendigt for, at din MCP-server kan fungere.
- **Respond quickly to threats:** Hav en proces på plads for at patche eller udskifte kompromitterede komponenter og for at rotere hemmeligheder eller legitimationsoplysninger, hvis et brud opdages.

[GitHub Advanced Security](https://github.com/security/advanced-security) tilbyder funktioner som scanning for hemmeligheder, afhængighedsscanning og CodeQL-analyse. Disse værktøjer integreres med [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) og [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) for at hjælpe teams med at identificere og afbøde sårbarheder i både kode og AI-supply chain-komponenter.

Microsoft implementerer også omfattende supply chain-sikkerhedspraksis internt for alle produkter. Læs mere i [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Established security best practices that will uplift your MCP implementation's security posture

Enhver MCP-implementering arver den eksisterende sikkerhedstilstand i den organisationsmiljø, den er bygget ovenpå. Derfor anbefales det at styrke den overordnede eksisterende sikkerhedstilstand, når du vurderer sikkerheden i MCP som en del af dine samlede AI-systemer. Følgende etablerede sikkerhedskontroller er særligt relevante:

- Sikker kodningspraksis i din AI-applikation – beskyt mod [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), brug af sikre vaults til hemmeligheder og tokens, implementering af end-to-end sikre kommunikationer mellem alle applikationskomponenter osv.
- Serverhårdning – brug MFA hvor muligt, hold patches opdaterede, integrer serveren med en tredjeparts identitetsudbyder til adgang osv.
- Hold enheder, infrastruktur og applikationer opdaterede med patches
- Sikkerhedsovervågning – implementer logning og overvågning af en AI-applikation (inklusive MCP-klient/servere) og send disse logs til et centralt SIEM for at opdage unormal aktivitet
- Zero trust-arkitektur –
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Rejsen mod at sikre softwareforsyningskæden hos Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Sikker adgang med mindst mulige rettigheder (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Bedste praksis for tokenvalidering og levetid](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Brug sikker tokenlagring og krypter tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management som autentificeringsgateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Brug af Microsoft Entra ID til autentificering med MCP-servere](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Næste

Næste: [Kapitel 3: Kom godt i gang](/03-GettingStarted/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for eventuelle misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.