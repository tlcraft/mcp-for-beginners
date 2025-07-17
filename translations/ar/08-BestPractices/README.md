<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "80e5c8949af5af0f401fce6f905990aa",
  "translation_date": "2025-07-16T23:33:47+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "ar"
}
-->
# أفضل ممارسات تطوير MCP

## نظرة عامة

تركز هذه الدرسة على أفضل الممارسات المتقدمة لتطوير، اختبار، ونشر خوادم وميزات MCP في بيئات الإنتاج. مع تزايد تعقيد وأهمية أنظمة MCP، يضمن اتباع الأنماط المعتمدة الموثوقية، سهولة الصيانة، والتشغيل البيني. تجمع هذه الدرسة الحكمة العملية المكتسبة من تطبيقات MCP الحقيقية لتوجيهك في إنشاء خوادم قوية وفعالة مع موارد، مطالبات، وأدوات فعالة.

## أهداف التعلم

بنهاية هذه الدرسة، ستكون قادرًا على:
- تطبيق أفضل الممارسات الصناعية في تصميم خوادم وميزات MCP
- إنشاء استراتيجيات اختبار شاملة لخوادم MCP
- تصميم أنماط سير عمل فعالة وقابلة لإعادة الاستخدام لتطبيقات MCP المعقدة
- تنفيذ معالجة أخطاء صحيحة، تسجيل، ورصد في خوادم MCP
- تحسين تطبيقات MCP من حيث الأداء، الأمان، وسهولة الصيانة

## المبادئ الأساسية لـ MCP

قبل الخوض في ممارسات التنفيذ المحددة، من المهم فهم المبادئ الأساسية التي توجه تطوير MCP الفعال:

1. **التواصل الموحد**: يستخدم MCP JSON-RPC 2.0 كأساس له، مما يوفر تنسيقًا موحدًا للطلبات، الاستجابات، ومعالجة الأخطاء عبر جميع التطبيقات.

2. **تصميم يركز على المستخدم**: دائمًا أعطِ الأولوية لموافقة المستخدم، التحكم، والشفافية في تطبيقات MCP الخاصة بك.

3. **الأمان أولاً**: نفذ تدابير أمان قوية تشمل المصادقة، التفويض، التحقق، وتحديد المعدل.

4. **الهيكلية المعيارية**: صمم خوادم MCP بطريقة معيارية، حيث يكون لكل أداة وموارد غرض واضح ومركز.

5. **الاتصالات الحالة**: استغل قدرة MCP على الحفاظ على الحالة عبر طلبات متعددة لتفاعلات أكثر تماسكًا ووعيًا بالسياق.

## أفضل ممارسات MCP الرسمية

تستند أفضل الممارسات التالية إلى وثائق بروتوكول سياق النموذج الرسمية:

### أفضل ممارسات الأمان

1. **موافقة المستخدم والتحكم**: دائمًا اطلب موافقة صريحة من المستخدم قبل الوصول إلى البيانات أو تنفيذ العمليات. قدم تحكمًا واضحًا فيما يتم مشاركته من بيانات وما هي الإجراءات المصرح بها.

2. **خصوصية البيانات**: لا تعرض بيانات المستخدم إلا بموافقة صريحة واحمها بضوابط وصول مناسبة. احمِ ضد نقل البيانات غير المصرح به.

3. **سلامة الأدوات**: اطلب موافقة صريحة من المستخدم قبل استدعاء أي أداة. تأكد من فهم المستخدم لوظيفة كل أداة وفرض حدود أمان قوية.

4. **التحكم في أذونات الأدوات**: قم بتكوين الأدوات التي يُسمح للنموذج باستخدامها خلال الجلسة، مع ضمان الوصول فقط إلى الأدوات المصرح بها صراحة.

5. **المصادقة**: اطلب مصادقة صحيحة قبل منح الوصول إلى الأدوات، الموارد، أو العمليات الحساسة باستخدام مفاتيح API، رموز OAuth، أو طرق مصادقة آمنة أخرى.

6. **التحقق من المعلمات**: طبق التحقق لجميع استدعاءات الأدوات لمنع وصول مدخلات خاطئة أو خبيثة إلى تنفيذ الأدوات.

7. **تحديد المعدل**: نفذ تحديد المعدل لمنع سوء الاستخدام وضمان الاستخدام العادل لموارد الخادم.

### أفضل ممارسات التنفيذ

1. **التفاوض على القدرات**: خلال إعداد الاتصال، تبادل المعلومات حول الميزات المدعومة، إصدارات البروتوكول، الأدوات، والموارد المتاحة.

