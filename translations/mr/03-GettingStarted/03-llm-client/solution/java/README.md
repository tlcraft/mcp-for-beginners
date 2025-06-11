<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:24:02+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "mr"
}
-->
# Calculator LLM Client

LangChain4j वापरून MCP (Model Context Protocol) कॅल्क्युलेटर सेवा GitHub Models इंटिग्रेशनसह कशी कनेक्ट करायची हे दाखवणारे Java अॅप्लिकेशन.

## आवश्यकताः

- Java 21 किंवा त्याहून वर
- Maven 3.6+ (किंवा समाविष्ट Maven wrapper वापरा)
- GitHub Models साठी प्रवेश असलेले GitHub खाते
- `http://localhost:8080` वर चालणारी MCP कॅल्क्युलेटर सेवा

## GitHub Token कसा मिळवायचा

हे अॅप्लिकेशन GitHub Models वापरते ज्यासाठी GitHub personal access token आवश्यक आहे. तुमचा token मिळवण्यासाठी खालील पावले फॉलो करा:

### 1. GitHub Models मध्ये प्रवेश करा
1. [GitHub Models](https://github.com/marketplace/models) वर जा
2. तुमच्या GitHub खात्याने साइन इन करा
3. जर आधीपासून प्रवेश नसेल तर GitHub Models साठी access request करा

### 2. Personal Access Token तयार करा
1. [GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens) वर जा
2. "Generate new token" → "Generate new token (classic)" क्लिक करा
3. तुमच्या token ला वर्णनात्मक नाव द्या (उदा., "MCP Calculator Client")
4. आवश्यकतेनुसार expiration सेट करा
5. खालील scopes निवडा:
   - `repo` (जर प्रायव्हेट रिपॉझिटरीजमध्ये प्रवेश असेल तर)
   - `user:email`
6. "Generate token" क्लिक करा
7. **महत्त्वाचे**: token लगेच कॉपी करा - पुन्हा ते पाहता येणार नाही!

### 3. Environment Variable सेट करा

#### Windows (Command Prompt) वर:
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### Windows (PowerShell) वर:
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### macOS/Linux वर:
```bash
export GITHUB_TOKEN=your_github_token_here
```

## सेटअप आणि इन्स्टॉलेशन

1. **प्रोजेक्ट डायरेक्टरी क्लोन करा किंवा त्यात जा**

2. **डिपेंडन्सी इन्स्टॉल करा**:
   ```cmd
   mvnw clean install
   ```
   किंवा Maven ग्लोबली इंस्टॉल केले असल्यास:
   ```cmd
   mvn clean install
   ```

3. **Environment variable सेट करा** (वरील "Getting the GitHub Token" सेक्शन पहा)

4. **MCP Calculator Service सुरू करा**:
   chapter 1 मधील MCP कॅल्क्युलेटर सेवा `http://localhost:8080/sse` वर चालू असावी. क्लायंट सुरू करण्यापूर्वी ही सेवा चालू असणे आवश्यक आहे.

## अॅप्लिकेशन कसे चालवायचे

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## अॅप्लिकेशन काय करते

हे अॅप्लिकेशन कॅल्क्युलेटर सेवेसह तीन मुख्य संवाद दाखवते:

1. **बेरीज**: 24.5 आणि 17.3 ची बेरीज काढते
2. **वर्गमुळ**: 144 चा वर्गमुळ काढते
3. **मदत**: उपलब्ध कॅल्क्युलेटर फंक्शन्स दाखवते

## अपेक्षित आउटपुट

यशस्वीपणे चालविल्यावर, खालीलप्रमाणे आउटपुट दिसेल:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## समस्या निवारण

### सामान्य समस्या

1. **"GITHUB_TOKEN environment variable not set"**
   - खात्री करा की तुम्ही `GITHUB_TOKEN` सेट केले आहे` environment variable
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

### डीबगिंग

डीबग लॉगिंग सक्षम करण्यासाठी, अॅप्लिकेशन चालवताना खालील JVM argument जोडा:
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## कॉन्फिगरेशन

अॅप्लिकेशन खालीलप्रमाणे कॉन्फिगर केले आहे:
- GitHub Models वापरते `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse`
- विनंत्यांसाठी 60 सेकंदांचा timeout सेट केला आहे
- डीबगिंगसाठी request/response लॉगिंग सक्षम केले आहे

## डिपेंडन्सीज

या प्रोजेक्टमध्ये वापरल्या जाणार्‍या मुख्य डिपेंडन्सीज:
- **LangChain4j**: AI इंटिग्रेशन आणि टूल मॅनेजमेंटसाठी
- **LangChain4j MCP**: Model Context Protocol सपोर्टसाठी
- **LangChain4j GitHub Models**: GitHub Models इंटिग्रेशनसाठी
- **Spring Boot**: अॅप्लिकेशन फ्रेमवर्क आणि dependency injection साठी

## परवाना

हा प्रोजेक्ट Apache License 2.0 अंतर्गत परवानाधारक आहे - तपशीलांसाठी [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) फाइल पहा.

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्न करतो, तरी कृपया लक्षात ठेवा की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेची कमतरता असू शकते. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद शिफारसीय आहे. या अनुवादाच्या वापरामुळे उद्भवलेल्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलाभाबद्दल आम्ही जबाबदार नाही.