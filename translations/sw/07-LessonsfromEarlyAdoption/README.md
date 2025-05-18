<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a6482c201133cb6cb0742918b373a523",
  "translation_date": "2025-05-17T16:32:37+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "sw"
}
-->
# Masomo kutoka kwa Watumiaji wa Mapema

## Muhtasari

Somohili linaangazia jinsi watumiaji wa mapema walivyotumia Model Context Protocol (MCP) kutatua changamoto za ulimwengu wa kweli na kuendesha ubunifu katika sekta mbalimbali. Kupitia masomo ya kina na miradi ya mikono, utaona jinsi MCP inavyowezesha ujumuishaji wa AI ulio sanifu, salama, na unaoweza kupanuka—kuunganisha mifano mikubwa ya lugha, zana, na data ya biashara katika mfumo mmoja. Utapata uzoefu wa vitendo katika kubuni na kujenga suluhisho za msingi za MCP, kujifunza kutoka kwa mifumo ya utekelezaji iliyothibitishwa, na kugundua mbinu bora za kupeleka MCP katika mazingira ya uzalishaji. Somo hili pia linaangazia mitindo inayoibuka, mwelekeo wa siku zijazo, na rasilimali za wazi kusaidia uwe mbele katika teknolojia ya MCP na mfumo wake unaoendelea.

## Malengo ya Kujifunza

- Kuchambua utekelezaji wa MCP wa ulimwengu wa kweli katika sekta mbalimbali
- Kubuni na kujenga programu kamili za msingi za MCP
- Kuchunguza mitindo inayoibuka na mwelekeo wa siku zijazo katika teknolojia ya MCP
- Kutumia mbinu bora katika hali halisi za maendeleo

## Utekelezaji wa MCP wa Ulimwengu wa Kweli

### Uchunguzi wa Kesi 1: Uendeshaji wa Msaada wa Wateja wa Biashara

Kampuni ya kimataifa ilitekeleza suluhisho la msingi la MCP ili kusanifu mwingiliano wa AI katika mifumo yao ya msaada kwa wateja. Hii iliwapa uwezo wa:

- Kuunda interface iliyounganishwa kwa watoa huduma wengi wa LLM
- Kudumisha usimamizi wa maombi ulio thabiti katika idara mbalimbali
- Kutekeleza udhibiti wa usalama na uzingatiaji wenye nguvu
- Kubadili kwa urahisi kati ya mifano tofauti ya AI kulingana na mahitaji maalum

**Utekelezaji wa Kiufundi:**
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

**Matokeo:** Punguzo la 30% katika gharama za mfano, uboreshaji wa 45% katika uthabiti wa majibu, na uzingatiaji ulioimarishwa katika shughuli za kimataifa.

### Uchunguzi wa Kesi 2: Msaidizi wa Utambuzi wa Afya

Mtoa huduma wa afya aliunda miundombinu ya MCP ili kuunganisha mifano ya AI ya matibabu maalum huku akihakikisha data nyeti ya wagonjwa inabaki salama:

- Kubadilika bila mshono kati ya mifano ya matibabu ya jumla na maalum
- Udhibiti mkali wa faragha na nyaraka za ukaguzi
- Ujumuishaji na mifumo iliyopo ya Rekodi za Afya za Kielektroniki (EHR)
- Uhandisi wa maombi ulio thabiti kwa istilahi ya matibabu

**Utekelezaji wa Kiufundi:**
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

**Matokeo:** Mapendekezo bora ya utambuzi kwa madaktari huku ukidumisha uzingatiaji kamili wa HIPAA na kupunguzwa kwa kiasi kikubwa kwa ubadilishaji wa muktadha kati ya mifumo.

### Uchunguzi wa Kesi 3: Uchambuzi wa Hatari za Huduma za Kifedha

Taasisi ya kifedha ilitekeleza MCP kusanifu michakato yao ya uchambuzi wa hatari katika idara mbalimbali:

- Iliunda interface iliyounganishwa kwa mifano ya hatari ya mkopo, kugundua udanganyifu, na hatari ya uwekezaji
- Kutekeleza udhibiti mkali wa ufikiaji na toleo la modeli
- Kuhakikisha uwezekano wa ukaguzi wa mapendekezo yote ya AI
- Kudumisha muundo wa data ulio thabiti katika mifumo tofauti

**Utekelezaji wa Kiufundi:**
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

**Matokeo:** Uzingatiaji wa kanuni ulioimarishwa, mzunguko wa utekelezaji wa modeli wa haraka kwa 40%, na uthabiti wa tathmini ya hatari ulioimarishwa katika idara.

