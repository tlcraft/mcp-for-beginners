<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1ccfe1a6ea77e42862b92ae53cb6cddf",
  "translation_date": "2025-05-20T17:12:23+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "th"
}
-->
# บทเรียนจากผู้ใช้งานรุ่นแรก

## ภาพรวม

บทเรียนนี้สำรวจว่าผู้ใช้งานรุ่นแรกได้นำ Model Context Protocol (MCP) มาใช้แก้ไขปัญหาในโลกจริงและขับเคลื่อนนวัตกรรมในหลายอุตสาหกรรมอย่างไร ผ่านกรณีศึกษาละเอียดและโครงการฝึกปฏิบัติ คุณจะได้เห็นว่า MCP ช่วยให้การผสานรวม AI ที่เป็นมาตรฐาน มีความปลอดภัย และขยายตัวได้อย่างไร—เชื่อมต่อโมเดลภาษาใหญ่ เครื่องมือ และข้อมูลองค์กรในกรอบงานเดียวกัน คุณจะได้รับประสบการณ์จริงในการออกแบบและสร้างโซลูชันที่ใช้ MCP เรียนรู้จากรูปแบบการใช้งานที่พิสูจน์แล้ว และค้นพบแนวทางปฏิบัติที่ดีที่สุดสำหรับการนำ MCP ไปใช้ในสภาพแวดล้อมการผลิต บทเรียนยังเน้นเทรนด์ใหม่ ๆ ทิศทางในอนาคต และแหล่งข้อมูลโอเพนซอร์สที่จะช่วยให้คุณก้าวนำเทคโนโลยี MCP และระบบนิเวศที่กำลังพัฒนาได้อย่างต่อเนื่อง

## วัตถุประสงค์การเรียนรู้

- วิเคราะห์การใช้งาน MCP ในโลกจริงในหลายอุตสาหกรรม
- ออกแบบและสร้างแอปพลิเคชันที่ใช้ MCP อย่างครบถ้วน
- สำรวจเทรนด์ใหม่และทิศทางในอนาคตของเทคโนโลยี MCP
- นำแนวทางปฏิบัติที่ดีที่สุดไปใช้ในสถานการณ์พัฒนาจริง

## การใช้งาน MCP ในโลกจริง

### กรณีศึกษา 1: ระบบอัตโนมัติสนับสนุนลูกค้าองค์กร

บริษัทข้ามชาติได้นำโซลูชันที่ใช้ MCP มาใช้เพื่อมาตรฐานการโต้ตอบ AI ในระบบสนับสนุนลูกค้าของพวกเขา ซึ่งช่วยให้สามารถ:

- สร้างอินเทอร์เฟซเดียวสำหรับผู้ให้บริการ LLM หลายราย
- รักษาการจัดการ prompt ให้สอดคล้องกันในทุกแผนก
- นำมาตรการรักษาความปลอดภัยและการปฏิบัติตามข้อกำหนดที่เข้มงวดมาใช้
- สลับใช้โมเดล AI ต่าง ๆ ได้อย่างง่ายดายตามความต้องการเฉพาะ

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

**ผลลัพธ์:** ลดต้นทุนโมเดลลง 30% ปรับปรุงความสม่ำเสมอของการตอบกลับ 45% และเสริมสร้างการปฏิบัติตามกฎระเบียบทั่วโลก

### กรณีศึกษา 2: ผู้ช่วยวินิจฉัยทางการแพทย์

ผู้ให้บริการดูแลสุขภาพได้พัฒนาโครงสร้างพื้นฐาน MCP เพื่อผสานรวมโมเดล AI ทางการแพทย์เฉพาะทางหลายตัวพร้อมกับการปกป้องข้อมูลผู้ป่วยที่ละเอียดอ่อน:

- สลับใช้โมเดลทางการแพทย์ทั่วไปและเฉพาะทางได้อย่างราบรื่น
- ควบคุมความเป็นส่วนตัวและบันทึกตรวจสอบอย่างเข้มงวด
- ผสานรวมกับระบบบันทึกสุขภาพอิเล็กทรอนิกส์ (EHR) ที่มีอยู่
- บริหารจัดการ prompt สำหรับศัพท์ทางการแพทย์อย่างสม่ำเสมอ

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