2. **تصميم الأدوات**: أنشئ أدوات مركزة تقوم بمهمة واحدة بشكل جيد، بدلاً من أدوات ضخمة تتعامل مع عدة مهام.

3. **معالجة الأخطاء**: نفذ رسائل وأكواد خطأ موحدة لمساعدة في تشخيص المشكلات، التعامل مع الفشل بسلاسة، وتقديم ملاحظات قابلة للتنفيذ.

4. **التسجيل**: قم بتكوين سجلات منظمة للمراجعة، التصحيح، ومراقبة تفاعلات البروتوكول.

5. **تتبع التقدم**: للعمليات طويلة الأمد، أبلغ عن تحديثات التقدم لتمكين واجهات مستخدم تفاعلية.

6. **إلغاء الطلبات**: اسمح للعملاء بإلغاء الطلبات الجارية التي لم تعد ضرورية أو تستغرق وقتًا طويلاً.

## مراجع إضافية

للحصول على أحدث المعلومات حول أفضل ممارسات MCP، راجع:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)
- [Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## أمثلة تطبيقية عملية

### أفضل ممارسات تصميم الأدوات

#### 1. مبدأ المسؤولية الواحدة

يجب أن يكون لكل أداة MCP غرض واضح ومركز. بدلاً من إنشاء أدوات ضخمة تحاول التعامل مع عدة مهام، طور أدوات متخصصة تتفوق في مهام محددة.

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

#### 2. معالجة الأخطاء المتسقة

نفذ معالجة أخطاء قوية مع رسائل خطأ مفيدة وآليات استرداد مناسبة.

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

#### 3. التحقق من المعلمات

تحقق دائمًا من المعلمات بدقة لمنع وصول مدخلات خاطئة أو خبيثة.

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

### أمثلة تنفيذ الأمان

#### 1. المصادقة والتفويض

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

#### 2. تحديد المعدل

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

## أفضل ممارسات الاختبار

### 1. اختبار وحدات أدوات MCP

اختبر أدواتك دائمًا بشكل معزول، مع محاكاة التبعيات الخارجية:

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

### 2. اختبار التكامل

اختبر التدفق الكامل من طلبات العميل إلى استجابات الخادم:

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

## تحسين الأداء

### 1. استراتيجيات التخزين المؤقت

نفذ التخزين المؤقت المناسب لتقليل زمن الاستجابة واستهلاك الموارد:

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
// مثال جافا مع حقن التبعيات
public class CurrencyConversionTool implements Tool {
    private final ExchangeRateService exchangeService;
    private final CacheService cacheService;
    private final Logger logger;
    
    // التبعيات محقونة عبر المُنشئ
    public CurrencyConversionTool(
            ExchangeRateService exchangeService,
            CacheService cacheService,
            Logger logger) {
        this.exchangeService = exchangeService;
        this.cacheService = cacheService;
        this.logger = logger;
    }
    
    // تنفيذ الأداة
    // ...
}
```

#### 3. Composable Tools

Design tools that can be composed together to create more complex workflows:

```python
# مثال بايثون يوضح أدوات قابلة للتركيب
class DataFetchTool(Tool):
    def get_name(self):
        return "dataFetch"
    
    # التنفيذ...

class DataAnalysisTool(Tool):
    def get_name(self):
        return "dataAnalysis"
    
    # يمكن لهذه الأداة استخدام نتائج أداة dataFetch
    async def execute_async(self, request):
        # التنفيذ...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # يمكن لهذه الأداة استخدام نتائج أداة dataAnalysis
    async def execute_async(self, request):
        # التنفيذ...
        pass

# يمكن استخدام هذه الأدوات بشكل مستقل أو كجزء من سير عمل
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
                description = "نص استعلام البحث. استخدم كلمات مفتاحية دقيقة للحصول على نتائج أفضل." 
            },
            filters = new {
                type = "object",
                description = "مرشحات اختيارية لتضييق نتائج البحث",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "نطاق التاريخ بصيغة YYYY-MM-DD:YYYY-MM-DD" 
                    },
                    category = new { 
                        type = "string", 
                        description = "اسم الفئة للتصفية" 
                    }
                }
            },
            limit = new { 
                type = "integer", 
                description = "الحد الأقصى لعدد النتائج التي سيتم إرجاعها (1-50)",
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
    
    // خاصية البريد الإلكتروني مع التحقق من الصيغة
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "عنوان البريد الإلكتروني للمستخدم");
    
    // خاصية العمر مع قيود رقمية
    Map<String, Object> age = new HashMap<>();
    age.put("type", "integer");
    age.put("minimum", 13);
    age.put("maximum", 120);
    age.put("description", "عمر المستخدم بالسنوات");
    
    // خاصية تعداد
    Map<String, Object> subscription = new HashMap<>();
    subscription.put("type", "string");
    subscription.put("enum", Arrays.asList("free", "basic", "premium"));
    subscription.put("default", "free");
    subscription.put("description", "فئة الاشتراك");
    
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
        # معالجة الطلب
        results = await self._search_database(request.parameters["query"])
        
        # إرجاع هيكل متسق دائمًا
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
    """يضمن أن كل عنصر له هيكل متسق"""
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
            throw new ToolExecutionException($"الملف غير موجود: {fileId}");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ToolExecutionException("ليس لديك إذن للوصول إلى هذا الملف");
        }
        catch (Exception ex) when (ex is IOException || ex is TimeoutException)
        {
            _logger.LogError(ex, "خطأ في الوصول إلى الملف {FileId}", fileId);
            throw new ToolExecutionException("خطأ في الوصول إلى الملف: الخدمة غير متوفرة مؤقتًا");
        }
    }
    catch (JsonException)
    {
        throw new ToolExecutionException("تنسيق معرف الملف غير صالح");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "خطأ غير متوقع في FileAccessTool");
        throw new ToolExecutionException("حدث خطأ غير متوقع");
    }
}
```

#### 2. Structured Error Responses

Return structured error information when possible:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    try {
        // التنفيذ
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
        
        // إعادة رمي الاستثناءات الأخرى كـ ToolExecutionException
        throw new ToolExecutionException("فشل تنفيذ الأداة: " + ex.getMessage(), ex);
    }
}
```

