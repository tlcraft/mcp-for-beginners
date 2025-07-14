<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "10d7df03cff1fa3cf3c56dc06e82ba79",
  "translation_date": "2025-07-14T04:59:12+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "pa"
}
-->
# MCP ਵਿਕਾਸ ਲਈ ਸਰਵੋਤਮ ਅਭਿਆਸ

## ਝਲਕ

ਇਸ ਪਾਠ ਵਿੱਚ MCP ਸਰਵਰਾਂ ਅਤੇ ਫੀਚਰਾਂ ਨੂੰ ਉਤਪਾਦਨ ਵਾਤਾਵਰਣ ਵਿੱਚ ਵਿਕਸਿਤ, ਟੈਸਟ ਅਤੇ ਡਿਪਲੋਇ ਕਰਨ ਲਈ ਉੱਚ-ਸਤਹ ਦੇ ਸਰਵੋਤਮ ਅਭਿਆਸਾਂ 'ਤੇ ਧਿਆਨ ਦਿੱਤਾ ਗਿਆ ਹੈ। ਜਿਵੇਂ ਜਿਵੇਂ MCP ਪਰਿਸਰ ਜਟਿਲ ਅਤੇ ਮਹੱਤਵਪੂਰਨ ਹੁੰਦੇ ਜਾਂਦੇ ਹਨ, ਸਥਾਪਿਤ ਪੈਟਰਨਾਂ ਦੀ ਪਾਲਣਾ ਭਰੋਸੇਯੋਗਤਾ, ਸੰਭਾਲਯੋਗਤਾ ਅਤੇ ਆਪਸੀ ਕੰਮਕਾਜ ਨੂੰ ਯਕੀਨੀ ਬਣਾਉਂਦੀ ਹੈ। ਇਹ ਪਾਠ ਅਸਲੀ ਦੁਨੀਆ ਦੇ MCP ਲਾਗੂ ਕਰਨ ਦੇ ਤਜਰਬਿਆਂ ਤੋਂ ਪ੍ਰਾਪਤ ਪ੍ਰਯੋਗਿਕ ਗਿਆਨ ਨੂੰ ਇਕੱਠਾ ਕਰਦਾ ਹੈ ਤਾਂ ਜੋ ਤੁਸੀਂ ਮਜ਼ਬੂਤ, ਪ੍ਰਭਾਵਸ਼ਾਲੀ ਸਰਵਰ ਬਣਾਉਣ ਵਿੱਚ ਸਹਾਇਤਾ ਪ੍ਰਾਪਤ ਕਰ ਸਕੋ, ਜਿਨ੍ਹਾਂ ਵਿੱਚ ਪ੍ਰਭਾਵਸ਼ਾਲੀ ਸਰੋਤ, ਪ੍ਰਾਂਪਟ ਅਤੇ ਟੂਲ ਸ਼ਾਮਲ ਹਨ।

## ਸਿੱਖਣ ਦੇ ਉਦੇਸ਼

ਇਸ ਪਾਠ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਸਮਰੱਥ ਹੋਵੋਗੇ:
- MCP ਸਰਵਰ ਅਤੇ ਫੀਚਰ ਡਿਜ਼ਾਈਨ ਵਿੱਚ ਉਦਯੋਗ ਦੇ ਸਰਵੋਤਮ ਅਭਿਆਸ ਲਾਗੂ ਕਰਨ
- MCP ਸਰਵਰਾਂ ਲਈ ਵਿਸਤ੍ਰਿਤ ਟੈਸਟਿੰਗ ਰਣਨੀਤੀਆਂ ਬਣਾਉਣ
- ਜਟਿਲ MCP ਐਪਲੀਕੇਸ਼ਨਾਂ ਲਈ ਪ੍ਰਭਾਵਸ਼ਾਲੀ, ਦੁਬਾਰਾ ਵਰਤਣ ਯੋਗ ਵਰਕਫਲੋ ਪੈਟਰਨ ਡਿਜ਼ਾਈਨ ਕਰਨ
- MCP ਸਰਵਰਾਂ ਵਿੱਚ ਠੀਕ ਤਰ੍ਹਾਂ ਗਲਤੀ ਸੰਭਾਲ, ਲੌਗਿੰਗ ਅਤੇ ਨਿਰੀਖਣ ਲਾਗੂ ਕਰਨ
- ਪ੍ਰਦਰਸ਼ਨ, ਸੁਰੱਖਿਆ ਅਤੇ ਸੰਭਾਲਯੋਗਤਾ ਲਈ MCP ਲਾਗੂ ਕਰਨ ਦੀ ਅਪਟੀਮਾਈਜ਼ੇਸ਼ਨ

