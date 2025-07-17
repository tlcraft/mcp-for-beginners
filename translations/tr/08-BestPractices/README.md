<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "80e5c8949af5af0f401fce6f905990aa",
  "translation_date": "2025-07-17T01:25:26+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "tr"
}
-->
# MCP Geliştirme En İyi Uygulamaları

## Genel Bakış

Bu ders, MCP sunucularını ve özelliklerini üretim ortamlarında geliştirme, test etme ve dağıtma konusunda ileri düzey en iyi uygulamalara odaklanmaktadır. MCP ekosistemleri karmaşıklık ve önem kazandıkça, belirlenmiş kalıpları takip etmek güvenilirlik, sürdürülebilirlik ve birlikte çalışabilirlik sağlar. Bu ders, gerçek dünya MCP uygulamalarından edinilen pratik bilgileri bir araya getirerek, etkili kaynaklar, istemler ve araçlarla sağlam, verimli sunucular oluşturmanız için rehberlik eder.

## Öğrenme Hedefleri

Bu dersin sonunda şunları yapabileceksiniz:
- MCP sunucu ve özellik tasarımında sektörün en iyi uygulamalarını uygulamak
- MCP sunucuları için kapsamlı test stratejileri oluşturmak
- Karmaşık MCP uygulamaları için verimli, yeniden kullanılabilir iş akışı kalıpları tasarlamak
- MCP sunucularında uygun hata yönetimi, kayıt tutma ve gözlemlenebilirlik uygulamak
- MCP uygulamalarını performans, güvenlik ve sürdürülebilirlik açısından optimize etmek

## MCP Temel İlkeleri

Belirli uygulama pratiklerine geçmeden önce, etkili MCP geliştirmeyi yönlendiren temel ilkeleri anlamak önemlidir:

1. **Standartlaştırılmış İletişim**: MCP, tüm uygulamalarda istekler, yanıtlar ve hata yönetimi için tutarlı bir format sağlayan JSON-RPC 2.0 temelini kullanır.

2. **Kullanıcı Odaklı Tasarım**: MCP uygulamalarınızda her zaman kullanıcı onayı, kontrolü ve şeffaflığı ön planda tutun.

3. **Öncelikli Güvenlik**: Kimlik doğrulama, yetkilendirme, doğrulama ve hız sınırlaması gibi sağlam güvenlik önlemleri uygulayın.

4. **Modüler Mimari**: MCP sunucularınızı her araç ve kaynağın net, odaklanmış bir amacı olduğu modüler bir yaklaşımla tasarlayın.

5. **Durumlu Bağlantılar**: Daha tutarlı ve bağlama duyarlı etkileşimler için MCP’nin birden fazla istek arasında durumu koruma yeteneğinden yararlanın.

## Resmi MCP En İyi Uygulamaları

Aşağıdaki en iyi uygulamalar resmi Model Context Protocol dokümantasyonundan alınmıştır:

### Güvenlik En İyi Uygulamaları

1. **Kullanıcı Onayı ve Kontrolü**: Veri erişimi veya işlem yapmadan önce her zaman açık kullanıcı onayı isteyin. Paylaşılan veriler ve yetkilendirilen işlemler üzerinde net kontrol sağlayın.

2. **Veri Gizliliği**: Kullanıcı verilerini yalnızca açık onayla paylaşın ve uygun erişim kontrolleriyle koruyun. Yetkisiz veri iletimine karşı önlem alın.

3. **Araç Güvenliği**: Herhangi bir aracı çağırmadan önce açık kullanıcı onayı isteyin. Kullanıcıların her aracın işlevini anlamasını sağlayın ve sağlam güvenlik sınırları uygulayın.

4. **Araç İzin Kontrolü**: Bir oturum sırasında modelin hangi araçları kullanabileceğini yapılandırarak yalnızca açıkça yetkilendirilmiş araçlara erişim sağlayın.

5. **Kimlik Doğrulama**: Araçlara, kaynaklara veya hassas işlemlere erişim öncesinde API anahtarları, OAuth tokenları veya diğer güvenli kimlik doğrulama yöntemleriyle uygun kimlik doğrulama isteyin.

6. **Parametre Doğrulama**: Araç çağrılarında bozuk veya kötü niyetli girdilerin araç uygulamalarına ulaşmasını önlemek için tüm parametreleri doğrulayın.

