<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "10d7df03cff1fa3cf3c56dc06e82ba79",
  "translation_date": "2025-07-02T08:15:02+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "hu"
}
-->
# MCP Fejlesztési Legjobb Gyakorlatai

## Áttekintés

Ez a lecke az MCP szerverek és funkciók fejlett fejlesztési, tesztelési és éles környezetbe való telepítési legjobb gyakorlataira fókuszál. Ahogy az MCP ökoszisztémák egyre összetettebbé és fontosabbá válnak, a bevált minták követése biztosítja a megbízhatóságot, karbantarthatóságot és az interoperabilitást. Ez a lecke a valós MCP megvalósítások során szerzett gyakorlati tapasztalatokat foglalja össze, hogy segítsen robosztus, hatékony szervereket létrehozni megfelelő erőforrásokkal, promptokkal és eszközökkel.

## Tanulási Célok

A lecke végére képes leszel:
- Alkalmazni az iparági legjobb gyakorlatokat MCP szerverek és funkciók tervezésében
- Átfogó tesztelési stratégiákat kidolgozni MCP szerverekhez
- Hatékony, újrahasznosítható munkafolyamat-mintákat tervezni összetett MCP alkalmazásokhoz
- Megfelelő hibakezelést, naplózást és megfigyelhetőséget megvalósítani MCP szerverekben
- Optimalizálni az MCP megvalósításokat teljesítmény, biztonság és karbantarthatóság szempontjából

## További Hivatkozások

