<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b62150e27d4b7b5797ee41146d176e6b",
  "translation_date": "2025-08-18T18:12:19+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "uk"
}
-->
# Найкращі практики розробки MCP

[![Найкращі практики розробки MCP](../../../translated_images/09.d0f6d86c9d72134ccf5a8d8c8650a0557e519936661fc894cad72d73522227cb.uk.png)](https://youtu.be/W56H9W7x-ao)

_(Натисніть на зображення вище, щоб переглянути відео цього уроку)_

## Огляд

Цей урок зосереджений на передових найкращих практиках розробки, тестування та впровадження серверів і функцій MCP у виробничих середовищах. Зі зростанням складності та важливості екосистем MCP дотримання встановлених шаблонів забезпечує надійність, підтримуваність і сумісність. Урок узагальнює практичний досвід, отриманий із реальних впроваджень MCP, щоб допомогти вам створювати надійні, ефективні сервери з використанням відповідних ресурсів, підказок і інструментів.

## Цілі навчання

До кінця цього уроку ви зможете:

- Застосовувати найкращі галузеві практики у проєктуванні серверів і функцій MCP
- Створювати комплексні стратегії тестування серверів MCP
- Проєктувати ефективні, багаторазові шаблони робочих процесів для складних застосунків MCP
- Реалізовувати належну обробку помилок, логування та спостереження у серверах MCP
- Оптимізувати впровадження MCP для продуктивності, безпеки та підтримуваності

## Основні принципи MCP

Перед тим як заглиблюватися у конкретні практики впровадження, важливо зрозуміти основні принципи, які керують ефективною розробкою MCP:

1. **Стандартизована комунікація**: MCP використовує JSON-RPC 2.0 як основу, забезпечуючи єдиний формат для запитів, відповідей і обробки помилок у всіх впровадженнях.

2. **Орієнтованість на користувача**: Завжди надавайте пріоритет згоді, контролю та прозорості користувача у ваших впровадженнях MCP.

3. **Безпека понад усе**: Реалізовуйте надійні заходи безпеки, включаючи автентифікацію, авторизацію, валідацію та обмеження швидкості.

4. **Модульна архітектура**: Проєктуйте сервери MCP з модульним підходом, де кожен інструмент і ресурс має чітку, сфокусовану мету.

5. **Становий зв’язок**: Використовуйте здатність MCP підтримувати стан між кількома запитами для більш узгоджених і контекстно-обізнаних взаємодій.

## Офіційні найкращі практики MCP

Наведені нижче найкращі практики взяті з офіційної документації Model Context Protocol:

### Найкращі практики безпеки

1. **Згода та контроль користувача**: Завжди вимагайте явної згоди користувача перед доступом до даних або виконанням операцій. Надавайте чіткий контроль над тим, які дані передаються і які дії дозволені.

2. **Конфіденційність даних**: Відкривайте дані користувача лише за явною згодою та захищайте їх за допомогою відповідних механізмів доступу. Захищайте від несанкціонованої передачі даних.

3. **Безпека інструментів**: Вимагайте явної згоди користувача перед викликом будь-якого інструменту. Забезпечте розуміння користувачем функціональності кожного інструменту та дотримання надійних меж безпеки.

4. **Контроль дозволів інструментів**: Налаштовуйте, які інструменти дозволено використовувати моделі під час сесії, забезпечуючи доступ лише до явно дозволених інструментів.

5. **Автентифікація**: Вимагайте належної автентифікації перед наданням доступу до інструментів, ресурсів або чутливих операцій, використовуючи API-ключі, токени OAuth або інші безпечні методи автентифікації.

6. **Валідація параметрів**: Забезпечте валідацію для всіх викликів інструментів, щоб запобігти потраплянню некоректних або шкідливих даних до реалізації інструментів.

7. **Обмеження швидкості**: Реалізуйте обмеження швидкості, щоб запобігти зловживанням і забезпечити справедливе використання ресурсів сервера.

### Найкращі практики впровадження

1. **Узгодження можливостей**: Під час налаштування з’єднання обмінюйтеся інформацією про підтримувані функції, версії протоколу, доступні інструменти та ресурси.

2. **Проєктування інструментів**: Створюйте сфокусовані інструменти, які добре виконують одну задачу, замість монолітних інструментів, що охоплюють кілька завдань.

3. **Обробка помилок**: Реалізовуйте стандартизовані повідомлення про помилки та коди для діагностики проблем, плавного оброблення збоїв і надання корисного зворотного зв’язку.

4. **Логування**: Налаштуйте структуровані журнали для аудиту, налагодження та моніторингу взаємодій протоколу.

5. **Відстеження прогресу**: Для довготривалих операцій надавайте оновлення про прогрес, щоб забезпечити чуйний інтерфейс користувача.

6. **Скасування запитів**: Дозвольте клієнтам скасовувати запити, які більше не потрібні або займають занадто багато часу.

## Додаткові посилання

Для найактуальнішої інформації про найкращі практики MCP звертайтеся до:

- [Документація MCP](https://modelcontextprotocol.io/)
- [Специфікація MCP](https://spec.modelcontextprotocol.io/)
- [Репозиторій GitHub](https://github.com/modelcontextprotocol)
- [Найкращі практики безпеки](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## Приклади практичного впровадження

### Найкращі практики проєктування інструментів

#### 1. Принцип єдиної відповідальності

Кожен інструмент MCP повинен мати чітку, сфокусовану мету. Замість створення монолітних інструментів, які намагаються охопити кілька завдань, розробляйте спеціалізовані інструменти, які відмінно виконують конкретні задачі.

```csharp
// A focused tool that does one thing well
public class WeatherForecastTool : ITool
{
    private readonly IWeatherService _weatherService;
    
    public WeatherForecastTool(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }
    
    public string Name => "weatherForecast";
    public string Description => "Gets weather forecast for a specific location";
    
    public ToolDefinition GetDefinition()
    {
        return new ToolDefinition
        {
            Name = Name,
            Description = Description,
            Parameters = new Dictionary<string, ParameterDefinition>
            {
                ["location"] = new ParameterDefinition
                {
                    Type = ParameterType.String,
                    Description = "City or location name"
                },
                ["days"] = new ParameterDefinition
                {
                    Type = ParameterType.Integer,
                    Description = "Number of forecast days",
                    Default = 3
                }
            },
            Required = new[] { "location" }
        };
    }
    
    public async Task<ToolResponse> ExecuteAsync(IDictionary<string, object> parameters)
    {
        var location = parameters["location"].ToString();
        var days = parameters.ContainsKey("days") 
            ? Convert.ToInt32(parameters["days"]) 
            : 3;
            
        var forecast = await _weatherService.GetForecastAsync(location, days);
        
        return new ToolResponse
        {
            Content = new List<ContentItem>
            {
                new TextContent(JsonSerializer.Serialize(forecast))
            }
        };
    }
}
```

#### 2. Послідовна обробка помилок

Реалізовуйте надійну обробку помилок з інформативними повідомленнями про помилки та відповідними механізмами відновлення.

```python
# Python example with comprehensive error handling
class DataQueryTool:
    def get_name(self):
        return "dataQuery"
        
    def get_description(self):
        return "Queries data from specified database tables"
    
    async def execute(self, parameters):
        try:
            # Parameter validation
            if "query" not in parameters:
                raise ToolParameterError("Missing required parameter: query")
                
            query = parameters["query"]
            
            # Security validation
            if self._contains_unsafe_sql(query):
                raise ToolSecurityError("Query contains potentially unsafe SQL")
            
            try:
                # Database operation with timeout
                async with timeout(10):  # 10 second timeout
                    result = await self._database.execute_query(query)
                    
                return ToolResponse(
                    content=[TextContent(json.dumps(result))]
                )
            except asyncio.TimeoutError:
                raise ToolExecutionError("Database query timed out after 10 seconds")
            except DatabaseConnectionError as e:
                # Connection errors might be transient
                self._log_error("Database connection error", e)
                raise ToolExecutionError(f"Database connection error: {str(e)}")
            except DatabaseQueryError as e:
                # Query errors are likely client errors
                self._log_error("Database query error", e)
                raise ToolExecutionError(f"Invalid query: {str(e)}")
                
        except ToolError:
            # Let tool-specific errors pass through
            raise
        except Exception as e:
            # Catch-all for unexpected errors
            self._log_error("Unexpected error in DataQueryTool", e)
            raise ToolExecutionError(f"An unexpected error occurred: {str(e)}")
    
    def _contains_unsafe_sql(self, query):
        # Implementation of SQL injection detection
        pass
        
    def _log_error(self, message, error):
        # Implementation of error logging
        pass
```

#### 3. Валідація параметрів

Завжди ретельно перевіряйте параметри, щоб запобігти некоректним або шкідливим даним.

```javascript
// JavaScript/TypeScript example with detailed parameter validation
class FileOperationTool {
  getName() {
    return "fileOperation";
  }
  
  getDescription() {
    return "Performs file operations like read, write, and delete";
  }
  
  getDefinition() {
    return {
      name: this.getName(),
      description: this.getDescription(),
      parameters: {
        operation: {
          type: "string",
          description: "Operation to perform",
          enum: ["read", "write", "delete"]
        },
        path: {
          type: "string",
          description: "File path (must be within allowed directories)"
        },
        content: {
          type: "string",
          description: "Content to write (only for write operation)",
          optional: true
        }
      },
      required: ["operation", "path"]
    };
  }
  
  async execute(parameters) {
    // 1. Validate parameter presence
    if (!parameters.operation) {
      throw new ToolError("Missing required parameter: operation");
    }
    
    if (!parameters.path) {
      throw new ToolError("Missing required parameter: path");
    }
    
    // 2. Validate parameter types
    if (typeof parameters.operation !== "string") {
      throw new ToolError("Parameter 'operation' must be a string");
    }
    
    if (typeof parameters.path !== "string") {
      throw new ToolError("Parameter 'path' must be a string");
    }
    
    // 3. Validate parameter values
    const validOperations = ["read", "write", "delete"];
    if (!validOperations.includes(parameters.operation)) {
      throw new ToolError(`Invalid operation. Must be one of: ${validOperations.join(", ")}`);
    }
    
    // 4. Validate content presence for write operation
    if (parameters.operation === "write" && !parameters.content) {
      throw new ToolError("Content parameter is required for write operation");
    }
    
    // 5. Path safety validation
    if (!this.isPathWithinAllowedDirectories(parameters.path)) {
      throw new ToolError("Access denied: path is outside of allowed directories");
    }
    
    // Implementation based on validated parameters
    // ...
  }
  
  isPathWithinAllowedDirectories(path) {
    // Implementation of path safety check
    // ...
  }
}
```

### Приклади впровадження безпеки

#### 1. Автентифікація та авторизація

```java
// Java example with authentication and authorization
public class SecureDataAccessTool implements Tool {
    private final AuthenticationService authService;
    private final AuthorizationService authzService;
    private final DataService dataService;
    
    // Dependency injection
    public SecureDataAccessTool(
            AuthenticationService authService,
            AuthorizationService authzService,
            DataService dataService) {
        this.authService = authService;
        this.authzService = authzService;
        this.dataService = dataService;
    }
    
    @Override
    public String getName() {
        return "secureDataAccess";
    }
    
    @Override
    public ToolResponse execute(ToolRequest request) {
        // 1. Extract authentication context
        String authToken = request.getContext().getAuthToken();
        
        // 2. Authenticate user
        UserIdentity user;
        try {
            user = authService.validateToken(authToken);
        } catch (AuthenticationException e) {
            return ToolResponse.error("Authentication failed: " + e.getMessage());
        }
        
        // 3. Check authorization for the specific operation
        String dataId = request.getParameters().get("dataId").getAsString();
        String operation = request.getParameters().get("operation").getAsString();
        
        boolean isAuthorized = authzService.isAuthorized(user, "data:" + dataId, operation);
        if (!isAuthorized) {
            return ToolResponse.error("Access denied: Insufficient permissions for this operation");
        }
        
        // 4. Proceed with authorized operation
        try {
            switch (operation) {
                case "read":
                    Object data = dataService.getData(dataId, user.getId());
                    return ToolResponse.success(data);
                case "update":
                    JsonNode newData = request.getParameters().get("newData");
                    dataService.updateData(dataId, newData, user.getId());
                    return ToolResponse.success("Data updated successfully");
                default:
                    return ToolResponse.error("Unsupported operation: " + operation);
            }
        } catch (Exception e) {
            return ToolResponse.error("Operation failed: " + e.getMessage());
        }
    }
}
```

#### 2. Обмеження швидкості

```csharp
// C# rate limiting implementation
public class RateLimitingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IMemoryCache _cache;
    private readonly ILogger<RateLimitingMiddleware> _logger;
    
    // Configuration options
    private readonly int _maxRequestsPerMinute;
    
    public RateLimitingMiddleware(
        RequestDelegate next,
        IMemoryCache cache,
        ILogger<RateLimitingMiddleware> logger,
        IConfiguration config)
    {
        _next = next;
        _cache = cache;
        _logger = logger;
        _maxRequestsPerMinute = config.GetValue<int>("RateLimit:MaxRequestsPerMinute", 60);
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        // 1. Get client identifier (API key or user ID)
        string clientId = GetClientIdentifier(context);
        
        // 2. Get rate limiting key for this minute
        string cacheKey = $"rate_limit:{clientId}:{DateTime.UtcNow:yyyyMMddHHmm}";
        
        // 3. Check current request count
        if (!_cache.TryGetValue(cacheKey, out int requestCount))
        {
            requestCount = 0;
        }
        
        // 4. Enforce rate limit
        if (requestCount >= _maxRequestsPerMinute)
        {
            _logger.LogWarning("Rate limit exceeded for client {ClientId}", clientId);
            
            context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
            context.Response.Headers.Add("Retry-After", "60");
            
            await context.Response.WriteAsJsonAsync(new
            {
                error = "Rate limit exceeded",
                message = "Too many requests. Please try again later.",
                retryAfterSeconds = 60
            });
            
            return;
        }
        
        // 5. Increment request count
        _cache.Set(cacheKey, requestCount + 1, TimeSpan.FromMinutes(2));
        
        // 6. Add rate limit headers
        context.Response.Headers.Add("X-RateLimit-Limit", _maxRequestsPerMinute.ToString());
        context.Response.Headers.Add("X-RateLimit-Remaining", (_maxRequestsPerMinute - requestCount - 1).ToString());
        
        // 7. Continue with the request
        await _next(context);
    }
    
    private string GetClientIdentifier(HttpContext context)
    {
        // Implementation to extract API key or user ID
        // ...
    }
}
```

...
3. **Базові показники продуктивності**: Підтримуйте еталонні показники продуктивності, щоб виявляти регресії  
4. **Сканування безпеки**: Автоматизуйте тестування безпеки як частину конвеєра  

### Приклад CI-конвеєра (GitHub Actions)

```yaml
name: MCP Server Tests

on:
  push:
    branches: [ main ]
  pull_request:
    branches: [ main ]

jobs:
  test:
    runs-on: ubuntu-latest
    
    steps:
    - uses: actions/checkout@v2
    
    - name: Set up Runtime
      uses: actions/setup-dotnet@v1
      with:
        dotnet-version: '8.0.x'
    
    - name: Restore dependencies
      run: dotnet restore
    
    - name: Build
      run: dotnet build --no-restore
    
    - name: Unit Tests
      run: dotnet test --no-build --filter Category=Unit
    
    - name: Integration Tests
      run: dotnet test --no-build --filter Category=Integration
      
    - name: Performance Tests
      run: dotnet run --project tests/PerformanceTests/PerformanceTests.csproj
```  

## Тестування на відповідність специфікації MCP  

Переконайтеся, що ваш сервер правильно реалізує специфікацію MCP.  

### Основні області відповідності  

1. **API-ендпоінти**: Тестуйте необхідні ендпоінти (/resources, /tools тощо)  
2. **Формат запитів/відповідей**: Перевіряйте відповідність схемі  
3. **Коди помилок**: Переконайтеся у правильності статус-кодів для різних сценаріїв  
4. **Типи контенту**: Тестуйте обробку різних типів контенту  
5. **Механізм автентифікації**: Перевіряйте механізми автентифікації, що відповідають специфікації  

### Набір тестів на відповідність  

```csharp
[Fact]
public async Task Server_ResourceEndpoint_ReturnsCorrectSchema()
{
    // Arrange
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");
    
    // Act
    var response = await client.GetAsync("http://localhost:5000/api/resources");
    var content = await response.Content.ReadAsStringAsync();
    var resources = JsonSerializer.Deserialize<ResourceList>(content);
    
    // Assert
    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    Assert.NotNull(resources);
    Assert.All(resources.Resources, resource => 
    {
        Assert.NotNull(resource.Id);
        Assert.NotNull(resource.Type);
        // Additional schema validation
    });
}
```  

## Топ-10 порад для ефективного тестування MCP-серверів  

1. **Окреме тестування визначень інструментів**: Перевіряйте схеми незалежно від логіки інструментів  
2. **Використовуйте параметризовані тести**: Тестуйте інструменти з різноманітними вхідними даними, включаючи крайні випадки  
3. **Перевіряйте відповіді на помилки**: Переконайтеся у правильній обробці всіх можливих умов помилок  
4. **Тестуйте логіку авторизації**: Забезпечте правильний контроль доступу для різних ролей користувачів  
5. **Моніторинг покриття тестів**: Стреміться до високого покриття критичного коду  
6. **Тестуйте потокові відповіді**: Перевіряйте правильну обробку потокового контенту  
7. **Симулюйте проблеми з мережею**: Тестуйте поведінку за умов поганого з'єднання  
8. **Тестуйте обмеження ресурсів**: Перевіряйте поведінку при досягненні квот або лімітів швидкості  
9. **Автоматизуйте регресійні тести**: Створіть набір тестів, який запускається при кожній зміні коду  
10. **Документуйте тестові випадки**: Підтримуйте чітку документацію сценаріїв тестування  

## Поширені помилки тестування  

- **Надмірна залежність від тестування "щасливого шляху"**: Переконайтеся, що помилки тестуються ретельно  
- **Ігнорування тестування продуктивності**: Виявляйте вузькі місця до того, як вони вплинуть на продакшн  
- **Тестування лише в ізоляції**: Поєднуйте модульні, інтеграційні та E2E тести  
- **Неповне покриття API**: Переконайтеся, що всі ендпоінти та функції протестовані  
- **Непослідовні тестові середовища**: Використовуйте контейнери для забезпечення стабільності середовищ  

## Висновок  

Комплексна стратегія тестування є ключовою для розробки надійних, високоякісних MCP-серверів. Використовуючи найкращі практики та поради, викладені в цьому посібнику, ви можете забезпечити відповідність ваших реалізацій MCP найвищим стандартам якості, надійності та продуктивності.  

## Основні висновки  

1. **Дизайн інструментів**: Дотримуйтеся принципу єдиної відповідальності, використовуйте впровадження залежностей та проектуйте для композиційності  
2. **Дизайн схем**: Створюйте чіткі, добре документовані схеми з правильними обмеженнями валідації  
3. **Обробка помилок**: Реалізуйте плавну обробку помилок, структуровані відповіді на помилки та логіку повторних спроб  
4. **Продуктивність**: Використовуйте кешування, асинхронну обробку та обмеження ресурсів  
5. **Безпека**: Застосовуйте ретельну валідацію введення, перевірки авторизації та обробку конфіденційних даних  
6. **Тестування**: Створюйте комплексні модульні, інтеграційні та наскрізні тести  
7. **Шаблони робочих процесів**: Використовуйте перевірені шаблони, такі як ланцюги, диспетчери та паралельна обробка  

## Завдання  

Розробіть MCP-інструмент і робочий процес для системи обробки документів, яка:  

1. Приймає документи у різних форматах (PDF, DOCX, TXT)  
2. Витягує текст і ключову інформацію з документів  
3. Класифікує документи за типом і змістом  
4. Генерує резюме кожного документа  

Реалізуйте схеми інструментів, обробку помилок і шаблон робочого процесу, який найкраще підходить для цього сценарію. Розгляньте, як ви будете тестувати цю реалізацію.  

## Ресурси  

1. Приєднуйтесь до спільноти MCP на [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs), щоб бути в курсі останніх новин  
2. Внесіть свій вклад у відкриті [MCP-проекти](https://github.com/modelcontextprotocol)  
3. Застосовуйте принципи MCP у власних ініціативах штучного інтелекту вашої організації  
4. Досліджуйте спеціалізовані реалізації MCP для вашої галузі  
5. Розгляньте можливість проходження просунутих курсів з конкретних тем MCP, таких як мультимодальна інтеграція або інтеграція корпоративних додатків  
6. Експериментуйте зі створенням власних MCP-інструментів і робочих процесів, використовуючи принципи, вивчені через [Практичну лабораторію](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)  

Далі: Найкращі практики [кейси](../09-CaseStudy/README.md)  

**Відмова від відповідальності**:  
Цей документ було перекладено за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоча ми прагнемо до точності, зверніть увагу, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ мовою оригіналу слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується професійний переклад людиною. Ми не несемо відповідальності за будь-які непорозуміння або неправильні тлумачення, що виникли внаслідок використання цього перекладу.