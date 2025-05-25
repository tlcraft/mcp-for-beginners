<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-20T23:30:54+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "sl"
}
-->
# Najboljše varnostne prakse

Sprejetje Model Context Protocol (MCP) prinaša močne nove zmožnosti za aplikacije, ki temeljijo na umetni inteligenci, vendar hkrati uvaja edinstvene varnostne izzive, ki presegajo tradicionalna tveganja programske opreme. Poleg uveljavljenih skrbi, kot so varno programiranje, načelo najmanjših privilegijev in varnost dobavne verige, se MCP in delovne obremenitve AI soočajo z novimi grožnjami, kot so vbrizgavanje pozivov, zastrupitev orodij in dinamične spremembe orodij. Ta tveganja lahko, če niso ustrezno obvladovana, vodijo do iztoka podatkov, kršitev zasebnosti in nezaželenega vedenja sistema.

Ta lekcija raziskuje najpomembnejša varnostna tveganja povezana z MCP — vključno z avtentikacijo, avtorizacijo, prekomernimi dovoljenji, posrednim vbrizgavanjem pozivov in ranljivostmi dobavne verige — ter ponuja izvedljive ukrepe in najboljše prakse za njihovo ublažitev. Naučili se boste tudi, kako izkoristiti Microsoftove rešitve, kot so Prompt Shields, Azure Content Safety in GitHub Advanced Security, za krepitev vaše implementacije MCP. Z razumevanjem in uporabo teh ukrepov lahko znatno zmanjšate verjetnost varnostne kršitve in zagotovite, da vaši AI sistemi ostanejo robustni in zaupanja vredni.

# Cilji učenja

Do konca te lekcije boste lahko:

- Prepoznali in pojasnili edinstvena varnostna tveganja, ki jih prinaša Model Context Protocol (MCP), vključno z vbrizgavanjem pozivov, zastrupitvijo orodij, prekomernimi dovoljenji in ranljivostmi dobavne verige.
- Opisali in uporabili učinkovite ukrepe za zmanjševanje varnostnih tveganj MCP, kot so robustna avtentikacija, načelo najmanjših privilegijev, varno upravljanje žetonov in preverjanje dobavne verige.
- Razumeli in izkoristili Microsoftove rešitve, kot so Prompt Shields, Azure Content Safety in GitHub Advanced Security, za zaščito MCP in AI delovnih obremenitev.
- Prepoznali pomen preverjanja metapodatkov orodij, spremljanja dinamičnih sprememb in obrambe pred posrednimi napadi vbrizgavanja pozivov.
- Vključili uveljavljene varnostne prakse — kot so varno programiranje, utrjevanje strežnikov in arhitektura ničelnega zaupanja — v vašo implementacijo MCP, da zmanjšate verjetnost in vpliv varnostnih kršitev.

# Varnostni ukrepi MCP

Vsak sistem, ki ima dostop do pomembnih virov, prinaša implicitne varnostne izzive. Varnostne izzive je običajno mogoče rešiti z ustrezno uporabo osnovnih varnostnih ukrepov in konceptov. Ker je MCP šele novo definiran, se specifikacija hitro spreminja in se protokol razvija. Sčasoma bodo varnostni ukrepi v njem dozoreli, kar bo omogočilo boljšo integracijo z enterprise in uveljavljenimi varnostnimi arhitekturami ter najboljšimi praksami.

