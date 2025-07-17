<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "80e5c8949af5af0f401fce6f905990aa",
  "translation_date": "2025-07-17T11:25:23+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "bg"
}
-->
# Най-добри практики за разработка на MCP

## Преглед

Този урок се фокусира върху напреднали най-добри практики за разработка, тестване и внедряване на MCP сървъри и функции в продукционни среди. С нарастването на сложността и значимостта на MCP екосистемите, спазването на установени модели гарантира надеждност, поддръжка и съвместимост. Този урок обединява практическа мъдрост, натрупана от реални MCP реализации, за да ви помогне да създавате стабилни, ефективни сървъри с полезни ресурси, подсказки и инструменти.

## Учебни цели

Към края на този урок ще можете да:
- Прилагате най-добрите практики в индустрията при проектиране на MCP сървъри и функции
- Създавате цялостни стратегии за тестване на MCP сървъри
- Проектирате ефективни, многократно използваеми модели на работни потоци за сложни MCP приложения
- Прилагате правилно обработване на грешки, логване и наблюдаемост в MCP сървъри
- Оптимизирате MCP реализации за производителност, сигурност и поддръжка

## Основни принципи на MCP

Преди да се потопим в конкретни практики за реализация, е важно да разберем основните принципи, които ръководят ефективната разработка на MCP:

1. **Стандартизирана комуникация**: MCP използва JSON-RPC 2.0 като основа, осигурявайки последователен формат за заявки, отговори и обработка на грешки във всички реализации.

2. **Дизайн, ориентиран към потребителя**: Винаги поставяйте на първо място съгласието, контрола и прозрачността за потребителя във вашите MCP реализации.

3. **Сигурност на първо място**: Прилагайте здрави мерки за сигурност, включително автентикация, авторизация, валидация и ограничаване на честотата.

4. **Модулна архитектура**: Проектирайте MCP сървърите си с модулен подход, при който всеки инструмент и ресурс има ясна и фокусирана цел.

5. **Състояниеви връзки**: Използвайте възможността на MCP да поддържа състояние през множество заявки за по-кохерентни и контекстно осъзнати взаимодействия.

## Официални най-добри практики за MCP

Следните най-добри практики са извлечени от официалната документация на Model Context Protocol:

### Най-добри практики за сигурност

1. **Съгласие и контрол на потребителя**: Винаги изисквайте изрично съгласие от потребителя преди достъп до данни или извършване на операции. Осигурете ясен контрол върху това какви данни се споделят и кои действия са разрешени.

2. **Поверителност на данните**: Излагайте потребителски данни само с изрично съгласие и ги защитете с подходящи контролни механизми за достъп. Предпазвайте от неоторизирано предаване на данни.

3. **Безопасност на инструментите**: Изисквайте изрично съгласие от потребителя преди извикване на какъвто и да е инструмент. Уверете се, че потребителите разбират функционалността на всеки инструмент и налагайте здрави граници за сигурност.

4. **Контрол на разрешенията за инструменти**: Конфигурирайте кои инструменти моделът може да използва по време на сесия, като гарантирате достъп само до изрично разрешени инструменти.

5. **Автентикация**: Изисквайте правилна автентикация преди предоставяне на достъп до инструменти, ресурси или чувствителни операции чрез API ключове, OAuth токени или други сигурни методи.

6. **Валидация на параметрите**: Налагайте валидация за всички извиквания на инструменти, за да предотвратите подаване на неправилни или злонамерени входни данни към реализациите на инструментите.

7. **Ограничаване на честотата**: Прилагайте ограничаване на честотата, за да предотвратите злоупотреби и да осигурите справедливо използване на сървърните ресурси.

### Най-добри практики за реализация

1. **Договаряне на възможности**: По време на установяване на връзка обменяйте информация за поддържаните функции, версии на протокола, налични инструменти и ресурси.

2. **Проектиране на инструменти**: Създавайте фокусирани инструменти, които изпълняват една задача добре, вместо монолитни инструменти, които обхващат множество функции.

3. **Обработка на грешки**: Прилагайте стандартизирани съобщения и кодове за грешки, които помагат при диагностика, обработка на неуспехи и предоставяне на полезна обратна връзка.

4. **Логване**: Конфигурирайте структурирани логове за одит, отстраняване на грешки и мониторинг на взаимодействията по протокола.