## ਵਾਧੂ ਸੰਦਰਭ

MCP ਸਰਵੋਤਮ ਅਭਿਆਸਾਂ ਬਾਰੇ ਸਭ ਤੋਂ ਨਵੀਂ ਜਾਣਕਾਰੀ ਲਈ, ਹਵਾਲਾ ਦਿਓ:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## MCP ਟੂਲ ਵਿਕਾਸ ਲਈ ਸਰਵੋਤਮ ਅਭਿਆਸ

### ਆਰਕੀਟੈਕਚਰਲ ਸਿਧਾਂਤ

#### 1. ਸਿੰਗਲ ਜ਼ਿੰਮੇਵਾਰੀ ਸਿਧਾਂਤ

ਹਰ MCP ਫੀਚਰ ਦਾ ਇੱਕ ਸਾਫ਼ ਅਤੇ ਕੇਂਦਰਿਤ ਮਕਸਦ ਹੋਣਾ ਚਾਹੀਦਾ ਹੈ। ਬਹੁਤ ਸਾਰੇ ਕੰਮਾਂ ਨੂੰ ਸੰਭਾਲਣ ਵਾਲੇ ਵੱਡੇ ਟੂਲ ਬਣਾਉਣ ਦੀ ਬਜਾਏ, ਖਾਸ ਕੰਮਾਂ ਵਿੱਚ ਮਾਹਿਰ ਵਿਸ਼ੇਸ਼ ਟੂਲ ਵਿਕਸਿਤ ਕਰੋ।

**ਚੰਗਾ ਉਦਾਹਰਨ:**
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

#### 2. ਡਿਪੈਂਡੈਂਸੀ ਇੰਜੈਕਸ਼ਨ ਅਤੇ ਟੈਸਟੇਬਿਲਿਟੀ

ਟੂਲਾਂ ਨੂੰ ਇਸ ਤਰ੍ਹਾਂ ਡਿਜ਼ਾਈਨ ਕਰੋ ਕਿ ਉਹ ਆਪਣੀਆਂ ਡਿਪੈਂਡੈਂਸੀਜ਼ ਕਨਸਟ੍ਰਕਟਰ ਇੰਜੈਕਸ਼ਨ ਰਾਹੀਂ ਪ੍ਰਾਪਤ ਕਰਨ, ਜਿਸ ਨਾਲ ਉਹ ਟੈਸਟ ਕਰਨ ਯੋਗ ਅਤੇ ਸੰਰਚਨਾਤਮਕ ਬਣ ਜਾਂਦੇ ਹਨ:

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

#### 3. ਕੰਪੋਜ਼ੇਬਲ ਟੂਲ

ਇਸ ਤਰ੍ਹਾਂ ਟੂਲ ਡਿਜ਼ਾਈਨ ਕਰੋ ਜੋ ਇਕੱਠੇ ਮਿਲ ਕੇ ਜਟਿਲ ਵਰਕਫਲੋ ਬਣਾਉਣ ਲਈ ਕੰਮ ਕਰ ਸਕਣ:

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

### ਸਕੀਮਾ ਡਿਜ਼ਾਈਨ ਲਈ ਸਰਵੋਤਮ ਅਭਿਆਸ

ਸਕੀਮਾ ਮਾਡਲ ਅਤੇ ਤੁਹਾਡੇ ਟੂਲ ਵਿਚਕਾਰ ਦਾ ਸਮਝੌਤਾ ਹੁੰਦਾ ਹੈ। ਚੰਗੀ ਤਰ੍ਹਾਂ ਡਿਜ਼ਾਈਨ ਕੀਤੇ ਸਕੀਮਾ ਟੂਲ ਦੀ ਵਰਤੋਂ ਨੂੰ ਬਿਹਤਰ ਬਣਾਉਂਦੇ ਹਨ।

