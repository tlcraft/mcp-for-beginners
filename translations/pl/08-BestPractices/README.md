<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "80e5c8949af5af0f401fce6f905990aa",
  "translation_date": "2025-07-16T22:33:57+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "pl"
}
-->
# Najlepsze praktyki rozwoju MCP

## Przegląd

Ta lekcja koncentruje się na zaawansowanych najlepszych praktykach dotyczących tworzenia, testowania i wdrażania serwerów MCP oraz funkcji w środowiskach produkcyjnych. W miarę jak ekosystemy MCP stają się coraz bardziej złożone i istotne, przestrzeganie ustalonych wzorców zapewnia niezawodność, łatwość utrzymania i interoperacyjność. Lekcja ta zbiera praktyczną wiedzę zdobytą na podstawie rzeczywistych implementacji MCP, aby pomóc Ci tworzyć solidne, wydajne serwery z efektywnymi zasobami, promptami i narzędziami.

## Cele nauki

Po ukończeniu tej lekcji będziesz potrafił:
- Stosować najlepsze praktyki branżowe w projektowaniu serwerów i funkcji MCP
- Tworzyć kompleksowe strategie testowania serwerów MCP
- Projektować efektywne, wielokrotnego użytku wzorce przepływów pracy dla złożonych aplikacji MCP
- Wdrażać właściwe obsługiwanie błędów, logowanie i monitorowanie w serwerach MCP
- Optymalizować implementacje MCP pod kątem wydajności, bezpieczeństwa i łatwości utrzymania

## Podstawowe zasady MCP

Zanim przejdziemy do konkretnych praktyk implementacyjnych, ważne jest zrozumienie podstawowych zasad, które kierują efektywnym rozwojem MCP:

1. **Standaryzowana komunikacja**: MCP opiera się na JSON-RPC 2.0, zapewniając spójny format dla żądań, odpowiedzi i obsługi błędów we wszystkich implementacjach.

2. **Projektowanie zorientowane na użytkownika**: Zawsze stawiaj na pierwszym miejscu zgodę, kontrolę i przejrzystość dla użytkownika w swoich implementacjach MCP.

3. **Bezpieczeństwo przede wszystkim**: Wdrażaj solidne środki bezpieczeństwa, w tym uwierzytelnianie, autoryzację, walidację i ograniczanie liczby żądań.

4. **Modułowa architektura**: Projektuj serwery MCP w sposób modułowy, gdzie każde narzędzie i zasób ma jasny, skoncentrowany cel.

5. **Połączenia stanowe**: Wykorzystuj zdolność MCP do utrzymywania stanu pomiędzy wieloma żądaniami, aby zapewnić spójne i świadome kontekstowo interakcje.

## Oficjalne najlepsze praktyki MCP

Poniższe najlepsze praktyki pochodzą z oficjalnej dokumentacji Model Context Protocol:

### Najlepsze praktyki bezpieczeństwa

1. **Zgoda i kontrola użytkownika**: Zawsze wymagaj wyraźnej zgody użytkownika przed dostępem do danych lub wykonywaniem operacji. Zapewnij jasną kontrolę nad tym, jakie dane są udostępniane i które działania są autoryzowane.

2. **Prywatność danych**: Udostępniaj dane użytkownika tylko za wyraźną zgodą i zabezpieczaj je odpowiednimi kontrolami dostępu. Chroń przed nieautoryzowanym przesyłaniem danych.

3. **Bezpieczeństwo narzędzi**: Wymagaj wyraźnej zgody użytkownika przed wywołaniem jakiegokolwiek narzędzia. Upewnij się, że użytkownicy rozumieją funkcjonalność każdego narzędzia i egzekwuj solidne granice bezpieczeństwa.

4. **Kontrola uprawnień narzędzi**: Konfiguruj, które narzędzia model może używać podczas sesji, zapewniając dostęp tylko do tych wyraźnie autoryzowanych.

5. **Uwierzytelnianie**: Wymagaj właściwego uwierzytelniania przed udzieleniem dostępu do narzędzi, zasobów lub operacji wrażliwych, korzystając z kluczy API, tokenów OAuth lub innych bezpiecznych metod uwierzytelniania.