A legfrissebb MCP legjobb gyakorlatokért tekintsd meg:
- [MCP Dokumentáció](https://modelcontextprotocol.io/)
- [MCP Specifikáció](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## MCP Eszközfejlesztési Legjobb Gyakorlatok

### Architektúrális Elvek

#### 1. Egységnyi Felelősség Elve

Minden MCP funkciónak világos, fókuszált céllal kell rendelkeznie. Ahelyett, hogy monolitikus eszközöket készítenél, amelyek több feladatot próbálnak egyszerre kezelni, fejlessz specializált eszközöket, amelyek egy adott feladatban kiválóak.

**Jó Példa:**
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

**Rossz Példa:**
```csharp
// A tool trying to do too many things
public class WeatherToolSuite : ITool
{
    public string Name => "weather";
    public string Description => "Weather-related functionality";
    
    public ToolDefinition GetDefinition()
    {
        return new ToolDefinition
        {
            Name = Name,
            Description = Description,
            Parameters = new Dictionary<string, ParameterDefinition>
            {
                ["action"] = new ParameterDefinition
                {
                    Type = ParameterType.String,
                    Description = "Weather action to perform",
                    Enum = new[] { "forecast", "history", "alerts", "radar" }
                },
                ["location"] = new ParameterDefinition
                {
                    Type = ParameterType.String,
                    Description = "City or location name"
                },
                // Many more properties for different actions...
            },
            required = new[] { "action", "location" }
        };
    }
    
    public async Task<ToolResponse> ExecuteAsync(ToolRequest request)
    {
        // Complex conditional logic to handle different actions
        var action = request.Parameters.GetProperty("action").GetString();
        var location = request.Parameters.GetProperty("location").GetString();
        
        switch (action)
        {
            case "forecast":
                // Forecast logic
                break;
            case "history":
                // Historical data logic
                break;
            // More cases...
            default:
                throw new ToolExecutionException($"Unknown action: {action}");
        }
        
        // Result processing
        // ...
    }
}
```

#### 2. Függőség Befecskendezés és Tesztelhetőség

Tervezd meg az eszközöket úgy, hogy a függőségeiket konstruktoron keresztül kapják meg, így tesztelhetőek és konfigurálhatóak lesznek:

```java
// Java example with dependency injection
public class CurrencyConversionTool implements Tool {
    private final ExchangeRateService exchangeService;
    private final CacheService cacheService;
    private final Logger logger;
    
    // Dependencies injected through constructor
    public CurrencyConversionTool(
            ExchangeRateService exchangeService,
            CacheService cacheService,
            Logger logger) {
        this.exchangeService = exchangeService;
        this.cacheService = cacheService;
        this.logger = logger;
    }
    
    // Tool implementation
    // ...
}
```

#### 3. Összeilleszthető Eszközök

Tervezd az eszközöket úgy, hogy összekapcsolhatóak legyenek komplexebb munkafolyamatok létrehozásához:

```python
# Python example showing composable tools
class DataFetchTool(Tool):
    def get_name(self):
        return "dataFetch"
    
    # Implementation...

class DataAnalysisTool(Tool):
    def get_name(self):
        return "dataAnalysis"
    
    # This tool can use results from the dataFetch tool
    async def execute_async(self, request):
        # Implementation...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # This tool can use results from the dataAnalysis tool
    async def execute_async(self, request):
        # Implementation...
        pass

# These tools can be used independently or as part of a workflow
```

### Sématervezési Legjobb Gyakorlatok

A séma a szerződés a modell és az eszközöd között. A jól megtervezett sémák jobb használhatósághoz vezetnek.

#### 1. Világos Paraméterleírások

Mindig adj leíró információkat minden paraméterhez:

```csharp
public object GetSchema()
{
    return new {
        type = "object",
        properties = new {
            query = new { 
                type = "string", 
                description = "Search query text. Use precise keywords for better results." 
            },
            filters = new {
                type = "object",
                description = "Optional filters to narrow down search results",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "Date range in format YYYY-MM-DD:YYYY-MM-DD" 
                    },
                    category = new { 
                        type = "string", 
                        description = "Category name to filter by" 
                    }
                }
            },
            limit = new { 
                type = "integer", 
                description = "Maximum number of results to return (1-50)",
                default = 10
            }
        },
        required = new[] { "query" }
    };
}
```

#### 2. Érvényesítési Korlátozások

Adj meg érvényesítési korlátokat, hogy megakadályozd a hibás bemeneteket:

```java
Map<String, Object> getSchema() {
    Map<String, Object> schema = new HashMap<>();
    schema.put("type", "object");
    
    Map<String, Object> properties = new HashMap<>();
    
    // Email property with format validation
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "User email address");
    
    // Age property with numeric constraints
    Map<String, Object> age = new HashMap<>();
    age.put("type", "integer");
    age.put("minimum", 13);
    age.put("maximum", 120);
    age.put("description", "User age in years");
    
    // Enumerated property
    Map<String, Object> subscription = new HashMap<>();
    subscription.put("type", "string");
    subscription.put("enum", Arrays.asList("free", "basic", "premium"));
    subscription.put("default", "free");
    subscription.put("description", "Subscription tier");
    
    properties.put("email", email);
    properties.put("age", age);
    properties.put("subscription", subscription);
    
    schema.put("properties", properties);
    schema.put("required", Arrays.asList("email"));
    
    return schema;
}
```

#### 3. Egységes Válaszstruktúrák

Tartsd következetesen a válaszstruktúrákat, hogy a modellek könnyebben értelmezhessék az eredményeket:

```python
async def execute_async(self, request):
    try:
        # Process request
        results = await self._search_database(request.parameters["query"])
        
        # Always return a consistent structure
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
    """Ensures each item has a consistent structure"""
    return {
        "id": item.id,
        "title": item.title,
        "summary": item.summary[:100] + "..." if len(item.summary) > 100 else item.summary,
        "url": item.url,
        "relevance": item.score
    }
```

### Hibakezelés

Robusztus hibakezelés elengedhetetlen az MCP eszközök megbízhatóságának fenntartásához.

#### 1. Kifinomult Hibakezelés

Kezeld a hibákat a megfelelő szinteken és adj informatív üzeneteket:

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
            throw new ToolExecutionException($"File not found: {fileId}");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ToolExecutionException("You don't have permission to access this file");
        }
        catch (Exception ex) when (ex is IOException || ex is TimeoutException)
        {
            _logger.LogError(ex, "Error accessing file {FileId}", fileId);
            throw new ToolExecutionException("Error accessing file: The service is temporarily unavailable");
        }
    }
    catch (JsonException)
    {
        throw new ToolExecutionException("Invalid file ID format");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Unexpected error in FileAccessTool");
        throw new ToolExecutionException("An unexpected error occurred");
    }
}
```

#### 2. Strukturált Hibaválaszok

Lehetőség szerint adj vissza strukturált hibainformációt:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    try {
        // Implementation
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
        
        // Re-throw other exceptions as ToolExecutionException
        throw new ToolExecutionException("Tool execution failed: " + ex.getMessage(), ex);
    }
}
```

