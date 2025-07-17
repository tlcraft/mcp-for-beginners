<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "80e5c8949af5af0f401fce6f905990aa",
  "translation_date": "2025-07-17T00:06:49+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "bn"
}
-->
# MCP ডেভেলপমেন্ট সেরা অনুশীলনসমূহ

## ওভারভিউ

এই পাঠে MCP সার্ভার এবং ফিচারগুলো প্রোডাকশন পরিবেশে ডেভেলপ, টেস্ট এবং ডিপ্লয় করার উন্নত সেরা অনুশীলনসমূহের ওপর গুরুত্ব দেওয়া হয়েছে। MCP ইকোসিস্টেম যতই জটিল এবং গুরুত্বপূর্ণ হয়ে উঠছে, প্রতিষ্ঠিত প্যাটার্ন অনুসরণ করলে নির্ভরযোগ্যতা, রক্ষণাবেক্ষণযোগ্যতা এবং আন্তঃপরিচালন ক্ষমতা নিশ্চিত হয়। এই পাঠ বাস্তব MCP বাস্তবায়ন থেকে প্রাপ্ত ব্যবহারিক জ্ঞান একত্রিত করে আপনাকে শক্তিশালী, দক্ষ সার্ভার তৈরি করতে গাইড করবে, যেখানে কার্যকর রিসোর্স, প্রম্পট এবং টুলস থাকবে।

## শেখার উদ্দেশ্য

এই পাঠ শেষ করার পর আপনি সক্ষম হবেন:
- MCP সার্ভার এবং ফিচার ডিজাইনে শিল্পের সেরা অনুশীলন প্রয়োগ করতে
- MCP সার্ভারের জন্য ব্যাপক টেস্টিং কৌশল তৈরি করতে
- জটিল MCP অ্যাপ্লিকেশনের জন্য দক্ষ, পুনঃব্যবহারযোগ্য ওয়ার্কফ্লো প্যাটার্ন ডিজাইন করতে
- MCP সার্ভারে সঠিক ত্রুটি পরিচালনা, লগিং এবং পর্যবেক্ষণ বাস্তবায়ন করতে
- পারফরম্যান্স, নিরাপত্তা এবং রক্ষণাবেক্ষণযোগ্যতার জন্য MCP বাস্তবায়ন অপ্টিমাইজ করতে

## MCP মূল নীতিমালা

নির্দিষ্ট বাস্তবায়ন অনুশীলনে প্রবেশ করার আগে, কার্যকর MCP ডেভেলপমেন্টের জন্য নির্দেশক মূল নীতিমালা বোঝা জরুরি:

1. **স্ট্যান্ডার্ডাইজড কমিউনিকেশন**: MCP JSON-RPC 2.0 ব্যবহার করে, যা সমস্ত বাস্তবায়নে অনুরোধ, প্রতিক্রিয়া এবং ত্রুটি পরিচালনার জন্য একটি সঙ্গতিপূর্ণ ফরম্যাট প্রদান করে।

2. **ব্যবহারকারী-কেন্দ্রিক ডিজাইন**: সবসময় ব্যবহারকারীর সম্মতি, নিয়ন্ত্রণ এবং স্বচ্ছতাকে MCP বাস্তবায়নে অগ্রাধিকার দিন।

3. **নিরাপত্তা প্রথমে**: প্রমাণীকরণ, অনুমোদন, যাচাই এবং রেট সীমাবদ্ধতা সহ শক্তিশালী নিরাপত্তা ব্যবস্থা বাস্তবায়ন করুন।

4. **মডুলার আর্কিটেকচার**: MCP সার্ভারগুলো মডুলার পদ্ধতিতে ডিজাইন করুন, যেখানে প্রতিটি টুল এবং রিসোর্সের একটি স্পষ্ট, কেন্দ্রীভূত উদ্দেশ্য থাকে।

5. **স্টেটফুল কানেকশন**: MCP এর ক্ষমতা ব্যবহার করুন একাধিক অনুরোধের মধ্যে অবস্থা বজায় রাখার জন্য, যাতে আরও সঙ্গতিপূর্ণ এবং প্রসঙ্গ-সচেতন ইন্টারঅ্যাকশন হয়।

## অফিসিয়াল MCP সেরা অনুশীলনসমূহ

নিম্নলিখিত সেরা অনুশীলনসমূহ অফিসিয়াল Model Context Protocol ডকুমেন্টেশন থেকে নেওয়া হয়েছে:

### নিরাপত্তা সেরা অনুশীলনসমূহ

1. **ব্যবহারকারীর সম্মতি এবং নিয়ন্ত্রণ**: ডেটা অ্যাক্সেস বা অপারেশন করার আগে সবসময় স্পষ্ট ব্যবহারকারীর সম্মতি নিন। কোন ডেটা শেয়ার করা হবে এবং কোন কাজ অনুমোদিত তা স্পষ্ট নিয়ন্ত্রণ প্রদান করুন।

