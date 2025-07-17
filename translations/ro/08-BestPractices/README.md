<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "80e5c8949af5af0f401fce6f905990aa",
  "translation_date": "2025-07-17T11:10:49+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "ro"
}
-->
# Cele mai bune practici pentru dezvoltarea MCP

## Prezentare generală

Această lecție se concentrează pe cele mai avansate practici pentru dezvoltarea, testarea și implementarea serverelor și funcționalităților MCP în medii de producție. Pe măsură ce ecosistemele MCP devin tot mai complexe și importante, respectarea unor modele bine stabilite asigură fiabilitate, ușurință în întreținere și interoperabilitate. Lecția reunește experiența practică acumulată din implementări reale MCP pentru a te ghida în crearea unor servere robuste și eficiente, cu resurse, prompturi și unelte bine concepute.

## Obiective de învățare

La finalul acestei lecții vei putea:
- Aplica cele mai bune practici din industrie în proiectarea serverelor și funcționalităților MCP
- Elabora strategii complete de testare pentru serverele MCP
- Concepe modele eficiente și reutilizabile de workflow pentru aplicații MCP complexe
- Implementa gestionarea corectă a erorilor, logarea și observabilitatea în serverele MCP
- Optimiza implementările MCP pentru performanță, securitate și ușurință în întreținere

## Principiile de bază MCP

Înainte de a intra în detalii despre practici specifice de implementare, este important să înțelegi principiile fundamentale care ghidează dezvoltarea eficientă MCP:

1. **Comunicare standardizată**: MCP folosește JSON-RPC 2.0 ca bază, oferind un format consecvent pentru cereri, răspunsuri și gestionarea erorilor în toate implementările.

2. **Design centrat pe utilizator**: Prioritizează întotdeauna consimțământul, controlul și transparența pentru utilizatori în implementările MCP.

3. **Securitate pe primul loc**: Aplică măsuri robuste de securitate, inclusiv autentificare, autorizare, validare și limitare a ratei.

4. **Arhitectură modulară**: Proiectează serverele MCP cu o abordare modulară, unde fiecare unealtă și resursă are un scop clar și bine definit.

5. **Conexiuni cu stare**: Folosește capacitatea MCP de a menține starea pe parcursul mai multor cereri pentru interacțiuni mai coerente și conștiente de context.

## Cele mai bune practici oficiale MCP

Următoarele bune practici sunt extrase din documentația oficială a Model Context Protocol:

### Cele mai bune practici de securitate

1. **Consimțământul și controlul utilizatorului**: Solicită întotdeauna consimțământ explicit înainte de a accesa date sau de a efectua operațiuni. Oferă control clar asupra datelor partajate și acțiunilor autorizate.

2. **Confidențialitatea datelor**: Expune datele utilizatorului doar cu consimțământ explicit și protejează-le cu controale adecvate de acces. Previne transmiterea neautorizată a datelor.

3. **Siguranța uneltelor**: Solicită consimțământ explicit înainte de a apela orice unealtă. Asigură-te că utilizatorii înțeleg funcționalitatea fiecărei unelte și aplică limite de securitate stricte.

4. **Controlul permisiunilor uneltelor**: Configurează ce unelte poate folosi un model în timpul unei sesiuni, asigurând acces doar la cele autorizate explicit.

5. **Autentificare**: Cere autentificare corectă înainte de a acorda acces la unelte, resurse sau operațiuni sensibile, folosind chei API, token-uri OAuth sau alte metode sigure.

6. **Validarea parametrilor**: Aplică validarea pentru toate invocările uneltelor pentru a preveni intrări incorecte sau malițioase.

7. **Limitarea ratei**: Implementează limitarea ratei pentru a preveni abuzul și a asigura utilizarea echitabilă a resurselor serverului.

### Cele mai bune practici de implementare

1. **Negocierea capabilităților**: La stabilirea conexiunii, schimbă informații despre funcționalitățile suportate, versiunile protocolului, uneltele și resursele disponibile.

