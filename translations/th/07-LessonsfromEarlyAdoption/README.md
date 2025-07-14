<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-07-14T04:28:18+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "th"
}
-->
# บทเรียนจากผู้ใช้งานกลุ่มแรก

## ภาพรวม

บทเรียนนี้จะสำรวจว่าผู้ใช้งานกลุ่มแรกได้นำ Model Context Protocol (MCP) มาใช้แก้ไขปัญหาในโลกจริงและขับเคลื่อนนวัตกรรมในหลากหลายอุตสาหกรรมอย่างไร ผ่านกรณีศึกษาละเอียดและโครงการลงมือปฏิบัติ คุณจะได้เห็นว่า MCP ช่วยให้การผสานรวม AI เป็นมาตรฐาน มีความปลอดภัย และขยายตัวได้อย่างไร—เชื่อมต่อโมเดลภาษาใหญ่ เครื่องมือ และข้อมูลองค์กรในกรอบงานเดียวกัน คุณจะได้รับประสบการณ์จริงในการออกแบบและสร้างโซลูชันที่ใช้ MCP เรียนรู้จากรูปแบบการใช้งานที่พิสูจน์แล้ว และค้นพบแนวทางปฏิบัติที่ดีที่สุดสำหรับการนำ MCP ไปใช้ในสภาพแวดล้อมการผลิต บทเรียนยังเน้นเทรนด์ที่กำลังเกิดขึ้น ทิศทางในอนาคต และแหล่งข้อมูลโอเพนซอร์สเพื่อช่วยให้คุณก้าวนำเทคโนโลยี MCP และระบบนิเวศที่กำลังพัฒนา

## วัตถุประสงค์การเรียนรู้

- วิเคราะห์การใช้งาน MCP ในโลกจริงในอุตสาหกรรมต่างๆ
- ออกแบบและสร้างแอปพลิเคชันที่ใช้ MCP อย่างครบถ้วน
- สำรวจเทรนด์ใหม่และทิศทางในอนาคตของเทคโนโลยี MCP
- นำแนวทางปฏิบัติที่ดีที่สุดไปใช้ในสถานการณ์พัฒนาจริง

## การใช้งาน MCP ในโลกจริง

### กรณีศึกษา 1: ระบบอัตโนมัติฝ่ายสนับสนุนลูกค้าองค์กร

บริษัทข้ามชาติได้นำโซลูชันที่ใช้ MCP มาใช้เพื่อทำให้การโต้ตอบ AI ในระบบสนับสนุนลูกค้าเป็นมาตรฐานเดียวกัน ซึ่งช่วยให้พวกเขา:

- สร้างอินเทอร์เฟซเดียวสำหรับผู้ให้บริการ LLM หลายราย
- รักษาการจัดการ prompt ให้สอดคล้องกันในทุกแผนก
- นำมาตรการความปลอดภัยและการปฏิบัติตามกฎระเบียบที่เข้มงวดมาใช้
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

**ผลลัพธ์:** ลดต้นทุนโมเดลลง 30% ปรับปรุงความสม่ำเสมอของการตอบกลับ 45% และเพิ่มความสอดคล้องในการปฏิบัติตามกฎระเบียบทั่วโลก

### กรณีศึกษา 2: ผู้ช่วยวินิจฉัยทางการแพทย์

ผู้ให้บริการด้านสุขภาพได้พัฒนาโครงสร้างพื้นฐาน MCP เพื่อผสานรวมโมเดล AI ทางการแพทย์เฉพาะทางหลายตัว พร้อมทั้งรักษาความปลอดภัยข้อมูลผู้ป่วยที่ละเอียดอ่อน:

- สลับใช้งานระหว่างโมเดลทางการแพทย์ทั่วไปและเฉพาะทางได้อย่างราบรื่น
- ควบคุมความเป็นส่วนตัวอย่างเข้มงวดและมีบันทึกตรวจสอบ
- ผสานรวมกับระบบบันทึกสุขภาพอิเล็กทรอนิกส์ (EHR) ที่มีอยู่
- จัดการ prompt อย่างสม่ำเสมอสำหรับคำศัพท์ทางการแพทย์

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

**ผลลัพธ์:** ปรับปรุงคำแนะนำวินิจฉัยสำหรับแพทย์ พร้อมรักษาความสอดคล้องกับ HIPAA อย่างเต็มที่ และลดการสลับบริบทระหว่างระบบอย่างมีนัยสำคัญ

