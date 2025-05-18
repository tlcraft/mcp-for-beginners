<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-17T07:38:12+00:00",
  "source_file": "02-Security/readme.md",
  "language_code": "nl"
}
-->
# Beveiligingsrichtlijnen

Het toepassen van het Model Context Protocol (MCP) biedt krachtige nieuwe mogelijkheden voor AI-gedreven applicaties, maar introduceert ook unieke beveiligingsuitdagingen die verder gaan dan traditionele software risico's. Naast de gevestigde zorgen zoals veilig coderen, minimaal privilege en beveiliging van de toeleveringsketen, worden MCP en AI-werklasten geconfronteerd met nieuwe bedreigingen zoals promptinjectie, toolvergiftiging en dynamische toolwijziging. Deze risico's kunnen leiden tot gegevensdiefstal, privacyschendingen en onbedoeld systeemgedrag als ze niet goed worden beheerd.

Deze les onderzoekt de meest relevante beveiligingsrisico's in verband met MCP, waaronder authenticatie, autorisatie, overmatige permissies, indirecte promptinjectie en kwetsbaarheden in de toeleveringsketen, en biedt bruikbare controles en beste praktijken om ze te verminderen. Je leert ook hoe je Microsoft-oplossingen zoals Prompt Shields, Azure Content Safety en GitHub Advanced Security kunt gebruiken om je MCP-implementatie te versterken. Door deze controles te begrijpen en toe te passen, kun je de kans op een beveiligingsinbreuk aanzienlijk verkleinen en ervoor zorgen dat je AI-systemen robuust en betrouwbaar blijven.

# Leerdoelen

Aan het einde van deze les kun je:

- Unieke beveiligingsrisico's identificeren en uitleggen die worden geïntroduceerd door het Model Context Protocol (MCP), waaronder promptinjectie, toolvergiftiging, overmatige permissies en kwetsbaarheden in de toeleveringsketen.
- Effectieve mitigerende controles voor MCP-beveiligingsrisico's beschrijven en toepassen, zoals robuuste authenticatie, minimaal privilege, veilig tokenbeheer en verificatie van de toeleveringsketen.
- Microsoft-oplossingen begrijpen en benutten zoals Prompt Shields, Azure Content Safety en GitHub Advanced Security om MCP en AI-werklasten te beschermen.
- Het belang van het valideren van toolmetadata, het monitoren van dynamische wijzigingen en het verdedigen tegen indirecte promptinjectie-aanvallen herkennen.
- Gevestigde beveiligingsrichtlijnen integreren—zoals veilig coderen, serververharding en zero trust-architectuur— in je MCP-implementatie om de kans en impact van beveiligingsinbreuken te verminderen.

# MCP beveiligingscontroles

Elk systeem dat toegang heeft tot belangrijke middelen heeft impliciete beveiligingsuitdagingen. Beveiligingsuitdagingen kunnen over het algemeen worden aangepakt door de juiste toepassing van fundamentele beveiligingscontroles en concepten. Aangezien MCP pas onlangs is gedefinieerd, verandert de specificatie zeer snel en evolueert het protocol. Uiteindelijk zullen de beveiligingscontroles daarin volwassen worden, waardoor een betere integratie met ondernemingen en gevestigde beveiligingsarchitecturen en beste praktijken mogelijk wordt.