#### 3. Retry Logic

Implement appropriate retry logic for transient failures:

```python
async def execute_async(self, request):
    max_retries = 3
    retry_count = 0
    base_delay = 1  # ثواني
    
    while retry_count < max_retries:
        try:
            # استدعاء API خارجي
            return await self._call_api(request.parameters)
        except TransientError as e:
            retry_count += 1
            if retry_count >= max_retries:
                raise ToolExecutionException(f"فشلت العملية بعد {max_retries} محاولات: {str(e)}")
                
            # تأخير متزايد أُسّي
            delay = base_delay * (2 ** (retry_count - 1))
            logging.warning(f"خطأ مؤقت، إعادة المحاولة بعد {delay} ثانية: {str(e)}")
            await asyncio.sleep(delay)
        except Exception as e:
            # خطأ غير مؤقت، لا تعيد المحاولة
            raise ToolExecutionException(f"فشلت العملية: {str(e)}")
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
<ToolResponse>
ExecuteAsync(ToolRequest request)
    {
        var query = request.Parameters.GetProperty("query").GetString();
        
        // إنشاء مفتاح التخزين المؤقت بناءً على المعلمات
        var cacheKey = $"data_query_{ComputeHash(query)}";
        
        // محاولة الحصول على النتيجة من التخزين المؤقت أولاً
        if (_cache.TryGetValue(cacheKey, out var cachedResult))
        {
            return new ToolResponse { Result = cachedResult };
        }
        
        // لم يتم العثور على النتيجة في التخزين المؤقت - تنفيذ الاستعلام الفعلي
        var result = await _database.QueryAsync(query);
        
        // تخزين النتيجة في التخزين المؤقت مع تحديد فترة انتهاء الصلاحية
        var cacheOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
            
        _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
        
        return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
    }
    
    private string ComputeHash(string input)
    {
        // تنفيذ لتوليد هاش ثابت لمفتاح التخزين المؤقت
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
        
        // للعمليات التي تستغرق وقتًا طويلاً، إرجاع معرف المعالجة فورًا
        String processId = UUID.randomUUID().toString();
        
        // بدء المعالجة بشكل غير متزامن
        CompletableFuture.runAsync(() -> {
            try {
                // تنفيذ العملية طويلة الأمد
                documentService.processDocument(documentId);
                
                // تحديث الحالة (عادةً ما يتم تخزينها في قاعدة بيانات)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // إرجاع استجابة فورية مع معرف العملية
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // أداة مرافقة لفحص حالة العملية
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
            tokens_per_second=5,  # السماح بـ 5 طلبات في الثانية
            bucket_size=10        # السماح بتدفق يصل إلى 10 طلبات دفعة واحدة
        )
    
    async def execute_async(self, request):
        # التحقق مما إذا كان يمكننا المتابعة أو يجب الانتظار
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # إذا كان وقت الانتظار طويلًا جدًا
                raise ToolExecutionException(
                    f"تم تجاوز حد المعدل. يرجى المحاولة مرة أخرى بعد {delay:.1f} ثانية."
                )
            else:
                # الانتظار لمدة التأخير المناسبة
                await asyncio.sleep(delay)
        
        # استهلاك رمز متابعة الطلب
        self.rate_limiter.consume()
        
        # استدعاء API
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
            
            # حساب الوقت حتى توفر رمز جديد
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # إضافة رموز جديدة بناءً على الوقت المنقضي
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
    // التحقق من وجود المعلمات
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("المعلمة المطلوبة مفقودة: query");
    }
    
    // التحقق من النوع الصحيح
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("يجب أن تكون معلمة الاستعلام من نوع نصي");
    }
    
    var query = queryProp.GetString();
    
    // التحقق من محتوى النص
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("لا يمكن أن تكون معلمة الاستعلام فارغة");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("تتجاوز معلمة الاستعلام الحد الأقصى للطول وهو 500 حرف");
    }
    
    // التحقق من هجمات حقن SQL إذا كان ذلك ممكنًا
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("استعلام غير صالح: يحتوي على SQL قد يكون غير آمن");
    }
    
    // المتابعة بالتنفيذ
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // الحصول على سياق المستخدم من الطلب
    UserContext user = request.getContext().getUserContext();
    
    // التحقق مما إذا كان لدى المستخدم الأذونات المطلوبة
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("المستخدم لا يملك إذن الوصول إلى المستندات");
    }
    
    // بالنسبة للموارد المحددة، التحقق من الوصول إلى تلك الموارد
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("تم رفض الوصول إلى المستند المطلوب");
    }
    
    // المتابعة بتنفيذ الأداة
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
        
        # الحصول على بيانات المستخدم
        user_data = await self.user_service.get_user_data(user_id)
        
        # تصفية الحقول الحساسة ما لم يتم طلبها صراحةً وبموافقة
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # التحقق من مستوى التفويض في سياق الطلب
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # إنشاء نسخة لتجنب تعديل الأصل
        redacted = user_data.copy()
        
        # إخفاء الحقول الحساسة المحددة
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # إخفاء البيانات الحساسة المتداخلة
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
    // التهيئة
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("Seattle", 3))
        .ReturnsAsync(new WeatherForecast(/* بيانات الاختبار */));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "Seattle", 
            days = 3 
        })
    );
    
    // التنفيذ
    var response = await tool.ExecuteAsync(request);
    
    // التحقق
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // التهيئة
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("InvalidLocation", It.IsAny<int>()))
        .ThrowsAsync(new LocationNotFoundException("الموقع غير موجود"));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "InvalidLocation", 
            days = 3 
        })
    );
    
    // التنفيذ والتحقق من الاستثناء
    var exception = await Assert.ThrowsAsync<ToolExecutionException>(
        () => tool.ExecuteAsync(request)
    );
    
    Assert.Contains("الموقع غير موجود", exception.Message);
}
```

