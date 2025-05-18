<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-17T07:35:46+00:00",
  "source_file": "02-Security/readme.md",
  "language_code": "no"
}
-->
# Sikkerhetsbestepraksis

Å ta i bruk Model Context Protocol (MCP) gir kraftige nye muligheter for AI-drevne applikasjoner, men introduserer også unike sikkerhetsutfordringer som går utover tradisjonelle programvarerisikoer. I tillegg til etablerte bekymringer som sikker koding, minst privilegium og forsyningskjede sikkerhet, står MCP og AI-arbeidsbelastninger overfor nye trusler som promptinjeksjon, verktøyforgiftning og dynamisk verktøyendring. Disse risikoene kan føre til datalekkasjer, personvernbrudd og utilsiktet systematferd hvis de ikke håndteres riktig.

Denne leksjonen utforsker de mest relevante sikkerhetsrisikoene knyttet til MCP—inkludert autentisering, autorisasjon, overdrevne tillatelser, indirekte promptinjeksjon og forsyningskjede sårbarheter—og gir handlingsrettede kontroller og bestepraksis for å redusere dem. Du vil også lære hvordan du kan utnytte Microsoft-løsninger som Prompt Shields, Azure Content Safety og GitHub Advanced Security for å styrke din MCP-implementering. Ved å forstå og anvende disse kontrollene kan du betydelig redusere sannsynligheten for et sikkerhetsbrudd og sikre at AI-systemene dine forblir robuste og pålitelige.

# Læringsmål

Ved slutten av denne leksjonen vil du kunne:

- Identifisere og forklare de unike sikkerhetsrisikoene som introduseres av Model Context Protocol (MCP), inkludert promptinjeksjon, verktøyforgiftning, overdrevne tillatelser og forsyningskjede sårbarheter.
- Beskrive og anvende effektive kontroller for å redusere MCP-sikkerhetsrisikoer, som robust autentisering, minst privilegium, sikker tokenhåndtering og forsyningskjede verifisering.
- Forstå og utnytte Microsoft-løsninger som Prompt Shields, Azure Content Safety og GitHub Advanced Security for å beskytte MCP og AI-arbeidsbelastninger.
- Gjenkjenne viktigheten av å validere verktøymetadata, overvåke for dynamiske endringer og forsvare mot indirekte promptinjeksjonsangrep.
- Integrere etablerte sikkerhetsbestepraksiser—som sikker koding, serverherding og null tillit arkitektur—inn i din MCP-implementering for å redusere sannsynligheten og virkningen av sikkerhetsbrudd.

# MCP sikkerhetskontroller

Ethvert system som har tilgang til viktige ressurser har impliserte sikkerhetsutfordringer. Sikkerhetsutfordringer kan generelt adresseres gjennom korrekt anvendelse av grunnleggende sikkerhetskontroller og konsepter. Siden MCP er nylig definert, endrer spesifikasjonen seg veldig raskt og etter hvert som protokollen utvikler seg. Til slutt vil sikkerhetskontrollene i den modnes, noe som muliggjør en bedre integrasjon med virksomhetens og etablerte sikkerhetsarkitekturer og bestepraksiser.