#### 1. ਸਾਫ਼ ਪੈਰਾਮੀਟਰ ਵੇਰਵੇ

ਹਰ ਪੈਰਾਮੀਟਰ ਲਈ ਸਦਾ ਵੇਰਵਾ ਸ਼ਾਮਲ ਕਰੋ:

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

#### 2. ਵੈਧਤਾ ਸੀਮਾਵਾਂ

ਗਲਤ ਇਨਪੁੱਟ ਨੂੰ ਰੋਕਣ ਲਈ ਵੈਧਤਾ ਸੀਮਾਵਾਂ ਸ਼ਾਮਲ ਕਰੋ:

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

#### 3. ਲਗਾਤਾਰ ਰਿਟਰਨ ਸਟ੍ਰਕਚਰ

ਆਪਣੇ ਜਵਾਬਾਂ ਦੀ ਬਣਤਰ ਵਿੱਚ ਲਗਾਤਾਰਤਾ ਰੱਖੋ ਤਾਂ ਜੋ ਮਾਡਲ ਨਤੀਜਿਆਂ ਨੂੰ ਆਸਾਨੀ ਨਾਲ ਸਮਝ ਸਕੇ:

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

ਮਜ਼ਬੂਤ ਗਲਤੀ ਸੰਭਾਲ MCP ਟੂਲਾਂ ਦੀ ਭਰੋਸੇਯੋਗਤਾ ਲਈ ਬਹੁਤ ਜ਼ਰੂਰੀ ਹੈ।

#### 1. ਨਰਮ ਗਲਤੀ ਸੰਭਾਲ

ਉਚਿਤ ਪੱਧਰਾਂ 'ਤੇ ਗਲਤੀਆਂ ਨੂੰ ਸੰਭਾਲੋ ਅਤੇ ਜਾਣਕਾਰੀ ਭਰਪੂਰ ਸੁਨੇਹੇ ਦਿਓ:

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

ਜਦੋਂ ਸੰਭਵ ਹੋਵੇ ਤਾਂ ਸੰਰਚਿਤ ਗਲਤੀ ਜਾਣਕਾਰੀ ਵਾਪਸ ਕਰੋ:

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

#### 3. ਦੁਬਾਰਾ ਕੋਸ਼ਿਸ਼ ਕਰਨ ਦੀ ਤਰਕ

ਅਸਥਾਈ ਨਾਕਾਮੀਆਂ ਲਈ ਢੁਕਵੀਂ ਦੁਬਾਰਾ ਕੋਸ਼ਿਸ਼ ਕਰਨ ਦੀ ਤਰਕ ਲਾਗੂ ਕਰੋ:

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

### ਪ੍ਰਦਰਸ਼ਨ ਅਪਟੀਮਾਈਜ਼ੇਸ਼ਨ

#### 1. ਕੈਸ਼ਿੰਗ

ਮਹਿੰਗੀਆਂ ਕਾਰਵਾਈਆਂ ਲਈ ਕੈਸ਼ਿੰਗ ਲਾਗੂ ਕਰੋ:

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

#### 2. ਅਸਿੰਕ੍ਰੋਨਸ ਪ੍ਰੋਸੈਸਿੰਗ

I/O-ਬਾਊਂਡ ਕਾਰਵਾਈਆਂ ਲਈ ਅਸਿੰਕ੍ਰੋਨਸ ਪ੍ਰੋਗ੍ਰਾਮਿੰਗ ਪੈਟਰਨ ਵਰਤੋ:

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

#### 3. ਸਰੋਤ ਸੀਮਿਤ ਕਰਨਾ

ਓਵਰਲੋਡ ਨੂੰ ਰੋਕਣ ਲਈ ਸਰੋਤ ਸੀਮਿਤ ਕਰਨ ਦੀ ਵਿਧੀ ਲਾਗੂ ਕਰੋ:

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

