<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "80e5c8949af5af0f401fce6f905990aa",
  "translation_date": "2025-07-17T10:39:07+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "cs"
}
-->
# Nejlepší postupy vývoje MCP

## Přehled

Tato lekce se zaměřuje na pokročilé osvědčené postupy pro vývoj, testování a nasazení MCP serverů a funkcí v produkčním prostředí. Jak MCP ekosystémy rostou na složitosti a významu, dodržování zavedených vzorů zajišťuje spolehlivost, udržovatelnost a interoperabilitu. Tato lekce shrnuje praktické zkušenosti získané z reálných implementací MCP, aby vás provedla tvorbou robustních a efektivních serverů s účinnými zdroji, výzvami a nástroji.

## Cíle učení

Na konci této lekce budete schopni:
- Aplikovat průmyslové osvědčené postupy při návrhu MCP serverů a funkcí
- Vytvářet komplexní testovací strategie pro MCP servery
- Navrhovat efektivní a znovupoužitelné vzory pracovních postupů pro složité MCP aplikace
- Implementovat správné zpracování chyb, logování a sledovatelnost v MCP serverech
- Optimalizovat MCP implementace z hlediska výkonu, bezpečnosti a udržovatelnosti

## Základní principy MCP

Než se pustíme do konkrétních implementačních postupů, je důležité pochopit základní principy, které vedou efektivní vývoj MCP:

1. **Standardizovaná komunikace**: MCP používá JSON-RPC 2.0 jako základ, což poskytuje jednotný formát pro požadavky, odpovědi a zpracování chyb ve všech implementacích.

2. **Uživatelsky orientovaný design**: Vždy upřednostňujte souhlas uživatele, jeho kontrolu a transparentnost ve vašich MCP implementacích.

3. **Bezpečnost na prvním místě**: Implementujte robustní bezpečnostní opatření včetně autentizace, autorizace, validace a omezení rychlosti.

4. **Modulární architektura**: Navrhujte MCP servery modulárně, kde každý nástroj a zdroj má jasný a zaměřený účel.

5. **Stavové připojení**: Využívejte schopnost MCP udržovat stav přes více požadavků pro koherentnější a kontextově uvědomělé interakce.

## Oficiální nejlepší postupy MCP

Následující nejlepší postupy vycházejí z oficiální dokumentace Model Context Protocol:

### Bezpečnostní nejlepší postupy

1. **Souhlas a kontrola uživatele**: Vždy vyžadujte explicitní souhlas uživatele před přístupem k datům nebo prováděním operací. Poskytněte jasnou kontrolu nad tím, jaká data jsou sdílena a jaké akce jsou autorizovány.

2. **Ochrana soukromí dat**: Zveřejňujte uživatelská data pouze s explicitním souhlasem a chraňte je vhodnými přístupovými kontrolami. Zabraňte neoprávněnému přenosu dat.

3. **Bezpečnost nástrojů**: Vyžadujte explicitní souhlas uživatele před spuštěním jakéhokoliv nástroje. Ujistěte se, že uživatelé rozumí funkčnosti každého nástroje a prosazujte pevné bezpečnostní hranice.

4. **Řízení oprávnění nástrojů**: Konfigurujte, které nástroje může model během relace používat, aby byly přístupné pouze ty, které jsou explicitně autorizované.

5. **Autentizace**: Vyžadujte správnou autentizaci před udělením přístupu k nástrojům, zdrojům nebo citlivým operacím pomocí API klíčů, OAuth tokenů nebo jiných bezpečných metod.

6. **Validace parametrů**: Prosazujte validaci všech volání nástrojů, aby se zabránilo předání neplatných nebo škodlivých vstupů do implementací nástrojů.

7. **Omezení rychlosti**: Implementujte omezení rychlosti, aby se zabránilo zneužití a zajistilo spravedlivé využívání serverových zdrojů.

### Implementační nejlepší postupy

