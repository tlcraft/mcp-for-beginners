<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "296d5c8913271ef3bd696fd46d998711",
  "translation_date": "2025-05-20T22:14:54+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "sw"
}
-->
# Mafunzo kutoka kwa Watumiaji wa Mapema

## Muhtasari

Somo hili linaangazia jinsi watumiaji wa mapema walivyotumia Model Context Protocol (MCP) kutatua changamoto halisi na kuendesha ubunifu katika sekta mbalimbali. Kupitia tafiti za kina za kesi na miradi ya vitendo, utaona jinsi MCP inavyowezesha ujumuishaji wa AI uliopangwa, salama, na unaoweza kupanuka—kuunganisha mifano mikubwa ya lugha, zana, na data za biashara katika mfumo mmoja. Utapata uzoefu wa kutengeneza na kujenga suluhisho za MCP, kujifunza kutoka kwa mifumo iliyothibitishwa ya utekelezaji, na kugundua mbinu bora za kuanzisha MCP katika mazingira ya uzalishaji. Somo pia linaangazia mwelekeo mpya, mustakabali, na rasilimali za chanzo huria zitakazokusaidia kubaki mstari wa mbele katika teknolojia ya MCP na mazingira yake yanayobadilika.

## Malengo ya Kujifunza

- Kuchambua utekelezaji halisi wa MCP katika sekta mbalimbali
- Kubuni na kujenga programu kamili zinazotegemea MCP
- Kuchunguza mwelekeo mpya na mustakabali wa teknolojia ya MCP
- Kutumia mbinu bora katika hali halisi za maendeleo

## Utekelezaji Halisi wa MCP

### Tafiti za Kesi 1: Uendeshaji wa Huduma kwa Wateja wa Biashara kwa Kujitegemea

Kampuni ya kimataifa ilitekeleza suluhisho la MCP ili kuweka viwango vya mawasiliano ya AI katika mifumo yao ya huduma kwa wateja. Hii iliwaruhusu:

- Kuunda kiolesura kimoja kwa watoa huduma mbalimbali wa LLM
- Kudumisha usimamizi thabiti wa maagizo katika idara zote
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

**Matokeo:** Kupungua kwa gharama za modeli kwa 30%, kuboresha uthabiti wa majibu kwa 45%, na kuimarisha ufuatiliaji wa sheria katika shughuli za kimataifa.

### Tafiti za Kesi 2: Msaidizi wa Uchunguzi wa Afya

Mtoa huduma wa afya alitengeneza miundombinu ya MCP kuunganisha mifano mingi maalum ya AI ya matibabu huku akihakikisha data nyeti za wagonjwa zinabaki salama:

- Kubadilisha kwa urahisi kati ya mifano ya matibabu ya jumla na maalum
- Udhibiti mkali wa faragha na rekodi za ukaguzi
- Uunganishaji na mifumo ya Rekodi za Afya za Kielektroniki (EHR)
- Usimamizi thabiti wa maagizo kwa istilahi za matibabu

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

**Matokeo:** Kuboresha mapendekezo ya uchunguzi kwa madaktari huku ukizingatia kikamilifu HIPAA na kupunguza kwa kiasi kikubwa mabadiliko ya muktadha kati ya mifumo.

### Tafiti za Kesi 3: Uchambuzi wa Hatari katika Huduma za Fedha

Taasisi ya kifedha ilitekeleza MCP kuweka viwango vya michakato yao ya uchambuzi wa hatari katika idara mbalimbali:

- Kuunda kiolesura kimoja kwa mifano ya hatari ya mikopo, kugundua udanganyifu, na hatari za uwekezaji
- Kutekeleza udhibiti mkali wa upatikanaji na matoleo ya modeli
- Kuhakikisha ufuatiliaji wa mapendekezo yote ya AI
- Kudumisha muundo thabiti wa data kati ya mifumo tofauti

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

**Matokeo:** Kuimarisha ufuatiliaji wa sheria, kuharakisha mizunguko ya utoaji modeli kwa 40%, na kuboresha uthabiti wa tathmini ya hatari katika idara zote.

### Tafiti za Kesi 4: Microsoft Playwright MCP Server kwa Uendeshaji wa Vifaa vya Kivinjari

