<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "296d5c8913271ef3bd696fd46d998711",
  "translation_date": "2025-05-20T22:01:43+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "vi"
}
-->
# Bài học từ những người áp dụng sớm

## Tổng quan

Bài học này khám phá cách các người áp dụng sớm đã tận dụng Model Context Protocol (MCP) để giải quyết các thách thức thực tế và thúc đẩy đổi mới trong nhiều ngành công nghiệp. Qua các nghiên cứu điển hình chi tiết và dự án thực hành, bạn sẽ thấy MCP giúp chuẩn hóa, bảo mật và mở rộng tích hợp AI như thế nào — kết nối các mô hình ngôn ngữ lớn, công cụ và dữ liệu doanh nghiệp trong một khuôn khổ thống nhất. Bạn sẽ có kinh nghiệm thực tiễn trong việc thiết kế và xây dựng các giải pháp dựa trên MCP, học hỏi từ các mẫu triển khai đã được chứng minh, và khám phá các phương pháp tốt nhất để triển khai MCP trong môi trường sản xuất. Bài học cũng nhấn mạnh các xu hướng mới nổi, hướng phát triển tương lai, và các nguồn tài nguyên mã nguồn mở giúp bạn luôn dẫn đầu công nghệ MCP và hệ sinh thái đang phát triển của nó.

## Mục tiêu học tập

- Phân tích các triển khai MCP thực tế trong các ngành khác nhau  
- Thiết kế và xây dựng các ứng dụng hoàn chỉnh dựa trên MCP  
- Khám phá các xu hướng mới nổi và hướng đi tương lai trong công nghệ MCP  
- Áp dụng các phương pháp tốt nhất trong các tình huống phát triển thực tế  

## Các triển khai MCP trong thực tế

### Nghiên cứu trường hợp 1: Tự động hóa hỗ trợ khách hàng doanh nghiệp

Một tập đoàn đa quốc gia đã triển khai giải pháp dựa trên MCP để chuẩn hóa tương tác AI trên hệ thống hỗ trợ khách hàng của họ. Điều này cho phép họ:

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

**Kết quả:** Giảm 30% chi phí mô hình, cải thiện 45% độ nhất quán phản hồi, và nâng cao tuân thủ trên toàn cầu.

### Nghiên cứu trường hợp 2: Trợ lý chẩn đoán y tế

Một nhà cung cấp dịch vụ y tế đã phát triển hạ tầng MCP để tích hợp nhiều mô hình AI y tế chuyên biệt đồng thời đảm bảo dữ liệu bệnh nhân nhạy cảm được bảo vệ:

- Chuyển đổi liền mạch giữa mô hình y tế đa năng và chuyên gia  
- Kiểm soát quyền riêng tư nghiêm ngặt và lưu vết kiểm toán  
- Tích hợp với hệ thống Hồ sơ Y tế Điện tử (EHR) hiện có  
- Quản lý prompt nhất quán cho thuật ngữ y khoa  

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

**Kết quả:** Cải thiện đề xuất chẩn đoán cho bác sĩ đồng thời duy trì tuân thủ HIPAA đầy đủ và giảm đáng kể việc chuyển đổi ngữ cảnh giữa các hệ thống.

### Nghiên cứu trường hợp 3: Phân tích rủi ro dịch vụ tài chính

Một tổ chức tài chính đã áp dụng MCP để chuẩn hóa quy trình phân tích rủi ro ở các phòng ban khác nhau:

- Tạo giao diện thống nhất cho các mô hình rủi ro tín dụng, phát hiện gian lận và rủi ro đầu tư  
- Triển khai kiểm soát truy cập nghiêm ngặt và quản lý phiên bản mô hình  
- Đảm bảo tính khả kiểm toán của tất cả khuyến nghị AI  
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

**Kết quả:** Nâng cao tuân thủ quy định, rút ngắn 40% chu kỳ triển khai mô hình, và cải thiện độ nhất quán đánh giá rủi ro.

### Nghiên cứu trường hợp 4: Microsoft Playwright MCP Server cho tự động hóa trình duyệt

Microsoft phát triển [Playwright MCP server](https://github.com/microsoft/playwright-mcp) để cho phép tự động hóa trình duyệt an toàn, chuẩn hóa thông qua Model Context Protocol. Giải pháp này cho phép các tác nhân AI và LLM tương tác với trình duyệt web theo cách kiểm soát, có thể kiểm toán và mở rộng — hỗ trợ các trường hợp sử dụng như kiểm thử web tự động, trích xuất dữ liệu và quy trình làm việc đầu-cuối.

- Cung cấp khả năng tự động hóa trình duyệt (điều hướng, điền form, chụp ảnh màn hình, v.v.) dưới dạng công cụ MCP  
- Triển khai kiểm soát truy cập nghiêm ngặt và sandbox để ngăn chặn hành động trái phép  
- Cung cấp nhật ký kiểm toán chi tiết cho tất cả tương tác trình duyệt  
- Hỗ trợ tích hợp với Azure OpenAI và các nhà cung cấp LLM khác cho tự động hóa do tác nhân điều khiển  

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
- Cho phép tự động hóa trình duyệt an toàn, có thể lập trình cho tác nhân AI và LLM  
- Giảm công sức kiểm thử thủ công và cải thiện phạm vi kiểm thử ứng dụng web  
- Cung cấp khung làm việc tái sử dụng, mở rộng cho tích hợp công cụ dựa trên trình duyệt trong môi trường doanh nghiệp  

**Tham khảo:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)  

