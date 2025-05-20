<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-20T23:28:20+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "sr"
}
-->
# Najbolje bezbednosne prakse

Usvajanje Model Context Protocol-a (MCP) donosi moćne nove mogućnosti AI-aplikacijama, ali istovremeno uvodi i jedinstvene bezbednosne izazove koji prevazilaze tradicionalne softverske rizike. Pored već poznatih tema kao što su sigurno programiranje, princip najmanjih privilegija i bezbednost lanca snabdevanja, MCP i AI radni zadaci suočavaju se sa novim pretnjama kao što su prompt injection, trovanje alata i dinamičke izmene alata. Ovi rizici mogu dovesti do curenja podataka, kršenja privatnosti i nepredviđenog ponašanja sistema ako se ne upravlja pravilno.

Ova lekcija istražuje najvažnije bezbednosne rizike povezane sa MCP-om — uključujući autentifikaciju, autorizaciju, prekomerne dozvole, indirektni prompt injection i ranjivosti u lancu snabdevanja — i pruža konkretne kontrole i najbolje prakse za njihovu mitigaciju. Takođe ćete naučiti kako da iskoristite Microsoft rešenja kao što su Prompt Shields, Azure Content Safety i GitHub Advanced Security za jačanje vaše MCP implementacije. Razumevanjem i primenom ovih kontrola, značajno možete smanjiti verovatnoću bezbednosnog incidenta i osigurati da vaši AI sistemi ostanu pouzdani i sigurni.

# Ciljevi učenja

Na kraju ove lekcije bićete u stanju da:

- Identifikujete i objasnite jedinstvene bezbednosne rizike koje uvodi Model Context Protocol (MCP), uključujući prompt injection, trovanje alata, prekomerne dozvole i ranjivosti u lancu snabdevanja.
- Opisujete i primenjujete efikasne mere za ublažavanje MCP bezbednosnih rizika, kao što su robusna autentifikacija, princip najmanjih privilegija, sigurno upravljanje tokenima i verifikacija lanca snabdevanja.
- Razumete i koristite Microsoft rešenja kao što su Prompt Shields, Azure Content Safety i GitHub Advanced Security za zaštitu MCP i AI radnih zadataka.
- Prepoznate značaj validacije metapodataka alata, praćenja dinamičkih promena i odbrane od indirektnih prompt injection napada.
- Uključite uspostavljene bezbednosne najbolje prakse — kao što su sigurno programiranje, ojačavanje servera i zero trust arhitektura — u vašu MCP implementaciju radi smanjenja verovatnoće i posledica bezbednosnih incidenata.

# MCP bezbednosne kontrole

Svaki sistem koji ima pristup važnim resursima nosi sa sobom određene bezbednosne izazove. Bezbednosni izazovi se generalno rešavaju pravilnom primenom osnovnih bezbednosnih kontrola i koncepata. Pošto je MCP tek nedavno definisan, specifikacija se brzo menja i kako protokol evoluira, kontrole bezbednosti unutar njega će sazreti, omogućavajući bolju integraciju sa korporativnim i etabliranim bezbednosnim arhitekturama i najboljim praksama.

