<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "56dd5af7e84cc0db6e17e310112109ae",
  "translation_date": "2025-09-15T22:37:42+00:00",
  "source_file": "changelog.md",
  "language_code": "sl"
}
-->
# Dnevnik sprememb: Učni načrt MCP za začetnike

Ta dokument služi kot zapis vseh pomembnih sprememb, izvedenih v učnem načrtu Model Context Protocol (MCP) za začetnike. Spremembe so dokumentirane v obratnem kronološkem vrstnem redu (najprej najnovejše spremembe).

## 15. september 2025

### Razširitev naprednih tem - Prilagojeni transporti in kontekstno inženirstvo

#### MCP Prilagojeni transporti (05-AdvancedTopics/mcp-transport/) - Nov napreden vodič za implementacijo
- **README.md**: Celovit vodič za implementacijo prilagojenih transportnih mehanizmov MCP
  - **Azure Event Grid Transport**: Celovita strežniška rešitev za dogodkovno usmerjen transport
    - Primeri v C#, TypeScript in Python z integracijo Azure Functions
    - Vzorci arhitekture, usmerjene na dogodke, za skalabilne MCP rešitve
    - Sprejemniki webhookov in obdelava sporočil na podlagi potiskanja
  - **Azure Event Hubs Transport**: Implementacija transporta za visoko pretočno pretakanje
    - Zmožnosti pretakanja v realnem času za scenarije z nizko zakasnitvijo
    - Strategije particioniranja in upravljanje kontrolnih točk
    - Paketna obdelava sporočil in optimizacija zmogljivosti
  - **Vzorce integracije v podjetjih**: Primeri arhitektur, pripravljeni za produkcijo
    - Porazdeljena obdelava MCP med več Azure Functions
    - Hibridne transportne arhitekture, ki združujejo več vrst transportov
    - Strategije trajnosti sporočil, zanesljivosti in obravnave napak
  - **Varnost in spremljanje**: Integracija Azure Key Vault in vzorci opazovanja
    - Avtentikacija z upravljano identiteto in dostop z najmanjšimi privilegiji
    - Telemetrija Application Insights in spremljanje zmogljivosti
    - Vzorci za prekinitev vezja in odpornost na napake
  - **Okviri za testiranje**: Celovite strategije testiranja za prilagojene transporte
    - Enotno testiranje z dvojniki testov in okviri za simulacijo
    - Integracijsko testiranje z Azure Test Containers
    - Premisleki o zmogljivostnem in obremenitvenem testiranju

#### Kontekstno inženirstvo (05-AdvancedTopics/mcp-contextengineering/) - Nastajajoča disciplina umetne inteligence
- **README.md**: Celovit pregled kontekstnega inženirstva kot nastajajočega področja
  - **Osnovna načela**: Popolno deljenje konteksta, zavedanje odločitev o ukrepih in upravljanje kontekstnih oken
  - **Usklajenost z MCP protokolom**: Kako zasnova MCP rešuje izzive kontekstnega inženirstva
    - Omejitve kontekstnih oken in strategije progresivnega nalaganja
    - Določanje relevantnosti in dinamično pridobivanje konteksta
    - Večmodalno upravljanje konteksta in varnostni premisleki
  - **Pristopi k implementaciji**: Arhitekture z enim nitjem proti večagentnim arhitekturam
    - Tehnike razdeljevanja in prioritizacije konteksta
    - Progresivno nalaganje konteksta in strategije stiskanja
    - Slojeviti pristopi k kontekstu in optimizacija pridobivanja
  - **Okvir za merjenje**: Nastajajoče metrike za ocenjevanje učinkovitosti konteksta
    - Učinkovitost vnosa, zmogljivost, kakovost in premisleki o uporabniški izkušnji
    - Eksperimentalni pristopi k optimizaciji konteksta
    - Analiza napak in metodologije za izboljšave

#### Posodobitve navigacije po učnem načrtu (README.md)
- **Izboljšana struktura modulov**: Posodobljena tabela učnega načrta z novimi naprednimi temami
  - Dodani vnosi za Kontekstno inženirstvo (5.14) in Prilagojeni transport (5.15)
  - Dosledno oblikovanje in navigacijske povezave med vsemi moduli
  - Posodobljeni opisi, ki odražajo trenutni obseg vsebine

### Izboljšave strukture imenikov
- **Standardizacija poimenovanja**: Preimenovanje "mcp transport" v "mcp-transport" za doslednost z drugimi mapami naprednih tem
- **Organizacija vsebine**: Vse mape 05-AdvancedTopics zdaj sledijo doslednemu vzorcu poimenovanja (mcp-[tema])