#### 3. Újrapróbálkozási Logika

Valósíts meg megfelelő újrapróbálkozási logikát átmeneti hibák esetére:

```python
async def execute_async(self, request):
    max_retries = 3
    retry_count = 0
    base_delay = 1  # seconds
    
    while retry_count < max_retries:
        try:
            # Call external API
            return await self._call_api(request.parameters)
        except TransientError as e:
            retry_count += 1
            if retry_count >= max_retries:
                raise ToolExecutionException(f"Operation failed after {max_retries} attempts: {str(e)}")
                
            # Exponential backoff
            delay = base_delay * (2 ** (retry_count - 1))
            logging.warning(f"Transient error, retrying in {delay}s: {str(e)}")
            await asyncio.sleep(delay)
        except Exception as e:
            # Non-transient error, don't retry
            raise ToolExecutionException(f"Operation failed: {str(e)}")
```

### Teljesítményoptimalizálás

#### 1. Gyorsítótárazás

Valósíts meg gyorsítótárazást erőforrás-igényes műveletekhez:

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
    
    public async Task<ToolResponse> ExecuteAsync(ToolRequest request)
    {
        var query = request.Parameters.GetProperty("query").GetString();
        
        // Create cache key based on parameters
        var cacheKey = $"data_query_{ComputeHash(query)}";
        
        // Try to get from cache first
        if (_cache.TryGetValue(cacheKey, out var cachedResult))
        {
            return new ToolResponse { Result = cachedResult };
        }
        
        // Cache miss - perform actual query
        var result = await _database.QueryAsync(query);
        
        // Store in cache with expiration
        var cacheOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
            
        _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
        
        return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
    }
    
    private string ComputeHash(string input)
    {
        // Implementation to generate stable hash for cache key
    }
}
```

#### 2. Aszinkron Feldolgozás

Használj aszinkron programozási mintákat I/O-kötött műveletekhez:

```java
public class AsyncDocumentProcessingTool implements Tool {
    private final DocumentService documentService;
    private final ExecutorService executorService;
    
