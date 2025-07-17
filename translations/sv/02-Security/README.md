<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "382fddb4ee4d9c1bdc806e2ee99b70c8",
  "translation_date": "2025-07-17T06:19:32+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "sv"
}
-->
# Säkerhetsbästa praxis

Att använda Model Context Protocol (MCP) ger kraftfulla nya möjligheter för AI-drivna applikationer, men medför också unika säkerhetsutmaningar som går bortom traditionella mjukvarurisker. Utöver etablerade frågor som säker kodning, minsta privilegium och leverantörskedjesäkerhet, möter MCP och AI-arbetsbelastningar nya hot som promptinjektion, verktygsförgiftning, dynamisk verktygsmodifiering, sessionskapning, confused deputy-attacker och token passthrough-sårbarheter. Dessa risker kan leda till dataläckage, integritetsbrott och oavsiktligt systembeteende om de inte hanteras korrekt.

Den här lektionen utforskar de mest relevanta säkerhetsriskerna kopplade till MCP—inklusive autentisering, auktorisering, överdrivna behörigheter, indirekt promptinjektion, sessionssäkerhet, confused deputy-problem, token passthrough-sårbarheter och leverantörskedjesårbarheter—och ger praktiska kontroller och bästa praxis för att minska dem. Du kommer också att lära dig hur du kan använda Microsoft-lösningar som Prompt Shields, Azure Content Safety och GitHub Advanced Security för att stärka din MCP-implementering. Genom att förstå och tillämpa dessa kontroller kan du avsevärt minska risken för säkerhetsintrång och säkerställa att dina AI-system förblir robusta och pålitliga.

# Lärandemål

I slutet av denna lektion ska du kunna:

- Identifiera och förklara de unika säkerhetsrisker som Model Context Protocol (MCP) medför, inklusive promptinjektion, verktygsförgiftning, överdrivna behörigheter, sessionskapning, confused deputy-problem, token passthrough-sårbarheter och leverantörskedjesårbarheter.
- Beskriva och tillämpa effektiva åtgärder för att mildra MCP:s säkerhetsrisker, såsom robust autentisering, minsta privilegium, säker tokenhantering, sessionssäkerhetskontroller och verifiering av leverantörskedjan.
- Förstå och använda Microsoft-lösningar som Prompt Shields, Azure Content Safety och GitHub Advanced Security för att skydda MCP och AI-arbetsbelastningar.
- Känna igen vikten av att validera verktygsmetadata, övervaka dynamiska förändringar, försvara mot indirekta promptinjektionsattacker och förhindra sessionskapning.
- Integrera etablerade säkerhetsbästa praxis—såsom säker kodning, serverhärdning och zero trust-arkitektur—i din MCP-implementering för att minska sannolikheten och effekten av säkerhetsintrång.

# MCP säkerhetskontroller

Alla system som har tillgång till viktiga resurser har underliggande säkerhetsutmaningar. Säkerhetsutmaningar kan i allmänhet hanteras genom korrekt tillämpning av grundläggande säkerhetskontroller och koncept. Eftersom MCP är nydefinierat förändras specifikationen mycket snabbt i takt med att protokollet utvecklas. Så småningom kommer säkerhetskontrollerna inom MCP att mogna, vilket möjliggör bättre integration med företags- och etablerade säkerhetsarkitekturer och bästa praxis.

