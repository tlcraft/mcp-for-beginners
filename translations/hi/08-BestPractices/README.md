<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "80e5c8949af5af0f401fce6f905990aa",
  "translation_date": "2025-07-16T22:45:58+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "hi"
}
-->
# MCP विकास के सर्वोत्तम अभ्यास

## अवलोकन

यह पाठ MCP सर्वर और फीचर्स को उत्पादन वातावरण में विकसित, परीक्षण और तैनात करने के लिए उन्नत सर्वोत्तम प्रथाओं पर केंद्रित है। जैसे-जैसे MCP इकोसिस्टम जटिल और महत्वपूर्ण होते जा रहे हैं, स्थापित पैटर्न का पालन करने से विश्वसनीयता, रखरखाव और इंटरऑपरेबिलिटी सुनिश्चित होती है। यह पाठ वास्तविक दुनिया के MCP कार्यान्वयन से प्राप्त व्यावहारिक ज्ञान को समेकित करता है ताकि आप प्रभावी संसाधनों, प्रॉम्प्ट्स और टूल्स के साथ मजबूत और कुशल सर्वर बना सकें।

## सीखने के उद्देश्य

इस पाठ के अंत तक, आप सक्षम होंगे:
- MCP सर्वर और फीचर डिज़ाइन में उद्योग की सर्वोत्तम प्रथाओं को लागू करना
- MCP सर्वरों के लिए व्यापक परीक्षण रणनीतियाँ बनाना
- जटिल MCP एप्लिकेशन के लिए कुशल, पुन: प्रयोज्य वर्कफ़्लो पैटर्न डिज़ाइन करना
- MCP सर्वरों में उचित त्रुटि हैंडलिंग, लॉगिंग और ऑब्ज़र्वेबिलिटी लागू करना
- प्रदर्शन, सुरक्षा और रखरखाव के लिए MCP कार्यान्वयन का अनुकूलन करना

## MCP के मूल सिद्धांत

विशिष्ट कार्यान्वयन प्रथाओं में जाने से पहले, यह समझना महत्वपूर्ण है कि प्रभावी MCP विकास को कौन से मूल सिद्धांत मार्गदर्शित करते हैं:

1. **मानकीकृत संचार**: MCP JSON-RPC 2.0 का उपयोग करता है, जो सभी कार्यान्वयनों में अनुरोध, प्रतिक्रिया और त्रुटि हैंडलिंग के लिए एक सुसंगत प्रारूप प्रदान करता है।

2. **उपयोगकर्ता-केंद्रित डिज़ाइन**: अपने MCP कार्यान्वयनों में हमेशा उपयोगकर्ता की सहमति, नियंत्रण और पारदर्शिता को प्राथमिकता दें।

3. **सुरक्षा पहले**: प्रमाणीकरण, प्राधिकरण, सत्यापन और दर सीमित करने सहित मजबूत सुरक्षा उपाय लागू करें।

4. **मॉड्यूलर आर्किटेक्चर**: अपने MCP सर्वरों को मॉड्यूलर दृष्टिकोण से डिज़ाइन करें, जहां प्रत्येक टूल और संसाधन का एक स्पष्ट, केंद्रित उद्देश्य हो।

5. **राज्यपूर्ण कनेक्शन**: अधिक सुसंगत और संदर्भ-सचेत इंटरैक्शन के लिए कई अनुरोधों के बीच स्थिति बनाए रखने की MCP क्षमता का लाभ उठाएं।

## आधिकारिक MCP सर्वोत्तम प्रथाएं

निम्नलिखित सर्वोत्तम प्रथाएं आधिकारिक Model Context Protocol दस्तावेज़ से ली गई हैं:

### सुरक्षा सर्वोत्तम प्रथाएं

1. **उपयोगकर्ता की सहमति और नियंत्रण**: डेटा तक पहुँचने या संचालन करने से पहले हमेशा स्पष्ट उपयोगकर्ता सहमति आवश्यक करें। यह स्पष्ट नियंत्रण प्रदान करें कि कौन सा डेटा साझा किया जा रहा है और कौन से क्रियाएं अधिकृत हैं।

2. **डेटा गोपनीयता**: केवल स्पष्ट सहमति के साथ उपयोगकर्ता डेटा को उजागर करें और उचित पहुँच नियंत्रण के साथ उसकी सुरक्षा करें। अनधिकृत डेटा ट्रांसमिशन से बचाव करें।

3. **टूल सुरक्षा**: किसी भी टूल को कॉल करने से पहले स्पष्ट उपयोगकर्ता सहमति आवश्यक करें। सुनिश्चित करें कि उपयोगकर्ता प्रत्येक टूल की कार्यक्षमता को समझें और मजबूत सुरक्षा सीमाएं लागू करें।

4. **टूल अनुमति नियंत्रण**: सत्र के दौरान मॉडल को किन टूल्स का उपयोग करने की अनुमति है, इसे कॉन्फ़िगर करें ताकि केवल स्पष्ट रूप से अधिकृत टूल्स ही सुलभ हों।

5. **प्रमाणीकरण**: टूल्स, संसाधनों या संवेदनशील संचालन तक पहुँच प्रदान करने से पहले उचित प्रमाणीकरण आवश्यक करें, जैसे API कुंजी, OAuth टोकन या अन्य सुरक्षित प्रमाणीकरण विधियाँ।

6. **पैरामीटर सत्यापन**: सभी टूल कॉल के लिए सत्यापन लागू करें ताकि गलत या दुर्भावनापूर्ण इनपुट टूल कार्यान्वयन तक न पहुंचे।

7. **दर सीमित करना**: दुरुपयोग रोकने और सर्वर संसाधनों के उचित उपयोग को सुनिश्चित करने के लिए दर सीमित करना लागू करें।

### कार्यान्वयन सर्वोत्तम प्रथाएं

1. **क्षमता वार्ता**: कनेक्शन सेटअप के दौरान समर्थित फीचर्स, प्रोटोकॉल संस्करण, उपलब्ध टूल्स और संसाधनों के बारे में जानकारी का आदान-प्रदान करें।

2. **टूल डिज़ाइन**: ऐसे केंद्रित टूल बनाएं जो एक काम को अच्छी तरह से करें, बजाय इसके कि वे कई मुद्दों को संभालने वाले बड़े टूल हों।

3. **त्रुटि हैंडलिंग**: मानकीकृत त्रुटि संदेश और कोड लागू करें ताकि समस्याओं का निदान किया जा सके, विफलताओं को सहजता से संभाला जा सके और क्रियाशील प्रतिक्रिया दी जा सके।

4. **लॉगिंग**: प्रोटोकॉल इंटरैक्शन के ऑडिटिंग, डिबगिंग और मॉनिटरिंग के लिए संरचित लॉग कॉन्फ़िगर करें।

5. **प्रगति ट्रैकिंग**: लंबी चलने वाली प्रक्रियाओं के लिए प्रगति अपडेट रिपोर्ट करें ताकि प्रतिक्रियाशील उपयोगकर्ता इंटरफेस सक्षम हो सकें।

6. **अनुरोध रद्द करना**: क्लाइंट्स को उन अनुरोधों को रद्द करने की अनुमति दें जो अब आवश्यक नहीं हैं या बहुत अधिक समय ले रहे हैं।

## अतिरिक्त संदर्भ

