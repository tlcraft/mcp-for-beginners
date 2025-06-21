<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "671162f2687253f22af11187919ed02d",
  "translation_date": "2025-06-21T13:59:22+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "vi"
}
-->
# MCP trong Thực Tiễn: Các Nghiên Cứu Tình Huống Thực tế

Model Context Protocol (MCP) đang thay đổi cách các ứng dụng AI tương tác với dữ liệu, công cụ và dịch vụ. Phần này trình bày các nghiên cứu tình huống thực tế minh họa cách ứng dụng MCP trong nhiều kịch bản doanh nghiệp khác nhau.

## Tổng quan

Phần này giới thiệu các ví dụ cụ thể về việc triển khai MCP, nhấn mạnh cách các tổ chức tận dụng giao thức này để giải quyết những thách thức kinh doanh phức tạp. Qua việc xem xét các nghiên cứu tình huống này, bạn sẽ hiểu rõ hơn về tính linh hoạt, khả năng mở rộng và lợi ích thực tiễn của MCP trong các tình huống thực tế.

## Mục tiêu học tập chính

Khi khám phá các nghiên cứu tình huống này, bạn sẽ:

- Hiểu cách MCP được áp dụng để giải quyết các vấn đề kinh doanh cụ thể
- Tìm hiểu về các mô hình tích hợp và phương pháp kiến trúc khác nhau
- Nhận biết các thực hành tốt nhất khi triển khai MCP trong môi trường doanh nghiệp
- Nắm được những thách thức và giải pháp trong các triển khai thực tế
- Xác định cơ hội áp dụng các mô hình tương tự trong dự án của bạn

## Các nghiên cứu tình huống tiêu biểu

### 1. [Azure AI Travel Agents – Triển khai tham khảo](./travelagentsample.md)

Nghiên cứu này phân tích giải pháp tham khảo toàn diện của Microsoft, trình bày cách xây dựng ứng dụng lập kế hoạch du lịch đa tác nhân, được hỗ trợ bởi AI, sử dụng MCP, Azure OpenAI và Azure AI Search. Dự án thể hiện:

- Điều phối đa tác nhân qua MCP
- Tích hợp dữ liệu doanh nghiệp với Azure AI Search
- Kiến trúc bảo mật, có khả năng mở rộng sử dụng dịch vụ Azure
- Công cụ mở rộng với các thành phần MCP có thể tái sử dụng
- Trải nghiệm người dùng hội thoại được hỗ trợ bởi Azure OpenAI

Kiến trúc và chi tiết triển khai cung cấp những hiểu biết giá trị về cách xây dựng hệ thống đa tác nhân phức tạp với MCP làm lớp điều phối.

### 2. [Cập nhật các mục Azure DevOps từ dữ liệu YouTube](./UpdateADOItemsFromYT.md)

Nghiên cứu này minh họa ứng dụng thực tiễn của MCP trong tự động hóa quy trình làm việc. Nó cho thấy cách sử dụng công cụ MCP để:

- Trích xuất dữ liệu từ các nền tảng trực tuyến (YouTube)
- Cập nhật các mục công việc trong hệ thống Azure DevOps
- Tạo các quy trình tự động hóa có thể lặp lại
- Tích hợp dữ liệu giữa các hệ thống khác nhau

Ví dụ này chứng minh rằng ngay cả các triển khai MCP đơn giản cũng có thể mang lại hiệu quả đáng kể bằng cách tự động hóa các tác vụ thường xuyên và nâng cao tính nhất quán dữ liệu giữa các hệ thống.

### 3. [Truy xuất tài liệu theo thời gian thực với MCP](./docs-mcp/README.md)

Nghiên cứu này hướng dẫn bạn kết nối một client console Python với server Model Context Protocol (MCP) để truy xuất và ghi lại tài liệu Microsoft theo ngữ cảnh, cập nhật theo thời gian thực. Bạn sẽ học cách:

- Kết nối với server MCP bằng client Python và SDK MCP chính thức
- Sử dụng các client HTTP streaming để truy xuất dữ liệu hiệu quả, theo thời gian thực
- Gọi các công cụ tài liệu trên server và ghi phản hồi trực tiếp ra console
- Tích hợp tài liệu Microsoft mới nhất vào quy trình làm việc mà không cần rời khỏi terminal