Istraživanje objavljeno u [Microsoft Digital Defense Report](https://aka.ms/mddr) navodi da bi 98% prijavljenih proboja bilo sprečeno robusnom bezbednosnom higijenom, a najbolja zaštita od bilo kakvog proboja jeste da postavite dobru osnovnu bezbednosnu higijenu, najbolje prakse sigurnog kodiranja i bezbednost lanca snabdevanja — te proverenе i isprobane prakse i dalje imaju najveći uticaj u smanjenju bezbednosnih rizika.

Pogledajmo neke od načina na koje možete početi da rešavate bezbednosne rizike prilikom usvajanja MCP-a.

# MCP server autentifikacija (ako je vaša MCP implementacija pre 26. aprila 2025)

> **[!NOTE]** Sledeće informacije su tačne na dan 26. aprila 2025. MCP protokol se stalno razvija, a buduće implementacije mogu uvesti nove obrasce autentifikacije i kontrole. Za najnovije informacije i smernice, uvek pogledajte [MCP Specification](https://spec.modelcontextprotocol.io/) i zvanični [MCP GitHub repository](https://github.com/modelcontextprotocol).

### Izjava problema  
Originalna MCP specifikacija je pretpostavljala da će developeri pisati sopstveni server za autentifikaciju. To je zahtevalo poznavanje OAuth i povezanih bezbednosnih ograničenja. MCP serveri su funkcionisali kao OAuth 2.0 Authorization Servers, upravljajući potrebnom autentifikacijom korisnika direktno, umesto da to delegiraju eksternom servisu kao što je Microsoft Entra ID. Od 26. aprila 2025, ažuriranje MCP specifikacije omogućava MCP serverima da delegiraju autentifikaciju korisnika eksternom servisu.

### Rizici  
- Pogrešno konfigurisana autorizacija na MCP serveru može dovesti do izlaganja osetljivih podataka i nepravilno primenjenih kontrola pristupa.  
- Krađa OAuth tokena na lokalnom MCP serveru. Ukoliko se token ukrade, može se koristiti za lažno predstavljanje MCP servera i pristup resursima i podacima za koje je token namenjen.

### Mere ublažavanja  
- **Pregledajte i ojačajte autorizacionu logiku:** Pažljivo revidirajte autorizacionu implementaciju na MCP serveru kako biste osigurali da samo predviđeni korisnici i klijenti imaju pristup osetljivim resursima. Za praktične smernice pogledajte [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) i [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).  
- **Sprovodite sigurne prakse za tokene:** Pratite [Microsoftove najbolje prakse za validaciju i trajanje tokena](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) kako biste sprečili zloupotrebu pristupnih tokena i smanjili rizik od ponovne upotrebe ili krađe tokena.  
- **Zaštitite skladištenje tokena:** Uvek skladištite tokene na siguran način i koristite enkripciju za zaštitu podataka u mirovanju i prenosu. Za savete o implementaciji pogledajte [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Prekomerne dozvole za MCP servere

### Izjava problema  
MCP serverima su možda dodeljene prekomerne dozvole za servis ili resurs kome pristupaju. Na primer, MCP server koji je deo AI prodajne aplikacije koja se povezuje sa korporativnim skladištem podataka treba da ima pristup ograničen na prodajne podatke, a ne dozvolu za pristup svim fajlovima u skladištu. Vraćajući se na princip najmanjih privilegija (jedan od najstarijih bezbednosnih principa), nijedan resurs ne bi trebalo da ima dozvole veće od onih potrebnih za izvršenje zadataka za koje je predviđen. AI dodatno komplikuje ovu situaciju jer je zbog njegove fleksibilnosti teško precizno definisati potrebne dozvole.

### Rizici  
- Dodeljivanje prekomernih dozvola može omogućiti iznošenje ili menjanje podataka kojima MCP server nije trebalo da pristupi. Ovo može predstavljati i problem privatnosti ako su u pitanju lični podaci (PII).

### Mere ublažavanja  
- **Primena principa najmanjih privilegija:** Dodeljujte MCP serveru samo minimalne dozvole potrebne za izvršenje zadataka. Redovno pregledajte i ažurirajte dozvole da ne prelaze potrebni nivo. Za detaljna uputstva pogledajte [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).  
- **Koristite Role-Based Access Control (RBAC):** Dodeljujte uloge MCP serveru koje su strogo ograničene na specifične resurse i akcije, izbegavajući široke ili nepotrebne dozvole.  
- **Nadzor i revizija dozvola:** Kontinuirano pratite korišćenje dozvola i revidirajte pristupne zapise kako biste brzo otkrili i uklonili prekomerne ili neiskorišćene privilegije.

# Indirektni prompt injection napadi

### Izjava problema

Zlonamerni ili kompromitovani MCP serveri mogu uneti značajne rizike izlaganjem podataka korisnika ili omogućavanjem neželjenih akcija. Ovi rizici su posebno značajni u AI i MCP radnim zadacima, gde:

- **Prompt Injection napadi:** Napadači ubacuju zlonamerne instrukcije u promptove ili spoljašnji sadržaj, zbog čega AI sistem izvršava neželjene radnje ili otkriva osetljive podatke. Više informacija: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)  
- **Trovanje alata:** Napadači manipulišu metapodacima alata (kao što su opisi ili parametri) kako bi uticali na ponašanje AI-ja, potencijalno zaobilaženje bezbednosnih kontrola ili iznošenje podataka. Detalji: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)  
- **Cross-Domain Prompt Injection:** Zlonamerne instrukcije su ubačene u dokumente, veb stranice ili imejlove, koje AI potom obrađuje, što može dovesti do curenja podataka ili manipulacije.  
- **Dinamičke izmene alata (Rug Pulls):** Definicije alata mogu biti promenjene nakon odobrenja korisnika, uvodeći nove zlonamerne funkcionalnosti bez znanja korisnika.

Ove ranjivosti naglašavaju potrebu za robusnom validacijom, praćenjem i bezbednosnim kontrolama prilikom integracije MCP servera i alata u vaše okruženje. Za detaljnije informacije pogledajte linkovane reference iznad.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.sr.png)

