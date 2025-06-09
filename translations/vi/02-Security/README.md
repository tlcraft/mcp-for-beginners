<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00aedb7b1d11b7eaacb0618d8791c65",
  "translation_date": "2025-05-29T23:28:16+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "vi"
}
-->
# Security Best Practices

Việc áp dụng Model Context Protocol (MCP) mang lại những khả năng mạnh mẽ cho các ứng dụng dựa trên AI, nhưng đồng thời cũng đặt ra những thách thức bảo mật đặc thù vượt ra ngoài các rủi ro phần mềm truyền thống. Ngoài những mối quan tâm đã được biết như lập trình an toàn, nguyên tắc quyền tối thiểu, và bảo mật chuỗi cung ứng, MCP và các workload AI còn đối mặt với các mối đe dọa mới như prompt injection, tool poisoning, và sửa đổi công cụ động. Những rủi ro này có thể dẫn đến rò rỉ dữ liệu, vi phạm quyền riêng tư, và hành vi hệ thống không mong muốn nếu không được quản lý đúng cách.

Bài học này sẽ khám phá những rủi ro bảo mật quan trọng liên quan đến MCP — bao gồm xác thực, ủy quyền, quyền hạn quá mức, prompt injection gián tiếp, và các lỗ hổng trong chuỗi cung ứng — đồng thời cung cấp các biện pháp kiểm soát và thực hành tốt nhất có thể áp dụng để giảm thiểu chúng. Bạn cũng sẽ học cách tận dụng các giải pháp của Microsoft như Prompt Shields, Azure Content Safety, và GitHub Advanced Security để tăng cường triển khai MCP. Bằng cách hiểu và áp dụng các kiểm soát này, bạn có thể giảm đáng kể khả năng xảy ra vi phạm bảo mật và đảm bảo hệ thống AI của mình luôn mạnh mẽ và đáng tin cậy.

# Learning Objectives

Sau khi hoàn thành bài học này, bạn sẽ có thể:

- Nhận diện và giải thích các rủi ro bảo mật đặc thù do Model Context Protocol (MCP) mang lại, bao gồm prompt injection, tool poisoning, quyền hạn quá mức, và các lỗ hổng chuỗi cung ứng.
- Mô tả và áp dụng các biện pháp kiểm soát hiệu quả để giảm thiểu rủi ro bảo mật MCP, như xác thực mạnh mẽ, nguyên tắc quyền tối thiểu, quản lý token an toàn, và xác minh chuỗi cung ứng.
- Hiểu và tận dụng các giải pháp của Microsoft như Prompt Shields, Azure Content Safety, và GitHub Advanced Security để bảo vệ MCP và các workload AI.
- Nhận thức tầm quan trọng của việc xác thực metadata công cụ, giám sát các thay đổi động, và phòng chống các cuộc tấn công prompt injection gián tiếp.
- Tích hợp các thực hành bảo mật đã được thiết lập — như lập trình an toàn, củng cố máy chủ, và kiến trúc zero trust — vào triển khai MCP để giảm thiểu khả năng và tác động của các vi phạm bảo mật.

# MCP security controls

Bất kỳ hệ thống nào có quyền truy cập vào các tài nguyên quan trọng đều có những thách thức bảo mật ngầm định. Các thách thức bảo mật thường được giải quyết thông qua việc áp dụng đúng các kiểm soát và khái niệm bảo mật cơ bản. Vì MCP mới chỉ được định nghĩa gần đây, đặc tả đang thay đổi rất nhanh khi giao thức tiến triển. Cuối cùng, các kiểm soát bảo mật trong đó sẽ trưởng thành hơn, cho phép tích hợp tốt hơn với kiến trúc bảo mật doanh nghiệp và các thực hành tốt nhất đã được thiết lập.

