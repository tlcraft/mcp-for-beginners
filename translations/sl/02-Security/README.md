<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "382fddb4ee4d9c1bdc806e2ee99b70c8",
  "translation_date": "2025-07-17T12:27:14+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "sl"
}
-->
# Najboljše varnostne prakse

Sprejetje Model Context Protocol (MCP) prinaša močne nove zmogljivosti za aplikacije, ki temeljijo na umetni inteligenci, vendar hkrati uvaja tudi edinstvene varnostne izzive, ki presegajo tradicionalna tveganja programske opreme. Poleg uveljavljenih skrbi, kot so varno kodiranje, načelo najmanjših privilegijev in varnost dobavne verige, se MCP in delovne obremenitve AI soočajo z novimi grožnjami, kot so prompt injection, zastrupitev orodij, dinamične spremembe orodij, prevzem sej, napadi confused deputy in ranljivosti pri prenašanju žetonov. Ta tveganja lahko vodijo do iztoka podatkov, kršitev zasebnosti in neželenega vedenja sistema, če niso ustrezno obvladana.

Ta lekcija raziskuje najpomembnejša varnostna tveganja, povezana z MCP — vključno z avtentikacijo, avtorizacijo, prekomernimi dovoljenji, posrednim prompt injection, varnostjo sej, problemi confused deputy, ranljivostmi pri prenašanju žetonov in ranljivostmi dobavne verige — ter ponuja praktične ukrepe in najboljše prakse za njihovo ublažitev. Naučili se boste tudi, kako izkoristiti Microsoftove rešitve, kot so Prompt Shields, Azure Content Safety in GitHub Advanced Security, za krepitev vaše implementacije MCP. Z razumevanjem in uporabo teh ukrepov lahko znatno zmanjšate verjetnost varnostnega incidenta in zagotovite, da vaši AI sistemi ostanejo robustni in zanesljivi.

# Cilji učenja

Do konca te lekcije boste znali:

- Prepoznati in pojasniti edinstvena varnostna tveganja, ki jih uvaja Model Context Protocol (MCP), vključno s prompt injection, zastrupitvijo orodij, prekomernimi dovoljenji, prevzemom sej, problemi confused deputy, ranljivostmi pri prenašanju žetonov in ranljivostmi dobavne verige.
- Opisati in uporabiti učinkovite ukrepe za ublažitev varnostnih tveganj MCP, kot so robustna avtentikacija, načelo najmanjših privilegijev, varno upravljanje žetonov, varnostne kontrole sej in preverjanje dobavne verige.
- Razumeti in izkoristiti Microsoftove rešitve, kot so Prompt Shields, Azure Content Safety in GitHub Advanced Security, za zaščito MCP in AI delovnih obremenitev.
- Prepoznati pomen preverjanja metapodatkov orodij, spremljanja dinamičnih sprememb, obrambe pred posrednimi napadi prompt injection in preprečevanja prevzema sej.
- Vključiti uveljavljene varnostne najboljše prakse — kot so varno kodiranje, utrjevanje strežnikov in arhitektura ničelnega zaupanja — v vašo implementacijo MCP, da zmanjšate verjetnost in vpliv varnostnih kršitev.

# Varnostni ukrepi MCP

Vsak sistem, ki ima dostop do pomembnih virov, prinaša implicitne varnostne izzive. Varnostne izzive je na splošno mogoče rešiti z ustrezno uporabo temeljnih varnostnih ukrepov in konceptov. Ker je MCP šele nedavno definiran, se specifikacija hitro spreminja in se razvija skupaj s protokolom. Sčasoma bodo varnostni ukrepi v njem dozoreli, kar bo omogočilo boljšo integracijo z enterprise in uveljavljenimi varnostnimi arhitekturami ter najboljšimi praksami.

