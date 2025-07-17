<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b59b477037dc1dd6b1740a0420f3be14",
  "translation_date": "2025-07-17T08:46:09+00:00",
  "source_file": "02-Security/mcp-security-controls-2025.md",
  "language_code": "vi"
}
-->
# Các Kiểm Soát Bảo Mật MCP Mới Nhất - Cập Nhật Tháng 7 Năm 2025

Khi Model Context Protocol (MCP) tiếp tục phát triển, bảo mật vẫn là yếu tố then chốt cần được quan tâm. Tài liệu này trình bày các kiểm soát bảo mật mới nhất và các thực hành tốt nhất để triển khai MCP một cách an toàn tính đến tháng 7 năm 2025.

## Xác Thực và Ủy Quyền

### Hỗ Trợ Ủy Quyền OAuth 2.0

Các cập nhật gần đây trong đặc tả MCP cho phép các máy chủ MCP ủy quyền xác thực người dùng cho các dịch vụ bên ngoài như Microsoft Entra ID. Điều này cải thiện đáng kể mức độ bảo mật bằng cách:

1. **Loại bỏ việc triển khai xác thực tùy chỉnh**: Giảm nguy cơ lỗi bảo mật trong mã xác thực tự phát triển  
2. **Tận dụng các nhà cung cấp danh tính đã được thiết lập**: Hưởng lợi từ các tính năng bảo mật cấp doanh nghiệp  
3. **Tập trung quản lý danh tính**: Đơn giản hóa việc quản lý vòng đời người dùng và kiểm soát truy cập  

## Ngăn Chặn Chuyển Tiếp Token

Đặc tả Ủy quyền MCP nghiêm cấm việc chuyển tiếp token nhằm ngăn chặn việc bỏ qua kiểm soát bảo mật và các vấn đề về trách nhiệm.

### Yêu Cầu Chính

1. **Máy chủ MCP KHÔNG ĐƯỢC chấp nhận token không được cấp cho chúng**: Xác thực rằng tất cả token có claim audience đúng  
2. **Thực hiện xác thực token đúng cách**: Kiểm tra issuer, audience, thời hạn và chữ ký  
3. **Sử dụng phát hành token riêng biệt**: Cấp token mới cho các dịch vụ hạ nguồn thay vì chuyển tiếp token hiện có  

## Quản Lý Phiên Làm Việc An Toàn

Để ngăn chặn các cuộc tấn công chiếm đoạt hoặc cố định phiên, hãy thực hiện các kiểm soát sau:

1. **Sử dụng ID phiên an toàn, không xác định trước**: Tạo bằng bộ sinh số ngẫu nhiên an toàn mật mã  
2. **Liên kết phiên với danh tính người dùng**: Kết hợp ID phiên với thông tin người dùng cụ thể  
3. **Thực hiện xoay phiên đúng cách**: Sau khi thay đổi xác thực hoặc nâng quyền  
4. **Đặt thời gian hết hạn phiên phù hợp**: Cân bằng giữa bảo mật và trải nghiệm người dùng  

## Cách Ly Thực Thi Công Cụ

Để ngăn chặn di chuyển ngang và hạn chế thiệt hại khi bị xâm nhập:

1. **Cách ly môi trường thực thi công cụ**: Sử dụng container hoặc tiến trình riêng biệt  
2. **Áp dụng giới hạn tài nguyên**: Ngăn chặn các cuộc tấn công làm cạn kiệt tài nguyên  
3. **Thực hiện quyền truy cập tối thiểu cần thiết**: Cấp quyền chỉ khi thật sự cần thiết  
4. **Giám sát các mẫu thực thi**: Phát hiện hành vi bất thường  

## Bảo Vệ Định Nghĩa Công Cụ

Để ngăn chặn việc đầu độc công cụ:

1. **Xác thực định nghĩa công cụ trước khi sử dụng**: Kiểm tra các lệnh độc hại hoặc mẫu không phù hợp  
2. **Sử dụng xác minh tính toàn vẹn**: Băm hoặc ký định nghĩa công cụ để phát hiện thay đổi trái phép  
3. **Thực hiện giám sát thay đổi**: Cảnh báo khi có sửa đổi bất ngờ đối với metadata công cụ  
4. **Quản lý phiên bản định nghĩa công cụ**: Theo dõi thay đổi và cho phép phục hồi khi cần  

Những kiểm soát này phối hợp với nhau để tạo nên một hệ thống bảo mật vững chắc cho các triển khai MCP, giải quyết các thách thức đặc thù của hệ thống AI đồng thời duy trì các thực hành bảo mật truyền thống mạnh mẽ.

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc của nó nên được coi là nguồn chính xác và đáng tin cậy. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.