<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1827d0f7a6430dfb7adcdd5f1ee05bda",
  "translation_date": "2025-07-29T01:06:51+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "fa"
}
-->
# بهترین شیوه‌های توسعه MCP

[![بهترین شیوه‌های توسعه MCP](../../../translated_images/09.d0f6d86c9d72134ccf5a8d8c8650a0557e519936661fc894cad72d73522227cb.fa.png)](https://youtu.be/W56H9W7x-ao)

_(برای مشاهده ویدئوی این درس روی تصویر بالا کلیک کنید)_

## مرور کلی

این درس بر روی بهترین شیوه‌های پیشرفته برای توسعه، آزمایش و استقرار سرورهای MCP و ویژگی‌ها در محیط‌های تولید تمرکز دارد. با افزایش پیچیدگی و اهمیت اکوسیستم‌های MCP، پیروی از الگوهای استاندارد، قابلیت اطمینان، نگهداری و تعامل‌پذیری را تضمین می‌کند. این درس خرد عملی به دست آمده از پیاده‌سازی‌های واقعی MCP را برای راهنمایی شما در ایجاد سرورهای قوی و کارآمد با منابع، درخواست‌ها و ابزارهای مؤثر جمع‌آوری کرده است.

## اهداف یادگیری

در پایان این درس، شما قادر خواهید بود:

- بهترین شیوه‌های طراحی سرور و ویژگی‌های MCP را به کار ببرید
- استراتژی‌های جامع آزمایش برای سرورهای MCP ایجاد کنید
- الگوهای کاری کارآمد و قابل استفاده مجدد برای برنامه‌های پیچیده MCP طراحی کنید
- مدیریت صحیح خطا، ثبت وقایع و مشاهده‌پذیری را در سرورهای MCP پیاده‌سازی کنید
- پیاده‌سازی‌های MCP را برای عملکرد، امنیت و قابلیت نگهداری بهینه کنید

## اصول اصلی MCP

قبل از ورود به شیوه‌های خاص پیاده‌سازی، درک اصول اصلی که توسعه مؤثر MCP را هدایت می‌کنند، مهم است:

1. **ارتباط استاندارد شده**: MCP از JSON-RPC 2.0 به عنوان پایه خود استفاده می‌کند و یک قالب ثابت برای درخواست‌ها، پاسخ‌ها و مدیریت خطا در تمام پیاده‌سازی‌ها ارائه می‌دهد.

2. **طراحی کاربرمحور**: همیشه رضایت، کنترل و شفافیت کاربر را در پیاده‌سازی‌های MCP خود در اولویت قرار دهید.

3. **امنیت در اولویت**: اقدامات امنیتی قوی از جمله احراز هویت، مجوزدهی، اعتبارسنجی و محدودیت نرخ را پیاده‌سازی کنید.

4. **معماری ماژولار**: سرورهای MCP خود را با رویکرد ماژولار طراحی کنید، به طوری که هر ابزار و منبع هدف مشخص و متمرکزی داشته باشد.

5. **اتصالات حالت‌دار**: از توانایی MCP برای حفظ حالت در چندین درخواست استفاده کنید تا تعاملات منسجم‌تر و آگاهانه‌تر از زمینه ایجاد شود.

## بهترین شیوه‌های رسمی MCP

بهترین شیوه‌های زیر از مستندات رسمی پروتکل مدل زمینه (MCP) استخراج شده‌اند:

### بهترین شیوه‌های امنیتی

1. **رضایت و کنترل کاربر**: همیشه رضایت صریح کاربر را قبل از دسترسی به داده‌ها یا انجام عملیات‌ها الزامی کنید. کنترل واضحی بر روی داده‌های به اشتراک گذاشته شده و اقدامات مجاز ارائه دهید.

2. **حریم خصوصی داده‌ها**: فقط با رضایت صریح کاربر داده‌ها را افشا کنید و با کنترل‌های دسترسی مناسب از آن محافظت کنید. از انتقال غیرمجاز داده‌ها جلوگیری کنید.

3. **ایمنی ابزارها**: قبل از فراخوانی هر ابزاری، رضایت صریح کاربر را الزامی کنید. اطمینان حاصل کنید که کاربران عملکرد هر ابزار را درک می‌کنند و مرزهای امنیتی قوی را اعمال کنید.

4. **کنترل مجوز ابزارها**: مشخص کنید که کدام ابزارها در طول یک جلسه برای مدل مجاز هستند و اطمینان حاصل کنید که فقط ابزارهای صریحاً مجاز در دسترس باشند.

5. **احراز هویت**: قبل از اعطای دسترسی به ابزارها، منابع یا عملیات حساس، احراز هویت مناسب را با استفاده از کلیدهای API، توکن‌های OAuth یا روش‌های امن دیگر الزامی کنید.

6. **اعتبارسنجی پارامترها**: اعتبارسنجی تمام فراخوانی‌های ابزار را اعمال کنید تا از رسیدن ورودی‌های نادرست یا مخرب به پیاده‌سازی ابزار جلوگیری شود.

7. **محدودیت نرخ**: محدودیت نرخ را برای جلوگیری از سوءاستفاده و اطمینان از استفاده منصفانه از منابع سرور پیاده‌سازی کنید.

### بهترین شیوه‌های پیاده‌سازی

1. **مذاکره قابلیت‌ها**: در طول تنظیم اتصال، اطلاعاتی درباره ویژگی‌های پشتیبانی شده، نسخه‌های پروتکل، ابزارها و منابع موجود تبادل کنید.

2. **طراحی ابزارها**: ابزارهایی ایجاد کنید که بر یک کار خاص تمرکز داشته باشند، به جای ابزارهای بزرگ که چندین موضوع را مدیریت می‌کنند.

3. **مدیریت خطا**: پیام‌ها و کدهای خطای استاندارد را پیاده‌سازی کنید تا به تشخیص مشکلات، مدیریت شکست‌ها و ارائه بازخورد عملی کمک کنید.

4. **ثبت وقایع**: ثبت وقایع ساختاریافته را برای حسابرسی، اشکال‌زدایی و نظارت بر تعاملات پروتکل پیکربندی کنید.

5. **ردیابی پیشرفت**: برای عملیات طولانی‌مدت، به‌روزرسانی‌های پیشرفت را گزارش دهید تا رابط‌های کاربری پاسخگو ایجاد کنید.

6. **لغو درخواست‌ها**: به مشتریان اجازه دهید درخواست‌های در حال اجرا را که دیگر مورد نیاز نیستند یا زمان زیادی می‌برند، لغو کنند.

## منابع اضافی

برای اطلاعات به‌روزتر درباره بهترین شیوه‌های MCP، به منابع زیر مراجعه کنید:

- [مستندات MCP](https://modelcontextprotocol.io/)
- [مشخصات MCP](https://spec.modelcontextprotocol.io/)
- [مخزن GitHub](https://github.com/modelcontextprotocol)
- [بهترین شیوه‌های امنیتی](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## مثال‌های عملی پیاده‌سازی

### بهترین شیوه‌های طراحی ابزارها

#### 1. اصل مسئولیت واحد

هر ابزار MCP باید هدفی واضح و متمرکز داشته باشد. به جای ایجاد ابزارهای بزرگ که تلاش می‌کنند چندین موضوع را مدیریت کنند، ابزارهای تخصصی ایجاد کنید که در وظایف خاص برتری داشته باشند.

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

#### 2. مدیریت خطای سازگار

مدیریت خطای قوی با پیام‌های خطای اطلاعاتی و مکانیزم‌های بازیابی مناسب پیاده‌سازی کنید.

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

#### 3. اعتبارسنجی پارامترها

همیشه پارامترها را به دقت اعتبارسنجی کنید تا از ورودی‌های نادرست یا مخرب جلوگیری شود.

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

### مثال‌های پیاده‌سازی امنیتی

#### 1. احراز هویت و مجوزدهی

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

#### 2. محدودیت نرخ

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

## بهترین شیوه‌های آزمایش

### 1. آزمایش واحد ابزارهای MCP

همیشه ابزارهای خود را به صورت جداگانه آزمایش کنید و وابستگی‌های خارجی را شبیه‌سازی کنید:

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

### 2. آزمایش یکپارچگی

جریان کامل از درخواست‌های مشتری تا پاسخ‌های سرور را آزمایش کنید:

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

## بهینه‌سازی عملکرد

### 1. استراتژی‌های کشینگ

کشینگ مناسب را برای کاهش تأخیر و استفاده از منابع پیاده‌سازی کنید:

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
// مثال جاوا با تزریق وابستگی
public class CurrencyConversionTool implements Tool {
    private final ExchangeRateService exchangeService;
    private final CacheService cacheService;
    private final Logger logger;
    
    // وابستگی‌ها از طریق سازنده تزریق می‌شوند
    public CurrencyConversionTool(
            ExchangeRateService exchangeService,
            CacheService cacheService,
            Logger logger) {
        this.exchangeService = exchangeService;
        this.cacheService = cacheService;
        this.logger = logger;
    }
    
    // پیاده‌سازی ابزار
    // ...
}
```

#### 3. Composable Tools

Design tools that can be composed together to create more complex workflows:

```python
# مثال پایتون با ابزارهای ترکیبی
class DataFetchTool(Tool):
    def get_name(self):
        return "dataFetch"
    
    # پیاده‌سازی...

class DataAnalysisTool(Tool):
    def get_name(self):
        return "dataAnalysis"
    
    # این ابزار می‌تواند از نتایج ابزار dataFetch استفاده کند
    async def execute_async(self, request):
        # پیاده‌سازی...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # این ابزار می‌تواند از نتایج ابزار dataAnalysis استفاده کند
    async def execute_async(self, request):
        # پیاده‌سازی...
        pass

# این ابزارها می‌توانند به صورت مستقل یا به عنوان بخشی از یک جریان کاری استفاده شوند
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
                description = "متن جستجو. از کلمات کلیدی دقیق برای نتایج بهتر استفاده کنید." 
            },
            filters = new {
                type = "object",
                description = "فیلترهای اختیاری برای محدود کردن نتایج جستجو",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "بازه زمانی به فرمت YYYY-MM-DD:YYYY-MM-DD" 
                    },
                    category = new { 
                        type = "string", 
                        description = "نام دسته‌بندی برای فیلتر کردن" 
                    }
                }
            },
            limit = new { 
                type = "integer", 
                description = "حداکثر تعداد نتایج برای بازگشت (1-50)",
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
    
    // ویژگی ایمیل با اعتبارسنجی فرمت
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "آدرس ایمیل کاربر");
    
    // ویژگی سن با محدودیت‌های عددی
    Map<String, Object> age = new HashMap<>();
    age.put("type", "integer");
    age.put("minimum", 13);
    age.put("maximum", 120);
    age.put("description", "سن کاربر به سال");
    
    // ویژگی شمارش‌شده
    Map<String, Object> subscription = new HashMap<>();
    subscription.put("type", "string");
    subscription.put("enum", Arrays.asList("free", "basic", "premium"));
    subscription.put("default", "free");
    subscription.put("description", "سطح اشتراک");
    
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
        # پردازش درخواست
        results = await self._search_database(request.parameters["query"])
        
        # همیشه یک ساختار سازگار بازگردانید
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
    """اطمینان حاصل کنید که هر آیتم ساختار سازگاری دارد"""
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
            throw new ToolExecutionException($"فایل یافت نشد: {fileId}");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ToolExecutionException("شما اجازه دسترسی به این فایل را ندارید");
        }
        catch (Exception ex) when (ex is IOException || ex is TimeoutException)
        {
            _logger.LogError(ex, "خطا در دسترسی به فایل {FileId}", fileId);
            throw new ToolExecutionException("خطا در دسترسی به فایل: سرویس به طور موقت در دسترس نیست");
        }
    }
    catch (JsonException)
    {
        throw new ToolExecutionException("فرمت شناسه فایل نامعتبر است");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "خطای غیرمنتظره در FileAccessTool");
        throw new ToolExecutionException("یک خطای غیرمنتظره رخ داد");
    }
}
```

#### 2. Structured Error Responses

Return structured error information when possible:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    try {
        // پیاده‌سازی
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
        
        // پرتاب مجدد سایر استثناها به عنوان ToolExecutionException
        throw new ToolExecutionException("اجرای ابزار شکست خورد: " + ex.getMessage(), ex);
    }
}
```

