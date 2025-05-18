<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a6482c201133cb6cb0742918b373a523",
  "translation_date": "2025-05-17T16:21:16+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "th"
}
-->
# บทเรียนจากผู้ใช้กลุ่มแรก

## ภาพรวม

บทเรียนนี้จะสำรวจวิธีที่ผู้ใช้กลุ่มแรกใช้ Model Context Protocol (MCP) ในการแก้ปัญหาที่เกิดขึ้นจริงและขับเคลื่อนนวัตกรรมในหลากหลายอุตสาหกรรม ผ่านกรณีศึกษาและโครงการที่ทำด้วยตนเอง คุณจะเห็นว่า MCP ช่วยให้การรวม AI เป็นมาตรฐาน ปลอดภัย และขยายขนาดได้อย่างไร โดยเชื่อมต่อโมเดลภาษาขนาดใหญ่ เครื่องมือ และข้อมูลองค์กรในกรอบการทำงานเดียว คุณจะได้รับประสบการณ์ในการออกแบบและสร้างโซลูชันที่ใช้ MCP เรียนรู้จากรูปแบบการดำเนินการที่ได้รับการพิสูจน์แล้ว และค้นพบวิธีปฏิบัติที่ดีที่สุดในการนำ MCP ไปใช้ในสภาพแวดล้อมการผลิต บทเรียนยังเน้นแนวโน้มที่เกิดขึ้นใหม่ ทิศทางในอนาคต และแหล่งข้อมูลโอเพนซอร์สเพื่อช่วยให้คุณอยู่ในระดับแนวหน้าของเทคโนโลยี MCP และระบบนิเวศที่พัฒนาอย่างต่อเนื่อง

## วัตถุประสงค์การเรียนรู้

- วิเคราะห์การใช้งาน MCP ในโลกจริงในอุตสาหกรรมต่างๆ
- ออกแบบและสร้างแอปพลิเคชันที่ใช้ MCP อย่างสมบูรณ์
- สำรวจแนวโน้มที่เกิดขึ้นใหม่และทิศทางในอนาคตในเทคโนโลยี MCP
- ประยุกต์ใช้แนวทางปฏิบัติที่ดีที่สุดในสถานการณ์การพัฒนาจริง

## การใช้งาน MCP ในโลกจริง

### กรณีศึกษา 1: การสนับสนุนลูกค้าอัตโนมัติขององค์กร

บริษัทข้ามชาติได้ใช้โซลูชันที่ใช้ MCP เพื่อทำให้การโต้ตอบ AI ในระบบสนับสนุนลูกค้าของพวกเขาเป็นมาตรฐาน สิ่งนี้ทำให้พวกเขาสามารถ:

- สร้างอินเทอร์เฟซแบบรวมสำหรับผู้ให้บริการ LLM หลายราย
- รักษาการจัดการ prompt ที่สอดคล้องกันในทุกแผนก
- ใช้มาตรการรักษาความปลอดภัยและการปฏิบัติตามกฎระเบียบที่เข้มงวด
- สลับระหว่างโมเดล AI ต่างๆ ได้อย่างง่ายดายตามความต้องการเฉพาะ

**การดำเนินการทางเทคนิค:**
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

**ผลลัพธ์:** ลดต้นทุนโมเดลลง 30% ปรับปรุงความสอดคล้องของการตอบสนอง 45% และเพิ่มการปฏิบัติตามกฎระเบียบในระดับโลก

### กรณีศึกษา 2: ผู้ช่วยวินิจฉัยทางการแพทย์

ผู้ให้บริการด้านการดูแลสุขภาพได้พัฒนาโครงสร้างพื้นฐาน MCP เพื่อรวมโมเดล AI ทางการแพทย์เฉพาะทางหลายโมเดลในขณะที่ยังคงปกป้องข้อมูลผู้ป่วยที่ละเอียดอ่อน:

- การสลับระหว่างโมเดลทางการแพทย์ทั่วไปและเฉพาะทางอย่างราบรื่น
- การควบคุมความเป็นส่วนตัวที่เข้มงวดและการติดตามการตรวจสอบ
- การรวมเข้ากับระบบ Electronic Health Record (EHR) ที่มีอยู่
- วิศวกรรม prompt ที่สอดคล้องกันสำหรับคำศัพท์ทางการแพทย์