7. **Hız Sınırlaması**: Kötüye kullanımı önlemek ve sunucu kaynaklarının adil kullanımını sağlamak için hız sınırlaması uygulayın.

### Uygulama En İyi Uygulamaları

1. **Yetenek Müzakeresi**: Bağlantı kurulurken desteklenen özellikler, protokol sürümleri, mevcut araçlar ve kaynaklar hakkında bilgi alışverişi yapın.

2. **Araç Tasarımı**: Birden fazla konuyu ele alan monolitik araçlar yerine, tek işi iyi yapan odaklanmış araçlar oluşturun.

3. **Hata Yönetimi**: Sorunları teşhis etmeye, hataları zarifçe ele almaya ve uygulanabilir geri bildirim sağlamaya yardımcı olacak standartlaştırılmış hata mesajları ve kodları uygulayın.

4. **Kayıt Tutma**: Protokol etkileşimlerini denetleme, hata ayıklama ve izleme için yapılandırılmış kayıtlar ayarlayın.

5. **İlerleme Takibi**: Uzun süren işlemler için, duyarlı kullanıcı arayüzleri sağlamak amacıyla ilerleme güncellemeleri raporlayın.

6. **İstek İptali**: İstemcilerin artık gerek kalmayan veya çok uzun süren istekleri iptal etmesine izin verin.

## Ek Kaynaklar

MCP en iyi uygulamaları hakkında en güncel bilgiler için şu kaynaklara bakabilirsiniz:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)
- [Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## Pratik Uygulama Örnekleri

### Araç Tasarımı En İyi Uygulamaları

#### 1. Tek Sorumluluk İlkesi

Her MCP aracı net ve odaklanmış bir amaca sahip olmalıdır. Birden fazla konuyu ele almaya çalışan monolitik araçlar yerine, belirli görevlerde uzmanlaşmış araçlar geliştirin.

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

#### 2. Tutarlı Hata Yönetimi

Bilgilendirici hata mesajları ve uygun kurtarma mekanizmalarıyla sağlam hata yönetimi uygulayın.

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

#### 3. Parametre Doğrulama

Bozuk veya kötü niyetli girdileri önlemek için parametreleri her zaman kapsamlı şekilde doğrulayın.

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

### Güvenlik Uygulama Örnekleri

#### 1. Kimlik Doğrulama ve Yetkilendirme

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

#### 2. Hız Sınırlaması

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

## Test En İyi Uygulamaları

### 1. MCP Araçları için Birim Testi

Araçlarınızı her zaman izole şekilde, dış bağımlılıkları taklit ederek test edin:

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

### 2. Entegrasyon Testi

İstemci isteklerinden sunucu yanıtlarına kadar tam akışı test edin:

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

## Performans Optimizasyonu

### 1. Önbellekleme Stratejileri

Gecikmeyi azaltmak ve kaynak kullanımını düşürmek için uygun önbellekleme uygulayın:

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
// Bağımlılık enjeksiyonu ile Java örneği
public class CurrencyConversionTool implements Tool {
    private final ExchangeRateService exchangeService;
    private final CacheService cacheService;
    private final Logger logger;
    
    // Bağımlılıklar yapıcı ile enjekte edilir
    public CurrencyConversionTool(
            ExchangeRateService exchangeService,
            CacheService cacheService,
            Logger logger) {
        this.exchangeService = exchangeService;
        this.cacheService = cacheService;
        this.logger = logger;
    }
    
    // Araç uygulaması
    // ...
}
```

#### 3. Composable Tools

Design tools that can be composed together to create more complex workflows:

```python
# Birleşebilir araçları gösteren Python örneği
class DataFetchTool(Tool):
    def get_name(self):
        return "dataFetch"
    
    # Uygulama...

class DataAnalysisTool(Tool):
    def get_name(self):
        return "dataAnalysis"
    
    # Bu araç dataFetch aracının sonuçlarını kullanabilir
    async def execute_async(self, request):
        # Uygulama...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # Bu araç dataAnalysis aracının sonuçlarını kullanabilir
    async def execute_async(self, request):
        # Uygulama...
        pass

# Bu araçlar bağımsız veya iş akışının parçası olarak kullanılabilir
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
                description = "Arama sorgusu metni. Daha iyi sonuçlar için kesin anahtar kelimeler kullanın." 
            },
            filters = new {
                type = "object",
                description = "Arama sonuçlarını daraltmak için isteğe bağlı filtreler",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "Tarih aralığı formatı YYYY-AA-GG:YYYY-AA-GG" 
                    },
                    category = new { 
                        type = "string", 
                        description = "Filtrelemek için kategori adı" 
                    }
                }
            },
            limit = new { 
                type = "integer", 
                description = "Dönülecek maksimum sonuç sayısı (1-50)",
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
    
    // E-posta özelliği format doğrulaması ile
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "Kullanıcı e-posta adresi");
    
    // Yaş özelliği sayısal kısıtlamalarla
    Map<String, Object> age = new HashMap<>();
    age.put("type", "integer");
    age.put("minimum", 13);
    age.put("maximum", 120);
    age.put("description", "Kullanıcının yaşı (yıl olarak)");
    
    // Sıralı özellik
    Map<String, Object> subscription = new HashMap<>();
    subscription.put("type", "string");
    subscription.put("enum", Arrays.asList("free", "basic", "premium"));
    subscription.put("default", "free");
    subscription.put("description", "Abonelik seviyesi");
    
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
        # İsteği işleme
        results = await self._search_database(request.parameters["query"])
        
        # Her zaman tutarlı bir yapı döndür
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
    """Her öğenin tutarlı bir yapıya sahip olmasını sağlar"""
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
            throw new ToolExecutionException($"Dosya bulunamadı: {fileId}");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ToolExecutionException("Bu dosyaya erişim izniniz yok");
        }
        catch (Exception ex) when (ex is IOException || ex is TimeoutException)
        {
            _logger.LogError(ex, "Dosyaya erişim hatası {FileId}", fileId);
            throw new ToolExecutionException("Dosyaya erişim hatası: Hizmet geçici olarak kullanılamıyor");
        }
    }
    catch (JsonException)
    {
        throw new ToolExecutionException("Geçersiz dosya kimliği formatı");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "FileAccessTool'da beklenmeyen hata");
        throw new ToolExecutionException("Beklenmeyen bir hata oluştu");
    }
}
```

#### 2. Structured Error Responses

Return structured error information when possible:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    try {
        // Uygulama
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
        
        // Diğer istisnaları ToolExecutionException olarak yeniden fırlat
        throw new ToolExecutionException("Araç yürütme başarısız: " + ex.getMessage(), ex);
    }
}
```

