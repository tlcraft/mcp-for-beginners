<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0728873f4271f8c19105619921e830d9",
  "translation_date": "2025-07-22T08:37:41+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "fa"
}
-->
# بهترین روش‌های توسعه MCP

## مرور کلی

این درس بر بهترین روش‌های پیشرفته برای توسعه، آزمایش و استقرار سرورهای MCP و ویژگی‌ها در محیط‌های تولید تمرکز دارد. با افزایش پیچیدگی و اهمیت اکوسیستم‌های MCP، پیروی از الگوهای مشخص شده، قابلیت اطمینان، نگهداری و سازگاری را تضمین می‌کند. این درس خرد عملی به دست آمده از پیاده‌سازی‌های واقعی MCP را برای راهنمایی شما در ایجاد سرورهای قوی و کارآمد با منابع، درخواست‌ها و ابزارهای مؤثر، جمع‌آوری کرده است.

## اهداف یادگیری

در پایان این درس، شما قادر خواهید بود:

- بهترین روش‌های صنعتی را در طراحی سرور و ویژگی‌های MCP اعمال کنید
- استراتژی‌های آزمایشی جامع برای سرورهای MCP ایجاد کنید
- الگوهای کاری کارآمد و قابل استفاده مجدد برای برنامه‌های پیچیده MCP طراحی کنید
- مدیریت صحیح خطاها، ثبت وقایع و مشاهده‌پذیری را در سرورهای MCP پیاده‌سازی کنید
- پیاده‌سازی‌های MCP را برای عملکرد، امنیت و نگهداری بهینه کنید

## اصول اصلی MCP

قبل از ورود به روش‌های خاص پیاده‌سازی، مهم است که اصول اصلی که توسعه مؤثر MCP را هدایت می‌کنند، درک کنید:

1. **ارتباط استاندارد شده**: MCP از JSON-RPC 2.0 به عنوان پایه خود استفاده می‌کند و یک فرمت ثابت برای درخواست‌ها، پاسخ‌ها و مدیریت خطا در تمام پیاده‌سازی‌ها فراهم می‌کند.

2. **طراحی کاربر محور**: همیشه رضایت، کنترل و شفافیت کاربر را در پیاده‌سازی‌های MCP خود اولویت دهید.

3. **امنیت در اولویت**: اقدامات امنیتی قوی از جمله احراز هویت، مجوزدهی، اعتبارسنجی و محدودیت نرخ را پیاده‌سازی کنید.

4. **معماری ماژولار**: سرورهای MCP خود را با رویکرد ماژولار طراحی کنید، به طوری که هر ابزار و منبع دارای هدفی واضح و متمرکز باشد.

5. **اتصالات حالت‌دار**: از توانایی MCP برای حفظ حالت در چندین درخواست برای تعاملات منسجم‌تر و آگاه به زمینه استفاده کنید.

## بهترین روش‌های رسمی MCP

بهترین روش‌های زیر از مستندات رسمی پروتکل مدل کانتکست استخراج شده‌اند:

### بهترین روش‌های امنیتی

1. **رضایت و کنترل کاربر**: همیشه رضایت صریح کاربر را قبل از دسترسی به داده‌ها یا انجام عملیات‌ها الزامی کنید. کنترل واضحی بر داده‌های به اشتراک گذاشته شده و اقدامات مجاز ارائه دهید.

2. **حریم خصوصی داده‌ها**: فقط داده‌های کاربر را با رضایت صریح افشا کنید و با کنترل‌های دسترسی مناسب از آن محافظت کنید. از انتقال غیرمجاز داده‌ها جلوگیری کنید.

3. **ایمنی ابزار**: قبل از فراخوانی هر ابزار، رضایت صریح کاربر را الزامی کنید. اطمینان حاصل کنید که کاربران عملکرد هر ابزار را درک می‌کنند و مرزهای امنیتی قوی را اجرا کنید.

