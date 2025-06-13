<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-06-13T17:26:30+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "vi"
}
-->
# Bài học từ những người áp dụng sớm

## Tổng quan

Bài học này khám phá cách những người áp dụng sớm đã tận dụng Model Context Protocol (MCP) để giải quyết các thách thức thực tế và thúc đẩy đổi mới trong nhiều ngành công nghiệp. Qua các nghiên cứu điển hình chi tiết và dự án thực hành, bạn sẽ thấy MCP cho phép tích hợp AI theo chuẩn mực, an toàn và có khả năng mở rộng—kết nối các mô hình ngôn ngữ lớn, công cụ và dữ liệu doanh nghiệp trong một khuôn khổ thống nhất. Bạn sẽ có kinh nghiệm thực tế trong việc thiết kế và xây dựng các giải pháp dựa trên MCP, học hỏi từ các mẫu triển khai đã được chứng minh, và khám phá các phương pháp tốt nhất để triển khai MCP trong môi trường sản xuất. Bài học cũng làm nổi bật các xu hướng mới nổi, hướng đi tương lai, và tài nguyên mã nguồn mở giúp bạn luôn đi đầu trong công nghệ MCP và hệ sinh thái đang phát triển của nó.

## Mục tiêu học tập

- Phân tích các triển khai MCP thực tế trong các ngành khác nhau  
- Thiết kế và xây dựng các ứng dụng hoàn chỉnh dựa trên MCP  
- Khám phá các xu hướng mới và hướng phát triển tương lai trong công nghệ MCP  
- Áp dụng các phương pháp tốt nhất trong các kịch bản phát triển thực tế  

## Các triển khai MCP trong thực tế

### Nghiên cứu điển hình 1: Tự động hóa hỗ trợ khách hàng doanh nghiệp

Một tập đoàn đa quốc gia đã triển khai giải pháp dựa trên MCP để chuẩn hóa các tương tác AI trong hệ thống hỗ trợ khách hàng của họ. Điều này giúp họ:

- Tạo giao diện thống nhất cho nhiều nhà cung cấp LLM  
- Duy trì quản lý prompt nhất quán giữa các phòng ban  
- Triển khai các kiểm soát bảo mật và tuân thủ nghiêm ngặt  
- Dễ dàng chuyển đổi giữa các mô hình AI khác nhau dựa trên nhu cầu cụ thể  

**Triển khai kỹ thuật:**  
```python
# Python MCP server implementation for customer support
import logging
import asyncio
from modelcontextprotocol import create_server, ServerConfig
from modelcontextprotocol.server import MCPServer
from modelcontextprotocol.transports import create_http_transport
from modelcontextprotocol.resources import ResourceDefinition
from modelcontextprotocol.prompts import PromptDefinition
from modelcontextprotocol.tool import ToolDefinition

# Configure logging
logging.basicConfig(level=logging.INFO)

async def main():
    # Create server configuration
    config = ServerConfig(
        name="Enterprise Customer Support Server",
        version="1.0.0",
        description="MCP server for handling customer support inquiries"
    )
    
    # Initialize MCP server
    server = create_server(config)
    
    # Register knowledge base resources
    server.resources.register(
        ResourceDefinition(
            name="customer_kb",
            description="Customer knowledge base documentation"
        ),
        lambda params: get_customer_documentation(params)
    )
    
    # Register prompt templates
    server.prompts.register(
        PromptDefinition(
            name="support_template",
            description="Templates for customer support responses"
        ),
        lambda params: get_support_templates(params)
    )
    
    # Register support tools
    server.tools.register(
        ToolDefinition(
            name="ticketing",
            description="Create and update support tickets"
        ),
        handle_ticketing_operations
    )
    
    # Start server with HTTP transport
    transport = create_http_transport(port=8080)
    await server.run(transport)

if __name__ == "__main__":
    asyncio.run(main())
```

**Kết quả:** Giảm 30% chi phí mô hình, cải thiện 45% độ nhất quán phản hồi, và tăng cường tuân thủ trên quy mô toàn cầu.

### Nghiên cứu điển hình 2: Trợ lý chẩn đoán y tế

Một nhà cung cấp dịch vụ y tế đã phát triển hạ tầng MCP để tích hợp nhiều mô hình AI y tế chuyên biệt đồng thời đảm bảo dữ liệu bệnh nhân nhạy cảm được bảo vệ:

- Chuyển đổi mượt mà giữa mô hình y tế tổng quát và chuyên gia  
- Kiểm soát quyền riêng tư nghiêm ngặt và lưu vết kiểm toán  
- Tích hợp với hệ thống Hồ sơ Y tế Điện tử (EHR) hiện có  
- Quản lý prompt nhất quán cho thuật ngữ y tế  

**Triển khai kỹ thuật:**  
```csharp
// C# MCP host application implementation in healthcare application
using Microsoft.Extensions.DependencyInjection;
using ModelContextProtocol.SDK.Client;
using ModelContextProtocol.SDK.Security;
using ModelContextProtocol.SDK.Resources;

public class DiagnosticAssistant
{
    private readonly MCPHostClient _mcpClient;
    private readonly PatientContext _patientContext;
    
    public DiagnosticAssistant(PatientContext patientContext)
    {
        _patientContext = patientContext;
        
        // Configure MCP client with healthcare-specific settings
        var clientOptions = new ClientOptions
        {
            Name = "Healthcare Diagnostic Assistant",
            Version = "1.0.0",
            Security = new SecurityOptions
            {
                Encryption = EncryptionLevel.Medical,
                AuditEnabled = true
            }
        };
        
        _mcpClient = new MCPHostClientBuilder()
            .WithOptions(clientOptions)
            .WithTransport(new HttpTransport("https://healthcare-mcp.example.org"))
            .WithAuthentication(new HIPAACompliantAuthProvider())
            .Build();
    }
    
    public async Task<DiagnosticSuggestion> GetDiagnosticAssistance(
        string symptoms, string patientHistory)
    {
        // Create request with appropriate resources and tool access
        var resourceRequest = new ResourceRequest
        {
            Name = "patient_records",
            Parameters = new Dictionary<string, object>
            {
                ["patientId"] = _patientContext.PatientId,
                ["requestingProvider"] = _patientContext.ProviderId
            }
        };
        
        // Request diagnostic assistance using appropriate prompt
        var response = await _mcpClient.SendPromptRequestAsync(
            promptName: "diagnostic_assistance",
            parameters: new Dictionary<string, object>
            {
                ["symptoms"] = symptoms,
                patientHistory = patientHistory,
                relevantGuidelines = _patientContext.GetRelevantGuidelines()
            });
            
        return DiagnosticSuggestion.FromMCPResponse(response);
    }
}
```

**Kết quả:** Cải thiện đề xuất chẩn đoán cho bác sĩ trong khi duy trì tuân thủ đầy đủ HIPAA và giảm đáng kể việc chuyển đổi ngữ cảnh giữa các hệ thống.

### Nghiên cứu điển hình 3: Phân tích rủi ro dịch vụ tài chính

Một tổ chức tài chính đã triển khai MCP để chuẩn hóa quy trình phân tích rủi ro trong các phòng ban khác nhau:

- Tạo giao diện thống nhất cho các mô hình rủi ro tín dụng, phát hiện gian lận, và rủi ro đầu tư  
- Áp dụng kiểm soát truy cập nghiêm ngặt và quản lý phiên bản mô hình  
- Đảm bảo khả năng kiểm toán tất cả các khuyến nghị AI  
- Duy trì định dạng dữ liệu nhất quán trên các hệ thống đa dạng  

**Triển khai kỹ thuật:**  
```java
// Java MCP server for financial risk assessment
import org.mcp.server.*;
import org.mcp.security.*;

public class FinancialRiskMCPServer {
    public static void main(String[] args) {
        // Create MCP server with financial compliance features
        MCPServer server = new MCPServerBuilder()
            .withModelProviders(
                new ModelProvider("risk-assessment-primary", new AzureOpenAIProvider()),
                new ModelProvider("risk-assessment-audit", new LocalLlamaProvider())
            )
            .withPromptTemplateDirectory("./compliance/templates")
            .withAccessControls(new SOCCompliantAccessControl())
            .withDataEncryption(EncryptionStandard.FINANCIAL_GRADE)
            .withVersionControl(true)
            .withAuditLogging(new DatabaseAuditLogger())
            .build();
            
        server.addRequestValidator(new FinancialDataValidator());
        server.addResponseFilter(new PII_RedactionFilter());
        
        server.start(9000);
        
        System.out.println("Financial Risk MCP Server running on port 9000");
    }
}
```

**Kết quả:** Tăng cường tuân thủ quy định, rút ngắn chu kỳ triển khai mô hình 40%, và cải thiện độ nhất quán đánh giá rủi ro giữa các phòng ban.

