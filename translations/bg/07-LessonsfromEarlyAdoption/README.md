<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-07-14T04:41:14+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "bg"
}
-->
# Уроци от ранните потребители

## Преглед

Този урок разглежда как ранните потребители са използвали Model Context Protocol (MCP), за да решават реални предизвикателства и да стимулират иновации в различни индустрии. Чрез подробни казуси и практически проекти ще видите как MCP позволява стандартизирана, сигурна и мащабируема интеграция на изкуствен интелект — свързвайки големи езикови модели, инструменти и корпоративни данни в единна рамка. Ще придобиете практически опит в проектирането и изграждането на решения, базирани на MCP, ще научите от доказани модели за внедряване и ще откриете най-добрите практики за използване на MCP в продукционни среди. Урокът също така подчертава нововъзникващи тенденции, бъдещи посоки и отворени ресурси, които ще ви помогнат да останете на върха на технологиите MCP и развиващата се екосистема около тях.

## Цели на обучението

- Анализиране на реални внедрявания на MCP в различни индустрии  
- Проектиране и изграждане на пълни приложения, базирани на MCP  
- Изследване на нововъзникващи тенденции и бъдещи посоки в MCP технологията  
- Прилагане на най-добрите практики в реални сценарии на разработка  

## Реални внедрявания на MCP

### Казус 1: Автоматизация на клиентската поддръжка в предприятия

Международна корпорация внедри решение, базирано на MCP, за стандартизиране на AI взаимодействията в техните системи за клиентска поддръжка. Това им позволи да:

- Създадат единен интерфейс за множество доставчици на LLM  
- Поддържат последователно управление на подсказките между отделите  
- Внедрят стабилни мерки за сигурност и съответствие  
- Лесно превключват между различни AI модели според конкретните нужди  

**Техническа реализация:**  
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

**Резултати:** 30% намаление на разходите за модели, 45% подобрение в последователността на отговорите и засилено съответствие в глобалните операции.

### Казус 2: Диагностичен асистент в здравеопазването

Доставчик на здравни услуги разработи MCP инфраструктура за интегриране на множество специализирани медицински AI модели, като същевременно гарантира защита на чувствителните пациентски данни:

- Безпроблемно превключване между общи и специализирани медицински модели  
- Строги мерки за поверителност и одитни следи  
- Интеграция с вече съществуващи системи за електронни здравни досиета (EHR)  
- Последователно инженерство на подсказките за медицинска терминология  

**Техническа реализация:**  
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

**Резултати:** Подобрени диагностични предложения за лекари с пълно спазване на HIPAA и значително намаляване на превключването между системи.

### Казус 3: Анализ на риска във финансовите услуги

Финансова институция внедри MCP за стандартизиране на процесите по анализ на риска в различни отдели:

- Създаден единен интерфейс за модели за кредитен риск, откриване на измами и инвестиционен риск  
- Внедрени строги контролни механизми за достъп и версиониране на моделите  
- Осигурена възможност за одит на всички AI препоръки  
- Поддържане на последователен формат на данните в различни системи  

**Техническа реализация:**  
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

**Резултати:** Подобрено регулаторно съответствие, 40% по-бързи цикли на внедряване на модели и повишена последователност в оценката на риска между отделите.

### Казус 4: Microsoft Playwright MCP сървър за автоматизация на браузъра

Microsoft разработи [Playwright MCP сървър](https://github.com/microsoft/playwright-mcp), който позволява сигурна и стандартизирана автоматизация на браузъра чрез Model Context Protocol. Това решение дава възможност на AI агенти и LLM да взаимодействат с уеб браузъри по контролиран, одитируем и разширяем начин — позволявайки случаи на употреба като автоматизирано уеб тестване, извличане на данни и крайни работни потоци.

- Излага възможности за автоматизация на браузъра (навигация, попълване на форми, заснемане на екрани и др.) като MCP инструменти  
- Внедрява строги контролни механизми за достъп и изолиране, за да предотврати неоторизирани действия  
- Осигурява подробни одитни записи за всички взаимодействия с браузъра  
- Поддържа интеграция с Azure OpenAI и други доставчици на LLM за автоматизация, управлявана от агенти  

**Техническа реализация:**  
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
- Позволи сигурна, програмна автоматизация на браузъра за AI агенти и LLM  
- Намали ръчния труд при тестване и подобри покритието на тестовете за уеб приложения  
- Осигури многократно използваема и разширяема рамка за интеграция на браузър-базирани инструменти в корпоративни среди  

**Референции:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Казус 5: Azure MCP – Enterprise-Grade Model Context Protocol като услуга

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) е управлявана, корпоративна реализация на Model Context Protocol от Microsoft, предназначена да предоставя мащабируеми, сигурни и съвместими MCP сървърни възможности като облачна услуга. Azure MCP позволява на организациите бързо да внедряват, управляват и интегрират MCP сървъри с Azure AI, данни и услуги за сигурност, намалявайки оперативните разходи и ускорявайки приемането на AI.