#### 3. Retry Logic

Implement appropriate retry logic for transient failures:

```python
async def execute_async(self, request):
    max_retries = 3
    retry_count = 0
    base_delay = 1  # ثانیه
    
    while retry_count < max_retries:
        try:
            # فراخوانی API خارجی
            return await self._call_api(request.parameters)
        except TransientError as e:
            retry_count += 1
            if retry_count >= max_retries:
                raise ToolExecutionException(f"عملیات پس از {max_retries} تلاش شکست خورد: {str(e)}")
                
            # تأخیر نمایی
            delay = base_delay * (2 ** (retry_count - 1))
            logging.warning(f"خطای موقت، تلاش مجدد در {delay} ثانیه: {str(e)}")
            await asyncio.sleep(delay)
        except Exception as e:
            # خطای غیرموقت، تلاش مجدد نکنید
            raise ToolExecutionException(f"عملیات شکست خورد: {str(e)}")
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
    
    // ایجاد کلید کش بر اساس پارامترها
    var cacheKey = $"data_query_{ComputeHash(query)}";
    
    // ابتدا تلاش برای دریافت از کش
    if (_cache.TryGetValue(cacheKey, out var cachedResult))
    {
        return new ToolResponse { Result = cachedResult };
    }
    
    // عدم وجود در کش - انجام پرس‌وجوی واقعی
    var result = await _database.QueryAsync(query);
    
    // ذخیره در کش با زمان انقضا
    var cacheOptions = new MemoryCacheEntryOptions()
        .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
        
    _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
    
    return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
}

private string ComputeHash(string input)
{
    // پیاده‌سازی برای تولید هش پایدار برای کلید کش
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
        
        // برای عملیات طولانی، شناسه پردازش را بلافاصله برگردانید
        String processId = UUID.randomUUID().toString();
        
        // شروع پردازش غیرهمزمان
        CompletableFuture.runAsync(() -> {
            try {
                // انجام عملیات طولانی
                documentService.processDocument(documentId);
                
                // به‌روزرسانی وضعیت (معمولاً در پایگاه داده ذخیره می‌شود)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // پاسخ فوری با شناسه پردازش را برگردانید
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // ابزار بررسی وضعیت همراه
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
            tokens_per_second=5,  # اجازه ۵ درخواست در هر ثانیه
            bucket_size=10        # اجازه انفجار تا ۱۰ درخواست
        )
    
    async def execute_async(self, request):
        # بررسی اینکه آیا می‌توان ادامه داد یا باید منتظر ماند
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # اگر زمان انتظار زیاد باشد
                raise ToolExecutionException(
                    f"محدودیت نرخ تجاوز شده است. لطفاً {delay:.1f} ثانیه دیگر دوباره تلاش کنید."
                )
            else:
                # منتظر زمان تأخیر مناسب بمانید
                await asyncio.sleep(delay)
        
        # مصرف یک توکن و ادامه درخواست
        self.rate_limiter.consume()
        
        # فراخوانی API
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
            
            # محاسبه زمان تا توکن بعدی موجود
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # افزودن توکن‌های جدید بر اساس زمان سپری شده
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
    // بررسی وجود پارامترها
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("پارامتر مورد نیاز وجود ندارد: query");
    }
    
    // بررسی نوع صحیح
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("پارامتر query باید یک رشته باشد");
    }
    
    var query = queryProp.GetString();
    
    // بررسی محتوای رشته
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("پارامتر query نمی‌تواند خالی باشد");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("پارامتر query طول مجاز ۵۰۰ کاراکتر را تجاوز کرده است");
    }
    
    // بررسی حملات تزریق SQL در صورت لزوم
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("پرس‌وجوی نامعتبر: شامل SQL ناامن احتمالی است");
    }
    
    // ادامه اجرا
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // دریافت زمینه کاربر از درخواست
    UserContext user = request.getContext().getUserContext();
    
    // بررسی اینکه آیا کاربر مجوزهای لازم را دارد
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("کاربر مجوز دسترسی به اسناد را ندارد");
    }
    
    // برای منابع خاص، دسترسی به آن منبع را بررسی کنید
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("دسترسی به سند درخواست شده رد شد");
    }
    
    // ادامه اجرای ابزار
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
        
        # دریافت داده‌های کاربر
        user_data = await self.user_service.get_user_data(user_id)
        
        # فیلتر کردن فیلدهای حساس مگر اینکه صراحتاً درخواست شده و مجاز باشد
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # بررسی سطح مجوز در زمینه درخواست
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # ایجاد یک کپی برای جلوگیری از تغییر اصل
        redacted = user_data.copy()
        
        # فیلتر کردن فیلدهای حساس خاص
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # فیلتر کردن داده‌های حساس تو در تو
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
    // تنظیم
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("Seattle", 3))
        .ReturnsAsync(new WeatherForecast(/* داده‌های آزمایشی */));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "Seattle", 
            days = 3 
        })
    );
    
    // اجرا
    var response = await tool.ExecuteAsync(request);
    
    // بررسی
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // تنظیم
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("InvalidLocation", It.IsAny<int>()))
        .ThrowsAsync(new LocationNotFoundException("مکان یافت نشد"));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "InvalidLocation", 
            days = 3 
        })
    );
    
    // اجرا و بررسی
    var exception = await Assert.ThrowsAsync<ToolExecutionException>(
        () => tool.ExecuteAsync(request)
    );
    
    Assert.Contains("مکان یافت نشد", exception.Message);
}
```

