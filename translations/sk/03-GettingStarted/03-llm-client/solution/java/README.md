<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:32:57+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "sk"
}
-->
# Calculator LLM Client

Java aplikácia, ktorá ukazuje, ako použiť LangChain4j na pripojenie k MCP (Model Context Protocol) kalkulačnej službe s integráciou GitHub Models.

## Požiadavky

- Java 21 alebo novšia
- Maven 3.6+ (alebo použite priložený Maven wrapper)
- GitHub účet s prístupom k GitHub Models
- MCP kalkulačná služba bežiaca na `http://localhost:8080`

## Získanie GitHub Tokenu

Táto aplikácia používa GitHub Models, ktoré vyžadujú osobný prístupový token GitHubu. Postupujte podľa týchto krokov, aby ste získali svoj token:

### 1. Prístup k GitHub Models
1. Prejdite na [GitHub Models](https://github.com/marketplace/models)
2. Prihláste sa so svojím GitHub účtom
3. Požiadajte o prístup k GitHub Models, ak ho ešte nemáte

### 2. Vytvorenie osobného prístupového tokenu
1. Prejdite na [GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens)
2. Kliknite na "Generate new token" → "Generate new token (classic)"
3. Pomenujte token (napr. "MCP Calculator Client")
4. Nastavte platnosť podľa potreby
5. Vyberte tieto oprávnenia:
   - `repo` (ak pristupujete k súkromným repozitárom)
   - `user:email`
6. Kliknite na "Generate token"
7. **Dôležité**: Token si okamžite skopírujte - už ho nebudete môcť zobraziť!

### 3. Nastavenie premennej prostredia

#### Na Windows (Command Prompt):
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### Na Windows (PowerShell):
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### Na macOS/Linux:
```bash
export GITHUB_TOKEN=your_github_token_here
```

## Inštalácia a nastavenie

1. **Naklonujte alebo prejdite do adresára projektu**

2. **Nainštalujte závislosti**:
   ```cmd
   mvnw clean install
   ```
   Alebo ak máte Maven globálne nainštalovaný:
   ```cmd
   mvn clean install
   ```

3. **Nastavte premennú prostredia** (pozri sekciu "Získanie GitHub Tokenu" vyššie)

4. **Spustite MCP kalkulačnú službu**:
   Uistite sa, že máte spustenú MCP kalkulačnú službu z kapitoly 1 na `http://localhost:8080/sse`. Mala by bežať pred spustením klienta.

## Spustenie aplikácie

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Čo aplikácia robí

Aplikácia demonštruje tri hlavné interakcie s kalkulačnou službou:

1. **Sčítanie**: Vypočíta súčet 24.5 a 17.3
2. **Druhá odmocnina**: Vypočíta druhú odmocninu z 144
3. **Pomoc**: Zobrazí dostupné kalkulačné funkcie

## Očakávaný výstup

Pri úspešnom spustení by ste mali vidieť výstup podobný:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## Riešenie problémov

### Bežné problémy

1. **"GITHUB_TOKEN environment variable not set"**
   - Skontrolujte, či ste nastavili premennú `GITHUB_TOKEN` environment variable
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

### Ladenie

Pre zapnutie debug logovania pridajte pri spustení JVM tento argument:
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Konfigurácia

Aplikácia je nastavená takto:
- Používa GitHub Models s `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse`
- Časový limit požiadaviek je 60 sekúnd
- Zapnuté logovanie požiadaviek a odpovedí pre ladenie

## Závislosti

Hlavné závislosti použité v tomto projekte:
- **LangChain4j**: Pre AI integráciu a správu nástrojov
- **LangChain4j MCP**: Pre podporu Model Context Protocol
- **LangChain4j GitHub Models**: Pre integráciu GitHub Models
- **Spring Boot**: Pre aplikačný framework a dependency injection

## Licencia

Tento projekt je licencovaný pod Apache License 2.0 - viac informácií nájdete v súbore [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE).

**Zrieknutie sa zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, majte prosím na pamäti, že automatické preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.