2. **ডেটা গোপনীয়তা**: শুধুমাত্র স্পষ্ট সম্মতির মাধ্যমে ব্যবহারকারীর ডেটা প্রকাশ করুন এবং উপযুক্ত অ্যাক্সেস নিয়ন্ত্রণ দিয়ে সুরক্ষিত রাখুন। অননুমোদিত ডেটা প্রেরণ থেকে রক্ষা করুন।

3. **টুল নিরাপত্তা**: যেকোনো টুল কল করার আগে স্পষ্ট ব্যবহারকারীর সম্মতি নিন। ব্যবহারকারীরা প্রতিটি টুলের কার্যকারিতা বুঝতে পারবে এবং শক্তিশালী নিরাপত্তা সীমা প্রয়োগ করুন।

4. **টুল অনুমতি নিয়ন্ত্রণ**: সেশন চলাকালীন কোন টুলগুলো মডেল ব্যবহার করতে পারবে তা কনফিগার করুন, যাতে শুধুমাত্র স্পষ্টভাবে অনুমোদিত টুলগুলো অ্যাক্সেসযোগ্য হয়।

5. **প্রমাণীকরণ**: টুল, রিসোর্স বা সংবেদনশীল অপারেশনে অ্যাক্সেস দেওয়ার আগে সঠিক প্রমাণীকরণ নিশ্চিত করুন, যেমন API কী, OAuth টোকেন বা অন্যান্য নিরাপদ প্রমাণীকরণ পদ্ধতি ব্যবহার করে।

6. **প্যারামিটার যাচাই**: সব টুল কলের জন্য যাচাই বাধ্যতামূলক করুন যাতে ভুল বা ক্ষতিকর ইনপুট টুল বাস্তবায়নে পৌঁছাতে না পারে।

7. **রেট সীমাবদ্ধতা**: অপব্যবহার রোধ করতে এবং সার্ভার রিসোর্সের ন্যায্য ব্যবহার নিশ্চিত করতে রেট সীমাবদ্ধতা প্রয়োগ করুন।

### বাস্তবায়ন সেরা অনুশীলনসমূহ

1. **ক্ষমতা আলোচনা**: কানেকশন সেটআপের সময় সমর্থিত ফিচার, প্রোটোকল ভার্সন, উপলব্ধ টুল এবং রিসোর্স সম্পর্কে তথ্য বিনিময় করুন।

2. **টুল ডিজাইন**: এমন টুল তৈরি করুন যা একটি কাজ ভালোভাবে করে, বড় বড় টুলের পরিবর্তে যা একাধিক বিষয় সামলায়।

3. **ত্রুটি পরিচালনা**: স্ট্যান্ডার্ডাইজড ত্রুটি বার্তা এবং কোড বাস্তবায়ন করুন যা সমস্যা নির্ণয়, ব্যর্থতা সুন্দরভাবে পরিচালনা এবং কার্যকর প্রতিক্রিয়া প্রদান করে।

4. **লগিং**: প্রোটোকল ইন্টারঅ্যাকশনের অডিট, ডিবাগ এবং মনিটরিংয়ের জন্য কাঠামোবদ্ধ লগ কনফিগার করুন।

5. **প্রগতি ট্র্যাকিং**: দীর্ঘমেয়াদী অপারেশনের জন্য প্রগতি আপডেট রিপোর্ট করুন যাতে ব্যবহারকারী ইন্টারফেস দ্রুত প্রতিক্রিয়া দিতে পারে।

6. **অনুরোধ বাতিলকরণ**: ক্লায়েন্টদের এমন অনুরোধ বাতিল করার অনুমতি দিন যা আর প্রয়োজন নেই বা খুব বেশি সময় নিচ্ছে।

## অতিরিক্ত রেফারেন্স

