<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36e46bfca83e3528afc6f66803efa75e",
  "translation_date": "2025-06-17T16:27:40+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "my"
}
-->
# MCP ဖွံ့ဖြိုးတိုးတက်မှုအတွက် အကောင်းဆုံးအလေ့အထ

## အနှစ်ချုပ်

ဒီသင်ခန်းစာမှာ MCP ဆာဗာများနဲ့ အင်္ဂါရပ်တွေကို ထုတ်လုပ်၊ စမ်းသပ်၊ ထုတ်လုပ်ရေးပတ်ဝန်းကျင်တွင် တပ်ဆင်ရာမှာ အသုံးပြုနိုင်တဲ့ အဆင့်မြင့် အကောင်းဆုံးအလေ့အထများအပေါ် အာရုံစိုက်ထားပါတယ်။ MCP စနစ်များသည် ရှုပ်ထွေးမှုနှင့် အရေးပါမှုများ တိုးလာတာနဲ့အမျှ၊ သတ်မှတ်ထားသော နမူနာများကို လိုက်နာခြင်းဖြင့် ယုံကြည်စိတ်ချရမှု၊ ပြုပြင်ထိန်းသိမ်းရလွယ်မှု၊ နှင့် ပေါင်းစည်းမှုကောင်းမှုများ ရရှိစေပါသည်။ ဒီသင်ခန်းစာက MCP ကို လက်တွေ့အသုံးပြုမှုတွေကနေ ရရှိတဲ့ အတွေ့အကြုံနဲ့ အကြံဉာဏ်တွေကို စုစည်းပေးပြီး ခိုင်မာပြီး ထိရောက်တဲ့ ဆာဗာတွေ၊ အရင်းအမြစ်တွေ၊ အကြံပြုချက်တွေ၊ ကိရိယာတွေ ဖန်တီးရာမှာ လမ်းညွှန်ပေးမှာ ဖြစ်ပါတယ်။

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဒီသင်ခန်းစာပြီးဆုံးချိန်မှာ သင်သည်
- MCP ဆာဗာနဲ့ အင်္ဂါရပ်ဒီဇိုင်းတွင် စက်မှုလုပ်ငန်းအကောင်းဆုံးအလေ့အထများကို အသုံးချနိုင်မည်
- MCP ဆာဗာများအတွက် စမ်းသပ်မှု မဟာဗျူဟာများကို ဖန်တီးနိုင်မည်
- ရှုပ်ထွေးသော MCP အပလီကေးရှင်းများအတွက် ထိရောက်ပြီး ပြန်လည်အသုံးပြုနိုင်သော လုပ်ငန်းစဉ် နမူနာများကို ဒီဇိုင်းဆွဲနိုင်မည်
- MCP ဆာဗာများတွင် မှားယွင်းချက်များကို သင့်တော်စွာ ကိုင်တွယ်ခြင်း၊ မှတ်တမ်းတင်ခြင်းနှင့် ကြည့်ရှုနိုင်မှုများကို အကောင်အထည်ဖော်နိုင်မည်
- တည်ဆောက်မှုများကို လုပ်ဆောင်မှု၊ လုံခြုံမှုနှင့် ပြုပြင်ထိန်းသိမ်းရလွယ်မှုအတွက် အကောင်းဆုံးပြုပြင်နိုင်မည်

## ထပ်ဆောင်းရင်းမြစ်များ

MCP အကောင်းဆုံးအလေ့အထများအတွက် နောက်ဆုံးရသတင်းအချက်အလက်များကို အောက်ပါလင့်ခ်များမှ ရယူနိုင်ပါသည်-
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## MCP ကိရိယာ ဖွံ့ဖြိုးတိုးတက်မှုအတွက် အကောင်းဆုံးအလေ့အထ

### စီမံခန့်ခွဲမှုဆိုင်ရာ နိယာမများ

#### 1. တစ်ခုတည်းတာဝန်ရှိမှု နိယာမ

