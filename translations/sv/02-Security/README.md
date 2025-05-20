<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-20T23:11:31+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "sv"
}
-->
# Security Best Practices

Att använda Model Context Protocol (MCP) ger kraftfulla nya möjligheter för AI-drivna applikationer, men medför också unika säkerhetsutmaningar som går bortom traditionella mjukvarurisker. Utöver etablerade områden som säker kodning, principen om minsta privilegium och leverantörskedjesäkerhet, möter MCP och AI-arbetsbelastningar nya hot som promptinjektion, verktygsförgiftning och dynamisk verktygsmodifiering. Dessa risker kan leda till dataexfiltration, integritetsintrång och oavsiktligt systembeteende om de inte hanteras på rätt sätt.

Den här lektionen utforskar de mest relevanta säkerhetsriskerna kopplade till MCP—inklusive autentisering, auktorisering, överdrivna behörigheter, indirekta promptinjektioner och sårbarheter i leverantörskedjan—och erbjuder konkreta kontroller och bästa praxis för att mildra dem. Du kommer även att lära dig hur du kan använda Microsoft-lösningar som Prompt Shields, Azure Content Safety och GitHub Advanced Security för att stärka din MCP-implementering. Genom att förstå och tillämpa dessa kontroller kan du avsevärt minska risken för säkerhetsintrång och säkerställa att dina AI-system förblir robusta och pålitliga.

# Learning Objectives

I slutet av denna lektion kommer du att kunna:

- Identifiera och förklara de unika säkerhetsriskerna som Model Context Protocol (MCP) medför, inklusive promptinjektion, verktygsförgiftning, överdrivna behörigheter och sårbarheter i leverantörskedjan.
- Beskriva och tillämpa effektiva åtgärder för att minska MCP:s säkerhetsrisker, såsom robust autentisering, principen om minsta privilegium, säker tokenhantering och verifiering av leverantörskedjan.
- Förstå och använda Microsoft-lösningar som Prompt Shields, Azure Content Safety och GitHub Advanced Security för att skydda MCP och AI-arbetsbelastningar.
- Känna igen vikten av att validera verktygsmetadata, övervaka dynamiska förändringar och försvara mot indirekta promptinjektionsattacker.
- Integrera etablerade säkerhetsrutiner—såsom säker kodning, serverhärdning och zero trust-arkitektur—i din MCP-implementering för att minska sannolikheten och konsekvenserna av säkerhetsintrång.

# MCP security controls

Alla system som har tillgång till viktiga resurser har underliggande säkerhetsutmaningar. Säkerhetsutmaningar kan generellt hanteras genom korrekt tillämpning av grundläggande säkerhetskontroller och koncept. Eftersom MCP är nydefinierat ändras specifikationen snabbt och protokollet utvecklas. Så småningom kommer säkerhetskontrollerna inom MCP att mogna, vilket möjliggör bättre integration med företags- och etablerade säkerhetsarkitekturer och bästa praxis.

