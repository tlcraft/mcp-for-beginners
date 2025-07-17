<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "80e5c8949af5af0f401fce6f905990aa",
  "translation_date": "2025-07-17T07:35:39+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "vi"
}
-->
# Thực Tiễn Phát Triển MCP Tốt Nhất

## Tổng Quan

Bài học này tập trung vào các thực tiễn nâng cao trong việc phát triển, kiểm thử và triển khai các máy chủ MCP và tính năng trong môi trường sản xuất. Khi hệ sinh thái MCP ngày càng phức tạp và quan trọng, việc tuân theo các mẫu đã được thiết lập giúp đảm bảo tính ổn định, dễ bảo trì và khả năng tương tác. Bài học này tổng hợp những kinh nghiệm thực tiễn từ các triển khai MCP thực tế để hướng dẫn bạn tạo ra các máy chủ mạnh mẽ, hiệu quả với tài nguyên, lời nhắc và công cụ phù hợp.

## Mục Tiêu Học Tập

Kết thúc bài học này, bạn sẽ có khả năng:
- Áp dụng các thực tiễn tốt nhất trong thiết kế máy chủ và tính năng MCP
- Tạo chiến lược kiểm thử toàn diện cho các máy chủ MCP
- Thiết kế các mẫu quy trình làm việc hiệu quả, có thể tái sử dụng cho các ứng dụng MCP phức tạp
- Triển khai xử lý lỗi, ghi nhật ký và quan sát đúng cách trong các máy chủ MCP
- Tối ưu hóa các triển khai MCP về hiệu suất, bảo mật và khả năng bảo trì

## Nguyên Tắc Cốt Lõi MCP

Trước khi đi sâu vào các thực tiễn triển khai cụ thể, điều quan trọng là hiểu các nguyên tắc cốt lõi hướng dẫn phát triển MCP hiệu quả:

1. **Giao Tiếp Chuẩn Hóa**: MCP sử dụng JSON-RPC 2.0 làm nền tảng, cung cấp định dạng nhất quán cho các yêu cầu, phản hồi và xử lý lỗi trên tất cả các triển khai.

2. **Thiết Kế Tập Trung Vào Người Dùng**: Luôn ưu tiên sự đồng ý, kiểm soát và minh bạch đối với người dùng trong các triển khai MCP của bạn.

3. **Bảo Mật Là Trên Hết**: Triển khai các biện pháp bảo mật mạnh mẽ bao gồm xác thực, phân quyền, xác thực dữ liệu và giới hạn tần suất.

4. **Kiến Trúc Mô-đun**: Thiết kế các máy chủ MCP theo hướng mô-đun, mỗi công cụ và tài nguyên có mục đích rõ ràng và tập trung.

5. **Kết Nối Có Trạng Thái**: Tận dụng khả năng của MCP trong việc duy trì trạng thái qua nhiều yêu cầu để tạo ra các tương tác mạch lạc và có ngữ cảnh.

## Thực Tiễn Tốt Nhất Chính Thức của MCP

Các thực tiễn tốt nhất sau đây được rút ra từ tài liệu chính thức của Model Context Protocol:

### Thực Tiễn Bảo Mật

1. **Sự Đồng Ý và Kiểm Soát của Người Dùng**: Luôn yêu cầu sự đồng ý rõ ràng của người dùng trước khi truy cập dữ liệu hoặc thực hiện các thao tác. Cung cấp quyền kiểm soát rõ ràng về dữ liệu được chia sẻ và các hành động được phép.

2. **Bảo Mật Dữ Liệu**: Chỉ tiết lộ dữ liệu người dùng khi có sự đồng ý rõ ràng và bảo vệ bằng các kiểm soát truy cập phù hợp. Ngăn chặn việc truyền dữ liệu trái phép.

3. **An Toàn Công Cụ**: Yêu cầu sự đồng ý rõ ràng của người dùng trước khi gọi bất kỳ công cụ nào. Đảm bảo người dùng hiểu chức năng của từng công cụ và thực thi các ranh giới bảo mật chặt chẽ.

4. **Kiểm Soát Quyền Công Cụ**: Cấu hình các công cụ mà mô hình được phép sử dụng trong phiên làm việc, đảm bảo chỉ những công cụ được phép mới có thể truy cập.

5. **Xác Thực**: Yêu cầu xác thực đúng cách trước khi cấp quyền truy cập công cụ, tài nguyên hoặc các thao tác nhạy cảm bằng API key, token OAuth hoặc các phương pháp xác thực an toàn khác.