### ਸੁਰੱਖਿਆ ਲਈ ਸਰਵੋਤਮ ਅਭਿਆਸ

#### 1. ਇਨਪੁੱਟ ਵੈਧਤਾ

ਹਮੇਸ਼ਾ ਇਨਪੁੱਟ ਪੈਰਾਮੀਟਰਾਂ ਦੀ ਪੂਰੀ ਤਰ੍ਹਾਂ ਜਾਂਚ ਕਰੋ:

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

ਠੀਕ ਅਧਿਕਾਰ ਜਾਂਚ ਲਾਗੂ ਕਰੋ:

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

ਸੰਵੇਦਨਸ਼ੀਲ ਡੇਟਾ ਨੂੰ ਧਿਆਨ ਨਾਲ ਸੰਭਾਲੋ:

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

## MCP ਟੂਲਾਂ ਲਈ ਟੈਸਟਿੰਗ ਦੇ ਸਰਵੋਤਮ ਅਭਿਆਸ

ਵਿਸਤ੍ਰਿਤ ਟੈਸਟਿੰਗ ਇਹ ਯਕੀਨੀ ਬਣਾਉਂਦੀ ਹੈ ਕਿ MCP ਟੂਲ ਸਹੀ ਤਰ੍ਹਾਂ ਕੰਮ ਕਰਦੇ ਹਨ, ਕਿਨਾਰੇ ਦੇ ਕੇਸਾਂ ਨੂੰ ਸੰਭਾਲਦੇ ਹਨ ਅਤੇ ਸਿਸਟਮ ਨਾਲ ਠੀਕ ਤਰ੍ਹਾਂ ਇੰਟੀਗ੍ਰੇਟ ਹੁੰਦੇ ਹਨ।

### ਯੂਨਿਟ ਟੈਸਟਿੰਗ

#### 1. ਹਰ ਟੂਲ ਨੂੰ ਅਲੱਗ-ਅਲੱਗ ਟੈਸਟ ਕਰੋ

ਹਰ ਟੂਲ ਦੀ ਕਾਰਗੁਜ਼ਾਰੀ ਲਈ ਕੇਂਦਰਿਤ ਟੈਸਟ ਬਣਾਓ:

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

#### 2. ਸਕੀਮਾ ਵੈਧਤਾ ਟੈਸਟਿੰਗ

ਟੈਸਟ ਕਰੋ ਕਿ ਸਕੀਮਾ ਵੈਧ ਹਨ ਅਤੇ ਸੀਮਾਵਾਂ ਨੂੰ ਠੀਕ ਤਰ੍ਹਾਂ ਲਾਗੂ ਕਰਦੇ ਹਨ:

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

ਗਲਤੀ ਹਾਲਤਾਂ ਲਈ ਵਿਸ਼ੇਸ਼ ਟੈਸਟ ਬਣਾਓ:

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

ਉਮੀਦ ਕੀਤੀਆਂ ਸੰਯੋਜਨਾਂ ਵਿੱਚ ਟੂਲਾਂ ਨੂੰ ਇਕੱਠੇ ਕੰਮ ਕਰਦੇ ਹੋਏ ਟੈਸਟ ਕਰੋ:

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

#### 2. MCP ਸਰਵਰ ਟੈਸਟਿੰਗ

ਪੂਰੇ ਟੂਲ ਰਜਿਸਟ੍ਰੇਸ਼ਨ ਅਤੇ ਕਾਰਜਨਵਾਈ ਨਾਲ MCP ਸਰਵਰ ਦੀ ਜਾਂਚ ਕਰੋ:

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

#### 3. ਐਂਡ-ਟੂ-ਐਂਡ ਟੈਸਟਿੰਗ

ਮਾਡਲ ਪ੍ਰਾਂਪਟ ਤੋਂ ਟੂਲ ਕਾਰਜਨਵਾਈ ਤੱਕ ਪੂਰੇ ਵਰਕਫਲੋ ਨੂੰ ਟੈਸਟ ਕਰੋ:

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

ਟੈਸਟ ਕਰੋ ਕਿ ਤੁਹਾਡਾ MCP ਸਰਵਰ ਕਿੰਨੇ ਸਮਕਾਲੀ ਬੇਨਤੀਆਂ ਨੂੰ ਸੰਭਾਲ ਸਕਦਾ ਹੈ:

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

