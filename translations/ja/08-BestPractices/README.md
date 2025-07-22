<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0728873f4271f8c19105619921e830d9",
  "translation_date": "2025-07-22T07:44:37+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "ja"
}
-->
# MCP開発のベストプラクティス

## 概要

このレッスンでは、MCPサーバーや機能を本番環境で開発、テスト、デプロイする際の高度なベストプラクティスに焦点を当てます。MCPエコシステムが複雑化し重要性が増す中、確立されたパターンに従うことで信頼性、保守性、相互運用性を確保できます。このレッスンでは、実際のMCP実装から得られた実践的な知識を統合し、効率的で堅牢なサーバーを作成するためのリソース、プロンプト、ツールを提供します。

## 学習目標

このレッスンを終えるまでに、以下ができるようになります：

- MCPサーバーと機能設計における業界のベストプラクティスを適用する
- MCPサーバーの包括的なテスト戦略を作成する
- 複雑なMCPアプリケーション向けの効率的で再利用可能なワークフローパターンを設計する
- MCPサーバーにおける適切なエラーハンドリング、ログ記録、観測性を実装する
- パフォーマンス、セキュリティ、保守性を最適化したMCP実装を行う

## MCPの基本原則

具体的な実装のプラクティスに入る前に、効果的なMCP開発を導く基本原則を理解することが重要です：

1. **標準化された通信**: MCPはJSON-RPC 2.0を基盤としており、すべての実装でリクエスト、レスポンス、エラーハンドリングの一貫したフォーマットを提供します。

2. **ユーザー中心の設計**: MCP実装では常にユーザーの同意、コントロール、透明性を優先してください。

3. **セキュリティ第一**: 認証、認可、検証、レート制限を含む強力なセキュリティ対策を実施してください。

4. **モジュール型アーキテクチャ**: 各ツールやリソースが明確で焦点を絞った目的を持つように、モジュール型のアプローチでMCPサーバーを設計してください。

5. **ステートフルな接続**: MCPの複数リクエスト間で状態を維持する能力を活用し、より一貫性のあるコンテキスト対応のインタラクションを実現してください。

## MCP公式ベストプラクティス

以下のベストプラクティスは、公式のModel Context Protocolドキュメントから派生したものです：

### セキュリティのベストプラクティス

1. **ユーザーの同意とコントロール**: データへのアクセスや操作を行う前に、必ず明示的なユーザーの同意を求めてください。共有されるデータや許可される操作について明確なコントロールを提供してください。

2. **データプライバシー**: 明示的な同意がある場合のみユーザーデータを公開し、適切なアクセス制御で保護してください。不正なデータ送信を防ぐ措置を講じてください。

3. **ツールの安全性**: ツールを呼び出す前に必ず明示的なユーザーの同意を求めてください。各ツールの機能をユーザーが理解できるようにし、強力なセキュリティ境界を確保してください。

4. **ツールの権限管理**: セッション中にモデルが使用できるツールを設定し、明示的に許可されたツールのみがアクセス可能であることを保証してください。

5. **認証**: APIキー、OAuthトークン、その他の安全な認証方法を使用して、ツール、リソース、機密操作へのアクセスを許可する前に適切な認証を要求してください。

6. **パラメータ検証**: ツールの呼び出しに対して検証を徹底し、不正な入力や悪意のある入力がツールの実装に到達するのを防いでください。

7. **レート制限**: サーバーリソースの乱用を防ぎ、公平な使用を確保するためにレート制限を実施してください。

### 実装のベストプラクティス

1. **機能交渉**: 接続設定時に、サポートされている機能、プロトコルバージョン、利用可能なツールやリソースに関する情報を交換してください。

2. **ツール設計**: 複数の関心事を扱うモノリシックなツールではなく、特定のタスクに特化したツールを作成してください。

3. **エラーハンドリング**: 問題の診断を助け、失敗を優雅に処理し、実用的なフィードバックを提供するために、標準化されたエラーメッセージとコードを実装してください。

4. **ログ記録**: プロトコルのインタラクションを監査、デバッグ、監視するために構造化されたログを設定してください。

5. **進捗追跡**: 長時間実行される操作については、進捗状況を報告し、応答性の高いユーザーインターフェースを可能にしてください。

