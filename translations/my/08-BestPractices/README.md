<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "80e5c8949af5af0f401fce6f905990aa",
  "translation_date": "2025-07-17T12:33:44+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "my"
}
-->
# MCP ဖွံ့ဖြိုးတိုးတက်မှုအတွက် အကောင်းဆုံး လေ့လာမှုများ

## အနှစ်ချုပ်

ဒီသင်ခန်းစာမှာ MCP ဆာဗာများနှင့် လုပ်ဆောင်ချက်များကို ထုတ်လုပ်မှုပတ်ဝန်းကျင်များတွင် ဖွံ့ဖြိုးတိုးတက်ခြင်း၊ စမ်းသပ်ခြင်းနှင့် တပ်ဆင်ခြင်းဆိုင်ရာ အဆင့်မြင့် အကောင်းဆုံး လေ့လာမှုများကို အဓိကထားပြောကြားထားသည်။ MCP စနစ်များသည် ရှုပ်ထွေးမှုနှင့် အရေးပါမှုများ တိုးလာသည့်အခါ၊ သတ်မှတ်ထားသော ပုံစံများကို လိုက်နာခြင်းဖြင့် ယုံကြည်စိတ်ချရမှု၊ ပြုပြင်ထိန်းသိမ်းရလွယ်ကူမှုနှင့် အပြန်အလှန်ဆက်သွယ်နိုင်မှုတို့ကို အာမခံနိုင်သည်။ ဒီသင်ခန်းစာသည် MCP ကို အကောင်းဆုံး အသုံးချနိုင်ရန် အတွေ့အကြုံများကို စုစည်းပြီး၊ ခိုင်မာပြီး ထိရောက်သော ဆာဗာများ၊ အရင်းအမြစ်များ၊ အကြောင်းကြားချက်များနှင့် ကိရိယာများကို ဖန်တီးရာတွင် လမ်းညွှန်ပေးသည်။

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဒီသင်ခန်းစာပြီးဆုံးချိန်တွင် သင်သည် -
- MCP ဆာဗာနှင့် လုပ်ဆောင်ချက် ဒီဇိုင်းတွင် စက်မှုလုပ်ငန်းအကောင်းဆုံး လေ့လာမှုများကို အသုံးပြုနိုင်မည်
- MCP ဆာဗာများအတွက် စမ်းသပ်မှု မဟာဗျူဟာများကို ဖန်တီးနိုင်မည်
- ရှုပ်ထွေးသော MCP အပလီကေးရှင်းများအတွက် ထိရောက်ပြီး ပြန်လည်အသုံးပြုနိုင်သော လုပ်ငန်းစဉ် ပုံစံများကို ဒီဇိုင်းဆွဲနိုင်မည်
- MCP ဆာဗာများတွင် မှားယွင်းမှု ကိုင်တွယ်ခြင်း၊ မှတ်တမ်းတင်ခြင်းနှင့် ကြည့်ရှုနိုင်မှုကို မှန်ကန်စွာ အကောင်အထည်ဖော်နိုင်မည်
- စွမ်းဆောင်ရည်၊ လုံခြုံရေးနှင့် ပြုပြင်ထိန်းသိမ်းရလွယ်ကူမှုအတွက် MCP အကောင်အထည်ဖော်မှုများကို အကောင်းဆုံး ပြုလုပ်နိုင်မည်

## MCP အခြေခံ 원칙များ

အထူးသဖြင့် အကောင်အထည်ဖော်မှု လေ့လာမှုများကို စတင်မတိုင်မီ၊ ထိရောက်သော MCP ဖွံ့ဖြိုးတိုးတက်မှုကို ဦးတည်စေသော အခြေခံ 원칙များကို နားလည်ထားခြင်း အရေးကြီးသည် -

1. **စံနှုန်းတကျ ဆက်သွယ်မှု**: MCP သည် JSON-RPC 2.0 ကို အခြေခံထားပြီး၊ တောင်းဆိုမှုများ၊ တုံ့ပြန်မှုများနှင့် မှားယွင်းမှု ကိုင်တွယ်မှုများအတွက် တစ်သွေ့တစ်ပြိုင် ညီညာသော ပုံစံကို ပံ့ပိုးပေးသည်။

2. **အသုံးပြုသူ ဦးတည်ဒီဇိုင်း**: MCP အကောင်အထည်ဖော်မှုများတွင် အသုံးပြုသူ၏ သဘောတူညီချက်၊ ထိန်းချုပ်မှုနှင့် ထင်ရှားမြင်သာမှုကို အမြဲ ဦးစားပေးပါ။

3. **လုံခြုံရေး အရင်ဆုံး**: အတည်ပြုခြင်း၊ ခွင့်ပြုခြင်း၊ စစ်ဆေးခြင်းနှင့် အမြန်နှုန်း ကန့်သတ်ခြင်းတို့ ပါဝင်သည့် ခိုင်မာသော လုံခြုံရေး အစီအစဉ်များကို အကောင်အထည်ဖော်ပါ။

4. **မော်ဂျူးလာ ဖွဲ့စည်းမှု**: MCP ဆာဗာများကို မော်ဂျူးလာနည်းဖြင့် ဒီဇိုင်းဆွဲပါ၊ ကိရိယာနှင့် အရင်းအမြစ်တိုင်းမှာ ရည်ရွယ်ချက်ရှင်းလင်းပြီး အာရုံစိုက်ထားသင့်သည်။

5. **အခြေအနေရှိ ဆက်သွယ်မှုများ**: MCP ၏ တောင်းဆိုမှုများအတွင်း အခြေအနေကို ထိန်းသိမ်းနိုင်မှုကို အသုံးချ၍ ပိုမို သေချာပြီး အကြောင်းအရာနားလည်မှုရှိသော ဆက်သွယ်မှုများကို ဖန်တီးပါ။

## တရားဝင် MCP အကောင်းဆုံး လေ့လာမှုများ

အောက်ပါ အကောင်းဆုံး လေ့လာမှုများကို တရားဝင် Model Context Protocol စာတမ်းများမှ ရယူထားသည် -

### လုံခြုံရေး အကောင်းဆုံး လေ့လာမှုများ

