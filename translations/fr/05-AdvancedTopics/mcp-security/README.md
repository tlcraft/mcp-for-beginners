<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-06-12T21:33:00+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "fr"
}
-->
# Meilleures pratiques de sécurité

La sécurité est essentielle pour les implémentations MCP, surtout dans les environnements d'entreprise. Il est important de garantir que les outils et les données soient protégés contre les accès non autorisés, les fuites de données et autres menaces de sécurité.

## Introduction

Dans cette leçon, nous allons explorer les meilleures pratiques de sécurité pour les implémentations MCP. Nous aborderons l’authentification et l’autorisation, la protection des données, l’exécution sécurisée des outils, ainsi que la conformité aux réglementations sur la confidentialité des données.

## Objectifs d’apprentissage

À la fin de cette leçon, vous serez capable de :

- Mettre en place des mécanismes d’authentification et d’autorisation sécurisés pour les serveurs MCP.
- Protéger les données sensibles grâce au chiffrement et au stockage sécurisé.
- Assurer l’exécution sécurisée des outils avec des contrôles d’accès appropriés.
- Appliquer les meilleures pratiques pour la protection des données et la conformité à la vie privée.

## Authentification et autorisation

L’authentification et l’autorisation sont indispensables pour sécuriser les serveurs MCP. L’authentification répond à la question « Qui êtes-vous ? », tandis que l’autorisation répond à « Que pouvez-vous faire ? ».

Voyons des exemples d’implémentation d’authentification et d’autorisation sécurisées dans les serveurs MCP en utilisant .NET et Java.

### Intégration .NET Identity

ASP .NET Core Identity offre un cadre solide pour gérer l’authentification et l’autorisation des utilisateurs. Nous pouvons l’intégrer aux serveurs MCP pour sécuriser l’accès aux outils et ressources.

Voici quelques concepts clés à comprendre lors de l’intégration d’ASP.NET Core Identity avec les serveurs MCP :

- **Configuration de l’identité** : Mise en place d’ASP.NET Core Identity avec les rôles et revendications des utilisateurs. Une revendication est une information concernant l’utilisateur, comme son rôle ou ses permissions, par exemple « Admin » ou « User ».
- **Authentification JWT** : Utilisation des JSON Web Tokens (JWT) pour un accès API sécurisé. Le JWT est une norme permettant de transmettre des informations de manière sécurisée entre deux parties sous forme d’objet JSON, vérifiable et fiable grâce à une signature numérique.
- **Politiques d’autorisation** : Définition de politiques pour contrôler l’accès à des outils spécifiques selon les rôles des utilisateurs. MCP utilise ces politiques pour déterminer quels utilisateurs peuvent accéder à quels outils en fonction de leurs rôles et revendications.

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

Dans le code précédent, nous avons :

- Configuré ASP.NET Core Identity pour la gestion des utilisateurs.
- Mis en place l’authentification JWT pour un accès API sécurisé, en spécifiant les paramètres de validation du token, notamment l’émetteur, le public et la clé de signature.
- Défini des politiques d’autorisation pour contrôler l’accès aux outils selon les rôles des utilisateurs. Par exemple, la politique « CanUseAdminTools » requiert que l’utilisateur ait le rôle « Admin », tandis que la politique « CanUseBasic » exige que l’utilisateur soit authentifié.
- Enregistré les outils MCP avec des exigences d’autorisation spécifiques, garantissant que seuls les utilisateurs avec les rôles appropriés peuvent y accéder.

### Intégration Java Spring Security

Pour Java, nous utiliserons Spring Security pour implémenter une authentification et une autorisation sécurisées pour les serveurs MCP. Spring Security fournit un cadre de sécurité complet qui s’intègre parfaitement aux applications Spring.

Les concepts clés ici sont :

- **Configuration de Spring Security** : Mise en place des configurations de sécurité pour l’authentification et l’autorisation.
- **OAuth2 Resource Server** : Utilisation d’OAuth2 pour un accès sécurisé aux outils MCP. OAuth2 est un cadre d’autorisation permettant aux services tiers d’échanger des jetons d’accès pour un accès API sécurisé.
- **Intercepteurs de sécurité** : Implémentation d’intercepteurs de sécurité pour appliquer les contrôles d’accès à l’exécution des outils.
- **Contrôle d’accès basé sur les rôles** : Utilisation des rôles pour contrôler l’accès aux outils et ressources spécifiques.
- **Annotations de sécurité** : Utilisation d’annotations pour sécuriser les méthodes et points d’accès.

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

Dans le code précédent, nous avons :

- Configuré Spring Security pour sécuriser les points d’accès MCP, en permettant un accès public à la découverte des outils tout en exigeant une authentification pour l’exécution des outils.
- Utilisé OAuth2 en tant que resource server pour gérer l’accès sécurisé aux outils MCP.
- Implémenté un intercepteur de sécurité pour appliquer les contrôles d’accès à l’exécution des outils, vérifiant les rôles et permissions des utilisateurs avant d’autoriser l’accès à des outils spécifiques.
- Défini un contrôle d’accès basé sur les rôles pour restreindre l’accès aux outils d’administration et aux données sensibles selon les rôles des utilisateurs.

## Protection des données et confidentialité

La protection des données est cruciale pour garantir que les informations sensibles soient traitées de manière sécurisée. Cela inclut la protection des informations personnelles identifiables (PII), des données financières et d’autres informations sensibles contre les accès non autorisés et les fuites.

### Exemple de protection des données en Python

Voyons un exemple d’implémentation de la protection des données en Python utilisant le chiffrement et la détection de PII.

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

Dans le code précédent, nous avons :

- Implémenté un `PiiDetector` class to scan text and parameters for personally identifiable information (PII).
- Created an `EncryptionService` class to handle encryption and decryption of sensitive data using the `cryptography` library.
- Defined a `secure_tool` decorator that wraps tool execution to check for PII, log access, and encrypt sensitive data if required.
- Applied the `secure_tool` decorator to a sample tool (`SecureCustomerDataTool`) pour garantir qu’il gère les données sensibles de manière sécurisée.

## Et ensuite

- [5.9 Web search](../web-search-mcp/README.md)

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, il est recommandé de recourir à une traduction professionnelle réalisée par un humain. Nous ne saurions être tenus responsables de tout malentendu ou mauvaise interprétation résultant de l’utilisation de cette traduction.