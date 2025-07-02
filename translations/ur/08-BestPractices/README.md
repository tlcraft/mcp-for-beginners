<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "10d7df03cff1fa3cf3c56dc06e82ba79",
  "translation_date": "2025-07-02T07:52:04+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "ur"
}
-->
# MCP کی ترقی کے بہترین طریقے

## جائزہ

یہ سبق MCP سرورز اور فیچرز کو پروڈکشن ماحول میں تیار کرنے، ٹیسٹ کرنے اور تعینات کرنے کے جدید بہترین طریقوں پر توجہ دیتا ہے۔ جیسے جیسے MCP ماحولیاتی نظام پیچیدہ اور اہم ہوتے جا رہے ہیں، قائم شدہ نمونوں پر عمل درآمد سے اعتماد، برقرار رکھنے کی سہولت اور باہمی تعامل کو یقینی بنایا جاتا ہے۔ یہ سبق حقیقی دنیا کی MCP تنصیبات سے حاصل شدہ عملی حکمت کو یکجا کرتا ہے تاکہ آپ کو مضبوط، موثر سرورز بنانے میں رہنمائی فراہم کی جا سکے جن میں موثر وسائل، پرامپٹس اور آلات شامل ہوں۔

## سیکھنے کے مقاصد

اس سبق کے اختتام تک، آپ قابل ہوں گے:
- MCP سرور اور فیچر ڈیزائن میں صنعتی بہترین طریقے اپنانا
- MCP سرورز کے لیے جامع ٹیسٹنگ حکمت عملی تیار کرنا
- پیچیدہ MCP ایپلیکیشنز کے لیے مؤثر، قابل استعمال ورک فلو پیٹرنز ڈیزائن کرنا
- MCP سرورز میں مناسب ایرر ہینڈلنگ، لاگنگ اور آبزرویبیلیٹی نافذ کرنا
- کارکردگی، سیکورٹی اور برقرار رکھنے کی صلاحیت کے لیے MCP تنصیبات کو بہتر بنانا

## اضافی حوالہ جات

MCP کے بہترین طریقوں کی تازہ ترین معلومات کے لیے رجوع کریں:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## MCP ٹول کی ترقی کے بہترین طریقے

### معماری اصول

#### 1. واحد ذمہ داری کا اصول

ہر MCP فیچر کا ایک واضح اور مخصوص مقصد ہونا چاہیے۔ ایسے ایک ہی وقت میں متعدد امور سنبھالنے والے بڑے ٹولز بنانے کے بجائے، مخصوص کاموں میں مہارت رکھنے والے خصوصی ٹولز تیار کریں۔

**اچھا مثال:**
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

**خراب مثال:**
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

#### 2. انحصار کی انجیکشن اور ٹیسٹ ایبلٹی

ٹولز کو اس طرح ڈیزائن کریں کہ ان کی انحصاریاں کنسٹرکٹر انجیکشن کے ذریعے ملیں، تاکہ وہ ٹیسٹ کرنے اور ترتیب دینے کے قابل ہوں:

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

#### 3. جوڑنے والے ٹولز

ایسے ٹولز ڈیزائن کریں جنہیں مل کر زیادہ پیچیدہ ورک فلو بنانے کے لیے جوڑا جا سکے:

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

### اسکیمہ ڈیزائن کے بہترین طریقے

اسکیمہ ماڈل اور آپ کے ٹول کے درمیان معاہدہ ہے۔ اچھی طرح ڈیزائن کردہ اسکیمے ٹول کی استعمال میں بہتری لاتے ہیں۔

#### 1. واضح پیرامیٹر کی وضاحتیں

ہر پیرامیٹر کے لیے ہمیشہ وضاحتی معلومات شامل کریں:

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

#### 2. تصدیقی پابندیاں

غلط ان پٹ سے بچنے کے لیے تصدیقی پابندیاں شامل کریں:

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

#### 3. مستقل واپسی کے ڈھانچے

اپنے ردعمل کے ڈھانچوں میں تسلسل رکھیں تاکہ ماڈلز کے لیے نتائج کو سمجھنا آسان ہو:

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

### ایرر ہینڈلنگ

MCP ٹولز کی بھروسہ مندی برقرار رکھنے کے لیے مضبوط ایرر ہینڈلنگ ضروری ہے۔