**ผลลัพธ์:** ปรับปรุงคำแนะนำวินิจฉัยสำหรับแพทย์พร้อมการปฏิบัติตาม HIPAA เต็มรูปแบบ และลดการสลับบริบทระหว่างระบบอย่างมีนัยสำคัญ

### กรณีศึกษา 3: การวิเคราะห์ความเสี่ยงทางการเงิน

สถาบันการเงินได้นำ MCP มาใช้เพื่อมาตรฐานกระบวนการวิเคราะห์ความเสี่ยงในหลายแผนก:

- สร้างอินเทอร์เฟซเดียวสำหรับโมเดลความเสี่ยงเครดิต การตรวจจับการฉ้อโกง และความเสี่ยงการลงทุน
- นำมาตรการควบคุมการเข้าถึงและการจัดการเวอร์ชันโมเดลมาใช้
- รับประกันความสามารถในการตรวจสอบคำแนะนำ AI ทุกข้อ
- รักษารูปแบบข้อมูลที่สม่ำเสมอในระบบที่หลากหลาย

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

**ผลลัพธ์:** เสริมสร้างการปฏิบัติตามกฎระเบียบ เร่งรอบการนำโมเดลไปใช้ได้เร็วขึ้น 40% และปรับปรุงความสม่ำเสมอของการประเมินความเสี่ยงในแผนกต่าง ๆ

### กรณีศึกษา 4: Microsoft Playwright MCP Server สำหรับการอัตโนมัติบนเบราว์เซอร์

Microsoft พัฒนา [Playwright MCP server](https://github.com/microsoft/playwright-mcp) เพื่อให้สามารถทำงานอัตโนมัติบนเว็บเบราว์เซอร์ได้อย่างปลอดภัยและเป็นมาตรฐานผ่าน Model Context Protocol โซลูชันนี้ช่วยให้เอเจนต์ AI และ LLM โต้ตอบกับเว็บเบราว์เซอร์ในรูปแบบที่ควบคุม ตรวจสอบได้ และขยายได้—รองรับกรณีใช้งานเช่น การทดสอบเว็บอัตโนมัติ การดึงข้อมูล และเวิร์กโฟลว์แบบครบวงจร

- เปิดเผยความสามารถในการอัตโนมัติบนเบราว์เซอร์ (การนำทาง กรอกแบบฟอร์ม ถ่ายภาพหน้าจอ ฯลฯ) เป็นเครื่องมือ MCP
- นำมาตรการควบคุมการเข้าถึงและ sandboxing อย่างเข้มงวดเพื่อป้องกันการกระทำที่ไม่ได้รับอนุญาต
- ให้บันทึกตรวจสอบรายละเอียดสำหรับการโต้ตอบบนเบราว์เซอร์ทั้งหมด
- รองรับการผสานรวมกับ Azure OpenAI และผู้ให้บริการ LLM อื่น ๆ สำหรับการอัตโนมัติที่ขับเคลื่อนโดยเอเจนต์

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
- เปิดใช้งานการอัตโนมัติบนเบราว์เซอร์อย่างปลอดภัยและเป็นโปรแกรมสำหรับเอเจนต์ AI และ LLM  
- ลดความพยายามในการทดสอบด้วยตนเองและปรับปรุงความครอบคลุมของการทดสอบเว็บแอปพลิเคชัน  
- มอบกรอบงานที่นำกลับมาใช้ใหม่และขยายได้สำหรับการผสานรวมเครื่องมือบนเบราว์เซอร์ในสภาพแวดล้อมองค์กร  

**เอกสารอ้างอิง:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### กรณีศึกษา 5: Azure MCP – Model Context Protocol ระดับองค์กรในรูปแบบบริการ

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) คือการใช้งาน Model Context Protocol ระดับองค์กรที่ Microsoft บริหารจัดการอย่างครบวงจร ออกแบบมาเพื่อให้บริการ MCP server ที่ขยายตัวได้ ปลอดภัย และปฏิบัติตามข้อกำหนดในรูปแบบบริการบนคลาวด์ Azure MCP ช่วยให้องค์กรสามารถปรับใช้ จัดการ และผสานรวม MCP server กับบริการ Azure AI ข้อมูล และความปลอดภัยได้อย่างรวดเร็ว ลดภาระการดำเนินงานและเร่งการนำ AI ไปใช้

