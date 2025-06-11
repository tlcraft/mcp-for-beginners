<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ed9cab32cc67c12d8969b407aa47100a",
  "translation_date": "2025-06-11T09:30:57+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/java/README.md",
  "language_code": "mr"
}
-->
# Basic Calculator MCP सेवा

ही सेवा Model Context Protocol (MCP) वापरून Spring Boot सह WebFlux ट्रान्सपोर्टद्वारे बेसिक कॅल्क्युलेटर ऑपरेशन्स प्रदान करते. हे MCP अंमलबजावणी शिकणाऱ्या नवशिक्यांसाठी एक सोपा उदाहरण म्हणून डिझाइन केले आहे.

अधिक माहितीसाठी, [MCP Server Boot Starter](https://docs.spring.io/spring-ai/reference/api/mcp/mcp-server-boot-starter-docs.html) संदर्भ दस्तऐवज पहा.


## सेवा वापरणे

ही सेवा MCP प्रोटोकॉलद्वारे खालील API एंडपॉइंट्स एक्सपोज करते:

- `add(a, b)`: दोन संख्यांची बेरीज करा
- `subtract(a, b)`: पहिल्या संख्येतून दुसरी संख्या वजा करा
- `multiply(a, b)`: दोन संख्यांची गुणाकार करा
- `divide(a, b)`: पहिल्या संख्येला दुसऱ्या संख्येने भागा (शून्य तपासणीसह)
- `power(base, exponent)`: एका संख्येची शक्ती काढा
- `squareRoot(number)`: वर्गमूळ काढा (नकारात्मक संख्या तपासणीसह)
- `modulus(a, b)`: भागाकाराचा उरलेला भाग काढा
- `absolute(number)`: परिमाण काढा

## अवलंबित्वे

प्रकल्पासाठी खालील मुख्य अवलंबित्वे आवश्यक आहेत:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

## प्रकल्प बिल्ड करणे

Maven वापरून प्रकल्प बिल्ड करा:
```bash
./mvnw clean install -DskipTests
```

## सर्व्हर चालू करणे

### Java वापरून

```bash
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

### MCP Inspector वापरणे

MCP Inspector हा MCP सेवा वापरण्यास उपयुक्त टूल आहे. या कॅल्क्युलेटर सेवेसह ते वापरण्यासाठी:

1. **नवीन टर्मिनल विंडोमध्ये MCP Inspector इन्स्टॉल करा आणि चालू करा:**
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **वेब UI ला प्रवेश करा** - अॅपने दाखवलेली URL क्लिक करा (साधारणपणे http://localhost:6274)

3. **कनेक्शन कॉन्फिगर करा:**
   - ट्रान्सपोर्ट प्रकार "SSE" सेट करा
   - तुमच्या चालू सर्व्हरच्या SSE एंडपॉइंटसाठी URL सेट करा: `http://localhost:8080/sse`
   - "Connect" क्लिक करा

4. **टूल्स वापरा:**
   - उपलब्ध कॅल्क्युलेटर ऑपरेशन्स पाहण्यासाठी "List Tools" क्लिक करा
   - टूल निवडा आणि ऑपरेशन चालवण्यासाठी "Run Tool" क्लिक करा

![MCP Inspector Screenshot](../../../../../../translated_images/tool.40e180a7b0d0fe2067cf96435532b01f63f7f8619d6b0132355a04b426b669ac.mr.png)

**अस्वीकरण**:  
हा दस्तऐवज AI भाषांतर सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून भाषांतरित केला आहे. आम्ही अचूकतेसाठी प्रयत्न करतो, तरी कृपया लक्षात घ्या की स्वयंचलित भाषांतरांमध्ये चुका किंवा अचूकतेत त्रुटी असू शकतात. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला पाहिजे. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी भाषांतर करण्याचा सल्ला दिला जातो. या भाषांतराच्या वापरामुळे होणाऱ्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागी आम्ही जबाबदार नाही.