5. **Проследяване на напредъка**: При дълготрайни операции докладвайте за напредъка, за да се осигури отзивчив потребителски интерфейс.

6. **Отмяна на заявки**: Позволявайте на клиентите да отменят текущи заявки, които вече не са необходими или отнемат прекалено много време.

## Допълнителни препратки

За най-актуална информация относно най-добрите практики за MCP, вижте:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)
- [Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## Примери за практическа реализация

### Най-добри практики при проектиране на инструменти

#### 1. Принцип на единствената отговорност

Всеки MCP инструмент трябва да има ясна и фокусирана цел. Вместо да създавате монолитни инструменти, които се опитват да покрият множество функции, разработвайте специализирани инструменти, които се справят отлично с конкретни задачи.

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

#### 2. Последователна обработка на грешки

Прилагайте здрава обработка на грешки с информативни съобщения и подходящи механизми за възстановяване.

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

#### 3. Валидация на параметрите

Винаги валидирайте параметрите старателно, за да предотвратите подаване на неправилни или злонамерени данни.

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

### Примери за реализация на сигурността

#### 1. Автентикация и авторизация

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

#### 2. Ограничаване на честотата

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

## Най-добри практики за тестване

### 1. Модулно тестване на MCP инструменти

Винаги тествайте инструментите си изолирано, като използвате мокове за външни зависимости:

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

### 2. Интеграционно тестване

Тествайте целия поток от заявки на клиента до отговорите на сървъра:

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

## Оптимизация на производителността

### 1. Стратегии за кеширане

Прилагайте подходящо кеширане, за да намалите латентността и използването на ресурси:

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
// Java пример с инжектиране на зависимости
public class CurrencyConversionTool implements Tool {
    private final ExchangeRateService exchangeService;
    private final CacheService cacheService;
    private final Logger logger;
    
    // Зависимостите се инжектират чрез конструктора
    public CurrencyConversionTool(
            ExchangeRateService exchangeService,
            CacheService cacheService,
            Logger logger) {
        this.exchangeService = exchangeService;
        this.cacheService = cacheService;
        this.logger = logger;
    }
    
    // Реализация на инструмента
    // ...
}
```

#### 3. Composable Tools

Design tools that can be composed together to create more complex workflows:

```python
# Python пример, показващ съставни инструменти
class DataFetchTool(Tool):
    def get_name(self):
        return "dataFetch"
    
    # Реализация...

class DataAnalysisTool(Tool):
    def get_name(self):
        return "dataAnalysis"
    
    # Този инструмент може да използва резултатите от dataFetch
    async def execute_async(self, request):
        # Реализация...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # Този инструмент може да използва резултатите от dataAnalysis
    async def execute_async(self, request):
        # Реализация...
        pass

# Тези инструменти могат да се използват независимо или като част от работен поток
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
                description = "Текст на търсене. Използвайте точни ключови думи за по-добри резултати." 
            },
            filters = new {
                type = "object",
                description = "Опционални филтри за стесняване на резултатите от търсенето",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "Период във формат ГГГГ-ММ-ДД:ГГГГ-ММ-ДД" 
                    },
                    category = new { 
                        type = "string", 
                        description = "Име на категория за филтриране" 
                    }
                }
            },
            limit = new { 
                type = "integer", 
                description = "Максимален брой резултати за връщане (1-50)",
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
    
    // Имейл с валидация на формата
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "Имейл адрес на потребителя");
    
    // Възраст с числови ограничения
    Map<String, Object> age = new HashMap<>();
    age.put("type", "integer");
    age.put("minimum", 13);
    age.put("maximum", 120);
    age.put("description", "Възраст на потребителя в години");
    
    // Изброим тип
    Map<String, Object> subscription = new HashMap<>();
    subscription.put("type", "string");
    subscription.put("enum", Arrays.asList("free", "basic", "premium"));
    subscription.put("default", "free");
    subscription.put("description", "Ниво на абонамент");
    
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
        # Обработка на заявката
        results = await self._search_database(request.parameters["query"])
        
        # Винаги връщайте последователна структура
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
    """Гарантира, че всеки елемент има последователна структура"""
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
            throw new ToolExecutionException($"Файлът не е намерен: {fileId}");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ToolExecutionException("Нямате разрешение за достъп до този файл");
        }
        catch (Exception ex) when (ex is IOException || ex is TimeoutException)
        {
            _logger.LogError(ex, "Грешка при достъп до файл {FileId}", fileId);
            throw new ToolExecutionException("Грешка при достъп до файла: Услугата временно не е налична");
        }
    }
    catch (JsonException)
    {
        throw new ToolExecutionException("Невалиден формат на ID на файла");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Неочаквана грешка в FileAccessTool");
        throw new ToolExecutionException("Възникна неочаквана грешка");
    }
}
```

#### 2. Structured Error Responses

Return structured error information when possible:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    try {
        // Реализация
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
        
        // Прехвърляне на други изключения като ToolExecutionException
        throw new ToolExecutionException("Изпълнението на инструмента не бе успешно: " + ex.getMessage(), ex);
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
            # Извикване на външен API
            return await self._call_api(request.parameters)
        except TransientError as e:
            retry_count += 1
            if retry_count >= max_retries:
                raise ToolExecutionException(f"Операцията не успя след {max_retries} опита: {str(e)}")
                
            # Експоненциално забавяне
            delay = base_delay * (2 ** (retry_count - 1))
            logging.warning(f"Временна грешка, повторен опит след {delay}s: {str(e)}")
            await asyncio.sleep(delay)
        except Exception as e:
            # Невременна грешка, без повторен опит
            raise ToolExecutionException(f"Операцията не успя: {str(e)}")
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
        
        // Създаване на ключ за кеширане въз основа на параметрите
        var cacheKey = $"data_query_{ComputeHash(query)}";
        
        // Опит за вземане от кеша първо
        if (_cache.TryGetValue(cacheKey, out var cachedResult))
        {
            return new ToolResponse { Result = cachedResult };
        }
        
        // Кешът не съдържа резултат - изпълнява се реалната заявка
        var result = await _database.QueryAsync(query);
        
        // Записване в кеша с изтичане на валидността
        var cacheOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
            
        _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
        
        return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
    }
    
    private string ComputeHash(string input)
    {
        // Имплементация за генериране на стабилен хеш за ключа на кеша
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
        
        // За дълготрайни операции, веднага връщаме ID на процеса
        String processId = UUID.randomUUID().toString();
        
        // Стартиране на асинхронна обработка
        CompletableFuture.runAsync(() -> {
            try {
                // Изпълнение на дълготрайна операция
                documentService.processDocument(documentId);
                
                // Актуализиране на статуса (обикновено се съхранява в база данни)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // Връщане на незабавен отговор с ID на процеса
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // Съпътстващ инструмент за проверка на статус
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
            tokens_per_second=5,  # Позволява 5 заявки в секунда
            bucket_size=10        # Позволява изблици до 10 заявки
        )
    
    async def execute_async(self, request):
        # Проверка дали можем да продължим или трябва да изчакаме
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # Ако чакането е твърде дълго
                raise ToolExecutionException(
                    f"Превишен лимит на заявките. Моля, опитайте отново след {delay:.1f} секунди."
                )
            else:
                # Изчакване за подходящото време
                await asyncio.sleep(delay)
        
        # Консумиране на токен и продължаване със заявката
        self.rate_limiter.consume()
        
        # Извикване на API
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
            
            # Изчисляване на времето до наличен следващ токен
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # Добавяне на нови токени според изминалото време
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
    // Проверка дали параметрите съществуват
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("Липсва задължителен параметър: query");
    }
    
    // Проверка за правилен тип
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("Параметърът query трябва да е низ");
    }
    
    var query = queryProp.GetString();
    
    // Проверка на съдържанието на низа
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("Параметърът query не може да е празен");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("Параметърът query надвишава максималната дължина от 500 символа");
    }
    
    // Проверка за SQL инжекции, ако е приложимо
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("Невалидна заявка: съдържа потенциално опасен SQL");
    }
    
    // Продължаване с изпълнението
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // Вземане на потребителския контекст от заявката
    UserContext user = request.getContext().getUserContext();
    
    // Проверка дали потребителят има необходимите права
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("Потребителят няма права за достъп до документи");
    }
    
    // За конкретни ресурси, проверка на достъпа до този ресурс
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("Достъпът до заявения документ е отказан");
    }
    
    // Продължаване с изпълнението на инструмента
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
        
        # Вземане на данни за потребителя
        user_data = await self.user_service.get_user_data(user_id)
        
        # Филтриране на чувствителни полета, освен ако не е изрично поискано И разрешено
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # Проверка на нивото на упълномощаване в контекста на заявката
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # Създаване на копие, за да не се променя оригинала
        redacted = user_data.copy()
        
        # Скриване на конкретни чувствителни полета
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # Скриване на вложени чувствителни данни
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
    // Подготовка
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("Seattle", 3))
        .ReturnsAsync(new WeatherForecast(/* тестови данни */));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "Seattle", 
            days = 3 
        })
    );
    
    // Изпълнение
    var response = await tool.ExecuteAsync(request);
    
    // Проверка
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // Подготовка
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("InvalidLocation", It.IsAny<int>()))
        .ThrowsAsync(new LocationNotFoundException("Мястото не е намерено"));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "InvalidLocation", 
            days = 3 
        })
    );
    
    // Изпълнение и проверка
    var exception = await Assert.ThrowsAsync<ToolExecutionException>(
        () => tool.ExecuteAsync(request)
    );
    
    Assert.Contains("Мястото не е намерено", exception.Message);
}
```