- โฮสต์ MCP server แบบจัดการเต็มรูปแบบพร้อมฟีเจอร์ปรับขนาด ตรวจสอบ และความปลอดภัยในตัว
- ผสานรวมแบบเนทีฟกับ Azure OpenAI, Azure AI Search และบริการ Azure อื่น ๆ
- การพิสูจน์ตัวตนและอนุญาตระดับองค์กรผ่าน Microsoft Entra ID
- รองรับเครื่องมือที่กำหนดเอง, เทมเพลต prompt และตัวเชื่อมต่อทรัพยากร
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
- ลดเวลาในการสร้างมูลค่าสำหรับโครงการ AI องค์กรด้วยแพลตฟอร์ม MCP server ที่พร้อมใช้งานและปฏิบัติตามข้อกำหนด  
- ทำให้ง่ายขึ้นในการผสานรวม LLM เครื่องมือ และแหล่งข้อมูลองค์กร  
- เสริมความปลอดภัย การสังเกตการณ์ และประสิทธิภาพการดำเนินงานสำหรับงาน MCP  

**เอกสารอ้างอิง:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## กรณีศึกษา 6: NLWeb  
MCP (Model Context Protocol) คือโปรโตคอลที่กำลังเกิดขึ้นสำหรับแชทบอทและผู้ช่วย AI ในการโต้ตอบกับเครื่องมือต่าง ๆ ทุกอินสแตนซ์ของ NLWeb ยังทำหน้าที่เป็น MCP server ที่รองรับเมธอดหลักหนึ่งเมธอดคือ ask ซึ่งใช้ถามคำถามเว็บไซต์ด้วยภาษาธรรมชาติ คำตอบที่ได้รับจะใช้ schema.org ซึ่งเป็นคำศัพท์ที่ใช้กันอย่างแพร่หลายสำหรับอธิบายข้อมูลเว็บ โดยเปรียบง่าย ๆ ว่า MCP คือ NLWeb เหมือนกับ Http ต่อ HTML NLWeb รวมโปรโตคอล รูปแบบ Schema.org และโค้ดตัวอย่างเพื่อช่วยให้เว็บไซต์สร้าง endpoint เหล่านี้ได้อย่างรวดเร็ว ซึ่งเป็นประโยชน์ทั้งกับมนุษย์ผ่านอินเทอร์เฟซสนทนาและเครื่องจักรผ่านการโต้ตอบเอเจนต์ต่อเอเจนต์แบบธรรมชาติ

NLWeb มีสองส่วนประกอบที่แตกต่างกัน  
- โปรโตคอลที่เริ่มต้นง่ายสำหรับเชื่อมต่อกับเว็บไซต์ด้วยภาษาธรรมชาติและรูปแบบที่ใช้ json กับ schema.org สำหรับคำตอบ ดูเอกสาร REST API เพื่อรายละเอียดเพิ่มเติม  
- การใช้งานที่ตรงไปตรงมาของ (1) ที่ใช้มาร์กอัปที่มีอยู่สำหรับเว็บไซต์ที่สามารถสรุปเป็นรายการของไอเท็ม (สินค้า สูตรอาหาร สถานที่ท่องเที่ยว รีวิว ฯลฯ) ร่วมกับชุดวิดเจ็ตอินเทอร์เฟซผู้ใช้ เว็บไซต์สามารถนำเสนออินเทอร์เฟซสนทนาแก่เนื้อหาของตนได้อย่างง่ายดาย ดูเอกสาร Life of a chat query สำหรับรายละเอียดเพิ่มเติมเกี่ยวกับวิธีการทำงานนี้  

**เอกสารอ้างอิง:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### กรณีศึกษา 7: MCP สำหรับ Foundry – การผสานรวม Azure AI Agents

