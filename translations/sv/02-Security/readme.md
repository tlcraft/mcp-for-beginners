<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-17T07:33:33+00:00",
  "source_file": "02-Security/readme.md",
  "language_code": "sv"
}
-->
# Säkerhetsbästa praxis

Att anta Model Context Protocol (MCP) ger kraftfulla nya möjligheter till AI-drivna applikationer, men introducerar också unika säkerhetsutmaningar som sträcker sig bortom traditionella mjukvarurisker. Förutom etablerade bekymmer som säker kodning, minsta privilegium och försörjningskedjans säkerhet, står MCP och AI-arbetsbelastningar inför nya hot som promptinjektion, verktygsförgiftning och dynamisk verktygsmodifikation. Dessa risker kan leda till dataexfiltrering, integritetsintrång och oavsiktligt systembeteende om de inte hanteras korrekt.

Denna lektion utforskar de mest relevanta säkerhetsriskerna associerade med MCP—inklusive autentisering, auktorisering, överdrivna behörigheter, indirekt promptinjektion och försörjningskedjans sårbarheter—och ger handlingsbara kontroller och bästa praxis för att mildra dem. Du kommer också att lära dig hur du utnyttjar Microsoft-lösningar som Prompt Shields, Azure Content Safety och GitHub Advanced Security för att stärka din MCP-implementering. Genom att förstå och tillämpa dessa kontroller kan du avsevärt minska sannolikheten för en säkerhetsintrång och säkerställa att dina AI-system förblir robusta och pålitliga.

# Lärandemål

I slutet av denna lektion kommer du att kunna:

- Identifiera och förklara de unika säkerhetsrisker som introduceras av Model Context Protocol (MCP), inklusive promptinjektion, verktygsförgiftning, överdrivna behörigheter och försörjningskedjans sårbarheter.
- Beskriva och tillämpa effektiva kontroller för att mildra MCP-säkerhetsrisker, såsom robust autentisering, minsta privilegium, säker tokenhantering och försörjningskedjans verifiering.
- Förstå och utnyttja Microsoft-lösningar som Prompt Shields, Azure Content Safety och GitHub Advanced Security för att skydda MCP och AI-arbetsbelastningar.
- Erkänna vikten av att validera verktygsmetadata, övervaka dynamiska förändringar och försvara mot indirekta promptinjektionattacker.
- Integrera etablerade säkerhetsbästa praxis—såsom säker kodning, serverhärdning och zero trust-arkitektur—i din MCP-implementering för att minska sannolikheten och påverkan av säkerhetsintrång.

# MCP-säkerhetskontroller

Alla system som har tillgång till viktiga resurser har underförstådda säkerhetsutmaningar. Säkerhetsutmaningar kan generellt hanteras genom korrekt tillämpning av grundläggande säkerhetskontroller och koncept. Eftersom MCP bara nyligen definierats, förändras specifikationen mycket snabbt och i takt med att protokollet utvecklas. Så småningom kommer säkerhetskontrollerna inom det att mogna, vilket möjliggör en bättre integration med företags- och etablerade säkerhetsarkitekturer och bästa praxis.

