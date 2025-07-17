<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "80e5c8949af5af0f401fce6f905990aa",
  "translation_date": "2025-07-17T12:02:32+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "hr"
}
-->
# Najbolje prakse za razvoj MCP-a

## Pregled

Ova lekcija fokusira se na napredne najbolje prakse za razvoj, testiranje i implementaciju MCP servera i značajki u produkcijskim okruženjima. Kako MCP ekosustavi postaju složeniji i važniji, pridržavanje utvrđenih obrazaca osigurava pouzdanost, održivost i interoperabilnost. Ova lekcija objedinjuje praktične spoznaje stečene kroz stvarne MCP implementacije kako bi vas vodila u stvaranju robusnih, učinkovitih servera s učinkovitim resursima, promptovima i alatima.

## Ciljevi učenja

Na kraju ove lekcije moći ćete:
- Primijeniti najbolje industrijske prakse u dizajnu MCP servera i značajki
- Kreirati sveobuhvatne strategije testiranja MCP servera
- Dizajnirati učinkovite, višekratno upotrebljive obrasce radnih tokova za složene MCP aplikacije
- Implementirati pravilno rukovanje pogreškama, zapisivanje i promatranje u MCP serverima
- Optimizirati MCP implementacije za performanse, sigurnost i održivost

## Osnovna načela MCP-a

Prije nego što prijeđemo na specifične prakse implementacije, važno je razumjeti osnovna načela koja vode učinkoviti razvoj MCP-a:

1. **Standardizirana komunikacija**: MCP koristi JSON-RPC 2.0 kao temelj, pružajući dosljedan format za zahtjeve, odgovore i rukovanje pogreškama u svim implementacijama.

2. **Dizajn usmjeren na korisnika**: Uvijek dajte prioritet pristanku korisnika, kontroli i transparentnosti u vašim MCP implementacijama.

3. **Sigurnost na prvom mjestu**: Implementirajte snažne sigurnosne mjere uključujući autentifikaciju, autorizaciju, validaciju i ograničavanje brzine.

4. **Modularna arhitektura**: Dizajnirajte svoje MCP servere modularno, gdje svaki alat i resurs ima jasnu, fokusiranu svrhu.

5. **Stanje veza**: Iskoristite mogućnost MCP-a da održava stanje kroz više zahtjeva za koherentnije i kontekstualno svjesne interakcije.

## Službene najbolje prakse MCP-a

Sljedeće najbolje prakse izvedene su iz službene dokumentacije Model Context Protocola:

### Najbolje prakse za sigurnost

1. **Pristanak i kontrola korisnika**: Uvijek zahtijevajte izričit pristanak korisnika prije pristupa podacima ili izvođenja operacija. Omogućite jasnu kontrolu nad time koji se podaci dijele i koje su radnje ovlaštene.

2. **Privatnost podataka**: Izlažite korisničke podatke samo uz izričit pristanak i štitite ih odgovarajućim kontrolama pristupa. Zaštitite od neovlaštenog prijenosa podataka.

3. **Sigurnost alata**: Zahtijevajte izričit pristanak korisnika prije pozivanja bilo kojeg alata. Osigurajte da korisnici razumiju funkcionalnost svakog alata i provodite snažne sigurnosne granice.

4. **Kontrola dopuštenja alata**: Konfigurirajte koje alate model smije koristiti tijekom sesije, osiguravajući da su dostupni samo eksplicitno ovlašteni alati.

5. **Autentifikacija**: Zahtijevajte ispravnu autentifikaciju prije nego što se omogući pristup alatima, resursima ili osjetljivim operacijama koristeći API ključeve, OAuth tokene ili druge sigurne metode autentifikacije.

6. **Validacija parametara**: Provodite validaciju za sva pozivanja alata kako biste spriječili da neispravan ili zlonamjeran unos dođe do implementacija alata.

7. **Ograničenje brzine**: Implementirajte ograničenje brzine kako biste spriječili zloupotrebu i osigurali poštenu upotrebu resursa servera.

### Najbolje prakse implementacije

