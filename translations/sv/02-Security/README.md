<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00aedb7b1d11b7eaacb0618d8791c65",
  "translation_date": "2025-05-29T23:21:48+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "sv"
}
-->
# Security Best Practices

Att använda Model Context Protocol (MCP) ger kraftfulla nya möjligheter för AI-drivna applikationer, men medför också unika säkerhetsutmaningar som går bortom traditionella mjukvarurisker. Utöver etablerade aspekter som säker kodning, minsta privilegium och leverantörskedjesäkerhet, möter MCP och AI-arbetsbelastningar nya hot som promptinjektion, verktygsförgiftning och dynamisk verktygsmodifiering. Dessa risker kan leda till dataläckage, integritetsbrott och oavsiktligt systembeteende om de inte hanteras korrekt.

Denna lektion undersöker de mest relevanta säkerhetsriskerna kopplade till MCP—inklusive autentisering, auktorisation, överdrivna behörigheter, indirekt promptinjektion och leverantörskedjesårbarheter—och erbjuder praktiska kontroller och bästa praxis för att mildra dem. Du kommer även att lära dig hur du kan använda Microsoft-lösningar som Prompt Shields, Azure Content Safety och GitHub Advanced Security för att stärka din MCP-implementering. Genom att förstå och tillämpa dessa kontroller kan du avsevärt minska risken för säkerhetsöverträdelser och säkerställa att dina AI-system förblir robusta och pålitliga.

# Learning Objectives

I slutet av denna lektion ska du kunna:

- Identifiera och förklara de unika säkerhetsrisker som Model Context Protocol (MCP) medför, inklusive promptinjektion, verktygsförgiftning, överdrivna behörigheter och leverantörskedjesårbarheter.
- Beskriva och tillämpa effektiva åtgärder för att mildra MCP:s säkerhetsrisker, såsom robust autentisering, minsta privilegium, säker tokenhantering och verifiering av leverantörskedjan.
- Förstå och använda Microsoft-lösningar som Prompt Shields, Azure Content Safety och GitHub Advanced Security för att skydda MCP och AI-arbetsbelastningar.
- Känna igen vikten av att validera verktygsmetadata, övervaka dynamiska förändringar och försvara mot indirekta promptinjektionsattacker.
- Integrera etablerade säkerhetsbästa praxis—såsom säker kodning, serverhärdning och zero trust-arkitektur—i din MCP-implementering för att minska sannolikheten och effekten av säkerhetsöverträdelser.

# MCP security controls

Alla system som har tillgång till viktiga resurser står inför implicita säkerhetsutmaningar. Säkerhetsutmaningar kan generellt hanteras genom korrekt tillämpning av grundläggande säkerhetskontroller och koncept. Eftersom MCP är nydefinierat förändras specifikationen snabbt i takt med att protokollet utvecklas. Så småningom kommer säkerhetskontrollerna inom MCP att mogna, vilket möjliggör bättre integration med företags- och etablerade säkerhetsarkitekturer och bästa praxis.

