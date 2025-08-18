<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "245b03ae1e7973094fe82b8051ae0939",
  "translation_date": "2025-08-18T17:05:01+00:00",
  "source_file": "changelog.md",
  "language_code": "vi"
}
-->
# Nhật ký thay đổi: Giáo trình MCP cho Người mới bắt đầu

Tài liệu này là bản ghi lại tất cả các thay đổi quan trọng được thực hiện đối với giáo trình Model Context Protocol (MCP) dành cho người mới bắt đầu. Các thay đổi được ghi lại theo thứ tự ngược thời gian (thay đổi mới nhất ở trên cùng).

## Ngày 18 tháng 8, 2025

### Cập nhật toàn diện tài liệu - Tiêu chuẩn MCP 2025-06-18

#### Thực hành bảo mật MCP (02-Security/) - Hiện đại hóa hoàn toàn
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Viết lại hoàn toàn phù hợp với MCP Specification 2025-06-18
  - **Yêu cầu bắt buộc**: Thêm các yêu cầu MUST/MUST NOT rõ ràng từ đặc tả chính thức với các chỉ báo trực quan
  - **12 Thực hành bảo mật cốt lõi**: Tái cấu trúc từ danh sách 15 mục thành các lĩnh vực bảo mật toàn diện
    - Bảo mật Token & Xác thực với tích hợp nhà cung cấp danh tính bên ngoài
    - Quản lý Phiên & Bảo mật Truyền tải với các yêu cầu mã hóa
    - Bảo vệ Mối đe dọa AI với tích hợp Microsoft Prompt Shields
    - Kiểm soát Truy cập & Quyền với nguyên tắc quyền tối thiểu
    - An toàn Nội dung & Giám sát với tích hợp Azure Content Safety
    - Bảo mật Chuỗi Cung ứng với xác minh thành phần toàn diện
    - Bảo mật OAuth & Phòng chống Tấn công Confused Deputy với triển khai PKCE
    - Phản hồi & Phục hồi Sự cố với khả năng tự động hóa
    - Tuân thủ & Quản trị với sự phù hợp quy định
    - Kiểm soát Bảo mật Nâng cao với kiến trúc zero trust
    - Tích hợp Hệ sinh thái Bảo mật Microsoft với các giải pháp toàn diện
    - Tiến hóa Bảo mật Liên tục với các thực hành thích ứng
  - **Giải pháp Bảo mật Microsoft**: Hướng dẫn tích hợp nâng cao cho Prompt Shields, Azure Content Safety, Entra ID, và GitHub Advanced Security
  - **Tài nguyên Triển khai**: Phân loại liên kết tài nguyên toàn diện theo Tài liệu MCP Chính thức, Giải pháp Bảo mật Microsoft, Tiêu chuẩn Bảo mật, và Hướng dẫn Triển khai

#### Kiểm soát Bảo mật Nâng cao (02-Security/) - Triển khai Doanh nghiệp
- **MCP-SECURITY-CONTROLS-2025.md**: Đại tu hoàn toàn với khung bảo mật cấp doanh nghiệp
  - **9 Lĩnh vực Bảo mật Toàn diện**: Mở rộng từ các kiểm soát cơ bản đến khung chi tiết cấp doanh nghiệp
    - Xác thực & Ủy quyền Nâng cao với tích hợp Microsoft Entra ID
    - Bảo mật Token & Kiểm soát Chống Truyền qua với xác minh toàn diện
    - Kiểm soát Bảo mật Phiên với phòng chống chiếm đoạt
    - Kiểm soát Bảo mật Cụ thể AI với phòng chống tiêm lệnh và đầu độc công cụ
    - Phòng chống Tấn công Confused Deputy với bảo mật proxy OAuth
    - Bảo mật Thực thi Công cụ với cách ly và sandboxing
    - Kiểm soát Bảo mật Chuỗi Cung ứng với xác minh phụ thuộc
    - Kiểm soát Giám sát & Phát hiện với tích hợp SIEM
    - Phản hồi & Phục hồi Sự cố với khả năng tự động hóa
  - **Ví dụ Triển khai**: Thêm các khối cấu hình YAML chi tiết và ví dụ mã
  - **Tích hợp Giải pháp Microsoft**: Bao phủ toàn diện các dịch vụ bảo mật Azure, GitHub Advanced Security, và quản lý danh tính doanh nghiệp

