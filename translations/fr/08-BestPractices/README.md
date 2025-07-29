<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1827d0f7a6430dfb7adcdd5f1ee05bda",
  "translation_date": "2025-07-28T23:53:10+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "fr"
}
-->
# Meilleures pratiques de développement MCP

[![Meilleures pratiques de développement MCP](../../../translated_images/09.d0f6d86c9d72134ccf5a8d8c8650a0557e519936661fc894cad72d73522227cb.fr.png)](https://youtu.be/W56H9W7x-ao)

_(Cliquez sur l'image ci-dessus pour visionner la vidéo de cette leçon)_

## Aperçu

Cette leçon se concentre sur les meilleures pratiques avancées pour développer, tester et déployer des serveurs MCP et leurs fonctionnalités dans des environnements de production. À mesure que les écosystèmes MCP gagnent en complexité et en importance, suivre des modèles établis garantit fiabilité, maintenabilité et interopérabilité. Cette leçon rassemble des enseignements pratiques issus d'implémentations MCP réelles pour vous guider dans la création de serveurs robustes et efficaces avec des ressources, des invites et des outils performants.

## Objectifs d'apprentissage

À la fin de cette leçon, vous serez capable de :

- Appliquer les meilleures pratiques de l'industrie dans la conception de serveurs et de fonctionnalités MCP
- Élaborer des stratégies de test complètes pour les serveurs MCP
- Concevoir des modèles de workflow efficaces et réutilisables pour des applications MCP complexes
- Mettre en œuvre une gestion des erreurs, une journalisation et une observabilité appropriées dans les serveurs MCP
- Optimiser les implémentations MCP pour la performance, la sécurité et la maintenabilité

## Principes fondamentaux du MCP

Avant de plonger dans les pratiques spécifiques d'implémentation, il est important de comprendre les principes fondamentaux qui guident un développement MCP efficace :

1. **Communication standardisée** : MCP utilise JSON-RPC 2.0 comme base, offrant un format cohérent pour les requêtes, les réponses et la gestion des erreurs dans toutes les implémentations.

2. **Conception centrée sur l'utilisateur** : Priorisez toujours le consentement, le contrôle et la transparence de l'utilisateur dans vos implémentations MCP.

3. **Sécurité avant tout** : Mettez en œuvre des mesures de sécurité robustes, notamment l'authentification, l'autorisation, la validation et la limitation de débit.

4. **Architecture modulaire** : Concevez vos serveurs MCP avec une approche modulaire, où chaque outil et ressource a un objectif clair et précis.

5. **Connexions avec état** : Exploitez la capacité du MCP à maintenir un état entre plusieurs requêtes pour des interactions plus cohérentes et contextuelles.

## Meilleures pratiques officielles du MCP

Les meilleures pratiques suivantes sont issues de la documentation officielle du Model Context Protocol :

### Meilleures pratiques en matière de sécurité

1. **Consentement et contrôle de l'utilisateur** : Exigez toujours un consentement explicite de l'utilisateur avant d'accéder aux données ou d'effectuer des opérations. Fournissez un contrôle clair sur les données partagées et les actions autorisées.

2. **Confidentialité des données** : N'exposez les données utilisateur qu'avec un consentement explicite et protégez-les avec des contrôles d'accès appropriés. Prévenez toute transmission non autorisée de données.

3. **Sécurité des outils** : Exigez un consentement explicite de l'utilisateur avant d'invoquer un outil. Assurez-vous que les utilisateurs comprennent la fonctionnalité de chaque outil et appliquez des limites de sécurité robustes.

4. **Contrôle des permissions des outils** : Configurez les outils qu'un modèle est autorisé à utiliser pendant une session, en veillant à ce que seuls les outils explicitement autorisés soient accessibles.

5. **Authentification** : Exigez une authentification appropriée avant d'accorder l'accès aux outils, ressources ou opérations sensibles en utilisant des clés API, des jetons OAuth ou d'autres méthodes sécurisées.

6. **Validation des paramètres** : Appliquez une validation pour toutes les invocations d'outils afin d'empêcher les entrées malformées ou malveillantes d'atteindre les implémentations des outils.

7. **Limitation de débit** : Implémentez une limitation de débit pour prévenir les abus et garantir une utilisation équitable des ressources du serveur.

### Meilleures pratiques d'implémentation

1. **Négociation des capacités** : Lors de l'établissement de la connexion, échangez des informations sur les fonctionnalités prises en charge, les versions de protocole, les outils disponibles et les ressources.

2. **Conception des outils** : Créez des outils spécialisés qui excellent dans une tâche spécifique, plutôt que des outils monolithiques qui gèrent plusieurs préoccupations.

3. **Gestion des erreurs** : Implémentez des messages d'erreur standardisés et des codes pour aider à diagnostiquer les problèmes, gérer les échecs de manière élégante et fournir des retours exploitables.

4. **Journalisation** : Configurez des journaux structurés pour l'audit, le débogage et la surveillance des interactions du protocole.

5. **Suivi de progression** : Pour les opérations de longue durée, rapportez des mises à jour de progression pour permettre des interfaces utilisateur réactives.

6. **Annulation des requêtes** : Permettez aux clients d'annuler les requêtes en cours qui ne sont plus nécessaires ou qui prennent trop de temps.

## Références supplémentaires

Pour des informations à jour sur les meilleures pratiques MCP, consultez :

- [Documentation MCP](https://modelcontextprotocol.io/)
- [Spécification MCP](https://spec.modelcontextprotocol.io/)
- [Dépôt GitHub](https://github.com/modelcontextprotocol)
- [Meilleures pratiques de sécurité](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## Exemples pratiques d'implémentation

### Meilleures pratiques de conception des outils

#### 1. Principe de responsabilité unique

Chaque outil MCP doit avoir un objectif clair et précis. Plutôt que de créer des outils monolithiques qui tentent de gérer plusieurs préoccupations, développez des outils spécialisés qui excellent dans des tâches spécifiques.

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

#### 2. Gestion cohérente des erreurs

Implémentez une gestion robuste des erreurs avec des messages d'erreur informatifs et des mécanismes de récupération appropriés.

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

#### 3. Validation des paramètres

Validez toujours les paramètres de manière approfondie pour éviter les entrées malformées ou malveillantes.

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

### Exemples d'implémentation de sécurité

#### 1. Authentification et autorisation

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

#### 2. Limitation de débit

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

## Meilleures pratiques de test

### 1. Tests unitaires des outils MCP

Testez toujours vos outils de manière isolée, en simulant les dépendances externes :

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

### 2. Tests d'intégration

Testez le flux complet des requêtes client aux réponses serveur :

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

## Optimisation des performances

### 1. Stratégies de mise en cache

Implémentez des mécanismes de mise en cache appropriés pour réduire la latence et l'utilisation des ressources :

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
// Exemple Java avec injection de dépendances
public class CurrencyConversionTool implements Tool {
    private final ExchangeRateService exchangeService;
    private final CacheService cacheService;
    private final Logger logger;
    
    // Dépendances injectées via le constructeur
    public CurrencyConversionTool(
            ExchangeRateService exchangeService,
            CacheService cacheService,
            Logger logger) {
        this.exchangeService = exchangeService;
        this.cacheService = cacheService;
        this.logger = logger;
    }
    
    // Implémentation de l'outil
    // ...
}
```

#### 3. Composable Tools

Design tools that can be composed together to create more complex workflows:

```python
# Exemple Python montrant des outils composables
class DataFetchTool(Tool):
    def get_name(self):
        return "dataFetch"
    
    # Implémentation...

class DataAnalysisTool(Tool):
    def get_name(self):
        return "dataAnalysis"
    
    # Cet outil peut utiliser les résultats de l'outil dataFetch
    async def execute_async(self, request):
        # Implémentation...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # Cet outil peut utiliser les résultats de l'outil dataAnalysis
    async def execute_async(self, request):
        # Implémentation...
        pass

# Ces outils peuvent être utilisés indépendamment ou dans le cadre d'un workflow
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
                description = "Texte de la requête de recherche. Utilisez des mots-clés précis pour de meilleurs résultats." 
            },
            filters = new {
                type = "object",
                description = "Filtres optionnels pour affiner les résultats de recherche",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "Plage de dates au format YYYY-MM-DD:YYYY-MM-DD" 
                    },
                    category = new { 
                        type = "string", 
                        description = "Nom de la catégorie pour filtrer" 
                    }
                }
            },
            limit = new { 
                type = "integer", 
                description = "Nombre maximum de résultats à retourner (1-50)",
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
    
    // Propriété email avec validation de format
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "Adresse email de l'utilisateur");
    
    // Propriété âge avec contraintes numériques
    Map<String, Object> age = new HashMap<>();
    age.put("type", "integer");
    age.put("minimum", 13);
    age.put("maximum", 120);
    age.put("description", "Âge de l'utilisateur en années");
    
    // Propriété énumérée
    Map<String, Object> subscription = new HashMap<>();
    subscription.put("type", "string");
    subscription.put("enum", Arrays.asList("free", "basic", "premium"));
    subscription.put("default", "free");
    subscription.put("description", "Niveau d'abonnement");
    
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
        # Traiter la requête
        results = await self._search_database(request.parameters["query"])
        
        # Toujours retourner une structure cohérente
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
    """Assure que chaque élément a une structure cohérente"""
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
            throw new ToolExecutionException($"Fichier introuvable : {fileId}");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ToolExecutionException("Vous n'avez pas la permission d'accéder à ce fichier");
        }
        catch (Exception ex) when (ex is IOException || ex is TimeoutException)
        {
            _logger.LogError(ex, "Erreur d'accès au fichier {FileId}", fileId);
            throw new ToolExecutionException("Erreur d'accès au fichier : Le service est temporairement indisponible");
        }
    }
    catch (JsonException)
    {
        throw new ToolExecutionException("Format d'ID de fichier invalide");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Erreur inattendue dans FileAccessTool");
        throw new ToolExecutionException("Une erreur inattendue s'est produite");
    }
}
```

#### 2. Structured Error Responses

Return structured error information when possible:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    try {
        // Implémentation
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
        
        // Relancer d'autres exceptions comme ToolExecutionException
        throw new ToolExecutionException("Échec de l'exécution de l'outil : " + ex.getMessage(), ex);
    }
}
```

