<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "80e5c8949af5af0f401fce6f905990aa",
  "translation_date": "2025-07-17T07:20:33+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "he"
}
-->
# שיטות עבודה מומלצות לפיתוח MCP

## סקירה כללית

השיעור הזה מתמקד בשיטות עבודה מתקדמות לפיתוח, בדיקה ופריסה של שרתי MCP ותכונות בסביבות ייצור. ככל שמערכות ה-MCP מתפתחות ומורכבות יותר, שמירה על דפוסים מוכחים מבטיחה אמינות, תחזוקה ויכולת אינטגרציה. שיעור זה מרכז חכמה מעשית שנרכשה מיישומי MCP אמיתיים כדי להנחות אותך ביצירת שרתים יציבים, יעילים עם משאבים, פרומפטים וכלים אפקטיביים.

## מטרות הלמידה

בסיום השיעור תוכל:
- ליישם שיטות עבודה מומלצות בתכנון שרתי MCP ותכונותיהם
- ליצור אסטרטגיות בדיקה מקיפות לשרתי MCP
- לתכנן דפוסי עבודה יעילים וניתנים לשימוש חוזר עבור יישומי MCP מורכבים
- ליישם טיפול שגיאות, רישום ותצפית נכונים בשרתי MCP
- לאופטם יישומי MCP מבחינת ביצועים, אבטחה ותחזוקה

## עקרונות הליבה של MCP

לפני שנכנסים לפרקטיקות יישום ספציפיות, חשוב להבין את העקרונות המרכזיים שמנחים פיתוח MCP אפקטיבי:

1. **תקשורת סטנדרטית**: MCP מבוסס על JSON-RPC 2.0, המספק פורמט אחיד לבקשות, תגובות וטיפול בשגיאות בכל היישומים.

2. **עיצוב ממוקד משתמש**: תמיד תעדיף הסכמה, שליטה ושקיפות למשתמש ביישומי MCP שלך.

3. **אבטחה בראש סדר העדיפויות**: יישם אמצעי אבטחה חזקים הכוללים אימות, הרשאה, אימות נתונים והגבלת קצב.

4. **ארכיטקטורה מודולרית**: עצב את שרתי MCP בגישה מודולרית, כאשר לכל כלי ומשאב יש מטרה ברורה וממוקדת.

5. **חיבורים עם שמירת מצב**: נצל את יכולת MCP לשמור על מצב בין בקשות מרובות לאינטראקציות קוהרנטיות ומודעות להקשר.

## שיטות עבודה מומלצות רשמיות ל-MCP

שיטות העבודה הבאות נגזרות מתיעוד רשמי של Model Context Protocol:

### שיטות עבודה מומלצות לאבטחה

1. **הסכמה ושליטה של המשתמש**: תמיד דרוש הסכמה מפורשת מהמשתמש לפני גישה לנתונים או ביצוע פעולות. ספק שליטה ברורה על אילו נתונים משותפים ואילו פעולות מורשות.

2. **פרטיות נתונים**: חשוף נתוני משתמש רק עם הסכמה מפורשת והגן עליהם באמצעות בקרות גישה מתאימות. הגן מפני העברת נתונים לא מורשית.

3. **בטיחות כלים**: דרוש הסכמה מפורשת לפני הפעלת כל כלי. ודא שהמשתמשים מבינים את תפקוד כל כלי ואכוף גבולות אבטחה חזקים.

4. **בקרת הרשאות לכלים**: הגדר אילו כלים המודל מורשה להשתמש בהם במהלך סשן, כך שרק כלים מורשים יהיו נגישים.

5. **אימות**: דרוש אימות תקין לפני מתן גישה לכלים, משאבים או פעולות רגישות באמצעות מפתחות API, אסימוני OAuth או שיטות אימות מאובטחות אחרות.

6. **אימות פרמטרים**: אכוף אימות לכל קריאות הכלים כדי למנוע קלט שגוי או זדוני מלהגיע ליישום הכלים.

7. **הגבלת קצב**: יישם הגבלת קצב למניעת ניצול לרעה ולהבטחת שימוש הוגן במשאבי השרת.

