<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:30:32+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "vi"
}
-->
# Máy tính LLM Client

Một ứng dụng Java minh họa cách sử dụng LangChain4j để kết nối với dịch vụ máy tính MCP (Model Context Protocol) tích hợp GitHub Models.

## Yêu cầu trước

- Java 21 trở lên  
- Maven 3.6+ (hoặc sử dụng Maven wrapper đi kèm)  
- Tài khoản GitHub có quyền truy cập GitHub Models  
- Dịch vụ máy tính MCP đang chạy trên `http://localhost:8080`

## Lấy GitHub Token

Ứng dụng này sử dụng GitHub Models, cần một GitHub personal access token. Làm theo các bước sau để lấy token:

### 1. Truy cập GitHub Models
1. Vào [GitHub Models](https://github.com/marketplace/models)  
2. Đăng nhập bằng tài khoản GitHub của bạn  
3. Yêu cầu quyền truy cập GitHub Models nếu bạn chưa có

### 2. Tạo Personal Access Token
1. Vào [GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens)  
2. Nhấn "Generate new token" → "Generate new token (classic)"  
3. Đặt tên mô tả cho token (ví dụ: "MCP Calculator Client")  
4. Chọn thời hạn hết hạn nếu cần  
5. Chọn các phạm vi sau:  
   - `repo` (nếu truy cập kho riêng tư)  
   - `user:email`  
6. Nhấn "Generate token"  
7. **Quan trọng**: Sao chép token ngay lập tức - bạn sẽ không thể xem lại!

### 3. Thiết lập biến môi trường

#### Trên Windows (Command Prompt):  
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### Trên Windows (PowerShell):  
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### Trên macOS/Linux:  
```bash
export GITHUB_TOKEN=your_github_token_here
```

## Cài đặt và thiết lập

1. **Clone hoặc chuyển đến thư mục dự án**

2. **Cài đặt các phụ thuộc**:  
   ```cmd
   mvnw clean install
   ```  
   Hoặc nếu đã cài Maven toàn cục:  
   ```cmd
   mvn clean install
   ```

3. **Thiết lập biến môi trường** (xem phần "Lấy GitHub Token" ở trên)

4. **Khởi động dịch vụ MCP Calculator**:  
   Đảm bảo dịch vụ MCP calculator chương 1 đang chạy tại `http://localhost:8080/sse`. Dịch vụ này phải chạy trước khi bạn khởi động client.

## Chạy ứng dụng

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Ứng dụng làm gì

Ứng dụng minh họa ba thao tác chính với dịch vụ máy tính:

1. **Cộng**: Tính tổng 24.5 và 17.3  
2. **Căn bậc hai**: Tính căn bậc hai của 144  
3. **Trợ giúp**: Hiển thị các chức năng có sẵn của máy tính

## Kết quả mong đợi

Khi chạy thành công, bạn sẽ thấy kết quả tương tự:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## Khắc phục sự cố

### Vấn đề thường gặp

1. **"GITHUB_TOKEN environment variable not set"**  
   - Đảm bảo bạn đã thiết lập biến `GITHUB_TOKEN` environment variable
   - Restart your terminal/command prompt after setting the variable

2. **"Connection refused to localhost:8080"**
   - Ensure the MCP calculator service is running on port 8080
   - Check if another service is using port 8080

3. **"Authentication failed"**
   - Verify your GitHub token is valid and has the correct permissions
   - Check if you have access to GitHub Models

4. **Maven build errors**
   - Ensure you're using Java 21 or higher: `java -version`
   - Try cleaning the build: `mvnw clean`

### Gỡ lỗi

Để bật ghi log debug, thêm tham số JVM sau khi chạy:  
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Cấu hình

Ứng dụng được cấu hình để:  
- Sử dụng GitHub Models với `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse`  
- Thời gian chờ 60 giây cho các yêu cầu  
- Bật ghi log yêu cầu/phản hồi để dễ gỡ lỗi

## Phụ thuộc

Các phụ thuộc chính trong dự án:  
- **LangChain4j**: Tích hợp AI và quản lý công cụ  
- **LangChain4j MCP**: Hỗ trợ Model Context Protocol  
- **LangChain4j GitHub Models**: Tích hợp GitHub Models  
- **Spring Boot**: Framework ứng dụng và tiêm phụ thuộc

## Giấy phép

Dự án này được cấp phép theo Apache License 2.0 - xem file [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) để biết chi tiết.

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc nên được xem là nguồn thông tin chính thức. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.