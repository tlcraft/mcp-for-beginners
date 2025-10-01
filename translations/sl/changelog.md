<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f9d56a1327805a9f6df085a41fb81083",
  "translation_date": "2025-09-30T22:43:31+00:00",
  "source_file": "changelog.md",
  "language_code": "sl"
}
-->
# Dnevnik sprememb: Učni načrt MCP za začetnike

Ta dokument služi kot zapis vseh pomembnih sprememb, ki so bile narejene v učnem načrtu Model Context Protocol (MCP) za začetnike. Spremembe so dokumentirane v obratnem kronološkem vrstnem redu (najprej najnovejše spremembe).

## 29. september 2025

### Laboratoriji za integracijo podatkovnih baz MCP strežnika - celovita praktična učna pot

#### 11-MCPServerHandsOnLabs - Nov celovit učni načrt za integracijo podatkovnih baz
- **Celovita učna pot s 13 laboratoriji**: Dodan celovit praktični učni načrt za izdelavo produkcijsko pripravljenih MCP strežnikov z integracijo podatkovne baze PostgreSQL
  - **Implementacija v realnem svetu**: Primer uporabe analitike Zava Retail, ki prikazuje vzorce na ravni podjetja
  - **Strukturiran učni napredek**:
    - **Laboratoriji 00-03: Osnove** - Uvod, osnovna arhitektura, varnost in večnajemniška zasnova, nastavitev okolja
    - **Laboratoriji 04-06: Izdelava MCP strežnika** - Oblikovanje podatkovne baze in sheme, implementacija MCP strežnika, razvoj orodij  
    - **Laboratoriji 07-09: Napredne funkcije** - Integracija semantičnega iskanja, testiranje in odpravljanje napak, integracija z VS Code
    - **Laboratoriji 10-12: Produkcija in najboljše prakse** - Strategije uvajanja, spremljanje in opazovanje, najboljše prakse in optimizacija
  - **Tehnologije na ravni podjetja**: Okvir FastMCP, PostgreSQL s pgvector, Azure OpenAI embeddings, Azure Container Apps, Application Insights
  - **Napredne funkcije**: Varnost na ravni vrstic (RLS), semantično iskanje, dostop do podatkov večnajemnikov, vektorski embeddings, spremljanje v realnem času

#### Standardizacija terminologije - Pretvorba modulov v laboratorije
- **Celovita posodobitev dokumentacije**: Sistematično posodobljeni vsi README datoteke v 11-MCPServerHandsOnLabs za uporabo terminologije "Laboratorij" namesto "Modul"
  - **Naslovi razdelkov**: Posodobljeno "Kaj pokriva ta modul" v "Kaj pokriva ta laboratorij" v vseh 13 laboratorijih
  - **Opis vsebine**: Spremenjeno "Ta modul zagotavlja..." v "Ta laboratorij zagotavlja..." v celotni dokumentaciji
  - **Učni cilji**: Posodobljeno "Do konca tega modula..." v "Do konca tega laboratorija..."
  - **Navigacijske povezave**: Pretvorjene vse reference "Modul XX:" v "Laboratorij XX:" v medsebojnih referencah in navigaciji
  - **Sledenje dokončanju**: Posodobljeno "Po dokončanju tega modula..." v "Po dokončanju tega laboratorija..."
  - **Ohranjene tehnične reference**: Ohranili reference Python modulov v konfiguracijskih datotekah (npr. `"module": "mcp_server.main"`)

#### Izboljšava študijskega vodnika (study_guide.md)
- **Vizualni zemljevid učnega načrta**: Dodan nov razdelek "11. Laboratoriji za integracijo podatkovnih baz" z vizualizacijo strukture laboratorijev
- **Struktura repozitorija**: Posodobljeno iz desetih na enajst glavnih razdelkov z natančnim opisom 11-MCPServerHandsOnLabs
- **Navodila za učno pot**: Izboljšana navodila za navigacijo, ki pokrivajo razdelke 00-11
- **Pokritost tehnologij**: Dodane podrobnosti o integraciji FastMCP, PostgreSQL in Azure storitev
- **Učni rezultati**: Poudarjen razvoj produkcijsko pripravljenih strežnikov, vzorce integracije podatkovnih baz in varnost na ravni podjetja

