<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1ccfe1a6ea77e42862b92ae53cb6cddf",
  "translation_date": "2025-05-20T17:53:55+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "sw"
}
-->
# Masomo kutoka kwa Watumiaji wa Mapema

## Muhtasari

Somo hili linaangazia jinsi watumiaji wa mapema walivyotumia Model Context Protocol (MCP) kutatua changamoto halisi na kuendesha ubunifu katika sekta mbalimbali. Kupitia tafiti za kina za kesi na miradi ya vitendo, utaona jinsi MCP inavyowezesha ushirikiano wa AI unaoendana na viwango, salama, na unaoweza kupanuka—kuunganisha mifano mikubwa ya lugha, zana, na data za kampuni katika mfumo mmoja. Utapata uzoefu wa kutengeneza na kujenga suluhisho zinazotegemea MCP, kujifunza kutoka kwa mifumo iliyothibitishwa, na kugundua mbinu bora za kutumia MCP katika mazingira ya uzalishaji. Somo pia linaangazia mwenendo unaojitokeza, mwelekeo wa baadaye, na rasilimali za chanzo huria kusaidia kubaki mstari wa mbele wa teknolojia ya MCP na mazingira yake yanayobadilika.

## Malengo ya Kujifunza

- Kuchambua utekelezaji halisi wa MCP katika sekta mbalimbali
- Kubuni na kujenga programu kamili zinazotegemea MCP
- Kuchunguza mwenendo unaojitokeza na mwelekeo wa baadaye katika teknolojia ya MCP
- Kutumia mbinu bora katika mazingira halisi ya maendeleo

## Utekelezaji Halisi wa MCP

### Tafiti ya Kesi 1: Uendeshaji wa Huduma kwa Wateja wa Kampuni kwa Mfumo wa Kiotomatiki

Kampuni ya kimataifa ilitekeleza suluhisho linalotegemea MCP ili kuweka viwango vya ushirikiano wa AI katika mifumo yao ya huduma kwa wateja. Hii iliwaruhusu:

- Kuunda kiolesura kimoja kwa watoa huduma mbalimbali wa LLM
- Kudumisha usimamizi wa maelekezo (prompt) unaoendana katika idara zote
- Kutekeleza udhibiti thabiti wa usalama na ufuatiliaji wa sheria
- Kubadilisha kwa urahisi kati ya mifano tofauti ya AI kulingana na mahitaji maalum

**Utekelezaji wa Kifundi:**  
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

**Matokeo:** Kupunguza gharama za modeli kwa 30%, kuboresha uthabiti wa majibu kwa 45%, na kuongeza ufuatiliaji wa utimilifu katika shughuli za kimataifa.

### Tafiti ya Kesi 2: Msaidizi wa Uchunguzi wa Afya

Mtoa huduma wa afya alitengeneza miundombinu ya MCP kuunganisha mifano mbalimbali maalum ya AI ya matibabu huku akihakikisha data nyeti za wagonjwa zinabaki salama:

- Kubadilisha kwa urahisi kati ya mifano ya matibabu ya jumla na maalum
- Udhibiti mkali wa faragha na rekodi za ukaguzi
- Kuunganishwa na mifumo ya Rekodi za Afya za Kielektroniki (EHR)
- Usimamizi thabiti wa maelekezo ya istilahi ya matibabu

**Utekelezaji wa Kifundi:**  
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

**Matokeo:** Kuboresha mapendekezo ya uchunguzi kwa madaktari huku ikidumisha utimilifu wa HIPAA na kupunguza sana kubadili muktadha kati ya mifumo.

### Tafiti ya Kesi 3: Uchambuzi wa Hatari katika Huduma za Fedha

Taasisi ya kifedha ilitekeleza MCP kuweka viwango katika michakato yao ya uchambuzi wa hatari katika idara mbalimbali:

- Kuunda kiolesura kimoja kwa mifano ya hatari ya mikopo, utambuzi wa ulaghai, na hatari za uwekezaji
- Kutekeleza udhibiti mkali wa upatikanaji na toleo la modeli
- Kuhakikisha ufuatiliaji wa mapendekezo yote ya AI
- Kudumisha muundo thabiti wa data katika mifumo tofauti

**Utekelezaji wa Kifundi:**  
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

**Matokeo:** Kuimarisha utimilifu wa kanuni, kuharakisha mizunguko ya uzalishaji wa modeli kwa 40%, na kuboresha uthabiti wa tathmini ya hatari katika idara.

### Tafiti ya Kesi 4: Microsoft Playwright MCP Server kwa Uendeshaji wa Vifaa vya Kivinjari