1. **Pregovaranje mogućnosti**: Tijekom uspostave veze razmijenite informacije o podržanim značajkama, verzijama protokola, dostupnim alatima i resursima.

2. **Dizajn alata**: Kreirajte fokusirane alate koji dobro obavljaju jednu stvar, umjesto monolitnih alata koji pokrivaju više područja.

3. **Rukovanje pogreškama**: Implementirajte standardizirane poruke i kodove pogrešaka kako biste olakšali dijagnostiku problema, elegantno rukovali neuspjesima i pružili korisne povratne informacije.

4. **Zapisivanje**: Konfigurirajte strukturirane zapise za reviziju, otklanjanje pogrešaka i nadzor interakcija protokola.

5. **Praćenje napretka**: Za dugotrajne operacije izvještavajte o napretku kako biste omogućili responzivne korisničke sučelja.

6. **Otkaži zahtjev**: Omogućite klijentima da otkažu zahtjeve u tijeku koji više nisu potrebni ili traju predugo.

## Dodatne reference

Za najnovije informacije o najboljim praksama MCP-a, pogledajte:
- [MCP Dokumentacija](https://modelcontextprotocol.io/)
- [MCP Specifikacija](https://spec.modelcontextprotocol.io/)
- [GitHub Repozitorij](https://github.com/modelcontextprotocol)
- [Najbolje prakse za sigurnost](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## Primjeri praktične implementacije

### Najbolje prakse dizajna alata

#### 1. Princip jedne odgovornosti

Svaki MCP alat treba imati jasnu, fokusiranu svrhu. Umjesto stvaranja monolitnih alata koji pokušavaju pokriti više područja, razvijajte specijalizirane alate koji su izvrsni u određenim zadacima.

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

#### 2. Dosljedno rukovanje pogreškama

Implementirajte robusno rukovanje pogreškama s informativnim porukama i odgovarajućim mehanizmima oporavka.

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

#### 3. Validacija parametara

Uvijek temeljito validirajte parametre kako biste spriječili neispravan ili zlonamjeran unos.

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

### Primjeri implementacije sigurnosti

#### 1. Autentifikacija i autorizacija

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

#### 2. Ograničenje brzine

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

## Najbolje prakse testiranja

### 1. Jedinično testiranje MCP alata

Uvijek testirajte svoje alate izolirano, koristeći mockove za vanjske ovisnosti:

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

### 2. Integracijsko testiranje

Testirajte kompletan tijek od zahtjeva klijenta do odgovora servera:

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

## Optimizacija performansi

### 1. Strategije keširanja

Implementirajte odgovarajuće keširanje kako biste smanjili latenciju i potrošnju resursa:

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
// Java primjer s injekcijom ovisnosti
public class CurrencyConversionTool implements Tool {
    private final ExchangeRateService exchangeService;
    private final CacheService cacheService;
    private final Logger logger;
    
    // Ovisnosti se ubacuju kroz konstruktor
    public CurrencyConversionTool(
            ExchangeRateService exchangeService,
            CacheService cacheService,
            Logger logger) {
        this.exchangeService = exchangeService;
        this.cacheService = cacheService;
        this.logger = logger;
    }
    
    // Implementacija alata
    // ...
}
```

#### 3. Composable Tools

Design tools that can be composed together to create more complex workflows:

```python
# Python primjer koji prikazuje kompozabilne alate
class DataFetchTool(Tool):
    def get_name(self):
        return "dataFetch"
    
    # Implementacija...

class DataAnalysisTool(Tool):
    def get_name(self):
        return "dataAnalysis"
    
    # Ovaj alat može koristiti rezultate iz dataFetch alata
    async def execute_async(self, request):
        # Implementacija...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # Ovaj alat može koristiti rezultate iz dataAnalysis alata
    async def execute_async(self, request):
        # Implementacija...
        pass

# Ovi alati se mogu koristiti samostalno ili kao dio radnog toka
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
                description = "Tekst upita za pretraživanje. Koristite precizne ključne riječi za bolje rezultate." 
            },
            filters = new {
                type = "object",
                description = "Opcionalni filtri za sužavanje rezultata pretraživanja",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "Raspon datuma u formatu YYYY-MM-DD:YYYY-MM-DD" 
                    },
                    category = new { 
                        type = "string", 
                        description = "Naziv kategorije za filtriranje" 
                    }
                }
            },
            limit = new { 
                type = "integer", 
                description = "Maksimalan broj rezultata za prikaz (1-50)",
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
    
    // Svojstvo email s validacijom formata
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "Email adresa korisnika");
    
    // Svojstvo dob s numeričkim ograničenjima
    Map<String, Object> age = new HashMap<>();
    age.put("type", "integer");
    age.put("minimum", 13);
    age.put("maximum", 120);
    age.put("description", "Dob korisnika u godinama");
    
    // Enumerirano svojstvo
    Map<String, Object> subscription = new HashMap<>();
    subscription.put("type", "string");
    subscription.put("enum", Arrays.asList("free", "basic", "premium"));
    subscription.put("default", "free");
    subscription.put("description", "Razina pretplate");
    
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
        # Obrada zahtjeva
        results = await self._search_database(request.parameters["query"])
        
        # Uvijek vraćajte dosljednu strukturu
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
    """Osigurava da svaki element ima dosljednu strukturu"""
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
            throw new ToolExecutionException($"Datoteka nije pronađena: {fileId}");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ToolExecutionException("Nemate dopuštenje za pristup ovoj datoteci");
        }
        catch (Exception ex) when (ex is IOException || ex is TimeoutException)
        {
            _logger.LogError(ex, "Pogreška pri pristupu datoteci {FileId}", fileId);
            throw new ToolExecutionException("Pogreška pri pristupu datoteci: Usluga je privremeno nedostupna");
        }
    }
    catch (JsonException)
    {
        throw new ToolExecutionException("Neispravan format ID-a datoteke");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Neočekivana pogreška u FileAccessTool");
        throw new ToolExecutionException("Došlo je do neočekivane pogreške");
    }
}
```

#### 2. Structured Error Responses

Return structured error information when possible:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    try {
        // Implementacija
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
        
        // Ponovno baci ostale iznimke kao ToolExecutionException
        throw new ToolExecutionException("Izvršenje alata nije uspjelo: " + ex.getMessage(), ex);
    }
}
```