#### 2. Schema Validation Testing

Test that schemas are valid and properly enforce constraints:

```java
@Test
public void testSchemaValidation() {
    // إنشاء نسخة من الأداة
    SearchTool searchTool = new SearchTool();
    
    // الحصول على المخطط
    Object schema = searchTool.getSchema();
    
    // تحويل المخطط إلى JSON للتحقق
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // التحقق من أن المخطط هو JSONSchema صالح
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // اختبار المعلمات الصحيحة
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // اختبار المعلمة المطلوبة المفقودة
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // اختبار نوع المعلمة غير الصحيح
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
    # التهيئة
    tool = ApiTool(timeout=0.1)  # مهلة قصيرة جدًا
    
    # محاكاة طلب سينتهي مهله
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # أطول من المهلة
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # التنفيذ والتحقق من الاستثناء
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # التحقق من رسالة الاستثناء
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # التهيئة
    tool = ApiTool()
    
    # محاكاة استجابة محدودة المعدل
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
        
        # التنفيذ والتحقق من الاستثناء
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # التحقق من أن الاستثناء يحتوي على معلومات عن حد المعدل
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
    // التهيئة
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // التنفيذ
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

// تحقق
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
        // اختبار نقطة النهاية الخاصة بالاكتشاف
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // إنشاء طلب الأداة
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // إرسال الطلب والتحقق من الاستجابة
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // إنشاء طلب أداة غير صالح
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // المعامل "b" مفقود
        request.put("parameters", parameters);
        
        // إرسال الطلب والتحقق من استجابة الخطأ
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
    # التهيئة - إعداد عميل MCP ونموذج وهمي
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # استجابات النموذج الوهمي
    mock_model = MockLanguageModel([
        MockResponse(
            "ما هو الطقس في سياتل؟",
            tool_calls=[{
                "tool_name": "weatherForecast",
                "parameters": {"location": "Seattle", "days": 3}
            }]
        ),
        MockResponse(
            "إليك توقعات الطقس لسياتل:\n- اليوم: 65°F، غائم جزئياً\n- غداً: 68°F، مشمس\n- بعد غد: 62°F، ممطر",
            tool_calls=[]
        )
    ])
    
    # استجابة أداة الطقس الوهمية
    with aioresponses() as mocked:
        mocked.post(
            "http://localhost:5000/mcp/execute",
            payload={
                "result": {
                    "location": "Seattle",
                    "forecast": [
                        {"date": "2023-06-01", "temperature": 65, "conditions": "غائم جزئياً"},
                        {"date": "2023-06-02", "temperature": 68, "conditions": "مشمس"},
                        {"date": "2023-06-03", "temperature": 62, "conditions": "ممطر"}
                    ]
                }
            }
        )
        
        # التنفيذ
        response = await mcp_client.send_prompt(
            "ما هو الطقس في سياتل؟",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # التحقق
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
    // التهيئة
    var server = new McpServer(
        name: "TestServer",
        version: "1.0",
        maxConcurrentRequests: 100
    );
    
    server.RegisterTool(new FastExecutingTool());
    await server.StartAsync();
    
    var client = new McpClient("http://localhost:5000");
    
    // التنفيذ
    var tasks = new List<Task<McpResponse>>();
    for (int i = 0; i < 1000; i++)
    {
        tasks.Add(client.ExecuteToolAsync("fastTool", new { iteration = i }));
    }
    
    var results = await Task.WhenAll(tasks);
    
    // التحقق
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
    
    // إعداد JMeter لاختبار الضغط
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // تكوين خطة اختبار JMeter
    HashTree testPlanTree = new HashTree();
    
    // إنشاء خطة الاختبار، مجموعة الخيوط، العينات، إلخ.
    TestPlan testPlan = new TestPlan("اختبار ضغط خادم MCP");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // إضافة عينة HTTP لتنفيذ الأداة
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // إضافة المستمعين
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // تشغيل الاختبار
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // التحقق من النتائج
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // متوسط زمن الاستجابة أقل من 200 مللي ثانية
    assertTrue(summaryReport.getPercentile(90.0) < 500); // النسبة المئوية 90 أقل من 500 مللي ثانية
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# تكوين المراقبة لخادم MCP
def configure_monitoring(server):
    # إعداد مقاييس بروميثيوس
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "إجمالي طلبات MCP"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "مدة الطلب بالثواني",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "عدد تنفيذات الأدوات",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "مدة تنفيذ الأداة بالثواني",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "أخطاء تنفيذ الأدوات",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # إضافة وسيط لتوقيت وتسجيل المقاييس
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # كشف نقطة النهاية للمقاييس
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
# تنفيذ سلسلة أدوات في بايثون
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # قائمة بأسماء الأدوات التي سيتم تنفيذها بالتسلسل
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # تنفيذ كل أداة في السلسلة، مع تمرير النتيجة السابقة
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # تخزين النتيجة واستخدامها كمدخل للأداة التالية
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# مثال على الاستخدام
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
    public string Description => "يعالج محتوى من أنواع مختلفة";
    
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
        
        // تحديد الأداة المتخصصة التي سيتم استخدامها
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // إعادة التوجيه إلى الأداة المتخصصة
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
# معالجة CSV

في هذا القسم، سنتناول كيفية استخدام `csvProcessor` لمعالجة ملفات CSV بكفاءة.

## الميزات الرئيسية

- قراءة ملفات CSV بسرعة عالية.
- دعم تنسيقات CSV المختلفة.
- معالجة البيانات وتنظيفها بسهولة.
- دعم التصدير إلى تنسيقات متعددة.

## كيفية الاستخدام

1. استيراد `csvProcessor` في مشروعك.
2. تحميل ملف CSV باستخدام الدالة `loadCSV()`.
3. استخدام الدوال المتاحة لمعالجة البيانات مثل `filterRows()` و `mapColumns()`.
4. تصدير النتائج باستخدام `exportData()`.

## مثال عملي

```python
from csvProcessor import loadCSV, filterRows, exportData

