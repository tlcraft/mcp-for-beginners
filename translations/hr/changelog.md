<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "56dd5af7e84cc0db6e17e310112109ae",
  "translation_date": "2025-09-15T22:36:25+00:00",
  "source_file": "changelog.md",
  "language_code": "hr"
}
-->
# Dnevnik promjena: MCP za početnike - Kurikulum

Ovaj dokument služi kao zapis svih značajnih promjena napravljenih u kurikulumu Model Context Protocol (MCP) za početnike. Promjene su dokumentirane obrnutim kronološkim redoslijedom (najnovije promjene na vrhu).

## 15. rujna 2025.

### Proširenje naprednih tema - Prilagođeni transporti i inženjering konteksta

#### MCP Prilagođeni transporti (05-AdvancedTopics/mcp-transport/) - Novi vodič za naprednu implementaciju
- **README.md**: Potpuni vodič za implementaciju prilagođenih MCP transportnih mehanizama
  - **Azure Event Grid Transport**: Sveobuhvatna implementacija transporta temeljenog na serverless događajima
    - Primjeri u C#, TypeScriptu i Pythonu s integracijom Azure Functions
    - Obrasci arhitekture temeljene na događajima za skalabilna MCP rješenja
    - Primanje webhooks i rukovanje porukama temeljenim na push metodama
  - **Azure Event Hubs Transport**: Implementacija transporta za visokopropusno strujanje
    - Sposobnosti za strujanje u stvarnom vremenu za scenarije niske latencije
    - Strategije particioniranja i upravljanje kontrolnim točkama
    - Grupiranje poruka i optimizacija performansi
  - **Obrasci integracije u poduzeću**: Primjeri arhitekture spremni za produkciju
    - Distribuirana MCP obrada preko više Azure Functions
    - Hibridne transportne arhitekture koje kombiniraju više vrsta transporta
    - Strategije trajnosti poruka, pouzdanosti i rukovanja greškama
  - **Sigurnost i praćenje**: Integracija Azure Key Vaulta i obrasci za promatranje
    - Autentifikacija upravljanim identitetima i pristup s najmanjim privilegijama
    - Telemetrija Application Insights i praćenje performansi
    - Obrasci za prekidače i toleranciju na greške
  - **Okviri za testiranje**: Sveobuhvatne strategije testiranja za prilagođene transporte
    - Jedinično testiranje s testnim duplikatima i okvirima za simulaciju
    - Integracijsko testiranje s Azure Test Containers
    - Razmatranja za testiranje performansi i opterećenja

#### Inženjering konteksta (05-AdvancedTopics/mcp-contextengineering/) - Nova AI disciplina
- **README.md**: Sveobuhvatno istraživanje inženjeringa konteksta kao novog područja
  - **Osnovni principi**: Potpuno dijeljenje konteksta, svijest o donošenju odluka i upravljanje prozorima konteksta
  - **Usklađenost s MCP protokolom**: Kako MCP dizajn rješava izazove inženjeringa konteksta
    - Ograničenja prozora konteksta i strategije progresivnog učitavanja
    - Određivanje relevantnosti i dinamičko dohvaćanje konteksta
    - Višemodalno rukovanje kontekstom i sigurnosni aspekti
  - **Pristupi implementaciji**: Jednonitne naspram višeagentske arhitekture
    - Tehnike segmentiranja i prioritizacije konteksta
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
- **Standardizacija naziva**: Preimenovan "mcp transport" u "mcp-transport" radi dosljednosti s ostalim mapama naprednih tema
- **Organizacija sadržaja**: Sve mape 05-AdvancedTopics sada slijede dosljedan obrazac imenovanja (mcp-[tema])

### Poboljšanja kvalitete dokumentacije
- **Usklađenost sa specifikacijom MCP-a**: Svi novi sadržaji referiraju trenutnu MCP specifikaciju 2025-06-18
- **Primjeri na više jezika**: Sveobuhvatni primjeri koda u C#, TypeScriptu i Pythonu
- **Fokus na poduzeće**: Obrasci spremni za produkciju i integracija s Azure cloudom
- **Vizualna dokumentacija**: Dijagrami izrađeni u Mermaidu za vizualizaciju arhitekture i tijeka

## 18. kolovoza 2025.