เซิร์ฟเวอร์ Azure AI Foundry MCP แสดงให้เห็นว่า MCP สามารถใช้จัดการและควบคุมเอเจนต์ AI และเวิร์กโฟลว์ในสภาพแวดล้อมองค์กรได้อย่างไร โดยการผสาน MCP กับ Azure AI Foundry องค์กรสามารถมาตรฐานการโต้ตอบของเอเจนต์ ใช้ประโยชน์จากการจัดการเวิร์กโฟลว์ของ Foundry และรับประกันการปรับใช้ที่ปลอดภัยและขยายตัวได้ วิธีนี้ช่วยให้สามารถสร้างต้นแบบได้อย่างรวดเร็ว มีการตรวจสอบที่เข้มงวด และผสานรวมกับบริการ Azure AI ได้อย่างไร้รอยต่อ รองรับสถานการณ์ขั้นสูงเช่น การจัดการความรู้และการประเมินเอเจนต์ นักพัฒนาจะได้รับอินเทอร์เฟซเดียวสำหรับการสร้าง นำไปใช้ และตรวจสอบสายงานเอเจนต์ ในขณะที่ทีม IT จะได้รับความปลอดภัย การปฏิบัติตามกฎระเบียบ และประสิทธิภาพการดำเนินงานที่ดีขึ้น โซลูชันนี้เหมาะสำหรับองค์กรที่ต้องการเร่งการนำ AI ไปใช้และควบคุมกระบวนการที่ซับซ้อนซึ่งขับเคลื่อนโดยเอเจนต์

**เอกสารอ้างอิง:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### กรณีศึกษา 8: Foundry MCP Playground – การทดลองและสร้างต้นแบบ

Foundry MCP Playground มอบสภาพแวดล้อมพร้อมใช้งานสำหรับทดลองกับ MCP server และการผสานรวม Azure AI Foundry นักพัฒนาสามารถสร้างต้นแบบ ทดสอบ และประเมินโมเดล AI รวมถึงเวิร์กโฟลว์เอเจนต์ได้อย่างรวดเร็วโดยใช้ทรัพยากรจาก Azure AI Foundry Catalog และ Labs playground ช่วยให้งานตั้งค่าเป็นไปอย่างรวดเร็ว มีโครงการตัวอย่าง และรองรับการพัฒนาร่วมกัน ทำให้ง่ายต่อการสำรวจแนวทางปฏิบัติที่ดีที่สุดและสถานการณ์ใหม่ ๆ ด้วยต้นทุนต่ำ เหมาะสำหรับทีมที่ต้องการยืนยันไอเดีย แชร์การทดลอง และเร่งการเรียนรู้โดยไม่ต้องใช้โครงสร้างพื้นฐานซับซ้อน ด้วยการลดอุปสรรคในการเข้าถึง playground ช่วยส่งเสริมนวัตกรรมและการมีส่วนร่วมของชุมชนในระบบนิเวศ MCP และ Azure AI Foundry

**เอกสารอ้างอิง:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

## โครงการฝึกปฏิบัติ

### โครงการ 1: สร้าง MCP Server ที่รองรับผู้ให้บริการหลายราย

**วัตถุประสงค์:** สร้าง MCP server ที่สามารถกำหนดเส้นทางคำขอไปยังผู้ให้บริการโมเดล AI หลายรายตามเกณฑ์เฉพาะ

**ข้อกำหนด:**  
- รองรับผู้ให้บริการโมเดลอย่างน้อยสามราย (เช่น OpenAI, Anthropic, โมเดลภายใน)  
- นำกลไกการกำหนดเส้นทางตามเมตาดาต้าของคำขอมาใช้  
- สร้างระบบกำหนดค่าสำหรับจัดการข้อมูลรับรองของผู้ให้บริการ  
- เพิ่มการแคชเพื่อเพิ่มประสิทธิภาพและลดต้นทุน  
- สร้างแดชบอร์ดง่าย ๆ สำหรับตรวจสอบการใช้งาน

**ขั้นตอนการใช้งาน:**  
1. ตั้งค่าโครงสร้างพื้นฐาน MCP server เบื้องต้น  
2. พัฒนาตัวปรับแต่งผู้ให้บริการสำหรับแต่ละบริการโมเดล AI  
3. สร้างตรรกะการกำหนดเส้นทางตามคุณลักษณะของคำขอ  
4. เพิ่มกลไกแคชสำหรับคำขอบ่อย  
5. พัฒนาแดชบอร์ดสำหรับตรวจสอบ  
6. ทดสอบด้วยรูปแบบคำขอหลากหลาย

