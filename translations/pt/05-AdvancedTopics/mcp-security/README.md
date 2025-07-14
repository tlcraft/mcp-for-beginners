<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-07-14T02:38:42+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "pt"
}
-->
# Melhores Práticas de Segurança

A segurança é fundamental para implementações MCP, especialmente em ambientes empresariais. É importante garantir que as ferramentas e os dados estejam protegidos contra acessos não autorizados, fugas de dados e outras ameaças de segurança.

## Introdução

Nesta lição, vamos explorar as melhores práticas de segurança para implementações MCP. Abordaremos autenticação e autorização, proteção de dados, execução segura de ferramentas e conformidade com regulamentos de privacidade de dados.

## Objetivos de Aprendizagem

No final desta lição, será capaz de:

- Implementar mecanismos seguros de autenticação e autorização para servidores MCP.
- Proteger dados sensíveis usando encriptação e armazenamento seguro.
- Garantir a execução segura das ferramentas com controlos de acesso adequados.
- Aplicar as melhores práticas para proteção de dados e conformidade com a privacidade.

## Autenticação e Autorização

Autenticação e autorização são essenciais para proteger os servidores MCP. A autenticação responde à pergunta "Quem é você?" enquanto a autorização responde "O que pode fazer?".

Vamos ver exemplos de como implementar autenticação e autorização seguras em servidores MCP usando .NET e Java.

### Integração .NET Identity

O ASP .NET Core Identity fornece um framework robusto para gerir a autenticação e autorização de utilizadores. Podemos integrá-lo com servidores MCP para proteger o acesso a ferramentas e recursos.

Existem alguns conceitos principais que precisamos de entender ao integrar o ASP.NET Core Identity com servidores MCP, nomeadamente:

- **Configuração do Identity**: Configurar o ASP.NET Core Identity com funções e claims de utilizador. Um claim é uma informação sobre o utilizador, como a sua função ou permissões, por exemplo "Admin" ou "User".
- **Autenticação JWT**: Utilizar JSON Web Tokens (JWT) para acesso seguro à API. O JWT é um padrão para transmitir informações de forma segura entre partes como um objeto JSON, que pode ser verificado e confiável porque é assinado digitalmente.
- **Políticas de Autorização**: Definir políticas para controlar o acesso a ferramentas específicas com base nas funções dos utilizadores. O MCP usa políticas de autorização para determinar quais utilizadores podem aceder a quais ferramentas com base nas suas funções e claims.

```csharp
public class SecureMcpStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Add ASP.NET Core Identity
        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        
        // Configure JWT authentication
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = Configuration["Jwt:Issuer"],
                ValidAudience = Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            };
        });
        
        // Add authorization policies
        services.AddAuthorization(options =>
        {
            options.AddPolicy("CanUseAdminTools", policy =>
                policy.RequireRole("Admin"));
                
            options.AddPolicy("CanUseBasicTools", policy =>
                policy.RequireAuthenticatedUser());
        });
        
        // Configure MCP server with security
        services.AddMcpServer(options =>
        {
            options.ServerName = "Secure MCP Server";
            options.ServerVersion = "1.0.0";
            options.RequireAuthentication = true;
        });
        
        // Register tools with authorization requirements
        services.AddMcpTool<BasicTool>(options => 
            options.RequirePolicy("CanUseBasicTools"));
            
        services.AddMcpTool<AdminTool>(options => 
            options.RequirePolicy("CanUseAdminTools"));
    }
    
    public void Configure(IApplicationBuilder app)
    {
        // Use authentication and authorization
        app.UseAuthentication();
        app.UseAuthorization();
        
        // Use MCP server middleware
        app.UseMcpServer();
    }
}
```

No código anterior, fizemos:

- Configuração do ASP.NET Core Identity para gestão de utilizadores.
- Configuração da autenticação JWT para acesso seguro à API. Especificámos os parâmetros de validação do token, incluindo o emissor, audiência e chave de assinatura.
- Definição de políticas de autorização para controlar o acesso às ferramentas com base nas funções dos utilizadores. Por exemplo, a política "CanUseAdminTools" exige que o utilizador tenha a função "Admin", enquanto a política "CanUseBasic" exige que o utilizador esteja autenticado.
- Registo das ferramentas MCP com requisitos específicos de autorização, garantindo que apenas utilizadores com as funções apropriadas possam aceder a elas.