#### 2. Schema Validation Testing

Test that schemas are valid and properly enforce constraints:

```java
@Test
public void testSchemaValidation() {
    // Създаване на инстанция на инструмента
    SearchTool searchTool = new SearchTool();
    
    // Вземане на схемата
    Object schema = searchTool.getSchema();
    
    // Конвертиране на схемата в JSON за валидиране
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // Валидиране, че схемата е валиден JSONSchema
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // Тест с валидни параметри
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // Тест с липсващ задължителен параметър
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // Тест с невалиден тип на параметъра
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
    # Подготовка
    tool = ApiTool(timeout=0.1)  # Много кратък таймаут
    
    # Мокване на заявка, която ще изтече времето
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # По-дълго от таймаута
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # Изпълнение и проверка
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Проверка на съобщението за изключение
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # Подготовка
    tool = ApiTool()
    
    # Мокване на отговор с ограничение на честотата
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
        
        # Изпълнение и проверка
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Проверка, че изключението съдържа информация за ограничението
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
    // Подготовка
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // Изпълнение
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

// Assert
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
        // Тествай endpoint за откриване на инструменти
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // Създай заявка за инструмент
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // Изпрати заявката и провери отговора
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // Създай невалидна заявка за инструмент
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // Липсва параметър "b"
        request.put("parameters", parameters);
        
        // Изпрати заявката и провери за грешка в отговора
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
    # Подготовка - настрой MCP клиент и mock модел
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # Mock отговори на модела
    mock_model = MockLanguageModel([
        MockResponse(
            "Какво е времето в Сиатъл?",
            tool_calls=[{
                "tool_name": "weatherForecast",
                "parameters": {"location": "Seattle", "days": 3}
            }]
        ),
        MockResponse(
            "Ето прогнозата за времето в Сиатъл:\n- Днес: 65°F, частично облачно\n- Утре: 68°F, слънчево\n- Следващия ден: 62°F, дъжд",
            tool_calls=[]
        )
    ])
    
    # Mock отговор на инструмента за времето
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
        
        # Действие
        response = await mcp_client.send_prompt(
            "Какво е времето в Сиатъл?",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # Проверка
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
    // Подготовка
    var server = new McpServer(
        name: "TestServer",
        version: "1.0",
        maxConcurrentRequests: 100
    );
    
    server.RegisterTool(new FastExecutingTool());
    await server.StartAsync();
    
    var client = new McpClient("http://localhost:5000");
    
    // Действие
    var tasks = new List<Task<McpResponse>>();
    for (int i = 0; i < 1000; i++)
    {
        tasks.Add(client.ExecuteToolAsync("fastTool", new { iteration = i }));
    }
    
    var results = await Task.WhenAll(tasks);
    
    // Проверка
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
    
    // Настрой JMeter за стрес тест
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // Конфигурирай тест плана на JMeter
    HashTree testPlanTree = new HashTree();
    
    // Създай тест план, thread group, samplers и др.
    TestPlan testPlan = new TestPlan("MCP Server Stress Test");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // Добави HTTP sampler за изпълнение на инструмент
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // Добави слушатели
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // Стартирай теста
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // Валидирай резултатите
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // Средно време за отговор < 200ms
    assertTrue(summaryReport.getPercentile(90.0) < 500); // 90-ти перцентил < 500ms
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# Конфигуриране на мониторинг за MCP сървър
def configure_monitoring(server):
    # Настрой Prometheus метрики
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "Общ брой MCP заявки"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "Продължителност на заявката в секунди",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "Брой изпълнения на инструменти",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "Продължителност на изпълнение на инструмента в секунди",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "Грешки при изпълнение на инструменти",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # Добави middleware за измерване на време и записване на метрики
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # Експонирай endpoint за метрики
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
# Имплементация на Python Chain of Tools
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # Списък с имена на инструменти за изпълнение последователно
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # Изпълни всеки инструмент в последователността, подавайки предишния резултат
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # Запази резултата и го използвай като вход за следващия инструмент
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# Пример за използване
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
    public string Description => "Обработва съдържание от различни типове";
    
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
        
        // Определи кой специализиран инструмент да се използва
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // Пренасочи към специализирания инструмент
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
ВАЖНИ ПРАВИЛА:
1. НЕ добавяйте '''markdown или други тагове около превода
2. Уверете се, че преводът не звучи твърде буквално
3. Превеждайте и коментарите
4. Този файл е написан във формат Markdown - не го третирайте като XML или HTML
5. Не превеждайте:
   - [!NOTE], [!WARNING], [!TIP], [!IMPORTANT], [!CAUTION]
   - Имена на променливи, функции, класове
   - Плейсхолдъри като @@INLINE_CODE_x@@ или @@CODE_BLOCK_x@@
   - URL адреси или пътища
6. Запазете цялото оригинално Markdown форматиране
7. Върнете САМО преведения текст без допълнителни тагове или маркировка
Моля, пишете изхода от ляво на дясно.
("code", _) => "codeAnalyzer",
_ => throw new ToolExecutionException($"Няма наличен инструмент за {contentType}/{operation}")
};
}

private object GetOptionsForTool(string toolName, string operation)
{
// Връща подходящи опции за всеки специализиран инструмент
return toolName switch
{
    "textSummarizer" => new { length = "medium" },
    "htmlProcessor" => new { cleanUp = true, operation },
    // Опции за други инструменти...
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
        // Стъпка 1: Вземане на метаданни за набора от данни (синхронно)
        ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata", 
            Map.of("datasetId", datasetId));
        
        // Стъпка 2: Стартиране на няколко анализа паралелно
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
        
        // Изчакване всички паралелни задачи да завършат
        CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
            statisticalAnalysis, correlationAnalysis, outlierDetection
        );
        
        allAnalyses.join();  // Изчакване за завършване
        
        // Стъпка 3: Комбиниране на резултатите
        Map<String, Object> combinedResults = new HashMap<>();
        combinedResults.put("metadata", metadataResponse.getResult());
        combinedResults.put("statistics", statisticalAnalysis.join().getResult());
        combinedResults.put("correlations", correlationAnalysis.join().getResult());
        combinedResults.put("outliers", outlierDetection.join().getResult());
        
        // Стъпка 4: Генериране на обобщен доклад
        ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator", 
            Map.of("analysisResults", combinedResults));
        
        // Връщане на пълния резултат от работния процес
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
            # Опит първо с основния инструмент
            response = await self.client.execute_tool(primary_tool, parameters)
            return {
                "result": response.result,
                "source": "primary",
                "tool": primary_tool
            }
        except ToolExecutionException as e:
            # Записване на грешката
            logging.warning(f"Основният инструмент '{primary_tool}' се провали: {str(e)}")
            
            # Преминаване към резервния инструмент
            try:
                # Може да се наложи адаптиране на параметрите за резервния инструмент
                fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)
                
                response = await self.client.execute_tool(fallback_tool, fallback_params)
                return {
                    "result": response.result,
                    "source": "fallback",
                    "tool": fallback_tool,
                    "primaryError": str(e)
                }
            except ToolExecutionException as fallback_error:
                # И двата инструмента се провалиха
                logging.error(f"И основният, и резервният инструменти се провалиха. Грешка при резервния: {str(fallback_error)}")
                raise WorkflowExecutionException(
                    f"Работният процес се провали: основна грешка: {str(e)}; грешка при резервния: {str(fallback_error)}"
                )
    
    def _adapt_parameters(self, params, from_tool, to_tool):
        """Адаптиране на параметрите между различни инструменти, ако е необходимо"""
        # Тази имплементация зависи от конкретните инструменти
        # В този пример просто връщаме оригиналните параметри
        return params

# Пример за използване
async def get_weather(workflow, location):
    return await workflow.execute_with_fallback(
        "premiumWeatherService",  # Основен (платен) API за времето
        "basicWeatherService",    # Резервен (безплатен) API за времето
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
            
            // Запазване на резултата от всеки работен процес
            results[workflow.Name] = workflowResult;
            
            // Актуализиране на контекста с резултата за следващия работен процес
            context = context.WithResult(workflow.Name, workflowResult);
        }
        
        return new WorkflowResult(results);
    }
    
    public string Name => "CompositeWorkflow";
    public string Description => "Изпълнява няколко работни процеса последователно";
}

// Пример за използване
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
// Примерен unit тест за калкулаторен инструмент на C#
[Fact]
public async Task CalculatorTool_Add_ReturnsCorrectSum()
{
    // Подготовка
    var calculator = new CalculatorTool();
    var parameters = new Dictionary<string, object>
    {
        ["operation"] = "add",
        ["a"] = 5,
        ["b"] = 7
    };
    
    // Изпълнение
    var response = await calculator.ExecuteAsync(parameters);
    var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());
    
    // Проверка
    Assert.Equal(12, result.Value);
}
```

