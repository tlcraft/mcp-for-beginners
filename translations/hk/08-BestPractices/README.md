<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1827d0f7a6430dfb7adcdd5f1ee05bda",
  "translation_date": "2025-07-28T23:41:17+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "hk"
}
-->
# MCP 開發最佳實踐

[![MCP 開發最佳實踐](../../../translated_images/09.d0f6d86c9d72134ccf5a8d8c8650a0557e519936661fc894cad72d73522227cb.hk.png)](https://youtu.be/W56H9W7x-ao)

_（點擊上方圖片觀看本課程的影片）_

## 概述

本課程專注於在生產環境中開發、測試及部署 MCP 伺服器和功能的高級最佳實踐。隨著 MCP 生態系統的複雜性和重要性不斷增長，遵循既定模式能確保可靠性、可維護性及互操作性。本課程整合了從實際 MCP 實施中獲得的實用經驗，指導您創建穩健、高效的伺服器及有效的資源、提示和工具。

## 學習目標

完成本課程後，您將能夠：

- 在 MCP 伺服器和功能設計中應用行業最佳實踐
- 為 MCP 伺服器制定全面的測試策略
- 為複雜的 MCP 應用設計高效、可重用的工作流程模式
- 在 MCP 伺服器中實施正確的錯誤處理、日誌記錄及可觀測性
- 優化 MCP 實施的性能、安全性及可維護性

## MCP 核心原則

在深入探討具體的實施實踐之前，了解指導有效 MCP 開發的核心原則非常重要：

1. **標準化通信**：MCP 使用 JSON-RPC 2.0 作為基礎，為所有實施提供一致的請求、響應及錯誤處理格式。

2. **以用戶為中心的設計**：在 MCP 實施中始終優先考慮用戶的同意、控制及透明度。

3. **安全至上**：實施包括身份驗證、授權、驗證及速率限制在內的強大安全措施。

4. **模塊化架構**：以模塊化方式設計 MCP 伺服器，每個工具和資源都有明確且專注的用途。

5. **有狀態連接**：利用 MCP 能夠在多個請求之間保持狀態的能力，實現更連貫且具上下文感知的交互。

## 官方 MCP 最佳實踐

以下最佳實踐來自官方 Model Context Protocol 文檔：

### 安全最佳實踐

1. **用戶同意及控制**：在訪問數據或執行操作之前，始終要求明確的用戶同意。提供清晰的控制，讓用戶了解共享的數據及授權的操作。

2. **數據隱私**：僅在獲得明確同意的情況下暴露用戶數據，並通過適當的訪問控制保護數據。防止未授權的數據傳輸。

3. **工具安全性**：在調用任何工具之前要求明確的用戶同意。確保用戶了解每個工具的功能，並強制執行強大的安全邊界。

4. **工具權限控制**：配置模型在會話期間允許使用的工具，確保僅可訪問明確授權的工具。

5. **身份驗證**：在使用 API 密鑰、OAuth 令牌或其他安全身份驗證方法授予工具、資源或敏感操作的訪問權限之前，要求進行適當的身份驗證。

6. **參數驗證**：對所有工具調用強制執行驗證，防止格式錯誤或惡意輸入到達工具實現。

7. **速率限制**：實施速率限制以防止濫用並確保公平使用伺服器資源。

### 實施最佳實踐

1. **能力協商**：在連接設置期間，交換有關支持的功能、協議版本、可用工具及資源的信息。

2. **工具設計**：創建專注的工具，專注於做好一件事，而不是設計處理多個問題的單一工具。

3. **錯誤處理**：實施標準化的錯誤消息及代碼，以幫助診斷問題、優雅地處理故障並提供可操作的反饋。

4. **日誌記錄**：配置結構化日誌以審計、調試及監控協議交互。

5. **進度跟蹤**：對於長時間運行的操作，報告進度更新以支持響應式用戶界面。

6. **請求取消**：允許客戶端取消不再需要或耗時過長的進行中請求。

## 其他參考資料

有關 MCP 最佳實踐的最新信息，請參考：

- [MCP 文檔](https://modelcontextprotocol.io/)
- [MCP 規範](https://spec.modelcontextprotocol.io/)
- [GitHub 儲存庫](https://github.com/modelcontextprotocol)
- [安全最佳實踐](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## 實際實施範例

### 工具設計最佳實踐

#### 1. 單一職責原則

每個 MCP 工具應有明確且專注的用途。與其創建試圖處理多個問題的單一工具，不如開發專注於特定任務的專業工具。

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

#### 2. 一致的錯誤處理

實施強大的錯誤處理，提供信息豐富的錯誤消息及適當的恢復機制。

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

#### 3. 參數驗證

始終徹底驗證參數，以防止格式錯誤或惡意輸入。

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

### 安全實施範例

#### 1. 身份驗證及授權

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

#### 2. 速率限制

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

## 測試最佳實踐

### 1. 單元測試 MCP 工具

始終在隔離環境中測試工具，模擬外部依賴：

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

### 2. 集成測試

測試從客戶端請求到伺服器響應的完整流程：

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

## 性能優化

### 1. 快取策略

實施適當的快取以減少延遲及資源使用：

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
// Java 範例，使用依賴注入
public class CurrencyConversionTool implements Tool {
    private final ExchangeRateService exchangeService;
    private final CacheService cacheService;
    private final Logger logger;
    
    // 通過構造函數注入依賴
    public CurrencyConversionTool(
            ExchangeRateService exchangeService,
            CacheService cacheService,
            Logger logger) {
        this.exchangeService = exchangeService;
        this.cacheService = cacheService;
        this.logger = logger;
    }
    
    // 工具實現
    // ...
}
```

#### 3. Composable Tools

Design tools that can be composed together to create more complex workflows:

```python
# Python 範例，展示可組合工具
class DataFetchTool(Tool):
    def get_name(self):
        return "dataFetch"
    
    # 實現...

class DataAnalysisTool(Tool):
    def get_name(self):
        return "dataAnalysis"
    
    # 此工具可使用 dataFetch 工具的結果
    async def execute_async(self, request):
        # 實現...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # 此工具可使用 dataAnalysis 工具的結果
    async def execute_async(self, request):
        # 實現...
        pass

# 這些工具可獨立使用或作為工作流程的一部分
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
                description = "搜索查詢文本。使用精確的關鍵字以獲得更好的結果。" 
            },
            filters = new {
                type = "object",
                description = "可選的篩選器以縮小搜索結果範圍",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "日期範圍，格式為 YYYY-MM-DD:YYYY-MM-DD" 
                    },
                    category = new { 
                        type = "string", 
                        description = "篩選的類別名稱" 
                    }
                }
            },
            limit = new { 
                type = "integer", 
                description = "返回的最大結果數量（1-50）",
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
    
    // 電郵屬性，帶格式驗證
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "用戶電郵地址");
    
    // 年齡屬性，帶數值約束
    Map<String, Object> age = new HashMap<>();
    age.put("type", "integer");
    age.put("minimum", 13);
    age.put("maximum", 120);
    age.put("description", "用戶年齡（以年計）");
    
    // 枚舉屬性
    Map<String, Object> subscription = new HashMap<>();
    subscription.put("type", "string");
    subscription.put("enum", Arrays.asList("free", "basic", "premium"));
    subscription.put("default", "free");
    subscription.put("description", "訂閱層級");
    
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
        # 處理請求
        results = await self._search_database(request.parameters["query"])
        
        # 始終返回一致的結構
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
    """確保每個項目都有一致的結構"""
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
            throw new ToolExecutionException($"未找到文件：{fileId}");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ToolExecutionException("您無權訪問此文件");
        }
        catch (Exception ex) when (ex is IOException || ex is TimeoutException)
        {
            _logger.LogError(ex, "訪問文件 {FileId} 時出錯", fileId);
            throw new ToolExecutionException("訪問文件時出錯：服務暫時不可用");
        }
    }
    catch (JsonException)
    {
        throw new ToolExecutionException("文件 ID 格式無效");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "FileAccessTool 中發生意外錯誤");
        throw new ToolExecutionException("發生意外錯誤");
    }
}
```

#### 2. Structured Error Responses

Return structured error information when possible:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    try {
        // 實現
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
        
        // 將其他異常重新拋出為 ToolExecutionException
        throw new ToolExecutionException("工具執行失敗：" + ex.getMessage(), ex);
    }
}
```

