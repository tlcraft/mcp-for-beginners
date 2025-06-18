<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:45:54+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "pa"
}
-->
# Calculator HTTP Streaming Demo

ਇਹ ਪ੍ਰੋਜੈਕਟ Spring Boot WebFlux ਨਾਲ Server-Sent Events (SSE) ਦੀ ਵਰਤੋਂ ਕਰਕੇ HTTP ਸਟ੍ਰੀਮਿੰਗ ਨੂੰ ਦਰਸਾਉਂਦਾ ਹੈ। ਇਹ ਦੋ ਐਪਲੀਕੇਸ਼ਨਾਂ 'ਤੇ مشتمل ਹੈ:

- **Calculator Server**: ਇੱਕ ਰੀਐਕਟਿਵ ਵੈੱਬ ਸਰਵਿਸ ਜੋ ਗਣਨਾਵਾਂ ਕਰਦਾ ਹੈ ਅਤੇ SSE ਰਾਹੀਂ ਨਤੀਜੇ ਸਟ੍ਰੀਮ ਕਰਦਾ ਹੈ  
- **Calculator Client**: ਇੱਕ ਕਲਾਇੰਟ ਐਪਲੀਕੇਸ਼ਨ ਜੋ ਸਟ੍ਰੀਮਿੰਗ ਐਂਡਪੌਇੰਟ ਨੂੰ ਖਪਤ ਕਰਦਾ ਹੈ

## Prerequisites

- ਜਾਵਾ 17 ਜਾਂ ਉੱਪਰ  
- ਮਾਵਨ 3.6 ਜਾਂ ਉੱਪਰ  

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
   - Makes a request to calculate `7 * 5` ਐਂਡਪੌਇੰਟ ਨੂੰ ਐਕਸਪੋਜ਼ ਕਰਦਾ ਹੈ  
   - ਸਟ੍ਰੀਮਿੰਗ ਜਵਾਬ ਨੂੰ ਖਪਤ ਕਰਦਾ ਹੈ  
   - ਹਰ ਇਕ ਇਵੈਂਟ ਨੂੰ ਕੰਸੋਲ 'ਤੇ ਪ੍ਰਿੰਟ ਕਰਦਾ ਹੈ  

## Running the Applications

### Option 1: Using Maven (Recommended)

#### 1. Calculator Server ਚਾਲੂ ਕਰੋ

ਇੱਕ ਟਰਮੀਨਲ ਖੋਲ੍ਹੋ ਅਤੇ ਸਰਵਰ ਡਾਇਰੈਕਟਰੀ ਵਿੱਚ ਜਾਓ:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

ਸਰਵਰ `http://localhost:8080` 'ਤੇ ਚੱਲੇਗਾ

ਤੁਹਾਨੂੰ ਇਸ ਤਰ੍ਹਾਂ ਆਉਟਪੁੱਟ ਵੇਖਣ ਨੂੰ ਮਿਲੇਗਾ:  
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. Calculator Client ਚਲਾਓ

ਇੱਕ **ਨਵਾਂ ਟਰਮੀਨਲ** ਖੋਲ੍ਹੋ ਅਤੇ ਕਲਾਇੰਟ ਡਾਇਰੈਕਟਰੀ ਵਿੱਚ ਜਾਓ:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

ਕਲਾਇੰਟ ਸਰਵਰ ਨਾਲ ਜੁੜੇਗਾ, ਗਣਨਾ ਕਰੇਗਾ ਅਤੇ ਸਟ੍ਰੀਮਿੰਗ ਨਤੀਜੇ ਦਿਖਾਏਗਾ।

### Option 2: Using Java directly

#### 1. ਸਰਵਰ ਕਾਂਪਾਇਲ ਅਤੇ ਚਲਾਓ:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. ਕਲਾਇੰਟ ਕਾਂਪਾਇਲ ਅਤੇ ਚਲਾਓ:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Testing the Server Manually

