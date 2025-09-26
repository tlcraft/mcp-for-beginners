<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "704c94da1dde019de2d8eb1d671f418f",
  "translation_date": "2025-09-26T19:16:10+00:00",
  "source_file": "changelog.md",
  "language_code": "sl"
}
-->
# Dnevnik sprememb: Učni načrt MCP za začetnike

Ta dokument služi kot zapis vseh pomembnih sprememb, ki so bile narejene v učnem načrtu Model Context Protocol (MCP) za začetnike. Spremembe so dokumentirane v obratnem kronološkem vrstnem redu (najprej najnovejše spremembe).

## 26. september 2025

### Izboljšave študij primerov - Integracija GitHub MCP Registry

#### Študije primerov (09-CaseStudy/) - Poudarek na razvoju ekosistema
- **README.md**: Obsežna razširitev z izčrpno študijo primera GitHub MCP Registry
  - **Študija primera GitHub MCP Registry**: Nova izčrpna študija primera, ki preučuje lansiranje GitHub MCP Registry septembra 2025
    - **Analiza problema**: Podrobna preučitev izzivov pri odkrivanju in uvajanju razdrobljenih MCP strežnikov
    - **Arhitektura rešitve**: Centraliziran pristop GitHub Registry z enostavno namestitvijo v VS Code
    - **Poslovni vpliv**: Merljive izboljšave pri uvajanju razvijalcev in produktivnosti
    - **Strateška vrednost**: Poudarek na modularni uvedbi agentov in interoperabilnosti med orodji
    - **Razvoj ekosistema**: Pozicioniranje kot temeljna platforma za integracijo agentov
  - **Izboljšana struktura študij primerov**: Posodobljene vse študije primerov z doslednim formatiranjem in obsežnimi opisi
    - Azure AI Travel Agents: Poudarek na orkestraciji več agentov
    - Integracija Azure DevOps: Osredotočenost na avtomatizacijo delovnih tokov
    - Pridobivanje dokumentacije v realnem času: Implementacija Python konzolnega odjemalca
    - Interaktivni generator študijskega načrta: Chainlit pogovorna spletna aplikacija
    - Dokumentacija v urejevalniku: Integracija VS Code in GitHub Copilot
    - Upravljanje Azure API: Vzorci integracije API za podjetja
    - GitHub MCP Registry: Razvoj ekosistema in platforma za skupnost
  - **Obsežen zaključek**: Na novo napisan zaključni del, ki poudarja sedem študij primerov, ki pokrivajo različne dimenzije implementacije MCP
    - Kategorizacija: Integracija v podjetjih, orkestracija več agentov, produktivnost razvijalcev
    - Razvoj ekosistema, izobraževalne aplikacije
    - Izboljšani vpogledi v arhitekturne vzorce, strategije implementacije in najboljše prakse
    - Poudarek na MCP kot zrelem, proizvodno pripravljenem protokolu

#### Posodobitve študijskega vodnika (study_guide.md)
- **Vizualni zemljevid učnega načrta**: Posodobljen miselni zemljevid, ki vključuje GitHub MCP Registry v razdelek študij primerov
- **Opis študij primerov**: Izboljšan iz generičnih opisov v podrobne razčlenitve sedmih obsežnih študij primerov
- **Struktura repozitorija**: Posodobljen razdelek 10, ki odraža obsežno pokritost študij primerov s specifičnimi podrobnostmi implementacije
- **Integracija dnevnika sprememb**: Dodan vnos za 26. september 2025, ki dokumentira dodatek GitHub MCP Registry in izboljšave študij primerov
- **Posodobitve datuma**: Posodobljen časovni žig v nogi dokumenta, ki odraža najnovejšo revizijo (26. september 2025)

### Izboljšave kakovosti dokumentacije
- **Izboljšanje doslednosti**: Standardizirano formatiranje in struktura študij primerov v vseh sedmih primerih
- **Obsežna pokritost**: Študije primerov zdaj pokrivajo scenarije za podjetja, produktivnost razvijalcev in razvoj ekosistema
- **Strateško pozicioniranje**: Poudarjen MCP kot temeljna platforma za uvedbo agentnih sistemov
- **Integracija virov**: Posodobljeni dodatni viri, ki vključujejo povezavo do GitHub MCP Registry

