<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "80e5c8949af5af0f401fce6f905990aa",
  "translation_date": "2025-07-17T07:49:35+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "id"
}
-->
# Praktik Terbaik Pengembangan MCP

## Ikhtisar

Pelajaran ini berfokus pada praktik terbaik lanjutan untuk mengembangkan, menguji, dan menerapkan server dan fitur MCP di lingkungan produksi. Seiring ekosistem MCP yang semakin kompleks dan penting, mengikuti pola yang sudah mapan memastikan keandalan, kemudahan pemeliharaan, dan interoperabilitas. Pelajaran ini mengkonsolidasikan kebijaksanaan praktis yang diperoleh dari implementasi MCP di dunia nyata untuk membimbing Anda dalam menciptakan server yang tangguh dan efisien dengan sumber daya, prompt, dan alat yang efektif.

## Tujuan Pembelajaran

Pada akhir pelajaran ini, Anda akan mampu:
- Menerapkan praktik terbaik industri dalam desain server dan fitur MCP
- Membuat strategi pengujian komprehensif untuk server MCP
- Merancang pola alur kerja yang efisien dan dapat digunakan ulang untuk aplikasi MCP yang kompleks
- Menerapkan penanganan kesalahan, pencatatan, dan observabilitas yang tepat pada server MCP
- Mengoptimalkan implementasi MCP untuk kinerja, keamanan, dan kemudahan pemeliharaan

## Prinsip Inti MCP

Sebelum masuk ke praktik implementasi spesifik, penting untuk memahami prinsip inti yang membimbing pengembangan MCP yang efektif:

1. **Komunikasi Standar**: MCP menggunakan JSON-RPC 2.0 sebagai dasar, menyediakan format konsisten untuk permintaan, respons, dan penanganan kesalahan di semua implementasi.

2. **Desain Berorientasi Pengguna**: Selalu prioritaskan persetujuan, kontrol, dan transparansi pengguna dalam implementasi MCP Anda.

3. **Keamanan Utama**: Terapkan langkah keamanan yang kuat termasuk autentikasi, otorisasi, validasi, dan pembatasan laju.

4. **Arsitektur Modular**: Rancang server MCP Anda dengan pendekatan modular, di mana setiap alat dan sumber daya memiliki tujuan yang jelas dan terfokus.

5. **Koneksi Stateful**: Manfaatkan kemampuan MCP untuk mempertahankan status di antara beberapa permintaan agar interaksi lebih koheren dan kontekstual.

## Praktik Terbaik Resmi MCP

Praktik terbaik berikut diambil dari dokumentasi resmi Model Context Protocol:

### Praktik Terbaik Keamanan

1. **Persetujuan dan Kontrol Pengguna**: Selalu minta persetujuan eksplisit pengguna sebelum mengakses data atau melakukan operasi. Berikan kontrol yang jelas atas data apa yang dibagikan dan tindakan apa yang diizinkan.

2. **Privasi Data**: Hanya tampilkan data pengguna dengan persetujuan eksplisit dan lindungi dengan kontrol akses yang sesuai. Lindungi dari transmisi data yang tidak sah.

3. **Keamanan Alat**: Minta persetujuan eksplisit pengguna sebelum memanggil alat apa pun. Pastikan pengguna memahami fungsi setiap alat dan terapkan batasan keamanan yang kuat.

4. **Kontrol Izin Alat**: Konfigurasikan alat mana yang diizinkan digunakan model selama sesi, memastikan hanya alat yang secara eksplisit diotorisasi yang dapat diakses.

5. **Autentikasi**: Minta autentikasi yang tepat sebelum memberikan akses ke alat, sumber daya, atau operasi sensitif menggunakan kunci API, token OAuth, atau metode autentikasi aman lainnya.

6. **Validasi Parameter**: Terapkan validasi untuk semua pemanggilan alat guna mencegah input yang salah format atau berbahaya mencapai implementasi alat.

7. **Pembatasan Laju**: Terapkan pembatasan laju untuk mencegah penyalahgunaan dan memastikan penggunaan sumber daya server yang adil.

### Praktik Terbaik Implementasi

1. **Negosiasi Kapabilitas**: Saat pengaturan koneksi, tukar informasi tentang fitur yang didukung, versi protokol, alat, dan sumber daya yang tersedia.

