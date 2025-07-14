<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-07-14T02:34:47+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "es"
}
-->
# Mejores Prácticas de Seguridad

La seguridad es fundamental para las implementaciones de MCP, especialmente en entornos empresariales. Es importante garantizar que las herramientas y los datos estén protegidos contra accesos no autorizados, filtraciones de datos y otras amenazas de seguridad.

## Introducción

En esta lección, exploraremos las mejores prácticas de seguridad para las implementaciones de MCP. Cubriremos autenticación y autorización, protección de datos, ejecución segura de herramientas y cumplimiento de regulaciones de privacidad de datos.

## Objetivos de Aprendizaje

Al finalizar esta lección, podrás:

- Implementar mecanismos seguros de autenticación y autorización para servidores MCP.
- Proteger datos sensibles mediante cifrado y almacenamiento seguro.
- Asegurar la ejecución segura de herramientas con controles de acceso adecuados.
- Aplicar mejores prácticas para la protección de datos y el cumplimiento de la privacidad.

## Autenticación y Autorización

La autenticación y la autorización son esenciales para asegurar los servidores MCP. La autenticación responde a la pregunta "¿Quién eres?" mientras que la autorización responde "¿Qué puedes hacer?".

Veamos ejemplos de cómo implementar autenticación y autorización seguras en servidores MCP usando .NET y Java.

### Integración de .NET Identity

ASP .NET Core Identity ofrece un marco sólido para gestionar la autenticación y autorización de usuarios. Podemos integrarlo con servidores MCP para proteger el acceso a herramientas y recursos.

Hay algunos conceptos clave que debemos entender al integrar ASP.NET Core Identity con servidores MCP, a saber:

- **Configuración de Identity**: Configurar ASP.NET Core Identity con roles y claims de usuario. Un claim es una información sobre el usuario, como su rol o permisos, por ejemplo "Admin" o "User".
- **Autenticación JWT**: Uso de JSON Web Tokens (JWT) para acceso seguro a la API. JWT es un estándar para transmitir información de forma segura entre partes como un objeto JSON, que puede ser verificado y confiable porque está firmado digitalmente.
- **Políticas de Autorización**: Definir políticas para controlar el acceso a herramientas específicas según los roles de usuario. MCP usa políticas de autorización para determinar qué usuarios pueden acceder a qué herramientas según sus roles y claims.

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

En el código anterior, hemos:

- Configurado ASP.NET Core Identity para la gestión de usuarios.
- Configurado la autenticación JWT para acceso seguro a la API. Especificamos los parámetros de validación del token, incluyendo el emisor, audiencia y clave de firma.
- Definido políticas de autorización para controlar el acceso a herramientas según los roles de usuario. Por ejemplo, la política "CanUseAdminTools" requiere que el usuario tenga el rol "Admin", mientras que la política "CanUseBasic" requiere que el usuario esté autenticado.
- Registrado herramientas MCP con requisitos específicos de autorización, asegurando que solo los usuarios con los roles adecuados puedan acceder a ellas.

### Integración de Java Spring Security

Para Java, usaremos Spring Security para implementar autenticación y autorización seguras en servidores MCP. Spring Security ofrece un marco de seguridad completo que se integra perfectamente con aplicaciones Spring.

Los conceptos clave aquí son:

- **Configuración de Spring Security**: Configurar la seguridad para autenticación y autorización.
- **Servidor de Recursos OAuth2**: Uso de OAuth2 para acceso seguro a herramientas MCP. OAuth2 es un marco de autorización que permite a servicios terceros intercambiar tokens de acceso para acceso seguro a APIs.
- **Interceptores de Seguridad**: Implementar interceptores de seguridad para hacer cumplir controles de acceso en la ejecución de herramientas.
- **Control de Acceso Basado en Roles**: Uso de roles para controlar el acceso a herramientas y recursos específicos.
- **Anotaciones de Seguridad**: Uso de anotaciones para proteger métodos y endpoints.

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

En el código anterior, hemos:

- Configurado Spring Security para proteger los endpoints MCP, permitiendo acceso público al descubrimiento de herramientas y requiriendo autenticación para la ejecución de herramientas.
- Usado OAuth2 como servidor de recursos para manejar el acceso seguro a herramientas MCP.
- Implementado un interceptor de seguridad para hacer cumplir controles de acceso en la ejecución de herramientas, verificando roles y permisos del usuario antes de permitir acceso a herramientas específicas.
- Definido control de acceso basado en roles para restringir el acceso a herramientas administrativas y acceso a datos sensibles según los roles de usuario.

## Protección de Datos y Privacidad

La protección de datos es crucial para asegurar que la información sensible se maneje de forma segura. Esto incluye proteger información personal identificable (PII), datos financieros y otra información sensible contra accesos no autorizados y filtraciones.

### Ejemplo de Protección de Datos en Python

Veamos un ejemplo de cómo implementar protección de datos en Python usando cifrado y detección de PII.

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

En el código anterior, hemos:

- Implementado una clase `PiiDetector` para escanear texto y parámetros en busca de información personal identificable (PII).
- Creado una clase `EncryptionService` para manejar el cifrado y descifrado de datos sensibles usando la librería `cryptography`.
- Definido un decorador `secure_tool` que envuelve la ejecución de herramientas para verificar PII, registrar accesos y cifrar datos sensibles si es necesario.
- Aplicado el decorador `secure_tool` a una herramienta de ejemplo (`SecureCustomerDataTool`) para asegurar que maneje datos sensibles de forma segura.

## Qué sigue

- [5.9 Web search](../web-search-mcp/README.md)

**Aviso legal**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda la traducción profesional realizada por humanos. No nos hacemos responsables de malentendidos o interpretaciones erróneas derivadas del uso de esta traducción.