#### 3. Retry Logic

Implement appropriate retry logic for transient failures:

```python
async def execute_async(self, request):
    max_retries = 3
    retry_count = 0
    base_delay = 1  # saniye
    
    while retry_count < max_retries:
        try:
            # Harici API çağrısı
            return await self._call_api(request.parameters)
        except TransientError as e:
            retry_count += 1
            if retry_count >= max_retries:
                raise ToolExecutionException(f"İşlem {max_retries} denemeden sonra başarısız oldu: {str(e)}")
                
            # Üssel geri çekilme
            delay = base_delay * (2 ** (retry_count - 1))
            logging.warning(f"Geçici hata, {delay}s sonra yeniden denenecek: {str(e)}")
            await asyncio.sleep(delay)
        except Exception as e:
            # Geçici olmayan hata, yeniden deneme
            raise ToolExecutionException(f"İşlem başarısız oldu: {str(e)}")
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
    
    // Parametrelere göre önbellek anahtarı oluştur
    var cacheKey = $"data_query_{ComputeHash(query)}";
    
    // Önce önbellekten almaya çalış
    if (_cache.TryGetValue(cacheKey, out var cachedResult))
    {
        return new ToolResponse { Result = cachedResult };
    }
    
    // Önbellekte yok - gerçek sorguyu yap
    var result = await _database.QueryAsync(query);
    
    // Süresi dolacak şekilde önbelleğe kaydet
    var cacheOptions = new MemoryCacheEntryOptions()
        .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
        
    _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
    
    return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
}

private string ComputeHash(string input)
{
    // Önbellek anahtarı için stabil hash oluşturma implementasyonu
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
        
        // Uzun süren işlemler için hemen bir işlem ID'si döndür
        String processId = UUID.randomUUID().toString();
        
        // Asenkron işlemi başlat
        CompletableFuture.runAsync(() -> {
            try {
                // Uzun süren işlemi gerçekleştir
                documentService.processDocument(documentId);
                
                // Durumu güncelle (genellikle veritabanında saklanır)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // İşlem ID'si ile hemen yanıt döndür
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // Yardımcı durum kontrol aracı
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
            tokens_per_second=5,  # Saniyede 5 istek izin ver
            bucket_size=10        # 10 isteğe kadar ani patlamalara izin ver
        )
    
    async def execute_async(self, request):
        # Devam edip edemeyeceğimizi veya beklememiz gerekip gerekmediğini kontrol et
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # Bekleme süresi çok uzunsa
                raise ToolExecutionException(
                    f"Rate limiti aşıldı. Lütfen {delay:.1f} saniye sonra tekrar deneyin."
                )
            else:
                # Uygun bekleme süresi kadar bekle
                await asyncio.sleep(delay)
        
        # Bir token tüket ve isteğe devam et
        self.rate_limiter.consume()
        
        # API çağrısı yap
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
            
            # Bir sonraki tokenın ne zaman hazır olacağını hesapla
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # Geçen zamana göre yeni token ekle
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
    // Parametrelerin varlığını doğrula
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("Gerekli parametre eksik: query");
    }
    
    // Doğru türde olduğunu doğrula
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("Query parametresi bir string olmalıdır");
    }
    
    var query = queryProp.GetString();
    
    // String içeriğini doğrula
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("Query parametresi boş olamaz");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("Query parametresi 500 karakteri aşamaz");
    }
    
    // Uygulanabiliyorsa SQL enjeksiyon saldırılarını kontrol et
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("Geçersiz sorgu: potansiyel olarak tehlikeli SQL içeriyor");
    }
    
    // İşleme devam et
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // İstekten kullanıcı bağlamını al
    UserContext user = request.getContext().getUserContext();
    
    // Kullanıcının gerekli izinlere sahip olup olmadığını kontrol et
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("Kullanıcının belgelere erişim izni yok");
    }
    
    // Belirli kaynaklar için o kaynağa erişimi kontrol et
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("İstenen belgeye erişim reddedildi");
    }
    
    // Araç çalıştırmaya devam et
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
        
        # Kullanıcı verisini al
        user_data = await self.user_service.get_user_data(user_id)
        
        # Hassas alanları, açıkça istenmedikçe VE yetkili değilse filtrele
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # İstek bağlamındaki yetki seviyesini kontrol et
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # Orijinali değiştirmemek için kopya oluştur
        redacted = user_data.copy()
        
        # Belirli hassas alanları sansürle
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # İç içe hassas verileri sansürle
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
    // Hazırlık
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("Seattle", 3))
        .ReturnsAsync(new WeatherForecast(/* test verisi */));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "Seattle", 
            days = 3 
        })
    );
    
    // Çalıştır
    var response = await tool.ExecuteAsync(request);
    
    // Doğrula
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // Hazırlık
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("InvalidLocation", It.IsAny<int>()))
        .ThrowsAsync(new LocationNotFoundException("Konum bulunamadı"));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "InvalidLocation", 
            days = 3 
        })
    );
    
    // Çalıştır ve doğrula
    var exception = await Assert.ThrowsAsync<ToolExecutionException>(
        () => tool.ExecuteAsync(request)
    );
    
    Assert.Contains("Konum bulunamadı", exception.Message);
}
```

