<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-05-20T23:41:26+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "vi"
}
-->
# Case Study: Azure AI Travel Agents – Triển Khai Tham Khảo

## Tổng Quan

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) là một giải pháp tham khảo toàn diện do Microsoft phát triển, minh họa cách xây dựng ứng dụng lập kế hoạch du lịch đa tác nhân, được hỗ trợ bởi AI, sử dụng Model Context Protocol (MCP), Azure OpenAI và Azure AI Search. Dự án này trình bày các phương pháp tốt nhất để điều phối nhiều tác nhân AI, tích hợp dữ liệu doanh nghiệp và cung cấp nền tảng an toàn, có thể mở rộng cho các kịch bản thực tế.

## Tính Năng Chính
- **Điều phối Đa Tác Nhân:** Sử dụng MCP để phối hợp các tác nhân chuyên biệt (ví dụ: tác nhân chuyến bay, khách sạn, hành trình) cùng làm việc để hoàn thành các nhiệm vụ lập kế hoạch du lịch phức tạp.
- **Tích hợp Dữ liệu Doanh nghiệp:** Kết nối với Azure AI Search và các nguồn dữ liệu doanh nghiệp khác để cung cấp thông tin cập nhật, phù hợp cho các đề xuất du lịch.
- **Kiến trúc An toàn, Có thể mở rộng:** Tận dụng dịch vụ Azure cho xác thực, phân quyền và triển khai linh hoạt, tuân thủ các thực tiễn bảo mật doanh nghiệp.
- **Công cụ Mở rộng:** Triển khai các công cụ MCP và mẫu prompt có thể tái sử dụng, giúp nhanh chóng thích ứng với các lĩnh vực hoặc yêu cầu kinh doanh mới.
- **Trải nghiệm Người dùng:** Cung cấp giao diện hội thoại để người dùng tương tác với các tác nhân du lịch, được hỗ trợ bởi Azure OpenAI và MCP.

## Kiến Trúc
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Mô Tả Sơ Đồ Kiến Trúc

Giải pháp Azure AI Travel Agents được thiết kế theo hướng mô-đun, có khả năng mở rộng và tích hợp an toàn nhiều tác nhân AI cùng các nguồn dữ liệu doanh nghiệp. Các thành phần chính và luồng dữ liệu như sau:

- **Giao Diện Người Dùng:** Người dùng tương tác với hệ thống qua giao diện hội thoại (ví dụ như chat web hoặc bot Teams), gửi truy vấn và nhận đề xuất du lịch.
- **MCP Server:** Là bộ điều phối trung tâm, nhận đầu vào từ người dùng, quản lý ngữ cảnh và phối hợp hành động của các tác nhân chuyên biệt (ví dụ FlightAgent, HotelAgent, ItineraryAgent) qua Model Context Protocol.
- **Tác Nhân AI:** Mỗi tác nhân chịu trách nhiệm một lĩnh vực cụ thể (chuyến bay, khách sạn, hành trình) và được triển khai như một công cụ MCP. Các tác nhân sử dụng mẫu prompt và logic để xử lý yêu cầu và tạo phản hồi.
- **Dịch vụ Azure OpenAI:** Cung cấp khả năng hiểu và sinh ngôn ngữ tự nhiên nâng cao, giúp các tác nhân hiểu ý định người dùng và tạo phản hồi hội thoại.
- **Azure AI Search & Dữ liệu Doanh nghiệp:** Các tác nhân truy vấn Azure AI Search và các nguồn dữ liệu doanh nghiệp để lấy thông tin cập nhật về chuyến bay, khách sạn và các lựa chọn du lịch.
- **Xác thực & Bảo mật:** Tích hợp với Microsoft Entra ID để xác thực an toàn và áp dụng kiểm soát truy cập theo nguyên tắc ít quyền nhất cho tất cả tài nguyên.
- **Triển khai:** Được thiết kế để triển khai trên Azure Container Apps, đảm bảo khả năng mở rộng, giám sát và vận hành hiệu quả.

Kiến trúc này cho phép điều phối liền mạch nhiều tác nhân AI, tích hợp an toàn với dữ liệu doanh nghiệp và nền tảng mở rộng vững chắc để xây dựng các giải pháp AI theo lĩnh vực cụ thể.

## Giải Thích Từng Bước về Sơ Đồ Kiến Trúc
Hãy tưởng tượng bạn đang lên kế hoạch cho một chuyến đi lớn và có một đội ngũ trợ lý chuyên gia giúp bạn từng chi tiết. Hệ thống Azure AI Travel Agents hoạt động tương tự, sử dụng các bộ phận khác nhau (như các thành viên trong nhóm) mà mỗi người đảm nhận một nhiệm vụ đặc thù. Dưới đây là cách chúng phối hợp với nhau:

### Giao Diện Người Dùng (UI):
Hãy coi đây như quầy lễ tân của đại lý du lịch. Đây là nơi bạn (người dùng) đặt câu hỏi hoặc yêu cầu, ví dụ “Tìm chuyến bay đến Paris cho tôi.” Có thể là cửa sổ chat trên website hoặc ứng dụng nhắn tin.