#### 2. Schema Validation Testing

Test that schemas are valid and properly enforce constraints:

```java
@Test
public void testSchemaValidation() {
    // ایجاد نمونه ابزار
    SearchTool searchTool = new SearchTool();
    
    // دریافت طرح
    Object schema = searchTool.getSchema();
    
    // تبدیل طرح به JSON برای اعتبارسنجی
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // بررسی اینکه طرح JSONSchema معتبر است
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // آزمایش پارامترهای معتبر
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // آزمایش پارامتر مورد نیاز گم‌شده
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // آزمایش نوع پارامتر نامعتبر
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
    # تنظیم
    tool = ApiTool(timeout=0.1)  # زمان‌بندی بسیار کوتاه
    
    # شبیه‌سازی یک درخواست که زمان‌بندی می‌شود
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # طولانی‌تر از زمان‌بندی
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # اجرا و بررسی
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # بررسی پیام استثنا
        assert "زمان‌بندی شده" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # تنظیم
    tool = ApiTool()
    
    # شبیه‌سازی پاسخ محدودیت نرخ
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            status=429,
            headers={"Retry-After": "2"},
            body=json.dumps({"error": "محدودیت نرخ تجاوز شده است"})
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # اجرا و بررسی
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # بررسی اینکه استثنا شامل اطلاعات محدودیت نرخ است
        error_msg = str(exc_info.value).lower()
        assert "محدودیت نرخ" in error_msg
        assert "دوباره تلاش کنید" in error_msg
```

