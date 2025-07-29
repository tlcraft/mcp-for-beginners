<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1827d0f7a6430dfb7adcdd5f1ee05bda",
  "translation_date": "2025-07-29T00:35:52+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "pt"
}
-->
# Melhores Práticas de Desenvolvimento MCP

[![Melhores Práticas de Desenvolvimento MCP](../../../translated_images/09.d0f6d86c9d72134ccf5a8d8c8650a0557e519936661fc894cad72d73522227cb.pt.png)](https://youtu.be/W56H9W7x-ao)

_(Clique na imagem acima para assistir ao vídeo desta lição)_

## Visão Geral

Esta lição aborda práticas avançadas para o desenvolvimento, teste e implementação de servidores MCP e funcionalidades em ambientes de produção. À medida que os ecossistemas MCP crescem em complexidade e importância, seguir padrões estabelecidos garante confiabilidade, manutenção e interoperabilidade. Esta lição reúne conhecimentos práticos obtidos em implementações reais de MCP para orientá-lo na criação de servidores robustos e eficientes com recursos, prompts e ferramentas eficazes.

## Objetivos de Aprendizagem

Ao final desta lição, você será capaz de:

- Aplicar as melhores práticas da indústria no design de servidores e funcionalidades MCP
- Criar estratégias abrangentes de teste para servidores MCP
- Projetar padrões de fluxo de trabalho eficientes e reutilizáveis para aplicações MCP complexas
- Implementar tratamento de erros adequado, registro de logs e observabilidade em servidores MCP
- Otimizar implementações MCP para desempenho, segurança e manutenção

## Princípios Fundamentais do MCP

Antes de mergulhar nas práticas específicas de implementação, é importante compreender os princípios fundamentais que orientam o desenvolvimento eficaz de MCP:

1. **Comunicação Padronizada**: O MCP utiliza JSON-RPC 2.0 como base, fornecendo um formato consistente para solicitações, respostas e tratamento de erros em todas as implementações.

2. **Design Centrado no Utilizador**: Priorize sempre o consentimento, controle e transparência do utilizador nas suas implementações MCP.

3. **Segurança em Primeiro Lugar**: Implemente medidas de segurança robustas, incluindo autenticação, autorização, validação e limitação de taxa.

4. **Arquitetura Modular**: Projete seus servidores MCP com uma abordagem modular, onde cada ferramenta e recurso tem um propósito claro e focado.

5. **Conexões com Estado**: Aproveite a capacidade do MCP de manter estado entre várias solicitações para interações mais coerentes e contextuais.

## Melhores Práticas Oficiais do MCP

As seguintes melhores práticas são derivadas da documentação oficial do Model Context Protocol:

### Melhores Práticas de Segurança

1. **Consentimento e Controle do Utilizador**: Exija sempre o consentimento explícito do utilizador antes de acessar dados ou realizar operações. Forneça controle claro sobre quais dados são compartilhados e quais ações são autorizadas.

2. **Privacidade de Dados**: Exponha dados do utilizador apenas com consentimento explícito e proteja-os com controles de acesso apropriados. Garanta proteção contra transmissão não autorizada de dados.

3. **Segurança das Ferramentas**: Exija consentimento explícito do utilizador antes de invocar qualquer ferramenta. Certifique-se de que os utilizadores compreendem a funcionalidade de cada ferramenta e imponha limites de segurança robustos.

4. **Controle de Permissões das Ferramentas**: Configure quais ferramentas um modelo pode usar durante uma sessão, garantindo que apenas ferramentas explicitamente autorizadas estejam acessíveis.

5. **Autenticação**: Exija autenticação adequada antes de conceder acesso a ferramentas, recursos ou operações sensíveis, utilizando chaves de API, tokens OAuth ou outros métodos seguros de autenticação.

6. **Validação de Parâmetros**: Imponha validação para todas as invocações de ferramentas para evitar que entradas malformadas ou maliciosas alcancem as implementações das ferramentas.

7. **Limitação de Taxa**: Implemente limitação de taxa para prevenir abusos e garantir uso justo dos recursos do servidor.

### Melhores Práticas de Implementação

1. **Negociação de Capacidades**: Durante a configuração da conexão, troque informações sobre funcionalidades suportadas, versões de protocolo, ferramentas disponíveis e recursos.

2. **Design de Ferramentas**: Crie ferramentas focadas que realizem uma tarefa específica de forma eficiente, em vez de ferramentas monolíticas que lidam com múltiplas preocupações.

3. **Tratamento de Erros**: Implemente mensagens de erro padronizadas e códigos para ajudar a diagnosticar problemas, lidar com falhas de forma elegante e fornecer feedback acionável.

4. **Registro de Logs**: Configure logs estruturados para auditoria, depuração e monitoramento de interações do protocolo.

5. **Rastreamento de Progresso**: Para operações de longa duração, reporte atualizações de progresso para permitir interfaces de utilizador mais responsivas.

6. **Cancelamento de Solicitações**: Permita que os clientes cancelem solicitações em andamento que não são mais necessárias ou que estão demorando muito.

## Referências Adicionais

Para informações mais atualizadas sobre as melhores práticas do MCP, consulte:

- [Documentação MCP](https://modelcontextprotocol.io/)
- [Especificação MCP](https://spec.modelcontextprotocol.io/)
- [Repositório GitHub](https://github.com/modelcontextprotocol)
- [Melhores Práticas de Segurança](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## Exemplos Práticos de Implementação

### Melhores Práticas de Design de Ferramentas

#### 1. Princípio da Responsabilidade Única

Cada ferramenta MCP deve ter um propósito claro e focado. Em vez de criar ferramentas monolíticas que tentam lidar com múltiplas preocupações, desenvolva ferramentas especializadas que se destacam em tarefas específicas.

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

#### 2. Tratamento de Erros Consistente

Implemente tratamento de erros robusto com mensagens de erro informativas e mecanismos de recuperação apropriados.

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

## Melhores Práticas de Teste

### 1. Testes Unitários de Ferramentas MCP

Teste sempre suas ferramentas de forma isolada, simulando dependências externas:

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

Teste o fluxo completo desde as solicitações do cliente até as respostas do servidor:

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

Implemente estratégias de cache apropriadas para reduzir latência e uso de recursos:

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
    
    # Esta ferramenta pode usar resultados da ferramenta dataFetch
    async def execute_async(self, request):
        # Implementação...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # Esta ferramenta pode usar resultados da ferramenta dataAnalysis
    async def execute_async(self, request):
        # Implementação...
        pass

# Estas ferramentas podem ser usadas de forma independente ou como parte de um fluxo de trabalho
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
    
    // Propriedade de email com validação de formato
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "Endereço de email do utilizador");
    
    // Propriedade de idade com restrições numéricas
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
    subscription.put("description", "Plano de subscrição");
    
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
        # Processar solicitação
        results = await self._search_database(request.parameters["query"])
        
        # Sempre retornar uma estrutura consistente
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
    """Garante que cada item tenha uma estrutura consistente"""
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
            throw new ToolExecutionException($"Arquivo não encontrado: {fileId}");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ToolExecutionException("Você não tem permissão para acessar este arquivo");
        }
        catch (Exception ex) when (ex is IOException || ex is TimeoutException)
        {
            _logger.LogError(ex, "Erro ao acessar arquivo {FileId}", fileId);
            throw new ToolExecutionException("Erro ao acessar arquivo: O serviço está temporariamente indisponível");
        }
    }
    catch (JsonException)
    {
        throw new ToolExecutionException("Formato de ID de arquivo inválido");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Erro inesperado em FileAccessTool");
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
        
        // Re-lançar outras exceções como ToolExecutionException
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
            logging.warning(f"Erro transitório, tentando novamente em {delay}s: {str(e)}")
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
    
    // Cache não encontrado - realizar consulta real
    var result = await _database.QueryAsync(query);
    
    // Armazenar no cache com expiração
    var cacheOptions = new MemoryCacheEntryOptions()
        .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
        
    _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
    
    return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
}

private string ComputeHash(string input)
{
    // Implementação para gerar hash estável para chave de cache
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
        
        // Para operações de longa duração, retornar um ID de processamento imediatamente
        String processId = UUID.randomUUID().toString();
        
        // Iniciar processamento assíncrono
        CompletableFuture.runAsync(() -> {
            try {
                // Realizar operação de longa duração
                documentService.processDocument(documentId);
                
                // Atualizar status (normalmente seria armazenado em um banco de dados)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // Retornar resposta imediata com ID de processamento
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // Ferramenta complementar para verificar status
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
            tokens_per_second=5,  # Permitir 5 pedidos por segundo
            bucket_size=10        # Permitir picos de até 10 pedidos
        )
    
    async def execute_async(self, request):
        # Verificar se podemos prosseguir ou precisamos esperar
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # Se o tempo de espera for muito longo
                raise ToolExecutionException(
                    f"Limite de taxa excedido. Por favor, tente novamente em {delay:.1f} segundos."
                )
            else:
                # Esperar pelo tempo de atraso apropriado
                await asyncio.sleep(delay)
        
        # Consumir um token e prosseguir com o pedido
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
            
            # Calcular tempo até o próximo token disponível
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
        throw new ToolExecutionException("Parâmetro obrigatório ausente: query");
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
        throw new ToolExecutionException("Consulta inválida: contém SQL potencialmente inseguro");
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
        
        # Filtrar campos sensíveis, a menos que explicitamente solicitado E autorizado
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
        
        # Redigir campos sensíveis específicos
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        # Redigir dados sensíveis aninhados
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
        .ReturnsAsync(new WeatherForecast(/* dados de teste */));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "Seattle", 
            days = 3 
        })
    );
    
    // Executar
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
        .ThrowsAsync(new LocationNotFoundException("Localização não encontrada"));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "InvalidLocation", 
            days = 3 
        })
    );
    
    // Executar e verificar
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
    
    // Testar parâmetro obrigatório ausente
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
    # Preparar
    tool = ApiTool(timeout=0.1)  # Timeout muito curto
    
    # Simular um pedido que irá exceder o tempo limite
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # Mais longo que o timeout
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # Executar e verificar
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Verificar mensagem de exceção
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # Preparar
    tool = ApiTool()
    
    # Simular uma resposta com limite de taxa
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
        
        # Executar e verificar
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # Verificar que a exceção contém informações sobre o limite de taxa
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
    
    // Executar