2. **Proiectarea uneltelor**: Creează unelte specializate care să facă bine un singur lucru, în loc de unelte monolitice care gestionează mai multe aspecte.

3. **Gestionarea erorilor**: Implementează mesaje și coduri de eroare standardizate pentru a ajuta la diagnosticarea problemelor, a gestiona eșecurile elegant și a oferi feedback util.

4. **Logare**: Configurează loguri structurate pentru audit, depanare și monitorizarea interacțiunilor protocolului.

5. **Urmărirea progresului**: Pentru operațiuni de durată, raportează actualizări de progres pentru a permite interfețe responsive.

6. **Anularea cererilor**: Permite clienților să anuleze cererile în curs care nu mai sunt necesare sau durează prea mult.

## Referințe suplimentare

Pentru cele mai recente informații despre cele mai bune practici MCP, consultă:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)
- [Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## Exemple practice de implementare

### Cele mai bune practici pentru proiectarea uneltelor

#### 1. Principiul responsabilității unice

Fiecare unealtă MCP ar trebui să aibă un scop clar și bine definit. În loc să creezi unelte monolitice care încearcă să gestioneze mai multe aspecte, dezvoltă unelte specializate care excelează în sarcini specifice.

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

#### 2. Gestionarea consecventă a erorilor

Implementează o gestionare robustă a erorilor cu mesaje informative și mecanisme adecvate de recuperare.

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

#### 3. Validarea parametrilor

Validează întotdeauna parametrii temeinic pentru a preveni intrări incorecte sau malițioase.

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

### Exemple de implementare a securității

#### 1. Autentificare și autorizare

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

#### 2. Limitarea ratei

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

## Cele mai bune practici pentru testare

### 1. Testarea unitară a uneltelor MCP

Testează întotdeauna uneltele izolat, simulând dependențele externe:

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

### 2. Testarea integrată

Testează fluxul complet de la cererile clientului până la răspunsurile serverului:

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

## Optimizarea performanței

### 1. Strategii de caching

Implementează caching adecvat pentru a reduce latența și consumul de resurse:

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
// Exemplu Java cu injecție de dependențe
public class CurrencyConversionTool implements Tool {
    private final ExchangeRateService exchangeService;
    private final CacheService cacheService;
    private final Logger logger;
    
    // Dependențe injectate prin constructor
    public CurrencyConversionTool(
            ExchangeRateService exchangeService,
            CacheService cacheService,
            Logger logger) {
        this.exchangeService = exchangeService;
        this.cacheService = cacheService;
        this.logger = logger;
    }
    
    // Implementarea uneltei
    // ...
}
```

#### 3. Composable Tools

Design tools that can be composed together to create more complex workflows:

```python
# Exemplu Python care arată unelte compozabile
class DataFetchTool(Tool):
    def get_name(self):
        return "dataFetch"
    
    # Implementare...

class DataAnalysisTool(Tool):
    def get_name(self):
        return "dataAnalysis"
    
    # Această unealtă poate folosi rezultatele uneltei dataFetch
    async def execute_async(self, request):
        # Implementare...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # Această unealtă poate folosi rezultatele uneltei dataAnalysis
    async def execute_async(self, request):
        # Implementare...
        pass

# Aceste unelte pot fi folosite independent sau ca parte a unui workflow
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
                description = "Textul interogării de căutare. Folosește cuvinte cheie precise pentru rezultate mai bune." 
            },
            filters = new {
                type = "object",
                description = "Filtre opționale pentru a restrânge rezultatele căutării",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "Intervalul de date în format YYYY-MM-DD:YYYY-MM-DD" 
                    },
                    category = new { 
                        type = "string", 
                        description = "Numele categoriei după care se filtrează" 
                    }
                }
            },
            limit = new { 
                type = "integer", 
                description = "Numărul maxim de rezultate returnate (1-50)",
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
    
    // Proprietatea email cu validare de format
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "Adresa de email a utilizatorului");
    
    // Proprietatea vârstă cu constrângeri numerice
    Map<String, Object> age = new HashMap<>();
    age.put("type", "integer");
    age.put("minimum", 13);
    age.put("maximum", 120);
    age.put("description", "Vârsta utilizatorului în ani");
    
    // Proprietate enumerată
    Map<String, Object> subscription = new HashMap<>();
    subscription.put("type", "string");
    subscription.put("enum", Arrays.asList("free", "basic", "premium"));
    subscription.put("default", "free");
    subscription.put("description", "Nivelul abonamentului");
    
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
        # Procesează cererea
        results = await self._search_database(request.parameters["query"])
        
        # Returnează întotdeauna o structură consistentă
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
    """Asigură o structură consistentă pentru fiecare element"""
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
            throw new ToolExecutionException($"Fișierul nu a fost găsit: {fileId}");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ToolExecutionException("Nu ai permisiunea de a accesa acest fișier");
        }
        catch (Exception ex) when (ex is IOException || ex is TimeoutException)
        {
            _logger.LogError(ex, "Eroare la accesarea fișierului {FileId}", fileId);
            throw new ToolExecutionException("Eroare la accesarea fișierului: Serviciul este temporar indisponibil");
        }
    }
    catch (JsonException)
    {
        throw new ToolExecutionException("Format invalid pentru ID-ul fișierului");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Eroare neașteptată în FileAccessTool");
        throw new ToolExecutionException("A apărut o eroare neașteptată");
    }
}
```

#### 2. Structured Error Responses

Return structured error information when possible:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    try {
        // Implementare
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
        
        // Re-aruncă alte excepții ca ToolExecutionException
        throw new ToolExecutionException("Executarea uneltei a eșuat: " + ex.getMessage(), ex);
    }
}
```