MCP सर्वोत्तम प्रथाओं पर सबसे अद्यतित जानकारी के लिए देखें:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)
- [Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## व्यावहारिक कार्यान्वयन उदाहरण

### टूल डिज़ाइन सर्वोत्तम प्रथाएं

#### 1. एकल जिम्मेदारी सिद्धांत

प्रत्येक MCP टूल का एक स्पष्ट, केंद्रित उद्देश्य होना चाहिए। कई मुद्दों को संभालने वाले बड़े टूल बनाने के बजाय, ऐसे विशेषीकृत टूल विकसित करें जो विशिष्ट कार्यों में उत्कृष्ट हों।

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

#### 2. सुसंगत त्रुटि हैंडलिंग

जानकारीपूर्ण त्रुटि संदेशों और उचित पुनर्प्राप्ति तंत्रों के साथ मजबूत त्रुटि हैंडलिंग लागू करें।

```python
# Python example with comprehensive error handling
class DataQueryTool:
    def get_name(self):
        return "dataQuery"
        
    def get_description(self):
        return "Queries data from specified database tables"
    
    async def execute(self, parameters):
        try:
            # Parameter validation
            if "query" not in parameters:
                raise ToolParameterError("Missing required parameter: query")
                
            query = parameters["query"]
            
            # Security validation
            if self._contains_unsafe_sql(query):
                raise ToolSecurityError("Query contains potentially unsafe SQL")
            
            try:
                # Database operation with timeout
                async with timeout(10):  # 10 second timeout
                    result = await self._database.execute_query(query)
                    
                return ToolResponse(
                    content=[TextContent(json.dumps(result))]
                )
            except asyncio.TimeoutError:
                raise ToolExecutionError("Database query timed out after 10 seconds")
            except DatabaseConnectionError as e:
                # Connection errors might be transient
                self._log_error("Database connection error", e)
                raise ToolExecutionError(f"Database connection error: {str(e)}")
            except DatabaseQueryError as e:
                # Query errors are likely client errors
                self._log_error("Database query error", e)
                raise ToolExecutionError(f"Invalid query: {str(e)}")
                
        except ToolError:
            # Let tool-specific errors pass through
            raise
        except Exception as e:
            # Catch-all for unexpected errors
            self._log_error("Unexpected error in DataQueryTool", e)
            raise ToolExecutionError(f"An unexpected error occurred: {str(e)}")
    
    def _contains_unsafe_sql(self, query):
        # Implementation of SQL injection detection
        pass
        
    def _log_error(self, message, error):
        # Implementation of error logging
        pass
```

#### 3. पैरामीटर सत्यापन

गलत या दुर्भावनापूर्ण इनपुट को रोकने के लिए हमेशा पैरामीटर का पूरी तरह से सत्यापन करें।

```javascript
// JavaScript/TypeScript example with detailed parameter validation
class FileOperationTool {
  getName() {
    return "fileOperation";
  }
  
  getDescription() {
    return "Performs file operations like read, write, and delete";
  }
  
  getDefinition() {
    return {
      name: this.getName(),
      description: this.getDescription(),
      parameters: {
        operation: {
          type: "string",
          description: "Operation to perform",
          enum: ["read", "write", "delete"]
        },
        path: {
          type: "string",
          description: "File path (must be within allowed directories)"
        },
        content: {
          type: "string",
          description: "Content to write (only for write operation)",
          optional: true
        }
      },
      required: ["operation", "path"]
    };
  }
  
  async execute(parameters) {
    // 1. Validate parameter presence
    if (!parameters.operation) {
      throw new ToolError("Missing required parameter: operation");
    }
    
    if (!parameters.path) {
      throw new ToolError("Missing required parameter: path");
    }
    
    // 2. Validate parameter types
    if (typeof parameters.operation !== "string") {
      throw new ToolError("Parameter 'operation' must be a string");
    }
    
    if (typeof parameters.path !== "string") {
      throw new ToolError("Parameter 'path' must be a string");
    }
    
    // 3. Validate parameter values
    const validOperations = ["read", "write", "delete"];
    if (!validOperations.includes(parameters.operation)) {
      throw new ToolError(`Invalid operation. Must be one of: ${validOperations.join(", ")}`);
    }
    
    // 4. Validate content presence for write operation
    if (parameters.operation === "write" && !parameters.content) {
      throw new ToolError("Content parameter is required for write operation");
    }
    
    // 5. Path safety validation
    if (!this.isPathWithinAllowedDirectories(parameters.path)) {
      throw new ToolError("Access denied: path is outside of allowed directories");
    }
    
    // Implementation based on validated parameters
    // ...
  }
  
  isPathWithinAllowedDirectories(path) {
    // Implementation of path safety check
    // ...
  }
}
```

### सुरक्षा कार्यान्वयन उदाहरण

#### 1. प्रमाणीकरण और प्राधिकरण

```java
// Java example with authentication and authorization
public class SecureDataAccessTool implements Tool {
    private final AuthenticationService authService;
    private final AuthorizationService authzService;
    private final DataService dataService;
    
    // Dependency injection
    public SecureDataAccessTool(
            AuthenticationService authService,
            AuthorizationService authzService,
            DataService dataService) {
        this.authService = authService;
        this.authzService = authzService;
        this.dataService = dataService;
    }
    
    @Override
    public String getName() {
        return "secureDataAccess";
    }
    
    @Override
    public ToolResponse execute(ToolRequest request) {
        // 1. Extract authentication context
        String authToken = request.getContext().getAuthToken();
        
        // 2. Authenticate user
        UserIdentity user;
        try {
            user = authService.validateToken(authToken);
        } catch (AuthenticationException e) {
            return ToolResponse.error("Authentication failed: " + e.getMessage());
        }
        
        // 3. Check authorization for the specific operation
        String dataId = request.getParameters().get("dataId").getAsString();
        String operation = request.getParameters().get("operation").getAsString();
        
        boolean isAuthorized = authzService.isAuthorized(user, "data:" + dataId, operation);
        if (!isAuthorized) {
            return ToolResponse.error("Access denied: Insufficient permissions for this operation");
        }
        
        // 4. Proceed with authorized operation
        try {
            switch (operation) {
                case "read":
                    Object data = dataService.getData(dataId, user.getId());
                    return ToolResponse.success(data);
                case "update":
                    JsonNode newData = request.getParameters().get("newData");
                    dataService.updateData(dataId, newData, user.getId());
                    return ToolResponse.success("Data updated successfully");
                default:
                    return ToolResponse.error("Unsupported operation: " + operation);
            }
        } catch (Exception e) {
            return ToolResponse.error("Operation failed: " + e.getMessage());
        }
    }
}
```

#### 2. दर सीमित करना

```csharp
// C# rate limiting implementation
public class RateLimitingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IMemoryCache _cache;
    private readonly ILogger<RateLimitingMiddleware> _logger;
    
    // Configuration options
    private readonly int _maxRequestsPerMinute;
    
    public RateLimitingMiddleware(
        RequestDelegate next,
        IMemoryCache cache,
        ILogger<RateLimitingMiddleware> logger,
        IConfiguration config)
    {
        _next = next;
        _cache = cache;
        _logger = logger;
        _maxRequestsPerMinute = config.GetValue<int>("RateLimit:MaxRequestsPerMinute", 60);
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        // 1. Get client identifier (API key or user ID)
        string clientId = GetClientIdentifier(context);
        
        // 2. Get rate limiting key for this minute
        string cacheKey = $"rate_limit:{clientId}:{DateTime.UtcNow:yyyyMMddHHmm}";
        
        // 3. Check current request count
        if (!_cache.TryGetValue(cacheKey, out int requestCount))
        {
            requestCount = 0;
        }
        
        // 4. Enforce rate limit
        if (requestCount >= _maxRequestsPerMinute)
        {
            _logger.LogWarning("Rate limit exceeded for client {ClientId}", clientId);
            
            context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
            context.Response.Headers.Add("Retry-After", "60");
            
            await context.Response.WriteAsJsonAsync(new
            {
                error = "Rate limit exceeded",
                message = "Too many requests. Please try again later.",
                retryAfterSeconds = 60
            });
            
            return;
        }
        
        // 5. Increment request count
        _cache.Set(cacheKey, requestCount + 1, TimeSpan.FromMinutes(2));
        
        // 6. Add rate limit headers
        context.Response.Headers.Add("X-RateLimit-Limit", _maxRequestsPerMinute.ToString());
        context.Response.Headers.Add("X-RateLimit-Remaining", (_maxRequestsPerMinute - requestCount - 1).ToString());
        
        // 7. Continue with the request
        await _next(context);
    }
    
    private string GetClientIdentifier(HttpContext context)
    {
        // Implementation to extract API key or user ID
        // ...
    }
}
```

## परीक्षण सर्वोत्तम प्रथाएं

### 1. MCP टूल्स के लिए यूनिट टेस्टिंग

हमेशा अपने टूल्स को अलग-अलग टेस्ट करें, बाहरी निर्भरताओं को मॉक करते हुए:

```typescript
// TypeScript example of a tool unit test
describe('WeatherForecastTool', () => {
  let tool: WeatherForecastTool;
  let mockWeatherService: jest.Mocked<IWeatherService>;
  
  beforeEach(() => {
    // Create a mock weather service
    mockWeatherService = {
      getForecasts: jest.fn()
    } as any;
    
    // Create the tool with the mock dependency
    tool = new WeatherForecastTool(mockWeatherService);
  });
  
  it('should return weather forecast for a location', async () => {
    // Arrange
    const mockForecast = {
      location: 'Seattle',
      forecasts: [
        { date: '2025-07-16', temperature: 72, conditions: 'Sunny' },
        { date: '2025-07-17', temperature: 68, conditions: 'Partly Cloudy' },
        { date: '2025-07-18', temperature: 65, conditions: 'Rain' }
      ]
    };
    
    mockWeatherService.getForecasts.mockResolvedValue(mockForecast);
    
    // Act
    const response = await tool.execute({
      location: 'Seattle',
      days: 3
    });
    
    // Assert
    expect(mockWeatherService.getForecasts).toHaveBeenCalledWith('Seattle', 3);
    expect(response.content[0].text).toContain('Seattle');
    expect(response.content[0].text).toContain('Sunny');
  });
  
  it('should handle errors from the weather service', async () => {
    // Arrange
    mockWeatherService.getForecasts.mockRejectedValue(new Error('Service unavailable'));
    
    // Act & Assert
    await expect(tool.execute({
      location: 'Seattle',
      days: 3
    })).rejects.toThrow('Weather service error: Service unavailable');
  });
});
```

### 2. इंटीग्रेशन टेस्टिंग

क्लाइंट अनुरोधों से लेकर सर्वर प्रतिक्रियाओं तक पूरे प्रवाह का परीक्षण करें:

```python
# Python integration test example
@pytest.mark.asyncio
async def test_mcp_server_integration():
    # Start a test server
    server = McpServer()
    server.register_tool(WeatherForecastTool(MockWeatherService()))
    await server.start(port=5000)
    
    try:
        # Create a client
        client = McpClient("http://localhost:5000")
        
        # Test tool discovery
        tools = await client.discover_tools()
        assert "weatherForecast" in [t.name for t in tools]
        
        # Test tool execution
        response = await client.execute_tool("weatherForecast", {
            "location": "Seattle",
            "days": 3
        })
        
        # Verify response
        assert response.status_code == 200
        assert "Seattle" in response.content[0].text
        assert len(json.loads(response.content[0].text)["forecasts"]) == 3
        
    finally:
        # Clean up
        await server.stop()
```

## प्रदर्शन अनुकूलन

### 1. कैशिंग रणनीतियाँ

लेटेंसी और संसाधन उपयोग को कम करने के लिए उपयुक्त कैशिंग लागू करें:

```csharp
// C# example with caching
public class CachedWeatherTool : ITool
{
    private readonly IWeatherService _weatherService;
    private readonly IDistributedCache _cache;
    private readonly ILogger<CachedWeatherTool> _logger;
    
    public CachedWeatherTool(
        IWeatherService weatherService,
        IDistributedCache cache,
        ILogger<CachedWeatherTool> logger)
    {
        _weatherService = weatherService;
        _cache = cache;
        _logger = logger;
    }
    
    public string Name => "weatherForecast";
    
    public async Task<ToolResponse> ExecuteAsync(IDictionary<string, object> parameters)
    {
        var location = parameters["location"].ToString();
        var days = Convert.ToInt32(parameters.GetValueOrDefault("days", 3));
        
        // Create cache key
        string cacheKey = $"weather:{location}:{days}";
        
        // Try to get from cache
        string cachedForecast = await _cache.GetStringAsync(cacheKey);
        if (!string.IsNullOrEmpty(cachedForecast))
        {
            _logger.LogInformation("Cache hit for weather forecast: {Location}", location);
            return new ToolResponse
            {
                Content = new List<ContentItem>
                {
                    new TextContent(cachedForecast)
                }
            };
        }
        
        // Cache miss - get from service
        _logger.LogInformation("Cache miss for weather forecast: {Location}", location);
        var forecast = await _weatherService.GetForecastAsync(location, days);
        string forecastJson = JsonSerializer.Serialize(forecast);
        
        // Store in cache (weather forecasts valid for 1 hour)
        await _cache.SetStringAsync(
            cacheKey,
            forecastJson,
            new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1)
            });
        
        return new ToolResponse
        {
            Content = new List<ContentItem>
            {
                new TextContent(forecastJson)
            }
        };
    }
}

#### 2. Dependency Injection and Testability

Design tools to receive their dependencies through constructor injection, making them testable and configurable:

```java
// Java उदाहरण जिसमें डिपेंडेंसी इंजेक्शन है
public class CurrencyConversionTool implements Tool {
    private final ExchangeRateService exchangeService;
    private final CacheService cacheService;
    private final Logger logger;
    
    // कंस्ट्रक्टर के माध्यम से डिपेंडेंसी इंजेक्ट की गईं
    public CurrencyConversionTool(
            ExchangeRateService exchangeService,
            CacheService cacheService,
            Logger logger) {
        this.exchangeService = exchangeService;
        this.cacheService = cacheService;
        this.logger = logger;
    }
    
    // टूल कार्यान्वयन
    // ...
}
```

#### 3. Composable Tools

Design tools that can be composed together to create more complex workflows:

```python
# Python उदाहरण जो संयोज्य टूल्स दिखाता है
class DataFetchTool(Tool):
    def get_name(self):
        return "dataFetch"
    
    # कार्यान्वयन...

class DataAnalysisTool(Tool):
    def get_name(self):
        return "dataAnalysis"
    
    # यह टूल dataFetch टूल के परिणामों का उपयोग कर सकता है
    async def execute_async(self, request):
        # कार्यान्वयन...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # यह टूल dataAnalysis टूल के परिणामों का उपयोग कर सकता है
    async def execute_async(self, request):
        # कार्यान्वयन...
        pass

# ये टूल स्वतंत्र रूप से या वर्कफ़्लो के हिस्से के रूप में उपयोग किए जा सकते हैं
```

### Schema Design Best Practices

The schema is the contract between the model and your tool. Well-designed schemas lead to better tool usability.

#### 1. Clear Parameter Descriptions

Always include descriptive information for each parameter:

```csharp
public object GetSchema()
{
    return new {
        type = "object",
        properties = new {
            query = new { 
                type = "string", 
                description = "सर्च क्वेरी टेक्स्ट। बेहतर परिणामों के लिए सटीक कीवर्ड का उपयोग करें।" 
            },
            filters = new {
                type = "object",
                description = "वैकल्पिक फ़िल्टर जो खोज परिणामों को सीमित करते हैं",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "YYYY-MM-DD:YYYY-MM-DD प्रारूप में तारीख सीमा" 
                    },
                    category = new { 
                        type = "string", 
                        description = "फ़िल्टर करने के लिए श्रेणी का नाम" 
                    }
                }
            },
            limit = new { 
                type = "integer", 
                description = "परिणामों की अधिकतम संख्या (1-50)",
                default = 10
            }
        },
        required = new[] { "query" }
    };
}
```

#### 2. Validation Constraints

Include validation constraints to prevent invalid inputs:

```java
Map<String, Object> getSchema() {
    Map<String, Object> schema = new HashMap<>();
    schema.put("type", "object");
    
    Map<String, Object> properties = new HashMap<>();
    
    // ईमेल प्रॉपर्टी के लिए फॉर्मेट सत्यापन
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "उपयोगकर्ता का ईमेल पता");
    
    // आयु प्रॉपर्टी के लिए संख्यात्मक प्रतिबंध
    Map<String, Object> age = new HashMap<>();
    age.put("type", "integer");
    age.put("minimum", 13);
    age.put("maximum", 120);
    age.put("description", "उपयोगकर्ता की आयु वर्ष में");
    
    // एन्यूमरेटेड प्रॉपर्टी
    Map<String, Object> subscription = new HashMap<>();
    subscription.put("type", "string");
    subscription.put("enum", Arrays.asList("free", "basic", "premium"));
    subscription.put("default", "free");
    subscription.put("description", "सब्सक्रिप्शन स्तर");
    
    properties.put("email", email);
    properties.put("age", age);
    properties.put("subscription", subscription);
    
    schema.put("properties", properties);
    schema.put("required", Arrays.asList("email"));
    
    return schema;
}
```

#### 3. Consistent Return Structures

Maintain consistency in your response structures to make it easier for models to interpret results:

```python
async def execute_async(self, request):
    try:
        # अनुरोध संसाधित करें
        results = await self._search_database(request.parameters["query"])
        
        # हमेशा एक सुसंगत संरचना लौटाएं
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
    """सुनिश्चित करता है कि प्रत्येक आइटम की संरचना सुसंगत हो"""
    return {
        "id": item.id,
        "title": item.title,
        "summary": item.summary[:100] + "..." if len(item.summary) > 100 else item.summary,
        "url": item.url,
        "relevance": item.score
    }