#### Bảo mật Chủ đề Nâng cao (05-AdvancedTopics/mcp-security/) - Triển khai Sẵn sàng Sản xuất
- **README.md**: Viết lại hoàn toàn cho triển khai bảo mật doanh nghiệp
  - **Phù hợp với Đặc tả Hiện tại**: Cập nhật theo MCP Specification 2025-06-18 với các yêu cầu bảo mật bắt buộc
  - **Xác thực Nâng cao**: Tích hợp Microsoft Entra ID với các ví dụ chi tiết trong .NET và Java Spring Security
  - **Tích hợp Bảo mật AI**: Triển khai Microsoft Prompt Shields và Azure Content Safety với các ví dụ Python chi tiết
  - **Giảm thiểu Mối đe dọa Nâng cao**: Các ví dụ triển khai toàn diện cho
    - Phòng chống Tấn công Confused Deputy với PKCE và xác thực sự đồng ý của người dùng
    - Phòng chống Truyền qua Token với xác minh đối tượng và quản lý token an toàn
    - Phòng chống Chiếm đoạt Phiên với liên kết mã hóa và phân tích hành vi
  - **Tích hợp Bảo mật Doanh nghiệp**: Giám sát Azure Application Insights, đường dẫn phát hiện mối đe dọa, và bảo mật chuỗi cung ứng
  - **Danh sách Kiểm tra Triển khai**: Rõ ràng giữa các kiểm soát bảo mật bắt buộc và khuyến nghị với lợi ích từ hệ sinh thái bảo mật Microsoft

### Cải thiện Chất lượng & Tiêu chuẩn Tài liệu
- **Tham chiếu Đặc tả**: Cập nhật tất cả tham chiếu đến MCP Specification 2025-06-18 hiện tại
- **Hệ sinh thái Bảo mật Microsoft**: Hướng dẫn tích hợp nâng cao xuyên suốt tất cả tài liệu bảo mật
- **Triển khai Thực tiễn**: Thêm các ví dụ mã chi tiết trong .NET, Java, và Python với các mẫu doanh nghiệp
- **Tổ chức Tài nguyên**: Phân loại toàn diện tài liệu chính thức, tiêu chuẩn bảo mật, và hướng dẫn triển khai
- **Chỉ báo Trực quan**: Đánh dấu rõ ràng các yêu cầu bắt buộc so với thực hành khuyến nghị

#### Khái niệm Cốt lõi (01-CoreConcepts/) - Hiện đại hóa Hoàn toàn
- **Cập nhật Phiên bản Giao thức**: Cập nhật để tham chiếu MCP Specification 2025-06-18 hiện tại với định dạng phiên bản theo ngày (YYYY-MM-DD)
- **Tinh chỉnh Kiến trúc**: Mô tả nâng cao về Hosts, Clients, và Servers để phản ánh các mẫu kiến trúc MCP hiện tại
  - Hosts được định nghĩa rõ ràng là các ứng dụng AI điều phối nhiều kết nối client MCP
  - Clients được mô tả là các kết nối giao thức duy trì mối quan hệ một-một với server
  - Servers được nâng cao với các kịch bản triển khai cục bộ và từ xa
- **Tái cấu trúc Nguyên thủy**: Đại tu hoàn toàn các nguyên thủy server và client
  - Nguyên thủy Server: Resources (nguồn dữ liệu), Prompts (mẫu), Tools (chức năng thực thi) với các giải thích và ví dụ chi tiết
  - Nguyên thủy Client: Sampling (hoàn thành LLM), Elicitation (đầu vào người dùng), Logging (gỡ lỗi/giám sát)
  - Cập nhật với các mẫu phương pháp hiện tại: khám phá (`*/list`), truy xuất (`*/get`), và thực thi (`*/call`)
- **Kiến trúc Giao thức**: Giới thiệu mô hình kiến trúc hai lớp
  - Lớp Dữ liệu: Nền tảng JSON-RPC 2.0 với quản lý vòng đời và các nguyên thủy
  - Lớp Truyền tải: STDIO (cục bộ) và HTTP có thể truyền phát với SSE (từ xa)
