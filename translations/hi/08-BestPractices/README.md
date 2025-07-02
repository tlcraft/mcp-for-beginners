<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "10d7df03cff1fa3cf3c56dc06e82ba79",
  "translation_date": "2025-07-02T07:56:50+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "hi"
}
-->
# MCP विकास के सर्वोत्तम अभ्यास

## अवलोकन

यह पाठ MCP सर्वरों और फीचर्स के उत्पादन वातावरण में विकसित करने, परीक्षण करने और तैनात करने के लिए उन्नत सर्वोत्तम अभ्यासों पर केंद्रित है। जैसे-जैसे MCP इकोसिस्टम जटिल और महत्वपूर्ण होता जा रहा है, स्थापित पैटर्न का पालन करने से विश्वसनीयता, अनुरक्षणीयता और इंटरऑपरेबिलिटी सुनिश्चित होती है। यह पाठ वास्तविक दुनिया की MCP कार्यान्वयन से प्राप्त व्यावहारिक ज्ञान को समेकित करता है ताकि आप प्रभावी संसाधन, प्रॉम्प्ट और टूल्स के साथ मजबूत और कुशल सर्वर बना सकें।

## सीखने के उद्देश्य

इस पाठ के अंत तक, आप सक्षम होंगे:
- MCP सर्वर और फीचर डिजाइन में उद्योग के सर्वोत्तम अभ्यास लागू करना
- MCP सर्वरों के लिए व्यापक परीक्षण रणनीतियाँ बनाना
- जटिल MCP एप्लिकेशन के लिए कुशल, पुन: प्रयोज्य वर्कफ़्लो पैटर्न डिजाइन करना
- MCP सर्वरों में उचित त्रुटि प्रबंधन, लॉगिंग, और ऑब्ज़रवेबिलिटी लागू करना
- प्रदर्शन, सुरक्षा, और अनुरक्षणीयता के लिए MCP कार्यान्वयन का अनुकूलन करना

## अतिरिक्त संदर्भ

MCP सर्वोत्तम अभ्यासों पर सबसे अद्यतन जानकारी के लिए देखें:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## MCP टूल विकास के सर्वोत्तम अभ्यास

### वास्तुकला सिद्धांत

#### 1. सिंगल रिस्पॉन्सिबिलिटी प्रिंसिपल

प्रत्येक MCP फीचर का एक स्पष्ट, केंद्रित उद्देश्य होना चाहिए। बहु-कार्य संभालने वाले विशाल टूल बनाने के बजाय, ऐसे विशेषज्ञ टूल विकसित करें जो विशिष्ट कार्यों में उत्कृष्ट हों।

**अच्छा उदाहरण:**
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

#### 2. डिपेंडेंसी इंजेक्शन और टेस्टेबिलिटी

टूल्स को इस तरह डिजाइन करें कि वे उनके निर्भरता कंस्ट्रक्टर इंजेक्शन के माध्यम से प्राप्त करें, जिससे वे परीक्षण योग्य और कॉन्फ़िगर करने योग्य बनें:

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

#### 3. कंपोजेबल टूल्स

ऐसे टूल डिज़ाइन करें जिन्हें मिलाकर अधिक जटिल वर्कफ़्लो बनाए जा सकें:

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

### स्कीमा डिज़ाइन के सर्वोत्तम अभ्यास

स्कीमा मॉडल और आपके टूल के बीच का अनुबंध होता है। अच्छी तरह से डिज़ाइन किए गए स्कीमा बेहतर टूल उपयोगिता प्रदान करते हैं।

#### 1. स्पष्ट पैरामीटर विवरण

हर पैरामीटर के लिए हमेशा वर्णनात्मक जानकारी शामिल करें:

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

#### 2. वैलिडेशन प्रतिबंध

अवैध इनपुट को रोकने के लिए वैलिडेशन प्रतिबंध शामिल करें:

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

#### 3. सुसंगत रिटर्न संरचनाएँ

अपने प्रतिक्रिया संरचनाओं में सुसंगतता बनाए रखें ताकि मॉडल परिणामों को आसानी से समझ सके:

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

### त्रुटि प्रबंधन

MCP टूल्स की विश्वसनीयता बनाए रखने के लिए मजबूत त्रुटि प्रबंधन आवश्यक है।

#### 1. सहज त्रुटि प्रबंधन

उचित स्तरों पर त्रुटियों को संभालें और जानकारीपूर्ण संदेश प्रदान करें:

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

