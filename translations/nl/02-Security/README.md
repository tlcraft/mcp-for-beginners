<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c69f9df7f3215dac8d056020539bac36",
  "translation_date": "2025-07-04T17:57:00+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "nl"
}
-->
# Security Best Practices

Het adopteren van het Model Context Protocol (MCP) brengt krachtige nieuwe mogelijkheden voor AI-gedreven applicaties, maar introduceert ook unieke beveiligingsuitdagingen die verder gaan dan traditionele softwarerisico’s. Naast bekende aandachtspunten zoals veilig coderen, het principe van minste privilege en beveiliging van de supply chain, worden MCP en AI-workloads geconfronteerd met nieuwe bedreigingen zoals prompt injection, tool poisoning en dynamische toolwijzigingen. Deze risico’s kunnen leiden tot datalekken, privacyinbreuken en onbedoeld systeemgedrag als ze niet goed worden beheerd.

Deze les behandelt de meest relevante beveiligingsrisico’s rondom MCP—waaronder authenticatie, autorisatie, te ruime permissies, indirecte prompt injection en kwetsbaarheden in de supply chain—en biedt praktische maatregelen en best practices om deze te beperken. Je leert ook hoe je Microsoft-oplossingen zoals Prompt Shields, Azure Content Safety en GitHub Advanced Security kunt inzetten om je MCP-implementatie te versterken. Door deze maatregelen te begrijpen en toe te passen, verklein je de kans op een beveiligingsincident aanzienlijk en zorg je dat je AI-systemen robuust en betrouwbaar blijven.

# Leerdoelen

Aan het einde van deze les kun je:

- De unieke beveiligingsrisico’s van het Model Context Protocol (MCP) identificeren en uitleggen, zoals prompt injection, tool poisoning, te ruime permissies en kwetsbaarheden in de supply chain.
- Effectieve maatregelen toepassen om MCP-beveiligingsrisico’s te beperken, zoals robuuste authenticatie, het principe van minste privilege, veilig tokenbeheer en verificatie van de supply chain.
- Microsoft-oplossingen zoals Prompt Shields, Azure Content Safety en GitHub Advanced Security begrijpen en inzetten ter bescherming van MCP en AI-workloads.
- Het belang inzien van het valideren van tool-metadata, het monitoren van dynamische wijzigingen en het verdedigen tegen indirecte prompt injection-aanvallen.
- Bestaande beveiligingsbest practices integreren—zoals veilig coderen, serverhardening en zero trust-architectuur—om de kans en impact van beveiligingsincidenten binnen MCP te verkleinen.

# MCP beveiligingsmaatregelen

Elk systeem met toegang tot belangrijke resources kent impliciete beveiligingsuitdagingen. Deze uitdagingen kunnen doorgaans worden aangepakt door het correct toepassen van fundamentele beveiligingsmaatregelen en -concepten. Omdat MCP nog relatief nieuw is, verandert de specificatie snel en ontwikkelt het protocol zich continu. Uiteindelijk zullen de beveiligingsmaatregelen binnen MCP volwassen worden, wat een betere integratie mogelijk maakt met enterprise- en gevestigde beveiligingsarchitecturen en best practices.

