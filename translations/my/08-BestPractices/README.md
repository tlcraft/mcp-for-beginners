<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "10d7df03cff1fa3cf3c56dc06e82ba79",
  "translation_date": "2025-07-14T05:17:22+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "my"
}
-->
# MCP ဖွံ့ဖြိုးတိုးတက်မှုအတွက် အကောင်းဆုံး လေ့လာမှုများ

## အနှစ်ချုပ်

ဒီသင်ခန်းစာမှာ MCP ဆာဗာများနဲ့ လုပ်ဆောင်ချက်များကို ထုတ်လုပ်မှုပတ်ဝန်းကျင်မှာ ဖွံ့ဖြိုးတိုးတက်မှု၊ စမ်းသပ်မှုနဲ့ တပ်ဆင်မှုဆိုင်ရာ အဆင့်မြင့် အကောင်းဆုံး လေ့လာမှုများကို အဓိကထားပြောပြထားပါတယ်။ MCP ပတ်ဝန်းကျင်များသည် ပိုမိုရှုပ်ထွေးလာပြီး အရေးပါလာသည့်အခါ၊ ရိုးရာနည်းလမ်းများကို လိုက်နာခြင်းဖြင့် ယုံကြည်စိတ်ချရမှု၊ ပြုပြင်ထိန်းသိမ်းရလွယ်မှုနဲ့ အပြန်အလှန်ဆက်သွယ်နိုင်မှုတို့ကို သေချာစေပါသည်။ ဒီသင်ခန်းစာမှာ MCP ကို အကောင်းဆုံး အသုံးချနိုင်ဖို့ အတွေ့အကြုံများကို စုစည်းပြီး ခိုင်မာပြီး ထိရောက်သော ဆာဗာများ၊ အရင်းအမြစ်များ၊ prompt များနဲ့ ကိရိယာများ ဖန်တီးရာမှာ လမ်းညွှန်ပေးထားပါတယ်။

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဒီသင်ခန်းစာပြီးဆုံးချိန်မှာ သင်သည်
- MCP ဆာဗာနဲ့ လုပ်ဆောင်ချက် ဒီဇိုင်းမှာ စက်မှုလုပ်ငန်းအကောင်းဆုံး လေ့လာမှုများကို အသုံးချနိုင်မည်
- MCP ဆာဗာများအတွက် စမ်းသပ်မှု မဟာဗျူဟာများ ဖန်တီးနိုင်မည်
- ရှုပ်ထွေးသော MCP အက်ပလီကေးရှင်းများအတွက် ထိရောက်ပြီး ပြန်လည်အသုံးပြုနိုင်သော workflow ပုံစံများ ဒီဇိုင်းဆွဲနိုင်မည်
- MCP ဆာဗာများတွင် မှားယွင်းမှု ကိုင်တွယ်မှု၊ မှတ်တမ်းတင်မှုနဲ့ ကြည့်ရှုနိုင်မှုများကို မှန်ကန်စွာ အကောင်အထည်ဖော်နိုင်မည်
- စွမ်းဆောင်ရည်၊ လုံခြုံမှုနဲ့ ပြုပြင်ထိန်းသိမ်းရလွယ်မှုအတွက် MCP အကောင်အထည်ဖော်မှုများကို အကောင်းဆုံး ပြုလုပ်နိုင်မည်

## ထပ်ဆောင်း ရင်းမြစ်များ

MCP အကောင်းဆုံး လေ့လာမှုများအတွက် နောက်ဆုံးရသတင်းအချက်အလက်များကို အောက်ပါနေရာများတွင် ရယူနိုင်ပါသည်။
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## MCP ကိရိယာ ဖွံ့ဖြိုးတိုးတက်မှုအတွက် အကောင်းဆုံး လေ့လာမှုများ

### အင်ဂျင်နီယာ အခြေခံသဘောတရားများ

#### 1. တစ်ခုတည်းတာဝန်ယူမှု သဘောတရား