1. **အသုံးပြုသူ သဘောတူညီချက်နှင့် ထိန်းချုပ်မှု**: ဒေတာသို့ ဝင်ရောက်ခွင့်ရယူခြင်း သို့မဟုတ် လုပ်ဆောင်ချက်များ ပြုလုပ်ခြင်းမပြုမီ အသုံးပြုသူ၏ ထင်ရှားသော သဘောတူညီချက်ကို အမြဲလိုအပ်ပါသည်။ မည်သည့်ဒေတာမျိုးကို မျှဝေမည်နှင့် မည်သည့် လုပ်ဆောင်ချက်များ ခွင့်ပြုမည်ကို ရှင်းလင်းစွာ ထိန်းချုပ်ခွင့်ပေးပါ။

2. **ဒေတာ ကိုယ်ရေးလုံခြုံမှု**: အသုံးပြုသူ၏ သဘောတူညီချက် ရှိမှသာ ဒေတာကို ဖော်ပြပါ၊ သင့်တော်သော ဝင်ရောက်ခွင့် ထိန်းချုပ်မှုဖြင့် ကာကွယ်ပါ။ ခွင့်မပြုထားသော ဒေတာ ပို့ဆောင်မှုများကို ကာကွယ်ပါ။

3. **ကိရိယာ လုံခြုံမှု**: ကိရိယာတစ်ခုခုကို ခေါ်ယူမည်မဟုတ်မီ အသုံးပြုသူ၏ ထင်ရှားသော သဘောတူညီချက် လိုအပ်ပါသည်။ အသုံးပြုသူများသည် ကိရိယာ၏ လုပ်ဆောင်ချက်ကို နားလည်စေရန်နှင့် ခိုင်မာသော လုံခြုံရေး နယ်နိမိတ်များကို အကောင်အထည်ဖော်ပါ။

4. **ကိရိယာ ခွင့်ပြုချက် ထိန်းချုပ်မှု**: မော်ဒယ်တစ်ခုသည် အစည်းအဝေးအတွင်း အသုံးပြုခွင့်ရသော ကိရိယာများကို သတ်မှတ်ပေးပါ၊ ထင်ရှားသော ခွင့်ပြုချက်ရှိသော ကိရိယာများသာ အသုံးပြုနိုင်ပါစေ။

5. **အတည်ပြုခြင်း**: API key, OAuth token သို့မဟုတ် အခြား လုံခြုံသော အတည်ပြုနည်းများဖြင့် ကိရိယာများ၊ အရင်းအမြစ်များ သို့မဟုတ် အထူးသဖြင့် အရေးကြီးသော လုပ်ဆောင်ချက်များကို ဝင်ရောက်ခွင့်မပေးမီ မှန်ကန်သော အတည်ပြုမှု လိုအပ်ပါသည်။

6. **ပါရာမီတာ စစ်ဆေးခြင်း**: ကိရိယာခေါ်ယူမှုတိုင်းအတွက် မမှန်ကန်သော သို့မဟုတ် မကောင်းသော အချက်အလက်များ မဝင်ရောက်နိုင်ရန် စစ်ဆေးမှုများကို အကောင်အထည်ဖော်ပါ။

7. **အမြန်နှုန်း ကန့်သတ်ခြင်း**: ဆာဗာ အရင်းအမြစ်များကို မတရားအသုံးပြုမှုမှ ကာကွယ်ရန်နှင့် တရားမျှတသော အသုံးပြုမှုကို အာမခံရန် အမြန်နှုန်း ကန့်သတ်မှုများကို ထည့်သွင်းပါ။

### အကောင်အထည်ဖော်မှု အကောင်းဆုံး လေ့လာမှုများ

1. **စွမ်းဆောင်ရည် ညှိနှိုင်းမှု**: ဆက်သွယ်မှု စတင်ချိန်တွင် ပံ့ပိုးထားသော လုပ်ဆောင်ချက်များ၊ ပရိုတိုကော ဗားရှင်းများ၊ ရရှိနိုင်သော ကိရိယာများနှင့် အရင်းအမြစ်များအကြောင်း အချက်အလက်များကို လဲလှယ်ပါ။

2. **ကိရိယာ ဒီဇိုင်း**: တစ်ခုတည်းသော လုပ်ဆောင်ချက်ကို အထူးပြုလုပ်သော ကိရိယာများကို ဖန်တီးပါ၊ မျိုးစုံသော ပြဿနာများကို တစ်ခုတည်းကိရိယာဖြင့် ကိုင်တွယ်ရန် မကြိုးစားပါနှင့်။

3. **မှားယွင်းမှု ကိုင်တွယ်မှု**: ပြဿနာများ ရှာဖွေရန်၊ အဆင်မပြေမှုများကို သေချာစွာ ကိုင်တွယ်ရန်နှင့် လုပ်ဆောင်နိုင်သော တုံ့ပြန်ချက်များ ပေးရန် စံနှုန်းတကျ မှားယွင်းမှု စာသားများနှင့် ကုဒ်များကို အကောင်အထည်ဖော်ပါ။

4. **မှတ်တမ်းတင်ခြင်း**: စနစ်တကျ မှတ်တမ်းများကို စီစဉ်၍ စစ်ဆေးခြင်း၊ အမှားရှာဖွေရေးနှင့် ပရိုတိုကော ဆက်သွယ်မှုများကို ကြည့်ရှုနိုင်ရန် ပြုလုပ်ပါ။

5. **တိုးတက်မှု ခြေရာခံခြင်း**: ကြာရှည်ဆောင်ရွက်မှုများအတွက် တိုးတက်မှု အဆင့်များကို အသုံးပြုသူ မျက်နှာပြင်များတွင် ပြသနိုင်ရန် အစီအစဉ်တင်ပြပါ။

6. **တောင်းဆိုမှု ပယ်ဖျက်ခြင်း**: မလိုအပ်တော့သော သို့မဟုတ် ကြာရှည်နေသော တောင်းဆိုမှုများကို ဖောက်သည်များက ပယ်ဖျက်နိုင်ရန် ခွင့်ပြုပါ။

## အပိုဆောင်း ရင်းမြစ်များ

