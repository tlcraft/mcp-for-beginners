<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1827d0f7a6430dfb7adcdd5f1ee05bda",
  "translation_date": "2025-07-29T00:23:47+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "ko"
}
-->
# MCP 개발 모범 사례

[![MCP 개발 모범 사례](../../../translated_images/09.d0f6d86c9d72134ccf5a8d8c8650a0557e519936661fc894cad72d73522227cb.ko.png)](https://youtu.be/W56H9W7x-ao)

_(위 이미지를 클릭하면 이 강의의 동영상을 볼 수 있습니다)_

## 개요

이 강의는 MCP 서버와 기능을 프로덕션 환경에서 개발, 테스트, 배포할 때의 고급 모범 사례에 중점을 둡니다. MCP 생태계가 점점 더 복잡하고 중요해짐에 따라, 확립된 패턴을 따르는 것은 신뢰성, 유지보수성, 상호운용성을 보장하는 데 필수적입니다. 이 강의는 실제 MCP 구현에서 얻은 실질적인 지혜를 통합하여, 효율적이고 견고한 서버를 만들고 효과적인 리소스, 프롬프트, 도구를 활용하는 방법을 안내합니다.

## 학습 목표

이 강의를 마치면 다음을 수행할 수 있습니다:

- MCP 서버와 기능 설계에서 업계 모범 사례를 적용
- MCP 서버에 대한 포괄적인 테스트 전략 수립
- 복잡한 MCP 애플리케이션을 위한 효율적이고 재사용 가능한 워크플로 패턴 설계
- MCP 서버에서 적절한 오류 처리, 로깅, 관찰성 구현
- 성능, 보안, 유지보수성을 최적화한 MCP 구현

## MCP 핵심 원칙

구체적인 구현 사례를 살펴보기 전에, 효과적인 MCP 개발을 이끄는 핵심 원칙을 이해하는 것이 중요합니다:

1. **표준화된 통신**: MCP는 JSON-RPC 2.0을 기반으로 하며, 모든 구현에서 요청, 응답, 오류 처리를 위한 일관된 형식을 제공합니다.

2. **사용자 중심 설계**: MCP 구현에서 항상 사용자 동의, 제어, 투명성을 우선시하십시오.

3. **보안 우선**: 인증, 권한 부여, 유효성 검사, 속도 제한을 포함한 강력한 보안 조치를 구현하십시오.

4. **모듈형 아키텍처**: 각 도구와 리소스가 명확하고 집중된 목적을 가지도록 MCP 서버를 모듈형으로 설계하십시오.

5. **상태 유지 연결**: 여러 요청에 걸쳐 상태를 유지할 수 있는 MCP의 기능을 활용하여 더 일관되고 컨텍스트를 고려한 상호작용을 만드십시오.

## 공식 MCP 모범 사례

다음 모범 사례는 공식 Model Context Protocol 문서에서 파생되었습니다:

### 보안 모범 사례

1. **사용자 동의와 제어**: 데이터를 액세스하거나 작업을 수행하기 전에 항상 명시적인 사용자 동의를 요구하십시오. 공유되는 데이터와 승인된 작업에 대해 명확한 제어를 제공하십시오.

2. **데이터 프라이버시**: 명시적인 동의 없이 사용자 데이터를 노출하지 말고, 적절한 액세스 제어로 보호하십시오. 무단 데이터 전송을 방지하십시오.

3. **도구 안전성**: 도구를 호출하기 전에 명시적인 사용자 동의를 요구하십시오. 각 도구의 기능을 사용자에게 명확히 이해시키고 강력한 보안 경계를 적용하십시오.

4. **도구 권한 제어**: 세션 중 모델이 사용할 수 있는 도구를 구성하여 명시적으로 승인된 도구만 접근 가능하도록 하십시오.

5. **인증**: API 키, OAuth 토큰 또는 기타 안전한 인증 방법을 사용하여 도구, 리소스 또는 민감한 작업에 대한 액세스를 부여하기 전에 적절한 인증을 요구하십시오.

6. **매개변수 유효성 검사**: 도구 구현에 잘못된 입력이나 악의적인 입력이 전달되지 않도록 모든 도구 호출에 대해 유효성 검사를 적용하십시오.

7. **속도 제한**: 남용을 방지하고 서버 리소스의 공정한 사용을 보장하기 위해 속도 제한을 구현하십시오.

### 구현 모범 사례

1. **기능 협상**: 연결 설정 중 지원되는 기능, 프로토콜 버전, 사용 가능한 도구 및 리소스에 대한 정보를 교환하십시오.

2. **도구 설계**: 여러 문제를 처리하는 거대한 도구보다는 특정 작업에 특화된 도구를 만드십시오.

3. **오류 처리**: 문제를 진단하고, 실패를 우아하게 처리하며, 실행 가능한 피드백을 제공할 수 있도록 표준화된 오류 메시지와 코드를 구현하십시오.

4. **로깅**: 프로토콜 상호작용을 감사, 디버깅, 모니터링할 수 있도록 구조화된 로그를 구성하십시오.

5. **진행 상황 추적**: 장시간 실행되는 작업의 경우, 진행 상황 업데이트를 보고하여 반응형 사용자 인터페이스를 가능하게 하십시오.

6. **요청 취소**: 더 이상 필요하지 않거나 너무 오래 걸리는 요청을 클라이언트가 취소할 수 있도록 허용하십시오.

## 추가 참고 자료

MCP 모범 사례에 대한 최신 정보는 다음을 참조하십시오:

- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)
- [Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## 실질적인 구현 예제

### 도구 설계 모범 사례

#### 1. 단일 책임 원칙

각 MCP 도구는 명확하고 집중된 목적을 가져야 합니다. 여러 문제를 처리하려는 거대한 도구를 만드는 대신, 특정 작업에 특화된 도구를 개발하십시오.

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

#### 2. 일관된 오류 처리

정보 제공 오류 메시지와 적절한 복구 메커니즘을 통해 강력한 오류 처리를 구현하십시오.

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

#### 3. 매개변수 유효성 검사

잘못된 입력이나 악의적인 입력을 방지하기 위해 항상 매개변수를 철저히 검증하십시오.

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

### 보안 구현 예제

#### 1. 인증 및 권한 부여

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

#### 2. 속도 제한

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

## 테스트 모범 사례

### 1. MCP 도구 단위 테스트

외부 종속성을 모킹하여 도구를 개별적으로 테스트하십시오:

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

### 2. 통합 테스트

클라이언트 요청에서 서버 응답까지의 전체 흐름을 테스트하십시오:

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

## 성능 최적화

### 1. 캐싱 전략

지연 시간과 리소스 사용량을 줄이기 위해 적절한 캐싱을 구현하십시오:

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
// 의존성 주입을 활용한 Java 예제
public class CurrencyConversionTool implements Tool {
    private final ExchangeRateService exchangeService;
    private final CacheService cacheService;
    private final Logger logger;
    
    // 생성자를 통한 의존성 주입
    public CurrencyConversionTool(
            ExchangeRateService exchangeService,
            CacheService cacheService,
            Logger logger) {
        this.exchangeService = exchangeService;
        this.cacheService = cacheService;
        this.logger = logger;
    }
    
    // 도구 구현
    // ...
}
```

#### 3. Composable Tools

Design tools that can be composed together to create more complex workflows:

```python
# Python 예제: 조합 가능한 도구
class DataFetchTool(Tool):
    def get_name(self):
        return "dataFetch"
    
    # 구현...

class DataAnalysisTool(Tool):
    def get_name(self):
        return "dataAnalysis"
    
    # 이 도구는 dataFetch 도구의 결과를 사용할 수 있음
    async def execute_async(self, request):
        # 구현...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # 이 도구는 dataAnalysis 도구의 결과를 사용할 수 있음
    async def execute_async(self, request):
        # 구현...
        pass

# 이 도구들은 독립적으로 또는 워크플로의 일부로 사용할 수 있음
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
                description = "검색 쿼리 텍스트. 더 나은 결과를 위해 정확한 키워드를 사용하세요." 
            },
            filters = new {
                type = "object",
                description = "검색 결과를 좁히기 위한 선택적 필터",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "날짜 범위 형식 YYYY-MM-DD:YYYY-MM-DD" 
                    },
                    category = new { 
                        type = "string", 
                        description = "필터링할 카테고리 이름" 
                    }
                }
            },
            limit = new { 
                type = "integer", 
                description = "반환할 최대 결과 수 (1-50)",
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
    
    // 이메일 속성: 형식 유효성 검사 포함
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "사용자 이메일 주소");
    
    // 나이 속성: 숫자 제약 조건 포함
    Map<String, Object> age = new HashMap<>();
    age.put("type", "integer");
    age.put("minimum", 13);
    age.put("maximum", 120);
    age.put("description", "사용자 나이 (년 단위)");
    
    // 열거형 속성
    Map<String, Object> subscription = new HashMap<>();
    subscription.put("type", "string");
    subscription.put("enum", Arrays.asList("free", "basic", "premium"));
    subscription.put("default", "free");
    subscription.put("description", "구독 등급");
    
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
        # 요청 처리
        results = await self._search_database(request.parameters["query"])
        
        # 항상 일관된 구조 반환
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
    """각 항목이 일관된 구조를 가지도록 보장"""
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
            throw new ToolExecutionException($"파일을 찾을 수 없습니다: {fileId}");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ToolExecutionException("이 파일에 접근할 권한이 없습니다");
        }
        catch (Exception ex) when (ex is IOException || ex is TimeoutException)
        {
            _logger.LogError(ex, "파일 {FileId} 접근 중 오류 발생", fileId);
            throw new ToolExecutionException("파일 접근 오류: 서비스가 일시적으로 사용 불가능합니다");
        }
    }
    catch (JsonException)
    {
        throw new ToolExecutionException("잘못된 파일 ID 형식");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "FileAccessTool에서 예기치 않은 오류 발생");
        throw new ToolExecutionException("예기치 않은 오류가 발생했습니다");
    }
}
```

#### 2. Structured Error Responses

Return structured error information when possible:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    try {
        // 구현
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
        
        // 다른 예외는 ToolExecutionException으로 재발생
        throw new ToolExecutionException("도구 실행 실패: " + ex.getMessage(), ex);
    }
}
```