### Izboljšave kakovosti dokumentacije
- **Usklajenost s specifikacijo MCP**: Vsa nova vsebina se sklicuje na trenutno specifikacijo MCP 2025-06-18
- **Primeri v več jezikih**: Celoviti primeri kode v C#, TypeScript in Python
- **Osredotočenost na podjetja**: Vzorci, pripravljeni za produkcijo, in integracija z oblakom Azure
- **Vizualna dokumentacija**: Diagrami Mermaid za vizualizacijo arhitekture in tokov

## 18. avgust 2025

### Celovita posodobitev dokumentacije - Standardi MCP 2025-06-18

#### Najboljše prakse za varnost MCP (02-Security/) - Popolna modernizacija
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Popolna prenova, usklajena s specifikacijo MCP 2025-06-18
  - **Obvezne zahteve**: Dodane eksplicitne zahteve MUST/MUST NOT iz uradne specifikacije z jasnimi vizualnimi indikatorji
  - **12 osnovnih varnostnih praks**: Prestrukturirano iz 15-točkovnega seznama v celovite varnostne domene
    - Varnost žetonov in avtentikacija z integracijo zunanjih ponudnikov identitete
    - Upravljanje sej in transportna varnost s kriptografskimi zahtevami
    - Zaščita pred grožnjami, specifičnimi za AI, z integracijo Microsoft Prompt Shields
    - Nadzor dostopa in dovoljenja z načelom najmanjšega privilegija
    - Varnost vsebine in spremljanje z integracijo Azure Content Safety
    - Varnost dobavne verige s celovitim preverjanjem komponent
    - Varnost OAuth in preprečevanje zmedenih napadov z implementacijo PKCE
    - Odziv na incidente in okrevanje z avtomatiziranimi zmožnostmi
    - Skladnost in upravljanje z regulativno usklajenostjo
    - Napredni varnostni nadzori z arhitekturo ničelnega zaupanja
    - Integracija Microsoftovega varnostnega ekosistema s celovitimi rešitvami
    - Nenehen razvoj varnosti z adaptivnimi praksami
  - **Microsoftove varnostne rešitve**: Izboljšana navodila za integracijo Prompt Shields, Azure Content Safety, Entra ID in GitHub Advanced Security
  - **Viri za implementacijo**: Kategorizirane celovite povezave do uradne dokumentacije MCP, Microsoftovih varnostnih rešitev, varnostnih standardov in vodičev za implementacijo

#### Napredni varnostni nadzori (02-Security/) - Implementacija v podjetjih
- **MCP-SECURITY-CONTROLS-2025.md**: Popolna prenova z varnostnim okvirom na ravni podjetij
  - **9 celovitih varnostnih domen**: Razširjeno iz osnovnih nadzorov v podroben okvir za podjetja
    - Napredna avtentikacija in avtorizacija z integracijo Microsoft Entra ID
    - Varnost žetonov in nadzor proti prenosu z obsežnim preverjanjem
    - Nadzori varnosti sej s preprečevanjem ugrabitve
    - Varnostni nadzori, specifični za AI, s preprečevanjem vbrizgavanja pozivov in zastrupitve orodij
    - Preprečevanje zmedenih napadov z varnostjo proxyjev OAuth
    - Varnost izvajanja orodij z izolacijo in peskovnikom
    - Nadzori varnosti dobavne verige s preverjanjem odvisnosti
    - Nadzori spremljanja in zaznavanja z integracijo SIEM
    - Odziv na incidente in okrevanje z avtomatiziranimi zmožnostmi
  - **Primeri implementacije**: Dodani podrobni bloki konfiguracije YAML in primeri kode
  - **Integracija Microsoftovih rešitev**: Celovita pokritost varnostnih storitev Azure, GitHub Advanced Security in upravljanja identitete v podjetjih

#### Varnost naprednih tem (05-AdvancedTopics/mcp-security/) - Implementacija, pripravljena za produkcijo
- **README.md**: Popolna prenova za implementacijo varnosti na ravni podjetij
  - **Usklajenost s trenutnimi specifikacijami**: Posodobljeno na specifikacijo MCP 2025-06-18 z obveznimi varnostnimi zahtevami
  - **Izboljšana avtentikacija**: Integracija Microsoft Entra ID z obsežnimi primeri v .NET in Java Spring Security
  - **Integracija varnosti AI**: Implementacija Microsoft Prompt Shields in Azure Content Safety z natančnimi primeri v Pythonu
  - **Napredno blaženje groženj**: Celoviti primeri implementacije za
    - Preprečevanje zmedenih napadov z PKCE in preverjanjem uporabniškega soglasja
    - Preprečevanje prenosa žetonov z validacijo občinstva in varnim upravljanjem žetonov
    - Preprečevanje ugrabitve sej s kriptografsko vezavo in analizo vedenja
  - **Integracija varnosti v podjetjih**: Spremljanje z Azure Application Insights, cevovodi za zaznavanje groženj in varnost dobavne verige
  - **Kontrolni seznam za implementacijo**: Jasni obvezni proti priporočenim varnostnim nadzorom z ugodnostmi Microsoftovega varnostnega ekosistema

