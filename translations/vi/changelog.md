<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f9d56a1327805a9f6df085a41fb81083",
  "translation_date": "2025-09-30T19:18:34+00:00",
  "source_file": "changelog.md",
  "language_code": "vi"
}
-->
# Nhật ký thay đổi: Giáo trình MCP cho người mới bắt đầu

Tài liệu này ghi lại tất cả các thay đổi quan trọng được thực hiện đối với giáo trình Model Context Protocol (MCP) dành cho người mới bắt đầu. Các thay đổi được ghi lại theo thứ tự thời gian đảo ngược (thay đổi mới nhất trước).

## Ngày 29 tháng 9 năm 2025

### Phòng thí nghiệm tích hợp cơ sở dữ liệu MCP Server - Lộ trình học tập thực hành toàn diện

#### 11-MCPServerHandsOnLabs - Giáo trình tích hợp cơ sở dữ liệu hoàn chỉnh mới
- **Lộ trình học tập 13 phòng thí nghiệm hoàn chỉnh**: Thêm giáo trình thực hành toàn diện để xây dựng MCP server sẵn sàng cho sản xuất với tích hợp cơ sở dữ liệu PostgreSQL
  - **Triển khai thực tế**: Trường hợp sử dụng phân tích bán lẻ Zava minh họa các mẫu cấp doanh nghiệp
  - **Tiến trình học tập có cấu trúc**:
    - **Phòng thí nghiệm 00-03: Nền tảng** - Giới thiệu, Kiến trúc cốt lõi, Bảo mật & Đa người thuê, Thiết lập môi trường
    - **Phòng thí nghiệm 04-06: Xây dựng MCP Server** - Thiết kế & Schema cơ sở dữ liệu, Triển khai MCP Server, Phát triển công cụ  
    - **Phòng thí nghiệm 07-09: Tính năng nâng cao** - Tích hợp tìm kiếm ngữ nghĩa, Kiểm thử & Gỡ lỗi, Tích hợp VS Code
    - **Phòng thí nghiệm 10-12: Sản xuất & Thực hành tốt nhất** - Chiến lược triển khai, Giám sát & Khả năng quan sát, Tối ưu hóa & Thực hành tốt nhất
  - **Công nghệ doanh nghiệp**: Framework FastMCP, PostgreSQL với pgvector, Azure OpenAI embeddings, Azure Container Apps, Application Insights
  - **Tính năng nâng cao**: Bảo mật cấp hàng (RLS), tìm kiếm ngữ nghĩa, truy cập dữ liệu đa người thuê, vector embeddings, giám sát thời gian thực

#### Chuẩn hóa thuật ngữ - Chuyển đổi từ Module sang Lab
- **Cập nhật tài liệu toàn diện**: Hệ thống hóa tất cả các tệp README trong 11-MCPServerHandsOnLabs để sử dụng thuật ngữ "Lab" thay vì "Module"
  - **Tiêu đề phần**: Cập nhật "What This Module Covers" thành "What This Lab Covers" trong tất cả 13 phòng thí nghiệm
  - **Mô tả nội dung**: Thay đổi "This module provides..." thành "This lab provides..." trong toàn bộ tài liệu
  - **Mục tiêu học tập**: Cập nhật "By the end of this module..." thành "By the end of this lab..."
  - **Liên kết điều hướng**: Chuyển đổi tất cả các tham chiếu "Module XX:" thành "Lab XX:" trong các tham chiếu chéo và điều hướng
  - **Theo dõi hoàn thành**: Cập nhật "After completing this module..." thành "After completing this lab..."
  - **Giữ nguyên tham chiếu kỹ thuật**: Duy trì các tham chiếu module Python trong tệp cấu hình (ví dụ: `"module": "mcp_server.main"`)

#### Nâng cao hướng dẫn học tập (study_guide.md)
- **Bản đồ giáo trình trực quan**: Thêm phần mới "11. Database Integration Labs" với hình dung cấu trúc phòng thí nghiệm toàn diện
- **Cấu trúc kho lưu trữ**: Cập nhật từ mười lên mười một phần chính với mô tả chi tiết về 11-MCPServerHandsOnLabs
- **Hướng dẫn lộ trình học tập**: Nâng cao hướng dẫn điều hướng để bao gồm các phần 00-11
- **Phạm vi công nghệ**: Thêm chi tiết tích hợp FastMCP, PostgreSQL, và các dịch vụ Azure
- **Kết quả học tập**: Nhấn mạnh phát triển server sẵn sàng cho sản xuất, các mẫu tích hợp cơ sở dữ liệu, và bảo mật cấp doanh nghiệp