    @Override
    public ToolResponse execute(ToolRequest request) {
        String documentId = request.getParameters().get("documentId").asText();
        
        // For long-running operations, return a processing ID immediately
        String processId = UUID.randomUUID().toString();
        
        // Start async processing
        CompletableFuture.runAsync(() -> {
            try {
                // Perform long-running operation
                documentService.processDocument(documentId);
                
                // Update status (would typically be stored in a database)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // Return immediate response with process ID
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // Companion status check tool
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

#### 3. Erőforrás Korlátozás

Valósíts meg erőforrás-korlátozást a túlterhelés megelőzésére:

```python
class ThrottledApiTool(Tool):
    def __init__(self):
        self.rate_limiter = TokenBucketRateLimiter(
            tokens_per_second=5,  # Allow 5 requests per second
            bucket_size=10        # Allow bursts up to 10 requests
        )
    
    async def execute_async(self, request):
        # Check if we can proceed or need to wait
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # If wait is too long
                raise ToolExecutionException(
                    f"Rate limit exceeded. Please try again in {delay:.1f} seconds."
                )
            else:
                # Wait for the appropriate delay time
                await asyncio.sleep(delay)
        
        # Consume a token and proceed with the request
        self.rate_limiter.consume()
        
        # Call API
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
            
            # Calculate time until next token available
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # Add new tokens based on elapsed time
        new_tokens = elapsed * self.tokens_per_second
        self.tokens = min(self.bucket_size, self.tokens + new_tokens)
        self.last_refill = now
```

### Biztonsági Legjobb Gyakorlatok

#### 1. Bemeneti Érvényesítés

Mindig alaposan érvényesítsd a bemeneti paramétereket:

```csharp
public async Task<ToolResponse> ExecuteAsync(ToolRequest request)
{
    // Validate parameters exist
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("Missing required parameter: query");
    }
    
    // Validate correct type
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("Query parameter must be a string");
    }
    
    var query = queryProp.GetString();
    
    // Validate string content
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("Query parameter cannot be empty");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("Query parameter exceeds maximum length of 500 characters");
    }
    
    // Check for SQL injection attacks if applicable
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("Invalid query: contains potentially unsafe SQL");
    }
    
    // Proceed with execution
    // ...
}
```

#### 2. Jogosultság Ellenőrzések

Valósíts meg megfelelő jogosultság ellenőrzéseket:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // Get user context from request
    UserContext user = request.getContext().getUserContext();
    
    // Check if user has required permissions
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("User does not have permission to access documents");
    }
    
    // For specific resources, check access to that resource
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("Access denied to the requested document");
    }
    
    // Proceed with tool execution
    // ...
}
```

#### 3. Érzékeny Adatok Kezelése

Kezeld körültekintően az érzékeny adatokat:

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
        
        # Get user data
        user_data = await self.user_service.get_user_data(user_id)
        
        # Filter sensitive fields unless explicitly requested AND authorized
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # Check authorization level in request context
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # Create a copy to avoid modifying the original
        redacted = user_data.copy()
        
        # Redact specific sensitive fields
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # Redact nested sensitive data
        if "financialInfo" in redacted:
            redacted["financialInfo"] = {"available": True, "accessRestricted": True}
        
        return redacted
```

## Tesztelési Legjobb Gyakorlatok MCP Eszközökhöz

Az átfogó tesztelés biztosítja, hogy az MCP eszközök helyesen működjenek, kezeljék a szélsőséges eseteket és megfelelően integrálódjanak a rendszer többi részével.

### Egységtesztelés

#### 1. Teszteld az Eszközöket Elkülönítve

Készíts fókuszált teszteket az egyes eszközök funkcionalitására:

```csharp
[Fact]
public async Task WeatherTool_ValidLocation_ReturnsCorrectForecast()
{
    // Arrange
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
    
    // Act
    var response = await tool.ExecuteAsync(request);
    
    // Assert
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // Arrange
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
    
    // Act & Assert
    var exception = await Assert.ThrowsAsync<ToolExecutionException>(
        () => tool.ExecuteAsync(request)
    );
    
    Assert.Contains("Location not found", exception.Message);
}
```

#### 2. Séma Érvényesítés Tesztelése

Teszteld, hogy a sémák érvényesek és megfelelően érvényesítik a korlátokat:

```java
@Test
public void testSchemaValidation() {
    // Create tool instance
    SearchTool searchTool = new SearchTool();
    
    // Get schema
    Object schema = searchTool.getSchema();
    
    // Convert schema to JSON for validation
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // Validate schema is valid JSONSchema
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // Test valid parameters
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // Test missing required parameter
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // Test invalid parameter type
    JsonNode invalidType = objectMapper.createObjectNode()
        .put("query", "test")
        .put("limit", "not-a-number");
        
    ProcessingReport invalidReport = jsonSchema.validate(invalidType);
    assertFalse(invalidReport.isSuccess());
}
```

#### 3. Hibakezelési Tesztek

Készíts specifikus teszteket hibás esetekre:

```python
@pytest.mark.asyncio
async def test_api_tool_handles_timeout():
    # Arrange
    tool = ApiTool(timeout=0.1)  # Very short timeout
    
    # Mock a request that will time out
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # Longer than timeout
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # Act & Assert
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Verify exception message
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # Arrange
    tool = ApiTool()
    
    # Mock a rate-limited response
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
        
        # Act & Assert
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Verify exception contains rate limit information
        error_msg = str(exc_info.value).lower()
        assert "rate limit" in error_msg
        assert "try again" in error_msg
```

### Integrációs Tesztelés

#### 1. Eszközlánc Tesztelés

Teszteld, hogy az eszközök az elvárt kombinációkban együtt működnek:

```csharp
[Fact]
public async Task DataProcessingWorkflow_CompletesSuccessfully()
{
    // Arrange
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // Act
    var result = await workflowExecutor.ExecuteWorkflowAsync(new[] {
        new ToolCall("dataFetch", new { source = "sales2023" }),
        new ToolCall("dataAnalysis", ctx => new { 
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

#### 2. MCP Szerver Tesztelés

Teszteld az MCP szervert az összes eszköz regisztrálásával és futtatásával:

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
        // Test the discovery endpoint
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // Create tool request
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // Send request and verify response
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // Create invalid tool request
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // Missing parameter "b"
        request.put("parameters", parameters);
        
        // Send request and verify error response
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isBadRequest())
            .andExpect(jsonPath("$.error").exists());
    }
}
```

#### 3. Végponttól Végpontig Tesztelés

Teszteld a teljes munkafolyamatot a modell promptjától az eszköz végrehajtásáig:

```python
@pytest.mark.asyncio
async def test_model_interaction_with_tool():
    # Arrange - Set up MCP client and mock model
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # Mock model responses
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
    
    # Mock weather tool response
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

### Teljesítmény Tesztelés

#### 1. Terhelés Tesztelés

Teszteld, hogy hány egyidejű kérést tud kezelni az MCP szervered:

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

#### 2. Stressz Tesztelés

Teszteld a rendszert extrém terhelés alatt:

```java
@Test
public void testServerUnderStress() {
    int maxUsers = 1000;
    int rampUpTimeSeconds = 60;
    int testDurationSeconds = 300;
    
    // Set up JMeter for stress testing
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // Configure JMeter test plan
    HashTree testPlanTree = new HashTree();
    
    // Create test plan, thread group, samplers, etc.
    TestPlan testPlan = new TestPlan("MCP Server Stress Test");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // Add HTTP sampler for tool execution
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // Add listeners
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // Run test
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // Validate results
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // Average response time < 200ms
    assertTrue(summaryReport.getPercentile(90.0) < 500); // 90th percentile < 500ms
}
```

#### 3. Megfigyelés és Profilozás

Állíts be megfigyelést hosszú távú teljesítmény elemzéshez:

```python
# Configure monitoring for an MCP server
def configure_monitoring(server):
    # Set up Prometheus metrics
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "Total MCP requests"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "Request duration in seconds",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "Tool execution count",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "Tool execution duration in seconds",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "Tool execution errors",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # Add middleware for timing and recording metrics
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # Expose metrics endpoint
    @server.router.get("/metrics")
    async def metrics():
        return generate_latest()
    
    return server
```

## MCP Munkafolyamat Tervezési Minták

A jól megtervezett MCP munkafolyamatok javítják a hatékonyságot, megbízhatóságot és karbantarthatóságot. Íme a legfontosabb minták:

### 1. Eszközök Láncolata Minta

Kapcsolj össze több eszközt úgy, hogy az egyik kimenete a következő bemenete legyen:

```python
# Python Chain of Tools implementation
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # List of tool names to execute in sequence
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # Execute each tool in the chain, passing previous result
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # Store result and use as input for next tool
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# Example usage
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

### 2. Dispatcher Minta

Használj központi eszközt, amely bemenet alapján specializált eszközökhöz irányít:

```csharp
public class ContentDispatcherTool : IMcpTool
{
    private readonly IMcpClient _mcpClient;
    
    public ContentDispatcherTool(IMcpClient mcpClient)
    {
        _mcpClient = mcpClient;
    }
    
    public string Name => "contentProcessor";
    public string Description => "Processes content of various types";
    
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
        
        // Determine which specialized tool to use
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // Forward to the specialized tool
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
            ("code", _) => "codeAnalyzer",
            _ => throw new ToolExecutionException($"No tool available for {contentType}/{operation}")
        };
    }
    
    private object GetOptionsForTool(string toolName, string operation)
    {
        // Return appropriate options for each specialized tool
        return toolName switch
        {
            "textSummarizer" => new { length = "medium" },
            "htmlProcessor" => new { cleanUp = true, operation },
            // Options for other tools...
            _ => new { }
        };
    }
}
```

### 3. Párhuzamos Feldolgozás Minta

Futtass több eszközt egyszerre a hatékonyság érdekében:

```java
public class ParallelDataProcessingWorkflow {
    private final McpClient mcpClient;
    
    public ParallelDataProcessingWorkflow(McpClient mcpClient) {
        this.mcpClient = mcpClient;
    }
    
    public WorkflowResult execute(String datasetId) {
        // Step 1: Fetch dataset metadata (synchronous)
        ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata", 
            Map.of("datasetId", datasetId));
        
        // Step 2: Launch multiple analyses in parallel
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
        
        // Wait for all parallel tasks to complete
        CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
            statisticalAnalysis, correlationAnalysis, outlierDetection
        );
        
        allAnalyses.join();  // Wait for completion
        
        // Step 3: Combine results
        Map<String, Object> combinedResults = new HashMap<>();
        combinedResults.put("metadata", metadataResponse.getResult());
        combinedResults.put("statistics", statisticalAnalysis.join().getResult());
        combinedResults.put("correlations", correlationAnalysis.join().getResult());
        combinedResults.put("outliers", outlierDetection.join().getResult());
        
        // Step 4: Generate summary report
        ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator", 
            Map.of("analysisResults", combinedResults));
        
        // Return complete workflow result
        WorkflowResult result = new WorkflowResult();
        result.setDatasetId(datasetId);
        result.setAnalysisResults(combinedResults);
        result.setSummaryReport(summaryResponse.getResult());
        
        return result;
    }
}
```

### 4. Hibajavító Minta

Valósíts meg kifinomult visszaesési megoldásokat eszközhibák esetére:

```python
class ResilientWorkflow:
    def __init__(self, mcp_client):
        self.client = mcp_client
    
    async def execute_with_fallback(self, primary_tool, fallback_tool, parameters):
        try:
            # Try primary tool first
            response = await self.client.execute_tool(primary_tool, parameters)
            return {
                "result": response.result,
                "source": "primary",
                "tool": primary_tool
            }
        except ToolExecutionException as e:
            # Log the failure
            logging.warning(f"Primary tool '{primary_tool}' failed: {str(e)}")
            
            # Fall back to secondary tool
            try:
                # Might need to transform parameters for fallback tool
                fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)
                
                response = await self.client.execute_tool(fallback_tool, fallback_params)
                return {
                    "result": response.result,
                    "source": "fallback",
                    "tool": fallback_tool,
                    "primaryError": str(e)
                }
            except ToolExecutionException as fallback_error:
                # Both tools failed
                logging.error(f"Both primary and fallback tools failed. Fallback error: {str(fallback_error)}")
                raise WorkflowExecutionException(
                    f"Workflow failed: primary error: {str(e)}; fallback error: {str(fallback_error)}"
                )
    
    def _adapt_parameters(self, params, from_tool, to_tool):
        """Adapt parameters between different tools if needed"""
        # This implementation would depend on the specific tools
        # For this example, we'll just return the original parameters
        return params

# Example usage
async def get_weather(workflow, location):
    return await workflow.execute_with_fallback(
        "premiumWeatherService",  # Primary (paid) weather API
        "basicWeatherService",    # Fallback (free) weather API
        {"location": location}
    )
```

### 5. Munkafolyamat Összeállítás Minta

Építs komplex munkafolyamatokat egyszerűbbek összeillesztésével:

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
            
            // Store each workflow's result
            results[workflow.Name] = workflowResult;
            
            // Update context with the result for the next workflow
            context = context.WithResult(workflow.Name, workflowResult);
        }
        
