<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "56dd5af7e84cc0db6e17e310112109ae",
  "translation_date": "2025-09-15T22:22:23+00:00",
  "source_file": "changelog.md",
  "language_code": "vi"
}
-->
# Nhật ký thay đổi: Giáo trình MCP cho Người mới bắt đầu

Tài liệu này là bản ghi lại tất cả các thay đổi quan trọng được thực hiện đối với giáo trình Model Context Protocol (MCP) dành cho người mới bắt đầu. Các thay đổi được ghi lại theo thứ tự thời gian đảo ngược (thay đổi mới nhất trước).

## 15 Tháng 9, 2025

### Mở rộng Chủ đề Nâng cao - Vận chuyển Tùy chỉnh & Kỹ thuật Ngữ cảnh

#### MCP Vận chuyển Tùy chỉnh (05-AdvancedTopics/mcp-transport/) - Hướng dẫn Triển khai Nâng cao Mới
- **README.md**: Hướng dẫn triển khai đầy đủ cho các cơ chế vận chuyển MCP tùy chỉnh
  - **Azure Event Grid Transport**: Triển khai vận chuyển không máy chủ theo sự kiện toàn diện
    - Ví dụ bằng C#, TypeScript, và Python với tích hợp Azure Functions
    - Mô hình kiến trúc theo sự kiện cho các giải pháp MCP có khả năng mở rộng
    - Bộ nhận webhook và xử lý tin nhắn theo kiểu đẩy
  - **Azure Event Hubs Transport**: Triển khai vận chuyển theo luồng với thông lượng cao
    - Khả năng truyền dữ liệu theo thời gian thực cho các tình huống độ trễ thấp
    - Chiến lược phân vùng và quản lý điểm kiểm tra
    - Gộp tin nhắn và tối ưu hóa hiệu suất
  - **Mô hình Tích hợp Doanh nghiệp**: Ví dụ kiến trúc sẵn sàng sản xuất
    - Xử lý MCP phân tán trên nhiều Azure Functions
    - Kiến trúc vận chuyển lai kết hợp nhiều loại vận chuyển
    - Chiến lược độ bền, độ tin cậy và xử lý lỗi của tin nhắn
  - **Bảo mật & Giám sát**: Tích hợp Azure Key Vault và các mô hình quan sát
    - Xác thực danh tính được quản lý và truy cập với quyền tối thiểu
    - Telemetry của Application Insights và giám sát hiệu suất
    - Bộ ngắt mạch và các mô hình chịu lỗi
  - **Khung Kiểm thử**: Chiến lược kiểm thử toàn diện cho các vận chuyển tùy chỉnh
    - Kiểm thử đơn vị với các đối tượng giả và khung mô phỏng
    - Kiểm thử tích hợp với Azure Test Containers
    - Cân nhắc kiểm thử hiệu suất và tải

#### Kỹ thuật Ngữ cảnh (05-AdvancedTopics/mcp-contextengineering/) - Lĩnh vực AI Mới Nổi
- **README.md**: Khám phá toàn diện về kỹ thuật ngữ cảnh như một lĩnh vực mới nổi
  - **Nguyên tắc Cốt lõi**: Chia sẻ ngữ cảnh hoàn chỉnh, nhận thức quyết định hành động, và quản lý cửa sổ ngữ cảnh
  - **Sự phù hợp với MCP Protocol**: Cách thiết kế MCP giải quyết các thách thức kỹ thuật ngữ cảnh
    - Giới hạn cửa sổ ngữ cảnh và chiến lược tải tiến bộ
    - Xác định mức độ liên quan và truy xuất ngữ cảnh động
    - Xử lý ngữ cảnh đa phương thức và các cân nhắc về bảo mật
  - **Phương pháp Triển khai**: Kiến trúc đơn luồng so với đa tác nhân
    - Kỹ thuật phân đoạn và ưu tiên ngữ cảnh
    - Tải tiến ngữ cảnh và chiến lược nén
    - Phương pháp ngữ cảnh phân lớp và tối ưu hóa truy xuất
  - **Khung Đo lường**: Các chỉ số mới nổi để đánh giá hiệu quả ngữ cảnh
    - Hiệu quả đầu vào, hiệu suất, chất lượng, và cân nhắc trải nghiệm người dùng
    - Phương pháp thử nghiệm để tối ưu hóa ngữ cảnh
    - Phân tích lỗi và phương pháp cải tiến

