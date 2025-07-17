<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "80e5c8949af5af0f401fce6f905990aa",
  "translation_date": "2025-07-17T08:02:31+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "ms"
}
-->
# Amalan Terbaik Pembangunan MCP

## Gambaran Keseluruhan

Pelajaran ini memfokuskan kepada amalan terbaik lanjutan untuk membangunkan, menguji, dan melaksanakan pelayan dan ciri MCP dalam persekitaran produksi. Apabila ekosistem MCP menjadi semakin kompleks dan penting, mengikuti corak yang telah ditetapkan memastikan kebolehpercayaan, kebolehselenggaraan, dan kebolehoperasian. Pelajaran ini mengumpulkan kebijaksanaan praktikal yang diperoleh daripada pelaksanaan MCP sebenar untuk membimbing anda dalam mencipta pelayan yang kukuh dan cekap dengan sumber, arahan, dan alat yang berkesan.

## Objektif Pembelajaran

Menjelang akhir pelajaran ini, anda akan dapat:
- Mengaplikasikan amalan terbaik industri dalam reka bentuk pelayan dan ciri MCP
- Mewujudkan strategi ujian menyeluruh untuk pelayan MCP
- Merancang corak aliran kerja yang cekap dan boleh digunakan semula untuk aplikasi MCP yang kompleks
- Melaksanakan pengendalian ralat, pencatatan, dan pemerhatian yang betul dalam pelayan MCP
- Mengoptimumkan pelaksanaan MCP untuk prestasi, keselamatan, dan kebolehselenggaraan

## Prinsip Teras MCP

Sebelum menyelami amalan pelaksanaan tertentu, adalah penting untuk memahami prinsip teras yang membimbing pembangunan MCP yang berkesan:

1. **Komunikasi Standard**: MCP menggunakan JSON-RPC 2.0 sebagai asasnya, menyediakan format yang konsisten untuk permintaan, respons, dan pengendalian ralat di semua pelaksanaan.

2. **Reka Bentuk Berpusatkan Pengguna**: Sentiasa utamakan persetujuan, kawalan, dan ketelusan pengguna dalam pelaksanaan MCP anda.

3. **Keselamatan Diutamakan**: Laksanakan langkah keselamatan yang kukuh termasuk pengesahan, kebenaran, pengesahan data, dan had kadar.

4. **Seni Bina Modular**: Reka pelayan MCP anda dengan pendekatan modular, di mana setiap alat dan sumber mempunyai tujuan yang jelas dan fokus.

5. **Sambungan Berkeadaan**: Manfaatkan keupayaan MCP untuk mengekalkan keadaan merentasi pelbagai permintaan bagi interaksi yang lebih koheren dan berkesedaran konteks.

## Amalan Terbaik Rasmi MCP

Amalan terbaik berikut diambil daripada dokumentasi rasmi Model Context Protocol:

### Amalan Terbaik Keselamatan

1. **Persetujuan dan Kawalan Pengguna**: Sentiasa minta persetujuan jelas daripada pengguna sebelum mengakses data atau menjalankan operasi. Berikan kawalan yang jelas terhadap data yang dikongsi dan tindakan yang dibenarkan.

2. **Privasi Data**: Dedahkan data pengguna hanya dengan persetujuan jelas dan lindungi dengan kawalan akses yang sesuai. Lindungi daripada penghantaran data tanpa kebenaran.

3. **Keselamatan Alat**: Minta persetujuan jelas pengguna sebelum menggunakan mana-mana alat. Pastikan pengguna memahami fungsi setiap alat dan laksanakan sempadan keselamatan yang kukuh.

4. **Kawalan Kebenaran Alat**: Konfigurasikan alat yang dibenarkan digunakan oleh model semasa sesi, memastikan hanya alat yang diberi kuasa secara jelas boleh diakses.

5. **Pengesahan**: Minta pengesahan yang betul sebelum memberi akses kepada alat, sumber, atau operasi sensitif menggunakan kunci API, token OAuth, atau kaedah pengesahan selamat lain.

6. **Pengesahan Parameter**: Laksanakan pengesahan untuk semua panggilan alat bagi mengelakkan input yang rosak atau berniat jahat sampai ke pelaksanaan alat.