data = loadCSV('data.csv')
filtered = filterRows(data, lambda row: row['age'] > 30)
exportData(filtered, 'filtered_data.csv')
```

> [!NOTE]
> تأكد من أن ملف CSV يحتوي على رؤوس الأعمدة لتجنب الأخطاء أثناء المعالجة.

## نصائح مهمة

- استخدم دالة `validateCSV()` للتحقق من صحة الملف قبل المعالجة.
- عند التعامل مع ملفات كبيرة، قم بتقسيمها إلى أجزاء أصغر لتحسين الأداء.
- استغل خاصية `asyncProcessing` لمعالجة البيانات بشكل غير متزامن.

## تحذير

[!WARNING]  
تجنب تعديل ملفات CSV الأصلية مباشرةً، واحتفظ بنسخة احتياطية قبل البدء في المعالجة.
("code", _) => "codeAnalyzer",
_ => throw new ToolExecutionException($"لا توجد أداة متاحة لـ {contentType}/{operation}")
};
}

private object GetOptionsForTool(string toolName, string operation)
{
// إرجاع الخيارات المناسبة لكل أداة متخصصة
return toolName switch
{
    "textSummarizer" => new { length = "medium" },
    "htmlProcessor" => new { cleanUp = true, operation },
    // خيارات لأدوات أخرى...
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
        // الخطوة 1: جلب بيانات وصفية لمجموعة البيانات (متزامن)
        ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata", 
            Map.of("datasetId", datasetId));
        
        // الخطوة 2: إطلاق عدة تحليلات بشكل متوازي
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
        
        // الانتظار حتى تكتمل كل المهام المتوازية
        CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
            statisticalAnalysis, correlationAnalysis, outlierDetection
        );
        
        allAnalyses.join();  // الانتظار حتى الانتهاء
        
        // الخطوة 3: دمج النتائج
        Map<String, Object> combinedResults = new HashMap<>();
        combinedResults.put("metadata", metadataResponse.getResult());
        combinedResults.put("statistics", statisticalAnalysis.join().getResult());
        combinedResults.put("correlations", correlationAnalysis.join().getResult());
        combinedResults.put("outliers", outlierDetection.join().getResult());
        
        // الخطوة 4: إنشاء تقرير ملخص
        ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator", 
            Map.of("analysisResults", combinedResults));
        
        // إرجاع نتيجة سير العمل كاملة
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
            # محاولة استخدام الأداة الأساسية أولاً
            response = await self.client.execute_tool(primary_tool, parameters)
            return {
                "result": response.result,
                "source": "primary",
                "tool": primary_tool
            }
        except ToolExecutionException as e:
            # تسجيل الفشل
            logging.warning(f"فشل الأداة الأساسية '{primary_tool}': {str(e)}")
            
            # التراجع إلى الأداة البديلة
            try:
                # قد تحتاج إلى تعديل المعلمات للأداة البديلة
                fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)
                
                response = await self.client.execute_tool(fallback_tool, fallback_params)
                return {
                    "result": response.result,
                    "source": "fallback",
                    "tool": fallback_tool,
                    "primaryError": str(e)
                }
            except ToolExecutionException as fallback_error:
                # فشل كلتا الأداتين
                logging.error(f"فشل كل من الأداة الأساسية والبديلة. خطأ التراجع: {str(fallback_error)}")
                raise WorkflowExecutionException(
                    f"فشل سير العمل: خطأ أساسي: {str(e)}؛ خطأ التراجع: {str(fallback_error)}"
                )
    
    def _adapt_parameters(self, params, from_tool, to_tool):
        """تعديل المعلمات بين الأدوات المختلفة إذا لزم الأمر"""
        # يعتمد هذا التنفيذ على الأدوات المحددة
        # في هذا المثال، سنعيد المعلمات الأصلية فقط
        return params

# مثال على الاستخدام
async def get_weather(workflow, location):
    return await workflow.execute_with_fallback(
        "premiumWeatherService",  # API الطقس الأساسي (مدفوع)
        "basicWeatherService",    # API الطقس البديل (مجاني)
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
            
            // تخزين نتيجة كل سير عمل
            results[workflow.Name] = workflowResult;
            
            // تحديث السياق بالنتيجة للسير العمل التالي
            context = context.WithResult(workflow.Name, workflowResult);
        }
        
        return new WorkflowResult(results);
    }
    
    public string Name => "CompositeWorkflow";
    public string Description => "ينفذ عدة سير عمل بالتتابع";
}

// مثال على الاستخدام
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
// مثال اختبار وحدة لأداة الآلة الحاسبة في C#
[Fact]
public async Task CalculatorTool_Add_ReturnsCorrectSum()
{
    // التهيئة
    var calculator = new CalculatorTool();
    var parameters = new Dictionary<string, object>
    {
        ["operation"] = "add",
        ["a"] = 5,
        ["b"] = 7
    };
    
    // التنفيذ
    var response = await calculator.ExecuteAsync(parameters);
    var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());
    
    // التحقق
    Assert.Equal(12, result.Value);
}
```