        return new WorkflowResult(results);
    }
    
    public string Name => "CompositeWorkflow";
    public string Description => "Executes multiple workflows in sequence";
}

// Example usage
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

# MCP Szerverek Tesztelése: Legjobb Gyakorlatok és Tippek

## Áttekintés

A tesztelés kulcsfontosságú a megbízható, magas minőségű MCP szerverek fejlesztésében. Ez az útmutató átfogó legjobb gyakorlatokat és tippeket nyújt az MCP szerverek fejlesztési ciklus alatti teszteléséhez, az egységtesztektől az integrációs és végponttól végpontig tartó validációig.

## Miért Fontos a Tesztelés MCP Szervereknél

Az MCP szerverek fontos köztes rétegként működnek az AI modellek és a kliens alkalmazások között. Az alapos tesztelés biztosítja:

- Megbízhatóságot éles környezetben
- Pontos kérés-válasz kezelését
- Az MCP specifikációk helyes megvalósítását
- Ellenállóképességet hibák és szélsőséges esetek ellen
- Következetes teljesítményt különböző terhelések alatt

## Egységtesztelés MCP Szerverekhez

### Egységtesztelés (Alap)

Az egységtesztek az MCP szerver egyes komponenseit izoláltan ellenőrzik.

#### Mit Tesztelj