#### 1. نرم مزاجی سے ایرر ہینڈلنگ

مناسب سطحوں پر ایررز کو ہینڈل کریں اور معلوماتی پیغامات فراہم کریں:

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

#### 2. ساختہ ایرر ردعمل

جب ممکن ہو تو ساختہ ایرر معلومات واپس کریں:

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

#### 3. ری ٹرائی لاجک

عارضی ناکامیوں کے لیے مناسب ری ٹرائی لاجک نافذ کریں:

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

### کارکردگی کی بہتری

#### 1. کیشنگ

مہنگے آپریشنز کے لیے کیشنگ نافذ کریں:

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

#### 2. غیر متزامن پروسیسنگ

I/O پر مبنی آپریشنز کے لیے غیر متزامن پروگرامنگ پیٹرنز استعمال کریں:

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

#### 3. وسائل کی تھروٹلنگ

اوورلوڈ سے بچنے کے لیے وسائل کی تھروٹلنگ نافذ کریں:

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

### سیکورٹی کے بہترین طریقے

#### 1. ان پٹ کی تصدیق

ہمیشہ ان پٹ پیرامیٹرز کی مکمل تصدیق کریں:

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

#### 2. اجازت چیک

مناسب اجازت چیک نافذ کریں:

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

#### 3. حساس ڈیٹا کا ہینڈلنگ

حساس ڈیٹا کو احتیاط سے سنبھالیں:

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

## MCP ٹولز کے لیے ٹیسٹنگ کے بہترین طریقے

جامع ٹیسٹنگ اس بات کو یقینی بناتی ہے کہ MCP ٹولز صحیح کام کریں، ایج کیسز کو ہینڈل کریں، اور نظام کے باقی حصوں کے ساتھ مناسب انضمام کریں۔

### یونٹ ٹیسٹنگ

#### 1. ہر ٹول کو الگ تھلگ ٹیسٹ کریں

ہر ٹول کی فعالیت کے لیے مخصوص ٹیسٹ بنائیں:

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

#### 2. اسکیمہ ویلیڈیشن ٹیسٹنگ

ٹیسٹ کریں کہ اسکیمے درست ہیں اور پابندیاں صحیح طریقے سے نافذ کر رہے ہیں:

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

#### 3. ایرر ہینڈلنگ ٹیسٹ

ایرر کی حالتوں کے لیے مخصوص ٹیسٹ بنائیں:

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

### انٹیگریشن ٹیسٹنگ

#### 1. ٹول چین ٹیسٹنگ

متوقع امتزاج میں مل کر کام کرنے والے ٹولز کی جانچ کریں:

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

#### 2. MCP سرور ٹیسٹنگ

مکمل ٹول رجسٹریشن اور عمل درآمد کے ساتھ MCP سرور کی جانچ کریں:

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

#### 3. اینڈ ٹو اینڈ ٹیسٹنگ

ماڈل پرامپٹ سے لے کر ٹول کے عمل تک مکمل ورک فلو کی جانچ کریں:

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

### کارکردگی کی ٹیسٹنگ

#### 1. لوڈ ٹیسٹنگ

جانچیں کہ آپ کا MCP سرور کتنی بیک وقت درخواستیں سنبھال سکتا ہے:

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

#### 2. اسٹریس ٹیسٹنگ

انتہائی لوڈ کے تحت نظام کی جانچ کریں:

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

#### 3. مانیٹرنگ اور پروفائلنگ

طویل مدتی کارکردگی کے تجزیے کے لیے مانیٹرنگ سیٹ اپ کریں:

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

## MCP ورک فلو ڈیزائن پیٹرنز

اچھے ڈیزائن کیے گئے MCP ورک فلو کارکردگی، بھروسہ مندی، اور برقرار رکھنے کی سہولت کو بہتر بناتے ہیں۔ یہاں کلیدی پیٹرنز دیے گئے ہیں:

### 1. چین آف ٹولز پیٹرن

متعدد ٹولز کو اس طرح جوڑیں کہ ہر ٹول کا آؤٹ پٹ اگلے کے ان پٹ کے طور پر کام کرے:

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

### 2. ڈسپیچر پیٹرن

