<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-17T07:41:28+00:00",
  "source_file": "02-Security/readme.md",
  "language_code": "vi"
}
-->
# Các Thực Hành Tốt Nhất Về Bảo Mật

Áp dụng Giao thức Ngữ cảnh Mô hình (MCP) mang lại những khả năng mạnh mẽ mới cho các ứng dụng dựa trên AI, nhưng cũng giới thiệu những thách thức bảo mật độc đáo vượt ra ngoài các rủi ro phần mềm truyền thống. Ngoài những mối quan tâm đã được thiết lập như mã hóa an toàn, quyền tối thiểu và bảo mật chuỗi cung ứng, MCP và khối lượng công việc AI đối mặt với các mối đe dọa mới như tiêm nhiễm gợi ý, đầu độc công cụ và thay đổi công cụ động. Những rủi ro này có thể dẫn đến rò rỉ dữ liệu, vi phạm quyền riêng tư và hành vi hệ thống không mong muốn nếu không được quản lý đúng cách.

Bài học này khám phá các rủi ro bảo mật có liên quan nhất liên quan đến MCP — bao gồm xác thực, ủy quyền, quyền hạn quá mức, tiêm nhiễm gợi ý gián tiếp và lỗ hổng chuỗi cung ứng — và cung cấp các biện pháp kiểm soát hành động và thực hành tốt nhất để giảm thiểu chúng. Bạn cũng sẽ học cách tận dụng các giải pháp của Microsoft như Prompt Shields, Azure Content Safety và GitHub Advanced Security để củng cố triển khai MCP của bạn. Bằng cách hiểu và áp dụng các biện pháp kiểm soát này, bạn có thể giảm đáng kể khả năng xảy ra vi phạm bảo mật và đảm bảo hệ thống AI của bạn vẫn mạnh mẽ và đáng tin cậy.

# Mục Tiêu Học Tập

Đến cuối bài học này, bạn sẽ có thể:

- Xác định và giải thích các rủi ro bảo mật độc đáo do Giao thức Ngữ cảnh Mô hình (MCP) giới thiệu, bao gồm tiêm nhiễm gợi ý, đầu độc công cụ, quyền hạn quá mức và lỗ hổng chuỗi cung ứng.
- Mô tả và áp dụng các biện pháp kiểm soát giảm thiểu hiệu quả cho các rủi ro bảo mật MCP, chẳng hạn như xác thực mạnh mẽ, quyền tối thiểu, quản lý mã thông báo an toàn và xác minh chuỗi cung ứng.
- Hiểu và tận dụng các giải pháp của Microsoft như Prompt Shields, Azure Content Safety và GitHub Advanced Security để bảo vệ MCP và khối lượng công việc AI.
- Nhận thức tầm quan trọng của việc xác thực siêu dữ liệu công cụ, giám sát các thay đổi động và bảo vệ chống lại các cuộc tấn công tiêm nhiễm gợi ý gián tiếp.
- Tích hợp các thực hành bảo mật đã được thiết lập — như mã hóa an toàn, làm cứng máy chủ và kiến trúc không tin tưởng — vào triển khai MCP của bạn để giảm khả năng và tác động của các vi phạm bảo mật.

# Kiểm Soát Bảo Mật MCP

Bất kỳ hệ thống nào có quyền truy cập vào các tài nguyên quan trọng đều có những thách thức bảo mật ngầm. Các thách thức bảo mật thường có thể được giải quyết thông qua việc áp dụng đúng các biện pháp kiểm soát và khái niệm bảo mật cơ bản. Vì MCP chỉ mới được định nghĩa gần đây, đặc điểm kỹ thuật đang thay đổi rất nhanh chóng và khi giao thức phát triển. Cuối cùng, các biện pháp kiểm soát bảo mật trong nó sẽ trưởng thành, cho phép tích hợp tốt hơn với các kiến trúc và thực hành bảo mật doanh nghiệp và đã được thiết lập.

