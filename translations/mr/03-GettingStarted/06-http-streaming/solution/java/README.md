<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:45:30+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "mr"
}
-->
# Calculator HTTP Streaming Demo

हा प्रोजेक्ट Spring Boot WebFlux वापरून Server-Sent Events (SSE) द्वारे HTTP स्ट्रीमिंग कसे होते हे दाखवतो. यात दोन अॅप्लिकेशन्स आहेत:

- **Calculator Server**: एक reactive वेब सेवा जी गणिते करते आणि SSE वापरून निकाल स्ट्रीम करते
- **Calculator Client**: एक क्लायंट अॅप्लिकेशन जे स्ट्रीमिंग एंडपॉइंट वापरते

## Prerequisites

- Java 17 किंवा त्यापेक्षा नवीन आवृत्ती
- Maven 3.6 किंवा त्यापेक्षा नवीन आवृत्ती

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

## काम कसे करते

1. **Calculator Server** हा `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5` या URL वर सेवा पुरवतो  
   - स्ट्रीमिंग प्रतिसाद घेतो  
   - प्रत्येक इव्हेंट कन्सोलवर छापतो  

## अॅप्लिकेशन्स कसे चालवायचे

### पर्याय 1: Maven वापरून (शिफारस केलेले)

#### 1. Calculator Server सुरू करा

टर्मिनल उघडा आणि server डिरेक्टरीमध्ये जा:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

सर्व्हर `http://localhost:8080` वर सुरू होईल

तुम्हाला अशा प्रकारचा आउटपुट दिसेल:  
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. Calculator Client चालवा

नवीन टर्मिनल उघडा आणि client डिरेक्टरीमध्ये जा:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

क्लायंट सर्व्हरशी कनेक्ट होईल, गणिते करेल आणि स्ट्रीमिंग निकाल दाखवेल.

### पर्याय 2: थेट Java वापरून

#### 1. सर्व्हर compile आणि run करा:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. क्लायंट compile आणि run करा:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## सर्व्हर मॅन्युअली टेस्ट करणे

तुम्ही वेब ब्राउझर किंवा curl वापरून देखील सर्व्हर तपासू शकता:

### वेब ब्राउझर वापरून:
यावर भेट द्या: `http://localhost:8080/calculate?a=10&b=5&op=add`

### curl वापरून:
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## अपेक्षित आउटपुट

क्लायंट चालवताना तुम्हाला खालील प्रमाणे स्ट्रीमिंग आउटपुट दिसेल:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## समर्थित ऑपरेशन्स

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
- गणित प्रगती आणि निकालासह Server-Sent Events परत करते

**उदाहरण विनंती:**  
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**उदाहरण प्रतिसाद:**  
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## समस्या निवारण

### सामान्य समस्या

1. **पोर्ट 8080 आधीच वापरात आहे**  
   - पोर्ट 8080 वापरत असलेली इतर अॅप्लिकेशन्स थांबवा  
   - किंवा `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop` मध्ये सर्व्हर पोर्ट बदला जर बॅकग्राउंड प्रोसेस म्हणून चालवत असाल  

## तंत्रज्ञान स्टॅक

- **Spring Boot 3.3.1** - अॅप्लिकेशन फ्रेमवर्क  
- **Spring WebFlux** - Reactive वेब फ्रेमवर्क  
- **Project Reactor** - Reactive streams लायब्ररी  
- **Netty** - Non-blocking I/O सर्व्हर  
- **Maven** - बिल्ड टूल  
- **Java 17+** - प्रोग्रामिंग भाषा  

## पुढील टप्पे

कोडमध्ये बदल करून प्रयत्न करा:  
- आणखी गणिती ऑपरेशन्स जोडा  
- चुकीच्या ऑपरेशन्ससाठी त्रुटी हाताळणी जोडा  
- विनंती/प्रतिसाद लॉगिंग जोडा  
- प्रमाणीकरण अंमलात आणा  
- युनिट टेस्टस जोडा

**अस्वीकरण**:  
हा दस्तऐवज AI भाषांतर सेवेमुळे [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून भाषांतरित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात ठेवा की स्वयंचलित भाषांतरांमध्ये चुका किंवा अचूकतेचा अभाव असू शकतो. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाची माहिती असल्यास, व्यावसायिक मानवी भाषांतराची शिफारस केली जाते. या भाषांतराच्या वापरामुळे उद्भवलेल्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थनिर्देशनासाठी आम्ही जबाबदार नाही.