<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1827d0f7a6430dfb7adcdd5f1ee05bda",
  "translation_date": "2025-07-29T00:07:18+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "ja"
}
-->
# MCP開発のベストプラクティス

[![MCP開発のベストプラクティス](../../../translated_images/09.d0f6d86c9d72134ccf5a8d8c8650a0557e519936661fc894cad72d73522227cb.ja.png)](https://youtu.be/W56H9W7x-ao)

_(上の画像をクリックすると、このレッスンのビデオをご覧いただけます)_

## 概要

このレッスンでは、MCPサーバーや機能を本番環境で開発、テスト、デプロイする際の高度なベストプラクティスに焦点を当てます。MCPエコシステムが複雑化し、重要性が増す中、確立されたパターンに従うことで、信頼性、保守性、相互運用性を確保できます。このレッスンでは、実際のMCP実装から得られた実践的な知見を集約し、堅牢で効率的なサーバーを作成するためのリソース、プロンプト、ツールを効果的に活用する方法をガイドします。

## 学習目標

このレッスンを終えると、以下ができるようになります：

- MCPサーバーと機能設計における業界のベストプラクティスを適用する
- MCPサーバーの包括的なテスト戦略を作成する
- 複雑なMCPアプリケーション向けの効率的で再利用可能なワークフローパターンを設計する
- MCPサーバーで適切なエラーハンドリング、ログ記録、可観測性を実装する
- パフォーマンス、セキュリティ、保守性を最適化したMCP実装を行う

## MCPの基本原則

具体的な実装のプラクティスに入る前に、効果的なMCP開発を導く基本原則を理解することが重要です：

1. **標準化された通信**: MCPはJSON-RPC 2.0を基盤としており、すべての実装でリクエスト、レスポンス、エラーハンドリングの一貫した形式を提供します。

2. **ユーザー中心の設計**: MCP実装では常にユーザーの同意、コントロール、透明性を優先してください。

3. **セキュリティ第一**: 認証、認可、検証、レート制限を含む堅牢なセキュリティ対策を実装してください。

4. **モジュール型アーキテクチャ**: 各ツールやリソースが明確で焦点を絞った目的を持つように、モジュール型のアプローチでMCPサーバーを設計してください。

5. **ステートフルな接続**: 複数のリクエスト間で状態を維持するMCPの能力を活用し、より一貫性があり、コンテキストに応じたインタラクションを実現してください。

## 公式MCPベストプラクティス

以下のベストプラクティスは、公式のModel Context Protocolドキュメントに基づいています：

### セキュリティのベストプラクティス

1. **ユーザーの同意とコントロール**: データへのアクセスや操作を行う前に、必ず明示的なユーザーの同意を得てください。共有されるデータや許可されるアクションを明確にコントロールできるようにしてください。

2. **データプライバシー**: 明示的な同意がある場合のみユーザーデータを公開し、適切なアクセス制御で保護してください。不正なデータ送信を防ぐ措置を講じてください。

3. **ツールの安全性**: ツールを呼び出す前に必ず明示的なユーザーの同意を得てください。各ツールの機能をユーザーが理解できるようにし、堅牢なセキュリティ境界を確保してください。

4. **ツールの権限管理**: セッション中にモデルが使用できるツールを設定し、明示的に許可されたツールのみがアクセス可能であることを確認してください。

5. **認証**: APIキー、OAuthトークン、その他の安全な認証方法を使用して、ツール、リソース、または機密操作へのアクセスを許可する前に適切な認証を要求してください。

6. **パラメータ検証**: ツールの呼び出しに対してすべてのパラメータを検証し、不正または悪意のある入力がツールの実装に到達しないようにしてください。

7. **レート制限**: サーバーリソースの乱用を防ぎ、公平な使用を確保するためにレート制限を実装してください。

### 実装のベストプラクティス

1. **機能交渉**: 接続のセットアップ時に、サポートされている機能、プロトコルバージョン、利用可能なツールやリソースに関する情報を交換してください。

2. **ツール設計**: 複数の関心事を扱うモノリシックなツールではなく、1つのことをうまく行うことに特化したツールを作成してください。

3. **エラーハンドリング**: 問題の診断を助け、失敗を優雅に処理し、実行可能なフィードバックを提供するために、標準化されたエラーメッセージとコードを実装してください。

4. **ログ記録**: プロトコルのインタラクションを監査、デバッグ、監視するために構造化されたログを設定してください。

5. **進捗追跡**: 長時間実行される操作については、進捗状況を報告し、応答性の高いユーザーインターフェースを可能にしてください。

6. **リクエストのキャンセル**: 必要なくなった、または時間がかかりすぎている進行中のリクエストをクライアントがキャンセルできるようにしてください。

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

不正または悪意のある入力を防ぐために、常にパラメータを徹底的に検証してください。

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

適切なキャッシュを実装して、レイテンシとリソース使用量を削減してください：

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
    
    // 有効期限付きでキャッシュに保存
    var cacheOptions = new MemoryCacheEntryOptions()
        .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
        
    _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
    
    return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
}

