<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "80e5c8949af5af0f401fce6f905990aa",
  "translation_date": "2025-07-17T05:56:02+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "th"
}
-->
# MCP Development Best Practices

## ภาพรวม

บทเรียนนี้เน้นไปที่แนวปฏิบัติที่ดีที่สุดขั้นสูงสำหรับการพัฒนา ทดสอบ และปรับใช้เซิร์ฟเวอร์และฟีเจอร์ MCP ในสภาพแวดล้อมการผลิต เมื่อระบบนิเวศ MCP มีความซับซ้อนและสำคัญมากขึ้น การปฏิบัติตามรูปแบบที่กำหนดไว้จะช่วยให้มั่นใจในความน่าเชื่อถือ การดูแลรักษา และความสามารถในการทำงานร่วมกัน บทเรียนนี้รวบรวมความรู้จากการใช้งาน MCP ในโลกจริงเพื่อแนะนำคุณในการสร้างเซิร์ฟเวอร์ที่แข็งแกร่ง มีประสิทธิภาพ พร้อมทรัพยากร คำสั่ง และเครื่องมือที่เหมาะสม

## วัตถุประสงค์การเรียนรู้

เมื่อจบบทเรียนนี้ คุณจะสามารถ:
- นำแนวปฏิบัติที่ดีที่สุดในอุตสาหกรรมมาใช้ในการออกแบบเซิร์ฟเวอร์และฟีเจอร์ MCP
- สร้างกลยุทธ์การทดสอบที่ครอบคลุมสำหรับเซิร์ฟเวอร์ MCP
- ออกแบบรูปแบบเวิร์กโฟลว์ที่มีประสิทธิภาพและนำกลับมาใช้ใหม่ได้สำหรับแอปพลิเคชัน MCP ที่ซับซ้อน
- นำการจัดการข้อผิดพลาด การบันทึก และการสังเกตการณ์ที่เหมาะสมมาใช้ในเซิร์ฟเวอร์ MCP
- ปรับแต่งการใช้งาน MCP ให้เหมาะสมกับประสิทธิภาพ ความปลอดภัย และการดูแลรักษา

## หลักการสำคัญของ MCP

ก่อนที่จะลงลึกในแนวปฏิบัติการใช้งานเฉพาะ ควรเข้าใจหลักการสำคัญที่ชี้นำการพัฒนา MCP อย่างมีประสิทธิภาพ:

1. **การสื่อสารที่เป็นมาตรฐาน**: MCP ใช้ JSON-RPC 2.0 เป็นพื้นฐาน ซึ่งให้รูปแบบที่สม่ำเสมอสำหรับคำขอ การตอบกลับ และการจัดการข้อผิดพลาดในทุกการใช้งาน

2. **การออกแบบที่เน้นผู้ใช้เป็นศูนย์กลาง**: ให้ความสำคัญกับความยินยอมของผู้ใช้ การควบคุม และความโปร่งใสในการใช้งาน MCP ของคุณเสมอ

3. **ความปลอดภัยเป็นอันดับแรก**: นำมาตรการความปลอดภัยที่แข็งแกร่งมาใช้ รวมถึงการตรวจสอบตัวตน การอนุญาต การตรวจสอบความถูกต้อง และการจำกัดอัตราการใช้งาน

4. **สถาปัตยกรรมแบบโมดูลาร์**: ออกแบบเซิร์ฟเวอร์ MCP ด้วยแนวทางแบบโมดูลาร์ โดยที่แต่ละเครื่องมือและทรัพยากรมีวัตถุประสงค์ที่ชัดเจนและมุ่งเน้น

5. **การเชื่อมต่อที่มีสถานะ**: ใช้ประโยชน์จากความสามารถของ MCP ในการรักษาสถานะระหว่างคำขอหลายรายการ เพื่อการโต้ตอบที่สอดคล้องและมีบริบทมากขึ้น

## แนวปฏิบัติที่ดีที่สุดอย่างเป็นทางการของ MCP

แนวปฏิบัติที่ดีที่สุดต่อไปนี้มาจากเอกสาร Model Context Protocol อย่างเป็นทางการ:

### แนวปฏิบัติด้านความปลอดภัย

1. **ความยินยอมและการควบคุมของผู้ใช้**: ต้องได้รับความยินยอมจากผู้ใช้อย่างชัดเจนก่อนเข้าถึงข้อมูลหรือดำเนินการใด ๆ ให้ผู้ใช้ควบคุมได้อย่างชัดเจนว่าข้อมูลใดถูกแชร์และการกระทำใดได้รับอนุญาต

2. **ความเป็นส่วนตัวของข้อมูล**: เปิดเผยข้อมูลผู้ใช้เฉพาะเมื่อได้รับความยินยอมอย่างชัดเจน และปกป้องข้อมูลด้วยการควบคุมการเข้าถึงที่เหมาะสม ป้องกันการส่งข้อมูลโดยไม่ได้รับอนุญาต

3. **ความปลอดภัยของเครื่องมือ**: ต้องได้รับความยินยอมจากผู้ใช้อย่างชัดเจนก่อนเรียกใช้เครื่องมือใด ๆ ให้ผู้ใช้เข้าใจฟังก์ชันของแต่ละเครื่องมือและบังคับใช้ขอบเขตความปลอดภัยที่เข้มงวด