6. **リクエストのキャンセル**: 必要なくなったり、時間がかかりすぎたりするリクエストをクライアントがキャンセルできるようにしてください。

## 追加の参考資料

MCPのベストプラクティスに関する最新情報については、以下を参照してください：

- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)
- [Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## 実践的な実装例

### ツール設計のベストプラクティス

#### 1. 単一責任の原則

各MCPツールは明確で焦点を絞った目的を持つべきです。複数の関心事を扱おうとするモノリシックなツールを作成するのではなく、特定のタスクに優れた専門的なツールを開発してください。

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

#### 2. 一貫したエラーハンドリング

情報豊富なエラーメッセージと適切な回復メカニズムを備えた堅牢なエラーハンドリングを実装してください。

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

#### 3. パラメータ検証

不正な入力や悪意のある入力を防ぐために、常にパラメータを徹底的に検証してください。

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

### セキュリティ実装例

#### 1. 認証と認可

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

#### 2. レート制限

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

## テストのベストプラクティス

### 1. MCPツールの単体テスト

外部依存関係をモックしてツールを単独でテストしてください：

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

### 2. 統合テスト

クライアントリクエストからサーバーレスポンスまでの完全なフローをテストしてください：

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

## パフォーマンス最適化

### 1. キャッシュ戦略

適切なキャッシュを実装して、レイテンシーとリソース使用量を削減してください：

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
// Javaの依存性注入を使用した例
public class CurrencyConversionTool implements Tool {
    private final ExchangeRateService exchangeService;
    private final CacheService cacheService;
    private final Logger logger;
    
    // コンストラクタを通じて依存性を注入
    public CurrencyConversionTool(
            ExchangeRateService exchangeService,
            CacheService cacheService,
            Logger logger) {
        this.exchangeService = exchangeService;
        this.cacheService = cacheService;
        this.logger = logger;
    }
    
    // ツールの実装
    // ...
}
```

#### 3. Composable Tools

Design tools that can be composed together to create more complex workflows:

```python
# Pythonの例：構成可能なツール
class DataFetchTool(Tool):
    def get_name(self):
        return "dataFetch"
    
    # 実装...

class DataAnalysisTool(Tool):
    def get_name(self):
        return "dataAnalysis"
    
    # このツールはdataFetchツールの結果を使用可能
    async def execute_async(self, request):
        # 実装...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # このツールはdataAnalysisツールの結果を使用可能
    async def execute_async(self, request):
        # 実装...
        pass

# これらのツールは独立して、またはワークフローの一部として使用可能
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
                description = "検索クエリテキスト。より正確なキーワードを使用してください。" 
            },
            filters = new {
                type = "object",
                description = "検索結果を絞り込むためのオプションフィルター",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "日付範囲（形式：YYYY-MM-DD:YYYY-MM-DD）" 
                    },
                    category = new { 
                        type = "string", 
                        description = "フィルター対象のカテゴリ名" 
                    }
                }
            },
            limit = new { 
                type = "integer", 
                description = "返される結果の最大数（1-50）",
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
    
    // Emailプロパティ（フォーマット検証付き）
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "ユーザーのメールアドレス");
    
    // Ageプロパティ（数値制約付き）
    Map<String, Object> age = new HashMap<>();
    age.put("type", "integer");
    age.put("minimum", 13);
    age.put("maximum", 120);
    age.put("description", "ユーザーの年齢（年単位）");
    
    // 列挙型プロパティ
    Map<String, Object> subscription = new HashMap<>();
    subscription.put("type", "string");
    subscription.put("enum", Arrays.asList("free", "basic", "premium"));
    subscription.put("default", "free");
    subscription.put("description", "サブスクリプションの階層");
    
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
        # リクエストを処理
        results = await self._search_database(request.parameters["query"])
        
        # 常に一貫した構造を返す
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
    """各アイテムが一貫した構造を持つことを保証"""
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
            throw new ToolExecutionException($"ファイルが見つかりません: {fileId}");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ToolExecutionException("このファイルにアクセスする権限がありません");
        }
        catch (Exception ex) when (ex is IOException || ex is TimeoutException)
        {
            _logger.LogError(ex, "ファイルへのアクセス中にエラーが発生しました {FileId}", fileId);
            throw new ToolExecutionException("ファイルへのアクセス中にエラーが発生しました：サービスが一時的に利用できません");
        }
    }
    catch (JsonException)
    {
        throw new ToolExecutionException("無効なファイルID形式");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "FileAccessToolで予期しないエラーが発生しました");
        throw new ToolExecutionException("予期しないエラーが発生しました");
    }
}
```

#### 2. Structured Error Responses

Return structured error information when possible:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    try {
        // 実装
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
        
        // 他の例外をToolExecutionExceptionとして再スロー
        throw new ToolExecutionException("ツールの実行に失敗しました: " + ex.getMessage(), ex);
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
            # 外部APIを呼び出し
            return await self._call_api(request.parameters)
        except TransientError as e:
            retry_count += 1
            if retry_count >= max_retries:
                raise ToolExecutionException(f"{max_retries}回の試行後に操作が失敗しました: {str(e)}")
                
            # 指数バックオフ
            delay = base_delay * (2 ** (retry_count - 1))
            logging.warning(f"一時的なエラー、{delay}秒後に再試行します: {str(e)}")
            await asyncio.sleep(delay)
        except Exception as e:
            # 非一時的なエラー、再試行しない
            raise ToolExecutionException(f"操作が失敗しました: {str(e)}")
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
    
    // パラメータに基づいてキャッシュキーを作成
    var cacheKey = $"data_query_{ComputeHash(query)}";
    
    // まずキャッシュから取得を試みる
    if (_cache.TryGetValue(cacheKey, out var cachedResult))
    {
        return new ToolResponse { Result = cachedResult };
    }
    
    // キャッシュミス - 実際のクエリを実行
    var result = await _database.QueryAsync(query);
    
    // キャッシュに保存（有効期限付き）
    var cacheOptions = new MemoryCacheEntryOptions()
        .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
        
    _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
    
    return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
}

private string ComputeHash(string input)
{
    // キャッシュキー用の安定したハッシュを生成する実装
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
        
        // 長時間実行される操作の場合、処理IDを即座に返す
        String processId = UUID.randomUUID().toString();
        
        // 非同期処理を開始
        CompletableFuture.runAsync(() -> {
            try {
                // 長時間実行される操作を実行
                documentService.processDocument(documentId);
                
                // ステータスを更新（通常はデータベースに保存される）
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // 処理IDを含む即時応答を返す
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // ステータス確認用の補助ツール
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
            tokens_per_second=5,  # 1秒あたり5リクエストを許可
            bucket_size=10        # 最大10リクエストのバーストを許可
        )
    
    async def execute_async(self, request):
        # 実行可能か、待機が必要かを確認
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # 待機時間が長すぎる場合
                raise ToolExecutionException(
                    f"レート制限を超えました。{delay:.1f}秒後に再試行してください。"
                )
            else:
                # 適切な待機時間を待つ
                await asyncio.sleep(delay)
        
        # トークンを消費してリクエストを続行
        self.rate_limiter.consume()
        
        # APIを呼び出す
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
            
            # 次のトークンが利用可能になるまでの時間を計算
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # 経過時間に基づいて新しいトークンを追加
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
    // パラメータが存在するか検証
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("必須パラメータが不足しています: query");
    }
    
    // 正しい型かどうかを検証
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("Queryパラメータは文字列である必要があります");
    }
    
    var query = queryProp.GetString();
    
    // 文字列の内容を検証
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("Queryパラメータは空であってはなりません");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("Queryパラメータは最大500文字を超えることはできません");
    }
    
    // 必要に応じてSQLインジェクション攻撃をチェック
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("無効なクエリ: 潜在的に安全でないSQLが含まれています");
    }
    
    // 実行を続行
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // リクエストからユーザーコンテキストを取得
    UserContext user = request.getContext().getUserContext();
    
    // ユーザーが必要な権限を持っているか確認
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("ユーザーにドキュメントへのアクセス権限がありません");
    }
    
    // 特定のリソースに対して、そのリソースへのアクセスを確認
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("要求されたドキュメントへのアクセスが拒否されました");
    }
    
    // ツールの実行を続行
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
        
        # ユーザーデータを取得
        user_data = await self.user_service.get_user_data(user_id)
        
        # 明示的に要求され、かつ認可されていない限り、機密フィールドをフィルタリング
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # リクエストコンテキスト内の認可レベルを確認
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # 元のデータを変更しないようコピーを作成
        redacted = user_data.copy()
        
        # 特定の機密フィールドをマスク
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # ネストされた機密データをマスク
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
    // 準備
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("Seattle", 3))
        .ReturnsAsync(new WeatherForecast(/* テストデータ */));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "Seattle", 
            days = 3 
        })
    );
    
    // 実行
    var response = await tool.ExecuteAsync(request);
    
    // 検証
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // 準備
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
    
    // 実行と検証
    var exception = await Assert.ThrowsAsync<ToolExecutionException>(
        () => tool.ExecuteAsync(request)
    );
    
    Assert.Contains("Location not found", exception.Message);
}
```