#### 2. Schema Validation Testing

Test that schemas are valid and properly enforce constraints:

```java
@Test
public void testSchemaValidation() {
    // Araç örneği oluştur
    SearchTool searchTool = new SearchTool();
    
    // Şemayı al
    Object schema = searchTool.getSchema();
    
    // Şemayı JSON'a çevir ve doğrula
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // Şemanın geçerli JSONSchema olduğunu doğrula
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // Geçerli parametreleri test et
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // Gerekli parametre eksikliği testi
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // Geçersiz parametre türü testi
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
    # Hazırlık
    tool = ApiTool(timeout=0.1)  # Çok kısa zaman aşımı
    
    # Zaman aşımı olacak isteği taklit et
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # Zaman aşımından uzun
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # Çalıştır ve doğrula
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Hata mesajını doğrula
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # Hazırlık
    tool = ApiTool()
    
    # Rate limit uygulanmış yanıtı taklit et
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
        
        # Çalıştır ve doğrula
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Hatanın rate limit bilgisini içerdiğini doğrula
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
    // Hazırlık
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // Çalıştır
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

// Doğrulama
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
        // Keşif endpoint'ini test et
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // Araç isteği oluştur
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // İsteği gönder ve yanıtı doğrula
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // Geçersiz araç isteği oluştur
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // Eksik parametre "b"
        request.put("parameters", parameters);
        
        // İsteği gönder ve hata yanıtını doğrula
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
    # Hazırlık - MCP istemcisini ve sahte modeli ayarla
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # Sahte model yanıtları
    mock_model = MockLanguageModel([
        MockResponse(
            "Seattle'da hava durumu nasıl?",
            tool_calls=[{
                "tool_name": "weatherForecast",
                "parameters": {"location": "Seattle", "days": 3}
            }]
        ),
        MockResponse(
            "İşte Seattle için hava tahmini:\n- Bugün: 65°F, Parçalı Bulutlu\n- Yarın: 68°F, Güneşli\n- Ertesi gün: 62°F, Yağmurlu",
            tool_calls=[]
        )
    ])
    
    # Sahte hava aracı yanıtı
    with aioresponses() as mocked:
        mocked.post(
            "http://localhost:5000/mcp/execute",
            payload={
                "result": {
                    "location": "Seattle",
                    "forecast": [
                        {"date": "2023-06-01", "temperature": 65, "conditions": "Parçalı Bulutlu"},
                        {"date": "2023-06-02", "temperature": 68, "conditions": "Güneşli"},
                        {"date": "2023-06-03", "temperature": 62, "conditions": "Yağmurlu"}
                    ]
                }
            }
        )
        
        # İşlem
        response = await mcp_client.send_prompt(
            "Seattle'da hava durumu nasıl?",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # Doğrulama
        assert "Seattle" in response.generated_text
        assert "65" in response.generated_text
        assert "Güneşli" in response.generated_text
        assert "Yağmurlu" in response.generated_text
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
    // Hazırlık
    var server = new McpServer(
        name: "TestServer",
        version: "1.0",
        maxConcurrentRequests: 100
    );
    
    server.RegisterTool(new FastExecutingTool());
    await server.StartAsync();
    
    var client = new McpClient("http://localhost:5000");
    
    // İşlem
    var tasks = new List<Task<McpResponse>>();
    for (int i = 0; i < 1000; i++)
    {
        tasks.Add(client.ExecuteToolAsync("fastTool", new { iteration = i }));
    }
    
    var results = await Task.WhenAll(tasks);
    
    // Doğrulama
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
    
    // Stres testi için JMeter ayarla
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // JMeter test planını yapılandır
    HashTree testPlanTree = new HashTree();
    
    // Test planı, thread grubu, örnekleyiciler vb. oluştur
    TestPlan testPlan = new TestPlan("MCP Server Stres Testi");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // Araç çalıştırma için HTTP örnekleyici ekle
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // Dinleyiciler ekle
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // Testi çalıştır
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // Sonuçları doğrula
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // Ortalama yanıt süresi < 200ms
    assertTrue(summaryReport.getPercentile(90.0) < 500); // %90 persentil < 500ms
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# Bir MCP sunucusu için izleme yapılandırması
def configure_monitoring(server):
    # Prometheus metriklerini ayarla
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "Toplam MCP istekleri"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "İstek süresi saniye cinsinden",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "Araç çalıştırma sayısı",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "Araç çalıştırma süresi saniye cinsinden",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "Araç çalıştırma hataları",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # Zamanlama ve metrik kaydı için ara katman ekle
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # Metrikler endpoint'ini aç
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
# Python Araç Zinciri uygulaması
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # Sırayla çalıştırılacak araç isimleri listesi
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # Zincirdeki her aracı çalıştır, önceki sonucu geçir
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # Sonucu sakla ve sonraki araç için giriş olarak kullan
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# Örnek kullanım
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
    public string Description => "Çeşitli türde içerikleri işler";
    
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
        
        // Hangi özel aracın kullanılacağını belirle
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // Özel araca yönlendir
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
ÖNEMLİ KURALLAR:  
1. Çevirinin etrafına '''markdown veya başka herhangi bir etiket eklemeyin  
2. Çevirinin çok kelime kelime olmamasına dikkat edin  
3. Yorumları da çevirin  
4. Bu dosya Markdown formatında yazılmıştır - XML veya HTML gibi işlemeyin  
5. Çevirmeyin:  
   - [!NOTE], [!WARNING], [!TIP], [!IMPORTANT], [!CAUTION]  
   - Değişken isimleri, fonksiyon isimleri, sınıf isimleri  
   - @@INLINE_CODE_x@@ veya @@CODE_BLOCK_x@@ gibi yer tutucular  
   - URL’ler veya yollar  
6. Tüm orijinal markdown formatlamasını koruyun  
7. Yalnızca çevrilmiş içeriği, ek etiket veya işaretleme olmadan döndürün  
Lütfen çıktıyı soldan sağa yazın.
("code", _) => "codeAnalyzer",
_ => throw new ToolExecutionException($"No tool available for {contentType}/{operation}")
};
}

private object GetOptionsForTool(string toolName, string operation)
{
// Her özel araç için uygun seçenekleri döndür
return toolName switch
{
    "textSummarizer" => new { length = "medium" },
    "htmlProcessor" => new { cleanUp = true, operation },
    // Diğer araçlar için seçenekler...
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
        // Adım 1: Veri seti meta verisini al (eşzamanlı)
        ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata", 
            Map.of("datasetId", datasetId));
        
        // Adım 2: Birden fazla analizi paralel başlat
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
        
        // Tüm paralel görevlerin tamamlanmasını bekle
        CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
            statisticalAnalysis, correlationAnalysis, outlierDetection
        );
        
        allAnalyses.join();  // Tamamlanana kadar bekle
        
        // Adım 3: Sonuçları birleştir
        Map<String, Object> combinedResults = new HashMap<>();
        combinedResults.put("metadata", metadataResponse.getResult());
        combinedResults.put("statistics", statisticalAnalysis.join().getResult());
        combinedResults.put("correlations", correlationAnalysis.join().getResult());
        combinedResults.put("outliers", outlierDetection.join().getResult());
        
        // Adım 4: Özet rapor oluştur
        ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator", 
            Map.of("analysisResults", combinedResults));
        
        // Tam iş akışı sonucunu döndür
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
            # Öncelikle birincil aracı dene
            response = await self.client.execute_tool(primary_tool, parameters)
            return {
                "result": response.result,
                "source": "primary",
                "tool": primary_tool
            }
        except ToolExecutionException as e:
            # Hata kaydı
            logging.warning(f"Birincil araç '{primary_tool}' başarısız oldu: {str(e)}")
            
            # İkincil araca geç
            try:
                # İkincil araç için parametreleri dönüştürmek gerekebilir
                fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)
                
                response = await self.client.execute_tool(fallback_tool, fallback_params)
                return {
                    "result": response.result,
                    "source": "fallback",
                    "tool": fallback_tool,
                    "primaryError": str(e)
                }
            except ToolExecutionException as fallback_error:
                # Her iki araç da başarısız oldu
                logging.error(f"Birincil ve ikincil araçlar başarısız oldu. İkincil hata: {str(fallback_error)}")
                raise WorkflowExecutionException(
                    f"İş akışı başarısız oldu: birincil hata: {str(e)}; ikincil hata: {str(fallback_error)}"
                )
    
    def _adapt_parameters(self, params, from_tool, to_tool):
        """Gerekirse farklı araçlar arasında parametreleri uyarlama"""
        # Bu uygulama, kullanılan araçlara bağlıdır
        # Bu örnekte orijinal parametreleri döndürüyoruz
        return params

# Örnek kullanım
async def get_weather(workflow, location):
    return await workflow.execute_with_fallback(
        "premiumWeatherService",  # Birincil (ücretli) hava durumu API'si
        "basicWeatherService",    # İkincil (ücretsiz) hava durumu API'si
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
            
            // Her iş akışının sonucunu sakla
            results[workflow.Name] = workflowResult;
            
            // Sonraki iş akışı için bağlamı güncelle
            context = context.WithResult(workflow.Name, workflowResult);
        }
        
        return new WorkflowResult(results);
    }
    
    public string Name => "CompositeWorkflow";
    public string Description => "Birden fazla iş akışını sırayla çalıştırır";
}

// Örnek kullanım
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
// C# için hesap makinesi aracı birim testi örneği
[Fact]
public async Task CalculatorTool_Add_ReturnsCorrectSum()
{
    // Hazırlık
    var calculator = new CalculatorTool();
    var parameters = new Dictionary<string, object>
    {
        ["operation"] = "add",
        ["a"] = 5,
        ["b"] = 7
    };
    
    // İşlem
    var response = await calculator.ExecuteAsync(parameters);
    var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());
    
    // Doğrulama
    Assert.Equal(12, result.Value);
}
```

