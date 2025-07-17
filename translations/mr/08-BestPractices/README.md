<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "80e5c8949af5af0f401fce6f905990aa",
  "translation_date": "2025-07-17T00:19:46+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "mr"
}
-->
# MCP विकासासाठी सर्वोत्तम पद्धती

## आढावा

हा धडा उत्पादन वातावरणात MCP सर्व्हर आणि वैशिष्ट्ये विकसित करणे, चाचणी घेणे आणि तैनात करण्यासाठी प्रगत सर्वोत्तम पद्धतींवर लक्ष केंद्रित करतो. MCP परिसंस्था जसे जास्त गुंतागुंतीच्या आणि महत्त्वाच्या होत आहेत, तशा स्थापित नमुन्यांचे पालन केल्याने विश्वासार्हता, देखभालयोग्यता आणि परस्परसंवाद सुनिश्चित होतो. हा धडा वास्तविक जगातील MCP अंमलबजावणीतून मिळालेल्या व्यावहारिक ज्ञानाचा संकलन करतो, ज्यामुळे तुम्हाला प्रभावी संसाधने, प्रॉम्प्ट्स आणि साधने वापरून मजबूत, कार्यक्षम सर्व्हर तयार करण्यात मार्गदर्शन मिळेल.

## शिकण्याचे उद्दिष्टे

या धड्याच्या शेवटी, तुम्ही सक्षम असाल:
- MCP सर्व्हर आणि वैशिष्ट्यांच्या डिझाइनमध्ये उद्योगातील सर्वोत्तम पद्धती लागू करणे
- MCP सर्व्हर साठी व्यापक चाचणी धोरणे तयार करणे
- गुंतागुंतीच्या MCP अनुप्रयोगांसाठी कार्यक्षम, पुनर्वापरयोग्य वर्कफ्लो नमुने डिझाइन करणे
- MCP सर्व्हरमध्ये योग्य त्रुटी हाताळणी, लॉगिंग आणि निरीक्षण अंमलात आणणे
- कार्यक्षमता, सुरक्षा आणि देखभालयोग्यता यासाठी MCP अंमलबजावणीचे ऑप्टिमायझेशन करणे

## MCP मुख्य तत्त्वे

विशिष्ट अंमलबजावणी पद्धतींमध्ये प्रवेश करण्यापूर्वी, प्रभावी MCP विकासासाठी मार्गदर्शक मुख्य तत्त्वे समजून घेणे महत्त्वाचे आहे:

1. **मानकीकृत संवाद**: MCP JSON-RPC 2.0 वापरते, जे विनंत्या, प्रतिसाद आणि त्रुटी हाताळणीसाठी सर्व अंमलबजावणींमध्ये सुसंगत स्वरूप प्रदान करते.

2. **वापरकर्ता-केंद्रित डिझाइन**: तुमच्या MCP अंमलबजावणींमध्ये नेहमी वापरकर्त्याच्या संमती, नियंत्रण आणि पारदर्शकतेला प्राधान्य द्या.

3. **सुरक्षा प्रथम**: प्रमाणीकरण, अधिकृतता, पडताळणी आणि दर मर्यादिती यांसह मजबूत सुरक्षा उपाय अंमलात आणा.

4. **मॉड्युलर आर्किटेक्चर**: तुमचे MCP सर्व्हर मॉड्युलर दृष्टिकोनाने डिझाइन करा, जिथे प्रत्येक साधन आणि संसाधनाचा स्पष्ट, लक्ष केंद्रित उद्देश असतो.

5. **स्थितीपूर्ण कनेक्शन**: अधिक सुसंगत आणि संदर्भ-जाणणाऱ्या संवादांसाठी अनेक विनंत्यांमध्ये स्थिती राखण्याची MCP क्षमता वापरा.

## अधिकृत MCP सर्वोत्तम पद्धती

खालील सर्वोत्तम पद्धती अधिकृत Model Context Protocol दस्तऐवजांवर आधारित आहेत:

### सुरक्षा सर्वोत्तम पद्धती

