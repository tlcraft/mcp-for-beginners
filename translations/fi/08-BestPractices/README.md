<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "80e5c8949af5af0f401fce6f905990aa",
  "translation_date": "2025-07-17T06:51:11+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "fi"
}
-->
# MCP-kehityksen parhaat käytännöt

## Yleiskatsaus

Tämä oppitunti keskittyy edistyneisiin parhaisiin käytäntöihin MCP-palvelimien ja -ominaisuuksien kehittämisessä, testaamisessa ja käyttöönotossa tuotantoympäristöissä. MCP-ekosysteemien kasvaessa monimutkaisuudeltaan ja merkitykseltään, vakiintuneiden mallien noudattaminen takaa luotettavuuden, ylläpidettävyyden ja yhteentoimivuuden. Tämä oppitunti kokoaa käytännön kokemuksia todellisista MCP-toteutuksista ohjatakseen sinua luomaan vankkoja, tehokkaita palvelimia toimivilla resursseilla, kehotteilla ja työkaluilla.

## Oppimistavoitteet

Oppitunnin lopuksi osaat:
- Soveltaa alan parhaita käytäntöjä MCP-palvelimien ja -ominaisuuksien suunnittelussa
- Laatia kattavia testausstrategioita MCP-palvelimille
- Suunnitella tehokkaita, uudelleenkäytettäviä työnkulkuja monimutkaisiin MCP-sovelluksiin
- Toteuttaa asianmukaisen virheenkäsittelyn, lokituksen ja havaittavuuden MCP-palvelimissa
- Optimoida MCP-toteutukset suorituskyvyn, turvallisuuden ja ylläpidettävyyden näkökulmasta

## MCP:n keskeiset periaatteet

Ennen kuin siirrytään tarkempiin toteutuskäytäntöihin, on tärkeää ymmärtää MCP-kehitystä ohjaavat keskeiset periaatteet:

1. **Standardoitu viestintä**: MCP perustuu JSON-RPC 2.0 -protokollaan, joka tarjoaa yhtenäisen muodon pyyntöihin, vastauksiin ja virheenkäsittelyyn kaikissa toteutuksissa.

2. **Käyttäjäkeskeinen suunnittelu**: Aseta aina käyttäjän suostumus, hallinta ja läpinäkyvyys etusijalle MCP-toteutuksissasi.

3. **Turvallisuus ensin**: Toteuta vahvat turvatoimet, kuten autentikointi, valtuutus, validointi ja käyttörajoitukset.

4. **Modulaarinen arkkitehtuuri**: Suunnittele MCP-palvelimesi modulaarisesti siten, että jokaisella työkalulla ja resurssilla on selkeä ja tarkka tehtävä.

5. **Tilalliset yhteydet**: Hyödynnä MCP:n kykyä ylläpitää tilaa useiden pyyntöjen välillä, jotta vuorovaikutukset ovat johdonmukaisempia ja kontekstuaalisempia.

## Viralliset MCP:n parhaat käytännöt

Seuraavat parhaat käytännöt perustuvat viralliseen Model Context Protocol -dokumentaatioon:

### Turvallisuuden parhaat käytännöt

1. **Käyttäjän suostumus ja hallinta**: Vaadi aina käyttäjän nimenomainen suostumus ennen tietojen käyttöä tai toimintojen suorittamista. Tarjoa selkeä hallinta siitä, mitä tietoja jaetaan ja mitkä toimet ovat sallittuja.

2. **Tietosuoja**: Näytä käyttäjätiedot vain nimenomaisella suostumuksella ja suojaa ne asianmukaisin käyttöoikeuksin. Estä luvaton tiedonsiirto.

3. **Työkalujen turvallisuus**: Vaadi käyttäjän nimenomainen suostumus ennen minkä tahansa työkalun kutsumista. Varmista, että käyttäjät ymmärtävät kunkin työkalun toiminnallisuuden ja toteuta vahvat turvarajat.

4. **Työkalujen käyttöoikeuksien hallinta**: Määritä, mitä työkaluja malli saa käyttää istunnon aikana, varmistaen että vain nimenomaisesti valtuutetut työkalut ovat käytettävissä.

