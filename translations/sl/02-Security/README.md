<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c69f9df7f3215dac8d056020539bac36",
  "translation_date": "2025-07-04T19:15:56+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "sl"
}
-->
# Najboljše varnostne prakse

Sprejetje Model Context Protocol (MCP) prinaša močne nove zmogljivosti za aplikacije, ki temeljijo na umetni inteligenci, vendar hkrati uvaja tudi edinstvene varnostne izzive, ki presegajo tradicionalna tveganja programske opreme. Poleg uveljavljenih skrbi, kot so varno kodiranje, načelo najmanjših privilegijev in varnost dobavne verige, se MCP in delovne obremenitve AI soočajo z novimi grožnjami, kot so prompt injection, zastrupitev orodij in dinamične spremembe orodij. Ta tveganja lahko vodijo do iztoka podatkov, kršitev zasebnosti in neželenega vedenja sistema, če niso ustrezno obvladana.

Ta lekcija raziskuje najpomembnejša varnostna tveganja, povezana z MCP — vključno z avtentikacijo, avtorizacijo, prekomernimi dovoljenji, posrednim prompt injection in ranljivostmi dobavne verige — ter ponuja izvedljive ukrepe in najboljše prakse za njihovo ublažitev. Naučili se boste tudi, kako izkoristiti Microsoftove rešitve, kot so Prompt Shields, Azure Content Safety in GitHub Advanced Security, za krepitev vaše implementacije MCP. Z razumevanjem in uporabo teh ukrepov lahko znatno zmanjšate verjetnost varnostnega incidenta in zagotovite, da vaši AI sistemi ostanejo zanesljivi in varni.

# Cilji učenja

Ob koncu te lekcije boste znali:

- Prepoznati in razložiti edinstvena varnostna tveganja, ki jih prinaša Model Context Protocol (MCP), vključno s prompt injection, zastrupitvijo orodij, prekomernimi dovoljenji in ranljivostmi dobavne verige.
- Opisati in uporabiti učinkovite ukrepe za ublažitev varnostnih tveganj MCP, kot so robustna avtentikacija, načelo najmanjših privilegijev, varno upravljanje žetonov in preverjanje dobavne verige.
- Razumeti in izkoristiti Microsoftove rešitve, kot so Prompt Shields, Azure Content Safety in GitHub Advanced Security, za zaščito MCP in AI delovnih obremenitev.
- Prepoznati pomen preverjanja metapodatkov orodij, spremljanja dinamičnih sprememb in obrambe pred posrednimi napadi prompt injection.
- Vključiti uveljavljene varnostne najboljše prakse — kot so varno kodiranje, utrjevanje strežnikov in arhitektura ničelnega zaupanja — v vašo implementacijo MCP za zmanjšanje verjetnosti in vpliva varnostnih kršitev.

# Varnostni ukrepi MCP

Vsak sistem, ki ima dostop do pomembnih virov, se sooča z implicitnimi varnostnimi izzivi. Varnostne izzive je na splošno mogoče rešiti z ustrezno uporabo osnovnih varnostnih ukrepov in konceptov. Ker je MCP šele nedavno definiran, se specifikacija hitro spreminja in se razvija skupaj s protokolom. Sčasoma bodo varnostni ukrepi v njem dozoreli, kar bo omogočilo boljšo integracijo z obstoječimi podjetniškimi in uveljavljenimi varnostnimi arhitekturami ter najboljšimi praksami.

