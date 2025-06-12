<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:21:28+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "mo"
}
-->
# Calculator LLM Client

Java-gyi application a langChain4j-ka MCP (Model Context Protocol) calculator service GitHub Models integration-te connect tlat a si ahcun i hman tthan a si.

## Prerequisites

- Java 21 le thil pawl
- Maven 3.6+ (mipin Maven wrapper a si lole)
- GitHub account a GitHub Models access a si
- MCP calculator service a `http://localhost:8080` ah a run tthan

## Getting the GitHub Token

Hi application hi GitHub Models hman a si i, GitHub personal access token a theih nakin a um. Token a hman theih nakin thil pakhat pawimawh a si:

### 1. GitHub Models a tawn
1. [GitHub Models](https://github.com/marketplace/models) ah a tawn
2. GitHub account hmanin sign in rawh
3. GitHub Models access request lole a si tikah

### 2. Personal Access Token a siam
1. [GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens) ah a tawn
2. "Generate new token" → "Generate new token (classic)" a click rawh
3. Token hi hman theih a si lole a si ttha a sianginn a si (e.g., "MCP Calculator Client")
4. Expiration a si theih a si
5. Scope pawl hi thil pakhat hman:
   - `repo` (private repositories access theih nakin)
   - `user:email`
6. "Generate token" a click rawh
7. **Pawimawh**: Token hi copy in a sianginn - a um lo in i hman lai lo!

### 3. Environment Variable a set

#### Windows (Command Prompt) ah:
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### Windows (PowerShell) ah:
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### macOS/Linux ah:
```bash
export GITHUB_TOKEN=your_github_token_here
```

## Setup le Installation

1. **Project directory a clone lole a tawn**

2. **Dependencies a install**:
   ```cmd
   mvnw clean install
   ```
   Maven a um tikah:
   ```cmd
   mvn clean install
   ```

3. **Environment variable a set** ( "Getting the GitHub Token" section ah i ti in)

4. **MCP Calculator Service a start**:
   Chapter 1 MCP calculator service `http://localhost:8080/sse` ah a run tthan a si i, client a start nakin a run tthan a si.

## Application a run nak

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Application cu thil pakhat thil hman a si

Calculator service ah thil pakhat thil hman a si:

1. **Addition**: 24.5 le 17.3 a sum a si
2. **Square Root**: 144 chung ah square root a si
3. **Help**: Calculator function pawl a hman theih nak a show a si

## Expected Output

Application hi run tikah output hi a si ko hman:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## Troubleshooting

### Common Issues

1. **"GITHUB_TOKEN environment variable not set"**
   - `GITHUB_TOKEN` hi set in a si ko hman
   - `` environment variable
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

Debug logging a enable nakin JVM argument hi i hman rawh:
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Configuration

Application cu:
- GitHub Models hman a si le `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse`
- Request timeout 60 seconds a si
- Request/response logging a enable tthan nakin debugging a theih

## Dependencies

Project cu thil pakhat dependency a hman:
- **LangChain4j**: AI integration le tool management
- **LangChain4j MCP**: Model Context Protocol support
- **LangChain4j GitHub Models**: GitHub Models integration
- **Spring Boot**: Application framework le dependency injection

## License

Project hi Apache License 2.0 ah a licens a si - [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) file ah a hman theih.

**Disclaimer**:  
This document has been translated using AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). While we strive for accuracy, please be aware that automated translations may contain errors or inaccuracies. The original document in its native language should be considered the authoritative source. For critical information, professional human translation is recommended. We are not liable for any misunderstandings or misinterpretations arising from the use of this translation.

---

Note: "mo" is not a widely recognized language code or name. Could you please clarify which language you mean by "mo"? For example, it might be Moldovan (which is essentially Romanian), or something else. This will help me provide an accurate translation.