**การดำเนินการทางเทคนิค:**
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

**ผลลัพธ์:** ข้อเสนอแนะการวินิจฉัยที่ดีขึ้นสำหรับแพทย์ในขณะที่รักษาการปฏิบัติตามข้อกำหนด HIPAA อย่างเต็มรูปแบบและลดการสลับบริบทระหว่างระบบอย่างมีนัยสำคัญ

### กรณีศึกษา 3: การวิเคราะห์ความเสี่ยงด้านบริการทางการเงิน

สถาบันการเงินได้ใช้ MCP เพื่อทำให้กระบวนการวิเคราะห์ความเสี่ยงของพวกเขาเป็นมาตรฐานในแผนกต่างๆ:

- สร้างอินเทอร์เฟซแบบรวมสำหรับโมเดลความเสี่ยงด้านเครดิต การตรวจจับการฉ้อโกง และความเสี่ยงในการลงทุน
- ใช้การควบคุมการเข้าถึงที่เข้มงวดและการจัดการเวอร์ชันของโมเดล
- ตรวจสอบความสามารถในการตรวจสอบคำแนะนำของ AI ทั้งหมด
- รักษาการจัดรูปแบบข้อมูลที่สอดคล้องกันในระบบที่หลากหลาย

**การดำเนินการทางเทคนิค:**
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

**ผลลัพธ์:** เพิ่มการปฏิบัติตามกฎระเบียบ ปรับปรุงรอบการปรับใช้โมเดลเร็วขึ้น 40% และปรับปรุงความสอดคล้องในการประเมินความเสี่ยงในแผนกต่างๆ

### กรณีศึกษา 4: Microsoft Playwright MCP Server สำหรับการทำงานอัตโนมัติของเบราว์เซอร์

Microsoft ได้พัฒนา [Playwright MCP server](https://github.com/microsoft/playwright-mcp) เพื่อเปิดใช้งานการทำงานอัตโนมัติของเบราว์เซอร์ที่ปลอดภัยและเป็นมาตรฐานผ่าน Model Context Protocol โซลูชันนี้ช่วยให้ AI agents และ LLMs สามารถโต้ตอบกับเว็บเบราว์เซอร์ได้ในลักษณะที่ควบคุม ตรวจสอบได้ และขยายได้—เปิดใช้งานกรณีการใช้งาน เช่น การทดสอบเว็บอัตโนมัติ การสกัดข้อมูล และเวิร์กโฟลว์แบบ end-to-end

- เปิดเผยความสามารถในการทำงานอัตโนมัติของเบราว์เซอร์ (การนำทาง การกรอกแบบฟอร์ม การจับภาพหน้าจอ ฯลฯ) เป็นเครื่องมือ MCP
- ใช้การควบคุมการเข้าถึงที่เข้มงวดและการแยกสภาพแวดล้อมเพื่อป้องกันการกระทำที่ไม่ได้รับอนุญาต
- ให้บันทึกการตรวจสอบรายละเอียดสำหรับการโต้ตอบกับเบราว์เซอร์ทั้งหมด
- รองรับการรวมเข้ากับ Azure OpenAI และผู้ให้บริการ LLM อื่นๆ สำหรับการทำงานอัตโนมัติที่ขับเคลื่อนด้วย agent

**การดำเนินการทางเทคนิค:**
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
- เปิดใช้งานการทำงานอัตโนมัติของเบราว์เซอร์อย่างปลอดภัยสำหรับ AI agents และ LLMs
- ลดความพยายามในการทดสอบด้วยตนเองและปรับปรุงความครอบคลุมในการทดสอบสำหรับแอปพลิเคชันเว็บ
- จัดหาโครงสร้างที่สามารถนำกลับมาใช้ใหม่และขยายได้สำหรับการรวมเครื่องมือที่ใช้เบราว์เซอร์ในสภาพแวดล้อมองค์กร

**แหล่งอ้างอิง:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### กรณีศึกษา 5: Azure MCP – บริการ Model Context Protocol ระดับองค์กร

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) คือการดำเนินการของ Microsoft ที่มีการจัดการระดับองค์กรของ Model Context Protocol ซึ่งออกแบบมาเพื่อให้ความสามารถของเซิร์ฟเวอร์ MCP ที่ปรับขนาดได้ ปลอดภัย และสอดคล้องกันเป็นบริการคลาวด์ Azure MCP ช่วยให้องค์กรสามารถปรับใช้ จัดการ และรวมเซิร์ฟเวอร์ MCP กับ Azure AI ข้อมูล และบริการความปลอดภัยได้อย่างรวดเร็ว ลดภาระงานในการดำเนินงานและเร่งการนำ AI ไปใช้

