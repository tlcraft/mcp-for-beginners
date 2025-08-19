<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "80e5c8949af5af0f401fce6f905990aa",
  "translation_date": "2025-07-17T10:55:13+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "sk"
}
-->
# Najlepšie postupy vývoja MCP

## Prehľad

Táto lekcia sa zameriava na pokročilé najlepšie postupy pri vývoji, testovaní a nasadzovaní MCP serverov a funkcií v produkčných prostrediach. Ako MCP ekosystémy rastú na zložitosti a význame, dodržiavanie osvedčených vzorov zabezpečuje spoľahlivosť, udržiavateľnosť a interoperabilitu. Táto lekcia zhrňuje praktické skúsenosti získané z reálnych implementácií MCP, aby vás viedla k vytváraniu robustných a efektívnych serverov s účinnými zdrojmi, promptmi a nástrojmi.

## Ciele učenia

Na konci tejto lekcie budete schopní:
- Použiť pri návrhu MCP serverov a funkcií osvedčené priemyselné postupy
- Vytvoriť komplexné testovacie stratégie pre MCP servery
- Navrhovať efektívne, znovupoužiteľné vzory pracovných tokov pre zložité MCP aplikácie
- Implementovať správne spracovanie chýb, logovanie a pozorovateľnosť v MCP serveroch
- Optimalizovať MCP implementácie z hľadiska výkonu, bezpečnosti a udržiavateľnosti

## Základné princípy MCP

Predtým, než sa pustíme do konkrétnych implementačných postupov, je dôležité pochopiť základné princípy, ktoré riadia efektívny vývoj MCP:

1. **Štandardizovaná komunikácia**: MCP používa JSON-RPC 2.0 ako základ, poskytujúc konzistentný formát pre požiadavky, odpovede a spracovanie chýb vo všetkých implementáciách.

2. **Dizajn orientovaný na používateľa**: Vždy uprednostňujte súhlas používateľa, kontrolu a transparentnosť vo vašich MCP implementáciách.

3. **Bezpečnosť na prvom mieste**: Implementujte robustné bezpečnostné opatrenia vrátane autentifikácie, autorizácie, validácie a obmedzenia rýchlosti.

4. **Modulárna architektúra**: Navrhujte MCP servery modulárne, kde každý nástroj a zdroj má jasný a zameraný účel.

5. **Stavové pripojenia**: Využívajte schopnosť MCP udržiavať stav naprieč viacerými požiadavkami pre koherentnejšie a kontextovo uvedomelejšie interakcie.

## Oficiálne najlepšie postupy MCP

Nasledujúce najlepšie postupy sú odvodené z oficiálnej dokumentácie Model Context Protocol:

### Najlepšie bezpečnostné postupy

1. **Súhlas a kontrola používateľa**: Vždy vyžadujte explicitný súhlas používateľa pred prístupom k dátam alebo vykonaním operácií. Poskytnite jasnú kontrolu nad tým, aké dáta sa zdieľajú a ktoré akcie sú autorizované.

2. **Ochrana súkromia dát**: Zverejňujte používateľské dáta len s explicitným súhlasom a chráňte ich vhodnými prístupovými kontrolami. Zabráňte neoprávnenému prenosu dát.

3. **Bezpečnosť nástrojov**: Vyžadujte explicitný súhlas používateľa pred spustením akéhokoľvek nástroja. Zabezpečte, aby používatelia rozumeli funkciám každého nástroja a uplatnite pevné bezpečnostné hranice.

4. **Kontrola povolení nástrojov**: Konfigurujte, ktoré nástroje môže model počas relácie používať, aby boli prístupné len tie, ktoré sú výslovne autorizované.

5. **Autentifikácia**: Vyžadujte správnu autentifikáciu pred udelením prístupu k nástrojom, zdrojom alebo citlivým operáciám pomocou API kľúčov, OAuth tokenov alebo iných bezpečných metód autentifikácie.

6. **Validácia parametrov**: Vynucujte validáciu všetkých volaní nástrojov, aby sa zabránilo prieniku nesprávnych alebo škodlivých vstupov do implementácií nástrojov.

7. **Obmedzovanie rýchlosti**: Implementujte obmedzovanie rýchlosti, aby ste zabránili zneužitiu a zabezpečili spravodlivé využívanie serverových zdrojov.

