<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "296d5c8913271ef3bd696fd46d998711",
  "translation_date": "2025-05-20T21:35:49+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "th"
}
-->
# บทเรียนจากผู้ใช้งานกลุ่มแรก

## ภาพรวม

บทเรียนนี้จะสำรวจว่าผู้ใช้งานกลุ่มแรกได้นำ Model Context Protocol (MCP) มาใช้แก้ไขปัญหาในโลกจริงและขับเคลื่อนนวัตกรรมในหลากหลายอุตสาหกรรมอย่างไร ผ่านกรณีศึกษาละเอียดและโครงการปฏิบัติจริง คุณจะได้เห็นว่า MCP ช่วยให้การรวม AI ที่เป็นมาตรฐาน ปลอดภัย และปรับขนาดได้อย่างไร—เชื่อมต่อโมเดลภาษาขนาดใหญ่ เครื่องมือ และข้อมูลองค์กรในกรอบงานเดียว คุณจะได้รับประสบการณ์จริงในการออกแบบและสร้างโซลูชันที่ใช้ MCP เรียนรู้จากรูปแบบการใช้งานที่พิสูจน์แล้ว และค้นพบแนวทางปฏิบัติที่ดีที่สุดสำหรับการนำ MCP ไปใช้ในสภาพแวดล้อมการผลิต บทเรียนยังเน้นถึงแนวโน้มที่กำลังเกิดขึ้น ทิศทางในอนาคต และแหล่งข้อมูลโอเพนซอร์สที่จะช่วยให้คุณก้าวนำหน้าทางเทคโนโลยี MCP และระบบนิเวศที่กำลังพัฒนา

## วัตถุประสงค์การเรียนรู้

- วิเคราะห์การใช้งาน MCP ในโลกจริงในอุตสาหกรรมต่างๆ
- ออกแบบและสร้างแอปพลิเคชันที่ใช้ MCP อย่างครบถ้วน
- สำรวจแนวโน้มที่เกิดขึ้นและทิศทางในอนาคตของเทคโนโลยี MCP
- นำแนวทางปฏิบัติที่ดีที่สุดไปใช้ในสถานการณ์การพัฒนาจริง

## การใช้งาน MCP ในโลกจริง

### กรณีศึกษา 1: ระบบอัตโนมัติสนับสนุนลูกค้าองค์กร

บริษัทข้ามชาติได้นำโซลูชันที่ใช้ MCP มาใช้เพื่อทำให้การโต้ตอบ AI ในระบบสนับสนุนลูกค้าของพวกเขามีมาตรฐานเดียวกัน ซึ่งช่วยให้พวกเขา:

- สร้างอินเทอร์เฟซแบบรวมศูนย์สำหรับผู้ให้บริการ LLM หลายราย
- รักษาการจัดการ prompt ที่สม่ำเสมอในแต่ละแผนก
- นำมาตรการรักษาความปลอดภัยและการปฏิบัติตามข้อกำหนดที่เข้มงวดมาใช้
- สลับใช้โมเดล AI ต่างๆ ได้ง่ายตามความต้องการเฉพาะ

**การใช้งานเชิงเทคนิค:**  
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

**ผลลัพธ์:** ลดต้นทุนโมเดลลง 30% ปรับปรุงความสม่ำเสมอในการตอบกลับ 45% และเสริมความเข้มงวดในการปฏิบัติตามข้อกำหนดทั่วโลก

### กรณีศึกษา 2: ผู้ช่วยวินิจฉัยทางการแพทย์

ผู้ให้บริการด้านสุขภาพได้พัฒนาโครงสร้างพื้นฐาน MCP เพื่อผสานรวมโมเดล AI ทางการแพทย์เฉพาะทางหลายตัวพร้อมกับรักษาความปลอดภัยข้อมูลผู้ป่วยที่ละเอียดอ่อน:

- สลับใช้งานระหว่างโมเดลแพทย์ทั่วไปและเฉพาะทางได้อย่างราบรื่น
- ควบคุมความเป็นส่วนตัวอย่างเข้มงวดและมีบันทึกการตรวจสอบ
- ผสานรวมกับระบบ Electronic Health Record (EHR) ที่มีอยู่
- จัดการ prompt สำหรับคำศัพท์ทางการแพทย์อย่างสม่ำเสมอ

