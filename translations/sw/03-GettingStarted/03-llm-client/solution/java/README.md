<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:31:48+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "sw"
}
-->
# Calculator LLM Client

Programu ya Java inayonyesha jinsi ya kutumia LangChain4j kuunganishwa na huduma ya kalkuleta ya MCP (Model Context Protocol) yenye muunganisho wa GitHub Models.

## Mahitaji

- Java 21 au zaidi
- Maven 3.6+ (au tumia Maven wrapper iliyojumuishwa)
- Akaunti ya GitHub yenye ufikiaji wa GitHub Models
- Huduma ya kalkuleta ya MCP inayotumia `http://localhost:8080`

## Kupata Tokeni ya GitHub

Programu hii inatumia GitHub Models ambayo inahitaji tokeni ya ufikiaji wa kibinafsi ya GitHub. Fuata hatua hizi kupata tokeni yako:

### 1. Ingia GitHub Models
1. Tembelea [GitHub Models](https://github.com/marketplace/models)
2. Ingia kwa akaunti yako ya GitHub
3. Omba ruhusa ya kutumia GitHub Models ikiwa bado hujafanya hivyo

### 2. Tengeneza Tokeni ya Ufikiaji wa Kibinafsi
1. Nenda kwenye [GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens)
2. Bonyeza "Generate new token" → "Generate new token (classic)"
3. Weka jina linaloelezea tokeni yako (mfano, "MCP Calculator Client")
4. Weka muda wa kumalizika kama unavyotaka
5. Chagua maeneo yafuatayo:
   - `repo` (ikiwa unahitaji kufikia repositories binafsi)
   - `user:email`
6. Bonyeza "Generate token"
7. **Muhimu**: Nakili tokeni mara moja - huwezi kuiwona tena!

### 3. Weka Kigezo cha Mazingira

#### Kwenye Windows (Command Prompt):
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### Kwenye Windows (PowerShell):
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### Kwenye macOS/Linux:
```bash
export GITHUB_TOKEN=your_github_token_here
```

## Usanidi na Ufungaji

1. **Nakili au nenda kwenye folda ya mradi**

2. **Sakinisha tegemezi**:
   ```cmd
   mvnw clean install
   ```
   Au ikiwa una Maven imewekwa duniani:
   ```cmd
   mvn clean install
   ```

3. **Weka kigezo cha mazingira** (angaliza sehemu ya "Kupata Tokeni ya GitHub" hapo juu)

4. **Anzisha Huduma ya MCP Calculator**:
   Hakikisha huduma ya MCP calculator ya sura ya 1 inafanya kazi kwenye `http://localhost:8080/sse`. Huduma hii inapaswa kuwa imeshaanza kabla hujaanzisha client.

## Kuendesha Programu

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Programu Inayofanya Nini

Programu inaonyesha maingiliano matatu makuu na huduma ya kalkuleta:

1. **Kuweka Jumla**: Hisa jumla ya 24.5 na 17.3
2. **Mzizi wa Mraba**: Hisa mzizi wa mraba wa 144
3. **Msaada**: Onyesha kazi zinazopatikana za kalkuleta

## Matokeo Yanayotarajiwa

Unapofanikiwa kuendesha, utaona matokeo yanayofanana na:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## Kutatua Matatizo

### Masuala Yanayojirudia

1. **"GITHUB_TOKEN environment variable not set"**
   - Hakikisha umeweka `GITHUB_TOKEN` environment variable
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

### Uchanganuzi wa Hitilafu

Ili kuwezesha kurekodi maelezo ya debug, ongeza hoja ifuatayo ya JVM unapokimbiza:
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Mipangilio

Programu imepangwa kutumia:
- GitHub Models na `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse`
- Muda wa kusubiri majibu wa sekunde 60
- Wezesha kurekodi maombi/majibu kwa ajili ya uchanganuzi wa matatizo

## Tegemezi

Tegemezi muhimu zinazotumika katika mradi huu:
- **LangChain4j**: Kwa muunganisho wa AI na usimamizi wa zana
- **LangChain4j MCP**: Kwa msaada wa Model Context Protocol
- **LangChain4j GitHub Models**: Kwa muunganisho wa GitHub Models
- **Spring Boot**: Kwa mfumo wa programu na usimamizi wa tegemezi

## Leseni

Mradi huu umepewa leseni chini ya Apache License 2.0 - angalia faili ya [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) kwa maelezo zaidi.

**Kang’amuzi**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuhakikisha usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati asili katika lugha yake ya asili inapaswa kuzingatiwa kama chanzo cha kuaminika. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na watu inashauriwa. Hatubebei dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.