```python
# Python için hesap makinesi aracı birim testi örneği
def test_calculator_tool_add():
    # Hazırlık
    calculator = CalculatorTool()
    parameters = {
        "operation": "add",
        "a": 5,
        "b": 7
    }
    
    # İşlem
    response = calculator.execute(parameters)
    result = json.loads(response.content[0].text)
    
    # Doğrulama
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
// MCP sunucusu için C# entegrasyon testi örneği
[Fact]
public async Task Server_ProcessToolRequest_ReturnsValidResponse()
{
    // Hazırlık
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
    
    // İşlem
    var response = await server.ProcessRequestAsync(request);
    
    // Doğrulama
    Assert.NotNull(response);
    Assert.Equal(McpStatusCodes.Success, response.StatusCode);
    // Yanıt içeriği için ek doğrulamalar
    
    // Temizlik
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
// TypeScript ile istemci kullanarak E2E testi örneği
describe('MCP Server E2E Tests', () => {
  let client: McpClient;
  
  beforeAll(async () => {
    // Test ortamında sunucuyu başlat
    await startTestServer();
    client = new McpClient('http://localhost:5000');
  });
  
  afterAll(async () => {
    await stopTestServer();
  });
  
  test('İstemci calculator aracını çağırabilir ve doğru sonucu alır', async () => {
    // İşlem
    const response = await client.invokeToolAsync('calculator', {
      operation: 'divide',
      a: 20,
      b: 4
    });
    
    // Doğrulama
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
// C# örneği Moq ile
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
# Python örneği unittest.mock ile
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
    # Mock yapılandırması
    mock_model.return_value.generate_response.return_value = {
        "text": "Mocked model response",
        "finish_reason": "completed"
    }
    
    # Testte mock kullanımı
    server = McpServer(model_client=mock_model)
    # Teste devam
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
// MCP sunucusu için yük testi k6 scripti
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  vus: 10,  // 10 sanal kullanıcı
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
    'durum 200': (r) => r.status === 200,
    'yanıt süresi < 500ms': (r) => r.timings.duration < 500,
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
    
    - name: Çalışma Zamanı Kurulumu
      uses: actions/setup-dotnet@v1
      with:
        dotnet-version: '8.0.x'
    
    - name: Bağımlılıkları Geri Yükle
      run: dotnet restore
    
    - name: Derle
      run: dotnet build --no-restore
    
    - name: Birim Testleri
      run: dotnet test --no-build --filter Category=Unit
    
    - name: Entegrasyon Testleri
      run: dotnet test --no-build --filter Category=Integration
      
    - name: Performans Testleri
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
    // Hazırlık
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");
    
    // İşlem
    var response = await client.GetAsync("http://localhost:5000/api/resources");
    var content = await response.Content.ReadAsStringAsync();
    var resources = JsonSerializer.Deserialize

// Doğrulama  
Assert.Equal(HttpStatusCode.OK, response.StatusCode);  
Assert.NotNull(resources);  
Assert.All(resources.Resources, resource =>  
{  
    Assert.NotNull(resource.Id);  
    Assert.NotNull(resource.Type);  
    // Ek şema doğrulaması  
});  
}  
```

