<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-06-13T17:16:29+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "th"
}
-->
# บทเรียนจากผู้ใช้งานรุ่นแรก

## ภาพรวม

บทเรียนนี้สำรวจวิธีที่ผู้ใช้งานรุ่นแรกได้นำ Model Context Protocol (MCP) มาใช้แก้ไขปัญหาในโลกจริงและขับเคลื่อนนวัตกรรมในหลากหลายอุตสาหกรรม ผ่านกรณีศึกษาละเอียดและโปรเจกต์ลงมือทำ คุณจะได้เห็นว่า MCP ช่วยให้การผสานรวม AI ที่เป็นมาตรฐาน ปลอดภัย และปรับขนาดได้อย่างไร — เชื่อมต่อโมเดลภาษาขนาดใหญ่ เครื่องมือ และข้อมูลองค์กรในกรอบงานเดียวกัน คุณจะได้รับประสบการณ์จริงในการออกแบบและสร้างโซลูชันที่ใช้ MCP เรียนรู้รูปแบบการใช้งานที่พิสูจน์แล้ว และค้นพบแนวทางปฏิบัติที่ดีที่สุดสำหรับการนำ MCP ไปใช้ในสภาพแวดล้อมการผลิต บทเรียนยังเน้นเทรนด์ที่เกิดขึ้น ทิศทางในอนาคต และแหล่งข้อมูลแบบโอเพนซอร์สเพื่อช่วยให้คุณก้าวนำเทคโนโลยี MCP และระบบนิเวศที่กำลังพัฒนา

## วัตถุประสงค์การเรียนรู้

- วิเคราะห์การใช้งาน MCP ในโลกจริงในอุตสาหกรรมต่างๆ  
- ออกแบบและสร้างแอปพลิเคชันครบวงจรที่ใช้ MCP  
- สำรวจเทรนด์ที่เกิดขึ้นและทิศทางในอนาคตของเทคโนโลยี MCP  
- นำแนวทางปฏิบัติที่ดีที่สุดไปใช้ในสถานการณ์พัฒนาจริง

## การใช้งาน MCP ในโลกจริง

### กรณีศึกษา 1: ระบบอัตโนมัติสนับสนุนลูกค้าองค์กร

บริษัทข้ามชาติได้ใช้โซลูชันที่ใช้ MCP เพื่อทำให้การโต้ตอบ AI ในระบบสนับสนุนลูกค้าของพวกเขามีมาตรฐานเดียวกัน ซึ่งช่วยให้พวกเขา:

- สร้างอินเทอร์เฟซเดียวสำหรับผู้ให้บริการ LLM หลายราย  
- รักษาการจัดการ prompt ที่สอดคล้องกันในทุกแผนก  
- นำมาตรการความปลอดภัยและการปฏิบัติตามข้อกำหนดที่เข้มงวดมาใช้  
- สลับใช้โมเดล AI ต่างๆ ได้อย่างง่ายดายตามความต้องการเฉพาะ

**การใช้งานทางเทคนิค:**  
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

**ผลลัพธ์:** ลดต้นทุนโมเดลลง 30% ปรับปรุงความสม่ำเสมอในการตอบกลับ 45% และเสริมความมั่นใจในการปฏิบัติตามข้อกำหนดทั่วโลก

### กรณีศึกษา 2: ผู้ช่วยวินิจฉัยทางการแพทย์

ผู้ให้บริการด้านสุขภาพพัฒนาโครงสร้างพื้นฐาน MCP เพื่อผสานรวมโมเดล AI ทางการแพทย์เฉพาะทางหลายตัว พร้อมทั้งรักษาความปลอดภัยข้อมูลผู้ป่วยอย่างเข้มงวด:

- สลับใช้งานโมเดลแพทย์ทั่วไปและเฉพาะทางได้อย่างราบรื่น  
- ควบคุมความเป็นส่วนตัวและบันทึกการตรวจสอบอย่างเข้มงวด  
- ผสานรวมกับระบบบันทึกสุขภาพอิเล็กทรอนิกส์ (EHR) ที่มีอยู่  
- จัดการ prompt สำหรับคำศัพท์ทางการแพทย์อย่างสม่ำเสมอ

**การใช้งานทางเทคนิค:**  
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

