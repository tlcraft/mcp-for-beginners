<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "80e5c8949af5af0f401fce6f905990aa",
  "translation_date": "2025-07-17T10:20:31+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "hu"
}
-->
# MCP Fejlesztési Legjobb Gyakorlatok

## Áttekintés

Ez a lecke az MCP szerverek és funkciók fejlesztésének, tesztelésének és éles környezetbe történő telepítésének haladó legjobb gyakorlataira fókuszál. Ahogy az MCP ökoszisztémák egyre összetettebbé és fontosabbá válnak, a bevált minták követése biztosítja a megbízhatóságot, karbantarthatóságot és interoperabilitást. Ez a lecke a valós MCP megvalósításokból származó gyakorlati tapasztalatokat foglalja össze, hogy segítsen robusztus, hatékony szervereket létrehozni megfelelő erőforrásokkal, promptokkal és eszközökkel.

## Tanulási Célok

A lecke végére képes leszel:
- Iparági legjobb gyakorlatokat alkalmazni MCP szerverek és funkciók tervezésében
- Átfogó tesztelési stratégiákat kidolgozni MCP szerverekhez
- Hatékony, újrahasznosítható munkafolyamat-mintákat tervezni összetett MCP alkalmazásokhoz
- Megfelelő hibakezelést, naplózást és megfigyelhetőséget megvalósítani MCP szerverekben
- Optimalizálni az MCP megvalósításokat teljesítmény, biztonság és karbantarthatóság szempontjából

## MCP Alapelvek

Mielőtt a konkrét megvalósítási gyakorlatokba mélyednénk, fontos megérteni azokat az alapelveket, amelyek az eredményes MCP fejlesztést irányítják:

1. **Standardizált Kommunikáció**: Az MCP a JSON-RPC 2.0-t használja alapként, amely egységes formátumot biztosít a kérések, válaszok és hibakezelés számára minden megvalósításban.

2. **Felhasználó-központú Tervezés**: Mindig helyezd előtérbe a felhasználói beleegyezést, kontrollt és átláthatóságot az MCP megvalósításaidban.

3. **Biztonság Elsőként**: Erős biztonsági intézkedéseket alkalmazz, beleértve az autentikációt, jogosultságkezelést, validációt és a sebességkorlátozást.

4. **Moduláris Architektúra**: Tervezd MCP szervereidet moduláris megközelítéssel, ahol minden eszköznek és erőforrásnak világos, fókuszált célja van.

5. **Állapotmegőrző Kapcsolatok**: Használd ki az MCP képességét, hogy több kérésen át megőrizze az állapotot, így koherensebb és kontextusérzékenyebb interakciókat biztosítva.

## Hivatalos MCP Legjobb Gyakorlatok

Az alábbi legjobb gyakorlatok az hivatalos Model Context Protocol dokumentációból származnak:

### Biztonsági Legjobb Gyakorlatok

1. **Felhasználói Beleegyezés és Kontroll**: Mindig kérj kifejezett felhasználói beleegyezést az adatok eléréséhez vagy műveletek végrehajtásához. Biztosíts világos kontrollt arról, hogy milyen adatokat osztanak meg és mely műveletek engedélyezettek.

2. **Adatvédelem**: Csak kifejezett beleegyezéssel tedd elérhetővé a felhasználói adatokat, és védd azokat megfelelő hozzáférés-ellenőrzéssel. Védj az illetéktelen adatátvitel ellen.

3. **Eszközbiztonság**: Minden eszköz meghívása előtt kérj kifejezett felhasználói beleegyezést. Biztosítsd, hogy a felhasználók megértsék az eszközök működését, és érvényesíts erős biztonsági határokat.

4. **Eszköz Jogosultságkezelés**: Állítsd be, hogy egy modell mely eszközöket használhatja egy munkamenet során, biztosítva, hogy csak kifejezetten engedélyezett eszközök legyenek elérhetők.

5. **Autentikáció**: Mielőtt hozzáférést adsz eszközökhöz, erőforrásokhoz vagy érzékeny műveletekhez, kérj megfelelő autentikációt API kulcsokkal, OAuth tokenekkel vagy más biztonságos hitelesítési módszerekkel.

6. **Paraméter Validáció**: Minden eszköz meghívásánál érvényesíts validációt, hogy megakadályozd a hibás vagy rosszindulatú bemenetek eljutását az eszközmegvalósításokhoz.

