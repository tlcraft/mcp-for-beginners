<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0728873f4271f8c19105619921e830d9",
  "translation_date": "2025-07-22T08:52:37+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "pl"
}
-->
# Najlepsze praktyki rozwoju MCP

## Przegląd

Ta lekcja koncentruje się na zaawansowanych najlepszych praktykach dotyczących tworzenia, testowania i wdrażania serwerów MCP oraz funkcji w środowiskach produkcyjnych. W miarę jak ekosystemy MCP stają się coraz bardziej złożone i istotne, przestrzeganie ustalonych wzorców zapewnia niezawodność, łatwość utrzymania i interoperacyjność. Lekcja ta zbiera praktyczne doświadczenia zdobyte podczas rzeczywistych wdrożeń MCP, aby pomóc w tworzeniu solidnych, wydajnych serwerów z efektywnymi zasobami, podpowiedziami i narzędziami.

## Cele nauki

Po ukończeniu tej lekcji będziesz w stanie:

- Stosować najlepsze praktyki branżowe w projektowaniu serwerów i funkcji MCP
- Tworzyć kompleksowe strategie testowania serwerów MCP
- Projektować wydajne, wielokrotnego użytku wzorce przepływu pracy dla złożonych aplikacji MCP
- Wdrażać odpowiednie mechanizmy obsługi błędów, logowania i obserwowalności w serwerach MCP
- Optymalizować implementacje MCP pod kątem wydajności, bezpieczeństwa i łatwości utrzymania

## Podstawowe zasady MCP

Zanim przejdziemy do konkretnych praktyk implementacyjnych, ważne jest, aby zrozumieć podstawowe zasady, które kierują skutecznym rozwojem MCP:

1. **Standaryzowana komunikacja**: MCP opiera się na JSON-RPC 2.0, zapewniając spójny format dla żądań, odpowiedzi i obsługi błędów we wszystkich implementacjach.

2. **Projektowanie zorientowane na użytkownika**: Zawsze priorytetem powinny być zgoda użytkownika, kontrola i przejrzystość w implementacjach MCP.

3. **Bezpieczeństwo przede wszystkim**: Wdrażaj solidne środki bezpieczeństwa, w tym uwierzytelnianie, autoryzację, walidację i ograniczanie liczby żądań.

4. **Modularna architektura**: Projektuj serwery MCP w sposób modułowy, gdzie każde narzędzie i zasób ma jasno określony, skoncentrowany cel.

5. **Połączenia stanowe**: Wykorzystaj zdolność MCP do utrzymywania stanu między wieloma żądaniami, aby zapewnić bardziej spójne i świadome kontekstu interakcje.

## Oficjalne najlepsze praktyki MCP

Poniższe najlepsze praktyki pochodzą z oficjalnej dokumentacji Model Context Protocol:

### Najlepsze praktyki bezpieczeństwa

1. **Zgoda i kontrola użytkownika**: Zawsze wymagaj wyraźnej zgody użytkownika przed uzyskaniem dostępu do danych lub wykonaniem operacji. Zapewnij jasną kontrolę nad tym, jakie dane są udostępniane i jakie działania są autoryzowane.

2. **Prywatność danych**: Udostępniaj dane użytkownika tylko za wyraźną zgodą i chroń je za pomocą odpowiednich mechanizmów kontroli dostępu. Zapobiegaj nieautoryzowanemu przesyłaniu danych.

3. **Bezpieczeństwo narzędzi**: Wymagaj wyraźnej zgody użytkownika przed uruchomieniem jakiegokolwiek narzędzia. Upewnij się, że użytkownicy rozumieją funkcjonalność każdego narzędzia i egzekwuj solidne granice bezpieczeństwa.

4. **Kontrola uprawnień narzędzi**: Konfiguruj, które narzędzia model może używać podczas sesji, zapewniając dostęp tylko do wyraźnie autoryzowanych narzędzi.

5. **Uwierzytelnianie**: Wymagaj odpowiedniego uwierzytelniania przed przyznaniem dostępu do narzędzi, zasobów lub wrażliwych operacji, używając kluczy API, tokenów OAuth lub innych bezpiecznych metod uwierzytelniania.