## Etkili MCP Sunucu Testi İçin En İyi 10 İpucu

1. **Araç Tanımlarını Ayrı Test Edin**: Şema tanımlarını araç mantığından bağımsız olarak doğrulayın  
2. **Parametreli Testler Kullanın**: Araçları çeşitli girdilerle, özellikle sınır durumlarıyla test edin  
3. **Hata Yanıtlarını Kontrol Edin**: Tüm olası hata durumları için doğru hata yönetimini doğrulayın  
4. **Yetkilendirme Mantığını Test Edin**: Farklı kullanıcı rolleri için uygun erişim kontrolünü sağlayın  
5. **Test Kapsamını İzleyin**: Kritik yol kodunun yüksek kapsama sahip olmasına özen gösterin  
6. **Akış Yanıtlarını Test Edin**: Akış halinde gelen içeriğin doğru şekilde işlendiğini doğrulayın  
7. **Ağ Sorunlarını Simüle Edin**: Zayıf ağ koşullarında davranışı test edin  
8. **Kaynak Limitlerini Test Edin**: Kota veya hız sınırlarına ulaşıldığında davranışı doğrulayın  
9. **Regresyon Testlerini Otomatikleştirin**: Her kod değişikliğinde çalışan bir test paketi oluşturun  
10. **Test Senaryolarını Belgeleyin**: Test durumlarının net dokümantasyonunu tutun  