### Nghiên cứu điển hình 4: Microsoft Playwright MCP Server cho tự động hóa trình duyệt

Microsoft phát triển [Playwright MCP server](https://github.com/microsoft/playwright-mcp) để cho phép tự động hóa trình duyệt an toàn, chuẩn hóa thông qua Model Context Protocol. Giải pháp này cho phép các agent AI và LLM tương tác với trình duyệt web theo cách kiểm soát, có thể kiểm toán và mở rộng—hỗ trợ các trường hợp sử dụng như kiểm thử web tự động, trích xuất dữ liệu, và quy trình làm việc đầu-cuối.

- Cung cấp khả năng tự động hóa trình duyệt (điều hướng, điền form, chụp ảnh màn hình, v.v.) dưới dạng công cụ MCP  
- Áp dụng kiểm soát truy cập nghiêm ngặt và sandbox để ngăn chặn hành động trái phép  
- Cung cấp nhật ký kiểm toán chi tiết cho mọi tương tác trình duyệt  
- Hỗ trợ tích hợp với Azure OpenAI và các nhà cung cấp LLM khác cho tự động hóa do agent điều khiển  

**Triển khai kỹ thuật:**  
```typescript
// TypeScript: Registering Playwright browser automation tools in an MCP server
import { createServer, ToolDefinition } from 'modelcontextprotocol';
import { launch } from 'playwright';

const server = createServer({
  name: 'Playwright MCP Server',
  version: '1.0.0',
  description: 'MCP server for browser automation using Playwright'
});

// Register a tool for navigating to a URL and capturing a screenshot
server.tools.register(
  new ToolDefinition({
    name: 'navigate_and_screenshot',
    description: 'Navigate to a URL and capture a screenshot',
    parameters: {
      url: { type: 'string', description: 'The URL to visit' }
    }
  }),
  async ({ url }) => {
    const browser = await launch();
    const page = await browser.newPage();
    await page.goto(url);
    const screenshot = await page.screenshot();
    await browser.close();
    return { screenshot };
  }
);

// Start the MCP server
server.listen(8080);
```

**Kết quả:**  
- Cho phép tự động hóa trình duyệt an toàn, có thể lập trình cho các agent AI và LLM  
- Giảm công sức kiểm thử thủ công và cải thiện độ bao phủ kiểm thử cho ứng dụng web  
- Cung cấp khung làm việc tái sử dụng, mở rộng cho tích hợp công cụ trình duyệt trong môi trường doanh nghiệp  

**Tham khảo:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)  

### Nghiên cứu điển hình 5: Azure MCP – Model Context Protocol cấp doanh nghiệp dưới dạng dịch vụ

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) là triển khai MCP cấp doanh nghiệp do Microsoft quản lý, được thiết kế để cung cấp khả năng máy chủ MCP có thể mở rộng, an toàn và tuân thủ dưới dạng dịch vụ đám mây. Azure MCP giúp các tổ chức triển khai nhanh, quản lý và tích hợp máy chủ MCP với Azure AI, dữ liệu và dịch vụ bảo mật, giảm tải vận hành và thúc đẩy việc áp dụng AI.

- Hosting máy chủ MCP được quản lý hoàn toàn với khả năng mở rộng, giám sát và bảo mật tích hợp sẵn  
- Tích hợp gốc với Azure OpenAI, Azure AI Search, và các dịch vụ Azure khác  
- Xác thực và phân quyền doanh nghiệp qua Microsoft Entra ID  
- Hỗ trợ công cụ tùy chỉnh, mẫu prompt, và kết nối tài nguyên  
- Tuân thủ các yêu cầu bảo mật và quy định doanh nghiệp  

**Triển khai kỹ thuật:**  
```yaml
# Example: Azure MCP server deployment configuration (YAML)
apiVersion: mcp.microsoft.com/v1
kind: McpServer
metadata:
  name: enterprise-mcp-server
spec:
  modelProviders:
    - name: azure-openai
      type: AzureOpenAI
      endpoint: https://<your-openai-resource>.openai.azure.com/
      apiKeySecret: <your-azure-keyvault-secret>
  tools:
    - name: document_search
      type: AzureAISearch
      endpoint: https://<your-search-resource>.search.windows.net/
      apiKeySecret: <your-azure-keyvault-secret>
  authentication:
    type: EntraID
    tenantId: <your-tenant-id>
  monitoring:
    enabled: true
    logAnalyticsWorkspace: <your-log-analytics-id>
```