1. **Erőforrás Kezelők**: Teszteld az egyes erőforrás kezelők logikáját külön-külön
2. **Eszköz Megvalósítások**: Ellenőrizd az eszközök viselkedését különböző bemenetekkel
3. **Prompt Sablonok**: Biztosítsd, hogy a prompt sablonok helyesen renderelődnek
4. **Séma Érvényesítés**: Teszteld a paraméterek érvényesítési logikáját
5. **Hibakezelés**: Ellenőrizd a hibaválaszokat hibás bemenetek esetén

#### Egységtesztelési Legjobb Gyakorlatok

```csharp
// Example unit test for a calculator tool in C#
[Fact]
public async Task CalculatorTool_Add_ReturnsCorrectSum()
{
    // Arrange
    var calculator = new CalculatorTool();
    var parameters = new Dictionary<string, object>
    {
        ["operation"] = "add",
        ["a"] = 5,
        ["b"] = 7
    };
    
    // Act
    var response = await calculator.ExecuteAsync(parameters);
    var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());
    
    // Assert
    Assert.Equal(12, result.Value);
}
```

```python
# Example unit test for a calculator tool in Python
def test_calculator_tool_add():
    # Arrange
    calculator = CalculatorTool()
    parameters = {
        "operation": "add",
        "a": 5,
        "b": 7
    }
    
    # Act
    response = calculator.execute(parameters)
    result = json.loads(response.content[0].text)
    
    # Assert
    assert result["value"] == 12
```