#### Cập nhật Điều hướng Giáo trình (README.md)
- **Cấu trúc Module Nâng cao**: Cập nhật bảng giáo trình để bao gồm các chủ đề nâng cao mới
  - Thêm Kỹ thuật Ngữ cảnh (5.14) và Vận chuyển Tùy chỉnh (5.15)
  - Định dạng và liên kết điều hướng nhất quán trên tất cả các module
  - Cập nhật mô tả để phản ánh phạm vi nội dung hiện tại

### Cải tiến Cấu trúc Thư mục
- **Chuẩn hóa Tên**: Đổi tên "mcp transport" thành "mcp-transport" để nhất quán với các thư mục chủ đề nâng cao khác
- **Tổ chức Nội dung**: Tất cả các thư mục 05-AdvancedTopics hiện tuân theo mẫu đặt tên nhất quán (mcp-[chủ đề])

### Nâng cao Chất lượng Tài liệu
- **Sự phù hợp với MCP Specification**: Tất cả nội dung mới tham chiếu đến MCP Specification hiện tại 2025-06-18
- **Ví dụ Đa Ngôn ngữ**: Các ví dụ mã toàn diện bằng C#, TypeScript, và Python
- **Tập trung vào Doanh nghiệp**: Các mô hình sẵn sàng sản xuất và tích hợp đám mây Azure xuyên suốt
- **Tài liệu Hình ảnh**: Biểu đồ Mermaid để trực quan hóa kiến trúc và luồng

## 18 Tháng 8, 2025

### Cập nhật Tài liệu Toàn diện - Tiêu chuẩn MCP 2025-06-18

#### Thực hành Bảo mật MCP (02-Security/) - Hiện đại hóa Hoàn toàn
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Viết lại hoàn toàn phù hợp với MCP Specification 2025-06-18
  - **Yêu cầu Bắt buộc**: Thêm các yêu cầu MUST/MUST NOT rõ ràng từ đặc tả chính thức với các chỉ báo trực quan rõ ràng
  - **12 Thực hành Bảo mật Cốt lõi**: Cấu trúc lại từ danh sách 15 mục thành các lĩnh vực bảo mật toàn diện
    - Bảo mật Token & Xác thực với tích hợp nhà cung cấp danh tính bên ngoài
    - Quản lý Phiên & Bảo mật Vận chuyển với các yêu cầu mã hóa
    - Bảo vệ Mối đe dọa Cụ thể AI với tích hợp Microsoft Prompt Shields
    - Kiểm soát Truy cập & Quyền với nguyên tắc quyền tối thiểu
    - An toàn Nội dung & Giám sát với tích hợp Azure Content Safety
    - Bảo mật Chuỗi Cung ứng với xác minh thành phần toàn diện
    - Bảo mật OAuth & Phòng ngừa Confused Deputy với triển khai PKCE
    - Phản hồi & Khôi phục Sự cố với khả năng tự động hóa
    - Tuân thủ & Quản trị với sự phù hợp quy định
    - Kiểm soát Bảo mật Nâng cao với kiến trúc zero trust
    - Tích hợp Hệ sinh thái Bảo mật Microsoft với các giải pháp toàn diện
    - Tiến hóa Bảo mật Liên tục với các thực hành thích ứng
  - **Giải pháp Bảo mật Microsoft**: Hướng dẫn tích hợp nâng cao cho Prompt Shields, Azure Content Safety, Entra ID, và GitHub Advanced Security
  - **Tài nguyên Triển khai**: Liên kết tài nguyên toàn diện được phân loại theo Tài liệu MCP Chính thức, Giải pháp Bảo mật Microsoft, Tiêu chuẩn Bảo mật, và Hướng dẫn Triển khai