7. **Had Kadar**: Laksanakan had kadar untuk mengelakkan penyalahgunaan dan memastikan penggunaan sumber pelayan yang adil.

### Amalan Terbaik Pelaksanaan

1. **Rundingan Keupayaan**: Semasa penyediaan sambungan, bertukar maklumat mengenai ciri yang disokong, versi protokol, alat dan sumber yang tersedia.

2. **Reka Bentuk Alat**: Cipta alat yang fokus melakukan satu perkara dengan baik, bukannya alat monolitik yang mengendalikan pelbagai perkara.

3. **Pengendalian Ralat**: Laksanakan mesej dan kod ralat yang standard untuk membantu mendiagnosis isu, mengendalikan kegagalan dengan baik, dan memberikan maklum balas yang boleh diambil tindakan.

4. **Pencatatan**: Konfigurasikan log berstruktur untuk audit, penyahpepijatan, dan pemantauan interaksi protokol.

5. **Penjejakan Kemajuan**: Untuk operasi yang berjalan lama, laporkan kemas kini kemajuan untuk membolehkan antara muka pengguna yang responsif.

6. **Pembatalan Permintaan**: Benarkan klien membatalkan permintaan yang sedang diproses yang tidak lagi diperlukan atau mengambil masa terlalu lama.

## Rujukan Tambahan

Untuk maklumat terkini mengenai amalan terbaik MCP, rujuk:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)
- [Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## Contoh Pelaksanaan Praktikal

### Amalan Terbaik Reka Bentuk Alat

#### 1. Prinsip Tanggungjawab Tunggal

Setiap alat MCP harus mempunyai tujuan yang jelas dan fokus. Daripada mencipta alat monolitik yang cuba mengendalikan pelbagai perkara, bangunkan alat khusus yang cemerlang dalam tugasan tertentu.

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

#### 2. Pengendalian Ralat Konsisten

Laksanakan pengendalian ralat yang kukuh dengan mesej ralat yang informatif dan mekanisme pemulihan yang sesuai.

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

#### 3. Pengesahan Parameter

Sentiasa sahkan parameter dengan teliti untuk mengelakkan input yang rosak atau berniat jahat.

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

### Contoh Pelaksanaan Keselamatan

#### 1. Pengesahan dan Kebenaran

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

#### 2. Had Kadar

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

## Amalan Terbaik Ujian

### 1. Ujian Unit Alat MCP

Sentiasa uji alat anda secara berasingan, dengan meniru kebergantungan luaran:

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

### 2. Ujian Integrasi

Uji aliran lengkap dari permintaan klien ke respons pelayan:

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

## Pengoptimuman Prestasi

### 1. Strategi Caching

Laksanakan caching yang sesuai untuk mengurangkan kelewatan dan penggunaan sumber:

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
// Contoh Java dengan suntikan kebergantungan
public class CurrencyConversionTool implements Tool {
    private final ExchangeRateService exchangeService;
    private final CacheService cacheService;
    private final Logger logger;
    
    // Kebergantungan disuntik melalui konstruktor
    public CurrencyConversionTool(
            ExchangeRateService exchangeService,
            CacheService cacheService,
            Logger logger) {
        this.exchangeService = exchangeService;
        this.cacheService = cacheService;
        this.logger = logger;
    }
    
    // Pelaksanaan alat
    // ...
}
```

#### 3. Composable Tools

Design tools that can be composed together to create more complex workflows:

```python
# Contoh Python menunjukkan alat yang boleh digabungkan
class DataFetchTool(Tool):
    def get_name(self):
        return "dataFetch"
    
    # Pelaksanaan...

class DataAnalysisTool(Tool):
    def get_name(self):
        return "dataAnalysis"
    
    # Alat ini boleh menggunakan hasil dari alat dataFetch
    async def execute_async(self, request):
        # Pelaksanaan...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # Alat ini boleh menggunakan hasil dari alat dataAnalysis
    async def execute_async(self, request):
        # Pelaksanaan...
        pass

# Alat-alat ini boleh digunakan secara bebas atau sebagai sebahagian daripada aliran kerja
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
                description = "Teks carian. Gunakan kata kunci tepat untuk hasil yang lebih baik." 
            },
            filters = new {
                type = "object",
                description = "Penapis pilihan untuk mengecilkan hasil carian",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "Julat tarikh dalam format YYYY-MM-DD:YYYY-MM-DD" 
                    },
                    category = new { 
                        type = "string", 
                        description = "Nama kategori untuk menapis" 
                    }
                }
            },
            limit = new { 
                type = "integer", 
                description = "Bilangan maksimum hasil yang dikembalikan (1-50)",
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
    
    // Properti email dengan pengesahan format
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "Alamat emel pengguna");
    
    // Properti umur dengan had nombor
    Map<String, Object> age = new HashMap<>();
    age.put("type", "integer");
    age.put("minimum", 13);
    age.put("maximum", 120);
    age.put("description", "Umur pengguna dalam tahun");
    
    // Properti enumerasi
    Map<String, Object> subscription = new HashMap<>();
    subscription.put("type", "string");
    subscription.put("enum", Arrays.asList("free", "basic", "premium"));
    subscription.put("default", "free");
    subscription.put("description", "Tahap langganan");
    
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
        # Proses permintaan
        results = await self._search_database(request.parameters["query"])
        
        # Sentiasa kembalikan struktur yang konsisten
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
    """Memastikan setiap item mempunyai struktur yang konsisten"""
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
            throw new ToolExecutionException($"Fail tidak dijumpai: {fileId}");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ToolExecutionException("Anda tidak mempunyai kebenaran untuk mengakses fail ini");
        }
        catch (Exception ex) when (ex is IOException || ex is TimeoutException)
        {
            _logger.LogError(ex, "Ralat mengakses fail {FileId}", fileId);
            throw new ToolExecutionException("Ralat mengakses fail: Perkhidmatan tidak tersedia buat sementara waktu");
        }
    }
    catch (JsonException)
    {
        throw new ToolExecutionException("Format ID fail tidak sah");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Ralat tidak dijangka dalam FileAccessTool");
        throw new ToolExecutionException("Ralat tidak dijangka berlaku");
    }
}
```

#### 2. Structured Error Responses

Return structured error information when possible:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    try {
        // Pelaksanaan
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
        
        // Buang semula pengecualian lain sebagai ToolExecutionException
        throw new ToolExecutionException("Pelaksanaan alat gagal: " + ex.getMessage(), ex);
    }
}
```