7. **Sebességkorlátozás**: Vezess be sebességkorlátozást a visszaélések megelőzésére és a szerver erőforrások igazságos használatának biztosítására.

### Megvalósítási Legjobb Gyakorlatok

1. **Képesség Egyeztetés**: A kapcsolat létrehozásakor cseréljetek információt a támogatott funkciókról, protokoll verziókról, elérhető eszközökről és erőforrásokról.

2. **Eszköz Tervezés**: Készíts fókuszált eszközöket, amelyek egy dolgot jól csinálnak, ahelyett, hogy monolitikus eszközök több feladatot próbálnának kezelni.

3. **Hibakezelés**: Valósíts meg szabványosított hibaüzeneteket és kódokat, hogy segítsék a problémák diagnosztizálását, a hibák elegáns kezelését és a hasznos visszajelzést.

4. **Naplózás**: Állíts be strukturált naplókat az auditáláshoz, hibakereséshez és a protokoll interakciók megfigyeléséhez.

5. **Folyamatkövetés**: Hosszú futású műveleteknél jelentess előrehaladási frissítéseket a reszponzív felhasználói felületek érdekében.

6. **Kérés Megszakítás**: Engedélyezd a klienseknek, hogy megszakítsák a már nem szükséges vagy túl hosszú ideig tartó folyamatban lévő kéréseket.

## További Hivatkozások

A legfrissebb információkért az MCP legjobb gyakorlatokról, tekintsd meg:
- [MCP Dokumentáció](https://modelcontextprotocol.io/)
- [MCP Specifikáció](https://spec.modelcontextprotocol.io/)
- [GitHub Tároló](https://github.com/modelcontextprotocol)
- [Biztonsági Legjobb Gyakorlatok](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## Gyakorlati Megvalósítási Példák

### Eszköz Tervezési Legjobb Gyakorlatok

#### 1. Egyetlen Felelősség Elve

Minden MCP eszköznek világos, fókuszált céllal kell rendelkeznie. Ahelyett, hogy monolitikus eszközöket hoznál létre, amelyek több feladatot próbálnak kezelni, fejlessz specializált eszközöket, amelyek egy adott feladatban kiemelkedőek.

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

#### 2. Következetes Hibakezelés

Valósíts meg robusztus hibakezelést informatív hibaüzenetekkel és megfelelő helyreállítási mechanizmusokkal.

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

#### 3. Paraméter Validáció

Mindig alaposan validáld a paramétereket, hogy megakadályozd a hibás vagy rosszindulatú bemeneteket.

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

### Biztonsági Megvalósítási Példák

#### 1. Autentikáció és Jogosultságkezelés

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

#### 2. Sebességkorlátozás

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

## Tesztelési Legjobb Gyakorlatok

### 1. Egységtesztelés MCP Eszközökhöz

Mindig teszteld az eszközeidet izoláltan, külső függőségeket mockolva:

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

### 2. Integrációs Tesztelés

Teszteld a teljes folyamatot a kliens kéréseitől a szerver válaszáig:

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

## Teljesítmény Optimalizálás

### 1. Gyorsítótárazási Stratégiák

Alkalmazz megfelelő gyorsítótárazást a késleltetés és az erőforrás-felhasználás csökkentésére:

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
// Java példa függőség-injektálással
public class CurrencyConversionTool implements Tool {
    private final ExchangeRateService exchangeService;
    private final CacheService cacheService;
    private final Logger logger;
    
    // Függőségek konstruktoron keresztül injektálva
    public CurrencyConversionTool(
            ExchangeRateService exchangeService,
            CacheService cacheService,
            Logger logger) {
        this.exchangeService = exchangeService;
        this.cacheService = cacheService;
        this.logger = logger;
    }
    
    // Eszköz megvalósítása
    // ...
}
```

#### 3. Composable Tools

Design tools that can be composed together to create more complex workflows:

```python
# Python példa összetett eszközökre
class DataFetchTool(Tool):
    def get_name(self):
        return "dataFetch"
    
    # Megvalósítás...

class DataAnalysisTool(Tool):
    def get_name(self):
        return "dataAnalysis"
    
    # Ez az eszköz használhatja a dataFetch eszköz eredményeit
    async def execute_async(self, request):
        # Megvalósítás...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # Ez az eszköz használhatja a dataAnalysis eszköz eredményeit
    async def execute_async(self, request):
        # Megvalósítás...
        pass

# Ezek az eszközök önállóan vagy munkafolyamat részeként is használhatók
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
                description = "Keresési lekérdezés szövege. Használj pontos kulcsszavakat a jobb eredményekért." 
            },
            filters = new {
                type = "object",
                description = "Opcionális szűrők a keresési eredmények szűkítéséhez",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "Dátumtartomány formátumban ÉÉÉÉ-HH-NN:ÉÉÉÉ-HH-NN" 
                    },
                    category = new { 
                        type = "string", 
                        description = "Szűrés kategória szerint" 
                    }
                }
            },
            limit = new { 
                type = "integer", 
                description = "Visszaadott eredmények maximális száma (1-50)",
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
    
    // Email tulajdonság formátum validációval
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "Felhasználó email címe");
    
    // Kor tulajdonság numerikus korlátokkal
    Map<String, Object> age = new HashMap<>();
    age.put("type", "integer");
    age.put("minimum", 13);
    age.put("maximum", 120);
    age.put("description", "Felhasználó életkora években");
    
    // Enumerált tulajdonság
    Map<String, Object> subscription = new HashMap<>();
    subscription.put("type", "string");
    subscription.put("enum", Arrays.asList("free", "basic", "premium"));
    subscription.put("default", "free");
    subscription.put("description", "Előfizetési szint");
    
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
        # Kérés feldolgozása
        results = await self._search_database(request.parameters["query"])
        
        # Mindig egységes struktúrát adj vissza
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
    """Biztosítja, hogy minden elem egységes struktúrájú legyen"""
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
            throw new ToolExecutionException($"Fájl nem található: {fileId}");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ToolExecutionException("Nincs jogosultságod a fájl eléréséhez");
        }
        catch (Exception ex) when (ex is IOException || ex is TimeoutException)
        {
            _logger.LogError(ex, "Hiba a fájl elérésekor {FileId}", fileId);
            throw new ToolExecutionException("Hiba a fájl elérésekor: A szolgáltatás ideiglenesen nem elérhető");
        }
    }
    catch (JsonException)
    {
        throw new ToolExecutionException("Érvénytelen fájlazonosító formátum");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Váratlan hiba a FileAccessTool-ban");
        throw new ToolExecutionException("Váratlan hiba történt");
    }
}
```

#### 2. Structured Error Responses

Return structured error information when possible:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    try {
        // Megvalósítás
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
        
        // Egyéb kivételek újradobása ToolExecutionException-ként
        throw new ToolExecutionException("Az eszköz végrehajtása sikertelen: " + ex.getMessage(), ex);
    }
}
```