4. **การควบคุมสิทธิ์เครื่องมือ**: กำหนดว่าเครื่องมือใดที่โมเดลสามารถใช้ได้ในระหว่างเซสชัน เพื่อให้เข้าถึงเฉพาะเครื่องมือที่ได้รับอนุญาตอย่างชัดเจนเท่านั้น

5. **การตรวจสอบตัวตน**: ต้องมีการตรวจสอบตัวตนที่เหมาะสมก่อนให้สิทธิ์เข้าถึงเครื่องมือ ทรัพยากร หรือการดำเนินการที่ละเอียดอ่อน โดยใช้ API keys, OAuth tokens หรือวิธีการตรวจสอบตัวตนที่ปลอดภัยอื่น ๆ

6. **การตรวจสอบพารามิเตอร์**: บังคับใช้การตรวจสอบพารามิเตอร์สำหรับการเรียกใช้เครื่องมือทั้งหมด เพื่อป้องกันข้อมูลที่ผิดรูปแบบหรือเป็นอันตรายไม่ให้ถึงการใช้งานเครื่องมือ

7. **การจำกัดอัตราการใช้งาน**: นำการจำกัดอัตราการใช้งานมาใช้เพื่อป้องกันการใช้งานเกินขอบเขตและเพื่อให้การใช้ทรัพยากรเซิร์ฟเวอร์เป็นธรรม

### แนวปฏิบัติด้านการใช้งาน

1. **การเจรจาความสามารถ**: ในระหว่างการตั้งค่าการเชื่อมต่อ ให้แลกเปลี่ยนข้อมูลเกี่ยวกับฟีเจอร์ที่รองรับ เวอร์ชันโปรโตคอล เครื่องมือ และทรัพยากรที่มี

2. **การออกแบบเครื่องมือ**: สร้างเครื่องมือที่มุ่งเน้นทำงานอย่างใดอย่างหนึ่งได้ดี แทนที่จะสร้างเครื่องมือขนาดใหญ่ที่จัดการหลายเรื่องพร้อมกัน

3. **การจัดการข้อผิดพลาด**: นำข้อความและรหัสข้อผิดพลาดที่เป็นมาตรฐานมาใช้ เพื่อช่วยวินิจฉัยปัญหา จัดการความล้มเหลวอย่างเหมาะสม และให้ข้อเสนอแนะที่นำไปปฏิบัติได้

4. **การบันทึกข้อมูล**: กำหนดค่าการบันทึกแบบมีโครงสร้างเพื่อการตรวจสอบ การดีบัก และการติดตามการโต้ตอบของโปรโตคอล

5. **การติดตามความคืบหน้า**: สำหรับการดำเนินการที่ใช้เวลานาน ให้รายงานความคืบหน้าเพื่อสนับสนุนอินเทอร์เฟซผู้ใช้ที่ตอบสนองได้ดี

6. **การยกเลิกคำขอ**: อนุญาตให้ไคลเอนต์ยกเลิกคำขอที่กำลังดำเนินการอยู่ซึ่งไม่จำเป็นหรือใช้เวลานานเกินไป

## เอกสารอ้างอิงเพิ่มเติม