2. **Desain Alat**: Buat alat yang terfokus yang melakukan satu hal dengan baik, bukan alat monolitik yang menangani banyak hal sekaligus.

3. **Penanganan Kesalahan**: Terapkan pesan dan kode kesalahan standar untuk membantu mendiagnosis masalah, menangani kegagalan dengan baik, dan memberikan umpan balik yang dapat ditindaklanjuti.

4. **Pencatatan**: Konfigurasikan log terstruktur untuk audit, debugging, dan pemantauan interaksi protokol.

5. **Pelacakan Progres**: Untuk operasi yang berjalan lama, laporkan pembaruan progres agar antarmuka pengguna responsif.

6. **Pembatalan Permintaan**: Izinkan klien membatalkan permintaan yang sedang berjalan yang tidak lagi diperlukan atau memakan waktu terlalu lama.

## Referensi Tambahan

Untuk informasi terbaru tentang praktik terbaik MCP, lihat:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)
- [Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## Contoh Implementasi Praktis

### Praktik Terbaik Desain Alat

#### 1. Prinsip Tanggung Jawab Tunggal

Setiap alat MCP harus memiliki tujuan yang jelas dan terfokus. Daripada membuat alat monolitik yang mencoba menangani banyak hal sekaligus, kembangkan alat khusus yang unggul dalam tugas tertentu.

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

#### 2. Penanganan Kesalahan Konsisten

Terapkan penanganan kesalahan yang kuat dengan pesan kesalahan yang informatif dan mekanisme pemulihan yang sesuai.

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

#### 3. Validasi Parameter

Selalu validasi parameter secara menyeluruh untuk mencegah input yang salah format atau berbahaya.

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

### Contoh Implementasi Keamanan

#### 1. Autentikasi dan Otorisasi

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

#### 2. Pembatasan Laju

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

## Praktik Terbaik Pengujian

### 1. Unit Testing Alat MCP

Selalu uji alat Anda secara terpisah, dengan memalsukan dependensi eksternal:

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

### 2. Integration Testing

Uji alur lengkap dari permintaan klien hingga respons server:

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

## Optimasi Kinerja

### 1. Strategi Caching

Terapkan caching yang sesuai untuk mengurangi latensi dan penggunaan sumber daya:

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
// Contoh Java dengan dependency injection
public class CurrencyConversionTool implements Tool {
    private final ExchangeRateService exchangeService;
    private final CacheService cacheService;
    private final Logger logger;
    
    // Dependensi disuntikkan melalui konstruktor
    public CurrencyConversionTool(
            ExchangeRateService exchangeService,
            CacheService cacheService,
            Logger logger) {
        this.exchangeService = exchangeService;
        this.cacheService = cacheService;
        this.logger = logger;
    }
    
    // Implementasi alat
    // ...
}
```

#### 3. Composable Tools

Design tools that can be composed together to create more complex workflows:

```python
# Contoh Python yang menunjukkan alat yang dapat dikomposisi
class DataFetchTool(Tool):
    def get_name(self):
        return "dataFetch"
    
    # Implementasi...

class DataAnalysisTool(Tool):
    def get_name(self):
        return "dataAnalysis"
    
    # Alat ini dapat menggunakan hasil dari alat dataFetch
    async def execute_async(self, request):
        # Implementasi...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # Alat ini dapat menggunakan hasil dari alat dataAnalysis
    async def execute_async(self, request):
        # Implementasi...
        pass

# Alat-alat ini dapat digunakan secara mandiri atau sebagai bagian dari alur kerja
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
                description = "Teks kueri pencarian. Gunakan kata kunci yang tepat untuk hasil yang lebih baik." 
            },
            filters = new {
                type = "object",
                description = "Filter opsional untuk mempersempit hasil pencarian",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "Rentang tanggal dalam format YYYY-MM-DD:YYYY-MM-DD" 
                    },
                    category = new { 
                        type = "string", 
                        description = "Nama kategori untuk difilter" 
                    }
                }
            },
            limit = new { 
                type = "integer", 
                description = "Jumlah maksimum hasil yang dikembalikan (1-50)",
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
    
    // Properti email dengan validasi format
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "Alamat email pengguna");
    
    // Properti umur dengan batasan numerik
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
    subscription.put("description", "Tingkat langganan");
    
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
        
        # Selalu kembalikan struktur yang konsisten
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
    """Memastikan setiap item memiliki struktur yang konsisten"""
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
            throw new ToolExecutionException($"File tidak ditemukan: {fileId}");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ToolExecutionException("Anda tidak memiliki izin untuk mengakses file ini");
        }
        catch (Exception ex) when (ex is IOException || ex is TimeoutException)
        {
            _logger.LogError(ex, "Kesalahan mengakses file {FileId}", fileId);
            throw new ToolExecutionException("Kesalahan mengakses file: Layanan sementara tidak tersedia");
        }
    }
    catch (JsonException)
    {
        throw new ToolExecutionException("Format ID file tidak valid");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Kesalahan tak terduga di FileAccessTool");
        throw new ToolExecutionException("Terjadi kesalahan tak terduga");
    }
}
```

#### 2. Structured Error Responses

Return structured error information when possible:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    try {
        // Implementasi
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
        
        // Lempar ulang exception lain sebagai ToolExecutionException
        throw new ToolExecutionException("Eksekusi alat gagal: " + ex.getMessage(), ex);
    }
}
```

