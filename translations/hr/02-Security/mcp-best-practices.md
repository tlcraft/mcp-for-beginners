<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b2b9e15e78b9d9a2b3ff3e8fd7d1f434",
  "translation_date": "2025-08-18T22:07:04+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "hr"
}
-->
# MCP Sigurnosne Najbolje Prakse 2025

Ovaj sveobuhvatni vodič opisuje ključne sigurnosne najbolje prakse za implementaciju sustava Model Context Protocol (MCP) temeljenih na najnovijoj **MCP Specifikaciji 2025-06-18** i trenutnim industrijskim standardima. Ove prakse obuhvaćaju tradicionalne sigurnosne izazove kao i prijetnje specifične za AI koje su jedinstvene za MCP implementacije.

## Kritični Sigurnosni Zahtjevi

### Obavezne Sigurnosne Kontrole (MUST Zahtjevi)

1. **Validacija Tokena**: MCP serveri **NE SMIJU** prihvaćati tokene koji nisu izričito izdani za MCP server
2. **Provjera Autorizacije**: MCP serveri koji implementiraju autorizaciju **MORAJU** provjeriti SVE dolazne zahtjeve i **NE SMIJU** koristiti sesije za autentifikaciju  
3. **Korisnički Pristanak**: MCP proxy serveri koji koriste statične ID-ove klijenata **MORAJU** dobiti izričit pristanak korisnika za svakog dinamički registriranog klijenta
4. **Sigurni ID-ovi Sesija**: MCP serveri **MORAJU** koristiti kriptografski sigurne, nedeterminističke ID-ove sesija generirane pomoću sigurnih generatora slučajnih brojeva

## Osnovne Sigurnosne Prakse

### 1. Validacija i Sanitizacija Unosa
- **Sveobuhvatna Validacija Unosa**: Validirajte i sanitizirajte sve unose kako biste spriječili napade ubrizgavanja, probleme s konfuznim posrednicima i ranjivosti ubrizgavanja prompta
- **Provođenje Sheme Parametara**: Implementirajte strogu validaciju JSON sheme za sve parametre alata i API unose
- **Filtriranje Sadržaja**: Koristite Microsoft Prompt Shields i Azure Content Safety za filtriranje zlonamjernog sadržaja u promptovima i odgovorima
- **Sanitizacija Izlaza**: Validirajte i sanitizirajte sve izlaze modela prije nego što ih prikažete korisnicima ili sustavima nizvodno

### 2. Izvrsnost u Autentifikaciji i Autorizaciji  
- **Vanjski Pružatelji Identiteta**: Delegirajte autentifikaciju etabliranim pružateljima identiteta (Microsoft Entra ID, OAuth 2.1 pružatelji) umjesto implementacije prilagođene autentifikacije
- **Fino-granularne Dozvole**: Implementirajte granularne, alat-specifične dozvole slijedeći načelo najmanjih privilegija
- **Upravljanje Životnim Ciklusom Tokena**: Koristite kratkotrajne pristupne tokene s sigurnom rotacijom i pravilnom validacijom publike
- **Višefaktorska Autentifikacija**: Zahtijevajte MFA za sav administrativni pristup i osjetljive operacije

### 3. Sigurni Komunikacijski Protokoli
- **Sigurnost Transportnog Sloja**: Koristite HTTPS/TLS 1.3 za sve MCP komunikacije uz pravilnu validaciju certifikata
- **End-to-End Enkripcija**: Implementirajte dodatne slojeve enkripcije za vrlo osjetljive podatke u prijenosu i mirovanju
- **Upravljanje Certifikatima**: Održavajte pravilno upravljanje životnim ciklusom certifikata uz automatizirane procese obnove
- **Provođenje Verzije Protokola**: Koristite trenutnu MCP verziju protokola (2025-06-18) uz pravilnu pregovaranje verzije

