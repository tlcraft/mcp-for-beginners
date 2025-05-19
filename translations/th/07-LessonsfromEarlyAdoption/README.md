<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "344a126b620ff7997158542fd31be6a4",
  "translation_date": "2025-05-19T22:03:49+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "th"
}
-->
# บทเรียนจากผู้ใช้รายแรก

## ภาพรวม

บทเรียนนี้สำรวจว่าผู้ใช้รายแรกได้นำ Model Context Protocol (MCP) มาใช้แก้ไขปัญหาในโลกจริงและขับเคลื่อนนวัตกรรมในหลายอุตสาหกรรมอย่างไร ผ่านกรณีศึกษาละเอียดและโครงการลงมือทำ คุณจะได้เห็นว่า MCP ช่วยให้การรวม AI เป็นมาตรฐาน ปลอดภัย และขยายผลได้อย่างไร—เชื่อมต่อโมเดลภาษาใหญ่ เครื่องมือ และข้อมูลองค์กรในกรอบงานเดียวกัน คุณจะได้รับประสบการณ์จริงในการออกแบบและสร้างโซลูชันที่ใช้ MCP เรียนรู้รูปแบบการใช้งานที่พิสูจน์แล้ว และค้นพบแนวทางปฏิบัติที่ดีที่สุดสำหรับการนำ MCP ไปใช้ในสภาพแวดล้อมการผลิต บทเรียนยังเน้นเทรนด์ที่เกิดขึ้น ทิศทางในอนาคต และแหล่งข้อมูลโอเพ่นซอร์สเพื่อช่วยให้คุณก้าวนำเทคโนโลยี MCP และระบบนิเวศที่พัฒนาอย่างต่อเนื่อง

## วัตถุประสงค์การเรียนรู้

- วิเคราะห์การใช้งาน MCP ในโลกจริงในหลายอุตสาหกรรม
- ออกแบบและสร้างแอปพลิเคชันที่ใช้ MCP อย่างครบวงจร
- สำรวจเทรนด์ใหม่และทิศทางในอนาคตของเทคโนโลยี MCP
- นำแนวทางปฏิบัติที่ดีที่สุดไปใช้ในสถานการณ์พัฒนาจริง

## การใช้งาน MCP ในโลกจริง

### กรณีศึกษา 1: ระบบอัตโนมัติสนับสนุนลูกค้าองค์กร

บริษัทข้ามชาติได้นำโซลูชันที่ใช้ MCP มาใช้เพื่อทำให้การโต้ตอบ AI ในระบบสนับสนุนลูกค้าเป็นมาตรฐานเดียวกัน ซึ่งช่วยให้พวกเขา:

- สร้างอินเทอร์เฟซเดียวสำหรับผู้ให้บริการ LLM หลายราย
- รักษาการจัดการ prompt ที่สอดคล้องกันในทุกแผนก
- ใช้มาตรการความปลอดภัยและการปฏิบัติตามกฎระเบียบอย่างเข้มงวด
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

**ผลลัพธ์:** ลดค่าใช้จ่ายโมเดลลง 30%, ปรับปรุงความสม่ำเสมอในการตอบกลับ 45% และเพิ่มการปฏิบัติตามกฎระเบียบทั่วโลก

### กรณีศึกษา 2: ผู้ช่วยวินิจฉัยทางการแพทย์

ผู้ให้บริการด้านสุขภาพพัฒนาโครงสร้างพื้นฐาน MCP เพื่อรวมโมเดล AI ทางการแพทย์เฉพาะทางหลายตัวในขณะที่รักษาความปลอดภัยข้อมูลผู้ป่วยที่ละเอียดอ่อน:

- สลับใช้โมเดลแพทย์ทั่วไปและเฉพาะทางได้อย่างราบรื่น
- ควบคุมความเป็นส่วนตัวอย่างเข้มงวดและมีบันทึกตรวจสอบ
- รวมกับระบบบันทึกสุขภาพอิเล็กทรอนิกส์ (EHR) ที่มีอยู่
- จัดการ prompt ให้สอดคล้องกับศัพท์ทางการแพทย์

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