```

### Error Handling

Robust error handling is crucial for MCP tools to maintain reliability.

#### 1. Graceful Error Handling

Handle errors at appropriate levels and provide informative messages:

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
            throw new ToolExecutionException($"फ़ाइल नहीं मिली: {fileId}");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ToolExecutionException("आपके पास इस फ़ाइल तक पहुँचने की अनुमति नहीं है");
        }
        catch (Exception ex) when (ex is IOException || ex is TimeoutException)
        {
            _logger.LogError(ex, "फ़ाइल {FileId} तक पहुँचने में त्रुटि", fileId);
            throw new ToolExecutionException("फ़ाइल तक पहुँचने में त्रुटि: सेवा अस्थायी रूप से अनुपलब्ध है");
        }
    }
    catch (JsonException)
    {
        throw new ToolExecutionException("अमान्य फ़ाइल ID प्रारूप");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "FileAccessTool में अप्रत्याशित त्रुटि");
        throw new ToolExecutionException("एक अप्रत्याशित त्रुटि हुई");
    }
}
```

#### 2. Structured Error Responses

Return structured error information when possible:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    try {
        // कार्यान्वयन
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
        
        // अन्य अपवादों को ToolExecutionException के रूप में पुनः फेंकें
        throw new ToolExecutionException("टूल निष्पादन विफल: " + ex.getMessage(), ex);
    }
}
```

#### 3. Retry Logic

Implement appropriate retry logic for transient failures:

```python
async def execute_async(self, request):
    max_retries = 3
    retry_count = 0
    base_delay = 1  # सेकंड
    
    while retry_count < max_retries:
        try:
            # बाहरी API कॉल करें
            return await self._call_api(request.parameters)
        except TransientError as e:
            retry_count += 1
            if retry_count >= max_retries:
                raise ToolExecutionException(f"{max_retries} प्रयासों के बाद ऑपरेशन विफल: {str(e)}")
                
            # घातीय बैकऑफ
            delay = base_delay * (2 ** (retry_count - 1))
            logging.warning(f"क्षणिक त्रुटि, {delay} सेकंड में पुनः प्रयास: {str(e)}")
            await asyncio.sleep(delay)
        except Exception as e:
            # गैर-क्षणिक त्रुटि, पुनः प्रयास न करें
            raise ToolExecutionException(f"ऑपरेशन विफल: {str(e)}")
