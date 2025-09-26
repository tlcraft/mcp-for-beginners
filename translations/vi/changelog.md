<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "704c94da1dde019de2d8eb1d671f418f",
  "translation_date": "2025-09-26T18:43:35+00:00",
  "source_file": "changelog.md",
  "language_code": "vi"
}
-->
# Changelog: MCP cho Người Mới Bắt Đầu

Tài liệu này là bản ghi lại tất cả các thay đổi quan trọng được thực hiện đối với chương trình học Model Context Protocol (MCP) dành cho người mới bắt đầu. Các thay đổi được ghi lại theo thứ tự thời gian đảo ngược (thay đổi mới nhất trước).

## Ngày 26 tháng 9 năm 2025

### Nâng cấp Nghiên cứu Tình huống - Tích hợp GitHub MCP Registry

#### Nghiên cứu Tình huống (09-CaseStudy/) - Tập trung vào Phát triển Hệ sinh thái
- **README.md**: Mở rộng lớn với nghiên cứu tình huống toàn diện về GitHub MCP Registry
  - **Nghiên cứu Tình huống GitHub MCP Registry**: Nghiên cứu mới phân tích việc ra mắt GitHub MCP Registry vào tháng 9 năm 2025
    - **Phân tích Vấn đề**: Xem xét chi tiết các thách thức trong việc tìm kiếm và triển khai máy chủ MCP bị phân mảnh
    - **Kiến trúc Giải pháp**: Cách tiếp cận registry tập trung của GitHub với cài đặt VS Code chỉ bằng một cú nhấp chuột
    - **Tác động Kinh doanh**: Cải thiện đáng kể việc giới thiệu và năng suất của nhà phát triển
    - **Giá trị Chiến lược**: Tập trung vào triển khai tác nhân mô-đun và khả năng tương tác giữa các công cụ
    - **Phát triển Hệ sinh thái**: Định vị như một nền tảng cơ bản cho tích hợp tác nhân
  - **Cấu trúc Nghiên cứu Tình huống Nâng cao**: Cập nhật tất cả bảy nghiên cứu tình huống với định dạng nhất quán và mô tả toàn diện
    - Azure AI Travel Agents: Nhấn mạnh vào điều phối đa tác nhân
    - Tích hợp Azure DevOps: Tập trung vào tự động hóa quy trình làm việc
    - Truy xuất Tài liệu Thời gian Thực: Triển khai client console Python
    - Trình tạo Kế hoạch Học tập Tương tác: Ứng dụng web Chainlit hội thoại
    - Tài liệu Trong Trình Soạn Thảo: Tích hợp VS Code và GitHub Copilot
    - Quản lý API Azure: Mẫu tích hợp API doanh nghiệp
    - GitHub MCP Registry: Phát triển hệ sinh thái và nền tảng cộng đồng
  - **Kết luận Toàn diện**: Viết lại phần kết luận nhấn mạnh bảy nghiên cứu tình huống trải rộng trên nhiều khía cạnh triển khai MCP
    - Tích hợp Doanh nghiệp, Điều phối Đa Tác nhân, Năng suất Nhà phát triển
    - Phát triển Hệ sinh thái, Ứng dụng Giáo dục
    - Cung cấp thông tin chi tiết nâng cao về mẫu kiến trúc, chiến lược triển khai và thực tiễn tốt nhất
    - Nhấn mạnh MCP như một giao thức trưởng thành, sẵn sàng sản xuất

#### Cập nhật Hướng dẫn Học tập (study_guide.md)
- **Bản đồ Chương trình Học tập Trực quan**: Cập nhật sơ đồ tư duy để bao gồm GitHub MCP Registry trong phần Nghiên cứu Tình huống
- **Mô tả Nghiên cứu Tình huống**: Nâng cấp từ mô tả chung thành phân tích chi tiết bảy nghiên cứu tình huống toàn diện
- **Cấu trúc Kho Lưu trữ**: Cập nhật phần 10 để phản ánh phạm vi nghiên cứu tình huống toàn diện với chi tiết triển khai cụ thể
- **Tích hợp Changelog**: Thêm mục ngày 26 tháng 9 năm 2025 ghi lại việc bổ sung GitHub MCP Registry và nâng cấp nghiên cứu tình huống
- **Cập nhật Ngày**: Cập nhật dấu thời gian ở chân trang để phản ánh lần sửa đổi mới nhất (ngày 26 tháng 9 năm 2025)

