<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b6b1bc868efed4cf02c52f8deada559d",
  "translation_date": "2025-05-17T17:31:36+00:00",
  "source_file": "09-CaseStudy/Readme.md",
  "language_code": "vi"
}
-->
# Nghiên Cứu Tình Huống: Azure AI Travel Agents – Triển Khai Tham Chiếu

## Tổng Quan

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) là một giải pháp tham chiếu toàn diện do Microsoft phát triển, minh họa cách xây dựng một ứng dụng lập kế hoạch du lịch đa tác nhân, sử dụng trí tuệ nhân tạo với Model Context Protocol (MCP), Azure OpenAI, và Azure AI Search. Dự án này trình bày các thực hành tốt nhất cho việc điều phối nhiều tác nhân AI, tích hợp dữ liệu doanh nghiệp, và cung cấp một nền tảng an toàn, có thể mở rộng cho các kịch bản thực tế.

## Các Tính Năng Chính
- **Điều Phối Đa Tác Nhân:** Sử dụng MCP để điều phối các tác nhân chuyên biệt (ví dụ: tác nhân chuyến bay, khách sạn, và hành trình) cùng hợp tác để hoàn thành các nhiệm vụ lập kế hoạch du lịch phức tạp.
- **Tích Hợp Dữ Liệu Doanh Nghiệp:** Kết nối với Azure AI Search và các nguồn dữ liệu doanh nghiệp khác để cung cấp thông tin cập nhật, liên quan cho các đề xuất du lịch.
- **Kiến Trúc An Toàn, Có Thể Mở Rộng:** Tận dụng các dịch vụ Azure cho xác thực, ủy quyền, và triển khai có thể mở rộng, tuân theo các thực hành bảo mật doanh nghiệp tốt nhất.
- **Công Cụ Có Thể Mở Rộng:** Triển khai các công cụ MCP tái sử dụng và các mẫu nhắc nhở, cho phép thích ứng nhanh chóng với các lĩnh vực mới hoặc yêu cầu kinh doanh.
- **Trải Nghiệm Người Dùng:** Cung cấp giao diện hội thoại cho người dùng tương tác với các tác nhân du lịch, được hỗ trợ bởi Azure OpenAI và MCP.