**ผลลัพธ์:** เสนอคำแนะนำวินิจฉัยที่ดีขึ้นแก่แพทย์ พร้อมทั้งรักษาความสอดคล้องกับ HIPAA เต็มรูปแบบและลดการสลับบริบทระหว่างระบบอย่างมีนัยสำคัญ

### กรณีศึกษา 3: การวิเคราะห์ความเสี่ยงทางการเงิน

สถาบันการเงินใช้ MCP เพื่อทำให้กระบวนการวิเคราะห์ความเสี่ยงในแผนกต่างๆ มีมาตรฐานเดียวกัน:

- สร้างอินเทอร์เฟซเดียวสำหรับโมเดลความเสี่ยงเครดิต ตรวจจับการฉ้อโกง และความเสี่ยงการลงทุน  
- นำมาตรการควบคุมการเข้าถึงและการจัดการเวอร์ชันโมเดลมาใช้  
- รับรองความสามารถในการตรวจสอบคำแนะนำ AI ทั้งหมด  
- รักษารูปแบบข้อมูลที่สอดคล้องกันในระบบที่หลากหลาย

**การใช้งานทางเทคนิค:**  
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

**ผลลัพธ์:** เพิ่มประสิทธิภาพการปฏิบัติตามกฎระเบียบ เร่งรอบการเปิดตัวโมเดลเร็วขึ้น 40% และปรับปรุงความสม่ำเสมอในการประเมินความเสี่ยงในทุกแผนก

### กรณีศึกษา 4: Microsoft Playwright MCP Server สำหรับการทำงานอัตโนมัติบนเบราว์เซอร์

Microsoft พัฒนา [Playwright MCP server](https://github.com/microsoft/playwright-mcp) เพื่อเปิดใช้งานการทำงานอัตโนมัติบนเว็บเบราว์เซอร์ที่ปลอดภัยและเป็นมาตรฐานผ่าน Model Context Protocol โซลูชันนี้ช่วยให้เอเจนต์ AI และ LLM สามารถโต้ตอบกับเว็บเบราว์เซอร์ได้อย่างควบคุม ตรวจสอบได้ และขยายผลได้—รองรับการใช้งานเช่น การทดสอบเว็บอัตโนมัติ การดึงข้อมูล และเวิร์กโฟลว์แบบครบวงจร

- เปิดเผยความสามารถการทำงานอัตโนมัติบนเบราว์เซอร์ (การนำทาง กรอกฟอร์ม ถ่ายภาพหน้าจอ ฯลฯ) เป็นเครื่องมือ MCP  
- นำมาตรการควบคุมการเข้าถึงและ sandboxing อย่างเข้มงวดเพื่อป้องกันการกระทำที่ไม่ได้รับอนุญาต  
- ให้บันทึกการตรวจสอบอย่างละเอียดสำหรับการโต้ตอบบนเบราว์เซอร์ทั้งหมด  
- รองรับการผสานรวมกับ Azure OpenAI และผู้ให้บริการ LLM อื่นๆ สำหรับการทำงานอัตโนมัติที่ขับเคลื่อนโดยเอเจนต์

**การใช้งานทางเทคนิค:**  
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

**ผลลัพธ์:**  
- เปิดใช้งานการทำงานอัตโนมัติบนเบราว์เซอร์อย่างปลอดภัยและเป็นโปรแกรมสำหรับเอเจนต์ AI และ LLM  
- ลดความพยายามในการทดสอบด้วยมือและเพิ่มความครอบคลุมของการทดสอบเว็บแอปพลิเคชัน  
- ให้กรอบงานที่นำกลับมาใช้ใหม่และขยายผลได้สำหรับการผสานรวมเครื่องมือบนเบราว์เซอร์ในสภาพแวดล้อมองค์กร

**แหล่งอ้างอิง:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### กรณีศึกษา 5: Azure MCP – Model Context Protocol ระดับองค์กรในรูปแบบบริการ

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) คือการใช้งาน MCP ระดับองค์กรที่ Microsoft จัดการให้ โดยออกแบบมาเพื่อให้บริการ MCP server ที่ปรับขนาดได้ ปลอดภัย และปฏิบัติตามข้อกำหนดในรูปแบบบริการคลาวด์ Azure MCP ช่วยให้องค์กรสามารถเปิดตัว จัดการ และผสานรวม MCP server กับ Azure AI, ข้อมูล และบริการความปลอดภัยได้อย่างรวดเร็ว ลดภาระการดำเนินงานและเร่งการนำ AI มาใช้

