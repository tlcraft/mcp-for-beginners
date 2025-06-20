<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6c11b6162171abc895ed75d1e0f368a3",
  "translation_date": "2025-06-20T19:09:38+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "vi"
}
-->
# MCP trong Thực Tiễn: Các Nghiên Cứu Tình Huống Thực Tế

Model Context Protocol (MCP) đang thay đổi cách các ứng dụng AI tương tác với dữ liệu, công cụ và dịch vụ. Phần này trình bày các nghiên cứu tình huống thực tế minh họa ứng dụng thực tiễn của MCP trong nhiều kịch bản doanh nghiệp khác nhau.

## Tổng Quan

Phần này giới thiệu các ví dụ cụ thể về việc triển khai MCP, làm nổi bật cách các tổ chức tận dụng giao thức này để giải quyết các thách thức kinh doanh phức tạp. Qua việc xem xét các nghiên cứu tình huống này, bạn sẽ hiểu rõ hơn về tính linh hoạt, khả năng mở rộng và lợi ích thực tiễn của MCP trong các kịch bản thực tế.

## Mục Tiêu Học Tập Chính

Thông qua việc khám phá các nghiên cứu tình huống này, bạn sẽ:

- Hiểu cách MCP có thể được áp dụng để giải quyết các vấn đề kinh doanh cụ thể
- Tìm hiểu về các mẫu tích hợp và phương pháp kiến trúc khác nhau
- Nhận biết các thực hành tốt nhất khi triển khai MCP trong môi trường doanh nghiệp
- Nắm bắt các thách thức và giải pháp gặp phải trong các triển khai thực tế
- Xác định cơ hội áp dụng các mẫu tương tự trong dự án của chính bạn

## Các Nghiên Cứu Tình Huống Tiêu Biểu

### 1. [Azure AI Travel Agents – Triển Khai Tham Chiếu](./travelagentsample.md)

Nghiên cứu tình huống này xem xét giải pháp tham chiếu toàn diện của Microsoft, minh họa cách xây dựng ứng dụng lập kế hoạch du lịch đa tác nhân, được hỗ trợ bởi AI, sử dụng MCP, Azure OpenAI và Azure AI Search. Dự án thể hiện:

- Điều phối đa tác nhân thông qua MCP
- Tích hợp dữ liệu doanh nghiệp với Azure AI Search
- Kiến trúc bảo mật, có khả năng mở rộng sử dụng các dịch vụ Azure
- Công cụ mở rộng với các thành phần MCP có thể tái sử dụng
- Trải nghiệm người dùng hội thoại được hỗ trợ bởi Azure OpenAI

Chi tiết kiến trúc và triển khai cung cấp những hiểu biết quý giá về cách xây dựng các hệ thống đa tác nhân phức tạp với MCP làm lớp điều phối.

### 2. [Cập Nhật Các Mục Azure DevOps Từ Dữ Liệu YouTube](./UpdateADOItemsFromYT.md)

Nghiên cứu tình huống này minh họa ứng dụng thực tế của MCP trong tự động hóa quy trình làm việc. Nó cho thấy cách các công cụ MCP có thể được sử dụng để:

- Trích xuất dữ liệu từ các nền tảng trực tuyến (YouTube)
- Cập nhật các mục công việc trong hệ thống Azure DevOps
- Tạo các quy trình tự động hóa có thể lặp lại
- Tích hợp dữ liệu giữa các hệ thống khác nhau

Ví dụ này minh họa cách các triển khai MCP tương đối đơn giản cũng có thể mang lại hiệu quả đáng kể bằng cách tự động hóa các nhiệm vụ thường nhật và cải thiện tính nhất quán dữ liệu giữa các hệ thống.

## Kết Luận

Các nghiên cứu tình huống này làm nổi bật tính linh hoạt và ứng dụng thực tiễn của Model Context Protocol trong các kịch bản thực tế. Từ các hệ thống đa tác nhân phức tạp đến các quy trình tự động hóa có mục tiêu, MCP cung cấp một phương thức chuẩn hóa để kết nối các hệ thống AI với công cụ và dữ liệu cần thiết nhằm tạo ra giá trị.

Qua việc nghiên cứu các triển khai này, bạn có thể rút ra được các mẫu kiến trúc, chiến lược triển khai và thực hành tốt nhất để áp dụng vào các dự án MCP của riêng bạn. Các ví dụ chứng minh rằng MCP không chỉ là một khuôn khổ lý thuyết mà còn là giải pháp thực tiễn cho các thách thức kinh doanh thực tế.

## Tài Nguyên Bổ Sung

- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)
- [MCP Community Examples](https://github.com/microsoft/mcp)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi nỗ lực đảm bảo độ chính xác, xin lưu ý rằng bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ nguyên bản nên được coi là nguồn thông tin chính xác nhất. Đối với các thông tin quan trọng, khuyến nghị sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm đối với bất kỳ sự hiểu nhầm hay giải thích sai nào phát sinh từ việc sử dụng bản dịch này.