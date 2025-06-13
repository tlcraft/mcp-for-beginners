<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-06-13T21:50:36+00:00",
  "source_file": "09-CaseStudy/travelagentsample.md",
  "language_code": "vi"
}
-->
# Nghiên cứu trường hợp: Azure AI Travel Agents – Triển khai tham khảo

## Tổng quan

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) là một giải pháp tham khảo toàn diện do Microsoft phát triển, minh họa cách xây dựng ứng dụng lập kế hoạch du lịch đa tác nhân, được hỗ trợ bởi AI, sử dụng Model Context Protocol (MCP), Azure OpenAI và Azure AI Search. Dự án này trình bày các thực tiễn tốt nhất để điều phối nhiều tác nhân AI, tích hợp dữ liệu doanh nghiệp và cung cấp nền tảng bảo mật, mở rộng cho các kịch bản thực tế.

## Các tính năng chính
- **Điều phối đa tác nhân:** Sử dụng MCP để phối hợp các tác nhân chuyên biệt (ví dụ: tác nhân chuyến bay, khách sạn và hành trình) hợp tác thực hiện các nhiệm vụ lập kế hoạch du lịch phức tạp.
- **Tích hợp dữ liệu doanh nghiệp:** Kết nối với Azure AI Search và các nguồn dữ liệu doanh nghiệp khác để cung cấp thông tin cập nhật, phù hợp cho các đề xuất du lịch.
- **Kiến trúc bảo mật, có khả năng mở rộng:** Tận dụng các dịch vụ Azure cho xác thực, ủy quyền và triển khai mở rộng, tuân thủ các thực tiễn bảo mật doanh nghiệp.
- **Công cụ mở rộng:** Triển khai các công cụ MCP tái sử dụng và mẫu prompt, cho phép thích nghi nhanh với các lĩnh vực hoặc yêu cầu kinh doanh mới.
- **Trải nghiệm người dùng:** Cung cấp giao diện hội thoại để người dùng tương tác với các tác nhân du lịch, được hỗ trợ bởi Azure OpenAI và MCP.

## Kiến trúc
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Mô tả sơ đồ kiến trúc

Giải pháp Azure AI Travel Agents được thiết kế để có tính mô-đun, khả năng mở rộng và tích hợp bảo mật nhiều tác nhân AI cùng các nguồn dữ liệu doanh nghiệp. Các thành phần chính và luồng dữ liệu như sau:

- **Giao diện người dùng:** Người dùng tương tác với hệ thống qua giao diện hội thoại (chẳng hạn như chat web hoặc bot Teams), gửi truy vấn và nhận đề xuất du lịch.
- **MCP Server:** Đóng vai trò điều phối trung tâm, nhận dữ liệu đầu vào từ người dùng, quản lý ngữ cảnh và điều phối hành động của các tác nhân chuyên biệt (ví dụ FlightAgent, HotelAgent, ItineraryAgent) qua Model Context Protocol.
- **Các tác nhân AI:** Mỗi tác nhân chịu trách nhiệm một lĩnh vực cụ thể (chuyến bay, khách sạn, hành trình) và được triển khai dưới dạng công cụ MCP. Các tác nhân sử dụng mẫu prompt và logic để xử lý yêu cầu và tạo phản hồi.
- **Dịch vụ Azure OpenAI:** Cung cấp khả năng hiểu và tạo ngôn ngữ tự nhiên nâng cao, giúp các tác nhân giải mã ý định người dùng và tạo phản hồi hội thoại.
- **Azure AI Search & dữ liệu doanh nghiệp:** Các tác nhân truy vấn Azure AI Search và các nguồn dữ liệu doanh nghiệp khác để lấy thông tin cập nhật về chuyến bay, khách sạn và lựa chọn du lịch.
- **Xác thực & bảo mật:** Tích hợp với Microsoft Entra ID để xác thực an toàn và áp dụng kiểm soát truy cập theo nguyên tắc quyền tối thiểu cho tất cả tài nguyên.
- **Triển khai:** Thiết kế để triển khai trên Azure Container Apps, đảm bảo khả năng mở rộng, giám sát và vận hành hiệu quả.

Kiến trúc này cho phép điều phối liền mạch nhiều tác nhân AI, tích hợp bảo mật với dữ liệu doanh nghiệp và nền tảng mạnh mẽ, mở rộng để xây dựng các giải pháp AI chuyên ngành.

## Giải thích từng bước sơ đồ kiến trúc
Hãy tưởng tượng bạn đang lên kế hoạch cho một chuyến đi lớn và có một đội ngũ trợ lý chuyên gia giúp bạn từng chi tiết. Hệ thống Azure AI Travel Agents hoạt động tương tự, sử dụng các phần khác nhau (như các thành viên trong đội) mỗi phần đảm nhận một nhiệm vụ riêng. Dưới đây là cách mọi thứ phối hợp:

### Giao diện người dùng (UI):
Hãy coi đây là quầy tiếp tân của đại lý du lịch. Đây là nơi bạn (người dùng) đặt câu hỏi hoặc yêu cầu, ví dụ như “Tìm cho tôi chuyến bay đến Paris.” Đây có thể là cửa sổ chat trên website hoặc ứng dụng nhắn tin.

### MCP Server (Người điều phối):
MCP Server giống như người quản lý nghe yêu cầu của bạn tại quầy tiếp tân và quyết định chuyên gia nào sẽ xử lý từng phần. Nó theo dõi cuộc hội thoại của bạn và đảm bảo mọi việc diễn ra trơn tru.

### Các tác nhân AI (Trợ lý chuyên môn):
Mỗi tác nhân là chuyên gia trong một lĩnh vực cụ thể—một người biết tất cả về chuyến bay, một người khác về khách sạn, và một người nữa về lập kế hoạch hành trình. Khi bạn yêu cầu chuyến đi, MCP Server gửi yêu cầu đến tác nhân phù hợp. Các tác nhân này sử dụng kiến thức và công cụ của mình để tìm lựa chọn tốt nhất cho bạn.

### Dịch vụ Azure OpenAI (Chuyên gia ngôn ngữ):
Giống như có một chuyên gia ngôn ngữ hiểu chính xác bạn đang hỏi gì, dù bạn diễn đạt thế nào. Nó giúp các tác nhân hiểu yêu cầu và trả lời bằng ngôn ngữ tự nhiên, thân thiện.

### Azure AI Search & dữ liệu doanh nghiệp (Thư viện thông tin):
Hãy tưởng tượng một thư viện lớn, luôn cập nhật với tất cả thông tin du lịch mới nhất—lịch trình chuyến bay, tình trạng phòng khách sạn, và nhiều hơn nữa. Các tác nhân tìm kiếm thư viện này để lấy câu trả lời chính xác nhất cho bạn.

### Xác thực & bảo mật (Bảo vệ an ninh):
Giống như bảo vệ an ninh kiểm tra ai được phép vào các khu vực nhất định, phần này đảm bảo chỉ những người và tác nhân được ủy quyền mới truy cập thông tin nhạy cảm. Nó giữ an toàn và bảo mật dữ liệu của bạn.

### Triển khai trên Azure Container Apps (Toà nhà):
Tất cả trợ lý và công cụ này hoạt động bên trong một tòa nhà an toàn, có thể mở rộng (đám mây). Điều này có nghĩa là hệ thống có thể phục vụ nhiều người dùng cùng lúc và luôn sẵn sàng khi bạn cần.

## Cách mọi thứ phối hợp hoạt động:

Bạn bắt đầu bằng cách đặt câu hỏi tại quầy tiếp tân (UI).
Người quản lý (MCP Server) xác định chuyên gia (tác nhân) phù hợp để giúp bạn.
Chuyên gia dùng chuyên gia ngôn ngữ (OpenAI) để hiểu yêu cầu và thư viện thông tin (AI Search) để tìm câu trả lời tốt nhất.
Bảo vệ an ninh (Xác thực) đảm bảo mọi thứ an toàn.
Tất cả diễn ra trong một tòa nhà đáng tin cậy, có khả năng mở rộng (Azure Container Apps), giúp trải nghiệm của bạn mượt mà và an toàn.
Sự phối hợp này giúp hệ thống nhanh chóng và an toàn hỗ trợ bạn lên kế hoạch chuyến đi, như một đội ngũ đại lý du lịch chuyên nghiệp làm việc cùng nhau trong một văn phòng hiện đại!

## Triển khai kỹ thuật
- **MCP Server:** Chứa logic điều phối cốt lõi, cung cấp các công cụ tác nhân và quản lý ngữ cảnh cho các quy trình lập kế hoạch du lịch đa bước.
- **Các tác nhân:** Mỗi tác nhân (ví dụ FlightAgent, HotelAgent) được triển khai như một công cụ MCP với mẫu prompt và logic riêng.
- **Tích hợp Azure:** Sử dụng Azure OpenAI để hiểu ngôn ngữ tự nhiên và Azure AI Search để truy xuất dữ liệu.
- **Bảo mật:** Tích hợp với Microsoft Entra ID cho xác thực và áp dụng kiểm soát truy cập theo nguyên tắc quyền tối thiểu cho tất cả tài nguyên.
- **Triển khai:** Hỗ trợ triển khai trên Azure Container Apps để đảm bảo khả năng mở rộng và hiệu quả vận hành.

## Kết quả và tác động
- Minh họa cách MCP được sử dụng để điều phối nhiều tác nhân AI trong kịch bản thực tế, đạt chuẩn sản xuất.
- Thúc đẩy phát triển giải pháp nhanh chóng bằng cách cung cấp các mẫu phối hợp tác nhân, tích hợp dữ liệu và triển khai bảo mật có thể tái sử dụng.
- Là bản thiết kế để xây dựng các ứng dụng AI chuyên ngành dựa trên MCP và dịch vụ Azure.

## Tham khảo
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ bản địa nên được coi là nguồn thông tin chính thức. Đối với các thông tin quan trọng, nên sử dụng dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.