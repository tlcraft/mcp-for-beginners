<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "80e5c8949af5af0f401fce6f905990aa",
  "translation_date": "2025-07-16T23:44:07+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "ur"
}
-->
# MCP کی ترقی کے بہترین طریقے

## جائزہ

یہ سبق MCP سرورز اور فیچرز کو پروڈکشن ماحول میں تیار کرنے، ٹیسٹ کرنے، اور تعینات کرنے کے جدید بہترین طریقوں پر مرکوز ہے۔ جیسے جیسے MCP کے ماحولیاتی نظام کی پیچیدگی اور اہمیت بڑھتی ہے، قائم شدہ نمونوں پر عمل کرنا اعتماد، برقرار رکھنے کی سہولت، اور باہمی تعامل کو یقینی بناتا ہے۔ یہ سبق حقیقی دنیا کی MCP تنصیبات سے حاصل شدہ عملی حکمت کو یکجا کرتا ہے تاکہ آپ کو مضبوط، مؤثر سرورز بنانے میں رہنمائی فراہم کی جا سکے جن میں مؤثر وسائل، پرامپٹس، اور ٹولز شامل ہوں۔

## سیکھنے کے مقاصد

اس سبق کے اختتام تک، آپ قابل ہوں گے کہ:
- MCP سرور اور فیچر ڈیزائن میں صنعت کے بہترین طریقے اپنائیں
- MCP سرورز کے لیے جامع ٹیسٹنگ حکمت عملی تیار کریں
- پیچیدہ MCP ایپلیکیشنز کے لیے مؤثر، دوبارہ استعمال ہونے والے ورک فلو پیٹرنز ڈیزائن کریں
- MCP سرورز میں مناسب ایرر ہینڈلنگ، لاگنگ، اور آبزرویبیلٹی نافذ کریں
- کارکردگی، سیکیورٹی، اور برقرار رکھنے کی سہولت کے لیے MCP کی تنصیبات کو بہتر بنائیں

## MCP کے بنیادی اصول

مخصوص نفاذی طریقوں میں غوطہ لگانے سے پہلے، یہ سمجھنا ضروری ہے کہ مؤثر MCP ترقی کی رہنمائی کرنے والے بنیادی اصول کیا ہیں:

1. **معیاری مواصلات**: MCP JSON-RPC 2.0 کو بنیاد کے طور پر استعمال کرتا ہے، جو تمام نفاذات میں درخواستوں، جوابات، اور ایرر ہینڈلنگ کے لیے ایک مستقل فارمیٹ فراہم کرتا ہے۔

2. **صارف مرکزیت ڈیزائن**: ہمیشہ اپنے MCP نفاذات میں صارف کی رضامندی، کنٹرول، اور شفافیت کو ترجیح دیں۔

3. **سیکیورٹی کو اولین ترجیح**: مضبوط سیکیورٹی اقدامات نافذ کریں جن میں تصدیق، اجازت، توثیق، اور ریٹ لمٹنگ شامل ہیں۔

4. **ماڈیولر فن تعمیر**: اپنے MCP سرورز کو ماڈیولر انداز میں ڈیزائن کریں، جہاں ہر ٹول اور وسیلہ کا واضح اور مخصوص مقصد ہو۔

5. **حالت دار کنکشنز**: متعدد درخواستوں کے دوران حالت برقرار رکھنے کی MCP کی صلاحیت سے فائدہ اٹھائیں تاکہ زیادہ مربوط اور سیاق و سباق سے آگاہ تعاملات ممکن ہوں۔

## سرکاری MCP بہترین طریقے

مندرجہ ذیل بہترین طریقے سرکاری Model Context Protocol دستاویزات سے ماخوذ ہیں:

### سیکیورٹی کے بہترین طریقے

1. **صارف کی رضامندی اور کنٹرول**: ڈیٹا تک رسائی یا آپریشنز انجام دینے سے پہلے ہمیشہ واضح صارف کی رضامندی حاصل کریں۔ واضح کنٹرول فراہم کریں کہ کون سا ڈیٹا شیئر کیا جا رہا ہے اور کون سے اقدامات کی اجازت ہے۔

2. **ڈیٹا کی رازداری**: صرف واضح رضامندی کے ساتھ صارف کا ڈیٹا ظاہر کریں اور مناسب رسائی کنٹرولز کے ذریعے اس کی حفاظت کریں۔ غیر مجاز ڈیٹا کی ترسیل سے بچاؤ کریں۔

3. **ٹول کی حفاظت**: کسی بھی ٹول کو چلانے سے پہلے واضح صارف کی رضامندی ضروری ہے۔ یقینی بنائیں کہ صارف ہر ٹول کی فعالیت کو سمجھتا ہے اور مضبوط سیکیورٹی حدود نافذ کریں۔

4. **ٹول اجازت کنٹرول**: سیشن کے دوران ماڈل کو کن ٹولز کے استعمال کی اجازت ہے، اس کی ترتیب دیں تاکہ صرف واضح طور پر مجاز ٹولز قابل رسائی ہوں۔