#### Kiểm soát Bảo mật Nâng cao (02-Security/) - Triển khai Doanh nghiệp
- **MCP-SECURITY-CONTROLS-2025.md**: Viết lại hoàn toàn với khung bảo mật cấp doanh nghiệp
  - **9 Lĩnh vực Bảo mật Toàn diện**: Mở rộng từ các kiểm soát cơ bản đến khung chi tiết cấp doanh nghiệp
    - Xác thực & Ủy quyền Nâng cao với tích hợp Microsoft Entra ID
    - Bảo mật Token & Kiểm soát Chống Chuyển Tiếp với xác thực toàn diện
    - Kiểm soát Bảo mật Phiên với phòng ngừa chiếm đoạt
    - Kiểm soát Bảo mật Cụ thể AI với phòng ngừa tiêm lệnh và đầu độc công cụ
    - Phòng ngừa Tấn công Confused Deputy với bảo mật proxy OAuth
    - Bảo mật Thực thi Công cụ với cách ly và sandboxing
    - Kiểm soát Bảo mật Chuỗi Cung ứng với xác minh phụ thuộc
    - Kiểm soát Giám sát & Phát hiện với tích hợp SIEM
    - Phản hồi & Khôi phục Sự cố với khả năng tự động hóa
  - **Ví dụ Triển khai**: Thêm các khối cấu hình YAML chi tiết và ví dụ mã
  - **Tích hợp Giải pháp Microsoft**: Phạm vi toàn diện về các dịch vụ bảo mật Azure, GitHub Advanced Security, và quản lý danh tính doanh nghiệp

#### Chủ đề Nâng cao Bảo mật (05-AdvancedTopics/mcp-security/) - Triển khai Sẵn sàng Sản xuất
- **README.md**: Viết lại hoàn toàn cho triển khai bảo mật cấp doanh nghiệp
  - **Sự phù hợp với Đặc tả Hiện tại**: Cập nhật theo MCP Specification 2025-06-18 với các yêu cầu bảo mật bắt buộc
  - **Xác thực Nâng cao**: Tích hợp Microsoft Entra ID với các ví dụ toàn diện .NET và Java Spring Security
  - **Tích hợp Bảo mật AI**: Triển khai Microsoft Prompt Shields và Azure Content Safety với các ví dụ Python chi tiết
  - **Giảm thiểu Mối đe dọa Nâng cao**: Các ví dụ triển khai toàn diện cho
    - Phòng ngừa Tấn công Confused Deputy với PKCE và xác thực sự đồng ý của người dùng
    - Phòng ngừa Chuyển Tiếp Token với xác thực đối tượng và quản lý token an toàn
    - Phòng ngừa Chiếm đoạt Phiên với liên kết mã hóa và phân tích hành vi
  - **Tích hợp Bảo mật Doanh nghiệp**: Giám sát Application Insights của Azure, các đường dẫn phát hiện mối đe dọa, và bảo mật chuỗi cung ứng
  - **Danh sách Kiểm tra Triển khai**: Kiểm soát bảo mật bắt buộc so với khuyến nghị rõ ràng với lợi ích hệ sinh thái bảo mật Microsoft

### Cải tiến Chất lượng Tài liệu & Sự phù hợp Tiêu chuẩn
- **Tham chiếu Đặc tả**: Cập nhật tất cả các tham chiếu đến MCP Specification hiện tại 2025-06-18
- **Hệ sinh thái Bảo mật Microsoft**: Hướng dẫn tích hợp nâng cao xuyên suốt tất cả tài liệu bảo mật
- **Hướng dẫn Triển khai Thực tế**: Thêm các ví dụ mã chi tiết trong .NET, Java, và Python với các mô hình doanh nghiệp
- **Tổ chức Tài nguyên**: Phân loại toàn diện tài liệu chính thức, tiêu chuẩn bảo mật, và hướng dẫn triển khai
- **Chỉ báo Trực quan**: Đánh dấu rõ ràng các yêu cầu bắt buộc so với thực hành khuyến nghị