6. **Xác Thực Tham Số**: Thực thi xác thực cho tất cả các lần gọi công cụ để ngăn chặn đầu vào bị sai định dạng hoặc độc hại đến các triển khai công cụ.

7. **Giới Hạn Tần Suất**: Triển khai giới hạn tần suất để ngăn chặn lạm dụng và đảm bảo sử dụng công bằng tài nguyên máy chủ.

### Thực Tiễn Triển Khai

1. **Đàm Phán Khả Năng**: Trong quá trình thiết lập kết nối, trao đổi thông tin về các tính năng được hỗ trợ, phiên bản giao thức, công cụ và tài nguyên có sẵn.

2. **Thiết Kế Công Cụ**: Tạo các công cụ tập trung làm tốt một việc, thay vì các công cụ đơn khối xử lý nhiều vấn đề cùng lúc.

3. **Xử Lý Lỗi**: Triển khai các thông báo lỗi và mã lỗi chuẩn hóa để giúp chẩn đoán sự cố, xử lý lỗi một cách nhẹ nhàng và cung cấp phản hồi có thể hành động.

4. **Ghi Nhật Ký**: Cấu hình các bản ghi có cấu trúc để kiểm toán, gỡ lỗi và giám sát các tương tác giao thức.

5. **Theo Dõi Tiến Độ**: Đối với các thao tác chạy lâu, báo cáo cập nhật tiến độ để hỗ trợ giao diện người dùng phản hồi nhanh.

6. **Hủy Yêu Cầu**: Cho phép khách hàng hủy các yêu cầu đang xử lý mà không còn cần thiết hoặc mất quá nhiều thời gian.

## Tham Khảo Bổ Sung