5. **تصدیق**: ٹولز، وسائل، یا حساس آپریشنز تک رسائی دینے سے پہلے مناسب تصدیق ضروری ہے، جیسے API کیز، OAuth ٹوکنز، یا دیگر محفوظ تصدیقی طریقے۔

6. **پیرا میٹر کی توثیق**: تمام ٹول کالز کے لیے توثیق نافذ کریں تاکہ خراب یا نقصان دہ ان پٹ کو ٹول نفاذات تک پہنچنے سے روکا جا سکے۔

7. **ریٹ لمٹنگ**: بدسلوکی کو روکنے اور سرور وسائل کے منصفانہ استعمال کو یقینی بنانے کے لیے ریٹ لمٹنگ نافذ کریں۔

### نفاذ کے بہترین طریقے

1. **صلاحیت کی گفت و شنید**: کنکشن قائم کرتے وقت، سپورٹ شدہ فیچرز، پروٹوکول ورژنز، دستیاب ٹولز، اور وسائل کی معلومات کا تبادلہ کریں۔

2. **ٹول ڈیزائن**: ایسے ٹولز بنائیں جو ایک کام کو بخوبی انجام دیں، بجائے اس کے کہ ایک ہی ٹول متعدد مسائل کو سنبھالے۔

3. **ایرر ہینڈلنگ**: معیاری ایرر پیغامات اور کوڈز نافذ کریں تاکہ مسائل کی تشخیص میں مدد ملے، ناکامیوں کو نرمی سے سنبھالا جا سکے، اور قابل عمل فیڈبیک فراہم کیا جا سکے۔

4. **لاگنگ**: آڈٹ، ڈیبگنگ، اور پروٹوکول تعاملات کی نگرانی کے لیے منظم لاگز ترتیب دیں۔

5. **پروگریس ٹریکنگ**: طویل مدتی آپریشنز کے لیے، پیش رفت کی تازہ کاری رپورٹ کریں تاکہ صارف کے انٹرفیس کو جوابدہ بنایا جا سکے۔

6. **درخواست منسوخی**: کلائنٹس کو اجازت دیں کہ وہ ایسے جاری درخواستوں کو منسوخ کر سکیں جو اب ضروری نہیں یا بہت زیادہ وقت لے رہی ہوں۔

## اضافی حوالہ جات

