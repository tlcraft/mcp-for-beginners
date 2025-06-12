<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:34:55+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "hr"
}
-->
# Calculator LLM Client

Java aplikacija koja pokazuje kako koristiti LangChain4j za povezivanje s MCP (Model Context Protocol) kalkulator servisom s integracijom GitHub Models.

## Preduvjeti

- Java 21 ili novija verzija
- Maven 3.6+ (ili koristite priloženi Maven wrapper)
- GitHub račun s pristupom GitHub Models
- MCP kalkulator servis koji radi na `http://localhost:8080`

## Dobivanje GitHub Tokena

Ova aplikacija koristi GitHub Models što zahtijeva GitHub personalni pristupni token. Slijedite ove korake da biste dobili svoj token:

### 1. Pristup GitHub Models
1. Posjetite [GitHub Models](https://github.com/marketplace/models)
2. Prijavite se sa svojim GitHub računom
3. Zatražite pristup GitHub Models ako ga još nemate

### 2. Kreirajte Personalni Pristupni Token
1. Idite na [GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens)
2. Kliknite "Generate new token" → "Generate new token (classic)"
3. Dajte tokenu opisni naziv (npr. "MCP Calculator Client")
4. Postavite datum isteka po potrebi
5. Odaberite sljedeće ovlasti:
   - `repo` (ako pristupate privatnim repozitorijima)
   - `user:email`
6. Kliknite "Generate token"
7. **Važno**: Odmah kopirajte token - nakon toga ga više nećete moći vidjeti!

### 3. Postavite Varijablu Okoline

#### Na Windowsu (Command Prompt):
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### Na Windowsu (PowerShell):
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### Na macOS/Linux:
```bash
export GITHUB_TOKEN=your_github_token_here
```

## Postavljanje i Instalacija

1. **Klonirajte ili se premjestite u direktorij projekta**

2. **Instalirajte ovisnosti**:
   ```cmd
   mvnw clean install
   ```
   Ili ako imate globalno instaliran Maven:
   ```cmd
   mvn clean install
   ```

3. **Postavite varijablu okoline** (pogledajte odjeljak "Dobivanje GitHub Tokena" gore)

4. **Pokrenite MCP Calculator Service**:
   Provjerite da je MCP kalkulator servis iz poglavlja 1 pokrenut na `http://localhost:8080/sse`. Servis treba biti aktivan prije pokretanja klijenta.

## Pokretanje Aplikacije

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Što Aplikacija Radi

Aplikacija demonstrira tri glavne interakcije s kalkulator servisom:

1. **Zbrajanje**: Izračunava zbroj 24.5 i 17.3
2. **Kvadratni korijen**: Izračunava kvadratni korijen od 144
3. **Pomoć**: Prikazuje dostupne funkcije kalkulatora

## Očekivani Izlaz

Ako aplikacija uspješno radi, trebali biste vidjeti izlaz sličan ovom:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## Rješavanje Problema

### Česti Problemi

1. **"GITHUB_TOKEN environment variable not set"**
   - Provjerite jeste li postavili `GITHUB_TOKEN` environment variable
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

### Debugiranje

Za omogućavanje debug logiranja, dodajte sljedeći JVM argument prilikom pokretanja:
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Konfiguracija

Aplikacija je konfigurirana da:
- Koristi GitHub Models s `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse`
- Koristi timeout od 60 sekundi za zahtjeve
- Omogućuje logiranje zahtjeva/odgovora radi debugiranja

## Ovisnosti

Glavne ovisnosti korištene u ovom projektu:
- **LangChain4j**: Za AI integraciju i upravljanje alatima
- **LangChain4j MCP**: Za podršku Model Context Protocolu
- **LangChain4j GitHub Models**: Za integraciju s GitHub Models
- **Spring Boot**: Za framework aplikacije i injekciju ovisnosti

## Licenca

Ovaj projekt je licenciran pod Apache License 2.0 - pogledajte datoteku [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) za detalje.

**Odricanje od odgovornosti**:  
Ovaj dokument preveden je korištenjem AI prevoditeljskog servisa [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba se smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.