### Nghiên cứu trường hợp 5: Azure MCP – Model Context Protocol cấp doanh nghiệp dưới dạng dịch vụ

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) là triển khai MCP cấp doanh nghiệp được Microsoft quản lý, được thiết kế để cung cấp khả năng mở rộng, bảo mật và tuân thủ cho server MCP dưới dạng dịch vụ đám mây. Azure MCP cho phép các tổ chức nhanh chóng triển khai, quản lý và tích hợp server MCP với các dịch vụ AI, dữ liệu và bảo mật của Azure, giảm tải vận hành và tăng tốc áp dụng AI.

- Hosting server MCP được quản lý hoàn toàn với khả năng tự động mở rộng, giám sát và bảo mật tích hợp  
- Tích hợp gốc với Azure OpenAI, Azure AI Search và các dịch vụ Azure khác  
- Xác thực và phân quyền doanh nghiệp qua Microsoft Entra ID  
- Hỗ trợ công cụ tùy chỉnh, mẫu prompt và kết nối tài nguyên  
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
- Rút ngắn thời gian đưa dự án AI doanh nghiệp vào hoạt động bằng nền tảng server MCP sẵn sàng, tuân thủ  
- Đơn giản hóa tích hợp LLM, công cụ và nguồn dữ liệu doanh nghiệp  
- Nâng cao bảo mật, khả năng quan sát và hiệu quả vận hành cho các workload MCP  

**Tham khảo:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)  

## Nghiên cứu trường hợp 6: NLWeb  
MCP (Model Context Protocol) là một giao thức mới cho chatbot và trợ lý AI tương tác với công cụ. Mỗi phiên bản NLWeb cũng là một server MCP, hỗ trợ một phương thức chính, ask, dùng để hỏi trang web bằng ngôn ngữ tự nhiên. Phản hồi trả về sử dụng schema.org, một từ vựng phổ biến để mô tả dữ liệu web. Nói một cách đơn giản, MCP là NLWeb như Http là với HTML. NLWeb kết hợp giao thức, định dạng Schema.org và mã mẫu để giúp các trang web nhanh chóng tạo các điểm cuối này, hỗ trợ cả con người qua giao diện hội thoại và máy móc qua tương tác tác nhân-tác nhân tự nhiên.

NLWeb có hai thành phần riêng biệt:  
- Một giao thức, rất đơn giản để bắt đầu, để giao tiếp với trang web bằng ngôn ngữ tự nhiên và một định dạng, sử dụng json và schema.org cho câu trả lời. Xem tài liệu REST API để biết thêm chi tiết.  
- Một triển khai đơn giản của (1) tận dụng markup hiện có, cho các trang có thể được trừu tượng thành danh sách mục (sản phẩm, công thức, điểm tham quan, đánh giá, v.v.). Cùng với bộ widget giao diện người dùng, các trang dễ dàng cung cấp giao diện hội thoại cho nội dung của họ. Xem tài liệu Life of a chat query để biết cách hoạt động.  

**Tham khảo:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)  

### Nghiên cứu trường hợp 7: MCP cho Foundry – Tích hợp Azure AI Agents

Server MCP Azure AI Foundry thể hiện cách MCP được sử dụng để điều phối và quản lý các tác nhân AI và quy trình làm việc trong môi trường doanh nghiệp. Bằng cách tích hợp MCP với Azure AI Foundry, các tổ chức có thể chuẩn hóa tương tác tác nhân, tận dụng quản lý quy trình làm việc của Foundry, và đảm bảo triển khai an toàn, mở rộng. Phương pháp này cho phép thử nghiệm nhanh, giám sát mạnh mẽ, và tích hợp liền mạch với các dịch vụ Azure AI, hỗ trợ các kịch bản nâng cao như quản lý tri thức và đánh giá tác nhân. Nhà phát triển được hưởng lợi từ giao diện thống nhất để xây dựng, triển khai và giám sát pipeline tác nhân, trong khi đội IT cải thiện bảo mật, tuân thủ và hiệu quả vận hành. Giải pháp phù hợp với doanh nghiệp muốn tăng tốc áp dụng AI và kiểm soát các quy trình phức tạp do tác nhân điều khiển.