### Integration Testing

#### 1. Tool Chain Testing

Test tools working together in expected combinations:

```csharp
[Fact]
public async Task DataProcessingWorkflow_CompletesSuccessfully()
{
    // تنظیم
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // اجرا
شود "csvProcessor",
            ("code", _) => "codeProcessor",
            _ => throw new InvalidOperationException("نوع محتوا یا عملیات نامعتبر است")
        };
    }

    private object GetOptionsForTool(string toolName, string operation)
    {
        return toolName switch
        {
            "textSummarizer" => new { length = "short" },
            "textAnalyzer" => new { sentiment = true, keywords = true },
            "htmlProcessor" => new { clean = true },
            "markdownProcessor" => new { convertToHtml = true },
            "csvProcessor" => new { delimiter = "," },
            "codeProcessor" => new { language = "auto-detect" },
            _ => throw new InvalidOperationException("ابزار نامعتبر است")
        };
    }
}
پردازشگر CSV
```csharp
("code", _) => "codeAnalyzer",
_ => throw new ToolExecutionException($"هیچ ابزاری برای {contentType}/{operation} موجود نیست")
};
}

private object GetOptionsForTool(string toolName, string operation)
{
    // بازگرداندن گزینه‌های مناسب برای هر ابزار تخصصی
    return toolName switch
    {
        "textSummarizer" => new { length = "medium" },
        "htmlProcessor" => new { cleanUp = true, operation },
        // گزینه‌ها برای ابزارهای دیگر...
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
        // مرحله ۱: دریافت متادیتای مجموعه داده (همگام)
        ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata", 
            Map.of("datasetId", datasetId));
        
