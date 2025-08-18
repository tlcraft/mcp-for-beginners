<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1c767a35642f753127dc08545c25a290",
  "translation_date": "2025-08-18T17:26:17+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "hr"
}
-->
# MCP Sigurnost: Sveobuhvatna zaštita za AI sustave

[![MCP Sigurnosne najbolje prakse](../../../translated_images/03.175aed6dedae133f9d41e49cefd0f0a9a39c3317e1eaa7ef7182696af7534308.hr.png)](https://youtu.be/88No8pw706o)

_(Kliknite na sliku iznad za pregled videa ove lekcije)_

Sigurnost je temeljni dio dizajna AI sustava, zbog čega je stavljamo kao naš drugi odjeljak. Ovo je u skladu s Microsoftovim načelom **Secure by Design** iz [Secure Future Initiative](https://www.microsoft.com/security/blog/2025/04/17/microsofts-secure-by-design-journey-one-year-of-success/).

Model Context Protocol (MCP) donosi snažne nove mogućnosti za aplikacije vođene umjetnom inteligencijom, ali također uvodi jedinstvene sigurnosne izazove koji nadilaze tradicionalne softverske rizike. MCP sustavi suočavaju se s postojećim sigurnosnim problemima (sigurno kodiranje, najmanje privilegije, sigurnost opskrbnog lanca) i novim prijetnjama specifičnim za AI, uključujući ubrizgavanje prompta, trovanje alata, otmicu sesije, napade zbunjenog zamjenika, ranjivosti prijenosa tokena i dinamičke izmjene sposobnosti.

Ova lekcija istražuje najkritičnije sigurnosne rizike u MCP implementacijama—pokrivajući autentifikaciju, autorizaciju, prekomjerne privilegije, neizravno ubrizgavanje prompta, sigurnost sesije, probleme zbunjenog zamjenika, upravljanje tokenima i ranjivosti opskrbnog lanca. Naučit ćete praktične kontrole i najbolje prakse za ublažavanje ovih rizika, dok koristite Microsoftova rješenja poput Prompt Shields, Azure Content Safety i GitHub Advanced Security za jačanje vaše MCP implementacije.

## Ciljevi učenja

Na kraju ove lekcije, moći ćete:

- **Prepoznati prijetnje specifične za MCP**: Identificirati jedinstvene sigurnosne rizike u MCP sustavima, uključujući ubrizgavanje prompta, trovanje alata, prekomjerne privilegije, otmicu sesije, probleme zbunjenog zamjenika, ranjivosti prijenosa tokena i rizike opskrbnog lanca
- **Primijeniti sigurnosne kontrole**: Implementirati učinkovite mjere poput robusne autentifikacije, pristupa s najmanje privilegija, sigurnog upravljanja tokenima, kontrola sigurnosti sesije i provjere opskrbnog lanca
- **Iskoristiti Microsoftova sigurnosna rješenja**: Razumjeti i implementirati Microsoft Prompt Shields, Azure Content Safety i GitHub Advanced Security za zaštitu MCP radnih opterećenja
- **Validirati sigurnost alata**: Prepoznati važnost validacije metapodataka alata, praćenja dinamičkih promjena i obrane od neizravnih napada ubrizgavanja prompta
- **Integrirati najbolje prakse**: Kombinirati utvrđene sigurnosne osnove (sigurno kodiranje, učvršćivanje poslužitelja, zero trust) s kontrolama specifičnim za MCP za sveobuhvatnu zaštitu

# MCP Sigurnosna arhitektura i kontrole

Moderne MCP implementacije zahtijevaju slojevite sigurnosne pristupe koji adresiraju i tradicionalne softverske sigurnosne prijetnje i prijetnje specifične za AI. Brzo razvijajuća MCP specifikacija nastavlja unapređivati svoje sigurnosne kontrole, omogućujući bolju integraciju s arhitekturama sigurnosti poduzeća i utvrđenim najboljim praksama.

Istraživanje iz [Microsoft Digital Defense Report](https://aka.ms/mddr) pokazuje da bi **98% prijavljenih povreda bilo spriječeno robusnom sigurnosnom higijenom**. Najučinkovitija strategija zaštite kombinira temeljne sigurnosne prakse s kontrolama specifičnim za MCP—dokazane osnovne sigurnosne mjere ostaju najutjecajnije u smanjenju ukupnog sigurnosnog rizika.

## Trenutni sigurnosni krajolik

> **Napomena:** Ove informacije odražavaju MCP sigurnosne standarde od **18. kolovoza 2025.** MCP protokol se brzo razvija, a buduće implementacije mogu uvesti nove obrasce autentifikacije i poboljšane kontrole. Uvijek se referirajte na trenutnu [MCP Specifikaciju](https://spec.modelcontextprotocol.io/), [MCP GitHub repozitorij](https://github.com/modelcontextprotocol) i [dokumentaciju najboljih sigurnosnih praksi](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices) za najnovije smjernice.

### Evolucija MCP autentifikacije

MCP specifikacija značajno je evoluirala u svom pristupu autentifikaciji i autorizaciji:

- **Izvorni pristup**: Rane specifikacije zahtijevale su od programera implementaciju prilagođenih autentifikacijskih poslužitelja, pri čemu su MCP poslužitelji djelovali kao OAuth 2.0 poslužitelji za autorizaciju koji izravno upravljaju autentifikacijom korisnika
- **Trenutni standard (2025-06-18)**: Ažurirana specifikacija omogućuje MCP poslužiteljima delegiranje autentifikacije vanjskim pružateljima identiteta (poput Microsoft Entra ID), poboljšavajući sigurnosni položaj i smanjujući složenost implementacije
- **Sigurnost transportnog sloja**: Poboljšana podrška za sigurne transportne mehanizme s odgovarajućim obrascima autentifikacije za lokalne (STDIO) i udaljene (Streamable HTTP) veze

## Sigurnost autentifikacije i autorizacije

### Trenutni sigurnosni izazovi

Moderne MCP implementacije suočavaju se s nekoliko izazova u autentifikaciji i autorizaciji:

### Rizici i vektori prijetnji

- **Pogrešno konfigurirana logika autorizacije**: Pogrešna implementacija autorizacije u MCP poslužiteljima može izložiti osjetljive podatke i nepravilno primijeniti kontrole pristupa
- **Kompromitacija OAuth tokena**: Krađa tokena lokalnog MCP poslužitelja omogućuje napadačima da se predstavljaju kao poslužitelji i pristupaju uslugama nizvodno
- **Ranjivosti prijenosa tokena**: Nepravilno rukovanje tokenima stvara zaobilaznice sigurnosnih kontrola i praznine u odgovornosti
- **Prekomjerne privilegije**: MCP poslužitelji s previše privilegija krše načela najmanjih privilegija i proširuju površinu napada

#### Prijenos tokena: Kritični anti-obrazac

**Prijenos tokena je izričito zabranjen** u trenutnoj MCP specifikaciji autorizacije zbog ozbiljnih sigurnosnih implikacija:

##### Zaobilaženje sigurnosnih kontrola
- MCP poslužitelji i nizvodni API-ji implementiraju ključne sigurnosne kontrole (ograničavanje brzine, validacija zahtjeva, praćenje prometa) koje ovise o pravilnoj validaciji tokena
- Izravno korištenje tokena klijenta prema API-ju zaobilazi ove ključne zaštite, narušavajući sigurnosnu arhitekturu

##### Izazovi odgovornosti i revizije  
- MCP poslužitelji ne mogu razlikovati klijente koji koriste tokene izdane uzvodno, narušavajući revizijske tragove
- Dnevnici poslužitelja resursa nizvodno prikazuju obmanjujuće izvore zahtjeva umjesto stvarnih MCP poslužitelja posrednika
- Istrage incidenata i revizije usklađenosti postaju znatno teže

##### Rizici eksfiltracije podataka
- Nevalidirane tvrdnje tokena omogućuju zlonamjernim akterima s ukradenim tokenima korištenje MCP poslužitelja kao posrednika za eksfiltraciju podataka
- Kršenja granica povjerenja omogućuju neovlaštene obrasce pristupa koji zaobilaze predviđene sigurnosne kontrole

##### Vektori napada na više usluga
- Kompromitirani tokeni prihvaćeni od strane više usluga omogućuju lateralno kretanje kroz povezane sustave
- Pretpostavke povjerenja između usluga mogu biti narušene kada se ne može potvrditi podrijetlo tokena

### Sigurnosne kontrole i ublažavanja

**Kritični sigurnosni zahtjevi:**

> **OBAVEZNO**: MCP poslužitelji **NE SMIJU** prihvaćati tokene koji nisu izričito izdani za MCP poslužitelj

#### Kontrole autentifikacije i autorizacije

- **Temeljita revizija autorizacije**: Provesti sveobuhvatne revizije logike autorizacije MCP poslužitelja kako bi se osiguralo da samo namijenjeni korisnici i klijenti mogu pristupiti osjetljivim resursima  
  - **Vodič za implementaciju**: [Azure API Management kao autentifikacijska vrata za MCP poslužitelje](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)  
  - **Integracija identiteta**: [Korištenje Microsoft Entra ID za autentifikaciju MCP poslužitelja](https://den.dev/blog/mcp-server-auth-entra-id-session/)

- **Sigurno upravljanje tokenima**: Implementirati [Microsoftove najbolje prakse za validaciju i životni ciklus tokena](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens)  
  - Validirati tvrdnje publike tokena kako bi odgovarale identitetu MCP poslužitelja  
  - Implementirati pravilnu rotaciju i politike isteka tokena  
  - Spriječiti napade ponovnog korištenja tokena i neovlaštenu upotrebu  

- **Zaštićeno pohranjivanje tokena**: Osigurati pohranu tokena enkripcijom u mirovanju i tijekom prijenosa  
  - **Najbolje prakse**: [Smjernice za sigurnu pohranu i enkripciju tokena](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

#### Implementacija kontrole pristupa

- **Načelo najmanjih privilegija**: Dodijeliti MCP poslužiteljima samo minimalne privilegije potrebne za predviđenu funkcionalnost  
  - Redovite revizije i ažuriranja privilegija kako bi se spriječilo nakupljanje privilegija  
  - **Microsoftova dokumentacija**: [Siguran pristup s najmanje privilegija](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)

- **Kontrola pristupa temeljena na ulogama (RBAC)**: Implementirati precizno definirane uloge  
  - Ograničiti uloge na specifične resurse i radnje  
  - Izbjegavati široke ili nepotrebne privilegije koje proširuju površinu napada  

- **Kontinuirano praćenje privilegija**: Implementirati stalno praćenje i reviziju pristupa  
  - Praćenje obrazaca korištenja privilegija radi otkrivanja anomalija  
  - Brzo otklanjanje prekomjernih ili neiskorištenih privilegija  

## Sigurnosne prijetnje specifične za AI

### Napadi ubrizgavanja prompta i manipulacije alatima

Moderne MCP implementacije suočavaju se sa sofisticiranim vektorima napada specifičnim za AI koje tradicionalne sigurnosne mjere ne mogu u potpunosti adresirati:

#### **Neizravno ubrizgavanje prompta (Cross-Domain Prompt Injection)**

**Neizravno ubrizgavanje prompta** predstavlja jednu od najkritičnijih ranjivosti u MCP sustavima vođenim AI-jem. Napadači ugrađuju zlonamjerne upute unutar vanjskog sadržaja—dokumenata, web stranica, e-mailova ili izvora podataka—koje AI sustavi kasnije obrađuju kao legitimne naredbe.
- **Sigurno generiranje sesija**: Koristite kriptografski sigurne, nedeterminističke ID-ove sesija generirane pomoću sigurnih generatora slučajnih brojeva  
- **Povezivanje s korisnikom**: Povežite ID-ove sesija s korisničkim informacijama koristeći formate poput `<user_id>:<session_id>` kako biste spriječili zloupotrebu sesija između korisnika  
- **Upravljanje životnim ciklusom sesije**: Implementirajte pravilno istecanje, rotaciju i poništavanje sesija kako biste smanjili prozore ranjivosti  
- **Sigurnost prijenosa**: Obavezno koristite HTTPS za svu komunikaciju kako biste spriječili presretanje ID-ova sesija  

### Problem zbunjenog zamjenika

**Problem zbunjenog zamjenika** nastaje kada MCP poslužitelji djeluju kao autentifikacijski posrednici između klijenata i usluga trećih strana, stvarajući prilike za zaobilaženje autorizacije iskorištavanjem statičnih ID-ova klijenata.

#### **Mehanika napada i rizici**

- **Zaobilaženje pristanka putem kolačića**: Prethodna autentifikacija korisnika stvara kolačiće pristanka koje napadači iskorištavaju putem zlonamjernih zahtjeva za autorizaciju s prilagođenim URI-jevima za preusmjeravanje  
- **Krađa autorizacijskog koda**: Postojeći kolačići pristanka mogu uzrokovati da poslužitelji za autorizaciju preskoče ekrane za pristanak, preusmjeravajući kodove na krajnje točke pod kontrolom napadača  
- **Neovlašteni pristup API-ju**: Ukradeni autorizacijski kodovi omogućuju razmjenu tokena i lažno predstavljanje korisnika bez eksplicitnog odobrenja  

#### **Strategije ublažavanja**

**Obavezne kontrole:**
- **Eksplicitni zahtjevi za pristanak**: MCP proxy poslužitelji koji koriste statične ID-ove klijenata **MORAJU** dobiti pristanak korisnika za svakog dinamički registriranog klijenta  
- **Implementacija sigurnosti OAuth 2.1**: Slijedite trenutne najbolje prakse sigurnosti OAuth-a, uključujući PKCE (Proof Key for Code Exchange) za sve zahtjeve za autorizaciju  
- **Stroga validacija klijenata**: Provedite rigoroznu validaciju URI-jeva za preusmjeravanje i identifikatora klijenata kako biste spriječili zloupotrebu  

### Ranjivosti prosljeđivanja tokena  

**Prosljeđivanje tokena** predstavlja eksplicitni antipattern gdje MCP poslužitelji prihvaćaju tokene klijenata bez odgovarajuće validacije i prosljeđuju ih prema dolje API-jevima, kršeći MCP specifikacije autorizacije.

#### **Sigurnosne implikacije**

- **Zaobilaženje kontrole**: Izravno korištenje tokena klijenata prema API-ju zaobilazi ključne kontrole poput ograničavanja brzine, validacije i praćenja  
- **Kompromitiranje revizijskog traga**: Tokeni izdani uzvodno onemogućuju identifikaciju klijenata, narušavajući mogućnosti istrage incidenata  
- **Eksfiltracija podataka putem proxyja**: Nevalidirani tokeni omogućuju zlonamjernim akterima korištenje poslužitelja kao proxyja za neovlašteni pristup podacima  
- **Kršenje granica povjerenja**: Pretpostavke povjerenja usluga prema dolje mogu biti narušene kada se ne može potvrditi podrijetlo tokena  
- **Širenje napada na više usluga**: Kompromitirani tokeni prihvaćeni u više usluga omogućuju lateralno kretanje  

#### **Potrebne sigurnosne kontrole**

**Nepregovarački zahtjevi:**
- **Validacija tokena**: MCP poslužitelji **NE SMIJU** prihvaćati tokene koji nisu izričito izdani za MCP poslužitelj  
- **Provjera publike**: Uvijek provjerite da tvrdnje o publici tokena odgovaraju identitetu MCP poslužitelja  
- **Pravilno upravljanje životnim ciklusom tokena**: Implementirajte kratkotrajne pristupne tokene s praksama sigurne rotacije  

## Sigurnost opskrbnog lanca za AI sustave

Sigurnost opskrbnog lanca evoluirala je izvan tradicionalnih softverskih ovisnosti kako bi obuhvatila cijeli AI ekosustav. Moderne MCP implementacije moraju rigorozno provjeravati i nadzirati sve AI komponente, jer svaka od njih uvodi potencijalne ranjivosti koje mogu ugroziti integritet sustava.

### Proširene komponente opskrbnog lanca za AI

**Tradicionalne softverske ovisnosti:**
- Open-source biblioteke i okviri  
- Slike kontejnera i osnovni sustavi  
- Alati za razvoj i CI/CD pipelineovi  
- Infrastrukturne komponente i usluge  

**AI-specifični elementi opskrbnog lanca:**
- **Osnovni modeli**: Pretrenirani modeli od različitih pružatelja koji zahtijevaju provjeru podrijetla  
- **Usluge ugradnje**: Vanjske usluge za vektorizaciju i semantičko pretraživanje  
- **Pružatelji konteksta**: Izvori podataka, baze znanja i repozitoriji dokumenata  
- **API-ji trećih strana**: Vanjske AI usluge, ML pipelineovi i krajnje točke za obradu podataka  
- **Artefakti modela**: Težine, konfiguracije i varijante modela prilagođene za specifične zadatke  
- **Izvori podataka za treniranje**: Skupovi podataka korišteni za treniranje i prilagodbu modela  

### Sveobuhvatna strategija sigurnosti opskrbnog lanca

#### **Provjera komponenti i povjerenje**
- **Validacija podrijetla**: Provjerite podrijetlo, licenciranje i integritet svih AI komponenti prije integracije  
- **Sigurnosna procjena**: Provedite skeniranje ranjivosti i sigurnosne preglede za modele, izvore podataka i AI usluge  
- **Analiza reputacije**: Procijenite sigurnosni dosje i prakse pružatelja AI usluga  
- **Provjera usklađenosti**: Osigurajte da sve komponente zadovoljavaju sigurnosne i regulatorne zahtjeve organizacije  

#### **Sigurni pipelineovi za implementaciju**  
- **Automatizirana sigurnost CI/CD-a**: Integrirajte sigurnosno skeniranje kroz automatizirane pipelineove implementacije  
- **Integritet artefakata**: Implementirajte kriptografsku provjeru za sve implementirane artefakte (kod, modeli, konfiguracije)  
- **Postupna implementacija**: Koristite strategije postupne implementacije sa sigurnosnom validacijom u svakoj fazi  
- **Pouzdani repozitoriji artefakata**: Implementirajte samo iz provjerenih, sigurnih repozitorija artefakata  

#### **Kontinuirano praćenje i odgovor**
- **Skeniranje ovisnosti**: Kontinuirano praćenje ranjivosti za sve softverske i AI komponente  
- **Praćenje modela**: Kontinuirana procjena ponašanja modela, odstupanja u performansama i sigurnosnih anomalija  
- **Praćenje zdravlja usluga**: Nadziranje vanjskih AI usluga zbog dostupnosti, sigurnosnih incidenata i promjena politika  
- **Integracija obavještajnih podataka o prijetnjama**: Uključivanje feedova prijetnji specifičnih za AI i ML sigurnosne rizike  

#### **Kontrola pristupa i najmanje privilegije**
- **Dozvole na razini komponenata**: Ograničite pristup modelima, podacima i uslugama na temelju poslovne potrebe  
- **Upravljanje servisnim računima**: Implementirajte namjenske servisne račune s minimalnim potrebnim dozvolama  
- **Segmentacija mreže**: Izolirajte AI komponente i ograničite mrežni pristup između usluga  
- **Kontrole API gatewaya**: Koristite centralizirane API gatewaye za kontrolu i praćenje pristupa vanjskim AI uslugama  

#### **Odgovor na incidente i oporavak**
- **Postupci brzog odgovora**: Uspostavljeni procesi za zakrpe ili zamjenu kompromitiranih AI komponenti  
- **Rotacija vjerodajnica**: Automatizirani sustavi za rotaciju tajni, API ključeva i servisnih vjerodajnica  
- **Sposobnosti vraćanja**: Mogućnost brzog vraćanja na prethodne poznate dobre verzije AI komponenti  
- **Oporavak od kompromitacije opskrbnog lanca**: Specifični postupci za odgovaranje na kompromise AI usluga uzvodno  

### Microsoft alati za sigurnost i integraciju

**GitHub Advanced Security** pruža sveobuhvatnu zaštitu opskrbnog lanca uključujući:
- **Skeniranje tajni**: Automatsko otkrivanje vjerodajnica, API ključeva i tokena u repozitorijima  
- **Skeniranje ovisnosti**: Procjena ranjivosti za open-source ovisnosti i biblioteke  
- **CodeQL analiza**: Statička analiza koda za sigurnosne ranjivosti i probleme u kodiranju  
- **Uvidi u opskrbni lanac**: Vidljivost u zdravlje i sigurnosni status ovisnosti  

**Integracija s Azure DevOps i Azure Repos:**
- Besprijekorna integracija sigurnosnog skeniranja na Microsoftovim platformama za razvoj  
- Automatske sigurnosne provjere u Azure Pipelineovima za AI radna opterećenja  
- Provedba politika za sigurnu implementaciju AI komponenti  

**Interna praksa Microsofta:**
Microsoft implementira opsežne prakse sigurnosti opskrbnog lanca u svim proizvodima. Saznajte više o dokazanim pristupima u [Put do osiguravanja opskrbnog lanca softvera u Microsoftu](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).
### **Microsoft Sigurnosna Rješenja**
- [Microsoft Prompt Shields Dokumentacija](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety Service](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Microsoft Entra ID Sigurnost](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Najbolje Prakse za Upravljanje Azure Tokenima](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [GitHub Napredna Sigurnost](https://github.com/security/advanced-security)

### **Vodiči za Implementaciju i Tutorijali**
- [Azure API Management kao MCP Autentifikacijska Gateway](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Microsoft Entra ID Autentifikacija s MCP Serverima](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Sigurno Pohranjivanje Tokena i Enkripcija (Video)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### **DevOps i Sigurnost Opskrbnog Lanca**
- [Azure DevOps Sigurnost](https://azure.microsoft.com/products/devops)
- [Azure Repos Sigurnost](https://azure.microsoft.com/products/devops/repos/)
- [Microsoftovo Putovanje Sigurnosti Opskrbnog Lanca](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)

## **Dodatna Sigurnosna Dokumentacija**

Za sveobuhvatne sigurnosne smjernice, pogledajte ove specijalizirane dokumente u ovom odjeljku:

- **[MCP Najbolje Sigurnosne Prakse 2025](./mcp-security-best-practices-2025.md)** - Kompletne najbolje sigurnosne prakse za MCP implementacije  
- **[Implementacija Azure Content Safety](./azure-content-safety-implementation.md)** - Praktični primjeri implementacije za integraciju Azure Content Safety  
- **[MCP Sigurnosne Kontrole 2025](./mcp-security-controls-2025.md)** - Najnovije sigurnosne kontrole i tehnike za MCP implementacije  
- **[Brzi Referentni Vodič za MCP Najbolje Prakse](./mcp-best-practices.md)** - Brzi vodič za osnovne MCP sigurnosne prakse  

---

## Što Slijedi

Sljedeće: [Poglavlje 3: Početak](../03-GettingStarted/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prijevod [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo osigurati točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati mjerodavnim izvorom. Za ključne informacije preporučuje se profesionalni prijevod od strane stručnjaka. Ne preuzimamo odgovornost za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.