- **Khung Bảo mật**: Các nguyên tắc bảo mật toàn diện bao gồm sự đồng ý rõ ràng của người dùng, bảo vệ quyền riêng tư dữ liệu, an toàn thực thi công cụ, và bảo mật lớp truyền tải
- **Mẫu Giao tiếp**: Cập nhật các thông điệp giao thức để hiển thị các luồng khởi tạo, khám phá, thực thi, và thông báo
- **Ví dụ Mã**: Làm mới các ví dụ đa ngôn ngữ (.NET, Java, Python, JavaScript) để phản ánh các mẫu MCP SDK hiện tại

#### Bảo mật (02-Security/) - Đại tu Bảo mật Toàn diện  
- **Phù hợp Tiêu chuẩn**: Phù hợp hoàn toàn với các yêu cầu bảo mật MCP Specification 2025-06-18
- **Tiến hóa Xác thực**: Tài liệu hóa sự tiến hóa từ các máy chủ OAuth tùy chỉnh sang ủy quyền nhà cung cấp danh tính bên ngoài (Microsoft Entra ID)
- **Phân tích Mối đe dọa Cụ thể AI**: Tăng cường phạm vi các vector tấn công AI hiện đại
  - Các kịch bản tấn công tiêm lệnh chi tiết với ví dụ thực tế
  - Cơ chế đầu độc công cụ và các mẫu tấn công "rug pull"
  - Đầu độc cửa sổ ngữ cảnh và các cuộc tấn công gây nhầm lẫn mô hình
- **Giải pháp Bảo mật AI Microsoft**: Bao phủ toàn diện hệ sinh thái bảo mật Microsoft
  - AI Prompt Shields với phát hiện nâng cao, spotlighting, và kỹ thuật delimiter
  - Mẫu tích hợp Azure Content Safety
  - GitHub Advanced Security để bảo vệ chuỗi cung ứng
- **Giảm thiểu Mối đe dọa Nâng cao**: Các kiểm soát bảo mật chi tiết cho
  - Chiếm đoạt Phiên với các kịch bản tấn công MCP cụ thể và yêu cầu ID phiên mã hóa
  - Các vấn đề Confused Deputy trong các kịch bản proxy MCP với yêu cầu sự đồng ý rõ ràng
  - Lỗ hổng Truyền qua Token với các kiểm soát xác minh bắt buộc
- **Bảo mật Chuỗi Cung ứng**: Mở rộng phạm vi chuỗi cung ứng AI bao gồm các mô hình nền tảng, dịch vụ embeddings, nhà cung cấp ngữ cảnh, và API bên thứ ba
- **Bảo mật Nền tảng**: Tăng cường tích hợp với các mẫu bảo mật doanh nghiệp bao gồm kiến trúc zero trust và hệ sinh thái bảo mật Microsoft
- **Tổ chức Tài nguyên**: Phân loại liên kết tài nguyên toàn diện theo loại (Tài liệu Chính thức, Tiêu chuẩn, Nghiên cứu, Giải pháp Microsoft, Hướng dẫn Triển khai)

### Cải thiện Chất lượng Tài liệu
- **Mục tiêu Học tập Có cấu trúc**: Tăng cường mục tiêu học tập với các kết quả cụ thể, có thể hành động
- **Tham chiếu Chéo**: Thêm liên kết giữa các chủ đề bảo mật và khái niệm cốt lõi liên quan
- **Thông tin Hiện tại**: Cập nhật tất cả các tham chiếu ngày và liên kết đặc tả theo tiêu chuẩn hiện tại
- **Hướng dẫn Triển khai**: Thêm các hướng dẫn triển khai cụ thể, có thể hành động xuyên suốt cả hai phần

## Ngày 16 tháng 7, 2025

### Cải tiến README và Điều hướng
- Thiết kế lại hoàn toàn điều hướng giáo trình trong README.md
- Thay thế thẻ `<details>` bằng định dạng bảng dễ tiếp cận hơn
- Tạo các tùy chọn bố cục thay thế trong thư mục "alternative_layouts" mới
- Thêm các ví dụ điều hướng kiểu thẻ, tab, và accordion
- Cập nhật phần cấu trúc kho lưu trữ để bao gồm tất cả các tệp mới nhất
- Tăng cường phần "Cách sử dụng giáo trình này" với các khuyến nghị rõ ràng
- Cập nhật liên kết đặc tả MCP để trỏ đến các URL chính xác
- Thêm phần Kỹ thuật Ngữ cảnh (5.14) vào cấu trúc giáo trình

