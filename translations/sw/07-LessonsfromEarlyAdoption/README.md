<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-06-13T17:31:02+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "sw"
}
-->
# Masomo Kutoka kwa Watumiaji wa Mapema

## Muhtasari

Somo hili linaangazia jinsi watumiaji wa mapema walivyotumia Model Context Protocol (MCP) kutatua changamoto halisi na kuendesha ubunifu katika sekta mbalimbali. Kupitia tafiti za kina na miradi ya vitendo, utaona jinsi MCP inavyowezesha ujumuishaji wa AI ulio na viwango, usalama, na unaoweza kupanuka—kuunganisha mifano mikubwa ya lugha, zana, na data za biashara ndani ya mfumo mmoja. Utapata uzoefu wa kuunda na kutengeneza suluhisho za MCP, kujifunza kutoka kwa mifumo iliyothibitishwa, na kugundua mbinu bora za kuanzisha MCP katika mazingira ya uzalishaji. Somo pia linaangazia mwenendo mpya, mwelekeo wa baadaye, na rasilimali za chanzo wazi zitakazokusaidia kubaki mstari wa mbele katika teknolojia ya MCP na ekosistimu yake inayobadilika.

## Malengo ya Kujifunza

- Kuchambua utekelezaji halisi wa MCP katika sekta mbalimbali  
- Kuunda na kutengeneza programu kamili zinazotumia MCP  
- Kuchunguza mwenendo mpya na mwelekeo wa teknolojia ya MCP  
- Kutumia mbinu bora katika mazingira halisi ya maendeleo  

## Utekelezaji Halisi wa MCP

### Tafiti ya Kesi 1: Uendeshaji wa Huduma kwa Wateja wa Biashara Kubinafsi

Kampuni ya kimataifa ilitekeleza suluhisho la MCP ili kuweka viwango katika mwingiliano wa AI katika mifumo yao ya huduma kwa wateja. Hii iliwaruhusu:

- Kuunda kiolesura kimoja kwa watoa huduma mbalimbali wa LLM  
- Kudumisha usimamizi thabiti wa maelekezo (prompts) katika idara zote  
- Kutekeleza udhibiti thabiti wa usalama na ufuatiliaji wa sheria  
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

**Matokeo:** Kupunguza gharama za mifano kwa 30%, kuboresha uthabiti wa majibu kwa 45%, na kuongeza ufuatiliaji wa utimilifu katika shughuli za kimataifa.

### Tafiti ya Kesi 2: Msaidizi wa Utambuzi wa Afya

Mtoa huduma wa afya alitengeneza miundombinu ya MCP kuunganisha mifano mingi maalum ya AI ya matibabu huku akihakikisha data nyeti za wagonjwa zinabaki salama:

- Kubadilisha kwa urahisi kati ya mifano ya matibabu ya jumla na maalum  
- Udhibiti mkali wa faragha na rekodi za ufuatiliaji  
- Uunganisho na mifumo ya Rekodi za Afya za Kielektroniki (EHR) iliyopo  
- Usimamizi thabiti wa maelekezo kwa istilahi za matibabu  

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

**Matokeo:** Kuboresha mapendekezo ya utambuzi kwa madaktari huku ikidumisha utimilifu wa HIPAA na kupunguza kwa kiasi kikubwa mabadiliko ya muktadha kati ya mifumo.

### Tafiti ya Kesi 3: Uchambuzi wa Hatari katika Huduma za Fedha

Taasis ya kifedha ilitekeleza MCP kuweka viwango katika michakato yao ya uchambuzi wa hatari katika idara mbalimbali:

- Kuunda kiolesura kimoja kwa mifano ya hatari ya mikopo, kugundua udanganyifu, na hatari za uwekezaji  
- Kutekeleza udhibiti mkali wa upatikanaji na matoleo ya mifano  
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

**Matokeo:** Kuimarisha utimilifu wa kanuni, kuharakisha mizunguko ya utoaji mifano kwa 40%, na kuboresha uthabiti wa tathmini ya hatari katika idara.

### Tafiti ya Kesi 4: Microsoft Playwright MCP Server kwa Uendeshaji wa Vivinjari