**ผลลัพธ์:** เสนอคำแนะนำวินิจฉัยที่ดีขึ้นแก่แพทย์ พร้อมรักษาการปฏิบัติตาม HIPAA อย่างเต็มที่และลดเวลาสลับบริบทระหว่างระบบอย่างมีนัยสำคัญ

### กรณีศึกษา 3: การวิเคราะห์ความเสี่ยงบริการทางการเงิน

สถาบันการเงินนำ MCP มาใช้เพื่อทำให้กระบวนการวิเคราะห์ความเสี่ยงในแผนกต่างๆ เป็นมาตรฐานเดียวกัน:

- สร้างอินเทอร์เฟซเดียวสำหรับโมเดลวิเคราะห์ความเสี่ยงเครดิต การตรวจจับการฉ้อโกง และความเสี่ยงการลงทุน
- ใช้มาตรการควบคุมการเข้าถึงและเวอร์ชันของโมเดลอย่างเข้มงวด
- รับประกันการตรวจสอบย้อนหลังได้ของคำแนะนำ AI ทั้งหมด
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

**ผลลัพธ์:** ปรับปรุงการปฏิบัติตามกฎระเบียบ, ลดเวลาการเปิดตัวโมเดลลง 40%, และเพิ่มความสม่ำเสมอในการประเมินความเสี่ยงในทุกแผนก

### กรณีศึกษา 4: Microsoft Playwright MCP Server สำหรับการทำงานอัตโนมัติบนเบราว์เซอร์

Microsoft พัฒนา [Playwright MCP server](https://github.com/microsoft/playwright-mcp) เพื่อให้สามารถทำงานอัตโนมัติบนเบราว์เซอร์ได้อย่างปลอดภัยและเป็นมาตรฐานผ่าน Model Context Protocol โซลูชันนี้ช่วยให้เอเจนต์ AI และ LLM โต้ตอบกับเว็บเบราว์เซอร์ได้อย่างควบคุม ตรวจสอบได้ และขยายผลได้—รองรับกรณีใช้งานเช่น การทดสอบเว็บอัตโนมัติ การดึงข้อมูล และเวิร์กโฟลว์แบบครบวงจร

- เปิดเผยความสามารถการทำงานอัตโนมัติบนเบราว์เซอร์ (การนำทาง กรอกแบบฟอร์ม ถ่ายภาพหน้าจอ ฯลฯ) ในรูปแบบเครื่องมือ MCP
- ใช้มาตรการควบคุมการเข้าถึงและ sandboxing อย่างเข้มงวดเพื่อป้องกันการกระทำที่ไม่ได้รับอนุญาต
- ให้บันทึกตรวจสอบรายละเอียดสำหรับการโต้ตอบกับเบราว์เซอร์ทั้งหมด
- รองรับการรวมกับ Azure OpenAI และผู้ให้บริการ LLM อื่นๆ สำหรับการทำงานอัตโนมัติที่ขับเคลื่อนโดยเอเจนต์

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
- ลดความพยายามในการทดสอบด้วยมือและปรับปรุงความครอบคลุมการทดสอบสำหรับเว็บแอป  
- ให้กรอบงานที่นำกลับมาใช้ใหม่และขยายผลได้สำหรับการรวมเครื่องมือบนเบราว์เซอร์ในสภาพแวดล้อมองค์กร

**แหล่งอ้างอิง:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### กรณีศึกษา 5: Azure MCP – Model Context Protocol ระดับองค์กรในรูปแบบบริการ

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) คือการใช้งาน Model Context Protocol ระดับองค์กรที่ Microsoft บริหารจัดการและออกแบบมาเพื่อให้บริการ MCP server ที่ขยายได้ ปลอดภัย และปฏิบัติตามกฎระเบียบในรูปแบบบริการคลาวด์ Azure MCP ช่วยให้องค์กรสามารถเปิดตัว จัดการ และรวม MCP server กับบริการ Azure AI, ข้อมูล และความปลอดภัยได้อย่างรวดเร็ว ลดภาระการดำเนินงานและเร่งการนำ AI มาใช้