**Indirektni Prompt Injection** (poznat i kao cross-domain prompt injection ili XPIA) predstavlja kritičnu ranjivost u generativnim AI sistemima, uključujući one koji koriste Model Context Protocol (MCP). U ovom napadu, zlonamerne instrukcije su skrivene u spoljašnjem sadržaju — kao što su dokumenti, veb stranice ili imejlovi. Kada AI sistem obrađuje ovaj sadržaj, može protumačiti ubačene instrukcije kao legitimne korisničke komande, što dovodi do neželjenih radnji kao što su curenje podataka, generisanje štetnog sadržaja ili manipulacija korisničkim interakcijama. Za detaljno objašnjenje i primere iz stvarnog sveta pogledajte [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Posebno opasna forma ovog napada je **Trovanje alata**. Ovde napadači ubacuju zlonamerne instrukcije u metapodatke MCP alata (kao što su opisi alata ili parametri). Pošto veliki jezički modeli (LLM) koriste ove metapodatke da odluče koje alate da pozovu, kompromitovani opisi mogu prevariti model da izvrši neautorizovane pozive alata ili zaobiđe bezbednosne kontrole. Ove manipulacije su često nevidljive krajnjim korisnicima, ali ih AI sistem može protumačiti i po njima postupati. Ovaj rizik je naročito izražen u hostovanim MCP server okruženjima, gde se definicije alata mogu menjati nakon odobrenja korisnika — scenario poznat i kao "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". U takvim slučajevima, alat koji je ranije bio bezbedan može kasnije biti modifikovan da izvrši zlonamerne radnje, kao što je iznošenje podataka ili menjanje ponašanja sistema, bez znanja korisnika. Više o ovom vektoru napada pogledajte u [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.sr.png)

## Rizici  
Neželjene AI akcije predstavljaju različite bezbednosne rizike, uključujući curenje podataka i narušavanje privatnosti.

### Mere ublažavanja  
### Korišćenje prompt shields za zaštitu od indirektnih prompt injection napada  
-----------------------------------------------------------------------------

**AI Prompt Shields** su rešenje koje je razvio Microsoft za odbranu od direktnih i indirektnih prompt injection napada. Oni pomažu kroz:

1.  **Detekciju i filtriranje:** Prompt Shields koriste napredne algoritme mašinskog učenja i obradu prirodnog jezika da otkriju i filtriraju zlonamerne instrukcije ubačene u spoljašnji sadržaj, kao što su dokumenti, veb stranice ili imejlovi.  
2.  **Isticanje (Spotlighting):** Ova tehnika pomaže AI sistemu da razlikuje validne sistemske instrukcije od potencijalno nepouzdanih spoljašnjih ulaza. Transformisanjem ulaznog teksta na način koji ga čini relevantnijim za model, Spotlighting osigurava da AI može bolje prepoznati i ignorisati zlonamerne instrukcije.  
3.  **Delimitere i označavanje podataka:** Uključivanje delimitera u sistemsku poruku jasno definiše lokaciju ulaznog teksta, pomažući AI sistemu da razlikuje korisničke ulaze od potencijalno štetnog spoljašnjeg sadržaja. Datamarking proširuje ovaj koncept korišćenjem specijalnih markera za označavanje granica pouzdanih i nepouzdanih podataka.  
4.  **Kontinuirano praćenje i ažuriranja:** Microsoft kontinuirano prati i ažurira Prompt Shields kako bi odgovorio na nove i razvijajuće pretnje. Ovaj proaktivan pristup osigurava da odbrane ostaju efikasne protiv najnovijih tehnika napada.  
5. **Integracija sa Azure Content Safety:** Prompt Shields su deo šire Azure AI Content Safety platforme, koja pruža dodatne alate za otkrivanje pokušaja jailbreak-a, štetnog sadržaja i drugih bezbednosnih rizika u AI aplikacijama.

Više o AI prompt shields pročitajte u [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.sr.png)

### Bezbednost lanca snabdevanja

Bezbednost lanca snabdevanja ostaje temeljna i u eri AI, ali se obim onoga što predstavlja vaš lanac snabdevanja proširio. Pored tradicionalnih paketa koda, sada morate strogo proveravati i pratiti sve AI-komponente, uključujući osnovne modele, usluge ugradnje (embedding), pružaoce konteksta i API-je trećih strana. Svaka od ovih komponenti može uneti ranjivosti ili rizike ako se ne upravlja pravilno.

**Ključne bezbednosne prakse za lanac snabdevanja u AI i MCP:**
- **Proveravajte sve komponente pre integracije:** Ovo uključuje ne samo open-source biblioteke, već i AI modele, izvore podataka i spoljne API-je. Uvek proveravajte poreklo, licence i poznate ranjivosti.  
- **Održavajte sigurne pipeline-ove za deployment:** Koristite automatizovane CI/CD pipeline-ove sa integrisanim bezbednosnim skeniranjem za rano otkrivanje problema. Osigurajte da se u produkciju plasiraju samo provereni artefakti.  
- **Kontinuirano pratite i revidirajte:** Implementirajte stalni nadzor svih zavisnosti, uključujući modele i usluge podataka, da biste otkrili nove ranjivosti ili napade na lanac snabdevanja.  
- **Primena principa najmanjih privilegija i kontrola pristupa:** Ograničite pristup modelima, podacima i servisima samo na ono što je neophodno za rad MCP servera.  
- **Brza reakcija na pretnje:** Imate uspostavljen proces za zakrpe ili zamenu kompromitovanih komponenti, kao i za rotaciju tajni ili akreditiva ukoliko se otkrije bezbednosni incident.

[GitHub Advanced Security](https://github.com/security/advanced-security) pruža funkcionalnosti kao što su skeniranje tajni, skeniranje zavisnosti i CodeQL analiza. Ovi alati se integrišu sa [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) i [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) kako bi pomogli timovima da identifikuju i ublaže ranjivosti u kodu i AI komponentama lanca snabdevanja.

Microsoft takođe interno primenjuje opsežne bezbednosne prakse lanca snabdevanja za sve svoje proizvode. Više o tome saznajte u [The Journey to Secure the Software Supply Chain at
- [OWASP Top 10 za LLM](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Put ka sigurnom lancu snabdevanja softvera u Microsoftu](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Siguran pristup sa najmanje privilegija (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Najbolje prakse za validaciju tokena i njihov vek trajanja](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Koristite sigurnu pohranu tokena i šifrujte tokene (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management kao autentifikacioni gateway za MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Korišćenje Microsoft Entra ID za autentifikaciju sa MCP serverima](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Sledeće

Sledeće: [Poglavlje 3: Početak](/03-GettingStarted/README.md)

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI услуге за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде тачан, молимо имајте у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетом. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешна тумачења која могу настати употребом овог превода.