### Integrációs Tesztelés (Középső Réteg)

Az integrációs tesztek az MCP szerver komponenseinek kölcsönhatásait ellenőrzik.

#### Mit Tesztelj

1. **Szerver Indítás**: Teszteld a szerver indítását különböző konfigurációkkal
2. **Útvonal Regisztráció**: Ellenőrizd, hogy minden végpont helyesen regisztrálva van
3. **Kérés Feldolgozás**: Teszteld a teljes kérés-válasz ciklust
4. **Hibák Átterjedése**: Biztosítsd, hogy a hibák megfelelően kezelődnek a komponensek között
5. **Hitelesítés és Jogosultság**: Teszteld a biztonsági mechanizmusokat

#### Integrációs Tesztelési Legjobb Gyakorlatok

```csharp
// Example integration test for MCP server in C#
[Fact]
public async Task Server_ProcessToolRequest_ReturnsValidResponse()
{
    // Arrange
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
    
    // Act
    var response = await server.ProcessRequestAsync(request);
    
    // Assert
    Assert.NotNull(response);
    Assert.Equal(McpStatusCodes.Success, response.StatusCode);
    // Additional assertions for response content
    
    // Cleanup
    await server.StopAsync();
}
```

### Végponttól Végpontig Tesztelés (Felső Réteg)

A végponttól végpontig tartó tesztek az egész rendszer viselkedését ellenőrzik a kliens oldaltól a szerverig.

#### Mit Tesztelj

1. **Kliens-Szerver Kommunikáció**: Teszteld a teljes kérés-válasz ciklusokat
2. **Valós Kliens SDK-k**: Tesztelj valódi kliens megvalósításokkal
3. **Terhelés Alatti Teljesítmény**: Ellenőrizd a viselkedést több egyidejű kérés esetén
4. **Hibajavítás**: Teszteld a rendszer helyreállását hibákból
5. **Hosszú Műveletek**: Ellenőrizd a streaming és hosszú futású műveletek kezelését

#### Végponttól Végpontig Tesztelési Legjobb Gyakorlatok

```typescript
// Example E2E test with a client in TypeScript
describe('MCP Server E2E Tests', () => {
  let client: McpClient;
  
  beforeAll(async () => {
    // Start server in test environment
    await startTestServer();
    client = new McpClient('http://localhost:5000');
  });
  
  afterAll(async () => {
    await stopTestServer();
  });
  
  test('Client can invoke calculator tool and get correct result', async () => {
    // Act
    const response = await client.invokeToolAsync('calculator', {
      operation: 'divide',
      a: 20,
      b: 4
    });
    
    // Assert
    expect(response.statusCode).toBe(200);
    expect(response.content[0].text).toContain('5');
  });
});
```