### กรณีศึกษา 3: การวิเคราะห์ความเสี่ยงในบริการทางการเงิน

สถาบันการเงินได้นำ MCP มาใช้เพื่อทำให้กระบวนการวิเคราะห์ความเสี่ยงในแผนกต่างๆ เป็นมาตรฐานเดียวกัน:

- สร้างอินเทอร์เฟซเดียวสำหรับโมเดลวิเคราะห์ความเสี่ยงเครดิต การตรวจจับการฉ้อโกง และความเสี่ยงการลงทุน
- นำมาตรการควบคุมการเข้าถึงและการจัดการเวอร์ชันโมเดลมาใช้
- รับรองความสามารถในการตรวจสอบคำแนะนำ AI ทั้งหมด
- รักษารูปแบบข้อมูลให้สอดคล้องกันในระบบที่หลากหลาย

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

**ผลลัพธ์:** เพิ่มความสอดคล้องกับกฎระเบียบ เร่งรอบการนำโมเดลไปใช้เร็วขึ้น 40% และปรับปรุงความสม่ำเสมอของการประเมินความเสี่ยงในแผนกต่างๆ

### กรณีศึกษา 4: Microsoft Playwright MCP Server สำหรับการทำงานอัตโนมัติบนเบราว์เซอร์

Microsoft พัฒนา [Playwright MCP server](https://github.com/microsoft/playwright-mcp) เพื่อเปิดใช้งานการทำงานอัตโนมัติบนเบราว์เซอร์ที่ปลอดภัยและเป็นมาตรฐานผ่าน Model Context Protocol โซลูชันนี้ช่วยให้เอเจนต์ AI และ LLM สามารถโต้ตอบกับเว็บเบราว์เซอร์ได้อย่างควบคุม ตรวจสอบได้ และขยายได้—รองรับกรณีใช้งานเช่น การทดสอบเว็บอัตโนมัติ การดึงข้อมูล และเวิร์กโฟลว์แบบครบวงจร

- เปิดเผยความสามารถในการทำงานอัตโนมัติบนเบราว์เซอร์ (การนำทาง กรอกแบบฟอร์ม ถ่ายภาพหน้าจอ ฯลฯ) ในรูปแบบเครื่องมือ MCP
- นำมาตรการควบคุมการเข้าถึงและ sandboxing อย่างเข้มงวดเพื่อป้องกันการกระทำที่ไม่ได้รับอนุญาต
- ให้บันทึกตรวจสอบรายละเอียดสำหรับการโต้ตอบกับเบราว์เซอร์ทั้งหมด
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
- เปิดใช้งานการทำงานอัตโนมัติบนเบราว์เซอร์ที่ปลอดภัยและโปรแกรมเมติกสำหรับเอเจนต์ AI และ LLM  
- ลดความพยายามในการทดสอบด้วยมือและเพิ่มความครอบคลุมของการทดสอบเว็บแอปพลิเคชัน  
- ให้กรอบงานที่นำกลับมาใช้ใหม่และขยายได้สำหรับการผสานรวมเครื่องมือบนเบราว์เซอร์ในสภาพแวดล้อมองค์กร

**เอกสารอ้างอิง:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### กรณีศึกษา 5: Azure MCP – Model Context Protocol ระดับองค์กรในรูปแบบบริการ

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) คือการใช้งาน Model Context Protocol ระดับองค์กรที่ Microsoft บริหารจัดการ ซึ่งออกแบบมาเพื่อให้บริการ MCP server ที่ขยายตัวได้ ปลอดภัย และสอดคล้องตามกฎระเบียบในรูปแบบบริการคลาวด์ Azure MCP ช่วยให้องค์กรสามารถนำ MCP server ไปใช้ จัดการ และผสานรวมกับ Azure AI, ข้อมูล และบริการความปลอดภัยได้อย่างรวดเร็ว ลดภาระการดำเนินงานและเร่งการนำ AI มาใช้

