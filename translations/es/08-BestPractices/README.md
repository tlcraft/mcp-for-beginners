<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "80e5c8949af5af0f401fce6f905990aa",
  "translation_date": "2025-07-16T22:03:39+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "es"
}
-->
# Mejores Prácticas para el Desarrollo de MCP

## Resumen

Esta lección se centra en las mejores prácticas avanzadas para desarrollar, probar y desplegar servidores y funcionalidades MCP en entornos de producción. A medida que los ecosistemas MCP crecen en complejidad e importancia, seguir patrones establecidos garantiza fiabilidad, mantenibilidad e interoperabilidad. Esta lección consolida la experiencia práctica obtenida de implementaciones reales de MCP para guiarte en la creación de servidores robustos y eficientes con recursos, prompts y herramientas efectivas.

## Objetivos de Aprendizaje

Al finalizar esta lección, serás capaz de:
- Aplicar las mejores prácticas de la industria en el diseño de servidores y funcionalidades MCP
- Crear estrategias de prueba integrales para servidores MCP
- Diseñar patrones de flujo de trabajo eficientes y reutilizables para aplicaciones MCP complejas
- Implementar un manejo adecuado de errores, registro y observabilidad en servidores MCP
- Optimizar las implementaciones MCP para rendimiento, seguridad y mantenibilidad

## Principios Fundamentales de MCP

Antes de profundizar en prácticas específicas de implementación, es importante entender los principios fundamentales que guían un desarrollo efectivo de MCP:

1. **Comunicación Estandarizada**: MCP utiliza JSON-RPC 2.0 como base, proporcionando un formato consistente para solicitudes, respuestas y manejo de errores en todas las implementaciones.

2. **Diseño Centrado en el Usuario**: Prioriza siempre el consentimiento, control y transparencia del usuario en tus implementaciones MCP.

3. **Seguridad Primero**: Implementa medidas de seguridad robustas que incluyan autenticación, autorización, validación y limitación de tasa.

4. **Arquitectura Modular**: Diseña tus servidores MCP con un enfoque modular, donde cada herramienta y recurso tenga un propósito claro y específico.

5. **Conexiones con Estado**: Aprovecha la capacidad de MCP para mantener estado a lo largo de múltiples solicitudes para interacciones más coherentes y contextuales.

## Mejores Prácticas Oficiales de MCP

Las siguientes mejores prácticas se derivan de la documentación oficial del Model Context Protocol:

### Mejores Prácticas de Seguridad

1. **Consentimiento y Control del Usuario**: Siempre requiere consentimiento explícito del usuario antes de acceder a datos o realizar operaciones. Proporciona control claro sobre qué datos se comparten y qué acciones están autorizadas.

2. **Privacidad de Datos**: Solo expón datos de usuario con consentimiento explícito y protégelos con controles de acceso adecuados. Prevén la transmisión no autorizada de datos.

3. **Seguridad de las Herramientas**: Requiere consentimiento explícito antes de invocar cualquier herramienta. Asegúrate de que los usuarios comprendan la funcionalidad de cada herramienta y aplica límites de seguridad estrictos.

4. **Control de Permisos de Herramientas**: Configura qué herramientas puede usar un modelo durante una sesión, asegurando que solo estén accesibles las herramientas autorizadas explícitamente.

5. **Autenticación**: Exige autenticación adecuada antes de conceder acceso a herramientas, recursos u operaciones sensibles, usando claves API, tokens OAuth u otros métodos seguros.

6. **Validación de Parámetros**: Aplica validación para todas las invocaciones de herramientas para evitar que entradas malformadas o maliciosas lleguen a las implementaciones.

7. **Limitación de Tasa**: Implementa limitación de tasa para prevenir abusos y asegurar un uso justo de los recursos del servidor.

### Mejores Prácticas de Implementación

1. **Negociación de Capacidades**: Durante la configuración de la conexión, intercambia información sobre características soportadas, versiones del protocolo, herramientas y recursos disponibles.