ایک مرکزی ٹول استعمال کریں جو ان پٹ کی بنیاد پر مخصوص ٹولز کو بھیجے:

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

### 3. متوازی پروسیسنگ پیٹرن

زیادہ کارکردگی کے لیے متعدد ٹولز کو بیک وقت چلائیں:

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

### 4. ایرر ریکوری پیٹرن

ٹول کی ناکامیوں کے لیے نرم مزاجی سے متبادل راستے نافذ کریں:

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

### 5. ورک فلو کمپوزیشن پیٹرن

سادہ ورک فلو کو جوڑ کر پیچیدہ ورک فلو بنائیں:

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

# MCP سرورز کی ٹیسٹنگ: بہترین طریقے اور اہم نکات

## جائزہ

ٹیسٹنگ MCP سرورز کی قابل اعتماد اور اعلیٰ معیار کی ترقی کا ایک اہم پہلو ہے۔ یہ رہنما آپ کے MCP سرورز کی ترقی کے دوران یونٹ ٹیسٹ سے لے کر انٹیگریشن ٹیسٹ اور اینڈ ٹو اینڈ ویلیڈیشن تک جامع بہترین طریقے اور نکات فراہم کرتا ہے۔

## MCP سرورز کے لیے ٹیسٹنگ کیوں ضروری ہے

MCP سرورز AI ماڈلز اور کلائنٹ ایپلیکیشنز کے درمیان ایک اہم مڈل ویئر کا کردار ادا کرتے ہیں۔ مکمل ٹیسٹنگ یقینی بناتی ہے کہ:

- پروڈکشن ماحول میں اعتماد قائم رہے
- درخواستوں اور جوابات کو درست طریقے سے ہینڈل کیا جائے
- MCP وضاحتوں کا مناسب نفاذ ہو
- ناکامیوں اور ایج کیسز کے خلاف مزاحمت ہو
- مختلف بوجھ کے تحت مستقل کارکردگی برقرار رہے

## MCP سرورز کے لیے یونٹ ٹیسٹنگ

### یونٹ ٹیسٹنگ (بنیاد)

یونٹ ٹیسٹ آپ کے MCP سرور کے انفرادی اجزاء کو الگ تھلگ طور پر جانچتے ہیں۔

#### کیا ٹیسٹ کرنا ہے

1. **Resource Handlers**: ہر resource handler کی منطق کو الگ سے ٹیسٹ کریں
2. **Tool Implementations**: مختلف ان پٹس کے ساتھ ٹول کے رویے کی تصدیق کریں
3. **Prompt Templates**: یقینی بنائیں کہ پرامپٹ ٹیمپلیٹس درست طور پر رینڈر ہوتے ہیں
4. **Schema Validation**: پیرامیٹر کی تصدیقی منطق کو ٹیسٹ کریں
5. **Error Handling**: غلط ان پٹ کے لیے ایرر ردعمل کی تصدیق کریں

#### یونٹ ٹیسٹنگ کے بہترین طریقے

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

### انٹیگریشن ٹیسٹنگ (درمیانی سطح)

انٹیگریشن ٹیسٹ آپ کے MCP سرور کے اجزاء کے درمیان تعاملات کی تصدیق کرتے ہیں۔

#### کیا ٹیسٹ کرنا ہے

1. **Server Initialization**: مختلف ترتیبوں کے ساتھ سرور کی شروعات کی جانچ کریں
2. **Route Registration**: تصدیق کریں کہ تمام اینڈ پوائنٹس درست طریقے سے رجسٹرڈ ہیں
3. **Request Processing**: مکمل درخواست-جواب سائیکل کی جانچ کریں
4. **Error Propagation**: یقینی بنائیں کہ ایررز اجزاء کے درمیان صحیح طریقے سے منتقل ہوتے ہیں
5. **Authentication & Authorization**: سیکورٹی میکانزم کی جانچ کریں

#### انٹیگریشن ٹیسٹنگ کے بہترین طریقے

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

### اینڈ ٹو اینڈ ٹیسٹنگ (اعلیٰ سطح)

اینڈ ٹو اینڈ ٹیسٹ کلائنٹ سے سرور تک مکمل نظام کے رویے کی تصدیق کرتے ہیں۔

#### کیا ٹیسٹ کرنا ہے