## 15. september 2025

### Razširitev naprednih tem - Prilagojeni transporti in inženiring konteksta

#### Prilagojeni transporti MCP (05-AdvancedTopics/mcp-transport/) - Nov napreden vodnik za implementacijo
- **README.md**: Celovit vodnik za implementacijo prilagojenih transportnih mehanizmov MCP
  - **Transport Azure Event Grid**: Obsežna implementacija transporta, ki temelji na dogodkih brez strežnika
    - Primeri v C#, TypeScript in Python z integracijo Azure Functions
    - Vzorci arhitekture, ki temelji na dogodkih, za skalabilne rešitve MCP
    - Sprejemniki webhookov in obdelava sporočil na podlagi potiskanja
  - **Transport Azure Event Hubs**: Implementacija transporta za pretakanje z visoko prepustnostjo
    - Zmožnosti pretakanja v realnem času za scenarije z nizko zakasnitvijo
    - Strategije particioniranja in upravljanje kontrolnih točk
    - Združevanje sporočil in optimizacija zmogljivosti
  - **Vzorce integracije v podjetjih**: Primeri arhitekture, pripravljeni za proizvodnjo
    - Distribuirana obdelava MCP prek več funkcij Azure
    - Hibridne transportne arhitekture, ki združujejo več vrst transportov
    - Strategije trajnosti sporočil, zanesljivosti in obravnave napak
  - **Varnost in spremljanje**: Integracija Azure Key Vault in vzorci opazovanja
    - Avtentikacija z upravljano identiteto in dostop z najmanjšimi privilegiji
    - Telemetrija Application Insights in spremljanje zmogljivosti
    - Prekinitveni mehanizmi in vzorci odpornosti na napake
  - **Okviri za testiranje**: Celovite strategije testiranja za prilagojene transporte
    - Enotno testiranje z dvojniki testov in okviri za simulacijo
    - Testiranje integracije z Azure Test Containers
    - Premisleki o testiranju zmogljivosti in obremenitve

#### Inženiring konteksta (05-AdvancedTopics/mcp-contextengineering/) - Nastajajoča disciplina AI
- **README.md**: Celovita raziskava inženiringa konteksta kot nastajajočega področja
  - **Osnovna načela**: Popolno deljenje konteksta, zavedanje odločanja o akcijah in upravljanje okna konteksta
  - **Uskladitev s protokolom MCP**: Kako zasnova MCP obravnava izzive inženiringa konteksta
    - Omejitve okna konteksta in strategije progresivnega nalaganja
    - Določanje ustreznosti in dinamično pridobivanje konteksta
    - Večmodalno upravljanje konteksta in varnostni premisleki
  - **Pristopi k implementaciji**: Arhitekture z enim nitjo proti več agentom
    - Tehnike razdeljevanja in prioritizacije konteksta
    - Progresivno nalaganje konteksta in strategije stiskanja
    - Slojeviti pristopi konteksta in optimizacija pridobivanja
  - **Okvir za merjenje**: Nastajajoče metrike za ocenjevanje učinkovitosti konteksta
    - Premisleki o učinkovitosti vnosa, zmogljivosti, kakovosti in uporabniški izkušnji
    - Eksperimentalni pristopi k optimizaciji konteksta
    - Analiza napak in metodologije izboljšav

#### Posodobitve navigacije učnega načrta (README.md)
- **Izboljšana struktura modulov**: Posodobljena tabela učnega načrta, ki vključuje nove napredne teme
  - Dodani vnosi za inženiring konteksta (5.14) in prilagojene transporte (5.15)
  - Dosledno formatiranje in navigacijske povezave v vseh modulih
  - Posodobljeni opisi, ki odražajo trenutni obseg vsebine