- โฮสติ้งเซิร์ฟเวอร์ MCP ที่มีการจัดการเต็มรูปแบบพร้อมการปรับขนาด การตรวจสอบ และความปลอดภัยในตัว
- การรวมเข้ากับ Azure OpenAI, Azure AI Search และบริการ Azure อื่นๆ โดยตรง
- การตรวจสอบสิทธิ์และการอนุญาตขององค์กรผ่าน Microsoft Entra ID
- รองรับเครื่องมือที่กำหนดเอง แม่แบบ prompt และตัวเชื่อมต่อทรัพยากร
- ปฏิบัติตามข้อกำหนดด้านความปลอดภัยและกฎระเบียบขององค์กร

**การดำเนินการทางเทคนิค:**
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
- ลดเวลาในการสร้างมูลค่าสำหรับโครงการ AI ขององค์กรโดยให้แพลตฟอร์มเซิร์ฟเวอร์ MCP ที่พร้อมใช้งานและสอดคล้องกัน
- ทำให้การรวม LLMs เครื่องมือ และแหล่งข้อมูลองค์กรง่ายขึ้น
- เพิ่มความปลอดภัย การสังเกตการณ์ และประสิทธิภาพการดำเนินงานสำหรับงาน MCP

**แหล่งอ้างอิง:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## โครงการที่ทำด้วยตนเอง

### โครงการ 1: สร้างเซิร์ฟเวอร์ MCP หลายผู้ให้บริการ

**วัตถุประสงค์:** สร้างเซิร์ฟเวอร์ MCP ที่สามารถกำหนดเส้นทางคำขอไปยังผู้ให้บริการโมเดล AI หลายรายตามเกณฑ์เฉพาะ

**ข้อกำหนด:**
- รองรับผู้ให้บริการโมเดลอย่างน้อยสามราย (เช่น OpenAI, Anthropic, โมเดลท้องถิ่น)
- ใช้กลไกการกำหนดเส้นทางตามเมตาดาต้าของคำขอ
- สร้างระบบการกำหนดค่าที่จัดการข้อมูลรับรองของผู้ให้บริการ
- เพิ่มการแคชเพื่อเพิ่มประสิทธิภาพและลดค่าใช้จ่าย
- สร้างแดชบอร์ดง่ายๆ สำหรับการตรวจสอบการใช้งาน

**ขั้นตอนการดำเนินการ:**
1. ตั้งค่าโครงสร้างพื้นฐานเซิร์ฟเวอร์ MCP พื้นฐาน
2. ใช้ตัวเชื่อมต่อผู้ให้บริการสำหรับแต่ละบริการโมเดล AI
3. สร้างตรรกะการกำหนดเส้นทางตามแอตทริบิวต์ของคำขอ
4. เพิ่มกลไกการแคชสำหรับคำขอบ่อยๆ
5. พัฒนาแดชบอร์ดการตรวจสอบ
6. ทดสอบด้วยรูปแบบคำขอต่างๆ

**เทคโนโลยี:** เลือกจาก Python (.NET/Java/Python ตามความชอบของคุณ), Redis สำหรับการแคช และเฟรมเวิร์กเว็บง่ายๆ สำหรับแดชบอร์ด

### โครงการ 2: ระบบการจัดการ prompt ขององค์กร

**วัตถุประสงค์:** พัฒนาระบบที่ใช้ MCP สำหรับการจัดการ การกำหนดเวอร์ชัน และการปรับใช้แม่แบบ prompt ในองค์กร