MCP সেরা অনুশীলন সম্পর্কে সর্বশেষ তথ্যের জন্য দেখুন:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)
- [Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## ব্যবহারিক বাস্তবায়ন উদাহরণ

### টুল ডিজাইন সেরা অনুশীলনসমূহ

#### ১. একক দায়িত্ব নীতি

প্রতিটি MCP টুলের একটি স্পষ্ট, কেন্দ্রীভূত উদ্দেশ্য থাকা উচিত। একাধিক বিষয় সামলানোর চেষ্টা করা বড় টুল তৈরির পরিবর্তে, বিশেষায়িত টুল তৈরি করুন যা নির্দিষ্ট কাজগুলোতে দক্ষ।

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

#### ২. সঙ্গতিপূর্ণ ত্রুটি পরিচালনা

তথ্যবহুল ত্রুটি বার্তা এবং উপযুক্ত পুনরুদ্ধার প্রক্রিয়া সহ শক্তিশালী ত্রুটি পরিচালনা বাস্তবায়ন করুন।

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

#### ৩. প্যারামিটার যাচাই

সবসময় প্যারামিটারগুলো ভালোভাবে যাচাই করুন যাতে ভুল বা ক্ষতিকর ইনপুট প্রতিরোধ করা যায়।

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

### নিরাপত্তা বাস্তবায়ন উদাহরণ

#### ১. প্রমাণীকরণ এবং অনুমোদন

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

#### ২. রেট সীমাবদ্ধতা

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

## টেস্টিং সেরা অনুশীলনসমূহ

### ১. ইউনিট টেস্টিং MCP টুলস

সবসময় আপনার টুলগুলো আলাদাভাবে টেস্ট করুন, বাহ্যিক নির্ভরশীলতাগুলো মক করে:

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

### ২. ইন্টিগ্রেশন টেস্টিং

ক্লায়েন্ট অনুরোধ থেকে সার্ভার প্রতিক্রিয়া পর্যন্ত সম্পূর্ণ প্রবাহ পরীক্ষা করুন:

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

## পারফরম্যান্স অপ্টিমাইজেশন

### ১. ক্যাশিং কৌশল

প্রতিবন্ধকতা কমাতে এবং রিসোর্স ব্যবহারে দক্ষতা বাড়াতে উপযুক্ত ক্যাশিং বাস্তবায়ন করুন:

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
    
    // প্যারামিটারগুলোর উপর ভিত্তি করে ক্যাশ কী তৈরি করুন
    var cacheKey = $"data_query_{ComputeHash(query)}";
    
    // প্রথমে ক্যাশ থেকে পাওয়ার চেষ্টা করুন
    if (_cache.TryGetValue(cacheKey, out var cachedResult))
    {
        return new ToolResponse { Result = cachedResult };
    }
    
    // ক্যাশ মিস - আসল কুয়েরি চালান
    var result = await _database.QueryAsync(query);
    
    // মেয়াদ উত্তীর্ণের সাথে ক্যাশে সংরক্ষণ করুন
    var cacheOptions = new MemoryCacheEntryOptions()
        .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
        
    _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
    
    return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
}