1. **Vyjednávání schopností**: Při navazování připojení si vyměňujte informace o podporovaných funkcích, verzích protokolu, dostupných nástrojích a zdrojích.

2. **Návrh nástrojů**: Vytvářejte zaměřené nástroje, které dělají jednu věc dobře, místo monolitických nástrojů řešících více záležitostí najednou.

3. **Zpracování chyb**: Implementujte standardizované chybové zprávy a kódy, které pomáhají diagnostikovat problémy, elegantně zvládat selhání a poskytovat užitečnou zpětnou vazbu.

4. **Logování**: Nastavte strukturované logy pro audit, ladění a monitorování interakcí protokolu.

5. **Sledování průběhu**: U dlouhotrvajících operací hlaste aktualizace průběhu, aby bylo možné vytvořit responzivní uživatelská rozhraní.

6. **Zrušení požadavků**: Umožněte klientům zrušit probíhající požadavky, které již nejsou potřeba nebo trvají příliš dlouho.

## Další odkazy

Pro nejaktuálnější informace o nejlepších postupech MCP navštivte:
- [MCP Dokumentace](https://modelcontextprotocol.io/)
- [MCP Specifikace](https://spec.modelcontextprotocol.io/)
- [GitHub Repozitář](https://github.com/modelcontextprotocol)
- [Bezpečnostní nejlepší postupy](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## Praktické příklady implementace

### Nejlepší postupy návrhu nástrojů

#### 1. Princip jediné odpovědnosti

Každý MCP nástroj by měl mít jasný a zaměřený účel. Místo vytváření monolitických nástrojů, které se snaží řešit více záležitostí najednou, vyvíjejte specializované nástroje, které vynikají v konkrétních úkolech.

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

#### 2. Konzistentní zpracování chyb

Implementujte robustní zpracování chyb s informativními chybovými zprávami a vhodnými mechanismy obnovy.

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

#### 3. Validace parametrů

Vždy důkladně validujte parametry, aby se zabránilo předání neplatných nebo škodlivých vstupů.

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

### Příklady implementace bezpečnosti

#### 1. Autentizace a autorizace

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

#### 2. Omezení rychlosti

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

## Nejlepší postupy testování

### 1. Jednotkové testování MCP nástrojů

Vždy testujte své nástroje izolovaně, pomocí mockování externích závislostí:

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

### 2. Integrační testování

Testujte kompletní tok od požadavků klienta po odpovědi serveru:

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

## Optimalizace výkonu

### 1. Strategie cachování

Implementujte vhodné cachování ke snížení latence a využití zdrojů:

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
// Příklad v Javě s injektáží závislostí
public class CurrencyConversionTool implements Tool {
    private final ExchangeRateService exchangeService;
    private final CacheService cacheService;
    private final Logger logger;
    
    // Závislosti injektovány přes konstruktor
    public CurrencyConversionTool(
            ExchangeRateService exchangeService,
            CacheService cacheService,
            Logger logger) {
        this.exchangeService = exchangeService;
        this.cacheService = cacheService;
        this.logger = logger;
    }
    
    // Implementace nástroje
    // ...
}
```

#### 3. Composable Tools

Design tools that can be composed together to create more complex workflows:

```python
# Příklad v Pythonu ukazující kompozici nástrojů
class DataFetchTool(Tool):
    def get_name(self):
        return "dataFetch"
    
    # Implementace...

class DataAnalysisTool(Tool):
    def get_name(self):
        return "dataAnalysis"
    
    # Tento nástroj může využívat výsledky z dataFetch nástroje
    async def execute_async(self, request):
        # Implementace...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # Tento nástroj může využívat výsledky z dataAnalysis nástroje
    async def execute_async(self, request):
        # Implementace...
        pass

# Tyto nástroje lze používat samostatně nebo jako součást pracovního postupu
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
                description = "Text vyhledávacího dotazu. Používejte přesná klíčová slova pro lepší výsledky." 
            },
            filters = new {
                type = "object",
                description = "Volitelné filtry pro zpřesnění výsledků vyhledávání",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "Časové období ve formátu YYYY-MM-DD:YYYY-MM-DD" 
                    },
                    category = new { 
                        type = "string", 
                        description = "Název kategorie pro filtrování" 
                    }
                }
            },
            limit = new { 
                type = "integer", 
                description = "Maximální počet vrácených výsledků (1-50)",
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
    
    // Vlastnost email s validací formátu
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "Emailová adresa uživatele");
    
    // Vlastnost věk s číselnými omezeními
    Map<String, Object> age = new HashMap<>();
    age.put("type", "integer");
    age.put("minimum", 13);
    age.put("maximum", 120);
    age.put("description", "Věk uživatele v letech");
    
    // Výčtová vlastnost
    Map<String, Object> subscription = new HashMap<>();
    subscription.put("type", "string");
    subscription.put("enum", Arrays.asList("free", "basic", "premium"));
    subscription.put("default", "free");
    subscription.put("description", "Úroveň předplatného");
    
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
        # Zpracování požadavku
        results = await self._search_database(request.parameters["query"])
        
        # Vždy vracejte konzistentní strukturu
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
    """Zajišťuje, že každý prvek má konzistentní strukturu"""
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
            throw new ToolExecutionException($"Soubor nenalezen: {fileId}");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ToolExecutionException("Nemáte oprávnění k přístupu k tomuto souboru");
        }
        catch (Exception ex) when (ex is IOException || ex is TimeoutException)
        {
            _logger.LogError(ex, "Chyba při přístupu k souboru {FileId}", fileId);
            throw new ToolExecutionException("Chyba při přístupu k souboru: Služba je dočasně nedostupná");
        }
    }
    catch (JsonException)
    {
        throw new ToolExecutionException("Neplatný formát ID souboru");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Neočekávaná chyba v FileAccessTool");
        throw new ToolExecutionException("Došlo k neočekávané chybě");
    }
}
```

#### 2. Structured Error Responses

Return structured error information when possible:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    try {
        // Implementace
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
        
        // Přehodit ostatní výjimky jako ToolExecutionException
        throw new ToolExecutionException("Selhání při vykonání nástroje: " + ex.getMessage(), ex);
    }
}
```