MCP အင်္ဂါရပ်တိုင်းမှာ ရှင်းလင်းပြီး အာရုံစိုက်ထားသော ရည်ရွယ်ချက်တစ်ခုရှိသင့်သည်။ အမြောက်အများသောတာဝန်များကို ကိုင်တွယ်ရန် ကြိုးစားသော ကိရိယာကြီးများ ဖန်တီးခြင်းမပြုဘဲ၊ အထူးပြုလုပ်ထားသော ကိရိယာများကို တီထွင်၍ အထူးတာဝန်များကို ထိရောက်စွာ ဆောင်ရွက်စေပါ။

**ကောင်းသော နမူနာ:**
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

**မကောင်းသော နမူနာ:**
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

#### 2. အခြေခံပစ္စည်း ထည့်သွင်းခြင်းနှင့် စမ်းသပ်နိုင်မှု

ကိရိယာများကို constructor injection ဖြင့် လိုအပ်သော အခြေခံပစ္စည်းများကို လက်ခံရန် ဒီဇိုင်းဆွဲပြီး စမ်းသပ်နိုင်မှုနှင့် ပြင်ဆင်နိုင်မှု ရရှိစေရန် -

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

#### 3. ပေါင်းစပ်အသုံးပြုနိုင်သော ကိရိယာများ

ပိုမိုရှုပ်ထွေးသော လုပ်ငန်းစဉ်များ ဖန်တီးနိုင်ရန် ကိရိယာများကို ပေါင်းစပ်အသုံးပြုနိုင်အောင် ဒီဇိုင်းဆွဲပါ -

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

### Schema ဒီဇိုင်း အကောင်းဆုံးအလေ့အထများ

Schema သည် မော်ဒယ်နှင့် သင့်ကိရိယာအကြား သဘောတူညီချက်ဖြစ်သည်။ ကောင်းမွန်စွာ ဒီဇိုင်းဆွဲထားသော schema များက ကိရိယာအသုံးပြုမှုကို ပိုမိုကောင်းမွန်စေပါသည်။

#### 1. ပရမားတာ ရှင်းလင်းသော ဖော်ပြချက်များ

ပရမားတာတိုင်းအတွက် ဖော်ပြချက်များ ထည့်သွင်းပေးပါ -

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

မှားယွင်းသော အချက်အလက်များ မဝင်ရောက်နိုင်အောင် စစ်ဆေးမှု ကန့်သတ်ချက်များ ထည့်သွင်းပါ -

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

#### 3. ပြန်လည်ပေးပို့မှု ဖွဲ့စည်းမှု တူညီမှု

မော်ဒယ်များအနေဖြင့် ရလဒ်များကို ပိုမိုလွယ်ကူစွာ အဓိပ္ပာယ်ဖွင့်နိုင်ရန် ပြန်လည်ပေးပို့မှု ဖွဲ့စည်းမှုများကို တူညီစွာ ထိန်းသိမ်းပါ -

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

### မှားယွင်းချက် ကိုင်တွယ်မှု

MCP ကိရိယာများအတွက် ယုံကြည်စိတ်ချရမှုကို ထိန်းသိမ်းရန် ခိုင်မာသော မှားယွင်းချက် ကိုင်တွယ်မှု မရှိမဖြစ်လိုအပ်ပါသည်။

#### 1. သင့်တော်စွာ မှားယွင်းချက် ကိုင်တွယ်မှု

မှားယွင်းချက်များကို သင့်တော်သောအဆင့်တွင် ကိုင်တွယ်ပြီး အသိပေးစာများ ပေးပါ -

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

#### 2. ဖွဲ့စည်းတည်ဆောက်ထားသော မှားယွင်းချက် တုံ့ပြန်ချက်များ

ဖြစ်နိုင်ပါက ဖွဲ့စည်းတည်ဆောက်ထားသော မှားယွင်းချက် အချက်အလက်များ ပြန်ပေးပို့ပါ -

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