#### 3. Retry Logic

Implement appropriate retry logic for transient failures:

```python
async def execute_async(self, request):
    max_retries = 3
    retry_count = 0
    base_delay = 1  # sekunde
    
    while retry_count < max_retries:
        try:
            # Poziv vanjskog API-ja
            return await self._call_api(request.parameters)
        except TransientError as e:
            retry_count += 1
            if retry_count >= max_retries:
                raise ToolExecutionException(f"Operacija nije uspjela nakon {max_retries} pokušaja: {str(e)}")
                
            # Eksponencijalno odgađanje
            delay = base_delay * (2 ** (retry_count - 1))
            logging.warning(f"Privremena pogreška, ponovni pokušaj za {delay}s: {str(e)}")
            await asyncio.sleep(delay)
        except Exception as e:
            # Neprekinuta pogreška, ne ponavljaj
            raise ToolExecutionException(f"Operacija nije uspjela: {str(e)}")
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
    
    // Kreiraj ključ za cache na temelju parametara
    var cacheKey = $"data_query_{ComputeHash(query)}";
    
    // Pokušaj prvo dohvatiti iz cachea
    if (_cache.TryGetValue(cacheKey, out var cachedResult))
    {
        return new ToolResponse { Result = cachedResult };
    }
    
    // Cache promašaj - izvrši stvarni upit
    var result = await _database.QueryAsync(query);
    
    // Spremi u cache s istekom
    var cacheOptions = new MemoryCacheEntryOptions()
        .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
        
    _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
    
    return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
}

private string ComputeHash(string input)
{
    // Implementacija za generiranje stabilnog hasha za ključ cachea
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
        
        // Za dugotrajne operacije odmah vrati ID procesa
        String processId = UUID.randomUUID().toString();
        
        // Pokreni asinkronu obradu
        CompletableFuture.runAsync(() -> {
            try {
                // Izvrši dugotrajnu operaciju
                documentService.processDocument(documentId);
                
                // Ažuriraj status (obično se sprema u bazu podataka)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // Vrati trenutni odgovor s ID-om procesa
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // Pomoćni alat za provjeru statusa procesa
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
            tokens_per_second=5,  # Dozvoli 5 zahtjeva u sekundi
            bucket_size=10        # Dozvoli nagle skokove do 10 zahtjeva
        )
    
    async def execute_async(self, request):
        # Provjeri možemo li nastaviti ili moramo čekati
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # Ako je čekanje predugo
                raise ToolExecutionException(
                    f"Prekoračen limit brzine. Molimo pokušajte ponovno za {delay:.1f} sekundi."
                )
            else:
                # Pričekaj odgovarajuće vrijeme
                await asyncio.sleep(delay)
        
        # Potroši token i nastavi s zahtjevom
        self.rate_limiter.consume()
        
        # Pozovi API
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
            
            # Izračunaj vrijeme do dostupnosti sljedećeg tokena
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # Dodaj nove tokene na temelju proteklog vremena
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
    // Provjeri postoje li parametri
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("Nedostaje obavezni parametar: query");
    }
    
    // Provjeri ispravan tip
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("Parametar query mora biti string");
    }
    
    var query = queryProp.GetString();
    
    // Provjeri sadržaj stringa
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("Parametar query ne može biti prazan");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("Parametar query prelazi maksimalnu duljinu od 500 znakova");
    }
    
    // Provjeri SQL injekcije ako je primjenjivo
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("Neispravan upit: sadrži potencijalno nesiguran SQL");
    }
    
    // Nastavi s izvršenjem
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // Dohvati korisnički kontekst iz zahtjeva
    UserContext user = request.getContext().getUserContext();
    
    // Provjeri ima li korisnik potrebne dozvole
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("Korisnik nema dozvolu za pristup dokumentima");
    }
    
    // Za određene resurse provjeri pristup tom resursu
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("Pristup traženom dokumentu odbijen");
    }
    
    // Nastavi s izvršenjem alata
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
        
        # Dohvati korisničke podatke
        user_data = await self.user_service.get_user_data(user_id)
        
        # Filtriraj osjetljiva polja osim ako nije izričito zatraženo I ovlašteno
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # Provjeri razinu ovlaštenja u kontekstu zahtjeva
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # Napravi kopiju da se ne mijenja original
        redacted = user_data.copy()
        
        # Sakrij određena osjetljiva polja
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # Sakrij ugniježđene osjetljive podatke
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
    // Priprema
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("Seattle", 3))
        .ReturnsAsync(new WeatherForecast(/* testni podaci */));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "Seattle", 
            days = 3 
        })
    );
    
    // Izvršenje
    var response = await tool.ExecuteAsync(request);
    
    // Provjera
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // Priprema
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("InvalidLocation", It.IsAny<int>()))
        .ThrowsAsync(new LocationNotFoundException("Lokacija nije pronađena"));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "InvalidLocation", 
            days = 3 
        })
    );
    
    // Izvršenje i provjera
    var exception = await Assert.ThrowsAsync<ToolExecutionException>(
        () => tool.ExecuteAsync(request)
    );
    
    Assert.Contains("Lokacija nije pronađena", exception.Message);
}
```