### Integração Java Spring Security

Para Java, usaremos o Spring Security para implementar autenticação e autorização seguras para servidores MCP. O Spring Security fornece um framework de segurança abrangente que se integra perfeitamente com aplicações Spring.

Os conceitos principais aqui são:

- **Configuração do Spring Security**: Configurar as definições de segurança para autenticação e autorização.
- **Servidor de Recursos OAuth2**: Utilizar OAuth2 para acesso seguro às ferramentas MCP. O OAuth2 é um framework de autorização que permite a serviços terceiros trocar tokens de acesso para acesso seguro à API.
- **Intercetores de Segurança**: Implementar intercetores de segurança para aplicar controlos de acesso na execução das ferramentas.
- **Controlo de Acesso Baseado em Funções**: Usar funções para controlar o acesso a ferramentas e recursos específicos.
- **Anotações de Segurança**: Usar anotações para proteger métodos e endpoints.

```java
@Configuration
@EnableWebSecurity
public class SecurityConfig extends WebSecurityConfigurerAdapter {

    @Override
    protected void configure(HttpSecurity http) throws Exception {
        http
            .csrf().disable()
            .authorizeRequests()
                .antMatchers("/mcp/discovery").permitAll() // Allow tool discovery
                .antMatchers("/mcp/tools/**").hasAnyRole("USER", "ADMIN") // Require authentication for tools
                .antMatchers("/mcp/admin/**").hasRole("ADMIN") // Admin-only endpoints
                .anyRequest().authenticated()
            .and()
            .oauth2ResourceServer().jwt();
    }
    
    @Bean
    public McpSecurityInterceptor mcpSecurityInterceptor() {
        return new McpSecurityInterceptor();
    }
}

// MCP Security Interceptor for tool authorization
public class McpSecurityInterceptor implements ToolExecutionInterceptor {
    @Autowired
    private JwtDecoder jwtDecoder;
    
    @Override
    public void beforeToolExecution(ToolRequest request, Authentication authentication) {
        String toolName = request.getToolName();
        
        // Check if user has permissions for this tool
        if (toolName.startsWith("admin") && !authentication.getAuthorities().contains("ROLE_ADMIN")) {
            throw new AccessDeniedException("You don't have permission to use this tool");
        }
        
        // Additional security checks based on tool or parameters
        if ("sensitiveDataAccess".equals(toolName)) {
            validateDataAccessPermissions(request, authentication);
        }
    }
    
    private void validateDataAccessPermissions(ToolRequest request, Authentication auth) {
        // Implementation to check fine-grained data access permissions
    }
}
```

No código anterior, fizemos:

- Configuração do Spring Security para proteger os endpoints MCP, permitindo acesso público à descoberta de ferramentas enquanto exige autenticação para a execução das mesmas.
- Uso do OAuth2 como servidor de recursos para gerir o acesso seguro às ferramentas MCP.
- Implementação de um intercetor de segurança para aplicar controlos de acesso na execução das ferramentas, verificando as funções e permissões do utilizador antes de permitir o acesso a ferramentas específicas.
- Definição de controlo de acesso baseado em funções para restringir o acesso a ferramentas administrativas e a dados sensíveis com base nas funções dos utilizadores.

## Proteção de Dados e Privacidade

A proteção de dados é crucial para garantir que informações sensíveis são tratadas de forma segura. Isto inclui proteger informações pessoalmente identificáveis (PII), dados financeiros e outras informações sensíveis contra acessos não autorizados e fugas.

### Exemplo de Proteção de Dados em Python

Vamos ver um exemplo de como implementar proteção de dados em Python usando encriptação e deteção de PII.