MCP کے بہترین طریقوں کے بارے میں تازہ ترین معلومات کے لیے رجوع کریں:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)
- [Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## عملی نفاذ کی مثالیں

### ٹول ڈیزائن کے بہترین طریقے

#### 1. واحد ذمہ داری کا اصول

ہر MCP ٹول کا ایک واضح اور مخصوص مقصد ہونا چاہیے۔ ایسے ٹولز بنائیں جو ایک خاص کام میں مہارت رکھتے ہوں، بجائے اس کے کہ ایک ہی ٹول متعدد مسائل کو سنبھالنے کی کوشش کرے۔

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

#### 2. مستقل ایرر ہینڈلنگ

مضبوط ایرر ہینڈلنگ نافذ کریں جس میں معلوماتی ایرر پیغامات اور مناسب بازیابی کے طریقے شامل ہوں۔

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

#### 3. پیرا میٹر کی توثیق

ہمیشہ پیرا میٹرز کی مکمل جانچ کریں تاکہ خراب یا نقصان دہ ان پٹ کو روکا جا سکے۔

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

### سیکیورٹی نفاذ کی مثالیں

#### 1. تصدیق اور اجازت

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

#### 2. ریٹ لمٹنگ

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

## ٹیسٹنگ کے بہترین طریقے

### 1. MCP ٹولز کی یونٹ ٹیسٹنگ

ہمیشہ اپنے ٹولز کو الگ تھلگ ٹیسٹ کریں، بیرونی انحصارات کو موک کریں:

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

### 2. انٹیگریشن ٹیسٹنگ

کلائنٹ کی درخواستوں سے لے کر سرور کے جوابات تک مکمل عمل کی جانچ کریں:

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

## کارکردگی کی بہتری

### 1. کیشنگ کی حکمت عملیاں

تاخیر اور وسائل کے استعمال کو کم کرنے کے لیے مناسب کیشنگ نافذ کریں:

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
// Java مثال جس میں dependency injection استعمال ہوئی ہے
public class CurrencyConversionTool implements Tool {
    private final ExchangeRateService exchangeService;
    private final CacheService cacheService;
    private final Logger logger;
    
    // کنسٹرکٹر کے ذریعے انحصارات فراہم کیے گئے
    public CurrencyConversionTool(
            ExchangeRateService exchangeService,
            CacheService cacheService,
            Logger logger) {
        this.exchangeService = exchangeService;
        this.cacheService = cacheService;
        this.logger = logger;
    }
    
    // ٹول کا نفاذ
    // ...
}
```

#### 3. Composable Tools

Design tools that can be composed together to create more complex workflows:

```python
# Python کی مثال جو کمپوز ایبل ٹولز دکھاتی ہے
class DataFetchTool(Tool):
    def get_name(self):
        return "dataFetch"
    
    # نفاذ...

class DataAnalysisTool(Tool):
    def get_name(self):
        return "dataAnalysis"
    
    # یہ ٹول dataFetch ٹول کے نتائج استعمال کر سکتا ہے
    async def execute_async(self, request):
        # نفاذ...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # یہ ٹول dataAnalysis ٹول کے نتائج استعمال کر سکتا ہے
    async def execute_async(self, request):
        # نفاذ...
        pass

# یہ ٹولز آزادانہ یا ورک فلو کے حصے کے طور پر استعمال کیے جا سکتے ہیں
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
                description = "تلاش کے لیے متن۔ بہتر نتائج کے لیے درست کلیدی الفاظ استعمال کریں۔" 
            },
            filters = new {
                type = "object",
                description = "اختیاری فلٹرز جو تلاش کے نتائج کو محدود کرتے ہیں",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "تاریخ کی حد فارمیٹ YYYY-MM-DD:YYYY-MM-DD" 
                    },
                    category = new { 
                        type = "string", 
                        description = "فلٹر کرنے کے لیے زمرہ کا نام" 
                    }
                }
            },
            limit = new { 
                type = "integer", 
                description = "واپس کیے جانے والے نتائج کی زیادہ سے زیادہ تعداد (1-50)",
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
    
    // ای میل پراپرٹی جس میں فارمیٹ کی توثیق شامل ہے
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "صارف کا ای میل پتہ");
    
    // عمر کی پراپرٹی جس میں عددی حدود ہیں
    Map<String, Object> age = new HashMap<>();
    age.put("type", "integer");
    age.put("minimum", 13);
    age.put("maximum", 120);
    age.put("description", "صارف کی عمر سالوں میں");
    
    // متعین کردہ پراپرٹی
    Map<String, Object> subscription = new HashMap<>();
    subscription.put("type", "string");
    subscription.put("enum", Arrays.asList("free", "basic", "premium"));
    subscription.put("default", "free");
    subscription.put("description", "سبسکرپشن کی سطح");
    
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
        # درخواست پر عمل کریں
        results = await self._search_database(request.parameters["query"])
        
        # ہمیشہ ایک مستقل ساخت واپس کریں
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
    """یقینی بنائیں کہ ہر آئٹم کی ساخت مستقل ہو"""
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
            throw new ToolExecutionException($"فائل نہیں ملی: {fileId}");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ToolExecutionException("آپ کو اس فائل تک رسائی کی اجازت نہیں ہے");
        }
        catch (Exception ex) when (ex is IOException || ex is TimeoutException)
        {
            _logger.LogError(ex, "فائل تک رسائی میں خرابی {FileId}", fileId);
            throw new ToolExecutionException("فائل تک رسائی میں خرابی: سروس عارضی طور پر دستیاب نہیں ہے");
        }
    }
    catch (JsonException)
    {
        throw new ToolExecutionException("فائل ID کا فارمیٹ غلط ہے");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "FileAccessTool میں غیر متوقع خرابی");
        throw new ToolExecutionException("ایک غیر متوقع خرابی پیش آئی");
    }
}
```

#### 2. Structured Error Responses

Return structured error information when possible:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    try {
        // نفاذ
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
        
        // دیگر استثنات کو ToolExecutionException کے طور پر دوبارہ پھینکیں
        throw new ToolExecutionException("ٹول کی عمل کاری ناکام رہی: " + ex.getMessage(), ex);
    }
}
```

#### 3. Retry Logic

Implement appropriate retry logic for transient failures:

```python
async def execute_async(self, request):
    max_retries = 3
    retry_count = 0
    base_delay = 1  # سیکنڈ
    
    while retry_count < max_retries:
        try:
            # بیرونی API کال کریں
            return await self._call_api(request.parameters)
        except TransientError as e:
            retry_count += 1
            if retry_count >= max_retries:
                raise ToolExecutionException(f"{max_retries} کوششوں کے بعد آپریشن ناکام: {str(e)}")
                
            # نمایاں تاخیر کے ساتھ دوبارہ کوشش
            delay = base_delay * (2 ** (retry_count - 1))
            logging.warning(f"عارضی خرابی، {delay} سیکنڈ بعد دوبارہ کوشش: {str(e)}")
            await asyncio.sleep(delay)
        except Exception as e:
            # غیر عارضی خرابی، دوبارہ کوشش نہ کریں
            raise ToolExecutionException(f"آپریشن ناکام: {str(e)}")
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
براہ کرم اس متن کا ترجمہ اردو میں کریں۔  
</ToolResponse>
ExecuteAsync(ToolRequest request)
    {
        var query = request.Parameters.GetProperty("query").GetString();
        
        // پیرامیٹرز کی بنیاد پر کیش کی کلید بنائیں
        var cacheKey = $"data_query_{ComputeHash(query)}";
        
        // پہلے کیش سے حاصل کرنے کی کوشش کریں
        if (_cache.TryGetValue(cacheKey, out var cachedResult))
        {
            return new ToolResponse { Result = cachedResult };
        }
        
        // کیش میں نہ ملنے پر اصل سوال کریں
        var result = await _database.QueryAsync(query);
        
        // میعاد ختم ہونے کے ساتھ کیش میں محفوظ کریں
        var cacheOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
            
        _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
        
        return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
    }
    
    private string ComputeHash(string input)
    {
        // کیش کی کلید کے لیے مستحکم ہیش بنانے کا نفاذ
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
        
        // طویل عمل کے لیے فوری طور پر ایک پراسیس ID واپس کریں
        String processId = UUID.randomUUID().toString();
        
        // غیر متزامن پراسیسنگ شروع کریں
        CompletableFuture.runAsync(() -> {
            try {
                // طویل عمل انجام دیں
                documentService.processDocument(documentId);
                
                // اسٹیٹس اپ ڈیٹ کریں (عام طور پر ڈیٹا بیس میں محفوظ کیا جاتا ہے)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // پراسیس ID کے ساتھ فوری جواب واپس کریں
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // ہمراہ اسٹیٹس چیک کرنے کا ٹول
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
            tokens_per_second=5,  # فی سیکنڈ 5 درخواستیں اجازت دیں
            bucket_size=10        # 10 درخواستوں تک اچانک اضافہ کی اجازت
        )
    
    async def execute_async(self, request):
        # چیک کریں کہ کیا ہم آگے بڑھ سکتے ہیں یا انتظار کرنا ہوگا
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # اگر انتظار بہت زیادہ ہو
                raise ToolExecutionException(
                    f"Rate limit exceeded. Please try again in {delay:.1f} seconds."
                )
            else:
                # مناسب تاخیر کے لیے انتظار کریں
                await asyncio.sleep(delay)
        
        # ایک ٹوکن استعمال کریں اور درخواست جاری رکھیں
        self.rate_limiter.consume()
        
        # API کال کریں
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
            
            # اگلے دستیاب ٹوکن تک کا وقت حساب کریں
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # گزرے ہوئے وقت کی بنیاد پر نئے ٹوکن شامل کریں
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
    // تصدیق کریں کہ پیرامیٹرز موجود ہیں
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("ضروری پیرامیٹر غائب ہے: query");
    }
    
    // درست قسم کی تصدیق کریں
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("Query پیرامیٹر کو سٹرنگ ہونا چاہیے");
    }
    
    var query = queryProp.GetString();
    
    // سٹرنگ کے مواد کی تصدیق کریں
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("Query پیرامیٹر خالی نہیں ہو سکتا");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("Query پیرامیٹر کی زیادہ سے زیادہ لمبائی 500 حروف ہے");
    }
    
    // SQL انجیکشن حملوں کی جانچ کریں اگر قابل اطلاق ہو
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("غلط سوال: ممکنہ طور پر غیر محفوظ SQL شامل ہے");
    }
    
    // عملدرآمد جاری رکھیں
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // درخواست سے صارف کا سیاق و سباق حاصل کریں
    UserContext user = request.getContext().getUserContext();
    
    // چیک کریں کہ صارف کے پاس مطلوبہ اجازت ہے
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("صارف کو دستاویزات تک رسائی کی اجازت نہیں ہے");
    }
    
    // مخصوص وسائل کے لیے، اس وسائل تک رسائی چیک کریں
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("درخواست کردہ دستاویز تک رسائی سے انکار");
    }
    
    // ٹول کے عملدرآمد کے ساتھ آگے بڑھیں
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
        
        # صارف کا ڈیٹا حاصل کریں
        user_data = await self.user_service.get_user_data(user_id)
        
        # حساس فیلڈز کو فلٹر کریں جب تک کہ واضح طور پر درخواست نہ کی گئی ہو اور اجازت نہ ہو
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # درخواست کے سیاق و سباق میں اجازت کی سطح چیک کریں
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # اصل کو تبدیل کرنے سے بچنے کے لیے کاپی بنائیں
        redacted = user_data.copy()
        
        # مخصوص حساس فیلڈز کو چھپائیں
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # اندرونی حساس ڈیٹا کو چھپائیں
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
    // ترتیب دیں
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("Seattle", 3))
        .ReturnsAsync(new WeatherForecast(/* ٹیسٹ ڈیٹا */));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "Seattle", 
            days = 3 
        })
    );
    
    // عمل کریں
    var response = await tool.ExecuteAsync(request);
    
    // تصدیق کریں
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // ترتیب دیں
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("InvalidLocation", It.IsAny<int>()))
        .ThrowsAsync(new LocationNotFoundException("Location not found"));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "InvalidLocation", 
            days = 3 
        })
    );
    
    // عمل اور تصدیق
    var exception = await Assert.ThrowsAsync<ToolExecutionException>(
        () => tool.ExecuteAsync(request)
    );
    
    Assert.Contains("Location not found", exception.Message);
}
```