6. **Walidacja parametrów**: Egzekwuj walidację dla wszystkich wywołań narzędzi, aby zapobiec przesyłaniu nieprawidłowych lub złośliwych danych wejściowych do implementacji narzędzi.

7. **Ograniczanie liczby żądań**: Wdrażaj ograniczanie liczby żądań, aby zapobiec nadużyciom i zapewnić sprawiedliwe wykorzystanie zasobów serwera.

### Najlepsze praktyki implementacyjne

1. **Negocjacja możliwości**: Podczas nawiązywania połączenia wymieniaj informacje o obsługiwanych funkcjach, wersjach protokołu, dostępnych narzędziach i zasobach.

2. **Projektowanie narzędzi**: Twórz narzędzia skoncentrowane na jednej funkcji, zamiast monolitycznych narzędzi obsługujących wiele zagadnień.

3. **Obsługa błędów**: Wdrażaj standaryzowane komunikaty o błędach i kody, aby ułatwić diagnozowanie problemów, łagodnie obsługiwać awarie i dostarczać użyteczne informacje zwrotne.

4. **Logowanie**: Konfiguruj strukturalne logi do audytowania, debugowania i monitorowania interakcji protokołu.

5. **Śledzenie postępu**: Dla operacji długotrwałych raportuj aktualizacje postępu, aby umożliwić responsywne interfejsy użytkownika.

6. **Anulowanie żądań**: Pozwól klientom anulować żądania w trakcie realizacji, które nie są już potrzebne lub trwają zbyt długo.

## Dodatkowe materiały

Aby uzyskać najbardziej aktualne informacje na temat najlepszych praktyk MCP, zapoznaj się z:

- [Dokumentacją MCP](https://modelcontextprotocol.io/)
- [Specyfikacją MCP](https://spec.modelcontextprotocol.io/)
- [Repozytorium GitHub](https://github.com/modelcontextprotocol)
- [Najlepszymi praktykami bezpieczeństwa](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## Praktyczne przykłady implementacji

### Najlepsze praktyki projektowania narzędzi

#### 1. Zasada pojedynczej odpowiedzialności

Każde narzędzie MCP powinno mieć jasno określony, skoncentrowany cel. Zamiast tworzyć monolityczne narzędzia próbujące obsługiwać wiele zagadnień, rozwijaj wyspecjalizowane narzędzia, które doskonale radzą sobie z konkretnymi zadaniami.

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

Wdrażaj solidną obsługę błędów z informacyjnymi komunikatami o błędach i odpowiednimi mechanizmami odzyskiwania.

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

Zawsze dokładnie weryfikuj parametry, aby zapobiec przesyłaniu nieprawidłowych lub złośliwych danych wejściowych.

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

### 1. Testowanie jednostkowe narzędzi MCP

Zawsze testuj narzędzia w izolacji, symulując zewnętrzne zależności:

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

### 2. Testowanie integracyjne

Testuj cały przepływ od żądań klienta do odpowiedzi serwera:

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

Wdrażaj odpowiednie mechanizmy buforowania, aby zmniejszyć opóźnienia i zużycie zasobów:

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

```

ExecuteAsync(ToolRequest request)
{
    var query = request.Parameters.GetProperty("query").GetString();
    
    // Utwórz klucz pamięci podręcznej na podstawie parametrów
    var cacheKey = $"data_query_{ComputeHash(query)}";
    
    // Najpierw spróbuj pobrać z pamięci podręcznej
    if (_cache.TryGetValue(cacheKey, out var cachedResult))
    {
        return new ToolResponse { Result = cachedResult };
    }
    
    // Brak w pamięci podręcznej - wykonaj rzeczywiste zapytanie
    var result = await _database.QueryAsync(query);
    
    // Zapisz w pamięci podręcznej z okresem ważności
    var cacheOptions = new MemoryCacheEntryOptions()
        .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
        
    _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
    
    return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
}

private string ComputeHash(string input)
{
    // Implementacja generowania stabilnego skrótu dla klucza pamięci podręcznej
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
        
        // Dla operacji długotrwałych natychmiast zwróć identyfikator przetwarzania
        String processId = UUID.randomUUID().toString();
        
        // Rozpocznij asynchroniczne przetwarzanie
        CompletableFuture.runAsync(() -> {
            try {
                // Wykonaj operację długotrwałą
                documentService.processDocument(documentId);
                
                // Zaktualizuj status (zazwyczaj przechowywany w bazie danych)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // Natychmiast zwróć odpowiedź z identyfikatorem procesu
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
            bucket_size=10        # Pozwól na nagłe wzrosty do 10 żądań
        )
    
    async def execute_async(self, request):
        # Sprawdź, czy można kontynuować, czy trzeba poczekać
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # Jeśli czas oczekiwania jest zbyt długi
                raise ToolExecutionException(
                    f"Przekroczono limit żądań. Spróbuj ponownie za {delay:.1f} sekund."
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
            
            # Oblicz czas do następnego dostępnego tokena
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # Dodaj nowe tokeny na podstawie upływu czasu
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
    
    // Sprawdź zawartość ciągu znaków
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("Parametr query nie może być pusty");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("Parametr query przekracza maksymalną długość 500 znaków");
    }
    
    // Sprawdź ataki SQL injection, jeśli dotyczy
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("Nieprawidłowe zapytanie: zawiera potencjalnie niebezpieczny SQL");
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
    
    // Dla określonych zasobów sprawdź dostęp do tego zasobu
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
        
        # Filtruj wrażliwe pola, chyba że wyraźnie zażądano I autoryzowano
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # Sprawdź poziom autoryzacji w kontekście żądania
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # Utwórz kopię, aby uniknąć modyfikacji oryginału
        redacted = user_data.copy()
        
        # Ukryj określone wrażliwe pola
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # Ukryj zagnieżdżone wrażliwe dane
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
    
    // Działanie
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
        .ThrowsAsync(new LocationNotFoundException("Lokalizacja nie została znaleziona"));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "InvalidLocation", 
            days = 3 
        })
    );
    
    // Działanie i sprawdzenie
    var exception = await Assert.ThrowsAsync<ToolExecutionException>(
        () => tool.ExecuteAsync(request)
    );
    
    Assert.Contains("Lokalizacja nie została znaleziona", exception.Message);
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
    
    // Przekształć schemat na JSON do walidacji
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // Sprawdź, czy schemat jest poprawnym JSONSchema
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // Test poprawnych parametrów
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // Test brakującego wymaganego parametru
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // Test niepoprawnego typu parametru
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
    tool = ApiTool(timeout=0.1)  # Bardzo krótki czas oczekiwania
    
    # Zasymuluj żądanie, które przekroczy czas oczekiwania
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # Dłużej niż czas oczekiwania
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # Działanie i sprawdzenie
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Zweryfikuj komunikat wyjątku
        assert "przekroczono czas" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # Przygotowanie
    tool = ApiTool()
    
    # Zasymuluj odpowiedź z ograniczeniem szybkości
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            status=429,
            headers={"Retry-After": "2"},
            body=json.dumps({"error": "Przekroczono limit żądań"})
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # Działanie i sprawdzenie
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Zweryfikuj, czy wyjątek zawiera informacje o ograniczeniu szybkości
        error_msg = str(exc_info.value).lower()
        assert "limit żądań" in error_msg
        assert "spróbuj ponownie" in error_msg
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
    
    // Działanie
```markdown
var result = await workflowExecutor.ExecuteWorkflowAsync(new[] {
    new ToolCall("dataFetch", new { source = "sales2023" }),
    new ToolCall("dataAnalysis", ctx =
> new { 
        data = ctx.GetResult("dataFetch"),
        analysis = "trend" 
    }),
    new ToolCall("dataVisualize", ctx => new {
        analysisResult = ctx.GetResult("dataAnalysis"),
        type = "line-chart"
    })
});

// Sprawdzenie
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
        // Testowanie punktu końcowego odkrywania narzędzi
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // Tworzenie żądania narzędzia
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // Wysyłanie żądania i weryfikacja odpowiedzi
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // Tworzenie nieprawidłowego żądania narzędzia
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // Brak parametru "b"
        request.put("parameters", parameters);
        
        // Wysyłanie żądania i weryfikacja odpowiedzi błędu
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
    # Przygotowanie - Konfiguracja klienta MCP i modelu mock
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # Mock odpowiedzi modelu
    mock_model = MockLanguageModel([
        MockResponse(
            "Jaka jest pogoda w Seattle?",
            tool_calls=[{
                "tool_name": "weatherForecast",
                "parameters": {"location": "Seattle", "days": 3}
            }]
        ),
        MockResponse(
            "Oto prognoza pogody dla Seattle:\n- Dziś: 65°F, częściowe zachmurzenie\n- Jutro: 68°F, słonecznie\n- Pojutrze: 62°F, deszcz",
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
                        {"date": "2023-06-01", "temperature": 65, "conditions": "Częściowe zachmurzenie"},
                        {"date": "2023-06-02", "temperature": 68, "conditions": "Słonecznie"},
                        {"date": "2023-06-03", "temperature": 62, "conditions": "Deszcz"}
                    ]
                }
            }
        )
        
        # Działanie
        response = await mcp_client.send_prompt(
            "Jaka jest pogoda w Seattle?",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # Sprawdzenie
        assert "Seattle" in response.generated_text
        assert "65" in response.generated_text
        assert "Słonecznie" in response.generated_text
        assert "Deszcz" in response.generated_text
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
    
    // Działanie
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
    
    // Konfiguracja JMeter do testów obciążeniowych
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // Konfiguracja planu testowego JMeter
    HashTree testPlanTree = new HashTree();
    
    // Tworzenie planu testowego, grupy wątków, samplerów itp.
    TestPlan testPlan = new TestPlan("Test obciążeniowy serwera MCP");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // Dodanie HTTP samplera do wykonania narzędzia
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // Dodanie listenerów
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // Uruchomienie testu
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // Walidacja wyników
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // Średni czas odpowiedzi < 200ms
    assertTrue(summaryReport.getPercentile(90.0) < 500); // 90. percentyl < 500ms
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# Konfiguracja monitorowania dla serwera MCP
def configure_monitoring(server):
    # Konfiguracja metryk Prometheus
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "Łączna liczba żądań MCP"),
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
            "Czas trwania wykonania narzędzia w sekundach",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "Błędy wykonania narzędzi",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # Dodanie middleware do mierzenia czasu i rejestrowania metryk
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # Udostępnienie punktu końcowego metryk
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
        self.tools_chain = tools_chain  # Lista nazw narzędzi do wykonania w kolejności
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # Wykonanie każdego narzędzia w łańcuchu, przekazując poprzedni wynik
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # Przechowywanie wyniku i użycie jako wejścia dla kolejnego narzędzia
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# Przykład użycia
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
    public string Description => "Przetwarza treści różnych typów";
    
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
        
        // Określenie, które narzędzie specjalistyczne użyć
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // Przekazanie do narzędzia specjalistycznego
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
            ("csv", _) => "csvProcessor",
            ("code", _) => "codeProcessor",
            _ => throw new InvalidOperationException("Nieobsługiwany typ treści lub operacja")
        };
    }
}
```
"csvProcessor",
("code", _) => "codeAnalyzer",
            _ => throw new ToolExecutionException($"Brak dostępnego narzędzia dla {contentType}/{operation}")
        };
    }
    
    private object GetOptionsForTool(string toolName, string operation)
    {
        // Zwróć odpowiednie opcje dla każdego specjalistycznego narzędzia
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
        // Krok 1: Pobierz metadane zbioru danych (synchronizacja)
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
        
        // Poczekaj na zakończenie wszystkich równoległych zadań
        CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
            statisticalAnalysis, correlationAnalysis, outlierDetection
        );
        
        allAnalyses.join();  // Oczekiwanie na zakończenie
        
        // Krok 3: Połącz wyniki
        Map<String, Object> combinedResults = new HashMap<>();
        combinedResults.put("metadata", metadataResponse.getResult());
        combinedResults.put("statistics", statisticalAnalysis.join().getResult());
        combinedResults.put("correlations", correlationAnalysis.join().getResult());
        combinedResults.put("outliers", outlierDetection.join().getResult());
        
        // Krok 4: Wygeneruj raport podsumowujący
        ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator", 
            Map.of("analysisResults", combinedResults));
        
        // Zwróć pełny wynik przepływu pracy
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
            # Najpierw spróbuj użyć narzędzia głównego
            response = await self.client.execute_tool(primary_tool, parameters)
            return {
                "result": response.result,
                "source": "primary",
                "tool": primary_tool
            }
        except ToolExecutionException as e:
            # Zaloguj niepowodzenie
            logging.warning(f"Narzędzie główne '{primary_tool}' nie powiodło się: {str(e)}")
            
            # Przejdź do narzędzia zapasowego
            try:
                # Może być konieczne przekształcenie parametrów dla narzędzia zapasowego
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
                logging.error(f"Zarówno narzędzie główne, jak i zapasowe zawiodły. Błąd zapasowy: {str(fallback_error)}")
                raise WorkflowExecutionException(
                    f"Przepływ pracy nie powiódł się: błąd główny: {str(e)}; błąd zapasowy: {str(fallback_error)}"
                )
    
    def _adapt_parameters(self, params, from_tool, to_tool):
        """Dostosuj parametry między różnymi narzędziami, jeśli to konieczne"""
        # Ta implementacja zależy od konkretnych narzędzi
        # W tym przykładzie zwrócimy oryginalne parametry
        return params

# Przykład użycia
async def get_weather(workflow, location):
    return await workflow.execute_with_fallback(
        "premiumWeatherService",  # Główne (płatne) API pogodowe
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
            
            // Zapisz wynik każdego przepływu pracy
            results[workflow.Name] = workflowResult;
            
            // Zaktualizuj kontekst wynikiem dla kolejnego przepływu pracy
            context = context.WithResult(workflow.Name, workflowResult);
        }
        
        return new WorkflowResult(results);
    }
    
    public string Name => "CompositeWorkflow";
    public string Description => "Wykonuje wiele przepływów pracy w kolejności";
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
    
    // Działanie
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
    
    # Działanie
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
    
    // Działanie
    var response = await server.ProcessRequestAsync(request);
    
    // Sprawdzenie
    Assert.NotNull(response);
    Assert.Equal(McpStatusCodes.Success, response.StatusCode);
    // Dodatkowe sprawdzenia dla zawartości odpowiedzi
    
    // Czyszczenie
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
  
  test('Klient może wywołać narzędzie kalkulatora i otrzymać poprawny wynik', async () => {
    // Działanie
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
// Przykład w C# z Moq
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
    # Kontynuacja testu
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
// Skrypt k6 do testowania obciążenia serwera MCP
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
    
    // Działanie
    var response = await client.GetAsync("http://localhost:5000/api/resources");
    var content = await response.Content.ReadAsStringAsync();
    var resources = JsonSerializer.Deserialize

# Testowanie MCP Server: Najlepsze Praktyki

## Wprowadzenie

Testowanie MCP Server wymaga kompleksowego podejścia, które obejmuje testy jednostkowe, integracyjne i end-to-end. W tym przewodniku omówimy kluczowe zasady, wskazówki i pułapki, które pomogą Ci stworzyć niezawodne i wydajne serwery MCP.

## Przykład Testu

```csharp
// Arrange
var request = new HttpRequestMessage(HttpMethod.Get, "/api/resources");
request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

