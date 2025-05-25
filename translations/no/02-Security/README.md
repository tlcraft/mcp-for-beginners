<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-20T23:13:46+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "no"
}
-->
# Sikkerhets beste praksis

Å ta i bruk Model Context Protocol (MCP) gir kraftige nye muligheter for AI-drevne applikasjoner, men introduserer også unike sikkerhetsutfordringer som går utover tradisjonelle programvarerisikoer. I tillegg til etablerte hensyn som sikker koding, minste privilegium og leverandørkjede-sikkerhet, står MCP og AI-arbeidsmengder overfor nye trusler som prompt-injeksjon, verktøytoksinering og dynamisk verktøymodifikasjon. Disse risikoene kan føre til datalekkasjer, brudd på personvern og uønsket systematferd hvis de ikke håndteres riktig.

Denne leksjonen utforsker de mest relevante sikkerhetsrisikoene knyttet til MCP—inkludert autentisering, autorisasjon, overdrevne tillatelser, indirekte prompt-injeksjon og leverandørkjede-sårbarheter—og gir praktiske kontroller og beste praksiser for å redusere dem. Du vil også lære hvordan du kan utnytte Microsoft-løsninger som Prompt Shields, Azure Content Safety og GitHub Advanced Security for å styrke din MCP-implementering. Ved å forstå og anvende disse kontrollene kan du betydelig redusere sannsynligheten for et sikkerhetsbrudd og sikre at AI-systemene dine forblir robuste og pålitelige.

# Læringsmål

Ved slutten av denne leksjonen vil du kunne:

- Identifisere og forklare de unike sikkerhetsrisikoene som Model Context Protocol (MCP) introduserer, inkludert prompt-injeksjon, verktøytoksinering, overdrevne tillatelser og leverandørkjede-sårbarheter.
- Beskrive og anvende effektive tiltak for å redusere MCP-sikkerhetsrisikoer, som robust autentisering, minste privilegium, sikker token-håndtering og leverandørkjede-verifisering.
- Forstå og utnytte Microsoft-løsninger som Prompt Shields, Azure Content Safety og GitHub Advanced Security for å beskytte MCP og AI-arbeidsmengder.
- Anerkjenne viktigheten av å validere verktøymetadata, overvåke dynamiske endringer og forsvare seg mot indirekte prompt-injeksjonsangrep.
- Integrere etablerte sikkerhetsprinsipper—som sikker koding, serverhardening og zero trust-arkitektur—i din MCP-implementering for å redusere sannsynligheten og konsekvensene av sikkerhetsbrudd.

# MCP sikkerhetskontroller

Enhver system som har tilgang til viktige ressurser har iboende sikkerhetsutfordringer. Sikkerhetsutfordringer kan generelt håndteres gjennom riktig anvendelse av grunnleggende sikkerhetskontroller og konsepter. Siden MCP er nylig definert, endres spesifikasjonen raskt og protokollen utvikler seg. Etter hvert vil sikkerhetskontrollene i den modnes, noe som muliggjør bedre integrasjon med virksomhets- og etablerte sikkerhetsarkitekturer og beste praksis.

