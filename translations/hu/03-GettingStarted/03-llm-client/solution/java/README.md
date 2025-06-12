<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:32:12+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "hu"
}
-->
# Calculator LLM Client

Egy Java alkalmazás, amely bemutatja, hogyan használható a LangChain4j az MCP (Model Context Protocol) kalkulátor szolgáltatáshoz való kapcsolódáshoz GitHub Models integrációval.

## Előfeltételek

- Java 21 vagy újabb
- Maven 3.6+ (vagy használd a mellékelt Maven wrappert)
- GitHub fiók, amely hozzáfér a GitHub Models-hez
- Egy futó MCP kalkulátor szolgáltatás a `http://localhost:8080` címen

## A GitHub Token beszerzése

Ez az alkalmazás a GitHub Models-t használja, amihez GitHub személyes hozzáférési token szükséges. Kövesd az alábbi lépéseket a token megszerzéséhez:

### 1. Lépj be a GitHub Models-be
1. Menj a [GitHub Models](https://github.com/marketplace/models) oldalra
2. Jelentkezz be a GitHub fiókoddal
3. Kérj hozzáférést a GitHub Models-hez, ha még nem tetted meg

### 2. Hozz létre személyes hozzáférési tokent
1. Menj a [GitHub Beállítások → Fejlesztői beállítások → Személyes hozzáférési tokenek → Tokenek (klasszikus)](https://github.com/settings/tokens) oldalra
2. Kattints a "Generate new token" → "Generate new token (classic)" gombra
3. Adj a tokennek egy beszédes nevet (pl. "MCP Calculator Client")
4. Állítsd be a lejáratot szükség szerint
5. Válaszd ki a következő jogosultságokat:
   - `repo` (ha privát repókhoz is hozzáférsz)
   - `user:email`
6. Kattints a "Generate token" gombra
7. **Fontos**: Azonnal másold ki a tokent, mert később nem fogod látni!

### 3. Állítsd be a környezeti változót

#### Windows (Parancssor):
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### Windows (PowerShell):
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### macOS/Linux:
```bash
export GITHUB_TOKEN=your_github_token_here
```

## Beállítás és telepítés

1. **Klónozd vagy lépj be a projekt könyvtárába**

2. **Telepítsd a függőségeket**:
   ```cmd
   mvnw clean install
   ```
   Vagy ha globálisan telepítve van a Maven:
   ```cmd
   mvn clean install
   ```

3. **Állítsd be a környezeti változót** (lásd a "A GitHub Token beszerzése" részt)

4. **Indítsd el az MCP Calculator szolgáltatást**:
   Győződj meg róla, hogy az 1. fejezetben ismertetett MCP kalkulátor szolgáltatás fut a `http://localhost:8080/sse` címen. Ennek futnia kell, mielőtt elindítod a klienst.

## Az alkalmazás futtatása

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Mit csinál az alkalmazás

Az alkalmazás három fő műveletet mutat be a kalkulátor szolgáltatással:

1. **Összeadás**: Kiszámolja 24.5 és 17.3 összegét
2. **Négyzetgyök**: Kiszámolja a 144 négyzetgyökét
3. **Segítség**: Megjeleníti a rendelkezésre álló kalkulátor funkciókat

## Várt kimenet

Sikeres futtatás esetén az alábbihoz hasonló kimenetet kell látnod:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## Hibakeresés

### Gyakori problémák

1. **"GITHUB_TOKEN környezeti változó nincs beállítva"**
   - Győződj meg róla, hogy beállítottad a `GITHUB_TOKEN` environment variable
   - Restart your terminal/command prompt after setting the variable

2. **"Connection refused to localhost:8080"**
   - Ensure the MCP calculator service is running on port 8080
   - Check if another service is using port 8080

3. **"Authentication failed"**
   - Verify your GitHub token is valid and has the correct permissions
   - Check if you have access to GitHub Models

4. **Maven build errors**
   - Ensure you're using Java 21 or higher: `java -version`
   - Try cleaning the build: `mvnw clean`

### Hibakeresés

A hibakereső naplózás engedélyezéséhez add hozzá a következő JVM argumentumot a futtatáskor:
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Konfiguráció

Az alkalmazás beállításai:
- GitHub Models használata a `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse` címmel
- 60 másodperces időkorlát a kérésekhez
- Kérés/válasz naplózás engedélyezve hibakereséshez

## Függőségek

A projekt főbb függőségei:
- **LangChain4j**: AI integrációhoz és eszközkezeléshez
- **LangChain4j MCP**: Model Context Protocol támogatáshoz
- **LangChain4j GitHub Models**: GitHub Models integrációhoz
- **Spring Boot**: Alkalmazás keretrendszerhez és függőség injektáláshoz

## Licenc

Ez a projekt az Apache License 2.0 alatt áll - részletek a [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) fájlban találhatók.

**Nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy félreértelmezésekért.