>
            "csvProcessor",
            ("code", _) => "codeProcessor",
            _ => throw new InvalidOperationException("Unsupported content type or operation")
        };
    }
    
    private object GetOptionsForTool(string toolName, string operation)
    {
        return toolName switch
        {
            "textSummarizer" => new { mode = operation },
            "textAnalyzer" => new { analysisType = operation },
            "htmlProcessor" => new { parseMode = operation },
            "markdownProcessor" => new { renderMode = operation },
            "csvProcessor" => new { processingMode = operation },
            "codeProcessor" => new { analysisMode = operation },
            _ => throw new InvalidOperationException("Unsupported tool")
        };
    }
}
"csvProcessor",
```csharp
<List<Resource>>(content);

    // Assert
    Assert.NotNull(resources);
    Assert.All(resources, resource => Assert.NotNull(resource.Id));
    Assert.All(resources, resource => Assert.NotNull(resource.Name));
}
```

## Top 10 Dicas para Testes Eficazes de Servidores MCP

1. **Teste Definições de Ferramentas Separadamente**: Verifique as definições de esquema de forma independente da lógica das ferramentas  
2. **Use Testes Parametrizados**: Teste ferramentas com uma variedade de entradas, incluindo casos extremos  
3. **Verifique Respostas de Erro**: Confirme o tratamento adequado de erros para todas as condições possíveis  
4. **Teste a Lógica de Autorização**: Garanta o controlo de acesso adequado para diferentes perfis de utilizador  
5. **Monitore a Cobertura de Testes**: Procure uma cobertura elevada do código crítico  
6. **Teste Respostas em Streaming**: Verifique o tratamento correto de conteúdos em streaming  
7. **Simule Problemas de Rede**: Teste o comportamento em condições de rede instáveis  
8. **Teste Limites de Recursos**: Verifique o comportamento ao atingir quotas ou limites de taxa  
9. **Automatize Testes de Regressão**: Crie uma suíte que seja executada a cada alteração de código  
10. **Documente os Casos de Teste**: Mantenha uma documentação clara dos cenários de teste  

