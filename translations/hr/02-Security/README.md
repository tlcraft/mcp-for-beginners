<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-20T23:29:35+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "hr"
}
-->
# Security Best Practices

Usvajanje Model Context Protocol (MCP) donosi moćne nove mogućnosti za AI aplikacije, ali također uvodi jedinstvene sigurnosne izazove koji nadilaze tradicionalne softverske rizike. Osim utvrđenih pitanja kao što su sigurno kodiranje, princip najmanjih privilegija i sigurnost opskrbnog lanca, MCP i AI radni zadaci suočavaju se s novim prijetnjama poput prompt injectiona, trovanja alata i dinamičke modifikacije alata. Ovi rizici mogu dovesti do krađe podataka, narušavanja privatnosti i neželjenog ponašanja sustava ako se ne upravljaju ispravno.

Ova lekcija istražuje najvažnije sigurnosne rizike povezane s MCP-om — uključujući autentikaciju, autorizaciju, prekomjerne dozvole, indirektni prompt injection i ranjivosti u opskrbnom lancu — te pruža konkretne kontrole i najbolje prakse za njihovo ublažavanje. Također ćete naučiti kako iskoristiti Microsoftova rješenja poput Prompt Shields, Azure Content Safety i GitHub Advanced Security za jačanje vaše MCP implementacije. Razumijevanjem i primjenom ovih kontrola možete značajno smanjiti vjerojatnost sigurnosnog incidenta i osigurati da vaši AI sustavi ostanu snažni i pouzdani.

# Learning Objectives

Do kraja ove lekcije moći ćete:

- Prepoznati i objasniti jedinstvene sigurnosne rizike koje donosi Model Context Protocol (MCP), uključujući prompt injection, trovanje alata, prekomjerne dozvole i ranjivosti u opskrbnom lancu.
- Opisati i primijeniti učinkovite kontrole za ublažavanje MCP sigurnosnih rizika, poput robusne autentikacije, principa najmanjih privilegija, sigurnog upravljanja tokenima i provjere opskrbnog lanca.
- Razumjeti i koristiti Microsoftova rješenja poput Prompt Shields, Azure Content Safety i GitHub Advanced Security za zaštitu MCP i AI radnih zadataka.
- Prepoznati važnost validacije metapodataka alata, praćenja dinamičkih promjena i obrane od indirektnih prompt injection napada.
- Integrirati uspostavljene sigurnosne najbolje prakse — kao što su sigurno kodiranje, jačanje servera i zero trust arhitektura — u vašu MCP implementaciju kako biste smanjili vjerojatnost i utjecaj sigurnosnih incidenata.

# MCP security controls

Svaki sustav koji ima pristup važnim resursima ima implicitne sigurnosne izazove. Sigurnosni izazovi se općenito mogu riješiti pravilnom primjenom temeljnih sigurnosnih kontrola i koncepata. Kako je MCP tek nedavno definiran, specifikacija se brzo mijenja i protokol se razvija. S vremenom će sigurnosne kontrole unutar njega sazrijeti, omogućujući bolju integraciju s enterprise i etabliranim sigurnosnim arhitekturama i najboljim praksama.

