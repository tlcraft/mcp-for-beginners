<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:48:30+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "vi"
}
-->
# Demo Streaming HTTP Máy Tính

Dự án này minh họa streaming HTTP sử dụng Server-Sent Events (SSE) với Spring Boot WebFlux. Nó bao gồm hai ứng dụng:

- **Calculator Server**: Dịch vụ web phản ứng thực hiện các phép tính và truyền kết quả bằng SSE
- **Calculator Client**: Ứng dụng client tiêu thụ endpoint streaming

## Yêu cầu

- Java 17 trở lên
- Maven 3.6 trở lên

## Cấu trúc Dự án

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

## Cách hoạt động

1. **Calculator Server** cung cấp endpoint `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5`
   - Tiêu thụ phản hồi streaming
   - In từng sự kiện ra console

## Chạy Ứng dụng

### Lựa chọn 1: Dùng Maven (Khuyến nghị)

#### 1. Khởi động Calculator Server

Mở terminal và điều hướng đến thư mục server:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

Server sẽ chạy tại `http://localhost:8080`

Bạn sẽ thấy đầu ra như sau:
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. Chạy Calculator Client

Mở **terminal mới** và điều hướng đến thư mục client:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

Client sẽ kết nối với server, thực hiện phép tính và hiển thị kết quả streaming.

### Lựa chọn 2: Chạy trực tiếp bằng Java

#### 1. Biên dịch và chạy server:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. Biên dịch và chạy client:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Kiểm tra Server Thủ công

Bạn cũng có thể kiểm tra server bằng trình duyệt hoặc curl:

### Dùng trình duyệt:
Truy cập: `http://localhost:8080/calculate?a=10&b=5&op=add`

### Dùng curl:
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## Kết quả mong đợi

Khi chạy client, bạn sẽ thấy kết quả streaming tương tự:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## Các phép toán hỗ trợ

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
- Trả về Server-Sent Events với tiến trình và kết quả tính toán

**Ví dụ Request:**
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**Ví dụ Response:**
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## Xử lý sự cố

### Vấn đề phổ biến

1. **Cổng 8080 đã được sử dụng**
   - Dừng các ứng dụng khác đang dùng cổng 8080
   - Hoặc thay đổi cổng server trong `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop` nếu chạy ở chế độ nền

## Công nghệ sử dụng

- **Spring Boot 3.3.1** - Framework ứng dụng
- **Spring WebFlux** - Framework web phản ứng
- **Project Reactor** - Thư viện reactive streams
- **Netty** - Server I/O không chặn
- **Maven** - Công cụ build
- **Java 17+** - Ngôn ngữ lập trình

## Bước tiếp theo

Thử sửa mã để:
- Thêm nhiều phép toán hơn
- Thêm xử lý lỗi cho các phép toán không hợp lệ
- Thêm ghi nhận log request/response
- Triển khai xác thực
- Thêm unit test

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ nguyên bản của nó nên được xem là nguồn chính xác và đáng tin cậy. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.