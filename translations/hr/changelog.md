<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f9d56a1327805a9f6df085a41fb81083",
  "translation_date": "2025-09-30T22:40:42+00:00",
  "source_file": "changelog.md",
  "language_code": "hr"
}
-->
# Dnevnik promjena: MCP za početnike - Kurikulum

Ovaj dokument služi kao zapis svih značajnih promjena napravljenih u kurikulumu Model Context Protocol (MCP) za početnike. Promjene su dokumentirane obrnutim kronološkim redoslijedom (najnovije promjene na vrhu).

## 29. rujna 2025.

### MCP Server Database Integration Labs - Sveobuhvatan praktični put učenja

#### 11-MCPServerHandsOnLabs - Novi kompletan kurikulum za integraciju baza podataka
- **Kompletan put učenja s 13 laboratorija**: Dodan sveobuhvatan praktični kurikulum za izgradnju MCP servera spremnih za produkciju s integracijom PostgreSQL baze podataka
  - **Implementacija u stvarnom svijetu**: Zava Retail analitički slučaj demonstrira obrasce na razini poduzeća
  - **Strukturirani napredak u učenju**:
    - **Laboratoriji 00-03: Osnove** - Uvod, osnovna arhitektura, sigurnost i višekorisnički pristup, postavljanje okruženja
    - **Laboratoriji 04-06: Izgradnja MCP servera** - Dizajn baze podataka i shema, implementacija MCP servera, razvoj alata  
    - **Laboratoriji 07-09: Napredne značajke** - Integracija semantičke pretrage, testiranje i otklanjanje pogrešaka, integracija s VS Code
    - **Laboratoriji 10-12: Produkcija i najbolje prakse** - Strategije implementacije, praćenje i preglednost, najbolje prakse i optimizacija
  - **Tehnologije na razini poduzeća**: FastMCP okvir, PostgreSQL s pgvector, Azure OpenAI embeddings, Azure Container Apps, Application Insights
  - **Napredne značajke**: Sigurnost na razini redaka (RLS), semantička pretraga, višekorisnički pristup podacima, vektorski embeddings, praćenje u stvarnom vremenu

#### Standardizacija terminologije - Pretvorba modula u laboratorije
- **Sveobuhvatno ažuriranje dokumentacije**: Sustavno ažurirani svi README datoteke u 11-MCPServerHandsOnLabs kako bi se koristila terminologija "Laboratorij" umjesto "Modul"
  - **Naslovi sekcija**: Ažurirano "Što ovaj modul pokriva" u "Što ovaj laboratorij pokriva" u svih 13 laboratorija
  - **Opis sadržaja**: Promijenjeno "Ovaj modul pruža..." u "Ovaj laboratorij pruža..." u cijeloj dokumentaciji
  - **Ciljevi učenja**: Ažurirano "Na kraju ovog modula..." u "Na kraju ovog laboratorija..."
  - **Navigacijski linkovi**: Pretvoreni svi "Modul XX:" reference u "Laboratorij XX:" u međusobnim referencama i navigaciji
  - **Praćenje završetka**: Ažurirano "Nakon završetka ovog modula..." u "Nakon završetka ovog laboratorija..."
  - **Očuvane tehničke reference**: Održane Python reference modula u konfiguracijskim datotekama (npr., `"module": "mcp_server.main"`)

#### Poboljšanje vodiča za učenje (study_guide.md)
- **Vizualna mapa kurikuluma**: Dodana nova sekcija "11. Laboratoriji za integraciju baza podataka" s vizualizacijom strukture laboratorija
- **Struktura repozitorija**: Ažurirano s deset na jedanaest glavnih sekcija s detaljnim opisom 11-MCPServerHandsOnLabs
- **Smjernice za put učenja**: Poboljšane navigacijske upute za pokrivanje sekcija 00-11
- **Pokriće tehnologija**: Dodani detalji o integraciji FastMCP, PostgreSQL i Azure usluga
- **Rezultati učenja**: Naglašeno razvijanje servera spremnih za produkciju, obrasci integracije baza podataka i sigurnost na razini poduzeća