#### 3. Retry Logic

Implement appropriate retry logic for transient failures:

```python
async def execute_async(self, request):
    max_retries = 3
    retry_count = 0
    base_delay = 1  # saat
    
    while retry_count < max_retries:
        try:
            # Panggil API luaran
            return await self._call_api(request.parameters)
        except TransientError as e:
            retry_count += 1
            if retry_count >= max_retries:
                raise ToolExecutionException(f"Operasi gagal selepas {max_retries} percubaan: {str(e)}")
                
            # Penangguhan eksponen
            delay = base_delay * (2 ** (retry_count - 1))
            logging.warning(f"Ralat sementara, cuba semula dalam {delay}s: {str(e)}")
            await asyncio.sleep(delay)
        except Exception as e:
            # Ralat bukan sementara, tidak cuba semula
            raise ToolExecutionException(f"Operasi gagal: {str(e)}")
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
        
        // Cipta kunci cache berdasarkan parameter
        var cacheKey = $"data_query_{ComputeHash(query)}";
        
        // Cuba dapatkan dari cache terlebih dahulu
        if (_cache.TryGetValue(cacheKey, out var cachedResult))
        {
            return new ToolResponse { Result = cachedResult };
        }
        
        // Cache tidak ditemui - jalankan pertanyaan sebenar
        var result = await _database.QueryAsync(query);
        
        // Simpan dalam cache dengan tempoh luput
        var cacheOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
            
        _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
        
        return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
    }
    
    private string ComputeHash(string input)
    {
        // Pelaksanaan untuk menjana hash stabil bagi kunci cache
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
        
        // Untuk operasi yang mengambil masa lama, kembalikan ID proses dengan segera
        String processId = UUID.randomUUID().toString();
        
        // Mulakan pemprosesan async
        CompletableFuture.runAsync(() -> {
            try {
                // Laksanakan operasi yang mengambil masa lama
                documentService.processDocument(documentId);
                
                // Kemas kini status (biasanya disimpan dalam pangkalan data)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // Kembalikan respons segera dengan ID proses
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // Alat semakan status pendamping
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
            tokens_per_second=5,  # Benarkan 5 permintaan sesaat
            bucket_size=10        # Benarkan letusan sehingga 10 permintaan
        )
    
    async def execute_async(self, request):
        # Semak jika kita boleh teruskan atau perlu tunggu
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # Jika masa menunggu terlalu lama
                raise ToolExecutionException(
                    f"Had kadar terlampau. Sila cuba lagi dalam {delay:.1f} saat."
                )
            else:
                # Tunggu untuk masa kelewatan yang sesuai
                await asyncio.sleep(delay)
        
        # Gunakan token dan teruskan dengan permintaan
        self.rate_limiter.consume()
        
        # Panggil API
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
            
            # Kira masa sehingga token seterusnya tersedia
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # Tambah token baru berdasarkan masa yang berlalu
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
    // Sahkan parameter wujud
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("Parameter diperlukan hilang: query");
    }
    
    // Sahkan jenis yang betul
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("Parameter query mesti berupa string");
    }
    
    var query = queryProp.GetString();
    
    // Sahkan kandungan string
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("Parameter query tidak boleh kosong");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("Parameter query melebihi panjang maksimum 500 aksara");
    }
    
    // Semak serangan suntikan SQL jika berkenaan
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("Query tidak sah: mengandungi SQL yang berpotensi tidak selamat");
    }
    
    // Teruskan dengan pelaksanaan
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // Dapatkan konteks pengguna dari permintaan
    UserContext user = request.getContext().getUserContext();
    
    // Semak jika pengguna mempunyai kebenaran yang diperlukan
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("Pengguna tidak mempunyai kebenaran untuk mengakses dokumen");
    }
    
    // Untuk sumber tertentu, semak akses ke sumber tersebut
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("Akses ditolak ke dokumen yang diminta");
    }
    
    // Teruskan dengan pelaksanaan alat
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
        
        # Dapatkan data pengguna
        user_data = await self.user_service.get_user_data(user_id)
        
        # Tapis medan sensitif kecuali diminta secara eksplisit DAN diberi kuasa
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # Semak tahap kebenaran dalam konteks permintaan
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # Buat salinan untuk elak mengubah asal
        redacted = user_data.copy()
        
        # Sembunyikan medan sensitif tertentu
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # Sembunyikan data sensitif bersarang
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
    // Susun atur
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("Seattle", 3))
        .ReturnsAsync(new WeatherForecast(/* data ujian */));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "Seattle", 
            days = 3 
        })
    );
    
    // Laksanakan
    var response = await tool.ExecuteAsync(request);
    
    // Sahkan
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // Susun atur
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("InvalidLocation", It.IsAny<int>()))
        .ThrowsAsync(new LocationNotFoundException("Lokasi tidak ditemui"));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "InvalidLocation", 
            days = 3 
        })
    );
    
    // Laksanakan & sahkan
    var exception = await Assert.ThrowsAsync<ToolExecutionException>(
        () => tool.ExecuteAsync(request)
    );
    
    Assert.Contains("Lokasi tidak ditemui", exception.Message);
}
```