**การใช้งานเชิงเทคนิค:**  
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

**ผลลัพธ์:** ปรับปรุงคำแนะนำการวินิจฉัยสำหรับแพทย์ พร้อมรักษาความสอดคล้องตาม HIPAA อย่างเต็มรูปแบบ และลดการสลับบริบทระหว่างระบบอย่างมีนัยสำคัญ

### กรณีศึกษา 3: การวิเคราะห์ความเสี่ยงในบริการทางการเงิน

สถาบันการเงินได้นำ MCP มาใช้เพื่อทำให้กระบวนการวิเคราะห์ความเสี่ยงในแต่ละแผนกมีมาตรฐานเดียวกัน:

- สร้างอินเทอร์เฟซแบบรวมศูนย์สำหรับโมเดลความเสี่ยงเครดิต การตรวจจับการฉ้อโกง และความเสี่ยงการลงทุน
- ใช้มาตรการควบคุมการเข้าถึงและการจัดการเวอร์ชันโมเดลอย่างเข้มงวด
- รับประกันการตรวจสอบย้อนกลับของคำแนะนำ AI ทั้งหมด
- รักษารูปแบบข้อมูลที่สอดคล้องกันในระบบที่หลากหลาย

**การใช้งานเชิงเทคนิค:**  
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

**ผลลัพธ์:** ปรับปรุงการปฏิบัติตามกฎระเบียบ เร่งรอบการเปิดตัวโมเดลเร็วขึ้น 40% และเพิ่มความสม่ำเสมอในการประเมินความเสี่ยงในแต่ละแผนก

### กรณีศึกษา 4: Microsoft Playwright MCP Server สำหรับการทำงานอัตโนมัติบนเบราว์เซอร์

Microsoft ได้พัฒนา [Playwright MCP server](https://github.com/microsoft/playwright-mcp) เพื่อเปิดใช้งานการทำงานอัตโนมัติบนเบราว์เซอร์ที่ปลอดภัยและมีมาตรฐานผ่าน Model Context Protocol โซลูชันนี้ช่วยให้เอเจนต์ AI และ LLM สามารถโต้ตอบกับเว็บเบราว์เซอร์ได้อย่างควบคุม ตรวจสอบได้ และขยายได้—รองรับกรณีใช้งานเช่น การทดสอบเว็บอัตโนมัติ การดึงข้อมูล และเวิร์กโฟลว์แบบครบวงจร

- เปิดเผยความสามารถการทำงานอัตโนมัติบนเบราว์เซอร์ (เช่น การนำทาง กรอกแบบฟอร์ม ถ่ายภาพหน้าจอ ฯลฯ) ในรูปแบบเครื่องมือ MCP
- ใช้มาตรการควบคุมการเข้าถึงและ sandboxing อย่างเข้มงวดเพื่อป้องกันการกระทำที่ไม่ได้รับอนุญาต
- จัดทำบันทึกตรวจสอบรายละเอียดสำหรับการโต้ตอบบนเบราว์เซอร์ทั้งหมด
- รองรับการผสานรวมกับ Azure OpenAI และผู้ให้บริการ LLM อื่นๆ สำหรับการทำงานอัตโนมัติที่ขับเคลื่อนด้วยเอเจนต์

**การใช้งานเชิงเทคนิค:**  
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
- ลดความพยายามในการทดสอบด้วยมือและเพิ่มความครอบคลุมของการทดสอบสำหรับเว็บแอปพลิเคชัน  
- มอบกรอบงานที่นำกลับมาใช้ใหม่และขยายได้สำหรับการผสานรวมเครื่องมือบนเบราว์เซอร์ในสภาพแวดล้อมองค์กร  

**แหล่งอ้างอิง:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### กรณีศึกษา 5: Azure MCP – Model Context Protocol ระดับองค์กรในรูปแบบบริการ

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) คือการใช้งาน Model Context Protocol ระดับองค์กรที่ Microsoft จัดการให้ เป็นบริการคลาวด์ที่มีความสามารถในการปรับขนาด ปลอดภัย และสอดคล้องตามข้อกำหนด Azure MCP ช่วยให้องค์กรสามารถเปิดใช้ จัดการ และผสานรวม MCP server กับ Azure AI, ข้อมูล และบริการด้านความปลอดภัยได้อย่างรวดเร็ว ลดภาระงานและเร่งการนำ AI ไปใช้