## Yaygın Test Hataları

- **Sadece olumlu senaryolara aşırı güvenmek**: Hata durumlarını da kapsamlı şekilde test edin  
- **Performans testlerini göz ardı etmek**: Üretimi etkilemeden önce darboğazları tespit edin  
- **Yalnızca izole test yapmak**: Birim, entegrasyon ve uçtan uca testleri birleştirin  
- **Eksik API kapsamı**: Tüm uç noktaların ve özelliklerin test edildiğinden emin olun  
- **Tutarsız test ortamları**: Tutarlı test ortamları için konteyner kullanın  

## Sonuç

Güvenilir ve yüksek kaliteli MCP sunucuları geliştirmek için kapsamlı bir test stratejisi şarttır. Bu rehberdeki en iyi uygulamaları ve ipuçlarını uygulayarak, MCP uygulamalarınızın kalite, güvenilirlik ve performans açısından en yüksek standartları karşılamasını sağlayabilirsiniz.  

## Önemli Noktalar

1. **Araç Tasarımı**: Tek sorumluluk prensibini takip edin, bağımlılık enjeksiyonu kullanın ve bileşen tasarımına önem verin  
2. **Şema Tasarımı**: Açık, iyi belgelenmiş şemalar oluşturun ve uygun doğrulama kısıtlamaları ekleyin  
3. **Hata Yönetimi**: Zarif hata yönetimi, yapılandırılmış hata yanıtları ve yeniden deneme mantığı uygulayın  
4. **Performans**: Önbellekleme, asenkron işlem ve kaynak kısıtlaması kullanın  
5. **Güvenlik**: Kapsamlı giriş doğrulama, yetkilendirme kontrolleri ve hassas veri yönetimi uygulayın  
6. **Test**: Kapsamlı birim, entegrasyon ve uçtan uca testler oluşturun  
7. **İş Akışı Desenleri**: Zincirler, dağıtıcılar ve paralel işleme gibi yerleşik desenleri uygulayın  

