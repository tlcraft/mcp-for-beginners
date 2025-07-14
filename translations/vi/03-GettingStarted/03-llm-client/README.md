<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f74887f51a69d3f255cb83d0b517c623",
  "translation_date": "2025-07-13T18:54:05+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "vi"
}
-->
Tuyệt vời, bước tiếp theo của chúng ta là liệt kê các khả năng trên server.

### -2 Liệt kê các khả năng của server

Bây giờ chúng ta sẽ kết nối với server và yêu cầu danh sách các khả năng của nó:

### -3- Chuyển đổi các khả năng của server thành công cụ cho LLM

Bước tiếp theo sau khi liệt kê các khả năng của server là chuyển đổi chúng sang định dạng mà LLM có thể hiểu. Khi đã làm được điều đó, chúng ta có thể cung cấp các khả năng này như các công cụ cho LLM của mình.

Tuyệt vời, bây giờ chúng ta đã sẵn sàng để xử lý các yêu cầu từ người dùng, hãy cùng thực hiện bước tiếp theo.

### -4- Xử lý yêu cầu prompt từ người dùng

Trong phần mã này, chúng ta sẽ xử lý các yêu cầu từ người dùng.

Tuyệt vời, bạn đã làm được rồi!

## Bài tập

Lấy mã từ bài tập và xây dựng server với nhiều công cụ hơn. Sau đó tạo một client có tích hợp LLM, giống như trong bài tập, và thử nghiệm với các prompt khác nhau để đảm bảo tất cả các công cụ trên server của bạn được gọi một cách linh hoạt. Cách xây dựng client này giúp người dùng cuối có trải nghiệm tuyệt vời vì họ có thể sử dụng prompt thay vì các lệnh chính xác của client và không cần quan tâm đến việc gọi server MCP.

## Giải pháp

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Những điểm chính cần nhớ

- Thêm LLM vào client giúp người dùng tương tác với MCP Server một cách tốt hơn.
- Bạn cần chuyển đổi phản hồi từ MCP Server thành định dạng mà LLM có thể hiểu.

## Mẫu ví dụ

- [Máy tính Java](../samples/java/calculator/README.md)
- [Máy tính .Net](../../../../03-GettingStarted/samples/csharp)
- [Máy tính JavaScript](../samples/javascript/README.md)
- [Máy tính TypeScript](../samples/typescript/README.md)
- [Máy tính Python](../../../../03-GettingStarted/samples/python)

## Tài nguyên bổ sung

## Tiếp theo

- Tiếp theo: [Sử dụng server với Visual Studio Code](../04-vscode/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc của nó nên được coi là nguồn chính xác và đáng tin cậy. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.