<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8358c13b5b6877e475674697cdc1a904",
  "translation_date": "2025-08-18T18:00:09+00:00",
  "source_file": "03-GettingStarted/02-client/complete_examples.md",
  "language_code": "sl"
}
-->
# Popolni Primeri MCP Odjemalcev

Ta mapa vsebuje popolne, delujoče primere MCP odjemalcev v različnih programskih jezikih. Vsak odjemalec prikazuje celotno funkcionalnost, opisano v glavnem vodiču README.md.

## Razpoložljivi Odjemalci

### 1. Java Odjemalec (`client_example_java.java`)

- **Transport**: SSE (Server-Sent Events) prek HTTP
- **Ciljni Strežnik**: `http://localhost:8080`
- **Funkcije**:
  - Vzpostavitev povezave in ping
  - Seznam orodij
  - Operacije kalkulatorja (seštevanje, odštevanje, množenje, deljenje, pomoč)
  - Upravljanje napak in pridobivanje rezultatov

**Za zagon:**

```bash
# Ensure your MCP server is running on localhost:8080
javac client_example_java.java
java client_example_java
```

### 2. C# Odjemalec (`client_example_csharp.cs`)

- **Transport**: Stdio (Standardni Vhod/Izhod)
- **Ciljni Strežnik**: Lokalni .NET MCP strežnik prek dotnet run
- **Funkcije**:
  - Samodejni zagon strežnika prek stdio transporta
  - Seznam orodij in virov
  - Operacije kalkulatorja
  - Parsiranje rezultatov v JSON formatu
  - Celovito upravljanje napak

**Za zagon:**

```bash
dotnet run
```

### 3. TypeScript Odjemalec (`client_example_typescript.ts`)

- **Transport**: Stdio (Standardni Vhod/Izhod)
- **Ciljni Strežnik**: Lokalni Node.js MCP strežnik
- **Funkcije**:
  - Polna podpora MCP protokolu
  - Operacije z orodji, viri in pozivi
  - Operacije kalkulatorja
  - Branje virov in izvajanje pozivov
  - Zanesljivo upravljanje napak

**Za zagon:**

```bash
# First compile TypeScript (if needed)
npm run build

# Then run the client
npm run client
# or
node client_example_typescript.js
```

### 4. Python Odjemalec (`client_example_python.py`)

- **Transport**: Stdio (Standardni Vhod/Izhod)  
- **Ciljni Strežnik**: Lokalni Python MCP strežnik
- **Funkcije**:
  - Vzorec async/await za operacije
  - Odkritje orodij in virov
  - Testiranje operacij kalkulatorja
  - Branje vsebine virov
  - Organizacija na osnovi razredov

**Za zagon:**

```bash
python client_example_python.py
```

## Skupne Funkcije Vseh Odjemalcev

Vsaka implementacija odjemalca prikazuje:

1. **Upravljanje Povezave**
   - Vzpostavitev povezave z MCP strežnikom
   - Upravljanje napak pri povezavi
   - Pravilno čiščenje in upravljanje virov

2. **Odkritje Strežnika**
   - Seznam razpoložljivih orodij
   - Seznam razpoložljivih virov (kjer je podprto)
   - Seznam razpoložljivih pozivov (kjer je podprto)

3. **Izvajanje Orodij**
   - Osnovne operacije kalkulatorja (seštevanje, odštevanje, množenje, deljenje)
   - Ukaz za pomoč za informacije o strežniku
   - Pravilno posredovanje argumentov in upravljanje rezultatov

4. **Upravljanje Napak**
   - Napake pri povezavi
   - Napake pri izvajanju orodij
   - Prijazno obveščanje uporabnika ob neuspehu

5. **Obdelava Rezultatov**
   - Pridobivanje besedilne vsebine iz odgovorov
   - Oblikovanje izhoda za boljšo berljivost
   - Upravljanje različnih formatov odgovorov

## Predpogoji

Preden zaženete te odjemalce, se prepričajte, da imate:

1. **Ustrezno MCP strežnik, ki deluje** (iz `../01-first-server/`)
2. **Nameščene potrebne odvisnosti** za izbrani programski jezik
3. **Pravilno omrežno povezljivost** (za transporte na osnovi HTTP)

## Ključne Razlike Med Implementacijami

| Jezik      | Transport | Zagon Strežnika | Async Model | Ključne Knjižnice       |
|------------|-----------|-----------------|-------------|-------------------------|
| Java       | SSE/HTTP  | Zunanji         | Sinhrono    | WebFlux, MCP SDK        |
| C#         | Stdio     | Samodejno       | Async/Await | .NET MCP SDK            |
| TypeScript | Stdio     | Samodejno       | Async/Await | Node MCP SDK            |
| Python     | Stdio     | Samodejno       | AsyncIO     | Python MCP SDK          |
| Rust       | Stdio     | Samodejno       | Async/Await | Rust MCP SDK, Tokio     |

## Naslednji Koraki

Po raziskovanju teh primerov odjemalcev:

1. **Prilagodite odjemalce**, da dodate nove funkcije ali operacije
2. **Ustvarite svoj strežnik** in ga preizkusite z odjemalci
3. **Eksperimentirajte z različnimi transporti** (SSE proti Stdio)
4. **Zgradite bolj kompleksno aplikacijo**, ki integrira MCP funkcionalnost

## Odpravljanje Težav

### Pogoste Težave

1. **Povezava zavrnjena**: Prepričajte se, da MCP strežnik deluje na pričakovanem portu/poti
2. **Modul ni najden**: Namestite zahtevani MCP SDK za vaš jezik
3. **Dostop zavrnjen**: Preverite dovoljenja datotek za stdio transport
4. **Orodje ni najdeno**: Preverite, ali strežnik implementira pričakovana orodja

### Nasveti za Debugging

1. **Omogočite podrobno beleženje** v vašem MCP SDK
2. **Preverite strežniške dnevnike** za sporočila o napakah
3. **Preverite imena in podpise orodij**, da se ujemajo med odjemalcem in strežnikom
4. **Najprej preizkusite z MCP Inspectorjem**, da preverite funkcionalnost strežnika

## Povezana Dokumentacija

- [Glavni Vodič za Odjemalce](./README.md)
- [Primeri MCP Strežnikov](../../../../03-GettingStarted/01-first-server)
- [MCP z Integracijo LLM](../../../../03-GettingStarted/03-llm-client)
- [Uradna Dokumentacija MCP](https://modelcontextprotocol.io/)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za strojno prevajanje [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku je treba obravnavati kot avtoritativni vir. Za ključne informacije priporočamo strokovno človeško prevajanje. Ne prevzemamo odgovornosti za morebitna nesporazumevanja ali napačne razlage, ki izhajajo iz uporabe tega prevoda.