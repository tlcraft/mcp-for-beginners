<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00aedb7b1d11b7eaacb0618d8791c65",
  "translation_date": "2025-05-29T23:38:44+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "sr"
}
-->
# Najbolje prakse za bezbednost

Usvajanje Model Context Protocol-a (MCP) donosi moćne nove mogućnosti za AI aplikacije, ali takođe uvodi i jedinstvene bezbednosne izazove koji prevazilaze tradicionalne softverske rizike. Pored uobičajenih pitanja kao što su sigurno programiranje, princip najmanjih privilegija i bezbednost lanca snabdevanja, MCP i AI zadaci suočavaju se sa novim pretnjama kao što su prompt injection, trovanje alata i dinamičke izmene alata. Ovi rizici mogu dovesti do krađe podataka, narušavanja privatnosti i neželjenog ponašanja sistema ako se ne upravlja na pravi način.

Ova lekcija istražuje najvažnije bezbednosne rizike povezane sa MCP-om — uključujući autentifikaciju, autorizaciju, prekomerne privilegije, indirektni prompt injection i ranjivosti u lancu snabdevanja — i pruža praktične kontrole i najbolje prakse za njihovo ublažavanje. Takođe ćete naučiti kako da iskoristite Microsoft rešenja kao što su Prompt Shields, Azure Content Safety i GitHub Advanced Security za jačanje vaše MCP implementacije. Razumevanjem i primenom ovih kontrola, možete značajno smanjiti verovatnoću bezbednosnih incidenata i osigurati da vaši AI sistemi ostanu pouzdani i stabilni.

# Ciljevi učenja

Na kraju ove lekcije bićete u stanju da:

- Identifikujete i objasnite jedinstvene bezbednosne rizike koje donosi Model Context Protocol (MCP), uključujući prompt injection, trovanje alata, prekomerne privilegije i ranjivosti u lancu snabdevanja.
- Opišete i primenite efikasne kontrole za ublažavanje MCP bezbednosnih rizika, kao što su robusna autentifikacija, princip najmanjih privilegija, sigurno upravljanje tokenima i verifikacija lanca snabdevanja.
- Razumete i koristite Microsoft rešenja poput Prompt Shields, Azure Content Safety i GitHub Advanced Security za zaštitu MCP i AI zadataka.
- Prepoznate važnost validacije metapodataka alata, praćenja dinamičkih promena i odbrane od indirektnih prompt injection napada.
- Integrirate uspostavljene bezbednosne prakse — kao što su sigurno programiranje, jačanje servera i zero trust arhitektura — u vašu MCP implementaciju kako biste smanjili verovatnoću i posledice bezbednosnih incidenata.

# MCP bezbednosne kontrole

Svaki sistem koji ima pristup važnim resursima nosi sa sobom bezbednosne izazove. Ovi izazovi se uglavnom mogu rešiti pravilnom primenom osnovnih bezbednosnih kontrola i koncepata. Kako je MCP tek nedavno definisan, specifikacija se brzo menja i razvija. Vremenom će bezbednosne kontrole unutar protokola sazreti, omogućavajući bolju integraciju sa enterprise i postojećim bezbednosnim arhitekturama i najboljim praksama.