**ข้อกำหนด:**
- สร้างที่เก็บรวมศูนย์สำหรับแม่แบบ prompt
- ใช้ระบบเวอร์ชันและเวิร์กโฟลว์การอนุมัติ
- สร้างความสามารถในการทดสอบแม่แบบด้วยอินพุตตัวอย่าง
- พัฒนาการควบคุมการเข้าถึงตามบทบาท
- สร้าง API สำหรับการดึงและปรับใช้แม่แบบ

**ขั้นตอนการดำเนินการ:**
1. ออกแบบสคีมาฐานข้อมูลสำหรับการจัดเก็บแม่แบบ
2. สร้าง API หลักสำหรับการดำเนินการ CRUD ของแม่แบบ
3. ใช้ระบบเวอร์ชัน
4. สร้างเวิร์กโฟลว์การอนุมัติ
5. พัฒนากรอบการทดสอบ
6. สร้างอินเทอร์เฟซเว็บง่ายๆ สำหรับการจัดการ
7. รวมเข้ากับเซิร์ฟเวอร์ MCP

**เทคโนโลยี:** เลือกเฟรมเวิร์กแบ็กเอนด์ ฐานข้อมูล SQL หรือ NoSQL และเฟรมเวิร์กฟรอนต์เอนด์สำหรับอินเทอร์เฟซการจัดการตามที่คุณต้องการ

### โครงการ 3: แพลตฟอร์มการสร้างเนื้อหาที่ใช้ MCP

**วัตถุประสงค์:** สร้างแพลตฟอร์มการสร้างเนื้อหาที่ใช้ MCP เพื่อให้ผลลัพธ์ที่สอดคล้องกันในประเภทเนื้อหาต่างๆ

**ข้อกำหนด:**
- รองรับรูปแบบเนื้อหาหลายประเภท (บล็อกโพสต์ โซเชียลมีเดีย การเขียนโฆษณาการตลาด)
- ใช้การสร้างตามแม่แบบพร้อมตัวเลือกการปรับแต่ง
- สร้างระบบการตรวจสอบและข้อเสนอแนะเนื้อหา
- ติดตามตัวชี้วัดประสิทธิภาพของเนื้อหา
- รองรับการจัดเวอร์ชันและการทำซ้ำเนื้อหา

**ขั้นตอนการดำเนินการ:**
1. ตั้งค่าโครงสร้างพื้นฐานไคลเอนต์ MCP
2. สร้างแม่แบบสำหรับประเภทเนื้อหาต่างๆ
3. สร้างกระบวนการสร้างเนื้อหา
4. ใช้ระบบการตรวจสอบ
5. พัฒนาระบบติดตามตัวชี้วัด
6. สร้างอินเทอร์เฟซผู้ใช้สำหรับการจัดการแม่แบบและการสร้างเนื้อหา

**เทคโนโลยี:** เลือกภาษาการเขียนโปรแกรม เฟรมเวิร์กเว็บ และระบบฐานข้อมูลที่คุณต้องการ

## ทิศทางในอนาคตสำหรับเทคโนโลยี MCP

### แนวโน้มที่เกิดขึ้นใหม่

1. **Multi-Modal MCP**
   - การขยาย MCP เพื่อมาตรฐานการโต้ตอบกับโมเดลภาพ เสียง และวิดีโอ
   - การพัฒนาความสามารถในการให้เหตุผลข้ามโมเดล
   - รูปแบบ prompt มาตรฐานสำหรับสื่อที่แตกต่างกัน

2. **Federated MCP Infrastructure**
   - เครือข่าย MCP แบบกระจายที่สามารถแชร์ทรัพยากรข้ามองค์กร
   - โปรโตคอลมาตรฐานสำหรับการแชร์โมเดลอย่างปลอดภัย
   - เทคนิคการคำนวณที่รักษาความเป็นส่วนตัว

3. **MCP Marketplaces**
   - ระบบนิเวศสำหรับการแชร์และสร้างรายได้จากแม่แบบและปลั๊กอิน MCP
   - กระบวนการประกันคุณภาพและการรับรอง
   - การรวมเข้ากับตลาดโมเดล