- โฮสต์ MCP server ที่จัดการเต็มรูปแบบ พร้อมการปรับขนาด การตรวจสอบ และความปลอดภัยในตัว  
- ผสานรวมอย่างเป็นธรรมชาติกับ Azure OpenAI, Azure AI Search และบริการ Azure อื่นๆ  
- การพิสูจน์ตัวตนและการอนุญาตระดับองค์กรผ่าน Microsoft Entra ID  
- รองรับเครื่องมือแบบกำหนดเอง, แม่แบบ prompt และตัวเชื่อมต่อทรัพยากร  
- ปฏิบัติตามข้อกำหนดด้านความปลอดภัยและกฎระเบียบขององค์กร

**การใช้งานทางเทคนิค:**  
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

**ผลลัพธ์:**  
- ลดเวลาสู่การสร้างคุณค่าให้กับโครงการ AI ระดับองค์กรด้วยแพลตฟอร์ม MCP server ที่พร้อมใช้งานและปฏิบัติตามข้อกำหนด  
- ทำให้ง่ายขึ้นในการผสานรวม LLMs, เครื่องมือ และแหล่งข้อมูลองค์กร  
- เพิ่มความปลอดภัย การตรวจสอบ และประสิทธิภาพในการดำเนินงานสำหรับงาน MCP

**แหล่งอ้างอิง:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## กรณีศึกษา 6: NLWeb  
MCP (Model Context Protocol) คือโพรโทคอลที่กำลังเกิดขึ้นสำหรับแชทบอทและผู้ช่วย AI ในการโต้ตอบกับเครื่องมือต่างๆ ทุกอินสแตนซ์ของ NLWeb เป็น MCP server ที่รองรับเมธอดหลักหนึ่งตัวคือ ask ซึ่งใช้ถามเว็บไซต์เป็นภาษาธรรมชาติ คำตอบที่ส่งกลับใช้ schema.org ซึ่งเป็นคำศัพท์ที่ใช้กันอย่างแพร่หลายสำหรับการอธิบายข้อมูลบนเว็บ กล่าวโดยง่าย MCP คือ NLWeb ในแบบเดียวกับ Http ที่เป็น HTML NLWeb ผสานโพรโทคอล รูปแบบ Schema.org และโค้ดตัวอย่างเพื่อช่วยให้เว็บไซต์สร้างจุดเชื่อมต่อเหล่านี้ได้อย่างรวดเร็ว เป็นประโยชน์ทั้งกับมนุษย์ผ่านอินเทอร์เฟซสนทนาและเครื่องจักรผ่านการโต้ตอบแบบ agent-to-agent

NLWeb มีสองส่วนประกอบที่แตกต่างกัน  
- โพรโทคอลที่เรียบง่ายสำหรับเริ่มต้น เพื่อเชื่อมต่อกับไซต์ด้วยภาษาธรรมชาติและรูปแบบที่ใช้ json กับ schema.org สำหรับคำตอบที่ส่งกลับ ดูเอกสารเกี่ยวกับ REST API สำหรับรายละเอียดเพิ่มเติม  
- การใช้งานที่ตรงไปตรงมาของ (1) ที่ใช้มาร์กอัปที่มีอยู่สำหรับไซต์ที่สามารถสรุปเป็นรายการของไอเท็ม (สินค้า สูตรอาหาร สถานที่ท่องเที่ยว รีวิว ฯลฯ) พร้อมด้วยชุดวิดเจ็ตอินเทอร์เฟซผู้ใช้ ทำให้ไซต์สามารถให้บริการอินเทอร์เฟซสนทนาแก่เนื้อหาของตนได้อย่างง่ายดาย ดูเอกสาร Life of a chat query สำหรับรายละเอียดวิธีการทำงานนี้

**แหล่งอ้างอิง:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### กรณีศึกษา 7: MCP สำหรับ Foundry – การผสานรวม Azure AI Agents

