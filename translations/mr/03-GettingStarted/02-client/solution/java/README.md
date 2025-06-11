<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7074b9f4c8cd147c1c10f569d8508c82",
  "translation_date": "2025-06-11T13:08:31+00:00",
  "source_file": "03-GettingStarted/02-client/solution/java/README.md",
  "language_code": "mr"
}
-->
# MCP Java Client - Calculator Demo

हा प्रोजेक्ट कसा Java क्लायंट तयार करायचा जो MCP (Model Context Protocol) सर्व्हरशी कनेक्ट होतो आणि त्याच्याशी संवाद साधतो हे दाखवतो. या उदाहरणात, आपण Chapter 01 मधील कॅल्क्युलेटर सर्व्हरशी कनेक्ट होऊन विविध गणिती ऑपरेशन्स पार पाडणार आहोत.

## Prerequisites

हा क्लायंट चालवण्यापूर्वी, तुम्हाला हे करणे आवश्यक आहे:

1. **Chapter 01 मधील Calculator Server सुरू करा**:
   - कॅल्क्युलेटर सर्व्हर डायरेक्टरीकडे जा: `03-GettingStarted/01-first-server/solution/java/`
   - कॅल्क्युलेटर सर्व्हर बिल्ड आणि रन करा:
     ```cmd
     cd ..\01-first-server\solution\java
     .\mvnw clean install -DskipTests
     java -jar target\calculator-server-0.0.1-SNAPSHOT.jar
     ```
   - सर्व्हर `http://localhost:8080` वर चालू असावा

`SDKClient` हा Java अॅप्लिकेशन आहे जो दाखवतो कसे:
- Server-Sent Events (SSE) ट्रान्सपोर्ट वापरून MCP सर्व्हरशी कनेक्ट करायचे
- सर्व्हरवरील उपलब्ध टूल्सची यादी कशी करायची
- विविध कॅल्क्युलेटर फंक्शन्स रिमोटली कॉल करायचे
- प्रतिसाद हाताळून निकाल दाखवायचे

## How It Works

हा क्लायंट Spring AI MCP फ्रेमवर्क वापरतो जेणेकरून:

1. **कनेक्शन स्थापित करणे**: कॅल्क्युलेटर सर्व्हरशी कनेक्ट होण्यासाठी WebFlux SSE क्लायंट ट्रान्सपोर्ट तयार करतो
2. **क्लायंट इनिशियलाइझ करणे**: MCP क्लायंट सेटअप करतो आणि कनेक्शन स्थापन करतो
3. **टूल्स शोधणे**: सर्व उपलब्ध कॅल्क्युलेटर ऑपरेशन्सची यादी करतो
4. **ऑपरेशन्स चालवणे**: नमुना डेटा वापरून विविध गणिती फंक्शन्स कॉल करतो
5. **निकाल दाखवणे**: प्रत्येक कॅल्क्युलेशनचा निकाल दाखवतो

## Project Structure

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

## Key Dependencies

प्रोजेक्टमध्ये खालील मुख्य dependencies वापरल्या आहेत:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

ही dependency प्रदान करते:
- `McpClient` - The main client interface
- `WebFluxSseClientTransport` - वेब-आधारित कम्युनिकेशनसाठी SSE ट्रान्सपोर्ट
- MCP प्रोटोकॉलचे schemas आणि request/response प्रकार

## Building the Project

Maven wrapper वापरून प्रोजेक्ट बिल्ड करा:

```cmd
.\mvnw clean install
```

## Running the Client

```cmd
java -jar .\target\calculator-client-0.0.1-SNAPSHOT.jar
```

**Note**: खात्री करा की कॅल्क्युलेटर सर्व्हर `http://localhost:8080` वर चालू आहे

2. **टूल्सची यादी करा** - सर्व उपलब्ध कॅल्क्युलेटर ऑपरेशन्स दाखवा  
3. **गणिती ऑपरेशन्स करा**:
   - बेरीज: 5 + 3 = 8
   - वजाबाकी: 10 - 4 = 6
   - गुणाकार: 6 × 7 = 42
   - भागाकार: 20 ÷ 4 = 5
   - घातांक: 2^8 = 256
   - वर्गमुळ: √16 = 4
   - पूर्णांक मूल्य: |-5.5| = 5.5
   - मदत: उपलब्ध ऑपरेशन्स दाखवा

## Expected Output

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

**Note**: शेवटी Maven कधीकधी lingering threads बद्दल चेतावणी देऊ शकतो - हे reactive applications मध्ये सामान्य आहे आणि त्रुटी नाही.

## Understanding the Code

### 1. Transport Setup
```java
var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
```  
हे SSE (Server-Sent Events) ट्रान्सपोर्ट तयार करते जे कॅल्क्युलेटर सर्व्हरशी कनेक्ट होते.

### 2. Client Creation
```java
var client = McpClient.sync(this.transport).build();
client.initialize();
```  
सिंक्रोनस MCP क्लायंट तयार करतो आणि कनेक्शन इनिशियलाइझ करतो.

### 3. Calling Tools
```java
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
```  
"add" टूल कॉल करतो ज्यात a=5.0 आणि b=3.0 हे पॅरामीटर्स दिले आहेत.

## Troubleshooting

### Server Not Running  
जर कनेक्शन एरर आले तर खात्री करा की Chapter 01 मधील कॅल्क्युलेटर सर्व्हर चालू आहे:  
```
Error: Connection refused
```  
**Solution**: कॅल्क्युलेटर सर्व्हर प्रथम सुरू करा.

### Port Already in Use  
जर पोर्ट 8080 आधीच वापरात असेल:  
```
Error: Address already in use
```  
**Solution**: पोर्ट 8080 वापरत असलेले इतर अॅप्लिकेशन्स थांबवा किंवा सर्व्हर वेगळा पोर्ट वापरण्यासाठी सेट करा.

### Build Errors  
जर बिल्ड एरर आले:  
```cmd
.\mvnw clean install -DskipTests
```

## Learn More

- [Spring AI MCP Documentation](https://docs.spring.io/spring-ai/reference/api/mcp/)
- [Model Context Protocol Specification](https://modelcontextprotocol.io/)
- [Spring WebFlux Documentation](https://docs.spring.io/spring-framework/docs/current/reference/html/web-reactive.html)

**अस्वीकरण**:  
हा दस्तऐवज AI भाषांतर सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून भाषांतरित केला आहे. आम्ही अचूकतेसाठी प्रयत्न करतो, परंतु कृपया लक्षात ठेवा की स्वयंचलित भाषांतरांमध्ये चुका किंवा अचूकतेत त्रुटी असू शकतात. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीकरिता व्यावसायिक मानवी भाषांतर शिफारसीय आहे. या भाषांतराच्या वापरामुळे उद्भवणाऱ्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थव्यवस्थेसाठी आम्ही जबाबदार नाही.