### שיטות עבודה מומלצות ליישום

1. **משא ומתן על יכולות**: במהלך הקמת החיבור, החלף מידע על תכונות נתמכות, גרסאות פרוטוקול, כלים ומשאבים זמינים.

2. **עיצוב כלים**: צור כלים ממוקדים שעושים דבר אחד טוב, במקום כלים מונוליתיים שמטפלים במספר נושאים.

3. **טיפול בשגיאות**: יישם הודעות שגיאה וקודים סטנדרטיים שיעזרו באבחון בעיות, טיפול בכשלים בצורה חלקה ומתן משוב שניתן לפעול לפיו.

4. **רישום**: הגדר לוגים מובנים לצורך ביקורת, איתור באגים ומעקב אחר אינטראקציות בפרוטוקול.

5. **מעקב התקדמות**: עבור פעולות ארוכות, דווח על עדכוני התקדמות כדי לאפשר ממשקי משתמש רספונסיביים.

6. **ביטול בקשות**: אפשר ללקוחות לבטל בקשות בתהליך שאינן נדרשות עוד או שלוקחות זמן רב מדי.

## הפניות נוספות

לקבלת המידע העדכני ביותר על שיטות עבודה מומלצות ל-MCP, עיין ב:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)
- [Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## דוגמאות ליישום מעשי

### שיטות עבודה מומלצות לעיצוב כלים

#### 1. עיקרון האחריות היחידה

כל כלי MCP צריך להיות בעל מטרה ברורה וממוקדת. במקום ליצור כלים מונוליתיים שמנסים לטפל במספר נושאים, פתח כלים מתמחים שמצטיינים במשימות ספציפיות.

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

#### 2. טיפול שגיאות עקבי

יישם טיפול שגיאות חזק עם הודעות שגיאה אינפורמטיביות ומנגנוני התאוששות מתאימים.

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

#### 3. אימות פרמטרים

תמיד אמת פרמטרים ביסודיות כדי למנוע קלט שגוי או זדוני.

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

### דוגמאות ליישום אבטחה

#### 1. אימות והרשאה

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

#### 2. הגבלת קצב

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

## שיטות עבודה מומלצות לבדיקות

### 1. בדיקות יחידה לכלי MCP

תמיד בדוק את הכלים שלך בנפרד, תוך שימוש במוקינג של תלות חיצוניות:

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

### 2. בדיקות אינטגרציה

בדוק את הזרימה המלאה מבקשות הלקוח לתגובות השרת:

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

## אופטימיזציה של ביצועים

### 1. אסטרטגיות מטמון

יישם מטמון מתאים כדי להפחית השהיה ושימוש במשאבים:

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
// דוגמה ב-Java עם הזרקת תלות
public class CurrencyConversionTool implements Tool {
    private final ExchangeRateService exchangeService;
    private final CacheService cacheService;
    private final Logger logger;
    
    // תלות מוזרקת דרך הקונסטרקטור
    public CurrencyConversionTool(
            ExchangeRateService exchangeService,
            CacheService cacheService,
            Logger logger) {
        this.exchangeService = exchangeService;
        this.cacheService = cacheService;
        this.logger = logger;
    }
    
    // יישום הכלי
    // ...
}
```

#### 3. Composable Tools

Design tools that can be composed together to create more complex workflows:

```python
# דוגמה בפייתון המציגה כלים קומפוזביליים
class DataFetchTool(Tool):
    def get_name(self):
        return "dataFetch"
    
    # יישום...

class DataAnalysisTool(Tool):
    def get_name(self):
        return "dataAnalysis"
    
    # כלי זה יכול להשתמש בתוצאות של dataFetch
    async def execute_async(self, request):
        # יישום...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # כלי זה יכול להשתמש בתוצאות של dataAnalysis
    async def execute_async(self, request):
        # יישום...
        pass

# כלים אלה ניתנים לשימוש עצמאי או כחלק מזרימת עבודה
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
                description = "טקסט שאילתת חיפוש. השתמש במילות מפתח מדויקות לתוצאות טובות יותר." 
            },
            filters = new {
                type = "object",
                description = "מסננים אופציונליים לצמצום תוצאות החיפוש",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "טווח תאריכים בפורמט YYYY-MM-DD:YYYY-MM-DD" 
                    },
                    category = new { 
                        type = "string", 
                        description = "שם קטגוריה לסינון" 
                    }
                }
            },
            limit = new { 
                type = "integer", 
                description = "מספר מקסימלי של תוצאות להחזרה (1-50)",
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
    
    // מאפיין אימייל עם אימות פורמט
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "כתובת אימייל של המשתמש");
    
    // מאפיין גיל עם מגבלות מספריות
    Map<String, Object> age = new HashMap<>();
    age.put("type", "integer");
    age.put("minimum", 13);
    age.put("maximum", 120);
    age.put("description", "גיל המשתמש בשנים");
    
    // מאפיין עם ערכים מוגדרים מראש
    Map<String, Object> subscription = new HashMap<>();
    subscription.put("type", "string");
    subscription.put("enum", Arrays.asList("free", "basic", "premium"));
    subscription.put("default", "free");
    subscription.put("description", "רמת המנוי");
    
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
        # עיבוד הבקשה
        results = await self._search_database(request.parameters["query"])
        
        # תמיד החזר מבנה עקבי
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
    """מבטיח שכל פריט יהיה במבנה עקבי"""
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
            throw new ToolExecutionException($"הקובץ לא נמצא: {fileId}");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ToolExecutionException("אין לך הרשאה לגשת לקובץ זה");
        }
        catch (Exception ex) when (ex is IOException || ex is TimeoutException)
        {
            _logger.LogError(ex, "שגיאה בגישה לקובץ {FileId}", fileId);
            throw new ToolExecutionException("שגיאה בגישה לקובץ: השירות אינו זמין כרגע");
        }
    }
    catch (JsonException)
    {
        throw new ToolExecutionException("פורמט מזהה הקובץ שגוי");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "שגיאה בלתי צפויה ב-FileAccessTool");
        throw new ToolExecutionException("אירעה שגיאה בלתי צפויה");
    }
}
```

#### 2. Structured Error Responses

Return structured error information when possible:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    try {
        // יישום
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
        
        // זרוק מחדש חריגות אחרות כ-ToolExecutionException
        throw new ToolExecutionException("הפעלת הכלי נכשלה: " + ex.getMessage(), ex);
    }
}
```

