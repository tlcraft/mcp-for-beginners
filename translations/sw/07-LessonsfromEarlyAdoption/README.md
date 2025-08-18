<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "41f16dac486d2086a53bc644a01cbe42",
  "translation_date": "2025-08-18T18:52:45+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "sw"
}
-->
# 🌟 Masomo Kutoka kwa Watumiaji wa Mapema

[![Masomo Kutoka kwa Watumiaji wa Mapema wa MCP](../../../translated_images/08.980bb2babbaadd8a97739effc9b31e5f1abd8f4c4a3fbc90fb9f931a866674d0.sw.png)](https://youtu.be/jds7dSmNptE)

_(Bofya picha hapo juu kutazama video ya somo hili)_

## 🎯 Yaliyomo Katika Moduli Hii

Moduli hii inachunguza jinsi mashirika halisi na watengenezaji wanavyotumia Model Context Protocol (MCP) kutatua changamoto za kweli na kuendesha ubunifu. Kupitia masomo ya kina ya kesi na miradi ya vitendo, utagundua jinsi MCP inavyowezesha ujumuishaji salama na wa kiwango kikubwa wa AI unaounganisha mifano ya lugha, zana, na data ya biashara.

### 📚 Tazama MCP Ikifanya Kazi

Unataka kuona kanuni hizi zikitekelezwa kwenye zana tayari za uzalishaji? Angalia [**Seva 10 za Microsoft MCP Zinazobadilisha Uzalishaji wa Watengenezaji**](microsoft-mcp-servers.md), ambayo inaonyesha seva halisi za Microsoft MCP unazoweza kutumia leo.

## Muhtasari

Somo hili linachunguza jinsi watumiaji wa mapema walivyotumia Model Context Protocol (MCP) kutatua changamoto za ulimwengu halisi na kuendesha ubunifu katika sekta mbalimbali. Kupitia masomo ya kina ya kesi na miradi ya vitendo, utaona jinsi MCP inavyowezesha ujumuishaji wa AI ulio sanifu, salama, na wa kiwango kikubwa—unaounganisha mifano mikubwa ya lugha, zana, na data ya biashara katika mfumo mmoja. Utapata uzoefu wa vitendo wa kubuni na kujenga suluhisho za msingi wa MCP, kujifunza kutoka kwa mifumo ya utekelezaji iliyothibitishwa, na kugundua mbinu bora za kupeleka MCP katika mazingira ya uzalishaji. Somo pia linaangazia mitindo inayojitokeza, mwelekeo wa siku zijazo, na rasilimali za chanzo huria ili kukusaidia kubaki mbele katika teknolojia ya MCP na mfumo wake unaoendelea.

## Malengo ya Kujifunza

- Kuchambua utekelezaji halisi wa MCP katika sekta mbalimbali
- Kubuni na kujenga programu kamili za msingi wa MCP
- Kuchunguza mitindo inayojitokeza na mwelekeo wa siku zijazo katika teknolojia ya MCP
- Kutumia mbinu bora katika hali halisi za maendeleo

## Utekelezaji Halisi wa MCP

### Kesi ya Kwanza: Uboreshaji wa Huduma kwa Wateja wa Biashara

Kampuni ya kimataifa ilitekeleza suluhisho la msingi wa MCP ili kusanifisha mwingiliano wa AI katika mifumo yao ya huduma kwa wateja. Hii iliwasaidia:

- Kuunda kiolesura sanifu kwa watoa huduma mbalimbali wa LLM
- Kudumisha usimamizi thabiti wa maelezo ya maombi katika idara zote
- Kutekeleza udhibiti madhubuti wa usalama na uzingatiaji
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

**Matokeo:** Kupunguzwa kwa gharama za mifano kwa 30%, kuboreshwa kwa uthabiti wa majibu kwa 45%, na kuimarishwa kwa uzingatiaji katika operesheni za kimataifa.

### Kesi ya Pili: Msaidizi wa Uchunguzi wa Afya

Mtoa huduma wa afya alitengeneza miundombinu ya MCP ili kuunganisha mifano mbalimbali ya AI ya matibabu maalum huku wakihakikisha data nyeti ya wagonjwa inabaki salama:

- Kubadilisha kwa urahisi kati ya mifano ya matibabu ya jumla na maalum
- Udhibiti mkali wa faragha na rekodi za ukaguzi
- Ujumuishaji na mifumo iliyopo ya Rekodi za Kielektroniki za Afya (EHR)
- Uhandisi thabiti wa maelezo ya maombi kwa istilahi ya matibabu

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

**Matokeo:** Mapendekezo bora ya uchunguzi kwa madaktari huku yakidumisha uzingatiaji kamili wa HIPAA na kupunguzwa kwa mabadiliko ya muktadha kati ya mifumo.

### Kesi ya Tatu: Uchambuzi wa Hatari katika Huduma za Kifedha

Taasisi ya kifedha ilitekeleza MCP ili kusanifisha michakato yao ya uchambuzi wa hatari katika idara mbalimbali:

- Kuunda kiolesura sanifu kwa mifano ya hatari ya mikopo, kugundua udanganyifu, na hatari za uwekezaji
- Kutekeleza udhibiti madhubuti wa ufikiaji na toleo la mifano
- Kuhakikisha uwezekano wa ukaguzi wa mapendekezo yote ya AI
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

**Matokeo:** Uzingatiaji wa kanuni ulioimarishwa, mzunguko wa kupeleka mifano kwa haraka kwa 40%, na uthabiti bora wa tathmini ya hatari katika idara.

### Kesi ya Nne: Seva ya Microsoft Playwright MCP kwa Uendeshaji wa Kivinjari

Microsoft ilitengeneza [Seva ya Playwright MCP](https://github.com/microsoft/playwright-mcp) kuwezesha uendeshaji salama na sanifu wa kivinjari kupitia Model Context Protocol. Seva hii tayari kwa uzalishaji inaruhusu mawakala wa AI na LLMs kuingiliana na vivinjari vya wavuti kwa njia iliyodhibitiwa, inayoweza kukaguliwa, na inayoweza kupanuliwa—ikiwezesha matumizi kama majaribio ya wavuti yaliyotengenezwa kiotomatiki, uchimbaji wa data, na mtiririko wa kazi wa mwisho hadi mwisho.

> **🎯 Zana Tayari kwa Uzalishaji**
> 
> Kesi hii inaonyesha seva halisi ya MCP unayoweza kutumia leo! Jifunze zaidi kuhusu Seva ya Playwright MCP na seva nyingine 9 tayari za uzalishaji za Microsoft MCP katika [**Mwongozo wa Seva za Microsoft MCP**](microsoft-mcp-servers.md#8--playwright-mcp-server).

**Vipengele Muhimu:**
- Inatoa uwezo wa uendeshaji wa kivinjari (urambazaji, kujaza fomu, kuchukua picha za skrini, n.k.) kama zana za MCP
- Inatekeleza udhibiti madhubuti wa ufikiaji na sandboxing ili kuzuia vitendo visivyoidhinishwa
- Inatoa rekodi za ukaguzi za kina kwa mwingiliano wote wa kivinjari
- Inasaidia ujumuishaji na Azure OpenAI na watoa huduma wengine wa LLM kwa uendeshaji unaoendeshwa na mawakala
- Inawezesha uwezo wa kuvinjari wavuti wa GitHub Copilot's Coding Agent

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

- Uendeshaji salama wa kivinjari kwa mawakala wa AI na LLMs
- Kupunguzwa kwa juhudi za majaribio ya mwongozo na kuboreshwa kwa chanjo ya majaribio kwa programu za wavuti
- Kutoa mfumo unaoweza kutumika tena na kupanuliwa kwa ujumuishaji wa zana za msingi wa kivinjari katika mazingira ya biashara
- Inawezesha uwezo wa kuvinjari wavuti wa GitHub Copilot

**Marejeleo:**

- [Hifadhi ya GitHub ya Seva ya Playwright MCP](https://github.com/microsoft/playwright-mcp)
- [Suluhisho za Microsoft AI na Uendeshaji](https://azure.microsoft.com/en-us/products/ai-services/)

### Kesi ya Tano: Azure MCP – Model Context Protocol ya Biashara kama Huduma

Seva ya Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) ni utekelezaji wa kiwango cha biashara wa Model Context Protocol unaosimamiwa na Microsoft, ulioundwa kutoa uwezo wa seva za MCP zinazoweza kupanuliwa, salama, na zinazozingatia kanuni kama huduma ya wingu. Azure MCP inawawezesha mashirika kupeleka, kusimamia, na kuunganisha seva za MCP haraka na huduma za AI, data, na usalama za Azure, kupunguza mzigo wa kiutendaji na kuharakisha kupitishwa kwa AI.

> **🎯 Zana Tayari kwa Uzalishaji**
> 
> Hii ni seva halisi ya MCP unayoweza kutumia leo! Jifunze zaidi kuhusu Seva ya Azure AI Foundry MCP katika [**Mwongozo wa Seva za Microsoft MCP**](microsoft-mcp-servers.md).

- Ukaribishaji wa seva za MCP unaosimamiwa kikamilifu na upanuzi wa ndani, ufuatiliaji, na usalama
- Ujumuishaji wa asili na Azure OpenAI, Azure AI Search, na huduma nyingine za Azure
- Uthibitishaji wa biashara na idhini kupitia Microsoft Entra ID
- Msaada kwa zana maalum, templeti za maelezo ya maombi, na viunganishi vya rasilimali
- Uzingatiaji wa mahitaji ya usalama wa biashara na kanuni

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
- Kupunguzwa kwa muda wa thamani kwa miradi ya AI ya biashara kwa kutoa jukwaa la seva za MCP tayari kutumika na zinazozingatia kanuni
- Ujumuishaji rahisi wa LLMs, zana, na vyanzo vya data vya biashara
- Usalama ulioimarishwa, ufuatiliaji, na ufanisi wa kiutendaji kwa mzigo wa kazi wa MCP
- Ubora wa msimbo ulioboreshwa kwa kutumia mbinu bora za SDK za Azure na mifumo ya uthibitishaji ya sasa

**Marejeleo:**  
- [Nyaraka za Azure MCP](https://aka.ms/azmcp)
- [Hifadhi ya GitHub ya Seva ya Azure MCP](https://github.com/Azure/azure-mcp)
- [Huduma za AI za Azure](https://azure.microsoft.com/en-us/products/ai-services/)
- [Kituo cha Microsoft MCP](https://mcp.azure.com)

### Kesi ya Sita: NLWeb

MCP (Model Context Protocol) ni itifaki inayojitokeza kwa Chatbots na wasaidizi wa AI kuingiliana na zana. Kila mfano wa NLWeb pia ni seva ya MCP, inayounga mkono mbinu moja ya msingi, ask, ambayo hutumika kuuliza tovuti swali kwa lugha ya kawaida. Jibu linalorudishwa linatumia schema.org, msamiati unaotumika sana kwa kuelezea data ya wavuti. Kwa maneno rahisi, MCP ni NLWeb kama Http ilivyo kwa HTML. NLWeb inachanganya itifaki, miundo ya Schema.org, na msimbo wa sampuli kusaidia tovuti kuunda haraka sehemu hizi, ikinufaisha wanadamu kupitia kiolesura cha mazungumzo na mashine kupitia mwingiliano wa wakala kwa wakala.

Kuna vipengele viwili tofauti vya NLWeb:
- Itifaki, rahisi kuanza nayo, ya kuingiliana na tovuti kwa lugha ya kawaida na muundo, ukitumia json na schema.org kwa jibu linalorudishwa. Tazama nyaraka za REST API kwa maelezo zaidi.
- Utekelezaji rahisi wa (1) unaotumia alama zilizopo, kwa tovuti zinazoweza kufupishwa kama orodha za vitu (bidhaa, mapishi, vivutio, hakiki, n.k.). Pamoja na seti ya wijeti za kiolesura cha mtumiaji, tovuti zinaweza kutoa kwa urahisi kiolesura cha mazungumzo kwa maudhui yao. Tazama nyaraka za Maisha ya swali la mazungumzo kwa maelezo zaidi kuhusu jinsi hii inavyofanya kazi.

**Marejeleo:**  
- [Nyaraka za Azure MCP](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Kesi ya Saba: Seva ya Azure AI Foundry MCP – Ujumuishaji wa Mawakala wa AI wa Biashara

Seva za Azure AI Foundry MCP zinaonyesha jinsi MCP inaweza kutumika kuratibu na kusimamia mawakala wa AI na mtiririko wa kazi katika mazingira ya biashara. Kwa kuunganisha MCP na Azure AI Foundry, mashirika yanaweza kusanifisha mwingiliano wa mawakala, kutumia usimamizi wa mtiririko wa kazi wa Foundry, na kuhakikisha utekelezaji salama na wa kiwango kikubwa.

> **🎯 Zana Tayari kwa Uzalishaji**
> 
> Hii ni seva halisi ya MCP unayoweza kutumia leo! Jifunze zaidi kuhusu Seva ya Azure AI Foundry MCP katika [**Mwongozo wa Seva za Microsoft MCP**](microsoft-mcp-servers.md#9--azure-ai-foundry-mcp-server).

**Vipengele Muhimu:**
- Ufikiaji wa kina wa mfumo wa AI wa Azure, ikiwa ni pamoja na katalogi za mifano na usimamizi wa kupeleka
- Kuorodhesha maarifa kwa Azure AI Search kwa programu za RAG
- Zana za tathmini ya utendaji wa mifano ya AI na uhakikisho wa ubora
- Ujumuishaji na Katalogi ya Foundry AI na Maabara kwa mifano ya utafiti ya kisasa
- Uwezo wa usimamizi na tathmini ya mawakala kwa hali za uzalishaji

**Matokeo:**
- Uundaji wa haraka wa prototipu na ufuatiliaji thabiti wa mtiririko wa kazi wa mawakala wa AI
- Ujumuishaji rahisi na huduma za AI za Azure kwa hali za hali ya juu
- Kiolesura sanifu cha kujenga, kupeleka, na kufuatilia njia za mawakala
- Usalama ulioimarishwa, uzingatiaji, na ufanisi wa kiutendaji kwa biashara
- Kuongeza kasi ya kupitishwa kwa AI huku ukidumisha udhibiti wa michakato changamano inayotegemea mawakala

**Marejeleo:**
- [Hifadhi ya GitHub ya Seva ya Azure AI Foundry MCP](https://github.com/azure-ai-foundry/mcp-foundry)
- [Kuunganisha Mawakala wa AI wa Azure na MCP (Blogu ya Microsoft Foundry)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Kesi ya Nane: Uwanja wa Mchezo wa Foundry MCP – Majaribio na Uundaji wa Prototipu

Uwanja wa Mchezo wa Foundry MCP unatoa mazingira tayari kutumika kwa majaribio na ujumuishaji wa seva za MCP na Azure AI Foundry. Watengenezaji wanaweza kuunda prototipu haraka, kujaribu, na kutathmini mifano ya AI na mtiririko wa kazi wa mawakala kwa kutumia rasilimali kutoka Katalogi ya Foundry AI na Maabara. Uwanja wa mchezo unarahisisha usanidi, hutoa miradi ya sampuli, na kuunga mkono maendeleo ya pamoja, na kufanya iwe rahisi kuchunguza mbinu bora na hali mpya kwa gharama ndogo. Ni muhimu hasa kwa timu zinazotafuta kuthibitisha mawazo, kushiriki majaribio, na kuharakisha kujifunza bila hitaji la miundombinu changamano. Kwa kupunguza kizuizi cha kuingia, uwanja wa mchezo husaidia kukuza ubunifu na michango ya jamii katika mfumo wa MCP na Azure AI Foundry.

**Marejeleo:**

- [Hifadhi ya GitHub ya Uwanja wa Mchezo wa Foundry MCP](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### Kesi ya Tisa: Seva ya Microsoft Learn Docs MCP – Ufikiaji wa Nyaraka Unaotumia AI

Seva ya Microsoft Learn Docs MCP ni huduma inayohifadhiwa kwenye wingu inayotoa wasaidizi wa AI ufikiaji wa wakati halisi wa nyaraka rasmi za Microsoft kupitia Model Context Protocol. Seva hii tayari kwa uzalishaji inaunganisha na mfumo wa Microsoft Learn na kuwezesha utafutaji wa semantiki katika vyanzo vyote rasmi vya Microsoft.
> **🎯 Zana Tayari kwa Uzalishaji**
> 
> Hii ni seva halisi ya MCP unayoweza kutumia leo! Jifunze zaidi kuhusu Seva ya MCP ya Microsoft Learn Docs katika [**Mwongozo wa Seva za MCP za Microsoft**](microsoft-mcp-servers.md#1--microsoft-learn-docs-mcp-server).
**Vipengele Muhimu:**
- Ufikiaji wa papo hapo wa nyaraka rasmi za Microsoft, nyaraka za Azure, na nyaraka za Microsoft 365
- Uwezo wa utafutaji wa kisemantiki wa hali ya juu unaoelewa muktadha na nia
- Taarifa za kisasa kila wakati kadri maudhui ya Microsoft Learn yanavyochapishwa
- Ufunikaji wa kina katika Microsoft Learn, nyaraka za Azure, na vyanzo vya Microsoft 365
- Hutoa vipande vya maudhui bora hadi 10 pamoja na vichwa vya makala na URL

**Kwa Nini Ni Muhimu:**
- Inatatua tatizo la "maarifa ya AI yaliyopitwa na wakati" kwa teknolojia za Microsoft
- Inahakikisha wasaidizi wa AI wanapata vipengele vya kisasa vya .NET, C#, Azure, na Microsoft 365
- Inatoa taarifa rasmi, ya kwanza kwa usahihi wa kizazi cha msimbo
- Muhimu kwa watengenezaji wanaofanya kazi na teknolojia za Microsoft zinazobadilika haraka

**Matokeo:**
- Usahihi ulioboreshwa sana wa msimbo unaozalishwa na AI kwa teknolojia za Microsoft
- Kupunguza muda unaotumika kutafuta nyaraka za kisasa na mbinu bora
- Kuongeza tija ya watengenezaji kwa upatikanaji wa nyaraka zinazojali muktadha
- Muunganisho wa bila mshono na mtiririko wa kazi za maendeleo bila kuacha IDE

**Marejeleo:**
- [Microsoft Learn Docs MCP Server GitHub Repository](https://github.com/MicrosoftDocs/mcp)
- [Microsoft Learn Documentation](https://learn.microsoft.com/)

## Miradi ya Vitendo

### Mradi 1: Jenga Seva ya MCP ya Watoa Huduma Wengi

**Lengo:** Unda seva ya MCP inayoweza kuelekeza maombi kwa watoa huduma wa mifano ya AI wengi kulingana na vigezo maalum.

**Mahitaji:**

- Kusaidia angalau watoa huduma wa mifano mitatu tofauti (mfano, OpenAI, Anthropic, mifano ya ndani)
- Tekeleza utaratibu wa kuelekeza kulingana na metadata ya maombi
- Unda mfumo wa usanidi wa kusimamia hati za watoa huduma
- Ongeza akiba ili kuboresha utendaji na gharama
- Jenga dashibodi rahisi ya kufuatilia matumizi

**Hatua za Utekelezaji:**

1. Sanidi miundombinu ya msingi ya seva ya MCP
2. Tekeleza adapta za watoa huduma kwa kila huduma ya mfano wa AI
3. Unda mantiki ya kuelekeza kulingana na sifa za maombi
4. Ongeza mifumo ya akiba kwa maombi ya mara kwa mara
5. Tengeneza dashibodi ya ufuatiliaji
6. Jaribu na mifumo mbalimbali ya maombi

**Teknolojia:** Chagua kati ya Python (.NET/Java/Python kulingana na upendeleo wako), Redis kwa akiba, na mfumo rahisi wa wavuti kwa dashibodi.

### Mradi 2: Mfumo wa Usimamizi wa Maagizo ya Biashara

**Lengo:** Kuendeleza mfumo wa msingi wa MCP wa kusimamia, kuweka toleo, na kupeleka templeti za maagizo katika shirika.

**Mahitaji:**

- Unda hifadhi kuu ya templeti za maagizo
- Tekeleza mifumo ya kuweka toleo na mchakato wa idhini
- Jenga uwezo wa kupima templeti kwa pembejeo za sampuli
- Kuza udhibiti wa ufikiaji kulingana na majukumu
- Unda API ya upatikanaji na upelekaji wa templeti

**Hatua za Utekelezaji:**

1. Buni mpangilio wa hifadhidata kwa uhifadhi wa templeti
2. Unda API kuu kwa operesheni za CRUD za templeti
3. Tekeleza mfumo wa kuweka toleo
4. Jenga mchakato wa idhini
5. Tengeneza mfumo wa kupima
6. Unda kiolesura rahisi cha wavuti kwa usimamizi
7. Unganisha na seva ya MCP

**Teknolojia:** Chaguo lako la mfumo wa nyuma, hifadhidata ya SQL au NoSQL, na mfumo wa mbele kwa kiolesura cha usimamizi.

### Mradi 3: Jukwaa la Kuzalisha Maudhui kwa Kutumia MCP

**Lengo:** Jenga jukwaa la kuzalisha maudhui linalotumia MCP kutoa matokeo thabiti kwa aina tofauti za maudhui.

**Mahitaji:**

- Kusaidia miundo mbalimbali ya maudhui (machapisho ya blogu, mitandao ya kijamii, nakala za masoko)
- Tekeleza kizazi cha msingi wa templeti na chaguo za ubinafsishaji
- Unda mfumo wa mapitio na maoni ya maudhui
- Fuatilia vipimo vya utendaji wa maudhui
- Kusaidia kuweka toleo na kurudia maudhui

**Hatua za Utekelezaji:**

1. Sanidi miundombinu ya mteja wa MCP
2. Unda templeti kwa aina tofauti za maudhui
3. Jenga bomba la kuzalisha maudhui
4. Tekeleza mfumo wa mapitio
5. Kuza mfumo wa kufuatilia vipimo
6. Unda kiolesura cha mtumiaji kwa usimamizi wa templeti na kizazi cha maudhui

**Teknolojia:** Lugha ya programu unayopendelea, mfumo wa wavuti, na mfumo wa hifadhidata.

## Mwelekeo wa Baadaye wa Teknolojia ya MCP

### Mwelekeo Unaibuka

1. **MCP ya Modaliti Nyingi**
   - Upanuzi wa MCP ili kusawazisha mwingiliano na mifano ya picha, sauti, na video
   - Maendeleo ya uwezo wa kufikiri kati ya modaliti
   - Miundo ya maagizo iliyosawazishwa kwa modaliti tofauti

2. **Miundombinu ya MCP ya Shirikishi**
   - Mitandao ya MCP iliyosambazwa inayoweza kushiriki rasilimali kati ya mashirika
   - Itifaki zilizowekwa kwa ushirikiano salama wa mifano
   - Mbinu za hesabu zinazohifadhi faragha

3. **Masoko ya MCP**
   - Mifumo ya kushiriki na kupata mapato kutoka kwa templeti na programu-jalizi za MCP
   - Michakato ya uhakikisho wa ubora na vyeti
   - Muunganisho na masoko ya mifano

4. **MCP kwa Kompyuta ya Ukingo**
   - Marekebisho ya viwango vya MCP kwa vifaa vya ukingo vyenye rasilimali ndogo
   - Itifaki zilizoboreshwa kwa mazingira ya bendi ya chini
   - Utekelezaji maalum wa MCP kwa mifumo ya IoT

5. **Mifumo ya Udhibiti**
   - Maendeleo ya viendelezi vya MCP kwa kufuata kanuni
   - Njia za ukaguzi zilizowekwa na violesura vya kuelezea
   - Muunganisho na mifumo ya usimamizi wa AI inayojitokeza

### Suluhisho za MCP kutoka Microsoft

Microsoft na Azure zimeunda hifadhi kadhaa za chanzo huria kusaidia watengenezaji kutekeleza MCP katika hali mbalimbali:

#### Shirika la Microsoft

1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - Seva ya MCP ya Playwright kwa otomatiki ya kivinjari na upimaji
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - Utekelezaji wa seva ya MCP ya OneDrive kwa upimaji wa ndani na mchango wa jamii
3. [NLWeb](https://github.com/microsoft/NlWeb) - NLWeb ni mkusanyiko wa itifaki wazi na zana za chanzo huria zinazohusiana. Lengo lake kuu ni kuanzisha safu ya msingi kwa Wavuti ya AI

#### Shirika la Azure-Samples

1. [mcp](https://github.com/Azure-Samples/mcp) - Viungo vya sampuli, zana, na rasilimali za kujenga na kuunganisha seva za MCP kwenye Azure kwa kutumia lugha nyingi
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - Seva za MCP za marejeleo zinazoonyesha uthibitishaji na maelezo ya sasa ya Model Context Protocol
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Ukurasa wa kutua kwa utekelezaji wa Seva ya MCP ya Mbali katika Azure Functions na viungo kwa hifadhi maalum za lugha
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Kiolezo cha kuanza haraka kwa kujenga na kupeleka seva za MCP za mbali maalum kwa kutumia Azure Functions na Python
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Kiolezo cha kuanza haraka kwa kujenga na kupeleka seva za MCP za mbali maalum kwa kutumia Azure Functions na .NET/C#
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Kiolezo cha kuanza haraka kwa kujenga na kupeleka seva za MCP za mbali maalum kwa kutumia Azure Functions na TypeScript
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Azure API Management kama Lango la AI kwa seva za MCP za mbali kwa kutumia Python
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - Majaribio ya APIM ❤️ AI ikiwa ni pamoja na uwezo wa MCP, kuunganisha na Azure OpenAI na AI Foundry

Hifadhi hizi hutoa utekelezaji mbalimbali, templeti, na rasilimali za kufanya kazi na Model Context Protocol katika lugha tofauti za programu na huduma za Azure. Zinashughulikia hali mbalimbali za matumizi kutoka kwa utekelezaji wa seva za msingi hadi uthibitishaji, upelekaji wa wingu, na hali za ujumuishaji wa biashara.

#### Saraka ya Rasilimali za MCP

Saraka ya [MCP Resources](https://github.com/microsoft/mcp/tree/main/Resources) katika hifadhi rasmi ya Microsoft MCP inatoa mkusanyiko ulioratibiwa wa rasilimali za sampuli, templeti za maagizo, na ufafanuzi wa zana kwa matumizi na seva za Model Context Protocol. Saraka hii imeundwa kusaidia watengenezaji kuanza haraka na MCP kwa kutoa vizuizi vya ujenzi vinavyoweza kutumika tena na mifano bora ya mazoezi kwa:

- **Templeti za Maagizo:** Templeti za maagizo zinazoweza kutumika mara moja kwa kazi za kawaida za AI na hali, ambazo zinaweza kubadilishwa kwa utekelezaji wako wa seva ya MCP.
- **Ufafanuzi wa Zana:** Mifano ya miundo ya zana na metadata ili kusawazisha ujumuishaji wa zana na uanzishaji katika seva tofauti za MCP.
- **Sampuli za Rasilimali:** Mifano ya ufafanuzi wa rasilimali za kuunganisha na vyanzo vya data, API, na huduma za nje ndani ya mfumo wa MCP.
- **Utekelezaji wa Marejeleo:** Sampuli za vitendo zinazoonyesha jinsi ya kuunda na kupanga rasilimali, maagizo, na zana katika miradi halisi ya MCP.

Rasilimali hizi zinaharakisha maendeleo, kukuza usawazishaji, na kusaidia kuhakikisha mazoea bora wakati wa kujenga na kupeleka suluhisho za msingi za MCP.

#### Saraka ya Rasilimali za MCP

- [MCP Resources (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)

### Fursa za Utafiti

- Mbinu bora za kuboresha maagizo ndani ya mifumo ya MCP
- Miundo ya usalama kwa utekelezaji wa MCP wa wateja wengi
- Upimaji wa utendaji katika utekelezaji tofauti wa MCP
- Mbinu za uthibitishaji rasmi kwa seva za MCP

## Hitimisho

Model Context Protocol (MCP) inaunda haraka mustakabali wa ujumuishaji wa AI uliosawazishwa, salama, na unaoweza kuingiliana katika sekta mbalimbali. Kupitia masomo ya kesi na miradi ya vitendo katika somo hili, umeona jinsi watumiaji wa mapema—ikiwa ni pamoja na Microsoft na Azure—wanavyotumia MCP kutatua changamoto za ulimwengu halisi, kuharakisha kupitishwa kwa AI, na kuhakikisha kufuata kanuni, usalama, na upanuzi. Mbinu ya moduli ya MCP inawezesha mashirika kuunganisha mifano mikubwa ya lugha, zana, na data ya biashara katika mfumo mmoja, unaoweza kukaguliwa. Kadri MCP inavyoendelea kubadilika, kushiriki na jamii, kuchunguza rasilimali za chanzo huria, na kutumia mazoea bora kutakuwa muhimu katika kujenga suluhisho za AI zenye nguvu, tayari kwa siku zijazo.

## Rasilimali za Ziada

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

## Mazoezi

1. Changanua moja ya masomo ya kesi na pendekeza mbinu mbadala ya utekelezaji.
2. Chagua moja ya mawazo ya mradi na unda maelezo ya kiufundi ya kina.
3. Fanya utafiti kuhusu sekta ambayo haijashughulikiwa katika masomo ya kesi na eleza jinsi MCP inaweza kushughulikia changamoto zake maalum.
4. Chunguza moja ya mwelekeo wa baadaye na unda dhana ya kiendelezi kipya cha MCP ili kuunga mkono. 

Next: [Microsoft MCP Server](../07-LessonsfromEarlyAdoption/microsoft-mcp-servers.md)

**Kanusho**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au kutokuwa sahihi. Hati ya asili katika lugha yake ya awali inapaswa kuzingatiwa kama chanzo cha mamlaka. Kwa taarifa muhimu, inashauriwa kutumia huduma ya tafsiri ya kitaalamu ya binadamu. Hatutawajibika kwa maelewano mabaya au tafsiri zisizo sahihi zinazotokana na matumizi ya tafsiri hii.