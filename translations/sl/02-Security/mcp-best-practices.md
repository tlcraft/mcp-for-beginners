<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b2b9e15e78b9d9a2b3ff3e8fd7d1f434",
  "translation_date": "2025-08-18T22:32:25+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "sl"
}
-->
# Najboljše varnostne prakse za MCP 2025

Ta obsežen vodnik opisuje ključne varnostne prakse za implementacijo sistemov Model Context Protocol (MCP) na podlagi najnovejše **MCP Specifikacije 2025-06-18** in trenutnih industrijskih standardov. Prakse obravnavajo tako tradicionalne varnostne izzive kot tudi grožnje, specifične za umetno inteligenco, ki so značilne za MCP implementacije.

## Ključne varnostne zahteve

### Obvezni varnostni ukrepi (zahteve MUST)

1. **Validacija žetonov**: MCP strežniki **NE SMEJO** sprejemati žetonov, ki niso bili izrecno izdani za sam MCP strežnik.
2. **Preverjanje avtorizacije**: MCP strežniki, ki izvajajo avtorizacijo, **MORAJO** preveriti VSE dohodne zahteve in **NE SMEJO** uporabljati sej za avtentikacijo.  
3. **Soglasje uporabnika**: MCP proxy strežniki, ki uporabljajo statične ID-je odjemalcev, **MORAJO** pridobiti izrecno soglasje uporabnika za vsakega dinamično registriranega odjemalca.
4. **Varni ID-ji sej**: MCP strežniki **MORAJO** uporabljati kriptografsko varne, nedeterministične ID-je sej, ustvarjene z varnimi generatorji naključnih števil.

## Osnovne varnostne prakse

### 1. Validacija in sanitizacija vhodnih podatkov
- **Celovita validacija vhodnih podatkov**: Validirajte in sanitizirajte vse vhodne podatke, da preprečite napade z vbrizgavanjem, težave z zmedenimi posredniki in ranljivosti pri vbrizgavanju pozivov.
- **Uveljavljanje sheme parametrov**: Uvedite strogo validacijo JSON shem za vse parametre orodij in vhodne podatke API-jev.
- **Filtriranje vsebine**: Uporabite Microsoft Prompt Shields in Azure Content Safety za filtriranje zlonamerne vsebine v pozivih in odgovorih.
- **Sanitizacija izhodnih podatkov**: Validirajte in sanitizirajte vse izhode modela, preden jih predstavite uporabnikom ali sistemom navzdol.

### 2. Odličnost pri avtentikaciji in avtorizaciji  
- **Zunanji ponudniki identitete**: Avtentikacijo delegirajte uveljavljenim ponudnikom identitete (Microsoft Entra ID, ponudniki OAuth 2.1) namesto implementacije lastne avtentikacije.
- **Drobnozrnate pravice**: Uvedite granularne, orodju specifične pravice v skladu z načelom najmanjših privilegijev.
- **Upravljanje življenjskega cikla žetonov**: Uporabljajte kratkotrajne dostopne žetone z varno rotacijo in ustrezno validacijo občinstva.
- **Večfaktorska avtentikacija**: Zahtevajte MFA za ves administrativni dostop in občutljive operacije.

### 3. Varni komunikacijski protokoli
- **Transport Layer Security**: Uporabljajte HTTPS/TLS 1.3 za vse MCP komunikacije z ustrezno validacijo certifikatov.
- **Šifriranje od konca do konca**: Uvedite dodatne sloje šifriranja za zelo občutljive podatke med prenosom in v mirovanju.
- **Upravljanje certifikatov**: Zagotovite ustrezno upravljanje življenjskega cikla certifikatov z avtomatiziranimi procesi obnove.
- **Uveljavljanje različic protokola**: Uporabljajte trenutno različico MCP protokola (2025-06-18) z ustreznim pogajanjem o različicah.

