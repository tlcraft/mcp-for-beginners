<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "245b03ae1e7973094fe82b8051ae0939",
  "translation_date": "2025-08-18T17:14:47+00:00",
  "source_file": "changelog.md",
  "language_code": "hr"
}
-->
# Dnevnik promjena: MCP za početnike

Ovaj dokument služi kao zapis svih značajnih promjena napravljenih u kurikulumu Model Context Protocol (MCP) za početnike. Promjene su dokumentirane obrnutim kronološkim redoslijedom (najnovije promjene na vrhu).

## 18. kolovoza 2025.

### Sveobuhvatno ažuriranje dokumentacije - MCP standardi 2025-06-18

#### MCP Sigurnosne najbolje prakse (02-Security/) - Potpuna modernizacija
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Potpuno prepisano u skladu s MCP specifikacijom 2025-06-18
  - **Obvezni zahtjevi**: Dodani eksplicitni zahtjevi MUST/MUST NOT iz službene specifikacije s jasnim vizualnim oznakama
  - **12 osnovnih sigurnosnih praksi**: Restrukturirano s popisa od 15 stavki u sveobuhvatne sigurnosne domene
    - Sigurnost tokena i autentifikacija s integracijom vanjskog pružatelja identiteta
    - Upravljanje sesijama i sigurnost prijenosa s kriptografskim zahtjevima
    - Zaštita od AI-specifičnih prijetnji s integracijom Microsoft Prompt Shields
    - Kontrola pristupa i dozvole prema načelu najmanjih privilegija
    - Sigurnost sadržaja i nadzor s integracijom Azure Content Safety
    - Sigurnost opskrbnog lanca s provjerom komponenti
    - OAuth sigurnost i prevencija "Confused Deputy" napada s implementacijom PKCE
    - Odgovor na incidente i oporavak s automatiziranim mogućnostima
    - Usklađenost i upravljanje s regulatornim zahtjevima
    - Napredne sigurnosne kontrole s arhitekturom nultog povjerenja
    - Integracija s Microsoft sigurnosnim ekosustavom s cjelovitim rješenjima
    - Kontinuirana evolucija sigurnosti s prilagodljivim praksama
  - **Microsoft sigurnosna rješenja**: Poboljšane smjernice za integraciju Prompt Shields, Azure Content Safety, Entra ID i GitHub Advanced Security
  - **Resursi za implementaciju**: Kategorizirani sveobuhvatni linkovi na službenu MCP dokumentaciju, Microsoft sigurnosna rješenja, sigurnosne standarde i vodiče za implementaciju

#### Napredne sigurnosne kontrole (02-Security/) - Implementacija za poduzeća
- **MCP-SECURITY-CONTROLS-2025.md**: Potpuno preuređeno s okvirom sigurnosti za poduzeća
  - **9 sveobuhvatnih sigurnosnih domena**: Prošireno s osnovnih kontrola na detaljan okvir za poduzeća
    - Napredna autentifikacija i autorizacija s integracijom Microsoft Entra ID
    - Sigurnost tokena i kontrole protiv prosljeđivanja s detaljnom validacijom
    - Sigurnosne kontrole sesije s prevencijom otmica
    - AI-specifične sigurnosne kontrole s prevencijom ubrizgavanja prompta i trovanja alata
    - Prevencija "Confused Deputy" napada s OAuth proxy sigurnošću
    - Sigurnost izvršavanja alata s izolacijom i sandboxingom
    - Kontrole sigurnosti opskrbnog lanca s provjerom ovisnosti
    - Kontrole nadzora i detekcije s integracijom SIEM-a
    - Odgovor na incidente i oporavak s automatiziranim mogućnostima
  - **Primjeri implementacije**: Dodani detaljni YAML konfiguracijski blokovi i primjeri koda
  - **Integracija Microsoft rješenja**: Sveobuhvatno pokrivanje Azure sigurnosnih usluga, GitHub Advanced Security i upravljanja identitetima za poduzeća

#### Sigurnost naprednih tema (05-AdvancedTopics/mcp-security/) - Implementacija spremna za produkciju
- **README.md**: Potpuno prepisano za implementaciju sigurnosti u poduzećima
  - **Usklađenost s trenutnom specifikacijom**: Ažurirano prema MCP specifikaciji 2025-06-18 s obveznim sigurnosnim zahtjevima
  - **Poboljšana autentifikacija**: Integracija Microsoft Entra ID s detaljnim primjerima za .NET i Java Spring Security
  - **Integracija AI sigurnosti**: Implementacija Microsoft Prompt Shields i Azure Content Safety s detaljnim Python primjerima
  - **Napredna mitigacija prijetnji**: Sveobuhvatni primjeri implementacije za
    - Prevenciju "Confused Deputy" napada s PKCE i validacijom korisničkog pristanka
    - Prevenciju prosljeđivanja tokena s validacijom publike i sigurnim upravljanjem tokenima
    - Prevenciju otmica sesije s kriptografskim vezivanjem i analizom ponašanja
  - **Integracija sigurnosti za poduzeća**: Nadzor putem Azure Application Insights, detekcija prijetnji i sigurnost opskrbnog lanca
  - **Kontrolni popis za implementaciju**: Jasne obvezne i preporučene sigurnosne kontrole s prednostima Microsoft sigurnosnog ekosustava

