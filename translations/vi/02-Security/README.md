<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "382fddb4ee4d9c1bdc806e2ee99b70c8",
  "translation_date": "2025-07-17T07:44:42+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "vi"
}
-->
# Thực hành bảo mật tốt nhất

Việc áp dụng Model Context Protocol (MCP) mang lại những khả năng mạnh mẽ cho các ứng dụng dựa trên AI, nhưng cũng đồng thời tạo ra những thách thức bảo mật đặc thù vượt ra ngoài các rủi ro phần mềm truyền thống. Bên cạnh các mối quan tâm đã được thiết lập như lập trình an toàn, quyền truy cập tối thiểu và bảo mật chuỗi cung ứng, MCP và các khối lượng công việc AI còn đối mặt với các mối đe dọa mới như chèn prompt, đầu độc công cụ, thay đổi công cụ động, chiếm đoạt phiên làm việc, tấn công confused deputy và lỗ hổng truyền token. Những rủi ro này có thể dẫn đến việc rò rỉ dữ liệu, vi phạm quyền riêng tư và hành vi hệ thống không mong muốn nếu không được quản lý đúng cách.

Bài học này sẽ khám phá các rủi ro bảo mật liên quan đến MCP—bao gồm xác thực, ủy quyền, quyền truy cập quá mức, chèn prompt gián tiếp, bảo mật phiên làm việc, vấn đề confused deputy, lỗ hổng truyền token và lỗ hổng chuỗi cung ứng—và cung cấp các biện pháp kiểm soát cũng như thực hành tốt nhất để giảm thiểu chúng. Bạn cũng sẽ học cách tận dụng các giải pháp của Microsoft như Prompt Shields, Azure Content Safety và GitHub Advanced Security để củng cố việc triển khai MCP. Bằng cách hiểu và áp dụng các biện pháp kiểm soát này, bạn có thể giảm đáng kể khả năng xảy ra vi phạm bảo mật và đảm bảo hệ thống AI của mình luôn mạnh mẽ và đáng tin cậy.

# Mục tiêu học tập

Sau khi hoàn thành bài học này, bạn sẽ có khả năng:

- Nhận diện và giải thích các rủi ro bảo mật đặc thù do Model Context Protocol (MCP) mang lại, bao gồm chèn prompt, đầu độc công cụ, quyền truy cập quá mức, chiếm đoạt phiên làm việc, vấn đề confused deputy, lỗ hổng truyền token và lỗ hổng chuỗi cung ứng.
- Mô tả và áp dụng các biện pháp kiểm soát hiệu quả để giảm thiểu rủi ro bảo mật MCP, như xác thực mạnh mẽ, quyền truy cập tối thiểu, quản lý token an toàn, kiểm soát bảo mật phiên làm việc và xác minh chuỗi cung ứng.
- Hiểu và tận dụng các giải pháp của Microsoft như Prompt Shields, Azure Content Safety và GitHub Advanced Security để bảo vệ MCP và các khối lượng công việc AI.
- Nhận biết tầm quan trọng của việc xác thực metadata công cụ, giám sát các thay đổi động, phòng chống các cuộc tấn công chèn prompt gián tiếp và ngăn chặn chiếm đoạt phiên làm việc.
- Tích hợp các thực hành bảo mật đã được thiết lập—như lập trình an toàn, tăng cường bảo mật máy chủ và kiến trúc zero trust—vào việc triển khai MCP để giảm thiểu khả năng và tác động của các vi phạm bảo mật.

# Các biện pháp kiểm soát bảo mật MCP

Bất kỳ hệ thống nào có quyền truy cập vào các tài nguyên quan trọng đều đối mặt với những thách thức bảo mật nhất định. Các thách thức này thường được giải quyết thông qua việc áp dụng đúng các biện pháp kiểm soát và khái niệm bảo mật cơ bản. Vì MCP mới được định nghĩa gần đây, đặc tả đang thay đổi rất nhanh và sẽ tiếp tục phát triển. Cuối cùng, các biện pháp kiểm soát bảo mật trong MCP sẽ trưởng thành hơn, cho phép tích hợp tốt hơn với kiến trúc bảo mật doanh nghiệp và các thực hành tốt nhất đã được thiết lập.