MCP လုပ်ဆောင်ချက်တိုင်းမှာ ရည်ရွယ်ချက်ရှင်းလင်းပြီး အာရုံစိုက်ထားသင့်သည်။ အကြီးစား ကိရိယာများကို တစ်ပြိုင်နက်မှာ အလုပ်အမျိုးမျိုးလုပ်စေခြင်းမပြုဘဲ၊ အထူးပြု ကိရိယာများကို တီထွင်ဖန်တီးပါ။

**ကောင်းမွန်သော ဥပမာ:**
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

**မကောင်းသော ဥပမာ:**
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

#### 2. Dependency Injection နဲ့ စမ်းသပ်နိုင်မှု

ကိရိယာများကို constructor injection ဖြင့် လက်ခံပြီး စမ်းသပ်နိုင်စေရန် ဒီဇိုင်းဆွဲပါ။

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

#### 3. Composable Tools

ပိုမိုရှုပ်ထွေးသော workflow များ ဖန်တီးနိုင်ရန် ကိရိယာများကို ပေါင်းစပ်အသုံးပြုနိုင်အောင် ဒီဇိုင်းဆွဲပါ။

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

### Schema ဒီဇိုင်း အကောင်းဆုံး လေ့လာမှုများ

Schema သည် မော်ဒယ်နဲ့ သင့်ကိရိယာအကြား စာချုပ်တစ်ခုဖြစ်သည်။ ကောင်းမွန်စွာ ဒီဇိုင်းဆွဲထားသော schema များက ကိရိယာအသုံးပြုမှုကို ပိုမိုကောင်းမွန်စေပါသည်။

#### 1. ပရမားတာ ဖော်ပြချက်ရှင်းလင်းမှု

ပရမားတာတိုင်းအတွက် ဖော်ပြချက်အသေးစိတ် ထည့်သွင်းပါ။

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

#### 2. စစ်ဆေးမှု ကန့်သတ်ချက်များ

မှားယွင်းသော အချက်အလက်များ မဝင်ရောက်နိုင်စေရန် စစ်ဆေးမှု ကန့်သတ်ချက်များ ထည့်သွင်းပါ။

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

#### 3. ပြန်လည်ထုတ်ပေးမှု ဖွဲ့စည်းမှု တူညီမှု

မော်ဒယ်များအတွက် ရလဒ်များကို ပိုမိုလွယ်ကူစွာ နားလည်နိုင်စေရန် ပြန်လည်ထုတ်ပေးမှု ဖွဲ့စည်းမှုကို တူညီစွာ ထိန်းသိမ်းပါ။

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

### မှားယွင်းမှု ကိုင်တွယ်မှု

MCP ကိရိယာများအတွက် ယုံကြည်စိတ်ချရမှု ထိန်းသိမ်းရန် မှားယွင်းမှုကိုင်တွယ်မှု အရေးကြီးပါသည်။

#### 1. သက်သာစေသော မှားယွင်းမှု ကိုင်တွယ်မှု

မှားယွင်းမှုများကို သင့်တော်သော အဆင့်များတွင် ကိုင်တွယ်ပြီး အသိပေးစာသားများ ပေးပါ။

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

#### 2. ဖွဲ့စည်းထားသော မှားယွင်းမှု ပြန်လည်ဖြေကြားမှု

ဖြစ်နိုင်လျှင် ဖွဲ့စည်းထားသော မှားယွင်းမှု အချက်အလက်များ ပြန်ပေးပါ။

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

#### 3. ထပ်မံကြိုးစားမှု မဟာဗျူဟာ

ယာယီ အဆင်မပြေမှုများအတွက် သင့်တော်သော ထပ်မံကြိုးစားမှု မဟာဗျူဟာများ ထည့်သွင်းပါ။

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

### စွမ်းဆောင်ရည် တိုးတက်မှု

#### 1. Caching

စရိတ်ကြီးသော လုပ်ဆောင်ချက်များအတွက် caching ကို အသုံးပြုပါ။

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

#### 2. အချိန်မီ မလုပ်ဆောင်မှု (Asynchronous Processing)

I/O အခြေပြု လုပ်ဆောင်ချက်များအတွက် asynchronous programming ပုံစံများကို အသုံးပြုပါ။

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