Raziskava, objavljena v [Microsoft Digital Defense Report](https://aka.ms/mddr), navaja, da bi 98 % prijavljenih kršitev preprečila dosledna varnostna higiena, najboljša zaščita pred kakršnokoli kršitvijo pa je pravilno izvajanje osnovne varnostne higiene, najboljših praks varnega kodiranja in varnosti dobavne verige — te preizkušene prakse še vedno najbolj vplivajo na zmanjšanje varnostnih tveganj.

Poglejmo si nekaj načinov, kako lahko začnete obvladovati varnostna tveganja pri uvajanju MCP.

> **Note:** Naslednje informacije so veljavne na dan **29. maj 2025**. Protokol MCP se nenehno razvija, prihodnje implementacije pa lahko uvedejo nove vzorce avtentikacije in varnostne ukrepe. Za najnovejše posodobitve in navodila vedno preverite [MCP Specification](https://spec.modelcontextprotocol.io/) ter uradni [MCP GitHub repozitorij](https://github.com/modelcontextprotocol) in [stran z najboljšimi varnostnimi praksami](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Opis problema  
Izvirna specifikacija MCP je predvidevala, da bodo razvijalci napisali svoj avtentikacijski strežnik. To je zahtevalo znanje o OAuth in povezanih varnostnih omejitvah. MCP strežniki so delovali kot OAuth 2.0 avtorizacijski strežniki, ki so neposredno upravljali potrebno uporabniško avtentikacijo, namesto da bi jo delegirali zunanjemu servisu, kot je Microsoft Entra ID. Od **26. aprila 2025** posodobitev specifikacije MCP omogoča, da MCP strežniki delegirajo uporabniško avtentikacijo zunanjemu servisu.

### Tveganja
- Napačno konfigurirana avtorizacijska logika na MCP strežniku lahko vodi do razkritja občutljivih podatkov in nepravilno uporabljenih dostopnih pravic.
- Kraja OAuth žetonov na lokalnem MCP strežniku. Če so žetoni ukradeni, jih lahko napadalec uporabi za lažno predstavljanje MCP strežnika in dostop do virov ter podatkov, za katere je žeton namenjen.

#### Token Passthrough
Token passthrough je v specifikaciji avtorizacije izrecno prepovedan, saj prinaša več varnostnih tveganj, med drugim:

#### Obhod varnostnih ukrepov
MCP strežnik ali spodnji API-ji lahko izvajajo pomembne varnostne ukrepe, kot so omejevanje hitrosti, preverjanje zahtevkov ali spremljanje prometa, ki so odvisni od občinstva žetona ali drugih omejitev poverilnic. Če lahko odjemalci pridobijo in neposredno uporabljajo žetone pri spodnjih API-jih brez ustrezne validacije MCP strežnika ali brez zagotovila, da so žetoni izdani za pravi servis, ti ukrepi niso upoštevani.

#### Težave z odgovornostjo in revizijsko sledjo
MCP strežnik ne bo mogel identificirati ali razlikovati med MCP odjemalci, če ti kličejo z žetonom za dostop, ki ga je izdal zunanji vir in je za MCP strežnik lahko nejasen.
Dnevniki spodnjega strežnika virov lahko kažejo zahtevke, ki se zdijo, kot da prihajajo iz drugega vira z drugačno identiteto, namesto iz MCP strežnika, ki dejansko posreduje žetone.
Oba dejavnika otežujeta preiskavo incidentov, nadzor in revizijo.
Če MCP strežnik posreduje žetone brez preverjanja njihovih trditev (npr. vlog, privilegijev ali občinstva) ali drugih metapodatkov, lahko zlonamerni uporabnik z ukradenim žetonom uporabi strežnik kot posrednika za iztiskanje podatkov.

#### Težave z mejo zaupanja
Spodnji strežnik virov zaupa določenim entitetam. To zaupanje lahko vključuje predpostavke o izvoru ali vzorcih vedenja odjemalcev. Kršitev te meje zaupanja lahko povzroči nepričakovane težave.
Če žeton sprejema več storitev brez ustrezne validacije, lahko napadalec, ki kompromitira eno storitev, uporabi žeton za dostop do drugih povezanih storitev.

#### Tveganje združljivosti v prihodnosti
Tudi če MCP strežnik danes deluje kot "čisti proxy", bo morda kasneje moral dodati varnostne ukrepe. Začetek z ustrezno ločitvijo občinstva žetonov olajša razvoj varnostnega modela.

### Ukrepi za ublažitev

**MCP strežniki NE SMEJO sprejemati žetonov, ki niso izrecno izdani za MCP strežnik**

- **Preglejte in utrdite avtorizacijsko logiko:** Natančno preglejte implementacijo avtorizacije na vašem MCP strežniku, da zagotovite, da do občutljivih virov dostopajo le predvideni uporabniki in odjemalci. Za praktične nasvete glejte [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) in [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Uveljavljajte varne prakse upravljanja žetonov:** Sledite [Microsoftovim najboljšim praksam za validacijo žetonov in njihovo življenjsko dobo](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens), da preprečite zlorabo dostopnih žetonov in zmanjšate tveganje ponovne uporabe ali kraje žetonov.
- **Zaščitite shranjevanje žetonov:** Vedno shranjujte žetone varno in uporabljajte šifriranje za zaščito med mirovanjem in prenosom. Za nasvete o implementaciji glejte [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Prekomerna dovoljenja za MCP strežnike

### Opis problema  
MCP strežnikom so morda dodeljena prekomerna dovoljenja za storitev/vir, do katerega dostopajo. Na primer, MCP strežnik, ki je del AI prodajne aplikacije, ki se povezuje s podjetniškim podatkovnim skladiščem, bi moral imeti dostop omejen na prodajne podatke in ne dovoljenje za dostop do vseh datotek v skladišču. Glede na načelo najmanjših privilegijev (eno najstarejših varnostnih načel) noben vir ne bi smel imeti dovoljenj, ki presegajo tisto, kar je potrebno za izvedbo predvidenih nalog. AI predstavlja dodatni izziv, saj je zaradi njene prilagodljivosti težko natančno določiti potrebna dovoljenja.

### Tveganja  
- Dodeljevanje prekomernih dovoljenj lahko omogoči iztiskanje ali spreminjanje podatkov, do katerih MCP strežnik ni smel imeti dostopa. To je lahko tudi vprašanje zasebnosti, če gre za osebne podatke (PII).

### Ukrepi za ublažitev
- **Uporabite načelo najmanjših privilegijev:** MCP strežniku dodelite le minimalna dovoljenja, potrebna za opravljanje njegovih nalog. Redno pregledujte in posodabljajte ta dovoljenja, da zagotovite, da ne presegajo potrebnega. Za podrobna navodila glejte [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Uporabite nadzor dostopa na osnovi vlog (RBAC):** Dodelite vlogi MCP strežniku, ki so strogo omejene na določene vire in dejanja, ter se izogibajte širokim ali nepotrebnim dovoljenjem.
- **Spremljajte in revidirajte dovoljenja:** Neprestano spremljajte uporabo dovoljenj in pregledujte dnevnike dostopa, da hitro odkrijete in odpravite prekomerna ali neuporabljena dovoljenja.

# Posredni napadi prompt injection

### Opis problema

Zlonamerni ali kompromitirani MCP strežniki lahko povzročijo resna tveganja z razkritjem podatkov strank ali omogočanjem neželenih dejanj. Ta tveganja so še posebej pomembna pri AI in delovnih obremenitvah, ki temeljijo na MCP, kjer:

- **Napadi prompt injection:** Napadalci vstavijo zlonamerna navodila v pozive ali zunanjo vsebino, zaradi česar AI sistem izvede neželena dejanja ali razkrije občutljive podatke. Več: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Zastrupitev orodij:** Napadalci manipulirajo z metapodatki orodij (kot so opisi ali parametri), da vplivajo na vedenje AI, potencialno obidejo varnostne ukrepe ali iztiskajo podatke. Podrobnosti: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection:** Zlonamerna navodila so vgrajena v dokumente, spletne strani ali e-pošto, ki jih nato obdela AI, kar vodi do uhajanja ali manipulacije podatkov.
- **Dinamične spremembe orodij (Rug Pulls):** Definicije orodij se lahko spremenijo po odobritvi uporabnika, kar uvaja nove zlonamerne vedenja brez vednosti uporabnika.

Te ranljivosti poudarjajo potrebo po robustni validaciji, spremljanju in varnostnih ukrepih pri integraciji MCP strežnikov in orodij v vaše okolje. Za podrobnejši vpogled glejte zgoraj navedene povezave.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.sl.png)

**Posredni prompt injection** (znan tudi kot cross-domain prompt injection ali XPIA) je kritična ranljivost v generativnih AI sistemih, vključno s tistimi, ki uporabljajo Model Context Protocol (MCP). Pri tem napadu so zlonamerna navodila skrita v zunanji vsebini — kot so dokumenti, spletne strani ali e-pošta. Ko AI sistem obdela to vsebino, lahko vgrajena navodila interpretira kot legitimna uporabniška navodila, kar povzroči neželena dejanja, kot so uhajanje podatkov, generiranje škodljive vsebine ali manipulacija uporabniških interakcij. Za podroben opis in primere iz prakse glejte [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Posebej nevarna oblika tega napada je **zastrupitev orodij**. Napadalci v metapodatke MCP orodij (kot so opisi ali parametri) vstavijo zlonamerna navodila. Ker veliki jezikovni modeli (LLM) temeljijo na teh metapodatkih, da odločijo, katera orodja uporabiti, lahko kompromitirani opisi zavajajo model, da izvede nepooblaščene klice orodij ali obide varnostne ukrepe. Te manipulacije so pogosto nevidne končnim uporabnikom, a jih AI sistem lahko interpretira in izvede. To tveganje je še posebej izrazito v gostovanih okoljih MCP strežnikov, kjer se definicije orodij lahko posodobijo po odobritvi uporabnika — scenarij, ki ga včasih imenujejo "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". V takih primerih je orodje, ki je bilo prej varno, lahko kasneje spremenjeno za izvajanje zlonamernih dejanj, kot je iztiskanje podatkov ali spreminjanje vedenja sistema, brez vednosti uporabnika. Za več informacij o tem napadu glejte [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.sl.png)

## Tveganja
Neželeni ukrepi AI predstavljajo različna varnostna tveganja, vključno z iztiskom podatkov in kršitvami zasebnosti.

### Ukrepi za ublažitev
### Uporaba prompt shields za zaščito pred posrednimi napadi prompt injection
-----------------------------------------------------------------------------

**AI Prompt Shields** so rešitev, ki jo je razvil Microsoft za obrambo pred neposrednimi in posrednimi napadi prompt injection. Pomagajo z:

1.  **Zaznavanjem in filtriranjem:** Prompt Shields uporabljajo napredne algoritme strojnega učenja in obdelave naravnega jezika za zaznavanje in filtriranje zlonamernih navodil, vgrajenih v zunanjo vsebino, kot so dokumenti, spletne strani ali e-pošta.
    
2.  **Osvetljevanjem (Spotlighting):** Ta tehnika pomaga AI sistemu razlikovati med veljavnimi sistemskimi navodili in potencialno nezanesljivimi zunanjimi vnosi. S preoblikovanjem vhodnega besedila na način, ki je modelu bolj relevanten, Spotlighting zagotavlja, da AI lažje prepozna in prezre zlonamerna navodila.
    
3.  **Omejevalniki in označevanje podatkov (Delimiters and Datamarking):** Vključevanje omejevalnikov v sistemsko sporočilo jasno označuje lokacijo vhodnega besedila, kar pomaga AI sistemu prepoznati in ločiti uporabniške vnose od potencialno škodljive zunanje vsebine
Varnost dobavne verige ostaja temeljna v dobi umetne inteligence, vendar se je obseg tega, kar šteje kot vaša dobavna veriga, razširil. Poleg tradicionalnih paketov kode morate zdaj dosledno preverjati in nadzorovati vse komponente, povezane z umetno inteligenco, vključno z osnovnimi modeli, storitvami za vdelave, ponudniki konteksta in API-ji tretjih oseb. Vsaka od teh lahko, če ni ustrezno upravljana, prinese ranljivosti ali tveganja.

**Ključne prakse za varnost dobavne verige pri AI in MCP:**
- **Preverite vse komponente pred integracijo:** To vključuje ne le odprtokodne knjižnice, ampak tudi AI modele, podatkovne vire in zunanje API-je. Vedno preverite izvor, licenciranje in znane ranljivosti.
- **Vzdržujte varne postopke uvajanja:** Uporabljajte avtomatizirane CI/CD procese z vgrajenim varnostnim pregledovanjem, da težave odkrijete zgodaj. Poskrbite, da se v produkcijo uvajajo le zaupanja vredni artefakti.
- **Neprestano spremljajte in revidirajte:** Uvedite stalno spremljanje vseh odvisnosti, vključno z modeli in podatkovnimi storitvami, da zaznate nove ranljivosti ali napade na dobavno verigo.
- **Uporabljajte načelo najmanjših privilegijev in nadzor dostopa:** Omejite dostop do modelov, podatkov in storitev le na tisto, kar je nujno potrebno za delovanje vašega MCP strežnika.
- **Hitro ukrepajte ob grožnjah:** Imate vzpostavljen postopek za popravke ali zamenjavo ogroženih komponent ter za rotacijo skrivnosti ali poverilnic, če zaznate vdor.

[GitHub Advanced Security](https://github.com/security/advanced-security) ponuja funkcije, kot so pregledovanje skrivnosti, pregledovanje odvisnosti in analiza CodeQL. Ta orodja se integrirajo z [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) in [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/), da ekipam pomagajo prepoznati in ublažiti ranljivosti tako v kodi kot v komponentah AI dobavne verige.

Microsoft prav tako interno izvaja obsežne prakse varnosti dobavne verige za vse izdelke. Več izveste v [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Uveljavljene varnostne prakse, ki bodo izboljšale varnostno držo vaše MCP implementacije

Vsaka MCP implementacija podeduje obstoječo varnostno držo okolja vaše organizacije, na katerem temelji, zato je priporočljivo, da pri razmišljanju o varnosti MCP kot dela vaših celotnih AI sistemov izboljšate svojo obstoječo varnostno držo. Naslednji uveljavljeni varnostni ukrepi so še posebej pomembni:

-   Najboljše prakse varnega kodiranja v vaši AI aplikaciji – zaščita pred [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 za LLM-je](https://genai.owasp.org/download/43299/?tmstv=1731900559), uporaba varnih trezorjev za skrivnosti in žetone, vzpostavitev varne komunikacije od začetka do konca med vsemi komponentami aplikacije itd.
-   Ojačitev strežnika – kjer je mogoče, uporabite MFA, redno nameščajte popravke, integrirajte strežnik z zunanjim ponudnikom identitete za dostop itd.
-   Redno posodabljajte naprave, infrastrukturo in aplikacije s popravki
-   Varnostno spremljanje – uvedba beleženja in nadzora AI aplikacije (vključno s MCP klienti/strežniki) ter pošiljanje teh dnevnikov v centralni SIEM za zaznavanje nenavadnih aktivnosti
-   Arhitektura ničelnega zaupanja – logično izoliranje komponent z uporabo omrežnih in identitetnih kontrol, da se zmanjša možnost lateralnega premikanja v primeru kompromitacije AI aplikacije.

# Ključne ugotovitve

- Temelji varnosti ostajajo ključni: varno kodiranje, načelo najmanjših privilegijev, preverjanje dobavne verige in neprekinjeno spremljanje so bistveni za MCP in AI delovne obremenitve.
- MCP prinaša nova tveganja – kot so vbrizgavanje pozivov, zastrupitev orodij in pretirane pravice – ki zahtevajo tako tradicionalne kot AI-specifične kontrole.
- Uporabljajte robustne prakse avtentikacije, avtorizacije in upravljanja žetonov, kjer je mogoče zunanji ponudniki identitete, kot je Microsoft Entra ID.
- Zaščitite se pred posrednim vbrizgavanjem pozivov in zastrupitvijo orodij z validacijo metapodatkov orodij, spremljanjem dinamičnih sprememb in uporabo rešitev, kot je Microsoft Prompt Shields.
- Vse komponente v vaši AI dobavni verigi – vključno z modeli, vdelavami in ponudniki konteksta – obravnavajte z enako skrbnostjo kot odvisnosti kode.
- Bodite na tekočem z razvijajočimi se specifikacijami MCP in prispevajte skupnosti za oblikovanje varnih standardov.

# Dodatni viri

- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [Prompt Injection in MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Tool Poisoning Attacks (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls in MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Prompt Shields Documentation (Microsoft)](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Secure Token Storage and Encrypt Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [MCP Security Best Practice](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Naslednje

Naslednje: [Poglavje 3: Začetek](../03-GettingStarted/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za avtomatski prevod AI [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da lahko avtomatski prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.