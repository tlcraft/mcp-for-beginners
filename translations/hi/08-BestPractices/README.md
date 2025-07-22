<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0728873f4271f8c19105619921e830d9",
  "translation_date": "2025-07-22T09:07:32+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "hi"
}
-->
# MCP विकास के सर्वोत्तम अभ्यास

## परिचय

यह पाठ उत्पादन वातावरण में MCP सर्वर और फीचर्स को विकसित करने, परीक्षण करने और तैनात करने के लिए उन्नत सर्वोत्तम अभ्यासों पर केंद्रित है। जैसे-जैसे MCP इकोसिस्टम जटिल और महत्वपूर्ण होते जाते हैं, स्थापित पैटर्न का पालन करना विश्वसनीयता, रखरखाव और पारस्परिकता सुनिश्चित करता है। यह पाठ वास्तविक दुनिया के MCP कार्यान्वयन से प्राप्त व्यावहारिक ज्ञान को समेकित करता है ताकि आपको मजबूत, कुशल सर्वर बनाने में मार्गदर्शन मिल सके, जिनमें प्रभावी संसाधन, प्रॉम्प्ट और उपकरण हों।

## सीखने के उद्देश्य

इस पाठ के अंत तक, आप सक्षम होंगे:

- MCP सर्वर और फीचर डिज़ाइन में उद्योग के सर्वोत्तम अभ्यास लागू करना
- MCP सर्वरों के लिए व्यापक परीक्षण रणनीतियाँ बनाना
- जटिल MCP अनुप्रयोगों के लिए कुशल, पुन: उपयोग योग्य वर्कफ़्लो पैटर्न डिज़ाइन करना
- MCP सर्वरों में उचित त्रुटि प्रबंधन, लॉगिंग और अवलोकन को लागू करना
- प्रदर्शन, सुरक्षा और रखरखाव के लिए MCP कार्यान्वयन को अनुकूलित करना

## MCP के मूल सिद्धांत

विशिष्ट कार्यान्वयन प्रथाओं में गहराई से जाने से पहले, उन मूल सिद्धांतों को समझना महत्वपूर्ण है जो प्रभावी MCP विकास का मार्गदर्शन करते हैं:

1. **मानकीकृत संचार**: MCP JSON-RPC 2.0 का उपयोग अपनी नींव के रूप में करता है, जो सभी कार्यान्वयनों में अनुरोधों, प्रतिक्रियाओं और त्रुटि प्रबंधन के लिए एक सुसंगत प्रारूप प्रदान करता है।

2. **उपयोगकर्ता-केंद्रित डिज़ाइन**: अपने MCP कार्यान्वयनों में हमेशा उपयोगकर्ता की सहमति, नियंत्रण और पारदर्शिता को प्राथमिकता दें।

3. **सुरक्षा पहले**: प्रमाणीकरण, प्राधिकरण, सत्यापन और दर सीमित करने सहित मजबूत सुरक्षा उपाय लागू करें।

4. **मॉड्यूलर आर्किटेक्चर**: अपने MCP सर्वरों को मॉड्यूलर दृष्टिकोण के साथ डिज़ाइन करें, जहां प्रत्येक उपकरण और संसाधन का एक स्पष्ट, केंद्रित उद्देश्य हो।

5. **स्टेटफुल कनेक्शन**: अधिक सुसंगत और संदर्भ-सचेत इंटरैक्शन के लिए कई अनुरोधों में स्थिति बनाए रखने की MCP की क्षमता का लाभ उठाएं।

## आधिकारिक MCP सर्वोत्तम अभ्यास

निम्नलिखित सर्वोत्तम अभ्यास आधिकारिक मॉडल संदर्भ प्रोटोकॉल दस्तावेज़ीकरण से लिए गए हैं:

### सुरक्षा सर्वोत्तम अभ्यास

1. **उपयोगकर्ता की सहमति और नियंत्रण**: डेटा तक पहुंचने या संचालन करने से पहले हमेशा स्पष्ट उपयोगकर्ता सहमति की आवश्यकता होती है। यह सुनिश्चित करें कि उपयोगकर्ता को साझा किए जा रहे डेटा और अधिकृत कार्यों पर स्पष्ट नियंत्रण हो।