#### 2. Schema Validation Testing

Test that schemas are valid and properly enforce constraints:

```java
@Test
public void testSchemaValidation() {
    // Cipta instans alat
    SearchTool searchTool = new SearchTool();
    
    // Dapatkan skema
    Object schema = searchTool.getSchema();
    
    // Tukar skema ke JSON untuk pengesahan
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // Sahkan skema adalah JSONSchema yang sah
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // Uji parameter yang sah
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // Uji parameter wajib yang hilang
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // Uji jenis parameter yang tidak sah
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
    # Susun atur
    tool = ApiTool(timeout=0.1)  # Masa tamat sangat singkat
    
    # Palsukan permintaan yang akan tamat masa
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # Lebih lama dari tamat masa
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # Laksanakan & sahkan
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Sahkan mesej pengecualian
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # Susun atur
    tool = ApiTool()
    
    # Palsukan respons had kadar
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
        
        # Laksanakan & sahkan
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Sahkan pengecualian mengandungi maklumat had kadar
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
    // Susun atur
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // Laksanakan
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

// Sahkan
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
        // Uji titik akhir penemuan
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // Cipta permintaan alat
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // Hantar permintaan dan sahkan respons
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // Cipta permintaan alat yang tidak sah
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // Parameter "b" hilang
        request.put("parameters", parameters);
        
        // Hantar permintaan dan sahkan respons ralat
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
    # Susun - Sediakan klien MCP dan model tiruan
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # Respons model tiruan
    mock_model = MockLanguageModel([
        MockResponse(
            "Apa ramalan cuaca di Seattle?",
            tool_calls=[{
                "tool_name": "weatherForecast",
                "parameters": {"location": "Seattle", "days": 3}
            }]
        ),
        MockResponse(
            "Ini ramalan cuaca untuk Seattle:\n- Hari ini: 65°F, Berawan Sebahagian\n- Esok: 68°F, Cerah\n- Hari selepas: 62°F, Hujan",
            tool_calls=[]
        )
    ])
    
    # Respons alat cuaca tiruan
    with aioresponses() as mocked:
        mocked.post(
            "http://localhost:5000/mcp/execute",
            payload={
                "result": {
                    "location": "Seattle",
                    "forecast": [
                        {"date": "2023-06-01", "temperature": 65, "conditions": "Berawan Sebahagian"},
                        {"date": "2023-06-02", "temperature": 68, "conditions": "Cerah"},
                        {"date": "2023-06-03", "temperature": 62, "conditions": "Hujan"}
                    ]
                }
            }
        )
        
        # Bertindak
        response = await mcp_client.send_prompt(
            "Apa ramalan cuaca di Seattle?",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # Sahkan
        assert "Seattle" in response.generated_text
        assert "65" in response.generated_text
        assert "Cerah" in response.generated_text
        assert "Hujan" in response.generated_text
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
    // Susun
    var server = new McpServer(
        name: "TestServer",
        version: "1.0",
        maxConcurrentRequests: 100
    );
    
    server.RegisterTool(new FastExecutingTool());
    await server.StartAsync();
    
    var client = new McpClient("http://localhost:5000");
    
    // Bertindak
    var tasks = new List<Task<McpResponse>>();
    for (int i = 0; i < 1000; i++)
    {
        tasks.Add(client.ExecuteToolAsync("fastTool", new { iteration = i }));
    }
    
    var results = await Task.WhenAll(tasks);
    
    // Sahkan
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
    
    // Sediakan JMeter untuk ujian tekanan
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // Konfigurasikan pelan ujian JMeter
    HashTree testPlanTree = new HashTree();
    
    // Cipta pelan ujian, kumpulan thread, sampler, dan lain-lain
    TestPlan testPlan = new TestPlan("Ujian Tekanan Pelayan MCP");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // Tambah HTTP sampler untuk pelaksanaan alat
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // Tambah pendengar
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // Jalankan ujian
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // Sahkan keputusan
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // Masa respons purata < 200ms
    assertTrue(summaryReport.getPercentile(90.0) < 500); // Peratusan ke-90 < 500ms
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# Konfigurasikan pemantauan untuk pelayan MCP
def configure_monitoring(server):
    # Sediakan metrik Prometheus
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "Jumlah permintaan MCP"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "Tempoh permintaan dalam saat",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "Kiraan pelaksanaan alat",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "Tempoh pelaksanaan alat dalam saat",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "Ralat pelaksanaan alat",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # Tambah middleware untuk pengukuran masa dan rakaman metrik
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # Dedahkan titik akhir metrik
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
# Pelaksanaan Rantaian Alat dalam Python
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # Senarai nama alat untuk dilaksanakan secara berurutan
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # Laksanakan setiap alat dalam rantaian, menghantar hasil sebelumnya
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # Simpan hasil dan gunakan sebagai input untuk alat seterusnya
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# Contoh penggunaan
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
    public string Description => "Memproses kandungan pelbagai jenis";
    
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
        
        // Tentukan alat khusus yang akan digunakan
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // Hantar ke alat khusus
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
PERATURAN PENTING:
1. JANGAN tambah '''markdown atau sebarang tag lain di sekitar terjemahan
2. Pastikan terjemahan tidak kedengaran terlalu literal
3. Terjemahkan juga komen
4. Fail ini ditulis dalam format Markdown - jangan anggap ia sebagai XML atau HTML
5. Jangan terjemah:
   - [!NOTE], [!WARNING], [!TIP], [!IMPORTANT], [!CAUTION]
   - Nama pembolehubah, nama fungsi, nama kelas
   - Pemegang tempat seperti @@INLINE_CODE_x@@ atau @@CODE_BLOCK_x@@
   - URL atau laluan
6. Kekalkan semua format markdown asal
7. Hanya kembalikan kandungan yang diterjemah tanpa sebarang tag atau markup tambahan
Sila tulis output dari kiri ke kanan.
("code", _) => "codeAnalyzer",
_ => throw new ToolExecutionException($"Tiada alat tersedia untuk {contentType}/{operation}")
};
}

private object GetOptionsForTool(string toolName, string operation)
{
// Pulangkan pilihan yang sesuai untuk setiap alat khusus
return toolName switch
{
    "textSummarizer" => new { length = "medium" },
    "htmlProcessor" => new { cleanUp = true, operation },
    // Pilihan untuk alat lain...
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
        // Langkah 1: Dapatkan metadata dataset (secara segerak)
        ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata", 
            Map.of("datasetId", datasetId));
        
        // Langkah 2: Lancarkan beberapa analisis secara selari
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
        
        // Tunggu semua tugasan selari selesai
        CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
            statisticalAnalysis, correlationAnalysis, outlierDetection
        );
        
        allAnalyses.join();  // Tunggu sehingga selesai
        
        // Langkah 3: Gabungkan keputusan
        Map<String, Object> combinedResults = new HashMap<>();
        combinedResults.put("metadata", metadataResponse.getResult());
        combinedResults.put("statistics", statisticalAnalysis.join().getResult());
        combinedResults.put("correlations", correlationAnalysis.join().getResult());
        combinedResults.put("outliers", outlierDetection.join().getResult());
        
        // Langkah 4: Hasilkan laporan ringkasan
        ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator", 
            Map.of("analysisResults", combinedResults));
        
        // Pulangkan keputusan lengkap workflow
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
            # Cuba alat utama dahulu
            response = await self.client.execute_tool(primary_tool, parameters)
            return {
                "result": response.result,
                "source": "primary",
                "tool": primary_tool
            }
        except ToolExecutionException as e:
            # Log kegagalan
            logging.warning(f"Alat utama '{primary_tool}' gagal: {str(e)}")
            
            # Beralih ke alat sandaran
            try:
                # Mungkin perlu ubah parameter untuk alat sandaran
                fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)
                
                response = await self.client.execute_tool(fallback_tool, fallback_params)
                return {
                    "result": response.result,
                    "source": "fallback",
                    "tool": fallback_tool,
                    "primaryError": str(e)
                }
            except ToolExecutionException as fallback_error:
                # Kedua-dua alat gagal
                logging.error(f"Kedua-dua alat utama dan sandaran gagal. Ralat sandaran: {str(fallback_error)}")
                raise WorkflowExecutionException(
                    f"Workflow gagal: ralat utama: {str(e)}; ralat sandaran: {str(fallback_error)}"
                )
    
    def _adapt_parameters(self, params, from_tool, to_tool):
        """Sesuaikan parameter antara alat yang berbeza jika perlu"""
        # Pelaksanaan ini bergantung pada alat tertentu
        # Untuk contoh ini, kami hanya pulangkan parameter asal
        return params

# Contoh penggunaan
async def get_weather(workflow, location):
    return await workflow.execute_with_fallback(
        "premiumWeatherService",  # API cuaca utama (berbayar)
        "basicWeatherService",    # API cuaca sandaran (percuma)
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
            
            // Simpan keputusan setiap workflow
            results[workflow.Name] = workflowResult;
            
            // Kemas kini konteks dengan keputusan untuk workflow seterusnya
            context = context.WithResult(workflow.Name, workflowResult);
        }
        
        return new WorkflowResult(results);
    }
    
    public string Name => "CompositeWorkflow";
    public string Description => "Melaksanakan beberapa workflow secara berurutan";
}

// Contoh penggunaan
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
// Contoh ujian unit untuk alat kalkulator dalam C#
[Fact]
public async Task CalculatorTool_Add_ReturnsCorrectSum()
{
    // Susun atur
    var calculator = new CalculatorTool();
    var parameters = new Dictionary<string, object>
    {
        ["operation"] = "add",
        ["a"] = 5,
        ["b"] = 7
    };
    
    // Laksanakan
    var response = await calculator.ExecuteAsync(parameters);
    var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());
    
    // Sahkan
    Assert.Equal(12, result.Value);
}
```