- โฮสต์ MCP server แบบจัดการเต็มรูปแบบ พร้อมการปรับขนาด การตรวจสอบ และความปลอดภัยในตัว
- ผสานรวมเนทีฟกับ Azure OpenAI, Azure AI Search และบริการ Azure อื่นๆ
- การพิสูจน์ตัวตนและการอนุญาตระดับองค์กรผ่าน Microsoft Entra ID
- รองรับเครื่องมือที่กำหนดเอง, เทมเพลต prompt และตัวเชื่อมต่อทรัพยากร
- สอดคล้องกับข้อกำหนดด้านความปลอดภัยและกฎระเบียบขององค์กร

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
- ลดเวลาสู่คุณค่าสำหรับโครงการ AI ระดับองค์กรด้วยการให้แพลตฟอร์ม MCP server ที่พร้อมใช้งานและสอดคล้อง  
- ทำให้ง่ายต่อการผสานรวม LLM, เครื่องมือ และแหล่งข้อมูลองค์กร  
- เพิ่มความปลอดภัย การสังเกตการณ์ และประสิทธิภาพการดำเนินงานสำหรับงาน MCP

**เอกสารอ้างอิง:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## กรณีศึกษา 6: NLWeb  
MCP (Model Context Protocol) เป็นโปรโตคอลที่กำลังเกิดขึ้นสำหรับแชทบอทและผู้ช่วย AI ในการโต้ตอบกับเครื่องมือต่างๆ ทุกอินสแตนซ์ของ NLWeb ยังเป็น MCP server ซึ่งรองรับเมธอดหลักหนึ่งตัวคือ ask ที่ใช้ถามเว็บไซต์ด้วยภาษาธรรมชาติ คำตอบที่ส่งกลับใช้ schema.org ซึ่งเป็นคำศัพท์ที่ใช้กันอย่างแพร่หลายสำหรับการอธิบายข้อมูลเว็บ โดยสรุป MCP คือ NLWeb ในแบบเดียวกับที่ Http เป็นต่อ HTML NLWeb รวมโปรโตคอล รูปแบบ Schema.org และโค้ดตัวอย่างเพื่อช่วยให้เว็บไซต์สร้างจุดเชื่อมต่อเหล่านี้ได้อย่างรวดเร็ว ซึ่งเป็นประโยชน์ทั้งกับมนุษย์ผ่านอินเทอร์เฟซสนทนาและกับเครื่องจักรผ่านการโต้ตอบแบบ agent-to-agent

NLWeb มีสองส่วนประกอบที่แตกต่างกัน  
- โปรโตคอลที่เรียบง่ายสำหรับเริ่มต้น เพื่อเชื่อมต่อกับเว็บไซต์ด้วยภาษาธรรมชาติและรูปแบบที่ใช้ json และ schema.org สำหรับคำตอบ ดูเอกสาร REST API สำหรับรายละเอียดเพิ่มเติม  
- การใช้งานที่ตรงไปตรงมาของ (1) ที่ใช้มาร์กอัปที่มีอยู่ สำหรับเว็บไซต์ที่สามารถสรุปเป็นรายการของรายการ (สินค้า สูตรอาหาร สถานที่ท่องเที่ยว รีวิว ฯลฯ) พร้อมด้วยชุดวิดเจ็ตอินเทอร์เฟซผู้ใช้ เว็บไซต์สามารถให้บริการอินเทอร์เฟซสนทนาแก่เนื้อหาได้อย่างง่ายดาย ดูเอกสาร Life of a chat query สำหรับรายละเอียดเพิ่มเติมเกี่ยวกับการทำงานนี้

**เอกสารอ้างอิง:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### กรณีศึกษา 7: MCP สำหรับ Foundry – การผสานรวม Azure AI Agents

เซิร์ฟเวอร์ Azure AI Foundry MCP แสดงให้เห็นว่า MCP สามารถใช้ในการจัดการและควบคุมเอเจนต์ AI และเวิร์กโฟลว์ในสภาพแวดล้อมองค์กรได้อย่างไร โดยการผสาน MCP กับ Azure AI Foundry องค์กรสามารถทำให้การโต้ตอบของเอเจนต์เป็นมาตรฐาน ใช้ประโยชน์จากการจัดการเวิร์กโฟลว์ของ Foundry และรับรองการนำไปใช้ที่ปลอดภัยและขยายตัวได้ วิธีนี้ช่วยให้การสร้างต้นแบบรวดเร็ว การตรวจสอบที่แข็งแกร่ง และการผสานรวมกับบริการ Azure AI อย่างราบรื่น รองรับสถานการณ์ขั้นสูง เช่น การจัดการความรู้และการประเมินเอเจนต์ นักพัฒนาจะได้รับอินเทอร์เฟซเดียวสำหรับการสร้าง นำไปใช้ และตรวจสอบสายงานเอเจนต์ ขณะที่ทีมไอทีจะได้รับความปลอดภัยที่ดีขึ้น การปฏิบัติตามกฎระเบียบ และประสิทธิภาพการดำเนินงาน โซลูชันนี้เหมาะสำหรับองค์กรที่ต้องการเร่งการนำ AI มาใช้และควบคุมกระบวนการที่ซับซ้อนซึ่งขับเคลื่อนด้วยเอเจนต์

