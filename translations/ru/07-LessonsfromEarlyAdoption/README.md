<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-07-14T04:08:43+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "ru"
}
-->
# Уроки от ранних пользователей

## Обзор

В этом уроке рассматривается, как ранние пользователи применяли Model Context Protocol (MCP) для решения реальных задач и стимулирования инноваций в различных отраслях. Через подробные кейс-стади и практические проекты вы увидите, как MCP обеспечивает стандартизированную, безопасную и масштабируемую интеграцию ИИ — объединяя большие языковые модели, инструменты и корпоративные данные в единую систему. Вы получите практический опыт проектирования и создания решений на базе MCP, изучите проверенные шаблоны реализации и узнаете лучшие практики развертывания MCP в производственной среде. Урок также освещает новые тенденции, перспективы развития и открытые ресурсы, которые помогут вам оставаться на переднем крае технологий MCP и его развивающейся экосистемы.

## Цели обучения

- Анализировать реальные реализации MCP в различных отраслях
- Проектировать и создавать полноценные приложения на базе MCP
- Изучать новые тенденции и направления развития технологии MCP
- Применять лучшие практики в реальных сценариях разработки

## Реальные реализации MCP

### Кейс 1: Автоматизация поддержки клиентов в корпоративной среде

Международная корпорация внедрила решение на базе MCP для стандартизации взаимодействия с ИИ в своих системах поддержки клиентов. Это позволило:

- Создать единый интерфейс для нескольких поставщиков LLM
- Обеспечить единое управление подсказками во всех отделах
- Внедрить надежные меры безопасности и соответствия требованиям
- Легко переключаться между разными моделями ИИ в зависимости от задач

**Техническая реализация:**  
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

**Результаты:** Сокращение затрат на модели на 30%, повышение согласованности ответов на 45%, улучшение соответствия требованиям по всему миру.

### Кейс 2: Диагностический помощник в здравоохранении

Медицинская организация разработала инфраструктуру MCP для интеграции нескольких специализированных медицинских ИИ-моделей с сохранением защиты конфиденциальных данных пациентов:

- Плавное переключение между универсальными и специализированными медицинскими моделями
- Строгий контроль конфиденциальности и ведение аудита
- Интеграция с существующими системами электронных медицинских карт (EHR)
- Единообразное создание подсказок с учетом медицинской терминологии

**Техническая реализация:**  
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

**Результаты:** Улучшение диагностических рекомендаций для врачей при полном соблюдении HIPAA и значительное сокращение переключений между системами.

### Кейс 3: Анализ рисков в финансовом секторе

Финансовое учреждение внедрило MCP для стандартизации процессов анализа рисков в разных отделах:

- Создан единый интерфейс для моделей кредитного риска, выявления мошенничества и инвестиционного риска
- Внедрен строгий контроль доступа и версионирование моделей
- Обеспечена возможность аудита всех рекомендаций ИИ
- Поддерживается единый формат данных в различных системах

**Техническая реализация:**  
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

**Результаты:** Повышение соответствия нормативным требованиям, ускорение циклов развертывания моделей на 40%, улучшение согласованности оценки рисков.

### Кейс 4: Microsoft Playwright MCP Server для автоматизации браузера

Microsoft разработала [Playwright MCP server](https://github.com/microsoft/playwright-mcp) для обеспечения безопасной и стандартизированной автоматизации браузера через Model Context Protocol. Это решение позволяет ИИ-агентам и LLM взаимодействовать с веб-браузерами в контролируемом, проверяемом и расширяемом формате — поддерживая такие сценарии, как автоматизированное тестирование веба, извлечение данных и сквозные рабочие процессы.

- Предоставляет возможности автоматизации браузера (навигация, заполнение форм, создание скриншотов и др.) в виде MCP-инструментов
- Внедряет строгий контроль доступа и песочницу для предотвращения несанкционированных действий
- Обеспечивает подробные журналы аудита всех взаимодействий с браузером
- Поддерживает интеграцию с Azure OpenAI и другими поставщиками LLM для автоматизации с участием агентов

**Техническая реализация:**  
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

**Результаты:**  
- Обеспечена безопасная программная автоматизация браузера для ИИ-агентов и LLM  
- Снижены затраты на ручное тестирование и улучшено покрытие тестами веб-приложений  
- Предоставлена многоразовая и расширяемая платформа для интеграции браузерных инструментов в корпоративной среде

**Ссылки:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Кейс 5: Azure MCP – корпоративный Model Context Protocol как сервис

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) — это управляемая Microsoft корпоративная реализация Model Context Protocol, предназначенная для предоставления масштабируемых, безопасных и соответствующих требованиям MCP-серверов в облаке. Azure MCP позволяет организациям быстро развертывать, управлять и интегрировать MCP-серверы с Azure AI, данными и службами безопасности, снижая операционные затраты и ускоряя внедрение ИИ.