```

### Performance Optimization

#### 1. Caching

Implement caching for expensive operations:

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
    
    public async Task

ExecuteAsync(ToolRequest request)
{
    var query = request.Parameters.GetProperty("query").GetString();
    
    // पैरामीटर के आधार पर कैश कुंजी बनाएं
    var cacheKey = $"data_query_{ComputeHash(query)}";
    
    // पहले कैश से प्राप्त करने की कोशिश करें
    if (_cache.TryGetValue(cacheKey, out var cachedResult))
    {
        return new ToolResponse { Result = cachedResult };
    }
    
    // कैश मिस - वास्तविक क्वेरी निष्पादित करें
    var result = await _database.QueryAsync(query);
    
    // समाप्ति के साथ कैश में स्टोर करें
    var cacheOptions = new MemoryCacheEntryOptions()
        .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
        
    _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
    
    return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
}

private string ComputeHash(string input)
{
    // कैश कुंजी के लिए स्थिर हैश जनरेट करने का कार्यान्वयन
}
}
```

#### 2. Asynchronous Processing

Use asynchronous programming patterns for I/O-bound operations:

```java
public class AsyncDocumentProcessingTool implements Tool {
    private final DocumentService documentService;
    private final ExecutorService executorService;
    
    @Override
    public ToolResponse execute(ToolRequest request) {
        String documentId = request.getParameters().get("documentId").asText();
        
        // लंबी चलने वाली प्रक्रियाओं के लिए, तुरंत एक प्रोसेसिंग ID लौटाएं
        String processId = UUID.randomUUID().toString();
        
        // असिंक्रोनस प्रोसेसिंग शुरू करें
        CompletableFuture.runAsync(() -> {
            try {
                // लंबी चलने वाली प्रक्रिया करें
                documentService.processDocument(documentId);
                
                // स्थिति अपडेट करें (आमतौर पर डेटाबेस में स्टोर की जाती है)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // प्रोसेस ID के साथ तुरंत प्रतिक्रिया लौटाएं
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // सहायक स्थिति जांच टूल
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

#### 3. Resource Throttling

Implement resource throttling to prevent overload:

```python
class ThrottledApiTool(Tool):
    def __init__(self):
        self.rate_limiter = TokenBucketRateLimiter(
            tokens_per_second=5,  # प्रति सेकंड 5 अनुरोध की अनुमति
            bucket_size=10        # 10 अनुरोध तक की बर्स्ट की अनुमति
        )
    
    async def execute_async(self, request):
        # जांचें कि हम आगे बढ़ सकते हैं या इंतजार करना होगा
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # अगर इंतजार बहुत लंबा है
                raise ToolExecutionException(
                    f"रेट लिमिट पार हो गई है। कृपया {delay:.1f} सेकंड बाद पुनः प्रयास करें।"
                )
            else:
                # उचित विलंब समय के लिए प्रतीक्षा करें
                await asyncio.sleep(delay)
        
        # एक टोकन खर्च करें और अनुरोध के साथ आगे बढ़ें
        self.rate_limiter.consume()
        
        # API कॉल करें
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
            
            # अगले टोकन के उपलब्ध होने तक का समय गणना करें
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # बीते समय के आधार पर नए टोकन जोड़ें
        new_tokens = elapsed * self.tokens_per_second
        self.tokens = min(self.bucket_size, self.tokens + new_tokens)
        self.last_refill = now