Để có thông tin cập nhật nhất về các thực tiễn tốt nhất MCP, tham khảo:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)
- [Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## Ví Dụ Triển Khai Thực Tế

### Thực Tiễn Thiết Kế Công Cụ

#### 1. Nguyên Tắc Trách Nhiệm Đơn Lẻ

Mỗi công cụ MCP nên có mục đích rõ ràng và tập trung. Thay vì tạo các công cụ đơn khối cố gắng xử lý nhiều vấn đề, hãy phát triển các công cụ chuyên biệt làm tốt các nhiệm vụ cụ thể.

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

#### 2. Xử Lý Lỗi Nhất Quán

Triển khai xử lý lỗi mạnh mẽ với các thông báo lỗi chi tiết và cơ chế phục hồi phù hợp.

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

#### 3. Xác Thực Tham Số

Luôn xác thực tham số kỹ lưỡng để ngăn chặn đầu vào bị sai định dạng hoặc độc hại.

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

### Ví Dụ Triển Khai Bảo Mật

#### 1. Xác Thực và Phân Quyền

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

#### 2. Giới Hạn Tần Suất

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

## Thực Tiễn Kiểm Thử

### 1. Kiểm Thử Đơn Vị Công Cụ MCP

Luôn kiểm thử công cụ của bạn một cách độc lập, giả lập các phụ thuộc bên ngoài:

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

### 2. Kiểm Thử Tích Hợp

Kiểm thử toàn bộ luồng từ yêu cầu của khách hàng đến phản hồi của máy chủ:

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

## Tối Ưu Hiệu Suất

### 1. Chiến Lược Bộ Nhớ Đệm

Triển khai bộ nhớ đệm phù hợp để giảm độ trễ và sử dụng tài nguyên:

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
// Ví dụ Java với dependency injection
public class CurrencyConversionTool implements Tool {
    private final ExchangeRateService exchangeService;
    private final CacheService cacheService;
    private final Logger logger;
    
    // Các phụ thuộc được tiêm qua constructor
    public CurrencyConversionTool(
            ExchangeRateService exchangeService,
            CacheService cacheService,
            Logger logger) {
        this.exchangeService = exchangeService;
        this.cacheService = cacheService;
        this.logger = logger;
    }
    
    // Triển khai công cụ
    // ...
}
```

#### 3. Composable Tools

Design tools that can be composed together to create more complex workflows:

```python
# Ví dụ Python thể hiện các công cụ có thể kết hợp
class DataFetchTool(Tool):
    def get_name(self):
        return "dataFetch"
    
    # Triển khai...

class DataAnalysisTool(Tool):
    def get_name(self):
        return "dataAnalysis"
    
    # Công cụ này có thể sử dụng kết quả từ dataFetch
    async def execute_async(self, request):
        # Triển khai...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # Công cụ này có thể sử dụng kết quả từ dataAnalysis
    async def execute_async(self, request):
        # Triển khai...
        pass

# Các công cụ này có thể dùng độc lập hoặc như một phần của quy trình làm việc
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
                description = "Văn bản truy vấn tìm kiếm. Sử dụng từ khóa chính xác để có kết quả tốt hơn." 
            },
            filters = new {
                type = "object",
                description = "Bộ lọc tùy chọn để thu hẹp kết quả tìm kiếm",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "Khoảng thời gian theo định dạng YYYY-MM-DD:YYYY-MM-DD" 
                    },
                    category = new { 
                        type = "string", 
                        description = "Tên danh mục để lọc" 
                    }
                }
            },
            limit = new { 
                type = "integer", 
                description = "Số lượng kết quả tối đa trả về (1-50)",
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
    
    // Thuộc tính email với xác thực định dạng
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "Địa chỉ email người dùng");
    
    // Thuộc tính tuổi với giới hạn số
    Map<String, Object> age = new HashMap<>();
    age.put("type", "integer");
    age.put("minimum", 13);
    age.put("maximum", 120);
    age.put("description", "Tuổi người dùng tính theo năm");
    
    // Thuộc tính liệt kê
    Map<String, Object> subscription = new HashMap<>();
    subscription.put("type", "string");
    subscription.put("enum", Arrays.asList("free", "basic", "premium"));
    subscription.put("default", "free");
    subscription.put("description", "Cấp độ đăng ký");
    
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
        # Xử lý yêu cầu
        results = await self._search_database(request.parameters["query"])
        
        # Luôn trả về cấu trúc nhất quán
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
    """Đảm bảo mỗi mục có cấu trúc nhất quán"""
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
            throw new ToolExecutionException($"Không tìm thấy tệp: {fileId}");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ToolExecutionException("Bạn không có quyền truy cập tệp này");
        }
        catch (Exception ex) when (ex is IOException || ex is TimeoutException)
        {
            _logger.LogError(ex, "Lỗi truy cập tệp {FileId}", fileId);
            throw new ToolExecutionException("Lỗi truy cập tệp: Dịch vụ tạm thời không khả dụng");
        }
    }
    catch (JsonException)
    {
        throw new ToolExecutionException("Định dạng ID tệp không hợp lệ");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Lỗi không mong muốn trong FileAccessTool");
        throw new ToolExecutionException("Đã xảy ra lỗi không mong muốn");
    }
}
```

#### 2. Structured Error Responses

Return structured error information when possible:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    try {
        // Triển khai
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
        
        // Ném lại các ngoại lệ khác dưới dạng ToolExecutionException
        throw new ToolExecutionException("Thực thi công cụ thất bại: " + ex.getMessage(), ex);
    }
}
```

#### 3. Retry Logic

Implement appropriate retry logic for transient failures:

```python
async def execute_async(self, request):
    max_retries = 3
    retry_count = 0
    base_delay = 1  # giây
    
    while retry_count < max_retries:
        try:
            # Gọi API bên ngoài
            return await self._call_api(request.parameters)
        except TransientError as e:
            retry_count += 1
            if retry_count >= max_retries:
                raise ToolExecutionException(f"Thao tác thất bại sau {max_retries} lần thử: {str(e)}")
                
            # Tăng thời gian chờ theo cấp số nhân
            delay = base_delay * (2 ** (retry_count - 1))
            logging.warning(f"Lỗi tạm thời, thử lại sau {delay}s: {str(e)}")
            await asyncio.sleep(delay)
        except Exception as e:
            # Lỗi không tạm thời, không thử lại
            raise ToolExecutionException(f"Thao tác thất bại: {str(e)}")
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
    
    // Tạo khóa cache dựa trên các tham số
    var cacheKey = $"data_query_{ComputeHash(query)}";
    
    // Thử lấy dữ liệu từ cache trước
    if (_cache.TryGetValue(cacheKey, out var cachedResult))
    {
        return new ToolResponse { Result = cachedResult };
    }
    
    // Cache không có - thực hiện truy vấn thực tế
    var result = await _database.QueryAsync(query);
    
    // Lưu vào cache với thời gian hết hạn
    var cacheOptions = new MemoryCacheEntryOptions()
        .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
        
    _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
    
    return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
}

private string ComputeHash(string input)
{
    // Cài đặt để tạo hash ổn định cho khóa cache
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
        
        // Với các thao tác chạy lâu, trả về ID xử lý ngay lập tức
        String processId = UUID.randomUUID().toString();
        
        // Bắt đầu xử lý bất đồng bộ
        CompletableFuture.runAsync(() -> {
            try {
                // Thực hiện thao tác chạy lâu
                documentService.processDocument(documentId);
                
                // Cập nhật trạng thái (thường được lưu trong cơ sở dữ liệu)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // Trả về phản hồi ngay với ID xử lý
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // Công cụ kiểm tra trạng thái đi kèm
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
            tokens_per_second=5,  # Cho phép 5 yêu cầu mỗi giây
            bucket_size=10        # Cho phép bùng phát tối đa 10 yêu cầu
        )
    
    async def execute_async(self, request):
        # Kiểm tra xem có thể tiếp tục hay phải chờ
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # Nếu thời gian chờ quá lâu
                raise ToolExecutionException(
                    f"Vượt quá giới hạn tốc độ. Vui lòng thử lại sau {delay:.1f} giây."
                )
            else:
                # Chờ đúng thời gian cần thiết
                await asyncio.sleep(delay)
        
        # Tiêu thụ một token và tiếp tục xử lý yêu cầu
        self.rate_limiter.consume()
        
        # Gọi API
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
            
            # Tính thời gian chờ đến khi có token tiếp theo
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # Thêm token mới dựa trên thời gian đã trôi qua
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
    // Kiểm tra tham số tồn tại
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("Thiếu tham số bắt buộc: query");
    }
    
    // Kiểm tra kiểu dữ liệu đúng
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("Tham số query phải là chuỗi");
    }
    
    var query = queryProp.GetString();
    
    // Kiểm tra nội dung chuỗi
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("Tham số query không được để trống");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("Tham số query vượt quá độ dài tối đa 500 ký tự");
    }
    
    // Kiểm tra tấn công SQL injection nếu có thể áp dụng
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("Truy vấn không hợp lệ: chứa SQL có thể gây nguy hiểm");
    }
    
    // Tiếp tục thực thi
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // Lấy ngữ cảnh người dùng từ request
    UserContext user = request.getContext().getUserContext();
    
    // Kiểm tra người dùng có quyền cần thiết không
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("Người dùng không có quyền truy cập tài liệu");
    }
    
    // Với tài nguyên cụ thể, kiểm tra quyền truy cập tài nguyên đó
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("Từ chối truy cập tài liệu yêu cầu");
    }
    
    // Tiếp tục thực thi công cụ
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
        
        # Lấy dữ liệu người dùng
        user_data = await self.user_service.get_user_data(user_id)
        
        # Lọc các trường nhạy cảm trừ khi được yêu cầu rõ ràng VÀ có quyền
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # Kiểm tra mức độ ủy quyền trong ngữ cảnh request
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # Tạo bản sao để tránh sửa đổi dữ liệu gốc
        redacted = user_data.copy()
        
        # Ẩn các trường nhạy cảm cụ thể
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # Ẩn dữ liệu nhạy cảm lồng nhau
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
    // Chuẩn bị
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("Seattle", 3))
        .ReturnsAsync(new WeatherForecast(/* dữ liệu test */));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "Seattle", 
            days = 3 
        })
    );
    
    // Thực thi
    var response = await tool.ExecuteAsync(request);
    
    // Kiểm tra
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // Chuẩn bị
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("InvalidLocation", It.IsAny<int>()))
        .ThrowsAsync(new LocationNotFoundException("Không tìm thấy vị trí"));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "InvalidLocation", 
            days = 3 
        })
    );
    
    // Thực thi & kiểm tra ngoại lệ
    var exception = await Assert.ThrowsAsync<ToolExecutionException>(
        () => tool.ExecuteAsync(request)
    );
    
    Assert.Contains("Không tìm thấy vị trí", exception.Message);
}
```

#### 2. Schema Validation Testing

Test that schemas are valid and properly enforce constraints:

```java
@Test
public void testSchemaValidation() {
    // Tạo instance công cụ
    SearchTool searchTool = new SearchTool();
    
    // Lấy schema
    Object schema = searchTool.getSchema();
    
    // Chuyển schema sang JSON để kiểm tra
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // Kiểm tra schema có phải JSONSchema hợp lệ
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // Kiểm tra tham số hợp lệ
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // Kiểm tra thiếu tham số bắt buộc
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // Kiểm tra kiểu tham số không hợp lệ
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
    # Chuẩn bị
    tool = ApiTool(timeout=0.1)  # Thời gian timeout rất ngắn
    
    # Giả lập một request bị timeout
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # Lâu hơn timeout
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # Thực thi & kiểm tra ngoại lệ
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Kiểm tra thông báo ngoại lệ
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # Chuẩn bị
    tool = ApiTool()
    
    # Giả lập phản hồi bị giới hạn tốc độ
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
        
        # Thực thi & kiểm tra ngoại lệ
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Kiểm tra ngoại lệ chứa thông tin giới hạn tốc độ
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
    // Chuẩn bị
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // Thực thi
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

// Kiểm tra
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
        // Kiểm tra endpoint khám phá công cụ
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // Tạo yêu cầu công cụ
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // Gửi yêu cầu và kiểm tra phản hồi
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // Tạo yêu cầu công cụ không hợp lệ
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // Thiếu tham số "b"
        request.put("parameters", parameters);
        
        // Gửi yêu cầu và kiểm tra phản hồi lỗi
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
    # Chuẩn bị - Thiết lập client MCP và mô hình giả lập
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # Mô phỏng phản hồi của mô hình
    mock_model = MockLanguageModel([
        MockResponse(
            "Thời tiết ở Seattle thế nào?",
            tool_calls=[{
                "tool_name": "weatherForecast",
                "parameters": {"location": "Seattle", "days": 3}
            }]
        ),
        MockResponse(
            "Dưới đây là dự báo thời tiết cho Seattle:\n- Hôm nay: 65°F, Trời có mây một phần\n- Ngày mai: 68°F, Trời nắng\n- Ngày kế tiếp: 62°F, Mưa",
            tool_calls=[]
        )
    ])
    
    # Mô phỏng phản hồi công cụ thời tiết
    with aioresponses() as mocked:
        mocked.post(
            "http://localhost:5000/mcp/execute",
            payload={
                "result": {
                    "location": "Seattle",
                    "forecast": [
                        {"date": "2023-06-01", "temperature": 65, "conditions": "Trời có mây một phần"},
                        {"date": "2023-06-02", "temperature": 68, "conditions": "Trời nắng"},
                        {"date": "2023-06-03", "temperature": 62, "conditions": "Mưa"}
                    ]
                }
            }
        )
        
        # Thực thi
        response = await mcp_client.send_prompt(
            "Thời tiết ở Seattle thế nào?",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # Kiểm tra
        assert "Seattle" in response.generated_text
        assert "65" in response.generated_text
        assert "Trời nắng" in response.generated_text
        assert "Mưa" in response.generated_text
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
    // Chuẩn bị
    var server = new McpServer(
        name: "TestServer",
        version: "1.0",
        maxConcurrentRequests: 100
    );
    
    server.RegisterTool(new FastExecutingTool());
    await server.StartAsync();
    
    var client = new McpClient("http://localhost:5000");
    
    // Thực thi
    var tasks = new List<Task<McpResponse>>();
    for (int i = 0; i < 1000; i++)
    {
        tasks.Add(client.ExecuteToolAsync("fastTool", new { iteration = i }));
    }
    
    var results = await Task.WhenAll(tasks);
    
    // Kiểm tra
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
    
    // Thiết lập JMeter để kiểm tra tải
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // Cấu hình kế hoạch kiểm tra JMeter
    HashTree testPlanTree = new HashTree();
    
    // Tạo kế hoạch kiểm tra, nhóm luồng, bộ lấy mẫu, v.v.
    TestPlan testPlan = new TestPlan("Kiểm tra tải MCP Server");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // Thêm bộ lấy mẫu HTTP cho việc thực thi công cụ
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // Thêm các bộ lắng nghe
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // Chạy kiểm tra
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // Xác nhận kết quả
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // Thời gian phản hồi trung bình < 200ms
    assertTrue(summaryReport.getPercentile(90.0) < 500); // Phần trăm 90 < 500ms
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# Cấu hình giám sát cho MCP server
def configure_monitoring(server):
    # Thiết lập các chỉ số Prometheus
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "Tổng số yêu cầu MCP"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "Thời gian xử lý yêu cầu tính bằng giây",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "Số lần thực thi công cụ",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "Thời gian thực thi công cụ tính bằng giây",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "Lỗi trong quá trình thực thi công cụ",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # Thêm middleware để đo thời gian và ghi lại các chỉ số
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # Mở endpoint để xuất các chỉ số
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
# Triển khai chuỗi công cụ trong Python
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # Danh sách tên công cụ sẽ thực thi theo thứ tự
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # Thực thi từng công cụ trong chuỗi, truyền kết quả trước đó làm đầu vào
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # Lưu kết quả và dùng làm đầu vào cho công cụ tiếp theo
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# Ví dụ sử dụng
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
    public string Description => "Xử lý nội dung các loại khác nhau";
    
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
        
        // Xác định công cụ chuyên biệt cần sử dụng
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // Chuyển tiếp đến công cụ chuyên biệt
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
QUY TẮC QUAN TRỌNG:
1. KHÔNG thêm '''markdown hoặc bất kỳ thẻ nào khác quanh bản dịch
2. Đảm bảo bản dịch không quá máy móc
3. Dịch cả phần chú thích
4. Tệp này được viết theo định dạng Markdown - không xử lý như XML hoặc HTML
5. Không dịch:
   - [!NOTE], [!WARNING], [!TIP], [!IMPORTANT], [!CAUTION]
   - Tên biến, tên hàm, tên lớp
   - Các chỗ giữ chỗ như @@INLINE_CODE_x@@ hoặc @@CODE_BLOCK_x@@
   - URL hoặc đường dẫn
6. Giữ nguyên tất cả định dạng markdown gốc
7. Chỉ trả về nội dung đã dịch mà không thêm thẻ hay định dạng nào khác
Vui lòng viết kết quả từ trái sang phải.
("code", _) => "codeAnalyzer",
_ => throw new ToolExecutionException($"Không có công cụ nào phù hợp cho {contentType}/{operation}")
};
}

private object GetOptionsForTool(string toolName, string operation)
{
// Trả về các tùy chọn phù hợp cho từng công cụ chuyên biệt
return toolName switch
{
    "textSummarizer" => new { length = "medium" },
    "htmlProcessor" => new { cleanUp = true, operation },
    // Tùy chọn cho các công cụ khác...
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
        // Bước 1: Lấy metadata của bộ dữ liệu (đồng bộ)
        ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata", 
            Map.of("datasetId", datasetId));
        
        // Bước 2: Khởi chạy nhiều phân tích song song
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
        
        // Chờ tất cả các tác vụ song song hoàn thành
        CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
            statisticalAnalysis, correlationAnalysis, outlierDetection
        );
        
        allAnalyses.join();  // Chờ hoàn tất
        
        // Bước 3: Kết hợp kết quả
        Map<String, Object> combinedResults = new HashMap<>();
        combinedResults.put("metadata", metadataResponse.getResult());
        combinedResults.put("statistics", statisticalAnalysis.join().getResult());
        combinedResults.put("correlations", correlationAnalysis.join().getResult());
        combinedResults.put("outliers", outlierDetection.join().getResult());
        
        // Bước 4: Tạo báo cáo tóm tắt
        ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator", 
            Map.of("analysisResults", combinedResults));
        
        // Trả về kết quả toàn bộ quy trình
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
            # Thử công cụ chính trước
            response = await self.client.execute_tool(primary_tool, parameters)
            return {
                "result": response.result,
                "source": "primary",
                "tool": primary_tool
            }
        except ToolExecutionException as e:
            # Ghi lại lỗi
            logging.warning(f"Công cụ chính '{primary_tool}' thất bại: {str(e)}")
            
            # Chuyển sang công cụ dự phòng
            try:
                # Có thể cần điều chỉnh tham số cho công cụ dự phòng
                fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)
                
                response = await self.client.execute_tool(fallback_tool, fallback_params)
                return {
                    "result": response.result,
                    "source": "fallback",
                    "tool": fallback_tool,
                    "primaryError": str(e)
                }
            except ToolExecutionException as fallback_error:
                # Cả hai công cụ đều thất bại
                logging.error(f"Cả công cụ chính và dự phòng đều thất bại. Lỗi dự phòng: {str(fallback_error)}")
                raise WorkflowExecutionException(
                    f"Quy trình thất bại: lỗi chính: {str(e)}; lỗi dự phòng: {str(fallback_error)}"
                )
    
    def _adapt_parameters(self, params, from_tool, to_tool):
        """Điều chỉnh tham số giữa các công cụ nếu cần"""
        # Cách thực hiện phụ thuộc vào từng công cụ cụ thể
        # Ở ví dụ này, chúng ta chỉ trả về tham số gốc
        return params

# Ví dụ sử dụng
async def get_weather(workflow, location):
    return await workflow.execute_with_fallback(
        "premiumWeatherService",  # API thời tiết chính (trả phí)
        "basicWeatherService",    # API thời tiết dự phòng (miễn phí)
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
            
            // Lưu kết quả của từng workflow
            results[workflow.Name] = workflowResult;
            
            // Cập nhật context với kết quả cho workflow tiếp theo
            context = context.WithResult(workflow.Name, workflowResult);
        }
        
        return new WorkflowResult(results);
    }
    
    public string Name => "CompositeWorkflow";
    public string Description => "Thực thi nhiều workflow theo thứ tự";
}

// Ví dụ sử dụng
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
// Ví dụ unit test cho công cụ calculator trong C#
[Fact]
public async Task CalculatorTool_Add_ReturnsCorrectSum()
{
    // Chuẩn bị
    var calculator = new CalculatorTool();
    var parameters = new Dictionary<string, object>
    {
        ["operation"] = "add",
        ["a"] = 5,
        ["b"] = 7
    };
    
    // Thực thi
    var response = await calculator.ExecuteAsync(parameters);
    var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());
    
    // Kiểm tra
    Assert.Equal(12, result.Value);
}
```