ਸਿਸਟਮ ਨੂੰ ਬਹੁਤ ਜ਼ਿਆਦਾ ਲੋਡ ਹੇਠ ਟੈਸਟ ਕਰੋ:

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

#### 3. ਨਿਰੀਖਣ ਅਤੇ ਪ੍ਰੋਫਾਈਲਿੰਗ

ਲੰਬੇ ਸਮੇਂ ਲਈ ਪ੍ਰਦਰਸ਼ਨ ਵਿਸ਼ਲੇਸ਼ਣ ਲਈ ਨਿਰੀਖਣ ਸੈੱਟ ਕਰੋ:

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

## MCP ਵਰਕਫਲੋ ਡਿਜ਼ਾਈਨ ਪੈਟਰਨ

ਚੰਗੀ ਤਰ੍ਹਾਂ ਡਿਜ਼ਾਈਨ ਕੀਤੇ MCP ਵਰਕਫਲੋ ਕਾਰਗੁਜ਼ਾਰੀ, ਭਰੋਸੇਯੋਗਤਾ ਅਤੇ ਸੰਭਾਲਯੋਗਤਾ ਨੂੰ ਸੁਧਾਰਦੇ ਹਨ। ਇੱਥੇ ਕੁਝ ਮੁੱਖ ਪੈਟਰਨ ਹਨ ਜਿਨ੍ਹਾਂ ਦੀ ਪਾਲਣਾ ਕਰੋ:

### 1. ਟੂਲ ਚੇਨ ਪੈਟਰਨ

ਕਈ ਟੂਲਾਂ ਨੂੰ ਇਸ ਤਰ੍ਹਾਂ ਜੋੜੋ ਕਿ ਹਰ ਟੂਲ ਦਾ ਆਉਟਪੁੱਟ ਅਗਲੇ ਟੂਲ ਦਾ ਇਨਪੁੱਟ ਬਣ ਜਾਵੇ:

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

ਇੱਕ ਕੇਂਦਰੀ ਟੂਲ ਵਰਤੋ ਜੋ ਇਨਪੁੱਟ ਦੇ ਅਧਾਰ 'ਤੇ ਵਿਸ਼ੇਸ਼ ਟੂਲਾਂ ਨੂੰ ਡਿਸਪੈਚ ਕਰਦਾ ਹੈ:

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

### 3. ਪੈਰਲੇਲ ਪ੍ਰੋਸੈਸਿੰਗ ਪੈਟਰਨ

ਕਾਰਗੁਜ਼ਾਰੀ ਲਈ ਕਈ ਟੂਲਾਂ ਨੂੰ ਇਕੱਠੇ ਚਲਾਓ:

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

ਟੂਲ ਫੇਲ੍ਹ ਹੋਣ 'ਤੇ ਨਰਮ ਬੈਕਅੱਪ ਲਾਗੂ ਕਰੋ:

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

### 5. ਵਰਕਫਲੋ ਕੰਪੋਜ਼ੀਸ਼ਨ ਪੈਟਰਨ

ਸਧਾਰਣ ਵਰਕਫਲੋਜ਼ ਨੂੰ ਜੋੜ ਕੇ ਜਟਿਲ ਵਰਕਫਲੋ ਬਣਾਓ:

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

# MCP ਸਰਵਰਾਂ ਦੀ ਟੈਸਟਿੰਗ: ਸਰਵੋਤਮ ਅਭਿਆਸ ਅਤੇ ਮੁੱਖ ਸੁਝਾਅ

## ਝਲਕ