6. **Walidacja parametrów**: Wymuszaj walidację wszystkich wywołań narzędzi, aby zapobiec przekazywaniu niepoprawnych lub złośliwych danych do implementacji narzędzi.

7. **Ograniczanie liczby żądań**: Wdrażaj ograniczenia liczby żądań, aby zapobiec nadużyciom i zapewnić sprawiedliwe wykorzystanie zasobów serwera.

### Najlepsze praktyki implementacyjne

1. **Negocjacja możliwości**: Podczas nawiązywania połączenia wymieniaj informacje o obsługiwanych funkcjach, wersjach protokołu, dostępnych narzędziach i zasobach.

2. **Projektowanie narzędzi**: Twórz skoncentrowane narzędzia, które dobrze wykonują jedno zadanie, zamiast monolitycznych narzędzi obsługujących wiele funkcji.

3. **Obsługa błędów**: Wdrażaj ustandaryzowane komunikaty i kody błędów, aby ułatwić diagnozowanie problemów, łagodne radzenie sobie z awariami i dostarczanie użytecznych informacji zwrotnych.

4. **Logowanie**: Konfiguruj strukturalne logi do audytu, debugowania i monitorowania interakcji protokołu.

5. **Śledzenie postępu**: W przypadku długotrwałych operacji raportuj aktualizacje postępu, aby umożliwić responsywne interfejsy użytkownika.

6. **Anulowanie żądań**: Pozwalaj klientom anulować żądania w trakcie realizacji, które nie są już potrzebne lub zajmują zbyt dużo czasu.

## Dodatkowe źródła