#### 3. Retry Logic

Implement appropriate retry logic for transient failures:

```python
async def execute_async(self, request):
    max_retries = 3
    retry_count = 0
    base_delay = 1  # sekundy
    
    while retry_count < max_retries:
        try:
            # Volání externího API
            return await self._call_api(request.parameters)
        except TransientError as e:
            retry_count += 1
            if retry_count >= max_retries:
                raise ToolExecutionException(f"Operace selhala po {max_retries} pokusech: {str(e)}")
                
            # Exponenciální zpomalení
            delay = base_delay * (2 ** (retry_count - 1))
            logging.warning(f"Dočasná chyba, opakuji za {delay}s: {str(e)}")
            await asyncio.sleep(delay)
        except Exception as e:
            # Nedochází k dočasné chybě, neopakovat
            raise ToolExecutionException(f"Operace selhala: {str(e)}")
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
    
    // Vytvoření klíče cache na základě parametrů
    var cacheKey = $"data_query_{ComputeHash(query)}";
    
    // Nejprve se pokusit získat z cache
    if (_cache.TryGetValue(cacheKey, out var cachedResult))
    {
        return new ToolResponse { Result = cachedResult };
    }
    
    // Cache miss - proveď skutečný dotaz
    var result = await _database.QueryAsync(query);
    
    // Uložení do cache s expirací
    var cacheOptions = new MemoryCacheEntryOptions()
        .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
        
    _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
    
    return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
}

private string ComputeHash(string input)
{
    // Implementace pro vytvoření stabilního hashe pro klíč cache
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
        
        // U dlouhotrvajících operací okamžitě vrátit ID procesu
        String processId = UUID.randomUUID().toString();
        
        // Spustit asynchronní zpracování
        CompletableFuture.runAsync(() -> {
            try {
                // Proveď dlouhotrvající operaci
                documentService.processDocument(documentId);
                
                // Aktualizuj stav (obvykle by se ukládal do databáze)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // Okamžitě vrátit odpověď s ID procesu
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // Nástroj pro kontrolu stavu procesu
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
            tokens_per_second=5,  # Povolit 5 požadavků za sekundu
            bucket_size=10        # Povolit náraz až 10 požadavků
        )
    
    async def execute_async(self, request):
        # Zkontroluj, zda můžeme pokračovat, nebo je potřeba počkat
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # Pokud je čekání příliš dlouhé
                raise ToolExecutionException(
                    f"Překročen limit rychlosti. Zkuste to prosím znovu za {delay:.1f} sekund."
                )
            else:
                # Počkej odpovídající dobu
                await asyncio.sleep(delay)
        
        # Spotřebuj token a pokračuj s požadavkem
        self.rate_limiter.consume()
        
        # Zavolej API
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
            
            # Vypočítej čas do dostupnosti dalšího tokenu
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # Přidej nové tokeny podle uplynulého času
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
    // Ověření, že parametry existují
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("Chybí povinný parametr: query");
    }
    
    // Ověření správného typu
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("Parametr query musí být řetězec");
    }
    
    var query = queryProp.GetString();
    
    // Ověření obsahu řetězce
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("Parametr query nesmí být prázdný");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("Parametr query překračuje maximální délku 500 znaků");
    }
    
    // Kontrola na SQL injection útoky, pokud je to relevantní
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("Neplatný dotaz: obsahuje potenciálně nebezpečný SQL kód");
    }
    
    // Pokračuj ve vykonání
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // Získat uživatelský kontext z požadavku
    UserContext user = request.getContext().getUserContext();
    
    // Zkontrolovat, zda má uživatel potřebná oprávnění
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("Uživatel nemá oprávnění k přístupu k dokumentům");
    }
    
    // U specifických zdrojů zkontrolovat přístup k danému zdroji
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("Přístup k požadovanému dokumentu byl odepřen");
    }
    
    // Pokračuj ve vykonání nástroje
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
        
        # Získat uživatelská data
        user_data = await self.user_service.get_user_data(user_id)
        
        # Filtrovat citlivá pole, pokud nejsou explicitně požadována A autorizována
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # Zkontrolovat úroveň autorizace v kontextu požadavku
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # Vytvořit kopii, aby nedošlo k úpravě originálu
        redacted = user_data.copy()
        
        # Cenzurovat konkrétní citlivá pole
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # Cenzurovat vnořená citlivá data
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
    // Příprava
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("Seattle", 3))
        .ReturnsAsync(new WeatherForecast(/* testovací data */));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "Seattle", 
            days = 3 
        })
    );
    
    // Akce
    var response = await tool.ExecuteAsync(request);
    
    // Ověření
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // Příprava
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("InvalidLocation", It.IsAny<int>()))
        .ThrowsAsync(new LocationNotFoundException("Místo nenalezeno"));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "InvalidLocation", 
            days = 3 
        })
    );
    
    // Akce & Ověření
    var exception = await Assert.ThrowsAsync<ToolExecutionException>(
        () => tool.ExecuteAsync(request)
    );
    
    Assert.Contains("Místo nenalezeno", exception.Message);
}
```