Microsoft ilitengeneza [Playwright MCP server](https://github.com/microsoft/playwright-mcp) kuwezesha uendeshaji salama, uliowekwa viwango wa vivinjari kwa kutumia Model Context Protocol. Suluhisho hili huruhusu mawakala wa AI na LLM kuingiliana na vivinjari vya wavuti kwa njia iliyo na udhibiti, inayoweza kufuatiliwa, na inayoweza kupanuliwa—kusaidia matumizi kama vile upimaji wa wavuti kwa kiotomatiki, uchimbaji wa data, na mchakato wa mwisho hadi mwisho.

- Hutoa uwezo wa uendeshaji wa kivinjari (kuvinjari, kujaza fomu, kupiga picha ya skrini, n.k.) kama zana za MCP
- Kutekeleza udhibiti mkali wa upatikanaji na sandboxing kuzuia vitendo visivyoidhinishwa
- Kutoa rekodi za ukaguzi kwa undani za mwingiliano yote ya kivinjari
- Kusaidia kuunganishwa na Azure OpenAI na watoa huduma wengine wa LLM kwa uendeshaji wa mawakala

**Utekelezaji wa Kifundi:**  
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
- Kuwezesha uendeshaji salama, wa programu wa vivinjari kwa mawakala wa AI na LLM  
- Kupunguza jitihada za upimaji wa mikono na kuboresha usambazaji wa vipimo kwa programu za wavuti  
- Kutoa mfumo unaoweza kutumika tena na kupanuliwa kwa ushirikiano wa zana za kivinjari katika mazingira ya kampuni

**Marejeleo:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Tafiti ya Kesi 5: Azure MCP – Model Context Protocol ya Kiwango cha Kampuni kama Huduma

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) ni utekelezaji wa Microsoft wa MCP wa kiwango cha kampuni, unaosimamiwa, ulioundwa kutoa uwezo wa seva za MCP zinazoweza kupanuka, salama, na zenye utimilifu kama huduma ya wingu. Azure MCP inawawezesha mashirika kupeleka, kusimamia, na kuunganisha seva za MCP haraka na huduma za Azure AI, data, na usalama, kupunguza mzigo wa uendeshaji na kuharakisha matumizi ya AI.

- Uwekaji wa seva za MCP unaosimamiwa kikamilifu na uwezo wa kupanua, kufuatilia, na usalama uliojengwa ndani
- Muunganisho wa asili na Azure OpenAI, Azure AI Search, na huduma nyingine za Azure
- Uthibitishaji na idhini ya kampuni kupitia Microsoft Entra ID
- Msaada kwa zana za kawaida, templeti za maelekezo, na viunganishi vya rasilimali
- Utimilifu wa usalama wa kampuni na mahitaji ya kanuni

**Utekelezaji wa Kifundi:**  
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
- Kupunguza muda wa kupata thamani kwa miradi ya AI ya kampuni kwa kutoa jukwaa la seva za MCP tayari kutumia na zenye utimilifu  
- Kurahisisha kuunganisha LLM, zana, na vyanzo vya data vya kampuni  
- Kuimarisha usalama, ufuatiliaji, na ufanisi wa uendeshaji wa mizigo ya MCP

**Marejeleo:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Tafiti ya Kesi 6: NLWeb

MCP (Model Context Protocol) ni itifaki inayojitokeza kwa Chatbots na wasaidizi wa AI kuingiliana na zana. Kila mfano wa NLWeb pia ni seva ya MCP, inayounga mkono njia kuu moja, ask, inayotumika kuuliza tovuti swali kwa lugha ya kawaida. Jibu linalorudishwa linatumia schema.org, msamiati unaotumika sana wa kuelezea data za wavuti. Kwa kifupi, MCP ni NLWeb kama HTTP ilivyo kwa HTML. NLWeb huunganisha itifaki, muundo wa Schema.org, na mifano ya msimbo kusaidia tovuti kuunda haraka vituo hivi, vinavyosaidia watu kupitia kiolesura cha mazungumzo na mashine kupitia mwingiliano wa mawakala kwa mawakala wa asili.

Kuna vipengele viwili tofauti vya NLWeb:  
- Itifaki rahisi ya kuanzisha, ya kuingiliana na tovuti kwa lugha ya kawaida na muundo unaotumia json na schema.org kwa jibu linalorejeshwa. Angalia nyaraka za REST API kwa maelezo zaidi.  
- Utekelezaji rahisi wa (1) unaotumia alama zilizopo, kwa tovuti zinazoweza kufupishwa kama orodha za vitu (bidhaa, mapishi, vivutio, maoni, n.k.). Pamoja na seti ya vidhibiti vya kiolesura cha mtumiaji, tovuti zinaweza kutoa kwa urahisi kiolesura cha mazungumzo kwa maudhui yao. Angalia nyaraka za Life of a chat query kwa maelezo zaidi juu ya jinsi inavyofanya kazi.

