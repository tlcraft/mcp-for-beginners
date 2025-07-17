<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "80e5c8949af5af0f401fce6f905990aa",
  "translation_date": "2025-07-17T00:32:06+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "ne"
}
-->
# MCP विकासका उत्कृष्ट अभ्यासहरू

## अवलोकन

यो पाठले उत्पादन वातावरणमा MCP सर्भरहरू र सुविधाहरू विकास, परीक्षण, र परिनियोजन गर्ने उन्नत उत्कृष्ट अभ्यासहरूमा केन्द्रित छ। MCP पारिस्थितिकी तन्त्रहरू जटिल र महत्वपूर्ण बन्दै जाँदा, स्थापित ढाँचाहरूको पालना गर्दा विश्वसनीयता, मर्मतसम्भारयोग्यता, र अन्तरक्रियाशीलता सुनिश्चित हुन्छ। यो पाठले वास्तविक विश्वका MCP कार्यान्वयनहरूबाट प्राप्त व्यावहारिक ज्ञानलाई समेटेर तपाईंलाई प्रभावकारी स्रोतहरू, प्रॉम्प्टहरू, र उपकरणहरूसँग बलियो र कुशल सर्भरहरू सिर्जना गर्न मार्गदर्शन गर्दछ।

## सिकाइ उद्देश्यहरू

यस पाठको अन्त्यसम्म, तपाईं सक्षम हुनुहुनेछ:
- MCP सर्भर र सुविधाहरूको डिजाइनमा उद्योगका उत्कृष्ट अभ्यासहरू लागू गर्न
- MCP सर्भरहरूको लागि व्यापक परीक्षण रणनीतिहरू तयार गर्न
- जटिल MCP अनुप्रयोगहरूको लागि प्रभावकारी, पुन: प्रयोगयोग्य कार्यप्रवाह ढाँचाहरू डिजाइन गर्न
- MCP सर्भरहरूमा उचित त्रुटि व्यवस्थापन, लगिङ, र अवलोकन कार्यान्वयन गर्न
- प्रदर्शन, सुरक्षा, र मर्मतसम्भारयोग्यताका लागि MCP कार्यान्वयनहरू अनुकूलन गर्न

## MCP कोर सिद्धान्तहरू

विशिष्ट कार्यान्वयन अभ्यासहरूमा प्रवेश गर्नु अघि, प्रभावकारी MCP विकासलाई मार्गदर्शन गर्ने कोर सिद्धान्तहरू बुझ्नु महत्त्वपूर्ण छ:

1. **मानकीकृत सञ्चार**: MCP ले JSON-RPC 2.0 लाई आधारको रूपमा प्रयोग गर्छ, जसले सबै कार्यान्वयनहरूमा अनुरोध, प्रतिक्रिया, र त्रुटि व्यवस्थापनका लागि एक समान ढाँचा प्रदान गर्छ।

2. **प्रयोगकर्ता-केंद्रित डिजाइन**: सधैं प्रयोगकर्ताको सहमति, नियन्त्रण, र पारदर्शितालाई प्राथमिकता दिनुहोस्।

3. **सुरक्षा पहिलो**: प्रमाणीकरण, प्राधिकरण, प्रमाणीकरण, र दर सीमांकन सहित बलियो सुरक्षा उपायहरू कार्यान्वयन गर्नुहोस्।

4. **मोड्युलर वास्तुकला**: प्रत्येक उपकरण र स्रोतको स्पष्ट, केन्द्रित उद्देश्य हुने गरी MCP सर्भरहरू मोड्युलर तरिकाले डिजाइन गर्नुहोस्।

5. **राज्यपूर्ण जडानहरू**: धेरै अनुरोधहरूमा राज्य कायम राख्ने MCP को क्षमता प्रयोग गरेर थप सुसंगत र सन्दर्भ-चेतन अन्तरक्रियाहरू सक्षम पार्नुहोस्।

## आधिकारिक MCP उत्कृष्ट अभ्यासहरू

तलका उत्कृष्ट अभ्यासहरू आधिकारिक Model Context Protocol कागजातबाट लिइएका हुन्:

### सुरक्षा उत्कृष्ट अभ्यासहरू

1. **प्रयोगकर्ता सहमति र नियन्त्रण**: डाटा पहुँच वा अपरेशनहरू गर्नु अघि सधैं स्पष्ट प्रयोगकर्ता सहमति आवश्यक छ। कुन डाटा साझा गरिन्छ र कुन क्रियाहरू प्राधिकृत छन् भन्ने स्पष्ट नियन्त्रण प्रदान गर्नुहोस्।

2. **डाटा गोपनीयता**: केवल स्पष्ट सहमति प्राप्त डाटालाई मात्र सार्वजनिक गर्नुहोस् र उपयुक्त पहुँच नियन्त्रणहरूसँग सुरक्षित गर्नुहोस्। अनधिकृत डाटा प्रसारणबाट बचाउनुहोस्।

3. **उपकरण सुरक्षा**: कुनै पनि उपकरण प्रयोग गर्नु अघि स्पष्ट प्रयोगकर्ता सहमति आवश्यक छ। प्रयोगकर्ताले प्रत्येक उपकरणको कार्यक्षमता बुझ्नुपर्छ र बलियो सुरक्षा सीमाहरू लागू गर्नुहोस्।

