<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1827d0f7a6430dfb7adcdd5f1ee05bda",
  "translation_date": "2025-07-29T00:46:20+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "es"
}
-->
# Mejores Prácticas para el Desarrollo de MCP

[![Mejores Prácticas para el Desarrollo de MCP](../../../translated_images/09.d0f6d86c9d72134ccf5a8d8c8650a0557e519936661fc894cad72d73522227cb.es.png)](https://youtu.be/W56H9W7x-ao)

_(Haz clic en la imagen de arriba para ver el video de esta lección)_

## Descripción General

Esta lección se centra en prácticas avanzadas para desarrollar, probar y desplegar servidores y características de MCP en entornos de producción. A medida que los ecosistemas de MCP crecen en complejidad e importancia, seguir patrones establecidos garantiza confiabilidad, mantenibilidad e interoperabilidad. Esta lección consolida la experiencia práctica obtenida de implementaciones reales de MCP para guiarte en la creación de servidores robustos y eficientes con recursos, prompts y herramientas efectivas.

## Objetivos de Aprendizaje

Al finalizar esta lección, serás capaz de:

- Aplicar las mejores prácticas de la industria en el diseño de servidores y características de MCP
- Crear estrategias de prueba completas para servidores MCP
- Diseñar patrones de flujo de trabajo eficientes y reutilizables para aplicaciones MCP complejas
- Implementar un manejo adecuado de errores, registro y observabilidad en servidores MCP
- Optimizar implementaciones de MCP para rendimiento, seguridad y mantenibilidad

## Principios Fundamentales de MCP

Antes de profundizar en prácticas específicas de implementación, es importante comprender los principios fundamentales que guían el desarrollo efectivo de MCP:

1. **Comunicación Estandarizada**: MCP utiliza JSON-RPC 2.0 como base, proporcionando un formato consistente para solicitudes, respuestas y manejo de errores en todas las implementaciones.

2. **Diseño Centrado en el Usuario**: Siempre prioriza el consentimiento, control y transparencia del usuario en tus implementaciones de MCP.

3. **Seguridad Primero**: Implementa medidas de seguridad robustas, incluyendo autenticación, autorización, validación y limitación de tasas.

4. **Arquitectura Modular**: Diseña tus servidores MCP con un enfoque modular, donde cada herramienta y recurso tenga un propósito claro y enfocado.

5. **Conexiones con Estado**: Aprovecha la capacidad de MCP para mantener el estado a través de múltiples solicitudes para interacciones más coherentes y con contexto.

## Mejores Prácticas Oficiales de MCP

Las siguientes mejores prácticas se derivan de la documentación oficial del Protocolo de Contexto de Modelo (MCP):

### Mejores Prácticas de Seguridad

1. **Consentimiento y Control del Usuario**: Siempre requiere el consentimiento explícito del usuario antes de acceder a datos o realizar operaciones. Proporciona un control claro sobre qué datos se comparten y qué acciones están autorizadas.

2. **Privacidad de los Datos**: Solo expón datos del usuario con consentimiento explícito y protégelos con controles de acceso adecuados. Evita transmisiones de datos no autorizadas.

3. **Seguridad de las Herramientas**: Requiere el consentimiento explícito del usuario antes de invocar cualquier herramienta. Asegúrate de que los usuarios comprendan la funcionalidad de cada herramienta y aplica límites de seguridad robustos.

4. **Control de Permisos de Herramientas**: Configura qué herramientas puede usar un modelo durante una sesión, asegurando que solo las herramientas explícitamente autorizadas estén accesibles.

5. **Autenticación**: Requiere autenticación adecuada antes de otorgar acceso a herramientas, recursos u operaciones sensibles utilizando claves API, tokens OAuth u otros métodos seguros.

6. **Validación de Parámetros**: Aplica validación para todas las invocaciones de herramientas para evitar que entradas malformadas o maliciosas lleguen a las implementaciones de herramientas.

7. **Limitación de Tasa**: Implementa limitación de tasa para prevenir abusos y garantizar un uso equitativo de los recursos del servidor.

### Mejores Prácticas de Implementación

1. **Negociación de Capacidades**: Durante la configuración de la conexión, intercambia información sobre características compatibles, versiones del protocolo, herramientas disponibles y recursos.

2. **Diseño de Herramientas**: Crea herramientas enfocadas que hagan una sola cosa bien, en lugar de herramientas monolíticas que manejen múltiples preocupaciones.

3. **Manejo de Errores**: Implementa mensajes de error y códigos estandarizados para ayudar a diagnosticar problemas, manejar fallos de manera elegante y proporcionar retroalimentación accionable.

4. **Registro**: Configura registros estructurados para auditoría, depuración y monitoreo de interacciones del protocolo.

5. **Seguimiento de Progreso**: Para operaciones de larga duración, informa actualizaciones de progreso para habilitar interfaces de usuario receptivas.

6. **Cancelación de Solicitudes**: Permite a los clientes cancelar solicitudes en curso que ya no sean necesarias o que estén tardando demasiado.

## Referencias Adicionales

Para obtener la información más actualizada sobre las mejores prácticas de MCP, consulta:

- [Documentación de MCP](https://modelcontextprotocol.io/)
- [Especificación de MCP](https://spec.modelcontextprotocol.io/)
- [Repositorio en GitHub](https://github.com/modelcontextprotocol)
- [Mejores Prácticas de Seguridad](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## Ejemplos Prácticos de Implementación

### Mejores Prácticas de Diseño de Herramientas

#### 1. Principio de Responsabilidad Única

Cada herramienta de MCP debe tener un propósito claro y enfocado. En lugar de crear herramientas monolíticas que intenten manejar múltiples preocupaciones, desarrolla herramientas especializadas que sobresalgan en tareas específicas.

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

Valida siempre los parámetros de manera exhaustiva para evitar entradas malformadas o maliciosas.

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

Prueba siempre tus herramientas de forma aislada, simulando dependencias externas:

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

## Optimización de Rendimiento

### 1. Estrategias de Caché

Implementa estrategias de caché adecuadas para reducir la latencia y el uso de recursos:

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
    
    # Esta herramienta puede usar resultados de la herramienta dataFetch
    async def execute_async(self, request):
        # Implementación...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # Esta herramienta puede usar resultados de la herramienta dataAnalysis
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
                description = "Texto de consulta de búsqueda. Usa palabras clave precisas para mejores resultados." 
            },
            filters = new {
                type = "object",
                description = "Filtros opcionales para limitar los resultados de búsqueda",
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
    
    // Propiedad de correo electrónico con validación de formato
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "Dirección de correo electrónico del usuario");
    
    // Propiedad de edad con restricciones numéricas
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
        
        # Siempre devuelve una estructura consistente
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
    """Asegura que cada elemento tenga una estructura consistente"""
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
            throw new ToolExecutionException("Error al acceder al archivo: El servicio no está disponible temporalmente");
        }
    }
    catch (JsonException)
    {
        throw new ToolExecutionException("Formato de ID de archivo no válido");
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
        throw new ToolExecutionException("La ejecución de la herramienta falló: " + ex.getMessage(), ex);
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
            # Llamar a la API externa
            return await self._call_api(request.parameters)
        except TransientError as e:
            retry_count += 1
            if retry_count >= max_retries:
                raise ToolExecutionException(f"La operación falló después de {max_retries} intentos: {str(e)}")
                
            # Retroceso exponencial
            delay = base_delay * (2 ** (retry_count - 1))
            logging.warning(f"Error transitorio, reintentando en {delay}s: {str(e)}")
            await asyncio.sleep(delay)
        except Exception as e:
            # Error no transitorio, no reintentar
            raise ToolExecutionException(f"La operación falló: {str(e)}")
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
    
    // Intentar obtener primero desde la caché
    if (_cache.TryGetValue(cacheKey, out var cachedResult))
    {
        return new ToolResponse { Result = cachedResult };
    }
    
    // Fallo de caché - realizar consulta real
    var result = await _database.QueryAsync(query);
    
    // Almacenar en caché con expiración
    var cacheOptions = new MemoryCacheEntryOptions()
        .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
        
    _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
    
    return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
}

private string ComputeHash(string input)
{
    // Implementación para generar un hash estable para la clave de caché
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
        
        // Para operaciones de larga duración, devolver un ID de procesamiento inmediatamente
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
        
        // Devolver respuesta inmediata con el ID de procesamiento
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
        # Verificar si podemos proceder o necesitamos esperar
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # Si la espera es demasiado larga
                raise ToolExecutionException(
                    f"Límite de tasa excedido. Por favor, inténtelo de nuevo en {delay:.1f} segundos."
                )
            else:
                // Esperar el tiempo de retraso adecuado
                await asyncio.sleep(delay)
        
        // Consumir un token y proceder con la solicitud
        self.rate_limiter.consume()
        
        // Llamar a la API
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
            
            // Calcular el tiempo hasta que esté disponible el próximo token
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        // Agregar nuevos tokens según el tiempo transcurrido
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
    // Validar que los parámetros existan
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("Falta el parámetro requerido: query");
    }
    
    // Validar el tipo correcto
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("El parámetro query debe ser una cadena");
    }
    
    var query = queryProp.GetString();
    
    // Validar el contenido de la cadena
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("El parámetro query no puede estar vacío");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("El parámetro query excede la longitud máxima de 500 caracteres");
    }
    
    // Verificar ataques de inyección SQL si corresponde
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("Consulta inválida: contiene SQL potencialmente inseguro");
    }
    
    // Proceder con la ejecución
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // Obtener el contexto del usuario desde la solicitud
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
    
    // Proceder con la ejecución de la herramienta
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
        
        // Obtener datos del usuario
        user_data = await self.user_service.get_user_data(user_id)
        
        // Filtrar campos sensibles a menos que se soliciten explícitamente Y estén autorizados
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        // Verificar nivel de autorización en el contexto de la solicitud
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        // Crear una copia para evitar modificar el original
        redacted = user_data.copy()
        
        // Redactar campos sensibles específicos
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        // Redactar datos sensibles anidados
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
    
    // Actuar
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
    
    // Actuar y verificar
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
    // Crear instancia de herramienta
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
    // Preparar
    tool = ApiTool(timeout=0.1)  // Tiempo de espera muy corto
    
    // Simular una solicitud que se agotará
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  // Más largo que el tiempo de espera
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        // Actuar y verificar
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        // Verificar mensaje de excepción
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    // Preparar
    tool = ApiTool()
    
    // Simular una respuesta con límite de tasa
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
        
        // Actuar y verificar
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        // Verificar que la excepción contiene información sobre el límite de tasa
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
    
    // Actuar
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

