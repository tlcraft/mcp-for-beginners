<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "80e5c8949af5af0f401fce6f905990aa",
  "translation_date": "2025-07-16T21:54:06+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "pt"
}
-->
# Boas Práticas de Desenvolvimento MCP

## Visão Geral

Esta lição foca-se nas melhores práticas avançadas para desenvolver, testar e implementar servidores e funcionalidades MCP em ambientes de produção. À medida que os ecossistemas MCP se tornam mais complexos e importantes, seguir padrões estabelecidos garante fiabilidade, facilidade de manutenção e interoperabilidade. Esta lição consolida a experiência prática adquirida em implementações reais de MCP para o ajudar a criar servidores robustos e eficientes com recursos, prompts e ferramentas eficazes.

## Objetivos de Aprendizagem

No final desta lição, será capaz de:
- Aplicar as melhores práticas da indústria no design de servidores e funcionalidades MCP
- Criar estratégias abrangentes de testes para servidores MCP
- Projetar padrões de workflow eficientes e reutilizáveis para aplicações MCP complexas
- Implementar tratamento de erros, registo e observabilidade adequados em servidores MCP
- Otimizar implementações MCP para desempenho, segurança e facilidade de manutenção

## Princípios Fundamentais do MCP

Antes de aprofundar práticas específicas de implementação, é importante compreender os princípios fundamentais que orientam o desenvolvimento eficaz de MCP:

1. **Comunicação Padronizada**: O MCP utiliza JSON-RPC 2.0 como base, fornecendo um formato consistente para pedidos, respostas e tratamento de erros em todas as implementações.

2. **Design Centrado no Utilizador**: Priorize sempre o consentimento, controlo e transparência do utilizador nas suas implementações MCP.

3. **Segurança em Primeiro Lugar**: Implemente medidas de segurança robustas, incluindo autenticação, autorização, validação e limitação de taxa.

4. **Arquitetura Modular**: Projete os seus servidores MCP com uma abordagem modular, onde cada ferramenta e recurso tem um propósito claro e focado.

5. **Conexões Stateful**: Aproveite a capacidade do MCP de manter estado ao longo de múltiplos pedidos para interações mais coerentes e conscientes do contexto.

## Melhores Práticas Oficiais do MCP

As seguintes melhores práticas são derivadas da documentação oficial do Model Context Protocol:

### Melhores Práticas de Segurança

1. **Consentimento e Controlo do Utilizador**: Exija sempre consentimento explícito do utilizador antes de aceder a dados ou executar operações. Forneça controlo claro sobre que dados são partilhados e quais as ações autorizadas.

2. **Privacidade dos Dados**: Exponha dados do utilizador apenas com consentimento explícito e proteja-os com controlos de acesso adequados. Previna transmissões não autorizadas de dados.

3. **Segurança das Ferramentas**: Requeira consentimento explícito do utilizador antes de invocar qualquer ferramenta. Assegure que os utilizadores compreendem a funcionalidade de cada ferramenta e imponha limites de segurança rigorosos.

4. **Controlo de Permissões das Ferramentas**: Configure quais ferramentas um modelo pode usar durante uma sessão, garantindo que apenas ferramentas explicitamente autorizadas estejam acessíveis.

5. **Autenticação**: Exija autenticação adequada antes de conceder acesso a ferramentas, recursos ou operações sensíveis, utilizando chaves API, tokens OAuth ou outros métodos seguros.

6. **Validação de Parâmetros**: Imponha validação para todas as invocações de ferramentas para evitar que entradas malformadas ou maliciosas cheguem às implementações das ferramentas.

7. **Limitação de Taxa**: Implemente limitação de taxa para prevenir abusos e garantir uso justo dos recursos do servidor.

### Melhores Práticas de Implementação

1. **Negociação de Capacidades**: Durante a configuração da ligação, troque informações sobre funcionalidades suportadas, versões do protocolo, ferramentas e recursos disponíveis.

2. **Design de Ferramentas**: Crie ferramentas focadas que façam bem uma única coisa, em vez de ferramentas monolíticas que tratem múltiplas preocupações.

3. **Tratamento de Erros**: Implemente mensagens e códigos de erro padronizados para ajudar a diagnosticar problemas, gerir falhas de forma elegante e fornecer feedback acionável.

4. **Registo (Logging)**: Configure registos estruturados para auditoria, depuração e monitorização das interações do protocolo.