#### 3. Retry Logic

Implement appropriate retry logic for transient failures:

```python
async def execute_async(self, request):
    max_retries = 3
    retry_count = 0
    base_delay = 1  # שניות
    
    while retry_count < max_retries:
        try:
            # קריאה ל-API חיצוני
            return await self._call_api(request.parameters)
        except TransientError as e:
            retry_count += 1
            if retry_count >= max_retries:
                raise ToolExecutionException(f"הפעולה נכשלה לאחר {max_retries} ניסיונות: {str(e)}")
                
            # השהייה אקספוננציאלית
            delay = base_delay * (2 ** (retry_count - 1))
            logging.warning(f"שגיאה זמנית, ניסיון חוזר בעוד {delay} שניות: {str(e)}")
            await asyncio.sleep(delay)
        except Exception as e:
            # שגיאה לא זמנית, אין ניסיון חוזר
            raise ToolExecutionException(f"הפעולה נכשלה: {str(e)}")
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
<ToolResponse>
ExecuteAsync(ToolRequest request)
    {
        var query = request.Parameters.GetProperty("query").GetString();
        
        // יצירת מפתח מטמון בהתבסס על הפרמטרים
        var cacheKey = $"data_query_{ComputeHash(query)}";
        
        // ניסיון לקבל מהמטמון קודם כל
        if (_cache.TryGetValue(cacheKey, out var cachedResult))
        {
            return new ToolResponse { Result = cachedResult };
        }
        
        // החמצת מטמון - ביצוע השאילתה בפועל
        var result = await _database.QueryAsync(query);
        
        // אחסון במטמון עם תוקף
        var cacheOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
            
        _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
        
        return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
    }
    
    private string ComputeHash(string input)
    {
        // מימוש ליצירת hash יציב למפתח המטמון
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
        
        // עבור פעולות ארוכות טווח, מחזירים מיד מזהה עיבוד
        String processId = UUID.randomUUID().toString();
        
        // התחלת עיבוד אסינכרוני
        CompletableFuture.runAsync(() -> {
            try {
                // ביצוע פעולה ארוכת טווח
                documentService.processDocument(documentId);
                
                // עדכון סטטוס (בדרך כלל יאוחסן בבסיס נתונים)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // החזרת תגובה מיידית עם מזהה התהליך
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // כלי בדיקת סטטוס נלווה
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
            tokens_per_second=5,  # מאפשר 5 בקשות לשנייה
            bucket_size=10        # מאפשר התפרצויות של עד 10 בקשות
        )
    
    async def execute_async(self, request):
        # בדיקה אם אפשר להמשיך או צריך להמתין
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # אם ההמתנה ארוכה מדי
                raise ToolExecutionException(
                    f"חריגת מגבלת קצב. אנא נסה שוב בעוד {delay:.1f} שניות."
                )
            else:
                # המתנה לזמן המתאים
                await asyncio.sleep(delay)
        
        # צריכת אסימון והמשך בבקשה
        self.rate_limiter.consume()
        
        # קריאה ל-API
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
            
            # חישוב זמן עד לאסימון הבא הזמין
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # הוספת אסימונים חדשים בהתבסס על הזמן שחלף
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
    // אימות שקיימים פרמטרים
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("חסר פרמטר חובה: query");
    }
    
    // אימות סוג נכון
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("פרמטר query חייב להיות מחרוזת");
    }
    
    var query = queryProp.GetString();
    
    // אימות תוכן המחרוזת
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("פרמטר query לא יכול להיות ריק");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("פרמטר query חורג מאורך מקסימלי של 500 תווים");
    }
    
    // בדיקה להתקפות SQL injection אם רלוונטי
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("שאילתה לא חוקית: מכילה SQL מסוכן פוטנציאלי");
    }
    
    // המשך ביצוע
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // קבלת הקשר משתמש מהבקשה
    UserContext user = request.getContext().getUserContext();
    
    // בדיקה אם למשתמש יש הרשאות נדרשות
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("למשתמש אין הרשאה לגשת למסמכים");
    }
    
    // עבור משאבים ספציפיים, בדוק גישה למשאב
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("הגישה למסמך המבוקש נדחתה");
    }
    
    // המשך ביצוע הכלי
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
        
        # קבלת נתוני המשתמש
        user_data = await self.user_service.get_user_data(user_id)
        
        # סינון שדות רגישים אלא אם כן נדרש במפורש ועם הרשאה
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # בדיקת רמת הרשאה בהקשר הבקשה
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # יצירת עותק כדי לא לשנות את המקורי
        redacted = user_data.copy()
        
        # טשטוש שדות רגישים ספציפיים
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # טשטוש נתונים רגישים מקוננים
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
    // סידור
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("Seattle", 3))
        .ReturnsAsync(new WeatherForecast(/* נתוני בדיקה */));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "Seattle", 
            days = 3 
        })
    );
    
    // ביצוע
    var response = await tool.ExecuteAsync(request);
    
    // אימות
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // סידור
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
    
    // ביצוע ואימות
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
    // יצירת מופע של הכלי
    SearchTool searchTool = new SearchTool();
    
    // קבלת הסכמה
    Object schema = searchTool.getSchema();
    
    // המרת הסכמה ל-JSON לצורך אימות
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // אימות שהסכמה היא JSONSchema תקין
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // בדיקת פרמטרים תקינים
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // בדיקת פרמטר חובה חסר
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // בדיקת סוג פרמטר לא תקין
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
    # סידור
    tool = ApiTool(timeout=0.1)  # זמן קצוב קצר מאוד
    
    # הדמיית בקשה שתיגמר בזמן
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # ארוך מהזמן הקצוב
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # ביצוע ואימות
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # אימות הודעת החריגה
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # סידור
    tool = ApiTool()
    
    # הדמיית תגובה עם הגבלת קצב
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
        
        # ביצוע ואימות
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # אימות שהחריגה מכילה מידע על הגבלת קצב
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
    // סידור
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // ביצוע
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
        // בדוק את נקודת הקצה לגילוי כלים
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // צור בקשת כלי
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // שלח את הבקשה ואמת את התגובה
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // צור בקשת כלי לא תקינה
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // חסר הפרמטר "b"
        request.put("parameters", parameters);
        
        // שלח את הבקשה ואמת את תגובת השגיאה
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
    # סידור - הגדר לקוח MCP ודגם מדומה
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # תגובות מדומות של הדגם
    mock_model = MockLanguageModel([
        MockResponse(
            "מה מזג האוויר בסיאטל?",
            tool_calls=[{
                "tool_name": "weatherForecast",
                "parameters": {"location": "Seattle", "days": 3}
            }]
        ),
        MockResponse(
            "הנה תחזית מזג האוויר לסיאטל:\n- היום: 65°F, מעונן חלקית\n- מחר: 68°F, שמשי\n- מחרתיים: 62°F, גשם",
            tool_calls=[]
        )
    ])
    
    # תגובת כלי מזג האוויר המדומה
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
        
        # ביצוע
        response = await mcp_client.send_prompt(
            "מה מזג האוויר בסיאטל?",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # אימות
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
    // סידור
    var server = new McpServer(
        name: "TestServer",
        version: "1.0",
        maxConcurrentRequests: 100
    );
    
    server.RegisterTool(new FastExecutingTool());
    await server.StartAsync();
    
    var client = new McpClient("http://localhost:5000");
    
    // ביצוע
    var tasks = new List<Task<McpResponse>>();
    for (int i = 0; i < 1000; i++)
    {
        tasks.Add(client.ExecuteToolAsync("fastTool", new { iteration = i }));
    }
    
    var results = await Task.WhenAll(tasks);
    
    // אימות
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
    
    // הגדר את JMeter לבדיקת עומס
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // קבע את תוכנית הבדיקה של JMeter
    HashTree testPlanTree = new HashTree();
    
    // צור תוכנית בדיקה, קבוצת תהליכים, דגימות וכו'
    TestPlan testPlan = new TestPlan("MCP Server Stress Test");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // הוסף דגימת HTTP לביצוע הכלי
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // הוסף מאזינים
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // הרץ את הבדיקה
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // אמת תוצאות
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // זמן תגובה ממוצע < 200ms
    assertTrue(summaryReport.getPercentile(90.0) < 500); // האחוזון ה-90 < 500ms
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# הגדר ניטור עבור שרת MCP
def configure_monitoring(server):
    # הגדר מדדי Prometheus
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "סך כל בקשות MCP"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "משך זמן הבקשה בשניות",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "מספר הפעלות כלים",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "משך זמן הפעלת הכלי בשניות",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "שגיאות בהפעלת כלים",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # הוסף middleware למדידת זמן ורישום מדדים
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # חשוף נקודת קצה למדדים
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
# מימוש שרשרת כלים בפייתון
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # רשימת שמות כלים לביצוע ברצף
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # הפעל כל כלי בשרשרת, העבר את התוצאה הקודמת
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # שמור את התוצאה והשתמש בה כקלט לכלי הבא
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# דוגמה לשימוש
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
    public string Description => "מעבד תוכן מסוגים שונים";
    
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
        
        // קבע איזה כלי מיוחד להשתמש בו
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // העבר לכלי המיוחד
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
# מדריך למשתמש של csvProcessor

ברוכים הבאים ל-**csvProcessor**, הכלי המושלם לעיבוד קבצי CSV במהירות וביעילות.

## תכונות עיקריות

- טעינה וניתוח של קבצי CSV גדולים
- סינון ועריכת נתונים בקלות
- ייצוא הנתונים המעובדים לפורמטים שונים
- תמיכה בפקודות מותאמות אישית

## התחלה מהירה

כדי להתחיל, השתמשו בפונקציה `loadCSV(@@INLINE_CODE_1@@)` כדי לטעון את הקובץ שלכם:

```python
data = loadCSV('path/to/file.csv')
```

לאחר מכן, ניתן לסנן את הנתונים באמצעות `filterData(@@INLINE_CODE_2@@)`:

```python
filtered = filterData(data, condition=lambda row: row['age'] > 30)
```

## טיפים חשובים

[!TIP]  
כדי לשפר את הביצועים, מומלץ לעבוד עם קבצים קטנים יותר או לחלק קבצים גדולים לחלקים.

## התמודדות עם שגיאות

[!WARNING]  
אם הקובץ אינו בפורמט תקין, הפונקציה `loadCSV` תחזיר שגיאה. ודאו שהקובץ שלכם תואם לסטנדרטים של CSV.

## סיכום

csvProcessor הוא כלי עוצמתי שמפשט את העבודה עם קבצי CSV. בעזרת הפונקציות המובנות תוכלו לייעל את תהליכי העיבוד שלכם ולחסוך זמן רב.

למידע נוסף, בקרו בכתובת האתר הרשמית או עיינו בתיעוד המלא.
("code", _) => "codeAnalyzer",
_ => throw new ToolExecutionException($"אין כלי זמין עבור {contentType}/{operation}")
};

}

private object GetOptionsForTool(string toolName, string operation)
{
// החזר אפשרויות מתאימות לכל כלי מיוחד
return toolName switch
{
    "textSummarizer" => new { length = "medium" },
    "htmlProcessor" => new { cleanUp = true, operation },
    // אפשרויות לכלים אחרים...
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
        // שלב 1: שליפת מטא-נתונים של מערך הנתונים (סינכרוני)
        ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata", 
            Map.of("datasetId", datasetId));
        
        // שלב 2: הפעלת מספר ניתוחים במקביל
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
        
        // המתן לסיום כל המשימות במקביל
        CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
            statisticalAnalysis, correlationAnalysis, outlierDetection
        );
        
        allAnalyses.join();  // המתן לסיום
        
        // שלב 3: שילוב התוצאות
        Map<String, Object> combinedResults = new HashMap<>();
        combinedResults.put("metadata", metadataResponse.getResult());
        combinedResults.put("statistics", statisticalAnalysis.join().getResult());
        combinedResults.put("correlations", correlationAnalysis.join().getResult());
        combinedResults.put("outliers", outlierDetection.join().getResult());
        
        // שלב 4: יצירת דוח סיכום
        ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator", 
            Map.of("analysisResults", combinedResults));
        
        // החזר את תוצאת תהליך העבודה המלאה
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
            # נסה קודם את הכלי הראשי
            response = await self.client.execute_tool(primary_tool, parameters)
            return {
                "result": response.result,
                "source": "primary",
                "tool": primary_tool
            }
        except ToolExecutionException as e:
            # רישום הכישלון
            logging.warning(f"הכלי הראשי '{primary_tool}' נכשל: {str(e)}")
            
            # מעבר לכלי המשני
            try:
                # ייתכן וצריך להתאים את הפרמטרים לכלי המשני
                fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)
                
                response = await self.client.execute_tool(fallback_tool, fallback_params)
                return {
                    "result": response.result,
                    "source": "fallback",
                    "tool": fallback_tool,
                    "primaryError": str(e)
                }
            except ToolExecutionException as fallback_error:
                # שני הכלים נכשלו
                logging.error(f"שני הכלים, הראשי והמשני, נכשלו. שגיאת הכלי המשני: {str(fallback_error)}")
                raise WorkflowExecutionException(
                    f"תהליך העבודה נכשל: שגיאה ראשית: {str(e)}; שגיאת גיבוי: {str(fallback_error)}"
                )
    
    def _adapt_parameters(self, params, from_tool, to_tool):
        """התאם פרמטרים בין כלים שונים במידת הצורך"""
        # מימוש זה תלוי בכלים הספציפיים
        # בדוגמה זו נחזיר את הפרמטרים המקוריים
        return params

# דוגמה לשימוש
async def get_weather(workflow, location):
    return await workflow.execute_with_fallback(
        "premiumWeatherService",  # API מזג אוויר ראשי (בתשלום)
        "basicWeatherService",    # API מזג אוויר משני (חינמי)
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
            
            // שמירת תוצאת כל תהליך עבודה
            results[workflow.Name] = workflowResult;
            
            // עדכון ההקשר עם התוצאה לתהליך העבודה הבא
            context = context.WithResult(workflow.Name, workflowResult);
        }
        
        return new WorkflowResult(results);
    }
    
    public string Name => "CompositeWorkflow";
    public string Description => "מבצע מספר תהליכי עבודה ברצף";
}

// דוגמה לשימוש
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
// דוגמת בדיקת יחידה לכלי מחשבון ב-C#
[Fact]
public async Task CalculatorTool_Add_ReturnsCorrectSum()
{
    // סידור
    var calculator = new CalculatorTool();
    var parameters = new Dictionary<string, object>
    {
        ["operation"] = "add",
        ["a"] = 5,
        ["b"] = 7
    };
    
    // ביצוע
    var response = await calculator.ExecuteAsync(parameters);
    var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());
    
    // אימות
    Assert.Equal(12, result.Value);
}
```