4. **उपकरण अनुमति नियन्त्रण**: सत्रको समयमा कुन उपकरणहरू मोडेलले प्रयोग गर्न सक्छ भनेर कन्फिगर गर्नुहोस्, जसले केवल स्पष्ट रूपमा प्राधिकृत उपकरणहरू पहुँचयोग्य बनाउँछ।

5. **प्रमाणीकरण**: उपकरणहरू, स्रोतहरू, वा संवेदनशील अपरेशनहरूमा पहुँच दिनु अघि API कुञ्जीहरू, OAuth टोकनहरू, वा अन्य सुरक्षित प्रमाणीकरण विधिहरू प्रयोग गरी उचित प्रमाणीकरण आवश्यक छ।

6. **प्यारामिटर प्रमाणीकरण**: सबै उपकरण कलहरूको लागि प्रमाणीकरण लागू गर्नुहोस् ताकि बिग्रिएको वा दुर्भावनापूर्ण इनपुट उपकरण कार्यान्वयनसम्म नपुगोस्।

7. **दर सीमांकन**: दुरुपयोग रोक्न र सर्भर स्रोतहरूको न्यायसंगत प्रयोग सुनिश्चित गर्न दर सीमांकन लागू गर्नुहोस्।

### कार्यान्वयन उत्कृष्ट अभ्यासहरू

1. **क्षमता वार्ता**: जडान सेटअपको क्रममा समर्थित सुविधाहरू, प्रोटोकल संस्करणहरू, उपलब्ध उपकरणहरू, र स्रोतहरूको बारेमा जानकारी आदानप्रदान गर्नुहोस्।

2. **उपकरण डिजाइन**: एकै पटक धेरै विषयहरू सम्हाल्ने मोनोलिथिक उपकरणहरू भन्दा एक काम राम्रोसँग गर्ने केन्द्रित उपकरणहरू सिर्जना गर्नुहोस्।

3. **त्रुटि व्यवस्थापन**: समस्या पहिचान गर्न, असफलताहरूलाई सहज रूपमा व्यवस्थापन गर्न, र कार्यान्वयनयोग्य प्रतिक्रिया दिन मानकीकृत त्रुटि सन्देशहरू र कोडहरू लागू गर्नुहोस्।

4. **लगिङ**: प्रोटोकल अन्तरक्रियाहरूको अडिट, डिबगिङ, र अनुगमनका लागि संरचित लगहरू कन्फिगर गर्नुहोस्।

5. **प्रगति ट्र्याकिङ**: लामो समय लाग्ने अपरेसनहरूको लागि प्रगति अपडेटहरू रिपोर्ट गर्नुहोस् जसले प्रतिक्रियाशील प्रयोगकर्ता इन्टरफेस सक्षम पार्छ।

6. **अनुरोध रद्दीकरण**: क्लाइन्टहरूलाई अब आवश्यक नभएका वा धेरै समय लिइरहेका अनुरोधहरू रद्द गर्न अनुमति दिनुहोस्।

## थप सन्दर्भहरू