### Izboljšave strukture imenikov
- **Standardizacija poimenovanja**: Preimenovano "mcp transport" v "mcp-transport" za doslednost z drugimi mapami naprednih tem
- **Organizacija vsebine**: Vse mape 05-AdvancedTopics zdaj sledijo doslednemu vzorcu poimenovanja (mcp-[tema])

### Izboljšave kakovosti dokumentacije
- **Uskladitev s specifikacijo MCP**: Vsa nova vsebina se sklicuje na trenutno specifikacijo MCP 2025-06-18
- **Večjezični primeri**: Obsežni primeri kode v C#, TypeScript in Python
- **Osredotočenost na podjetja**: Vzorci, pripravljeni za proizvodnjo, in integracija v oblak Azure
- **Vizualna dokumentacija**: Diagrami Mermaid za vizualizacijo arhitekture in tokov

## 18. avgust 2025

### Celovita posodobitev dokumentacije - Standardi MCP 2025-06-18

#### Najboljše prakse varnosti MCP (02-Security/) - Popolna modernizacija
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Popolna prenova, usklajena s specifikacijo MCP 2025-06-18
  - **Obvezne zahteve**: Dodane eksplicitne zahteve MUST/MUST NOT iz uradne specifikacije z jasnimi vizualnimi indikatorji
  - **12 osnovnih varnostnih praks**: Prestrukturirano iz 15-točkovnega seznama v obsežne varnostne domene
    - Varnost žetonov in avtentikacija z integracijo zunanjega ponudnika identitete
    - Upravljanje sej in varnost transporta s kriptografskimi zahtevami
    - Zaščita pred specifičnimi grožnjami AI z integracijo Microsoft Prompt Shields
    - Nadzor dostopa in dovoljenja z načelom najmanjšega privilegija
    - Varnost vsebine in spremljanje z integracijo Azure Content Safety
    - Varnost dobavne verige s celovitim preverjanjem komponent
    - Varnost OAuth in preprečevanje zmedenih napadov z implementacijo PKCE
    - Odziv na incidente in okrevanje z avtomatiziranimi zmogljivostmi
    - Skladnost in upravljanje z regulativno uskladitvijo
    - Napredni varnostni nadzori z arhitekturo ničelnega zaupanja
    - Integracija Microsoftovega varnostnega ekosistema s celovitimi rešitvami
    - Nenehen razvoj varnosti z adaptivnimi praksami
  - **Microsoftove varnostne rešitve**: Izboljšana navodila za integracijo Prompt Shields, Azure Content Safety, Entra ID in GitHub Advanced Security
  - **Viri za implementacijo**: Kategorizirane obsežne povezave do virov po uradni dokumentaciji MCP, Microsoftovih varnostnih rešitvah, varnostnih standardih in vodnikih za implementacijo

#### Napredni varnostni nadzori (02-Security/) - Implementacija za podjetja
- **MCP-SECURITY-CONTROLS-2025.md**: Popolna prenova z varnostnim okvirom za podjetja
  - **9 obsežnih varnostnih domen**: Razširjeno iz osnovnih nadzorov v podroben okvir za podjetja
    - Napredna avtentikacija in avtorizacija z integracijo Microsoft Entra ID
    - Varnost žetonov in nadzor proti prenosu z obsežnim preverjanjem
    - Nadzori varnosti sej s preprečevanjem ugrabitve
    - Specifični varnostni nadzori AI z zaščito pred vbrizgavanjem ukazov in zastrupljanjem orodij
    - Preprečevanje zmedenih napadov z varnostjo proxy OAuth
    - Varnost izvajanja orodij z izolacijo in peskovnikom
    - Nadzori varnosti dobavne verige s preverjanjem odvisnosti
    - Nadzori spremljanja in zaznavanja z integracijo SIEM
    - Odziv na incidente in okrevanje z avtomatiziranimi zmogljivostmi
  - **Primeri implementacije**: Dodani podrobni bloki konfiguracije YAML in primeri kode
  - **Integracija Microsoftovih rešitev**: Celovita pokritost varnostnih storitev Azure, GitHub Advanced Security in upravljanje identitete v podjetjih