private string ComputeHash(string input)
{
    // キャッシュキー用の安定したハッシュを生成する実装
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
        
        # トークンを消費してリクエストを進める
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
        throw new ToolExecutionException("無効なクエリ: 潜在的に危険なSQLが含まれています");
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
        throw new ToolExecutionException("ユーザーにはドキュメントにアクセスする権限がありません");
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
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # タイムアウトを超える
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
        // ツールの発見エンドポイントをテスト
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
            "シアトルの天気予報はこちらです:\n- 今日: 65°F, 曇り時々晴れ\n- 明日: 68°F, 晴れ\n- 明後日: 62°F, 雨",
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
    
    // JMeterを設定してストレステストを実施
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // JMeterテストプランを構成
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
# MCPサーバーの監視を設定
def configure_monitoring(server):
    # Prometheusメトリクスを設定
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "MCPリクエストの総数"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "リクエストの秒単位の所要時間",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "ツール実行回数",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "ツール実行の秒単位の所要時間",
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
# Pythonツールチェーンの実装
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # 順番に実行するツール名のリスト
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # チェーン内の各ツールを実行し、前の結果を渡す
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # 結果を保存し、次のツールへの入力として使用
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
            ("csv", _) => "csvProcessor",
            _ => throw new InvalidOperationException("Unsupported content type or operation")
        };
    }
}
```
"csvProcessor"
```csharp
// Arrange
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");
    
    // Act
    var response = await client.GetAsync("http://localhost:5000/api/resources");
    var content = await response.Content.ReadAsStringAsync();
    var resources = JsonSerializer.Deserialize