## Kiến Trúc
![Kiến Trúc](https://github.com/Azure-Samples/azure-ai-travel-agents/blob/main/docs/ai-travel-agents-architecture-diagram.png)

### Mô Tả Sơ Đồ Kiến Trúc

Giải pháp Azure AI Travel Agents được kiến trúc để tạo tính mô đun, có thể mở rộng, và tích hợp an toàn của nhiều tác nhân AI và các nguồn dữ liệu doanh nghiệp. Các thành phần chính và luồng dữ liệu như sau:

- **Giao Diện Người Dùng:** Người dùng tương tác với hệ thống thông qua giao diện hội thoại (như trò chuyện web hoặc bot Teams), gửi các truy vấn người dùng và nhận các đề xuất du lịch.
- **Máy Chủ MCP:** Hoạt động như người điều phối trung tâm, nhận đầu vào của người dùng, quản lý ngữ cảnh, và điều phối các hành động của các tác nhân chuyên biệt (ví dụ: FlightAgent, HotelAgent, ItineraryAgent) thông qua Model Context Protocol.
- **Tác Nhân AI:** Mỗi tác nhân chịu trách nhiệm về một lĩnh vực cụ thể (chuyến bay, khách sạn, hành trình) và được triển khai như một công cụ MCP. Các tác nhân sử dụng các mẫu nhắc nhở và logic để xử lý yêu cầu và tạo ra phản hồi.
- **Dịch Vụ Azure OpenAI:** Cung cấp khả năng hiểu và tạo ngôn ngữ tự nhiên tiên tiến, cho phép các tác nhân diễn giải ý định của người dùng và tạo phản hồi hội thoại.
- **Azure AI Search & Dữ Liệu Doanh Nghiệp:** Các tác nhân truy vấn Azure AI Search và các nguồn dữ liệu doanh nghiệp khác để truy xuất thông tin cập nhật về chuyến bay, khách sạn, và các tùy chọn du lịch.
- **Xác Thực & Bảo Mật:** Tích hợp với Microsoft Entra ID để xác thực an toàn và áp dụng các điều khiển truy cập với quyền tối thiểu cho tất cả tài nguyên.
- **Triển Khai:** Được thiết kế để triển khai trên Azure Container Apps, đảm bảo khả năng mở rộng, giám sát, và hiệu quả hoạt động.

Kiến trúc này cho phép điều phối liền mạch của nhiều tác nhân AI, tích hợp an toàn với dữ liệu doanh nghiệp, và một nền tảng mạnh mẽ, có thể mở rộng cho việc xây dựng các giải pháp AI chuyên ngành.

## Giải Thích Từng Bước Về Sơ Đồ Kiến Trúc
Hãy tưởng tượng việc lên kế hoạch cho một chuyến đi lớn và có một đội ngũ trợ lý chuyên gia giúp bạn với mọi chi tiết. Hệ thống Azure AI Travel Agents hoạt động theo cách tương tự, sử dụng các phần khác nhau (như các thành viên trong nhóm) mà mỗi phần có một công việc đặc biệt. Đây là cách tất cả khớp lại với nhau:

### Giao Diện Người Dùng (UI):
Hãy nghĩ về điều này như bàn tiếp tân của đại lý du lịch của bạn. Đây là nơi bạn (người dùng) đặt câu hỏi hoặc đưa ra yêu cầu, như "Tìm cho tôi một chuyến bay đến Paris." Điều này có thể là một cửa sổ trò chuyện trên trang web hoặc ứng dụng nhắn tin.

### Máy Chủ MCP (Người Điều Phối):
Máy Chủ MCP giống như người quản lý lắng nghe yêu cầu của bạn tại bàn tiếp tân và quyết định chuyên gia nào nên xử lý từng phần. Nó theo dõi cuộc trò chuyện của bạn và đảm bảo mọi thứ diễn ra suôn sẻ.

### Tác Nhân AI (Trợ Lý Chuyên Gia):
Mỗi tác nhân là một chuyên gia trong một lĩnh vực cụ thể—một người biết tất cả về chuyến bay, một người khác về khách sạn, và một người khác về lập kế hoạch hành trình của bạn. Khi bạn yêu cầu một chuyến đi, Máy Chủ MCP gửi yêu cầu của bạn đến đúng tác nhân. Các tác nhân này sử dụng kiến thức và công cụ của họ để tìm ra lựa chọn tốt nhất cho bạn.

### Dịch Vụ Azure OpenAI (Chuyên Gia Ngôn Ngữ):
Đây giống như có một chuyên gia ngôn ngữ hiểu chính xác những gì bạn đang yêu cầu, bất kể bạn diễn đạt như thế nào. Nó giúp các tác nhân hiểu yêu cầu của bạn và trả lời bằng ngôn ngữ hội thoại tự nhiên.

### Azure AI Search & Dữ Liệu Doanh Nghiệp (Thư Viện Thông Tin):
Hãy tưởng tượng một thư viện lớn, cập nhật với tất cả thông tin du lịch mới nhất—lịch trình chuyến bay, khả năng khách sạn, và nhiều hơn nữa. Các tác nhân tìm kiếm trong thư viện này để có câu trả lời chính xác nhất cho bạn.

### Xác Thực & Bảo Mật (Nhân Viên Bảo Vệ):
Giống như một nhân viên bảo vệ kiểm tra ai có thể vào các khu vực nhất định, phần này đảm bảo chỉ những người và tác nhân được ủy quyền mới có thể truy cập thông tin nhạy cảm. Nó giữ dữ liệu của bạn an toàn và riêng tư.

### Triển Khai trên Azure Container Apps (Tòa Nhà):
Tất cả các trợ lý và công cụ này hoạt động cùng nhau bên trong một tòa nhà an toàn, có thể mở rộng (đám mây). Điều này có nghĩa là hệ thống có thể xử lý nhiều người dùng cùng một lúc và luôn sẵn sàng khi bạn cần.

## Cách Tất Cả Hoạt Động Cùng Nhau:

Bạn bắt đầu bằng cách đặt câu hỏi tại bàn tiếp tân (UI).
Người quản lý (MCP Server) tìm ra chuyên gia nào (tác nhân) nên giúp bạn.
Chuyên gia sử dụng chuyên gia ngôn ngữ (OpenAI) để hiểu yêu cầu của bạn và thư viện (AI Search) để tìm câu trả lời tốt nhất.
Nhân viên bảo vệ (Xác Thực) đảm bảo mọi thứ an toàn.
Tất cả điều này xảy ra bên trong một tòa nhà đáng tin cậy, có thể mở rộng (Azure Container Apps), vì vậy trải nghiệm của bạn mượt mà và an toàn.
Sự hợp tác này cho phép hệ thống nhanh chóng và an toàn giúp bạn lập kế hoạch chuyến đi của mình, giống như một đội ngũ các đại lý du lịch chuyên nghiệp làm việc cùng nhau trong một văn phòng hiện đại!

## Triển Khai Kỹ Thuật
- **Máy Chủ MCP:** Lưu trữ logic điều phối cốt lõi, cung cấp các công cụ tác nhân, và quản lý ngữ cảnh cho các quy trình lập kế hoạch du lịch nhiều bước.
- **Tác Nhân:** Mỗi tác nhân (ví dụ: FlightAgent, HotelAgent) được triển khai như một công cụ MCP với các mẫu nhắc nhở và logic riêng.
- **Tích Hợp Azure:** Sử dụng Azure OpenAI để hiểu ngôn ngữ tự nhiên và Azure AI Search để truy xuất dữ liệu.
- **Bảo Mật:** Tích hợp với Microsoft Entra ID để xác thực và áp dụng các điều khiển truy cập với quyền tối thiểu cho tất cả tài nguyên.
- **Triển Khai:** Hỗ trợ triển khai lên Azure Container Apps để đảm bảo khả năng mở rộng và hiệu quả hoạt động.

## Kết Quả và Tác Động
- Minh họa cách MCP có thể được sử dụng để điều phối nhiều tác nhân AI trong một kịch bản thực tế, cấp sản xuất.
- Tăng tốc phát triển giải pháp bằng cách cung cấp các mẫu tái sử dụng cho điều phối tác nhân, tích hợp dữ liệu, và triển khai an toàn.
- Phục vụ như một bản thiết kế cho việc xây dựng các ứng dụng AI chuyên ngành, sử dụng MCP và các dịch vụ Azure.

## Tham Khảo
- [Kho Lưu Trữ GitHub Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Dịch Vụ Azure OpenAI](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Tuyên bố miễn trừ trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc sự không chính xác. Tài liệu gốc bằng ngôn ngữ bản địa nên được coi là nguồn đáng tin cậy. Đối với thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp từ con người. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc diễn giải sai nào phát sinh từ việc sử dụng bản dịch này.