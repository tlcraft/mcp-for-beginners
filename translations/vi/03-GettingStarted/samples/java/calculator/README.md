<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "13231e9951b68efd9df8c56bd5cdb27e",
  "translation_date": "2025-05-17T13:14:37+00:00",
  "source_file": "03-GettingStarted/samples/java/calculator/README.md",
  "language_code": "vi"
}
-->
# Dịch vụ Máy tính Cơ bản MCP

Dịch vụ này cung cấp các phép toán máy tính cơ bản thông qua Giao thức Ngữ cảnh Mô hình (MCP) sử dụng Spring Boot với WebFlux làm phương tiện truyền tải. Nó được thiết kế như một ví dụ đơn giản cho người mới học về các triển khai MCP.

Để biết thêm thông tin, xem tài liệu tham khảo [MCP Server Boot Starter](https://docs.spring.io/spring-ai/reference/api/mcp/mcp-server-boot-starter-docs.html).

## Tổng quan

Dịch vụ này giới thiệu:
- Hỗ trợ SSE (Sự kiện do máy chủ gửi)
- Đăng ký công cụ tự động bằng cách sử dụng `@Tool` annotation của Spring AI
- Các chức năng máy tính cơ bản:
  - Phép cộng, phép trừ, phép nhân, phép chia
  - Tính lũy thừa và căn bậc hai
  - Phép chia lấy dư và giá trị tuyệt đối
  - Chức năng trợ giúp để mô tả các phép toán

## Tính năng

Dịch vụ máy tính này cung cấp các khả năng sau:

1. **Các phép toán số học cơ bản**:
   - Cộng hai số
   - Trừ một số từ số khác
   - Nhân hai số
   - Chia một số cho số khác (với kiểm tra chia cho số không)

2. **Các phép toán nâng cao**:
   - Tính lũy thừa (nâng một cơ số lên một số mũ)
   - Tính căn bậc hai (với kiểm tra số âm)
   - Tính phép chia lấy dư
   - Tính giá trị tuyệt đối

3. **Hệ thống trợ giúp**:
   - Chức năng trợ giúp tích hợp giải thích tất cả các phép toán có sẵn

## Sử dụng dịch vụ

Dịch vụ này cung cấp các điểm cuối API sau thông qua giao thức MCP:

- `add(a, b)`: Cộng hai số lại với nhau
- `subtract(a, b)`: Trừ số thứ hai từ số thứ nhất
- `multiply(a, b)`: Nhân hai số
- `divide(a, b)`: Chia số thứ nhất cho số thứ hai (với kiểm tra chia cho số không)
- `power(base, exponent)`: Tính lũy thừa của một số
- `squareRoot(number)`: Tính căn bậc hai (với kiểm tra số âm)
- `modulus(a, b)`: Tính phần dư khi chia
- `absolute(number)`: Tính giá trị tuyệt đối
- `help()`: Lấy thông tin về các phép toán có sẵn

## Khách hàng thử nghiệm

Một khách hàng thử nghiệm đơn giản được bao gồm trong gói `com.microsoft.mcp.sample.client`. Lớp `SampleCalculatorClient` minh họa các phép toán có sẵn của dịch vụ máy tính.

## Sử dụng Khách hàng LangChain4j

Dự án bao gồm một ví dụ khách hàng LangChain4j trong `com.microsoft.mcp.sample.client.LangChain4jClient`, minh họa cách tích hợp dịch vụ máy tính với LangChain4j và các mô hình GitHub:

### Yêu cầu trước

1. **Thiết lập Mã thông báo GitHub**:
   
   Để sử dụng các mô hình AI của GitHub (như phi-4), bạn cần có mã thông báo truy cập cá nhân của GitHub:

   a. Đi đến cài đặt tài khoản GitHub của bạn: https://github.com/settings/tokens
   
   b. Nhấp vào "Generate new token" → "Generate new token (classic)"
   
   c. Đặt tên mô tả cho mã thông báo của bạn
   
   d. Chọn các phạm vi sau:
      - `repo` (Kiểm soát toàn bộ các kho lưu trữ riêng)
      - `read:org` (Đọc thành viên tổ chức và nhóm, đọc dự án tổ chức)
      - `gist` (Tạo gists)
      - `user:email` (Truy cập địa chỉ email người dùng (chỉ đọc))
   
   e. Nhấp vào "Generate token" và sao chép mã thông báo mới của bạn
   
   f. Đặt nó làm biến môi trường:
      
      Trên Windows:
      ```
      set GITHUB_TOKEN=your-github-token
      ```
      
      Trên macOS/Linux:
      ```bash
      export GITHUB_TOKEN=your-github-token
      ```

   g. Để thiết lập lâu dài, thêm nó vào các biến môi trường của bạn thông qua cài đặt hệ thống

2. Thêm phụ thuộc LangChain4j GitHub vào dự án của bạn (đã được bao gồm trong pom.xml):
   ```xml
   <dependency>
       <groupId>dev.langchain4j</groupId>
       <artifactId>langchain4j-github</artifactId>
       <version>${langchain4j.version}</version>
   </dependency>
   ```

3. Đảm bảo máy chủ máy tính đang chạy trên `localhost:8080`

### Chạy Khách hàng LangChain4j

Ví dụ này minh họa:
- Kết nối với máy chủ MCP máy tính qua phương tiện truyền tải SSE
- Sử dụng LangChain4j để tạo một chatbot tận dụng các phép toán máy tính
- Tích hợp với các mô hình AI của GitHub (hiện đang sử dụng mô hình phi-4)

Khách hàng gửi các truy vấn mẫu sau để minh họa chức năng:
1. Tính tổng của hai số
2. Tìm căn bậc hai của một số
3. Lấy thông tin trợ giúp về các phép toán máy tính có sẵn

Chạy ví dụ và kiểm tra đầu ra của bảng điều khiển để xem cách mô hình AI sử dụng các công cụ máy tính để trả lời các truy vấn.

### Cấu hình Mô hình GitHub

Khách hàng LangChain4j được cấu hình để sử dụng mô hình phi-4 của GitHub với các cài đặt sau:

```java
ChatLanguageModel model = GitHubChatModel.builder()
    .apiKey(System.getenv("GITHUB_TOKEN"))
    .timeout(Duration.ofSeconds(60))
    .modelName("phi-4")
    .logRequests(true)
    .logResponses(true)
    .build();
```

Để sử dụng các mô hình GitHub khác, chỉ cần thay đổi tham số `modelName` thành mô hình được hỗ trợ khác (ví dụ: "claude-3-haiku-20240307", "llama-3-70b-8192", v.v.).

## Phụ thuộc

Dự án yêu cầu các phụ thuộc chính sau:

```xml
<!-- For MCP Server -->
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>

<!-- For LangChain4j integration -->
<dependency>
    <groupId>dev.langchain4j</groupId>
    <artifactId>langchain4j-mcp</artifactId>
    <version>${langchain4j.version}</version>
</dependency>

<!-- For GitHub models support -->
<dependency>
    <groupId>dev.langchain4j</groupId>
    <artifactId>langchain4j-github</artifactId>
    <version>${langchain4j.version}</version>
</dependency>
```

## Xây dựng Dự án

Xây dựng dự án bằng Maven:
```bash
./mvnw clean install -DskipTests
```

## Chạy Máy chủ

### Sử dụng Java

```bash
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

### Sử dụng MCP Inspector

MCP Inspector là một công cụ hữu ích để tương tác với các dịch vụ MCP. Để sử dụng nó với dịch vụ máy tính này:

1. **Cài đặt và chạy MCP Inspector** trong một cửa sổ terminal mới:
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **Truy cập giao diện web** bằng cách nhấp vào URL được hiển thị bởi ứng dụng (thường là http://localhost:6274)

3. **Cấu hình kết nối**:
   - Đặt loại phương tiện truyền tải là "SSE"
   - Đặt URL đến điểm cuối SSE của máy chủ đang chạy của bạn: `http://localhost:8080/sse`
   - Nhấp vào "Connect"

4. **Sử dụng công cụ**:
   - Nhấp vào "List Tools" để xem các phép toán máy tính có sẵn
   - Chọn một công cụ và nhấp vào "Run Tool" để thực hiện một phép toán

![Ảnh chụp màn hình MCP Inspector](../../../../../../translated_images/tool.d45bdee7d4d5740a48d0d6378c9a8af0c1a289f1e0f2ae95ee176f1a5afb40a8.vi.png)

### Sử dụng Docker

Dự án bao gồm một Dockerfile cho triển khai container hóa:

1. **Xây dựng hình ảnh Docker**:
   ```bash
   docker build -t calculator-mcp-service .
   ```

2. **Chạy container Docker**:
   ```bash
   docker run -p 8080:8080 calculator-mcp-service
   ```

Điều này sẽ:
- Xây dựng một hình ảnh Docker đa giai đoạn với Maven 3.9.9 và Eclipse Temurin 24 JDK
- Tạo một hình ảnh container tối ưu
- Mở dịch vụ trên cổng 8080
- Khởi động dịch vụ máy tính MCP bên trong container

Bạn có thể truy cập dịch vụ tại `http://localhost:8080` khi container đang chạy.

## Khắc phục sự cố

### Vấn đề thường gặp với Mã thông báo GitHub

1. **Vấn đề về quyền của mã thông báo**: Nếu bạn nhận được lỗi 403 Forbidden, hãy kiểm tra mã thông báo của bạn có các quyền đúng như đã nêu trong các yêu cầu trước.

2. **Mã thông báo không tìm thấy**: Nếu bạn nhận được lỗi "No API key found", đảm bảo biến môi trường GITHUB_TOKEN được đặt đúng.

3. **Giới hạn tốc độ**: API của GitHub có giới hạn tốc độ. Nếu bạn gặp lỗi giới hạn tốc độ (mã trạng thái 429), hãy đợi vài phút trước khi thử lại.

4. **Hết hạn mã thông báo**: Mã thông báo GitHub có thể hết hạn. Nếu bạn nhận được lỗi xác thực sau một thời gian, hãy tạo mã thông báo mới và cập nhật biến môi trường của bạn.

Nếu bạn cần hỗ trợ thêm, hãy kiểm tra tài liệu [LangChain4j](https://github.com/langchain4j/langchain4j) hoặc tài liệu [GitHub API](https://docs.github.com/en/rest).

**Tuyên bố miễn trừ trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc sự không chính xác. Tài liệu gốc bằng ngôn ngữ bản địa nên được coi là nguồn thông tin có thẩm quyền. Đối với thông tin quan trọng, khuyến nghị sử dụng dịch vụ dịch thuật chuyên nghiệp của con người. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc diễn giải sai nào phát sinh từ việc sử dụng bản dịch này.