- โฮสต์ MCP server ที่บริหารจัดการเต็มรูปแบบ พร้อมฟีเจอร์สเกล มอนิเตอร์ และความปลอดภัยในตัว
- รวมเนทีฟกับ Azure OpenAI, Azure AI Search และบริการ Azure อื่นๆ
- การยืนยันตัวตนและการอนุญาตระดับองค์กรผ่าน Microsoft Entra ID
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
- ลดเวลาสู่คุณค่าสำหรับโครงการ AI ระดับองค์กรโดยมีแพลตฟอร์ม MCP server ที่พร้อมใช้งานและปฏิบัติตามข้อกำหนด  
- ทำให้ง่ายขึ้นในการรวม LLM, เครื่องมือ และแหล่งข้อมูลองค์กร  
- เพิ่มความปลอดภัย การตรวจสอบ และประสิทธิภาพในการดำเนินงานสำหรับงาน MCP  

**แหล่งอ้างอิง:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## กรณีศึกษา 6: NLWeb  
MCP (Model Context Protocol) คือโปรโตคอลที่กำลังเกิดขึ้นสำหรับแชทบอทและผู้ช่วย AI ในการโต้ตอบกับเครื่องมือต่างๆ ทุกอินสแตนซ์ของ NLWeb ยังเป็น MCP server ซึ่งรองรับเมธอดหลักหนึ่งเมธอดคือ ask ใช้สำหรับถามคำถามกับเว็บไซต์ด้วยภาษาธรรมชาติ คำตอบที่ได้รับใช้ schema.org ซึ่งเป็นคำศัพท์ที่ใช้กันอย่างแพร่หลายสำหรับอธิบายข้อมูลเว็บ พูดง่ายๆ ก็คือ MCP เปรียบเสมือน NLWeb ในแบบที่ Http เป็นกับ HTML NLWeb รวมโปรโตคอล รูปแบบ Schema.org และตัวอย่างโค้ดเพื่อช่วยให้เว็บไซต์สร้างจุดเชื่อมต่อเหล่านี้ได้อย่างรวดเร็ว เป็นประโยชน์ทั้งกับมนุษย์ผ่านอินเทอร์เฟซสนทนาและเครื่องจักรผ่านการโต้ตอบแบบเอเจนต์ต่อเอเจนต์

NLWeb ประกอบด้วยสองส่วนที่แตกต่างกัน  
- โปรโตคอลที่เรียบง่ายสำหรับเริ่มต้น ใช้เชื่อมต่อกับเว็บไซต์ด้วยภาษาธรรมชาติและรูปแบบที่ใช้ json และ schema.org สำหรับคำตอบ ดูเอกสาร REST API สำหรับรายละเอียดเพิ่มเติม  
- การใช้งานที่ตรงไปตรงมาของ (1) ที่ใช้มาร์กอัปที่มีอยู่ สำหรับเว็บไซต์ที่สามารถสรุปเป็นรายการของไอเท็ม (สินค้า สูตรอาหาร สถานที่ท่องเที่ยว รีวิว ฯลฯ) พร้อมกับชุดวิดเจ็ตอินเทอร์เฟซผู้ใช้ เว็บไซต์สามารถให้บริการอินเทอร์เฟซสนทนาแก่เนื้อหาของตนได้อย่างง่ายดาย ดูเอกสาร Life of a chat query สำหรับรายละเอียดเพิ่มเติมเกี่ยวกับวิธีการทำงานนี้

**แหล่งอ้างอิง:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

## โครงการลงมือทำ

### โครงการ 1: สร้าง MCP Server รองรับผู้ให้บริการหลายราย

**วัตถุประสงค์:** สร้าง MCP server ที่สามารถส่งคำขอไปยังผู้ให้บริการโมเดล AI หลายรายตามเกณฑ์ที่กำหนด

**ข้อกำหนด:**  
- รองรับผู้ให้บริการโมเดลอย่างน้อยสามราย (เช่น OpenAI, Anthropic, โมเดลในเครื่อง)  
- ใช้กลไกการส่งคำขอตามข้อมูลเมตาของคำขอ  
- สร้างระบบกำหนดค่าสำหรับจัดการข้อมูลรับรองของผู้ให้บริการ  
- เพิ่มระบบแคชเพื่อเพิ่มประสิทธิภาพและลดค่าใช้จ่าย  
- สร้างแดชบอร์ดง่ายๆ สำหรับติดตามการใช้งาน