### Najlepšie implementačné postupy

1. **Vyjednávanie schopností**: Počas nastavovania pripojenia si vymieňajte informácie o podporovaných funkciách, verziách protokolu, dostupných nástrojoch a zdrojoch.

2. **Návrh nástrojov**: Vytvárajte zamerané nástroje, ktoré robia jednu vec dobre, namiesto monolitických nástrojov riešiacich viacero problémov naraz.

3. **Spracovanie chýb**: Implementujte štandardizované chybové správy a kódy, ktoré pomáhajú diagnostikovať problémy, zvládať zlyhania s gráciou a poskytovať použiteľnú spätnú väzbu.

4. **Logovanie**: Konfigurujte štruktúrované logy na auditovanie, ladenie a monitorovanie interakcií protokolu.

5. **Sledovanie priebehu**: Pri dlhodobých operáciách hláste aktualizácie priebehu, aby používateľské rozhrania boli responzívne.

6. **Zrušenie požiadaviek**: Umožnite klientom zrušiť požiadavky, ktoré už nie sú potrebné alebo trvajú príliš dlho.

## Ďalšie referencie

Pre najaktuálnejšie informácie o najlepších postupoch MCP navštívte:
- [MCP Dokumentácia](https://modelcontextprotocol.io/)
- [MCP Špecifikácia](https://spec.modelcontextprotocol.io/)
- [GitHub Repozitár](https://github.com/modelcontextprotocol)
- [Bezpečnostné najlepšie postupy](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## Praktické príklady implementácie

### Najlepšie postupy dizajnu nástrojov

#### 1. Princíp jednej zodpovednosti

Každý MCP nástroj by mal mať jasný a zameraný účel. Namiesto vytvárania monolitických nástrojov, ktoré sa snažia riešiť viacero problémov naraz, vyvíjajte špecializované nástroje, ktoré excelujú v konkrétnych úlohách.

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

#### 2. Konzistentné spracovanie chýb

Implementujte robustné spracovanie chýb s informatívnymi chybovými správami a vhodnými mechanizmami obnovy.

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

#### 3. Validácia parametrov

Vždy dôkladne validujte parametre, aby ste zabránili nesprávnym alebo škodlivým vstupom.

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

### Príklady implementácie bezpečnosti

#### 1. Autentifikácia a autorizácia

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

#### 2. Obmedzenie rýchlosti

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

## Najlepšie postupy testovania

### 1. Jednotkové testovanie MCP nástrojov

Vždy testujte svoje nástroje izolovane, pomocou mockovania externých závislostí:

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

### 2. Integračné testovanie

Testujte kompletný tok od požiadaviek klienta po odpovede servera:

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

## Optimalizácia výkonu

### 1. Stratégiá cachovania

Implementujte vhodné cachovanie na zníženie latencie a využitia zdrojov:

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
// Príklad v Jave s dependency injection
public class CurrencyConversionTool implements Tool {
    private final ExchangeRateService exchangeService;
    private final CacheService cacheService;
    private final Logger logger;
    
    // Závislosti injektované cez konštruktor
    public CurrencyConversionTool(
            ExchangeRateService exchangeService,
            CacheService cacheService,
            Logger logger) {
        this.exchangeService = exchangeService;
        this.cacheService = cacheService;
        this.logger = logger;
    }
    
    // Implementácia nástroja
    // ...
}
```

#### 3. Composable Tools

Design tools that can be composed together to create more complex workflows:

```python
# Príklad v Pythone ukazujúci kompozitné nástroje
class DataFetchTool(Tool):
    def get_name(self):
        return "dataFetch"
    
    # Implementácia...

class DataAnalysisTool(Tool):
    def get_name(self):
        return "dataAnalysis"
    
    # Tento nástroj môže používať výsledky z dataFetch nástroja
    async def execute_async(self, request):
        # Implementácia...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # Tento nástroj môže používať výsledky z dataAnalysis nástroja
    async def execute_async(self, request):
        # Implementácia...
        pass

# Tieto nástroje môžu byť použité samostatne alebo ako súčasť pracovného toku
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
                description = "Text vyhľadávacieho dopytu. Použite presné kľúčové slová pre lepšie výsledky." 
            },
            filters = new {
                type = "object",
                description = "Voliteľné filtre na zúženie výsledkov vyhľadávania",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "Dátumové rozpätie vo formáte YYYY-MM-DD:YYYY-MM-DD" 
                    },
                    category = new { 
                        type = "string", 
                        description = "Názov kategórie na filtrovanie" 
                    }
                }
            },
            limit = new { 
                type = "integer", 
                description = "Maximálny počet vrátených výsledkov (1-50)",
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
    
    // Vlastnosť email s validáciou formátu
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "Emailová adresa používateľa");
    
    // Vlastnosť vek s číselnými obmedzeniami
    Map<String, Object> age = new HashMap<>();
    age.put("type", "integer");
    age.put("minimum", 13);
    age.put("maximum", 120);
    age.put("description", "Vek používateľa v rokoch");
    
    // Enumerovaná vlastnosť
    Map<String, Object> subscription = new HashMap<>();
    subscription.put("type", "string");
    subscription.put("enum", Arrays.asList("free", "basic", "premium"));
    subscription.put("default", "free");
    subscription.put("description", "Úroveň predplatného");
    
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
        # Spracovanie požiadavky
        results = await self._search_database(request.parameters["query"])
        
        # Vždy vrátiť konzistentnú štruktúru
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
    """Zabezpečí, že každý prvok má konzistentnú štruktúru"""
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
            throw new ToolExecutionException($"Súbor nenájdený: {fileId}");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ToolExecutionException("Nemáte oprávnenie na prístup k tomuto súboru");
        }
        catch (Exception ex) when (ex is IOException || ex is TimeoutException)
        {
            _logger.LogError(ex, "Chyba pri prístupe k súboru {FileId}", fileId);
            throw new ToolExecutionException("Chyba pri prístupe k súboru: Služba je dočasne nedostupná");
        }
    }
    catch (JsonException)
    {
        throw new ToolExecutionException("Neplatný formát ID súboru");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Neočekávaná chyba v FileAccessTool");
        throw new ToolExecutionException("Došlo k neočakávanej chybe");
    }
}
```

#### 2. Structured Error Responses

Return structured error information when possible:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    try {
        // Implementácia
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
        
        // Znovu vyhodiť ostatné výnimky ako ToolExecutionException
        throw new ToolExecutionException("Vykonanie nástroja zlyhalo: " + ex.getMessage(), ex);
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
            # Volanie externého API
            return await self._call_api(request.parameters)
        except TransientError as e:
            retry_count += 1
            if retry_count >= max_retries:
                raise ToolExecutionException(f"Operácia zlyhala po {max_retries} pokusoch: {str(e)}")
                
            # Exponenciálne oneskorenie
            delay = base_delay * (2 ** (retry_count - 1))
            logging.warning(f"Prechodná chyba, opakujem za {delay}s: {str(e)}")
            await asyncio.sleep(delay)
        except Exception as e:
            # Neprechodná chyba, neopakovať
            raise ToolExecutionException(f"Operácia zlyhala: {str(e)}")
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
        
        // Vytvorenie kľúča cache na základe parametrov
        var cacheKey = $"data_query_{ComputeHash(query)}";
        
        // Najprv sa pokúsime získať výsledok z cache
        if (_cache.TryGetValue(cacheKey, out var cachedResult))
        {
            return new ToolResponse { Result = cachedResult };
        }
        
        // Cache neobsahuje výsledok - vykonaj skutočný dopyt
        var result = await _database.QueryAsync(query);
        
        // Ulož do cache s expiráciou
        var cacheOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
            
        _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
        
        return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
    }
    
    private string ComputeHash(string input)
    {
        // Implementácia na generovanie stabilného hashu pre kľúč cache
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
        
        // Pri dlhodobých operáciách vráťte okamžite ID spracovania
        String processId = UUID.randomUUID().toString();
        
        // Spusti asynchrónne spracovanie
        CompletableFuture.runAsync(() -> {
            try {
                // Vykonaj dlhodobú operáciu
                documentService.processDocument(documentId);
                
                // Aktualizuj stav (zvyčajne by sa ukladalo do databázy)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // Vráť okamžitú odpoveď s ID procesu
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // Nástroj na kontrolu stavu procesu
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
            tokens_per_second=5,  # Povoliť 5 požiadaviek za sekundu
            bucket_size=10        # Povoliť nárazové zaťaženie až do 10 požiadaviek
        )
    
    async def execute_async(self, request):
        # Skontroluj, či môžeme pokračovať alebo musíme počkať
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # Ak je čakanie príliš dlhé
                raise ToolExecutionException(
                    f"Limit rýchlosti prekročený. Skúste to znova o {delay:.1f} sekúnd."
                )
            else:
                # Počkaj príslušný čas
                await asyncio.sleep(delay)
        
        # Spotrebuj token a pokračuj s požiadavkou
        self.rate_limiter.consume()
        
        # Zavolaj API
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
            
            # Vypočítaj čas do dostupnosti ďalšieho tokenu
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # Pridaj nové tokeny na základe uplynulého času
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
    // Over, či parametre existujú
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("Chýba povinný parameter: query");
    }
    
    // Over správny typ
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("Parameter query musí byť reťazec");
    }
    
    var query = queryProp.GetString();
    
    // Over obsah reťazca
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("Parameter query nemôže byť prázdny");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("Parameter query presahuje maximálnu dĺžku 500 znakov");
    }
    
    // Skontroluj SQL injection útoky, ak je to relevantné
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("Neplatný dopyt: obsahuje potenciálne nebezpečný SQL kód");
    }
    
    // Pokračuj vo vykonaní
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // Získaj používateľský kontext z požiadavky
    UserContext user = request.getContext().getUserContext();
    
    // Skontroluj, či má používateľ potrebné oprávnenia
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("Používateľ nemá oprávnenie na prístup k dokumentom");
    }
    
    // Pre konkrétne zdroje skontroluj prístup k danému zdroju
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("Prístup k požadovanému dokumentu bol zamietnutý");
    }
    
    // Pokračuj vo vykonaní nástroja
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
        
        # Získaj údaje používateľa
        user_data = await self.user_service.get_user_data(user_id)
        
        # Filtrovanie citlivých údajov, pokiaľ nie sú výslovne požadované A autorizované
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # Skontroluj úroveň autorizácie v kontexte požiadavky
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # Vytvor kópiu, aby sa neovplyvnili pôvodné údaje
        redacted = user_data.copy()
        
        # Cenzuruj konkrétne citlivé polia
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # Cenzuruj vnorené citlivé údaje
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
    // Príprava
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("Seattle", 3))
        .ReturnsAsync(new WeatherForecast(/* testovacie dáta */));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "Seattle", 
            days = 3 
        })
    );
    
    // Vykonanie
    var response = await tool.ExecuteAsync(request);
    
    // Overenie
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // Príprava
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("InvalidLocation", It.IsAny<int>()))
        .ThrowsAsync(new LocationNotFoundException("Miesto nebolo nájdené"));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "InvalidLocation", 
            days = 3 
        })
    );
    
    // Vykonanie a overenie
    var exception = await Assert.ThrowsAsync<ToolExecutionException>(
        () => tool.ExecuteAsync(request)
    );
    
    Assert.Contains("Miesto nebolo nájdené", exception.Message);
}
```

