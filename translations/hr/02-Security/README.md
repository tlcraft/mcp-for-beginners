<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c69f9df7f3215dac8d056020539bac36",
  "translation_date": "2025-07-04T19:10:17+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "hr"
}
-->
# Najbolje sigurnosne prakse

Usvajanje Model Context Protocol (MCP) donosi moćne nove mogućnosti za AI-pokretane aplikacije, ali također uvodi jedinstvene sigurnosne izazove koji nadilaze tradicionalne softverske rizike. Osim već poznatih problema poput sigurnog kodiranja, principa najmanjih privilegija i sigurnosti lanca opskrbe, MCP i AI radni opterećenja suočavaju se s novim prijetnjama kao što su prompt injection, trovanje alata i dinamičke izmjene alata. Ovi rizici mogu dovesti do krađe podataka, narušavanja privatnosti i neželjenog ponašanja sustava ako se ne upravlja pravilno.

Ova lekcija istražuje najvažnije sigurnosne rizike povezane s MCP-om — uključujući autentifikaciju, autorizaciju, pretjerane dozvole, indirektni prompt injection i ranjivosti u lancu opskrbe — te pruža praktične kontrole i najbolje prakse za njihovo ublažavanje. Također ćete naučiti kako iskoristiti Microsoftova rješenja poput Prompt Shields, Azure Content Safety i GitHub Advanced Security za jačanje vaše MCP implementacije. Razumijevanjem i primjenom ovih kontrola možete značajno smanjiti vjerojatnost sigurnosnog incidenta i osigurati da vaši AI sustavi ostanu pouzdani i otporni.

# Ciljevi učenja

Na kraju ove lekcije moći ćete:

- Prepoznati i objasniti jedinstvene sigurnosne rizike koje donosi Model Context Protocol (MCP), uključujući prompt injection, trovanje alata, pretjerane dozvole i ranjivosti u lancu opskrbe.
- Opisati i primijeniti učinkovite kontrole za ublažavanje sigurnosnih rizika MCP-a, poput snažne autentifikacije, principa najmanjih privilegija, sigurnog upravljanja tokenima i provjere lanca opskrbe.
- Razumjeti i iskoristiti Microsoftova rješenja poput Prompt Shields, Azure Content Safety i GitHub Advanced Security za zaštitu MCP i AI radnih opterećenja.
- Prepoznati važnost provjere metapodataka alata, praćenja dinamičkih promjena i obrane od indirektnih prompt injection napada.
- Integrirati uspostavljene sigurnosne najbolje prakse — poput sigurnog kodiranja, učvršćivanja poslužitelja i arhitekture nulte povjerenja — u vašu MCP implementaciju kako biste smanjili vjerojatnost i utjecaj sigurnosnih incidenata.

# MCP sigurnosne kontrole

Svaki sustav koji ima pristup važnim resursima nosi sa sobom određene sigurnosne izazove. Sigurnosni izazovi se općenito mogu riješiti pravilnom primjenom osnovnih sigurnosnih kontrola i koncepata. Kako je MCP tek nedavno definiran, specifikacija se brzo mijenja i protokol se razvija. S vremenom će sigurnosne kontrole unutar njega sazrijeti, omogućujući bolju integraciju s korporativnim i uspostavljenim sigurnosnim arhitekturama i najboljim praksama.