```python
# Ví dụ unit test cho công cụ calculator trong Python
def test_calculator_tool_add():
    # Chuẩn bị
    calculator = CalculatorTool()
    parameters = {
        "operation": "add",
        "a": 5,
        "b": 7
    }
    
    # Thực thi
    response = calculator.execute(parameters)
    result = json.loads(response.content[0].text)
    
    # Kiểm tra
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
// Ví dụ integration test cho server MCP trong C#
[Fact]
public async Task Server_ProcessToolRequest_ReturnsValidResponse()
{
    // Chuẩn bị
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
    
    // Thực thi
    var response = await server.ProcessRequestAsync(request);
    
    // Kiểm tra
    Assert.NotNull(response);
    Assert.Equal(McpStatusCodes.Success, response.StatusCode);
    // Các kiểm tra bổ sung cho nội dung phản hồi
    
    // Dọn dẹp
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
// Ví dụ E2E test với client trong TypeScript
describe('MCP Server E2E Tests', () => {
  let client: McpClient;
  
  beforeAll(async () => {
    // Khởi động server trong môi trường test
    await startTestServer();
    client = new McpClient('http://localhost:5000');
  });
  
  afterAll(async () => {
    await stopTestServer();
  });
  
  test('Client có thể gọi công cụ calculator và nhận kết quả đúng', async () => {
    // Thực thi
    const response = await client.invokeToolAsync('calculator', {
      operation: 'divide',
      a: 20,
      b: 4
    });
    
    // Kiểm tra
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
// Ví dụ C# với Moq
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
# Ví dụ Python với unittest.mock
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
    # Cấu hình mock
    mock_model.return_value.generate_response.return_value = {
        "text": "Mocked model response",
        "finish_reason": "completed"
    }
    
    # Sử dụng mock trong test
    server = McpServer(model_client=mock_model)
    # Tiếp tục với test
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
// k6 script để kiểm thử tải cho MCP server
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  vus: 10,  // 10 người dùng ảo
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
    'status là 200': (r) => r.status === 200,
    'thời gian phản hồi < 500ms': (r) => r.timings.duration < 500,
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
    
    - name: Thiết lập Runtime
      uses: actions/setup-dotnet@v1
      with:
        dotnet-version: '8.0.x'
    
    - name: Khôi phục phụ thuộc
      run: dotnet restore
    
    - name: Xây dựng
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
    // Chuẩn bị
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");
    
    // Thực thi
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
    // Kiểm tra thêm về schema
});
}
```