Istraživanje objavljeno u [Microsoft Digital Defense Report](https://aka.ms/mddr) navodi da bi 98% prijavljenih proboja bilo spriječeno robusnom sigurnosnom higijenom, a najbolja zaštita od bilo kakvog proboja je da imate pravilno postavljenu osnovnu sigurnosnu higijenu, najbolje prakse sigurnog kodiranja i sigurnost opskrbnog lanca — te provjerene prakse koje već znamo i koje i dalje imaju najveći utjecaj u smanjenju sigurnosnih rizika.

Pogledajmo neke načine na koje možete početi adresirati sigurnosne rizike prilikom usvajanja MCP-a.

# MCP server authentication (if your MCP implementation was before 26th April 2025)

> **Note:** Sljedeće informacije su točne na dan 26. travnja 2025. MCP protokol se kontinuirano razvija i buduće implementacije mogu uvesti nove obrasce autentikacije i kontrole. Za najnovije informacije i smjernice uvijek se obratite [MCP Specification](https://spec.modelcontextprotocol.io/) i službenom [MCP GitHub repozitoriju](https://github.com/modelcontextprotocol).

### Problem statement  
Izvorna MCP specifikacija pretpostavljala je da će developeri sami pisati svoj server za autentikaciju. To je zahtijevalo znanje o OAuth-u i povezanim sigurnosnim ograničenjima. MCP serveri su djelovali kao OAuth 2.0 Authorization Serveri, upravljajući potrebnom autentikacijom korisnika direktno, umjesto da je delegiraju vanjskoj usluzi poput Microsoft Entra ID. Od 26. travnja 2025., ažuriranje MCP specifikacije omogućava MCP serverima da delegiraju autentikaciju korisnika vanjskoj usluzi.

### Risks  
- Pogrešno konfigurirana autorizacijska logika na MCP serveru može dovesti do izlaganja osjetljivih podataka i nepravilno primijenjenih kontrola pristupa.  
- Krađa OAuth tokena na lokalnom MCP serveru. Ako je token ukraden, može se koristiti za lažno predstavljanje MCP servera i pristup resursima i podacima za koje je token namijenjen.

### Mitigating controls  
- **Review and Harden Authorization Logic:** Pažljivo pregledajte autorizacijsku implementaciju na vašem MCP serveru kako biste osigurali da samo namijenjeni korisnici i klijenti imaju pristup osjetljivim resursima. Za praktične smjernice, pogledajte [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) i [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).  
- **Enforce Secure Token Practices:** Slijedite [Microsoftove najbolje prakse za validaciju i životni vijek tokena](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) kako biste spriječili zloupotrebu pristupnih tokena i smanjili rizik od ponovne upotrebe ili krađe tokena.  
- **Protect Token Storage:** Uvijek pohranjujte tokene sigurno i koristite enkripciju za zaštitu u mirovanju i prijenosu. Za savjete o implementaciji, pogledajte [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Excessive permissions for MCP servers

### Problem statement  
MCP serverima su možda dodijeljene prekomjerne dozvole za uslugu ili resurs kojem pristupaju. Na primjer, MCP server koji je dio AI aplikacije za prodaju i povezan je s enterprise skladištem podataka trebao bi imati pristup ograničen na prodajne podatke, a ne dozvolu za pristup svim datotekama u skladištu. Vraćajući se na princip najmanjih privilegija (jedan od najstarijih sigurnosnih principa), nijedan resurs ne bi smio imati dozvole veće od onih potrebnih za izvršenje svojih zadanih zadataka. AI predstavlja dodatni izazov jer je zbog fleksibilnosti teško precizno definirati potrebne dozvole.

### Risks  
- Dodjeljivanje prekomjernih dozvola može omogućiti iznošenje ili izmjenu podataka kojima MCP server nije trebao pristupati. To može biti i problem privatnosti ako se radi o osobnim podacima (PII).

### Mitigating controls  
- **Apply the Principle of Least Privilege:** Dodijelite MCP serveru samo minimalne dozvole potrebne za obavljanje zadataka. Redovito pregledavajte i ažurirajte te dozvole kako ne bi premašivale potrebne. Za detaljne upute, pogledajte [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).  
- **Use Role-Based Access Control (RBAC):** Dodjeljujte uloge MCP serveru koje su strogo ograničene na specifične resurse i akcije, izbjegavajući široke ili nepotrebne dozvole.  
- **Monitor and Audit Permissions:** Kontinuirano pratite korištenje dozvola i auditirajte pristupne zapise kako biste brzo otkrili i uklonili prekomjerne ili neiskorištene privilegije.

# Indirect prompt injection attacks

### Problem statement

Zlonamjerni ili kompromitirani MCP serveri mogu unijeti značajne rizike izlaganjem podataka korisnika ili omogućavanjem neželjenih akcija. Ovi rizici su posebno važni u AI i MCP radnim zadacima, gdje:

- **Prompt Injection Attacks**: Napadači ugrađuju zlonamjerne upute u promptove ili vanjski sadržaj, prisiljavajući AI sustav na neželjene akcije ili curenje osjetljivih podataka. Više informacija: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)  
- **Tool Poisoning**: Napadači manipuliraju metapodacima alata (poput opisa ili parametara) kako bi utjecali na ponašanje AI-ja, potencijalno zaobilazeći sigurnosne kontrole ili izvlačeći podatke. Detalji: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)  
- **Cross-Domain Prompt Injection**: Zlonamjerne upute ugrađene u dokumente, web stranice ili e-mailove koje AI procesira, što može dovesti do curenja podataka ili manipulacije.  
- **Dynamic Tool Modification (Rug Pulls)**: Definicije alata mogu se mijenjati nakon korisničkog odobrenja, uvodeći nove zlonamjerne funkcionalnosti bez znanja korisnika.

Ove ranjivosti naglašavaju potrebu za robusnom validacijom, praćenjem i sigurnosnim kontrolama prilikom integracije MCP servera i alata u vaše okruženje. Za dublju analizu, pogledajte navedene izvore.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.hr.png)