Onderzoek gepubliceerd in het [Microsoft Digital Defense Report](https://aka.ms/mddr) stelt dat 98% van de gerapporteerde datalekken voorkomen had kunnen worden door robuuste beveiligingshygiëne. De beste bescherming tegen elk type datalek is het op orde hebben van je basisbeveiliging, veilige codeerpraktijken en supply chain-beveiliging — die beproefde methoden maken nog steeds het grootste verschil in het verminderen van beveiligingsrisico’s.

Laten we eens kijken naar enkele manieren waarop je beveiligingsrisico’s kunt aanpakken bij het adopteren van MCP.

> **Note:** De volgende informatie is correct per **29 mei 2025**. Het MCP-protocol blijft zich ontwikkelen en toekomstige implementaties kunnen nieuwe authenticatiepatronen en -maatregelen introduceren. Raadpleeg voor de laatste updates en richtlijnen altijd de [MCP Specification](https://spec.modelcontextprotocol.io/) en de officiële [MCP GitHub repository](https://github.com/modelcontextprotocol) en [security best practice page](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Probleemstelling  
De oorspronkelijke MCP-specificatie ging ervan uit dat ontwikkelaars hun eigen authenticatieserver zouden schrijven. Dit vereiste kennis van OAuth en gerelateerde beveiligingsbeperkingen. MCP-servers fungeerden als OAuth 2.0 Authorization Servers en beheerden de benodigde gebruikersauthenticatie direct, in plaats van deze te delegeren aan een externe dienst zoals Microsoft Entra ID. Vanaf **26 april 2025** staat een update van de MCP-specificatie toe dat MCP-servers gebruikersauthenticatie delegeren aan een externe dienst.

### Risico’s
- Foutief geconfigureerde autorisatielogica in de MCP-server kan leiden tot blootstelling van gevoelige data en verkeerd toegepaste toegangscontroles.
- Diefstal van OAuth-tokens op de lokale MCP-server. Als een token wordt gestolen, kan deze worden gebruikt om zich voor te doen als de MCP-server en toegang te krijgen tot resources en data waarvoor het OAuth-token bedoeld is.

#### Token Passthrough
Token passthrough is expliciet verboden in de autorisatiespecificatie omdat het verschillende beveiligingsrisico’s met zich meebrengt, waaronder:

#### Omzeilen van beveiligingsmaatregelen
De MCP-server of downstream API’s kunnen belangrijke beveiligingsmaatregelen implementeren zoals rate limiting, requestvalidatie of verkeersmonitoring, die afhankelijk zijn van het token-audience of andere credential-voorwaarden. Als clients tokens rechtstreeks bij downstream API’s kunnen gebruiken zonder dat de MCP-server deze correct valideert of controleert of de tokens voor de juiste service zijn uitgegeven, omzeilen ze deze maatregelen.

#### Problemen met verantwoordelijkheid en audittrail
De MCP-server kan MCP-clients niet identificeren of onderscheiden wanneer clients met een upstream-uitgegeven access token bellen dat mogelijk ondoorzichtig is voor de MCP-server.  
De logs van de downstream Resource Server kunnen verzoeken tonen die lijken te komen van een andere bron met een andere identiteit, in plaats van van de MCP-server die de tokens daadwerkelijk doorstuurt.  
Beide factoren bemoeilijken incidentonderzoek, controles en auditing.  
Als de MCP-server tokens doorgeeft zonder hun claims (zoals rollen, privileges of audience) of andere metadata te valideren, kan een kwaadwillende met een gestolen token de server als proxy gebruiken voor datalekken.

#### Vertrouwensgrensproblemen
De downstream Resource Server verleent vertrouwen aan specifieke entiteiten. Dit vertrouwen kan aannames bevatten over herkomst of gedragspatronen van clients. Het doorbreken van deze vertrouwensgrens kan leiden tot onverwachte problemen.  
Als het token door meerdere services wordt geaccepteerd zonder juiste validatie, kan een aanvaller die één service compromitteert het token gebruiken om toegang te krijgen tot andere verbonden services.

#### Risico op toekomstige compatibiliteit
Zelfs als een MCP-server vandaag als een “pure proxy” begint, kan het later nodig zijn om beveiligingsmaatregelen toe te voegen. Beginnen met een correcte scheiding van token-audience maakt het makkelijker om het beveiligingsmodel te laten evolueren.

### Maatregelen ter beperking

**MCP-servers MOGEN GEEN tokens accepteren die niet expliciet voor de MCP-server zijn uitgegeven**

- **Review en versterk autorisatielogica:** Controleer zorgvuldig de autorisatie-implementatie van je MCP-server om te waarborgen dat alleen bedoelde gebruikers en clients toegang hebben tot gevoelige resources. Voor praktische richtlijnen, zie [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) en [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Handhaaf veilige tokenpraktijken:** Volg [Microsoft’s best practices voor tokenvalidatie en levensduur](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) om misbruik van access tokens te voorkomen en het risico op token replay of diefstal te verkleinen.
- **Bescherm tokenopslag:** Sla tokens altijd veilig op en gebruik encryptie om ze te beveiligen, zowel in rust als tijdens transport. Voor implementatietips, zie [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Te ruime permissies voor MCP-servers

### Probleemstelling  
MCP-servers kunnen te ruime permissies hebben gekregen voor de service of resource die ze benaderen. Bijvoorbeeld, een MCP-server die deel uitmaakt van een AI-verkoopapplicatie die verbinding maakt met een enterprise data store, zou alleen toegang moeten hebben tot verkoopdata en niet tot alle bestanden in de opslag. Terugverwijzend naar het principe van minste privilege (een van de oudste beveiligingsprincipes), mag geen enkele resource permissies hebben die verder gaan dan nodig is om de beoogde taken uit te voeren. AI brengt hier een extra uitdaging omdat het flexibel moet zijn, waardoor het lastig kan zijn om precies te definiëren welke permissies vereist zijn.

### Risico’s  
- Het verlenen van te ruime permissies kan leiden tot datalekken of het aanpassen van data waar de MCP-server geen toegang toe zou moeten hebben. Dit kan ook een privacyprobleem zijn als het gaat om persoonsgegevens (PII).

### Maatregelen ter beperking  
- **Pas het principe van minste privilege toe:** Geef de MCP-server alleen de minimale permissies die nodig zijn om zijn taken uit te voeren. Beoordeel en actualiseer deze permissies regelmatig om te zorgen dat ze niet ruimer zijn dan noodzakelijk. Voor gedetailleerde richtlijnen, zie [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Gebruik Role-Based Access Control (RBAC):** Ken rollen toe aan de MCP-server die nauwkeurig zijn afgestemd op specifieke resources en acties, en vermijd brede of onnodige permissies.
- **Monitor en audit permissies:** Houd het gebruik van permissies continu in de gaten en controleer toegangslogs om te zorgen dat te ruime of ongebruikte rechten snel worden opgespoord en aangepakt.

# Indirecte prompt injection-aanvallen

### Probleemstelling

Kwaadwillende of gecompromitteerde MCP-servers kunnen aanzienlijke risico’s veroorzaken door klantgegevens bloot te stellen of onbedoelde acties mogelijk te maken. Deze risico’s zijn vooral relevant bij AI- en MCP-gebaseerde workloads, waar:

- **Prompt Injection-aanvallen**: Aanvallers verstoppen kwaadaardige instructies in prompts of externe content, waardoor het AI-systeem onbedoelde acties uitvoert of gevoelige data lekt. Meer info: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning**: Aanvallers manipuleren tool-metadata (zoals beschrijvingen of parameters) om het gedrag van de AI te beïnvloeden, mogelijk beveiligingsmaatregelen te omzeilen of data te exfiltreren. Details: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection**: Kwaadaardige instructies worden verborgen in documenten, webpagina’s of e-mails, die vervolgens door de AI worden verwerkt, wat leidt tot datalekken of manipulatie.
- **Dynamische toolwijziging (Rug Pulls)**: Tooldefinities kunnen na goedkeuring door de gebruiker worden aangepast, waardoor nieuwe kwaadaardige gedragingen worden geïntroduceerd zonder dat de gebruiker dit doorheeft.

Deze kwetsbaarheden benadrukken de noodzaak van robuuste validatie, monitoring en beveiligingsmaatregelen bij het integreren van MCP-servers en tools in je omgeving. Voor een diepere duik, zie de bovenstaande verwijzingen.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.nl.png)

**Indirecte Prompt Injection** (ook bekend als cross-domain prompt injection of XPIA) is een kritieke kwetsbaarheid in generatieve AI-systemen, inclusief die welke het Model Context Protocol (MCP) gebruiken. Bij deze aanval worden kwaadaardige instructies verborgen in externe content—zoals documenten, webpagina’s of e-mails. Wanneer het AI-systeem deze content verwerkt, interpreteert het mogelijk de verborgen instructies als legitieme gebruikersopdrachten, wat leidt tot onbedoelde acties zoals datalekken, het genereren van schadelijke content of manipulatie van gebruikersinteracties. Voor een gedetailleerde uitleg en praktijkvoorbeelden, zie [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Een bijzonder gevaarlijke vorm van deze aanval is **Tool Poisoning**. Hierbij injecteren aanvallers kwaadaardige instructies in de metadata van MCP-tools (zoals toolbeschrijvingen of parameters). Omdat grote taalmodellen (LLM’s) op deze metadata vertrouwen om te bepalen welke tools ze aanroepen, kunnen gecompromitteerde beschrijvingen het model misleiden om ongeautoriseerde toolaanroepen uit te voeren of beveiligingsmaatregelen te omzeilen. Deze manipulaties zijn vaak onzichtbaar voor eindgebruikers, maar kunnen door het AI-systeem worden geïnterpreteerd en uitgevoerd. Dit risico is groter in gehoste MCP-serveromgevingen, waar tooldefinities na gebruikersgoedkeuring kunnen worden aangepast—een scenario dat soms een "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)" wordt genoemd. In zulke gevallen kan een tool die eerder veilig was, later worden gewijzigd om kwaadaardige acties uit te voeren, zoals datalekken of het wijzigen van systeemgedrag, zonder dat de gebruiker hiervan op de hoogte is. Voor meer informatie over deze aanvalsvector, zie [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.nl.png)

## Risico’s  
Onbedoelde AI-acties brengen diverse beveiligingsrisico’s met zich mee, waaronder datalekken en privacyinbreuken.

### Maatregelen ter beperking  
### Gebruik van prompt shields ter bescherming tegen indirecte prompt injection-aanvallen
-----------------------------------------------------------------------------

**AI Prompt Shields** zijn een door Microsoft ontwikkelde oplossing om zowel directe als indirecte prompt injection-aanvallen tegen te gaan. Ze helpen door:

1.  **Detectie en filtering:** Prompt Shields gebruiken geavanceerde machine learning-algoritmes en natuurlijke taalverwerking om kwaadaardige instructies in externe content, zoals documenten, webpagina’s of e-mails, te detecteren en te filteren.
    
2.  **Spotlighting:** Deze techniek helpt het AI-systeem onderscheid te maken tussen geldige systeeminstructies en mogelijk onbetrouwbare externe input. Door de invoertekst zodanig te transformeren dat deze relevanter wordt voor het model, zorgt Spotlighting ervoor dat het AI-systeem kwaadaardige instructies beter kan herkennen en negeren.
    
3.  **Delimiters en datamarking:** Het opnemen van delimiters in het systeembericht geeft expliciet aan waar de invoertekst zich bevindt, waardoor het AI-systeem gebruikersinput kan onderscheiden van mogelijk schadelijke externe content. Datamarking breidt dit concept uit door speciale markers te gebruiken om de grenzen van vertrouwde en onbetrouwbare data aan te geven.
    
4.  **Continue monitoring en updates:** Microsoft monitort en actualiseert Prompt Shields continu om nieuwe en evoluerende bedreigingen het hoofd te bieden. Deze proactieve aanpak zorgt ervoor dat de bescherming effectief blijft tegen de nieuwste aanvalstechnieken.
    
5. **Integratie met Azure Content Safety:** Prompt Shields maken deel uit van de bredere Azure AI Content Safety-suite, die extra tools biedt voor het detecteren van jailbreakpogingen, schadelijke content en andere beveiligingsrisico’s in AI-toepassingen.

Meer informatie over AI prompt shields vind je in de [Prompt Shields documentatie](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.nl.png)

### Supply chain security
Supply chain-beveiliging blijft fundamenteel in het AI-tijdperk, maar de reikwijdte van wat jouw supply chain omvat is uitgebreid. Naast traditionele codepakketten moet je nu ook alle AI-gerelateerde componenten grondig verifiëren en monitoren, waaronder foundation models, embeddings-services, contextproviders en API's van derden. Elk van deze kan kwetsbaarheden of risico's introduceren als ze niet goed worden beheerd.

**Belangrijke supply chain-beveiligingspraktijken voor AI en MCP:**
- **Verifieer alle componenten vóór integratie:** Dit omvat niet alleen open-source bibliotheken, maar ook AI-modellen, databronnen en externe API's. Controleer altijd op herkomst, licenties en bekende kwetsbaarheden.
- **Onderhoud veilige deployment pipelines:** Gebruik geautomatiseerde CI/CD-pijplijnen met geïntegreerde beveiligingsscans om problemen vroegtijdig te detecteren. Zorg ervoor dat alleen vertrouwde artefacten in productie worden uitgerold.
- **Voer continue monitoring en audits uit:** Implementeer voortdurende monitoring voor alle afhankelijkheden, inclusief modellen en dataservices, om nieuwe kwetsbaarheden of supply chain-aanvallen te detecteren.
- **Pas het principe van minste privilege en toegangscontroles toe:** Beperk de toegang tot modellen, data en services tot alleen wat noodzakelijk is voor de werking van je MCP-server.
- **Reageer snel op bedreigingen:** Zorg voor een proces om gecompromitteerde componenten te patchen of te vervangen, en om geheimen of inloggegevens te roteren als een inbreuk wordt vastgesteld.

[GitHub Advanced Security](https://github.com/security/advanced-security) biedt functies zoals secret scanning, dependency scanning en CodeQL-analyse. Deze tools integreren met [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) en [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) om teams te helpen kwetsbaarheden te identificeren en te mitigeren, zowel in code als in AI-supply chain componenten.

Microsoft past ook intern uitgebreide supply chain-beveiligingspraktijken toe voor alle producten. Lees meer in [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Bewezen beveiligingspraktijken die de beveiligingshouding van je MCP-implementatie versterken

Elke MCP-implementatie erft de bestaande beveiligingshouding van de omgeving van je organisatie waarop deze is gebouwd. Daarom wordt aanbevolen om bij het beveiligen van MCP als onderdeel van je AI-systemen ook te kijken naar het versterken van je algemene beveiligingshouding. De volgende bewezen beveiligingsmaatregelen zijn hierbij vooral relevant:

- Veilige codeerpraktijken in je AI-toepassing – bescherm tegen [de OWASP Top 10](https://owasp.org/www-project-top-ten/), de [OWASP Top 10 voor LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), gebruik van veilige kluizen voor geheimen en tokens, implementatie van end-to-end beveiligde communicatie tussen alle applicatiecomponenten, enzovoort.
- Server hardening – gebruik waar mogelijk MFA, houd patching up-to-date, integreer de server met een externe identiteitsprovider voor toegang, enzovoort.
- Houd apparaten, infrastructuur en applicaties up-to-date met patches.
- Beveiligingsmonitoring – implementeer logging en monitoring van een AI-toepassing (inclusief de MCP client/servers) en stuur die logs naar een centrale SIEM voor detectie van afwijkend gedrag.
- Zero trust-architectuur – isoleer componenten via netwerk- en identiteitscontroles op een logische manier om laterale beweging te minimaliseren als een AI-toepassing gecompromitteerd raakt.

# Belangrijkste punten

- Beveiligingsfundamenten blijven cruciaal: veilig coderen, minste privilege, supply chain-verificatie en continue monitoring zijn essentieel voor MCP en AI-workloads.
- MCP brengt nieuwe risico’s met zich mee—zoals prompt injection, tool poisoning en te ruime permissies—die zowel traditionele als AI-specifieke controles vereisen.
- Gebruik robuuste authenticatie-, autorisatie- en tokenbeheerpraktijken, waarbij je waar mogelijk externe identiteitsproviders zoals Microsoft Entra ID inzet.
- Bescherm tegen indirecte prompt injection en tool poisoning door toolmetadata te valideren, te monitoren op dynamische wijzigingen en oplossingen zoals Microsoft Prompt Shields te gebruiken.
- Behandel alle componenten in je AI-supply chain—waaronder modellen, embeddings en contextproviders—met dezelfde zorgvuldigheid als code-afhankelijkheden.
- Blijf op de hoogte van de evoluerende MCP-specificaties en draag bij aan de community om veilige standaarden vorm te geven.

# Aanvullende bronnen

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

### Volgende

Volgende: [Hoofdstuk 3: Aan de slag](../03-GettingStarted/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.