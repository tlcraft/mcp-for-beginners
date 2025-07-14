<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-07-14T04:47:19+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "uk"
}
-->
# Уроки від ранніх користувачів

## Огляд

Цей урок розглядає, як ранні користувачі використовували Model Context Protocol (MCP) для розв’язання реальних проблем і стимулювання інновацій у різних галузях. Через детальні кейс-стаді та практичні проєкти ви побачите, як MCP забезпечує стандартизовану, безпечну та масштабовану інтеграцію ШІ — поєднуючи великі мовні моделі, інструменти та корпоративні дані в єдиній системі. Ви отримаєте практичний досвід у проєктуванні та створенні рішень на основі MCP, вивчите перевірені шаблони впровадження та дізнаєтеся найкращі практики для розгортання MCP у виробничих середовищах. Урок також висвітлює нові тенденції, майбутні напрямки та відкриті ресурси, які допоможуть вам залишатися на передовій технології MCP та її розвитку.

## Цілі навчання

- Аналізувати реальні впровадження MCP у різних галузях
- Проєктувати та створювати повноцінні додатки на основі MCP
- Досліджувати нові тенденції та майбутні напрямки розвитку MCP
- Застосовувати найкращі практики у реальних сценаріях розробки

## Реальні впровадження MCP

### Кейс-стаді 1: Автоматизація підтримки клієнтів у корпорації

Багатонаціональна корпорація впровадила рішення на основі MCP для стандартизації взаємодії ШІ у своїх системах підтримки клієнтів. Це дозволило їм:

- Створити уніфікований інтерфейс для кількох провайдерів LLM
- Підтримувати послідовне управління запитами між відділами
- Впровадити надійні заходи безпеки та відповідності
- Легко переключатися між різними моделями ШІ залежно від потреб

**Технічна реалізація:**  
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

**Результати:** Зниження витрат на моделі на 30%, покращення узгодженості відповідей на 45% та підвищення відповідності вимогам у глобальних операціях.

### Кейс-стаді 2: Асистент діагностики в охороні здоров’я

Медичний заклад розробив інфраструктуру MCP для інтеграції кількох спеціалізованих медичних моделей ШІ, забезпечуючи захист чутливих даних пацієнтів:

- Безшовне переключення між загальними та спеціалізованими медичними моделями
- Жорсткий контроль конфіденційності та ведення аудиту
- Інтеграція з існуючими системами електронних медичних записів (EHR)
- Послідовне формування запитів з урахуванням медичної термінології

**Технічна реалізація:**  
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

**Результати:** Покращені діагностичні рекомендації для лікарів при повній відповідності HIPAA та значне зменшення переключень між системами.

### Кейс-стаді 3: Аналіз ризиків у фінансових послугах

Фінансова установа впровадила MCP для стандартизації процесів аналізу ризиків у різних відділах:

- Створено уніфікований інтерфейс для моделей кредитного ризику, виявлення шахрайства та інвестиційних ризиків
- Впроваджено суворий контроль доступу та версіонування моделей
- Забезпечено аудит усіх рекомендацій ШІ
- Підтримано послідовне форматування даних у різних системах

**Технічна реалізація:**  
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

**Результати:** Покращена відповідність регуляторним вимогам, на 40% швидший цикл розгортання моделей та підвищена узгодженість оцінки ризиків у відділах.

### Кейс-стаді 4: Microsoft Playwright MCP Server для автоматизації браузера

Microsoft розробила [Playwright MCP server](https://github.com/microsoft/playwright-mcp) для забезпечення безпечної, стандартизованої автоматизації браузера через Model Context Protocol. Це рішення дозволяє агентам ШІ та LLM взаємодіяти з веб-браузерами у контрольованому, аудиторському та розширюваному режимі — підтримуючи такі сценарії, як автоматизоване тестування веб, вилучення даних та повні робочі процеси.

- Надає можливості автоматизації браузера (навігація, заповнення форм, знімки екрана тощо) як інструменти MCP
- Впроваджує суворий контроль доступу та ізоляцію для запобігання несанкціонованим діям
- Забезпечує детальні журнали аудиту для всіх взаємодій з браузером
- Підтримує інтеграцію з Azure OpenAI та іншими провайдерами LLM для автоматизації, керованої агентами

**Технічна реалізація:**  
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

**Результати:**  
- Забезпечено безпечну програмну автоматизацію браузера для агентів ШІ та LLM  
- Зменшено ручні зусилля з тестування та покращено покриття тестів веб-додатків  
- Надано багаторазову, розширювану платформу для інтеграції браузерних інструментів у корпоративних середовищах

**Посилання:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Кейс-стаді 5: Azure MCP – корпоративний Model Context Protocol як сервіс

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) — це кероване Microsoft корпоративне рішення Model Context Protocol, розроблене для надання масштабованих, безпечних і відповідних MCP серверних можливостей у хмарі. Azure MCP дозволяє організаціям швидко розгортати, керувати та інтегрувати MCP сервери з Azure AI, даними та службами безпеки, знижуючи операційні витрати та прискорюючи впровадження ШІ.