#### Nâng cao cấu trúc README chính
- **Thuật ngữ dựa trên Lab**: Cập nhật README.md chính trong 11-MCPServerHandsOnLabs để sử dụng cấu trúc "Lab" một cách nhất quán
- **Tổ chức lộ trình học tập**: Tiến trình rõ ràng từ các khái niệm cơ bản đến triển khai nâng cao và triển khai sản xuất
- **Tập trung thực tế**: Nhấn mạnh học tập thực hành với các mẫu và công nghệ cấp doanh nghiệp

### Cải thiện chất lượng & tính nhất quán của tài liệu
- **Nhấn mạnh học tập thực hành**: Tăng cường cách tiếp cận dựa trên phòng thí nghiệm thực hành trong toàn bộ tài liệu
- **Tập trung vào mẫu cấp doanh nghiệp**: Làm nổi bật các triển khai sẵn sàng cho sản xuất và các cân nhắc về bảo mật cấp doanh nghiệp
- **Tích hợp công nghệ**: Phạm vi toàn diện về các dịch vụ Azure hiện đại và các mẫu tích hợp AI
- **Tiến trình học tập**: Lộ trình rõ ràng, có cấu trúc từ các khái niệm cơ bản đến triển khai sản xuất

## Ngày 26 tháng 9 năm 2025

### Nâng cao nghiên cứu trường hợp - Tích hợp GitHub MCP Registry

#### Nghiên cứu trường hợp (09-CaseStudy/) - Tập trung phát triển hệ sinh thái
- **README.md**: Mở rộng lớn với nghiên cứu trường hợp GitHub MCP Registry toàn diện
  - **Nghiên cứu trường hợp GitHub MCP Registry**: Nghiên cứu trường hợp toàn diện mới về việc ra mắt GitHub MCP Registry vào tháng 9 năm 2025
    - **Phân tích vấn đề**: Kiểm tra chi tiết các thách thức về khám phá và triển khai MCP server bị phân mảnh
    - **Kiến trúc giải pháp**: Cách tiếp cận registry tập trung của GitHub với cài đặt VS Code chỉ bằng một cú nhấp chuột
    - **Tác động kinh doanh**: Cải thiện đáng kể việc onboarding và năng suất của nhà phát triển
    - **Giá trị chiến lược**: Tập trung vào triển khai agent theo module và khả năng tương tác giữa các công cụ
    - **Phát triển hệ sinh thái**: Định vị như nền tảng cơ bản cho tích hợp agentic
  - **Cấu trúc nghiên cứu trường hợp nâng cao**: Cập nhật tất cả bảy nghiên cứu trường hợp với định dạng nhất quán và mô tả toàn diện
    - Azure AI Travel Agents: Nhấn mạnh điều phối đa agent
    - Tích hợp Azure DevOps: Tập trung vào tự động hóa quy trình làm việc
    - Truy xuất tài liệu thời gian thực: Triển khai client console Python
    - Trình tạo kế hoạch học tập tương tác: Ứng dụng web hội thoại Chainlit
    - Tài liệu trong trình chỉnh sửa: Tích hợp VS Code và GitHub Copilot
    - Quản lý API Azure: Các mẫu tích hợp API cấp doanh nghiệp
    - GitHub MCP Registry: Phát triển hệ sinh thái và nền tảng cộng đồng
  - **Kết luận toàn diện**: Viết lại phần kết luận làm nổi bật bảy nghiên cứu trường hợp trải dài nhiều khía cạnh triển khai MCP
    - Tích hợp doanh nghiệp, Điều phối đa agent, Năng suất nhà phát triển
    - Phát triển hệ sinh thái, Ứng dụng giáo dục
    - Cung cấp thông tin chi tiết nâng cao về các mẫu kiến trúc, chiến lược triển khai, và thực hành tốt nhất
    - Nhấn mạnh MCP như một giao thức trưởng thành, sẵn sàng cho sản xuất