```

### Security Best Practices

#### 1. Input Validation

Always validate input parameters thoroughly:

```csharp
public async Task<ToolResponse> ExecuteAsync(ToolRequest request)
{
    // पैरामीटर मौजूद हैं या नहीं जांचें
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("आवश्यक पैरामीटर गायब है: query");
    }
    
    // सही प्रकार की जांच करें
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("Query पैरामीटर स्ट्रिंग होना चाहिए");
    }
    
    var query = queryProp.GetString();
    
    // स्ट्रिंग सामग्री की जांच करें
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("Query पैरामीटर खाली नहीं हो सकता");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("Query पैरामीटर की अधिकतम लंबाई 500 अक्षर है");
    }
    
    // SQL इंजेक्शन हमलों के लिए जांच करें यदि लागू हो
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("अमान्य क्वेरी: संभावित असुरक्षित SQL शामिल है");
    }
    
    // निष्पादन के साथ आगे बढ़ें
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // अनुरोध से उपयोगकर्ता संदर्भ प्राप्त करें
    UserContext user = request.getContext().getUserContext();
    
    // जांचें कि उपयोगकर्ता के पास आवश्यक अनुमतियाँ हैं या नहीं
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("उपयोगकर्ता के पास दस्तावेज़ एक्सेस करने की अनुमति नहीं है");
    }
    
    // विशिष्ट संसाधनों के लिए, उस संसाधन तक पहुंच जांचें
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("अनुरोधित दस्तावेज़ तक पहुंच अस्वीकृत");
    }
    
    // टूल निष्पादन के साथ आगे बढ़ें
    // ...
}
```

#### 3. Sensitive Data Handling

Handle sensitive data carefully:

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
        
        # उपयोगकर्ता डेटा प्राप्त करें
        user_data = await self.user_service.get_user_data(user_id)
        
        # संवेदनशील फ़ील्ड को फ़िल्टर करें जब तक कि स्पष्ट रूप से अनुरोध न किया गया हो और अधिकृत न हो
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # अनुरोध संदर्भ में प्राधिकरण स्तर जांचें
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # मूल को संशोधित करने से बचने के लिए कॉपी बनाएं
        redacted = user_data.copy()
        
        # विशिष्ट संवेदनशील फ़ील्ड को छुपाएं
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # नेस्टेड संवेदनशील डेटा को छुपाएं
        if "financialInfo" in redacted:
            redacted["financialInfo"] = {"available": True, "accessRestricted": True}
        
        return redacted
```

## Testing Best Practices for MCP Tools

Comprehensive testing ensures that MCP tools function correctly, handle edge cases, and integrate properly with the rest of the system.

### Unit Testing

#### 1. Test Each Tool in Isolation

Create focused tests for each tool's functionality:

```csharp
[Fact]
public async Task WeatherTool_ValidLocation_ReturnsCorrectForecast()
{
    // तैयारी
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("Seattle", 3))
        .ReturnsAsync(new WeatherForecast(/* परीक्षण डेटा */));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "Seattle", 
            days = 3 
        })
    );
    
    // क्रियान्वयन
    var response = await tool.ExecuteAsync(request);
    
    // सत्यापन
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // तैयारी
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("InvalidLocation", It.IsAny<int>()))
        .ThrowsAsync(new LocationNotFoundException("स्थान नहीं मिला"));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "InvalidLocation", 
            days = 3 
        })
    );
    
    // क्रियान्वयन और सत्यापन
    var exception = await Assert.ThrowsAsync<ToolExecutionException>(
        () => tool.ExecuteAsync(request)
    );
    
    Assert.Contains("स्थान नहीं मिला", exception.Message);
}
```

#### 2. Schema Validation Testing

Test that schemas are valid and properly enforce constraints:

```java
@Test
public void testSchemaValidation() {
    // टूल इंस्टेंस बनाएं
    SearchTool searchTool = new SearchTool();
    
    // स्कीमा प्राप्त करें
    Object schema = searchTool.getSchema();
    
    // मान्यता के लिए स्कीमा को JSON में कनवर्ट करें
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // जांचें कि स्कीमा वैध JSONSchema है
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // वैध पैरामीटर का परीक्षण करें
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // आवश्यक पैरामीटर के बिना परीक्षण करें
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // अमान्य पैरामीटर प्रकार का परीक्षण करें
    JsonNode invalidType = objectMapper.createObjectNode()
        .put("query", "test")
        .put("limit", "not-a-number");
        
    ProcessingReport invalidReport = jsonSchema.validate(invalidType);
    assertFalse(invalidReport.isSuccess());
}
```

#### 3. Error Handling Tests

Create specific tests for error conditions:

```python
@pytest.mark.asyncio
async def test_api_tool_handles_timeout():
    # तैयारी
    tool = ApiTool(timeout=0.1)  # बहुत छोटा टाइमआउट
    
    # एक ऐसा अनुरोध मॉक करें जो टाइमआउट हो जाएगा
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # टाइमआउट से लंबा
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # क्रियान्वयन और सत्यापन
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # अपवाद संदेश सत्यापित करें
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # तैयारी
    tool = ApiTool()
    
    # रेट-लिमिटेड प्रतिक्रिया मॉक करें
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
        
        # क्रियान्वयन और सत्यापन
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # सत्यापित करें कि अपवाद में रेट लिमिट जानकारी है
        error_msg = str(exc_info.value).lower()
        assert "rate limit" in error_msg
        assert "try again" in error_msg
```

### Integration Testing

#### 1. Tool Chain Testing

Test tools working together in expected combinations:

```csharp
[Fact]
public async Task DataProcessingWorkflow_CompletesSuccessfully()
{
    // तैयारी
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // क्रियान्वयन
var result = await workflowExecutor.ExecuteWorkflowAsync(new[] {
    new ToolCall("dataFetch", new { source = "sales2023" }),
    new ToolCall("dataAnalysis", ctx =>
        new { 
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

#### 2. MCP Server Testing

Test the MCP server with full tool registration and execution:

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
        // डिस्कवरी एंडपॉइंट का परीक्षण करें
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // टूल अनुरोध बनाएं
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // अनुरोध भेजें और प्रतिक्रिया सत्यापित करें
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // अमान्य टूल अनुरोध बनाएं
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // पैरामीटर "b" गायब है
        request.put("parameters", parameters);
        
        // अनुरोध भेजें और त्रुटि प्रतिक्रिया सत्यापित करें
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isBadRequest())
            .andExpect(jsonPath("$.error").exists());
    }
}
```

#### 3. End-to-End Testing

Test complete workflows from model prompt to tool execution:

```python
@pytest.mark.asyncio
async def test_model_interaction_with_tool():
    # तैयारी - MCP क्लाइंट और मॉक मॉडल सेटअप करें
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # मॉक मॉडल प्रतिक्रियाएं
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
    
    # मॉक वेदर टूल प्रतिक्रिया
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
        
        # क्रिया
        response = await mcp_client.send_prompt(
            "What's the weather in Seattle?",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # सत्यापन
        assert "Seattle" in response.generated_text
        assert "65" in response.generated_text
        assert "Sunny" in response.generated_text
        assert "Rain" in response.generated_text
        assert len(response.tool_calls) == 1
        assert response.tool_calls[0].tool_name == "weatherForecast"
```

### Performance Testing

#### 1. Load Testing

Test how many concurrent requests your MCP server can handle:

```csharp
[Fact]
public async Task McpServer_HandlesHighConcurrency()
{
    // तैयारी
    var server = new McpServer(
        name: "TestServer",
        version: "1.0",
        maxConcurrentRequests: 100
    );
    
    server.RegisterTool(new FastExecutingTool());
    await server.StartAsync();
    
    var client = new McpClient("http://localhost:5000");
    
    // क्रिया
    var tasks = new List<Task<McpResponse>>();
    for (int i = 0; i < 1000; i++)
    {
        tasks.Add(client.ExecuteToolAsync("fastTool", new { iteration = i }));
    }
    
    var results = await Task.WhenAll(tasks);
    
    // सत्यापन
    Assert.Equal(1000, results.Length);
    Assert.All(results, r => Assert.NotNull(r));
}
```

