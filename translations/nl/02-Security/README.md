<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-20T23:15:43+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "nl"
}
-->
# Security Best Practices

Het adopteren van het Model Context Protocol (MCP) brengt krachtige nieuwe mogelijkheden voor AI-gedreven toepassingen, maar introduceert ook unieke beveiligingsuitdagingen die verder gaan dan traditionele softwarerisico’s. Naast bekende aandachtspunten zoals veilig coderen, het principe van minste privileges en beveiliging van de supply chain, worden MCP en AI workloads geconfronteerd met nieuwe bedreigingen zoals prompt injectie, tool poisoning en dynamische aanpassing van tools. Deze risico’s kunnen leiden tot datalekken, privacyinbreuken en ongewenst systeemgedrag als ze niet goed worden beheerd.

In deze les behandelen we de meest relevante beveiligingsrisico’s rondom MCP—waaronder authenticatie, autorisatie, te ruime rechten, indirecte prompt injectie en kwetsbaarheden in de supply chain—en bieden we praktische maatregelen en best practices om deze te beperken. Je leert ook hoe je Microsoft-oplossingen zoals Prompt Shields, Azure Content Safety en GitHub Advanced Security kunt inzetten om je MCP-implementatie te versterken. Door deze maatregelen te begrijpen en toe te passen, kun je de kans op een beveiligingsincident aanzienlijk verkleinen en zorgen dat je AI-systemen betrouwbaar en robuust blijven.

# Leerdoelen

Aan het einde van deze les kun je:

- De unieke beveiligingsrisico’s van het Model Context Protocol (MCP) identificeren en uitleggen, zoals prompt injectie, tool poisoning, te ruime rechten en kwetsbaarheden in de supply chain.
- Effectieve maatregelen voor MCP-beveiligingsrisico’s beschrijven en toepassen, zoals robuuste authenticatie, het principe van minste privileges, veilig tokenbeheer en verificatie van de supply chain.
- Microsoft-oplossingen zoals Prompt Shields, Azure Content Safety en GitHub Advanced Security begrijpen en gebruiken om MCP en AI workloads te beschermen.
- Het belang inzien van het valideren van tool-metadata, het monitoren van dynamische wijzigingen en het verdedigen tegen indirecte prompt injectie-aanvallen.
- Bestaande beveiligingsbest practices integreren—zoals veilig coderen, serverhardening en zero trust architectuur—om de beveiliging van je MCP-implementatie te verbeteren en de impact van incidenten te verminderen.

# MCP beveiligingsmaatregelen

Elk systeem met toegang tot belangrijke bronnen kent inherente beveiligingsuitdagingen. Deze kunnen doorgaans worden aangepakt door het correct toepassen van fundamentele beveiligingsmaatregelen en concepten. Omdat MCP nog relatief nieuw is, verandert de specificatie snel en ontwikkelt het protocol zich nog. Naarmate het volwassen wordt, zullen de beveiligingsmaatregelen beter integreren met enterprise- en gevestigde beveiligingsarchitecturen en best practices.