#### Poboljšanje strukture glavnog README-a
- **Terminologija temeljena na laboratorijima**: Ažuriran glavni README.md u 11-MCPServerHandsOnLabs za dosljedno korištenje strukture "Laboratorij"
- **Organizacija puta učenja**: Jasna progresija od osnovnih koncepata preko napredne implementacije do produkcijske primjene
- **Fokus na stvarni svijet**: Naglasak na praktično, praktično učenje s obrascima i tehnologijama na razini poduzeća

### Poboljšanja kvalitete i dosljednosti dokumentacije
- **Naglasak na praktično učenje**: Pojačan praktični, laboratorijski pristup kroz cijelu dokumentaciju
- **Fokus na obrasce na razini poduzeća**: Istaknute implementacije spremne za produkciju i razmatranja sigurnosti na razini poduzeća
- **Integracija tehnologija**: Sveobuhvatno pokriće modernih Azure usluga i AI obrazaca integracije
- **Napredak u učenju**: Jasna, strukturirana staza od osnovnih koncepata do produkcijske primjene

## 26. rujna 2025.

### Poboljšanje studija slučaja - Integracija GitHub MCP Registry

#### Studije slučaja (09-CaseStudy/) - Fokus na razvoj ekosustava
- **README.md**: Veliko proširenje s detaljnom studijom slučaja GitHub MCP Registry
  - **Studija slučaja GitHub MCP Registry**: Nova sveobuhvatna studija slučaja koja ispituje lansiranje GitHub MCP Registry u rujnu 2025.
    - **Analiza problema**: Detaljno ispitivanje izazova fragmentiranog otkrivanja i implementacije MCP servera
    - **Arhitektura rješenja**: Pristup centraliziranog registra GitHub-a s instalacijom jednim klikom u VS Code
    - **Poslovni utjecaj**: Mjerljiva poboljšanja u onboardingu i produktivnosti developera
    - **Strateška vrijednost**: Fokus na modularnu implementaciju agenata i interoperabilnost među alatima
    - **Razvoj ekosustava**: Pozicioniranje kao temeljna platforma za integraciju agenata
  - **Poboljšana struktura studija slučaja**: Ažurirane sve studije slučaja s dosljednim formatiranjem i sveobuhvatnim opisima
    - Azure AI Travel Agents: Naglasak na orkestraciji više agenata
    - Integracija Azure DevOps: Fokus na automatizaciju tijeka rada
    - Dohvaćanje dokumentacije u stvarnom vremenu: Implementacija Python konzolnog klijenta
    - Interaktivni generator plana učenja: Chainlit konverzacijska web aplikacija
    - Dokumentacija u uređivaču: Integracija VS Code i GitHub Copilot
    - Upravljanje Azure API-jem: Obrasci integracije API-ja na razini poduzeća
    - GitHub MCP Registry: Razvoj ekosustava i platforma za zajednicu
  - **Sveobuhvatan zaključak**: Prepisan zaključak koji ističe sedam studija slučaja koje pokrivaju različite dimenzije MCP implementacije
    - Integracija na razini poduzeća, orkestracija više agenata, produktivnost developera
    - Razvoj ekosustava, kategorizacija obrazovnih aplikacija
    - Poboljšani uvidi u arhitektonske obrasce, strategije implementacije i najbolje prakse
    - Naglasak na MCP kao zreli, spremni za produkciju protokol

#### Ažuriranja vodiča za učenje (study_guide.md)
- **Vizualna mapa kurikuluma**: Ažurirana mentalna mapa za uključivanje GitHub MCP Registry u sekciju studija slučaja
- **Opis studija slučaja**: Poboljšano od generičkih opisa do detaljnog pregleda sedam sveobuhvatnih studija slučaja
- **Struktura repozitorija**: Ažurirana sekcija 10 kako bi odražavala sveobuhvatno pokriće studija slučaja sa specifičnim detaljima implementacije
- **Integracija dnevnika promjena**: Dodan unos za 26. rujna 2025. koji dokumentira dodatak GitHub MCP Registry i poboljšanja studija slučaja
- **Ažuriranja datuma**: Ažuriran vremenski pečat u podnožju kako bi odražavao najnoviju reviziju (26. rujna 2025.)

### Poboljšanja kvalitete dokumentacije
- **Poboljšanje dosljednosti**: Standardizirano formatiranje i struktura studija slučaja u svih sedam primjera
- **Sveobuhvatno pokriće**: Studije slučaja sada pokrivaju scenarije na razini poduzeća, produktivnost developera i razvoj ekosustava
- **Strateško pozicioniranje**: Pojačan fokus na MCP kao temeljnu platformu za implementaciju agentičkih sustava
- **Integracija resursa**: Ažurirani dodatni resursi za uključivanje linka na GitHub MCP Registry