- Повністю керований хостинг MCP серверів з вбудованим масштабуванням, моніторингом і безпекою
- Рідна інтеграція з Azure OpenAI, Azure AI Search та іншими сервісами Azure
- Корпоративна аутентифікація та авторизація через Microsoft Entra ID
- Підтримка кастомних інструментів, шаблонів запитів і конекторів ресурсів
- Відповідність корпоративним вимогам безпеки та регуляторним нормам

**Технічна реалізація:**  
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

**Результати:**  
- Скорочення часу до отримання результату для корпоративних проєктів ШІ завдяки готовій, відповідній платформі MCP серверів  
- Спрощена інтеграція LLM, інструментів та корпоративних джерел даних  
- Підвищена безпека, спостережуваність та операційна ефективність MCP навантажень

**Посилання:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Кейс-стаді 6: NLWeb  
MCP (Model Context Protocol) — це новий протокол для чатботів і AI-асистентів для взаємодії з інструментами. Кожен екземпляр NLWeb також є MCP сервером, який підтримує один основний метод ask, що використовується для запитання сайту природною мовою. Отримана відповідь використовує schema.org — широко вживаний словник для опису веб-даних. У спрощеному вигляді MCP — це NLWeb так само, як Http — це HTML. NLWeb поєднує протоколи, формати Schema.org і приклади коду, щоб допомогти сайтам швидко створювати такі кінцеві точки, вигідні як для людей через розмовні інтерфейси, так і для машин через природну взаємодію агентів.

NLWeb складається з двох окремих компонентів:  
- Протокол, дуже простий на початку, для взаємодії з сайтом природною мовою та формату, що використовує json і schema.org для відповіді. Детальніше див. у документації REST API.  
- Проста реалізація (1), що використовує існуючу розмітку для сайтів, які можна абстрагувати як списки елементів (продукти, рецепти, атракції, відгуки тощо). Разом із набором віджетів інтерфейсу користувача сайти можуть легко надавати розмовні інтерфейси до свого контенту. Детальніше див. у документації Life of a chat query.

**Посилання:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Кейс-стаді 7: MCP для Foundry – інтеграція агентів Azure AI

Сервери Azure AI Foundry MCP демонструють, як MCP можна використовувати для оркестрації та керування агентами ШІ і робочими процесами в корпоративних середовищах. Інтегруючи MCP з Azure AI Foundry, організації можуть стандартизувати взаємодію агентів, використовувати управління робочими процесами Foundry та забезпечувати безпечне, масштабоване розгортання. Такий підхід дозволяє швидко створювати прототипи, надійно моніторити та безшовно інтегруватися з сервісами Azure AI, підтримуючи складні сценарії, такі як управління знаннями та оцінка агентів. Розробники отримують уніфікований інтерфейс для створення, розгортання та моніторингу конвеєрів агентів, а ІТ-команди — покращену безпеку, відповідність і операційну ефективність. Рішення ідеально підходить для підприємств, які прагнуть прискорити впровадження ШІ та зберегти контроль над складними процесами, керованими агентами.

**Посилання:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Інтеграція агентів Azure AI з MCP (блог Microsoft Foundry)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Кейс-стаді 8: Foundry MCP Playground – експерименти та прототипування

Foundry MCP Playground пропонує готове середовище для експериментів із MCP серверами та інтеграціями Azure AI Foundry. Розробники можуть швидко створювати прототипи, тестувати та оцінювати моделі ШІ і робочі процеси агентів, використовуючи ресурси з Azure AI Foundry Catalog і Labs. Плейграунд спрощує налаштування, надає приклади проєктів і підтримує спільну розробку, що полегшує вивчення найкращих практик і нових сценаріїв з мінімальними витратами. Особливо корисний для команд, які хочуть перевірити ідеї, поділитися експериментами та прискорити навчання без складної інфраструктури. Зниження порогу входу сприяє інноваціям і внескам спільноти в екосистему MCP та Azure AI Foundry.