ਤੁਸੀਂ ਸਰਵਰ ਨੂੰ ਵੈੱਬ ਬ੍ਰਾਊਜ਼ਰ ਜਾਂ curl ਦੀ ਵਰਤੋਂ ਨਾਲ ਵੀ ਟੈਸਟ ਕਰ ਸਕਦੇ ਹੋ:

### Using a web browser:  
ਵਿਜ਼ਿਟ ਕਰੋ: `http://localhost:8080/calculate?a=10&b=5&op=add`

### Using curl:  
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## Expected Output

ਜਦੋਂ ਕਲਾਇੰਟ ਚੱਲ ਰਿਹਾ ਹੋਵੇ, ਤੁਹਾਨੂੰ ਇਹੋ ਜਿਹਾ ਸਟ੍ਰੀਮਿੰਗ ਆਉਟਪੁੱਟ ਵੇਖਣ ਨੂੰ ਮਿਲੇਗਾ:  

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
- Server-Sent Events ਵਾਪਸ ਕਰਦਾ ਹੈ ਜਿਸ ਵਿੱਚ ਗਣਨਾ ਦੀ ਪ੍ਰਗਟਿ ਅਤੇ ਨਤੀਜਾ ਹੁੰਦਾ ਹੈ  

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

1. **Port 8080 ਪਹਿਲਾਂ ਹੀ ਵਰਤੀ ਜਾ ਰਹੀ ਹੈ**  
   - ਕੋਈ ਹੋਰ ਐਪਲੀਕੇਸ਼ਨ ਜੋ 8080 ਪੋਰਟ ਵਰਤ ਰਹੀ ਹੈ ਉਸਨੂੰ ਰੋਕੋ  
   - ਜਾਂ `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop` ਵਿੱਚ ਸਰਵਰ ਪੋਰਟ ਬਦਲੋ ਜੇਕਰ ਇਹ ਬੈਕਗ੍ਰਾਊਂਡ ਪ੍ਰਕਿਰਿਆ ਵਜੋਂ ਚੱਲ ਰਿਹਾ ਹੈ  

## Technology Stack

- **Spring Boot 3.3.1** - ਐਪਲੀਕੇਸ਼ਨ ਫਰੇਮਵਰਕ  
- **Spring WebFlux** - ਰੀਐਕਟਿਵ ਵੈੱਬ ਫਰੇਮਵਰਕ  
- **Project Reactor** - ਰੀਐਕਟਿਵ ਸਟ੍ਰੀਮਜ਼ ਲਾਇਬ੍ਰੇਰੀ  
- **Netty** - ਨਾਨ-ਬਲੌਕਿੰਗ I/O ਸਰਵਰ  
- **Maven** - ਬਿਲਡ ਟੂਲ  
- **Java 17+** - ਪ੍ਰੋਗ੍ਰਾਮਿੰਗ ਭਾਸ਼ਾ  

## Next Steps

ਕੋਡ ਵਿੱਚ ਇਹ ਬਦਲਾਅ ਕਰਨ ਦੀ ਕੋਸ਼ਿਸ਼ ਕਰੋ:  
- ਹੋਰ ਗਣਿਤੀ ਕਾਰਜ ਸ਼ਾਮਲ ਕਰੋ  
- ਗਲਤ ਕਾਰਜਾਂ ਲਈ ਏਰਰ ਹੈਂਡਲਿੰਗ ਸ਼ਾਮਲ ਕਰੋ  
- ਰਿਕਵੈਸਟ/ਰਿਸਪਾਂਸ ਲੌਗਿੰਗ ਜੋੜੋ  
- ਪ੍ਰਮਾਣਿਕਤਾ ਲਾਗੂ ਕਰੋ  
- ਯੂਨਿਟ ਟੈਸਟ ਸ਼ਾਮਲ ਕਰੋ

**ਅਸਵੀਕਾਰੋक्ति**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਅਤ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਜਾਣੋ ਕਿ ਸਵੈਚਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਮਰਥਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਅਧਿਕਾਰਤ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਨਾਲ ਪੈਦਾ ਹੋਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀਆਂ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆਵਾਂ ਲਈ ਅਸੀਂ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।