### 4. Napredno Ograničavanje Stope i Zaštita Resursa
- **Višeslojno Ograničavanje Stope**: Implementirajte ograničavanje stope na razini korisnika, sesije, alata i resursa kako biste spriječili zloupotrebu
- **Adaptivno Ograničavanje Stope**: Koristite ograničavanje stope temeljeno na strojnome učenju koje se prilagođava obrascima korištenja i pokazateljima prijetnji
- **Upravljanje Kvotama Resursa**: Postavite odgovarajuće limite za računalne resurse, korištenje memorije i vrijeme izvršenja
- **Zaštita od DDoS Napada**: Implementirajte sveobuhvatnu zaštitu od DDoS napada i sustave za analizu prometa

### 5. Sveobuhvatno Logiranje i Praćenje
- **Strukturirano Logiranje Audita**: Implementirajte detaljne, pretražive logove za sve MCP operacije, izvršenja alata i sigurnosne događaje
- **Praćenje Sigurnosti u Stvarnom Vremenu**: Implementirajte SIEM sustave s AI-pogonom za otkrivanje anomalija u MCP radnim opterećenjima
- **Logiranje u Skladu s Privatnošću**: Logirajte sigurnosne događaje uz poštivanje zahtjeva i regulativa o privatnosti podataka
- **Integracija Odgovora na Incidente**: Povežite sustave logiranja s automatiziranim tijekovima odgovora na incidente

### 6. Poboljšane Prakse Sigurnog Pohranjivanja
- **Hardverski Sigurnosni Moduli**: Koristite HSM-podržano pohranjivanje ključeva (Azure Key Vault, AWS CloudHSM) za ključne kriptografske operacije
- **Upravljanje Kriptografskim Ključevima**: Implementirajte pravilnu rotaciju ključeva, segregaciju i kontrole pristupa za ključeve
- **Upravljanje Tajnama**: Pohranite sve API ključeve, tokene i vjerodajnice u namjenske sustave za upravljanje tajnama
- **Klasifikacija Podataka**: Klasificirajte podatke prema razinama osjetljivosti i primijenite odgovarajuće mjere zaštite

### 7. Napredno Upravljanje Tokenima
- **Sprječavanje Prosljeđivanja Tokena**: Izričito zabranite obrasce prosljeđivanja tokena koji zaobilaze sigurnosne kontrole
- **Validacija Publike**: Uvijek provjerite tvrdnje o publici tokena kako bi odgovarale identitetu namijenjenog MCP servera
- **Autorizacija Temeljena na Tvrdnjama**: Implementirajte fino-granularnu autorizaciju temeljenu na tvrdnjama tokena i atributima korisnika
- **Vezivanje Tokena**: Vežite tokene za specifične sesije, korisnike ili uređaje gdje je to prikladno

### 8. Sigurno Upravljanje Sesijama
- **Kriptografski Sigurni ID-ovi Sesija**: Generirajte ID-ove sesija koristeći kriptografski sigurne generatore slučajnih brojeva (ne predvidljive sekvence)
- **Korisničko Vezivanje**: Vežite ID-ove sesija za korisničke specifične informacije koristeći sigurne formate poput `<user_id>:<session_id>`
- **Kontrole Životnog Ciklusa Sesija**: Implementirajte pravilno istecanje, rotaciju i poništavanje sesija
- **Sigurnosni Zaglavlja Sesija**: Koristite odgovarajuća HTTP sigurnosna zaglavlja za zaštitu sesija

### 9. Sigurnosne Kontrole Specifične za AI
- **Obrana od Ubrizgavanja Promptova**: Implementirajte Microsoft Prompt Shields s tehnikama poput spotlightinga, delimitera i označavanja podataka
- **Prevencija Trovanja Alata**: Validirajte metapodatke alata, pratite dinamičke promjene i provjeravajte integritet alata
- **Validacija Izlaza Modela**: Skenirajte izlaze modela na potencijalno curenje podataka, štetan sadržaj ili kršenja sigurnosnih politika
- **Zaštita Kontekstualnog Prozora**: Implementirajte kontrole za sprječavanje trovanja i manipulacije kontekstualnim prozorom

### 10. Sigurnost Izvršenja Alata
- **Izolacija Izvršenja**: Pokrećite izvršenja alata u kontejneriziranim, izoliranim okruženjima s ograničenjima resursa
- **Razdvajanje Privilegija**: Izvršavajte alate s minimalnim potrebnim privilegijama i odvojenim korisničkim računima
- **Izolacija Mreže**: Implementirajte segmentaciju mreže za okruženja izvršenja alata
- **Praćenje Izvršenja**: Pratite izvršenje alata na anomalno ponašanje, korištenje resursa i sigurnosna kršenja