สำหรับข้อมูลล่าสุดเกี่ยวกับแนวปฏิบัติที่ดีที่สุดของ MCP โปรดดูที่:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)
- [Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## ตัวอย่างการใช้งานจริง

### แนวปฏิบัติการออกแบบเครื่องมือ

#### 1. หลักการความรับผิดชอบเดียว

เครื่องมือ MCP แต่ละตัวควรมีวัตถุประสงค์ที่ชัดเจนและมุ่งเน้น แทนที่จะสร้างเครื่องมือขนาดใหญ่ที่พยายามจัดการหลายเรื่อง ให้พัฒนาเครื่องมือเฉพาะทางที่ทำงานเฉพาะด้านได้อย่างยอดเยี่ยม

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

#### 2. การจัดการข้อผิดพลาดที่สม่ำเสมอ

นำการจัดการข้อผิดพลาดที่แข็งแกร่งมาใช้ พร้อมข้อความข้อผิดพลาดที่ให้ข้อมูลและกลไกการกู้คืนที่เหมาะสม

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

#### 3. การตรวจสอบพารามิเตอร์

ตรวจสอบพารามิเตอร์อย่างละเอียดเสมอเพื่อป้องกันข้อมูลที่ผิดรูปแบบหรือเป็นอันตราย

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

### ตัวอย่างการใช้งานด้านความปลอดภัย

#### 1. การตรวจสอบตัวตนและการอนุญาต

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

#### 2. การจำกัดอัตราการใช้งาน

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

## แนวปฏิบัติการทดสอบ

### 1. การทดสอบหน่วยของเครื่องมือ MCP

ทดสอบเครื่องมือของคุณแยกกันเสมอ โดยจำลองการพึ่งพาภายนอก:

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

### 2. การทดสอบแบบบูรณาการ

ทดสอบกระบวนการทั้งหมดตั้งแต่คำขอของไคลเอนต์จนถึงการตอบกลับของเซิร์ฟเวอร์:

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

## การปรับแต่งประสิทธิภาพ

### 1. กลยุทธ์การแคช

นำกลยุทธ์การแคชที่เหมาะสมมาใช้เพื่อลดความหน่วงและการใช้ทรัพยากร:

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
// ตัวอย่าง Java พร้อมการฉีดพึ่งพา
public class CurrencyConversionTool implements Tool {
    private final ExchangeRateService exchangeService;
    private final CacheService cacheService;
    private final Logger logger;
    
    // พึ่งพาถูกฉีดผ่านคอนสตรัคเตอร์
    public CurrencyConversionTool(
            ExchangeRateService exchangeService,
            CacheService cacheService,
            Logger logger) {
        this.exchangeService = exchangeService;
        this.cacheService = cacheService;
        this.logger = logger;
    }
    
    // การใช้งานเครื่องมือ
    // ...
}
```

#### 3. Composable Tools

Design tools that can be composed together to create more complex workflows:

```python
# ตัวอย่าง Python แสดงเครื่องมือที่ประกอบกันได้
class DataFetchTool(Tool):
    def get_name(self):
        return "dataFetch"
    
    # การใช้งาน...

class DataAnalysisTool(Tool):
    def get_name(self):
        return "dataAnalysis"
    
    # เครื่องมือนี้สามารถใช้ผลลัพธ์จาก dataFetch ได้
    async def execute_async(self, request):
        # การใช้งาน...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # เครื่องมือนี้สามารถใช้ผลลัพธ์จาก dataAnalysis ได้
    async def execute_async(self, request):
        # การใช้งาน...
        pass

# เครื่องมือเหล่านี้สามารถใช้แยกกันหรือเป็นส่วนหนึ่งของเวิร์กโฟลว์
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
                description = "ข้อความค้นหา ใช้คำสำคัญที่แม่นยำเพื่อผลลัพธ์ที่ดีกว่า" 
            },
            filters = new {
                type = "object",
                description = "ตัวกรองเสริมเพื่อจำกัดผลลัพธ์การค้นหา",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "ช่วงวันที่ในรูปแบบ YYYY-MM-DD:YYYY-MM-DD" 
                    },
                    category = new { 
                        type = "string", 
                        description = "ชื่อหมวดหมู่สำหรับกรอง" 
                    }
                }
            },
            limit = new { 
                type = "integer", 
                description = "จำนวนผลลัพธ์สูงสุดที่ต้องการ (1-50)",
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
    
    // คุณสมบัติอีเมลพร้อมการตรวจสอบรูปแบบ
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "ที่อยู่อีเมลของผู้ใช้");
    
    // คุณสมบัติอายุพร้อมข้อจำกัดเชิงตัวเลข
    Map<String, Object> age = new HashMap<>();
    age.put("type", "integer");
    age.put("minimum", 13);
    age.put("maximum", 120);
    age.put("description", "อายุของผู้ใช้เป็นปี");
    
    // คุณสมบัติแบบระบุค่าได้
    Map<String, Object> subscription = new HashMap<>();
    subscription.put("type", "string");
    subscription.put("enum", Arrays.asList("free", "basic", "premium"));
    subscription.put("default", "free");
    subscription.put("description", "ระดับการสมัครสมาชิก");
    
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
        # ประมวลผลคำขอ
        results = await self._search_database(request.parameters["query"])
        
        # ส่งคืนโครงสร้างที่สม่ำเสมอเสมอ
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
    """รับประกันว่าแต่ละรายการมีโครงสร้างที่สม่ำเสมอ"""
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
            throw new ToolExecutionException($"ไม่พบไฟล์: {fileId}");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ToolExecutionException("คุณไม่มีสิทธิ์เข้าถึงไฟล์นี้");
        }
        catch (Exception ex) when (ex is IOException || ex is TimeoutException)
        {
            _logger.LogError(ex, "เกิดข้อผิดพลาดในการเข้าถึงไฟล์ {FileId}", fileId);
            throw new ToolExecutionException("เกิดข้อผิดพลาดในการเข้าถึงไฟล์: บริการไม่พร้อมใช้งานชั่วคราว");
        }
    }
    catch (JsonException)
    {
        throw new ToolExecutionException("รูปแบบ ID ไฟล์ไม่ถูกต้อง");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "ข้อผิดพลาดที่ไม่คาดคิดใน FileAccessTool");
        throw new ToolExecutionException("เกิดข้อผิดพลาดที่ไม่คาดคิด");
    }
}
```

#### 2. Structured Error Responses

Return structured error information when possible:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    try {
        // การใช้งาน
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
        
        // โยนข้อยกเว้นอื่น ๆ ใหม่เป็น ToolExecutionException
        throw new ToolExecutionException("การทำงานของเครื่องมือไม่สำเร็จ: " + ex.getMessage(), ex);
    }
}
```

#### 3. Retry Logic

Implement appropriate retry logic for transient failures:

```python
async def execute_async(self, request):
    max_retries = 3
    retry_count = 0
    base_delay = 1  # วินาที
    
    while retry_count < max_retries:
        try:
            # เรียก API ภายนอก
            return await self._call_api(request.parameters)
        except TransientError as e:
            retry_count += 1
            if retry_count >= max_retries:
                raise ToolExecutionException(f"การดำเนินการล้มเหลวหลังจากพยายาม {max_retries} ครั้ง: {str(e)}")
                
            # การหน่วงเวลาย้อนกลับแบบทวีคูณ
            delay = base_delay * (2 ** (retry_count - 1))
            logging.warning(f"เกิดข้อผิดพลาดชั่วคราว กำลังลองใหม่ใน {delay} วินาที: {str(e)}")
            await asyncio.sleep(delay)
        except Exception as e:
            # ข้อผิดพลาดที่ไม่ใช่ชั่วคราว ไม่ต้องลองใหม่
            raise ToolExecutionException(f"การดำเนินการล้มเหลว: {str(e)}")
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
        
        // สร้างคีย์แคชจากพารามิเตอร์
        var cacheKey = $"data_query_{ComputeHash(query)}";
        
        // พยายามดึงข้อมูลจากแคชก่อน
        if (_cache.TryGetValue(cacheKey, out var cachedResult))
        {
            return new ToolResponse { Result = cachedResult };
        }
        
        // กรณีไม่เจอในแคช - ดำเนินการคิวรีจริง
        var result = await _database.QueryAsync(query);
        
        // เก็บข้อมูลในแคชพร้อมตั้งเวลาหมดอายุ
        var cacheOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
            
        _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
        
        return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
    }
    
    private string ComputeHash(string input)
    {
        // การทำงานเพื่อสร้างแฮชที่เสถียรสำหรับคีย์แคช
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
        
        // สำหรับงานที่ใช้เวลานาน ให้คืน process ID ทันที
        String processId = UUID.randomUUID().toString();
        
        // เริ่มการประมวลผลแบบอะซิงโครนัส
        CompletableFuture.runAsync(() -> {
            try {
                // ดำเนินการงานที่ใช้เวลานาน
                documentService.processDocument(documentId);
                
                // อัปเดตสถานะ (โดยปกติจะเก็บในฐานข้อมูล)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // ส่งคืนผลลัพธ์ทันทีพร้อม process ID
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // เครื่องมือตรวจสอบสถานะคู่ขนาน
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
            tokens_per_second=5,  # อนุญาต 5 คำขอต่อวินาที
            bucket_size=10        # อนุญาตให้ระเบิดคำขอได้สูงสุด 10 คำขอ
        )
    
    async def execute_async(self, request):
        # ตรวจสอบว่าสามารถดำเนินการต่อได้หรือจำเป็นต้องรอ
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # ถ้าต้องรอนานเกินไป
                raise ToolExecutionException(
                    f"เกินขีดจำกัดอัตราการใช้งาน กรุณาลองใหม่อีกครั้งใน {delay:.1f} วินาที"
                )
            else:
                # รอเวลาที่เหมาะสม
                await asyncio.sleep(delay)
        
        # ใช้โทเค็นและดำเนินการคำขอ
        self.rate_limiter.consume()
        
        # เรียก API
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
            
            # คำนวณเวลาจนกว่าโทเค็นถัดไปจะพร้อมใช้งาน
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # เติมโทเค็นใหม่ตามเวลาที่ผ่านไป
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
    // ตรวจสอบว่ามีพารามิเตอร์หรือไม่
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("พารามิเตอร์ที่จำเป็นหายไป: query");
    }
    
    // ตรวจสอบชนิดข้อมูลให้ถูกต้อง
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("พารามิเตอร์ query ต้องเป็นสตริง");
    }
    
    var query = queryProp.GetString();
    
    // ตรวจสอบเนื้อหาสตริง
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("พารามิเตอร์ query ไม่สามารถเว้นว่างได้");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("พารามิเตอร์ query ยาวเกิน 500 ตัวอักษร");
    }
    
    // ตรวจสอบการโจมตี SQL injection หากมีการใช้งาน
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("คำสั่ง query ไม่ถูกต้อง: มี SQL ที่อาจไม่ปลอดภัย");
    }
    
    // ดำเนินการต่อ
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // ดึงบริบทผู้ใช้จากคำขอ
    UserContext user = request.getContext().getUserContext();
    
    // ตรวจสอบว่าผู้ใช้มีสิทธิ์ที่จำเป็นหรือไม่
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("ผู้ใช้ไม่มีสิทธิ์เข้าถึงเอกสาร");
    }
    
    // สำหรับทรัพยากรเฉพาะ ให้ตรวจสอบการเข้าถึงทรัพยากรนั้น
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("ปฏิเสธการเข้าถึงเอกสารที่ร้องขอ");
    }
    
    // ดำเนินการเครื่องมือต่อ
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
        
        # ดึงข้อมูลผู้ใช้
        user_data = await self.user_service.get_user_data(user_id)
        
        # กรองข้อมูลที่ละเอียดอ่อน เว้นแต่จะร้องขอและได้รับอนุญาตอย่างชัดเจน
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # ตรวจสอบระดับสิทธิ์ในบริบทคำขอ
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # สร้างสำเนาเพื่อไม่แก้ไขต้นฉบับ
        redacted = user_data.copy()
        
        # ลบข้อมูลที่ละเอียดอ่อนบางรายการ
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # ลบข้อมูลละเอียดอ่อนที่ซ้อนอยู่
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
    // จัดเตรียม
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("Seattle", 3))
        .ReturnsAsync(new WeatherForecast(/* ข้อมูลทดสอบ */));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "Seattle", 
            days = 3 
        })
    );
    
    // ดำเนินการ
    var response = await tool.ExecuteAsync(request);
    
    // ตรวจสอบผลลัพธ์
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // จัดเตรียม
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("InvalidLocation", It.IsAny<int>()))
        .ThrowsAsync(new LocationNotFoundException("ไม่พบสถานที่"));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "InvalidLocation", 
            days = 3 
        })
    );
    
    // ดำเนินการและตรวจสอบข้อยกเว้น
    var exception = await Assert.ThrowsAsync<ToolExecutionException>(
        () => tool.ExecuteAsync(request)
    );
    
    Assert.Contains("ไม่พบสถานที่", exception.Message);
}
```

