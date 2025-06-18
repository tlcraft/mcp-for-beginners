<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:45:09+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "hi"
}
-->
# Calculator HTTP Streaming Demo

यह प्रोजेक्ट Server-Sent Events (SSE) का उपयोग करके Spring Boot WebFlux के साथ HTTP स्ट्रीमिंग दिखाता है। इसमें दो एप्लिकेशन शामिल हैं:

- **Calculator Server**: एक रिएक्टिव वेब सेवा जो कैलकुलेशन करती है और SSE के माध्यम से परिणाम स्ट्रीम करती है
- **Calculator Client**: एक क्लाइंट एप्लिकेशन जो स्ट्रीमिंग एंडपॉइंट का उपयोग करता है

## Prerequisites

- Java 17 या उससे ऊपर
- Maven 3.6 या उससे ऊपर

## Project Structure

```
java/
├── calculator-server/     # Spring Boot server with SSE endpoint
│   ├── src/main/java/com/example/calculatorserver/
│   │   ├── CalculatorServerApplication.java
│   │   └── CalculatorController.java
│   └── pom.xml
├── calculator-client/     # Spring Boot client application
│   ├── src/main/java/com/example/calculatorclient/
│   │   └── CalculatorClientApplication.java
│   └── pom.xml
└── README.md
```

## यह कैसे काम करता है

1. **Calculator Server** एक `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5` एंडपॉइंट प्रदान करता है
   - स्ट्रीमिंग प्रतिक्रिया को उपयोग करता है
   - प्रत्येक इवेंट को कंसोल पर प्रिंट करता है

## एप्लिकेशन चलाना

### विकल्प 1: Maven का उपयोग करके (सिफारिश की गई)

#### 1. Calculator Server शुरू करें

टर्मिनल खोलें और सर्वर डायरेक्टरी में जाएं:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

सर्वर `http://localhost:8080` पर शुरू हो जाएगा

आपको इस तरह का आउटपुट दिखाई देगा:
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. Calculator Client चलाएं

एक **नया टर्मिनल** खोलें और क्लाइंट डायरेक्टरी में जाएं:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

क्लाइंट सर्वर से कनेक्ट होगा, कैलकुलेशन करेगा, और स्ट्रीमिंग परिणाम दिखाएगा।

### विकल्प 2: सीधे Java का उपयोग करके

#### 1. सर्वर को कंपाइल और चलाएं:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. क्लाइंट को कंपाइल और चलाएं:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## सर्वर को मैन्युअली टेस्ट करना

आप वेब ब्राउज़र या curl का उपयोग करके भी सर्वर का परीक्षण कर सकते हैं:

### वेब ब्राउज़र का उपयोग करते हुए:
यहाँ जाएं: `http://localhost:8080/calculate?a=10&b=5&op=add`

### curl का उपयोग करते हुए:
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## अपेक्षित आउटपुट

जब क्लाइंट चलाया जाता है, तो आपको स्ट्रीमिंग आउटपुट कुछ इस तरह दिखेगा:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## समर्थित ऑपरेशन

- `add` - Addition (a + b)
- `sub` - Subtraction (a - b)
- `mul` - Multiplication (a * b)
- `div` - Division (a / b, returns NaN if b = 0)

## API Reference

### GET /calculate

**Parameters:**
- `a` (required): First number (double)
- `b` (required): Second number (double)
- `op` (required): Operation (`add`, `sub`, `mul`, `div`)

**Response:**
- Content-Type: `text/event-stream`
- कैलकुलेशन प्रगति और परिणाम के साथ Server-Sent Events लौटाता है

**उदाहरण अनुरोध:**
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**उदाहरण प्रतिक्रिया:**
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## Troubleshooting

### सामान्य समस्याएँ

1. **पोर्ट 8080 पहले से उपयोग में है**
   - पोर्ट 8080 का उपयोग कर रहे किसी अन्य एप्लिकेशन को बंद करें
   - या `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop` में सर्वर पोर्ट बदलें यदि बैकग्राउंड प्रक्रिया के रूप में चला रहे हैं

## Technology Stack

- **Spring Boot 3.3.1** - एप्लिकेशन फ्रेमवर्क
- **Spring WebFlux** - रिएक्टिव वेब फ्रेमवर्क
- **Project Reactor** - रिएक्टिव स्ट्रीम लाइब्रेरी
- **Netty** - नॉन-ब्लॉकिंग I/O सर्वर
- **Maven** - बिल्ड टूल
- **Java 17+** - प्रोग्रामिंग भाषा

## अगले कदम

कोड को इस तरह बदलने की कोशिश करें:
- और गणितीय ऑपरेशन जोड़ें
- अमान्य ऑपरेशनों के लिए त्रुटि हैंडलिंग शामिल करें
- अनुरोध/प्रतिक्रिया लॉगिंग जोड़ें
- प्रमाणीकरण लागू करें
- यूनिट टेस्ट जोड़ें

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। हम सटीकता के लिए प्रयासरत हैं, लेकिन कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या असंगतियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में अधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।