#### 3. Retry Logic

Implement appropriate retry logic for transient failures:

```python
async def execute_async(self, request):
    max_retries = 3
    retry_count = 0
    base_delay = 1  # secunde
    
    while retry_count < max_retries:
        try:
            # Apelează API-ul extern
            return await self._call_api(request.parameters)
        except TransientError as e:
            retry_count += 1
            if retry_count >= max_retries:
                raise ToolExecutionException(f"Operațiunea a eșuat după {max_retries} încercări: {str(e)}")
                
            # Backoff exponențial
            delay = base_delay * (2 ** (retry_count - 1))
            logging.warning(f"Eroare tranzitorie, se reîncearcă în {delay}s: {str(e)}")
            await asyncio.sleep(delay)
        except Exception as e:
            # Eroare non-tranzitorie, nu se reîncearcă
            raise ToolExecutionException(f"Operațiunea a eșuat: {str(e)}")
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
    
    // Creează cheia cache-ului bazată pe parametri
    var cacheKey = $"data_query_{ComputeHash(query)}";
    
    // Încearcă să obții rezultatul din cache mai întâi
    if (_cache.TryGetValue(cacheKey, out var cachedResult))
    {
        return new ToolResponse { Result = cachedResult };
    }
    
    // Cache miss - execută interogarea efectivă
    var result = await _database.QueryAsync(query);
    
    // Stochează în cache cu expirare
    var cacheOptions = new MemoryCacheEntryOptions()
        .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
        
    _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
    
    return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
}

private string ComputeHash(string input)
{
    // Implementare pentru generarea unui hash stabil pentru cheia cache-ului
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
        
        // Pentru operațiuni de durată lungă, returnează imediat un ID de procesare
        String processId = UUID.randomUUID().toString();
        
        // Pornește procesarea asincronă
        CompletableFuture.runAsync(() -> {
            try {
                // Execută operațiunea de durată lungă
                documentService.processDocument(documentId);
                
                // Actualizează statusul (de obicei stocat într-o bază de date)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // Returnează răspuns imediat cu ID-ul procesului
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // Unealtă companion pentru verificarea statusului
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
            tokens_per_second=5,  # Permite 5 cereri pe secundă
            bucket_size=10        # Permite explozii de până la 10 cereri
        )
    
    async def execute_async(self, request):
        # Verifică dacă putem continua sau trebuie să așteptăm
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # Dacă așteptarea este prea lungă
                raise ToolExecutionException(
                    f"Limita de rată a fost depășită. Te rugăm să încerci din nou în {delay:.1f} secunde."
                )
            else:
                # Așteaptă timpul corespunzător
                await asyncio.sleep(delay)
        
        # Consumă un token și continuă cu cererea
        self.rate_limiter.consume()
        
        # Apelează API-ul
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
            
            # Calculează timpul până când va fi disponibil următorul token
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # Adaugă token-uri noi în funcție de timpul trecut
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
    // Verifică dacă parametrii există
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("Lipsește parametrul obligatoriu: query");
    }
    
    // Verifică tipul corect
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("Parametrul query trebuie să fie un șir de caractere");
    }
    
    var query = queryProp.GetString();
    
    // Verifică conținutul șirului
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("Parametrul query nu poate fi gol");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("Parametrul query depășește lungimea maximă de 500 de caractere");
    }
    
    // Verifică atacuri de tip SQL injection, dacă este cazul
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("Interogare invalidă: conține SQL potențial nesigur");
    }
    
    // Continuă cu execuția
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // Obține contextul utilizatorului din cerere
    UserContext user = request.getContext().getUserContext();
    
    // Verifică dacă utilizatorul are permisiunile necesare
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("Utilizatorul nu are permisiunea de a accesa documentele");
    }
    
    // Pentru resurse specifice, verifică accesul la acea resursă
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("Acces refuzat la documentul solicitat");
    }
    
    // Continuă cu execuția uneltei
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
        
        # Obține datele utilizatorului
        user_data = await self.user_service.get_user_data(user_id)
        
        # Filtrează câmpurile sensibile dacă nu sunt cerute explicit ȘI autorizat
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # Verifică nivelul de autorizare din contextul cererii
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # Creează o copie pentru a nu modifica originalul
        redacted = user_data.copy()
        
        # Redactează câmpurile sensibile specifice
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # Redactează datele sensibile imbricate
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
    // Aranjează
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("Seattle", 3))
        .ReturnsAsync(new WeatherForecast(/* date de test */));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "Seattle", 
            days = 3 
        })
    );
    
    // Acționează
    var response = await tool.ExecuteAsync(request);
    
    // Verifică
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // Aranjează
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("InvalidLocation", It.IsAny<int>()))
        .ThrowsAsync(new LocationNotFoundException("Locația nu a fost găsită"));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "InvalidLocation", 
            days = 3 
        })
    );
    
    // Acționează & Verifică
    var exception = await Assert.ThrowsAsync<ToolExecutionException>(
        () => tool.ExecuteAsync(request)
    );
    
    Assert.Contains("Locația nu a fost găsită", exception.Message);
}
```