private string ComputeHash(string input)
{
    // ক্যাশ কী এর জন্য স্থিতিশীল হ্যাশ তৈরি করার বাস্তবায়ন
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
        
        // দীর্ঘমেয়াদী অপারেশনের জন্য, অবিলম্বে একটি প্রসেসিং আইডি ফেরত দিন
        String processId = UUID.randomUUID().toString();
        
        // অ্যাসিঙ্ক্রোনাস প্রসেসিং শুরু করুন
        CompletableFuture.runAsync(() -> {
            try {
                // দীর্ঘমেয়াদী অপারেশন সম্পাদন করুন
                documentService.processDocument(documentId);
                
                // স্ট্যাটাস আপডেট করুন (সাধারণত ডাটাবেসে সংরক্ষিত হবে)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // প্রসেস আইডি সহ অবিলম্বে প্রতিক্রিয়া ফেরত দিন
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // সঙ্গী স্ট্যাটাস চেক টুল
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
            tokens_per_second=5,  # প্রতি সেকেন্ডে ৫টি অনুরোধ অনুমোদন করুন
            bucket_size=10        # ১০টি অনুরোধ পর্যন্ত বুস্ট অনুমতি দিন
        )
    
    async def execute_async(self, request):
        # আমরা কি এগিয়ে যেতে পারি নাকি অপেক্ষা করতে হবে তা পরীক্ষা করুন
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # যদি অপেক্ষার সময় খুব বেশি হয়
                raise ToolExecutionException(
                    f"রেট লিমিট অতিক্রম হয়েছে। অনুগ্রহ করে {delay:.1f} সেকেন্ড পরে আবার চেষ্টা করুন।"
                )
            else:
                # উপযুক্ত অপেক্ষার সময়ের জন্য অপেক্ষা করুন
                await asyncio.sleep(delay)
        
        # একটি টোকেন ব্যবহার করুন এবং অনুরোধটি চালিয়ে যান
        self.rate_limiter.consume()
        
        # API কল করুন
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
            
            # পরবর্তী টোকেন পাওয়ার জন্য সময় গণনা করুন
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # অতিবাহিত সময়ের ভিত্তিতে নতুন টোকেন যোগ করুন
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
    // প্যারামিটার আছে কিনা যাচাই করুন
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("প্রয়োজনীয় প্যারামিটার অনুপস্থিত: query");
    }
    
    // সঠিক টাইপ যাচাই করুন
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("Query প্যারামিটার অবশ্যই একটি স্ট্রিং হতে হবে");
    }
    
    var query = queryProp.GetString();
    
    // স্ট্রিং কন্টেন্ট যাচাই করুন
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("Query প্যারামিটার খালি হতে পারে না");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("Query প্যারামিটার সর্বোচ্চ ৫০০ অক্ষরের হতে পারে");
    }
    
    // প্রযোজ্য হলে SQL ইনজেকশন আক্রমণের জন্য পরীক্ষা করুন
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("অবৈধ কুয়েরি: সম্ভাব্য অনিরাপদ SQL রয়েছে");
    }
    
    // কার্যকরী অংশ চালিয়ে যান
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // রিকোয়েস্ট থেকে ব্যবহারকারীর প্রসঙ্গ নিন
    UserContext user = request.getContext().getUserContext();
    
    // ব্যবহারকারীর প্রয়োজনীয় অনুমতি আছে কিনা পরীক্ষা করুন
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("ব্যবহারকারীর ডকুমেন্ট অ্যাক্সেস করার অনুমতি নেই");
    }
    
    // নির্দিষ্ট রিসোর্সের জন্য, সেই রিসোর্সে অ্যাক্সেস আছে কিনা পরীক্ষা করুন
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("অনুরোধকৃত ডকুমেন্টে অ্যাক্সেস অস্বীকৃত");
    }
    
    // টুল এক্সিকিউশনে এগিয়ে যান
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
        
        # ব্যবহারকারীর তথ্য নিন
        user_data = await self.user_service.get_user_data(user_id)
        
        # স্পর্শকাতর ক্ষেত্রগুলি ফিল্টার করুন যদি স্পষ্টভাবে অনুরোধ না করা হয় এবং অনুমোদিত না হয়
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # রিকোয়েস্ট প্রসঙ্গে অনুমোদন স্তর পরীক্ষা করুন
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # মূল ডেটা পরিবর্তন এড়াতে একটি কপি তৈরি করুন
        redacted = user_data.copy()
        
        # নির্দিষ্ট স্পর্শকাতর ক্ষেত্র লুকান
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # নেস্টেড স্পর্শকাতর তথ্য লুকান
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
    // প্রস্তুতি
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("Seattle", 3))
        .ReturnsAsync(new WeatherForecast(/* টেস্ট ডেটা */));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "Seattle", 
            days = 3 
        })
    );
    
    // কার্যকরী অংশ
    var response = await tool.ExecuteAsync(request);
    
    // যাচাই
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // প্রস্তুতি
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("InvalidLocation", It.IsAny<int>()))
        .ThrowsAsync(new LocationNotFoundException("অবস্থান পাওয়া যায়নি"));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "InvalidLocation", 
            days = 3 
        })
    );
    
    // কার্যকরী অংশ ও যাচাই
    var exception = await Assert.ThrowsAsync<ToolExecutionException>(
        () => tool.ExecuteAsync(request)
    );
    
    Assert.Contains("অবস্থান পাওয়া যায়নি", exception.Message);
}
```

#### 2. Schema Validation Testing

Test that schemas are valid and properly enforce constraints:

```java
@Test
public void testSchemaValidation() {
    // টুল ইনস্ট্যান্স তৈরি করুন
    SearchTool searchTool = new SearchTool();
    
    // স্কিমা নিন
    Object schema = searchTool.getSchema();
    
    // যাচাইয়ের জন্য স্কিমাকে JSON এ রূপান্তর করুন
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // যাচাই করুন স্কিমা বৈধ JSONSchema কিনা
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // বৈধ প্যারামিটার টেস্ট করুন
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // প্রয়োজনীয় প্যারামিটার অনুপস্থিত টেস্ট করুন
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // অবৈধ প্যারামিটার টাইপ টেস্ট করুন
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
    # প্রস্তুতি
    tool = ApiTool(timeout=0.1)  # খুবই কম সময়সীমা
    
    # একটি রিকোয়েস্ট মক করুন যা টাইমআউট হবে
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # টাইমআউটের চেয়ে বেশি সময়
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # কার্যকরী অংশ ও যাচাই
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # এক্সসেপশনের মেসেজ যাচাই করুন
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # প্রস্তুতি
    tool = ApiTool()
    
    # রেট-লিমিটেড রেসপন্স মক করুন
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
        
        # কার্যকরী অংশ ও যাচাই
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # এক্সসেপশনে রেট লিমিট সম্পর্কিত তথ্য আছে কিনা যাচাই করুন
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
    // প্রস্তুতি
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // কার্যকরী অংশ
IMPORTANT RULES:
1. অনুবাদের চারপাশে '''markdown বা অন্য কোনো ট্যাগ যোগ করবেন না
2. অনুবাদ খুবই শাব্দিক না হওয়া নিশ্চিত করুন
3. মন্তব্যসমূহও অনুবাদ করুন
4. এই ফাইলটি Markdown ফরম্যাটে লেখা - এটিকে XML বা HTML হিসেবে বিবেচনা করবেন না
5. অনুবাদ করবেন না:
   - [!NOTE], [!WARNING], [!TIP], [!IMPORTANT], [!CAUTION]
   - ভেরিয়েবল নাম, ফাংশন নাম, ক্লাস নাম
   - @@INLINE_CODE_x@@ বা @@CODE_BLOCK_x@@ এর মতো প্লেসহোল্ডার
   - URL বা পাথ
6. সকল মূল markdown ফরম্যাটিং অপরিবর্তিত রাখুন
7. শুধুমাত্র অনূদিত বিষয়বস্তু ফিরিয়ে দিন, অতিরিক্ত কোনো ট্যাগ বা মার্কআপ ছাড়া
অনুগ্রহ করে আউটপুট বাম থেকে ডানে লিখুন।

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
        // ডিসকভারি এন্ডপয়েন্ট পরীক্ষা করুন
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // টুল রিকোয়েস্ট তৈরি করুন
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // রিকোয়েস্ট পাঠান এবং রেসপন্স যাচাই করুন
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // অবৈধ টুল রিকোয়েস্ট তৈরি করুন
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // "b" প্যারামিটার অনুপস্থিত
        request.put("parameters", parameters);
        
        // রিকোয়েস্ট পাঠান এবং ত্রুটি রেসপন্স যাচাই করুন
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
    # প্রস্তুতি - MCP ক্লায়েন্ট এবং মক মডেল সেটআপ করুন
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # মক মডেল রেসপন্স
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
    
    # মক ওয়েদার টুল রেসপন্স
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
        
        # কার্যকর করুন
        response = await mcp_client.send_prompt(
            "What's the weather in Seattle?",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # যাচাই করুন
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
    // প্রস্তুতি
    var server = new McpServer(
        name: "TestServer",
        version: "1.0",
        maxConcurrentRequests: 100
    );
    
    server.RegisterTool(new FastExecutingTool());
    await server.StartAsync();
    
    var client = new McpClient("http://localhost:5000");
    
    // কার্যকর করুন
    var tasks = new List<Task<McpResponse>>();
    for (int i = 0; i < 1000; i++)
    {
        tasks.Add(client.ExecuteToolAsync("fastTool", new { iteration = i }));
    }
    
    var results = await Task.WhenAll(tasks);
    
    // যাচাই করুন
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
    
    // স্ট্রেস টেস্টিং এর জন্য JMeter সেটআপ করুন
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // JMeter টেস্ট প্ল্যান কনফিগার করুন
    HashTree testPlanTree = new HashTree();
    
    // টেস্ট প্ল্যান, থ্রেড গ্রুপ, স্যাম্পলার ইত্যাদি তৈরি করুন
    TestPlan testPlan = new TestPlan("MCP Server Stress Test");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // টুল এক্সিকিউশনের জন্য HTTP স্যাম্পলার যোগ করুন
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // লিসেনার যোগ করুন
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // টেস্ট চালান
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // ফলাফল যাচাই করুন
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // গড় রেসপন্স টাইম < ২০০মিলিসেকেন্ড
    assertTrue(summaryReport.getPercentile(90.0) < 500); // ৯০তম পারসেন্টাইল < ৫০০মিলিসেকেন্ড
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# MCP সার্ভারের জন্য মনিটরিং কনফিগার করুন
def configure_monitoring(server):
    # Prometheus মেট্রিক্স সেটআপ করুন
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "মোট MCP রিকোয়েস্ট"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "রিকোয়েস্টের সময়কাল সেকেন্ডে",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "টুল এক্সিকিউশনের সংখ্যা",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "টুল এক্সিকিউশনের সময়কাল সেকেন্ডে",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "টুল এক্সিকিউশনের ত্রুটি",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # টাইমিং এবং মেট্রিক্স রেকর্ড করার জন্য মিডলওয়্যার যোগ করুন
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # মেট্রিক্স এন্ডপয়েন্ট প্রকাশ করুন
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
# পাইথন চেইন অফ টুলস ইমপ্লিমেন্টেশন
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # ধারাবাহিকভাবে চালানোর জন্য টুল নামের তালিকা
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # প্রতিটি টুল চালান, পূর্বের ফলাফল পাস করে
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # ফলাফল সংরক্ষণ করুন এবং পরবর্তী টুলের ইনপুট হিসেবে ব্যবহার করুন
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# উদাহরণ ব্যবহার
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
    public string Description => "বিভিন্ন ধরনের কন্টেন্ট প্রক্রিয়াকরণ করে";
    
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
        
        // নির্ধারণ করুন কোন বিশেষায়িত টুল ব্যবহার করবেন
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // বিশেষায়িত টুলে ফরওয়ার্ড করুন
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
1. অনুবাদের চারপাশে '''markdown বা অন্য কোনো ট্যাগ যোগ করবেন না
2. অনুবাদ খুবই শাব্দিক না হওয়া নিশ্চিত করুন
3. মন্তব্যসমূহও অনুবাদ করুন
4. এই ফাইলটি Markdown ফরম্যাটে লেখা - এটিকে XML বা HTML হিসেবে বিবেচনা করবেন না
5. অনুবাদ করবেন না:
   - [!NOTE], [!WARNING], [!TIP], [!IMPORTANT], [!CAUTION]
   - ভেরিয়েবল নাম, ফাংশন নাম, ক্লাস নাম
   - @@INLINE_CODE_x@@ বা @@CODE_BLOCK_x@@ এর মতো প্লেসহোল্ডার
   - URL বা পাথসমূহ
6. সমস্ত মূল markdown ফরম্যাটিং অপরিবর্তিত রাখুন
7. শুধুমাত্র অনূদিত বিষয়বস্তু প্রদান করুন, কোনো অতিরিক্ত ট্যাগ বা মার্কআপ ছাড়া
("code", _) => "codeAnalyzer",
_ => throw new ToolExecutionException($"No tool available for {contentType}/{operation}")
};
}