Istraživanje objavljeno u [Microsoft Digital Defense Report](https://aka.ms/mddr) navodi da bi 98% prijavljenih bezbednosnih incidenata bilo sprečeno primenom snažne bezbednosne higijene, a najbolja zaštita od bilo kakvog incidenta je da pravilno uspostavite osnovnu bezbednosnu higijenu, najbolje prakse sigurnog programiranja i bezbednost lanca snabdevanja — te proverenih i isprobanih praksi koje i dalje imaju najveći uticaj na smanjenje rizika.

Pogledajmo neke od načina na koje možete početi da rešavate bezbednosne rizike prilikom usvajanja MCP-a.

> **[!NOTE]** Sledeće informacije su tačne zaključno sa **29. maj 2025**. MCP protokol se stalno razvija, i buduće implementacije mogu uvesti nove obrasce autentifikacije i kontrole. Za najnovije informacije i smernice uvek se obratite [MCP specifikaciji](https://spec.modelcontextprotocol.io/) i zvaničnom [MCP GitHub repozitorijumu](https://github.com/modelcontextprotocol) kao i [stranici sa najboljim bezbednosnim praksama](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Problem

Originalna MCP specifikacija je pretpostavljala da će developeri sami pisati server za autentifikaciju. To je zahtevalo znanje o OAuth-u i povezanim bezbednosnim ograničenjima. MCP serveri su delovali kao OAuth 2.0 Authorization Server-i, upravljajući potrebnom autentifikacijom korisnika direktno, umesto da je delegiraju eksternoj usluzi kao što je Microsoft Entra ID. Od **26. aprila 2025** uvedena je izmena u MCP specifikaciji koja omogućava MCP serverima da delegiraju autentifikaciju korisnika eksternoj usluzi.

### Rizici

- Pogrešno konfigurisana autorizaciona logika na MCP serveru može dovesti do izlaganja osetljivih podataka i nepravilno primenjenih kontrola pristupa.
- Krađa OAuth tokena na lokalnom MCP serveru. Ako je token ukraden, može se koristiti za lažno predstavljanje MCP servera i pristup resursima i podacima za koje je token izdat.

#### Token Passthrough

Token passthrough je izričito zabranjen u autorizacionoj specifikaciji jer uvodi niz bezbednosnih rizika, uključujući:

#### Zaobilaženje bezbednosnih kontrola

MCP server ili downstream API-ji mogu implementirati važne bezbednosne kontrole kao što su ograničenje brzine zahteva, validacija zahteva ili praćenje saobraćaja, koje zavise od publike tokena ili drugih ograničenja kredencijala. Ako klijenti mogu direktno pribaviti i koristiti tokene sa downstream API-ja bez pravilne validacije od strane MCP servera ili bez provere da li su tokeni izdate za odgovarajuću uslugu, oni zaobilaze ove kontrole.

#### Problemi sa odgovornošću i audit tragom

MCP server neće moći da identifikuje ili razlikuje MCP klijente kada klijenti koriste pristupni token izdat upstream, koji može biti nečitljiv za MCP server. Logovi downstream Resource Server-a mogu prikazivati zahteve koji deluju kao da dolaze sa drugog izvora sa drugačijim identitetom, umesto od MCP servera koji zapravo prosleđuje tokene. Ovi faktori otežavaju istragu incidenata, kontrole i reviziju. Ako MCP server prosleđuje tokene bez validacije njihovih tvrdnji (npr. uloga, privilegija ili publike) ili drugih metapodataka, zlonamerni korisnik sa ukradenim tokenom može koristiti server kao posrednika za krađu podataka.

#### Problemi sa granicom poverenja

Downstream Resource Server daje poverenje određenim entitetima. Ovo poverenje može uključivati pretpostavke o poreklu ili obrascima ponašanja klijenata. Kršenje ove granice poverenja može dovesti do neočekivanih problema. Ako token prihvata više servisa bez pravilne validacije, napadač koji kompromituje jedan servis može koristiti token za pristup drugim povezanim servisima.

#### Rizik buduće kompatibilnosti

Čak i ako MCP server danas funkcioniše kao „čisti proxy“, kasnije može biti potrebno da doda bezbednosne kontrole. Početak sa pravilnom separacijom publike tokena olakšava razvoj bezbednosnog modela.

### Kontrole za ublažavanje

**MCP serveri NE SMEJU prihvatati tokene koji nisu izričito izdate za MCP server**

- **Pregledajte i ojačajte autorizacionu logiku:** Pažljivo proverite implementaciju autorizacije na vašem MCP serveru kako biste osigurali da samo predviđeni korisnici i klijenti imaju pristup osetljivim resursima. Za praktične smernice pogledajte [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) i [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Primena sigurnih praksi za tokene:** Pridržavajte se [Microsoft-ovih najboljih praksi za validaciju i životni vek tokena](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) kako biste sprečili zloupotrebu pristupnih tokena i smanjili rizik od ponovne upotrebe ili krađe tokena.
- **Zaštita skladištenja tokena:** Uvek skladištite tokene na siguran način i koristite enkripciju za zaštitu podataka u mirovanju i prenosu. Za savete o implementaciji pogledajte [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Prekomerne privilegije za MCP servere

### Problem

MCP serverima može biti dodeljeno previše privilegija za servis ili resurs kojem pristupaju. Na primer, MCP server koji je deo AI aplikacije za prodaju i povezan je sa enterprise skladištem podataka, treba da ima pristup samo podacima vezanim za prodaju, a ne svim fajlovima u skladištu. Vraćajući se na princip najmanjih privilegija (jedan od najstarijih bezbednosnih principa), nijedan resurs ne bi trebalo da ima privilegije veće od onih koje su neophodne za izvršenje zadataka za koje je predviđen. AI predstavlja dodatni izazov jer je ponekad teško precizno definisati koje privilegije su potrebne da bi sistem bio fleksibilan.

### Rizici

- Dodeljivanje prekomernih privilegija može omogućiti iznošenje ili izmene podataka kojima MCP server nije trebalo da pristupa. Ovo može biti i problem privatnosti ukoliko se radi o ličnim podacima (PII).

### Kontrole za ublažavanje

- **Primena principa najmanjih privilegija:** Dodelite MCP serveru samo minimalne privilegije potrebne za obavljanje njegovih zadataka. Redovno proveravajte i ažurirajte ove privilegije da ne prelaze ono što je neophodno. Za detaljne smernice pogledajte [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Korišćenje Role-Based Access Control (RBAC):** Dodeljujte uloge MCP serveru koje su strogo ograničene na određene resurse i akcije, izbegavajući široke ili nepotrebne privilegije.
- **Praćenje i revizija privilegija:** Kontinuirano pratite korišćenje privilegija i revizirajte pristupne zapise kako biste brzo otkrili i otklonili prekomerne ili neiskorišćene privilegije.

# Indirektni prompt injection napadi

### Problem

Zlonamerni ili kompromitovani MCP serveri mogu predstavljati ozbiljan rizik izlaganjem korisničkih podataka ili omogućavanjem neželjenih akcija. Ovi rizici su posebno značajni u AI i MCP okruženjima, gde:

- **Prompt Injection napadi**: Napadači ugrađuju zlonamerne instrukcije u promptove ili spoljašnji sadržaj, što može naterati AI sistem da izvrši neželjene akcije ili otkrije osetljive podatke. Više informacija: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Trovanje alata**: Napadači manipulišu metapodacima alata (kao što su opisi ili parametri) da utiču na ponašanje AI-ja, potencijalno zaobilazeći bezbednosne kontrole ili izvlačeći podatke. Detalji: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection**: Zlonamerne instrukcije su ugrađene u dokumente, web stranice ili mejlove, koji se potom obrađuju od strane AI-ja, što može dovesti do curenja ili manipulacije podacima.
- **Dinamičke izmene alata (Rug Pulls)**: Definicije alata mogu biti menjane nakon odobrenja korisnika, uvodeći nove zlonamerne funkcionalnosti bez znanja korisnika.

Ove ranjivosti ističu potrebu za snažnom validacijom, praćenjem i bezbednosnim kontrolama prilikom integracije MCP servera i alata u vaše okruženje. Za dublju analizu, pogledajte gore navedene reference.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.sr.png)

**Indirektni Prompt Injection** (poznat i kao cross-domain prompt injection ili XPIA) predstavlja kritičnu ranjivost u generativnim AI sistemima, uključujući one koji koriste Model Context Protocol (MCP). U ovom napadu, zlonamerne instrukcije su skrivene u spoljnjem sadržaju — kao što su dokumenti, web stranice ili mejlovi. Kada AI sistem procesuira ovaj sadržaj, može interpretirati ugrađene instrukcije kao legitimne korisničke komande, što dovodi do neželjenih akcija kao što su curenje podataka, generisanje štetnog sadržaja ili manipulacija korisničkim interakcijama. Za detaljno objašnjenje i primere iz prakse, pogledajte [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Posebno opasna forma ovog napada je **Trovanje alata**. Ovde napadači ubacuju zlonamerne instrukcije u metapodatke MCP alata (kao što su opisi ili parametri). Pošto veliki jezički modeli (LLM) koriste ove metapodatke da odluče koje alate da pozovu, kompromitovani opisi mogu prevariti model da izvrši neautorizovane pozive alata ili zaobiđe bezbednosne kontrole. Ove manipulacije su često nevidljive krajnjim korisnicima, ali ih AI sistem može interpretirati i izvršiti. Rizik je pojačan u hostovanim MCP server okruženjima, gde definicije alata mogu biti ažurirane nakon korisničkog odobrenja — što se ponekad naziva "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". U takvim slučajevima, alat koji je prethodno bio siguran može kasnije biti izmenjen da izvršava zlonamerne radnje, poput krađe podataka ili menjanja ponašanja sistema, bez znanja korisnika. Za više informacija o ovom napadu pogledajte [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.sr.png)

## Rizici

Neželjene AI akcije predstavljaju različite bezbednosne rizike, uključujući krađu podataka i narušavanje privatnosti.

### Kontrole za ublažavanje

### Korišćenje prompt shields za zaštitu od indirektnih prompt injection napada
-----------------------------------------------------------------------------

**AI Prompt Shields** su rešenje koje je razvio Microsoft za odbranu od direktnih i indirektnih prompt injection napada. Oni pomažu kroz:

1.  **Detekciju i filtriranje**: Prompt Shields koriste napredne algoritme mašinskog učenja i obradu prirodnog jezika da otkriju i filtriraju zlonamerne instrukcije ugrađene u spoljašnji sadržaj, kao što su dokumenti, web stranice ili mejlovi.
    
2.  **Spotlighting**: Ova tehnika pomaže AI sistemu da razlikuje validne sistemske instrukcije od potencijalno nepouzdanih spoljašnjih ulaza. Transformacijom ulaznog teksta na način koji ga čini relevantnijim za model, Spotlighting omogućava AI-ju da bolje identifikuje i ignoriše zlonamerne instrukcije.
    
3.  **Delimitere i datamarking**: Uključivanje delimitera u sistemsku poruku jasno definiše lokaciju ulaznog teksta, pomažući AI sistemu da prepozna i odvoji korisničke ulaze od potencijalno štetnog spoljnog sadržaja. Datamarking proširuje ovaj koncept korišćenjem specijalnih markera za označavanje granica pouzdanih i nepouzdanih podataka.
    
4.  **Kontinuirano praćenje i ažuriranja**: Microsoft kontinuirano prati i ažurira Prompt Shields kako bi se suočio sa novim i evoluirajućim pretnjama. Ovaj proaktivan pristup osigurava da odbrane ostanu efikasne protiv najnovijih tehnika napada.
    
5. **Integracija sa Azure Content Safety:** Prompt Shields su deo šire Azure AI Content Safety platforme, koja pruža dodatne alate za detekciju pokušaja zaobilaženja zaštite (jailbreak), štetnog sadržaja i drugih bezbednosnih rizika u AI aplikacijama.

Više o AI prompt shields možete pročitati u [Prompt Shields dokumentaciji](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.sr.png)

### Bez
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

### Следеће

Следеће: [Поглавље 3: Почетак рада](/03-GettingStarted/README.md)

**Ограничење одговорности**:  
Овај документ је преведен помоћу AI сервиса за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако тежимо тачности, молимо вас да имате у виду да аутоматски преводи могу садржати грешке или нетачности. Изворни документ на његовом оригиналном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешне интерпретације настале коришћењем овог превода.