        // مرحله ۲: اجرای چندین تحلیل به صورت موازی
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
        
        // انتظار برای تکمیل تمام وظایف موازی
        CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
            statisticalAnalysis, correlationAnalysis, outlierDetection
        );
        
        allAnalyses.join();  // انتظار برای تکمیل
        
        // مرحله ۳: ترکیب نتایج
        Map<String, Object> combinedResults = new HashMap<>();
        combinedResults.put("metadata", metadataResponse.getResult());
        combinedResults.put("statistics", statisticalAnalysis.join().getResult());
        combinedResults.put("correlations", correlationAnalysis.join().getResult());
        combinedResults.put("outliers", outlierDetection.join().getResult());
        
        // مرحله ۴: تولید گزارش خلاصه
        ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator", 
            Map.of("analysisResults", combinedResults));
        
        // بازگرداندن نتیجه کامل جریان کاری
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
            # ابتدا تلاش برای ابزار اصلی
            response = await self.client.execute_tool(primary_tool, parameters)
            return {
                "result": response.result,
                "source": "primary",
                "tool": primary_tool
            }
        except ToolExecutionException as e:
            # ثبت شکست
            logging.warning(f"ابزار اصلی '{primary_tool}' شکست خورد: {str(e)}")
            
            # استفاده از ابزار جایگزین
            try:
                # ممکن است نیاز به تبدیل پارامترها برای ابزار جایگزین باشد
                fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)
                
                response = await self.client.execute_tool(fallback_tool, fallback_params)
                return {
                    "result": response.result,
                    "source": "fallback",
                    "tool": fallback_tool,
                    "primaryError": str(e)
                }
            except ToolExecutionException as fallback_error:
                # هر دو ابزار شکست خوردند
                logging.error(f"هر دو ابزار اصلی و جایگزین شکست خوردند. خطای جایگزین: {str(fallback_error)}")
                raise WorkflowExecutionException(
                    f"جریان کاری شکست خورد: خطای اصلی: {str(e)}; خطای جایگزین: {str(fallback_error)}"
                )
    
    def _adapt_parameters(self, params, from_tool, to_tool):
        """تبدیل پارامترها بین ابزارهای مختلف در صورت نیاز"""
        # این پیاده‌سازی به ابزارهای خاص بستگی دارد
        # برای این مثال، پارامترهای اصلی بازگردانده می‌شوند
        return params

