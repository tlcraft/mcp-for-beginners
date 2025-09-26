<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "704c94da1dde019de2d8eb1d671f418f",
  "translation_date": "2025-09-26T19:13:12+00:00",
  "source_file": "changelog.md",
  "language_code": "hr"
}
-->
# Promjene: MCP za početnike - Kurikulum

Ovaj dokument služi kao zapis svih značajnih promjena napravljenih u kurikulumu Model Context Protocol (MCP) za početnike. Promjene su dokumentirane obrnutim kronološkim redoslijedom (najnovije promjene na vrhu).

## 26. rujna 2025.

### Poboljšanje studija slučaja - Integracija GitHub MCP Registry

#### Studije slučaja (09-CaseStudy/) - Fokus na razvoj ekosustava
- **README.md**: Veliko proširenje s detaljnom studijom slučaja o GitHub MCP Registry
  - **Studija slučaja GitHub MCP Registry**: Nova sveobuhvatna studija slučaja o lansiranju GitHub MCP Registry u rujnu 2025.
    - **Analiza problema**: Detaljno ispitivanje izazova fragmentirane MCP server discovery i implementacije
    - **Arhitektura rješenja**: Centralizirani pristup registru GitHub-a s instalacijom u jednom kliku putem VS Code-a
    - **Poslovni utjecaj**: Mjerljiva poboljšanja u onboarding-u i produktivnosti programera
    - **Strateška vrijednost**: Fokus na modularnu implementaciju agenata i interoperabilnost alata
    - **Razvoj ekosustava**: Pozicioniranje kao temeljna platforma za integraciju agenata
  - **Poboljšana struktura studija slučaja**: Ažurirane sve studije slučaja s dosljednim formatiranjem i detaljnim opisima
    - Azure AI Travel Agents: Naglasak na orkestraciji više agenata
    - Integracija Azure DevOps: Fokus na automatizaciju radnih procesa
    - Dohvaćanje dokumentacije u stvarnom vremenu: Implementacija Python konzolnog klijenta
    - Interaktivni generator plana učenja: Chainlit web aplikacija za razgovore
    - Dokumentacija u uređivaču: Integracija VS Code-a i GitHub Copilot-a
    - Upravljanje Azure API-jem: Obrasci integracije API-ja za poduzeća
    - GitHub MCP Registry: Razvoj ekosustava i platforma za zajednicu
  - **Sveobuhvatan zaključak**: Prepisan zaključni dio koji ističe sedam studija slučaja koje pokrivaju različite dimenzije implementacije MCP-a
    - Integracija u poduzeću, orkestracija više agenata, produktivnost programera
    - Razvoj ekosustava, kategorizacija obrazovnih aplikacija
    - Poboljšani uvidi u arhitektonske obrasce, strategije implementacije i najbolje prakse
    - Naglasak na MCP kao zreli, spremni za proizvodnju protokol

#### Ažuriranja vodiča za učenje (study_guide.md)
- **Vizualna mapa kurikuluma**: Ažurirana mapa uma za uključivanje GitHub MCP Registry u odjeljak studija slučaja
- **Opis studija slučaja**: Poboljšan od generičkih opisa do detaljnog pregleda sedam sveobuhvatnih studija slučaja
- **Struktura repozitorija**: Ažuriran odjeljak 10 kako bi odražavao sveobuhvatnu pokrivenost studija slučaja sa specifičnim detaljima implementacije
- **Integracija promjena**: Dodan unos za 26. rujna 2025. koji dokumentira dodatak GitHub MCP Registry i poboljšanja studija slučaja
- **Ažuriranja datuma**: Ažuriran vremenski pečat u podnožju kako bi odražavao najnoviju reviziju (26. rujna 2025.)

### Poboljšanja kvalitete dokumentacije
- **Poboljšanje dosljednosti**: Standardizirano formatiranje i struktura studija slučaja u svim primjerima
- **Sveobuhvatna pokrivenost**: Studije slučaja sada pokrivaju scenarije poduzeća, produktivnosti programera i razvoja ekosustava
- **Strateško pozicioniranje**: Poboljšan fokus na MCP kao temeljnu platformu za implementaciju agentnih sustava
- **Integracija resursa**: Ažurirani dodatni resursi za uključivanje poveznice na GitHub MCP Registry