5. **Autentikointi**: Vaadi asianmukainen autentikointi ennen pääsyn myöntämistä työkaluihin, resursseihin tai arkaluonteisiin toimintoihin käyttäen API-avaimia, OAuth-tunnuksia tai muita turvallisia tunnistusmenetelmiä.

6. **Parametrien validointi**: Pakota validointi kaikille työkalukutsuissa, jotta virheelliset tai haitalliset syötteet eivät pääse työkalujen toteutuksiin.

7. **Käyttörajoitukset**: Toteuta käyttörajoitukset väärinkäytösten estämiseksi ja palvelinresurssien oikeudenmukaisen käytön varmistamiseksi.

### Toteutuksen parhaat käytännöt

1. **Ominaisuuksien neuvottelu**: Yhteyden muodostuksen aikana vaihda tietoa tuetuista ominaisuuksista, protokollaversioista, käytettävissä olevista työkaluista ja resursseista.

2. **Työkalujen suunnittelu**: Luo tarkkaan määriteltyjä työkaluja, jotka hoitavat yhden asian hyvin, sen sijaan että tekisit monoliittisia työkaluja, jotka käsittelevät useita asioita.

3. **Virheenkäsittely**: Toteuta standardoidut virheilmoitukset ja -koodit, jotka auttavat ongelmien diagnosoinnissa, virheiden hallinnassa ja tarjoavat toimivia palautteita.

4. **Lokitus**: Määritä jäsennellyt lokit auditointia, virheenkorjausta ja protokollan vuorovaikutusten seurantaa varten.

5. **Edistymisen seuranta**: Pitkissä toiminnoissa raportoi edistymistiedot, jotta käyttöliittymät voivat reagoida nopeasti.

6. **Pyyntöjen peruutus**: Salli asiakkaiden peruuttaa kesken olevat pyynnöt, joita ei enää tarvita tai jotka kestävät liian kauan.

## Lisäviitteet