- โฮสต์ MCP server แบบจัดการเต็มรูปแบบ พร้อมความสามารถในการปรับขนาด การตรวจสอบ และความปลอดภัยในตัว
- ผสานรวมแบบเนทีฟกับ Azure OpenAI, Azure AI Search และบริการ Azure อื่นๆ
- การพิสูจน์ตัวตนและการอนุญาตระดับองค์กรผ่าน Microsoft Entra ID
- รองรับเครื่องมือที่กำหนดเอง, แม่แบบ prompt และตัวเชื่อมต่อทรัพยากร
- สอดคล้องกับข้อกำหนดด้านความปลอดภัยและกฎระเบียบขององค์กร

**การใช้งานเชิงเทคนิค:**  
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
- ลดเวลาสู่คุณค่าสำหรับโครงการ AI ระดับองค์กรโดยการให้แพลตฟอร์ม MCP server ที่พร้อมใช้งานและสอดคล้อง  
- ทำให้ง่ายขึ้นในการผสานรวม LLM, เครื่องมือ และแหล่งข้อมูลองค์กร  
- เพิ่มความปลอดภัย การสังเกต และประสิทธิภาพการดำเนินงานสำหรับงาน MCP  

**แหล่งอ้างอิง:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## กรณีศึกษา 6: NLWeb

MCP (Model Context Protocol) เป็นโพรโทคอลที่กำลังเกิดขึ้นสำหรับแชทบอทและผู้ช่วย AI ในการโต้ตอบกับเครื่องมือต่างๆ ทุกอินสแตนซ์ของ NLWeb ก็เป็น MCP server ที่รองรับวิธีหลักหนึ่งคือ ask ซึ่งใช้สำหรับถามคำถามกับเว็บไซต์ด้วยภาษาธรรมชาติ คำตอบที่ส่งกลับใช้ schema.org ซึ่งเป็นศัพท์ที่ใช้กันอย่างแพร่หลายสำหรับอธิบายข้อมูลเว็บ กล่าวโดยง่าย MCP ก็คือ NLWeb ในแบบเดียวกับที่ Http เป็นต่อ HTML NLWeb รวมโพรโทคอล รูปแบบ Schema.org และตัวอย่างโค้ดเพื่อช่วยให้เว็บไซต์สร้างจุดเชื่อมต่อเหล่านี้ได้อย่างรวดเร็ว โดยเป็นประโยชน์ทั้งกับมนุษย์ผ่านอินเทอร์เฟซสนทนา และกับเครื่องจักรผ่านการโต้ตอบระหว่างเอเจนต์ในรูปแบบธรรมชาติ

NLWeb มีส่วนประกอบสองส่วนที่แตกต่างกัน  
- โพรโทคอลที่ง่ายมากสำหรับเริ่มต้น ใช้สำหรับเชื่อมต่อกับเว็บไซต์ด้วยภาษาธรรมชาติและรูปแบบที่ใช้ json และ schema.org สำหรับคำตอบ ดูเอกสาร REST API เพื่อรายละเอียดเพิ่มเติม  
- การใช้งานง่ายของ (1) ที่ใช้มาร์กอัปที่มีอยู่แล้วสำหรับเว็บไซต์ที่สามารถนับเป็นรายการของรายการ (สินค้า สูตรอาหาร สถานที่ท่องเที่ยว รีวิว ฯลฯ) พร้อมชุดวิดเจ็ตอินเทอร์เฟซผู้ใช้ ช่วยให้เว็บไซต์สามารถให้บริการอินเทอร์เฟซสนทนาแก่เนื้อหาได้อย่างง่ายดาย ดูเอกสาร Life of a chat query เพื่อดูรายละเอียดการทำงาน

**แหล่งอ้างอิง:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### กรณีศึกษา 7: MCP สำหรับ Foundry – การผสานรวม Azure AI Agents