Chương này bao gồm bài tập thực hành, mẫu mã nguồn tối giản và liên kết tới tài nguyên bổ sung để học sâu hơn. Xem hướng dẫn chi tiết và mã nguồn trong chương liên kết để hiểu cách MCP có thể thay đổi cách truy cập tài liệu và nâng cao hiệu suất làm việc của lập trình viên trong môi trường console.

### 4. [Ứng dụng web tạo kế hoạch học tập tương tác với MCP](./docs-mcp/README.md)

Nghiên cứu này trình bày cách xây dựng ứng dụng web tương tác sử dụng Chainlit và Model Context Protocol (MCP) để tạo kế hoạch học tập cá nhân hóa cho bất kỳ chủ đề nào. Người dùng có thể nhập chủ đề (ví dụ "chứng chỉ AI-900") và thời gian học (ví dụ 8 tuần), ứng dụng sẽ cung cấp phân chia nội dung theo từng tuần. Chainlit cung cấp giao diện trò chuyện hội thoại, giúp trải nghiệm trở nên hấp dẫn và linh hoạt.

- Ứng dụng web hội thoại do Chainlit hỗ trợ
- Lời nhắc do người dùng điều khiển cho chủ đề và thời gian
- Gợi ý nội dung theo tuần dựa trên MCP
- Phản hồi thời gian thực, thích ứng trong giao diện chat

Dự án minh họa cách kết hợp AI hội thoại và MCP để tạo ra công cụ giáo dục động, hướng tới người dùng trong môi trường web hiện đại.

### 5. [Tài liệu trong trình soạn thảo với MCP Server trong VS Code](./docs-mcp/README.md)

Nghiên cứu này cho thấy cách bạn có thể đưa Microsoft Learn Docs trực tiếp vào môi trường VS Code bằng server MCP — không cần phải chuyển đổi tab trình duyệt nữa! Bạn sẽ thấy cách:

- Tìm kiếm và đọc tài liệu ngay trong VS Code qua bảng điều khiển MCP hoặc command palette
- Tham chiếu tài liệu và chèn liên kết trực tiếp vào file README hoặc markdown khóa học
- Sử dụng GitHub Copilot kết hợp MCP cho quy trình làm việc tài liệu và mã nguồn liền mạch, được hỗ trợ AI
- Xác thực và cải thiện tài liệu với phản hồi thời gian thực và độ chính xác từ Microsoft
- Tích hợp MCP với quy trình làm việc GitHub để xác thực tài liệu liên tục

Việc triển khai bao gồm:
- Cấu hình `.vscode/mcp.json` ví dụ để thiết lập dễ dàng
- Hướng dẫn qua ảnh chụp màn hình trải nghiệm trong trình soạn thảo
- Mẹo kết hợp Copilot và MCP để tối đa hiệu suất

Tình huống này rất phù hợp cho tác giả khóa học, người viết tài liệu và nhà phát triển muốn tập trung trong trình soạn thảo khi làm việc với tài liệu, Copilot và công cụ xác thực — tất cả đều được hỗ trợ bởi MCP.

## Kết luận

Các nghiên cứu tình huống này làm nổi bật tính linh hoạt và ứng dụng thực tế của Model Context Protocol trong các tình huống thực tế. Từ hệ thống đa tác nhân phức tạp đến các quy trình tự động hóa hướng mục tiêu, MCP cung cấp cách chuẩn hóa để kết nối hệ thống AI với công cụ và dữ liệu cần thiết nhằm tạo ra giá trị.

Qua việc nghiên cứu các triển khai này, bạn có thể rút ra các mẫu kiến trúc, chiến lược triển khai và thực hành tốt nhất để áp dụng vào dự án MCP của riêng mình. Các ví dụ cho thấy MCP không chỉ là một khung lý thuyết mà còn là giải pháp thiết thực cho các thách thức kinh doanh thực tế.

## Tài nguyên bổ sung

- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP Server](https://github.com/MicrosoftDocs/mcp)
- [MCP Community Examples](https://github.com/microsoft/mcp)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ nguyên bản được coi là nguồn tham khảo chính thức. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hay giải thích sai nào phát sinh từ việc sử dụng bản dịch này.