<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "61a160248efabe92b09d7b08293d17db",
  "translation_date": "2025-08-18T17:05:45+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "vi"
}
-->
# MCP trong Thực Tiễn: Các Nghiên Cứu Tình Huống Thực Tế

[![MCP trong Thực Tiễn: Các Nghiên Cứu Tình Huống Thực Tế](../../../translated_images/10.3262cc80b4de5071fde8ba74c5c5d6738a0a9f398dcc0423f0210f632e2238b8.vi.png)](https://youtu.be/IxshWb2Az5w)

_(Nhấp vào hình ảnh trên để xem video của bài học này)_

Giao thức Model Context Protocol (MCP) đang thay đổi cách các ứng dụng AI tương tác với dữ liệu, công cụ và dịch vụ. Phần này giới thiệu các nghiên cứu tình huống thực tế, minh họa cách MCP được áp dụng trong các kịch bản doanh nghiệp khác nhau.

## Tổng Quan

Phần này trình bày các ví dụ cụ thể về việc triển khai MCP, làm nổi bật cách các tổ chức tận dụng giao thức này để giải quyết các thách thức kinh doanh phức tạp. Qua việc nghiên cứu các tình huống này, bạn sẽ hiểu rõ hơn về tính linh hoạt, khả năng mở rộng và lợi ích thực tiễn của MCP trong các kịch bản thực tế.

## Mục Tiêu Học Tập Chính

Khi khám phá các nghiên cứu tình huống này, bạn sẽ:

- Hiểu cách MCP có thể được áp dụng để giải quyết các vấn đề kinh doanh cụ thể
- Tìm hiểu về các mẫu tích hợp và cách tiếp cận kiến trúc khác nhau
- Nhận biết các thực hành tốt nhất để triển khai MCP trong môi trường doanh nghiệp
- Hiểu rõ các thách thức và giải pháp trong các triển khai thực tế
- Xác định cơ hội áp dụng các mẫu tương tự vào dự án của bạn

## Các Nghiên Cứu Tình Huống Nổi Bật

### 1. [Azure AI Travel Agents – Triển Khai Tham Chiếu](./travelagentsample.md)

Nghiên cứu tình huống này phân tích giải pháp tham chiếu toàn diện của Microsoft, minh họa cách xây dựng một ứng dụng lập kế hoạch du lịch đa tác nhân, được hỗ trợ bởi AI, sử dụng MCP, Azure OpenAI và Azure AI Search. Dự án này bao gồm:

- Điều phối đa tác nhân thông qua MCP
- Tích hợp dữ liệu doanh nghiệp với Azure AI Search
- Kiến trúc an toàn, có khả năng mở rộng sử dụng các dịch vụ Azure
- Công cụ mở rộng với các thành phần MCP có thể tái sử dụng
- Trải nghiệm người dùng hội thoại được hỗ trợ bởi Azure OpenAI

Chi tiết về kiến trúc và triển khai cung cấp những hiểu biết giá trị về cách xây dựng các hệ thống đa tác nhân phức tạp với MCP làm lớp điều phối.

### 2. [Cập Nhật Mục Azure DevOps từ Dữ Liệu YouTube](./UpdateADOItemsFromYT.md)

Nghiên cứu tình huống này minh họa một ứng dụng thực tế của MCP trong việc tự động hóa quy trình làm việc. Nó cho thấy cách các công cụ MCP có thể được sử dụng để:

- Trích xuất dữ liệu từ các nền tảng trực tuyến (YouTube)
- Cập nhật các mục công việc trong hệ thống Azure DevOps
- Tạo các quy trình tự động hóa có thể lặp lại
- Tích hợp dữ liệu giữa các hệ thống khác nhau

Ví dụ này minh họa cách ngay cả các triển khai MCP tương đối đơn giản cũng có thể mang lại hiệu quả đáng kể bằng cách tự động hóa các tác vụ thường xuyên và cải thiện tính nhất quán của dữ liệu giữa các hệ thống.

### 3. [Truy Xuất Tài Liệu Theo Thời Gian Thực với MCP](./docs-mcp/README.md)

Nghiên cứu tình huống này hướng dẫn bạn cách kết nối một ứng dụng console Python với máy chủ Model Context Protocol (MCP) để truy xuất và ghi lại tài liệu Microsoft theo ngữ cảnh, theo thời gian thực. Bạn sẽ học cách:

- Kết nối với máy chủ MCP bằng ứng dụng Python và MCP SDK chính thức
- Sử dụng các client HTTP streaming để truy xuất dữ liệu theo thời gian thực một cách hiệu quả
- Gọi các công cụ tài liệu trên máy chủ và ghi lại phản hồi trực tiếp vào console
- Tích hợp tài liệu Microsoft cập nhật vào quy trình làm việc của bạn mà không cần rời khỏi terminal

Chương này bao gồm một bài tập thực hành, một mẫu mã hoạt động tối thiểu và các liên kết đến tài nguyên bổ sung để học sâu hơn. Xem toàn bộ hướng dẫn và mã trong chương liên kết để hiểu cách MCP có thể thay đổi cách truy cập tài liệu và năng suất của nhà phát triển trong môi trường console.

### 4. [Ứng Dụng Web Tạo Kế Hoạch Học Tập Tương Tác với MCP](./docs-mcp/README.md)

Nghiên cứu tình huống này minh họa cách xây dựng một ứng dụng web tương tác sử dụng Chainlit và Model Context Protocol (MCP) để tạo các kế hoạch học tập cá nhân hóa cho bất kỳ chủ đề nào. Người dùng có thể chỉ định một chủ đề (như "Chứng chỉ AI-900") và thời gian học (ví dụ: 8 tuần), và ứng dụng sẽ cung cấp một kế hoạch nội dung theo tuần. Chainlit cung cấp giao diện trò chuyện hội thoại, làm cho trải nghiệm trở nên hấp dẫn và thích ứng.

- Ứng dụng web hội thoại được hỗ trợ bởi Chainlit
- Các yêu cầu do người dùng đưa ra về chủ đề và thời gian
- Đề xuất nội dung theo tuần sử dụng MCP
- Phản hồi theo thời gian thực, thích ứng trong giao diện trò chuyện

Dự án minh họa cách AI hội thoại và MCP có thể được kết hợp để tạo ra các công cụ giáo dục động, hướng người dùng trong môi trường web hiện đại.

### 5. [Tài Liệu Trong Trình Soạn Thảo với MCP Server trong VS Code](./docs-mcp/README.md)

Nghiên cứu tình huống này minh họa cách bạn có thể mang tài liệu Microsoft Learn Docs trực tiếp vào môi trường VS Code của mình bằng máy chủ MCP—không cần chuyển đổi giữa các tab trình duyệt! Bạn sẽ thấy cách:

- Tìm kiếm và đọc tài liệu ngay trong VS Code bằng bảng MCP hoặc command palette
- Tham khảo tài liệu và chèn liên kết trực tiếp vào các tệp README hoặc markdown khóa học của bạn
- Sử dụng GitHub Copilot và MCP cùng nhau để có quy trình làm việc tài liệu và mã hóa được hỗ trợ bởi AI
- Xác thực và cải thiện tài liệu của bạn với phản hồi theo thời gian thực và độ chính xác từ Microsoft
- Tích hợp MCP với quy trình làm việc GitHub để xác thực tài liệu liên tục

Triển khai bao gồm:

- Ví dụ cấu hình `.vscode/mcp.json` để thiết lập dễ dàng
- Hướng dẫn từng bước bằng hình ảnh về trải nghiệm trong trình soạn thảo
- Mẹo kết hợp Copilot và MCP để đạt năng suất tối đa

Kịch bản này lý tưởng cho các tác giả khóa học, người viết tài liệu và nhà phát triển muốn tập trung trong trình soạn thảo của họ trong khi làm việc với tài liệu, Copilot và các công cụ xác thực—tất cả đều được hỗ trợ bởi MCP.

### 6. [Tạo Máy Chủ MCP với APIM](./apimsample.md)

Nghiên cứu tình huống này cung cấp hướng dẫn từng bước về cách tạo một máy chủ MCP bằng Azure API Management (APIM). Nó bao gồm:

- Thiết lập máy chủ MCP trong Azure API Management
- Cung cấp các hoạt động API dưới dạng công cụ MCP
- Cấu hình chính sách để giới hạn tốc độ và bảo mật
- Kiểm tra máy chủ MCP bằng Visual Studio Code và GitHub Copilot

Ví dụ này minh họa cách tận dụng khả năng của Azure để tạo một máy chủ MCP mạnh mẽ có thể được sử dụng trong nhiều ứng dụng, nâng cao tích hợp các hệ thống AI với API doanh nghiệp.

## Kết Luận

Các nghiên cứu tình huống này làm nổi bật tính linh hoạt và ứng dụng thực tiễn của Model Context Protocol trong các kịch bản thực tế. Từ các hệ thống đa tác nhân phức tạp đến các quy trình tự động hóa mục tiêu, MCP cung cấp một cách tiêu chuẩn hóa để kết nối các hệ thống AI với các công cụ và dữ liệu cần thiết để mang lại giá trị.

Bằng cách nghiên cứu các triển khai này, bạn có thể hiểu rõ hơn về các mẫu kiến trúc, chiến lược triển khai và thực hành tốt nhất có thể áp dụng vào các dự án MCP của riêng bạn. Các ví dụ này chứng minh rằng MCP không chỉ là một khung lý thuyết mà còn là một giải pháp thực tiễn cho các thách thức kinh doanh thực tế.

## Tài Nguyên Bổ Sung

- [Kho Lưu Trữ Azure AI Travel Agents trên GitHub](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Công Cụ MCP Azure DevOps](https://github.com/microsoft/azure-devops-mcp)
- [Công Cụ MCP Playwright](https://github.com/microsoft/playwright-mcp)
- [Máy Chủ MCP Microsoft Docs](https://github.com/MicrosoftDocs/mcp)
- [Ví Dụ Cộng Đồng MCP](https://github.com/microsoft/mcp)

Tiếp theo: Phòng Thí Nghiệm Thực Hành [Tối Ưu Hóa Quy Trình AI: Xây Dựng Máy Chủ MCP với Bộ Công Cụ AI](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**Tuyên bố miễn trừ trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ bản địa nên được coi là nguồn thông tin chính thức. Đối với các thông tin quan trọng, khuyến nghị sử dụng dịch vụ dịch thuật chuyên nghiệp từ con người. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc diễn giải sai nào phát sinh từ việc sử dụng bản dịch này.