#### 2. Schema Validation Testing

Test that schemas are valid and properly enforce constraints:

```java
@Test
public void testSchemaValidation() {
    // ツールインスタンスを作成
    SearchTool searchTool = new SearchTool();
    
    // スキーマを取得
    Object schema = searchTool.getSchema();
    
    // スキーマをJSONに変換して検証
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // スキーマが有効なJSONSchemaであることを確認
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // 有効なパラメータをテスト
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // 必須パラメータが欠落している場合をテスト
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // 無効なパラメータ型をテスト
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
    # 準備
    tool = ApiTool(timeout=0.1)  # 非常に短いタイムアウト
    
    # タイムアウトするリクエストをモック
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # タイムアウトより長い
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # 実行と検証
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # 例外メッセージを確認
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # 準備
    tool = ApiTool()
    
    # レート制限されたレスポンスをモック
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
        
        # 実行と検証
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # 例外にレート制限情報が含まれていることを確認
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
    // 準備
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // 実行
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

// 確認
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
        // エンドポイントの検出をテスト
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // ツールリクエストを作成
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // リクエストを送信し、レスポンスを確認
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // 無効なツールリクエストを作成
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // パラメータ "b" が欠落
        request.put("parameters", parameters);
        
        // リクエストを送信し、エラーレスポンスを確認
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
    # 準備 - MCPクライアントとモックモデルを設定
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # モックモデルのレスポンス
    mock_model = MockLanguageModel([
        MockResponse(
            "シアトルの天気はどうですか？",
            tool_calls=[{
                "tool_name": "weatherForecast",
                "parameters": {"location": "Seattle", "days": 3}
            }]
        ),
        MockResponse(
            "シアトルの天気予報はこちらです：\n- 今日: 65°F, 曇り時々晴れ\n- 明日: 68°F, 晴れ\n- 明後日: 62°F, 雨",
            tool_calls=[]
        )
    ])
    
    # モック天気ツールのレスポンス
    with aioresponses() as mocked:
        mocked.post(
            "http://localhost:5000/mcp/execute",
            payload={
                "result": {
                    "location": "Seattle",
                    "forecast": [
                        {"date": "2023-06-01", "temperature": 65, "conditions": "曇り時々晴れ"},
                        {"date": "2023-06-02", "temperature": 68, "conditions": "晴れ"},
                        {"date": "2023-06-03", "temperature": 62, "conditions": "雨"}
                    ]
                }
            }
        )
        
        # 実行
        response = await mcp_client.send_prompt(
            "シアトルの天気はどうですか？",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # 確認
        assert "Seattle" in response.generated_text
        assert "65" in response.generated_text
        assert "晴れ" in response.generated_text
        assert "雨" in response.generated_text
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
    // 準備
    var server = new McpServer(
        name: "TestServer",
        version: "1.0",
        maxConcurrentRequests: 100
    );
    
    server.RegisterTool(new FastExecutingTool());
    await server.StartAsync();
    
    var client = new McpClient("http://localhost:5000");
    
    // 実行
    var tasks = new List<Task<McpResponse>>();
    for (int i = 0; i < 1000; i++)
    {
        tasks.Add(client.ExecuteToolAsync("fastTool", new { iteration = i }));
    }
    
    var results = await Task.WhenAll(tasks);
    
    // 確認
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
    
    // JMeterを使用したストレステストの設定
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // JMeterテストプランの構成
    HashTree testPlanTree = new HashTree();
    
    // テストプラン、スレッドグループ、サンプラーなどを作成
    TestPlan testPlan = new TestPlan("MCPサーバーストレステスト");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // ツール実行用のHTTPサンプラーを追加
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // リスナーを追加
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // テストを実行
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // 結果を検証
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // 平均応答時間 < 200ms
    assertTrue(summaryReport.getPercentile(90.0) < 500); // 90パーセンタイル < 500ms
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# MCPサーバーのモニタリングを設定
def configure_monitoring(server):
    # Prometheusメトリクスを設定
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "MCPリクエストの総数"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "リクエストの処理時間（秒）",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "ツール実行回数",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "ツール実行時間（秒）",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "ツール実行エラー",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # タイミングとメトリクス記録用のミドルウェアを追加
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # メトリクスエンドポイントを公開
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
# Python ツールチェーンの実装
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # 順番に実行するツール名のリスト
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # チェーン内の各ツールを実行し、前の結果を渡す
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # 結果を保存し、次のツールの入力として使用
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# 使用例
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
    public string Description => "さまざまなタイプのコンテンツを処理します";
    
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
        
        // 使用する専門ツールを決定
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // 専門ツールに転送
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
```
"csvProcessor"
("code", _) => "codeAnalyzer",
            _ => throw new ToolExecutionException($"指定された {contentType}/{operation} に対応するツールがありません")
        };
    }
    
    private object GetOptionsForTool(string toolName, string operation)
    {
        // 各専門ツールに適したオプションを返す
        return toolName switch
        {
            "textSummarizer" => new { length = "medium" },
            "htmlProcessor" => new { cleanUp = true, operation },
            // 他のツールのオプション...
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
        // ステップ1: データセットのメタデータを取得 (同期処理)
        ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata", 
            Map.of("datasetId", datasetId));
        
        // ステップ2: 複数の分析を並行して実行
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
        
        // 全ての並行タスクが完了するのを待つ
        CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
            statisticalAnalysis, correlationAnalysis, outlierDetection
        );
        
        allAnalyses.join();  // 完了を待機
        
        // ステップ3: 結果を統合
        Map<String, Object> combinedResults = new HashMap<>();
        combinedResults.put("metadata", metadataResponse.getResult());
        combinedResults.put("statistics", statisticalAnalysis.join().getResult());
        combinedResults.put("correlations", correlationAnalysis.join().getResult());
        combinedResults.put("outliers", outlierDetection.join().getResult());
        
        // ステップ4: サマリーレポートを生成
        ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator", 
            Map.of("analysisResults", combinedResults));
        
        // 完全なワークフロー結果を返す
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
            # まずはプライマリツールを試す
            response = await self.client.execute_tool(primary_tool, parameters)
            return {
                "result": response.result,
                "source": "primary",
                "tool": primary_tool
            }
        except ToolExecutionException as e:
            # 失敗をログに記録
            logging.warning(f"プライマリツール '{primary_tool}' が失敗しました: {str(e)}")
            
            # セカンダリツールにフォールバック
            try:
                # フォールバックツール用にパラメータを変換する必要があるかもしれません
                fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)
                
                response = await self.client.execute_tool(fallback_tool, fallback_params)
                return {
                    "result": response.result,
                    "source": "fallback",
                    "tool": fallback_tool,
                    "primaryError": str(e)
                }
            except ToolExecutionException as fallback_error:
                # 両方のツールが失敗
                logging.error(f"プライマリとフォールバックツールの両方が失敗しました。フォールバックエラー: {str(fallback_error)}")
                raise WorkflowExecutionException(
                    f"ワークフローが失敗しました: プライマリエラー: {str(e)}; フォールバックエラー: {str(fallback_error)}"
                )
    
    def _adapt_parameters(self, params, from_tool, to_tool):
        """異なるツール間でパラメータを適応させる"""
        # この実装は特定のツールに依存します
        # この例では元のパラメータをそのまま返します
        return params