// Verificar
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
            "Aquí está el pronóstico del clima para Seattle:\n- Hoy: 65°F, Parcialmente Nublado\n- Mañana: 68°F, Soleado\n- Pasado mañana: 62°F, Lluvia",
            tool_calls=[]
        )
    ])
    
    # Respuesta simulada de la herramienta de clima
    with aioresponses() as mocked:
        mocked.post(
            "http://localhost:5000/mcp/execute",
            payload={
                "result": {
                    "location": "Seattle",
                    "forecast": [
                        {"date": "2023-06-01", "temperature": 65, "conditions": "Parcialmente Nublado"},
                        {"date": "2023-06-02", "temperature": 68, "conditions": "Soleado"},
                        {"date": "2023-06-03", "temperature": 62, "conditions": "Lluvia"}
                    ]
                }
            }
        )
        
        # Actuar
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
    
    // Actuar
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
    
    // Configurar plan de prueba de JMeter
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
    
    // Agregar muestreador HTTP para la ejecución de herramientas
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // Agregar reportes
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // Ejecutar prueba
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // Validar resultados
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // Tiempo de respuesta promedio < 200ms
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
            "Duración de las solicitudes en segundos",
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
    
    # Agregar middleware para medir y registrar métricas
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
# Implementación de una Cadena de Herramientas en Python
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # Lista de nombres de herramientas a ejecutar en secuencia
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # Ejecutar cada herramienta en la cadena, pasando el resultado previo
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # Almacenar el resultado y usarlo como entrada para la siguiente herramienta
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
"csvProcessor",
```csharp
<List<Resource>>(content);

    // Assert
    Assert.NotNull(resources);
    Assert.All(resources, resource =>
    {
        Assert.NotNull(resource.Id);
        Assert.NotNull(resource.Name);
        Assert.NotNull(resource.Type);
    });
}
```