#### 2. Schema Validation Testing

Test that schemas are valid and properly enforce constraints:

```java
@Test
public void testSchemaValidation() {
    // Vytvoření instance nástroje
    SearchTool searchTool = new SearchTool();
    
    // Získání schématu
    Object schema = searchTool.getSchema();
    
    // Převod schématu na JSON pro validaci
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // Validace, že schéma je platné JSONSchema
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // Test platných parametrů
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // Test chybějícího povinného parametru
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // Test neplatného typu parametru
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
    # Příprava
    tool = ApiTool(timeout=0.1)  # Velmi krátký timeout
    
    # Mock požadavku, který vyprší časový limit
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # Delší než timeout
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # Akce & Ověření
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Ověření zprávy výjimky
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # Příprava
    tool = ApiTool()
    
    # Mock odpovědi s omezením rychlosti
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
        
        # Akce & Ověření
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Ověření, že výjimka obsahuje informace o omezení rychlosti
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
    // Příprava
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // Akce
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

// Ověření
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
        // Otestujte endpoint pro zjištění nástrojů
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // Vytvoření požadavku na nástroj
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // Odeslání požadavku a ověření odpovědi
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // Vytvoření neplatného požadavku na nástroj
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // Chybějící parametr "b"
        request.put("parameters", parameters);
        
        // Odeslání požadavku a ověření chybové odpovědi
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
    # Příprava - nastavení MCP klienta a mock modelu
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # Mock odpovědi modelu
    mock_model = MockLanguageModel([
        MockResponse(
            "Jaké je počasí v Seattlu?",
            tool_calls=[{
                "tool_name": "weatherForecast",
                "parameters": {"location": "Seattle", "days": 3}
            }]
        ),
        MockResponse(
            "Tady je předpověď počasí pro Seattle:\n- Dnes: 65°F, částečně oblačno\n- Zítra: 68°F, slunečno\n- Den poté: 62°F, déšť",
            tool_calls=[]
        )
    ])
    
    # Mock odpověď nástroje počasí
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
        
        # Provedení
        response = await mcp_client.send_prompt(
            "Jaké je počasí v Seattlu?",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # Ověření
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
    // Příprava
    var server = new McpServer(
        name: "TestServer",
        version: "1.0",
        maxConcurrentRequests: 100
    );
    
    server.RegisterTool(new FastExecutingTool());
    await server.StartAsync();
    
    var client = new McpClient("http://localhost:5000");
    
    // Provedení
    var tasks = new List<Task<McpResponse>>();
    for (int i = 0; i < 1000; i++)
    {
        tasks.Add(client.ExecuteToolAsync("fastTool", new { iteration = i }));
    }
    
    var results = await Task.WhenAll(tasks);
    
    // Ověření
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
    
    // Nastavení JMeter pro stresové testování
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // Konfigurace testovacího plánu JMeteru
    HashTree testPlanTree = new HashTree();
    
    // Vytvoření testovacího plánu, skupiny vláken, samplerů atd.
    TestPlan testPlan = new TestPlan("MCP Server Stress Test");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // Přidání HTTP sampleru pro spuštění nástroje
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // Přidání posluchačů
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // Spuštění testu
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // Ověření výsledků
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // Průměrná doba odezvy < 200ms
    assertTrue(summaryReport.getPercentile(90.0) < 500); // 90. percentil < 500ms
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# Konfigurace monitoringu pro MCP server
def configure_monitoring(server):
    # Nastavení Prometheus metrik
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "Celkový počet MCP požadavků"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "Doba trvání požadavku v sekundách",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "Počet spuštění nástrojů",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "Doba trvání spuštění nástroje v sekundách",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "Chyby při spuštění nástroje",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # Přidání middleware pro měření času a zaznamenávání metrik
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # Zveřejnění endpointu pro metriky
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
# Implementace řetězce nástrojů v Pythonu
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # Seznam názvů nástrojů, které se mají spustit za sebou
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # Spuštění každého nástroje v řetězci, předání předchozího výsledku
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # Uložení výsledku a použití jako vstup pro další nástroj
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# Příklad použití
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
    public string Description => "Zpracovává obsah různých typů";
    
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
        
        // Určení, který specializovaný nástroj použít
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // Přeposlání požadavku specializovanému nástroji
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
# csvProcessor

[!IMPORTANT]
Tento modul je navržen pro efektivní zpracování CSV souborů s velkým objemem dat.

## Funkce

- `loadCSV(filePath)`: Načte CSV soubor z dané cesty.
- `parseRow(row)`: Analyzuje jednotlivý řádek CSV a vrátí objekt.
- `filterData(criteria)`: Filtruje data podle zadaných kritérií.
- `exportCSV(destination)`: Exportuje aktuální data do CSV souboru.

## Použití

```javascript
const processor = new csvProcessor();
processor.loadCSV('data.csv');
const filtered = processor.filterData({ age: '>30' });
processor.exportCSV('filtered_data.csv');
```

## Poznámky

- Ujistěte se, že CSV soubor má správný formát a oddělovač.
- Funkce `filterData` podporuje základní operátory jako `>`, `<`, `=`.

[!TIP]
Pro lepší výkon zpracovávejte data po částech místo celého souboru najednou.
("code", _) => "codeAnalyzer",
_ => throw new ToolExecutionException($"Není dostupný žádný nástroj pro {contentType}/{operation}")
};
}

private object GetOptionsForTool(string toolName, string operation)
{
// Vrátí vhodné možnosti pro každý specializovaný nástroj
return toolName switch
{
    "textSummarizer" => new { length = "medium" },
    "htmlProcessor" => new { cleanUp = true, operation },
    // Možnosti pro další nástroje...
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
        // Krok 1: Získání metadat datasetu (synchronně)
        ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata", 
            Map.of("datasetId", datasetId));
        
        // Krok 2: Spuštění více analýz paralelně
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
        
        // Počkejte, až všechny paralelní úkoly dokončí práci
        CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
            statisticalAnalysis, correlationAnalysis, outlierDetection
        );
        
        allAnalyses.join();  // Čekání na dokončení
        
        // Krok 3: Sloučení výsledků
        Map<String, Object> combinedResults = new HashMap<>();
        combinedResults.put("metadata", metadataResponse.getResult());
        combinedResults.put("statistics", statisticalAnalysis.join().getResult());
        combinedResults.put("correlations", correlationAnalysis.join().getResult());
        combinedResults.put("outliers", outlierDetection.join().getResult());
        
        // Krok 4: Vygenerování souhrnné zprávy
        ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator", 
            Map.of("analysisResults", combinedResults));
        
        // Vrácení kompletního výsledku workflow
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
            # Nejprve zkusit primární nástroj
            response = await self.client.execute_tool(primary_tool, parameters)
            return {
                "result": response.result,
                "source": "primary",
                "tool": primary_tool
            }
        except ToolExecutionException as e:
            # Zaznamenat selhání
            logging.warning(f"Primární nástroj '{primary_tool}' selhal: {str(e)}")
            
            # Přepnout na záložní nástroj
            try:
                # Možná bude potřeba upravit parametry pro záložní nástroj
                fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)
                
                response = await self.client.execute_tool(fallback_tool, fallback_params)
                return {
                    "result": response.result,
                    "source": "fallback",
                    "tool": fallback_tool,
                    "primaryError": str(e)
                }
            except ToolExecutionException as fallback_error:
                # Oba nástroje selhaly
                logging.error(f"Selhaly oba nástroje: primární i záložní. Chyba záložního: {str(fallback_error)}")
                raise WorkflowExecutionException(
                    f"Workflow selhal: primární chyba: {str(e)}; chyba záložního: {str(fallback_error)}"
                )
    
    def _adapt_parameters(self, params, from_tool, to_tool):
        """Přizpůsobí parametry mezi různými nástroji, pokud je to potřeba"""
        # Implementace závisí na konkrétních nástrojích
        # Pro tento příklad vrátíme původní parametry
        return params

# Příklad použití
async def get_weather(workflow, location):
    return await workflow.execute_with_fallback(
        "premiumWeatherService",  # Primární (placené) API počasí
        "basicWeatherService",    # Záložní (zdarma) API počasí
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
            
            // Uložit výsledek každého workflow
            results[workflow.Name] = workflowResult;
            
            // Aktualizovat kontext výsledkem pro další workflow
            context = context.WithResult(workflow.Name, workflowResult);
        }
        
        return new WorkflowResult(results);
    }
    
    public string Name => "CompositeWorkflow";
    public string Description => "Spouští více workflow za sebou";
}

// Příklad použití
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
// Příklad jednotkového testu pro kalkulační nástroj v C#
[Fact]
public async Task CalculatorTool_Add_ReturnsCorrectSum()
{
    // Příprava
    var calculator = new CalculatorTool();
    var parameters = new Dictionary<string, object>
    {
        ["operation"] = "add",
        ["a"] = 5,
        ["b"] = 7
    };
    
    // Akce
    var response = await calculator.ExecuteAsync(parameters);
    var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());
    
    // Ověření
    Assert.Equal(12, result.Value);
}
```

