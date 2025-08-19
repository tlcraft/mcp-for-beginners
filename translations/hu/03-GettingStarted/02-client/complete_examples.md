<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "affcf199a44f60283a289dcb69dc144e",
  "translation_date": "2025-07-17T13:35:24+00:00",
  "source_file": "03-GettingStarted/02-client/complete_examples.md",
  "language_code": "hu"
}
-->
# Teljes MCP kliens példák

Ez a könyvtár teljes, működő MCP kliens példákat tartalmaz különböző programozási nyelveken. Minden kliens bemutatja a fő README.md oktatóanyagban leírt teljes funkcionalitást.

## Elérhető kliensek

### 1. Java kliens (`client_example_java.java`)

- **Átvitel**: SSE (Server-Sent Events) HTTP-n keresztül
- **Cél szerver**: `http://localhost:8080`
- **Funkciók**: 
  - Kapcsolat létrehozása és ping
  - Eszközlista lekérése
  - Számológép műveletek (összeadás, kivonás, szorzás, osztás, segítség)
  - Hibakezelés és eredmény kinyerése

**Futtatáshoz:**
```bash
# Ensure your MCP server is running on localhost:8080
javac client_example_java.java
java client_example_java
```

### 2. C# kliens (`client_example_csharp.cs`)
- **Átvitel**: Stdio (Standard bemenet/kimenet)
- **Cél szerver**: Helyi .NET MCP szerver a dotnet run segítségével
- **Funkciók**:
  - Automatikus szerverindítás stdio átvitel használatával
  - Eszköz- és erőforráslista lekérése
  - Számológép műveletek
  - JSON eredmény feldolgozás
  - Átfogó hibakezelés

**Futtatáshoz:**
```bash
dotnet run
```

### 3. TypeScript kliens (`client_example_typescript.ts`)
- **Átvitel**: Stdio (Standard bemenet/kimenet)
- **Cél szerver**: Helyi Node.js MCP szerver
- **Funkciók**:
  - Teljes MCP protokoll támogatás
  - Eszköz-, erőforrás- és prompt műveletek
  - Számológép műveletek
  - Erőforrás olvasás és prompt végrehajtás
  - Robosztus hibakezelés

**Futtatáshoz:**
```bash
# First compile TypeScript (if needed)
npm run build

# Then run the client
npm run client
# or
node client_example_typescript.js
```

### 4. Python kliens (`client_example_python.py`)
- **Átvitel**: Stdio (Standard bemenet/kimenet)  
- **Cél szerver**: Helyi Python MCP szerver
- **Funkciók**:
  - Async/await mintázat a műveletekhez
  - Eszköz- és erőforrás felfedezés
  - Számológép műveletek tesztelése
  - Erőforrás tartalom olvasása
  - Osztály alapú szervezés

**Futtatáshoz:**
```bash
python client_example_python.py
```

## Közös funkciók minden kliensben

Minden kliens implementáció bemutatja:

1. **Kapcsolatkezelés**
   - Kapcsolat létrehozása az MCP szerverrel
   - Kapcsolati hibák kezelése
   - Megfelelő erőforrás-takarítás és lezárás

2. **Szerver felfedezése**
   - Elérhető eszközök listázása
   - Elérhető erőforrások listázása (ahol támogatott)
   - Elérhető promptok listázása (ahol támogatott)

3. **Eszköz meghívás**
   - Alapvető számológép műveletek (összeadás, kivonás, szorzás, osztás)
   - Segítség parancs a szerver információkhoz
   - Érvek helyes átadása és eredmény kezelése

4. **Hibakezelés**
   - Kapcsolati hibák
   - Eszköz végrehajtási hibák
   - Kiegyensúlyozott hibakezelés és felhasználói visszajelzés

5. **Eredményfeldolgozás**
   - Szöveges tartalom kinyerése a válaszokból
   - Kimenet formázása olvashatóság érdekében
   - Különböző válaszformátumok kezelése

## Előfeltételek

A kliensek futtatása előtt győződjön meg arról, hogy:

1. **A megfelelő MCP szerver fut** (a `../01-first-server/` könyvtárból)
2. **A szükséges függőségek telepítve vannak** a választott nyelvhez
3. **Megfelelő hálózati kapcsolat áll rendelkezésre** (HTTP alapú átvitel esetén)

## Fő különbségek az implementációk között

| Nyelv      | Átvitel  | Szerver indítás | Async modell | Főbb könyvtárak      |
|------------|----------|-----------------|--------------|---------------------|
| Java       | SSE/HTTP | Külső           | Szinkron     | WebFlux, MCP SDK     |
| C#         | Stdio    | Automatikus     | Async/Await  | .NET MCP SDK         |
| TypeScript | Stdio    | Automatikus     | Async/Await  | Node MCP SDK         |
| Python     | Stdio    | Automatikus     | AsyncIO      | Python MCP SDK       |

## Következő lépések

Miután felfedezte ezeket a kliens példákat:

1. **Módosítsa a klienseket**, hogy új funkciókat vagy műveleteket adjon hozzá
2. **Hozzon létre saját szervert**, és tesztelje ezeket a kliensekkel
3. **Kísérletezzen különböző átvitelekkel** (SSE vs. Stdio)
4. **Építsen egy összetettebb alkalmazást**, amely integrálja az MCP funkcionalitást

## Hibakeresés

### Gyakori problémák

1. **Kapcsolat megtagadva**: Ellenőrizd, hogy az MCP szerver fut-e a várt porton/útvonalon
2. **Modul nem található**: Telepítsd a szükséges MCP SDK-t a nyelvedhez
3. **Hozzáférés megtagadva**: Ellenőrizd a fájl jogosultságokat stdio átvitel esetén
4. **Eszköz nem található**: Győződj meg róla, hogy a szerver implementálja a várt eszközöket

### Hibakeresési tippek

1. **Kapcsold be a részletes naplózást** az MCP SDK-ban
2. **Nézd meg a szerver naplóit** hibák után kutatva
3. **Ellenőrizd az eszközneveket és aláírásokat**, hogy egyezzenek kliens és szerver között
4. **Először teszteld az MCP Inspectorral**, hogy validáld a szerver működését

## Kapcsolódó dokumentáció

- [Fő kliens oktatóanyag](./README.md)
- [MCP szerver példák](../../../../03-GettingStarted/01-first-server)
- [MCP LLM integrációval](../../../../03-GettingStarted/03-llm-client)
- [Hivatalos MCP dokumentáció](https://modelcontextprotocol.io/)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.