2. **Diseño de Herramientas**: Crea herramientas enfocadas que hagan bien una sola cosa, en lugar de herramientas monolíticas que manejen múltiples responsabilidades.

3. **Manejo de Errores**: Implementa mensajes y códigos de error estandarizados para ayudar a diagnosticar problemas, manejar fallos de forma elegante y proporcionar retroalimentación útil.

4. **Registro (Logging)**: Configura registros estructurados para auditoría, depuración y monitoreo de las interacciones del protocolo.

5. **Seguimiento de Progreso**: Para operaciones de larga duración, reporta actualizaciones de progreso para habilitar interfaces de usuario responsivas.

6. **Cancelación de Solicitudes**: Permite que los clientes cancelen solicitudes en curso que ya no son necesarias o que están tardando demasiado.

## Referencias Adicionales

Para obtener la información más actualizada sobre las mejores prácticas de MCP, consulta:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)
- [Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## Ejemplos Prácticos de Implementación

### Mejores Prácticas en el Diseño de Herramientas

#### 1. Principio de Responsabilidad Única

Cada herramienta MCP debe tener un propósito claro y enfocado. En lugar de crear herramientas monolíticas que intenten manejar múltiples responsabilidades, desarrolla herramientas especializadas que sobresalgan en tareas específicas.

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

#### 2. Manejo Consistente de Errores

Implementa un manejo robusto de errores con mensajes informativos y mecanismos de recuperación adecuados.

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

#### 3. Validación de Parámetros

Valida siempre los parámetros de forma exhaustiva para evitar entradas malformadas o maliciosas.

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

### Ejemplos de Implementación de Seguridad

#### 1. Autenticación y Autorización

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

#### 2. Limitación de Tasa

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

## Mejores Prácticas de Pruebas

### 1. Pruebas Unitarias de Herramientas MCP

Prueba siempre tus herramientas de forma aislada, simulando las dependencias externas:

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

### 2. Pruebas de Integración

Prueba el flujo completo desde las solicitudes del cliente hasta las respuestas del servidor:

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

## Optimización del Rendimiento

### 1. Estrategias de Caché

Implementa caché adecuada para reducir la latencia y el uso de recursos:

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
// Ejemplo en Java con inyección de dependencias
public class CurrencyConversionTool implements Tool {
    private final ExchangeRateService exchangeService;
    private final CacheService cacheService;
    private final Logger logger;
    
    // Dependencias inyectadas a través del constructor
    public CurrencyConversionTool(
            ExchangeRateService exchangeService,
            CacheService cacheService,
            Logger logger) {
        this.exchangeService = exchangeService;
        this.cacheService = cacheService;
        this.logger = logger;
    }
    
    // Implementación de la herramienta
    // ...
}
```

#### 3. Composable Tools

Design tools that can be composed together to create more complex workflows:

```python
# Ejemplo en Python mostrando herramientas componibles
class DataFetchTool(Tool):
    def get_name(self):
        return "dataFetch"
    
    # Implementación...

class DataAnalysisTool(Tool):
    def get_name(self):
        return "dataAnalysis"
    
    # Esta herramienta puede usar resultados de dataFetch
    async def execute_async(self, request):
        # Implementación...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # Esta herramienta puede usar resultados de dataAnalysis
    async def execute_async(self, request):
        # Implementación...
        pass

# Estas herramientas pueden usarse de forma independiente o como parte de un flujo de trabajo
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
                description = "Texto de la consulta de búsqueda. Usa palabras clave precisas para mejores resultados." 
            },
            filters = new {
                type = "object",
                description = "Filtros opcionales para acotar los resultados de búsqueda",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "Rango de fechas en formato YYYY-MM-DD:YYYY-MM-DD" 
                    },
                    category = new { 
                        type = "string", 
                        description = "Nombre de la categoría para filtrar" 
                    }
                }
            },
            limit = new { 
                type = "integer", 
                description = "Número máximo de resultados a devolver (1-50)",
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
    
    // Propiedad email con validación de formato
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "Dirección de correo electrónico del usuario");
    
    // Propiedad age con restricciones numéricas
    Map<String, Object> age = new HashMap<>();
    age.put("type", "integer");
    age.put("minimum", 13);
    age.put("maximum", 120);
    age.put("description", "Edad del usuario en años");
    
    // Propiedad enumerada
    Map<String, Object> subscription = new HashMap<>();
    subscription.put("type", "string");
    subscription.put("enum", Arrays.asList("free", "basic", "premium"));
    subscription.put("default", "free");
    subscription.put("description", "Nivel de suscripción");
    
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
        # Procesar solicitud
        results = await self._search_database(request.parameters["query"])
        
        # Siempre devolver una estructura consistente
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
    """Asegura que cada ítem tenga una estructura consistente"""
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
            throw new ToolExecutionException($"Archivo no encontrado: {fileId}");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ToolExecutionException("No tienes permiso para acceder a este archivo");
        }
        catch (Exception ex) when (ex is IOException || ex is TimeoutException)
        {
            _logger.LogError(ex, "Error al acceder al archivo {FileId}", fileId);
            throw new ToolExecutionException("Error al acceder al archivo: El servicio está temporalmente no disponible");
        }
    }
    catch (JsonException)
    {
        throw new ToolExecutionException("Formato de ID de archivo inválido");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error inesperado en FileAccessTool");
        throw new ToolExecutionException("Ocurrió un error inesperado");
    }
}
```

#### 2. Structured Error Responses

Return structured error information when possible:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    try {
        // Implementación
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
        
        // Re-lanzar otras excepciones como ToolExecutionException
        throw new ToolExecutionException("Fallo en la ejecución de la herramienta: " + ex.getMessage(), ex);
    }
}
```

