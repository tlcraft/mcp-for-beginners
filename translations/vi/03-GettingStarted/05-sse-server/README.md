<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "64645691bf0985f1760b948123edf269",
  "translation_date": "2025-06-13T10:54:03+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "vi"
}
-->
Bây giờ chúng ta đã hiểu thêm về SSE, hãy cùng xây dựng một server SSE tiếp theo.

## Bài tập: Tạo một SSE Server

Để tạo server, chúng ta cần nhớ hai điều:

- Cần sử dụng một web server để mở các endpoint cho kết nối và tin nhắn.
- Xây dựng server như bình thường với các công cụ, tài nguyên và lời nhắc khi sử dụng stdio.

### -1- Tạo một instance server

Để tạo server, chúng ta dùng cùng các kiểu như với stdio. Tuy nhiên, với transport, ta chọn SSE.

Hãy thêm các route cần thiết tiếp theo.

### -2- Thêm các route

Thêm các route xử lý kết nối và tin nhắn đến:

Tiếp theo, thêm các khả năng cho server.

### -3- Thêm khả năng cho server

Bây giờ khi đã định nghĩa xong các phần đặc thù của SSE, hãy thêm các khả năng như công cụ, lời nhắc và tài nguyên cho server.

Mã đầy đủ của bạn sẽ trông như sau:

Tuyệt vời, chúng ta đã có một server sử dụng SSE, bây giờ hãy thử vận hành nó.

## Bài tập: Gỡ lỗi SSE Server với Inspector

Inspector là một công cụ tuyệt vời mà chúng ta đã thấy trong bài trước [Creating your first server](/03-GettingStarted/01-first-server/README.md). Hãy xem liệu ta có thể dùng Inspector ở đây không:

### -1- Chạy Inspector

Để chạy Inspector, bạn phải có một server SSE đang chạy, vậy hãy làm điều đó trước:

1. Chạy server

1. Chạy inspector

    > ![NOTE]
    > Chạy lệnh này trong một cửa sổ terminal riêng biệt so với nơi server đang chạy. Ngoài ra, bạn cần điều chỉnh lệnh dưới đây cho phù hợp với URL mà server của bạn đang chạy.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Việc chạy inspector giống nhau trên tất cả các runtime. Lưu ý thay vì truyền đường dẫn đến server và lệnh khởi động server, ta truyền URL nơi server đang chạy và chỉ định thêm route `/sse`.

### -2- Thử nghiệm công cụ

Kết nối server bằng cách chọn SSE trong danh sách thả xuống và điền vào trường URL nơi server của bạn đang chạy, ví dụ http:localhost:4321/sse. Bấm nút "Connect". Như trước, chọn để liệt kê các công cụ, chọn một công cụ và nhập giá trị đầu vào. Bạn sẽ thấy kết quả như hình dưới đây:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.vi.png)

Tuyệt vời, bạn đã có thể làm việc với inspector, giờ hãy xem cách làm việc với Visual Studio Code.

## Bài tập về nhà

Hãy thử mở rộng server của bạn với nhiều khả năng hơn. Xem [trang này](https://api.chucknorris.io/) để ví dụ thêm một công cụ gọi API, bạn quyết định server nên trông như thế nào. Chúc bạn vui :)

## Giải pháp

[Giải pháp](./solution/README.md) Đây là một giải pháp có mã hoạt động.

## Những điểm cần ghi nhớ

Những điểm chính trong chương này là:

- SSE là phương thức truyền thứ hai được hỗ trợ bên cạnh stdio.
- Để hỗ trợ SSE, bạn cần quản lý kết nối và tin nhắn đến sử dụng một framework web.
- Bạn có thể dùng cả Inspector và Visual Studio Code để tiêu thụ server SSE, giống như server stdio. Lưu ý sự khác biệt nhỏ giữa stdio và SSE. Với SSE, bạn cần khởi động server riêng rồi chạy công cụ inspector. Với công cụ inspector, cũng cần chỉ định URL.

## Mẫu ví dụ

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Tài nguyên bổ sung

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Tiếp theo

- Tiếp theo: [HTTP Streaming với MCP (Streamable HTTP)](/03-GettingStarted/06-http-streaming/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc nên được coi là nguồn chính thức. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ hiểu lầm hay diễn giải sai nào phát sinh từ việc sử dụng bản dịch này.