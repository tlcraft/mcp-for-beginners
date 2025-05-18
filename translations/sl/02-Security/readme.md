<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-17T08:03:36+00:00",
  "source_file": "02-Security/readme.md",
  "language_code": "sl"
}
-->
# Najboljše prakse za varnost

Uporaba Model Context Protocol (MCP) prinaša močne nove zmogljivosti za aplikacije, ki jih poganja umetna inteligenca, vendar tudi uvaja edinstvene varnostne izzive, ki presegajo tradicionalna tveganja programske opreme. Poleg ustaljenih skrbi, kot so varno kodiranje, najmanjša privilegiranost in varnost dobavne verige, se MCP in delovne obremenitve umetne inteligence soočajo z novimi grožnjami, kot so vbrizgavanje pozivov, zastrupitev orodij in dinamična sprememba orodij. Ta tveganja lahko privedejo do izčrpavanja podatkov, kršitev zasebnosti in nenamernega vedenja sistema, če niso pravilno upravljana.

Ta lekcija raziskuje najpomembnejša varnostna tveganja, povezana z MCP—vključno z avtentikacijo, avtorizacijo, prekomernimi dovoljenji, posrednim vbrizgavanjem pozivov in ranljivostmi dobavne verige—ter ponuja ukrepe in najboljše prakse za njihovo zmanjšanje. Naučili se boste tudi, kako izkoristiti Microsoftove rešitve, kot so Prompt Shields, Azure Content Safety in GitHub Advanced Security, za okrepitev vaše implementacije MCP. Z razumevanjem in uporabo teh ukrepov lahko znatno zmanjšate verjetnost varnostne kršitve in zagotovite, da vaši sistemi umetne inteligence ostanejo robustni in vredni zaupanja.

# Cilji učenja

Do konca te lekcije boste sposobni:

- Prepoznati in razložiti edinstvena varnostna tveganja, ki jih uvaja Model Context Protocol (MCP), vključno z vbrizgavanjem pozivov, zastrupitvijo orodij, prekomernimi dovoljenji in ranljivostmi dobavne verige.
- Opisati in uporabiti učinkovite ukrepe za zmanjšanje varnostnih tveganj MCP, kot so robustna avtentikacija, najmanjša privilegiranost, varno upravljanje žetonov in preverjanje dobavne verige.
- Razumeti in izkoristiti Microsoftove rešitve, kot so Prompt Shields, Azure Content Safety in GitHub Advanced Security, za zaščito delovnih obremenitev MCP in umetne inteligence.
- Prepoznati pomen validacije metapodatkov orodij, spremljanja dinamičnih sprememb in obrambe pred posrednimi napadi z vbrizgavanjem pozivov.
- Integrirati uveljavljene varnostne najboljše prakse—kot so varno kodiranje, utrjevanje strežnikov in arhitektura ničelnega zaupanja—v vašo implementacijo MCP za zmanjšanje verjetnosti in vpliva varnostnih kršitev.

# Varnostni ukrepi MCP

Vsak sistem, ki ima dostop do pomembnih virov, ima implicitne varnostne izzive. Varnostne izzive je mogoče na splošno nasloviti s pravilno uporabo temeljnih varnostnih ukrepov in konceptov. Ker je MCP šele na novo definiran, se specifikacija zelo hitro spreminja in ko se protokol razvija, se bodo varnostni ukrepi v njem sčasoma izboljšali, kar bo omogočilo boljšo integracijo s podjetniškimi in uveljavljenimi varnostnimi arhitekturami ter najboljšimi praksami.