Ajantasaisimman tiedon MCP:n parhaista käytännöistä löydät osoitteista:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)
- [Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## Käytännön toteutusesimerkit

### Työkalujen suunnittelun parhaat käytännöt

#### 1. Yhden vastuun periaate

Jokaisella MCP-työkalulla tulisi olla selkeä ja tarkka tehtävä. Sen sijaan, että tekisit monoliittisia työkaluja, jotka yrittävät hoitaa useita asioita, kehitä erikoistuneita työkaluja, jotka ovat erinomaisia tietyissä tehtävissä.

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

#### 2. Johdonmukainen virheenkäsittely

Toteuta vahva virheenkäsittely informatiivisilla virheilmoituksilla ja asianmukaisilla palautumismekanismeilla.

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

#### 3. Parametrien validointi

Varmista aina parametrien perusteellinen validointi, jotta virheelliset tai haitalliset syötteet eivät pääse läpi.

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

### Turvallisuuden toteutusesimerkit

#### 1. Autentikointi ja valtuutus

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

#### 2. Käyttörajoitukset

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

## Testauksen parhaat käytännöt

### 1. Yksikkötestaus MCP-työkaluille

Testaa työkalusi aina erillään, käyttäen ulkoisten riippuvuuksien simulointia:

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

### 2. Integraatiotestaus

Testaa koko ketju asiakaspyynnöistä palvelinvastauksiin:

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

## Suorituskyvyn optimointi

### 1. Välimuististrategiat

Toteuta sopiva välimuisti viiveen ja resurssien käytön vähentämiseksi:

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
// Java-esimerkki riippuvuuksien injektiolla
public class CurrencyConversionTool implements Tool {
    private final ExchangeRateService exchangeService;
    private final CacheService cacheService;
    private final Logger logger;
    
    // Riippuvuudet injektoidaan konstruktorin kautta
    public CurrencyConversionTool(
            ExchangeRateService exchangeService,
            CacheService cacheService,
            Logger logger) {
        this.exchangeService = exchangeService;
        this.cacheService = cacheService;
        this.logger = logger;
    }
    
    // Työkalun toteutus
    // ...
}
```

#### 3. Composable Tools

Design tools that can be composed together to create more complex workflows:

```python
# Python-esimerkki, jossa työkalut ovat yhdisteltävissä
class DataFetchTool(Tool):
    def get_name(self):
        return "dataFetch"
    
    # Toteutus...

class DataAnalysisTool(Tool):
    def get_name(self):
        return "dataAnalysis"
    
    # Tämä työkalu voi käyttää dataFetch-työkalun tuloksia
    async def execute_async(self, request):
        # Toteutus...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # Tämä työkalu voi käyttää dataAnalysis-työkalun tuloksia
    async def execute_async(self, request):
        # Toteutus...
        pass

# Näitä työkaluja voi käyttää itsenäisesti tai osana työnkulkua
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
                description = "Hakukyselyn teksti. Käytä tarkkoja avainsanoja parempiin tuloksiin." 
            },
            filters = new {
                type = "object",
                description = "Valinnaiset suodattimet hakutulosten rajaamiseksi",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "Aikaväli muodossa VVVV-KK-PP:VVVV-KK-PP" 
                    },
                    category = new { 
                        type = "string", 
                        description = "Suodatettava kategorian nimi" 
                    }
                }
            },
            limit = new { 
                type = "integer", 
                description = "Palautettavien tulosten enimmäismäärä (1-50)",
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
    
    // Sähköpostiominaisuus muotovalidoinnilla
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "Käyttäjän sähköpostiosoite");
    
    // Ikäominaisuus numeerisilla rajoilla
    Map<String, Object> age = new HashMap<>();
    age.put("type", "integer");
    age.put("minimum", 13);
    age.put("maximum", 120);
    age.put("description", "Käyttäjän ikä vuosina");
    
    // Lueteltu ominaisuus
    Map<String, Object> subscription = new HashMap<>();
    subscription.put("type", "string");
    subscription.put("enum", Arrays.asList("free", "basic", "premium"));
    subscription.put("default", "free");
    subscription.put("description", "Tilaustaso");
    
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
        # Käsittele pyyntö
        results = await self._search_database(request.parameters["query"])
        
        # Palauta aina yhtenäinen rakenne
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
    """Varmistaa, että jokaisella kohteella on yhtenäinen rakenne"""
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
            throw new ToolExecutionException($"Tiedostoa ei löytynyt: {fileId}");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ToolExecutionException("Sinulla ei ole oikeuksia käyttää tätä tiedostoa");
        }
        catch (Exception ex) when (ex is IOException || ex is TimeoutException)
        {
            _logger.LogError(ex, "Virhe tiedostoon pääsyssä {FileId}", fileId);
            throw new ToolExecutionException("Virhe tiedostoon pääsyssä: Palvelu on tilapäisesti poissa käytöstä");
        }
    }
    catch (JsonException)
    {
        throw new ToolExecutionException("Virheellinen tiedoston tunnisteen muoto");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Odottamaton virhe FileAccessToolissa");
        throw new ToolExecutionException("Tapahtui odottamaton virhe");
    }
}
```

#### 2. Structured Error Responses

Return structured error information when possible:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    try {
        // Toteutus
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
        
        // Heitä muut poikkeukset uudelleen ToolExecutionExceptionina
        throw new ToolExecutionException("Työkalun suoritus epäonnistui: " + ex.getMessage(), ex);
    }
}
```

#### 3. Retry Logic

Implement appropriate retry logic for transient failures:

```python
async def execute_async(self, request):
    max_retries = 3
    retry_count = 0
    base_delay = 1  # sekuntia
    
    while retry_count < max_retries:
        try:
            # Kutsu ulkoista APIa
            return await self._call_api(request.parameters)
        except TransientError as e:
            retry_count += 1
            if retry_count >= max_retries:
                raise ToolExecutionException(f"Toiminto epäonnistui {max_retries} yrityksen jälkeen: {str(e)}")
                
            # Eksponentiaalinen viive
            delay = base_delay * (2 ** (retry_count - 1))
            logging.warning(f"Väliaikainen virhe, yritetään uudelleen {delay}s kuluttua: {str(e)}")
            await asyncio.sleep(delay)
        except Exception as e:
            # Ei-väliaikainen virhe, ei uudelleenyritä
            raise ToolExecutionException(f"Toiminto epäonnistui: {str(e)}")
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
        
        // Luo välimuistinäppäin parametrien perusteella
        var cacheKey = $"data_query_{ComputeHash(query)}";
        
        // Yritä ensin hakea välimuistista
        if (_cache.TryGetValue(cacheKey, out var cachedResult))
        {
            return new ToolResponse { Result = cachedResult };
        }
        
        // Välimuistissa ei ole - suorita varsinainen kysely
        var result = await _database.QueryAsync(query);
        
        // Tallenna välimuistiin vanhenemisajalla
        var cacheOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
            
        _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
        
        return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
    }
    
    private string ComputeHash(string input)
    {
        // Toteutus vakaalle hajautusarvolle välimuistin avaimelle
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
        
        // Pitkissä operaatioissa palautetaan käsittelytunnus heti
        String processId = UUID.randomUUID().toString();
        
        // Käynnistä asynkroninen käsittely
        CompletableFuture.runAsync(() -> {
            try {
                // Suorita pitkäkestoinen operaatio
                documentService.processDocument(documentId);
                
                // Päivitä tila (tavallisesti tallennetaan tietokantaan)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // Palauta välitön vastaus käsittelytunnuksella
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // Kumppanityökalu tilan tarkistukseen
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
            tokens_per_second=5,  # Salli 5 pyyntöä sekunnissa
            bucket_size=10        # Salli piikit jopa 10 pyyntöön
        )
    
    async def execute_async(self, request):
        # Tarkista, voimmeko jatkaa vai pitääkö odottaa
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # Jos odotus on liian pitkä
                raise ToolExecutionException(
                    f"Rajanopeus ylittynyt. Yritä uudelleen {delay:.1f} sekunnin kuluttua."
                )
            else:
                # Odota sopiva aika
                await asyncio.sleep(delay)
        
        # Kuluta token ja jatka pyyntöä
        self.rate_limiter.consume()
        
        # Kutsu APIa
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
            
            # Laske aika seuraavaan tokeniin
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # Lisää uusia tokeneita kuluneen ajan perusteella
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
    // Tarkista, että parametrit ovat olemassa
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("Puuttuva vaadittu parametri: query");
    }
    
    // Tarkista oikea tyyppi
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("Query-parametrin tulee olla merkkijono");
    }
    
    var query = queryProp.GetString();
    
    // Tarkista merkkijonon sisältö
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("Query-parametri ei voi olla tyhjä");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("Query-parametri ylittää sallitun 500 merkin pituuden");
    }
    
    // Tarkista SQL-injektiohyökkäykset, jos sovellettavissa
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("Virheellinen kysely: sisältää mahdollisesti vaarallista SQL:ää");
    }
    
    // Jatka suoritusta
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // Hae käyttäjäkonteksti pyynnöstä
    UserContext user = request.getContext().getUserContext();
    
    // Tarkista, onko käyttäjällä tarvittavat oikeudet
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("Käyttäjällä ei ole oikeutta käyttää dokumentteja");
    }
    
    // Tarkista pääsy tiettyyn resurssiin
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("Pääsy pyydettyyn dokumenttiin evätty");
    }
    
    // Jatka työkalun suoritusta
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
        
        # Hae käyttäjätiedot
        user_data = await self.user_service.get_user_data(user_id)
        
        # Suodata arkaluontoiset kentät, ellei erikseen pyydetä JA ole valtuutettu
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # Tarkista valtuutustaso pyynnön kontekstista
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # Luo kopio, jotta alkuperäinen ei muutu
        redacted = user_data.copy()
        
        # Peitä tietyt arkaluontoiset kentät
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # Peitä sisäkkäiset arkaluontoiset tiedot
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
    // Järjestely
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("Seattle", 3))
        .ReturnsAsync(new WeatherForecast(/* testidata */));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "Seattle", 
            days = 3 
        })
    );
    
    // Toiminta
    var response = await tool.ExecuteAsync(request);
    
    // Varmistus
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // Järjestely
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("InvalidLocation", It.IsAny<int>()))
        .ThrowsAsync(new LocationNotFoundException("Sijaintia ei löytynyt"));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "InvalidLocation", 
            days = 3 
        })
    );
    
    // Toiminta & varmistus
    var exception = await Assert.ThrowsAsync<ToolExecutionException>(
        () => tool.ExecuteAsync(request)
    );
    
    Assert.Contains("Sijaintia ei löytynyt", exception.Message);
}
```

#### 2. Schema Validation Testing

Test that schemas are valid and properly enforce constraints:

```java
@Test
public void testSchemaValidation() {
    // Luo työkalun instanssi
    SearchTool searchTool = new SearchTool();
    
    // Hae skeema
    Object schema = searchTool.getSchema();
    
    // Muunna skeema JSONiksi validointia varten
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // Varmista, että skeema on kelvollinen JSONSchema
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // Testaa kelvolliset parametrit
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // Testaa puuttuva vaadittu parametri
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // Testaa virheellinen parametrin tyyppi
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
    # Järjestely
    tool = ApiTool(timeout=0.1)  # Erittäin lyhyt aikakatkaisu
    
    # Mockkaa pyyntö, joka aikakatkaistaan
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # Pidempi kuin aikakatkaisu
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # Toiminta & varmistus
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Varmista, että poikkeusviestissä on timeout-viittaus
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # Järjestely
    tool = ApiTool()
    
    # Mockkaa rajanopeusvastauksen
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
        
        # Toiminta & varmistus
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Varmista, että poikkeus sisältää rajanopeustiedon
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
    // Järjestely
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // Toiminta
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

// Varmistus
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
        // Testaa työkalujen löytymisrajapinta
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // Luo työkalupyyntö
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // Lähetä pyyntö ja tarkista vastaus
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // Luo virheellinen työkalupyyntö
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // Parametri "b" puuttuu
        request.put("parameters", parameters);
        
        // Lähetä pyyntö ja tarkista virhevastauksen olemassaolo
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
    # Valmistelut - Luo MCP-asiakas ja mallin mock
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # Mock-mallin vastaukset
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
    
    # Mock-säätyökalun vastaus
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
        
        # Toiminta
        response = await mcp_client.send_prompt(
            "What's the weather in Seattle?",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # Varmistus
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
    // Valmistelut
    var server = new McpServer(
        name: "TestServer",
        version: "1.0",
        maxConcurrentRequests: 100
    );
    
    server.RegisterTool(new FastExecutingTool());
    await server.StartAsync();
    
    var client = new McpClient("http://localhost:5000");
    
    // Toiminta
    var tasks = new List<Task<McpResponse>>();
    for (int i = 0; i < 1000; i++)
    {
        tasks.Add(client.ExecuteToolAsync("fastTool", new { iteration = i }));
    }
    
    var results = await Task.WhenAll(tasks);
    
    // Varmistus
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
    
    // Määritä JMeter kuormitustestiä varten
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // Konfiguroi JMeterin testisuunnitelma
    HashTree testPlanTree = new HashTree();
    
    // Luo testisuunnitelma, säikeistöryhmä, näytteidenottajat jne.
    TestPlan testPlan = new TestPlan("MCP Server Stress Test");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // Lisää HTTP-näytteidenottaja työkalun suorittamiseen
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // Lisää kuuntelijat
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // Suorita testi
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // Tarkista tulokset
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // Keskimääräinen vasteaika < 200ms
    assertTrue(summaryReport.getPercentile(90.0) < 500); // 90. persentiili < 500ms
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# Määritä valvonta MCP-palvelimelle
def configure_monitoring(server):
    # Luo Prometheus-mittarit
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "Kokonaismäärä MCP-pyyntöjä"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "Pyynnön kesto sekunteina",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "Työkalun suorituskerrat",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "Työkalun suorituksen kesto sekunteina",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "Työkalun suorituksen virheet",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # Lisää middleware ajastusta ja mittareiden tallennusta varten
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # Tarjoa mittarit päätepisteenä
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
# Python-työkaluketjun toteutus
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # Lista suoritettavista työkaluista järjestyksessä
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # Suorita kukin työkalu ketjussa, välitä edellinen tulos
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # Tallenna tulos ja käytä sitä seuraavan työkalun syötteenä
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# Esimerkkikäyttö
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
    public string Description => "Käsittelee eri tyyppistä sisältöä";
    
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
        
        // Määritä, mitä erikoistunutta työkalua käytetään
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // Lähetä pyyntö erikoistuneelle työkalulle
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
# csvProcessor

Tämä moduuli tarjoaa tehokkaita työkaluja CSV-tiedostojen käsittelyyn ja analysointiin.

## Ominaisuudet

- Lue ja kirjoita CSV-tiedostoja helposti
- Tuki erilaisille erottimille, kuten pilkku, puolipiste ja tabulaattori
- Suorita tietojen suodatus ja lajittelu
- Yhteensopiva suurten tiedostojen kanssa

## Käyttöohjeet

```python
from csvProcessor import read_csv, write_csv