### Sveobuhvatno ažuriranje dokumentacije - MCP standardi 2025-06-18

#### MCP Sigurnosne najbolje prakse (02-Security/) - Potpuna modernizacija
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Potpuno prepisano u skladu s MCP specifikacijom 2025-06-18
  - **Obavezni zahtjevi**: Dodani eksplicitni MUST/MUST NOT zahtjevi iz službene specifikacije s jasnim vizualnim indikatorima
  - **12 osnovnih sigurnosnih praksi**: Restrukturirano s popisa od 15 stavki u sveobuhvatne sigurnosne domene
    - Sigurnost tokena i autentifikacija s integracijom vanjskih pružatelja identiteta
    - Upravljanje sesijama i sigurnost transporta s kriptografskim zahtjevima
    - Zaštita od AI-specifičnih prijetnji s integracijom Microsoft Prompt Shields
    - Kontrola pristupa i dozvola s principom najmanjih privilegija
    - Sigurnost sadržaja i praćenje s integracijom Azure Content Safety
    - Sigurnost opskrbnog lanca s provjerom komponenti
    - OAuth sigurnost i prevencija napada "zbunjenog zamjenika" s PKCE implementacijom
    - Odgovor na incidente i oporavak s automatiziranim sposobnostima
    - Usklađenost i upravljanje s regulatornim zahtjevima
    - Napredne sigurnosne kontrole s arhitekturom nultog povjerenja
    - Integracija Microsoft sigurnosnog ekosustava s sveobuhvatnim rješenjima
    - Kontinuirana evolucija sigurnosti s adaptivnim praksama
  - **Microsoft sigurnosna rješenja**: Poboljšane smjernice za integraciju Prompt Shields, Azure Content Safety, Entra ID i GitHub Advanced Security
  - **Resursi za implementaciju**: Kategorizirani sveobuhvatni linkovi na službenu MCP dokumentaciju, Microsoft sigurnosna rješenja, sigurnosne standarde i vodiče za implementaciju

#### Napredne sigurnosne kontrole (02-Security/) - Implementacija za poduzeća
- **MCP-SECURITY-CONTROLS-2025.md**: Potpuno preuređeno s okvirom sigurnosti za poduzeća
  - **9 sveobuhvatnih sigurnosnih domena**: Prošireno od osnovnih kontrola do detaljnog okvira za poduzeća
    - Napredna autentifikacija i autorizacija s integracijom Microsoft Entra ID
    - Sigurnost tokena i kontrole protiv prosljeđivanja s sveobuhvatnom validacijom
    - Sigurnosne kontrole sesije s prevencijom otmica
    - AI-specifične sigurnosne kontrole s prevencijom ubrizgavanja prompta i trovanja alata
    - Prevencija napada "zbunjenog zamjenika" s OAuth proxy sigurnošću
    - Sigurnost izvršenja alata s izolacijom i sandboxingom
    - Kontrole sigurnosti opskrbnog lanca s provjerom ovisnosti
    - Kontrole praćenja i detekcije s integracijom SIEM-a
    - Odgovor na incidente i oporavak s automatiziranim sposobnostima
  - **Primjeri implementacije**: Dodani detaljni YAML konfiguracijski blokovi i primjeri koda
  - **Integracija Microsoft rješenja**: Sveobuhvatno pokrivanje Azure sigurnosnih usluga, GitHub Advanced Security i upravljanja identitetima za poduzeća

#### Sigurnost naprednih tema (05-AdvancedTopics/mcp-security/) - Implementacija spremna za produkciju
- **README.md**: Potpuno prepisano za implementaciju sigurnosti u poduzećima
  - **Usklađenost s trenutnom specifikacijom**: Ažurirano prema MCP specifikaciji 2025-06-18 s obaveznim sigurnosnim zahtjevima
  - **Poboljšana autentifikacija**: Integracija Microsoft Entra ID s sveobuhvatnim primjerima u .NET-u i Java Spring Security
  - **Integracija AI sigurnosti**: Implementacija Microsoft Prompt Shields i Azure Content Safety s detaljnim primjerima u Pythonu
  - **Napredna mitigacija prijetnji**: Sveobuhvatni primjeri implementacije za
    - Prevenciju napada "zbunjenog zamjenika" s PKCE i validacijom korisničkog pristanka
    - Prevenciju prosljeđivanja tokena s validacijom publike i sigurnim upravljanjem tokenima
    - Prevenciju otmica sesije s kriptografskim vezanjem i analizom ponašanja
  - **Integracija sigurnosti za poduzeća**: Praćenje Application Insights, detekcijski kanali prijetnji i sigurnost opskrbnog lanca
  - **Kontrolni popis implementacije**: Jasne obavezne naspram preporučenih sigurnosnih kontrola s prednostima Microsoft sigurnosnog ekosustava