### 4. Napredno omejevanje hitrosti in zaščita virov
- **Večplastno omejevanje hitrosti**: Uvedite omejevanje hitrosti na ravni uporabnika, seje, orodja in virov, da preprečite zlorabe.
- **Prilagodljivo omejevanje hitrosti**: Uporabljajte omejevanje hitrosti, ki temelji na strojni inteligenci in se prilagaja vzorcem uporabe ter indikatorjem groženj.
- **Upravljanje kvot virov**: Nastavite ustrezne omejitve za računske vire, porabo pomnilnika in čas izvajanja.
- **Zaščita pred DDoS napadi**: Uvedite celovite sisteme za zaščito pred DDoS napadi in analizo prometa.

### 5. Celovito beleženje in spremljanje
- **Strukturirano beleženje revizij**: Uvedite podrobne, iskalne dnevnike za vse MCP operacije, izvajanja orodij in varnostne dogodke.
- **Spremljanje varnosti v realnem času**: Uporabljajte SIEM sisteme z zaznavanjem anomalij, ki temelji na umetni inteligenci, za MCP delovne obremenitve.
- **Beleženje skladno z zasebnostjo**: Beležite varnostne dogodke ob spoštovanju zahtev in predpisov o varstvu podatkov.
- **Integracija odziva na incidente**: Povežite sisteme beleženja z avtomatiziranimi delovnimi tokovi za odziv na incidente.

### 6. Izboljšane prakse varnega shranjevanja
- **Strojne varnostne module**: Uporabljajte HSM-podprto shranjevanje ključev (Azure Key Vault, AWS CloudHSM) za ključne kriptografske operacije.
- **Upravljanje šifrirnih ključev**: Uvedite ustrezno rotacijo ključev, segregacijo in nadzor dostopa za šifrirne ključe.
- **Upravljanje skrivnosti**: Shranjujte vse API ključe, žetone in poverilnice v namenskih sistemih za upravljanje skrivnosti.
- **Razvrščanje podatkov**: Razvrstite podatke glede na stopnjo občutljivosti in uporabite ustrezne zaščitne ukrepe.

### 7. Napredno upravljanje žetonov
- **Preprečevanje posredovanja žetonov**: Izrecno prepovejte vzorce posredovanja žetonov, ki obidejo varnostne ukrepe.
- **Validacija občinstva**: Vedno preverite, ali trditve o občinstvu žetonov ustrezajo identiteti predvidenega MCP strežnika.
- **Avtorizacija na podlagi trditev**: Uvedite drobnozrnato avtorizacijo na podlagi trditev žetonov in atributov uporabnikov.
- **Vezava žetonov**: Žetone povežite s specifičnimi sejami, uporabniki ali napravami, kjer je to primerno.

### 8. Varno upravljanje sej
- **Kriptografski ID-ji sej**: Ustvarjajte ID-je sej z uporabo kriptografsko varnih generatorjev naključnih števil (nepredvidljivih zaporedij).
- **Vezava na uporabnika**: ID-je sej povežite z uporabniškimi informacijami z uporabo varnih formatov, kot je `<user_id>:<session_id>`.
- **Nadzor življenjskega cikla sej**: Uvedite ustrezno potekanje, rotacijo in razveljavitev sej.
- **Varnostne glave sej**: Uporabljajte ustrezne HTTP varnostne glave za zaščito sej.

### 9. Varnostni ukrepi specifični za AI
- **Obramba pred vbrizgavanjem pozivov**: Uvedite Microsoft Prompt Shields z metodami osvetljevanja, ločil in označevanja podatkov.
- **Preprečevanje zastrupitve orodij**: Validirajte metapodatke orodij, spremljajte dinamične spremembe in preverjajte integriteto orodij.
- **Validacija izhodov modela**: Preverjajte izhode modela glede morebitnega uhajanja podatkov, škodljive vsebine ali kršitev varnostnih politik.
- **Zaščita kontekstnega okna**: Uvedite ukrepe za preprečevanje zastrupitve in manipulacije kontekstnega okna.

