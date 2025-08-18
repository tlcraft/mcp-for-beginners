<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8358c13b5b6877e475674697cdc1a904",
  "translation_date": "2025-08-18T14:45:03+00:00",
  "source_file": "03-GettingStarted/02-client/complete_examples.md",
  "language_code": "hu"
}
-->
# Teljes MCP kliens példák

Ez a könyvtár teljes, működő MCP kliens példákat tartalmaz különböző programozási nyelveken. Minden kliens bemutatja a fő README.md oktatóanyagban leírt teljes funkcionalitást.

## Elérhető kliensek

### 1. Java kliens (`client_example_java.java`)

- **Átvitel**: SSE (Server-Sent Events) HTTP-n keresztül
- **Célkiszolgáló**: `http://localhost:8080`
- **Funkciók**:
  - Kapcsolat létrehozása és pingelés
  - Eszközlista lekérése
  - Számológép műveletek (összeadás, kivonás, szorzás, osztás, súgó)
  - Hibakezelés és eredmény kinyerése

**Futtatás:**

```bash
# Ensure your MCP server is running on localhost:8080
javac client_example_java.java
java client_example_java
```

### 2. C# kliens (`client_example_csharp.cs`)

- **Átvitel**: Stdio (Standard Input/Output)
- **Célkiszolgáló**: Helyi .NET MCP szerver a dotnet run segítségével
- **Funkciók**:
  - Automatikus szerverindítás stdio átvitel segítségével
  - Eszköz- és erőforráslista lekérése
  - Számológép műveletek
  - JSON eredmények feldolgozása
  - Átfogó hibakezelés

**Futtatás:**

```bash
dotnet run
```

### 3. TypeScript kliens (`client_example_typescript.ts`)

- **Átvitel**: Stdio (Standard Input/Output)
- **Célkiszolgáló**: Helyi Node.js MCP szerver
- **Funkciók**:
  - Teljes MCP protokoll támogatás
  - Eszköz-, erőforrás- és prompt műveletek
  - Számológép műveletek
  - Erőforrások olvasása és prompt végrehajtás
  - Robusztus hibakezelés

**Futtatás:**

```bash
# First compile TypeScript (if needed)
npm run build

# Then run the client
npm run client
# or
node client_example_typescript.js
```

### 4. Python kliens (`client_example_python.py`)

- **Átvitel**: Stdio (Standard Input/Output)  
- **Célkiszolgáló**: Helyi Python MCP szerver
- **Funkciók**:
  - Async/await minta a műveletekhez
  - Eszköz- és erőforrás-felfedezés
  - Számológép műveletek tesztelése
  - Erőforrás tartalom olvasása
  - Osztályalapú szervezés

**Futtatás:**

```bash
python client_example_python.py
```

## Közös funkciók minden kliensben

Minden kliens implementáció bemutatja:

1. **Kapcsolatkezelés**
   - Kapcsolat létrehozása az MCP szerverrel
   - Kapcsolati hibák kezelése
   - Megfelelő erőforrás-felszabadítás és takarítás

2. **Szerver felfedezése**
   - Elérhető eszközök listázása
   - Elérhető erőforrások listázása (ha támogatott)
   - Elérhető promt-ok listázása (ha támogatott)

3. **Eszközök meghívása**
   - Alapvető számológép műveletek (összeadás, kivonás, szorzás, osztás)
   - Súgó parancs a szerver információihoz
   - Megfelelő argumentumkezelés és eredményfeldolgozás

4. **Hibakezelés**
   - Kapcsolati hibák
   - Eszközvégrehajtási hibák
   - Kecses hibakezelés és felhasználói visszajelzés

5. **Eredményfeldolgozás**
   - Szöveges tartalom kinyerése a válaszokból
   - Kimenet formázása az olvashatóság érdekében
   - Különböző válaszformátumok kezelése

## Előfeltételek

A kliensek futtatása előtt győződjön meg arról, hogy:

1. **A megfelelő MCP szerver fut** (a `../01-first-server/` könyvtárból)
2. **A szükséges függőségek telepítve vannak** a választott nyelvhez
3. **Megfelelő hálózati kapcsolat** áll rendelkezésre (HTTP-alapú átvitelekhez)

## Főbb különbségek az implementációk között

| Nyelv      | Átvitel   | Szerverindítás | Async modell | Kulcsfontosságú könyvtárak |
|------------|-----------|----------------|--------------|----------------------------|
| Java       | SSE/HTTP  | Külső          | Szinkron     | WebFlux, MCP SDK          |
| C#         | Stdio     | Automatikus    | Async/Await  | .NET MCP SDK              |
| TypeScript | Stdio     | Automatikus    | Async/Await  | Node MCP SDK              |
| Python     | Stdio     | Automatikus    | AsyncIO      | Python MCP SDK            |
| Rust       | Stdio     | Automatikus    | Async/Await  | Rust MCP SDK, Tokio       |

## Következő lépések

Miután felfedezte ezeket a kliens példákat:

1. **Módosítsa a klienseket**, hogy új funkciókat vagy műveleteket adjon hozzá
2. **Hozzon létre saját szervert**, és tesztelje ezeket a kliensekkel
3. **Kísérletezzen különböző átvitelekkel** (SSE vs. Stdio)
4. **Építsen egy összetettebb alkalmazást**, amely integrálja az MCP funkcionalitást

## Hibakeresés

### Gyakori problémák

1. **Kapcsolat megtagadva**: Győződjön meg arról, hogy az MCP szerver a várt porton/útvonalon fut
2. **Modul nem található**: Telepítse a szükséges MCP SDK-t a nyelvéhez
3. **Hozzáférés megtagadva**: Ellenőrizze a fájlengedélyeket stdio átvitel esetén
4. **Eszköz nem található**: Ellenőrizze, hogy a szerver implementálja-e a várt eszközöket

### Hibakeresési tippek

1. **Kapcsolja be a részletes naplózást** az MCP SDK-ban
2. **Ellenőrizze a szerver naplóit** hibaüzenetekért
3. **Győződjön meg arról, hogy az eszköznevek és aláírások** egyeznek a kliens és a szerver között
4. **Tesztelje az MCP Inspectorral** először a szerver funkcionalitásának ellenőrzéséhez

## Kapcsolódó dokumentáció

- [Fő kliens oktatóanyag](./README.md)
- [MCP szerver példák](../../../../03-GettingStarted/01-first-server)
- [MCP LLM integrációval](../../../../03-GettingStarted/03-llm-client)
- [Hivatalos MCP dokumentáció](https://modelcontextprotocol.io/)

**Felelősség kizárása**:  
Ez a dokumentum az AI fordítási szolgáltatás [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével lett lefordítva. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az eredeti nyelvén tekintendő hiteles forrásnak. Kritikus információk esetén javasolt professzionális emberi fordítást igénybe venni. Nem vállalunk felelősséget semmilyen félreértésért vagy téves értelmezésért, amely a fordítás használatából eredhet.