เซิร์ฟเวอร์ Azure AI Foundry MCP แสดงให้เห็นว่า MCP สามารถใช้จัดการและประสานงานเอเจนต์ AI และเวิร์กโฟลว์ในสภาพแวดล้อมองค์กรได้อย่างไร ด้วยการผสานรวม MCP กับ Azure AI Foundry องค์กรสามารถทำให้การโต้ตอบของเอเจนต์เป็นมาตรฐาน ใช้ประโยชน์จากการจัดการเวิร์กโฟลว์ของ Foundry และรับประกันการเปิดตัวที่ปลอดภัยและปรับขนาดได้ วิธีนี้ช่วยให้สร้างต้นแบบอย่างรวดเร็ว การตรวจสอบที่แข็งแกร่ง และการผสานรวมกับบริการ Azure AI ได้อย่างราบรื่น รองรับสถานการณ์ขั้นสูง เช่น การจัดการความรู้และการประเมินเอเจนต์ นักพัฒนาจะได้อินเทอร์เฟซเดียวสำหรับสร้าง เปิดตัว และตรวจสอบสายงานเอเจนต์ ขณะที่ทีมไอทีจะได้รับความปลอดภัย ปฏิบัติตามข้อกำหนด และประสิทธิภาพในการดำเนินงานที่ดีขึ้น โซลูชันนี้เหมาะสำหรับองค์กรที่ต้องการเร่งการนำ AI มาใช้และควบคุมกระบวนการที่ซับซ้อนซึ่งขับเคลื่อนโดยเอเจนต์

**แหล่งอ้างอิง:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### กรณีศึกษา 8: Foundry MCP Playground – การทดลองและสร้างต้นแบบ

Foundry MCP Playground คือสภาพแวดล้อมพร้อมใช้งานสำหรับทดลองกับ MCP server และการผสานรวม Azure AI Foundry นักพัฒนาสามารถสร้างต้นแบบ ทดสอบ และประเมินโมเดล AI กับเวิร์กโฟลว์เอเจนต์อย่างรวดเร็ว โดยใช้ทรัพยากรจาก Azure AI Foundry Catalog และ Labs สนามเด็กเล่นนี้ช่วยให้การตั้งค่าง่ายขึ้น มีโปรเจกต์ตัวอย่าง และสนับสนุนการพัฒนาร่วมกัน ทำให้ง่ายต่อการสำรวจแนวทางปฏิบัติที่ดีที่สุดและสถานการณ์ใหม่ๆ โดยมีภาระงานน้อย เหมาะอย่างยิ่งสำหรับทีมที่ต้องการตรวจสอบไอเดีย แบ่งปันการทดลอง และเร่งการเรียนรู้โดยไม่ต้องใช้โครงสร้างพื้นฐานที่ซับซ้อน ด้วยการลดอุปสรรคในการเข้าถึง สนามเด็กเล่นช่วยส่งเสริมนวัตกรรมและการมีส่วนร่วมของชุมชนในระบบนิเวศ MCP และ Azure AI Foundry

**แหล่งอ้างอิง:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### กรณีศึกษา 9: Microsoft Docs MCP Server - การเรียนรู้และพัฒนาทักษะ  
Microsoft Docs MCP Server คือการใช้งาน Model Context Protocol (MCP) server ที่ให้ผู้ช่วย AI เข้าถึงเอกสารทางการของ Microsoft แบบเรียลไทม์ ทำการค้นหาเชิงความหมายในเอกสารทางเทคนิคอย่างเป็นทางการของ Microsoft