#### 3. Retry Logic

Implement appropriate retry logic for transient failures:

```python
async def execute_async(self, request):
    max_retries = 3
    retry_count = 0
    base_delay = 1  # másodperc
    
    while retry_count < max_retries:
        try:
            # Külső API hívás
            return await self._call_api(request.parameters)
        except TransientError as e:
            retry_count += 1
            if retry_count >= max_retries:
                raise ToolExecutionException(f"Művelet sikertelen {max_retries} próbálkozás után: {str(e)}")
                
            # Exponenciális visszavárakozás
            delay = base_delay * (2 ** (retry_count - 1))
            logging.warning(f"Átmeneti hiba, újrapróbálkozás {delay} mp múlva: {str(e)}")
            await asyncio.sleep(delay)
        except Exception as e:
            # Nem átmeneti hiba, nem próbálkozunk újra
            raise ToolExecutionException(f"Művelet sikertelen: {str(e)}")
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
    
    // Cache kulcs létrehozása a paraméterek alapján
    var cacheKey = $"data_query_{ComputeHash(query)}";
    
    // Először próbáljuk meg lekérni a cache-ből
    if (_cache.TryGetValue(cacheKey, out var cachedResult))
    {
        return new ToolResponse { Result = cachedResult };
    }
    
    // Cache hiány - tényleges lekérdezés végrehajtása
    var result = await _database.QueryAsync(query);
    
    // Tárolás a cache-ben lejárati idővel
    var cacheOptions = new MemoryCacheEntryOptions()
        .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
        
    _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
    
    return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
}

private string ComputeHash(string input)
{
    // Megvalósítás a stabil hash generálásához a cache kulcshoz
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
        
        // Hosszú futású műveletek esetén azonnal visszaadunk egy feldolgozási azonosítót
        String processId = UUID.randomUUID().toString();
        
        // Aszinkron feldolgozás indítása
        CompletableFuture.runAsync(() -> {
            try {
                // Hosszú futású művelet végrehajtása
                documentService.processDocument(documentId);
                
                // Állapot frissítése (általában adatbázisban tárolva)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // Azonnali válasz visszaadása a feldolgozási azonosítóval
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // Kísérő állapot lekérdező eszköz
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
            tokens_per_second=5,  # Másodpercenként 5 kérés engedélyezett
            bucket_size=10        # Maximum 10 kérés hirtelen megugrása engedélyezett
        )
    
    async def execute_async(self, request):
        # Ellenőrizzük, hogy folytathatjuk-e vagy várnunk kell
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # Ha a várakozás túl hosszú
                raise ToolExecutionException(
                    f"Átviteli korlát túllépve. Kérjük, próbálja újra {delay:.1f} másodperc múlva."
                )
            else:
                # Várakozás a megfelelő ideig
                await asyncio.sleep(delay)
        
        # Token elfogyasztása és a kérés folytatása
        self.rate_limiter.consume()
        
        # API hívás
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
            
            # Számítsuk ki, mennyi idő múlva lesz új token
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # Új tokenek hozzáadása az eltelt idő alapján
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
    // Ellenőrizzük, hogy a paraméterek léteznek-e
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("Hiányzó kötelező paraméter: query");
    }
    
    // Ellenőrizzük a helyes típust
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("A query paraméternek string típusúnak kell lennie");
    }
    
    var query = queryProp.GetString();
    
    // Ellenőrizzük a string tartalmát
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("A query paraméter nem lehet üres");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("A query paraméter hossza nem haladhatja meg az 500 karaktert");
    }
    
    // Ellenőrizzük SQL injection támadásokra, ha releváns
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("Érvénytelen lekérdezés: potenciálisan veszélyes SQL-t tartalmaz");
    }
    
    // Folytassuk a végrehajtást
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // Felhasználói kontextus lekérése a kérésből
    UserContext user = request.getContext().getUserContext();
    
    // Ellenőrizzük, hogy a felhasználónak megvan-e a szükséges jogosultsága
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("A felhasználónak nincs jogosultsága a dokumentumok eléréséhez");
    }
    
    // Egyes erőforrások esetén ellenőrizzük a hozzáférést az adott erőforráshoz
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("Hozzáférés megtagadva a kért dokumentumhoz");
    }
    
    // Folytassuk az eszköz végrehajtását
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
        
        # Felhasználói adatok lekérése
        user_data = await self.user_service.get_user_data(user_id)
        
        # Érzékeny mezők szűrése, kivéve ha kifejezetten kérték ÉS jogosultak vagyunk rá
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # Jogosultsági szint ellenőrzése a kérés kontextusában
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # Másolat készítése, hogy ne módosítsuk az eredetit
        redacted = user_data.copy()
        
        # Konkrét érzékeny mezők kitakarása
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # Beágyazott érzékeny adatok kitakarása
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
    // Előkészítés
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("Seattle", 3))
        .ReturnsAsync(new WeatherForecast(/* tesztadatok */));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "Seattle", 
            days = 3 
        })
    );
    
    // Végrehajtás
    var response = await tool.ExecuteAsync(request);
    
    // Ellenőrzés
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // Előkészítés
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("InvalidLocation", It.IsAny<int>()))
        .ThrowsAsync(new LocationNotFoundException("Helyszín nem található"));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "InvalidLocation", 
            days = 3 
        })
    );
    
    // Végrehajtás és ellenőrzés
    var exception = await Assert.ThrowsAsync<ToolExecutionException>(
        () => tool.ExecuteAsync(request)
    );
    
    Assert.Contains("Helyszín nem található", exception.Message);
}
```