#### 3. Retry Logic

Implement appropriate retry logic for transient failures:

```python
async def execute_async(self, request):
    max_retries = 3
    retry_count = 0
    base_delay = 1  # 초 단위
    
    while retry_count < max_retries:
        try:
            # 외부 API 호출
            return await self._call_api(request.parameters)
        except TransientError as e:
            retry_count += 1
            if retry_count >= max_retries:
                raise ToolExecutionException(f"{max_retries}번 시도 후 작업 실패: {str(e)}")
                
            # 지수 백오프
            delay = base_delay * (2 ** (retry_count - 1))
            logging.warning(f"일시적 오류 발생, {delay}초 후 재시도: {str(e)}")
            await asyncio.sleep(delay)
        except Exception as e:
            # 비일시적 오류, 재시도하지 않음
            raise ToolExecutionException(f"작업 실패: {str(e)}")
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
    
    // 매개변수를 기반으로 캐시 키 생성
    var cacheKey = $"data_query_{ComputeHash(query)}";
    
    // 먼저 캐시에서 가져오기 시도
    if (_cache.TryGetValue(cacheKey, out var cachedResult))
    {
        return new ToolResponse { Result = cachedResult };
    }
    
    // 캐시 미스 - 실제 쿼리 수행
    var result = await _database.QueryAsync(query);
    
    // 만료 시간과 함께 캐시에 저장
    var cacheOptions = new MemoryCacheEntryOptions()
        .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
        
    _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
    
    return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
}

private string ComputeHash(string input)
{
    // 캐시 키를 위한 안정적인 해시 생성 구현
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
        
        // 장시간 실행되는 작업의 경우, 처리 ID를 즉시 반환
        String processId = UUID.randomUUID().toString();
        
        // 비동기 처리 시작
        CompletableFuture.runAsync(() -> {
            try {
                // 장시간 실행 작업 수행
                documentService.processDocument(documentId);
                
                // 상태 업데이트 (일반적으로 데이터베이스에 저장됨)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // 처리 ID와 함께 즉시 응답 반환
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // 상태 확인 도구
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
            tokens_per_second=5,  # 초당 5개의 요청 허용
            bucket_size=10        # 최대 10개의 요청 버스트 허용
        )
    
    async def execute_async(self, request):
        # 진행 가능 여부 확인 또는 대기 필요 여부 확인
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # 대기 시간이 너무 길 경우
                raise ToolExecutionException(
                    f"요청 제한 초과. {delay:.1f}초 후에 다시 시도하세요."
                )
            else:
                # 적절한 대기 시간 동안 대기
                await asyncio.sleep(delay)
        
        # 토큰을 소비하고 요청 진행
        self.rate_limiter.consume()
        
        # API 호출
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
            
            # 다음 토큰이 사용 가능해질 때까지의 시간 계산
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # 경과 시간에 따라 새 토큰 추가
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
    // 매개변수 유효성 검사
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("필수 매개변수 누락: query");
    }
    
    // 올바른 유형인지 확인
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("Query 매개변수는 문자열이어야 합니다");
    }
    
    var query = queryProp.GetString();
    
    // 문자열 내용 유효성 검사
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("Query 매개변수는 비어 있을 수 없습니다");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("Query 매개변수는 최대 500자를 초과할 수 없습니다");
    }
    
    // SQL 인젝션 공격 여부 확인 (적용 가능한 경우)
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("유효하지 않은 쿼리: 잠재적으로 안전하지 않은 SQL 포함");
    }
    
    // 실행 진행
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // 요청에서 사용자 컨텍스트 가져오기
    UserContext user = request.getContext().getUserContext();
    
    // 사용자가 필요한 권한을 가지고 있는지 확인
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("사용자가 문서에 접근할 권한이 없습니다");
    }
    
    // 특정 리소스에 대해 해당 리소스에 대한 접근 권한 확인
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("요청된 문서에 대한 접근이 거부되었습니다");
    }
    
    // 도구 실행 진행
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
        
        # 사용자 데이터 가져오기
        user_data = await self.user_service.get_user_data(user_id)
        
        # 민감한 필드는 명시적으로 요청되고 권한이 있는 경우에만 필터링
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # 요청 컨텍스트에서 권한 수준 확인
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # 원본을 수정하지 않기 위해 복사본 생성
        redacted = user_data.copy()
        
        # 특정 민감한 필드 숨기기
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # 중첩된 민감한 데이터 숨기기
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
    // 준비
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("Seattle", 3))
        .ReturnsAsync(new WeatherForecast(/* 테스트 데이터 */));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "Seattle", 
            days = 3 
        })
    );
    
    // 실행
    var response = await tool.ExecuteAsync(request);
    
    // 검증
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // 준비
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("InvalidLocation", It.IsAny<int>()))
        .ThrowsAsync(new LocationNotFoundException("위치를 찾을 수 없습니다"));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "InvalidLocation", 
            days = 3 
        })
    );
    
    // 실행 및 검증
    var exception = await Assert.ThrowsAsync<ToolExecutionException>(
        () => tool.ExecuteAsync(request)
    );
    
    Assert.Contains("위치를 찾을 수 없습니다", exception.Message);
}
```