Microsoft ilitengeneza [Playwright MCP server](https://github.com/microsoft/playwright-mcp) kuwezesha uendeshaji wa kivinjari kwa usalama na kwa viwango kupitia Model Context Protocol. Suluhisho hili huruhusu mawakala wa AI na LLM kuingiliana na vivinjari vya wavuti kwa njia iliyodhibitiwa, inayofuata sheria, na inayoweza kupanuliwa—kusaidia matumizi kama vile upimaji wa wavuti kwa njia ya kiotomatiki, uchukuaji wa data, na michakato kamili.

- Inaonyesha uwezo wa uendeshaji wa kivinjari (kuvinjari, kujaza fomu, kupiga picha ya skrini, nk) kama zana za MCP
- Kutekeleza udhibiti mkali wa upatikanaji na sandboxing kuzuia vitendo visivyoidhinishwa
- Kutoa rekodi za ukaguzi za kina kwa maingiliano yote ya kivinjari
- Kusaidia uunganishaji na Azure OpenAI na watoa huduma wengine wa LLM kwa uendeshaji wa mawakala

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
- Kuwezesha uendeshaji wa kivinjari wa kiotomatiki kwa mawakala wa AI na LLM kwa usalama  
- Kupunguza juhudi za upimaji wa mikono na kuboresha upana wa upimaji wa programu za wavuti  
- Kutoa mfumo unaoweza kutumika tena na kupanuliwa kwa ujumuishaji wa zana za kivinjari katika mazingira ya biashara

**Marejeleo:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Tafiti za Kesi 5: Azure MCP – Model Context Protocol ya Kiwanda kama Huduma

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) ni utekelezaji wa MCP wa kiwango cha biashara unaosimamiwa na Microsoft, ulioundwa kutoa uwezo wa seva za MCP zinazoweza kupanuka, salama, na zinazozingatia sheria kama huduma ya wingu. Azure MCP huruhusu mashirika kuanzisha, kusimamia, na kuunganisha seva za MCP na huduma za Azure AI, data, na usalama haraka, kupunguza mzigo wa uendeshaji na kuharakisha matumizi ya AI.

- Uendeshaji wa seva za MCP ulio kamilika na upanuzi, ufuatiliaji, na usalama vilivyojengwa ndani
- Uunganishaji wa asili na Azure OpenAI, Azure AI Search, na huduma nyingine za Azure
- Uthibitishaji na ruhusa za biashara kupitia Microsoft Entra ID
- Msaada kwa zana za kawaida, templeti za maagizo, na viunganishi vya rasilimali
- Uzingatiaji wa usalama wa biashara na mahitaji ya kisheria

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
- Kupunguza muda wa kupata thamani kwa miradi ya AI ya biashara kwa kutoa jukwaa la seva ya MCP tayari kwa matumizi na linalozingatia sheria  
- Kurahisisha ujumuishaji wa LLM, zana, na vyanzo vya data vya biashara  
- Kuimarisha usalama, ufuatiliaji, na ufanisi wa uendeshaji kwa mizigo ya MCP  

**Marejeleo:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Tafiti za Kesi 6: NLWeb  
MCP (Model Context Protocol) ni itifaki inayochipuka kwa ajili ya Chatbots na wasaidizi wa AI kuingiliana na zana. Kila mfano wa NLWeb pia ni seva ya MCP, inayounga mkono njia moja kuu, ask, inayotumika kuuliza tovuti swali kwa lugha ya kawaida. Jibu linalorudi linatumia schema.org, msamiati unaotumika sana kwa kuelezea data za wavuti. Kwa ufupi, MCP ni NLWeb kama Http ilivyo kwa HTML. NLWeb huunganisha itifaki, muundo wa Schema.org, na msimbo wa mfano kusaidia tovuti kuunda haraka sehemu hizi za mwisho, ikinufaisha watu kupitia miingiliano ya mazungumzo na mashine kupitia mwingiliano wa mawakala kwa mawakala kwa lugha ya kawaida.

Kuna vipengele viwili tofauti vya NLWeb.  
- Itifaki rahisi kuanzia, ya kuunganishwa na tovuti kwa lugha ya kawaida na muundo, ikitumia json na schema.org kwa jibu linalorejeshwa. Angalia nyaraka za REST API kwa maelezo zaidi.  
- Utekelezaji rahisi wa (1) unaotumia alama zilizopo, kwa tovuti zinazoweza kufupishwa kama orodha za vitu (bidhaa, mapishi, vivutio, mapitio, n.k.). Pamoja na seti ya vidhibiti vya kiolesura cha mtumiaji, tovuti zinaweza kutoa miingiliano ya mazungumzo kwa urahisi kwa maudhui yao. Angalia nyaraka za Life of a chat query kwa maelezo zaidi juu ya jinsi hii inavyofanya kazi.