- Полностью управляемый хостинг MCP-серверов с автоматическим масштабированием, мониторингом и безопасностью
- Нативная интеграция с Azure OpenAI, Azure AI Search и другими сервисами Azure
- Корпоративная аутентификация и авторизация через Microsoft Entra ID
- Поддержка пользовательских инструментов, шаблонов подсказок и коннекторов ресурсов
- Соответствие корпоративным требованиям безопасности и нормативам

**Техническая реализация:**  
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

**Результаты:**  
- Сокращение времени выхода на результат для корпоративных ИИ-проектов благодаря готовой, соответствующей требованиям платформе MCP-сервера  
- Упрощение интеграции LLM, инструментов и корпоративных источников данных  
- Повышение безопасности, наблюдаемости и операционной эффективности MCP-нагрузок

**Ссылки:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Кейс 6: NLWeb  
MCP (Model Context Protocol) — это новый протокол для чат-ботов и ИИ-ассистентов для взаимодействия с инструментами. Каждый экземпляр NLWeb также является MCP-сервером, поддерживающим один основной метод ask, который используется для запроса сайта на естественном языке. Возвращаемый ответ использует schema.org — широко применяемый словарь для описания веб-данных. Говоря упрощенно, MCP — это NLWeb, как HTTP для HTML. NLWeb объединяет протоколы, форматы Schema.org и примерный код, чтобы помочь сайтам быстро создавать такие конечные точки, принося пользу как людям через разговорные интерфейсы, так и машинам через естественное взаимодействие агентов.

NLWeb состоит из двух основных компонентов:  
- Протокол, очень простой для начала, для взаимодействия с сайтом на естественном языке и формат, использующий json и schema.org для ответа. Подробнее см. документацию по REST API.  
- Простая реализация (1), использующая существующую разметку для сайтов, которые можно представить в виде списков элементов (продукты, рецепты, достопримечательности, отзывы и т.д.). Вместе с набором виджетов пользовательского интерфейса сайты могут легко предоставлять разговорные интерфейсы к своему контенту. Подробнее см. документацию по Life of a chat query.

**Ссылки:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Кейс 7: MCP для Foundry – интеграция Azure AI агентов

MCP-серверы Azure AI Foundry демонстрируют, как MCP можно использовать для оркестрации и управления ИИ-агентами и рабочими процессами в корпоративной среде. Интеграция MCP с Azure AI Foundry позволяет стандартизировать взаимодействия агентов, использовать управление рабочими процессами Foundry и обеспечивать безопасное, масштабируемое развертывание. Такой подход ускоряет прототипирование, обеспечивает надежный мониторинг и бесшовную интеграцию с сервисами Azure AI, поддерживая продвинутые сценарии, такие как управление знаниями и оценка агентов. Разработчики получают единый интерфейс для создания, развертывания и мониторинга конвейеров агентов, а ИТ-команды — улучшенную безопасность, соответствие требованиям и операционную эффективность. Решение идеально подходит для предприятий, стремящихся ускорить внедрение ИИ и сохранить контроль над сложными процессами с участием агентов.

**Ссылки:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Кейс 8: Foundry MCP Playground – эксперименты и прототипирование

Foundry MCP Playground предоставляет готовую среду для экспериментов с MCP-серверами и интеграциями Azure AI Foundry. Разработчики могут быстро создавать прототипы, тестировать и оценивать ИИ-модели и рабочие процессы агентов, используя ресурсы из Azure AI Foundry Catalog и Labs. Плейграунд упрощает настройку, предоставляет примерные проекты и поддерживает совместную разработку, облегчая изучение лучших практик и новых сценариев с минимальными затратами. Особенно полезен для команд, которые хотят проверить идеи, делиться экспериментами и ускорить обучение без сложной инфраструктуры. Снижая порог входа, плейграунд способствует инновациям и развитию сообщества в экосистеме MCP и Azure AI Foundry.

**Ссылки:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### Кейс 9: Microsoft Docs MCP Server – обучение и повышение квалификации  
Microsoft Docs MCP Server реализует MCP-сервер, который предоставляет ИИ-ассистентам доступ в реальном времени к официальной документации Microsoft. Выполняет семантический поиск по официальной технической документации Microsoft.