## 15. rujna 2025.

### Proširenje naprednih tema - Prilagođeni transporti i inženjering konteksta

#### MCP Prilagođeni transporti (05-AdvancedTopics/mcp-transport/) - Novi vodič za implementaciju
- **README.md**: Kompletan vodič za implementaciju prilagođenih mehanizama transporta MCP-a
  - **Azure Event Grid Transport**: Sveobuhvatna implementacija serverless transporta temeljenog na događajima
    - Primjeri u C#, TypeScript i Pythonu s integracijom Azure Functions
    - Obrasci arhitekture temeljenih na događajima za skalabilna MCP rješenja
    - Webhook prijemnici i rukovanje porukama temeljenim na push-u
  - **Azure Event Hubs Transport**: Implementacija transporta za streaming visokog kapaciteta
    - Sposobnosti za streaming u stvarnom vremenu za scenarije niske latencije
    - Strategije particioniranja i upravljanje kontrolnim točkama
    - Grupiranje poruka i optimizacija performansi
  - **Obrasci integracije u poduzeću**: Primjeri arhitekture spremni za proizvodnju
    - Distribuirana obrada MCP-a preko više Azure Functions
    - Hibridne arhitekture transporta koje kombiniraju više vrsta transporta
    - Strategije trajnosti poruka, pouzdanosti i rukovanja greškama
  - **Sigurnost i praćenje**: Integracija Azure Key Vault-a i obrasci za praćenje
    - Autentifikacija pomoću upravljanog identiteta i pristup s najmanjim privilegijama
    - Telemetrija Application Insights i praćenje performansi
    - Prekidači i obrasci tolerancije na greške
  - **Okviri za testiranje**: Sveobuhvatne strategije testiranja za prilagođene transporte
    - Jedinično testiranje s testnim duplikatima i okvirima za simulaciju
    - Testiranje integracije s Azure Test Containers
    - Razmatranja za testiranje performansi i opterećenja

#### Inženjering konteksta (05-AdvancedTopics/mcp-contextengineering/) - Nova AI disciplina
- **README.md**: Sveobuhvatno istraživanje inženjeringa konteksta kao rastućeg područja
  - **Osnovni principi**: Potpuno dijeljenje konteksta, svijest o donošenju odluka i upravljanje prozorom konteksta
  - **Usklađenost s MCP protokolom**: Kako MCP dizajn rješava izazove inženjeringa konteksta
    - Ograničenja prozora konteksta i strategije progresivnog učitavanja
    - Određivanje relevantnosti i dinamičko dohvaćanje konteksta
    - Višemodalno rukovanje kontekstom i sigurnosna razmatranja
  - **Pristupi implementaciji**: Jednostruka arhitektura vs. arhitektura više agenata
    - Tehnike segmentiranja i prioritizacije konteksta
    - Progresivno učitavanje konteksta i strategije kompresije
    - Slojeviti pristupi kontekstu i optimizacija dohvaćanja
  - **Okvir za mjerenje**: Novi metrički sustavi za procjenu učinkovitosti konteksta
    - Učinkovitost unosa, performanse, kvaliteta i razmatranja korisničkog iskustva
    - Eksperimentalni pristupi optimizaciji konteksta
    - Analiza neuspjeha i metodologije poboljšanja

#### Ažuriranja navigacije kurikuluma (README.md)
- **Poboljšana struktura modula**: Ažurirana tablica kurikuluma za uključivanje novih naprednih tema
  - Dodani inženjering konteksta (5.14) i prilagođeni transport (5.15)
  - Dosljedno formatiranje i navigacijske poveznice u svim modulima
  - Ažurirani opisi kako bi odražavali trenutni opseg sadržaja