**Marejeleo:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Tafiti za Kesi 7: MCP kwa Foundry – Kuunganisha Ma wakala wa Azure AI

Seva za Azure AI Foundry MCP zinaonyesha jinsi MCP inavyoweza kutumika kuandaa na kusimamia mawakala wa AI na michakato katika mazingira ya biashara. Kwa kuunganisha MCP na Azure AI Foundry, mashirika yanaweza kuweka viwango vya maingiliano ya mawakala, kutumia usimamizi wa michakato wa Foundry, na kuhakikisha usalama na upanuzi wa utekelezaji. Njia hii huruhusu uundaji wa prototipu haraka, ufuatiliaji thabiti, na ujumuishaji mzuri na huduma za Azure AI, ikisaidia hali za juu kama usimamizi wa maarifa na tathmini ya mawakala. Waendelezaji wanapata kiolesura kimoja cha kujenga, kupeleka, na kufuatilia mistari ya mawakala, huku timu za IT zikipata usalama ulioboreshwa, ufuatiliaji, na ufanisi wa uendeshaji. Suluhisho hili ni bora kwa makampuni yanayotaka kuharakisha matumizi ya AI na kudumisha udhibiti wa michakato tata inayotegemea mawakala.

**Marejeleo:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Tafiti za Kesi 8: Foundry MCP Playground – Jaribio na Uundaji Prototipu

Foundry MCP Playground hutoa mazingira tayari kwa matumizi kwa ajili ya kujaribu seva za MCP na ujumuishaji wa Azure AI Foundry. Waendelezaji wanaweza kuunda prototipu, kupima, na kutathmini mifano ya AI na michakato ya mawakala kwa kutumia rasilimali kutoka Azure AI Foundry Catalog na Labs. Playground hufanya iwe rahisi kuanzisha, kutoa miradi ya mfano, na kusaidia maendeleo ya pamoja, kurahisisha uchunguzi wa mbinu bora na hali mpya kwa gharama ndogo. Ni muhimu hasa kwa timu zinazotaka kuthibitisha mawazo, kushiriki majaribio, na kuharakisha kujifunza bila hitaji la miundombinu tata. Kwa kupunguza vizingiti vya kuingia, playground huchochea ubunifu na michango ya jamii katika MCP na mazingira ya Azure AI Foundry.

**Marejeleo:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

## Miradi ya Vitendo

### Mradi 1: Jenga Seva ya MCP yenye Watoa Huduma Wengi

**Lengo:** Tengeneza seva ya MCP inayoweza kuelekeza maombi kwa watoa huduma mbalimbali wa modeli za AI kulingana na vigezo maalum.

**Mahitaji:**  
- Kuunga mkono watoa huduma angalau watatu tofauti (mfano, OpenAI, Anthropic, modeli za ndani)  
- Kutekeleza mfumo wa kuelekeza maombi kulingana na metadata ya maombi  
- Kuunda mfumo wa usanidi wa kusimamia nyaraka za watoa huduma  
- Kuongeza caching kuboresha utendaji na gharama  
- Kujenga dashibodi rahisi ya kufuatilia matumizi

**Hatua za Utekelezaji:**  
1. Anzisha miundombinu ya msingi ya seva ya MCP  
2. Tekeleza adapta za watoa huduma kwa kila huduma ya modeli ya AI  
3. Tengeneza mantiki ya kuelekeza maombi kulingana na sifa za maombi  
4. Ongeza mifumo ya caching kwa maombi ya mara kwa mara  
5. Tengeneza dashibodi ya ufuatiliaji  
6. Fanya majaribio na mifumo mbalimbali ya maombi

**Teknolojia:** Chagua kati ya Python (.NET/Java/Python kulingana na upendeleo wako), Redis kwa caching, na mfumo rahisi wa wavuti kwa dashibodi.

### Mradi 2: Mfumo wa Usimamizi wa Maagizo wa Biashara

**Lengo:** Tengeneza mfumo unaotegemea MCP wa kusimamia, kuweka matoleo, na kupeleka templeti za maagizo katika shirika.

**Mahitaji:**  
- Kuunda hifadhi kuu ya templeti za maagizo  
- Kutekeleza mfumo wa kuweka matoleo na mchakato wa idhini  
- Kujenga uwezo wa kujaribu templeti kwa maingizo ya mfano  
- Kuendeleza udhibiti wa upatikanaji kwa misingi ya majukumu  
- Kuunda API ya upokeaji na utoaji wa templeti