**Marejeleo:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Tafiti ya Kesi 7: MCP kwa Foundry – Kuunganisha Mawakala wa Azure AI

Seva za Azure AI Foundry MCP zinaonyesha jinsi MCP inavyoweza kutumika kuandaa na kusimamia mawakala wa AI na michakato katika mazingira ya kampuni. Kwa kuunganisha MCP na Azure AI Foundry, mashirika yanaweza kuweka viwango vya mwingiliano wa mawakala, kutumia usimamizi wa michakato wa Foundry, na kuhakikisha usambazaji salama, unaoweza kupanuka. Njia hii inaruhusu kuunda haraka mifano, ufuatiliaji thabiti, na kuunganishwa bila mshono na huduma za Azure AI, kusaidia hali za juu kama usimamizi wa maarifa na tathmini ya mawakala. Waendelezaji wanapata kiolesura kimoja cha kujenga, kupeleka, na kufuatilia mizunguko ya mawakala, wakati timu za IT zinapata usalama ulioimarishwa, utimilifu, na ufanisi wa uendeshaji. Suluhisho hili ni bora kwa makampuni yanayotaka kuharakisha matumizi ya AI na kudumisha udhibiti wa michakato tata inayotegemea mawakala.

**Marejeleo:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Tafiti ya Kesi 8: Foundry MCP Playground – Majaribio na Uundaji wa Mifano

Foundry MCP Playground hutoa mazingira tayari kwa matumizi kwa ajili ya kujaribu seva za MCP na kuunganishwa kwa Azure AI Foundry. Waendelezaji wanaweza haraka kuunda mifano, kupima, na kutathmini mifano ya AI na michakato ya mawakala kwa kutumia rasilimali kutoka Azure AI Foundry Catalog na Labs. Playground inarahisisha usanidi, hutoa miradi ya mfano, na inasaidia maendeleo ya pamoja, kufanya iwe rahisi kuchunguza mbinu bora na hali mpya kwa mzigo mdogo. Ni muhimu hasa kwa timu zinazotaka kuthibitisha mawazo, kushiriki majaribio, na kuharakisha kujifunza bila hitaji la miundombinu tata. Kwa kupunguza vizingiti vya kuingia, playground husaidia kukuza ubunifu na michango ya jamii katika MCP na mazingira ya Azure AI Foundry.

**Marejeleo:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

## Miradi ya Vitendo

### Mradi 1: Jenga Seva ya MCP yenye Watoa Huduma Wengi

**Lengo:** Tengeneza seva ya MCP inayoweza kuelekeza maombi kwa watoa huduma mbalimbali wa modeli za AI kulingana na vigezo maalum.

**Mahitaji:**  
- Kuunga mkono watoa huduma angalau watatu tofauti (mfano, OpenAI, Anthropic, modeli za ndani)  
- Kutekeleza mfumo wa kuelekeza maombi kulingana na metadata ya ombi  
- Kuunda mfumo wa usanidi wa kusimamia taarifa za watoa huduma  
- Ongeza caching kuboresha utendaji na kupunguza gharama  
- Jenga dashibodi rahisi ya kufuatilia matumizi

**Hatua za Utekelezaji:**  
1. Andaa miundombinu ya msingi ya seva ya MCP  
2. Tengeneza adapta za watoa huduma kwa kila huduma ya modeli ya AI  
3. Unda mantiki ya kuelekeza maombi kulingana na sifa za maombi  
4. Ongeza mbinu za caching kwa maombi ya mara kwa mara  
5. Tengeneza dashibodi ya ufuatiliaji  
6. Fanya majaribio kwa mifumo mbalimbali ya maombi

**Teknolojia:** Chagua kati ya Python (.NET/Java/Python kulingana na upendeleo wako), Redis kwa caching, na fremu rahisi ya wavuti kwa dashibodi.

### Mradi 2: Mfumo wa Usimamizi wa Maelekezo wa Kampuni

**Lengo:** Tengeneza mfumo unaotegemea MCP wa kusimamia, kuweka toleo, na kupeleka templeti za maelekezo katika shirika.

