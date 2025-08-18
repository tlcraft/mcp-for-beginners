<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1c767a35642f753127dc08545c25a290",
  "translation_date": "2025-08-18T17:51:15+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "sl"
}
-->
# MCP Varnost: Celovita zaščita za AI sisteme

[![MCP Varnostne Prakse](../../../translated_images/03.175aed6dedae133f9d41e49cefd0f0a9a39c3317e1eaa7ef7182696af7534308.sl.png)](https://youtu.be/88No8pw706o)

_(Kliknite na zgornjo sliko za ogled videa te lekcije)_

Varnost je temeljni del oblikovanja AI sistemov, zato ji namenjamo drugo poglavje. To je v skladu z Microsoftovim načelom **Secure by Design** iz [Secure Future Initiative](https://www.microsoft.com/security/blog/2025/04/17/microsofts-secure-by-design-journey-one-year-of-success/).

Model Context Protocol (MCP) prinaša zmogljive nove zmožnosti za aplikacije, ki temeljijo na AI, hkrati pa uvaja edinstvene varnostne izzive, ki presegajo tradicionalna programska tveganja. MCP sistemi se soočajo tako z uveljavljenimi varnostnimi skrbmi (varno kodiranje, najmanjše privilegije, varnost dobavne verige) kot z novimi, specifičnimi grožnjami za AI, kot so vbrizgavanje ukazov, zastrupitev orodij, ugrabitev sej, napadi z zmedenim namestnikom, ranljivosti pri prenosu žetonov in dinamične spremembe zmogljivosti.

Ta lekcija raziskuje najpomembnejša varnostna tveganja pri implementacijah MCP—vključno z avtentikacijo, avtorizacijo, prekomernimi dovoljenji, posrednim vbrizgavanjem ukazov, varnostjo sej, težavami z zmedenim namestnikom, upravljanjem žetonov in ranljivostmi dobavne verige. Naučili se boste praktičnih ukrepov in najboljših praks za zmanjšanje teh tveganj ter uporabe Microsoftovih rešitev, kot so Prompt Shields, Azure Content Safety in GitHub Advanced Security, za krepitev vaše MCP implementacije.

## Cilji učenja

Do konca te lekcije boste sposobni:

- **Prepoznati MCP-specifične grožnje**: Identificirati edinstvena varnostna tveganja v MCP sistemih, vključno z vbrizgavanjem ukazov, zastrupitvijo orodij, prekomernimi dovoljenji, ugrabitev sej, težavami z zmedenim namestnikom, ranljivostmi pri prenosu žetonov in tveganji dobavne verige
- **Uporabiti varnostne ukrepe**: Implementirati učinkovite ukrepe, vključno z robustno avtentikacijo, dostopom z najmanjšimi privilegiji, varnim upravljanjem žetonov, nadzorom varnosti sej in preverjanjem dobavne verige
- **Izkoristiti Microsoftove varnostne rešitve**: Razumeti in uporabiti Microsoft Prompt Shields, Azure Content Safety in GitHub Advanced Security za zaščito MCP delovnih obremenitev
- **Preveriti varnost orodij**: Prepoznati pomen validacije metapodatkov orodij, spremljanja dinamičnih sprememb in obrambe pred posrednimi napadi z vbrizgavanjem ukazov
- **Integrirati najboljše prakse**: Združiti uveljavljene varnostne temelje (varno kodiranje, utrjevanje strežnikov, ničelno zaupanje) z MCP-specifičnimi ukrepi za celovito zaščito

# MCP Varnostna arhitektura in ukrepi

Sodobne MCP implementacije zahtevajo večplastne varnostne pristope, ki obravnavajo tako tradicionalne varnostne grožnje programske opreme kot specifične grožnje za AI. Hitro razvijajoča se specifikacija MCP še naprej izboljšuje svoje varnostne ukrepe, kar omogoča boljšo integracijo z varnostnimi arhitekturami podjetij in uveljavljenimi najboljšimi praksami.

Raziskave iz [Microsoft Digital Defense Report](https://aka.ms/mddr) kažejo, da bi **98 % prijavljenih kršitev preprečila robustna varnostna higiena**. Najbolj učinkovita strategija zaščite združuje osnovne varnostne prakse z MCP-specifičnimi ukrepi—dokazane osnovne varnostne ukrepe ostajajo najbolj vplivni pri zmanjševanju celotnega varnostnega tveganja.

## Trenutna varnostna pokrajina

> **Note:** Te informacije odražajo MCP varnostne standarde na dan **18. avgust 2025**. Specifikacija MCP se hitro razvija, prihodnje implementacije pa lahko uvedejo nove vzorce avtentikacije in izboljšane ukrepe. Vedno se sklicujte na trenutno [MCP Specifikacijo](https://spec.modelcontextprotocol.io/), [MCP GitHub repozitorij](https://github.com/modelcontextprotocol) in [dokumentacijo najboljših varnostnih praks](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices) za najnovejše smernice.

### Razvoj MCP avtentikacije

Specifikacija MCP se je bistveno razvila v svojem pristopu k avtentikaciji in avtorizaciji:

- **Prvotni pristop**: Zgodnje specifikacije so zahtevale, da razvijalci implementirajo prilagojene strežnike za avtentikacijo, pri čemer so MCP strežniki delovali kot OAuth 2.0 strežniki za avtorizacijo, ki neposredno upravljajo avtentikacijo uporabnikov
- **Trenutni standard (2025-06-18)**: Posodobljena specifikacija omogoča MCP strežnikom delegiranje avtentikacije zunanjim ponudnikom identitete (kot je Microsoft Entra ID), kar izboljšuje varnostno držo in zmanjšuje kompleksnost implementacije
- **Transportna varnost**: Izboljšana podpora za varne transportne mehanizme z ustreznimi vzorci avtentikacije za lokalne (STDIO) in oddaljene (Streamable HTTP) povezave

## Varnost avtentikacije in avtorizacije

### Trenutni varnostni izzivi

Sodobne MCP implementacije se soočajo z več izzivi pri avtentikaciji in avtorizaciji:

### Tveganja in vektorji groženj

- **Napačno konfigurirana logika avtorizacije**: Slaba implementacija avtorizacije v MCP strežnikih lahko izpostavi občutljive podatke in nepravilno uporabi nadzore dostopa
- **Kompromis OAuth žetonov**: Kraja lokalnih žetonov MCP strežnika omogoča napadalcem, da se predstavljajo kot strežniki in dostopajo do storitev
- **Ranljivosti pri prenosu žetonov**: Nepravilno ravnanje z žetoni ustvarja obvode varnostnih ukrepov in vrzeli v odgovornosti
- **Prekomerna dovoljenja**: Preveč privilegirani MCP strežniki kršijo načelo najmanjših privilegijev in širijo površino napada

#### Prenos žetonov: Kritični anti-vzorec

**Prenos žetonov je izrecno prepovedan** v trenutni specifikaciji MCP avtorizacije zaradi resnih varnostnih posledic:

##### Obvodi varnostnih ukrepov
- MCP strežniki in API-ji navzdol izvajajo ključne varnostne ukrepe (omejevanje hitrosti, validacija zahtevkov, spremljanje prometa), ki so odvisni od pravilne validacije žetonov
- Neposredna uporaba žetonov odjemalca do API-ja obide te bistvene zaščite, kar ogroža varnostno arhitekturo

##### Izzivi odgovornosti in revizije  
- MCP strežniki ne morejo razlikovati med odjemalci, ki uporabljajo žetone, izdane navzgor, kar prekine revizijske sledi
- Dnevniki strežnikov virov navzdol prikazujejo zavajajoče izvore zahtevkov namesto dejanskih posrednikov MCP strežnikov
- Preiskave incidentov in skladnostne revizije postanejo bistveno težje

##### Tveganja iztoka podatkov
- Nevalidirane trditve žetonov omogočajo zlonamernim akterjem s ukradenimi žetoni uporabo MCP strežnikov kot proxy za iztok podatkov
- Kršitve meja zaupanja omogočajo nepooblaščene vzorce dostopa, ki obidejo predvidene varnostne ukrepe

##### Vektorji napadov na več storitev
- Kompromitirani žetoni, ki jih sprejema več storitev, omogočajo lateralno gibanje po povezanih sistemih
- Predpostavke zaupanja med storitvami so lahko kršene, ko izvor žetonov ni mogoče preveriti

### Varnostni ukrepi in omilitve

**Ključne varnostne zahteve:**

> **OBVEZNO**: MCP strežniki **NE SMEJO** sprejeti nobenih žetonov, ki niso bili izrecno izdani za MCP strežnik

#### Ukrepi za avtentikacijo in avtorizacijo

- **Temeljit pregled avtorizacije**: Izvedite celovite revizije logike avtorizacije MCP strežnika, da zagotovite, da lahko občutljive vire dostopajo le predvideni uporabniki in odjemalci
  - **Vodnik za implementacijo**: [Azure API Management kot prehod za avtentikacijo MCP strežnikov](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
  - **Integracija identitete**: [Uporaba Microsoft Entra ID za avtentikacijo MCP strežnikov](https://den.dev/blog/mcp-server-auth-entra-id-session/)

- **Varno upravljanje žetonov**: Implementirajte [Microsoftove najboljše prakse za validacijo žetonov in življenjski cikel](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens)
  - Validirajte trditve občinstva žetonov, da se ujemajo z identiteto MCP strežnika
  - Implementirajte pravilne politike rotacije in poteka žetonov
  - Preprečite napade ponovnega predvajanja žetonov in nepooblaščeno uporabo

- **Zaščitena hramba žetonov**: Varna hramba žetonov z enkripcijo tako v mirovanju kot med prenosom
  - **Najboljše prakse**: [Smernice za varno hrambo žetonov in enkripcijo](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

#### Implementacija nadzora dostopa

- **Načelo najmanjših privilegijev**: MCP strežnikom dodelite le minimalna dovoljenja, potrebna za predvideno funkcionalnost
  - Redni pregledi dovoljenj in posodobitve za preprečevanje kopičenja privilegijev
  - **Microsoft Dokumentacija**: [Varno dostopanje z najmanjšimi privilegiji](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)

- **Nadzor dostopa na podlagi vlog (RBAC)**: Implementirajte natančno določene dodelitve vlog
  - Omejite vloge na specifične vire in dejanja
  - Izogibajte se širokim ali nepotrebnim dovoljenjem, ki širijo površino napada

- **Nenehno spremljanje dovoljenj**: Implementirajte stalno revizijo in spremljanje dostopa
  - Spremljajte vzorce uporabe dovoljenj za anomalije
  - Hitro odpravite prekomerne ali neuporabljene privilegije

## Specifične varnostne grožnje za AI

### Napadi z vbrizgavanjem ukazov in manipulacijo orodij

Sodobne MCP implementacije se soočajo s sofisticiranimi napadi, specifičnimi za AI, ki jih tradicionalni varnostni ukrepi ne morejo v celoti obravnavati:

#### **Posredno vbrizgavanje ukazov (Cross-Domain Prompt Injection)**

**Posredno vbrizgavanje ukazov** predstavlja eno najkritičnejših ranljivosti v MCP omogočenih AI sistemih. Napadalci vgradijo zlonamerna navodila v zunanjo vsebino—dokumente, spletne strani, e-pošto ali podatkovne vire—ki jih AI sistemi nato obravnavajo kot legitimne ukaze.

**Scenariji napadov:**
- **Vbrizgavanje na podlagi dokumentov**: Zlonamerna navodila, skrita v obdelanih dokumentih, ki sprožijo nenamerna dejanja AI
- **Izkoriščanje spletne vsebine**: Kompromitirane spletne strani z vgrajenimi ukazi, ki manipulirajo z vedenjem AI ob strganju
- **Napadi na podlagi e-pošte**: Zlonamerna navodila v e-poštah, ki povzročijo uhajanje informacij ali izvajanje nepooblaščenih dejanj
- **Kontaminacija podatkovnih virov**: Kompromitirane baze podatkov ali API-ji, ki strežejo okuženo vsebino AI sistemom

**Vpliv v resničnem svetu**: Ti napadi lahko povzročijo uhajanje podatkov, kršitve zasebnosti, generiranje škodljive vsebine in manipulacijo uporabniških interakcij. Za podrobno analizo glejte [Prompt Injection v MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

![Diagram napada z vbrizgavanjem ukazov](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.sl.png)

#### **Napadi z zastrupitvijo orodij**

**Zastrupitev orodij** cilja na metapodatke, ki definirajo MCP orodja, izkoriščajoč način, kako LLM interpretirajo opise orodij in parametre za sprejemanje odločitev o izvajanju.

**Mehanizmi napadov:**
- **Manipulacija metapodatkov**: Napadalci vbrizgajo zlonamerna navodila v opise orodij, definicije parametrov ali primere uporabe
- **Nevidna navodila**: Skrita navodila v metapodatkih orodij, ki jih obdelujejo AI modeli, a so nevidna človeškim uporabnikom
- **Dinamična sprememba orodij ("Rug Pulls")**: Orodja, ki jih uporabniki odobrijo, se kasneje spremenijo, da izvajajo zlonamerna dejanja brez zavedanja uporabnikov
- **Vbrizgavanje parametrov**: Zlonamerna vsebina, vgrajena v sheme parametrov orodij, ki vpliva na vedenje modela

**Tveganja gostovanih strežnikov**: Oddaljeni MCP strežniki predstavljajo povečana tveganja, saj se definicije orodij lahko posodobijo po začetni odobritvi uporabnika, kar ustvarja scenarije, kjer prej varna orodja postanejo zlonamerna. Za celovito analizo glejte [Napadi z zastrupitvijo orodij (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![Diagram napada z vbrizgavanjem orodij](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.sl.png)

#### **Dodatni vektorji napadov na AI**

- **Posredno vbrizgavanje ukazov med domenami (XPIA)**: Sofisticirani napadi, ki izkoriščajo vsebino iz več domen za obhod varnostnih ukrepov
- **Dinamična sprememba zmogljivosti**: Spremembe zmogljivosti orodij v realnem času, ki uidejo začetnim varnostnim ocenam
- **Zastrupitev kontekstnega okna**: Napadi, ki manipulirajo z velikimi kontekstnimi okni za skrivanje zlonamernih navodil
- **Napadi z zmedenjem modela**: Izkoriščanje omejitev modela za ustvarjanje nepredvidenega ali nevarnega vedenja

### Vpliv varnostnih tveganj za AI

**Posledice z visokim vplivom:**
- **Uhajanje podatkov**: Nepooblaščen dostop in kraja občutljivih podatkov podjetja ali osebnih podatkov
- **Kršitve zasebnosti**: Izpostavitev osebno prepoznavnih informacij (PII) in zaupnih poslovnih podatkov  
- **Manipulacija sistemov**: Nenamerne spremembe kritičnih sistemov in delovnih tokov
- **Kraja poverilnic**: Kompromitacija avtentikacijskih žetonov in poverilnic storitev
- **Lateralno gibanje**: Uporaba kompromitiranih AI sistemov kot izhodišč za širše napade na omrežje

### Microsoftove varnostne rešitve za AI

#### **AI Prompt Shields: Napredna zaščita pred napadi z vbrizgavanjem ukazov**

Microsoft **AI Prompt Shields** zagotavljajo celovito obrambo pred neposrednimi in posrednimi napadi z vbrizgavanjem ukazov prek več varnostnih slojev:

##### **Osnovni mehanizmi zaščite:**

1. **Napredno zaznavanje in filtriranje**
  
- **Varno ustvarjanje sej**: Uporabljajte kriptografsko varne, nedeterministične ID-je sej, ustvarjene z varnimi generatorji naključnih števil  
- **Vezava na uporabnika**: Povežite ID-je sej z uporabniškimi informacijami v formatu, kot je `<user_id>:<session_id>`, da preprečite zlorabo sej med uporabniki  
- **Upravljanje življenjskega cikla sej**: Uvedite pravilno potekanje, rotacijo in preklic sej za omejitev ranljivosti  
- **Varnost prenosa**: Obvezna uporaba HTTPS za vso komunikacijo, da preprečite prestrezanje ID-jev sej  

### Problem zmedenega namestnika

**Problem zmedenega namestnika** se pojavi, ko strežniki MCP delujejo kot avtentikacijski posredniki med odjemalci in storitvami tretjih oseb, kar omogoča obvode avtorizacije z izkoriščanjem statičnih ID-jev odjemalcev.

#### **Mehanika napada in tveganja**

- **Obvod privolitve na osnovi piškotkov**: Prejšnja avtentikacija uporabnika ustvari piškotke za privolitev, ki jih napadalci izkoriščajo z zlonamernimi zahtevami za avtorizacijo in prirejenimi preusmeritvenimi URI-ji  
- **Kraja avtorizacijskih kod**: Obstoječi piškotki za privolitev lahko povzročijo, da strežniki za avtorizacijo preskočijo zaslone za privolitev in preusmerijo kode na končne točke pod nadzorom napadalcev  
- **Neavtoriziran dostop do API-jev**: Ukradene avtorizacijske kode omogočajo izmenjavo žetonov in posnemanje uporabnikov brez izrecne odobritve  

#### **Strategije za zmanjšanje tveganj**

**Obvezni ukrepi:**
- **Zahteva po izrecni privolitvi**: Proxy strežniki MCP, ki uporabljajo statične ID-je odjemalcev, **MORAJO** pridobiti uporabniško privolitev za vsakega dinamično registriranega odjemalca  
- **Implementacija varnosti OAuth 2.1**: Upoštevajte trenutne najboljše prakse varnosti OAuth, vključno s PKCE (Proof Key for Code Exchange) za vse zahteve za avtorizacijo  
- **Stroga validacija odjemalcev**: Uvedite strogo preverjanje preusmeritvenih URI-jev in identifikatorjev odjemalcev, da preprečite zlorabe  

### Ranljivosti pri posredovanju žetonov  

**Posredovanje žetonov** predstavlja očiten antipattern, kjer strežniki MCP sprejemajo žetone odjemalcev brez ustrezne validacije in jih posredujejo navzdol API-jem, kar krši specifikacije avtorizacije MCP.

#### **Varnostne posledice**

- **Obhod nadzora**: Neposredna uporaba žetonov odjemalcev za API-je obide ključne omejitve hitrosti, validacijo in nadzorne ukrepe  
- **Izkrivljanje revizijskih sledi**: Žetoni, izdani navzgor, onemogočajo identifikacijo odjemalcev, kar otežuje preiskave incidentov  
- **Izvlečenje podatkov prek proxyja**: Nevalidirani žetoni omogočajo zlonamernim akterjem uporabo strežnikov kot proxyjev za neavtoriziran dostop do podatkov  
- **Kršitve meja zaupanja**: Predpostavke zaupanja storitev navzdol so lahko kršene, ko izvor žetonov ni mogoče preveriti  
- **Razširitev napadov na več storitev**: Kompromitirani žetoni, sprejeti v več storitvah, omogočajo lateralno premikanje  

#### **Zahtevani varnostni ukrepi**

**Nepogrešljive zahteve:**
- **Validacija žetonov**: Strežniki MCP **NE SMEJO** sprejemati žetonov, ki niso izrecno izdani za strežnik MCP  
- **Preverjanje občinstva**: Vedno preverite, ali trditve o občinstvu žetonov ustrezajo identiteti strežnika MCP  
- **Pravilno upravljanje življenjskega cikla žetonov**: Uvedite kratkotrajne dostopne žetone z varnimi praksami rotacije  

## Varnost dobavne verige za sisteme umetne inteligence

Varnost dobavne verige se je razvila onkraj tradicionalnih programskih odvisnosti in zajema celoten ekosistem umetne inteligence. Sodobne implementacije MCP morajo strogo preverjati in spremljati vse komponente, povezane z umetno inteligenco, saj vsaka predstavlja potencialne ranljivosti, ki lahko ogrozijo celovitost sistema.

### Razširjeni elementi dobavne verige umetne inteligence

**Tradicionalne programske odvisnosti:**
- Knjižnice in ogrodja odprte kode  
- Slike kontejnerjev in osnovni sistemi  
- Razvojna orodja in gradbeni cevovodi  
- Komponente in storitve infrastrukture  

**Elementi specifični za umetno inteligenco:**
- **Osnovni modeli**: Predhodno usposobljeni modeli različnih ponudnikov, ki zahtevajo preverjanje izvora  
- **Storitve vektorizacije**: Zunanje storitve za vektorizacijo in semantično iskanje  
- **Ponudniki konteksta**: Viri podatkov, baze znanja in repozitoriji dokumentov  
- **API-ji tretjih oseb**: Zunanje storitve umetne inteligence, cevovodi strojnega učenja in končne točke za obdelavo podatkov  
- **Artefakti modelov**: Teže, konfiguracije in različice modelov po prilagoditvi  
- **Viri podatkov za usposabljanje**: Nabori podatkov, uporabljeni za usposabljanje in prilagajanje modelov  

### Celovita strategija varnosti dobavne verige

#### **Preverjanje komponent in zaupanje**
- **Preverjanje izvora**: Preverite izvor, licenciranje in celovitost vseh komponent umetne inteligence pred integracijo  
- **Varnostna ocena**: Izvedite preglede ranljivosti in varnostne preglede za modele, vire podatkov in storitve umetne inteligence  
- **Analiza ugleda**: Ocenite varnostne prakse in zgodovino ponudnikov storitev umetne inteligence  
- **Preverjanje skladnosti**: Zagotovite, da vse komponente izpolnjujejo varnostne in regulativne zahteve organizacije  

#### **Varni cevovodi za uvajanje**  
- **Avtomatizirana varnost CI/CD**: Vključite varnostno skeniranje v avtomatizirane cevovode za uvajanje  
- **Celovitost artefaktov**: Uvedite kriptografsko preverjanje za vse uvedene artefakte (koda, modeli, konfiguracije)  
- **Postopno uvajanje**: Uporabljajte strategije postopnega uvajanja z varnostnim preverjanjem na vsaki stopnji  
- **Zaupanja vredni repozitoriji artefaktov**: Uvajajte samo iz preverjenih, varnih repozitorijev artefaktov  

#### **Nenehno spremljanje in odzivanje**
- **Skeniranje odvisnosti**: Stalno spremljanje ranljivosti za vse programske in AI komponente  
- **Spremljanje modelov**: Nenehno ocenjevanje vedenja modelov, odklonov zmogljivosti in varnostnih anomalij  
- **Sledenje zdravju storitev**: Spremljanje zunanjih storitev umetne inteligence glede razpoložljivosti, varnostnih incidentov in sprememb politik  
- **Integracija obveščevalnih podatkov o grožnjah**: Vključitev virov groženj, specifičnih za varnost umetne inteligence in strojnega učenja  

#### **Nadzor dostopa in najmanjše privilegije**
- **Dovoljenja na ravni komponent**: Omejite dostop do modelov, podatkov in storitev glede na poslovne potrebe  
- **Upravljanje računov storitev**: Uvedite namenski računi storitev z minimalno potrebnimi dovoljenji  
- **Segmentacija omrežja**: Izolirajte komponente umetne inteligence in omejite omrežni dostop med storitvami  
- **Nadzor API prehodov**: Uporabljajte centralizirane API prehode za nadzor in spremljanje dostopa do zunanjih storitev umetne inteligence  

#### **Odziv na incidente in okrevanje**
- **Postopki hitrega odziva**: Uveljavljeni procesi za popravke ali zamenjavo kompromitiranih komponent umetne inteligence  
- **Rotacija poverilnic**: Avtomatizirani sistemi za rotacijo skrivnosti, API ključev in poverilnic storitev  
- **Zmožnosti povratka**: Sposobnost hitrega vračanja na prejšnje znane dobre različice komponent umetne inteligence  
- **Okrevanje po kršitvah dobavne verige**: Posebni postopki za odzivanje na kompromise storitev umetne inteligence navzgor  

### Microsoftova varnostna orodja in integracija

**GitHub Advanced Security** zagotavlja celovito zaščito dobavne verige, vključno z:  
- **Skeniranje skrivnosti**: Avtomatizirano odkrivanje poverilnic, API ključev in žetonov v repozitorijih  
- **Skeniranje odvisnosti**: Ocena ranljivosti za odvisnosti in knjižnice odprte kode  
- **Analiza CodeQL**: Statična analiza kode za varnostne ranljivosti in težave s kodiranjem  
- **Vpogledi v dobavno verigo**: Vidljivost v zdravje in varnost odvisnosti  

**Integracija Azure DevOps in Azure Repos:**
- Brezhibna integracija varnostnega skeniranja v Microsoftove razvojne platforme  
- Avtomatizirani varnostni pregledi v Azure Pipelines za delovne obremenitve umetne inteligence  
- Uveljavljanje politik za varno uvajanje komponent umetne inteligence  

**Microsoftove interne prakse:**
Microsoft izvaja obsežne prakse varnosti dobavne verige v vseh svojih izdelkih. Več o preverjenih pristopih si preberite v [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).  


### **Microsoft varnostne rešitve**
- [Microsoft Prompt Shields dokumentacija](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety storitev](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Microsoft Entra ID varnost](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Najboljše prakse za upravljanje Azure žetonov](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [GitHub napredna varnost](https://github.com/security/advanced-security)

### **Vodiči za implementacijo in vadnice**
- [Azure API Management kot avtentikacijski prehod za MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Microsoft Entra ID avtentikacija z MCP strežniki](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Varno shranjevanje žetonov in šifriranje (video)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### **DevOps in varnost dobavne verige**
- [Azure DevOps varnost](https://azure.microsoft.com/products/devops)
- [Azure Repos varnost](https://azure.microsoft.com/products/devops/repos/)
- [Microsoftova pot do varnosti dobavne verige](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)

## **Dodatna varnostna dokumentacija**

Za celovite varnostne smernice si oglejte te specializirane dokumente v tem razdelku:

- **[Najboljše prakse za MCP varnost 2025](./mcp-security-best-practices-2025.md)** - Celovite najboljše prakse za MCP implementacije  
- **[Implementacija Azure Content Safety](./azure-content-safety-implementation.md)** - Praktični primeri implementacije za integracijo Azure Content Safety  
- **[MCP varnostni nadzori 2025](./mcp-security-controls-2025.md)** - Najnovejši varnostni nadzori in tehnike za MCP uvajanja  
- **[Hiter referenčni vodič za najboljše prakse MCP](./mcp-best-practices.md)** - Hiter referenčni vodič za ključne MCP varnostne prakse  

---

## Kaj sledi

Naprej: [Poglavje 3: Začetek](../03-GettingStarted/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za strojno prevajanje [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku je treba obravnavati kot avtoritativni vir. Za ključne informacije priporočamo strokovno človeško prevajanje. Ne prevzemamo odgovornosti za morebitna nesporazumevanja ali napačne razlage, ki izhajajo iz uporabe tega prevoda.