#### 3. Retry Logic

Implement appropriate retry logic for transient failures:

```python
async def execute_async(self, request):
    max_retries = 3
    retry_count = 0
    base_delay = 1  # detik
    
    while retry_count < max_retries:
        try:
            # Panggil API eksternal
            return await self._call_api(request.parameters)
        except TransientError as e:
            retry_count += 1
            if retry_count >= max_retries:
                raise ToolExecutionException(f"Operasi gagal setelah {max_retries} percobaan: {str(e)}")
                
            # Penundaan eksponensial
            delay = base_delay * (2 ** (retry_count - 1))
            logging.warning(f"Kesalahan sementara, mencoba ulang dalam {delay}s: {str(e)}")
            await asyncio.sleep(delay)
        except Exception as e:
            # Kesalahan non-sementara, tidak mencoba ulang
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
        
        // Buat cache key berdasarkan parameter
        var cacheKey = $"data_query_{ComputeHash(query)}";
        
        // Coba ambil dari cache terlebih dahulu
        if (_cache.TryGetValue(cacheKey, out var cachedResult))
        {
            return new ToolResponse { Result = cachedResult };
        }
        
        // Cache tidak ditemukan - lakukan query sebenarnya
        var result = await _database.QueryAsync(query);
        
        // Simpan di cache dengan masa berlaku
        var cacheOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
            
        _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
        
        return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
    }
    
    private string ComputeHash(string input)
    {
        // Implementasi untuk menghasilkan hash stabil sebagai cache key
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
        
        // Untuk operasi yang berjalan lama, langsung kembalikan ID proses
        String processId = UUID.randomUUID().toString();
        
        // Mulai pemrosesan async
        CompletableFuture.runAsync(() -> {
            try {
                // Lakukan operasi yang berjalan lama
                documentService.processDocument(documentId);
                
                // Perbarui status (biasanya disimpan di database)
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
    
    // Alat pendamping untuk pengecekan status
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
            tokens_per_second=5,  # Izinkan 5 permintaan per detik
            bucket_size=10        # Izinkan lonjakan hingga 10 permintaan
        )
    
    async def execute_async(self, request):
        # Periksa apakah bisa lanjut atau harus menunggu
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # Jika waktu tunggu terlalu lama
                raise ToolExecutionException(
                    f"Batas kecepatan terlampaui. Silakan coba lagi dalam {delay:.1f} detik."
                )
            else:
                # Tunggu sesuai waktu delay yang diperlukan
                await asyncio.sleep(delay)
        
        # Konsumsi token dan lanjutkan permintaan
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
            
            # Hitung waktu sampai token berikutnya tersedia
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # Tambahkan token baru berdasarkan waktu yang berlalu
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
    // Validasi parameter ada
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("Parameter yang dibutuhkan: query tidak ditemukan");
    }
    
    // Validasi tipe yang benar
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("Parameter query harus berupa string");
    }
    
    var query = queryProp.GetString();
    
    // Validasi isi string
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("Parameter query tidak boleh kosong");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("Parameter query melebihi panjang maksimum 500 karakter");
    }
    
    // Periksa serangan SQL injection jika berlaku
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("Query tidak valid: mengandung SQL yang berpotensi berbahaya");
    }
    
    // Lanjutkan eksekusi
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // Ambil konteks pengguna dari request
    UserContext user = request.getContext().getUserContext();
    
    // Periksa apakah pengguna memiliki izin yang dibutuhkan
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("Pengguna tidak memiliki izin untuk mengakses dokumen");
    }
    
    // Untuk sumber daya tertentu, periksa akses ke sumber daya tersebut
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("Akses ke dokumen yang diminta ditolak");
    }
    
    // Lanjutkan eksekusi alat
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
        
        # Ambil data pengguna
        user_data = await self.user_service.get_user_data(user_id)
        
        # Saring field sensitif kecuali diminta secara eksplisit DAN berwenang
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # Periksa level otorisasi dalam konteks request
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # Buat salinan agar tidak mengubah data asli
        redacted = user_data.copy()
        
        # Sensor field sensitif tertentu
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # Sensor data sensitif yang bersarang
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
    // Siapkan
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("Seattle", 3))
        .ReturnsAsync(new WeatherForecast(/* data uji */));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "Seattle", 
            days = 3 
        })
    );
    
    // Eksekusi
    var response = await tool.ExecuteAsync(request);
    
    // Verifikasi
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // Siapkan
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("InvalidLocation", It.IsAny<int>()))
        .ThrowsAsync(new LocationNotFoundException("Lokasi tidak ditemukan"));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "InvalidLocation", 
            days = 3 
        })
    );
    
    // Eksekusi & Verifikasi
    var exception = await Assert.ThrowsAsync<ToolExecutionException>(
        () => tool.ExecuteAsync(request)
    );
    
    Assert.Contains("Lokasi tidak ditemukan", exception.Message);
}
```

