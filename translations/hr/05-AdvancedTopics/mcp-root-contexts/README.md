<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8311f46a35cf608c9780f39b62c9dc3f",
  "translation_date": "2025-07-14T02:07:49+00:00",
  "source_file": "05-AdvancedTopics/mcp-root-contexts/README.md",
  "language_code": "hr"
}
-->
## Primjer: Implementacija Root Contexta za financijsku analizu

U ovom primjeru ćemo kreirati root context za sesiju financijske analize, pokazujući kako održavati stanje kroz više interakcija.

## Primjer: Upravljanje Root Contextom

Učinkovito upravljanje root contextima ključno je za održavanje povijesti razgovora i stanja. Ispod je primjer kako implementirati upravljanje root contextom.

## Root Context za Višekratnu Pomoć

U ovom primjeru ćemo kreirati root context za sesiju višekratne pomoći, pokazujući kako održavati stanje kroz više interakcija.

## Najbolje prakse za Root Context

Evo nekoliko najboljih praksi za učinkovito upravljanje root contextima:

- **Kreirajte fokusirane kontekte**: Kreirajte zasebne root contexte za različite svrhe razgovora ili domene kako biste održali jasnoću.

- **Postavite politike isteka**: Implementirajte politike za arhiviranje ili brisanje starih konteksta radi upravljanja prostorom i usklađenosti s pravilima čuvanja podataka.

- **Spremite relevantne metapodatke**: Koristite metapodatke konteksta za pohranu važnih informacija o razgovoru koje bi mogle biti korisne kasnije.

- **Dosljedno koristite ID konteksta**: Nakon što je kontekst kreiran, dosljedno koristite njegov ID za sve povezane zahtjeve kako biste održali kontinuitet.

- **Generirajte sažetke**: Kada kontekst postane velik, razmislite o generiranju sažetaka koji hvataju bitne informacije uz upravljanje veličinom konteksta.

- **Implementirajte kontrolu pristupa**: Za sustave s više korisnika, implementirajte odgovarajuće kontrole pristupa kako biste osigurali privatnost i sigurnost konteksta razgovora.

- **Rukujte ograničenjima konteksta**: Budite svjesni ograničenja veličine konteksta i implementirajte strategije za rukovanje vrlo dugim razgovorima.

- **Arhivirajte kada je završeno**: Arhivirajte kontekste kada su razgovori završeni kako biste oslobodili resurse, a pritom sačuvali povijest razgovora.

## Što slijedi

- [5.5 Routing](../mcp-routing/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.