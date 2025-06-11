<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7074b9f4c8cd147c1c10f569d8508c82",
  "translation_date": "2025-06-11T13:15:32+00:00",
  "source_file": "03-GettingStarted/02-client/solution/java/README.md",
  "language_code": "hu"
}
-->
# MCP Java Client - Számológép Demó

Ez a projekt bemutatja, hogyan lehet létrehozni egy Java klienst, amely kapcsolódik egy MCP (Model Context Protocol) szerverhez, és interakcióba lép vele. Ebben a példában a 01. fejezetből származó számológép szerverhez csatlakozunk, és különböző matematikai műveleteket hajtunk végre.

## Előfeltételek

A kliens futtatása előtt a következőket kell megtenni:

1. **Indítsd el a 01. fejezetből származó számológép szervert**:
   - Navigálj a számológép szerver könyvtárába: `03-GettingStarted/01-first-server/solution/java/`
   - Építsd és indítsd el a számológép szervert:
     ```cmd
     cd ..\01-first-server\solution\java
     .\mvnw clean install -DskipTests
     java -jar target\calculator-server-0.0.1-SNAPSHOT.jar
     ```
   - A szervernek a `http://localhost:8080` címen kell futnia.

## SDKClient egy Java alkalmazás, amely bemutatja, hogyan lehet:
- MCP szerverhez csatlakozni Server-Sent Events (SSE) transport segítségével
- Lekérdezni a szerveren elérhető eszközöket
- Távolról meghívni különböző számológép funkciókat
- Kezelni a válaszokat és megjeleníteni az eredményeket

## Hogyan működik

A kliens a Spring AI MCP keretrendszert használja a következőkhöz:

1. **Kapcsolat létrehozása**: WebFlux SSE kliens transportot hoz létre a számológép szerverhez való kapcsolódáshoz
2. **Kliens inicializálása**: Beállítja az MCP klienst és létrehozza a kapcsolatot
3. **Eszközök felfedezése**: Listázza az összes elérhető számológép műveletet
4. **Műveletek végrehajtása**: Meghív különböző matematikai függvényeket mintaadatokkal
5. **Eredmények megjelenítése**: Megjeleníti az egyes számítások eredményeit

## Projekt felépítése

```
src/
└── main/
    └── java/
        └── com/
            └── microsoft/
                └── mcp/
                    └── sample/
                        └── client/
                            └── SDKClient.java    # Main client implementation
```

## Fő függőségek

A projekt a következő fő függőségeket használja:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

Ez a függőség biztosítja:
- `McpClient` - The main client interface
- `WebFluxSseClientTransport` - SSE transport webes kommunikációhoz
- MCP protokoll sémák és kérés/válasz típusok

## Projekt építése

A projektet a Maven wrapper segítségével építsd:

```cmd
.\mvnw clean install
```

## A kliens futtatása

```cmd
java -jar .\target\calculator-client-0.0.1-SNAPSHOT.jar
```

**Megjegyzés**: Győződj meg róla, hogy a számológép szerver fut a `http://localhost:8080` címen.

2. **Eszközök listázása** - Megjeleníti az összes elérhető számológép műveletet  
3. **Számítások végrehajtása**:
   - Összeadás: 5 + 3 = 8
   - Kivonás: 10 - 4 = 6
   - Szorzás: 6 × 7 = 42
   - Osztás: 20 ÷ 4 = 5
   - Hatványozás: 2^8 = 256
   - Négyzetgyök: √16 = 4
   - Abszolút érték: |-5.5| = 5.5
   - Segítség: Megjeleníti az elérhető műveleteket

## Várt kimenet

```
Available Tools = ListToolsResult[tools=[Tool[name=add, description=Add two numbers together, ...], ...]]
Add Result = CallToolResult[content=[TextContent[text="5,00 + 3,00 = 8,00"]], isError=false]
Subtract Result = CallToolResult[content=[TextContent[text="10,00 - 4,00 = 6,00"]], isError=false]
Multiply Result = CallToolResult[content=[TextContent[text="6,00 * 7,00 = 42,00"]], isError=false]
Divide Result = CallToolResult[content=[TextContent[text="20,00 / 4,00 = 5,00"]], isError=false]
Power Result = CallToolResult[content=[TextContent[text="2,00 ^ 8,00 = 256,00"]], isError=false]
Square Root Result = CallToolResult[content=[TextContent[text="√16,00 = 4,00"]], isError=false]
Absolute Result = CallToolResult[content=[TextContent[text="|-5,50| = 5,50"]], isError=false]
Help = CallToolResult[content=[TextContent[text="Basic Calculator MCP Service\n\nAvailable operations:\n1. add(a, b) - Adds two numbers\n2. subtract(a, b) - Subtracts the second number from the first\n..."]], isError=false]
```

**Megjegyzés**: Előfordulhat, hogy a Maven figyelmeztetéseket jelez a futás végén a háttérben futó szálakról – ez normális reaktív alkalmazások esetén, nem jelent hibát.

## A kód megértése

### 1. Transport beállítása  
```java
var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
```  
Ez létrehoz egy SSE (Server-Sent Events) transportot, amely kapcsolódik a számológép szerverhez.

### 2. Kliens létrehozása  
```java
var client = McpClient.sync(this.transport).build();
client.initialize();
```  
Létrehoz egy szinkron MCP klienst és inicializálja a kapcsolatot.

### 3. Eszközök meghívása  
```java
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
```  
Meghívja az "add" eszközt a paraméterekkel: a=5.0 és b=3.0.

## Hibakeresés

### A szerver nem fut  
Ha csatlakozási hibákat kapsz, győződj meg róla, hogy a 01. fejezetből származó számológép szerver fut:  
```
Error: Connection refused
```  
**Megoldás**: Először indítsd el a számológép szervert.

### A port már foglalt  
Ha a 8080-as port foglalt:  
```
Error: Address already in use
```  
**Megoldás**: Állítsd le a portot használó más alkalmazásokat, vagy módosítsd a szervert, hogy más portot használjon.

### Fordítási hibák  
Ha fordítási hibák lépnek fel:  
```cmd
.\mvnw clean install -DskipTests
```

## További információk

- [Spring AI MCP Dokumentáció](https://docs.spring.io/spring-ai/reference/api/mcp/)
- [Model Context Protocol specifikáció](https://modelcontextprotocol.io/)
- [Spring WebFlux Dokumentáció](https://docs.spring.io/spring-framework/docs/current/reference/html/web-reactive.html)

**Felelősségkizárás**:  
Ezt a dokumentumot az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár igyekszünk pontosak lenni, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum a saját nyelvén tekintendő hivatalos forrásnak. Fontos információk esetén professzionális emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.