### Cải thiện Chất lượng Tài liệu
- **Nâng cao Tính Nhất quán**: Chuẩn hóa định dạng và cấu trúc nghiên cứu tình huống trên tất cả bảy ví dụ
- **Phạm vi Toàn diện**: Các nghiên cứu tình huống hiện bao gồm các kịch bản doanh nghiệp, năng suất nhà phát triển và phát triển hệ sinh thái
- **Định vị Chiến lược**: Tăng cường tập trung vào MCP như một nền tảng cơ bản cho triển khai hệ thống tác nhân
- **Tích hợp Tài nguyên**: Cập nhật tài nguyên bổ sung để bao gồm liên kết GitHub MCP Registry

## Ngày 15 tháng 9 năm 2025

### Mở rộng Chủ đề Nâng cao - Giao vận Tùy chỉnh & Kỹ thuật Ngữ cảnh

#### MCP Custom Transports (05-AdvancedTopics/mcp-transport/) - Hướng dẫn Triển khai Nâng cao Mới
- **README.md**: Hướng dẫn triển khai đầy đủ cho các cơ chế giao vận MCP tùy chỉnh
  - **Azure Event Grid Transport**: Triển khai giao vận không máy chủ theo sự kiện toàn diện
    - Ví dụ bằng C#, TypeScript và Python với tích hợp Azure Functions
    - Mẫu kiến trúc theo sự kiện cho các giải pháp MCP có khả năng mở rộng
    - Bộ nhận webhook và xử lý tin nhắn dựa trên đẩy
  - **Azure Event Hubs Transport**: Triển khai giao vận streaming thông lượng cao
    - Khả năng streaming thời gian thực cho các kịch bản độ trễ thấp
    - Chiến lược phân vùng và quản lý điểm kiểm tra
    - Gộp tin nhắn và tối ưu hóa hiệu suất
  - **Mẫu Tích hợp Doanh nghiệp**: Ví dụ kiến trúc sẵn sàng sản xuất
    - Xử lý MCP phân tán trên nhiều Azure Functions
    - Kiến trúc giao vận lai kết hợp nhiều loại giao vận
    - Chiến lược độ bền tin nhắn, độ tin cậy và xử lý lỗi
  - **Bảo mật & Giám sát**: Tích hợp Azure Key Vault và mẫu quan sát
    - Xác thực danh tính được quản lý và truy cập tối thiểu
    - Telemetry của Application Insights và giám sát hiệu suất
    - Bộ ngắt mạch và mẫu chịu lỗi
  - **Khung Kiểm tra**: Chiến lược kiểm tra toàn diện cho giao vận tùy chỉnh
    - Kiểm tra đơn vị với test doubles và khung giả lập
    - Kiểm tra tích hợp với Azure Test Containers
    - Cân nhắc kiểm tra hiệu suất và tải

