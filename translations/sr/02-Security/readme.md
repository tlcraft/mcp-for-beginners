<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-17T07:56:01+00:00",
  "source_file": "02-Security/readme.md",
  "language_code": "sr"
}
-->
# Najbolje prakse za bezbednost

Usvajanje Model Context Protocola (MCP) donosi snažne nove mogućnosti aplikacijama vođenim veštačkom inteligencijom, ali takođe uvodi jedinstvene bezbednosne izazove koji prevazilaze tradicionalne softverske rizike. Pored ustaljenih briga kao što su sigurno kodiranje, najmanje privilegije i bezbednost lanca snabdevanja, MCP i radna opterećenja veštačke inteligencije suočavaju se sa novim pretnjama kao što su injekcija prompta, trovanje alata i dinamička modifikacija alata. Ovi rizici mogu dovesti do eksfiltracije podataka, kršenja privatnosti i neželjenog ponašanja sistema ako se ne upravljaju pravilno.

Ova lekcija istražuje najrelevantnije bezbednosne rizike povezane sa MCP-om—uključujući autentifikaciju, autorizaciju, prekomerne dozvole, indirektnu injekciju prompta i ranjivosti lanca snabdevanja—i pruža praktične kontrole i najbolje prakse za njihovo ublažavanje. Takođe ćete naučiti kako da iskoristite Microsoft rešenja kao što su Prompt Shields, Azure Content Safety i GitHub Advanced Security da ojačate vašu MCP implementaciju. Razumevanjem i primenom ovih kontrola, možete značajno smanjiti verovatnoću bezbednosnog kršenja i osigurati da vaši AI sistemi ostanu robusni i pouzdani.

# Ciljevi učenja

Do kraja ove lekcije, moći ćete da:

- Identifikujete i objasnite jedinstvene bezbednosne rizike koje uvodi Model Context Protocol (MCP), uključujući injekciju prompta, trovanje alata, prekomerne dozvole i ranjivosti lanca snabdevanja.
- Opisujete i primenjujete efikasne kontrolne mere za ublažavanje MCP bezbednosnih rizika, kao što su robusna autentifikacija, najmanje privilegije, upravljanje sigurnim tokenima i verifikacija lanca snabdevanja.
- Razumete i koristite Microsoft rešenja kao što su Prompt Shields, Azure Content Safety i GitHub Advanced Security da zaštitite MCP i radna opterećenja veštačke inteligencije.
- Prepoznate važnost validacije metapodataka alata, praćenja dinamičkih promena i odbrane od indirektnih napada injekcije prompta.
- Integrirate ustanovljene najbolje prakse za bezbednost—kao što su sigurno kodiranje, učvršćivanje servera i arhitektura nultog poverenja—u vašu MCP implementaciju da smanjite verovatnoću i uticaj bezbednosnih kršenja.

# MCP kontrole bezbednosti

Svaki sistem koji ima pristup važnim resursima ima implicirane bezbednosne izazove. Bezbednosni izazovi se generalno mogu rešiti pravilnom primenom osnovnih bezbednosnih kontrola i koncepata. Kako je MCP tek nedavno definisan, specifikacija se vrlo brzo menja i kako se protokol razvija. Na kraju će kontrole bezbednosti unutar njega sazreti, omogućavajući bolju integraciju sa preduzećima i ustanovljenim bezbednosnim arhitekturama i najboljim praksama.

