<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e363328861e6e00258187f731a773411",
  "translation_date": "2025-07-16T21:56:28+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "pt"
}
-->
# Melhores Práticas de Segurança

A segurança é fundamental para implementações MCP, especialmente em ambientes empresariais. É importante garantir que as ferramentas e os dados estejam protegidos contra acessos não autorizados, fugas de dados e outras ameaças de segurança.

## Introdução

O Model Context Protocol (MCP) exige considerações específicas de segurança devido ao seu papel em fornecer aos LLMs acesso a dados e ferramentas. Esta lição explora as melhores práticas de segurança para implementações MCP com base nas diretrizes oficiais do MCP e em padrões de segurança estabelecidos.

O MCP segue princípios-chave de segurança para garantir interações seguras e confiáveis:

- **Consentimento e Controlo do Utilizador**: Os utilizadores devem fornecer consentimento explícito antes de qualquer acesso a dados ou execução de operações. Deve ser oferecido controlo claro sobre quais dados são partilhados e quais ações são autorizadas.
  
- **Privacidade dos Dados**: Os dados dos utilizadores só devem ser expostos com consentimento explícito e devem estar protegidos por controlos de acesso adequados. Proteja contra transmissões não autorizadas de dados.
  
- **Segurança das Ferramentas**: Antes de invocar qualquer ferramenta, é necessário o consentimento explícito do utilizador. Os utilizadores devem compreender claramente a funcionalidade de cada ferramenta, e devem ser aplicados limites de segurança rigorosos.

## Objetivos de Aprendizagem

No final desta lição, será capaz de:

- Implementar mecanismos seguros de autenticação e autorização para servidores MCP.
- Proteger dados sensíveis usando encriptação e armazenamento seguro.
- Garantir a execução segura das ferramentas com controlos de acesso adequados.
- Aplicar as melhores práticas para proteção de dados e conformidade com a privacidade.
- Identificar e mitigar vulnerabilidades comuns de segurança MCP, como problemas de confused deputy, token passthrough e sequestro de sessão.

## Autenticação e Autorização

Autenticação e autorização são essenciais para proteger servidores MCP. A autenticação responde à pergunta "Quem é você?" enquanto a autorização responde "O que você pode fazer?".

De acordo com a especificação de segurança MCP, estas são considerações críticas de segurança:

1. **Validação de Token**: Os servidores MCP NÃO DEVEM aceitar tokens que não tenham sido explicitamente emitidos para o servidor MCP. O "token passthrough" é um anti-padrão explicitamente proibido.

2. **Verificação de Autorização**: Servidores MCP que implementam autorização DEVEM verificar todas as requisições recebidas e NÃO DEVEM usar sessões para autenticação.

3. **Gestão Segura de Sessões**: Quando utilizarem sessões para estado, os servidores MCP DEVEM usar IDs de sessão seguros e não determinísticos, gerados com geradores de números aleatórios seguros. Os IDs de sessão DEVERÃO estar vinculados a informações específicas do utilizador.

4. **Consentimento Explícito do Utilizador**: Para servidores proxy, as implementações MCP DEVEM obter consentimento do utilizador para cada cliente registado dinamicamente antes de encaminhar para servidores de autorização de terceiros.

Vamos ver exemplos de como implementar autenticação e autorização seguras em servidores MCP usando .NET e Java.

### Integração com .NET Identity

O ASP .NET Core Identity fornece um framework robusto para gerir autenticação e autorização de utilizadores. Podemos integrá-lo com servidores MCP para proteger o acesso a ferramentas e recursos.

Existem alguns conceitos principais que precisamos compreender ao integrar o ASP.NET Core Identity com servidores MCP, nomeadamente:

- **Configuração do Identity**: Configurar o ASP.NET Core Identity com funções e claims de utilizador. Um claim é uma informação sobre o utilizador, como a sua função ou permissões, por exemplo "Admin" ou "User".
- **Autenticação JWT**: Utilizar JSON Web Tokens (JWT) para acesso seguro à API. JWT é um padrão para transmitir informações de forma segura entre partes como um objeto JSON, que pode ser verificado e confiável porque é assinado digitalmente.
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

No código anterior, temos:

- Configurado o ASP.NET Core Identity para gestão de utilizadores.
- Configurado a autenticação JWT para acesso seguro à API. Especificámos os parâmetros de validação do token, incluindo o emissor, audiência e chave de assinatura.
- Definido políticas de autorização para controlar o acesso às ferramentas com base nas funções dos utilizadores. Por exemplo, a política "CanUseAdminTools" exige que o utilizador tenha a função "Admin", enquanto a política "CanUseBasic" exige que o utilizador esteja autenticado.
- Registado ferramentas MCP com requisitos específicos de autorização, garantindo que apenas utilizadores com as funções apropriadas possam aceder a elas.

### Integração com Java Spring Security

Para Java, usaremos o Spring Security para implementar autenticação e autorização seguras para servidores MCP. O Spring Security fornece um framework de segurança abrangente que se integra perfeitamente com aplicações Spring.

Os conceitos principais aqui são:

- **Configuração do Spring Security**: Configurar as definições de segurança para autenticação e autorização.
- **Servidor de Recursos OAuth2**: Usar OAuth2 para acesso seguro às ferramentas MCP. OAuth2 é um framework de autorização que permite a serviços terceiros trocar tokens de acesso para acesso seguro à API.
- **Interceptadores de Segurança**: Implementar interceptadores de segurança para aplicar controlos de acesso na execução das ferramentas.
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

No código anterior, temos:

- Configurado o Spring Security para proteger os endpoints MCP, permitindo acesso público à descoberta de ferramentas enquanto exige autenticação para a execução das mesmas.
- Usado OAuth2 como servidor de recursos para gerir o acesso seguro às ferramentas MCP.
- Implementado um interceptador de segurança para aplicar controlos de acesso na execução das ferramentas, verificando funções e permissões do utilizador antes de permitir o acesso a ferramentas específicas.
- Definido controlo de acesso baseado em funções para restringir o acesso a ferramentas administrativas e a dados sensíveis com base nas funções dos utilizadores.

## Proteção de Dados e Privacidade

A proteção de dados é crucial para garantir que informações sensíveis sejam tratadas de forma segura. Isto inclui proteger informações pessoalmente identificáveis (PII), dados financeiros e outras informações sensíveis contra acessos não autorizados e fugas.

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

No código anterior, temos:

- Implementado a classe `PiiDetector` para analisar texto e parâmetros em busca de informações pessoalmente identificáveis (PII).
- Criado a classe `EncryptionService` para gerir a encriptação e desencriptação de dados sensíveis usando a biblioteca `cryptography`.
- Definido o decorador `secure_tool` que envolve a execução da ferramenta para verificar PII, registar acessos e encriptar dados sensíveis se necessário.
- Aplicado o decorador `secure_tool` a uma ferramenta de exemplo (`SecureCustomerDataTool`) para garantir que trata dados sensíveis de forma segura.

## Riscos de Segurança Específicos do MCP

De acordo com a documentação oficial de segurança MCP, existem riscos específicos de segurança que os implementadores MCP devem conhecer:

### 1. Problema do Confused Deputy

Esta vulnerabilidade ocorre quando um servidor MCP atua como proxy para APIs de terceiros, potencialmente permitindo que atacantes explorem a relação de confiança entre o servidor MCP e essas APIs.

**Mitigação:**
- Servidores proxy MCP que usam IDs de cliente estáticos DEVEM obter consentimento do utilizador para cada cliente registado dinamicamente antes de encaminhar para servidores de autorização de terceiros.
- Implementar o fluxo OAuth adequado com PKCE (Proof Key for Code Exchange) para pedidos de autorização.
- Validar rigorosamente os URIs de redirecionamento e identificadores de cliente.

### 2. Vulnerabilidades de Token Passthrough

Token passthrough ocorre quando um servidor MCP aceita tokens de um cliente MCP sem validar que os tokens foram emitidos corretamente para o servidor MCP e os transmite para APIs a jusante.

### Riscos
- Contorno de controlos de segurança (evitar limitação de taxa, validação de pedidos)
- Problemas de responsabilidade e auditoria
- Violações de fronteiras de confiança
- Riscos de compatibilidade futura

**Mitigação:**
- Servidores MCP NÃO DEVEM aceitar tokens que não tenham sido explicitamente emitidos para o servidor MCP.
- Validar sempre os claims de audiência do token para garantir que correspondem ao serviço esperado.

### 3. Sequestro de Sessão

Ocorre quando uma parte não autorizada obtém um ID de sessão e o usa para se passar pelo cliente original, potencialmente levando a ações não autorizadas.

**Mitigação:**
- Servidores MCP que implementam autorização DEVEM verificar todas as requisições recebidas e NÃO DEVEM usar sessões para autenticação.
- Usar IDs de sessão seguros e não determinísticos gerados com geradores de números aleatórios seguros.
- Vincular IDs de sessão a informações específicas do utilizador usando um formato de chave como `<user_id>:<session_id>`.
- Implementar políticas adequadas de expiração e rotação de sessão.

## Outras Melhores Práticas de Segurança para MCP

Para além das considerações principais de segurança MCP, considere implementar estas práticas adicionais:

- **Use sempre HTTPS**: Encripte a comunicação entre cliente e servidor para proteger tokens contra interceção.
- **Implemente Controlo de Acesso Baseado em Funções (RBAC)**: Não verifique apenas se o utilizador está autenticado; verifique o que está autorizado a fazer.
- **Monitorize e audite**: Registe todos os eventos de autenticação para detetar e responder a atividades suspeitas.
- **Gerencie limitação de taxa e throttling**: Implemente backoff exponencial e lógica de retry para lidar com limites de taxa de forma elegante.
- **Armazenamento seguro de tokens**: Guarde tokens de acesso e refresh tokens de forma segura usando mecanismos de armazenamento seguro do sistema ou serviços seguros de gestão de chaves.
- **Considere usar Gestão de API**: Serviços como o Azure API Management podem tratar automaticamente muitas preocupações de segurança, incluindo autenticação, autorização e limitação de taxa.

## Referências

- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [MCP Core Concepts](https://modelcontextprotocol.io/docs/concepts/architecture)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)

## O que vem a seguir

- [5.9 Pesquisa na web](../web-search-mcp/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos pela precisão, por favor tenha em conta que traduções automáticas podem conter erros ou imprecisões. O documento original na sua língua nativa deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes da utilização desta tradução.