Aby uzyskać najnowsze informacje na temat najlepszych praktyk MCP, odwołaj się do:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)
- [Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## Praktyczne przykłady implementacji

### Najlepsze praktyki projektowania narzędzi

#### 1. Zasada pojedynczej odpowiedzialności

Każde narzędzie MCP powinno mieć jasny, skoncentrowany cel. Zamiast tworzyć monolityczne narzędzia, które próbują obsłużyć wiele funkcji, rozwijaj wyspecjalizowane narzędzia, które doskonale radzą sobie z konkretnymi zadaniami.

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

#### 2. Spójna obsługa błędów

Wdrażaj solidną obsługę błędów z informacyjnymi komunikatami i odpowiednimi mechanizmami odzyskiwania.

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

#### 3. Walidacja parametrów

Zawsze dokładnie waliduj parametry, aby zapobiec przekazywaniu niepoprawnych lub złośliwych danych.

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

### Przykłady implementacji bezpieczeństwa

#### 1. Uwierzytelnianie i autoryzacja

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

#### 2. Ograniczanie liczby żądań

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

## Najlepsze praktyki testowania

### 1. Testy jednostkowe narzędzi MCP

Zawsze testuj swoje narzędzia w izolacji, stosując mockowanie zależności zewnętrznych:

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

### 2. Testy integracyjne

Testuj pełny przepływ od żądań klienta do odpowiedzi serwera:

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

## Optymalizacja wydajności

### 1. Strategie buforowania

Wdrażaj odpowiednie buforowanie, aby zmniejszyć opóźnienia i zużycie zasobów:

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
// Przykład w Javie z wstrzykiwaniem zależności
public class CurrencyConversionTool implements Tool {
    private final ExchangeRateService exchangeService;
    private final CacheService cacheService;
    private final Logger logger;
    
    // Zależności wstrzykiwane przez konstruktor
    public CurrencyConversionTool(
            ExchangeRateService exchangeService,
            CacheService cacheService,
            Logger logger) {
        this.exchangeService = exchangeService;
        this.cacheService = cacheService;
        this.logger = logger;
    }
    
    // Implementacja narzędzia
    // ...
}
```

#### 3. Composable Tools

Design tools that can be composed together to create more complex workflows:

```python
# Przykład w Pythonie pokazujący kompozycję narzędzi
class DataFetchTool(Tool):
    def get_name(self):
        return "dataFetch"
    
    # Implementacja...

class DataAnalysisTool(Tool):
    def get_name(self):
        return "dataAnalysis"
    
    # To narzędzie może korzystać z wyników narzędzia dataFetch
    async def execute_async(self, request):
        # Implementacja...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # To narzędzie może korzystać z wyników narzędzia dataAnalysis
    async def execute_async(self, request):
        # Implementacja...
        pass

# Te narzędzia mogą być używane niezależnie lub jako część przepływu pracy
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
                description = "Tekst zapytania wyszukiwania. Używaj precyzyjnych słów kluczowych dla lepszych wyników." 
            },
            filters = new {
                type = "object",
                description = "Opcjonalne filtry zawężające wyniki wyszukiwania",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "Zakres dat w formacie RRRR-MM-DD:RRRR-MM-DD" 
                    },
                    category = new { 
                        type = "string", 
                        description = "Nazwa kategorii do filtrowania" 
                    }
                }
            },
            limit = new { 
                type = "integer", 
                description = "Maksymalna liczba zwracanych wyników (1-50)",
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
    
    // Właściwość email z walidacją formatu
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "Adres e-mail użytkownika");
    
    // Właściwość wiek z ograniczeniami liczbowymi
    Map<String, Object> age = new HashMap<>();
    age.put("type", "integer");
    age.put("minimum", 13);
    age.put("maximum", 120);
    age.put("description", "Wiek użytkownika w latach");
    
    // Właściwość enumerowana
    Map<String, Object> subscription = new HashMap<>();
    subscription.put("type", "string");
    subscription.put("enum", Arrays.asList("free", "basic", "premium"));
    subscription.put("default", "free");
    subscription.put("description", "Poziom subskrypcji");
    
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
        # Przetwarzanie żądania
        results = await self._search_database(request.parameters["query"])
        
        # Zawsze zwracaj spójną strukturę
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
    """Zapewnia spójną strukturę każdego elementu"""
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
            throw new ToolExecutionException($"Plik nie znaleziony: {fileId}");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ToolExecutionException("Nie masz uprawnień do dostępu do tego pliku");
        }
        catch (Exception ex) when (ex is IOException || ex is TimeoutException)
        {
            _logger.LogError(ex, "Błąd dostępu do pliku {FileId}", fileId);
            throw new ToolExecutionException("Błąd dostępu do pliku: Usługa jest tymczasowo niedostępna");
        }
    }
    catch (JsonException)
    {
        throw new ToolExecutionException("Nieprawidłowy format ID pliku");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Nieoczekiwany błąd w FileAccessTool");
        throw new ToolExecutionException("Wystąpił nieoczekiwany błąd");
    }
}
```

#### 2. Structured Error Responses

Return structured error information when possible:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    try {
        // Implementacja
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
        
        // Ponowne rzucenie innych wyjątków jako ToolExecutionException
        throw new ToolExecutionException("Wykonanie narzędzia nie powiodło się: " + ex.getMessage(), ex);
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
            # Wywołanie zewnętrznego API
            return await self._call_api(request.parameters)
        except TransientError as e:
            retry_count += 1
            if retry_count >= max_retries:
                raise ToolExecutionException(f"Operacja nie powiodła się po {max_retries} próbach: {str(e)}")
                
            # Eksponencjalne opóźnienie
            delay = base_delay * (2 ** (retry_count - 1))
            logging.warning(f"Błąd przejściowy, ponawianie za {delay}s: {str(e)}")
            await asyncio.sleep(delay)
        except Exception as e:
            # Błąd nieprzejściowy, brak ponawiania
            raise ToolExecutionException(f"Operacja nie powiodła się: {str(e)}")
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
        
        // Utwórz klucz cache na podstawie parametrów
        var cacheKey = $"data_query_{ComputeHash(query)}";
        
        // Najpierw spróbuj pobrać z cache
        if (_cache.TryGetValue(cacheKey, out var cachedResult))
        {
            return new ToolResponse { Result = cachedResult };
        }
        
        // Brak w cache - wykonaj faktyczne zapytanie
        var result = await _database.QueryAsync(query);
        
        // Zapisz w cache z czasem wygaśnięcia
        var cacheOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
            
        _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
        
        return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
    }
    
    private string ComputeHash(string input)
    {
        // Implementacja generowania stabilnego hasha dla klucza cache
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
        
        // Dla operacji długotrwałych zwróć od razu ID procesu
        String processId = UUID.randomUUID().toString();
        
        // Rozpocznij asynchroniczne przetwarzanie
        CompletableFuture.runAsync(() -> {
            try {
                // Wykonaj długotrwałą operację
                documentService.processDocument(documentId);
                
                // Zaktualizuj status (zwykle przechowywany w bazie danych)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // Zwróć natychmiastową odpowiedź z ID procesu
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // Narzędzie do sprawdzania statusu procesu
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
            tokens_per_second=5,  # Pozwól na 5 żądań na sekundę
            bucket_size=10        # Pozwól na nagłe skoki do 10 żądań
        )
    
    async def execute_async(self, request):
        # Sprawdź, czy możemy kontynuować, czy trzeba poczekać
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # Jeśli czas oczekiwania jest zbyt długi
                raise ToolExecutionException(
                    f"Przekroczono limit zapytań. Spróbuj ponownie za {delay:.1f} sekund."
                )
            else:
                # Poczekaj odpowiedni czas
                await asyncio.sleep(delay)
        
        # Zużyj token i kontynuuj żądanie
        self.rate_limiter.consume()
        
        # Wywołaj API
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
            
            # Oblicz czas do dostępności kolejnego tokena
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # Dodaj nowe tokeny na podstawie upływającego czasu
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
    // Sprawdź, czy parametry istnieją
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("Brak wymaganego parametru: query");
    }
    
    // Sprawdź poprawny typ
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("Parametr query musi być typu string");
    }
    
    var query = queryProp.GetString();
    
    // Sprawdź zawartość stringa
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("Parametr query nie może być pusty");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("Parametr query przekracza maksymalną długość 500 znaków");
    }
    
    // Sprawdź pod kątem ataków SQL injection, jeśli dotyczy
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("Nieprawidłowe zapytanie: zawiera potencjalnie niebezpieczne SQL");
    }
    
    // Kontynuuj wykonanie
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // Pobierz kontekst użytkownika z żądania
    UserContext user = request.getContext().getUserContext();
    
    // Sprawdź, czy użytkownik ma wymagane uprawnienia
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("Użytkownik nie ma uprawnień do dostępu do dokumentów");
    }
    
    // Dla konkretnych zasobów sprawdź dostęp do tego zasobu
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("Odmowa dostępu do żądanego dokumentu");
    }
    
    // Kontynuuj wykonanie narzędzia
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
        
        # Pobierz dane użytkownika
        user_data = await self.user_service.get_user_data(user_id)
        
        # Filtruj pola wrażliwe, chyba że wyraźnie żądane I uprawnione
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # Sprawdź poziom autoryzacji w kontekście żądania
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # Utwórz kopię, aby nie modyfikować oryginału
        redacted = user_data.copy()
        
        # Zamaskuj konkretne pola wrażliwe
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # Zamaskuj zagnieżdżone dane wrażliwe
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
    // Przygotowanie
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("Seattle", 3))
        .ReturnsAsync(new WeatherForecast(/* dane testowe */));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "Seattle", 
            days = 3 
        })
    );
    
    // Wykonanie
    var response = await tool.ExecuteAsync(request);
    
    // Sprawdzenie
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // Przygotowanie
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
    
    // Wykonanie i sprawdzenie
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
    // Utwórz instancję narzędzia
    SearchTool searchTool = new SearchTool();
    
    // Pobierz schemat
    Object schema = searchTool.getSchema();
    
    // Konwertuj schemat do JSON do walidacji
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // Sprawdź, czy schemat jest poprawnym JSONSchema
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // Testuj poprawne parametry
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // Testuj brak wymaganego parametru
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // Testuj niepoprawny typ parametru
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
    # Przygotowanie
    tool = ApiTool(timeout=0.1)  # Bardzo krótki timeout
    
    # Zamockuj żądanie, które przekroczy timeout
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # Dłużej niż timeout
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # Wykonanie i sprawdzenie
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Sprawdź komunikat wyjątku
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # Przygotowanie
    tool = ApiTool()
    
    # Zamockuj odpowiedź z ograniczeniem rate limit
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
        
        # Wykonanie i sprawdzenie
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Sprawdź, czy wyjątek zawiera informacje o limicie
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
    // Przygotowanie
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // Wykonanie
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
        // Testuj endpoint odkrywania narzędzi
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // Utwórz żądanie narzędzia
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // Wyślij żądanie i zweryfikuj odpowiedź
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // Utwórz nieprawidłowe żądanie narzędzia
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // Brak parametru "b"
        request.put("parameters", parameters);
        
        // Wyślij żądanie i zweryfikuj odpowiedź z błędem
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
    # Przygotowanie - skonfiguruj klienta MCP i mock modelu
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # Mock odpowiedzi modelu
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
    
    # Mock odpowiedzi narzędzia pogodowego
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
        
        # Wykonanie
        response = await mcp_client.send_prompt(
            "What's the weather in Seattle?",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # Sprawdzenie
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
    // Przygotowanie
    var server = new McpServer(
        name: "TestServer",
        version: "1.0",
        maxConcurrentRequests: 100
    );
    
    server.RegisterTool(new FastExecutingTool());
    await server.StartAsync();
    
    var client = new McpClient("http://localhost:5000");
    
    // Wykonanie
    var tasks = new List<Task<McpResponse>>();
    for (int i = 0; i < 1000; i++)
    {
        tasks.Add(client.ExecuteToolAsync("fastTool", new { iteration = i }));
    }
    
    var results = await Task.WhenAll(tasks);
    
    // Sprawdzenie
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
    
    // Skonfiguruj JMeter do testów obciążeniowych
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // Skonfiguruj plan testów JMeter
    HashTree testPlanTree = new HashTree();
    
    // Utwórz plan testów, grupę wątków, samplery itd.
    TestPlan testPlan = new TestPlan("MCP Server Stress Test");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // Dodaj sampler HTTP do wykonania narzędzia
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // Dodaj listenerów
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // Uruchom test
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // Walidacja wyników
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // Średni czas odpowiedzi < 200ms
    assertTrue(summaryReport.getPercentile(90.0) < 500); // 90 percentyl < 500ms
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# Konfiguracja monitoringu dla serwera MCP
def configure_monitoring(server):
    # Skonfiguruj metryki Prometheus
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "Całkowita liczba żądań MCP"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "Czas trwania żądania w sekundach",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "Liczba wykonanych narzędzi",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "Czas wykonania narzędzia w sekundach",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "Błędy wykonania narzędzi",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # Dodaj middleware do mierzenia czasu i rejestrowania metryk
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # Udostępnij endpoint metryk
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
# Implementacja łańcucha narzędzi w Pythonie
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # Lista nazw narzędzi do wykonania po kolei
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # Wykonaj każde narzędzie w łańcuchu, przekazując poprzedni wynik
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # Zapisz wynik i użyj go jako wejście dla następnego narzędzia
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# Przykładowe użycie
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
    public string Description => "Przetwarza zawartość różnych typów";
    
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
        
        // Określ, które specjalistyczne narzędzie użyć
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // Przekaż do specjalistycznego narzędzia
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

csvProcessor to narzędzie do efektywnego przetwarzania plików CSV w JavaScript. Umożliwia szybkie parsowanie, filtrowanie i modyfikowanie danych CSV bez konieczności ładowania całego pliku do pamięci.

## Funkcje

- Parsowanie plików CSV o dowolnym rozmiarze
- Obsługa niestandardowych separatorów i znaków cytowania
- Filtrowanie danych na podstawie warunków
- Modyfikowanie i aktualizowanie rekordów
- Eksportowanie zmodyfikowanych danych do nowego pliku CSV

## Przykład użycia

```javascript
import { csvProcessor } from 'csvProcessor';