#### Izboljšava strukture glavnega README
- **Terminologija na osnovi laboratorijev**: Posodobljen glavni README.md v 11-MCPServerHandsOnLabs za dosledno uporabo strukture "Laboratorij"
- **Organizacija učne poti**: Jasna progresija od osnovnih konceptov preko napredne implementacije do uvajanja v produkcijo
- **Osredotočenost na realni svet**: Poudarek na praktičnem, praktičnem učenju z vzorci in tehnologijami na ravni podjetja

### Izboljšave kakovosti in doslednosti dokumentacije
- **Poudarek na praktičnem učenju**: Okrepljen praktičen, laboratorijsko usmerjen pristop v celotni dokumentaciji
- **Osredotočenost na vzorce na ravni podjetja**: Poudarjene produkcijsko pripravljene implementacije in varnostne vidike na ravni podjetja
- **Integracija tehnologij**: Celovita pokritost sodobnih Azure storitev in vzorcev AI integracije
- **Učni napredek**: Jasna, strukturirana pot od osnovnih konceptov do uvajanja v produkcijo

## 26. september 2025

### Izboljšava študij primerov - Integracija GitHub MCP Registry

#### Študije primerov (09-CaseStudy/) - Osredotočenost na razvoj ekosistema
- **README.md**: Velika razširitev z obsežno študijo primera GitHub MCP Registry
  - **Študija primera GitHub MCP Registry**: Nova obsežna študija primera, ki preučuje lansiranje GitHub MCP Registry septembra 2025
    - **Analiza problema**: Podrobna preučitev razdrobljenosti odkrivanja in uvajanja MCP strežnikov
    - **Arhitektura rešitve**: Centraliziran pristop registra GitHub z enoklikno namestitvijo v VS Code
    - **Poslovni vpliv**: Merljive izboljšave pri uvajanju razvijalcev in produktivnosti
    - **Strateška vrednost**: Osredotočenost na modularno uvajanje agentov in interoperabilnost med orodji
    - **Razvoj ekosistema**: Pozicioniranje kot temeljna platforma za integracijo agentov
  - **Izboljšana struktura študij primerov**: Posodobljene vse študije primerov z doslednim formatiranjem in obsežnimi opisi
    - Azure AI Travel Agents: Poudarek na orkestraciji več agentov
    - Integracija Azure DevOps: Osredotočenost na avtomatizacijo delovnih tokov
    - Pridobivanje dokumentacije v realnem času: Implementacija Python konzolnega odjemalca
    - Interaktivni generator študijskega načrta: Chainlit pogovorna spletna aplikacija
    - Dokumentacija v urejevalniku: Integracija VS Code in GitHub Copilot
    - Upravljanje API-jev Azure: Vzorci integracije API-jev na ravni podjetja
    - GitHub MCP Registry: Razvoj ekosistema in platforma skupnosti
  - **Celoviti zaključek**: Preoblikovan zaključni razdelek, ki poudarja sedem študij primerov, ki pokrivajo različne dimenzije implementacije MCP
    - Integracija na ravni podjetja, orkestracija več agentov, produktivnost razvijalcev
    - Razvoj ekosistema, kategorizacija izobraževalnih aplikacij
    - Izboljšani vpogledi v arhitekturne vzorce, strategije implementacije in najboljše prakse
    - Poudarek na MCP kot zrel, produkcijsko pripravljen protokol

#### Posodobitve študijskega vodnika (study_guide.md)
- **Vizualni zemljevid učnega načrta**: Posodobljen miselni zemljevid za vključitev GitHub MCP Registry v razdelek študij primerov
- **Opis študij primerov**: Izboljšan iz generičnih opisov v podroben pregled sedmih obsežnih študij primerov
- **Struktura repozitorija**: Posodobljen razdelek 10 za odražanje celovite pokritosti študij primerov s specifičnimi podrobnostmi implementacije
- **Integracija dnevnika sprememb**: Dodan vnos za 26. september 2025, ki dokumentira dodatek GitHub MCP Registry in izboljšave študij primerov
- **Posodobitve datumov**: Posodobljen časovni žig v nogi za odražanje zadnje revizije (26. september 2025)