- Пълно управляван хостинг на MCP сървъри с вградени възможности за мащабиране, мониторинг и сигурност  
- Родна интеграция с Azure OpenAI, Azure AI Search и други Azure услуги  
- Корпоративна автентикация и авторизация чрез Microsoft Entra ID  
- Поддръжка на персонализирани инструменти, шаблони за подсказки и конектори към ресурси  
- Съответствие с корпоративни изисквания за сигурност и регулации  

**Техническа реализация:**  
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
- Намалено време за постигане на стойност в корпоративни AI проекти чрез готова, съвместима MCP сървърна платформа  
- Оптимизирана интеграция на LLM, инструменти и корпоративни източници на данни  
- Подобрена сигурност, наблюдаемост и оперативна ефективност при MCP натоварвания  

**Референции:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Казус 6: NLWeb  
MCP (Model Context Protocol) е нов протокол за чатботове и AI асистенти за взаимодействие с инструменти. Всяка инстанция на NLWeb е също MCP сървър, който поддържа един основен метод, ask, използван за задаване на въпроси на уебсайт на естествен език. Върнатият отговор използва schema.org, широко използван речник за описание на уеб данни. По същество, MCP е за NLWeb това, което HTTP е за HTML. NLWeb комбинира протоколи, формати на Schema.org и примерен код, за да помогне на сайтовете бързо да създават тези крайни точки, като предоставя ползи както за хората чрез разговорни интерфейси, така и за машините чрез естествено взаимодействие агент към агент.

NLWeb има две отделни компоненти:  
- Протокол, много прост за начало, за интерфейс с сайт на естествен език и формат, използващ json и schema.org за върнатия отговор. Вижте документацията за REST API за повече подробности.  
- Лесна за използване реализация на (1), която използва съществуваща маркировка за сайтове, които могат да се абстрахират като списъци с елементи (продукти, рецепти, атракции, ревюта и др.). Заедно с набор от потребителски интерфейсни джаджи, сайтовете лесно могат да предоставят разговорни интерфейси към съдържанието си. Вижте документацията за Life of a chat query за повече подробности как работи това.  

**Референции:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Казус 7: MCP за Foundry – Интеграция на Azure AI агенти

Azure AI Foundry MCP сървърите демонстрират как MCP може да се използва за оркестрация и управление на AI агенти и работни потоци в корпоративни среди. Чрез интеграция на MCP с Azure AI Foundry организациите могат да стандартизират взаимодействията на агентите, да използват управлението на работни потоци на Foundry и да осигурят сигурни, мащабируеми внедрявания. Този подход позволява бързо прототипиране, стабилен мониторинг и безпроблемна интеграция с Azure AI услуги, поддържайки напреднали сценарии като управление на знания и оценка на агенти. Разработчиците се възползват от единен интерфейс за изграждане, внедряване и наблюдение на агентски потоци, а IT екипите получават подобрена сигурност, съответствие и оперативна ефективност. Решението е идеално за предприятия, които искат да ускорят приемането на AI и да запазят контрол върху сложни процеси, управлявани от агенти.

**Референции:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Казус 8: Foundry MCP Playground – Експериментиране и прототипиране

Foundry MCP Playground предлага готова за използване среда за експериментиране с MCP сървъри и интеграции с Azure AI Foundry. Разработчиците могат бързо да прототипират, тестват и оценяват AI модели и агентски работни потоци, използвайки ресурси от Azure AI Foundry Catalog и Labs. Плейграундът улеснява настройката, предоставя примерни проекти и поддържа съвместна разработка, което прави лесно изследването на най-добрите практики и нови сценарии с минимални усилия. Особено полезен е за екипи, които искат да валидират идеи, споделят експерименти и ускорят обучението без нужда от сложна инфраструктура. Чрез намаляване на бариерите за влизане, плейграундът подпомага иновациите и приноса на общността в екосистемата на MCP и Azure AI Foundry.