```python
from mcp_server import McpServer
from mcp_tools import Tool, ToolRequest, ToolResponse
from cryptography.fernet import Fernet
import os
import json
from functools import wraps

# PII Detector - identifies and protects sensitive information
class PiiDetector:
    def __init__(self):
        # Load patterns for different types of PII
        with open("pii_patterns.json", "r") as f:
            self.patterns = json.load(f)
    
    def scan_text(self, text):
        """Scans text for PII and returns detected PII types"""
        detected_pii = []
        # Implementation to detect PII using regex or ML models
        return detected_pii
    
    def scan_parameters(self, parameters):
        """Scans request parameters for PII"""
        detected_pii = []
        for key, value in parameters.items():
            if isinstance(value, str):
                pii_in_value = self.scan_text(value)
                if pii_in_value:
                    detected_pii.append((key, pii_in_value))
        return detected_pii

# Encryption Service for protecting sensitive data
class EncryptionService:
    def __init__(self, key_path=None):
        if key_path and os.path.exists(key_path):
            with open(key_path, "rb") as key_file:
                self.key = key_file.read()
        else:
            self.key = Fernet.generate_key()
            if key_path:
                with open(key_path, "wb") as key_file:
                    key_file.write(self.key)
        
        self.cipher = Fernet(self.key)
    
    def encrypt(self, data):
        """Encrypt data"""
        if isinstance(data, str):
            return self.cipher.encrypt(data.encode()).decode()
        else:
            return self.cipher.encrypt(json.dumps(data).encode()).decode()
    
    def decrypt(self, encrypted_data):
        """Decrypt data"""
        if encrypted_data is None:
            return None
        
        decrypted = self.cipher.decrypt(encrypted_data.encode())
        try:
            return json.loads(decrypted)
        except:
            return decrypted.decode()

# Security decorator for tools
def secure_tool(requires_encryption=False, log_access=True):
    def decorator(cls):
        original_execute = cls.execute_async if hasattr(cls, 'execute_async') else cls.execute
        
        @wraps(original_execute)
        async def secure_execute(self, request):
            # Check for PII in request
            pii_detector = PiiDetector()
            pii_found = pii_detector.scan_parameters(request.parameters)
            
            # Log access if required
            if log_access:
                tool_name = self.get_name()
                user_id = request.context.get("user_id", "anonymous")
                log_entry = {
                    "timestamp": datetime.now().isoformat(),
                    "tool": tool_name,
                    "user": user_id,
                    "contains_pii": bool(pii_found),
                    "parameters": {k: "***" for k in request.parameters.keys()}  # Don't log actual values
                }
                logging.info(f"Tool access: {json.dumps(log_entry)}")
            
            # Handle detected PII
            if pii_found:
                # Either encrypt sensitive data or reject the request
                if requires_encryption:
                    encryption_service = EncryptionService("keys/tool_key.key")
                    for param_name, pii_types in pii_found:
                        # Encrypt the sensitive parameter
                        request.parameters[param_name] = encryption_service.encrypt(
                            request.parameters[param_name]
                        )
                else:
                    # If encryption not available but PII found, you might reject the request
                    raise ToolExecutionException(
                        "Request contains sensitive data that cannot be processed securely"
                    )
            
            # Execute the original method
            return await original_execute(self, request)
        
        # Replace the execute method
        if hasattr(cls, 'execute_async'):
            cls.execute_async = secure_execute
        else:
            cls.execute = secure_execute
        return cls
    
    return decorator

# Example of a secure tool with the decorator
@secure_tool(requires_encryption=True, log_access=True)
class SecureCustomerDataTool(Tool):
    def get_name(self):
        return "customerData"
    
    def get_description(self):
        return "Accesses customer data securely"
    
    def get_schema(self):
        # Schema definition
        return {}
    
    async def execute_async(self, request):
        # Implementation would access customer data securely
        # Since we used the decorator, PII is already detected and encrypted
        return ToolResponse(result={"status": "success"})
```

No código anterior, fizemos:

- Implementação da classe `PiiDetector` para analisar texto e parâmetros em busca de informações pessoalmente identificáveis (PII).
- Criação da classe `EncryptionService` para gerir a encriptação e desencriptação de dados sensíveis usando a biblioteca `cryptography`.
- Definição do decorador `secure_tool` que envolve a execução da ferramenta para verificar PII, registar acessos e encriptar dados sensíveis, se necessário.
- Aplicação do decorador `secure_tool` a uma ferramenta de exemplo (`SecureCustomerDataTool`) para garantir que trata os dados sensíveis de forma segura.

## O que vem a seguir

- [5.9 Pesquisa na web](../web-search-mcp/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos pela precisão, por favor tenha em conta que traduções automáticas podem conter erros ou imprecisões. O documento original na sua língua nativa deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes da utilização desta tradução.