#### 3. ထပ်မံကြိုးစားမှု ရုပ်သိမ်းချက်

ယာယီ အောင်မြင်မှုမရှိမှုများအတွက် သင့်တော်သော ထပ်မံကြိုးစားမှု မူဝါဒများ ထည့်သွင်းပါ -

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

### လုပ်ဆောင်မှု မြှင့်တင်ခြင်း

#### 1. Cache သုံးခြင်း

စရိတ်ကြီးသော လုပ်ဆောင်ချက်များအတွက် cache ထည့်သွင်းပါ -

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

#### 2. အဆင့်မြင့် အလုပ်လုပ်ပုံ

I/O ဆိုင်ရာ လုပ်ငန်းများအတွက် asynchronous programming နမူနာများ အသုံးပြုပါ -

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

အလေးပေးမှုများ မဖြစ်ပေါ်စေရန် အရင်းအမြစ်များကို ထိန်းချုပ်ပါ -

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

### လုံခြုံရေး အကောင်းဆုံးအလေ့အထများ

#### 1. အထွက်အချက်အလက် စစ်ဆေးခြင်း

အထွက်အချက်အလက်များကို အမြဲတမ်း ပြည့်စုံစွာ စစ်ဆေးပါ -

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

#### 2. ခွင့်ပြုချက် စစ်ဆေးခြင်း

သင့်တော်သော ခွင့်ပြုချက် စစ်ဆေးမှုများ ထည့်သွင်းပါ -

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

အထူးသဖြင့် အချက်အလက်များကို သတိထားစွာ ကိုင်တွယ်ပါ -

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

## MCP ကိရိယာများအတွက် စမ်းသပ်မှု အကောင်းဆုံးအလေ့အထများ

ကျယ်ပြန့်စွာ စမ်းသပ်ခြင်းသည် MCP ကိရိယာများသည် မှန်ကန်စွာ လုပ်ဆောင်နိုင်မှု၊ အထူးအနေအထားများကို ကိုင်တွယ်နိုင်မှုနှင့် စနစ်အတွင်း အခြားအစိတ်အပိုင်းများနှင့် ပေါင်းစည်းမှု ကောင်းမွန်မှုကို အာမခံပေးသည်။

### တစ်ခုချင်းစမ်းသပ်ခြင်း

#### 1. ကိရိယာတိုင်းကို အလိုက်သင့်စမ်းသပ်မှု

ကိရိယာ၏ လုပ်ဆောင်ချက်ကို အာရုံစိုက်ပြီး စမ်းသပ်ပါ -

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

#### 2. Schema စစ်ဆေးမှု စမ်းသပ်ခြင်း

Schema များသည် မှန်ကန်ပြီး ကန့်သတ်ချက်များကို မှန်ကန်စွာ အကောင်အထည်ဖော်နေကြောင်း စမ်းသပ်ပါ -

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

#### 3. မှားယွင်းချက် ကိုင်တွယ်မှု စမ်းသပ်မှုများ

မှားယွင်းချက် အခြေအနေများအတွက် သီးခြား စမ်းသပ်မှုများ ဖန်တီးပါ -

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

### ပေါင်းစည်းစမ်းသပ်မှု

#### 1. ကိရိယာလမ်းကြောင်း စမ်းသပ်မှု

မျှော်မှန်းထားသည့် ပေါင်းစပ်မှုများဖြင့် ကိရိယာများ အတူတကွ လုပ်ဆောင်မှုကို စမ်းသပ်ပါ -

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

ကိရိယာများ အပြည့်အစုံ မှတ်ပုံတင်ခြင်းနှင့် အကောင်အထည်ဖော်ခြင်းဖြင့် MCP ဆာဗာကို စမ်းသပ်ပါ -

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

မော်ဒယ် prompt မှ ကိရိယာအကောင်အထည်ဖော်မှုအထိ ပြည့်စုံသော လုပ်ငန်းစဉ်များကို စမ်းသပ်ပါ -

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