# مثال استفاده
async def get_weather(workflow, location):
    return await workflow.execute_with_fallback(
        "premiumWeatherService",  # API اصلی (پرداختی) هواشناسی
        "basicWeatherService",    # API جایگزین (رایگان) هواشناسی
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
            
            // ذخیره نتیجه هر جریان کاری
            results[workflow.Name] = workflowResult;
            
            // به‌روزرسانی زمینه با نتیجه برای جریان کاری بعدی
            context = context.WithResult(workflow.Name, workflowResult);
        }
        
        return new WorkflowResult(results);
    }
    
    public string Name => "CompositeWorkflow";
    public string Description => "اجرای چندین جریان کاری به ترتیب";
}

// مثال استفاده
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
// مثال تست واحد برای ابزار ماشین‌حساب در C#
[Fact]
public async Task CalculatorTool_Add_ReturnsCorrectSum()
{
    // آماده‌سازی
    var calculator = new CalculatorTool();
    var parameters = new Dictionary<string, object>
    {
        ["operation"] = "add",
        ["a"] = 5,
        ["b"] = 7
    };
    
    // اجرا
    var response = await calculator.ExecuteAsync(parameters);
    var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());
    
    // بررسی
    Assert.Equal(12, result.Value);
}
```

```python
# مثال تست واحد برای ابزار ماشین‌حساب در Python
def test_calculator_tool_add():
    # آماده‌سازی
    calculator = CalculatorTool()
    parameters = {
        "operation": "add",
        "a": 5,
        "b": 7
    }
    
    # اجرا
    response = calculator.execute(parameters)
    result = json.loads(response.content[0].text)
    
    # بررسی
    assert result["value"] == 12