**Посилання:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### Кейс-стаді 9: Microsoft Docs MCP Server – навчання та підвищення кваліфікації  
Microsoft Docs MCP Server реалізує MCP сервер, який надає асистентам ШІ доступ у реальному часі до офіційної документації Microsoft. Виконує семантичний пошук по офіційній технічній документації Microsoft.

**Посилання:**  
- [Microsoft Learn Docs MCP Server](https://github.com/MicrosoftDocs/mcp)

## Практичні проєкти

### Проєкт 1: Створення MCP сервера з підтримкою кількох провайдерів

**Мета:** Створити MCP сервер, який може маршрутизувати запити до кількох провайдерів моделей ШІ на основі певних критеріїв.

**Вимоги:**  
- Підтримка щонайменше трьох різних провайдерів моделей (наприклад, OpenAI, Anthropic, локальні моделі)  
- Реалізація механізму маршрутизації на основі метаданих запиту  
- Створення системи конфігурації для керування обліковими даними провайдерів  
- Додавання кешування для оптимізації продуктивності та витрат  
- Розробка простого дашборда для моніторингу використання

**Кроки реалізації:**  
1. Налаштувати базову інфраструктуру MCP сервера  
2. Реалізувати адаптери провайдерів для кожного сервісу моделей ШІ  
3. Створити логіку маршрутизації на основі атрибутів запиту  
4. Додати механізми кешування для частих запитів  
5. Розробити дашборд моніторингу  
6. Протестувати з різними патернами запитів

**Технології:** Вибір між Python (.NET/Java/Python за вашим уподобанням), Redis для кешування та простий веб-фреймворк для дашборда.

### Проєкт 2: Корпоративна система управління запитами

**Мета:** Розробити систему на основі MCP для управління, версіонування та розгортання шаблонів запитів у межах організації.

**Вимоги:**  
- Створення централізованого репозиторію шаблонів запитів  
- Впровадження версіонування та робочих процесів затвердження  
- Розробка можливостей тестування шаблонів з прикладами вхідних даних  
- Впровадження контролю доступу на основі ролей  
- Створення API для отримання та розгортання шаблонів

**Кроки реалізації:**  
1. Спроєктувати схему бази даних для зберігання шаблонів  
2. Створити основний API для CRUD операцій із шаблонами  
3. Реалізувати систему версіонування  
4. Розробити робочий процес затвердження  
5. Створити тестову платформу  
6. Розробити простий веб-інтерфейс для управління  
7. Інтегрувати з MCP сервером

**Технології:** Вибір бекенд-фреймворку, SQL або NoSQL бази даних та фронтенд-фреймворку для інтерфейсу управління.

### Проєкт 3: Платформа генерації контенту на основі MCP

**Мета:** Створити платформу генерації контенту, що використовує MCP для забезпечення послідовних результатів у різних типах контенту.

**Вимоги:**  
- Підтримка кількох форматів контенту (блоги, соціальні мережі, маркетингові тексти)  
- Реалізація генерації на основі шаблонів з можливістю налаштування  
- Створення системи перегляду та зворотного зв’язку по контенту  
- Відстеження метрик ефективності контенту  
- Підтримка версіонування та ітерацій контенту

**Кроки реалізації:**  
1. Налаштувати інфраструктуру MCP клієнта  
2. Створити шаблони для різних типів контенту  
3. Побудувати конвеєр генерації контенту  
4. Реалізувати систему перегляду  
5. Розробити систему відстеження метрик  
6. Створити інтерфейс користувача для управління шаблонами та генерації контенту

**Технології:** Обрана вами мова програмування, веб-фреймворк та система баз даних.

## Майбутні напрямки розвитку MCP

### Нові тенденції

1. **Мультимодальний MCP**  
   - Розширення MCP для стандартизації взаємодії з моделями зображень, аудіо та відео  
   - Розробка можливостей крос-модального логічного аналізу  
   - Стандартизовані формати запитів для різних модальностей

2. **Федеративна інфраструктура MCP**  
   - Розподілені мережі MCP, що можуть ділитися ресурсами між організаціями  
   - Стандартизовані протоколи для безпечного обміну моделями  
   - Т
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) – Головна сторінка для реалізацій Remote MCP Server в Azure Functions з посиланнями на репозиторії для конкретних мов програмування  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) – Шаблон швидкого старту для створення та розгортання кастомних віддалених MCP серверів за допомогою Azure Functions на Python  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) – Шаблон швидкого старту для створення та розгортання кастомних віддалених MCP серверів за допомогою Azure Functions на .NET/C#  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) – Шаблон швидкого старту для створення та розгортання кастомних віддалених MCP серверів за допомогою Azure Functions на TypeScript  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) – Azure API Management як AI Gateway до віддалених MCP серверів з використанням Python  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) – Експерименти APIM ❤️ AI, включно з можливостями MCP, інтеграція з Azure OpenAI та AI Foundry  