Forskning publicerad i [Microsoft Digital Defense Report](https://aka.ms/mddr) visar att 98 % av rapporterade intrång skulle kunna förhindras med robust säkerhetshygien och att det bästa skyddet mot alla typer av intrång är att ha en stabil grund med säkerhetshygien, säker kodningspraxis och leverantörskedjesäkerhet—de beprövade metoder vi redan känner till gör fortfarande störst skillnad för att minska säkerhetsrisker.

Låt oss titta på några sätt att börja hantera säkerhetsrisker när du implementerar MCP.

# MCP server authentication (if your MCP implementation was before 26th April 2025)

> **Note:** Följande information är korrekt per 26 april 2025. MCP-protokollet utvecklas kontinuerligt och framtida implementationer kan introducera nya autentiseringsmönster och kontroller. För senaste uppdateringar och vägledning, hänvisa alltid till [MCP Specification](https://spec.modelcontextprotocol.io/) och den officiella [MCP GitHub repository](https://github.com/modelcontextprotocol).

### Problem statement  
Den ursprungliga MCP-specifikationen antog att utvecklare skulle skriva sin egen autentiseringsserver. Detta krävde kunskap om OAuth och relaterade säkerhetsbegränsningar. MCP-servrar fungerade som OAuth 2.0 Authorization Servers och hanterade användarautentisering direkt istället för att delegera till en extern tjänst som Microsoft Entra ID. Från och med 26 april 2025 tillåter en uppdatering i MCP-specifikationen att MCP-servrar kan delegera användarautentisering till en extern tjänst.

### Risks
- Felkonfigurerad auktoriseringslogik i MCP-servern kan leda till exponering av känslig data och felaktigt tillämpade åtkomstkontroller.
- Stöld av OAuth-token på den lokala MCP-servern. Om token stjäls kan den användas för att utge sig för att vara MCP-servern och få tillgång till resurser och data från den tjänst som OAuth-token gäller för.

### Mitigating controls
- **Review and Harden Authorization Logic:** Granska noggrant din MCP-servers auktoriseringsimplementering för att säkerställa att endast avsedda användare och klienter kan nå känsliga resurser. För praktisk vägledning, se [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) och [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Enforce Secure Token Practices:** Följ [Microsofts bästa praxis för tokenvalidering och livslängd](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) för att förhindra missbruk av access tokens och minska risken för tokenåterspelning eller stöld.
- **Protect Token Storage:** Spara alltid tokens säkert och använd kryptering för att skydda dem både i vila och under överföring. För implementeringstips, se [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Excessive permissions for MCP servers

### Problem statement  
MCP-servrar kan ha beviljats överdrivna behörigheter till tjänsten/resursen de ansluter till. Till exempel bör en MCP-server som är en del av en AI-försäljningsapplikation som ansluter till ett företagsdatastore endast ha åtkomst begränsad till försäljningsdata och inte tillåtas komma åt alla filer i lagret. Med hänvisning till principen om minsta privilegium (en av de äldsta säkerhetsprinciperna) ska ingen resurs ha behörigheter utöver vad som krävs för att utföra sina avsedda uppgifter. AI utgör en särskild utmaning här eftersom flexibilitet kräver svårdefinierade exakta behörigheter.

### Risks  
- Att ge överdrivna behörigheter kan möjliggöra exfiltration eller ändring av data som MCP-servern inte skulle ha åtkomst till. Detta kan även vara ett integritetsproblem om data innehåller personligt identifierbar information (PII).

### Mitigating controls
- **Apply the Principle of Least Privilege:** Ge MCP-servern endast de minsta behörigheter som krävs för att utföra sina uppgifter. Granska och uppdatera regelbundet dessa behörigheter för att säkerställa att de inte överskrider det nödvändiga. För detaljerad vägledning, se [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Use Role-Based Access Control (RBAC):** Tilldela roller till MCP-servern som är strikt avgränsade till specifika resurser och åtgärder, och undvik breda eller onödiga behörigheter.
- **Monitor and Audit Permissions:** Övervaka kontinuerligt behörighetsanvändning och granska åtkomstloggar för att snabbt upptäcka och åtgärda överdrivna eller oanvända privilegier.

# Indirect prompt injection attacks

### Problem statement

Illvilliga eller komprometterade MCP-servrar kan medföra betydande risker genom att exponera kunddata eller möjliggöra oavsiktliga handlingar. Dessa risker är särskilt relevanta i AI- och MCP-baserade arbetsbelastningar, där:

- **Prompt Injection Attacks**: Angripare gömmer skadliga instruktioner i prompts eller externt innehåll, vilket får AI-systemet att utföra oavsiktliga handlingar eller läcka känslig data. Läs mer: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning**: Angripare manipulerar verktygsmetadata (såsom beskrivningar eller parametrar) för att påverka AI:ns beteende, vilket kan kringgå säkerhetskontroller eller exfiltrera data. Detaljer: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection**: Skadliga instruktioner göms i dokument, webbsidor eller e-post som sedan bearbetas av AI, vilket leder till dataläckage eller manipulation.
- **Dynamic Tool Modification (Rug Pulls)**: Verktygsdefinitioner kan ändras efter användarens godkännande, vilket inför nya skadliga beteenden utan användarens vetskap.

Dessa sårbarheter understryker behovet av robust validering, övervakning och säkerhetskontroller när MCP-servrar och verktyg integreras i din miljö. För en djupare genomgång, se de länkade referenserna ovan.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.sv.png)

**Indirect Prompt Injection** (även kallat cross-domain prompt injection eller XPIA) är en kritisk sårbarhet i generativa AI-system, inklusive de som använder Model Context Protocol (MCP). Vid denna attack göms skadliga instruktioner i externt innehåll—såsom dokument, webbsidor eller e-post. När AI-systemet bearbetar detta innehåll kan det tolka de inbäddade instruktionerna som legitima användarkommandon, vilket resulterar i oavsiktliga handlingar som dataläckage, generering av skadligt innehåll eller manipulation av användarinteraktioner. För en detaljerad förklaring och verkliga exempel, se [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

En särskilt farlig form av denna attack är **Tool Poisoning**. Här injicerar angripare skadliga instruktioner i metadata för MCP-verktyg (såsom verktygsbeskrivningar eller parametrar). Eftersom stora språkmodeller (LLM) förlitar sig på denna metadata för att avgöra vilka verktyg som ska anropas, kan komprometterade beskrivningar lura modellen att utföra obehöriga verktygsanrop eller kringgå säkerhetskontroller. Dessa manipulationer är ofta osynliga för slutanvändare men kan tolkas och ageras på av AI-systemet. Risken ökar i hostade MCP-servermiljöer där verktygsdefinitioner kan uppdateras efter användarens godkännande—ett scenario som ibland kallas för en "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". I sådana fall kan ett verktyg som tidigare var säkert senare modifieras för att utföra skadliga handlingar, som att exfiltrera data eller ändra systembeteende, utan användarens vetskap. För mer om denna attackvektor, se [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.sv.png)

## Risks  
Oavsiktliga AI-handlingar medför en rad säkerhetsrisker, inklusive dataexfiltration och integritetsintrång.

### Mitigating controls  
### Using prompt shields to protect against Indirect Prompt Injection attacks  
-----------------------------------------------------------------------------

**AI Prompt Shields** är en lösning utvecklad av Microsoft för att försvara mot både direkta och indirekta promptinjektionsattacker. De hjälper genom:

1.  **Detection and Filtering:** Prompt Shields använder avancerade maskininlärningsalgoritmer och naturlig språkbehandling för att upptäcka och filtrera bort skadliga instruktioner inbäddade i externt innehåll, som dokument, webbsidor eller e-post.
    
2.  **Spotlighting:** Denna teknik hjälper AI-systemet att skilja på giltiga systeminstruktioner och potentiellt opålitliga externa indata. Genom att transformera indatatexten på ett sätt som gör den mer relevant för modellen säkerställer Spotlighting att AI:n bättre kan identifiera och ignorera skadliga instruktioner.
    
3.  **Delimiters and Datamarking:** Genom att inkludera avgränsare i systemmeddelandet markeras tydligt var indatatexten finns, vilket hjälper AI-systemet att känna igen och separera användarindata från potentiellt skadligt externt innehåll. Datamarking utökar detta koncept genom att använda speciella markörer för att lyfta fram gränserna mellan betrodd och obetrodd data.
    
4.  **Continuous Monitoring and Updates:** Microsoft övervakar och uppdaterar kontinuerligt Prompt Shields för att hantera nya och föränderliga hot. Detta proaktiva tillvägagångssätt säkerställer att skyddet förblir effektivt mot de senaste attackteknikerna.
    
5. **Integration with Azure Content Safety:** Prompt Shields är en del av den bredare Azure AI Content Safety-sviten, som erbjuder ytterligare verktyg för att upptäcka jailbreak-försök, skadligt innehåll och andra säkerhetsrisker i AI-applikationer.

Du kan läsa mer om AI prompt shields i [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.sv.png)

### Supply chain security

Leverantörskedjesäkerhet förblir grundläggande i AI-eran, men omfattningen av vad som räknas som din leverantörskedja har utökats. Utöver traditionella kodpaket måste du nu noggrant verifiera och övervaka alla AI-relaterade komponenter, inklusive grundmodeller, embeddings-tjänster, kontextleverantörer och tredjeparts-API:er. Var och en av dessa kan introducera sårbarheter eller risker om de inte hanteras korrekt.

**Viktiga leverantörskedjesäkerhetsrutiner för AI och MCP:**
- **Verifiera alla komponenter före integration:** Detta inkluderar inte bara open source-bibliotek utan även AI-modeller, datakällor och externa API:er. Kontrollera alltid ursprung, licenser och kända sårbarheter.
- **Behåll säkra distributionspipelines:** Använd automatiserade CI/CD-pipelines med integrerad säkerhetsskanning för att upptäcka problem tidigt. Säkerställ att endast betrodda artefakter distribueras till produktion.
- **Kontinuerlig övervakning och revision:** Implementera löpande övervakning av alla beroenden, inklusive modeller och datatjänster, för att upptäcka nya sårbarheter eller attacker mot leverantörskedjan.
- **Tillämpa minsta privilegium och åtkomstkontroller:** Begränsa åtkomst till modeller, data och tjänster till endast vad som är nödvändigt för att din MCP-server ska fungera.
- **Snabb respons på hot:** Ha en process för att patcha eller ersätta komprometterade komponenter och för att rotera hemligheter eller autentiseringsuppgifter om ett intrång upptäcks.

[GitHub Advanced Security](https://github.com/security/advanced-security) erbjuder funktioner som hemlighetsskanning, beroendeskanning och CodeQL-analys. Dessa verktyg integreras med [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) och [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) för att hjälpa team att identifiera och mildra sårbarheter i både kod och AI-leverantörskedjekomponenter.

Microsoft implementerar också omfattande leverantörskedjesäkerhetsrutiner internt för alla produkter. Läs mer i [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Established security best practices that will uplift your MCP implementation's security posture

Varje MCP-implementering ärver den befintliga säkerhetsnivån i den organisationsmiljö den bygger på, så när du betraktar säkerheten för MCP som en del av dina AI-system rekommenderas det att du stärker din övergripande säkerhetsnivå. Följande etablerade säkerhetskontroller är särskilt relevanta:

- Säker kodningspraxis i din AI-applikation – skydda mot [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 för LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), användning av säkra valv för hemligheter och tokens, implementera end-to-end säker kommunikation mellan alla applikationskomponenter, med mera.
- Serverhärdning – använd MFA där det är möjligt, håll patchar uppdaterade, integrera servern med en tredjepartsidentitetsleverantör för åtkomst, osv.
- Håll enheter, infrastruktur och applikationer uppdaterade med patchar.
- Säkerhetsövervakning – implementera loggning och övervakning av AI-ap
- [OWASP Top 10 för LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Resan för att säkra mjukvaruleveranskedjan på Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Säkra minsta privilegierad åtkomst (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Bästa praxis för tokenvalidering och livslängd](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Använd säker tokenlagring och kryptera tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management som autentiseringsgateway för MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Använda Microsoft Entra ID för autentisering med MCP-servrar](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Nästa

Nästa: [Kapitel 3: Komma igång](/03-GettingStarted/README.md)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen var medveten om att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för några missförstånd eller feltolkningar som uppstår vid användning av denna översättning.