#### 2. संरचित त्रुटि प्रतिक्रियाएँ

संभव हो तो संरचित त्रुटि जानकारी लौटाएं:

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

#### 3. पुनः प्रयास तर्क

अस्थायी विफलताओं के लिए उचित पुनः प्रयास तर्क लागू करें:

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

#### 1. कैशिंग

महंगे ऑपरेशनों के लिए कैशिंग लागू करें:

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

#### 2. एसिंक्रोनस प्रोसेसिंग

I/O-बाउंड ऑपरेशनों के लिए एसिंक्रोनस प्रोग्रामिंग पैटर्न का उपयोग करें:

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

#### 3. संसाधन थ्रॉटलिंग

ओवरलोड रोकने के लिए संसाधन थ्रॉटलिंग लागू करें:

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

### सुरक्षा के सर्वोत्तम अभ्यास

#### 1. इनपुट वैलिडेशन

इनपुट पैरामीटरों का हमेशा पूरी तरह से सत्यापन करें:

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

#### 2. प्राधिकरण जांच

उचित प्राधिकरण जांच लागू करें:

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

#### 3. संवेदनशील डेटा प्रबंधन

संवेदनशील डेटा को सावधानी से संभालें:

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

## MCP टूल्स के लिए परीक्षण के सर्वोत्तम अभ्यास

व्यापक परीक्षण सुनिश्चित करता है कि MCP टूल सही तरीके से काम करें, किनारे के मामलों को संभालें, और सिस्टम के बाकी हिस्सों के साथ सही ढंग से एकीकृत हों।

### यूनिट टेस्टिंग

#### 1. प्रत्येक टूल का पृथक परीक्षण करें

प्रत्येक टूल की कार्यक्षमता के लिए केंद्रित परीक्षण बनाएँ:

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

#### 2. स्कीमा वैलिडेशन परीक्षण

परीक्षण करें कि स्कीमा मान्य हैं और प्रतिबंधों को ठीक से लागू करते हैं:

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

#### 3. त्रुटि प्रबंधन परीक्षण

त्रुटि स्थितियों के लिए विशिष्ट परीक्षण बनाएँ:

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

### इंटीग्रेशन टेस्टिंग

#### 1. टूल चेन परीक्षण

अपेक्षित संयोजनों में टूल्स के साथ परीक्षण करें:

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

#### 2. MCP सर्वर परीक्षण

पूरे टूल पंजीकरण और निष्पादन के साथ MCP सर्वर का परीक्षण करें:

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

#### 3. एंड-टू-एंड परीक्षण

मॉडल प्रॉम्प्ट से लेकर टूल निष्पादन तक पूर्ण वर्कफ़्लो का परीक्षण करें:

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

#### 1. लोड परीक्षण

परीक्षण करें कि आपका MCP सर्वर कितनी समवर्ती अनुरोधों को संभाल सकता है:

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

#### 2. स्ट्रेस परीक्षण

अत्यधिक लोड के तहत सिस्टम का परीक्षण करें:

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

#### 3. निगरानी और प्रोफाइलिंग

दीर्घकालिक प्रदर्शन विश्लेषण के लिए निगरानी सेट करें:

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

## MCP वर्कफ़्लो डिज़ाइन पैटर्न

अच्छी तरह से डिज़ाइन किए गए MCP वर्कफ़्लो दक्षता, विश्वसनीयता और अनुरक्षणीयता बढ़ाते हैं। यहां प्रमुख पैटर्न दिए गए हैं:

### 1. टूल्स की श्रृंखला पैटर्न

एक के बाद एक कई टूल्स को जोड़ें जहाँ प्रत्येक टूल का आउटपुट अगले के लिए इनपुट बनता है:

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

### 2. डिस्पैचर पैटर्न

एक केंद्रीय टूल का उपयोग करें जो इनपुट के आधार पर विशेषज्ञ टूल्स को भेजता है:

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

### 3. समानांतर प्रोसेसिंग पैटर्न

दक्षता के लिए कई टूल्स को एक साथ निष्पादित करें:

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

### 4. त्रुटि पुनर्प्राप्ति पैटर्न

टूल विफलताओं के लिए सहज फॉलबैक्स लागू करें:

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

### 5. वर्कफ़्लो कंपोजिशन पैटर्न

सरल वर्कफ़्लो को मिलाकर जटिल वर्कफ़्लो बनाएं:

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

