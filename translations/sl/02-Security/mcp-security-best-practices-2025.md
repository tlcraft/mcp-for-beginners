<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "057dd5cc6bea6434fdb788e6c93f3f3d",
  "translation_date": "2025-08-18T22:28:21+00:00",
  "source_file": "02-Security/mcp-security-best-practices-2025.md",
  "language_code": "sl"
}
-->
# MCP Varnostne najboljše prakse - Posodobitev avgust 2025

> **Pomembno**: Ta dokument odraža najnovejše varnostne zahteve [MCP Specifikacije 2025-06-18](https://spec.modelcontextprotocol.io/specification/2025-06-18/) in uradne [MCP Varnostne najboljše prakse](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices). Vedno se sklicujte na trenutno specifikacijo za najbolj posodobljene smernice.

## Ključne varnostne prakse za implementacije MCP

Model Context Protocol prinaša edinstvene varnostne izzive, ki presegajo tradicionalno programsko varnost. Te prakse obravnavajo tako osnovne varnostne zahteve kot tudi MCP-specifične grožnje, vključno z vbrizgavanjem ukazov, zastrupljanjem orodij, ugrabitvijo sej, težavami z zmedenim namestnikom in ranljivostmi pri posredovanju žetonov.

### **OBVEZNE varnostne zahteve**

**Ključne zahteve iz MCP specifikacije:**

> **NE SME**: MCP strežniki **NE SMEJO** sprejemati nobenih žetonov, ki niso bili izrecno izdani za MCP strežnik  
> 
> **MORA**: MCP strežniki, ki izvajajo avtorizacijo, **MORAJO** preveriti VSE dohodne zahteve  
>  
> **NE SME**: MCP strežniki **NE SMEJO** uporabljati sej za avtentikacijo  
>
> **MORA**: MCP posredniški strežniki, ki uporabljajo statične ID-je odjemalcev, **MORAJO** pridobiti soglasje uporabnika za vsakega dinamično registriranega odjemalca  

---

## 1. **Varnost žetonov in avtentikacija**

**Kontrole avtentikacije in avtorizacije:**
   - **Temeljit pregled avtorizacije**: Izvedite obsežne revizije avtorizacijske logike MCP strežnika, da zagotovite dostop samo za predvidene uporabnike in odjemalce  
   - **Integracija zunanjih ponudnikov identitete**: Uporabljajte uveljavljene ponudnike identitete, kot je Microsoft Entra ID, namesto da bi razvijali lastne rešitve za avtentikacijo  
   - **Preverjanje občinstva žetonov**: Vedno preverite, da so bili žetoni izrecno izdani za vaš MCP strežnik - nikoli ne sprejemajte žetonov iz višjih tokov  
   - **Pravilno upravljanje življenjskega cikla žetonov**: Uvedite varno rotacijo žetonov, politike poteka in preprečite napade z ponovnim predvajanjem žetonov  

**Zaščitena hramba žetonov:**
   - Uporabljajte Azure Key Vault ali podobne varne shrambe za vse skrivnosti  
   - Uvedite šifriranje žetonov tako v mirovanju kot med prenosom  
   - Redna rotacija poverilnic in spremljanje nepooblaščenega dostopa  

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
   - Jasni postopki za eskalacijo varnostnih incidentov  
   - Integracija z organizacijskimi ekipami za odziv na incidente  
   - Redne simulacije varnostnih incidentov in vaje na papirju  

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
   - **Microsoft Defender for Cloud**: Upravljanje varnostne drže v oblaku za MCP delovne obremenitve  
   - **Azure Sentinel**: Cloud-native SIEM in SOAR zmogljivosti za napredno zaznavanje groženj  
   - **Microsoft Purview**: Upravljanje podatkov in skladnost za AI delovne tokove in vire podatkov  

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
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)  
- [Azure Content Safety](https://learn.microsoft.com/azure/ai-services/content-safety/)  
- [Microsoft Entra ID Varnost](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)  
- [GitHub Advanced Security](https://github.com/security/advanced-security)  

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