### Kvaliteta dokumentacije i usklađenost sa standardima
- **Reference na specifikacije**: Ažurirane sve reference na trenutnu MCP specifikaciju 2025-06-18
- **Microsoft sigurnosni ekosustav**: Poboljšane smjernice za integraciju kroz svu sigurnosnu dokumentaciju
- **Praktična implementacija**: Dodani detaljni primjeri koda u .NET, Java i Python s obrascima za poduzeća
- **Organizacija resursa**: Sveobuhvatna kategorizacija službene dokumentacije, sigurnosnih standarda i vodiča za implementaciju
- **Vizualni indikatori**: Jasno označavanje obveznih zahtjeva naspram preporučenih praksi

#### Osnovni koncepti (01-CoreConcepts/) - Potpuna modernizacija
- **Ažuriranje verzije protokola**: Ažurirano na trenutnu MCP specifikaciju 2025-06-18 s verzioniranjem temeljenim na datumu (YYYY-MM-DD format)
- **Rafiniranje arhitekture**: Poboljšani opisi domaćina, klijenata i poslužitelja kako bi odražavali trenutne MCP arhitekturne obrasce
  - Domaćini sada jasno definirani kao AI aplikacije koje koordiniraju više MCP klijentskih veza
  - Klijenti opisani kao konektori protokola koji održavaju odnose jedan-na-jedan s poslužiteljima
  - Poslužitelji poboljšani s lokalnim i udaljenim scenarijima implementacije
- **Restrukturiranje primitiva**: Potpuna reorganizacija primitiva poslužitelja i klijenata
  - Primitivi poslužitelja: Resursi (izvori podataka), Promptovi (predlošci), Alati (izvršne funkcije) s detaljnim objašnjenjima i primjerima
  - Primitivi klijenata: Uzorkovanje (LLM dovršetci), Elicitacija (korisnički unos), Zapisivanje (debugging/nadzor)
  - Ažurirano s trenutnim metodama otkrivanja (`*/list`), dohvaćanja (`*/get`) i izvršavanja (`*/call`)
- **Arhitektura protokola**: Uveden model dvoslojne arhitekture
  - Sloj podataka: JSON-RPC 2.0 osnova s upravljanjem životnim ciklusom i primitivima
  - Sloj prijenosa: STDIO (lokalno) i Streamable HTTP sa SSE (udaljeno) mehanizmima prijenosa
- **Sigurnosni okvir**: Sveobuhvatna sigurnosna načela uključujući eksplicitan korisnički pristanak, zaštitu privatnosti podataka, sigurnost izvršavanja alata i sigurnost sloja prijenosa
- **Komunikacijski obrasci**: Ažurirane poruke protokola za prikaz inicijalizacije, otkrivanja, izvršavanja i obavijesti
- **Primjeri koda**: Osvježeni primjeri na više jezika (.NET, Java, Python, JavaScript) kako bi odražavali trenutne MCP SDK obrasce

#### Sigurnost (02-Security/) - Sveobuhvatna sigurnosna revizija  
- **Usklađenost sa standardima**: Potpuna usklađenost s MCP specifikacijom 2025-06-18 sigurnosnih zahtjeva
- **Evolucija autentifikacije**: Dokumentirana evolucija od prilagođenih OAuth poslužitelja do delegacije vanjskim pružateljima identiteta (Microsoft Entra ID)
- **Analiza AI-specifičnih prijetnji**: Poboljšano pokrivanje modernih AI vektora napada
  - Detaljni scenariji napada ubrizgavanja prompta s primjerima iz stvarnog svijeta
  - Mehanizmi trovanja alata i obrasci napada "rug pull"
  - Trovanje kontekstualnog prozora i napadi zbunjivanja modela
- **Microsoft AI sigurnosna rješenja**: Sveobuhvatno pokrivanje Microsoft sigurnosnog ekosustava
  - AI Prompt Shields s naprednom detekcijom, označavanjem i tehnikama razgraničenja
  - Azure Content Safety integracijski obrasci
  - GitHub Advanced Security za zaštitu opskrbnog lanca