const csvData = `
id,name,age
1,Jan Kowalski,30
2,Anna Nowak,25
3,Piotr Wiśniewski,40
`;

const processor = new csvProcessor(csvData, { delimiter: ',' });

// Filtrowanie osób powyżej 30 lat
const filtered = processor.filter(row => parseInt(row.age) > 30);

console.log(filtered);
```

## Uwagi

[!NOTE] csvProcessor działa synchronicznie, więc dla bardzo dużych plików zaleca się użycie w środowisku Node.js, aby uniknąć blokowania interfejsu użytkownika.

[!WARNING] Nie obsługuje plików CSV z wieloliniowymi polami.

## Instalacja

Możesz zainstalować csvProcessor za pomocą npm:

```bash
npm install csvProcessor
```

lub yarn:

```bash
yarn add csvProcessor
```

## Dokumentacja

Więcej informacji znajdziesz w oficjalnej dokumentacji na stronie projektu.
            ("code", _) => "codeAnalyzer",
            _ => throw new ToolExecutionException($"No tool available for {contentType}/{operation}")
        };
    }
    
    private object GetOptionsForTool(string toolName, string operation)
    {
        // Zwróć odpowiednie opcje dla każdego wyspecjalizowanego narzędzia
        return toolName switch
        {
            "textSummarizer" => new { length = "medium" },
            "htmlProcessor" => new { cleanUp = true, operation },
            // Opcje dla innych narzędzi...
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
        // Krok 1: Pobierz metadane zestawu danych (synchronizacyjnie)
        ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata", 
            Map.of("datasetId", datasetId));
        
        // Krok 2: Uruchom wiele analiz równolegle
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
        
        // Poczekaj na zakończenie wszystkich zadań równoległych
        CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
            statisticalAnalysis, correlationAnalysis, outlierDetection
        );
        
        allAnalyses.join();  // Czekaj na zakończenie
        
        // Krok 3: Połącz wyniki
        Map<String, Object> combinedResults = new HashMap<>();
        combinedResults.put("metadata", metadataResponse.getResult());
        combinedResults.put("statistics", statisticalAnalysis.join().getResult());
        combinedResults.put("correlations", correlationAnalysis.join().getResult());
        combinedResults.put("outliers", outlierDetection.join().getResult());
        
        // Krok 4: Wygeneruj raport podsumowujący
        ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator", 
            Map.of("analysisResults", combinedResults));
        
        // Zwróć kompletny wynik workflow
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
            # Najpierw spróbuj użyć narzędzia podstawowego
            response = await self.client.execute_tool(primary_tool, parameters)
            return {
                "result": response.result,
                "source": "primary",
                "tool": primary_tool
            }
        except ToolExecutionException as e:
            # Zaloguj niepowodzenie
            logging.warning(f"Podstawowe narzędzie '{primary_tool}' nie powiodło się: {str(e)}")
            
            # Przejdź do narzędzia zapasowego
            try:
                # Może być konieczna transformacja parametrów dla narzędzia zapasowego
                fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)
                
                response = await self.client.execute_tool(fallback_tool, fallback_params)
                return {
                    "result": response.result,
                    "source": "fallback",
                    "tool": fallback_tool,
                    "primaryError": str(e)
                }
            except ToolExecutionException as fallback_error:
                # Oba narzędzia zawiodły
                logging.error(f"Zarówno narzędzie podstawowe, jak i zapasowe zawiodły. Błąd zapasowego: {str(fallback_error)}")
                raise WorkflowExecutionException(
                    f"Workflow nie powiódł się: błąd podstawowy: {str(e)}; błąd zapasowy: {str(fallback_error)}"
                )
    
    def _adapt_parameters(self, params, from_tool, to_tool):
        """Dostosuj parametry między różnymi narzędziami, jeśli to konieczne"""
        # Ta implementacja zależy od konkretnych narzędzi
        # W tym przykładzie po prostu zwrócimy oryginalne parametry
        return params

# Przykład użycia
async def get_weather(workflow, location):
    return await workflow.execute_with_fallback(
        "premiumWeatherService",  # Podstawowe (płatne) API pogodowe
        "basicWeatherService",    # Zapasowe (darmowe) API pogodowe
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
            
            // Zapisz wynik każdego workflow
            results[workflow.Name] = workflowResult;
            
            // Zaktualizuj kontekst o wynik dla kolejnego workflow
            context = context.WithResult(workflow.Name, workflowResult);
        }
        
        return new WorkflowResult(results);
    }
    
    public string Name => "CompositeWorkflow";
    public string Description => "Wykonuje wiele workflow sekwencyjnie";
}

// Przykład użycia
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
// Przykładowy test jednostkowy dla narzędzia kalkulatora w C#
[Fact]
public async Task CalculatorTool_Add_ReturnsCorrectSum()
{
    // Przygotowanie
    var calculator = new CalculatorTool();
    var parameters = new Dictionary<string, object>
    {
        ["operation"] = "add",
        ["a"] = 5,
        ["b"] = 7
    };
    
    // Wykonanie
    var response = await calculator.ExecuteAsync(parameters);
    var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());
    
    // Sprawdzenie
    Assert.Equal(12, result.Value);
}
```