## 10 mẹo hàng đầu để kiểm thử MCP Server hiệu quả

1. **Kiểm thử định nghĩa công cụ riêng biệt**: Xác minh các định nghĩa schema độc lập với logic công cụ  
2. **Sử dụng kiểm thử tham số hóa**: Kiểm thử công cụ với nhiều đầu vào khác nhau, bao gồm cả các trường hợp biên  
3. **Kiểm tra phản hồi lỗi**: Đảm bảo xử lý lỗi đúng cho tất cả các điều kiện lỗi có thể xảy ra  
4. **Kiểm thử logic phân quyền**: Đảm bảo kiểm soát truy cập chính xác cho các vai trò người dùng khác nhau  
5. **Theo dõi độ bao phủ kiểm thử**: Hướng tới độ bao phủ cao cho các đoạn mã quan trọng  
6. **Kiểm thử phản hồi dạng streaming**: Xác minh xử lý đúng nội dung streaming  
7. **Mô phỏng sự cố mạng**: Kiểm thử hành vi khi mạng yếu hoặc không ổn định  
8. **Kiểm thử giới hạn tài nguyên**: Xác minh hành vi khi đạt đến hạn mức hoặc giới hạn tốc độ  
9. **Tự động hóa kiểm thử hồi quy**: Xây dựng bộ kiểm thử chạy tự động mỗi khi có thay đổi mã  
10. **Ghi chép các trường hợp kiểm thử**: Duy trì tài liệu rõ ràng về các kịch bản kiểm thử  