# Lue CSV-tiedosto
data = read_csv('data.csv', delimiter=',')

# Suodata rivit, joissa arvo sarakkeessa 'age' on yli 30
filtered_data = [row for row in data if int(row['age']) > 30]

# Kirjoita suodatettu data uuteen tiedostoon
write_csv('filtered_data.csv', filtered_data)
```

## Huomioitavaa

[!NOTE] Muista aina tarkistaa, että käytät oikeaa erottinta CSV-tiedostossasi, jotta tiedot luetaan oikein.

[!WARNING] Suuret tiedostot voivat vaatia enemmän muistia ja prosessointiaikaa.

## Lisätietoja

Katso täydellinen dokumentaatio osoitteesta @@DOCS_URL@@ tai ota yhteyttä tukitiimiin.
("code", _) => "codeAnalyzer",
_ => throw new ToolExecutionException($"Työkalua ei ole saatavilla tyypille {contentType}/{operation}")
};
}

private object GetOptionsForTool(string toolName, string operation)
{
// Palauta sopivat asetukset kullekin erikoistyökalulle
return toolName switch
{
    "textSummarizer" => new { length = "medium" },
    "htmlProcessor" => new { cleanUp = true, operation },
    // Muiden työkalujen asetukset...
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
        // Vaihe 1: Hae aineiston metatiedot (synkroninen)
        ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata", 
            Map.of("datasetId", datasetId));
        
        // Vaihe 2: Käynnistä useita analyysejä rinnakkain
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
        
        // Odota, että kaikki rinnakkaiset tehtävät valmistuvat
        CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
            statisticalAnalysis, correlationAnalysis, outlierDetection
        );
        
        allAnalyses.join();  // Odota valmistumista
        
        // Vaihe 3: Yhdistä tulokset
        Map<String, Object> combinedResults = new HashMap<>();
        combinedResults.put("metadata", metadataResponse.getResult());
        combinedResults.put("statistics", statisticalAnalysis.join().getResult());
        combinedResults.put("correlations", correlationAnalysis.join().getResult());
        combinedResults.put("outliers", outlierDetection.join().getResult());
        
        // Vaihe 4: Luo yhteenvetoraportti
        ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator", 
            Map.of("analysisResults", combinedResults));
        
        // Palauta koko työnkulun tulos
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
            # Kokeile ensin ensisijaista työkalua
            response = await self.client.execute_tool(primary_tool, parameters)
            return {
                "result": response.result,
                "source": "primary",
                "tool": primary_tool
            }
        except ToolExecutionException as e:
            # Kirjaa epäonnistuminen
            logging.warning(f"Ensisijainen työkalu '{primary_tool}' epäonnistui: {str(e)}")
            
            # Siirry varatyökaluun
            try:
                # Saattaa olla tarpeen muokata parametreja varatyökalulle
                fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)
                
                response = await self.client.execute_tool(fallback_tool, fallback_params)
                return {
                    "result": response.result,
                    "source": "fallback",
                    "tool": fallback_tool,
                    "primaryError": str(e)
                }
            except ToolExecutionException as fallback_error:
                # Molemmat työkalut epäonnistuivat
                logging.error(f"Molemmat ensisijainen ja varatyökalu epäonnistuivat. Varatyökalun virhe: {str(fallback_error)}")
                raise WorkflowExecutionException(
                    f"Työnkulku epäonnistui: ensisijainen virhe: {str(e)}; varatyökalun virhe: {str(fallback_error)}"
                )
    
    def _adapt_parameters(self, params, from_tool, to_tool):
        """Muokkaa parametreja eri työkalujen välillä tarvittaessa"""
        # Tämä toteutus riippuu käytetyistä työkaluista
        # Tässä esimerkissä palautetaan alkuperäiset parametrit sellaisenaan
        return params

# Esimerkkikäyttö
async def get_weather(workflow, location):
    return await workflow.execute_with_fallback(
        "premiumWeatherService",  # Ensisijainen (maksullinen) sääpalvelu
        "basicWeatherService",    # Varapalvelu (ilmainen) sääpalvelu
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
            
            // Tallenna kunkin työnkulun tulos
            results[workflow.Name] = workflowResult;
            
            // Päivitä konteksti seuraavaa työnkulkua varten
            context = context.WithResult(workflow.Name, workflowResult);
        }
        
        return new WorkflowResult(results);
    }
    
    public string Name => "CompositeWorkflow";
    public string Description => "Suorittaa useita työnkulkuja peräkkäin";
}

// Esimerkkikäyttö
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
// Esimerkkiyksikkötesti laskin-työkalulle C#:ssa
[Fact]
public async Task CalculatorTool_Add_ReturnsCorrectSum()
{
    // Järjestely
    var calculator = new CalculatorTool();
    var parameters = new Dictionary<string, object>
    {
        ["operation"] = "add",
        ["a"] = 5,
        ["b"] = 7
    };
    
    // Toiminta
    var response = await calculator.ExecuteAsync(parameters);
    var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());
    
    // Varmistus
    Assert.Equal(12, result.Value);
}
```

