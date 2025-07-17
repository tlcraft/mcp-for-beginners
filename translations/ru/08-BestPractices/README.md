<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "80e5c8949af5af0f401fce6f905990aa",
  "translation_date": "2025-07-16T23:22:34+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "ru"
}
-->
# Лучшие практики разработки MCP

## Обзор

Этот урок посвящён продвинутым лучшим практикам разработки, тестирования и развертывания MCP-серверов и функций в продуктивных средах. По мере роста сложности и значимости экосистем MCP, следование проверенным шаблонам обеспечивает надёжность, удобство сопровождения и совместимость. В уроке собран практический опыт реальных внедрений MCP, который поможет создавать устойчивые и эффективные серверы с продуманными ресурсами, подсказками и инструментами.

## Цели обучения

К концу урока вы сможете:
- Применять отраслевые лучшие практики при проектировании MCP-серверов и функций
- Создавать комплексные стратегии тестирования MCP-серверов
- Разрабатывать эффективные и переиспользуемые шаблоны рабочих процессов для сложных MCP-приложений
- Реализовывать корректную обработку ошибок, логирование и мониторинг в MCP-серверах
- Оптимизировать реализации MCP с точки зрения производительности, безопасности и удобства сопровождения

## Основные принципы MCP

Прежде чем перейти к конкретным практикам реализации, важно понять ключевые принципы, лежащие в основе эффективной разработки MCP:

1. **Стандартизованная коммуникация**: MCP базируется на JSON-RPC 2.0, что обеспечивает единый формат запросов, ответов и обработки ошибок во всех реализациях.

2. **Ориентация на пользователя**: Всегда ставьте на первое место согласие пользователя, его контроль и прозрачность в ваших реализациях MCP.

3. **Безопасность прежде всего**: Внедряйте надёжные меры безопасности, включая аутентификацию, авторизацию, валидацию и ограничение частоты запросов.

4. **Модульная архитектура**: Проектируйте MCP-серверы с модульным подходом, где каждый инструмент и ресурс имеет чёткую и узконаправленную функцию.

5. **Состояние соединения**: Используйте возможность MCP поддерживать состояние между несколькими запросами для более связного и контекстно-зависимого взаимодействия.

## Официальные лучшие практики MCP

Ниже приведены лучшие практики, основанные на официальной документации Model Context Protocol:

### Лучшие практики безопасности

1. **Согласие и контроль пользователя**: Всегда требуйте явного согласия пользователя перед доступом к данным или выполнением операций. Обеспечьте прозрачный контроль над тем, какие данные передаются и какие действия разрешены.

2. **Конфиденциальность данных**: Раскрывайте пользовательские данные только с явного согласия и защищайте их с помощью соответствующих механизмов контроля доступа. Предотвращайте несанкционированную передачу данных.

3. **Безопасность инструментов**: Требуйте явного согласия пользователя перед вызовом любого инструмента. Обеспечьте понимание пользователем функционала каждого инструмента и жёсткие границы безопасности.

4. **Контроль разрешений инструментов**: Настраивайте, какие инструменты модель может использовать в сессии, чтобы доступ был только к явно разрешённым.

5. **Аутентификация**: Требуйте корректную аутентификацию перед предоставлением доступа к инструментам, ресурсам или чувствительным операциям с помощью API-ключей, OAuth-токенов или других безопасных методов.

6. **Валидация параметров**: Обязательно проверяйте параметры всех вызовов инструментов, чтобы предотвратить передачу некорректных или вредоносных данных.

7. **Ограничение частоты запросов**: Внедряйте лимиты на количество запросов, чтобы предотвратить злоупотребления и обеспечить справедливое использование ресурсов сервера.

### Лучшие практики реализации

1. **Согласование возможностей**: При установлении соединения обменивайтесь информацией о поддерживаемых функциях, версиях протокола, доступных инструментах и ресурсах.

2. **Проектирование инструментов**: Создавайте узкоспециализированные инструменты, которые хорошо выполняют одну задачу, а не монолитные, охватывающие множество функций.

3. **Обработка ошибок**: Реализуйте стандартизированные сообщения и коды ошибок для упрощения диагностики, корректного управления сбоями и предоставления полезной обратной связи.