#### Khái niệm Cốt lõi (01-CoreConcepts/) - Hiện đại hóa Hoàn toàn
- **Cập nhật Phiên bản Giao thức**: Cập nhật để tham chiếu MCP Specification hiện tại 2025-06-18 với định dạng phiên bản theo ngày (YYYY-MM-DD)
- **Tinh chỉnh Kiến trúc**: Mô tả nâng cao về Hosts, Clients, và Servers để phản ánh các mô hình kiến trúc MCP hiện tại
  - Hosts hiện được định nghĩa rõ ràng là các ứng dụng AI phối hợp nhiều kết nối client MCP
  - Clients được mô tả là các bộ kết nối giao thức duy trì mối quan hệ một-một với server
  - Servers được nâng cao với các kịch bản triển khai cục bộ so với từ xa
- **Tái cấu trúc Nguyên thủy**: Viết lại hoàn toàn các nguyên thủy server và client
  - Nguyên thủy Server: Resources (nguồn dữ liệu), Prompts (mẫu), Tools (chức năng có thể thực thi) với các giải thích và ví dụ chi tiết
  - Nguyên thủy Client: Sampling (hoàn thành LLM), Elicitation (đầu vào người dùng), Logging (gỡ lỗi/giám sát)
  - Cập nhật với các mẫu phương pháp khám phá (`*/list`), truy xuất (`*/get`), và thực thi (`*/call`)
- **Kiến trúc Giao thức**: Giới thiệu mô hình kiến trúc hai lớp
  - Lớp Dữ liệu: Nền tảng JSON-RPC 2.0 với quản lý vòng đời và nguyên thủy
  - Lớp Vận chuyển: STDIO (cục bộ) và HTTP có thể truyền với SSE (từ xa)
- **Khung Bảo mật**: Các nguyên tắc bảo mật toàn diện bao gồm sự đồng ý rõ ràng của người dùng, bảo vệ quyền riêng tư dữ liệu, an toàn thực thi công cụ, và bảo mật lớp vận chuyển
- **Mẫu Giao tiếp**: Cập nhật các tin nhắn giao thức để hiển thị luồng khởi tạo, khám phá, thực thi, và thông báo
- **Ví dụ Mã**: Làm mới các ví dụ đa ngôn ngữ (.NET, Java, Python, JavaScript) để phản ánh các mẫu SDK MCP hiện tại

#### Bảo mật (02-Security/) - Viết lại Bảo mật Toàn diện  
- **Sự phù hợp Tiêu chuẩn**: Phù hợp hoàn toàn với các yêu cầu bảo mật MCP Specification 2025-06-18
- **Tiến hóa Xác thực**: Tài liệu hóa sự tiến hóa từ các server OAuth tùy chỉnh sang ủy quyền nhà cung cấp danh tính bên ngoài (Microsoft Entra ID)
- **Phân tích Mối đe dọa Cụ thể AI**: Phạm vi nâng cao về các vector tấn công AI hiện đại
  - Các kịch bản tấn công tiêm lệnh chi tiết với ví dụ thực tế
  - Cơ chế đầu độc công cụ và các mẫu tấn công "rug pull"
  - Đầu độc cửa sổ ngữ cảnh và các cuộc tấn công gây nhầm lẫn mô hình
- **Giải pháp Bảo mật AI Microsoft**: Phạm vi toàn diện về hệ sinh thái bảo mật Microsoft
  - AI Prompt Shields với các kỹ thuật phát hiện, spotlighting, và delimiter nâng cao
  - Mô hình tích hợp Azure Content Safety
  - GitHub Advanced Security để bảo vệ chuỗi cung ứng