Microsoft ilitengeneza [Playwright MCP server](https://github.com/microsoft/playwright-mcp) kuwezesha uendeshaji wa vivinjari kwa usalama na viwango kupitia Model Context Protocol. Suluhisho hili huruhusu maajenti wa AI na LLM kuingiliana na vivinjari vya wavuti kwa njia iliyodhibitiwa, inayoambatana na ufuatiliaji na inayoweza kupanuliwa—ikisaidia matumizi kama vile upimaji wa wavuti wa kiotomatiki, uchukuaji wa data, na michakato kamili.

- Inaonyesha uwezo wa uendeshaji vivinjari (kuvinjari, kujaza fomu, kupiga picha za skrini, n.k.) kama zana za MCP  
- Inatekeleza udhibiti mkali wa upatikanaji na sandboxing kuzuia vitendo visivyoidhinishwa  
- Inatoa rekodi za kina za ufuatiliaji wa mwingiliano yote wa kivinjari  
- Inaunga mkono uunganisho na Azure OpenAI na watoa huduma wengine wa LLM kwa uendeshaji wa maajenti  

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
- Kuwezesha uendeshaji wa vivinjari kwa usalama kwa maajenti wa AI na LLM  
- Kupunguza juhudi za upimaji wa mikono na kuboresha upana wa upimaji wa programu za wavuti  
- Kutoa mfumo unaoweza kutumika tena na kupanuliwa kwa uunganisho wa zana za kivinjari katika mazingira ya biashara  

**Marejeleo:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Tafiti ya Kesi 5: Azure MCP – Model Context Protocol ya Kiwango cha Biashara kama Huduma

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) ni utekelezaji wa Microsoft wa kiwango cha biashara wa Model Context Protocol, ulioundwa kutoa uwezo wa seva za MCP zinazoweza kupanuka, salama, na zinazoendana na kanuni kama huduma ya wingu. Azure MCP inawawezesha mashirika kuanzisha, kusimamia, na kuunganisha seva za MCP na huduma za Azure AI, data, na usalama haraka, kupunguza mzigo wa uendeshaji na kuharakisha matumizi ya AI.

- Uendeshaji wa seva za MCP zilizosimamiwa kikamilifu zenye upanuzi, ufuatiliaji, na usalama wa ndani  
- Uunganisho wa asili na Azure OpenAI, Azure AI Search, na huduma nyingine za Azure  
- Uthibitishaji na idhini za biashara kupitia Microsoft Entra ID  
- Msaada kwa zana maalum, templeti za maelekezo, na viunganishi vya rasilimali  
- Uzingatiaji wa usalama wa biashara na mahitaji ya kanuni  

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
- Kupunguza muda wa kupata thamani kwa miradi ya AI ya biashara kwa kutoa jukwaa la seva za MCP linalotumika moja kwa moja na linaendana na kanuni  
- Kurahisisha ujumuishaji wa LLM, zana, na vyanzo vya data vya biashara  
- Kuongeza usalama, ufuatiliaji, na ufanisi wa uendeshaji kwa mizigo ya MCP  

**Marejeleo:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Tafiti ya Kesi 6: NLWeb  
MCP (Model Context Protocol) ni itifaki inayoibuka kwa Chatbots na wasaidizi wa AI kuingiliana na zana. Kila mfano wa NLWeb pia ni seva ya MCP, inayounga mkono njia moja kuu, ask, inayotumika kuuliza tovuti swali kwa lugha ya kawaida. Jibu linalorudishwa linatumia schema.org, msamiati maarufu wa kuelezea data za wavuti. Kwa kifupi, MCP ni NLWeb kama Http ilivyo kwa HTML. NLWeb huunganisha itifaki, muundo wa Schema.org, na mfano wa msimbo kusaidia tovuti kuunda haraka vituo hivi, vinavyonufaisha watu kupitia kiolesura cha mazungumzo na mashine kupitia mwingiliano wa maajenti kwa maajenti wa asili.

Kuna sehemu mbili tofauti za NLWeb.  
- Itifaki rahisi kuanzia, ya kuingiliana na tovuti kwa lugha ya kawaida na muundo unaotumia json na schema.org kwa jibu linalorejeshwa. Angalia nyaraka za REST API kwa maelezo zaidi.  
- Utekelezaji rahisi wa (1) unaotumia alama zilizopo, kwa tovuti zinazoweza kufupishwa kama orodha za vitu (bidhaa, mapishi, vivutio, mapitio, n.k.). Pamoja na seti ya vidhibiti vya kiolesura cha mtumiaji, tovuti zinaweza kutoa kiolesura cha mazungumzo kwa maudhui yao kwa urahisi. Angalia nyaraka za Life of a chat query kwa maelezo zaidi jinsi inavyofanya kazi.  