**Mahitaji:**  
- Tengeneza hifadhi kuu ya templeti za maelekezo  
- Tekeleza mfumo wa kuweka toleo na michakato ya idhini  
- Jenga uwezo wa kujaribu templeti kwa kutumia maingizo ya mfano  
- Tengeneza udhibiti wa upatikanaji kulingana na majukumu  
- Tengeneza API ya upokeaji na upeleka templeti

**Hatua za Utekelezaji:**  
1. Buni skimu ya hifadhidata kwa ajili ya kuhifadhi templeti  
2. Tengeneza API kuu kwa shughuli za CRUD za templeti  
3. Tekeleza mfumo wa kuweka toleo  
4. Jenga mchakato wa idhini  
5. Tengeneza mfumo wa majaribio  
6. Tengeneza kiolesura rahisi cha wavuti kwa usimamizi  
7. Unganisha na seva ya MCP

**Teknolojia:** Chagua fremu ya nyuma, hifadhidata ya SQL au NoSQL, na fremu ya mbele kwa kiolesura cha usimamizi.

### Mradi 3: Jukwaa la Uundaji Maudhui Linalotegemea MCP

**Lengo:** Jenga jukwaa la uundaji maudhui linalotumia MCP kutoa matokeo thabiti kwa aina tofauti za maudhui.

**Mahitaji:**  
- Kuunga mkono aina mbalimbali za maudhui (makala za blog, mitandao ya kijamii, nakala za masoko)  
- Tekeleza uzalishaji unaotegemea templeti na chaguzi za kubadilisha  
- Tengeneza mfumo wa mapitio na maoni ya maudhui  
- Fuata vipimo vya utendaji wa maudhui  
- Kuunga mkono kuweka toleo na mzunguko wa marekebisho ya maudhui

**Hatua za Utekelezaji:**  
1. Andaa miundombinu ya mteja wa MCP  
2. Tengeneza templeti kwa aina tofauti za maudhui  
3. Jenga mchakato wa uzalishaji wa maudhui  
4. Tekeleza mfumo wa mapitio  
5. Tengeneza mfumo wa kufuatilia vipimo  
6. Tengeneza kiolesura cha mtumiaji kwa usimamizi wa templeti na uundaji wa maudhui

**Teknolojia:** Lugha unayopendelea ya programu, fremu ya wavuti, na mfumo wa hifadhidata.

## Mwelekeo wa Baadaye wa Teknolojia ya MCP

### Mwenendo Unaokuja

1. **MCP ya Njia Nyingi (Multi-Modal MCP)**  
   - Upanuzi wa MCP kuweka viwango vya mwingiliano na mifano ya picha, sauti, na video  
   - Maendeleo ya uwezo wa kufikiria kwa njia nyingi  
   - Muundo wa maelekezo uliowekwa viwango kwa aina mbalimbali

2. **Miundombinu ya MCP ya Shirikisho (Federated MCP Infrastructure)**  
   - Mitandao ya MCP isiyojumlishwa inayoweza kushiriki rasilimali kati ya mashirika  
   - Itifaki za viwango vya usalama wa kushirikiana kwa mifano  
   - Mbinu za kuhifadhi faragha katika mahesabu

3. **Soko la MCP (MCP Marketplaces)**  
   - Mifumo ya kushiriki na kupata mapato kwa templeti na programu-jalizi za MCP  
   - Mchakato wa uhakikisho wa ubora na vyeti  
   - Muunganisho na masoko ya mifano

4. **MCP kwa Kompyuta za Edge (MCP for Edge Computing)**  
   - Urekebishaji wa viwango vya MCP kwa vifaa vya edge vyenye rasilimali ndogo  
   - Itifaki zilizoboreshwa kwa mazingira ya mtandao wa chini  
   - Utekelezaji maalum wa MCP kwa mifumo ya IoT

5. **Mifumo ya Kanuni (Regulatory Frameworks)**  
   - Maendeleo ya nyongeza za
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

1. Changanua moja ya masomo ya kesi na pendekeza njia mbadala ya utekelezaji.
2. Chagua moja ya mawazo ya mradi na tengeneza vipimo vya kina vya kiufundi.
3. Fanya utafiti wa sekta ambayo haijajumuishwa katika masomo ya kesi na eleza jinsi MCP inaweza kushughulikia changamoto zake maalum.
4. Chunguza moja ya mwelekeo wa baadaye na tengeneza wazo la nyongeza mpya ya MCP kuunga mkono hilo.

Ifuatayo: [Best Practices](../08-BestPractices/README.md)

**Kiondo**:  
Hati hii imefasiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuhakikisha usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au upotovu wa maana. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu ya binadamu inapendekezwa. Hatuna dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.