<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "245b03ae1e7973094fe82b8051ae0939",
  "translation_date": "2025-08-18T17:38:46+00:00",
  "source_file": "changelog.md",
  "language_code": "sl"
}
-->
# Dnevnik sprememb: Učni načrt MCP za začetnike

Ta dokument služi kot zapis vseh pomembnih sprememb, narejenih v učnem načrtu Model Context Protocol (MCP) za začetnike. Spremembe so dokumentirane v obratnem kronološkem vrstnem redu (najnovejše spremembe so na vrhu).

## 18. avgust 2025

### Celovita posodobitev dokumentacije - Standardi MCP 2025-06-18

#### Najboljše varnostne prakse MCP (02-Security/) - Popolna posodobitev
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Popolna prenova v skladu s specifikacijo MCP 2025-06-18
  - **Obvezne zahteve**: Dodane jasne zahteve MUST/MUST NOT iz uradne specifikacije z vizualnimi označevalci
  - **12 osnovnih varnostnih praks**: Prestrukturirano iz 15-točkovnega seznama v celovite varnostne domene
    - Varnost žetonov in avtentikacija z integracijo zunanjega ponudnika identitete
    - Upravljanje sej in varnost prenosa s kriptografskimi zahtevami
    - Zaščita pred grožnjami, specifičnimi za AI, z integracijo Microsoft Prompt Shields
    - Nadzor dostopa in dovoljenja z načelom najmanjših privilegijev
    - Varnost vsebine in nadzor z integracijo Azure Content Safety
    - Varnost dobavne verige z obsežnim preverjanjem komponent
    - Varnost OAuth in preprečevanje napadov "zmedenega namestnika" z implementacijo PKCE
    - Odziv na incidente in okrevanje z avtomatiziranimi zmogljivostmi
    - Skladnost in upravljanje z regulativno uskladitvijo
    - Napredni varnostni ukrepi z arhitekturo ničelnega zaupanja
    - Integracija z Microsoftovim varnostnim ekosistemom z obsežnimi rešitvami
    - Nenehen razvoj varnosti z adaptivnimi praksami
  - **Microsoftove varnostne rešitve**: Izboljšana navodila za integracijo Prompt Shields, Azure Content Safety, Entra ID in GitHub Advanced Security
  - **Viri za implementacijo**: Kategorizirani obsežni povezovalni viri po uradni dokumentaciji MCP, Microsoftovih varnostnih rešitvah, varnostnih standardih in vodnikih za implementacijo

#### Napredni varnostni ukrepi (02-Security/) - Implementacija na ravni podjetja
- **MCP-SECURITY-CONTROLS-2025.md**: Popolna prenova z varnostnim okvirom na ravni podjetja
  - **9 celovitih varnostnih domen**: Razširjeno iz osnovnih ukrepov v podroben okvir za podjetja
    - Napredna avtentikacija in avtorizacija z integracijo Microsoft Entra ID
    - Varnost žetonov in preprečevanje zlorab z obsežnim preverjanjem
    - Varnost sej z zaščito pred ugrabitvijo
    - Varnostni ukrepi, specifični za AI, z zaščito pred vbrizgavanjem ukazov in zastrupitvijo orodij
    - Preprečevanje napadov "zmedenega namestnika" z varnostjo proxy OAuth
    - Varnost izvajanja orodij z izolacijo in peskovnikom
    - Varnostni ukrepi za dobavno verigo z verifikacijo odvisnosti
    - Nadzorni in detekcijski ukrepi z integracijo SIEM
    - Odziv na incidente in okrevanje z avtomatiziranimi zmogljivostmi
  - **Primeri implementacije**: Dodani podrobni YAML konfiguracijski bloki in primeri kode
  - **Integracija Microsoftovih rešitev**: Obsežna pokritost varnostnih storitev Azure, GitHub Advanced Security in upravljanja identitete na ravni podjetja

#### Napredne teme varnosti (05-AdvancedTopics/mcp-security/) - Implementacija za produkcijo
- **README.md**: Popolna prenova za implementacijo varnosti na ravni podjetja
  - **Usklajenost s trenutno specifikacijo**: Posodobljeno na specifikacijo MCP 2025-06-18 z obveznimi varnostnimi zahtevami
  - **Izboljšana avtentikacija**: Integracija Microsoft Entra ID z obsežnimi primeri za .NET in Java Spring Security
  - **Integracija varnosti AI**: Implementacija Microsoft Prompt Shields in Azure Content Safety z natančnimi primeri v Pythonu
  - **Napredno zmanjševanje groženj**: Celoviti primeri implementacije za
    - Preprečevanje napadov "zmedenega namestnika" z PKCE in preverjanjem uporabniškega soglasja
    - Preprečevanje zlorabe žetonov z validacijo občinstva in varnim upravljanjem žetonov
    - Preprečevanje ugrabitve sej s kriptografsko vezavo in analizo vedenja
  - **Integracija varnosti na ravni podjetja**: Nadzor z Azure Application Insights, detekcijski cevovodi za grožnje in varnost dobavne verige
  - **Kontrolni seznam za implementacijo**: Jasni obvezni in priporočeni varnostni ukrepi z ugodnostmi Microsoftovega varnostnega ekosistema