Raziskava, objavljena v [Microsoft Digital Defense Report](https://aka.ms/mddr), navaja, da bi 98 % prijavljenih kršitev preprečila robustna varnostna higiena, najboljša zaščita pred kakršnokoli kršitvijo pa je pravilno izvajanje osnovne varnostne higiene, najboljših praks varnega kodiranja in varnosti dobavne verige — te preizkušene prakse še vedno najbolj vplivajo na zmanjšanje varnostnih tveganj.

Poglejmo si nekaj načinov, kako lahko začnete obravnavati varnostna tveganja pri uvajanju MCP.

> **Note:** Naslednje informacije so veljavne na dan **29. maj 2025**. Protokol MCP se nenehno razvija, prihodnje implementacije pa lahko uvedejo nove vzorce avtentikacije in kontrole. Za najnovejše posodobitve in smernice vedno preverite [MCP Specification](https://spec.modelcontextprotocol.io/) ter uradni [MCP GitHub repozitorij](https://github.com/modelcontextprotocol) in [stran z najboljšimi varnostnimi praksami](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Opis problema  
Izvirna specifikacija MCP je predvidevala, da bodo razvijalci napisali svoj avtentikacijski strežnik. To je zahtevalo znanje o OAuth in povezanih varnostnih omejitvah. MCP strežniki so delovali kot OAuth 2.0 avtorizacijski strežniki, ki so neposredno upravljali potrebno uporabniško avtentikacijo, namesto da bi jo delegirali zunanji storitvi, kot je Microsoft Entra ID. Od **26. aprila 2025** naprej posodobitev specifikacije MCP omogoča, da MCP strežniki delegirajo uporabniško avtentikacijo zunanji storitvi.

### Tveganja
- Napačno konfigurirana avtorizacijska logika v MCP strežniku lahko vodi do razkritja občutljivih podatkov in nepravilno uporabljenih dostopnih kontrol.
- Kraja OAuth žetonov na lokalnem MCP strežniku. Če so žetoni ukradeni, jih lahko napadalec uporabi za ponarejanje MCP strežnika in dostop do virov ter podatkov storitve, za katero je žeton namenjen.

#### Token Passthrough
Prenašanje žetonov je v avtorizacijski specifikaciji izrecno prepovedano, saj prinaša več varnostnih tveganj, med drugim:

#### Obhod varnostnih kontrol
MCP strežnik ali spodnji API-ji lahko izvajajo pomembne varnostne kontrole, kot so omejevanje hitrosti, preverjanje zahtevkov ali spremljanje prometa, ki so odvisne od občinstva žetona ali drugih omejitev poverilnic. Če lahko odjemalci pridobijo in neposredno uporabljajo žetone pri spodnjih API-jih brez ustrezne validacije MCP strežnika ali brez zagotovila, da so žetoni izdani za pravo storitev, obidejo te kontrole.

#### Težave z odgovornostjo in revizijsko sledjo
MCP strežnik ne bo mogel identificirati ali razlikovati med MCP odjemalci, ko ti kličejo z žetonom za dostop, ki ga je izdal zgornji sistem in je za MCP strežnik lahko nejasen.
Dnevniki spodnjega strežnika virov lahko prikazujejo zahtevke, ki se zdijo, kot da prihajajo iz drugega vira z drugačno identiteto, namesto iz MCP strežnika, ki dejansko posreduje žetone.
Oba dejavnika otežujeta preiskavo incidentov, nadzor in revizijo.
Če MCP strežnik posreduje žetone brez preverjanja njihovih trditev (npr. vlog, privilegijev ali občinstva) ali drugih metapodatkov, lahko zlonamerni akter v posesti ukradenega žetona uporabi strežnik kot proxy za iztiskanje podatkov.

#### Težave z mejo zaupanja
Spodnji strežnik virov zaupa določenim entitetam. To zaupanje lahko vključuje predpostavke o izvoru ali vzorcih vedenja odjemalcev. Kršitev te meje zaupanja lahko povzroči nepričakovane težave.
Če žeton sprejema več storitev brez ustrezne validacije, lahko napadalec, ki kompromitira eno storitev, uporabi žeton za dostop do drugih povezanih storitev.

#### Tveganje združljivosti v prihodnosti
Tudi če MCP strežnik danes deluje kot "čisti proxy", bo morda kasneje moral dodati varnostne kontrole. Začetek z ustrezno ločitvijo občinstva žetonov olajša razvoj varnostnega modela.

### Ukrepi za ublažitev

**MCP strežniki NE SMEJO sprejemati nobenih žetonov, ki niso izrecno izdani za MCP strežnik**

- **Preglejte in utrdite avtorizacijsko logiko:** Natančno preglejte implementacijo avtorizacije vašega MCP strežnika, da zagotovite, da do občutljivih virov dostopajo le predvideni uporabniki in odjemalci. Za praktične smernice glejte [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) in [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Uveljavljajte varne prakse za žetone:** Sledite [Microsoftovim najboljšim praksam za validacijo in življenjsko dobo žetonov](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens), da preprečite zlorabo dostopnih žetonov in zmanjšate tveganje ponovne uporabe ali kraje žetonov.
- **Zaščitite shranjevanje žetonov:** Vedno shranjujte žetone varno in uporabljajte šifriranje za zaščito med mirovanjem in prenosom. Za nasvete o implementaciji glejte [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Prekomerna dovoljenja za MCP strežnike

### Opis problema
MCP strežnikom so morda dodeljena prekomerna dovoljenja za storitev/vir, do katerega dostopajo. Na primer, MCP strežnik, ki je del AI prodajne aplikacije, ki se povezuje z enterprise podatkovnim skladiščem, bi moral imeti dostop omejen na prodajne podatke in ne dovoljenje za dostop do vseh datotek v skladišču. Glede na načelo najmanjših privilegijev (eno najstarejših varnostnih načel) noben vir ne bi smel imeti dovoljenj, ki presegajo tisto, kar je potrebno za izvedbo predvidenih nalog. AI predstavlja dodatni izziv, saj je zaradi njene prilagodljivosti težko natančno določiti potrebna dovoljenja.

### Tveganja  
- Dodeljevanje prekomernih dovoljenj lahko omogoči iztiskanje ali spreminjanje podatkov, do katerih MCP strežnik ni smel imeti dostopa. To je lahko tudi vprašanje zasebnosti, če gre za osebne podatke (PII).

### Ukrepi za ublažitev
- **Uporabite načelo najmanjših privilegijev:** MCP strežniku dodelite le najmanjša dovoljenja, potrebna za opravljanje njegovih nalog. Redno pregledujte in posodabljajte ta dovoljenja, da zagotovite, da ne presegajo potrebnega. Za podrobna navodila glejte [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Uporabite nadzor dostopa na osnovi vlog (RBAC):** Dodelite vloge MCP strežniku, ki so strogo omejene na določene vire in dejanja, ter se izogibajte širokim ali nepotrebnim dovoljenjem.
- **Spremljajte in revidirajte dovoljenja:** Neprestano spremljajte uporabo dovoljenj in pregledujte dnevnike dostopa, da hitro odkrijete in odpravite prekomerna ali neuporabljena dovoljenja.

# Posredni napadi prompt injection

### Opis problema

Zlonamerni ali kompromitirani MCP strežniki lahko povzročijo resna tveganja z razkritjem podatkov strank ali omogočanjem neželenih dejanj. Ta tveganja so še posebej pomembna pri AI in delovnih obremenitvah, ki temeljijo na MCP, kjer:

- **Napadi prompt injection:** Napadalci vstavijo zlonamerna navodila v pozive ali zunanjo vsebino, zaradi česar AI sistem izvede neželena dejanja ali razkrije občutljive podatke. Več: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Zastrupitev orodij:** Napadalci manipulirajo z metapodatki orodij (kot so opisi ali parametri), da vplivajo na vedenje AI, kar lahko zaobide varnostne kontrole ali povzroči iztiskanje podatkov. Podrobnosti: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection:** Zlonamerna navodila so vgrajena v dokumente, spletne strani ali e-pošto, ki jih nato obdela AI, kar vodi do uhajanja ali manipulacije podatkov.
- **Dinamične spremembe orodij (Rug Pulls):** Definicije orodij se lahko spremenijo po odobritvi uporabnika, kar uvaja nove zlonamerne vedenja brez vednosti uporabnika.

Te ranljivosti poudarjajo potrebo po robustni validaciji, spremljanju in varnostnih kontrolah pri integraciji MCP strežnikov in orodij v vaše okolje. Za poglobljeno razumevanje si oglejte zgoraj navedene povezave.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.sl.png)

**Posredni prompt injection** (znan tudi kot cross-domain prompt injection ali XPIA) je kritična ranljivost v generativnih AI sistemih, vključno s tistimi, ki uporabljajo Model Context Protocol (MCP). Pri tem napadu so zlonamerna navodila skrita v zunanji vsebini — kot so dokumenti, spletne strani ali e-pošta. Ko AI sistem obdela to vsebino, lahko vgrajena navodila interpretira kot legitimna uporabniška ukaza, kar povzroči neželena dejanja, kot so uhajanje podatkov, generiranje škodljive vsebine ali manipulacija uporabniških interakcij. Za podroben opis in primere iz prakse glejte [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Posebej nevaren je napad **Tool Poisoning**. Napadalci v metapodatke MCP orodij (kot so opisi ali parametri) vstavijo zlonamerna navodila. Ker veliki jezikovni modeli (LLM) temeljijo na teh metapodatkih, da odločijo, katera orodja uporabiti, lahko kompromitirani opisi zavajajo model, da izvede nepooblaščene klice orodij ali zaobide varnostne kontrole. Te manipulacije so pogosto nevidne končnim uporabnikom, a jih AI sistem lahko interpretira in izvede. To tveganje je še posebej izrazito v gostovanih MCP strežniških okoljih, kjer se definicije orodij lahko posodobijo po odobritvi uporabnika — scenarij, ki ga včasih imenujejo "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". V takih primerih je orodje, ki je bilo prej varno, lahko kasneje spremenjeno za izvajanje zlonamernih dejanj, kot je iztiskanje podatkov ali spreminjanje vedenja sistema, brez vednosti uporabnika. Za več informacij o tem napadu glejte [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.sl.png)

## Tveganja
Neželeni AI ukrepi predstavljajo različna varnostna tveganja, vključno z iztiskanjem podatkov in kršitvami zasebnosti.

### Ukrepi za ublažitev
### Uporaba prompt shields za zaščito pred posrednimi napadi prompt injection
-----------------------------------------------------------------------------

**AI Prompt Shields** so rešitev, ki jo je razvil Microsoft za obrambo pred neposrednimi in posrednimi napadi prompt injection. Pomagajo z:

1.  **Zaznavanjem in filtriranjem:** Prompt Shields uporabljajo napredne algoritme strojnega učenja in obdelave naravnega jezika za zaznavanje in filtriranje zlonamernih navodil, vgrajenih v zunanjo vsebino, kot so dokumenti, spletne strani ali e-pošta.
    
2.  **Spotlighting:** Ta tehnika pomaga AI sistemu razlikovati med veljavnimi sistemskimi navodili in potencialno nezanesljivimi zunanjimi vnosi. S preoblikovanjem vhodnega besedila na način, ki je modelu bolj relevanten, Spotlighting zagotavlja, da AI lažje prepozna in prezre zlonamerna navodila.
    
3.  **Omejevalniki in označevanje podatkov:** Vključevanje omejevalnikov
Problem z zmedenim namestnikom je varnostna ranljivost, ki nastane, ko MCP strežnik deluje kot posrednik med MCP odjemalci in API-ji tretjih oseb. To ranljivost je mogoče izkoristiti, kadar MCP strežnik uporablja statični ID odjemalca za avtentikacijo pri strežniku za avtorizacijo tretje osebe, ki ne podpira dinamične registracije odjemalcev.

### Tveganja

- **Obhod soglasja na podlagi piškotkov**: Če se je uporabnik že prej avtenticiral prek MCP proxy strežnika, lahko strežnik za avtorizacijo tretje osebe nastavi piškotek soglasja v uporabnikovem brskalniku. Napadalec lahko to kasneje izkoristi tako, da uporabniku pošlje zlonamerno povezavo z izdelanim zahtevkom za avtorizacijo, ki vsebuje zlonamerni URI za preusmeritev.
- **Kraja avtorizacijskih kod**: Ko uporabnik klikne zlonamerno povezavo, lahko strežnik za avtorizacijo tretje osebe zaradi obstoječega piškotka preskoči zaslon za soglasje, avtorizacijska koda pa se lahko preusmeri na strežnik napadalca.
- **Neavtoriziran dostop do API-ja**: Napadalec lahko ukradeno avtorizacijsko kodo zamenja za dostopne žetone in se pretvarja, da je uporabnik, ter tako dostopa do API-ja tretje osebe brez izrecnega dovoljenja.

### Ukrepi za zmanjšanje tveganj

- **Zahteve po izrecnem soglasju**: MCP proxy strežniki, ki uporabljajo statične ID-je odjemalcev, **MORAJO** pridobiti soglasje uporabnika za vsakega dinamično registriranega odjemalca, preden posredujejo zahtevke strežnikom za avtorizacijo tretjih oseb.
- **Pravilna implementacija OAuth**: Upoštevajte varnostne najboljše prakse OAuth 2.1, vključno z uporabo izzivov kode (PKCE) za avtorizacijske zahtevke, da preprečite prestrezalne napade.
- **Validacija odjemalcev**: Uvedite strogo preverjanje URI-jev za preusmeritev in identifikatorjev odjemalcev, da preprečite zlorabe s strani zlonamernih akterjev.


# Ranljivosti pri posredovanju žetonov

### Opis problema

"Posredovanje žetonov" je napačen vzorec, kjer MCP strežnik sprejema žetone od MCP odjemalca, ne da bi preveril, ali so bili ti žetoni pravilno izdani prav za MCP strežnik, nato pa jih "posreduje" naprej do nižjih API-jev. Ta praksa izrecno krši specifikacijo avtorizacije MCP in prinaša resna varnostna tveganja.

### Tveganja

- **Obhod varnostnih kontrol**: Odjemalci lahko zaobidejo pomembne varnostne kontrole, kot so omejevanje hitrosti, preverjanje zahtevkov ali nadzor prometa, če lahko žetone neposredno uporabljajo z nižjimi API-ji brez ustrezne validacije.
- **Težave z odgovornostjo in revizijsko sledjo**: MCP strežnik ne bo mogel identificirati ali razlikovati med MCP odjemalci, ko ti uporabljajo dostopne žetone, izdane zgoraj, kar otežuje preiskave incidentov in revizijo.
- **Izvoz podatkov**: Če se žetoni posredujejo brez ustrezne validacije trditev, lahko zlonamerni akter z ukradenim žetonom uporabi strežnik kot posrednika za izvoz podatkov.
- **Kršenje meja zaupanja**: Strežniki virov na nižji ravni lahko zaupajo določenim entitetam na podlagi predpostavk o izvoru ali vzorcih vedenja. Kršitev te meje zaupanja lahko povzroči nepričakovane varnostne težave.
- **Zloraba žetonov v več storitvah**: Če žetoni veljajo za več storitev brez ustrezne validacije, lahko napadalec, ki kompromitira eno storitev, uporabi žeton za dostop do drugih povezanih storitev.

### Ukrepi za zmanjšanje tveganj

- **Validacija žetonov**: MCP strežniki **NE SMEJO** sprejemati žetonov, ki niso izrecno izdani za MCP strežnik.
- **Preverjanje občinstva**: Vedno preverite, ali imajo žetoni pravilno trditev o občinstvu, ki ustreza identiteti MCP strežnika.
- **Pravilno upravljanje življenjskega cikla žetonov**: Uvedite kratkotrajne dostopne žetone in ustrezne prakse rotacije žetonov, da zmanjšate tveganje kraje in zlorabe žetonov.


# Prevzemanje sej

### Opis problema

Prevzemanje sej je napad, kjer strežnik odjemalcu dodeli ID seje, nepooblaščena oseba pa pridobi in uporabi isti ID seje, da se pretvarja, da je izvirni odjemalec, ter izvaja nepooblaščene akcije v njegovem imenu. To je še posebej zaskrbljujoče pri stanjevnih HTTP strežnikih, ki obravnavajo MCP zahtevke.

### Tveganja

- **Vbrizgavanje zlonamernih dogodkov prek prevzema seje**: Napadalec, ki pridobi ID seje, lahko pošlje zlonamerne dogodke strežniku, ki deli stanje seje s strežnikom, s katerim je odjemalec povezan, kar lahko sproži škodljive akcije ali dostop do občutljivih podatkov.
- **Prevzemanje identitete prek seje**: Napadalec z ukradenim ID-jem seje lahko neposredno kliče MCP strežnik, zaobide avtentikacijo in je obravnavan kot legitimni uporabnik.
- **Kompromitirani nadaljevalni tokovi**: Ko strežnik podpira ponovno dostavo/nadaljevalne tokove, lahko napadalec predčasno prekine zahtevek, ki ga nato izvirni odjemalec nadaljuje z morebitno zlonamerno vsebino.

### Ukrepi za zmanjšanje tveganj

- **Preverjanje avtorizacije**: MCP strežniki, ki izvajajo avtorizacijo, **MORAJO** preveriti vse dohodne zahtevke in **NE SMEJO** uporabljati sej za avtentikacijo.
- **Varnostni ID-ji sej**: MCP strežniki **MORAJO** uporabljati varne, nedeterministične ID-je sej, ustvarjene z varnimi generatorji naključnih števil. Izogibajte se predvidljivim ali zaporednim identifikatorjem.
- **Povezava sej z uporabnikom**: MCP strežniki **NAJ BI** povezali ID-je sej z informacijami, specifičnimi za uporabnika, tako da združijo ID seje z edinstvenimi podatki o pooblaščenem uporabniku (npr. njihov notranji ID uporabnika) v formatu `
<user_id>:<session_id>`.
- **Potek seje**: Uvedite ustrezno potekanje in rotacijo sej, da omejite čas ranljivosti, če je ID seje kompromitiran.
- **Varnost prenosa**: Vedno uporabljajte HTTPS za vso komunikacijo, da preprečite prestrezanje ID-jev sej.


# Varnost dobavne verige

Varnost dobavne verige ostaja temeljna v dobi umetne inteligence, vendar se je obseg tega, kar šteje kot vaša dobavna veriga, razširil. Poleg tradicionalnih paketov kode morate zdaj strogo preverjati in nadzorovati vse komponente, povezane z AI, vključno z osnovnimi modeli, storitvami vdelav, ponudniki konteksta in API-ji tretjih oseb. Vsaka od teh lahko prinese ranljivosti ali tveganja, če ni ustrezno upravljana.

**Ključne prakse varnosti dobavne verige za AI in MCP:**
- **Preverite vse komponente pred integracijo:** To vključuje ne le odprtokodne knjižnice, ampak tudi AI modele, vire podatkov in zunanje API-je. Vedno preverite izvor, licenciranje in znane ranljivosti.
- **Vzdržujte varne procese uvajanja:** Uporabljajte avtomatizirane CI/CD procese z integriranim varnostnim pregledom, da težave odkrijete zgodaj. Poskrbite, da se v produkcijo uvajajo le zaupanja vredni artefakti.
- **Neprestano spremljajte in revidirajte:** Uvedite stalno spremljanje vseh odvisnosti, vključno z modeli in podatkovnimi storitvami, da zaznate nove ranljivosti ali napade na dobavno verigo.
- **Uporabljajte načelo najmanjših privilegijev in nadzor dostopa:** Omejite dostop do modelov, podatkov in storitev le na tisto, kar je potrebno za delovanje vašega MCP strežnika.
- **Hitra odzivnost na grožnje:** Imate vzpostavljen postopek za popravke ali zamenjavo kompromitiranih komponent ter za rotacijo skrivnosti ali poverilnic, če je zaznan vdor.

[GitHub Advanced Security](https://github.com/security/advanced-security) ponuja funkcije, kot so pregled skrivnosti, pregled odvisnosti in analiza CodeQL. Ta orodja se integrirajo z [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) in [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/), da ekipam pomagajo prepoznati in ublažiti ranljivosti tako v kodi kot v komponentah AI dobavne verige.

Microsoft prav tako interno izvaja obsežne prakse varnosti dobavne verige za vse izdelke. Več si preberite v [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Uveljavljene varnostne najboljše prakse za izboljšanje varnostnega stanja vaše MCP implementacije

Vsaka MCP implementacija podeduje obstoječe varnostno stanje okolja vaše organizacije, na katerem temelji, zato je priporočljivo, da pri razmišljanju o varnosti MCP kot sestavnega dela vaših AI sistemov izboljšate tudi splošno obstoječe varnostno stanje. Naslednji uveljavljeni varnostni ukrepi so še posebej pomembni:

- Najboljše prakse varnega kodiranja v vaši AI aplikaciji – zaščita pred [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 za LLM](https://genai.owasp.org/download/43299/?tmstv=1731900559), uporaba varnih shramb za skrivnosti in žetone, izvajanje varne komunikacije od konca do konca med vsemi komponentami aplikacije itd.
- Krepitev strežnika – kjer je mogoče, uporabite MFA, redno nameščajte popravke, integrirajte strežnik s ponudnikom identitete tretje osebe za dostop itd.
- Posodabljanje naprav, infrastrukture in aplikacij z najnovejšimi popravki
- Varnostno spremljanje – uvedba beleženja in nadzora AI aplikacije (vključno z MCP odjemalci/strežniki) ter pošiljanje teh dnevnikov v centralni SIEM za zaznavanje nenavadnih dejavnosti
- Arhitektura ničelnega zaupanja – izolacija komponent z uporabo omrežnih in identitetnih kontrol na logičen način za zmanjšanje lateralnega premikanja v primeru kompromitacije AI aplikacije.

# Ključne ugotovitve

- Temelji varnosti ostajajo ključni: varno kodiranje, načelo najmanjših privilegijev, preverjanje dobavne verige in neprekinjeno spremljanje so bistveni za MCP in AI delovne obremenitve.
- MCP prinaša nova tveganja – kot so vbrizgavanje ukazov, zastrupitev orodij, prevzemanje sej, problem z zmedenim namestnikom, ranljivosti pri posredovanju žetonov in prekomerne pravice – ki zahtevajo tako tradicionalne kot AI-specifične ukrepe.
- Uporabljajte robustne prakse avtentikacije, avtorizacije in upravljanja žetonov, pri čemer po potrebi izkoristite zunanje ponudnike identitete, kot je Microsoft Entra ID.
- Zaščitite se pred posrednim vbrizgavanjem ukazov in zastrupitvijo orodij z validacijo metapodatkov orodij, spremljanjem dinamičnih sprememb in uporabo rešitev, kot je Microsoft Prompt Shields.
- Uvedite varno upravljanje sej z uporabo nedeterminističnih ID-jev sej, povezovanjem sej z identitetami uporabnikov in nikoli ne uporabljajte sej za avtentikacijo.
- Preprečite napade z zmedenim namestnikom z zahtevami po izrecnem soglasju uporabnika za vsakega dinamično registriranega odjemalca in z ustreznimi varnostnimi praksami OAuth.
- Izogibajte se ranljivostim pri posredovanju žetonov tako, da MCP strežniki sprejemajo le žetone, ki so izrecno izdani zanje, in ustrezno validirajo trditve žetonov.
- Vse komponente v vaši AI dobavni verigi – vključno z modeli, vdelavami in ponudniki konteksta – obravnavajte z enako skrbnostjo kot odvisnosti kode.
- Bodite na tekočem z razvijajočimi se specifikacijami MCP in prispevajte k skupnosti za oblikovanje varnih standardov.

# Dodatni viri

## Zunanji viri
- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
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
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

## Dodatni varnostni dokumenti

Za podrobnejša varnostna navodila si oglejte naslednje dokumente:

- [MCP Security Best Practices 2025](./mcp-security-best-practices-2025.md) - Celovit seznam varnostnih najboljših praks za MCP implementacije
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md) - Primeri implementacije za integracijo Azure Content Safety z MCP strežniki
- [MCP Security Controls 2025](./mcp-security-controls-2025.md) - Najnovejši varnostni ukrepi in tehnike za varovanje MCP okolij
- [MCP Best Practices](./mcp-best-practices.md) - Hitri referenčni vodič za varnost MCP

### Naslednje

Naslednje: [Poglavje 3: Začetek](../03-GettingStarted/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.