#### 2. Schema Validation Testing

Test that schemas are valid and properly enforce constraints:

```java
@Test
public void testSchemaValidation() {
    // Vytvor inštanciu nástroja
    SearchTool searchTool = new SearchTool();
    
    // Získaj schému
    Object schema = searchTool.getSchema();
    
    // Prekonvertuj schému do JSON pre validáciu
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // Over, že schéma je platný JSONSchema
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // Testuj platné parametre
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // Testuj chýbajúci povinný parameter
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // Testuj neplatný typ parametra
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
    # Príprava
    tool = ApiTool(timeout=0.1)  # Veľmi krátky timeout
    
    # Mock požiadavky, ktorá vyprší časový limit
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # Dlhšie ako timeout
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # Vykonanie a overenie
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Over správu výnimky
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # Príprava
    tool = ApiTool()
    
    # Mock odpovede s obmedzením rýchlosti
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
        
        # Vykonanie a overenie
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Over, že výnimka obsahuje informácie o limite rýchlosti
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
    // Príprava
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // Vykonanie
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

// Overenie
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
        // Otestuj endpoint pre zistenie nástrojov
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // Vytvor požiadavku na nástroj
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // Pošli požiadavku a over odpoveď
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // Vytvor neplatnú požiadavku na nástroj
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // Chýba parameter "b"
        request.put("parameters", parameters);
        
        // Pošli požiadavku a over chybu v odpovedi
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
    # Príprava - nastavenie MCP klienta a mock modelu
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # Mock odpovede modelu
    mock_model = MockLanguageModel([
        MockResponse(
            "Aké je počasie v Seattli?",
            tool_calls=[{
                "tool_name": "weatherForecast",
                "parameters": {"location": "Seattle", "days": 3}
            }]
        ),
        MockResponse(
            "Tu je predpoveď počasia pre Seattle:\n- Dnes: 65°F, čiastočne oblačno\n- Zajtra: 68°F, slnečno\n- Pozajtra: 62°F, dážď",
            tool_calls=[]
        )
    ])
    
    # Mock odpoveď nástroja počasia
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
        
        # Vykonanie
        response = await mcp_client.send_prompt(
            "Aké je počasie v Seattli?",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # Overenie
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
    // Príprava
    var server = new McpServer(
        name: "TestServer",
        version: "1.0",
        maxConcurrentRequests: 100
    );
    
    server.RegisterTool(new FastExecutingTool());
    await server.StartAsync();
    
    var client = new McpClient("http://localhost:5000");
    
    // Vykonanie
    var tasks = new List<Task<McpResponse>>();
    for (int i = 0; i < 1000; i++)
    {
        tasks.Add(client.ExecuteToolAsync("fastTool", new { iteration = i }));
    }
    
    var results = await Task.WhenAll(tasks);
    
    // Overenie
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
    
    // Nastavenie JMeter pre záťažové testovanie
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // Konfigurácia testovacieho plánu JMeter
    HashTree testPlanTree = new HashTree();
    
    // Vytvorenie testovacieho plánu, skupiny vlákien, samplerov atď.
    TestPlan testPlan = new TestPlan("MCP Server Stress Test");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // Pridanie HTTP sampleru pre vykonanie nástroja
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // Pridanie poslucháčov
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // Spustenie testu
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // Overenie výsledkov
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // Priemerný čas odozvy < 200ms
    assertTrue(summaryReport.getPercentile(90.0) < 500); // 90. percentil < 500ms
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# Konfigurácia monitoringu pre MCP server
def configure_monitoring(server):
    # Nastavenie Prometheus metrík
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "Celkový počet MCP požiadaviek"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "Dĺžka trvania požiadavky v sekundách",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "Počet vykonaní nástrojov",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "Dĺžka vykonávania nástroja v sekundách",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "Chyby pri vykonávaní nástrojov",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # Pridanie middleware pre meranie času a zaznamenávanie metrík
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # Sprístupnenie endpointu pre metriky
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
# Implementácia reťazca nástrojov v Pythone
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # Zoznam názvov nástrojov, ktoré sa vykonávajú postupne
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # Vykonaj každý nástroj v reťazci, pričom ako vstup použije predchádzajúci výsledok
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # Ulož výsledok a použij ho ako vstup pre ďalší nástroj
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# Príklad použitia
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
    public string Description => "Spracováva obsah rôznych typov";
    
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
        
        // Urči, ktorý špecializovaný nástroj použiť
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // Preposli požiadavku špecializovanému nástroju
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

Tento modul poskytuje nástroje na spracovanie CSV súborov efektívne a jednoducho.

## Funkcie

- `loadCSV(filePath)`: Načíta CSV súbor z daného `filePath` a vráti jeho obsah ako pole objektov.
- `parseRow(row)`: Analyzuje jednotlivý riadok CSV a prevedie ho na objekt.
- `filterRows(data, criteria)`: Filtruje pole dát podľa zadaných kritérií.
- `exportCSV(data, destination)`: Exportuje pole dát späť do CSV formátu a uloží ho na `destination`.

## Použitie

```javascript
const data = loadCSV('data.csv');
const filtered = filterRows(data, { status: 'active' });
exportCSV(filtered, 'filtered_data.csv');
```

[!NOTE]  
Uistite sa, že CSV súbor má správnu štruktúru a kódovanie UTF-8, aby sa predišlo problémom pri načítaní.

[!WARNING]  
Funkcia `exportCSV` prepíše existujúci súbor bez varovania.

## Tipy

- Pri práci s veľkými CSV súbormi zvážte použitie streamovania na zníženie spotreby pamäte.
- Použite `parseRow` na validáciu a čistenie dát pred ich ďalším spracovaním.

## Chyby

- `loadCSV` vyhodí chybu, ak súbor neexistuje alebo nie je prístupný.
- `parseRow` môže vrátiť `null`, ak riadok nevyhovuje očakávanému formátu.

## Kontakt

Pre viac informácií navštívte dokumentáciu alebo kontaktujte podporu.
("code", _) => "codeAnalyzer",
_ => throw new ToolExecutionException($"Nástroj nie je dostupný pre {contentType}/{operation}")
};
}

private object GetOptionsForTool(string toolName, string operation)
{
// Vráti vhodné možnosti pre každý špecializovaný nástroj
return toolName switch
{
    "textSummarizer" => new { length = "medium" },
    "htmlProcessor" => new { cleanUp = true, operation },
    // Možnosti pre ďalšie nástroje...
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
        // Krok 1: Získať metadata datasetu (synchronne)
        ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata", 
            Map.of("datasetId", datasetId));
        
        // Krok 2: Spustiť viacero analýz paralelne
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
        
        // Počkajte, kým všetky paralelné úlohy dokončia prácu
        CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
            statisticalAnalysis, correlationAnalysis, outlierDetection
        );
        
        allAnalyses.join();  // Čaká na dokončenie
        
        // Krok 3: Spojiť výsledky
        Map<String, Object> combinedResults = new HashMap<>();
        combinedResults.put("metadata", metadataResponse.getResult());
        combinedResults.put("statistics", statisticalAnalysis.join().getResult());
        combinedResults.put("correlations", correlationAnalysis.join().getResult());
        combinedResults.put("outliers", outlierDetection.join().getResult());
        
        // Krok 4: Vygenerovať súhrnnú správu
        ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator", 
            Map.of("analysisResults", combinedResults));
        
        // Vrátiť kompletný výsledok workflow
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
            # Najprv skúsiť primárny nástroj
            response = await self.client.execute_tool(primary_tool, parameters)
            return {
                "result": response.result,
                "source": "primary",
                "tool": primary_tool
            }
        except ToolExecutionException as e:
            # Zaznamenať zlyhanie
            logging.warning(f"Primárny nástroj '{primary_tool}' zlyhal: {str(e)}")
            
            # Prejsť na záložný nástroj
            try:
                # Možno bude potrebné upraviť parametre pre záložný nástroj
                fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)
                
                response = await self.client.execute_tool(fallback_tool, fallback_params)
                return {
                    "result": response.result,
                    "source": "fallback",
                    "tool": fallback_tool,
                    "primaryError": str(e)
                }
            except ToolExecutionException as fallback_error:
                # Oba nástroje zlyhali
                logging.error(f"Oba nástroje, primárny aj záložný, zlyhali. Chyba záložného: {str(fallback_error)}")
                raise WorkflowExecutionException(
                    f"Workflow zlyhal: primárna chyba: {str(e)}; chyba záložného: {str(fallback_error)}"
                )
    
    def _adapt_parameters(self, params, from_tool, to_tool):
        """Prispôsobiť parametre medzi rôznymi nástrojmi, ak je to potrebné"""
        # Táto implementácia závisí od konkrétnych nástrojov
        # V tomto príklade jednoducho vrátime pôvodné parametre
        return params

# Príklad použitia
async def get_weather(workflow, location):
    return await workflow.execute_with_fallback(
        "premiumWeatherService",  # Primárne (platené) API počasia
        "basicWeatherService",    # Záložné (bezplatné) API počasia
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
            
            // Uložiť výsledok každého workflow
            results[workflow.Name] = workflowResult;
            
            // Aktualizovať kontext výsledkom pre ďalší workflow
            context = context.WithResult(workflow.Name, workflowResult);
        }
        
        return new WorkflowResult(results);
    }
    
    public string Name => "CompositeWorkflow";
    public string Description => "Spúšťa viacero workflow postupne za sebou";
}

// Príklad použitia
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
// Príklad jednotkového testu pre kalkulačný nástroj v C#
[Fact]
public async Task CalculatorTool_Add_ReturnsCorrectSum()
{
    // Príprava
    var calculator = new CalculatorTool();
    var parameters = new Dictionary<string, object>
    {
        ["operation"] = "add",
        ["a"] = 5,
        ["b"] = 7
    };
    
    // Vykonanie
    var response = await calculator.ExecuteAsync(parameters);
    var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());
    
    // Overenie
    Assert.Equal(12, result.Value);
}
```