#### Cập nhật hướng dẫn học tập (study_guide.md)
- **Bản đồ giáo trình trực quan**: Cập nhật sơ đồ tư duy để bao gồm GitHub MCP Registry trong phần Nghiên cứu trường hợp
- **Mô tả nghiên cứu trường hợp**: Nâng cao từ mô tả chung thành phân tích chi tiết bảy nghiên cứu trường hợp toàn diện
- **Cấu trúc kho lưu trữ**: Cập nhật phần 10 để phản ánh phạm vi nghiên cứu trường hợp toàn diện với chi tiết triển khai cụ thể
- **Tích hợp nhật ký thay đổi**: Thêm mục ngày 26 tháng 9 năm 2025 ghi lại việc bổ sung GitHub MCP Registry và nâng cao nghiên cứu trường hợp
- **Cập nhật ngày tháng**: Cập nhật dấu thời gian ở chân trang để phản ánh lần sửa đổi mới nhất (ngày 26 tháng 9 năm 2025)

### Cải thiện chất lượng tài liệu
- **Nâng cao tính nhất quán**: Chuẩn hóa định dạng và cấu trúc nghiên cứu trường hợp trên tất cả bảy ví dụ
- **Phạm vi toàn diện**: Các nghiên cứu trường hợp hiện bao gồm các kịch bản doanh nghiệp, năng suất nhà phát triển, và phát triển hệ sinh thái
- **Định vị chiến lược**: Tăng cường tập trung vào MCP như nền tảng cơ bản cho triển khai hệ thống agentic
- **Tích hợp tài nguyên**: Cập nhật các tài nguyên bổ sung để bao gồm liên kết GitHub MCP Registry

## Ngày 15 tháng 9 năm 2025

### Mở rộng chủ đề nâng cao - Vận chuyển tùy chỉnh & Kỹ thuật ngữ cảnh

#### MCP Custom Transports (05-AdvancedTopics/mcp-transport/) - Hướng dẫn triển khai nâng cao mới
- **README.md**: Hướng dẫn triển khai hoàn chỉnh cho các cơ chế vận chuyển MCP tùy chỉnh
  - **Azure Event Grid Transport**: Triển khai vận chuyển không máy chủ theo sự kiện toàn diện
    - Ví dụ C#, TypeScript, và Python với tích hợp Azure Functions
    - Các mẫu kiến trúc theo sự kiện cho các giải pháp MCP có khả năng mở rộng
    - Bộ nhận webhook và xử lý tin nhắn dựa trên đẩy
  - **Azure Event Hubs Transport**: Triển khai vận chuyển streaming thông lượng cao
    - Khả năng streaming thời gian thực cho các kịch bản độ trễ thấp
    - Chiến lược phân vùng và quản lý điểm kiểm tra
    - Batching tin nhắn và tối ưu hóa hiệu suất
  - **Mẫu tích hợp doanh nghiệp**: Ví dụ kiến trúc sẵn sàng cho sản xuất
    - Xử lý MCP phân tán trên nhiều Azure Functions
    - Kiến trúc vận chuyển lai kết hợp nhiều loại vận chuyển
    - Độ bền tin nhắn, độ tin cậy, và chiến lược xử lý lỗi
  - **Bảo mật & Giám sát**: Tích hợp Azure Key Vault và các mẫu khả năng quan sát
    - Xác thực danh tính được quản lý và truy cập tối thiểu
    - Telemetry Application Insights và giám sát hiệu suất
    - Circuit breakers và các mẫu chịu lỗi
  - **Khung kiểm thử**: Chiến lược kiểm thử toàn diện cho các vận chuyển tùy chỉnh
    - Kiểm thử đơn vị với test doubles và các framework giả lập
    - Kiểm thử tích hợp với Azure Test Containers
    - Cân nhắc kiểm thử hiệu suất và tải