#### 2. Schema Validation Testing

Test that schemas are valid and properly enforce constraints:

```java
@Test
public void testSchemaValidation() {
    // Eszköz példány létrehozása
    SearchTool searchTool = new SearchTool();
    
    // Sém lekérése
    Object schema = searchTool.getSchema();
    
    // Séma JSON formátumba konvertálása validáláshoz
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // Ellenőrizzük, hogy a séma érvényes JSONSchema-e
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // Érvényes paraméterek tesztelése
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // Hiányzó kötelező paraméter tesztelése
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // Érvénytelen paramétertípus tesztelése
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
    # Előkészítés
    tool = ApiTool(timeout=0.1)  # Nagyon rövid időkorlát
    
    # Mock kérés, ami időtúllépést okoz
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # Hosszabb, mint az időkorlát
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # Végrehajtás és ellenőrzés
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Ellenőrizzük a kivétel üzenetét
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # Előkészítés
    tool = ApiTool()
    
    # Mock válasz, ami rate limitet jelez
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
        
        # Végrehajtás és ellenőrzés
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Ellenőrizzük, hogy a kivétel tartalmazza a rate limit információt
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
    // Előkészítés
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // Végrehajtás
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

// Ellenőrzés
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
        // Teszteld az eszköz-felderítő végpontot
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // Eszközkérés létrehozása
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // Kérés elküldése és válasz ellenőrzése
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // Érvénytelen eszközkérés létrehozása
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // Hiányzó "b" paraméter
        request.put("parameters", parameters);
        
        // Kérés elküldése és hibaválasz ellenőrzése
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
    # Előkészítés - MCP kliens és mock modell beállítása
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # Mock modell válaszok
    mock_model = MockLanguageModel([
        MockResponse(
            "Mi az időjárás Seattle-ben?",
            tool_calls=[{
                "tool_name": "weatherForecast",
                "parameters": {"location": "Seattle", "days": 3}
            }]
        ),
        MockResponse(
            "Íme a seattle-i időjárás-előrejelzés:\n- Ma: 65°F, részben felhős\n- Holnap: 68°F, napos\n- Holnapután: 62°F, eső",
            tool_calls=[]
        )
    ])
    
    # Mock időjárás eszköz válasz
    with aioresponses() as mocked:
        mocked.post(
            "http://localhost:5000/mcp/execute",
            payload={
                "result": {
                    "location": "Seattle",
                    "forecast": [
                        {"date": "2023-06-01", "temperature": 65, "conditions": "Részben felhős"},
                        {"date": "2023-06-02", "temperature": 68, "conditions": "Napos"},
                        {"date": "2023-06-03", "temperature": 62, "conditions": "Eső"}
                    ]
                }
            }
        )
        
        # Végrehajtás
        response = await mcp_client.send_prompt(
            "Mi az időjárás Seattle-ben?",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # Ellenőrzés
        assert "Seattle" in response.generated_text
        assert "65" in response.generated_text
        assert "Napos" in response.generated_text
        assert "Eső" in response.generated_text
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
    // Előkészítés
    var server = new McpServer(
        name: "TestServer",
        version: "1.0",
        maxConcurrentRequests: 100
    );
    
    server.RegisterTool(new FastExecutingTool());
    await server.StartAsync();
    
    var client = new McpClient("http://localhost:5000");
    
    // Végrehajtás
    var tasks = new List<Task<McpResponse>>();
    for (int i = 0; i < 1000; i++)
    {
        tasks.Add(client.ExecuteToolAsync("fastTool", new { iteration = i }));
    }
    
    var results = await Task.WhenAll(tasks);
    
    // Ellenőrzés
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
    
    // JMeter beállítása stresszteszthez
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // JMeter tesztterv konfigurálása
    HashTree testPlanTree = new HashTree();
    
    // Tesztterv, szálcsoport, mintavételezők létrehozása stb.
    TestPlan testPlan = new TestPlan("MCP Server Stress Test");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // HTTP mintavételező hozzáadása az eszköz végrehajtáshoz
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // Hallgatók hozzáadása
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // Teszt futtatása
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // Eredmények ellenőrzése
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // Átlagos válaszidő < 200ms
    assertTrue(summaryReport.getPercentile(90.0) < 500); // 90. percentilis < 500ms
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# MCP szerver monitorozásának beállítása
def configure_monitoring(server):
    # Prometheus metrikák beállítása
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "Összes MCP kérés"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "Kérés időtartama másodpercben",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "Eszköz végrehajtások száma",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "Eszköz végrehajtás időtartama másodpercben",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "Eszköz végrehajtási hibák",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # Middleware hozzáadása az időméréshez és metrikák rögzítéséhez
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # Metrikák végpontjának kitettsége
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
# Python láncolt eszközök megvalósítása
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # Az eszközök neveinek listája, amelyeket sorban kell végrehajtani
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # Minden eszköz végrehajtása a láncban, az előző eredmény átadásával
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # Eredmény tárolása és bemenetként használata a következő eszközhöz
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# Példa használat
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
    public string Description => "Különböző típusú tartalmak feldolgozása";
    
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
        
        // Meghatározza, melyik specializált eszközt használja
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // Továbbítja a kérést a specializált eszköznek
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
# csvProcessor használati útmutató

Ez a modul lehetővé teszi CSV fájlok egyszerű feldolgozását és elemzését.

## Főbb funkciók

- CSV fájlok beolvasása és soronkénti feldolgozása
- Adatok szűrése és rendezése
- Egyszerű statisztikai műveletek végrehajtása

## Használat

```python
from csvProcessor import read_csv, filter_data

