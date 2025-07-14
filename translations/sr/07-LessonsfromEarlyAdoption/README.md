<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-07-14T04:42:46+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "sr"
}
-->
# Уроци од раних усвајача

## Преглед

Овај час истражује како су рани усвајачи искористили Model Context Protocol (MCP) за решавање стварних изазова и подстицање иновација у различитим индустријама. Кроз детаљне студије случаја и практичне пројекте, видећете како MCP омогућава стандардизовану, безбедну и скалабилну интеграцију вештачке интелигенције — повезујући велике језичке моделе, алате и корпоративне податке у јединственом оквиру. Стекнућете практично искуство у дизајнирању и изградњи решења заснованих на MCP-у, научити проверене шаблоне имплементације и открити најбоље праксе за примену MCP-а у продукцијским окружењима. Час такође истиче нове трендове, будуће смернице и ресурсе отвореног кода који ће вам помоћи да останете на челу MCP технологије и њеног развијајућег се екосистема.

## Циљеви учења

- Анализирати стварне имплементације MCP-а у различитим индустријама  
- Дизајнирати и изградити комплетне апликације засноване на MCP-у  
- Истражити нове трендове и будуће смернице у MCP технологији  
- Применити најбоље праксе у стварним развојним сценаријима  

## Стварне имплементације MCP-а

### Студија случаја 1: Аутоматизација корисничке подршке у предузећима

Мултинационална корпорација је имплементирала решење засновано на MCP-у како би стандардизовала интеракције вештачке интелигенције у својим системима корисничке подршке. Ово им је омогућило да:

- Креирају јединствен интерфејс за више провајдера LLM модела  
- Одржавају доследно управљање упитима у различитим одељењима  
- Имплементирају робусне контроле безбедности и усаглашености  
- Лако пребацују између различитих AI модела према специфичним потребама  

**Техничка имплементација:**  
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

**Резултати:** Смањење трошкова модела за 30%, побољшање конзистентности одговора за 45% и унапређена усаглашеност у глобалним операцијама.

### Студија случаја 2: Дијагностички асистент у здравству

Здравствена установа је развила MCP инфраструктуру за интеграцију више специјализованих медицинских AI модела уз обезбеђивање заштите осетљивих података пацијената:

- Беспрекорно пребацивање између општих и специјализованих медицинских модела  
- Строге контроле приватности и евиденција ревизије  
- Интеграција са постојећим системима електронских здравствених картона (EHR)  
- Доследно креирање упита за медицинску терминологију  

**Техничка имплементација:**  
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

**Резултати:** Побољшани дијагностички предлози за лекаре уз пуну HIPAA усаглашеност и значајно смањење пребацивања контекста између система.

### Студија случаја 3: Анализа ризика у финансијским услугама

Финансијска институција је имплементирала MCP како би стандардизовала процесе анализе ризика у различитим одељењима:

- Креиран јединствен интерфејс за моделе кредитног ризика, детекције преваре и инвестиционог ризика  
- Имплементиране строге контроле приступа и верзионисање модела  
- Обезбеђена ревизија свих AI препорука  
- Одржана доследна форматација података у различитим системима  

**Техничка имплементација:**  
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

**Резултати:** Побољшана регулаторна усаглашеност, 40% бржи циклуси имплементације модела и боља конзистентност процене ризика у одељењима.

### Студија случаја 4: Microsoft Playwright MCP сервер за аутоматизацију прегледача

