<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "10d7df03cff1fa3cf3c56dc06e82ba79",
  "translation_date": "2025-07-02T07:59:45+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "ne"
}
-->
# MCP विकासका उत्कृष्ट अभ्यासहरू

## अवलोकन

यो पाठले उत्पादन वातावरणमा MCP सर्भरहरू र सुविधाहरू विकास, परीक्षण, र डिप्लोय गर्ने उन्नत उत्कृष्ट अभ्यासहरूमा केन्द्रित छ। MCP पारिस्थितिकी तंत्र जटिल र महत्त्वपूर्ण बन्दै जाँदा, स्थापित ढाँचाहरूको पालना गर्दा विश्वसनीयता, मर्मतयोग्यता, र अन्तरसञ्चालनीयता सुनिश्चित हुन्छ। यस पाठले वास्तविक संसारका MCP कार्यान्वयनहरूबाट प्राप्त व्यावहारिक ज्ञानलाई एकत्रित गरी तपाईंलाई बलियो, प्रभावकारी सर्भरहरू बनाउन मार्गदर्शन गर्दछ जसमा प्रभावकारी स्रोतहरू, प्रॉम्प्टहरू, र उपकरणहरू हुन्छन्।

## सिकाइ उद्देश्यहरू

यस पाठको अन्त्यसम्म तपाईं सक्षम हुनुहुनेछ:
- MCP सर्भर र सुविधा डिजाइनमा उद्योगका उत्कृष्ट अभ्यासहरू लागू गर्न
- MCP सर्भरहरूको लागि व्यापक परीक्षण रणनीतिहरू बनाउन
- जटिल MCP अनुप्रयोगहरूको लागि प्रभावकारी, पुन: प्रयोग गर्न मिल्ने वर्कफ्लो ढाँचाहरू डिजाइन गर्न
- MCP सर्भरहरूमा उपयुक्त त्रुटि ह्यान्डलिङ, लगिङ, र अवलोकनशीलता लागू गर्न
- प्रदर्शन, सुरक्षा, र मर्मतयोग्यताको लागि MCP कार्यान्वयनहरू अनुकूलित गर्न

## थप सन्दर्भहरू

MCP उत्कृष्ट अभ्यासहरूमा सबैभन्दा नयाँ जानकारीका लागि हेर्नुहोस्:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## MCP उपकरण विकासका उत्कृष्ट अभ्यासहरू

### वास्तुकला सिद्धान्तहरू

#### १. एकल जिम्मेवारी सिद्धान्त

प्रत्येक MCP सुविधाले स्पष्ट र केन्द्रित उद्देश्य हुनु पर्छ। धेरै विषयहरू सम्हाल्ने मोनोलीथिक उपकरणहरू बनाउनुभन्दा, विशेष कार्यहरूमा दक्ष विशेषज्ञ उपकरणहरू विकास गर्नुहोस्।

**राम्रो उदाहरण:**
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

**खराब उदाहरण:**
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

#### २. निर्भरता इंजेक्शन र परीक्षणयोग्यता

निर्भरता निर्माणकर्ताबाट इंजेक्ट हुने गरी उपकरणहरू डिजाइन गर्नुहोस् जसले तिनीहरूलाई परीक्षणयोग्य र कन्फिगरेबल बनाउँछ:

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

#### ३. संयोज्य उपकरणहरू

अधिक जटिल वर्कफ्लोहरू बनाउन संयोजन गर्न मिल्ने उपकरणहरू डिजाइन गर्नुहोस्:

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

### स्कीमा डिजाइनका उत्कृष्ट अभ्यासहरू

स्कीमा मोडेल र तपाईंको उपकरण बीचको सम्झौता हो। राम्रो डिजाइन गरिएका स्कीमाले उपकरणको प्रयोगयोग्यता सुधार गर्छ।

#### १. स्पष्ट प्यारामिटर विवरणहरू

प्रत्येक प्यारामिटरको लागि सधैं वर्णनात्मक जानकारी समावेश गर्नुहोस्:

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

#### २. प्रमाणीकरण सिमाहरू

अवैध इनपुट रोक्न प्रमाणीकरण सिमाहरू समावेश गर्नुहोस्:

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