Nghiên cứu được công bố trong [Microsoft Digital Defense Report](https://aka.ms/mddr) cho biết rằng 98% các vi phạm được báo cáo sẽ được ngăn chặn bằng vệ sinh bảo mật mạnh mẽ và biện pháp bảo vệ tốt nhất chống lại bất kỳ loại vi phạm nào là thực hiện vệ sinh bảo mật cơ bản của bạn, thực hành mã hóa an toàn tốt nhất và bảo mật chuỗi cung ứng đúng cách — những thực hành đã được thử nghiệm mà chúng ta đã biết vẫn tạo ra tác động lớn nhất trong việc giảm rủi ro bảo mật.

Hãy xem một số cách bạn có thể bắt đầu giải quyết các rủi ro bảo mật khi áp dụng MCP.

# Xác Thực Máy Chủ MCP (nếu triển khai MCP của bạn trước ngày 26 tháng 4 năm 2025)

> **Lưu ý:** Thông tin sau đây là chính xác tính đến ngày 26 tháng 4 năm 2025. Giao thức MCP đang liên tục phát triển và các triển khai trong tương lai có thể giới thiệu các mẫu và biện pháp kiểm soát xác thực mới. Để cập nhật và hướng dẫn mới nhất, luôn tham khảo [MCP Specification](https://spec.modelcontextprotocol.io/) và [MCP GitHub repository](https://github.com/modelcontextprotocol).

### Tuyên bố vấn đề
Đặc điểm kỹ thuật MCP ban đầu giả định rằng các nhà phát triển sẽ tự viết máy chủ xác thực của họ. Điều này yêu cầu kiến thức về OAuth và các ràng buộc bảo mật liên quan. Các máy chủ MCP hoạt động như các Máy chủ Ủy quyền OAuth 2.0, quản lý xác thực người dùng cần thiết trực tiếp thay vì ủy thác nó cho một dịch vụ bên ngoài như Microsoft Entra ID. Tính đến ngày 26 tháng 4 năm 2025, một bản cập nhật cho đặc điểm kỹ thuật MCP cho phép các máy chủ MCP ủy thác xác thực người dùng cho một dịch vụ bên ngoài.

### Rủi ro
- Logic ủy quyền cấu hình sai trong máy chủ MCP có thể dẫn đến lộ dữ liệu nhạy cảm và áp dụng không đúng các kiểm soát truy cập.
- Trộm cắp mã thông báo OAuth trên máy chủ MCP cục bộ. Nếu bị đánh cắp, mã thông báo có thể được sử dụng để giả mạo máy chủ MCP và truy cập tài nguyên và dữ liệu từ dịch vụ mà mã thông báo OAuth dành cho.

### Biện pháp kiểm soát giảm thiểu
- **Xem xét và Làm cứng Logic Ủy quyền:** Kiểm tra cẩn thận việc triển khai ủy quyền của máy chủ MCP của bạn để đảm bảo chỉ những người dùng và khách hàng dự kiến mới có thể truy cập tài nguyên nhạy cảm. Để biết hướng dẫn thực tế, xem [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) và [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Thực thi Thực hành Mã thông báo An toàn:** Tuân theo [thực hành tốt nhất của Microsoft về xác thực và thời gian sống của mã thông báo](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) để ngăn chặn việc sử dụng sai mã thông báo truy cập và giảm nguy cơ phát lại hoặc trộm cắp mã thông báo.
- **Bảo vệ Lưu trữ Mã thông báo:** Luôn lưu trữ mã thông báo một cách an toàn và sử dụng mã hóa để bảo vệ chúng khi nghỉ ngơi và trong quá trình truyền tải. Để biết mẹo triển khai, xem [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Quyền Hạn Quá Mức Cho Máy Chủ MCP

### Tuyên bố vấn đề
Máy chủ MCP có thể đã được cấp quyền hạn quá mức cho dịch vụ/tài nguyên mà chúng đang truy cập. Ví dụ, một máy chủ MCP là một phần của ứng dụng bán hàng AI kết nối với kho dữ liệu doanh nghiệp nên có quyền truy cập được giới hạn trong dữ liệu bán hàng và không được phép truy cập tất cả các tệp trong kho. Quay lại nguyên tắc quyền tối thiểu (một trong những nguyên tắc bảo mật lâu đời nhất), không có tài nguyên nào nên có quyền vượt quá những gì cần thiết để thực hiện các nhiệm vụ mà nó được dự định cho. AI trình bày một thách thức gia tăng trong không gian này vì để cho phép nó linh hoạt, có thể khó xác định các quyền chính xác cần thiết.

### Rủi ro
- Việc cấp quyền hạn quá mức có thể cho phép rò rỉ hoặc sửa đổi dữ liệu mà máy chủ MCP không được dự định có thể truy cập. Điều này cũng có thể là vấn đề quyền riêng tư nếu dữ liệu là thông tin cá nhân có thể nhận dạng (PII).

### Biện pháp kiểm soát giảm thiểu
- **Áp dụng Nguyên tắc Quyền Tối Thiểu:** Chỉ cấp cho máy chủ MCP các quyền tối thiểu cần thiết để thực hiện các nhiệm vụ yêu cầu. Thường xuyên xem xét và cập nhật các quyền này để đảm bảo chúng không vượt quá những gì cần thiết. Để biết hướng dẫn chi tiết, xem [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Sử dụng Kiểm soát Truy cập Dựa trên Vai trò (RBAC):** Gán vai trò cho máy chủ MCP mà được giới hạn chặt chẽ đối với các tài nguyên và hành động cụ thể, tránh các quyền rộng hoặc không cần thiết.
- **Giám sát và Kiểm tra Quyền hạn:** Liên tục giám sát việc sử dụng quyền và kiểm tra nhật ký truy cập để phát hiện và khắc phục các quyền quá mức hoặc không sử dụng kịp thời.

# Các Cuộc Tấn Công Tiêm Nhiễm Gợi Ý Gián Tiếp

### Tuyên bố vấn đề

Các máy chủ MCP độc hại hoặc bị xâm nhập có thể giới thiệu các rủi ro đáng kể bằng cách lộ dữ liệu khách hàng hoặc cho phép các hành động không mong muốn. Những rủi ro này đặc biệt liên quan trong khối lượng công việc dựa trên AI và MCP, nơi:

- **Các Cuộc Tấn Công Tiêm Nhiễm Gợi Ý**: Kẻ tấn công nhúng các hướng dẫn độc hại vào gợi ý hoặc nội dung bên ngoài, khiến hệ thống AI thực hiện các hành động không mong muốn hoặc lộ dữ liệu nhạy cảm. Tìm hiểu thêm: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Đầu Độc Công Cụ**: Kẻ tấn công thao túng siêu dữ liệu công cụ (chẳng hạn như mô tả hoặc tham số) để ảnh hưởng đến hành vi của AI, có thể vượt qua các biện pháp kiểm soát bảo mật hoặc rò rỉ dữ liệu. Chi tiết: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Tiêm Nhiễm Gợi Ý Xuyên Miền**: Các hướng dẫn độc hại được nhúng trong tài liệu, trang web hoặc email, sau đó được xử lý bởi AI, dẫn đến rò rỉ hoặc thao túng dữ liệu.
- **Thay Đổi Công Cụ Động (Rug Pulls)**: Các định nghĩa công cụ có thể được thay đổi sau khi người dùng phê duyệt, giới thiệu các hành vi độc hại mới mà không có sự nhận biết của người dùng.

Những lỗ hổng này nhấn mạnh sự cần thiết phải xác thực, giám sát và kiểm soát bảo mật mạnh mẽ khi tích hợp các máy chủ và công cụ MCP vào môi trường của bạn. Để tìm hiểu sâu hơn, xem các tài liệu tham khảo liên kết ở trên.

**Tiêm Nhiễm Gợi Ý Gián Tiếp** (còn được gọi là tiêm nhiễm gợi ý xuyên miền hoặc XPIA) là một lỗ hổng nghiêm trọng trong các hệ thống AI tạo sinh, bao gồm cả những hệ thống sử dụng Giao thức Ngữ cảnh Mô hình (MCP). Trong cuộc tấn công này, các hướng dẫn độc hại được giấu trong nội dung bên ngoài — chẳng hạn như tài liệu, trang web hoặc email. Khi hệ thống AI xử lý nội dung này, nó có thể diễn giải các hướng dẫn nhúng như là các lệnh hợp lệ của người dùng, dẫn đến các hành động không mong muốn như rò rỉ dữ liệu, tạo ra nội dung có hại hoặc thao túng tương tác của người dùng. Để biết giải thích chi tiết và ví dụ thực tế, xem [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Một hình thức đặc biệt nguy hiểm của cuộc tấn công này là **Đầu Độc Công Cụ**. Tại đây, kẻ tấn công tiêm nhiễm các hướng dẫn độc hại vào siêu dữ liệu của các công cụ MCP (chẳng hạn như mô tả công cụ hoặc tham số). Vì các mô hình ngôn ngữ lớn (LLM) dựa vào siêu dữ liệu này để quyết định công cụ nào sẽ được gọi, các mô tả bị xâm nhập có thể lừa mô hình thực hiện các cuộc gọi công cụ trái phép hoặc vượt qua các biện pháp kiểm soát bảo mật. Những thao túng này thường không thể nhìn thấy đối với người dùng cuối nhưng có thể được diễn giải và thực hiện bởi hệ thống AI. Rủi ro này được tăng cường trong các môi trường máy chủ MCP được lưu trữ, nơi các định nghĩa công cụ có thể được cập nhật sau khi người dùng phê duyệt — một kịch bản đôi khi được gọi là "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Trong những trường hợp như vậy, một công cụ trước đây an toàn có thể sau đó được sửa đổi để thực hiện các hành động độc hại, chẳng hạn như rò rỉ dữ liệu hoặc thay đổi hành vi hệ thống, mà không có sự nhận biết của người dùng. Để biết thêm về vector tấn công này, xem [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

## Rủi ro
Các hành động AI không mong muốn trình bày một loạt các rủi ro bảo mật bao gồm rò rỉ dữ liệu và vi phạm quyền riêng tư.

### Biện pháp kiểm soát giảm thiểu
### Sử dụng lá chắn gợi ý để bảo vệ chống lại các cuộc tấn công Tiêm Nhiễm Gợi Ý Gián Tiếp
-----------------------------------------------------------------------------

**AI Prompt Shields** là một giải pháp do Microsoft phát triển để bảo vệ chống lại cả các cuộc tấn công tiêm nhiễm gợi ý trực tiếp và gián tiếp. Chúng giúp thông qua:

1.  **Phát hiện và Lọc**: Prompt Shields sử dụng các thuật toán máy học tiên tiến và xử lý ngôn ngữ tự nhiên để phát hiện và lọc các hướng dẫn độc hại nhúng trong nội dung bên ngoài, chẳng hạn như tài liệu, trang web hoặc email.
    
2.  **Spotlighting**: Kỹ thuật này giúp hệ thống AI phân biệt giữa các hướng dẫn hệ thống hợp lệ và các đầu vào bên ngoài có thể không đáng tin cậy. Bằng cách biến đổi văn bản đầu vào theo cách làm cho nó có liên quan hơn với mô hình, Spotlighting đảm bảo rằng AI có thể nhận diện và bỏ qua các hướng dẫn độc hại.
    
3.  **Dấu phân cách và Đánh dấu dữ liệu**: Bao gồm các dấu phân cách trong thông điệp hệ thống để nêu rõ vị trí của văn bản đầu vào, giúp hệ thống AI nhận ra và tách biệt các đầu vào của người dùng khỏi nội dung bên ngoài có thể gây hại. Đánh dấu dữ liệu mở rộng khái niệm này bằng cách sử dụng các dấu đặc biệt để làm nổi bật ranh giới của dữ liệu đáng tin cậy và không đáng tin cậy.
    
4.  **Giám sát và Cập nhật liên tục**: Microsoft liên tục giám sát và cập nhật Prompt Shields để giải quyết các mối đe dọa mới và đang phát triển. Cách tiếp cận chủ động này đảm bảo rằng các biện pháp phòng thủ vẫn hiệu quả trước các kỹ thuật tấn công mới nhất.
    
5. **Tích hợp với Azure Content Safety:** Prompt Shields là một phần của bộ công cụ Azure AI Content Safety rộng hơn, cung cấp các công cụ bổ sung để phát hiện các nỗ lực jailbreak, nội dung có hại và các rủi ro bảo mật khác trong các ứng dụng AI.

Bạn có thể đọc thêm về lá chắn gợi ý AI trong [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

### Bảo mật chuỗi cung ứng

Bảo mật chuỗi cung ứng vẫn là cơ bản trong thời đại AI, nhưng phạm vi của những gì cấu thành chuỗi cung ứng của bạn đã mở rộng. Ngoài các gói mã truyền thống, bạn phải kiểm tra và giám sát nghiêm ngặt tất cả các thành phần liên quan đến AI, bao gồm các mô hình nền tảng, dịch vụ nhúng, nhà cung cấp ngữ cảnh và API của bên thứ ba. Mỗi thành phần này có thể giới thiệu các lỗ hổng hoặc rủi ro nếu không được quản lý đúng cách.

**Các thực hành bảo mật chuỗi cung ứng chính cho AI và MCP:**
- **Xác minh tất cả các thành phần trước khi tích hợp:** Điều này bao gồm không chỉ các thư viện mã nguồn mở, mà còn các mô hình AI, nguồn dữ liệu và API bên ngoài. Luôn kiểm tra nguồn gốc, giấy phép và các lỗ hổng đã biết.
- **Duy trì các đường dẫn triển khai an toàn:** Sử dụng các đường dẫn CI/CD tự động với quét bảo mật tích hợp để phát hiện vấn đề sớm. Đảm bảo rằng chỉ các hiện vật đáng tin cậy mới được triển khai vào sản xuất.
- **Giám sát và kiểm tra liên tục:** Thực hiện giám sát liên tục cho tất cả các phụ thuộc, bao gồm cả các mô hình và dịch vụ dữ liệu, để phát hiện các lỗ hổng mới hoặc các cuộc tấn công chuỗi cung ứng.
- **Áp dụng quyền tối thiểu và kiểm soát truy cập:** Hạn chế quyền truy cập vào các mô hình, dữ liệu và dịch vụ chỉ cho những gì cần thiết để máy chủ MCP của bạn hoạt động.
- **Phản ứng nhanh chóng với các mối đe dọa:** Có quy trình để vá lỗi hoặc thay thế các thành phần bị xâm phạm, và để xoay vòng bí mật hoặc thông tin đăng nhập nếu phát hiện vi phạm.

[GitHub Advanced Security](https://github.com/security/advanced
- [OWASP Top 10 cho LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Hành Trình Bảo Vệ Chuỗi Cung Ứng Phần Mềm tại Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Truy Cập Tối Thiểu An Toàn (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Thực Hành Tốt Nhất cho Xác Thực và Thời Gian Sống của Token](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Sử Dụng Lưu Trữ Token An Toàn và Mã Hóa Token (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management như Cổng Xác Thực cho MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Sử Dụng Microsoft Entra ID để Xác Thực với Máy Chủ MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Tiếp theo

Tiếp theo: [Chương 3: Bắt Đầu](/03-GettingStarted/README.md)

**Tuyên bố miễn trừ trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ bản địa nên được coi là nguồn thông tin đáng tin cậy. Đối với thông tin quan trọng, khuyến nghị sử dụng dịch vụ dịch thuật chuyên nghiệp của con người. Chúng tôi không chịu trách nhiệm cho bất kỳ hiểu lầm hoặc diễn giải sai nào phát sinh từ việc sử dụng bản dịch này.