Ці репозиторії надають різноманітні реалізації, шаблони та ресурси для роботи з Model Context Protocol у різних мовах програмування та сервісах Azure. Вони охоплюють широкий спектр випадків використання — від базових серверних реалізацій до автентифікації, розгортання в хмарі та інтеграції в корпоративному середовищі.  

#### Каталог ресурсів MCP  

[Каталог ресурсів MCP](https://github.com/microsoft/mcp/tree/main/Resources) в офіційному репозиторії Microsoft MCP містить відібраний набір прикладів ресурсів, шаблонів запитів (prompt templates) та визначень інструментів для використання з серверами Model Context Protocol. Цей каталог створений, щоб допомогти розробникам швидко почати роботу з MCP, пропонуючи повторно використовувані компоненти та приклади найкращих практик для:  

- **Шаблони запитів:** Готові шаблони для типових AI-завдань і сценаріїв, які можна адаптувати для власних реалізацій MCP серверів.  
- **Визначення інструментів:** Приклади схем інструментів і метаданих для стандартизації інтеграції та виклику інструментів у різних MCP серверах.  
- **Приклади ресурсів:** Приклади визначень ресурсів для підключення до джерел даних, API та зовнішніх сервісів у рамках MCP.  
- **Референсні реалізації:** Практичні приклади, які демонструють, як структурувати та організовувати ресурси, запити та інструменти у реальних MCP проєктах.  

Ці ресурси прискорюють розробку, сприяють стандартизації та допомагають забезпечити найкращі практики при створенні та розгортанні рішень на основі MCP.  

#### Каталог ресурсів MCP  
- [MCP Resources (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)  

### Можливості для досліджень  

- Ефективні методи оптимізації запитів у рамках MCP  
- Моделі безпеки для мультиорендних MCP розгортань  
- Порівняльне тестування продуктивності різних реалізацій MCP  
- Методи формальної верифікації MCP серверів  

## Висновок  

Model Context Protocol (MCP) швидко формує майбутнє стандартизованої, безпечної та сумісної інтеграції AI у різних галузях. Через кейс-стаді та практичні проєкти цього уроку ви побачили, як ранні користувачі — включно з Microsoft та Azure — використовують MCP для розв’язання реальних задач, прискорення впровадження AI та забезпечення відповідності, безпеки й масштабованості. Модульний підхід MCP дозволяє організаціям об’єднувати великі мовні моделі, інструменти та корпоративні дані в єдину, аудитуємую структуру. У міру розвитку MCP важливо залишатися активним у спільноті, досліджувати відкриті ресурси та застосовувати найкращі практики для створення надійних AI-рішень, готових до майбутнього.  

## Додаткові ресурси  

- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Foundry MCP Playground](https://github.com/azure-ai-foundry/foundry-mcp-playground)  
- [Інтеграція Azure AI Agents з MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)  
- [MCP GitHub Repository (Microsoft)](https://github.com/microsoft/mcp)  
- [Каталог ресурсів MCP (Приклади запитів, інструментів та визначень ресурсів)](https://github.com/microsoft/mcp/tree/main/Resources)  
- [Спільнота MCP та документація](https://modelcontextprotocol.io/introduction)  
- [Документація Azure MCP](https://aka.ms/azmcp)  
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

## Вправи  

1. Проаналізуйте один із кейс-стаді та запропонуйте альтернативний підхід до реалізації.  
2. Оберіть одну з ідей проєкту та створіть детальну технічну специфікацію.  
3. Дослідіть галузь, не охоплену кейс-стаді, і опишіть, як MCP може вирішити її специфічні виклики.  
4. Вивчіть один із напрямків розвитку та розробіть концепцію нового розширення MCP для його підтримки.  

Далі: [Best Practices](../08-BestPractices/README.md)

**Відмова від відповідальності**:  
Цей документ було перекладено за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоча ми прагнемо до точності, будь ласка, майте на увазі, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння або неправильні тлумачення, що виникли внаслідок використання цього перекладу.