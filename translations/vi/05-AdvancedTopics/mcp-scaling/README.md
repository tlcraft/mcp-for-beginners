<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9730a53698bf9df8166d0080a8d5b61f",
  "translation_date": "2025-06-02T19:56:40+00:00",
  "source_file": "05-AdvancedTopics/mcp-scaling/README.md",
  "language_code": "vi"
}
-->
## Tăng cường theo chiều dọc và Tối ưu hóa tài nguyên

Tăng cường theo chiều dọc tập trung vào việc tối ưu hóa một phiên bản MCP duy nhất để xử lý nhiều yêu cầu hiệu quả hơn. Điều này có thể đạt được bằng cách tinh chỉnh cấu hình, sử dụng các thuật toán hiệu quả và quản lý tài nguyên một cách hợp lý. Ví dụ, bạn có thể điều chỉnh pool luồng, thời gian chờ yêu cầu và giới hạn bộ nhớ để cải thiện hiệu suất.

Hãy cùng xem một ví dụ về cách tối ưu hóa máy chủ MCP cho việc tăng cường theo chiều dọc và quản lý tài nguyên.

## Kiến trúc phân tán

Kiến trúc phân tán bao gồm nhiều nút MCP làm việc cùng nhau để xử lý yêu cầu, chia sẻ tài nguyên và cung cấp khả năng dự phòng. Cách tiếp cận này tăng cường khả năng mở rộng và chịu lỗi bằng cách cho phép các nút giao tiếp và phối hợp thông qua hệ thống phân tán.

Hãy cùng xem một ví dụ về cách triển khai kiến trúc máy chủ MCP phân tán sử dụng Redis để phối hợp.

## Tiếp theo là gì

- [Bảo mật](../mcp-security/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc nên được coi là nguồn chính thức. Đối với thông tin quan trọng, nên sử dụng dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hay diễn giải sai nào phát sinh từ việc sử dụng bản dịch này.