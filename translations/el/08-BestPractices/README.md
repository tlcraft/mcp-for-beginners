<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "80e5c8949af5af0f401fce6f905990aa",
  "translation_date": "2025-07-17T05:38:51+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "el"
}
-->
# Καλύτερες Πρακτικές Ανάπτυξης MCP

## Επισκόπηση

Αυτό το μάθημα εστιάζει σε προχωρημένες βέλτιστες πρακτικές για την ανάπτυξη, τον έλεγχο και την ανάπτυξη MCP servers και λειτουργιών σε παραγωγικά περιβάλλοντα. Καθώς τα οικοσυστήματα MCP γίνονται πιο πολύπλοκα και σημαντικά, η τήρηση καθιερωμένων προτύπων εξασφαλίζει αξιοπιστία, ευκολία συντήρησης και διαλειτουργικότητα. Το μάθημα αυτό συγκεντρώνει πρακτική γνώση από πραγματικές υλοποιήσεις MCP για να σας καθοδηγήσει στη δημιουργία στιβαρών, αποδοτικών servers με αποτελεσματικούς πόρους, προτροπές και εργαλεία.

## Στόχοι Μάθησης

Στο τέλος αυτού του μαθήματος, θα μπορείτε να:
- Εφαρμόζετε βέλτιστες πρακτικές της βιομηχανίας στο σχεδιασμό MCP servers και λειτουργιών
- Δημιουργείτε ολοκληρωμένες στρατηγικές δοκιμών για MCP servers
- Σχεδιάζετε αποδοτικά, επαναχρησιμοποιήσιμα πρότυπα ροής εργασίας για σύνθετες εφαρμογές MCP
- Υλοποιείτε σωστή διαχείριση σφαλμάτων, καταγραφή και παρατηρησιμότητα σε MCP servers
- Βελτιστοποιείτε τις υλοποιήσεις MCP για απόδοση, ασφάλεια και ευκολία συντήρησης

## Βασικές Αρχές MCP

Πριν εμβαθύνετε σε συγκεκριμένες πρακτικές υλοποίησης, είναι σημαντικό να κατανοήσετε τις βασικές αρχές που καθοδηγούν την αποτελεσματική ανάπτυξη MCP:

1. **Τυποποιημένη Επικοινωνία**: Το MCP βασίζεται στο JSON-RPC 2.0, παρέχοντας ένα συνεπές φορμάτ για αιτήματα, απαντήσεις και διαχείριση σφαλμάτων σε όλες τις υλοποιήσεις.

2. **Σχεδιασμός με επίκεντρο τον χρήστη**: Πάντα να δίνετε προτεραιότητα στη συγκατάθεση, τον έλεγχο και τη διαφάνεια προς τον χρήστη στις υλοποιήσεις MCP.

3. **Ασφάλεια Πρώτα**: Εφαρμόστε ισχυρά μέτρα ασφαλείας, όπως αυθεντικοποίηση, εξουσιοδότηση, επικύρωση και περιορισμό ρυθμού.

4. **Μοντέρνα Αρχιτεκτονική**: Σχεδιάστε τους MCP servers με modular προσέγγιση, όπου κάθε εργαλείο και πόρος έχει σαφή και εστιασμένο σκοπό.

5. **Κατάσταση Συνδέσεων**: Εκμεταλλευτείτε την ικανότητα του MCP να διατηρεί κατάσταση ανάμεσα σε πολλαπλά αιτήματα για πιο συνεκτικές και με επίγνωση συμφραζομένων αλληλεπιδράσεις.

## Επίσημες Βέλτιστες Πρακτικές MCP

Οι παρακάτω βέλτιστες πρακτικές προέρχονται από την επίσημη τεκμηρίωση του Model Context Protocol:

### Βέλτιστες Πρακτικές Ασφαλείας

1. **Συγκατάθεση και Έλεγχος Χρήστη**: Πάντα απαιτείτε ρητή συγκατάθεση του χρήστη πριν από την πρόσβαση σε δεδομένα ή την εκτέλεση λειτουργιών. Παρέχετε σαφή έλεγχο για το ποια δεδομένα κοινοποιούνται και ποιες ενέργειες επιτρέπονται.

2. **Απόρρητο Δεδομένων**: Εκθέτετε δεδομένα χρήστη μόνο με ρητή συγκατάθεση και τα προστατεύετε με κατάλληλους ελέγχους πρόσβασης. Προστατέψτε από μη εξουσιοδοτημένη μετάδοση δεδομένων.

3. **Ασφάλεια Εργαλείων**: Απαιτείτε ρητή συγκατάθεση πριν την κλήση οποιουδήποτε εργαλείου. Διασφαλίστε ότι οι χρήστες κατανοούν τη λειτουργία κάθε εργαλείου και επιβάλετε ισχυρά όρια ασφαλείας.

4. **Έλεγχος Δικαιωμάτων Εργαλείων**: Ρυθμίστε ποια εργαλεία επιτρέπεται να χρησιμοποιεί ένα μοντέλο κατά τη διάρκεια μιας συνεδρίας, εξασφαλίζοντας πρόσβαση μόνο σε ρητά εξουσιοδοτημένα εργαλεία.