#### 2. Stress Testing

Test the system under extreme load:

```java
@Test
public void testServerUnderStress() {
    int maxUsers = 1000;
    int rampUpTimeSeconds = 60;
    int testDurationSeconds = 300;
    
    // स्ट्रेस टेस्टिंग के लिए JMeter सेटअप करें
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // JMeter टेस्ट प्लान कॉन्फ़िगर करें
    HashTree testPlanTree = new HashTree();
    
    // टेस्ट प्लान, थ्रेड ग्रुप, सैम्पलर आदि बनाएं
    TestPlan testPlan = new TestPlan("MCP Server Stress Test");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // टूल निष्पादन के लिए HTTP सैम्पलर जोड़ें
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // लिस्नर्स जोड़ें
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // टेस्ट चलाएं
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // परिणाम सत्यापित करें
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // औसत प्रतिक्रिया समय < 200ms
    assertTrue(summaryReport.getPercentile(90.0) < 500); // 90वां पर्सेंटाइल < 500ms
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# MCP सर्वर के लिए मॉनिटरिंग कॉन्फ़िगर करें
def configure_monitoring(server):
    # Prometheus मेट्रिक्स सेटअप करें
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "कुल MCP अनुरोध"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "अनुरोध की अवधि सेकंड में",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "टूल निष्पादन की संख्या",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "टूल निष्पादन की अवधि सेकंड में",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "टूल निष्पादन त्रुटियां",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # टाइमिंग और मेट्रिक्स रिकॉर्ड करने के लिए मिडलवेयर जोड़ें
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # मेट्रिक्स एंडपॉइंट एक्सपोज़ करें
    @server.router.get("/metrics")
    async def metrics():
        return generate_latest()
    
    return server
```

## MCP Workflow Design Patterns

Well-designed MCP workflows improve efficiency, reliability, and maintainability. Here are key patterns to follow:

### 1. Chain of Tools Pattern

Connect multiple tools in a sequence where each tool's output becomes the input for the next:

```python
# Python Chain of Tools कार्यान्वयन
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # अनुक्रम में निष्पादित करने के लिए टूल नामों की सूची
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # चेन में प्रत्येक टूल को निष्पादित करें, पिछले परिणाम को पास करते हुए
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # परिणाम संग्रहीत करें और अगले टूल के लिए इनपुट के रूप में उपयोग करें
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# उदाहरण उपयोग
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

### 2. Dispatcher Pattern

Use a central tool that dispatches to specialized tools based on input:

```csharp
public class ContentDispatcherTool : IMcpTool
{
    private readonly IMcpClient _mcpClient;
    
    public ContentDispatcherTool(IMcpClient mcpClient)
    {
        _mcpClient = mcpClient;
    }
    
    public string Name => "contentProcessor";
    public string Description => "विभिन्न प्रकार की सामग्री को प्रोसेस करता है";
    
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
        
        // यह निर्धारित करें कि कौन सा विशेष टूल उपयोग करना है
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // विशेष टूल को फॉरवर्ड करें
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
            ("csv", _) =>
# CSV प्रोसेसर

यह मॉड्यूल CSV फ़ाइलों को पढ़ने और लिखने के लिए उपयोगी फ़ंक्शन प्रदान करता है।

## मुख्य विशेषताएँ

- CSV फ़ाइलों को आसानी से पार्स करें
- डेटा को CSV स्वरूप में निर्यात करें
- कस्टम डिलीमीटर और क्वोटिंग विकल्पों का समर्थन करें

## उपयोग का उदाहरण

```python
from csvProcessor import read_csv, write_csv

# CSV पढ़ना
data = read_csv('data.csv')

# डेटा में कुछ परिवर्तन करें
data.append({'name': 'नया उपयोगकर्ता', 'age': 30})

# CSV में लिखना
write_csv('updated_data.csv', data)
```

## नोट्स

[!NOTE] सुनिश्चित करें कि इनपुट फ़ाइल UTF-8 एन्कोडिंग में हो।

[!WARNING] बहुत बड़ी फ़ाइलों के लिए, मेमोरी उपयोग पर ध्यान दें।

## अक्सर पूछे जाने वाले प्रश्न

### क्या मैं कस्टम डिलीमीटर का उपयोग कर सकता हूँ?

हाँ, `read_csv` और `write_csv` दोनों में `delimiter` पैरामीटर उपलब्ध है।

### क्या यह मॉड्यूल बड़े डेटा सेट के लिए उपयुक्त है?

यह छोटे और मध्यम आकार के डेटा के लिए उपयुक्त है, लेकिन बहुत बड़े डेटा के लिए विशेष टूल्स बेहतर हो सकते हैं।
("code", _) => "codeAnalyzer",
_ => throw new ToolExecutionException($"No tool available for {contentType}/{operation}")
};
}

private object GetOptionsForTool(string toolName, string operation)
{
// प्रत्येक विशेष उपकरण के लिए उपयुक्त विकल्प लौटाएं
return toolName switch
{
    "textSummarizer" => new { length = "medium" },
    "htmlProcessor" => new { cleanUp = true, operation },
    // अन्य उपकरणों के विकल्प...
    _ => new { }
};
}
}
```

### 3. Parallel Processing Pattern

Execute multiple tools simultaneously for efficiency:

```java
public class ParallelDataProcessingWorkflow {
    private final McpClient mcpClient;
    
    public ParallelDataProcessingWorkflow(McpClient mcpClient) {
        this.mcpClient = mcpClient;
    }
    
    public WorkflowResult execute(String datasetId) {
        // चरण 1: डेटासेट मेटाडेटा प्राप्त करें (सिंक्रोनस)
        ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata", 
            Map.of("datasetId", datasetId));
        
        // चरण 2: कई विश्लेषण समानांतर में शुरू करें
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
        
        // सभी समानांतर कार्यों के पूरा होने का इंतजार करें
        CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
            statisticalAnalysis, correlationAnalysis, outlierDetection
        );
        
        allAnalyses.join();  // पूर्णता तक प्रतीक्षा करें
        
        // चरण 3: परिणामों को संयोजित करें
        Map<String, Object> combinedResults = new HashMap<>();
        combinedResults.put("metadata", metadataResponse.getResult());
        combinedResults.put("statistics", statisticalAnalysis.join().getResult());
        combinedResults.put("correlations", correlationAnalysis.join().getResult());
        combinedResults.put("outliers", outlierDetection.join().getResult());
        
        // चरण 4: सारांश रिपोर्ट तैयार करें
        ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator", 
            Map.of("analysisResults", combinedResults));
        
        // पूर्ण वर्कफ़्लो परिणाम लौटाएं
        WorkflowResult result = new WorkflowResult();
        result.setDatasetId(datasetId);
        result.setAnalysisResults(combinedResults);
        result.setSummaryReport(summaryResponse.getResult());
        
        return result;
    }
}
```

### 4. Error Recovery Pattern

Implement graceful fallbacks for tool failures:

```python
class ResilientWorkflow:
    def __init__(self, mcp_client):
        self.client = mcp_client
    
    async def execute_with_fallback(self, primary_tool, fallback_tool, parameters):
        try:
            # पहले प्राथमिक उपकरण आज़माएं
            response = await self.client.execute_tool(primary_tool, parameters)
            return {
                "result": response.result,
                "source": "primary",
                "tool": primary_tool
            }
        except ToolExecutionException as e:
            # विफलता को लॉग करें
            logging.warning(f"Primary tool '{primary_tool}' failed: {str(e)}")
            
            # द्वितीयक उपकरण पर स्विच करें
            try:
                # fallback उपकरण के लिए पैरामीटर बदलने की आवश्यकता हो सकती है
                fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)
                
                response = await self.client.execute_tool(fallback_tool, fallback_params)
                return {
                    "result": response.result,
                    "source": "fallback",
                    "tool": fallback_tool,
                    "primaryError": str(e)
                }
            except ToolExecutionException as fallback_error:
                # दोनों उपकरण विफल हो गए
                logging.error(f"Both primary and fallback tools failed. Fallback error: {str(fallback_error)}")
                raise WorkflowExecutionException(
                    f"Workflow failed: primary error: {str(e)}; fallback error: {str(fallback_error)}"
                )
    
    def _adapt_parameters(self, params, from_tool, to_tool):
        """आवश्यक होने पर विभिन्न उपकरणों के बीच पैरामीटर अनुकूलित करें"""
        # यह कार्यान्वयन विशिष्ट उपकरणों पर निर्भर करेगा
        # इस उदाहरण में, हम मूल पैरामीटर ही लौटाएंगे
        return params