### MCP Server (Người Điều Phối):
MCP Server giống như người quản lý lắng nghe yêu cầu của bạn tại quầy lễ tân và quyết định chuyên gia nào sẽ xử lý phần việc đó. Nó theo dõi cuộc trò chuyện và đảm bảo mọi thứ diễn ra suôn sẻ.

### Tác Nhân AI (Trợ lý Chuyên Môn):
Mỗi tác nhân là chuyên gia trong lĩnh vực riêng — một người hiểu rõ về chuyến bay, người khác về khách sạn, và một người nữa về lập kế hoạch hành trình. Khi bạn yêu cầu chuyến đi, MCP Server gửi yêu cầu của bạn đến tác nhân phù hợp. Các tác nhân này dùng kiến thức và công cụ của mình để tìm lựa chọn tốt nhất cho bạn.

### Dịch vụ Azure OpenAI (Chuyên Gia Ngôn Ngữ):
Giống như có một chuyên gia ngôn ngữ hiểu chính xác bạn đang hỏi gì, dù bạn diễn đạt thế nào. Nó giúp các tác nhân hiểu yêu cầu và trả lời bằng ngôn ngữ tự nhiên, thân thiện.

### Azure AI Search & Dữ liệu Doanh nghiệp (Thư viện Thông tin):
Hãy tưởng tượng một thư viện khổng lồ, luôn cập nhật thông tin du lịch mới nhất — lịch trình chuyến bay, tình trạng phòng khách sạn, v.v. Các tác nhân tìm kiếm thư viện này để lấy câu trả lời chính xác nhất cho bạn.

### Xác thực & Bảo mật (Bảo vệ An ninh):
Giống như bảo vệ kiểm tra ai được phép vào các khu vực nhất định, phần này đảm bảo chỉ những người và tác nhân được phép mới truy cập thông tin nhạy cảm. Nó giữ dữ liệu của bạn an toàn và riêng tư.

### Triển khai trên Azure Container Apps (Tòa nhà):
Tất cả các trợ lý và công cụ này cùng làm việc trong một tòa nhà an toàn, có thể mở rộng (đám mây). Điều này giúp hệ thống xử lý được nhiều người dùng cùng lúc và luôn sẵn sàng khi bạn cần.

## Cách mọi thứ hoạt động cùng nhau:

Bạn bắt đầu bằng cách đặt câu hỏi tại quầy lễ tân (UI).
Người quản lý (MCP Server) xác định chuyên gia (tác nhân) nào sẽ giúp bạn.
Chuyên gia dùng chuyên gia ngôn ngữ (OpenAI) để hiểu yêu cầu và thư viện (AI Search) để tìm câu trả lời tốt nhất.
Bảo vệ an ninh (Xác thực) đảm bảo mọi thứ an toàn.
Tất cả diễn ra trong một tòa nhà tin cậy, có thể mở rộng (Azure Container Apps), giúp trải nghiệm của bạn mượt mà và an toàn.
Sự phối hợp này cho phép hệ thống nhanh chóng và an toàn giúp bạn lên kế hoạch chuyến đi, giống như một đội ngũ đại lý du lịch chuyên nghiệp làm việc cùng nhau trong một văn phòng hiện đại!

## Triển Khai Kỹ Thuật
- **MCP Server:** Chịu trách nhiệm logic điều phối chính, cung cấp công cụ cho các tác nhân và quản lý ngữ cảnh cho các quy trình lập kế hoạch du lịch đa bước.
- **Các Tác Nhân:** Mỗi tác nhân (ví dụ FlightAgent, HotelAgent) được triển khai như một công cụ MCP với mẫu prompt và logic riêng.
- **Tích hợp Azure:** Sử dụng Azure OpenAI để hiểu ngôn ngữ tự nhiên và Azure AI Search để truy xuất dữ liệu.
- **Bảo mật:** Tích hợp với Microsoft Entra ID để xác thực và áp dụng kiểm soát truy cập theo nguyên tắc ít quyền nhất cho tất cả tài nguyên.
- **Triển khai:** Hỗ trợ triển khai trên Azure Container Apps để đảm bảo khả năng mở rộng và hiệu quả vận hành.

## Kết Quả và Ảnh Hưởng
- Minh họa cách MCP có thể được sử dụng để điều phối nhiều tác nhân AI trong kịch bản thực tế, đạt tiêu chuẩn sản xuất.
- Tăng tốc phát triển giải pháp bằng cách cung cấp các mẫu tái sử dụng cho điều phối tác nhân, tích hợp dữ liệu và triển khai an toàn.
- Là bản thiết kế để xây dựng các ứng dụng AI theo lĩnh vực cụ thể, được hỗ trợ bởi MCP và dịch vụ Azure.

## Tài Liệu Tham Khảo
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ nguyên bản nên được coi là nguồn chính thức. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp của con người. Chúng tôi không chịu trách nhiệm đối với bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.