```python
# Contoh ujian unit untuk alat kalkulator dalam Python
def test_calculator_tool_add():
    # Susun atur
    calculator = CalculatorTool()
    parameters = {
        "operation": "add",
        "a": 5,
        "b": 7
    }
    
    # Laksanakan
    response = calculator.execute(parameters)
    result = json.loads(response.content[0].text)
    
    # Sahkan
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
// Contoh ujian integrasi untuk server MCP dalam C#
[Fact]
public async Task Server_ProcessToolRequest_ReturnsValidResponse()
{
    // Susun atur
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
    
    // Laksanakan
    var response = await server.ProcessRequestAsync(request);
    
    // Sahkan
    Assert.NotNull(response);
    Assert.Equal(McpStatusCodes.Success, response.StatusCode);
    // Penegasan tambahan untuk kandungan respons
    
    // Bersihkan
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
// Contoh ujian E2E dengan klien dalam TypeScript
describe('Ujian E2E Server MCP', () => {
  let client: McpClient;
  
  beforeAll(async () => {
    // Mulakan server dalam persekitaran ujian
    await startTestServer();
    client = new McpClient('http://localhost:5000');
  });
  
  afterAll(async () => {
    await stopTestServer();
  });
  
  test('Klien boleh panggil alat kalkulator dan dapatkan keputusan betul', async () => {
    // Laksanakan
    const response = await client.invokeToolAsync('calculator', {
      operation: 'divide',
      a: 20,
      b: 4
    });
    
    // Sahkan
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
// Contoh C# dengan Moq
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
# Contoh Python dengan unittest.mock
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
    # Konfigurasikan mock
    mock_model.return_value.generate_response.return_value = {
        "text": "Mocked model response",
        "finish_reason": "completed"
    }
    
    # Gunakan mock dalam ujian
    server = McpServer(model_client=mock_model)
    # Teruskan dengan ujian
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
// Skrip k6 untuk ujian beban server MCP
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  vus: 10,  // 10 pengguna maya
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
    'status adalah 200': (r) => r.status === 200,
    'masa respons < 500ms': (r) => r.timings.duration < 500,
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
name: Ujian Server MCP

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
    
    - name: Sediakan Runtime
      uses: actions/setup-dotnet@v1
      with:
        dotnet-version: '8.0.x'
    
    - name: Pulihkan kebergantungan
      run: dotnet restore
    
    - name: Bina
      run: dotnet build --no-restore
    
    - name: Ujian Unit
      run: dotnet test --no-build --filter Category=Unit
    
    - name: Ujian Integrasi
      run: dotnet test --no-build --filter Category=Integration
      
    - name: Ujian Prestasi
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
    // Susun atur
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");
    
    // Laksanakan
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
    // Pengesahan skema tambahan
});
}
```