```python
# Esimerkkiyksikkötesti laskin-työkalulle Pythonissa
def test_calculator_tool_add():
    # Järjestely
    calculator = CalculatorTool()
    parameters = {
        "operation": "add",
        "a": 5,
        "b": 7
    }
    
    # Toiminta
    response = calculator.execute(parameters)
    result = json.loads(response.content[0].text)
    
    # Varmistus
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
// Esimerkkaintegraatiotesti MCP-palvelimelle C#:ssa
[Fact]
public async Task Server_ProcessToolRequest_ReturnsValidResponse()
{
    // Järjestely
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
    
    // Toiminta
    var response = await server.ProcessRequestAsync(request);
    
    // Varmistus
    Assert.NotNull(response);
    Assert.Equal(McpStatusCodes.Success, response.StatusCode);
    // Lisävahvistukset vastauksen sisällölle
    
    // Siivous
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
// Esimerkkipääte-testi asiakkaalla TypeScriptissä
describe('MCP Server E2E Tests', () => {
  let client: McpClient;
  
  beforeAll(async () => {
    // Käynnistä palvelin testausympäristössä
    await startTestServer();
    client = new McpClient('http://localhost:5000');
  });
  
  afterAll(async () => {
    await stopTestServer();
  });
  
  test('Asiakas voi kutsua laskin-työkalua ja saada oikean tuloksen', async () => {
    // Toiminta
    const response = await client.invokeToolAsync('calculator', {
      operation: 'divide',
      a: 20,
      b: 4
    });
    
    // Varmistus
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
// C# esimerkki Moq-kirjastolla
var mockModel = new Mock<ILanguageModel>();
mockModel
    .Setup(m => m.GenerateResponseAsync(
        It.IsAny<string>(),
        It.IsAny<McpRequestContext>()))
    .ReturnsAsync(new ModelResponse { 
        Text = "Mockattu mallin vastaus",
        FinishReason = FinishReason.Completed
    });

var server = new McpServer(modelClient: mockModel.Object);
```

```python
# Python-esimerkki unittest.mockilla
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
    # Määritä mock
    mock_model.return_value.generate_response.return_value = {
        "text": "Mockattu mallin vastaus",
        "finish_reason": "completed"
    }
    
    # Käytä mockia testissä
    server = McpServer(model_client=mock_model)
    # Jatka testin suorittamista
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
// k6-skripti MCP-palvelimen kuormitustestaukseen
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  vus: 10,  // 10 virtuaalikäyttäjää
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
    // Järjestely
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");
    
    // Toiminta
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
    // Lisäkaavion validointi
});
}
```

## Top 10 vinkkiä tehokkaaseen MCP-palvelimen testaamiseen

1. **Testaa työkalumääritelmät erikseen**: Varmista kaavion määritelmät erillään työkalulogiiikasta  
2. **Käytä parametrisoituja testejä**: Testaa työkaluja erilaisilla syötteillä, myös ääritapauksilla  
3. **Tarkista virhevastaukset**: Varmista virheenkäsittely kaikissa mahdollisissa virhetilanteissa  
4. **Testaa valtuutuslogiikka**: Varmista oikea pääsynhallinta eri käyttäjärooleille  
5. **Seuraa testikattavuutta**: Pyri kattavaan testaukseen kriittisissä koodipoluissa  
6. **Testaa suoratoistovastaukset**: Varmista suoratoistosisällön oikea käsittely  
7. **Simuloi verkkohäiriöitä**: Testaa toiminta heikoissa verkkoyhteyksissä  
8. **Testaa resurssirajoitukset**: Tarkista toiminta, kun saavutetaan kiintiöt tai nopeusrajoitukset  
9. **Automatisoi regressiotestit**: Rakenna testipaketti, joka ajetaan jokaisen koodimuutoksen yhteydessä  
10. **Dokumentoi testitapaukset**: Pidä testiskenaarioista selkeää dokumentaatiota  