#### Napredne teme varnosti (05-AdvancedTopics/mcp-security/) - Implementacija, pripravljena za proizvodnjo
- **README.md**: Popolna prenova za implementacijo varnosti v podjetjih
  - **Uskladitev s trenutno specifikacijo**: Posodobljeno na specifikacijo MCP 2025-06-18 z obveznimi varnostnimi zahtevami
  - **Izboljšana avtentikacija**: Integracija Microsoft Entra ID z obsežnimi primeri v .NET in Java Spring Security
  - **Integracija varnosti AI**: Implementacija Microsoft Prompt Shields in Azure Content Safety z podrobnimi primeri v Pythonu
  - **Napredno zmanjševanje groženj**: Celoviti primeri implementacije za
    - Preprečevanje zmedenih napadov z PKCE in validacijo uporabniškega soglasja
    - Preprečevanje prenosa žetonov z validacijo občinstva in varnim upravljanjem žetonov
    - Preprečevanje ugrabitve sej s kriptografsko vezavo in analizo vedenja
  - **Integracija varnosti v podjetjih**: Spremljanje Application Insights, pipelines za zaznavanje groženj in varnost dobavne verige
  - **Kontrolni seznam implementacije**: Jasni obvezni in priporočeni varnostni nadzori z ugodnostmi Microsoftovega varnostnega ekosistema

### Izboljšave kakovosti dokumentacije in uskladitev s standardi
- **Reference specifikacije**: Posodobljene vse reference na trenutno specifikacijo MCP 2025-06-18
- **Microsoftov varnostni ekosistem**: Izboljšana navodila za integracijo v celotni varnostni dokumentaciji
- **Praktična implementacija**: Dodani podrobni primeri kode v .NET, Java in Python z vzorci za podjetja
- **Organizacija virov**: Celovita kategorizacija uradne dokumentacije, varnostnih standardov in vodnikov za implementacijo
- **Vizualni indikatorji**: Jasno označevanje obveznih zahtev v primerjavi s priporočenimi praksami

#### Osnovni koncepti (01-CoreConcepts/) - Popolna modernizacija
- **Posodobitev različice protokola**: Posodobljeno na trenutno specifikacijo MCP 2025-06-18 z datumsko različico (format YYYY-MM-DD)
- **Izboljšanje arhitekture**: Izboljšani opisi gostiteljev, odjemalcev in strežnikov, ki odražajo trenutne vzorce arhitekture MCP
  - Gostitelji zdaj jasno opredeljeni kot AI aplikacije, ki koordinirajo več povezav MCP odjemalcev
  - Odjemalci opisani kot konektorji protokola, ki vzdržujejo razmerja ena-na-ena s strežniki
  - Strežniki izboljšani z lokalnimi in oddaljenimi scenariji uvajanja
- **Prestrukturiranje primitivov**: Popolna prenova strežniških in odjemalskih primitivov
  - Strežniški primitivi: Viri (viri podatkov), Predloge (predloge), Orodja (izvedljive funkcije) s podrobnimi razlagami in primeri
  - Odjemalski primitivi: Vzorčenje (LLM zaključki), Elicitacija (uporabniški vnos), Beleženje (razhroščevanje/spremljanje)
  - Posodobljeno z trenutnimi metodami odkrivanja (`*/list`), pridobivanja (`*/get`) in izvajanja (`*/call`)
- **Arhitektura protokola**: Predstavljen dvoplastni arhitekturni model
  - Podatkovna plast: Temelj JSON-RPC 2.0 z upravljanjem življenjskega cikla in primitivov
  - Transportna plast: STDIO (lokalno) in Streamable HTTP s SSE (oddaljeno) transportnimi mehanizmi