Istraživanje objavljeno u [Microsoft Digital Defense Report](https://aka.ms/mddr) navodi da bi 98% prijavljenih proboja bilo spriječeno robusnom sigurnosnom higijenom, a najbolja zaštita od bilo kakvog proboja je pravilno postavljanje osnovne sigurnosne higijene, najboljih praksi sigurnog kodiranja i sigurnosti lanca opskrbe — te provjerene prakse koje već poznajemo i koje i dalje imaju najveći utjecaj na smanjenje sigurnosnog rizika.

Pogledajmo neke od načina na koje možete početi rješavati sigurnosne rizike prilikom usvajanja MCP-a.

> **Note:** Sljedeće informacije su točne na dan **29. svibnja 2025.** MCP protokol se stalno razvija, a buduće implementacije mogu uvesti nove obrasce autentifikacije i kontrole. Za najnovije informacije i smjernice uvijek se obratite [MCP Specification](https://spec.modelcontextprotocol.io/) i službenom [MCP GitHub repozitoriju](https://github.com/modelcontextprotocol) te [stranici s najboljim sigurnosnim praksama](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Izjava problema  
Izvorna MCP specifikacija pretpostavljala je da će developeri sami napisati svoj autentifikacijski poslužitelj. To je zahtijevalo poznavanje OAuth-a i povezanih sigurnosnih ograničenja. MCP poslužitelji su djelovali kao OAuth 2.0 Authorization Servers, upravljajući potrebnom autentifikacijom korisnika izravno, umjesto da je delegiraju vanjskoj usluzi poput Microsoft Entra ID-a. Od **26. travnja 2025.**, ažuriranje MCP specifikacije omogućuje MCP poslužiteljima da delegiraju autentifikaciju korisnika vanjskoj usluzi.

### Rizici
- Pogrešno konfigurirana autorizacijska logika na MCP poslužitelju može dovesti do izlaganja osjetljivih podataka i nepravilno primijenjenih kontrola pristupa.
- Krađa OAuth tokena na lokalnom MCP poslužitelju. Ako je token ukraden, može se koristiti za lažno predstavljanje MCP poslužitelja i pristup resursima i podacima usluge za koju je token izdan.

#### Prosljeđivanje tokena
Prosljeđivanje tokena je izričito zabranjeno u autorizacijskoj specifikaciji jer uvodi niz sigurnosnih rizika, uključujući:

#### Zaobilaženje sigurnosnih kontrola
MCP poslužitelj ili downstream API-ji mogu implementirati važne sigurnosne kontrole poput ograničenja brzine, provjere zahtjeva ili nadzora prometa, koje ovise o publici tokena ili drugim ograničenjima vjerodajnica. Ako klijenti mogu dobiti i koristiti tokene izravno s downstream API-ja bez da ih MCP poslužitelj pravilno provjerava ili osigurava da su tokeni izdani za pravu uslugu, oni zaobilaze ove kontrole.

#### Problemi s odgovornošću i auditnim tragom
MCP poslužitelj neće moći identificirati ili razlikovati MCP klijente kada klijenti pozivaju s pristupnim tokenom izdanom upstream, koji može biti nečitljiv MCP poslužitelju.  
Dnevnici downstream Resource Servera mogu prikazivati zahtjeve koji izgledaju kao da dolaze iz drugog izvora s drugačijim identitetom, a ne od MCP poslužitelja koji zapravo prosljeđuje tokene.  
Oba faktora otežavaju istragu incidenata, kontrole i reviziju.  
Ako MCP poslužitelj prosljeđuje tokene bez provjere njihovih tvrdnji (npr. uloga, privilegija ili publike) ili drugih metapodataka, zlonamjerni akter u posjedu ukradenog tokena može koristiti poslužitelj kao proxy za krađu podataka.

#### Problemi s granicom povjerenja
Downstream Resource Server daje povjerenje određenim entitetima. Ovo povjerenje može uključivati pretpostavke o podrijetlu ili obrascima ponašanja klijenata. Kršenje ove granice povjerenja može dovesti do neočekivanih problema.  
Ako token prihvaćaju više usluga bez odgovarajuće provjere, napadač koji kompromitira jednu uslugu može koristiti token za pristup drugim povezanim uslugama.

#### Rizik buduće kompatibilnosti
Čak i ako MCP poslužitelj danas počne kao „čisti proxy“, možda će kasnije trebati dodati sigurnosne kontrole. Početak s pravilnim razdvajanjem publike tokena olakšava razvoj sigurnosnog modela.

### Kontrole za ublažavanje

**MCP poslužitelji NE SMIJU prihvaćati tokene koji nisu izričito izdani za MCP poslužitelj**

- **Pregledajte i učvrstite autorizacijsku logiku:** Pažljivo revidirajte implementaciju autorizacije na vašem MCP poslužitelju kako biste osigurali da samo namijenjeni korisnici i klijenti mogu pristupiti osjetljivim resursima. Za praktične smjernice pogledajte [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) i [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Provodite sigurne prakse upravljanja tokenima:** Slijedite [Microsoftove najbolje prakse za validaciju tokena i njihov životni vijek](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) kako biste spriječili zloupotrebu pristupnih tokena i smanjili rizik od ponovne upotrebe ili krađe tokena.
- **Zaštitite pohranu tokena:** Uvijek sigurno pohranjujte tokene i koristite enkripciju za njihovu zaštitu u mirovanju i tijekom prijenosa. Za savjete o implementaciji pogledajte [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Pretjerane dozvole za MCP poslužitelje

### Izjava problema  
MCP poslužiteljima mogu biti dodijeljene pretjerane dozvole za uslugu ili resurs kojem pristupaju. Na primjer, MCP poslužitelj koji je dio AI prodajne aplikacije koja se povezuje s korporativnom bazom podataka trebao bi imati pristup ograničen samo na prodajne podatke, a ne dozvolu za pristup svim datotekama u skladištu. Vraćajući se na princip najmanjih privilegija (jedan od najstarijih sigurnosnih principa), nijedan resurs ne bi trebao imati dozvole veće od onih potrebnih za izvršavanje zadataka za koje je namijenjen. AI predstavlja dodatni izazov u ovom području jer je zbog njegove fleksibilnosti teško precizno definirati potrebne dozvole.

### Rizici  
- Dodjeljivanje pretjeranih dozvola može omogućiti krađu ili izmjenu podataka kojima MCP poslužitelj nije trebao pristupiti. To također može predstavljati problem privatnosti ako se radi o osobnim podacima (PII).

### Kontrole za ublažavanje  
- **Primijenite princip najmanjih privilegija:** Dodijelite MCP poslužitelju samo minimalne dozvole potrebne za obavljanje njegovih zadataka. Redovito pregledavajte i ažurirajte ove dozvole kako biste osigurali da ne prelaze ono što je potrebno. Za detaljne smjernice pogledajte [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Koristite kontrolu pristupa temeljenu na ulogama (RBAC):** Dodijelite uloge MCP poslužitelju koje su strogo ograničene na određene resurse i radnje, izbjegavajući široke ili nepotrebne dozvole.
- **Nadzor i revizija dozvola:** Kontinuirano pratite korištenje dozvola i revidirajte zapise pristupa kako biste brzo otkrili i uklonili pretjerane ili neiskorištene privilegije.

# Indirektni prompt injection napadi

### Izjava problema

Zlonamjerni ili kompromitirani MCP poslužitelji mogu predstavljati značajne rizike izlaganjem podataka korisnika ili omogućavanjem neželjenih radnji. Ovi rizici su posebno relevantni u AI i MCP radnim opterećenjima, gdje:

- **Prompt Injection napadi:** Napadači ugrađuju zlonamjerne upute u promptove ili vanjski sadržaj, što uzrokuje da AI sustav izvrši neželjene radnje ili otkrije osjetljive podatke. Više informacija: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Trovanje alata:** Napadači manipuliraju metapodacima alata (poput opisa ili parametara) kako bi utjecali na ponašanje AI-ja, potencijalno zaobilazeći sigurnosne kontrole ili izvlačeći podatke. Detalji: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection:** Zlonamjerne upute ugrađene su u dokumente, web stranice ili e-mailove, koje AI potom obrađuje, što može dovesti do curenja podataka ili manipulacije.
- **Dinamičke izmjene alata (Rug Pulls):** Definicije alata mogu se mijenjati nakon odobrenja korisnika, uvodeći nove zlonamjerne radnje bez znanja korisnika.

Ove ranjivosti naglašavaju potrebu za robusnom validacijom, nadzorom i sigurnosnim kontrolama prilikom integracije MCP poslužitelja i alata u vaše okruženje. Za detaljnije informacije pogledajte povezane izvore gore.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.hr.png)

**Indirektni Prompt Injection** (poznat i kao cross-domain prompt injection ili XPIA) predstavlja kritičnu ranjivost u generativnim AI sustavima, uključujući one koji koriste Model Context Protocol (MCP). U ovom napadu, zlonamjerne upute skrivene su u vanjskom sadržaju — poput dokumenata, web stranica ili e-mailova. Kada AI sustav obrađuje taj sadržaj, može interpretirati ugrađene upute kao legitimne korisničke naredbe, što rezultira neželjenim radnjama poput curenja podataka, generiranja štetnog sadržaja ili manipulacije korisničkim interakcijama. Za detaljno objašnjenje i primjere iz stvarnog svijeta pogledajte [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Posebno opasna vrsta ovog napada je **Trovanje alata**. Ovdje napadači ubacuju zlonamjerne upute u metapodatke MCP alata (poput opisa alata ili parametara). Budući da veliki jezični modeli (LLM) koriste ove metapodatke za odlučivanje koje alate pozvati, kompromitirani opisi mogu prevariti model da izvrši neovlaštene pozive alata ili zaobiđe sigurnosne kontrole. Ove manipulacije često su nevidljive krajnjim korisnicima, ali ih AI sustav može interpretirati i na njih reagirati. Ovaj rizik je pojačan u hostiranim MCP okruženjima, gdje se definicije alata mogu mijenjati nakon odobrenja korisnika — scenarij poznat kao "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". U takvim slučajevima, alat koji je prethodno bio siguran može kasnije biti izmijenjen da izvršava zlonamjerne radnje, poput krađe podataka ili mijenjanja ponašanja sustava, bez znanja korisnika. Za više o ovom vektoru napada pogledajte [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.hr.png)

## Rizici  
Neželjene AI radnje predstavljaju različite sigurnosne rizike, uključujući krađu podataka i narušavanje privatnosti.

### Kontrole za ublažavanje  
### Korištenje prompt shields za zaštitu od indirektnih prompt injection napada
-----------------------------------------------------------------------------

**AI Prompt Shields** su rješenje koje je razvio Microsoft za obranu od izravnih i neizravnih prompt injection napada. Pomažu kroz:

1.  **Detekciju i filtriranje:** Prompt Shields koriste napredne algoritme strojnog učenja i obradu prirodnog jezika za otkrivanje i filtriranje zlonamjernih uputa ugrađenih u vanjski sadržaj, poput dokumenata, web stranica ili e-mailova.
    
2.  **Isticanje (Spotlighting):** Ova tehnika pomaže AI sustavu razlikovati valjane sistemske upute od potencijalno nepouzdanih vanjskih unosa. Transformiranjem ulaznog teksta na način koji ga čini relevantnijim za model, Spotlighting osigurava da AI bolje prepoznaje i ignorira zlonamjerne upute.
    
3.  **Razdjelnici i označavanje podataka (Delimiters and Datamarking):** Uključivanje razdjelnika u sistemsku poruku jasno označava lokaciju ulaznog teksta, pomažući AI sustavu da prepozna i odvoji korisničke unose od potencijalno štetnog vanjskog sadržaja. Datamarking proširuje ovaj koncept korištenjem posebnih oznaka za isticanje granica pouzdanih i nepouzdanih podataka.
    
4.  **Kontinuirani nadzor i ažuriranja:** Microsoft kontinuirano prati i ažurira Prompt Shields kako bi odgovorio na nove i razvijajuće prijetnje. Ovaj proaktivan pristup osigurava da obrane ostanu učinkovite protiv najnovijih tehnika napada.
    
5. **Integracija s Azure Content Safety:** Prompt Shields su dio šire Azure AI Content Safety platforme, koja pruža dodatne alate za otkrivanje pokušaja jailbreaka, štetnog sadržaja i drugih sigurnosnih rizika u AI aplikacijama.


Sigurnost lanca opskrbe ostaje temeljna u eri umjetne inteligencije, no opseg onoga što se smatra vašim lancem opskrbe se proširio. Osim tradicionalnih paketa koda, sada morate temeljito provjeravati i nadzirati sve AI-komponente, uključujući temeljne modele, usluge ugradnji (embeddings), pružatelje konteksta i API-je trećih strana. Svaka od ovih komponenti može unijeti ranjivosti ili rizike ako se ne upravlja pravilno.

**Ključne prakse sigurnosti lanca opskrbe za AI i MCP:**
- **Provjerite sve komponente prije integracije:** To uključuje ne samo open-source biblioteke, već i AI modele, izvore podataka i vanjske API-je. Uvijek provjerite podrijetlo, licencu i poznate ranjivosti.
- **Održavajte sigurne pipelineove za implementaciju:** Koristite automatizirane CI/CD pipelineove s integriranim sigurnosnim skeniranjem kako biste rano otkrili probleme. Osigurajte da se u produkciju implementiraju samo pouzdani artefakti.
- **Kontinuirano nadzirite i revidirajte:** Uvedite stalni nadzor svih ovisnosti, uključujući modele i usluge podataka, kako biste otkrili nove ranjivosti ili napade na lanac opskrbe.
- **Primijenite načelo najmanjih privilegija i kontrole pristupa:** Ograničite pristup modelima, podacima i uslugama samo na ono što je potrebno za rad vašeg MCP servera.
- **Brzo reagirajte na prijetnje:** Imate uspostavljen proces za zakrpu ili zamjenu kompromitiranih komponenti te za rotaciju tajni ili vjerodajnica ako se otkrije sigurnosni incident.

[GitHub Advanced Security](https://github.com/security/advanced-security) nudi značajke poput skeniranja tajni, skeniranja ovisnosti i CodeQL analize. Ovi alati se integriraju s [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) i [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) kako bi timovima pomogli u identificiranju i ublažavanju ranjivosti u kodu i AI komponentama lanca opskrbe.

Microsoft također interno primjenjuje opsežne prakse sigurnosti lanca opskrbe za sve proizvode. Saznajte više u [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Uspostavljene najbolje sigurnosne prakse koje će unaprijediti sigurnosni položaj vaše MCP implementacije

Svaka MCP implementacija nasljeđuje postojeći sigurnosni položaj okruženja vaše organizacije na kojem je izgrađena, stoga se pri razmatranju sigurnosti MCP-a kao dijela vaših ukupnih AI sustava preporučuje da unaprijedite svoj postojeći sigurnosni položaj. Sljedeće uspostavljene sigurnosne kontrole su posebno relevantne:

- Sigurne prakse kodiranja u vašoj AI aplikaciji – zaštita od [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 za LLM-ove](https://genai.owasp.org/download/43299/?tmstv=1731900559), korištenje sigurnih spremišta za tajne i tokene, implementacija end-to-end sigurnih komunikacija između svih komponenti aplikacije itd.
- Ojačavanje servera – koristite MFA gdje je moguće, redovito ažurirajte zakrpe, integrirajte server s pružateljem identiteta treće strane za pristup itd.
- Održavajte uređaje, infrastrukturu i aplikacije ažurnima s najnovijim zakrpama
- Sigurnosni nadzor – implementirajte evidentiranje i nadzor AI aplikacije (uključujući MCP klijente/servere) te šaljite te zapise u centralizirani SIEM za otkrivanje anomalnih aktivnosti
- Zero trust arhitektura – izolirajte komponente putem mrežnih i identitetskih kontrol na logičan način kako biste minimizirali lateralno kretanje u slučaju kompromitacije AI aplikacije.

# Ključni zaključci

- Osnove sigurnosti ostaju ključne: sigurno kodiranje, načelo najmanjih privilegija, provjera lanca opskrbe i kontinuirani nadzor su neophodni za MCP i AI radna opterećenja.
- MCP donosi nove rizike – poput prompt injectiona, trovanja alata i pretjeranih dozvola – koji zahtijevaju i tradicionalne i AI-specifične kontrole.
- Koristite robusne prakse autentikacije, autorizacije i upravljanja tokenima, koristeći vanjske pružatelje identiteta poput Microsoft Entra ID gdje je moguće.
- Zaštitite se od indirektnog prompt injectiona i trovanja alata provjerom metapodataka alata, nadzorom dinamičkih promjena i korištenjem rješenja poput Microsoft Prompt Shields.
- Sve komponente u vašem AI lancu opskrbe – uključujući modele, ugradnje i pružatelje konteksta – tretirajte s istom pažnjom kao i ovisnosti koda.
- Budite u toku s razvojem MCP specifikacija i doprinesite zajednici kako biste pomogli oblikovati sigurne standarde.

# Dodatni resursi

- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
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
- [MCP Security Best Practice](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Sljedeće

Sljedeće: [Chapter 3: Getting Started](../03-GettingStarted/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.