#### Kỹ thuật ngữ cảnh (05-AdvancedTopics/mcp-contextengineering/) - Lĩnh vực AI mới nổi
- **README.md**: Khám phá toàn diện về kỹ thuật ngữ cảnh như một lĩnh vực mới nổi
  - **Nguyên tắc cốt lõi**: Chia sẻ ngữ cảnh hoàn chỉnh, nhận thức quyết định hành động, và quản lý cửa sổ ngữ cảnh
  - **Sự phù hợp với giao thức MCP**: Cách thiết kế MCP giải quyết các thách thức kỹ thuật ngữ cảnh
    - Giới hạn cửa sổ ngữ cảnh và chiến lược tải tiến bộ
    - Xác định mức độ liên quan và truy xuất ngữ cảnh động
    - Xử lý ngữ cảnh đa phương thức và các cân nhắc về bảo mật
  - **Cách tiếp cận triển khai**: Kiến trúc đơn luồng so với đa agent
    - Chunking ngữ cảnh và các kỹ thuật ưu tiên
    - Tải ngữ cảnh tiến bộ và chiến lược nén
    - Các cách tiếp cận ngữ cảnh phân lớp và tối ưu hóa truy xuất
  - **Khung đo lường**: Các chỉ số mới nổi để đánh giá hiệu quả ngữ cảnh
    - Hiệu quả đầu vào, hiệu suất, chất lượng, và cân nhắc trải nghiệm người dùng
    - Các cách tiếp cận thử nghiệm để tối ưu hóa ngữ cảnh
    - Phân tích lỗi và phương pháp cải tiến

#### Cập nhật điều hướng giáo trình (README.md)
- **Cấu trúc module nâng cao**: Cập nhật bảng giáo trình để bao gồm các chủ đề nâng cao mới
  - Thêm Kỹ thuật ngữ cảnh (5.14) và Vận chuyển tùy chỉnh (5.15)
  - Định dạng nhất quán và liên kết điều hướng trên tất cả các module
  - Cập nhật mô tả để phản ánh phạm vi nội dung hiện tại

### Cải tiến cấu trúc thư mục
- **Chuẩn hóa tên**: Đổi tên "mcp transport" thành "mcp-transport" để nhất quán với các thư mục chủ đề nâng cao khác
- **Tổ chức nội dung**: Tất cả các thư mục 05-AdvancedTopics hiện tuân theo mẫu đặt tên nhất quán (mcp-[chủ đề])

### Nâng cao chất lượng tài liệu
- **Phù hợp với đặc tả MCP**: Tất cả nội dung mới tham chiếu đến đặc tả MCP hiện tại 2025-06-18
- **Ví dụ đa ngôn ngữ**: Các ví dụ mã toàn diện bằng C#, TypeScript, và Python
- **Tập trung vào doanh nghiệp**: Các mẫu sẵn sàng cho sản xuất và tích hợp đám mây Azure trong toàn bộ nội dung
- **Tài liệu trực quan**: Biểu đồ Mermaid để hình dung kiến trúc và luồng

## Ngày 18 tháng 8 năm 2025

### Cập nhật toàn diện tài liệu - Tiêu chuẩn MCP 2025-06-18

#### Thực hành tốt nhất về bảo mật MCP (02-Security/) - Hiện đại hóa hoàn chỉnh
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Viết lại hoàn chỉnh phù hợp với đặc tả MCP 2025-06-18
  - **Yêu cầu bắt buộc**: Thêm các yêu cầu MUST/MUST NOT rõ ràng từ đặc tả chính thức với các chỉ báo trực quan rõ ràng
  - **12 Thực hành bảo mật cốt lõi**: Cấu trúc lại từ danh sách 15 mục thành các lĩnh vực bảo mật toàn diện
    - Bảo mật Token & Xác thực với tích hợp nhà cung cấp danh tính bên ngoài
    - Quản lý phiên & Bảo mật vận chuyển với các yêu cầu mã hóa
    - Bảo vệ mối đe dọa AI cụ thể với tích hợp Microsoft Prompt Shields
    - Kiểm soát truy cập & Quyền với nguyên tắc truy cập tối thiểu
    - An toàn nội dung & Giám sát với tích hợp Azure Content Safety
    - Bảo mật chuỗi cung ứng với xác minh thành phần toàn diện
    - Bảo mật OAuth & Phòng ngừa tấn công Confused Deputy với triển khai PKCE
    - Phản ứng & Khôi phục sự cố với các khả năng tự động hóa
    - Tuân thủ & Quản trị với sự phù hợp quy định
    - Kiểm soát bảo mật nâng cao với kiến trúc zero trust
    - Tích hợp hệ sinh thái bảo mật Microsoft với các giải pháp toàn diện
    - Tiến hóa bảo mật liên tục với các thực hành thích ứng
  - **Giải pháp bảo mật Microsoft**: Hướng dẫn tích hợp nâng cao cho Prompt Shields, Azure Content Safety, Entra ID, và GitHub Advanced Security
  - **Tài nguyên triển khai**: Phân loại các liên kết tài nguyên toàn diện theo Tài liệu MCP chính thức, Giải pháp bảo mật Microsoft, Tiêu chuẩn bảo mật, và Hướng dẫn triển khai