```python
# Przykładowy test jednostkowy dla narzędzia kalkulatora w Pythonie
def test_calculator_tool_add():
    # Przygotowanie
    calculator = CalculatorTool()
    parameters = {
        "operation": "add",
        "a": 5,
        "b": 7
    }
    
    # Wykonanie
    response = calculator.execute(parameters)
    result = json.loads(response.content[0].text)
    
    # Sprawdzenie
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
// Przykładowy test integracyjny dla serwera MCP w C#
[Fact]
public async Task Server_ProcessToolRequest_ReturnsValidResponse()
{
    // Przygotowanie
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
    
    // Wykonanie
    var response = await server.ProcessRequestAsync(request);
    
    // Sprawdzenie
    Assert.NotNull(response);
    Assert.Equal(McpStatusCodes.Success, response.StatusCode);
    // Dodatkowe asercje dotyczące zawartości odpowiedzi
    
    // Sprzątanie
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
// Przykładowy test E2E z klientem w TypeScript
describe('MCP Server E2E Tests', () => {
  let client: McpClient;
  
  beforeAll(async () => {
    // Uruchom serwer w środowisku testowym
    await startTestServer();
    client = new McpClient('http://localhost:5000');
  });
  
  afterAll(async () => {
    await stopTestServer();
  });
  
  test('Client can invoke calculator tool and get correct result', async () => {
    // Wykonanie
    const response = await client.invokeToolAsync('calculator', {
      operation: 'divide',
      a: 20,
      b: 4
    });
    
    // Sprawdzenie
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
// Przykład w C# z użyciem Moq
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
# Przykład w Pythonie z unittest.mock
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
    # Konfiguracja mocka
    mock_model.return_value.generate_response.return_value = {
        "text": "Mocked model response",
        "finish_reason": "completed"
    }
    
    # Użycie mocka w teście
    server = McpServer(model_client=mock_model)
    # Kontynuuj test
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
// Skrypt k6 do testów obciążeniowych serwera MCP
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  vus: 10,  // 10 wirtualnych użytkowników
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
    // Przygotowanie
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");
    
    // Wykonanie
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
    // Dodatkowa walidacja schematu
});
}
```

