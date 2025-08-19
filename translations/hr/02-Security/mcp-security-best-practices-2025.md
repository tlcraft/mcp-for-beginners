<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c3f4ea5732d64bf965e8aa2907759709",
  "translation_date": "2025-07-17T13:47:33+00:00",
  "source_file": "02-Security/mcp-security-best-practices-2025.md",
  "language_code": "hr"
}
-->
# MCP Sigurnosne Najbolje Prakse - Ažuriranje za kolovoz 2025.

> **Važno**: Ovaj dokument odražava najnovije [MCP Specifikacije 2025-06-18](https://spec.modelcontextprotocol.io/specification/2025-06-18/) sigurnosne zahtjeve i službene [MCP Sigurnosne Najbolje Prakse](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices). Uvijek se oslonite na trenutnu specifikaciju za najnovije smjernice.

## Osnovne Sigurnosne Prakse za MCP Implementacije

Prilikom rada s MCP serverima, slijedite ove sigurnosne najbolje prakse kako biste zaštitili svoje podatke, infrastrukturu i korisnike:

1. **Validacija Unosa**: Uvijek provjeravajte i sanitizirajte unose kako biste spriječili injekcijske napade i probleme s neovlaštenim pristupom.
   - Implementirajte strogu validaciju za sve parametre alata
   - Koristite validaciju sheme kako biste osigurali da zahtjevi odgovaraju očekivanim formatima
   - Filtrirajte potencijalno zlonamjerni sadržaj prije obrade

2. **Kontrola Pristupa**: Implementirajte ispravnu autentifikaciju i autorizaciju za svoj MCP server s detaljnim dopuštenjima.
   - Koristite OAuth 2.0 s etabliranim pružateljima identiteta poput Microsoft Entra ID
   - Implementirajte kontrolu pristupa temeljenu na ulogama (RBAC) za MCP alate
   - Nikada ne implementirajte vlastitu autentifikaciju ako postoje etablirana rješenja

3. **Sigurna Komunikacija**: Koristite HTTPS/TLS za svu komunikaciju s MCP serverom i razmotrite dodatno šifriranje za osjetljive podatke.
   - Konfigurirajte TLS 1.3 gdje je moguće
   - Implementirajte pinning certifikata za kritične veze
   - Redovito rotirajte certifikate i provjeravajte njihovu valjanost

4. **Ograničenje Brzine (Rate Limiting)**: Implementirajte ograničenje brzine kako biste spriječili zloupotrebe, DoS napade i upravljali potrošnjom resursa.
   - Postavite odgovarajuće limite zahtjeva prema očekivanim obrascima korištenja
   - Implementirajte postupne odgovore na prekomjerne zahtjeve
   - Razmotrite ograničenja brzine specifična za korisnike na temelju statusa autentifikacije

5. **Evidencija i Praćenje**: Pratite svoj MCP server zbog sumnjivih aktivnosti i implementirajte sveobuhvatne revizijske zapise.
   - Zabilježite sve pokušaje autentifikacije i pozive alata
   - Implementirajte upozorenja u stvarnom vremenu za sumnjive obrasce
   - Osigurajte da su zapisi sigurno pohranjeni i da im se ne može manipulirati

6. **Sigurna Pohrana**: Zaštitite osjetljive podatke i vjerodajnice odgovarajućim šifriranjem u mirovanju.
   - Koristite key vaultove ili sigurne spremišta vjerodajnica za sve tajne podatke
   - Implementirajte šifriranje na razini polja za osjetljive podatke
   - Redovito rotirajte ključeve za šifriranje i vjerodajnice

7. **Upravljanje Tokenima**: Spriječite ranjivosti povezane s prosljeđivanjem tokena validacijom i sanitizacijom svih ulaza i izlaza modela.
   - Implementirajte validaciju tokena na temelju audience tvrdnji
   - Nikada ne prihvaćajte tokene koji nisu izričito izdani za vaš MCP server
   - Implementirajte pravilno upravljanje životnim ciklusom tokena i njihovu rotaciju

8. **Upravljanje Sesijama**: Implementirajte sigurno upravljanje sesijama kako biste spriječili otmicu i fiksaciju sesija.
   - Koristite sigurne, nedeterminističke ID-eve sesija
   - Povežite sesije s informacijama specifičnim za korisnika
   - Implementirajte pravilno isteka i rotaciju sesija

9. **Izolacija Izvršavanja Alata**: Pokrećite izvršavanje alata u izoliranim okruženjima kako biste spriječili lateralno kretanje u slučaju kompromitacije.
   - Implementirajte izolaciju kontejnera za izvršavanje alata
   - Primijenite ograničenja resursa kako biste spriječili napade iscrpljivanja resursa
   - Koristite odvojene kontekste izvršavanja za različite sigurnosne domene

10. **Redovite Sigurnosne Revizije**: Provodite periodične sigurnosne preglede svojih MCP implementacija i ovisnosti.
    - Planirajte redovito testiranje penetracije
    - Koristite automatizirane alate za skeniranje ranjivosti
    - Održavajte ovisnosti ažuriranima kako biste riješili poznate sigurnosne probleme

11. **Filtriranje Sigurnosti Sadržaja**: Implementirajte filtre sigurnosti sadržaja za ulaze i izlaze.
    - Koristite Azure Content Safety ili slične usluge za otkrivanje štetnog sadržaja
    - Implementirajte tehnike zaštite prompta kako biste spriječili injekciju prompta
    - Skenirajte generirani sadržaj zbog potencijalnog curenja osjetljivih podataka

12. **Sigurnost Lanca Opskrbe**: Provjerite integritet i autentičnost svih komponenti u vašem AI lancu opskrbe.
    - Koristite potpisane pakete i provjeravajte potpise
    - Implementirajte analizu software bill of materials (SBOM)
    - Pratite zlonamjerne nadogradnje ovisnosti

13. **Zaštita Definicije Alata**: Spriječite trovanje alata osiguravanjem definicija alata i metapodataka.
    - Validirajte definicije alata prije upotrebe
    - Pratite neočekivane promjene u metapodacima alata
    - Implementirajte provjere integriteta definicija alata

14. **Dinamičko Praćenje Izvršavanja**: Pratite ponašanje MCP servera i alata tijekom rada.
    - Implementirajte analizu ponašanja za otkrivanje anomalija
    - Postavite upozorenja za neočekivane obrasce izvršavanja
    - Koristite tehnike runtime application self-protection (RASP)

15. **Načelo Najmanjih Povlastica**: Osigurajte da MCP serveri i alati rade s minimalnim potrebnim dopuštenjima.
    - Dodijelite samo specifična dopuštenja potrebna za svaku operaciju
    - Redovito pregledavajte i revidirajte korištenje dopuštenja
    - Implementirajte pristup po potrebi (just-in-time) za administrativne funkcije

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo postići točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakve nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.