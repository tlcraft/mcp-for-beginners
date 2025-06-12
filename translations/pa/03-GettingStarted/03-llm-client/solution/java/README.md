<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:24:56+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "pa"
}
-->
# Calculator LLM Client

ਇੱਕ ਜਾਵਾ ਐਪਲੀਕੇਸ਼ਨ ਜੋ ਦਿਖਾਉਂਦਾ ਹੈ ਕਿ ਕਿਵੇਂ LangChain4j ਦੀ ਵਰਤੋਂ ਕਰਕੇ MCP (Model Context Protocol) ਕੈਲਕੂਲੇਟਰ ਸੇਵਾ ਨਾਲ GitHub Models ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਦੇ ਨਾਲ ਜੁੜਿਆ ਜਾ ਸਕਦਾ ਹੈ।

## ਲੋੜੀਂਦੀਆਂ ਚੀਜ਼ਾਂ

- ਜਾਵਾ 21 ਜਾਂ ਉਪਰ
- Maven 3.6+ (ਜਾਂ ਸ਼ਾਮਿਲ Maven wrapper ਦੀ ਵਰਤੋਂ ਕਰੋ)
- GitHub Models ਤੱਕ ਪਹੁੰਚ ਵਾਲਾ GitHub ਖਾਤਾ
- ਇੱਕ MCP ਕੈਲਕੂਲੇਟਰ ਸੇਵਾ ਜੋ `http://localhost:8080` 'ਤੇ ਚੱਲ ਰਹੀ ਹੋਵੇ

## GitHub ਟੋਕਨ ਪ੍ਰਾਪਤ ਕਰਨਾ

ਇਹ ਐਪਲੀਕੇਸ਼ਨ GitHub Models ਦੀ ਵਰਤੋਂ ਕਰਦਾ ਹੈ ਜਿਸ ਲਈ GitHub personal access token ਦੀ ਲੋੜ ਹੁੰਦੀ ਹੈ। ਆਪਣਾ ਟੋਕਨ ਪ੍ਰਾਪਤ ਕਰਨ ਲਈ ਹੇਠਾਂ ਦਿੱਤੇ ਕਦਮ ਫੋਲੋ ਕਰੋ:

### 1. GitHub Models ਤੱਕ ਪਹੁੰਚ ਕਰੋ
1. [GitHub Models](https://github.com/marketplace/models) 'ਤੇ ਜਾਓ
2. ਆਪਣੇ GitHub ਖਾਤੇ ਨਾਲ ਸਾਈਨ ਇਨ ਕਰੋ
3. ਜੇ ਤੁਸੀਂ ਪਹਿਲਾਂ ਨਹੀਂ ਕੀਤਾ ਤਾਂ GitHub Models ਲਈ ਐਕਸੈਸ ਦੀ ਬੇਨਤੀ ਕਰੋ

### 2. Personal Access Token ਬਣਾਓ
1. [GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens) 'ਤੇ ਜਾਓ
2. "Generate new token" → "Generate new token (classic)" 'ਤੇ ਕਲਿੱਕ ਕਰੋ
3. ਆਪਣੇ ਟੋਕਨ ਨੂੰ ਵਰਨਨਾਤਮਕ ਨਾਮ ਦਿਓ (ਜਿਵੇਂ "MCP Calculator Client")
4. ਜਰੂਰਤ ਮੁਤਾਬਕ ਮਿਆਦ ਸੈੱਟ ਕਰੋ
5. ਹੇਠਾਂ ਦਿੱਤੇ ਸਕੋਪ ਚੁਣੋ:
   - `repo` (ਜੇ ਪ੍ਰਾਈਵੇਟ ਰਿਪੋਜ਼ਿਟਰੀਜ਼ ਤੱਕ ਪਹੁੰਚ ਹੈ)
   - `user:email`
6. "Generate token" 'ਤੇ ਕਲਿੱਕ ਕਰੋ
7. **ਮਹੱਤਵਪੂਰਨ**: ਟੋਕਨ ਨੂੰ ਤੁਰੰਤ ਕਾਪੀ ਕਰੋ - ਇਹ ਮੁੜ ਨਹੀਂ ਵੇਖਿਆ ਜਾ ਸਕਦਾ!

### 3. Environment Variable ਸੈੱਟ ਕਰੋ

#### Windows (Command Prompt) 'ਤੇ:
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### Windows (PowerShell) 'ਤੇ:
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### macOS/Linux 'ਤੇ:
```bash
export GITHUB_TOKEN=your_github_token_here
```

## ਸੈਟਅਪ ਅਤੇ ਇੰਸਟਾਲੇਸ਼ਨ

1. **ਪ੍ਰੋਜੈਕਟ ਡਾਇਰੈਕਟਰੀ ਕਲੋਨ ਕਰੋ ਜਾਂ ਉਸ ਵਿੱਚ ਜਾਓ**

2. **ਡਿਪੈਂਡੈਂਸੀਜ਼ ਇੰਸਟਾਲ ਕਰੋ**:
   ```cmd
   mvnw clean install
   ```
   ਜਾਂ ਜੇ ਤੁਹਾਡੇ ਕੋਲ Maven ਗਲੋਬਲੀ ਇੰਸਟਾਲ ਹੈ:
   ```cmd
   mvn clean install
   ```

3. **Environment Variable ਸੈੱਟ ਕਰੋ** (ਉੱਪਰ "Getting the GitHub Token" ਭਾਗ ਵੇਖੋ)

4. **MCP Calculator Service ਚਾਲੂ ਕਰੋ**:
   ਯਕੀਨੀ ਬਣਾਓ ਕਿ chapter 1 ਦਾ MCP calculator service `http://localhost:8080/sse` 'ਤੇ ਚੱਲ ਰਿਹਾ ਹੈ। ਇਹ ਸੇਵਾ ਕਲਾਇੰਟ ਸ਼ੁਰੂ ਕਰਨ ਤੋਂ ਪਹਿਲਾਂ ਚੱਲ ਰਹੀ ਹੋਣੀ ਚਾਹੀਦੀ ਹੈ।

## ਐਪਲੀਕੇਸ਼ਨ ਚਲਾਉਣਾ

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## ਐਪਲੀਕੇਸ਼ਨ ਕੀ ਕਰਦਾ ਹੈ

ਐਪਲੀਕੇਸ਼ਨ ਕੈਲਕੂਲੇਟਰ ਸੇਵਾ ਨਾਲ ਤਿੰਨ ਮੁੱਖ ਇੰਟਰਐਕਸ਼ਨਾਂ ਨੂੰ ਦਰਸਾਉਂਦਾ ਹੈ:

1. **ਜੋੜ**: 24.5 ਅਤੇ 17.3 ਦਾ ਜੋੜ ਕੈਲਕੂਲੇਟ ਕਰਦਾ ਹੈ
2. **ਵਰਗਮੂਲ**: 144 ਦਾ ਵਰਗਮੂਲ ਕੈਲਕੂਲੇਟ ਕਰਦਾ ਹੈ
3. **ਮਦਦ**: ਉਪਲਬਧ ਕੈਲਕੂਲੇਟਰ ਫੰਕਸ਼ਨਾਂ ਨੂੰ ਦਿਖਾਉਂਦਾ ਹੈ

## ਉਮੀਦ ਕੀਤੀ ਗਈ ਆਉਟਪੁੱਟ

ਸਫਲਤਾ ਨਾਲ ਚਲਾਉਣ 'ਤੇ, ਤੁਸੀਂ ਇਸ ਤਰ੍ਹਾਂ ਦੀ ਆਉਟਪੁੱਟ ਵੇਖੋਗੇ:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## ਸਮੱਸਿਆਵਾਂ ਦਾ ਹੱਲ

### ਆਮ ਸਮੱਸਿਆਵਾਂ

1. **"GITHUB_TOKEN environment variable not set"**
   - ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਤੁਸੀਂ `GITHUB_TOKEN` ਸੈੱਟ ਕੀਤਾ ਹੈ` environment variable
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

### ਡੀਬੱਗਿੰਗ

ਡੀਬੱਗ ਲੌਗਿੰਗ ਚਾਲੂ ਕਰਨ ਲਈ, ਐਪ ਚਲਾਉਂਦੇ ਸਮੇਂ ਹੇਠਾਂ ਦਿੱਤਾ JVM argument ਸ਼ਾਮਿਲ ਕਰੋ:
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## ਸੰਰਚਨਾ

ਐਪਲੀਕੇਸ਼ਨ ਨੂੰ ਇਸ ਤਰ੍ਹਾਂ ਸੰਰਚਿਤ ਕੀਤਾ ਗਿਆ ਹੈ:
- GitHub Models ਨੂੰ `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse` ਨਾਲ ਵਰਤਣਾ
- ਬੇਨਤੀ ਲਈ 60 ਸਕਿੰਟ ਦੀ timeout
- ਡੀਬੱਗਿੰਗ ਲਈ ਬੇਨਤੀ/ਜਵਾਬ ਲੌਗਿੰਗ ਚਾਲੂ

## ਡਿਪੈਂਡੈਂਸੀਜ਼

ਇਸ ਪ੍ਰੋਜੈਕਟ ਵਿੱਚ ਮੁੱਖ ਤੌਰ 'ਤੇ ਵਰਤੀ ਗਈਆਂ ਡਿਪੈਂਡੈਂਸੀਜ਼:
- **LangChain4j**: AI ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਅਤੇ ਟੂਲ ਮੈਨੇਜਮੈਂਟ ਲਈ
- **LangChain4j MCP**: Model Context Protocol ਸਹਾਇਤਾ ਲਈ
- **LangChain4j GitHub Models**: GitHub Models ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਲਈ
- **Spring Boot**: ਐਪਲੀਕੇਸ਼ਨ ਫਰੇਮਵਰਕ ਅਤੇ ਡਿਪੈਂਡੈਂਸੀ ਇੰਜੈਕਸ਼ਨ ਲਈ

## ਲਾਇਸੈਂਸ

ਇਹ ਪ੍ਰੋਜੈਕਟ Apache License 2.0 ਅਧੀਨ ਲਾਇਸੈਂਸਡ ਹੈ - ਵੇਰਵਿਆਂ ਲਈ [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) ਫਾਇਲ ਵੇਖੋ।

**ਡਿਸਕਲੇਮਰ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਅਤ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਵਿੱਚ ਰੱਖੋ ਕਿ ਆਟੋਮੇਟਿਕ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਹੀਤੀਆਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਅਧਿਕਾਰਤ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਜਰੂਰੀ ਜਾਣਕਾਰੀ ਲਈ, ਪ੍ਰੋਫੈਸ਼ਨਲ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫ਼ਾਰਿਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਪੈਦਾ ਹੋਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀਆਂ ਜਾਂ ਭੁੱਲਾਂ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।