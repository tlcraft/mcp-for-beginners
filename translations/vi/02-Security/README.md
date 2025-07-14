<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c69f9df7f3215dac8d056020539bac36",
  "translation_date": "2025-07-13T16:56:14+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "vi"
}
-->
# Thực hành bảo mật tốt nhất

Việc áp dụng Model Context Protocol (MCP) mang lại những khả năng mạnh mẽ cho các ứng dụng dựa trên AI, nhưng cũng đồng thời tạo ra những thách thức bảo mật đặc thù vượt ra ngoài các rủi ro phần mềm truyền thống. Bên cạnh các mối quan tâm đã được thiết lập như lập trình an toàn, quyền truy cập tối thiểu và bảo mật chuỗi cung ứng, MCP và các khối lượng công việc AI còn đối mặt với các mối đe dọa mới như chèn prompt, đầu độc công cụ và thay đổi công cụ động. Những rủi ro này có thể dẫn đến việc rò rỉ dữ liệu, vi phạm quyền riêng tư và hành vi hệ thống không mong muốn nếu không được quản lý đúng cách.

Bài học này sẽ khám phá các rủi ro bảo mật liên quan đến MCP—bao gồm xác thực, ủy quyền, quyền truy cập quá mức, chèn prompt gián tiếp và lỗ hổng chuỗi cung ứng—và cung cấp các biện pháp kiểm soát cũng như thực hành tốt nhất để giảm thiểu chúng. Bạn cũng sẽ học cách tận dụng các giải pháp của Microsoft như Prompt Shields, Azure Content Safety và GitHub Advanced Security để củng cố việc triển khai MCP của mình. Bằng cách hiểu và áp dụng các biện pháp kiểm soát này, bạn có thể giảm đáng kể khả năng xảy ra vi phạm bảo mật và đảm bảo hệ thống AI của bạn luôn mạnh mẽ và đáng tin cậy.

# Mục tiêu học tập

Sau khi hoàn thành bài học này, bạn sẽ có khả năng:

- Nhận diện và giải thích các rủi ro bảo mật đặc thù do Model Context Protocol (MCP) mang lại, bao gồm chèn prompt, đầu độc công cụ, quyền truy cập quá mức và lỗ hổng chuỗi cung ứng.
- Mô tả và áp dụng các biện pháp kiểm soát hiệu quả để giảm thiểu rủi ro bảo mật MCP, như xác thực mạnh mẽ, quyền truy cập tối thiểu, quản lý token an toàn và xác minh chuỗi cung ứng.
- Hiểu và tận dụng các giải pháp của Microsoft như Prompt Shields, Azure Content Safety và GitHub Advanced Security để bảo vệ MCP và các khối lượng công việc AI.
- Nhận thức tầm quan trọng của việc xác thực metadata công cụ, giám sát các thay đổi động và phòng chống các cuộc tấn công chèn prompt gián tiếp.
- Tích hợp các thực hành bảo mật đã được thiết lập—như lập trình an toàn, tăng cường bảo mật máy chủ và kiến trúc zero trust—vào việc triển khai MCP để giảm thiểu khả năng và tác động của các vi phạm bảo mật.

# Các biện pháp kiểm soát bảo mật MCP

Bất kỳ hệ thống nào có quyền truy cập vào các tài nguyên quan trọng đều đối mặt với những thách thức bảo mật nhất định. Các thách thức này thường được giải quyết thông qua việc áp dụng đúng các biện pháp kiểm soát và khái niệm bảo mật cơ bản. Vì MCP mới chỉ được định nghĩa gần đây, đặc tả đang thay đổi rất nhanh và giao thức cũng đang phát triển. Cuối cùng, các biện pháp kiểm soát bảo mật trong đó sẽ trưởng thành hơn, cho phép tích hợp tốt hơn với kiến trúc bảo mật doanh nghiệp và các thực hành tốt nhất đã được thiết lập.

