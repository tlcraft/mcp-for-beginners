<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36e46bfca83e3528afc6f66803efa75e",
  "translation_date": "2025-05-17T16:51:14+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "bn"
}
-->
# এমসিপি ডেভেলপমেন্ট সেরা অনুশীলন

## সংক্ষিপ্ত বিবরণ

এই পাঠটি উৎপাদন পরিবেশে এমসিপি সার্ভার এবং বৈশিষ্ট্যগুলি বিকাশ, পরীক্ষা এবং স্থাপন করার জন্য উন্নত সেরা অনুশীলনের উপর ফোকাস করে। এমসিপি ইকোসিস্টেমগুলি জটিলতা এবং গুরুত্বে বৃদ্ধি পাওয়ার সাথে সাথে প্রতিষ্ঠিত প্যাটার্নগুলি অনুসরণ করলে নির্ভরযোগ্যতা, রক্ষণাবেক্ষণযোগ্যতা এবং আন্তঃপ্রচলনযোগ্যতা নিশ্চিত হয়। এই পাঠটি বাস্তব-জগতের এমসিপি বাস্তবায়ন থেকে অর্জিত ব্যবহারিক জ্ঞানকে একত্রিত করে আপনাকে শক্তিশালী, দক্ষ সার্ভার তৈরি করতে কার্যকর সম্পদ, প্রম্পট এবং সরঞ্জাম সহ গাইড করতে।

## শিক্ষার উদ্দেশ্য

এই পাঠের শেষে, আপনি সক্ষম হবেন:
- এমসিপি সার্ভার এবং বৈশিষ্ট্য ডিজাইনে শিল্পের সেরা অনুশীলন প্রয়োগ করুন
- এমসিপি সার্ভারের জন্য ব্যাপক পরীক্ষার কৌশল তৈরি করুন
- জটিল এমসিপি অ্যাপ্লিকেশনের জন্য দক্ষ, পুনঃব্যবহারযোগ্য ওয়ার্কফ্লো প্যাটার্ন ডিজাইন করুন
- এমসিপি সার্ভারে যথাযথ ত্রুটি পরিচালনা, লগিং এবং পর্যবেক্ষণ বাস্তবায়ন করুন
- কর্মক্ষমতা, নিরাপত্তা এবং রক্ষণাবেক্ষণের জন্য এমসিপি বাস্তবায়নগুলি অপ্টিমাইজ করুন

## অতিরিক্ত রেফারেন্স