#### ३. सुसंगत प्रतिक्रिया संरचनाहरू

परिणामहरू मोडेलले सजिलै बुझ्न सकून् भनेर प्रतिक्रिया संरचनामा सुसंगतता राख्नुहोस्:

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

### त्रुटि ह्यान्डलिङ

MCP उपकरणहरूको विश्वसनीयता कायम राख्न मजबुत त्रुटि ह्यान्डलिङ अत्यावश्यक छ।

#### १. सहज त्रुटि ह्यान्डलिङ

उपयुक्त तहहरूमा त्रुटिहरू ह्यान्डल गर्नुहोस् र जानकारीमूलक सन्देशहरू दिनुहोस्:

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

#### २. संरचित त्रुटि प्रतिक्रिया

संभव भएमा संरचित त्रुटि जानकारी फर्काउनुहोस्:

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

#### ३. पुन: प्रयास तर्क

अस्थायी असफलताहरूको लागि उपयुक्त पुन: प्रयास तर्क लागू गर्नुहोस्:

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

### प्रदर्शन अनुकूलन

#### १. क्यासिङ

महँगो अपरेसनहरूको लागि क्यासिङ लागू गर्नुहोस्:

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

#### २. एसिन्क्रोनस प्रक्रिया

I/O-आधारित अपरेसनहरूका लागि एसिन्क्रोनस प्रोग्रामिङ ढाँचाहरू प्रयोग गर्नुहोस्:

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

#### ३. स्रोत थ्रोटलिङ

ओभरलोड रोक्न स्रोत थ्रोटलिङ लागू गर्नुहोस्:

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

### सुरक्षा उत्कृष्ट अभ्यासहरू

#### १. इनपुट प्रमाणीकरण

सधैं इनपुट प्यारामिटरहरू पूर्ण रूपमा प्रमाणीकरण गर्नुहोस्:

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

#### २. प्राधिकरण जाँचहरू

उपयुक्त प्राधिकरण जाँचहरू लागू गर्नुहोस्:

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

#### ३. संवेदनशील डाटा ह्यान्डलिङ

संवेदनशील डाटालाई सावधानीपूर्वक ह्यान्डल गर्नुहोस्:

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

## MCP उपकरणहरूको लागि परीक्षण उत्कृष्ट अभ्यासहरू

व्यापक परीक्षणले सुनिश्चित गर्छ कि MCP उपकरणहरू सही रूपमा काम गर्छन्, किनाराका केसहरू सम्हाल्छन्, र प्रणालीसँग ठीकसँग एकीकृत हुन्छन्।

### युनिट परीक्षण

#### १. प्रत्येक उपकरणलाई अलग्गै परीक्षण गर्नुहोस्

प्रत्येक उपकरणको कार्यक्षमता केन्द्रित तरिकाले परीक्षण गर्नुहोस्:

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

#### २. स्कीमा प्रमाणीकरण परीक्षण

स्कीमाहरू मान्य छन् र सिमाहरू ठीकसँग लागू भएका छन् भनी परीक्षण गर्नुहोस्:

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

#### ३. त्रुटि ह्यान्डलिङ परीक्षण

त्रुटि अवस्थाहरूका लागि विशेष परीक्षणहरू बनाउनुहोस्:

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

### एकीकरण परीक्षण

#### १. उपकरण श्रृंखला परीक्षण

अपेक्षित संयोजनमा उपकरणहरू सँगै काम गर्छन् भनी परीक्षण गर्नुहोस्:

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

#### २. MCP सर्भर परीक्षण

पूर्ण उपकरण दर्ता र कार्यान्वयन सहित MCP सर्भर परीक्षण गर्नुहोस्:

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

#### ३. अन्त्यदेखि अन्त्य परीक्षण

मोडेल प्रॉम्प्टदेखि उपकरण कार्यान्वयनसम्म पूरा वर्कफ्लो परीक्षण गर्नुहोस्:

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

### प्रदर्शन परीक्षण

#### १. लोड परीक्षण

तपाईंको MCP सर्भर कति समवर्ती अनुरोधहरू सम्हाल्न सक्छ भनी परीक्षण गर्नुहोस्:

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

#### २. तनाव परीक्षण