**Kết quả:**  
- Rút ngắn thời gian đưa dự án AI doanh nghiệp vào vận hành bằng cách cung cấp nền tảng máy chủ MCP tuân thủ, sẵn sàng sử dụng  
- Đơn giản hóa tích hợp LLM, công cụ, và nguồn dữ liệu doanh nghiệp  
- Tăng cường bảo mật, khả năng quan sát và hiệu quả vận hành cho khối lượng công việc MCP  

**Tham khảo:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)  

## Nghiên cứu điển hình 6: NLWeb  
MCP (Model Context Protocol) là một giao thức mới nổi cho chatbot và trợ lý AI tương tác với công cụ. Mỗi phiên bản NLWeb cũng là một máy chủ MCP, hỗ trợ một phương thức chính là ask, dùng để hỏi một trang web bằng ngôn ngữ tự nhiên. Phản hồi trả về sử dụng schema.org, một bộ từ vựng phổ biến để mô tả dữ liệu web. Nói một cách đơn giản, MCP là NLWeb như Http là với HTML. NLWeb kết hợp các giao thức, định dạng Schema.org và mã mẫu giúp các trang web nhanh chóng tạo các điểm cuối này, hỗ trợ cả con người qua giao diện hội thoại và máy móc qua tương tác agent-to-agent tự nhiên.

NLWeb có hai thành phần riêng biệt.  
- Một giao thức, rất đơn giản để bắt đầu, để giao tiếp với trang web bằng ngôn ngữ tự nhiên và một định dạng, sử dụng json và schema.org cho câu trả lời trả về. Xem tài liệu REST API để biết chi tiết.  
- Một triển khai trực quan của (1) tận dụng markup hiện có, dành cho các trang có thể được trừu tượng hóa thành danh sách mục (sản phẩm, công thức, điểm tham quan, đánh giá, v.v.). Kết hợp với bộ widget giao diện người dùng, các trang có thể dễ dàng cung cấp giao diện hội thoại cho nội dung của họ. Xem tài liệu Life of a chat query để biết thêm cách hoạt động.  

**Tham khảo:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)  

### Nghiên cứu điển hình 7: MCP cho Foundry – Tích hợp Azure AI Agents

Máy chủ Azure AI Foundry MCP minh họa cách MCP có thể được sử dụng để điều phối và quản lý các agent AI và quy trình làm việc trong môi trường doanh nghiệp. Bằng cách tích hợp MCP với Azure AI Foundry, các tổ chức có thể chuẩn hóa tương tác agent, tận dụng quản lý quy trình của Foundry, và đảm bảo triển khai an toàn, có khả năng mở rộng. Cách tiếp cận này cho phép tạo mẫu nhanh, giám sát chặt chẽ và tích hợp liền mạch với dịch vụ Azure AI, hỗ trợ các kịch bản nâng cao như quản lý tri thức và đánh giá agent. Nhà phát triển được lợi từ giao diện thống nhất để xây dựng, triển khai và giám sát pipeline agent, trong khi đội IT cải thiện bảo mật, tuân thủ và hiệu quả vận hành. Giải pháp này lý tưởng cho các doanh nghiệp muốn thúc đẩy áp dụng AI và kiểm soát quy trình phức tạp do agent điều khiển.

**Tham khảo:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)  

### Nghiên cứu điển hình 8: Foundry MCP Playground – Thử nghiệm và tạo mẫu

Foundry MCP Playground cung cấp môi trường sẵn sàng sử dụng để thử nghiệm máy chủ MCP và tích hợp Azure AI Foundry. Nhà phát triển có thể nhanh chóng tạo mẫu, kiểm thử và đánh giá mô hình AI và quy trình agent sử dụng tài nguyên từ Azure AI Foundry Catalog và Labs. Playground đơn giản hóa việc thiết lập, cung cấp dự án mẫu và hỗ trợ phát triển cộng tác, giúp dễ dàng khám phá các phương pháp tốt nhất và kịch bản mới với chi phí thấp. Đặc biệt hữu ích cho các nhóm muốn xác thực ý tưởng, chia sẻ thử nghiệm và tăng tốc học tập mà không cần hạ tầng phức tạp. Bằng cách giảm rào cản tiếp cận, playground thúc đẩy đổi mới và đóng góp cộng đồng trong hệ sinh thái MCP và Azure AI Foundry.

**Tham khảo:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)  