```python
# Příklad jednotkového testu pro kalkulační nástroj v Pythonu
def test_calculator_tool_add():
    # Příprava
    calculator = CalculatorTool()
    parameters = {
        "operation": "add",
        "a": 5,
        "b": 7
    }
    
    # Akce
    response = calculator.execute(parameters)
    result = json.loads(response.content[0].text)
    
    # Ověření
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
// Příklad integračního testu pro MCP server v C#
[Fact]
public async Task Server_ProcessToolRequest_ReturnsValidResponse()
{
    // Příprava
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
    
    // Akce
    var response = await server.ProcessRequestAsync(request);
    
    // Ověření
    Assert.NotNull(response);
    Assert.Equal(McpStatusCodes.Success, response.StatusCode);
    // Další ověření obsahu odpovědi
    
    // Úklid
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
// Příklad E2E testu s klientem v TypeScriptu
describe('MCP Server E2E Tests', () => {
  let client: McpClient;
  
  beforeAll(async () => {
    // Spuštění serveru v testovacím prostředí
    await startTestServer();
    client = new McpClient('http://localhost:5000');
  });
  
  afterAll(async () => {
    await stopTestServer();
  });
  
  test('Klient může zavolat kalkulační nástroj a získat správný výsledek', async () => {
    // Akce
    const response = await client.invokeToolAsync('calculator', {
      operation: 'divide',
      a: 20,
      b: 4
    });
    
    // Ověření
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
// C# příklad s Moq
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
# Python příklad s unittest.mock
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
    # Nastavení mocku
    mock_model.return_value.generate_response.return_value = {
        "text": "Mocked model response",
        "finish_reason": "completed"
    }
    
    # Použití mocku v testu
    server = McpServer(model_client=mock_model)
    # Pokračování testu
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
// k6 skript pro load testing MCP serveru
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  vus: 10,  // 10 virtuálních uživatelů
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
    'status je 200': (r) => r.status === 200,
    'doba odezvy < 500ms': (r) => r.timings.duration < 500,
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
    
    - name: Nastavení Runtime
      uses: actions/setup-dotnet@v1
      with:
        dotnet-version: '8.0.x'
    
    - name: Obnovení závislostí
      run: dotnet restore
    
    - name: Sestavení
      run: dotnet build --no-restore
    
    - name: Jednotkové testy
      run: dotnet test --no-build --filter Category=Unit
    
    - name: Integrační testy
      run: dotnet test --no-build --filter Category=Integration
      
    - name: Výkonnostní testy
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
    // Příprava
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");
    
    // Akce
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
    // Další validace schématu
});
}
```