Forskning publicerad i [Microsoft Digital Defense Report](https://aka.ms/mddr) visar att 98 % av rapporterade intrång skulle kunna förhindras genom robust säkerhetshygien, och det bästa skyddet mot intrång är att ha en grundläggande säkerhetshygien, säker kodning och leverantörskedjesäkerhet på plats – de beprövade metoder vi redan känner till har störst effekt för att minska säkerhetsrisker.

Låt oss titta på några sätt du kan börja hantera säkerhetsrisker när du adopterar MCP.

> **Note:** Följande information är korrekt per **29 maj 2025**. MCP-protokollet utvecklas kontinuerligt och framtida implementationer kan introducera nya autentiseringsmönster och kontroller. För de senaste uppdateringarna och riktlinjerna, hänvisa alltid till [MCP Specification](https://spec.modelcontextprotocol.io/) och den officiella [MCP GitHub repository](https://github.com/modelcontextprotocol) samt [security best practice page](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Problem statement  
Den ursprungliga MCP-specifikationen antog att utvecklare skulle skriva sin egen autentiseringsserver. Detta krävde kunskap om OAuth och relaterade säkerhetsbegränsningar. MCP-servrar fungerade som OAuth 2.0-auktoriseringsservrar och hanterade användarautentisering direkt istället för att delegera till en extern tjänst som Microsoft Entra ID. Från och med **26 april 2025** tillåter en uppdatering av MCP-specifikationen att MCP-servrar kan delegera användarautentisering till en extern tjänst.

### Risks
- Felkonfigurerad auktoriseringslogik i MCP-servern kan leda till exponering av känslig data och felaktigt tillämpade åtkomstkontroller.
- Stöld av OAuth-token på den lokala MCP-servern. Om token stjäls kan den användas för att utge sig för att vara MCP-servern och få tillgång till resurser och data från tjänsten som OAuth-token är avsedd för.

#### Token Passthrough
Token passthrough är uttryckligen förbjudet i auktoriseringsspecifikationen eftersom det medför flera säkerhetsrisker, bland annat:

#### Security Control Circumvention
MCP-servern eller downstream-API:er kan implementera viktiga säkerhetskontroller som rate limiting, förfrågningsvalidering eller trafikövervakning, vilka är beroende av tokenpubliken eller andra autentiseringsbegränsningar. Om klienter kan erhålla och använda tokens direkt mot downstream-API:er utan att MCP-servern validerar dem korrekt eller säkerställer att tokens är utfärdade för rätt tjänst, kringgår de dessa kontroller.

#### Accountability and Audit Trail Issues
MCP-servern kommer inte kunna identifiera eller särskilja mellan MCP-klienter när klienter anropar med en upstream-utfärdad access token som kan vara ogenomskinlig för MCP-servern.  
Downstream Resource Servers loggar kan visa förfrågningar som ser ut att komma från en annan källa med annan identitet, istället för MCP-servern som faktiskt vidarebefordrar tokens.  
Båda faktorer försvårar incidentutredningar, kontroller och revisioner.  
Om MCP-servern vidarebefordrar tokens utan att validera deras claims (t.ex. roller, privilegier eller publik) eller annan metadata, kan en illasinnad aktör med en stulen token använda servern som en proxy för dataläckage.

#### Trust Boundary Issues
Downstream Resource Server ger förtroende till specifika entiteter. Detta förtroende kan inkludera antaganden om ursprung eller klientbeteendemönster. Att bryta denna förtroendegräns kan leda till oväntade problem.  
Om token accepteras av flera tjänster utan korrekt validering kan en angripare som komprometterar en tjänst använda token för att få tillgång till andra anslutna tjänster.

#### Future Compatibility Risk
Även om en MCP-server idag fungerar som en “ren proxy” kan den behöva lägga till säkerhetskontroller senare. Att börja med korrekt separation av tokenpublik gör det lättare att utveckla säkerhetsmodellen.

### Mitigating controls

**MCP-servrar FÅR INTE acceptera tokens som inte uttryckligen utfärdats för MCP-servern**

- **Granska och förstärk auktoriseringslogiken:** Granska noggrant din MCP-servers auktoriseringsimplementering för att säkerställa att endast avsedda användare och klienter kan få tillgång till känsliga resurser. För praktisk vägledning, se [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) och [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Tillämpa säkra tokenrutiner:** Följ [Microsofts bästa praxis för tokenvalidering och livslängd](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) för att förhindra missbruk av access tokens och minska risken för tokenåteranvändning eller stöld.
- **Skydda tokenlagring:** Spara alltid tokens säkert och använd kryptering för att skydda dem i vila och under överföring. För implementeringstips, se [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Excessive permissions for MCP servers

### Problem statement  
MCP-servrar kan ha tilldelats överdrivna behörigheter till den tjänst eller resurs de ansluter till. Till exempel bör en MCP-server som är en del av en AI-försäljningsapplikation kopplad till en företagsdatabas endast ha åtkomst till försäljningsdata och inte till alla filer i databasen. Med hänvisning till principen om minsta privilegium (en av de äldsta säkerhetsprinciperna) bör inga resurser ha behörigheter som överstiger vad som krävs för att utföra sina uppgifter. AI utgör en ökad utmaning eftersom det kan vara svårt att exakt definiera vilka behörigheter som behövs för flexibilitet.

### Risks  
- Att ge överdrivna behörigheter kan möjliggöra dataläckage eller ändring av data som MCP-servern inte skulle ha åtkomst till. Detta kan också vara ett integritetsproblem om datan är personligt identifierbar information (PII).

### Mitigating controls  
- **Tillämpa principen om minsta privilegium:** Ge MCP-servern endast de minsta behörigheter som krävs för att utföra sina uppgifter. Granska och uppdatera dessa behörigheter regelbundet för att säkerställa att de inte överstiger det som behövs. För detaljerad vägledning, se [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Använd rollbaserad åtkomstkontroll (RBAC):** Tilldela roller till MCP-servern som är strikt begränsade till specifika resurser och åtgärder, och undvik breda eller onödiga behörigheter.
- **Övervaka och revidera behörigheter:** Övervaka kontinuerligt användningen av behörigheter och granska åtkomstloggar för att snabbt upptäcka och åtgärda överdrivna eller oanvända privilegier.

# Indirect prompt injection attacks

### Problem statement

Illasinnade eller komprometterade MCP-servrar kan medföra betydande risker genom att exponera kunddata eller möjliggöra oavsiktliga handlingar. Dessa risker är särskilt relevanta för AI- och MCP-baserade arbetsbelastningar, där:

- **Prompt Injection Attacks**: Angripare bäddar in skadliga instruktioner i prompts eller externt innehåll, vilket får AI-systemet att utföra oavsiktliga handlingar eller läcka känslig data. Läs mer: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning**: Angripare manipulerar verktygsmetadata (som beskrivningar eller parametrar) för att påverka AI:ns beteende, potentiellt kringgå säkerhetskontroller eller läcka data. Detaljer: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection**: Skadliga instruktioner bäddas in i dokument, webbsidor eller e-postmeddelanden som sedan bearbetas av AI:n, vilket leder till dataläckage eller manipulation.
- **Dynamic Tool Modification (Rug Pulls)**: Verktygsdefinitioner kan ändras efter användarens godkännande, vilket introducerar nya skadliga beteenden utan användarens vetskap.

Dessa sårbarheter understryker behovet av robust validering, övervakning och säkerhetskontroller när MCP-servrar och verktyg integreras i din miljö. För en djupare genomgång, se de länkade referenserna ovan.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.sv.png)

**Indirect Prompt Injection** (även kallat cross-domain prompt injection eller XPIA) är en kritisk sårbarhet i generativa AI-system, inklusive de som använder Model Context Protocol (MCP). Vid denna attack göms skadliga instruktioner i externt innehåll—som dokument, webbsidor eller e-post. När AI-systemet bearbetar detta innehåll kan det tolka de inbäddade instruktionerna som legitima användarkommandon, vilket resulterar i oavsiktliga handlingar som dataläckage, generering av skadligt innehåll eller manipulation av användarinteraktioner. För en detaljerad förklaring och verkliga exempel, se [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

En särskilt farlig form av denna attack är **Tool Poisoning**. Här injicerar angripare skadliga instruktioner i metadata för MCP-verktyg (såsom verktygsbeskrivningar eller parametrar). Eftersom stora språkmodeller (LLM) förlitar sig på denna metadata för att avgöra vilka verktyg som ska användas, kan komprometterade beskrivningar lura modellen att utföra obehöriga verktygsanrop eller kringgå säkerhetskontroller. Dessa manipulationer är ofta osynliga för slutanvändare men kan tolkas och ageras på av AI-systemet. Risken ökar i hostade MCP-servermiljöer där verktygsdefinitioner kan uppdateras efter användarens godkännande—ett scenario som ibland kallas "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". I sådana fall kan ett verktyg som tidigare var säkert senare modifieras för att utföra skadliga handlingar, som att läcka data eller ändra systembeteende, utan användarens vetskap. För mer om denna attackvektor, se [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.sv.png)

## Risks  
Oavsiktliga AI-handlingar medför olika säkerhetsrisker, inklusive dataläckage och integritetsbrott.

### Mitigating controls  
### Using prompt shields to protect against Indirect Prompt Injection attacks  
-----------------------------------------------------------------------------

**AI Prompt Shields** är en lösning utvecklad av Microsoft för att försvara mot både direkta och indirekta promptinjektionsattacker. De hjälper genom:

1.  **Detektion och filtrering:** Prompt Shields använder avancerade maskininlärningsalgoritmer och naturlig språkbehandling för att upptäcka och filtrera bort skadliga instruktioner inbäddade i externt innehåll, såsom dokument, webbsidor eller e-post.
    
2.  **Spotlighting:** Denna teknik hjälper AI-systemet att skilja mellan giltiga systeminstruktioner och potentiellt opålitliga externa indata. Genom att transformera inmatningstexten på ett sätt som gör den mer relevant för modellen säkerställer Spotlighting att AI:n bättre kan identifiera och ignorera skadliga instruktioner.
    
3.  **Avgränsare och datamärkning:** Inkludering av avgränsare i systemmeddelandet tydliggör platsen för inmatningstexten, vilket hjälper AI-systemet att känna igen och separera användarinmatningar från potentiellt skadligt externt innehåll. Datamärkning bygger vidare på detta genom att använda särskilda markörer för att lyfta fram gränserna mellan betrodd och obetrodd data.
    
4.  **Kontinuerlig övervakning och uppdateringar:** Microsoft övervakar och uppdaterar kontinuerligt Prompt Shields för att hantera nya och föränderliga hot. Detta proaktiva angreppssätt säkerställer att försvaren förblir effektiva mot de senaste attacker.
    
5. **Integration med Azure Content Safety:** Prompt Shields är en del av den bredare Azure AI Content Safety-sviten, som erbjuder ytterligare verktyg för att upptäcka jailbreakförsök, skadligt innehåll och andra säkerhetsrisker i AI-applikationer.

Du kan läsa mer om AI prompt shields i [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.sv.png)

### Supply chain security

Leverantörskedjesäkerhet är fortsatt grundläggande i AI-eran, men omfattningen av vad som räknas som din leverantörskedja har utökats. Utöver traditionella kodpaket måste du nu noggrant verifiera och övervaka alla AI-relaterade komponenter, inklusive grundmodeller, embeddings-tjänster, kontextleverantörer och tredjeparts-API:er. Var och en av dessa kan introducera sårbarheter eller risker om de inte hanteras korrekt.

**Viktiga leverantörskedjesäkerhetspraxis för AI och MCP:**
- **Verifiera alla komponenter före integration:** Detta inkluderar inte bara open source-bibliotek utan även AI-modeller, datakällor och externa API:er. Kontrollera alltid ursprung, licenser och kända sårbarheter.
- **Upprätthåll säkra distributionspipelines:** Använd automatiserade CI/CD-pipelines med integrerad säkerhetsskanning för att upptäcka problem tidigt. Säkerställ att endast betrodda artefakter distribueras till produktion.
- **Kontinuerlig övervakning och revision:** Implementera löpande övervakning av alla beroenden, inklusive modeller och datatjänster, för att upptäcka nya sårbarheter eller attacker mot leverantörskedjan
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

### Nästa

Nästa: [Kapitel 3: Komma igång](/03-GettingStarted/README.md)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen observera att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för eventuella missförstånd eller feltolkningar som uppstår vid användning av denna översättning.