<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "382fddb4ee4d9c1bdc806e2ee99b70c8",
  "translation_date": "2025-07-17T06:45:49+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "no"
}
-->
# Sikkerhets beste praksis

Å ta i bruk Model Context Protocol (MCP) gir kraftige nye muligheter for AI-drevne applikasjoner, men introduserer også unike sikkerhetsutfordringer som går utover tradisjonelle programvarerisikoer. I tillegg til etablerte bekymringer som sikker koding, minste privilegium og sikkerhet i leverandørkjeden, står MCP og AI-arbeidsbelastninger overfor nye trusler som prompt-injeksjon, verktøyforgiftning, dynamisk verktøymodifisering, sesjonskapring, confused deputy-angrep og token passthrough-sårbarheter. Disse risikoene kan føre til datalekkasjer, brudd på personvern og utilsiktet systematferd hvis de ikke håndteres riktig.

Denne leksjonen utforsker de mest relevante sikkerhetsrisikoene knyttet til MCP—inkludert autentisering, autorisasjon, overdrevne tillatelser, indirekte prompt-injeksjon, sesjonssikkerhet, confused deputy-problemer, token passthrough-sårbarheter og sårbarheter i leverandørkjeden—og gir konkrete tiltak og beste praksis for å redusere dem. Du vil også lære hvordan du kan bruke Microsoft-løsninger som Prompt Shields, Azure Content Safety og GitHub Advanced Security for å styrke din MCP-implementering. Ved å forstå og anvende disse kontrollene kan du betydelig redusere sannsynligheten for sikkerhetsbrudd og sikre at AI-systemene dine forblir robuste og pålitelige.

# Læringsmål

Ved slutten av denne leksjonen skal du kunne:

- Identifisere og forklare de unike sikkerhetsrisikoene som Model Context Protocol (MCP) introduserer, inkludert prompt-injeksjon, verktøyforgiftning, overdrevne tillatelser, sesjonskapring, confused deputy-problemer, token passthrough-sårbarheter og sårbarheter i leverandørkjeden.
- Beskrive og anvende effektive tiltak for å redusere MCP-sikkerhetsrisikoer, som robust autentisering, minste privilegium, sikker tokenhåndtering, sesjonssikkerhetskontroller og verifisering av leverandørkjeden.
- Forstå og utnytte Microsoft-løsninger som Prompt Shields, Azure Content Safety og GitHub Advanced Security for å beskytte MCP og AI-arbeidsbelastninger.
- Gjenkjenne viktigheten av å validere verktøymetadata, overvåke dynamiske endringer, forsvare mot indirekte prompt-injeksjonsangrep og forhindre sesjonskapring.
- Integrere etablerte sikkerhets beste praksiser—som sikker koding, serverherding og zero trust-arkitektur—i din MCP-implementering for å redusere sannsynligheten og konsekvensene av sikkerhetsbrudd.

# MCP sikkerhetskontroller

Enhver løsning som har tilgang til viktige ressurser har iboende sikkerhetsutfordringer. Sikkerhetsutfordringer kan vanligvis håndteres gjennom korrekt anvendelse av grunnleggende sikkerhetskontroller og konsepter. Siden MCP er nylig definert, endres spesifikasjonen raskt i takt med at protokollen utvikler seg. Etter hvert vil sikkerhetskontrollene i den modnes, noe som muliggjør bedre integrasjon med bedrifts- og etablerte sikkerhetsarkitekturer og beste praksis.