#### 2. Schema Validation Testing

Test that schemas are valid and properly enforce constraints:

```java
@Test
public void testSchemaValidation() {
    // ٹول کی مثال بنائیں
    SearchTool searchTool = new SearchTool();
    
    // اسکیمہ حاصل کریں
    Object schema = searchTool.getSchema();
    
    // اسکیمہ کو JSON میں تبدیل کریں تاکہ تصدیق کی جا سکے
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // اسکیمہ کی درستگی کی تصدیق کریں کہ یہ JSONSchema ہے
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // درست پیرامیٹرز کا ٹیسٹ کریں
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // ضروری پیرامیٹر کے بغیر ٹیسٹ کریں
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // غلط قسم کے پیرامیٹر کا ٹیسٹ کریں
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
    # ترتیب دیں
    tool = ApiTool(timeout=0.1)  # بہت کم وقت
    
    # ایسی درخواست کا موک بنائیں جو وقت ختم کر دے
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # وقت سے زیادہ دیر
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # عمل اور تصدیق
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # استثناء کے پیغام کی تصدیق کریں
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # ترتیب دیں
    tool = ApiTool()
    
    # ریٹ محدود جواب کا موک بنائیں
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
        
        # عمل اور تصدیق
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # استثناء میں ریٹ لمٹ کی معلومات کی تصدیق کریں
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
    // ترتیب دیں
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // عمل کریں
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

// تصدیق کریں
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
        // دریافت اینڈ پوائنٹ کا ٹیسٹ کریں
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // ٹول کی درخواست بنائیں
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // درخواست بھیجیں اور جواب کی تصدیق کریں
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // غلط ٹول کی درخواست بنائیں
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // "b" پیرامیٹر غائب ہے
        request.put("parameters", parameters);
        
        // درخواست بھیجیں اور ایرر جواب کی تصدیق کریں
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
    # ترتیب دیں - MCP کلائنٹ اور ماڈل کا موک بنائیں
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # ماڈل کے جوابات کا موک بنائیں
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
    
    # موسم کے ٹول کا موک جواب
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
        
        # عمل کریں
        response = await mcp_client.send_prompt(
            "What's the weather in Seattle?",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # تصدیق کریں
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
    // ترتیب دیں
    var server = new McpServer(
        name: "TestServer",
        version: "1.0",
        maxConcurrentRequests: 100
    );
    
    server.RegisterTool(new FastExecutingTool());
    await server.StartAsync();
    
    var client = new McpClient("http://localhost:5000");
    
    // عمل کریں
    var tasks = new List<Task<McpResponse>>();
    for (int i = 0; i < 1000; i++)
    {
        tasks.Add(client.ExecuteToolAsync("fastTool", new { iteration = i }));
    }
    
    var results = await Task.WhenAll(tasks);
    
    // تصدیق کریں
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
    
    // JMeter کو اسٹریس ٹیسٹنگ کے لیے ترتیب دیں
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // JMeter ٹیسٹ پلان ترتیب دیں
    HashTree testPlanTree = new HashTree();
    
    // ٹیسٹ پلان، تھریڈ گروپ، سیمپلرز وغیرہ بنائیں
    TestPlan testPlan = new TestPlan("MCP Server Stress Test");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // ٹول کے عملدرآمد کے لیے HTTP سیمپلر شامل کریں
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // لسنرز شامل کریں
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // ٹیسٹ چلائیں
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // نتائج کی تصدیق کریں
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // اوسط ردعمل کا وقت 200ms سے کم
    assertTrue(summaryReport.getPercentile(90.0) < 500); // 90واں پرسنٹائل 500ms سے کم
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# MCP سرور کے لیے مانیٹرنگ ترتیب دیں
def configure_monitoring(server):
    # Prometheus میٹرکس ترتیب دیں
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "کل MCP درخواستیں"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "درخواست کا دورانیہ سیکنڈز میں",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "ٹول کے عملدرآمد کی تعداد",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "ٹول کے عملدرآمد کا دورانیہ سیکنڈز میں",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "ٹول کے عملدرآمد کی غلطیاں",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # وقت ناپنے اور میٹرکس ریکارڈ کرنے کے لیے مڈل ویئر شامل کریں
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # میٹرکس اینڈ پوائنٹ کو ظاہر کریں
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
# Python میں Chain of Tools کی عملدرآمد
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # ٹولز کی فہرست جو ترتیب سے چلانی ہے
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # ہر ٹول کو چلائیں، پچھلے نتیجے کو ان پٹ کے طور پر دیں
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # نتیجہ محفوظ کریں اور اگلے ٹول کے لیے ان پٹ بنائیں
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# مثال کے طور پر استعمال
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
    public string Description => "مختلف اقسام کے مواد کو پروسیس کرتا ہے";
    
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
        
        // فیصلہ کریں کہ کون سا مخصوص ٹول استعمال کرنا ہے
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // مخصوص ٹول کو فارورڈ کریں
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
# اہم قواعد:
1. ترجمے کے ارد گرد '''markdown یا کوئی اور ٹیگز نہ لگائیں
2. ترجمہ بہت لفظ بہ لفظ نہ ہو
3. تبصروں کا بھی ترجمہ کریں
4. یہ فائل Markdown فارمیٹ میں ہے - اسے XML یا HTML نہ سمجھیں
5. ترجمہ نہ کریں:
   - [!NOTE], [!WARNING], [!TIP], [!IMPORTANT], [!CAUTION]
   - Variable names, function names, class names
   - @@INLINE_CODE_x@@ یا @@CODE_BLOCK_x@@ جیسے پلیس ہولڈرز
   - URLs یا راستے
6. تمام اصل markdown فارمیٹنگ کو برقرار رکھیں
7. صرف ترجمہ شدہ مواد واپس کریں، بغیر کسی اضافی ٹیگز یا مارک اپ کے
("code", _) => "codeAnalyzer",
            _ => throw new ToolExecutionException($"کوئی ٹول دستیاب نہیں ہے {contentType}/{operation} کے لیے")
        };
    }
    
    private object GetOptionsForTool(string toolName, string operation)
    {
        // ہر مخصوص ٹول کے لیے مناسب اختیارات واپس کریں
        return toolName switch
        {
            "textSummarizer" => new { length = "medium" },
            "htmlProcessor" => new { cleanUp = true, operation },
            // دیگر ٹولز کے اختیارات...
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
        // مرحلہ 1: ڈیٹاسیٹ میٹا ڈیٹا حاصل کریں (ہم وقت)
        ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata", 
            Map.of("datasetId", datasetId));
        
        // مرحلہ 2: متعدد تجزیے بیک وقت شروع کریں
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
        
        // تمام متوازی کاموں کے مکمل ہونے کا انتظار کریں
        CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
            statisticalAnalysis, correlationAnalysis, outlierDetection
        );
        
        allAnalyses.join();  // مکمل ہونے تک انتظار کریں
        
        // مرحلہ 3: نتائج کو یکجا کریں
        Map<String, Object> combinedResults = new HashMap<>();
        combinedResults.put("metadata", metadataResponse.getResult());
        combinedResults.put("statistics", statisticalAnalysis.join().getResult());
        combinedResults.put("correlations", correlationAnalysis.join().getResult());
        combinedResults.put("outliers", outlierDetection.join().getResult());
        
        // مرحلہ 4: خلاصہ رپورٹ تیار کریں
        ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator", 
            Map.of("analysisResults", combinedResults));
        
        // مکمل ورک فلو کا نتیجہ واپس کریں
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
            # پہلے پرائمری ٹول آزمائیں
            response = await self.client.execute_tool(primary_tool, parameters)
            return {
                "result": response.result,
                "source": "primary",
                "tool": primary_tool
            }
        except ToolExecutionException as e:
            # ناکامی کو لاگ کریں
            logging.warning(f"پرائمری ٹول '{primary_tool}' ناکام رہا: {str(e)}")
            
            # سیکنڈری ٹول پر منتقل ہوں
            try:
                # ممکن ہے کہ fallback ٹول کے لیے پیرامیٹرز تبدیل کرنے کی ضرورت ہو
                fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)
                
                response = await self.client.execute_tool(fallback_tool, fallback_params)
                return {
                    "result": response.result,
                    "source": "fallback",
                    "tool": fallback_tool,
                    "primaryError": str(e)
                }
            except ToolExecutionException as fallback_error:
                # دونوں ٹولز ناکام ہوگئے
                logging.error(f"دونوں پرائمری اور fallback ٹولز ناکام رہے۔ fallback کی خرابی: {str(fallback_error)}")
                raise WorkflowExecutionException(
                    f"ورک فلو ناکام رہا: پرائمری خرابی: {str(e)}؛ fallback خرابی: {str(fallback_error)}"
                )
    
    def _adapt_parameters(self, params, from_tool, to_tool):
        """اگر ضرورت ہو تو مختلف ٹولز کے درمیان پیرامیٹرز کو ایڈجسٹ کریں"""
        # یہ عمل مخصوص ٹولز پر منحصر ہوگا
        # اس مثال میں، ہم اصل پیرامیٹرز ہی واپس کر رہے ہیں
        return params

# مثال کے طور پر استعمال
async def get_weather(workflow, location):
    return await workflow.execute_with_fallback(
        "premiumWeatherService",  # پرائمری (ادائیگی والا) موسم کا API
        "basicWeatherService",    # fallback (مفت) موسم کا API
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
            
            // ہر ورک فلو کے نتیجے کو محفوظ کریں
            results[workflow.Name] = workflowResult;
            
            // اگلے ورک فلو کے لیے سیاق و سباق کو نتیجے کے ساتھ اپ ڈیٹ کریں
            context = context.WithResult(workflow.Name, workflowResult);
        }
        
        return new WorkflowResult(results);
    }
    
    public string Name => "CompositeWorkflow";
    public string Description => "متعدد ورک فلو کو ترتیب وار چلائیں";
}

// مثال کے طور پر استعمال
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
// C# میں کیلکولیٹر ٹول کے لیے مثال یونٹ ٹیسٹ
[Fact]
public async Task CalculatorTool_Add_ReturnsCorrectSum()
{
    // ترتیب دیں
    var calculator = new CalculatorTool();
    var parameters = new Dictionary<string, object>
    {
        ["operation"] = "add",
        ["a"] = 5,
        ["b"] = 7
    };
    
    // عمل کریں
    var response = await calculator.ExecuteAsync(parameters);
    var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());
    
    // تصدیق کریں
    Assert.Equal(12, result.Value);
}
```