(content);
    
    // Afirmar
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

## Los 10 Mejores Consejos para Pruebas Efectivas de Servidores MCP

1. **Prueba las Definiciones de Herramientas por Separado**: Verifica las definiciones de esquema independientemente de la lógica de las herramientas
2. **Usa Pruebas Parametrizadas**: Prueba las herramientas con una variedad de entradas, incluyendo casos límite
3. **Verifica las Respuestas de Error**: Asegúrate de manejar correctamente todos los posibles casos de error
4. **Prueba la Lógica de Autorización**: Garantiza el control de acceso adecuado para diferentes roles de usuario
5. **Monitorea la Cobertura de Pruebas**: Apunta a una alta cobertura del código crítico
6. **Prueba Respuestas en Streaming**: Verifica el manejo adecuado de contenido en streaming
7. **Simula Problemas de Red**: Prueba el comportamiento bajo condiciones de red deficientes
8. **Prueba los Límites de Recursos**: Verifica el comportamiento al alcanzar cuotas o límites de velocidad
9. **Automatiza las Pruebas de Regresión**: Construye un conjunto de pruebas que se ejecute con cada cambio de código
10. **Documenta los Casos de Prueba**: Mantén una documentación clara de los escenarios de prueba

## Errores Comunes en las Pruebas

