<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "80e5c8949af5af0f401fce6f905990aa",
  "translation_date": "2025-07-17T12:56:39+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "uk"
}
-->
# MCP Кращі Практики Розробки

## Огляд

Цей урок присвячений передовим кращим практикам розробки, тестування та розгортання MCP серверів і функцій у продуктивних середовищах. Оскільки екосистеми MCP стають дедалі складнішими та важливішими, дотримання встановлених шаблонів забезпечує надійність, підтримуваність і сумісність. Урок узагальнює практичний досвід, отриманий із реальних впроваджень MCP, щоб допомогти вам створювати міцні, ефективні сервери з корисними ресурсами, підказками та інструментами.

## Цілі Навчання

До кінця цього уроку ви зможете:
- Застосовувати галузеві кращі практики у проєктуванні MCP серверів і функцій
- Створювати комплексні стратегії тестування MCP серверів
- Проєктувати ефективні, багаторазові шаблони робочих процесів для складних MCP застосунків
- Реалізовувати правильну обробку помилок, логування та спостережуваність у MCP серверах
- Оптимізувати реалізації MCP за показниками продуктивності, безпеки та підтримуваності

## Основні Принципи MCP

Перед тим, як заглиблюватися у конкретні практики реалізації, важливо зрозуміти основні принципи, які керують ефективною розробкою MCP:

1. **Стандартизована Комунікація**: MCP базується на JSON-RPC 2.0, що забезпечує послідовний формат для запитів, відповідей і обробки помилок у всіх реалізаціях.

2. **Орієнтація на Користувача**: Завжди ставте на перше місце згоду користувача, контроль і прозорість у ваших реалізаціях MCP.

3. **Безпека Насамперед**: Впроваджуйте надійні заходи безпеки, включно з автентифікацією, авторизацією, валідацією та обмеженням частоти запитів.

4. **Модульна Архітектура**: Проєктуйте MCP сервери за модульним підходом, де кожен інструмент і ресурс має чітку, сфокусовану мету.

5. **Станові З’єднання**: Використовуйте можливість MCP підтримувати стан між кількома запитами для більш послідовної та контекстно-залежної взаємодії.

## Офіційні Кращі Практики MCP

Наступні кращі практики взяті з офіційної документації Model Context Protocol:

### Кращі Практики Безпеки

1. **Згода та Контроль Користувача**: Завжди вимагайте явної згоди користувача перед доступом до даних або виконанням операцій. Забезпечуйте чіткий контроль над тим, які дані передаються і які дії дозволені.

2. **Конфіденційність Даних**: Показуйте дані користувача лише за явної згоди та захищайте їх відповідними механізмами контролю доступу. Запобігайте несанкціонованій передачі даних.

3. **Безпека Інструментів**: Вимагаєте явної згоди користувача перед викликом будь-якого інструменту. Переконайтеся, що користувачі розуміють функціонал кожного інструменту і дотримуйтеся суворих меж безпеки.

4. **Контроль Дозволів Інструментів**: Налаштовуйте, які інструменти модель може використовувати під час сесії, щоб забезпечити доступ лише до явно дозволених інструментів.

5. **Автентифікація**: Вимагаєте належної автентифікації перед наданням доступу до інструментів, ресурсів або чутливих операцій за допомогою API ключів, OAuth токенів або інших безпечних методів.

6. **Валідація Параметрів**: Забезпечуйте валідацію всіх викликів інструментів, щоб запобігти передачі некоректних або шкідливих даних у реалізації інструментів.

7. **Обмеження Частоти Запитів**: Впроваджуйте обмеження частоти запитів, щоб запобігти зловживанням і забезпечити справедливе використання ресурсів сервера.

### Кращі Практики Реалізації

1. **Переговори Можливостей**: Під час встановлення з’єднання обмінюйтеся інформацією про підтримувані функції, версії протоколу, доступні інструменти та ресурси.

2. **Проєктування Інструментів**: Створюйте сфокусовані інструменти, які добре виконують одну задачу, а не монолітні інструменти, що охоплюють кілька функцій.

3. **Обробка Помилок**: Реалізуйте стандартизовані повідомлення про помилки та коди, щоб допомогти діагностувати проблеми, коректно обробляти збої та надавати корисний зворотний зв’язок.

4. **Логування**: Налаштовуйте структуровані логи для аудиту, налагодження та моніторингу взаємодій протоколу.

5. **Відстеження Прогресу**: Для довготривалих операцій повідомляйте про оновлення прогресу, щоб забезпечити чуйний інтерфейс користувача.

6. **Скасування Запитів**: Дозволяйте клієнтам скасовувати запити, які більше не потрібні або виконуються надто довго.

## Додаткові Посилання