// Act
var response = await client.SendAsync(request);
var content = await response.Content.ReadAsStringAsync();
var resources = JsonConvert.DeserializeObject<ResourceResponse>(content);

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

## 10 Najlepszych Wskazówek Dotyczących Testowania MCP Server

1. **Testuj definicje narzędzi osobno**: Zweryfikuj definicje schematów niezależnie od logiki narzędzi.
2. **Używaj testów parametryzowanych**: Testuj narzędzia z różnorodnymi danymi wejściowymi, w tym przypadkami brzegowymi.
3. **Sprawdzaj odpowiedzi błędów**: Zweryfikuj poprawne obsługiwanie wszystkich możliwych warunków błędów.
4. **Testuj logikę autoryzacji**: Upewnij się, że kontrola dostępu działa poprawnie dla różnych ról użytkowników.
5. **Monitoruj pokrycie testów**: Dąż do wysokiego pokrycia kodu krytycznego.
6. **Testuj odpowiedzi strumieniowe**: Zweryfikuj poprawne obsługiwanie treści strumieniowych.
7. **Symuluj problemy z siecią**: Przetestuj zachowanie w warunkach słabej jakości sieci.
8. **Testuj limity zasobów**: Zweryfikuj zachowanie przy osiąganiu limitów kwot lub szybkości.
9. **Automatyzuj testy regresji**: Stwórz zestaw testów uruchamianych przy każdej zmianie kodu.
10. **Dokumentuj przypadki testowe**: Utrzymuj jasną dokumentację scenariuszy testowych.