5. **Αυθεντικοποίηση**: Απαιτείστε σωστή αυθεντικοποίηση πριν την παροχή πρόσβασης σε εργαλεία, πόρους ή ευαίσθητες λειτουργίες, χρησιμοποιώντας API keys, OAuth tokens ή άλλες ασφαλείς μεθόδους.

6. **Επικύρωση Παραμέτρων**: Εφαρμόστε επικύρωση για όλες τις κλήσεις εργαλείων ώστε να αποτρέψετε κακόβουλη ή λανθασμένη είσοδο που θα φτάσει στις υλοποιήσεις εργαλείων.

7. **Περιορισμός Ρυθμού**: Υλοποιήστε περιορισμό ρυθμού για να αποτρέψετε κατάχρηση και να εξασφαλίσετε δίκαιη χρήση των πόρων του server.

### Βέλτιστες Πρακτικές Υλοποίησης

1. **Διαπραγμάτευση Δυνατοτήτων**: Κατά τη σύνδεση, ανταλλάξτε πληροφορίες για υποστηριζόμενες λειτουργίες, εκδόσεις πρωτοκόλλου, διαθέσιμα εργαλεία και πόρους.

2. **Σχεδιασμός Εργαλείων**: Δημιουργήστε εστιασμένα εργαλεία που κάνουν καλά ένα πράγμα, αντί για μονολιθικά εργαλεία που διαχειρίζονται πολλαπλές ανησυχίες.

3. **Διαχείριση Σφαλμάτων**: Υλοποιήστε τυποποιημένα μηνύματα και κωδικούς σφαλμάτων για να βοηθήσετε στη διάγνωση προβλημάτων, να χειριστείτε αποτυχίες ομαλά και να παρέχετε χρήσιμα σχόλια.

4. **Καταγραφή**: Ρυθμίστε δομημένα logs για έλεγχο, αποσφαλμάτωση και παρακολούθηση των αλληλεπιδράσεων του πρωτοκόλλου.

5. **Παρακολούθηση Προόδου**: Για λειτουργίες μεγάλης διάρκειας, αναφέρετε ενημερώσεις προόδου ώστε να υποστηρίζονται ευέλικτα περιβάλλοντα χρήστη.

6. **Ακύρωση Αιτημάτων**: Επιτρέψτε στους πελάτες να ακυρώνουν αιτήματα που βρίσκονται σε εξέλιξη και δεν χρειάζονται πλέον ή καθυστερούν υπερβολικά.

## Πρόσθετες Αναφορές