## Alıştırma

Aşağıdaki özelliklere sahip bir belge işleme sistemi için MCP aracı ve iş akışı tasarlayın:

1. Birden fazla formatta (PDF, DOCX, TXT) belge kabul eder  
2. Belgelerden metin ve anahtar bilgileri çıkarır  
3. Belgeleri tür ve içeriğe göre sınıflandırır  
4. Her belgenin özetini oluşturur  

Bu senaryoya en uygun araç şemalarını, hata yönetimini ve iş akışı desenini uygulayın. Bu uygulamayı nasıl test edeceğinizi düşünün.  

## Kaynaklar

1. En son gelişmelerden haberdar olmak için [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs) MCP topluluğuna katılın  
2. Açık kaynak [MCP projelerine](https://github.com/modelcontextprotocol) katkıda bulunun  
3. Kendi kuruluşunuzun yapay zeka girişimlerinde MCP prensiplerini uygulayın  
4. Sektörünüze özel MCP uygulamalarını keşfedin  
5. Çok modlu entegrasyon veya kurumsal uygulama entegrasyonu gibi belirli MCP konularında ileri düzey kurslar almayı düşünün  
6. [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) aracılığıyla öğrenilen prensipleri kullanarak kendi MCP araçlarınızı ve iş akışlarınızı geliştirmeyi deneyin  

Sonraki: En İyi Uygulamalar [vaka çalışmaları](../09-CaseStudy/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.