```python
# דוגמת בדיקת יחידה לכלי מחשבון בפייתון
def test_calculator_tool_add():
    # סידור
    calculator = CalculatorTool()
    parameters = {
        "operation": "add",
        "a": 5,
        "b": 7
    }
    
    # ביצוע
    response = calculator.execute(parameters)
    result = json.loads(response.content[0].text)
    
    # אימות
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
// דוגמת בדיקת אינטגרציה לשרת MCP ב-C#
[Fact]
public async Task Server_ProcessToolRequest_ReturnsValidResponse()
{
    // סידור
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
    
    // ביצוע
    var response = await server.ProcessRequestAsync(request);
    
    // אימות
    Assert.NotNull(response);
    Assert.Equal(McpStatusCodes.Success, response.StatusCode);
    // אימותים נוספים לתוכן התגובה
    
    // ניקוי
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
// דוגמת בדיקת קצה לקצה (E2E) עם לקוח ב-TypeScript
describe('MCP Server E2E Tests', () => {
  let client: McpClient;
  
  beforeAll(async () => {
    // הפעלת השרת בסביבת בדיקה
    await startTestServer();
    client = new McpClient('http://localhost:5000');
  });
  
  afterAll(async () => {
    await stopTestServer();
  });
  
  test('Client can invoke calculator tool and get correct result', async () => {
    // ביצוע
    const response = await client.invokeToolAsync('calculator', {
      operation: 'divide',
      a: 20,
      b: 4
    });
    
    // אימות
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
// דוגמה ב-C# עם Moq
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
# דוגמה בפייתון עם unittest.mock
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
    # קונפיגורציית המוק
    mock_model.return_value.generate_response.return_value = {
        "text": "Mocked model response",
        "finish_reason": "completed"
    }
    
    # שימוש במוק בבדיקה
    server = McpServer(model_client=mock_model)
    # המשך הבדיקה
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
// סקריפט k6 לבדיקת עומס על שרת MCP
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  vus: 10,  // 10 משתמשים וירטואליים
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
    // סידור
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");
    
    // ביצוע
    var response = await client.GetAsync("http://localhost:5000/api/resources");
    var content = await response.Content.ReadAsStringAsync();
    var resources = JsonSerializer.Deserialize
<רשימתמשאבים>
// Assert
Assert.Equal(HttpStatusCode.OK, response.StatusCode);
Assert.NotNull(resources);
Assert.All(resources.Resources, resource => 
{
    Assert.NotNull(resource.Id);
    Assert.NotNull(resource.Type);
    // אימות נוסף של הסכמה
});
}

## 10 הטיפים המובילים לבדיקת שרת MCP יעילה

1. **בדוק הגדרות כלי בנפרד**: אמת הגדרות הסכמה בנפרד מלוגיקת הכלי
2. **השתמש בבדיקות פרמטריות**: בדוק כלים עם מגוון קלטים, כולל מקרים קיצוניים
3. **בדוק תגובות שגיאה**: אמת טיפול נכון בשגיאות בכל המצבים האפשריים
4. **בדוק לוגיקת הרשאות**: ודא בקרת גישה נכונה לתפקידי משתמש שונים
5. **נטר כיסוי בדיקות**: שאף לכיסוי גבוה של קוד הנתיב הקריטי
6. **בדוק תגובות סטרימינג**: אמת טיפול נכון בתוכן זורם
7. **סמלץ בעיות רשת**: בדוק התנהגות בתנאי רשת לקויים
8. **בדוק מגבלות משאבים**: אמת התנהגות בהגעה למכסות או מגבלות קצב
9. **אוטומט בדיקות רגרסיה**: בנה מערך בדיקות שרץ בכל שינוי קוד
10. **תעד מקרי בדיקה**: שמור תיעוד ברור של תרחישי הבדיקה

## כשלים נפוצים בבדיקות

- **הסתמכות יתר על בדיקות נתיב מוצלח**: ודא בדיקה יסודית של מקרים עם שגיאות
- **התעלמות מבדיקות ביצועים**: זיהוי צווארי בקבוק לפני שהם משפיעים על הייצור
- **בדיקה בבידוד בלבד**: שלב בדיקות יחידה, אינטגרציה ו-End-to-End
- **כיסוי API לא מלא**: ודא שכל נקודות הקצה והתכונות נבדקות
- **סביבות בדיקה לא עקביות**: השתמש בקונטיינרים להבטחת סביבות בדיקה עקביות

## סיכום

אסטרטגיית בדיקה מקיפה חיונית לפיתוח שרתי MCP אמינים ואיכותיים. על ידי יישום שיטות העבודה המומלצות והטיפים המפורטים במדריך זה, תוכל להבטיח שמימושי ה-MCP שלך יעמדו בסטנדרטים הגבוהים ביותר של איכות, אמינות וביצועים.

## נקודות מפתח

1. **עיצוב כלי**: פעל לפי עקרון האחריות היחידה, השתמש בהזרקת תלות, ועצב למרכיבים ניתנים להרכבה
2. **עיצוב סכמות**: צור סכמות ברורות ומתועדות היטב עם מגבלות אימות מתאימות
3. **טיפול בשגיאות**: יישם טיפול שגיאות אלגנטי, תגובות שגיאה מובנות ולוגיקת ניסיון חוזר
4. **ביצועים**: השתמש במטמון, עיבוד אסינכרוני, והגבלת משאבים
5. **אבטחה**: החל אימות קלט מקיף, בדיקות הרשאה, וטיפול בנתונים רגישים
6. **בדיקות**: צור בדיקות יחידה, אינטגרציה ו-End-to-End מקיפות
7. **תבניות עבודה**: השתמש בתבניות מוכרות כמו שרשראות, מפעילים ועיבוד מקבילי

## תרגיל

עצב כלי MCP ותהליך עבודה למערכת עיבוד מסמכים ש:

1. מקבלת מסמכים בפורמטים שונים (PDF, DOCX, TXT)
2. מחלץ טקסט ומידע מרכזי מהמסמכים
3. מסווג מסמכים לפי סוג ותוכן
4. מייצר סיכום לכל מסמך

ממש את סכמות הכלי, טיפול בשגיאות, ותבנית עבודה המתאימה ביותר לתרחיש זה. שקול כיצד תבדוק מימוש זה.

## משאבים

1. הצטרף לקהילת MCP ב-[Azure AI Foundry Discord Community](https://aka.ms/foundrydevs) כדי להתעדכן בהתפתחויות האחרונות  
2. תרום לפרויקטים בקוד פתוח של [MCP](https://github.com/modelcontextprotocol)  
3. החל עקרונות MCP ביוזמות ה-AI של הארגון שלך  
4. חקור מימושי MCP ייעודיים לתעשייה שלך  
5. שקול לקחת קורסים מתקדמים בנושאי MCP ספציפיים, כמו אינטגרציה מולטימודלית או אינטגרציית יישומים ארגוניים  
6. נסה לבנות כלים ותהליכי עבודה משלך ב-MCP באמצעות העקרונות שנלמדו ב-[Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)  

הבא: מקרים לדוגמה של שיטות עבודה מומלצות [case studies](../09-CaseStudy/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו נחשב למקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי מתרגם אנושי. אנו לא נושאים באחריות לכל אי-הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.