এমসিপি সেরা অনুশীলন সম্পর্কে সর্বশেষ তথ্যের জন্য, দেখুন:
- [এমসিপি ডকুমেন্টেশন](https://modelcontextprotocol.io/)
- [এমসিপি স্পেসিফিকেশন](https://spec.modelcontextprotocol.io/)
- [গিটহাব রিপোজিটরি](https://github.com/modelcontextprotocol)

## এমসিপি টুল ডেভেলপমেন্ট সেরা অনুশীলন

### স্থাপত্য নীতি

#### ১. একক দায়িত্ব নীতি

প্রতিটি এমসিপি বৈশিষ্ট্যকে একটি স্পষ্ট, কেন্দ্রীভূত উদ্দেশ্য থাকা উচিত। একাধিক উদ্বেগ পরিচালনা করার চেষ্টা করে বিশালাকার সরঞ্জাম তৈরি করার পরিবর্তে, নির্দিষ্ট কাজগুলিতে উৎকৃষ্ট বিশেষায়িত সরঞ্জাম তৈরি করুন।

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

**দুর্বল উদাহরণ:**
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

#### ২. নির্ভরতা ইনজেকশন এবং পরীক্ষাযোগ্যতা

সরঞ্জামগুলি তাদের নির্ভরতা কনস্ট্রাক্টর ইনজেকশনের মাধ্যমে গ্রহণ করার জন্য ডিজাইন করুন, তাদের পরীক্ষাযোগ্য এবং কনফিগারযোগ্য করে তুলুন:

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

#### ৩. যৌগিক সরঞ্জাম

সরঞ্জামগুলি এমনভাবে ডিজাইন করুন যা আরও জটিল ওয়ার্কফ্লো তৈরি করতে একসাথে রচনা করা যায়:

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

### স্কিমা ডিজাইন সেরা অনুশীলন

স্কিমা হল মডেল এবং আপনার সরঞ্জামের মধ্যে চুক্তি। ভালভাবে ডিজাইন করা স্কিমাগুলি ভাল সরঞ্জাম ব্যবহারযোগ্যতার দিকে নিয়ে যায়।

#### ১. স্পষ্ট প্যারামিটার বিবরণ

প্রতিটি প্যারামিটারের জন্য বর্ণনামূলক তথ্য অন্তর্ভুক্ত করুন:

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

#### ২. বৈধতা সীমাবদ্ধতা

অবৈধ ইনপুট প্রতিরোধ করতে বৈধতা সীমাবদ্ধতা অন্তর্ভুক্ত করুন:

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

#### ৩. ধারাবাহিক রিটার্ন স্ট্রাকচার

ফলাফল ব্যাখ্যা করা মডেলগুলির জন্য সহজ করতে আপনার প্রতিক্রিয়া কাঠামোতে ধারাবাহিকতা বজায় রাখুন:

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

### ত্রুটি পরিচালনা

নির্ভরযোগ্যতা বজায় রাখার জন্য এমসিপি সরঞ্জামের জন্য শক্তিশালী ত্রুটি পরিচালনা অত্যন্ত গুরুত্বপূর্ণ।

#### ১. সুশৃঙ্খল ত্রুটি পরিচালনা

উপযুক্ত স্তরে ত্রুটি পরিচালনা করুন এবং তথ্যপূর্ণ বার্তা প্রদান করুন:

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

#### ২. কাঠামোগত ত্রুটি প্রতিক্রিয়া

যখন সম্ভব কাঠামোগত ত্রুটি তথ্য প্রদান করুন:

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

#### ৩. পুনরায় চেষ্টা করার যুক্তি

অস্থায়ী ব্যর্থতার জন্য উপযুক্ত পুনরায় চেষ্টা করার যুক্তি বাস্তবায়ন করুন:

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

### কর্মক্ষমতা অপ্টিমাইজেশন

#### ১. ক্যাশিং

ব্যয়বহুল অপারেশনের জন্য ক্যাশিং বাস্তবায়ন করুন:

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

আই/ও-বাউন্ড অপারেশনের জন্য অ্যাসিঙ্ক্রোনাস প্রোগ্রামিং প্যাটার্ন ব্যবহার করুন:

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

#### ৩. সম্পদ থ্রোটলিং

অতিরিক্ত লোড প্রতিরোধ করতে সম্পদ থ্রোটলিং বাস্তবায়ন করুন:

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

### নিরাপত্তা সেরা অনুশীলন

#### ১. ইনপুট বৈধতা

সবসময় ইনপুট প্যারামিটারগুলি পুঙ্খানুপুঙ্খভাবে বৈধতা পরীক্ষা করুন:

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

#### ২. অনুমোদন চেক

যথাযথ অনুমোদন চেক বাস্তবায়ন করুন:

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

#### ৩. সংবেদনশীল ডেটা পরিচালনা

সংবেদনশীল ডেটা সতর্কতার সাথে পরিচালনা করুন:

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

## এমসিপি সরঞ্জামের জন্য পরীক্ষার সেরা অনুশীলন

ব্যাপক পরীক্ষা নিশ্চিত করে যে এমসিপি সরঞ্জামগুলি সঠিকভাবে কাজ করে, প্রান্তের ক্ষেত্রে পরিচালনা করে এবং সিস্টেমের বাকি অংশের সাথে সঠিকভাবে একত্রিত হয়।

### ইউনিট টেস্টিং

#### ১. প্রতিটি সরঞ্জামকে আলাদাভাবে পরীক্ষা করুন

প্রতিটি সরঞ্জামের কার্যকারিতা জন্য কেন্দ্রীভূত পরীক্ষা তৈরি করুন:

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

#### ২. স্কিমা বৈধতা পরীক্ষা

স্কিমাগুলি বৈধ এবং সঠিকভাবে সীমাবদ্ধতা প্রয়োগ করে কিনা তা পরীক্ষা করুন:

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

#### ৩. ত্রুটি পরিচালনা পরীক্ষা

ত্রুটি শর্তগুলির জন্য নির্দিষ্ট পরীক্ষা তৈরি করুন:

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

প্রত্যাশিত সংমিশ্রণে কাজ করা সরঞ্জামগুলি পরীক্ষা করুন:

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

#### ২. এমসিপি সার্ভার টেস্টিং

সম্পূর্ণ সরঞ্জাম নিবন্ধন এবং কার্যকর করার সাথে এমসিপি সার্ভার পরীক্ষা করুন:

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

মডেল প্রম্পট থেকে টুল এক্সিকিউশন পর্যন্ত সম্পূর্ণ ওয়ার্কফ্লো পরীক্ষা করুন:

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

### কর্মক্ষমতা পরীক্ষা

#### ১. লোড টেস্টিং

আপনার এমসিপি সার্ভার কতগুলি একযোগে অনুরোধ পরিচালনা করতে পারে তা পরীক্ষা করুন:

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

#### ৩. পর্যবেক্ষণ এবং প্রোফাইলিং

দীর্ঘমেয়াদী কর্মক্ষমতা বিশ্লেষণের জন্য পর্যবেক্ষণ সেট আপ করুন:

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

## এমসিপি ওয়ার্কফ্লো ডিজাইন প্যাটার্ন

ভালভাবে ডিজাইন করা এমসিপি ওয়ার্কফ্লো দক্ষতা, নির্ভরযোগ্যতা এবং রক্ষণাবেক্ষণযোগ্যতা উন্নত করে। অনুসরণ করার জন্য এখানে প্রধান প্যাটার্নগুলি রয়েছে:

### ১. টুলস প্যাটার্নের চেইন

প্রতিটি সরঞ্জামের আউটপুট পরবর্তীটির ইনপুট হয়ে যায় এমন একটি ক্রমে একাধিক সরঞ্জাম সংযুক্ত করুন:

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

ইনপুটের উপর ভিত্তি করে বিশেষায়িত সরঞ্জামগুলিতে প্রেরণ করে একটি কেন্দ্রীয় সরঞ্জাম ব্যবহার করুন:

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

### ৩. সমান্তরাল প্রসেসিং প্যাটার্ন

দক্ষতার জন্য একযোগে একাধিক সরঞ্জাম কার্যকর করুন:

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

### ৪. ত্রুটি পুনরুদ্ধার প্যাটার্ন

সরঞ্জামের ব্যর্থতার জন্য সুশৃঙ্খল ব্যাকআপ বাস্তবায়ন করুন:

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

সহজগুলিকে রচনা করে জটিল ওয়ার্কফ্লো তৈরি করুন:

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

# এমসিপি সার্ভার পরীক্ষা: সেরা অনুশীলন এবং শীর্ষ টিপস

## সংক্ষিপ্ত বিবরণ

পরীক্ষা হল নির্ভরযোগ্য, উচ্চ-মানের এমসিপি সার্ভার তৈরি করার একটি গুরুত্বপূর্ণ দিক। এই গাইডটি আপনার এমসিপি সার্ভারগুলি পুরো বিকাশের জীবনচক্র জুড়ে পরীক্ষা করার জন্য ব্যাপক সেরা অনুশীলন এবং টিপস প্রদান করে, ইউনিট টেস্ট থেকে ইন্টিগ্রেশন টেস্ট এবং এন্ড-টু-এন্ড যাচাইকরণ পর্যন্ত।

## এমসিপি সার্ভারগুলির জন্য পরীক্ষার গুরুত্ব

এমসিপি সার্ভারগুলি এআই মডেল এবং ক্লায়েন্ট অ্যাপ্লিকেশনগুলির মধ্যে গুরুত্বপূর্ণ মধ্যস্থতাকারী হিসাবে কাজ করে। বিস্তারিত পরীক্ষা নিশ্চিত করে:

- উৎপাদন পরিবেশে নির্ভরযোগ্যতা
- অনুরোধ এবং প্রতিক্রিয়াগুলির সঠিক পরিচালনা
- এমসিপি স্পেসিফিকেশন বাস্তবায়ন
- ব্যর্থতা এবং প্রান্তের ক্ষেত্রে বিরুদ্ধে স্থিতিস্থাপকতা
- বিভিন্ন লোডের অধীনে ধারাবাহিক কর্মক্ষমতা

## এমসিপি সার্ভারগুলির জন্য ইউনিট টেস্টিং

### ইউনিট টেস্টিং (ফাউন্ডেশন)

ইউনিট টেস্টগুলি আপনার এমসিপি সার্ভারের পৃথক উপাদানগুলি আলাদাভাবে যাচাই করে।

#### কী পরীক্ষা করবেন

1. **সম্পদ হ্যান্ডলার**: প্রতিটি সম্পদ হ্যান্ডলারের যুক্তি স্বাধীনভাবে পরীক্ষা করুন
2. **সরঞ্জাম বাস্তবায়ন**: বিভিন্ন ইনপুট সহ সরঞ্জামের আচরণ যাচাই করুন
3. **প্রম্পট টেমপ্লেট**: নিশ্চিত করুন যে প্রম্পট টেমপ্লেটগুলি সঠিকভাবে রেন্ডার হয়
4. **স্কিমা বৈধতা**: প্যারামিটার বৈধতা যুক্তি পরীক্ষা করুন
5. **ত্রুটি পরিচালনা**: অবৈধ ইনপুটের জন্য ত্রুটি প্রতিক্রিয়া যাচাই করুন

#### ইউনিট টেস্টিংয়ের সেরা অনুশীলন

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

### ইন্টিগ্রেশন টেস্টিং (মধ্য স্তর)

ইন্টিগ্রেশন টেস্টগুলি আপনার এমসিপি সার্ভারের উপাদানগুলির মধ্যে ইন্টারঅ্যাকশন যাচাই করে।

#### কী পরীক্ষা করবেন

1. **সার্ভার ইনিশিয়ালাইজেশন**: বিভিন্ন কনফিগারেশন সহ সার্ভার স্টার্টআপ পরীক্ষা করুন
2. **রুট নিবন্ধন**: নিশ্চিত করুন যে সমস্ত এন্ডপয়েন্টগুলি সঠিকভাবে নিবন্ধিত হয়েছে
3. **অনুরোধ প্রক্রিয়াকরণ**: সম্পূর্ণ অনুরোধ-প্রতিক্রিয়া চক্র পরীক্ষা করুন
4. **ত্রুটি প্রচার**: নিশ্চিত করুন যে ত্রুটিগুলি উপাদানগুলির মধ্যে সঠিকভাবে পরিচালিত হয়েছে
5. **প্রমাণীকরণ এবং অনুমোদন**: নিরাপত্তা প্রক্রিয়া পরীক্ষা করুন

#### ইন্টিগ্রেশন টেস্টিংয়ের সেরা অনুশীলন

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

এন্ড-টু-এন্ড টেস্টগুলি ক্লায়েন্ট থেকে সার্ভার পর্যন্ত সম্পূর্ণ সিস্টেমের আচরণ যাচাই করে।

#### কী পরীক্ষা করবেন

1. **ক্লায়েন্ট-সার্ভার যোগাযোগ**: সম্পূর্ণ অনুরোধ-প্রতিক্রিয়া চক্র পরীক্ষা করুন
2. **বাস্তব ক্লায়েন্ট এসডিকে**: প্রকৃত ক্লায়েন্ট বাস্তবায়নের সাথে পরীক্ষা করুন
3. **লোডের অধীনে কর্মক্ষমতা**: একাধিক একযোগে অনুরোধের সাথে আচরণ যাচাই করুন
4. **ত্রুটি পুনরুদ্ধার**: ব্যর্থতা থেকে সিস্টেম পুনরুদ্ধার পরীক্ষা করুন
5. **দীর্ঘমেয়াদী অপারেশন**: স্ট্রিমিং এবং দীর্ঘ অপারেশন পরিচালনা যাচাই করুন

#### E2E টেস্টিংয়ের সেরা অনুশীলন

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

## এমসিপি পরীক্ষার জন্য মকিং কৌশল

পরীক্ষার সময় উপাদানগুলি বিচ্ছিন্ন করার জন্য মকিং অপরিহার্য।

### মক করার উপাদান

1. **বাহ্যিক এআই মডেল**: পূর্বাভাসযোগ্য পরীক্ষার জন্য মডেল প্রতিক্রিয়াগুলি মক করুন
2. **বাহ্যিক পরিষেবা**: API নির্ভরতা (ডাটাবেস, তৃতীয় পক্ষের পরিষেবা) মক করুন
3. **প্রমাণীকরণ পরিষেবা**: পরিচয় প্রদানকারী মক করুন
4. **সম্পদ প্রদানকারী**: ব্যয়বহুল সম্পদ হ্যান্ডলার মক করুন

### উদাহরণ: একটি এআই মডেল প্রতিক্রিয়া মক করা

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

## কর্মক্ষমতা পরীক্ষা

উৎপাদন এমসিপি সার্ভারের জন্য কর্মক্ষমতা পরীক্ষা অত্যন্ত গুরুত্বপূর্ণ।

### কী পরিমাপ করবেন

1. **বিলম্ব**: অনুরোধের জন্য প্রতিক্রিয়া সময়
2. **থ্রুপুট**: প্রতি সেকেন্ডে পরিচালিত অনুরোধ
3. **সম্পদ ব্যবহার**: CPU, মেমরি, নেটওয়ার্ক ব্যবহার
4. **একযোগে পরিচালনা**: সমান্তরাল অনুরোধের অধীনে আচরণ
5. **স্কেলিং বৈশিষ্ট্য**: লোড বাড়ার সাথে সাথে কর্মক্ষমতা

### কর্মক্ষমতা পরীক্ষার জন্য সরঞ্জাম

- **k6**: ওপেন-সোর্স লোড টেস্টিং টুল
- **JMeter**: ব্যাপক কর্মক্ষমতা পরীক্ষা
- **Locust**: পাইথন-ভিত্তিক লোড টেস্টিং
- **Azure Load Testing**: ক্লাউড-ভিত্তিক কর্মক্ষমতা পরীক্ষা

### উদাহরণ: k6 এর সাথে মৌলিক লোড পরীক্ষা

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

## এমসিপি সার্ভারের জন্য পরীক্ষার অটোমেশন

আপনার পরীক্ষাগুলি স্বয়ংক্রিয় করা ধারাবাহিক গুণমান এবং দ্রুত প্রতিক্রিয়া লুপ নিশ্চিত করে।

### CI/CD ইন্টিগ্রেশন

1. **পুল অনুরোধে ইউনিট পরীক্ষা চালান**: নিশ্চিত করুন কোড পরিবর্তনগুলি বিদ্যমান কার্যকারিতা ভঙ্গ করে না
2. **স্টেজিংয়ে ইন্টিগ্রেশন পরীক্ষা**: প্রাক-উৎপাদন পরিবেশে ইন্টিগ্রেশন পরীক্ষা চালান
3. **কর্মক্ষমতা বেসলাইন**: প্রতিক্রিয়াগুলি ধরতে কর্মক্ষমতা বেঞ্চমার্ক বজায় রাখুন
4. **নিরাপত্তা স্ক্যান**: পাইপলাইনের অংশ হিসাবে নিরাপত্তা পরীক্ষা স্বয়ংক্রিয় করুন

### উদাহরণ CI পাইপলাইন (গিটহাব অ্যাকশন)

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

## এমসিপি স্পেসিফিকেশন মেনে চলার জন্য পরীক্ষা

আপনার সার্ভার সঠিকভাবে এমসিপি স্পেসিফিকেশন বাস্তবায়ন করে কিনা তা যাচাই করুন।

### প্রধান মেনে চলার ক্ষেত্র

1. **এপিআই এন্ডপয়েন্ট**: প্রয়োজনীয় এন্ডপয়েন্ট পরীক্ষা করুন (/resources, /tools, ইত্যাদি)
2. **অনুরোধ/প্রতিক্রিয়া ফরম্যাট**: স্কিমা মেনে চলা যাচাই করুন
3. **ত্রুটি কোড**: বিভিন্ন পরিস্থিতির জন্য সঠিক স্ট্যাটাস কোড যাচাই করুন
4. **বিষয়বস্তু প্রকার**: বিভিন্ন বিষয়বস্তু প্রকারের পরিচালনা পরীক্ষা করুন
5. **প্রমাণীকরণ প্রবাহ**: স্পেস মেনে চলা প্রমাণীকরণ প্রক্রিয়া যাচাই করুন

### মেনে চলা পরীক্ষা স্যুট

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

## কার্যকর এমসিপি সার্ভার পরীক্ষার জন্য শীর্ষ ১০ টিপস

1. **সরঞ্জাম সংজ্ঞাগুলি আলাদাভাবে পরীক্ষা করুন**: সরঞ্জাম যুক্তি থেকে স্বাধীনভাবে স্কিমা সংজ্ঞাগুলি যাচাই করুন
2. **প্যারামিটারাইজড পরীক্ষা ব্যবহার করুন**: প্রান্তের ক্ষেত্রে সহ বিভিন্ন ইনপুট সহ সরঞ্জাম পরীক্ষা করুন
3. **ত্রুটি প্রতিক্রিয়া পরীক্ষা করুন**: সমস্ত সম্ভাব্য ত্রুটি শর্তের জন্য যথাযথ ত্রুটি পরিচালনা যাচাই করুন
4. **অনুমোদন যুক্তি পরীক্ষা করুন**: বিভিন্ন ব্যবহারকারীর ভূমিকার জন্য যথাযথ অ্যাক্সেস নিয়ন্ত্রণ নিশ্চিত করুন
5. **পরীক্ষার কভারেজ পর্যবেক্ষণ করুন**: গুরুত্বপূর্ণ পথ কোডের উচ্চ কভারেজ লক্ষ্য করুন
6. **স্ট্রিমিং প্রতিক্রিয়া পরীক্ষা করুন**: স্ট্রিমিং বিষয়বস্তু পরিচালনার যথাযথ যাচাই করুন
7. **নেটওয়ার্ক সমস্যা অনুকরণ করুন**: খারাপ নেটওয়ার্ক অবস্থার

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য নির্ভুলতার জন্য চেষ্টা করি, তবে দয়া করে মনে রাখবেন যে স্বয়ংক্রিয় অনুবাদে ভুল বা অসঙ্গতি থাকতে পারে। মূল ভাষায় মূল নথিটি প্রামাণিক উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য, পেশাদার মানব অনুবাদ সুপারিশ করা হয়। এই অনুবাদ ব্যবহারের ফলে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।