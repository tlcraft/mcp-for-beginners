<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00aedb7b1d11b7eaacb0618d8791c65",
  "translation_date": "2025-05-29T23:24:05+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "no"
}
-->
# Sikkerhets beste praksis

Å ta i bruk Model Context Protocol (MCP) gir kraftige nye muligheter for AI-drevne applikasjoner, men introduserer også unike sikkerhetsutfordringer som går utover tradisjonelle programvarerisikoer. I tillegg til etablerte bekymringer som sikker koding, minste privilegium og leverandørkjede-sikkerhet, står MCP og AI-arbeidsmengder overfor nye trusler som prompt-injeksjon, verktøyforgiftning og dynamisk verktøymodifisering. Disse risikoene kan føre til datalekkasjer, brudd på personvern og utilsiktet systematferd hvis de ikke håndteres riktig.

Denne leksjonen utforsker de mest relevante sikkerhetsrisikoene knyttet til MCP—inkludert autentisering, autorisasjon, overdrevne tillatelser, indirekte prompt-injeksjon og sårbarheter i leverandørkjeden—og gir praktiske kontroller og beste praksiser for å redusere dem. Du vil også lære hvordan du kan utnytte Microsoft-løsninger som Prompt Shields, Azure Content Safety og GitHub Advanced Security for å styrke din MCP-implementering. Ved å forstå og anvende disse kontrollene kan du betydelig redusere sannsynligheten for et sikkerhetsbrudd og sikre at AI-systemene dine forblir robuste og pålitelige.

# Læringsmål

Ved slutten av denne leksjonen vil du kunne:

- Identifisere og forklare de unike sikkerhetsrisikoene som Model Context Protocol (MCP) introduserer, inkludert prompt-injeksjon, verktøyforgiftning, overdrevne tillatelser og sårbarheter i leverandørkjeden.
- Beskrive og anvende effektive tiltak for å redusere MCP-sikkerhetsrisikoer, som robust autentisering, minste privilegium, sikker token-håndtering og verifisering av leverandørkjeden.
- Forstå og bruke Microsoft-løsninger som Prompt Shields, Azure Content Safety og GitHub Advanced Security for å beskytte MCP og AI-arbeidsmengder.
- Gjenkjenne viktigheten av å validere verktøymetadata, overvåke dynamiske endringer og forsvare seg mot indirekte prompt-injeksjonsangrep.
- Integrere etablerte sikkerhets beste praksiser—som sikker koding, serverhardening og zero trust-arkitektur—i din MCP-implementering for å redusere sannsynlighet og konsekvens av sikkerhetsbrudd.

# MCP sikkerhetskontroller

Enhver system som har tilgang til viktige ressurser har iboende sikkerhetsutfordringer. Sikkerhetsutfordringer kan vanligvis håndteres gjennom korrekt anvendelse av grunnleggende sikkerhetskontroller og konsepter. Siden MCP er nylig definert, endres spesifikasjonen raskt i takt med at protokollen utvikler seg. Etter hvert vil sikkerhetskontrollene modnes, noe som muliggjør bedre integrasjon med virksomhetens og etablerte sikkerhetsarkitekturer og beste praksiser.