```python
# Python میں کیلکولیٹر ٹول کے لیے مثال یونٹ ٹیسٹ
def test_calculator_tool_add():
    # ترتیب دیں
    calculator = CalculatorTool()
    parameters = {
        "operation": "add",
        "a": 5,
        "b": 7
    }
    
    # عمل کریں
    response = calculator.execute(parameters)
    result = json.loads(response.content[0].text)
    
    # تصدیق کریں
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
// C# میں MCP سرور کے لیے مثال انٹیگریشن ٹیسٹ
[Fact]
public async Task Server_ProcessToolRequest_ReturnsValidResponse()
{
    // ترتیب دیں
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
    
    // عمل کریں
    var response = await server.ProcessRequestAsync(request);
    
    // تصدیق کریں
    Assert.NotNull(response);
    Assert.Equal(McpStatusCodes.Success, response.StatusCode);
    // جواب کے مواد کے لیے اضافی تصدیقات
    
    // صفائی کریں
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
// TypeScript میں کلائنٹ کے ساتھ E2E ٹیسٹ کی مثال
describe('MCP Server E2E Tests', () => {
  let client: McpClient;
  
  beforeAll(async () => {
    // ٹیسٹ ماحول میں سرور شروع کریں
    await startTestServer();
    client = new McpClient('http://localhost:5000');
  });
  
  afterAll(async () => {
    await stopTestServer();
  });
  
  test('کلائنٹ کیلکولیٹر ٹول کو کال کر کے درست نتیجہ حاصل کر سکتا ہے', async () => {
    // عمل کریں
    const response = await client.invokeToolAsync('calculator', {
      operation: 'divide',
      a: 20,
      b: 4
    });
    
    // تصدیق کریں
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
// C# میں Moq کے ساتھ مثال
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
# Python میں unittest.mock کے ساتھ مثال
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
    # موک کو ترتیب دیں
    mock_model.return_value.generate_response.return_value = {
        "text": "Mocked model response",
        "finish_reason": "completed"
    }
    
    # ٹیسٹ میں موک کا استعمال کریں
    server = McpServer(model_client=mock_model)
    # ٹیسٹ جاری رکھیں
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
// MCP سرور کے لیے لوڈ ٹیسٹنگ کا k6 اسکرپٹ
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  vus: 10,  // 10 ورچوئل یوزرز
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
    // ترتیب دیں
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");
    
    // عمل کریں
    var response = await client.GetAsync("http://localhost:5000/api/resources");
    var content = await response.Content.ReadAsStringAsync();
    var resources = JsonSerializer.Deserialize
<ResourceList>
// Assert  
Assert.Equal(HttpStatusCode.OK, response.StatusCode);  
Assert.NotNull(resources);  
Assert.All(resources.Resources, resource =>  
{  
    Assert.NotNull(resource.Id);  
    Assert.NotNull(resource.Type);  
    // اضافی اسکیمہ کی تصدیق  
});  
}  
```