### Izboljšave kakovosti dokumentacije
- **Izboljšanje doslednosti**: Standardizirano formatiranje in struktura študij primerov v vseh sedmih primerih
- **Celovita pokritost**: Študije primerov zdaj pokrivajo scenarije na ravni podjetja, produktivnost razvijalcev in razvoj ekosistema
- **Strateško pozicioniranje**: Poudarjen MCP kot temeljna platforma za uvajanje agentnih sistemov
- **Integracija virov**: Posodobljeni dodatni viri za vključitev povezave GitHub MCP Registry

## 15. september 2025

### Razširitev naprednih tem - Prilagojeni transporti in inženiring konteksta

#### Prilagojeni transporti MCP (05-AdvancedTopics/mcp-transport/) - Nov napreden vodnik za implementacijo
- **README.md**: Celovit vodnik za implementacijo prilagojenih transportnih mehanizmov MCP
  - **Transport Azure Event Grid**: Celovita strežniška implementacija transporta, ki temelji na dogodkih
    - Primeri v C#, TypeScript in Python z integracijo Azure Functions
    - Vzorci arhitekture, ki temelji na dogodkih, za skalabilne rešitve MCP
    - Sprejemniki webhookov in obdelava sporočil na podlagi potiskanja
  - **Transport Azure Event Hubs**: Implementacija transporta za pretakanje z visoko prepustnostjo
    - Zmožnosti pretakanja v realnem času za scenarije z nizko zakasnitvijo
    - Strategije particioniranja in upravljanje kontrolnih točk
    - Paketna obdelava sporočil in optimizacija zmogljivosti
  - **Vzorci integracije na ravni podjetja**: Produkcijsko pripravljeni arhitekturni primeri
    - Distribuirana obdelava MCP preko več Azure Functions
    - Hibridne transportne arhitekture, ki združujejo več vrst transportov
    - Trajnost sporočil, zanesljivost in strategije obravnave napak
  - **Varnost in spremljanje**: Integracija Azure Key Vault in vzorci opazovanja
    - Avtentikacija z upravljano identiteto in dostop z najmanjšimi privilegiji
    - Telemetrija Application Insights in spremljanje zmogljivosti
    - Prekinjevalniki vezij in vzorci odpornosti na napake
  - **Okviri za testiranje**: Celovite strategije testiranja za prilagojene transporte
    - Enotno testiranje z dvojniki testov in okviri za simulacijo
    - Testiranje integracije z Azure Test Containers
    - Premisleki o testiranju zmogljivosti in obremenitve

#### Inženiring konteksta (05-AdvancedTopics/mcp-contextengineering/) - Nastajajoča disciplina AI
- **README.md**: Celovita raziskava inženiringa konteksta kot nastajajočega področja
  - **Osnovna načela**: Popolno deljenje konteksta, zavedanje odločanja o akcijah in upravljanje okna konteksta
  - **Poravnava s protokolom MCP**: Kako zasnova MCP obravnava izzive inženiringa konteksta
    - Omejitve okna konteksta in strategije progresivnega nalaganja
    - Določanje ustreznosti in dinamično pridobivanje konteksta
    - Večmodalno upravljanje konteksta in varnostni vidiki
  - **Pristopi k implementaciji**: Arhitekture z enim nitjem proti večagentnim arhitekturam
    - Tehnike razdeljevanja in prioritizacije konteksta
    - Strategije progresivnega nalaganja konteksta in stiskanja
    - Slojeviti pristopi konteksta in optimizacija pridobivanja
  - **Okvir za merjenje**: Nastajajoče metrike za ocenjevanje učinkovitosti konteksta
    - Premisleki o učinkovitosti vnosa, zmogljivosti, kakovosti in uporabniški izkušnji
    - Eksperimentalni pristopi k optimizaciji konteksta
    - Analiza napak in metodologije izboljšanja

#### Posodobitve navigacije učnega načrta (README.md)
- **Izboljšana struktura modulov**: Posodobljena tabela učnega načrta za vključitev novih naprednih tem
  - Dodani vnosi za inženiring konteksta (5.14) in prilagojeni transport (5.15)
  - Dosledno formatiranje in navigacijske povezave v vseh modulih
  - Posodobljeni opisi za odražanje trenutnega obsega vsebine

