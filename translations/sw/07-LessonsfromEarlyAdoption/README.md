<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-07-14T04:36:07+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "sw"
}
-->
# Mafunzo kutoka kwa Watumiaji wa Mapema

## Muhtasari

Somo hili linachunguza jinsi watumiaji wa mapema walivyotumia Model Context Protocol (MCP) kutatua changamoto halisi na kuendesha ubunifu katika sekta mbalimbali. Kupitia tafiti za kina za kesi na miradi ya vitendo, utaona jinsi MCP inavyowezesha ushirikiano wa AI uliopangwa, salama, na unaoweza kupanuka—kuunganisha mifano mikubwa ya lugha, zana, na data za biashara katika mfumo mmoja. Utapata uzoefu wa kutengeneza na kujenga suluhisho zinazotegemea MCP, kujifunza kutoka kwa mifumo iliyothibitishwa ya utekelezaji, na kugundua mbinu bora za kuanzisha MCP katika mazingira ya uzalishaji. Somo pia linaangazia mwelekeo unaojitokeza, mwelekeo wa baadaye, na rasilimali za chanzo huria zitakazokusaidia kubaki mstari wa mbele wa teknolojia ya MCP na mfumo wake unaobadilika.

## Malengo ya Kujifunza

- Kuchambua utekelezaji halisi wa MCP katika sekta mbalimbali  
- Kubuni na kujenga programu kamili zinazotegemea MCP  
- Kuchunguza mwelekeo unaojitokeza na mwelekeo wa baadaye katika teknolojia ya MCP  
- Kutumia mbinu bora katika hali halisi za maendeleo  

## Utekelezaji Halisi wa MCP

### Tafiti ya Kesi 1: Uendeshaji wa Msaada kwa Wateja wa Kampuni

Kampuni ya kimataifa ilitekeleza suluhisho linalotegemea MCP ili kuweka viwango vya ushirikiano wa AI katika mifumo yao ya msaada kwa wateja. Hii iliwaruhusu:

- Kuunda kiolesura kimoja kwa watoa huduma mbalimbali wa LLM  
- Kudumisha usimamizi thabiti wa maelekezo katika idara zote  
- Kutekeleza udhibiti imara wa usalama na ufuataji wa sheria  
- Kubadilisha kwa urahisi kati ya mifano tofauti ya AI kulingana na mahitaji maalum  

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

**Matokeo:** Kupungua kwa gharama za modeli kwa 30%, kuboresha uthabiti wa majibu kwa 45%, na kuimarisha ufuataji wa sheria katika shughuli za kimataifa.

### Tafiti ya Kesi 2: Msaidizi wa Uchunguzi wa Afya

Mtoa huduma wa afya alitengeneza miundombinu ya MCP kuunganisha mifano mbalimbali maalum ya AI ya matibabu huku akihakikisha data nyeti za wagonjwa zinabaki salama:

- Kubadilisha kwa urahisi kati ya mifano ya matibabu ya jumla na maalum  
- Udhibiti mkali wa faragha na rekodi za ukaguzi  
- Uunganishaji na mifumo ya Rekodi za Afya za Kielektroniki (EHR) iliyopo  
- Uhandisi thabiti wa maelekezo kwa istilahi za matibabu  

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

**Matokeo:** Kuboresha mapendekezo ya uchunguzi kwa madaktari huku ikidumisha ufuataji kamili wa HIPAA na kupunguza kwa kiasi kikubwa mabadiliko ya muktadha kati ya mifumo.

### Tafiti ya Kesi 3: Uchambuzi wa Hatari katika Huduma za Fedha

Taasisi ya fedha ilitekeleza MCP kuweka viwango vya michakato yao ya uchambuzi wa hatari katika idara mbalimbali:

- Kuunda kiolesura kimoja kwa mifano ya hatari ya mkopo, kugundua udanganyifu, na hatari za uwekezaji  
- Kutekeleza udhibiti mkali wa upatikanaji na toleo la modeli  
- Kuhakikisha ufuatiliaji wa mapendekezo yote ya AI  
- Kudumisha muundo thabiti wa data katika mifumo tofauti  

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

**Matokeo:** Kuimarisha ufuataji wa kanuni, mizunguko ya utoaji wa modeli kwa kasi ya 40%, na kuboresha uthabiti wa tathmini ya hatari katika idara.

### Tafiti ya Kesi 4: Microsoft Playwright MCP Server kwa Uendeshaji wa Vivinjari

Microsoft ilitengeneza [Playwright MCP server](https://github.com/microsoft/playwright-mcp) kuwezesha uendeshaji wa vivinjari kwa usalama na kwa viwango kupitia Model Context Protocol. Suluhisho hili huruhusu mawakala wa AI na LLM kuingiliana na vivinjari vya wavuti kwa njia iliyodhibitiwa, inayoweza kufuatiliwa, na inayoweza kupanuliwa—kusaidia matumizi kama vile upimaji wa wavuti wa moja kwa moja, uchimbaji data, na michakato kamili ya kazi.

- Inaonyesha uwezo wa uendeshaji wa kivinjari (kuvinjari, kujaza fomu, kupiga picha za skrini, n.k.) kama zana za MCP  
- Inatekeleza udhibiti mkali wa upatikanaji na sandboxing kuzuia vitendo visivyoidhinishwa  
- Inatoa rekodi za ukaguzi kwa undani kwa mwingiliano wote wa kivinjari  
- Inaunga mkono uunganishaji na Azure OpenAI na watoa huduma wengine wa LLM kwa uendeshaji unaoongozwa na mawakala  

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
- Iwezesha uendeshaji wa kivinjari kwa usalama na kwa mpangilio kwa mawakala wa AI na LLM  
- Kupunguza juhudi za upimaji wa mikono na kuboresha upana wa upimaji wa programu za wavuti  
- Kutoa mfumo unaoweza kutumika tena na kupanuliwa kwa uunganishaji wa zana za kivinjari katika mazingira ya biashara  

**Marejeleo:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Tafiti ya Kesi 5: Azure MCP – Model Context Protocol ya Kiwango cha Biashara kama Huduma

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) ni utekelezaji wa Microsoft wa kiwango cha biashara wa Model Context Protocol, uliosimamiwa kikamilifu, ulioundwa kutoa uwezo wa seva za MCP zinazoweza kupanuka, salama, na zenye ufuataji wa sheria kama huduma ya wingu. Azure MCP inawawezesha mashirika kuanzisha, kusimamia, na kuunganisha seva za MCP na huduma za Azure AI, data, na usalama kwa haraka, kupunguza mzigo wa uendeshaji na kuharakisha matumizi ya AI.

- Uendeshaji wa seva za MCP ulioendeshwa kikamilifu na upanuzi, ufuatiliaji, na usalama vilivyojengwa ndani  
- Uunganishaji wa asili na Azure OpenAI, Azure AI Search, na huduma nyingine za Azure  
- Uthibitishaji na idhini ya biashara kupitia Microsoft Entra ID  
- Msaada kwa zana maalum, templeti za maelekezo, na viunganishi vya rasilimali  
- Ufuataji wa usalama wa biashara na mahitaji ya kanuni  

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
- Kupunguza muda wa kupata thamani kwa miradi ya AI ya biashara kwa kutoa jukwaa la seva za MCP linalotegemewa na linalofuata sheria  
- Kuwezesha uunganishaji rahisi wa LLM, zana, na vyanzo vya data vya biashara  
- Kuimarisha usalama, ufuatiliaji, na ufanisi wa uendeshaji kwa mizigo ya MCP  