## 15. rujna 2025.

### Proširenje naprednih tema - Prilagođeni transporti i inženjering konteksta

#### MCP Prilagođeni transporti (05-AdvancedTopics/mcp-transport/) - Novi vodič za naprednu implementaciju
- **README.md**: Kompletan vodič za implementaciju prilagođenih MCP transportnih mehanizama
  - **Azure Event Grid Transport**: Sveobuhvatna implementacija serverless transporta temeljenog na događajima
    - Primjeri u C#, TypeScript i Pythonu s integracijom Azure Functions
    - Obrasci arhitekture temeljene na događajima za skalabilna MCP rješenja
    - Webhook prijemnici i rukovanje porukama temeljenim na push metodi
  - **Azure Event Hubs Transport**: Implementacija transporta za streaming visokog kapaciteta
    - Sposobnosti za streaming u stvarnom vremenu za scenarije niske latencije
    - Strategije particioniranja i upravljanje kontrolnim točkama
    - Grupiranje poruka i optimizacija performansi
  - **Obrasci integracije na razini poduzeća**: Primjeri arhitekture spremne za produkciju
    - Distribuirana MCP obrada preko više Azure Functions
    - Hibridne transportne arhitekture koje kombiniraju više vrsta transporta
    - Strategije trajnosti poruka, pouzdanosti i rukovanja pogreškama
  - **Sigurnost i praćenje**: Integracija Azure Key Vault i obrasci preglednosti
    - Autentifikacija pomoću upravljanog identiteta i pristup s najmanjim privilegijama
    - Telemetrija Application Insights i praćenje performansi
    - Prekidači krugova i obrasci tolerancije na greške
  - **Okviri za testiranje**: Sveobuhvatne strategije testiranja za prilagođene transporte
    - Jedinično testiranje s testnim duplikatima i okvirima za simulaciju
    - Integracijsko testiranje s Azure Test Containers
    - Razmatranja performansi i testiranja opterećenja

#### Inženjering konteksta (05-AdvancedTopics/mcp-contextengineering/) - Nova AI disciplina
- **README.md**: Sveobuhvatno istraživanje inženjeringa konteksta kao nove discipline
  - **Osnovni principi**: Potpuno dijeljenje konteksta, svijest o odlukama akcije i upravljanje prozorom konteksta
  - **Usklađenost s MCP protokolom**: Kako MCP dizajn rješava izazove inženjeringa konteksta
    - Ograničenja prozora konteksta i strategije progresivnog učitavanja
    - Određivanje relevantnosti i dinamičko dohvaćanje konteksta
    - Višemodalno rukovanje kontekstom i razmatranja sigurnosti
  - **Pristupi implementaciji**: Jednostruka arhitektura vs. arhitektura s više agenata
    - Tehnike segmentacije i prioritizacije konteksta
    - Progresivno učitavanje i strategije kompresije konteksta
    - Slojeviti pristupi kontekstu i optimizacija dohvaćanja
  - **Okvir za mjerenje**: Novi metrički sustavi za procjenu učinkovitosti konteksta
    - Učinkovitost ulaza, performanse, kvaliteta i razmatranja korisničkog iskustva
    - Eksperimentalni pristupi optimizaciji konteksta
    - Analiza neuspjeha i metodologije poboljšanja

#### Ažuriranja navigacije kurikuluma (README.md)
- **Poboljšana struktura modula**: Ažurirana tablica kurikuluma za uključivanje novih naprednih tema
  - Dodani inženjering konteksta (5.14) i prilagođeni transport (5.15)
  - Dosljedno formatiranje i navigacijski linkovi kroz sve module
  - Ažurirani opisi kako bi odražavali trenutni opseg sadržaja

### Poboljšanja strukture direktorija
- **Standardizacija naziva**: Preimenovano "mcp transport" u "mcp-transport" radi dosljednosti s ostalim mapama naprednih tema
- **Organizacija sadržaja**: Sve mape 05-AdvancedTopics sada slijede dosljedan obrazac imenovanja (mcp-[tema])