MCP အကောင်းဆုံး လေ့လာမှုများအတွက် နောက်ဆုံးရသတင်းအချက်အလက်များကို အောက်ပါနေရာများတွင် ရယူနိုင်ပါသည် -
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)
- [Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## လက်တွေ့ အကောင်အထည်ဖော်မှု ဥပမာများ

### ကိရိယာ ဒီဇိုင်း အကောင်းဆုံး လေ့လာမှုများ

#### 1. တစ်ခုတည်းတာဝန်ယူမှု 원칙

MCP ကိရိယာတိုင်းသည် ရည်ရွယ်ချက်ရှင်းလင်းပြီး အာရုံစိုက်ထားသင့်သည်။ မျိုးစုံသော ပြဿနာများကို တစ်ခုတည်းကိရိယာဖြင့် ကိုင်တွယ်ရန် မကြိုးစားဘဲ၊ အထူးပြုလုပ်ထားသော ကိရိယာများကို ဖန်တီးပါ။

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

#### 2. တစ်ညီတစ်ညွတ် မှားယွင်းမှု ကိုင်တွယ်မှု

သတင်းအချက်အလက်ပြည့်စုံသော မှားယွင်းမှု စာသားများနှင့် သင့်တော်သော ပြန်လည်ကောင်းမွန်ရေး နည်းလမ်းများဖြင့် ခိုင်မာသော မှားယွင်းမှု ကိုင်တွယ်မှုကို အကောင်အထည်ဖော်ပါ။

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

#### 3. ပါရာမီတာ စစ်ဆေးမှု

မမှန်ကန်သော သို့မဟုတ် မကောင်းသော အချက်အလက်များ မဝင်ရောက်နိုင်ရန် ပါရာမီတာများကို အမြဲတမ်း စစ်ဆေးပါ။

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

### လုံခြုံရေး အကောင်အထည်ဖော်မှု ဥပမာများ

#### 1. အတည်ပြုခြင်းနှင့် ခွင့်ပြုခြင်း

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

#### 2. အမြန်နှုန်း ကန့်သတ်ခြင်း

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

## စမ်းသပ်မှု အကောင်းဆုံး လေ့လာမှုများ

### 1. MCP ကိရိယာများအတွက် ယူနစ် စမ်းသပ်မှု

သင့်ကိရိယာများကို အခြား အပြင်အဆင်များကို မပါဘဲ တစ်ခုချင်းစီ စမ်းသပ်ပါ -

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

### 2. ပေါင်းစပ် စမ်းသပ်မှု

ဖောက်သည်တောင်းဆိုမှုများမှ ဆာဗာတုံ့ပြန်မှုများအထိ ပြည့်စုံသော လည်ပတ်မှုကို စမ်းသပ်ပါ -

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

## စွမ်းဆောင်ရည် တိုးတက်မှု

### 1. ကက်ရှ် မဟာဗျူဟာများ

နောက်ကျမှုနှင့် အရင်းအမြစ် အသုံးပြုမှုကို လျော့နည်းစေရန် သင့်တော်သော ကက်ရှ် မဟာဗျူဟာများကို အကောင်အထည်ဖော်ပါ -

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
// Java ဥပမာ - dependency injection ဖြင့်
public class CurrencyConversionTool implements Tool {
    private final ExchangeRateService exchangeService;
    private final CacheService cacheService;
    private final Logger logger;
    
    // constructor မှတဆင့် dependency များ ထည့်သွင်းခြင်း
    public CurrencyConversionTool(
            ExchangeRateService exchangeService,
            CacheService cacheService,
            Logger logger) {
        this.exchangeService = exchangeService;
        this.cacheService = cacheService;
        this.logger = logger;
    }
    
    // ကိရိယာ အကောင်အထည်ဖော်မှု
    // ...
}
```

#### 3. Composable Tools

Design tools that can be composed together to create more complex workflows:

```python
# Python ဥပမာ - ပေါင်းစပ်အသုံးပြုနိုင်သော ကိရိယာများ ပြသခြင်း
class DataFetchTool(Tool):
    def get_name(self):
        return "dataFetch"
    
    # အကောင်အထည်ဖော်မှု...

class DataAnalysisTool(Tool):
    def get_name(self):
        return "dataAnalysis"
    
    # ဒီကိရိယာသည် dataFetch ကိရိယာရလဒ်များကို အသုံးပြုနိုင်သည်
    async def execute_async(self, request):
        # အကောင်အထည်ဖော်မှု...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # ဒီကိရိယာသည် dataAnalysis ကိရိယာရလဒ်များကို အသုံးပြုနိုင်သည်
    async def execute_async(self, request):
        # အကောင်အထည်ဖော်မှု...
        pass

# ဒီကိရိယာများကို တစ်ခုချင်း သီးသန့် သို့မဟုတ် လုပ်ငန်းစဉ်တစ်ခုအဖြစ် အသုံးပြုနိုင်သည်
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
                description = "ရှာဖွေရေး စာသား။ ပိုမိုကောင်းမွန်သော ရလဒ်များအတွက် တိကျသော စကားလုံးများကို အသုံးပြုပါ။" 
            },
            filters = new {
                type = "object",
                description = "ရွေးချယ်စရာ ဖလ်တာများ၊ ရှာဖွေရေး ရလဒ်များကို ကန့်သတ်ရန်",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "YYYY-MM-DD:YYYY-MM-DD ပုံစံဖြင့် ရက်စွဲကာလ" 
                    },
                    category = new { 
                        type = "string", 
                        description = "အမျိုးအစားအမည်ဖြင့် ဖလ်တာခွဲရန်" 
                    }
                }
            },
            limit = new { 
                type = "integer", 
                description = "ပြန်လည်ပေးပို့မည့် အများဆုံး ရလဒ်အရေအတွက် (1-50)",
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
    
    // အီးမေးလ် အချက်အလက်နှင့် ပုံစံ စစ်ဆေးမှု
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "အသုံးပြုသူ၏ အီးမေးလ်လိပ်စာ");
    
    // အသက် အချက်အလက်နှင့် ကန့်သတ်ချက်များ
    Map<String, Object> age = new HashMap<>();
    age.put("type", "integer");
    age.put("minimum", 13);
    age.put("maximum", 120);
    age.put("description", "အသုံးပြုသူ အသက် (နှစ်)");
    
    // ရွေးချယ်စရာ အမျိုး