## Top 10 wskazówek dotyczących skutecznego testowania serwera MCP

1. **Testuj definicje narzędzi osobno**: Sprawdzaj definicje schematów niezależnie od logiki narzędzi
2. **Używaj testów parametryzowanych**: Testuj narzędzia z różnymi danymi wejściowymi, w tym przypadkami brzegowymi
3. **Sprawdzaj odpowiedzi błędów**: Weryfikuj poprawne obsługiwanie wszystkich możliwych błędów
4. **Testuj logikę autoryzacji**: Zapewnij właściwą kontrolę dostępu dla różnych ról użytkowników
5. **Monitoruj pokrycie testami**: Dąż do wysokiego pokrycia krytycznych fragmentów kodu
6. **Testuj odpowiedzi strumieniowe**: Sprawdzaj poprawne przetwarzanie treści przesyłanych strumieniowo
7. **Symuluj problemy sieciowe**: Testuj zachowanie w warunkach słabego połączenia sieciowego
8. **Testuj limity zasobów**: Weryfikuj zachowanie przy osiąganiu limitów kwot lub szybkości
9. **Automatyzuj testy regresji**: Stwórz zestaw testów uruchamianych przy każdej zmianie kodu
10. **Dokumentuj przypadki testowe**: Prowadź jasną dokumentację scenariuszy testowych