### Poboljšanja strukture direktorija
- **Standardizacija naziva**: Preimenovan "mcp transport" u "mcp-transport" radi dosljednosti s ostalim mapama naprednih tema
- **Organizacija sadržaja**: Sve mape 05-AdvancedTopics sada slijede dosljedan obrazac imenovanja (mcp-[tema])

### Poboljšanja kvalitete dokumentacije
- **Usklađenost sa specifikacijom MCP-a**: Svi novi sadržaji referiraju trenutnu MCP specifikaciju 2025-06-18
- **Primjeri na više jezika**: Sveobuhvatni primjeri koda u C#, TypeScript i Pythonu
- **Fokus na poduzeće**: Obrasci spremni za proizvodnju i integracija s Azure cloudom
- **Vizualna dokumentacija**: Dijagrami izrađeni u Mermaid za vizualizaciju arhitekture i tijeka

## 18. kolovoza 2025.

### Sveobuhvatno ažuriranje dokumentacije - MCP standardi 2025-06-18

#### MCP Sigurnosne najbolje prakse (02-Security/) - Potpuna modernizacija
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Potpuno prepisan dokument usklađen s MCP specifikacijom 2025-06-18
  - **Obvezni zahtjevi**: Dodani eksplicitni MUST/MUST NOT zahtjevi iz službene specifikacije s jasnim vizualnim indikatorima
  - **12 osnovnih sigurnosnih praksi**: Restrukturirano s popisa od 15 stavki na sveobuhvatne sigurnosne domene
    - Sigurnost tokena i autentifikacija s integracijom vanjskih pružatelja identiteta
    - Upravljanje sesijama i sigurnost transporta s kriptografskim zahtjevima
    - Zaštita od AI-specifičnih prijetnji s integracijom Microsoft Prompt Shields
    - Kontrola pristupa i dozvola s načelom najmanjih privilegija
    - Sigurnost sadržaja i praćenje s integracijom Azure Content Safety
    - Sigurnost opskrbnog lanca s provjerom komponenti
    - Sigurnost OAuth-a i prevencija napada "Confused Deputy" s implementacijom PKCE
    - Odgovor na incidente i oporavak s automatiziranim mogućnostima
    - Usklađenost i upravljanje s regulatornim zahtjevima
    - Napredne sigurnosne kontrole s arhitekturom nultog povjerenja
    - Integracija Microsoft sigurnosnog ekosustava s sveobuhvatnim rješenjima
    - Kontinuirana evolucija sigurnosti s adaptivnim praksama
  - **Microsoft sigurnosna rješenja**: Poboljšane smjernice za integraciju Prompt Shields, Azure Content Safety, Entra ID i GitHub Advanced Security
  - **Resursi za implementaciju**: Kategorizirane sveobuhvatne poveznice na službenu MCP dokumentaciju, Microsoft sigurnosna rješenja, sigurnosne standarde i vodiče za implementaciju

#### Napredne sigurnosne kontrole (02-Security/) - Implementacija za poduzeća
- **MCP-SECURITY-CONTROLS-2025.md**: Potpuno preuređen dokument s sigurnosnim okvirom za poduzeća
  - **9 sveobuhvatnih sigurnosnih domena**: Prošireno od osnovnih kontrola do detaljnog okvira za poduzeća
    - Napredna autentifikacija i autorizacija s integracijom Microsoft Entra ID
    - Sigurnost tokena i kontrole protiv prosljeđivanja s sveobuhvatnom validacijom
    - Sigurnosne kontrole sesije s prevencijom otmica
    - AI-specifične sigurnosne kontrole s prevencijom ubrizgavanja prompta i trovanja alata
    - Prevencija napada "Confused Deputy" s sigurnošću OAuth proxyja
    - Sigurnost izvršavanja alata s izolacijom i sandboxingom
    - Kontrole sigurnosti opskrbnog lanca s provjerom ovisnosti
    - Kontrole praćenja i detekcije s integracijom SIEM-a
    - Odgovor na incidente i oporavak s automatiziranim mogućnostima
  - **Primjeri implementacije**: Dodani detaljni YAML blokovi konfiguracije i primjeri koda
  - **Integracija Microsoft rješenja**: Sveobuhvatna pokrivenost Azure sigurnosnih usluga, GitHub Advanced Security i upravljanja identitetom za poduzeća