**Tham khảo:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)  

### Nghiên cứu trường hợp 8: Foundry MCP Playground – Thử nghiệm và nguyên mẫu

Foundry MCP Playground cung cấp môi trường sẵn sàng sử dụng để thử nghiệm các server MCP và tích hợp Azure AI Foundry. Nhà phát triển có thể nhanh chóng tạo nguyên mẫu, kiểm thử và đánh giá mô hình AI cùng quy trình tác nhân sử dụng tài nguyên từ Azure AI Foundry Catalog và Labs. Playground đơn giản hóa việc thiết lập, cung cấp dự án mẫu, và hỗ trợ phát triển cộng tác, giúp dễ dàng khám phá các phương pháp tốt nhất và kịch bản mới với chi phí thấp. Đặc biệt hữu ích cho các nhóm muốn xác thực ý tưởng, chia sẻ thử nghiệm và tăng tốc học hỏi mà không cần hạ tầng phức tạp. Bằng cách hạ thấp rào cản, playground thúc đẩy đổi mới và đóng góp cộng đồng trong hệ sinh thái MCP và Azure AI Foundry.

**Tham khảo:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)  

## Dự án thực hành

### Dự án 1: Xây dựng server MCP đa nhà cung cấp

**Mục tiêu:** Tạo server MCP có khả năng định tuyến yêu cầu đến nhiều nhà cung cấp mô hình AI dựa trên tiêu chí cụ thể.

**Yêu cầu:**  
- Hỗ trợ ít nhất ba nhà cung cấp mô hình khác nhau (ví dụ: OpenAI, Anthropic, mô hình nội bộ)  
- Triển khai cơ chế định tuyến dựa trên metadata yêu cầu  
- Tạo hệ thống cấu hình quản lý thông tin xác thực nhà cung cấp  
- Thêm bộ nhớ đệm để tối ưu hiệu suất và chi phí  
- Xây dựng bảng điều khiển đơn giản để giám sát sử dụng  

**Các bước triển khai:**  
1. Thiết lập hạ tầng server MCP cơ bản  
2. Triển khai adapter nhà cung cấp cho từng dịch vụ mô hình AI  
3. Tạo logic định tuyến dựa trên thuộc tính yêu cầu  
4. Thêm cơ chế bộ nhớ đệm cho các yêu cầu thường xuyên  
5. Phát triển bảng điều khiển giám sát  
6. Kiểm thử với các mẫu yêu cầu khác nhau  

**Công nghệ:** Lựa chọn Python (.NET/Java/Python tùy sở thích), Redis cho bộ nhớ đệm, và framework web đơn giản cho bảng điều khiển.

### Dự án 2: Hệ thống quản lý prompt doanh nghiệp

**Mục tiêu:** Phát triển hệ thống dựa trên MCP để quản lý, phiên bản hóa và triển khai mẫu prompt trong tổ chức.

**Yêu cầu:**  
- Tạo kho lưu trữ tập trung cho mẫu prompt  
- Triển khai quy trình phiên bản và phê duyệt  
- Xây dựng khả năng kiểm thử mẫu với dữ liệu đầu vào mẫu  
- Phát triển kiểm soát truy cập theo vai trò  
- Tạo API để truy xuất và triển khai mẫu  

**Các bước triển khai:**  
1. Thiết kế schema cơ sở dữ liệu cho lưu trữ mẫu  
2. Tạo API cốt lõi cho các thao tác CRUD mẫu  
3. Triển khai hệ thống phiên bản  
4. Xây dựng quy trình phê duyệt  
5. Phát triển khung kiểm thử  
6. Tạo giao diện web đơn giản để quản lý  
7. Tích hợp với server MCP  

**Công nghệ:** Lựa chọn framework backend, cơ sở dữ liệu SQL hoặc NoSQL, và framework frontend cho giao diện quản lý.

### Dự án 3: Nền tảng tạo nội dung dựa trên MCP

**Mục tiêu:** Xây dựng nền tảng tạo nội dung sử dụng MCP để cung cấp kết quả nhất quán trên nhiều loại nội dung khác nhau.

**Yêu cầu:**  
- Hỗ trợ nhiều định dạng nội dung (bài blog, mạng xã hội, nội dung marketing)  
- Triển khai tạo nội dung dựa trên mẫu với tùy chỉnh  
- Tạo hệ thống đánh giá và phản hồi nội dung  
- Theo dõi các chỉ số hiệu suất nội dung  
- Hỗ trợ phiên bản hóa và lặp lại nội dung  

**Các bước triển khai:**  
1. Thiết lập hạ tầng client MCP  
2. Tạo mẫu cho các loại nội dung khác nhau  
3. Xây dựng pipeline tạo nội dung  
4. Triển khai hệ thống đánh giá  
5. Phát triển hệ thống theo dõi chỉ số  
6. Tạo giao diện người dùng cho quản lý mẫu và tạo nội dung  