### 11. Kontinuirana Validacija Sigurnosti
- **Automatizirano Sigurnosno Testiranje**: Integrirajte sigurnosno testiranje u CI/CD procese koristeći alate poput GitHub Advanced Security
- **Upravljanje Ranjivostima**: Redovito skenirajte sve ovisnosti, uključujući AI modele i vanjske usluge
- **Penetracijsko Testiranje**: Redovito provodite sigurnosne procjene usmjerene na MCP implementacije
- **Sigurnosne Revizije Koda**: Implementirajte obavezne sigurnosne revizije za sve promjene koda povezane s MCP-om

### 12. Sigurnost Opskrbnog Lanca za AI
- **Verifikacija Komponenti**: Provjerite porijeklo, integritet i sigurnost svih AI komponenti (modela, ugradbi, API-ja)
- **Upravljanje Ovisnostima**: Održavajte ažurirane inventare svih softverskih i AI ovisnosti uz praćenje ranjivosti
- **Pouzdani Repozitoriji**: Koristite verificirane, pouzdane izvore za sve AI modele, biblioteke i alate
- **Praćenje Opskrbnog Lanca**: Kontinuirano pratite kompromise kod pružatelja AI usluga i repozitorija modela

## Napredni Sigurnosni Obrasci

### Zero Trust Arhitektura za MCP
- **Nikad Ne Vjeruj, Uvijek Provjeravaj**: Implementirajte kontinuiranu provjeru za sve MCP sudionike
- **Mikro-segmentacija**: Izolirajte MCP komponente s granularnim mrežnim i identitetskim kontrolama
- **Uvjetovani Pristup**: Implementirajte kontrole pristupa temeljene na riziku koje se prilagođavaju kontekstu i ponašanju
- **Kontinuirana Procjena Rizika**: Dinamički procjenjujte sigurnosno stanje na temelju trenutnih pokazatelja prijetnji

### Privatnost-prijateljska Implementacija AI-a
- **Minimizacija Podataka**: Izlažite samo minimalno potrebne podatke za svaku MCP operaciju
- **Diferencijalna Privatnost**: Implementirajte tehnike očuvanja privatnosti za obradu osjetljivih podataka
- **Homomorfna Enkripcija**: Koristite napredne tehnike enkripcije za sigurnu obradu šifriranih podataka
- **Federativno Učenje**: Implementirajte distribuirane pristupe učenju koji čuvaju lokalitet i privatnost podataka

### Odgovor na Incidente za AI Sustave
- **Postupci Specifični za AI Incidente**: Razvijte postupke odgovora na incidente prilagođene prijetnjama specifičnim za AI i MCP
- **Automatizirani Odgovor**: Implementirajte automatizirano ograničavanje i sanaciju za uobičajene AI sigurnosne incidente  
- **Forenzičke Sposobnosti**: Održavajte forenzičku spremnost za kompromise AI sustava i curenje podataka
- **Postupci Oporavka**: Uspostavite postupke za oporavak od trovanja AI modela, napada ubrizgavanja prompta i kompromitacija usluga

## Resursi za Implementaciju i Standardi