## Mockolási Stratégiák MCP Teszteléshez

A mockolás elengedhetetlen a komponensek izolált teszteléséhez.

### Mockolandó Komponensek

1. **Külső AI Modellek**: Mockold a modell válaszokat kiszámítható tesztekhez
2. **Külső Szolgáltatások**: Mockold az API függőségeket (adatbázisok, harmadik fél szolgáltatások)
3. **Hitelesítési Szolgáltatások**: Mockold az identitás szolgáltatókat
4. **Erőforrás Szolgáltatók**: Mockold az erőforrás-igényes kezelőket

### Példa: AI Modell Válasz Mockolása

```csharp
// C# example with Moq
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
# Python example with unittest.mock
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
    # Configure mock
    mock_model.return_value.generate_response.return_value = {
        "text": "Mocked model response",
        "finish_reason": "completed"
    }
    
    # Use mock in test
    server = McpServer(model_client=mock_model)
    # Continue with test
```

## Teljesítmény Tesztelés

A teljesítménytesztelés kulcsfontosságú az éles MCP szerverekhez.

### Mit Mérj

1. **Késleltetés**: Válaszidő kérésekre
2. **Áteresztőképesség**: Másodpercenként kezelt kérések száma
3. **Erőforrás Használat**: CPU, memória, hálózat kihasználtság
4. **Párhuzamosság Kezelése**: Viselkedés párhuzamos kérések alatt
5. **Skálázódási Jellemzők**: Teljesítmény terhelés növekedésével

### Teljesítmény Tesztelő Eszközök

- **k6**: Nyílt forráskódú terhelés tesztelő eszköz
- **JMeter**: Átfogó teljesítménytesztelő
- **Locust**: Python alapú terhelés tesztelő
- **Azure Load Testing**: Felhő alapú teljesítménytesztelő

### Példa: Egyszerű Terhelés Teszt k6-tal

```javascript
// k6 script for load testing MCP server
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  vus: 10,  // 10 virtual users
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

## Teszt Automatizálás MCP Szerverekhez

A tesztek automatizálása biztosítja a következetes minőséget és gyorsabb visszacsatolást.

### CI/CD Integráció

1. **Egységtesztek futtatása Pull Request-eknél**: Biztosítsd, hogy a kódváltozások ne törjék meg a meglévő funkcionalitást
2. **Integrációs tesztek staging környezetben**: Fussanak integrációs tesztek előéles környezetben
3. **Teljesítmény alapvonalak**: Tartsd fenn a teljesítmény mérőszámokat a regressziók elkerülésére
4. **Biztonsági szkennelés**: Automatizáld a biztonsági teszteket a folyamat részeként

### Példa CI Pipeline (GitHub Actions)

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

## MCP Specifikációnak Megfelelés Tesztelése

Ellenőrizd, hogy a szervered helyesen valósítja meg az MCP specifikációt.

### Fő Megfelelési Területek

1. **API Végpontok**: Teszteld a kötelező végpontokat (/resources, /tools, stb.)
2. **Kérés/Válasz Formátum**: Érvényesítsd a séma szerinti megfelelést
3. **Hibakódok**: Ellenőrizd a helyes státuszkódokat különböző esetekben
4. **Tartalomtípusok**: Teszteld a különböző tartalomtípusok kezelését
5. **Hitelesítési Folyamat**: Ellenőrizd a specifikációnak megfelelő hitelesítési mechanizmusokat

### Megfelelőségi Tesztcsomag

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

## Top 10 Tipp Hatékony MCP Szerver Teszteléshez

1. **Teszteld külön az eszköz definíciókat**: Ellenőrizd a séma definíciókat az eszköz logikájától függetlenül
2. **Használj paraméterezett teszteket**: Tesztelj eszközöket változatos bemenetekkel, beleértve a szélsőséges eseteket is
3. **Ellenőrizd a hibaválaszokat**: Biztosítsd a megfelelő hibakezelést minden lehetséges hibahelyzetre
4. **Teszteld a jogosultság logikát**: Biztosítsd a megfelelő hozzáférés-ellenőrzést különböző felhasználói szerepk

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén professzionális, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.