# उदाहरण उपयोग
async def get_weather(workflow, location):
    return await workflow.execute_with_fallback(
        "premiumWeatherService",  # प्राथमिक (पेड) मौसम API
        "basicWeatherService",    # फॉलबैक (मुफ्त) मौसम API
        {"location": location}
    )
```

### 5. Workflow Composition Pattern

Build complex workflows by composing simpler ones:

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
            
            // प्रत्येक वर्कफ़्लो का परिणाम संग्रहित करें
            results[workflow.Name] = workflowResult;
            
            // अगले वर्कफ़्लो के लिए परिणाम के साथ संदर्भ अपडेट करें
            context = context.WithResult(workflow.Name, workflowResult);
        }
        
        return new WorkflowResult(results);
    }
    
    public string Name => "CompositeWorkflow";
    public string Description => "क्रम में कई वर्कफ़्लो निष्पादित करता है";
}

// उदाहरण उपयोग
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

# Testing MCP Servers: Best Practices and Top Tips

## Overview

Testing is a critical aspect of developing reliable, high-quality MCP servers. This guide provides comprehensive best practices and tips for testing your MCP servers throughout the development lifecycle, from unit tests to integration tests and end-to-end validation.

## Why Testing Matters for MCP Servers

MCP servers serve as crucial middleware between AI models and client applications. Thorough testing ensures:

- Reliability in production environments
- Accurate handling of requests and responses
- Proper implementation of MCP specifications
- Resilience against failures and edge cases
- Consistent performance under various loads

## Unit Testing for MCP Servers

### Unit Testing (Foundation)

Unit tests verify individual components of your MCP server in isolation.

#### What to Test

1. **Resource Handlers**: Test each resource handler's logic independently
2. **Tool Implementations**: Verify tool behavior with various inputs
3. **Prompt Templates**: Ensure prompt templates render correctly
4. **Schema Validation**: Test parameter validation logic
5. **Error Handling**: Verify error responses for invalid inputs

#### Best Practices for Unit Testing

```csharp
// C# में कैलकुलेटर टूल के लिए उदाहरण यूनिट टेस्ट
[Fact]
public async Task CalculatorTool_Add_ReturnsCorrectSum()
{
    // तैयारी
    var calculator = new CalculatorTool();
    var parameters = new Dictionary<string, object>
    {
        ["operation"] = "add",
        ["a"] = 5,
        ["b"] = 7
    };
    
    // क्रियान्वयन
    var response = await calculator.ExecuteAsync(parameters);
    var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());
    
    // सत्यापन
    Assert.Equal(12, result.Value);
}
```

```python
# Python में कैलकुलेटर टूल के लिए उदाहरण यूनिट टेस्ट
def test_calculator_tool_add():
    # तैयारी
    calculator = CalculatorTool()
    parameters = {
        "operation": "add",
        "a": 5,
        "b": 7
    }
    
    # क्रियान्वयन
    response = calculator.execute(parameters)
    result = json.loads(response.content[0].text)
    
    # सत्यापन
    assert result["value"] == 12
```

### Integration Testing (Middle Layer)

Integration tests verify interactions between components of your MCP server.

#### What to Test

1. **Server Initialization**: Test server startup with various configurations
2. **Route Registration**: Verify all endpoints are correctly registered
3. **Request Processing**: Test the full request-response cycle
4. **Error Propagation**: Ensure errors are properly handled across components
5. **Authentication & Authorization**: Test security mechanisms

#### Best Practices for Integration Testing

```csharp
// C# में MCP सर्वर के लिए उदाहरण इंटीग्रेशन टेस्ट
[Fact]
public async Task Server_ProcessToolRequest_ReturnsValidResponse()
{
    // तैयारी
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
    
    // क्रियान्वयन
    var response = await server.ProcessRequestAsync(request);
    
    // सत्यापन
    Assert.NotNull(response);
    Assert.Equal(McpStatusCodes.Success, response.StatusCode);
    // प्रतिक्रिया सामग्री के लिए अतिरिक्त सत्यापन
    
    // सफाई
    await server.StopAsync();
}
```

### End-to-End Testing (Top Layer)

End-to-end tests verify the complete system behavior from client to server.

#### What to Test

1. **Client-Server Communication**: Test complete request-response cycles
2. **Real Client SDKs**: Test with actual client implementations
3. **Performance Under Load**: Verify behavior with multiple concurrent requests
4. **Error Recovery**: Test system recovery from failures
5. **Long-Running Operations**: Verify handling of streaming and long operations

#### Best Practices for E2E Testing

```typescript
// TypeScript में क्लाइंट के साथ उदाहरण E2E टेस्ट
describe('MCP Server E2E Tests', () => {
  let client: McpClient;
  
  beforeAll(async () => {
    // परीक्षण वातावरण में सर्वर शुरू करें
    await startTestServer();
    client = new McpClient('http://localhost:5000');
  });
  
  afterAll(async () => {
    await stopTestServer();
  });
  
  test('Client can invoke calculator tool and get correct result', async () => {
    // क्रियान्वयन
    const response = await client.invokeToolAsync('calculator', {
      operation: 'divide',
      a: 20,
      b: 4
    });
    
    // सत्यापन
    expect(response.statusCode).toBe(200);
    expect(response.content[0].text).toContain('5');
  });
});
```

## Mocking Strategies for MCP Testing

Mocking is essential for isolating components during testing.

### Components to Mock

1. **External AI Models**: Mock model responses for predictable testing
2. **External Services**: Mock API dependencies (databases, third-party services)
3. **Authentication Services**: Mock identity providers
4. **Resource Providers**: Mock expensive resource handlers

### Example: Mocking an AI Model Response

```csharp
// C# में Moq के साथ उदाहरण
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
# Python में unittest.mock के साथ उदाहरण
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
    # मॉक कॉन्फ़िगर करें
    mock_model.return_value.generate_response.return_value = {
        "text": "Mocked model response",
        "finish_reason": "completed"
    }
    
    # परीक्षण में मॉक का उपयोग करें
    server = McpServer(model_client=mock_model)
    # परीक्षण जारी रखें
```

## Performance Testing

Performance testing is crucial for production MCP servers.

### What to Measure

1. **Latency**: Response time for requests
2. **Throughput**: Requests handled per second
3. **Resource Utilization**: CPU, memory, network usage
4. **Concurrency Handling**: Behavior under parallel requests
5. **Scaling Characteristics**: Performance as load increases

### Tools for Performance Testing

- **k6**: Open-source load testing tool
- **JMeter**: Comprehensive performance testing
- **Locust**: Python-based load testing
- **Azure Load Testing**: Cloud-based performance testing

### Example: Basic Load Test with k6

```javascript
// MCP सर्वर के लिए लोड टेस्टिंग के लिए k6 स्क्रिप्ट
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  vus: 10,  // 10 वर्चुअल उपयोगकर्ता
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

## Test Automation for MCP Servers

Automating your tests ensures consistent quality and faster feedback loops.

### CI/CD Integration