### Uchunguzi wa Kesi 4: Microsoft Playwright MCP Server kwa Uendeshaji wa Kivinjari

Microsoft ilitengeneza [Playwright MCP server](https://github.com/microsoft/playwright-mcp) kuwezesha uendeshaji wa kivinjari ulio sanifu na salama kupitia Model Context Protocol. Suluhisho hili linawezesha mawakala wa AI na LLM kuingiliana na vivinjari vya wavuti kwa njia iliyodhibitiwa, inayoweza kukaguliwa, na inayoweza kupanuliwa—ikiwezesha matumizi kama vile majaribio ya wavuti yaliyojiendesha, uchimbaji wa data, na mtiririko wa kazi wa mwisho hadi mwisho.

- Hutoa uwezo wa uendeshaji wa kivinjari (urambazaji, kujaza fomu, kunasa picha, n.k.) kama zana za MCP
- Kutekeleza udhibiti mkali wa ufikiaji na kuweka kwenye kisanduku cha mchanga ili kuzuia vitendo visivyoidhinishwa
- Kutoa nyaraka za ukaguzi wa kina kwa mwingiliano wote wa kivinjari
- Inasaidia ujumuishaji na Azure OpenAI na watoa huduma wengine wa LLM kwa uendeshaji unaoendeshwa na mawakala

**Utekelezaji wa Kiufundi:**
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

**Matokeo:**  
- Uwezeshaji wa uendeshaji wa kivinjari ulio salama, wa programu kwa mawakala wa AI na LLM
- Punguzo la juhudi za majaribio ya mwongozo na uboreshaji wa usambazaji wa majaribio kwa programu za wavuti
- Kutoa mfumo unaoweza kutumika tena, unaoweza kupanuliwa kwa ujumuishaji wa zana za msingi wa kivinjari katika mazingira ya biashara

**Marejeleo:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Uchunguzi wa Kesi 5: Azure MCP – Model Context Protocol ya Daraja la Biashara kama Huduma

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) ni utekelezaji ulio simamiwa na Microsoft wa daraja la biashara wa Model Context Protocol, ulioundwa kutoa uwezo wa seva ya MCP unaoweza kupanuka, salama, na unaozingatia kanuni kama huduma ya wingu. Azure MCP inawezesha mashirika kupeleka, kusimamia, na kuunganisha seva za MCP na huduma za Azure AI, data, na usalama, kupunguza mzigo wa kiutendaji na kuharakisha upitishaji wa AI.

- Ukaribishaji wa seva ya MCP ulio simamiwa kikamilifu na upanuzi wa ndani, ufuatiliaji, na usalama
- Ujumuishaji wa asili na Azure OpenAI, Azure AI Search, na huduma nyingine za Azure
- Uthibitishaji na idhini ya biashara kupitia Microsoft Entra ID
- Msaada kwa zana maalum, templeti za maombi, na viunganishi vya rasilimali
- Uzingatiaji wa mahitaji ya usalama na kanuni za biashara

**Utekelezaji wa Kiufundi:**
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

**Matokeo:**  
- Punguzo la muda wa thamani kwa miradi ya AI ya biashara kwa kutoa jukwaa la seva ya MCP linaloweza kutumika mara moja, linalozingatia kanuni
- Urahisi wa ujumuishaji wa LLM, zana, na vyanzo vya data vya biashara
- Usalama ulioimarishwa, ufuatiliaji, na ufanisi wa kiutendaji kwa mizigo ya kazi ya MCP

**Marejeleo:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Miradi ya Mikono

### Mradi 1: Jenga Seva ya MCP ya Watoa Huduma Wengi

**Lengo:** Unda seva ya MCP inayoweza kuelekeza maombi kwa watoa huduma wengi wa modeli ya AI kulingana na vigezo maalum.

**Mahitaji:**
- Msaada kwa angalau watoa huduma watatu tofauti wa modeli (mfano, OpenAI, Anthropic, modeli za ndani)
- Tekeleza utaratibu wa kuelekeza kulingana na metadata ya maombi
- Unda mfumo wa usanidi wa kusimamia hati za watoa huduma
- Ongeza uhifadhi ili kuboresha utendaji na gharama
- Jenga dashibodi rahisi ya ufuatiliaji wa matumizi

**Hatua za Utekelezaji:**
1. Sanidi miundombinu ya msingi ya seva ya MCP
2. Tekeleza adapta za watoa huduma kwa kila huduma ya modeli ya AI
3. Unda mantiki ya kuelekeza kulingana na sifa za maombi
4. Ongeza mifumo ya uhifadhi kwa maombi ya mara kwa mara
5. Tengeneza dashibodi ya ufuatiliaji
6. Jaribu na mifumo mbalimbali ya maombi