#### 3. Retry Logic

Implement appropriate retry logic for transient failures:

```python
async def execute_async(self, request):
    max_retries = 3
    retry_count = 0
    base_delay = 1  # 秒
    
    while retry_count < max_retries:
        try:
            # 調用外部 API
            return await self._call_api(request.parameters)
        except TransientError as e:
            retry_count += 1
            if retry_count >= max_retries:
                raise ToolExecutionException(f"操作在嘗試 {max_retries} 次後失敗：{str(e)}")
                
            # 指數回退
            delay = base_delay * (2 ** (retry_count - 1))
            logging.warning(f"暫時性錯誤，{delay} 秒後重試：{str(e)}")
            await asyncio.sleep(delay)
        except Exception as e:
            # 非暫時性錯誤，不重試
            raise ToolExecutionException(f"操作失敗：{str(e)}")
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

執行異步操作(ToolRequest request)
{
    var query = request.Parameters.GetProperty("query").GetString();
    
    // 根據參數創建緩存鍵
    var cacheKey = $"data_query_{ComputeHash(query)}";
    
    // 優先從緩存中獲取
    if (_cache.TryGetValue(cacheKey, out var cachedResult))
    {
        return new ToolResponse { Result = cachedResult };
    }
    
    // 緩存未命中 - 執行實際查詢
    var result = await _database.QueryAsync(query);
    
    // 將結果存入緩存並設置過期時間
    var cacheOptions = new MemoryCacheEntryOptions()
        .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
        
    _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
    
    return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
}

private string ComputeHash(string input)
{
    // 用於生成穩定緩存鍵的哈希實現
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
        
        // 對於長時間運行的操作，立即返回處理 ID
        String processId = UUID.randomUUID().toString();
        
        // 開始異步處理
        CompletableFuture.runAsync(() -> {
            try {
                // 執行長時間運行的操作
                documentService.processDocument(documentId);
                
                // 更新狀態（通常會存儲在數據庫中）
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // 返回包含處理 ID 的即時響應
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // 狀態檢查工具
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
            tokens_per_second=5,  # 每秒允許 5 個請求
            bucket_size=10        # 允許最多 10 個請求的突發
        )
    
    async def execute_async(self, request):
        # 檢查是否可以繼續或需要等待
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # 如果等待時間過長
                raise ToolExecutionException(
                    f"超出速率限制。請在 {delay:.1f} 秒後重試。"
                )
            else:
                # 等待適當的延遲時間
                await asyncio.sleep(delay)
        
        # 消耗一個令牌並繼續請求
        self.rate_limiter.consume()
        
        # 調用 API
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
            
            # 計算下一個令牌可用的時間
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # 根據經過的時間添加新令牌
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
    // 驗證參數是否存在
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("缺少必要參數：query");
    }
    
    // 驗證類型是否正確
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("Query 參數必須是字符串");
    }
    
    var query = queryProp.GetString();
    
    // 驗證字符串內容
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("Query 參數不能為空");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("Query 參數超過最大長度 500 字符");
    }
    
    // 如果適用，檢查 SQL 注入攻擊
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("無效的查詢：包含潛在不安全的 SQL");
    }
    
    // 繼續執行
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // 從請求中獲取用戶上下文
    UserContext user = request.getContext().getUserContext();
    
    // 檢查用戶是否具有所需的權限
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("用戶無權訪問文檔");
    }
    
    // 對於特定資源，檢查是否有權訪問該資源
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("無權訪問請求的文檔");
    }
    
    // 繼續執行工具
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
        
        # 獲取用戶數據
        user_data = await self.user_service.get_user_data(user_id)
        
        # 過濾敏感字段，除非明確請求且授權
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # 檢查請求上下文中的授權級別
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # 創建副本以避免修改原始數據
        redacted = user_data.copy()
        
        # 過濾特定敏感字段
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # 過濾嵌套的敏感數據
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
    // Arrange
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("Seattle", 3))
        .ReturnsAsync(new WeatherForecast(/* 測試數據 */));
    
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
        .ThrowsAsync(new LocationNotFoundException("找不到位置"));
    
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
    
    Assert.Contains("找不到位置", exception.Message);
}
```