#### 2. Schema Validation Testing

Test that schemas are valid and properly enforce constraints:

```java
@Test
public void testSchemaValidation() {
    // Creează o instanță a uneltei
    SearchTool searchTool = new SearchTool();
    
    // Obține schema
    Object schema = searchTool.getSchema();
    
    // Convertește schema în JSON pentru validare
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // Validează că schema este un JSONSchema valid
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // Testează parametri valizi
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // Testează lipsa parametrului obligatoriu
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // Testează tipul invalid al parametrului
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
    # Aranjează
    tool = ApiTool(timeout=0.1)  # Timeout foarte scurt
    
    # Simulează o cerere care va expira
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # Mai lung decât timeout-ul
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # Acționează & Verifică
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Verifică mesajul excepției
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # Aranjează
    tool = ApiTool()
    
    # Simulează un răspuns cu limitare de rată
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
        
        # Acționează & Verifică
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Verifică că excepția conține informații despre limitarea ratei
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
    // Aranjează
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // Acționează
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
        // Testează endpoint-ul de descoperire
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // Creează cererea pentru tool
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // Trimite cererea și verifică răspunsul
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // Creează o cerere invalidă pentru tool
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // Lipsă parametrul "b"
        request.put("parameters", parameters);
        
        // Trimite cererea și verifică răspunsul de eroare
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
    # Aranjează - Configurează clientul MCP și modelul mock
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # Răspunsuri mock pentru model
    mock_model = MockLanguageModel([
        MockResponse(
            "Care este vremea în Seattle?",
            tool_calls=[{
                "tool_name": "weatherForecast",
                "parameters": {"location": "Seattle", "days": 3}
            }]
        ),
        MockResponse(
            "Iată prognoza meteo pentru Seattle:\n- Azi: 65°F, Parțial înnorat\n- Mâine: 68°F, Senin\n- Peste două zile: 62°F, Ploaie",
            tool_calls=[]
        )
    ])
    
    # Răspuns mock pentru tool-ul meteo
    with aioresponses() as mocked:
        mocked.post(
            "http://localhost:5000/mcp/execute",
            payload={
                "result": {
                    "location": "Seattle",
                    "forecast": [
                        {"date": "2023-06-01", "temperature": 65, "conditions": "Parțial înnorat"},
                        {"date": "2023-06-02", "temperature": 68, "conditions": "Senin"},
                        {"date": "2023-06-03", "temperature": 62, "conditions": "Ploaie"}
                    ]
                }
            }
        )
        
        # Acționează
        response = await mcp_client.send_prompt(
            "Care este vremea în Seattle?",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # Verifică
        assert "Seattle" in response.generated_text
        assert "65" in response.generated_text
        assert "Senin" in response.generated_text
        assert "Ploaie" in response.generated_text
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
    // Aranjează
    var server = new McpServer(
        name: "TestServer",
        version: "1.0",
        maxConcurrentRequests: 100
    );
    
    server.RegisterTool(new FastExecutingTool());
    await server.StartAsync();
    
    var client = new McpClient("http://localhost:5000");
    
    // Acționează
    var tasks = new List<Task<McpResponse>>();
    for (int i = 0; i < 1000; i++)
    {
        tasks.Add(client.ExecuteToolAsync("fastTool", new { iteration = i }));
    }
    
    var results = await Task.WhenAll(tasks);
    
    // Verifică
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
    
    // Configurează JMeter pentru testare de stres
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // Configurează planul de test JMeter
    HashTree testPlanTree = new HashTree();
    
    // Creează planul de test, grupul de thread-uri, sampler-ele etc.
    TestPlan testPlan = new TestPlan("Test de stres MCP Server");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // Adaugă HTTP sampler pentru execuția tool-ului
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // Adaugă ascultători
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // Rulează testul
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // Validează rezultatele
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // Timp mediu de răspuns < 200ms
    assertTrue(summaryReport.getPercentile(90.0) < 500); // Percentila 90 < 500ms
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# Configurează monitorizarea pentru un server MCP
def configure_monitoring(server):
    # Configurează metricile Prometheus
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "Numărul total de cereri MCP"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "Durata cererii în secunde",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "Numărul de execuții ale tool-urilor",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "Durata execuției tool-ului în secunde",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "Erori la execuția tool-ului",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # Adaugă middleware pentru măsurarea timpului și înregistrarea metricilor
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # Expune endpoint-ul pentru metrici
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
# Implementarea lanțului de tool-uri în Python
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # Listă de nume de tool-uri care se execută în secvență
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # Execută fiecare tool din lanț, trecând rezultatul anterior
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # Stochează rezultatul și îl folosește ca input pentru următorul tool
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# Exemplu de utilizare
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
    public string Description => "Procesează conținut de diferite tipuri";
    
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
        
        // Determină care tool specializat să folosească
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // Redirecționează către tool-ul specializat
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
# Procesator CSV

Acest ghid explică cum să folosești `csvProcessor` pentru a manipula fișiere CSV în mod eficient.

## Funcționalități principale

- Citirea fișierelor CSV cu diferite delimitatoare
- Filtrarea și sortarea datelor
- Exportul datelor procesate în formate multiple

## Exemplu de utilizare

```python
# Importă modulul csvProcessor
from csvProcessor import CSVReader