**Marejeleo:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Tafiti ya Kesi 6: NLWeb  
MCP (Model Context Protocol) ni itifaki inayojitokeza kwa Chatbots na wasaidizi wa AI kuingiliana na zana. Kila mfano wa NLWeb pia ni seva ya MCP, inayounga mkono njia moja kuu, ask, inayotumika kuuliza tovuti swali kwa lugha ya asili. Jibu linalorejeshwa linatumia schema.org, msamiati unaotumika sana kwa kuelezea data za wavuti. Kwa kifupi, MCP ni NLWeb kama Http ilivyo kwa HTML. NLWeb huunganisha itifaki, muundo wa Schema.org, na mifano ya msimbo kusaidia tovuti kuunda haraka vituo hivi, vinavyonufaisha wanadamu kupitia kiolesura cha mazungumzo na mashine kupitia mwingiliano wa mawakala kwa mawakala kwa lugha ya asili.

Kuna vipengele viwili tofauti vya NLWeb.  
- Itifaki, rahisi kuanzia nayo, ya kuingiliana na tovuti kwa lugha ya asili na muundo, ikitumia json na schema.org kwa jibu linalorejeshwa. Angalia nyaraka za REST API kwa maelezo zaidi.  
- Utekelezaji rahisi wa (1) unaotumia alama zilizopo, kwa tovuti zinazoweza kufupishwa kama orodha za vitu (bidhaa, mapishi, vivutio, mapitio, n.k.). Pamoja na seti ya vidhibiti vya kiolesura cha mtumiaji, tovuti zinaweza kutoa kwa urahisi violesura vya mazungumzo kwa maudhui yao. Angalia nyaraka za Life of a chat query kwa maelezo zaidi jinsi inavyofanya kazi.  

**Marejeleo:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Tafiti ya Kesi 7: MCP kwa Foundry – Kuunganisha Wakala wa Azure AI

Seva za Azure AI Foundry MCP zinaonyesha jinsi MCP inavyoweza kutumika kuandaa na kusimamia mawakala wa AI na michakato ya kazi katika mazingira ya biashara. Kwa kuunganisha MCP na Azure AI Foundry, mashirika yanaweza kuweka viwango vya mwingiliano wa mawakala, kutumia usimamizi wa michakato ya Foundry, na kuhakikisha utoaji salama na unaoweza kupanuka. Njia hii inaruhusu uundaji wa haraka wa mifano, ufuatiliaji thabiti, na uunganishaji usio na mshono na huduma za Azure AI, ikisaidia hali za juu kama usimamizi wa maarifa na tathmini ya mawakala. Waendelezaji wanapata kiolesura kimoja cha kujenga, kuanzisha, na kufuatilia mizunguko ya mawakala, wakati timu za IT zinapata usalama ulioboreshwa, ufuataji wa sheria, na ufanisi wa uendeshaji. Suluhisho hili ni bora kwa mashirika yanayotaka kuharakisha matumizi ya AI na kudumisha udhibiti juu ya michakato tata inayosimamiwa na mawakala.

**Marejeleo:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Tafiti ya Kesi 8: Foundry MCP Playground – Jaribio na Uundaji wa Mifano

Foundry MCP Playground hutoa mazingira tayari kwa matumizi kwa ajili ya kujaribu seva za MCP na uunganishaji wa Azure AI Foundry. Waendelezaji wanaweza haraka kuunda mifano, kupima, na kutathmini mifano ya AI na michakato ya mawakala kwa kutumia rasilimali kutoka Azure AI Foundry Catalog na Labs. Playground hii inarahisisha usanidi, hutoa miradi ya mfano, na inaunga mkono maendeleo ya pamoja, ikifanya iwe rahisi kuchunguza mbinu bora na hali mpya kwa gharama ndogo. Ni muhimu hasa kwa timu zinazotaka kuthibitisha mawazo, kushiriki majaribio, na kuharakisha kujifunza bila hitaji la miundombinu tata. Kwa kupunguza vizingiti vya kuingia, playground husaidia kukuza ubunifu na michango ya jamii katika mfumo wa MCP na Azure AI Foundry.

