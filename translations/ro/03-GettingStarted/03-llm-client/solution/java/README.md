<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:33:25+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "ro"
}
-->
# Calculator LLM Client

O aplicație Java care demonstrează cum să folosești LangChain4j pentru a te conecta la un serviciu MCP (Model Context Protocol) calculator cu integrare GitHub Models.

## Cerințe preliminare

- Java 21 sau versiune superioară
- Maven 3.6+ (sau folosește Maven wrapper-ul inclus)
- Un cont GitHub cu acces la GitHub Models
- Un serviciu MCP calculator care rulează pe `http://localhost:8080`

## Obținerea Token-ului GitHub

Această aplicație folosește GitHub Models, care necesită un token de acces personal GitHub. Urmează pașii de mai jos pentru a obține token-ul:

### 1. Accesează GitHub Models
1. Mergi la [GitHub Models](https://github.com/marketplace/models)
2. Autentifică-te cu contul tău GitHub
3. Solicită acces la GitHub Models dacă nu ai făcut-o deja

### 2. Creează un Token de Acces Personal
1. Mergi la [GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens)
2. Apasă pe "Generate new token" → "Generate new token (classic)"
3. Dă token-ului un nume descriptiv (ex. "MCP Calculator Client")
4. Setează expirarea după cum este necesar
5. Selectează următoarele scope-uri:
   - `repo` (dacă accesezi repository-uri private)
   - `user:email`
6. Apasă pe "Generate token"
7. **Important**: Copiază token-ul imediat - nu vei mai putea să-l vezi din nou!

### 3. Setează Variabila de Mediu

#### Pe Windows (Command Prompt):
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### Pe Windows (PowerShell):
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### Pe macOS/Linux:
```bash
export GITHUB_TOKEN=your_github_token_here
```

## Configurare și Instalare

1. **Clonează sau navighează în directorul proiectului**

2. **Instalează dependențele**:
   ```cmd
   mvnw clean install
   ```
   Sau dacă ai Maven instalat global:
   ```cmd
   mvn clean install
   ```

3. **Setează variabila de mediu** (vezi secțiunea "Obținerea Token-ului GitHub" de mai sus)

4. **Pornește serviciul MCP Calculator**:
   Asigură-te că serviciul MCP calculator din capitolul 1 rulează pe `http://localhost:8080/sse`. Acesta trebuie să fie pornit înainte de a lansa clientul.

## Rularea Aplicației

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Ce face aplicația

Aplicația demonstrează trei interacțiuni principale cu serviciul calculator:

1. **Adunare**: Calculează suma dintre 24.5 și 17.3
2. **Rădăcină pătrată**: Calculează rădăcina pătrată a lui 144
3. **Ajutor**: Afișează funcțiile disponibile ale calculatorului

## Rezultatul așteptat

La rulare cu succes, ar trebui să vezi un output similar cu:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## Depanare

### Probleme comune

1. **"GITHUB_TOKEN environment variable not set"**
   - Asigură-te că ai setat variabila `GITHUB_TOKEN` environment variable
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

Pentru a activa logging-ul de debug, adaugă următorul argument JVM la rulare:
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Configurație

Aplicația este configurată să:
- Folosească GitHub Models cu `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse`
- Folosească un timeout de 60 de secunde pentru cereri
- Activeze logging-ul cerere/răspuns pentru depanare

## Dependențe

Dependențele principale folosite în acest proiect:
- **LangChain4j**: Pentru integrare AI și managementul uneltelor
- **LangChain4j MCP**: Pentru suport Model Context Protocol
- **LangChain4j GitHub Models**: Pentru integrare GitHub Models
- **Spring Boot**: Pentru framework-ul aplicației și injecția de dependențe

## Licență

Acest proiect este licențiat sub Apache License 2.0 - vezi fișierul [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) pentru detalii.

**Declinare a responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite care pot rezulta din utilizarea acestei traduceri.