### Cập nhật Hướng dẫn Học tập
- Sửa đổi hoàn toàn hướng dẫn học tập để phù hợp với cấu trúc kho lưu trữ hiện tại
- Thêm các phần mới cho MCP Clients và Tools, và các MCP Servers phổ biến
- Cập nhật Bản đồ Giáo trình Trực quan để phản ánh chính xác tất cả các chủ đề
- Tăng cường mô tả về Chủ đề Nâng cao để bao quát tất cả các lĩnh vực chuyên biệt
- Cập nhật phần Nghiên cứu Tình huống để phản ánh các ví dụ thực tế
- Thêm nhật ký thay đổi toàn diện này

### Đóng góp Cộng đồng (06-CommunityContributions/)
- Thêm thông tin chi tiết về các MCP servers cho tạo hình ảnh
- Thêm phần toàn diện về sử dụng Claude trong VSCode
- Thêm hướng dẫn thiết lập và sử dụng client terminal Cline
- Cập nhật phần MCP client để bao gồm tất cả các tùy chọn client phổ biến
- Tăng cường ví dụ đóng góp với các mẫu mã chính xác hơn

### Chủ đề Nâng cao (05-AdvancedTopics/)
- Tổ chức tất cả các thư mục chủ đề chuyên biệt với cách đặt tên nhất quán
- Thêm tài liệu và ví dụ về kỹ thuật ngữ cảnh
- Thêm tài liệu tích hợp agent Foundry
- Tăng cường tài liệu tích hợp bảo mật Entra ID

## Ngày 11 tháng 6, 2025

### Tạo ban đầu
- Phát hành phiên bản đầu tiên của giáo trình MCP cho Người mới bắt đầu
- Tạo cấu trúc cơ bản cho tất cả 10 phần chính
- Triển khai Bản đồ Giáo trình Trực quan để điều hướng
- Thêm các dự án mẫu ban đầu bằng nhiều ngôn ngữ lập trình

### Bắt đầu (03-GettingStarted/)
- Tạo các ví dụ triển khai server đầu tiên
- Thêm hướng dẫn phát triển client
- Bao gồm hướng dẫn tích hợp client LLM
- Thêm tài liệu tích hợp VS Code
- Triển khai các ví dụ server Server-Sent Events (SSE)

### Khái niệm Cốt lõi (01-CoreConcepts/)
- Thêm giải thích chi tiết về kiến trúc client-server
- Tạo tài liệu về các thành phần chính của giao thức
- Tài liệu hóa các mẫu thông điệp trong MCP

## Ngày 23 tháng 5, 2025

### Cấu trúc Kho lưu trữ
- Khởi tạo kho lưu trữ với cấu trúc thư mục cơ bản
- Tạo các tệp README cho mỗi phần chính
- Thiết lập cơ sở hạ tầng dịch thuật
- Thêm tài sản hình ảnh và sơ đồ

### Tài liệu
- Tạo README.md ban đầu với tổng quan giáo trình
- Thêm CODE_OF_CONDUCT.md và SECURITY.md
- Thiết lập SUPPORT.md với hướng dẫn nhận trợ giúp
- Tạo cấu trúc hướng dẫn học tập sơ bộ

## Ngày 15 tháng 4, 2025

### Lập kế hoạch và Khung
- Lập kế hoạch ban đầu cho giáo trình MCP cho Người mới bắt đầu
- Xác định mục tiêu học tập và đối tượng mục tiêu
- Phác thảo cấu trúc 10 phần của giáo trình
- Phát triển khung khái niệm cho các ví dụ và nghiên cứu tình huống
- Tạo các ví dụ nguyên mẫu ban đầu cho các khái niệm chính

**Tuyên bố miễn trừ trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ bản địa nên được coi là nguồn thông tin chính thức. Đối với các thông tin quan trọng, khuyến nghị sử dụng dịch vụ dịch thuật chuyên nghiệp bởi con người. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc diễn giải sai nào phát sinh từ việc sử dụng bản dịch này.