Onderzoek uit het [Microsoft Digital Defense Report](https://aka.ms/mddr) toont aan dat 98% van de gemelde beveiligingsincidenten voorkomen had kunnen worden met goede beveiligingshygiëne. De beste bescherming tegen elk type inbreuk is het op orde hebben van je basisbeveiliging, veilig coderen en supply chain beveiliging—deze bewezen methoden blijven het meeste effect hebben in het verkleinen van risico’s.

Laten we eens kijken naar enkele manieren om beveiligingsrisico’s aan te pakken bij het implementeren van MCP.

# MCP server authenticatie (als je MCP-implementatie vóór 26 april 2025 was)

> **Note:** De volgende informatie is correct per 26 april 2025. Het MCP-protocol ontwikkelt zich continu en toekomstige implementaties kunnen nieuwe authenticatiepatronen en controles introduceren. Raadpleeg altijd de [MCP Specification](https://spec.modelcontextprotocol.io/) en de officiële [MCP GitHub repository](https://github.com/modelcontextprotocol) voor de laatste updates en richtlijnen.

### Probleemstelling  
De oorspronkelijke MCP-specificatie ging ervan uit dat ontwikkelaars hun eigen authenticatieserver zouden bouwen. Dit vereiste kennis van OAuth en gerelateerde beveiligingsaspecten. MCP-servers fungeerden als OAuth 2.0 Authorization Servers en beheerden gebruikersauthenticatie rechtstreeks, in plaats van deze uit te besteden aan een externe service zoals Microsoft Entra ID. Vanaf 26 april 2025 maakt een update van de MCP-specificatie het mogelijk dat MCP-servers gebruikersauthenticatie delegeren aan een externe service.

### Risico’s
- Verkeerd geconfigureerde autorisatielogica in de MCP-server kan leiden tot blootstelling van gevoelige data en onjuiste toegangscontrole.
- Diefstal van OAuth-tokens op de lokale MCP-server. Als een token wordt gestolen, kan dit worden gebruikt om zich voor te doen als de MCP-server en toegang te krijgen tot resources en data waarvoor het token bedoeld is.

### Maatregelen ter beperking
- **Review en versterk autorisatielogica:** Controleer de autorisatie-implementatie van je MCP-server zorgvuldig om te waarborgen dat alleen de juiste gebruikers en clients toegang krijgen tot gevoelige resources. Praktische richtlijnen vind je in [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) en [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Handhaaf veilige tokenpraktijken:** Volg [Microsoft’s best practices voor tokenvalidatie en levensduur](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) om misbruik van toegangstokens te voorkomen en het risico op token replay of diefstal te verminderen.
- **Bescherm tokenopslag:** Sla tokens altijd veilig op en gebruik encryptie om ze te beveiligen, zowel in rust als tijdens transport. Voor implementatietips, zie [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Te ruime rechten voor MCP-servers

### Probleemstelling  
MCP-servers kunnen te veel rechten hebben gekregen voor de service of resource die ze benaderen. Bijvoorbeeld, een MCP-server die onderdeel is van een AI-verkoopapplicatie en verbinding maakt met een bedrijfsdatastore, zou alleen toegang moeten hebben tot verkoopdata en niet tot alle bestanden in de opslag. Teruggrijpend op het principe van minste privileges (een van de oudste beveiligingsprincipes) mag geen enkele resource meer rechten hebben dan strikt noodzakelijk om de beoogde taken uit te voeren. AI maakt dit lastiger, omdat flexibiliteit soms het definiëren van exacte benodigde rechten bemoeilijkt.

### Risico’s  
- Te ruime rechten kunnen leiden tot datalekken of het wijzigen van data waar de MCP-server geen toegang toe zou mogen hebben. Dit kan ook privacyproblemen veroorzaken als het om persoonsgegevens (PII) gaat.

### Maatregelen ter beperking
- **Pas het principe van minste privileges toe:** Geef de MCP-server alleen de minimale rechten die nodig zijn om zijn taken uit te voeren. Herzie en actualiseer deze rechten regelmatig om te voorkomen dat ze te ruim worden. Voor uitgebreide richtlijnen, zie [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Gebruik Role-Based Access Control (RBAC):** Ken rollen toe aan de MCP-server die nauwkeurig zijn afgestemd op specifieke resources en acties, vermijd brede of onnodige rechten.
- **Monitor en audit rechten:** Houd het gebruik van rechten continu in de gaten en controleer toegangslogs om te zorgen dat overtollige of ongebruikte privileges snel worden opgespoord en verwijderd.

# Indirecte prompt injectie-aanvallen

### Probleemstelling

Kwaadaardige of gecompromitteerde MCP-servers kunnen aanzienlijke risico’s veroorzaken door klantdata bloot te stellen of onbedoelde acties mogelijk te maken. Deze risico’s zijn vooral relevant in AI- en MCP-werkbelastingen, waar:

- **Prompt Injectie-aanvallen**: Aanvallers verstoppen kwaadaardige instructies in prompts of externe content, waardoor het AI-systeem onbedoelde acties uitvoert of gevoelige data lekt. Meer info: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning**: Aanvallers manipuleren tool-metadata (zoals beschrijvingen of parameters) om het gedrag van de AI te beïnvloeden, waardoor beveiligingsmaatregelen worden omzeild of data kan worden buitgemaakt. Details: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection**: Kwaadaardige instructies worden verstopt in documenten, webpagina’s of e-mails, die door de AI worden verwerkt, wat leidt tot datalekken of manipulatie.
- **Dynamische Tool Aanpassing (Rug Pulls)**: Tooldefinities kunnen na goedkeuring door de gebruiker worden gewijzigd, waardoor nieuwe kwaadaardige gedragingen worden geïntroduceerd zonder dat de gebruiker dit merkt.

Deze kwetsbaarheden benadrukken de noodzaak van robuuste validatie, monitoring en beveiligingsmaatregelen bij het integreren van MCP-servers en tools in je omgeving. Voor een diepere uitleg, zie de gelinkte bronnen hierboven.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.nl.png)

**Indirecte Prompt Injectie** (ook bekend als cross-domain prompt injectie of XPIA) is een ernstige kwetsbaarheid in generatieve AI-systemen, inclusief systemen die MCP gebruiken. Bij deze aanval worden kwaadaardige instructies verborgen in externe content—zoals documenten, webpagina’s of e-mails. Wanneer het AI-systeem deze content verwerkt, interpreteert het de verborgen instructies als legitieme gebruikerscommando’s, wat leidt tot onbedoelde acties zoals datalekken, het genereren van schadelijke content of het manipuleren van gebruikersinteracties. Voor een uitgebreide uitleg en voorbeelden uit de praktijk, zie [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Een bijzonder gevaarlijke vorm van deze aanval is **Tool Poisoning**. Hierbij injecteren aanvallers kwaadaardige instructies in de metadata van MCP-tools (zoals toolbeschrijvingen of parameters). Omdat grote taalmodellen (LLM’s) deze metadata gebruiken om te bepalen welke tools ze aanroepen, kunnen gemanipuleerde beschrijvingen het model misleiden om ongeautoriseerde tool-aanroepen te doen of beveiligingsmaatregelen te omzeilen. Deze manipulaties zijn vaak onzichtbaar voor eindgebruikers, maar worden door het AI-systeem geïnterpreteerd en uitgevoerd. Dit risico is extra groot in gehoste MCP-serveromgevingen, waar tooldefinities na goedkeuring door gebruikers kunnen worden aangepast—dit wordt soms een "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)" genoemd. Een tool die eerst veilig was, kan later worden veranderd om kwaadaardige acties uit te voeren, zoals het stelen van data of het wijzigen van systeemgedrag, zonder dat de gebruiker hiervan op de hoogte is. Meer over deze aanval: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.nl.png)

## Risico’s
Onbedoelde AI-acties brengen diverse beveiligingsrisico’s met zich mee, waaronder datalekken en privacyinbreuken.

### Maatregelen ter beperking  
### Gebruik van prompt shields ter bescherming tegen indirecte prompt injectie-aanvallen
-----------------------------------------------------------------------------

**AI Prompt Shields** zijn een door Microsoft ontwikkelde oplossing om zowel directe als indirecte prompt injectie-aanvallen tegen te gaan. Ze helpen door:

1.  **Detectie en Filtering:** Prompt Shields gebruiken geavanceerde machine learning en natuurlijke taalverwerking om kwaadaardige instructies in externe content, zoals documenten, webpagina’s of e-mails, te detecteren en te filteren.
    
2.  **Spotlighting:** Deze techniek helpt het AI-systeem onderscheid te maken tussen geldige systeeminstructies en mogelijk onbetrouwbare externe input. Door de inputtekst zo te transformeren dat deze relevanter wordt voor het model, zorgt Spotlighting ervoor dat het AI-systeem kwaadaardige instructies beter kan herkennen en negeren.
    
3.  **Afgrenzers en Datamarking:** Het opnemen van afgrenzers in het systeembericht maakt expliciet waar de inputtekst zich bevindt, waardoor het AI-systeem gebruikersinvoer kan onderscheiden van mogelijk schadelijke externe content. Datamarking breidt dit uit door speciale markeringen te gebruiken om de grenzen van vertrouwde en onbetrouwbare data aan te geven.
    
4.  **Continue Monitoring en Updates:** Microsoft houdt Prompt Shields continu in de gaten en werkt ze bij om nieuwe en veranderende bedreigingen te bestrijden. Deze proactieve aanpak zorgt dat de bescherming effectief blijft tegen de nieuwste aanvalstechnieken.
    
5. **Integratie met Azure Content Safety:** Prompt Shields maken deel uit van de bredere Azure AI Content Safety-suite, die extra tools biedt voor het detecteren van jailbreak-pogingen, schadelijke content en andere beveiligingsrisico’s in AI-toepassingen.

Meer informatie over AI prompt shields vind je in de [Prompt Shields documentatie](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.nl.png)

### Supply chain beveiliging

Supply chain beveiliging blijft fundamenteel in het AI-tijdperk, maar de reikwijdte van wat tot je supply chain behoort is uitgebreid. Naast traditionele codepakketten moet je nu ook alle AI-gerelateerde componenten grondig verifiëren en monitoren, zoals foundation models, embedding services, context providers en externe API’s. Elk van deze kan kwetsbaarheden of risico’s introduceren als ze niet goed worden beheerd.

**Belangrijke supply chain beveiligingspraktijken voor AI en MCP:**
- **Verifieer alle componenten vóór integratie:** Dit geldt niet alleen voor open source libraries, maar ook voor AI-modellen, databronnen en externe API’s. Controleer altijd herkomst, licenties en bekende kwetsbaarheden.
- **Onderhoud veilige deployment pipelines:** Gebruik geautomatiseerde CI/CD-pijplijnen met geïntegreerde beveiligingsscans om problemen vroeg te detecteren. Zorg dat alleen vertrouwde artefacten in productie worden uitgerold.
- **Continue monitoring en auditing:** Implementeer voortdurende monitoring van alle afhankelijkheden, inclusief modellen en dataservices, om nieuwe kwetsbaarheden of supply chain aanvallen op te sporen.
- **Pas minste privileges en toegangscontrole toe:** Beperk de toegang tot modellen, data en services tot alleen wat strikt nodig is voor de MCP-server.
- **Reageer snel op bedreigingen:** Zorg voor een proces om gecompromitteerde componenten te patchen of te vervangen, en om geheimen of credentials te roteren als er een inbreuk wordt ontdekt.

[GitHub Advanced Security](https://github.com/security/advanced-security) biedt functies zoals secret scanning, dependency scanning en CodeQL-analyse. Deze tools integreren met [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) en [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) om teams te helpen kwetsbaarheden in zowel code als AI supply chain componenten te identificeren en te mitigeren.

Microsoft implementeert intern uitgebreide supply chain beveiligingspraktijken voor alle producten. Meer informatie in [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Gevestigde beveiligingsbest practices die de beveiligingshouding van je MCP-implementatie versterken

Elke MCP-implementatie erft de bestaande beveiligingshouding van de omgeving waarin deze is gebouwd. Daarom is het aanbevolen om, bij het beoordelen van de beveiliging van MCP als onderdeel van je AI-systemen, ook je algemene beveiligingshouding te verbeteren. De volgende gevestigde beveiligingsmaatregelen zijn hierbij bijzonder relevant:

- Veilige codeerpraktijken in je AI-toepassing—bescherming tegen [de OWASP Top 10](https://owasp.org/www-project-top-ten/), de [OWASP Top 10 voor LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), gebruik van veilige kluizen voor geheimen en tokens, implementatie van end-to-end beveiligde communicatie tussen alle applicatiecomponenten, enzovoort.
- Serverhardening—gebruik waar mogelijk MFA, houd patching up-to-date, integreer de server met een externe identiteitsprovider voor toegang, enzovoort.
- Houd apparaten, infrastructuur en applicaties up-to-date met patches.
- Beveiligingsmonitoring—implementeer logging en monitoring van een AI-applicatie (inclusief MCP client/servers) en stuur deze logs naar een centrale SIEM voor detectie van afwijkend gedrag.
- Zero trust architectuur—isoleer componenten via netwerk- en identiteitscontroles op een logische manier om laterale bewegingen te minimaliseren als een AI-applicatie gecompromitteerd raakt.

# Belangrijkste conclusies

- Basisprincipes van beveiliging blijven cruciaal: veilig coderen, minste privileges, verificatie van de supply chain en continue monitoring zijn essentieel voor MCP en AI workloads.
- MCP brengt nieuwe risico’s met zich mee—zoals prompt injectie, tool poisoning en te ruime rechten—die zowel traditionele als AI-specifieke maatregelen vereisen.
- Gebruik robuuste authenticatie-, autorisatie- en tokenbeheerpraktijken, waarbij je waar mogelijk externe identiteitsproviders zoals Microsoft Entra ID inzet.
- Bescherm tegen indirecte prompt injectie en tool poisoning door tool-metadata te valideren, dynamische wijzigingen te monitoren en oplossingen zoals Microsoft Prompt Shields te gebruiken.
- Behandel alle componenten in je AI supply chain—waaronder modellen, embeddings en contextproviders—met dezelfde zorgvuldigheid als code-afhankelijkheden.
- Blijf op de hoogte van de evoluerende MCP-specificaties en draag bij aan de community om veilige standaarden vorm te geven.

# Aanvullende bronnen

- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [Prompt Injection in MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Tool Poisoning Attacks (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls in MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Prompt Shields Documentation (Microsoft)](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 voor LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [De reis naar het beveiligen van de softwareleveringsketen bij Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Beveiligde toegang met minimale rechten (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best practices voor tokenvalidatie en levensduur](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Gebruik veilige tokenopslag en versleutel tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management als Auth Gateway voor MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Microsoft Entra ID gebruiken om te authenticeren bij MCP-servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Volgende

Volgende: [Hoofdstuk 3: Aan de slag](/03-GettingStarted/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsservice [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal dient als de gezaghebbende bron te worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.