- **Giảm thiểu Mối đe dọa Nâng cao**: Các kiểm soát bảo mật chi tiết cho
  - Chiếm đoạt phiên với các kịch bản tấn công MCP cụ thể và yêu cầu ID phiên mã hóa
  - Các vấn đề Confused Deputy trong các kịch bản proxy MCP với yêu cầu sự đồng ý rõ ràng
  - Các lỗ hổng chuyển tiếp token với các kiểm soát xác thực bắt buộc
- **Bảo mật Chuỗi Cung ứng**: Mở rộng phạm vi chuỗi cung ứng AI bao gồm các mô hình nền tảng, dịch vụ embeddings, nhà cung cấp ngữ cảnh, và API bên thứ ba
- **Bảo mật Nền tảng**: Tích hợp nâng cao với các mẫu bảo mật doanh nghiệp bao gồm kiến trúc zero trust và hệ sinh thái bảo mật Microsoft
- **Tổ chức Tài nguyên**: Phân loại toàn diện các liên kết tài nguyên theo loại (Tài liệu Chính thức, Tiêu chuẩn, Nghiên cứu, Giải pháp Microsoft, Hướng dẫn Triển khai)

### Cải tiến Chất lượng Tài liệu
- **Mục tiêu Học tập Có cấu trúc**: Nâng cao mục tiêu học tập với các kết quả cụ thể, có thể hành động
- **Tham chiếu Chéo**: Thêm liên kết giữa các chủ đề bảo mật và khái niệm cốt lõi liên quan
- **Thông tin Hiện tại**: Cập nhật tất cả các tham chiếu ngày và liên kết đặc tả đến các tiêu chuẩn hiện tại
- **Hướng dẫn Triển khai**: Thêm các hướng dẫn triển khai cụ thể, có thể hành động xuyên suốt cả hai phần

## 16 Tháng 7, 2025

### README và Cải tiến Điều hướng
- Thiết kế lại hoàn toàn điều hướng giáo trình trong README.md
- Thay thế thẻ `<details>` bằng định dạng bảng dễ tiếp cận hơn
- Tạo các tùy chọn bố cục thay thế trong thư mục "alternative_layouts" mới
- Thêm các ví dụ điều hướng kiểu thẻ, kiểu tab, và kiểu accordion
- Cập nhật phần cấu trúc kho lưu trữ để bao gồm tất cả các tệp mới nhất
- Nâng cao phần "Cách sử dụng Giáo trình này" với các khuyến nghị rõ ràng
- Cập nhật liên kết đặc tả MCP để trỏ đến các URL chính xác
- Thêm phần Kỹ thuật Ngữ cảnh (5.14) vào cấu trúc giáo trình

### Cập nhật Hướng dẫn Học tập
- Viết lại hoàn toàn hướng dẫn học tập để phù hợp với cấu trúc kho lưu trữ hiện tại
- Thêm các phần mới cho MCP Clients và Tools, và các MCP Servers phổ biến
- Cập nhật Bản đồ Giáo trình Trực quan để phản ánh chính xác tất cả các chủ đề
- Nâng cao mô tả về Chủ đề Nâng cao để bao quát tất cả các lĩnh vực chuyên biệt
- Cập nhật phần Nghiên cứu Tình huống để phản ánh các ví dụ thực tế
- Thêm nhật ký thay đổi toàn diện này

### Đóng góp Cộng đồng (06-CommunityContributions/)
- Thêm thông tin chi tiết về các MCP servers cho tạo hình ảnh
- Thêm phần toàn diện về sử dụng Claude trong VSCode
- Thêm hướng dẫn thiết lập và sử dụng client terminal Cline
- Cập nhật phần MCP client để bao gồm tất cả các tùy chọn client phổ biến
- Nâng cao các ví dụ đóng góp với các mẫu mã chính xác hơn

### Chủ đề

---

**Tuyên bố miễn trừ trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ bản địa nên được coi là nguồn thông tin chính thức. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp từ con người. Chúng tôi không chịu trách nhiệm cho bất kỳ sự hiểu lầm hoặc diễn giải sai nào phát sinh từ việc sử dụng bản dịch này.