4. **Логирование**: Настраивайте структурированные логи для аудита, отладки и мониторинга взаимодействий по протоколу.

5. **Отслеживание прогресса**: Для длительных операций сообщайте о ходе выполнения, чтобы обеспечить отзывчивость пользовательского интерфейса.

6. **Отмена запросов**: Позволяйте клиентам отменять запросы, которые больше не нужны или выполняются слишком долго.

## Дополнительные ссылки

Для получения самой актуальной информации о лучших практиках MCP обращайтесь к:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)
- [Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## Практические примеры реализации

### Лучшие практики проектирования инструментов

#### 1. Принцип единственной ответственности

Каждый инструмент MCP должен иметь чёткую и узконаправленную цель. Вместо создания монолитных инструментов, пытающихся охватить несколько задач, разрабатывайте специализированные инструменты, которые отлично справляются с конкретными функциями.

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

#### 2. Последовательная обработка ошибок

Реализуйте надёжную обработку ошибок с информативными сообщениями и соответствующими механизмами восстановления.

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

#### 3. Валидация параметров

Всегда тщательно проверяйте параметры, чтобы предотвратить передачу некорректных или вредоносных данных.

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

### Примеры реализации безопасности

#### 1. Аутентификация и авторизация

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

#### 2. Ограничение частоты запросов

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

## Лучшие практики тестирования

### 1. Модульное тестирование инструментов MCP

Всегда тестируйте инструменты изолированно, используя заглушки для внешних зависимостей:

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

### 2. Интеграционное тестирование

Проверяйте полный цикл от запросов клиента до ответов сервера:

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

## Оптимизация производительности

### 1. Стратегии кэширования

Реализуйте подходящее кэширование для снижения задержек и уменьшения нагрузки на ресурсы:

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
// Пример на Java с внедрением зависимостей
public class CurrencyConversionTool implements Tool {
    private final ExchangeRateService exchangeService;
    private final CacheService cacheService;
    private final Logger logger;
    
    // Зависимости внедряются через конструктор
    public CurrencyConversionTool(
            ExchangeRateService exchangeService,
            CacheService cacheService,
            Logger logger) {
        this.exchangeService = exchangeService;
        this.cacheService = cacheService;
        this.logger = logger;
    }
    
    // Реализация инструмента
    // ...
}
```

#### 3. Composable Tools

Design tools that can be composed together to create more complex workflows:

```python
# Пример на Python с композируемыми инструментами
class DataFetchTool(Tool):
    def get_name(self):
        return "dataFetch"
    
    # Реализация...

class DataAnalysisTool(Tool):
    def get_name(self):
        return "dataAnalysis"
    
    # Этот инструмент может использовать результаты dataFetch
    async def execute_async(self, request):
        # Реализация...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # Этот инструмент может использовать результаты dataAnalysis
    async def execute_async(self, request):
        # Реализация...
        pass

# Эти инструменты можно использовать как отдельно, так и в составе рабочего процесса
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
                description = "Текст поискового запроса. Используйте точные ключевые слова для лучших результатов." 
            },
            filters = new {
                type = "object",
                description = "Необязательные фильтры для уточнения результатов поиска",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "Диапазон дат в формате YYYY-MM-DD:YYYY-MM-DD" 
                    },
                    category = new { 
                        type = "string", 
                        description = "Название категории для фильтрации" 
                    }
                }
            },
            limit = new { 
                type = "integer", 
                description = "Максимальное количество возвращаемых результатов (1-50)",
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
    
    // Свойство email с проверкой формата
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "Адрес электронной почты пользователя");
    
    // Свойство age с числовыми ограничениями
    Map<String, Object> age = new HashMap<>();
    age.put("type", "integer");
    age.put("minimum", 13);
    age.put("maximum", 120);
    age.put("description", "Возраст пользователя в годах");
    
    // Перечисляемое свойство
    Map<String, Object> subscription = new HashMap<>();
    subscription.put("type", "string");
    subscription.put("enum", Arrays.asList("free", "basic", "premium"));
    subscription.put("default", "free");
    subscription.put("description", "Уровень подписки");
    
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
        # Обработка запроса
        results = await self._search_database(request.parameters["query"])
        
        # Всегда возвращаем согласованную структуру
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
    """Обеспечивает единообразную структуру для каждого элемента"""
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
            throw new ToolExecutionException($"Файл не найден: {fileId}");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ToolExecutionException("У вас нет прав доступа к этому файлу");
        }
        catch (Exception ex) when (ex is IOException || ex is TimeoutException)
        {
            _logger.LogError(ex, "Ошибка доступа к файлу {FileId}", fileId);
            throw new ToolExecutionException("Ошибка доступа к файлу: сервис временно недоступен");
        }
    }
    catch (JsonException)
    {
        throw new ToolExecutionException("Неверный формат идентификатора файла");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Неожиданная ошибка в FileAccessTool");
        throw new ToolExecutionException("Произошла непредвиденная ошибка");
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
        
        // Повторно выбрасываем другие исключения как ToolExecutionException
        throw new ToolExecutionException("Ошибка выполнения инструмента: " + ex.getMessage(), ex);
    }
}
```

#### 3. Retry Logic

Implement appropriate retry logic for transient failures:

```python
async def execute_async(self, request):
    max_retries = 3
    retry_count = 0
    base_delay = 1  # секунды
    
    while retry_count < max_retries:
        try:
            # Вызов внешнего API
            return await self._call_api(request.parameters)
        except TransientError as e:
            retry_count += 1
            if retry_count >= max_retries:
                raise ToolExecutionException(f"Операция не удалась после {max_retries} попыток: {str(e)}")
                
            # Экспоненциальная задержка
            delay = base_delay * (2 ** (retry_count - 1))
            logging.warning(f"Временная ошибка, повтор через {delay}с: {str(e)}")
            await asyncio.sleep(delay)
        except Exception as e:
            # Невременная ошибка, повтор не выполняется
            raise ToolExecutionException(f"Операция не удалась: {str(e)}")
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
        
        // Создаем ключ кэша на основе параметров
        var cacheKey = $"data_query_{ComputeHash(query)}";
        
        // Сначала пытаемся получить из кэша
        if (_cache.TryGetValue(cacheKey, out var cachedResult))
        {
            return new ToolResponse { Result = cachedResult };
        }
        
        // Кэш не найден - выполняем реальный запрос
        var result = await _database.QueryAsync(query);
        
        // Сохраняем в кэш с временем жизни
        var cacheOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
            
        _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
        
        return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
    }
    
    private string ComputeHash(string input)
    {
        // Реализация генерации стабильного хэша для ключа кэша
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
        
        // Для длительных операций сразу возвращаем ID процесса
        String processId = UUID.randomUUID().toString();
        
        // Запускаем асинхронную обработку
        CompletableFuture.runAsync(() -> {
            try {
                // Выполняем длительную операцию
                documentService.processDocument(documentId);
                
                // Обновляем статус (обычно хранится в базе данных)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // Возвращаем немедленный ответ с ID процесса
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // Вспомогательный инструмент для проверки статуса
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
            tokens_per_second=5,  # Разрешаем 5 запросов в секунду
            bucket_size=10        # Разрешаем всплески до 10 запросов
        )
    
    async def execute_async(self, request):
        # Проверяем, можно ли продолжить или нужно подождать
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # Если ждать слишком долго
                raise ToolExecutionException(
                    f"Превышен лимит запросов. Пожалуйста, попробуйте снова через {delay:.1f} секунд."
                )
            else:
                # Ждем необходимое время
                await asyncio.sleep(delay)
        
        # Потребляем токен и продолжаем выполнение запроса
        self.rate_limiter.consume()
        
        # Вызываем API
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
            
            # Вычисляем время до появления следующего токена
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # Добавляем новые токены на основе прошедшего времени
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
    // Проверяем наличие параметров
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("Отсутствует обязательный параметр: query");
    }
    
    // Проверяем правильный тип
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("Параметр query должен быть строкой");
    }
    
    var query = queryProp.GetString();
    
    // Проверяем содержимое строки
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("Параметр query не может быть пустым");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("Параметр query превышает максимальную длину в 500 символов");
    }
    
    // Проверяем на SQL-инъекции, если применимо
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("Недопустимый запрос: содержит потенциально опасный SQL");
    }
    
    // Продолжаем выполнение
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // Получаем контекст пользователя из запроса
    UserContext user = request.getContext().getUserContext();
    
    // Проверяем, есть ли у пользователя необходимые права
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("У пользователя нет прав для доступа к документам");
    }
    
    // Для конкретных ресурсов проверяем доступ к ним
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("Доступ к запрашиваемому документу запрещен");
    }
    
    // Продолжаем выполнение инструмента
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
        
        # Получаем данные пользователя
        user_data = await self.user_service.get_user_data(user_id)
        
        # Фильтруем чувствительные поля, если не запрошено явно ИЛИ нет прав
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # Проверяем уровень авторизации в контексте запроса
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # Создаем копию, чтобы не изменять оригинал
        redacted = user_data.copy()
        
        # Маскируем конкретные чувствительные поля
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # Маскируем вложенные чувствительные данные
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
        .ReturnsAsync(new WeatherForecast(/* тестовые данные */));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "Seattle", 
            days = 3 
        })
    );
    
    // Действие
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
        .ThrowsAsync(new LocationNotFoundException("Местоположение не найдено"));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "InvalidLocation", 
            days = 3 
        })
    );
    
    // Действие и проверка
    var exception = await Assert.ThrowsAsync<ToolExecutionException>(
        () => tool.ExecuteAsync(request)
    );
    
    Assert.Contains("Местоположение не найдено", exception.Message);
}
```

#### 2. Schema Validation Testing

Test that schemas are valid and properly enforce constraints:

```java
@Test
public void testSchemaValidation() {
    // Создаем экземпляр инструмента
    SearchTool searchTool = new SearchTool();
    
    // Получаем схему
    Object schema = searchTool.getSchema();
    
    // Преобразуем схему в JSON для валидации
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // Проверяем, что схема является валидным JSONSchema
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // Тестируем валидные параметры
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // Тестируем отсутствие обязательного параметра
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // Тестируем неверный тип параметра
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
    tool = ApiTool(timeout=0.1)  # Очень короткий таймаут
    
    # Мокаем запрос, который превысит таймаут
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # Дольше таймаута
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # Действие и проверка
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Проверяем сообщение об ошибке
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # Подготовка
    tool = ApiTool()
    
    # Мокаем ответ с ограничением по скорости
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
        
        # Действие и проверка
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Проверяем, что исключение содержит информацию о лимите
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
    
    // Действие
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

// Проверка
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
        // Тестируем endpoint для обнаружения инструментов
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // Создаем запрос к инструменту
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // Отправляем запрос и проверяем ответ
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // Создаем некорректный запрос к инструменту
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // Отсутствует параметр "b"
        request.put("parameters", parameters);
        
        // Отправляем запрос и проверяем ошибку в ответе
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
    # Подготовка - настройка MCP клиента и мок модели
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # Мок ответы модели
    mock_model = MockLanguageModel([
        MockResponse(
            "Какая погода в Сиэтле?",
            tool_calls=[{
                "tool_name": "weatherForecast",
                "parameters": {"location": "Seattle", "days": 3}
            }]
        ),
        MockResponse(
            "Вот прогноз погоды для Сиэтла:\n- Сегодня: 65°F, переменная облачность\n- Завтра: 68°F, солнечно\n- Послезавтра: 62°F, дождь",
            tool_calls=[]
        )
    ])
    
    # Мок ответ инструмента погоды
    with aioresponses() as mocked:
        mocked.post(
            "http://localhost:5000/mcp/execute",
            payload={
                "result": {
                    "location": "Seattle",
                    "forecast": [
                        {"date": "2023-06-01", "temperature": 65, "conditions": "Переменная облачность"},
                        {"date": "2023-06-02", "temperature": 68, "conditions": "Солнечно"},
                        {"date": "2023-06-03", "temperature": 62, "conditions": "Дождь"}
                    ]
                }
            }
        )
        
        # Выполнение
        response = await mcp_client.send_prompt(
            "Какая погода в Сиэтле?",
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
    
    // Выполнение
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
    
    // Настройка JMeter для стресс-тестирования
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // Конфигурация плана тестирования JMeter
    HashTree testPlanTree = new HashTree();
    
    // Создание плана теста, группы потоков, сэмплеров и т.д.
    TestPlan testPlan = new TestPlan("MCP Server Stress Test");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // Добавление HTTP сэмплера для выполнения инструмента
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // Добавление слушателей
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // Запуск теста
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // Проверка результатов
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // Среднее время отклика < 200 мс
    assertTrue(summaryReport.getPercentile(90.0) < 500); // 90-й перцентиль < 500 мс
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# Настройка мониторинга для MCP сервера
def configure_monitoring(server):
    # Настройка метрик Prometheus
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "Общее количество запросов MCP"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "Длительность запроса в секундах",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "Количество выполнений инструментов",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "Длительность выполнения инструмента в секундах",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "Ошибки выполнения инструментов",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # Добавление middleware для измерения времени и записи метрик
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # Открытие endpoint для метрик
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
# Реализация цепочки инструментов на Python
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # Список инструментов для последовательного выполнения
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # Выполняем каждый инструмент в цепочке, передавая результат предыдущего
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # Сохраняем результат и используем его как вход для следующего инструмента
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# Пример использования
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
    public string Description => "Обрабатывает контент различных типов";
    
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
        
        // Определяем, какой специализированный инструмент использовать
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // Перенаправляем запрос к специализированному инструменту
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
# Руководство по использованию csvProcessor

Добро пожаловать в руководство по использованию csvProcessor — мощного инструмента для обработки CSV-файлов.

## Основные возможности

- Быстрая загрузка и парсинг CSV-файлов
- Фильтрация данных по заданным критериям
- Экспорт отфильтрованных данных в новый CSV-файл
- Поддержка больших объемов данных без потери производительности

## Начало работы

Чтобы начать работу с csvProcessor, выполните следующие шаги:

1. Импортируйте модуль в ваш проект:
   ```python
   import csvProcessor
   ```
2. Загрузите CSV-файл с помощью функции `load_csv`:
   ```python
   data = csvProcessor.load_csv('path/to/file.csv')
   ```
3. Примените фильтр к данным:
   ```python
   filtered_data = csvProcessor.filter_data(data, criteria)
   ```
4. Сохраните отфильтрованные данные:
   ```python
   csvProcessor.save_csv(filtered_data, 'path/to/output.csv')
   ```

## Советы по оптимизации

[!TIP] Для ускорения обработки больших файлов используйте параметр `chunk_size` в функции `load_csv`.

## Часто задаваемые вопросы

### Как обрабатывать файлы с нестандартной кодировкой?

Вы можете указать параметр `encoding` при загрузке файла:
```python
data = csvProcessor.load_csv('file.csv', encoding='utf-8-sig')
```

### Что делать, если в файле есть пустые строки?

Функция `filter_data` автоматически игнорирует пустые строки, но вы можете настроить это поведение через параметр `skip_empty`.

## Заключение

csvProcessor — удобный и эффективный инструмент для работы с CSV-файлами, который поможет вам быстро и легко обрабатывать данные. Если у вас возникнут вопросы, обратитесь к разделу документации или свяжитесь с поддержкой.
            ("code", _) => "codeAnalyzer",
            _ => throw new ToolExecutionException($"Нет доступного инструмента для {contentType}/{operation}")
        };
    }
    
    private object GetOptionsForTool(string toolName, string operation)
    {
        // Возвращает соответствующие параметры для каждого специализированного инструмента
        return toolName switch
        {
            "textSummarizer" => new { length = "medium" },
            "htmlProcessor" => new { cleanUp = true, operation },
            // Параметры для других инструментов...
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
        // Шаг 1: Получить метаданные набора данных (синхронно)
        ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata", 
            Map.of("datasetId", datasetId));
        
        // Шаг 2: Запустить несколько анализов параллельно
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
        
        // Ожидание завершения всех параллельных задач
        CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
            statisticalAnalysis, correlationAnalysis, outlierDetection
        );
        
        allAnalyses.join();  // Ждем завершения
        
        // Шаг 3: Объединение результатов
        Map<String, Object> combinedResults = new HashMap<>();
        combinedResults.put("metadata", metadataResponse.getResult());
        combinedResults.put("statistics", statisticalAnalysis.join().getResult());
        combinedResults.put("correlations", correlationAnalysis.join().getResult());
        combinedResults.put("outliers", outlierDetection.join().getResult());
        
        // Шаг 4: Создание итогового отчёта
        ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator", 
            Map.of("analysisResults", combinedResults));
        
        // Возврат полного результата рабочего процесса
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
            # Сначала пытаемся использовать основной инструмент
            response = await self.client.execute_tool(primary_tool, parameters)
            return {
                "result": response.result,
                "source": "primary",
                "tool": primary_tool
            }
        except ToolExecutionException as e:
            # Логируем ошибку
            logging.warning(f"Основной инструмент '{primary_tool}' не сработал: {str(e)}")
            
            # Переходим к запасному инструменту
            try:
                # Возможно, потребуется адаптировать параметры для запасного инструмента
                fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)
                
                response = await self.client.execute_tool(fallback_tool, fallback_params)
                return {
                    "result": response.result,
                    "source": "fallback",
                    "tool": fallback_tool,
                    "primaryError": str(e)
                }
            except ToolExecutionException as fallback_error:
                # Оба инструмента не сработали
                logging.error(f"Неудача основного и запасного инструментов. Ошибка запасного: {str(fallback_error)}")
                raise WorkflowExecutionException(
                    f"Рабочий процесс завершился с ошибкой: основная ошибка: {str(e)}; ошибка запасного: {str(fallback_error)}"
                )
    
    def _adapt_parameters(self, params, from_tool, to_tool):
        """Адаптировать параметры между разными инструментами при необходимости"""
        # Реализация зависит от конкретных инструментов
        # В этом примере просто возвращаем исходные параметры
        return params