#### 2. Schema Validation Testing

Test that schemas are valid and properly enforce constraints:

```java
@Test
public void testSchemaValidation() {
    // Buat instance alat
    SearchTool searchTool = new SearchTool();
    
    // Ambil skema
    Object schema = searchTool.getSchema();
    
    // Konversi skema ke JSON untuk validasi
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // Validasi skema adalah JSONSchema yang valid
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // Uji parameter yang valid
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
    
    // Uji tipe parameter yang tidak valid
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
    # Siapkan
    tool = ApiTool(timeout=0.1)  # Timeout sangat singkat
    
    # Mock permintaan yang akan timeout
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # Lebih lama dari timeout
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # Eksekusi & Verifikasi
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Verifikasi pesan exception
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # Siapkan
    tool = ApiTool()
    
    # Mock respons yang dibatasi rate limit
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
        
        # Eksekusi & Verifikasi
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Verifikasi exception mengandung info rate limit
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
    // Siapkan
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // Eksekusi
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
        // Uji endpoint discovery
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // Buat permintaan tool
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // Kirim permintaan dan verifikasi respons
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // Buat permintaan tool yang tidak valid
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // Parameter "b" hilang
        request.put("parameters", parameters);
        
        // Kirim permintaan dan verifikasi respons error
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
    # Arrange - Siapkan klien MCP dan model mock
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # Mock respons model
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
    
    # Mock respons tool cuaca
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
        
        # Act
        response = await mcp_client.send_prompt(
            "What's the weather in Seattle?",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # Assert
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
    // Arrange
    var server = new McpServer(
        name: "TestServer",
        version: "1.0",
        maxConcurrentRequests: 100
    );
    
    server.RegisterTool(new FastExecutingTool());
    await server.StartAsync();
    
    var client = new McpClient("http://localhost:5000");
    
    // Act
    var tasks = new List<Task<McpResponse>>();
    for (int i = 0; i < 1000; i++)
    {
        tasks.Add(client.ExecuteToolAsync("fastTool", new { iteration = i }));
    }
    
    var results = await Task.WhenAll(tasks);
    
    // Assert
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
    
    // Siapkan JMeter untuk pengujian beban
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // Konfigurasikan rencana pengujian JMeter
    HashTree testPlanTree = new HashTree();
    
    // Buat rencana pengujian, thread group, sampler, dll.
    TestPlan testPlan = new TestPlan("MCP Server Stress Test");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // Tambahkan HTTP sampler untuk eksekusi tool
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // Tambahkan listener
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // Jalankan pengujian
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // Validasi hasil
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // Waktu respons rata-rata < 200ms
    assertTrue(summaryReport.getPercentile(90.0) < 500); // Persentil ke-90 < 500ms
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# Konfigurasikan monitoring untuk server MCP
def configure_monitoring(server):
    # Siapkan metrik Prometheus
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "Total permintaan MCP"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "Durasi permintaan dalam detik",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "Jumlah eksekusi tool",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "Durasi eksekusi tool dalam detik",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "Kesalahan eksekusi tool",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # Tambahkan middleware untuk pengukuran waktu dan pencatatan metrik
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # Ekspos endpoint metrik
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
# Implementasi Chain of Tools di Python
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # Daftar nama tool yang akan dijalankan berurutan
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # Jalankan setiap tool dalam rantai, meneruskan hasil sebelumnya
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # Simpan hasil dan gunakan sebagai input untuk tool berikutnya
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
    public string Description => "Memproses konten dari berbagai jenis";
    
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
        
        // Tentukan tool khusus yang akan digunakan
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // Teruskan ke tool khusus tersebut
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
# Panduan Pengguna csvProcessor

Selamat datang di dokumentasi resmi untuk **csvProcessor**, alat yang dirancang untuk memudahkan pengolahan file CSV Anda.

## Fitur Utama

- Membaca dan menulis file CSV dengan cepat dan efisien
- Mendukung berbagai format delimiter
- Memungkinkan filter dan transformasi data secara fleksibel
- Integrasi mudah dengan pipeline data Anda

## Cara Menggunakan

1. Impor modul csvProcessor ke dalam proyek Anda.
2. Gunakan fungsi `loadCSV()` untuk memuat file CSV.
3. Terapkan filter atau transformasi menggunakan metode yang tersedia.
4. Simpan hasilnya dengan `saveCSV()`.

```python
from csvProcessor import loadCSV, saveCSV