#### 3. Retry Logic

Implement appropriate retry logic for transient failures:

```python
async def execute_async(self, request):
    max_retries = 3
    retry_count = 0
    base_delay = 1  # segundos
    
    while retry_count < max_retries:
        try:
            # Llamar a API externa
            return await self._call_api(request.parameters)
        except TransientError as e:
            retry_count += 1
            if retry_count >= max_retries:
                raise ToolExecutionException(f"Operación fallida tras {max_retries} intentos: {str(e)}")
                
            # Reintentos con retroceso exponencial
            delay = base_delay * (2 ** (retry_count - 1))
            logging.warning(f"Error transitorio, reintentando en {delay}s: {str(e)}")
            await asyncio.sleep(delay)
        except Exception as e:
            # Error no transitorio, no reintentar
            raise ToolExecutionException(f"Operación fallida: {str(e)}")
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
        
        // Crear clave de caché basada en los parámetros
        var cacheKey = $"data_query_{ComputeHash(query)}";
        
        // Intentar obtener primero de la caché
        if (_cache.TryGetValue(cacheKey, out var cachedResult))
        {
            return new ToolResponse { Result = cachedResult };
        }
        
        // Caché no encontrada - realizar la consulta real
        var result = await _database.QueryAsync(query);
        
        // Guardar en caché con expiración
        var cacheOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
            
        _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
        
        return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
    }
    
    private string ComputeHash(string input)
    {
        // Implementación para generar un hash estable para la clave de caché
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
        
        // Para operaciones de larga duración, devolver inmediatamente un ID de proceso
        String processId = UUID.randomUUID().toString();
        
        // Iniciar procesamiento asíncrono
        CompletableFuture.runAsync(() -> {
            try {
                // Realizar operación de larga duración
                documentService.processDocument(documentId);
                
                // Actualizar estado (normalmente se almacenaría en una base de datos)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // Devolver respuesta inmediata con el ID del proceso
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // Herramienta complementaria para verificar el estado
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
            tokens_per_second=5,  # Permitir 5 solicitudes por segundo
            bucket_size=10        # Permitir ráfagas de hasta 10 solicitudes
        )
    
    async def execute_async(self, request):
        # Verificar si podemos continuar o debemos esperar
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # Si la espera es demasiado larga
                raise ToolExecutionException(
                    f"Límite de tasa excedido. Por favor, inténtelo de nuevo en {delay:.1f} segundos."
                )
            else:
                # Esperar el tiempo de retraso adecuado
                await asyncio.sleep(delay)
        
        # Consumir un token y continuar con la solicitud
        self.rate_limiter.consume()
        
        # Llamar a la API
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
            
            # Calcular tiempo hasta que haya un token disponible
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # Añadir nuevos tokens según el tiempo transcurrido
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
    // Validar que existan los parámetros
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("Falta el parámetro requerido: query");
    }
    
    // Validar tipo correcto
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("El parámetro query debe ser una cadena");
    }
    
    var query = queryProp.GetString();
    
    // Validar contenido de la cadena
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("El parámetro query no puede estar vacío");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("El parámetro query excede la longitud máxima de 500 caracteres");
    }
    
    // Comprobar ataques de inyección SQL si aplica
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("Consulta inválida: contiene SQL potencialmente inseguro");
    }
    
    // Continuar con la ejecución
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // Obtener contexto de usuario desde la solicitud
    UserContext user = request.getContext().getUserContext();
    
    // Verificar si el usuario tiene los permisos requeridos
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("El usuario no tiene permiso para acceder a los documentos");
    }
    
    // Para recursos específicos, verificar acceso a ese recurso
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("Acceso denegado al documento solicitado");
    }
    
    // Continuar con la ejecución de la herramienta
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
        
        # Obtener datos del usuario
        user_data = await self.user_service.get_user_data(user_id)
        
        # Filtrar campos sensibles a menos que se solicite explícitamente Y se esté autorizado
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # Verificar nivel de autorización en el contexto de la solicitud
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # Crear una copia para evitar modificar el original
        redacted = user_data.copy()
        
        # Ocultar campos sensibles específicos
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # Ocultar datos sensibles anidados
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
    // Preparar
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("Seattle", 3))
        .ReturnsAsync(new WeatherForecast(/* datos de prueba */));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "Seattle", 
            days = 3 
        })
    );
    
    // Ejecutar
    var response = await tool.ExecuteAsync(request);
    
    // Verificar
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // Preparar
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("InvalidLocation", It.IsAny<int>()))
        .ThrowsAsync(new LocationNotFoundException("Ubicación no encontrada"));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "InvalidLocation", 
            days = 3 
        })
    );
    
    // Ejecutar y verificar
    var exception = await Assert.ThrowsAsync<ToolExecutionException>(
        () => tool.ExecuteAsync(request)
    );
    
    Assert.Contains("Ubicación no encontrada", exception.Message);
}
```