Onderzoek gepubliceerd in het [Microsoft Digital Defense Report](https://aka.ms/mddr) stelt dat 98% van de gerapporteerde inbreuken zou worden voorkomen door robuuste beveiligingshygiëne en de beste bescherming tegen elk soort inbreuk is om je basisbeveiligingshygiëne, beste praktijken voor veilig coderen en beveiliging van de toeleveringsketen op orde te krijgen—die beproefde praktijken die we al kennen, maken nog steeds de meeste impact bij het verminderen van beveiligingsrisico's.

Laten we eens kijken naar enkele manieren waarop je beveiligingsrisico's kunt aanpakken bij het adopteren van MCP.

# MCP serverauthenticatie (als je MCP-implementatie voor 26 april 2025 was)

> **Opmerking:** De volgende informatie is correct vanaf 26 april 2025. Het MCP-protocol evolueert voortdurend en toekomstige implementaties kunnen nieuwe authenticatiepatronen en -controles introduceren. Voor de laatste updates en richtlijnen, raadpleeg altijd de [MCP Specificatie](https://spec.modelcontextprotocol.io/) en de officiële [MCP GitHub repository](https://github.com/modelcontextprotocol).

### Probleemstelling 
De oorspronkelijke MCP-specificatie ging ervan uit dat ontwikkelaars hun eigen authenticatieserver zouden schrijven. Dit vereiste kennis van OAuth en gerelateerde beveiligingsbeperkingen. MCP-servers fungeerden als OAuth 2.0 Authorization Servers, waarbij de vereiste gebruikersauthenticatie direct werd beheerd in plaats van deze te delegeren aan een externe dienst zoals Microsoft Entra ID. Vanaf 26 april 2025 staat een update van de MCP-specificatie toe dat MCP-servers gebruikersauthenticatie delegeren aan een externe dienst.

### Risico's
- Onjuist geconfigureerde autorisatielogica in de MCP-server kan leiden tot blootstelling van gevoelige gegevens en onjuist toegepaste toegangscontroles.
- Diefstal van OAuth-token op de lokale MCP-server. Als het token wordt gestolen, kan het worden gebruikt om de MCP-server te imiteren en toegang te krijgen tot bronnen en gegevens van de dienst waarvoor het OAuth-token is.

### Mitigerende controles
- **Review en Verhard Autorisatielogica:** Controleer zorgvuldig de autorisatie-implementatie van je MCP-server om ervoor te zorgen dat alleen bedoelde gebruikers en clients toegang hebben tot gevoelige bronnen. Voor praktische richtlijnen, zie [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) en [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Handhaaf Veilige Tokenpraktijken:** Volg [Microsoft’s beste praktijken voor tokenvalidatie en levensduur](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) om misbruik van toegangstokens te voorkomen en het risico van tokenreplay of diefstal te verminderen.
- **Bescherm Tokenopslag:** Sla tokens altijd veilig op en gebruik versleuteling om ze te beschermen in rust en tijdens transport. Voor implementatietips, zie [Gebruik veilige tokenopslag en versleutel tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Overmatige permissies voor MCP-servers

### Probleemstelling
MCP-servers kunnen overmatige permissies hebben gekregen voor de dienst/bron waartoe ze toegang hebben. Bijvoorbeeld, een MCP-server die deel uitmaakt van een AI-verkoopapplicatie die verbinding maakt met een ondernemingsdatastore zou alleen toegang moeten hebben tot de verkoopgegevens en niet tot alle bestanden in de store. Terugverwijzend naar het principe van minimaal privilege (een van de oudste beveiligingsprincipes), zou geen enkele bron permissies moeten hebben die verder gaan dan wat nodig is om de taken uit te voeren waarvoor het bedoeld was. AI presenteert een verhoogde uitdaging op dit gebied omdat het moeilijk kan zijn om de exacte vereiste permissies te definiëren om het flexibel te maken.

### Risico's 
- Het verlenen van overmatige permissies kan leiden tot gegevensdiefstal of wijziging van gegevens waartoe de MCP-server niet bedoeld was toegang te hebben. Dit kan ook een privacyprobleem zijn als de gegevens persoonlijk identificeerbare informatie (PII) zijn.

### Mitigerende controles
- **Pas het Principe van Minimaal Privilege toe:** Geef de MCP-server alleen de minimale permissies die nodig zijn om zijn vereiste taken uit te voeren. Bekijk en update deze permissies regelmatig om ervoor te zorgen dat ze niet verder gaan dan wat nodig is. Voor gedetailleerde richtlijnen, zie [Veilig toegang met minimaal privilege](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Gebruik Role-Based Access Control (RBAC):** Wijs rollen toe aan de MCP-server die nauw zijn afgebakend tot specifieke bronnen en acties, waarbij brede of onnodige permissies worden vermeden.
- **Monitor en Audit Permissies:** Monitor continu het gebruik van permissies en audit toegangslogboeken om overmatige of ongebruikte privileges snel op te sporen en te verhelpen.

# Indirecte promptinjectie-aanvallen

### Probleemstelling

Kwaadaardige of gecompromitteerde MCP-servers kunnen aanzienlijke risico's introduceren door klantgegevens bloot te stellen of onbedoelde acties mogelijk te maken. Deze risico's zijn vooral relevant in AI- en MCP-gebaseerde werklasten, waar:

- **Promptinjectie-aanvallen**: Aanvallers embedden kwaadaardige instructies in prompts of externe inhoud, waardoor het AI-systeem onbedoelde acties uitvoert of gevoelige gegevens lekt. Meer informatie: [Promptinjectie](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Toolvergiftiging**: Aanvallers manipuleren toolmetadata (zoals beschrijvingen of parameters) om het gedrag van de AI te beïnvloeden, mogelijk beveiligingscontroles te omzeilen of gegevens te exfiltreren. Details: [Toolvergiftiging](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection**: Kwaadaardige instructies worden ingebed in documenten, webpagina's of e-mails, die vervolgens door de AI worden verwerkt, wat leidt tot gegevenslekken of manipulatie.
- **Dynamische Toolwijziging (Rug Pulls)**: Tooldefinities kunnen na goedkeuring door de gebruiker worden gewijzigd, waardoor nieuwe kwaadaardige gedragingen worden geïntroduceerd zonder dat de gebruiker zich hiervan bewust is.

Deze kwetsbaarheden benadrukken de noodzaak van robuuste validatie, monitoring en beveiligingscontroles bij het integreren van MCP-servers en tools in je omgeving. Voor een diepere duik, zie de gelinkte referenties hierboven.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.4b2f1af239a32d46221a75c7bc5b6f392ebbacc47eccde241d4c60507232fa43.nl.png)

**Indirecte Promptinjectie** (ook bekend als cross-domain promptinjectie of XPIA) is een kritieke kwetsbaarheid in generatieve AI-systemen, inclusief die met het Model Context Protocol (MCP). Bij deze aanval zijn kwaadaardige instructies verborgen in externe inhoud—zoals documenten, webpagina's of e-mails. Wanneer het AI-systeem deze inhoud verwerkt, kan het de ingesloten instructies interpreteren als legitieme gebruikersopdrachten, wat resulteert in onbedoelde acties zoals gegevenslekken, het genereren van schadelijke inhoud of manipulatie van gebruikersinteracties. Voor een gedetailleerde uitleg en voorbeelden uit de praktijk, zie [Promptinjectie](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Een bijzonder gevaarlijke vorm van deze aanval is **Toolvergiftiging**. Hier injecteren aanvallers kwaadaardige instructies in de metadata van MCP-tools (zoals toolbeschrijvingen of parameters). Omdat grote taalmodellen (LLM's) vertrouwen op deze metadata om te beslissen welke tools ze moeten aanroepen, kunnen gecompromitteerde beschrijvingen het model misleiden om ongeautoriseerde tooloproepen uit te voeren of beveiligingscontroles te omzeilen. Deze manipulaties zijn vaak onzichtbaar voor eindgebruikers, maar kunnen worden geïnterpreteerd en uitgevoerd door het AI-systeem. Dit risico wordt vergroot in gehoste MCP-serveromgevingen, waar tooldefinities kunnen worden bijgewerkt na goedkeuring door de gebruiker—een scenario dat soms wordt aangeduid als een "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". In dergelijke gevallen kan een tool die eerder veilig was later worden gewijzigd om kwaadaardige acties uit te voeren, zoals het exfiltreren van gegevens of het wijzigen van systeemgedrag, zonder medeweten van de gebruiker. Voor meer over dit aanvalsvector, zie [Toolvergiftiging](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.d4607023f69e16157954001ad81afd763676361f03db0a1cf24ec696b2ddcb88.nl.png)

## Risico's
Onbedoelde AI-acties vormen een verscheidenheid aan beveiligingsrisico's, waaronder gegevensdiefstal en privacyschendingen.

### Mitigerende controles
### Gebruik van prompt shields om te beschermen tegen indirecte promptinjectie-aanvallen
-----------------------------------------------------------------------------

**AI Prompt Shields** zijn een oplossing ontwikkeld door Microsoft om te verdedigen tegen zowel directe als indirecte promptinjectie-aanvallen. Ze helpen door:

1.  **Detectie en Filtering**: Prompt Shields gebruiken geavanceerde machine learning-algoritmen en natuurlijke taalverwerking om kwaadaardige instructies te detecteren en te filteren die zijn ingebed in externe inhoud, zoals documenten, webpagina's of e-mails.
    
2.  **Spotlighting**: Deze techniek helpt het AI-systeem onderscheid te maken tussen geldige systeemopdrachten en mogelijk onbetrouwbare externe invoer. Door de invoertekst op een manier te transformeren die relevanter is voor het model, zorgt Spotlighting ervoor dat de AI kwaadaardige instructies beter kan identificeren en negeren.
    
3.  **Delimiters en Datamarking**: Het opnemen van delimiters in het systeembericht schetst expliciet de locatie van de invoertekst, waardoor het AI-systeem gebruikersinvoer kan herkennen en scheiden van potentieel schadelijke externe inhoud. Datamarking breidt dit concept uit door speciale markeringen te gebruiken om de grenzen van vertrouwde en onbetrouwbare gegevens te markeren.
    
4.  **Continue Monitoring en Updates**: Microsoft monitort en werkt Prompt Shields continu bij om nieuwe en zich ontwikkelende bedreigingen aan te pakken. Deze proactieve aanpak zorgt ervoor dat de verdedigingen effectief blijven tegen de nieuwste aanvalstechnieken.
    
5. **Integratie met Azure Content Safety:** Prompt Shields maken deel uit van de bredere Azure AI Content Safety-suite, die aanvullende tools biedt voor het detecteren van jailbreak-pogingen, schadelijke inhoud en andere beveiligingsrisico's in AI-toepassingen.

Je kunt meer lezen over AI prompt shields in de [Prompt Shields documentatie](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.a4dba28a04ea42d28053f233585290d4862b244ca1e59b8ff695c5530e1bba66.nl.png)

### Beveiliging van de toeleveringsketen

Beveiliging van de toeleveringsketen blijft fundamenteel in het AI-tijdperk, maar de reikwijdte van wat je toeleveringsketen vormt is uitgebreid. Naast traditionele codepakketten moet je nu rigoureus alle AI-gerelateerde componenten verifiëren en monitoren, inclusief fundamentele modellen, embeddingdiensten, contextproviders en externe API's. Elk van deze kan kwetsbaarheden of risico's introduceren als ze niet goed worden beheerd.

**Belangrijke beveiligingspraktijken voor de toeleveringsketen voor AI en MCP:**
- **Verifieer alle componenten voor integratie:** Dit omvat niet alleen open-source bibliotheken, maar ook AI-modellen, gegevensbronnen en externe API's. Controleer altijd op herkomst, licenties en bekende kwetsbaarheden.
- **Onderhoud veilige implementatiepijplijnen:** Gebruik geautomatiseerde CI/CD-pijplijnen met geïntegreerde beveiligingsscanning om problemen vroegtijdig op te sporen. Zorg ervoor dat alleen vertrouwde artefacten in productie worden geïmplementeerd.
- **Continu monitoren en auditen:** Implementeer doorlopende monitoring voor alle afhankelijkheden, inclusief modellen en gegevensdiensten, om nieuwe kwetsbaarheden of aanvallen op de toeleveringsketen op te sporen.
- **Pas minimaal privilege en toegangscontroles toe:** Beperk de toegang tot modellen, gegevens en diensten tot alleen wat nodig is voor je MCP-server om te functioneren.
- **Reageer snel op bedreigingen:** Zorg voor een proces voor het patchen of vervangen van gecompromitteerde componenten en voor het roteren van geheimen of inloggegevens als een inbreuk wordt gedetecteerd.

[GitHub Advanced Security](https://github.com/security/advanced-security) biedt functies zoals geheime scanning, afhankelijkheidsscanning en CodeQL-analyse. Deze tools integreren met [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) en [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) om teams te helpen kwetsbaarheden te identificeren en te verminderen in zowel code als AI-componenten van de toeleveringsketen.

Microsoft implementeert ook uitgebreide beveiligingspraktijken voor de toeleveringsketen intern voor alle producten. Lees meer in [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Gevestigde beveiligingsrichtlijnen die de beveiligingspositie van je MCP-implementatie zullen verbeteren

Elke MCP-implementatie erft de bestaande beveiligingspositie van de omgeving van je organisatie waarop het is gebouwd, dus bij het overwegen van de beveiliging van MCP als een onderdeel van je algehele AI-systemen wordt aanbevolen om je algehele bestaande beveiligingspositie te verbeteren. De volgende gevestigde beveiligingscontroles zijn bijzonder relevant:

-   Beste praktijken voor veilig coderen in je AI-applicatie - beschermen tegen [de OWASP Top 10](https://owasp.org/www-project-top-ten/), de [OWASP Top 10 voor LLM's](https://genai.owasp.org/download/43299/?tmstv=1731900559), gebruik van veilige kluizen voor geheimen en tokens, het implementeren van end-to-end veilige communicatie tussen alle applicatiecomponenten, enz.
-   Serververharding -- gebruik MFA waar mogelijk, houd patching up-to-date, integreer de server met een externe identiteitsprovider voor toegang, enz.
-   Houd apparaten, infrastructuur en applicaties up-to-date met patches
-   Beveiligingsmonitoring -- implementeren van logging en monitoring van een AI-applicatie (inclusief de MCP-client/servers) en het verzenden van die logs naar een centraal SIEM voor detectie van abnormale activiteiten
-   Zero trust-architectuur -- het isoleren van componenten via netwerk- en identiteitscontroles op een logische manier om laterale beweging te minimaliseren als een AI-applicatie zou worden gecompromitteerd.

# Belangrijkste punten

- Beveiligingsfundamentals blijven cruciaal: Veilig coderen, minimaal privilege, verificatie van de toeleveringsketen en continue monitoring zijn essentieel voor MCP- en AI-werklasten.
- MCP introduceert nieuwe risico's—zoals promptinjectie, toolvergiftiging en overmatige permissies—die zowel traditionele als AI-specifieke controles vereisen.
- Gebruik robuuste authenticatie-, autorisatie- en
- [OWASP Top 10 voor LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [De Reis naar het Beveiligen van de Softwareleveringsketen bij Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Beveiligde Toegang met Minimaal Privilege (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Beste Praktijken voor Tokenvalidatie en Levensduur](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Gebruik Veilige Tokenopslag en Versleutel Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management als Auth Gateway voor MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Microsoft Entra ID gebruiken om te Authenticeren bij MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Volgende

Volgende: [Hoofdstuk 3: Aan de slag](/03-GettingStarted/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI vertaaldienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we ons inzetten voor nauwkeurigheid, willen we u erop wijzen dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in zijn oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor kritieke informatie wordt professionele menselijke vertaling aanbevolen. We zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.