MCP उत्कृष्ट अभ्यासहरूको सबैभन्दा नयाँ जानकारीका लागि हेर्नुहोस्:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)
- [Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## व्यावहारिक कार्यान्वयन उदाहरणहरू

### उपकरण डिजाइन उत्कृष्ट अभ्यासहरू

#### 1. एकल जिम्मेवारी सिद्धान्त

प्रत्येक MCP उपकरणले स्पष्ट, केन्द्रित उद्देश्य राख्नुपर्छ। धेरै विषयहरू सम्हाल्ने मोनोलिथिक उपकरणहरू बनाउनुभन्दा, विशिष्ट कार्यहरूमा उत्कृष्टता हासिल गर्ने विशेषीकृत उपकरणहरू विकास गर्नुहोस्।

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

#### 2. सुसंगत त्रुटि व्यवस्थापन

जानकारीमूलक त्रुटि सन्देशहरू र उपयुक्त पुनः प्राप्ति संयन्त्रहरूसहित बलियो त्रुटि व्यवस्थापन लागू गर्नुहोस्।

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

#### 3. प्यारामिटर प्रमाणीकरण

सधैं प्यारामिटरहरूलाई पूर्ण रूपमा प्रमाणीकरण गर्नुहोस् ताकि बिग्रिएको वा दुर्भावनापूर्ण इनपुट रोक्न सकियोस्।

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

### सुरक्षा कार्यान्वयन उदाहरणहरू

#### 1. प्रमाणीकरण र प्राधिकरण

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

#### 2. दर सीमांकन

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

## परीक्षण उत्कृष्ट अभ्यासहरू

### 1. MCP उपकरणहरूको युनिट परीक्षण

सधैं तपाईंका उपकरणहरूलाई अलग्गै परीक्षण गर्नुहोस्, बाह्य निर्भरताहरूलाई मोक गरेर:

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

क्लाइन्ट अनुरोधदेखि सर्भर प्रतिक्रियासम्मको सम्पूर्ण प्रवाह परीक्षण गर्नुहोस्:

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

### 1. क्यासिङ रणनीतिहरू

ढिलाइ र स्रोत प्रयोग घटाउन उपयुक्त क्यासिङ लागू गर्नुहोस्:

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
// निर्भरता इन्जेक्सनसहितको Java उदाहरण
public class CurrencyConversionTool implements Tool {
    private final ExchangeRateService exchangeService;
    private final CacheService cacheService;
    private final Logger logger;
    
    // कन्स्ट्रक्टरमार्फत निर्भरता इन्जेक्ट गरिन्छ
    public CurrencyConversionTool(
            ExchangeRateService exchangeService,
            CacheService cacheService,
            Logger logger) {
        this.exchangeService = exchangeService;
        this.cacheService = cacheService;
        this.logger = logger;
    }
    
    // उपकरण कार्यान्वयन
    // ...
}
```

#### 3. Composable Tools

Design tools that can be composed together to create more complex workflows:

```python
# Python उदाहरण जसले संयोज्य उपकरणहरू देखाउँछ
class DataFetchTool(Tool):
    def get_name(self):
        return "dataFetch"
    
    # कार्यान्वयन...

class DataAnalysisTool(Tool):
    def get_name(self):
        return "dataAnalysis"
    
    # यो उपकरण dataFetch उपकरणबाट परिणामहरू प्रयोग गर्न सक्छ
    async def execute_async(self, request):
        # कार्यान्वयन...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # यो उपकरण dataAnalysis उपकरणबाट परिणामहरू प्रयोग गर्न सक्छ
    async def execute_async(self, request):
        # कार्यान्वयन...
        pass

# यी उपकरणहरू स्वतन्त्र रूपमा वा कार्यप्रवाहको भागको रूपमा प्रयोग गर्न सकिन्छ
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
                description = "खोजी क्वेरी पाठ। राम्रो परिणामका लागि सटीक कुञ्जीशब्दहरू प्रयोग गर्नुहोस्।" 
            },
            filters = new {
                type = "object",
                description = "खोजी परिणामहरू सीमित गर्न वैकल्पिक फिल्टरहरू",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "मिति दायरा YYYY-MM-DD:YYYY-MM-DD ढाँचामा" 
                    },
                    category = new { 
                        type = "string", 
                        description = "फिल्टर गर्नको लागि वर्ग नाम" 
                    }
                }
            },
            limit = new { 
                type = "integer", 
                description = "फिर्ता गरिने अधिकतम परिणाम संख्या (1-50)",
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
    
    // इमेल गुणस्तर प्रमाणीकरणसहित
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "प्रयोगकर्ताको इमेल ठेगाना");
    
    // उमेर गुणस्तर संख्यात्मक सीमासहित
    Map<String, Object> age = new HashMap<>();
    age.put("type", "integer");
    age.put("minimum", 13);
    age.put("maximum", 120);
    age.put("description", "प्रयोगकर्ताको उमेर वर्षमा");
    
    // सूचीबद्ध गुणस्तर
    Map<String, Object> subscription = new HashMap<>();
    subscription.put("type", "string");
    subscription.put("enum", Arrays.asList("free", "basic", "premium"));
    subscription.put("default", "free");
    subscription.put("description", "सदस्यता स्तर");
    
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
        # अनुरोध प्रक्रिया गर्नुहोस्
        results = await self._search_database(request.parameters["query"])
        
        # सधैं एक समान संरचना फिर्ता गर्नुहोस्
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
    """प्रत्येक वस्तुमा एक समान संरचना सुनिश्चित गर्दछ"""
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
            throw new ToolExecutionException($"फाइल फेला परेन: {fileId}");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ToolExecutionException("तपाईंलाई यो फाइल पहुँच गर्न अनुमति छैन");
        }
        catch (Exception ex) when (ex is IOException || ex is TimeoutException)
        {
            _logger.LogError(ex, "फाइल पहुँच गर्दा त्रुटि {FileId}", fileId);
            throw new ToolExecutionException("फाइल पहुँच गर्दा त्रुटि: सेवा अस्थायी रूपमा अनुपलब्ध छ");
        }
    }
    catch (JsonException)
    {
        throw new ToolExecutionException("अवैध फाइल ID ढाँचा");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "FileAccessTool मा अप्रत्याशित त्रुटि");
        throw new ToolExecutionException("अप्रत्याशित त्रुटि भयो");
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
        
        // अन्य अपवादहरूलाई ToolExecutionException को रूपमा पुनः थ्रो गर्नुहोस्
        throw new ToolExecutionException("उपकरण कार्यान्वयन असफल भयो: " + ex.getMessage(), ex);
    }
}
```

#### 3. Retry Logic

Implement appropriate retry logic for transient failures:

```python
async def execute_async(self, request):
    max_retries = 3
    retry_count = 0
    base_delay = 1  # सेकेन्ड
    
    while retry_count < max_retries:
        try:
            # बाह्य API कल गर्नुहोस्
            return await self._call_api(request.parameters)
        except TransientError as e:
            retry_count += 1
            if retry_count >= max_retries:
                raise ToolExecutionException(f"{max_retries} प्रयासपछि अपरेशन असफल भयो: {str(e)}")
                
            # घातीय ब्याकअफ
            delay = base_delay * (2 ** (retry_count - 1))
            logging.warning(f"अस्थायी त्रुटि, {delay} सेकेन्डमा पुनः प्रयास गर्दै: {str(e)}")
            await asyncio.sleep(delay)
        except Exception as e:
            # गैर-अस्थायी त्रुटि, पुनः प्रयास नगर्नुहोस्
            raise ToolExecutionException(f"अपरेशन असफल भयो: {str(e)}")
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
    
    // प्यारामिटरहरूमा आधारित क्यास कुञ्जी बनाउनुहोस्
    var cacheKey = $"data_query_{ComputeHash(query)}";
    
    // पहिले क्यासबाट प्राप्त गर्ने प्रयास गर्नुहोस्
    if (_cache.TryGetValue(cacheKey, out var cachedResult))
    {
        return new ToolResponse { Result = cachedResult };
    }
    
    // क्यास मिस - वास्तविक क्वेरी प्रदर्शन गर्नुहोस्
    var result = await _database.QueryAsync(query);
    
    // समाप्ति समय सहित क्यासमा भण्डारण गर्नुहोस्
    var cacheOptions = new MemoryCacheEntryOptions()
        .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
        
    _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
    
    return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
}