#### Kỹ thuật Ngữ cảnh (05-AdvancedTopics/mcp-contextengineering/) - Lĩnh vực AI Mới Nổi
- **README.md**: Khám phá toàn diện về kỹ thuật ngữ cảnh như một lĩnh vực mới nổi
  - **Nguyên tắc Cốt lõi**: Chia sẻ ngữ cảnh hoàn chỉnh, nhận thức quyết định hành động và quản lý cửa sổ ngữ cảnh
  - **Sự phù hợp với Giao thức MCP**: Cách thiết kế MCP giải quyết các thách thức kỹ thuật ngữ cảnh
    - Giới hạn cửa sổ ngữ cảnh và chiến lược tải tiến bộ
    - Xác định mức độ liên quan và truy xuất ngữ cảnh động
    - Xử lý ngữ cảnh đa phương thức và cân nhắc bảo mật
  - **Cách Tiếp cận Triển khai**: Kiến trúc đơn luồng so với đa tác nhân
    - Kỹ thuật chia nhỏ ngữ cảnh và ưu tiên
    - Tải ngữ cảnh tiến bộ và chiến lược nén
    - Cách tiếp cận ngữ cảnh phân lớp và tối ưu hóa truy xuất
  - **Khung Đo lường**: Các chỉ số mới nổi để đánh giá hiệu quả ngữ cảnh
    - Hiệu quả đầu vào, hiệu suất, chất lượng và cân nhắc trải nghiệm người dùng
    - Cách tiếp cận thử nghiệm để tối ưu hóa ngữ cảnh
    - Phân tích lỗi và phương pháp cải tiến

#### Cập nhật Điều hướng Chương trình Học tập (README.md)
- **Cấu trúc Module Nâng cao**: Cập nhật bảng chương trình học để bao gồm các chủ đề nâng cao mới
  - Thêm Kỹ thuật Ngữ cảnh (5.14) và Giao vận Tùy chỉnh (5.15)
  - Định dạng nhất quán và liên kết điều hướng trên tất cả các module
  - Cập nhật mô tả để phản ánh phạm vi nội dung hiện tại

### Cải thiện Cấu trúc Thư mục
- **Chuẩn hóa Tên**: Đổi tên "mcp transport" thành "mcp-transport" để nhất quán với các thư mục chủ đề nâng cao khác
- **Tổ chức Nội dung**: Tất cả các thư mục 05-AdvancedTopics hiện tuân theo mẫu đặt tên nhất quán (mcp-[chủ đề])

### Cải thiện Chất lượng Tài liệu
- **Phù hợp với Đặc tả MCP**: Tất cả nội dung mới tham chiếu đến Đặc tả MCP hiện tại 2025-06-18
- **Ví dụ Đa Ngôn ngữ**: Ví dụ mã toàn diện bằng C#, TypeScript và Python
- **Tập trung vào Doanh nghiệp**: Mẫu sẵn sàng sản xuất và tích hợp đám mây Azure xuyên suốt
- **Tài liệu Trực quan**: Sơ đồ Mermaid cho hình dung kiến trúc và luồng

## Ngày 18 tháng 8 năm 2025

### Cập nhật Tài liệu Toàn diện - Tiêu chuẩn MCP 2025-06-18

#### Thực tiễn Bảo mật MCP (02-Security/) - Hiện đại hóa Hoàn toàn
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Viết lại hoàn toàn phù hợp với Đặc tả MCP 2025-06-18
  - **Yêu cầu Bắt buộc**: Thêm các yêu cầu MUST/MUST NOT rõ ràng từ đặc tả chính thức với chỉ báo trực quan rõ ràng
  - **12 Thực tiễn Bảo mật Cốt lõi**: Cấu trúc lại từ danh sách 15 mục thành các lĩnh vực bảo mật toàn diện
    - Bảo mật Token & Xác thực với tích hợp nhà cung cấp danh tính bên ngoài
    - Quản lý Phiên & Bảo mật Giao vận với yêu cầu mã hóa
    - Bảo vệ Mối đe dọa Cụ thể AI với tích hợp Microsoft Prompt Shields
    - Kiểm soát Truy cập & Quyền với nguyên tắc tối thiểu
    - An toàn Nội dung & Giám sát với tích hợp Azure Content Safety
    - Bảo mật Chuỗi Cung ứng với xác minh thành phần toàn diện
    - Bảo mật OAuth & Phòng ngừa Tấn công Confused Deputy với triển khai PKCE
    - Phản hồi & Khôi phục Sự cố với khả năng tự động hóa
    - Tuân thủ & Quản trị với sự phù hợp quy định
    - Kiểm soát Bảo mật Nâng cao với kiến trúc zero trust
    - Tích hợp Hệ sinh thái Bảo mật Microsoft với các giải pháp toàn diện
    - Tiến hóa Bảo mật Liên tục với thực tiễn thích ứng
  - **Giải pháp Bảo mật Microsoft**: Hướng dẫn tích hợp nâng cao cho Prompt Shields, Azure Content Safety, Entra ID và GitHub Advanced Security
  - **Tài nguyên Triển khai**: Liên kết tài nguyên toàn diện được phân loại theo Tài liệu MCP Chính thức, Giải pháp Bảo mật Microsoft, Tiêu chuẩn Bảo mật và Hướng dẫn Triển khai