Nghiên cứu được công bố trong [Microsoft Digital Defense Report](https://aka.ms/mddr) cho thấy 98% các vụ vi phạm được báo cáo có thể được ngăn chặn bằng việc duy trì vệ sinh bảo mật nghiêm ngặt và biện pháp bảo vệ tốt nhất chống lại mọi loại vi phạm là đảm bảo vệ sinh bảo mật cơ bản, thực hành lập trình an toàn và bảo mật chuỗi cung ứng được thực hiện đúng—những thực hành đã được kiểm chứng này vẫn là cách hiệu quả nhất để giảm rủi ro bảo mật.

Hãy cùng xem một số cách bạn có thể bắt đầu giải quyết các rủi ro bảo mật khi áp dụng MCP.

> **Note:** Thông tin dưới đây chính xác tính đến ngày **29 tháng 5 năm 2025**. Giao thức MCP liên tục phát triển, và các triển khai trong tương lai có thể giới thiệu các mẫu xác thực và biện pháp kiểm soát mới. Để cập nhật và hướng dẫn mới nhất, luôn tham khảo [MCP Specification](https://spec.modelcontextprotocol.io/) và kho lưu trữ chính thức [MCP GitHub repository](https://github.com/modelcontextprotocol) cùng [trang thực hành bảo mật tốt nhất](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Vấn đề đặt ra  
Đặc tả MCP ban đầu giả định rằng các nhà phát triển sẽ tự viết máy chủ xác thực của riêng họ. Điều này đòi hỏi kiến thức về OAuth và các ràng buộc bảo mật liên quan. Các máy chủ MCP hoạt động như OAuth 2.0 Authorization Servers, quản lý việc xác thực người dùng trực tiếp thay vì ủy quyền cho dịch vụ bên ngoài như Microsoft Entra ID. Từ ngày **26 tháng 4 năm 2025**, một cập nhật trong đặc tả MCP cho phép các máy chủ MCP ủy quyền xác thực người dùng cho dịch vụ bên ngoài.

### Rủi ro
- Logic ủy quyền cấu hình sai trong máy chủ MCP có thể dẫn đến việc lộ dữ liệu nhạy cảm và áp dụng sai các kiểm soát truy cập.
- Trộm token OAuth trên máy chủ MCP cục bộ. Nếu token bị đánh cắp, kẻ tấn công có thể giả mạo máy chủ MCP và truy cập tài nguyên, dữ liệu từ dịch vụ mà token OAuth đó đại diện.

#### Token Passthrough
Token passthrough bị cấm rõ ràng trong đặc tả ủy quyền vì nó tạo ra nhiều rủi ro bảo mật, bao gồm:

#### Vượt qua biện pháp kiểm soát bảo mật
Máy chủ MCP hoặc các API hạ nguồn có thể triển khai các biện pháp kiểm soát bảo mật quan trọng như giới hạn tốc độ, xác thực yêu cầu hoặc giám sát lưu lượng, dựa vào đối tượng token hoặc các ràng buộc chứng thực khác. Nếu khách hàng có thể lấy và sử dụng token trực tiếp với các API hạ nguồn mà không qua xác thực đúng của máy chủ MCP hoặc không đảm bảo token được cấp cho dịch vụ đúng, họ sẽ bỏ qua các biện pháp kiểm soát này.

#### Vấn đề trách nhiệm và theo dõi kiểm toán
Máy chủ MCP sẽ không thể nhận diện hoặc phân biệt giữa các MCP Client khi các client gọi với token truy cập được cấp từ upstream mà máy chủ MCP có thể không hiểu rõ.
Nhật ký của Resource Server hạ nguồn có thể hiển thị các yêu cầu có vẻ đến từ nguồn khác với danh tính khác, thay vì từ máy chủ MCP thực sự chuyển tiếp token.
Cả hai yếu tố này làm cho việc điều tra sự cố, kiểm soát và kiểm toán trở nên khó khăn hơn.
Nếu máy chủ MCP chuyển tiếp token mà không xác thực các tuyên bố của token (ví dụ: vai trò, đặc quyền hoặc đối tượng) hoặc metadata khác, kẻ tấn công có token bị đánh cắp có thể dùng máy chủ như một proxy để rò rỉ dữ liệu.

#### Vấn đề ranh giới tin cậy
Resource Server hạ nguồn cấp quyền tin cậy cho các thực thể cụ thể. Sự tin cậy này có thể bao gồm các giả định về nguồn gốc hoặc hành vi của client. Việc phá vỡ ranh giới tin cậy này có thể dẫn đến các vấn đề không mong muốn.
Nếu token được chấp nhận bởi nhiều dịch vụ mà không được xác thực đúng, kẻ tấn công xâm phạm một dịch vụ có thể dùng token để truy cập các dịch vụ kết nối khác.

#### Rủi ro tương thích trong tương lai
Ngay cả khi máy chủ MCP bắt đầu như một “proxy thuần túy” hôm nay, nó có thể cần thêm các biện pháp kiểm soát bảo mật sau này. Bắt đầu với việc phân tách đối tượng token đúng cách sẽ giúp dễ dàng phát triển mô hình bảo mật hơn.

### Biện pháp giảm thiểu

**Máy chủ MCP KHÔNG ĐƯỢC chấp nhận bất kỳ token nào không được cấp rõ ràng cho máy chủ MCP đó**

- **Xem xét và củng cố logic ủy quyền:** Kiểm tra kỹ lưỡng việc triển khai ủy quyền của máy chủ MCP để đảm bảo chỉ người dùng và client dự kiến mới có thể truy cập tài nguyên nhạy cảm. Để được hướng dẫn thực tế, xem [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) và [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Thực thi các thực hành token an toàn:** Tuân theo [thực hành tốt nhất của Microsoft về xác thực token và thời gian tồn tại](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) để ngăn chặn việc sử dụng sai token truy cập và giảm nguy cơ phát lại hoặc đánh cắp token.
- **Bảo vệ lưu trữ token:** Luôn lưu trữ token một cách an toàn và sử dụng mã hóa để bảo vệ chúng khi lưu trữ và truyền tải. Để biết mẹo triển khai, xem [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Quyền truy cập quá mức cho máy chủ MCP

### Vấn đề đặt ra
Máy chủ MCP có thể được cấp quyền truy cập quá mức đối với dịch vụ hoặc tài nguyên mà nó truy cập. Ví dụ, một máy chủ MCP trong ứng dụng bán hàng AI kết nối với kho dữ liệu doanh nghiệp nên chỉ được phép truy cập dữ liệu bán hàng, không được phép truy cập tất cả các tệp trong kho. Quay lại nguyên tắc quyền truy cập tối thiểu (một trong những nguyên tắc bảo mật lâu đời nhất), không tài nguyên nào nên có quyền vượt quá mức cần thiết để thực hiện nhiệm vụ được giao. AI tạo ra thách thức lớn hơn trong lĩnh vực này vì để nó linh hoạt, việc xác định chính xác quyền cần thiết có thể rất khó khăn.

### Rủi ro  
- Cấp quyền quá mức có thể cho phép rò rỉ hoặc sửa đổi dữ liệu mà máy chủ MCP không được phép truy cập. Điều này cũng có thể là vấn đề về quyền riêng tư nếu dữ liệu là thông tin cá nhân nhận dạng được (PII).

### Biện pháp giảm thiểu
- **Áp dụng nguyên tắc quyền truy cập tối thiểu:** Chỉ cấp cho máy chủ MCP những quyền tối thiểu cần thiết để thực hiện nhiệm vụ. Thường xuyên xem xét và cập nhật quyền để đảm bảo không vượt quá mức cần thiết. Để được hướng dẫn chi tiết, xem [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Sử dụng kiểm soát truy cập dựa trên vai trò (RBAC):** Gán vai trò cho máy chủ MCP với phạm vi chặt chẽ đối với các tài nguyên và hành động cụ thể, tránh cấp quyền rộng hoặc không cần thiết.
- **Giám sát và kiểm toán quyền:** Liên tục theo dõi việc sử dụng quyền và kiểm tra nhật ký truy cập để phát hiện và xử lý kịp thời các đặc quyền quá mức hoặc không sử dụng.

# Các cuộc tấn công chèn prompt gián tiếp

### Vấn đề đặt ra

Các máy chủ MCP bị tấn công hoặc bị xâm phạm có thể gây ra rủi ro lớn bằng cách làm lộ dữ liệu khách hàng hoặc cho phép các hành động không mong muốn. Những rủi ro này đặc biệt quan trọng trong các khối lượng công việc AI và MCP, nơi:

- **Tấn công chèn prompt:** Kẻ tấn công nhúng các chỉ dẫn độc hại vào prompt hoặc nội dung bên ngoài, khiến hệ thống AI thực hiện các hành động không mong muốn hoặc rò rỉ dữ liệu nhạy cảm. Tìm hiểu thêm: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Đầu độc công cụ:** Kẻ tấn công thao túng metadata công cụ (như mô tả hoặc tham số) để ảnh hưởng đến hành vi AI, có thể vượt qua các biện pháp kiểm soát bảo mật hoặc rò rỉ dữ liệu. Chi tiết: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Chèn prompt xuyên miền:** Các chỉ dẫn độc hại được nhúng trong tài liệu, trang web hoặc email, sau đó được AI xử lý, dẫn đến rò rỉ hoặc thao túng dữ liệu.
- **Thay đổi công cụ động (Rug Pulls):** Định nghĩa công cụ có thể bị thay đổi sau khi người dùng phê duyệt, đưa vào các hành vi độc hại mới mà người dùng không hay biết.

Những lỗ hổng này nhấn mạnh sự cần thiết của việc xác thực chặt chẽ, giám sát và các biện pháp kiểm soát bảo mật khi tích hợp các máy chủ MCP và công cụ vào môi trường của bạn. Để tìm hiểu sâu hơn, xem các tài liệu tham khảo liên kết ở trên.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.vi.png)

**Chèn Prompt Gián Tiếp** (còn gọi là chèn prompt xuyên miền hoặc XPIA) là một lỗ hổng nghiêm trọng trong các hệ thống AI sinh tạo, bao gồm cả những hệ thống sử dụng Model Context Protocol (MCP). Trong cuộc tấn công này, các chỉ dẫn độc hại được giấu trong nội dung bên ngoài—như tài liệu, trang web hoặc email. Khi hệ thống AI xử lý nội dung này, nó có thể hiểu các chỉ dẫn nhúng như các lệnh hợp lệ từ người dùng, dẫn đến các hành động không mong muốn như rò rỉ dữ liệu, tạo nội dung có hại hoặc thao túng tương tác với người dùng. Để biết giải thích chi tiết và ví dụ thực tế, xem [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Một dạng tấn công đặc biệt nguy hiểm là **Đầu độc Công cụ**. Ở đây, kẻ tấn công chèn các chỉ dẫn độc hại vào metadata của các công cụ MCP (như mô tả công cụ hoặc tham số). Vì các mô hình ngôn ngữ lớn (LLM) dựa vào metadata này để quyết định công cụ nào sẽ được gọi, các mô tả bị xâm phạm có thể lừa mô hình thực hiện các cuộc gọi công cụ trái phép hoặc vượt qua các biện pháp kiểm soát bảo mật. Những thao túng này thường không hiển thị với người dùng cuối nhưng có thể được hệ thống AI hiểu và thực thi. Rủi ro này càng tăng cao trong môi trường máy chủ MCP được lưu trữ, nơi định nghĩa công cụ có thể được cập nhật sau khi người dùng phê duyệt—tình huống này đôi khi được gọi là "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Trong trường hợp này, một công cụ từng an toàn có thể bị thay đổi để thực hiện các hành vi độc hại, như rò rỉ dữ liệu hoặc thay đổi hành vi hệ thống mà người dùng không biết. Để biết thêm về vectơ tấn công này, xem [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.vi.png)

## Rủi ro
Các hành động AI không mong muốn gây ra nhiều rủi ro bảo mật, bao gồm rò rỉ dữ liệu và vi phạm quyền riêng tư.

### Biện pháp giảm thiểu
### Sử dụng prompt shields để bảo vệ chống lại các cuộc tấn công chèn prompt gián tiếp
-----------------------------------------------------------------------------

**AI Prompt Shields** là giải pháp do Microsoft phát triển nhằm phòng chống cả các cuộc tấn công chèn prompt trực tiếp và gián tiếp. Chúng hỗ trợ bằng cách:

1.  **Phát hiện và Lọc:** Prompt Shields sử dụng các thuật toán học máy tiên tiến và xử lý ngôn ngữ tự nhiên để phát hiện và lọc các chỉ dẫn độc hại nhúng trong nội dung bên ngoài, như tài liệu, trang web hoặc email.
    
2.  **Spotlighting:** Kỹ thuật này giúp hệ thống AI phân biệt giữa các chỉ dẫn hợp lệ của hệ thống và các đầu vào bên ngoài có thể không đáng tin cậy. Bằng cách biến đổi văn bản đầu vào theo cách làm cho nó phù hợp hơn với mô hình, Spotlighting đảm bảo AI có thể nhận diện và bỏ qua các chỉ dẫn độc hại tốt hơn.
    
3.  **Dấu phân cách và Đánh dấu dữ liệu:** Việc bao gồm các dấu phân cách trong thông điệp hệ thống giúp xác định rõ vị trí của văn bản đầu vào, giúp AI nhận biết và tách biệt các đầu vào của người dùng với nội dung bên ngoài có thể gây hại. Đánh dấu dữ liệu mở rộng khái niệm này bằng cách sử dụng các dấu hiệu đặc biệt để làm nổi bật ranh giới giữa dữ liệu tin cậy và không tin cậy.
    
4.  **Giám sát và Cập nhật liên tục:** Microsoft liên tục giám sát và cập nhật Prompt Shields để đối phó với các mối đe dọa mới và đang phát triển. Cách tiếp cận chủ động này đảm bảo các biện pháp phòng thủ luôn hiệu quả trước các kỹ thuật tấn công mới nhất.
    
5. **Tích hợp với Azure Content Safety:** Prompt Shields là một phần của bộ công cụ Azure AI Content Safety rộng hơn, cung cấp các công cụ bổ sung để phát hiện các nỗ lực jailbreak, nội dung độc hại và các rủi ro bảo mật khác trong ứng dụng AI.

Bạn có thể đọc thêm về AI prompt shields trong [tài liệu Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.vi.png)

### Bảo mật chuỗi cung ứng
An ninh chuỗi cung ứng vẫn là yếu tố then chốt trong thời đại AI, nhưng phạm vi của chuỗi cung ứng đã được mở rộng. Bên cạnh các gói mã truyền thống, bạn giờ đây phải kiểm tra và giám sát chặt chẽ tất cả các thành phần liên quan đến AI, bao gồm các mô hình nền tảng, dịch vụ embeddings, nhà cung cấp ngữ cảnh và API bên thứ ba. Mỗi thành phần này đều có thể gây ra lỗ hổng hoặc rủi ro nếu không được quản lý đúng cách.

**Các thực hành an ninh chuỗi cung ứng quan trọng cho AI và MCP:**
- **Xác minh tất cả các thành phần trước khi tích hợp:** Điều này không chỉ bao gồm các thư viện mã nguồn mở mà còn các mô hình AI, nguồn dữ liệu và API bên ngoài. Luôn kiểm tra nguồn gốc, giấy phép và các lỗ hổng đã biết.
- **Duy trì quy trình triển khai an toàn:** Sử dụng các pipeline CI/CD tự động tích hợp quét bảo mật để phát hiện sớm các vấn đề. Đảm bảo chỉ các artifact đáng tin cậy được triển khai lên môi trường sản xuất.
- **Giám sát và kiểm tra liên tục:** Thực hiện giám sát liên tục cho tất cả các phụ thuộc, bao gồm mô hình và dịch vụ dữ liệu, để phát hiện các lỗ hổng mới hoặc các cuộc tấn công chuỗi cung ứng.
- **Áp dụng nguyên tắc quyền tối thiểu và kiểm soát truy cập:** Hạn chế quyền truy cập vào mô hình, dữ liệu và dịch vụ chỉ ở mức cần thiết để MCP server hoạt động.
- **Phản ứng nhanh với các mối đe dọa:** Có quy trình để vá hoặc thay thế các thành phần bị xâm phạm, cũng như thay đổi bí mật hoặc thông tin xác thực nếu phát hiện vi phạm.

[GitHub Advanced Security](https://github.com/security/advanced-security) cung cấp các tính năng như quét bí mật, quét phụ thuộc và phân tích CodeQL. Các công cụ này tích hợp với [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) và [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) giúp các nhóm phát hiện và giảm thiểu lỗ hổng trên cả mã nguồn và các thành phần chuỗi cung ứng AI.

Microsoft cũng thực hiện các thực hành an ninh chuỗi cung ứng rộng rãi nội bộ cho tất cả sản phẩm. Tìm hiểu thêm tại [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Các thực hành bảo mật đã được thiết lập giúp nâng cao vị thế bảo mật cho triển khai MCP của bạn

Bất kỳ triển khai MCP nào cũng kế thừa vị thế bảo mật hiện có của môi trường tổ chức mà nó được xây dựng trên đó, vì vậy khi xem xét bảo mật của MCP như một thành phần trong hệ thống AI tổng thể, bạn nên cân nhắc nâng cao vị thế bảo mật hiện có của mình. Các kiểm soát bảo mật đã được thiết lập sau đây đặc biệt phù hợp:

-   Thực hành mã hóa an toàn trong ứng dụng AI của bạn – bảo vệ chống lại [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 cho LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), sử dụng kho bí mật an toàn cho các bí mật và token, triển khai giao tiếp an toàn đầu cuối giữa tất cả các thành phần ứng dụng, v.v.
-   Tăng cường bảo mật máy chủ – sử dụng MFA khi có thể, cập nhật bản vá thường xuyên, tích hợp máy chủ với nhà cung cấp danh tính bên thứ ba để kiểm soát truy cập, v.v.
-   Giữ thiết bị, hạ tầng và ứng dụng luôn được cập nhật bản vá
-   Giám sát bảo mật – triển khai ghi nhật ký và giám sát ứng dụng AI (bao gồm cả client/server MCP) và gửi các bản ghi này đến SIEM trung tâm để phát hiện các hoạt động bất thường
-   Kiến trúc Zero trust – cô lập các thành phần thông qua kiểm soát mạng và danh tính một cách hợp lý để giảm thiểu khả năng di chuyển ngang nếu ứng dụng AI bị xâm phạm.

# Những điểm chính cần ghi nhớ

- Các nguyên tắc bảo mật cơ bản vẫn rất quan trọng: Mã hóa an toàn, quyền tối thiểu, xác minh chuỗi cung ứng và giám sát liên tục là những yếu tố thiết yếu cho MCP và các workload AI.
- MCP mang đến các rủi ro mới — như prompt injection, tool poisoning và quyền truy cập quá mức — đòi hỏi các kiểm soát truyền thống và đặc thù cho AI.
- Sử dụng các thực hành xác thực, ủy quyền và quản lý token mạnh mẽ, tận dụng nhà cung cấp danh tính bên ngoài như Microsoft Entra ID khi có thể.
- Bảo vệ chống lại prompt injection gián tiếp và tool poisoning bằng cách xác thực metadata công cụ, giám sát các thay đổi động và sử dụng các giải pháp như Microsoft Prompt Shields.
- Đối xử với tất cả các thành phần trong chuỗi cung ứng AI của bạn — bao gồm mô hình, embeddings và nhà cung cấp ngữ cảnh — với mức độ nghiêm ngặt tương tự như các phụ thuộc mã nguồn.
- Luôn cập nhật các đặc tả MCP đang phát triển và đóng góp cho cộng đồng để giúp hình thành các tiêu chuẩn bảo mật.

# Tài nguyên bổ sung

- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [Prompt Injection trong MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Tool Poisoning Attacks (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls trong MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Tài liệu Prompt Shields (Microsoft)](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 cho LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Sử dụng lưu trữ token an toàn và mã hóa token (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management làm cổng xác thực cho MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Thực hành bảo mật MCP tốt nhất](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Sử dụng Microsoft Entra ID để xác thực với MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Tiếp theo

Tiếp theo: [Chương 3: Bắt đầu](../03-GettingStarted/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc của nó nên được coi là nguồn chính xác và đáng tin cậy. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.