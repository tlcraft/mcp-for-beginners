<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4cc245e2f4ea5db5e2b8c2cd1dadc4b4",
  "translation_date": "2025-07-13T18:18:06+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "vi"
}
-->
Trong đoạn mã trước, chúng ta đã:

- Nhập các thư viện
- Tạo một thể hiện của client và kết nối nó sử dụng stdio làm phương thức truyền tải.
- Liệt kê các prompt, tài nguyên và công cụ rồi gọi tất cả chúng.

Vậy là bạn đã có một client có thể giao tiếp với MCP Server.

Hãy dành thời gian trong phần bài tập tiếp theo để phân tích từng đoạn mã và giải thích những gì đang diễn ra.

## Bài tập: Viết một client

Như đã nói ở trên, hãy dành thời gian giải thích mã, và bạn hoàn toàn có thể viết mã cùng nếu muốn.

### -1- Nhập các thư viện

Hãy nhập các thư viện cần thiết, chúng ta sẽ cần tham chiếu đến client và giao thức truyền tải đã chọn, đó là stdio. stdio là một giao thức dành cho các ứng dụng chạy trên máy cục bộ của bạn. SSE là một giao thức truyền tải khác mà chúng ta sẽ giới thiệu trong các chương sau, nhưng đó là lựa chọn khác của bạn. Còn bây giờ, hãy tiếp tục với stdio.

---

Chúng ta hãy chuyển sang phần khởi tạo.

### -2- Khởi tạo client và giao thức truyền tải

Chúng ta sẽ cần tạo một thể hiện của giao thức truyền tải và một thể hiện của client:

---

### -3- Liệt kê các tính năng của server

Bây giờ, chúng ta đã có một client có thể kết nối khi chương trình được chạy. Tuy nhiên, nó chưa thực sự liệt kê các tính năng của server, vậy hãy làm điều đó ngay bây giờ:

---

Tuyệt vời, giờ chúng ta đã lấy được tất cả các tính năng. Vậy câu hỏi là khi nào chúng ta sử dụng chúng? Client này khá đơn giản, nghĩa là chúng ta sẽ cần gọi rõ ràng các tính năng khi muốn sử dụng. Trong chương tiếp theo, chúng ta sẽ tạo một client nâng cao hơn có quyền truy cập vào mô hình ngôn ngữ lớn (LLM) riêng của nó. Còn bây giờ, hãy xem cách gọi các tính năng trên server:

### -4- Gọi các tính năng

Để gọi các tính năng, chúng ta cần đảm bảo truyền đúng các đối số và trong một số trường hợp là tên của tính năng mà chúng ta muốn gọi.

---

### -5- Chạy client

Để chạy client, gõ lệnh sau trong terminal:

---

## Bài tập

Trong bài tập này, bạn sẽ sử dụng những gì đã học để tạo một client của riêng bạn.

Dưới đây là một server bạn có thể sử dụng và cần gọi thông qua mã client của bạn, hãy thử thêm nhiều tính năng hơn cho server để làm nó thú vị hơn. 

---

## Giải pháp

[Giải pháp](./solution/README.md)

## Những điểm chính cần nhớ

Những điểm chính cần nhớ về client trong chương này là:

- Có thể dùng để khám phá và gọi các tính năng trên server.
- Có thể khởi động server khi client khởi động (như trong chương này) nhưng client cũng có thể kết nối với các server đang chạy.
- Là một cách tuyệt vời để kiểm thử khả năng của server bên cạnh các lựa chọn khác như Inspector đã được mô tả trong chương trước.

## Tài nguyên bổ sung

- [Xây dựng client trong MCP](https://modelcontextprotocol.io/quickstart/client)

## Mẫu ví dụ

- [Máy tính Java](../samples/java/calculator/README.md)
- [Máy tính .Net](../../../../03-GettingStarted/samples/csharp)
- [Máy tính JavaScript](../samples/javascript/README.md)
- [Máy tính TypeScript](../samples/typescript/README.md)
- [Máy tính Python](../../../../03-GettingStarted/samples/python)

## Tiếp theo

- Tiếp theo: [Tạo client với LLM](../03-llm-client/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc của nó nên được coi là nguồn chính xác và đáng tin cậy. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.