เซิร์ฟเวอร์ Azure AI Foundry MCP แสดงให้เห็นว่า MCP สามารถใช้ในการจัดการและควบคุมเอเจนต์ AI และเวิร์กโฟลว์ในสภาพแวดล้อมองค์กรได้อย่างไร โดยการผสาน MCP กับ Azure AI Foundry องค์กรสามารถทำให้การโต้ตอบของเอเจนต์มีมาตรฐาน ใช้ประโยชน์จากการจัดการเวิร์กโฟลว์ของ Foundry และรับประกันการเปิดใช้งานที่ปลอดภัยและปรับขนาดได้ วิธีนี้ช่วยให้การสร้างต้นแบบรวดเร็ว การตรวจสอบที่มั่นคง และการผสานรวมกับบริการ Azure AI อย่างราบรื่น รองรับสถานการณ์ขั้นสูง เช่น การจัดการความรู้และการประเมินเอเจนต์ นักพัฒนาจะได้รับอินเทอร์เฟซแบบรวมสำหรับสร้าง เปิดใช้ และตรวจสอบสายงานเอเจนต์ ขณะที่ทีมไอทีได้รับการปรับปรุงด้านความปลอดภัย การปฏิบัติตามข้อกำหนด และประสิทธิภาพการดำเนินงาน โซลูชันนี้เหมาะสำหรับองค์กรที่ต้องการเร่งการนำ AI ไปใช้และควบคุมกระบวนการที่ซับซ้อนซึ่งขับเคลื่อนด้วยเอเจนต์

**แหล่งอ้างอิง:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### กรณีศึกษา 8: Foundry MCP Playground – การทดลองและสร้างต้นแบบ

Foundry MCP Playground เป็นสภาพแวดล้อมพร้อมใช้สำหรับทดลองกับ MCP server และการผสานรวม Azure AI Foundry นักพัฒนาสามารถสร้างต้นแบบ ทดสอบ และประเมินโมเดล AI และเวิร์กโฟลว์เอเจนต์ได้อย่างรวดเร็วโดยใช้ทรัพยากรจาก Azure AI Foundry Catalog และ Labs สนามเด็กเล่นนี้ช่วยให้การตั้งค่าง่ายขึ้น มีโปรเจกต์ตัวอย่าง และสนับสนุนการพัฒนาร่วมกัน ทำให้ง่ายต่อการสำรวจแนวทางปฏิบัติที่ดีที่สุดและสถานการณ์ใหม่ๆ โดยใช้ต้นทุนต่ำ เหมาะอย่างยิ่งสำหรับทีมที่ต้องการตรวจสอบแนวคิด แชร์การทดลอง และเร่งการเรียนรู้โดยไม่ต้องใช้โครงสร้างพื้นฐานที่ซับซ้อน ด้วยการลดอุปสรรคในการเริ่มต้น สนามเด็กเล่นช่วยส่งเสริมนวัตกรรมและการมีส่วนร่วมของชุมชนในระบบนิเวศ MCP และ Azure AI Foundry

**แหล่งอ้างอิง:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

## โครงการปฏิบัติจริง

### โครงการ 1: สร้าง MCP Server ที่รองรับผู้ให้บริการหลายราย

**วัตถุประสงค์:** สร้าง MCP server ที่สามารถส่งคำขอไปยังผู้ให้บริการโมเดล AI หลายรายตามเกณฑ์ที่กำหนด

**ข้อกำหนด:**  
- รองรับผู้ให้บริการโมเดลอย่างน้อยสามราย (เช่น OpenAI, Anthropic, โมเดลในเครื่อง)  
- นำกลไกการกำหนดเส้นทางตามเมตาดาต้าของคำขอมาใช้  
- สร้างระบบกำหนดค่าสำหรับจัดการข้อมูลรับรองของผู้ให้บริการ  
- เพิ่มการแคชเพื่อเพิ่มประสิทธิภาพและลดต้นทุน  
- สร้างแดชบอร์ดง่ายๆ สำหรับตรวจสอบการใช้งาน

**ขั้นตอนการดำเนินงาน:**  
1. ตั้งค่าโครงสร้างพื้นฐาน MCP server เบื้องต้น  
2. พัฒนาอแดปเตอร์ผู้ให้บริการสำหรับแต่ละบริการโมเดล AI  
3. สร้างตรรกะการกำหนดเส้นทางตามคุณสมบัติคำขอ  
4. เพิ่มกลไกแคชสำหรับคำขอที่ใช้บ่อย  
5. พัฒนาแดชบอร์ดตรวจสอบ  
6. ทดสอบด้วยรูปแบบคำขอต่างๆ