5. **Acompanhamento de Progresso**: Para operações de longa duração, reporte atualizações de progresso para permitir interfaces de utilizador responsivas.

6. **Cancelamento de Pedidos**: Permita que os clientes cancelem pedidos em curso que já não são necessários ou que estejam a demorar demasiado.

## Referências Adicionais

Para obter a informação mais atualizada sobre as melhores práticas MCP, consulte:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)
- [Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## Exemplos Práticos de Implementação

### Melhores Práticas no Design de Ferramentas

#### 1. Princípio da Responsabilidade Única

Cada ferramenta MCP deve ter um propósito claro e focado. Em vez de criar ferramentas monolíticas que tentam tratar múltiplas preocupações, desenvolva ferramentas especializadas que se destaquem em tarefas específicas.

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

#### 2. Tratamento Consistente de Erros

Implemente um tratamento robusto de erros com mensagens informativas e mecanismos de recuperação adequados.

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

#### 3. Validação de Parâmetros

Valide sempre os parâmetros de forma rigorosa para evitar entradas malformadas ou maliciosas.

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

### Exemplos de Implementação de Segurança

#### 1. Autenticação e Autorização

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

#### 2. Limitação de Taxa

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

## Melhores Práticas de Testes

### 1. Testes Unitários das Ferramentas MCP

Teste sempre as suas ferramentas isoladamente, simulando dependências externas:

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

### 2. Testes de Integração

Teste o fluxo completo desde os pedidos do cliente até às respostas do servidor:

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

## Otimização de Desempenho

### 1. Estratégias de Cache

Implemente cache adequado para reduzir latência e uso de recursos:

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
// Exemplo em Java com injeção de dependências
public class CurrencyConversionTool implements Tool {
    private final ExchangeRateService exchangeService;
    private final CacheService cacheService;
    private final Logger logger;
    
    // Dependências injetadas através do construtor
    public CurrencyConversionTool(
            ExchangeRateService exchangeService,
            CacheService cacheService,
            Logger logger) {
        this.exchangeService = exchangeService;
        this.cacheService = cacheService;
        this.logger = logger;
    }
    
    // Implementação da ferramenta
    // ...
}
```

#### 3. Composable Tools

Design tools that can be composed together to create more complex workflows:

```python
# Exemplo em Python mostrando ferramentas compostas
class DataFetchTool(Tool):
    def get_name(self):
        return "dataFetch"
    
    # Implementação...

class DataAnalysisTool(Tool):
    def get_name(self):
        return "dataAnalysis"
    
    # Esta ferramenta pode usar resultados da dataFetch
    async def execute_async(self, request):
        # Implementação...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # Esta ferramenta pode usar resultados da dataAnalysis
    async def execute_async(self, request):
        # Implementação...
        pass

# Estas ferramentas podem ser usadas independentemente ou como parte de um workflow
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
                description = "Texto da consulta de pesquisa. Use palavras-chave precisas para melhores resultados." 
            },
            filters = new {
                type = "object",
                description = "Filtros opcionais para restringir os resultados da pesquisa",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "Intervalo de datas no formato YYYY-MM-DD:YYYY-MM-DD" 
                    },
                    category = new { 
                        type = "string", 
                        description = "Nome da categoria para filtrar" 
                    }
                }
            },
            limit = new { 
                type = "integer", 
                description = "Número máximo de resultados a retornar (1-50)",
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
    
    // Propriedade email com validação de formato
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "Endereço de email do utilizador");
    
    // Propriedade idade com restrições numéricas
    Map<String, Object> age = new HashMap<>();
    age.put("type", "integer");
    age.put("minimum", 13);
    age.put("maximum", 120);
    age.put("description", "Idade do utilizador em anos");
    
    // Propriedade enumerada
    Map<String, Object> subscription = new HashMap<>();
    subscription.put("type", "string");
    subscription.put("enum", Arrays.asList("free", "basic", "premium"));
    subscription.put("default", "free");
    subscription.put("description", "Nível de subscrição");
    
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
        # Processar pedido
        results = await self._search_database(request.parameters["query"])
        
        # Retornar sempre uma estrutura consistente
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
    """Garante que cada item tem uma estrutura consistente"""
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
            throw new ToolExecutionException($"Ficheiro não encontrado: {fileId}");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ToolExecutionException("Não tem permissão para aceder a este ficheiro");
        }
        catch (Exception ex) when (ex is IOException || ex is TimeoutException)
        {
            _logger.LogError(ex, "Erro ao aceder ao ficheiro {FileId}", fileId);
            throw new ToolExecutionException("Erro ao aceder ao ficheiro: O serviço está temporariamente indisponível");
        }
    }
    catch (JsonException)
    {
        throw new ToolExecutionException("Formato de ID de ficheiro inválido");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Erro inesperado no FileAccessTool");
        throw new ToolExecutionException("Ocorreu um erro inesperado");
    }
}
```

#### 2. Structured Error Responses

Return structured error information when possible:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    try {
        // Implementação
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
        
        // Re-levantar outras exceções como ToolExecutionException
        throw new ToolExecutionException("Falha na execução da ferramenta: " + ex.getMessage(), ex);
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
            # Chamar API externa
            return await self._call_api(request.parameters)
        except TransientError as e:
            retry_count += 1
            if retry_count >= max_retries:
                raise ToolExecutionException(f"Operação falhou após {max_retries} tentativas: {str(e)}")
                
            # Retentativa exponencial
            delay = base_delay * (2 ** (retry_count - 1))
            logging.warning(f"Erro transitório, a tentar novamente em {delay}s: {str(e)}")
            await asyncio.sleep(delay)
        except Exception as e:
            # Erro não transitório, não tentar novamente
            raise ToolExecutionException(f"Operação falhou: {str(e)}")
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
        
        // Criar chave de cache com base nos parâmetros
        var cacheKey = $"data_query_{ComputeHash(query)}";
        
        // Tentar obter do cache primeiro
        if (_cache.TryGetValue(cacheKey, out var cachedResult))
        {
            return new ToolResponse { Result = cachedResult };
        }
        
        // Cache não encontrado - executar a consulta real
        var result = await _database.QueryAsync(query);
        
        // Armazenar no cache com expiração
        var cacheOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
            
        _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
        
        return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
    }
    
    private string ComputeHash(string input)
    {
        // Implementação para gerar hash estável para a chave de cache
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
        
        // Para operações demoradas, retornar imediatamente um ID de processamento
        String processId = UUID.randomUUID().toString();
        
        // Iniciar processamento assíncrono
        CompletableFuture.runAsync(() -> {
            try {
                // Executar operação demorada
                documentService.processDocument(documentId);
                
                // Atualizar estado (normalmente guardado numa base de dados)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // Retornar resposta imediata com o ID do processo
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // Ferramenta complementar para verificação de estado
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
            tokens_per_second=5,  # Permite 5 pedidos por segundo
            bucket_size=10        # Permite picos até 10 pedidos
        )
    
    async def execute_async(self, request):
        # Verificar se podemos continuar ou se é necessário esperar
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # Se a espera for demasiado longa
                raise ToolExecutionException(
                    f"Limite de taxa excedido. Por favor, tente novamente em {delay:.1f} segundos."
                )
            else:
                # Esperar o tempo de atraso apropriado
                await asyncio.sleep(delay)
        
        # Consumir um token e continuar com o pedido
        self.rate_limiter.consume()
        
        # Chamar API
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
            
            # Calcular tempo até o próximo token estar disponível
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # Adicionar novos tokens com base no tempo decorrido
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
    // Validar se os parâmetros existem
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("Parâmetro obrigatório em falta: query");
    }
    
    // Validar tipo correto
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("O parâmetro query deve ser uma string");
    }
    
    var query = queryProp.GetString();
    
    // Validar conteúdo da string
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("O parâmetro query não pode estar vazio");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("O parâmetro query excede o comprimento máximo de 500 caracteres");
    }
    
    // Verificar ataques de injeção SQL, se aplicável
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("Query inválida: contém SQL potencialmente inseguro");
    }
    
    // Prosseguir com a execução
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // Obter contexto do utilizador a partir do pedido
    UserContext user = request.getContext().getUserContext();
    
    // Verificar se o utilizador tem as permissões necessárias
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("O utilizador não tem permissão para aceder aos documentos");
    }
    
    // Para recursos específicos, verificar acesso a esse recurso
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("Acesso negado ao documento solicitado");
    }
    
    // Prosseguir com a execução da ferramenta
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
        
        # Obter dados do utilizador
        user_data = await self.user_service.get_user_data(user_id)
        
        # Filtrar campos sensíveis a menos que explicitamente solicitado E autorizado
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        # Verificar nível de autorização no contexto do pedido
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        # Criar uma cópia para evitar modificar o original
        redacted = user_data.copy()
        
        # Ocultar campos sensíveis específicos
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # Ocultar dados sensíveis aninhados
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
    // Preparação
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("Seattle", 3))
        .ReturnsAsync(new WeatherForecast(/* dados de teste */));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "Seattle", 
            days = 3 
        })
    );
    
    // Ação
    var response = await tool.ExecuteAsync(request);
    
    // Verificação
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // Preparação
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("InvalidLocation", It.IsAny<int>()))
        .ThrowsAsync(new LocationNotFoundException("Localização não encontrada"));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "InvalidLocation", 
            days = 3 
        })
    );
    
    // Ação & Verificação
    var exception = await Assert.ThrowsAsync<ToolExecutionException>(
        () => tool.ExecuteAsync(request)
    );
    
    Assert.Contains("Localização não encontrada", exception.Message);
}
```

