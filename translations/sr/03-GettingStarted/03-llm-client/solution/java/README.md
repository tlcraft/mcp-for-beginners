<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:34:11+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "sr"
}
-->
# Calculator LLM Client

Java aplikacija koja pokazuje kako koristiti LangChain4j za povezivanje sa MCP (Model Context Protocol) kalkulator servisom uz integraciju GitHub Models.

## Preduslovi

- Java 21 ili noviji
- Maven 3.6+ (ili koristite uključen Maven wrapper)
- GitHub nalog sa pristupom GitHub Models
- MCP kalkulator servis koji radi na `http://localhost:8080`

## Kako doći do GitHub Tokena

Ova aplikacija koristi GitHub Models, što zahteva GitHub personalni pristupni token. Pratite sledeće korake da dobijete token:

### 1. Pristupite GitHub Models
1. Idite na [GitHub Models](https://github.com/marketplace/models)
2. Prijavite se sa svojim GitHub nalogom
3. Zatražite pristup GitHub Models ako već nemate

### 2. Kreirajte Personal Access Token
1. Idite na [GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens)
2. Kliknite na "Generate new token" → "Generate new token (classic)"
3. Dajte tokenu opisno ime (npr. "MCP Calculator Client")
4. Podesite rok važenja po potrebi
5. Izaberite sledeće scope-ove:
   - `repo` (ako pristupate privatnim repozitorijumima)
   - `user:email`
6. Kliknite na "Generate token"
7. **Važno**: Odmah kopirajte token - nećete ga moći ponovo videti!

### 3. Podesite Environment Varijablu

#### Na Windows-u (Command Prompt):
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### Na Windows-u (PowerShell):
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### Na macOS/Linux:
```bash
export GITHUB_TOKEN=your_github_token_here
```

## Podešavanje i Instalacija

1. **Klonirajte ili se prebacite u direktorijum projekta**

2. **Instalirajte zavisnosti**:
   ```cmd
   mvnw clean install
   ```
   Ili ako imate globalno instaliran Maven:
   ```cmd
   mvn clean install
   ```

3. **Podesite environment varijablu** (pogledajte deo "Kako doći do GitHub Tokena" iznad)

4. **Pokrenite MCP Calculator Service**:
   Proverite da li je MCP kalkulator servis iz poglavlja 1 pokrenut na `http://localhost:8080/sse`. Servis mora biti aktivan pre pokretanja klijenta.

## Pokretanje Aplikacije

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Šta Aplikacija Radi

Aplikacija demonstrira tri glavne interakcije sa kalkulator servisom:

1. **Sabiranje**: Izračunava zbir 24.5 i 17.3
2. **Kvadratni koren**: Izračunava kvadratni koren od 144
3. **Pomoć**: Prikazuje dostupne funkcije kalkulatora

## Očekivani Izlaz

Kada aplikacija uspešno radi, trebalo bi da vidite izlaz sličan ovom:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## Rešavanje Problema

### Česti Problemi

1. **"GITHUB_TOKEN environment variable not set"**
   - Proverite da li ste podesili `GITHUB_TOKEN` environment variable
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

### Debugovanje

Da omogućite debug logovanje, dodajte sledeći JVM argument prilikom pokretanja:
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Konfiguracija

Aplikacija je konfigurisana da:
- Koristi GitHub Models sa `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse`
- Koristi timeout od 60 sekundi za zahteve
- Omogućava logovanje zahteva/odgovora radi debugovanja

## Zavisnosti

Glavne zavisnosti u ovom projektu:
- **LangChain4j**: Za AI integraciju i upravljanje alatima
- **LangChain4j MCP**: Za podršku Model Context Protocol-a
- **LangChain4j GitHub Models**: Za integraciju GitHub Models
- **Spring Boot**: Za framework aplikacije i dependency injection

## Licenca

Ovaj projekat je licenciran pod Apache License 2.0 - pogledajte [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) fajl za detalje.

**Одрицање од одговорности**:  
Овај документ је преведен помоћу AI сервиса за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако настојимо да превод буде тачан, молимо вас да имате у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешне тумачења настала коришћењем овог превода.