### Izboljšave kakovosti dokumentacije in usklajenost s standardi
- **Sklici na specifikacije**: Posodobljeni vsi sklici na trenutno specifikacijo MCP 2025-06-18
- **Microsoftov varnostni ekosistem**: Izboljšana navodila za integracijo skozi celotno varnostno dokumentacijo
- **Praktična implementacija**: Dodani podrobni primeri kode v .NET, Java in Python z vzorci na ravni podjetij
- **Organizacija virov**: Celovita kategorizacija uradne dokumentacije, varnostnih standardov in vodičev za implementacijo
- **Vizualni indikatorji**: Jasno označevanje obveznih zahtev proti priporočenim praksam

## 16. julij 2025

### Izboljšave README in navigacije
- Popolnoma prenovljena navigacija po učnem načrtu v README.md
- Zamenjava `<details>` oznak z bolj dostopnim formatom na osnovi tabel
- Ustvarjeni alternativni možnosti postavitve v novi mapi "alternative_layouts"
- Dodani primeri navigacije v obliki kartic, zavihkov in harmonike
- Posodobljen razdelek strukture repozitorija, da vključuje vse najnovejše datoteke
- Izboljšan razdelek "Kako uporabljati ta učni načrt" z jasnimi priporočili
- Posodobljene povezave do specifikacij MCP, da kažejo na pravilne URL-je
- Dodan razdelek Kontekstno inženirstvo (5.14) v strukturo učnega načrta

### Posodobitve študijskega vodiča
- Popolnoma prenovljen študijski vodič, da se uskladi s trenutno strukturo repozitorija
- Dodani novi razdelki za MCP odjemalce in orodja ter priljubljene MCP strežnike
- Posodobljen vizualni zemljevid učnega načrta, da natančno odraža vse teme
- Izboljšani opisi naprednih tem, da pokrivajo vsa specializirana področja
- Posodobljen razdelek študijskih primerov, da odraža dejanske primere
- Dodan ta celovit dnevnik sprememb

### Prispevki skupnosti (06-CommunityContributions/)
- Dodane podrobne informacije o MCP strežnikih za generiranje slik
- Dodan celovit razdelek o uporabi Claude v VSCode
- Dodana navodila za nastavitev in uporabo terminalskega odjemalca Cline
- Posodobljen razdelek MCP odjemalcev, da vključuje vse priljubljene možnosti odjemalcev
- Izboljšani primeri prispevkov z natančnejšimi vzorci kode

### Napredne teme (05-AdvancedTopics/)
- Organizirane vse specializirane mape tem z doslednim poimenovanjem
- Dodani materiali in primeri za kontekstno inženirstvo
- Dodana dokumentacija za integracijo Foundry agentov
- Izboljšana dokumentacija za integracijo varnosti Entra ID

## 11. junij 2025

### Začetna ustvaritev
- Izdana prva različica učnega načrta MCP za začetnike
- Ustvarjena osnovna struktura za vseh 10 glavnih razdelkov
- Implementiran vizualni zemljevid učnega načrta za navigacijo
- Dodani začetni vzorčni projekti v več programskih jezikih

### Začetek (03-GettingStarted/)
- Ustvarjeni prvi primeri implementacije strežnika
- Dodana navodila za razvoj odjemalca
- Vključena navodila za integracijo LLM odjemalca
- Dodana dokumentacija za integracijo z VS Code
- Implementirani primeri strežnika Server-Sent Events (SSE)

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
- Ustvarjen začetni README.md s pregledom učnega načrta
- Dodani CODE_OF_CONDUCT.md in SECURITY.md
- Nastavljen SUPPORT.md z navodili za pridobitev pomoči
- Ustvarjena predhodna struktura študijskega vodiča

## 15. april 2025

### Načrtovanje in okvir
- Začetno načrtovanje učnega načrta MCP za začetnike
- Določeni učni cilji in ciljno občinstvo
- Obrisana 10-delna struktura učnega načrta
- Razvit konceptualni okvir za primere in študijske primere
- Ustvarjeni začetni prototipni primeri za ključne koncepte

---

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za prevajanje z umetno inteligenco [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem maternem jeziku je treba obravnavati kot avtoritativni vir. Za ključne informacije priporočamo profesionalni človeški prevod. Ne prevzemamo odgovornosti za morebitna napačna razumevanja ali napačne interpretacije, ki bi nastale zaradi uporabe tega prevoda.