# CSV fájl beolvasása
data = read_csv('adatok.csv')

# Adatok szűrése bizonyos feltételek alapján
filtered = filter_data(data, lambda row: int(row['kor']) > 18)

# Eredmények kiírása
for row in filtered:
    print(row)
```

## Megjegyzések

- [!NOTE] A modul csak jól formázott CSV fájlokat támogat.
- [!WARNING] Nagy méretű fájlok esetén a feldolgozás lassú lehet.
- [!TIP] Használj generátorokat a memóriahatékony feldolgozáshoz.

## Hibakezelés

A modul kivételeket dob, ha a fájl nem található vagy hibás formátumú.

## További információk

Látogass el a hivatalos dokumentációra a részletes leírásért és példákért.
            ("code", _) => "codeAnalyzer",
            _ => throw new ToolExecutionException($"Nincs elérhető eszköz a(z) {contentType}/{operation} számára")
        };
    }
    
    private object GetOptionsForTool(string toolName, string operation)
    {
        // Visszaadja a megfelelő beállításokat az egyes speciális eszközökhöz
        return toolName switch
        {
            "textSummarizer" => new { length = "medium" },
            "htmlProcessor" => new { cleanUp = true, operation },
            // Egyéb eszközök beállításai...
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
        // 1. lépés: Adatkészlet metaadatainak lekérése (szinkron)
        ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata", 
            Map.of("datasetId", datasetId));
        
        // 2. lépés: Több elemzés párhuzamos indítása
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
        
        // Várakozás az összes párhuzamos feladat befejezésére
        CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
            statisticalAnalysis, correlationAnalysis, outlierDetection
        );
        
        allAnalyses.join();  // Várakozás a befejezésre
        
        // 3. lépés: Eredmények összevonása
        Map<String, Object> combinedResults = new HashMap<>();
        combinedResults.put("metadata", metadataResponse.getResult());
        combinedResults.put("statistics", statisticalAnalysis.join().getResult());
        combinedResults.put("correlations", correlationAnalysis.join().getResult());
        combinedResults.put("outliers", outlierDetection.join().getResult());
        
        // 4. lépés: Összefoglaló jelentés generálása
        ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator", 
            Map.of("analysisResults", combinedResults));
        
        // Teljes munkafolyamat eredményének visszaadása
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
            # Először a fő eszközt próbáljuk meg
            response = await self.client.execute_tool(primary_tool, parameters)
            return {
                "result": response.result,
                "source": "primary",
                "tool": primary_tool
            }
        except ToolExecutionException as e:
            # Hibát naplózunk
            logging.warning(f"A fő eszköz '{primary_tool}' hibát adott: {str(e)}")
            
            # Visszatérés a tartalék eszközhöz
            try:
                # Lehet, hogy át kell alakítani a paramétereket a tartalék eszközhöz
                fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)
                
                response = await self.client.execute_tool(fallback_tool, fallback_params)
                return {
                    "result": response.result,
                    "source": "fallback",
                    "tool": fallback_tool,
                    "primaryError": str(e)
                }
            except ToolExecutionException as fallback_error:
                # Mindkét eszköz hibát adott
                logging.error(f"Mind a fő, mind a tartalék eszköz hibát adott. Tartalék hiba: {str(fallback_error)}")
                raise WorkflowExecutionException(
                    f"A munkafolyamat sikertelen: fő hiba: {str(e)}; tartalék hiba: {str(fallback_error)}"
                )
    
    def _adapt_parameters(self, params, from_tool, to_tool):
        """Paraméterek átalakítása különböző eszközök között, ha szükséges"""
        # Ez az implementáció az adott eszközöktől függ
        # Ebben a példában egyszerűen visszaadjuk az eredeti paramétereket
        return params

# Példa használat
async def get_weather(workflow, location):
    return await workflow.execute_with_fallback(
        "premiumWeatherService",  # Elsődleges (fizetős) időjárás API
        "basicWeatherService",    # Tartalék (ingyenes) időjárás API
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
            
            // Minden munkafolyamat eredményének tárolása
            results[workflow.Name] = workflowResult;
            
            // A kontextus frissítése az eredménnyel a következő munkafolyamathoz
            context = context.WithResult(workflow.Name, workflowResult);
        }
        
        return new WorkflowResult(results);
    }
    
    public string Name => "CompositeWorkflow";
    public string Description => "Több munkafolyamat egymás utáni végrehajtása";
}

// Példa használat
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
// Példa egységteszt egy számológép eszközhöz C#-ban
[Fact]
public async Task CalculatorTool_Add_ReturnsCorrectSum()
{
    // Előkészítés
    var calculator = new CalculatorTool();
    var parameters = new Dictionary<string, object>
    {
        ["operation"] = "add",
        ["a"] = 5,
        ["b"] = 7
    };
    
    // Végrehajtás
    var response = await calculator.ExecuteAsync(parameters);
    var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());
    
    // Ellenőrzés
    Assert.Equal(12, result.Value);
}
```