# Creează un obiect CSVReader
reader = CSVReader('date.csv', delimiter=',')

# Citește toate rândurile
rows = reader.read_all()

# Filtrează rândurile unde coloana 'vârstă' este mai mare de 30
filtered_rows = [row for row in rows if int(row['vârstă']) > 30]

# Sortează rândurile după coloana 'nume'
sorted_rows = sorted(filtered_rows, key=lambda x: x['nume'])

# Exportă rezultatul într-un nou fișier CSV
reader.write('date_filtrate.csv', sorted_rows)
```

## Sfaturi utile

[!TIP] Folosește parametrul `delimiter` pentru a specifica caracterul care separă valorile în fișierul CSV.

[!IMPORTANT] Asigură-te că toate fișierele CSV au același format pentru a evita erorile la citire.

## Probleme comune

- [!WARNING] Dacă întâmpini erori legate de codificare, verifică dacă fișierul CSV este salvat în UTF-8.
- [!CAUTION] Nu modifica manual fișierele CSV în timp ce sunt procesate pentru a preveni coruperea datelor.

Pentru mai multe detalii, consultă documentația oficială sau contactează echipa de suport.
            ("code", _) => "codeAnalyzer",
            _ => throw new ToolExecutionException($"Nu există un instrument disponibil pentru {contentType}/{operation}")
        };
    }
    
    private object GetOptionsForTool(string toolName, string operation)
    {
        // Returnează opțiunile potrivite pentru fiecare instrument specializat
        return toolName switch
        {
            "textSummarizer" => new { length = "medium" },
            "htmlProcessor" => new { cleanUp = true, operation },
            // Opțiuni pentru alte instrumente...
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
        // Pasul 1: Preia metadatele setului de date (sincron)
        ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata", 
            Map.of("datasetId", datasetId));
        
        // Pasul 2: Lansează mai multe analize în paralel
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
        
        // Așteaptă finalizarea tuturor sarcinilor paralele
        CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
            statisticalAnalysis, correlationAnalysis, outlierDetection
        );
        
        allAnalyses.join();  // Așteaptă finalizarea
        
        // Pasul 3: Combină rezultatele
        Map<String, Object> combinedResults = new HashMap<>();
        combinedResults.put("metadata", metadataResponse.getResult());
        combinedResults.put("statistics", statisticalAnalysis.join().getResult());
        combinedResults.put("correlations", correlationAnalysis.join().getResult());
        combinedResults.put("outliers", outlierDetection.join().getResult());
        
        // Pasul 4: Generează raportul sumar
        ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator", 
            Map.of("analysisResults", combinedResults));
        
        // Returnează rezultatul complet al fluxului de lucru
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
            # Încearcă mai întâi instrumentul principal
            response = await self.client.execute_tool(primary_tool, parameters)
            return {
                "result": response.result,
                "source": "primary",
                "tool": primary_tool
            }
        except ToolExecutionException as e:
            # Înregistrează eșecul
            logging.warning(f"Instrumentul principal '{primary_tool}' a eșuat: {str(e)}")
            
            # Revine la instrumentul secundar
            try:
                # Poate fi necesară transformarea parametrilor pentru instrumentul de rezervă
                fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)
                
                response = await self.client.execute_tool(fallback_tool, fallback_params)
                return {
                    "result": response.result,
                    "source": "fallback",
                    "tool": fallback_tool,
                    "primaryError": str(e)
                }
            except ToolExecutionException as fallback_error:
                # Ambele instrumente au eșuat
                logging.error(f"Atât instrumentul principal, cât și cel de rezervă au eșuat. Eroare fallback: {str(fallback_error)}")
                raise WorkflowExecutionException(
                    f"Fluxul de lucru a eșuat: eroare principală: {str(e)}; eroare fallback: {str(fallback_error)}"
                )
    
    def _adapt_parameters(self, params, from_tool, to_tool):
        """Adaptează parametrii între diferite instrumente dacă este necesar"""
        # Această implementare depinde de instrumentele specifice
        # Pentru acest exemplu, vom returna pur și simplu parametrii originali
        return params

# Exemplu de utilizare
async def get_weather(workflow, location):
    return await workflow.execute_with_fallback(
        "premiumWeatherService",  # API meteo principal (plătit)
        "basicWeatherService",    # API meteo de rezervă (gratuit)
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
            
            // Stochează rezultatul fiecărui flux de lucru
            results[workflow.Name] = workflowResult;
            
            // Actualizează contextul cu rezultatul pentru următorul flux de lucru
            context = context.WithResult(workflow.Name, workflowResult);
        }
        
        return new WorkflowResult(results);
    }
    
    public string Name => "CompositeWorkflow";
    public string Description => "Execută mai multe fluxuri de lucru în secvență";
}

// Exemplu de utilizare
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
// Exemplu de test unitar pentru un instrument calculator în C#
[Fact]
public async Task CalculatorTool_Add_ReturnsCorrectSum()
{
    // Aranjare
    var calculator = new CalculatorTool();
    var parameters = new Dictionary<string, object>
    {
        ["operation"] = "add",
        ["a"] = 5,
        ["b"] = 7
    };
    
    // Acțiune
    var response = await calculator.ExecuteAsync(parameters);
    var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());
    
    // Verificare
    Assert.Equal(12, result.Value);
}
```