## موثر MCP سرور ٹیسٹنگ کے لیے ٹاپ 10 تجاویز

1. **ٹیسٹ ٹول کی تعریفات کو الگ سے جانچیں**: اسکیمہ کی تعریفات کو ٹول کی منطق سے الگ تصدیق کریں  
2. **پیرا میٹرائزڈ ٹیسٹس استعمال کریں**: مختلف ان پٹس بشمول ایج کیسز کے ساتھ ٹولز کی جانچ کریں  
3. **ایرر ریسپانسز چیک کریں**: تمام ممکنہ غلطی کی حالتوں کے لیے مناسب ایرر ہینڈلنگ کی تصدیق کریں  
4. **اتھارائزیشن لاجک کی جانچ کریں**: مختلف یوزر رولز کے لیے مناسب رسائی کنٹرول کو یقینی بنائیں  
5. **ٹیسٹ کوریج کی نگرانی کریں**: اہم راستے کے کوڈ کی زیادہ سے زیادہ کوریج کا ہدف رکھیں  
6. **اسٹریمنگ ریسپانسز کی جانچ کریں**: اسٹریمنگ مواد کی مناسب ہینڈلنگ کی تصدیق کریں  
7. **نیٹ ورک مسائل کی نقل کریں**: خراب نیٹ ورک حالات میں رویے کی جانچ کریں  
8. **ریسورس کی حدوں کی جانچ کریں**: کوٹاز یا ریٹ لمٹس تک پہنچنے پر رویے کی تصدیق کریں  
9. **ریگریشن ٹیسٹس کو خودکار بنائیں**: ہر کوڈ تبدیلی پر چلنے والا ٹیسٹ سوئٹ تیار کریں  
10. **ٹیسٹ کیسز کی دستاویزات بنائیں**: ٹیسٹ سیناریوز کی واضح دستاویزات رکھیں  

