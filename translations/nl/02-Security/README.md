<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00aedb7b1d11b7eaacb0618d8791c65",
  "translation_date": "2025-05-29T23:25:51+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "nl"
}
-->
# Security Best Practices

Het toepassen van het Model Context Protocol (MCP) biedt krachtige nieuwe mogelijkheden voor AI-gedreven toepassingen, maar brengt ook unieke beveiligingsuitdagingen met zich mee die verder gaan dan traditionele softwarerisico’s. Naast bekende aandachtspunten zoals veilig coderen, het principe van minste privileges en beveiliging van de supply chain, worden MCP en AI workloads geconfronteerd met nieuwe bedreigingen zoals prompt injection, tool poisoning en dynamische aanpassing van tools. Deze risico’s kunnen leiden tot datalekken, privacyinbreuken en onbedoeld systeemgedrag als ze niet goed worden beheerd.

Deze les behandelt de belangrijkste beveiligingsrisico’s rondom MCP — waaronder authenticatie, autorisatie, te ruime permissies, indirecte prompt injection en kwetsbaarheden in de supply chain — en biedt praktische maatregelen en best practices om deze te beperken. Je leert ook hoe je Microsoft-oplossingen zoals Prompt Shields, Azure Content Safety en GitHub Advanced Security kunt inzetten om je MCP-implementatie te versterken. Door deze maatregelen te begrijpen en toe te passen, verklein je de kans op een beveiligingsincident en zorg je dat je AI-systemen robuust en betrouwbaar blijven.

# Leerdoelen

Aan het einde van deze les kun je:

- De unieke beveiligingsrisico’s van het Model Context Protocol (MCP) herkennen en uitleggen, zoals prompt injection, tool poisoning, te ruime permissies en kwetsbaarheden in de supply chain.
- Effectieve maatregelen toepassen om MCP-beveiligingsrisico’s te beperken, zoals sterke authenticatie, het principe van minste privileges, veilig tokenbeheer en verificatie van de supply chain.
- Microsoft-oplossingen als Prompt Shields, Azure Content Safety en GitHub Advanced Security begrijpen en inzetten ter bescherming van MCP en AI workloads.
- Het belang inzien van het valideren van toolmetadata, het monitoren van dynamische wijzigingen en het verdedigen tegen indirecte prompt injection-aanvallen.
- Bestaande beveiligingsbest practices — zoals veilig coderen, serververharding en zero trust architectuur — integreren in je MCP-implementatie om de kans en impact van beveiligingsincidenten te verminderen.

# MCP beveiligingsmaatregelen

Elk systeem dat toegang heeft tot belangrijke resources brengt impliciete beveiligingsuitdagingen met zich mee. Deze uitdagingen kunnen doorgaans worden aangepakt door het juiste gebruik van fundamentele beveiligingsmaatregelen en -concepten. Omdat MCP nog relatief nieuw is, verandert de specificatie snel en ontwikkelt het protocol zich nog. Uiteindelijk zullen de beveiligingsmaatregelen hierin volwassen worden, wat betere integratie mogelijk maakt met enterprise- en gevestigde beveiligingsarchitecturen en best practices.