अत्यधिक लोडमा प्रणाली परीक्षण गर्नुहोस्:

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

#### ३. अनुगमन र प्रोफाइलिङ

दीर्घकालीन प्रदर्शन विश्लेषणका लागि अनुगमन सेटअप गर्नुहोस्:

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

## MCP वर्कफ्लो डिजाइन ढाँचाहरू

राम्रो डिजाइन गरिएका MCP वर्कफ्लोहरूले दक्षता, विश्वसनीयता, र मर्मतयोग्यता सुधार गर्छन्। यहाँ पालन गर्नुपर्ने मुख्य ढाँचाहरू छन्:

### १. उपकरणहरूको श्रृंखला ढाँचा

धेरै उपकरणहरूलाई एक अनुक्रममा जडान गर्नुहोस् जहाँ प्रत्येक उपकरणको आउटपुट अर्कोको इनपुट हुन्छ:

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

### २. डिस्प्याचर ढाँचा

केन्द्रीय उपकरण प्रयोग गरेर इनपुटको आधारमा विशेषज्ञ उपकरणहरूमा पठाउनुहोस्:

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

### ३. समानान्तर प्रक्रिया ढाँचा

दक्षताको लागि एकैसाथ धेरै उपकरणहरू चलाउनुहोस्:

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

### ४. त्रुटि पुन: प्राप्ति ढाँचा

उपकरण असफलताका लागि सहज फ्यालब्याकहरू लागू गर्नुहोस्:

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

### ५. वर्कफ्लो संयोजन ढाँचा

सरल वर्कफ्लोहरूलाई जोडेर जटिल वर्कफ्लोहरू निर्माण गर्नुहोस्:

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

# MCP सर्भरहरूको परीक्षण: उत्कृष्ट अभ्यासहरू र शीर्ष सुझावहरू

## अवलोकन

परीक्षण विश्वसनीय, उच्च गुणस्तरका MCP सर्भरहरू विकास गर्ने महत्वपूर्ण पक्ष हो। यो मार्गदर्शिकाले तपाईंको MCP सर्भरहरूलाई विकास चक्रभरि परीक्षण गर्न व्यापक उत्कृष्ट अभ्यासहरू र सुझावहरू प्रदान गर्दछ, युनिट परीक्षणदेखि एकीकरण परीक्षण र अन्त्यदेखि अन्त्य मान्यकरणसम्म।

## किन MCP सर्भरहरूको परीक्षण आवश्यक छ

MCP सर्भरहरू AI मोडेलहरू र क्लाइन्ट अनुप्रयोगहरू बीच महत्वपूर्ण मिडलवेयरको रूपमा काम गर्छन्। व्यापक परीक्षणले सुनिश्चित गर्छ:

- उत्पादन वातावरणमा विश्वसनीयता
- अनुरोध र प्रतिक्रियाहरूको सही ह्यान्डलिङ
- MCP विनिर्देशहरूको सही कार्यान्वयन
- असफलता र किनाराका केसहरू विरुद्ध सहनशीलता
- विभिन्न लोडमा निरन्तर प्रदर्शन

## MCP सर्भरहरूको लागि युनिट परीक्षण

### युनिट परीक्षण (आधार)

युनिट परीक्षणले तपाईंको MCP सर्भरका व्यक्तिगत कम्पोनेन्टहरूलाई अलग्गै जाँच गर्छ।

#### के परीक्षण गर्ने

१. **स्रोत ह्यान्डलरहरू**: प्रत्येक स्रोत ह्यान्डलरको तर्क अलग्गै परीक्षण गर्नुहोस्  
२. **उपकरण कार्यान्वयनहरू**: विभिन्न इनपुटहरूसँग उपकरणको व्यवहार प्रमाणित गर्नुहोस्  
३. **प्रॉम्प्ट टेम्प्लेटहरू**: प्रॉम्प्ट टेम्प्लेटहरू सही रूपमा रेंडर हुन्छन् भनी सुनिश्चित गर्नुहोस्  
४. **स्कीमा प्रमाणीकरण**: प्यारामिटर प्रमाणीकरण तर्क परीक्षण गर्नुहोस्  
५. **त्रुटि ह्यान्डलिङ**: अवैध इनपुटका लागि त्रुटि प्रतिक्रियाहरू जाँच्नुहोस्