```
<فهرست منابع>
## ده نکته برتر برای تست مؤثر سرور MCP

1. **تعریف ابزارها را جداگانه تست کنید**: صحت تعریف‌های اسکیمای ابزار را به‌طور مستقل از منطق ابزار بررسی کنید.  
2. **از تست‌های پارامتری استفاده کنید**: ابزارها را با ورودی‌های متنوع، از جمله موارد مرزی، آزمایش کنید.  
3. **پاسخ‌های خطا را بررسی کنید**: اطمینان حاصل کنید که برای تمام شرایط خطای ممکن، مدیریت خطا به‌درستی انجام می‌شود.  
4. **منطق مجوزدهی را تست کنید**: دسترسی مناسب برای نقش‌های مختلف کاربران را بررسی کنید.  
5. **پوشش تست را پایش کنید**: برای پوشش بالای کدهای مسیر بحرانی تلاش کنید.  
6. **پاسخ‌های استریم‌شده را تست کنید**: از مدیریت صحیح محتوای استریم‌شده اطمینان حاصل کنید.  
7. **مشکلات شبکه را شبیه‌سازی کنید**: رفتار سیستم را در شرایط شبکه ضعیف بررسی کنید.  
8. **محدودیت منابع را تست کنید**: رفتار سیستم را هنگام رسیدن به سقف سهمیه‌ها یا محدودیت‌های نرخ بررسی کنید.  
9. **تست‌های رگرسیون را خودکار کنید**: مجموعه‌ای از تست‌ها بسازید که با هر تغییر کد اجرا شوند.  
10. **مستندسازی تست‌ها**: سناریوهای تست را به‌صورت واضح و دقیق مستند کنید.  

## اشتباهات رایج در تست

- **اتکای بیش از حد به تست مسیر خوش‌بینانه**: اطمینان حاصل کنید که موارد خطا به‌طور کامل تست شده‌اند.  
- **نادیده گرفتن تست عملکرد**: گلوگاه‌ها را قبل از تأثیرگذاری بر محیط تولید شناسایی کنید.  
- **تست فقط در حالت ایزوله**: تست‌های واحد، یکپارچه و انتها به انتها را ترکیب کنید.  
- **پوشش ناقص API**: اطمینان حاصل کنید که تمام نقاط پایانی و ویژگی‌ها تست شده‌اند.  
- **محیط‌های تست ناسازگار**: از کانتینرها برای اطمینان از محیط‌های تست سازگار استفاده کنید.  

## نتیجه‌گیری

یک استراتژی جامع تست برای توسعه سرورهای MCP قابل‌اعتماد و باکیفیت ضروری است. با اجرای بهترین روش‌ها و نکات ذکرشده در این راهنما، می‌توانید اطمینان حاصل کنید که پیاده‌سازی‌های MCP شما بالاترین استانداردهای کیفیت، قابلیت اطمینان و عملکرد را برآورده می‌کنند.  

## نکات کلیدی

1. **طراحی ابزار**: اصل مسئولیت واحد را دنبال کنید، از تزریق وابستگی استفاده کنید و برای ترکیب‌پذیری طراحی کنید.  
2. **طراحی اسکیمای داده**: اسکیمای واضح و مستند با محدودیت‌های اعتبارسنجی مناسب ایجاد کنید.  
3. **مدیریت خطا**: مدیریت خطای مناسب، پاسخ‌های خطای ساختاریافته و منطق تلاش مجدد را پیاده‌سازی کنید.  
4. **عملکرد**: از کشینگ، پردازش غیرهمزمان و محدودسازی منابع استفاده کنید.  
5. **امنیت**: اعتبارسنجی ورودی‌ها، بررسی مجوزها و مدیریت داده‌های حساس را به‌طور کامل اعمال کنید.  
6. **تست**: تست‌های جامع واحد، یکپارچه و انتها به انتها ایجاد کنید.  
7. **الگوهای کاری**: از الگوهای کاری شناخته‌شده مانند زنجیره‌ها، توزیع‌کننده‌ها و پردازش موازی استفاده کنید.  

## تمرین

یک ابزار MCP و یک جریان کاری برای یک سیستم پردازش اسناد طراحی کنید که:  

1. اسناد را در فرمت‌های مختلف (PDF، DOCX، TXT) بپذیرد.  
2. متن و اطلاعات کلیدی را از اسناد استخراج کند.  
3. اسناد را بر اساس نوع و محتوای آن‌ها طبقه‌بندی کند.  
4. یک خلاصه از هر سند تولید کند.  

اسکیمای ابزار، مدیریت خطا و یک الگوی کاری که برای این سناریو مناسب است را پیاده‌سازی کنید. همچنین، نحوه تست این پیاده‌سازی را در نظر بگیرید.  

## منابع

1. به جامعه MCP در [جامعه دیسکورد Azure AI Foundry](https://aka.ms/foundrydevs) بپیوندید تا از آخرین پیشرفت‌ها مطلع شوید.  
2. در پروژه‌های متن‌باز [MCP](https://github.com/modelcontextprotocol) مشارکت کنید.  
3. اصول MCP را در ابتکارات هوش مصنوعی سازمان خود اعمال کنید.  
4. پیاده‌سازی‌های تخصصی MCP را برای صنعت خود بررسی کنید.  
5. دوره‌های پیشرفته در موضوعات خاص MCP، مانند یکپارچه‌سازی چندوجهی یا یکپارچه‌سازی برنامه‌های سازمانی را در نظر بگیرید.  
6. با استفاده از اصول آموخته‌شده از [آزمایشگاه عملی](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)، ابزارها و جریان‌های کاری MCP خود را بسازید.  

بعدی: بهترین روش‌ها [مطالعات موردی](../09-CaseStudy/README.md)  

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما تلاش می‌کنیم دقت را حفظ کنیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نادرستی‌هایی باشند. سند اصلی به زبان اصلی آن باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حساس، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما هیچ مسئولیتی در قبال سوءتفاهم‌ها یا تفسیرهای نادرست ناشی از استفاده از این ترجمه نداریم.