### လုပ်ဆောင်မှု စမ်းသပ်မှု

#### 1. အလားအလာ စမ်းသပ်မှု

MCP ဆာဗာသည် တစ်ပြိုင်နက်တည်း လက်ခံနိုင်သော တောင်းဆိုမှု အရေအတွက်ကို စမ်းသပ်ပါ -

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

#### 2. စိတ်အားထက်သန်မှု စမ်းသပ်မှု

အလွန်အမင်း ပိတ်ပင်မှုများအောက်တွင် စနစ်ကို စမ်းသပ်ပါ -

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

#### 3. ကြည့်ရှုခြင်းနှင့် ကိုယ်ပိုင်သုံးသပ်ခြင်း

ရှည်လျားသော အချိန်တစ်လျှောက် လုပ်ဆောင်မှုကို ကြည့်ရှုခြင်းနှင့် သုံးသပ်မှု စနစ်များ တပ်ဆင်ပါ -

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

## MCP လုပ်ငန်းစဉ် ဒီဇိုင်း နမူနာများ

ကောင်းမွန်စွာ ဒီဇိုင်းဆွဲထားသော MCP လုပ်ငန်းစဉ်များက ထိရောက်မှု၊ ယုံကြည်စိတ်ချမှုနှင့် ပြုပြင်ထိန်းသိမ်းရလွယ်မှု တိုးတက်စေသည်။ လိုက်နာသင့်သော အဓိက နမူနာများမှာ -

### 1. ကိရိယာများ ချိတ်ဆက်မှု နမူနာ

ကိရိယာများအများစုကို ဆက်တိုက် ချိတ်ဆက်ပြီး တစ်ခုချင်း output ကို နောက်တစ်ခု input အဖြစ် အသုံးပြုပါ -

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

### 2. ပို့ဆောင်သူ နမူနာ

အထွက်အချက်အလက်အပေါ် မူတည်၍ အထူးပြု ကိရိယာများသို့ ပို့ဆောင်ပေးသော အဓိက ကိရိယာကို အသုံးပြုပါ -

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

### 3. 병렬 처리 패턴

효율성을 위해 여러 도구를 동시에 실행합니다:

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

### 4. မှားယွင်းချက် ပြန်လည်ရယူမှု နမူနာ

ကိရိယာ မအောင်မြင်မှုများအတွက် သင့်တော်သော fallback များကို အကောင်အထည်ဖော်ပါ -

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

### 5. လုပ်ငန်းစဉ် ပေါင်းစပ်မှု နမူနာ

ရိုးရှင်းသော လုပ်ငန်းစဉ်များကို ပေါင်းစပ်ပြီး ရှုပ်ထွေးသော လုပ်ငန်းစဉ်များ ဖန်တီးပါ -

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

# MCP ဆာဗာ စမ်းသပ်ခြင်း: အကောင်းဆုံးအလေ့အထများနှင့် ထိပ်တန်းအကြံပြုချက်များ

## အနှစ်ချုပ်

စမ်းသပ်ခြင်းသည် ယုံကြည်စိတ်ချရသော၊ အရည်အသွေးမြင့် MCP ဆာဗာများ ဖန်တီးရာတွင် အရေးကြီးသော အစိတ်အပိုင်းဖြစ်သည်။ ဒီလမ်းညွှန်မှာ MCP ဆာဗာများ၏ ဖွံ့ဖြိုးတိုးတက်မှု လမ်းကြောင်းတလျှောက် စမ်းသပ်မှုများအတွက် အကောင်းဆုံးအလေ့အထများနှင့် အကြံပြုချက်များကို ဖော်ပြထားသည်။

## MCP ဆာဗာများအတွက် စမ်းသပ်ခြင်းအရေးကြီးမှု