```python
# مثال اختبار وحدة لأداة الآلة الحاسبة في Python
def test_calculator_tool_add():
    # التهيئة
    calculator = CalculatorTool()
    parameters = {
        "operation": "add",
        "a": 5,
        "b": 7
    }
    
    # التنفيذ
    response = calculator.execute(parameters)
    result = json.loads(response.content[0].text)
    
    # التحقق
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
// مثال اختبار تكامل لخادم MCP في C#
[Fact]
public async Task Server_ProcessToolRequest_ReturnsValidResponse()
{
    // التهيئة
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
    
    // التنفيذ
    var response = await server.ProcessRequestAsync(request);
    
    // التحقق
    Assert.NotNull(response);
    Assert.Equal(McpStatusCodes.Success, response.StatusCode);
    // تحقق إضافي لمحتوى الاستجابة
    
    // التنظيف
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
// مثال اختبار شامل (E2E) مع عميل في TypeScript
describe('اختبارات MCP Server الشاملة', () => {
  let client: McpClient;
  
  beforeAll(async () => {
    // بدء الخادم في بيئة الاختبار
    await startTestServer();
    client = new McpClient('http://localhost:5000');
  });
  
  afterAll(async () => {
    await stopTestServer();
  });
  
  test('يمكن للعميل استدعاء أداة الآلة الحاسبة والحصول على النتيجة الصحيحة', async () => {
    // التنفيذ
    const response = await client.invokeToolAsync('calculator', {
      operation: 'divide',
      a: 20,
      b: 4
    });
    
    // التحقق
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
// مثال C# مع Moq
var mockModel = new Mock<ILanguageModel>();
mockModel
    .Setup(m => m.GenerateResponseAsync(
        It.IsAny<string>(),
        It.IsAny<McpRequestContext>()))
    .ReturnsAsync(new ModelResponse { 
        Text = "استجابة نموذج وهمي",
        FinishReason = FinishReason.Completed
    });

var server = new McpServer(modelClient: mockModel.Object);
```