```python
# Példa egységteszt egy számológép eszközhöz Pythonban
def test_calculator_tool_add():
    # Előkészítés
    calculator = CalculatorTool()
    parameters = {
        "operation": "add",
        "a": 5,
        "b": 7
    }
    
    # Végrehajtás
    response = calculator.execute(parameters)
    result = json.loads(response.content[0].text)
    
    # Ellenőrzés
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
// Példa integrációs teszt MCP szerverhez C#-ban
[Fact]
public async Task Server_ProcessToolRequest_ReturnsValidResponse()
{
    // Előkészítés
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
    
    // Végrehajtás
    var response = await server.ProcessRequestAsync(request);
    
    // Ellenőrzés
    Assert.NotNull(response);
    Assert.Equal(McpStatusCodes.Success, response.StatusCode);
    // További ellenőrzések a válasz tartalmára
    
    // Takarítás
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
// Példa E2E teszt klienssel TypeScript-ben
describe('MCP Server E2E Tesztek', () => {
  let client: McpClient;
  
  beforeAll(async () => {
    // Szerver indítása teszt környezetben
    await startTestServer();
    client = new McpClient('http://localhost:5000');
  });
  
  afterAll(async () => {
    await stopTestServer();
  });
  
  test('A kliens képes meghívni a calculator eszközt és helyes eredményt kap', async () => {
    // Végrehajtás
    const response = await client.invokeToolAsync('calculator', {
      operation: 'divide',
      a: 20,
      b: 4
    });
    
    // Ellenőrzés
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
// C# példa Moq használatával
var mockModel = new Mock<ILanguageModel>();
mockModel
    .Setup(m => m.GenerateResponseAsync(
        It.IsAny<string>(),
        It.IsAny<McpRequestContext>()))
    .ReturnsAsync(new ModelResponse { 
        Text = "Mockolt modell válasz",
        FinishReason = FinishReason.Completed
    });

var server = new McpServer(modelClient: mockModel.Object);
```

