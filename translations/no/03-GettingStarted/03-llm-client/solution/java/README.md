<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:29:10+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "no"
}
-->
# Calculator LLM Client

En Java-applikasjon som viser hvordan du bruker LangChain4j for å koble til en MCP (Model Context Protocol) kalkulatortjeneste med GitHub Models-integrasjon.

## Forutsetninger

- Java 21 eller nyere
- Maven 3.6+ (eller bruk den medfølgende Maven-wrapperen)
- En GitHub-konto med tilgang til GitHub Models
- En MCP kalkulatortjeneste som kjører på `http://localhost:8080`

## Slik får du GitHub-tokenet

Denne applikasjonen bruker GitHub Models, som krever et personlig tilgangstoken fra GitHub. Følg disse stegene for å få tokenet ditt:

### 1. Gå til GitHub Models
1. Gå til [GitHub Models](https://github.com/marketplace/models)
2. Logg inn med GitHub-kontoen din
3. Be om tilgang til GitHub Models hvis du ikke allerede har det

### 2. Opprett et personlig tilgangstoken
1. Gå til [GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens)
2. Klikk "Generate new token" → "Generate new token (classic)"
3. Gi tokenet et beskrivende navn (f.eks. "MCP Calculator Client")
4. Sett utløpstid etter behov
5. Velg følgende scopes:
   - `repo` (hvis du skal ha tilgang til private repositorier)
   - `user:email`
6. Klikk "Generate token"
7. **Viktig**: Kopier tokenet med en gang – du får ikke se det igjen!

### 3. Sett miljøvariabelen

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

## Oppsett og installasjon

1. **Klon eller naviger til prosjektmappen**

2. **Installer avhengigheter**:
   ```cmd
   mvnw clean install
   ```
   Eller hvis du har Maven installert globalt:
   ```cmd
   mvn clean install
   ```

3. **Sett opp miljøvariabelen** (se "Slik får du GitHub-tokenet" ovenfor)

4. **Start MCP kalkulatortjenesten**:
   Sørg for at kapittel 1 sin MCP kalkulatortjeneste kjører på `http://localhost:8080/sse`. Denne må være oppe før du starter klienten.

## Kjøre applikasjonen

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Hva applikasjonen gjør

Applikasjonen demonstrerer tre hovedinteraksjoner med kalkulatortjenesten:

1. **Addisjon**: Regner ut summen av 24.5 og 17.3
2. **Kvadratrot**: Regner ut kvadratroten av 144
3. **Hjelp**: Viser tilgjengelige kalkulatorfunksjoner

## Forventet output

Når den kjører som den skal, bør du se output som ligner på:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## Feilsøking

### Vanlige problemer

1. **"GITHUB_TOKEN environment variable not set"**
   - Pass på at du har satt `GITHUB_TOKEN` environment variable
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

For å aktivere debug-logging, legg til følgende JVM-argument når du kjører:
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Konfigurasjon

Applikasjonen er konfigurert til å:
- Bruke GitHub Models med `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse`
- Ha en 60 sekunders timeout på forespørsler
- Aktivere logging av forespørsler og svar for debugging

## Avhengigheter

Viktige avhengigheter brukt i prosjektet:
- **LangChain4j**: For AI-integrasjon og verktøyhåndtering
- **LangChain4j MCP**: For Model Context Protocol-støtte
- **LangChain4j GitHub Models**: For integrasjon med GitHub Models
- **Spring Boot**: For applikasjonsrammeverk og dependency injection

## Lisens

Dette prosjektet er lisensiert under Apache License 2.0 – se [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) for detaljer.

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på originalspråket skal betraktes som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.