```python
# مثال Python مع unittest.mock
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
    # إعداد النموذج الوهمي
    mock_model.return_value.generate_response.return_value = {
        "text": "استجابة نموذج وهمي",
        "finish_reason": "completed"
    }
    
    # استخدام النموذج الوهمي في الاختبار
    server = McpServer(model_client=mock_model)
    # متابعة الاختبار
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
// سكريبت k6 لاختبار تحميل خادم MCP
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  vus: 10,  // 10 مستخدمين افتراضيين
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
    'الحالة 200': (r) => r.status === 200,
    'زمن الاستجابة أقل من 500 مللي ثانية': (r) => r.timings.duration < 500,
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
name: اختبارات خادم MCP

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
    
    - name: إعداد بيئة التشغيل
      uses: actions/setup-dotnet@v1
      with:
        dotnet-version: '8.0.x'
    
    - name: استعادة التبعيات
      run: dotnet restore
    
    - name: البناء
      run: dotnet build --no-restore
    
    - name: اختبارات الوحدة
      run: dotnet test --no-build --filter Category=Unit
    
    - name: اختبارات التكامل
      run: dotnet test --no-build --filter Category=Integration
      
    - name: اختبارات الأداء
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
    // التهيئة
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");
    
    // التنفيذ
    var response = await client.GetAsync("http://localhost:5000/api/resources");
    var content = await response.Content.ReadAsStringAsync();
    var resources = JsonSerializer.Deserialize
<قائمةالموارد>
// Assert
Assert.Equal(HttpStatusCode.OK, response.StatusCode);
Assert.NotNull(resources);
Assert.All(resources.Resources, resource => 
{
    Assert.NotNull(resource.Id);
    Assert.NotNull(resource.Type);
    // التحقق الإضافي من صحة المخطط
});
}

## أفضل 10 نصائح لاختبار خادم MCP بفعالية

1. **اختبر تعريفات الأدوات بشكل منفصل**: تحقق من صحة تعريفات المخطط بشكل مستقل عن منطق الأداة  
2. **استخدم اختبارات مع معاملات متعددة**: اختبر الأدوات مع مجموعة متنوعة من المدخلات، بما في ذلك الحالات الحدية  
3. **تحقق من استجابات الأخطاء**: تأكد من التعامل الصحيح مع جميع حالات الخطأ المحتملة  
4. **اختبر منطق التفويض**: تأكد من التحكم السليم في الوصول لأدوار المستخدم المختلفة  
5. **راقب تغطية الاختبارات**: استهدف تغطية عالية لكود المسار الحرج  
6. **اختبر استجابات البث**: تحقق من التعامل الصحيح مع المحتوى المتدفق  
7. **حاكي مشاكل الشبكة**: اختبر السلوك في ظروف شبكة ضعيفة  
8. **اختبر حدود الموارد**: تحقق من السلوك عند الوصول إلى الحصص أو حدود المعدل  
9. **أتمتة اختبارات الانحدار**: أنشئ مجموعة اختبارات تعمل مع كل تغيير في الكود  
10. **وثق حالات الاختبار**: حافظ على توثيق واضح لسيناريوهات الاختبار  

## الأخطاء الشائعة في الاختبار

- **الاعتماد المفرط على اختبار المسار السعيد**: تأكد من اختبار حالات الخطأ بشكل شامل  
- **تجاهل اختبار الأداء**: حدد نقاط الاختناق قبل أن تؤثر على الإنتاج  
- **الاختبار في عزلة فقط**: اجمع بين اختبارات الوحدة، التكامل، والاختبارات الشاملة  
- **تغطية غير كاملة لواجهة البرمجة**: تأكد من اختبار جميع النقاط النهائية والميزات  
- **بيئات اختبار غير متسقة**: استخدم الحاويات لضمان بيئات اختبار متسقة  

## الخلاصة

استراتيجية اختبار شاملة ضرورية لتطوير خوادم MCP موثوقة وعالية الجودة. من خلال تطبيق أفضل الممارسات والنصائح الواردة في هذا الدليل، يمكنك ضمان أن تطبيقات MCP الخاصة بك تلبي أعلى معايير الجودة والموثوقية والأداء.

## النقاط الرئيسية

1. **تصميم الأدوات**: اتبع مبدأ المسؤولية الواحدة، استخدم حقن التبعيات، وصمم لأجل القابلية للتكوين  
2. **تصميم المخطط**: أنشئ مخططات واضحة وموثقة جيدًا مع قيود تحقق مناسبة  
3. **معالجة الأخطاء**: نفذ معالجة أخطاء سلسة، استجابات خطأ منظمة، ومنطق إعادة المحاولة  
4. **الأداء**: استخدم التخزين المؤقت، المعالجة غير المتزامنة، وتحديد الموارد  
5. **الأمان**: طبق تحققًا شاملاً من المدخلات، فحوصات التفويض، والتعامل مع البيانات الحساسة  
6. **الاختبار**: أنشئ اختبارات شاملة للوحدة، التكامل، والنهاية إلى النهاية  
7. **أنماط سير العمل**: طبق أنماط معروفة مثل السلاسل، الموزعين، والمعالجة المتوازية  

## التمرين

صمم أداة MCP وسير عمل لنظام معالجة المستندات الذي:

1. يقبل مستندات بصيغ متعددة (PDF، DOCX، TXT)  
2. يستخرج النص والمعلومات الرئيسية من المستندات  
3. يصنف المستندات حسب النوع والمحتوى  
4. يولد ملخصًا لكل مستند  

قم بتنفيذ مخططات الأداة، معالجة الأخطاء، ونمط سير العمل الأنسب لهذا السيناريو. فكر في كيفية اختبار هذا التنفيذ.

## الموارد

1. انضم إلى مجتمع MCP على [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs) للبقاء على اطلاع بأحدث التطورات  
2. ساهم في مشاريع MCP مفتوحة المصدر [MCP projects](https://github.com/modelcontextprotocol)  
3. طبق مبادئ MCP في مبادرات الذكاء الاصطناعي في مؤسستك  
4. استكشف تطبيقات MCP المتخصصة لصناعتك  
5. فكر في أخذ دورات متقدمة حول مواضيع MCP محددة، مثل التكامل متعدد الوسائط أو تكامل تطبيقات المؤسسات  
6. جرب بناء أدوات MCP وسير عمل خاصة بك باستخدام المبادئ التي تعلمتها من خلال [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)  

التالي: أفضل الممارسات [دراسات حالة](../09-CaseStudy/README.md)

**إخلاء المسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. للمعلومات الهامة، يُنصح بالاعتماد على الترجمة البشرية المهنية. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.