data = loadCSV('data.csv')
filtered_data = data.filter(lambda row: int(row['age']) > 30)
saveCSV(filtered_data, 'filtered_data.csv')
```

## Tips dan Trik

- [!TIP] Gunakan parameter `delimiter` untuk menyesuaikan pemisah kolom jika file CSV Anda tidak menggunakan koma.
- [!IMPORTANT] Pastikan file CSV Anda memiliki header agar fungsi filter dapat bekerja dengan benar.

## Troubleshooting

- [!WARNING] Jika Anda mengalami error saat memuat file, periksa apakah path file sudah benar dan file tidak sedang digunakan oleh aplikasi lain.
- Jika data tidak terfilter sesuai harapan, cek kembali fungsi lambda yang Anda gunakan.

## Dukungan

Untuk bantuan lebih lanjut, kunjungi halaman dokumentasi resmi atau hubungi tim support kami melalui email support@csvprocessor.com.

Terima kasih telah menggunakan csvProcessor!
("code", _) => "codeAnalyzer",
_ => throw new ToolExecutionException($"Tidak ada alat yang tersedia untuk {contentType}/{operation}")
};
}

private object GetOptionsForTool(string toolName, string operation)
{
// Kembalikan opsi yang sesuai untuk setiap alat khusus
return toolName switch
{
    "textSummarizer" => new { length = "medium" },
    "htmlProcessor" => new { cleanUp = true, operation },
    // Opsi untuk alat lain...
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
        // Langkah 1: Ambil metadata dataset (sinkron)
        ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata", 
            Map.of("datasetId", datasetId));
        
        // Langkah 2: Jalankan beberapa analisis secara paralel
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
        
        // Tunggu semua tugas paralel selesai
        CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
            statisticalAnalysis, correlationAnalysis, outlierDetection
        );
        
        allAnalyses.join();  // Tunggu penyelesaian
        
        // Langkah 3: Gabungkan hasil
        Map<String, Object> combinedResults = new HashMap<>();
        combinedResults.put("metadata", metadataResponse.getResult());
        combinedResults.put("statistics", statisticalAnalysis.join().getResult());
        combinedResults.put("correlations", correlationAnalysis.join().getResult());
        combinedResults.put("outliers", outlierDetection.join().getResult());
        
        // Langkah 4: Buat laporan ringkasan
        ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator", 
            Map.of("analysisResults", combinedResults));
        
        // Kembalikan hasil workflow lengkap
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
            # Coba alat utama terlebih dahulu
            response = await self.client.execute_tool(primary_tool, parameters)
            return {
                "result": response.result,
                "source": "primary",
                "tool": primary_tool
            }
        except ToolExecutionException as e:
            # Catat kegagalan
            logging.warning(f"Alat utama '{primary_tool}' gagal: {str(e)}")
            
            # Beralih ke alat cadangan
            try:
                # Mungkin perlu mengubah parameter untuk alat cadangan
                fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)
                
                response = await self.client.execute_tool(fallback_tool, fallback_params)
                return {
                    "result": response.result,
                    "source": "fallback",
                    "tool": fallback_tool,
                    "primaryError": str(e)
                }
            except ToolExecutionException as fallback_error:
                # Kedua alat gagal
                logging.error(f"Kedua alat utama dan cadangan gagal. Error cadangan: {str(fallback_error)}")
                raise WorkflowExecutionException(
                    f"Workflow gagal: error utama: {str(e)}; error cadangan: {str(fallback_error)}"
                )
    
    def _adapt_parameters(self, params, from_tool, to_tool):
        """Sesuaikan parameter antar alat jika diperlukan"""
        # Implementasi ini tergantung pada alat spesifik
        # Untuk contoh ini, kita kembalikan parameter asli saja
        return params

# Contoh penggunaan
async def get_weather(workflow, location):
    return await workflow.execute_with_fallback(
        "premiumWeatherService",  # API cuaca utama (berbayar)
        "basicWeatherService",    # API cuaca cadangan (gratis)
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
            
            // Simpan hasil setiap workflow
            results[workflow.Name] = workflowResult;
            
            // Perbarui konteks dengan hasil untuk workflow berikutnya
            context = context.WithResult(workflow.Name, workflowResult);
        }
        
        return new WorkflowResult(results);
    }
    
    public string Name => "CompositeWorkflow";
    public string Description => "Menjalankan beberapa workflow secara berurutan";
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
// Contoh unit test untuk alat kalkulator di C#
[Fact]
public async Task CalculatorTool_Add_ReturnsCorrectSum()
{
    // Persiapan
    var calculator = new CalculatorTool();
    var parameters = new Dictionary<string, object>
    {
        ["operation"] = "add",
        ["a"] = 5,
        ["b"] = 7
    };
    
    // Eksekusi
    var response = await calculator.ExecuteAsync(parameters);
    var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());
    
    // Verifikasi
    Assert.Equal(12, result.Value);
}
```