private string ComputeHash(string input)
{
    // क्यास कुञ्जीको लागि स्थिर ह्यास उत्पन्न गर्ने कार्यान्वयन
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
        
        // लामो समय लाग्ने अपरेसनहरूको लागि, तुरुन्तै प्रोसेसिङ ID फर्काउनुहोस्
        String processId = UUID.randomUUID().toString();
        
        // एसिंक्रोनस प्रोसेसिङ सुरु गर्नुहोस्
        CompletableFuture.runAsync(() -> {
            try {
                // लामो समय लाग्ने अपरेसन गर्नुहोस्
                documentService.processDocument(documentId);
                
                // स्थिति अपडेट गर्नुहोस् (सामान्यतया डेटाबेसमा भण्डारण गरिन्छ)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // प्रोसेस ID सहित तुरुन्त प्रतिक्रिया फर्काउनुहोस्
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // सहायक स्थिति जाँच उपकरण
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
            tokens_per_second=5,  # प्रति सेकेन्ड ५ अनुरोध अनुमति दिनुहोस्
            bucket_size=10        # १० अनुरोधसम्म अचानक बढ्न अनुमति दिनुहोस्
        )
    
    async def execute_async(self, request):
        # हामी अघि बढ्न सक्छौं वा पर्खनु पर्छ जाँच गर्नुहोस्
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # यदि पर्खाइ धेरै लामो छ भने
                raise ToolExecutionException(
                    f"दर सीमा पार भयो। कृपया {delay:.1f} सेकेन्ड पछि पुन: प्रयास गर्नुहोस्।"
                )
            else:
                # उपयुक्त पर्खाइ समयको लागि पर्खनुहोस्
                await asyncio.sleep(delay)
        
        # एक टोकन प्रयोग गर्नुहोस् र अनुरोधसँग अघि बढ्नुहोस्
        self.rate_limiter.consume()
        
        # API कल गर्नुहोस्
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
            
            # अर्को टोकन उपलब्ध हुन कति समय लाग्छ गणना गर्नुहोस्
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # बितेको समयको आधारमा नयाँ टोकनहरू थप्नुहोस्
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
    // प्यारामिटरहरू अवस्थित छन् कि छैनन् जाँच गर्नुहोस्
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("आवश्यक प्यारामिटर हराइरहेको छ: query");
    }
    
    // सही प्रकार हो कि छैन जाँच गर्नुहोस्
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("Query प्यारामिटर स्ट्रिङ हुनुपर्छ");
    }
    
    var query = queryProp.GetString();
    
    // स्ट्रिङ सामग्री मान्य छ कि छैन जाँच गर्नुहोस्
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("Query प्यारामिटर खाली हुन सक्दैन");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("Query प्यारामिटर अधिकतम ५०० अक्षरभन्दा बढी हुन सक्दैन");
    }
    
    // SQL इन्जेक्सन आक्रमणहरूको लागि जाँच गर्नुहोस् यदि लागू हुन्छ भने
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("अवैध क्वेरी: सम्भावित असुरक्षित SQL समावेश छ");
    }
    
    // कार्यान्वयनसँग अघि बढ्नुहोस्
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // अनुरोधबाट प्रयोगकर्ता सन्दर्भ प्राप्त गर्नुहोस्
    UserContext user = request.getContext().getUserContext();
    
    // प्रयोगकर्तासँग आवश्यक अनुमति छ कि छैन जाँच गर्नुहोस्
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("प्रयोगकर्तासँग कागजातहरू पहुँच गर्ने अनुमति छैन");
    }
    
    // विशेष स्रोतहरूको लागि, सो स्रोतमा पहुँच छ कि छैन जाँच गर्नुहोस्
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("अनुरोधित कागजातमा पहुँच अस्वीकृत");
    }
    
    // उपकरण कार्यान्वयनसँग अघि बढ्नुहोस्
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
        
        # प्रयोगकर्ता डेटा प्राप्त गर्नुहोस्
        user_data = await self.user_service.get_user_data(user_id)
        
        # संवेदनशील क्षेत्रहरू फिल्टर गर्नुहोस् जबसम्म स्पष्ट रूपमा अनुरोध गरिएको छैन र अनुमति छैन
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # अनुरोध सन्दर्भमा अनुमति स्तर जाँच गर्नुहोस्
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # मूललाई परिवर्तन नगर्नको लागि प्रतिलिपि बनाउनुहोस्
        redacted = user_data.copy()
        
        # विशेष संवेदनशील क्षेत्रहरू हटाउनुहोस्
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # नेस्टेड संवेदनशील डेटा हटाउनुहोस्
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
    // तयारी
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
    
    // कार्य
    var response = await tool.ExecuteAsync(request);
    
    // पुष्टि
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // तयारी
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("InvalidLocation", It.IsAny<int>()))
        .ThrowsAsync(new LocationNotFoundException("स्थान फेला परेन"));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "InvalidLocation", 
            days = 3 
        })
    );
    
    // कार्य र पुष्टि
    var exception = await Assert.ThrowsAsync<ToolExecutionException>(
        () => tool.ExecuteAsync(request)
    );
    
    Assert.Contains("स्थान फेला परेन", exception.Message);
}
```

#### 2. Schema Validation Testing

Test that schemas are valid and properly enforce constraints:

```java
@Test
public void testSchemaValidation() {
    // उपकरण उदाहरण बनाउनुहोस्
    SearchTool searchTool = new SearchTool();
    
    // स्कीमा प्राप्त गर्नुहोस्
    Object schema = searchTool.getSchema();
    
    // मान्यताको लागि स्कीमालाई JSON मा रूपान्तरण गर्नुहोस्
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // स्कीमा मान्य JSONSchema हो कि छैन जाँच गर्नुहोस्
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // मान्य प्यारामिटरहरूको परीक्षण गर्नुहोस्
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // आवश्यक प्यारामिटर हराइरहेको परीक्षण गर्नुहोस्
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // अमान्य प्यारामिटर प्रकारको परीक्षण गर्नुहोस्
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
    # तयारी
    tool = ApiTool(timeout=0.1)  # धेरै छोटो टाइमआउट
    
    # टाइमआउट हुने अनुरोध मोक गर्नुहोस्
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # टाइमआउट भन्दा लामो
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # कार्य र पुष्टि
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # अपवाद सन्देश जाँच गर्नुहोस्
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # तयारी
    tool = ApiTool()
    
    # दर सीमित प्रतिक्रिया मोक गर्नुहोस्
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
        
        # कार्य र पुष्टि
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # अपवादमा दर सीमा सम्बन्धी जानकारी छ कि छैन जाँच गर्नुहोस्
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
    // तयारी
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // कार्य
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
        // डिस्कभरी एन्डपोइन्ट परीक्षण गर्नुहोस्
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // टुल अनुरोध सिर्जना गर्नुहोस्
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // अनुरोध पठाउनुहोस् र प्रतिक्रिया जाँच गर्नुहोस्
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // अमान्य टुल अनुरोध सिर्जना गर्नुहोस्
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // "b" प्यारामिटर छुटेको छ
        request.put("parameters", parameters);
        
        // अनुरोध पठाउनुहोस् र त्रुटि प्रतिक्रिया जाँच गर्नुहोस्
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
    # तयारी - MCP क्लाइन्ट र मोक मोडेल सेटअप गर्नुहोस्
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # मोक मोडेल प्रतिक्रियाहरू
    mock_model = MockLanguageModel([
        MockResponse(
            "सिएटलको मौसम कस्तो छ?",
            tool_calls=[{
                "tool_name": "weatherForecast",
                "parameters": {"location": "Seattle", "days": 3}
            }]
        ),
        MockResponse(
            "सिएटलको मौसम पूर्वानुमान यस प्रकार छ:\n- आज: 65°F, आंशिक रूपमा बादल लागेको\n- भोलि: 68°F, घाम लागेको\n- अर्को दिन: 62°F, वर्षा",
            tool_calls=[]
        )
    ])
    
    # मोक मौसम टुल प्रतिक्रिया
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
        
        # कार्य गर्नुहोस्
        response = await mcp_client.send_prompt(
            "सिएटलको मौसम कस्तो छ?",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # पुष्टि गर्नुहोस्
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
    
    // कार्य
    var tasks = new List<Task<McpResponse>>();
    for (int i = 0; i < 1000; i++)
    {
        tasks.Add(client.ExecuteToolAsync("fastTool", new { iteration = i }));
    }
    
    var results = await Task.WhenAll(tasks);
    
    // पुष्टि
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
    
    // स्ट्रेस परीक्षणका लागि JMeter सेटअप गर्नुहोस्
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // JMeter टेस्ट योजना कन्फिगर गर्नुहोस्
    HashTree testPlanTree = new HashTree();
    
    // टेस्ट योजना, थ्रेड समूह, स्याम्पलरहरू आदि सिर्जना गर्नुहोस्
    TestPlan testPlan = new TestPlan("MCP Server Stress Test");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // टुल कार्यान्वयनका लागि HTTP स्याम्पलर थप्नुहोस्
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // लिस्नरहरू थप्नुहोस्
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // परीक्षण चलाउनुहोस्
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // परिणामहरू मान्य गर्नुहोस्
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // औसत प्रतिक्रिया समय < 200ms
    assertTrue(summaryReport.getPercentile(90.0) < 500); // ९० औं पर्सेन्टाइल < ५००ms
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# MCP सर्भरको लागि मोनिटरिङ कन्फिगर गर्नुहोस्
def configure_monitoring(server):
    # Prometheus मेट्रिक्स सेटअप गर्नुहोस्
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "कुल MCP अनुरोधहरू"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "अनुरोध अवधि सेकेन्डमा",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "टुल कार्यान्वयन गणना",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "टुल कार्यान्वयन अवधि सेकेन्डमा",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "टुल कार्यान्वयन त्रुटिहरू",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # समय मापन र मेट्रिक्स रेकर्ड गर्न मिडलवेयर थप्नुहोस्
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # मेट्रिक्स एन्डपोइन्ट एक्स्पोज गर्नुहोस्
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
# Python मा टुलहरूको चेन कार्यान्वयन
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # अनुक्रममा कार्यान्वयन गर्न टुलहरूको सूची
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # चेनमा प्रत्येक टुल कार्यान्वयन गर्नुहोस्, अघिल्लो परिणाम पास गर्दै
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # परिणाम भण्डारण गर्नुहोस् र अर्को टुलको इनपुटको रूपमा प्रयोग गर्नुहोस्
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# उदाहरण प्रयोग
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
    public string Description => "विभिन्न प्रकारका सामग्रीहरू प्रक्रिया गर्छ";
    
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
        
        // कुन विशेष टुल प्रयोग गर्ने निर्धारण गर्नुहोस्
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // विशेष टुलमा अग्रेषित गर्नुहोस्
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
IMPORTANT RULES:
1. अनुवादमा '''markdown वा अन्य कुनै ट्यागहरू नथप्नुहोस्
2. अनुवाद धेरै शाब्दिक नबनाओस्
3. टिप्पणीहरू पनि अनुवाद गर्नुहोस्
4. यो फाइल Markdown ढाँचामा लेखिएको छ - यसलाई XML वा HTML जस्तो व्यवहार नगर्नुहोस्
5. अनुवाद नगर्नुहोस्:
   - [!NOTE], [!WARNING], [!TIP], [!IMPORTANT], [!CAUTION]
   - भेरिएबल नामहरू, फंक्शन नामहरू, क्लास नामहरू
   - @@INLINE_CODE_x@@ वा @@CODE_BLOCK_x@@ जस्ता प्लेसहोल्डरहरू
   - URL वा पथहरू
6. सबै मूल markdown फर्म्याटिङ यथावत राख्नुहोस्
7. कुनै अतिरिक्त ट्याग वा मार्कअप बिना मात्र अनुवादित सामग्री फर्काउनुहोस्
कृपया आउटपुट बायाँदेखि दायाँ लेख्नुहोस्।
("code", _) => "codeAnalyzer",
_ => throw new ToolExecutionException($"No tool available for {contentType}/{operation}")
};
}

private object GetOptionsForTool(string toolName, string operation)
{
// प्रत्येक विशेष उपकरणका लागि उपयुक्त विकल्पहरू फर्काउनुहोस्
return toolName switch
{
    "textSummarizer" => new { length = "medium" },
    "htmlProcessor" => new { cleanUp = true, operation },
    // अन्य उपकरणहरूको लागि विकल्पहरू...
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
        // चरण १: डेटासेट मेटाडाटा प्राप्त गर्नुहोस् (सिन्क्रोनस)
        ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata", 
            Map.of("datasetId", datasetId));
        
        // चरण २: धेरै विश्लेषणहरू समानान्तर रूपमा सुरु गर्नुहोस्
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
        
        // सबै समानान्तर कार्यहरू पूरा हुन कुर्नुहोस्
        CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
            statisticalAnalysis, correlationAnalysis, outlierDetection
        );
        
        allAnalyses.join();  // पूरा हुन कुर्नुहोस्
        
        // चरण ३: परिणामहरू संयोजन गर्नुहोस्
        Map<String, Object> combinedResults = new HashMap<>();
        combinedResults.put("metadata", metadataResponse.getResult());
        combinedResults.put("statistics", statisticalAnalysis.join().getResult());
        combinedResults.put("correlations", correlationAnalysis.join().getResult());
        combinedResults.put("outliers", outlierDetection.join().getResult());
        
        // चरण ४: सारांश रिपोर्ट तयार गर्नुहोस्
        ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator", 
            Map.of("analysisResults", combinedResults));
        
        // पूर्ण workflow परिणाम फर्काउनुहोस्
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
            # पहिले प्राथमिक उपकरण प्रयास गर्नुहोस्
            response = await self.client.execute_tool(primary_tool, parameters)
            return {
                "result": response.result,
                "source": "primary",
                "tool": primary_tool
            }
        except ToolExecutionException as e:
            # असफलता लग गर्नुहोस्
            logging.warning(f"Primary tool '{primary_tool}' failed: {str(e)}")
            
            # दोस्रो उपकरणमा फिर्ता जानुहोस्
            try:
                # फिर्ता उपकरणका लागि आवश्यक परिमार्जन हुन सक्छ
                fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)
                
                response = await self.client.execute_tool(fallback_tool, fallback_params)
                return {
                    "result": response.result,
                    "source": "fallback",
                    "tool": fallback_tool,
                    "primaryError": str(e)
                }
            except ToolExecutionException as fallback_error:
                # दुवै उपकरण असफल भए
                logging.error(f"Both primary and fallback tools failed. Fallback error: {str(fallback_error)}")
                raise WorkflowExecutionException(
                    f"Workflow failed: primary error: {str(e)}; fallback error: {str(fallback_error)}"
                )
    
    def _adapt_parameters(self, params, from_tool, to_tool):
        """आवश्यक भएमा विभिन्न उपकरणहरू बीचमा प्यारामिटरहरू अनुकूलन गर्नुहोस्"""
        # यो कार्यान्वयन विशेष उपकरणहरूमा निर्भर हुनेछ
        # यस उदाहरणमा, हामी मूल प्यारामिटरहरू नै फर्काउनेछौं
        return params

# उदाहरण प्रयोग
async def get_weather(workflow, location):
    return await workflow.execute_with_fallback(
        "premiumWeatherService",  # प्राथमिक (भुक्तानी गरिएको) मौसम API
        "basicWeatherService",    # फिर्ता (निःशुल्क) मौसम API
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
            
            // प्रत्येक workflow को परिणाम भण्डारण गर्नुहोस्
            results[workflow.Name] = workflowResult;
            
            // अर्को workflow का लागि परिणाम सहित सन्दर्भ अपडेट गर्नुहोस्
            context = context.WithResult(workflow.Name, workflowResult);
        }
        
        return new WorkflowResult(results);
    }
    
    public string Name => "CompositeWorkflow";
    public string Description => "धेरै workflows लाई अनुक्रममा चलाउँछ";
}

// उदाहरण प्रयोग
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
// C# मा क्याल्कुलेटर उपकरणको उदाहरण युनिट टेस्ट
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
    
    // कार्य
    var response = await calculator.ExecuteAsync(parameters);
    var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());
    
    // पुष्टि
    Assert.Equal(12, result.Value);
}
```

```python
# Python मा क्याल्कुलेटर उपकरणको उदाहरण युनिट टेस्ट
def test_calculator_tool_add():
    # तयारी
    calculator = CalculatorTool()
    parameters = {
        "operation": "add",
        "a": 5,
        "b": 7
    }
    
    # कार्य
    response = calculator.execute(parameters)
    result = json.loads(response.content[0].text)
    
    # पुष्टि
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
// C# मा MCP सर्भरको उदाहरण इंटिग्रेशन टेस्ट
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
    
    // कार्य
    var response = await server.ProcessRequestAsync(request);
    
    // पुष्टि
    Assert.NotNull(response);
    Assert.Equal(McpStatusCodes.Success, response.StatusCode);
    // प्रतिक्रिया सामग्रीका लागि थप पुष्टि
    
    // सफाइ
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
// TypeScript मा क्लाइन्टसँग E2E टेस्टको उदाहरण
describe('MCP Server E2E Tests', () => {
  let client: McpClient;
  
  beforeAll(async () => {
    // टेस्ट वातावरणमा सर्भर सुरु गर्नुहोस्
    await startTestServer();
    client = new McpClient('http://localhost:5000');
  });
  
  afterAll(async () => {
    await stopTestServer();
  });
  
  test('Client can invoke calculator tool and get correct result', async () => {
    // कार्य
    const response = await client.invokeToolAsync('calculator', {
      operation: 'divide',
      a: 20,
      b: 4
    });
    
    // पुष्टि
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
// C# मा Moq को उदाहरण
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
# Python मा unittest.mock को उदाहरण
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
    # मोक कन्फिगर गर्नुहोस्
    mock_model.return_value.generate_response.return_value = {
        "text": "Mocked model response",
        "finish_reason": "completed"
    }
    
    # टेस्टमा मोक प्रयोग गर्नुहोस्
    server = McpServer(model_client=mock_model)
    # टेस्ट जारी राख्नुहोस्
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
// MCP सर्भरको लोड टेस्टका लागि k6 स्क्रिप्ट
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  vus: 10,  // १० भर्चुअल प्रयोगकर्ता
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
    
    // कार्य
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
    // थप स्कीमा प्रमाणीकरण  
});  
}  
```  

## प्रभावकारी MCP सर्भर परीक्षणका लागि शीर्ष १० सुझावहरू  

1. **टूल परिभाषाहरू अलग-अलग परीक्षण गर्नुहोस्**: टूलको तर्कबाट स्कीमा परिभाषाहरू स्वतन्त्र रूपमा जाँच गर्नुहोस्  
2. **प्यारामिटराइज्ड परीक्षणहरू प्रयोग गर्नुहोस्**: विभिन्न इनपुटहरू सहित, सीमांत केसहरू पनि परीक्षण गर्नुहोस्  
3. **त्रुटि प्रतिक्रियाहरू जाँच गर्नुहोस्**: सबै सम्भावित त्रुटि अवस्थाहरूको सही ह्यान्डलिंग सुनिश्चित गर्नुहोस्  
4. **अधिकार तर्क परीक्षण गर्नुहोस्**: विभिन्न प्रयोगकर्ता भूमिकाहरूको लागि उचित पहुँच नियन्त्रण सुनिश्चित गर्नुहोस्  
5. **परीक्षण कभरज अनुगमन गर्नुहोस्**: महत्वपूर्ण पथ कोडको उच्च कभरज लक्ष्य राख्नुहोस्  
6. **स्ट्रीमिङ प्रतिक्रियाहरू परीक्षण गर्नुहोस्**: स्ट्रीमिङ सामग्रीको सही ह्यान्डलिंग सुनिश्चित गर्नुहोस्  
7. **नेटवर्क समस्याहरू सिमुलेट गर्नुहोस्**: कमजोर नेटवर्क अवस्थाहरूमा व्यवहार परीक्षण गर्नुहोस्  
8. **स्रोत सीमाहरू परीक्षण गर्नुहोस्**: कोटा वा दर सीमाहरू पुगेपछि व्यवहार जाँच गर्नुहोस्  
9. **रिग्रेसन परीक्षणहरू स्वचालित गर्नुहोस्**: प्रत्येक कोड परिवर्तनमा चल्ने परीक्षण सेट तयार गर्नुहोस्  
10. **परीक्षण केसहरू दस्तावेज गर्नुहोस्**: परीक्षण परिदृश्यहरूको स्पष्ट दस्तावेजीकरण राख्नुहोस्  

## सामान्य परीक्षण त्रुटिहरू  

- **खुसी मार्ग परीक्षणमा अत्यधिक निर्भरता**: त्रुटि केसहरूलाई पूर्ण रूपमा परीक्षण गर्न सुनिश्चित गर्नुहोस्  
- **प्रदर्शन परीक्षणलाई बेवास्ता गर्नु**: उत्पादनमा असर पर्नुअघि बाधाहरू पहिचान गर्नुहोस्  
- **केवल पृथक रूपमा परीक्षण गर्नु**: युनिट, एकीकरण, र अन्त्य-देखि-अन्त्य परीक्षणहरू संयोजन गर्नुहोस्  
- **अधूरो API कभरज**: सबै अन्तबिन्दुहरू र सुविधाहरू परीक्षण गरिएको सुनिश्चित गर्नुहोस्  
- **असंगत परीक्षण वातावरणहरू**: निरन्तर परीक्षण वातावरणका लागि कन्टेनरहरू प्रयोग गर्नुहोस्  

## निष्कर्ष  

विश्वसनीय, उच्च गुणस्तरका MCP सर्भरहरू विकास गर्न व्यापक परीक्षण रणनीति आवश्यक छ। यस मार्गदर्शनमा उल्लिखित उत्कृष्ट अभ्यासहरू र सुझावहरू लागू गरेर, तपाईंले आफ्नो MCP कार्यान्वयनहरूलाई उच्चतम गुणस्तर, विश्वसनीयता, र प्रदर्शनका मापदण्डहरू पूरा गर्न सक्नुहुन्छ।  

## मुख्य बुँदाहरू  

1. **टूल डिजाइन**: एकल जिम्मेवारी सिद्धान्त पालना गर्नुहोस्, निर्भरता इंजेक्शन प्रयोग गर्नुहोस्, र संयोज्य डिजाइन गर्नुहोस्  
2. **स्कीमा डिजाइन**: स्पष्ट, राम्रोसँग दस्तावेज गरिएको स्कीमाहरू बनाउनुहोस् जसमा उचित प्रमाणीकरण सर्तहरू समावेश छन्  
3. **त्रुटि ह्यान्डलिंग**: सहज त्रुटि ह्यान्डलिंग, संरचित त्रुटि प्रतिक्रियाहरू, र पुन: प्रयास तर्क लागू गर्नुहोस्  
4. **प्रदर्शन**: क्यासिङ, असिंक्रोनस प्रोसेसिङ, र स्रोत थ्रोटलिङ प्रयोग गर्नुहोस्  
5. **सुरक्षा**: पूर्ण इनपुट प्रमाणीकरण, अधिकार जाँच, र संवेदनशील डाटा ह्यान्डलिंग लागू गर्नुहोस्  
6. **परीक्षण**: व्यापक युनिट, एकीकरण, र अन्त्य-देखि-अन्त्य परीक्षणहरू सिर्जना गर्नुहोस्  
7. **वर्कफ्लो ढाँचाहरू**: चेनहरू, डिस्प्याचरहरू, र समानान्तर प्रोसेसिङ जस्ता स्थापित ढाँचाहरू लागू गर्नुहोस्  

## अभ्यास  

डकुमेन्ट प्रोसेसिङ प्रणालीका लागि MCP टूल र वर्कफ्लो डिजाइन गर्नुहोस् जसले:  

1. विभिन्न ढाँचाहरूमा (PDF, DOCX, TXT) डकुमेन्टहरू स्वीकार्छ  
2. डकुमेन्टहरूबाट पाठ र मुख्य जानकारी निकाल्छ  
3. डकुमेन्टहरूलाई प्रकार र सामग्री अनुसार वर्गीकरण गर्छ  
4. प्रत्येक डकुमेन्टको सारांश तयार पार्छ  

यस परिदृश्यका लागि उपयुक्त टूल स्कीमाहरू, त्रुटि ह्यान्डलिंग, र वर्कफ्लो ढाँचा कार्यान्वयन गर्नुहोस्। तपाईंले यो कार्यान्वयन कसरी परीक्षण गर्नुहुनेछ भनी विचार गर्नुहोस्।  

## स्रोतहरू  

1. नवीनतम विकासहरूमा अपडेट रहन [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs) मा MCP समुदायमा सहभागी हुनुहोस्  
2. खुला स्रोत [MCP परियोजनाहरू](https://github.com/modelcontextprotocol) मा योगदान गर्नुहोस्  
3. आफ्नो संस्थाको AI पहलहरूमा MCP सिद्धान्तहरू लागू गर्नुहोस्  
4. आफ्नो उद्योगका लागि विशेष MCP कार्यान्वयनहरू अन्वेषण गर्नुहोस्  
5. बहु-मोडल एकीकरण वा उद्यम अनुप्रयोग एकीकरण जस्ता विशिष्ट MCP विषयहरूमा उन्नत पाठ्यक्रमहरू लिन विचार गर्नुहोस्  
6. [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) मार्फत सिकेका सिद्धान्तहरू प्रयोग गरी आफ्नै MCP टूल र वर्कफ्लोहरू निर्माण गर्ने अभ्यास गर्नुहोस्  

अर्को: उत्कृष्ट अभ्यासहरू [केस अध्ययनहरू](../09-CaseStudy/README.md)

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा अशुद्धता हुन सक्छ। मूल दस्तावेज यसको मूल भाषामा आधिकारिक स्रोत मानिनुपर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।