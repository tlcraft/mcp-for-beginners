<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36e46bfca83e3528afc6f66803efa75e",
  "translation_date": "2025-05-17T16:56:01+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "pa"
}
-->
# ਐਮ.ਸੀ.ਪੀ. ਵਿਕਾਸ ਦੇ ਚੰਗੇ ਅਭਿਆਸ

## ਸਮੀਖਿਆ

ਇਹ ਪਾਠ ਉਤਪਾਦਨ ਵਾਤਾਵਰਣਾਂ ਵਿੱਚ ਐਮ.ਸੀ.ਪੀ. ਸਰਵਰਾਂ ਅਤੇ ਵਿਸ਼ੇਸ਼ਤਾਵਾਂ ਦੇ ਵਿਕਾਸ, ਟੈਸਟਿੰਗ, ਅਤੇ ਤਾਇਨਾਤੀ ਲਈ ਉੱਚ ਪੱਧਰੀ ਚੰਗੇ ਅਭਿਆਸਾਂ 'ਤੇ ਧਿਆਨ ਕੇਂਦਰਤ ਕਰਦਾ ਹੈ। ਜਿਵੇਂ ਜਿਵੇਂ ਐਮ.ਸੀ.ਪੀ. ਪ੍ਰਣਾਲੀਆਂ ਦੀ ਜਟਿਲਤਾ ਅਤੇ ਮਹੱਤਤਾ ਵਧਦੀ ਹੈ, ਸਥਾਪਤ ਪੈਟਰਨਾਂ ਦੀ ਪਾਲਣਾ ਭਰੋਸੇਯੋਗਤਾ, ਰੱਖ-ਰਖਾਅ, ਅਤੇ ਅੰਤਰ-ਸੰਚਾਲਨ ਯੋਗਤਾ ਨੂੰ ਸੁਨਿਸ਼ਚਿਤ ਕਰਦੀ ਹੈ। ਇਹ ਪਾਠ ਤੁਹਾਨੂੰ ਮਜ਼ਬੂਤ, ਕੁਸ਼ਲ ਸਰਵਰ ਬਣਾਉਣ ਲਈ ਮਾਰਗਦਰਸ਼ਨ ਕਰਨ ਲਈ ਅਸਲੀ ਦੁਨੀਆ ਦੇ ਐਮ.ਸੀ.ਪੀ. ਨਿਰਵਹਣਾਂ ਤੋਂ ਪ੍ਰਾਪਤ ਕੀਤੀ ਗਈ ਵਿਹਾਰਕ ਸਿਆਣਪ ਨੂੰ ਇਕੱਠਾ ਕਰਦਾ ਹੈ।

## ਸਿੱਖਣ ਦੇ ਉਦੇਸ਼

ਇਸ ਪਾਠ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਇਸ ਯੋਗ ਹੋ ਜਾਵੋਗੇ:
- ਐਮ.ਸੀ.ਪੀ. ਸਰਵਰ ਅਤੇ ਵਿਸ਼ੇਸ਼ਤਾ ਡਿਜ਼ਾਈਨ ਵਿੱਚ ਉਦਯੋਗ ਦੇ ਚੰਗੇ ਅਭਿਆਸਾਂ ਨੂੰ ਲਾਗੂ ਕਰੋ
- ਐਮ.ਸੀ.ਪੀ. ਸਰਵਰਾਂ ਲਈ ਵਿਸਥਾਰਕ ਟੈਸਟਿੰਗ ਰਣਨੀਤੀਆਂ ਬਣਾਓ
- ਜਟਿਲ ਐਮ.ਸੀ.ਪੀ. ਐਪਲੀਕੇਸ਼ਨਾਂ ਲਈ ਕੁਸ਼ਲ, ਦੁਬਾਰਾ ਵਰਤਣ ਯੋਗ ਵਰਕਫਲੋ ਪੈਟਰਨਾਂ ਦੀ ਡਿਜ਼ਾਈਨ ਕਰੋ
- ਐਮ.ਸੀ.ਪੀ. ਸਰਵਰਾਂ ਵਿੱਚ ਸਹੀ ਤਰ੍ਹਾਂ ਗਲਤੀ ਸੰਭਾਲ, ਲਾਗਿੰਗ, ਅਤੇ ਦ੍ਰਸ਼ਯਤਾ ਨੂੰ ਲਾਗੂ ਕਰੋ
- ਪ੍ਰਦਰਸ਼ਨ, ਸੁਰੱਖਿਆ, ਅਤੇ ਰੱਖ-ਰਖਾਅ ਲਈ ਐਮ.ਸੀ.ਪੀ. ਨਿਰਵਹਣਾਂ ਨੂੰ ਅਨੁਕੂਲ ਬਣਾਓ