- **Exceso de confianza en pruebas de casos felices**: Asegúrate de probar los casos de error a fondo
- **Ignorar las pruebas de rendimiento**: Identifica cuellos de botella antes de que afecten la producción
- **Probar solo en aislamiento**: Combina pruebas unitarias, de integración y de extremo a extremo
- **Cobertura incompleta de la API**: Asegúrate de probar todos los endpoints y características
- **Entornos de prueba inconsistentes**: Usa contenedores para garantizar entornos de prueba consistentes

## Conclusión

Una estrategia de pruebas integral es esencial para desarrollar servidores MCP confiables y de alta calidad. Al implementar las mejores prácticas y consejos descritos en esta guía, puedes garantizar que tus implementaciones MCP cumplan con los más altos estándares de calidad, confiabilidad y rendimiento.

## Puntos Clave

1. **Diseño de Herramientas**: Sigue el principio de responsabilidad única, usa inyección de dependencias y diseña para la composibilidad
2. **Diseño de Esquemas**: Crea esquemas claros y bien documentados con restricciones de validación adecuadas
3. **Manejo de Errores**: Implementa un manejo de errores elegante, respuestas de error estructuradas y lógica de reintento
4. **Rendimiento**: Usa caché, procesamiento asíncrono y limitación de recursos
5. **Seguridad**: Aplica validación exhaustiva de entradas, verificaciones de autorización y manejo de datos sensibles
6. **Pruebas**: Crea pruebas unitarias, de integración y de extremo a extremo completas
7. **Patrones de Flujo de Trabajo**: Aplica patrones establecidos como cadenas, despachadores y procesamiento paralelo

## Ejercicio

Diseña una herramienta MCP y un flujo de trabajo para un sistema de procesamiento de documentos que:

1. Acepte documentos en múltiples formatos (PDF, DOCX, TXT)
2. Extraiga texto e información clave de los documentos
3. Clasifique los documentos por tipo y contenido
4. Genere un resumen de cada documento

Implementa los esquemas de herramientas, el manejo de errores y un patrón de flujo de trabajo que se adapte mejor a este escenario. Considera cómo probarías esta implementación.

## Recursos 

1. Únete a la comunidad MCP en el [Discord de Azure AI Foundry](https://aka.ms/foundrydevs) para mantenerte actualizado sobre los últimos desarrollos 
2. Contribuye a proyectos [MCP de código abierto](https://github.com/modelcontextprotocol)
3. Aplica los principios MCP en las iniciativas de IA de tu organización
4. Explora implementaciones MCP especializadas para tu industria
5. Considera tomar cursos avanzados sobre temas específicos de MCP, como integración multimodal o integración de aplicaciones empresariales
6. Experimenta construyendo tus propias herramientas y flujos de trabajo MCP utilizando los principios aprendidos en el [Laboratorio Práctico](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)  

Siguiente: Mejores Prácticas [estudios de caso](../09-CaseStudy/README.md)

**Descargo de responsabilidad**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por garantizar la precisión, tenga en cuenta que las traducciones automatizadas pueden contener errores o imprecisiones. El documento original en su idioma nativo debe considerarse como la fuente autorizada. Para información crítica, se recomienda una traducción profesional realizada por humanos. No nos hacemos responsables de malentendidos o interpretaciones erróneas que puedan surgir del uso de esta traducción.