## 10 Petua Teratas untuk Ujian Server MCP yang Berkesan

1. **Uji Definisi Alat Secara Berasingan**: Sahkan definisi skema secara bebas daripada logik alat
2. **Gunakan Ujian Berparameter**: Uji alat dengan pelbagai input, termasuk kes tepi
3. **Periksa Respons Ralat**: Sahkan pengendalian ralat yang betul untuk semua keadaan ralat yang mungkin
4. **Uji Logik Kebenaran**: Pastikan kawalan akses yang betul untuk pelbagai peranan pengguna
5. **Pantau Liputan Ujian**: Sasarkan liputan tinggi untuk kod laluan kritikal
6. **Uji Respons Penstriman**: Sahkan pengendalian kandungan penstriman yang betul
7. **Simulasikan Masalah Rangkaian**: Uji tingkah laku di bawah keadaan rangkaian yang lemah
8. **Uji Had Sumber**: Sahkan tingkah laku apabila mencapai kuota atau had kadar
9. **Automatikkan Ujian Regresi**: Bina suite yang dijalankan setiap kali kod diubah
10. **Dokumentasikan Kes Ujian**: Kekalkan dokumentasi jelas bagi senario ujian

## Kesilapan Lazim dalam Ujian

- **Terlalu bergantung pada ujian laluan bahagia**: Pastikan ujian kes ralat dilakukan dengan teliti
- **Mengabaikan ujian prestasi**: Kenal pasti halangan sebelum ia menjejaskan pengeluaran
- **Ujian secara terpencil sahaja**: Gabungkan ujian unit, integrasi, dan hujung-ke-hujung
- **Liputan API tidak lengkap**: Pastikan semua titik akhir dan ciri diuji
- **Persekitaran ujian tidak konsisten**: Gunakan kontena untuk memastikan persekitaran ujian yang konsisten