**Marejeleo:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Tafiti ya Kesi 7: MCP kwa Foundry – Kuunganisha Maajenti wa Azure AI

Seva za Azure AI Foundry MCP zinaonyesha jinsi MCP inavyoweza kutumika kuratibu na kusimamia maajenti wa AI na michakato katika mazingira ya biashara. Kwa kuunganisha MCP na Azure AI Foundry, mashirika yanaweza kuweka viwango vya mwingiliano wa maajenti, kutumia usimamizi wa michakato wa Foundry, na kuhakikisha usalama na upanuzi wa uanzishaji. Njia hii inaruhusu prototyping ya haraka, ufuatiliaji thabiti, na ujumuishaji usio na mshono na huduma za Azure AI, ikisaidia matukio ya hali ya juu kama usimamizi wa maarifa na tathmini ya maajenti. Waendelezaji wanapata kiolesura kimoja cha kujenga, kuanzisha, na kufuatilia mitiririko ya maajenti, huku timu za IT zikipata usalama ulioboreshwa, utimilifu, na ufanisi wa uendeshaji. Suluhisho hili ni bora kwa mashirika yanayotaka kuharakisha matumizi ya AI na kudhibiti michakato tata inayotegemea maajenti.

**Marejeleo:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Tafiti ya Kesi 8: Foundry MCP Playground – Jaribio na Uundaji Mifano

Foundry MCP Playground hutoa mazingira tayari kwa kutumia kwa majaribio ya seva za MCP na ujumuishaji wa Azure AI Foundry. Waendelezaji wanaweza haraka kuunda mifano, kupima, na kutathmini mifano ya AI na mitiririko ya maajenti kwa kutumia rasilimali kutoka Azure AI Foundry Catalog na Labs. Playground inarahisisha usanidi, hutoa miradi ya mfano, na inaunga mkono maendeleo ya pamoja, ikifanya iwe rahisi kuchunguza mbinu bora na matukio mapya kwa gharama ndogo. Ni muhimu hasa kwa timu zinazotaka kuthibitisha mawazo, kushiriki majaribio, na kuharakisha kujifunza bila hitaji la miundombinu tata. Kwa kupunguza vizingiti, playground husaidia kuendeleza ubunifu na michango ya jamii katika ekosistimu ya MCP na Azure AI Foundry.

**Marejeleo:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### Tafiti ya Kesi 9: Microsoft Docs MCP Server - Kujifunza na Kuendeleza Ujuzi  
Microsoft Docs MCP Server hutekeleza seva ya Model Context Protocol (MCP) inayowawezesha wasaidizi wa AI kupata nyaraka rasmi za Microsoft kwa wakati halisi. Hufanya utafutaji wa maana dhidi ya nyaraka rasmi za kiufundi za Microsoft.