private object GetOptionsForTool(string toolName, string operation)
{
// প্রতিটি বিশেষায়িত টুলের জন্য উপযুক্ত অপশন ফেরত দিন
return toolName switch
{
    "textSummarizer" => new { length = "medium" },
    "htmlProcessor" => new { cleanUp = true, operation },
    // অন্যান্য টুলের জন্য অপশন...
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
        // ধাপ ১: ডেটাসেট মেটাডেটা সংগ্রহ করুন (সিঙ্ক্রোনাস)
        ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata", 
            Map.of("datasetId", datasetId));
        
        // ধাপ ২: একাধিক বিশ্লেষণ সমান্তরালে চালান
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
        
        // সব সমান্তরাল কাজ শেষ হওয়া পর্যন্ত অপেক্ষা করুন
        CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
            statisticalAnalysis, correlationAnalysis, outlierDetection
        );
        
        allAnalyses.join();  // সমাপ্তির জন্য অপেক্ষা করুন
        
        // ধাপ ৩: ফলাফল একত্রিত করুন
        Map<String, Object> combinedResults = new HashMap<>();
        combinedResults.put("metadata", metadataResponse.getResult());
        combinedResults.put("statistics", statisticalAnalysis.join().getResult());
        combinedResults.put("correlations", correlationAnalysis.join().getResult());
        combinedResults.put("outliers", outlierDetection.join().getResult());
        
        // ধাপ ৪: সারাংশ প্রতিবেদন তৈরি করুন
        ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator", 
            Map.of("analysisResults", combinedResults));
        
        // সম্পূর্ণ ওয়ার্কফ্লো ফলাফল ফেরত দিন
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
            # প্রথমে প্রাইমারি টুল চেষ্টা করুন
            response = await self.client.execute_tool(primary_tool, parameters)
            return {
                "result": response.result,
                "source": "primary",
                "tool": primary_tool
            }
        except ToolExecutionException as e:
            # ব্যর্থতার লগ করুন
            logging.warning(f"Primary tool '{primary_tool}' failed: {str(e)}")
            
            # সেকেন্ডারি টুলে ফallback করুন
            try:
                # ফallback টুলের জন্য প্যারামিটার পরিবর্তন প্রয়োজন হতে পারে
                fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)
                
                response = await self.client.execute_tool(fallback_tool, fallback_params)
                return {
                    "result": response.result,
                    "source": "fallback",
                    "tool": fallback_tool,
                    "primaryError": str(e)
                }
            except ToolExecutionException as fallback_error:
                # উভয় টুল ব্যর্থ হয়েছে
                logging.error(f"Both primary and fallback tools failed. Fallback error: {str(fallback_error)}")
                raise WorkflowExecutionException(
                    f"Workflow failed: primary error: {str(e)}; fallback error: {str(fallback_error)}"
                )
    
    def _adapt_parameters(self, params, from_tool, to_tool):
        """প্রয়োজনে বিভিন্ন টুলের মধ্যে প্যারামিটার সামঞ্জস্য করুন"""
        # এই ইমপ্লিমেন্টেশন নির্দিষ্ট টুলের উপর নির্ভর করবে
        # এই উদাহরণে, আমরা মূল প্যারামিটারই ফেরত দেব
        return params