```python
# Contoh unit test untuk alat kalkulator di Python
def test_calculator_tool_add():
    # Persiapan
    calculator = CalculatorTool()
    parameters = {
        "operation": "add",
        "a": 5,
        "b": 7
    }
    
    # Eksekusi
    response = calculator.execute(parameters)
    result = json.loads(response.content[0].text)
    
    # Verifikasi
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
// Contoh integration test untuk server MCP di C#
[Fact]
public async Task Server_ProcessToolRequest_ReturnsValidResponse()
{
    // Persiapan
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
    
    // Eksekusi
    var response = await server.ProcessRequestAsync(request);
    
    // Verifikasi
    Assert.NotNull(response);
    Assert.Equal(McpStatusCodes.Success, response.StatusCode);
    // Verifikasi tambahan untuk isi respons
    
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
// Contoh E2E test dengan client di TypeScript
describe('MCP Server E2E Tests', () => {
  let client: McpClient;
  
  beforeAll(async () => {
    // Mulai server di lingkungan test
    await startTestServer();
    client = new McpClient('http://localhost:5000');
  });
  
  afterAll(async () => {
    await stopTestServer();
  });
  
  test('Client dapat memanggil alat kalkulator dan mendapatkan hasil yang benar', async () => {
    // Eksekusi
    const response = await client.invokeToolAsync('calculator', {
      operation: 'divide',
      a: 20,
      b: 4
    });
    
    // Verifikasi
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
    # Konfigurasi mock
    mock_model.return_value.generate_response.return_value = {
        "text": "Mocked model response",
        "finish_reason": "completed"
    }
    
    # Gunakan mock dalam test
    server = McpServer(model_client=mock_model)
    # Lanjutkan dengan test
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
// Skrip k6 untuk load testing server MCP
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  vus: 10,  // 10 pengguna virtual
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
    'waktu respons < 500ms': (r) => r.timings.duration < 500,
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
    // Persiapan
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");
    
    // Eksekusi
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
    // Validasi skema tambahan  
});  
}  
```

## 10 Tips Teratas untuk Pengujian Server MCP yang Efektif