#### 3. အရင်းအမြစ် ထိန်းချုပ်မှု

အလွန်အကျွံ မဖြစ်ပေါ်စေရန် အရင်းအမြစ် ထိန်းချုပ်မှုကို ထည့်သွင်းပါ။

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

### လုံခြုံရေး အကောင်းဆုံး လေ့လာမှုများ

#### 1. အချက်အလက် ဝင်ရောက်မှု စစ်ဆေးမှု

အချက်အလက် ဝင်ရောက်မှုများကို အပြည့်အဝ စစ်ဆေးပါ။

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

#### 2. ခွင့်ပြုချက် စစ်ဆေးမှု

မှန်ကန်သော ခွင့်ပြုချက် စစ်ဆေးမှုများကို ထည့်သွင်းပါ။

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

#### 3. အထူးသဖြင့် အချက်အလက် ကိုင်တွယ်မှု

အထူးသဖြင့် အချက်အလက်များကို သတိထားစွာ ကိုင်တွယ်ပါ။

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

## MCP ကိရိယာများအတွက် စမ်းသပ်မှု အကောင်းဆုံး လေ့လာမှုများ

ကျယ်ပြန့်သော စမ်းသပ်မှုများက MCP ကိရိယာများ၏ မှန်ကန်မှု၊ အထူးအခြေအနေများကို ကိုင်တွယ်နိုင်မှုနဲ့ စနစ်အတွင်း အခြားအစိတ်အပိုင်းများနှင့် ပေါင်းစည်းမှုကို သေချာစေပါသည်။

### Unit Testing

#### 1. ကိရိယာ တစ်ခုချင်းစီကို သီးသန့် စမ်းသပ်ပါ

ကိရိယာတစ်ခုချင်းစီ၏ လုပ်ဆောင်ချက်များအတွက် အာရုံစိုက်စမ်းသပ်မှုများ ဖန်တီးပါ။

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

#### 2. Schema စစ်ဆေးမှု စမ်းသပ်မှု

Schema များသည် မှန်ကန်ပြီး ကန့်သတ်ချက်များကို မှန်ကန်စွာ အကောင်အထည်ဖော်နေကြောင်း စမ်းသပ်ပါ။

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

#### 3. မှားယွင်းမှု ကိုင်တွယ်မှု စမ်းသပ်မှုများ

မှားယွင်းမှု အခြေအနေများအတွက် သီးသန့် စမ်းသပ်မှုများ ဖန်တီးပါ။

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

### Integration Testing

#### 1. ကိရိယာ များ ပေါင်းစပ် စမ်းသပ်မှု

မျှော်မှန်းထားသည့် ပေါင်းစပ်မှုများအတိုင်း ကိရိယာများ ပူးပေါင်းလုပ်ဆောင်မှုကို စမ်းသပ်ပါ။

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

#### 2. MCP ဆာဗာ စမ်းသပ်မှု

ကိရိယာများ အပြည့်အစုံ မှတ်ပုံတင်ခြင်းနဲ့ လုပ်ဆောင်မှုအပြည့်အစုံဖြင့် MCP ဆာဗာကို စမ်းသပ်ပါ။

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

#### 3. အစမှအဆုံး စမ်းသပ်မှု

မော်ဒယ် prompt မှ ကိရိယာ လုပ်ဆောင်မှုအထိ ပြည့်စုံသော workflow များကို စမ်းသပ်ပါ။

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

### စွမ်းဆောင်ရည် စမ်းသပ်မှု

#### 1. Load Testing

MCP ဆာဗာသည် တစ်ပြိုင်နက်တောင်းဆိုမှုများကို ဘယ်လောက်ကိုင်တွယ်နိုင်သည်ကို စမ်းသပ်ပါ။

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

#### 2. Stress Testing

စနစ်ကို အလွန်အကျွံသော လုပ်ဆောင်မှုအောက်တွင် စမ်းသပ်ပါ။

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

#### 3. ကြည့်ရှုမှုနဲ့ ပရိုဖိုင်လုပ်ခြင်း