#### 2. Schema Validation Testing

Test that schemas are valid and properly enforce constraints:

```java
@Test
public void testSchemaValidation() {
    // 創建工具實例
    SearchTool searchTool = new SearchTool();
    
    // 獲取模式
    Object schema = searchTool.getSchema();
    
    // 將模式轉換為 JSON 以進行驗證
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // 驗證模式是否為有效的 JSONSchema
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // 測試有效參數
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // 測試缺少必要參數
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // 測試無效參數類型
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
    # Arrange
    tool = ApiTool(timeout=0.1)  # 非常短的超時時間
    
    # 模擬一個會超時的請求
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # 超過超時時間
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # Act & Assert
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # 驗證異常信息
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # Arrange
    tool = ApiTool()
    
    # 模擬一個速率限制的響應
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
        
        # 驗證異常包含速率限制信息
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
> var result = await workflowExecutor.ExecuteWorkflowAsync(new[] {
>     new ToolCall("dataFetch", new { source = "sales2023" }),
>     new ToolCall("dataAnalysis", ctx =
> new { 
>         data = ctx.GetResult("dataFetch"),
>         analysis = "trend" 
>     }),
>     new ToolCall("dataVisualize", ctx => new {
>         analysisResult = ctx.GetResult("dataAnalysis"),
>         type = "line-chart"
>     })
> });
> 
> // 驗證
> Assert.NotNull(result);
> Assert.True(result.Success);
> Assert.NotNull(result.GetResult("dataVisualize"));
> Assert.Contains("chartUrl", result.GetResult("dataVisualize").ToString());
> }
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
        // 測試工具發現端點
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // 建立工具請求
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // 發送請求並驗證回應
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // 建立無效的工具請求
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // 缺少參數 "b"
        request.put("parameters", parameters);
        
        // 發送請求並驗證錯誤回應
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
    # 安排 - 設置 MCP 客戶端和模擬模型
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # 模擬模型回應
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
    
    # 模擬天氣工具回應
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
        
        # 執行
        response = await mcp_client.send_prompt(
            "What's the weather in Seattle?",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # 驗證
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
    // 安排
    var server = new McpServer(
        name: "TestServer",
        version: "1.0",
        maxConcurrentRequests: 100
    );
    
    server.RegisterTool(new FastExecutingTool());
    await server.StartAsync();
    
    var client = new McpClient("http://localhost:5000");
    
    // 執行
    var tasks = new List<Task<McpResponse>>();
    for (int i = 0; i < 1000; i++)
    {
        tasks.Add(client.ExecuteToolAsync("fastTool", new { iteration = i }));
    }
    
    var results = await Task.WhenAll(tasks);
    
    // 驗證
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
    
    // 設置 JMeter 進行壓力測試
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // 配置 JMeter 測試計劃
    HashTree testPlanTree = new HashTree();
    
    // 創建測試計劃、線程組、取樣器等
    TestPlan testPlan = new TestPlan("MCP Server Stress Test");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // 添加 HTTP 取樣器以執行工具
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // 添加監聽器
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // 運行測試
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // 驗證結果
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // 平均響應時間 < 200ms
    assertTrue(summaryReport.getPercentile(90.0) < 500); // 90 百分位 < 500ms
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# 配置 MCP 伺服器的監控
def configure_monitoring(server):
    # 設置 Prometheus 指標
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "總 MCP 請求數"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "請求持續時間（秒）",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "工具執行次數",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "工具執行持續時間（秒）",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "工具執行錯誤",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # 添加中介軟件以記錄時間和指標
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # 暴露指標端點
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
# Python 工具鏈實現
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # 按順序執行的工具名稱列表
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # 執行鏈中的每個工具，傳遞前一個結果
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # 存儲結果並用作下一個工具的輸入
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# 示例用法
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
    public string Description => "處理各種類型的內容";
    
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
        
        // 確定使用哪個專門工具
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // 轉發到專門工具
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
csvProcessor 是一個用於處理 CSV 文件的工具。它可以幫助你快速解析、修改和導出 CSV 數據。

## 功能
- **解析 CSV 文件**：輕鬆讀取和解析 CSV 文件，支援多種分隔符。
- **數據修改**：提供簡單的 API 來修改數據，例如添加、刪除或更新行和列。
- **導出 CSV 文件**：將修改後的數據導出為新的 CSV 文件。

## 安裝
使用以下命令安裝 csvProcessor：

```bash
pip install csvProcessor
```

## 使用方法
以下是一些基本的使用範例：

### 讀取 CSV 文件
使用 `read_csv` 函數讀取 CSV 文件：

```python
import csvProcessor