### Kakovost dokumentacije in usklajenost s standardi
- **Reference na specifikacije**: Posodobljene vse reference na trenutno specifikacijo MCP 2025-06-18
- **Microsoftov varnostni ekosistem**: Izboljšana navodila za integracijo skozi celotno varnostno dokumentacijo
- **Praktična implementacija**: Dodani podrobni primeri kode v .NET, Java in Python z vzorci za podjetja
- **Organizacija virov**: Celovita kategorizacija uradne dokumentacije, varnostnih standardov in vodnikov za implementacijo
- **Vizualni označevalci**: Jasno označevanje obveznih zahtev v primerjavi s priporočenimi praksami

#### Osnovni koncepti (01-CoreConcepts/) - Popolna posodobitev
- **Posodobitev različice protokola**: Posodobljeno za sklicevanje na trenutno specifikacijo MCP 2025-06-18 z datumsko različico (format YYYY-MM-DD)
- **Izboljšanje arhitekture**: Izboljšani opisi gostiteljev, odjemalcev in strežnikov za odraz trenutnih vzorcev arhitekture MCP
  - Gostitelji so zdaj jasno opredeljeni kot AI aplikacije, ki usklajujejo več povezav MCP odjemalcev
  - Odjemalci opisani kot protokolarni konektorji z vzdrževanjem enega-na-enega odnosov s strežniki
  - Strežniki izboljšani s scenariji lokalne in oddaljene namestitve
- **Prestrukturiranje primitivov**: Popolna prenova strežniških in odjemalskih primitivov
  - Strežniški primitiv: Viri (viri podatkov), Predloge (šablone), Orodja (izvedljive funkcije) z natančnimi razlagami in primeri
  - Odjemalski primitiv: Vzorčenje (LLM zaključki), Elicitacija (uporabniški vnos), Beleženje (razhroščevanje/nadzor)
  - Posodobljeno s trenutnimi metodami za odkrivanje (`*/list`), pridobivanje (`*/get`) in izvajanje (`*/call`)
- **Arhitektura protokola**: Uveden dvoslojni arhitekturni model
  - Podatkovni sloj: Temelji na JSON-RPC 2.0 z upravljanjem življenjskega cikla in primitivov
  - Transportni sloj: STDIO (lokalno) in Streamable HTTP s SSE (oddaljeno) transportnimi mehanizmi
- **Varnostni okvir**: Celovita varnostna načela, vključno z izrecnim uporabniškim soglasjem, zaščito zasebnosti podatkov, varnostjo izvajanja orodij in varnostjo transportnega sloja
- **Vzorce komunikacije**: Posodobljena sporočila protokola za prikaz inicializacije, odkrivanja, izvajanja in tokov obvestil
- **Primeri kode**: Osveženi večjezični primeri (.NET, Java, Python, JavaScript) za odraz trenutnih vzorcev MCP SDK

#### Varnost (02-Security/) - Celovita prenova varnosti  
- **Usklajenost s standardi**: Popolna uskladitev z varnostnimi zahtevami specifikacije MCP 2025-06-18
- **Razvoj avtentikacije**: Dokumentiran prehod iz prilagojenih OAuth strežnikov na delegacijo zunanjega ponudnika identitete (Microsoft Entra ID)
- **Analiza groženj, specifičnih za AI**: Izboljšana pokritost sodobnih napadov na AI
  - Podrobni scenariji napadov z vbrizgavanjem ukazov z resničnimi primeri
  - Mehanizmi zastrupitve orodij in vzorci napadov "izvleci preprogo"
  - Zastrupitev kontekstnega okna in napadi z zmedenjem modela
- **Microsoftove varnostne rešitve za AI**: Celovita pokritost Microsoftovega varnostnega ekosistema
  - AI Prompt Shields z naprednim zaznavanjem, poudarjanjem in tehnikami ločil
  - Vzorci integracije Azure Content Safety
  - GitHub Advanced Security za zaščito dobavne verige