## عام ٹیسٹنگ کی غلطیاں

- **صرف خوشگوار راستے کی جانچ پر انحصار**: غلطی کے کیسز کو مکمل طور پر جانچنا یقینی بنائیں  
- **کارکردگی کی جانچ کو نظر انداز کرنا**: پیداواری اثرات سے پہلے رکاوٹوں کی نشاندہی کریں  
- **صرف تنہا ٹیسٹنگ کرنا**: یونٹ، انٹیگریشن، اور اینڈ ٹو اینڈ ٹیسٹس کو ملائیں  
- **نامکمل API کوریج**: تمام اینڈ پوائنٹس اور فیچرز کی جانچ یقینی بنائیں  
- **غیر مستقل ٹیسٹ ماحول**: مستقل ٹیسٹ ماحول کے لیے کنٹینرز استعمال کریں  

## نتیجہ

ایک جامع ٹیسٹنگ حکمت عملی قابل اعتماد، اعلیٰ معیار کے MCP سرورز کی ترقی کے لیے ضروری ہے۔ اس گائیڈ میں دی گئی بہترین طریقہ کار اور تجاویز کو اپنانے سے آپ کی MCP امپلیمنٹیشنز معیار، اعتماد، اور کارکردگی کے اعلیٰ ترین معیار پر پورا اتریں گی۔  

## اہم نکات

1. **ٹول ڈیزائن**: سنگل ریسپانسبلٹی اصول پر عمل کریں، dependency injection استعمال کریں، اور composability کے لیے ڈیزائن کریں  
2. **اسکیمہ ڈیزائن**: واضح، اچھی دستاویزی اسکیمہ بنائیں جن میں مناسب validation constraints ہوں  
3. **ایرر ہینڈلنگ**: نرم اور منظم ایرر ہینڈلنگ، ساختہ ایرر ریسپانسز، اور ریٹری لاجک نافذ کریں  
4. **کارکردگی**: کیشنگ، asynchronous پروسیسنگ، اور resource throttling استعمال کریں  
5. **سیکیورٹی**: مکمل ان پٹ ویلیڈیشن، authorization چیکس، اور حساس ڈیٹا کی حفاظت کریں  
6. **ٹیسٹنگ**: جامع یونٹ، انٹیگریشن، اور اینڈ ٹو اینڈ ٹیسٹس بنائیں  
7. **ورک فلو پیٹرنز**: معروف پیٹرنز جیسے chains، dispatchers، اور parallel processing اپنائیں  

## مشق

ایک MCP ٹول اور ورک فلو ڈیزائن کریں جو دستاویزات کے پروسیسنگ سسٹم کے لیے ہو جو:

1. مختلف فارمیٹس (PDF, DOCX, TXT) میں دستاویزات قبول کرے  
2. دستاویزات سے متن اور اہم معلومات نکالے  
3. دستاویزات کو قسم اور مواد کے لحاظ سے درجہ بندی کرے  
4. ہر دستاویز کا خلاصہ تیار کرے  

ٹول اسکیمہ، ایرر ہینڈلنگ، اور اس منظر نامے کے لیے موزوں ورک فلو پیٹرن نافذ کریں۔ اس امپلیمنٹیشن کی جانچ کیسے کریں اس پر غور کریں۔  

## وسائل

1. تازہ ترین ترقیات سے باخبر رہنے کے لیے MCP کمیونٹی میں شامل ہوں [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs)  
2. اوپن سورس [MCP پروجیکٹس](https://github.com/modelcontextprotocol) میں تعاون کریں  
3. اپنی تنظیم کی AI پہل کاریوں میں MCP اصول نافذ کریں  
4. اپنی صنعت کے لیے مخصوص MCP امپلیمنٹیشنز دریافت کریں  
5. مخصوص MCP موضوعات جیسے ملٹی موڈل انٹیگریشن یا انٹرپرائز ایپلیکیشن انٹیگریشن پر اعلیٰ درجے کے کورسز لینے پر غور کریں  
6. [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) کے ذریعے سیکھی گئی اصولوں کا استعمال کرتے ہوئے اپنے MCP ٹولز اور ورک فلو بنانے کی مشق کریں  

اگلا: بہترین طریقے [case studies](../09-CaseStudy/README.md)

**دستخطی نوٹ**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں ہی معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر عائد نہیں ہوتی۔