#### 2. Schema Validation Testing

Test that schemas are valid and properly enforce constraints:

```java
@Test
public void testSchemaValidation() {
    // Criar instância da ferramenta
    SearchTool searchTool = new SearchTool();
    
    // Obter esquema
    Object schema = searchTool.getSchema();
    
    // Converter esquema para JSON para validação
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // Validar que o esquema é um JSONSchema válido
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // Testar parâmetros válidos
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // Testar parâmetro obrigatório em falta
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // Testar tipo de parâmetro inválido
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
    # Preparação
    tool = ApiTool(timeout=0.1)  # Timeout muito curto
    
    # Simular um pedido que irá expirar
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # Mais longo que o timeout
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # Ação & Verificação
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Verificar mensagem de exceção
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # Preparação
    tool = ApiTool()
    
    # Simular uma resposta com limitação de taxa
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
        
        # Ação & Verificação
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Verificar se a exceção contém informação sobre limitação de taxa
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
    // Preparação
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // Ação
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
        // Testar o endpoint de descoberta
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // Criar pedido para a ferramenta
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // Enviar pedido e verificar resposta
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // Criar pedido inválido para a ferramenta
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // Falta o parâmetro "b"
        request.put("parameters", parameters);
        
        // Enviar pedido e verificar resposta de erro
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
    # Preparar - Configurar cliente MCP e modelo simulado
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # Respostas simuladas do modelo
    mock_model = MockLanguageModel([
        MockResponse(
            "Qual é a previsão do tempo em Seattle?",
            tool_calls=[{
                "tool_name": "weatherForecast",
                "parameters": {"location": "Seattle", "days": 3}
            }]
        ),
        MockResponse(
            "Aqui está a previsão do tempo para Seattle:\n- Hoje: 65°F, Parcialmente Nublado\n- Amanhã: 68°F, Sol\n- Depois: 62°F, Chuva",
            tool_calls=[]
        )
    ])
    
    # Resposta simulada da ferramenta de meteorologia
    with aioresponses() as mocked:
        mocked.post(
            "http://localhost:5000/mcp/execute",
            payload={
                "result": {
                    "location": "Seattle",
                    "forecast": [
                        {"date": "2023-06-01", "temperature": 65, "conditions": "Parcialmente Nublado"},
                        {"date": "2023-06-02", "temperature": 68, "conditions": "Sol"},
                        {"date": "2023-06-03", "temperature": 62, "conditions": "Chuva"}
                    ]
                }
            }
        )
        
        # Executar
        response = await mcp_client.send_prompt(
            "Qual é a previsão do tempo em Seattle?",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # Verificar
        assert "Seattle" in response.generated_text
        assert "65" in response.generated_text
        assert "Sol" in response.generated_text
        assert "Chuva" in response.generated_text
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
    
    // Executar
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
    
    // Configurar JMeter para teste de stress
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // Configurar plano de teste do JMeter
    HashTree testPlanTree = new HashTree();
    
    // Criar plano de teste, grupo de threads, amostradores, etc.
    TestPlan testPlan = new TestPlan("Teste de Stress do Servidor MCP");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // Adicionar amostrador HTTP para execução da ferramenta
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // Adicionar ouvintes
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // Executar teste
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // Validar resultados
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // Tempo médio de resposta < 200ms
    assertTrue(summaryReport.getPercentile(90.0) < 500); // Percentil 90 < 500ms
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# Configurar monitorização para um servidor MCP
def configure_monitoring(server):
    # Configurar métricas Prometheus
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "Total de pedidos MCP"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "Duração dos pedidos em segundos",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "Contagem de execuções de ferramentas",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "Duração da execução das ferramentas em segundos",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "Erros na execução das ferramentas",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # Adicionar middleware para medir e registar métricas
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # Expor endpoint de métricas
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
# Implementação Python de Cadeia de Ferramentas
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # Lista de nomes de ferramentas a executar em sequência
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # Executar cada ferramenta na cadeia, passando o resultado anterior
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # Guardar resultado e usar como input para a próxima ferramenta
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# Exemplo de uso
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
    public string Description => "Processa conteúdos de vários tipos";
    
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
        
        // Determinar qual a ferramenta especializada a usar
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // Encaminhar para a ferramenta especializada
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
# Guia do csvProcessor

O csvProcessor é uma ferramenta poderosa para manipular ficheiros CSV de forma eficiente e flexível.

## Funcionalidades principais

- Leitura e escrita de ficheiros CSV com diferentes delimitadores
- Suporte para ficheiros grandes sem consumir muita memória
- Filtragem e transformação de dados durante o processamento
- Exportação para vários formatos suportados

## Como usar

1. Importe o módulo csvProcessor no seu projeto.
2. Utilize a função `readCSV` para carregar os dados.
3. Aplique filtros ou transformações conforme necessário.
4. Guarde os resultados com `writeCSV`.

```python
# Exemplo de leitura de um ficheiro CSV
data = csvProcessor.readCSV('dados.csv', delimiter=';')