### Izboljšave strukture imenikov
- **Standardizacija poimenovanja**: Preimenovano "mcp transport" v "mcp-transport" za doslednost z drugimi mapami naprednih tem
- **Organizacija vsebine**: Vse mape 05-AdvancedTopics zdaj sledijo doslednemu vzorcu poimenovanja (mcp-[tema])

### Izboljšave kakovosti dokumentacije
- **Poravnava s specifikacijo MCP**: Vsa nova vsebina se nanaša na trenutno specifikacijo MCP 2025-06-18
- **Večjezični primeri**: Celoviti primeri kode v C#, TypeScript in Python
- **Osredotočenost na podjetja**: Produkcijsko pripravljeni vzorci in integracija Azure oblaka v celotni vsebini
- **Vizualna dokumentacija**: Diagrami Mermaid za vizualizacijo arhitekture in tokov

## 18. avgust 2025

### Celovita posodobitev dokumentacije - Standardi MCP 2025-06-18

#### Najboljše prakse varnosti MCP (02-Security/) - Popolna modernizacija
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Popolna prenova v skladu s specifikacijo MCP 2025-06-18
  - **Obvezne zahteve**: Dodane eksplicitne zahteve MUST/MUST NOT iz uradne specifikacije z jasnimi vizualnimi indikatorji
  - **12 osnovnih varnostnih praks**: Prestrukturirano iz 15-točkovnega seznama v celovite varnostne domene
    - Varnost žetonov in avtentikacija z integracijo zunanjega ponudnika identitete
    - Upravljanje sej in varnost transporta s kriptografskimi zahtevami
    - Zaščita pred grožnjami, specifičnimi za AI, z integracijo Microsoft Prompt Shields
    - Nadzor dostopa in dovoljenja z načelom najmanjšega privilegija
    - Varnost vsebine in spremljanje z integracijo Azure Content Safety
    - Varnost dobavne verige s celovitim preverjanjem komponent
    - Varnost OAuth in preprečevanje zmedenih napadov z implementacijo PKCE
    - Odziv na incidente in okrevanje z avtomatiziranimi zmožnostmi
    - Skladnost in upravljanje z regulativno poravnavo
    - Napredni varnostni nadzori z arhitekturo ničelnega zaupanja
    - Integracija Microsoftovega varnostnega ekosistema s celovitimi rešitvami
    - Nenehen razvoj varnosti z adaptivnimi praksami
  - **Microsoftove varnostne rešitve**: Izboljšana navodila za integracijo Prompt Shields, Azure Content Safety, Entra ID in GitHub Advanced Security
  - **Viri za implementacijo**: Kategorizirane celovite povezave virov po uradni dokumentaciji MCP, Microsoftovih varnostnih rešitvah, varnostnih standardih in vodnikih za implementacijo

#### Napredni varnostni nadzori (02-Security/) - Implementacija na ravni podjetja
- **MCP-SECURITY-CONTROLS-2025.md**: Popolna prenova z varnostnim okvirom na ravni podjetja
  - **9 celovitih varnostnih domen**: Razširjeno iz osnovnih nadzorov v podroben okvir na ravni podjetja
    - Napredna avtentikacija in avtorizacija z integracijo Microsoft Entra ID
    - Varnost žetonov in nadzor proti prehodu z obsežno validacijo
    - Nadzori varnosti sej s preprečevanjem ugrabitve
    - Varnostni nadzori, specifični za AI, s preprečevanjem vbrizgavanja ukazov in zastrupitve orodij
    - Preprečevanje zmedenih napadov z varnostjo proxyja OAuth
    - Varnost izvajanja orodij z
- **Vizualni kazalniki**: Jasno označevanje obveznih zahtev v primerjavi s priporočenimi praksami

#### Osnovni koncepti (01-CoreConcepts/) - Popolna posodobitev
- **Posodobitev različice protokola**: Posodobljeno na trenutno MCP specifikacijo 2025-06-18 z datumsko različico (format YYYY-MM-DD)
- **Izboljšanje arhitekture**: Izboljšani opisi gostiteljev, odjemalcev in strežnikov, ki odražajo trenutne vzorce MCP arhitekture
  - Gostitelji so zdaj jasno opredeljeni kot AI aplikacije, ki koordinirajo več povezav MCP odjemalcev
  - Odjemalci so opisani kot protokolarni konektorji, ki vzdržujejo enojne odnose s strežniki
  - Strežniki so izboljšani s scenariji lokalne in oddaljene namestitve
