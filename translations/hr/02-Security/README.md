<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "382fddb4ee4d9c1bdc806e2ee99b70c8",
  "translation_date": "2025-07-17T12:12:23+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "hr"
}
-->
# Najbolje sigurnosne prakse

Usvajanje Model Context Protocola (MCP) donosi moćne nove mogućnosti za AI-pokretane aplikacije, ali također uvodi jedinstvene sigurnosne izazove koji nadilaze tradicionalne softverske rizike. Osim već poznatih problema poput sigurnog kodiranja, principa najmanjih privilegija i sigurnosti lanca opskrbe, MCP i AI radni opterećenja suočavaju se s novim prijetnjama kao što su prompt injection, trovanje alata, dinamičke izmjene alata, preuzimanje sesije, napadi zbunjenog zamjenika i ranjivosti u prijenosu tokena. Ovi rizici mogu dovesti do krađe podataka, narušavanja privatnosti i neželjenog ponašanja sustava ako se ne upravlja pravilno.

Ova lekcija istražuje najvažnije sigurnosne rizike povezane s MCP-om — uključujući autentifikaciju, autorizaciju, pretjerane dozvole, indirektni prompt injection, sigurnost sesije, probleme zbunjenog zamjenika, ranjivosti u prijenosu tokena i ranjivosti u lancu opskrbe — te pruža praktične kontrole i najbolje prakse za njihovo ublažavanje. Također ćete naučiti kako iskoristiti Microsoftova rješenja poput Prompt Shields, Azure Content Safety i GitHub Advanced Security za jačanje vaše MCP implementacije. Razumijevanjem i primjenom ovih kontrola možete značajno smanjiti vjerojatnost sigurnosnog incidenta i osigurati da vaši AI sustavi ostanu robusni i pouzdani.

# Ciljevi učenja

Na kraju ove lekcije moći ćete:

- Prepoznati i objasniti jedinstvene sigurnosne rizike koje donosi Model Context Protocol (MCP), uključujući prompt injection, trovanje alata, pretjerane dozvole, preuzimanje sesije, probleme zbunjenog zamjenika, ranjivosti u prijenosu tokena i ranjivosti u lancu opskrbe.
- Opisati i primijeniti učinkovite mjere za ublažavanje sigurnosnih rizika MCP-a, poput robusne autentifikacije, principa najmanjih privilegija, sigurnog upravljanja tokenima, kontrola sigurnosti sesije i provjere lanca opskrbe.
- Razumjeti i iskoristiti Microsoftova rješenja poput Prompt Shields, Azure Content Safety i GitHub Advanced Security za zaštitu MCP i AI radnih opterećenja.
- Prepoznati važnost provjere metapodataka alata, praćenja dinamičkih promjena, obrane od indirektnih prompt injection napada i sprječavanja preuzimanja sesije.
- Integrirati uspostavljene sigurnosne najbolje prakse — poput sigurnog kodiranja, učvršćivanja servera i arhitekture nulte povjerenja — u vašu MCP implementaciju kako biste smanjili vjerojatnost i utjecaj sigurnosnih incidenata.

# Sigurnosne kontrole MCP-a

Svaki sustav koji ima pristup važnim resursima nosi sa sobom sigurnosne izazove. Sigurnosni izazovi se općenito mogu riješiti pravilnom primjenom osnovnih sigurnosnih kontrola i koncepata. Kako je MCP tek nedavno definiran, specifikacija se brzo mijenja i razvija. S vremenom će sigurnosne kontrole unutar protokola sazrijeti, omogućujući bolju integraciju s korporativnim i uspostavljenim sigurnosnim arhitekturama i najboljim praksama.

