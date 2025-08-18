<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8358c13b5b6877e475674697cdc1a904",
  "translation_date": "2025-08-18T22:15:13+00:00",
  "source_file": "03-GettingStarted/02-client/complete_examples.md",
  "language_code": "hr"
}
-->
# Kompletni Primjeri MCP Klijenata

Ovaj direktorij sadrži kompletne, funkcionalne primjere MCP klijenata u različitim programskim jezicima. Svaki klijent demonstrira punu funkcionalnost opisanu u glavnom vodiču README.md.

## Dostupni Klijenti

### 1. Java Klijent (`client_example_java.java`)

- **Transport**: SSE (Server-Sent Events) preko HTTP-a
- **Ciljani Poslužitelj**: `http://localhost:8080`
- **Značajke**:
  - Uspostavljanje veze i ping
  - Popis alata
  - Kalkulatorske operacije (zbrajanje, oduzimanje, množenje, dijeljenje, pomoć)
  - Obrada grešaka i izdvajanje rezultata

**Za pokretanje:**

```bash
# Ensure your MCP server is running on localhost:8080
javac client_example_java.java
java client_example_java
```

### 2. C# Klijent (`client_example_csharp.cs`)

- **Transport**: Stdio (Standardni Ulaz/Izlaz)
- **Ciljani Poslužitelj**: Lokalni .NET MCP poslužitelj putem dotnet run
- **Značajke**:
  - Automatsko pokretanje poslužitelja putem stdio transporta
  - Popis alata i resursa
  - Kalkulatorske operacije
  - Parsiranje rezultata u JSON formatu
  - Sveobuhvatna obrada grešaka

**Za pokretanje:**

```bash
dotnet run
```

### 3. TypeScript Klijent (`client_example_typescript.ts`)

- **Transport**: Stdio (Standardni Ulaz/Izlaz)
- **Ciljani Poslužitelj**: Lokalni Node.js MCP poslužitelj
- **Značajke**:
  - Potpuna podrška za MCP protokol
  - Operacije s alatima, resursima i promptovima
  - Kalkulatorske operacije
  - Čitanje resursa i izvršavanje promptova
  - Robusna obrada grešaka

**Za pokretanje:**

```bash
# First compile TypeScript (if needed)
npm run build

# Then run the client
npm run client
# or
node client_example_typescript.js
```

### 4. Python Klijent (`client_example_python.py`)

- **Transport**: Stdio (Standardni Ulaz/Izlaz)  
- **Ciljani Poslužitelj**: Lokalni Python MCP poslužitelj
- **Značajke**:
  - Async/await obrazac za operacije
  - Otkrivanje alata i resursa
  - Testiranje kalkulatorskih operacija
  - Čitanje sadržaja resursa
  - Organizacija temeljena na klasama

**Za pokretanje:**

```bash
python client_example_python.py
```

## Zajedničke Značajke Svih Klijenata

Svaka implementacija klijenta demonstrira:

1. **Upravljanje Veze**
   - Uspostavljanje veze s MCP poslužiteljem
   - Obrada grešaka pri povezivanju
   - Ispravno čišćenje i upravljanje resursima

2. **Otkrivanje Poslužitelja**
   - Popis dostupnih alata
   - Popis dostupnih resursa (gdje je podržano)
   - Popis dostupnih promptova (gdje je podržano)

3. **Pozivanje Alata**
   - Osnovne kalkulatorske operacije (zbrajanje, oduzimanje, množenje, dijeljenje)
   - Pomoćna naredba za informacije o poslužitelju
   - Ispravno prosljeđivanje argumenata i obrada rezultata

4. **Obrada Grešaka**
   - Greške pri povezivanju
   - Greške pri izvršavanju alata
   - Graciozno rukovanje neuspjesima i povratne informacije korisniku

5. **Obrada Rezultata**
   - Izdvajanje tekstualnog sadržaja iz odgovora
   - Formatiranje izlaza za čitljivost
   - Rukovanje različitim formatima odgovora

## Preduvjeti

Prije pokretanja ovih klijenata, osigurajte da imate:

1. **Pokrenut odgovarajući MCP poslužitelj** (iz `../01-first-server/`)
2. **Instalirane potrebne ovisnosti** za odabrani jezik
3. **Ispravnu mrežnu povezanost** (za transporte temeljene na HTTP-u)

## Ključne Razlike Između Implementacija

| Jezik      | Transport | Pokretanje Poslužitelja | Async Model | Ključne Biblioteke  |
|------------|-----------|-------------------------|-------------|---------------------|
| Java       | SSE/HTTP  | Eksterno                | Sinkrono    | WebFlux, MCP SDK    |
| C#         | Stdio     | Automatski             | Async/Await | .NET MCP SDK        |
| TypeScript | Stdio     | Automatski             | Async/Await | Node MCP SDK        |
| Python     | Stdio     | Automatski             | AsyncIO     | Python MCP SDK      |
| Rust       | Stdio     | Automatski             | Async/Await | Rust MCP SDK, Tokio |

## Sljedeći Koraci

Nakon što istražite ove primjere klijenata:

1. **Prilagodite klijente** kako biste dodali nove značajke ili operacije
2. **Kreirajte vlastiti poslužitelj** i testirajte ga s ovim klijentima
3. **Eksperimentirajte s različitim transportima** (SSE naspram Stdio)
4. **Izgradite složeniju aplikaciju** koja integrira MCP funkcionalnost

## Rješavanje Problema

### Uobičajeni Problemi

1. **Veza odbijena**: Provjerite je li MCP poslužitelj pokrenut na očekivanom portu/putanji
2. **Modul nije pronađen**: Instalirajte potrebni MCP SDK za svoj jezik
3. **Pristup odbijen**: Provjerite dozvole datoteka za stdio transport
4. **Alat nije pronađen**: Provjerite implementira li poslužitelj očekivane alate

### Savjeti za Debugging

1. **Omogućite detaljno logiranje** u svom MCP SDK-u
2. **Provjerite logove poslužitelja** za poruke o greškama
3. **Provjerite nazive i potpise alata** između klijenta i poslužitelja
4. **Testirajte s MCP Inspectorom** kako biste prvo provjerili funkcionalnost poslužitelja

## Povezana Dokumentacija

- [Glavni Vodič za Klijente](./README.md)
- [Primjeri MCP Poslužitelja](../../../../03-GettingStarted/01-first-server)
- [MCP s LLM Integracijom](../../../../03-GettingStarted/03-llm-client)
- [Službena MCP Dokumentacija](https://modelcontextprotocol.io/)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden pomoću AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo osigurati točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za ključne informacije preporučuje se profesionalni prijevod od strane stručnjaka. Ne preuzimamo odgovornost za nesporazume ili pogrešne interpretacije koje mogu proizaći iz korištenja ovog prijevoda.