ရှည်လျားသော အချိန်ကာလ စွမ်းဆောင်ရည် ချဲ့ထွင်မှုအတွက် ကြည့်ရှုမှု စနစ်များ တပ်ဆင်ပါ။

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

## MCP Workflow ဒီဇိုင်း ပုံစံများ

ကောင်းမွန်စွာ ဒီဇိုင်းဆွဲထားသော MCP workflow များက ထိရောက်မှု၊ ယုံကြည်စိတ်ချရမှုနဲ့ ပြုပြင်ထိန်းသိမ်းရလွယ်မှုကို တိုးတက်စေပါသည်။ အောက်ပါ ပုံစံများကို လိုက်နာပါ။

### 1. ကိရိယာများ ချိတ်ဆက်မှု ပုံစံ

ကိရိယာများစွာကို တစ်ဆက်တည်း ချိတ်ဆက်ပြီး တစ်ခုချင်း output ကို နောက်တစ်ခု input အဖြစ် အသုံးပြုပါ။

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

### 2. Dispatcher ပုံစံ

အဓိက ကိရိယာတစ်ခုကို အသုံးပြုပြီး input အပေါ် မူတည်၍ အထူးပြု ကိရိယာများသို့ ပို့ဆောင်ပါ။

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

### 3. တပြိုင်နက် လုပ်ဆောင်မှု ပုံစံ

ထိရောက်မှုအတွက် ကိရိယာများစွာကို တပြိုင်နက် လုပ်ဆောင်ပါ။

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

### 4. မှားယွင်းမှု ပြန်လည်ကောင်းမွန်မှု ပုံစံ

ကိရိယာ မအောင်မြင်မှုများအတွက် သက်သာစေသော fallback များ ထည့်သွင်းပါ။

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

### 5. Workflow ပေါင်းစပ်မှု ပုံစံ

ရိုးရှင်းသော workflow များကို ပေါင်းစပ်ပြီး ရှုပ်ထွေးသော workflow များ ဖန်တီးပါ။

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

# MCP ဆာဗာများ စမ်းသပ်ခြင်း: အကောင်းဆုံး လေ့လာမှုများနဲ့ ထိပ်တန်း အကြံပြုချက်များ

## အနှစ်ချုပ်

စမ်းသပ်ခြင်းသည် ယုံကြည်စိတ်ချရပြီး အရည်အသွေးမြင့် MCP ဆာဗာများ ဖွံ့ဖြိုးတိုးတက်ရေးအတွက် အရေးကြီးသော အစိတ်အပိုင်းဖြစ်သည်။ ဒီလမ်းညွှန်မှာ unit test များမှ integration test များ၊ အစမှအဆုံး စမ်းသပ်မှုများအထိ MCP ဆာဗာများကို စမ်းသပ်ရာတွင် အသုံးချနိုင်သော အကောင်းဆုံး လေ့လာမှုများနဲ့ အကြံပြုချက်များ ပါဝင်သည်။

## MCP ဆာဗာများအတွက် စမ်းသပ်ခြင်း အရေးကြီးမှု

MCP ဆာဗာများသည် AI မော်ဒယ်များနဲ့ client အက်ပလီကေးရှင်းများအကြား အရေးပါသော middleware အဖြစ် တာဝန်ထမ်းဆောင်သည်။ စမ်းသပ်မှုများက အောက်ပါအချက်များကို သေချာစေပါသည်။

- ထုတ်လုပ်မှုပတ်ဝန်းကျင်တွင် ယုံကြည်စိတ်ချရမှု
- တောင်းဆိုမှုနဲ့ ပြန်လည်ဖြေကြားမှုများကို မှန်ကန်စွာ ကိုင်တွယ်နိုင်မှု
- MCP သတ်မှတ်ချက်များကို မှန်ကန်စွာ အကောင်အထည်ဖော်မှု
- မအောင်မြင်မှုများနဲ့ အထူးအခြေအနေများကို ခိုင်မာစွာ ရင်ဆိုင်နိုင်မှု
- မတူညီသော လုပ်ဆောင်မှုအောက်တွင် တည်ငြိမ်သော စွမ်းဆောင်ရည်

