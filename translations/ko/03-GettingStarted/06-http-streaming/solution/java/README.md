<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:44:59+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "ko"
}
-->
# Calculator HTTP Streaming Demo

이 프로젝트는 Spring Boot WebFlux를 사용하여 Server-Sent Events(SSE) 기반의 HTTP 스트리밍을 시연합니다. 두 개의 애플리케이션으로 구성되어 있습니다:

- **Calculator Server**: 계산을 수행하고 SSE를 통해 결과를 스트리밍하는 리액티브 웹 서비스
- **Calculator Client**: 스트리밍 엔드포인트를 소비하는 클라이언트 애플리케이션

## 사전 준비 사항

- Java 17 이상
- Maven 3.6 이상

## 프로젝트 구조

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

## 동작 방식

1. **Calculator Server**가 `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5` 엔드포인트를 제공합니다.
   - 스트리밍 응답을 소비합니다.
   - 각 이벤트를 콘솔에 출력합니다.

## 애플리케이션 실행 방법

### 옵션 1: Maven 사용 (권장)

#### 1. Calculator Server 시작하기

터미널을 열고 서버 디렉터리로 이동하세요:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

서버는 `http://localhost:8080`에서 시작됩니다.

다음과 같은 출력이 표시됩니다:
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. Calculator Client 실행하기

**새 터미널**을 열고 클라이언트 디렉터리로 이동하세요:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

클라이언트가 서버에 연결하여 계산을 수행하고 스트리밍 결과를 표시합니다.

### 옵션 2: Java 직접 실행

#### 1. 서버 컴파일 및 실행:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. 클라이언트 컴파일 및 실행:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## 서버 수동 테스트

웹 브라우저나 curl을 사용하여 서버를 테스트할 수도 있습니다:

### 웹 브라우저 사용:
`http://localhost:8080/calculate?a=10&b=5&op=add` 방문

### curl 사용:
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## 예상 출력

클라이언트를 실행하면 다음과 유사한 스트리밍 출력이 나타납니다:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## 지원하는 연산

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
- 계산 진행 상황과 결과를 Server-Sent Events로 반환

**예시 요청:**
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**예시 응답:**
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## 문제 해결

### 자주 발생하는 문제

1. **포트 8080이 이미 사용 중인 경우**
   - 포트 8080을 사용하는 다른 애플리케이션을 종료하세요.
   - 또는 `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop` 명령어로 백그라운드 프로세스를 중지하거나 서버 포트를 변경하세요.

## 기술 스택

- **Spring Boot 3.3.1** - 애플리케이션 프레임워크
- **Spring WebFlux** - 리액티브 웹 프레임워크
- **Project Reactor** - 리액티브 스트림 라이브러리
- **Netty** - 논블로킹 I/O 서버
- **Maven** - 빌드 도구
- **Java 17+** - 프로그래밍 언어

## 다음 단계

코드를 수정해보세요:
- 더 많은 수학 연산 추가
- 잘못된 연산에 대한 에러 처리 포함
- 요청/응답 로깅 추가
- 인증 기능 구현
- 단위 테스트 추가

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 노력하고 있으나, 자동 번역에는 오류나 부정확한 부분이 있을 수 있음을 유의해 주시기 바랍니다. 원문은 해당 언어의 원본 문서가 권위 있는 자료로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역의 사용으로 인한 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.