# MCP सर्वरों का परीक्षण: सर्वोत्तम अभ्यास और शीर्ष सुझाव

## अवलोकन

परीक्षण विश्वसनीय, उच्च गुणवत्ता वाले MCP सर्वरों के विकास का एक महत्वपूर्ण पहलू है। यह मार्गदर्शिका यूनिट टेस्ट से लेकर इंटीग्रेशन टेस्ट और एंड-टू-एंड सत्यापन तक आपके MCP सर्वरों के परीक्षण के लिए व्यापक सर्वोत्तम अभ्यास और सुझाव प्रदान करती है।

## MCP सर्वरों के लिए परीक्षण क्यों महत्वपूर्ण है

MCP सर्वर AI मॉडल और क्लाइंट एप्लिकेशन के बीच महत्वपूर्ण मिडलवेयर के रूप में कार्य करते हैं। व्यापक परीक्षण सुनिश्चित करता है:

- उत्पादन वातावरण में विश्वसनीयता
- अनुरोध और प्रतिक्रियाओं का सही प्रबंधन
- MCP विनिर्देशों का सही कार्यान्वयन
- विफलताओं और किनारे के मामलों के प्रति लचीलापन
- विभिन्न लोड के तहत स्थिर प्रदर्शन

## MCP सर्वरों के लिए यूनिट टेस्टिंग

### यूनिट टेस्टिंग (बुनियाद)

यूनिट टेस्ट आपके MCP सर्वर के व्यक्तिगत घटकों का पृथक सत्यापन करते हैं।

#### क्या परीक्षण करें

1. **रिसोर्स हैंडलर**: प्रत्येक रिसोर्स हैंडलर के लॉजिक का स्वतंत्र परीक्षण करें
2. **टूल कार्यान्वयन**: विभिन्न इनपुट के साथ टूल व्यवहार की पुष्टि करें
3. **प्रॉम्प्ट टेम्प्लेट्स**: सुनिश्चित करें कि प्रॉम्प्ट टेम्प्लेट सही ढंग से रेंडर होते हैं
4. **स्कीमा वैलिडेशन**: पैरामीटर वैलिडेशन लॉजिक का परीक्षण करें
5. **त्रुटि प्रबंधन**: अवैध इनपुट के लिए त्रुटि प्रतिक्रियाओं की पुष्टि करें

#### यूनिट टेस्टिंग के सर्वोत्तम अभ्यास

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

### इंटीग्रेशन टेस्टिंग (मध्य स्तर)

इंटीग्रेशन टेस्ट MCP सर्वर के घटकों के बीच इंटरैक्शन का सत्यापन करते हैं।

#### क्या परीक्षण करें

1. **सर्वर प्रारंभिकरण**: विभिन्न कॉन्फ़िगरेशन के साथ सर्वर स्टार्टअप का परीक्षण करें
2. **रूट पंजीकरण**: सुनिश्चित करें कि सभी एंडपॉइंट सही तरीके से पंजीकृत हैं
3. **अनुरोध प्रसंस्करण**: पूर्ण अनुरोध-प्रतिक्रिया चक्र का परीक्षण करें
4. **त्रुटि प्रसार**: सुनिश्चित करें कि त्रुटियाँ घटकों के बीच ठीक से संभाली जाती हैं
5. **प्रमाणीकरण और प्राधिकरण**: सुरक्षा तंत्रों का परीक्षण करें

#### इंटीग्रेशन टेस्टिंग के सर्वोत्तम अभ्यास

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

### एंड-टू-एंड टेस्टिंग (शीर्ष स्तर)

एंड-टू-एंड टेस्ट क्लाइंट से सर्वर तक पूरे सिस्टम के व्यवहार का सत्यापन करते हैं।

#### क्या परीक्षण करें

1. **क्लाइंट-सर्वर संचार**: पूर्ण अनुरोध-प्रतिक्रिया चक्र का परीक्षण करें
2. **वास्तविक क्लाइंट SDKs**: वास्तविक क्लाइंट कार्यान्वयन के साथ परीक्षण करें
3. **लोड के तहत प्रदर्शन**: कई समवर्ती अनुरोधों के साथ व्यवहार की पुष्टि करें
4. **त्रुटि पुनर्प्राप्ति**: विफलताओं से सिस्टम की पुनर्प्राप्ति का परीक्षण करें
5. **दीर्घकालिक ऑपरेशन्स**: स्ट्रीमिंग और लंबी प्रक्रियाओं के प्रबंधन की पुष्टि करें