- **Varnostni okvir**: Celovita varnostna načela, vključno z eksplicitnim soglasjem uporabnika, zaščito zasebnosti podatkov, varnostjo izvajanja orodij in varnostjo transportne plasti
- **Vzorce komunikacije**: Posodobljena sporočila protokola, ki prikazujejo tokove inicializacije, odkrivanja, izvajanja in obveščanja
- **Primeri kode**: Osveženi večjezični primeri (.NET, Java, Python, JavaScript), ki odražajo
- Zamenjani `<details>` oznake z bolj dostopnim formatom na osnovi tabel
- Ustvarjene alternativne možnosti postavitve v novi mapi "alternative_layouts"
- Dodani primeri navigacije na osnovi kartic, zavihkov in harmonike
- Posodobljen razdelek o strukturi repozitorija, da vključuje vse najnovejše datoteke
- Izboljšan razdelek "Kako uporabljati ta učni načrt" z jasnimi priporočili
- Posodobljene povezave do MCP specifikacij, da kažejo na pravilne URL-je
- Dodan razdelek o kontekstnem inženiringu (5.14) v strukturo učnega načrta

### Posodobitve učnega vodiča
- Popolnoma prenovljen učni vodič, da se ujema z aktualno strukturo repozitorija
- Dodani novi razdelki za MCP odjemalce in orodja ter priljubljene MCP strežnike
- Posodobljen vizualni zemljevid učnega načrta, da natančno odraža vse teme
- Izboljšani opisi naprednih tem, da zajemajo vsa specializirana področja
- Posodobljen razdelek o študijskih primerih, da odraža dejanske primere
- Dodan ta obsežen seznam sprememb

### Prispevki skupnosti (06-CommunityContributions/)
- Dodane podrobne informacije o MCP strežnikih za generiranje slik
- Dodan obsežen razdelek o uporabi Claude v VSCode
- Dodana navodila za nastavitev in uporabo terminalskega odjemalca Cline
- Posodobljen razdelek o MCP odjemalcih, da vključuje vse priljubljene možnosti
- Izboljšani primeri prispevkov z natančnejšimi vzorci kode

### Napredne teme (05-AdvancedTopics/)
- Organizirane vse mape specializiranih tem z doslednim poimenovanjem
- Dodani materiali in primeri za kontekstni inženiring
- Dodana dokumentacija za integracijo Foundry agentov
- Izboljšana dokumentacija za varnostno integracijo Entra ID

## 11. junij 2025

### Prva izdaja
- Izdana prva različica učnega načrta MCP za začetnike
- Ustvarjena osnovna struktura za vseh 10 glavnih razdelkov
- Implementiran vizualni zemljevid učnega načrta za navigacijo
- Dodani začetni vzorčni projekti v več programskih jezikih

### Začetek (03-GettingStarted/)
- Ustvarjeni prvi primeri implementacije strežnika
- Dodana navodila za razvoj odjemalca
- Vključena navodila za integracijo LLM odjemalca
- Dodana dokumentacija za integracijo z VS Code
- Implementirani primeri strežnika za dogodke, poslane s strežnika (SSE)

### Osnovni koncepti (01-CoreConcepts/)
- Dodana podrobna razlaga arhitekture odjemalec-strežnik
- Ustvarjena dokumentacija o ključnih komponentah protokola
- Dokumentirani vzorci sporočanja v MCP

## 23. maj 2025

### Struktura repozitorija
- Inicializiran repozitorij z osnovno strukturo map
- Ustvarjene README datoteke za vsak glavni razdelek
- Nastavljena infrastruktura za prevajanje
- Dodane slikovne datoteke in diagrami

### Dokumentacija
- Ustvarjen začetni README.md s pregledom učnega načrta
- Dodani CODE_OF_CONDUCT.md in SECURITY.md
- Nastavljen SUPPORT.md z navodili za pomoč
- Ustvarjena preliminarna struktura učnega vodiča

## 15. april 2025

### Načrtovanje in okvir
- Začetno načrtovanje učnega načrta MCP za začetnike
- Določeni učni cilji in ciljno občinstvo
- Začrtana 10-delna struktura učnega načrta
- Razvit konceptualni okvir za primere in študijske primere
- Ustvarjeni začetni prototipni primeri za ključne koncepte

---