#### 2. Schema Validation Testing

Test that schemas are valid and properly enforce constraints:

```java
@Test
public void testSchemaValidation() {
    // สร้างอินสแตนซ์ของเครื่องมือ
    SearchTool searchTool = new SearchTool();
    
    // ดึง schema
    Object schema = searchTool.getSchema();
    
    // แปลง schema เป็น JSON สำหรับตรวจสอบ
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // ตรวจสอบว่า schema เป็น JSONSchema ที่ถูกต้อง
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // ทดสอบพารามิเตอร์ที่ถูกต้อง
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // ทดสอบกรณีขาดพารามิเตอร์ที่จำเป็น
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // ทดสอบกรณีชนิดพารามิเตอร์ไม่ถูกต้อง
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
    # จัดเตรียม
    tool = ApiTool(timeout=0.1)  # ตั้งเวลา timeout สั้นมาก
    
    # จำลองคำขอที่จะ timeout
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # นานกว่าระยะ timeout
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # ดำเนินการและตรวจสอบข้อยกเว้น
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # ตรวจสอบข้อความข้อผิดพลาด
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # จัดเตรียม
    tool = ApiTool()
    
    # จำลองการตอบกลับที่ถูกจำกัดอัตรา
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
        
        # ดำเนินการและตรวจสอบข้อยกเว้น
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # ตรวจสอบข้อความข้อผิดพลาดเกี่ยวกับการจำกัดอัตรา
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
    // จัดเตรียม
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // ดำเนินการ
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

// ตรวจสอบผลลัพธ์
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
        // ทดสอบ endpoint สำหรับค้นหาเครื่องมือ
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // สร้างคำขอเครื่องมือ
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // ส่งคำขอและตรวจสอบการตอบกลับ
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // สร้างคำขอเครื่องมือที่ไม่ถูกต้อง
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // ขาดพารามิเตอร์ "b"
        request.put("parameters", parameters);
        
        // ส่งคำขอและตรวจสอบการตอบกลับข้อผิดพลาด
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
    # จัดเตรียม - ตั้งค่า MCP client และโมเดลจำลอง
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # ตอบกลับของโมเดลจำลอง
    mock_model = MockLanguageModel([
        MockResponse(
            "สภาพอากาศที่ Seattle เป็นอย่างไร?",
            tool_calls=[{
                "tool_name": "weatherForecast",
                "parameters": {"location": "Seattle", "days": 3}
            }]
        ),
        MockResponse(
            "นี่คือพยากรณ์อากาศสำหรับ Seattle:\n- วันนี้: 65°F, มีเมฆบางส่วน\n- พรุ่งนี้: 68°F, อากาศแจ่มใส\n- วันถัดไป: 62°F, ฝนตก",
            tool_calls=[]
        )
    ])
    
    # ตอบกลับของเครื่องมือพยากรณ์อากาศจำลอง
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
        
        # ดำเนินการ
        response = await mcp_client.send_prompt(
            "สภาพอากาศที่ Seattle เป็นอย่างไร?",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # ตรวจสอบ
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
    // จัดเตรียม
    var server = new McpServer(
        name: "TestServer",
        version: "1.0",
        maxConcurrentRequests: 100
    );
    
    server.RegisterTool(new FastExecutingTool());
    await server.StartAsync();
    
    var client = new McpClient("http://localhost:5000");
    
    // ดำเนินการ
    var tasks = new List<Task<McpResponse>>();
    for (int i = 0; i < 1000; i++)
    {
        tasks.Add(client.ExecuteToolAsync("fastTool", new { iteration = i }));
    }
    
    var results = await Task.WhenAll(tasks);
    
    // ตรวจสอบ
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
    
    // ตั้งค่า JMeter สำหรับการทดสอบความทนทาน
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // กำหนดแผนการทดสอบ JMeter
    HashTree testPlanTree = new HashTree();
    
    // สร้างแผนการทดสอบ, กลุ่มเธรด, ตัวสุ่ม ฯลฯ
    TestPlan testPlan = new TestPlan("MCP Server Stress Test");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // เพิ่ม HTTP sampler สำหรับการเรียกใช้เครื่องมือ
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // เพิ่ม listeners
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // เริ่มการทดสอบ
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // ตรวจสอบผลลัพธ์
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // เวลาตอบสนองเฉลี่ย < 200ms
    assertTrue(summaryReport.getPercentile(90.0) < 500); // 90th percentile < 500ms
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# กำหนดค่าการมอนิเตอร์สำหรับ MCP server
def configure_monitoring(server):
    # ตั้งค่า metrics ของ Prometheus
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "จำนวนคำขอ MCP ทั้งหมด"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "ระยะเวลาคำขอเป็นวินาที",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "จำนวนครั้งที่เครื่องมือถูกเรียกใช้",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "ระยะเวลาการทำงานของเครื่องมือเป็นวินาที",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "ข้อผิดพลาดในการทำงานของเครื่องมือ",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # เพิ่ม middleware สำหรับจับเวลาและบันทึก metrics
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # เปิดเผย endpoint สำหรับ metrics
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
# การใช้งาน Chain of Tools ใน Python
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # รายชื่อเครื่องมือที่จะเรียกใช้ตามลำดับ
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # เรียกใช้แต่ละเครื่องมือในลำดับ โดยส่งผลลัพธ์ก่อนหน้าเป็นอินพุต
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # เก็บผลลัพธ์และใช้เป็นอินพุตสำหรับเครื่องมือต่อไป
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# ตัวอย่างการใช้งาน
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
    public string Description => "ประมวลผลเนื้อหาหลากหลายประเภท";
    
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
        
        // กำหนดเครื่องมือเฉพาะทางที่จะใช้
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // ส่งต่อไปยังเครื่องมือเฉพาะทาง
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
1. หลีกเลี่ยงการใส่ '''markdown หรือแท็กอื่น ๆ รอบ ๆ การแปล
2. ให้แปลโดยไม่ให้ความหมายดูตรงตัวเกินไป
3. แปลความคิดเห็นด้วย
4. ไฟล์นี้เขียนในรูปแบบ Markdown - อย่าปฏิบัติกับไฟล์นี้เหมือน XML หรือ HTML
5. ห้ามแปล:
   - [!NOTE], [!WARNING], [!TIP], [!IMPORTANT], [!CAUTION]
   - ชื่อของตัวแปร, ฟังก์ชัน, คลาส
   - ตัวแทนที่เช่น @@INLINE_CODE_x@@ หรือ @@CODE_BLOCK_x@@
   - URL หรือเส้นทาง
6. รักษารูปแบบ Markdown เดิมทั้งหมดไว้
7. ส่งกลับเฉพาะเนื้อหาที่แปลแล้วโดยไม่มีแท็กหรือเครื่องหมายเพิ่มเติมใด ๆ
โปรดเขียนผลลัพธ์จากซ้ายไปขวา

> "csvProcessor",
("code", _) => "codeAnalyzer",
_ => throw new ToolExecutionException($"ไม่มีเครื่องมือสำหรับ {contentType}/{operation}")
};
}

private object GetOptionsForTool(string toolName, string operation)
{
// คืนค่า options ที่เหมาะสมสำหรับแต่ละเครื่องมือเฉพาะทาง
return toolName switch
{
"textSummarizer" => new { length = "medium" },
"htmlProcessor" => new { cleanUp = true, operation },
// ตัวเลือกสำหรับเครื่องมืออื่นๆ...
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
// ขั้นตอนที่ 1: ดึงข้อมูลเมตาของชุดข้อมูล (แบบซิงโครนัส)
ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata", 
Map.of("datasetId", datasetId));

// ขั้นตอนที่ 2: เริ่มการวิเคราะห์หลายรายการพร้อมกัน
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

// รอให้ทุกงานที่ทำพร้อมกันเสร็จสิ้น
CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
statisticalAnalysis, correlationAnalysis, outlierDetection
);

allAnalyses.join();  // รอจนเสร็จ

// ขั้นตอนที่ 3: รวมผลลัพธ์
Map<String, Object> combinedResults = new HashMap<>();
combinedResults.put("metadata", metadataResponse.getResult());
combinedResults.put("statistics", statisticalAnalysis.join().getResult());
combinedResults.put("correlations", correlationAnalysis.join().getResult());
combinedResults.put("outliers", outlierDetection.join().getResult());

// ขั้นตอนที่ 4: สร้างรายงานสรุป
ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator", 
Map.of("analysisResults", combinedResults));

// คืนค่าผลลัพธ์ของ workflow ทั้งหมด
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
# ลองใช้เครื่องมือหลักก่อน
response = await self.client.execute_tool(primary_tool, parameters)
return {
"result": response.result,
"source": "primary",
"tool": primary_tool
}
except ToolExecutionException as e:
# บันทึกการล้มเหลว
logging.warning(f"เครื่องมือหลัก '{primary_tool}' ล้มเหลว: {str(e)}")

# ใช้เครื่องมือสำรองแทน
try:
# อาจต้องแปลงพารามิเตอร์สำหรับเครื่องมือสำรอง
fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)

response = await self.client.execute_tool(fallback_tool, fallback_params)
return {
"result": response.result,
"source": "fallback",
"tool": fallback_tool,
"primaryError": str(e)
}
except ToolExecutionException as fallback_error:
# เครื่องมือทั้งสองล้มเหลว
logging.error(f"เครื่องมือหลักและสำรองล้มเหลวทั้งคู่ ข้อผิดพลาดของสำรอง: {str(fallback_error)}")
raise WorkflowExecutionException(
f"Workflow ล้มเหลว: ข้อผิดพลาดหลัก: {str(e)}; ข้อผิดพลาดสำรอง: {str(fallback_error)}"
)

def _adapt_parameters(self, params, from_tool, to_tool):
"""ปรับพารามิเตอร์ระหว่างเครื่องมือต่างๆ หากจำเป็น"""
# การทำงานนี้ขึ้นอยู่กับเครื่องมือเฉพาะ
# ในตัวอย่างนี้จะคืนค่าพารามิเตอร์เดิม
return params

# ตัวอย่างการใช้งาน
async def get_weather(workflow, location):
return await workflow.execute_with_fallback(
"premiumWeatherService",  # API สภาพอากาศหลัก (จ่ายเงิน)
"basicWeatherService",    # API สำรอง (ฟรี)
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

// เก็บผลลัพธ์ของแต่ละ workflow
results[workflow.Name] = workflowResult;

// อัปเดต context ด้วยผลลัพธ์สำหรับ workflow ถัดไป
context = context.WithResult(workflow.Name, workflowResult);
}

return new WorkflowResult(results);
}

public string Name => "CompositeWorkflow";
public string Description => "ดำเนินการ workflow หลายรายการตามลำดับ";
}

// ตัวอย่างการใช้งาน
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
// ตัวอย่าง unit test สำหรับเครื่องมือ calculator ใน C#
[Fact]
public async Task CalculatorTool_Add_ReturnsCorrectSum()
{
// จัดเตรียม
var calculator = new CalculatorTool();
var parameters = new Dictionary<string, object>
{
["operation"] = "add",
["a"] = 5,
["b"] = 7
};

// ดำเนินการ
var response = await calculator.ExecuteAsync(parameters);
var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());

// ตรวจสอบ
Assert.Equal(12, result.Value);
}
```