# Filtrar linhas onde a coluna "idade" é maior que 30
filtered_data = [row for row in data if int(row['idade']) > 30]

# Guardar os dados filtrados num novo ficheiro
csvProcessor.writeCSV('dados_filtrados.csv', filtered_data)
```

## Dicas úteis

[!TIP]  
Para melhorar a performance, evite carregar todo o ficheiro na memória se não for necessário. Utilize processamento em streaming.

[!IMPORTANT]  
Certifique-se de que o delimitador usado corresponde ao do ficheiro CSV para evitar erros de parsing.

## Resolução de problemas comuns

- Se receber um erro de codificação, verifique a codificação do ficheiro original.
- Para problemas de formatação, confirme se todas as linhas têm o mesmo número de colunas.

## Contacto

Para mais informações ou suporte, visite a página oficial do projeto ou envie um email para support@csvprocessor.com.
("code", _) => "codeAnalyzer",
_ => throw new ToolExecutionException($"Nenhuma ferramenta disponível para {contentType}/{operation}")
};

}

private object GetOptionsForTool(string toolName, string operation)
{
// Retorna as opções apropriadas para cada ferramenta especializada
return toolName switch
{
    "textSummarizer" => new { length = "medium" },
    "htmlProcessor" => new { cleanUp = true, operation },
    // Opções para outras ferramentas...
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
        // Passo 1: Obter metadados do conjunto de dados (síncrono)
        ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata", 
            Map.of("datasetId", datasetId));
        
        // Passo 2: Lançar múltiplas análises em paralelo
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
        
        // Aguardar que todas as tarefas paralelas terminem
        CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
            statisticalAnalysis, correlationAnalysis, outlierDetection
        );
        
        allAnalyses.join();  // Esperar pela conclusão
        
        // Passo 3: Combinar resultados
        Map<String, Object> combinedResults = new HashMap<>();
        combinedResults.put("metadata", metadataResponse.getResult());
        combinedResults.put("statistics", statisticalAnalysis.join().getResult());
        combinedResults.put("correlations", correlationAnalysis.join().getResult());
        combinedResults.put("outliers", outlierDetection.join().getResult());
        
        // Passo 4: Gerar relatório resumo
        ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator", 
            Map.of("analysisResults", combinedResults));
        
        // Retornar resultado completo do workflow
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
            # Tentar a ferramenta principal primeiro
            response = await self.client.execute_tool(primary_tool, parameters)
            return {
                "result": response.result,
                "source": "primary",
                "tool": primary_tool
            }
        except ToolExecutionException as e:
            # Registar a falha
            logging.warning(f"Falha na ferramenta principal '{primary_tool}': {str(e)}")
            
            # Recurso à ferramenta secundária
            try:
                # Pode ser necessário adaptar os parâmetros para a ferramenta de fallback
                fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)
                
                response = await self.client.execute_tool(fallback_tool, fallback_params)
                return {
                    "result": response.result,
                    "source": "fallback",
                    "tool": fallback_tool,
                    "primaryError": str(e)
                }
            except ToolExecutionException as fallback_error:
                # Ambas as ferramentas falharam
                logging.error(f"Falha nas ferramentas principal e de fallback. Erro de fallback: {str(fallback_error)}")
                raise WorkflowExecutionException(
                    f"Workflow falhou: erro principal: {str(e)}; erro de fallback: {str(fallback_error)}"
                )
    
    def _adapt_parameters(self, params, from_tool, to_tool):
        """Adaptar parâmetros entre diferentes ferramentas, se necessário"""
        # Esta implementação depende das ferramentas específicas
        # Neste exemplo, apenas retorna os parâmetros originais
        return params

# Exemplo de uso
async def get_weather(workflow, location):
    return await workflow.execute_with_fallback(
        "premiumWeatherService",  # API meteorológica principal (paga)
        "basicWeatherService",    # API meteorológica de fallback (gratuita)
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
            
            // Guardar o resultado de cada workflow
            results[workflow.Name] = workflowResult;
            
            // Atualizar o contexto com o resultado para o próximo workflow
            context = context.WithResult(workflow.Name, workflowResult);
        }
        
        return new WorkflowResult(results);
    }
    
    public string Name => "CompositeWorkflow";
    public string Description => "Executa múltiplos workflows em sequência";
}

// Exemplo de uso
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
// Exemplo de teste unitário para uma ferramenta de calculadora em C#
[Fact]
public async Task CalculatorTool_Add_ReturnsCorrectSum()
{
    // Preparação
    var calculator = new CalculatorTool();
    var parameters = new Dictionary<string, object>
    {
        ["operation"] = "add",
        ["a"] = 5,
        ["b"] = 7
    };
    
    // Execução
    var response = await calculator.ExecuteAsync(parameters);
    var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());
    
    // Verificação
    Assert.Equal(12, result.Value);
}
```

