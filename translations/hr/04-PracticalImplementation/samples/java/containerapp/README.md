<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e5ea5e7582f70008ea9bec3b3820f20a",
  "translation_date": "2025-05-17T14:32:51+00:00",
  "source_file": "04-PracticalImplementation/samples/java/containerapp/README.md",
  "language_code": "hr"
}
-->
## Arhitektura sustava

Ovaj projekt prikazuje web aplikaciju koja koristi provjeru sigurnosti sadržaja prije nego što proslijedi korisničke upite kalkulatorskoj usluzi putem Model Context Protocola (MCP).

### Kako funkcionira

1. **Korisnički unos**: Korisnik unosi upit za izračun u web sučelje
2. **Provjera sigurnosti sadržaja (unos)**: Upit se analizira pomoću Azure Content Safety API-ja
3. **Odluka o sigurnosti (unos)**:
   - Ako je sadržaj siguran (težina < 2 u svim kategorijama), nastavlja se do kalkulatora
   - Ako je sadržaj označen kao potencijalno štetan, proces se zaustavlja i vraća upozorenje
4. **Integracija kalkulatora**: Siguran sadržaj obrađuje LangChain4j, koji komunicira s MCP kalkulatorskim serverom
5. **Provjera sigurnosti sadržaja (izlaz)**: Odgovor bota se analizira pomoću Azure Content Safety API-ja
6. **Odluka o sigurnosti (izlaz)**:
   - Ako je odgovor bota siguran, prikazuje se korisniku
   - Ako je odgovor bota označen kao potencijalno štetan, zamjenjuje se upozorenjem
7. **Odgovor**: Rezultati (ako su sigurni) prikazuju se korisniku zajedno s analizama sigurnosti

## Korištenje Model Context Protocola (MCP) s kalkulatorskim uslugama

Ovaj projekt prikazuje kako koristiti Model Context Protocol (MCP) za pozivanje MCP kalkulatorskih usluga iz LangChain4j. Implementacija koristi lokalni MCP server koji radi na portu 8080 za pružanje kalkulatorskih operacija.

### Postavljanje Azure Content Safety usluge

Prije korištenja značajki sigurnosti sadržaja, potrebno je stvoriti resurs za Azure Content Safety uslugu:

1. Prijavite se na [Azure Portal](https://portal.azure.com)
2. Kliknite "Create a resource" i potražite "Content Safety"
3. Odaberite "Content Safety" i kliknite "Create"
4. Unesite jedinstveno ime za svoj resurs
5. Odaberite svoju pretplatu i grupu resursa (ili stvorite novu)
6. Odaberite podržanu regiju (provjerite [Region availability](https://azure.microsoft.com/en-us/global-infrastructure/services/?products=cognitive-services) za detalje)
7. Odaberite odgovarajući cjenovni razred
8. Kliknite "Create" za implementaciju resursa
9. Nakon završetka implementacije, kliknite "Go to resource"
10. U lijevom izborniku, pod "Resource Management", odaberite "Keys and Endpoint"
11. Kopirajte jedan od ključeva i URL krajnje točke za korištenje u sljedećem koraku

### Konfiguriranje varijabli okruženja

Postavite `GITHUB_TOKEN` varijablu okruženja za autentifikaciju GitHub modela:
```sh
export GITHUB_TOKEN=<your_github_token>
```

Za značajke sigurnosti sadržaja, postavite:
```sh
export CONTENT_SAFETY_ENDPOINT=<your_content_safety_endpoint>
export CONTENT_SAFETY_KEY=<your_content_safety_key>
```

Ove varijable okruženja koristi aplikacija za autentifikaciju s Azure Content Safety uslugom. Ako ove varijable nisu postavljene, aplikacija će koristiti vrijednosti za demonstraciju, ali značajke sigurnosti sadržaja neće pravilno raditi.

### Pokretanje MCP kalkulatorskog servera

Prije pokretanja klijenta, potrebno je pokrenuti MCP kalkulatorski server u SSE modu na localhost:8080.

## Opis projekta

Ovaj projekt prikazuje integraciju Model Context Protocola (MCP) s LangChain4j za pozivanje kalkulatorskih usluga. Ključne značajke uključuju:

- Korištenje MCP-a za povezivanje s kalkulatorskom uslugom za osnovne matematičke operacije
- Dvostruka provjera sigurnosti sadržaja na korisničkim upitima i odgovorima bota
- Integracija s GitHub-ovim gpt-4.1-nano modelom putem LangChain4j
- Korištenje Server-Sent Events (SSE) za MCP prijenos

## Integracija sigurnosti sadržaja

Projekt uključuje sveobuhvatne značajke sigurnosti sadržaja kako bi se osiguralo da su i korisnički unosi i odgovori sustava bez štetnog sadržaja:

1. **Provjera unosa**: Svi korisnički upiti analiziraju se za kategorije štetnog sadržaja poput govora mržnje, nasilja, samoozljeđivanja i seksualnog sadržaja prije obrade.

2. **Provjera izlaza**: Čak i kada se koriste potencijalno necenzurirani modeli, sustav provjerava sve generirane odgovore kroz iste filtre sigurnosti sadržaja prije nego što ih prikaže korisniku.

Ovaj dvostruki pristup osigurava da sustav ostaje siguran bez obzira na to koji AI model se koristi, štiteći korisnike od štetnih unosa i potencijalno problematičnih AI generiranih izlaza.

## Web klijent

Aplikacija uključuje korisnički prilagođeno web sučelje koje omogućuje korisnicima interakciju s Content Safety Calculator sustavom:

### Značajke web sučelja

- Jednostavan, intuitivan obrazac za unos upita za izračun
- Dvostruka provjera sigurnosti sadržaja (unos i izlaz)
- Povratne informacije u stvarnom vremenu o sigurnosti upita i odgovora
- Sigurnosni indikatori u boji za jednostavnu interpretaciju
- Čist, responzivan dizajn koji radi na različitim uređajima
- Primjeri sigurnih upita za vođenje korisnika

### Korištenje web klijenta

1. Pokrenite aplikaciju:
   ```sh
   mvn spring-boot:run
   ```

2. Otvorite preglednik i idite na `http://localhost:8087`

3. Unesite upit za izračun u predviđeno tekstualno polje (npr. "Izračunaj zbroj 24.5 i 17.3")

4. Kliknite "Submit" za obradu zahtjeva

5. Pogledajte rezultate, koji će uključivati:
   - Analizu sigurnosti sadržaja vašeg upita
   - Izračunati rezultat (ako je upit bio siguran)
   - Analizu sigurnosti sadržaja odgovora bota
   - Bilo kakva sigurnosna upozorenja ako je unos ili izlaz označen

Web klijent automatski rukuje oba procesa provjere sigurnosti sadržaja, osiguravajući da su sve interakcije sigurne i prikladne bez obzira na to koji AI model se koristi.

**Odricanje odgovornosti**:  
Ovaj dokument je preveden koristeći AI uslugu prevođenja [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo ka točnosti, molimo vas da budete svjesni da automatizirani prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni prijevod od strane ljudskog prevoditelja. Ne odgovaramo za nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.