1. **Client-Server Communication**: مکمل درخواست-جواب سائیکل کی جانچ کریں
2. **Real Client SDKs**: حقیقی کلائنٹ نفاذ کے ساتھ ٹیسٹ کریں
3. **Performance Under Load**: متعدد بیک وقت درخواستوں کے ساتھ رویے کی تصدیق کریں
4. **Error Recovery**: ناکامیوں سے نظام کی بحالی کی جانچ کریں
5. **Long-Running Operations**: سٹریمنگ اور طویل آپریشنز کے ہینڈلنگ کی تصدیق کریں

#### اینڈ ٹو اینڈ ٹیسٹنگ کے بہترین طریقے

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

## MCP ٹیسٹنگ کے لیے موکنگ حکمت عملی

موکنگ ٹیسٹنگ کے دوران اجزاء کو الگ کرنے کے لیے ضروری ہے۔

### موک کرنے والے اجزاء

1. **External AI Models**: متوقع ٹیسٹنگ کے لیے ماڈل ردعمل کو موک کریں
2. **External Services**: API انحصار (ڈیٹا بیسز، تھرڈ پارٹی سروسز) کو موک کریں
3. **Authentication Services**: شناخت فراہم کرنے والوں کو موک کریں
4. **Resource Providers**: مہنگے resource handlers کو موک کریں

### مثال: AI ماڈل کے ردعمل کی موکنگ

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

## کارکردگی کی ٹیسٹنگ

کارکردگی کی ٹیسٹنگ پروڈکشن MCP سرورز کے لیے ضروری ہے۔

### کیا ناپنا ہے

1. **Latency**: درخواستوں کے لیے ردعمل کا وقت
2. **Throughput**: سیکنڈ میں ہینڈل کی جانے والی درخواستیں
3. **Resource Utilization**: CPU، میموری، نیٹ ورک کا استعمال
4. **Concurrency Handling**: متوازی درخواستوں کے تحت رویہ
5. **Scaling Characteristics**: بوجھ بڑھنے پر کارکردگی

### کارکردگی کی ٹیسٹنگ کے آلات

- **k6**: اوپن سورس لوڈ ٹیسٹنگ ٹول
- **JMeter**: جامع کارکردگی کی جانچ
- **Locust**: پائتھون پر مبنی لوڈ ٹیسٹنگ
- **Azure Load Testing**: کلاؤڈ بیسڈ کارکردگی کی جانچ

### مثال: k6 کے ساتھ بنیادی لوڈ ٹیسٹ

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

## MCP سرورز کے لیے ٹیسٹ آٹومیشن

آپ کے ٹیسٹوں کو خودکار بنانا معیار کی مستقل مزاجی اور تیز فیڈبیک لوپس کو یقینی بناتا ہے۔

### CI/CD انٹیگریشن

1. **Run Unit Tests on Pull Requests**: یقینی بنائیں کہ کوڈ کی تبدیلیاں موجودہ فعالیت کو خراب نہ کریں
2. **Integration Tests in Staging**: پری پروڈکشن ماحول میں انٹیگریشن ٹیسٹ چلائیں
3. **Performance Baselines**: کارکردگی کے معیار کو برقرار رکھیں تاکہ ریگریشن پکڑی جا سکے
4. **Security Scans**: سیکورٹی ٹیسٹنگ کو پائپ لائن کا حصہ بنائیں

### مثال CI پائپ لائن (GitHub Actions)

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

## MCP وضاحت کے مطابق ٹیسٹنگ

یقینی بنائیں کہ آپ کا سرور MCP وضاحت کو صحیح طریقے سے نافذ کرتا ہے۔

### کلیدی تعمیل کے علاقے

1. **API Endpoints**: ضروری اینڈ پوائنٹس (/resources, /tools وغیرہ) کی جانچ کریں
2. **Request/Response Format**: اسکیمہ کی تعمیل کی تصدیق کریں
3. **Error Codes**: مختلف حالات کے لیے درست اسٹیٹس کوڈز کی جانچ کریں
4. **Content Types**: مختلف مواد کی اقسام کی ہینڈلنگ ٹیسٹ کریں
5. **Authentication Flow**: وضاحت کے مطابق تصدیقی میکانزم کی جانچ کریں