#### 3. Retry Logic

Implement appropriate retry logic for transient failures:

```python
async def execute_async(self, request):
    max_retries = 3
    retry_count = 0
    base_delay = 1  # secondes
    
    while retry_count < max_retries:
        try:
            # Appeler l'API externe
            return await self._call_api(request.parameters)
        except TransientError as e:
            retry_count += 1
            if retry_count >= max_retries:
                raise ToolExecutionException(f"Échec de l'opération après {max_retries} tentatives : {str(e)}")
                
            # Recul exponentiel
            delay = base_delay * (2 ** (retry_count - 1))
            logging.warning(f"Erreur transitoire, nouvelle tentative dans {delay}s : {str(e)}")
            await asyncio.sleep(delay)
        except Exception as e:
            # Erreur non transitoire, ne pas réessayer
            raise ToolExecutionException(f"Échec de l'opération : {str(e)}")
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
    
    // Créer une clé de cache basée sur les paramètres
    var cacheKey = $"data_query_{ComputeHash(query)}";
    
    // Essayer d'obtenir du cache en premier
    if (_cache.TryGetValue(cacheKey, out var cachedResult))
    {
        return new ToolResponse { Result = cachedResult };
    }
    
    // Cache manquant - effectuer la requête réelle
    var result = await _database.QueryAsync(query);
    
    // Stocker dans le cache avec expiration
    var cacheOptions = new MemoryCacheEntryOptions()
        .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
        
    _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
    
    return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
}

private string ComputeHash(string input)
{
    // Implémentation pour générer un hash stable pour la clé de cache
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
        
        // Pour les opérations longues, retourner immédiatement un ID de traitement
        String processId = UUID.randomUUID().toString();
        
        // Démarrer le traitement asynchrone
        CompletableFuture.runAsync(() -> {
            try {
                // Effectuer une opération longue
                documentService.processDocument(documentId);
                
                // Mettre à jour le statut (généralement stocké dans une base de données)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // Retourner une réponse immédiate avec l'ID de traitement
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // Outil compagnon pour vérifier le statut
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
            tokens_per_second=5,  # Autoriser 5 requêtes par seconde
            bucket_size=10        # Autoriser des pics jusqu'à 10 requêtes
        )
    
    async def execute_async(self, request):
        # Vérifier si nous pouvons continuer ou devons attendre
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # Si l'attente est trop longue
                raise ToolExecutionException(
                    f"Limite de débit dépassée. Veuillez réessayer dans {delay:.1f} secondes."
                )
            else:
                # Attendre le temps de délai approprié
                await asyncio.sleep(delay)
        
        # Consommer un jeton et continuer avec la requête
        self.rate_limiter.consume()
        
        # Appeler l'API
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
            
            # Calculer le temps jusqu'au prochain jeton disponible
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # Ajouter de nouveaux jetons en fonction du temps écoulé
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
    // Valider que les paramètres existent
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("Paramètre requis manquant : query");
    }
    
    // Valider le type correct
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("Le paramètre query doit être une chaîne de caractères");
    }
    
    var query = queryProp.GetString();
    
    // Valider le contenu de la chaîne
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("Le paramètre query ne peut pas être vide");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("Le paramètre query dépasse la longueur maximale de 500 caractères");
    }
    
    // Vérifier les attaques par injection SQL si applicable
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("Requête invalide : contient potentiellement du SQL dangereux");
    }
    
    // Continuer avec l'exécution
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // Obtenir le contexte utilisateur à partir de la requête
    UserContext user = request.getContext().getUserContext();
    
    // Vérifier si l'utilisateur a les permissions requises
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("L'utilisateur n'a pas la permission d'accéder aux documents");
    }
    
    // Pour des ressources spécifiques, vérifier l'accès à cette ressource
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("Accès refusé au document demandé");
    }
    
    // Continuer avec l'exécution de l'outil
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
        
        // Obtenir les données utilisateur
        user_data = await self.user_service.get_user_data(user_id)
        
        // Filtrer les champs sensibles sauf si explicitement demandé ET autorisé
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        // Vérifier le niveau d'autorisation dans le contexte de la requête
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        // Créer une copie pour éviter de modifier l'original
        redacted = user_data.copy()
        
        // Masquer des champs sensibles spécifiques
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        // Masquer les données sensibles imbriquées
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
    // Préparer
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("Seattle", 3))
        .ReturnsAsync(new WeatherForecast(/* données de test */));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "Seattle", 
            days = 3 
        })
    );
    
    // Agir
    var response = await tool.ExecuteAsync(request);
    
    // Vérifier
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // Préparer
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("InvalidLocation", It.IsAny<int>()))
        .ThrowsAsync(new LocationNotFoundException("Lieu introuvable"));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "InvalidLocation", 
            days = 3 
        })
    );
    
    // Agir & Vérifier
    var exception = await Assert.ThrowsAsync<ToolExecutionException>(
        () => tool.ExecuteAsync(request)
    );
    
    Assert.Contains("Lieu introuvable", exception.Message);
}
```

