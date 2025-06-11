<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:23:20+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "hi"
}
-->
# Calculator LLM Client

एक Java एप्लिकेशन जो दिखाता है कि LangChain4j का उपयोग करके MCP (Model Context Protocol) कैलकुलेटर सेवा से GitHub Models इंटीग्रेशन के साथ कैसे कनेक्ट किया जाए।

## आवश्यकताएँ

- Java 21 या उससे ऊपर
- Maven 3.6+ (या शामिल Maven wrapper का उपयोग करें)
- GitHub Models तक पहुंच वाला GitHub खाता
- `http://localhost:8080` पर चल रही MCP कैलकुलेटर सेवा

## GitHub टोकन प्राप्त करना

यह एप्लिकेशन GitHub Models का उपयोग करता है, जिसके लिए GitHub पर्सनल एक्सेस टोकन आवश्यक है। अपना टोकन पाने के लिए निम्न चरणों का पालन करें:

### 1. GitHub Models तक पहुँचें
1. [GitHub Models](https://github.com/marketplace/models) पर जाएं
2. अपने GitHub खाते से साइन इन करें
3. यदि आपने पहले से एक्सेस नहीं लिया है तो GitHub Models के लिए अनुरोध करें

### 2. पर्सनल एक्सेस टोकन बनाएं
1. [GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens) पर जाएं
2. "Generate new token" → "Generate new token (classic)" पर क्लिक करें
3. अपने टोकन को एक वर्णनात्मक नाम दें (जैसे, "MCP Calculator Client")
4. आवश्यकतानुसार एक्सपायरी सेट करें
5. निम्न स्कोप चुनें:
   - `repo` (यदि प्राइवेट रिपॉजिटरी एक्सेस करनी हो)
   - `user:email`
6. "Generate token" पर क्लिक करें
7. **महत्वपूर्ण**: टोकन को तुरंत कॉपी करें - बाद में आप इसे नहीं देख पाएंगे!

### 3. पर्यावरण चर सेट करें

#### Windows (Command Prompt) पर:
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### Windows (PowerShell) पर:
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### macOS/Linux पर:
```bash
export GITHUB_TOKEN=your_github_token_here
```

## सेटअप और इंस्टॉलेशन

1. **प्रोजेक्ट डायरेक्टरी क्लोन या नेविगेट करें**

2. **डिपेंडेंसी इंस्टॉल करें**:
   ```cmd
   mvnw clean install
   ```
   या यदि आपके पास Maven ग्लोबली इंस्टॉल है:
   ```cmd
   mvn clean install
   ```

3. **पर्यावरण चर सेट करें** (ऊपर "GitHub टोकन प्राप्त करना" सेक्शन देखें)

4. **MCP कैलकुलेटर सेवा शुरू करें**:
   सुनिश्चित करें कि आपने चैप्टर 1 की MCP कैलकुलेटर सेवा `http://localhost:8080/sse` पर चल रही है। क्लाइंट शुरू करने से पहले यह सेवा चालू होनी चाहिए।

## एप्लिकेशन चलाना

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## एप्लिकेशन क्या करता है

यह एप्लिकेशन कैलकुलेटर सेवा के साथ तीन मुख्य इंटरैक्शन दिखाता है:

1. **जोड़**: 24.5 और 17.3 का योग निकालता है
2. **वर्गमूल**: 144 का वर्गमूल निकालता है
3. **सहायता**: उपलब्ध कैलकुलेटर फंक्शंस दिखाता है

## अपेक्षित आउटपुट

सफलतापूर्वक चलने पर, आपको कुछ इस तरह का आउटपुट दिखेगा:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## समस्या निवारण

### सामान्य समस्याएँ

1. **"GITHUB_TOKEN environment variable not set"**
   - सुनिश्चित करें कि आपने `GITHUB_TOKEN` environment variable
   - Restart your terminal/command prompt after setting the variable

2. **"Connection refused to localhost:8080"**
   - Ensure the MCP calculator service is running on port 8080
   - Check if another service is using port 8080

3. **"Authentication failed"**
   - Verify your GitHub token is valid and has the correct permissions
   - Check if you have access to GitHub Models

4. **Maven build errors**
   - Ensure you're using Java 21 or higher: `java -version`
   - Try cleaning the build: `mvnw clean` सेट किया है

### डिबगिंग

डिबग लॉगिंग सक्षम करने के लिए, एप्लिकेशन चलाते समय निम्न JVM आर्गुमेंट जोड़ें:
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## कॉन्फ़िगरेशन

एप्लिकेशन कॉन्फ़िगर किया गया है:
- GitHub Models का उपयोग `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse` के साथ
- अनुरोधों के लिए 60 सेकंड का टाइमआउट
- डिबगिंग के लिए अनुरोध/प्रतिक्रिया लॉगिंग सक्षम

## डिपेंडेंसीज़

इस प्रोजेक्ट में उपयोग की गई मुख्य डिपेंडेंसीज़:
- **LangChain4j**: AI इंटीग्रेशन और टूल मैनेजमेंट के लिए
- **LangChain4j MCP**: Model Context Protocol सपोर्ट के लिए
- **LangChain4j GitHub Models**: GitHub Models इंटीग्रेशन के लिए
- **Spring Boot**: एप्लिकेशन फ्रेमवर्क और डिपेंडेंसी इंजेक्शन के लिए

## लाइसेंस

यह प्रोजेक्ट Apache License 2.0 के तहत लाइसेंस प्राप्त है - विवरण के लिए [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) फ़ाइल देखें।

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या असंगतियाँ हो सकती हैं। मूल दस्तावेज़ को उसकी मूल भाषा में प्रामाणिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सिफारिश की जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।