Για τις πιο ενημερωμένες πληροφορίες σχετικά με τις βέλτιστες πρακτικές MCP, ανατρέξτε σε:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)
- [Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## Παραδείγματα Πρακτικής Υλοποίησης

### Βέλτιστες Πρακτικές Σχεδιασμού Εργαλείων

#### 1. Αρχή Μοναδικής Ευθύνης

Κάθε εργαλείο MCP πρέπει να έχει σαφή και εστιασμένο σκοπό. Αντί να δημιουργείτε μονολιθικά εργαλεία που προσπαθούν να καλύψουν πολλαπλές λειτουργίες, αναπτύξτε εξειδικευμένα εργαλεία που διαπρέπουν σε συγκεκριμένες εργασίες.

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

#### 2. Συνεπής Διαχείριση Σφαλμάτων

Υλοποιήστε ισχυρή διαχείριση σφαλμάτων με ενημερωτικά μηνύματα και κατάλληλους μηχανισμούς ανάκτησης.

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

#### 3. Επικύρωση Παραμέτρων

Πάντα επικυρώνετε διεξοδικά τις παραμέτρους για να αποτρέψετε κακόβουλη ή λανθασμένη είσοδο.

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

### Παραδείγματα Υλοποίησης Ασφαλείας

#### 1. Αυθεντικοποίηση και Εξουσιοδότηση

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

#### 2. Περιορισμός Ρυθμού

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

## Βέλτιστες Πρακτικές Δοκιμών

### 1. Μονάδες Δοκιμών Εργαλείων MCP

Πάντα δοκιμάζετε τα εργαλεία σας απομονωμένα, χρησιμοποιώντας mocks για εξωτερικές εξαρτήσεις:

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

### 2. Ολοκληρωμένες Δοκιμές

Δοκιμάστε ολόκληρη τη ροή από τα αιτήματα του πελάτη μέχρι τις απαντήσεις του server:

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

## Βελτιστοποίηση Απόδοσης

### 1. Στρατηγικές Caching

Υλοποιήστε κατάλληλο caching για να μειώσετε την καθυστέρηση και τη χρήση πόρων:

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
// Παράδειγμα Java με dependency injection
public class CurrencyConversionTool implements Tool {
    private final ExchangeRateService exchangeService;
    private final CacheService cacheService;
    private final Logger logger;
    
    // Εξαρτήσεις που εισάγονται μέσω constructor
    public CurrencyConversionTool(
            ExchangeRateService exchangeService,
            CacheService cacheService,
            Logger logger) {
        this.exchangeService = exchangeService;
        this.cacheService = cacheService;
        this.logger = logger;
    }
    
    // Υλοποίηση εργαλείου
    // ...
}
```

#### 3. Composable Tools

Design tools that can be composed together to create more complex workflows:

```python
# Παράδειγμα Python που δείχνει συνθέσιμα εργαλεία
class DataFetchTool(Tool):
    def get_name(self):
        return "dataFetch"
    
    # Υλοποίηση...

class DataAnalysisTool(Tool):
    def get_name(self):
        return "dataAnalysis"
    
    # Αυτό το εργαλείο μπορεί να χρησιμοποιεί αποτελέσματα από το dataFetch
    async def execute_async(self, request):
        # Υλοποίηση...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # Αυτό το εργαλείο μπορεί να χρησιμοποιεί αποτελέσματα από το dataAnalysis
    async def execute_async(self, request):
        # Υλοποίηση...
        pass

# Αυτά τα εργαλεία μπορούν να χρησιμοποιηθούν ανεξάρτητα ή ως μέρος ροής εργασίας
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
                description = "Κείμενο αναζήτησης. Χρησιμοποιήστε ακριβείς λέξεις-κλειδιά για καλύτερα αποτελέσματα." 
            },
            filters = new {
                type = "object",
                description = "Προαιρετικά φίλτρα για περιορισμό των αποτελεσμάτων αναζήτησης",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "Εύρος ημερομηνιών σε μορφή YYYY-MM-DD:YYYY-MM-DD" 
                    },
                    category = new { 
                        type = "string", 
                        description = "Όνομα κατηγορίας για φιλτράρισμα" 
                    }
                }
            },
            limit = new { 
                type = "integer", 
                description = "Μέγιστος αριθμός αποτελεσμάτων προς επιστροφή (1-50)",
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
    
    // Ιδιότητα email με επικύρωση μορφής
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "Διεύθυνση email χρήστη");
    
    // Ιδιότητα ηλικίας με αριθμητικούς περιορισμούς
    Map<String, Object> age = new HashMap<>();
    age.put("type", "integer");
    age.put("minimum", 13);
    age.put("maximum", 120);
    age.put("description", "Ηλικία χρήστη σε έτη");
    
    // Ιδιότητα με προκαθορισμένες τιμές
    Map<String, Object> subscription = new HashMap<>();
    subscription.put("type", "string");
    subscription.put("enum", Arrays.asList("free", "basic", "premium"));
    subscription.put("default", "free");
    subscription.put("description", "Επίπεδο συνδρομής");
    
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
        # Επεξεργασία αιτήματος
        results = await self._search_database(request.parameters["query"])
        
        # Επιστροφή πάντα συνεπούς δομής
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
    """Εξασφαλίζει ότι κάθε στοιχείο έχει συνεπή δομή"""
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
            throw new ToolExecutionException($"Το αρχείο δεν βρέθηκε: {fileId}");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ToolExecutionException("Δεν έχετε δικαίωμα πρόσβασης σε αυτό το αρχείο");
        }
        catch (Exception ex) when (ex is IOException || ex is TimeoutException)
        {
            _logger.LogError(ex, "Σφάλμα κατά την πρόσβαση στο αρχείο {FileId}", fileId);
            throw new ToolExecutionException("Σφάλμα πρόσβασης αρχείου: Η υπηρεσία είναι προσωρινά μη διαθέσιμη");
        }
    }
    catch (JsonException)
    {
        throw new ToolExecutionException("Μη έγκυρη μορφή αναγνωριστικού αρχείου");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Απρόβλεπτο σφάλμα στο FileAccessTool");
        throw new ToolExecutionException("Παρουσιάστηκε απρόβλεπτο σφάλμα");
    }
}
```

#### 2. Structured Error Responses

Return structured error information when possible:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    try {
        // Υλοποίηση
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
        
        // Επαναρίψη άλλων εξαιρέσεων ως ToolExecutionException
        throw new ToolExecutionException("Η εκτέλεση του εργαλείου απέτυχε: " + ex.getMessage(), ex);
    }
}
```

#### 3. Retry Logic

Implement appropriate retry logic for transient failures:

```python
async def execute_async(self, request):
    max_retries = 3
    retry_count = 0
    base_delay = 1  # δευτερόλεπτα
    
    while retry_count < max_retries:
        try:
            # Κλήση εξωτερικού API
            return await self._call_api(request.parameters)
        except TransientError as e:
            retry_count += 1
            if retry_count >= max_retries:
                raise ToolExecutionException(f"Η λειτουργία απέτυχε μετά από {max_retries} προσπάθειες: {str(e)}")
                
            # Εκθετική καθυστέρηση
            delay = base_delay * (2 ** (retry_count - 1))
            logging.warning(f"Προσωρινό σφάλμα, επανάληψη σε {delay}s: {str(e)}")
            await asyncio.sleep(delay)
        except Exception as e:
            # Μη προσωρινό σφάλμα, δεν επαναλαμβάνουμε
            raise ToolExecutionException(f"Η λειτουργία απέτυχε: {str(e)}")
```

### Performance Optimization

#### 1. Caching

Implement caching for expensive operations:

```csharp
public class CachedDataTool : IMcpTool
{
    private readonly IDatabase _database;
    private readonly IMemoryCache _cache;
    
    public CachedDataTool(IDatabase database,

ExecuteAsync(ToolRequest request)
    {
        var query = request.Parameters.GetProperty("query").GetString();
        
        // Δημιουργία κλειδιού cache βάσει των παραμέτρων
        var cacheKey = $"data_query_{ComputeHash(query)}";
        
        // Προσπάθεια ανάκτησης από cache πρώτα
        if (_cache.TryGetValue(cacheKey, out var cachedResult))
        {
            return new ToolResponse { Result = cachedResult };
        }
        
        // Cache miss - εκτέλεση πραγματικού ερωτήματος
        var result = await _database.QueryAsync(query);
        
        // Αποθήκευση στην cache με χρόνο λήξης
        var cacheOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
            
        _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
        
        return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
    }
    
    private string ComputeHash(string input)
    {
        // Υλοποίηση για δημιουργία σταθερού hash για το κλειδί cache
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
        
        // Για εργασίες μεγάλης διάρκειας, επιστρέφουμε άμεσα ένα ID επεξεργασίας
        String processId = UUID.randomUUID().toString();
        
        // Ξεκινάμε ασύγχρονη επεξεργασία
        CompletableFuture.runAsync(() -> {
            try {
                // Εκτέλεση εργασίας μεγάλης διάρκειας
                documentService.processDocument(documentId);
                
                // Ενημέρωση κατάστασης (συνήθως αποθηκεύεται σε βάση δεδομένων)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // Επιστροφή άμεσης απάντησης με το ID της διαδικασίας
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // Συνοδευτικό εργαλείο για έλεγχο κατάστασης
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
            tokens_per_second=5,  # Επιτρέπονται 5 αιτήματα ανά δευτερόλεπτο
            bucket_size=10        # Επιτρέπονται εκρήξεις έως 10 αιτήματα
        )
    
    async def execute_async(self, request):
        # Έλεγχος αν μπορούμε να προχωρήσουμε ή πρέπει να περιμένουμε
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # Αν η αναμονή είναι πολύ μεγάλη
                raise ToolExecutionException(
                    f"Το όριο ρυθμού ξεπεράστηκε. Παρακαλώ δοκιμάστε ξανά σε {delay:.1f} δευτερόλεπτα."
                )
            else:
                # Περιμένουμε τον κατάλληλο χρόνο καθυστέρησης
                await asyncio.sleep(delay)
        
        # Καταναλώνουμε ένα token και προχωράμε με το αίτημα
        self.rate_limiter.consume()
        
        # Κλήση API
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
            
            # Υπολογισμός χρόνου μέχρι να είναι διαθέσιμο το επόμενο token
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # Προσθήκη νέων tokens βάσει του χρόνου που πέρασε
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
    // Επαλήθευση ύπαρξης παραμέτρων
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("Λείπει η απαιτούμενη παράμετρος: query");
    }
    
    // Επαλήθευση σωστού τύπου
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("Η παράμετρος query πρέπει να είναι συμβολοσειρά");
    }
    
    var query = queryProp.GetString();
    
    // Επαλήθευση περιεχομένου συμβολοσειράς
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("Η παράμετρος query δεν μπορεί να είναι κενή");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("Η παράμετρος query υπερβαίνει το μέγιστο μήκος των 500 χαρακτήρων");
    }
    
    // Έλεγχος για επιθέσεις SQL injection αν ισχύει
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("Μη έγκυρο query: περιέχει πιθανώς μη ασφαλές SQL");
    }
    
    // Προχωράμε με την εκτέλεση
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // Λήψη context χρήστη από το αίτημα
    UserContext user = request.getContext().getUserContext();
    
    // Έλεγχος αν ο χρήστης έχει τα απαιτούμενα δικαιώματα
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("Ο χρήστης δεν έχει δικαίωμα πρόσβασης στα έγγραφα");
    }
    
    // Για συγκεκριμένους πόρους, έλεγχος πρόσβασης σε αυτόν τον πόρο
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("Άρνηση πρόσβασης στο ζητούμενο έγγραφο");
    }
    
    // Προχωράμε με την εκτέλεση του εργαλείου
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
        
        # Λήψη δεδομένων χρήστη
        user_data = await self.user_service.get_user_data(user_id)
        
        # Φιλτράρισμα ευαίσθητων πεδίων εκτός αν ζητηθεί ρητά ΚΑΙ υπάρχει εξουσιοδότηση
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # Έλεγχος επιπέδου εξουσιοδότησης στο context του αιτήματος
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # Δημιουργία αντιγράφου για να μην τροποποιηθεί το αρχικό
        redacted = user_data.copy()
        
        # Απόκρυψη συγκεκριμένων ευαίσθητων πεδίων
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # Απόκρυψη εμφωλευμένων ευαίσθητων δεδομένων
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
    // Προετοιμασία
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("Seattle", 3))
        .ReturnsAsync(new WeatherForecast(/* test data */));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "Seattle", 
            days = 3 
        })
    );
    
    // Εκτέλεση
    var response = await tool.ExecuteAsync(request);
    
    // Έλεγχος
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // Προετοιμασία
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
    
    // Εκτέλεση & Έλεγχος
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
    // Δημιουργία instance εργαλείου
    SearchTool searchTool = new SearchTool();
    
    // Λήψη schema
    Object schema = searchTool.getSchema();
    
    // Μετατροπή schema σε JSON για επικύρωση
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // Επικύρωση schema ως έγκυρο JSONSchema
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // Δοκιμή έγκυρων παραμέτρων
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // Δοκιμή έλλειψης απαιτούμενης παραμέτρου
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // Δοκιμή μη έγκυρου τύπου παραμέτρου
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
    # Προετοιμασία
    tool = ApiTool(timeout=0.1)  # Πολύ μικρό timeout
    
    # Mock ενός αιτήματος που θα υπερβεί το timeout
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # Μεγαλύτερο από το timeout
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # Εκτέλεση & Έλεγχος
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Έλεγχος μηνύματος εξαίρεσης
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # Προετοιμασία
    tool = ApiTool()
    
    # Mock απάντησης με περιορισμό ρυθμού
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
        
        # Εκτέλεση & Έλεγχος
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Έλεγχος ότι η εξαίρεση περιέχει πληροφορίες για το όριο ρυθμού
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
    // Προετοιμασία
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // Εκτέλεση
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

// Επιβεβαίωση
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
        // Δοκιμή του endpoint ανακάλυψης εργαλείων
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // Δημιουργία αιτήματος εργαλείου
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // Αποστολή αιτήματος και επαλήθευση απάντησης
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // Δημιουργία μη έγκυρου αιτήματος εργαλείου
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // Λείπει η παράμετρος "b"
        request.put("parameters", parameters);
        
        // Αποστολή αιτήματος και επαλήθευση απάντησης λάθους
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
    # Προετοιμασία - Ρύθμιση πελάτη MCP και mock μοντέλου
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # Mock απαντήσεις μοντέλου
    mock_model = MockLanguageModel([
        MockResponse(
            "Ποιος είναι ο καιρός στο Σιάτλ;",
            tool_calls=[{
                "tool_name": "weatherForecast",
                "parameters": {"location": "Seattle", "days": 3}
            }]
        ),
        MockResponse(
            "Αυτή είναι η πρόγνωση καιρού για το Σιάτλ:\n- Σήμερα: 65°F, Μερικώς Συννεφιασμένος\n- Αύριο: 68°F, Ηλιόλουστος\n- Μεθαύριο: 62°F, Βροχή",
            tool_calls=[]
        )
    ])
    
    # Mock απάντηση εργαλείου καιρού
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
        
        # Εκτέλεση
        response = await mcp_client.send_prompt(
            "Ποιος είναι ο καιρός στο Σιάτλ;",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # Επιβεβαίωση
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
    // Προετοιμασία
    var server = new McpServer(
        name: "TestServer",
        version: "1.0",
        maxConcurrentRequests: 100
    );
    
    server.RegisterTool(new FastExecutingTool());
    await server.StartAsync();
    
    var client = new McpClient("http://localhost:5000");
    
    // Εκτέλεση
    var tasks = new List<Task<McpResponse>>();
    for (int i = 0; i < 1000; i++)
    {
        tasks.Add(client.ExecuteToolAsync("fastTool", new { iteration = i }));
    }
    
    var results = await Task.WhenAll(tasks);
    
    // Επιβεβαίωση
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
    
    // Ρύθμιση JMeter για δοκιμή φόρτου
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // Διαμόρφωση σχεδίου δοκιμής JMeter
    HashTree testPlanTree = new HashTree();
    
    // Δημιουργία σχεδίου δοκιμής, ομάδας νημάτων, δεικτών κλπ.
    TestPlan testPlan = new TestPlan("MCP Server Stress Test");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // Προσθήκη HTTP sampler για εκτέλεση εργαλείου
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // Προσθήκη ακροατών
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // Εκτέλεση δοκιμής
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // Επαλήθευση αποτελεσμάτων
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // Μέσος χρόνος απόκρισης < 200ms
    assertTrue(summaryReport.getPercentile(90.0) < 500); // 90ο εκατοστημόριο < 500ms
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# Ρύθμιση παρακολούθησης για έναν MCP server
def configure_monitoring(server):
    # Ρύθμιση μετρικών Prometheus
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "Συνολικές αιτήσεις MCP"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "Διάρκεια αιτήσεων σε δευτερόλεπτα",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "Αριθμός εκτελέσεων εργαλείων",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "Διάρκεια εκτέλεσης εργαλείων σε δευτερόλεπτα",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "Σφάλματα εκτέλεσης εργαλείων",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # Προσθήκη middleware για μέτρηση χρόνου και καταγραφή μετρικών
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # Έκθεση endpoint μετρικών
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
# Υλοποίηση αλυσίδας εργαλείων σε Python
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # Λίστα με ονόματα εργαλείων προς εκτέλεση διαδοχικά
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # Εκτέλεση κάθε εργαλείου στην αλυσίδα, περνώντας το προηγούμενο αποτέλεσμα
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # Αποθήκευση αποτελέσματος και χρήση ως είσοδο για το επόμενο εργαλείο
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# Παράδειγμα χρήσης
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
    public string Description => "Επεξεργάζεται περιεχόμενο διαφόρων τύπων";
    
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
        
        // Καθορισμός ποιο εξειδικευμένο εργαλείο θα χρησιμοποιηθεί
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // Προώθηση στο εξειδικευμένο εργαλείο
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

Αυτό το εργαλείο επιτρέπει την εύκολη επεξεργασία αρχείων CSV με διάφορες λειτουργίες.

## Χαρακτηριστικά

- Φόρτωση και ανάλυση αρχείων CSV
- Φιλτράρισμα δεδομένων βάσει κριτηρίων
- Εξαγωγή των επεξεργασμένων δεδομένων σε νέο αρχείο CSV
- Υποστήριξη για αρχεία με διαφορετικά διαχωριστικά

## Παραδείγματα χρήσης

```python
# Φόρτωση αρχείου CSV
data = csvProcessor.load('@@INLINE_CODE_1@@')