ਟੈਸਟਿੰਗ ਭਰੋਸੇਯੋਗ, ਉੱਚ-ਗੁਣਵੱਤਾ ਵਾਲੇ MCP ਸਰਵਰਾਂ ਦੇ ਵਿਕਾਸ ਦਾ ਇੱਕ ਅਹੰਕਾਰਪੂਰਕ ਪੱਖ ਹੈ। ਇਹ ਗਾਈਡ ਵਿਕਾਸ ਦੇ ਹਰ ਪੜਾਅ ਵਿੱਚ, ਯੂਨਿਟ ਟੈਸਟ ਤੋਂ ਲੈ ਕੇ ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਟੈਸਟ ਅਤੇ ਐਂਡ-ਟੂ-ਐਂਡ ਵੈਰੀਫਿਕੇਸ਼ਨ ਤੱਕ, MCP ਸਰਵਰਾਂ ਦੀ ਟੈਸਟਿੰਗ ਲਈ ਵਿਸਤ੍ਰਿਤ ਸਰਵੋਤਮ ਅਭਿਆਸ ਅਤੇ ਸੁਝਾਅ ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ।

## MCP ਸਰਵਰਾਂ ਲਈ ਟੈਸਟਿੰਗ ਕਿਉਂ ਜ਼ਰੂਰੀ ਹੈ

MCP ਸਰਵਰ AI ਮਾਡਲਾਂ ਅਤੇ ਕਲਾਇੰਟ ਐਪਲੀਕੇਸ਼ਨਾਂ ਵਿਚਕਾਰ ਇੱਕ ਅਹੰਕਾਰਪੂਰਕ ਮਿਡਲਵੇਅਰ ਵਜੋਂ ਕੰਮ ਕਰਦੇ ਹਨ। ਪੂਰੀ ਟੈਸਟਿੰਗ ਇਹ ਯਕੀਨੀ ਬਣਾਉਂਦੀ ਹੈ:

- ਉਤਪਾਦਨ ਵਾਤਾਵਰਣ ਵਿੱਚ ਭਰੋਸੇਯੋਗਤਾ
- ਬੇਨਤੀਆਂ ਅਤੇ ਜਵਾਬਾਂ ਦੀ ਸਹੀ ਸੰਭਾਲ
- MCP ਵਿਸ਼ੇਸ਼ਤਾਵਾਂ ਦੀ ਠੀਕ ਲਾਗੂਆਈ
- ਨਾਕਾਮੀਆਂ ਅਤੇ ਕਿਨਾਰੇ ਦੇ ਕੇਸਾਂ ਦੇ ਖਿਲਾਫ਼ ਲਚਕੀਲਾਪਨ
- ਵੱਖ-ਵੱਖ ਲੋਡ ਹੇਠ ਲਗਾਤਾਰ ਪ੍ਰਦਰਸ਼ਨ

## MCP ਸਰਵਰਾਂ ਲਈ ਯੂਨਿਟ ਟੈਸਟਿੰਗ

### ਯੂਨਿਟ ਟੈਸਟਿੰਗ (ਬੁਨਿਆਦ)

ਯੂਨਿਟ ਟੈਸਟ MCP ਸਰਵਰ ਦੇ ਵਿਅਕਤੀਗਤ ਹਿੱਸਿਆਂ ਨੂੰ ਅਲੱਗ-ਅਲੱਗ ਜਾਂਚਦੇ ਹਨ।

#### ਕੀ ਟੈਸਟ ਕਰਨਾ ਹੈ

1. **ਸਰੋਤ ਹੈਂਡਲਰ**: ਹਰ ਸਰੋਤ ਹੈਂਡਲਰ ਦੀ ਲੋਜਿਕ ਨੂੰ ਅਲੱਗ-ਅਲੱਗ ਟੈਸਟ ਕਰੋ
2. **ਟੂਲ ਲਾਗੂਆਈ**: ਵੱਖ-ਵੱਖ ਇਨਪੁੱਟ ਨਾਲ ਟੂਲ ਦੇ ਵਿਹਾਰ ਦੀ ਜਾਂਚ ਕਰੋ
3. **ਪ੍ਰਾਂਪਟ ਟੈਮਪਲੇਟ**: ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਪ੍ਰਾਂਪਟ ਟੈਮਪਲੇਟ ਸਹੀ ਤਰ੍ਹਾਂ ਰੇਂਡਰ ਹੁੰਦੇ ਹਨ
4. **ਸਕੀਮਾ ਵੈਧਤਾ**: ਪੈਰਾਮੀਟਰ ਵੈਧਤਾ ਲੋਜਿਕ ਦੀ ਜਾਂਚ ਕਰੋ
5. **ਗਲਤੀ ਸੰਭਾਲ**: ਗਲਤ ਇਨਪੁੱਟ ਲਈ ਗਲਤੀ ਜਵਾਬਾਂ ਦੀ ਜਾਂਚ ਕਰੋ