- **Napredno zmanjševanje groženj**: Podrobni varnostni ukrepi za
  - Ugrabitev sej s scenariji napadov, specifičnimi za MCP, in zahtevami za kriptografske ID-je sej
  - Težave "zmedenega namestnika" v proxy scenarijih MCP z izrecnimi zahtevami za soglasje
  - Ranljivosti pri prehodu žetonov z obveznimi kontrolami validacije
- **Varnost dobavne verige**: Razširjena pokritost dobavne verige AI, vključno z osnovnimi modeli, storitvami vdelav, ponudniki konteksta in API-ji tretjih oseb
- **Osnovna varnost**: Izboljšana integracija z varnostnimi vzorci na ravni podjetja, vključno z arhitekturo ničelnega zaupanja in Microsoftovim varnostnim ekosistemom
- **Organizacija virov**: Kategorizirani obsežni povezovalni viri po tipu (uradna dokumentacija, standardi, raziskave, Microsoftove rešitve, vodniki za implementacijo)

### Izboljšave kakovosti dokumentacije
- **Strukturirani učni cilji**: Izboljšani učni cilji s specifičnimi, izvedljivimi rezultati
- **Križne reference**: Dodane povezave med povezanimi temami varnosti in osnovnih konceptov
- **Aktualne informacije**: Posodobljeni vsi datumski sklici in povezave na specifikacije na trenutne standarde
- **Navodila za implementacijo**: Dodana specifična, izvedljiva navodila za implementacijo skozi oba razdelka

## 16. julij 2025

### Izboljšave README in navigacije
- Popolnoma prenovljena navigacija učnega načrta v README.md
- Zamenjani `<details>` oznake z bolj dostopnim formatom na osnovi tabel
- Ustvarjene alternativne možnosti postavitve v novi mapi "alternative_layouts"
- Dodani primeri navigacije v obliki kartic, zavihkov in harmonike
- Posodobljen razdelek o strukturi repozitorija, da vključuje vse najnovejše datoteke
- Izboljšan razdelek "Kako uporabljati ta učni načrt" z jasnimi priporočili
- Posodobljene povezave na specifikacijo MCP, da kažejo na pravilne URL-je
- Dodan razdelek o kontekstnem inženiringu (5.14) v strukturo učnega načrta

### Posodobitve študijskega vodnika
- Popolnoma prenovljen študijski vodnik za uskladitev s trenutno strukturo repozitorija
- Dodani novi razdelki za MCP odjemalce in orodja ter priljubljene MCP strežnike
- Posodobljen vizualni zemljevid učnega načrta, da natančno odraža vse teme
- Izboljšani opisi naprednih tem za pokritje vseh specializiranih področij
- Posodobljen razdelek študijskih primerov, da odraža dejanske primere
- Dodan ta celovit dnevnik sprememb

### Prispevki skupnosti (06-CommunityContributions/)
- Dodane podrobne informacije o MCP strežnikih za generiranje slik
- Dodan obsežen razdelek o uporabi Claude v VSCode
- Dodana navodila za nastavitev in uporabo terminalskega odjemalca Cline
- Posodobljen razdelek MCP odjemalcev, da vključuje vse priljubljene možnosti odjemalcev
- Izboljšani primeri prispevkov z natančnejšimi vzorci kode

### Napredne teme (05-AdvancedTopics/)
- Organizirane vse mape specializiranih tem z doslednim poimenovanjem
- Dodani materiali in primeri za kontekstni inženiring
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
- Dodana navodila za razvoj odjemalcev
- Vključena navodila za integracijo LLM odjemalcev
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
- Ustvarjen začetni README.md s pregledom učnega načrta
- Dodani CODE_OF_CONDUCT.md in SECURITY.md
- Nastavljen SUPPORT.md z navodili za pridobitev pomoči
- Ustvarjena predhodna struktura študijskega vodnika

## 15. april 2025

### Načrtovanje in okvir
- Začetno načrtovanje učnega načrta MCP za začetnike
- Določeni učni cilji in ciljno občinstvo
- Orisana 10-delna struktura učnega načrta
- Razvit konceptualni okvir za primere in študije primerov
- Ustvarjeni začetni prototipni primeri za ključne koncepte

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za strojno prevajanje [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku je treba obravnavati kot avtoritativni vir. Za ključne informacije priporočamo strokovno človeško prevajanje. Ne prevzemamo odgovornosti za morebitna nesporazumevanja ali napačne razlage, ki izhajajo iz uporabe tega prevoda.