Forskning publicerad i [Microsoft Digital Defense Report](https://aka.ms/mddr) anger att 98% av rapporterade intrång skulle förhindras genom robust säkerhetshygien och det bästa skyddet mot alla slags intrång är att få din grundläggande säkerhetshygien, bästa praxis för säker kodning och försörjningskedjans säkerhet rätt -- dessa beprövade och testade metoder som vi redan vet om gör fortfarande mest påverkan på att minska säkerhetsrisken.

Låt oss titta på några av de sätt som du kan börja adressera säkerhetsrisker när du antar MCP.

# MCP-serverautentisering (om din MCP-implementering var före den 26 april 2025)

> **Note:** Följande information är korrekt från och med den 26 april 2025. MCP-protokollet utvecklas kontinuerligt, och framtida implementeringar kan introducera nya autentiseringsmönster och kontroller. För de senaste uppdateringarna och vägledningen, hänvisa alltid till [MCP Specification](https://spec.modelcontextprotocol.io/) och den officiella [MCP GitHub repository](https://github.com/modelcontextprotocol).

### Problemformulering 
Den ursprungliga MCP-specifikationen antog att utvecklare skulle skriva sina egna autentiseringsservrar. Detta krävde kunskap om OAuth och relaterade säkerhetsbegränsningar. MCP-servrar fungerade som OAuth 2.0-auktoriseringsservrar, hanterade den nödvändiga användarautentiseringen direkt snarare än att delegera den till en extern tjänst såsom Microsoft Entra ID. Från och med den 26 april 2025 tillåter en uppdatering av MCP-specifikationen MCP-servrar att delegera användarautentisering till en extern tjänst.

### Risker
- Felkonfigurerad auktoriseringslogik i MCP-servern kan leda till exponering av känslig data och felaktigt tillämpade åtkomstkontroller.
- OAuth-tokenstöld på den lokala MCP-servern. Om den stjäls kan token sedan användas för att imitera MCP-servern och få tillgång till resurser och data från tjänsten som OAuth-token är för.

### Mildrande kontroller
- **Granska och Härda Auktoriseringslogik:** Granska noggrant din MCP-servers auktoriseringsimplementering för att säkerställa att endast avsedda användare och klienter kan få tillgång till känsliga resurser. För praktisk vägledning, se [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) och [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Upprätthåll Säkra Token Praxis:** Följ [Microsofts bästa praxis för tokenvalidering och livstid](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) för att förhindra missbruk av åtkomsttoken och minska risken för tokenåterspelning eller stöld.
- **Skydda Tokenlagring:** Lagra alltid token säkert och använd kryptering för att skydda dem vid vila och i transit. För implementeringstips, se [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Överdrivna behörigheter för MCP-servrar

### Problemformulering
MCP-servrar kan ha fått överdrivna behörigheter till den tjänst/resurs de har åtkomst till. Till exempel, en MCP-server som är en del av en AI-försäljningsapplikation som ansluter till ett företags datalager bör ha åtkomst begränsad till försäljningsdata och inte tillåtas att få tillgång till alla filer i lagret. Med hänvisning tillbaka till principen om minsta privilegium (en av de äldsta säkerhetsprinciperna), bör ingen resurs ha behörigheter som överstiger vad som krävs för att den ska utföra de uppgifter den var avsedd för. AI presenterar en ökad utmaning inom detta område eftersom det kan vara svårt att definiera exakt vilka behörigheter som krävs för att göra det flexibelt.

### Risker 
- Att bevilja överdrivna behörigheter kan tillåta exfiltrering eller ändring av data som MCP-servern inte var avsedd att kunna få tillgång till. Detta kan också vara ett integritetsproblem om datan är personligt identifierbar information (PII).

### Mildrande kontroller
- **Tillämpa Principen om Minsta Privilegium:** Ge MCP-servern endast de minimala behörigheter som är nödvändiga för att utföra dess uppgifter. Granska och uppdatera regelbundet dessa behörigheter för att säkerställa att de inte överstiger vad som behövs. För detaljerad vägledning, se [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Använd Rollbaserad Åtkomstkontroll (RBAC):** Tilldela roller till MCP-servern som är noggrant avgränsade till specifika resurser och åtgärder, och undvik breda eller onödiga behörigheter.
- **Övervaka och Granska Behörigheter:** Övervaka kontinuerligt behörighetsanvändning och granska åtkomstloggar för att snabbt upptäcka och åtgärda överdrivna eller oanvända privilegier.

# Indirekta promptinjektionattacker

### Problemformulering

Skadliga eller komprometterade MCP-servrar kan introducera betydande risker genom att exponera kunddata eller möjliggöra oavsiktliga åtgärder. Dessa risker är särskilt relevanta i AI- och MCP-baserade arbetsbelastningar, där:

- **Promptinjektionattacker**: Angripare bäddar in skadliga instruktioner i prompts eller extern innehåll, vilket får AI-systemet att utföra oavsiktliga åtgärder eller läcka känslig data. Läs mer: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Verktygsförgiftning**: Angripare manipulerar verktygsmetadata (såsom beskrivningar eller parametrar) för att påverka AI:s beteende, potentiellt kringgå säkerhetskontroller eller exfiltrera data. Detaljer: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection**: Skadliga instruktioner bäddas in i dokument, webbsidor eller e-postmeddelanden, som sedan bearbetas av AI, vilket leder till dataläckage eller manipulation.
- **Dynamisk Verktygsmodifikation (Rug Pulls)**: Verktygsdefinitioner kan ändras efter användarens godkännande, vilket introducerar nya skadliga beteenden utan användarens medvetenhet.

Dessa sårbarheter understryker behovet av robust validering, övervakning och säkerhetskontroller när MCP-servrar och verktyg integreras i din miljö. För en djupare förståelse, se de länkade referenserna ovan.

**Indirekt Promptinjektion** (även känd som cross-domain prompt injection eller XPIA) är en kritisk sårbarhet i generativa AI-system, inklusive de som använder Model Context Protocol (MCP). I denna attack är skadliga instruktioner dolda inom externt innehåll—såsom dokument, webbsidor eller e-postmeddelanden. När AI-systemet bearbetar detta innehåll kan det tolka de inbäddade instruktionerna som legitima användarkommandon, vilket resulterar i oavsiktliga åtgärder som dataläckage, generering av skadligt innehåll eller manipulation av användarinteraktioner. För en detaljerad förklaring och verkliga exempel, se [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

En särskilt farlig form av denna attack är **Verktygsförgiftning**. Här injicerar angripare skadliga instruktioner i metadata för MCP-verktyg (såsom verktygsbeskrivningar eller parametrar). Eftersom stora språkmodeller (LLMs) förlitar sig på denna metadata för att bestämma vilka verktyg som ska anropas, kan komprometterade beskrivningar lura modellen att utföra obehöriga verktygsanrop eller kringgå säkerhetskontroller. Dessa manipulationer är ofta osynliga för slutanvändare men kan tolkas och ageras på av AI-systemet. Denna risk ökar i värdmiljöer för MCP-servrar, där verktygsdefinitioner kan uppdateras efter användarens godkännande—ett scenario som ibland kallas "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". I sådana fall kan ett verktyg som tidigare var säkert senare modifieras för att utföra skadliga åtgärder, såsom att exfiltrera data eller ändra systembeteende, utan användarens vetskap. För mer om denna attackvektor, se [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

## Risker
Oavsiktliga AI-åtgärder utgör en mängd säkerhetsrisker som inkluderar dataexfiltrering och integritetsintrång.

### Mildrande kontroller
### Använda promptsköldar för att skydda mot indirekta promptinjektionattacker
-----------------------------------------------------------------------------

**AI Prompt Shields** är en lösning utvecklad av Microsoft för att försvara mot både direkta och indirekta promptinjektionattacker. De hjälper genom:

1.  **Upptäckt och Filtrering**: Prompt Shields använder avancerade maskininlärningsalgoritmer och naturlig språkbehandling för att upptäcka och filtrera bort skadliga instruktioner inbäddade i externt innehåll, såsom dokument, webbsidor eller e-postmeddelanden.
    
2.  **Spotlighting**: Denna teknik hjälper AI-systemet att skilja mellan giltiga systeminstruktioner och potentiellt opålitliga externa inmatningar. Genom att transformera inputtexten på ett sätt som gör den mer relevant för modellen, säkerställer Spotlighting att AI bättre kan identifiera och ignorera skadliga instruktioner.
    
3.  **Avgränsare och Datamärkning**: Inkludera avgränsare i systemmeddelandet som uttryckligen beskriver platsen för inputtexten, vilket hjälper AI-systemet att känna igen och separera användarinmatningar från potentiellt skadligt externt innehåll. Datamärkning utökar detta koncept genom att använda speciella markeringar för att belysa gränserna för betrodd och opålitlig data.
    
4.  **Kontinuerlig Övervakning och Uppdateringar**: Microsoft övervakar och uppdaterar kontinuerligt Prompt Shields för att adressera nya och utvecklande hot. Denna proaktiva strategi säkerställer att försvaren förblir effektiva mot de senaste attackteknikerna.
    
5. **Integration med Azure Content Safety:** Prompt Shields är en del av den bredare Azure AI Content Safety-sviten, som tillhandahåller ytterligare verktyg för att upptäcka jailbreak-försök, skadligt innehåll och andra säkerhetsrisker i AI-applikationer.

Du kan läsa mer om AI promptsköldar i [Prompt Shields-dokumentationen](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

### Försörjningskedjans säkerhet

Försörjningskedjans säkerhet förblir grundläggande i AI-eran, men omfattningen av vad som utgör din försörjningskedja har utvidgats. Förutom traditionella kodpaket måste du nu noggrant verifiera och övervaka alla AI-relaterade komponenter, inklusive grundmodeller, embeddings-tjänster, kontextleverantörer och tredjeparts-API:er. Var och en av dessa kan introducera sårbarheter eller risker om de inte hanteras korrekt.

**Viktiga försörjningskedjans säkerhetspraxis för AI och MCP:**
- **Verifiera alla komponenter innan integration:** Detta inkluderar inte bara öppna källkodsbibliotek, utan även AI-modeller, datakällor och externa API:er. Kontrollera alltid proveniens, licensiering och kända sårbarheter.
- **Upprätthåll säkra distributionspipelines:** Använd automatiserade CI/CD-pipelines med integrerad säkerhetsskanning för att fånga problem tidigt. Se till att endast betrodda artefakter distribueras till produktion.
- **Kontinuerligt övervaka och granska:** Implementera kontinuerlig övervakning för alla beroenden, inklusive modeller och datatjänster, för att upptäcka nya sårbarheter eller försörjningskedjeattacker.
- **Tillämpa minsta privilegium och åtkomstkontroller:** Begränsa åtkomst till modeller, data och tjänster till endast vad som är nödvändigt för din MCP-server att fungera.
- **Reagera snabbt på hot:** Ha en process på plats för att patcha eller ersätta komprometterade komponenter och för att rotera hemligheter eller autentiseringsuppgifter om ett intrång upptäcks.

[GitHub Advanced Security](https://github.com/security/advanced-security) tillhandahåller funktioner som hemlighetsskanning, beroendeskanning och CodeQL-analys. Dessa verktyg integreras med [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) och [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) för att hjälpa team att identifiera och mildra sårbarheter över både kod och AI-försörjningskedjans komponenter.

Microsoft implementerar också omfattande försörjningskedjans säkerhetspraxis internt för alla produkter. Läs mer i [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Etablerade säkerhetsbästa praxis som kommer att höja din MCP-implementerings säkerhetshållning

Varje MCP-implementering ärver den befintliga säkerhetshållningen av din organisations miljö som den är byggd på, så när du överväger säkerheten för MCP som en komponent av dina övergripande AI-system rekommenderas det att du ser över att höja din övergripande befintliga säkerhetshållning. Följande etablerade säkerhetskontroller är särskilt relevanta:

-   Säker kodningsbästa
- [OWASP Topp 10 för LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Avancerad Säkerhet](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Resan för att Säkra Mjukvaruleveranskedjan på Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Säkra Minsta Privilegierade Åtkomst (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Bästa Praxis för Tokenvalidering och Livstid](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Använd Säker Tokenlagring och Kryptera Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management som Autentiseringsgateway för MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Använda Microsoft Entra ID för att Autentisera med MCP Servrar](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Nästa 

Nästa: [Kapitel 3: Komma Igång](/03-GettingStarted/README.md)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, var medveten om att automatiserade översättningar kan innehålla fel eller oriktigheter. Det ursprungliga dokumentet på sitt modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för eventuella missförstånd eller misstolkningar som uppstår vid användning av denna översättning.