#### 2. Schema Validation Testing

Test that schemas are valid and properly enforce constraints:

```java
@Test
public void testSchemaValidation() {
    // Créer une instance de l'outil
    SearchTool searchTool = new SearchTool();
    
    // Obtenir le schéma
    Object schema = searchTool.getSchema();
    
    // Convertir le schéma en JSON pour validation
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // Valider que le schéma est un JSONSchema valide
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // Tester des paramètres valides
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // Tester un paramètre requis manquant
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // Tester un type de paramètre invalide
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
    // Préparer
    tool = ApiTool(timeout=0.1)  // Timeout très court
    
    // Simuler une requête qui expirera
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  // Plus long que le timeout
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        // Agir & Vérifier
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        // Vérifier le message d'exception
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    // Préparer
    tool = ApiTool()
    
    // Simuler une réponse avec limitation de débit
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            status=429,
            headers={"Retry-After": "2"},
            body=json.dumps({"error": "Limite de débit dépassée"})
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        // Agir & Vérifier
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        // Vérifier que l'exception contient des informations sur la limitation de débit
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
    // Préparer
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // Agir
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

// Vérification
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
        // Tester le point de terminaison de découverte
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // Créer une requête pour l'outil
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // Envoyer la requête et vérifier la réponse
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // Créer une requête invalide pour l'outil
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // Paramètre "b" manquant
        request.put("parameters", parameters);
        
        // Envoyer la requête et vérifier la réponse d'erreur
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
    # Préparer - Configurer le client MCP et le modèle simulé
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # Réponses simulées du modèle
    mock_model = MockLanguageModel([
        MockResponse(
            "Quel temps fait-il à Seattle ?",
            tool_calls=[{
                "tool_name": "weatherForecast",
                "parameters": {"location": "Seattle", "days": 3}
            }]
        ),
        MockResponse(
            "Voici les prévisions météo pour Seattle :\n- Aujourd'hui : 65°F, Partiellement nuageux\n- Demain : 68°F, Ensoleillé\n- Après-demain : 62°F, Pluie",
            tool_calls=[]
        )
    ])
    
    # Réponse simulée de l'outil météo
    with aioresponses() as mocked:
        mocked.post(
            "http://localhost:5000/mcp/execute",
            payload={
                "result": {
                    "location": "Seattle",
                    "forecast": [
                        {"date": "2023-06-01", "temperature": 65, "conditions": "Partiellement nuageux"},
                        {"date": "2023-06-02", "temperature": 68, "conditions": "Ensoleillé"},
                        {"date": "2023-06-03", "temperature": 62, "conditions": "Pluie"}
                    ]
                }
            }
        )
        
        # Agir
        response = await mcp_client.send_prompt(
            "Quel temps fait-il à Seattle ?",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # Vérifier
        assert "Seattle" in response.generated_text
        assert "65" in response.generated_text
        assert "Ensoleillé" in response.generated_text
        assert "Pluie" in response.generated_text
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
    // Préparer
    var server = new McpServer(
        name: "TestServer",
        version: "1.0",
        maxConcurrentRequests: 100
    );
    
    server.RegisterTool(new FastExecutingTool());
    await server.StartAsync();
    
    var client = new McpClient("http://localhost:5000");
    
    // Agir
    var tasks = new List<Task<McpResponse>>();
    for (int i = 0; i < 1000; i++)
    {
        tasks.Add(client.ExecuteToolAsync("fastTool", new { iteration = i }));
    }
    
    var results = await Task.WhenAll(tasks);
    
    // Vérifier
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
    
    // Configurer JMeter pour les tests de charge
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // Configurer le plan de test JMeter
    HashTree testPlanTree = new HashTree();
    
    // Créer le plan de test, le groupe de threads, les échantillonneurs, etc.
    TestPlan testPlan = new TestPlan("Test de charge du serveur MCP");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // Ajouter un échantillonneur HTTP pour l'exécution des outils
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // Ajouter des rapports
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // Lancer le test
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // Valider les résultats
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // Temps de réponse moyen < 200ms
    assertTrue(summaryReport.getPercentile(90.0) < 500); // 90e percentile < 500ms
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# Configurer la surveillance pour un serveur MCP
def configure_monitoring(server):
    # Configurer les métriques Prometheus
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "Nombre total de requêtes MCP"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "Durée des requêtes en secondes",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "Nombre d'exécutions d'outils",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "Durée d'exécution des outils en secondes",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "Erreurs d'exécution des outils",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # Ajouter un middleware pour mesurer et enregistrer les métriques
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # Exposer le point de terminaison des métriques
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
# Implémentation Python d'une chaîne d'outils
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # Liste des noms d'outils à exécuter en séquence
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # Exécuter chaque outil de la chaîne, en passant le résultat précédent
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # Stocker le résultat et l'utiliser comme entrée pour l'outil suivant
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# Exemple d'utilisation
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
    public string Description => "Traite le contenu de différents types";
    
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
        
        // Déterminer quel outil spécialisé utiliser
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // Transférer à l'outil spécialisé
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
            _ => throw new NotSupportedException("Type de contenu ou opération non pris en charge")
        };
    }
}
```
"csvProcessor",
("code", _) => "codeAnalyzer",
            _ => throw new ToolExecutionException($"Aucun outil disponible pour {contentType}/{operation}")
        };
    }
    
    private object GetOptionsForTool(string toolName, string operation)
    {
        // Retourne les options appropriées pour chaque outil spécialisé
        return toolName switch
        {
            "textSummarizer" => new { length = "medium" },
            "htmlProcessor" => new { cleanUp = true, operation },
            // Options pour d'autres outils...
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
        // Étape 1 : Récupérer les métadonnées du jeu de données (synchronisé)
        ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata", 
            Map.of("datasetId", datasetId));
        
        // Étape 2 : Lancer plusieurs analyses en parallèle
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
        
        // Attendre que toutes les tâches parallèles soient terminées
        CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
            statisticalAnalysis, correlationAnalysis, outlierDetection
        );
        
        allAnalyses.join();  // Attendre la fin
        
        // Étape 3 : Combiner les résultats
        Map<String, Object> combinedResults = new HashMap<>();
        combinedResults.put("metadata", metadataResponse.getResult());
        combinedResults.put("statistics", statisticalAnalysis.join().getResult());
        combinedResults.put("correlations", correlationAnalysis.join().getResult());
        combinedResults.put("outliers", outlierDetection.join().getResult());
        
        // Étape 4 : Générer un rapport de synthèse
        ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator", 
            Map.of("analysisResults", combinedResults));
        
        // Retourner le résultat complet du workflow
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
            # Essayer d'abord l'outil principal
            response = await self.client.execute_tool(primary_tool, parameters)
            return {
                "result": response.result,
                "source": "primary",
                "tool": primary_tool
            }
        except ToolExecutionException as e:
            # Enregistrer l'échec
            logging.warning(f"L'outil principal '{primary_tool}' a échoué : {str(e)}")
            
            # Repli sur l'outil secondaire
            try:
                # Peut nécessiter une transformation des paramètres pour l'outil de repli
                fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)
                
                response = await self.client.execute_tool(fallback_tool, fallback_params)
                return {
                    "result": response.result,
                    "source": "fallback",
                    "tool": fallback_tool,
                    "primaryError": str(e)
                }
            except ToolExecutionException as fallback_error:
                # Les deux outils ont échoué
                logging.error(f"Les outils principal et de repli ont échoué. Erreur de repli : {str(fallback_error)}")
                raise WorkflowExecutionException(
                    f"Échec du workflow : erreur principale : {str(e)} ; erreur de repli : {str(fallback_error)}"
                )
    
    def _adapt_parameters(self, params, from_tool, to_tool):
        """Adapter les paramètres entre différents outils si nécessaire"""
        # Cette implémentation dépendrait des outils spécifiques
        # Pour cet exemple, nous retournons simplement les paramètres d'origine
        return params