### Službena MCP Dokumentacija
- [MCP Specifikacija 2025-06-18](https://spec.modelcontextprotocol.io/specification/2025-06-18/) - Trenutna MCP specifikacija protokola
- [MCP Sigurnosne Najbolje Prakse](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices) - Službene sigurnosne smjernice
- [MCP Specifikacija Autorizacije](https://modelcontextprotocol.io/specification/2025-06-18/basic/authorization) - Obrasci autentifikacije i autorizacije
- [MCP Sigurnost Transporta](https://modelcontextprotocol.io/specification/2025-06-18/transports/) - Zahtjevi za sigurnost transportnog sloja

### Microsoft Sigurnosna Rješenja
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection) - Napredna zaštita od ubrizgavanja prompta
- [Azure Content Safety](https://learn.microsoft.com/azure/ai-services/content-safety/) - Sveobuhvatno filtriranje AI sadržaja
- [Microsoft Entra ID](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow) - Upravljanje identitetom i pristupom za poduzeća
- [Azure Key Vault](https://learn.microsoft.com/azure/key-vault/general/basic-concepts) - Sigurno upravljanje tajnama i vjerodajnicama
- [GitHub Advanced Security](https://github.com/security/advanced-security) - Sigurnosno skeniranje opskrbnog lanca i koda

### Sigurnosni Standardi i Okviri
- [OAuth 2.1 Sigurnosne Najbolje Prakse](https://datatracker.ietf.org/doc/html/draft-ietf-oauth-security-topics) - Trenutne smjernice za OAuth sigurnost
- [OWASP Top 10](https://owasp.org/www-project-top-ten/) - Rizici sigurnosti web aplikacija
- [OWASP Top 10 za LLM-ove](https://genai.owasp.org/download/43299/?tmstv=1731900559) - AI-specifični sigurnosni rizici
- [NIST Okvir za Upravljanje Rizicima AI-a](https://www.nist.gov/itl/ai-risk-management-framework) - Sveobuhvatno upravljanje rizicima AI-a
- [ISO 27001:2022](https://www.iso.org/standard/27001) - Sustavi upravljanja informacijskom sigurnošću

### Vodiči za Implementaciju i Tutorijali
- [Azure API Management kao MCP Auth Gateway](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) - Obrasci autentifikacije za poduzeća
- [Microsoft Entra ID s MCP Serverima](https://den.dev/blog/mcp-server-auth-entra-id-session/) - Integracija pružatelja identiteta
- [Implementacija Sigurnog Pohranjivanja Tokena](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2) - Najbolje prakse upravljanja tokenima
- [End-to-End Enkripcija za AI](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption) - Napredni obrasci enkripcije

### Napredni Sigurnosni Resursi
- [Microsoft Sigurnosni Razvojni Ciklus](https://www.microsoft.com/sdl) - Prakse sigurnog razvoja
- [AI Red Team Smjernice](https://learn.microsoft.com/security/ai-red-team/) - AI-specifično sigurnosno testiranje
- [Modeliranje Prijetnji za AI Sustave](https://learn.microsoft.com/security/adoption/approach/threats-ai) - Metodologija modeliranja prijetnji za AI
- [Inženjering Privatnosti za AI](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/) - Tehnike očuvanja privatnosti za AI

### Usklađenost i Upravljanje
- [GDPR Usklađenost za AI](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments) - Usklađenost privatnosti u AI sustavima
- [Okvir za Upravljanje AI-om](https://learn.microsoft.com/azure/architecture/guide/responsible-ai/responsible-ai-overview) - Implementacija odgovornog AI-a
- [SOC 2 za AI Usluge](https://learn.microsoft.com/compliance/regulatory/offering-soc) - Sigurnosne kontrole za pružatelje AI usluga
- [HIPAA Usklađenost za AI](https://learn.microsoft.com/compliance/regulatory/offering-hipaa-hitech) - Zahtjevi za usklađenost AI-a u zdravstvu

### DevSecOps i Automatizacija
- [DevSecOps Cjevovod za AI](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline) - Sigurni razvojni cjevovodi za AI
- [Automatizirano Sigurnosno Testiranje](https://learn.microsoft.com/security/engineering/devsecops) - Kontinuirana sigurnosna validacija
- [Sigurnost Infrastrukture kao Koda](https://learn.microsoft.com/security/engineering/infrastructure-security) -
- **Razvoj alata**: Razvijajte i dijelite sigurnosne alate i biblioteke za MCP ekosustav

---

*Ovaj dokument odražava najbolje sigurnosne prakse za MCP na dan 18. kolovoza 2025., temeljene na MCP specifikaciji 2025-06-18. Sigurnosne prakse treba redovito pregledavati i ažurirati kako se protokol i krajolik prijetnji razvijaju.*

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden pomoću AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo osigurati točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za ključne informacije preporučuje se profesionalni prijevod od strane čovjeka. Ne preuzimamo odgovornost za nesporazume ili pogrešna tumačenja koja mogu proizaći iz korištenja ovog prijevoda.