data = csvProcessor.read_csv('example.csv')
print(data)
```

### 修改數據
使用 `update_row` 函數更新特定行的數據：

```python
csvProcessor.update_row(data, row_index=2, new_row=['value1', 'value2', 'value3'])
```

### 導出 CSV 文件
使用 `write_csv` 函數將數據導出到新的 CSV 文件：

```python
csvProcessor.write_csv(data, 'output.csv')
```

## 注意事項
[!NOTE] csvProcessor 不支援處理超大型 CSV 文件。如果你的文件超過 1GB，請考慮使用其他工具。

[!WARNING] 修改數據時，請確保提供的索引和數據格式正確，否則可能導致意外錯誤。

[!TIP] 如果你需要處理多個 CSV 文件，可以使用迴圈來批量處理。

[!IMPORTANT] 在導出文件之前，請檢查數據是否正確，以避免導出錯誤的結果。

[!CAUTION] 請勿在多線程環境中同時操作同一個 CSV 文件，這可能會導致數據損壞。

## 常見問題
### csvProcessor 是否支援 Excel 格式的文件？
不支援。csvProcessor 僅用於處理 CSV 文件。如果需要處理 Excel 文件，請使用其他工具，例如 `openpyxl` 或 `pandas`。

### 如何處理包含特殊字符的 CSV 文件？
csvProcessor 支援自定義分隔符和編碼。你可以在讀取文件時指定這些參數：

```python
data = csvProcessor.read_csv('example.csv', delimiter=';', encoding='utf-8')
```

### 是否有 GUI 工具？
目前 csvProcessor 僅提供命令行工具，未包含 GUI 界面。

## 聯絡我們
如果你有任何問題或建議，請通過以下方式聯絡我們：
- 電郵：support@csvprocessor.com
- 官方網站：[https://www.csvprocessor.com](https://www.csvprocessor.com)
```csharp
// Arrange
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");
    
    // Act
    var response = await client.GetAsync("http://localhost:5000/api/resources");
    var content = await response.Content.ReadAsStringAsync();
    var resources = JsonSerializer.Deserialize