**ขั้นตอนการใช้งาน:**  
1. ตั้งค่าโครงสร้างพื้นฐาน MCP server พื้นฐาน  
2. พัฒนาตัวปรับแต่งผู้ให้บริการสำหรับแต่ละบริการโมเดล AI  
3. สร้างตรรกะการส่งคำขอตามคุณสมบัติของคำขอ  
4. เพิ่มกลไกแคชสำหรับคำขอที่เกิดขึ้นบ่อย  
5. พัฒนาแดชบอร์ดติดตามผล  
6. ทดสอบด้วยรูปแบบคำขอต่างๆ

**เทคโนโลยี:** เลือกใช้ Python (.NET/Java/Python ตามที่คุณถนัด), Redis สำหรับแคช และเว็บเฟรมเวิร์กง่ายๆ สำหรับแดชบอร์ด

### โครงการ 2: ระบบจัดการ Prompt สำหรับองค์กร

**วัตถุประสงค์:** พัฒนาระบบที่ใช้ MCP สำหรับจัดการ เวอร์ชัน และปรับใช้เทมเพลต prompt ในองค์กร

**ข้อกำหนด:**  
- สร้างที่เก็บเทมเพลต prompt แบบรวมศูนย์  
- ใช้ระบบเวอร์ชันและเวิร์กโฟลว์การอนุมัติ  
- สร้างความสามารถในการทดสอบเทมเพลตด้วยข้อมูลตัวอย่าง  
- พัฒนาการควบคุมการเข้าถึงตามบทบาท  
- สร้าง API สำหรับดึงข้อมูลและปรับใช้เทมเพลต

**ขั้นตอนการใช้งาน:**  
1. ออกแบบโครงสร้างฐานข้อมูลสำหรับเก็บเทมเพลต  
2. สร้าง API หลักสำหรับการสร้าง อ่าน อัปเดต และลบเทมเพลต  
3. พัฒนาระบบเวอร์ชัน  
4. สร้างเวิร์กโฟลว์การอนุมัติ  
5. พัฒนากรอบงานทดสอบ  
6. สร้างอินเทอร์เฟซเว็บง่ายๆ สำหรับการจัดการ  
7. รวมเข้ากับ MCP server

**เทคโนโลยี:** เลือกเฟรมเวิร์กแบ็กเอนด์, ฐานข้อมูล SQL หรือ NoSQL และเฟรมเวิร์กฟรอนต์เอนด์สำหรับอินเทอร์เฟซจัดการตามที่ต้องการ

### โครงการ 3: แพลตฟอร์มสร้างเนื้อหาที่ใช้ MCP

**วัตถุประสงค์:** สร้างแพลตฟอร์มสร้างเนื้อหาที่ใช้ MCP เพื่อให้ผลลัพธ์ที่สม่ำเสมอในหลายรูปแบบเนื้อหา

**ข้อกำหนด:**  
- รองรับหลายรูปแบบเนื้อหา (บทความบล็อก, โซเชียลมีเดีย, ข้อความการตลาด)  
- ใช้การสร้างเนื้อหาจากเทมเพลตพร้อมตัวเลือกปรับแต่ง  
- สร้างระบบทบทวนและให้ข้อเสนอแนะเนื้อหา  
- ติดตามเมตริกประสิทธิภาพเนื้อหา  
- รองรับการเวอร์ชันและการปรับปรุงเนื้อหา

**ขั้นตอนการใช้งาน:**  
1. ตั้งค่าโครงสร้างพื้นฐาน MCP client  
2. สร้างเทมเพลตสำหรับเนื้อหาหลายประเภท  
3. สร้างสายการผลิตเนื้อหา  
4. พัฒนาระบบทบทวน  
5. สร้างระบบติดตามเมตริก  
6. สร้างอินเทอร์เฟซผู้ใช้สำหรับการจัดการเทมเพลตและการสร้างเนื้อหา

**เทคโนโลยี:** เลือกภาษาโปรแกรม เว็บเฟรมเวิร์ก และระบบฐานข้อมูลที่คุณชอบ

## ทิศทางในอนาคตของเทคโนโลยี MCP