**เทคโนโลยี:** เลือกจาก Python (.NET/Java/Python ตามความชอบ), Redis สำหรับแคช, และเว็บเฟรมเวิร์กง่ายๆ สำหรับแดชบอร์ด

### โครงการ 2: ระบบจัดการ Prompt ระดับองค์กร

**วัตถุประสงค์:** พัฒนาระบบที่ใช้ MCP สำหรับจัดการ การเวอร์ชัน และการเปิดใช้แม่แบบ prompt ในองค์กร

**ข้อกำหนด:**  
- สร้างที่เก็บแม่แบบ prompt แบบรวมศูนย์  
- นำระบบเวอร์ชันและเวิร์กโฟลว์อนุมัติมาใช้  
- สร้างความสามารถในการทดสอบแม่แบบด้วยข้อมูลตัวอย่าง  
- พัฒนาการควบคุมการเข้าถึงตามบทบาท  
- สร้าง API สำหรับดึงและเปิดใช้แม่แบบ

**ขั้นตอนการดำเนินงาน:**  
1. ออกแบบสคีมาฐานข้อมูลสำหรับเก็บแม่แบบ  
2. สร้าง API หลักสำหรับ CRUD แม่แบบ  
3. นำระบบเวอร์ชันมาใช้  
4. พัฒนาเวิร์กโฟลว์อนุมัติ  
5. สร้างกรอบการทดสอบ  
6. สร้างอินเทอร์เฟซเว็บง่ายๆ สำหรับการจัดการ  
7. ผสานรวมกับ MCP server

**เทคโนโลยี:** เลือกเฟรมเวิร์กแบ็กเอนด์ ฐานข้อมูล SQL หรือ NoSQL และเฟรมเวิร์กหน้าเว็บตามที่ต้องการ

### โครงการ 3: แพลตฟอร์มสร้างเนื้อหาที่ใช้ MCP

**วัตถุประสงค์:** สร้างแพลตฟอร์มสร้างเนื้อหาที่ใช้ MCP เพื่อให้ผลลัพธ์ที่สม่ำเสมอในเนื้อหาหลากหลายประเภท

**ข้อกำหนด:**  
- รองรับหลายรูปแบบเนื้อหา (บทความบล็อก โซเชียลมีเดีย คัดลอกการตลาด)  
- นำการสร้างเนื้อหาจากแม่แบบพร้อมตัวเลือกปรับแต่งมาใช้  
- สร้างระบบรีวิวและข้อเสนอแนะเนื้อหา  
- ติดตามตัวชี้วัดประสิทธิภาพเนื้อหา  
- รองรับการเวอร์ชันและการปรับปรุงเนื้อหา

**ขั้นตอนการดำเนินงาน:**  
1. ตั้งค่าโครงสร้างพื้นฐาน MCP client  
2. สร้างแม่แบบสำหรับเนื้อหาประเภทต่างๆ  
3. สร้างสายงานการสร้างเนื้อหา  
4. นำระบบรีวิวมาใช้  
5. พัฒนาระบบติดตามตัวชี้วัด  
6. สร้างอินเทอร์เฟซผู้ใช้สำหรับจัดการแม่แบบและสร้างเนื้อหา

**เทคโนโลยี:** เลือกภาษาโปรแกรม เว็บเฟรมเวิร์
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
2. เลือกหนึ่งในไอเดียโครงการและจัดทำข้อกำหนดทางเทคนิคอย่างละเอียด
3. ศึกษาอุตสาหกรรมที่ไม่ได้ครอบคลุมในกรณีศึกษา และร่างแนวทางที่ MCP สามารถแก้ไขปัญหาเฉพาะได้
4. สำรวจทิศทางในอนาคตหนึ่งทางและสร้างแนวคิดสำหรับส่วนขยาย MCP ใหม่เพื่อรองรับ

ถัดไป: [Best Practices](../08-BestPractices/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาด้วย AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้มีความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลสำคัญแนะนำให้ใช้บริการแปลโดยผู้เชี่ยวชาญมนุษย์ เราจะไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความที่ผิดพลาดใด ๆ ที่เกิดจากการใช้การแปลนี้