#### Kiểm soát bảo mật nâng cao (02-Security/) - Triển khai cấp doanh nghiệp
- **MCP-SECURITY-CONTROLS-2025.md**: Đại tu hoàn chỉnh với khung bảo mật cấp doanh nghiệp
  - **9 Lĩnh vực bảo mật toàn diện**: Mở rộng từ các kiểm soát cơ bản đến khung chi tiết cấp doanh nghiệp
    - Xác thực & Ủy quyền nâng cao với tích hợp Microsoft Entra ID
    - Bảo mật Token & Kiểm soát chống vượt qua với xác thực toàn diện
    - Kiểm soát bảo mật phiên với phòng ngừa chiếm đoạt
    - Kiểm soát bảo mật AI cụ thể với phòng ngừa tiêm prompt và đầu độc công cụ
    - Phòng ngừa tấn công Confused Deputy với bảo mật proxy OAuth
    - Bảo mật thực thi công cụ với sandboxing và cô lập
    - Kiểm soát bảo mật chuỗi cung ứng với xác minh phụ thuộc
    - Kiểm soát giám sát & phát hiện với tích hợp SIEM
    - Phản ứng & Khôi phục sự cố với các khả năng tự động hóa
  - **Ví dụ triển khai**: Thêm các khối cấu hình YAML chi tiết và ví dụ mã
  - **Tích hợp giải pháp Microsoft**: Phạm vi toàn diện về các dịch vụ bảo mật Azure, GitHub Advanced Security, và quản lý danh tính doanh nghiệp

#### Bảo mật chủ đề nâng cao (05-AdvancedTopics/mcp-security/) - Triển khai sẵn sàng sản xuất
- **README.md**: Viết lại hoàn chỉnh cho triển khai bảo mật cấp doanh nghiệp
  - **Phù hợp với đặc tả hiện tại**: Cập nhật theo đặc tả MCP 2025-06-18 với các yêu cầu bảo mật bắt buộc
  - **Xác thực nâng cao**: Tích hợp Microsoft Entra ID với các ví dụ toàn diện .NET và Java Spring Security
  - **Tích hợp bảo mật AI**
- **Chỉ báo trực quan**: Đánh dấu rõ ràng các yêu cầu bắt buộc so với các thực hành được khuyến nghị

#### Các khái niệm cốt lõi (01-CoreConcepts/) - Hiện đại hóa toàn diện
- **Cập nhật phiên bản giao thức**: Được cập nhật để tham chiếu đến MCP Specification hiện tại 2025-06-18 với định dạng phiên bản theo ngày (YYYY-MM-DD)
- **Tinh chỉnh kiến trúc**: Mô tả chi tiết hơn về Hosts, Clients và Servers để phản ánh các mẫu kiến trúc MCP hiện tại
  - Hosts được định nghĩa rõ ràng là các ứng dụng AI phối hợp nhiều kết nối client MCP
  - Clients được mô tả là các kết nối giao thức duy trì mối quan hệ một-một với server
  - Servers được cải tiến với các kịch bản triển khai cục bộ và từ xa
- **Tái cấu trúc nguyên thủy**: Đại tu toàn diện các nguyên thủy của server và client
  - Nguyên thủy của Server: Resources (nguồn dữ liệu), Prompts (mẫu), Tools (chức năng có thể thực thi) với các giải thích và ví dụ chi tiết
  - Nguyên thủy của Client: Sampling (hoàn thành LLM), Elicitation (đầu vào người dùng), Logging (gỡ lỗi/giám sát)
  - Được cập nhật với các mẫu phương pháp hiện tại (`*/list`, `*/get`, `*/call`)
- **Kiến trúc giao thức**: Giới thiệu mô hình kiến trúc hai lớp
  - Lớp dữ liệu: Nền tảng JSON-RPC 2.0 với quản lý vòng đời và các nguyên thủy
  - Lớp truyền tải: STDIO (cục bộ) và HTTP có thể truyền trực tuyến với SSE (từ xa)