#### Kiểm soát Bảo mật Nâng cao (02-Security/) - Triển khai Doanh nghiệp
- **MCP-SECURITY-CONTROLS-2025.md**: Đại tu hoàn toàn với khung bảo mật cấp doanh nghiệp
  - **9 Lĩnh vực Bảo mật Toàn diện**: Mở rộng từ các kiểm soát cơ bản thành khung doanh nghiệp chi tiết
    - Xác thực & Ủy quyền Nâng cao với tích hợp Microsoft Entra ID
    - Bảo mật Token & Kiểm soát Chống Chuyển Tiếp với xác thực toàn diện
    - Kiểm soát Bảo mật Phiên với phòng ngừa chiếm đoạt
    - Kiểm soát Bảo mật Cụ thể AI với phòng ngừa tiêm prompt và đầu độc công cụ
    - Phòng ngừa Tấn công Confused Deputy với bảo mật proxy OAuth
    - Bảo mật Thực thi Công cụ với sandboxing và cô lập
    - Kiểm soát Bảo mật Chuỗi Cung ứng với xác minh phụ thuộc
    - Kiểm soát Giám sát & Phát hiện với tích hợp SIEM
    - Phản hồi & Khôi phục Sự cố với khả năng tự động hóa
  - **Ví dụ Triển khai**: Thêm các khối cấu hình YAML chi tiết và ví dụ mã
  - **Tích hợp Giải pháp Microsoft**: Phạm vi toàn diện về dịch vụ bảo mật Azure, GitHub Advanced Security và quản lý danh tính doanh nghiệp

#### Chủ đề Nâng cao Bảo mật (05-AdvancedTopics/mcp-security/) - Triển khai Sẵn sàng Sản xuất
- **README.md**: Viết lại hoàn toàn cho triển khai bảo mật doanh nghiệp
  - **Phù hợp với Đặc tả Hiện tại**: Cập nhật theo Đặc tả MCP 2025-06-18 với các yêu cầu bảo mật bắt buộc
  - **Xác thực Nâng cao**: Tích hợp Microsoft Entra ID với ví dụ toàn diện .NET và Java Spring Security
  - **Tích hợp Bảo mật AI**: Triển khai Microsoft Prompt Shields và Azure Content Safety với ví dụ Python chi tiết
  - **Giảm thiểu Mối đe dọa Nâng cao**: Ví dụ triển khai toàn diện cho
    - Phòng ngừa Tấn công Confused Deputy với PKCE và xác thực sự đồng ý của người dùng
    - Phòng ngừa Chuyển Tiếp Token với xác thực đối tượng và quản lý token an toàn
    - Phòng ngừa Chiếm đoạt Phiên với liên kết mã hóa và phân tích hành vi
  - **Tích hợp Bảo mật Doanh nghiệp**: Giám sát Application Insights của Azure, pipeline phát hiện mối đe dọa và bảo mật chuỗi cung ứng
  - **Danh sách Kiểm tra Triển khai**: Kiểm soát bảo mật bắt buộc và khuyến nghị rõ ràng với lợi ích hệ sinh thái bảo mật Microsoft