### تعمیل ٹیسٹ سوئٹ

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

## موثر MCP سرور ٹیسٹنگ کے لیے 10 اہم نکات

1. **ٹول کی تعریفوں کو الگ سے ٹیسٹ کریں**: اسکیمہ تعریفوں کی آزادانہ تصدیق کریں
2. **پیرامیٹرائزڈ ٹیسٹ استعمال کریں**: مختلف ان پٹس بشمول ایج کیسز کے ساتھ ٹولز کو ٹیسٹ کریں
3. **ایرر ردعمل چیک کریں**: تمام ممکنہ ایرر حالتوں کے لیے مناسب ایرر ہینڈلنگ کی تصدیق کریں
4. **اجازت لاجک ٹیسٹ کریں**: مختلف صارف کرداروں کے لیے مناسب رسائی کنٹرول کو یقینی بنائیں
5. **ٹیسٹ کوریج کی نگرانی کریں**: اہم راستے کے کوڈ کی زیادہ سے زیادہ کوریج کا ہدف رکھیں
6. **سٹریمنگ ردعمل ٹیسٹ کریں**: سٹریمنگ مواد کی مناسب ہینڈلنگ کی تصدیق کریں
7. **نیٹ ورک مسائل کی نقل کریں**: خراب نیٹ ورک حالات میں رویہ ٹیسٹ کریں
8. **وسائل کی حدود ٹیسٹ کریں**: کوٹہ یا ریٹ لمٹس پہنچنے پر رویے کی تصدیق کریں
9. **ریگریشن ٹیسٹ خودکار بنائیں**: ہر کوڈ تبدیلی پر چلنے والا سوئٹ بنائیں
10. **ٹیسٹ کیسز کی دستاویزات تیار کریں**: ٹیسٹ منظرناموں کی واضح دستاویزات برقرار رکھیں

## عام ٹیسٹنگ کی غلطیاں

- **صرف خوشگوار راستے کی ٹیسٹنگ پر انحصار**: ایرر کیسز کی مکمل جانچ کریں
- **کارکردگی کی ٹیسٹنگ کی نظراندازی**: پروڈکشن سے پہلے رکاوٹوں کی شناخت کریں
- **صرف الگ تھلگ ٹیسٹنگ**: یونٹ، انٹیگریشن، اور اینڈ ٹو اینڈ ٹیسٹ کا امتزاج کریں
- **نامکمل API کوریج**: تمام اینڈ پوائنٹس اور فیچرز کی جانچ یقینی بنائیں
- **ناقابل اعتماد ٹیسٹ ماحول**: مستقل ٹیسٹ ماحول کے لیے کنٹینرز استعمال کریں

## نتیجہ

ایک جامع ٹیسٹنگ حکمت عملی قابل اعتماد، اعلیٰ معیار کے MCP سرورز کی ترقی کے لیے ضروری ہے۔ اس رہنما میں بیان کردہ بہترین طریقوں اور نکات پر عمل کر کے، آپ اپنی MCP تنصیبات کو اعلیٰ معیار، بھروسہ مندی، اور کارکردگی کے معیار پر پورا اترنے کو یقینی بنا سکتے ہیں۔

## کلیدی نکات

1. **ٹول ڈیزائن**: واحد ذمہ داری کے اصول پر عمل کریں، dependency injection استعمال کریں، اور جوڑنے کے لیے ڈیزائن کریں
2. **اسکیمہ ڈیزائن**: واضح، دستاویزی اسکیمے بنائیں جن میں مناسب تصدیقی پابندیاں ہوں
3. **ایرر ہینڈلنگ**: نرم مزاجی سے ایرر ہینڈلنگ، ساختہ ایرر ردعمل، اور ری ٹرائی لاجک نافذ کریں
4. **کارکردگی**: کیشنگ، غیر متزامن پروسیسنگ، اور وسائل کی تھروٹلنگ استعمال کریں
5. **سیکورٹی**: مکمل ان پٹ تصدیق، اجازت

**دستبرداری**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کی کوشش کرتے ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا عدم صحت ہو سکتی ہے۔ اصل دستاویز اپنی مادری زبان میں مستند ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ورانہ انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر عائد نہیں ہوتی۔