#### 2. Schema Validation Testing

Test that schemas are valid and properly enforce constraints:

```java
@Test
public void testSchemaValidation() {
    // 도구 인스턴스 생성
    SearchTool searchTool = new SearchTool();
    
    // 스키마 가져오기
    Object schema = searchTool.getSchema();
    
    // 유효성 검사를 위해 스키마를 JSON으로 변환
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // 스키마가 유효한 JSONSchema인지 확인
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // 유효한 매개변수 테스트
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // 필수 매개변수 누락 테스트
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // 잘못된 매개변수 유형 테스트
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
    # 준비
    tool = ApiTool(timeout=0.1)  # 매우 짧은 타임아웃 설정
    
    # 타임아웃이 발생할 요청 모의
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # 타임아웃보다 긴 시간
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # 실행 및 검증
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # 예외 메시지 확인
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # 준비
    tool = ApiTool()
    
    # 속도 제한 응답 모의
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
        
        # 실행 및 검증
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # 예외에 속도 제한 정보 포함 여부 확인
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
    // 준비
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // 실행
```markdown
var result = await workflowExecutor.ExecuteWorkflowAsync(new[] {
    new ToolCall("dataFetch", new { source = "sales2023" }),
    new ToolCall("dataAnalysis", ctx =
> new { 
        data = ctx.GetResult("dataFetch"),
        analysis = "trend" 
    }),
    new ToolCall("dataVisualize", ctx => new {
        analysisResult = ctx.GetResult("dataAnalysis"),
        type = "line-chart"
    })
});