Forskning publicerad i [Microsoft Digital Defense Report](https://aka.ms/mddr) visar att 98 % av rapporterade intrång skulle kunna förhindras med robust säkerhetshygien, och det bästa skyddet mot alla typer av intrång är att ha grundläggande säkerhetshygien, säker kodningspraxis och leverantörskedjesäkerhet på plats — de beprövade metoder vi redan känner till har fortfarande störst effekt för att minska säkerhetsrisker.

Låt oss titta på några sätt du kan börja hantera säkerhetsrisker när du använder MCP.

> **Note:** Följande information är korrekt per **29 maj 2025**. MCP-protokollet utvecklas kontinuerligt, och framtida implementationer kan introducera nya autentiseringsmönster och kontroller. För de senaste uppdateringarna och riktlinjerna, se alltid [MCP Specification](https://spec.modelcontextprotocol.io/) samt den officiella [MCP GitHub-repositorien](https://github.com/modelcontextprotocol) och [sidan för säkerhetsbästa praxis](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Problemformulering  
Den ursprungliga MCP-specifikationen antog att utvecklare skulle skriva sin egen autentiseringsserver. Detta krävde kunskap om OAuth och relaterade säkerhetsbegränsningar. MCP-servrar agerade som OAuth 2.0 Authorization Servers och hanterade den nödvändiga användarautentiseringen direkt istället för att delegera den till en extern tjänst som Microsoft Entra ID. Från och med **26 april 2025** tillåter en uppdatering av MCP-specifikationen att MCP-servrar kan delegera användarautentisering till en extern tjänst.

### Risker
- Felkonfigurerad auktoriseringslogik i MCP-servern kan leda till exponering av känslig data och felaktigt tillämpade åtkomstkontroller.
- Stöld av OAuth-token på den lokala MCP-servern. Om token stjäls kan den användas för att utge sig för MCP-servern och få tillgång till resurser och data från tjänsten som OAuth-token gäller för.

#### Token Passthrough
Token passthrough är uttryckligen förbjudet i auktoriseringsspecifikationen eftersom det medför flera säkerhetsrisker, bland annat:

#### Omgång av säkerhetskontroller
MCP-servern eller nedströms-API:er kan implementera viktiga säkerhetskontroller som rate limiting, förfrågningsvalidering eller trafikövervakning, vilka är beroende av token-målgrupp eller andra autentiseringsbegränsningar. Om klienter kan erhålla och använda tokens direkt mot nedströms-API:er utan att MCP-servern validerar dem korrekt eller säkerställer att token är utfärdade för rätt tjänst, kringgår de dessa kontroller.

#### Ansvars- och revisionsspårproblem
MCP-servern kan inte identifiera eller skilja mellan MCP-klienter när klienter anropar med en upstream-utfärdad access-token som kan vara ogenomskinlig för MCP-servern.  
Nedströmsresursserverns loggar kan visa förfrågningar som verkar komma från en annan källa med en annan identitet, snarare än från MCP-servern som faktiskt vidarebefordrar token.  
Båda faktorerna försvårar incidentutredning, kontroller och revision.  
Om MCP-servern vidarebefordrar tokens utan att validera deras påståenden (t.ex. roller, privilegier eller målgrupp) eller annan metadata, kan en illasinnad aktör med en stulen token använda servern som en proxy för dataläckage.

#### Problem med förtroendegränser
Nedströmsresursservern ger förtroende till specifika enheter. Detta förtroende kan inkludera antaganden om ursprung eller klientbeteendemönster. Att bryta denna förtroendegräns kan leda till oväntade problem.  
Om token accepteras av flera tjänster utan korrekt validering kan en angripare som komprometterar en tjänst använda token för att få tillgång till andra anslutna tjänster.

#### Risk för framtida kompatibilitet
Även om en MCP-server idag börjar som en "ren proxy" kan den behöva lägga till säkerhetskontroller senare. Att från början ha korrekt separation av token-målgrupp gör det enklare att utveckla säkerhetsmodellen.

### Åtgärder för att mildra risker

**MCP-servrar FÅR INTE acceptera några tokens som inte uttryckligen är utfärdade för MCP-servern**

- **Granska och förstärk auktoriseringslogiken:** Granska noggrant din MCP-servers auktoriseringsimplementering för att säkerställa att endast avsedda användare och klienter kan få tillgång till känsliga resurser. För praktisk vägledning, se [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) och [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Tillämpa säkra tokenrutiner:** Följ [Microsofts bästa praxis för tokenvalidering och livslängd](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) för att förhindra missbruk av access-tokens och minska risken för tokenåteranvändning eller stöld.
- **Skydda tokenlagring:** Spara alltid tokens säkert och använd kryptering för att skydda dem i vila och under överföring. För implementeringstips, se [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Överdrivna behörigheter för MCP-servrar

### Problemformulering  
MCP-servrar kan ha tilldelats överdrivna behörigheter till tjänsten/resursen de får åtkomst till. Till exempel bör en MCP-server som är en del av en AI-försäljningsapplikation som ansluter till ett företagsdatabutik ha åtkomst begränsad till försäljningsdata och inte tillåtas komma åt alla filer i butiken. Med hänvisning till principen om minsta privilegium (en av de äldsta säkerhetsprinciperna) bör ingen resurs ha behörigheter som överstiger vad som krävs för att utföra de uppgifter den är avsedd för. AI utgör en ökad utmaning i detta område eftersom flexibiliteten gör det svårt att exakt definiera vilka behörigheter som krävs.

### Risker  
- Att ge överdrivna behörigheter kan möjliggöra dataläckage eller ändring av data som MCP-servern inte var avsedd att få åtkomst till. Detta kan också vara ett integritetsproblem om datan innehåller personuppgifter (PII).

### Åtgärder för att mildra risker  
- **Tillämpa principen om minsta privilegium:** Ge MCP-servern endast de minimala behörigheter som krävs för att utföra sina uppgifter. Granska och uppdatera dessa behörigheter regelbundet för att säkerställa att de inte överstiger vad som behövs. För detaljerad vägledning, se [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Använd rollbaserad åtkomstkontroll (RBAC):** Tilldela roller till MCP-servern som är strikt begränsade till specifika resurser och åtgärder, och undvik breda eller onödiga behörigheter.
- **Övervaka och granska behörigheter:** Övervaka kontinuerligt användningen av behörigheter och granska åtkomstloggar för att snabbt upptäcka och åtgärda överdrivna eller oanvända privilegier.

# Indirekta promptinjektionsattacker

### Problemformulering

Illasinnade eller komprometterade MCP-servrar kan medföra betydande risker genom att exponera kunddata eller möjliggöra oavsiktliga åtgärder. Dessa risker är särskilt relevanta i AI- och MCP-baserade arbetsbelastningar, där:

- **Prompt Injection Attacker:** Angripare bäddar in skadliga instruktioner i prompts eller externt innehåll, vilket får AI-systemet att utföra oavsiktliga handlingar eller läcka känslig data. Läs mer: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning:** Angripare manipulerar verktygsmetadata (såsom beskrivningar eller parametrar) för att påverka AI:ns beteende, potentiellt kringgå säkerhetskontroller eller läcka data. Detaljer: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection:** Skadliga instruktioner bäddas in i dokument, webbsidor eller e-post som sedan bearbetas av AI, vilket leder till dataläckage eller manipulation.
- **Dynamisk verktygsmodifiering (Rug Pulls):** Verktygsdefinitioner kan ändras efter användarens godkännande, vilket introducerar nya skadliga beteenden utan användarens vetskap.

Dessa sårbarheter understryker behovet av robust validering, övervakning och säkerhetskontroller när MCP-servrar och verktyg integreras i din miljö. För en djupare genomgång, se de länkade referenserna ovan.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.sv.png)

**Indirekt promptinjektion** (även kallad cross-domain prompt injection eller XPIA) är en kritisk sårbarhet i generativa AI-system, inklusive de som använder Model Context Protocol (MCP). Vid denna attack göms skadliga instruktioner i externt innehåll—såsom dokument, webbsidor eller e-post. När AI-systemet bearbetar detta innehåll kan det tolka de inbäddade instruktionerna som legitima användarkommandon, vilket resulterar i oavsiktliga handlingar som dataläckage, generering av skadligt innehåll eller manipulation av användarinteraktioner. För en detaljerad förklaring och verkliga exempel, se [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

En särskilt farlig form av denna attack är **Tool Poisoning**. Här injicerar angripare skadliga instruktioner i metadata för MCP-verktyg (såsom verktygsbeskrivningar eller parametrar). Eftersom stora språkmodeller (LLM) förlitar sig på denna metadata för att avgöra vilka verktyg som ska anropas, kan komprometterade beskrivningar lura modellen att utföra obehöriga verktygsanrop eller kringgå säkerhetskontroller. Dessa manipulationer är ofta osynliga för slutanvändare men kan tolkas och ageras på av AI-systemet. Denna risk ökar i hostade MCP-servermiljöer, där verktygsdefinitioner kan uppdateras efter användarens godkännande—ett scenario som ibland kallas en "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". I sådana fall kan ett verktyg som tidigare var säkert senare modifieras för att utföra skadliga handlingar, såsom dataläckage eller ändring av systembeteende, utan användarens vetskap. För mer om denna attackvektor, se [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.sv.png)

## Risker  
Oavsiktliga AI-handlingar medför en rad säkerhetsrisker som inkluderar dataläckage och integritetsbrott.

### Åtgärder för att mildra risker  
### Använda prompt shields för att skydda mot indirekta promptinjektionsattacker
-----------------------------------------------------------------------------

**AI Prompt Shields** är en lösning utvecklad av Microsoft för att försvara mot både direkta och indirekta promptinjektionsattacker. De hjälper genom:

1.  **Detektion och filtrering:** Prompt Shields använder avancerade maskininlärningsalgoritmer och naturlig språkbehandling för att upptäcka och filtrera bort skadliga instruktioner inbäddade i externt innehåll, såsom dokument, webbsidor eller e-post.
    
2.  **Spotlighting:** Denna teknik hjälper AI-systemet att skilja mellan giltiga systeminstruktioner och potentiellt opålitliga externa indata. Genom att transformera inmatningstexten på ett sätt som gör den mer relevant för modellen säkerställer Spotlighting att AI:n bättre kan identifiera och ignorera skadliga instruktioner.
    
3.  **Avgränsare och datamärkning:** Att inkludera avgränsare i systemmeddelandet tydliggör var inmatningstexten finns, vilket hjälper AI-systemet att känna igen och separera användarindata från potentiellt skadligt externt innehåll. Datamärkning utökar detta koncept genom att använda speciella markörer för att framhäva gränserna mellan betrodda och obetrodda data.
    
4.  **Kontinuerlig övervakning och uppdateringar:** Microsoft övervakar och uppdaterar kontinuerligt Prompt Shields för att hantera nya och föränderliga hot. Detta proaktiva tillvägagångssätt säkerställer att försvaren förblir effektiva mot de senaste attackteknikerna.
    
5. **Integration med Azure Content Safety:** Prompt Shields ingår i den bredare Azure AI Content Safety-sviten, som erbjuder ytterligare verktyg för att upptäcka jailbreak-försök, skadligt innehåll och andra säkerhetsrisker i AI-applikationer.

Du kan läsa mer om AI prompt shields i [Prompt Shields-dokumentationen](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.sv.png)

# Confused Deputy-problemet

### Problemformulering
Problemet med confused deputy är en säkerhetssårbarhet som uppstår när en MCP-server agerar som en proxy mellan MCP-klienter och tredjeparts-API:er. Denna sårbarhet kan utnyttjas när MCP-servern använder ett statiskt klient-ID för att autentisera sig mot en tredjepartsauktoriseringsserver som saknar stöd för dynamisk klientregistrering.

### Risker

- **Cookie-baserad samtyckesomgåelse**: Om en användare tidigare har autentiserats via MCP-proxyservern kan en tredjepartsauktoriseringsserver sätta en samtyckes-cookie i användarens webbläsare. En angripare kan senare utnyttja detta genom att skicka en skadlig länk till användaren med en manipulerad auktoriseringsförfrågan som innehåller en skadlig omdirigerings-URI.
- **Stöld av auktoriseringskod**: När användaren klickar på den skadliga länken kan tredjepartsauktoriseringsservern hoppa över samtyckesskärmen på grund av den befintliga cookien, och auktoriseringskoden kan omdirigeras till angriparens server.
- **Obehörig API-åtkomst**: Angriparen kan byta den stulna auktoriseringskoden mot åtkomsttoken och utge sig för att vara användaren för att få tillgång till tredjeparts-API:et utan uttryckligt godkännande.

### Åtgärder för att minska risker

- **Krav på uttryckligt samtycke**: MCP-proxyservrar som använder statiska klient-ID:n **MÅSTE** inhämta användarens samtycke för varje dynamiskt registrerad klient innan de vidarebefordrar till tredjepartsauktoriseringsservrar.
- **Korrekt OAuth-implementering**: Följ OAuth 2.1:s säkerhetsbästa praxis, inklusive användning av kodutmaningar (PKCE) för auktoriseringsförfrågningar för att förhindra avlyssningsattacker.
- **Klientvalidering**: Implementera strikt validering av omdirigerings-URI:er och klientidentifierare för att förhindra utnyttjande av illvilliga aktörer.


# Token Passthrough-sårbarheter

### Problembeskrivning

"Token passthrough" är ett anti-mönster där en MCP-server accepterar token från en MCP-klient utan att validera att token faktiskt utfärdats till MCP-servern själv, och sedan "passerar vidare" dessa till nedströms-API:er. Denna praxis bryter uttryckligen mot MCP:s auktoriseringsspecifikation och medför allvarliga säkerhetsrisker.

### Risker

- **Omgång av säkerhetskontroller**: Klienter kan kringgå viktiga säkerhetskontroller som hastighetsbegränsning, förfrågningsvalidering eller trafikövervakning om de kan använda token direkt mot nedströms-API:er utan korrekt validering.
- **Ansvars- och revisionsproblem**: MCP-servern kommer inte kunna identifiera eller skilja mellan MCP-klienter när klienter använder åtkomsttoken utfärdade uppströms, vilket försvårar incidentutredning och revision.
- **Dataexfiltrering**: Om token vidarebefordras utan korrekt validering av claims kan en illvillig aktör med en stulen token använda servern som proxy för dataexfiltrering.
- **Brott mot förtroendegränser**: Nedströmsresurser kan ge förtroende till specifika enheter baserat på antaganden om ursprung eller beteendemönster. Att bryta denna förtroendegräns kan leda till oväntade säkerhetsproblem.
- **Missbruk av token i flera tjänster**: Om token accepteras av flera tjänster utan korrekt validering kan en angripare som komprometterar en tjänst använda token för att få tillgång till andra anslutna tjänster.

### Åtgärder för att minska risker

- **Tokenvalidering**: MCP-servrar **FÅR INTE** acceptera token som inte uttryckligen utfärdats för MCP-servern själv.
- **Verifiering av målgrupp**: Validera alltid att token har rätt audience-claim som matchar MCP-serverns identitet.
- **Korrekt hantering av tokenlivscykel**: Implementera kortlivade åtkomsttoken och korrekt rotation av token för att minska risken för tokenstöld och missbruk.


# Sessionkapning

### Problembeskrivning

Sessionkapning är en attack där en klient tilldelas ett sessions-ID av servern, och en obehörig part får tag på och använder samma sessions-ID för att utge sig för att vara den ursprungliga klienten och utföra obehöriga åtgärder å dennes vägnar. Detta är särskilt oroande i stateful HTTP-servrar som hanterar MCP-förfrågningar.

### Risker

- **Sessionkapnings-promptinjektion**: En angripare som får tag på ett sessions-ID kan skicka skadliga händelser till en server som delar sessionsstatus med servern klienten är ansluten till, vilket potentiellt kan utlösa skadliga åtgärder eller ge åtkomst till känslig data.
- **Sessionkapnings-imitation**: En angripare med ett stulet sessions-ID kan göra anrop direkt till MCP-servern, kringgå autentisering och behandlas som den legitima användaren.
- **Komprometterade återupptagbara strömmar**: När en server stödjer omleverans/återupptagbara strömmar kan en angripare avsluta en förfrågan i förtid, vilket leder till att den återupptas senare av den ursprungliga klienten med potentiellt skadligt innehåll.

### Åtgärder för att minska risker

- **Verifiering av auktorisering**: MCP-servrar som implementerar auktorisering **MÅSTE** verifiera alla inkommande förfrågningar och **FÅR INTE** använda sessioner för autentisering.
- **Säkra sessions-ID:n**: MCP-servrar **MÅSTE** använda säkra, icke-deterministiska sessions-ID:n genererade med säkra slumpgeneratorer. Undvik förutsägbara eller sekventiella identifierare.
- **Användarspecifik sessionsbindning**: MCP-servrar **BÖR** binda sessions-ID:n till användarspecifik information, genom att kombinera sessions-ID med information unik för den auktoriserade användaren (som deras interna användar-ID) i ett format som `
<user_id>:<session_id>`.
- **Sessionsutgång**: Implementera korrekt sessionsutgång och rotation för att begränsa sårbarhetsfönstret om ett sessions-ID komprometteras.
- **Transport-säkerhet**: Använd alltid HTTPS för all kommunikation för att förhindra avlyssning av sessions-ID:n.


# Säkerhet i leverantörskedjan

Säkerhet i leverantörskedjan är fortsatt grundläggande i AI-eran, men omfattningen av vad som räknas som din leverantörskedja har utvidgats. Utöver traditionella kodpaket måste du nu noggrant verifiera och övervaka alla AI-relaterade komponenter, inklusive grundmodeller, embeddings-tjänster, kontextleverantörer och tredjeparts-API:er. Var och en av dessa kan introducera sårbarheter eller risker om de inte hanteras korrekt.

**Viktiga säkerhetspraxis för leverantörskedjan inom AI och MCP:**
- **Verifiera alla komponenter innan integration:** Detta inkluderar inte bara open source-bibliotek utan även AI-modeller, datakällor och externa API:er. Kontrollera alltid ursprung, licenser och kända sårbarheter.
- **Upprätthåll säkra distributionspipelines:** Använd automatiserade CI/CD-pipelines med integrerad säkerhetsskanning för att upptäcka problem tidigt. Säkerställ att endast betrodda artefakter distribueras till produktion.
- **Kontinuerlig övervakning och revision:** Implementera löpande övervakning av alla beroenden, inklusive modeller och datatjänster, för att upptäcka nya sårbarheter eller attacker mot leverantörskedjan.
- **Tillämpa principen om minsta privilegium och åtkomstkontroller:** Begränsa åtkomst till modeller, data och tjänster till endast vad som är nödvändigt för att din MCP-server ska fungera.
- **Snabb respons på hot:** Ha en process för att patcha eller ersätta komprometterade komponenter och för att rotera hemligheter eller autentiseringsuppgifter om en säkerhetsöverträdelse upptäcks.

[GitHub Advanced Security](https://github.com/security/advanced-security) erbjuder funktioner som hemlighetsskanning, beroendeskanning och CodeQL-analys. Dessa verktyg integreras med [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) och [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) för att hjälpa team att identifiera och mildra sårbarheter i både kod och AI-leverantörskedjans komponenter.

Microsoft implementerar också omfattande säkerhetspraxis för leverantörskedjan internt för alla produkter. Läs mer i [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Etablerade säkerhetsbästa praxis som stärker säkerhetsläget för din MCP-implementation

Alla MCP-implementationer ärver den befintliga säkerhetsnivån i din organisations miljö som de byggs på, så när du överväger säkerheten för MCP som en del av dina övergripande AI-system rekommenderas att du stärker din befintliga säkerhetsnivå. Följande etablerade säkerhetskontroller är särskilt relevanta:

- Säker kodning i din AI-applikation – skydda mot [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 för LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), användning av säkra valv för hemligheter och token, implementera end-to-end säker kommunikation mellan alla applikationskomponenter, med mera.
- Serverhärdning – använd MFA där det är möjligt, håll patchar uppdaterade, integrera servern med en tredjepartsidentitetsleverantör för åtkomst, med mera.
- Håll enheter, infrastruktur och applikationer uppdaterade med patchar.
- Säkerhetsövervakning – implementera loggning och övervakning av en AI-applikation (inklusive MCP-klient/servrar) och skicka dessa loggar till en central SIEM för att upptäcka avvikande aktiviteter.
- Zero trust-arkitektur – isolera komponenter via nätverks- och identitetskontroller på ett logiskt sätt för att minimera laterala rörelser om en AI-applikation skulle komprometteras.

# Viktiga slutsatser

- Säkerhetsgrunder är fortsatt avgörande: Säker kodning, minsta privilegium, verifiering av leverantörskedjan och kontinuerlig övervakning är nödvändiga för MCP och AI-arbetsbelastningar.
- MCP medför nya risker – såsom promptinjektion, verktygsförgiftning, sessionkapning, confused deputy-problem, token passthrough-sårbarheter och överdrivna behörigheter – som kräver både traditionella och AI-specifika kontroller.
- Använd robust autentisering, auktorisering och tokenhantering, och utnyttja externa identitetsleverantörer som Microsoft Entra ID där det är möjligt.
- Skydda mot indirekt promptinjektion och verktygsförgiftning genom att validera verktygsmetadata, övervaka dynamiska förändringar och använda lösningar som Microsoft Prompt Shields.
- Implementera säker sessionshantering genom att använda icke-deterministiska sessions-ID:n, binda sessioner till användaridentiteter och aldrig använda sessioner för autentisering.
- Förhindra confused deputy-attacker genom att kräva uttryckligt användarsamtycke för varje dynamiskt registrerad klient och implementera korrekt OAuth-säkerhetspraxis.
- Undvik token passthrough-sårbarheter genom att säkerställa att MCP-servrar endast accepterar token som uttryckligen utfärdats för dem och validerar token-claims korrekt.
- Behandla alla komponenter i din AI-leverantörskedja – inklusive modeller, embeddings och kontextleverantörer – med samma noggrannhet som kodberoenden.
- Håll dig uppdaterad med utvecklingen av MCP-specifikationer och bidra till communityn för att hjälpa till att forma säkra standarder.

# Ytterligare resurser

## Externa resurser
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

## Ytterligare säkerhetsdokument

För mer detaljerad säkerhetsvägledning, se dessa dokument:

- [MCP Security Best Practices 2025](./mcp-security-best-practices-2025.md) – Omfattande lista över säkerhetsbästa praxis för MCP-implementationer
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md) – Implementeringsexempel för integration av Azure Content Safety med MCP-servrar
- [MCP Security Controls 2025](./mcp-security-controls-2025.md) – Senaste säkerhetskontroller och tekniker för att säkra MCP-distributioner
- [MCP Best Practices](./mcp-best-practices.md) – Snabbreferensguide för MCP-säkerhet

### Nästa

Nästa: [Kapitel 3: Komma igång](../03-GettingStarted/README.md)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen observera att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för några missförstånd eller feltolkningar som uppstår vid användning av denna översättning.