1. **वापरकर्ता संमती आणि नियंत्रण**: डेटा प्रवेश करण्यापूर्वी किंवा ऑपरेशन्स करण्यापूर्वी नेहमी स्पष्ट वापरकर्ता संमती आवश्यक आहे. कोणता डेटा शेअर केला जातो आणि कोणती क्रिया अधिकृत आहे यावर स्पष्ट नियंत्रण द्या.

2. **डेटा गोपनीयता**: फक्त स्पष्ट संमतीने वापरकर्ता डेटा उघडा आणि योग्य प्रवेश नियंत्रणांसह त्याचे संरक्षण करा. अनधिकृत डेटा प्रसारणापासून संरक्षण करा.

3. **साधन सुरक्षा**: कोणतेही साधन वापरण्यापूर्वी स्पष्ट वापरकर्ता संमती आवश्यक आहे. वापरकर्त्यांना प्रत्येक साधनाची कार्यक्षमता समजावून द्या आणि मजबूत सुरक्षा मर्यादा लागू करा.

4. **साधन परवानगी नियंत्रण**: सत्रादरम्यान कोणती साधने मॉडेल वापरू शकते हे कॉन्फिगर करा, ज्यामुळे फक्त स्पष्टपणे अधिकृत साधनांनाच प्रवेश मिळतो.

5. **प्रमाणीकरण**: API कीज, OAuth टोकन्स किंवा इतर सुरक्षित प्रमाणीकरण पद्धती वापरून साधने, संसाधने किंवा संवेदनशील ऑपरेशन्ससाठी योग्य प्रमाणीकरण आवश्यक आहे.

6. **पॅरामीटर पडताळणी**: सर्व साधन कॉलसाठी पडताळणी लागू करा जेणेकरून चुकीचा किंवा हानिकारक इनपुट साधन अंमलबजावणीपर्यंत पोहोचू नये.

7. **दर मर्यादिती**: गैरवापर टाळण्यासाठी आणि सर्व्हर संसाधनांचा न्याय्य वापर सुनिश्चित करण्यासाठी दर मर्यादिती लागू करा.

### अंमलबजावणी सर्वोत्तम पद्धती

1. **क्षमता वाटाघाटी**: कनेक्शन सेटअप दरम्यान समर्थित वैशिष्ट्ये, प्रोटोकॉल आवृत्त्या, उपलब्ध साधने आणि संसाधने याबाबत माहिती देवाणघेवाण करा.

2. **साधन डिझाइन**: एकाच कामासाठी लक्ष केंद्रित केलेली साधने तयार करा, बहुतेक समस्या हाताळणाऱ्या मोठ्या साधनांऐवजी.

3. **त्रुटी हाताळणी**: समस्या ओळखण्यासाठी, अपयश सौम्यपणे हाताळण्यासाठी आणि उपयुक्त अभिप्राय देण्यासाठी मानकीकृत त्रुटी संदेश आणि कोड अंमलात आणा.

4. **लॉगिंग**: प्रोटोकॉल संवादांचे ऑडिटिंग, डीबगिंग आणि निरीक्षणासाठी संरचित लॉग कॉन्फिगर करा.

5. **प्रगती ट्रॅकिंग**: दीर्घकालीन ऑपरेशन्ससाठी प्रगती अद्यतने द्या जेणेकरून प्रतिसादक्षम वापरकर्ता इंटरफेस सक्षम होईल.

6. **विनंती रद्द करणे**: क्लायंटना आवश्यक नसलेल्या किंवा खूप वेळ घेणाऱ्या इन-फ्लाइट विनंत्या रद्द करण्याची परवानगी द्या.

## अतिरिक्त संदर्भ