**Indirect Prompt Injection** (poznat i kao cross-domain prompt injection ili XPIA) je kritična ranjivost u generativnim AI sustavima, uključujući one koji koriste Model Context Protocol (MCP). U ovom napadu, zlonamjerne upute skrivene su u vanjskom sadržaju — poput dokumenata, web stranica ili e-mailova. Kada AI sustav procesuira taj sadržaj, može interpretirati ugrađene upute kao legitimne korisničke naredbe, što rezultira neželjenim radnjama poput curenja podataka, generiranja štetnog sadržaja ili manipulacije korisničkim interakcijama. Za detaljno objašnjenje i primjere iz stvarnog svijeta, pogledajte [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Posebno opasna vrsta ovog napada je **Tool Poisoning**. Ovdje napadači ubacuju zlonamjerne upute u metapodatke MCP alata (poput opisa alata ili parametara). Budući da veliki jezični modeli (LLM) koriste te metapodatke za odlučivanje koje alate pozvati, kompromitirani opisi mogu prevariti model da izvrši neovlaštene pozive alata ili zaobiđe sigurnosne kontrole. Ove manipulacije često su nevidljive krajnjim korisnicima, ali ih AI sustav može interpretirati i izvršiti. Rizik je pojačan u hostanim MCP okruženjima, gdje se definicije alata mogu mijenjati nakon korisničkog odobrenja — scenarij poznat kao "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". U takvim slučajevima, alat koji je prije bio siguran može kasnije biti izmijenjen da izvršava zlonamjerne radnje, poput izvlačenja podataka ili mijenjanja ponašanja sustava, bez znanja korisnika. Za više informacija o ovom vektoru napada, pogledajte [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.hr.png)

## Risks  
Neželjene AI akcije predstavljaju niz sigurnosnih rizika koji uključuju krađu podataka i narušavanje privatnosti.

### Mitigating controls  
### Using prompt shields to protect against Indirect Prompt Injection attacks  
-----------------------------------------------------------------------------

**AI Prompt Shields** su rješenje koje je razvio Microsoft za obranu od direktnih i indirektnih prompt injection napada. Pomažu kroz:

1.  **Detection and Filtering:** Prompt Shields koriste napredne algoritme strojnog učenja i obradu prirodnog jezika za otkrivanje i filtriranje zlonamjernih uputa ugrađenih u vanjski sadržaj, poput dokumenata, web stranica ili e-mailova.  
2.  **Spotlighting:** Ova tehnika pomaže AI sustavu da razlikuje valjane sistemske upute od potencijalno nepouzdanih vanjskih ulaza. Transformiranjem ulaznog teksta na način koji ga čini relevantnijim za model, Spotlighting osigurava da AI bolje prepoznaje i ignorira zlonamjerne upute.  
3.  **Delimiters and Datamarking:** Uključivanje delimitera u sistemsku poruku jasno označava lokaciju ulaznog teksta, pomažući AI sustavu da razlikuje korisničke unose od potencijalno štetnog vanjskog sadržaja. Datamarking proširuje ovaj koncept korištenjem posebnih oznaka za isticanje granica pouzdanih i nepouzdanih podataka.  
4.  **Continuous Monitoring and Updates:** Microsoft kontinuirano prati i ažurira Prompt Shields kako bi odgovorio na nove i razvijajuće prijetnje. Ovaj proaktivan pristup osigurava da obrana ostane učinkovita protiv najnovijih tehnika napada.  
5. **Integration with Azure Content Safety:** Prompt Shields su dio šire Azure AI Content Safety zbirke alata koja pruža dodatne mehanizme za otkrivanje pokušaja jailbreaka, štetnog sadržaja i drugih sigurnosnih rizika u AI aplikacijama.

Više o AI prompt shields možete pročitati u [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.hr.png)

### Supply chain security

Sigurnost opskrbnog lanca ostaje temeljna u AI eri, ali opseg onoga što se smatra vašim opskrbnim lancem se proširio. Osim tradicionalnih paketa koda, sada morate strogo provjeravati i pratiti sve AI povezane komponente, uključujući temeljne modele, servise za ugradnju (embeddings), pružatelje konteksta i API-je trećih strana. Svaka od ovih komponenti može unijeti ranjivosti ili rizike ako se ne upravlja pravilno.

**Ključne prakse sigurnosti opskrbnog lanca za AI i MCP:**  
- **Verify all components before integration:** To uključuje ne samo open-source biblioteke, već i AI modele, izvore podataka i vanjske API-je. Uvijek provjerite podrijetlo, licence i poznate ranjivosti.  
- **Maintain secure deployment pipelines:** Koristite automatizirane CI/CD pipelineove s integriranim sigurnosnim skeniranjem kako biste rano otkrili probleme. Osigurajte da se u produkciju implementiraju samo pouzdani artefakti.  
- **Continuously monitor and audit:** Provedite stalni nadzor svih ovisnosti, uključujući modele i servise podataka, kako biste otkrili nove ranjivosti ili napade na opskrbni lanac.  
- **Apply least privilege and access controls:** Ograničite pristup modelima, podacima i servisima samo na ono što je potrebno za rad MCP servera.  
- **Respond quickly to threats:** Imate proces za brzo zakrpavanje ili zamjenu kompromitiranih komponenti te rotaciju tajni ili vjerodajnica ako se otkrije proboj.

[GitHub Advanced Security](https://github.com/security/advanced-security) pruža značajke poput skeniranja tajni, skeniranja ovisnosti i CodeQL analize. Ovi alati se integriraju s [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) i [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) kako bi timovima pomogli u identifikaciji i ublažavanju ranjivosti u kodu i AI komponentama opskrbnog lanca.

Microsoft također interno provodi opsežne prakse sigurnosti opskrbnog lanca za sve proizvode. Više saznajte u [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Established security best practices that will uplift your MCP implementation's security posture

Svaka MCP implementacija nasljeđuje postojeći sigurnosni položaj okruženja vaše organizacije na kojem se temelji, stoga se pri razmatranju sigurnosti MCP-a kao dijela vašeg ukupnog AI sustava preporučuje da unaprijedite postojeći sigurnosni položaj. Sljedeće uspostavljene sigurnosne kontrole su posebno važne:

- Sigurne prakse kodiranja u vašoj AI aplikaciji — zaštita od [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 for
- [OWASP Top 10 za LLM-ove](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Put prema sigurnom lancu opskrbe softverom u Microsoftu](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Siguran pristup s najmanjim privilegijama (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Najbolje prakse za provjeru valjanosti tokena i njihov životni vijek](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Koristite sigurno spremanje tokena i šifrirajte tokene (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management kao autentifikacijski gateway za MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Korištenje Microsoft Entra ID za autentifikaciju s MCP serverima](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Sljedeće

Sljedeće: [Poglavlje 3: Početak rada](/03-GettingStarted/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI prevoditeljskog servisa [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo postići točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za važne informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakve nesporazume ili pogrešna tumačenja proizašla iz korištenja ovog prijevoda.