**Референции:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### Казус 9: Microsoft Docs MCP Server – Обучение и умения

Microsoft Docs MCP Server реализира Model Context Protocol (MCP) сървър, който предоставя на AI асистенти достъп в реално време до официалната документация на Microsoft. Извършва семантично търсене в официалната техническа документация на Microsoft.

**Референции:**  
- [Microsoft Learn Docs MCP Server](https://github.com/MicrosoftDocs/mcp)

## Практически проекти

### Проект 1: Изграждане на MCP сървър с множество доставчици

**Цел:** Създаване на MCP сървър, който може да маршрутизира заявки към различни доставчици на AI модели според конкретни критерии.

**Изисквания:**  
- Поддръжка на поне три различни доставчици на модели (например OpenAI, Anthropic, локални модели)  
- Внедряване на механизъм за маршрутизиране, базиран на метаданни на заявката  
- Създаване на конфигурационна система за управление на идентификационни данни на доставчиците  
- Добавяне на кеширане за оптимизиране на производителността и разходите  
- Изграждане на прост табло за мониторинг на използването  

**Стъпки за реализация:**  
1. Настройка на базовата MCP сървърна инфраструктура  
2. Имплементиране на адаптери за всеки AI модел доставчик  
3. Създаване на логика за маршрутизиране според атрибутите на заявката  
4. Добавяне на кеширащи механизми за чести заявки  
5. Разработка на табло за мониторинг  
6. Тестване с различни модели на заявки  

**Технологии:** Избор между Python (.NET/Java/Python според предпочитанията), Redis за кеширане и прост уеб фреймуърк за таблото.

### Проект 2: Корпоративна система за управление на подсказки

**Цел:** Разработване на система, базирана на MCP, за управление, версиониране и внедряване на шаблони за подсказки в организацията.

**Изисквания:**  
- Създаване на централен репозиторий за шаблони на подсказки  
- Внедряване на версиониране и работни потоци за одобрение  
- Изграждане на възможности за тестване на шаблони с примерни входни данни  
- Разработка на контрол на достъпа, базиран на роли  
- Създаване на API за извличане и внедряване на шаблони  

**Стъпки за реализация:**  
1. Проектиране на база данни за съхранение на шаблони  
2. Създаване на основно API за CRUD операции с шаблони  
3. Имплементиране на система за версиониране  
4. Изграждане на работен поток за одобрение  
5. Разработка на тестова рамка  
6. Създаване на прост уеб интерфейс за управление  
7. Интеграция с MCP сървър  

**Технологии:** Избор на бекенд фреймуърк, SQL или NoSQL база данни и фронтенд фреймуърк за интерфейса.

### Проект 3: Платформа за генериране на съдържание, базирана на MCP

**Цел:** Изграждане на платформа за генериране на съдържание, която използва MCP за осигуряване на последователни резултати при различни типове съдържание.

**Изисквания:**  
- Поддръжка на множество формати на съдържание (блог постове, социални мрежи, маркетингови текстове)  
- Имплементиране на шаблонно генериране с възможности за персонализация  
- Създаване на система за преглед и обратна връзка за съдържанието  
- Проследяване на метрики за представяне на съдържанието  
- Поддръжка на версиониране и итерации на съдържанието  

**Стъпки за реализация:**  
1. Настройка на MCP клиентска инфраструктура  
2. Създаване на шаблони за различни типове съдържание  
3. Изграждане на генерационен работен поток  
4. Имплементиране на система за преглед  
5. Разработка на система за проследяване на метрики  
6. Създаване на потребителски интерфейс за управление на шаблони и генериране на съдържание  

**Технологии:** Предпочитан програмен език, уеб фреймуърк и база данни.

## Бъдещи посоки за MCP технологията

### Нововъзникващи тенденции

1. **Мултимодален MCP**  
   - Разширяване на MCP за стандартизиране на взаимодействия с модели за изображения, аудио и видео  
   - Развитие на възможности за крос-модално разсъждение  
   - Стандартизирани формати за подсказки за различни модалности  

2. **Федеративна MCP инфраструктура**  
   - Разпределени MCP мрежи, които могат да споделят ресурси между организации  
   - Стандартизирани протоколи за сиг
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Начална страница за реализации на Remote MCP Server в Azure Functions с връзки към репозитории за конкретни езици
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Шаблон за бърз старт за създаване и разгръщане на персонализирани remote MCP сървъри с Azure Functions и Python
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Шаблон за бърз старт за създаване и разгръщане на персонализирани remote MCP сървъри с Azure Functions и .NET/C#
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Шаблон за бърз старт за създаване и разгръщане на персонализирани remote MCP сървъри с Azure Functions и TypeScript
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Azure API Management като AI Gateway към Remote MCP сървъри с Python
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - Експерименти с APIM ❤️ AI, включително MCP възможности, интегриращи се с Azure OpenAI и AI Foundry

Тези репозитории предоставят различни реализации, шаблони и ресурси за работа с Model Context Protocol на различни програмни езици и Azure услуги. Те обхващат широк спектър от случаи на употреба – от базови сървърни реализации до автентикация, облачно разгръщане и интеграция в корпоративна среда.

#### MCP Resources Directory

[Директорията MCP Resources](https://github.com/microsoft/mcp/tree/main/Resources) в официалното Microsoft MCP хранилище предлага подбрана колекция от примерни ресурси, шаблони за prompt-и и дефиниции на инструменти за използване с Model Context Protocol сървъри. Тази директория е създадена, за да помогне на разработчиците бързо да започнат с MCP, като предоставя многократно използваеми компоненти и примери за добри практики за:

- **Prompt Templates:** Готови за използване шаблони за prompt-и за често срещани AI задачи и сценарии, които могат да се адаптират за вашите MCP сървърни реализации.
- **Tool Definitions:** Примерни схеми и метаданни на инструменти за стандартизиране на интеграцията и извикването на инструменти в различни MCP сървъри.
- **Resource Samples:** Примерни дефиниции на ресурси за свързване към източници на данни, API-та и външни услуги в рамките на MCP.
- **Reference Implementations:** Практически примери, които показват как да се структурират и организират ресурси, prompt-и и инструменти в реални MCP проекти.

Тези ресурси ускоряват разработката, насърчават стандартизацията и подпомагат прилагането на добри практики при изграждането и разгръщането на решения, базирани на MCP.

#### MCP Resources Directory
- [MCP Resources (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)

### Изследователски възможности

- Ефективни техники за оптимизация на prompt-и в рамките на MCP
- Модели за сигурност при мулти-тенант MCP разгръщания
- Бенчмаркинг на производителността при различни MCP реализации
- Формални методи за верификация на MCP сървъри

## Заключение

Model Context Protocol (MCP) бързо оформя бъдещето на стандартизирана, сигурна и съвместима AI интеграция в различни индустрии. Чрез казусите и практическите проекти в този урок видяхте как ранните приематели – включително Microsoft и Azure – използват MCP за решаване на реални предизвикателства, ускоряване на приемането на AI и осигуряване на съответствие, сигурност и мащабируемост. Модулният подход на MCP позволява на организациите да свързват големи езикови модели, инструменти и корпоративни данни в единна, проверяема рамка. С развитието на MCP, активното участие в общността, изследването на отворени ресурси и прилагането на добри практики ще бъдат ключови за изграждането на стабилни и готови за бъдещето AI решения.

## Допълнителни ресурси

- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)
- [Foundry MCP Playground](https://github.com/azure-ai-foundry/foundry-mcp-playground)
- [Интегриране на Azure AI агенти с MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)
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

## Упражнения

1. Анализирайте един от казусите и предложете алтернативен подход за реализация.
2. Изберете една от проектните идеи и създайте подробна техническа спецификация.
3. Изследвайте индустрия, която не е разгледана в казусите, и очертайте как MCP може да реши специфичните ѝ предизвикателства.
4. Разгледайте една от бъдещите посоки и създайте концепция за ново MCP разширение, което да я поддържа.

Следва: [Best Practices](../08-BestPractices/README.md)

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматизираните преводи могат да съдържат грешки или неточности. Оригиналният документ на неговия роден език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за каквито и да е недоразумения или неправилни тълкувания, произтичащи от използването на този превод.