Для найактуальнішої інформації про кращі практики MCP звертайтеся до:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)
- [Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## Приклади Практичної Реалізації

### Кращі Практики Проєктування Інструментів

#### 1. Принцип Єдиної Відповідальності

Кожен інструмент MCP повинен мати чітку, сфокусовану мету. Замість створення монолітних інструментів, які намагаються охопити кілька завдань, розробляйте спеціалізовані інструменти, які відмінно виконують конкретні функції.

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

#### 2. Послідовна Обробка Помилок

Реалізуйте надійну обробку помилок з інформативними повідомленнями та відповідними механізмами відновлення.

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

#### 3. Валідація Параметрів

Завжди ретельно перевіряйте параметри, щоб запобігти передачі некоректних або шкідливих даних.

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

### Приклади Реалізації Безпеки

#### 1. Автентифікація та Авторизація

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

#### 2. Обмеження Частоти Запитів

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

## Кращі Практики Тестування

### 1. Модульне Тестування Інструментів MCP

Завжди тестуйте інструменти окремо, імітуючи зовнішні залежності:

```typescript
// TypeScript example of a tool unit test
describe('WeatherForecastTool', () => {
  let tool: WeatherForecastTool;
  let mockWeatherService: jest.Mocked<IWeatherService>;
  
  beforeEach(() => {
    // Create a mock weather service
    mockWeatherService = {
      getForecasts: jest.fn()
    } as any;
    
    // Create the tool with the mock dependency
    tool = new WeatherForecastTool(mockWeatherService);
  });
  
  it('should return weather forecast for a location', async () => {
    // Arrange
    const mockForecast = {
      location: 'Seattle',
      forecasts: [
        { date: '2025-07-16', temperature: 72, conditions: 'Sunny' },
        { date: '2025-07-17', temperature: 68, conditions: 'Partly Cloudy' },
        { date: '2025-07-18', temperature: 65, conditions: 'Rain' }
      ]
    };
    
    mockWeatherService.getForecasts.mockResolvedValue(mockForecast);
    
    // Act
    const response = await tool.execute({
      location: 'Seattle',
      days: 3
    });
    
    // Assert
    expect(mockWeatherService.getForecasts).toHaveBeenCalledWith('Seattle', 3);
    expect(response.content[0].text).toContain('Seattle');
    expect(response.content[0].text).toContain('Sunny');
  });
  
  it('should handle errors from the weather service', async () => {
    // Arrange
    mockWeatherService.getForecasts.mockRejectedValue(new Error('Service unavailable'));
    
    // Act & Assert
    await expect(tool.execute({
      location: 'Seattle',
      days: 3
    })).rejects.toThrow('Weather service error: Service unavailable');
  });
});
```

### 2. Інтеграційне Тестування

Перевіряйте повний цикл від запитів клієнта до відповідей сервера:

```python
# Python integration test example
@pytest.mark.asyncio
async def test_mcp_server_integration():
    # Start a test server
    server = McpServer()
    server.register_tool(WeatherForecastTool(MockWeatherService()))
    await server.start(port=5000)
    
    try:
        # Create a client
        client = McpClient("http://localhost:5000")
        
        # Test tool discovery
        tools = await client.discover_tools()
        assert "weatherForecast" in [t.name for t in tools]
        
        # Test tool execution
        response = await client.execute_tool("weatherForecast", {
            "location": "Seattle",
            "days": 3
        })
        
        # Verify response
        assert response.status_code == 200
        assert "Seattle" in response.content[0].text
        assert len(json.loads(response.content[0].text)["forecasts"]) == 3
        
    finally:
        # Clean up
        await server.stop()
```

## Оптимізація Продуктивності

### 1. Стратегії Кешування

Впроваджуйте відповідне кешування, щоб зменшити затримки та використання ресурсів:

```csharp
// C# example with caching
public class CachedWeatherTool : ITool
{
    private readonly IWeatherService _weatherService;
    private readonly IDistributedCache _cache;
    private readonly ILogger<CachedWeatherTool> _logger;
    
    public CachedWeatherTool(
        IWeatherService weatherService,
        IDistributedCache cache,
        ILogger<CachedWeatherTool> logger)
    {
        _weatherService = weatherService;
        _cache = cache;
        _logger = logger;
    }
    
    public string Name => "weatherForecast";
    
    public async Task<ToolResponse> ExecuteAsync(IDictionary<string, object> parameters)
    {
        var location = parameters["location"].ToString();
        var days = Convert.ToInt32(parameters.GetValueOrDefault("days", 3));
        
        // Create cache key
        string cacheKey = $"weather:{location}:{days}";
        
        // Try to get from cache
        string cachedForecast = await _cache.GetStringAsync(cacheKey);
        if (!string.IsNullOrEmpty(cachedForecast))
        {
            _logger.LogInformation("Cache hit for weather forecast: {Location}", location);
            return new ToolResponse
            {
                Content = new List<ContentItem>
                {
                    new TextContent(cachedForecast)
                }
            };
        }
        
        // Cache miss - get from service
        _logger.LogInformation("Cache miss for weather forecast: {Location}", location);
        var forecast = await _weatherService.GetForecastAsync(location, days);
        string forecastJson = JsonSerializer.Serialize(forecast);
        
        // Store in cache (weather forecasts valid for 1 hour)
        await _cache.SetStringAsync(
            cacheKey,
            forecastJson,
            new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1)
            });
        
        return new ToolResponse
        {
            Content = new List<ContentItem>
            {
                new TextContent(forecastJson)
            }
        };
    }
}

#### 2. Dependency Injection and Testability

Design tools to receive their dependencies through constructor injection, making them testable and configurable:

```java
// Приклад на Java з впровадженням залежностей
public class CurrencyConversionTool implements Tool {
    private final ExchangeRateService exchangeService;
    private final CacheService cacheService;
    private final Logger logger;
    
    // Залежності впроваджуються через конструктор
    public CurrencyConversionTool(
            ExchangeRateService exchangeService,
            CacheService cacheService,
            Logger logger) {
        this.exchangeService = exchangeService;
        this.cacheService = cacheService;
        this.logger = logger;
    }
    
    // Реалізація інструменту
    // ...
}
```

#### 3. Composable Tools

Design tools that can be composed together to create more complex workflows:

```python
# Приклад на Python, що демонструє композицію інструментів
class DataFetchTool(Tool):
    def get_name(self):
        return "dataFetch"
    
    # Реалізація...

class DataAnalysisTool(Tool):
    def get_name(self):
        return "dataAnalysis"
    
    # Цей інструмент може використовувати результати dataFetch
    async def execute_async(self, request):
        # Реалізація...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # Цей інструмент може використовувати результати dataAnalysis
    async def execute_async(self, request):
        # Реалізація...
        pass

# Ці інструменти можна використовувати окремо або як частину робочого процесу
```

### Schema Design Best Practices

The schema is the contract between the model and your tool. Well-designed schemas lead to better tool usability.

#### 1. Clear Parameter Descriptions

Always include descriptive information for each parameter:

```csharp
public object GetSchema()
{
    return new {
        type = "object",
        properties = new {
            query = new { 
                type = "string", 
                description = "Текст пошукового запиту. Використовуйте точні ключові слова для кращих результатів." 
            },
            filters = new {
                type = "object",
                description = "Опціональні фільтри для звуження результатів пошуку",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "Діапазон дат у форматі YYYY-MM-DD:YYYY-MM-DD" 
                    },
                    category = new { 
                        type = "string", 
                        description = "Назва категорії для фільтрації" 
                    }
                }
            },
            limit = new { 
                type = "integer", 
                description = "Максимальна кількість результатів для повернення (1-50)",
                default = 10
            }
        },
        required = new[] { "query" }
    };
}
```

#### 2. Validation Constraints

Include validation constraints to prevent invalid inputs:

```java
Map<String, Object> getSchema() {
    Map<String, Object> schema = new HashMap<>();
    schema.put("type", "object");
    
    Map<String, Object> properties = new HashMap<>();
    
    // Властивість email з валідацією формату
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "Електронна адреса користувача");
    
    // Властивість age з числовими обмеженнями
    Map<String, Object> age = new HashMap<>();
    age.put("type", "integer");
    age.put("minimum", 13);
    age.put("maximum", 120);
    age.put("description", "Вік користувача у роках");
    
    // Перелічувана властивість
    Map<String, Object> subscription = new HashMap<>();
    subscription.put("type", "string");
    subscription.put("enum", Arrays.asList("free", "basic", "premium"));
    subscription.put("default", "free");
    subscription.put("description", "Рівень підписки");
    
    properties.put("email", email);
    properties.put("age", age);
    properties.put("subscription", subscription);
    
    schema.put("properties", properties);
    schema.put("required", Arrays.asList("email"));
    
    return schema;
}
```

#### 3. Consistent Return Structures

Maintain consistency in your response structures to make it easier for models to interpret results:

```python
async def execute_async(self, request):
    try:
        # Обробка запиту
        results = await self._search_database(request.parameters["query"])
        
        # Завжди повертайте послідовну структуру
        return ToolResponse(
            result={
                "matches": [self._format_item(item) for item in results],
                "totalCount": len(results),
                "queryTime": calculation_time_ms,
                "status": "success"
            }
        )
    except Exception as e:
        return ToolResponse(
            result={
                "matches": [],
                "totalCount": 0,
                "queryTime": 0,
                "status": "error",
                "error": str(e)
            }
        )
    