```python
# Exemplu de test unitar pentru un instrument calculator în Python
def test_calculator_tool_add():
    # Aranjare
    calculator = CalculatorTool()
    parameters = {
        "operation": "add",
        "a": 5,
        "b": 7
    }
    
    # Acțiune
    response = calculator.execute(parameters)
    result = json.loads(response.content[0].text)
    
    # Verificare
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
// Exemplu de test de integrare pentru serverul MCP în C#
[Fact]
public async Task Server_ProcessToolRequest_ReturnsValidResponse()
{
    // Aranjare
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
    
    // Acțiune
    var response = await server.ProcessRequestAsync(request);
    
    // Verificare
    Assert.NotNull(response);
    Assert.Equal(McpStatusCodes.Success, response.StatusCode);
    // Verificări suplimentare pentru conținutul răspunsului
    
    // Curățare
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
// Exemplu de test E2E cu un client în TypeScript
describe('Teste E2E pentru MCP Server', () => {
  let client: McpClient;
  
  beforeAll(async () => {
    // Pornește serverul în mediul de testare
    await startTestServer();
    client = new McpClient('http://localhost:5000');
  });
  
  afterAll(async () => {
    await stopTestServer();
  });
  
  test('Clientul poate apela instrumentul calculator și obține rezultatul corect', async () => {
    // Acțiune
    const response = await client.invokeToolAsync('calculator', {
      operation: 'divide',
      a: 20,
      b: 4
    });
    
    // Verificare
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
// Exemplu C# cu Moq
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
# Exemplu Python cu unittest.mock
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
    # Configurează mock-ul
    mock_model.return_value.generate_response.return_value = {
        "text": "Mocked model response",
        "finish_reason": "completed"
    }
    
    # Folosește mock-ul în test
    server = McpServer(model_client=mock_model)
    # Continuă cu testul
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
// Script k6 pentru testarea încărcării serverului MCP
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  vus: 10,  // 10 utilizatori virtuali
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
    'status este 200': (r) => r.status === 200,
    'timpul de răspuns < 500ms': (r) => r.timings.duration < 500,
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
    // Aranjare
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");
    
    // Acțiune
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
    // Validare suplimentară a schemei
});
}
```