```python
# Python példa unittest.mock használatával
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
    # Mock konfigurálása
    mock_model.return_value.generate_response.return_value = {
        "text": "Mockolt modell válasz",
        "finish_reason": "completed"
    }
    
    # Mock használata a tesztben
    server = McpServer(model_client=mock_model)
    # Teszt folytatása
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
// k6 szkript MCP szerver terheléses teszteléséhez
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  vus: 10,  // 10 virtuális felhasználó
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
    'status 200-as': (r) => r.status === 200,
    'válaszidő < 500ms': (r) => r.timings.duration < 500,
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
name: MCP Server Tesztek

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
    
    - name: Futási környezet beállítása
      uses: actions/setup-dotnet@v1
      with:
        dotnet-version: '8.0.x'
    
    - name: Függőségek visszaállítása
      run: dotnet restore
    
    - name: Fordítás
      run: dotnet build --no-restore
    
    - name: Egységtesztek
      run: dotnet test --no-build --filter Category=Unit
    
    - name: Integrációs tesztek
      run: dotnet test --no-build --filter Category=Integration
      
    - name: Teljesítménytesztek
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
    // Előkészítés
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");
    
    // Végrehajtás
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
    // További sémaellenőrzés
});
}

## Top 10 tipp hatékony MCP szerverteszteléshez

1. **Teszteld külön a Tool definíciókat**: Ellenőrizd a séma definíciókat a tool logikájától függetlenül  
2. **Használj paraméterezett teszteket**: Teszteld a toolokat különböző bemenetekkel, beleértve a szélsőséges eseteket is  
3. **Ellenőrizd a hibaválaszokat**: Győződj meg róla, hogy minden lehetséges hibakörülmény megfelelően kezelve van  
4. **Teszteld az engedélyezési logikát**: Biztosítsd a megfelelő hozzáférés-ellenőrzést különböző felhasználói szerepköröknél  
5. **Figyeld a tesztlefedettséget**: Törekedj a kritikus kódrészek magas lefedettségére  
6. **Teszteld a streaming válaszokat**: Ellenőrizd a streaming tartalom helyes kezelését  
7. **Szimulálj hálózati problémákat**: Teszteld a viselkedést gyenge hálózati körülmények között  
8. **Teszteld az erőforrás-korlátokat**: Vizsgáld meg a viselkedést kvóták vagy sebességkorlátok elérésekor  
9. **Automatizáld a regressziós teszteket**: Építs olyan tesztcsomagot, ami minden kódváltozás után lefut  
10. **Dokumentáld a teszteseteket**: Tarts fenn világos dokumentációt a tesztforgatókönyvekről  

## Gyakori tesztelési buktatók

- **Túlzott támaszkodás a sikeres útvonal tesztelésére**: Ügyelj arra, hogy a hibás eseteket is alaposan teszteld  
- **A teljesítménytesztelés figyelmen kívül hagyása**: Azonosítsd a szűk keresztmetszeteket, mielőtt azok a termelésben problémát okoznának  
- **Csak izolált tesztelés**: Kombináld az egység-, integrációs és end-to-end teszteket  
- **Hiányos API lefedettség**: Biztosítsd, hogy minden végpont és funkció tesztelve legyen  
- **Inkonzisztens tesztkörnyezetek**: Használj konténereket a tesztkörnyezetek egységességének biztosítására  

## Összefoglalás

Egy átfogó tesztelési stratégia elengedhetetlen a megbízható, magas minőségű MCP szerverek fejlesztéséhez. A jelen útmutatóban bemutatott legjobb gyakorlatok és tippek alkalmazásával biztosíthatod, hogy MCP megvalósításaid a legmagasabb minőségi, megbízhatósági és teljesítménybeli elvárásoknak megfeleljenek.

## Főbb tanulságok

1. **Tool tervezés**: Kövesd az egység felelősség elvét, használj dependency injection-t, és tervezz komponálhatóságra  
2. **Sémaztervezés**: Készíts világos, jól dokumentált sémákat megfelelő validációs korlátokkal  
3. **Hibakezelés**: Valósíts meg kifinomult hibakezelést, strukturált hibaválaszokat és újrapróbálkozási logikát  
4. **Teljesítmény**: Használj cache-elést, aszinkron feldolgozást és erőforrás-korlátozást  
5. **Biztonság**: Alkalmazz alapos bemeneti validációt, jogosultság-ellenőrzést és érzékeny adatok kezelését  
6. **Tesztelés**: Készíts átfogó egység-, integrációs és end-to-end teszteket  
7. **Munkafolyamat minták**: Alkalmazz bevált mintákat, mint láncok, diszpécserek és párhuzamos feldolgozás  

## Gyakorlat

Tervezzen egy MCP toolt és munkafolyamatot egy dokumentumfeldolgozó rendszerhez, amely:

1. Több formátumú dokumentumokat fogad (PDF, DOCX, TXT)  
2. Kinyeri a szöveget és a kulcsfontosságú információkat a dokumentumokból  
3. Osztályozza a dokumentumokat típus és tartalom szerint  
4. Összefoglalót készít minden dokumentumról  

Valósítsa meg a tool sémákat, hibakezelést és egy munkafolyamat mintát, amely a legjobban illik ehhez a feladathoz. Gondolja át, hogyan tesztelné ezt a megvalósítást.

## Források

1. Csatlakozzon az MCP közösséghez az [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs) oldalon, hogy naprakész legyen a legújabb fejlesztésekről  
2. Vegyen részt nyílt forráskódú [MCP projektekben](https://github.com/modelcontextprotocol)  
3. Alkalmazza az MCP elveket saját szervezete AI kezdeményezéseiben  
4. Fedezze fel az iparágára szabott MCP megvalósításokat  
5. Fontolja meg haladó tanfolyamok elvégzését specifikus MCP témákban, például multimodális integráció vagy vállalati alkalmazásintegráció  
6. Kísérletezzen saját MCP toolok és munkafolyamatok építésével a [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) útmutató alapján  

Következő: Best Practices [esettanulmányok](../09-CaseStudy/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén professzionális emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.