ExecuteAsync(ToolRequest request)
    {
        var query = request.Parameters.GetProperty("query").GetString();
        
        // ပရမားတာများအပေါ် မူတည်၍ cache key ဖန်တီးခြင်း
        var cacheKey = $"data_query_{ComputeHash(query)}";
        
        // ပထမဦးဆုံး cache မှ ရယူကြည့်ပါ
        if (_cache.TryGetValue(cacheKey, out var cachedResult))
        {
            return new ToolResponse { Result = cachedResult };
        }
        
        // Cache မတွေ့ပါက - အမှန်တကယ် query ကို ဆောင်ရွက်ပါ
        var result = await _database.QueryAsync(query);
        
        // သတ်မှတ်ထားသော အချိန်အတွင်း cache ထဲသို့ သိမ်းဆည်းပါ
        var cacheOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
            
        _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
        
        return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
    }
    
    private string ComputeHash(string input)
    {
        // cache key အတွက် တည်ငြိမ်သော hash ဖန်တီးရန် အကောင်အထည်ဖော်မှု
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
        
        // ကြာရှည်ဆောင်ရွက်ရမည့် လုပ်ငန်းများအတွက် processing ID ကို ချက်ချင်း ပြန်ပေးပါ
        String processId = UUID.randomUUID().toString();
        
        // async ဆောင်ရွက်မှု စတင်ပါ
        CompletableFuture.runAsync(() -> {
            try {
                // ကြာရှည်ဆောင်ရွက်မှု လုပ်ဆောင်ပါ
                documentService.processDocument(documentId);
                
                // အခြေအနေကို update လုပ်ပါ (ပုံမှန်အားဖြင့် database တွင် သိမ်းဆည်းထားသည်)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // process ID နှင့်အတူ ချက်ချင်း ပြန်လည်တုံ့ပြန်မှု ပေးပါ
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // အတူတကွ အသုံးပြုနိုင်သော status စစ်ဆေးရေး tool
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
            tokens_per_second=5,  # တစ်စက္ကန့်လျှင် ၅ ကြိမ်တောင်းဆိုခွင့်
            bucket_size=10        # တောင်းဆိုမှုများကို ၁၀ ကြိမ်အထိ တပြိုင်နက် ခွင့်ပြုသည်
        )
    
    async def execute_async(self, request):
        # ဆက်လက်လုပ်ဆောင်နိုင်မလား၊ မလုပ်နိုင်ဘဲ စောင့်ရမလား စစ်ဆေးပါ
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # စောင့်ရမည့်အချိန် ကြာလွန်းပါက
                raise ToolExecutionException(
                    f"Rate limit ကျော်လွန်နေပါသည်။ {delay:.1f} စက္ကန့်အတွင်း ပြန်ကြိုးစားပါ။"
                )
            else:
                # သင့်တော်သော စောင့်ချိန်အတွက် စောင့်ပါ
                await asyncio.sleep(delay)
        
        # token တစ်ခု သုံးပြီး တောင်းဆိုမှု ဆက်လက်လုပ်ဆောင်ပါ
        self.rate_limiter.consume()
        
        # API ကို ခေါ်ပါ
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
            
            # နောက်တစ် token ရရှိရန် လိုအပ်သည့် အချိန်တွက်ချက်ခြင်း
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # ကာလအလိုက် token အသစ်များ ထည့်သွင်းခြင်း
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
    // ပရမားတာများ ရှိ/မရှိ စစ်ဆေးပါ
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("လိုအပ်သော parameter မရှိပါ: query");
    }
    
    // အမျိုးအစားမှန်ကန်မှု စစ်ဆေးပါ
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("Query parameter သည် string ဖြစ်ရမည်");
    }
    
    var query = queryProp.GetString();
    
    // string အကြောင်းအရာ စစ်ဆေးပါ
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("Query parameter ကို ဖျက်ထား၍ မရပါ");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("Query parameter သည် အများဆုံး ၅၀၀ လုံးထက် မကျော်ရ");
    }
    
    // SQL injection အန္တရာယ်ရှိမရှိ စစ်ဆေးပါ (လိုအပ်ပါက)
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("မမှန်ကန်သော query: အန္တရာယ်ရှိနိုင်သော SQL ပါဝင်သည်");
    }
    
    // ဆောင်ရွက်မှု ဆက်လက်လုပ်ဆောင်ပါ
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // request မှ user context ရယူပါ
    UserContext user = request.getContext().getUserContext();
    
    // user တွင် လိုအပ်သော ခွင့်ပြုချက် ရှိ/မရှိ စစ်ဆေးပါ
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("User သည် စာရွက်စာတမ်းများကို ဝင်ရောက်ကြည့်ရှုခွင့် မရှိပါ");
    }
    
    // သတ်မှတ်ထားသော အရင်းအမြစ်များအတွက် အဆိုပါ အရင်းအမြစ်ကို ဝင်ရောက်ကြည့်ရှုခွင့် ရှိ/မရှိ စစ်ဆေးပါ
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("တောင်းဆိုထားသော စာရွက်စာတမ်းကို ဝင်ရောက်ကြည့်ရှုခွင့် ပိတ်ထားသည်");
    }
    
    // tool ဆောင်ရွက်မှု ဆက်လက်လုပ်ဆောင်ပါ
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
        
        # user data ရယူပါ
        user_data = await self.user_service.get_user_data(user_id)
        
        # သတိထားရမည့် အချက်အလက်များကို တောင်းဆိုခြင်းမရှိပါက သို့မဟုတ် ခွင့်ပြုချက်မရှိပါက ဖယ်ရှားပါ
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # request context ထဲမှ ခွင့်ပြုချက်အဆင့် စစ်ဆေးပါ
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # မူရင်းကို မထိခိုက်စေရန် ကူးယူပါ
        redacted = user_data.copy()
        
        # သတိထားရမည့် အချက်အလက်များကို ဖယ်ရှားပါ
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # အတွင်းပိုင်း သတိထားရမည့် အချက်အလက်များကို ဖယ်ရှားပါ
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
    // စီစဉ်ခြင်း
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("Seattle", 3))
        .ReturnsAsync(new WeatherForecast(/* စမ်းသပ်မှု ဒေတာ */));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "Seattle", 
            days = 3 
        })
    );
    
    // လုပ်ဆောင်ခြင်း
    var response = await tool.ExecuteAsync(request);
    
    // အတည်ပြုခြင်း
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // စီစဉ်ခြင်း
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("InvalidLocation", It.IsAny<int>()))
        .ThrowsAsync(new LocationNotFoundException("တည်နေရာ မတွေ့ပါ"));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "InvalidLocation", 
            days = 3 
        })
    );
    
    // လုပ်ဆောင်ခြင်းနှင့် အတည်ပြုခြင်း
    var exception = await Assert.ThrowsAsync<ToolExecutionException>(
        () => tool.ExecuteAsync(request)
    );
    
    Assert.Contains("တည်နေရာ မတွေ့ပါ", exception.Message);
}
```

#### 2. Schema Validation Testing

Test that schemas are valid and properly enforce constraints:

```java
@Test
public void testSchemaValidation() {
    // tool instance ဖန်တီးခြင်း
    SearchTool searchTool = new SearchTool();
    
    // schema ရယူခြင်း
    Object schema = searchTool.getSchema();
    
    // schema ကို JSON အဖြစ် ပြောင်း၍ စစ်ဆေးခြင်း
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // schema သည် မှန်ကန်သော JSONSchema ဖြစ်ကြောင်း စစ်ဆေးခြင်း
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // မှန်ကန်သော parameter များ စမ်းသပ်ခြင်း
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // လိုအပ်သော parameter မပါသော အခြေအနေ စမ်းသပ်ခြင်း
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // parameter အမျိုးအစား မမှန်ကန်သော အခြေအနေ စမ်းသပ်ခြင်း
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
    # စီစဉ်ခြင်း
    tool = ApiTool(timeout=0.1)  # အချိန်ကန့်သတ် အလွန်တိုတောင်းသည်
    
    # timeout ဖြစ်မည့် request ကို mock ပြုလုပ်ခြင်း
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # timeout ထက် ကြာသည်
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # လုပ်ဆောင်ခြင်းနှင့် အတည်ပြုခြင်း
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # exception message ကို စစ်ဆေးခြင်း
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # စီစဉ်ခြင်း
    tool = ApiTool()
    
    # rate-limited response ကို mock ပြုလုပ်ခြင်း
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
        
        # လုပ်ဆောင်ခြင်းနှင့် အတည်ပြုခြင်း
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # exception တွင် rate limit အချက်အလက် ပါဝင်မှုကို စစ်ဆေးခြင်း
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
    // စီစဉ်ခြင်း
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // လုပ်ဆောင်ခြင်း
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

// အတည်ပြုချက်
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
        // discovery endpoint ကို စမ်းသပ်ခြင်း
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // tool request ဖန်တီးခြင်း
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // request ပို့ပြီး response ကို စစ်ဆေးခြင်း
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // မမှန်ကန်သော tool request ဖန်တီးခြင်း
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // "b" parameter မပါရှိခြင်း
        request.put("parameters", parameters);
        
        // request ပို့ပြီး error response ကို စစ်ဆေးခြင်း
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
    # ပြင်ဆင်ခြင်း - MCP client နဲ့ mock model ကို ပြင်ဆင်ခြင်း
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # mock model ရဲ့ တုံ့ပြန်မှုများ
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
    
    # weather tool ရဲ့ mock တုံ့ပြန်မှု
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
        
        # လုပ်ဆောင်ချက်
        response = await mcp_client.send_prompt(
            "What's the weather in Seattle?",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # အတည်ပြုချက်
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
    // ပြင်ဆင်ခြင်း
    var server = new McpServer(
        name: "TestServer",
        version: "1.0",
        maxConcurrentRequests: 100
    );
    
    server.RegisterTool(new FastExecutingTool());
    await server.StartAsync();
    
    var client = new McpClient("http://localhost:5000");
    
    // လုပ်ဆောင်ချက်
    var tasks = new List<Task<McpResponse>>();
    for (int i = 0; i < 1000; i++)
    {
        tasks.Add(client.ExecuteToolAsync("fastTool", new { iteration = i }));
    }
    
    var results = await Task.WhenAll(tasks);
    
    // အတည်ပြုချက်
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
    
    // JMeter ကို stress testing အတွက် ပြင်ဆင်ခြင်း
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // JMeter test plan ကို ပြင်ဆင်ခြင်း
    HashTree testPlanTree = new HashTree();
    
    // test plan, thread group, samplers စသည်ဖြင့် ဖန်တီးခြင်း
    TestPlan testPlan = new TestPlan("MCP Server Stress Test");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // tool execution အတွက် HTTP sampler ထည့်ခြင်း
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // listener များ ထည့်ခြင်း
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // စမ်းသပ်မှု ပြုလုပ်ခြင်း
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // ရလဒ်များကို အတည်ပြုခြင်း
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // ပျမ်းမျှ တုံ့ပြန်ချိန် < 200ms
    assertTrue(summaryReport.getPercentile(90.0) < 500); // ၉၀ ရာခိုင်နှုန်း < 500ms
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# MCP server အတွက် monitoring ကို ပြင်ဆင်ခြင်း
def configure_monitoring(server):
    # Prometheus metrics များကို ပြင်ဆင်ခြင်း
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "စုစုပေါင်း MCP request များ"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "Request ကြာချိန် (စက္ကန့်)",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "Tool အကောင်အထည်ဖော်မှု အရေအတွက်",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "Tool အကောင်အထည်ဖော်မှု ကြာချိန် (စက္ကန့်)",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "Tool အကောင်အထည်ဖော်မှု အမှားများ",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # timing နဲ့ metrics မှတ်တမ်းတင်ဖို့ middleware ထည့်ခြင်း
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # metrics endpoint ကို ဖော်ပြခြင်း
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
# Python Chain of Tools အကောင်အထည်ဖော်မှု
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # အဆက်မပြတ် အကောင်အထည်ဖော်ရန် tool များစာရင်း
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # အဆက်လိုက် tool တစ်ခုချင်းစီကို အရင်ရလဒ်ဖြင့် အကောင်အထည်ဖော်ခြင်း
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # ရလဒ်ကို သိမ်းဆည်းပြီး နောက် tool အတွက် input အဖြစ် သုံးခြင်း
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# ဥပမာ အသုံးပြုမှု
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
    public string Description => "အမျိုးမျိုးသော အကြောင်းအရာများကို ပြုလုပ်ပေးသည်";
    
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
        
        // ဘယ် specialized tool ကို သုံးမလဲ ဆုံးဖြတ်ခြင်း
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // specialized tool ကို ပို့ဆောင်ခြင်း
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
            ("csv", _) => ...
IMPORTANT RULES:
1. ဘာသာပြန်ချက်ကို '''markdown သို့မဟုတ် အခြားတစ်ခုခု tag များဖြင့် မပတ်ပတ်လည်ထည့်သွင်းပါနှင့်
2. ဘာသာပြန်ချက်သည် အလွန်တိတိကျကျ မဖြစ်စေရန် သေချာစေပါ
3. မှတ်ချက်များကိုလည်း ဘာသာပြန်ပါ
4. ဤဖိုင်သည် Markdown ပုံစံဖြင့် ရေးသားထားသည် - XML သို့မဟုတ် HTML အဖြစ် မဆင်ခြင်ပါနှင့်
5. ဘာသာပြန်မရပါ:
   - [!NOTE], [!WARNING], [!TIP], [!IMPORTANT], [!CAUTION]
   - Variable နာမည်များ၊ function နာမည်များ၊ class နာမည်များ
   - @@INLINE_CODE_x@@ သို့မဟုတ် @@CODE_BLOCK_x@@ ကဲ့သို့သော Placeholder များ
   - URL များ သို့မဟုတ် လမ်းကြောင်းများ
6. မူရင်း markdown ဖော်မတ်ကို အပြည့်အဝ ထိန်းသိမ်းပါ
7. ထည့်သွင်းထားသော tag များ သို့မဟုတ် markup များ မပါဘဲ ဘာသာပြန်ထားသော အကြောင်းအရာကိုသာ ပြန်ပေးပါ

> "csvProcessor",
("code", _) => "codeAnalyzer",
_ => throw new ToolExecutionException($"No tool available for {contentType}/{operation}")
};
}

private object GetOptionsForTool(string toolName, string operation)
{
// Return appropriate options for each specialized tool
return toolName switch
{
"textSummarizer" => new { length = "medium" },
"htmlProcessor" => new { cleanUp = true, operation },
// Options for other tools...
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
// အဆင့် ၁: ဒေတာစနစ် metadata ကို ရယူပါ (စနစ်တကျ)
ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata", 
Map.of("datasetId", datasetId));

// အဆင့် ၂: အနည်းငယ်သော အချက်အလက်များကို 병렬로 분석 시작하기
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

// 병렬 작업 모두 완료될 때까지 대기하기
CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
statisticalAnalysis, correlationAnalysis, outlierDetection
);

allAnalyses.join();  // 완료될 때까지 대기하기

// အဆင့် ၃: ရလဒ်များကို ပေါင်းစပ်ပါ
Map<String, Object> combinedResults = new HashMap<>();
combinedResults.put("metadata", metadataResponse.getResult());
combinedResults.put("statistics", statisticalAnalysis.join().getResult());
combinedResults.put("correlations", correlationAnalysis.join().getResult());
combinedResults.put("outliers", outlierDetection.join().getResult());

// အဆင့် ၄: အကျဉ်းချုပ်အစီရင်ခံစာ ထုတ်လုပ်ပါ
ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator", 
Map.of("analysisResults", combinedResults));

// အလုပ်စဉ်ရလဒ် အပြည့်အစုံ ပြန်ပေးပါ
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
# ပထမဆုံး primary tool ကို စမ်းသပ်ပါ
response = await self.client.execute_tool(primary_tool, parameters)
return {
"result": response.result,
"source": "primary",
"tool": primary_tool
}
except ToolExecutionException as e:
# မအောင်မြင်မှုကို မှတ်တမ်းတင်ပါ
logging.warning(f"Primary tool '{primary_tool}' failed: {str(e)}")

# fallback tool ကို အသုံးပြုပါ
try:
# fallback tool အတွက် parameters ကို ပြောင်းလဲရန် လိုအပ်နိုင်သည်
fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)

response = await self.client.execute_tool(fallback_tool, fallback_params)
return {
"result": response.result,
"source": "fallback",
"tool": fallback_tool,
"primaryError": str(e)
}
except ToolExecutionException as fallback_error:
# နှစ်ခုစလုံး မအောင်မြင်ပါ
logging.error(f"Both primary and fallback tools failed. Fallback error: {str(fallback_error)}")
raise WorkflowExecutionException(
f"Workflow failed: primary error: {str(e)}; fallback error: {str(fallback_error)}"
)

def _adapt_parameters(self, params, from_tool, to_tool):
"""လိုအပ်ပါက tools များအကြား parameters ကို ကိုက်ညီအောင် ပြင်ဆင်သည်"""
# ဒီအကောင်အထည်ဖော်မှုသည် သတ်မှတ်ထားသော tools များပေါ် မူတည်ပါသည်
# ဤဥပမာတွင် မူလ parameters များကို ပြန်ပေးပါမည်
return params

# ဥပမာအသုံးပြုမှု
async def get_weather(workflow, location):
return await workflow.execute_with_fallback(
"premiumWeatherService",  # ပထမဆုံး (ပေးဆောင်ရသော) မိုးလေဝသ API
"basicWeatherService",    # fallback (အခမဲ့) မိုးလေဝသ API
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

// workflow တစ်ခုချင်းစီရဲ့ ရလဒ်ကို သိမ်းဆည်းပါ
results[workflow.Name] = workflowResult;

// နောက်တစ်ခု workflow အတွက် context ကို ရလဒ်ဖြင့် update လုပ်ပါ
context = context.WithResult(workflow.Name, workflowResult);
}

return new WorkflowResult(results);
}

public string Name => "CompositeWorkflow";
public string Description => "အလုပ်စဉ်များစွာကို အဆက်မပြတ် အကောင်အထည်ဖော်သည်";
}

// ဥပမာအသုံးပြုမှု
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
// C# တွင် calculator tool အတွက် ဥပမာ unit test
[Fact]
public async Task CalculatorTool_Add_ReturnsCorrectSum()
{
// စီစဉ်ခြင်း
var calculator = new CalculatorTool();
var parameters = new Dictionary<string, object>
{
["operation"] = "add",
["a"] = 5,
["b"] = 7
};

// လုပ်ဆောင်ခြင်း
var response = await calculator.ExecuteAsync(parameters);
var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());

// အတည်ပြုခြင်း
Assert.Equal(12, result.Value);
}
```

```python
# Python တွင် calculator tool အတွက် ဥပမာ unit test
def test_calculator_tool_add():
# စီစဉ်ခြင်း
calculator = CalculatorTool()
parameters = {
"operation": "add",
"a": 5,
"b": 7
}

# လုပ်ဆောင်ခြင်း
response = calculator.execute(parameters)
result = json.loads(response.content[0].text)

# အတည်ပြုခြင်း
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
// C# တွင် MCP server အတွက် ဥပမာ integration test
[Fact]
public async Task Server_ProcessToolRequest_ReturnsValidResponse()
{
// စီစဉ်ခြင်း
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

// လုပ်ဆောင်ခြင်း
var response = await server.ProcessRequestAsync(request);

// အတည်ပြုခြင်း
Assert.NotNull(response);
Assert.Equal(McpStatusCodes.Success, response.StatusCode);
// response content အတွက် ထပ်မံ အတည်ပြုချက်များ

// သန့်ရှင်းရေး
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
// TypeScript တွင် client ဖြင့် E2E test ဥပမာ
describe('MCP Server E2E Tests', () => {
let client: McpClient;

beforeAll(async () => {
// စမ်းသပ်မှု ပတ်ဝန်းကျင်တွင် server ကို စတင်ပါ
await startTestServer();
client = new McpClient('http://localhost:5000');
});

afterAll(async () => {
await stopTestServer();
});

test('Client သည် calculator tool ကို ခေါ်ယူပြီး မှန်ကန်သော ရလဒ်ရရှိနိုင်သည်', async () => {
// လုပ်ဆောင်ခြင်း
const response = await client.invokeToolAsync('calculator', {
operation: 'divide',
a: 20,
b: 4
});

// အတည်ပြုခြင်း
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
// C# တွင် Moq အသုံးပြုမှု ဥပမာ
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
# Python တွင် unittest.mock ဖြင့် ဥပမာ
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
# mock ကို ပြင်ဆင်ပါ
mock_model.return_value.generate_response.return_value = {
"text": "Mocked model response",
"finish_reason": "completed"
}

# စမ်းသပ်မှုတွင် mock ကို အသုံးပြုပါ
server = McpServer(model_client=mock_model)
# စမ်းသပ်မှု ဆက်လက်လုပ်ဆောင်ပါ
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
// MCP server အတွက် load testing အတွက် k6 script
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
vus: 10,  // virtual user ၁၀ ဦး
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
// စီစဉ်ခြင်း
var client = new HttpClient();
client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");

// လုပ်ဆောင်ခြင်း
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
    // အပို schema စစ်ဆေးခြင်း
});
}

## MCP Server စမ်းသပ်မှု အကျိုးရှိဆုံး အကြံပြုချက် ၁၀ ချက်

1. **စမ်းသပ်မှုကိရိယာ သတ်မှတ်ချက်များကို သီးခြားစစ်ဆေးပါ** - ကိရိယာ၏ လုပ်ဆောင်ချက် logic မှ မဟုတ်ဘဲ schema သတ်မှတ်ချက်များကို သီးခြားစစ်ဆေးပါ
2. **Parameterize လုပ်ထားသော စမ်းသပ်မှုများ အသုံးပြုပါ** - အမျိုးမျိုးသော input များနှင့် အထူးအခြေအနေများဖြင့် ကိရိယာများကို စမ်းသပ်ပါ
3. **အမှားတုံ့ပြန်မှုများ စစ်ဆေးပါ** - ဖြစ်နိုင်သော အမှားအခြေအနေများအားလုံးအတွက် မှန်ကန်သော အမှားကိုင်တွယ်မှုရှိမရှိ စစ်ဆေးပါ
4. **ခွင့်ပြုချက် logic ကို စမ်းသပ်ပါ** - အသုံးပြုသူ အခန်းကဏ္ဍအလိုက် မှန်ကန်သော access control ရှိမရှိ သေချာစစ်ဆေးပါ
5. **စမ်းသပ်မှု ဖုံးလွှမ်းမှုကို စောင့်ကြည့်ပါ** - အရေးကြီးသော လမ်းကြောင်းကုဒ်များအတွက် ဖုံးလွှမ်းမှုမြင့်မားစေရန် ကြိုးစားပါ
6. **Streaming တုံ့ပြန်မှုများကို စမ်းသပ်ပါ** - Streaming အကြောင်းအရာကို မှန်ကန်စွာ ကိုင်တွယ်နိုင်မှုရှိမရှိ စစ်ဆေးပါ
7. **ကွန်ယက်ပြဿနာများကို အတုယူပါ** - ကွန်ယက်အခြေအနေ မကောင်းသောအခါ လုပ်ဆောင်ချက်များကို စမ်းသပ်ပါ
8. **အရင်းအမြစ် ကန့်သတ်ချက်များကို စမ်းသပ်ပါ** - quota သို့မဟုတ် rate limit ရောက်ရှိသည့်အခါ လုပ်ဆောင်ချက်များကို စစ်ဆေးပါ
9. **Regression စမ်းသပ်မှုများကို အလိုအလျောက် ပြုလုပ်ပါ** - ကုဒ်ပြောင်းလဲတိုင်း အလိုအလျောက် ပြေးဆွဲနိုင်သော စမ်းသပ်မှု စနစ်တစ်ခု တည်ဆောက်ပါ
10. **စမ်းသပ်မှု ကိစ္စရပ်များကို မှတ်တမ်းတင်ပါ** - စမ်းသပ်မှု အခြေအနေများကို ရှင်းလင်းစွာ မှတ်တမ်းတင်ထားပါ

## စမ်းသပ်မှုတွင် ဖြစ်တတ်သော အမှားများ

- **အောင်မြင်မှုလမ်းကြောင်းပေါ် မူတည်မှုများ များလွန်းခြင်း** - အမှားဖြစ်နိုင်သော အခြေအနေများကို လုံလောက်စွာ စမ်းသပ်ပါ
- **စွမ်းဆောင်ရည် စမ်းသပ်မှု မလုပ်ခြင်း** - ထုတ်လုပ်မှုကို ထိခိုက်စေမည့် အတားအဆီးများကို ကြိုတင်ရှာဖွေပါ
- **တစ်ခုတည်းသော isolation စမ်းသပ်မှုများသာ ပြုလုပ်ခြင်း** - unit, integration, နှင့် end-to-end စမ်းသပ်မှုများကို ပေါင်းစပ်ပါ
- **API ဖုံးလွှမ်းမှု မပြည့်စုံခြင်း** - endpoint နှင့် လုပ်ဆောင်ချက်အားလုံးကို စမ်းသပ်ပါ
- **စမ်းသပ်မှု ပတ်ဝန်းကျင် မတူညီခြင်း** - စမ်းသပ်မှု ပတ်ဝန်းကျင်များကို တူညီစေရန် container များ အသုံးပြုပါ

## နိဂုံးချုပ်

ယုံကြည်စိတ်ချရပြီး အရည်အသွေးမြင့် MCP server များ ဖန်တီးရန် အပြည့်အစုံ စမ်းသပ်မှု မဟာဗျူဟာသည် အရေးကြီးပါသည်။ ဤလမ်းညွှန်စာအုပ်တွင် ဖော်ပြထားသည့် အကောင်းဆုံး လုပ်ထုံးလုပ်နည်းများနှင့် အကြံပြုချက်များကို လိုက်နာခြင်းဖြင့် သင့် MCP အကောင်အထည်ဖော်မှုများသည် အရည်အသွေး၊ ယုံကြည်စိတ်ချမှုနှင့် စွမ်းဆောင်ရည် အမြင့်ဆုံး စံနှုန်းများနှင့် ကိုက်ညီစေရန် အာမခံနိုင်ပါသည်။

## အဓိက သင်ခန်းစာများ

1. **ကိရိယာ ဒီဇိုင်း** - တစ်ခုတည်းတာဝန်ယူမှု 원칙ကို လိုက်နာပြီး dependency injection ကို အသုံးပြုကာ composability အတွက် ဒီဇိုင်းဆွဲပါ
2. **Schema ဒီဇိုင်း** - ရှင်းလင်းပြီး မှတ်တမ်းတင်ထားသော schema များကို သတ်မှတ်ပြီး မှန်ကန်သော စစ်ဆေးမှု ကန့်သတ်ချက်များ ထည့်သွင်းပါ
3. **အမှားကိုင်တွယ်မှု** - သက်တမ်းရှည် အမှားကိုင်တွယ်မှု၊ ဖွဲ့စည်းထားသော အမှားတုံ့ပြန်မှုများနှင့် ပြန်လည်ကြိုးစားမှု logic များ ထည့်သွင်းပါ
4. **စွမ်းဆောင်ရည်** - caching, asynchronous processing နှင့် resource throttling များ အသုံးပြုပါ
5. **လုံခြုံရေး** - input စစ်ဆေးမှု၊ ခွင့်ပြုချက် စစ်ဆေးမှုများနှင့် အရေးကြီးသော ဒေတာ ကိုင်တွယ်မှုများကို ပြည့်စုံစွာ လုပ်ဆောင်ပါ
6. **စမ်းသပ်မှု** - အပြည့်အစုံ unit, integration နှင့် end-to-end စမ်းသပ်မှုများ ဖန်တီးပါ
7. **လုပ်ငန်းစဉ် ပုံစံများ** - chains, dispatchers နှင့် parallel processing ကဲ့သို့သော အတည်ပြုထားသော ပုံစံများကို အသုံးပြုပါ

## လေ့ကျင့်ခန်း

စာရွက်စာတမ်းများကို အောက်ပါအတိုင်း လုပ်ဆောင်နိုင်သော MCP ကိရိယာနှင့် workflow တစ်ခု ဒီဇိုင်းဆွဲပါ။

1. စာရွက်စာတမ်းများကို အမျိုးမျိုးသော ဖော်မတ်များ (PDF, DOCX, TXT) ဖြင့် လက်ခံနိုင်ရန်
2. စာရွက်စာတမ်းများမှ စာသားနှင့် အဓိက အချက်အလက်များ ထုတ်ယူရန်
3. စာရွက်စာတမ်းများကို အမျိုးအစားနှင့် အကြောင်းအရာအလိုက် သတ်မှတ်ခြင်း
4. စာရွက်စာတမ်းတိုင်းအတွက် အကျဉ်းချုပ် တစ်ခု ထုတ်ပေးရန်

ဤအခြေအနေအတွက် သင့်အနေဖြင့် tool schema များ၊ အမှားကိုင်တွယ်မှုနှင့် workflow ပုံစံကို အကောင်းဆုံး သင့်တော်သော နည်းလမ်းဖြင့် အကောင်အထည်ဖော်ပါ။ ထို့အပြင် ဤအကောင်အထည်ဖော်မှုကို မည်သို့ စမ်းသပ်မည်ကိုလည်း စဉ်းစားပါ။

## အရင်းအမြစ်များ

1. MCP အသိုင်းအဝိုင်းတွင် ပါဝင်ရန် [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs) တွင် ဆက်သွယ်ပါ
2. open-source [MCP projects](https://github.com/modelcontextprotocol) များတွင် ပါဝင်ဆောင်ရွက်ပါ
3. သင့်အဖွဲ့အစည်း၏ AI လုပ်ငန်းများတွင် MCP 원칙များကို အသုံးချပါ
4. သင့်လုပ်ငန်းအတွက် အထူးပြု MCP အကောင်အထည်ဖော်မှုများကို ရှာဖွေပါ
5. multi-modal integration သို့မဟုတ် enterprise application integration ကဲ့သို့ MCP အကြောင်းအရာ အထူးသင်တန်းများကို လေ့လာပါ
6. [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) မှ သင်ယူထားသည့် 원칙များဖြင့် သင့်ကိုယ်ပိုင် MCP ကိရိယာများနှင့် workflow များ တည်ဆောက်၍ စမ်းသပ်ပါ

နောက်တစ်ခု: အကောင်းဆုံး လုပ်ထုံးလုပ်နည်းများ [case studies](../09-CaseStudy/README.md)

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အရင်းအမြစ်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်မှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။