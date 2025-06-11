<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:30:01+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "nl"
}
-->
# Calculator LLM Client

Een Java-applicatie die laat zien hoe je LangChain4j gebruikt om verbinding te maken met een MCP (Model Context Protocol) calculatorservice met integratie van GitHub Models.

## Vereisten

- Java 21 of hoger
- Maven 3.6+ (of gebruik de meegeleverde Maven wrapper)
- Een GitHub-account met toegang tot GitHub Models
- Een MCP calculatorservice draaiend op `http://localhost:8080`

## Het verkrijgen van de GitHub-token

Deze applicatie gebruikt GitHub Models, waarvoor een persoonlijke toegangstoken van GitHub nodig is. Volg deze stappen om je token te krijgen:

### 1. Toegang krijgen tot GitHub Models
1. Ga naar [GitHub Models](https://github.com/marketplace/models)
2. Log in met je GitHub-account
3. Vraag toegang aan tot GitHub Models als je dat nog niet hebt gedaan

### 2. Maak een persoonlijke toegangstoken aan
1. Ga naar [GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens)
2. Klik op "Generate new token" → "Generate new token (classic)"
3. Geef je token een duidelijke naam (bijv. "MCP Calculator Client")
4. Stel de vervaldatum in naar wens
5. Selecteer de volgende scopes:
   - `repo` (als je toegang nodig hebt tot privé repositories)
   - `user:email`
6. Klik op "Generate token"
7. **Belangrijk**: Kopieer de token direct - je kunt hem later niet meer zien!

### 3. Stel de omgevingsvariabele in

#### Op Windows (Command Prompt):
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### Op Windows (PowerShell):
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### Op macOS/Linux:
```bash
export GITHUB_TOKEN=your_github_token_here
```

## Installatie en setup

1. **Clone of navigeer naar de projectmap**

2. **Installeer de dependencies**:
   ```cmd
   mvnw clean install
   ```
   Of als je Maven globaal hebt geïnstalleerd:
   ```cmd
   mvn clean install
   ```

3. **Stel de omgevingsvariabele in** (zie sectie "Het verkrijgen van de GitHub-token" hierboven)

4. **Start de MCP Calculator Service**:
   Zorg dat de MCP calculatorservice uit hoofdstuk 1 draait op `http://localhost:8080/sse`. Deze moet actief zijn voordat je de client start.

## De applicatie uitvoeren

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Wat de applicatie doet

De applicatie laat drie belangrijke interacties met de calculatorservice zien:

1. **Optellen**: Berekent de som van 24,5 en 17,3
2. **Wortel trekken**: Berekent de wortel van 144
3. **Help**: Toont beschikbare calculatorfuncties

## Verwachte output

Bij een succesvolle uitvoering zie je een output die lijkt op:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## Problemen oplossen

### Veelvoorkomende problemen

1. **"GITHUB_TOKEN environment variable not set"**
   - Controleer of je de `GITHUB_TOKEN` environment variable
   - Restart your terminal/command prompt after setting the variable

2. **"Connection refused to localhost:8080"**
   - Ensure the MCP calculator service is running on port 8080
   - Check if another service is using port 8080

3. **"Authentication failed"**
   - Verify your GitHub token is valid and has the correct permissions
   - Check if you have access to GitHub Models

4. **Maven build errors**
   - Ensure you're using Java 21 or higher: `java -version`
   - Try cleaning the build: `mvnw clean` hebt ingesteld

### Debuggen

Om debug-logging in te schakelen, voeg je de volgende JVM-argument toe bij het uitvoeren:
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Configuratie

De applicatie is geconfigureerd om:
- GitHub Models te gebruiken met `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse`
- Een timeout van 60 seconden voor verzoeken te hanteren
- Logging van verzoeken/antwoorden in te schakelen voor debugging

## Dependencies

Belangrijke dependencies in dit project:
- **LangChain4j**: Voor AI-integratie en toolbeheer
- **LangChain4j MCP**: Voor ondersteuning van Model Context Protocol
- **LangChain4j GitHub Models**: Voor integratie met GitHub Models
- **Spring Boot**: Voor het applicatieframework en dependency injection

## Licentie

Dit project is gelicentieerd onder de Apache License 2.0 - zie het [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) bestand voor details.

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat automatische vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.