#### ਯੂਨਿਟ ਟੈਸਟਿੰਗ ਲਈ ਸਰਵੋਤਮ ਅਭਿਆਸ

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

ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਟੈਸਟ MCP ਸਰਵਰ ਦੇ ਹਿੱਸਿਆਂ ਵਿਚਕਾਰ ਇੰਟਰੈਕਸ਼ਨ ਦੀ ਜਾਂਚ ਕਰਦੇ ਹਨ।

#### ਕੀ ਟੈਸਟ ਕਰਨਾ ਹੈ

1. **ਸਰਵਰ ਸ਼ੁਰੂਆਤ**: ਵੱਖ-ਵੱਖ ਸੰਰਚਨਾਵਾਂ ਨਾਲ ਸਰਵਰ ਸ਼ੁਰੂ ਕਰਨ ਦੀ ਜਾਂਚ ਕਰੋ
2. **ਰੂਟ ਰਜਿਸਟ੍ਰੇਸ਼ਨ**: ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਸਾਰੇ ਐਂਡਪੌਇੰਟ ਠੀਕ ਤਰ੍ਹਾਂ ਰਜਿਸਟਰ ਹੋਏ ਹਨ
3. **ਬੇਨਤੀ ਪ੍ਰਕਿਰਿਆ**: ਪੂਰੇ ਬੇਨਤੀ-ਜਵਾਬ ਚੱਕਰ ਦੀ ਜਾਂਚ ਕਰੋ
4. **ਗਲਤੀ ਪ੍ਰਸਾਰਣ**: ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਗਲਤੀਆਂ ਹਿੱਸਿਆਂ ਵਿਚਕਾਰ ਠੀਕ ਤਰ੍ਹਾਂ ਸੰਭਾਲੀਆਂ ਜਾਂਦੀਆਂ ਹਨ
5. **ਪਛਾਣ ਅਤੇ ਅਧਿਕਾਰ**: ਸੁਰੱਖਿਆ ਮਕੈਨਿਜ਼ਮ ਦੀ ਜਾਂਚ ਕਰੋ

#### ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਟੈਸਟਿੰਗ ਲਈ ਸਰਵੋਤਮ ਅਭਿਆਸ

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

### ਐਂਡ-ਟੂ-ਐਂਡ ਟੈਸਟਿੰਗ (ਉੱਚ ਪੱਧਰ)

ਐਂਡ-ਟੂ-ਐਂਡ ਟੈਸਟ ਪੂਰੇ ਸਿਸਟਮ ਦੇ ਵਿਹਾਰ ਨੂੰ ਕਲਾਇੰਟ ਤੋਂ ਸਰਵਰ ਤੱਕ ਜਾਂਚਦੇ ਹਨ।

#### ਕੀ ਟੈਸਟ ਕਰਨਾ ਹੈ

1. **ਕਲਾਇੰਟ-ਸਰਵਰ ਸੰਚਾਰ**: ਪੂਰੇ ਬੇਨਤੀ-ਜਵਾਬ ਚੱਕਰ ਦੀ ਜਾਂਚ ਕਰੋ
2. **ਅਸਲੀ ਕਲਾਇੰਟ SDKs**: ਅਸਲੀ ਕਲਾਇੰਟ ਲਾਗੂਆਈ ਨਾਲ ਟੈਸਟ ਕਰੋ
3. **ਲੋਡ ਹੇਠ ਪ੍ਰਦਰਸ਼ਨ**: ਕਈ ਸਮਕਾਲੀ ਬੇਨਤੀਆਂ ਨਾਲ ਵਿਹਾਰ ਦੀ ਜਾਂਚ ਕਰੋ
4. **ਗਲਤੀ ਪੁਨਰ ਪ੍ਰਾਪਤੀ**: ਨਾਕਾਮੀਆਂ ਤੋਂ ਸਿਸਟਮ ਦੀ ਬਹਾਲੀ ਦੀ ਜਾਂਚ ਕਰੋ
5. **ਲੰਬੇ ਸਮੇਂ ਚੱਲਣ ਵਾਲੀਆਂ ਕਾਰਵਾਈਆਂ**: ਸਟ੍ਰੀਮਿੰਗ ਅਤੇ ਲੰਬੀਆਂ ਕਾਰਵਾਈਆਂ ਦੀ ਸੰਭਾਲ ਦੀ ਜਾਂਚ ਕਰੋ