```python
# ตัวอย่าง unit test สำหรับเครื่องมือ calculator ใน Python
def test_calculator_tool_add():
# จัดเตรียม
calculator = CalculatorTool()
parameters = {
"operation": "add",
"a": 5,
"b": 7
}

# ดำเนินการ
response = calculator.execute(parameters)
result = json.loads(response.content[0].text)

# ตรวจสอบ
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
// ตัวอย่าง integration test สำหรับ MCP server ใน C#
[Fact]
public async Task Server_ProcessToolRequest_ReturnsValidResponse()
{
// จัดเตรียม
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

// ดำเนินการ
var response = await server.ProcessRequestAsync(request);

// ตรวจสอบ
Assert.NotNull(response);
Assert.Equal(McpStatusCodes.Success, response.StatusCode);
// ตรวจสอบเพิ่มเติมสำหรับเนื้อหาการตอบกลับ

// ทำความสะอาด
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
// ตัวอย่าง E2E test กับ client ใน TypeScript
describe('MCP Server E2E Tests', () => {
let client: McpClient;

beforeAll(async () => {
// เริ่มเซิร์ฟเวอร์ในสภาพแวดล้อมทดสอบ
await startTestServer();
client = new McpClient('http://localhost:5000');
});

afterAll(async () => {
await stopTestServer();
});

test('Client สามารถเรียกใช้เครื่องมือ calculator และได้ผลลัพธ์ที่ถูกต้อง', async () => {
// ดำเนินการ
const response = await client.invokeToolAsync('calculator', {
operation: 'divide',
a: 20,
b: 4
});

// ตรวจสอบ
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
// ตัวอย่าง C# กับ Moq
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
# ตัวอย่าง Python กับ unittest.mock
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
# กำหนดค่า mock
mock_model.return_value.generate_response.return_value = {
"text": "Mocked model response",
"finish_reason": "completed"
}

# ใช้ mock ในการทดสอบ
server = McpServer(model_client=mock_model)
# ดำเนินการทดสอบต่อ
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
// สคริปต์ k6 สำหรับทดสอบโหลด MCP server
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
vus: 10,  // ผู้ใช้เสมือน 10 คน
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
// จัดเตรียม
var client = new HttpClient();
client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");

// ดำเนินการ
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
    // การตรวจสอบ schema เพิ่มเติม
});
}
```