## Typowe Pułapki w Testowaniu

- **Zbyt duże poleganie na testach "happy path"**: Upewnij się, że dokładnie testujesz przypadki błędów.
- **Ignorowanie testów wydajnościowych**: Zidentyfikuj wąskie gardła, zanim wpłyną na produkcję.
- **Testowanie tylko w izolacji**: Łącz testy jednostkowe, integracyjne i end-to-end.
- **Niepełne pokrycie API**: Upewnij się, że wszystkie endpointy i funkcje są testowane.
- **Niespójne środowiska testowe**: Używaj kontenerów, aby zapewnić spójność środowisk testowych.

## Podsumowanie

Kompleksowa strategia testowania jest kluczowa dla tworzenia niezawodnych i wysokiej jakości serwerów MCP. Wdrażając najlepsze praktyki i wskazówki opisane w tym przewodniku, możesz zapewnić, że Twoje implementacje MCP spełniają najwyższe standardy jakości, niezawodności i wydajności.

## Kluczowe Wnioski

1. **Projektowanie narzędzi**: Stosuj zasadę pojedynczej odpowiedzialności, używaj wstrzykiwania zależności i projektuj z myślą o kompozycji.
2. **Projektowanie schematów**: Twórz jasne, dobrze udokumentowane schematy z odpowiednimi ograniczeniami walidacyjnymi.
3. **Obsługa błędów**: Wdrażaj łagodną obsługę błędów, strukturalne odpowiedzi błędów i logikę ponawiania.
4. **Wydajność**: Używaj pamięci podręcznej, przetwarzania asynchronicznego i ograniczania zasobów.
5. **Bezpieczeństwo**: Stosuj dokładną walidację danych wejściowych, kontrole autoryzacji i odpowiednie przetwarzanie danych wrażliwych.
6. **Testowanie**: Twórz kompleksowe testy jednostkowe, integracyjne i end-to-end.
7. **Wzorce przepływu pracy**: Stosuj sprawdzone wzorce, takie jak łańcuchy, dyspozytory i przetwarzanie równoległe.