// 확인
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
        // 도구 검색 엔드포인트 테스트
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // 도구 요청 생성
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // 요청 전송 및 응답 확인
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // 잘못된 도구 요청 생성
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // 누락된 매개변수 "b"
        request.put("parameters", parameters);
        
        // 요청 전송 및 오류 응답 확인
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
    # 준비 - MCP 클라이언트 및 모형 설정
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # 모형 응답 모의
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
    
    # 날씨 도구 응답 모의
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
        
        # 실행
        response = await mcp_client.send_prompt(
            "What's the weather in Seattle?",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # 확인
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
    // 준비
    var server = new McpServer(
        name: "TestServer",
        version: "1.0",
        maxConcurrentRequests: 100
    );
    
    server.RegisterTool(new FastExecutingTool());
    await server.StartAsync();
    
    var client = new McpClient("http://localhost:5000");
    
    // 실행
    var tasks = new List<Task<McpResponse>>();
    for (int i = 0; i < 1000; i++)
    {
        tasks.Add(client.ExecuteToolAsync("fastTool", new { iteration = i }));
    }
    
    var results = await Task.WhenAll(tasks);
    
    // 확인
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
    
    // 스트레스 테스트를 위한 JMeter 설정
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // JMeter 테스트 계획 구성
    HashTree testPlanTree = new HashTree();
    
    // 테스트 계획, 스레드 그룹, 샘플러 등 생성
    TestPlan testPlan = new TestPlan("MCP Server Stress Test");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // 도구 실행을 위한 HTTP 샘플러 추가
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // 리스너 추가
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // 테스트 실행
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // 결과 확인
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // 평균 응답 시간 < 200ms
    assertTrue(summaryReport.getPercentile(90.0) < 500); // 90번째 백분위 < 500ms
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# MCP 서버 모니터링 구성
def configure_monitoring(server):
    # Prometheus 메트릭 설정
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
    
    # 타이밍 및 메트릭 기록을 위한 미들웨어 추가
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # 메트릭 엔드포인트 노출
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
# Python 도구 체인 구현
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # 순서대로 실행할 도구 이름 목록
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # 체인의 각 도구를 실행하며 이전 결과를 전달
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # 결과 저장 및 다음 도구를 위한 입력으로 사용
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# 사용 예시
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
        
        // 사용할 특화 도구 결정
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // 특화 도구로 전달
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
            _ => throw new InvalidOperationException("Unsupported content type or operation")
        };
    }
}
```
"csvProcessor",
("code", _) => "codeAnalyzer",
            _ => throw new ToolExecutionException($"해당 {contentType}/{operation}에 사용할 도구가 없습니다.")
        };
    }
    
    private object GetOptionsForTool(string toolName, string operation)
    {
        // 각 전문 도구에 적합한 옵션 반환
        return toolName switch
        {
            "textSummarizer" => new { length = "medium" },
            "htmlProcessor" => new { cleanUp = true, operation },
            // 다른 도구에 대한 옵션...
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
        // 1단계: 데이터셋 메타데이터 가져오기 (동기)
        ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata", 
            Map.of("datasetId", datasetId));
        
        // 2단계: 여러 분석을 병렬로 실행
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
        
        // 모든 병렬 작업 완료 대기
        CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
            statisticalAnalysis, correlationAnalysis, outlierDetection
        );
        
        allAnalyses.join();  // 완료 대기
        
        // 3단계: 결과 결합
        Map<String, Object> combinedResults = new HashMap<>();
        combinedResults.put("metadata", metadataResponse.getResult());
        combinedResults.put("statistics", statisticalAnalysis.join().getResult());
        combinedResults.put("correlations", correlationAnalysis.join().getResult());
        combinedResults.put("outliers", outlierDetection.join().getResult());
        
        // 4단계: 요약 보고서 생성
        ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator", 
            Map.of("analysisResults", combinedResults));
        
        // 전체 워크플로 결과 반환
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
            # 우선 기본 도구 시도
            response = await self.client.execute_tool(primary_tool, parameters)
            return {
                "result": response.result,
                "source": "primary",
                "tool": primary_tool
            }
        except ToolExecutionException as e:
            # 실패 기록
            logging.warning(f"기본 도구 '{primary_tool}' 실패: {str(e)}")
            
            # 보조 도구로 대체
            try:
                # 보조 도구에 맞게 매개변수 변환 필요할 수 있음
                fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)
                
                response = await self.client.execute_tool(fallback_tool, fallback_params)
                return {
                    "result": response.result,
                    "source": "fallback",
                    "tool": fallback_tool,
                    "primaryError": str(e)
                }
            except ToolExecutionException as fallback_error:
                # 기본 및 보조 도구 모두 실패
                logging.error(f"기본 및 보조 도구 모두 실패. 보조 도구 오류: {str(fallback_error)}")
                raise WorkflowExecutionException(
                    f"워크플로 실패: 기본 오류: {str(e)}; 보조 오류: {str(fallback_error)}"
                )
    
    def _adapt_parameters(self, params, from_tool, to_tool):
        """도구 간 매개변수 변환 필요 시 처리"""
        # 이 구현은 특정 도구에 따라 달라짐
        # 이 예제에서는 원래 매개변수를 그대로 반환
        return params

# 사용 예제
async def get_weather(workflow, location):
    return await workflow.execute_with_fallback(
        "premiumWeatherService",  # 기본 (유료) 날씨 API
        "basicWeatherService",    # 보조 (무료) 날씨 API
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
            
            // 각 워크플로 결과 저장
            results[workflow.Name] = workflowResult;
            
            // 다음 워크플로를 위해 결과로 컨텍스트 업데이트
            context = context.WithResult(workflow.Name, workflowResult);
        }
        
        return new WorkflowResult(results);
    }
    
    public string Name => "CompositeWorkflow";
    public string Description => "여러 워크플로를 순차적으로 실행";
}

// 사용 예제
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
// C#에서 계산기 도구에 대한 단위 테스트 예제
[Fact]
public async Task CalculatorTool_Add_ReturnsCorrectSum()
{
    // 준비
    var calculator = new CalculatorTool();
    var parameters = new Dictionary<string, object>
    {
        ["operation"] = "add",
        ["a"] = 5,
        ["b"] = 7
    };
    
    // 실행
    var response = await calculator.ExecuteAsync(parameters);
    var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());
    
    // 검증
    Assert.Equal(12, result.Value);
}
```