### Poboljšanja kvalitete dokumentacije
- **Usklađenost sa specifikacijom MCP**: Svi novi sadržaji referiraju trenutnu MCP specifikaciju 2025-06-18
- **Primjeri na više jezika**: Sveobuhvatni primjeri koda u C#, TypeScript i Pythonu
- **Fokus na razini poduzeća**: Obrasci spremni za produkciju i integracija s Azure cloudom kroz cijeli sadržaj
- **Vizualna dokumentacija**: Mermaid dijagrami za vizualizaciju arhitekture i tijeka

## 18. kolovoza 2025.

### Sveobuhvatno ažuriranje dokumentacije - MCP standardi 2025-06-18

#### MCP Sigurnosne najbolje prakse (02-Security/) - Potpuna modernizacija
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Potpuno prepisano u skladu s MCP specifikacijom 2025-06-18
  - **Obvezni zahtjevi**: Dodani eksplicitni MUST/MUST NOT zahtjevi iz službene specifikacije s jasnim vizualnim indikatorima
  - **12 osnovnih sigurnosnih praksi**: Restrukturirano s popisa od 15 stavki u sveobuhvatne sigurnosne domene
    - Sigurnost tokena i autentifikacija s integracijom vanjskog pružatelja identiteta
    - Upravljanje sesijama i sigurnost transporta s kriptografskim zahtjevima
    - Zaštita od AI-specifičnih prijetnji s integracijom Microsoft Prompt Shields
    - Kontrola pristupa i dozvola s principom najmanjih privilegija
    - Sigurnost sadržaja i praćenje s integracijom Azure Content Safety
    - Sigurnost opskrbnog lanca s provjerom komponenti
    - OAuth sigurnost i prevencija napada "zbunjeni zamjenik" s PKCE implementacijom
    - Odgovor na incidente i oporavak s automatiziranim sposobnostima
    - Usklađenost i upravljanje s regulatornim zahtjevima
    - Napredne sigurnosne kontrole s arhitekturom nultog povjerenja
    - Integracija Microsoft sigurnosnog ekosustava s sveobuhvatnim rješenjima
    - Kontinuirana evolucija sigurnosti s adaptivnim praksama
  - **Microsoft sigurnosna rješenja**: Poboljšane smjernice za integraciju Prompt Shields, Azure Content Safety, Entra ID i GitHub Advanced Security
  - **Resursi za implementaciju**: Kategorizirani sveobuhvatni linkovi na službenu MCP dokumentaciju, Microsoft sigurnosna rješenja, sigurnosne standarde i vodiče za implementaciju

#### Napredne sigurnosne kontrole (02-Security/) - Implementacija na razini poduzeća
- **MCP-SECURITY-CONTROLS-2025.md**: Potpuno preuređeno s sigurnosnim okvirom na razini poduzeća
  - **9 sveobuhvatnih sigurnosnih domena**: Prošireno od osnovnih kontrola do detaljnog okvira za poduzeća
    - Napredna autentifikacija i autorizacija s integracijom Microsoft Entra ID
    - Sigurnost tokena i kontrole protiv prosljeđivanja s sveobuhvatnom validacijom
    - Sigurnosne kontrole sesije s prevencijom otmica
    - AI-specifične sigurnosne kontrole s prevencijom ubrizgavanja prompta i trovanja alata
    - Prevencija napada "zbunjeni zamjenik" s OAuth proxy sigurnošću
    - Sigurnost izvršavanja alata s izolacijom i sandboxingom
    - Kontrole sigurnosti opskrbnog lanca s verifikacijom ovisnosti
    - Kontrole praćenja i
- **Vizualni pokazatelji**: Jasno označavanje obaveznih zahtjeva naspram preporučenih praksi

#### Osnovni koncepti (01-CoreConcepts/) - Potpuna modernizacija
- **Ažuriranje verzije protokola**: Ažurirano prema trenutnoj MCP specifikaciji 2025-06-18 s verzioniranjem temeljenim na datumu (format YYYY-MM-DD)
- **Rafiniranje arhitekture**: Poboljšani opisi domaćina, klijenata i poslužitelja kako bi odražavali trenutne MCP arhitekturne obrasce
  - Domaćini sada jasno definirani kao AI aplikacije koje koordiniraju više MCP klijentskih veza
  - Klijenti opisani kao konektori protokola koji održavaju odnose jedan-na-jedan s poslužiteljima
  - Poslužitelji poboljšani scenarijima lokalne naspram udaljene implementacije