```

# MCPサーバーテストのベストプラクティス

MCP（Model Context Protocol）サーバーのテストは、信頼性が高く高品質なシステムを構築するために不可欠です。このガイドでは、MCPサーバーのテストを効果的に行うためのベストプラクティスとヒントを紹介します。

## MCPサーバーテストの基本原則

1. **スキーマ定義を検証する**  
   MCPツールのスキーマ定義は、ツールのロジックとは独立して検証する必要があります。これにより、スキーマの正確性を確保できます。

2. **ツールのロジックをテストする**  
   MCPツールのロジックをテストし、期待される動作を確認します。これには、エッジケースや異常な入力も含めてテストすることが重要です。

3. **エンドツーエンドのワークフローをテストする**  
   MCPサーバーの全体的なワークフローをテストし、ツール間の相互作用が正しく機能していることを確認します。

4. **エラー処理を検証する**  
   適切なエラー処理が行われていることを確認します。これには、エラーコード、メッセージ、リトライロジックの検証が含まれます。

5. **パフォーマンスを測定する**  
   MCPサーバーのパフォーマンスを測定し、ボトルネックを特定します。これには、負荷テストやスケーラビリティテストが含まれます。

6. **セキュリティをテストする**  
   入力検証、認可チェック、データ保護など、セキュリティ関連のテストを実施します。

## MCPサーバーテストの例

以下は、MCPサーバーのテストを実施する際のコード例です。

```csharp
// Arrange
var client = new HttpClient();
var request = new HttpRequestMessage(HttpMethod.Get, "https://example.com/api/resources");

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
    // 追加のスキーマ検証
});
}
```

## 効果的なMCPサーバーテストのためのトップ10のヒント

1. **ツールの定義を個別にテストする**: スキーマ定義をツールロジックから独立して検証する  
2. **パラメータ化されたテストを使用する**: エッジケースを含む多様な入力でツールをテストする  
3. **エラーレスポンスを確認する**: すべてのエラー条件に対して適切なエラー処理を検証する  
4. **認可ロジックをテストする**: 異なるユーザーロールに対する適切なアクセス制御を確認する  
5. **テストカバレッジを監視する**: 重要なコードパスの高いカバレッジを目指す  
6. **ストリーミングレスポンスをテストする**: ストリーミングコンテンツの適切な処理を確認する  
7. **ネットワーク問題をシミュレートする**: ネットワークが不安定な状況での動作をテストする  
8. **リソース制限をテストする**: クォータやレート制限に達した場合の動作を確認する  
9. **回帰テストを自動化する**: コード変更ごとに実行されるスイートを構築する  
10. **テストケースを文書化する**: テストシナリオの明確なドキュメントを維持する  

## よくあるテストの落とし穴

- **ハッピーパステストへの過度な依存**: エラーケースを徹底的にテストすることを忘れない  
- **パフォーマンステストの無視**: 本番環境に影響が出る前にボトルネックを特定する  
- **孤立したテストのみを実施**: ユニットテスト、統合テスト、エンドツーエンドテストを組み合わせる  
- **APIカバレッジの不完全さ**: すべてのエンドポイントと機能をテストする  
- **一貫性のないテスト環境**: コンテナを使用して一貫性のあるテスト環境を確保する  

## 結論

包括的なテスト戦略は、信頼性が高く高品質なMCPサーバーを開発するために不可欠です。このガイドで紹介したベストプラクティスとヒントを実践することで、MCP実装が最高水準の品質、信頼性、パフォーマンスを満たすことを保証できます。

## 重要なポイント

1. **ツール設計**: 単一責任の原則に従い、依存性注入を使用し、再利用可能な設計を行う  
2. **スキーマ設計**: 明確で適切な検証制約を持つスキーマを作成する  
3. **エラー処理**: 優雅なエラー処理、構造化されたエラーレスポンス、リトライロジックを実装する  
4. **パフォーマンス**: キャッシュ、非同期処理、リソーススロットリングを活用する  
5. **セキュリティ**: 入力検証、認可チェック、機密データの取り扱いを徹底する  
6. **テスト**: 包括的なユニットテスト、統合テスト、エンドツーエンドテストを作成する  
7. **ワークフローパターン**: チェーン、ディスパッチャー、並列処理などの確立されたパターンを適用する  

## 演習

以下の要件を満たすドキュメント処理システムのMCPツールとワークフローを設計してください。

1. 複数の形式（PDF、DOCX、TXT）のドキュメントを受け入れる  
2. ドキュメントからテキストと主要情報を抽出する  
3. ドキュメントを種類と内容で分類する  
4. 各ドキュメントの要約を生成する  

このシナリオに最適なツールスキーマ、エラー処理、ワークフローパターンを実装してください。また、この実装をどのようにテストするかを検討してください。

## リソース

1. 最新情報を得るために[MCPコミュニティ](https://aka.ms/foundrydevs)に参加する  
2. オープンソースの[MCPプロジェクト](https://github.com/modelcontextprotocol)に貢献する  
3. 自身の組織のAIイニシアチブにMCPの原則を適用する  
4. 業界に特化したMCP実装を探求する  
5. マルチモーダル統合やエンタープライズアプリケーション統合など、特定のMCPトピックに関する高度なコースを受講する  
6. [ハンズオンラボ](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)を通じて学んだ原則を使用して、自分のMCPツールとワークフローを構築する  

次へ: ベストプラクティス[ケーススタディ](../09-CaseStudy/README.md)

**免責事項**:  
この文書は、AI翻訳サービス [Co-op Translator](https://github.com/Azure/co-op-translator) を使用して翻訳されています。正確性を追求しておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があることをご承知おきください。元の言語で記載された文書が公式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。この翻訳の使用に起因する誤解や誤認について、当方は一切の責任を負いません。