- **Khung bảo mật**: Các nguyên tắc bảo mật toàn diện bao gồm sự đồng ý rõ ràng của người dùng, bảo vệ quyền riêng tư dữ liệu, an toàn thực thi công cụ và bảo mật lớp truyền tải
- **Mẫu giao tiếp**: Cập nhật các thông điệp giao thức để hiển thị các luồng khởi tạo, khám phá, thực thi và thông báo
- **Ví dụ mã**: Làm mới các ví dụ đa ngôn ngữ (.NET, Java, Python, JavaScript) để phản ánh các mẫu SDK MCP hiện tại

#### Bảo mật (02-Security/) - Đại tu bảo mật toàn diện  
- **Tuân thủ tiêu chuẩn**: Tuân thủ đầy đủ các yêu cầu bảo mật của MCP Specification 2025-06-18
- **Tiến hóa xác thực**: Tài liệu hóa sự tiến hóa từ các máy chủ OAuth tùy chỉnh sang ủy quyền nhà cung cấp danh tính bên ngoài (Microsoft Entra ID)
- **Phân tích mối đe dọa AI cụ thể**: Tăng cường phạm vi các vector tấn công AI hiện đại
  - Các kịch bản tấn công tiêm prompt chi tiết với ví dụ thực tế
  - Cơ chế đầu độc công cụ và các mẫu tấn công "rug pull"
  - Đầu độc cửa sổ ngữ cảnh và các cuộc tấn công gây nhầm lẫn mô hình
- **Giải pháp bảo mật AI của Microsoft**: Phạm vi toàn diện về hệ sinh thái bảo mật của Microsoft
  - AI Prompt Shields với các kỹ thuật phát hiện, làm nổi bật và phân cách tiên tiến
  - Các mẫu tích hợp Azure Content Safety
  - GitHub Advanced Security để bảo vệ chuỗi cung ứng
- **Giảm thiểu mối đe dọa nâng cao**: Các biện pháp kiểm soát bảo mật chi tiết cho
  - Chiếm đoạt phiên với các kịch bản tấn công cụ thể của MCP và yêu cầu ID phiên mã hóa
  - Các vấn đề confused deputy trong các kịch bản proxy MCP với yêu cầu đồng ý rõ ràng
  - Các lỗ hổng truyền token với các biện pháp kiểm soát xác thực bắt buộc
- **Bảo mật chuỗi cung ứng**: Mở rộng phạm vi chuỗi cung ứng AI bao gồm các mô hình nền tảng, dịch vụ embeddings, nhà cung cấp ngữ cảnh và API bên thứ ba
- **Bảo mật nền tảng**: Tăng cường tích hợp với các mẫu bảo mật doanh nghiệp bao gồm kiến trúc zero trust và hệ sinh thái bảo mật của Microsoft
- **Tổ chức tài nguyên**: Phân loại các liên kết tài nguyên toàn diện theo loại (Tài liệu chính thức, Tiêu chuẩn, Nghiên cứu, Giải pháp của Microsoft, Hướng dẫn triển khai)

### Cải thiện chất lượng tài liệu
- **Mục tiêu học tập có cấu trúc**: Tăng cường các mục tiêu học tập với kết quả cụ thể, có thể hành động
- **Tham chiếu chéo**: Thêm liên kết giữa các chủ đề bảo mật và khái niệm cốt lõi liên quan
- **Thông tin hiện tại**: Cập nhật tất cả các tham chiếu ngày và liên kết đặc tả theo tiêu chuẩn hiện tại
- **Hướng dẫn triển khai**: Thêm các hướng dẫn triển khai cụ thể, có thể hành động trong suốt cả hai phần

## Ngày 16 tháng 7 năm 2025

### README và cải tiến điều hướng
- Thiết kế lại hoàn toàn điều hướng chương trình học trong README.md
- Thay thế các thẻ `<details>` bằng định dạng bảng dễ tiếp cận hơn
- Tạo các tùy chọn bố cục thay thế trong thư mục "alternative_layouts" mới
- Thêm các ví dụ điều hướng kiểu thẻ, kiểu tab và kiểu accordion
- Cập nhật phần cấu trúc kho lưu trữ để bao gồm tất cả các tệp mới nhất
- Tăng cường phần "Cách sử dụng chương trình học này" với các khuyến nghị rõ ràng
- Cập nhật các liên kết đặc tả MCP để trỏ đến các URL chính xác
- Thêm phần Kỹ thuật ngữ cảnh (5.14) vào cấu trúc chương trình học