## Kesimpulan

Strategi ujian yang menyeluruh adalah penting untuk membangunkan server MCP yang boleh dipercayai dan berkualiti tinggi. Dengan melaksanakan amalan terbaik dan petua yang diterangkan dalam panduan ini, anda boleh memastikan pelaksanaan MCP anda memenuhi piawaian tertinggi dari segi kualiti, kebolehpercayaan, dan prestasi.

## Perkara Penting yang Perlu Diingat

1. **Reka Bentuk Alat**: Ikuti prinsip tanggungjawab tunggal, gunakan suntikan kebergantungan, dan reka untuk kebolehgabungan
2. **Reka Bentuk Skema**: Cipta skema yang jelas, didokumenkan dengan baik dan had pengesahan yang sesuai
3. **Pengendalian Ralat**: Laksanakan pengendalian ralat yang lancar, respons ralat berstruktur, dan logik cuba semula
4. **Prestasi**: Gunakan caching, pemprosesan tak segerak, dan pengawalan sumber
5. **Keselamatan**: Terapkan pengesahan input yang teliti, pemeriksaan kebenaran, dan pengendalian data sensitif
6. **Ujian**: Cipta ujian unit, integrasi, dan hujung-ke-hujung yang menyeluruh
7. **Corak Aliran Kerja**: Gunakan corak yang telah terbukti seperti rantai, penghantar, dan pemprosesan selari