## MCP ဆာဗာများအတွက် Unit Testing

### Unit Testing (အခြေခံ)

Unit test များက MCP ဆာဗာ၏ တစ်စိတ်တစ်ပိုင်းကို သီးသန့်စမ်းသပ်သည်။

#### စမ်းသပ်ရန် အချက်များ

1. **Resource Handlers**: resource handler တစ်ခုချင်း၏ လုပ်ဆောင်ချက်ကို သီးသန့်စမ်းသပ်ပါ
2. **Tool Implementations**: ကိရိယာများ၏ အပြုအမူကို input မျိုးစုံဖြင့် စစ်ဆေးပါ
3. **Prompt Templates**: prompt template များမှန်ကန်စွာ ပြသနိုင်မှုကို သေချာစေပါ
4. **Schema Validation**: parameter စစ်ဆေးမှု လုပ်ဆောင်ချက်ကို စမ်းသပ်ပါ
5. **Error Handling**: မှားယွင်းသော input များအတွက် error ပြန်လည်ဖြေကြားမှုကို စစ်ဆေးပါ

#### Unit Testing အတွက် အကောင်းဆုံး လေ့လာမှုများ

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

### Integration Testing (အလယ်အလတ်အဆင့်)

Integration test များက MCP ဆာဗာ၏ အစိတ်အပိုင်းများအကြား ဆက်သွယ်မှုကို စမ်းသပ်သည်။

#### စမ်းသပ်ရန် အချက်များ

1. **Server Initialization**: server စတင်မှုကို configuration မျိုးစုံဖြင့် စမ်းသပ်ပါ
2. **Route Registration**: endpoint များအားလုံးမှန်ကန်စွာ မှတ်ပုံတင်ထားမှုကို စစ်ဆေးပါ
3. **Request Processing**: တောင်းဆိုမှု-ပြန်လည်ဖြေကြားမှု လည်ပတ်မှုအပြည့်အစုံကို စမ်းသပ်ပါ
4. **Error Propagation**: မှားယွင်းမှုများကို အစိတ်အပိုင်းများအတွင်း မှန်ကန်စွာ ဖြန့်ဝေမှုကို စစ်ဆေးပါ
5. **Authentication & Authorization**: လုံခြုံရေးစနစ်များကို စမ်းသပ်ပါ

#### Integration Testing အတွက် အကောင်းဆုံး လေ့လာမှုများ

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

### End-to-End Testing (အထိပ်အမြောက်အဆင့်)

End-to-end test များက client မှ server အထိ စနစ်တစ်ခုလုံး၏ လုပ်ဆောင်မှုကို စမ်းသပ်သည်။

#### စမ်းသပ်ရန် အချက်များ

1. **Client-Server Communication**: တောင်းဆိုမှု-ပြန်လည်ဖြေကြားမှု လည်ပတ်မှုအပြည့်အစုံကို စမ်းသပ်ပါ
2. **Real Client SDKs**: အမှန်တကယ် client implementation များဖြင့် စမ်းသပ်ပါ
3. **Performance Under Load**: တပြိုင်နက်တောင်းဆိုမှုများဖြင့် လည်ပတ်မှုကို စစ်ဆေးပါ
4. **Error Recovery**: မအောင်မြင်မှုများမှ စနစ် ပြန်လ
5. multi-modal integration သို့မဟုတ် enterprise application integration ကဲ့သို့ MCP အထူးအကြောင်းအရာများအပေါ် အဆင့်မြင့်သင်တန်းများယူရန်စဉ်းစားပါ။
6. [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) မှ သင်ယူထားသော 원칙များကို အသုံးပြု၍ သင်၏ကိုယ်ပိုင် MCP ကိရိယာများနှင့် workflow များ တည်ဆောက်ရန် စမ်းသပ်ကြည့်ပါ။

နောက်တစ်ခု: အကောင်းဆုံးလေ့လာမှုများ [case studies](../09-CaseStudy/README.md)

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အရင်းအမြစ်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်မှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့ တာဝန်မယူပါ။