Forskning publisert i [Microsoft Digital Defense Report](https://aka.ms/mddr) viser at 98 % av rapporterte brudd kunne vært forhindret med god sikkerhetshygiene, og den beste beskyttelsen mot ethvert brudd er å ha et solid grunnlag i sikkerhetshygiene, sikre kodingspraksiser og leverandørkjede-sikkerhet – disse velprøvde metodene har fortsatt størst effekt på å redusere sikkerhetsrisiko.

La oss se på noen måter du kan begynne å adressere sikkerhetsrisikoer når du tar i bruk MCP.

> **Note:** Følgende informasjon er korrekt per **29. mai 2025**. MCP-protokollen utvikler seg kontinuerlig, og fremtidige implementeringer kan introdusere nye autentiseringsmønstre og kontroller. For siste oppdateringer og veiledning, se alltid [MCP Specification](https://spec.modelcontextprotocol.io/), den offisielle [MCP GitHub repository](https://github.com/modelcontextprotocol) og [security best practice page](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Problemstilling  
Den opprinnelige MCP-spesifikasjonen antok at utviklere ville lage sin egen autentiseringsserver. Dette krevde kunnskap om OAuth og relaterte sikkerhetsbegrensninger. MCP-servere fungerte som OAuth 2.0 Autorisasjonsservere, og håndterte brukerautentisering direkte i stedet for å delegere den til en ekstern tjeneste som Microsoft Entra ID. Fra og med **26. april 2025** tillater en oppdatering i MCP-spesifikasjonen at MCP-servere kan delegere brukerautentisering til en ekstern tjeneste.

### Risikoer
- Feilkonfigurert autorisasjonslogikk i MCP-serveren kan føre til eksponering av sensitiv data og feilaktig anvendte tilgangskontroller.
- OAuth-token-tyveri på lokal MCP-server. Hvis tokenet blir stjålet, kan det brukes til å utgi seg for MCP-serveren og få tilgang til ressurser og data som tokenet gjelder for.

#### Token Passthrough
Token passthrough er uttrykkelig forbudt i autorisasjonsspesifikasjonen fordi det introduserer flere sikkerhetsrisikoer, blant annet:

#### Omgåelse av sikkerhetskontroller
MCP-serveren eller nedstrøms API-er kan implementere viktige sikkerhetskontroller som ratebegrensning, forespørselsvalidering eller trafikkovervåkning, som er avhengige av tokenets målgruppe eller andre legitimasjonsbegrensninger. Hvis klienter kan skaffe og bruke token direkte med nedstrøms API-er uten at MCP-serveren validerer dem ordentlig eller sikrer at tokenene er utstedt for riktig tjeneste, omgår de disse kontrollene.

#### Ansvars- og revisjonssporproblemer
MCP-serveren vil ikke kunne identifisere eller skille mellom MCP-klienter når klienter ringer med et tilgangstoken utstedt av en upstream som kan være utydelig for MCP-serveren.  
Nedstrøms ressursservers logger kan vise forespørsler som ser ut til å komme fra en annen kilde med en annen identitet, i stedet for MCP-serveren som faktisk videresender tokenene.  
Begge forholdene gjør hendelsesundersøkelser, kontroll og revisjon vanskeligere.  
Hvis MCP-serveren videresender token uten å validere deres påstander (f.eks. roller, privilegier eller målgruppe) eller annen metadata, kan en ondsinnet aktør med et stjålet token bruke serveren som en proxy for dataeksfiltrasjon.

#### Problemer med tillitsgrenser
Nedstrøms ressursserver gir tillit til spesifikke enheter. Denne tilliten kan inkludere antakelser om opprinnelse eller klientatferdsmønstre. Å bryte denne tillitsgrensen kan føre til uventede problemer.  
Hvis tokenet godtas av flere tjenester uten riktig validering, kan en angriper som kompromitterer én tjeneste bruke tokenet til å få tilgang til andre tilknyttede tjenester.

#### Risiko for fremtidig kompatibilitet
Selv om en MCP-server i dag starter som en "ren proxy", kan det bli nødvendig å legge til sikkerhetskontroller senere. Å starte med riktig separasjon av tokenmålgruppe gjør det enklere å utvikle sikkerhetsmodellen.

### Reduserende kontroller

**MCP-servere MÅ IKKE akseptere noen token som ikke eksplisitt er utstedt for MCP-serveren**

- **Gjennomgå og styrk autorisasjonslogikken:** Revider nøye MCP-serverens autorisasjonsimplementering for å sikre at bare tiltenkte brukere og klienter får tilgang til sensitive ressurser. For praktisk veiledning, se [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) og [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Håndhev sikre token-praksiser:** Følg [Microsofts beste praksis for token-validering og levetid](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) for å forhindre misbruk av tilgangstoken og redusere risikoen for token-gjenspilling eller tyveri.
- **Beskytt token-lagring:** Lagre alltid token sikkert og bruk kryptering for å beskytte dem i ro og under overføring. For implementeringstips, se [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Overdrevne tillatelser for MCP-servere

### Problemstilling
MCP-servere kan ha fått tildelt overdrevne tillatelser til tjenesten/ressursen de får tilgang til. For eksempel bør en MCP-server som er en del av en AI-salgsapplikasjon som kobler til et bedriftsdatasystem, ha tilgang begrenset til salgsdata og ikke kunne få tilgang til alle filer i systemet. Tilbake til prinsippet om minste privilegium (et av de eldste sikkerhetsprinsippene), skal ingen ressurs ha tillatelser utover det som er nødvendig for å utføre oppgavene den er ment for. AI utgjør en økt utfordring i dette området fordi det kan være vanskelig å definere nøyaktig hvilke tillatelser som kreves for å sikre fleksibilitet.

### Risikoer  
- Å gi overdrevne tillatelser kan tillate eksfiltrasjon eller endring av data som MCP-serveren ikke skulle ha tilgang til. Dette kan også være et personvernproblem hvis dataene inneholder personlig identifiserbar informasjon (PII).

### Reduserende kontroller
- **Anvend prinsippet om minste privilegium:** Gi MCP-serveren kun de minimumstillatelser som er nødvendige for å utføre sine oppgaver. Gjennomgå og oppdater disse tillatelsene regelmessig for å sikre at de ikke overstiger det som trengs. For detaljert veiledning, se [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Bruk rollebasert tilgangskontroll (RBAC):** Tilordne roller til MCP-serveren som er nøye avgrenset til spesifikke ressurser og handlinger, og unngå brede eller unødvendige tillatelser.
- **Overvåk og revider tillatelser:** Overvåk kontinuerlig bruk av tillatelser og revider tilgangslogger for å oppdage og raskt rette opp i overdrevne eller ubrukte privilegier.

# Indirekte prompt-injeksjonsangrep

### Problemstilling

Ondsinnede eller kompromitterte MCP-servere kan introdusere betydelige risikoer ved å eksponere kundedata eller muliggjøre utilsiktede handlinger. Disse risikoene er spesielt relevante i AI- og MCP-baserte arbeidsmengder, hvor:

- **Prompt-injeksjonsangrep:** Angripere legger inn ondsinnede instruksjoner i prompts eller eksternt innhold, noe som får AI-systemet til å utføre utilsiktede handlinger eller lekke sensitiv informasjon. Les mer: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Verktøyforgiftning:** Angripere manipulerer verktøymetadata (som beskrivelser eller parametere) for å påvirke AI-ens atferd, potensielt omgå sikkerhetskontroller eller eksfiltrere data. Detaljer: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Tverrdomenebasert prompt-injeksjon:** Ondsinnede instruksjoner legges inn i dokumenter, nettsider eller e-poster, som deretter behandles av AI, noe som fører til datalekkasjer eller manipulering.
- **Dynamisk verktøymodifisering (Rug Pulls):** Verktøydefinisjoner kan endres etter brukerens godkjenning, og introdusere ny ondsinnet atferd uten brukerens viten.

Disse sårbarhetene understreker behovet for robust validering, overvåking og sikkerhetskontroller når MCP-servere og verktøy integreres i miljøet ditt. For en grundigere gjennomgang, se de lenkede referansene ovenfor.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.no.png)

**Indirekte prompt-injeksjon** (også kjent som tverrdomenebasert prompt-injeksjon eller XPIA) er en kritisk sårbarhet i generative AI-systemer, inkludert de som bruker Model Context Protocol (MCP). I dette angrepet skjules ondsinnede instruksjoner i eksternt innhold—som dokumenter, nettsider eller e-poster. Når AI-systemet behandler dette innholdet, kan det tolke de innebygde instruksjonene som legitime brukerkommandoer, noe som resulterer i utilsiktede handlinger som datalekkasjer, generering av skadelig innhold eller manipulering av brukerinteraksjoner. For en detaljert forklaring og eksempler fra virkeligheten, se [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

En spesielt farlig form for dette angrepet er **verktøyforgiftning**. Her injiserer angripere ondsinnede instruksjoner i metadataene til MCP-verktøy (som verktøybeskrivelser eller parametere). Siden store språkmodeller (LLM-er) baserer seg på denne metadataen for å avgjøre hvilke verktøy de skal bruke, kan kompromitterte beskrivelser lure modellen til å utføre uautoriserte verktøykall eller omgå sikkerhetskontroller. Disse manipuleringene er ofte usynlige for sluttbrukere, men kan tolkes og utføres av AI-systemet. Risikoen øker i hostede MCP-servermiljøer, hvor verktøydefinisjoner kan oppdateres etter brukerens godkjenning—et scenario som noen ganger kalles en "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". I slike tilfeller kan et verktøy som tidligere var trygt, senere bli endret for å utføre ondsinnede handlinger, som å eksfiltrere data eller endre systematferd, uten at brukeren vet det. For mer om denne angrepsvektoren, se [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.no.png)

## Risikoer
Utilsiktede AI-handlinger utgjør flere sikkerhetsrisikoer som inkluderer datalekkasjer og brudd på personvern.

### Reduserende kontroller
### Bruke prompt shields for å beskytte mot indirekte prompt-injeksjonsangrep
-----------------------------------------------------------------------------

**AI Prompt Shields** er en løsning utviklet av Microsoft for å forsvare mot både direkte og indirekte prompt-injeksjonsangrep. De hjelper gjennom:

1.  **Deteksjon og filtrering:** Prompt Shields bruker avanserte maskinlæringsalgoritmer og naturlig språkprosessering for å oppdage og filtrere ut ondsinnede instruksjoner som er innebygd i eksternt innhold, som dokumenter, nettsider eller e-poster.
    
2.  **Spotlighting:** Denne teknikken hjelper AI-systemet med å skille mellom gyldige systeminstruksjoner og potensielt upålitelige eksterne innspill. Ved å transformere inndataene på en måte som gjør dem mer relevante for modellen, sikrer Spotlighting at AI-en bedre kan identifisere og ignorere ondsinnede instruksjoner.
    
3.  **Avgrensere og datamerking:** Inkludering av avgrensere i systemmeldingen tydeliggjør plasseringen av inndata, noe som hjelper AI-systemet med å gjenkjenne og skille brukerinnspill fra potensielt skadelig eksternt innhold. Datamerking utvider dette konseptet ved å bruke spesielle markører for å fremheve grensene mellom pålitelig og upålitelig data.
    
4.  **Kontinuerlig overvåking og oppdateringer:** Microsoft overvåker og oppdaterer kontinuerlig Prompt Shields for å møte nye og utviklende trusler. Denne proaktive tilnærmingen sikrer at forsvaret forblir effektivt mot de nyeste angrepsteknikkene.
    
5. **Integrasjon med Azure Content Safety:** Prompt Shields er en del av den bredere Azure AI Content Safety-pakken, som tilbyr ytterligere verktøy for å oppdage jailbreak-forsøk, skadelig innhold og andre sikkerhetsrisikoer i AI-applikasjoner.

Du kan lese mer om AI prompt shields i [Prompt Shields dokumentasjonen](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.no.png)

### Leverandørkjede-sikkerhet

Leverandørkjede-sikkerhet forblir grunnleggende i AI-æraen, men omfanget av hva som utgjør leverandørkjeden din har utvidet seg. I tillegg til tradisjonelle kodepakker må du nå grundig verifisere og overvåke alle AI-relaterte komponenter, inkludert grunnmodeller, embedding-tjenester, kontekstleverandører og tredjeparts-API-er. Hver av disse kan introdusere sårbarheter eller risiko hvis de ikke håndteres riktig.

**Nøkkelpraksiser for leverandørkjede-sikkerhet for AI og MCP:**
- **Verifiser alle komponenter før integrasjon:** Dette inkluder
- [OWASP Topp 10](https://owasp.org/www-project-top-ten/)
- [OWASP Topp 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Reisen for å sikre programvareleverandørkjeden hos Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Sikre minste privilegiumstilgang (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Beste praksis for tokenvalidering og levetid](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Bruk sikker tokenlagring og krypter tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management som autentiseringsgateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [MCP sikkerhets beste praksis](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Bruke Microsoft Entra ID for å autentisere med MCP-servere](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Neste

Neste: [Kapittel 3: Komme i gang](/03-GettingStarted/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på originalspråket bør betraktes som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.