# Пример использования
async def get_weather(workflow, location):
    return await workflow.execute_with_fallback(
        "premiumWeatherService",  # Основной (платный) API погоды
        "basicWeatherService",    # Запасной (бесплатный) API погоды
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
            
            // Сохраняем результат каждого рабочего процесса
            results[workflow.Name] = workflowResult;
            
            // Обновляем контекст с результатом для следующего рабочего процесса
            context = context.WithResult(workflow.Name, workflowResult);
        }
        
        return new WorkflowResult(results);
    }
    
    public string Name => "CompositeWorkflow";
    public string Description => "Выполняет несколько рабочих процессов последовательно";
}

// Пример использования
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
// Пример модульного теста для калькулятора на C#
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
    
    // Выполнение
    var response = await calculator.ExecuteAsync(parameters);
    var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());
    
    // Проверка
    Assert.Equal(12, result.Value);
}
```

```python
# Пример модульного теста для калькулятора на Python
def test_calculator_tool_add():
    # Подготовка
    calculator = CalculatorTool()
    parameters = {
        "operation": "add",
        "a": 5,
        "b": 7
    }
    
    # Выполнение
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
// Пример интеграционного теста для MCP сервера на C#
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
    
    // Выполнение
    var response = await server.ProcessRequestAsync(request);
    
    // Проверка
    Assert.NotNull(response);
    Assert.Equal(McpStatusCodes.Success, response.StatusCode);
    // Дополнительные проверки содержимого ответа
    
    // Очистка
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
// Пример E2E теста с клиентом на TypeScript
describe('MCP Server E2E Tests', () => {
  let client: McpClient;
  
  beforeAll(async () => {
    // Запуск сервера в тестовой среде
    await startTestServer();
    client = new McpClient('http://localhost:5000');
  });
  
  afterAll(async () => {
    await stopTestServer();
  });
  
  test('Клиент может вызвать инструмент калькулятора и получить правильный результат', async () => {
    // Выполнение
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
// Пример на C# с использованием Moq
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
# Пример на Python с использованием unittest.mock
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
    # Настройка мока
    mock_model.return_value.generate_response.return_value = {
        "text": "Mocked model response",
        "finish_reason": "completed"
    }
    
    # Использование мока в тесте
    server = McpServer(model_client=mock_model)
    # Продолжение теста
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
// Скрипт k6 для нагрузочного тестирования MCP сервера
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  vus: 10,  // 10 виртуальных пользователей
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
    'время ответа < 500мс': (r) => r.timings.duration < 500,
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
    // Подготовка
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");
    
    // Выполнение
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
    // Дополнительная проверка схемы
});
}
```

## Топ-10 советов для эффективного тестирования MCP сервера

1. **Отдельно проверяйте определения инструментов**: Проверяйте схемы независимо от логики инструментов  
2. **Используйте параметризованные тесты**: Тестируйте инструменты с разными входными данными, включая граничные случаи  
3. **Проверяйте ответы с ошибками**: Убедитесь в корректной обработке всех возможных ошибок  
4. **Тестируйте логику авторизации**: Обеспечьте правильный контроль доступа для разных ролей пользователей  
5. **Следите за покрытием тестами**: Стремитесь к высокому покрытию критически важного кода  
6. **Тестируйте потоковые ответы**: Проверьте корректную обработку потокового контента  
7. **Симулируйте сетевые проблемы**: Тестируйте поведение при плохом качестве сети  
8. **Проверяйте лимиты ресурсов**: Убедитесь в правильной работе при достижении квот или ограничений по скорости  
9. **Автоматизируйте регрессионные тесты**: Создайте набор тестов, который запускается при каждом изменении кода  
10. **Документируйте тестовые случаи**: Ведите понятную документацию по сценариям тестирования  

## Распространённые ошибки при тестировании

- **Чрезмерное упование на успешные сценарии**: Обязательно тщательно тестируйте ошибки  
- **Игнорирование тестирования производительности**: Выявляйте узкие места до выхода в продакшен  
- **Тестирование только в изоляции**: Используйте сочетание модульных, интеграционных и сквозных тестов  
- **Неполное покрытие API**: Убедитесь, что протестированы все эндпоинты и функции  
- **Несогласованные тестовые окружения**: Используйте контейнеры для стабильности и повторяемости тестов  

## Заключение

Комплексная стратегия тестирования необходима для создания надёжных и качественных MCP серверов. Следуя лучшим практикам и советам из этого руководства, вы обеспечите соответствие ваших MCP-реализаций самым высоким стандартам качества, надёжности и производительности.

## Основные выводы

1. **Проектирование инструментов**: Следуйте принципу единственной ответственности, используйте внедрение зависимостей и проектируйте для композиции  
2. **Проектирование схем**: Создавайте понятные, хорошо документированные схемы с правильными ограничениями валидации  
3. **Обработка ошибок**: Реализуйте корректную обработку ошибок, структурированные ответы и логику повторных попыток  
4. **Производительность**: Используйте кэширование, асинхронную обработку и ограничение ресурсов  
5. **Безопасность**: Применяйте тщательную валидацию входных данных, проверки авторизации и защиту чувствительных данных  
6. **Тестирование**: Создавайте комплексные модульные, интеграционные и сквозные тесты  
7. **Паттерны рабочих процессов**: Используйте проверенные паттерны, такие как цепочки, диспетчеры и параллельная обработка  

## Задание

Спроектируйте MCP инструмент и рабочий процесс для системы обработки документов, которая:

1. Принимает документы в нескольких форматах (PDF, DOCX, TXT)  
2. Извлекает текст и ключевую информацию из документов  
3. Классифицирует документы по типу и содержимому  
4. Генерирует краткое содержание каждого документа  

Реализуйте схемы инструментов, обработку ошибок и паттерн рабочего процесса, который лучше всего подходит для этого сценария. Подумайте, как вы будете тестировать эту реализацию.

## Ресурсы

1. Присоединяйтесь к сообществу MCP на [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs), чтобы быть в курсе последних новостей  
2. Вносите вклад в открытые [MCP проекты](https://github.com/modelcontextprotocol)  
3. Применяйте принципы MCP в AI-инициативах вашей организации  
4. Изучайте специализированные реализации MCP для вашей отрасли  
5. Рассмотрите возможность прохождения продвинутых курсов по отдельным темам MCP, таким как мультимодальная интеграция или интеграция корпоративных приложений  
6. Экспериментируйте с созданием собственных MCP инструментов и рабочих процессов, используя принципы из [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)  

Далее: Лучшие практики [кейсы](../09-CaseStudy/README.md)

**Отказ от ответственности**:  
Этот документ был переведен с помощью сервиса автоматического перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Несмотря на наши усилия по обеспечению точности, просим учитывать, что автоматический перевод может содержать ошибки или неточности. Оригинальный документ на его исходном языке следует считать авторитетным источником. Для получения критически важной информации рекомендуется обращаться к профессиональному переводу, выполненному человеком. Мы не несем ответственности за любые недоразумения или неправильные толкования, возникшие в результате использования данного перевода.