#### युनिट परीक्षणका उत्कृष्ट अभ्यासहरू

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

### एकीकरण परीक्षण (मध्य तह)

एकीकरण परीक्षणले तपाईंको MCP सर्भरका कम्पोनेन्टहरू बीचको अन्तरक्रिया जाँच गर्छ।

#### के परीक्षण गर्ने

१. **सर्भर सुरु गर्ने प्रक्रिया**: विभिन्न कन्फिगरेसनहरूसँग सर्भर सुरु परीक्षण गर्नुहोस्  
२. **रुट दर्ता**: सबै अन्त बिन्दुहरू सही रूपमा दर्ता भएका छन् भनी जाँच गर्नुहोस्  
३. **अनुरोध प्रक्रिया**: पूर्ण अनुरोध-प्रतिक्रिया चक्र परीक्षण गर्नुहोस्  
४. **त्रुटि प्रसार**: कम्पोनेन्टहरू बीच त्रुटिहरू ठीकसँग ह्यान्डल हुन्छन् भनी सुनिश्चित गर्नुहोस्  
५. **प्रमाणीकरण र प्राधिकरण**: सुरक्षा संयन्त्रहरू परीक्षण गर्नुहोस्

#### एकीकरण परीक्षणका उत्कृष्ट अभ्यासहरू

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

### अन्त्यदेखि अन्त्य परीक्षण (शीर्ष तह)

अन्त्यदेखि अन्त्य परीक्षणले क्लाइन्टदेखि सर्भरसम्म सम्पूर्ण प्रणालीको व्यवहार जाँच गर्छ।

#### के परीक्षण गर्ने

१. **क्लाइन्ट-सर्भर सञ्चार**: पूर्ण अनुरोध-प्रतिक्रिया चक्र परीक्षण गर्नुहोस्  
२. **वास्तविक क्लाइन्ट SDKहरू**: वास्तविक क्लाइन्ट कार्यान्वयनहरूसँग परीक्षण गर्नुहोस्  
३. **लोडमा प्रदर्शन**: धेरै समवर्ती अनुरोधहरूसँग व्यवहार जाँच्नुहोस्  
४. **त्रुटि पुन: प्राप्ति**: असफलताबाट प्रणालीको पुनःस्थापना परीक्षण गर्नुहोस्  
५. **दीर्घकालीन अपरेसनहरू**: स्ट्रिमिङ र लामो अपरेसनहरूको ह्यान्डलिङ परीक्षण गर्नुहोस्

#### अन्त्यदेखि अन्त्य परीक्षणका उत्कृष्ट अभ्यासहरू

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

## MCP परीक्षणका लागि मोकिङ रणनीतिहरू

मोकिङले परीक्षणका क्रममा कम्पोनेन्टहरूलाई अलग्गै राख्न मद्दत गर्छ।

### मोक गर्नुपर्ने कम्पोनेन्टहरू

१. **बाह्य AI मोडेलहरू**: भविष्यवाणीयोग्य परीक्षणका लागि मोडेल प्रतिक्रियाहरू मोक गर्नुहोस्  
२. **बाह्य सेवा**: API निर्भरता (डेटाबेस, तेस्रो पक्ष सेवा) मोक गर्नुहोस्  
३. **प्रमाणीकरण सेवा**: पहिचान प्रदायकहरू मोक गर्नुहोस्  
४. **स्रोत प्रदायकहरू**: महँगो स्रोत ह्यान्डलरहरू मोक गर्नुहोस्

### उदाहरण: AI मोडेल प्रतिक्रिया मोकिङ

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

## प्रदर्शन परीक्षण

प्रदर्शन परीक्षण उत्पादन MCP सर्भरहरूको लागि अत्यावश्यक छ।

### के मापन गर्ने

१. **लेटेन्सी**: अनुरोधहरूको प्रतिक्रिया समय  
२. **थ्रूपुट**: प्रति सेकेन्ड ह्यान्डल गरिएका अनुरोधहरू  
३. **स्रोत उपयोग**: CPU, मेमोरी, नेटवर्क प्रयोग  
४. **समवर्ती ह्यान्डलिङ**: समानान्तर अनुरोधमा व्यवहार  
५. **स्केलिङ विशेषताहरू**: लोड बढ्दा प्रदर्शन

