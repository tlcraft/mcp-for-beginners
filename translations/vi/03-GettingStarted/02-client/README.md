<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a9c3ca25df37dbb4c1518174fc415ce1",
  "translation_date": "2025-05-17T09:43:59+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "vi"
}
-->
# Tạo một client

Clients là các ứng dụng tùy chỉnh hoặc script giao tiếp trực tiếp với một MCP Server để yêu cầu tài nguyên, công cụ và nhắc nhở. Không giống như việc sử dụng công cụ inspector, cung cấp giao diện đồ họa để tương tác với server, việc viết client của riêng bạn cho phép tương tác lập trình và tự động hóa. Điều này giúp các nhà phát triển tích hợp khả năng MCP vào quy trình làm việc của riêng họ, tự động hóa nhiệm vụ và xây dựng các giải pháp tùy chỉnh phù hợp với nhu cầu cụ thể.

## Tổng quan

Bài học này giới thiệu khái niệm về clients trong hệ sinh thái Model Context Protocol (MCP). Bạn sẽ học cách viết client của riêng mình và kết nối nó với MCP Server.

## Mục tiêu học tập

Kết thúc bài học này, bạn sẽ có thể:

- Hiểu client có thể làm gì.
- Viết client của riêng bạn.
- Kết nối và kiểm tra client với MCP server để đảm bảo server hoạt động như mong đợi.

## Những gì cần thiết để viết một client?

Để viết một client, bạn cần thực hiện các bước sau:

- **Nhập các thư viện chính xác**. Bạn sẽ sử dụng cùng thư viện như trước, chỉ khác các cấu trúc.
- **Khởi tạo một client**. Điều này bao gồm việc tạo một instance client và kết nối nó với phương thức truyền tải đã chọn.
- **Quyết định tài nguyên nào cần liệt kê**. MCP server của bạn đi kèm với tài nguyên, công cụ và nhắc nhở, bạn cần quyết định cái nào cần liệt kê.
- **Tích hợp client vào ứng dụng host**. Khi bạn biết khả năng của server, bạn cần tích hợp nó vào ứng dụng host để nếu người dùng nhập một nhắc nhở hoặc lệnh khác, tính năng server tương ứng sẽ được gọi.

Bây giờ chúng ta đã hiểu ở mức độ cao những gì sắp thực hiện, hãy xem một ví dụ tiếp theo.

### Một ví dụ client

Hãy xem ví dụ client này:
Bạn được đào tạo trên dữ liệu đến tháng 10 năm 2023.

Trong đoạn mã trước:

- Nhập các thư viện
- Tạo một instance của client và kết nối nó sử dụng stdio cho truyền tải.
- Liệt kê các nhắc nhở, tài nguyên và công cụ và gọi chúng tất cả.

Vậy là bạn đã có một client có thể nói chuyện với MCP Server.

Hãy dành thời gian ở phần bài tập tiếp theo và phân tích từng đoạn mã và giải thích những gì đang diễn ra.

## Bài tập: Viết một client

Như đã nói ở trên, hãy dành thời gian giải thích mã, và bằng mọi cách hãy mã hóa cùng nếu bạn muốn.

### -1- Nhập các thư viện

Hãy nhập các thư viện chúng ta cần, chúng ta sẽ cần tham chiếu đến một client và đến giao thức truyền tải đã chọn, stdio. stdio là một giao thức cho những thứ dự định chạy trên máy cục bộ của bạn. SSE là một giao thức truyền tải khác mà chúng ta sẽ trình bày trong các chương sau nhưng đó là lựa chọn khác của bạn. Tuy nhiên, bây giờ hãy tiếp tục với stdio.

Tiếp tục với khởi tạo.

### -2- Khởi tạo client và truyền tải

Chúng ta sẽ cần tạo một instance của truyền tải và của client:

### -3- Liệt kê các tính năng của server

Bây giờ, chúng ta có một client có thể kết nối nếu chương trình được chạy. Tuy nhiên, nó không thực sự liệt kê các tính năng của nó nên hãy làm điều đó tiếp theo:

Tuyệt vời, bây giờ chúng ta đã nắm bắt tất cả các tính năng. Câu hỏi là khi nào chúng ta sử dụng chúng? Chà, client này khá đơn giản, đơn giản theo nghĩa là chúng ta sẽ cần gọi rõ ràng các tính năng khi chúng ta muốn chúng. Trong chương tiếp theo, chúng ta sẽ tạo một client tiên tiến hơn có quyền truy cập vào mô hình ngôn ngữ lớn của riêng nó, LLM. Tuy nhiên, bây giờ hãy xem cách chúng ta có thể gọi các tính năng trên server:

### -4- Gọi các tính năng

Để gọi các tính năng, chúng ta cần đảm bảo rằng chúng ta chỉ định đúng các đối số và trong một số trường hợp là tên của những gì chúng ta đang cố gắng gọi.

### -5- Chạy client

Để chạy client, nhập lệnh sau trong terminal:

## Bài tập

Trong bài tập này, bạn sẽ sử dụng những gì bạn đã học trong việc tạo một client nhưng tạo một client của riêng bạn.

Đây là một server bạn có thể sử dụng mà bạn cần gọi qua mã client của mình, xem liệu bạn có thể thêm nhiều tính năng hơn vào server để làm cho nó thú vị hơn.

## Giải pháp

[Giải pháp](./solution/README.md)

## Những điểm chính cần nhớ

Những điểm chính cần nhớ cho chương này về clients:

- Có thể được sử dụng để cả khám phá và gọi các tính năng trên server.
- Có thể khởi động một server trong khi nó tự khởi động (như trong chương này) nhưng clients cũng có thể kết nối với các server đang chạy.
- Là một cách tuyệt vời để kiểm tra khả năng của server bên cạnh các lựa chọn thay thế như Inspector như đã được mô tả trong chương trước.

## Tài nguyên bổ sung

- [Xây dựng clients trong MCP](https://modelcontextprotocol.io/quickstart/client)

## Mẫu

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Tiếp theo

- Tiếp theo: [Tạo client với LLM](/03-GettingStarted/03-llm-client/README.md)

**Tuyên bố miễn trừ trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ bản địa của nó nên được coi là nguồn thông tin chính thống. Đối với thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp của con người. Chúng tôi không chịu trách nhiệm cho bất kỳ sự hiểu lầm hoặc diễn giải sai nào phát sinh từ việc sử dụng bản dịch này.