### Cập nhật hướng dẫn học tập
- Sửa đổi hoàn toàn hướng dẫn học tập để phù hợp với cấu trúc kho lưu trữ hiện tại
- Thêm các phần mới cho MCP Clients và Tools, và các MCP Servers phổ biến
- Cập nhật Bản đồ chương trình học trực quan để phản ánh chính xác tất cả các chủ đề
- Tăng cường mô tả về Các chủ đề nâng cao để bao quát tất cả các lĩnh vực chuyên biệt
- Cập nhật phần Nghiên cứu tình huống để phản ánh các ví dụ thực tế
- Thêm nhật ký thay đổi toàn diện này

### Đóng góp cộng đồng (06-CommunityContributions/)
- Thêm thông tin chi tiết về các máy chủ MCP cho tạo hình ảnh
- Thêm phần toàn diện về cách sử dụng Claude trong VSCode
- Thêm hướng dẫn thiết lập và sử dụng client terminal Cline
- Cập nhật phần client MCP để bao gồm tất cả các tùy chọn client phổ biến
- Tăng cường các ví dụ đóng góp với các mẫu mã chính xác hơn

### Các chủ đề nâng cao (05-AdvancedTopics/)
- Tổ chức tất cả các thư mục chủ đề chuyên biệt với tên gọi nhất quán
- Thêm tài liệu và ví dụ về kỹ thuật ngữ cảnh
- Thêm tài liệu tích hợp agent Foundry
- Tăng cường tài liệu tích hợp bảo mật Entra ID

## Ngày 11 tháng 6 năm 2025

### Tạo ban đầu
- Phát hành phiên bản đầu tiên của chương trình học MCP cho người mới bắt đầu
- Tạo cấu trúc cơ bản cho tất cả 10 phần chính
- Triển khai Bản đồ chương trình học trực quan để điều hướng
- Thêm các dự án mẫu ban đầu bằng nhiều ngôn ngữ lập trình

### Bắt đầu (03-GettingStarted/)
- Tạo các ví dụ triển khai máy chủ đầu tiên
- Thêm hướng dẫn phát triển client
- Bao gồm hướng dẫn tích hợp client LLM
- Thêm tài liệu tích hợp VS Code
- Triển khai các ví dụ máy chủ Server-Sent Events (SSE)

### Các khái niệm cốt lõi (01-CoreConcepts/)
- Thêm giải thích chi tiết về kiến trúc client-server
- Tạo tài liệu về các thành phần giao thức chính
- Tài liệu hóa các mẫu thông điệp trong MCP

## Ngày 23 tháng 5 năm 2025

### Cấu trúc kho lưu trữ
- Khởi tạo kho lưu trữ với cấu trúc thư mục cơ bản
- Tạo các tệp README cho mỗi phần chính
- Thiết lập cơ sở hạ tầng dịch thuật
- Thêm tài sản hình ảnh và sơ đồ

### Tài liệu
- Tạo README.md ban đầu với tổng quan chương trình học
- Thêm CODE_OF_CONDUCT.md và SECURITY.md
- Thiết lập SUPPORT.md với hướng dẫn nhận trợ giúp
- Tạo cấu trúc hướng dẫn học tập sơ bộ

## Ngày 15 tháng 4 năm 2025

### Lập kế hoạch và khung
- Lập kế hoạch ban đầu cho chương trình học MCP cho người mới bắt đầu
- Xác định mục tiêu học tập và đối tượng mục tiêu
- Phác thảo cấu trúc 10 phần của chương trình học
- Phát triển khung khái niệm cho các ví dụ và nghiên cứu tình huống
- Tạo các ví dụ nguyên mẫu ban đầu cho các khái niệm chính

---

**Tuyên bố miễn trừ trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ bản địa nên được coi là nguồn thông tin chính thức. Đối với các thông tin quan trọng, khuyến nghị sử dụng dịch vụ dịch thuật chuyên nghiệp bởi con người. Chúng tôi không chịu trách nhiệm cho bất kỳ sự hiểu lầm hoặc diễn giải sai nào phát sinh từ việc sử dụng bản dịch này.