**แหล่งอ้างอิง:**  
- [Microsoft Learn Docs MCP Server](https://github.com/MicrosoftDocs/mcp)

## โปรเจกต์ลงมือทำ

### โปรเจกต์ 1: สร้าง MCP Server หลายผู้ให้บริการ

**วัตถุประสงค์:** สร้าง MCP server ที่สามารถส่งคำขอไปยังผู้ให้บริการโมเดล AI หลายรายตามเกณฑ์ที่กำหนด

**ข้อกำหนด:**  
- รองรับผู้ให้บริการโมเดลอย่างน้อยสามราย (เช่น OpenAI, Anthropic, โมเดลในเครื่อง)  
- ใช้กลไกการกำหนดเส้นทางตามเมตาดาต้าของคำขอ  
- สร้างระบบกำหนดค่าจัดการข้อมูลรับรองของผู้ให้บริการ  
- เพิ่มระบบแคชเพื่อเพิ่มประสิทธิภาพและลดต้นทุน  
- สร้างแดชบอร์ดง่ายๆ สำหรับติดตามการใช้งาน

**ขั้นตอนการใช้งาน:**  
1. ตั้งค่าโครงสร้างพื้นฐาน MCP server เบื้องต้น  
2. สร้างตัวแปลงสำหรับผู้ให้บริการแต่ละราย  
3. สร้างตรรกะการกำหนดเส้นทางตามคุณสมบัติคำขอ  
4. เพิ่มกลไกแคชสำหรับคำขอบ่อย  
5. พัฒนาแดชบอร์ดติดตาม  
6. ทดสอบด้วยรูปแบบคำขอต่างๆ

**เทคโนโลยี:** เลือกใช้ Python (.NET/Java/Python ตามที่ถนัด), Redis สำหรับแคช และเว็บเฟรมเวิร์กง่ายๆ สำหรับแดชบอร์ด

### โปรเจกต์ 2: ระบบจัดการ Prompt ระดับองค์กร

**วัตถุประสงค์:** พัฒนาระบบที่ใช้ MCP สำหรับจัดการ เวอร์ชัน และเปิดใช้แม่แบบ prompt ในองค์กร

**ข้อกำหนด:**  
- สร้างคลังแม่แบบ prompt ศูนย์กลาง  
- ใช้งานระบบเวอร์ชันและเวิร์กโฟลว์อนุมัติ  
- สร้างความสามารถในการทดสอบแม่แบบด้วยข้อมูลตัวอย่าง  
- พัฒนาการควบคุมการเข้าถึงตามบทบาท  
- สร้าง API สำหรับเรียกดูและเปิดใช้แม่แบบ

**ขั้นตอนการใช้งาน:**  
1. ออกแบบโครงสร้างฐานข้อมูลสำหรับเก็บแม่แบบ  
2. สร้าง API หลักสำหรับ CRUD แม่แบบ  
3. ใช้งานระบบเวอร์ชัน  
4. สร้างเวิร์กโฟลว์อนุมัติ  
5. พัฒนากรอบการทดสอบ  
6. สร้างอินเทอร์เฟซเว็บง่ายๆ สำหรับการจัดการ  
7. ผสานรวมกับ MCP server

**เทคโนโลยี:** เลือกใช้เฟรมเวิร์กแบ็คเอนด์ ฐานข้อมูล SQL หรือ NoSQL และเฟรมเวิร์กฟรอนต์เอนด์สำหรับอินเทอร์เฟซจัดการ

### โปรเจกต์ 3: แพลตฟอร์มสร้างเนื้อหาที่ใช้ MCP

**วัตถุประสงค์:** สร้างแพลตฟอร์มสร้างเนื้อหาที่ใช้ MCP เพื่อให้ผลลัพธ์ที่สม่ำเสมอในเนื้อหาหลากหลายประเภท

**ข้อกำหนด:**  
- รองรับหลายรูปแบบเนื้อหา (บทความบล็อก โซเชียลมีเดีย คัดลอกการตลาด)  
- ใช้การสร้างแม่แบบพร้อมตัวเลือกปรับแต่ง  
- สร้างระบบตรวจทานและรับข้อเสนอแนะเนื้อหา  
- ติดตามเมตริกประสิทธิภาพเนื้อหา  
- รองรับการเวอร์ชันและปรับปรุงเนื้อหา

**ขั้นตอนการใช้งาน:**  
1. ตั้งค่าโครงสร้างพื้นฐาน MCP client  
2. สร้างแม่แบบสำหรับเน
- [MCP Community & Documentation](https://modelcontextprotocol.io/introduction)
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

## แบบฝึกหัด

1. วิเคราะห์กรณีศึกษาหนึ่งและเสนอแนวทางการดำเนินงานทางเลือก
2. เลือกไอเดียโปรเจกต์หนึ่งและสร้างข้อกำหนดทางเทคนิคอย่างละเอียด
3. ศึกษาอุตสาหกรรมที่ไม่ได้อยู่ในกรณีศึกษาและร่างแนวทางที่ MCP จะช่วยแก้ไขปัญหาเฉพาะได้อย่างไร
4. สำรวจทิศทางในอนาคตหนึ่งด้านและสร้างแนวคิดสำหรับส่วนขยาย MCP ใหม่เพื่อรองรับ

ถัดไป: [Best Practices](../08-BestPractices/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษา AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางควรถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ แนะนำให้ใช้การแปลโดยมนุษย์มืออาชีพ เราจะไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดที่เกิดจากการใช้การแปลนี้