**Marejeleo:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### Tafiti ya Kesi 9: Microsoft Docs MCP Server - Kujifunza na Kuongeza Ujuzi  
Microsoft Docs MCP Server hutekeleza seva ya Model Context Protocol (MCP) inayowezesha wasaidizi wa AI kupata nyaraka rasmi za Microsoft kwa wakati halisi. Hufanya utafutaji wa maana dhidi ya nyaraka rasmi za kiufundi za Microsoft.

**Marejeleo:**  
- [Microsoft Learn Docs MCP Server](https://github.com/MicrosoftDocs/mcp)

## Miradi ya Vitendo

### Mradi 1: Jenga Seva ya MCP ya Watoa Huduma Wengi

**Lengo:** Tengeneza seva ya MCP inayoweza kuongoza maombi kwa watoa huduma mbalimbali wa modeli za AI kulingana na vigezo maalum.

**Mahitaji:**  
- Kuunga mkono angalau watoa huduma watatu tofauti wa modeli (mfano, OpenAI, Anthropic, modeli za ndani)  
- Kutekeleza mfumo wa kuongoza maombi kulingana na metadata ya maombi  
- Kuunda mfumo wa usanidi wa kusimamia nyaraka za watoa huduma  
- Ongeza uhifadhi wa muda (caching) kuboresha utendaji na gharama  
- Jenga dashibodi rahisi ya kufuatilia matumizi  

**Hatua za Utekelezaji:**  
1. Tengeneza miundombinu ya msingi ya seva ya MCP  
2. Tekeleza adapta za watoa huduma kwa kila huduma ya modeli ya AI  
3. Tengeneza mantiki ya kuongoza maombi kulingana na sifa za maombi  
4. Ongeza mifumo ya uhifadhi wa maombi yanayojirudia mara kwa mara  
5. Tengeneza dashibodi ya ufuatiliaji  
6. Fanya majaribio na mifumo mbalimbali ya maombi  

**Teknolojia:** Chagua kati ya Python (.NET/Java/Python kulingana na upendeleo wako), Redis kwa uhifadhi wa muda, na mfumo rahisi wa wavuti kwa dashibodi.

### Mradi 2: Mfumo wa Usimamizi wa Maelekezo wa Biashara

**Lengo:** Tengeneza mfumo unaotegemea MCP wa kusimamia, kuweka toleo, na kuanzisha templeti za maelekezo katika shirika.

**Mahitaji:**  
- Kuunda hifadhi kuu ya templeti za maelekezo  
- Kutekeleza mfumo wa kuweka toleo na mchakato wa idhini  
- Kujenga uwezo wa kupima templeti kwa kutumia maingizo ya mfano  
- Kuendeleza udhibiti wa upatikanaji kulingana na majukumu  
- Kuunda API ya kupata na kuanzisha templeti  

**Hatua za Utekelezaji:**  
1. Buni skimu ya hifadhidata kwa ajili ya kuhifadhi templeti  
2. Tengeneza API kuu ya shughuli za CRUD kwa templeti  
3. Tekeleza mfumo wa kuweka toleo  
4. Jenga mchakato wa idhini  
5. Tengeneza mfumo wa upimaji  
6. Unda kiolesura rahisi cha wavuti kwa usimamizi  
7. Unganisha na seva ya MCP  

**Teknolojia:** Chagua mfumo wa nyuma unaotaka, hifadhidata ya SQL au NoSQL, na mfumo wa mbele kwa kiolesura cha usimamizi.

### Mradi 3: Jukwaa la Uundaji wa Maudhui Linalotegemea MCP

**Lengo:** Jenga jukwaa la uundaji wa maudhui linalotumia MCP kutoa matokeo thabiti kwa aina mbalimbali za maudhui.

**Mahitaji:**  
- Kuunga mkono aina mbalimbali za maudhui (makala za blogu, mitandao ya kijamii, nakala za masoko)  
- Kutekeleza uundaji unaotegemea templeti na chaguzi za kubinafsisha  
- Kuunda mfumo wa mapitio na maoni ya maudhui  
- Kufuatilia vipimo vya utendaji wa maudhui  
- Kuunga mkono kuweka toleo na mchakato wa marekebisho  

**Hatua za Utekelezaji:**  
1. Tengeneza miundombinu ya mteja wa MCP  
2. Unda templeti kwa aina mbalimbali za maudhui  
3. Jenga mchakato wa uundaji wa maudhui  
4. Tekeleza mfumo wa mapitio  
5. Tengeneza mfumo wa kufuatilia vipimo  
6. Unda kiolesura cha mtumiaji kwa usimamizi wa templeti na uundaji wa maudhui  

**Teknolojia:** Lugha ya programu unayopendelea, mfumo wa wavuti, na mfumo wa hifadhidata.

## Mwelekeo wa Baadaye wa Teknolojia ya MCP

### Mwelekeo Unaojitokeza

1. **MCP ya Multi-Modal**  
   - Upanuzi wa MCP kuweka viwango vya mwingiliano na mifano ya picha, sauti, na video  
   - Maendeleo ya uwezo wa kufikiri kwa njia za modal mbalimbali  
   - Miundo ya maelekezo iliyopangwa kwa modal mbalimbali  

2. **Miundombinu ya MCP ya Kuweka Pamoja (Federated)**  
   - Mitandao ya MCP inayosambazwa inayoweza kushirikiana rasilimali kati ya mashirika  
   - Itifaki za viwango vya usalama wa kushirikiana kwa mifano  
   - Mbinu za kuhifadhi faragha katika mahesabu  

3. **Soko la MCP**  
   -
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Ukurasa wa kuingia kwa utekelezaji wa Remote MCP Server katika Azure Functions pamoja na viungo vya repos kwa lugha tofauti  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Kiolezo cha kuanza haraka cha kujenga na kupeleka seva za MCP za mbali zilizobinafsishwa kwa kutumia Azure Functions na Python  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Kiolezo cha kuanza haraka cha kujenga na kupeleka seva za MCP za mbali zilizobinafsishwa kwa kutumia Azure Functions na .NET/C#  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Kiolezo cha kuanza haraka cha kujenga na kupeleka seva za MCP za mbali zilizobinafsishwa kwa kutumia Azure Functions na TypeScript  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Azure API Management kama AI Gateway kwa seva za Remote MCP kwa kutumia Python  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - Maajaribio ya APIM ❤️ AI ikijumuisha uwezo wa MCP, ikishirikiana na Azure OpenAI na AI Foundry  

Hizi repositori zinatoa utekelezaji mbalimbali, violezo, na rasilimali za kufanya kazi na Model Context Protocol katika lugha tofauti za programu na huduma za Azure. Zinashughulikia matumizi mbalimbali kuanzia utekelezaji wa seva za msingi hadi uthibitishaji, uenezaji wa wingu, na hali za ushirikiano wa biashara.  

#### Katalogi ya Rasilimali za MCP  

[Katalogi ya Rasilimali za MCP](https://github.com/microsoft/mcp/tree/main/Resources) katika repositori rasmi ya Microsoft MCP hutoa mkusanyiko ulioratibiwa wa rasilimali za mfano, violezo vya maelekezo, na ufafanuzi wa zana kwa matumizi na seva za Model Context Protocol. Katalogi hii imeundwa kusaidia watengenezaji kuanza haraka na MCP kwa kutoa vipande vinavyoweza kutumika tena na mifano ya mbinu bora kwa:  

- **Violezo vya Maelekezo:** Violezo tayari kutumia kwa kazi na hali za AI zinazojirudia, ambavyo vinaweza kubadilishwa kwa utekelezaji wako wa seva za MCP.  
- **Ufafanuzi wa Zana:** Mifano ya skimu za zana na metadata ili kuweka viwango vya ushirikiano na kuitwa kwa zana katika seva tofauti za MCP.  
- **Mifano ya Rasilimali:** Ufafanuzi wa rasilimali za mfano kwa kuunganishwa na vyanzo vya data, API, na huduma za nje ndani ya mfumo wa MCP.  
- **Utekelezaji wa Marejeleo:** Mifano ya vitendo inayoonyesha jinsi ya kupanga na kuandaa rasilimali, maelekezo, na zana katika miradi halisi ya MCP.  

Rasilimali hizi huchochea maendeleo, kuhimiza viwango, na kusaidia kuhakikisha mbinu bora wakati wa kujenga na kupeleka suluhisho za MCP.  

#### Katalogi ya Rasilimali za MCP  
- [Rasilimali za MCP (Maelekezo ya Mfano, Zana, na Ufafanuzi wa Rasilimali)](https://github.com/microsoft/mcp/tree/main/Resources)  

### Fursa za Utafiti  

- Mbinu bora za kuboresha maelekezo ndani ya mifumo ya MCP  
- Mifano ya usalama kwa uenezaji wa MCP wenye wamiliki wengi  
- Kupima utendaji kati ya utekelezaji tofauti wa MCP  
- Mbinu rasmi za uhakiki kwa seva za MCP  

## Hitimisho  

Model Context Protocol (MCP) inaendelea kuunda mustakabali wa ushirikiano wa AI uliowekwa viwango, salama, na unaoweza kuunganishwa katika sekta mbalimbali. Kupitia tafiti za kesi na miradi ya vitendo katika somo hili, umeona jinsi watumiaji wa mapema—pamoja na Microsoft na Azure—wanavyotumia MCP kutatua changamoto halisi, kuharakisha matumizi ya AI, na kuhakikisha ufuataji, usalama, na upanuzi. Mbinu ya moduli ya MCP inawawezesha mashirika kuunganisha mifano mikubwa ya lugha, zana, na data za biashara katika mfumo mmoja unaoweza kufuatiliwa. MCP inapoendelea kukua, kushiriki na jamii, kuchunguza rasilimali za chanzo huria, na kutumia mbinu bora kutakuwa muhimu katika kujenga suluhisho thabiti za AI zenye mwelekeo wa baadaye.  

## Rasilimali Zaidi  

- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Foundry MCP Playground](https://github.com/azure-ai-foundry/foundry-mcp-playground)  
- [Kuingiza Wakala wa Azure AI na MCP (Blogu ya Microsoft Foundry)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)  
- [MCP GitHub Repository (Microsoft)](https://github.com/microsoft/mcp)  
- [Katalogi ya Rasilimali za MCP (Maelekezo ya Mfano, Zana, na Ufafanuzi wa Rasilimali)](https://github.com/microsoft/mcp/tree/main/Resources)  
- [Jamii na Nyaraka za MCP](https://modelcontextprotocol.io/introduction)  
- [Nyaraka za Azure MCP](https://aka.ms/azmcp)  
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
- [Suluhisho za AI na Uendeshaji wa Microsoft](https://azure.microsoft.com/en-us/products/ai-services/)  

## Mazoezi  

1. Changanua moja ya tafiti za kesi na pendekeza njia mbadala ya utekelezaji.  
2. Chagua moja ya mawazo ya mradi na tengeneza maelezo ya kiufundi kwa undani.  
3. Fanya utafiti wa sekta ambayo haijashughulikiwa katika tafiti za kesi na eleza jinsi MCP inaweza kushughulikia changamoto zake maalum.  
4. Chunguza moja ya mwelekeo wa baadaye na tengeneza dhana ya nyongeza mpya ya MCP kusaidia hilo.  

Ifuatayo: [Mbinu Bora](../08-BestPractices/README.md)

**Kiarifu cha Kutotegemea**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inapendekezwa. Hatubebei dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.