#### 2. Schema Validation Testing

Test that schemas are valid and properly enforce constraints:

```java
@Test
public void testSchemaValidation() {
    // Kreiraj instancu alata
    SearchTool searchTool = new SearchTool();
    
    // Dohvati shemu
    Object schema = searchTool.getSchema();
    
    // Pretvori shemu u JSON za validaciju
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // Validiraj da je shema valjani JSONSchema
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // Testiraj valjane parametre
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // Testiraj nedostajući obavezni parametar
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // Testiraj neispravan tip parametra
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
    # Priprema
    tool = ApiTool(timeout=0.1)  # Vrlo kratak timeout
    
    # Mock zahtjev koji će istek vremena
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # Duže od timeouta
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # Izvršenje i provjera
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Provjeri poruku iznimke
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # Priprema
    tool = ApiTool()
    
    # Mock odgovor s ograničenjem brzine
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
        
        # Izvršenje i provjera
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Provjeri da iznimka sadrži informacije o ograničenju brzine
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
    // Priprema
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // Izvršenje
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

// Provjera
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
        // Testiraj endpoint za pronalazak alata
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // Kreiraj zahtjev za alat
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // Pošalji zahtjev i provjeri odgovor
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // Kreiraj neispravan zahtjev za alat
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // Nedostaje parametar "b"
        request.put("parameters", parameters);
        
        // Pošalji zahtjev i provjeri odgovor s greškom
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
    # Priprema - postavi MCP klijenta i lažni model
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # Lažni odgovori modela
    mock_model = MockLanguageModel([
        MockResponse(
            "Kakvo je vrijeme u Seattleu?",
            tool_calls=[{
                "tool_name": "weatherForecast",
                "parameters": {"location": "Seattle", "days": 3}
            }]
        ),
        MockResponse(
            "Evo vremenske prognoze za Seattle:\n- Danas: 65°F, djelomično oblačno\n- Sutra: 68°F, sunčano\n- Prekosutra: 62°F, kiša",
            tool_calls=[]
        )
    ])
    
    # Lažni odgovor alata za vremensku prognozu
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
        
        # Izvrši
        response = await mcp_client.send_prompt(
            "Kakvo je vrijeme u Seattleu?",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # Provjera
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
    // Priprema
    var server = new McpServer(
        name: "TestServer",
        version: "1.0",
        maxConcurrentRequests: 100
    );
    
    server.RegisterTool(new FastExecutingTool());
    await server.StartAsync();
    
    var client = new McpClient("http://localhost:5000");
    
    // Izvršenje
    var tasks = new List<Task<McpResponse>>();
    for (int i = 0; i < 1000; i++)
    {
        tasks.Add(client.ExecuteToolAsync("fastTool", new { iteration = i }));
    }
    
    var results = await Task.WhenAll(tasks);
    
    // Provjera
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
    
    // Postavi JMeter za stres testiranje
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // Konfiguriraj test plan za JMeter
    HashTree testPlanTree = new HashTree();
    
    // Kreiraj test plan, thread group, samplere itd.
    TestPlan testPlan = new TestPlan("MCP Server Stress Test");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // Dodaj HTTP sampler za izvršenje alata
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // Dodaj slušatelje
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // Pokreni test
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // Validiraj rezultate
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // Prosječno vrijeme odziva < 200ms
    assertTrue(summaryReport.getPercentile(90.0) < 500); // 90. percentil < 500ms
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# Konfiguriraj nadzor za MCP server
def configure_monitoring(server):
    # Postavi Prometheus metrike
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "Ukupan broj MCP zahtjeva"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "Trajanje zahtjeva u sekundama",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "Broj izvršenja alata",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "Trajanje izvršenja alata u sekundama",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "Greške pri izvršenju alata",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # Dodaj middleware za mjerenje vremena i bilježenje metrika
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # Izloži endpoint za metrike
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
# Implementacija lanca alata u Pythonu
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # Lista imena alata koji se izvršavaju redom
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # Izvrši svaki alat u lancu, prosljeđujući prethodni rezultat
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # Spremi rezultat i koristi ga kao ulaz za sljedeći alat
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# Primjer korištenja
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
    public string Description => "Obrađuje sadržaj različitih tipova";
    
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
        
        // Odredi koji specijalizirani alat koristiti
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // Proslijedi zahtjev specijaliziranom alatu
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

Ovaj modul omogućuje jednostavnu obradu CSV datoteka u vašim aplikacijama.

## Funkcionalnosti

- Učitavanje CSV datoteka iz lokalnog sustava ili URL-a
- Parsiranje podataka u strukturirani format
- Filtriranje i sortiranje podataka prema zadanim kriterijima
- Izvoz obrađenih podataka natrag u CSV format

## Primjer korištenja

```python
from csvProcessor import load_csv, filter_data, export_csv