Raziskave, objavljene v [Microsoft Digital Defense Report](https://aka.ms/mddr), navajajo, da bi bilo 98% prijavljenih kršitev preprečenih z robustno varnostno higieno, in najboljša zaščita pred kakršnokoli kršitvijo je, da imate svojo osnovno varnostno higieno, najboljše prakse za varno kodiranje in varnost dobavne verige pravilno postavljene—te preizkušene prakse, ki jih že poznamo, še vedno najbolj vplivajo na zmanjšanje varnostnega tveganja.

Poglejmo nekaj načinov, kako lahko začnete nasloviti varnostna tveganja pri sprejemanju MCP.

# Avtentikacija strežnika MCP (če je bila vaša implementacija MCP pred 26. aprilom 2025)

> **Opomba:** Naslednje informacije so pravilne na dan 26. april 2025. Protokol MCP se nenehno razvija, prihodnje implementacije pa lahko uvedejo nove vzorce in ukrepe za avtentikacijo. Za najnovejše posodobitve in smernice vedno preverite [MCP Specification](https://spec.modelcontextprotocol.io/) in uradno [MCP GitHub repository](https://github.com/modelcontextprotocol).

### Izjava o problemu 
Prvotna specifikacija MCP je predvidevala, da bodo razvijalci napisali svoj avtentikacijski strežnik. To je zahtevalo znanje o OAuth in povezanih varnostnih omejitvah. Strežniki MCP so delovali kot OAuth 2.0 Avtorizacijski strežniki, neposredno upravljajoč potrebno avtentikacijo uporabnikov, namesto da bi jo delegirali zunanji storitvi, kot je Microsoft Entra ID. Od 26. aprila 2025 posodobitev specifikacije MCP omogoča, da strežniki MCP delegirajo avtentikacijo uporabnikov zunanji storitvi.

### Tveganja
- Napačno konfigurirana logika avtorizacije v strežniku MCP lahko vodi do izpostavitve občutljivih podatkov in nepravilno uporabljenih kontrol dostopa.
- Kraja OAuth žetona na lokalnem strežniku MCP. Če je žeton ukraden, se lahko nato uporabi za posnemanje strežnika MCP in dostop do virov in podatkov iz storitve, za katero je žeton OAuth namenjen.

### Ukrepi za zmanjšanje tveganj
- **Pregled in Utrditev Logike Avtorizacije:** Natančno preverite implementacijo avtorizacije vašega strežnika MCP, da zagotovite, da lahko občutljive vire dostopajo le nameravani uporabniki in odjemalci. Za praktične smernice si oglejte [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) in [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Uveljavitev Varnih Praks za Žetone:** Sledite [Microsoftovim najboljšim praksam za validacijo in življenjsko dobo žetonov](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens), da preprečite zlorabo dostopnih žetonov in zmanjšate tveganje ponovne uporabe ali kraje žetona.
- **Zaščita Shranjevanja Žetonov:** Žetone vedno shranjujte varno in uporabite šifriranje za zaščito med počitkom in prenosom. Za nasvete o implementaciji si oglejte [Uporaba varnega shranjevanja žetonov in šifriranje žetonov](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Prekomerna dovoljenja za strežnike MCP

### Izjava o problemu
Strežniki MCP so morda prejeli prekomerna dovoljenja za storitev/vir, do katerega dostopajo. Na primer, strežnik MCP, ki je del aplikacije za prodajo umetne inteligence in se povezuje z podjetniško podatkovno shrambo, bi moral imeti dostop omejen na prodajne podatke in ne bi smel imeti dostopa do vseh datotek v shrambi. Sklicujoč se nazaj na načelo najmanjše privilegiranosti (eno najstarejših varnostnih načel), noben vir ne bi smel imeti dovoljenj, ki presegajo tisto, kar je potrebno za izvajanje nalog, za katere je bil namenjen. Umetna inteligenca predstavlja povečanje izziva na tem področju, ker je zaradi omogočanja prilagodljivosti težko definirati natančna potrebna dovoljenja.

### Tveganja 
- Dodeljevanje prekomernih dovoljenj lahko omogoči izčrpavanje ali spreminjanje podatkov, do katerih strežnik MCP ni bil namenjen dostopati. To bi lahko bil tudi problem zasebnosti, če so podatki osebno prepoznavni podatki (PII).

### Ukrepi za zmanjšanje tveganj
- **Uporaba Načela Najmanjše Privilegiranosti:** Dodelite strežniku MCP le minimalna potrebna dovoljenja za izvajanje njegovih nalog. Redno pregledujte in posodabljajte ta dovoljenja, da zagotovite, da ne presegajo potrebnega. Za podrobne smernice si oglejte [Zagotovite najmanjši privilegirani dostop](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Uporaba Nadzora Dostopa na Podlagi Vlog (RBAC):** Dodelite vloge strežniku MCP, ki so strogo omejene na določene vire in dejanja, pri čemer se izogibajte širokim ali nepotrebnim dovoljenjem.
- **Spremljanje in Revizija Dovoljenj:** Nenehno spremljajte uporabo dovoljenj in pregledujte dnevnike dostopa, da hitro zaznate in odpravite prekomerne ali neuporabljene privilegije.

# Posredni napadi z vbrizgavanjem pozivov

### Izjava o problemu

Zlonamerni ali kompromitirani strežniki MCP lahko predstavljajo znatna tveganja z izpostavljanjem podatkov strank ali omogočanjem nenamernih dejanj. Ta tveganja so še posebej pomembna pri delovnih obremenitvah, ki temeljijo na umetni inteligenci in MCP, kjer:

- **Napadi z vbrizgavanjem pozivov**: Napadalci v pozive ali zunanjo vsebino vgradijo zlonamerna navodila, zaradi česar sistem umetne inteligence izvaja nenamerna dejanja ali razkriva občutljive podatke. Več o tem: [Vbrizgavanje pozivov](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Zastrupitev orodij**: Napadalci manipulirajo z metapodatki orodij (kot so opisi ali parametri), da vplivajo na vedenje umetne inteligence, kar lahko obide varnostne ukrepe ali izčrpava podatke. Podrobnosti: [Zastrupitev orodij](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Navzkrižno domeno vbrizgavanje pozivov**: Zlonamerna navodila so vgrajena v dokumente, spletne strani ali e-pošto, ki jih nato obdela umetna inteligenca, kar vodi do uhajanja ali manipulacije podatkov.
- **Dinamična sprememba orodij (Rug Pulls)**: Definicije orodij se lahko spremenijo po odobritvi uporabnika, kar uvede nova zlonamerna vedenja brez zavedanja uporabnika.

Te ranljivosti poudarjajo potrebo po robustni validaciji, spremljanju in varnostnih ukrepih pri integraciji strežnikov in orodij MCP v vaše okolje. Za poglobljen pregled si oglejte povezane reference zgoraj.

**Posredno vbrizgavanje pozivov** (znano tudi kot navzkrižno domeno vbrizgavanje pozivov ali XPIA) je kritična ranljivost v generativnih sistemih umetne inteligence, vključno s tistimi, ki uporabljajo Model Context Protocol (MCP). Pri tem napadu so zlonamerna navodila skrita v zunanji vsebini—kot so dokumenti, spletne strani ali e-pošta. Ko sistem umetne inteligence obdela to vsebino, lahko vgrajena navodila razlaga kot legitimne uporabniške ukaze, kar povzroči nenamerna dejanja, kot so uhajanje podatkov, generiranje škodljive vsebine ali manipulacija z uporabniškimi interakcijami. Za podrobno razlago in primere iz resničnega sveta si oglejte [Vbrizgavanje pozivov](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Posebej nevarna oblika tega napada je **Zastrupitev orodij**. Tukaj napadalci vbrizgajo zlonamerna navodila v metapodatke orodij MCP (kot so opisi orodij ali parametri). Ker se veliki jezikovni modeli (LLM) zanašajo na te metapodatke, da se odločijo, katera orodja naj uporabijo, lahko kompromitirani opisi zavajajo model, da izvaja nepooblaščene klice orodij ali obide varnostne ukrepe. Te manipulacije so pogosto nevidne končnim uporabnikom, vendar jih lahko sistem umetne inteligence razlaga in izvaja. To tveganje se povečuje v gostovanih okoljih strežnikov MCP, kjer se lahko definicije orodij posodobijo po odobritvi uporabnika—scenarij, ki se včasih imenuje "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". V takih primerih lahko orodje, ki je bilo prej varno, kasneje spremeni, da izvaja zlonamerna dejanja, kot so izčrpavanje podatkov ali spreminjanje vedenja sistema, brez vednosti uporabnika. Za več o tem vektorju napada si oglejte [Zastrupitev orodij](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

## Tveganja
Nenamerna dejanja umetne inteligence predstavljajo različna varnostna tveganja, vključno z izčrpavanjem podatkov in kršitvami zasebnosti.

### Ukrepi za zmanjšanje tveganj
### Uporaba ščitov za pozive za zaščito pred posrednimi napadi z vbrizgavanjem pozivov
-----------------------------------------------------------------------------

**Ščiti za pozive AI** so rešitev, ki jo je razvil Microsoft za obrambo pred neposrednimi in posrednimi napadi z vbrizgavanjem pozivov. Pomagajo skozi:

1.  **Detekcija in Filtriranje**: Ščiti za pozive uporabljajo napredne algoritme strojnega učenja in obdelavo naravnega jezika za odkrivanje in filtriranje zlonamernih navodil, vgrajenih v zunanjo vsebino, kot so dokumenti, spletne strani ali e-pošta.
    
2.  **Osvetljevanje**: Ta tehnika pomaga sistemu umetne inteligence razlikovati med veljavnimi sistemskimi navodili in potencialno nezanesljivimi zunanjimi vnosi. S preoblikovanjem besedila vnosa na način, ki je bolj relevanten za model, Osvetljevanje zagotavlja, da lahko umetna inteligenca bolje prepozna in ignorira zlonamerna navodila.
    
3.  **Omejevalniki in Označevanje Podatkov**: Vključevanje omejevalnikov v sistemsko sporočilo izrecno opredeljuje lokacijo besedila vnosa, kar pomaga sistemu umetne inteligence prepoznati in ločiti uporabniške vnose od potencialno škodljive zunanje vsebine. Označevanje podatkov razširja ta koncept z uporabo posebnih označevalcev za poudarjanje meja zaupanih in nezaupanih podatkov.
    
4.  **Nenehno Spremljanje in Posodobitve**: Microsoft nenehno spremlja in posodablja ščite za pozive, da se spopade z novimi in razvijajočimi se grožnjami. Ta proaktiven pristop zagotavlja, da obrambe ostanejo učinkovite proti najnovejšim tehnikam napadov.
    
5. **Integracija z Azure Content Safety:** Ščiti za pozive so del širšega kompleta Azure AI Content Safety, ki zagotavlja dodatna orodja za odkrivanje poskusov pobega iz zapora, škodljive vsebine in drugih varnostnih tveganj v aplikacijah umetne inteligence.

Več o ščitih za pozive AI lahko preberete v [Prompt Shields dokumentaciji](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

### Varnost dobavne verige

Varnost dobavne verige ostaja temeljna v dobi umetne inteligence, vendar se je obseg tega, kar sestavlja vašo dobavno verigo, razširil. Poleg tradicionalnih kodnih paketov morate zdaj strogo preverjati in spremljati vse komponente, povezane z umetno inteligenco, vključno z osnovnimi modeli, storitvami za vdelave, ponudniki konteksta in tretjimi API-ji. Vsak od teh lahko uvede ranljivosti ali tveganja, če ni pravilno upravljan.

**Ključne prakse za varnost dobavne verige za AI in MCP:**
- **Preverite vse komponente pred integracijo:** To vključuje ne samo odprtokodne knjižnice, temveč tudi AI modele, vire podatkov in zunanje API-je. Vedno preverite poreklo, licenciranje in znane ranljivosti.
- **Vzdržujte varne postopke uvajanja
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Microsoft में सॉफ़्टवेयर सप्लाई चेन को सुरक्षित करने की यात्रा](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [सुरक्षित न्यूनतम-विशेषाधिकार एक्सेस (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [टोकन मान्यता और जीवनकाल के लिए सर्वोत्तम प्रथाएं](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [सुरक्षित टोकन भंडारण का उपयोग करें और टोकन एन्क्रिप्ट करें (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [MCP के लिए प्रमाणीकरण गेटवे के रूप में Azure API प्रबंधन](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Microsoft Entra ID का उपयोग करके MCP सर्वरों के साथ प्रमाणीकरण](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### आगे 

आगे: [अध्याय 3: शुरुआत करना](/03-GettingStarted/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za strojno prevajanje [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku je treba obravnavati kot avtoritativni vir. Za kritične informacije se priporoča profesionalni človeški prevod. Ne prevzemamo odgovornosti za kakršne koli nesporazume ali napačne razlage, ki izhajajo iz uporabe tega prevoda.