#### एंड-टू-एंड टेस्टिंग के सर्वोत्तम अभ्यास

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

## MCP परीक्षण के लिए मॉकिंग रणनीतियाँ

परीक्षण के दौरान घटकों को पृथक करने के लिए मॉकिंग आवश्यक है।

### मॉक करने वाले घटक

1. **बाहरी AI मॉडल**: पूर्वानुमेय परीक्षण के लिए मॉडल प्रतिक्रियाओं को मॉक करें
2. **बाहरी सेवाएँ**: API निर्भरताओं (डेटाबेस, थर्ड-पार्टी सेवाएँ) को मॉक करें
3. **प्रमाणीकरण सेवाएँ**: पहचान प्रदाताओं को मॉक करें
4. **रिसोर्स प्रदाता**: महंगे रिसोर्स हैंडलर को मॉक करें

### उदाहरण: AI मॉडल प्रतिक्रिया मॉक करना

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

प्रोडक्शन MCP सर्वरों के लिए प्रदर्शन परीक्षण आवश्यक है।

### क्या मापें

1. **लेटेंसी**: अनुरोधों के लिए प्रतिक्रिया समय
2. **थ्रूपुट**: प्रति सेकंड संभाले गए अनुरोध
3. **संसाधन उपयोग**: CPU, मेमोरी, नेटवर्क उपयोग
4. **समानांतरता प्रबंधन**: समानांतर अनुरोधों के तहत व्यवहार
5. **स्केलिंग विशेषताएँ**: लोड बढ़ने पर प्रदर्शन

### प्रदर्शन परीक्षण के उपकरण

- **k6**: ओपन-सोर्स लोड परीक्षण उपकरण
- **JMeter**: व्यापक प्रदर्शन परीक्षण
- **Locust**: पायथन-आधारित लोड परीक्षण
- **Azure Load Testing**: क्लाउड-आधारित प्रदर्शन परीक्षण

### उदाहरण: k6 के साथ बुनियादी लोड टेस्ट

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

## MCP सर्वरों के लिए परीक्षण स्वचालन

अपने परीक्षणों को स्वचालित करना गुणवत्ता में स्थिरता और तेज़ प्रतिक्रिया चक्र सुनिश्चित करता है।

### CI/CD एकीकरण

1. **पुल रिक्वेस्ट पर यूनिट टेस्ट चलाएं**: सुनिश्चित करें कि कोड परिवर्तन मौजूदा कार्यक्षमता को प्रभावित न करें
2. **स्टेजिंग में इंटीग्रेशन टेस्ट**: प्री-प्रोडक्शन वातावरण में इंटीग्रेशन टेस्ट चलाएं
3. **प्रदर्शन बेंचमार्क बनाए रखें**: प्रदर्शन में गिरावट पकड़ने के लिए बेंचमार्क बनाए रखें
4. **सुरक्षा स्कैन**: पाइपलाइन के हिस्से के रूप में सुरक्षा परीक्षण स्वचालित करें

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

## MCP विनिर्देश के साथ अनुपालन के लिए परीक्षण

सुनिश्चित करें कि आपका सर्वर MCP विनिर्देश को सही ढंग से लागू करता है।

### मुख्य अनुपालन क्षेत्र

1. **API एंडपॉइंट्स**: आवश्यक एंडपॉइंट (/resources, /tools, आदि) का परीक्षण करें
2. **अनुरोध/प्रतिक्रिया प्रारूप**: स्कीमा अनुपालन का सत्यापन करें
3. **त्रुटि कोड**: विभिन्न परिदृश्यों के लिए सही स्थिति कोड सुनिश्चित करें
4. **सामग्री प्रकार**: विभिन्न सामग्री प्रकारों का प्रबंधन परीक्षण करें
5. **प्रमाणीकरण प्रवाह**: विनिर्देश-अनुपालन ऑथ तंत्र की पुष्टि करें

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

## प्रभावी MCP सर्वर परीक्षण के शीर्ष 10 सुझाव