## 10 เคล็ดลับสำคัญสำหรับการทดสอบ MCP Server อย่างมีประสิทธิภาพ

1. **ทดสอบการกำหนดเครื่องมือแยกกัน**: ตรวจสอบการกำหนด schema แยกจากตรรกะของเครื่องมือ
2. **ใช้การทดสอบแบบพารามิเตอร์**: ทดสอบเครื่องมือด้วยข้อมูลหลากหลาย รวมถึงกรณีขอบเขต
3. **ตรวจสอบการตอบกลับข้อผิดพลาด**: ยืนยันการจัดการข้อผิดพลาดที่ถูกต้องในทุกสถานการณ์
4. **ทดสอบตรรกะการอนุญาต**: ตรวจสอบการควบคุมการเข้าถึงสำหรับบทบาทผู้ใช้ต่างๆ
5. **ติดตามความครอบคลุมของการทดสอบ**: มุ่งเน้นให้ครอบคลุมโค้ดในเส้นทางสำคัญสูงสุด
6. **ทดสอบการตอบกลับแบบสตรีมมิ่ง**: ยืนยันการจัดการเนื้อหาสตรีมมิ่งอย่างถูกต้อง
7. **จำลองปัญหาเครือข่าย**: ทดสอบพฤติกรรมภายใต้เครือข่ายที่มีปัญหา
8. **ทดสอบขีดจำกัดทรัพยากร**: ตรวจสอบพฤติกรรมเมื่อถึงโควตาหรือขีดจำกัดอัตรา
9. **ทำการทดสอบถดถอยอัตโนมัติ**: สร้างชุดทดสอบที่รันทุกครั้งเมื่อมีการเปลี่ยนแปลงโค้ด
10. **จัดทำเอกสารกรณีทดสอบ**: รักษาเอกสารที่ชัดเจนเกี่ยวกับสถานการณ์ทดสอบ