#### 2. Schema Validation Testing

Test that schemas are valid and properly enforce constraints:

```java
@Test
public void testSchemaValidation() {
    // Crear instancia de la herramienta
    SearchTool searchTool = new SearchTool();
    
    // Obtener esquema
    Object schema = searchTool.getSchema();
    
    // Convertir esquema a JSON para validación
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // Validar que el esquema sea un JSONSchema válido
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // Probar parámetros válidos
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // Probar parámetro requerido faltante
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // Probar tipo de parámetro inválido
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
    # Preparar
    tool = ApiTool(timeout=0.1)  # Tiempo de espera muy corto
    
    # Simular una solicitud que excederá el tiempo de espera
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # Más largo que el timeout
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # Ejecutar y verificar
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Verificar mensaje de excepción
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # Preparar
    tool = ApiTool()
    
    # Simular una respuesta con límite de tasa
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
        
        # Ejecutar y verificar
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Verificar que la excepción contenga información sobre el límite de tasa
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
    // Preparar
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // Ejecutar
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

// Afirmar
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
        // Probar el endpoint de descubrimiento
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // Crear solicitud para la herramienta
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // Enviar solicitud y verificar respuesta
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // Crear solicitud inválida para la herramienta
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // Falta el parámetro "b"
        request.put("parameters", parameters);
        
        // Enviar solicitud y verificar respuesta de error
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
    # Preparar - Configurar cliente MCP y modelo simulado
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # Respuestas simuladas del modelo
    mock_model = MockLanguageModel([
        MockResponse(
            "¿Cuál es el clima en Seattle?",
            tool_calls=[{
                "tool_name": "weatherForecast",
                "parameters": {"location": "Seattle", "days": 3}
            }]
        ),
        MockResponse(
            "Aquí está el pronóstico del tiempo para Seattle:\n- Hoy: 65°F, Parcialmente nublado\n- Mañana: 68°F, Soleado\n- Pasado mañana: 62°F, Lluvia",
            tool_calls=[]
        )
    ])
    
    # Respuesta simulada de la herramienta del clima
    with aioresponses() as mocked:
        mocked.post(
            "http://localhost:5000/mcp/execute",
            payload={
                "result": {
                    "location": "Seattle",
                    "forecast": [
                        {"date": "2023-06-01", "temperature": 65, "conditions": "Parcialmente nublado"},
                        {"date": "2023-06-02", "temperature": 68, "conditions": "Soleado"},
                        {"date": "2023-06-03", "temperature": 62, "conditions": "Lluvia"}
                    ]
                }
            }
        )
        
        # Ejecutar
        response = await mcp_client.send_prompt(
            "¿Cuál es el clima en Seattle?",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # Verificar
        assert "Seattle" in response.generated_text
        assert "65" in response.generated_text
        assert "Soleado" in response.generated_text
        assert "Lluvia" in response.generated_text
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
    // Preparar
    var server = new McpServer(
        name: "TestServer",
        version: "1.0",
        maxConcurrentRequests: 100
    );
    
    server.RegisterTool(new FastExecutingTool());
    await server.StartAsync();
    
    var client = new McpClient("http://localhost:5000");
    
    // Ejecutar
    var tasks = new List<Task<McpResponse>>();
    for (int i = 0; i < 1000; i++)
    {
        tasks.Add(client.ExecuteToolAsync("fastTool", new { iteration = i }));
    }
    
    var results = await Task.WhenAll(tasks);
    
    // Verificar
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
    
    // Configurar JMeter para pruebas de estrés
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // Configurar el plan de prueba de JMeter
    HashTree testPlanTree = new HashTree();
    
    // Crear plan de prueba, grupo de hilos, muestreadores, etc.
    TestPlan testPlan = new TestPlan("Prueba de Estrés del Servidor MCP");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // Añadir muestreador HTTP para ejecución de herramienta
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // Añadir listeners
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // Ejecutar prueba
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // Validar resultados
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // Tiempo medio de respuesta < 200ms
    assertTrue(summaryReport.getPercentile(90.0) < 500); // Percentil 90 < 500ms
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# Configurar monitoreo para un servidor MCP
def configure_monitoring(server):
    # Configurar métricas de Prometheus
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "Total de solicitudes MCP"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "Duración de la solicitud en segundos",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "Conteo de ejecuciones de herramientas",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "Duración de la ejecución de herramientas en segundos",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "Errores en la ejecución de herramientas",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # Añadir middleware para medir tiempos y registrar métricas
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # Exponer endpoint de métricas
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
# Implementación en Python de cadena de herramientas
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # Lista de nombres de herramientas a ejecutar en secuencia
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # Ejecutar cada herramienta en la cadena, pasando el resultado previo
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # Guardar resultado y usarlo como entrada para la siguiente herramienta
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# Ejemplo de uso
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
    public string Description => "Procesa contenido de varios tipos";
    
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
        
        // Determinar qué herramienta especializada usar
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // Reenviar a la herramienta especializada
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
# Procesador CSV

[!IMPORTANT]
Este módulo es fundamental para manejar archivos CSV en nuestra aplicación. Asegúrate de seguir las reglas de formato para evitar errores.

## Funciones principales

- `loadCSV(filePath)`: Carga un archivo CSV desde la ruta especificada.
- `parseCSV(data)`: Convierte una cadena CSV en un array de objetos.
- `saveCSV(data, filePath)`: Guarda un array de objetos en un archivo CSV.

## Ejemplo de uso

```javascript
const data = loadCSV('@@INLINE_CODE_1@@');
const parsedData = parseCSV(data);
// Procesar los datos
saveCSV(parsedData, '@@INLINE_CODE_2@@');
```

[!TIP]
Para archivos grandes, considera procesar los datos en bloques para mejorar el rendimiento.

## Manejo de errores

[!WARNING]
Si el archivo CSV está mal formateado, `parseCSV` lanzará una excepción. Usa bloques try-catch para manejar estos casos.

## Notas adicionales

- Los encabezados del CSV deben coincidir con las propiedades de los objetos.
- Las comas dentro de los campos deben estar entre comillas para evitar problemas de parseo.
("code", _) => "codeAnalyzer",
_ => throw new ToolExecutionException($"No hay herramienta disponible para {contentType}/{operation}")
};
}

private object GetOptionsForTool(string toolName, string operation)
{
// Devuelve las opciones apropiadas para cada herramienta especializada
return toolName switch
{
    "textSummarizer" => new { length = "medium" },
    "htmlProcessor" => new { cleanUp = true, operation },
    // Opciones para otras herramientas...
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
        // Paso 1: Obtener metadatos del conjunto de datos (sincrónico)
        ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata", 
            Map.of("datasetId", datasetId));
        
        // Paso 2: Lanzar múltiples análisis en paralelo
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
        
        // Esperar a que todas las tareas paralelas terminen
        CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
            statisticalAnalysis, correlationAnalysis, outlierDetection
        );
        
        allAnalyses.join();  // Esperar a la finalización
        
        // Paso 3: Combinar resultados
        Map<String, Object> combinedResults = new HashMap<>();
        combinedResults.put("metadata", metadataResponse.getResult());
        combinedResults.put("statistics", statisticalAnalysis.join().getResult());
        combinedResults.put("correlations", correlationAnalysis.join().getResult());
        combinedResults.put("outliers", outlierDetection.join().getResult());
        
        // Paso 4: Generar informe resumen
        ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator", 
            Map.of("analysisResults", combinedResults));
        
        // Devolver resultado completo del flujo de trabajo
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
            # Intentar primero con la herramienta principal
            response = await self.client.execute_tool(primary_tool, parameters)
            return {
                "result": response.result,
                "source": "primary",
                "tool": primary_tool
            }
        except ToolExecutionException as e:
            # Registrar la falla
            logging.warning(f"La herramienta principal '{primary_tool}' falló: {str(e)}")
            
            # Recurre a la herramienta secundaria
            try:
                # Puede ser necesario transformar los parámetros para la herramienta secundaria
                fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)
                
                response = await self.client.execute_tool(fallback_tool, fallback_params)
                return {
                    "result": response.result,
                    "source": "fallback",
                    "tool": fallback_tool,
                    "primaryError": str(e)
                }
            except ToolExecutionException as fallback_error:
                # Ambas herramientas fallaron
                logging.error(f"Tanto la herramienta principal como la secundaria fallaron. Error de fallback: {str(fallback_error)}")
                raise WorkflowExecutionException(
                    f"El flujo de trabajo falló: error principal: {str(e)}; error de fallback: {str(fallback_error)}"
                )
    
    def _adapt_parameters(self, params, from_tool, to_tool):
        """Adaptar parámetros entre diferentes herramientas si es necesario"""
        # Esta implementación dependerá de las herramientas específicas
        # Para este ejemplo, simplemente devolvemos los parámetros originales
        return params

# Ejemplo de uso
async def get_weather(workflow, location):
    return await workflow.execute_with_fallback(
        "premiumWeatherService",  # API meteorológica principal (de pago)
        "basicWeatherService",    # API meteorológica secundaria (gratuita)
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
            
            // Guardar el resultado de cada flujo de trabajo
            results[workflow.Name] = workflowResult;
            
            // Actualizar el contexto con el resultado para el siguiente flujo
            context = context.WithResult(workflow.Name, workflowResult);
        }
        
        return new WorkflowResult(results);
    }
    
    public string Name => "CompositeWorkflow";
    public string Description => "Ejecuta múltiples flujos de trabajo en secuencia";
}

// Ejemplo de uso
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
// Ejemplo de prueba unitaria para una herramienta calculadora en C#
[Fact]
public async Task CalculatorTool_Add_ReturnsCorrectSum()
{
    // Preparar
    var calculator = new CalculatorTool();
    var parameters = new Dictionary<string, object>
    {
        ["operation"] = "add",
        ["a"] = 5,
        ["b"] = 7
    };
    
    // Ejecutar
    var response = await calculator.ExecuteAsync(parameters);
    var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());
    
    // Comprobar
    Assert.Equal(12, result.Value);
}
```