## Typowe pułapki podczas testowania

- **Nadmierne poleganie na testach „happy path”**: Upewnij się, że testujesz dokładnie przypadki błędów
- **Ignorowanie testów wydajnościowych**: Wykrywaj wąskie gardła zanim wpłyną na produkcję
- **Testowanie tylko w izolacji**: Łącz testy jednostkowe, integracyjne i end-to-end
- **Niepełne pokrycie API**: Zapewnij testowanie wszystkich punktów końcowych i funkcji
- **Niespójne środowiska testowe**: Używaj kontenerów, aby zapewnić spójność środowisk testowych

## Podsumowanie

Kompleksowa strategia testowania jest niezbędna do tworzenia niezawodnych i wysokiej jakości serwerów MCP. Wdrażając najlepsze praktyki i wskazówki opisane w tym przewodniku, możesz zapewnić, że Twoje implementacje MCP spełniają najwyższe standardy jakości, niezawodności i wydajności.

## Kluczowe wnioski

1. **Projektowanie narzędzi**: Stosuj zasadę pojedynczej odpowiedzialności, korzystaj z wstrzykiwania zależności i projektuj pod kątem kompozycji
2. **Projektowanie schematów**: Twórz jasne, dobrze udokumentowane schematy z odpowiednimi ograniczeniami walidacji
3. **Obsługa błędów**: Implementuj łagodne zarządzanie błędami, ustrukturyzowane odpowiedzi błędów oraz logikę ponawiania
4. **Wydajność**: Wykorzystuj cache, przetwarzanie asynchroniczne i ograniczanie zasobów
5. **Bezpieczeństwo**: Stosuj dokładną walidację danych wejściowych, kontrole autoryzacji oraz bezpieczne przetwarzanie danych wrażliwych
6. **Testowanie**: Twórz kompleksowe testy jednostkowe, integracyjne i end-to-end
7. **Wzorce przepływu pracy**: Stosuj sprawdzone wzorce, takie jak łańcuchy, dyspozytory i przetwarzanie równoległe