1. **Run Unit Tests on Pull Requests**: Ensure code changes don't break existing functionality
2. **Integration Tests in Staging**: Run integration tests in pre-production environments
3. **Performance Baselines**: Maintain performance benchmarks to catch regressions
4. **Security Scans**: Automate security testing as part of the pipeline

### Example CI Pipeline (GitHub Actions)

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

## Testing for Compliance with MCP Specification

Verify your server correctly implements the MCP specification.

### Key Compliance Areas

1. **API Endpoints**: Test required endpoints (/resources, /tools, etc.)
2. **Request/Response Format**: Validate schema compliance
3. **Error Codes**: Verify correct status codes for various scenarios
4. **Content Types**: Test handling of different content types
5. **Authentication Flow**: Verify spec-compliant auth mechanisms

### Compliance Test Suite

```csharp
[Fact]
public async Task Server_ResourceEndpoint_ReturnsCorrectSchema()
{
    // तैयारी
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");
    
    // क्रियान्वयन
    var response = await client.GetAsync("http://localhost:5000/api/resources");
    var content = await response.Content.ReadAsStringAsync();
    var resources = JsonSerializer.Deserialize

// Assert  
Assert.Equal(HttpStatusCode.OK, response.StatusCode);  
Assert.NotNull(resources);  
Assert.All(resources.Resources, resource =>  
{  
    Assert.NotNull(resource.Id);  
    Assert.NotNull(resource.Type);  
    // अतिरिक्त स्कीमा सत्यापन  
});  
}  
```  

## प्रभावी MCP सर्वर परीक्षण के लिए शीर्ष 10 सुझाव  

1. **टूल परिभाषाओं का अलग से परीक्षण करें**: टूल लॉजिक से स्वतंत्र रूप से स्कीमा परिभाषाओं को सत्यापित करें  
2. **पैरामीटरयुक्त परीक्षण का उपयोग करें**: विभिन्न इनपुट के साथ टूल्स का परीक्षण करें, जिसमें किनारे के मामले भी शामिल हों  
3. **त्रुटि प्रतिक्रियाओं की जांच करें**: सभी संभावित त्रुटि स्थितियों के लिए उचित त्रुटि हैंडलिंग सुनिश्चित करें  
4. **प्राधिकरण लॉजिक का परीक्षण करें**: विभिन्न उपयोगकर्ता भूमिकाओं के लिए उचित एक्सेस नियंत्रण सुनिश्चित करें  
5. **परीक्षण कवरेज की निगरानी करें**: महत्वपूर्ण पथ कोड के उच्च कवरेज का लक्ष्य रखें  
6. **स्ट्रीमिंग प्रतिक्रियाओं का परीक्षण करें**: स्ट्रीमिंग सामग्री के सही हैंडलिंग को सत्यापित करें  
7. **नेटवर्क समस्याओं का अनुकरण करें**: खराब नेटवर्क स्थितियों में व्यवहार का परीक्षण करें  
8. **संसाधन सीमाओं का परीक्षण करें**: कोटा या दर सीमाओं तक पहुंचने पर व्यवहार की जांच करें  
9. **पुनरावृत्ति परीक्षणों को स्वचालित करें**: हर कोड परिवर्तन पर चलने वाला परीक्षण सूट बनाएं  
10. **परीक्षण मामलों का दस्तावेजीकरण करें**: परीक्षण परिदृश्यों का स्पष्ट दस्तावेज बनाए रखें  

## सामान्य परीक्षण गलतियाँ  

- **सिर्फ सफल मार्ग परीक्षण पर अधिक निर्भरता**: त्रुटि मामलों का भी पूरी तरह परीक्षण करें  
- **प्रदर्शन परीक्षण की अनदेखी**: उत्पादन को प्रभावित करने से पहले बाधाओं की पहचान करें  
- **केवल पृथक परीक्षण करना**: यूनिट, इंटीग्रेशन, और एंड-टू-एंड परीक्षणों को मिलाएं  
- **अपूर्ण API कवरेज**: सुनिश्चित करें कि सभी एंडपॉइंट और फीचर्स का परीक्षण हो  
- **असंगत परीक्षण वातावरण**: सुसंगत परीक्षण वातावरण के लिए कंटेनरों का उपयोग करें  

## निष्कर्ष  

एक व्यापक परीक्षण रणनीति विश्वसनीय, उच्च गुणवत्ता वाले MCP सर्वर विकसित करने के लिए आवश्यक है। इस गाइड में बताए गए सर्वोत्तम अभ्यासों और सुझावों को लागू करके, आप सुनिश्चित कर सकते हैं कि आपकी MCP कार्यान्वयन उच्चतम गुणवत्ता, विश्वसनीयता और प्रदर्शन मानकों को पूरा करें।  

## मुख्य बिंदु  

1. **टूल डिज़ाइन**: सिंगल रिस्पॉन्सिबिलिटी प्रिंसिपल का पालन करें, डिपेंडेंसी इंजेक्शन का उपयोग करें, और संयोज्यता के लिए डिज़ाइन करें  
2. **स्कीमा डिज़ाइन**: स्पष्ट, अच्छी तरह से दस्तावेजीकृत स्कीमा बनाएं जिनमें उचित सत्यापन प्रतिबंध हों  
3. **त्रुटि हैंडलिंग**: सहज त्रुटि प्रबंधन, संरचित त्रुटि प्रतिक्रियाएं, और पुनः प्रयास लॉजिक लागू करें  
4. **प्रदर्शन**: कैशिंग, असिंक्रोनस प्रोसेसिंग, और संसाधन थ्रॉटलिंग का उपयोग करें  
5. **सुरक्षा**: व्यापक इनपुट सत्यापन, प्राधिकरण जांच, और संवेदनशील डेटा हैंडलिंग लागू करें  
6. **परीक्षण**: व्यापक यूनिट, इंटीग्रेशन, और एंड-टू-एंड परीक्षण बनाएं  
7. **वर्कफ़्लो पैटर्न**: चेन, डिस्पैचर, और समानांतर प्रोसेसिंग जैसे स्थापित पैटर्न लागू करें  

## अभ्यास  

एक दस्तावेज़ प्रसंस्करण प्रणाली के लिए MCP टूल और वर्कफ़्लो डिज़ाइन करें जो:  

1. कई प्रारूपों (PDF, DOCX, TXT) में दस्तावेज़ स्वीकार करता है  
2. दस्तावेज़ों से टेक्स्ट और मुख्य जानकारी निकालता है  
3. दस्तावेज़ों को प्रकार और सामग्री के अनुसार वर्गीकृत करता है  
4. प्रत्येक दस्तावेज़ का सारांश उत्पन्न करता है  

इस परिदृश्य के लिए उपयुक्त टूल स्कीमा, त्रुटि हैंडलिंग, और वर्कफ़्लो पैटर्न लागू करें। सोचें कि आप इस कार्यान्वयन का परीक्षण कैसे करेंगे।  

## संसाधन  

1. नवीनतम विकासों से अपडेट रहने के लिए [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs) में MCP समुदाय से जुड़ें  
2. ओपन-सोर्स [MCP प्रोजेक्ट्स](https://github.com/modelcontextprotocol) में योगदान करें  
3. अपनी संस्था की AI पहलों में MCP सिद्धांत लागू करें  
4. अपने उद्योग के लिए विशेष MCP कार्यान्वयन का अन्वेषण करें  
5. मल्टी-मोडल इंटीग्रेशन या एंटरप्राइज एप्लिकेशन इंटीग्रेशन जैसे विशिष्ट MCP विषयों पर उन्नत पाठ्यक्रम लेने पर विचार करें  
6. [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) के माध्यम से सीखे गए सिद्धांतों का उपयोग करके अपने MCP टूल और वर्कफ़्लो बनाने का प्रयोग करें  

अगला: सर्वोत्तम अभ्यास [केस स्टडीज](../09-CaseStudy/README.md)

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में ही अधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।