```python
# Príklad jednotkového testu pre kalkulačný nástroj v Pythone
def test_calculator_tool_add():
    # Príprava
    calculator = CalculatorTool()
    parameters = {
        "operation": "add",
        "a": 5,
        "b": 7
    }
    
    # Vykonanie
    response = calculator.execute(parameters)
    result = json.loads(response.content[0].text)
    
    # Overenie
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
// Príklad integračného testu pre MCP server v C#
[Fact]
public async Task Server_ProcessToolRequest_ReturnsValidResponse()
{
    // Príprava
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
    
    // Vykonanie
    var response = await server.ProcessRequestAsync(request);
    
    // Overenie
    Assert.NotNull(response);
    Assert.Equal(McpStatusCodes.Success, response.StatusCode);
    // Ďalšie overenia obsahu odpovede
    
    // Upratovanie
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
// Príklad E2E testu s klientom v TypeScripte
describe('MCP Server E2E Tests', () => {
  let client: McpClient;
  
  beforeAll(async () => {
    // Spustiť server v testovacom prostredí
    await startTestServer();
    client = new McpClient('http://localhost:5000');
  });
  
  afterAll(async () => {
    await stopTestServer();
  });
  
  test('Klient dokáže zavolať kalkulačný nástroj a získať správny výsledok', async () => {
    // Vykonanie
    const response = await client.invokeToolAsync('calculator', {
      operation: 'divide',
      a: 20,
      b: 4
    });
    
    // Overenie
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
// Príklad v C# s Moq
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
# Príklad v Pythone s unittest.mock
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
    # Konfigurácia mocku
    mock_model.return_value.generate_response.return_value = {
        "text": "Mocked model response",
        "finish_reason": "completed"
    }
    
    # Použitie mocku v teste
    server = McpServer(model_client=mock_model)
    # Pokračovanie testu
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
// k6 skript na záťažové testovanie MCP servera
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  vus: 10,  // 10 virtuálnych používateľov
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
    'doba odozvy < 500ms': (r) => r.timings.duration < 500,
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

1. **API Endpointy**: Testujte požadované endpointy (/resources, /tools, atď.)  
2. **Formát požiadaviek/odpovedí**: Validujte súlad so schémou  
3. **Chybové kódy**: Overte správne status kódy pre rôzne scenáre  
4. **Typy obsahu**: Testujte spracovanie rôznych typov obsahu  
5. **Autentifikačný tok**: Overte mechanizmy autentifikácie v súlade so špecifikáciou  

### Compliance Test Suite

```csharp
[Fact]
public async Task Server_ResourceEndpoint_ReturnsCorrectSchema()
{
    // Arrange
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");
    
    // Act
    var response = await client.GetAsync("http://localhost:5000/api/resources");
    var content = await response.Content.ReadAsStringAsync();
    var resources = JsonSerializer.Deserialize<ResourceList>(content);
    
    // Assert
    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    Assert.NotNull(resources);
    Assert.All(resources.Resources, resource => 
    {
        Assert.NotNull(resource.Id);
        Assert.NotNull(resource.Type);
        // Additional schema validation
    });
}
```

## Top 10 tipov pre efektívne testovanie MCP servera

1. **Testujte definície nástrojov samostatne**: Overujte definície schém nezávisle od logiky nástrojov  
2. **Používajte parameterizované testy**: Testujte nástroje s rôznymi vstupmi vrátane hraničných prípadov  
3. **Kontrolujte chybové odpovede**: Overte správne spracovanie chýb pre všetky možné chybové stavy  
4. **Testujte autorizačnú logiku**: Zabezpečte správnu kontrolu prístupu pre rôzne používateľské roly  
5. **Sledujte pokrytie testami**: Usilujte o vysoké pokrytie kritických častí kódu  
6. **Testujte streamingové odpovede**: Overte správne spracovanie streamovaného obsahu  
7. **Simulujte sieťové problémy**: Testujte správanie pri zlých sieťových podmienkach  
8. **Testujte limity zdrojov**: Overte správanie pri dosiahnutí kvót alebo limitov rýchlosti  
9. **Automatizujte regresné testy**: Vytvorte sadu testov, ktoré sa spúšťajú pri každej zmene kódu  
10. **Dokumentujte testovacie prípady**: Udržiavajte jasnú dokumentáciu testovacích scenárov  

## Bežné chyby pri testovaní

- **Prílišné spoliehanie sa na testovanie "šťastnej cesty"**: Uistite sa, že dôkladne testujete chybové prípady  
- **Ignorovanie výkonnostného testovania**: Identifikujte úzke miesta skôr, než ovplyvnia produkciu  
- **Testovanie iba v izolácii**: Kombinujte jednotkové, integračné a E2E testy  
- **Neúplné pokrytie API**: Zabezpečte testovanie všetkých endpointov a funkcií  
- **Nekonzistentné testovacie prostredia**: Používajte kontajnery pre zabezpečenie konzistentnosti prostredí  

## Záver

Komplexná testovacia stratégia je nevyhnutná pre vývoj spoľahlivých a kvalitných MCP serverov. Implementáciou najlepších postupov a tipov uvedených v tomto návode môžete zabezpečiť, že vaše MCP implementácie dosiahnu najvyššie štandardy kvality, spoľahlivosti a výkonu.

## Kľúčové poznatky

1. **Návrh nástrojov**: Dodržiavajte princíp jednej zodpovednosti, používajte dependency injection a navrhujte pre skladateľnosť  
2. **Návrh schém**: Vytvárajte jasné, dobre zdokumentované schémy s vhodnými validačnými obmedzeniami  
3. **Spracovanie chýb**: Implementujte elegantné spracovanie chýb, štruktúrované chybové odpovede a logiku opakovania  
4. **Výkon**: Používajte caching, asynchrónne spracovanie a obmedzovanie zdrojov  
5. **Bezpečnosť**: Aplikujte dôkladnú validáciu vstupov, kontroly autorizácie a spracovanie citlivých údajov  
6. **Testovanie**: Vytvárajte komplexné jednotkové, integračné a end-to-end testy  
7. **Vzory pracovných tokov**: Používajte osvedčené vzory ako reťazce, dispečery a paralelné spracovanie  

## Cvičenie

Navrhnite MCP nástroj a pracovný tok pre systém spracovania dokumentov, ktorý:  

1. Prijíma dokumenty v rôznych formátoch (PDF, DOCX, TXT)  
2. Extrahuje text a kľúčové informácie z dokumentov  
3. Klasifikuje dokumenty podľa typu a obsahu  
4. Generuje zhrnutie každého dokumentu  

Implementujte schémy nástrojov, spracovanie chýb a pracovný tok, ktorý najlepšie vyhovuje tomuto scenáru. Zvážte, ako by ste testovali túto implementáciu.

## Zdroje

1. Pripojte sa ku komunite MCP na [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs), aby ste zostali informovaní o najnovších novinkách  
2. Prispievajte do open-source [MCP projektov](https://github.com/modelcontextprotocol)  
3. Aplikujte MCP princípy vo vlastných AI iniciatívach vašej organizácie  
4. Preskúmajte špecializované MCP implementácie pre váš priemysel  
5. Zvážte absolvovanie pokročilých kurzov na špecifické témy MCP, ako je multimodálna integrácia alebo integrácia podnikových aplikácií  
6. Experimentujte s tvorbou vlastných MCP nástrojov a pracovných postupov podľa princípov naučených v [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)  

Ďalej: Najlepšie postupy [prípadové štúdie](../09-CaseStudy/README.md)  

**Zrieknutie sa zodpovednosti**:  
Tento dokument bol preložený pomocou služby AI prekladu [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, berte na vedomie, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nenesieme zodpovednosť za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.