Forskning publisert i [Microsoft Digital Defense Report](https://aka.ms/mddr) viser at 98 % av rapporterte brudd kunne vært forhindret med robust sikkerhetshygiene, og den beste beskyttelsen mot alle typer brudd er å ha grunnleggende sikkerhetshygiene, sikre kodingspraksiser og leverandørkjede-sikkerhet på plass — de velprøvde metodene vi allerede kjenner til har fortsatt størst effekt på å redusere sikkerhetsrisiko.

La oss se på noen måter du kan begynne å håndtere sikkerhetsrisikoer ved å ta i bruk MCP.

> **Note:** Følgende informasjon er korrekt per **29. mai 2025**. MCP-protokollen utvikler seg kontinuerlig, og fremtidige implementeringer kan introdusere nye autentiseringsmønstre og kontroller. For siste oppdateringer og veiledning, se alltid [MCP Specification](https://spec.modelcontextprotocol.io/) og den offisielle [MCP GitHub-repositoriet](https://github.com/modelcontextprotocol) og [sikkerhets beste praksis-siden](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Problemstilling  
Den opprinnelige MCP-spesifikasjonen antok at utviklere skulle skrive sin egen autentiseringsserver. Dette krevde kunnskap om OAuth og relaterte sikkerhetsbegrensninger. MCP-servere fungerte som OAuth 2.0 Autorisasjonsservere, og håndterte nødvendig brukerautentisering direkte i stedet for å delegere dette til en ekstern tjeneste som Microsoft Entra ID. Fra og med **26. april 2025** tillater en oppdatering i MCP-spesifikasjonen at MCP-servere kan delegere brukerautentisering til en ekstern tjeneste.

### Risikoer
- Feilkonfigurert autorisasjonslogikk i MCP-serveren kan føre til eksponering av sensitiv data og feilaktig anvendte tilgangskontroller.
- Tyveri av OAuth-token på lokal MCP-server. Hvis tokenet blir stjålet, kan det brukes til å utgi seg for MCP-serveren og få tilgang til ressurser og data fra tjenesten tokenet gjelder for.

#### Token Passthrough
Token passthrough er eksplisitt forbudt i autorisasjonsspesifikasjonen da det introduserer flere sikkerhetsrisikoer, som inkluderer:

#### Omgåelse av sikkerhetskontroller
MCP-serveren eller nedstrøms API-er kan implementere viktige sikkerhetskontroller som ratebegrensning, forespørselsvalidering eller trafikkovervåking, som er avhengige av tokenets audience eller andre legitimasjonsbegrensninger. Hvis klienter kan skaffe og bruke token direkte mot nedstrøms API-er uten at MCP-serveren validerer dem riktig eller sikrer at tokenene er utstedt for riktig tjeneste, omgår de disse kontrollene.

#### Ansvarlighet og revisjonssporproblemer
MCP-serveren vil ikke kunne identifisere eller skille mellom MCP-klienter når klienter ringer med et upstream-utstedt tilgangstoken som kan være utydelig for MCP-serveren.  
Nedstrøms ressursservers logger kan vise forespørsler som ser ut til å komme fra en annen kilde med en annen identitet, i stedet for MCP-serveren som faktisk videresender tokenene.  
Begge faktorer gjør hendelsesundersøkelser, kontroller og revisjon vanskeligere.  
Hvis MCP-serveren videresender token uten å validere deres påstander (f.eks. roller, privilegier eller audience) eller annen metadata, kan en ondsinnet aktør med et stjålet token bruke serveren som en proxy for dataeksfiltrasjon.

#### Problemer med tillitsgrenser
Nedstrøms ressursserver gir tillit til spesifikke enheter. Denne tilliten kan inkludere antakelser om opprinnelse eller klientatferdsmønstre. Å bryte denne tillitsgrensen kan føre til uventede problemer.  
Hvis tokenet aksepteres av flere tjenester uten riktig validering, kan en angriper som kompromitterer én tjeneste bruke tokenet for å få tilgang til andre tilknyttede tjenester.

#### Risiko for fremtidig kompatibilitet
Selv om en MCP-server i dag starter som en "ren proxy", kan det hende den må legge til sikkerhetskontroller senere. Å starte med riktig separasjon av token audience gjør det enklere å utvikle sikkerhetsmodellen.

### Reduserende tiltak

**MCP-servere MÅ IKKE akseptere noen token som ikke eksplisitt er utstedt for MCP-serveren**

- **Gjennomgå og styrk autorisasjonslogikken:** Revider nøye autorisasjonsimplementeringen i MCP-serveren for å sikre at kun tiltenkte brukere og klienter får tilgang til sensitive ressurser. For praktisk veiledning, se [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) og [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Håndhev sikre tokenpraksiser:** Følg [Microsofts beste praksis for tokenvalidering og levetid](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) for å forhindre misbruk av tilgangstoken og redusere risikoen for token-replay eller tyveri.
- **Beskytt tokenlagring:** Lagre alltid token sikkert og bruk kryptering for å beskytte dem både i ro og under overføring. For implementeringstips, se [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Overdrevne tillatelser for MCP-servere

### Problemstilling  
MCP-servere kan ha fått tildelt overdrevne tillatelser til tjenesten/ressursen de får tilgang til. For eksempel bør en MCP-server som er en del av en AI-salgsapplikasjon som kobler til en bedriftsdatabutikk, ha tilgang begrenset til salgsdataene og ikke ha tillatelse til å få tilgang til alle filene i butikken. Med henvisning til prinsippet om minste privilegium (et av de eldste sikkerhetsprinsippene), skal ingen ressurs ha tillatelser utover det som er nødvendig for å utføre de oppgavene den er ment for. AI utgjør en økt utfordring her fordi for å gjøre den fleksibel, kan det være vanskelig å definere nøyaktig hvilke tillatelser som kreves.

### Risikoer  
- Å gi overdrevne tillatelser kan tillate eksfiltrasjon eller endring av data som MCP-serveren ikke skulle ha tilgang til. Dette kan også være et personvernproblem hvis dataene inneholder personlig identifiserbar informasjon (PII).

### Reduserende tiltak  
- **Bruk prinsippet om minste privilegium:** Gi MCP-serveren kun de minimale tillatelsene som trengs for å utføre sine oppgaver. Gjennomgå og oppdater disse tillatelsene jevnlig for å sikre at de ikke overstiger det som er nødvendig. For detaljert veiledning, se [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Bruk rollebasert tilgangskontroll (RBAC):** Tildel roller til MCP-serveren som er strengt avgrenset til spesifikke ressurser og handlinger, og unngå brede eller unødvendige tillatelser.
- **Overvåk og revider tillatelser:** Overvåk kontinuerlig bruken av tillatelser og revider tilgangslogger for å oppdage og raskt rette opp overdrevne eller ubrukte privilegier.

# Indirekte prompt-injeksjonsangrep

### Problemstilling

Ondsinnede eller kompromitterte MCP-servere kan introdusere betydelige risikoer ved å eksponere kundedata eller muliggjøre utilsiktede handlinger. Disse risikoene er spesielt relevante i AI- og MCP-baserte arbeidsbelastninger, hvor:

- **Prompt-injeksjonsangrep:** Angripere legger inn ondsinnede instruksjoner i prompts eller eksternt innhold, noe som får AI-systemet til å utføre utilsiktede handlinger eller lekke sensitiv data. Les mer: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Verktøyforgiftning:** Angripere manipulerer verktøymetadata (som beskrivelser eller parametere) for å påvirke AI-ens atferd, potensielt for å omgå sikkerhetskontroller eller eksfiltrere data. Detaljer: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Tverrdomeneprompt-injeksjon:** Ondsinnede instruksjoner legges inn i dokumenter, nettsider eller e-poster, som deretter behandles av AI, noe som fører til datalekkasjer eller manipulering.
- **Dynamisk verktøymodifisering (Rug Pulls):** Verktøydefinisjoner kan endres etter brukerens godkjenning, og introdusere ny ondsinnet atferd uten brukerens kjennskap.

Disse sårbarhetene understreker behovet for robust validering, overvåking og sikkerhetskontroller når MCP-servere og verktøy integreres i miljøet ditt. For en dypere gjennomgang, se de lenkede referansene ovenfor.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.no.png)

**Indirekte prompt-injeksjon** (også kjent som tverrdomeneprompt-injeksjon eller XPIA) er en kritisk sårbarhet i generative AI-systemer, inkludert de som bruker Model Context Protocol (MCP). I dette angrepet skjules ondsinnede instruksjoner i eksternt innhold—som dokumenter, nettsider eller e-poster. Når AI-systemet behandler dette innholdet, kan det tolke de innebygde instruksjonene som legitime brukerkommandoer, noe som resulterer i utilsiktede handlinger som datalekkasjer, generering av skadelig innhold eller manipulering av brukerinteraksjoner. For en detaljert forklaring og eksempler fra virkeligheten, se [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

En spesielt farlig form for dette angrepet er **Verktøyforgiftning**. Her injiserer angripere ondsinnede instruksjoner i metadataene til MCP-verktøy (som verktøybeskrivelser eller parametere). Siden store språkmodeller (LLMs) baserer seg på denne metadataen for å avgjøre hvilke verktøy som skal kalles, kan kompromitterte beskrivelser lure modellen til å utføre uautoriserte verktøykall eller omgå sikkerhetskontroller. Disse manipulasjonene er ofte usynlige for sluttbrukere, men kan tolkes og utføres av AI-systemet. Denne risikoen øker i hostede MCP-servermiljøer, hvor verktøydefinisjoner kan oppdateres etter brukerens godkjenning—et scenario som noen ganger kalles en "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". I slike tilfeller kan et verktøy som tidligere var trygt, senere bli modifisert til å utføre ondsinnede handlinger, som å eksfiltrere data eller endre systematferd, uten brukerens kjennskap. For mer om denne angrepsvektoren, se [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.no.png)

## Risikoer  
Utilsiktede AI-handlinger utgjør en rekke sikkerhetsrisikoer som inkluderer datalekkasjer og brudd på personvern.

### Reduserende tiltak  
### Bruke prompt shields for å beskytte mot indirekte prompt-injeksjonsangrep
-----------------------------------------------------------------------------

**AI Prompt Shields** er en løsning utviklet av Microsoft for å forsvare mot både direkte og indirekte prompt-injeksjonsangrep. De hjelper ved å:

1.  **Deteksjon og filtrering:** Prompt Shields bruker avanserte maskinlæringsalgoritmer og naturlig språkprosessering for å oppdage og filtrere ut ondsinnede instruksjoner som er innebygd i eksternt innhold, som dokumenter, nettsider eller e-poster.
    
2.  **Spotlighting:** Denne teknikken hjelper AI-systemet med å skille mellom gyldige systeminstruksjoner og potensielt upålitelige eksterne input. Ved å transformere inndataene på en måte som gjør dem mer relevante for modellen, sikrer Spotlighting at AI-en bedre kan identifisere og ignorere ondsinnede instruksjoner.
    
3.  **Avgrensere og datamerking:** Inkludering av avgrensere i systemmeldingen angir eksplisitt plasseringen av inndata, noe som hjelper AI-systemet med å gjenkjenne og skille brukerinput fra potensielt skadelig eksternt innhold. Datamerking utvider dette konseptet ved å bruke spesielle markører for å fremheve grensene mellom pålitelig og upålitelig data.
    
4.  **Kontinuerlig overvåking og oppdateringer:** Microsoft overvåker og oppdaterer kontinuerlig Prompt Shields for å håndtere nye og utviklende trusler. Denne proaktive tilnærmingen sikrer at forsvarene forblir effektive mot de nyeste angrepsteknikkene.
    
5. **Integrasjon med Azure Content Safety:** Prompt Shields er en del av den bredere Azure AI Content Safety-pakken, som tilbyr flere verktøy for å oppdage jailbreak-forsøk, skadelig innhold og andre sikkerhetsrisikoer i AI-applikasjoner.

Du kan lese mer om AI prompt shields i [Prompt Shields-dokumentasjonen](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.no.png)

# Confused Deputy-problemet

### Problemstilling
Problemet med confused deputy er en sikkerhetssårbarhet som oppstår når en MCP-server fungerer som en proxy mellom MCP-klienter og tredjeparts-APIer. Denne sårbarheten kan utnyttes når MCP-serveren bruker en statisk klient-ID for å autentisere seg mot en tredjeparts autorisasjonsserver som ikke støtter dynamisk klientregistrering.

### Risikoer

- **Omgåelse av samtykke basert på informasjonskapsler**: Hvis en bruker tidligere har autentisert seg gjennom MCP-proxyserveren, kan en tredjeparts autorisasjonsserver sette en samtykkekapsel i brukerens nettleser. En angriper kan senere utnytte dette ved å sende brukeren en ondsinnet lenke med en manipulert autorisasjonsforespørsel som inneholder en ondsinnet redirect URI.
- **Tyveri av autorisasjonskode**: Når brukeren klikker på den ondsinnede lenken, kan tredjeparts autorisasjonsserveren hoppe over samtykkeskjermen på grunn av den eksisterende informasjonskapselen, og autorisasjonskoden kan bli videresendt til angriperens server.
- **Uautorisert API-tilgang**: Angriperen kan bytte den stjålne autorisasjonskoden mot tilgangstokener og utgi seg for å være brukeren for å få tilgang til tredjeparts-APIet uten eksplisitt godkjenning.

### Tiltak for å redusere risiko

- **Krav om eksplisitt samtykke**: MCP-proxyservere som bruker statiske klient-IDer **MÅ** innhente brukerens samtykke for hver dynamisk registrerte klient før de videresender til tredjeparts autorisasjonsservere.
- **Korrekt OAuth-implementering**: Følg OAuth 2.1 sikkerhetsanbefalinger, inkludert bruk av kodeutfordringer (PKCE) for autorisasjonsforespørsler for å forhindre avlyttingsangrep.
- **Klientvalidering**: Implementer streng validering av redirect URIs og klientidentifikatorer for å forhindre utnyttelse av ondsinnede aktører.


# Token Passthrough-sårbarheter

### Problemstilling

"Token passthrough" er et anti-mønster hvor en MCP-server aksepterer tokens fra en MCP-klient uten å validere at tokenene faktisk er utstedt til MCP-serveren selv, og deretter "videresender" dem til nedstrøms APIer. Denne praksisen bryter eksplisitt med MCP-autorisasjonsspesifikasjonen og introduserer alvorlige sikkerhetsrisikoer.

### Risikoer

- **Omgåelse av sikkerhetskontroller**: Klienter kan omgå viktige sikkerhetskontroller som ratebegrensning, forespørselsvalidering eller trafikkovervåking hvis de kan bruke tokens direkte med nedstrøms APIer uten korrekt validering.
- **Problemer med ansvar og revisjonsspor**: MCP-serveren vil ikke kunne identifisere eller skille mellom MCP-klienter når klienter bruker tilgangstokener utstedt oppstrøms, noe som gjør hendelsesundersøkelser og revisjon vanskeligere.
- **Dataeksfiltrasjon**: Hvis tokens videresendes uten korrekt validering av claims, kan en ondsinnet aktør med et stjålet token bruke serveren som proxy for dataeksfiltrasjon.
- **Brudd på tillitsgrenser**: Nedstrøms ressursservere kan gi tillit til spesifikke enheter basert på antakelser om opprinnelse eller atferdsmønstre. Å bryte denne tillitsgrensen kan føre til uventede sikkerhetsproblemer.
- **Feilbruk av tokens på tvers av tjenester**: Hvis tokens aksepteres av flere tjenester uten korrekt validering, kan en angriper som kompromitterer én tjeneste bruke tokenet for å få tilgang til andre tilknyttede tjenester.

### Tiltak for å redusere risiko

- **Tokenvalidering**: MCP-servere **MÅ IKKE** akseptere tokens som ikke eksplisitt er utstedt for MCP-serveren selv.
- **Verifisering av audience**: Alltid valider at tokens har riktig audience-claim som samsvarer med MCP-serverens identitet.
- **Korrekt håndtering av tokenets livssyklus**: Implementer kortlivede tilgangstokener og gode rutiner for tokenrotasjon for å redusere risikoen for token-tyveri og misbruk.


# Sesjonskapring

### Problemstilling

Sesjonskapring er en angrepsmetode hvor en klient får tildelt en sesjons-ID av serveren, og en uautorisert part skaffer seg og bruker den samme sesjons-IDen for å utgi seg for å være den opprinnelige klienten og utføre uautoriserte handlinger på deres vegne. Dette er spesielt bekymringsfullt i stateful HTTP-servere som håndterer MCP-forespørsler.

### Risikoer

- **Sesjonskapring via prompt-injeksjon**: En angriper som får tak i en sesjons-ID kan sende ondsinnede hendelser til en server som deler sesjonsstatus med serveren klienten er koblet til, noe som potensielt kan utløse skadelige handlinger eller gi tilgang til sensitiv informasjon.
- **Sesjonskapring via utgi seg for andre**: En angriper med en stjålet sesjons-ID kan gjøre kall direkte til MCP-serveren, omgå autentisering og bli behandlet som den legitime brukeren.
- **Kompromitterte gjenopptakbare strømmer**: Når en server støtter gjenlevering/gjenopptakbare strømmer, kan en angriper avslutte en forespørsel for tidlig, noe som fører til at den blir gjenopptatt senere av den opprinnelige klienten med potensielt ondsinnet innhold.

### Tiltak for å redusere risiko

- **Verifisering av autorisasjon**: MCP-servere som implementerer autorisasjon **MÅ** verifisere alle innkommende forespørsler og **MÅ IKKE** bruke sesjoner for autentisering.
- **Sikre sesjons-IDer**: MCP-servere **MÅ** bruke sikre, ikke-deterministiske sesjons-IDer generert med sikre tilfeldige tallgeneratorer. Unngå forutsigbare eller sekvensielle identifikatorer.
- **Brukerspesifikk sesjonsbinding**: MCP-servere **BØR** binde sesjons-IDer til brukerspesifikk informasjon, ved å kombinere sesjons-IDen med informasjon unik for den autoriserte brukeren (som deres interne bruker-ID) i et format som `
<user_id>:<session_id>`.
- **Sesjonsutløp**: Implementer korrekt sesjonsutløp og rotasjon for å begrense sårbarhetsvinduet hvis en sesjons-ID blir kompromittert.
- **Transport-sikkerhet**: Bruk alltid HTTPS for all kommunikasjon for å forhindre avlytting av sesjons-IDer.


# Sikkerhet i leverandørkjeden

Sikkerhet i leverandørkjeden er fortsatt grunnleggende i AI-æraen, men omfanget av hva som utgjør leverandørkjeden din har utvidet seg. I tillegg til tradisjonelle kodepakker må du nå grundig verifisere og overvåke alle AI-relaterte komponenter, inkludert grunnmodeller, embeddings-tjenester, kontekstleverandører og tredjeparts-APIer. Hver av disse kan introdusere sårbarheter eller risikoer hvis de ikke håndteres riktig.

**Nøkkelpraksiser for sikkerhet i AI- og MCP-leverandørkjeden:**
- **Verifiser alle komponenter før integrasjon:** Dette inkluderer ikke bare open source-biblioteker, men også AI-modeller, datakilder og eksterne APIer. Sjekk alltid opprinnelse, lisensiering og kjente sårbarheter.
- **Oppretthold sikre distribusjonspipelines:** Bruk automatiserte CI/CD-pipelines med integrert sikkerhetsskanning for å oppdage problemer tidlig. Sørg for at kun betrodde artefakter distribueres til produksjon.
- **Kontinuerlig overvåking og revisjon:** Implementer løpende overvåking av alle avhengigheter, inkludert modeller og datatjenester, for å oppdage nye sårbarheter eller angrep mot leverandørkjeden.
- **Bruk minste privilegium og tilgangskontroller:** Begrens tilgang til modeller, data og tjenester til kun det som er nødvendig for at MCP-serveren skal fungere.
- **Rask respons på trusler:** Ha en prosess for å oppdatere eller erstatte kompromitterte komponenter, og for å rotere hemmeligheter eller legitimasjon hvis et brudd oppdages.

[GitHub Advanced Security](https://github.com/security/advanced-security) tilbyr funksjoner som hemmelighetsskanning, avhengighetsskanning og CodeQL-analyse. Disse verktøyene integreres med [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) og [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) for å hjelpe team med å identifisere og redusere sårbarheter både i kode og AI-leverandørkjede-komponenter.

Microsoft implementerer også omfattende sikkerhetspraksiser for leverandørkjeden internt for alle produkter. Les mer i [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Etablerte sikkerhetspraksiser som vil styrke sikkerhetsnivået i din MCP-implementering

Enhver MCP-implementering arver det eksisterende sikkerhetsnivået i organisasjonens miljø som den er bygget på, så når du vurderer sikkerheten til MCP som en komponent i dine AI-systemer, anbefales det å heve det generelle sikkerhetsnivået. Følgende etablerte sikkerhetskontroller er spesielt relevante:

-   Beste praksis for sikker koding i AI-applikasjonen din – beskytt mot [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), bruk av sikre hemmelighetslagre for hemmeligheter og tokens, implementering av ende-til-ende sikre kommunikasjoner mellom alle applikasjonskomponenter, osv.
-   Serverforsterkning – bruk MFA der det er mulig, hold systemet oppdatert med sikkerhetsoppdateringer, integrer serveren med en tredjeparts identitetsleverandør for tilgang, osv.
-   Hold enheter, infrastruktur og applikasjoner oppdatert med sikkerhetsoppdateringer
-   Sikkerhetsovervåking – implementer logging og overvåking av AI-applikasjonen (inkludert MCP-klient/servere) og send disse loggene til et sentralt SIEM for å oppdage unormal aktivitet
-   Zero trust-arkitektur – isoler komponenter via nettverks- og identitetskontroller på en logisk måte for å minimere lateral bevegelse hvis en AI-applikasjon blir kompromittert.

# Viktige punkter

- Grunnleggende sikkerhet er fortsatt avgjørende: Sikker koding, minste privilegium, verifisering av leverandørkjeden og kontinuerlig overvåking er essensielt for MCP og AI-arbeidsbelastninger.
- MCP introduserer nye risikoer – som prompt-injeksjon, verktøyforgiftning, sesjonskapring, confused deputy-problemer, token passthrough-sårbarheter og overdrevne tillatelser – som krever både tradisjonelle og AI-spesifikke kontroller.
- Bruk robust autentisering, autorisasjon og tokenhåndtering, og benytt eksterne identitetsleverandører som Microsoft Entra ID der det er mulig.
- Beskytt mot indirekte prompt-injeksjon og verktøyforgiftning ved å validere verktøymetadata, overvåke dynamiske endringer og bruke løsninger som Microsoft Prompt Shields.
- Implementer sikker sesjonshåndtering ved å bruke ikke-deterministiske sesjons-IDer, binde sesjoner til brukeridentiteter, og aldri bruke sesjoner for autentisering.
- Forhindre confused deputy-angrep ved å kreve eksplisitt brukersamtykke for hver dynamisk registrerte klient og implementere riktige OAuth-sikkerhetsrutiner.
- Unngå token passthrough-sårbarheter ved å sikre at MCP-servere kun aksepterer tokens som eksplisitt er utstedt for dem, og valider token-claims korrekt.
- Behandle alle komponenter i AI-leverandørkjeden – inkludert modeller, embeddings og kontekstleverandører – med samme grundighet som kodeavhengigheter.
- Hold deg oppdatert med utviklingen i MCP-spesifikasjonene og bidra til fellesskapet for å forme sikre standarder.

# Ytterligere ressurser

## Eksterne ressurser
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

## Ytterligere sikkerhetsdokumenter

For mer detaljert sikkerhetsveiledning, se disse dokumentene:

- [MCP Security Best Practices 2025](./mcp-security-best-practices-2025.md) – Omfattende liste over sikkerhetspraksiser for MCP-implementeringer
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md) – Implementeringseksempler for integrering av Azure Content Safety med MCP-servere
- [MCP Security Controls 2025](./mcp-security-controls-2025.md) – Nyeste sikkerhetskontroller og teknikker for å sikre MCP-distribusjoner
- [MCP Best Practices](./mcp-best-practices.md) – Rask referanseguide for MCP-sikkerhet

### Neste

Neste: [Kapittel 3: Komme i gang](../03-GettingStarted/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på originalspråket skal anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.