**Ссылки:**  
- [Microsoft Learn Docs MCP Server](https://github.com/MicrosoftDocs/mcp)

## Практические проекты

### Проект 1: Создание MCP-сервера с несколькими провайдерами

**Цель:** Создать MCP-сервер, который маршрутизирует запросы к нескольким поставщикам моделей ИИ на основе заданных критериев.

**Требования:**  
- Поддержка минимум трех разных провайдеров моделей (например, OpenAI, Anthropic, локальные модели)  
- Реализация механизма маршрутизации на основе метаданных запроса  
- Создание системы конфигурации для управления учетными данными провайдеров  
- Добавление кэширования для оптимизации производительности и затрат  
- Разработка простого дашборда для мониторинга использования

**Шаги реализации:**  
1. Настроить базовую инфраструктуру MCP-сервера  
2. Реализовать адаптеры провайдеров для каждого сервиса моделей ИИ  
3. Создать логику маршрутизации на основе атрибутов запроса  
4. Добавить механизмы кэширования для частых запросов  
5. Разработать дашборд для мониторинга  
6. Провести тестирование с разными сценариями запросов

**Технологии:** Выбор из Python (.NET/Java/Python по предпочтению), Redis для кэширования и простой веб-фреймворк для дашборда.

### Проект 2: Корпоративная система управления подсказками

**Цель:** Разработать систему на базе MCP для управления, версионирования и развертывания шаблонов подсказок в организации.

**Требования:**  
- Создать централизованный репозиторий шаблонов подсказок  
- Реализовать версионирование и процессы утверждения  
- Построить возможности тестирования шаблонов с примерами входных данных  
- Внедрить ролевой контроль доступа  
- Создать API для получения и развертывания шаблонов

**Шаги реализации:**  
1. Спроектировать схему базы данных для хранения шаблонов  
2. Создать основной API для операций CRUD с шаблонами  
3. Реализовать систему версионирования  
4. Построить процесс утверждения  
5. Разработать тестовую среду  
6. Создать простой веб-интерфейс для управления  
7. Интегрировать с MCP-сервером

**Технологии:** Выбор backend-фреймворка, SQL или NoSQL базы данных и frontend-фреймворка для интерфейса управления.

### Проект 3: Платформа генерации контента на базе MCP

**Цель:** Создать платформу генерации контента, использующую MCP для обеспечения согласованных результатов по разным типам контента.

**Требования:**  
- Поддержка нескольких форматов контента (блог-посты, соцсети, маркетинговые тексты)  
- Реализация генерации на основе шаблонов с возможностью настройки  
- Создание системы обзора и обратной связи по контенту  
- Отслеживание метрик эффективности контента  
- Поддержка версионирования и итераций контента

**Шаги реализации:**  
1. Настроить инфраструктуру MCP-клиента  
2. Создать шаблоны для разных типов контента  
3. Построить конвейер генерации контента  
4. Реализовать систему обзора  
5. Разработать систему отслеживания метрик  
6. Создать пользовательский интерфейс для управления шаблонами и генерацией контента

**Технологии:** Предпочтительный язык программирования, веб-фреймворк и система баз данных.

## Перспективы развития технологии MCP

### Новые тенденции

1. **Мульти-модальный MCP**  
   - Расширение MCP для стандартизации взаимодействия с моделями изображений, аудио и видео  
   - Разработка возможностей кросс-модального рассуждения  
   - Стандартизированные форматы подсказок для разных модальностей

2. **Федеративная инфраструктура MCP**  
   - Распределенные сети MCP, способные обмениваться ресурсами между организациями  
   - Стандартизированные протоколы для безопасного обмена моделями  
   - Техники вычислений с сохранением конфиденциальности

3. **Маркетплейсы MCP**  
   - Экосистемы для обмена и монетизации шаблонов и плагинов MCP  
   - Процессы обеспечения качества и сертификации  
   - Интеграция с маркетплейсами моделей

4. **MCP для edge-вычислений**  
   - Адаптация стандартов MCP для устройств с ограниченными ресурсами  
   - Оптимизированные протоколы для сред с низкой пропускной способностью  
   - Специализированные реализации MCP для IoT-экосистем

5. **Регуляторные рамки**  
   - Разработка расширений MCP для соответствия нормативным требованиям  
   - Стандартизированные аудиторские следы и интерфейсы объяснимости  
   - Интеграция с развивающимися рамками управления ИИ

### Решения MCP от Microsoft

Microsoft и Azure разработали несколько открытых репозиториев, помогающих разработчикам внедрять MCP в различных сценариях:

#### Организация Microsoft  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) — MCP-сервер Playwright для автоматизации и тестирования браузера  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) — реализация MCP-сервера OneDrive для локального тестирования и участия сообщества  
3. [NLWeb](https://github.com/microsoft/NlWeb) — набор открытых протоколов и инструментов, основа для AI Web

#### Организация Azure-Samples  
1. [mcp](https://github.com/Azure-Samples/mcp) — ссылки на примеры, инструменты и ресурсы для создания и интеграции MCP-серверов на Azure с использованием разных языков  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) — эталонные MCP-серверы с аутентификацией по текущей спецификации Model Context Protocol
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) — главная страница для реализаций Remote MCP Server в Azure Functions с ссылками на репозитории для разных языков программирования  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) — шаблон быстрого старта для создания и развертывания кастомных удалённых MCP серверов с использованием Azure Functions на Python  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) — шаблон быстрого старта для создания и развертывания кастомных удалённых MCP серверов с использованием Azure Functions на .NET/C#  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) — шаблон быстрого старта для создания и развертывания кастомных удалённых MCP серверов с использованием Azure Functions на TypeScript  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) — Azure API Management в роли AI Gateway для удалённых MCP серверов с использованием Python  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) — эксперименты APIM ❤️ AI, включая возможности MCP, интеграция с Azure OpenAI и AI Foundry  