## Latihan

Reka alat MCP dan aliran kerja untuk sistem pemprosesan dokumen yang:

1. Menerima dokumen dalam pelbagai format (PDF, DOCX, TXT)
2. Mengekstrak teks dan maklumat utama dari dokumen
3. Mengklasifikasikan dokumen mengikut jenis dan kandungan
4. Menjana ringkasan bagi setiap dokumen

Laksanakan skema alat, pengendalian ralat, dan corak aliran kerja yang paling sesuai untuk senario ini. Fikirkan bagaimana anda akan menguji pelaksanaan ini.

## Sumber

1. Sertai komuniti MCP di [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs) untuk sentiasa dikemas kini dengan perkembangan terkini
2. Sumbang kepada projek sumber terbuka [MCP](https://github.com/modelcontextprotocol)
3. Terapkan prinsip MCP dalam inisiatif AI organisasi anda sendiri
4. Terokai pelaksanaan MCP khusus untuk industri anda
5. Pertimbangkan untuk mengikuti kursus lanjutan mengenai topik MCP tertentu, seperti integrasi multi-modal atau integrasi aplikasi perusahaan
6. Cuba bina alat dan aliran kerja MCP anda sendiri menggunakan prinsip yang dipelajari melalui [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

Seterusnya: Amalan Terbaik [kajian kes](../09-CaseStudy/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.