## ข้อควรระวังในการทดสอบที่พบบ่อย

- **พึ่งพาการทดสอบเส้นทางที่สำเร็จมากเกินไป**: ต้องทดสอบกรณีข้อผิดพลาดอย่างละเอียด
- **ละเลยการทดสอบประสิทธิภาพ**: หาจุดคอขวดก่อนที่จะส่งผลกระทบต่อการใช้งานจริง
- **ทดสอบแยกส่วนอย่างเดียว**: ควรรวมการทดสอบหน่วย การทดสอบแบบบูรณาการ และการทดสอบแบบ end-to-end
- **ความครอบคลุม API ไม่สมบูรณ์**: ตรวจสอบให้แน่ใจว่าทดสอบทุก endpoint และฟีเจอร์
- **สภาพแวดล้อมทดสอบไม่สม่ำเสมอ**: ใช้ container เพื่อให้สภาพแวดล้อมทดสอบเหมือนกันทุกครั้ง

## สรุป

กลยุทธ์การทดสอบที่ครอบคลุมเป็นสิ่งจำเป็นสำหรับการพัฒนา MCP server ที่เชื่อถือได้และมีคุณภาพสูง ด้วยการนำแนวทางปฏิบัติที่ดีที่สุดและเคล็ดลับในคู่มือนี้ไปใช้ คุณจะมั่นใจได้ว่า MCP implementation ของคุณจะได้มาตรฐานสูงสุดในด้านคุณภาพ ความน่าเชื่อถือ และประสิทธิภาพ

## ประเด็นสำคัญที่ควรจดจำ

1. **การออกแบบเครื่องมือ**: ปฏิบัติตามหลักการความรับผิดชอบเดียว ใช้ dependency injection และออกแบบให้สามารถประกอบกันได้
2. **การออกแบบ schema**: สร้าง schema ที่ชัดเจน มีเอกสารครบถ้วน พร้อมข้อจำกัดการตรวจสอบที่เหมาะสม
3. **การจัดการข้อผิดพลาด**: ใช้การจัดการข้อผิดพลาดอย่างนุ่มนวล ตอบกลับข้อผิดพลาดในรูปแบบโครงสร้าง และมีตรรกะการลองใหม่
4. **ประสิทธิภาพ**: ใช้ caching, การประมวลผลแบบอะซิงโครนัส และการจำกัดทรัพยากร
5. **ความปลอดภัย**: ตรวจสอบข้อมูลนำเข้าอย่างละเอียด ตรวจสอบการอนุญาต และจัดการข้อมูลที่ละเอียดอ่อนอย่างเหมาะสม
6. **การทดสอบ**: สร้างชุดทดสอบหน่วย การทดสอบแบบบูรณาการ และการทดสอบแบบ end-to-end อย่างครบถ้วน
7. **รูปแบบการทำงาน**: ใช้รูปแบบที่ได้รับการยอมรับ เช่น chains, dispatchers และการประมวลผลแบบขนาน

## แบบฝึกหัด

ออกแบบเครื่องมือ MCP และ workflow สำหรับระบบประมวลผลเอกสารที่:

1. รับเอกสารในหลายรูปแบบ (PDF, DOCX, TXT)
2. ดึงข้อความและข้อมูลสำคัญจากเอกสาร
3. จัดประเภทเอกสารตามประเภทและเนื้อหา
4. สร้างสรุปของแต่ละเอกสาร

พัฒนา schema ของเครื่องมือ การจัดการข้อผิดพลาด และรูปแบบ workflow ที่เหมาะสมกับสถานการณ์นี้ พิจารณาวิธีการทดสอบ implementation นี้ด้วย

## แหล่งข้อมูล

1. เข้าร่วมชุมชน MCP ใน [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs) เพื่อรับข่าวสารล่าสุด
2. ร่วมพัฒนาโครงการ [MCP แบบโอเพนซอร์ส](https://github.com/modelcontextprotocol)
3. นำหลักการ MCP ไปใช้ในโครงการ AI ขององค์กรคุณ
4. สำรวจการใช้งาน MCP เฉพาะทางในอุตสาหกรรมของคุณ
5. พิจารณาเรียนคอร์สขั้นสูงเกี่ยวกับหัวข้อ MCP เฉพาะ เช่น การรวมข้อมูลหลายรูปแบบ หรือการรวมแอปพลิเคชันองค์กร
6. ทดลองสร้างเครื่องมือและ workflow MCP ของคุณเองโดยใช้หลักการที่เรียนรู้จาก [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

ถัดไป: แนวทางปฏิบัติที่ดีที่สุด [case studies](../09-CaseStudy/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้บริการแปลโดยผู้เชี่ยวชาญมนุษย์ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดใด ๆ ที่เกิดจากการใช้การแปลนี้