**เอกสารอ้างอิง:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### กรณีศึกษา 8: Foundry MCP Playground – การทดลองและสร้างต้นแบบ

Foundry MCP Playground เป็นสภาพแวดล้อมพร้อมใช้งานสำหรับทดลองกับ MCP server และการผสานรวม Azure AI Foundry นักพัฒนาสามารถสร้างต้นแบบ ทดสอบ และประเมินโมเดล AI และเวิร์กโฟลว์เอเจนต์ได้อย่างรวดเร็วโดยใช้ทรัพยากรจาก Azure AI Foundry Catalog และ Labs สนามเด็กเล่นนี้ช่วยให้การตั้งค่าง่ายขึ้น มีโครงการตัวอย่าง และสนับสนุนการพัฒนาร่วมกัน ทำให้ง่ายต่อการสำรวจแนวทางปฏิบัติที่ดีที่สุดและสถานการณ์ใหม่ๆ โดยมีภาระงานน้อย เหมาะอย่างยิ่งสำหรับทีมที่ต้องการยืนยันไอเดีย แบ่งปันการทดลอง และเร่งการเรียนรู้โดยไม่ต้องใช้โครงสร้างพื้นฐานที่ซับซ้อน ด้วยการลดอุปสรรคในการเริ่มต้น สนามเด็กเล่นช่วยส่งเสริมนวัตกรรมและการมีส่วนร่วมของชุมชนในระบบนิเวศ MCP และ Azure AI Foundry

**เอกสารอ้างอิง:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### กรณีศึกษา 9: Microsoft Docs MCP Server – การเรียนรู้และพัฒนาทักษะ  
Microsoft Docs MCP Server เป็นการใช้งาน Model Context Protocol (MCP) server ที่ให้ผู้ช่วย AI เข้าถึงเอกสารทางการของ Microsoft แบบเรียลไทม์ ทำการค้นหาเชิงความหมายในเอกสารทางเทคนิคอย่างเป็นทางการของ Microsoft

