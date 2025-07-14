<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "10d7df03cff1fa3cf3c56dc06e82ba79",
  "translation_date": "2025-07-14T04:56:31+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "bn"
}
-->
# MCP ডেভেলপমেন্ট সেরা অনুশীলনসমূহ

## ওভারভিউ

এই পাঠে MCP সার্ভার এবং ফিচারগুলো প্রোডাকশন পরিবেশে ডেভেলপ, টেস্ট এবং ডিপ্লয় করার উন্নত সেরা অনুশীলনসমূহের ওপর গুরুত্ব দেওয়া হয়েছে। MCP ইকোসিস্টেম যতই জটিল এবং গুরুত্বপূর্ণ হয়ে উঠছে, প্রতিষ্ঠিত প্যাটার্ন অনুসরণ করলে নির্ভরযোগ্যতা, রক্ষণাবেক্ষণযোগ্যতা এবং আন্তঃপরিচালন ক্ষমতা নিশ্চিত হয়। এই পাঠ বাস্তব MCP বাস্তবায়ন থেকে প্রাপ্ত ব্যবহারিক জ্ঞান একত্রিত করে আপনাকে শক্তিশালী, দক্ষ সার্ভার তৈরি করতে গাইড করবে, যেখানে কার্যকর রিসোর্স, প্রম্পট এবং টুলস থাকবে।

## শেখার উদ্দেশ্যসমূহ

এই পাঠ শেষ করার পর আপনি সক্ষম হবেন:
- MCP সার্ভার এবং ফিচার ডিজাইনে শিল্পের সেরা অনুশীলন প্রয়োগ করতে
- MCP সার্ভারের জন্য ব্যাপক টেস্টিং কৌশল তৈরি করতে
- জটিল MCP অ্যাপ্লিকেশনের জন্য দক্ষ, পুনঃব্যবহারযোগ্য ওয়ার্কফ্লো প্যাটার্ন ডিজাইন করতে
- MCP সার্ভারে সঠিক এরর হ্যান্ডলিং, লগিং এবং অবজারভেবিলিটি বাস্তবায়ন করতে
- পারফরম্যান্স, সিকিউরিটি এবং রক্ষণাবেক্ষণযোগ্যতার জন্য MCP বাস্তবায়ন অপ্টিমাইজ করতে

## অতিরিক্ত রেফারেন্স