**Marejeleo:**  
- [Microsoft Learn Docs MCP Server](https://github.com/MicrosoftDocs/mcp)

## Miradi ya Vitendo

### Mradi 1: Jenga Seva ya MCP ya Watoa Huduma Wengi

**Lengo:** Tengeneza seva ya MCP inayoweza kupitisha maombi kwa watoa huduma wa mifano ya AI wengi kulingana na vigezo maalum.

**Mahitaji:**  
- Kuunga mkono angalau watoa huduma watatu wa mifano tofauti (mfano, OpenAI, Anthropic, mifano ya ndani)  
- Kutekeleza njia ya kupitisha maombi kulingana na metadata ya maombi  
- Kuunda mfumo wa kusanidi usimamizi wa nyaraka za watoa huduma  
- Kuongeza caching ili kuboresha utendaji na kupunguza gharama  
- Kutengeneza dashibodi rahisi ya kufuatilia matumizi  

**Hatua za Utekelezaji:**  
1. Anzisha miundombinu ya msingi ya seva ya MCP  
2. Tengeneza adapters za watoa huduma kwa kila huduma ya modeli ya AI  
3. Unda mantiki ya kupitisha maombi kulingana na sifa za maombi  
4. Ongeza caching kwa maombi yanayojirudia mara kwa mara  
5. Tengeneza dashibodi ya ufuatiliaji  
6. Fanya majaribio kwa mifumo mbalimbali ya maombi  

**Teknolojia:** Chagua kati ya Python (.NET/Java/Python kulingana na upendeleo wako), Redis kwa caching, na mfumo rahisi wa wavuti kwa dashibodi.

### Mradi 2: Mfumo wa Usimamizi wa Maelekezo wa Biashara

**Lengo:** Tengeneza mfumo unaotumia MCP wa kusimamia, kuweka matoleo, na kupeleka templeti za maelekezo katika shirika.

**Mahitaji:**  
- Tengeneza hazina kuu ya templeti za maelekezo  
- Tekeleza mfumo wa kuweka matoleo na taratibu za idhini  
- Jenga uwezo wa kujaribu templeti kwa ingizo za mfano  
- Tengeneza udhibiti wa upatikanaji kulingana na majukumu  
- Unda API ya kupata na kupeleka templeti  

**Hatua za Utekelezaji:**  
1. Buni skimu ya hifadhidata kwa ajili ya kuhifadhi templeti  
2. Tengeneza API kuu kwa shughuli za CRUD za templeti  
3. Tekeleza mfumo wa kuweka matoleo  
4. Jenga taratibu za idhini  
5. Tengeneza mfumo wa majaribio  
6. Unda kiolesura rahisi cha wavuti kwa usimamizi  
7. Unganisha na seva ya MCP  

**Teknolojia:** Chagua mfumo wa nyuma, hifadhidata ya SQL au NoSQL, na mfumo wa mbele kwa kiolesura cha usimamizi.

### Mradi 3: Jukwaa la Uundaji Maudhui Linalotumia MCP

**Lengo:** Tengeneza jukwaa la uundaji maudhui linalotumia MCP kutoa matokeo thabiti kwa aina mbalimbali za maudhui.

**Mahitaji:**  
- Kuunga mkono aina mbalimbali za maudhui (makala za blogu, mitandao ya kijamii, nakala za masoko)  
- Tekeleza uundaji unaotegemea templeti na chaguzi za kubinafsisha  
- Tengeneza mfumo wa uhakiki na mrejesho wa maudhui  
- Fuata takwimu za utendaji wa maudhui  
- Kuunga mkono kuweka matoleo na mchakato wa marekebisho  

**Hatua za Utekelezaji:**  
1. Anzisha miundombinu ya mteja wa MCP  
2. Tengeneza templeti kwa aina tofauti za maudhui  
3. Jenga mtiririko wa uundaji maudhui  
4. Tekeleza mfumo wa uhakiki  
5. Tengeneza mfumo wa kufuatilia takwimu  
6. Unda kiolesura cha mtumiaji kwa usimamizi wa templeti na uundaji maudhui  

**Teknolojia:** Lugha unayopendelea ya programu, mfumo wa wavuti, na mfumo wa hifadhidata.

## Mwelekeo wa Baadaye wa Teknolojia ya MCP

### Mwenendo Mipya

1. **MCP ya Multi-Modal**  
   - Kuongeza MCP kuweka viwango vya mwingiliano na mifano ya picha, sauti, na video  
   - Kuendeleza uwezo wa kufikiri kwa njia za modaliti mbalimbali  
   - Muundo wa maelekezo uliowekwa viwango kwa modaliti tofauti  

2. **Miundombinu ya MCP ya Kuweka Kitanzi**  
   - Mitandao ya MCP iliyogawanyika inayoweza kushirikiana rasilimali kati ya mashirika  
   - Itifaki za viwango vya kushirikiana mifano kwa usalama  
   - Mbinu za kuhifadhi faragha katika hesabu  

3. **Masoko ya MCP**  
   - Mfumo wa kushiriki na kupata kipato kwa templeti na viendelezi vya MCP  
   - Mchakato wa uhakiki na vyeti vya ubora  
   - Uunganisho na masoko ya mifano  

4. **MCP kwa Kompyuta za Edge**  
   - Kurekebisha viwango vya MCP kwa
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

## Mazoezi

1. Changanua mojawapo ya tafiti za kesi na pendekeza njia mbadala ya utekelezaji.
2. Chagua moja ya mawazo ya mradi na tengeneza maelezo ya kiufundi kwa kina.
3. Fanya utafiti wa sekta ambayo haijajumuishwa katika tafiti za kesi na eleza jinsi MCP ingeweza kushughulikia changamoto zake maalum.
4. Chunguza moja ya mwelekeo wa baadaye na unda dhana ya nyongeza mpya ya MCP kuunga mkono hilo.

Ifuatayo: [Best Practices](../08-BestPractices/README.md)

**Kiarushi**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati asili katika lugha yake ya asili inapaswa kuzingatiwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inapendekezwa. Hatubeba dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.