Forskning publisert i [Microsoft Digital Defense Report](https://aka.ms/mddr) sier at 98% av rapporterte brudd ville bli forhindret av robust sikkerhetshygiene, og den beste beskyttelsen mot enhver form for brudd er å få din grunnleggende sikkerhetshygiene, sikker koding bestepraksis og forsyningskjede sikkerhet riktig—de prøvde og testede praksisene som vi allerede vet om har fortsatt størst innvirkning på å redusere sikkerhetsrisikoen.

La oss se på noen av måtene du kan begynne å adressere sikkerhetsrisikoer når du tar i bruk MCP.

# MCP serverautentisering (hvis din MCP-implementering var før 26. april 2025)

> **Note:** Følgende informasjon er korrekt per 26. april 2025. MCP-protokollen utvikler seg kontinuerlig, og fremtidige implementeringer kan introdusere nye autentiseringsmønstre og kontroller. For de nyeste oppdateringene og veiledningen, henvis alltid til [MCP Specification](https://spec.modelcontextprotocol.io/) og den offisielle [MCP GitHub repository](https://github.com/modelcontextprotocol).

### Problemstilling 
Den opprinnelige MCP-spesifikasjonen antok at utviklere ville skrive sin egen autentiseringsserver. Dette krevde kunnskap om OAuth og relaterte sikkerhetsbegrensninger. MCP-servere fungerte som OAuth 2.0 Autorisasjonsservere, som administrerte nødvendig brukerautentisering direkte i stedet for å delegere det til en ekstern tjeneste som Microsoft Entra ID. Fra 26. april 2025 tillater en oppdatering av MCP-spesifikasjonen MCP-servere å delegere brukerautentisering til en ekstern tjeneste.

### Risikoer
- Feilkonfigurert autorisasjonslogikk i MCP-serveren kan føre til eksponering av sensitive data og feilaktig anvendte tilgangskontroller.
- OAuth-token tyveri på den lokale MCP-serveren. Hvis stjålet, kan tokenet deretter brukes til å utgi seg for MCP-serveren og få tilgang til ressurser og data fra tjenesten som OAuth-tokenet er for.

### Reduserende kontroller
- **Gjennomgå og styrke autorisasjonslogikk:** Gjør en nøye revisjon av MCP-serverens autorisasjonsimplementering for å sikre at bare tiltenkte brukere og klienter kan få tilgang til sensitive ressurser. For praktisk veiledning, se [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) og [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Tving sikre tokenpraksiser:** Følg [Microsofts beste praksiser for tokenvalidering og levetid](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) for å forhindre misbruk av tilgangstokens og redusere risikoen for token replay eller tyveri.
- **Beskytt tokenlagring:** Lagre alltid tokens sikkert og bruk kryptering for å beskytte dem ved hvile og i transitt. For implementeringstips, se [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Overdrevne tillatelser for MCP-servere

### Problemstilling
MCP-servere kan ha blitt gitt overdrevne tillatelser til tjenesten/ressursen de får tilgang til. For eksempel, en MCP-server som er en del av en AI-salgsapplikasjon som kobler til et virksomhetsdatastore bør ha tilgang begrenset til salgsdataene og ikke tillates å få tilgang til alle filene i lagringen. Med referanse tilbake til prinsippet om minst privilegium (en av de eldste sikkerhetsprinsippene), bør ingen ressurs ha tillatelser som overstiger hva som er nødvendig for at den skal utføre de oppgavene den var ment for. AI presenterer en økt utfordring på dette området fordi for å gjøre det fleksibelt kan det være utfordrende å definere de eksakte tillatelsene som kreves.

### Risikoer 
- Å gi overdrevne tillatelser kan tillate datalekkasjer eller endring av data som MCP-serveren ikke var ment å kunne få tilgang til. Dette kan også være et personvernproblem hvis dataene er personlig identifiserbar informasjon (PII).

### Reduserende kontroller
- **Anvend prinsippet om minst privilegium:** Gi MCP-serveren bare de nødvendige tillatelsene for å utføre de nødvendige oppgavene. Gjennomgå og oppdater disse tillatelsene regelmessig for å sikre at de ikke overstiger det som trengs. For detaljert veiledning, se [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Bruk rollebasert tilgangskontroll (RBAC):** Tildel roller til MCP-serveren som er stramt begrenset til spesifikke ressurser og handlinger, unngå brede eller unødvendige tillatelser.
- **Overvåk og revider tillatelser:** Kontinuerlig overvåk tillatelsesbruk og revider tilgangslogger for å oppdage og rette overdrevne eller ubrukte privilegier raskt.

# Indirekte promptinjeksjonsangrep

### Problemstilling

Ondsinnede eller kompromitterte MCP-servere kan introdusere betydelige risikoer ved å eksponere kundedata eller tillate utilsiktede handlinger. Disse risikoene er spesielt relevante i AI- og MCP-baserte arbeidsbelastninger, hvor:

- **Promptinjeksjonsangrep**: Angripere innebygger ondsinnede instruksjoner i prompts eller ekstern innhold, som får AI-systemet til å utføre utilsiktede handlinger eller lekke sensitive data. Lær mer: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Verktøyforgiftning**: Angripere manipulerer verktøymetadata (som beskrivelser eller parametere) for å påvirke AI-ens oppførsel, potensielt omgå sikkerhetskontroller eller eksfiltrere data. Detaljer: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection**: Ondsinnede instruksjoner er innebygd i dokumenter, nettsider eller e-poster, som deretter behandles av AI, som fører til datalekkasjer eller manipulasjon.
- **Dynamisk verktøyendring (Rug Pulls)**: Verktøydefinisjoner kan endres etter brukerens godkjenning, og introdusere nye ondsinnede oppførsler uten brukerens bevissthet.

Disse sårbarhetene fremhever behovet for robust validering, overvåking og sikkerhetskontroller når du integrerer MCP-servere og verktøy i ditt miljø. For en dypere forståelse, se de lenkede referansene ovenfor.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.4b2f1af239a32d46221a75c7bc5b6f392ebbacc47eccde241d4c60507232fa43.no.png)

**Indirekte promptinjeksjon** (også kjent som cross-domain prompt injection eller XPIA) er en kritisk sårbarhet i generative AI-systemer, inkludert de som bruker Model Context Protocol (MCP). I dette angrepet er ondsinnede instruksjoner skjult innenfor eksternt innhold—som dokumenter, nettsider eller e-poster. Når AI-systemet behandler dette innholdet, kan det tolke de innebygde instruksjonene som legitime brukerkommandoer, som resulterer i utilsiktede handlinger som datalekkasjer, generering av skadelig innhold eller manipulering av brukerinteraksjoner. For en detaljert forklaring og virkelige eksempler, se [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

En spesielt farlig form for dette angrepet er **Verktøyforgiftning**. Her injiserer angripere ondsinnede instruksjoner i metadataene til MCP-verktøy (som verktøybeskrivelser eller parametere). Siden store språkmodeller (LLMs) stoler på disse metadataene for å bestemme hvilke verktøy som skal brukes, kan kompromitterte beskrivelser lure modellen til å utføre uautoriserte verktøykall eller omgå sikkerhetskontroller. Disse manipulasjonene er ofte usynlige for sluttbrukere, men kan tolkes og handles på av AI-systemet. Denne risikoen er økt i hostede MCP-servermiljøer, hvor verktøydefinisjoner kan oppdateres etter brukerens godkjenning—et scenario noen ganger referert til som en "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". I slike tilfeller kan et verktøy som tidligere var trygt senere bli modifisert for å utføre ondsinnede handlinger, som å eksfiltrere data eller endre systematferd, uten brukerens kunnskap. For mer om denne angrepsvektoren, se [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.d4607023f69e16157954001ad81afd763676361f03db0a1cf24ec696b2ddcb88.no.png)

## Risikoer
Utilsiktede AI-handlinger utgjør en rekke sikkerhetsrisikoer som inkluderer datalekkasjer og personvernbrudd.

### Reduserende kontroller
### Bruke prompt shields for å beskytte mot indirekte promptinjeksjonsangrep
-----------------------------------------------------------------------------

**AI Prompt Shields** er en løsning utviklet av Microsoft for å forsvare mot både direkte og indirekte promptinjeksjonsangrep. De hjelper gjennom:

1.  **Deteksjon og filtrering**: Prompt Shields bruker avanserte maskinlæringsalgoritmer og naturlig språkbehandling for å oppdage og filtrere ut ondsinnede instruksjoner innebygd i eksternt innhold, som dokumenter, nettsider eller e-poster.
    
2.  **Spotlighting**: Denne teknikken hjelper AI-systemet med å skille mellom gyldige systeminstruksjoner og potensielt upålitelige eksterne innganger. Ved å transformere inngangsteksten på en måte som gjør den mer relevant for modellen, sikrer Spotlighting at AI bedre kan identifisere og ignorere ondsinnede instruksjoner.
    
3.  **Avgrensere og datamarkering**: Inkludering av avgrensere i systemmeldingen skisserer eksplisitt plasseringen av inngangsteksten, som hjelper AI-systemet med å gjenkjenne og skille brukerinnganger fra potensielt skadelig eksternt innhold. Datamarkering utvider dette konseptet ved å bruke spesielle markører for å fremheve grensene mellom pålitelig og upålitelig data.
    
4.  **Kontinuerlig overvåking og oppdateringer**: Microsoft overvåker og oppdaterer kontinuerlig Prompt Shields for å adressere nye og utviklende trusler. Denne proaktive tilnærmingen sikrer at forsvarene forblir effektive mot de nyeste angrepsteknikkene.
    
5. **Integrasjon med Azure Content Safety:** Prompt Shields er en del av den bredere Azure AI Content Safety-pakken, som gir ekstra verktøy for å oppdage forsøk på å bryte seg ut, skadelig innhold og andre sikkerhetsrisikoer i AI-applikasjoner.

Du kan lese mer om AI prompt shields i [Prompt Shields dokumentasjon](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.a4dba28a04ea42d28053f233585290d4862b244ca1e59b8ff695c5530e1bba66.no.png)

### Forsyningskjede sikkerhet

Forsyningskjede sikkerhet forblir grunnleggende i AI-tiden, men omfanget av hva som utgjør din forsyningskjede har utvidet seg. I tillegg til tradisjonelle kodepakker, må du nå grundig verifisere og overvåke alle AI-relaterte komponenter, inkludert grunnlagsmodeller, embeddings-tjenester, kontekstleverandører og tredjeparts API-er. Hver av disse kan introdusere sårbarheter eller risikoer hvis de ikke håndteres riktig.

**Nøkkelpraksis for forsyningskjede sikkerhet for AI og MCP:**
- **Verifiser alle komponenter før integrering:** Dette inkluderer ikke bare åpne kildekodebiblioteker, men også AI-modeller, datakilder og eksterne API-er. Sjekk alltid for opprinnelse, lisensiering og kjente sårbarheter.
- **Oppretthold sikre distribusjonspipelines:** Bruk automatiserte CI/CD-pipelines med integrert sikkerhetsskanning for å fange problemer tidlig. Sørg for at bare pålitelige artefakter distribueres til produksjon.
- **Kontinuerlig overvåking og revisjon:** Implementer kontinuerlig overvåking for alle avhengigheter, inkludert modeller og datatjenester, for å oppdage nye sårbarheter eller forsyningskjedeangrep.
- **Anvend minst privilegium og tilgangskontroller:** Begrens tilgang til modeller, data og tjenester til bare det som er nødvendig for at din MCP-server skal fungere.
- **Reager raskt på trusler:** Ha en prosess på plass for å patch eller erstatte kompromitterte komponenter, og for å rotere hemmeligheter eller legitimasjon hvis et brudd oppdages.

[GitHub Advanced Security](https://github.com/security/advanced-security) gir funksjoner som hemmelighetsskanning, avhengighetsskanning og CodeQL-analyse. Disse verktøyene integreres med [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) og [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) for å hjelpe team med å identifisere og redusere sårbarheter på tvers av både kode og AI-forsyningskjede komponenter.

Microsoft implementerer også omfattende forsyningskjede sikkerhetspraksiser internt for alle produkter. Lær mer i [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Etablerte sikkerhetsbestepraksiser som vil styrke sikkerhetsposisjonen til din MCP-implementering

Enhver MCP-implementering arver den eksisterende sikkerhetsposisjonen til organisasjonens miljø som den er bygget på, så når du vurderer sikkerheten til MCP som en komponent av dine samlede AI-systemer anbefales det at du ser på å styrke din totale eksisterende
- [OWASP Topp 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Avansert Sikkerhet](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Reisen for å sikre programvareforsyningskjeden hos Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Sikre minst privilegert tilgang (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Beste praksis for tokenvalidering og levetid](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Bruk sikker tokenlagring og krypter tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management som autentiseringsgateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Bruke Microsoft Entra ID for å autentisere med MCP-servere](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Neste

Neste: [Kapittel 3: Komme i gang](/03-GettingStarted/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiserte oversettelser kan inneholde feil eller unøyaktigheter. Det originale dokumentet på sitt opprinnelige språk bør anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.