- **Restrukturiranje primitiva**: Potpuna revizija primitiva poslužitelja i klijenata
  - Primitivi poslužitelja: Resursi (izvori podataka), upiti (predlošci), alati (izvršne funkcije) s detaljnim objašnjenjima i primjerima
  - Primitivi klijenata: Uzorkovanje (LLM dovršavanja), prikupljanje (unos korisnika), zapisivanje (debugging/nadzor)
  - Ažurirano prema trenutnim obrascima metoda otkrivanja (`*/list`), dohvaćanja (`*/get`) i izvršavanja (`*/call`)
- **Arhitektura protokola**: Uveden model arhitekture s dva sloja
  - Sloj podataka: Temelj JSON-RPC 2.0 s upravljanjem životnim ciklusom i primitivima
  - Sloj prijenosa: STDIO (lokalno) i Streamable HTTP sa SSE (udaljeni) mehanizmima prijenosa
- **Sigurnosni okvir**: Sveobuhvatni sigurnosni principi uključujući eksplicitni pristanak korisnika, zaštitu privatnosti podataka, sigurnost izvršavanja alata i sigurnost sloja prijenosa
- **Obrasci komunikacije**: Ažurirane poruke protokola za prikaz inicijalizacije, otkrivanja, izvršavanja i tokova obavijesti
- **Primjeri koda**: Osvježeni primjeri na više jezika (.NET, Java, Python, JavaScript) kako bi odražavali trenutne MCP SDK obrasce

#### Sigurnost (02-Security/) - Sveobuhvatna revizija sigurnosti  
- **Usklađenost sa standardima**: Potpuna usklađenost sa zahtjevima sigurnosti MCP specifikacije 2025-06-18
- **Evolucija autentifikacije**: Dokumentirana evolucija od prilagođenih OAuth poslužitelja do delegacije vanjskim pružateljima identiteta (Microsoft Entra ID)
- **Analiza prijetnji specifičnih za AI**: Poboljšano pokrivanje modernih vektora napada na AI
  - Detaljni scenariji napada ubrizgavanja upita s primjerima iz stvarnog svijeta
  - Mehanizmi trovanja alata i obrasci napada "rug pull"
  - Trovanje kontekstnog prozora i napadi zbunjivanja modela
- **Microsoft AI sigurnosna rješenja**: Sveobuhvatno pokrivanje Microsoft sigurnosnog ekosustava
  - AI Prompt Shields s naprednom detekcijom, isticanjem i tehnikama razgraničenja
  - Obrasci integracije Azure Content Safety
  - GitHub Advanced Security za zaštitu opskrbnog lanca
- **Napredne mjere ublažavanja prijetnji**: Detaljne sigurnosne kontrole za
  - Preotimanje sesije s MCP-specifičnim scenarijima napada i zahtjevima za kriptografske ID-ove sesije
  - Problemi zbunjenog zamjenika u MCP proxy scenarijima s eksplicitnim zahtjevima za pristanak
  - Ranljivosti prosljeđivanja tokena s obaveznim kontrolama validacije
- **Sigurnost opskrbnog lanca**: Prošireno pokrivanje AI opskrbnog lanca uključujući temeljne modele, usluge ugrađivanja, pružatelje konteksta i API-je trećih strana
- **Temeljna sigurnost**: Poboljšana integracija s obrascima sigurnosti poduzeća uključujući arhitekturu nultog povjerenja i Microsoft sigurnosni ekosustav
- **Organizacija resursa**: Kategorizirani sveobuhvatni linkovi na resurse prema vrsti (službeni dokumenti, standardi, istraživanja, Microsoft rješenja, vodiči za implementaciju)

### Poboljšanja kvalitete dokumentacije
- **Strukturirani ciljevi učenja**: Poboljšani ciljevi učenja s konkretnim, izvedivim ishodima
- **Unakrsne reference**: Dodane poveznice između povezanih tema sigurnosti i osnovnih koncepata
- **Ažurirane informacije**: Ažurirani svi datumski reference i poveznice na specifikacije prema trenutnim standardima
- **Vodič za implementaciju**: Dodane konkretne, izvedive smjernice za implementaciju kroz oba odjeljka