### เทรนด์ที่เกิดขึ้น

1. **Multi-Modal MCP**  
   - ขยาย MCP เพื่อทำให้การโต้ตอบกับโมเดลภาพ เสียง และวิดีโอเป็นมาตรฐาน  
   - พัฒนาความสามารถในการให้เหตุผลข้ามโมดัล  
   - รูปแบบ prompt มาตรฐานสำหรับแต่ละโหมด

2. **โครงสร้างพื้นฐาน MCP แบบกระจาย**  
   - เครือข่าย MCP ที่กระจายตัวเพื่อแชร์ทรัพยากรระหว่างองค์กร  
   - โปรโตคอลมาตรฐานสำหรับการแชร์โมเดลอย่างปลอดภัย  
   - เทคนิคการคำนวณที่รักษาความเป็นส่วนตัว

3. **ตลาด MCP**  
   - ระบบนิเวศสำหรับการแชร์และสร้างรายได้จากเทมเพลตและปลั๊กอิน MCP  
   - กระบวนการประกันคุณภาพและการรับรอง  
   - การรวมกับตลาดโมเดล

4. **MCP สำหรับ Edge Computing**  
   - ปรับมาตรฐาน MCP สำหรับอุปกรณ์ Edge ที่มีทรัพยากรจำกัด  
   - โปรโตคอลที่เหมาะสมกับสภาพแวดล้อมแบนด์วิดท์ต่ำ  
   - การใช้งาน MCP เฉพาะสำหรับระบบนิเวศ IoT

5. **กรอบกฎระเบียบ**  
   - พัฒนา MCP ให้สอดคล้องกับกฎระเบียบ  
   - ระบบบันทึกตรวจสอบและอินเทอร์เฟซอธิบายผลที่เป็นมาตรฐาน  
   - รวมกับกรอบการกำกับดูแล AI ที่เกิดขึ้นใหม่

### โซลูชัน MCP จาก Microsoft

Microsoft และ Azure ได้พัฒนาที่เก็บโอเพ่นซอร์สหลายแห่งเพื่อช่วยนักพัฒนาใช้งาน MCP ในหลายสถานการณ์:

#### Microsoft Organization  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - MCP server สำหรับ Playwright เพื่อการทำงานอัตโนมัติและทดสอบบนเบราว์เซอร์  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - การใช้งาน MCP server สำหรับ OneDrive เพื่อการทดสอบในเครื่องและการมีส่วนร่วมของชุมชน  
3. [NLWeb](https://github.com/microsoft/NlWeb) - ชุดโปรโตคอลเปิดและเครื่องมือโอเพ่นซอร์สที่เกี่ยวข้อง เน้นการสร้างชั้นฐานสำหรับ AI Web  

#### Azure-Samples Organization  
1. [mcp](https://github.com/Azure-Samples/mcp) - ตัวอย่าง เครื่องมือ และแหล่งข้อมูลสำหรับสร้างและรวม MCP server บน Azure ด้วยหลายภาษา  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - MCP server ตัวอย่างสำหรับการยืนยันตัวตนตามสเปค Model Context Protocol ปัจจุบัน  
3. [remote-mcp-functions](https://github.com
- [Remote MCP Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Remote MCP Functions .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Remote MCP Functions TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

## แบบฝึกหัด

1. วิเคราะห์กรณีศึกษาหนึ่งและเสนอแนวทางการใช้งานทางเลือกใหม่
2. เลือกหนึ่งในไอเดียโครงการและจัดทำข้อกำหนดทางเทคนิคอย่างละเอียด
3. ศึกษาอุตสาหกรรมที่ไม่ได้อยู่ในกรณีศึกษาและสรุปว่า MCP จะช่วยแก้ปัญหาเฉพาะได้อย่างไร
4. สำรวจทิศทางในอนาคตหนึ่งด้านและสร้างแนวคิดสำหรับส่วนขยาย MCP ใหม่เพื่อรองรับทิศทางนั้น

ถัดไป: [Best Practices](../08-BestPractices/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษา AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางควรถูกพิจารณาเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้บริการแปลโดยมนุษย์มืออาชีพ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดใดๆ ที่เกิดจากการใช้การแปลนี้