## Yleisiä testauksen sudenkuoppia

- **Liiallinen luottamus onnistuneisiin polkuihin**: Muista testata virhetilanteet huolellisesti  
- **Suorituskyvyn testaamisen laiminlyönti**: Tunnista pullonkaulat ennen tuotantoon siirtymistä  
- **Testaus vain eristyksissä**: Yhdistä yksikkö-, integraatio- ja E2E-testit  
- **Epätyydyttävä API-kattavuus**: Varmista, että kaikki päätepisteet ja ominaisuudet testataan  
- **Epäjohdonmukaiset testausympäristöt**: Käytä kontteja yhtenäisten testausympäristöjen varmistamiseksi  

## Yhteenveto

Laaja testausstrategia on välttämätön luotettavien ja laadukkaiden MCP-palvelimien kehittämisessä. Noudattamalla tässä oppaassa esitettyjä parhaita käytäntöjä ja vinkkejä varmistat, että MCP-ratkaisusi täyttävät korkeimmat laatu-, luotettavuus- ja suorituskykyvaatimukset.  

## Keskeiset opit

1. **Työkalusuunnittelu**: Noudata yksittäisen vastuun periaatetta, käytä riippuvuuksien injektiota ja suunnittele modulaarisesti  
2. **Kaavion suunnittelu**: Luo selkeät, hyvin dokumentoidut kaaviot asianmukaisine validointirajoitteineen  
3. **Virheenkäsittely**: Toteuta sujuva virheenkäsittely, jäsennellyt virhevastaukset ja uudelleenyrittomekanismit  
4. **Suorituskyky**: Hyödynnä välimuistia, asynkronista käsittelyä ja resurssien rajoitusta  
5. **Turvallisuus**: Käytä perusteellista syötteen validointia, valtuutustarkistuksia ja arkaluonteisen datan käsittelyä  
6. **Testaus**: Luo kattavat yksikkö-, integraatio- ja loppukäyttäjätestit  
7. **Työnkulkujen mallit**: Hyödynnä vakiintuneita malleja kuten ketjut, lähettäjät ja rinnakkainen käsittely  

## Harjoitus

Suunnittele MCP-työkalu ja työnkulku asiakirjojen käsittelyjärjestelmälle, joka:

1. Ottaa vastaan asiakirjoja useissa formaateissa (PDF, DOCX, TXT)  
2. Uuttaa tekstiä ja keskeisiä tietoja asiakirjoista  
3. Luokittelee asiakirjat tyypin ja sisällön perusteella  
4. Laatii yhteenvedon jokaisesta asiakirjasta  

Toteuta työkalujen kaaviot, virheenkäsittely ja työnkulun malli, joka sopii parhaiten tähän käyttötapaukseen. Pohdi myös, miten testaisit tämän toteutuksen.  

## Resurssit

1. Liity MCP-yhteisöön [Azure AI Foundry Discord Communityssä](https://aka.ms/foundrydevs) pysyäksesi ajan tasalla viimeisimmistä kehityksistä  
2. Osallistu avoimen lähdekoodin [MCP-projekteihin](https://github.com/modelcontextprotocol)  
3. Hyödynnä MCP-periaatteita oman organisaatiosi tekoälyhankkeissa  
4. Tutustu toimialakohtaisiin MCP-ratkaisuihin  
5. Harkitse edistyneitä kursseja erityisistä MCP-aiheista, kuten multimodaalinen integraatio tai yrityssovellusintegraatio  
6. Kokeile rakentaa omia MCP-työkaluja ja työnkulkuja oppimiesi periaatteiden pohjalta [Hands on Labin](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) avulla  

Seuraavaksi: Parhaat käytännöt [case studyt](../09-CaseStudy/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.