```python
# Exemplo de teste unitário para uma ferramenta de calculadora em Python
def test_calculator_tool_add():
    # Preparação
    calculator = CalculatorTool()
    parameters = {
        "operation": "add",
        "a": 5,
        "b": 7
    }
    
    # Execução
    response = calculator.execute(parameters)
    result = json.loads(response.content[0].text)
    
    # Verificação
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
// Exemplo de teste de integração para o servidor MCP em C#
[Fact]
public async Task Server_ProcessToolRequest_ReturnsValidResponse()
{
    // Preparação
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
    
    // Execução
    var response = await server.ProcessRequestAsync(request);
    
    // Verificação
    Assert.NotNull(response);
    Assert.Equal(McpStatusCodes.Success, response.StatusCode);
    // Verificações adicionais para o conteúdo da resposta
    
    // Limpeza
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
// Exemplo de teste E2E com um cliente em TypeScript
describe('MCP Server E2E Tests', () => {
  let client: McpClient;
  
  beforeAll(async () => {
    // Iniciar servidor em ambiente de teste
    await startTestServer();
    client = new McpClient('http://localhost:5000');
  });
  
  afterAll(async () => {
    await stopTestServer();
  });
  
  test('Cliente consegue invocar ferramenta de calculadora e obter resultado correto', async () => {
    // Execução
    const response = await client.invokeToolAsync('calculator', {
      operation: 'divide',
      a: 20,
      b: 4
    });
    
    // Verificação
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
// Exemplo em C# com Moq
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
# Exemplo em Python com unittest.mock
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
    # Configurar mock
    mock_model.return_value.generate_response.return_value = {
        "text": "Mocked model response",
        "finish_reason": "completed"
    }
    
    # Usar mock no teste
    server = McpServer(model_client=mock_model)
    # Continuar com o teste
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
// Script k6 para testes de carga no servidor MCP
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  vus: 10,  // 10 utilizadores virtuais
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
    'status é 200': (r) => r.status === 200,
    'tempo de resposta < 500ms': (r) => r.timings.duration < 500,
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
    
    - name: Restaurar dependências
      run: dotnet restore
    
    - name: Compilar
      run: dotnet build --no-restore
    
    - name: Testes Unitários
      run: dotnet test --no-build --filter Category=Unit
    
    - name: Testes de Integração
      run: dotnet test --no-build --filter Category=Integration
      
    - name: Testes de Performance
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
    // Preparação
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");
    
    // Execução
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
    // Validação adicional do esquema
});
}

## Top 10 Dicas para Testes Eficazes de Servidores MCP

1. **Teste as Definições das Ferramentas Separadamente**: Verifique as definições do esquema independentemente da lógica da ferramenta  
2. **Use Testes Parametrizados**: Teste as ferramentas com uma variedade de entradas, incluindo casos limite  
3. **Verifique as Respostas de Erro**: Confirme o tratamento adequado de erros para todas as condições possíveis  
4. **Teste a Lógica de Autorização**: Garanta controlo de acesso correto para diferentes perfis de utilizador  
5. **Monitorize a Cobertura dos Testes**: Procure uma cobertura elevada do código dos caminhos críticos  
6. **Teste Respostas em Streaming**: Verifique o tratamento correto de conteúdos em streaming  
7. **Simule Problemas de Rede**: Teste o comportamento em condições de rede instáveis  
8. **Teste Limites de Recursos**: Verifique o comportamento ao atingir quotas ou limites de taxa  
9. **Automatize Testes de Regressão**: Crie uma suite que execute a cada alteração de código  
10. **Documente os Casos de Teste**: Mantenha documentação clara dos cenários de teste  

## Armadilhas Comuns nos Testes

- **Excesso de confiança em testes de caminho feliz**: Certifique-se de testar exaustivamente os casos de erro  
- **Ignorar testes de desempenho**: Identifique gargalos antes que afetem a produção  
- **Testar apenas em isolamento**: Combine testes unitários, de integração e end-to-end  
- **Cobertura incompleta da API**: Assegure que todos os endpoints e funcionalidades são testados  
- **Ambientes de teste inconsistentes**: Use containers para garantir ambientes de teste consistentes  

## Conclusão

Uma estratégia de testes abrangente é essencial para desenvolver servidores MCP fiáveis e de alta qualidade. Ao implementar as melhores práticas e dicas apresentadas neste guia, pode garantir que as suas implementações MCP cumprem os mais elevados padrões de qualidade, fiabilidade e desempenho.

## Principais Conclusões

1. **Design da Ferramenta**: Siga o princípio da responsabilidade única, use injeção de dependências e projete para composabilidade  
2. **Design do Esquema**: Crie esquemas claros, bem documentados e com restrições de validação adequadas  
3. **Tratamento de Erros**: Implemente tratamento de erros elegante, respostas estruturadas e lógica de retry  
4. **Desempenho**: Utilize caching, processamento assíncrono e limitação de recursos  
5. **Segurança**: Aplique validação rigorosa de entradas, verificações de autorização e tratamento de dados sensíveis  
6. **Testes**: Crie testes unitários, de integração e end-to-end abrangentes  
7. **Padrões de Workflow**: Aplique padrões estabelecidos como cadeias, despachantes e processamento paralelo  

## Exercício

Desenhe uma ferramenta MCP e um workflow para um sistema de processamento de documentos que:

1. Aceite documentos em vários formatos (PDF, DOCX, TXT)  
2. Extraia texto e informações chave dos documentos  
3. Classifique os documentos por tipo e conteúdo  
4. Gere um resumo de cada documento  

Implemente os esquemas da ferramenta, o tratamento de erros e um padrão de workflow que melhor se adeque a este cenário. Considere como testaria esta implementação.

## Recursos

1. Junte-se à comunidade MCP no [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs) para se manter atualizado sobre as últimas novidades  
2. Contribua para projetos open-source [MCP](https://github.com/modelcontextprotocol)  
3. Aplique os princípios MCP nas iniciativas de IA da sua organização  
4. Explore implementações MCP especializadas para o seu setor  
5. Considere fazer cursos avançados sobre tópicos específicos MCP, como integração multimodal ou integração de aplicações empresariais  
6. Experimente construir as suas próprias ferramentas e workflows MCP usando os princípios aprendidos no [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)  

Seguinte: Melhores Práticas [estudos de caso](../09-CaseStudy/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos pela precisão, por favor tenha em conta que traduções automáticas podem conter erros ou imprecisões. O documento original na sua língua nativa deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes da utilização desta tradução.