Эти репозитории предлагают различные реализации, шаблоны и ресурсы для работы с Model Context Protocol на разных языках программирования и в сервисах Azure. Они охватывают широкий спектр сценариев — от базовых серверных реализаций до аутентификации, облачного развертывания и интеграции в корпоративной среде.

#### Каталог ресурсов MCP

[Каталог ресурсов MCP](https://github.com/microsoft/mcp/tree/main/Resources) в официальном репозитории Microsoft MCP содержит тщательно подобранную коллекцию примеров ресурсов, шаблонов подсказок и определений инструментов для использования с серверами Model Context Protocol. Этот каталог создан, чтобы помочь разработчикам быстро начать работу с MCP, предоставляя повторно используемые компоненты и примеры лучших практик для:

- **Шаблоны подсказок:** готовые шаблоны для типовых AI-задач и сценариев, которые можно адаптировать под свои реализации MCP серверов.  
- **Определения инструментов:** примеры схем и метаданных инструментов для стандартизации интеграции и вызова инструментов на разных MCP серверах.  
- **Примеры ресурсов:** образцы определений ресурсов для подключения к источникам данных, API и внешним сервисам в рамках MCP.  
- **Референсные реализации:** практические примеры, демонстрирующие, как структурировать и организовывать ресурсы, подсказки и инструменты в реальных проектах MCP.  

Эти ресурсы ускоряют разработку, способствуют стандартизации и помогают соблюдать лучшие практики при создании и развертывании решений на базе MCP.

#### Каталог ресурсов MCP
- [MCP Resources (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)

### Возможности для исследований

- Эффективные методы оптимизации подсказок в рамках MCP  
- Модели безопасности для многопользовательских развертываний MCP  
- Сравнительный анализ производительности различных реализаций MCP  
- Методы формальной верификации MCP серверов  

## Заключение

Model Context Protocol (MCP) быстро формирует будущее стандартизированной, безопасной и совместимой интеграции AI в различных отраслях. На примерах из этого урока и практических проектах вы увидели, как первопроходцы — включая Microsoft и Azure — используют MCP для решения реальных задач, ускорения внедрения AI и обеспечения соответствия, безопасности и масштабируемости. Модульный подход MCP позволяет организациям объединять большие языковые модели, инструменты и корпоративные данные в единую, проверяемую систему. По мере развития MCP важно оставаться активным в сообществе, изучать открытые ресурсы и применять лучшие практики для создания надёжных и готовых к будущему AI-решений.

## Дополнительные ресурсы

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

## Упражнения

1. Проанализируйте один из кейсов и предложите альтернативный подход к реализации.  
2. Выберите одну из идей проекта и составьте подробную техническую спецификацию.  
3. Изучите отрасль, не рассмотренную в кейсах, и опишите, как MCP может решить её специфические задачи.  
4. Исследуйте одно из направлений развития и разработайте концепцию нового расширения MCP для его поддержки.  

Далее: [Лучшие практики](../08-BestPractices/README.md)

**Отказ от ответственности**:  
Этот документ был переведен с помощью сервиса автоматического перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Несмотря на наши усилия по обеспечению точности, просим учитывать, что автоматический перевод может содержать ошибки или неточности. Оригинальный документ на его исходном языке следует считать авторитетным источником. Для получения критически важной информации рекомендуется обращаться к профессиональному переводу, выполненному человеком. Мы не несем ответственности за любые недоразумения или неправильные толкования, возникшие в результате использования данного перевода.