### प्रदर्शन परीक्षणका उपकरणहरू

- **k6**: खुला स्रोत लोड परीक्षण उपकरण  
- **JMeter**: व्यापक प्रदर्शन परीक्षण  
- **Locust**: पाइथन-आधारित लोड परीक्षण  
- **Azure Load Testing**: क्लाउड-आधारित प्रदर्शन परीक्षण

### उदाहरण: k6 सँग आधारभूत लोड परीक्षण

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

## MCP सर्भरहरूको लागि परीक्षण स्वचालन

तपाईंका परीक्षणहरू स्वचालित बनाउँदा गुणस्तर निरन्तर रहन्छ र प्रतिक्रिया चक्र छिटो हुन्छ।

### CI/CD एकीकरण

१. **पुल रिक्वेस्टमा युनिट परीक्षण चलाउनुहोस्**: कोड परिवर्तनले पहिलेको कार्यक्षमता भंग नगर्ने सुनिश्चित गर्नुहोस्  
२. **स्टेजिङमा एकीकरण परीक्षण**: पूर्व-उत्पादन वातावरणमा एकीकरण परीक्षण चलाउनुहोस्  
३. **प्रदर्शन आधाररेखा**: प्रदर्शन मापदण्डहरू कायम राखेर कमी पत्ता लगाउनुहोस्  
४. **सुरक्षा स्क्यानहरू**: पाइपलाइनको भागको रूपमा सुरक्षा परीक्षण स्वचालित गर्नुहोस्

### उदाहरण CI पाइपलाइन (GitHub Actions)

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

## MCP विनिर्देशनसँग अनुपालनको लागि परीक्षण

तपाईंको सर्भरले MCP विनिर्देशन सही रूपमा कार्यान्वयन गरेको छ भनी प्रमाणित गर्नुहोस्।

### मुख्य अनुपालन क्षेत्रहरू

१. **API अन्त बिन्दुहरू**: आवश्यक अन्त बिन्दुहरू (/resources, /tools, आदि) परीक्षण गर्नुहोस्  
२. **अनुरोध/प्रतिक्रिया ढाँचा**: स्कीमा अनुपालन प्रमाणीकरण गर्नुहोस्  
३. **त्रुटि कोडहरू**: विभिन्न परिदृश्यका लागि सही स्थिति कोडहरू सुनिश्चित गर्नुहोस्  
४. **सामग्री प्रकारहरू**: विभिन्न सामग्री प्रकारहरू ह्यान्डल गर्ने परीक्षण गर्नुहोस्  
५. **प्रमाणीकरण प्रवाह**: विनिर्देशन-अनुकूल प्रमाणीकरण संयन्त्रहरू प्रमाणित गर्नुहोस्

### अनुपालन परीक्षण सूट

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

## प्रभावकारी MCP सर्भर परीक्षणका शीर्ष १० सुझावहरू