4. **کنترل مجوز ابزار**: پیکربندی کنید که کدام ابزارها در طول یک جلسه برای مدل قابل دسترسی هستند، و اطمینان حاصل کنید که فقط ابزارهای صریحاً مجاز قابل دسترسی باشند.

5. **احراز هویت**: قبل از اعطای دسترسی به ابزارها، منابع یا عملیات حساس، احراز هویت مناسب را با استفاده از کلیدهای API، توکن‌های OAuth یا روش‌های امن دیگر الزامی کنید.

6. **اعتبارسنجی پارامترها**: اعتبارسنجی را برای تمام فراخوانی‌های ابزار اجرا کنید تا از رسیدن ورودی‌های ناقص یا مخرب به پیاده‌سازی‌های ابزار جلوگیری شود.

7. **محدودیت نرخ**: محدودیت نرخ را برای جلوگیری از سوءاستفاده و تضمین استفاده منصفانه از منابع سرور پیاده‌سازی کنید.

### بهترین روش‌های پیاده‌سازی

1. **مذاکره قابلیت‌ها**: در طول تنظیم اتصال، اطلاعاتی درباره ویژگی‌های پشتیبانی شده، نسخه‌های پروتکل، ابزارها و منابع موجود تبادل کنید.

2. **طراحی ابزار**: ابزارهایی متمرکز ایجاد کنید که یک کار را به خوبی انجام دهند، به جای ابزارهای یکپارچه که چندین نگرانی را مدیریت می‌کنند.

3. **مدیریت خطا**: پیام‌ها و کدهای خطای استاندارد شده را پیاده‌سازی کنید تا به تشخیص مشکلات، مدیریت شکست‌ها به صورت مؤثر و ارائه بازخورد عملی کمک کنید.

4. **ثبت وقایع**: ثبت وقایع ساختاریافته را برای حسابرسی، اشکال‌زدایی و نظارت بر تعاملات پروتکل پیکربندی کنید.

5. **ردیابی پیشرفت**: برای عملیات‌های طولانی مدت، به‌روزرسانی‌های پیشرفت را گزارش دهید تا رابط‌های کاربری پاسخگو را فعال کنید.

6. **لغو درخواست**: به مشتریان اجازه دهید درخواست‌های در حال اجرا را که دیگر مورد نیاز نیستند یا زمان زیادی می‌برند، لغو کنند.

## منابع اضافی

برای اطلاعات به‌روزترین درباره بهترین روش‌های MCP، به موارد زیر مراجعه کنید:

- [مستندات MCP](https://modelcontextprotocol.io/)
- [مشخصات MCP](https://spec.modelcontextprotocol.io/)
- [مخزن GitHub](https://github.com/modelcontextprotocol)
- [بهترین روش‌های امنیتی](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## مثال‌های عملی پیاده‌سازی

### بهترین روش‌های طراحی ابزار

#### 1. اصل مسئولیت واحد

هر ابزار MCP باید دارای هدفی واضح و متمرکز باشد. به جای ایجاد ابزارهای یکپارچه که تلاش می‌کنند چندین نگرانی را مدیریت کنند، ابزارهای تخصصی ایجاد کنید که در وظایف خاص برتری دارند.

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

همیشه پارامترها را به دقت اعتبارسنجی کنید تا از ورودی‌های ناقص یا مخرب جلوگیری شود.

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

## بهترین روش‌های آزمایش

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

### 2. آزمایش یکپارچه‌سازی

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
    
    // وابستگی‌ها از طریق سازنده تزریق شده‌اند
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
# مثال پایتون نشان‌دهنده ابزارهای ترکیبی
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
                description = "متن جستجوی پرس‌وجو. از کلمات کلیدی دقیق برای نتایج بهتر استفاده کنید." 
            },
            filters = new {
                type = "object",
                description = "فیلترهای اختیاری برای محدود کردن نتایج جستجو",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "محدوده تاریخ در قالب YYYY-MM-DD:YYYY-MM-DD" 
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
    
    // ویژگی شمارش شده
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
        
        # همیشه یک ساختار ثابت بازگردانید
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
    """اطمینان حاصل کنید که هر آیتم دارای ساختار ثابتی است"""
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
        
        // سایر استثناها را به عنوان ToolExecutionException بازپخش کنید
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
            logging.warning(f"خطای گذرا، تلاش مجدد در {delay}s: {str(e)}")
            await asyncio.sleep(delay)
        except Exception as e:
            # خطای غیر گذرا، تلاش مجدد نکنید
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
        
        // برای عملیات طولانی، شناسه پردازش را فوراً بازگردانید
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
        
        // بازگرداندن پاسخ فوری با شناسه پردازش
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
            if delay > 2.0:  # اگر زمان انتظار خیلی طولانی باشد
                raise ToolExecutionException(
                    f"محدودیت نرخ درخواست‌ها تجاوز کرده است. لطفاً بعد از {delay:.1f} ثانیه دوباره تلاش کنید."
                )
            else:
                # منتظر زمان مناسب بمانید
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
        
        # افزودن توکن‌های جدید بر اساس زمان گذشته
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
        throw new ToolExecutionException("پارامتر query باید از نوع رشته باشد");
    }
    
    var query = queryProp.GetString();
    
    // بررسی محتوای رشته
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("پارامتر query نمی‌تواند خالی باشد");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("پارامتر query از حداکثر طول ۵۰۰ کاراکتر تجاوز کرده است");
    }
    
    // بررسی حملات تزریق SQL در صورت لزوم
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("پرس‌وجوی نامعتبر: شامل SQL ناامن احتمالی است");
    }
    
    // ادامه اجرای ابزار
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
        # ایجاد یک کپی برای جلوگیری از تغییر نسخه اصلی
        redacted = user_data.copy()
        
        # حذف فیلدهای حساس خاص
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # حذف داده‌های حساس تو در تو
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
    tool = ApiTool(timeout=0.1)  # زمان انتظار بسیار کوتاه
    
    # شبیه‌سازی یک درخواست که زمان انتظار را رد می‌کند
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # طولانی‌تر از زمان انتظار
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # اجرا و بررسی
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # بررسی پیام استثنا
        assert "timed out" in str(exc_info.value).lower()

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
            body=json.dumps({"error": "Rate limit exceeded"})
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
```markdown
var result = await workflowExecutor.ExecuteWorkflowAsync(new[] {
    new ToolCall("dataFetch", new { source = "sales2023" }),
    new ToolCall("dataAnalysis", ctx =
> new { 
        data = ctx.GetResult("dataFetch"),
        analysis = "trend" 
    }),
    new ToolCall("dataVisualize", ctx => new {
        analysisResult = ctx.GetResult("dataAnalysis"),
        type = "line-chart"
    })
});

// بررسی
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
        // بررسی نقطه پایانی کشف ابزارها
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // ایجاد درخواست ابزار
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // ارسال درخواست و بررسی پاسخ
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // ایجاد درخواست ابزار نامعتبر
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // پارامتر "b" وجود ندارد
        request.put("parameters", parameters);
        
        // ارسال درخواست و بررسی پاسخ خطا
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
    # آماده‌سازی - تنظیم کلاینت MCP و مدل شبیه‌سازی‌شده
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # پاسخ‌های شبیه‌سازی‌شده مدل
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
    
    # پاسخ شبیه‌سازی‌شده ابزار هواشناسی
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
        
        # اجرا
        response = await mcp_client.send_prompt(
            "What's the weather in Seattle?",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # بررسی
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
    // آماده‌سازی
    var server = new McpServer(
        name: "TestServer",
        version: "1.0",
        maxConcurrentRequests: 100
    );
    
    server.RegisterTool(new FastExecutingTool());
    await server.StartAsync();
    
    var client = new McpClient("http://localhost:5000");
    
    // اجرا
    var tasks = new List<Task<McpResponse>>();
    for (int i = 0; i < 1000; i++)
    {
        tasks.Add(client.ExecuteToolAsync("fastTool", new { iteration = i }));
    }
    
    var results = await Task.WhenAll(tasks);
    
    // بررسی
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
    
    // تنظیم JMeter برای تست فشار
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // پیکربندی برنامه تست JMeter
    HashTree testPlanTree = new HashTree();
    
    // ایجاد برنامه تست، گروه‌های رشته، نمونه‌ها و غیره
    TestPlan testPlan = new TestPlan("MCP Server Stress Test");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // افزودن نمونه HTTP برای اجرای ابزار
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // افزودن شنوندگان
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // اجرای تست
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // اعتبارسنجی نتایج
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // زمان پاسخ متوسط < 200 میلی‌ثانیه
    assertTrue(summaryReport.getPercentile(90.0) < 500); // صدک 90 < 500 میلی‌ثانیه
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# پیکربندی نظارت برای سرور MCP
def configure_monitoring(server):
    # تنظیم معیارهای Prometheus
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "تعداد کل درخواست‌های MCP"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "مدت زمان درخواست به ثانیه",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "تعداد اجرای ابزار",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "مدت زمان اجرای ابزار به ثانیه",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "خطاهای اجرای ابزار",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # افزودن میان‌افزار برای زمان‌بندی و ثبت معیارها
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # نمایش نقطه پایانی معیارها
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
# پیاده‌سازی زنجیره ابزارها در پایتون
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # لیستی از نام ابزارها برای اجرا به ترتیب
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # اجرای هر ابزار در زنجیره با استفاده از نتیجه قبلی
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # ذخیره نتیجه و استفاده به عنوان ورودی ابزار بعدی
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# مثال استفاده
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
    public string Description => "پردازش محتوای انواع مختلف";
    
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
        
        // تعیین ابزار تخصصی برای استفاده
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // ارسال به ابزار تخصصی
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
```
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
            # ابتدا تلاش برای استفاده از ابزار اصلی
            response = await self.client.execute_tool(primary_tool, parameters)
            return {
                "result": response.result,
                "source": "primary",
                "tool": primary_tool
            }
        except ToolExecutionException as e:
            # ثبت شکست ابزار اصلی
            logging.warning(f"ابزار اصلی '{primary_tool}' شکست خورد: {str(e)}")
            
            # استفاده از ابزار جایگزین
            try:
                # ممکن است نیاز به تغییر پارامترها برای ابزار جایگزین باشد
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
                    f"جریان کاری شکست خورد: خطای اصلی: {str(e)}؛ خطای جایگزین: {str(fallback_error)}"
                )
    
    def _adapt_parameters(self, params, from_tool, to_tool):
        """تطبیق پارامترها بین ابزارهای مختلف در صورت نیاز"""
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
    public string Description => "اجرای چندین جریان کاری به صورت متوالی";
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
# مثال تست واحد برای ابزار ماشین‌حساب در پایتون
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
// مثال تست یکپارچه برای سرور MCP در C#
[Fact]
public async Task Server_ProcessToolRequest_ReturnsValidResponse()
{
    // آماده‌سازی
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
    
    // اجرا
    var response = await server.ProcessRequestAsync(request);
    
    // بررسی
    Assert.NotNull(response);
    Assert.Equal(McpStatusCodes.Success, response.StatusCode);
    // بررسی‌های اضافی برای محتوای پاسخ
    
    // پاکسازی
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
// مثال تست E2E با یک کلاینت در TypeScript
describe('MCP Server E2E Tests', () => {
  let client: McpClient;
  
  beforeAll(async () => {
    // راه‌اندازی سرور در محیط تست
    await startTestServer();
    client = new McpClient('http://localhost:5000');
  });
  
  afterAll(async () => {
    await stopTestServer();
  });
  
  test('کلاینت می‌تواند ابزار ماشین‌حساب را فراخوانی کرده و نتیجه صحیح دریافت کند', async () => {
    // اجرا
    const response = await client.invokeToolAsync('calculator', {
      operation: 'divide',
      a: 20,
      b: 4
    });
    
    // بررسی
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
// مثال C# با Moq
var mockModel = new Mock<ILanguageModel>();
mockModel
    .Setup(m => m.GenerateResponseAsync(
        It.IsAny<string>(),
        It.IsAny<McpRequestContext>()))
    .ReturnsAsync(new ModelResponse { 
        Text = "پاسخ مدل شبیه‌سازی‌شده",
        FinishReason = FinishReason.Completed
    });

var server = new McpServer(modelClient: mockModel.Object);
```

```python
# مثال پایتون با unittest.mock
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
    # پیکربندی شبیه‌سازی
    mock_model.return_value.generate_response.return_value = {
        "text": "پاسخ مدل شبیه‌سازی‌شده",
        "finish_reason": "completed"
    }
    
    # استفاده از شبیه‌سازی در تست
    server = McpServer(model_client=mock_model)
    # ادامه تست
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
// اسکریپت k6 برای تست بارگذاری سرور MCP
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  vus: 10,  // ۱۰ کاربر مجازی
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
    'status is 200': (r) => r.status === 200,
    'response time < 500ms': (r) => r.timings.duration < 500,
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
    // آماده‌سازی
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");
    
    // اجرا
    var response = await client.GetAsync("http://localhost:5000/api/resources");
    var content = await response.Content.ReadAsStringAsync();
    var resources = JsonSerializer.Deserialize
<ResourceList>
## ده نکته برتر برای آزمایش مؤثر سرور MCP

1. **تعریف ابزارها را جداگانه آزمایش کنید**: صحت تعریف‌های اسکیمای ابزار را مستقل از منطق ابزار بررسی کنید  
2. **از آزمایش‌های پارامتری استفاده کنید**: ابزارها را با ورودی‌های متنوع، از جمله موارد مرزی، آزمایش کنید  
3. **پاسخ‌های خطا را بررسی کنید**: اطمینان حاصل کنید که خطاها به درستی مدیریت می‌شوند  
4. **منطق مجوزدهی را آزمایش کنید**: دسترسی مناسب برای نقش‌های مختلف کاربران را بررسی کنید  
5. **پوشش آزمایش را نظارت کنید**: پوشش بالای کد مسیرهای حیاتی را هدف قرار دهید  
6. **پاسخ‌های استریم را آزمایش کنید**: مدیریت صحیح محتوای استریم را بررسی کنید  
7. **مشکلات شبکه را شبیه‌سازی کنید**: رفتار سیستم را در شرایط شبکه ضعیف آزمایش کنید  
8. **محدودیت‌های منابع را آزمایش کنید**: رفتار سیستم را هنگام رسیدن به سهمیه‌ها یا محدودیت‌های نرخ بررسی کنید  
9. **آزمایش‌های بازگشتی را خودکار کنید**: مجموعه‌ای بسازید که با هر تغییر کد اجرا شود  
10. **مستندسازی موارد آزمایش**: مستندات واضحی از سناریوهای آزمایش نگه دارید  

## مشکلات رایج در آزمایش

- **تکیه بیش از حد به آزمایش مسیرهای موفقیت‌آمیز**: موارد خطا را به طور کامل آزمایش کنید  
- **نادیده گرفتن آزمایش عملکرد**: گلوگاه‌ها را قبل از تأثیرگذاری بر تولید شناسایی کنید  
- **آزمایش فقط در انزوا**: آزمایش‌های واحد، یکپارچه و انتها به انتها را ترکیب کنید  
- **پوشش ناقص API**: اطمینان حاصل کنید که تمام نقاط پایانی و ویژگی‌ها آزمایش شده‌اند  
- **محیط‌های آزمایش ناسازگار**: از کانتینرها برای اطمینان از محیط‌های آزمایش سازگار استفاده کنید  

## نتیجه‌گیری

یک استراتژی جامع آزمایش برای توسعه سرورهای MCP قابل اعتماد و با کیفیت بالا ضروری است. با اجرای بهترین روش‌ها و نکات مطرح شده در این راهنما، می‌توانید اطمینان حاصل کنید که پیاده‌سازی‌های MCP شما بالاترین استانداردهای کیفیت، قابلیت اطمینان و عملکرد را برآورده می‌کنند.

## نکات کلیدی

1. **طراحی ابزار**: اصل مسئولیت واحد را دنبال کنید، از تزریق وابستگی استفاده کنید و برای ترکیب‌پذیری طراحی کنید  
2. **طراحی اسکیمای ابزار**: اسکیمای واضح و مستند با محدودیت‌های اعتبارسنجی مناسب ایجاد کنید  
3. **مدیریت خطا**: مدیریت خطای مناسب، پاسخ‌های خطای ساختاریافته و منطق تلاش مجدد را پیاده‌سازی کنید  
4. **عملکرد**: از کش، پردازش غیرهمزمان و محدود کردن منابع استفاده کنید  
5. **امنیت**: اعتبارسنجی ورودی، بررسی‌های مجوز و مدیریت داده‌های حساس را به طور کامل اعمال کنید  
6. **آزمایش**: آزمایش‌های واحد، یکپارچه و انتها به انتها جامع ایجاد کنید  
7. **الگوهای جریان کاری**: از الگوهای شناخته‌شده مانند زنجیره‌ها، توزیع‌کننده‌ها و پردازش موازی استفاده کنید  

## تمرین

یک ابزار MCP و جریان کاری برای یک سیستم پردازش اسناد طراحی کنید که:  

1. اسناد را در فرمت‌های مختلف (PDF، DOCX، TXT) بپذیرد  
2. متن و اطلاعات کلیدی را از اسناد استخراج کند  
3. اسناد را بر اساس نوع و محتوا طبقه‌بندی کند  
4. خلاصه‌ای از هر سند تولید کند  

اسکیمای ابزار، مدیریت خطا و یک الگوی جریان کاری که بهترین تناسب را با این سناریو دارد پیاده‌سازی کنید. همچنین در نظر بگیرید که چگونه این پیاده‌سازی را آزمایش خواهید کرد.  

## منابع

1. به جامعه MCP در [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs) بپیوندید تا از آخرین پیشرفت‌ها مطلع شوید  
2. در پروژه‌های متن‌باز [MCP](https://github.com/modelcontextprotocol) مشارکت کنید  
3. اصول MCP را در ابتکارات هوش مصنوعی سازمان خود اعمال کنید  
4. پیاده‌سازی‌های تخصصی MCP را برای صنعت خود بررسی کنید  
5. دوره‌های پیشرفته در موضوعات خاص MCP مانند یکپارچه‌سازی چندوجهی یا یکپارچه‌سازی برنامه‌های سازمانی را در نظر بگیرید  
6. با استفاده از اصول آموخته‌شده از [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) ابزارها و جریان‌های کاری MCP خود را آزمایش کنید  

بعدی: بهترین روش‌ها [مطالعات موردی](../09-CaseStudy/README.md)  

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما تلاش می‌کنیم دقت را حفظ کنیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است شامل خطاها یا نادرستی‌ها باشند. سند اصلی به زبان اصلی آن باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حساس، توصیه می‌شود از ترجمه حرفه‌ای انسانی استفاده کنید. ما مسئولیتی در قبال سوء تفاهم‌ها یا تفسیرهای نادرست ناشی از استفاده از این ترجمه نداریم.