# Učitaj CSV datoteku
data = load_csv('primjer.csv')

# Filtriraj podatke gdje je vrijednost u stupcu 'dob' veća od 30
filtered = filter_data(data, lambda row: int(row['dob']) > 30)

# Izvezi filtrirane podatke u novu CSV datoteku
export_csv(filtered, 'filtrirano.csv')
```

## Napomene

[!NOTE]
Ovaj modul ne podržava CSV datoteke s ugrađenim novim redovima unutar polja.

[!WARNING]
Pazite da CSV datoteke budu pravilno formatirane kako bi se izbjegle pogreške pri parsiranju.

## Često postavljana pitanja

**Kako mogu učitati CSV datoteku s URL-a?**

Koristite funkciju `load_csv` s URL-om kao argumentom.

**Je li moguće sortirati podatke?**

Da, koristite funkciju `sort_data` iz modula.

## Kontakt

Za dodatnu pomoć posjetite našu stranicu ili kontaktirajte podršku.
("code", _) => "codeAnalyzer",
_ => throw new ToolExecutionException($"Nema dostupnog alata za {contentType}/{operation}")
};
}

private object GetOptionsForTool(string toolName, string operation)
{
// Vraća odgovarajuće opcije za svaki specijalizirani alat
return toolName switch
{
    "textSummarizer" => new { length = "medium" },
    "htmlProcessor" => new { cleanUp = true, operation },
    // Opcije za ostale alate...
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
        // Korak 1: Dohvati metapodatke skupa podataka (sinhrono)
        ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata", 
            Map.of("datasetId", datasetId));
        
        // Korak 2: Pokreni više analiza paralelno
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
        
        // Pričekaj da se svi paralelni zadaci završe
        CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
            statisticalAnalysis, correlationAnalysis, outlierDetection
        );
        
        allAnalyses.join();  // Čekaj završetak
        
        // Korak 3: Kombiniraj rezultate
        Map<String, Object> combinedResults = new HashMap<>();
        combinedResults.put("metadata", metadataResponse.getResult());
        combinedResults.put("statistics", statisticalAnalysis.join().getResult());
        combinedResults.put("correlations", correlationAnalysis.join().getResult());
        combinedResults.put("outliers", outlierDetection.join().getResult());
        
        // Korak 4: Generiraj sažetak izvještaja
        ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator", 
            Map.of("analysisResults", combinedResults));
        
        // Vrati kompletan rezultat tijeka rada
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
            # Prvo pokušaj s primarnim alatom
            response = await self.client.execute_tool(primary_tool, parameters)
            return {
                "result": response.result,
                "source": "primary",
                "tool": primary_tool
            }
        except ToolExecutionException as e:
            # Zabilježi neuspjeh
            logging.warning(f"Primarni alat '{primary_tool}' nije uspio: {str(e)}")
            
            # Prebaci se na sekundarni alat
            try:
                # Možda je potrebno prilagoditi parametre za sekundarni alat
                fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)
                
                response = await self.client.execute_tool(fallback_tool, fallback_params)
                return {
                    "result": response.result,
                    "source": "fallback",
                    "tool": fallback_tool,
                    "primaryError": str(e)
                }
            except ToolExecutionException as fallback_error:
                # Oba alata su neuspjela
                logging.error(f"Oba alata, primarni i sekundarni, nisu uspjela. Greška sekundarnog alata: {str(fallback_error)}")
                raise WorkflowExecutionException(
                    f"Tijek rada nije uspio: primarna greška: {str(e)}; sekundarna greška: {str(fallback_error)}"
                )
    
    def _adapt_parameters(self, params, from_tool, to_tool):
        """Prilagodi parametre između različitih alata ako je potrebno"""
        # Ova implementacija ovisi o specifičnim alatima
        # Za ovaj primjer, samo vraćamo originalne parametre
        return params

# Primjer korištenja
async def get_weather(workflow, location):
    return await workflow.execute_with_fallback(
        "premiumWeatherService",  # Primarni (plaćeni) vremenski API
        "basicWeatherService",    # Sekundarni (besplatni) vremenski API
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
            
            // Spremi rezultat svakog tijeka rada
            results[workflow.Name] = workflowResult;
            
            // Ažuriraj kontekst s rezultatom za sljedeći tijek rada
            context = context.WithResult(workflow.Name, workflowResult);
        }
        
        return new WorkflowResult(results);
    }
    
    public string Name => "CompositeWorkflow";
    public string Description => "Izvršava više tijekova rada jedan za drugim";
}

// Primjer korištenja
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
// Primjer jedinicnog testa za alat kalkulatora u C#
[Fact]
public async Task CalculatorTool_Add_ReturnsCorrectSum()
{
    // Priprema
    var calculator = new CalculatorTool();
    var parameters = new Dictionary<string, object>
    {
        ["operation"] = "add",
        ["a"] = 5,
        ["b"] = 7
    };
    
    // Izvršenje
    var response = await calculator.ExecuteAsync(parameters);
    var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());
    
    // Provjera
    Assert.Equal(12, result.Value);
}
```