```

## MCP 伺服器測試的十大技巧

1. **分開測試工具定義**：獨立驗證架構定義，避免與工具邏輯混淆  
2. **使用參數化測試**：使用多種輸入，包括邊界情況進行測試  
3. **檢查錯誤回應**：驗證所有可能的錯誤情況是否正確處理  
4. **測試授權邏輯**：確保不同使用者角色的存取控制正確  
5. **監控測試覆蓋率**：目標是關鍵路徑程式碼的高覆蓋率  
6. **測試串流回應**：驗證串流內容的正確處理  
7. **模擬網絡問題**：測試在網絡狀況不佳時的行為  
8. **測試資源限制**：驗證在達到配額或速率限制時的行為  
9. **自動化回歸測試**：建立一套在每次程式碼變更時執行的測試  
10. **文件化測試案例**：保持測試場景的清晰文件記錄  

## 常見測試陷阱

- **過度依賴正向測試**：確保充分測試錯誤情況  
- **忽略性能測試**：在性能瓶頸影響生產環境之前識別問題  
- **僅進行孤立測試**：結合單元測試、整合測試和端到端測試  
- **API 覆蓋不足**：確保所有端點和功能都被測試  
- **不一致的測試環境**：使用容器確保測試環境的一致性  

## 結論

全面的測試策略對於開發可靠、高品質的 MCP 伺服器至關重要。通過實施本指南中列出的最佳實踐和技巧，您可以確保 MCP 實現符合最高的品質、可靠性和性能標準。

## 關鍵要點

1. **工具設計**：遵循單一職責原則，使用依賴注入，設計具備可組合性  
2. **架構設計**：創建清晰、文件化的架構，並設置適當的驗證約束  
3. **錯誤處理**：實施優雅的錯誤處理、結構化的錯誤回應和重試邏輯  
4. **性能**：使用快取、非同步處理和資源節流  
5. **安全性**：進行全面的輸入驗證、授權檢查和敏感數據處理  
6. **測試**：創建全面的單元測試、整合測試和端到端測試  
7. **工作流程模式**：應用既定模式，例如鏈式、分派器和並行處理  

## 練習

設計一個 MCP 工具和工作流程，用於文件處理系統，該系統需具備以下功能：

1. 接收多種格式的文件（PDF、DOCX、TXT）  
2. 從文件中提取文本和關鍵信息  
3. 根據類型和內容對文件進行分類  
4. 為每個文件生成摘要  

實現工具架構、錯誤處理以及最適合此場景的工作流程模式。考慮如何測試此實現。

## 資源

1. 加入 [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs) MCP 社群，了解最新動態  
2. 為開源 [MCP 專案](https://github.com/modelcontextprotocol) 做出貢獻  
3. 在您自己的組織 AI 計劃中應用 MCP 原則  
4. 探索針對您行業的專業 MCP 實現  
5. 考慮參加進階課程，學習 MCP 特定主題，例如多模態整合或企業應用整合  
6. 通過 [實作實驗室](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) 所學原則，嘗試構建自己的 MCP 工具和工作流程  

下一步：最佳實踐 [案例研究](../09-CaseStudy/README.md)  

**免責聲明**：  
本文件已使用人工智能翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於提供準確的翻譯，但請注意，自動翻譯可能包含錯誤或不準確之處。原始語言的文件應被視為具權威性的來源。對於重要資訊，建議使用專業人工翻譯。我們對因使用此翻譯而引起的任何誤解或錯誤解釋概不負責。