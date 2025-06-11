<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7074b9f4c8cd147c1c10f569d8508c82",
  "translation_date": "2025-06-11T13:08:48+00:00",
  "source_file": "03-GettingStarted/02-client/solution/java/README.md",
  "language_code": "ne"
}
-->
# MCP Java Client - क्यालकुलेटर डेमो

यो प्रोजेक्टले Java क्लाइन्ट कसरी बनाउने र MCP (Model Context Protocol) सर्भरसँग कसरी जडान हुने र अन्तरक्रिया गर्ने देखाउँछ। यस उदाहरणमा, हामीले अध्याय ०१ को क्यालकुलेटर सर्भरसँग जडान भएर विभिन्न गणितीय अपरेसनहरू गर्नेछौं।

## आवश्यकताहरू

यस क्लाइन्ट चलाउनु अघि, तपाईंले गर्नु पर्ने छ:

1. **अध्याय ०१ बाट क्यालकुलेटर सर्भर सुरु गर्नुहोस्**:
   - क्यालकुलेटर सर्भर डाइरेक्टरीमा जानुहोस्: `03-GettingStarted/01-first-server/solution/java/`
   - क्यालकुलेटर सर्भर बनाउनुहोस् र चलाउनुहोस्:
     ```cmd
     cd ..\01-first-server\solution\java
     .\mvnw clean install -DskipTests
     java -jar target\calculator-server-0.0.1-SNAPSHOT.jar
     ```
   - सर्भर `http://localhost:8080` मा चलिरहेको हुनुपर्छ।

`SDKClient` एक Java एप्लिकेशन हो जुन देखाउँछ कि कसरी:
- Server-Sent Events (SSE) ट्रान्सपोर्ट प्रयोग गरी MCP सर्भरसँग जडान गर्ने
- सर्भरबाट उपलब्ध उपकरणहरूको सूची प्राप्त गर्ने
- विभिन्न क्यालकुलेटर फंक्शनहरू रिमोटली कल गर्ने
- प्रतिक्रिया ह्यान्डल गरी नतिजा देखाउने

## यसले कसरी काम गर्छ

क्लाइन्टले Spring AI MCP फ्रेमवर्क प्रयोग गर्छ जसले:

1. **जडान स्थापना**: क्यालकुलेटर सर्भरसँग जडान गर्न WebFlux SSE क्लाइन्ट ट्रान्सपोर्ट बनाउँछ
2. **क्लाइन्ट सुरु**: MCP क्लाइन्ट सेटअप गरी जडान स्थापना गर्छ
3. **उपकरणहरू पत्ता लगाउने**: उपलब्ध सबै क्यालकुलेटर अपरेसनहरूको सूची देखाउँछ
4. **अपरेसनहरू चलाउने**: नमुना डाटासँग विभिन्न गणितीय फंक्शनहरू कल गर्छ
5. **नतिजा देखाउने**: हरेक गणनाको नतिजा प्रदर्शन गर्छ

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

## मुख्य निर्भरता

प्रोजेक्टले तलका मुख्य निर्भरता प्रयोग गर्छ:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

यस निर्भरता मार्फत उपलब्ध छ:
- `McpClient` - The main client interface
- `WebFluxSseClientTransport` - वेब-आधारित सञ्चारको लागि SSE ट्रान्सपोर्ट
- MCP प्रोटोकल स्किमाहरू र अनुरोध/प्रतिक्रिया प्रकारहरू

## प्रोजेक्ट बनाउने तरिका

Maven wrapper प्रयोग गरेर प्रोजेक्ट बनाउनुहोस्:

```cmd
.\mvnw clean install
```

## क्लाइन्ट चलाउने तरिका

```cmd
java -jar .\target\calculator-client-0.0.1-SNAPSHOT.jar
```

**Note**: क्यालकुलेटर सर्भर `http://localhost:8080` मा चलिरहेको छ भनी सुनिश्चित गर्नुहोस्।

2. **उपकरणहरू सूचीबद्ध गर्नुहोस्** - उपलब्ध सबै क्यालकुलेटर अपरेसनहरू देखाउँछ
3. **गणना गर्नुहोस्**:
   - जोड: 5 + 3 = 8
   - घटाउने: 10 - 4 = 6
   - गुणा: 6 × 7 = 42
   - भाग: 20 ÷ 4 = 5
   - घात: 2^8 = 256
   - वर्गमूल: √16 = 4
   - पूर्णांक मान: |-5.5| = 5.5
   - मद्दत: उपलब्ध अपरेसनहरू देखाउँछ

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

**Note**: अन्त्यमा Maven ले केही थ्रेडहरू बाँकी रहेको चेतावनी देखाउन सक्छ - यो प्रतिक्रिया प्रणालीका लागि सामान्य हो र त्रुटि होइन।

## कोड बुझ्न

### १. ट्रान्सपोर्ट सेटअप
```java
var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
```
यसले क्यालकुलेटर सर्भरसँग जडान गर्न SSE (Server-Sent Events) ट्रान्सपोर्ट बनाउँछ।

### २. क्लाइन्ट सिर्जना
```java
var client = McpClient.sync(this.transport).build();
client.initialize();
```
सिंक्रोनस MCP क्लाइन्ट बनाउँछ र जडान सुरु गर्छ।

### ३. उपकरणहरू कल गर्ने
```java
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
```
"add" उपकरणलाई a=5.0 र b=3.0 प्यारामिटरहरूसँग कल गर्छ।

## समस्या समाधान

### सर्भर चलिरहेको छैन
यदि जडानमा समस्या आए, अध्याय ०१ को क्यालकुलेटर सर्भर चलिरहेको छ भनी सुनिश्चित गर्नुहोस्:
```
Error: Connection refused
```
**Solution**: पहिले क्यालकुलेटर सर्भर सुरु गर्नुहोस्।

### पोर्ट पहिले नै प्रयोगमा छ
यदि पोर्ट 8080 प्रयोगमा छ भने:
```
Error: Address already in use
```
**Solution**: पोर्ट 8080 प्रयोग गरिरहेका अन्य एप्लिकेशनहरू बन्द गर्नुहोस् वा सर्भरलाई अर्को पोर्टमा चलाउनुहोस्।

### निर्माण त्रुटिहरू
यदि निर्माणमा समस्या आयो भने:
```cmd
.\mvnw clean install -DskipTests
```

## थप जान्न

- [Spring AI MCP Documentation](https://docs.spring.io/spring-ai/reference/api/mcp/)
- [Model Context Protocol Specification](https://modelcontextprotocol.io/)
- [Spring WebFlux Documentation](https://docs.spring.io/spring-framework/docs/current/reference/html/web-reactive.html)

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताको प्रयास गर्छौं, तर कृपया जान्नुहोस् कि स्वचालित अनुवादमा त्रुटिहरू वा अशुद्धताहरू हुनसक्छन्। मूल दस्तावेजलाई यसको मूल भाषामा आधिकारिक स्रोतको रूपमा मानिनु पर्छ। महत्वपूर्ण जानकारीको लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।