Forskning publisert i [Microsoft Digital Defense Report](https://aka.ms/mddr) sier at 98 % av rapporterte brudd kunne vært forhindret med robust sikkerhetshygiene, og den beste beskyttelsen mot alle typer brudd er å få på plass grunnleggende sikkerhetshygiene, sikre koding og leverandørkjede-sikkerhet — de velprøvde metodene vi allerede kjenner til, har fortsatt størst effekt for å redusere sikkerhetsrisiko.

La oss se på noen måter du kan begynne å adressere sikkerhetsrisikoer ved å ta i bruk MCP.

# MCP serverautentisering (hvis din MCP-implementering var før 26. april 2025)

> **Note:** Følgende informasjon er korrekt per 26. april 2025. MCP-protokollen utvikler seg kontinuerlig, og fremtidige implementeringer kan introdusere nye autentiseringsmønstre og kontroller. For siste oppdateringer og veiledning, se alltid [MCP Specification](https://spec.modelcontextprotocol.io/) og den offisielle [MCP GitHub repository](https://github.com/modelcontextprotocol).

### Problemstilling  
Den opprinnelige MCP-spesifikasjonen antok at utviklere skulle skrive sin egen autentiseringsserver. Dette krevde kunnskap om OAuth og relaterte sikkerhetsbegrensninger. MCP-servere fungerte som OAuth 2.0-autorisasjonsservere, og håndterte nødvendig brukerautentisering direkte i stedet for å delegere den til en ekstern tjeneste som Microsoft Entra ID. Fra 26. april 2025 tillater en oppdatering i MCP-spesifikasjonen at MCP-servere kan delegere brukerautentisering til en ekstern tjeneste.

### Risikoer
- Feilkonfigurert autorisasjonslogikk i MCP-serveren kan føre til eksponering av sensitiv data og feilaktig tilgangskontroll.
- OAuth-token-tyveri på lokal MCP-server. Hvis tokenet blir stjålet, kan det brukes til å utgi seg for MCP-serveren og få tilgang til ressurser og data som OAuth-tokenet gjelder for.

### Reduserende tiltak
- **Gjennomgå og styrk autorisasjonslogikken:** Revider nøye autorisasjonsimplementeringen i MCP-serveren for å sikre at kun tiltenkte brukere og klienter får tilgang til sensitive ressurser. For praktisk veiledning, se [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) og [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Håndhev sikre token-praksiser:** Følg [Microsofts beste praksis for token-validering og levetid](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) for å forhindre misbruk av tilgangstoken og redusere risiko for token-gjenspilling eller tyveri.
- **Beskytt token-lagring:** Lagre alltid tokens sikkert og bruk kryptering for å beskytte dem i hvile og under overføring. For implementeringstips, se [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Overdrevne tillatelser for MCP-servere

### Problemstilling  
MCP-servere kan ha fått tildelt overdrevne tillatelser til tjenesten/ressursen de har tilgang til. For eksempel bør en MCP-server som er del av en AI-salgsapplikasjon som kobler til et virksomhetsdatastore, kun ha tilgang avgrenset til salgsdata og ikke tillatelse til å aksessere alle filer i lagringen. Med henvisning til prinsippet om minste privilegium (et av de eldste sikkerhetsprinsippene), bør ingen ressurs ha flere tillatelser enn det som kreves for å utføre sine tiltenkte oppgaver. AI skaper en økt utfordring her fordi det kan være vanskelig å definere nøyaktig hvilke tillatelser som trengs for å være fleksibel.

### Risikoer  
- Å gi overdrevne tillatelser kan tillate dataeksfiltrering eller endring av data som MCP-serveren ikke skulle ha tilgang til. Dette kan også være et personvernproblem hvis dataene inneholder personlig identifiserbar informasjon (PII).

### Reduserende tiltak
- **Bruk prinsippet om minste privilegium:** Gi MCP-serveren kun de minste nødvendige tillatelsene for å utføre sine oppgaver. Gjennomgå og oppdater disse tillatelsene regelmessig for å sikre at de ikke overstiger det som er nødvendig. For detaljert veiledning, se [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Bruk rollebasert tilgangskontroll (RBAC):** Tilordne roller til MCP-serveren som er strengt avgrenset til spesifikke ressurser og handlinger, og unngå brede eller unødvendige tillatelser.
- **Overvåk og revider tillatelser:** Overvåk kontinuerlig bruk av tillatelser og revider tilgangslogger for å oppdage og rette opp i overdrevne eller ubrukte privilegier raskt.

# Indirekte prompt-injeksjonsangrep

### Problemstilling

Ondsinnede eller kompromitterte MCP-servere kan introdusere betydelige risikoer ved å eksponere kundedata eller muliggjøre uønskede handlinger. Disse risikoene er spesielt relevante i AI- og MCP-baserte arbeidsmengder, hvor:

- **Prompt-injeksjonsangrep:** Angripere legger inn skadelige instruksjoner i prompts eller eksternt innhold, noe som får AI-systemet til å utføre uønskede handlinger eller lekke sensitiv data. Les mer: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Verktøytoksinering:** Angripere manipulerer verktøymetadata (som beskrivelser eller parametere) for å påvirke AI-ens oppførsel, potensielt for å omgå sikkerhetskontroller eller eksfiltrere data. Detaljer: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Kryss-domene prompt-injeksjon:** Ondsinnede instruksjoner er innebygd i dokumenter, nettsider eller e-poster, som deretter behandles av AI, noe som fører til datalekkasjer eller manipulering.
- **Dynamisk verktøymodifikasjon (Rug Pulls):** Verktøydefinisjoner kan endres etter brukerens godkjenning, og introdusere nye skadelige funksjoner uten brukerens viten.

Disse sårbarhetene understreker behovet for robust validering, overvåkning og sikkerhetskontroller når MCP-servere og verktøy integreres i miljøet ditt. For en dypere gjennomgang, se de lenkede referansene ovenfor.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.no.png)

**Indirekte prompt-injeksjon** (også kjent som kryss-domene prompt-injeksjon eller XPIA) er en kritisk sårbarhet i generative AI-systemer, inkludert de som bruker Model Context Protocol (MCP). I dette angrepet skjules ondsinnede instruksjoner i eksternt innhold—som dokumenter, nettsider eller e-poster. Når AI-systemet behandler dette innholdet, kan det tolke de innebygde instruksjonene som legitime brukerkommandoer, noe som resulterer i uønskede handlinger som datalekkasjer, generering av skadelig innhold eller manipulering av brukerinteraksjoner. For en detaljert forklaring og virkelige eksempler, se [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

En spesielt farlig form for dette angrepet er **Verktøytoksinering**. Her injiserer angripere ondsinnede instruksjoner i metadataene til MCP-verktøy (som verktøybeskrivelser eller parametere). Siden store språkmodeller (LLMs) bruker denne metadataen for å avgjøre hvilke verktøy de skal kalle, kan kompromitterte beskrivelser lure modellen til å utføre uautoriserte verktøykall eller omgå sikkerhetskontroller. Disse manipulasjonene er ofte usynlige for sluttbrukere, men kan tolkes og utføres av AI-systemet. Denne risikoen øker i hostede MCP-servermiljøer, hvor verktøydefinisjoner kan oppdateres etter brukerens godkjenning—et scenario som noen ganger kalles en "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". I slike tilfeller kan et tidligere trygt verktøy senere bli endret for å utføre skadelige handlinger, som datalekkasjer eller endring av systematferd, uten at brukeren er klar over det. For mer om denne angrepsvektoren, se [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.no.png)

## Risikoer  
Uønskede AI-handlinger medfører ulike sikkerhetsrisikoer, inkludert datalekkasjer og brudd på personvern.

### Reduserende tiltak  
### Bruke prompt shields for å beskytte mot indirekte prompt-injeksjonsangrep
-----------------------------------------------------------------------------

**AI Prompt Shields** er en løsning utviklet av Microsoft for å forsvare mot både direkte og indirekte prompt-injeksjonsangrep. De hjelper ved å:

1.  **Deteksjon og filtrering:** Prompt Shields bruker avanserte maskinlæringsalgoritmer og naturlig språkprosessering for å oppdage og filtrere ut ondsinnede instruksjoner innebygd i eksternt innhold, som dokumenter, nettsider eller e-poster.
    
2.  **Spotlighting:** Denne teknikken hjelper AI-systemet å skille mellom gyldige systeminstruksjoner og potensielt upålitelige eksterne input. Ved å transformere inntekst på en måte som gjør den mer relevant for modellen, sikrer Spotlighting at AI bedre kan identifisere og ignorere skadelige instruksjoner.
    
3.  **Avgrensere og datamerking:** Å inkludere avgrensere i systemmeldingen tydeliggjør hvor inntekst befinner seg, og hjelper AI-systemet med å gjenkjenne og skille brukerinput fra potensielt skadelig eksternt innhold. Datamerking utvider dette konseptet ved å bruke spesielle markører for å fremheve grensene mellom pålitelige og upålitelige data.
    
4.  **Kontinuerlig overvåking og oppdateringer:** Microsoft overvåker og oppdaterer kontinuerlig Prompt Shields for å møte nye og utviklende trusler. Denne proaktive tilnærmingen sikrer at forsvarene forblir effektive mot de nyeste angrepsteknikkene.
    
5. **Integrasjon med Azure Content Safety:** Prompt Shields er en del av den bredere Azure AI Content Safety-pakken, som tilbyr tilleggsløsninger for å oppdage jailbreak-forsøk, skadelig innhold og andre sikkerhetsrisikoer i AI-applikasjoner.

Du kan lese mer om AI prompt shields i [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.no.png)

### Leverandørkjede-sikkerhet

Leverandørkjede-sikkerhet forblir grunnleggende i AI-æraen, men omfanget av hva som utgjør leverandørkjeden har utvidet seg. I tillegg til tradisjonelle kodepakker må du nå grundig verifisere og overvåke alle AI-relaterte komponenter, inkludert grunnmodeller, embeddings-tjenester, kontekstleverandører og tredjeparts-API-er. Hver av disse kan introdusere sårbarheter eller risikoer hvis de ikke håndteres riktig.

**Nøkkelpraksiser for leverandørkjede-sikkerhet i AI og MCP:**
- **Verifiser alle komponenter før integrasjon:** Dette inkluderer ikke bare open source-biblioteker, men også AI-modeller, datakilder og eksterne API-er. Sjekk alltid opprinnelse, lisensiering og kjente sårbarheter.
- **Oppretthold sikre deploy-pipelines:** Bruk automatiserte CI/CD-pipelines med integrert sikkerhetsskanning for å fange opp problemer tidlig. Sørg for at kun betrodde artefakter distribueres til produksjon.
- **Kontinuerlig overvåking og revisjon:** Implementer løpende overvåking for alle avhengigheter, inkludert modeller og datatjenester, for å oppdage nye sårbarheter eller leverandørkjede-angrep.
- **Bruk minste privilegium og tilgangskontroller:** Begrens tilgang til modeller, data og tjenester til kun det som er nødvendig for at MCP-serveren skal fungere.
- **Rask respons på trusler:** Ha en prosess for å patche eller erstatte kompromitterte komponenter, og for å rotere hemmeligheter eller legitimasjon hvis et brudd oppdages.

[GitHub Advanced Security](https://github.com/security/advanced-security) tilbyr funksjoner som hemmelighetsskanning, avhengighetsskanning og CodeQL-analyse. Disse verktøyene integreres med [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) og [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) for å hjelpe team med å identifisere og redusere sårbarheter både i kode og AI-leverandørkjede-komponenter.

Microsoft implementerer også omfattende leverandørkjede-sikkerhetspraksis internt for alle produkter. Les mer i [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Etablerte sikkerhetsprinsipper som vil styrke sikkerhetsnivået i din MCP-implementering

Enhver MCP-implementering arver den eksisterende sikkerhetsposisjonen til organisasjonens miljø den er bygget på, så når du vurderer sikkerheten til MCP som en del av dine AI-systemer, anbefales det å heve det overordnede sikkerhetsnivået. Følgende etablerte sikkerhetskontroller er spesielt relevante:

- Sikker koding i AI-applikasjonen din – beskytt mot [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 
- [OWASP Topp 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Reisen for å sikre programvareleverandørkjeden hos Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Sikker minste privilegert tilgang (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Beste praksis for tokenvalidering og levetid](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Bruk sikker tokenlagring og krypter tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management som autentiseringsgateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Bruke Microsoft Entra ID for å autentisere med MCP-servere](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Neste

Neste: [Kapittel 3: Komme i gang](/03-GettingStarted/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på dets opprinnelige språk bør betraktes som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.