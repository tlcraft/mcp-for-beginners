<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:28:49+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "da"
}
-->
# Calculator LLM Client

En Java-applikation, der viser, hvordan man bruger LangChain4j til at forbinde til en MCP (Model Context Protocol) calculator-service med GitHub Models-integration.

## Forudsætninger

- Java 21 eller nyere
- Maven 3.6+ (eller brug den inkluderede Maven-wrapper)
- En GitHub-konto med adgang til GitHub Models
- En MCP calculator-service kørende på `http://localhost:8080`

## Sådan får du GitHub-tokenet

Denne applikation bruger GitHub Models, som kræver et personligt adgangstoken til GitHub. Følg disse trin for at få dit token:

### 1. Få adgang til GitHub Models
1. Gå til [GitHub Models](https://github.com/marketplace/models)
2. Log ind med din GitHub-konto
3. Anmod om adgang til GitHub Models, hvis du ikke allerede har det

### 2. Opret et personligt adgangstoken
1. Gå til [GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens)
2. Klik på "Generate new token" → "Generate new token (classic)"
3. Giv dit token et beskrivende navn (f.eks. "MCP Calculator Client")
4. Sæt udløbsdato efter behov
5. Vælg følgende scopes:
   - `repo` (hvis du skal have adgang til private repositories)
   - `user:email`
6. Klik på "Generate token"
7. **Vigtigt**: Kopiér tokenet med det samme - du kan ikke se det igen!

### 3. Sæt miljøvariablen

#### På Windows (Command Prompt):
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### På Windows (PowerShell):
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### På macOS/Linux:
```bash
export GITHUB_TOKEN=your_github_token_here
```

## Opsætning og installation

1. **Klon eller naviger til projektmappen**

2. **Installer afhængigheder**:
   ```cmd
   mvnw clean install
   ```
   Eller hvis du har Maven installeret globalt:
   ```cmd
   mvn clean install
   ```

3. **Sæt miljøvariablen** (se afsnittet "Sådan får du GitHub-tokenet" ovenfor)

4. **Start MCP Calculator Service**:
   Sørg for, at du har kapitel 1's MCP calculator-service kørende på `http://localhost:8080/sse`. Den skal være kørende, inden du starter klienten.

## Kørsel af applikationen

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Hvad applikationen gør

Applikationen demonstrerer tre hovedinteraktioner med calculator-servicen:

1. **Addition**: Beregner summen af 24.5 og 17.3
2. **Kvadratrod**: Beregner kvadratroden af 144
3. **Hjælp**: Viser tilgængelige calculator-funktioner

## Forventet output

Når den kører korrekt, bør du se output, der ligner:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## Fejlfinding

### Almindelige problemer

1. **"GITHUB_TOKEN environment variable not set"**
   - Sørg for, at du har sat `GITHUB_TOKEN` environment variable
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

### Debugging

For at aktivere debug-logging, tilføj følgende JVM-argument ved kørsel:
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Konfiguration

Applikationen er konfigureret til at:
- Bruge GitHub Models med `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse`
- Bruge en 60 sekunders timeout for forespørgsler
- Aktivere logning af forespørgsler/svar til debugging

## Afhængigheder

Vigtige afhængigheder i dette projekt:
- **LangChain4j**: Til AI-integration og værktøjsstyring
- **LangChain4j MCP**: Til Model Context Protocol support
- **LangChain4j GitHub Models**: Til GitHub Models-integration
- **Spring Boot**: Til applikationsframework og dependency injection

## Licens

Dette projekt er licenseret under Apache License 2.0 - se [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) filen for detaljer.

**Ansvarsfraskrivelse**:  
Dette dokument er oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiske oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets modersmål bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der måtte opstå som følge af brugen af denne oversættelse.