Raziskava, objavljena v [Microsoft Digital Defense Report](https://aka.ms/mddr), navaja, da bi 98 % prijavljenih kršitev preprečili z robustno varnostno higieno, najboljša zaščita pred katerokoli kršitvijo pa je, da imate osnovno varnostno higieno, najboljše prakse varnega programiranja in varnost dobavne verige urejene — te preverjene prakse še vedno najbolj vplivajo na zmanjšanje varnostnega tveganja.

Poglejmo nekaj načinov, kako lahko začnete obravnavati varnostna tveganja pri uvajanju MCP.

# Avtentikacija MCP strežnika (če je bila vaša implementacija MCP pred 26. aprilom 2025)

> **Note:** Naslednje informacije veljajo za stanje 26. aprila 2025. Protokol MCP se nenehno razvija, prihodnje implementacije pa lahko uvedejo nove vzorce avtentikacije in ukrepe. Za najnovejše posodobitve in navodila vedno preverite [MCP Specification](https://spec.modelcontextprotocol.io/) in uradni [MCP GitHub repository](https://github.com/modelcontextprotocol).

### Opis problema  
Izvirna specifikacija MCP je predvidevala, da bodo razvijalci napisali svoj avtentikacijski strežnik. To je zahtevalo znanje o OAuth in sorodnih varnostnih omejitvah. MCP strežniki so delovali kot OAuth 2.0 avtorizacijski strežniki, ki so neposredno upravljali zahtevano uporabniško avtentikacijo, namesto da bi jo delegirali zunanjemu servisu, kot je Microsoft Entra ID. Od 26. aprila 2025 posodobitev specifikacije MCP omogoča, da MCP strežniki delegirajo uporabniško avtentikacijo zunanjemu servisu.

### Tveganja
- Napačno konfigurirana avtorizacijska logika na MCP strežniku lahko povzroči izpostavitev občutljivih podatkov in nepravilno uporabo dostopnih kontrol.
- Kraja OAuth žetonov na lokalnem MCP strežniku. Če so ukradeni, jih lahko zlorabijo za ponarejanje MCP strežnika in dostop do virov ter podatkov, za katere velja OAuth žeton.

### Ukrepi za ublažitev
- **Preglejte in okrepite avtorizacijsko logiko:** Natančno preglejte implementacijo avtorizacije na vašem MCP strežniku, da zagotovite, da lahko do občutljivih virov dostopajo samo predvideni uporabniki in odjemalci. Za praktična navodila si oglejte [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) in [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Uveljavljajte varne prakse upravljanja žetonov:** Upoštevajte [Microsoftove najboljše prakse za validacijo žetonov in njihovo življenjsko dobo](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens), da preprečite zlorabo dostopnih žetonov in zmanjšate tveganje ponovne uporabe ali kraje žetonov.
- **Zaščitite shranjevanje žetonov:** Vedno shranjujte žetone varno in uporabljajte šifriranje za zaščito med mirovanjem in prenosom. Za nasvete o implementaciji glejte [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Prekomerna dovoljenja za MCP strežnike

### Opis problema  
MCP strežnikom so morda dodeljena prekomerna dovoljenja za storitev/vir, do katerega dostopajo. Na primer, MCP strežnik, ki je del AI prodajne aplikacije, ki se povezuje z enterprise podatkovnim skladiščem, bi moral imeti dostop omejen na prodajne podatke in ne dovoljenje za dostop do vseh datotek v skladišču. Glede na načelo najmanjših privilegijev (eno najstarejših varnostnih načel) noben vir ne bi smel imeti dovoljenj, ki presegajo tisto, kar je potrebno za izvedbo predvidenih nalog. AI predstavlja dodatni izziv, saj je zaradi njene prilagodljivosti težko natančno določiti potrebna dovoljenja.

### Tveganja  
- Podeljevanje prekomernih dovoljenj lahko omogoči iztiskanje ali spreminjanje podatkov, do katerih MCP strežnik ni smel imeti dostopa. To je lahko tudi težava zasebnosti, če gre za osebno prepoznavne podatke (PII).

### Ukrepi za ublažitev
- **Uporabite načelo najmanjših privilegijev:** MCP strežniku dodelite le minimalna dovoljenja, potrebna za izvedbo njegovih nalog. Redno pregledujte in posodabljajte ta dovoljenja, da zagotovite, da ne presegajo potrebnega. Za podrobna navodila glejte [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Uporabite nadzor dostopa na podlagi vlog (RBAC):** Dodeljujte vloge MCP strežniku, ki so natančno omejene na določene vire in dejanja, s čimer se izognete širokim ali nepotrebnim dovoljenjem.
- **Spremljajte in revidirajte dovoljenja:** Neprestano spremljajte uporabo dovoljenj in pregledujte dnevnike dostopa, da pravočasno zaznate in odpravite prekomerna ali neuporabljena dovoljenja.

# Posredni napadi vbrizgavanja pozivov

### Opis problema

Zlonamerni ali kompromitirani MCP strežniki lahko povzročijo znatna tveganja z izpostavitvijo podatkov strank ali omogočanjem nezaželenih dejanj. Ta tveganja so še posebej pomembna pri AI in delovnih obremenitvah MCP, kjer:

- **Napadi vbrizgavanja pozivov:** Napadalci vstavijo zlonamerna navodila v pozive ali zunanjo vsebino, zaradi česar AI sistem izvaja nezaželena dejanja ali razkrije občutljive podatke. Več informacij: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Zastrupitev orodij:** Napadalci manipulirajo z metapodatki orodij (kot so opisi ali parametri), da vplivajo na vedenje AI, s čimer lahko obidejo varnostne kontrole ali iztiskajo podatke. Podrobnosti: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Prek domen vbrizgavanje pozivov:** Zlonamerna navodila so vgrajena v dokumente, spletne strani ali e-pošto, ki jih nato AI obdela, kar vodi do uhajanja ali manipulacije podatkov.
- **Dinamične spremembe orodij (Rug Pulls):** Definicije orodij se lahko spremenijo po odobritvi uporabnika, kar prinaša nove zlonamerne vedenja brez uporabnikove vednosti.

Te ranljivosti poudarjajo potrebo po robustnem preverjanju, spremljanju in varnostnih ukrepih pri integraciji MCP strežnikov in orodij v vaše okolje. Za podrobnejši vpogled si oglejte zgoraj navedene povezave.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.sl.png)

**Posredni napad vbrizgavanja pozivov** (znan tudi kot prek domen vbrizgavanje ali XPIA) je kritična ranljivost v generativnih AI sistemih, vključno s tistimi, ki uporabljajo Model Context Protocol (MCP). Pri tem napadu so zlonamerna navodila skrita v zunanji vsebini — kot so dokumenti, spletne strani ali e-pošta. Ko AI sistem obdela to vsebino, lahko interpretira vgrajena navodila kot legitimna uporabniška ukaza, kar vodi do nezaželenih dejanj, kot so uhajanje podatkov, generiranje škodljive vsebine ali manipulacija uporabniških interakcij. Za podroben opis in primere iz resničnega sveta glejte [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Posebno nevaren je napad **Zastrupitev orodij**. Tu napadalci vnašajo zlonamerna navodila v metapodatke MCP orodij (kot so opisi ali parametri orodij). Ker veliki jezikovni modeli (LLM) uporabljajo te metapodatke za odločanje, katera orodja poklicati, lahko kompromitirani opisi zavajajo model, da izvede nepooblaščene klice orodij ali obide varnostne kontrole. Te manipulacije so pogosto nevidne končnim uporabnikom, vendar jih AI sistem lahko interpretira in izvede. To tveganje je še posebej veliko v gostovanih MCP strežniških okoljih, kjer se definicije orodij lahko posodobijo po odobritvi uporabnika — scenarij, ki ga včasih imenujejo "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". V takih primerih je orodje, ki je bilo prej varno, kasneje lahko spremenjeno za izvajanje zlonamernih dejanj, kot so iztiskanje podatkov ali spreminjanje vedenja sistema, brez vednosti uporabnika. Več o tem napadu si oglejte na [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.sl.png)

## Tveganja  
Nezaželena dejanja AI prinašajo različna varnostna tveganja, vključno z iztiskom podatkov in kršitvami zasebnosti.

### Ukrepi za ublažitev  
### Uporaba prompt shields za zaščito pred posrednimi napadi vbrizgavanja pozivov
-----------------------------------------------------------------------------

**AI Prompt Shields** so rešitev, ki jo je razvila Microsoft za obrambo pred neposrednimi in posrednimi napadi vbrizgavanja pozivov. Pomagajo z:

1.  **Zaznavanjem in filtriranjem:** Prompt Shields uporabljajo napredne algoritme strojnega učenja in obdelave naravnega jezika za zaznavanje in filtriranje zlonamernih navodil, vgrajenih v zunanjo vsebino, kot so dokumenti, spletne strani ali e-pošta.
    
2.  **Spotlighting:** Ta tehnika pomaga AI sistemu ločiti veljavna sistemska navodila od potencialno nezaupljivih zunanjih vhodov. Z transformacijo vhodnega besedila na način, ki je bolj relevanten za model, Spotlighting zagotavlja, da AI lažje prepozna in ignorira zlonamerna navodila.
    
3.  **Ločila in datamarking:** Vključitev ločil v sistemsko sporočilo jasno označuje lokacijo vhodnega besedila, kar pomaga AI sistemu prepoznati in ločiti uporabniške vnose od potencialno škodljive zunanje vsebine. Datamarking ta koncept razširja z uporabo posebnih označevalcev za poudarjanje meja zaupanja vrednih in nezaupanja vrednih podatkov.
    
4.  **Nenehno spremljanje in posodobitve:** Microsoft nenehno spremlja in posodablja Prompt Shields, da bi se spopadel z novimi in razvijajočimi se grožnjami. Ta proaktivni pristop zagotavlja, da obramba ostaja učinkovita proti najnovejšim tehnikam napadov.
    
5. **Integracija z Azure Content Safety:** Prompt Shields so del širšega paketa Azure AI Content Safety, ki ponuja dodatna orodja za zaznavanje poskusov zaobidenja varnostnih omejitev, škodljive vsebine in drugih varnostnih tveganj v AI aplikacijah.

Več o AI prompt shields si lahko preberete v [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.sl.png)

### Varnost dobavne verige

Varnost dobavne verige ostaja temeljnega pomena v dobi AI, vendar se je obseg tega, kar šteje za vašo dobavno verigo, razširil. Poleg tradicionalnih paketov kode morate zdaj temeljito preverjati in spremljati vse AI povezane komponente, vključno z osnovnimi modeli, storitvami za vdelave, ponudniki konteksta in API-ji tretjih oseb. Vsaka od teh komponent lahko prinese ranljivosti ali tveganja, če niso ustrezno obvladane.

**Ključne prakse varnosti dobavne verige za AI in MCP:**
- **Preverite vse komponente pred integracijo:** To vključuje ne samo odprtokodne knjižnice, temveč tudi AI modele, vire podatkov in zunanje API-je. Vedno preverite izvor, licenciranje in znane ranljivosti.
- **Vzdržujte varne deploy pipeline:** Uporabljajte avtomatizirane CI/CD pipeline z vgrajenim varnostnim pregledovanjem za zgodnje odkrivanje težav. Poskrbite, da se v produkcijo nameščajo samo zaupanja vredni artefakti.
- **Neprestano spremljajte in revidirajte:** Uvedite stalno spremljanje vseh odvisnosti, vključno z modeli in podatkovnimi storitvami, da odkrijete nove ranljivosti ali napade na dobavno verigo.
- **Uporabite načelo najmanjših privilegijev in kontrole
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Secure Token Storage and Encrypt Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Next

Next: [Chapter 3: Getting Started](/03-GettingStarted/README.md)

**Opozorilo**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Nismo odgovorni za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.