### Nghiên cứu điển hình 9: Microsoft Docs MCP Server - Học tập và nâng cao kỹ năng  
Microsoft Docs MCP Server triển khai Model Context Protocol (MCP) server cung cấp trợ lý AI truy cập thời gian thực tới tài liệu chính thức của Microsoft. Thực hiện tìm kiếm ngữ nghĩa trên tài liệu kỹ thuật chính thức của Microsoft.

**Tham khảo:**  
- [Microsoft Learn Docs MCP Server](https://github.com/MicrosoftDocs/mcp)  

## Dự án thực hành

### Dự án 1: Xây dựng máy chủ MCP đa nhà cung cấp

**Mục tiêu:** Tạo máy chủ MCP có khả năng chuyển hướng yêu cầu đến nhiều nhà cung cấp mô hình AI dựa trên tiêu chí cụ thể.

**Yêu cầu:**  
- Hỗ trợ ít nhất ba nhà cung cấp mô hình khác nhau (ví dụ: OpenAI, Anthropic, mô hình cục bộ)  
- Triển khai cơ chế định tuyến dựa trên metadata yêu cầu  
- Tạo hệ thống cấu hình để quản lý thông tin xác thực nhà cung cấp  
- Thêm bộ nhớ đệm để tối ưu hiệu năng và chi phí  
- Xây dựng dashboard đơn giản để giám sát sử dụng  

**Các bước triển khai:**  
1. Thiết lập hạ tầng máy chủ MCP cơ bản  
2. Triển khai adapter cho từng dịch vụ mô hình AI  
3. Tạo logic định tuyến dựa trên thuộc tính yêu cầu  
4. Thêm cơ chế bộ nhớ đệm cho các yêu cầu thường xuyên  
5. Phát triển dashboard giám sát  
6. Kiểm thử với các mẫu yêu cầu đa dạng  

**Công nghệ:** Lựa chọn từ Python (.NET/Java/Python tùy sở thích), Redis cho bộ nhớ đệm, và framework web đơn giản cho dashboard.

### Dự án 2: Hệ thống quản lý prompt doanh nghiệp

**Mục tiêu:** Phát triển hệ thống dựa trên MCP để quản lý, phiên bản hóa và triển khai mẫu prompt trong toàn tổ chức.

**Yêu cầu:**  
- Tạo kho lưu trữ tập trung cho mẫu prompt  
- Triển khai quản lý phiên bản và quy trình phê duyệt  
- Xây dựng khả năng kiểm thử mẫu với đầu vào mẫu  
- Phát triển kiểm soát truy cập theo vai trò  
- Tạo API để truy xuất và triển khai mẫu  

**Các bước triển khai:**  
1. Thiết kế schema cơ sở dữ liệu cho lưu trữ mẫu  
2. Tạo API cốt lõi cho CRUD mẫu  
3. Triển khai hệ thống quản lý phiên bản  
4. Xây dựng quy trình phê duyệt  
5. Phát triển khung kiểm thử  
6. Tạo giao diện web đơn giản cho quản lý  
7. Tích hợp với máy chủ MCP  

**Công nghệ:** Lựa chọn framework backend, cơ sở dữ liệu SQL hoặc NoSQL, và framework frontend cho giao diện quản lý.

### Dự án 3: Nền tảng tạo nội dung dựa trên MCP

**Mục tiêu:** Xây dựng nền tảng tạo nội dung sử dụng MCP để cung cấp kết quả nhất quán trên nhiều loại nội dung khác nhau.

**Yêu cầu:**  
- Hỗ trợ nhiều định dạng nội dung (bài blog, mạng xã hội, nội dung marketing)  
- Triển khai tạo nội dung dựa trên mẫu với các tùy chọn tùy chỉnh  
- Tạo hệ thống đánh giá và phản hồi nội dung  
- Theo dõi chỉ số hiệu suất nội dung  
- Hỗ trợ phiên bản hóa và lặp lại nội dung  

**Các bước triển khai:**  
1. Thiết lập hạ tầng client MCP  
2. Tạo mẫu cho các loại nội dung khác nhau  
3. Xây dựng pipeline tạo nội dung  
4. Triển khai hệ thống đánh giá  
5. Phát triển hệ thống theo dõi chỉ số  
6. Tạo giao diện người dùng quản lý mẫu và tạo nội dung  

**Công nghệ:** Ngôn ngữ lập trình, framework web, và hệ quản trị cơ sở dữ liệu theo sở thích.

## Hướng phát triển tương lai của công nghệ MCP

### Xu hướng mới nổi

1. **MCP đa phương thức**  
   - Mở rộng MCP để chuẩn hóa tương tác với mô hình hình ảnh, âm thanh và video  
   - Phát triển khả năng suy luận đa phương thức  
   - Chuẩn hóa định dạng prompt cho các phương thức khác nhau  

2. **Hạ tầng MCP phân tán**  
   - Mạng MCP phân tán có thể chia sẻ tài nguyên giữa các tổ chức  
   - Giao thức chuẩn hóa cho chia sẻ mô hình an toàn  
   - Kỹ thuật tính toán bảo vệ quyền riêng tư  

3. **Chợ MCP**  
   - Hệ sinh thái chia sẻ và kiếm tiền từ mẫu và plugin MCP  
   - Quy trình đảm bảo chất lượng và chứng nhận  
   - Tích hợp với chợ mô hình  

4. **MCP cho điện toán biên**  
   - Điều chỉnh tiêu chuẩn MCP cho thiết bị biên có hạn chế tài nguyên  
   - Giao thức tối ưu cho môi trường băng thông thấp  
   - Triển khai MCP chuyên biệt cho hệ sinh thái IoT  

5. **Khung pháp lý**  
   - Phát triển mở rộng MCP cho tuân thủ quy định  
   - Lưu vết kiểm toán và giao diện giải thích chuẩn hóa  
   - Tích hợp với các khung quản trị AI mới nổi  

### Giải pháp MCP từ Microsoft

Microsoft và Azure đã phát triển nhiều kho mã nguồn mở hỗ trợ nhà phát triển triển khai MCP trong các kịch bản khác nhau:

#### Tổ chức Microsoft  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - Máy chủ Playwright MCP cho tự động hóa và kiểm thử trình duyệt  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - Triển khai máy chủ OneDrive MCP cho kiểm thử cục bộ và đóng góp cộng đồng  
3. [NLWeb](https://github.com/microsoft/NlWeb) - Bộ giao thức mở và công cụ mã nguồn mở liên quan, tập trung xây dựng nền tảng AI Web  

#### Tổ chức Azure-Samples  
1. [mcp](https://github.com/Azure-Samples/mcp) - Liên kết đến mẫu, công cụ và tài nguyên xây dựng, tích hợp máy chủ MCP trên Azure bằng nhiều ngôn ngữ  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - Máy chủ MCP tham khảo minh họa xác thực theo đặc tả Model Context Protocol hiện hành  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Trang giới thiệu triển khai Remote MCP Server trên Azure Functions với liên kết repo ngôn ngữ cụ thể  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Mẫu khởi động nhanh xây dựng và triển khai máy chủ Remote MCP tùy chỉnh bằng Python trên Azure Functions  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Mẫu khởi động nhanh xây dựng và triển khai
- [Cộng đồng & Tài liệu MCP](https://modelcontextprotocol.io/introduction)
- [Tài liệu Azure MCP](https://aka.ms/azmcp)
- [Kho GitHub Máy chủ Playwright MCP](https://github.com/microsoft/playwright-mcp)
- [Máy chủ Files MCP (OneDrive)](https://github.com/microsoft/files-mcp-server)
- [Azure-Samples MCP](https://github.com/Azure-Samples/mcp)
- [Máy chủ xác thực MCP (Azure-Samples)](https://github.com/Azure-Samples/mcp-auth-servers)
- [Chức năng MCP từ xa (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions)
- [Chức năng MCP từ xa Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Chức năng MCP từ xa .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Chức năng MCP từ xa TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Chức năng MCP APIM từ xa Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Giải pháp AI và Tự động hóa Microsoft](https://azure.microsoft.com/en-us/products/ai-services/)

## Bài tập

1. Phân tích một trong các nghiên cứu tình huống và đề xuất một cách triển khai thay thế.
2. Chọn một trong các ý tưởng dự án và tạo một bản đặc tả kỹ thuật chi tiết.
3. Tìm hiểu một ngành công nghiệp chưa được đề cập trong các nghiên cứu tình huống và phác thảo cách MCP có thể giải quyết các thách thức đặc thù của ngành đó.
4. Khám phá một trong các hướng phát triển tương lai và tạo một khái niệm cho một phần mở rộng MCP mới để hỗ trợ nó.

Tiếp theo: [Best Practices](../08-BestPractices/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ nguyên bản nên được coi là nguồn thông tin chính thức. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.