**เทคโนโลยี:** เลือกจาก Python (.NET/Java/Python ตามความชอบ), Redis สำหรับแคช และเว็บเฟรมเวิร์กง่าย ๆ สำหรับแดชบอร์ด

### โครงการ 2: ระบบจัดการ Prompt สำหรับองค์กร

**วัตถุประสงค์:** พัฒนาระบบที่ใช้ MCP สำหรับจัดการ เวอร์ชัน และปรับใช้เทมเพลต prompt ในองค์กร

**ข้อกำหนด:**  
- สร้างคลังเทมเพลต prompt กลาง  
- นำระบบเวอร์ชันและเวิร์กโฟลว์อนุมัติมาใช้  
- สร้างความสามารถในการทดสอบเทมเพลตด้วยข้อมูลตัวอย่าง  
- พัฒนาการควบคุมการเข้าถึงตามบทบาท  
- สร้าง API สำหรับดึงและปรับใช้เทมเพลต

**ขั้นตอนการใช้งาน:**  
1. ออกแบบสคีมาฐานข้อมูลสำหรับเก็บเทมเพลต  
2. สร้าง API หลักสำหรับ CRUD เทมเพลต  
3. นำระบบเวอร์ชันมาใช้  
4. สร้างเวิร์กโฟลว์อนุมัติ  
5. พัฒนากรอบการทดสอบ  
6. สร้างอินเทอร์เฟซเว็บง่าย ๆ สำหรับการจัดการ  
7. ผสานรวมกับ MCP server

**เทคโนโลยี:** เลือกเฟรมเวิร์กแบ็กเอนด์ ฐานข้อมูล SQL หรือ NoSQL และเฟรมเวิร์กฟรอนต์เอนด์ตามที่ต้องการ

### โครงการ 3: แพลตฟอร์มสร้างเนื้อหาที่ใช้ MCP

**วัตถุประสงค์:** สร้างแพลตฟอร์มสร้างเนื้อหาที่ใช้ MCP เพื่อให้ผลลัพธ์ที่สม่ำเสมอในหลายประเภทเนื้อหา

**ข้อกำหนด:**  
- รองรับหลายรูปแบบเนื้อหา (บทความบล็อก โซเชียลมีเดีย ข้อความการตลาด)  
- ใช้การสร้างเนื้อหาจากเทมเพลตพร้อมตัวเลือกปรับแต่ง  
- สร้างระบบตรวจสอบและให้ข้อเสนอแนะเนื้อหา  
- ติดตามเมตริกประสิทธิภาพของเนื้อหา  
- รองรับการเวอร์ชันและการปรับปรุงเนื้อหา

**ขั้นตอนการใช้งาน:**  
1. ตั้งค่าโครงสร้างพื้นฐาน MCP client  
2. สร้างเทมเพลตสำหรับประเภทเนื้อหาต่าง ๆ  
3. สร้างสายงานการสร้างเนื้อหา  
4. นำระบบตรวจสอบมาใช้  
5. พัฒนาระบบติดตามเมตริก  
6. สร้างอินเทอร์เฟซผู้ใช้สำหรับจัดการเทมเพลตและสร้างเนื้อหา

**เทคโนโลยี:** เลือ
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

1. วิเคราะห์กรณีศึกษาหนึ่งและเสนอแนวทางการดำเนินการทางเลือก
2. เลือกหนึ่งในไอเดียโปรเจกต์และจัดทำข้อกำหนดทางเทคนิคอย่างละเอียด
3. ศึกษาอุตสาหกรรมที่ไม่ได้อยู่ในกรณีศึกษา และร่างแนวทางที่ MCP สามารถแก้ไขปัญหาเฉพาะของอุตสาหกรรมนั้นได้
4. สำรวจทิศทางในอนาคตหนึ่งทางและสร้างแนวคิดสำหรับส่วนขยาย MCP ใหม่เพื่อสนับสนุนทิศทางนั้น

ถัดไป: [Best Practices](../08-BestPractices/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ แนะนำให้ใช้บริการแปลโดยผู้เชี่ยวชาญมนุษย์ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดใด ๆ ที่เกิดจากการใช้การแปลนี้