1. **Uji Definisi Alat Secara Terpisah**: Verifikasi definisi skema secara mandiri dari logika alat  
2. **Gunakan Tes Parameterisasi**: Uji alat dengan berbagai input, termasuk kasus ekstrem  
3. **Periksa Respons Kesalahan**: Pastikan penanganan kesalahan yang tepat untuk semua kondisi error  
4. **Uji Logika Otorisasi**: Pastikan kontrol akses yang benar untuk berbagai peran pengguna  
5. **Pantau Cakupan Tes**: Usahakan cakupan tinggi pada kode jalur kritis  
6. **Uji Respons Streaming**: Verifikasi penanganan konten streaming yang tepat  
7. **Simulasikan Masalah Jaringan**: Uji perilaku di bawah kondisi jaringan yang buruk  
8. **Uji Batasan Sumber Daya**: Verifikasi perilaku saat mencapai kuota atau batas laju  
9. **Otomatisasi Tes Regresi**: Bangun rangkaian tes yang berjalan setiap kali ada perubahan kode  
10. **Dokumentasikan Kasus Tes**: Pertahankan dokumentasi yang jelas untuk skenario pengujian  

## Kesalahan Umum dalam Pengujian

- **Terlalu mengandalkan pengujian jalur bahagia**: Pastikan menguji kasus kesalahan secara menyeluruh  
- **Mengabaikan pengujian performa**: Identifikasi hambatan sebelum berdampak pada produksi  
- **Hanya menguji secara terpisah**: Gabungkan tes unit, integrasi, dan end-to-end  
- **Cakupan API yang tidak lengkap**: Pastikan semua endpoint dan fitur diuji  
- **Lingkungan tes yang tidak konsisten**: Gunakan container untuk memastikan lingkungan tes yang konsisten  

## Kesimpulan

Strategi pengujian yang komprehensif sangat penting untuk mengembangkan server MCP yang andal dan berkualitas tinggi. Dengan menerapkan praktik terbaik dan tips yang dijelaskan dalam panduan ini, Anda dapat memastikan implementasi MCP Anda memenuhi standar tertinggi dalam kualitas, keandalan, dan performa.  

## Poin Penting

1. **Desain Alat**: Ikuti prinsip tanggung jawab tunggal, gunakan dependency injection, dan desain untuk komposabilitas  
2. **Desain Skema**: Buat skema yang jelas, terdokumentasi dengan baik, dan batasan validasi yang tepat  
3. **Penanganan Kesalahan**: Terapkan penanganan kesalahan yang elegan, respons kesalahan terstruktur, dan logika retry  
4. **Performa**: Gunakan caching, pemrosesan asinkron, dan pembatasan sumber daya  
5. **Keamanan**: Terapkan validasi input yang menyeluruh, pemeriksaan otorisasi, dan penanganan data sensitif  
6. **Pengujian**: Buat tes unit, integrasi, dan end-to-end yang komprehensif  
7. **Pola Alur Kerja**: Terapkan pola yang sudah mapan seperti chains, dispatchers, dan pemrosesan paralel  

## Latihan

Rancang alat MCP dan alur kerja untuk sistem pemrosesan dokumen yang:

1. Menerima dokumen dalam berbagai format (PDF, DOCX, TXT)  
2. Mengekstrak teks dan informasi kunci dari dokumen  
3. Mengklasifikasikan dokumen berdasarkan tipe dan isi  
4. Menghasilkan ringkasan dari setiap dokumen  

Implementasikan skema alat, penanganan kesalahan, dan pola alur kerja yang paling sesuai dengan skenario ini. Pertimbangkan bagaimana Anda akan menguji implementasi ini.  

## Sumber Daya

1. Bergabunglah dengan komunitas MCP di [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs) untuk mendapatkan update terbaru  
2. Berkontribusi pada proyek open-source [MCP](https://github.com/modelcontextprotocol)  
3. Terapkan prinsip MCP dalam inisiatif AI organisasi Anda sendiri  
4. Jelajahi implementasi MCP khusus untuk industri Anda  
5. Pertimbangkan mengikuti kursus lanjutan tentang topik MCP tertentu, seperti integrasi multi-modal atau integrasi aplikasi enterprise  
6. Bereksperimenlah membangun alat dan alur kerja MCP Anda sendiri menggunakan prinsip yang dipelajari melalui [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)  

Selanjutnya: Studi Kasus Praktik Terbaik [case studies](../09-CaseStudy/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk akurasi, harap diketahui bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang keliru yang timbul dari penggunaan terjemahan ini.