**Hatua za Utekelezaji:**  
1. Buni skimu ya hifadhidata kwa ajili ya kuhifadhi templeti  
2. Tengeneza API kuu kwa ajili ya operesheni za CRUD za templeti  
3. Tekeleza mfumo wa kuweka matoleo  
4. Jenga mchakato wa idhini  
5. Tengeneza mfumo wa majaribio  
6. Unda kiolesura rahisi cha wavuti kwa usimamizi  
7. Unganisha na seva ya MCP

**Teknolojia:** Chagua mfumo wa nyuma, hifadhidata ya SQL au NoSQL, na mfumo wa mbele kwa kiolesura cha usimamizi.

### Mradi 3: Jukwaa la Uundaji Maudhui Linalotegemea MCP

**Lengo:** Jenga jukwaa la uundaji maudhui linalotumia MCP kutoa matokeo thabiti kwa aina mbalimbali za maudhui.

**Mahitaji:**  
- Kuunga mkono aina nyingi za maudhui (makala za blogu, mitandao ya kijamii, nakala za masoko)  
- Kutekeleza uzalishaji unaotegemea templeti na chaguzi za kubinafsisha  
- Kuunda mfumo wa ukaguzi na maoni ya maudhui  
- Kufuatilia vipimo vya utendaji wa maudhui  
- Kusaidia kuweka matoleo na marekebisho ya maudhui

**Hatua za Utekelezaji:**  
1. Anzisha miundombinu ya mteja wa MCP  
2. Tengeneza templeti za aina mbalimbali za maudhui  
3. Jenga mchakato wa uzalishaji maudhui  
4. Tekeleza mfumo wa ukaguzi  
5. Unda mfumo wa kufuatilia vipimo  
6. Tengeneza kiolesura cha mtumiaji kwa usimamizi wa templeti na uzalishaji maudhui

**Teknolojia:** Lugha ya programu unayopendelea, mfumo wa wavuti, na mfumo wa hifadhidata.

## Mwelekeo wa Baadaye wa Teknolojia ya MCP

### Mwelekeo Mpya

1. **MCP ya Modalities Nyingi**  
   - Upanuzi wa MCP kuwezesha maingiliano na mifano ya picha, sauti, na video  
   - Uendelezaji wa uwezo wa kufikiri kwa njia mbalimbali  
   - Muundo wa maagizo uliowekwa viwango kwa modalities tofauti

2. **Miundombinu ya MCP ya Kusambazwa**  
   - Mitandao ya MCP inayosambazwa inayoweza kushirikisha rasilimali kati ya mashirika  
   - Itifaki za viwango vya usalama kwa kushiriki modeli  
   - Mbinu za kuhifadhi faragha katika uendeshaji

3. **Soko la MCP**  
   - Mazingira ya kushiriki na kupata mapato kutoka kwa templeti na programu-jalizi za MCP  
   - Mchakato wa uhakiki wa ubora na vyeti  
   - Ujumuishaji na masoko ya modeli

4. **MCP kwa Kompyuta za Edge**  
   - Urekebishaji wa viwango vya MCP kwa vifaa vya edge vyenye rasilimali finyu  
   - Itifaki zilizo optimized kwa mazingira ya mtandao mdogo  
   - Utekelezaji maalum wa MCP kwa mifumo ya IoT

5. **Mifumo ya Udhibiti wa Sheria**  
   - Uendelezaji wa nyongeza za MCP kwa uzingatiaji wa sheria  
   - Rekodi za ukaguzi zilizo viwango na kiolesura cha ufafanuzi  
   - Ujumuishaji na mifumo inayochipuka ya usimamizi wa AI

### Suluhisho za MCP kutoka Microsoft

Microsoft na Azure
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
2. Chagua moja ya mawazo ya mradi na tengeneza maelezo ya kina ya kiufundi.
3. Fanya utafiti wa sekta ambayo haijajumuishwa katika masomo ya kesi na eleza jinsi MCP inaweza kushughulikia changamoto zake maalum.
4. Chunguza moja ya mwelekeo wa baadaye na unda dhana ya upanuzi mpya wa MCP kusaidia hilo.

Ifuatayo: [Best Practices](../08-BestPractices/README.md)

**Kasi ya kutokujali**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuwa sahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au kasoro. Hati ya asili katika lugha yake ya mama inapaswa kuzingatiwa kama chanzo cha kuaminika. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inashauriwa. Hatuna dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.