#### Sigurnost naprednih tema (05-AdvancedTopics/mcp-security/) - Implementacija spremna za proizvodnju
- **README.md**: Potpuno prepisan dokument za implementaciju sigurnosti u poduzećima
  - **Usklađenost s trenutnom specifikacijom**: Ažurirano prema MCP specifikaciji 2025-06-18 s obveznim sigurnosnim zahtjevima
  - **Poboljšana autentifikacija**: Integracija Microsoft Entra ID s sveobuhvatnim primjerima u .NET-u i Java Spring Security
  - **Integracija AI sigurnosti**: Implementacija Microsoft Prompt Shields i Azure Content Safety s detaljnim primjerima u Pythonu
  - **Napredna mitigacija prijetnji**: Sveobuhvatni primjeri implementacije za
    - Prevenciju napada "Confused Deputy" s PKCE i validacijom korisničkog pristanka
    - Prevenciju prosljeđivanja tokena s validacijom publike i sigurnim upravljanjem tokenima
    - Prevenciju otmica sesije s kriptografskim vezivanjem i analizom ponašanja
  - **Integracija sigurnosti u poduzeću**: Praćenje putem Azure Application Insights, detekcijski kanali prijetnji i sigurnost opskrbnog lanca
  - **Kontrolni popis za implementaciju**: Jasne obvezne vs. preporučene sigurnosne kontrole s prednostima Microsoft sigurnosnog ekosustava

### Poboljšanja kvalitete dokumentacije i usklađenost sa standardima
- **Reference na specifikaciju**: Ažurirane sve reference na trenutnu MCP specifikaciju 2025-06-18
- **Microsoft sigurnosni ekosustav**: Poboljšane smjernice za integraciju kroz cijelu sigurnosnu dokumentaciju
- **Praktična implementacija**: Dodani detaljni primjeri koda u .NET-u, Javi i Pythonu s obrascima za poduzeća
- **Organizacija resursa**: Sveobuhvatna kategorizacija službene dokumentacije, sigurnosnih standarda i vodiča za implementaciju
- **Vizualni indikatori**: Jasno označavanje obveznih zahtjeva vs. preporučenih praksi

#### Osnovni koncepti (01-CoreConcepts/) - Potpuna modernizacija
- **Ažuriranje verzije protokola**: Ažurirano za referenciranje trenutne MCP specifikacije 2025-06-18 s datumski baziranim verzioniranjem (YYYY-MM-DD format)
- **Rafiniranje arhitekture**: Poboljšani opisi domaćina, klijenata i servera kako bi odražavali trenutne obrasce arhitekture MCP-a
  - Domaćini sada jasno definirani kao AI aplikacije koje koordiniraju više MCP klijentskih veza
  - Klijenti opisani kao konektori protokola koji održavaju odnose jedan-na-jedan sa serverima
  - Serveri poboljšani s lokalnim vs. udaljenim scenarijima implementacije
- **Restrukturiranje primitiva**: Potpuna preinaka server i klijent primitiva
  - Server primitivi: Resursi (izvori podataka), Prompti (predlošci), Alati (izvršne funkcije) s detaljnim objašnjenjima i primjerima
  - Klijent primitivi: Uzorkovanje (LLM završetci), Elicitacija (unos korisnika), Zapisivanje (debugging/praćenje)
  - Ažurirano s trenutnim metodama otkrivanja (`*/list`), dohvaćanja (`*/get`) i izvršenja (`*/call`)
- **Arhitektura protokola**: Uveden model arhitekture s dva sloja
  - Sloj podataka: JSON-RPC 2.0 temelj s upravljanjem životnim ciklusom i primitivima
  - Sloj transporta: STDIO (lokalni) i Streamable HTTP sa SSE (udaljeni) mehanizmi transporta
