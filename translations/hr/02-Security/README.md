<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00aedb7b1d11b7eaacb0618d8791c65",
  "translation_date": "2025-05-29T23:39:56+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "hr"
}
-->
# Najbolje sigurnosne prakse

Usvajanje Model Context Protocol (MCP) donosi moćne nove mogućnosti AI-pokretanih aplikacija, ali također uvodi jedinstvene sigurnosne izazove koji nadilaze tradicionalne softverske rizike. Osim uobičajenih briga poput sigurnog kodiranja, principa najmanjih privilegija i sigurnosti lanca opskrbe, MCP i AI radni opterećenja suočavaju se s novim prijetnjama poput prompt injectiona, trovanja alata i dinamičke izmjene alata. Ovi rizici mogu dovesti do krađe podataka, povrede privatnosti i nepredviđenog ponašanja sustava ako se ne upravlja pravilno.

Ova lekcija istražuje najvažnije sigurnosne rizike povezane s MCP-om — uključujući autentikaciju, autorizaciju, pretjerane dozvole, indirektni prompt injection i ranjivosti u lancu opskrbe — te pruža konkretne kontrole i najbolje prakse za njihovo ublažavanje. Također ćete naučiti kako iskoristiti Microsoftova rješenja poput Prompt Shields, Azure Content Safety i GitHub Advanced Security za jačanje vaše MCP implementacije. Razumijevanjem i primjenom ovih kontrola možete znatno smanjiti vjerojatnost sigurnosnog incidenta i osigurati da vaši AI sustavi ostanu robusni i pouzdani.

# Ciljevi učenja

Do kraja ove lekcije moći ćete:

- Prepoznati i objasniti jedinstvene sigurnosne rizike koje donosi Model Context Protocol (MCP), uključujući prompt injection, trovanje alata, pretjerane dozvole i ranjivosti u lancu opskrbe.
- Opisati i primijeniti učinkovite mjere za ublažavanje MCP sigurnosnih rizika, kao što su snažna autentikacija, princip najmanjih privilegija, sigurno upravljanje tokenima i provjera lanca opskrbe.
- Razumjeti i koristiti Microsoftova rješenja poput Prompt Shields, Azure Content Safety i GitHub Advanced Security za zaštitu MCP i AI radnih opterećenja.
- Prepoznati važnost validacije metapodataka alata, praćenja dinamičkih promjena i obrane od indirektnih prompt injection napada.
- Integrirati uspostavljene sigurnosne najbolje prakse — poput sigurnog kodiranja, učvršćivanja servera i arhitekture nulte povjerenja — u vašu MCP implementaciju kako biste smanjili vjerojatnost i utjecaj sigurnosnih incidenata.

# Sigurnosne kontrole MCP-a

Svaki sustav koji ima pristup važnim resursima ima i implicitne sigurnosne izazove. Sigurnosni izazovi se općenito mogu riješiti pravilnom primjenom temeljnih sigurnosnih kontrola i koncepata. Kako je MCP tek nedavno definiran, specifikacija se brzo mijenja i razvija. S vremenom će sigurnosne kontrole unutar njega sazrijeti, omogućujući bolju integraciju s enterprise i etabliranim sigurnosnim arhitekturama i najboljim praksama.