## Armadilhas Comuns nos Testes

- **Excesso de confiança em testes de caminho feliz**: Certifique-se de testar casos de erro de forma abrangente  
- **Ignorar testes de desempenho**: Identifique gargalos antes que afetem a produção  
- **Testar apenas em isolamento**: Combine testes unitários, de integração e de ponta a ponta (E2E)  
- **Cobertura incompleta da API**: Garanta que todos os endpoints e funcionalidades sejam testados  
- **Ambientes de teste inconsistentes**: Use contentores para garantir ambientes de teste consistentes  

## Conclusão

Uma estratégia de testes abrangente é essencial para desenvolver servidores MCP fiáveis e de alta qualidade. Ao implementar as melhores práticas e dicas descritas neste guia, pode garantir que as suas implementações MCP atendam aos mais altos padrões de qualidade, fiabilidade e desempenho.  

## Pontos-Chave

1. **Design de Ferramentas**: Siga o princípio da responsabilidade única, use injeção de dependências e projete para a composibilidade  
2. **Design de Esquemas**: Crie esquemas claros, bem documentados, com restrições de validação adequadas  
3. **Tratamento de Erros**: Implemente tratamento de erros elegante, respostas de erro estruturadas e lógica de repetição  
4. **Desempenho**: Utilize caching, processamento assíncrono e limitação de recursos  
5. **Segurança**: Aplique validação rigorosa de entradas, verificações de autorização e tratamento de dados sensíveis  
6. **Testes**: Crie testes unitários, de integração e de ponta a ponta abrangentes  
7. **Padrões de Fluxo de Trabalho**: Aplique padrões estabelecidos como cadeias, despachantes e processamento paralelo  