### 10. Varnost pri izvajanju orodij
- **Izolacija izvajanja**: Izvajajte orodja v vsebniških, izoliranih okoljih z omejitvami virov.
- **Ločevanje privilegijev**: Izvajajte orodja z minimalno potrebnimi privilegiji in ločenimi uporabniškimi računi.
- **Omrežna izolacija**: Uvedite segmentacijo omrežja za okolja izvajanja orodij.
- **Spremljanje izvajanja**: Spremljajte izvajanje orodij glede nenavadnega vedenja, porabe virov in varnostnih kršitev.

### 11. Nenehna varnostna validacija
- **Avtomatizirano varnostno testiranje**: Integrirajte varnostno testiranje v CI/CD procese z orodji, kot je GitHub Advanced Security.
- **Upravljanje ranljivosti**: Redno pregledujte vse odvisnosti, vključno z AI modeli in zunanjimi storitvami.
- **Penetracijsko testiranje**: Redno izvajajte varnostne ocene, posebej usmerjene na MCP implementacije.
- **Pregledi varnostne kode**: Uvedite obvezne varnostne preglede za vse spremembe kode, povezane z MCP.

### 12. Varnost dobavne verige za AI
- **Preverjanje komponent**: Preverite izvor, integriteto in varnost vseh AI komponent (modelov, vdelav, API-jev).
- **Upravljanje odvisnosti**: Vzdržujte trenutne sezname vseh programsko-opremskih in AI odvisnosti z beleženjem ranljivosti.
- **Zaupanja vredni repozitoriji**: Uporabljajte preverjene, zaupanja vredne vire za vse AI modele, knjižnice in orodja.
- **Spremljanje dobavne verige**: Nenehno spremljajte morebitne kompromise pri ponudnikih AI storitev in repozitorijih modelov.

## Napredni varnostni vzorci

### Arhitektura Zero Trust za MCP
- **Nikoli ne zaupaj, vedno preverjaj**: Uvedite stalno preverjanje za vse MCP udeležence.
- **Mikrosegmentacija**: Izolirajte MCP komponente z granularnimi omrežnimi in identitetnimi kontrolami.
- **Pogojni dostop**: Uvedite nadzor dostopa, ki temelji na tveganju in se prilagaja kontekstu ter vedenju.
- **Nenehna ocena tveganja**: Dinamično ocenjujte varnostno stanje na podlagi trenutnih indikatorjev groženj.

### Implementacija AI z ohranjanjem zasebnosti
- **Minimizacija podatkov**: Razkrijte le minimalno potrebne podatke za vsako MCP operacijo.
- **Diferencialna zasebnost**: Uvedite tehnike za ohranjanje zasebnosti pri obdelavi občutljivih podatkov.
- **Homomorfno šifriranje**: Uporabljajte napredne šifrirne tehnike za varno računanje na šifriranih podatkih.
- **Federativno učenje**: Uvedite porazdeljene pristope učenja, ki ohranjajo lokalnost in zasebnost podatkov.

### Odziv na incidente za AI sisteme
- **Postopki specifični za AI incidente**: Razvijte postopke odziva na incidente, prilagojene grožnjam, specifičnim za AI in MCP.
- **Avtomatiziran odziv**: Uvedite avtomatizirano zadrževanje in odpravljanje za pogoste AI varnostne incidente.  
- **Forenzične zmogljivosti**: Zagotovite pripravljenost na forenzične preiskave kompromisov AI sistemov in kršitev podatkov.
- **Postopki za obnovitev**: Vzpostavite postopke za obnovitev po zastrupitvi AI modelov, napadih z vbrizgavanjem pozivov in kompromisih storitev.

## Viri za implementacijo in standardi