- **Napredna mitigacija prijetnji**: Detaljne sigurnosne kontrole za
  - Otmicu sesije s MCP-specifičnim scenarijima napada i kriptografskim zahtjevima za ID sesije
  - Problemi "Confused Deputy" u MCP proxy scenarijima s eksplicitnim zahtjevima za pristanak
  - Ranljivosti prosljeđivanja tokena s obveznim kontrolama validacije
- **Sigurnost opskrbnog lanca**: Prošireno pokrivanje AI opskrbnog lanca uključujući osnovne modele, usluge ugradnje, pružatelje konteksta i API-je trećih strana
- **Osnovna sigurnost**: Poboljšana integracija s obrascima sigurnosti za poduzeća uključujući arhitekturu nultog povjerenja i Microsoft sigurnosni ekosustav
- **Organizacija resursa**: Kategorizirani sveobuhvatni linkovi na službene dokumente, standarde, istraživanja, Microsoft rješenja i vodiče za implementaciju

### Poboljšanja kvalitete dokumentacije
- **Strukturirani ciljevi učenja**: Poboljšani ciljevi učenja s konkretnim, provedivim ishodima
- **Unakrsne reference**: Dodane poveznice između povezanih sigurnosnih i osnovnih tema
- **Ažurne informacije**: Ažurirani svi datumi i poveznice na specifikacije prema trenutnim standardima
- **Smjernice za implementaciju**: Dodane specifične, provedive smjernice za implementaciju kroz oba odjeljka

## 16. srpnja 2025.

### Poboljšanja README-a i navigacije
- Potpuno redizajnirana navigacija kurikulumom u README.md
- Zamijenjene `<details>` oznake pristupačnijim formatom temeljenim na tablicama
- Stvorene alternativne opcije izgleda u novoj mapi "alternative_layouts"
- Dodani primjeri navigacije u stilu kartica, tabova i harmonike
- Ažuriran odjeljak strukture repozitorija kako bi uključio sve najnovije datoteke
- Poboljšan odjeljak "Kako koristiti ovaj kurikulum" s jasnim preporukama
- Ažurirane poveznice na MCP specifikacije kako bi ukazivale na ispravne URL-ove
- Dodan odjeljak o inženjeringu konteksta (5.14) u strukturu kurikuluma

### Ažuriranja vodiča za učenje
- Potpuno revidiran vodič za učenje kako bi bio usklađen s trenutnom strukturom repozitorija
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
- Organizirane sve mape specijaliziranih tema s dosljednim imenovanjem
- Dodani materijali i primjeri za inženjering konteksta
- Dodana dokumentacija za integraciju Foundry agenta
- Poboljšana dokumentacija za sigurnosnu integraciju Entra ID

## 11. lipnja 2025.

### Početno stvaranje
- Objavljena prva verzija kurikuluma MCP za početnike
- Stvorena osnovna struktura za svih 10 glavnih odjeljaka
- Implementirana vizualna karta kurikuluma za navigaciju
- Dodani početni uzorci projekata na više programskih jezika

### Početak rada (03-GettingStarted/)
- Stvoreni prvi primjeri implementacije poslužitelja
- Dodane smjernice za razvoj klijenata
- Uključene upute za integraciju LLM klijenata
- Dodana dokumentacija za integraciju s VS Code-om
- Implementirani primjeri poslužitelja sa Server-Sent Events (SSE)

### Osnovni koncepti (01-CoreConcepts/)
- Dodano detaljno objašnjenje arhitekture klijent-poslužitelj
- Stvorena dokumentacija o ključnim komponentama protokola
- Dokumentirani obrasci poruka u MCP-u

## 23. svibnja 2025.

### Struktura repozitorija
- Inicijaliziran repozitorij s osnovnom strukturom mapa
- Stvoreni README datoteke za svaki glavni odjeljak
- Postavljena infrastruktura za prijevode
- Dodani slikovni resursi i dijagrami

### Dokumentacija
- Stvoren početni README.md s pregledom kurikuluma
- Dodani CODE_OF_CONDUCT.md i SECURITY.md
- Postavljen SUPPORT.md s uputama za dobivanje pomoći
- Stvorena preliminarna struktura vodiča za učenje

## 15. travnja 2025.

### Planiranje i okvir
- Početno planiranje kurikuluma MCP za početnike
- Definirani ciljevi učenja i ciljana publika
- Nacrtana struktura od 10 odjeljaka kurikuluma
- Razvijen konceptualni okvir za primjere i studije slučaja
- Stvoreni početni prototipovi primjera za ključne koncepte

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prijevod [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo osigurati točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati mjerodavnim izvorom. Za ključne informacije preporučuje se profesionalni prijevod od strane stručnjaka. Ne preuzimamo odgovornost za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.