# Φιλτράρισμα γραμμών όπου η τιμή στη στήλη 'age' είναι μεγαλύτερη από 30
filtered_data = csvProcessor.filter(data, column='age', condition='>30')

# Εξαγωγή των φιλτραρισμένων δεδομένων
csvProcessor.export(filtered_data, 'filtered_output.csv')
```

## Σημαντικές Σημειώσεις

[!NOTE] Βεβαιωθείτε ότι το αρχείο CSV έχει σωστή μορφοποίηση πριν το φορτώσετε.

[!WARNING] Η λειτουργία φιλτραρίσματος δεν υποστηρίζει σύνθετες εκφράσεις.

[!TIP] Χρησιμοποιήστε τη μέθοδο `preview()` για να δείτε τα πρώτα 5 αρχεία πριν την εξαγωγή.

## Συχνές Ερωτήσεις

**Πώς μπορώ να αλλάξω το διαχωριστικό πεδίων;**

Μπορείτε να ορίσετε το διαχωριστικό κατά τη φόρτωση του αρχείου:

```python
data = csvProcessor.load('@@INLINE_CODE_2@@', delimiter=';')
```

**Τι μορφές αρχείων υποστηρίζονται;**

Το εργαλείο υποστηρίζει μόνο αρχεία CSV με κωδικοποίηση UTF-8.

## Υποστήριξη

Για περισσότερη βοήθεια, επισκεφθείτε την επίσημη σελίδα τεκμηρίωσης ή επικοινωνήστε με την ομάδα υποστήριξης.
("code", _) => "codeAnalyzer",
_ => throw new ToolExecutionException($"Δεν υπάρχει διαθέσιμο εργαλείο για {contentType}/{operation}")
};
}

private object GetOptionsForTool(string toolName, string operation)
{
// Επιστρέφει τις κατάλληλες επιλογές για κάθε εξειδικευμένο εργαλείο
return toolName switch
{
    "textSummarizer" => new { length = "medium" },
    "htmlProcessor" => new { cleanUp = true, operation },
    // Επιλογές για άλλα εργαλεία...
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
        // Βήμα 1: Ανάκτηση μεταδεδομένων συνόλου δεδομένων (συγχρονισμένα)
        ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata", 
            Map.of("datasetId", datasetId));
        
        // Βήμα 2: Εκκίνηση πολλαπλών αναλύσεων παράλληλα
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
        
        // Αναμονή για την ολοκλήρωση όλων των παράλληλων εργασιών
        CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
            statisticalAnalysis, correlationAnalysis, outlierDetection
        );
        
        allAnalyses.join();  // Αναμονή για ολοκλήρωση
        
        // Βήμα 3: Συνδυασμός αποτελεσμάτων
        Map<String, Object> combinedResults = new HashMap<>();
        combinedResults.put("metadata", metadataResponse.getResult());
        combinedResults.put("statistics", statisticalAnalysis.join().getResult());
        combinedResults.put("correlations", correlationAnalysis.join().getResult());
        combinedResults.put("outliers", outlierDetection.join().getResult());
        
        // Βήμα 4: Δημιουργία συνοπτικής αναφοράς
        ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator", 
            Map.of("analysisResults", combinedResults));
        
        // Επιστροφή ολοκληρωμένου αποτελέσματος ροής εργασίας
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
            # Προσπάθεια με το κύριο εργαλείο πρώτα
            response = await self.client.execute_tool(primary_tool, parameters)
            return {
                "result": response.result,
                "source": "primary",
                "tool": primary_tool
            }
        except ToolExecutionException as e:
            # Καταγραφή αποτυχίας
            logging.warning(f"Το κύριο εργαλείο '{primary_tool}' απέτυχε: {str(e)}")
            
            # Εναλλακτική χρήση δευτερεύοντος εργαλείου
            try:
                # Ίσως χρειαστεί προσαρμογή παραμέτρων για το εφεδρικό εργαλείο
                fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)
                
                response = await self.client.execute_tool(fallback_tool, fallback_params)
                return {
                    "result": response.result,
                    "source": "fallback",
                    "tool": fallback_tool,
                    "primaryError": str(e)
                }
            except ToolExecutionException as fallback_error:
                # Απέτυχαν και τα δύο εργαλεία
                logging.error(f"Απέτυχαν και τα δύο εργαλεία. Σφάλμα εφεδρείας: {str(fallback_error)}")
                raise WorkflowExecutionException(
                    f"Η ροή εργασίας απέτυχε: σφάλμα κύριου εργαλείου: {str(e)}; σφάλμα εφεδρείας: {str(fallback_error)}"
                )
    
    def _adapt_parameters(self, params, from_tool, to_tool):
        """Προσαρμογή παραμέτρων μεταξύ διαφορετικών εργαλείων αν χρειάζεται"""
        # Η υλοποίηση εξαρτάται από τα συγκεκριμένα εργαλεία
        # Σε αυτό το παράδειγμα, απλά επιστρέφουμε τις αρχικές παραμέτρους
        return params

# Παράδειγμα χρήσης
async def get_weather(workflow, location):
    return await workflow.execute_with_fallback(
        "premiumWeatherService",  # Κύριο (επί πληρωμή) API καιρού
        "basicWeatherService",    # Εφεδρικό (δωρεάν) API καιρού
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
            
            // Αποθήκευση του αποτελέσματος κάθε ροής εργασίας
            results[workflow.Name] = workflowResult;
            
            // Ενημέρωση του context με το αποτέλεσμα για την επόμενη ροή εργασίας
            context = context.WithResult(workflow.Name, workflowResult);
        }
        
        return new WorkflowResult(results);
    }
    
    public string Name => "CompositeWorkflow";
    public string Description => "Εκτελεί πολλαπλές ροές εργασίας διαδοχικά";
}

// Παράδειγμα χρήσης
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
// Παράδειγμα unit test για εργαλείο αριθμομηχανής σε C#
[Fact]
public async Task CalculatorTool_Add_ReturnsCorrectSum()
{
    // Προετοιμασία
    var calculator = new CalculatorTool();
    var parameters = new Dictionary<string, object>
    {
        ["operation"] = "add",
        ["a"] = 5,
        ["b"] = 7
    };
    
    // Εκτέλεση
    var response = await calculator.ExecuteAsync(parameters);
    var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());
    
    // Έλεγχος
    Assert.Equal(12, result.Value);
}
```