## Top 10 tipů pro efektivní testování MCP serveru

1. **Testujte definice nástrojů samostatně**: Ověřte definice schémat nezávisle na logice nástrojů  
2. **Používejte parametrizované testy**: Testujte nástroje s různými vstupy, včetně okrajových případů  
3. **Kontrolujte chybové odpovědi**: Ověřte správné zpracování chyb ve všech možných situacích  
4. **Testujte autorizační logiku**: Zajistěte správnou kontrolu přístupu pro různé uživatelské role  
5. **Sledujte pokrytí testy**: Usilujte o vysoké pokrytí kritických částí kódu  
6. **Testujte streamingové odpovědi**: Ověřte správné zpracování streamovaného obsahu  
7. **Simulujte síťové problémy**: Testujte chování za špatných síťových podmínek  
8. **Testujte limity zdrojů**: Ověřte chování při dosažení kvót nebo limitů rychlosti  
9. **Automatizujte regresní testy**: Vytvořte sadu testů, která se spouští při každé změně kódu  
10. **Dokumentujte testovací případy**: Udržujte přehlednou dokumentaci testovacích scénářů  

## Běžné chyby při testování

- **Přílišná závislost na testování „šťastné cesty“**: Nezapomeňte důkladně testovat i chybové scénáře  
- **Ignorování testování výkonu**: Identifikujte úzká místa dříve, než ovlivní produkci  
- **Testování pouze izolovaně**: Kombinujte jednotkové, integrační a end-to-end testy  
- **Neúplné pokrytí API**: Zajistěte testování všech endpointů a funkcí  
- **Nekonzistentní testovací prostředí**: Používejte kontejnery pro zajištění konzistentního prostředí  

