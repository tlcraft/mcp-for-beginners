<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c3f4ea5732d64bf965e8aa2907759709",
  "translation_date": "2025-07-17T08:54:03+00:00",
  "source_file": "02-Security/mcp-security-best-practices-2025.md",
  "language_code": "vi"
}
-->
# MCP Security Best Practices - Cập nhật tháng 7 năm 2025

## Các thực hành bảo mật toàn diện cho triển khai MCP

Khi làm việc với các máy chủ MCP, hãy tuân theo các thực hành bảo mật sau để bảo vệ dữ liệu, hạ tầng và người dùng của bạn:

1. **Xác thực đầu vào**: Luôn xác thực và làm sạch dữ liệu đầu vào để ngăn chặn các cuộc tấn công tiêm nhiễm và các vấn đề confused deputy.
   - Thực hiện xác thực nghiêm ngặt cho tất cả các tham số công cụ
   - Sử dụng xác thực theo schema để đảm bảo các yêu cầu phù hợp với định dạng mong đợi
   - Lọc các nội dung có thể gây hại trước khi xử lý

2. **Kiểm soát truy cập**: Triển khai xác thực và phân quyền phù hợp cho máy chủ MCP với các quyền truy cập chi tiết.
   - Sử dụng OAuth 2.0 với các nhà cung cấp danh tính đã được thiết lập như Microsoft Entra ID
   - Triển khai kiểm soát truy cập dựa trên vai trò (RBAC) cho các công cụ MCP
   - Không bao giờ tự triển khai xác thực tùy chỉnh khi đã có giải pháp sẵn có

3. **Giao tiếp an toàn**: Sử dụng HTTPS/TLS cho tất cả các giao tiếp với máy chủ MCP và cân nhắc thêm mã hóa cho dữ liệu nhạy cảm.
   - Cấu hình TLS 1.3 khi có thể
   - Triển khai certificate pinning cho các kết nối quan trọng
   - Thường xuyên thay đổi chứng chỉ và kiểm tra tính hợp lệ của chúng

4. **Giới hạn tốc độ**: Áp dụng giới hạn tốc độ để ngăn chặn lạm dụng, tấn công DoS và quản lý việc sử dụng tài nguyên.
   - Đặt giới hạn yêu cầu phù hợp dựa trên mô hình sử dụng dự kiến
   - Triển khai phản hồi tăng dần đối với các yêu cầu vượt mức
   - Cân nhắc giới hạn tốc độ riêng cho từng người dùng dựa trên trạng thái xác thực

5. **Ghi nhật ký và giám sát**: Giám sát máy chủ MCP để phát hiện hoạt động đáng ngờ và triển khai các bản ghi kiểm toán toàn diện.
   - Ghi lại tất cả các lần thử xác thực và gọi công cụ
   - Triển khai cảnh báo thời gian thực cho các mẫu hành vi đáng ngờ
   - Đảm bảo các bản ghi được lưu trữ an toàn và không thể bị sửa đổi

6. **Lưu trữ an toàn**: Bảo vệ dữ liệu nhạy cảm và thông tin đăng nhập bằng mã hóa thích hợp khi lưu trữ.
   - Sử dụng kho khóa hoặc kho lưu trữ thông tin đăng nhập an toàn cho tất cả các bí mật
   - Triển khai mã hóa ở cấp trường cho dữ liệu nhạy cảm
   - Thường xuyên thay đổi khóa mã hóa và thông tin đăng nhập

7. **Quản lý token**: Ngăn ngừa lỗ hổng token passthrough bằng cách xác thực và làm sạch tất cả đầu vào và đầu ra của mô hình.
   - Thực hiện xác thực token dựa trên các claims về đối tượng nhận
   - Không bao giờ chấp nhận token không được cấp rõ ràng cho máy chủ MCP của bạn
   - Triển khai quản lý vòng đời token và thay đổi token hợp lý

8. **Quản lý phiên làm việc**: Triển khai xử lý phiên làm việc an toàn để ngăn chặn chiếm đoạt và cố định phiên.
   - Sử dụng ID phiên làm việc an toàn, không xác định trước
   - Ràng buộc phiên làm việc với thông tin người dùng cụ thể
   - Triển khai hết hạn và thay đổi phiên làm việc hợp lý

9. **Chạy công cụ trong môi trường cách ly**: Thực thi công cụ trong môi trường tách biệt để ngăn chặn di chuyển ngang nếu bị xâm phạm.
   - Triển khai cách ly container cho việc thực thi công cụ
   - Áp dụng giới hạn tài nguyên để ngăn chặn các cuộc tấn công làm cạn kiệt tài nguyên
   - Sử dụng các ngữ cảnh thực thi riêng biệt cho các miền bảo mật khác nhau

10. **Kiểm tra bảo mật định kỳ**: Thực hiện đánh giá bảo mật định kỳ cho các triển khai MCP và các phụ thuộc.
    - Lên lịch kiểm thử xâm nhập định kỳ
    - Sử dụng công cụ quét tự động để phát hiện lỗ hổng
    - Cập nhật các phụ thuộc để khắc phục các vấn đề bảo mật đã biết

11. **Lọc an toàn nội dung**: Triển khai bộ lọc an toàn nội dung cho cả đầu vào và đầu ra.
    - Sử dụng Azure Content Safety hoặc các dịch vụ tương tự để phát hiện nội dung có hại
    - Triển khai kỹ thuật prompt shield để ngăn chặn tiêm nhiễm prompt
    - Quét nội dung tạo ra để phát hiện rò rỉ dữ liệu nhạy cảm tiềm ẩn

12. **Bảo mật chuỗi cung ứng**: Xác minh tính toàn vẹn và xác thực của tất cả các thành phần trong chuỗi cung ứng AI của bạn.
    - Sử dụng các gói đã ký và xác minh chữ ký
    - Triển khai phân tích phần mềm bill of materials (SBOM)
    - Giám sát các bản cập nhật độc hại cho các phụ thuộc

13. **Bảo vệ định nghĩa công cụ**: Ngăn chặn việc đầu độc công cụ bằng cách bảo vệ định nghĩa và metadata của công cụ.
    - Xác thực định nghĩa công cụ trước khi sử dụng
    - Giám sát các thay đổi bất thường đối với metadata công cụ
    - Triển khai kiểm tra tính toàn vẹn cho định nghĩa công cụ

14. **Giám sát thực thi động**: Giám sát hành vi runtime của máy chủ MCP và các công cụ.
    - Triển khai phân tích hành vi để phát hiện bất thường
    - Thiết lập cảnh báo cho các mẫu thực thi không mong muốn
    - Sử dụng kỹ thuật runtime application self-protection (RASP)

15. **Nguyên tắc quyền tối thiểu**: Đảm bảo máy chủ MCP và công cụ hoạt động với quyền hạn tối thiểu cần thiết.
    - Cấp chỉ các quyền cụ thể cần thiết cho từng thao tác
    - Thường xuyên xem xét và kiểm tra việc sử dụng quyền
    - Triển khai truy cập đúng lúc cho các chức năng quản trị

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc của nó nên được coi là nguồn chính xác và đáng tin cậy. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.