## 16. srpnja 2025.

### Poboljšanja README-a i navigacije
- Potpuno redizajnirana navigacija kurikuluma u README.md
- Zamijenjene `<details>` oznake pristupačnijim formatom temeljenim na tablicama
- Kreirane alternativne opcije izgleda u novoj mapi "alternative_layouts"
- Dodani primjeri navigacije u stilu kartica, s tabovima i harmonikom
- Ažuriran odjeljak strukture repozitorija kako bi uključio sve najnovije datoteke
- Poboljšan odjeljak "Kako koristiti ovaj kurikulum" s jasnim preporukama
- Ažurirane poveznice na MCP specifikacije kako bi ukazivale na ispravne URL-ove
- Dodan odjeljak Inženjering konteksta (5.14) u strukturu kurikuluma

### Ažuriranja vodiča za učenje
- Potpuno revidiran vodič za učenje kako bi se uskladio s trenutnom strukturom repozitorija
- Dodani novi odjeljci za MCP klijente i alate te popularne MCP poslužitelje
- Ažurirana vizualna karta kurikuluma kako bi točno odražavala sve teme
- Poboljšani opisi naprednih tema kako bi pokrili sva specijalizirana područja
- Ažuriran odjeljak studija slučaja kako bi odražavao stvarne primjere
- Dodan ovaj sveobuhvatni dnevnik promjena

### Doprinosi zajednice (06-CommunityContributions/)
- Dodane detaljne informacije o MCP poslužiteljima za generiranje slika
- Dodan sveobuhvatan odjeljak o korištenju Claudea u VSCode-u
- Dodane upute za postavljanje i korištenje Cline terminal klijenta
- Ažuriran odjeljak MCP klijenata kako bi uključio sve popularne opcije klijenata
- Poboljšani primjeri doprinosa s točnijim uzorcima koda

### Napredne teme (05-AdvancedTopics/)
- Organizirane sve mape specijaliziranih tema s dosljednim nazivima
- Dodani materijali i primjeri za inženjering konteksta
- Dodana dokumentacija za integraciju Foundry agenta
- Poboljšana dokumentacija za sigurnosnu integraciju Entra ID-a

## 11. lipnja 2025.

### Početno stvaranje
- Objavljena prva verzija kurikuluma MCP za početnike
- Kreirana osnovna struktura za svih 10 glavnih odjeljaka
- Implementirana vizualna karta kurikuluma za navigaciju
- Dodani početni uzorci projekata na više programskih jezika

### Početak rada (03-GettingStarted/)
- Kreirani prvi primjeri implementacije poslužitelja
- Dodane smjernice za razvoj klijenata
- Uključene upute za integraciju LLM klijenata
- Dodana dokumentacija za integraciju s VS Code-om
- Implementirani primjeri poslužitelja sa Server-Sent Events (SSE)

### Osnovni koncepti (01-CoreConcepts/)
- Dodano detaljno objašnjenje arhitekture klijent-poslužitelj
- Kreirana dokumentacija o ključnim komponentama protokola
- Dokumentirani obrasci poruka u MCP-u

## 23. svibnja 2025.

### Struktura repozitorija
- Inicijaliziran repozitorij s osnovnom strukturom mapa
- Kreirani README datoteke za svaki glavni odjeljak
- Postavljena infrastruktura za prijevod
- Dodani slikovni resursi i dijagrami

### Dokumentacija
- Kreiran početni README.md s pregledom kurikuluma
- Dodani CODE_OF_CONDUCT.md i SECURITY.md
- Postavljen SUPPORT.md s uputama za dobivanje pomoći
- Kreirana preliminarna struktura vodiča za učenje

## 15. travnja 2025.

### Planiranje i okvir
- Početno planiranje kurikuluma MCP za početnike
- Definirani ciljevi učenja i ciljana publika
- Nacrtana struktura kurikuluma s 10 odjeljaka
- Razvijen konceptualni okvir za primjere i studije slučaja
- Kreirani početni prototipovi primjera za ključne koncepte

---

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden pomoću AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo osigurati točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za ključne informacije preporučuje se profesionalni prijevod od strane čovjeka. Ne preuzimamo odgovornost za nesporazume ili pogrešna tumačenja koja mogu proizaći iz korištenja ovog prijevoda.