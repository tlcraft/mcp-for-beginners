<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:24:31+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "ne"
}
-->
# Calculator LLM Client

LangChain4j प्रयोग गरेर MCP (Model Context Protocol) क्यालकुलेटर सेवा GitHub Models इन्ग्रेशनसहित कसरी जडान गर्ने देखाउने एउटा Java एप्लिकेसन।

## पूर्वआवश्यकताहरू

- Java 21 वा माथि
- Maven 3.6+ (वा समावेश गरिएको Maven wrapper प्रयोग गर्नुहोस्)
- GitHub Models पहुँच भएको GitHub खाता
- `http://localhost:8080` मा चलिरहेको MCP क्यालकुलेटर सेवा

## GitHub Token कसरी प्राप्त गर्ने

यो एप्लिकेसनले GitHub Models प्रयोग गर्छ जसका लागि GitHub व्यक्तिगत पहुँच टोकन चाहिन्छ। आफ्नो टोकन पाउन यी चरणहरू पालना गर्नुहोस्:

### 1. GitHub Models पहुँच गर्नुहोस्
1. [GitHub Models](https://github.com/marketplace/models) मा जानुहोस्
2. आफ्नो GitHub खाताबाट साइन इन गर्नुहोस्
3. यदि पहिले गर्नुभएको छैन भने GitHub Models पहुँचको लागि अनुरोध गर्नुहोस्

### 2. व्यक्तिगत पहुँच टोकन बनाउनुहोस्
1. [GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens) मा जानुहोस्
2. "Generate new token" → "Generate new token (classic)" मा क्लिक गर्नुहोस्
3. टोकनलाई वर्णनात्मक नाम दिनुहोस् (जस्तै, "MCP Calculator Client")
4. आवश्यक अनुसार समाप्ति समय सेट गर्नुहोस्
5. तलका स्कोपहरू चयन गर्नुहोस्:
   - `repo` (यदि निजी रिपोजिटोरीहरू पहुँच गर्नुपर्ने हो भने)
   - `user:email`
6. "Generate token" मा क्लिक गर्नुहोस्
7. **महत्त्वपूर्ण**: टोकन तुरुन्तै कपी गर्नुहोस् - पछि फेरि देख्न सकिने छैन!

### 3. वातावरण चर सेट गर्नुहोस्

#### Windows (Command Prompt) मा:
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### Windows (PowerShell) मा:
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### macOS/Linux मा:
```bash
export GITHUB_TOKEN=your_github_token_here
```

## सेटअप र स्थापना

1. **प्रोजेक्ट डाइरेक्टरी क्लोन वा त्यहाँ जानुहोस्**

2. **निर्भरता स्थापना गर्नुहोस्**:
   ```cmd
   mvnw clean install
   ```
   वा Maven ग्लोबली इन्स्टल गरिएको छ भने:
   ```cmd
   mvn clean install
   ```

3. **वातावरण चर सेट गर्नुहोस्** (माथिको "GitHub Token कसरी प्राप्त गर्ने" खण्ड हेर्नुहोस्)

4. **MCP Calculator सेवा सुरु गर्नुहोस्**:
   chapter 1 को MCP क्यालकुलेटर सेवा `http://localhost:8080/sse` मा चलिरहेको छ भनी सुनिश्चित गर्नुहोस्। क्लाइन्ट सुरु गर्नु अघि यो चलिरहेको हुनु आवश्यक छ।

## एप्लिकेसन चलाउने तरिका

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## एप्लिकेसनले के गर्छ

एप्लिकेसनले क्यालकुलेटर सेवासँग तीन मुख्य अन्तरक्रियाहरू देखाउँछ:

1. **जोड**: 24.5 र 17.3 को योग गणना गर्छ
2. **स्क्वायर रुट**: 144 को वर्गमूल निकाल्छ
3. **मद्दत**: उपलब्ध क्यालकुलेटर फङ्सनहरू देखाउँछ

## अपेक्षित नतिजा

सफलतापूर्वक चलाउँदा, तपाईंले यस प्रकारको नतिजा देख्नुहुनेछ:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## समस्या समाधान

### सामान्य समस्या

1. **"GITHUB_TOKEN environment variable not set"**
   - सुनिश्चित गर्नुहोस् कि तपाईंले `GITHUB_TOKEN` environment variable
   - Restart your terminal/command prompt after setting the variable

2. **"Connection refused to localhost:8080"**
   - Ensure the MCP calculator service is running on port 8080
   - Check if another service is using port 8080

3. **"Authentication failed"**
   - Verify your GitHub token is valid and has the correct permissions
   - Check if you have access to GitHub Models

4. **Maven build errors**
   - Ensure you're using Java 21 or higher: `java -version`
   - Try cleaning the build: `mvnw clean` सेट गर्नुभएको छ

### डिबगिङ

डिबग लगिङ सक्षम गर्न, एप्लिकेसन चलाउँदा तलको JVM आर्गुमेन्ट थप्नुहोस्:
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## कन्फिगरेसन

एप्लिकेसन यसरी कन्फिगर गरिएको छ:
- GitHub Models `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse` सँग प्रयोग गर्ने
- अनुरोधहरूको लागि ६० सेकेण्डको टाइमआउट सेट गर्ने
- डिबगिङका लागि अनुरोध/प्रतिक्रिया लगिङ सक्षम गर्ने

## निर्भरता

यो प्रोजेक्टमा मुख्य निर्भरता:
- **LangChain4j**: AI इन्ग्रेशन र टूल व्यवस्थापनका लागि
- **LangChain4j MCP**: Model Context Protocol समर्थनका लागि
- **LangChain4j GitHub Models**: GitHub Models इन्ग्रेशनका लागि
- **Spring Boot**: एप्लिकेसन फ्रेमवर्क र निर्भरता इन्जेक्सनका लागि

## लाइसेन्स

यो प्रोजेक्ट Apache License 2.0 अन्तर्गत लाइसेन्स गरिएको छ - विस्तृत जानकारीको लागि [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) फाइल हेर्नुहोस्।

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताको लागि प्रयासरत छौं, तर कृपया जानकार रहनुहोस् कि स्वचालित अनुवादमा त्रुटि वा अशुद्धि हुन सक्नेछ। मूल दस्तावेज यसको मूल भाषामा आधिकारिक स्रोतको रूपमा मानिनु पर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानवीय अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।