def _format_item(self, item):
    """Гарантує, що кожен елемент має послідовну структуру"""
    return {
        "id": item.id,
        "title": item.title,
        "summary": item.summary[:100] + "..." if len(item.summary) > 100 else item.summary,
        "url": item.url,
        "relevance": item.score
    }
```

### Error Handling

Robust error handling is crucial for MCP tools to maintain reliability.

#### 1. Graceful Error Handling

Handle errors at appropriate levels and provide informative messages:

```csharp
public async Task<ToolResponse> ExecuteAsync(ToolRequest request)
{
    try
    {
        string fileId = request.Parameters.GetProperty("fileId").GetString();
        
        try
        {
            var fileData = await _fileService.GetFileAsync(fileId);
            return new ToolResponse { 
                Result = JsonSerializer.SerializeToElement(fileData) 
            };
        }
        catch (FileNotFoundException)
        {
            throw new ToolExecutionException($"Файл не знайдено: {fileId}");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ToolExecutionException("У вас немає дозволу на доступ до цього файлу");
        }
        catch (Exception ex) when (ex is IOException || ex is TimeoutException)
        {
            _logger.LogError(ex, "Помилка доступу до файлу {FileId}", fileId);
            throw new ToolExecutionException("Помилка доступу до файлу: сервіс тимчасово недоступний");
        }
    }
    catch (JsonException)
    {
        throw new ToolExecutionException("Неправильний формат ідентифікатора файлу");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Несподівана помилка в FileAccessTool");
        throw new ToolExecutionException("Сталася несподівана помилка");
    }
}
```

#### 2. Structured Error Responses

Return structured error information when possible:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    try {
        // Реалізація
    } catch (Exception ex) {
        Map<String, Object> errorResult = new HashMap<>();
        
        errorResult.put("success", false);
        
        if (ex instanceof ValidationException) {
            ValidationException validationEx = (ValidationException) ex;
            
            errorResult.put("errorType", "validation");
            errorResult.put("errorMessage", validationEx.getMessage());
            errorResult.put("validationErrors", validationEx.getErrors());
            
            return new ToolResponse.Builder()
                .setResult(errorResult)
                .build();
        }
        
        // Повторно викидаємо інші виключення як ToolExecutionException
        throw new ToolExecutionException("Виконання інструменту не вдалося: " + ex.getMessage(), ex);
    }
}
```

#### 3. Retry Logic

Implement appropriate retry logic for transient failures:

```python
async def execute_async(self, request):
    max_retries = 3
    retry_count = 0
    base_delay = 1  # секунди
    
    while retry_count < max_retries:
        try:
            # Виклик зовнішнього API
            return await self._call_api(request.parameters)
        except TransientError as e:
            retry_count += 1
            if retry_count >= max_retries:
                raise ToolExecutionException(f"Операція не вдалася після {max_retries} спроб: {str(e)}")
                
            # Експоненційне збільшення затримки
            delay = base_delay * (2 ** (retry_count - 1))
            logging.warning(f"Тимчасова помилка, повторна спроба через {delay}с: {str(e)}")
            await asyncio.sleep(delay)
        except Exception as e:
            # Нетимчасова помилка, повтор не виконуємо
            raise ToolExecutionException(f"Операція не вдалася: {str(e)}")
```

### Performance Optimization

#### 1. Caching

Implement caching for expensive operations:

```csharp
public class CachedDataTool : IMcpTool
{
    private readonly IDatabase _database;
    private readonly IMemoryCache _cache;
    
    public CachedDataTool(IDatabase database, IMemoryCache cache)
    {
        _database = database;
        _cache = cache;
    }
    
    public async Task

ExecuteAsync(ToolRequest request)
    {
        var query = request.Parameters.GetProperty("query").GetString();
        
        // Створити ключ кешу на основі параметрів
        var cacheKey = $"data_query_{ComputeHash(query)}";
        
        // Спробувати спочатку отримати з кешу
        if (_cache.TryGetValue(cacheKey, out var cachedResult))
        {
            return new ToolResponse { Result = cachedResult };
        }
        
        // Кеш не знайдено - виконати фактичний запит
        var result = await _database.QueryAsync(query);
        
        // Зберегти в кеш з терміном дії
        var cacheOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
            
        _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
        
        return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
    }
    
    private string ComputeHash(string input)
    {
        // Реалізація для генерації стабільного хешу для ключа кешу
    }
}
```

#### 2. Asynchronous Processing

Use asynchronous programming patterns for I/O-bound operations:

```java
public class AsyncDocumentProcessingTool implements Tool {
    private final DocumentService documentService;
    private final ExecutorService executorService;
    
    @Override
    public ToolResponse execute(ToolRequest request) {
        String documentId = request.getParameters().get("documentId").asText();
        
        // Для довготривалих операцій негайно повернути ID процесу
        String processId = UUID.randomUUID().toString();
        
        // Запустити асинхронну обробку
        CompletableFuture.runAsync(() -> {
            try {
                // Виконати довготривалу операцію
                documentService.processDocument(documentId);
                
                // Оновити статус (зазвичай зберігається в базі даних)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // Повернути негайну відповідь з ID процесу
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // Супутній інструмент для перевірки статусу
    public class ProcessStatusTool implements Tool {
        @Override
        public ToolResponse execute(ToolRequest request) {
            String processId = request.getParameters().get("processId").asText();
            ProcessStatus status = processStatusRepository.getStatus(processId);
            
            return new ToolResponse.Builder().setResult(status).build();
        }
    }
}
```

#### 3. Resource Throttling

Implement resource throttling to prevent overload:

```python
class ThrottledApiTool(Tool):
    def __init__(self):
        self.rate_limiter = TokenBucketRateLimiter(
            tokens_per_second=5,  # Дозволяє 5 запитів на секунду
            bucket_size=10        # Дозволяє сплески до 10 запитів
        )
    
    async def execute_async(self, request):
        # Перевірити, чи можна продовжити або потрібно почекати
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # Якщо чекати занадто довго
                raise ToolExecutionException(
                    f"Перевищено ліміт запитів. Спробуйте ще раз через {delay:.1f} секунд."
                )
            else:
                # Почекати відповідний час затримки
                await asyncio.sleep(delay)
        
        # Спожити токен і продовжити з запитом
        self.rate_limiter.consume()
        
        # Виклик API
        result = await self._call_api(request.parameters)
        return ToolResponse(result=result)

class TokenBucketRateLimiter:
    def __init__(self, tokens_per_second, bucket_size):
        self.tokens_per_second = tokens_per_second
        self.bucket_size = bucket_size
        self.tokens = bucket_size
        self.last_refill = time.time()
        self.lock = asyncio.Lock()
    
    async def get_delay_time(self):
        async with self.lock:
            self._refill()
            if self.tokens >= 1:
                return 0
            
            # Обчислити час до появи наступного токена
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # Додати нові токени на основі пройденого часу
        new_tokens = elapsed * self.tokens_per_second
        self.tokens = min(self.bucket_size, self.tokens + new_tokens)
        self.last_refill = now
```

### Security Best Practices

#### 1. Input Validation

Always validate input parameters thoroughly:

```csharp
public async Task<ToolResponse> ExecuteAsync(ToolRequest request)
{
    // Перевірити наявність параметрів
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("Відсутній обов’язковий параметр: query");
    }
    
    // Перевірити правильний тип
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("Параметр query повинен бути рядком");
    }
    
    var query = queryProp.GetString();
    
    // Перевірити вміст рядка
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("Параметр query не може бути порожнім");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("Параметр query перевищує максимальну довжину 500 символів");
    }
    
    // Перевірити на SQL-ін’єкції, якщо застосовно
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("Недійсний запит: містить потенційно небезпечний SQL");
    }
    
    // Продовжити виконання
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // Отримати контекст користувача з запиту
    UserContext user = request.getContext().getUserContext();
    
    // Перевірити, чи має користувач необхідні права
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("Користувач не має дозволу на доступ до документів");
    }
    
    // Для конкретних ресурсів перевірити доступ до цього ресурсу
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("Доступ до запитаного документа заборонено");
    }
    
    // Продовжити виконання інструменту
    // ...
}
```

#### 3. Sensitive Data Handling

Handle sensitive data carefully:

```python
class SecureDataTool(Tool):
    def get_schema(self):
        return {
            "type": "object",
            "properties": {
                "userId": {"type": "string"},
                "includeSensitiveData": {"type": "boolean", "default": False}
            },
            "required": ["userId"]
        }
    
    async def execute_async(self, request):
        user_id = request.parameters["userId"]
        include_sensitive = request.parameters.get("includeSensitiveData", False)
        
        # Отримати дані користувача
        user_data = await self.user_service.get_user_data(user_id)
        
        # Відфільтрувати чутливі поля, якщо не запитано явно І не авторизовано
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # Перевірити рівень авторизації в контексті запиту
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # Створити копію, щоб не змінювати оригінал
        redacted = user_data.copy()
        
        # Закрити конкретні чутливі поля
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # Закрити вкладені чутливі дані
        if "financialInfo" in redacted:
            redacted["financialInfo"] = {"available": True, "accessRestricted": True}
        
        return redacted
```

## Testing Best Practices for MCP Tools

Comprehensive testing ensures that MCP tools function correctly, handle edge cases, and integrate properly with the rest of the system.

### Unit Testing

#### 1. Test Each Tool in Isolation

Create focused tests for each tool's functionality:

```csharp
[Fact]
public async Task WeatherTool_ValidLocation_ReturnsCorrectForecast()
{
    // Підготовка
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("Seattle", 3))
        .ReturnsAsync(new WeatherForecast(/* тестові дані */));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "Seattle", 
            days = 3 
        })
    );
    
    // Виконання
    var response = await tool.ExecuteAsync(request);
    
    // Перевірка
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // Підготовка
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("InvalidLocation", It.IsAny<int>()))
        .ThrowsAsync(new LocationNotFoundException("Локація не знайдена"));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "InvalidLocation", 
            days = 3 
        })
    );
    
    // Виконання та перевірка
    var exception = await Assert.ThrowsAsync<ToolExecutionException>(
        () => tool.ExecuteAsync(request)
    );
    
    Assert.Contains("Локація не знайдена", exception.Message);
}
```

#### 2. Schema Validation Testing

Test that schemas are valid and properly enforce constraints:

```java
@Test
public void testSchemaValidation() {
    // Створити екземпляр інструменту
    SearchTool searchTool = new SearchTool();
    
    // Отримати схему
    Object schema = searchTool.getSchema();
    
    // Конвертувати схему в JSON для валідації
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // Перевірити, що схема є валідним JSONSchema
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // Тестувати валідні параметри
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // Тестувати відсутній обов’язковий параметр
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // Тестувати неправильний тип параметра
    JsonNode invalidType = objectMapper.createObjectNode()
        .put("query", "test")
        .put("limit", "not-a-number");
        
    ProcessingReport invalidReport = jsonSchema.validate(invalidType);
    assertFalse(invalidReport.isSuccess());
}
```

#### 3. Error Handling Tests

Create specific tests for error conditions:

```python
@pytest.mark.asyncio
async def test_api_tool_handles_timeout():
    # Підготовка
    tool = ApiTool(timeout=0.1)  # Дуже короткий таймаут
    
    # Мок запиту, який перевищить таймаут
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # Довше за таймаут
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # Виконання та перевірка
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Перевірити повідомлення про помилку
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # Підготовка
    tool = ApiTool()
    
    # Мок відповіді з обмеженням швидкості
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            status=429,
            headers={"Retry-After": "2"},
            body=json.dumps({"error": "Rate limit exceeded"})
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # Виконання та перевірка
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Перевірити, що виключення містить інформацію про ліміт
        error_msg = str(exc_info.value).lower()
        assert "rate limit" in error_msg
        assert "try again" in error_msg
```

### Integration Testing

#### 1. Tool Chain Testing

Test tools working together in expected combinations:

```csharp
[Fact]
public async Task DataProcessingWorkflow_CompletesSuccessfully()
{
    // Підготовка
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // Виконання
var result = await workflowExecutor.ExecuteWorkflowAsync(new[] {
    new ToolCall("dataFetch", new { source = "sales2023" }),
    new ToolCall("dataAnalysis", ctx =>
        new { 
            data = ctx.GetResult("dataFetch"),
            analysis = "trend" 
        }),
    new ToolCall("dataVisualize", ctx => new {
        analysisResult = ctx.GetResult("dataAnalysis"),
        type = "line-chart"
    })
});

// Перевірка
Assert.NotNull(result);
Assert.True(result.Success);
Assert.NotNull(result.GetResult("dataVisualize"));
Assert.Contains("chartUrl", result.GetResult("dataVisualize").ToString());
}
```

#### 2. MCP Server Testing

Test the MCP server with full tool registration and execution:

```java
@SpringBootTest
@AutoConfigureMockMvc
public class McpServerIntegrationTest {
    
    @Autowired
    private MockMvc mockMvc;
    
    @Autowired
    private ObjectMapper objectMapper;
    
    @Test
    public void testToolDiscovery() throws Exception {
        // Тестування endpoint для виявлення інструментів
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // Створення запиту до інструменту
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // Відправка запиту та перевірка відповіді
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // Створення некоректного запиту до інструменту
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // Відсутній параметр "b"
        request.put("parameters", parameters);
        
        // Відправка запиту та перевірка відповіді з помилкою
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isBadRequest())
            .andExpect(jsonPath("$.error").exists());
    }
}
```

#### 3. End-to-End Testing

Test complete workflows from model prompt to tool execution:

```python
@pytest.mark.asyncio
async def test_model_interaction_with_tool():
    # Підготовка - налаштування MCP клієнта та мок-моделі
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # Відповіді мок-моделі
    mock_model = MockLanguageModel([
        MockResponse(
            "What's the weather in Seattle?",
            tool_calls=[{
                "tool_name": "weatherForecast",
                "parameters": {"location": "Seattle", "days": 3}
            }]
        ),
        MockResponse(
            "Here's the weather forecast for Seattle:\n- Today: 65°F, Partly Cloudy\n- Tomorrow: 68°F, Sunny\n- Day after: 62°F, Rain",
            tool_calls=[]
        )
    ])
    
    # Мок-відповідь інструменту погоди
    with aioresponses() as mocked:
        mocked.post(
            "http://localhost:5000/mcp/execute",
            payload={
                "result": {
                    "location": "Seattle",
                    "forecast": [
                        {"date": "2023-06-01", "temperature": 65, "conditions": "Partly Cloudy"},
                        {"date": "2023-06-02", "temperature": 68, "conditions": "Sunny"},
                        {"date": "2023-06-03", "temperature": 62, "conditions": "Rain"}
                    ]
                }
            }
        )
        
        # Виконання
        response = await mcp_client.send_prompt(
            "What's the weather in Seattle?",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # Перевірка
        assert "Seattle" in response.generated_text
        assert "65" in response.generated_text
        assert "Sunny" in response.generated_text
        assert "Rain" in response.generated_text
        assert len(response.tool_calls) == 1
        assert response.tool_calls[0].tool_name == "weatherForecast"
```

### Performance Testing

#### 1. Load Testing

Test how many concurrent requests your MCP server can handle:

```csharp
[Fact]
public async Task McpServer_HandlesHighConcurrency()
{
    // Підготовка
    var server = new McpServer(
        name: "TestServer",
        version: "1.0",
        maxConcurrentRequests: 100
    );
    
    server.RegisterTool(new FastExecutingTool());
    await server.StartAsync();
    
    var client = new McpClient("http://localhost:5000");
    
    // Виконання
    var tasks = new List<Task<McpResponse>>();
    for (int i = 0; i < 1000; i++)
    {
        tasks.Add(client.ExecuteToolAsync("fastTool", new { iteration = i }));
    }
    
    var results = await Task.WhenAll(tasks);
    
    // Перевірка
    Assert.Equal(1000, results.Length);
    Assert.All(results, r => Assert.NotNull(r));
}
```

#### 2. Stress Testing

Test the system under extreme load:

```java
@Test
public void testServerUnderStress() {
    int maxUsers = 1000;
    int rampUpTimeSeconds = 60;
    int testDurationSeconds = 300;
    
    // Налаштування JMeter для стрес-тестування
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // Конфігурація плану тестування JMeter
    HashTree testPlanTree = new HashTree();
    
    // Створення плану тестування, групи потоків, семплерів тощо
    TestPlan testPlan = new TestPlan("MCP Server Stress Test");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // Додавання HTTP-семплера для виконання інструменту
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // Додавання слухачів
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // Запуск тесту
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // Перевірка результатів
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // Середній час відповіді < 200мс
    assertTrue(summaryReport.getPercentile(90.0) < 500); // 90-й перцентиль < 500мс
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# Налаштування моніторингу для MCP сервера
def configure_monitoring(server):
    # Налаштування метрик Prometheus
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "Загальна кількість запитів MCP"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "Тривалість запиту в секундах",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "Кількість виконань інструментів",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "Тривалість виконання інструменту в секундах",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "Помилки виконання інструментів",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # Додавання middleware для вимірювання часу та запису метрик
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # Відкриття endpoint для метрик
    @server.router.get("/metrics")
    async def metrics():
        return generate_latest()
    
    return server
```

## MCP Workflow Design Patterns

Well-designed MCP workflows improve efficiency, reliability, and maintainability. Here are key patterns to follow:

### 1. Chain of Tools Pattern

Connect multiple tools in a sequence where each tool's output becomes the input for the next:

```python
# Реалізація ланцюжка інструментів на Python
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # Список інструментів для послідовного виконання
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # Виконання кожного інструменту в ланцюжку, передаючи результат попереднього
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # Збереження результату та використання його як вхідних даних для наступного інструменту
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# Приклад використання
data_processing_chain = ChainWorkflow([
    "dataFetch",
    "dataCleaner",
    "dataAnalyzer",
    "dataVisualizer"
])

result = await data_processing_chain.execute(
    mcp_client,
    {"source": "sales_database", "table": "transactions"}
)
```

### 2. Dispatcher Pattern

Use a central tool that dispatches to specialized tools based on input:

```csharp
public class ContentDispatcherTool : IMcpTool
{
    private readonly IMcpClient _mcpClient;
    
    public ContentDispatcherTool(IMcpClient mcpClient)
    {
        _mcpClient = mcpClient;
    }
    
    public string Name => "contentProcessor";
    public string Description => "Обробляє контент різних типів";
    
    public object GetSchema()
    {
        return new {
            type = "object",
            properties = new {
                content = new { type = "string" },
                contentType = new { 
                    type = "string",
                    enum = new[] { "text", "html", "markdown", "csv", "code" }
                },
                operation = new { 
                    type = "string",
                    enum = new[] { "summarize", "analyze", "extract", "convert" }
                }
            },
            required = new[] { "content", "contentType", "operation" }
        };
    }
    
    public async Task<ToolResponse> ExecuteAsync(ToolRequest request)
    {
        var content = request.Parameters.GetProperty("content").GetString();
        var contentType = request.Parameters.GetProperty("contentType").GetString();
        var operation = request.Parameters.GetProperty("operation").GetString();
        
        // Визначення, який спеціалізований інструмент використовувати
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // Перенаправлення до спеціалізованого інструменту
        var specializedResponse = await _mcpClient.ExecuteToolAsync(
            targetTool,
            new { content, options = GetOptionsForTool(targetTool, operation) }
        );
        
        return new ToolResponse { Result = specializedResponse.Result };
    }
    
    private string DetermineTargetTool(string contentType, string operation)
    {
        return (contentType, operation) switch
        {
            ("text", "summarize") => "textSummarizer",
            ("text", "analyze") => "textAnalyzer",
            ("html", _) => "htmlProcessor",
            ("markdown", _) => "markdownProcessor",
            ("csv", _) =>
# csvProcessor

[!IMPORTANT]  
Цей модуль призначений для обробки CSV-файлів з великою кількістю рядків.

## Основні функції

- `loadCSV(filePath)` — завантажує CSV-файл за вказаним шляхом.
- `parseCSV(data)` — розбирає CSV-дані у внутрішній формат.
- `filterRows(criteria)` — фільтрує рядки за заданими критеріями.
- `exportCSV(outputPath)` — експортує оброблені дані у новий CSV-файл.

## Приклад використання

```python
processor = csvProcessor()
processor.loadCSV('data/input.csv')
processor.parseCSV(processor.data)
filtered = processor.filterRows({'status': 'active'})
processor.exportCSV('data/output.csv')
```

[!TIP]  
Використовуйте `filterRows` для швидкого відбору потрібних записів без необхідності вручну переглядати весь файл.

## Відомі обмеження

- Підтримується лише кодування UTF-8.
- Максимальний розмір файлу — 100 МБ.
- Не підтримуються вкладені коми у полях без лапок.

[!WARNING]  
Переконайтеся, що вхідний файл відповідає формату CSV, інакше можуть виникнути помилки під час парсингу.
            ("code", _) => "codeAnalyzer",
            _ => throw new ToolExecutionException($"Інструмент недоступний для {contentType}/{operation}")
        };
    }
    
    private object GetOptionsForTool(string toolName, string operation)
    {
        // Повертає відповідні параметри для кожного спеціалізованого інструменту
        return toolName switch
        {
            "textSummarizer" => new { length = "medium" },
            "htmlProcessor" => new { cleanUp = true, operation },
            // Параметри для інших інструментів...
            _ => new { }
        };
    }
}
```

### 3. Parallel Processing Pattern

Execute multiple tools simultaneously for efficiency:

```java
public class ParallelDataProcessingWorkflow {
    private final McpClient mcpClient;
    
    public ParallelDataProcessingWorkflow(McpClient mcpClient) {
        this.mcpClient = mcpClient;
    }
    
    public WorkflowResult execute(String datasetId) {
        // Крок 1: Отримати метадані набору даних (синхронно)
        ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata", 
            Map.of("datasetId", datasetId));
        
        // Крок 2: Запустити кілька аналізів паралельно
        CompletableFuture<ToolResponse> statisticalAnalysis = CompletableFuture.supplyAsync(() ->
            mcpClient.executeTool("statisticalAnalysis", Map.of(
                "datasetId", datasetId,
                "type", "comprehensive"
            ))
        );
        
        CompletableFuture<ToolResponse> correlationAnalysis = CompletableFuture.supplyAsync(() ->
            mcpClient.executeTool("correlationAnalysis", Map.of(
                "datasetId", datasetId,
                "method", "pearson"
            ))
        );
        
        CompletableFuture<ToolResponse> outlierDetection = CompletableFuture.supplyAsync(() ->
            mcpClient.executeTool("outlierDetection", Map.of(
                "datasetId", datasetId,
                "sensitivity", "medium"
            ))
        );
        
        // Очікуємо завершення всіх паралельних завдань
        CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
            statisticalAnalysis, correlationAnalysis, outlierDetection
        );
        
        allAnalyses.join();  // Очікуємо завершення
        
        // Крок 3: Об’єднати результати
        Map<String, Object> combinedResults = new HashMap<>();
        combinedResults.put("metadata", metadataResponse.getResult());
        combinedResults.put("statistics", statisticalAnalysis.join().getResult());
        combinedResults.put("correlations", correlationAnalysis.join().getResult());
        combinedResults.put("outliers", outlierDetection.join().getResult());
        
        // Крок 4: Згенерувати підсумковий звіт
        ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator", 
            Map.of("analysisResults", combinedResults));
        
        // Повернути повний результат робочого процесу
        WorkflowResult result = new WorkflowResult();
        result.setDatasetId(datasetId);
        result.setAnalysisResults(combinedResults);
        result.setSummaryReport(summaryResponse.getResult());
        
        return result;
    }
}
```

### 4. Error Recovery Pattern

Implement graceful fallbacks for tool failures:

```python
class ResilientWorkflow:
    def __init__(self, mcp_client):
        self.client = mcp_client
    
    async def execute_with_fallback(self, primary_tool, fallback_tool, parameters):
        try:
            # Спочатку спробувати основний інструмент
            response = await self.client.execute_tool(primary_tool, parameters)
            return {
                "result": response.result,
                "source": "primary",
                "tool": primary_tool
            }
        except ToolExecutionException as e:
            # Зареєструвати помилку
            logging.warning(f"Основний інструмент '{primary_tool}' не вдалося виконати: {str(e)}")
            
            # Виконати запасний інструмент
            try:
                # Можливо, потрібно адаптувати параметри для запасного інструменту
                fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)
                
                response = await self.client.execute_tool(fallback_tool, fallback_params)
                return {
                    "result": response.result,
                    "source": "fallback",
                    "tool": fallback_tool,
                    "primaryError": str(e)
                }
            except ToolExecutionException as fallback_error:
                # Обидва інструменти не вдалося виконати
                logging.error(f"Обидва інструменти (основний і запасний) не вдалося виконати. Помилка запасного: {str(fallback_error)}")
                raise WorkflowExecutionException(
                    f"Робочий процес завершився помилкою: основна помилка: {str(e)}; помилка запасного: {str(fallback_error)}"
                )
    
    def _adapt_parameters(self, params, from_tool, to_tool):
        """Адаптує параметри між різними інструментами, якщо потрібно"""
        # Реалізація залежить від конкретних інструментів
        # У цьому прикладі просто повертаємо оригінальні параметри
        return params

# Приклад використання
async def get_weather(workflow, location):
    return await workflow.execute_with_fallback(
        "premiumWeatherService",  # Основний (платний) погодний API
        "basicWeatherService",    # Запасний (безкоштовний) погодний API
        {"location": location}
    )
```

### 5. Workflow Composition Pattern

Build complex workflows by composing simpler ones:

```csharp
public class CompositeWorkflow : IWorkflow
{
    private readonly List<IWorkflow> _workflows;
    
    public CompositeWorkflow(IEnumerable<IWorkflow> workflows)
    {
        _workflows = new List<IWorkflow>(workflows);
    }
    
    public async Task<WorkflowResult> ExecuteAsync(WorkflowContext context)
    {
        var results = new Dictionary<string, object>();
        
        foreach (var workflow in _workflows)
        {
            var workflowResult = await workflow.ExecuteAsync(context);
            
            // Зберігаємо результат кожного робочого процесу
            results[workflow.Name] = workflowResult;
            
            // Оновлюємо контекст результатом для наступного робочого процесу
            context = context.WithResult(workflow.Name, workflowResult);
        }
        
        return new WorkflowResult(results);
    }
    
    public string Name => "CompositeWorkflow";
    public string Description => "Виконує кілька робочих процесів послідовно";
}

// Приклад використання
var documentWorkflow = new CompositeWorkflow(new IWorkflow[] {
    new DocumentFetchWorkflow(),
    new DocumentProcessingWorkflow(),
    new InsightGenerationWorkflow(),
    new ReportGenerationWorkflow()
});

var result = await documentWorkflow.ExecuteAsync(new WorkflowContext {
    Parameters = new { documentId = "12345" }
});
```

# Testing MCP Servers: Best Practices and Top Tips

## Overview

Testing is a critical aspect of developing reliable, high-quality MCP servers. This guide provides comprehensive best practices and tips for testing your MCP servers throughout the development lifecycle, from unit tests to integration tests and end-to-end validation.

## Why Testing Matters for MCP Servers

MCP servers serve as crucial middleware between AI models and client applications. Thorough testing ensures:

- Reliability in production environments
- Accurate handling of requests and responses
- Proper implementation of MCP specifications
- Resilience against failures and edge cases
- Consistent performance under various loads

## Unit Testing for MCP Servers

### Unit Testing (Foundation)

Unit tests verify individual components of your MCP server in isolation.

#### What to Test

1. **Resource Handlers**: Test each resource handler's logic independently
2. **Tool Implementations**: Verify tool behavior with various inputs
3. **Prompt Templates**: Ensure prompt templates render correctly
4. **Schema Validation**: Test parameter validation logic
5. **Error Handling**: Verify error responses for invalid inputs

#### Best Practices for Unit Testing

```csharp
// Приклад юніт-тесту для калькулятора на C#
[Fact]
public async Task CalculatorTool_Add_ReturnsCorrectSum()
{
    // Підготовка
    var calculator = new CalculatorTool();
    var parameters = new Dictionary<string, object>
    {
        ["operation"] = "add",
        ["a"] = 5,
        ["b"] = 7
    };
    
    // Виконання
    var response = await calculator.ExecuteAsync(parameters);
    var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());
    
    // Перевірка
    Assert.Equal(12, result.Value);
}
```

```python
# Приклад юніт-тесту для калькулятора на Python
def test_calculator_tool_add():
    # Підготовка
    calculator = CalculatorTool()
    parameters = {
        "operation": "add",
        "a": 5,
        "b": 7
    }
    
    # Виконання
    response = calculator.execute(parameters)
    result = json.loads(response.content[0].text)
    
    # Перевірка
    assert result["value"] == 12
```

### Integration Testing (Middle Layer)

Integration tests verify interactions between components of your MCP server.

#### What to Test

1. **Server Initialization**: Test server startup with various configurations
2. **Route Registration**: Verify all endpoints are correctly registered
3. **Request Processing**: Test the full request-response cycle
4. **Error Propagation**: Ensure errors are properly handled across components
5. **Authentication & Authorization**: Test security mechanisms

#### Best Practices for Integration Testing

```csharp
// Приклад інтеграційного тесту для MCP сервера на C#
[Fact]
public async Task Server_ProcessToolRequest_ReturnsValidResponse()
{
    // Підготовка
    var server = new McpServer();
    server.RegisterTool(new CalculatorTool());
    await server.StartAsync();
    
    var request = new McpRequest
    {
        Tool = "calculator",
        Parameters = new Dictionary<string, object>
        {
            ["operation"] = "multiply",
            ["a"] = 6,
            ["b"] = 7
        }
    };
    
    // Виконання
    var response = await server.ProcessRequestAsync(request);
    
    // Перевірка
    Assert.NotNull(response);
    Assert.Equal(McpStatusCodes.Success, response.StatusCode);
    // Додаткові перевірки вмісту відповіді
    
    // Очищення
    await server.StopAsync();
}
```

### End-to-End Testing (Top Layer)

End-to-end tests verify the complete system behavior from client to server.

#### What to Test

1. **Client-Server Communication**: Test complete request-response cycles
2. **Real Client SDKs**: Test with actual client implementations
3. **Performance Under Load**: Verify behavior with multiple concurrent requests
4. **Error Recovery**: Test system recovery from failures
5. **Long-Running Operations**: Verify handling of streaming and long operations

#### Best Practices for E2E Testing

```typescript
// Приклад E2E тесту з клієнтом на TypeScript
describe('MCP Server E2E Tests', () => {
  let client: McpClient;
  
  beforeAll(async () => {
    // Запуск сервера в тестовому середовищі
    await startTestServer();
    client = new McpClient('http://localhost:5000');
  });
  
  afterAll(async () => {
    await stopTestServer();
  });
  
  test('Клієнт може викликати інструмент калькулятора і отримати правильний результат', async () => {
    // Виконання
    const response = await client.invokeToolAsync('calculator', {
      operation: 'divide',
      a: 20,
      b: 4
    });
    
    // Перевірка
    expect(response.statusCode).toBe(200);
    expect(response.content[0].text).toContain('5');
  });
});
```

## Mocking Strategies for MCP Testing

Mocking is essential for isolating components during testing.

### Components to Mock

1. **External AI Models**: Mock model responses for predictable testing
2. **External Services**: Mock API dependencies (databases, third-party services)
3. **Authentication Services**: Mock identity providers
4. **Resource Providers**: Mock expensive resource handlers

### Example: Mocking an AI Model Response

```csharp
// Приклад C# з Moq
var mockModel = new Mock<ILanguageModel>();
mockModel
    .Setup(m => m.GenerateResponseAsync(
        It.IsAny<string>(),
        It.IsAny<McpRequestContext>()))
    .ReturnsAsync(new ModelResponse { 
        Text = "Mocked model response",
        FinishReason = FinishReason.Completed
    });

var server = new McpServer(modelClient: mockModel.Object);
```

```python
# Приклад Python з unittest.mock
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
    # Налаштування мок-об’єкта
    mock_model.return_value.generate_response.return_value = {
        "text": "Mocked model response",
        "finish_reason": "completed"
    }
    
    # Використання мока в тесті
    server = McpServer(model_client=mock_model)
    # Продовження тесту
```

## Performance Testing

Performance testing is crucial for production MCP servers.

### What to Measure

1. **Latency**: Response time for requests
2. **Throughput**: Requests handled per second
3. **Resource Utilization**: CPU, memory, network usage
4. **Concurrency Handling**: Behavior under parallel requests
5. **Scaling Characteristics**: Performance as load increases

### Tools for Performance Testing

- **k6**: Open-source load testing tool
- **JMeter**: Comprehensive performance testing
- **Locust**: Python-based load testing
- **Azure Load Testing**: Cloud-based performance testing