### Poboljšanja kvalitete dokumentacije i usklađenost sa standardima
- **Reference specifikacija**: Ažurirane sve reference na trenutnu MCP specifikaciju 2025-06-18
- **Microsoft sigurnosni ekosustav**: Poboljšane smjernice za integraciju kroz cijelu sigurnosnu dokumentaciju
- **Praktična implementacija**: Dodani detaljni primjeri koda u .NET-u, Javi i Pythonu s obrascima za poduzeća
- **Organizacija resursa**: Sveobuhvatna kategorizacija službene dokumentacije, sigurnosnih standarda i vodiča za implementaciju
- **Vizualni indikatori**: Jasno označavanje obaveznih zahtjeva naspram preporučenih praksi

## 16. srpnja 2025.

### Poboljšanja README-a i navigacije
- Potpuno redizajnirana navigacija kurikuluma u README.md
- Zamijenjeni `<details>` tagovi pristupačnijim formatom temeljenim na tablicama
- Kreirane alternativne opcije izgleda u novoj mapi "alternative_layouts"
- Dodani primjeri navigacije u stilu kartica, tabova i akordeona
- Ažuriran odjeljak strukture repozitorija kako bi uključio sve najnovije datoteke
- Poboljšan odjeljak "Kako koristiti ovaj kurikulum" s jasnim preporukama
- Ažurirani linkovi na MCP specifikaciju kako bi pokazivali na ispravne URL-ove
- Dodan odjeljak inženjeringa konteksta (5.14) u strukturu kurikuluma

### Ažuriranja vodiča za učenje
- Potpuno revidiran vodič za učenje kako bi se uskladio s trenutnom strukturom repozitorija
- Dodani novi odjeljci za MCP klijente i alate te popularne MCP servere
- Ažurirana vizualna karta kurikuluma kako bi točno odražavala sve teme
- Poboljšani opisi naprednih tema kako bi pokrili sva specijalizirana područja
- Ažuriran odjeljak studija slučaja kako bi odražavao stvarne primjere
- Dodan ovaj sveobuhvatni dnevnik promjena

### Doprinosi zajednice (06-CommunityContributions/)
- Dodane detaljne informacije o MCP serverima za generiranje slika
- Dodan sveobuhvatan odjeljak o korištenju Claudea u VSCodeu
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
- Kreirana osnovna struktura za svih 10 glavnih odjeljaka
- Implementirana vizualna karta kurikuluma za navigaciju
- Dodani početni uzorci projekata u više programskih jezika

### Početak rada (03-GettingStarted/)
- Kreirani prvi primjeri implementacije servera
- Dodane smjernice za razvoj klijenata
- Uključene upute za integraciju LLM klijenata
- Dodana dokumentacija za integraciju s VS Codeom
- Implementirani primjeri servera s događajima poslanim od strane servera (SSE)

### Osnovni koncepti (01-CoreConcepts/)
- Dodano detaljno objašnjenje arhitekture klijent-server
- Kreirana dokumentacija o ključnim komponentama protokola
- Dokumentirani obrasci poruka u MCP-u

## 23. svibnja 2025.

### Struktura repozitorija
- Inicijaliziran repozitorij s osnovnom strukturom mapa
- Kreirani README datoteke za svaki glavni odjeljak
- Postavljena infrastruktura za prijevode
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
- Osmišljena struktura od 10 odjeljaka kurikuluma
- Razvijen konceptualni okvir za primjere i studije slučaja
- Kreirani početni prototipovi primjera za ključne koncepte

---

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden pomoću AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo osigurati točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za ključne informacije preporučuje se profesionalni prijevod od strane čovjeka. Ne preuzimamo odgovornost za nesporazume ili pogrešna tumačenja koja mogu proizaći iz korištenja ovog prijevoda.