#### ਐਂਡ-ਟੂ-ਐਂਡ ਟੈਸਟਿੰਗ ਲਈ ਸਰਵੋਤਮ ਅਭਿਆਸ

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

## MCP ਟੈਸਟਿੰਗ ਲਈ ਮੌਕਿੰਗ ਰਣਨੀਤੀਆਂ

ਮੌਕਿੰਗ ਟੈਸਟਿੰਗ ਦੌਰਾਨ ਹਿੱਸਿਆਂ ਨੂੰ ਅਲੱਗ ਕਰਨ ਲਈ ਜ਼ਰੂਰੀ ਹੈ।

### ਮੌਕ ਕਰਨ ਵਾਲੇ ਹਿੱਸੇ

1. **ਬਾਹਰੀ AI ਮਾਡਲ**: ਪੇਸ਼ਗੋਈਯੋਗ ਟੈਸਟਿੰਗ ਲਈ ਮਾਡਲ ਜਵਾਬ ਮੌਕ ਕਰੋ
2. **ਬਾਹਰੀ ਸੇਵਾਵਾਂ**: API ਡਿਪੈਂਡੈਂਸੀਜ਼ (ਡੇਟਾਬੇਸ, ਤੀਜੀ ਪੱਖ ਸੇਵਾਵਾਂ) ਮੌਕ ਕਰੋ
3. **ਪਛਾਣ ਸੇਵਾਵਾਂ**: ਪਛਾਣ ਪ੍ਰਦਾਤਾ ਮੌਕ ਕਰੋ
4. **ਸਰੋਤ ਪ੍ਰਦਾਤਾ**: ਮਹਿੰਗੇ ਸਰੋਤ ਹੈਂਡਲਰ ਮੌਕ ਕਰੋ

### ਉਦਾਹਰਨ: AI ਮਾਡਲ ਜਵਾਬ ਮੌਕ ਕਰਨਾ

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

## ਪ੍ਰਦਰਸ਼ਨ ਟੈਸਟਿੰਗ

ਪ੍ਰਦਰਸ਼ਨ ਟੈਸਟਿੰਗ ਉਤਪਾਦਨ MCP ਸਰਵਰਾਂ ਲਈ
5. ਕੁਝ ਖਾਸ MCP ਵਿਸ਼ਿਆਂ 'ਤੇ ਅਗੇਤਰ ਕੋਰਸ ਕਰਨ ਬਾਰੇ ਸੋਚੋ, ਜਿਵੇਂ ਕਿ ਮਲਟੀ-ਮੋਡਲ ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਜਾਂ ਐਂਟਰਪ੍ਰਾਈਜ਼ ਐਪਲੀਕੇਸ਼ਨ ਇੰਟੀਗ੍ਰੇਸ਼ਨ।  
6. ਆਪਣੇ MCP ਟੂਲਜ਼ ਅਤੇ ਵਰਕਫਲੋਜ਼ ਬਣਾਉਣ ਦਾ ਪ੍ਰਯੋਗ ਕਰੋ, ਜੋ ਤੁਸੀਂ [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) ਰਾਹੀਂ ਸਿੱਖੇ ਸਿਧਾਂਤਾਂ 'ਤੇ ਆਧਾਰਿਤ ਹਨ।  

ਅਗਲਾ: ਬਿਹਤਰ ਅਭਿਆਸ [case studies](../09-CaseStudy/README.md)

**ਅਸਵੀਕਾਰੋਪਣ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਮਰਥਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉਤਪੰਨ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।