Onderzoek in het [Microsoft Digital Defense Report](https://aka.ms/mddr) toont aan dat 98% van de gerapporteerde beveiligingsinbreuken voorkomen had kunnen worden door een goede beveiligingshygiëne. De beste bescherming tegen elke vorm van inbraak is het op orde hebben van je basisbeveiliging, veilig coderen en beveiliging van de supply chain — die beproefde methoden blijven het meest effectief om risico’s te verkleinen.

Laten we eens kijken naar enkele manieren waarop je beveiligingsrisico’s kunt aanpakken bij het adopteren van MCP.

> **Note:** De volgende informatie is correct per **29 mei 2025**. Het MCP-protocol blijft in ontwikkeling, en toekomstige implementaties kunnen nieuwe authenticatiepatronen en maatregelen introduceren. Raadpleeg altijd de [MCP Specification](https://spec.modelcontextprotocol.io/) en de officiële [MCP GitHub repository](https://github.com/modelcontextprotocol) en [security best practice page](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices) voor de meest recente updates en richtlijnen.

### Probleemstelling  
De oorspronkelijke MCP-specificatie ging ervan uit dat ontwikkelaars hun eigen authenticatieserver zouden bouwen. Dit vereiste kennis van OAuth en gerelateerde beveiligingsbeperkingen. MCP-servers fungeerden als OAuth 2.0 Authorization Servers en beheerden de vereiste gebruikersauthenticatie direct, in plaats van deze uit te besteden aan een externe dienst zoals Microsoft Entra ID. Sinds **26 april 2025** staat een update van de MCP-specificatie toe dat MCP-servers gebruikersauthenticatie kunnen delegeren aan een externe dienst.

### Risico’s
- Onjuiste configuratie van autorisatielogica in de MCP-server kan leiden tot blootstelling van gevoelige data en verkeerd toegepaste toegangscontroles.
- Diefstal van OAuth-tokens op de lokale MCP-server. Als een token wordt gestolen, kan deze worden gebruikt om de MCP-server te imiteren en toegang te krijgen tot resources en data van de dienst waarvoor het OAuth-token is uitgegeven.

#### Token Passthrough
Token passthrough is expliciet verboden in de autorisatiespecificatie omdat het diverse beveiligingsrisico’s met zich meebrengt, waaronder:

#### Omzeilen van beveiligingsmaatregelen
De MCP-server of downstream API’s kunnen belangrijke beveiligingsmaatregelen implementeren zoals rate limiting, requestvalidatie of verkeersmonitoring, die afhankelijk zijn van de token audience of andere credentialbeperkingen. Als clients direct tokens kunnen verkrijgen en gebruiken bij downstream API’s zonder dat de MCP-server deze goed valideert of controleert of de tokens voor de juiste dienst zijn uitgegeven, worden deze maatregelen omzeild.

#### Problemen met verantwoordelijkheid en audittrail
De MCP-server kan niet onderscheiden welke MCP-clients requests doen wanneer clients een upstream-uitgegeven access token gebruiken die mogelijk ondoorzichtig is voor de MCP-server.  
De logs van de downstream Resource Server kunnen verzoeken tonen die lijken te komen van een andere bron met een andere identiteit dan de MCP-server die de tokens daadwerkelijk doorstuurt.  
Beide factoren bemoeilijken het onderzoeken van incidenten, het toepassen van controles en auditing.  
Als de MCP-server tokens doorgeeft zonder hun claims (zoals rollen, privileges of audience) of andere metadata te valideren, kan een kwaadwillende met een gestolen token de server als proxy gebruiken voor datalekken.

#### Vertrouwensgrensproblemen
De downstream Resource Server vertrouwt specifieke entiteiten, inclusief aannames over herkomst of gedragspatronen van clients. Het doorbreken van deze vertrouwensgrens kan leiden tot onverwachte problemen.  
Als het token door meerdere diensten wordt geaccepteerd zonder goede validatie, kan een aanvaller die één dienst compromitteert het token gebruiken om toegang te krijgen tot andere verbonden diensten.

#### Risico op toekomstige compatibiliteit
Zelfs als een MCP-server vandaag begint als een “pure proxy”, kan het later nodig zijn om beveiligingsmaatregelen toe te voegen. Door vanaf het begin een correcte scheiding van token audience toe te passen, wordt het makkelijker om het beveiligingsmodel te laten evolueren.

### Maatregelen ter mitigatie

**MCP-servers MOGEN GEEN tokens accepteren die niet expliciet voor de MCP-server zijn uitgegeven**

- **Herzie en versterk autorisatielogica:** Controleer zorgvuldig de implementatie van autorisatie in je MCP-server om te garanderen dat alleen bedoelde gebruikers en clients toegang krijgen tot gevoelige resources. Voor praktische richtlijnen, zie [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) en [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Handhaaf veilige tokenpraktijken:** Volg [Microsoft’s best practices voor tokenvalidatie en levensduur](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) om misbruik van access tokens te voorkomen en het risico op token replay of diefstal te verminderen.
- **Bescherm tokenopslag:** Sla tokens altijd veilig op en gebruik encryptie om ze zowel in rust als tijdens transport te beveiligen. Voor implementatietips, zie [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Te ruime permissies voor MCP-servers

### Probleemstelling
MCP-servers kunnen te ruime permissies hebben gekregen voor de service of resource waartoe ze toegang hebben. Bijvoorbeeld, een MCP-server die deel uitmaakt van een AI-salesapplicatie die verbinding maakt met een bedrijfsdatastore, zou alleen toegang moeten hebben tot de salesdata en niet tot alle bestanden in de datastore. Teruggrijpend op het principe van minste privilege (een van de oudste beveiligingsprincipes), mag geen enkele resource permissies hebben die verder gaan dan strikt noodzakelijk is voor de uitvoering van de beoogde taken. AI vormt een extra uitdaging omdat het vanwege de flexibiliteit lastig kan zijn om precies te definiëren welke permissies vereist zijn.

### Risico’s  
- Te ruime permissies kunnen leiden tot datalekken of het wijzigen van data waarvoor de MCP-server niet bedoeld is. Dit kan ook een privacyprobleem zijn als het gaat om persoonsgegevens (PII).

### Maatregelen ter mitigatie
- **Pas het principe van minste privilege toe:** Geef de MCP-server alleen de minimale permissies die nodig zijn voor zijn taken. Herzie en actualiseer deze permissies regelmatig om te voorkomen dat ze te ruim worden. Voor gedetailleerde richtlijnen, zie [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Gebruik Role-Based Access Control (RBAC):** Ken rollen toe aan de MCP-server die nauwkeurig zijn afgestemd op specifieke resources en acties, vermijd brede of onnodige permissies.
- **Monitor en audit permissies:** Houd het gebruik van permissies continu in de gaten en audit toegangslogs om te veel of ongebruikte rechten snel te detecteren en aan te pakken.

# Indirecte prompt injection-aanvallen

### Probleemstelling

Kwaadwillende of gecompromitteerde MCP-servers kunnen aanzienlijke risico’s veroorzaken door klantgegevens bloot te stellen of onbedoelde acties mogelijk te maken. Deze risico’s zijn vooral relevant bij AI- en MCP-gebaseerde workloads, waar:

- **Prompt Injection Attacks**: Aanvallers verstoppen kwaadaardige instructies in prompts of externe content, waardoor het AI-systeem onbedoelde acties uitvoert of gevoelige data lekt. Meer info: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning**: Aanvallers manipuleren toolmetadata (zoals beschrijvingen of parameters) om het gedrag van de AI te beïnvloeden, mogelijk om beveiligingsmaatregelen te omzeilen of data te exfiltreren. Details: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection**: Kwaadaardige instructies zijn ingebed in documenten, webpagina’s of e-mails, die vervolgens door de AI worden verwerkt, wat leidt tot datalekken of manipulatie.
- **Dynamische toolaanpassing (Rug Pulls)**: Tooldefinities kunnen na goedkeuring door de gebruiker worden gewijzigd, waardoor nieuwe kwaadaardige gedragingen worden geïntroduceerd zonder dat de gebruiker dit doorheeft.

Deze kwetsbaarheden benadrukken de noodzaak van robuuste validatie, monitoring en beveiligingsmaatregelen bij het integreren van MCP-servers en tools in je omgeving. Voor een diepere uitleg, zie de bovenstaande links.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.nl.png)

**Indirecte Prompt Injection** (ook bekend als cross-domain prompt injection of XPIA) is een kritieke kwetsbaarheid in generatieve AI-systemen, inclusief die welke het Model Context Protocol (MCP) gebruiken. Bij deze aanval worden kwaadaardige instructies verborgen in externe content — zoals documenten, webpagina’s of e-mails. Wanneer het AI-systeem deze content verwerkt, kan het de verborgen instructies interpreteren als legitieme gebruikerscommando’s, wat leidt tot onbedoelde acties zoals datalekken, genereren van schadelijke content of manipulatie van gebruikersinteracties. Voor een uitgebreide uitleg en praktijkvoorbeelden, zie [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Een bijzonder gevaarlijke vorm van deze aanval is **Tool Poisoning**. Hierbij injecteren aanvallers kwaadaardige instructies in de metadata van MCP-tools (zoals toolbeschrijvingen of parameters). Omdat grote taalmodellen (LLM’s) deze metadata gebruiken om te bepalen welke tools ze moeten aanroepen, kunnen gecompromitteerde beschrijvingen het model misleiden om ongeautoriseerde toolaanroepen te doen of beveiligingsmaatregelen te omzeilen. Deze manipulaties zijn vaak onzichtbaar voor eindgebruikers, maar worden door het AI-systeem geïnterpreteerd en uitgevoerd. Dit risico is extra groot in gehoste MCP-serveromgevingen, waar tooldefinities na goedkeuring door de gebruiker kunnen worden aangepast — een scenario dat soms een "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)" wordt genoemd. In zulke gevallen kan een eerder veilige tool later worden aangepast om kwaadaardige acties uit te voeren, zoals datalekken of het veranderen van systeemgedrag, zonder dat de gebruiker dit weet. Meer over deze aanvalsvector: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.nl.png)

## Risico’s
Onbedoelde AI-acties brengen diverse beveiligingsrisico’s met zich mee, waaronder datalekken en privacyinbreuken.

### Maatregelen ter mitigatie
### Gebruik van prompt shields ter bescherming tegen indirecte prompt injection-aanvallen
-----------------------------------------------------------------------------

**AI Prompt Shields** zijn een door Microsoft ontwikkelde oplossing om zowel directe als indirecte prompt injection-aanvallen te bestrijden. Ze bieden bescherming door:

1.  **Detectie en filtering:** Prompt Shields gebruiken geavanceerde machine learning-algoritmen en natuurlijke taalverwerking om kwaadaardige instructies in externe content — zoals documenten, webpagina’s of e-mails — te detecteren en te filteren.
    
2.  **Spotlighting:** Deze techniek helpt het AI-systeem onderscheid te maken tussen geldige systeeminstructies en mogelijk onbetrouwbare externe input. Door de inputtekst op een manier te transformeren die relevanter is voor het model, zorgt Spotlighting ervoor dat het AI-systeem kwaadaardige instructies beter kan herkennen en negeren.
    
3.  **Scheidingstekens en datamarking:** Het gebruik van scheidingstekens in het systeembericht geeft expliciet aan waar de inputtekst zich bevindt, waardoor het AI-systeem gebruikersinput kan onderscheiden van potentieel schadelijke externe content. Datamarking breidt dit concept uit door speciale markers te gebruiken om de grenzen tussen vertrouwde en onbetrouwbare data aan te geven.
    
4.  **Continue monitoring en updates:** Microsoft monitort en actualiseert Prompt Shields voortdurend om nieuwe en veranderende dreigingen het hoofd te bieden. Deze proactieve aanpak zorgt ervoor dat de bescherming effectief blijft tegen de nieuwste aanvalstechnieken.
    
5. **Integratie met Azure Content Safety:** Prompt Shields maken deel uit van de bredere Azure AI Content Safety-suite, die aanvullende tools biedt voor het detecteren van jailbreakpogingen, schadelijke content en andere beveiligingsrisico’s in AI-toepassingen.

Meer informatie over AI prompt shields vind je in de [Prompt Shields documentatie](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.nl.png)

### Supply chain security

Beveiliging van de supply chain blijft fundamenteel in het AI-tijdperk, maar de reikwijdte van wat onder je supply chain valt, is uitgebreid. Naast traditionele codepakketten moet je nu ook alle AI-gerelateerde componenten grondig verifiëren en monitoren, waaronder foundation models, embeddingdiensten, contextproviders en API’s van derden. Elk van deze kan kwetsbaarheden of risico’s introduceren als ze niet goed worden beheerd.

**Belangrijke supply chain beveiligingspraktijken voor AI en MCP:**
- **Verifieer alle componenten vóór integratie:** Dit omvat niet alleen open source bibliotheken, maar ook AI-modellen, databronnen en externe API’s. Controleer altijd de herkomst, licenties en bekende kwetsbaarheden.
- **Onderhoud veilige deployment pipelines:** Gebruik geautomatiseerde CI/CD-pijplijnen met geïntegreerde beveiligingsscans om problemen vroeg te detecteren. Zorg dat alleen vertrouwde artefacten naar productie worden uitgerold.
- **Continue monitoring en auditing:** Implementeer voortdurende monitoring van alle afhankelijkheden, inclusief modellen en dataservices, om nieuwe kwetsbaarheden of supply chain-aanvallen te detecteren.
- **Pas minste privilege en toegangscontrole toe:** Beperk toegang tot modellen, data en services tot wat strikt noodzakelijk is voor de werking van je MCP-server.
- **Reageer snel op bedreigingen:** Zorg voor een proces om gecompromitteerde componenten te patchen of te vervangen, en om geheimen of credentials te roteren als een inbreuk wordt vastgesteld.

[GitHub Advanced Security](https://github.com/security/advanced-security) biedt functies zoals secret scanning, dependency scanning en CodeQL-analyse. Deze tools integreren met [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) en [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) om teams te helpen kwetsbaarheden in code en AI-supply chain componenten te identificeren en te mitigeren.

Microsoft past intern ook uitgebreide beveiligingspraktijken toe voor de supply chain van alle producten. Meer hierover in [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Bestaande beveiligingsbest practices die de beveiligingshouding van je MCP-implementatie versterken

Elke MCP-implementatie erft de bestaande beveiligingshouding van de omgeving van je organisatie waarop het is gebouwd. Daarom wordt aanbevolen om bij het beoordelen van de beveiliging van MCP als onderdeel van je AI-systemen ook te kijken naar het versterken van je algehele beveiligingshouding. De volgende gevestigde beveiligingsmaatregelen zijn hierbij bijzonder relevant:

- Veilige codeerpraktijken in je AI-applicatie — bescherming tegen [de OWASP Top 10](https://owasp.org/www-project-top-ten/), de [OWASP Top 10 voor LLM’s](https://genai.owasp.org/download/43299/?tmstv=1731900559), gebruik van veilige kluizen voor geheimen en tokens, implementatie van end-to-end beveiligde communicatie tussen alle applicatiecomponenten, enzovoort.
- Serververharding — gebruik waar mogelijk MFA, houd patches up-to-date, integreer de server met een externe identity provider voor toegang, enzovoort.
- Houd
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 voor LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [De reis naar het beveiligen van de softwareleveringsketen bij Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Beveiligde least-privileged toegang (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best practices voor tokenvalidatie en levensduur](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Gebruik veilige tokenopslag en versleutel tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management als authenticatiegateway voor MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [MCP beveiligingsbest practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Microsoft Entra ID gebruiken om te authenticeren bij MCP-servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Volgende

Volgende: [Hoofdstuk 3: Aan de slag](/03-GettingStarted/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat automatische vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal geldt als de gezaghebbende bron. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.