Nghiên cứu được công bố trong [Microsoft Digital Defense Report](https://aka.ms/mddr) cho biết 98% các vi phạm được báo cáo có thể được ngăn chặn bằng vệ sinh bảo mật nghiêm ngặt, và biện pháp bảo vệ tốt nhất chống lại bất kỳ loại vi phạm nào là đảm bảo vệ sinh bảo mật cơ bản, thực hành lập trình an toàn, và bảo mật chuỗi cung ứng được thực hiện đúng — những thực hành đã được thử nghiệm và chứng minh vẫn là cách hiệu quả nhất để giảm thiểu rủi ro bảo mật.

Hãy cùng xem một số cách bạn có thể bắt đầu giải quyết các rủi ro bảo mật khi áp dụng MCP.

> **Note:** Thông tin dưới đây chính xác tính đến **29 tháng 5 năm 2025**. Giao thức MCP liên tục phát triển, và các triển khai trong tương lai có thể giới thiệu các mẫu xác thực và kiểm soát mới. Để cập nhật và hướng dẫn mới nhất, luôn tham khảo [MCP Specification](https://spec.modelcontextprotocol.io/) cùng kho lưu trữ chính thức [MCP GitHub repository](https://github.com/modelcontextprotocol) và [security best practice page](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Problem statement  
Đặc tả MCP ban đầu giả định các nhà phát triển sẽ tự xây dựng máy chủ xác thực của riêng họ. Điều này đòi hỏi kiến thức về OAuth và các giới hạn bảo mật liên quan. Máy chủ MCP hoạt động như các OAuth 2.0 Authorization Servers, quản lý việc xác thực người dùng trực tiếp thay vì ủy quyền cho dịch vụ bên ngoài như Microsoft Entra ID. Tính đến **26 tháng 4 năm 2025**, một bản cập nhật đặc tả MCP cho phép máy chủ MCP ủy quyền xác thực người dùng cho dịch vụ bên ngoài.

### Risks
- Logic ủy quyền cấu hình sai trong máy chủ MCP có thể dẫn đến lộ dữ liệu nhạy cảm và kiểm soát truy cập không chính xác.
- Trộm token OAuth trên máy chủ MCP cục bộ. Nếu token bị đánh cắp, kẻ tấn công có thể giả danh máy chủ MCP để truy cập tài nguyên và dữ liệu của dịch vụ tương ứng với token đó.

#### Token Passthrough
Token passthrough bị cấm rõ ràng trong đặc tả ủy quyền vì nó gây ra nhiều rủi ro bảo mật, bao gồm:

#### Security Control Circumvention
Máy chủ MCP hoặc API hạ nguồn có thể thực thi các kiểm soát bảo mật quan trọng như giới hạn tốc độ, xác thực yêu cầu, hoặc giám sát lưu lượng, dựa trên audience của token hoặc các giới hạn chứng thực khác. Nếu client có thể lấy và sử dụng token trực tiếp với API hạ nguồn mà không qua xác thực đúng của máy chủ MCP hoặc không đảm bảo token được cấp cho đúng dịch vụ, thì các kiểm soát này sẽ bị bỏ qua.

#### Accountability and Audit Trail Issues
Máy chủ MCP sẽ không thể xác định hoặc phân biệt các MCP Clients khi client gọi với token truy cập được cấp từ upstream mà máy chủ MCP không thể đọc rõ.
Nhật ký của Resource Server hạ nguồn có thể ghi nhận các yêu cầu có vẻ như đến từ nguồn khác với danh tính khác, thay vì máy chủ MCP thực sự chuyển tiếp token.
Cả hai yếu tố này làm cho việc điều tra sự cố, kiểm soát và kiểm toán trở nên khó khăn hơn.
Nếu máy chủ MCP chuyển token mà không xác thực các claim của token (ví dụ: roles, privileges, hoặc audience) hoặc các metadata khác, kẻ tấn công có token bị đánh cắp có thể lợi dụng máy chủ như một proxy để rò rỉ dữ liệu.

#### Trust Boundary Issues
Resource Server hạ nguồn đặt niềm tin vào các thực thể cụ thể. Niềm tin này có thể bao gồm giả định về nguồn gốc hoặc hành vi client. Việc phá vỡ ranh giới niềm tin này có thể dẫn đến các vấn đề không mong muốn.
Nếu token được chấp nhận bởi nhiều dịch vụ mà không xác thực đúng, kẻ tấn công xâm nhập một dịch vụ có thể dùng token để truy cập các dịch vụ kết nối khác.

#### Future Compatibility Risk
Ngay cả khi máy chủ MCP bắt đầu chỉ như một “pure proxy” ngày hôm nay, nó có thể cần thêm các kiểm soát bảo mật sau này. Việc bắt đầu với phân tách audience token đúng cách sẽ giúp dễ dàng phát triển mô hình bảo mật.

### Mitigating controls

**MCP servers MUST NOT accept any tokens that were not explicitly issued for the MCP server**

- **Review and Harden Authorization Logic:** Kiểm tra kỹ lưỡng việc triển khai ủy quyền của máy chủ MCP để đảm bảo chỉ những người dùng và client dự kiến mới có thể truy cập tài nguyên nhạy cảm. Để có hướng dẫn thực tế, xem [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) và [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Enforce Secure Token Practices:** Tuân thủ [thực hành tốt nhất của Microsoft về xác thực token và thời gian sống](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) để ngăn ngừa việc sử dụng sai token truy cập và giảm rủi ro token bị phát lại hoặc đánh cắp.
- **Protect Token Storage:** Luôn lưu trữ token một cách an toàn và sử dụng mã hóa để bảo vệ chúng khi lưu trữ và truyền tải. Để biết mẹo triển khai, xem [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Excessive permissions for MCP servers

### Problem statement
Máy chủ MCP có thể được cấp quyền quá mức đối với dịch vụ/tài nguyên mà chúng truy cập. Ví dụ, một máy chủ MCP trong ứng dụng bán hàng AI kết nối với kho dữ liệu doanh nghiệp nên chỉ được cấp quyền truy cập giới hạn vào dữ liệu bán hàng, không được phép truy cập tất cả các file trong kho. Quay lại nguyên tắc quyền tối thiểu (một trong những nguyên tắc bảo mật lâu đời nhất), không tài nguyên nào nên có quyền vượt quá mức cần thiết để thực hiện các nhiệm vụ dự định. AI đặt ra thách thức lớn trong việc xác định chính xác các quyền cần thiết vì tính linh hoạt của nó.

### Risks  
- Cấp quyền quá mức có thể cho phép rò rỉ hoặc sửa đổi dữ liệu mà máy chủ MCP không được phép truy cập. Đây cũng có thể là vấn đề về quyền riêng tư nếu dữ liệu là thông tin cá nhân (PII).

### Mitigating controls
- **Apply the Principle of Least Privilege:** Chỉ cấp cho máy chủ MCP quyền tối thiểu cần thiết để thực hiện nhiệm vụ. Thường xuyên rà soát và cập nhật quyền để đảm bảo không vượt quá mức cần thiết. Để biết hướng dẫn chi tiết, xem [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Use Role-Based Access Control (RBAC):** Gán vai trò cho máy chủ MCP với phạm vi chặt chẽ trên tài nguyên và hành động cụ thể, tránh các quyền rộng hoặc không cần thiết.
- **Monitor and Audit Permissions:** Giám sát liên tục việc sử dụng quyền và kiểm toán nhật ký truy cập để phát hiện và xử lý kịp thời các quyền quá mức hoặc không sử dụng.

# Indirect prompt injection attacks

### Problem statement

Các máy chủ MCP bị xâm phạm hoặc độc hại có thể gây ra rủi ro nghiêm trọng bằng cách làm lộ dữ liệu khách hàng hoặc cho phép các hành động không mong muốn. Những rủi ro này đặc biệt quan trọng trong các workload AI và MCP, nơi:

- **Prompt Injection Attacks**: Kẻ tấn công nhúng các chỉ dẫn độc hại vào prompt hoặc nội dung bên ngoài, khiến hệ thống AI thực hiện các hành động không mong muốn hoặc rò rỉ dữ liệu nhạy cảm. Tìm hiểu thêm: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning**: Kẻ tấn công thao túng metadata công cụ (như mô tả hoặc tham số) để ảnh hưởng hành vi AI, có thể vượt qua kiểm soát bảo mật hoặc rò rỉ dữ liệu. Chi tiết: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection**: Các chỉ dẫn độc hại được nhúng trong tài liệu, trang web hoặc email, sau đó được AI xử lý, dẫn đến rò rỉ hoặc thao túng dữ liệu.
- **Dynamic Tool Modification (Rug Pulls)**: Định nghĩa công cụ có thể bị thay đổi sau khi được người dùng phê duyệt, đưa vào các hành vi độc hại mới mà người dùng không biết.

Những lỗ hổng này làm nổi bật nhu cầu về xác thực chặt chẽ, giám sát, và các kiểm soát bảo mật khi tích hợp máy chủ MCP và công cụ vào môi trường của bạn. Để tìm hiểu sâu hơn, xem các tham chiếu liên kết phía trên.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.vi.png)

**Indirect Prompt Injection** (còn gọi là cross-domain prompt injection hoặc XPIA) là một lỗ hổng nghiêm trọng trong hệ thống AI sinh tạo, bao gồm cả những hệ thống sử dụng Model Context Protocol (MCP). Trong cuộc tấn công này, các chỉ dẫn độc hại được giấu trong nội dung bên ngoài — như tài liệu, trang web, hoặc email. Khi hệ thống AI xử lý nội dung này, nó có thể hiểu các chỉ dẫn nhúng là lệnh hợp lệ từ người dùng, dẫn đến các hành động không mong muốn như rò rỉ dữ liệu, tạo nội dung có hại, hoặc thao túng tương tác người dùng. Để biết giải thích chi tiết và ví dụ thực tế, xem [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Một dạng tấn công đặc biệt nguy hiểm là **Tool Poisoning**. Ở đây, kẻ tấn công chèn các chỉ dẫn độc hại vào metadata của công cụ MCP (như mô tả hoặc tham số công cụ). Vì các mô hình ngôn ngữ lớn (LLM) dựa vào metadata này để quyết định công cụ nào sẽ được gọi, các mô tả bị xâm phạm có thể khiến mô hình thực thi các lệnh công cụ trái phép hoặc bỏ qua kiểm soát bảo mật. Những thao túng này thường không thấy được bởi người dùng cuối nhưng lại được AI hiểu và thực hiện. Rủi ro này càng lớn hơn trong môi trường máy chủ MCP được lưu trữ, nơi định nghĩa công cụ có thể được cập nhật sau khi người dùng phê duyệt — một tình huống đôi khi gọi là "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Trong trường hợp này, một công cụ trước đó an toàn có thể bị thay đổi để thực hiện hành vi độc hại, như rò rỉ dữ liệu hoặc thay đổi hành vi hệ thống mà người dùng không hay biết. Để biết thêm về vectơ tấn công này, xem [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.vi.png)

## Risks
Các hành động AI không mong muốn gây ra nhiều rủi ro bảo mật bao gồm rò rỉ dữ liệu và vi phạm quyền riêng tư.

### Mitigating controls
### Using prompt shields to protect against Indirect Prompt Injection attacks
-----------------------------------------------------------------------------

**AI Prompt Shields** là giải pháp do Microsoft phát triển nhằm bảo vệ chống lại cả các cuộc tấn công prompt injection trực tiếp và gián tiếp. Chúng hỗ trợ thông qua:

1.  **Detection and Filtering**: Prompt Shields sử dụng các thuật toán máy học tiên tiến và xử lý ngôn ngữ tự nhiên để phát hiện và lọc các chỉ dẫn độc hại nhúng trong nội dung bên ngoài, như tài liệu, trang web hoặc email.
    
2.  **Spotlighting**: Kỹ thuật này giúp hệ thống AI phân biệt giữa các chỉ dẫn hệ thống hợp lệ và các đầu vào bên ngoài có thể không đáng tin cậy. Bằng cách biến đổi văn bản đầu vào sao cho phù hợp hơn với mô hình, Spotlighting giúp AI nhận diện và bỏ qua các chỉ dẫn độc hại tốt hơn.
    
3.  **Delimiters and Datamarking**: Việc sử dụng delimiters trong thông điệp hệ thống xác định rõ vị trí của văn bản đầu vào, giúp AI nhận ra và tách biệt các đầu vào của người dùng khỏi nội dung bên ngoài có thể gây hại. Datamarking mở rộng ý tưởng này bằng cách sử dụng các dấu đặc biệt để đánh dấu ranh giới giữa dữ liệu đáng tin cậy và không đáng tin cậy.
    
4.  **Continuous Monitoring and Updates**: Microsoft liên tục giám sát và cập nhật Prompt Shields để ứng phó với các mối đe dọa mới và đang phát triển. Cách tiếp cận chủ động này đảm bảo các biện pháp phòng thủ luôn hiệu quả trước các kỹ thuật tấn công mới nhất.
    
5. **Integration with Azure Content Safety:** Prompt Shields là một phần của bộ công cụ Azure AI Content Safety rộng hơn, cung cấp các công cụ bổ sung để phát hiện các cố gắng jailbreak, nội dung độc hại, và các rủi ro bảo mật khác trong ứng dụng AI.

Bạn có thể tìm hiểu thêm về AI prompt shields trong [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.vi.png)

### Supply chain security

Bảo mật chuỗi cung ứng vẫn là nền tảng trong thời đại AI, nhưng phạm vi của chuỗi cung ứng đã mở rộng. Ngoài các gói mã truyền thống, bạn phải kiểm tra và giám sát chặt chẽ tất cả các thành phần liên quan đến AI, bao gồm mô hình nền tảng, dịch vụ embeddings, nhà cung cấp ngữ cảnh, và API bên thứ ba. Mỗi thành phần này đều có thể mang đến lỗ hổng hoặc rủi ro nếu không được quản lý đúng.

**Các thực hành bảo mật chuỗi cung ứng quan trọng cho AI và MCP:**
- **Verify all components before integration:** Kiểm tra không chỉ các thư viện mã nguồn mở mà còn các mô hình AI, nguồn dữ liệu, và API bên ngoài. Luôn kiểm tra nguồn gốc, giấy phép, và các lỗ hổng đã biết.
- **Maintain secure deployment pipelines:** Sử dụng các pipeline CI/CD tự động tích hợp quét bảo mật để phát hiện sớm các vấn đề. Đảm bảo chỉ các artifact tin cậy được triển khai vào môi trường sản xuất.
- **Continuously monitor and audit:** Thực hiện giám sát liên tục cho tất cả các phụ thuộc, bao gồm mô hình và dịch vụ dữ liệu, để phát hiện các lỗ hổng hoặc tấn công chuỗi cung ứng mới.
- **Apply least privilege and access controls:** Hạn chế quyền
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Hành trình bảo mật Chuỗi cung ứng Phần mềm tại Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Truy cập Tối thiểu An toàn (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Thực hành Tốt nhất cho Xác thực Token và Thời gian tồn tại](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Sử dụng Lưu trữ Token An toàn và Mã hóa Token (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management làm Cổng xác thực cho MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Thực hành An ninh Tốt nhất cho MCP](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Sử dụng Microsoft Entra ID để Xác thực với Máy chủ MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Tiếp theo

Tiếp theo: [Chương 3: Bắt đầu](/03-GettingStarted/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc nên được xem là nguồn tham khảo chính thức. Đối với các thông tin quan trọng, nên sử dụng dịch thuật chuyên nghiệp bởi con người. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc diễn giải sai nào phát sinh từ việc sử dụng bản dịch này.