```python
# Ejemplo de prueba unitaria para una herramienta calculadora en Python
def test_calculator_tool_add():
    # Preparar
    calculator = CalculatorTool()
    parameters = {
        "operation": "add",
        "a": 5,
        "b": 7
    }
    
    # Ejecutar
    response = calculator.execute(parameters)
    result = json.loads(response.content[0].text)
    
    # Comprobar
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
// Ejemplo de prueba de integración para el servidor MCP en C#
[Fact]
public async Task Server_ProcessToolRequest_ReturnsValidResponse()
{
    // Preparar
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
    
    // Ejecutar
    var response = await server.ProcessRequestAsync(request);
    
    // Comprobar
    Assert.NotNull(response);
    Assert.Equal(McpStatusCodes.Success, response.StatusCode);
    // Comprobaciones adicionales para el contenido de la respuesta
    
    // Limpieza
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
// Ejemplo de prueba E2E con un cliente en TypeScript
describe('MCP Server E2E Tests', () => {
  let client: McpClient;
  
  beforeAll(async () => {
    // Iniciar servidor en entorno de pruebas
    await startTestServer();
    client = new McpClient('http://localhost:5000');
  });
  
  afterAll(async () => {
    await stopTestServer();
  });
  
  test('El cliente puede invocar la herramienta calculadora y obtener el resultado correcto', async () => {
    // Ejecutar
    const response = await client.invokeToolAsync('calculator', {
      operation: 'divide',
      a: 20,
      b: 4
    });
    
    // Comprobar
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
// Ejemplo en C# con Moq
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
# Ejemplo en Python con unittest.mock
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
    # Configurar mock
    mock_model.return_value.generate_response.return_value = {
        "text": "Mocked model response",
        "finish_reason": "completed"
    }
    
    # Usar mock en la prueba
    server = McpServer(model_client=mock_model)
    # Continuar con la prueba
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
// Script k6 para pruebas de carga del servidor MCP
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  vus: 10,  // 10 usuarios virtuales
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
    'el estado es 200': (r) => r.status === 200,
    'tiempo de respuesta < 500ms': (r) => r.timings.duration < 500,
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
    
    - name: Configurar Runtime
      uses: actions/setup-dotnet@v1
      with:
        dotnet-version: '8.0.x'
    
    - name: Restaurar dependencias
      run: dotnet restore
    
    - name: Compilar
      run: dotnet build --no-restore
    
    - name: Pruebas unitarias
      run: dotnet test --no-build --filter Category=Unit
    
    - name: Pruebas de integración
      run: dotnet test --no-build --filter Category=Integration
      
    - name: Pruebas de rendimiento
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
    // Preparar
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");
    
    // Ejecutar
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
    // Validación adicional del esquema
});
}
```