### Cải thiện Chất lượng Tài liệu & Phù hợp Tiêu chuẩn
- **Tham chiếu Đặc tả**: Cập nhật tất cả các tham chiếu đến tiêu chuẩn MCP hiện tại 2025-06-18
- **Hệ sinh thái Bảo mật Microsoft**: Hướng dẫn tích hợp nâng cao xuyên suốt tất cả tài liệu bảo mật
- **Hướng dẫn Triển khai Thực tiễn**: Thêm ví dụ mã chi tiết trong .NET, Java và Python với mẫu doanh nghiệp
- **Tổ chức Tài nguyên**: Phân loại toàn diện tài liệu chính thức, tiêu chuẩn bảo mật và hướng dẫn triển khai
- **Chỉ báo Trực quan**: Đánh dấu rõ ràng các yêu cầu bắt buộc so với thực tiễn khuyến nghị

#### Khái niệm Cốt lõi (01-CoreConcepts/) - Hiện đại hóa Hoàn toàn
- **Cập nhật Phiên bản Giao thức**: Cập nhật để tham chiếu tiêu chuẩn MCP hiện tại 2025-06-18 với định dạng phiên bản theo ngày (YYYY-MM-DD)
- **Tinh chỉnh Kiến trúc**: Mô tả nâng cao về Hosts, Clients và Servers để phản ánh mẫu kiến trúc MCP hiện tại
  - Hosts hiện được định nghĩa rõ ràng là các ứng dụng AI điều phối nhiều kết nối client MCP
  - Clients được mô tả là các trình kết nối giao thức duy trì mối quan hệ một-một với server
  - Servers được nâng cấp với các kịch bản triển khai cục bộ so với từ xa
- **Cấu trúc Lại Nguyên thủy**: Đại tu hoàn toàn các nguyên thủy server và client
  - Nguyên thủy Server: Resources (nguồn dữ liệu), Prompts (mẫu), Tools (chức năng có thể thực thi) với giải thích và ví dụ chi tiết
  - Nguyên thủy Client: Sampling (hoàn thành LLM), Elicitation (đầu vào người dùng), Logging (gỡ lỗi/giám sát)
  - Cập nhật với các mẫu phương pháp khám phá (`*/list`), truy xuất (`*/get`) và thực thi (`*/call`)
- **Kiến trúc Giao thức**: Giới thiệu mô hình kiến trúc hai lớp
  - Lớp Dữ liệu: Nền tảng JSON-RPC 2.0 với quản lý vòng đời và nguyên thủy
  - Lớp Giao vận: STDIO (cục bộ) và HTTP có thể streaming với SSE (từ xa)
- **Khung Bảo mật**: Nguyên tắc bảo mật toàn diện bao gồm sự đồng ý rõ ràng của người dùng, bảo vệ quyền riêng tư dữ liệu, an toàn thực thi công cụ và bảo mật lớp giao vận
- **Mẫu Giao tiếp**: Cập nhật tin nhắn giao thức để hiển thị luồng khởi tạo, khám phá, thực thi và thông báo
- **Ví dụ Mã**: Làm mới ví dụ đa ngôn ngữ (.NET, Java, Python, JavaScript) để phản ánh mẫu SDK MCP hiện tại

#### Bảo mật (02-Security/) - Đại tu Bảo mật Toàn diện  
- **Phù hợp Tiêu chuẩn**: Phù hợp hoàn toàn với các yêu cầu bảo mật của MCP 2025-06-18
- **Tiến hóa Xác thực**: Tài liệu hóa sự tiến hóa từ máy chủ OAuth tùy chỉnh sang ủy quyền nhà cung cấp danh tính bên ngoài (Microsoft Entra ID)
- **Phân tích Mối đe dọa Cụ thể AI**: Tăng cường phạm vi các vector tấn công AI
- Thay thế thẻ `<details>` bằng định dạng dựa trên bảng dễ tiếp cận hơn
- Tạo các tùy chọn bố cục thay thế trong thư mục "alternative_layouts" mới
- Thêm các ví dụ điều hướng dạng thẻ, kiểu tab và kiểu accordion
- Cập nhật phần cấu trúc kho lưu trữ để bao gồm tất cả các tệp mới nhất
- Nâng cao phần "Cách sử dụng chương trình học này" với các khuyến nghị rõ ràng
- Cập nhật liên kết đặc tả MCP để trỏ đến các URL chính xác
- Thêm phần Kỹ thuật Ngữ cảnh (5.14) vào cấu trúc chương trình học