```python
# Παράδειγμα unit test για εργαλείο αριθμομηχανής σε Python
def test_calculator_tool_add():
    # Προετοιμασία
    calculator = CalculatorTool()
    parameters = {
        "operation": "add",
        "a": 5,
        "b": 7
    }
    
    # Εκτέλεση
    response = calculator.execute(parameters)
    result = json.loads(response.content[0].text)
    
    # Έλεγχος
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
// Παράδειγμα integration test για MCP server σε C#
[Fact]
public async Task Server_ProcessToolRequest_ReturnsValidResponse()
{
    // Προετοιμασία
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
    
    // Εκτέλεση
    var response = await server.ProcessRequestAsync(request);
    
    // Έλεγχος
    Assert.NotNull(response);
    Assert.Equal(McpStatusCodes.Success, response.StatusCode);
    // Επιπλέον έλεγχοι για το περιεχόμενο της απόκρισης
    
    // Καθαρισμός
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
// Παράδειγμα E2E test με client σε TypeScript
describe('MCP Server E2E Tests', () => {
  let client: McpClient;
  
  beforeAll(async () => {
    // Εκκίνηση server σε περιβάλλον δοκιμών
    await startTestServer();
    client = new McpClient('http://localhost:5000');
  });
  
  afterAll(async () => {
    await stopTestServer();
  });
  
  test('Ο client μπορεί να καλέσει το εργαλείο αριθμομηχανής και να λάβει σωστό αποτέλεσμα', async () => {
    // Εκτέλεση
    const response = await client.invokeToolAsync('calculator', {
      operation: 'divide',
      a: 20,
      b: 4
    });
    
    // Έλεγχος
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
// Παράδειγμα C# με Moq
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
# Παράδειγμα Python με unittest.mock
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
    # Διαμόρφωση mock
    mock_model.return_value.generate_response.return_value = {
        "text": "Mocked model response",
        "finish_reason": "completed"
    }
    
    # Χρήση mock στο τεστ
    server = McpServer(model_client=mock_model)
    # Συνέχεια με το τεστ
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
// k6 script για δοκιμές φόρτου στον MCP server
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  vus: 10,  // 10 εικονικοί χρήστες
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
    // Προετοιμασία
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");
    
    // Εκτέλεση
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
    // Πρόσθετος έλεγχος σχήματος  
});  
}  
```

