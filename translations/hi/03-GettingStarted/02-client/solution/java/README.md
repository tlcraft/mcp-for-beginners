<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7074b9f4c8cd147c1c10f569d8508c82",
  "translation_date": "2025-06-11T13:07:38+00:00",
  "source_file": "03-GettingStarted/02-client/solution/java/README.md",
  "language_code": "hi"
}
-->
# MCP Java Client - Calculator Demo

यह प्रोजेक्ट दिखाता है कि कैसे एक Java क्लाइंट बनाया जाए जो MCP (Model Context Protocol) सर्वर से कनेक्ट होकर इंटरैक्ट करता है। इस उदाहरण में, हम चैप्टर 01 के कैलकुलेटर सर्वर से कनेक्ट करेंगे और विभिन्न गणितीय ऑपरेशन करेंगे।

## Prerequisites

इस क्लाइंट को चलाने से पहले, आपको:

1. **चैप्टर 01 से Calculator Server शुरू करें**:
   - कैलकुलेटर सर्वर डायरेक्टरी में जाएं: `03-GettingStarted/01-first-server/solution/java/`
   - कैलकुलेटर सर्वर को बिल्ड और रन करें:
     ```cmd
     cd ..\01-first-server\solution\java
     .\mvnw clean install -DskipTests
     java -jar target\calculator-server-0.0.1-SNAPSHOT.jar
     ```
   - सर्वर `http://localhost:8080`

2. **Java 21 or higher** installed on your system
3. **Maven** (included via Maven Wrapper)

## What is the SDKClient?

The `` पर चलना चाहिए

`SDKClient` एक Java एप्लिकेशन है जो दिखाता है कि कैसे:
- Server-Sent Events (SSE) ट्रांसपोर्ट का उपयोग करके MCP सर्वर से कनेक्ट करें
- सर्वर से उपलब्ध टूल्स की सूची प्राप्त करें
- विभिन्न कैलकुलेटर फंक्शंस को रिमोटली कॉल करें
- प्रतिक्रियाओं को हैंडल करें और परिणाम दिखाएं

## यह कैसे काम करता है

क्लाइंट Spring AI MCP फ्रेमवर्क का उपयोग करता है ताकि:

1. **कनेक्शन स्थापित करें**: कैलकुलेटर सर्वर से कनेक्ट करने के लिए WebFlux SSE क्लाइंट ट्रांसपोर्ट बनाता है
2. **क्लाइंट इनिशियलाइज़ करें**: MCP क्लाइंट सेटअप और कनेक्शन स्थापित करें
3. **टूल्स खोजें**: सभी उपलब्ध कैलकुलेटर ऑपरेशंस की सूची प्राप्त करें
4. **ऑपरेशंस चलाएं**: नमूना डेटा के साथ विभिन्न गणितीय फंक्शंस कॉल करें
5. **परिणाम दिखाएं**: प्रत्येक कैलकुलेशन के परिणाम दिखाएं

## प्रोजेक्ट संरचना

```
src/
└── main/
    └── java/
        └── com/
            └── microsoft/
                └── mcp/
                    └── sample/
                        └── client/
                            └── SDKClient.java    # Main client implementation
```

## मुख्य डिपेंडेंसियाँ

प्रोजेक्ट निम्नलिखित मुख्य डिपेंडेंसियों का उपयोग करता है:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

यह डिपेंडेंसी प्रदान करता है:
- `McpClient` - The main client interface
- `WebFluxSseClientTransport` - वेब आधारित संचार के लिए SSE ट्रांसपोर्ट
- MCP प्रोटोकॉल स्कीमास और रिक्वेस्ट/रिस्पॉन्स टाइप्स

## प्रोजेक्ट बिल्ड करना

Maven रैपर का उपयोग करके प्रोजेक्ट बिल्ड करें:

```cmd
.\mvnw clean install
```

## क्लाइंट चलाना

```cmd
java -jar .\target\calculator-client-0.0.1-SNAPSHOT.jar
```

**Note**: सुनिश्चित करें कि कैलकुलेटर सर्वर `http://localhost:8080` before executing any of these commands.

## What the Client Does

When you run the client, it will:

1. **Connect** to the calculator server at `http://localhost:8080` पर चल रहा हो

2. **टूल्स की सूची देखें** - सभी उपलब्ध कैलकुलेटर ऑपरेशंस दिखाएं  
3. **गणनाएँ करें**:  
   - जोड़: 5 + 3 = 8  
   - घटाव: 10 - 4 = 6  
   - गुणा: 6 × 7 = 42  
   - भाग: 20 ÷ 4 = 5  
   - घातांक: 2^8 = 256  
   - वर्गमूल: √16 = 4  
   - पूर्णांक मान: |-5.5| = 5.5  
   - मदद: उपलब्ध ऑपरेशंस दिखाएं

## अपेक्षित आउटपुट

```
Available Tools = ListToolsResult[tools=[Tool[name=add, description=Add two numbers together, ...], ...]]
Add Result = CallToolResult[content=[TextContent[text="5,00 + 3,00 = 8,00"]], isError=false]
Subtract Result = CallToolResult[content=[TextContent[text="10,00 - 4,00 = 6,00"]], isError=false]
Multiply Result = CallToolResult[content=[TextContent[text="6,00 * 7,00 = 42,00"]], isError=false]
Divide Result = CallToolResult[content=[TextContent[text="20,00 / 4,00 = 5,00"]], isError=false]
Power Result = CallToolResult[content=[TextContent[text="2,00 ^ 8,00 = 256,00"]], isError=false]
Square Root Result = CallToolResult[content=[TextContent[text="√16,00 = 4,00"]], isError=false]
Absolute Result = CallToolResult[content=[TextContent[text="|-5,50| = 5,50"]], isError=false]
Help = CallToolResult[content=[TextContent[text="Basic Calculator MCP Service\n\nAvailable operations:\n1. add(a, b) - Adds two numbers\n2. subtract(a, b) - Subtracts the second number from the first\n..."]], isError=false]
```

**Note**: आपको Maven की चेतावनियाँ मिल सकती हैं जो लम्बे समय तक चलने वाले थ्रेड्स के बारे में हों - यह reactive एप्लिकेशन के लिए सामान्य है और किसी त्रुटि का संकेत नहीं है।

## कोड समझना

### 1. ट्रांसपोर्ट सेटअप
```java
var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
```  
यह एक SSE (Server-Sent Events) ट्रांसपोर्ट बनाता है जो कैलकुलेटर सर्वर से कनेक्ट होता है।

### 2. क्लाइंट बनाना
```java
var client = McpClient.sync(this.transport).build();
client.initialize();
```  
एक synchronous MCP क्लाइंट बनाता है और कनेक्शन इनिशियलाइज़ करता है।

### 3. टूल्स कॉल करना
```java
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
```  
"add" टूल को पैरामीटर a=5.0 और b=3.0 के साथ कॉल करता है।

## समस्या निवारण

### सर्वर चल नहीं रहा
यदि कनेक्शन त्रुटि हो रही है, तो सुनिश्चित करें कि चैप्टर 01 का कैलकुलेटर सर्वर चल रहा हो:  
```
Error: Connection refused
```  
**समाधान**: पहले कैलकुलेटर सर्वर शुरू करें।

### पोर्ट पहले से उपयोग में है
यदि पोर्ट 8080 व्यस्त है:  
```
Error: Address already in use
```  
**समाधान**: पोर्ट 8080 का उपयोग कर रहे अन्य एप्लिकेशन बंद करें या सर्वर को अलग पोर्ट पर सेट करें।

### बिल्ड त्रुटियाँ
यदि बिल्ड त्रुटियाँ आ रही हैं:  
```cmd
.\mvnw clean install -DskipTests
```

## और जानें

- [Spring AI MCP Documentation](https://docs.spring.io/spring-ai/reference/api/mcp/)
- [Model Context Protocol Specification](https://modelcontextprotocol.io/)
- [Spring WebFlux Documentation](https://docs.spring.io/spring-framework/docs/current/reference/html/web-reactive.html)

**अस्वीकरण**:  
इस दस्तावेज़ का अनुवाद AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या असंगतियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में ही अधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम उत्तरदायी नहीं हैं।