**Teknolojia:** Chagua kutoka Python (.NET/Java/Python kulingana na upendeleo wako), Redis kwa uhifadhi, na mfumo rahisi wa wavuti kwa dashibodi.

### Mradi 2: Mfumo wa Usimamizi wa Maombi wa Biashara

**Lengo:** Kuendeleza mfumo wa msingi wa MCP wa kusimamia, kuweka toleo, na kupeleka templeti za maombi katika shirika.

**Mahitaji:**
- Unda hazina ya kati kwa templeti za maombi
- Tekeleza mfumo wa kuweka toleo na mchakato wa idhini
- Jenga uwezo wa kujaribu templeti na pembejeo za sampuli
- Kuendeleza udhibiti wa ufikiaji wa msingi wa majukumu
- Unda API ya upatikanaji na upelekeaji wa templeti

**Hatua za Utekelezaji:**
1. Buni muundo wa hifadhidata kwa uhifadhi wa templeti
2. Unda API ya msingi kwa operesheni za CRUD za templeti
3. Tekeleza mfumo wa kuweka toleo
4. Jenga mchakato wa idhini
5. Kuendeleza mfumo wa majaribio
6. Unda interface rahisi ya wavuti kwa usimamizi
7. Unganisha na seva ya MCP

**Teknolojia:** Chaguo lako la mfumo wa nyuma, hifadhidata ya SQL au NoSQL, na mfumo wa mbele kwa interface ya usimamizi.

### Mradi 3: Jukwaa la Kuzalisha Maudhui kwa Msingi wa MCP

**Lengo:** Jenga jukwaa la kuzalisha maudhui linalotumia MCP kutoa matokeo thabiti katika aina tofauti za maudhui.

**Mahitaji:**
- Msaada kwa miundo tofauti ya maudhui (machapisho ya blogi, mitandao ya kijamii, nakala za uuzaji)
- Tekeleza uzalishaji kwa msingi wa templeti na chaguo za ubinafsishaji
- Unda mfumo wa ukaguzi wa maudhui na maoni
- Fuatilia vipimo vya utendaji wa maudhui
- Msaada kwa kuweka toleo na kurudia kwa maudhui

**Hatua za Utekelezaji:**
1. Sanidi miundombinu ya mteja wa MCP
2. Unda templeti kwa aina tofauti za maudhui
3. Jenga mchakato wa uzalishaji wa maudhui
4. Tekeleza mfumo wa ukaguzi
5. Kuendeleza mfumo wa ufuatiliaji wa vipimo
6. Unda interface ya mtumiaji kwa usimamizi wa templeti na uzalishaji wa maudhui

**Teknolojia:** Lugha yako ya programu inayopendekezwa, mfumo wa wavuti, na mfumo wa hifadhidata.

## Mwelekeo wa Siku za Usoni kwa Teknolojia ya MCP

### Mitindo Inayoibuka

1. **MCP ya Njia Nyingi**
   - Upanuzi wa MCP ili kusanifu mwingiliano na mifano ya picha, sauti, na video
   - Maendeleo ya uwezo wa mantiki wa njia mbalimbali
   - Miundo sanifu ya maombi kwa njia tofauti

2. **Miundombinu ya MCP ya Kifederali**
   - Mitandao ya MCP iliyosambazwa inayoweza kushiriki rasilimali katika mashirika
   - Itifaki sanifu za kushiriki modeli kwa usalama
   - Mbinu za hesabu zinazohifadhi faragha

3. **Masoko ya MCP**
   - Ekosistimu za kushiriki na kupata MCP templates na plugins
   - Mchakato wa uhakikisho wa ubora na vyeti
   - Ujumuishaji na masoko ya modeli

4. **MCP kwa Kompyuta ya Kando**
   - Urekebishaji wa viwango vya MCP kwa vifaa vya kando vilivyo na rasilimali kidogo
   - Itifaki zilizoboreshwa kwa mazingira ya kipimo data kidogo
   - Utekelezaji maalum wa MCP kwa ekosistimu za IoT

5. **Mifumo ya Kanuni**
   - Maendeleo ya viendelezi vya MCP kwa uzingatiaji wa kanuni
   - Nyaraka sanifu za ukaguzi na interfaces za kuelezea
   - Ujumuishaji na mifumo ya utawala wa AI inayochipuka

### Suluhisho za MCP kutoka Microsoft

Microsoft na Azure wameunda hazina kadhaa za wazi kusaidia wasanidi programu kutekeleza MCP katika hali mbalimbali:

#### Shirika la Microsoft
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - Seva ya Playwright MCP kwa uendeshaji na majaribio ya kivinjari
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - Utekelezaji wa seva ya OneDrive MCP kwa majaribio ya ndani na mchango wa jamii

#### Shirika la Azure-Samples
1. [mcp](https://github.com/Azure-Samples/mcp) - Viungo vya sampuli, zana, na rasilimali za kujenga na kuunganisha seva za MCP kwenye Azure kwa kutumia lugha mbalimbali
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - Seva za MCP za marejeleo zinazodhihirisha uthibitishaji na vipimo vya sasa vya Model Context Protocol
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Ukurasa wa kutua kwa utekelezaji wa Seva ya MCP ya Mbali katika Azure Functions na viungo kwa hazina maalum za lugha
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Template ya kuanza haraka kwa kujenga na kupeleka seva za MCP za mbali maalum kwa kutumia Azure Functions na Python
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Template ya kuanza haraka kwa kujenga na kupeleka seva za MCP za mbali maalum kwa kutumia Azure Functions na .NET/C#
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Template ya kuanza haraka kwa kujenga na kupeleka seva za MCP za mbali maalum kwa kutumia Azure Functions na TypeScript
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Usimamizi wa API wa Azure kama Lango la AI kwa seva za MCP za mbali kwa kutumia Python
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - APIM ❤️ majaribio ya AI ikiwa ni pamoja na uwezo wa MCP, ujumuishaji na Azure OpenAI na AI Foundry

Hazina hizi zinatoa utekelezaji mbalimbali, templates, na rasilimali za kufanya kazi na Model Context Protocol katika lugha tofauti za programu na huduma za Azure. Zinashughulikia matumizi mbalimbali kutoka kwa utekelezaji wa seva za msingi hadi uthibitishaji, upelekaji wa wingu, na hali za ujumuishaji wa biashara.

#### Saraka ya Rasilimali za MCP

Saraka ya [MCP Resources](https://github.com/microsoft/mcp/tree/main/Resources) katika hazina rasmi ya Microsoft MCP inatoa mkusanyiko ulioratibiwa wa rasilimali za sampuli, templeti za maombi, na ufafanuzi wa zana kwa matumizi na seva za Model Context Protocol. Saraka hii imeundwa kusaidia wasanidi programu kuanza haraka na MCP kwa kutoa vizuizi vya ujenzi vinavyoweza kutumika tena na mifano bora ya vitendo kwa:

- **Templeti za Maombi:** Templeti za maombi zinazoweza kutumika moja kwa moja kwa kazi na hali za kawaida za AI, ambazo zinaweza kubadilishwa kwa utekelezaji wako wa seva ya MCP.
- **Ufafanuzi wa Zana:** Mifano ya schemas za zana na metadata ili kusanifu ujumuishaji wa zana na utekelezaji katika seva tofauti za MCP.
- **Sampuli za Rasilimali:** Mifano ya ufafanuzi wa rasilimali kwa kuunganisha na vyanzo vya data, APIs, na huduma za nje ndani ya mfumo wa MCP.
- **Utekelezaji wa Marejeleo:** Sampuli za vitendo zinazoonyesha jinsi ya kuunda na kupanga rasilimali, maombi, na zana katika miradi halisi ya MCP.

Rasilimali hizi zinaharakisha maendeleo, zinakuza usanifu, na husaidia kuhakikisha mbinu bora wakati wa kujenga na kupeleka suluhisho za msingi za MCP.

#### Saraka ya Rasilimali za MCP
- [MCP Resources (Sample Prompts, Tools, and Resource Definitions)](https://github.com/m
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

## Mazoezi

1. Changanua moja ya tafiti za kesi na toa njia mbadala ya utekelezaji.
2. Chagua moja ya mawazo ya mradi na uunde maelezo ya kina ya kiufundi.
3. Fanya utafiti wa sekta ambayo haijafunikwa kwenye tafiti za kesi na fafanua jinsi MCP inaweza kushughulikia changamoto zake maalum.
4. Chunguza moja ya mwelekeo wa baadaye na uunde dhana ya upanuzi mpya wa MCP ili kuunga mkono.

Ifuatayo: [Mbinu Bora](../08-BestPractices/README.md)

**Kanusho**: 
Hati hii imetafsiriwa kwa kutumia huduma ya kutafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au kutokuwa sahihi. Hati ya asili katika lugha yake ya asili inapaswa kuzingatiwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu ya binadamu inapendekezwa. Hatuwajibiki kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.