# Exemple d'utilisation
async def get_weather(workflow, location):
    return await workflow.execute_with_fallback(
        "premiumWeatherService",  # API météo principale (payante)
        "basicWeatherService",    # API météo de repli (gratuite)
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
            
            // Stocker le résultat de chaque workflow
            results[workflow.Name] = workflowResult;
            
            // Mettre à jour le contexte avec le résultat pour le workflow suivant
            context = context.WithResult(workflow.Name, workflowResult);
        }
        
        return new WorkflowResult(results);
    }
    
    public string Name => "CompositeWorkflow";
    public string Description => "Exécute plusieurs workflows en séquence";
}

// Exemple d'utilisation
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
// Exemple de test unitaire pour un outil calculateur en C#
[Fact]
public async Task CalculatorTool_Add_ReturnsCorrectSum()
{
    // Préparer
    var calculator = new CalculatorTool();
    var parameters = new Dictionary<string, object>
    {
        ["operation"] = "add",
        ["a"] = 5,
        ["b"] = 7
    };
    
    // Agir
    var response = await calculator.ExecuteAsync(parameters);
    var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());
    
    // Vérifier
    Assert.Equal(12, result.Value);
}
```

```python
# Exemple de test unitaire pour un outil calculateur en Python
def test_calculator_tool_add():
    # Préparer
    calculator = CalculatorTool()
    parameters = {
        "operation": "add",
        "a": 5,
        "b": 7
    }
    
    # Agir
    response = calculator.execute(parameters)
    result = json.loads(response.content[0].text)
    
    # Vérifier
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
// Exemple de test d'intégration pour le serveur MCP en C#
[Fact]
public async Task Server_ProcessToolRequest_ReturnsValidResponse()
{
    // Préparer
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
    
    // Agir
    var response = await server.ProcessRequestAsync(request);
    
    // Vérifier
    Assert.NotNull(response);
    Assert.Equal(McpStatusCodes.Success, response.StatusCode);
    // Assertions supplémentaires pour le contenu de la réponse
    
    // Nettoyage
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
// Exemple de test E2E avec un client en TypeScript
describe('Tests E2E du serveur MCP', () => {
  let client: McpClient;
  
  beforeAll(async () => {
    // Démarrer le serveur en environnement de test
    await startTestServer();
    client = new McpClient('http://localhost:5000');
  });
  
  afterAll(async () => {
    await stopTestServer();
  });
  
  test('Le client peut invoquer l\'outil calculateur et obtenir le résultat correct', async () => {
    // Agir
    const response = await client.invokeToolAsync('calculator', {
      operation: 'divide',
      a: 20,
      b: 4
    });
    
    // Vérifier
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
// Exemple en C# avec Moq
var mockModel = new Mock<ILanguageModel>();
mockModel
    .Setup(m => m.GenerateResponseAsync(
        It.IsAny<string>(),
        It.IsAny<McpRequestContext>()))
    .ReturnsAsync(new ModelResponse { 
        Text = "Réponse simulée du modèle",
        FinishReason = FinishReason.Completed
    });

var server = new McpServer(modelClient: mockModel.Object);
```

```python
# Exemple en Python avec unittest.mock
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
    # Configurer le mock
    mock_model.return_value.generate_response.return_value = {
        "text": "Réponse simulée du modèle",
        "finish_reason": "completed"
    }
    
    # Utiliser le mock dans le test
    server = McpServer(model_client=mock_model)
    # Continuer avec le test
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
// Script k6 pour tester la charge du serveur MCP
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  vus: 10,  // 10 utilisateurs virtuels
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
name: Tests du serveur MCP

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
    
    - name: Configurer l'environnement d'exécution
      uses: actions/setup-dotnet@v1
      with:
        dotnet-version: '8.0.x'
    
    - name: Restaurer les dépendances
      run: dotnet restore
    
    - name: Construire
      run: dotnet build --no-restore
    
    - name: Tests unitaires
      run: dotnet test --no-build --filter Category=Unit
    
    - name: Tests d'intégration
      run: dotnet test --no-build --filter Category=Integration
      
    - name: Tests de performance
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
    // Préparer
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");
    
    // Agir
    var response = await client.GetAsync("http://localhost:5000/api/resources");
    var content = await response.Content.ReadAsStringAsync();
    var resources = JsonSerializer.Deserialize

(content);
    
    // Vérification
    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    Assert.NotNull(resources);
    Assert.All(resources.Resources, resource => 
    {
        Assert.NotNull(resource.Id);
        Assert.NotNull(resource.Type);
        // Validation supplémentaire du schéma
    });
}
```

## Les 10 meilleurs conseils pour tester efficacement un serveur MCP

1. **Tester les définitions des outils séparément** : Vérifiez les définitions de schéma indépendamment de la logique des outils
2. **Utiliser des tests paramétrés** : Testez les outils avec une variété d'entrées, y compris les cas limites
3. **Vérifier les réponses d'erreur** : Assurez-vous d'une gestion correcte des erreurs pour toutes les conditions possibles
4. **Tester la logique d'autorisation** : Vérifiez le contrôle d'accès pour différents rôles utilisateurs
5. **Surveiller la couverture des tests** : Visez une couverture élevée du code critique
6. **Tester les réponses en streaming** : Vérifiez la gestion correcte du contenu en streaming
7. **Simuler des problèmes réseau** : Testez le comportement en cas de mauvaises conditions réseau
8. **Tester les limites de ressources** : Vérifiez le comportement lorsque les quotas ou limites de débit sont atteints
9. **Automatiser les tests de régression** : Construisez une suite qui s'exécute à chaque changement de code
10. **Documenter les cas de test** : Maintenez une documentation claire des scénarios de test

## Pièges courants lors des tests

- **Dépendance excessive aux tests de parcours heureux** : Assurez-vous de tester les cas d'erreur de manière approfondie
- **Ignorer les tests de performance** : Identifiez les goulots d'étranglement avant qu'ils n'affectent la production
- **Tester uniquement en isolation** : Combinez les tests unitaires, d'intégration et de bout en bout
- **Couverture API incomplète** : Assurez-vous que tous les points de terminaison et fonctionnalités sont testés
- **Environnements de test incohérents** : Utilisez des conteneurs pour garantir des environnements de test cohérents

## Conclusion

Une stratégie de test complète est essentielle pour développer des serveurs MCP fiables et de haute qualité. En appliquant les meilleures pratiques et conseils décrits dans ce guide, vous pouvez garantir que vos implémentations MCP répondent aux normes les plus élevées en matière de qualité, fiabilité et performance.

## Points clés à retenir

1. **Conception des outils** : Suivez le principe de responsabilité unique, utilisez l'injection de dépendances et concevez pour la composabilité
2. **Conception des schémas** : Créez des schémas clairs, bien documentés avec des contraintes de validation appropriées
3. **Gestion des erreurs** : Implémentez une gestion des erreurs élégante, des réponses structurées et une logique de reprise
4. **Performance** : Utilisez la mise en cache, le traitement asynchrone et le contrôle des ressources
5. **Sécurité** : Appliquez une validation approfondie des entrées, des vérifications d'autorisation et une gestion des données sensibles
6. **Tests** : Créez des tests unitaires, d'intégration et de bout en bout complets
7. **Modèles de workflow** : Appliquez des modèles établis comme les chaînes, les répartiteurs et le traitement parallèle

## Exercice

Concevez un outil MCP et un workflow pour un système de traitement de documents qui :

1. Accepte des documents dans plusieurs formats (PDF, DOCX, TXT)
2. Extrait le texte et les informations clés des documents
3. Classe les documents par type et contenu
4. Génère un résumé de chaque document

Implémentez les schémas des outils, la gestion des erreurs et un modèle de workflow adapté à ce scénario. Réfléchissez à la manière dont vous testeriez cette implémentation.

## Ressources 

1. Rejoignez la communauté MCP sur le [Discord Azure AI Foundry](https://aka.ms/foundrydevs) pour rester informé des derniers développements 
2. Contribuez aux projets open-source [MCP](https://github.com/modelcontextprotocol)
3. Appliquez les principes MCP dans les initiatives d'IA de votre organisation
4. Explorez des implémentations MCP spécialisées pour votre secteur d'activité
5. Envisagez de suivre des cours avancés sur des sujets spécifiques MCP, tels que l'intégration multimodale ou l'intégration d'applications d'entreprise
6. Expérimentez en construisant vos propres outils et workflows MCP en utilisant les principes appris dans le [Laboratoire pratique](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)  

Suivant : Meilleures pratiques [études de cas](../09-CaseStudy/README.md)

**Avertissement** :  
Ce document a été traduit à l'aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d'assurer l'exactitude, veuillez noter que les traductions automatisées peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d'origine doit être considéré comme la source faisant autorité. Pour des informations critiques, il est recommandé de recourir à une traduction professionnelle réalisée par un humain. Nous déclinons toute responsabilité en cas de malentendus ou d'interprétations erronées résultant de l'utilisation de cette traduction.