Istraživanje objavljeno u [Microsoft Digital Defense Report](https://aka.ms/mddr) navodi da bi 98% prijavljenih kršenja bilo sprečeno robusnom higijenom bezbednosti, a najbolja zaštita protiv bilo kakvog kršenja je da postavite osnovnu higijenu bezbednosti, najbolje prakse za sigurno kodiranje i bezbednost lanca snabdevanja—te proverene i testirane prakse koje već poznajemo i dalje imaju najveći uticaj u smanjenju rizika bezbednosti.

Pogledajmo neke od načina na koje možete početi da rešavate bezbednosne rizike prilikom usvajanja MCP-a.

# Autentifikacija MCP servera (ako je vaša MCP implementacija bila pre 26. aprila 2025.)

> **Napomena:** Sledeće informacije su tačne od 26. aprila 2025. MCP protokol se stalno razvija, a buduće implementacije mogu uvesti nove obrasce autentifikacije i kontrole. Za najnovija ažuriranja i smernice, uvek se pozivajte na [MCP Specification](https://spec.modelcontextprotocol.io/) i zvanični [MCP GitHub repository](https://github.com/modelcontextprotocol).

### Izjava o problemu
Originalna MCP specifikacija je pretpostavljala da će programeri pisati sopstveni server za autentifikaciju. Ovo je zahtevalo poznavanje OAuth-a i povezanih bezbednosnih ograničenja. MCP serveri su delovali kao OAuth 2.0 Authorization Servers, upravljajući potrebnom autentifikacijom korisnika direktno umesto da je delegiraju na eksternu uslugu kao što je Microsoft Entra ID. Od 26. aprila 2025. godine, ažuriranje MCP specifikacije omogućava MCP serverima da delegiraju autentifikaciju korisnika na eksternu uslugu.

### Rizici
- Pogrešno konfigurisana logika autorizacije na MCP serveru može dovesti do izlaganja osetljivih podataka i pogrešno primenjenih kontrola pristupa.
- Krađa OAuth tokena na lokalnom MCP serveru. Ako se ukrade, token se može koristiti za imitiranje MCP servera i pristup resursima i podacima sa usluge za koju je OAuth token namenjen.

### Kontrole za ublažavanje
- **Pregledajte i učvrstite logiku autorizacije:** Pažljivo proverite implementaciju autorizacije vašeg MCP servera kako biste osigurali da samo predviđeni korisnici i klijenti mogu pristupiti osetljivim resursima. Za praktične smernice, pogledajte [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) i [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Primena sigurnih praksi za tokene:** Pratite [Microsoftove najbolje prakse za validaciju i trajanje tokena](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) kako biste sprečili zloupotrebu tokena za pristup i smanjili rizik od ponovne upotrebe ili krađe tokena.
- **Zaštitite skladištenje tokena:** Uvek čuvajte tokene sigurno i koristite enkripciju da ih zaštitite u mirovanju i tokom prenosa. Za savete o implementaciji, pogledajte [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Prekomerne dozvole za MCP servere

### Izjava o problemu
MCP serverima mogu biti dodeljene prekomerne dozvole za uslugu/resurs kojem pristupaju. Na primer, MCP server koji je deo AI aplikacije za prodaju povezan sa skladištem podataka preduzeća treba da ima pristup ograničen na podatke o prodaji i ne sme mu biti dozvoljen pristup svim datotekama u skladištu. Vraćajući se na princip najmanje privilegije (jedan od najstarijih bezbednosnih principa), nijedan resurs ne bi trebalo da ima dozvole veće od onih koje su potrebne za izvršavanje zadataka za koje je predviđen. AI predstavlja povećan izazov u ovom prostoru jer, da bi se omogućila fleksibilnost, može biti teško definisati tačne potrebne dozvole.

### Rizici 
- Dodeljivanje prekomernih dozvola može omogućiti eksfiltraciju ili izmenu podataka kojima MCP server nije predviđen da pristupi. Ovo bi takođe moglo biti pitanje privatnosti ako su podaci lično identifikovani podaci (PII).

### Kontrole za ublažavanje
- **Primena principa najmanje privilegije:** Dodelite MCP serveru samo minimalne dozvole potrebne za obavljanje njegovih potrebnih zadataka. Redovno pregledajte i ažurirajte ove dozvole kako biste osigurali da ne prelaze ono što je potrebno. Za detaljne smernice, pogledajte [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Koristite kontrolu pristupa zasnovanu na ulozi (RBAC):** Dodelite uloge MCP serveru koje su usko ograničene na određene resurse i radnje, izbegavajući široke ili nepotrebne dozvole.
- **Pratite i proveravajte dozvole:** Kontinuirano pratite upotrebu dozvola i proveravajte dnevnike pristupa kako biste brzo otkrili i ispravili prekomerne ili neiskorišćene privilegije.

# Indirektni napadi injekcije prompta

### Izjava o problemu

Zlonamerni ili kompromitovani MCP serveri mogu uvesti značajne rizike izlažući podatke korisnika ili omogućavajući neželjene radnje. Ovi rizici su posebno relevantni u AI i MCP zasnovanim radnim opterećenjima, gde:

- **Napadi injekcije prompta**: Napadači ugrađuju zlonamerne instrukcije u promptove ili eksterni sadržaj, uzrokujući da AI sistem izvrši neželjene radnje ili otkrije osetljive podatke. Saznajte više: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Trovanje alata**: Napadači manipulišu metapodacima alata (kao što su opisi ili parametri) da utiču na ponašanje AI-a, potencijalno zaobilazeći bezbednosne kontrole ili eksfiltrirajući podatke. Detalji: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Unakrsna domena injekcija prompta**: Zlonamerne instrukcije su ugrađene u dokumente, veb stranice ili e-poštu, koje zatim obrađuje AI, što dovodi do curenja podataka ili manipulacije.
- **Dinamička modifikacija alata (Rug Pulls)**: Definicije alata mogu se promeniti nakon odobrenja korisnika, uvodeći nove zlonamerne radnje bez svesti korisnika.

Ove ranjivosti ističu potrebu za robusnom validacijom, praćenjem i bezbednosnim kontrolama pri integraciji MCP servera i alata u vaše okruženje. Za dublje razumevanje, pogledajte povezane reference iznad.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.4b2f1af239a32d46221a75c7bc5b6f392ebbacc47eccde241d4c60507232fa43.sr.png)

**Indirektna injekcija prompta** (poznata i kao unakrsna domena injekcija prompta ili XPIA) je kritična ranjivost u generativnim AI sistemima, uključujući one koji koriste Model Context Protocol (MCP). U ovom napadu, zlonamerne instrukcije su skrivene unutar eksternog sadržaja—kao što su dokumenti, veb stranice ili e-pošta. Kada AI sistem obradi ovaj sadržaj, može interpretirati ugrađene instrukcije kao legitimne korisničke komande, rezultirajući neželjenim radnjama kao što su curenje podataka, generisanje štetnog sadržaja ili manipulacija korisničkim interakcijama. Za detaljno objašnjenje i primere iz stvarnog sveta, pogledajte [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Posebno opasan oblik ovog napada je **Trovanje alata**. Ovde napadači ubacuju zlonamerne instrukcije u metapodatke MCP alata (kao što su opisi alata ili parametri). Pošto se veliki jezički modeli (LLM) oslanjaju na ove metapodatke da odluče koje alate da pozovu, kompromitovani opisi mogu prevariti model da izvrši neovlašćene pozive alata ili zaobiđe bezbednosne kontrole. Ove manipulacije su često nevidljive krajnjim korisnicima, ali ih AI sistem može interpretirati i izvršiti. Ovaj rizik je povećan u okruženjima hostovanih MCP servera, gde se definicije alata mogu ažurirati nakon odobrenja korisnika—scenarij koji se ponekad naziva "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". U takvim slučajevima, alat koji je prethodno bio siguran može kasnije biti modifikovan da izvrši zlonamerne radnje, kao što su eksfiltracija podataka ili promena ponašanja sistema, bez znanja korisnika. Za više informacija o ovom vektoru napada, pogledajte [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.d4607023f69e16157954001ad81afd763676361f03db0a1cf24ec696b2ddcb88.sr.png)

## Rizici
Neželjene AI radnje predstavljaju razne bezbednosne rizike koji uključuju eksfiltraciju podataka i kršenja privatnosti.

### Kontrole za ublažavanje
### Korišćenje štitova prompta za zaštitu od indirektnih napada injekcije prompta
-----------------------------------------------------------------------------

**AI Prompt Shields** su rešenje koje je razvio Microsoft za odbranu od direktnih i indirektnih napada injekcije prompta. Oni pomažu kroz:

1.  **Detekciju i filtriranje**: Prompt Shields koriste napredne algoritme mašinskog učenja i obradu prirodnog jezika za detekciju i filtriranje zlonamernih instrukcija ugrađenih u eksterni sadržaj, kao što su dokumenti, veb stranice ili e-pošta.
    
2.  **Spotlighting**: Ova tehnika pomaže AI sistemu da razlikuje validne sistemske instrukcije od potencijalno nepouzdanih eksternih unosa. Transformišući tekst unosa na način koji ga čini relevantnijim za model, Spotlighting osigurava da AI može bolje identifikovati i ignorisati zlonamerne instrukcije.
    
3.  **Razgraničenja i označavanje podataka**: Uključivanje razgraničenja u sistemsku poruku eksplicitno navodi lokaciju teksta unosa, pomažući AI sistemu da prepozna i razdvoji korisničke unose od potencijalno štetnog eksternog sadržaja. Označavanje podataka proširuje ovaj koncept korišćenjem posebnih oznaka za isticanje granica pouzdanih i nepouzdanih podataka.
    
4.  **Kontinuirano praćenje i ažuriranja**: Microsoft kontinuirano prati i ažurira Prompt Shields kako bi se suočio sa novim i razvijajućim pretnjama. Ovaj proaktivan pristup osigurava da odbrane ostanu efikasne protiv najnovijih tehnika napada.
    
5. **Integracija sa Azure Content Safety:** Prompt Shields su deo šire Azure AI Content Safety suite, koji pruža dodatne alate za detekciju pokušaja bekstva iz zatvora, štetnog sadržaja i drugih bezbednosnih rizika u AI aplikacijama.

Možete pročitati više o AI štitovima prompta u [Prompt Shields dokumentaciji](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.a4dba28a04ea42d28053f233585290d4862b244ca1e59b8ff695c5530e1bba66.sr.png)

### Bezbednost lanca snabdevanja

Bezbednost lanca snabdevanja ostaje fundamentalna u eri veštačke inteligencije, ali se obim onoga što čini vaš lanac snabdevanja proširio. Pored tradicionalnih paketa koda, sada morate rigorozno proveravati i pratiti sve komponente povezane sa veštačkom inteligencijom, uključujući osnovne modele, usluge ugrađivanja, provajdere konteksta i API-je trećih strana. Svaka od ovih može uneti ranjivosti ili rizike ako se ne upravlja pravilno.

**Ključne prakse bezbednosti lanca snabdevanja za AI i MCP:**
- **Verifikujte sve komponente pre integracije:** Ovo uključuje ne samo biblioteke otvorenog koda, već i AI modele, izvore podataka i eksterne API-je. Uvek proveravajte poreklo, licenciranje i poznate ranjivosti.
- **Održavajte sigurne pipeline za implementaciju:** Koristite automatizovane CI/CD pipeline sa integrisanim bezbednosnim skeniranjem kako biste uhvatili probleme rano. Osigurajte da se samo pouzdani artefakti implementiraju u produkciju.
- **Kontinuirano pratite i proveravajte:** Implementirajte stalno praćenje svih zavisnosti, uključujući modele i usluge podataka, kako biste otkrili nove ranjivosti ili napade na lanac snabdevanja.
- **Primena najmanje privilegije i kontrole pristupa:** Ograničite pristup modelima, podacima i uslugama samo na ono što je potrebno da MCP server funkcioniše.
- **Brzo reagujte na pretnje:** Imati proces za zakrpljivanje ili zamenu kompromitovanih komponenti, kao i za rotiranje tajni ili akreditiva ako se otkrije kršenje.

[GitHub Advanced Security](https://github
- [OWASP Top 10 za LLM-ove](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Napredna Sigurnost](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Put ka osiguranju lanca snabdevanja softverom u Microsoftu](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Osiguranje pristupa sa najmanje privilegija (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Najbolje prakse za validaciju tokena i njegov vek trajanja](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Koristite sigurno skladištenje tokena i šifrirajte tokene (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management kao Auth Gateway za MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Korišćenje Microsoft Entra ID za autentifikaciju sa MCP serverima](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Sledeće

Sledeće: [Poglavlje 3: Početak](/03-GettingStarted/README.md)

**Odricanje odgovornosti**:  
Ovaj dokument je preveden korišćenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako se trudimo da prevod bude tačan, molimo vas da budete svesni da automatski prevodi mogu sadržati greške ili netačnosti. Originalni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije, preporučuje se profesionalni prevod od strane ljudskog prevodioca. Ne snosimo odgovornost za nesporazume ili pogrešne interpretacije koje mogu nastati korišćenjem ovog prevoda.