### Cập nhật Hướng dẫn Học tập
- Hoàn toàn sửa đổi hướng dẫn học tập để phù hợp với cấu trúc kho lưu trữ hiện tại
- Thêm các phần mới về MCP Clients và Tools, và các MCP Servers phổ biến
- Cập nhật Bản đồ Chương trình Học trực quan để phản ánh chính xác tất cả các chủ đề
- Nâng cao mô tả về Các Chủ đề Nâng cao để bao quát tất cả các lĩnh vực chuyên sâu
- Cập nhật phần Nghiên cứu Tình huống để phản ánh các ví dụ thực tế
- Thêm nhật ký thay đổi toàn diện này

### Đóng góp từ Cộng đồng (06-CommunityContributions/)
- Thêm thông tin chi tiết về các MCP servers cho việc tạo hình ảnh
- Thêm phần toàn diện về cách sử dụng Claude trong VSCode
- Thêm hướng dẫn thiết lập và sử dụng client terminal Cline
- Cập nhật phần MCP client để bao gồm tất cả các tùy chọn client phổ biến
- Nâng cao các ví dụ đóng góp với các mẫu mã chính xác hơn

### Các Chủ đề Nâng cao (05-AdvancedTopics/)
- Tổ chức tất cả các thư mục chủ đề chuyên sâu với cách đặt tên nhất quán
- Thêm tài liệu và ví dụ về kỹ thuật ngữ cảnh
- Thêm tài liệu tích hợp agent Foundry
- Nâng cao tài liệu tích hợp bảo mật Entra ID

## Ngày 11 tháng 6 năm 2025

### Tạo lần đầu
- Phát hành phiên bản đầu tiên của chương trình học MCP cho người mới bắt đầu
- Tạo cấu trúc cơ bản cho tất cả 10 phần chính
- Triển khai Bản đồ Chương trình Học trực quan để điều hướng
- Thêm các dự án mẫu ban đầu bằng nhiều ngôn ngữ lập trình

### Bắt đầu (03-GettingStarted/)
- Tạo các ví dụ triển khai server đầu tiên
- Thêm hướng dẫn phát triển client
- Bao gồm hướng dẫn tích hợp client LLM
- Thêm tài liệu tích hợp VS Code
- Triển khai các ví dụ server Server-Sent Events (SSE)

### Các Khái niệm Cốt lõi (01-CoreConcepts/)
- Thêm giải thích chi tiết về kiến trúc client-server
- Tạo tài liệu về các thành phần chính của giao thức
- Tài liệu hóa các mẫu tin nhắn trong MCP

## Ngày 23 tháng 5 năm 2025

### Cấu trúc Kho lưu trữ
- Khởi tạo kho lưu trữ với cấu trúc thư mục cơ bản
- Tạo các tệp README cho mỗi phần chính
- Thiết lập cơ sở hạ tầng dịch thuật
- Thêm tài sản hình ảnh và sơ đồ

### Tài liệu
- Tạo README.md ban đầu với tổng quan về chương trình học
- Thêm CODE_OF_CONDUCT.md và SECURITY.md
- Thiết lập SUPPORT.md với hướng dẫn nhận hỗ trợ
- Tạo cấu trúc hướng dẫn học tập sơ bộ

## Ngày 15 tháng 4 năm 2025

### Lập kế hoạch và Khung chương trình
- Lập kế hoạch ban đầu cho chương trình học MCP cho người mới bắt đầu
- Xác định mục tiêu học tập và đối tượng mục tiêu
- Phác thảo cấu trúc 10 phần của chương trình học
- Phát triển khung khái niệm cho các ví dụ và nghiên cứu tình huống
- Tạo các ví dụ nguyên mẫu ban đầu cho các khái niệm chính

---