Microsoft је развио [Playwright MCP сервер](https://github.com/microsoft/playwright-mcp) који омогућава безбедну, стандардизовану аутоматизацију прегледача преко Model Context Protocol-а. Ово решење омогућава AI агентима и LLM моделима да интерагују са веб прегледачима на контролисан, ревидирајући и проширив начин — омогућавајући примене као што су аутоматизовано тестирање веба, екстракција података и крај-до-крај радни токови.

- Излаже могућности аутоматизације прегледача (навигација, попуњавање формулара, снимање екрана итд.) као MCP алате  
- Имплементира строге контроле приступа и sandboxing како би спречио неовлашћене радње  
- Пружа детаљне ревизијске записе за све интеракције са прегледачем  
- Подржава интеграцију са Azure OpenAI и другим LLM провајдерима за аутоматизацију вођену агентима  

**Техничка имплементација:**  
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

**Резултати:**  
- Омогућена безбедна, програмска аутоматизација прегледача за AI агенте и LLM моделе  
- Смањен ручни напор у тестирању и побољшано покривање тестова за веб апликације  
- Пружа оквир који се може поново користити и проширив за интеграцију алата заснованих на прегледачу у корпоративним окружењима  

**Референце:**  
- [Playwright MCP Server GitHub репозиторијум](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Студија случаја 5: Azure MCP – Model Context Protocol као услуга за предузећа

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) је Microsoft-ова управљана, корпоративна имплементација Model Context Protocol-а, дизајнирана да пружи скалабилне, безбедне и усаглашене MCP сервер капацитете као cloud услугу. Azure MCP омогућава организацијама брзо постављање, управљање и интеграцију MCP сервера са Azure AI, подацима и безбедносним сервисима, смањујући оперативне трошкове и убрзавајући усвајање AI технологија.

- Потпуно управљано хостовање MCP сервера са уграђеним скалирањем, мониторингом и безбедношћу  
- Нативна интеграција са Azure OpenAI, Azure AI Search и другим Azure сервисима  
- Корпоративна аутентификација и ауторизација преко Microsoft Entra ID  
- Подршка за прилагођене алате, шаблоне упита и конекторе ресурса  
- Усаглашеност са корпоративним безбедносним и регулаторним захтевима  

**Техничка имплементација:**  
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

**Резултати:**  
- Скратило време до вредности за корпоративне AI пројекте пружајући спремну, усаглашену MCP сервер платформу  
- Поједностављена интеграција LLM модела, алата и извора корпоративних података  
- Побољшана безбедност, посматрање и оперативна ефикасност за MCP радне оптерећења  

**Референце:**  
- [Azure MCP документација](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Студија случаја 6: NLWeb  
MCP (Model Context Protocol) је нови протокол за чатботове и AI асистенте за интеракцију са алатима. Свака NLWeb инстанца је такође MCP сервер који подржава једну основну методу, ask, која се користи за постављање питања веб сајту на природном језику. Враћени одговор користи schema.org, широко коришћен вокабулар за описивање веб података. Укратко, MCP је NLWeb као што је Http за HTML. NLWeb комбинује протоколе, Schema.org формате и пример кода како би помогао сајтовима да брзо креирају ове крајње тачке, користећи их и људи кроз разговорне интерфејсе и машине кроз природну интеракцију агената.

Постоје два јасна дела NLWeb-а:  
- Протокол, веома једноставан за почетак, за интеракцију са сајтом на природном језику и формат који користи json и schema.org за одговор. Погледајте документацију о REST API-ју за више детаља.  
- Једноставна имплементација (1) која користи постојећи markup, за сајтове који се могу апстраховати као листе ставки (производи, рецепти, атракције, рецензије итд.). Заједно са скупом корисничких видгета, сајтови могу лако пружити разговорне интерфејсе за свој садржај. Погледајте документацију о Life of a chat query за више детаља о томе како ово функционише.  

**Референце:**  
- [Azure MCP документација](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Студија случаја 7: MCP за Foundry – Интеграција Azure AI агената

Azure AI Foundry MCP сервери показују како се MCP може користити за оркестрацију и управљање AI агентима и радним токовима у корпоративним окружењима. Интеграцијом MCP-а са Azure AI Foundry, организације могу стандардизовати интеракције агената, искористити Foundry-јев систем управљања радним токовима и обезбедити безбедне, скалабилне имплементације. Овај приступ омогућава брзо прототиписање, робусно праћење и беспрекорну интеграцију са Azure AI сервисима, подржавајући напредне сценарије као што су управљање знањем и евалуација агената. Развојни тимови добијају јединствен интерфејс за изградњу, имплементацију и праћење агената, док IT тимови добијају побољшану безбедност, усаглашеност и оперативну ефикасност. Решење је идеално за предузећа која желе да убрзају усвајање AI и задрже контролу над сложеним процесима вођеним агентима.

**Референце:**  
- [MCP Foundry GitHub репозиторијум](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Интеграција Azure AI агената са MCP (Microsoft Foundry блог)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Студија случаја 8: Foundry MCP Playground – Експериментисање и прототиписање

Foundry MCP Playground нуди спремно окружење за експериментисање са MCP серверима и интеграцијама Azure AI Foundry. Развојни тимови могу брзо прототиписати, тестирати и евалуирати AI моделе и радне токове агената користећи ресурсе из Azure AI Foundry каталога и лабораторија. Playground поједностављује подешавање, пружа пример пројеката и подржава колаборативни развој, олакшавајући истраживање најбољих пракси и нових сценарија уз минималан напор. Посебно је користан за тимове који желе да верификују идеје, деле експерименте и убрзају учење без потребе за сложеном инфраструктуром. Смањењем улазне баријере, playground подстиче иновације и доприносе заједнице у MCP и Azure AI Foundry екосистему.

**Референце:**  
- [Foundry MCP Playground GitHub репозиторијум](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### Студија случаја 9: Microsoft Docs MCP сервер – Учење и усавршавање

Microsoft Docs MCP сервер имплементира Model Context Protocol (MCP) сервер који пружа AI асистентима приступ у реалном времену званичној Microsoft документацији. Извршава семантичку претрагу званичне Microsoft техничке документације.

**Референце:**  
- [Microsoft Learn Docs MCP сервер](https://github.com/MicrosoftDocs/mcp)

## Практични пројекти

### Пројекат 1: Изградња MCP сервера са више провајдера

**Циљ:** Креирати MCP сервер који може усмеравати захтеве ка више провајдера AI модела на основу одређених критеријума.

**Захтеви:**  
- Подршка за најмање три различита провајдера модела (нпр. OpenAI, Anthropic, локални модели)  
- Имплементација механизма усмеравања заснованог на метаподацима захтева  
- Креирање система конфигурације за управљање акредитивима провајдера  
- Додавање кеширања ради оптимизације перформанси и трошкова  
- Изградња једноставне контролне табле за праћење коришћења  

**Кораци имплементације:**  
1. Поставити основну MCP сервер инфраструктуру  
2. Имплементирати адаптере провајдера за сваки AI модел сервис  
3. Креирати логику усмеравања на основу атрибута захтева  
4. Додати кеширање за честе захтеве  
5. Развити контролну таблу за праћење  
6. Тестирати са различитим типовима захтева  

**Технологије:** Изаберите између Python (.NET/Java/Python по вашем избору), Redis за кеширање и једноставан веб фрејмворк за контролну таблу.

### Пројекат 2: Систем за управљање шаблонима упита у предузећу

**Циљ:** Развити систем заснован на MCP-у за управљање, верзионисање и имплементацију шаблона упита у организацији.

**Захтеви:**  
- Креирати централизовани репозиторијум за шаблоне упита  
- Имплементирати верзионисање и радне токове одобравања  
- Изградити могућности тестирања шаблона са пример уноса  
- Развити контроле приступа засноване на улогама  
- Креирати API за преузимање и имплементацију шаблона  

**Кораци имплементације:**  
1. Дизајнирати шему базе података за складиштење шаблона  
2. Креирати основни API за CRUD операције шаблона  
3. Имплементирати систем верзионисања  
4. Изградити радни ток одобравања  
5. Развити оквир за тестирање  
6. Креирати једноставан веб интерфејс за управљање  
7. Интегрисати са MCP сервером  

**Технологије:** По вашем избору backend фрејмворк, SQL или NoSQL база података и frontend фрејмворк за интерфејс управљања.

### Пројекат 3: Платформа за генерисање садржаја заснована на MCP-у

**Циљ:** Изградити платформу за генерисање садржаја која користи MCP за доследне резултате у различитим типовима садржаја.

**Захтеви:**  
- Подршка за више формата садржаја (блог постови, друштвени медији, маркетиншки текстови)  
- Имплементација генерисања заснованог на шаблонима са опцијама прилагођавања  
- Креирање система за рецензију и повратне информације
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Почетна страница за Remote MCP Server имплементације у Azure Functions са линковима ка репозиторijумима специфичним за језике  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Шаблон за брзи почетак за креирање и деплојовање прилагођених remote MCP сервера користећи Azure Functions са Python-ом  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Шаблон за брзи почетак за креирање и деплојовање прилагођених remote MCP сервера користећи Azure Functions са .NET/C#  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Шаблон за брзи почетак за креирање и деплојовање прилагођених remote MCP сервера користећи Azure Functions са TypeScript-ом  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Azure API Management као AI Gateway ка Remote MCP серверима користећи Python  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - APIM ❤️ AI експерименти укључујући MCP могућности, интеграцију са Azure OpenAI и AI Foundry  

Ови репозиторијуми пружају различите имплементације, шаблоне и ресурсе за рад са Model Context Protocol-ом у различитим програмским језицима и Azure сервисима. Обухватају широк спектар употребних случајева од основних имплементација сервера до аутентификације, облачног деплоја и сценарија интеграције у предузећима.  

#### MCP Resources Directory  

[Директоријум MCP Resources](https://github.com/microsoft/mcp/tree/main/Resources) у званичном Microsoft MCP репозиторијуму пружа курирани избор примерка ресурса, шаблона упита и дефиниција алата за коришћење са Model Context Protocol серверима. Овај директоријум је осмишљен да помогне програмерима да брзо почну са MCP-ом нудећи поновно употребљиве грађевинске блокове и примере најбољих пракси за:  

- **Prompt Templates:** Спремни шаблони упита за уобичајене AI задатке и сценарије, које можете прилагодити за своје MCP сервер имплементације.  
- **Tool Definitions:** Примери шема алата и метаподатака за стандардизацију интеграције и позивања алата на различитим MCP серверима.  
- **Resource Samples:** Примери дефиниција ресурса за повезивање са изворима података, API-јима и спољним сервисима у оквиру MCP оквира.  
- **Reference Implementations:** Практични примери који показују како структуирати и организовати ресурсе, упите и алате у реалним MCP пројектима.  

Ови ресурси убрзавају развој, промовишу стандарде и помажу у обезбеђивању најбољих пракси приликом креирања и деплоја MCP базираних решења.  

#### MCP Resources Directory  
- [MCP Resources (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)  

### Истраживачке могућности  

- Ефикасне технике оптимизације упита у оквиру MCP оквира  
- Безбедносни модели за мулти-тенант MCP деплоје  
- Поређење перформанси различитих MCP имплементација  
- Формалне методе верификације MCP сервера  

## Закључак  

Model Context Protocol (MCP) брзо обликује будућност стандардизоване, безбедне и интероперабилне AI интеграције у различитим индустријама. Кроз студије случаја и практичне пројекте у овом лекцији, видели сте како рани корисници — укључујући Microsoft и Azure — користе MCP за решавање стварних изазова, убрзавање усвајања AI технологија и обезбеђивање усаглашености, безбедности и скалабилности. Модуларни приступ MCP-а омогућава организацијама да повежу велике језичке моделе, алате и податке предузећа у јединствени, ревидирани оквир. Како MCP наставља да се развија, ангажовање у заједници, истраживање отворених ресурса и примена најбољих пракси биће кључни за изградњу робусних, спремних за будућност AI решења.  

## Додатни ресурси  

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

## Вежбе  

1. Анализирајте једну од студија случаја и предложите алтернативни приступ имплементацији.  
2. Изаберите једну од идеја за пројекат и направите детаљну техничку спецификацију.  
3. Истражите индустрију која није обухваћена студијама случаја и опишите како MCP може решити њене специфичне изазове.  
4. Истражите један од будућих праваца и осмислите концепт новог MCP проширења које би га подржало.  

Следеће: [Best Practices](../08-BestPractices/README.md)

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI сервиса за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако тежимо прецизности, молимо вас да имате у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешна тумачења која произилазе из коришћења овог превода.