## Exercício

Desenhe uma ferramenta e um fluxo de trabalho MCP para um sistema de processamento de documentos que:  

1. Aceite documentos em vários formatos (PDF, DOCX, TXT)  
2. Extraia texto e informações-chave dos documentos  
3. Classifique os documentos por tipo e conteúdo  
4. Gere um resumo de cada documento  

Implemente os esquemas da ferramenta, o tratamento de erros e um padrão de fluxo de trabalho que melhor se adapte a este cenário. Considere como testaria esta implementação.  

## Recursos

1. Junte-se à comunidade MCP no [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs) para se manter atualizado sobre os últimos desenvolvimentos  
2. Contribua para projetos open-source [MCP](https://github.com/modelcontextprotocol)  
3. Aplique os princípios MCP nas iniciativas de IA da sua organização  
4. Explore implementações MCP especializadas para a sua indústria  
5. Considere fazer cursos avançados sobre tópicos específicos de MCP, como integração multimodal ou integração de aplicações empresariais  
6. Experimente criar as suas próprias ferramentas e fluxos de trabalho MCP utilizando os princípios aprendidos através do [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)  

Next: Melhores Práticas [estudos de caso](../09-CaseStudy/README.md)  

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos pela precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original na sua língua nativa deve ser considerado a fonte autoritária. Para informações críticas, recomenda-se a tradução profissional realizada por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.