## ਵਾਧੂ ਹਵਾਲੇ

ਐਮ.ਸੀ.ਪੀ. ਦੇ ਚੰਗੇ ਅਭਿਆਸਾਂ ਬਾਰੇ ਸਭ ਤੋਂ ਨਵੀਨਤਮ ਜਾਣਕਾਰੀ ਲਈ, ਹਵਾਲਾ ਦਿਓ:
- [ਐਮ.ਸੀ.ਪੀ. ਦਸਤਾਵੇਜ਼](https://modelcontextprotocol.io/)
- [ਐਮ.ਸੀ.ਪੀ. ਵਿਸ਼ੇਸ਼ਤਾ](https://spec.modelcontextprotocol.io/)
- [GitHub ਰਿਪੋਜ਼ਟਰੀ](https://github.com/modelcontextprotocol)

## ਐਮ.ਸੀ.ਪੀ. ਟੂਲ ਵਿਕਾਸ ਦੇ ਚੰਗੇ ਅਭਿਆਸ

### ਆਰਕੀਟੈਕਚਰ ਦੇ ਸਿਧਾਂਤ

#### 1. ਸਿੰਗਲ ਰਿਸਪਾਂਸਬਿਲਿਟੀ ਪ੍ਰਿੰਸੀਪਲ

ਹਰ ਐਮ.ਸੀ.ਪੀ. ਵਿਸ਼ੇਸ਼ਤਾ ਦਾ ਸਪਸ਼ਟ, ਕੇਂਦਰਤ ਉਦੇਸ਼ ਹੋਣਾ ਚਾਹੀਦਾ ਹੈ। ਬਜਾਏ ਇਹਦੇ ਕਿ ਕਈ ਚਿੰਤਾਵਾਂ ਨੂੰ ਸੰਭਾਲਣ ਦੀ ਕੋਸ਼ਿਸ਼ ਕਰਨ ਵਾਲੇ ਵੱਡੇ ਉਪਕਰਨ ਬਣਾਏ ਜਾਣ, ਖਾਸ ਕਾਰਜਾਂ ਵਿੱਚ ਨਿਪੁੰਨ ਵਿਸ਼ੇਸ਼ ਉਪਕਰਨ ਵਿਕਸਿਤ ਕਰੋ।

**ਵਧੀਆ ਉਦਾਹਰਨ:**
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

**ਖਰਾਬ ਉਦਾਹਰਨ:**
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

#### 2. ਡਿਪੈਂਡੈਂਸੀ ਇੰਜੈਕਸ਼ਨ ਅਤੇ ਟੈਸਟਬਿਲਿਟੀ

ਉਪਕਰਨਾਂ ਨੂੰ ਡਿਪੈਂਡੈਂਸੀਜ਼ ਨੂੰ ਕਨਸਟਰਕਟਰ ਇੰਜੈਕਸ਼ਨ ਰਾਹੀਂ ਪ੍ਰਾਪਤ ਕਰਨ ਲਈ ਡਿਜ਼ਾਈਨ ਕਰੋ, ਜਿਸ ਨਾਲ ਉਹ ਟੈਸਟਬਲ ਅਤੇ ਕਨਫਿਗਰੇਬਲ ਬਣ ਜਾਂਦੇ ਹਨ:

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

#### 3. ਕਮਪੋਜ਼ੇਬਲ ਟੂਲ

ਉਪਕਰਨਾਂ ਨੂੰ ਇਸ ਤਰੀਕੇ ਨਾਲ ਡਿਜ਼ਾਈਨ ਕਰੋ ਕਿ ਉਹ ਹੋਰ ਜਟਿਲ ਵਰਕਫਲੋਜ਼ ਬਣਾਉਣ ਲਈ ਇਕੱਠੇ ਕੀਤੇ ਜਾ ਸਕਣ:

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

### ਸਕੀਮਾ ਡਿਜ਼ਾਈਨ ਦੇ ਚੰਗੇ ਅਭਿਆਸ

ਸਕੀਮਾ ਮਾਡਲ ਅਤੇ ਤੁਹਾਡੇ ਉਪਕਰਨ ਦੇ ਵਿਚਕਾਰ ਦਾ ਠੇਕਾ ਹੈ। ਚੰਗੀ ਤਰ੍ਹਾਂ ਡਿਜ਼ਾਈਨ ਕੀਤੇ ਸਕੀਮੇ ਬਿਹਤਰ ਉਪਕਰਨ ਯੂਜ਼ੇਬਿਲਿਟੀ ਵਲ ਲੈ ਜਾਂਦੇ ਹਨ।

#### 1. ਸਪਸ਼ਟ ਪੈਰਾਮੀਟਰ ਵਰਣਨ

ਹਮੇਸ਼ਾ ਹਰ ਪੈਰਾਮੀਟਰ ਲਈ ਵੇਰਵਾ ਸਮੇਤ ਜਾਣਕਾਰੀ ਸ਼ਾਮਲ ਕਰੋ:

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

#### 2. ਵੈਲੀਡੇਸ਼ਨ ਰੋਕਥਾਮ

ਅਵੈਧ ਇੰਪੁਟਾਂ ਨੂੰ ਰੋਕਣ ਲਈ ਵੈਲੀਡੇਸ਼ਨ ਰੋਕਥਾਮ ਸ਼ਾਮਲ ਕਰੋ:

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

#### 3. ਸਥਿਰ ਵਾਪਸੀ ਸੰਰਚਨਾ

ਤੁਹਾਡੇ ਜਵਾਬ ਦੇ ਢਾਂਚਿਆਂ ਵਿੱਚ ਸਥਿਰਤਾ ਬਣਾਈ ਰੱਖੋ ਤਾਂ ਕਿ ਮਾਡਲਾਂ ਲਈ ਨਤੀਜੇ ਦੀ ਵਿਆਖਿਆ ਕਰਨਾ ਆਸਾਨ ਹੋਵੇ:

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

### ਗਲਤੀ ਸੰਭਾਲ

ਐਮ.ਸੀ.ਪੀ. ਉਪਕਰਨਾਂ ਲਈ ਭਰੋਸੇਯੋਗਤਾ ਬਰਕਰਾਰ ਰੱਖਣ ਲਈ ਮਜ਼ਬੂਤ ਗਲਤੀ ਸੰਭਾਲ ਅਤਿਅੰਤ ਮਹੱਤਵਪੂਰਣ ਹੈ।

#### 1. ਮਰਿਆਦਾ ਪੂਰਨ ਗਲਤੀ ਸੰਭਾਲ

ਗਲਤੀਆਂ ਨੂੰ ਉਚਿਤ ਪੱਧਰਾਂ 'ਤੇ ਸੰਭਾਲੋ ਅਤੇ ਜਾਣਕਾਰੀ ਭਰੀਆਂ ਸੁਨੇਹੇ ਪ੍ਰਦਾਨ ਕਰੋ:

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

#### 2. ਸੰਰਚਿਤ ਗਲਤੀ ਜਵਾਬ

ਜਿੱਥੇ ਸੰਭਵ ਹੋਵੇ, ਸੰਰਚਿਤ ਗਲਤੀ ਜਾਣਕਾਰੀ ਵਾਪਸ ਕਰੋ:

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

#### 3. ਰੀਟ੍ਰਾਈ ਲਾਜਿਕ

ਅਸਥਾਈ ਨਾਕਾਮੀਆਂ ਲਈ ਉਚਿਤ ਰੀਟ੍ਰਾਈ ਲਾਜਿਕ ਲਾਗੂ ਕਰੋ:

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

### ਪ੍ਰਦਰਸ਼ਨ ਅਨੁਕੂਲਤਾ

#### 1. ਕੈਸ਼ਿੰਗ

ਮਹਿੰਗੇ ਓਪਰੇਸ਼ਨਾਂ ਲਈ ਕੈਸ਼ਿੰਗ ਲਾਗੂ ਕਰੋ:

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

#### 2. ਅਸੰਕਲਪਤ ਪ੍ਰਕਿਰਿਆ

I/O-ਬਾਊਂਡ ਓਪਰੇਸ਼ਨਾਂ ਲਈ ਅਸੰਕਲਪਤ ਪ੍ਰੋਗਰਾਮਿੰਗ ਪੈਟਰਨ ਵਰਤੋ:

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

#### 3. ਸਰੋਤ ਥਰੌਟਲਿੰਗ

ਅਧਿਕ ਲੋਡ ਤੋਂ ਬਚਣ ਲਈ ਸਰੋਤ ਥਰੌਟਲਿੰਗ ਲਾਗੂ ਕਰੋ:

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

### ਸੁਰੱਖਿਆ ਦੇ ਚੰਗੇ ਅਭਿਆਸ

#### 1. ਇੰਪੁਟ ਵੈਲੀਡੇਸ਼ਨ

ਹਮੇਸ਼ਾ ਇੰਪੁਟ ਪੈਰਾਮੀਟਰਾਂ ਦੀ ਪੂਰੀ ਤਰ੍ਹਾਂ ਵੈਲੀਡੇਸ਼ਨ ਕਰੋ:

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

#### 2. ਅਧਿਕਾਰ ਜਾਂਚ

ਸਹੀ ਅਧਿਕਾਰ ਜਾਂਚ ਲਾਗੂ ਕਰੋ:

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

#### 3. ਸੰਵੇਦਨਸ਼ੀਲ ਡੇਟਾ ਸੰਭਾਲ

ਸੰਵੇਦਨਸ਼ੀਲ ਡੇਟਾ ਨੂੰ ਸਾਵਧਾਨੀ ਨਾਲ ਸੰਭਾਲੋ:

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

## ਐਮ.ਸੀ.ਪੀ. ਉਪਕਰਨਾਂ ਲਈ ਟੈਸਟਿੰਗ ਦੇ ਚੰਗੇ ਅਭਿਆਸ

ਵਿਸਥਾਰਕ ਟੈਸਟਿੰਗ ਇਹ ਯਕੀਨੀ ਬਣਾਉਂਦੀ ਹੈ ਕਿ ਐਮ.ਸੀ.ਪੀ. ਉਪਕਰਨ ਸਹੀ ਤਰੀਕੇ ਨਾਲ ਕੰਮ ਕਰਦੇ ਹਨ, ਬਾਰਡਰ ਕੈਸਾਂ ਨੂੰ ਸੰਭਾਲਦੇ ਹਨ, ਅਤੇ ਪ੍ਰਣਾਲੀ ਦੇ ਬਾਕੀ ਹਿੱਸਿਆਂ ਨਾਲ ਠੀਕ ਤਰੀਕੇ ਨਾਲ ਇਕੱਠੇ ਹੁੰਦੇ ਹਨ।

### ਯੂਨਿਟ ਟੈਸਟਿੰਗ

#### 1. ਹਰ ਉਪਕਰਣ ਨੂੰ ਅਲੱਗ-ਅਲੱਗ ਟੈਸਟ ਕਰੋ

ਹਰ ਉਪਕਰਣ ਦੀ ਕਾਰਗੁਜ਼ਾਰੀ ਲਈ ਕੇਂਦਰਤ ਟੈਸਟ ਬਣਾਓ:

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

#### 2. ਸਕੀਮਾ ਵੈਲੀਡੇਸ਼ਨ ਟੈਸਟਿੰਗ

ਇਹ ਟੈਸਟ ਕਰੋ ਕਿ ਸਕੀਮੇ ਵੈਧ ਹਨ ਅਤੇ ਰੋਕਥਾਮ ਨੂੰ ਠੀਕ ਤਰੀਕੇ ਨਾਲ ਲਾਗੂ ਕਰਦੇ ਹਨ:

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

#### 3. ਗਲਤੀ ਸੰਭਾਲ ਟੈਸਟ

ਗਲਤੀ ਦੀਆਂ ਸਥਿਤੀਆਂ ਲਈ ਖਾਸ ਟੈਸਟ ਬਣਾਓ:

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

### ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਟੈਸਟਿੰਗ

#### 1. ਟੂਲ ਚੇਨ ਟੈਸਟਿੰਗ

ਉਮੀਦ ਕੀਤੀਆਂ ਸੰਯੁਕਤਾਂ ਵਿੱਚ ਕੰਮ ਕਰਨ ਵਾਲੇ ਉਪਕਰਣਾਂ ਦਾ ਟੈਸਟ ਕਰੋ:

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

#### 2. ਐਮ.ਸੀ.ਪੀ. ਸਰਵਰ ਟੈਸਟਿੰਗ

ਪੂਰੇ ਟੂਲ ਰਜਿਸਟਰੇਸ਼ਨ ਅਤੇ ਕਾਰਗੁਜ਼ਾਰੀ ਦੇ ਨਾਲ ਐਮ.ਸੀ.ਪੀ. ਸਰਵਰ ਦਾ ਟੈਸਟ ਕਰੋ:

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

#### 3. ਅੰਤ-ਤੱਕ ਟੈਸਟਿੰਗ

ਮਾਡਲ ਪ੍ਰੋਮਪਟ ਤੋਂ ਲੈ ਕੇ ਟੂਲ ਕਾਰਗੁਜ਼ਾਰੀ ਤੱਕ ਪੂਰੇ ਵਰਕਫਲੋਜ਼ ਦਾ ਟੈਸਟ ਕਰੋ:

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

### ਪ੍ਰਦਰਸ਼ਨ ਟੈਸਟਿੰਗ

#### 1. ਲੋਡ ਟੈਸਟਿੰਗ

ਟੈਸਟ ਕਰੋ ਕਿ ਤੁਹਾਡਾ ਐਮ.ਸੀ.ਪੀ. ਸਰਵਰ ਕਿੰਨੀਆਂ ਸਮਕਾਲੀ ਬੇਨਤੀਆਂ ਨੂੰ ਸੰਭਾਲ ਸਕਦਾ ਹੈ:

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

#### 2. ਸਟ੍ਰੈੱਸ ਟੈਸਟਿੰਗ

ਪ੍ਰਣਾਲੀ ਦਾ ਅਤਿ ਲੋਡ ਹੇਠ ਟੈਸਟ ਕਰੋ:

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

#### 3. ਨਿਗਰਾਨੀ ਅਤੇ ਪ੍ਰੋਫਾਇਲਿੰਗ

ਲੰਮੇ ਸਮੇਂ ਦੀ ਪ੍ਰਦਰਸ਼ਨ ਵਿਸ਼ਲੇਸ਼ਣ ਲਈ ਨਿਗਰਾਨੀ ਸੈਟ ਅੱਪ ਕਰੋ:

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

## ਐਮ.ਸੀ.ਪੀ. ਵਰਕਫਲੋ ਡਿਜ਼ਾਈਨ ਪੈਟਰਨ

ਚੰਗੀ ਤਰ੍ਹਾਂ ਡਿਜ਼ਾਈਨ ਕੀਤੇ ਐਮ.ਸੀ.ਪੀ. ਵਰਕਫਲੋਜ਼ ਕੁਸ਼ਲਤਾ, ਭਰੋਸੇਯੋਗਤਾ, ਅਤੇ ਰੱਖ-ਰਖਾਅ ਵਿੱਚ ਸੁਧਾਰ ਕਰਦੇ ਹਨ। ਇੱਥੇ ਕੁਝ ਮੁੱਖ ਪੈਟਰਨ ਹਨ ਜਿਨ੍ਹਾਂ ਦੀ ਪਾਲਣਾ ਕੀਤੀ ਜਾਣੀ ਚਾਹੀਦੀ ਹੈ:

### 1. ਟੂਲ ਚੇਨ ਪੈਟਰਨ

ਕਈ ਉਪਕਰਣਾਂ ਨੂੰ ਲੜੀਵਾਰ ਜੁੜੋ ਜਿੱਥੇ ਹਰ ਉਪਕਰਣ ਦੀ ਆਉਟਪੁੱਟ ਅਗਲੇ ਲਈ ਇਨਪੁੱਟ ਬਣ ਜਾਂਦੀ ਹੈ:

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

### 2. ਡਿਸਪੈਚਰ ਪੈਟਰਨ

ਇੱਕ ਕੇਂਦਰੀ ਉਪਕਰਣ ਵਰਤੋਂ ਜੋ ਇਨਪੁੱਟ ਦੇ ਆਧਾਰ 'ਤੇ ਵਿਸ਼ੇਸ਼ ਉਪਕਰਣਾਂ ਨੂੰ ਡਿਸਪੈਚ ਕਰਦਾ ਹੈ:

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

### 3. ਸਮਕਾਲੀ ਪ੍ਰਕਿਰਿਆ ਪੈਟਰਨ

ਕੁਸ਼ਲਤਾ ਲਈ ਕਈ ਉਪਕਰਣਾਂ ਨੂੰ ਇੱਕਸਮੇਂ ਚਲਾਓ:

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

### 4. ਗਲਤੀ ਪੁਨਰ ਪ੍ਰਾਪਤੀ ਪੈਟਰਨ

ਉਪਕਰਣ ਦੀਆਂ ਅਸਫਲਤਾਵਾਂ ਲਈ ਮਰਿਆਦਾ ਪੂਰਨ ਬਦਲ ਲਾਗੂ ਕਰੋ:

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

### 5. ਵਰਕਫਲੋ ਸੰਯੋਜਨ ਪੈਟਰਨ

ਸਧਾਰਨ ਵਰਕਫਲੋਜ਼ ਨੂੰ ਸੰਯੋਜਨ ਕਰਕੇ ਜਟਿਲ ਵਰਕਫਲੋਜ਼ ਬਣਾਓ:

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

# ਐਮ.ਸੀ.ਪੀ. ਸਰਵਰਾਂ ਦੀ ਟੈਸਟਿੰਗ: ਚੰਗੇ ਅਭਿਆਸ ਅਤੇ ਸਭ ਤੋਂ ਵਧੀਆ ਸੁਝਾਅ

## ਸਮੀਖਿਆ

ਟੈਸਟਿੰਗ ਭਰੋਸੇਯੋਗ, ਉੱਚ-ਗੁਣਵੱਤਾ ਵਾਲੇ ਐਮ.ਸੀ.ਪੀ. ਸਰਵਰਾਂ ਦੇ ਵਿਕਾਸ ਦਾ ਇੱਕ ਅਹਿਮ ਪਹਲੂ ਹੈ। ਇਹ ਗਾਈਡ ਤੁਹਾਡੇ ਐਮ.ਸੀ.ਪੀ. ਸਰਵਰਾਂ ਨੂੰ ਯੂਨਿਟ ਟੈਸਟ ਤੋਂ ਲੈ ਕੇ ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਟੈਸਟ ਅਤੇ ਅੰਤ-ਤੱਕ ਵੈਧਤਾ ਤੱਕ ਵਿਕਾਸ ਦੇ ਜੀਵਨ ਚੱਕਰ ਦੇ ਦੌਰਾਨ ਟੈਸਟ ਕਰਨ ਲਈ ਵਿਸਥਾਰਕ ਚੰਗੇ ਅਭਿਆਸ ਅਤੇ ਸੁਝਾਅ ਪ੍ਰਦਾਨ ਕਰਦੀ ਹੈ।

## ਐਮ.ਸੀ.ਪੀ. ਸਰਵਰਾਂ ਲਈ ਟੈਸਟਿੰਗ ਕਿਉਂ ਮਹੱਤਵਪੂਰਣ ਹੈ

ਐਮ.ਸੀ.ਪੀ. ਸਰਵਰ AI ਮਾਡਲਾਂ ਅਤੇ ਕਲਾਇੰਟ ਐਪਲੀਕੇਸ਼ਨਾਂ ਦੇ ਵਿਚਕਾਰ ਅਹਿਮ ਮਿਡਲਵੇਅਰ ਵਜੋਂ ਕੰਮ ਕਰਦੇ ਹਨ। ਵਿਸਥਾਰਕ ਟੈਸਟਿੰਗ ਇਹ ਸੁਨਿਸ਼ਚਿਤ ਕਰਦੀ ਹੈ:

- ਉਤਪਾਦਨ ਵਾਤਾਵਰਣਾਂ ਵਿੱਚ ਭਰੋਸੇਯੋਗਤਾ
- ਬੇਨਤੀਆਂ ਅਤੇ ਜਵਾਬਾਂ ਦਾ ਸਹੀ ਸੰਭਾਲ
- ਐਮ.ਸੀ.ਪੀ. ਵਿਸ਼ੇਸ਼ਤਾਵਾਂ ਦਾ ਸਹੀ ਨਿਰਵਹਣ
- ਅਸਫਲਤਾਵਾਂ ਅਤੇ ਬਾਰਡਰ ਕੈਸਾਂ ਦੇ ਖਿਲਾਫ਼ ਲਚੀਲਾਪਣ
- ਵੱਖ-ਵੱਖ ਲੋਡਾਂ ਹੇਠ ਸਥਿਰ ਪ੍ਰਦਰਸ਼ਨ

## ਐਮ.ਸੀ.ਪੀ. ਸਰਵਰਾਂ ਲਈ ਯੂਨਿਟ ਟੈਸਟਿੰਗ

### ਯੂਨਿਟ ਟੈਸਟਿੰਗ (ਬੁਨਿਆਦ)

ਯੂਨਿਟ ਟੈਸਟ ਤੁਹਾਡੇ ਐਮ.ਸੀ.ਪੀ. ਸਰਵਰ ਦੇ ਵਿਅਕਤੀਗਤ ਹਿੱਸਿਆਂ ਨੂੰ ਅਲੱਗ-ਅਲੱਗ ਵੈਰੀਫਾਈ ਕਰਦੇ ਹਨ।

#### ਕੀ ਟੈਸਟ ਕਰਨਾ ਹੈ

1. **ਸਰੋਤ ਸੰਭਾਲਕ**: ਹਰੇਕ ਸਰੋਤ ਸੰਭਾਲਕ ਦੀ ਤਰਕ ਨੂੰ ਅਲੱਗ-ਅਲੱਗ ਟੈਸਟ ਕਰੋ
2. **ਟੂਲ ਨਿਰਵਹਣਾਂ**: ਵੱਖ-ਵੱਖ ਇੰਪੁੱਟਾਂ ਨਾਲ ਉਪਕਰਣ ਦੇ ਵਿਵਹਾਰ ਦੀ ਪੁਸ਼ਟੀ ਕਰੋ
3. **ਪ੍ਰੋਮਪਟ ਟੈਮਪਲੇਟ**: ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਪ੍ਰੋਮਪਟ ਟੈਮਪਲੇਟ ਠੀਕ ਤਰੀਕੇ ਨਾਲ ਰੈਂਡਰ ਹੁੰਦੇ ਹਨ
4. **ਸਕੀਮਾ ਵੈਲੀਡੇਸ਼ਨ**: ਪੈਰਾਮੀਟਰ ਵੈਲੀਡੇਸ਼ਨ ਲਾਜਿਕ ਦੀ ਜਾਂਚ ਕਰੋ
5. **ਗਲਤੀ ਸੰਭਾਲ**: ਅਵੈਧ ਇੰਪੁੱਟਾਂ ਲਈ ਗਲਤੀ ਦੇ ਜਵਾਬਾਂ ਦੀ ਪੁਸ਼ਟੀ ਕਰੋ

#### ਯੂਨਿਟ ਟੈਸਟਿੰਗ ਲਈ ਚੰਗੇ ਅਭਿਆਸ

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

### ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਟੈਸਟਿੰਗ (ਮੱਧ ਪੱਧਰ)

ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਟੈਸਟ ਤੁਹਾਡੇ ਐਮ.ਸੀ.ਪੀ. ਸਰਵਰ ਦੇ ਹਿੱਸਿਆਂ ਦੇ ਵਿਚਕਾਰ ਦੇ ਅੰਤਰਕ੍ਰਿਆਵਾਂ ਦੀ ਪੁਸ਼ਟੀ ਕਰਦੇ ਹਨ।

#### ਕੀ ਟੈਸਟ ਕਰਨਾ ਹੈ

1. **ਸਰਵਰ ਸ਼ੁਰੂਆਤ**: ਵੱਖ-ਵੱਖ ਸੰਰਚਨਾਵਾਂ ਨਾਲ ਸਰਵਰ ਸ਼ੁਰੂਆਤ ਦਾ ਟੈਸਟ ਕਰੋ
2. **ਰੂਟ ਰਜਿਸਟਰੇਸ਼ਨ**: ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਸਾਰੇ ਐਂਡਪੋਇੰਟ ਠੀਕ ਤਰੀਕੇ ਨਾਲ ਰਜਿਸਟਰ ਕੀਤੇ ਗਏ ਹਨ
3. **ਬੇਨਤੀ ਪ੍ਰਕਿਰਿਆ**: ਪੂਰੇ ਬੇਨਤੀ-ਜਵਾਬ ਚੱਕਰ ਦਾ ਟੈਸਟ ਕਰੋ
4. **ਗਲਤੀ ਪ੍ਰਸਾਰਣ**: ਇਹ ਸੁਨਿਸ਼ਚਿਤ ਕਰੋ ਕਿ ਗਲਤੀਆਂ ਹਿੱਸਿਆਂ ਵਿੱਚ ਠੀਕ ਤਰੀਕੇ ਨਾਲ ਸੰਭਾਲੀਆਂ ਜਾਂਦੀਆਂ ਹਨ
5. **ਪ੍ਰਮਾਣੀਕਰਨ ਅਤੇ ਅਧਿਕਾਰ**: ਸੁਰੱਖਿਆ ਮਕੈਨਿਜ਼ਮਾਂ ਦਾ ਟੈਸਟ ਕਰੋ

#### ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਟੈਸਟਿੰਗ ਲਈ ਚੰਗੇ ਅਭਿਆਸ

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

### ਅੰਤ-ਤੱਕ ਟੈਸਟਿੰਗ (ਸਿਖਰ ਪੱਧਰ)

ਅੰਤ-ਤੱਕ ਟੈਸਟ ਕਲਾਇੰਟ ਤੋਂ ਸਰਵਰ ਤੱਕ ਪੂਰੇ ਸਿਸਟਮ ਦੇ ਵਿਵਹਾਰ ਦੀ ਪੁਸ਼ਟੀ ਕਰਦੇ ਹਨ।

#### ਕੀ ਟੈਸਟ ਕਰਨਾ ਹੈ

1. **ਕਲਾਇੰਟ-ਸਰਵਰ ਸੰਚਾਰ**: ਪੂਰੇ ਬੇਨਤੀ-ਜਵਾਬ ਚੱਕਰਾਂ ਦਾ ਟੈਸਟ ਕਰੋ
2. **ਅਸਲ ਕਲਾਇੰਟ SDKs**: ਅਸਲ ਕਲਾਇੰਟ ਨਿਰਵਹਣਾਂ ਨਾਲ ਟੈਸਟ ਕਰੋ
3. **ਲੋਡ ਹੇਠ ਪ੍ਰਦਰਸ਼ਨ**: ਕਈ ਸਮਕਾਲੀ ਬੇਨਤੀਆਂ ਨਾਲ ਵਿਵਹਾਰ ਦੀ ਪੁਸ਼ਟੀ ਕਰੋ
4. **ਗਲਤੀ ਪੁਨਰ ਪ੍ਰਾਪਤੀ**: ਅਸਫਲਤਾਵਾਂ ਤੋਂ ਪ੍ਰਣਾਲੀ ਦੀ ਪੁਨਰ ਪ੍ਰਾਪਤੀ ਦਾ ਟੈਸਟ ਕਰੋ
5. **ਲੰਬੇ ਸਮੇਂ ਚੱਲਣ ਵਾਲੇ ਓ

**ਅਸਵੀਕਰਤੀਕਰਨ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀ ਹੋਣ ਦੀ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਸਾਵਧਾਨ ਰਹੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸੁਤੀਆਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਇਸਦੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਮੂਲ ਦਸਤਾਵੇਜ਼ ਨੂੰ ਅਧਿਕਾਰਤ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉਪਜਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀਆਂ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆਵਾਂ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।