<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-20T23:17:32+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "vi"
}
-->
# Security Best Practices

Áp dụng Model Context Protocol (MCP) mang lại những khả năng mạnh mẽ cho các ứng dụng AI, nhưng cũng tạo ra những thách thức bảo mật đặc thù vượt ra ngoài các rủi ro phần mềm truyền thống. Bên cạnh các mối quan tâm đã được biết như lập trình an toàn, quyền truy cập tối thiểu và bảo mật chuỗi cung ứng, MCP và các workload AI còn đối mặt với các mối đe dọa mới như prompt injection, tool poisoning và thay đổi công cụ động. Những rủi ro này có thể dẫn đến rò rỉ dữ liệu, vi phạm quyền riêng tư và hành vi hệ thống không mong muốn nếu không được kiểm soát đúng cách.

Bài học này sẽ khám phá các rủi ro bảo mật liên quan đến MCP—bao gồm xác thực, ủy quyền, quyền hạn quá mức, prompt injection gián tiếp và lỗ hổng chuỗi cung ứng—và cung cấp các biện pháp kiểm soát cũng như thực hành tốt để giảm thiểu chúng. Bạn cũng sẽ học cách tận dụng các giải pháp của Microsoft như Prompt Shields, Azure Content Safety và GitHub Advanced Security để củng cố triển khai MCP của mình. Bằng việc hiểu và áp dụng các kiểm soát này, bạn có thể giảm đáng kể khả năng xảy ra vi phạm bảo mật và đảm bảo hệ thống AI của mình luôn vững chắc, đáng tin cậy.

# Learning Objectives

Kết thúc bài học này, bạn sẽ có khả năng:

- Nhận diện và giải thích các rủi ro bảo mật đặc thù do Model Context Protocol (MCP) mang lại, bao gồm prompt injection, tool poisoning, quyền hạn quá mức và lỗ hổng chuỗi cung ứng.
- Mô tả và áp dụng các biện pháp kiểm soát hiệu quả để giảm thiểu rủi ro bảo mật MCP, như xác thực mạnh mẽ, quyền truy cập tối thiểu, quản lý token an toàn và xác minh chuỗi cung ứng.
- Hiểu và tận dụng các giải pháp của Microsoft như Prompt Shields, Azure Content Safety và GitHub Advanced Security để bảo vệ MCP và các workload AI.
- Nhận biết tầm quan trọng của việc xác thực metadata công cụ, giám sát thay đổi động và phòng chống các cuộc tấn công prompt injection gián tiếp.
- Tích hợp các thực hành bảo mật đã được thiết lập—như lập trình an toàn, tăng cường bảo mật máy chủ và kiến trúc zero trust—vào triển khai MCP để giảm khả năng và tác động của các vi phạm bảo mật.

# MCP security controls

Bất kỳ hệ thống nào có quyền truy cập vào tài nguyên quan trọng đều gặp phải các thách thức bảo mật nhất định. Những thách thức này thường được giải quyết bằng cách áp dụng đúng các biện pháp kiểm soát và khái niệm bảo mật cơ bản. Vì MCP mới chỉ được định nghĩa gần đây, đặc tả đang thay đổi rất nhanh theo sự phát triển của giao thức. Cuối cùng, các biện pháp kiểm soát bảo mật trong MCP sẽ trưởng thành hơn, cho phép tích hợp tốt hơn với kiến trúc bảo mật doanh nghiệp và các thực hành tốt đã được thiết lập.