## Top 10 sfaturi pentru testarea eficientă a serverului MCP

1. **Testează definițiile uneltelor separat**: Verifică definițiile schemei independent de logica uneltei
2. **Folosește teste parametrizate**: Testează uneltele cu o varietate de intrări, inclusiv cazuri limită
3. **Verifică răspunsurile de eroare**: Asigură-te că gestionarea erorilor este corectă pentru toate condițiile posibile
4. **Testează logica de autorizare**: Confirmă controlul adecvat al accesului pentru diferite roluri de utilizatori
5. **Monitorizează acoperirea testelor**: Țintește o acoperire ridicată a codului din căile critice
6. **Testează răspunsurile în streaming**: Verifică gestionarea corectă a conținutului în streaming
7. **Simulează probleme de rețea**: Testează comportamentul în condiții de rețea deficitară
8. **Testează limitele resurselor**: Verifică comportamentul la atingerea cotelor sau limitelor de rată
9. **Automatizează testele de regresie**: Construiește o suită care să ruleze la fiecare modificare a codului
10. **Documentează cazurile de test**: Menține o documentație clară a scenariilor de testare

## Capcane comune în testare

- **Dependența excesivă de testarea căii fericite**: Asigură-te că testezi temeinic și cazurile de eroare
- **Ignorarea testării performanței**: Identifică blocajele înainte să afecteze producția
- **Testarea doar în izolare**: Combină teste unitare, de integrare și end-to-end
- **Acoperire incompletă a API-ului**: Asigură-te că toate endpoint-urile și funcționalitățile sunt testate
- **Mediile de testare inconsistente**: Folosește containere pentru a garanta medii de testare uniforme

