<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9d80e2a99a9aea8d8226253e6baf4c8c",
  "translation_date": "2025-06-06T18:36:33+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "vi"
}
-->
Tuyệt vời, bước tiếp theo của chúng ta là liệt kê các khả năng trên server.

### -2 Liệt kê khả năng của server

Bây giờ chúng ta sẽ kết nối đến server và yêu cầu danh sách các khả năng của nó:

### -3 Chuyển đổi khả năng của server thành công cụ cho LLM

Bước tiếp theo sau khi liệt kê khả năng của server là chuyển đổi chúng sang định dạng mà LLM có thể hiểu. Khi đã làm xong, chúng ta có thể cung cấp các khả năng này dưới dạng công cụ cho LLM.

Tuyệt vời, bây giờ chúng ta đã sẵn sàng để xử lý các yêu cầu từ người dùng, vậy hãy cùng làm phần đó tiếp theo.

### -4 Xử lý yêu cầu prompt từ người dùng

Trong phần mã này, chúng ta sẽ xử lý các yêu cầu từ người dùng.

Tuyệt vời, bạn đã làm được rồi!

## Bài tập

Lấy mã từ bài tập và xây dựng thêm các công cụ cho server. Sau đó tạo một client với LLM, giống như trong bài tập, và thử nghiệm với các prompt khác nhau để đảm bảo tất cả các công cụ trên server của bạn được gọi một cách động. Cách xây dựng client này sẽ mang lại trải nghiệm người dùng tuyệt vời vì họ có thể sử dụng prompt thay vì các lệnh client chính xác, và không cần quan tâm đến việc có MCP server nào được gọi hay không.

## Giải pháp

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Những điểm chính cần nhớ

- Thêm LLM vào client của bạn mang lại cách tương tác tốt hơn cho người dùng với MCP Server.
- Bạn cần chuyển đổi phản hồi từ MCP Server thành thứ mà LLM có thể hiểu được.

## Mẫu

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Tài nguyên bổ sung

## Bước tiếp theo

- Tiếp theo: [Sử dụng server với Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc nên được coi là nguồn tham khảo chính thức. Đối với thông tin quan trọng, nên sử dụng dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.