**Công nghệ:** Ngôn ngữ lập trình, framework web và hệ quản trị cơ sở dữ liệu bạn ưa thích.

## Hướng phát triển tương lai của công nghệ MCP

### Các xu hướng mới nổi

1. **MCP đa phương thức**  
   - Mở rộng MCP để chuẩn hóa tương tác với mô hình hình ảnh, âm thanh và video  
   - Phát triển khả năng suy luận đa phương thức  
   - Chuẩn hóa định dạng prompt cho các phương thức khác nhau  

2. **Hạ tầng MCP liên kết**  
   - Mạng MCP phân tán có thể chia sẻ tài nguyên giữa các tổ chức  
   - Giao thức chuẩn cho chia sẻ mô hình an toàn  
   - Kỹ thuật tính toán bảo vệ quyền riêng tư  

3. **Thị trường MCP**  
   - Hệ sinh thái chia sẻ và kiếm tiền từ mẫu và plugin MCP  
   - Quy trình đảm bảo chất lượng và chứng nhận  
   - Tích hợp với thị trường mô hình  

4. **MCP cho điện toán biên**  
   - Điều chỉnh chuẩn MCP cho thiết bị biên hạn chế tài nguyên  
   - Giao thức tối ưu cho môi trường băng thông thấp  
   - Triển khai MCP chuyên biệt cho hệ sinh thái IoT  

5. **Khung pháp lý**  
   - Phát triển mở rộng MCP cho tuân thủ quy định  
   - Chuẩn hóa lưu vết kiểm toán và giao diện giải thích  
   - Tích hợp với các khung quản trị AI mới nổi  

### Giải pháp MCP từ Microsoft

Microsoft và Azure đã phát triển nhiều kho mã nguồn mở hỗ trợ nhà phát triển triển khai MCP trong nhiều kịch bản:

#### Tổ chức Microsoft  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - Server MCP Playwright cho tự động hóa và kiểm thử trình duyệt  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - Triển khai server MCP OneDrive cho kiểm thử nội bộ và đóng góp cộng đồng  
3. [NLWeb](https://github.com/microsoft/NlWeb) - Tập hợp giao thức mở và công cụ mã nguồn mở liên quan, tập trung xây dựng lớp nền cho AI Web  

#### Tổ chức Azure-Samples  
1. [mcp](https://github.com/Azure-Samples/mcp) - Liên kết đến mẫu, công cụ và tài nguyên xây dựng, tích hợp server MCP trên Azure với nhiều ngôn ngữ  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - Server MCP tham khảo minh họa xác thực theo chuẩn Model Context Protocol hiện hành  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Trang chủ các triển khai Remote MCP Server trên Azure Functions với liên kết repo theo ngôn ngữ  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Mẫu khởi động nhanh xây dựng, triển khai server MCP tùy chỉnh trên Azure Functions với Python  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Mẫu khởi động nhanh xây dựng, triển khai server MCP tùy chỉnh trên Azure Functions với .NET/C#  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Mẫu khởi động nhanh xây dựng, triển khai server MCP tùy chỉnh trên Azure Functions với TypeScript  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Azure API Management làm AI Gateway tới Remote MCP server dùng Python  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - Thí nghiệm APIM ❤️ AI tích hợp MCP, Azure OpenAI và AI Foundry  

Các kho này
- [Azure MCP Documentation](https://aka.ms/azmcp)
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)
- [Files MCP Server (OneDrive)](https://github.com/microsoft/files-mcp-server)
- [Azure-Samples MCP](https://github.com/Azure-Samples/mcp)
- [MCP Auth Servers (Azure-Samples)](https://github.com/Azure-Samples/mcp-auth-servers)
- [Remote MCP Functions (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions)
- [Remote MCP Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Remote MCP Functions .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Remote MCP Functions TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

## Bài tập

1. Phân tích một trong các nghiên cứu tình huống và đề xuất một cách triển khai thay thế.
2. Chọn một trong các ý tưởng dự án và tạo một bản đặc tả kỹ thuật chi tiết.
3. Tìm hiểu một ngành công nghiệp chưa được đề cập trong các nghiên cứu tình huống và phác thảo cách MCP có thể giải quyết các thách thức đặc thù của ngành đó.
4. Khám phá một trong các hướng phát triển tương lai và tạo một ý tưởng cho một phần mở rộng MCP mới để hỗ trợ nó.

Tiếp theo: [Best Practices](../08-BestPractices/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc sự không chính xác. Tài liệu gốc bằng ngôn ngữ gốc nên được coi là nguồn tham khảo chính xác và đáng tin cậy. Đối với thông tin quan trọng, khuyến nghị sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu nhầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.