# উদাহরণ ব্যবহার
async def get_weather(workflow, location):
    return await workflow.execute_with_fallback(
        "premiumWeatherService",  # প্রাইমারি (পেইড) আবহাওয়া API
        "basicWeatherService",    # ফallback (ফ্রি) আবহাওয়া API
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
            
            // প্রতিটি ওয়ার্কফ্লোর ফলাফল সংরক্ষণ করুন
            results[workflow.Name] = workflowResult;
            
            // পরবর্তী ওয়ার্কফ্লোর জন্য ফলাফল সহ context আপডেট করুন
            context = context.WithResult(workflow.Name, workflowResult);
        }
        
        return new WorkflowResult(results);
    }
    
    public string Name => "CompositeWorkflow";
    public string Description => "একাধিক ওয়ার্কফ্লো ধারাবাহিকভাবে চালায়";
}

// উদাহরণ ব্যবহার
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
// C# এ একটি calculator টুলের জন্য উদাহরণ ইউনিট টেস্ট
[Fact]
public async Task CalculatorTool_Add_ReturnsCorrectSum()
{
    // প্রস্তুতি
    var calculator = new CalculatorTool();
    var parameters = new Dictionary<string, object>
    {
        ["operation"] = "add",
        ["a"] = 5,
        ["b"] = 7
    };
    
    // কার্যকরী অংশ
    var response = await calculator.ExecuteAsync(parameters);
    var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());
    
    // নিশ্চিতকরণ
    Assert.Equal(12, result.Value);
}
```

```python
# Python এ calculator টুলের জন্য উদাহরণ ইউনিট টেস্ট
def test_calculator_tool_add():
    # প্রস্তুতি
    calculator = CalculatorTool()
    parameters = {
        "operation": "add",
        "a": 5,
        "b": 7
    }
    
    # কার্যকরী অংশ
    response = calculator.execute(parameters)
    result = json.loads(response.content[0].text)
    
    # নিশ্চিতকরণ
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
// C# এ MCP সার্ভারের জন্য উদাহরণ ইন্টিগ্রেশন টেস্ট
[Fact]
public async Task Server_ProcessToolRequest_ReturnsValidResponse()
{
    // প্রস্তুতি
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
    
    // কার্যকরী অংশ
    var response = await server.ProcessRequestAsync(request);
    
    // নিশ্চিতকরণ
    Assert.NotNull(response);
    Assert.Equal(McpStatusCodes.Success, response.StatusCode);
    // প্রতিক্রিয়া বিষয়বস্তুর জন্য অতিরিক্ত নিশ্চিতকরণ
    
    // পরিস্কার-পরিচ্ছন্নতা
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
// TypeScript এ ক্লায়েন্ট সহ উদাহরণ E2E টেস্ট
describe('MCP Server E2E Tests', () => {
  let client: McpClient;
  
  beforeAll(async () => {
    // টেস্ট পরিবেশে সার্ভার শুরু করুন
    await startTestServer();
    client = new McpClient('http://localhost:5000');
  });
  
  afterAll(async () => {
    await stopTestServer();
  });
  
  test('Client can invoke calculator tool and get correct result', async () => {
    // কার্যকরী অংশ
    const response = await client.invokeToolAsync('calculator', {
      operation: 'divide',
      a: 20,
      b: 4
    });
    
    // নিশ্চিতকরণ
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
// C# উদাহরণ Moq সহ
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
# Python উদাহরণ unittest.mock সহ
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
    # মক কনফিগার করুন
    mock_model.return_value.generate_response.return_value = {
        "text": "Mocked model response",
        "finish_reason": "completed"
    }
    
    # টেস্টে মক ব্যবহার করুন
    server = McpServer(model_client=mock_model)
    # টেস্ট চালিয়ে যান
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
// MCP সার্ভারের লোড টেস্টিং এর জন্য k6 স্ক্রিপ্ট
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  vus: 10,  // ১০ ভার্চুয়াল ব্যবহারকারী
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
    // প্রস্তুতি
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");
    
    // কার্যকরী অংশ
    var response = await client.GetAsync("http://localhost:5000/api/resources");
    var content = await response.Content.ReadAsStringAsync();
    var resources = JsonSerializer.Deserialize
<ResourceList>
// Assert
Assert.Equal(HttpStatusCode.OK, response.StatusCode);
Assert.NotNull(resources);
Assert.All(resources.Resources, resource => 
{
    Assert.NotNull(resource.Id);
    Assert.NotNull(resource.Type);
    // অতিরিক্ত স্কিমা যাচাই
});
}

## কার্যকর MCP সার্ভার টেস্টিংয়ের শীর্ষ ১০ টিপস

1. **টেস্ট টুল ডেফিনিশন আলাদাভাবে পরীক্ষা করুন**: টুল লজিক থেকে স্কিমা ডেফিনিশন স্বাধীনভাবে যাচাই করুন  
2. **প্যারামিটারাইজড টেস্ট ব্যবহার করুন**: বিভিন্ন ইনপুট সহ টুলগুলো পরীক্ষা করুন, বিশেষ করে সীমান্ত ক্ষেত্রগুলি  
3. **এরর রেসপন্স পরীক্ষা করুন**: সব সম্ভাব্য এরর কন্ডিশনের জন্য সঠিক এরর হ্যান্ডলিং নিশ্চিত করুন  
4. **অথরাইজেশন লজিক পরীক্ষা করুন**: বিভিন্ন ইউজার রোলের জন্য সঠিক অ্যাক্সেস কন্ট্রোল নিশ্চিত করুন  
5. **টেস্ট কভারেজ মনিটর করুন**: গুরুত্বপূর্ণ কোড পাথের উচ্চ কভারেজ লক্ষ্য করুন  
6. **স্ট্রিমিং রেসপন্স পরীক্ষা করুন**: স্ট্রিমিং কন্টেন্ট সঠিকভাবে হ্যান্ডল করা হচ্ছে কিনা যাচাই করুন  
7. **নেটওয়ার্ক সমস্যা সিমুলেট করুন**: দুর্বল নেটওয়ার্ক অবস্থায় আচরণ পরীক্ষা করুন  
8. **রিসোর্স লিমিট পরীক্ষা করুন**: কোটা বা রেট লিমিট পৌঁছালে সিস্টেমের আচরণ যাচাই করুন  
9. **রিগ্রেশন টেস্ট অটোমেট করুন**: প্রতিটি কোড পরিবর্তনের সাথে চলার জন্য একটি টেস্ট স্যুট তৈরি করুন  
10. **টেস্ট কেস ডকুমেন্ট করুন**: টেস্ট সিনারিওগুলোর স্পষ্ট ডকুমেন্টেশন বজায় রাখুন  

## সাধারণ টেস্টিং ভুল

- **শুধুমাত্র সফল পথের উপর অতিরিক্ত নির্ভরতা**: এরর কেসগুলোও ভালোভাবে পরীক্ষা করুন  
- **পারফরম্যান্স টেস্ট উপেক্ষা করা**: প্রোডাকশনে সমস্যা হওয়ার আগে বটলনেক চিহ্নিত করুন  
- **শুধুমাত্র আইসোলেশন টেস্ট করা**: ইউনিট, ইন্টিগ্রেশন এবং E2E টেস্ট একসাথে করুন  
- **অসম্পূর্ণ API কভারেজ**: সব এন্ডপয়েন্ট এবং ফিচার পরীক্ষা নিশ্চিত করুন  
- **অসঙ্গত টেস্ট পরিবেশ**: ধারাবাহিক টেস্ট পরিবেশের জন্য কন্টেইনার ব্যবহার করুন  

## উপসংহার

একটি ব্যাপক টেস্টিং কৌশল নির্ভরযোগ্য, উচ্চমানের MCP সার্ভার তৈরি করার জন্য অপরিহার্য। এই গাইডে বর্ণিত সেরা অনুশীলন এবং টিপস অনুসরণ করে, আপনি নিশ্চিত করতে পারবেন যে আপনার MCP ইমপ্লিমেন্টেশন গুণমান, নির্ভরযোগ্যতা এবং পারফরম্যান্সের সর্বোচ্চ মান পূরণ করে।  

## মূল বিষয়সমূহ

1. **টুল ডিজাইন**: একক দায়িত্ব নীতি অনুসরণ করুন, ডিপেনডেন্সি ইনজেকশন ব্যবহার করুন, এবং কম্পোজেবিলিটির জন্য ডিজাইন করুন  
2. **স্কিমা ডিজাইন**: স্পষ্ট, ভালো ডকুমেন্টেড স্কিমা তৈরি করুন যথাযথ যাচাই সীমাবদ্ধতা সহ  
3. **এরর হ্যান্ডলিং**: সুন্দর এরর হ্যান্ডলিং, কাঠামোবদ্ধ এরর রেসপন্স এবং রিট্রাই লজিক বাস্তবায়ন করুন  
4. **পারফরম্যান্স**: ক্যাশিং, অ্যাসিঙ্ক্রোনাস প্রসেসিং এবং রিসোর্স থ্রটলিং ব্যবহার করুন  
5. **সিকিউরিটি**: সম্পূর্ণ ইনপুট যাচাই, অথরাইজেশন চেক এবং সংবেদনশীল ডেটা হ্যান্ডলিং প্রয়োগ করুন  
6. **টেস্টিং**: ব্যাপক ইউনিট, ইন্টিগ্রেশন এবং এন্ড-টু-এন্ড টেস্ট তৈরি করুন  
7. **ওয়ার্কফ্লো প্যাটার্ন**: চেইন, ডিসপ্যাচার এবং প্যারালাল প্রসেসিংয়ের মতো প্রতিষ্ঠিত প্যাটার্ন প্রয়োগ করুন  

## অনুশীলন

একটি MCP টুল এবং ওয়ার্কফ্লো ডিজাইন করুন যা একটি ডকুমেন্ট প্রসেসিং সিস্টেমের জন্য:

1. একাধিক ফরম্যাটে (PDF, DOCX, TXT) ডকুমেন্ট গ্রহণ করে  
2. ডকুমেন্ট থেকে টেক্সট এবং মূল তথ্য বের করে  
3. ডকুমেন্টকে টাইপ এবং বিষয়বস্তু অনুযায়ী শ্রেণীবদ্ধ করে  
4. প্রতিটি ডকুমেন্টের সারাংশ তৈরি করে  

এই পরিস্থিতির জন্য টুল স্কিমা, এরর হ্যান্ডলিং এবং একটি উপযুক্ত ওয়ার্কফ্লো প্যাটার্ন বাস্তবায়ন করুন। কিভাবে আপনি এই ইমপ্লিমেন্টেশন পরীক্ষা করবেন তা বিবেচনা করুন।  

## রিসোর্স

1. সর্বশেষ উন্নয়নের জন্য MCP কমিউনিটিতে যোগ দিন [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs)  
2. ওপেন-সোর্স [MCP প্রকল্পে](https://github.com/modelcontextprotocol) অবদান রাখুন  
3. আপনার প্রতিষ্ঠানের AI উদ্যোগে MCP নীতিমালা প্রয়োগ করুন  
4. আপনার শিল্পের জন্য বিশেষায়িত MCP ইমপ্লিমেন্টেশন অন্বেষণ করুন  
5. মাল্টি-মোডাল ইন্টিগ্রেশন বা এন্টারপ্রাইজ অ্যাপ্লিকেশন ইন্টিগ্রেশনের মতো নির্দিষ্ট MCP বিষয়ের উন্নত কোর্স গ্রহণ বিবেচনা করুন  
6. [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) থেকে শেখা নীতিমালা ব্যবহার করে নিজস্ব MCP টুল এবং ওয়ার্কফ্লো তৈরি করে পরীক্ষা করুন  

পরবর্তী: সেরা অনুশীলন [কেস স্টাডি](../09-CaseStudy/README.md)

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায়ই কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ গ্রহণ করার পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।