```python
# Примерен unit тест за калкулаторен инструмент на Python
def test_calculator_tool_add():
    # Подготовка
    calculator = CalculatorTool()
    parameters = {
        "operation": "add",
        "a": 5,
        "b": 7
    }
    
    # Изпълнение
    response = calculator.execute(parameters)
    result = json.loads(response.content[0].text)
    
    # Проверка
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
// Примерен интеграционен тест за MCP сървър на C#
[Fact]
public async Task Server_ProcessToolRequest_ReturnsValidResponse()
{
    // Подготовка
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
    
    // Изпълнение
    var response = await server.ProcessRequestAsync(request);
    
    // Проверка
    Assert.NotNull(response);
    Assert.Equal(McpStatusCodes.Success, response.StatusCode);
    // Допълнителни проверки на съдържанието на отговора
    
    // Почистване
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
// Примерен E2E тест с клиент на TypeScript
describe('MCP Server E2E Tests', () => {
  let client: McpClient;
  
  beforeAll(async () => {
    // Стартиране на сървъра в тестова среда
    await startTestServer();
    client = new McpClient('http://localhost:5000');
  });
  
  afterAll(async () => {
    await stopTestServer();
  });
  
  test('Клиентът може да извика калкулаторния инструмент и да получи правилен резултат', async () => {
    // Изпълнение
    const response = await client.invokeToolAsync('calculator', {
      operation: 'divide',
      a: 20,
      b: 4
    });
    
    // Проверка
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
// Пример на C# с Moq
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
# Пример на Python с unittest.mock
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
    # Конфигуриране на mock
    mock_model.return_value.generate_response.return_value = {
        "text": "Mocked model response",
        "finish_reason": "completed"
    }
    
    # Използване на mock в теста
    server = McpServer(model_client=mock_model)
    # Продължаване с теста
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
// k6 скрипт за натоварващо тестване на MCP сървър
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  vus: 10,  // 10 виртуални потребители
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
    'статус е 200': (r) => r.status === 200,
    'време за отговор < 500ms': (r) => r.timings.duration < 500,
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
    
    - name: Настройка на Runtime
      uses: actions/setup-dotnet@v1
      with:
        dotnet-version: '8.0.x'
    
    - name: Възстановяване на зависимости
      run: dotnet restore
    
    - name: Компилиране
      run: dotnet build --no-restore
    
    - name: Unit тестове
      run: dotnet test --no-build --filter Category=Unit
    
    - name: Интеграционни тестове
      run: dotnet test --no-build --filter Category=Integration
      
    - name: Тестове за производителност
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
    // Подготовка
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");
    
    // Изпълнение
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
    // Допълнителна проверка на схемата
});
}

## Топ 10 съвета за ефективно тестване на MCP сървър

1. **Тествайте дефинициите на инструментите отделно**: Проверявайте схемите независимо от логиката на инструмента  
2. **Използвайте параметризирани тестове**: Тествайте инструментите с различни входни данни, включително гранични случаи  
3. **Проверявайте отговорите при грешки**: Уверете се, че грешките се обработват правилно при всички възможни ситуации  
4. **Тествайте логиката за авторизация**: Осигурете правилен контрол на достъпа за различни потребителски роли  
5. **Следете покритието на тестовете**: Стремете се към високо покритие на критичните части от кода  
6. **Тествайте стрийминг отговори**: Проверявайте правилното обработване на съдържание в реално време  
7. **Симулирайте мрежови проблеми**: Тествайте поведението при лоши мрежови условия  
8. **Тествайте лимитите на ресурсите**: Проверявайте поведението при достигане на квоти или ограничения на скоростта  
9. **Автоматизирайте регресионните тестове**: Създайте набор от тестове, които се изпълняват при всяка промяна в кода  
10. **Документирайте тестовите случаи**: Поддържайте ясна документация на тестовите сценарии  

## Чести грешки при тестване

- **Прекалено разчитане на успешните сценарии**: Уверете се, че грешките се тестват задълбочено  
- **Игнориране на тестовете за производителност**: Откривайте тесните места преди да засегнат продукцията  
- **Тестване само в изолация**: Комбинирайте модулни, интеграционни и крайни тестове  
- **Непълно покритие на API**: Уверете се, че всички крайни точки и функции са тествани  
- **Несъответстващи тестови среди**: Използвайте контейнери за осигуряване на постоянни тестови среди  

## Заключение

Цялостната тестова стратегия е от съществено значение за разработването на надеждни и качествени MCP сървъри. Като прилагате най-добрите практики и съвети, описани в това ръководство, можете да гарантирате, че вашите MCP реализации отговарят на най-високите стандарти за качество, надеждност и производителност.

## Основни изводи

1. **Дизайн на инструментите**: Следвайте принципа за единствена отговорност, използвайте dependency injection и проектирайте за съставяне  
2. **Дизайн на схемите**: Създавайте ясни, добре документирани схеми с подходящи валидиращи ограничения  
3. **Обработка на грешки**: Прилагайте елегантна обработка на грешки, структурирани отговори при грешки и логика за повторни опити  
4. **Производителност**: Използвайте кеширане, асинхронна обработка и ограничаване на ресурсите  
5. **Сигурност**: Прилагайте щателна валидация на входните данни, проверки за авторизация и обработка на чувствителна информация  
6. **Тестване**: Създавайте цялостни модулни, интеграционни и крайни тестове  
7. **Работни модели**: Прилагайте утвърдени модели като вериги, диспечери и паралелна обработка  

## Упражнение

Проектирайте MCP инструмент и работен процес за система за обработка на документи, която:

1. Приема документи в различни формати (PDF, DOCX, TXT)  
2. Извлича текст и ключова информация от документите  
3. Класифицира документите по тип и съдържание  
4. Генерира резюме на всеки документ  

Имплементирайте схемите на инструмента, обработката на грешки и работния модел, който най-добре пасва на този сценарий. Помислете как бихте тествали тази реализация.

## Ресурси

1. Присъединете се към MCP общността в [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs), за да сте в течение с последните разработки  
2. Допринасяйте за отворени [MCP проекти](https://github.com/modelcontextprotocol)  
3. Прилагайте MCP принципите в AI инициативите на вашата организация  
4. Разгледайте специализирани MCP реализации за вашата индустрия  
5. Обмислете да преминете напреднали курсове по специфични MCP теми, като мултимодална интеграция или интеграция на корпоративни приложения  
6. Експериментирайте с изграждането на собствени MCP инструменти и работни процеси, използвайки принципите, научени в [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)  

Следва: Най-добри практики [case studies](../09-CaseStudy/README.md)

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматизираните преводи могат да съдържат грешки или неточности. Оригиналният документ на неговия първичен език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за каквито и да е недоразумения или неправилни тълкувания, произтичащи от използването на този превод.