### Example: Basic Load Test with k6

```javascript
// k6 скрипт для навантажувального тестування MCP сервера
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  vus: 10,  // 10 віртуальних користувачів
  duration: '30s',
};

export default function () {
  const payload = JSON.stringify({
    tool: 'calculator',
    parameters: {
      operation: 'add',
      a: Math.floor(Math.random() * 100),
      b: Math.floor(Math.random() * 100)
    }
  });

  const params = {
    headers: {
      'Content-Type': 'application/json',
      'Authorization': 'Bearer test-token'
    },
  };

  const res = http.post('http://localhost:5000/api/tools/invoke', payload, params);
  
  check(res, {
    'статус 200': (r) => r.status === 200,
    'час відповіді < 500ms': (r) => r.timings.duration < 500,
  });
  
  sleep(1);
}
```

## Test Automation for MCP Servers

Automating your tests ensures consistent quality and faster feedback loops.

### CI/CD Integration

1. **Run Unit Tests on Pull Requests**: Ensure code changes don't break existing functionality
2. **Integration Tests in Staging**: Run integration tests in pre-production environments
3. **Performance Baselines**: Maintain performance benchmarks to catch regressions
4. **Security Scans**: Automate security testing as part of the pipeline

### Example CI Pipeline (GitHub Actions)

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

## Testing for Compliance with MCP Specification

Verify your server correctly implements the MCP specification.

### Key Compliance Areas

1. **API Endpoints**: Test required endpoints (/resources, /tools, etc.)
2. **Request/Response Format**: Validate schema compliance
3. **Error Codes**: Verify correct status codes for various scenarios
4. **Content Types**: Test handling of different content types
5. **Authentication Flow**: Verify spec-compliant auth mechanisms

### Compliance Test Suite

```csharp
[Fact]
public async Task Server_ResourceEndpoint_ReturnsCorrectSchema()
{
    // Підготовка
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");
    
    // Виконання
    var response = await client.GetAsync("http://localhost:5000/api/resources");
    var content = await response.Content.ReadAsStringAsync();
    var resources = JsonSerializer.Deserialize

// Assert
Assert.Equal(HttpStatusCode.OK, response.StatusCode);
Assert.NotNull(resources);
Assert.All(resources.Resources, resource => 
{
    Assert.NotNull(resource.Id);
    Assert.NotNull(resource.Type);
    // Додаткова перевірка схеми
});
}
```

## Топ 10 порад для ефективного тестування MCP сервера

1. **Перевіряйте визначення інструментів окремо**: Переконайтеся, що схеми визначені незалежно від логіки інструментів  
2. **Використовуйте параметризовані тести**: Тестуйте інструменти з різними вхідними даними, включно з граничними випадками  
3. **Перевіряйте обробку помилок**: Переконайтеся, що всі можливі помилки обробляються коректно  
4. **Тестуйте логіку авторизації**: Забезпечте правильний контроль доступу для різних ролей користувачів  
5. **Контролюйте покриття тестами**: Спрямовуйте зусилля на високе покриття критичних ділянок коду  
6. **Тестуйте потокові відповіді**: Перевірте коректну обробку контенту у вигляді потоків  
7. **Імітуйте проблеми з мережею**: Тестуйте поведінку при поганих мережевих умовах  
8. **Перевіряйте обмеження ресурсів**: Переконайтеся у правильній роботі при досягненні квот або лімітів  
9. **Автоматизуйте регресійні тести**: Створіть набір тестів, що запускаються при кожній зміні коду  
10. **Документуйте тестові випадки**: Підтримуйте чітку документацію тестових сценаріїв  

## Поширені помилки при тестуванні

- **Надмірна залежність від тестування "щасливого шляху"**: Обов’язково ретельно тестуйте випадки помилок  
- **Ігнорування тестування продуктивності**: Виявляйте вузькі місця до того, як вони вплинуть на продакшн  
- **Тестування лише в ізоляції**: Поєднуйте юніт-, інтеграційні та end-to-end тести  
- **Неповне покриття API**: Переконайтеся, що всі кінцеві точки та функції протестовані  
- **Непослідовність тестових середовищ**: Використовуйте контейнери для забезпечення стабільності середовищ  

## Висновок

Комплексна стратегія тестування є ключовою для розробки надійних і якісних MCP серверів. Впроваджуючи найкращі практики та поради з цього посібника, ви зможете гарантувати, що ваші реалізації MCP відповідатимуть найвищим стандартам якості, надійності та продуктивності.

## Основні висновки

1. **Проєктування інструментів**: Дотримуйтесь принципу єдиної відповідальності, використовуйте dependency injection та проектуйте для композиції  
2. **Проєктування схем**: Створюйте чіткі, добре документовані схеми з відповідними обмеженнями валідації  
3. **Обробка помилок**: Реалізуйте плавну обробку помилок, структуровані відповіді з помилками та логіку повторних спроб  
4. **Продуктивність**: Використовуйте кешування, асинхронну обробку та обмеження ресурсів  
5. **Безпека**: Застосовуйте ретельну валідацію вхідних даних, перевірки авторизації та обробку конфіденційної інформації  
6. **Тестування**: Створюйте комплексні юніт-, інтеграційні та end-to-end тести  
7. **Патерни робочих процесів**: Використовуйте перевірені патерни, такі як ланцюжки, диспетчери та паралельна обробка  

## Завдання

Спроєктуйте MCP інструмент і робочий процес для системи обробки документів, яка:

1. Приймає документи у різних форматах (PDF, DOCX, TXT)  
2. Витягує текст та ключову інформацію з документів  
3. Класифікує документи за типом і змістом  
4. Генерує резюме для кожного документа  

Реалізуйте схеми інструментів, обробку помилок та патерн робочого процесу, який найкраще підходить для цього сценарію. Продумайте, як ви будете тестувати цю реалізацію.

## Ресурси

1. Приєднуйтесь до спільноти MCP на [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs), щоб бути в курсі останніх новин  
2. Вносьте свій внесок у open-source [MCP проєкти](https://github.com/modelcontextprotocol)  
3. Застосовуйте принципи MCP у власних AI ініціативах вашої організації  
4. Вивчайте спеціалізовані реалізації MCP для вашої галузі  
5. Розгляньте можливість проходження просунутих курсів з окремих тем MCP, таких як мультимодальна інтеграція або інтеграція корпоративних додатків  
6. Експериментуйте зі створенням власних MCP інструментів і робочих процесів, використовуючи принципи, вивчені у [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)  

Далі: Кращі практики [case studies](../09-CaseStudy/README.md)

**Відмова від відповідальності**:  
Цей документ було перекладено за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоча ми прагнемо до точності, будь ласка, майте на увазі, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння або неправильні тлумачення, що виникли внаслідок використання цього перекладу.