```python
# Primjer jedinicnog testa za alat kalkulatora u Pythonu
def test_calculator_tool_add():
    # Priprema
    calculator = CalculatorTool()
    parameters = {
        "operation": "add",
        "a": 5,
        "b": 7
    }
    
    # Izvršenje
    response = calculator.execute(parameters)
    result = json.loads(response.content[0].text)
    
    # Provjera
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
// Primjer integracijskog testa za MCP server u C#
[Fact]
public async Task Server_ProcessToolRequest_ReturnsValidResponse()
{
    // Priprema
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
    
    // Izvršenje
    var response = await server.ProcessRequestAsync(request);
    
    // Provjera
    Assert.NotNull(response);
    Assert.Equal(McpStatusCodes.Success, response.StatusCode);
    // Dodatne provjere sadržaja odgovora
    
    // Čišćenje
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
// Primjer E2E testa s klijentom u TypeScriptu
describe('MCP Server E2E Tests', () => {
  let client: McpClient;
  
  beforeAll(async () => {
    // Pokreni server u testnom okruženju
    await startTestServer();
    client = new McpClient('http://localhost:5000');
  });
  
  afterAll(async () => {
    await stopTestServer();
  });
  
  test('Klijent može pozvati alat kalkulatora i dobiti točan rezultat', async () => {
    // Izvršenje
    const response = await client.invokeToolAsync('calculator', {
      operation: 'divide',
      a: 20,
      b: 4
    });
    
    // Provjera
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
// C# primjer s Moq
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
# Python primjer s unittest.mock
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
    # Konfiguriraj mock
    mock_model.return_value.generate_response.return_value = {
        "text": "Mocked model response",
        "finish_reason": "completed"
    }
    
    # Koristi mock u testu
    server = McpServer(model_client=mock_model)
    # Nastavi s testom
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
// k6 skripta za load testiranje MCP servera
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  vus: 10,  // 10 virtualnih korisnika
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
    'vrijeme odgovora < 500ms': (r) => r.timings.duration < 500,
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
    
    - name: Postavi Runtime
      uses: actions/setup-dotnet@v1
      with:
        dotnet-version: '8.0.x'
    
    - name: Vrati ovisnosti
      run: dotnet restore
    
    - name: Izgradi
      run: dotnet build --no-restore
    
    - name: Jedinični testovi
      run: dotnet test --no-build --filter Category=Unit
    
    - name: Integracijski testovi
      run: dotnet test --no-build --filter Category=Integration
      
    - name: Testovi performansi
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
    // Priprema
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");
    
    // Izvršenje
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
    // Dodatna provjera sheme
});
}

## Top 10 savjeta za učinkovito testiranje MCP servera

1. **Testirajte definicije alata zasebno**: Provjerite definicije shema neovisno o logici alata  
2. **Koristite parametarske testove**: Testirajte alate s različitim ulazima, uključujući rubne slučajeve  
3. **Provjerite odgovore na pogreške**: Osigurajte pravilno rukovanje svim mogućim pogreškama  
4. **Testirajte logiku autorizacije**: Provjerite ispravnu kontrolu pristupa za različite korisničke uloge  
5. **Pratite pokrivenost testovima**: Ciljajte na visoku pokrivenost kritičnog koda  
6. **Testirajte streaming odgovore**: Provjerite ispravno rukovanje streaming sadržajem  
7. **Simulirajte mrežne probleme**: Testirajte ponašanje u uvjetima loše mreže  
8. **Testirajte ograničenja resursa**: Provjerite ponašanje pri dosezanju kvota ili ograničenja brzine  
9. **Automatizirajte regresijske testove**: Izgradite skup testova koji se pokreću pri svakoj promjeni koda  
10. **Dokumentirajte testne slučajeve**: Održavajte jasnu dokumentaciju testnih scenarija  

## Uobičajene zamke u testiranju

- **Prevelika oslanjanja na testiranje samo "sretnog puta"**: Obavezno temeljito testirajte i slučajeve pogrešaka  
- **Ignoriranje testiranja performansi**: Otkrivajte uska grla prije nego što utječu na produkciju  
- **Testiranje samo u izolaciji**: Kombinirajte jedinicne, integracijske i end-to-end testove  
- **Nepotpuna pokrivenost API-ja**: Osigurajte da su svi endpointi i funkcionalnosti testirani  
- **Nekonzistentna testna okruženja**: Koristite kontejnere za dosljedna testna okruženja  

## Zaključak

Sveobuhvatna strategija testiranja ključna je za razvoj pouzdanih i kvalitetnih MCP servera. Primjenom najboljih praksi i savjeta iz ovog vodiča osigurat ćete da vaše MCP implementacije zadovoljavaju najviše standarde kvalitete, pouzdanosti i performansi.

## Ključne spoznaje

1. **Dizajn alata**: Slijedite princip jedne odgovornosti, koristite dependency injection i dizajnirajte za kompozabilnost  
2. **Dizajn sheme**: Kreirajte jasne, dobro dokumentirane sheme s odgovarajućim validacijskim ograničenjima  
3. **Rukovanje pogreškama**: Implementirajte elegantno rukovanje pogreškama, strukturirane odgovore i logiku ponovnog pokušaja  
4. **Performanse**: Koristite keširanje, asinkrono procesiranje i ograničavanje resursa  
5. **Sigurnost**: Primijenite temeljitu validaciju unosa, provjere autorizacije i rukovanje osjetljivim podacima  
6. **Testiranje**: Kreirajte sveobuhvatne jedinicne, integracijske i end-to-end testove  
7. **Radni obrasci**: Primijenite etablirane obrasce poput lanaca, dispatcher-a i paralelnog procesiranja  

## Vježba

Dizajnirajte MCP alat i radni tijek za sustav obrade dokumenata koji:

1. Prima dokumente u više formata (PDF, DOCX, TXT)  
2. Izvlači tekst i ključne informacije iz dokumenata  
3. Klasificira dokumente prema tipu i sadržaju  
4. Generira sažetak za svaki dokument  

Implementirajte sheme alata, rukovanje pogreškama i radni obrazac koji najbolje odgovara ovom scenariju. Razmislite kako biste testirali ovu implementaciju.

## Resursi

1. Pridružite se MCP zajednici na [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs) kako biste bili u tijeku s najnovijim događanjima  
2. Doprinesite open-source [MCP projektima](https://github.com/modelcontextprotocol)  
3. Primijenite MCP principe u AI inicijativama vaše organizacije  
4. Istražite specijalizirane MCP implementacije za vašu industriju  
5. Razmislite o naprednim tečajevima na specifične MCP teme, poput multi-modalne integracije ili integracije enterprise aplikacija  
6. Eksperimentirajte s izradom vlastitih MCP alata i radnih tijekova koristeći principe naučene kroz [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)  

Sljedeće: Najbolje prakse [studije slučaja](../09-CaseStudy/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.