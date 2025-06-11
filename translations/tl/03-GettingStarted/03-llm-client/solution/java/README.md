<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:31:29+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "tl"
}
-->
# Calculator LLM Client

Isang Java application na nagpapakita kung paano gamitin ang LangChain4j para kumonekta sa isang MCP (Model Context Protocol) calculator service na may integrasyon ng GitHub Models.

## Mga Kinakailangan

- Java 21 o mas mataas
- Maven 3.6+ (o gamitin ang kasamang Maven wrapper)
- Isang GitHub account na may access sa GitHub Models
- Isang MCP calculator service na tumatakbo sa `http://localhost:8080`

## Pagkuha ng GitHub Token

Gumagamit ang application na ito ng GitHub Models na nangangailangan ng personal access token mula sa GitHub. Sundan ang mga hakbang na ito para makuha ang iyong token:

### 1. Pumunta sa GitHub Models
1. Buksan ang [GitHub Models](https://github.com/marketplace/models)
2. Mag-sign in gamit ang iyong GitHub account
3. Humiling ng access sa GitHub Models kung hindi ka pa nakakapag-request

### 2. Gumawa ng Personal Access Token
1. Pumunta sa [GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens)
2. I-click ang "Generate new token" → "Generate new token (classic)"
3. Bigyan ng malinaw na pangalan ang iyong token (hal., "MCP Calculator Client")
4. Itakda ang expiration kung kinakailangan
5. Piliin ang mga sumusunod na scopes:
   - `repo` (kung aakses ang private repositories)
   - `user:email`
6. I-click ang "Generate token"
7. **Mahalaga**: Kopyahin agad ang token - hindi mo na ito makikita muli!

### 3. Itakda ang Environment Variable

#### Sa Windows (Command Prompt):
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### Sa Windows (PowerShell):
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### Sa macOS/Linux:
```bash
export GITHUB_TOKEN=your_github_token_here
```

## Setup at Pag-install

1. **I-clone o pumunta sa project directory**

2. **I-install ang mga dependencies**:
   ```cmd
   mvnw clean install
   ```
   O kung naka-install ang Maven globally:
   ```cmd
   mvn clean install
   ```

3. **Itakda ang environment variable** (tingnan ang seksyong "Pagkuha ng GitHub Token" sa itaas)

4. **Simulan ang MCP Calculator Service**:
   Siguraduhing tumatakbo ang MCP calculator service mula sa chapter 1 sa `http://localhost:8080/sse`. Dapat itong tumakbo bago simulan ang client.

## Pagsisimula ng Application

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Ano ang Ginagawa ng Application

Ipinapakita ng application ang tatlong pangunahing interaksyon sa calculator service:

1. **Addition**: Kinakalkula ang kabuuan ng 24.5 at 17.3
2. **Square Root**: Kinakalkula ang square root ng 144
3. **Help**: Ipinapakita ang mga available na calculator functions

## Inaasahang Output

Kapag matagumpay na tumakbo, makikita mo ang output na katulad ng:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## Pag-aayos ng Problema

### Mga Karaniwang Isyu

1. **"GITHUB_TOKEN environment variable not set"**
   - Siguraduhing naitakda mo ang `GITHUB_TOKEN` environment variable
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

### Pag-debug

Para paganahin ang debug logging, idagdag ang sumusunod na JVM argument kapag nagpapatakbo:
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Konfigurasyon

Nakakonpigura ang application para:
- Gamitin ang GitHub Models gamit ang `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse`
- Gumamit ng 60-segundong timeout para sa mga request
- Paganahin ang request/response logging para sa debugging

## Mga Dependencies

Pangunahing mga dependencies na ginamit sa proyektong ito:
- **LangChain4j**: Para sa AI integration at pamamahala ng tools
- **LangChain4j MCP**: Para sa suporta sa Model Context Protocol
- **LangChain4j GitHub Models**: Para sa integrasyon ng GitHub Models
- **Spring Boot**: Para sa application framework at dependency injection

## Lisensya

Ang proyektong ito ay lisensyado sa ilalim ng Apache License 2.0 - tingnan ang [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) file para sa mga detalye.

**Pagtatanggol**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na opisyal na sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.