Nghiên cứu được công bố trong [Microsoft Digital Defense Report](https://aka.ms/mddr) cho thấy 98% các vụ vi phạm được báo cáo có thể được ngăn chặn nhờ thực hành vệ sinh bảo mật nghiêm ngặt, và biện pháp bảo vệ tốt nhất trước mọi loại vi phạm là thiết lập đúng các quy tắc vệ sinh bảo mật cơ bản, lập trình an toàn và bảo mật chuỗi cung ứng — những thực hành đã được kiểm chứng này vẫn có tác động lớn nhất trong việc giảm rủi ro bảo mật.

Hãy cùng xem qua một số cách bạn có thể bắt đầu giải quyết các rủi ro bảo mật khi áp dụng MCP.

# MCP server authentication (if your MCP implementation was before 26th April 2025)

> **Note:** Thông tin sau đây chính xác tính đến ngày 26 tháng 4 năm 2025. Giao thức MCP liên tục phát triển, và các triển khai trong tương lai có thể giới thiệu các mẫu và biện pháp kiểm soát xác thực mới. Để cập nhật và hướng dẫn mới nhất, hãy luôn tham khảo [MCP Specification](https://spec.modelcontextprotocol.io/) và kho mã chính thức [MCP GitHub repository](https://github.com/modelcontextprotocol).

### Problem statement  
Đặc tả MCP ban đầu giả định các nhà phát triển sẽ tự viết máy chủ xác thực. Điều này đòi hỏi kiến thức về OAuth và các giới hạn bảo mật liên quan. Máy chủ MCP hoạt động như OAuth 2.0 Authorization Server, quản lý việc xác thực người dùng trực tiếp thay vì ủy quyền cho dịch vụ bên ngoài như Microsoft Entra ID. Tính đến ngày 26 tháng 4 năm 2025, một cập nhật đặc tả MCP cho phép máy chủ MCP ủy quyền xác thực người dùng cho dịch vụ bên ngoài.

### Risks  
- Logic ủy quyền cấu hình sai trong máy chủ MCP có thể dẫn đến lộ dữ liệu nhạy cảm và áp dụng sai quyền truy cập.
- Mất cắp token OAuth trên máy chủ MCP cục bộ. Nếu token bị đánh cắp, kẻ tấn công có thể giả danh máy chủ MCP để truy cập tài nguyên và dữ liệu từ dịch vụ mà token đó thuộc về.

### Mitigating controls  
- **Xem xét và Tăng cường Logic Ủy quyền:** Kiểm tra kỹ lưỡng việc triển khai ủy quyền trên máy chủ MCP để đảm bảo chỉ người dùng và client dự kiến mới được truy cập tài nguyên nhạy cảm. Tham khảo hướng dẫn thực tế tại [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) và [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Thực thi Quy tắc Token An toàn:** Tuân theo [thực hành tốt nhất của Microsoft về xác thực và vòng đời token](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) để ngăn chặn việc sử dụng sai token và giảm nguy cơ phát lại hoặc đánh cắp token.
- **Bảo vệ Lưu trữ Token:** Luôn lưu trữ token một cách an toàn và sử dụng mã hóa để bảo vệ token khi lưu trữ và truyền tải. Xem mẹo triển khai tại [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Excessive permissions for MCP servers

### Problem statement  
Máy chủ MCP có thể đã được cấp quyền quá mức đối với dịch vụ hoặc tài nguyên mà nó truy cập. Ví dụ, một máy chủ MCP trong ứng dụng AI bán hàng kết nối với kho dữ liệu doanh nghiệp nên chỉ được cấp quyền truy cập dữ liệu bán hàng, không phải toàn bộ các tệp trong kho. Quay lại nguyên tắc quyền truy cập tối thiểu (một trong những nguyên tắc bảo mật lâu đời nhất), không tài nguyên nào nên có quyền vượt quá mức cần thiết để thực hiện nhiệm vụ được giao. AI tạo ra thách thức lớn hơn trong lĩnh vực này vì để linh hoạt, rất khó xác định chính xác quyền cần thiết.

### Risks  
- Cấp quyền quá mức có thể cho phép rò rỉ hoặc chỉnh sửa dữ liệu mà máy chủ MCP không được phép truy cập. Điều này cũng có thể là vấn đề về quyền riêng tư nếu dữ liệu chứa thông tin cá nhân (PII).

### Mitigating controls  
- **Áp dụng Nguyên tắc Quyền truy cập Tối thiểu:** Chỉ cấp cho máy chủ MCP quyền cần thiết tối thiểu để thực hiện nhiệm vụ. Thường xuyên xem xét và cập nhật quyền để đảm bảo không vượt quá mức cần thiết. Tham khảo hướng dẫn chi tiết tại [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Sử dụng Role-Based Access Control (RBAC):** Gán vai trò cho máy chủ MCP với phạm vi chặt chẽ cho các tài nguyên và hành động cụ thể, tránh quyền rộng hoặc không cần thiết.
- **Giám sát và Kiểm toán Quyền:** Theo dõi liên tục việc sử dụng quyền và kiểm tra nhật ký truy cập để phát hiện và xử lý kịp thời các quyền quá mức hoặc không sử dụng.

# Indirect prompt injection attacks

### Problem statement

Máy chủ MCP độc hại hoặc bị xâm nhập có thể tạo ra rủi ro lớn bằng cách làm lộ dữ liệu khách hàng hoặc cho phép các hành động không mong muốn. Những rủi ro này đặc biệt quan trọng trong các workload AI và MCP, nơi:

- **Prompt Injection Attacks**: Kẻ tấn công nhúng các chỉ thị độc hại trong prompt hoặc nội dung bên ngoài, khiến hệ thống AI thực hiện các hành động không mong muốn hoặc rò rỉ dữ liệu nhạy cảm. Tìm hiểu thêm: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning**: Kẻ tấn công thao túng metadata công cụ (như mô tả hoặc tham số) để ảnh hưởng hành vi AI, có thể vượt qua các kiểm soát bảo mật hoặc rò rỉ dữ liệu. Chi tiết: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection**: Chỉ thị độc hại được nhúng trong tài liệu, trang web hoặc email, sau đó được AI xử lý, dẫn đến rò rỉ hoặc thao túng dữ liệu.
- **Dynamic Tool Modification (Rug Pulls)**: Định nghĩa công cụ có thể bị thay đổi sau khi người dùng phê duyệt, đưa vào hành vi độc hại mới mà người dùng không biết.

Những điểm yếu này nhấn mạnh nhu cầu về xác thực chặt chẽ, giám sát và kiểm soát bảo mật khi tích hợp máy chủ MCP và công cụ vào môi trường của bạn. Để tìm hiểu sâu hơn, xem các tài liệu tham khảo ở trên.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.vi.png)

**Indirect Prompt Injection** (còn gọi là cross-domain prompt injection hoặc XPIA) là một lỗ hổng nghiêm trọng trong hệ thống AI sinh tạo, bao gồm cả những hệ thống sử dụng Model Context Protocol (MCP). Trong cuộc tấn công này, các chỉ thị độc hại được giấu trong nội dung bên ngoài — như tài liệu, trang web hoặc email. Khi hệ thống AI xử lý nội dung này, nó có thể hiểu nhầm các chỉ thị đó là lệnh hợp lệ của người dùng, dẫn đến các hành động không mong muốn như rò rỉ dữ liệu, tạo nội dung có hại hoặc thao túng tương tác người dùng. Để biết giải thích chi tiết và ví dụ thực tế, xem [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Một dạng tấn công đặc biệt nguy hiểm là **Tool Poisoning**. Ở đây, kẻ tấn công chèn các chỉ thị độc hại vào metadata của các công cụ MCP (như mô tả công cụ hoặc tham số). Vì các mô hình ngôn ngữ lớn (LLMs) dựa vào metadata này để quyết định công cụ nào sẽ được gọi, mô tả bị xâm nhập có thể lừa mô hình thực thi các lệnh gọi công cụ trái phép hoặc vượt qua kiểm soát bảo mật. Những thao túng này thường không thấy được bởi người dùng cuối nhưng có thể bị AI hiểu và thực hiện. Rủi ro này càng cao trong môi trường máy chủ MCP được lưu trữ, nơi định nghĩa công cụ có thể được cập nhật sau khi người dùng đã phê duyệt — một tình huống đôi khi gọi là "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Trong những trường hợp này, một công cụ từng an toàn có thể bị sửa đổi để thực hiện hành vi độc hại, như rò rỉ dữ liệu hoặc thay đổi hành vi hệ thống mà người dùng không biết. Để biết thêm về vectơ tấn công này, xem [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.vi.png)

## Risks  
Các hành động không mong muốn của AI gây ra nhiều rủi ro bảo mật bao gồm rò rỉ dữ liệu và vi phạm quyền riêng tư.

### Mitigating controls  
### Using prompt shields to protect against Indirect Prompt Injection attacks  
-----------------------------------------------------------------------------

**AI Prompt Shields** là giải pháp do Microsoft phát triển nhằm chống lại cả prompt injection trực tiếp và gián tiếp. Chúng hỗ trợ qua các cơ chế:

1.  **Phát hiện và Lọc:** Prompt Shields sử dụng thuật toán học máy tiên tiến và xử lý ngôn ngữ tự nhiên để phát hiện và loại bỏ các chỉ thị độc hại nhúng trong nội dung bên ngoài như tài liệu, trang web hoặc email.
    
2.  **Spotlighting:** Kỹ thuật này giúp hệ thống AI phân biệt giữa chỉ thị hệ thống hợp lệ và đầu vào bên ngoài có thể không đáng tin cậy. Bằng cách biến đổi văn bản đầu vào sao cho phù hợp hơn với mô hình, Spotlighting giúp AI nhận biết và bỏ qua các chỉ thị độc hại tốt hơn.
    
3.  **Delimiters và Datamarking:** Bao gồm các ký hiệu phân định trong thông điệp hệ thống để xác định rõ vị trí của văn bản đầu vào, giúp AI nhận diện và tách biệt giữa dữ liệu người dùng và nội dung bên ngoài có thể gây hại. Datamarking mở rộng ý tưởng này bằng cách dùng các dấu hiệu đặc biệt để làm nổi bật ranh giới giữa dữ liệu tin cậy và không tin cậy.
    
4.  **Giám sát và Cập nhật Liên tục:** Microsoft liên tục theo dõi và cập nhật Prompt Shields để đối phó với các mối đe dọa mới và biến đổi. Cách tiếp cận chủ động này đảm bảo hệ thống phòng thủ luôn hiệu quả trước các kỹ thuật tấn công mới nhất.
    
5. **Tích hợp với Azure Content Safety:** Prompt Shields là một phần của bộ công cụ Azure AI Content Safety, cung cấp thêm các công cụ phát hiện các nỗ lực jailbreak, nội dung độc hại và các rủi ro bảo mật khác trong ứng dụng AI.

Bạn có thể tìm hiểu thêm về AI prompt shields trong [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.vi.png)

### Supply chain security

Bảo mật chuỗi cung ứng vẫn là yếu tố nền tảng trong thời đại AI, nhưng phạm vi của chuỗi cung ứng đã mở rộng. Ngoài các gói mã truyền thống, giờ đây bạn phải kiểm tra và giám sát chặt chẽ tất cả các thành phần liên quan đến AI, bao gồm mô hình nền tảng, dịch vụ embeddings, nhà cung cấp ngữ cảnh và API bên thứ ba. Mỗi thành phần này đều có thể tạo ra lỗ hổng hoặc rủi ro nếu không được quản lý đúng cách.

**Các thực hành bảo mật chuỗi cung ứng then chốt cho AI và MCP:**  
- **Xác minh tất cả thành phần trước khi tích hợp:** Không chỉ các thư viện mã nguồn mở, mà còn các mô hình AI, nguồn dữ liệu và API bên ngoài. Luôn kiểm tra nguồn gốc, giấy phép và các lỗ hổng đã biết.  
- **Duy trì pipeline triển khai an toàn:** Sử dụng pipeline CI/CD tự động có tích hợp quét bảo mật để phát hiện sớm vấn đề. Đảm bảo chỉ triển khai các artifact tin cậy vào môi trường sản xuất.  
- **Giám sát và kiểm toán liên tục:** Thực hiện giám sát liên tục cho tất cả các phụ thuộc, bao gồm mô hình và dịch vụ dữ liệu, để phát hiện các lỗ hổng mới hoặc các cuộc tấn công chuỗi cung ứng.  
- **Áp dụng quyền truy cập tối thiểu và kiểm soát truy cập:** Hạn chế quyền truy cập vào mô hình, dữ liệu và dịch vụ chỉ trong phạm vi cần thiết cho máy chủ MCP hoạt động.  
- **Phản ứng nhanh với các mối đe dọa:** Có quy trình vá lỗi hoặc thay thế thành phần bị xâm phạm, và thay đổi bí mật hoặc thông tin xác thực nếu phát hiện vi phạm.

[GitHub Advanced Security](https://github.com/security/advanced-security) cung cấp các tính năng như quét bí mật, quét phụ thuộc và phân tích CodeQL. Những công cụ này tích hợp với [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) và [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) giúp nhóm phát hiện và giảm thiểu lỗ hổng trong cả mã nguồn và các thành phần chuỗi cung ứng AI.

Microsoft cũng áp dụng các thực hành bảo mật chuỗi cung ứng nghiêm ngặt nội bộ cho tất cả sản phẩm. Tìm hiểu thêm tại [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Established security best practices that will uplift your MCP implementation's security posture

Bất kỳ triển khai MCP nào cũng kế thừa tư thế bảo mật hiện có của môi trường tổ chức mà nó xây dựng trên đó, vì vậy khi xem xét bảo mật MCP như một thành phần của hệ thống AI tổng thể, bạn nên nâng cao tư thế bảo mật hiện tại của mình. Các biện pháp kiểm soát bảo mật đã được thiết lập sau đây đặc biệt phù hợp:

- Thực hành lập trình an toàn trong ứng dụng AI của bạn — bảo vệ chống lại [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), sử dụng kho bảo mật cho bí mật và token, triển khai liên lạc an toàn đầu-cuối giữa tất cả các thành phần ứng dụng, v.v.
- Tăng cường bảo mật máy chủ — sử dụng MFA khi có thể, luôn cập nhật bản vá, tích hợp máy chủ với nhà cung cấp danh tính bên thứ ba để kiểm soát truy cập, v.v.
- Giữ thiết bị,
- [OWASP Top 10 cho LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Hành trình bảo mật chuỗi cung ứng phần mềm tại Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Truy cập ít quyền nhất an toàn (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Thực hành tốt nhất cho xác thực token và thời gian tồn tại](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Sử dụng lưu trữ token an toàn và mã hóa token (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management làm cổng xác thực cho MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Sử dụng Microsoft Entra ID để xác thực với MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Tiếp theo

Tiếp theo: [Chương 3: Bắt đầu](/03-GettingStarted/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc sự không chính xác. Tài liệu gốc bằng ngôn ngữ nguyên bản nên được coi là nguồn tham khảo chính thức. Đối với các thông tin quan trọng, khuyến nghị sử dụng dịch thuật chuyên nghiệp bởi con người. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.