## Κορυφαίες 10 Συμβουλές για Αποτελεσματικό Testing MCP Server

1. **Δοκιμάστε ξεχωριστά τους ορισμούς εργαλείων**: Επαληθεύστε τους ορισμούς του σχήματος ανεξάρτητα από τη λογική του εργαλείου  
2. **Χρησιμοποιήστε παραμετροποιημένες δοκιμές**: Δοκιμάστε τα εργαλεία με ποικιλία εισόδων, συμπεριλαμβανομένων ακραίων περιπτώσεων  
3. **Ελέγξτε τις απαντήσεις σφαλμάτων**: Επαληθεύστε τη σωστή διαχείριση σφαλμάτων για όλες τις πιθανές συνθήκες σφάλματος  
4. **Δοκιμάστε τη λογική εξουσιοδότησης**: Βεβαιωθείτε για τον σωστό έλεγχο πρόσβασης ανάλογα με τους ρόλους των χρηστών  
5. **Παρακολουθήστε την κάλυψη των δοκιμών**: Στοχεύστε σε υψηλή κάλυψη του κώδικα κρίσιμων διαδρομών  
6. **Δοκιμάστε απαντήσεις ροής (streaming)**: Επαληθεύστε τη σωστή διαχείριση περιεχομένου ροής  
7. **Προσομοιώστε προβλήματα δικτύου**: Δοκιμάστε τη συμπεριφορά υπό κακές συνθήκες δικτύου  
8. **Δοκιμάστε τα όρια πόρων**: Επαληθεύστε τη συμπεριφορά όταν φτάνετε σε όρια ποσοστώσεων ή ρυθμών  
9. **Αυτοματοποιήστε τις δοκιμές παλινδρόμησης**: Δημιουργήστε ένα σύνολο που εκτελείται σε κάθε αλλαγή κώδικα  
10. **Τεκμηριώστε τις περιπτώσεις δοκιμών**: Διατηρήστε σαφή τεκμηρίωση των σεναρίων δοκιμών  