Nghiên cứu được công bố trong [Microsoft Digital Defense Report](https://aka.ms/mddr) cho thấy 98% các vụ vi phạm được báo cáo có thể được ngăn chặn bằng việc duy trì vệ sinh bảo mật nghiêm ngặt và biện pháp bảo vệ tốt nhất chống lại mọi loại vi phạm là đảm bảo vệ sinh bảo mật cơ bản, thực hành lập trình an toàn và bảo mật chuỗi cung ứng được thực hiện đúng—những thực hành đã được kiểm chứng này vẫn là cách hiệu quả nhất để giảm thiểu rủi ro bảo mật.

Hãy cùng xem một số cách bạn có thể bắt đầu giải quyết các rủi ro bảo mật khi áp dụng MCP.

> **Note:** Thông tin dưới đây chính xác tính đến **29 tháng 5 năm 2025**. Giao thức MCP liên tục phát triển, và các triển khai trong tương lai có thể giới thiệu các mẫu xác thực và biện pháp kiểm soát mới. Để cập nhật và hướng dẫn mới nhất, luôn tham khảo [MCP Specification](https://spec.modelcontextprotocol.io/), kho lưu trữ chính thức [MCP GitHub repository](https://github.com/modelcontextprotocol) và [trang thực hành bảo mật tốt nhất](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Vấn đề đặt ra  
Đặc tả MCP ban đầu giả định rằng các nhà phát triển sẽ tự viết máy chủ xác thực của riêng họ. Điều này đòi hỏi kiến thức về OAuth và các ràng buộc bảo mật liên quan. Máy chủ MCP hoạt động như OAuth 2.0 Authorization Server, quản lý xác thực người dùng trực tiếp thay vì ủy quyền cho dịch vụ bên ngoài như Microsoft Entra ID. Từ ngày **26 tháng 4 năm 2025**, một cập nhật trong đặc tả MCP cho phép máy chủ MCP ủy quyền xác thực người dùng cho dịch vụ bên ngoài.

### Rủi ro
- Logic ủy quyền cấu hình sai trong máy chủ MCP có thể dẫn đến việc lộ dữ liệu nhạy cảm và áp dụng sai các kiểm soát truy cập.
- Trộm token OAuth trên máy chủ MCP cục bộ. Nếu token bị đánh cắp, kẻ tấn công có thể giả mạo máy chủ MCP và truy cập tài nguyên, dữ liệu từ dịch vụ mà token OAuth đó được cấp.

#### Token Passthrough
Token passthrough bị cấm rõ ràng trong đặc tả ủy quyền vì nó tạo ra nhiều rủi ro bảo mật, bao gồm:

#### Vượt qua kiểm soát bảo mật
Máy chủ MCP hoặc các API hạ nguồn có thể triển khai các biện pháp kiểm soát bảo mật quan trọng như giới hạn tốc độ, xác thực yêu cầu hoặc giám sát lưu lượng, dựa vào đối tượng token hoặc các ràng buộc chứng thực khác. Nếu khách hàng có thể lấy và sử dụng token trực tiếp với các API hạ nguồn mà không qua xác thực đúng của máy chủ MCP hoặc không đảm bảo token được cấp cho dịch vụ đúng, họ sẽ vượt qua các kiểm soát này.

#### Vấn đề trách nhiệm và theo dõi kiểm toán
Máy chủ MCP sẽ không thể nhận diện hoặc phân biệt giữa các MCP Client khi khách hàng gọi với token truy cập được cấp từ upstream mà máy chủ MCP có thể không hiểu rõ.
Nhật ký của Resource Server hạ nguồn có thể hiển thị các yêu cầu có vẻ đến từ nguồn khác với danh tính khác, thay vì từ máy chủ MCP thực sự chuyển tiếp token.
Cả hai yếu tố này làm cho việc điều tra sự cố, kiểm soát và kiểm toán trở nên khó khăn hơn.
Nếu máy chủ MCP chuyển tiếp token mà không xác thực các tuyên bố của token (ví dụ: vai trò, đặc quyền hoặc đối tượng) hoặc metadata khác, kẻ xấu có token bị đánh cắp có thể dùng máy chủ như một proxy để rút dữ liệu.

#### Vấn đề ranh giới tin cậy
Resource Server hạ nguồn cấp quyền tin cậy cho các thực thể cụ thể. Quyền tin cậy này có thể bao gồm các giả định về nguồn gốc hoặc hành vi của khách hàng. Việc phá vỡ ranh giới tin cậy này có thể dẫn đến các vấn đề không mong muốn.
Nếu token được chấp nhận bởi nhiều dịch vụ mà không được xác thực đúng, kẻ tấn công xâm phạm một dịch vụ có thể dùng token để truy cập các dịch vụ kết nối khác.

#### Rủi ro tương thích trong tương lai
Ngay cả khi máy chủ MCP bắt đầu như một "proxy thuần túy" hôm nay, nó có thể cần thêm các biện pháp kiểm soát bảo mật sau này. Bắt đầu với việc phân tách đối tượng token đúng cách sẽ giúp dễ dàng phát triển mô hình bảo mật hơn.

### Biện pháp giảm thiểu

**Máy chủ MCP KHÔNG ĐƯỢC chấp nhận bất kỳ token nào không được cấp rõ ràng cho máy chủ MCP**

- **Xem xét và củng cố logic ủy quyền:** Kiểm tra kỹ lưỡng việc triển khai ủy quyền của máy chủ MCP để đảm bảo chỉ người dùng và khách hàng được phép mới có thể truy cập tài nguyên nhạy cảm. Để được hướng dẫn thực tế, xem [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) và [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Thực thi các thực hành bảo mật token:** Tuân theo [thực hành tốt nhất của Microsoft về xác thực token và thời gian hiệu lực](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) để ngăn chặn việc sử dụng sai token truy cập và giảm nguy cơ phát lại hoặc đánh cắp token.
- **Bảo vệ lưu trữ token:** Luôn lưu trữ token một cách an toàn và sử dụng mã hóa để bảo vệ chúng khi lưu trữ và truyền tải. Để biết mẹo triển khai, xem [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Quyền truy cập quá mức cho máy chủ MCP

### Vấn đề đặt ra
Máy chủ MCP có thể được cấp quyền truy cập quá mức đối với dịch vụ hoặc tài nguyên mà nó truy cập. Ví dụ, một máy chủ MCP trong ứng dụng bán hàng AI kết nối với kho dữ liệu doanh nghiệp nên chỉ được phép truy cập dữ liệu bán hàng, không được phép truy cập tất cả các tệp trong kho. Quay lại nguyên tắc quyền truy cập tối thiểu (một trong những nguyên tắc bảo mật lâu đời nhất), không tài nguyên nào nên có quyền vượt quá mức cần thiết để thực hiện nhiệm vụ được giao. AI đặt ra thách thức lớn hơn trong lĩnh vực này vì để nó linh hoạt, việc xác định chính xác quyền cần thiết có thể rất khó khăn.

### Rủi ro  
- Cấp quyền quá mức có thể cho phép rút dữ liệu hoặc sửa đổi dữ liệu mà máy chủ MCP không được phép truy cập. Điều này cũng có thể gây ra vấn đề về quyền riêng tư nếu dữ liệu là thông tin cá nhân nhận dạng được (PII).

### Biện pháp giảm thiểu
- **Áp dụng nguyên tắc quyền truy cập tối thiểu:** Chỉ cấp cho máy chủ MCP những quyền tối thiểu cần thiết để thực hiện nhiệm vụ. Thường xuyên xem xét và cập nhật quyền để đảm bảo không vượt quá mức cần thiết. Để được hướng dẫn chi tiết, xem [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Sử dụng kiểm soát truy cập dựa trên vai trò (RBAC):** Gán vai trò cho máy chủ MCP với phạm vi chặt chẽ đối với các tài nguyên và hành động cụ thể, tránh cấp quyền rộng hoặc không cần thiết.
- **Giám sát và kiểm toán quyền:** Liên tục theo dõi việc sử dụng quyền và kiểm tra nhật ký truy cập để phát hiện và xử lý kịp thời các quyền quá mức hoặc không sử dụng.

# Tấn công chèn prompt gián tiếp

### Vấn đề đặt ra

Máy chủ MCP bị tấn công hoặc bị xâm phạm có thể gây ra rủi ro lớn bằng cách làm lộ dữ liệu khách hàng hoặc cho phép các hành động không mong muốn. Những rủi ro này đặc biệt quan trọng trong các khối lượng công việc AI và MCP, nơi:

- **Tấn công chèn prompt:** Kẻ tấn công nhúng các chỉ dẫn độc hại vào prompt hoặc nội dung bên ngoài, khiến hệ thống AI thực hiện các hành động không mong muốn hoặc rò rỉ dữ liệu nhạy cảm. Tìm hiểu thêm: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Đầu độc công cụ:** Kẻ tấn công thao túng metadata công cụ (như mô tả hoặc tham số) để ảnh hưởng đến hành vi AI, có thể vượt qua các kiểm soát bảo mật hoặc rút dữ liệu. Chi tiết: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Chèn prompt xuyên miền:** Các chỉ dẫn độc hại được nhúng trong tài liệu, trang web hoặc email, sau đó được AI xử lý, dẫn đến rò rỉ hoặc thao túng dữ liệu.
- **Thay đổi công cụ động (Rug Pulls):** Định nghĩa công cụ có thể bị thay đổi sau khi người dùng phê duyệt, đưa vào các hành vi độc hại mới mà người dùng không hay biết.

Những lỗ hổng này nhấn mạnh sự cần thiết của việc xác thực chặt chẽ, giám sát và các biện pháp bảo mật khi tích hợp máy chủ MCP và công cụ vào môi trường của bạn. Để tìm hiểu sâu hơn, xem các tài liệu tham khảo liên kết ở trên.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.vi.png)

**Chèn prompt gián tiếp** (còn gọi là chèn prompt xuyên miền hoặc XPIA) là một lỗ hổng nghiêm trọng trong các hệ thống AI sinh tạo, bao gồm cả những hệ thống sử dụng Model Context Protocol (MCP). Trong cuộc tấn công này, các chỉ dẫn độc hại được giấu trong nội dung bên ngoài—như tài liệu, trang web hoặc email. Khi hệ thống AI xử lý nội dung này, nó có thể hiểu các chỉ dẫn nhúng như là lệnh hợp lệ từ người dùng, dẫn đến các hành động không mong muốn như rò rỉ dữ liệu, tạo nội dung có hại hoặc thao túng tương tác với người dùng. Để biết giải thích chi tiết và ví dụ thực tế, xem [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Một dạng tấn công đặc biệt nguy hiểm là **Đầu độc công cụ**. Ở đây, kẻ tấn công chèn các chỉ dẫn độc hại vào metadata của các công cụ MCP (như mô tả công cụ hoặc tham số). Vì các mô hình ngôn ngữ lớn (LLM) dựa vào metadata này để quyết định công cụ nào sẽ được gọi, các mô tả bị xâm phạm có thể lừa mô hình thực thi các lệnh gọi công cụ trái phép hoặc vượt qua các kiểm soát bảo mật. Những thao túng này thường không hiển thị với người dùng cuối nhưng có thể được AI hiểu và thực hiện. Rủi ro này càng tăng cao trong môi trường máy chủ MCP được lưu trữ, nơi định nghĩa công cụ có thể được cập nhật sau khi người dùng phê duyệt—tình huống này đôi khi được gọi là "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Trong trường hợp đó, một công cụ từng an toàn có thể bị thay đổi để thực hiện các hành vi độc hại, như rút dữ liệu hoặc thay đổi hành vi hệ thống, mà người dùng không hay biết. Để biết thêm về vectơ tấn công này, xem [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.vi.png)

## Rủi ro
Các hành động AI không mong muốn gây ra nhiều rủi ro bảo mật, bao gồm rút dữ liệu và vi phạm quyền riêng tư.

### Biện pháp giảm thiểu
### Sử dụng prompt shields để bảo vệ chống lại tấn công chèn prompt gián tiếp
-----------------------------------------------------------------------------

**AI Prompt Shields** là giải pháp do Microsoft phát triển nhằm phòng chống cả tấn công chèn prompt trực tiếp và gián tiếp. Chúng hỗ trợ bằng cách:

1.  **Phát hiện và lọc:** Prompt Shields sử dụng các thuật toán học máy tiên tiến và xử lý ngôn ngữ tự nhiên để phát hiện và lọc các chỉ dẫn độc hại nhúng trong nội dung bên ngoài, như tài liệu, trang web hoặc email.
    
2.  **Spotlighting:** Kỹ thuật này giúp hệ thống AI phân biệt giữa các chỉ dẫn hệ thống hợp lệ và các đầu vào bên ngoài có thể không đáng tin cậy. Bằng cách biến đổi văn bản đầu vào sao cho phù hợp hơn với mô hình, Spotlighting giúp AI nhận diện và bỏ qua các chỉ dẫn độc hại tốt hơn.
    
3.  **Dấu phân cách và đánh dấu dữ liệu:** Việc bao gồm các dấu phân cách trong thông điệp hệ thống giúp xác định rõ vị trí của văn bản đầu vào, giúp AI nhận biết và tách biệt các đầu vào của người dùng với nội dung bên ngoài có thể gây hại. Đánh dấu dữ liệu mở rộng khái niệm này bằng cách sử dụng các ký hiệu đặc biệt để làm nổi bật ranh giới giữa dữ liệu tin cậy và không tin cậy.
    
4.  **Giám sát và cập nhật liên tục:** Microsoft liên tục giám sát và cập nhật Prompt Shields để đối phó với các mối đe dọa mới và đang phát triển. Cách tiếp cận chủ động này đảm bảo các biện pháp phòng thủ luôn hiệu quả trước các kỹ thuật tấn công mới nhất.
    
5. **Tích hợp với Azure Content Safety:** Prompt Shields là một phần của bộ công cụ Azure AI Content Safety rộng hơn, cung cấp các công cụ bổ sung để phát hiện các nỗ lực jailbreak, nội dung độc hại và các rủi ro bảo mật khác trong ứng dụng AI.

Bạn có thể đọc thêm về AI prompt shields trong [tài liệu Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.vi.png)

# Vấn đề Confused Deputy


Vấn đề confused deputy là một lỗ hổng bảo mật xảy ra khi một máy chủ MCP đóng vai trò làm proxy giữa các client MCP và các API bên thứ ba. Lỗ hổng này có thể bị khai thác khi máy chủ MCP sử dụng một client ID tĩnh để xác thực với máy chủ ủy quyền bên thứ ba không hỗ trợ đăng ký client động.

### Rủi ro

- **Vượt qua sự đồng ý dựa trên cookie**: Nếu người dùng đã từng xác thực qua máy chủ proxy MCP, máy chủ ủy quyền bên thứ ba có thể đặt cookie đồng ý trong trình duyệt của người dùng. Kẻ tấn công có thể lợi dụng điều này bằng cách gửi cho người dùng một liên kết độc hại chứa yêu cầu ủy quyền được tạo thủ công với URI chuyển hướng độc hại.
- **Trộm mã ủy quyền**: Khi người dùng nhấp vào liên kết độc hại, máy chủ ủy quyền bên thứ ba có thể bỏ qua màn hình đồng ý do cookie đã tồn tại, và mã ủy quyền có thể bị chuyển hướng đến máy chủ của kẻ tấn công.
- **Truy cập API trái phép**: Kẻ tấn công có thể đổi mã ủy quyền bị đánh cắp lấy token truy cập và giả danh người dùng để truy cập API bên thứ ba mà không cần sự chấp thuận rõ ràng.

### Các biện pháp giảm thiểu

- **Yêu cầu đồng ý rõ ràng**: Máy chủ proxy MCP sử dụng client ID tĩnh **PHẢI** lấy sự đồng ý của người dùng cho mỗi client được đăng ký động trước khi chuyển tiếp đến máy chủ ủy quyền bên thứ ba.
- **Triển khai OAuth đúng cách**: Tuân thủ các thực hành bảo mật tốt nhất của OAuth 2.1, bao gồm sử dụng code challenge (PKCE) cho các yêu cầu ủy quyền để ngăn chặn các cuộc tấn công chặn mã.
- **Xác thực client**: Thực hiện xác thực nghiêm ngặt các URI chuyển hướng và định danh client để ngăn chặn việc khai thác bởi các tác nhân độc hại.

# Lỗ hổng Token Passthrough

### Vấn đề

"Token passthrough" là một mô hình sai lầm khi máy chủ MCP chấp nhận token từ client MCP mà không xác thực rằng token đó được cấp hợp lệ cho chính máy chủ MCP, rồi "chuyển tiếp" token đó đến các API phía dưới. Thực hành này vi phạm rõ ràng đặc tả ủy quyền MCP và gây ra các rủi ro bảo mật nghiêm trọng.

### Rủi ro

- **Vượt qua kiểm soát bảo mật**: Client có thể bỏ qua các kiểm soát bảo mật quan trọng như giới hạn tốc độ, xác thực yêu cầu hoặc giám sát lưu lượng nếu họ có thể sử dụng token trực tiếp với các API phía dưới mà không được xác thực đúng cách.
- **Vấn đề trách nhiệm và theo dõi**: Máy chủ MCP sẽ không thể nhận diện hoặc phân biệt các client MCP khi client sử dụng token truy cập được cấp từ phía trên, làm cho việc điều tra sự cố và kiểm toán trở nên khó khăn hơn.
- **Rò rỉ dữ liệu**: Nếu token được chuyển tiếp mà không xác thực các claims đúng cách, kẻ tấn công có token bị đánh cắp có thể dùng máy chủ làm proxy để rò rỉ dữ liệu.
- **Vi phạm ranh giới tin cậy**: Các máy chủ tài nguyên phía dưới có thể tin tưởng vào các thực thể cụ thể dựa trên giả định về nguồn gốc hoặc hành vi. Vi phạm ranh giới tin cậy này có thể dẫn đến các vấn đề bảo mật không mong muốn.
- **Lạm dụng token đa dịch vụ**: Nếu token được chấp nhận bởi nhiều dịch vụ mà không xác thực đúng, kẻ tấn công xâm nhập một dịch vụ có thể dùng token để truy cập các dịch vụ kết nối khác.

### Các biện pháp giảm thiểu

- **Xác thực token**: Máy chủ MCP **KHÔNG ĐƯỢC** chấp nhận bất kỳ token nào không được cấp rõ ràng cho chính máy chủ MCP.
- **Xác minh audience**: Luôn xác thực rằng token có claim audience đúng với định danh của máy chủ MCP.
- **Quản lý vòng đời token đúng cách**: Triển khai token truy cập có thời gian sống ngắn và thực hành xoay vòng token hợp lý để giảm rủi ro trộm cắp và lạm dụng token.

# Chiếm đoạt phiên làm việc (Session Hijacking)

### Vấn đề

Chiếm đoạt phiên làm việc là một phương thức tấn công khi client được máy chủ cấp một session ID, và một bên không được phép lấy được session ID đó để giả danh client gốc và thực hiện các hành động trái phép thay mặt họ. Điều này đặc biệt đáng lo ngại với các máy chủ HTTP trạng thái xử lý các yêu cầu MCP.

### Rủi ro

- **Tiêm prompt chiếm đoạt phiên**: Kẻ tấn công có session ID có thể gửi các sự kiện độc hại đến máy chủ chia sẻ trạng thái phiên với máy chủ mà client đang kết nối, có thể kích hoạt các hành động gây hại hoặc truy cập dữ liệu nhạy cảm.
- **Giả danh chiếm đoạt phiên**: Kẻ tấn công có session ID bị đánh cắp có thể gọi trực tiếp đến máy chủ MCP, bỏ qua xác thực và được xử lý như người dùng hợp pháp.
- **Dòng dữ liệu có thể tiếp tục bị xâm phạm**: Khi máy chủ hỗ trợ tái gửi hoặc dòng dữ liệu có thể tiếp tục, kẻ tấn công có thể kết thúc yêu cầu sớm, dẫn đến việc client gốc tiếp tục yêu cầu với nội dung có thể độc hại.

### Các biện pháp giảm thiểu

- **Xác minh ủy quyền**: Máy chủ MCP triển khai ủy quyền **PHẢI** xác minh tất cả các yêu cầu đến và **KHÔNG ĐƯỢC** sử dụng phiên làm phương thức xác thực.
- **Session ID an toàn**: Máy chủ MCP **PHẢI** sử dụng session ID an toàn, không xác định trước, được tạo bằng bộ sinh số ngẫu nhiên bảo mật. Tránh các định danh có thể đoán trước hoặc theo thứ tự.
- **Ràng buộc phiên theo người dùng**: Máy chủ MCP **NÊN** ràng buộc session ID với thông tin người dùng cụ thể, kết hợp session ID với thông tin duy nhất của người dùng được ủy quyền (như user ID nội bộ) theo định dạng `
<user_id>:<session_id>`.
- **Hết hạn phiên**: Triển khai hết hạn và xoay vòng phiên hợp lý để giới hạn thời gian lộ diện nếu session ID bị xâm phạm.
- **Bảo mật truyền tải**: Luôn sử dụng HTTPS cho mọi giao tiếp để ngăn chặn việc chặn session ID.

# Bảo mật chuỗi cung ứng

Bảo mật chuỗi cung ứng vẫn là yếu tố nền tảng trong thời đại AI, nhưng phạm vi của chuỗi cung ứng đã được mở rộng. Ngoài các gói mã truyền thống, bạn cần kiểm tra và giám sát nghiêm ngặt tất cả các thành phần liên quan đến AI, bao gồm các mô hình nền tảng, dịch vụ embeddings, nhà cung cấp ngữ cảnh và API bên thứ ba. Mỗi thành phần này có thể mang lại lỗ hổng hoặc rủi ro nếu không được quản lý đúng cách.

**Các thực hành bảo mật chuỗi cung ứng quan trọng cho AI và MCP:**
- **Xác minh tất cả thành phần trước khi tích hợp:** Bao gồm không chỉ thư viện mã nguồn mở mà còn các mô hình AI, nguồn dữ liệu và API bên ngoài. Luôn kiểm tra nguồn gốc, giấy phép và các lỗ hổng đã biết.
- **Duy trì pipeline triển khai an toàn:** Sử dụng pipeline CI/CD tự động với tích hợp quét bảo mật để phát hiện sớm các vấn đề. Đảm bảo chỉ các artifact đáng tin cậy được triển khai vào môi trường sản xuất.
- **Giám sát và kiểm toán liên tục:** Triển khai giám sát liên tục cho tất cả các phụ thuộc, bao gồm mô hình và dịch vụ dữ liệu, để phát hiện các lỗ hổng mới hoặc các cuộc tấn công chuỗi cung ứng.
- **Áp dụng nguyên tắc ít đặc quyền và kiểm soát truy cập:** Hạn chế quyền truy cập vào mô hình, dữ liệu và dịch vụ chỉ trong phạm vi cần thiết cho máy chủ MCP hoạt động.
- **Phản ứng nhanh với các mối đe dọa:** Có quy trình vá lỗi hoặc thay thế các thành phần bị xâm phạm, và xoay vòng bí mật hoặc thông tin xác thực khi phát hiện vi phạm.

[GitHub Advanced Security](https://github.com/security/advanced-security) cung cấp các tính năng như quét bí mật, quét phụ thuộc và phân tích CodeQL. Các công cụ này tích hợp với [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) và [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) giúp các nhóm phát hiện và giảm thiểu lỗ hổng trên cả mã nguồn và các thành phần chuỗi cung ứng AI.

Microsoft cũng triển khai các thực hành bảo mật chuỗi cung ứng rộng rãi nội bộ cho tất cả sản phẩm. Tìm hiểu thêm tại [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Các thực hành bảo mật đã được thiết lập giúp nâng cao vị thế bảo mật của triển khai MCP

Bất kỳ triển khai MCP nào cũng kế thừa vị thế bảo mật hiện có của môi trường tổ chức mà nó được xây dựng trên đó, vì vậy khi xem xét bảo mật MCP như một thành phần trong hệ thống AI tổng thể, bạn nên nâng cao vị thế bảo mật hiện có của mình. Các kiểm soát bảo mật đã được thiết lập sau đây đặc biệt phù hợp:

- Thực hành mã hóa an toàn trong ứng dụng AI của bạn - bảo vệ chống lại [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 cho LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), sử dụng kho bí mật an toàn cho các bí mật và token, triển khai giao tiếp bảo mật đầu cuối giữa tất cả các thành phần ứng dụng, v.v.
- Tăng cường bảo mật máy chủ -- sử dụng MFA khi có thể, cập nhật bản vá thường xuyên, tích hợp máy chủ với nhà cung cấp danh tính bên thứ ba để kiểm soát truy cập, v.v.
- Giữ thiết bị, hạ tầng và ứng dụng luôn được cập nhật bản vá
- Giám sát bảo mật -- triển khai ghi nhật ký và giám sát ứng dụng AI (bao gồm client/server MCP) và gửi các nhật ký đó đến SIEM trung tâm để phát hiện các hoạt động bất thường
- Kiến trúc zero trust -- cô lập các thành phần qua kiểm soát mạng và danh tính một cách hợp lý để giảm thiểu di chuyển ngang nếu ứng dụng AI bị xâm phạm.

# Những điểm chính cần nhớ

- Các nguyên tắc bảo mật cơ bản vẫn rất quan trọng: Mã hóa an toàn, nguyên tắc ít đặc quyền, xác minh chuỗi cung ứng và giám sát liên tục là thiết yếu cho MCP và khối lượng công việc AI.
- MCP mang đến các rủi ro mới — như tiêm prompt, đầu độc công cụ, chiếm đoạt phiên, vấn đề confused deputy, lỗ hổng token passthrough và quyền hạn quá mức — đòi hỏi các kiểm soát truyền thống và đặc thù AI.
- Sử dụng các thực hành xác thực, ủy quyền và quản lý token mạnh mẽ, tận dụng nhà cung cấp danh tính bên ngoài như Microsoft Entra ID khi có thể.
- Bảo vệ chống lại tiêm prompt gián tiếp và đầu độc công cụ bằng cách xác thực metadata công cụ, giám sát các thay đổi động và sử dụng các giải pháp như Microsoft Prompt Shields.
- Triển khai quản lý phiên an toàn bằng cách sử dụng session ID không xác định trước, ràng buộc phiên với danh tính người dùng và không bao giờ dùng phiên để xác thực.
- Ngăn chặn các cuộc tấn công confused deputy bằng cách yêu cầu sự đồng ý rõ ràng của người dùng cho mỗi client đăng ký động và thực hiện các thực hành bảo mật OAuth đúng cách.
- Tránh lỗ hổng token passthrough bằng cách đảm bảo máy chủ MCP chỉ chấp nhận token được cấp rõ ràng cho chúng và xác thực các claims token phù hợp.
- Đối xử với tất cả các thành phần trong chuỗi cung ứng AI của bạn — bao gồm mô hình, embeddings và nhà cung cấp ngữ cảnh — với mức độ nghiêm ngặt tương tự như các phụ thuộc mã nguồn.
- Luôn cập nhật các đặc tả MCP đang phát triển và đóng góp cho cộng đồng để giúp hình thành các tiêu chuẩn bảo mật.

# Tài nguyên bổ sung

## Tài nguyên bên ngoài
- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Prompt Injection in MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Tool Poisoning Attacks (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls in MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Prompt Shields Documentation (Microsoft)](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Secure Token Storage and Encrypt Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

## Tài liệu bảo mật bổ sung

Để có hướng dẫn bảo mật chi tiết hơn, vui lòng tham khảo các tài liệu sau:

- [MCP Security Best Practices 2025](./mcp-security-best-practices-2025.md) - Danh sách toàn diện các thực hành bảo mật tốt nhất cho triển khai MCP
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md) - Ví dụ triển khai tích hợp Azure Content Safety với máy chủ MCP
- [MCP Security Controls 2025](./mcp-security-controls-2025.md) - Các kiểm soát và kỹ thuật bảo mật mới nhất cho triển khai MCP
- [MCP Best Practices](./mcp-best-practices.md) - Hướng dẫn tham khảo nhanh về bảo mật MCP

### Tiếp theo

Tiếp theo: [Chương 3: Bắt đầu](../03-GettingStarted/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc của nó nên được coi là nguồn chính xác và đáng tin cậy. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.