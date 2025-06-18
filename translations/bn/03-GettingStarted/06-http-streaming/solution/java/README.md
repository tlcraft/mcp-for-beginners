<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:45:20+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "bn"
}
-->
# Calculator HTTP Streaming Demo

এই প্রকল্পটি Server-Sent Events (SSE) ব্যবহার করে HTTP স্ট্রিমিং প্রদর্শন করে Spring Boot WebFlux এর মাধ্যমে। এতে দুটি অ্যাপ্লিকেশন রয়েছে:

- **Calculator Server**: একটি রিঅ্যাকটিভ ওয়েব সার্ভিস যা গণনা সম্পাদন করে এবং SSE ব্যবহার করে ফলাফল স্ট্রিম করে
- **Calculator Client**: একটি ক্লায়েন্ট অ্যাপ্লিকেশন যা স্ট্রিমিং এন্ডপয়েন্ট ব্যবহার করে

## Prerequisites

- Java 17 বা তার উপরে
- Maven 3.6 বা তার উপরে

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

## How It Works

1. **Calculator Server** `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5` এন্ডপয়েন্ট প্রকাশ করে
   - স্ট্রিমিং রেসপন্স গ্রহণ করে
   - প্রতিটি ইভেন্ট কনসোলে প্রিন্ট করে

## Running the Applications

### Option 1: Using Maven (Recommended)

#### 1. Calculator Server চালু করুন

একটি টার্মিনাল খুলে সার্ভার ডিরেক্টরিতে যান:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

সার্ভার চালু হবে `http://localhost:8080` এ

আপনি নিচের মত আউটপুট দেখতে পাবেন:
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. Calculator Client চালান

একটি **নতুন টার্মিনাল** খুলে ক্লায়েন্ট ডিরেক্টরিতে যান:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

ক্লায়েন্ট সার্ভারের সাথে সংযোগ করবে, গণনা সম্পন্ন করবে, এবং স্ট্রিমিং ফলাফল প্রদর্শন করবে।

### Option 2: Using Java directly

#### 1. সার্ভার কম্পাইল এবং চালান:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. ক্লায়েন্ট কম্পাইল এবং চালান:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Testing the Server Manually

আপনি ব্রাউজার বা curl ব্যবহার করেও সার্ভার পরীক্ষা করতে পারেন:

### Using a web browser:
এটি ভিজিট করুন: `http://localhost:8080/calculate?a=10&b=5&op=add`

### Using curl:
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## Expected Output

ক্লায়েন্ট চালানোর সময় আপনি স্ট্রিমিং আউটপুট দেখতে পাবেন, যা এরকম হবে:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## Supported Operations

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
- গণনার অগ্রগতি এবং ফলাফল সহ Server-Sent Events রিটার্ন করে

**Example Request:**
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**Example Response:**
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## Troubleshooting

### Common Issues

1. **Port 8080 ইতিমধ্যে ব্যবহার হচ্ছে**
   - পোর্ট 8080 ব্যবহার করা অন্য কোনো অ্যাপ্লিকেশন বন্ধ করুন
   - অথবা `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop` এ সার্ভারের পোর্ট পরিবর্তন করুন যদি ব্যাকগ্রাউন্ড প্রসেস হিসেবে চলছে

## Technology Stack

- **Spring Boot 3.3.1** - অ্যাপ্লিকেশন ফ্রেমওয়ার্ক
- **Spring WebFlux** - রিঅ্যাকটিভ ওয়েব ফ্রেমওয়ার্ক
- **Project Reactor** - রিঅ্যাকটিভ স্ট্রিমস লাইব্রেরি
- **Netty** - নন-ব্লকিং I/O সার্ভার
- **Maven** - বিল্ড টুল
- **Java 17+** - প্রোগ্রামিং ভাষা

## Next Steps

কোড পরিবর্তন করে চেষ্টা করুন:
- আরও গণিত অপারেশন যোগ করুন
- ভুল অপারেশনের জন্য এরর হ্যান্ডলিং অন্তর্ভুক্ত করুন
- রিকোয়েস্ট/রেসপন্স লগিং যোগ করুন
- অথেনটিকেশন ইমপ্লিমেন্ট করুন
- ইউনিট টেস্ট যোগ করুন

**অস্বীকারোক্তি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে অনুগ্রহ করে জেনে রাখুন যে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার স্বাভাবিক ভাষায় সর্বোত্তম এবং কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ গ্রহণ করার পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারের ফলে যে কোনও ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।