## Las 10 mejores recomendaciones para pruebas efectivas de servidores MCP

1. **Prueba las definiciones de las herramientas por separado**: Verifica las definiciones del esquema independientemente de la lógica de la herramienta  
2. **Usa pruebas parametrizadas**: Prueba las herramientas con una variedad de entradas, incluyendo casos límite  
3. **Revisa las respuestas de error**: Verifica el manejo adecuado de errores para todas las condiciones posibles  
4. **Prueba la lógica de autorización**: Asegura un control de acceso correcto para diferentes roles de usuario  
5. **Monitorea la cobertura de pruebas**: Busca una alta cobertura del código en rutas críticas  
6. **Prueba respuestas en streaming**: Verifica el manejo correcto de contenido en streaming  
7. **Simula problemas de red**: Prueba el comportamiento bajo condiciones de red deficientes  
8. **Prueba los límites de recursos**: Verifica el comportamiento al alcanzar cuotas o límites de tasa  
9. **Automatiza pruebas de regresión**: Construye un conjunto de pruebas que se ejecuten con cada cambio de código  
10. **Documenta los casos de prueba**: Mantén una documentación clara de los escenarios de prueba  

## Errores comunes en las pruebas

- **Dependencia excesiva en pruebas del camino feliz**: Asegúrate de probar a fondo los casos de error  
- **Ignorar las pruebas de rendimiento**: Identifica cuellos de botella antes de que afecten producción  
- **Probar solo en aislamiento**: Combina pruebas unitarias, de integración y end-to-end  
- **Cobertura incompleta de la API**: Asegura que todos los endpoints y funcionalidades estén probados  
- **Entornos de prueba inconsistentes**: Usa contenedores para garantizar entornos de prueba uniformes  

