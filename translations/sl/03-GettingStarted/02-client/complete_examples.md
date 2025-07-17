<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "affcf199a44f60283a289dcb69dc144e",
  "translation_date": "2025-07-17T13:37:20+00:00",
  "source_file": "03-GettingStarted/02-client/complete_examples.md",
  "language_code": "sl"
}
-->
# Celotni primeri MCP odjemalcev

Ta imenik vsebuje popolne, delujoče primere MCP odjemalcev v različnih programskih jezikih. Vsak odjemalec prikazuje celotno funkcionalnost, opisano v glavnem vodiču README.md.

## Na voljo so odjemalci

### 1. Java odjemalec (`client_example_java.java`)
- **Transport**: SSE (Server-Sent Events) preko HTTP
- **Ciljni strežnik**: `http://localhost:8080`
- **Funkcije**: 
  - Vzpostavitev povezave in ping
  - Seznam orodij
  - Kalkulator: seštevanje, odštevanje, množenje, deljenje, pomoč
  - Obdelava napak in pridobivanje rezultatov

**Za zagon:**
```bash
# Ensure your MCP server is running on localhost:8080
javac client_example_java.java
java client_example_java
```

### 2. C# odjemalec (`client_example_csharp.cs`)
- **Transport**: Stdio (standardni vhod/izhod)
- **Ciljni strežnik**: Lokalni .NET MCP strežnik preko dotnet run
- **Funkcije**:
  - Samodejni zagon strežnika preko stdio transporta
  - Seznam orodij in virov
  - Kalkulator
  - Parsiranje JSON rezultatov
  - Celovita obdelava napak

**Za zagon:**
```bash
dotnet run
```

### 3. TypeScript odjemalec (`client_example_typescript.ts`)
- **Transport**: Stdio (standardni vhod/izhod)
- **Ciljni strežnik**: Lokalni Node.js MCP strežnik
- **Funkcije**:
  - Popolna podpora MCP protokolu
  - Operacije z orodji, viri in pozivi
  - Kalkulator
  - Branje virov in izvajanje pozivov
  - Zanesljiva obdelava napak

**Za zagon:**
```bash
# First compile TypeScript (if needed)
npm run build

# Then run the client
npm run client
# or
node client_example_typescript.js
```

### 4. Python odjemalec (`client_example_python.py`)
- **Transport**: Stdio (standardni vhod/izhod)  
- **Ciljni strežnik**: Lokalni Python MCP strežnik
- **Funkcije**:
  - Async/await vzorec za operacije
  - Iskanje orodij in virov
  - Testiranje kalkulatorja
  - Branje vsebine virov
  - Organizacija v razrede

**Za zagon:**
```bash
python client_example_python.py
```

## Skupne funkcije vseh odjemalcev

Vsaka implementacija odjemalca prikazuje:

1. **Upravljanje povezave**
   - Vzpostavitev povezave s MCP strežnikom
   - Obdelava napak pri povezavi
   - Pravilno čiščenje in upravljanje virov

2. **Odkritje strežnika**
   - Seznam razpoložljivih orodij
   - Seznam razpoložljivih virov (kjer je podprto)
   - Seznam razpoložljivih pozivov (kjer je podprto)

3. **Klic orodij**
   - Osnovne operacije kalkulatorja (seštevanje, odštevanje, množenje, deljenje)
   - Ukaz za pomoč s podatki o strežniku
   - Pravilno posredovanje argumentov in obdelava rezultatov

4. **Obdelava napak**
   - Napake povezave
   - Napake pri izvajanju orodij
   - Prijazno obravnavanje napak in povratne informacije uporabniku

5. **Obdelava rezultatov**
   - Pridobivanje besedilne vsebine iz odgovorov
   - Oblikovanje izhoda za boljšo berljivost
   - Obdelava različnih formatov odgovorov

## Zahteve

Pred zagonom teh odjemalcev poskrbite, da imate:

1. **Zagon ustreznega MCP strežnika** (iz `../01-first-server/`)
2. **Namestitev potrebnih odvisnosti** za izbrani programski jezik
3. **Pravilno omrežno povezljivost** (za HTTP transport)

## Ključne razlike med implementacijami

| Jezik      | Transport | Zagon strežnika | Asinhroni model | Ključne knjižnice |
|------------|-----------|-----------------|-----------------|-------------------|
| Java       | SSE/HTTP  | Zunanji         | Sinhroni        | WebFlux, MCP SDK  |
| C#         | Stdio     | Samodejni       | Async/Await     | .NET MCP SDK      |
| TypeScript | Stdio     | Samodejni       | Async/Await     | Node MCP SDK      |
| Python     | Stdio     | Samodejni       | AsyncIO         | Python MCP SDK    |

## Naslednji koraki

Po pregledu teh primerov odjemalcev:

1. **Spremenite odjemalce** in dodajte nove funkcije ali operacije
2. **Ustvarite svoj strežnik** in ga preizkusite z odjemalci
3. **Preizkusite različne transporte** (SSE proti Stdio)
4. **Razvijte bolj zapleteno aplikacijo**, ki vključuje MCP funkcionalnost

## Reševanje težav

### Pogoste težave

1. **Povezava zavrnjena**: Preverite, da MCP strežnik teče na pričakovanem portu/poti
2. **Modul ni najden**: Namestite ustrezen MCP SDK za vaš jezik
3. **Dostop zavrnjen**: Preverite dovoljenja datotek za stdio transport
4. **Orodje ni najdeno**: Preverite, da strežnik podpira pričakovana orodja

### Nasveti za odpravljanje napak

1. **Omogočite podrobno beleženje** v vašem MCP SDK
2. **Preverite strežniške dnevnike** za sporočila o napakah
3. **Preverite imena in podpise orodij**, da se ujemajo med odjemalcem in strežnikom
4. **Najprej testirajte s MCP Inspectorjem** za potrditev delovanja strežnika

## Povezana dokumentacija

- [Glavni vodič za odjemalce](./README.md)
- [Primeri MCP strežnikov](../../../../03-GettingStarted/01-first-server)
- [MCP z LLM integracijo](../../../../03-GettingStarted/03-llm-client)
- [Uradna MCP dokumentacija](https://modelcontextprotocol.io/)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.