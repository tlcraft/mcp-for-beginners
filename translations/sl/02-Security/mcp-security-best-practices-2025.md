<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "057dd5cc6bea6434fdb788e6c93f3f3d",
<<<<<<< HEAD
  "translation_date": "2025-08-18T22:28:21+00:00",
=======
  "translation_date": "2025-08-18T17:48:42+00:00",
>>>>>>> origin/main
  "source_file": "02-Security/mcp-security-best-practices-2025.md",
  "language_code": "sl"
}
-->
<<<<<<< HEAD
# MCP Varnostne najboljše prakse - Posodobitev avgust 2025

> **Pomembno**: Ta dokument odraža najnovejše varnostne zahteve [MCP Specifikacije 2025-06-18](https://spec.modelcontextprotocol.io/specification/2025-06-18/) in uradne [MCP Varnostne najboljše prakse](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices). Vedno se sklicujte na trenutno specifikacijo za najbolj posodobljene smernice.

## Ključne varnostne prakse za implementacije MCP

Model Context Protocol prinaša edinstvene varnostne izzive, ki presegajo tradicionalno programsko varnost. Te prakse obravnavajo tako osnovne varnostne zahteve kot tudi MCP-specifične grožnje, vključno z vbrizgavanjem ukazov, zastrupljanjem orodij, ugrabitvijo sej, težavami z zmedenim namestnikom in ranljivostmi pri posredovanju žetonov.

### **OBVEZNE varnostne zahteve**

**Ključne zahteve iz MCP specifikacije:**

> **NE SME**: MCP strežniki **NE SMEJO** sprejemati nobenih žetonov, ki niso bili izrecno izdani za MCP strežnik  
=======
# MCP Varnostne Najboljše Prakse - Posodobitev Avgust 2025

> **Pomembno**: Ta dokument odraža najnovejše [MCP Specifikacije 2025-06-18](https://spec.modelcontextprotocol.io/specification/2025-06-18/) varnostne zahteve in uradne [MCP Varnostne Najboljše Prakse](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices). Vedno se sklicujte na trenutno specifikacijo za najnovejše smernice.

## Ključne Varnostne Prakse za MCP Implementacije

Model Context Protocol prinaša edinstvene varnostne izzive, ki presegajo tradicionalno programsko varnost. Te prakse obravnavajo tako osnovne varnostne zahteve kot MCP-specifične grožnje, vključno z vbrizgavanjem ukazov, zastrupljanjem orodij, ugrabitvijo sej, težavami z zmedenim namestnikom in ranljivostmi pri posredovanju žetonov.

### **OBVEZNE Varnostne Zahteve**

**Ključne Zahteve iz MCP Specifikacije:**

> **NE SME**: MCP strežniki **NE SMEJO** sprejemati žetonov, ki niso bili izrecno izdani za MCP strežnik  
>>>>>>> origin/main
> 
> **MORA**: MCP strežniki, ki izvajajo avtorizacijo, **MORAJO** preveriti VSE dohodne zahteve  
>  
> **NE SME**: MCP strežniki **NE SMEJO** uporabljati sej za avtentikacijo  
>
<<<<<<< HEAD
> **MORA**: MCP posredniški strežniki, ki uporabljajo statične ID-je odjemalcev, **MORAJO** pridobiti soglasje uporabnika za vsakega dinamično registriranega odjemalca  

---

## 1. **Varnost žetonov in avtentikacija**

**Kontrole avtentikacije in avtorizacije:**
   - **Temeljit pregled avtorizacije**: Izvedite obsežne revizije avtorizacijske logike MCP strežnika, da zagotovite dostop samo za predvidene uporabnike in odjemalce  
   - **Integracija zunanjih ponudnikov identitete**: Uporabljajte uveljavljene ponudnike identitete, kot je Microsoft Entra ID, namesto da bi razvijali lastne rešitve za avtentikacijo  
   - **Preverjanje občinstva žetonov**: Vedno preverite, da so bili žetoni izrecno izdani za vaš MCP strežnik - nikoli ne sprejemajte žetonov iz višjih tokov  
   - **Pravilno upravljanje življenjskega cikla žetonov**: Uvedite varno rotacijo žetonov, politike poteka in preprečite napade z ponovnim predvajanjem žetonov  

**Zaščitena hramba žetonov:**
=======
> **MORA**: MCP proxy strežniki, ki uporabljajo statične ID-je strank, **MORAJO** pridobiti soglasje uporabnika za vsako dinamično registrirano stranko  

---

## 1. **Varnost Žetonov in Avtentikacija**

**Kontrole Avtentikacije in Avtorizacije:**
   - **Temeljit Pregled Avtorizacije**: Izvedite celovite preglede avtorizacijske logike MCP strežnika, da zagotovite, da lahko vire dostopajo le predvideni uporabniki in stranke  
   - **Integracija Zunanjih Ponudnikov Identitete**: Uporabljajte uveljavljene ponudnike identitete, kot je Microsoft Entra ID, namesto lastne implementacije avtentikacije  
   - **Preverjanje Ciljne Publike Žetonov**: Vedno preverite, da so bili žetoni izrecno izdani za vaš MCP strežnik - nikoli ne sprejemajte žetonov iz drugih virov  
   - **Pravilno Upravljanje Življenjskega Cikla Žetonov**: Uvedite varno rotacijo žetonov, politike poteka veljavnosti in preprečite napade z ponovnim predvajanjem žetonov  

**Zaščitena Hramba Žetonov:**
>>>>>>> origin/main
   - Uporabljajte Azure Key Vault ali podobne varne shrambe za vse skrivnosti  
   - Uvedite šifriranje žetonov tako v mirovanju kot med prenosom  
   - Redna rotacija poverilnic in spremljanje nepooblaščenega dostopa  

<<<<<<< HEAD
## 2. **Upravljanje sej in varnost prenosa**

**Varne prakse za seje:**
   - **Kriptografsko varni ID-ji sej**: Uporabljajte varne, nedeterministične ID-je sej, ustvarjene z varnimi generatorji naključnih števil  
   - **Vezava na uporabnika**: Vezite ID-je sej na identitete uporabnikov z oblikami, kot je `<user_id>:<session_id>`, da preprečite zlorabo sej med uporabniki  
   - **Upravljanje življenjskega cikla sej**: Uvedite pravilno potekanje, rotacijo in preklic sej za omejevanje ranljivih obdobij  
   - **Obvezna uporaba HTTPS/TLS**: Obvezno uporabljajte HTTPS za vso komunikacijo, da preprečite prestrezanje ID-jev sej  

**Varnost transportne plasti:**
   - Kjer je mogoče, konfigurirajte TLS 1.3 z ustreznim upravljanjem certifikatov  
   - Uvedite pripenjanje certifikatov za kritične povezave  
   - Redna rotacija certifikatov in preverjanje njihove veljavnosti  

## 3. **Zaščita pred grožnjami, specifičnimi za AI** 🤖

**Obramba pred vbrizgavanjem ukazov:**
   - **Microsoft Prompt Shields**: Uporabljajte AI Prompt Shields za napredno zaznavanje in filtriranje zlonamernih navodil  
   - **Sanitizacija vhodov**: Preverjajte in čistite vse vnose, da preprečite napade z vbrizgavanjem in težave z zmedenim namestnikom  
   - **Meje vsebine**: Uporabljajte sisteme za označevanje in ločevanje vsebine, da ločite zaupanja vredna navodila od zunanje vsebine  

**Preprečevanje zastrupljanja orodij:**
   - **Preverjanje metapodatkov orodij**: Uvedite preverjanje celovitosti definicij orodij in spremljajte nepričakovane spremembe  
   - **Dinamično spremljanje orodij**: Spremljajte vedenje med izvajanjem in nastavite opozorila za nepričakovane vzorce izvajanja  
   - **Delovni tokovi za odobritev**: Zahtevajte izrecno uporabniško odobritev za spremembe orodij in njihovih zmogljivosti  

## 4. **Nadzor dostopa in dovoljenja**

**Načelo najmanjših privilegijev:**
   - MCP strežnikom dodelite samo minimalna dovoljenja, potrebna za predvideno funkcionalnost  
   - Uvedite nadzor dostopa na podlagi vlog (RBAC) z natančno določenimi dovoljenji  
   - Redni pregledi dovoljenj in stalno spremljanje za preprečevanje eskalacije privilegijev  

**Kontrole dovoljenj med izvajanjem:**
   - Uporabljajte omejitve virov za preprečevanje napadov z izčrpavanjem virov  
   - Uporabljajte izolacijo vsebnikov za okolja izvajanja orodij  
   - Uvedite dostop "just-in-time" za administrativne funkcije  

## 5. **Varnost vsebine in spremljanje**

**Implementacija varnosti vsebine:**
   - **Integracija Azure Content Safety**: Uporabljajte Azure Content Safety za zaznavanje škodljive vsebine, poskusov izogibanja pravilom in kršitev politik  
   - **Analiza vedenja**: Uvedite spremljanje vedenja med izvajanjem za zaznavanje anomalij pri MCP strežniku in izvajanju orodij  
   - **Celovito beleženje**: Beležite vse poskuse avtentikacije, klice orodij in varnostne dogodke z varno, nepoškodljivo hrambo  

**Neprekinjeno spremljanje:**
   - Opozorila v realnem času za sumljive vzorce in poskuse nepooblaščenega dostopa  
   - Integracija s sistemi SIEM za centralizirano upravljanje varnostnih dogodkov  
   - Redne varnostne revizije in penetracijski testi MCP implementacij  

## 6. **Varnost dobavne verige**

**Preverjanje komponent:**
   - **Skeniranje odvisnosti**: Uporabljajte avtomatizirano skeniranje ranljivosti za vse programske odvisnosti in AI komponente  
   - **Preverjanje izvora**: Preverjajte izvor, licenciranje in celovitost modelov, virov podatkov in zunanjih storitev  
   - **Podpisani paketi**: Uporabljajte kriptografsko podpisane pakete in preverjajte podpise pred uvajanjem  

**Varna razvojna linija:**
   - **GitHub Advanced Security**: Uvedite skeniranje skrivnosti, analizo odvisnosti in statično analizo CodeQL  
   - **Varnost CI/CD**: Integrirajte varnostno preverjanje skozi avtomatizirane linije uvajanja  
   - **Celovitost artefaktov**: Uvedite kriptografsko preverjanje za uvedene artefakte in konfiguracije  

## 7. **OAuth varnost in preprečevanje zmedenega namestnika**

**Implementacija OAuth 2.1:**
   - **Implementacija PKCE**: Uporabljajte Proof Key for Code Exchange (PKCE) za vse zahteve za avtorizacijo  
   - **Izrecno soglasje**: Pridobite soglasje uporabnika za vsakega dinamično registriranega odjemalca, da preprečite napade z zmedenim namestnikom  
   - **Preverjanje preusmeritvenih URI-jev**: Uvedite strogo preverjanje preusmeritvenih URI-jev in identifikatorjev odjemalcev  

**Varnost posrednikov:**
   - Preprečite obvode avtorizacije z izkoriščanjem statičnih ID-jev odjemalcev  
   - Uvedite ustrezne delovne tokove za soglasje za dostop do API-jev tretjih oseb  
   - Spremljajte krajo avtorizacijskih kod in nepooblaščen dostop do API-jev  

## 8. **Odziv na incidente in okrevanje**

**Sposobnosti hitrega odziva:**
   - **Avtomatiziran odziv**: Uvedite avtomatizirane sisteme za rotacijo poverilnic in zajezitev groženj  
   - **Postopki povrnitve**: Sposobnost hitrega vračanja na znane dobre konfiguracije in komponente  
   - **Forenzične sposobnosti**: Podrobne revizijske sledi in beleženje za preiskavo incidentov  

**Komunikacija in koordinacija:**
=======
## 2. **Upravljanje Sej in Varnost Prenosa**

**Varne Prakse za Seje:**
   - **Kriptografsko Varni ID-ji Sej**: Uporabljajte varne, nedeterministične ID-je sej, ustvarjene z varnimi generatorji naključnih števil  
   - **Vezava na Uporabnika**: Povežite ID-je sej z identitetami uporabnikov v formatu, kot je `<user_id>:<session_id>`, da preprečite zlorabo sej med uporabniki  
   - **Upravljanje Življenjskega Cikla Sej**: Uvedite pravilno potekanje, rotacijo in preklic sej za omejitev ranljivostnih oken  
   - **Obvezna Uporaba HTTPS/TLS**: Zahtevajte HTTPS za vso komunikacijo, da preprečite prestrezanje ID-jev sej  

**Varnost Prenosnega Sloja:**
   - Konfigurirajte TLS 1.3, kjer je mogoče, z ustreznim upravljanjem certifikatov  
   - Uvedite pripenjanje certifikatov za kritične povezave  
   - Redna rotacija certifikatov in preverjanje veljavnosti  

## 3. **Zaščita Pred Grožnjami, Povezanimi z Umetno Inteligenco** 🤖

**Obramba Pred Vbrizgavanjem Ukazov:**
   - **Microsoft Prompt Shields**: Uporabljajte AI Prompt Shields za napredno zaznavanje in filtriranje zlonamernih navodil  
   - **Sanitizacija Vnosov**: Preverjajte in sanitizirajte vse vnose, da preprečite napade z vbrizgavanjem in težave z zmedenim namestnikom  
   - **Meje Vsebine**: Uporabljajte sisteme za označevanje in ločevanje vsebine, da ločite zaupanja vredna navodila od zunanje vsebine  

**Preprečevanje Zastrupljanja Orodij:**
   - **Preverjanje Metapodatkov Orodij**: Uvedite preverjanje integritete definicij orodij in spremljajte nepričakovane spremembe  
   - **Dinamično Spremljanje Orodij**: Spremljajte vedenje med izvajanjem in nastavite opozorila za nepričakovane vzorce izvajanja  
   - **Delovni Tokovi za Odobritev**: Zahtevajte izrecno odobritev uporabnika za spremembe orodij in njihovih zmožnosti  

## 4. **Nadzor Dostopa in Dovoljenja**

**Načelo Najmanjših Privilegijev:**
   - MCP strežnikom dodelite le minimalna dovoljenja, potrebna za predvideno funkcionalnost  
   - Uvedite nadzor dostopa na podlagi vlog (RBAC) z natančno določenimi dovoljenji  
   - Redni pregledi dovoljenj in stalno spremljanje za eskalacijo privilegijev  

**Kontrole Dovoljenj Med Izvajanjem:**
   - Uvedite omejitve virov, da preprečite napade z izčrpavanjem virov  
   - Uporabljajte izolacijo kontejnerjev za okolja izvajanja orodij  
   - Uvedite dostop "just-in-time" za administrativne funkcije  

## 5. **Varnost Vsebine in Spremljanje**

**Implementacija Varnosti Vsebine:**
   - **Integracija Azure Content Safety**: Uporabljajte Azure Content Safety za zaznavanje škodljive vsebine, poskusov izogibanja pravilom in kršitev politik  
   - **Vedenjska Analiza**: Uvedite spremljanje vedenja med izvajanjem za zaznavanje anomalij v MCP strežniku in izvajanju orodij  
   - **Celovito Beleženje**: Beležite vse poskuse avtentikacije, klice orodij in varnostne dogodke z varno, nepoškodljivo hrambo  

**Neprekinjeno Spremljanje:**
   - Opozorila v realnem času za sumljive vzorce in nepooblaščene poskuse dostopa  
   - Integracija s SIEM sistemi za centralizirano upravljanje varnostnih dogodkov  
   - Redni varnostni pregledi in penetracijski testi MCP implementacij  

## 6. **Varnost Dobavne Verige**

**Preverjanje Komponent:**
   - **Skeniranje Odvisnosti**: Uporabljajte avtomatizirano skeniranje ranljivosti za vse programske odvisnosti in AI komponente  
   - **Preverjanje Izvora**: Preverite izvor, licenciranje in integriteto modelov, virov podatkov in zunanjih storitev  
   - **Podpisani Paketi**: Uporabljajte kriptografsko podpisane pakete in preverite podpise pred uvajanjem  

**Varna Razvojna Cevovoda:**
   - **GitHub Advanced Security**: Uvedite skeniranje skrivnosti, analizo odvisnosti in statično analizo CodeQL  
   - **Varnost CI/CD**: Integrirajte varnostno preverjanje skozi avtomatizirane cevovode uvajanja  
   - **Integriteta Artefaktov**: Uvedite kriptografsko preverjanje za uvedene artefakte in konfiguracije  

## 7. **OAuth Varnost in Preprečevanje Zmedenega Namestnika**

**Implementacija OAuth 2.1:**
   - **Implementacija PKCE**: Uporabljajte Proof Key for Code Exchange (PKCE) za vse avtorizacijske zahteve  
   - **Izrecno Soglasje**: Pridobite soglasje uporabnika za vsako dinamično registrirano stranko, da preprečite napade zmedenega namestnika  
   - **Preverjanje Preusmeritvenih URI-jev**: Uvedite strogo preverjanje preusmeritvenih URI-jev in identifikatorjev strank  

**Varnost Proxyja:**
   - Preprečite obvode avtorizacije z izkoriščanjem statičnih ID-jev strank  
   - Uvedite ustrezne delovne tokove za soglasje za dostop do API-jev tretjih oseb  
   - Spremljajte krajo avtorizacijskih kod in nepooblaščen dostop do API-jev  

## 8. **Odziv na Incidente in Obnova**

**Sposobnosti Hitrega Odziva:**
   - **Avtomatiziran Odziv**: Uvedite avtomatizirane sisteme za rotacijo poverilnic in omejevanje groženj  
   - **Postopki Povrnitve**: Sposobnost hitrega vračanja na znane dobre konfiguracije in komponente  
   - **Forenzične Sposobnosti**: Podrobne revizijske sledi in beleženje za preiskavo incidentov  

**Komunikacija in Koordinacija:**
>>>>>>> origin/main
   - Jasni postopki za eskalacijo varnostnih incidentov  
   - Integracija z organizacijskimi ekipami za odziv na incidente  
   - Redne simulacije varnostnih incidentov in vaje na papirju  

<<<<<<< HEAD
## 9. **Skladnost in upravljanje**

**Regulativna skladnost:**
   - Zagotovite, da MCP implementacije izpolnjujejo zahteve specifične za industrijo (GDPR, HIPAA, SOC 2)  
   - Uvedite klasifikacijo podatkov in kontrole zasebnosti za obdelavo AI podatkov  
   - Vzdržujte obsežno dokumentacijo za revizije skladnosti  

**Upravljanje sprememb:**
   - Formalni postopki varnostnega pregleda za vse spremembe MCP sistema  
   - Nadzor različic in delovni tokovi za odobritev sprememb konfiguracije  
   - Redne ocene skladnosti in analize vrzeli  

## 10. **Napredni varnostni ukrepi**

**Arhitektura Zero Trust:**
   - **Nikoli ne zaupaj, vedno preveri**: Neprekinjeno preverjanje uporabnikov, naprav in povezav  
   - **Mikrosegmentacija**: Granularni omrežni nadzori za izolacijo posameznih MCP komponent  
   - **Pogojni dostop**: Nadzor dostopa na podlagi tveganja, ki se prilagaja trenutnemu kontekstu in vedenju  

**Zaščita aplikacij med izvajanjem:**
   - **Runtime Application Self-Protection (RASP)**: Uvedite RASP tehnike za zaznavanje groženj v realnem času  
   - **Spremljanje zmogljivosti aplikacij**: Spremljajte anomalije v zmogljivosti, ki lahko kažejo na napade  
   - **Dinamične varnostne politike**: Uvedite varnostne politike, ki se prilagajajo trenutni grožnji  

## 11. **Integracija z Microsoftovim varnostnim ekosistemom**

**Celovita Microsoftova varnost:**
=======
## 9. **Skladnost in Upravljanje**

**Regulativna Skladnost:**
   - Zagotovite, da MCP implementacije izpolnjujejo zahteve specifične za industrijo (GDPR, HIPAA, SOC 2)  
   - Uvedite klasifikacijo podatkov in nadzore zasebnosti za obdelavo AI podatkov  
   - Vzdržujte celovito dokumentacijo za revizije skladnosti  

**Upravljanje Sprememb:**
   - Formalni varnostni pregledi za vse spremembe MCP sistema  
   - Nadzor različic in delovni tokovi za odobritev sprememb konfiguracije  
   - Redne ocene skladnosti in analize vrzeli  

## 10. **Napredni Varnostni Nadzori**

**Arhitektura Zero Trust:**
   - **Nikoli Ne Zaupaj, Vedno Preverjaj**: Neprekinjeno preverjanje uporabnikov, naprav in povezav  
   - **Mikrosegmentacija**: Granularni omrežni nadzori za izolacijo posameznih MCP komponent  
   - **Pogojni Dostop**: Nadzori dostopa na podlagi tveganja, prilagojeni trenutnemu kontekstu in vedenju  

**Zaščita Aplikacij Med Izvajanjem:**
   - **Runtime Application Self-Protection (RASP)**: Uvedite RASP tehnike za zaznavanje groženj v realnem času  
   - **Spremljanje Zmogljivosti Aplikacij**: Spremljajte anomalije v zmogljivosti, ki lahko nakazujejo napade  
   - **Dinamične Varnostne Politike**: Uvedite varnostne politike, ki se prilagajajo trenutni grožnji  

## 11. **Integracija z Microsoftovim Varnostnim Ekosistemom**

**Celovita Microsoftova Varnost:**
>>>>>>> origin/main
   - **Microsoft Defender for Cloud**: Upravljanje varnostne drže v oblaku za MCP delovne obremenitve  
   - **Azure Sentinel**: Cloud-native SIEM in SOAR zmogljivosti za napredno zaznavanje groženj  
   - **Microsoft Purview**: Upravljanje podatkov in skladnost za AI delovne tokove in vire podatkov  

<<<<<<< HEAD
**Upravljanje identitete in dostopa:**
   - **Microsoft Entra ID**: Upravljanje identitete v podjetju s politikami pogojnega dostopa  
   - **Privileged Identity Management (PIM)**: Dostop "just-in-time" in delovni tokovi za odobritev za administrativne funkcije  
   - **Zaščita identitete**: Pogojni dostop na podlagi tveganja in avtomatiziran odziv na grožnje  

## 12. **Neprekinjen razvoj varnosti**

**Ohranjanje aktualnosti:**
   - **Spremljanje specifikacij**: Redni pregledi posodobitev MCP specifikacij in sprememb varnostnih smernic  
   - **Obveščanje o grožnjah**: Integracija virov groženj, specifičnih za AI, in indikatorjev kompromisa  
   - **Vključevanje v varnostno skupnost**: Aktivno sodelovanje v MCP varnostni skupnosti in programih za razkritje ranljivosti  

**Prilagodljiva varnost:**
   - **Varnost strojnega učenja**: Uporabljajte zaznavanje anomalij na osnovi strojnega učenja za prepoznavanje novih vzorcev napadov  
   - **Prediktivna varnostna analitika**: Uvedite prediktivne modele za proaktivno prepoznavanje groženj  
   - **Avtomatizacija varnosti**: Avtomatizirane posodobitve varnostnih politik na podlagi obveščanja o grožnjah in sprememb specifikacij  

---

## **Ključni varnostni viri**

### **Uradna MCP dokumentacija**
- [MCP Specifikacija (2025-06-18)](https://spec.modelcontextprotocol.io/specification/2025-06-18/)  
- [MCP Varnostne najboljše prakse](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices)  
- [MCP Specifikacija avtorizacije](https://modelcontextprotocol.io/specification/2025-06-18/basic/authorization)  

### **Microsoftove varnostne rešitve**
=======
**Upravljanje Identitete in Dostopa:**
   - **Microsoft Entra ID**: Upravljanje identitete v podjetju s politikami pogojnega dostopa  
   - **Privileged Identity Management (PIM)**: Dostop "just-in-time" in delovni tokovi za odobritev za administrativne funkcije  
   - **Zaščita Identitete**: Pogojni dostop na podlagi tveganja in avtomatiziran odziv na grožnje  

## 12. **Neprekinjen Razvoj Varnosti**

**Ohranjanje Aktualnosti:**
   - **Spremljanje Specifikacij**: Redni pregledi posodobitev MCP specifikacij in sprememb varnostnih smernic  
   - **Obveščanje o Grožnjah**: Integracija AI-specifičnih virov groženj in indikatorjev kompromisa  
   - **Sodelovanje v Varnostni Skupnosti**: Aktivno sodelovanje v MCP varnostni skupnosti in programih za razkritje ranljivosti  

**Prilagodljiva Varnost:**
   - **Varnost Strojnega Učenja**: Uporabljajte algoritme za zaznavanje anomalij za prepoznavanje novih vzorcev napadov  
   - **Prediktivna Varnostna Analitika**: Uvedite prediktivne modele za proaktivno prepoznavanje groženj  
   - **Avtomatizacija Varnosti**: Avtomatizirane posodobitve varnostnih politik na podlagi obveščanja o grožnjah in sprememb specifikacij  

---

## **Ključni Varnostni Viri**

### **Uradna MCP Dokumentacija**
- [MCP Specifikacija (2025-06-18)](https://spec.modelcontextprotocol.io/specification/2025-06-18/)  
- [MCP Varnostne Najboljše Prakse](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices)  
- [MCP Specifikacija Avtorizacije](https://modelcontextprotocol.io/specification/2025-06-18/basic/authorization)  

### **Microsoftove Varnostne Rešitve**
>>>>>>> origin/main
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)  
- [Azure Content Safety](https://learn.microsoft.com/azure/ai-services/content-safety/)  
- [Microsoft Entra ID Varnost](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)  
- [GitHub Advanced Security](https://github.com/security/advanced-security)  

<<<<<<< HEAD
### **Varnostni standardi**
- [OAuth 2.0 Varnostne najboljše prakse (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)  
- [OWASP Top 10 za velike jezikovne modele](https://genai.owasp.org/)  
- [NIST Okvir za upravljanje tveganj AI](https://www.nist.gov/itl/ai-risk-management-framework)  

### **Vodniki za implementacijo**
- [Azure API Management MCP Avtentikacijski prehod](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)  
- [Microsoft Entra ID z MCP strežniki](https://den.dev/blog/mcp-server-auth-entra-id-session/)  

---

> **Varnostno obvestilo**: MCP varnostne prakse se hitro razvijajo. Vedno preverite trenutno [MCP specifikacijo](https://spec.modelcontextprotocol.io/) in [uradno varnostno dokumentacijo](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices) pred implementacijo.  

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za strojno prevajanje [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku je treba obravnavati kot avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Ne prevzemamo odgovornosti za morebitna nesporazumevanja ali napačne razlage, ki izhajajo iz uporabe tega prevoda.
=======
### **Varnostni Standardi**
- [OAuth 2.0 Varnostne Najboljše Prakse (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)  
- [OWASP Top 10 za Velike Jezikovne Modele](https://genai.owasp.org/)  
- [NIST Okvir za Upravljanje Tveganj AI](https://www.nist.gov/itl/ai-risk-management-framework)  

### **Vodniki za Implementacijo**
- [Azure API Management MCP Avtentikacijski Prehod](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)  
- [Microsoft Entra ID z MCP Strežniki](https://den.dev/blog/mcp-server-auth-entra-id-session/)  

---

> **Varnostno Obvestilo**: MCP varnostne prakse se hitro razvijajo. Vedno preverite trenutno [MCP specifikacijo](https://spec.modelcontextprotocol.io/) in [uradno varnostno dokumentacijo](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices) pred implementacijo.

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za strojno prevajanje [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku je treba obravnavati kot avtoritativni vir. Za ključne informacije priporočamo strokovno človeško prevajanje. Ne prevzemamo odgovornosti za morebitna nesporazumevanja ali napačne razlage, ki izhajajo iz uporabe tega prevoda.
>>>>>>> origin/main