## Závěr

Komplexní testovací strategie je klíčová pro vývoj spolehlivých a kvalitních MCP serverů. Implementací osvědčených postupů a tipů uvedených v této příručce zajistíte, že vaše MCP implementace budou splňovat nejvyšší standardy kvality, spolehlivosti a výkonu.

## Hlavní poznatky

1. **Návrh nástrojů**: Dodržujte princip jediné odpovědnosti, používejte dependency injection a navrhujte nástroje pro skládání  
2. **Návrh schémat**: Vytvářejte jasná, dobře zdokumentovaná schémata s odpovídajícími validačními omezeními  
3. **Zpracování chyb**: Implementujte elegantní zpracování chyb, strukturované chybové odpovědi a logiku opakování  
4. **Výkon**: Využívejte cache, asynchronní zpracování a řízení zdrojů  
5. **Bezpečnost**: Aplikujte důkladnou validaci vstupů, kontroly autorizace a správu citlivých dat  
6. **Testování**: Vytvářejte komplexní jednotkové, integrační a end-to-end testy  
7. **Vzorové pracovní postupy**: Používejte osvědčené vzory jako řetězce, dispatchery a paralelní zpracování  

## Cvičení

Navrhněte MCP nástroj a pracovní postup pro systém zpracování dokumentů, který:

1. Přijímá dokumenty v různých formátech (PDF, DOCX, TXT)  
2. Extrahuje text a klíčové informace z dokumentů  
3. Klasifikuje dokumenty podle typu a obsahu  
4. Generuje shrnutí každého dokumentu  

Implementujte schémata nástroje, zpracování chyb a vzor pracovního postupu, který nejlépe vyhovuje tomuto scénáři. Zvažte, jak byste tuto implementaci testovali.

## Zdroje

1. Připojte se ke komunitě MCP na [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs) a buďte v obraze o nejnovějším vývoji  
2. Přispívejte do open-source [MCP projektů](https://github.com/modelcontextprotocol)  
3. Aplikujte principy MCP ve vlastních AI iniciativách vaší organizace  
4. Prozkoumejte specializované MCP implementace pro váš obor  
5. Zvažte absolvování pokročilých kurzů na specifická témata MCP, jako je multimodální integrace nebo integrace podnikových aplikací  
6. Experimentujte s tvorbou vlastních MCP nástrojů a pracovních postupů podle principů naučených v [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)  

Další: Best Practices [případové studie](../09-CaseStudy/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za závazný zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.