<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "affcf199a44f60283a289dcb69dc144e",
  "translation_date": "2025-07-17T13:37:05+00:00",
  "source_file": "03-GettingStarted/02-client/complete_examples.md",
  "language_code": "hr"
}
-->
# Kompletni Primjeri MCP Klijenata

Ovaj direktorij sadrži kompletne, funkcionalne primjere MCP klijenata u različitim programskim jezicima. Svaki klijent demonstrira punu funkcionalnost opisanu u glavnom vodiču README.md.

## Dostupni Klijenti

### 1. Java Klijent (`client_example_java.java`)

- **Transport**: SSE (Server-Sent Events) preko HTTP-a
- **Ciljani server**: `http://localhost:8080`
- **Značajke**: 
  - Uspostava veze i ping
  - Popis alata
  - Kalkulator operacije (zbrajanje, oduzimanje, množenje, dijeljenje, pomoć)
  - Obrada pogrešaka i izdvajanje rezultata

**Za pokretanje:**

```bash
# Ensure your MCP server is running on localhost:8080
javac client_example_java.java
java client_example_java
```

### 2. C# klijent (`client_example_csharp.cs`)
- **Transport**: Stdio (standardni ulaz/izlaz)
- **Ciljani server**: Lokalni .NET MCP server preko dotnet run
- **Značajke**:
  - Automatsko pokretanje servera preko stdio transporta
  - Popis alata i resursa
  - Kalkulator operacije
  - Parsiranje JSON rezultata
  - Sveobuhvatna obrada pogrešaka

**Za pokretanje:**

```bash
dotnet run
```

### 3. TypeScript klijent (`client_example_typescript.ts`)
- **Transport**: Stdio (standardni ulaz/izlaz)
- **Ciljani server**: Lokalni Node.js MCP server
- **Značajke**:
  - Potpuna podrška MCP protokola
  - Operacije s alatima, resursima i promptovima
  - Kalkulator operacije
  - Čitanje resursa i izvršavanje promptova
  - Robusna obrada pogrešaka

**Za pokretanje:**

```bash
# First compile TypeScript (if needed)
npm run build

# Then run the client
npm run client
# or
node client_example_typescript.js
```

### 4. Python klijent (`client_example_python.py`)
- **Transport**: Stdio (standardni ulaz/izlaz)  
- **Ciljani server**: Lokalni Python MCP server
- **Značajke**:
  - Async/await obrazac za operacije
  - Otkrivanje alata i resursa
  - Testiranje kalkulator operacija
  - Čitanje sadržaja resursa
  - Organizacija temeljena na klasama

**Za pokretanje:**

```bash
python client_example_python.py
```

## Zajedničke Značajke Svih Klijenata

Svaka implementacija klijenta demonstrira:

1. **Upravljanje vezom**
   - Uspostava veze s MCP serverom
   - Obrada pogrešaka veze
   - Ispravno čišćenje i upravljanje resursima

2. **Otkrivanje servera**
   - Popis dostupnih alata
   - Popis dostupnih resursa (gdje je podržano)
   - Popis dostupnih upita (gdje je podržano)

3. **Pozivanje alata**
   - Osnovne kalkulator operacije (zbrajanje, oduzimanje, množenje, dijeljenje)
   - Pomoćna naredba za informacije o serveru
   - Ispravno prosljeđivanje argumenata i rukovanje rezultatima

4. **Obrada pogrešaka**
   - Pogreške veze
   - Pogreške pri izvršavanju alata
   - Lijepo rukovanje neuspjehom i povratne informacije korisniku

5. **Obrada Rezultata**
   - Izdvajanje tekstualnog sadržaja iz odgovora
   - Formatiranje izlaza za čitljivost
   - Rukovanje različitim formatima odgovora

## Preduvjeti

Prije pokretanja ovih klijenata, osigurajte da imate:

1. **Pokrenut odgovarajući MCP server** (iz `../01-first-server/`)
2. **Instalirane potrebne ovisnosti** za odabrani jezik
3. **Ispravnu mrežnu povezanost** (za transport preko HTTP-a)

## Ključne Razlike Između Implementacija

| Jezik      | Transport | Pokretanje servera | Async model | Ključne biblioteke |
|------------|-----------|--------------------|-------------|--------------------|
| Java       | SSE/HTTP  | Eksterni           | Sinkroni    | WebFlux, MCP SDK   |
| C#         | Stdio     | Automatsko         | Async/Await | .NET MCP SDK       |
| TypeScript | Stdio     | Automatsko         | Async/Await | Node MCP SDK       |
| Python     | Stdio     | Automatsko         | AsyncIO     | Python MCP SDK     |

## Sljedeći Koraci

Nakon što proučite ove primjere klijenata:

1. **Izmijenite klijente** kako biste dodali nove značajke ili operacije
2. **Napravite vlastiti server** i testirajte ga s ovim klijentima
3. **Eksperimentirajte s različitim transportima** (SSE vs. Stdio)
4. **Izgradite složeniju aplikaciju** koja integrira MCP funkcionalnost

## Rješavanje Problema

### Uobičajeni Problemi

1. **Veza odbijena**: Provjerite je li MCP server pokrenut na očekivanom portu/putanji
2. **Modul nije pronađen**: Instalirajte potrebni MCP SDK za vaš jezik
3. **Dozvola odbijena**: Provjerite dozvole datoteka za stdio transport
4. **Alat nije pronađen**: Provjerite implementira li server očekivane alate

### Savjeti za Debugging

1. **Omogućite detaljno zapisivanje** u vašem MCP SDK-u
2. **Provjerite server logove** za poruke o pogreškama
3. **Provjerite imena i potpise alata** da se podudaraju između klijenta i servera
4. **Prvo testirajte s MCP Inspectorom** kako biste potvrdili funkcionalnost servera

## Povezana Dokumentacija

- [Glavni tutorijal za klijente](./README.md)
- [Primjeri MCP servera](../../../../03-GettingStarted/01-first-server)
- [MCP s LLM integracijom](../../../../03-GettingStarted/03-llm-client)
- [Službena MCP dokumentacija](https://modelcontextprotocol.io/)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo postići točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.