Istraživanje objavljeno u [Microsoft Digital Defense Report](https://aka.ms/mddr) navodi da bi 98% prijavljenih proboja bilo spriječeno robusnom sigurnosnom higijenom, a najbolja zaštita od bilo kakvog proboja je pravilno postavljanje osnovne sigurnosne higijene, najboljih praksi sigurnog kodiranja i sigurnosti lanca opskrbe — te provjerene prakse koje i dalje imaju najveći utjecaj na smanjenje sigurnosnih rizika.

Pogledajmo neke od načina na koje možete početi rješavati sigurnosne rizike prilikom usvajanja MCP-a.

> **[!NOTE]** Sljedeće informacije su točne na dan **29. svibnja 2025.** MCP protokol se stalno razvija, a buduće implementacije mogu uvesti nove obrasce autentifikacije i kontrole. Za najnovije informacije i smjernice uvijek se obratite [MCP specifikaciji](https://spec.modelcontextprotocol.io/) te službenom [MCP GitHub spremištu](https://github.com/modelcontextprotocol) i [stranici s najboljim sigurnosnim praksama](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Izjava problema  
Izvorna MCP specifikacija pretpostavljala je da će programeri sami napisati svoj autentifikacijski server. To je zahtijevalo poznavanje OAuth-a i povezanih sigurnosnih ograničenja. MCP serveri su djelovali kao OAuth 2.0 Authorization Serveri, upravljajući potrebnom autentifikacijom korisnika izravno, umjesto da je delegiraju vanjskoj usluzi poput Microsoft Entra ID-a. Od **26. travnja 2025.** ažuriranje MCP specifikacije omogućuje MCP serverima da delegiraju autentifikaciju korisnika vanjskoj usluzi.

### Rizici
- Pogrešno konfigurirana autorizacijska logika na MCP serveru može dovesti do izlaganja osjetljivih podataka i nepravilno primijenjenih kontrola pristupa.
- Krađa OAuth tokena na lokalnom MCP serveru. Ako je token ukraden, može se koristiti za lažno predstavljanje MCP servera i pristup resursima i podacima usluge za koju je token izdan.

#### Token Passthrough  
Token passthrough je izričito zabranjen u autorizacijskoj specifikaciji jer uvodi niz sigurnosnih rizika, uključujući:

#### Zaobilaženje sigurnosnih kontrola  
MCP server ili downstream API-ji mogu implementirati važne sigurnosne kontrole poput ograničenja brzine, validacije zahtjeva ili nadzora prometa, koje ovise o publici tokena ili drugim uvjetima vjerodajnica. Ako klijenti mogu izravno dobiti i koristiti tokene s downstream API-ja bez da ih MCP server pravilno validira ili osigura da su tokeni izdani za pravu uslugu, oni zaobilaze ove kontrole.

#### Problemi s odgovornošću i auditnim tragom  
MCP server neće moći identificirati ili razlikovati MCP klijente kada klijenti pozivaju s pristupnim tokenom izdanom upstream, koji može biti nečitljiv MCP serveru.  
Zapisi downstream Resource Servera mogu prikazivati zahtjeve koji izgledaju kao da dolaze iz drugog izvora s drugačijim identitetom, a ne od MCP servera koji zapravo prosljeđuje tokene.  
Oba faktora otežavaju istragu incidenata, kontrole i reviziju.  
Ako MCP server prosljeđuje tokene bez validacije njihovih tvrdnji (npr. uloga, privilegija ili publike) ili drugih metapodataka, zlonamjerni akter u posjedu ukradenog tokena može koristiti server kao proxy za krađu podataka.

#### Problemi s granicom povjerenja  
Downstream Resource Server daje povjerenje određenim entitetima. Ovo povjerenje može uključivati pretpostavke o podrijetlu ili obrascima ponašanja klijenta. Kršenje ove granice povjerenja može dovesti do neočekivanih problema.  
Ako token prihvaćaju više usluga bez pravilne validacije, napadač koji kompromitira jednu uslugu može koristiti token za pristup drugim povezanim uslugama.

#### Rizik buduće kompatibilnosti  
Čak i ako MCP server danas počne kao "čisti proxy", možda će kasnije trebati dodati sigurnosne kontrole. Početak s pravilnim razdvajanjem publike tokena olakšava razvoj sigurnosnog modela.

### Mjere ublažavanja

**MCP serveri NE SMIJU prihvaćati tokene koji nisu izričito izdani za MCP server**

- **Pregledajte i učvrstite autorizacijsku logiku:** Pažljivo pregledajte implementaciju autorizacije na vašem MCP serveru kako biste osigurali da samo namijenjeni korisnici i klijenti mogu pristupiti osjetljivim resursima. Za praktične smjernice pogledajte [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) i [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Provodite sigurne prakse upravljanja tokenima:** Slijedite [Microsoftove najbolje prakse za validaciju tokena i njihov životni vijek](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) kako biste spriječili zloupotrebu pristupnih tokena i smanjili rizik od ponovne upotrebe ili krađe tokena.
- **Zaštitite pohranu tokena:** Uvijek sigurno pohranjujte tokene i koristite enkripciju za njihovu zaštitu u mirovanju i tijekom prijenosa. Za savjete o implementaciji pogledajte [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Pretjerane dozvole za MCP servere

### Izjava problema  
MCP serverima mogu biti dodijeljene pretjerane dozvole za uslugu ili resurs kojem pristupaju. Na primjer, MCP server koji je dio AI prodajne aplikacije koja se povezuje s poduzećem za pohranu podataka trebao bi imati pristup ograničen na prodajne podatke, a ne dozvolu za pristup svim datotekama u pohrani. Vraćajući se na princip najmanjih privilegija (jedan od najstarijih sigurnosnih principa), nijedan resurs ne bi trebao imati dozvole veće od onih potrebnih za izvršavanje zadataka za koje je namijenjen. AI predstavlja dodatni izazov u ovom području jer je zbog njegove fleksibilnosti teško precizno definirati potrebne dozvole.

### Rizici  
- Dodjeljivanje pretjeranih dozvola može omogućiti krađu ili izmjenu podataka kojima MCP server nije trebao pristupiti. To također može predstavljati problem privatnosti ako se radi o osobnim podacima (PII).

### Mjere ublažavanja  
- **Primijenite princip najmanjih privilegija:** Dodijelite MCP serveru samo minimalne dozvole potrebne za obavljanje njegovih zadataka. Redovito pregledavajte i ažurirajte ove dozvole kako biste osigurali da ne prelaze ono što je potrebno. Za detaljne smjernice pogledajte [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Koristite kontrolu pristupa temeljenu na ulogama (RBAC):** Dodijelite uloge MCP serveru koje su strogo ograničene na određene resurse i radnje, izbjegavajući široke ili nepotrebne dozvole.
- **Nadzor i revizija dozvola:** Kontinuirano pratite korištenje dozvola i revidirajte zapise pristupa kako biste brzo otkrili i uklonili pretjerane ili neiskorištene privilegije.

# Indirektni prompt injection napadi

### Izjava problema

Zlonamjerni ili kompromitirani MCP serveri mogu predstavljati značajne rizike izlaganjem podataka korisnika ili omogućavanjem neželjenih radnji. Ovi rizici su posebno relevantni u AI i MCP radnim opterećenjima, gdje:

- **Prompt Injection napadi:** Napadači ugrađuju zlonamjerne upute u promptove ili vanjski sadržaj, što uzrokuje da AI sustav izvrši neželjene radnje ili otkrije osjetljive podatke. Više informacija: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Trovanje alata:** Napadači manipuliraju metapodacima alata (poput opisa ili parametara) kako bi utjecali na ponašanje AI-ja, potencijalno zaobilazeći sigurnosne kontrole ili izvlačeći podatke. Detalji: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection:** Zlonamjerne upute ugrađene su u dokumente, web stranice ili e-mailove, koje AI potom obrađuje, što može dovesti do curenja podataka ili manipulacije.
- **Dinamičke izmjene alata (Rug Pulls):** Definicije alata mogu se mijenjati nakon odobrenja korisnika, uvodeći nove zlonamjerne radnje bez znanja korisnika.

Ove ranjivosti naglašavaju potrebu za robusnom validacijom, nadzorom i sigurnosnim kontrolama prilikom integracije MCP servera i alata u vaše okruženje. Za detaljnije informacije pogledajte povezane izvore gore.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.hr.png)

**Indirektni Prompt Injection** (poznat i kao cross-domain prompt injection ili XPIA) je kritična ranjivost u generativnim AI sustavima, uključujući one koji koriste Model Context Protocol (MCP). U ovom napadu, zlonamjerne upute skrivene su u vanjskom sadržaju — poput dokumenata, web stranica ili e-mailova. Kada AI sustav obrađuje taj sadržaj, može interpretirati ugrađene upute kao legitimne korisničke naredbe, što rezultira neželjenim radnjama poput curenja podataka, generiranja štetnog sadržaja ili manipulacije korisničkim interakcijama. Za detaljno objašnjenje i primjere iz stvarnog svijeta, pogledajte [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Posebno opasna vrsta ovog napada je **Trovanje alata**. Ovdje napadači ubacuju zlonamjerne upute u metapodatke MCP alata (poput opisa alata ili parametara). Budući da veliki jezični modeli (LLM) koriste ove metapodatke za odlučivanje koje alate pozvati, kompromitirani opisi mogu prevariti model da izvrši neovlaštene pozive alata ili zaobiđe sigurnosne kontrole. Ove manipulacije često su nevidljive krajnjim korisnicima, ali ih AI sustav može interpretirati i na njih reagirati. Ovaj rizik je pojačan u hostiranim MCP server okruženjima, gdje se definicije alata mogu ažurirati nakon odobrenja korisnika — scenarij poznat kao "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". U takvim slučajevima, alat koji je prethodno bio siguran može kasnije biti izmijenjen da izvršava zlonamjerne radnje, poput krađe podataka ili mijenjanja ponašanja sustava, bez znanja korisnika. Za više o ovom vektoru napada pogledajte [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.hr.png)

## Rizici  
Neželjene AI radnje predstavljaju različite sigurnosne rizike, uključujući krađu podataka i narušavanje privatnosti.

### Mjere ublažavanja  
### Korištenje prompt shields za zaštitu od indirektnih prompt injection napada  
-----------------------------------------------------------------------------

**AI Prompt Shields** su rješenje koje je razvio Microsoft za obranu od izravnih i neizravnih prompt injection napada. Pomažu kroz:

1.  **Detekciju i filtriranje:** Prompt Shields koriste napredne algoritme strojnog učenja i obradu prirodnog jezika za otkrivanje i filtriranje zlonamjernih uputa ugrađenih u vanjski sadržaj, poput dokumenata, web stranica ili e-mailova.
    
2.  **Isticanje (Spotlighting):** Ova tehnika pomaže AI sustavu razlikovati valjane sistemske upute od potencijalno nepouzdanih vanjskih unosa. Transformiranjem ulaznog teksta na način koji ga čini relevantnijim za model, Spotlighting osigurava da AI bolje prepozna i ignorira zlonamjerne upute.
    
3.  **Ograničivači i označavanje podataka (Delimiters and Datamarking):** Uključivanje ograničivača u sistemsku poruku jasno označava mjesto ulaznog teksta, pomažući AI sustavu da prepozna i odvoji korisničke unose od potencijalno štetnog vanjskog sadržaja. Datamarking proširuje ovaj koncept korištenjem posebnih oznaka za isticanje granica pouzdanih i nepouzdanih podataka.
    
4.  **Kontinuirani nadzor i ažuriranja:** Microsoft kontinuirano prati i ažurira Prompt Shields kako bi odgovorio na nove i razvijajuće prijetnje. Ovaj proaktivan pristup osigurava da obrane ostanu učinkovite protiv najnovijih tehnika napada.
    
5. **Integracija s Azure Content Safety:** Prompt Shields su dio šire Azure AI Content Safety platform
Problem "confused deputy" je sigurnosna ranjivost koja se javlja kada MCP poslužitelj djeluje kao posrednik između MCP klijenata i API-ja trećih strana. Ova ranjivost može se iskoristiti kada MCP poslužitelj koristi statički client ID za autentifikaciju kod treće strane koja nema podršku za dinamičku registraciju klijenata.

### Rizici

- **Zaobilaženje pristanka putem kolačića**: Ako se korisnik prethodno autentificirao preko MCP proxy poslužitelja, poslužitelj za autorizaciju treće strane može postaviti kolačić pristanka u korisnikov preglednik. Napadač to može iskoristiti slanjem zlonamjerne poveznice s izrađenim zahtjevom za autorizaciju koji sadrži zlonamjernu URI za preusmjeravanje.
- **Krađa autorizacijskog koda**: Kada korisnik klikne na zlonamjernu poveznicu, poslužitelj za autorizaciju treće strane može preskočiti zaslon za pristanak zbog postojećeg kolačića, a autorizacijski kod može biti preusmjeren na napadačev poslužitelj.
- **Neovlašteni pristup API-ju**: Napadač može zamijeniti ukradeni autorizacijski kod za pristupne tokene i lažno se predstavljati kao korisnik kako bi pristupio API-ju treće strane bez izričitog odobrenja.

### Mjere ublažavanja

- **Zahtjevi za izričitim pristankom**: MCP proxy poslužitelji koji koriste statičke client ID-jeve **MORAJU** dobiti pristanak korisnika za svakog dinamički registriranog klijenta prije prosljeđivanja zahtjeva poslužiteljima za autorizaciju trećih strana.
- **Ispravna implementacija OAuth-a**: Slijedite najbolje sigurnosne prakse OAuth 2.1, uključujući korištenje izazova koda (PKCE) za zahtjeve autorizacije kako biste spriječili napade presretanja.
- **Validacija klijenata**: Implementirajte strogu validaciju URI-ja za preusmjeravanje i identifikatora klijenata kako biste spriječili iskorištavanje od strane zlonamjernih aktera.


# Ranljivosti pri prosljeđivanju tokena

### Opis problema

"Token passthrough" je anti-obrazac u kojem MCP poslužitelj prihvaća tokene od MCP klijenta bez provjere jesu li ti tokeni ispravno izdani za sam MCP poslužitelj, a zatim ih "prosljeđuje" prema nižim API-jima. Ova praksa izričito krši MCP specifikaciju autorizacije i uvodi ozbiljne sigurnosne rizike.

### Rizici

- **Zaobilaženje sigurnosnih kontrola**: Klijenti bi mogli zaobići važne sigurnosne kontrole poput ograničenja brzine, validacije zahtjeva ili nadzora prometa ako mogu koristiti tokene izravno s nižim API-jima bez odgovarajuće provjere.
- **Problemi s odgovornošću i revizijom**: MCP poslužitelj neće moći identificirati ili razlikovati MCP klijente kada klijenti koriste pristupne tokene izdane na višoj razini, što otežava istrage incidenata i reviziju.
- **Eksfiltracija podataka**: Ako se tokeni prosljeđuju bez odgovarajuće validacije tvrdnji, zlonamjerni akter s ukradenim tokenom mogao bi koristiti poslužitelj kao proxy za iznošenje podataka.
- **Kršenje granica povjerenja**: Poslužitelji resursa na nižim razinama mogu davati povjerenje određenim entitetima s pretpostavkama o podrijetlu ili obrascima ponašanja. Kršenje ove granice može dovesti do neočekivanih sigurnosnih problema.
- **Nepravilna upotreba tokena u više servisa**: Ako tokeni budu prihvaćeni od strane više servisa bez odgovarajuće validacije, napadač koji kompromitira jedan servis mogao bi koristiti token za pristup drugim povezanim servisima.

### Mjere ublažavanja

- **Validacija tokena**: MCP poslužitelji **NE SMIJU** prihvaćati tokene koji nisu izričito izdani za sam MCP poslužitelj.
- **Provjera publike (audience)**: Uvijek provjeravajte da tokeni imaju ispravnu tvrdnju o publici koja odgovara identitetu MCP poslužitelja.
- **Ispravno upravljanje životnim ciklusom tokena**: Implementirajte kratkotrajne pristupne tokene i pravilne prakse rotacije tokena kako biste smanjili rizik od krađe i zloupotrebe tokena.


# Otimanje sesije

### Opis problema

Otimanje sesije je napad u kojem klijent dobije ID sesije od poslužitelja, a neovlaštena osoba pribavi i koristi isti ID sesije kako bi se lažno predstavila kao originalni klijent i izvršila neovlaštene radnje u njegovo ime. Ovo je posebno zabrinjavajuće kod serverskih sustava koji drže stanje (stateful) i obrađuju MCP zahtjeve.

### Rizici

- **Umetanje zlonamjernih događaja putem otetih sesija**: Napadač koji pribavi ID sesije može poslati zlonamjerne događaje poslužitelju koji dijeli stanje sesije s poslužiteljem na koji je klijent spojen, potencijalno pokrećući štetne radnje ili pristup osjetljivim podacima.
- **Lažno predstavljanje putem otete sesije**: Napadač s ukradenim ID-jem sesije može izravno pozivati MCP poslužitelj, zaobilazeći autentifikaciju i tretirajući se kao legitimni korisnik.
- **Kompromitirani nastavci prijenosa podataka**: Kada poslužitelj podržava ponovno dostavljanje ili nastavak prijenosa podataka, napadač može prerano prekinuti zahtjev, što može dovesti do njegovog nastavka kasnije od strane originalnog klijenta s potencijalno zlonamjernim sadržajem.

### Mjere ublažavanja

- **Provjera autorizacije**: MCP poslužitelji koji implementiraju autorizaciju **MORAJU** provjeravati sve dolazne zahtjeve i **NE SMIJU** koristiti sesije za autentifikaciju.
- **Sigurni ID-jevi sesije**: MCP poslužitelji **MORAJU** koristiti sigurne, nedeterminističke ID-jeve sesije generirane sigurnim generatorima slučajnih brojeva. Izbjegavajte predvidljive ili sekvencijalne identifikatore.
- **Povezivanje sesije s korisnikom**: MCP poslužitelji **BIH** trebali povezati ID-jeve sesije s informacijama specifičnim za korisnika, kombinirajući ID sesije s jedinstvenim podacima o autoriziranom korisniku (npr. njihovim internim korisničkim ID-jem) u formatu `
<user_id>:<session_id>`.
- **Istek sesije**: Implementirajte pravilno istekanje i rotaciju sesija kako biste ograničili vremenski okvir ranjivosti u slučaju kompromitacije ID-ja sesije.
- **Sigurnost prijenosa**: Uvijek koristite HTTPS za svu komunikaciju kako biste spriječili presretanje ID-ja sesije.


# Sigurnost lanca opskrbe

Sigurnost lanca opskrbe ostaje temeljna u eri umjetne inteligencije, no opseg onoga što se smatra vašim lancem opskrbe se proširio. Osim tradicionalnih paketa koda, sada morate strogo provjeravati i nadzirati sve AI-komponente, uključujući temeljne modele, usluge ugradnje (embeddings), pružatelje konteksta i API-je trećih strana. Svaka od ovih komponenti može unijeti ranjivosti ili rizike ako se ne upravlja pravilno.

**Ključne prakse sigurnosti lanca opskrbe za AI i MCP:**
- **Provjerite sve komponente prije integracije:** To uključuje ne samo open-source biblioteke, već i AI modele, izvore podataka i vanjske API-je. Uvijek provjerite podrijetlo, licencu i poznate ranjivosti.
- **Održavajte sigurne pipelineove za implementaciju:** Koristite automatizirane CI/CD pipelineove s integriranim sigurnosnim skeniranjem za rano otkrivanje problema. Osigurajte da se u produkciju implementiraju samo pouzdani artefakti.
- **Kontinuirano nadzirite i revidirajte:** Implementirajte stalni nadzor svih ovisnosti, uključujući modele i podatkovne usluge, kako biste otkrili nove ranjivosti ili napade na lanac opskrbe.
- **Primijenite načelo najmanjih privilegija i kontrole pristupa:** Ograničite pristup modelima, podacima i uslugama samo na ono što je potrebno za rad MCP poslužitelja.
- **Brzo reagirajte na prijetnje:** Imate proces za zakrpu ili zamjenu kompromitiranih komponenti te za rotaciju tajni ili vjerodajnica ako se otkrije sigurnosni incident.

[GitHub Advanced Security](https://github.com/security/advanced-security) nudi značajke poput skeniranja tajni, skeniranja ovisnosti i CodeQL analize. Ovi alati se integriraju s [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) i [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) kako bi pomogli timovima u otkrivanju i ublažavanju ranjivosti u kodu i AI komponentama lanca opskrbe.

Microsoft također interno provodi opsežne prakse sigurnosti lanca opskrbe za sve proizvode. Više saznajte u [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Uspostavljene najbolje sigurnosne prakse koje će unaprijediti sigurnosni položaj vaše MCP implementacije

Svaka MCP implementacija nasljeđuje postojeći sigurnosni položaj okruženja vaše organizacije na kojem je izgrađena, stoga se pri razmatranju sigurnosti MCP-a kao dijela vaših ukupnih AI sustava preporučuje podizanje ukupnog postojećeg sigurnosnog položaja. Sljedeće uspostavljene sigurnosne kontrole su posebno relevantne:

- Najbolje prakse sigurnog kodiranja u vašoj AI aplikaciji – zaštita od [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 za LLM-ove](https://genai.owasp.org/download/43299/?tmstv=1731900559), korištenje sigurnih spremišta za tajne i tokene, implementacija end-to-end sigurnih komunikacija između svih komponenti aplikacije itd.
- Ojačavanje poslužitelja – koristite MFA gdje je moguće, redovito ažurirajte zakrpe, integrirajte poslužitelj s vanjskim pružateljem identiteta za pristup itd.
- Održavajte uređaje, infrastrukturu i aplikacije ažurnima s najnovijim zakrpama
- Sigurnosni nadzor – implementirajte evidentiranje i nadzor AI aplikacije (uključujući MCP klijente/poslužitelje) te šaljite te zapise u centralizirani SIEM za otkrivanje anomalnih aktivnosti
- Arhitektura nulte povjerenja – izolirajte komponente putem mrežnih i identitetskih kontrol na logičan način kako biste minimizirali lateralno kretanje u slučaju kompromitacije AI aplikacije.

# Ključne poruke

- Osnove sigurnosti ostaju ključne: Sigurno kodiranje, načelo najmanjih privilegija, provjera lanca opskrbe i kontinuirani nadzor su neophodni za MCP i AI radna opterećenja.
- MCP donosi nove rizike — poput umetanja prompta, trovanja alata, otimanja sesije, problema confused deputy, ranjivosti pri prosljeđivanju tokena i pretjeranih dozvola — koji zahtijevaju i tradicionalne i AI-specifične kontrole.
- Koristite robusne prakse autentifikacije, autorizacije i upravljanja tokenima, koristeći vanjske pružatelje identiteta poput Microsoft Entra ID gdje je moguće.
- Zaštitite se od indirektnog umetanja prompta i trovanja alata validacijom metapodataka alata, nadzorom dinamičkih promjena i korištenjem rješenja poput Microsoft Prompt Shields.
- Implementirajte sigurnu upravu sesijama koristeći nedeterminističke ID-jeve sesije, povezivanje sesija s identitetima korisnika i nikada ne koristite sesije za autentifikaciju.
- Spriječite napade confused deputy zahtijevajući izričit pristanak korisnika za svakog dinamički registriranog klijenta i implementirajući ispravne OAuth sigurnosne prakse.
- Izbjegavajte ranjivosti pri prosljeđivanju tokena osiguravajući da MCP poslužitelji prihvaćaju samo tokene izričito izdane za njih i da pravilno validiraju tvrdnje tokena.
- Sve komponente u vašem AI lancu opskrbe — uključujući modele, ugradnje i pružatelje konteksta — tretirajte s istom pažnjom kao i ovisnosti koda.
- Budite u toku s razvojem MCP specifikacija i doprinosite zajednici kako biste pomogli oblikovati sigurne standarde.

# Dodatni resursi

## Vanjski resursi
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

## Dodatni sigurnosni dokumenti

Za detaljnije sigurnosne smjernice, molimo pogledajte ove dokumente:

- [MCP Security Best Practices 2025](./mcp-security-best-practices-2025.md) - Sveobuhvatan popis najboljih sigurnosnih praksi za MCP implementacije
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md) - Primjeri implementacije integracije Azure Content Safety s MCP poslužiteljima
- [MCP Security Controls 2025](./mcp-security-controls-2025.md) - Najnovije sigurnosne kontrole i tehnike za osiguranje MCP implementacija
- [MCP Best Practices](./mcp-best-practices.md) - Brzi vodič za sigurnost MCP-a

### Sljedeće

Sljedeće: [Poglavlje 3: Početak rada](../03-GettingStarted/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.