MCP সেরা অনুশীলন সম্পর্কে সর্বশেষ তথ্যের জন্য দেখুন:
- [MCP ডকুমেন্টেশন](https://modelcontextprotocol.io/)
- [MCP স্পেসিফিকেশন](https://spec.modelcontextprotocol.io/)
- [GitHub রিপোজিটরি](https://github.com/modelcontextprotocol)

## MCP টুল ডেভেলপমেন্ট সেরা অনুশীলনসমূহ

### আর্কিটেকচারাল নীতিমালা

#### ১. সিঙ্গেল রেসপন্সিবিলিটি প্রিন্সিপল

প্রতিটি MCP ফিচারের একটি স্পষ্ট, কেন্দ্রীভূত উদ্দেশ্য থাকা উচিত। একাধিক বিষয় একসাথে সামলানোর চেষ্টা করে মনোলিথিক টুল তৈরি করার পরিবর্তে, নির্দিষ্ট কাজের জন্য বিশেষায়িত টুল তৈরি করুন যা সেই কাজগুলোতে দক্ষ।

**ভালো উদাহরণ:**
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

**খারাপ উদাহরণ:**
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

#### ২. ডিপেন্ডেন্সি ইনজেকশন এবং টেস্টেবিলিটি

টুলগুলো এমনভাবে ডিজাইন করুন যাতে তাদের ডিপেন্ডেন্সি কনস্ট্রাক্টর ইনজেকশনের মাধ্যমে পাওয়া যায়, যা টেস্ট করা এবং কনফিগার করা সহজ করে তোলে:

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

#### ৩. কম্পোজেবল টুলস

এমন টুল ডিজাইন করুন যা একসাথে কম্পোজ করে আরও জটিল ওয়ার্কফ্লো তৈরি করা যায়:

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

### স্কিমা ডিজাইনের সেরা অনুশীলনসমূহ

স্কিমা হলো মডেল এবং আপনার টুলের মধ্যে চুক্তি। ভালো ডিজাইন করা স্কিমা টুল ব্যবহারে সুবিধা দেয়।

#### ১. স্পষ্ট প্যারামিটার বর্ণনা

প্রতিটি প্যারামিটারের জন্য বর্ণনামূলক তথ্য অবশ্যই অন্তর্ভুক্ত করুন:

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

#### ২. ভ্যালিডেশন কনস্ট্রেইন্টস

অবৈধ ইনপুট প্রতিরোধে ভ্যালিডেশন কনস্ট্রেইন্টস অন্তর্ভুক্ত করুন:

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

#### ৩. সঙ্গতিপূর্ণ রিটার্ন স্ট্রাকচার

মডেলগুলো ফলাফল সহজে ব্যাখ্যা করতে পারে সেজন্য আপনার রেসপন্স স্ট্রাকচারে ধারাবাহিকতা বজায় রাখুন:

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

### এরর হ্যান্ডলিং

MCP টুলের নির্ভরযোগ্যতা বজায় রাখতে শক্তিশালী এরর হ্যান্ডলিং অপরিহার্য।

#### ১. নম্র এরর হ্যান্ডলিং

উপযুক্ত স্তরে এরর হ্যান্ডলিং করুন এবং তথ্যবহুল মেসেজ প্রদান করুন:

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

#### ২. স্ট্রাকচার্ড এরর রেসপন্স

সম্ভব হলে স্ট্রাকচার্ড এরর তথ্য রিটার্ন করুন:

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

#### ৩. রিট্রাই লজিক

অস্থায়ী ব্যর্থতার জন্য উপযুক্ত রিট্রাই লজিক বাস্তবায়ন করুন:

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

### পারফরম্যান্স অপ্টিমাইজেশন

#### ১. ক্যাশিং

দামী অপারেশনের জন্য ক্যাশিং বাস্তবায়ন করুন:

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

#### ২. অ্যাসিঙ্ক্রোনাস প্রসেসিং

I/O-সংক্রান্ত অপারেশনের জন্য অ্যাসিঙ্ক্রোনাস প্রোগ্রামিং প্যাটার্ন ব্যবহার করুন:

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

#### ৩. রিসোর্স থ্রটলিং

ওভারলোড প্রতিরোধে রিসোর্স থ্রটলিং বাস্তবায়ন করুন:

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

### সিকিউরিটি সেরা অনুশীলনসমূহ

#### ১. ইনপুট ভ্যালিডেশন

ইনপুট প্যারামিটারগুলো সবসময় ভালোভাবে যাচাই করুন:

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

#### ২. অথরাইজেশন চেকস

সঠিক অথরাইজেশন চেকস বাস্তবায়ন করুন:

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

#### ৩. সংবেদনশীল ডেটা হ্যান্ডলিং

সংবেদনশীল ডেটা সাবধানে পরিচালনা করুন:

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

## MCP টুলসের জন্য টেস্টিং সেরা অনুশীলনসমূহ

ব্যাপক টেস্টিং নিশ্চিত করে MCP টুলস সঠিকভাবে কাজ করে, এজ কেসগুলো সামলায় এবং সিস্টেমের সাথে সঠিকভাবে ইন্টিগ্রেট হয়।

### ইউনিট টেস্টিং

#### ১. প্রতিটি টুল আলাদাভাবে টেস্ট করুন

প্রতিটি টুলের কার্যকারিতার জন্য কেন্দ্রীভূত টেস্ট তৈরি করুন:

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

#### ২. স্কিমা ভ্যালিডেশন টেস্টিং

স্কিমাগুলো বৈধ এবং সঠিকভাবে কনস্ট্রেইন্টস প্রয়োগ করছে কিনা পরীক্ষা করুন:

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

#### ৩. এরর হ্যান্ডলিং টেস্ট

এরর কন্ডিশনের জন্য নির্দিষ্ট টেস্ট তৈরি করুন:

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

### ইন্টিগ্রেশন টেস্টিং

#### ১. টুল চেইন টেস্টিং

প্রত্যাশিত কম্বিনেশনে টুলগুলো একসাথে কাজ করছে কিনা পরীক্ষা করুন:

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

#### ২. MCP সার্ভার টেস্টিং

পূর্ণ টুল রেজিস্ট্রেশন এবং এক্সিকিউশনের সাথে MCP সার্ভার টেস্ট করুন:

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

#### ৩. এন্ড-টু-এন্ড টেস্টিং

মডেল প্রম্পট থেকে টুল এক্সিকিউশন পর্যন্ত সম্পূর্ণ ওয়ার্কফ্লো টেস্ট করুন:

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

### পারফরম্যান্স টেস্টিং

#### ১. লোড টেস্টিং

আপনার MCP সার্ভার কতগুলো সমান্তরাল রিকোয়েস্ট সামলাতে পারে তা পরীক্ষা করুন:

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

#### ২. স্ট্রেস টেস্টিং

চরম লোডের অধীনে সিস্টেম পরীক্ষা করুন:

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

#### ৩. মনিটরিং এবং প্রোফাইলিং

দীর্ঘমেয়াদী পারফরম্যান্স বিশ্লেষণের জন্য মনিটরিং সেটআপ করুন:

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

## MCP ওয়ার্কফ্লো ডিজাইন প্যাটার্নস

ভাল ডিজাইন করা MCP ওয়ার্কফ্লো দক্ষতা, নির্ভরযোগ্যতা এবং রক্ষণাবেক্ষণযোগ্যতা উন্নত করে। এখানে অনুসরণ করার জন্য মূল প্যাটার্নগুলো:

### ১. চেইন অফ টুলস প্যাটার্ন

একাধিক টুলকে এমনভাবে সংযুক্ত করুন যেখানে প্রতিটি টুলের আউটপুট পরবর্তী টুলের ইনপুট হয়:

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

### ২. ডিসপ্যাচার প্যাটার্ন

একটি কেন্দ্রীয় টুল ব্যবহার করুন যা ইনপুট অনুযায়ী বিশেষায়িত টুলগুলোতে ডিসপ্যাচ করে:

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

### ৩. প্যারালাল প্রসেসিং প্যাটার্ন

দক্ষতার জন্য একসাথে একাধিক টুল এক্সিকিউট করুন:

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

### ৪. এরর রিকভারি প্যাটার্ন

টুল ব্যর্থতার জন্য নম্র ফ্যালব্যাক বাস্তবায়ন করুন:

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

### ৫. ওয়ার্কফ্লো কম্পোজিশন প্যাটার্ন

সহজ ওয়ার্কফ্লো কম্পোজ করে জটিল ওয়ার্কফ্লো তৈরি করুন:

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

# MCP সার্ভার টেস্টিং: সেরা অনুশীলন এবং শীর্ষ টিপস

## ওভারভিউ

টেস্টিং MCP সার্ভার ডেভেলপমেন্টের একটি গুরুত্বপূর্ণ দিক। এই গাইডটি ইউনিট টেস্ট থেকে ইন্টিগ্রেশন টেস্ট এবং এন্ড-টু-এন্ড ভ্যালিডেশন পর্যন্ত MCP সার্ভার টেস্টিংয়ের ব্যাপক সেরা অনুশীলন এবং টিপস প্রদান করে।

## MCP সার্ভারের জন্য টেস্টিং কেন গুরুত্বপূর্ণ

MCP সার্ভার AI মডেল এবং ক্লায়েন্ট অ্যাপ্লিকেশনের মধ্যে গুরুত্বপূর্ণ মিডলওয়্যার হিসেবে কাজ করে। ব্যাপক টেস্টিং নিশ্চিত করে:

- প্রোডাকশন পরিবেশে নির্ভরযোগ্যতা
- রিকোয়েস্ট এবং রেসপন্স সঠিকভাবে হ্যান্ডলিং
- MCP স্পেসিফিকেশন সঠিক বাস্তবায়ন
- ব্যর্থতা এবং এজ কেসের বিরুদ্ধে স্থিতিস্থাপকতা
- বিভিন্ন লোডে ধারাবাহিক পারফরম্যান্স

## MCP সার্ভারের জন্য ইউনিট টেস্টিং

### ইউনিট টেস্টিং (মৌলিক স্তর)

ইউনিট টেস্ট MCP সার্ভারের পৃথক উপাদানগুলো আলাদাভাবে যাচাই করে।

#### কী টেস্ট করবেন

১. **রিসোর্স হ্যান্ডলারস**: প্রতিটি রিসোর্স হ্যান্ডলারের লজিক আলাদাভাবে টেস্ট করুন  
২. **টুল ইমপ্লিমেন্টেশনস**: বিভিন্ন ইনপুট দিয়ে টুলের আচরণ যাচাই করুন  
৩. **প্রম্পট টেমপ্লেটস**: নিশ্চিত করুন প্রম্পট টেমপ্লেট সঠিকভাবে রেন্ডার হচ্ছে  
৪. **স্কিমা ভ্যালিডেশন**: প্যারামিটার ভ্যালিডেশন লজিক টেস্ট করুন  
৫. **এরর হ্যান্ডলিং**: অবৈধ ইনপুটের জন্য এরর রেসপন্স যাচাই করুন

#### ইউনিট টেস্টিংয়ের সেরা অনুশীলনসমূহ

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

### ইন্টিগ্রেশন টেস্টিং (মধ্যবর্তী স্তর)

ইন্টিগ্রেশন টেস্ট MCP সার্ভারের উপাদানগুলোর মধ্যে ইন্টারঅ্যাকশন যাচাই করে।

#### কী টেস্ট করবেন

১. **সার্ভার ইনিশিয়ালাইজেশন**: বিভিন্ন কনফিগারেশনে সার্ভার স্টার্টআপ টেস্ট করুন  
২. **রুট রেজিস্ট্রেশন**: সব এন্ডপয়েন্ট সঠিকভাবে রেজিস্টার হয়েছে কিনা যাচাই করুন  
৩. **রিকোয়েস্ট প্রসেসিং**: সম্পূর্ণ রিকোয়েস্ট-রেসপন্স সাইকেল টেস্ট করুন  
৪. **এরর প্রোপাগেশন**: উপাদানগুলোর মধ্যে এরর সঠিকভাবে হ্যান্ডল হচ্ছে কিনা নিশ্চিত করুন  
৫. **অথেনটিকেশন ও অথরাইজেশন**: সিকিউরিটি মেকানিজম টেস্ট করুন

#### ইন্টিগ্রেশন টেস্টিংয়ের সেরা অনুশীলনসমূহ

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

### এন্ড-টু-এন্ড টেস্টিং (শীর্ষ স্তর)

এন্ড-টু-এন্ড টেস্ট ক্লায়েন্ট থেকে সার্ভার পর্যন্ত সম্পূর্ণ সিস্টেমের আচরণ যাচাই করে।

#### কী টেস্ট করবেন

১. **ক্লায়েন্ট-সার্ভার কমিউনিকেশন**: সম্পূর্ণ রিকোয়েস্ট-রেসপন্স সাইকেল টেস্ট করুন  
২. **রিয়েল ক্লায়েন্ট SDKs**: বাস্তব ক্লায়েন্ট ইমপ্লিমেন্টেশনের সাথে টেস্ট করুন  
৩. **লোডের অধীনে পারফরম্যান্স**: একাধিক সমান্তরাল রিকোয়েস্টের সাথে আচরণ যাচাই করুন  
৪. **এরর রিকভারি**: ব্যর্থতা থেকে সিস্টেমের পুনরুদ্ধার টেস্ট করুন  
৫. **দীর্ঘমেয়াদী অপারেশন**: স্ট্রিমিং এবং দীর্ঘ অপারেশন হ্যান্ডলিং যাচাই করুন

#### এন্ড-টু-এন্ড টেস্টিংয়ের সেরা অনুশীলনসমূহ

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

## MCP টেস্টিংয়ের জন্য মকিং কৌশলসমূহ

মকিং টেস্টিং চলাকালীন উপাদানগুলো আলাদা করার জন্য অপরিহার্য।

### মক করার উপাদানসমূহ

১. **বাহ্যিক AI মডেলস**: পূর্বানুমানযোগ্য টেস্টিংয়ের জন্য মডেল রেসপন্স মক করুন  
২. **বাহ্যিক সার্ভিসেস**: API ডিপেন্ডেন্সি (ডাটাবেস, তৃতীয় পক্ষের সার্ভিস) মক করুন  
৩. **অথেনটিকেশন সার্ভিসেস**: আইডেন্টিটি প্রোভাইডার মক করুন  
৪. **রিসোর্স প্রোভাইডারস**: ব্যয়বহুল রিসোর্স হ্যান্ডলার মক করুন

### উদাহরণ: AI মডেল রেসপন্স মক করা

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

## পারফরম্যান্স টেস্টিং

পারফরম্যান্স টেস্টিং প্রোডাকশন MCP সার্ভারের জন্য অপরিহার্য।

### কী পরিমাপ করবেন

১. **লেটেন্সি**: রিকোয়েস্টের জন্য রেসপন্স সময়  
২. **থ্রুপুট**: প্রতি সেকেন্ডে হ্যান্ডেল করা রিকোয়েস্ট  
৩. **রিসোর্স ইউটিলাইজেশন**: CPU, মেমোরি, নেটওয়ার্ক ব্যবহার  
৪. **কনকারেন্সি হ্যান্ডলিং**: প্যারালাল রিকোয়েস্টের অধীনে আচরণ  
৫. **স্কেলিং বৈশিষ্ট্য**: লোড বাড়ার সাথে পারফরম্যান্স

### পারফরম্যান্স টেস্টিংয়ের টুলস

- **k6**: ওপেন-সোর্স লোড টেস্টিং টুল  
- **JMeter**: ব্যাপক পারফরম্যান্স টেস্টিং  
- **Locust**: পাইথন ভিত্তিক লোড টেস্টিং  
- **Azure Load Testing**: ক্লাউড ভিত্তিক পারফরম্যান্স টেস্টিং

### উদাহরণ: k6 দিয়ে বেসিক লোড টেস্ট

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

## MCP সার্ভারের জন্য টেস্ট অটোমেশন

টেস্ট অটোমেশন নিশ্চিত করে ধারাবাহিক গুণমান এবং দ্রুত ফিডব্যাক লুপ।

### CI/CD ইন্টিগ্রেশন

১. **পুল রিকোয়েস্টে ইউনিট টেস্ট চালান**: কোড পরিবর্তন বিদ্যমান ফাংশনালিটি ভাঙছে না নিশ্চিত করুন  
২. **স্টেজিংয়ে ইন্টিগ্রেশন টেস্ট**: প্রি-প্রোডাকশন পরিবেশে ইন্টিগ্রেশন টেস্ট চালান  
৩. **পারফরম্যান্স বেসলাইনস**: রিগ্রেশন ধরার জন্য পারফরম্যান্স বেঞ্চমার্ক বজায় রাখুন  
৪. **সিকিউরিটি স্ক্যান**: পাইপলাইনের অংশ হিসেবে সিকিউরিটি টেস্টিং অটোমেট করুন

### উদাহরণ CI পাইপলাইন (GitHub Actions)

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

## MCP স্পেসিফিকেশনের সাথে কমপ্লায়েন্স টেস্টিং

আপনার সার্ভার MCP স্পেসিফিকেশন সঠিকভাবে বাস্তবায়ন করছে কিনা যাচাই করুন।

### মূল কমপ্লায়েন্স ক্ষেত্রসমূহ

১. **API এন্ডপয়েন্টস**: প্রয়োজনীয় এন্ডপয়েন্টস (/resources, /tools, ইত্যাদি) টেস্ট করুন  
২. **রিকোয়েস্ট/রেসপন্স ফরম্যাট**: স্কিমা কমপ্লায়েন্স যাচাই করুন  
৩. **এরর কোডস**: বিভিন্ন পরিস্থিতির জন্য সঠিক স্ট্যাটাস কোড যাচাই করুন  
৪. **কন্টেন্ট টাইপস**: বিভিন্ন কন্টেন্ট টাইপ হ্যান্ডলিং টেস্ট করুন  
৫. **অথেনটিকেশন ফ্লো**: স্পেসিফিকেশন-অনুযায়ী অথ মেকানিজম যাচাই করুন

### কমপ্লায়েন্স টেস্ট স্যুট

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

## কার্যকর MCP সার্ভার টেস্টিংয়ের শীর্ষ ১০ টিপস

১. **টুল ডেফিনিশন আলাদাভাবে টেস্ট করুন**: টুল লজিক থেকে স্কিমা ডেফিনিশন স্বাধীনভাবে যাচাই করুন  
২. **প্যারামিটারাইজড টেস্ট ব্যবহার করুন**: বিভিন্ন ইনপুটসহ এজ কেস টেস্ট করুন  
৩. **এরর রেসপন্স চেক করুন**: সব সম্ভাব্য এরর কন্ডিশনের জন্য সঠিক হ্যান্ডলিং যাচাই করুন  
৪. **অথরাইজেশন লজ
5. নির্দিষ্ট MCP বিষয়গুলিতে উন্নত কোর্স নেওয়ার কথা বিবেচনা করুন, যেমন মাল্টি-মোডাল ইন্টিগ্রেশন বা এন্টারপ্রাইজ অ্যাপ্লিকেশন ইন্টিগ্রেশন।
6. [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) থেকে শেখা নীতিমালা ব্যবহার করে আপনার নিজস্ব MCP টুল এবং ওয়ার্কফ্লো তৈরি করার চেষ্টা করুন।

পরবর্তী: সেরা অনুশীলন [case studies](../09-CaseStudy/README.md)

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায়ই কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ গ্রহণ করার পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।