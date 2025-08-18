<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b62150e27d4b7b5797ee41146d176e6b",
  "translation_date": "2025-08-18T14:28:09+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "hu"
}
-->
# MCP Fejlesztési Legjobb Gyakorlatok

[![MCP Fejlesztési Legjobb Gyakorlatok](../../../translated_images/09.d0f6d86c9d72134ccf5a8d8c8650a0557e519936661fc894cad72d73522227cb.hu.png)](https://youtu.be/W56H9W7x-ao)

_(Kattints a fenti képre a leckéhez tartozó videó megtekintéséhez)_

## Áttekintés

Ez a lecke az MCP szerverek és funkciók fejlesztésének, tesztelésének és éles környezetben történő telepítésének haladó legjobb gyakorlataira összpontosít. Ahogy az MCP ökoszisztémák egyre összetettebbé és fontosabbá válnak, a bevált minták követése biztosítja a megbízhatóságot, karbantarthatóságot és interoperabilitást. Ez a lecke a valós MCP implementációkból származó gyakorlati tapasztalatokat foglalja össze, hogy segítsen robusztus, hatékony szervereket létrehozni megfelelő erőforrásokkal, promptokkal és eszközökkel.

## Tanulási célok

A lecke végére képes leszel:

- Az iparági legjobb gyakorlatokat alkalmazni MCP szerverek és funkciók tervezésében
- Átfogó tesztelési stratégiákat kidolgozni MCP szerverekhez
- Hatékony, újrahasznosítható munkafolyamat-mintákat tervezni összetett MCP alkalmazásokhoz
- Megfelelő hibakezelést, naplózást és megfigyelhetőséget megvalósítani MCP szerverekben
- Optimalizálni az MCP implementációkat teljesítmény, biztonság és karbantarthatóság szempontjából

## MCP Alapelvek

Mielőtt belevágnánk a konkrét implementációs gyakorlatokba, fontos megérteni azokat az alapelveket, amelyek az MCP fejlesztés hatékonyságát vezérlik:

1. **Standardizált Kommunikáció**: Az MCP az JSON-RPC 2.0-t használja alapként, amely egységes formátumot biztosít a kérésekhez, válaszokhoz és hibakezeléshez minden implementációban.

2. **Felhasználóközpontú Tervezés**: Mindig helyezd előtérbe a felhasználói beleegyezést, irányítást és átláthatóságot az MCP implementációidban.

3. **Biztonság Elsőként**: Valósíts meg erős biztonsági intézkedéseket, beleértve az autentikációt, autorizációt, validációt és sebességkorlátozást.

4. **Moduláris Architektúra**: Tervezd az MCP szervereket moduláris megközelítéssel, ahol minden eszköznek és erőforrásnak világos, fókuszált célja van.

5. **Állapotmegőrző Kapcsolatok**: Használd ki az MCP azon képességét, hogy több kérés között is megőrizze az állapotot, így koherensebb és kontextusérzékenyebb interakciókat biztosítva.

## Hivatalos MCP Legjobb Gyakorlatok

Az alábbi legjobb gyakorlatok a hivatalos Model Context Protocol dokumentációból származnak:

### Biztonsági Legjobb Gyakorlatok

1. **Felhasználói Beleegyezés és Irányítás**: Mindig kérj kifejezett felhasználói beleegyezést az adatokhoz való hozzáférés vagy műveletek végrehajtása előtt. Biztosíts egyértelmű irányítást az adatok megosztása és az engedélyezett műveletek felett.

2. **Adatvédelem**: Csak kifejezett beleegyezéssel tedd elérhetővé a felhasználói adatokat, és védd azokat megfelelő hozzáférés-vezérléssel. Óvd az illetéktelen adatátviteltől.

3. **Eszközbiztonság**: Mindig kérj kifejezett felhasználói beleegyezést bármely eszköz meghívása előtt. Biztosítsd, hogy a felhasználók megértsék az eszközök működését, és érvényesíts szigorú biztonsági határokat.

4. **Eszközengedélyek Szabályozása**: Konfiguráld, hogy egy modell mely eszközöket használhat egy munkamenet során, biztosítva, hogy csak kifejezetten engedélyezett eszközök legyenek elérhetők.

5. **Hitelesítés**: Követelj megfelelő hitelesítést az eszközökhöz, erőforrásokhoz vagy érzékeny műveletekhez való hozzáférés előtt API kulcsok, OAuth tokenek vagy más biztonságos hitelesítési módszerek használatával.

6. **Paraméterek Validálása**: Érvényesíts minden eszközhívást, hogy megakadályozd a hibás vagy rosszindulatú bemenetek elérését az eszköz implementációkhoz.

7. **Sebességkorlátozás**: Valósíts meg sebességkorlátozást a visszaélések megelőzése és a szerver erőforrásainak igazságos használata érdekében.

### Implementációs Legjobb Gyakorlatok

1. **Képességek Egyeztetése**: A kapcsolat beállítása során cserélj információt a támogatott funkciókról, protokollverziókról, elérhető eszközökről és erőforrásokról.

2. **Eszköztervezés**: Hozz létre fókuszált eszközöket, amelyek egy adott feladatot jól végeznek, ahelyett, hogy több problémát kezelő monolitikus eszközöket fejlesztenél.

3. **Hibakezelés**: Valósíts meg szabványosított hibaüzeneteket és kódokat, hogy segítsd a problémák diagnosztizálását, a hibák zökkenőmentes kezelését és az érdemi visszajelzést.

4. **Naplózás**: Konfigurálj strukturált naplókat az MCP interakciók auditálásához, hibakereséséhez és monitorozásához.

5. **Haladás Követése**: Hosszú műveletek esetén jelentkezz haladásfrissítésekkel, hogy a felhasználói felületek reszponzívak maradjanak.

6. **Kérések Megszakítása**: Engedd meg az ügyfeleknek, hogy megszakítsák a folyamatban lévő kéréseket, amelyekre már nincs szükségük, vagy amelyek túl sokáig tartanak.

## További Hivatkozások

A legfrissebb információkért az MCP legjobb gyakorlatokról, lásd:

- [MCP Dokumentáció](https://modelcontextprotocol.io/)
- [MCP Specifikáció](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)
- [Biztonsági Legjobb Gyakorlatok](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## Gyakorlati Implementációs Példák

### Eszköztervezési Legjobb Gyakorlatok

#### 1. Egyetlen Felelősség Elve

Minden MCP eszköznek világos, fókuszált célja legyen. Ahelyett, hogy több problémát kezelő monolitikus eszközöket hoznál létre, fejlessz specializált eszközöket, amelyek egy adott feladatban kiválóak.

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

#### 2. Következetes Hibakezelés

Valósíts meg robusztus hibakezelést informatív hibaüzenetekkel és megfelelő helyreállítási mechanizmusokkal.

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

#### 3. Paraméterek Validálása

Mindig alaposan validáld a paramétereket, hogy megakadályozd a hibás vagy rosszindulatú bemeneteket.

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

### Biztonsági Implementációs Példák

#### 1. Hitelesítés és Jogosultságkezelés

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

#### 2. Sebességkorlátozás

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

...
3. **Teljesítmény alapértékek**: Tartsd fenn a teljesítmény benchmarkokat, hogy időben észleld a visszaeséseket  
4. **Biztonsági vizsgálatok**: Automatizáld a biztonsági tesztelést a folyamat részeként  

### Példa CI Pipeline (GitHub Actions)

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

## MCP Specifikációnak való megfelelés tesztelése  

Ellenőrizd, hogy a szerver megfelelően implementálja az MCP specifikációt.  

### Kulcsfontosságú megfelelési területek  

1. **API végpontok**: Teszteld a kötelező végpontokat (/resources, /tools, stb.)  
2. **Kérés/Válasz formátum**: Ellenőrizd a séma megfelelőségét  
3. **Hibakódok**: Ellenőrizd a megfelelő státuszkódokat különböző helyzetekben  
4. **Tartalomtípusok**: Teszteld a különböző tartalomtípusok kezelését  
5. **Hitelesítési folyamat**: Ellenőrizd a specifikációnak megfelelő hitelesítési mechanizmusokat  

### Megfelelési tesztcsomag  

```csharp
[Fact]
public async Task Server_ResourceEndpoint_ReturnsCorrectSchema()
{
    // Arrange
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");
    
    // Act
    var response = await client.GetAsync("http://localhost:5000/api/resources");
    var content = await response.Content.ReadAsStringAsync();
    var resources = JsonSerializer.Deserialize<ResourceList>(content);
    
    // Assert
    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    Assert.NotNull(resources);
    Assert.All(resources.Resources, resource => 
    {
        Assert.NotNull(resource.Id);
        Assert.NotNull(resource.Type);
        // Additional schema validation
    });
}
```

## 10 legjobb tipp az MCP szerver hatékony teszteléséhez  

1. **Eszközdefiníciók külön tesztelése**: Ellenőrizd a séma definíciókat függetlenül az eszköz logikájától  
2. **Paraméterezett tesztek használata**: Teszteld az eszközöket különböző bemenetekkel, beleértve a szélsőséges eseteket  
3. **Hibaválaszok ellenőrzése**: Ellenőrizd a megfelelő hibakezelést minden lehetséges hibahelyzetben  
4. **Hitelesítési logika tesztelése**: Biztosítsd a megfelelő hozzáférés-ellenőrzést különböző felhasználói szerepkörökhöz  
5. **Tesztlefedettség figyelése**: Törekedj a kritikus kódútvonalak magas lefedettségére  
6. **Streaming válaszok tesztelése**: Ellenőrizd a streaming tartalom megfelelő kezelését  
7. **Hálózati problémák szimulálása**: Teszteld a viselkedést gyenge hálózati körülmények között  
8. **Erőforrás-korlátok tesztelése**: Ellenőrizd a viselkedést kvóták vagy sebességkorlátok elérésekor  
9. **Automatizált regressziós tesztek**: Építs egy tesztcsomagot, amely minden kódváltozáskor lefut  
10. **Teszt esetek dokumentálása**: Tartsd karban a teszt forgatókönyvek egyértelmű dokumentációját  

## Gyakori tesztelési buktatók  

- **Túlzott támaszkodás a "happy path" tesztelésre**: Teszteld alaposan a hibás eseteket is  
- **Teljesítménytesztelés figyelmen kívül hagyása**: Azonosítsd a szűk keresztmetszeteket, mielőtt azok hatással lennének a termelésre  
- **Csak izolált tesztelés**: Kombináld az egység-, integrációs és végpontok közötti teszteket  
- **Hiányos API lefedettség**: Biztosítsd, hogy minden végpont és funkció tesztelve legyen  
- **Következetlen tesztkörnyezetek**: Használj konténereket a következetes tesztkörnyezetek biztosításához  

## Következtetés  

Átfogó tesztelési stratégia elengedhetetlen a megbízható, magas minőségű MCP szerverek fejlesztéséhez. Az ebben az útmutatóban bemutatott legjobb gyakorlatok és tippek alkalmazásával biztosíthatod, hogy MCP implementációid megfeleljenek a legmagasabb minőségi, megbízhatósági és teljesítménybeli követelményeknek.  

## Fő tanulságok  

1. **Eszköztervezés**: Kövesd az egyetlen felelősség elvét, használj függőség injektálást, és tervezz összetettségre  
2. **Séma tervezés**: Hozz létre egyértelmű, jól dokumentált sémákat megfelelő validációs korlátokkal  
3. **Hibakezelés**: Valósíts meg elegáns hibakezelést, strukturált hibaválaszokat és újrapróbálkozási logikát  
4. **Teljesítmény**: Használj gyorsítótárazást, aszinkron feldolgozást és erőforrás-korlátozást  
5. **Biztonság**: Alkalmazz alapos bemenet validálást, hozzáférés-ellenőrzéseket és érzékeny adatok kezelését  
6. **Tesztelés**: Hozz létre átfogó egység-, integrációs és végpontok közötti teszteket  
7. **Munkafolyamat minták**: Alkalmazz bevált mintákat, mint például láncok, diszpécserek és párhuzamos feldolgozás  

## Gyakorlat  

Tervezd meg egy dokumentumfeldolgozó rendszer MCP eszközét és munkafolyamatát, amely:  

1. Több formátumú dokumentumokat fogad el (PDF, DOCX, TXT)  
2. Kinyeri a szöveget és kulcsfontosságú információkat a dokumentumokból  
3. Osztályozza a dokumentumokat típus és tartalom alapján  
4. Összefoglalót készít minden dokumentumról  

Valósítsd meg az eszköz sémáit, hibakezelést és egy munkafolyamat mintát, amely a legjobban illeszkedik ehhez a forgatókönyvhöz. Gondold át, hogyan tesztelnéd ezt az implementációt.  

## Források  

1. Csatlakozz az MCP közösséghez az [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs) platformon, hogy naprakész maradj a legújabb fejlesztésekkel kapcsolatban  
2. Járulj hozzá nyílt forráskódú [MCP projektekhez](https://github.com/modelcontextprotocol)  
3. Alkalmazd az MCP elveket saját szervezeted AI kezdeményezéseiben  
4. Fedezd fel az iparágad számára specializált MCP implementációkat  
5. Fontold meg haladó kurzusok elvégzését az MCP specifikus témákban, mint például multimodális integráció vagy vállalati alkalmazásintegráció  
6. Kísérletezz saját MCP eszközök és munkafolyamatok építésével az útmutatóban tanult elvek alapján a [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) segítségével  

Következő: Legjobb gyakorlatok [esettanulmányok](../09-CaseStudy/README.md)  

**Felelősségkizárás**:  
Ez a dokumentum az [Co-op Translator](https://github.com/Azure/co-op-translator) AI fordítási szolgáltatás segítségével készült. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az eredeti nyelvén tekintendő hiteles forrásnak. Kritikus információk esetén javasolt a professzionális, emberi fordítás igénybevétele. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.