## Συνηθισμένα Σφάλματα στις Δοκιμές

- **Υπερβολική εξάρτηση από το «ευτυχές μονοπάτι»**: Φροντίστε να δοκιμάζετε διεξοδικά τις περιπτώσεις σφαλμάτων  
- **Παράβλεψη των δοκιμών απόδοσης**: Εντοπίστε τα σημεία συμφόρησης πριν επηρεάσουν την παραγωγή  
- **Δοκιμές μόνο σε απομόνωση**: Συνδυάστε μονάδες, ολοκλήρωση και end-to-end δοκιμές  
- **Ατελής κάλυψη API**: Βεβαιωθείτε ότι όλα τα endpoints και οι λειτουργίες δοκιμάζονται  
- **Ασυνεπή περιβάλλοντα δοκιμών**: Χρησιμοποιήστε containers για να εξασφαλίσετε συνεπή περιβάλλοντα δοκιμών  

## Συμπέρασμα

Μια ολοκληρωμένη στρατηγική δοκιμών είναι απαραίτητη για την ανάπτυξη αξιόπιστων, υψηλής ποιότητας MCP servers. Εφαρμόζοντας τις βέλτιστες πρακτικές και συμβουλές που περιγράφονται σε αυτόν τον οδηγό, μπορείτε να διασφαλίσετε ότι οι υλοποιήσεις MCP πληρούν τα υψηλότερα πρότυπα ποιότητας, αξιοπιστίας και απόδοσης.  

## Βασικά Σημεία

1. **Σχεδιασμός εργαλείων**: Ακολουθήστε την αρχή της μοναδικής ευθύνης, χρησιμοποιήστε dependency injection και σχεδιάστε για συνθετότητα  
2. **Σχεδιασμός σχήματος**: Δημιουργήστε σαφή, καλά τεκμηριωμένα σχήματα με κατάλληλους περιορισμούς επικύρωσης  
3. **Διαχείριση σφαλμάτων**: Υλοποιήστε ομαλή διαχείριση σφαλμάτων, δομημένες απαντήσεις σφαλμάτων και λογική επανάληψης  
4. **Απόδοση**: Χρησιμοποιήστε caching, ασύγχρονη επεξεργασία και περιορισμό πόρων  
5. **Ασφάλεια**: Εφαρμόστε αυστηρή επικύρωση εισόδων, ελέγχους εξουσιοδότησης και διαχείριση ευαίσθητων δεδομένων  
6. **Δοκιμές**: Δημιουργήστε ολοκληρωμένες μονάδες, ολοκλήρωσης και end-to-end δοκιμές  
7. **Πρότυπα ροής εργασίας**: Εφαρμόστε καθιερωμένα πρότυπα όπως αλυσίδες, dispatchers και παράλληλη επεξεργασία  

## Άσκηση

Σχεδιάστε ένα εργαλείο MCP και ροή εργασίας για ένα σύστημα επεξεργασίας εγγράφων που:

1. Αποδέχεται έγγραφα σε πολλαπλές μορφές (PDF, DOCX, TXT)  
2. Εξάγει κείμενο και βασικές πληροφορίες από τα έγγραφα  
3. Κατηγοριοποιεί τα έγγραφα ανά τύπο και περιεχόμενο  
4. Δημιουργεί περίληψη για κάθε έγγραφο  

Υλοποιήστε τα σχήματα εργαλείων, τη διαχείριση σφαλμάτων και ένα πρότυπο ροής εργασίας που ταιριάζει καλύτερα σε αυτό το σενάριο. Σκεφτείτε πώς θα δοκιμάζατε αυτή την υλοποίηση.  

## Πόροι

1. Ενταχθείτε στην κοινότητα MCP στο [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs) για να μένετε ενημερωμένοι με τις τελευταίες εξελίξεις  
2. Συνεισφέρετε σε open-source [MCP projects](https://github.com/modelcontextprotocol)  
3. Εφαρμόστε τις αρχές MCP στις δικές σας πρωτοβουλίες AI οργανισμού  
4. Εξερευνήστε εξειδικευμένες υλοποιήσεις MCP για τον κλάδο σας  
5. Σκεφτείτε να παρακολουθήσετε προχωρημένα μαθήματα σε συγκεκριμένα θέματα MCP, όπως πολυμορφική ενσωμάτωση ή ενσωμάτωση επιχειρησιακών εφαρμογών  
6. Πειραματιστείτε με τη δημιουργία δικών σας εργαλείων και ροών εργασίας MCP χρησιμοποιώντας τις αρχές που μάθατε μέσα από το [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)  

Επόμενο: Καλές Πρακτικές [case studies](../09-CaseStudy/README.md)

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που επιδιώκουμε την ακρίβεια, παρακαλούμε να γνωρίζετε ότι οι αυτόματες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη γλώσσα του θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.