MCP सर्वोत्तम पद्धतींबाबत सर्वात अद्ययावत माहितीकरिता, खालील पहा:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)
- [Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## व्यावहारिक अंमलबजावणी उदाहरणे

### साधन डिझाइन सर्वोत्तम पद्धती

#### 1. एकल जबाबदारी तत्त्व

प्रत्येक MCP साधनाचा स्पष्ट, लक्ष केंद्रित उद्देश असावा. अनेक समस्या हाताळणाऱ्या मोठ्या साधनांऐवजी, विशिष्ट कार्यांमध्ये उत्कृष्ट असलेली विशेष साधने विकसित करा.

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

#### 2. सुसंगत त्रुटी हाताळणी

माहितीपूर्ण त्रुटी संदेशांसह आणि योग्य पुनर्प्राप्ती यंत्रणांसह मजबूत त्रुटी हाताळणी अंमलात आणा.

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

#### 3. पॅरामीटर पडताळणी

चुकीचा किंवा हानिकारक इनपुट टाळण्यासाठी पॅरामीटर्सची नेहमीच सखोल पडताळणी करा.

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

### सुरक्षा अंमलबजावणी उदाहरणे

#### 1. प्रमाणीकरण आणि अधिकृतता

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

#### 2. दर मर्यादिती

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

## चाचणी सर्वोत्तम पद्धती

### 1. युनिट चाचणी MCP साधने

तुमची साधने स्वतंत्रपणे, बाह्य अवलंबनांचे मॉकिंग करून नेहमीच चाचणी करा:

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

### 2. एकत्रीकरण चाचणी

क्लायंट विनंत्यांपासून सर्व्हर प्रतिसादांपर्यंत संपूर्ण प्रवाहाची चाचणी करा:

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

## कार्यक्षमता ऑप्टिमायझेशन

### 1. कॅशिंग धोरणे

विलंब आणि संसाधन वापर कमी करण्यासाठी योग्य कॅशिंग अंमलात आणा:

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

Design tools that can be composed together to create more complex workflows:

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

#### 2. Validation Constraints

Include validation constraints to prevent invalid inputs:

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

#### 3. Consistent Return Structures

Maintain consistency in your response structures to make it easier for models to interpret results:

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

#### 2. Structured Error Responses

Return structured error information when possible:

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

#### 3. Retry Logic

Implement appropriate retry logic for transient failures:

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
        
        // पॅरामीटर्सवर आधारित कॅश की तयार करा
        var cacheKey = $"data_query_{ComputeHash(query)}";
        
        // प्रथम कॅशमधून मिळवण्याचा प्रयत्न करा
        if (_cache.TryGetValue(cacheKey, out var cachedResult))
        {
            return new ToolResponse { Result = cachedResult };
        }
        
        // कॅशमध्ये न सापडल्यास - प्रत्यक्ष क्वेरी करा
        var result = await _database.QueryAsync(query);
        
        // कालबाह्यतेसह कॅशमध्ये साठवा
        var cacheOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
            
        _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
        
        return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
    }
    
    private string ComputeHash(string input)
    {
        // कॅश कीसाठी स्थिर हॅश तयार करण्याची अंमलबजावणी
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
        
        // दीर्घकालीन ऑपरेशन्ससाठी, लगेच प्रक्रिया आयडी परत करा
        String processId = UUID.randomUUID().toString();
        
        // असिंक्रोनस प्रक्रिया सुरू करा
        CompletableFuture.runAsync(() -> {
            try {
                // दीर्घकालीन ऑपरेशन करा
                documentService.processDocument(documentId);
                
                // स्थिती अपडेट करा (सामान्यतः डेटाबेसमध्ये साठवली जाते)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // प्रक्रिया आयडीसह त्वरित प्रतिसाद परत करा
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // सहकारी स्थिती तपासणी साधन
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
            tokens_per_second=5,  # प्रति सेकंद 5 विनंत्या परवानगी
            bucket_size=10        # 10 विनंत्यांपर्यंत अचानक वाढीची परवानगी
        )
    
    async def execute_async(self, request):
        # पुढे जाऊ शकतो का किंवा थांबावे लागेल का ते तपासा
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # जर थांबा खूप जास्त असेल
                raise ToolExecutionException(
                    f"रेट लिमिट ओलांडली आहे. कृपया {delay:.1f} सेकंदांनी पुन्हा प्रयत्न करा."
                )
            else:
                # योग्य विलंबासाठी थांबा
                await asyncio.sleep(delay)
        
        # एक टोकन वापरा आणि विनंतीसह पुढे जा
        self.rate_limiter.consume()
        
        # API कॉल करा
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
            
            # पुढील टोकन उपलब्ध होईपर्यंतचा वेळ मोजा
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # गेलेला वेळ लक्षात घेऊन नवीन टोकन जोडा
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
    // पॅरामीटर्स अस्तित्वात आहेत का ते तपासा
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("आवश्यक पॅरामीटर गहाळ आहे: query");
    }
    
    // योग्य प्रकार आहे का ते तपासा
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("Query पॅरामीटर स्ट्रिंग असणे आवश्यक आहे");
    }
    
    var query = queryProp.GetString();
    
    // स्ट्रिंग सामग्री वैध आहे का ते तपासा
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("Query पॅरामीटर रिकामा असू शकत नाही");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("Query पॅरामीटरची जास्तीत जास्त लांबी 500 अक्षरे आहे");
    }
    
    // SQL इंजेक्शन हल्ल्यांसाठी तपासा, जर लागू असेल तर
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("अवैध क्वेरी: संभाव्य असुरक्षित SQL आहे");
    }
    
    // अंमलबजावणीसह पुढे जा
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // विनंतीमधून वापरकर्ता संदर्भ मिळवा
    UserContext user = request.getContext().getUserContext();
    
    // वापरकर्त्याकडे आवश्यक परवानग्या आहेत का ते तपासा
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("वापरकर्त्याकडे दस्तऐवज पाहण्याची परवानगी नाही");
    }
    
    // विशिष्ट संसाधनांसाठी, त्या संसाधनावर प्रवेश तपासा
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("विनंती केलेल्या दस्तऐवजावर प्रवेश नाकारला");
    }
    
    // साधन अंमलबजावणीसह पुढे जा
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
        
        # वापरकर्त्याचा डेटा मिळवा
        user_data = await self.user_service.get_user_data(user_id)
        
        # संवेदनशील क्षेत्रे फिल्टर करा जोपर्यंत स्पष्टपणे विनंती केली नाही आणि अधिकृत नाही
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # विनंती संदर्भातील अधिकृत स्तर तपासा
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # मूळ डेटा बदलू नये म्हणून कॉपी तयार करा
        redacted = user_data.copy()
        
        # विशिष्ट संवेदनशील क्षेत्रे लपवा
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # अंतर्गत संवेदनशील डेटा लपवा
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
    // तयारी करा
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("Seattle", 3))
        .ReturnsAsync(new WeatherForecast(/* चाचणी डेटा */));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "Seattle", 
            days = 3 
        })
    );
    
    // क्रिया करा
    var response = await tool.ExecuteAsync(request);
    
    // पुष्टी करा
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // तयारी करा
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("InvalidLocation", It.IsAny<int>()))
        .ThrowsAsync(new LocationNotFoundException("स्थान सापडले नाही"));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "InvalidLocation", 
            days = 3 
        })
    );
    
    // क्रिया आणि पुष्टी करा
    var exception = await Assert.ThrowsAsync<ToolExecutionException>(
        () => tool.ExecuteAsync(request)
    );
    
    Assert.Contains("स्थान सापडले नाही", exception.Message);
}
```

#### 2. Schema Validation Testing

Test that schemas are valid and properly enforce constraints:

```java
@Test
public void testSchemaValidation() {
    // साधन उदाहरण तयार करा
    SearchTool searchTool = new SearchTool();
    
    // स्कीमा मिळवा
    Object schema = searchTool.getSchema();
    
    // स्कीमा JSON मध्ये रूपांतरित करा आणि वैधता तपासा
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // स्कीमा वैध JSONSchema आहे का ते तपासा
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // वैध पॅरामीटर्ससाठी चाचणी करा
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // आवश्यक पॅरामीटर गहाळ असल्यास चाचणी करा
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // अवैध पॅरामीटर प्रकारासाठी चाचणी करा
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
    # तयारी करा
    tool = ApiTool(timeout=0.1)  # खूप कमी टाइमआउट
    
    # टाइमआउट होणारी विनंती मॉक करा
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # टाइमआउटपेक्षा जास्त वेळ
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # क्रिया आणि पुष्टी करा
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # अपवाद संदेश तपासा
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # तयारी करा
    tool = ApiTool()
    
    # रेट-लिमिटेड प्रतिसाद मॉक करा
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
        
        # क्रिया आणि पुष्टी करा
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # अपवादात रेट लिमिट माहिती आहे का तपासा
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
    // तयारी करा
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // क्रिया करा
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
        // डिस्कव्हरी एंडपॉइंटची चाचणी करा
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // टूल विनंती तयार करा
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // विनंती पाठवा आणि प्रतिसाद तपासा
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // अवैध टूल विनंती तयार करा
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // "b" हा पॅरामीटर गहाळ आहे
        request.put("parameters", parameters);
        
        // विनंती पाठवा आणि त्रुटी प्रतिसाद तपासा
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
    # तयारी - MCP क्लायंट आणि मॉक मॉडेल सेट करा
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # मॉक मॉडेल प्रतिसाद
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
    
    # मॉक वेदर टूल प्रतिसाद
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
        
        # क्रिया करा
        response = await mcp_client.send_prompt(
            "What's the weather in Seattle?",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # पुष्टी करा
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
    // तयारी
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
    
    // पुष्टी करा
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
    
    // स्ट्रेस टेस्टसाठी JMeter सेट करा
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // JMeter टेस्ट प्लॅन कॉन्फिगर करा
    HashTree testPlanTree = new HashTree();
    
    // टेस्ट प्लॅन, थ्रेड ग्रुप, सॅम्पलर्स इत्यादी तयार करा
    TestPlan testPlan = new TestPlan("MCP Server Stress Test");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // टूल एक्सिक्युशनसाठी HTTP सॅम्पलर जोडा
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // लिसनर्स जोडा
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // टेस्ट चालवा
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // निकालांची पडताळणी करा
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // सरासरी प्रतिसाद वेळ < 200ms
    assertTrue(summaryReport.getPercentile(90.0) < 500); // 90वा टक्केवारी < 500ms
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# MCP सर्वरसाठी मॉनिटरिंग कॉन्फिगर करा
def configure_monitoring(server):
    # Prometheus मेट्रिक्स सेट करा
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "एकूण MCP विनंत्या"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "विनंतीचा कालावधी सेकंदांत",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "टूल एक्सिक्युशन्सची संख्या",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "टूल एक्सिक्युशनचा कालावधी सेकंदांत",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "टूल एक्सिक्युशन त्रुटी",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # टाइमिंग आणि मेट्रिक्स रेकॉर्ड करण्यासाठी मिडलवेअर जोडा
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # मेट्रिक्स एंडपॉइंट उघडा
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
# Python Chain of Tools अंमलबजावणी
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # अनुक्रमे चालवायची टूल्सची यादी
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # प्रत्येक टूल चालवा, मागील निकाल पुढील इनपुट म्हणून वापरा
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # निकाल साठवा आणि पुढील टूलसाठी इनपुट म्हणून वापरा
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# उदाहरण वापर
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
    public string Description => "विविध प्रकारच्या सामग्रीची प्रक्रिया करतो";
    
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
        
        // कोणता विशेष टूल वापरायचा ते ठरवा
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // विशेष टूलकडे पुढे पाठवा
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
महत्त्वाचे नियम:
1. भाषांतराच्या भोवती '''markdown किंवा इतर कोणतेही टॅग लावू नका
2. भाषांतर खूप शब्दशः वाटू नये याची काळजी घ्या
3. टिप्पण्या देखील भाषांतरित करा
4. हा फाइल Markdown स्वरूपात आहे - XML किंवा HTML म्हणून वागवू नका
5. खालील गोष्टी भाषांतर करू नका:
   - [!NOTE], [!WARNING], [!TIP], [!IMPORTANT], [!CAUTION]
   - व्हेरिएबल नावे, फंक्शन नावे, क्लास नावे
   - @@INLINE_CODE_x@@ किंवा @@CODE_BLOCK_x@@ सारखे प्लेसहोल्डर्स
   - URL किंवा पथ
6. मूळ Markdown फॉरमॅटिंग जसे आहे तसे ठेवा
7. फक्त भाषांतरित मजकूर परत करा, कोणतेही अतिरिक्त टॅग किंवा मार्कअप न वापरता

> "csvProcessor",
("code", _) => "codeAnalyzer",
_ => throw new ToolExecutionException($"No tool available for {contentType}/{operation}")
};
}

private object GetOptionsForTool(string toolName, string operation)
{
// प्रत्येक विशेष टूलसाठी योग्य पर्याय परत करा
return toolName switch
{
"textSummarizer" => new { length = "medium" },
"htmlProcessor" => new { cleanUp = true, operation },
// इतर टूलसाठी पर्याय...
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
// टप्पा 1: डेटासेट मेटाडेटा मिळवा (सिंक्रोनस)
ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata",
Map.of("datasetId", datasetId));

// टप्पा 2: अनेक विश्लेषणे समांतरपणे सुरू करा
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

// सर्व समांतर कार्य पूर्ण होईपर्यंत थांबा
CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
statisticalAnalysis, correlationAnalysis, outlierDetection
);

allAnalyses.join();  // पूर्ण होईपर्यंत थांबा

// टप्पा 3: निकाल एकत्र करा
Map<String, Object> combinedResults = new HashMap<>();
combinedResults.put("metadata", metadataResponse.getResult());
combinedResults.put("statistics", statisticalAnalysis.join().getResult());
combinedResults.put("correlations", correlationAnalysis.join().getResult());
combinedResults.put("outliers", outlierDetection.join().getResult());

// टप्पा 4: सारांश अहवाल तयार करा
ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator",
Map.of("analysisResults", combinedResults));

// पूर्ण वर्कफ्लो निकाल परत करा
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
# प्रथम प्राथमिक टूल वापरून पहा
response = await self.client.execute_tool(primary_tool, parameters)
return {
"result": response.result,
"source": "primary",
"tool": primary_tool
}
except ToolExecutionException as e:
# अयशस्वीतेची नोंद करा
logging.warning(f"Primary tool '{primary_tool}' failed: {str(e)}")

# दुय्यम टूलकडे वळा
try:
# कदाचित fallback टूलसाठी parameters रूपांतरित करावे लागतील
fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)

response = await self.client.execute_tool(fallback_tool, fallback_params)
return {
"result": response.result,
"source": "fallback",
"tool": fallback_tool,
"primaryError": str(e)
}
except ToolExecutionException as fallback_error:
# दोन्ही टूल अयशस्वी
logging.error(f"Both primary and fallback tools failed. Fallback error: {str(fallback_error)}")
raise WorkflowExecutionException(
f"Workflow failed: primary error: {str(e)}; fallback error: {str(fallback_error)}"
)

def _adapt_parameters(self, params, from_tool, to_tool):
"""वेगवेगळ्या टूल्ससाठी parameters अनुकूल करा"""
# ही अंमलबजावणी विशिष्ट टूल्सवर अवलंबून असेल
# या उदाहरणात, मूळ parameters परत करतो
return params

# उदाहरण वापर
async def get_weather(workflow, location):
return await workflow.execute_with_fallback(
"premiumWeatherService",  # प्राथमिक (पेड) हवामान API
"basicWeatherService",    # दुय्यम (मुफ्त) हवामान API
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

// प्रत्येक वर्कफ्लोचा निकाल साठवा
results[workflow.Name] = workflowResult;

// पुढील वर्कफ्लोसाठी context अपडेट करा
context = context.WithResult(workflow.Name, workflowResult);
}

return new WorkflowResult(results);
}

public string Name => "CompositeWorkflow";
public string Description => "एकाच वेळी अनेक वर्कफ्लो चालवते";
}

// उदाहरण वापर
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
// C# मध्ये कॅल्क्युलेटर टूलसाठी युनिट टेस्टचे उदाहरण
[Fact]
public async Task CalculatorTool_Add_ReturnsCorrectSum()
{
// तयारी
var calculator = new CalculatorTool();
var parameters = new Dictionary<string, object>
{
["operation"] = "add",
["a"] = 5,
["b"] = 7
};

// क्रिया
var response = await calculator.ExecuteAsync(parameters);
var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());

// पडताळणी
Assert.Equal(12, result.Value);
}
```

```python
# Python मध्ये कॅल्क्युलेटर टूलसाठी युनिट टेस्टचे उदाहरण
def test_calculator_tool_add():
# तयारी
calculator = CalculatorTool()
parameters = {
"operation": "add",
"a": 5,
"b": 7
}

# क्रिया
response = calculator.execute(parameters)
result = json.loads(response.content[0].text)

# पडताळणी
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
// C# मध्ये MCP सर्व्हरसाठी इंटिग्रेशन टेस्टचे उदाहरण
[Fact]
public async Task Server_ProcessToolRequest_ReturnsValidResponse()
{
// तयारी
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

// क्रिया
var response = await server.ProcessRequestAsync(request);

// पडताळणी
Assert.NotNull(response);
Assert.Equal(McpStatusCodes.Success, response.StatusCode);
// प्रतिसादाच्या सामग्रीसाठी अतिरिक्त पडताळण्या

// साफसफाई
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
// TypeScript मध्ये क्लायंटसह E2E टेस्टचे उदाहरण
describe('MCP Server E2E Tests', () => {
let client: McpClient;

beforeAll(async () => {
// टेस्ट वातावरणात सर्व्हर सुरू करा
await startTestServer();
client = new McpClient('http://localhost:5000');
});

afterAll(async () => {
await stopTestServer();
});

test('Client can invoke calculator tool and get correct result', async () => {
// क्रिया
const response = await client.invokeToolAsync('calculator', {
operation: 'divide',
a: 20,
b: 4
});

// पडताळणी
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
// C# मध्ये Moq सह उदाहरण
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
# Python मध्ये unittest.mock सह उदाहरण
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
# मॉक कॉन्फिगर करा
mock_model.return_value.generate_response.return_value = {
"text": "Mocked model response",
"finish_reason": "completed"
}

# टेस्टमध्ये मॉक वापरा
server = McpServer(model_client=mock_model)
# टेस्ट सुरू ठेवा
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
// MCP सर्व्हरसाठी लोड टेस्टिंगसाठी k6 स्क्रिप्ट
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
vus: 10,  // 10 आभासी वापरकर्ते
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
// तयारी
var client = new HttpClient();
client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");

// क्रिया
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
    // अतिरिक्त स्कीमा पडताळणी
});
}

## प्रभावी MCP सर्व्हर चाचणीसाठी टॉप 10 टिप्स

1. **टूल डिफिनिशन्स स्वतंत्रपणे तपासा**: टूल लॉजिकपासून स्कीमा डिफिनिशन्स स्वतंत्रपणे पडताळा
2. **पॅरामीटराइज्ड चाचण्या वापरा**: विविध इनपुटसह, विशेषतः एज केससह टूल्सची चाचणी करा
3. **त्रुटी प्रतिसाद तपासा**: सर्व संभाव्य त्रुटी परिस्थितींसाठी योग्य त्रुटी हाताळणी पडताळा
4. **प्राधिकरण लॉजिक तपासा**: वेगवेगळ्या वापरकर्ता भूमिकांसाठी योग्य प्रवेश नियंत्रण सुनिश्चित करा
5. **चाचणी कव्हरेजवर लक्ष ठेवा**: महत्त्वाच्या कोड मार्गाचा उच्च कव्हरेज साध्य करा
6. **स्ट्रीमिंग प्रतिसादांची चाचणी करा**: स्ट्रीमिंग सामग्रीची योग्य हाताळणी पडताळा
7. **नेटवर्क समस्या अनुकरण करा**: खराब नेटवर्क परिस्थितीत वर्तन तपासा
8. **संसाधन मर्यादा तपासा**: कोटा किंवा दर मर्यादा गाठल्यावर वर्तन पडताळा
9. **रिग्रेशन चाचण्या स्वयंचलित करा**: प्रत्येक कोड बदलावर चालणारी चाचणी संच तयार करा
10. **चाचणी प्रकरणे दस्तऐवजीकरण करा**: चाचणी परिस्थितींचे स्पष्ट दस्तऐवजीकरण ठेवा

## सामान्य चाचणीतील चुका

- **फक्त यशस्वी मार्गावर अवलंबून राहणे**: त्रुटी प्रकरणांची सखोल चाचणी करा
- **कार्यक्षमता चाचणी दुर्लक्षित करणे**: उत्पादनावर परिणाम होण्यापूर्वी अडथळे ओळखा
- **फक्त स्वतंत्रपणे चाचणी करणे**: युनिट, इंटिग्रेशन आणि E2E चाचण्या एकत्र करा
- **अपूर्ण API कव्हरेज**: सर्व एंडपॉइंट्स आणि वैशिष्ट्यांची चाचणी सुनिश्चित करा
- **असुसंगत चाचणी वातावरणे**: सुसंगत चाचणी वातावरणासाठी कंटेनर वापरा

## निष्कर्ष

विश्वसनीय, उच्च-गुणवत्तेचे MCP सर्व्हर विकसित करण्यासाठी व्यापक चाचणी धोरण आवश्यक आहे. या मार्गदर्शकातील सर्वोत्तम पद्धती आणि टिप्स अमलात आणून, आपण आपल्या MCP अंमलबजावण्या उच्चतम गुणवत्ता, विश्वासार्हता आणि कार्यक्षमतेच्या मानकांशी जुळवू शकता.

## मुख्य मुद्दे

1. **टूल डिझाइन**: सिंगल रिस्पॉन्सिबिलिटी प्रिन्सिपलचे पालन करा, डिपेंडन्सी इंजेक्शन वापरा, आणि कंपोजिबिलिटीसाठी डिझाइन करा
2. **स्कीमा डिझाइन**: स्पष्ट, चांगल्या प्रकारे दस्तऐवजीकृत स्कीमा तयार करा ज्यात योग्य पडताळणी बंधने असतील
3. **त्रुटी हाताळणी**: सौम्य त्रुटी हाताळणी, संरचित त्रुटी प्रतिसाद आणि पुनःप्रयत्न लॉजिक अंमलात आणा
4. **कार्यक्षमता**: कॅशिंग, असिंक्रोनस प्रक्रिया आणि संसाधन थ्रॉटलिंग वापरा
5. **सुरक्षा**: सखोल इनपुट पडताळणी, प्राधिकरण तपासणी आणि संवेदनशील डेटा हाताळणी करा
6. **चाचणी**: व्यापक युनिट, इंटिग्रेशन आणि एंड-टू-एंड चाचण्या तयार करा
7. **वर्कफ्लो पॅटर्न्स**: चेन, डिस्पॅचर्स आणि समांतर प्रक्रिया यांसारखे स्थापित पॅटर्न वापरा

## व्यायाम

एक दस्तऐवज प्रक्रिया प्रणालीसाठी MCP टूल आणि वर्कफ्लो डिझाइन करा जे:

1. अनेक स्वरूपांमध्ये (PDF, DOCX, TXT) दस्तऐवज स्वीकारते
2. दस्तऐवजांमधून मजकूर आणि मुख्य माहिती काढते
3. दस्तऐवजांचे प्रकार आणि सामग्रीनुसार वर्गीकरण करते
4. प्रत्येक दस्तऐवजाचा सारांश तयार करते

या परिस्थितीसाठी सर्वोत्तम अनुरूप टूल स्कीमा, त्रुटी हाताळणी आणि वर्कफ्लो पॅटर्न अंमलात आणा. या अंमलबजावणीची चाचणी कशी कराल याचा विचार करा.

## संसाधने

1. नवीनतम विकासांवर अपडेट राहण्यासाठी [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs) मध्ये MCP समुदायात सहभागी व्हा
2. मुक्त स्रोत [MCP प्रोजेक्ट्स](https://github.com/modelcontextprotocol) मध्ये योगदान द्या
3. आपल्या संस्थेच्या AI उपक्रमांमध्ये MCP तत्त्वे लागू करा
4. आपल्या उद्योगासाठी विशेष MCP अंमलबजावण्या शोधा
5. मल्टी-मोडल इंटिग्रेशन किंवा एंटरप्राइझ अ‍ॅप्लिकेशन इंटिग्रेशनसारख्या विशिष्ट MCP विषयांवर प्रगत कोर्सेस घेण्याचा विचार करा
6. [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) मधील तत्त्वे वापरून स्वतःचे MCP टूल्स आणि वर्कफ्लो तयार करण्याचा प्रयोग करा

पुढे: सर्वोत्तम पद्धती [केस स्टडीज](../09-CaseStudy/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेची कमतरता असू शकते. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद करण्याची शिफारस केली जाते. या अनुवादाच्या वापरामुळे उद्भवणाऱ्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागी आम्ही जबाबदार नाही.