- **Prestrukturiranje primitivov**: Popolna prenova strežniških in odjemalskih primitivov
  - Strežniški primitivi: Viri (podatkovni viri), pozivi (predloge), orodja (izvedljive funkcije) z podrobnimi razlagami in primeri
  - Odjemalski primitivi: Vzorčenje (LLM zaključki), pridobivanje (uporabniški vnos), beleženje (razhroščevanje/nadzor)
  - Posodobljeno s trenutnimi vzorci odkrivanja (`*/list`), pridobivanja (`*/get`) in izvajanja (`*/call`) metod
- **Arhitektura protokola**: Uveden dvoplastni arhitekturni model
  - Podatkovna plast: Temelji na JSON-RPC 2.0 z upravljanjem življenjskega cikla in primitivov
  - Transportna plast: STDIO (lokalno) in Streamable HTTP s SSE (oddaljeno) transportnimi mehanizmi
- **Varnostni okvir**: Celovita varnostna načela, vključno z izrecnim soglasjem uporabnika, zaščito zasebnosti podatkov, varnostjo izvajanja orodij in varnostjo transportne plasti
- **Vzorce komunikacije**: Posodobljena sporočila protokola za prikaz inicializacije, odkrivanja, izvajanja in obveščanja
- **Primeri kode**: Posodobljeni večjezični primeri (.NET, Java, Python, JavaScript), ki odražajo trenutne vzorce MCP SDK

#### Varnost (02-Security/) - Celovita prenova varnosti  
- **Usklajenost s standardi**: Popolna uskladitev z varnostnimi zahtevami MCP specifikacije 2025-06-18
- **Razvoj avtentikacije**: Dokumentiran prehod od prilagojenih OAuth strežnikov na delegacijo zunanjih ponudnikov identitete (Microsoft Entra ID)
- **Analiza groženj, specifičnih za AI**: Izboljšana pokritost sodobnih napadov na AI
  - Podrobni scenariji napadov z vbrizgavanjem pozivov s primeri iz resničnega sveta
  - Mehanizmi zastrupitve orodij in vzorci napadov "rug pull"
  - Zastrupitev kontekstnega okna in napadi z zmedo modela
- **Microsoftove rešitve za varnost AI**: Celovita pokritost Microsoftovega varnostnega ekosistema
  - AI Prompt Shields z naprednim zaznavanjem, poudarjanjem in tehnikami ločevanja
  - Vzorci integracije Azure Content Safety
  - GitHub Advanced Security za zaščito dobavne verige
- **Napredno zmanjševanje groženj**: Podrobni varnostni ukrepi za
  - Ugrabitev sej s scenariji napadov, specifičnimi za MCP, in zahtevami za kriptografske ID-je sej
  - Težave z zmedenim namestnikom v scenarijih MCP proxy z zahtevami za izrecno soglasje
  - Ranljivosti pri prenosu žetonov z obveznimi kontrolami validacije
- **Varnost dobavne verige**: Razširjena pokritost AI dobavne verige, vključno z osnovnimi modeli, storitvami vgrajevanja, ponudniki konteksta in API-ji tretjih oseb
- **Osnovna varnost**: Izboljšana integracija z vzorci varnosti podjetij, vključno z arhitekturo ničelnega zaupanja in Microsoftovim varnostnim ekosistemom
- **Organizacija virov**: Kategorizirani celoviti viri po vrstah (uradni dokumenti, standardi, raziskave, Microsoftove rešitve, vodniki za implementacijo)

### Izboljšave kakovosti dokumentacije
- **Strukturirani učni cilji**: Izboljšani učni cilji s specifičnimi, izvedljivimi rezultati
- **Križne reference**: Dodane povezave med povezanimi temami varnosti in osnovnih konceptov
- **Trenutne informacije**: Posodobljene vse reference datumov in povezave specifikacij na trenutne standarde
- **Vodila za implementacijo**: Dodana specifična, izvedljiva vodila za implementacijo skozi oba razdelka