## Những sai lầm phổ biến khi kiểm thử

- **Quá phụ thuộc vào kiểm thử đường chính (happy path)**: Hãy chắc chắn kiểm thử kỹ các trường hợp lỗi  
- **Bỏ qua kiểm thử hiệu năng**: Phát hiện các điểm nghẽn trước khi ảnh hưởng đến môi trường sản xuất  
- **Chỉ kiểm thử riêng lẻ**: Kết hợp kiểm thử đơn vị, tích hợp và end-to-end  
- **Bao phủ API không đầy đủ**: Đảm bảo tất cả các endpoint và tính năng đều được kiểm thử  
- **Môi trường kiểm thử không đồng nhất**: Sử dụng container để đảm bảo môi trường kiểm thử nhất quán  

## Kết luận

Một chiến lược kiểm thử toàn diện là điều cần thiết để phát triển các MCP server đáng tin cậy và chất lượng cao. Bằng cách áp dụng các thực hành và mẹo tốt nhất được trình bày trong hướng dẫn này, bạn có thể đảm bảo các triển khai MCP của mình đạt tiêu chuẩn cao nhất về chất lượng, độ tin cậy và hiệu suất.

## Những điểm chính cần nhớ

1. **Thiết kế công cụ**: Tuân theo nguyên tắc trách nhiệm đơn, sử dụng dependency injection và thiết kế để dễ kết hợp  
2. **Thiết kế schema**: Tạo schema rõ ràng, có tài liệu đầy đủ và các ràng buộc xác thực hợp lý  
3. **Xử lý lỗi**: Triển khai xử lý lỗi mượt mà, phản hồi lỗi có cấu trúc và logic thử lại  
4. **Hiệu năng**: Sử dụng caching, xử lý bất đồng bộ và giới hạn tài nguyên  
5. **Bảo mật**: Áp dụng kiểm tra đầu vào kỹ lưỡng, kiểm tra phân quyền và xử lý dữ liệu nhạy cảm  
6. **Kiểm thử**: Tạo bộ kiểm thử đơn vị, tích hợp và end-to-end toàn diện  
7. **Mẫu quy trình làm việc**: Áp dụng các mẫu đã được chứng minh như chuỗi, bộ điều phối và xử lý song song  

## Bài tập

Thiết kế một công cụ MCP và quy trình làm việc cho hệ thống xử lý tài liệu mà:

1. Nhận tài liệu ở nhiều định dạng khác nhau (PDF, DOCX, TXT)  
2. Trích xuất văn bản và thông tin chính từ tài liệu  
3. Phân loại tài liệu theo loại và nội dung  
4. Tạo bản tóm tắt cho mỗi tài liệu  

Triển khai schema công cụ, xử lý lỗi và mẫu quy trình làm việc phù hợp nhất với kịch bản này. Hãy cân nhắc cách bạn sẽ kiểm thử triển khai này.

## Tài nguyên

1. Tham gia cộng đồng MCP trên [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs) để cập nhật các phát triển mới nhất  
2. Đóng góp vào các dự án mã nguồn mở [MCP projects](https://github.com/modelcontextprotocol)  
3. Áp dụng các nguyên tắc MCP trong các sáng kiến AI của tổ chức bạn  
4. Khám phá các triển khai MCP chuyên biệt cho ngành của bạn  
5. Cân nhắc tham gia các khóa học nâng cao về các chủ đề MCP cụ thể, như tích hợp đa phương thức hoặc tích hợp ứng dụng doanh nghiệp  
6. Thử nghiệm xây dựng công cụ và quy trình MCP của riêng bạn dựa trên các nguyên tắc học được qua [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)  

Tiếp theo: Các thực hành tốt nhất [case studies](../09-CaseStudy/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc của nó nên được coi là nguồn chính xác và đáng tin cậy. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.