2. **डेटा गोपनीयता**: केवल उपयोगकर्ता की स्पष्ट सहमति से डेटा को उजागर करें और इसे उचित एक्सेस नियंत्रण के साथ सुरक्षित रखें। अनधिकृत डेटा ट्रांसमिशन से बचाव करें।

3. **उपकरण सुरक्षा**: किसी भी उपकरण को सक्रिय करने से पहले स्पष्ट उपयोगकर्ता सहमति की आवश्यकता होती है। यह सुनिश्चित करें कि उपयोगकर्ता प्रत्येक उपकरण की कार्यक्षमता को समझें और मजबूत सुरक्षा सीमाओं को लागू करें।

4. **उपकरण अनुमति नियंत्रण**: यह कॉन्फ़िगर करें कि सत्र के दौरान मॉडल किन उपकरणों का उपयोग कर सकता है, यह सुनिश्चित करते हुए कि केवल स्पष्ट रूप से अधिकृत उपकरण ही सुलभ हों।

5. **प्रमाणीकरण**: API कुंजी, OAuth टोकन या अन्य सुरक्षित प्रमाणीकरण विधियों का उपयोग करके उपकरणों, संसाधनों या संवेदनशील संचालन तक पहुंच प्रदान करने से पहले उचित प्रमाणीकरण की आवश्यकता होती है।

6. **पैरामीटर सत्यापन**: सभी उपकरण सक्रियणों के लिए सत्यापन लागू करें ताकि खराब स्वरूपित या दुर्भावनापूर्ण इनपुट को उपकरण कार्यान्वयन तक पहुंचने से रोका जा सके।

7. **दर सीमित करना**: दुरुपयोग को रोकने और सर्वर संसाधनों के उचित उपयोग को सुनिश्चित करने के लिए दर सीमित करना लागू करें।

### कार्यान्वयन सर्वोत्तम अभ्यास

1. **क्षमता वार्ता**: कनेक्शन सेटअप के दौरान, समर्थित सुविधाओं, प्रोटोकॉल संस्करणों, उपलब्ध उपकरणों और संसाधनों के बारे में जानकारी का आदान-प्रदान करें।

2. **उपकरण डिज़ाइन**: ऐसे केंद्रित उपकरण बनाएं जो एक काम को अच्छी तरह से करें, बजाय इसके कि ऐसे उपकरण बनाएं जो कई चिंताओं को संभालें।

3. **त्रुटि प्रबंधन**: समस्याओं का निदान करने, विफलताओं को सहजता से संभालने और कार्रवाई योग्य प्रतिक्रिया प्रदान करने में मदद के लिए मानकीकृत त्रुटि संदेश और कोड लागू करें।

4. **लॉगिंग**: प्रोटोकॉल इंटरैक्शन का ऑडिटिंग, डिबगिंग और मॉनिटरिंग के लिए संरचित लॉग कॉन्फ़िगर करें।

5. **प्रगति ट्रैकिंग**: लंबे समय तक चलने वाले संचालन के लिए, उत्तरदायी उपयोगकर्ता इंटरफेस को सक्षम करने के लिए प्रगति अपडेट की रिपोर्ट करें।

6. **अनुरोध रद्द करना**: ग्राहकों को उन अनुरोधों को रद्द करने की अनुमति दें जो अब आवश्यक नहीं हैं या बहुत अधिक समय ले रहे हैं।

## अतिरिक्त संदर्भ

MCP सर्वोत्तम अभ्यासों पर सबसे अद्यतन जानकारी के लिए, निम्नलिखित देखें:

- [MCP दस्तावेज़ीकरण](https://modelcontextprotocol.io/)
- [MCP विनिर्देश](https://spec.modelcontextprotocol.io/)
- [GitHub रिपॉजिटरी](https://github.com/modelcontextprotocol)
- [सुरक्षा सर्वोत्तम अभ्यास](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## व्यावहारिक कार्यान्वयन उदाहरण

### उपकरण डिज़ाइन सर्वोत्तम अभ्यास

#### 1. एकल उत्तरदायित्व सिद्धांत

प्रत्येक MCP उपकरण का एक स्पष्ट, केंद्रित उद्देश्य होना चाहिए। ऐसे उपकरण बनाने के बजाय जो कई चिंताओं को संभालने का प्रयास करते हैं, विशिष्ट कार्यों में उत्कृष्टता प्राप्त करने वाले विशेष उपकरण विकसित करें।

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

#### 2. सुसंगत त्रुटि प्रबंधन

जानकारीपूर्ण त्रुटि संदेशों और उपयुक्त पुनर्प्राप्ति तंत्र के साथ मजबूत त्रुटि प्रबंधन लागू करें।

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

हमेशा पैरामीटर को अच्छी तरह से सत्यापित करें ताकि खराब स्वरूपित या दुर्भावनापूर्ण इनपुट को रोका जा सके।

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

## परीक्षण सर्वोत्तम अभ्यास

### 1. MCP उपकरणों का यूनिट परीक्षण

हमेशा अपने उपकरणों का अलगाव में परीक्षण करें, बाहरी निर्भरताओं को मॉक करें:

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

### 2. एकीकरण परीक्षण

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

विलंबता और संसाधन उपयोग को कम करने के लिए उपयुक्त कैशिंग लागू करें:

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

```

...

ExecuteAsync(ToolRequest request)
{
    var query = request.Parameters.GetProperty("query").GetString();
    
    // पैरामीटर के आधार पर कैश कुंजी बनाएं
    var cacheKey = $"data_query_{ComputeHash(query)}";
    
    // पहले कैश से प्राप्त करने का प्रयास करें
    if (_cache.TryGetValue(cacheKey, out var cachedResult))
    {
        return new ToolResponse { Result = cachedResult };
    }
    
    // कैश मिस - वास्तविक क्वेरी करें
    var result = await _database.QueryAsync(query);
    
    // समाप्ति के साथ कैश में संग्रहीत करें
    var cacheOptions = new MemoryCacheEntryOptions()
        .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
        
    _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
    
    return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
}

private string ComputeHash(string input)
{
    // कैश कुंजी के लिए स्थिर हैश उत्पन्न करने का कार्यान्वयन
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
        
        // लंबे समय तक चलने वाले ऑपरेशन के लिए, तुरंत एक प्रोसेसिंग आईडी लौटाएं
        String processId = UUID.randomUUID().toString();
        
        // असिंक्रोनस प्रोसेसिंग शुरू करें
        CompletableFuture.runAsync(() -> {
            try {
                // लंबे समय तक चलने वाला ऑपरेशन करें
                documentService.processDocument(documentId);
                
                // स्थिति अपडेट करें (आमतौर पर डेटाबेस में संग्रहीत की जाती है)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // प्रोसेस आईडी के साथ तुरंत प्रतिक्रिया लौटाएं
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // साथी स्थिति जांच उपकरण
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
            tokens_per_second=5,  # प्रति सेकंड 5 अनुरोध की अनुमति दें
            bucket_size=10        # 10 अनुरोध तक बर्स्ट की अनुमति दें
        )
    
    async def execute_async(self, request):
        # जांचें कि हम आगे बढ़ सकते हैं या इंतजार करना होगा
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # यदि प्रतीक्षा बहुत लंबी है
                raise ToolExecutionException(
                    f"रेट लिमिट पार हो गई है। कृपया {delay:.1f} सेकंड में पुनः प्रयास करें।"
                )
            else:
                # उचित प्रतीक्षा समय के लिए प्रतीक्षा करें
                await asyncio.sleep(delay)
        
        # एक टोकन का उपयोग करें और अनुरोध के साथ आगे बढ़ें
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
            
            # अगला टोकन उपलब्ध होने तक का समय गणना करें
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
    // जांचें कि पैरामीटर मौजूद हैं
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("आवश्यक पैरामीटर गायब है: query");
    }
    
    // सही प्रकार की जांच करें
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("Query पैरामीटर एक स्ट्रिंग होना चाहिए");
    }
    
    var query = queryProp.GetString();
    
    // स्ट्रिंग सामग्री की जांच करें
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("Query पैरामीटर खाली नहीं हो सकता");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("Query पैरामीटर अधिकतम लंबाई 500 वर्णों से अधिक है");
    }
    
    // SQL इंजेक्शन हमलों की जांच करें यदि लागू हो
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("अवैध क्वेरी: संभावित असुरक्षित SQL शामिल है");
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
    
    // जांचें कि उपयोगकर्ता के पास आवश्यक अनुमतियां हैं
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("उपयोगकर्ता के पास दस्तावेज़ों तक पहुंचने की अनुमति नहीं है");
    }
    
    // विशिष्ट संसाधनों के लिए, उस संसाधन तक पहुंच की जांच करें
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("अनुरोधित दस्तावेज़ तक पहुंच अस्वीकृत");
    }
    
    // उपकरण निष्पादन के साथ आगे बढ़ें
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
        # अनुरोध संदर्भ में प्राधिकरण स्तर की जांच करें
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # मूल को संशोधित करने से बचने के लिए एक प्रति बनाएं
        redacted = user_data.copy()
        
        # विशिष्ट संवेदनशील फ़ील्ड को छुपाएं
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # संवेदनशील डेटा को नेस्टेड रूप में छुपाएं
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
    // व्यवस्था करें
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
    
    // कार्य करें
    var response = await tool.ExecuteAsync(request);
    
    // पुष्टि करें
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // व्यवस्था करें
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
    
    // कार्य करें और पुष्टि करें
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
    // उपकरण उदाहरण बनाएं
    SearchTool searchTool = new SearchTool();
    
    // स्कीमा प्राप्त करें
    Object schema = searchTool.getSchema();
    
    // मान्यता के लिए स्कीमा को JSON में बदलें
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // जांचें कि स्कीमा मान्य JSONSchema है
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // मान्य पैरामीटर का परीक्षण करें
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // आवश्यक पैरामीटर गायब होने का परीक्षण करें
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // अवैध पैरामीटर प्रकार का परीक्षण करें
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
    # व्यवस्था करें
    tool = ApiTool(timeout=0.1)  # बहुत छोटा टाइमआउट
    
    # एक अनुरोध को मॉक करें जो टाइमआउट करेगा
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # टाइमआउट से अधिक लंबा
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # कार्य करें और पुष्टि करें
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # अपवाद संदेश की पुष्टि करें
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # व्यवस्था करें
    tool = ApiTool()
    
    # रेट-लिमिटेड प्रतिक्रिया को मॉक करें
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            status=429,
            headers={"Retry-After": "2"},
            body=json.dumps({"error": "रेट लिमिट पार हो गई"})
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # कार्य करें और पुष्टि करें
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # अपवाद में रेट लिमिट जानकारी की पुष्टि करें
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
    // व्यवस्था करें
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // कार्य करें
> ("csvProcessor",
            ("code", _) => "codeProcessor",
            _ => throw new InvalidOperationException("Unsupported content type or operation")
        };
    }
    
    private object GetOptionsForTool(string toolName, string operation)
    {
        return toolName switch
        {
            "textSummarizer" => new { mode = operation },
            "textAnalyzer" => new { analysisType = operation },
            "htmlProcessor" => new { parseMode = operation },
            "markdownProcessor" => new { renderMode = operation },
            "csvProcessor" => new { processMode = operation },
            "codeProcessor" => new { lintMode = operation },
            _ => throw new InvalidOperationException("Unsupported tool")
        };
    }
}
"csvProcessor",
```csharp
("code", _) => "codeAnalyzer",
_ => throw new ToolExecutionException($"कोई टूल उपलब्ध नहीं है {contentType}/{operation}")
};
}

private object GetOptionsForTool(string toolName, string operation)
{
    // प्रत्येक विशेष टूल के लिए उपयुक्त विकल्प लौटाएं
    return toolName switch
    {
        "textSummarizer" => new { length = "medium" },
        "htmlProcessor" => new { cleanUp = true, operation },
        // अन्य टूल्स के लिए विकल्प...
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
        // चरण 1: डेटा सेट मेटाडेटा प्राप्त करें (सिंक्रोनस)
        ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata", 
            Map.of("datasetId", datasetId));
        
        // चरण 2: समानांतर में कई विश्लेषण शुरू करें
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
        
        // सभी समानांतर कार्यों के पूर्ण होने की प्रतीक्षा करें
        CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
            statisticalAnalysis, correlationAnalysis, outlierDetection
        );
        
        allAnalyses.join();  // पूर्ण होने की प्रतीक्षा करें
        
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
            # पहले प्राथमिक टूल का प्रयास करें
            response = await self.client.execute_tool(primary_tool, parameters)
            return {
                "result": response.result,
                "source": "primary",
                "tool": primary_tool
            }
        except ToolExecutionException as e:
            # विफलता को लॉग करें
            logging.warning(f"प्राथमिक टूल '{primary_tool}' विफल: {str(e)}")
            
            # द्वितीयक टूल पर वापस जाएं
            try:
                # हो सकता है कि द्वितीयक टूल के लिए पैरामीटर बदलने की आवश्यकता हो
                fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)
                
                response = await self.client.execute_tool(fallback_tool, fallback_params)
                return {
                    "result": response.result,
                    "source": "fallback",
                    "tool": fallback_tool,
                    "primaryError": str(e)
                }
            except ToolExecutionException as fallback_error:
                # दोनों टूल विफल हो गए
                logging.error(f"प्राथमिक और द्वितीयक दोनों टूल विफल। द्वितीयक त्रुटि: {str(fallback_error)}")
                raise WorkflowExecutionException(
                    f"वर्कफ़्लो विफल: प्राथमिक त्रुटि: {str(e)}; द्वितीयक त्रुटि: {str(fallback_error)}"
                )
    
    def _adapt_parameters(self, params, from_tool, to_tool):
        """विभिन्न टूल्स के बीच पैरामीटर अनुकूलित करें यदि आवश्यक हो"""
        # यह कार्यान्वयन विशिष्ट टूल्स पर निर्भर करेगा
        # इस उदाहरण के लिए, हम केवल मूल पैरामीटर लौटाएंगे
        return params

# उदाहरण उपयोग
async def get_weather(workflow, location):
    return await workflow.execute_with_fallback(
        "premiumWeatherService",  # प्राथमिक (भुगतान) मौसम API
        "basicWeatherService",    # द्वितीयक (मुफ्त) मौसम API
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
            
            // प्रत्येक वर्कफ़्लो का परिणाम सहेजें
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
// C# में कैलकुलेटर टूल के लिए एक उदाहरण यूनिट टेस्ट
[Fact]
public async Task CalculatorTool_Add_ReturnsCorrectSum()
{
    // व्यवस्थित करें
    var calculator = new CalculatorTool();
    var parameters = new Dictionary<string, object>
    {
        ["operation"] = "add",
        ["a"] = 5,
        ["b"] = 7
    };
    
    // कार्य करें
    var response = await calculator.ExecuteAsync(parameters);
    var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());
    
    // पुष्टि करें
    Assert.Equal(12, result.Value);
}
```

```python
# Python में कैलकुलेटर टूल के लिए एक उदाहरण यूनिट टेस्ट
def test_calculator_tool_add():
    # व्यवस्थित करें
    calculator = CalculatorTool()
    parameters = {
        "operation": "add",
        "a": 5,
        "b": 7
    }
    
    # कार्य करें
    response = calculator.execute(parameters)
    result = json.loads(response.content[0].text)
    
    # पुष्टि करें
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
// C# में MCP सर्वर के लिए एक उदाहरण इंटीग्रेशन टेस्ट
[Fact]
public async Task Server_ProcessToolRequest_ReturnsValidResponse()
{
    // व्यवस्थित करें
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
    
    // कार्य करें
    var response = await server.ProcessRequestAsync(request);
    
    // पुष्टि करें
    Assert.NotNull(response);
    Assert.Equal(McpStatusCodes.Success, response.StatusCode);
    // प्रतिक्रिया सामग्री के लिए अतिरिक्त पुष्टि
    
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
// TypeScript में क्लाइंट के साथ एक उदाहरण E2E टेस्ट
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
  
  test('क्लाइंट कैलकुलेटर टूल को कॉल कर सकता है और सही परिणाम प्राप्त कर सकता है', async () => {
    // कार्य करें
    const response = await client.invokeToolAsync('calculator', {
      operation: 'divide',
      a: 20,
      b: 4
    });
    
    // पुष्टि करें
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
// Moq के साथ C# उदाहरण
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
# unittest.mock के साथ Python उदाहरण
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
    # मॉक को कॉन्फ़िगर करें
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
// MCP सर्वर के लिए लोड परीक्षण हेतु k6 स्क्रिप्ट
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
    
    - name: Runtime सेट करें
      uses: actions/setup-dotnet@v1
      with:
        dotnet-version: '8.0.x'
    
    - name: डिपेंडेंसी पुनर्स्थापित करें
      run: dotnet restore
    
    - name: Build
      run: dotnet build --no-restore
    
    - name: यूनिट टेस्ट
      run: dotnet test --no-build --filter Category=Unit
    
    - name: इंटीग्रेशन टेस्ट
      run: dotnet test --no-build --filter Category=Integration
      
    - name: प्रदर्शन परीक्षण
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
    // व्यवस्थित करें
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");
    
    // कार्य करें
    var response = await client.GetAsync("http://localhost:5000/api/resources");
    var content = await response.Content.ReadAsStringAsync();
    var resources = JsonSerializer.Deserialize

## प्रभावी MCP सर्वर परीक्षण के लिए शीर्ष 10 सुझाव

1. **टूल परिभाषाओं का अलग से परीक्षण करें**: टूल लॉजिक से अलग स्कीमा परिभाषाओं को सत्यापित करें  
2. **पैरामीटराइज्ड परीक्षणों का उपयोग करें**: विभिन्न इनपुट्स, विशेष रूप से किनारे के मामलों के साथ टूल का परीक्षण करें  
3. **त्रुटि प्रतिक्रियाओं की जांच करें**: सभी संभावित त्रुटि स्थितियों के लिए उचित त्रुटि हैंडलिंग सत्यापित करें  
4. **प्राधिकरण लॉजिक का परीक्षण करें**: विभिन्न उपयोगकर्ता भूमिकाओं के लिए उचित एक्सेस नियंत्रण सुनिश्चित करें  
5. **परीक्षण कवरेज की निगरानी करें**: महत्वपूर्ण पथ कोड के उच्च कवरेज का लक्ष्य रखें  
6. **स्ट्रीमिंग प्रतिक्रियाओं का परीक्षण करें**: स्ट्रीमिंग सामग्री के उचित हैंडलिंग की पुष्टि करें  
7. **नेटवर्क समस्याओं का अनुकरण करें**: खराब नेटवर्क स्थितियों में व्यवहार का परीक्षण करें  
8. **संसाधन सीमाओं का परीक्षण करें**: कोटा या दर सीमाओं तक पहुंचने पर व्यवहार सत्यापित करें  
9. **पुनरावृत्ति परीक्षण स्वचालित करें**: एक ऐसा सूट बनाएं जो हर कोड परिवर्तन पर चले  
10. **परीक्षण मामलों का दस्तावेजीकरण करें**: परीक्षण परिदृश्यों का स्पष्ट दस्तावेज़ बनाए रखें  

## सामान्य परीक्षण गलतियां

- **सिर्फ "हैप्पी पाथ" परीक्षण पर निर्भरता**: त्रुटि मामलों का गहराई से परीक्षण करना सुनिश्चित करें  
- **प्रदर्शन परीक्षण को नजरअंदाज करना**: उत्पादन को प्रभावित करने से पहले बॉटलनेक्स की पहचान करें  
- **केवल अलगाव में परीक्षण करना**: यूनिट, इंटीग्रेशन और एंड-टू-एंड परीक्षणों को मिलाएं  
- **अधूरी API कवरेज**: सुनिश्चित करें कि सभी एंडपॉइंट्स और फीचर्स का परीक्षण किया गया है  
- **असंगत परीक्षण वातावरण**: कंटेनरों का उपयोग करें ताकि परीक्षण वातावरण सुसंगत रहे  

## निष्कर्ष

एक व्यापक परीक्षण रणनीति विश्वसनीय, उच्च-गुणवत्ता वाले MCP सर्वरों को विकसित करने के लिए आवश्यक है। इस गाइड में उल्लिखित सर्वोत्तम प्रथाओं और सुझावों को लागू करके, आप सुनिश्चित कर सकते हैं कि आपके MCP कार्यान्वयन गुणवत्ता, विश्वसनीयता और प्रदर्शन के उच्चतम मानकों को पूरा करते हैं।  

## मुख्य बातें

1. **टूल डिज़ाइन**: सिंगल रिस्पॉन्सिबिलिटी प्रिंसिपल का पालन करें, डिपेंडेंसी इंजेक्शन का उपयोग करें, और कंपोज़ेबिलिटी के लिए डिज़ाइन करें  
2. **स्कीमा डिज़ाइन**: स्पष्ट, अच्छी तरह से प्रलेखित स्कीमा बनाएं जिनमें उचित सत्यापन बाधाएं हों  
3. **त्रुटि हैंडलिंग**: ग्रेसफुल त्रुटि हैंडलिंग, संरचित त्रुटि प्रतिक्रियाएं, और पुनः प्रयास लॉजिक लागू करें  
4. **प्रदर्शन**: कैशिंग, असिंक्रोनस प्रोसेसिंग, और संसाधन थ्रॉटलिंग का उपयोग करें  
5. **सुरक्षा**: इनपुट सत्यापन, प्राधिकरण जांच, और संवेदनशील डेटा हैंडलिंग को लागू करें  
6. **परीक्षण**: व्यापक यूनिट, इंटीग्रेशन, और एंड-टू-एंड परीक्षण बनाएं  
7. **वर्कफ़्लो पैटर्न**: चेन, डिस्पैचर्स, और पैरेलल प्रोसेसिंग जैसे स्थापित पैटर्न लागू करें  

## अभ्यास

एक दस्तावेज़ प्रसंस्करण प्रणाली के लिए MCP टूल और वर्कफ़्लो डिज़ाइन करें जो:  

1. कई प्रारूपों (PDF, DOCX, TXT) में दस्तावेज़ स्वीकार करता है  
2. दस्तावेज़ों से टेक्स्ट और प्रमुख जानकारी निकालता है  
3. दस्तावेज़ों को प्रकार और सामग्री के अनुसार वर्गीकृत करता है  
4. प्रत्येक दस्तावेज़ का सारांश उत्पन्न करता है  

इस परिदृश्य के लिए टूल स्कीमा, त्रुटि हैंडलिंग, और एक उपयुक्त वर्कफ़्लो पैटर्न लागू करें। विचार करें कि आप इस कार्यान्वयन का परीक्षण कैसे करेंगे।  

## संसाधन

1. नवीनतम विकास पर अपडेट रहने के लिए [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs) में MCP समुदाय से जुड़ें  
2. ओपन-सोर्स [MCP प्रोजेक्ट्स](https://github.com/modelcontextprotocol) में योगदान करें  
3. अपनी संस्था की AI पहलों में MCP सिद्धांतों को लागू करें  
4. अपने उद्योग के लिए विशेष MCP कार्यान्वयन का अन्वेषण करें  
5. विशिष्ट MCP विषयों, जैसे मल्टी-मोडल इंटीग्रेशन या एंटरप्राइज एप्लिकेशन इंटीग्रेशन पर उन्नत पाठ्यक्रम लेने पर विचार करें  
6. [हैंड्स ऑन लैब](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) के माध्यम से सीखे गए सिद्धांतों का उपयोग करके अपने MCP टूल और वर्कफ़्लो बनाने के साथ प्रयोग करें  

अगला: सर्वोत्तम प्रथाओं [केस स्टडी](../09-CaseStudy/README.md)  

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता सुनिश्चित करने का प्रयास करते हैं, कृपया ध्यान दें कि स्वचालित अनुवाद में त्रुटियां या अशुद्धियां हो सकती हैं। मूल भाषा में उपलब्ध मूल दस्तावेज़ को आधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सिफारिश की जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।