Istraživanje objavljeno u [Microsoft Digital Defense Report](https://aka.ms/mddr) navodi da bi 98% prijavljenih sigurnosnih incidenata bilo spriječeno pravilnom sigurnosnom higijenom, a najbolja zaštita od bilo kakvog proboja je da uspostavite osnovnu sigurnosnu higijenu, najbolje prakse sigurnog kodiranja i sigurnost lanca opskrbe — te provjerene prakse koje već poznajemo i koje i dalje imaju najveći utjecaj na smanjenje sigurnosnog rizika.

Pogledajmo neke od načina na koje možete početi adresirati sigurnosne rizike prilikom usvajanja MCP-a.

> **Note:** Sljedeće informacije točne su na dan **29. svibnja 2025.** MCP protokol se stalno razvija, a buduće implementacije mogu uvesti nove obrasce autentikacije i kontrole. Za najnovije informacije i smjernice uvijek se obratite [MCP Specification](https://spec.modelcontextprotocol.io/) te službenom [MCP GitHub repozitoriju](https://github.com/modelcontextprotocol) i [stranici s najboljim sigurnosnim praksama](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Izjava problema  
Izvorna MCP specifikacija pretpostavljala je da će developeri sami pisati svoj autentikacijski server. To je zahtijevalo poznavanje OAuth-a i povezanih sigurnosnih ograničenja. MCP serveri su djelovali kao OAuth 2.0 Authorization Serveri, upravljajući potrebnom autentikacijom korisnika direktno, umjesto da je delegiraju vanjskoj usluzi poput Microsoft Entra ID. Od **26. travnja 2025.**, ažuriranje MCP specifikacije dopušta MCP serverima da delegiraju autentikaciju korisnika vanjskoj usluzi.

### Rizici
- Pogrešno konfigurirana autorizacijska logika na MCP serveru može dovesti do izlaganja osjetljivih podataka i nepravilno primijenjenih kontrola pristupa.
- Krađa OAuth tokena na lokalnom MCP serveru. Ako je token ukraden, može se koristiti za lažno predstavljanje MCP servera i pristup resursima i podacima za koje je token izdan.

#### Token Passthrough
Token passthrough je izričito zabranjen u autorizacijskoj specifikaciji jer uvodi niz sigurnosnih rizika, uključujući:

#### Zaobilaženje sigurnosnih kontrola
MCP Server ili downstream API-ji mogu implementirati važne sigurnosne kontrole poput ograničavanja brzine zahtjeva, validacije zahtjeva ili praćenja prometa, koje ovise o publici tokena ili drugim ograničenjima vjerodajnica. Ako klijenti mogu direktno dobiti i koristiti tokene s downstream API-ja bez da ih MCP server pravilno validira ili osigurava da su tokeni izdani za odgovarajuću uslugu, zaobilaze te kontrole.

#### Problemi s odgovornošću i revizijskim tragom
MCP Server neće moći identificirati ili razlikovati MCP klijente kada klijenti koriste pristupni token izdan od strane upstream-a koji može biti nečitljiv MCP Serveru. Logovi downstream Resource Servera mogu prikazivati zahtjeve kao da dolaze iz drugog izvora s drugačijim identitetom, umjesto iz MCP servera koji zapravo prosljeđuje tokene. Oba faktora otežavaju istragu incidenata, kontrole i reviziju. Ako MCP Server prosljeđuje tokene bez provjere njihovih tvrdnji (npr. uloga, privilegija ili publike) ili drugih metapodataka, zlonamjerni korisnik u posjedu ukradenog tokena može koristiti server kao proxy za iznošenje podataka.

#### Problemi s granicom povjerenja
Downstream Resource Server daje povjerenje određenim entitetima. Ovo povjerenje može uključivati pretpostavke o podrijetlu ili obrascima ponašanja klijenata. Kršenje ove granice povjerenja može dovesti do neočekivanih problema. Ako se token prihvaća od strane više usluga bez odgovarajuće validacije, napadač koji kompromitira jednu uslugu može koristiti token za pristup drugim povezanim uslugama.

#### Rizik buduće kompatibilnosti
Čak i ako MCP Server danas započne kao "čisti proxy", možda će kasnije trebati dodati sigurnosne kontrole. Početak s pravilnim razdvajanjem publike tokena olakšava razvoj sigurnosnog modela.

### Mjere ublažavanja

**MCP serveri NE SMEJU prihvaćati tokene koji nisu izričito izdani za MCP server**

- **Pregledajte i učvrstite autorizacijsku logiku:** Pažljivo revidirajte implementaciju autorizacije na vašem MCP serveru kako biste osigurali da samo namijenjeni korisnici i klijenti imaju pristup osjetljivim resursima. Za praktične smjernice, pogledajte [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) i [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Primijenite sigurne prakse za tokene:** Slijedite [Microsoftove najbolje prakse za validaciju tokena i njihov životni vijek](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) kako biste spriječili zloupotrebu pristupnih tokena i smanjili rizik od ponovne upotrebe ili krađe tokena.
- **Zaštitite pohranu tokena:** Uvijek pohranjujte tokene sigurno i koristite enkripciju za njihovu zaštitu u mirovanju i prijenosu. Za savjete o implementaciji, pogledajte [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Pretjerane dozvole za MCP servere

### Izjava problema
MCP serverima su možda dodijeljene pretjerane dozvole za uslugu ili resurs kojem pristupaju. Na primjer, MCP server koji je dio AI aplikacije za prodaju i povezan je s enterprise spremištem podataka trebao bi imati pristup ograničen na prodajne podatke, a ne na sve datoteke u spremištu. Vraćajući se na princip najmanjih privilegija (jedan od najstarijih sigurnosnih principa), nijedan resurs ne bi trebao imati dozvole veće od onih potrebnih za izvršavanje zadanih zadataka. AI dodatno komplicira ovu situaciju jer je za njegovu fleksibilnost teško precizno definirati potrebne dozvole.

### Rizici  
- Dodjela pretjeranih dozvola može omogućiti iznošenje ili izmjenu podataka kojima MCP server nije trebao pristupiti. To također može predstavljati problem privatnosti ako se radi o osobnim podacima (PII).

### Mjere ublažavanja
- **Primijenite princip najmanjih privilegija:** Dodijelite MCP serveru samo minimalne dozvole potrebne za izvršenje njegovih zadataka. Redovito pregledavajte i ažurirajte te dozvole kako ne bi prelazile potrebnu razinu. Za detaljne smjernice, pogledajte [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Koristite Role-Based Access Control (RBAC):** Dodjeljujte uloge MCP serveru koje su strogo ograničene na određene resurse i radnje, izbjegavajući široke ili nepotrebne dozvole.
- **Nadzor i revizija dozvola:** Kontinuirano pratite korištenje dozvola i pregledavajte zapise pristupa kako biste brzo otkrili i uklonili pretjerane ili neiskorištene privilegije.

# Indirektni prompt injection napadi

### Izjava problema

Zlonamjerni ili kompromitirani MCP serveri mogu uzrokovati značajne rizike izlaganjem podataka korisnika ili omogućavanjem neželjenih radnji. Ovi rizici su posebno relevantni u AI i MCP radnim opterećenjima, gdje:

- **Prompt Injection napadi:** Napadači ugrađuju zlonamjerne upute u promptove ili vanjski sadržaj, zbog čega AI sustav izvodi neželjene radnje ili otkriva osjetljive podatke. Više informacija: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Trovanje alata:** Napadači manipuliraju metapodacima alata (poput opisa ili parametara) kako bi utjecali na ponašanje AI-ja, potencijalno zaobilazeći sigurnosne kontrole ili izvlačeći podatke. Detalji: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection:** Zlonamjerne upute su ugrađene u dokumente, web stranice ili e-poštu koje AI potom obrađuje, što može dovesti do curenja podataka ili manipulacije.
- **Dinamička izmjena alata (Rug Pulls):** Definicije alata mogu se mijenjati nakon korisničkog odobrenja, uvodeći nove zlonamjerne radnje bez znanja korisnika.

Ove ranjivosti naglašavaju potrebu za snažnom validacijom, praćenjem i sigurnosnim kontrolama pri integraciji MCP servera i alata u vaše okruženje. Za detaljnije informacije, pogledajte gore navedene poveznice.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.hr.png)

**Indirektni Prompt Injection** (poznat i kao cross-domain prompt injection ili XPIA) je kritična ranjivost u generativnim AI sustavima, uključujući one koji koriste Model Context Protocol (MCP). U ovom napadu, zlonamjerne upute skrivene su u vanjskom sadržaju — poput dokumenata, web stranica ili e-pošte. Kada AI sustav obrađuje taj sadržaj, može interpretirati ugrađene upute kao legitimne korisničke naredbe, što rezultira neželjenim radnjama poput curenja podataka, generiranja štetnog sadržaja ili manipulacije korisničkim interakcijama. Za detaljno objašnjenje i stvarne primjere, pogledajte [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Posebno opasna varijanta ovog napada je **Trovanje alata**. Ovdje napadači ubacuju zlonamjerne upute u metapodatke MCP alata (poput opisa ili parametara). Budući da veliki jezični modeli (LLM) koriste ove metapodatke za odlučivanje koje alate pozvati, kompromitirani opisi mogu prevariti model da izvrši neovlaštene pozive alata ili zaobiđe sigurnosne kontrole. Ove manipulacije su često nevidljive krajnjim korisnicima, ali ih AI sustav može interpretirati i izvršiti. Rizik je povećan u hostiranim MCP server okruženjima, gdje se definicije alata mogu ažurirati nakon korisničkog odobrenja — scenarij poznat kao "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". U takvim slučajevima, alat koji je prije bio siguran može kasnije biti izmijenjen da izvodi zlonamjerne radnje, poput izvlačenja podataka ili promjene ponašanja sustava, bez znanja korisnika. Za više informacija o ovom napadu pogledajte [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.hr.png)

## Rizici
Neželjene AI radnje predstavljaju razne sigurnosne rizike, uključujući iznošenje podataka i povrede privatnosti.

### Mjere ublažavanja
### Korištenje prompt shields za zaštitu od indirektnih prompt injection napada
-----------------------------------------------------------------------------

**AI Prompt Shields** su rješenje koje je razvio Microsoft za obranu od izravnih i neizravnih prompt injection napada. Pomažu kroz:

1.  **Detekciju i filtriranje:** Prompt Shields koriste napredne algoritme strojnog učenja i obradu prirodnog jezika za otkrivanje i filtriranje zlonamjernih uputa ugrađenih u vanjski sadržaj poput dokumenata, web stranica ili e-pošte.
    
2.  **Spotlighting:** Ova tehnika pomaže AI sustavu da razlikuje valjane sistemske upute od potencijalno nepouzdanih vanjskih unosa. Transformiranjem ulaznog teksta na način koji ga čini relevantnijim modelu, Spotlighting osigurava da AI bolje prepozna i ignorira zlonamjerne upute.
    
3.  **Ograničivači i označavanje podataka:** Uključivanje ograničivača u sistemsku poruku jasno označava lokaciju ulaznog teksta, pomažući AI sustavu da prepozna i razdvoji korisničke unose od potencijalno štetnog vanjskog sadržaja. Označavanje podataka proširuje ovaj koncept korištenjem posebnih markera za isticanje granica pouzdanih i nepouzdanih podataka.
    
4.  **Kontinuirano praćenje i ažuriranja:** Microsoft kontinuirano prati i ažurira Prompt Shields kako bi odgovorio na nove i razvijajuće prijetnje. Ovaj proaktivan pristup osigurava da obrana ostane učinkovita protiv najnovijih tehnika napada.
    
5. **Integracija s Azure Content Safety:** Prompt Shields su dio šire Azure AI Content Safety suite, koja pruža dodatne alate za otkrivanje pokušaja jailbreaka, štetnog sadržaja i drugih sigurnosnih rizika u AI aplikacijama.

Više o AI prompt shields pročitajte u [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.hr.png)

### Sigurnost lanca opskrbe

Sigurnost lanca opskrbe ostaje temeljna u AI eri, no opseg onoga što se smatra vašim lancem opskrbe se proširio. Osim tradicional
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Putovanje prema osiguranju lanca opskrbe softverom u Microsoftu](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Siguran pristup s najmanje privilegija (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Najbolje prakse za provjeru valjanosti tokena i njihovo trajanje](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Koristite sigurno spremište tokena i šifrirajte tokene (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management kao autentikacijski gateway za MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Najbolje sigurnosne prakse za MCP](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Korištenje Microsoft Entra ID za autentikaciju s MCP serverima](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Sljedeće

Sljedeće: [Poglavlje 3: Početak rada](/03-GettingStarted/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden pomoću AI prevoditeljskog servisa [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za važne informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.