## Ćwiczenie

Zaprojektuj narzędzie MCP i przepływ pracy dla systemu przetwarzania dokumentów, który:

1. Akceptuje dokumenty w różnych formatach (PDF, DOCX, TXT).
2. Wyodrębnia tekst i kluczowe informacje z dokumentów.
3. Klasyfikuje dokumenty według typu i treści.
4. Generuje podsumowanie każdego dokumentu.

Zaimplementuj schematy narzędzi, obsługę błędów i wzorzec przepływu pracy, który najlepiej pasuje do tego scenariusza. Rozważ, jak przetestowałbyś tę implementację.

## Zasoby

1. Dołącz do społeczności MCP na [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs), aby być na bieżąco z najnowszymi wydarzeniami.
2. Współtwórz projekty open-source [MCP](https://github.com/modelcontextprotocol).
3. Stosuj zasady MCP w inicjatywach AI swojej organizacji.
4. Eksploruj specjalistyczne implementacje MCP dla swojej branży.
5. Rozważ udział w zaawansowanych kursach na temat specyficznych tematów MCP, takich jak integracja multimodalna lub integracja aplikacji korporacyjnych.
6. Eksperymentuj z budowaniem własnych narzędzi i przepływów pracy MCP, korzystając z zasad poznanych w [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md).

Dalej: Najlepsze praktyki [studia przypadków](../09-CaseStudy/README.md)

**Zastrzeżenie**:  
Ten dokument został przetłumaczony za pomocą usługi tłumaczeniowej AI [Co-op Translator](https://github.com/Azure/co-op-translator). Chociaż dokładamy wszelkich starań, aby zapewnić dokładność, prosimy pamiętać, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w jego rodzimym języku powinien być uznawany za wiarygodne źródło. W przypadku informacji krytycznych zaleca się skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.