4. **MCP for Edge Computing**
   - การปรับมาตรฐาน MCP สำหรับอุปกรณ์ edge ที่มีข้อจำกัดด้านทรัพยากร
   - โปรโตคอลที่ปรับให้เหมาะสมสำหรับสภาพแวดล้อมที่มีแบนด์วิดท์ต่ำ
   - การใช้งาน MCP เฉพาะทางสำหรับระบบนิเวศ IoT

5. **Regulatory Frameworks**
   - การพัฒนาส่วนขยาย MCP สำหรับการปฏิบัติตามกฎระเบียบ
   - เส้นทางการตรวจสอบมาตรฐานและอินเทอร์เฟซการอธิบาย
   - การรวมเข้ากับกรอบการกำกับดูแล AI ที่เกิดขึ้นใหม่

### โซลูชัน MCP จาก Microsoft

Microsoft และ Azure ได้พัฒนาโครงการโอเพนซอร์สหลายโครงการเพื่อช่วยให้นักพัฒนาดำเนินการ MCP ในสถานการณ์ต่างๆ:

#### องค์กร Microsoft
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - เซิร์ฟเวอร์ Playwright MCP สำหรับการทำงานอัตโนมัติและการทดสอบเบราว์เซอร์
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - การดำเนินการเซิร์ฟเวอร์ MCP ของ OneDrive สำหรับการทดสอบในพื้นที่และการมีส่วนร่วมของชุมชน

#### องค์กร Azure-Samples
1. [mcp](https://github.com/Azure-Samples/mcp) - ลิงก์ไปยังตัวอย่าง เครื่องมือ และแหล่งข้อมูลสำหรับการสร้างและรวมเซิร์ฟเวอร์ MCP บน Azure โดยใช้หลายภาษา
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - เซิร์ฟเวอร์ MCP อ้างอิงที่แสดงการตรวจสอบสิทธิ์ด้วยข้อกำหนด Model Context Protocol ปัจจุบัน
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - หน้าแรกสำหรับการใช้งาน Remote MCP Server ใน Azure Functions พร้อมลิงก์ไปยัง repo เฉพาะภาษา
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - เทมเพลตเริ่มต้นอย่างรวดเร็วสำหรับการสร้างและปรับใช้เซิร์ฟเวอร์ MCP ระยะไกลแบบกำหนดเองโดยใช้ Azure Functions ด้วย Python
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - เทมเพลตเริ่มต้นอย่างรวดเร็วสำหรับการสร้างและปรับใช้เซิร์ฟเวอร์ MCP ระยะไกลแบบกำหนดเองโดยใช้ Azure Functions ด้วย .NET/C#
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - เทมเพลตเริ่มต้นอย่างรวดเร็วสำหรับการสร้างและปรับใช้เซิร์ฟเวอร์ MCP ระยะไกลแบบกำหนดเองโดยใช้ Azure Functions ด้วย TypeScript
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Azure API Management เป็น AI Gateway ไปยังเซิร์ฟเวอร์ MCP ระยะไกลโดยใช้ Python
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - การทดลอง APIM ❤️ AI รวมถึงความสามารถ MCP รวมเข้ากับ Azure OpenAI
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

## แบบฝึกหัด

1. วิเคราะห์กรณีศึกษาใดกรณีหนึ่งและเสนอวิธีการดำเนินการในรูปแบบทางเลือก
2. เลือกหนึ่งในแนวคิดโครงการและสร้างข้อกำหนดทางเทคนิคอย่างละเอียด
3. ศึกษาอุตสาหกรรมที่ไม่ได้ครอบคลุมในกรณีศึกษาและร่างวิธีที่ MCP สามารถแก้ไขความท้าทายเฉพาะของอุตสาหกรรมนั้นได้
4. สำรวจทิศทางอนาคตใดทิศทางหนึ่งและสร้างแนวคิดสำหรับการขยาย MCP ใหม่เพื่อสนับสนุนมัน

ถัดไป: [แนวทางปฏิบัติที่ดีที่สุด](../08-BestPractices/README.md)

**คำปฏิเสธความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาด้วย AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามอย่างเต็มที่เพื่อความถูกต้อง แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางควรถูกพิจารณาว่าเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลสำคัญ แนะนำให้ใช้การแปลโดยมนุษย์มืออาชีพ เราจะไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดพลาดใด ๆ ที่เกิดจากการใช้การแปลนี้