## Conclusión

Una estrategia de pruebas integral es esencial para desarrollar servidores MCP confiables y de alta calidad. Al implementar las mejores prácticas y recomendaciones descritas en esta guía, puedes asegurar que tus implementaciones MCP cumplan con los más altos estándares de calidad, fiabilidad y rendimiento.

## Puntos clave

1. **Diseño de herramientas**: Sigue el principio de responsabilidad única, usa inyección de dependencias y diseña para la composibilidad  
2. **Diseño de esquemas**: Crea esquemas claros, bien documentados y con restricciones de validación adecuadas  
3. **Manejo de errores**: Implementa un manejo de errores elegante, respuestas estructuradas y lógica de reintentos  
4. **Rendimiento**: Usa caché, procesamiento asíncrono y limitación de recursos  
5. **Seguridad**: Aplica validación exhaustiva de entradas, verificaciones de autorización y manejo seguro de datos sensibles  
6. **Pruebas**: Crea pruebas unitarias, de integración y end-to-end completas  
7. **Patrones de flujo de trabajo**: Aplica patrones establecidos como cadenas, despachadores y procesamiento paralelo  

## Ejercicio

Diseña una herramienta MCP y un flujo de trabajo para un sistema de procesamiento de documentos que:

1. Acepte documentos en múltiples formatos (PDF, DOCX, TXT)  
2. Extraiga texto e información clave de los documentos  
3. Clasifique los documentos por tipo y contenido  
4. Genere un resumen de cada documento  

Implementa los esquemas de la herramienta, el manejo de errores y un patrón de flujo de trabajo que mejor se adapte a este escenario. Considera cómo probarías esta implementación.

## Recursos

1. Únete a la comunidad MCP en la [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs) para estar al día con los últimos desarrollos  
2. Contribuye a proyectos open-source de [MCP](https://github.com/modelcontextprotocol)  
3. Aplica los principios MCP en las iniciativas de IA de tu propia organización  
4. Explora implementaciones especializadas de MCP para tu industria  
5. Considera tomar cursos avanzados sobre temas específicos de MCP, como integración multimodal o integración de aplicaciones empresariales  
6. Experimenta construyendo tus propias herramientas y flujos de trabajo MCP usando los principios aprendidos en el [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)  

Siguiente: Mejores prácticas [estudios de caso](../09-CaseStudy/README.md)

**Aviso Legal**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda la traducción profesional realizada por humanos. No nos hacemos responsables de malentendidos o interpretaciones erróneas derivadas del uso de esta traducción.