## Ćwiczenie

Zaprojektuj narzędzie MCP i przepływ pracy dla systemu przetwarzania dokumentów, który:

1. Akceptuje dokumenty w różnych formatach (PDF, DOCX, TXT)
2. Wydobywa tekst i kluczowe informacje z dokumentów
3. Klasyfikuje dokumenty według typu i zawartości
4. Generuje podsumowanie każdego dokumentu

Zaimplementuj schematy narzędzia, obsługę błędów oraz wzorzec przepływu pracy najlepiej dopasowany do tego scenariusza. Zastanów się, jak przetestujesz tę implementację.

## Zasoby

1. Dołącz do społeczności MCP na [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs), aby być na bieżąco z najnowszymi wydarzeniami
2. Wspieraj projekty open-source [MCP](https://github.com/modelcontextprotocol)
3. Stosuj zasady MCP w inicjatywach AI w swojej organizacji
4. Poznaj specjalistyczne implementacje MCP dla swojej branży
5. Rozważ udział w zaawansowanych kursach dotyczących konkretnych tematów MCP, takich jak integracja multimodalna czy integracja aplikacji korporacyjnych
6. Eksperymentuj z tworzeniem własnych narzędzi i przepływów MCP, korzystając z zasad poznanych w [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

Następne: Najlepsze praktyki [studia przypadków](../09-CaseStudy/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do jak największej dokładności, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za źródło autorytatywne. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.