### Uradna dokumentacija MCP
- [MCP Specifikacija 2025-06-18](https://spec.modelcontextprotocol.io/specification/2025-06-18/) - Trenutna specifikacija MCP protokola
- [MCP Najboljše varnostne prakse](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices) - Uradna varnostna navodila
- [MCP Specifikacija avtorizacije](https://modelcontextprotocol.io/specification/2025-06-18/basic/authorization) - Vzorci avtentikacije in avtorizacije
- [MCP Transportna varnost](https://modelcontextprotocol.io/specification/2025-06-18/transports/) - Zahteve za varnost transportne plasti

### Microsoftove varnostne rešitve
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection) - Napredna zaščita pred vbrizgavanjem pozivov
- [Azure Content Safety](https://learn.microsoft.com/azure/ai-services/content-safety/) - Celovito filtriranje vsebine AI
- [Microsoft Entra ID](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow) - Upravljanje identitete in dostopa za podjetja
- [Azure Key Vault](https://learn.microsoft.com/azure/key-vault/general/basic-concepts) - Varno upravljanje skrivnosti in poverilnic
- [GitHub Advanced Security](https://github.com/security/advanced-security) - Pregled varnosti kode in dobavne verige

### Varnostni standardi in okviri
- [OAuth 2.1 Najboljše varnostne prakse](https://datatracker.ietf.org/doc/html/draft-ietf-oauth-security-topics) - Trenutna navodila za varnost OAuth
- [OWASP Top 10](https://owasp.org/www-project-top-ten/) - Tveganja za spletne aplikacije
- [OWASP Top 10 za LLM-je](https://genai.owasp.org/download/43299/?tmstv=1731900559) - Varnostna tveganja, specifična za AI
- [NIST Okvir za upravljanje tveganj AI](https://www.nist.gov/itl/ai-risk-management-framework) - Celovito upravljanje tveganj AI
- [ISO 27001:2022](https://www.iso.org/standard/27001) - Sistemi za upravljanje informacijske varnosti

### Vodniki za implementacijo in vadnice
- [Azure API Management kot MCP Auth Gateway](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) - Vzorci avtentikacije za podjetja
- [Microsoft Entra ID z MCP strežniki](https://den.dev/blog/mcp-server-auth-entra-id-session/) - Integracija ponudnikov identitete
- [Implementacija varnega shranjevanja žetonov](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2) - Najboljše prakse za upravljanje žetonov
- [Šifriranje od konca do konca za AI](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption) - Napredni vzorci šifriranja

### Napredni varnostni viri
- [Microsoftov življenjski cikel razvoja varnosti](https://www.microsoft.com/sdl) - Prakse za varen razvoj
- [Vodnik za AI Red Team](https://learn.microsoft.com/security/ai-red-team/) - Testiranje varnosti, specifično za AI
- [Modeliranje groženj za AI sisteme](https://learn.microsoft.com/security/adoption/approach/threats-ai) - Metodologija modeliranja groženj AI
- [Inženiring zasebnosti za AI](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/) - Tehnike za ohranjanje zasebnosti AI

### Skladnost in upravljanje
- [Skladnost z GDPR za AI](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments) - Skladnost zasebnosti v AI sistemih
- [Okvir za upravljanje AI](https://learn.microsoft.com/azure/architecture/guide/responsible-ai/responsible-ai-overview) - Implementacija odgovornega AI
- [SOC 2 za AI storitve](https://learn.microsoft.com/compliance/regulatory/offering-soc) - Varnostni ukrepi za ponudnike AI storitev
- [Skladnost z HIPAA za AI](https://learn.microsoft.com/compliance/regulatory/offering-hipaa-hitech) - Zahteve za skladnost AI v zdravstvu

### DevSecOps in avtomatizacija
- [DevSecOps cevovod za AI](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline) - Varni razvojni cevovodi za AI
- [Avtomatizirano varnostno testiranje](https://learn.microsoft.com/security/engineering/devsecops) - Nenehna varnostna
- **Razvoj orodij**: Razvijajte in delite varnostna orodja ter knjižnice za ekosistem MCP

---

*Ta dokument odraža najboljše prakse za varnost MCP na dan 18. avgust 2025, skladno s specifikacijo MCP 2025-06-18. Varnostne prakse je treba redno pregledovati in posodabljati, saj se protokol in grožnje nenehno razvijajo.*

**Izjava o omejitvi odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za strojno prevajanje [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku je treba obravnavati kot avtoritativni vir. Za ključne informacije priporočamo strokovno človeško prevajanje. Ne prevzemamo odgovornosti za morebitna nesporazumevanja ali napačne razlage, ki izhajajo iz uporabe tega prevoda.