MCP ဆာဗာများသည် AI မော်ဒယ်များနှင့် client အပလီကေးရှင်းများအကြား အလယ်အလတ် middleware အဖြစ် တာဝန်ယူသည်။ ပြည့်စုံစွာ စမ်းသပ်ခြင်းက အောက်ပါအချက်များကို အာမခံပေးသည် -

- ထုတ်လုပ်ရေးပတ်ဝန်းကျင်တွင် ယုံကြည်စိတ်ချရမှု
- တောင်းဆိုမှုများနှင့် တုံ့ပြန်မှုများကို မှန်ကန်စွာ ကိုင်တွယ်ခြင်း
- MCP သတ်မှတ်ချက်များကို မှန်ကန်စွာ အကောင်အထည်ဖော်ခြင်း
- မအောင်မြင်မှုများနှင့် အထူးအခြေအနေများကို ခိုင်မာစွာ ကိုင်တွယ်နိုင်မှု
- မတူညီသော အလေးပေးမှုများအောက်တွင် တည်ငြိမ်သော လုပ်ဆောင်မှု

## MCP ဆာဗာများအတွက် တစ်ခုချင်း စမ်းသပ်မှု

### တစ်ခုချင်း စမ်းသပ်မှု (အခြေခံ)

တစ်ခုချင်း စမ်းသပ်မှုများသည် MCP ဆာဗာ၏ တစ်ခုချင်းအစိတ်အပိုင်းများကို သီးခြားစစ်ဆေးသည်။

#### စမ်းသပ်ရန် အချက်များ

1. **အရင်းအမြစ် ကိုင်တွယ်သူများ**: အရင်းအမြစ် ကိုင်တွယ်သူတစ်ဦးချင်းစီ၏ အတွေးအခေါ်ကို သီးခြားစမ်းသပ်ပါ
2. **ကိရိယာ အကောင်အထည်ဖော်မှုများ**: ကိရိယာ၏ အပြုအမူကို အမျိုးမျိုးသော အထွက်အချက်အလက်များဖြင့် စစ်ဆေးပါ
3. **Prompt Templates**: prompt template များမှန်ကန်စွာ ဖော်ပြမှု ရှိ/မရှိ စစ်ဆေးပါ
4. **Schema စစ်ဆေးမှု**: ပရမားတာ စစ်ဆေးမှု အတွေးအခေါ်ကို စမ်းသပ်ပါ
5. **မှားယွင်းချက် ကိုင်တွယ်မှု**: မှားယွင်းသော အချက်အလက်များအတွက် မှားယွင်းချက် တုံ့ပြန်မှုများကို စမ်းသပ်ပါ

#### တစ်ခုချင်း စမ်းသပ်မှု အကောင်းဆုံးအလေ့အထများ

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

### ပေါင်းစည်း စမ်းသပ်မှု (အလယ်အလတ်)

ပေါင်းစည်းစမ်းသပ်မှုများသည် MCP ဆာဗာအစိတ်အပိုင်းများအကြား အပြန်အလှန် ဆက်ဆံမှုများကို စစ်ဆေးသည်။

#### စမ်းသပ်ရန် အချက်များ

1. **ဆာဗာ စတင်ခြင်း**: အမျိုးမျိုးသော ပုံစံများဖြင့် ဆာဗာ စတင်မှုကို စမ်းသပ်ပါ
2. **လမ်းကြောင်း မှတ်ပုံတင်ခြင်း**: အားလုံးသော endpoint များမှန်ကန်စွ

**ရှင်းလင်းချက်**  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ တိကျမှန်ကန်မှုအတွက် ကြိုးစားပေမယ့် အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မှားယွင်းမှုများ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာရွက်စာတမ်းကို မူလဘာသာဖြင့်သာ တရားဝင် အချက်အလက်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် ကျွမ်းကျင်သော လူသားဘာသာပြန်ဝန်ဆောင်မှုကို အသုံးပြုရန် အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်နိုင်သည့် နားလည်မှုမှားယွင်းခြင်းများအတွက် ကျွန်ုပ်တို့ တာဝန်မယူပါ။