## Concluzie

O strategie de testare cuprinzătoare este esențială pentru dezvoltarea unor servere MCP fiabile și de înaltă calitate. Implementând cele mai bune practici și sfaturi prezentate în acest ghid, poți asigura că implementările MCP respectă cele mai înalte standarde de calitate, fiabilitate și performanță.

## Aspecte cheie de reținut

1. **Designul uneltelor**: Urmează principiul responsabilității unice, folosește injecția de dependențe și proiectează pentru compozabilitate
2. **Designul schemei**: Creează scheme clare, bine documentate, cu constrângeri de validare adecvate
3. **Gestionarea erorilor**: Implementează o gestionare elegantă a erorilor, răspunsuri structurate și logică de retry
4. **Performanța**: Folosește caching, procesare asincronă și limitarea resurselor
5. **Securitatea**: Aplică validare riguroasă a intrărilor, verificări de autorizare și gestionarea datelor sensibile
6. **Testarea**: Creează teste unitare, de integrare și end-to-end cuprinzătoare
7. **Modele de workflow**: Aplică modele consacrate precum lanțuri, dispatcheri și procesare paralelă

## Exercițiu

Proiectează o unealtă MCP și un workflow pentru un sistem de procesare a documentelor care:

1. Acceptă documente în mai multe formate (PDF, DOCX, TXT)
2. Extrage text și informații cheie din documente
3. Clasifică documentele după tip și conținut
4. Generează un rezumat pentru fiecare document

Implementează schemele uneltei, gestionarea erorilor și un model de workflow care se potrivește cel mai bine acestui scenariu. Gândește-te cum ai testa această implementare.

## Resurse

1. Alătură-te comunității MCP pe [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs) pentru a fi la curent cu ultimele noutăți
2. Contribuie la proiectele open-source [MCP](https://github.com/modelcontextprotocol)
3. Aplică principiile MCP în inițiativele AI ale organizației tale
4. Explorează implementări MCP specializate pentru industria ta
5. Ia în considerare cursuri avansate pe subiecte MCP specifice, cum ar fi integrarea multi-modală sau integrarea aplicațiilor enterprise
6. Experimentează construind propriile unelte și workflow-uri MCP folosind principiile învățate prin [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

Următorul: Studii de caz cu cele mai bune practici [case studies](../09-CaseStudy/README.md)

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.