**เอกสารอ้างอิง:**  
- [Microsoft Learn Docs MCP Server](https://github.com/MicrosoftDocs/mcp)

## โครงการลงมือปฏิบัติ

### โครงการ 1: สร้าง MCP Server ที่รองรับผู้ให้บริการหลายราย

**วัตถุประสงค์:** สร้าง MCP server ที่สามารถส่งคำขอไปยังผู้ให้บริการโมเดล AI หลายรายตามเกณฑ์ที่กำหนด

**ข้อกำหนด:**  
- รองรับผู้ให้บริการโมเดลอย่างน้อยสามราย (เช่น OpenAI, Anthropic, โมเดลภายในองค์กร)  
- นำกลไกการกำหนดเส้นทางตามเมตาดาต้าของคำขอมาใช้  
- สร้างระบบกำหนดค่าสำหรับจัดการข้อมูลรับรองของผู้ให้บริการ  
- เพิ่มระบบแคชเพื่อเพิ่มประสิทธิภาพและลดต้นทุน  
- สร้างแดชบอร์ดง่ายๆ สำหรับติดตามการใช้งาน

**ขั้นตอนการใช้งาน:**  
1. ตั้งค่าโครงสร้างพื้นฐาน MCP server เบื้องต้น  
2. พัฒนาอะแดปเตอร์ผู้ให้บริการสำหรับแต่ละบริการโมเดล AI  
3. สร้างตรรกะการกำหนดเส้นทางตามคุณสมบัติของคำขอ  
4. เพิ่มกลไกแคชสำหรับคำขอที่ใช้บ่อย  
5. พัฒนาแดชบอร์ดสำหรับการติดตาม  
6. ทดสอบด้วยรูปแบบคำขอต่างๆ

**เทคโนโลยี:** เลือกใช้ Python (.NET/Java/Python ตามความถนัด), Redis สำหรับแคช และเว็บเฟรมเวิร์กง่ายๆ สำหรับแดชบอร์ด

### โครงการ 2: ระบบจัดการ Prompt ระดับองค์กร

**วัตถุประสงค์:** พัฒนาระบบที่ใช้ MCP สำหรับจัดการ การจัดเวอร์ชัน และการนำเทมเพลต prompt ไปใช้ในองค์กร

**ข้อกำหนด:**  
- สร้างคลังเทมเพลต prompt กลาง  
- นำระบบจัดเวอร์ชันและเวิร์กโฟลว์อนุมัติมาใช้  
- สร้างความสามารถในการทดสอบเทมเพลตด้วยข้อมูลตัวอย่าง  
- พัฒนาการควบคุมการเข้าถึงตามบทบาท  
- สร้าง API สำหรับดึงและนำเทมเพลตไปใช้

**ขั้นตอนการใช้งาน:**  
1. ออกแบบสคีมาฐานข้อมูลสำหรับเก็บเทมเพลต  
2. สร้าง API หลักสำหรับ CRUD เทมเพลต  
3. นำระบบจัดเวอร์ชันมาใช้  
4. สร้างเวิร์กโฟลว์อนุมัติ  
5. พัฒนากรอบการทดสอบ  
6. สร้างอินเทอร์เฟซเว็บง่ายๆ สำหรับการจัดการ  
7. ผสานรวมกับ MCP server

**เทคโนโลยี:** เลือกใช้เฟรมเวิร์กแบ็กเอนด์ ฐานข้อมูล SQL หรือ NoSQL และเฟรมเวิร์กฟรอนต์เอนด์สำหรับอินเทอร์เฟซจัดการ

### โครงการ 3: แพลตฟอร์มสร้างเนื้อหาที่ใช้ MCP

**วัตถุประสงค์:** สร้างแพลตฟอร์มสร้างเนื้อหาที่ใช้ MCP เพื่อให้ผลลัพธ์ที่สม่ำเสมอในเนื้อหาหลากหลายประเภท

**ข้อกำหนด:**  
- รองรับรูปแบบเนื้อหาหลายประเภท (บทความบล็อก โซเชียลมีเดีย คัดลอกการตลาด)  
- นำการสร้างเนื้อหาจากเทมเพลตพร้อมตัวเลือกปรับแต่งมาใช้  
- สร้างระบบตรวจสอบและให้ข้อเสนอแนะเนื้อหา  
- ติดตามตัวชี้วัดประสิทธิ
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - หน้าแรกสำหรับการใช้งาน Remote MCP Server บน Azure Functions พร้อมลิงก์ไปยังรีโปสำหรับแต่ละภาษา  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - เทมเพลตเริ่มต้นสำหรับการสร้างและปรับใช้เซิร์ฟเวอร์ remote MCP แบบกำหนดเองโดยใช้ Azure Functions กับ Python  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - เทมเพลตเริ่มต้นสำหรับการสร้างและปรับใช้เซิร์ฟเวอร์ remote MCP แบบกำหนดเองโดยใช้ Azure Functions กับ .NET/C#  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - เทมเพลตเริ่มต้นสำหรับการสร้างและปรับใช้เซิร์ฟเวอร์ remote MCP แบบกำหนดเองโดยใช้ Azure Functions กับ TypeScript  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Azure API Management ในฐานะ AI Gateway สำหรับ Remote MCP servers โดยใช้ Python  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - การทดลอง APIM ❤️ AI รวมถึงความสามารถของ MCP ที่เชื่อมต่อกับ Azure OpenAI และ AI Foundry  

รีโปเหล่านี้นำเสนอการใช้งาน เทมเพลต และทรัพยากรต่างๆ สำหรับการทำงานกับ Model Context Protocol ในหลายภาษาโปรแกรมและบริการของ Azure ครอบคลุมการใช้งานตั้งแต่การสร้างเซิร์ฟเวอร์พื้นฐานไปจนถึงการยืนยันตัวตน การปรับใช้บนคลาวด์ และการรวมระบบในองค์กร  

#### MCP Resources Directory

[ไดเรกทอรี MCP Resources](https://github.com/microsoft/mcp/tree/main/Resources) ในรีโป MCP อย่างเป็นทางการของ Microsoft เป็นการรวบรวมตัวอย่างทรัพยากร เทมเพลต prompt และคำจำกัดความของเครื่องมือที่คัดสรรมาเพื่อใช้กับเซิร์ฟเวอร์ Model Context Protocol ไดเรกทอรีนี้ถูกออกแบบมาเพื่อช่วยให้นักพัฒนาสามารถเริ่มต้นกับ MCP ได้อย่างรวดเร็วโดยมีบล็อกที่ใช้ซ้ำได้และตัวอย่างแนวทางปฏิบัติที่ดีที่สุดสำหรับ:  

- **Prompt Templates:** เทมเพลต prompt ที่พร้อมใช้งานสำหรับงานและสถานการณ์ AI ทั่วไป ซึ่งสามารถปรับใช้กับการสร้างเซิร์ฟเวอร์ MCP ของคุณเองได้  
- **Tool Definitions:** ตัวอย่างสคีมาและเมตาดาต้าของเครื่องมือเพื่อมาตรฐานการรวมและเรียกใช้งานเครื่องมือในเซิร์ฟเวอร์ MCP ต่างๆ  
- **Resource Samples:** ตัวอย่างคำจำกัดความทรัพยากรสำหรับการเชื่อมต่อกับแหล่งข้อมูล APIs และบริการภายนอกภายในกรอบงาน MCP  
- **Reference Implementations:** ตัวอย่างใช้งานจริงที่แสดงวิธีการจัดโครงสร้างและจัดการทรัพยากร prompt และเครื่องมือในโครงการ MCP ที่ใช้ในโลกจริง  

ทรัพยากรเหล่านี้ช่วยเร่งการพัฒนา ส่งเสริมมาตรฐาน และช่วยให้มั่นใจในแนวทางปฏิบัติที่ดีที่สุดเมื่อสร้างและปรับใช้โซลูชันที่ใช้ MCP  

#### MCP Resources Directory
- [MCP Resources (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)  

### โอกาสในการวิจัย  

- เทคนิคการปรับแต่ง prompt อย่างมีประสิทธิภาพภายในกรอบงาน MCP  
- รูปแบบความปลอดภัยสำหรับการปรับใช้ MCP แบบหลายผู้เช่า  
- การวัดประสิทธิภาพใน MCP ที่หลากหลาย  
- วิธีการตรวจสอบความถูกต้องอย่างเป็นทางการสำหรับเซิร์ฟเวอร์ MCP  

## สรุป  

Model Context Protocol (MCP) กำลังเป็นตัวกำหนดอนาคตของการรวม AI ที่มีมาตรฐาน ปลอดภัย และสามารถทำงานร่วมกันได้ในหลายอุตสาหกรรม ผ่านกรณีศึกษาและโครงการปฏิบัติในบทเรียนนี้ คุณได้เห็นว่าผู้ใช้งานรายแรกๆ รวมถึง Microsoft และ Azure ใช้ MCP เพื่อแก้ปัญหาในโลกจริง เร่งการนำ AI มาใช้ และรับประกันความสอดคล้อง ความปลอดภัย และความสามารถในการขยายตัว วิธีการแบบโมดูลาร์ของ MCP ช่วยให้องค์กรสามารถเชื่อมต่อโมเดลภาษาใหญ่ เครื่องมือ และข้อมูลองค์กรในกรอบงานที่เป็นหนึ่งเดียวและตรวจสอบได้ เมื่อ MCP พัฒนาต่อไป การมีส่วนร่วมกับชุมชน การสำรวจทรัพยากรโอเพนซอร์ส และการนำแนวทางปฏิบัติที่ดีที่สุดมาใช้จะเป็นกุญแจสำคัญในการสร้างโซลูชัน AI ที่แข็งแกร่งและพร้อมสำหรับอนาคต  

## ทรัพยากรเพิ่มเติม  

- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Foundry MCP Playground](https://github.com/azure-ai-foundry/foundry-mcp-playground)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)  
- [MCP GitHub Repository (Microsoft)](https://github.com/microsoft/mcp)  
- [MCP Resources Directory (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)  
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

1. วิเคราะห์หนึ่งในกรณีศึกษาและเสนอแนวทางการใช้งานทางเลือก  
2. เลือกหนึ่งในไอเดียโครงการและสร้างข้อกำหนดทางเทคนิคอย่างละเอียด  
3. ศึกษาอุตสาหกรรมที่ไม่ได้กล่าวถึงในกรณีศึกษาและร่างแนวทางที่ MCP จะช่วยแก้ปัญหาเฉพาะของอุตสาหกรรมนั้นได้  
4. สำรวจหนึ่งในทิศทางอนาคตและสร้างแนวคิดสำหรับส่วนขยาย MCP ใหม่เพื่อรองรับทิศทางนั้น  

ถัดไป: [Best Practices](../08-BestPractices/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้บริการแปลโดยผู้เชี่ยวชาญมนุษย์ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดใด ๆ ที่เกิดจากการใช้การแปลนี้