# 使用例
async def get_weather(workflow, location):
    return await workflow.execute_with_fallback(
        "premiumWeatherService",  # プライマリ (有料) 天気API
        "basicWeatherService",    # フォールバック (無料) 天気API
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
            
            // 各ワークフローの結果を保存
            results[workflow.Name] = workflowResult;
            
            // 次のワークフローのために結果でコンテキストを更新
            context = context.WithResult(workflow.Name, workflowResult);
        }
        
        return new WorkflowResult(results);
    }
    
    public string Name => "CompositeWorkflow";
    public string Description => "複数のワークフローを順番に実行します";
}

// 使用例
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
// C#での計算ツールの単体テスト例
[Fact]
public async Task CalculatorTool_Add_ReturnsCorrectSum()
{
    // 準備
    var calculator = new CalculatorTool();
    var parameters = new Dictionary<string, object>
    {
        ["operation"] = "add",
        ["a"] = 5,
        ["b"] = 7
    };
    
    // 実行
    var response = await calculator.ExecuteAsync(parameters);
    var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());
    
    // 検証
    Assert.Equal(12, result.Value);
}
```

```python
# Pythonでの計算ツールの単体テスト例
def test_calculator_tool_add():
    # 準備
    calculator = CalculatorTool()
    parameters = {
        "operation": "add",
        "a": 5,
        "b": 7
    }
    
    # 実行
    response = calculator.execute(parameters)
    result = json.loads(response.content[0].text)
    
    # 検証
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
// C#でのMCPサーバーの統合テスト例
[Fact]
public async Task Server_ProcessToolRequest_ReturnsValidResponse()
{
    // 準備
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
    
    // 実行
    var response = await server.ProcessRequestAsync(request);
    
    // 検証
    Assert.NotNull(response);
    Assert.Equal(McpStatusCodes.Success, response.StatusCode);
    // レスポンス内容の追加検証
    
    // クリーンアップ
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
// TypeScriptでのクライアントを使ったE2Eテスト例
describe('MCP Server E2E Tests', () => {
  let client: McpClient;
  
  beforeAll(async () => {
    // テスト環境でサーバーを起動
    await startTestServer();
    client = new McpClient('http://localhost:5000');
  });
  
  afterAll(async () => {
    await stopTestServer();
  });
  
  test('クライアントが計算ツールを呼び出し、正しい結果を取得できる', async () => {
    // 実行
    const response = await client.invokeToolAsync('calculator', {
      operation: 'divide',
      a: 20,
      b: 4
    });
    
    // 検証
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
// C#でのMoqを使った例
var mockModel = new Mock<ILanguageModel>();
mockModel
    .Setup(m => m.GenerateResponseAsync(
        It.IsAny<string>(),
        It.IsAny<McpRequestContext>()))
    .ReturnsAsync(new ModelResponse { 
        Text = "モックされたモデルのレスポンス",
        FinishReason = FinishReason.Completed
    });

var server = new McpServer(modelClient: mockModel.Object);
```

```python
# Pythonでのunittest.mockを使った例
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
    # モックの設定
    mock_model.return_value.generate_response.return_value = {
        "text": "モックされたモデルのレスポンス",
        "finish_reason": "completed"
    }
    
    # テストでモックを使用
    server = McpServer(model_client=mock_model)
    # テストを続行
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
// MCPサーバーの負荷テスト用k6スクリプト
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  vus: 10,  // 10仮想ユーザー
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
    
    - name: ランタイムのセットアップ
      uses: actions/setup-dotnet@v1
      with:
        dotnet-version: '8.0.x'
    
    - name: 依存関係の復元
      run: dotnet restore
    
    - name: ビルド
      run: dotnet build --no-restore
    
    - name: 単体テスト
      run: dotnet test --no-build --filter Category=Unit
    
    - name: 統合テスト
      run: dotnet test --no-build --filter Category=Integration
      
    - name: パフォーマンステスト
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
    // 準備
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");
    
    // 実行
    var response = await client.GetAsync("http://localhost:5000/api/resources");
    var content = await response.Content.ReadAsStringAsync();
    var resources = JsonSerializer.Deserialize

## MCPサーバーテストを効果的に行うためのトップ10のヒント

1. **ツール定義を個別にテストする**: ツールのロジックとは別にスキーマ定義を検証する  
2. **パラメータ化されたテストを使用する**: 様々な入力（エッジケースを含む）でツールをテストする  
3. **エラーレスポンスを確認する**: すべての可能なエラー条件に対して適切なエラーハンドリングを検証する  
4. **認可ロジックをテストする**: 異なるユーザーロールに対して適切なアクセス制御を確認する  
5. **テストカバレッジを監視する**: 重要なコードパスの高いカバレッジを目指す  
6. **ストリーミングレスポンスをテストする**: ストリーミングコンテンツの適切な処理を確認する  
7. **ネットワーク問題をシミュレートする**: ネットワークが不安定な状況での挙動をテストする  
8. **リソース制限をテストする**: クォータやレート制限に達した場合の挙動を検証する  
9. **回帰テストを自動化する**: コード変更ごとに実行されるスイートを構築する  
10. **テストケースを文書化する**: テストシナリオの明確なドキュメントを維持する  

## テストにおける一般的な落とし穴

- **ハッピーパステストへの過度な依存**: エラーケースを徹底的にテストすることを忘れない  
- **パフォーマンステストの無視**: 本番環境に影響を与える前にボトルネックを特定する  
- **孤立したテストのみを行う**: ユニットテスト、統合テスト、E2Eテストを組み合わせる  
- **APIカバレッジの不完全さ**: すべてのエンドポイントと機能をテストする  
- **一貫性のないテスト環境**: コンテナを使用して一貫したテスト環境を確保する  

## 結論

包括的なテスト戦略は、信頼性が高く高品質なMCPサーバーを開発するために不可欠です。このガイドで紹介したベストプラクティスやヒントを実践することで、MCPの実装が最高水準の品質、信頼性、パフォーマンスを満たすことを保証できます。

## 重要なポイント

1. **ツール設計**: 単一責任の原則に従い、依存性注入を使用し、再利用可能な設計を目指す  
2. **スキーマ設計**: 明確で適切なバリデーション制約を持つスキーマを作成し、文書化する  
3. **エラーハンドリング**: 優雅なエラーハンドリング、構造化されたエラーレスポンス、リトライロジックを実装する  
4. **パフォーマンス**: キャッシング、非同期処理、リソーススロットリングを活用する  
5. **セキュリティ**: 入力バリデーション、認可チェック、機密データの適切な取り扱いを徹底する  
6. **テスト**: 包括的なユニットテスト、統合テスト、エンドツーエンドテストを作成する  
7. **ワークフローパターン**: チェーン、ディスパッチャー、並列処理などの確立されたパターンを適用する  

## 演習

以下の要件を満たす文書処理システムのためのMCPツールとワークフローを設計してください：

1. 複数の形式（PDF、DOCX、TXT）の文書を受け入れる  
2. 文書からテキストと主要な情報を抽出する  
3. 文書を種類や内容に基づいて分類する  
4. 各文書の要約を生成する  

このシナリオに最適なツールスキーマ、エラーハンドリング、ワークフローパターンを実装してください。また、この実装をどのようにテストするかを検討してください。

## リソース

1. 最新情報を得るために[Azure AI Foundry Discord Community](https://aka.ms/foundrydevs)でMCPコミュニティに参加する  
2. オープンソースの[MCPプロジェクト](https://github.com/modelcontextprotocol)に貢献する  
3. 自身の組織のAIイニシアチブにMCPの原則を適用する  
4. 業界向けの専門的なMCP実装を探求する  
5. マルチモーダル統合やエンタープライズアプリケーション統合など、特定のMCPトピックに関する高度なコースを受講する  
6. [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)を通じて学んだ原則を使い、自分自身のMCPツールやワークフローを構築してみる  

次へ: ベストプラクティス[ケーススタディ](../09-CaseStudy/README.md)  

**免責事項**:  
この文書は、AI翻訳サービス [Co-op Translator](https://github.com/Azure/co-op-translator) を使用して翻訳されています。正確性を追求しておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。元の言語で記載された原文が正式な情報源と見なされるべきです。重要な情報については、専門の人間による翻訳を推奨します。この翻訳の利用に起因する誤解や誤認について、当方は一切の責任を負いません。