- **Sigurnosni okvir**: Sveobuhvatni sigurnosni principi uključujući eksplicitni korisnički pristanak, zaštitu privatnosti podataka, sigurnost izvršenja alata i sigurnost sloja transporta
- **Obrasci komunikacije**: Ažurirane poruke protokola za prikaz inicijalizacije, otkrivanja, izvršenja i tijekova obavijesti
- **Primjeri koda**: Osvježeni primjeri na više jezika (.NET, Java, Python, JavaScript) kako bi odražavali trenutne obrasce MCP SDK-a

#### Sigurnost (02-Security/) - Sveobuhvatna sigurnosna preinaka  
-
- Zamijenjene oznake `<details>` pristupačnijim formatom temeljenim na tablicama
- Kreirane alternativne opcije izgleda u novoj mapi "alternative_layouts"
- Dodani primjeri navigacije u stilu kartica, tabova i harmonike
- Ažuriran odjeljak o strukturi repozitorija kako bi uključivao sve najnovije datoteke
- Poboljšan odjeljak "Kako koristiti ovaj kurikulum" s jasnim preporukama
- Ažurirane poveznice na MCP specifikacije kako bi upućivale na ispravne URL-ove
- Dodan odjeljak o kontekstualnom inženjeringu (5.14) u strukturu kurikuluma

### Ažuriranja vodiča za učenje
- Potpuno revidiran vodič za učenje kako bi se uskladio s trenutnom strukturom repozitorija
- Dodani novi odjeljci za MCP klijente i alate te popularne MCP servere
- Ažurirana vizualna karta kurikuluma kako bi točno odražavala sve teme
- Poboljšani opisi naprednih tema kako bi pokrili sva specijalizirana područja
- Ažuriran odjeljak studija slučaja kako bi odražavao stvarne primjere
- Dodan ovaj sveobuhvatan popis promjena

### Doprinosi zajednice (06-CommunityContributions/)
- Dodane detaljne informacije o MCP serverima za generiranje slika
- Dodan sveobuhvatan odjeljak o korištenju Claudea u VSCode-u
- Dodane upute za postavljanje i korištenje terminalskog klijenta Cline
- Ažuriran odjeljak MCP klijenata kako bi uključivao sve popularne opcije klijenata
- Poboljšani primjeri doprinosa s točnijim uzorcima koda

### Napredne teme (05-AdvancedTopics/)
- Organizirane sve mape specijaliziranih tema s dosljednim nazivima
- Dodani materijali i primjeri za kontekstualni inženjering
- Dodana dokumentacija za integraciju Foundry agenta
- Poboljšana dokumentacija za sigurnosnu integraciju Entra ID-a

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
- Dodana dokumentacija za integraciju s VS Code-om
- Implementirani primjeri servera s događajima poslanim od strane servera (SSE)

### Osnovni koncepti (01-CoreConcepts/)
- Dodano detaljno objašnjenje arhitekture klijent-server
- Kreirana dokumentacija o ključnim komponentama protokola
- Dokumentirani obrasci razmjene poruka u MCP-u

## 23. svibnja 2025.

### Struktura repozitorija
- Inicijaliziran repozitorij s osnovnom strukturom mapa
- Kreirani README datoteke za svaki glavni odjeljak
- Postavljena infrastruktura za prijevode
- Dodani slikovni materijali i dijagrami

### Dokumentacija
- Kreiran početni README.md s pregledom kurikuluma
- Dodani CODE_OF_CONDUCT.md i SECURITY.md
- Postavljen SUPPORT.md s uputama za dobivanje pomoći
- Kreirana preliminarna struktura vodiča za učenje

## 15. travnja 2025.

### Planiranje i okvir
- Početno planiranje kurikuluma MCP za početnike
- Definirani ciljevi učenja i ciljana publika
- Nacrtana struktura kurikuluma od 10 odjeljaka
- Razvijen konceptualni okvir za primjere i studije slučaja
- Kreirani početni prototipovi primjera za ključne koncepte

---