१. **उपकरण परिभाषाहरू अलग्गै परीक्षण गर्नुहोस्**: उपकरण तर्कबाट स्कीमा परिभाषाहरू स्वतंत्र रूपमा प्रमाणित गर्नुहोस्  
२. **प्यारामिटराइज्ड परीक्षणहरू प्रयोग गर्नुहोस्**: विभिन्न इनपुटहरू सहित उपकरणहरू परीक्षण गर्नुहोस्, किनाराका केसहरू पनि  
३. **त्रुटि प्रतिक्रियाहरू जाँच्नुहोस्**: सबै सम्भावित त्रुटि अवस्थाहरूको उपयुक्त ह्यान्डलिङ सुनिश्चित गर्नुहोस्  
४. **प्राधिकरण तर्क परीक्षण गर्नुहोस्**: विभिन्न प्रयोगकर्ता भूमिकाका लागि उचित पहुँच नियन्त्रण सुनिश्चित गर्नुहोस्  
५. **परीक्षण कवरेज अनुगमन गर्नुहोस्**: महत्वपूर्ण पथ कोडको उच्च कवरेज लक्ष्य राख्नुहोस्  
६. **स्ट्रिमिङ प्रतिक्रिया परीक्षण गर्नुहोस्**: स्ट्रिमिङ सामग्रीको उपयुक्त ह्यान्डलिङ प्रमाणित गर्नुहोस्  
७. **नेटवर्क समस्याहरू सिमुलेट गर्नुहोस्**: खराब नेटवर्क अवस्थाहरूमा व्यवहार परीक्षण गर्नुहोस्  
८. **स्रोत सीमाहरू परीक्षण गर्नुहोस्**: कोटा वा दर सीमामा पुग्दा व्यवहार जाँच्नुहोस्  
९. **रिग्रेसन परीक्षण स्वचालित गर्नुहोस्**: प्रत्येक कोड परिवर्तनमा चल्ने परीक्षण सूट बनाउनुहोस्  
१०. **परीक्षण केसहरू दस्तावेज गर्नुहोस्**: परीक्षण परिदृश्यहरूको स्पष्ट दस्तावेजीकरण कायम राख्नुहोस्

## सामान्य परीक्षणका गल्तीहरू

- **खुसी मार्ग परीक्षणमा धेरै निर्भर हुनु**: त्रुटि केसहरू पनि राम्रोसँग परीक्षण गर्नुहोस्  
- **प्रदर्शन परीक्षण बेवास्ता गर्नु**: उत्पादनमा समस्या आउनुअघि बाधाहरू पहिचान गर्नुहोस्  
- **अलग्गै मात्र परीक्षण गर्नु**: युनिट, एकीकरण, र अन्त्यदेखि अन्त्य परीक्षणहरू संयोजन गर्नुहोस्  
- **अपूर्ण API कवरेज**: सबै अन्त बिन्दुहरू र सुविधाहरू परीक्षण गर्नुहोस्  
- **असंगत परीक्षण वातावरणहरू**: परीक्षण वातावरणहरू स्थिर बनाउन कन्टेनरहरू प्रयोग गर्नुहोस्

## निष्कर्ष

विश्वसनीय, उच्च गुणस्तरका MCP सर्भरहरू विकास गर्न व्यापक परीक्षण रणनीति आवश्यक छ। यस मार्गदर्शिकामा उल्लिखित उत्कृष्ट अभ्यासहरू र सुझावहरू लागू गरेर, तपाईंले आफ्नो MCP कार्यान्वयनहरूलाई गुणस्तर, विश्वसनीयता, र प्रदर्शनका उच्चतम मापदण्डहरूमा पुर्‍याउन सक्नुहुन्छ।

## मुख्य सिकाइहरू

१. **उपकरण डिजाइन**: एकल जिम्मेवारी सिद्धान्त पालन गर्नुहोस्, निर्भरता इंजेक्शन प्रयोग गर्नुहोस्, र संयोज्यताको लागि डिजाइन गर्नुहोस्  
२. **स्कीमा डिजाइन**: स्पष्ट, राम्रो दस्तावेजीकृत स्कीमा बनाउनुहोस् जसमा उचित प्रमाणीकरण सिमाहरू समावेश छन्  
३. **त्रुटि ह्यान्डलिङ**: सहज त्रुटि ह्यान्डलिङ, संरचित त्रुटि प्रतिक्रिया, र पुन: प्रयास तर्क लागू गर्नुहोस्  
४. **प्रदर्शन**: क्यासिङ, एसिन्क्रोनस प्रक्रिया, र स्रोत थ्रोटलिङ प्रयोग गर्नुहोस्  
५. **सुरक्षा**: पूर्ण इनपुट प्रमाणीकरण, प्राधिकरण जाँच, र

**अस्वीकरण**:  
यस दस्तावेजलाई AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया जानकार हुनुस् कि स्वचालित अनुवादमा त्रुटि वा असत्यताहरू हुन सक्छन्। मूल दस्तावेज यसको स्वदेशी भाषामा आधिकारिक स्रोत मानिनुपर्छ। महत्वपूर्ण जानकारीको लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न हुने कुनै पनि गलतफहमी वा गलत व्याख्याको लागि हामी जिम्मेवार छैनौं।