1. **टूल परिभाषाओं का अलग से परीक्षण करें**: टूल लॉजिक से स्वतंत्र रूप से स्कीमा परिभाषाओं की पुष्टि करें
2. **पैरामीटरयुक्त परीक्षण का उपयोग करें**: विभिन्न इनपुट, जिसमें किनारे के मामले भी शामिल हों, के साथ टूल्स का परीक्षण करें
3. **त्रुटि प्रतिक्रियाओं की जांच करें**: सभी संभावित त्रुटि स्थितियों के लिए उचित त्रुटि प्रबंधन की पुष्टि करें
4. **प्राधिकरण लॉजिक का परीक्षण करें**: विभिन्न उपयोगकर्ता भूमिकाओं के लिए उचित पहुँच नियंत्रण सुनिश्चित करें
5. **परीक्षण कवरेज पर निगरानी रखें**: महत्वपूर्ण पथ कोड का उच्च कवरेज लक्ष्य बनाएं
6. **स्ट्रीमिंग प्रतिक्रियाओं का परीक्षण करें**: स्ट्रीमिंग सामग्री के उचित प्रबंधन की पुष्टि करें
7. **नेटवर्क समस्याओं का अनुकरण करें**: खराब नेटवर्क स्थितियों में व्यवहार का परीक्षण करें
8. **रिसोर्स सीमाओं का परीक्षण करें**: कोटा या दर सीमाओं तक पहुँचने पर व्यवहार की पुष्टि करें
9. **रिग्रेशन परीक्षण स्वचालित करें**: हर कोड परिवर्तन पर चलने वाला परीक्षण सूट बनाएं
10. **परीक्षण मामलों का दस्तावेजीकरण करें**: परीक्षण परिदृश्यों का स्पष्ट दस्तावेज़ बनाए रखें

## सामान्य परीक्षण जाल

- **सिर्फ सफल मार्ग परीक्षण पर अधिक निर्भरता**: त्रुटि मामलों का व्यापक परीक्षण करें
- **प्रदर्शन परीक्षण की अनदेखी**: उत्पादन से पहले बाधाओं की पहचान करें
- **केवल पृथक परीक्षण**: यूनिट, इंटीग्रेशन, और एंड-टू-एंड परीक्षणों को मिलाएं
- **अपूर्ण API कवरेज**: सुनिश्चित करें कि सभी एंडपॉइंट और फीचर्स का परीक्षण हो
- **असंगत परीक्षण वातावरण**: सुसंगत परीक्षण वातावरण के लिए कंटेनर का उपयोग करें

## निष्कर्ष

एक व्यापक परीक्षण रणनीति विश्वसनीय, उच्च गुणवत्ता वाले MCP सर्वरों के विकास के लिए आवश्यक है। इस मार्गदर्शिका में उल्लिखित सर्वोत्तम अभ्यास और सुझावों को लागू करके, आप सुनिश्चित कर सकते हैं कि आपके MCP कार्यान्वयन गुणवत्ता, विश्वसनीयता और प्रदर्शन के उच्चतम मानकों को पूरा करें।

## मुख्य निष्कर्ष

1. **टूल डिजाइन**: सिंगल रिस्पॉन्सिबिलिटी प्रिंसिपल का पालन करें, डिपेंडेंसी इंजेक्शन का उपयोग करें, और कंपोज़ेबिलिटी के लिए डिजाइन करें
2. **स्कीमा डिजाइन**: स्पष्ट, अच्छी तरह से प्रलेखित स्कीमा बनाएं जिनमें उचित वैलिडेशन प्रतिबंध हों
3. **त्रुटि प्रबंधन**: सहज त्रुटि प्रबंधन, संरचित त्रुटि प्रतिक्रियाएँ, और पुनः प्रयास तर्क लागू करें
4. **प्रदर्शन**: कैशिंग, एसिंक्रोनस प्रोसेसिंग, और संसाधन थ्रॉटलिंग का उपयोग करें
5. **सुरक्षा**: पूरी तरह से इनपुट वैलिडेशन, प्राधिकरण जांच, और संवेदनशील डेटा प्रबंधन लागू करें
6. **परीक्षण**: व्यापक यूनिट, इंटीग्रेशन, और एंड-टू-एंड परीक्षण बनाएं
7. **वर्कफ़्लो पैटर्न**: चेन, डिस्पैचर, और समानांतर प्रोसेसिंग जैसे स्थापित पैटर्न लागू करें

## अभ्यास

एक दस्तावेज़ प्रसंस्करण प्रणाली के लिए MCP टूल और वर्कफ़

**अस्वीकरण**:  
इस दस्तावेज़ का अनुवाद AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या असंगतियाँ हो सकती हैं। मूल दस्तावेज़ को उसकी मूल भाषा में अधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सिफारिश की जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।