```python
# Python에서 계산기 도구에 대한 단위 테스트 예제
def test_calculator_tool_add():
    # 준비
    calculator = CalculatorTool()
    parameters = {
        "operation": "add",
        "a": 5,
        "b": 7
    }
    
    # 실행
    response = calculator.execute(parameters)
    result = json.loads(response.content[0].text)
    
    # 검증
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
// C#에서 MCP 서버에 대한 통합 테스트 예제
[Fact]
public async Task Server_ProcessToolRequest_ReturnsValidResponse()
{
    // 준비
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
    
    // 실행
    var response = await server.ProcessRequestAsync(request);
    
    // 검증
    Assert.NotNull(response);
    Assert.Equal(McpStatusCodes.Success, response.StatusCode);
    // 응답 내용에 대한 추가 검증
    
    // 정리
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
// TypeScript에서 클라이언트를 사용한 E2E 테스트 예제
describe('MCP Server E2E Tests', () => {
  let client: McpClient;
  
  beforeAll(async () => {
    // 테스트 환경에서 서버 시작
    await startTestServer();
    client = new McpClient('http://localhost:5000');
  });
  
  afterAll(async () => {
    await stopTestServer();
  });
  
  test('클라이언트가 계산기 도구를 호출하고 올바른 결과를 얻을 수 있음', async () => {
    // 실행
    const response = await client.invokeToolAsync('calculator', {
      operation: 'divide',
      a: 20,
      b: 4
    });
    
    // 검증
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
// Moq를 사용한 C# 예제
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
# unittest.mock을 사용한 Python 예제
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
    # 모의 설정
    mock_model.return_value.generate_response.return_value = {
        "text": "Mocked model response",
        "finish_reason": "completed"
    }
    
    # 테스트에서 모의 사용
    server = McpServer(model_client=mock_model)
    # 테스트 계속 진행
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
// MCP 서버에 대한 부하 테스트를 위한 k6 스크립트
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  vus: 10,  // 10명의 가상 사용자
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
    
    - name: 런타임 설정
      uses: actions/setup-dotnet@v1
      with:
        dotnet-version: '8.0.x'
    
    - name: 종속성 복원
      run: dotnet restore
    
    - name: 빌드
      run: dotnet build --no-restore
    
    - name: 단위 테스트
      run: dotnet test --no-build --filter Category=Unit
    
    - name: 통합 테스트
      run: dotnet test --no-build --filter Category=Integration
      
    - name: 성능 테스트
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
    // 준비
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");
    
    // 실행
    var response = await client.GetAsync("http://localhost:5000/api/resources");
    var content = await response.Content.ReadAsStringAsync();
    var resources = JsonSerializer.Deserialize

# MCP 서버 테스트 가이드

## 소개

MCP 서버는 AI 도구와 워크플로를 통합하여 강력한 기능을 제공합니다. 그러나 이러한 서버의 신뢰성과 성능을 보장하려면 철저한 테스트가 필수적입니다. 이 가이드는 MCP 서버 테스트를 효과적으로 수행하기 위한 모범 사례와 팁을 제공합니다.

## MCP 서버 테스트의 주요 목표

1. **정확성**: 모든 도구와 워크플로가 예상대로 작동하는지 확인합니다.
2. **성능**: 서버가 높은 부하에서도 안정적으로 작동하는지 평가합니다.
3. **보안**: 데이터 유출 및 무단 액세스를 방지하기 위한 보안 검증을 수행합니다.
4. **확장성**: 서버가 증가하는 사용자 및 데이터 요구를 처리할 수 있는지 확인합니다.

## 테스트 사례

### 도구 정의 테스트
```csharp
// Arrange
var toolDefinition = new ToolDefinition
{
    Name = "SampleTool",
    Schema = new Schema
    {
        Properties = new List<Property>
        {
            new Property { Name = "Input", Type = "string" },
            new Property { Name = "Output", Type = "string" }
        }
    }
};