## 16. julij 2025

### Izboljšave README in navigacije
- Popolnoma prenovljena navigacija kurikuluma v README.md
- Zamenjani `<details>` oznake z bolj dostopnim formatom na osnovi tabel
- Ustvarjene alternativne možnosti postavitve v novi mapi "alternative_layouts"
- Dodani primeri navigacije v obliki kartic, zavihkov in harmonike
- Posodobljen razdelek strukture repozitorija, da vključuje vse najnovejše datoteke
- Izboljšan razdelek "Kako uporabljati ta kurikulum" z jasnimi priporočili
- Posodobljene povezave MCP specifikacij na pravilne URL-je
- Dodan razdelek o kontekstnem inženiringu (5.14) v strukturo kurikuluma

### Posodobitve študijskega vodnika
- Popolnoma prenovljen študijski vodnik, da se ujema s trenutno strukturo repozitorija
- Dodani novi razdelki za MCP odjemalce in orodja ter priljubljene MCP strežnike
- Posodobljen vizualni zemljevid kurikuluma, da natančno odraža vse teme
- Izboljšani opisi naprednih tem za pokritje vseh specializiranih področij
- Posodobljen razdelek študij primerov, da odraža dejanske primere
- Dodan ta celovit dnevnik sprememb

### Prispevki skupnosti (06-CommunityContributions/)
- Dodane podrobne informacije o MCP strežnikih za generiranje slik
- Dodan celovit razdelek o uporabi Claude v VSCode
- Dodana navodila za nastavitev in uporabo terminalskega odjemalca Cline
- Posodobljen razdelek MCP odjemalcev, da vključuje vse priljubljene možnosti odjemalcev
- Izboljšani primeri prispevkov z natančnejšimi vzorci kode

### Napredne teme (05-AdvancedTopics/)
- Organizirane vse mape specializiranih tem z doslednim poimenovanjem
- Dodani materiali in primeri kontekstnega inženiringa
- Dodana dokumentacija za integracijo agentov Foundry
- Izboljšana dokumentacija za varnostno integracijo Entra ID

## 11. junij 2025

### Prva izdaja
- Izdana prva različica kurikuluma MCP za začetnike
- Ustvarjena osnovna struktura za vseh 10 glavnih razdelkov
- Implementiran vizualni zemljevid kurikuluma za navigacijo
- Dodani začetni vzorčni projekti v več programskih jezikih

### Začetek (03-GettingStarted/)
- Ustvarjeni prvi primeri implementacije strežnika
- Dodana navodila za razvoj odjemalca
- Vključena navodila za integracijo LLM odjemalca
- Dodana dokumentacija za integracijo z VS Code
- Implementirani primeri strežnika s Server-Sent Events (SSE)

### Osnovni koncepti (01-CoreConcepts/)
- Dodana podrobna razlaga arhitekture odjemalec-strežnik
- Ustvarjena dokumentacija o ključnih komponentah protokola
- Dokumentirani vzorci sporočanja v MCP

## 23. maj 2025

### Struktura repozitorija
- Inicializiran repozitorij z osnovno strukturo map
- Ustvarjeni README datoteke za vsak glavni razdelek
- Nastavljena infrastruktura za prevajanje
- Dodane slikovne datoteke in diagrami

### Dokumentacija
- Ustvarjen začetni README.md s pregledom kurikuluma
- Dodani CODE_OF_CONDUCT.md in SECURITY.md
- Nastavljen SUPPORT.md z navodili za pomoč
- Ustvarjena preliminarna struktura študijskega vodnika

## 15. april 2025

### Načrtovanje in okvir
- Začetno načrtovanje kurikuluma MCP za začetnike
- Določeni učni cilji in ciljno občinstvo
- Oris 10-delne strukture kurikuluma
- Razvit konceptualni okvir za primere in študije primerov
- Ustvarjeni začetni prototipni primeri za ključne koncepte

---

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve AI za prevajanje [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem maternem jeziku je treba obravnavati kot avtoritativni vir. Za ključne informacije priporočamo profesionalni človeški prevod. Ne prevzemamo odgovornosti za morebitna nesporazumevanja ali napačne razlage, ki izhajajo iz uporabe tega prevoda.