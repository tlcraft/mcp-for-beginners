<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a0acf3093691b1cfcc008a8c6648ea26",
  "translation_date": "2025-06-13T06:49:11+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "vi"
}
-->
Trong đoạn mã trước, chúng ta đã:

- Nhập các thư viện
- Tạo một thể hiện của client và kết nối nó sử dụng stdio làm phương thức truyền tải.
- Liệt kê các prompt, tài nguyên và công cụ rồi gọi tất cả chúng.

Vậy là bạn đã có một client có thể giao tiếp với MCP Server.

Hãy dành thời gian trong phần bài tập tiếp theo để phân tích từng đoạn mã và giải thích xem nó hoạt động như thế nào.

## Bài tập: Viết một client

Như đã nói ở trên, hãy cùng nhau giải thích mã nguồn, và bạn hoàn toàn có thể code theo nếu muốn.

### -1- Nhập các thư viện

Hãy nhập các thư viện cần thiết, chúng ta sẽ cần tham chiếu đến client và giao thức truyền tải đã chọn, stdio. stdio là một giao thức dành cho các chương trình chạy trên máy cục bộ của bạn. SSE là một giao thức truyền tải khác mà chúng tôi sẽ giới thiệu trong các chương sau, đó cũng là một lựa chọn khác. Nhưng hiện tại, hãy tiếp tục với stdio.

---

Chúng ta tiếp tục với việc khởi tạo.

### -2- Khởi tạo client và giao thức truyền tải

Chúng ta cần tạo một thể hiện của giao thức truyền tải và một thể hiện của client:

---

### -3- Liệt kê các tính năng của server

Bây giờ, chúng ta đã có một client có thể kết nối khi chương trình được chạy. Tuy nhiên, nó chưa thực sự liệt kê các tính năng, vậy hãy làm điều đó ngay sau đây:

---

Tuyệt vời, giờ chúng ta đã lấy được tất cả các tính năng. Vậy khi nào chúng ta sẽ sử dụng chúng? Client này khá đơn giản, nghĩa là chúng ta cần gọi các tính năng một cách rõ ràng khi muốn dùng. Trong chương tiếp theo, chúng ta sẽ tạo một client nâng cao hơn có quyền truy cập vào mô hình ngôn ngữ lớn (LLM) của riêng nó. Nhưng hiện tại, hãy xem cách gọi các tính năng trên server:

### -4- Gọi các tính năng

Để gọi các tính năng, chúng ta cần đảm bảo truyền đúng các tham số và trong một số trường hợp là tên của tính năng muốn gọi.

---

### -5- Chạy client

Để chạy client, gõ lệnh sau trong terminal:

---

## Bài tập

Trong bài tập này, bạn sẽ sử dụng những gì đã học để tạo một client của riêng bạn.

Dưới đây là một server bạn có thể dùng và gọi thông qua mã client của bạn, hãy thử thêm nhiều tính năng hơn cho server để làm nó thú vị hơn.

---

## Giải pháp

[Solution](./solution/README.md)

## Những điểm chính cần nhớ

Các điểm chính về client trong chương này bao gồm:

- Có thể dùng để khám phá và gọi các tính năng trên server.
- Có thể khởi động một server khi client tự khởi động (như trong chương này) nhưng client cũng có thể kết nối đến các server đang chạy.
- Là một cách tuyệt vời để kiểm thử các khả năng của server bên cạnh các lựa chọn khác như Inspector đã được mô tả trong chương trước.

## Tài nguyên bổ sung

- [Xây dựng client trong MCP](https://modelcontextprotocol.io/quickstart/client)

## Mẫu

- [Máy tính Java](../samples/java/calculator/README.md)
- [Máy tính .Net](../../../../03-GettingStarted/samples/csharp)
- [Máy tính JavaScript](../samples/javascript/README.md)
- [Máy tính TypeScript](../samples/typescript/README.md)
- [Máy tính Python](../../../../03-GettingStarted/samples/python)

## Tiếp theo

- Tiếp theo: [Tạo client với LLM](/03-GettingStarted/03-llm-client/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ nguyên bản nên được xem là nguồn tham khảo chính thức. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hay giải thích sai nào phát sinh từ việc sử dụng bản dịch này.