// Act
var validationResult = ValidateToolDefinition(toolDefinition);

// Assert
Assert.True(validationResult.IsValid);
Assert.Empty(validationResult.Errors);
```

### 워크플로 테스트
```csharp
// Arrange
var workflow = new Workflow
{
    Steps = new List<Step>
    {
        new Step { ToolName = "ToolA", Input = "Step1Input" },
        new Step { ToolName = "ToolB", Input = "Step1Output" }
    }
};

// Act
var result = ExecuteWorkflow(workflow);

// Assert
Assert.NotNull(result);
Assert.Equal("ExpectedOutput", result.FinalOutput);
```

### 리소스 API 테스트
```csharp
// Arrange
var client = new HttpClient();
var request = new HttpRequestMessage(HttpMethod.Get, "/api/resources");

// Act
var response = await client.SendAsync(request);
var content = await response.Content.ReadAsStringAsync();
var resources = JsonConvert.DeserializeObject<ResourceResponse>(content);

// Assert
Assert.Equal(HttpStatusCode.OK, response.StatusCode);
Assert.NotNull(resources);
Assert.All(resources.Resources, resource => 
{
    Assert.NotNull(resource.Id);
    Assert.NotNull(resource.Type);
    // 추가 스키마 검증
});
}
```

## 효과적인 MCP 서버 테스트를 위한 10가지 팁

1. **도구 정의를 개별적으로 테스트**: 도구 로직과 별개로 스키마 정의를 검증하세요.
2. **매개변수화된 테스트 사용**: 다양한 입력값과 경계 조건을 포함하여 테스트하세요.
3. **에러 응답 확인**: 모든 가능한 에러 조건에 대해 적절한 에러 처리를 검증하세요.
4. **권한 로직 테스트**: 다양한 사용자 역할에 대한 접근 제어를 확인하세요.
5. **테스트 커버리지 모니터링**: 중요한 경로 코드의 높은 커버리지를 목표로 하세요.
6. **스트리밍 응답 테스트**: 스트리밍 콘텐츠 처리의 적절성을 검증하세요.
7. **네트워크 문제 시뮬레이션**: 네트워크 상태가 나쁠 때의 동작을 테스트하세요.
8. **리소스 제한 테스트**: 할당량이나 속도 제한에 도달했을 때의 동작을 검증하세요.
9. **회귀 테스트 자동화**: 코드 변경 시마다 실행되는 테스트 스위트를 구축하세요.
10. **테스트 케이스 문서화**: 테스트 시나리오를 명확히 문서화하세요.

## 일반적인 테스트 실수

- **행복 경로 테스트에만 의존**: 에러 케이스를 철저히 테스트하세요.
- **성능 테스트 무시**: 병목 현상을 사전에 식별하세요.
- **단위 테스트에만 의존**: 단위, 통합, E2E 테스트를 결합하세요.
- **불완전한 API 커버리지**: 모든 엔드포인트와 기능을 테스트하세요.
- **일관성 없는 테스트 환경**: 컨테이너를 사용하여 일관된 테스트 환경을 유지하세요.

## 결론

포괄적인 테스트 전략은 신뢰할 수 있고 고품질의 MCP 서버를 개발하는 데 필수적입니다. 이 가이드에서 제시한 모범 사례와 팁을 구현함으로써 MCP 구현이 최고 수준의 품질, 신뢰성, 성능을 충족하도록 보장할 수 있습니다.

## 핵심 요점

1. **도구 설계**: 단일 책임 원칙을 따르고, 의존성 주입을 사용하며, 조합 가능성을 고려하세요.
2. **스키마 설계**: 명확하고 잘 문서화된 스키마를 생성하고 적절한 검증 제약 조건을 추가하세요.
3. **에러 처리**: 우아한 에러 처리, 구조화된 에러 응답, 재시도 로직을 구현하세요.
4. **성능**: 캐싱, 비동기 처리, 리소스 제한을 활용하세요.
5. **보안**: 철저한 입력 검증, 권한 확인, 민감한 데이터 처리를 적용하세요.
6. **테스트**: 포괄적인 단위, 통합, E2E 테스트를 작성하세요.
7. **워크플로 패턴**: 체인, 디스패처, 병렬 처리와 같은 패턴을 적용하세요.

## 연습 문제

다음 시나리오에 적합한 MCP 도구와 워크플로를 설계하세요:

1. 여러 형식(PDF, DOCX, TXT)의 문서를 수락합니다.
2. 문서에서 텍스트와 주요 정보를 추출합니다.
3. 문서를 유형과 내용에 따라 분류합니다.
4. 각 문서의 요약을 생성합니다.

이 구현에 적합한 도구 스키마, 에러 처리, 워크플로 패턴을 설계하세요. 이 구현을 테스트하는 방법도 고려하세요.

## 리소스

1. 최신 정보를 얻기 위해 [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs)에 참여하세요.
2. 오픈소스 [MCP 프로젝트](https://github.com/modelcontextprotocol)에 기여하세요.
3. MCP 원칙을 귀하의 조직의 AI 이니셔티브에 적용하세요.
4. 귀하의 산업에 특화된 MCP 구현을 탐색하세요.
5. 다중 모달 통합 또는 엔터프라이즈 애플리케이션 통합과 같은 특정 MCP 주제에 대한 고급 과정을 고려하세요.
6. [핸즈온 랩](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)을 통해 배운 원칙을 사용하여 자체 MCP 도구와 워크플로를 실험해 보세요.

다음: 모범 사례 [사례 연구](../09-CaseStudy/README.md)

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 최선을 다하고 있지만, 자동 번역에는 오류나 부정확성이 포함될 수 있습니다. 원본 문서의 원어 버전을 권위 있는 출처로 간주해야 합니다. 중요한 정보의 경우, 전문적인 인간 번역을 권장합니다. 이 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해 책임을 지지 않습니다.