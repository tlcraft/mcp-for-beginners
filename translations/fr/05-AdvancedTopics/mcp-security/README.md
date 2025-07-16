<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e363328861e6e00258187f731a773411",
  "translation_date": "2025-07-16T21:24:42+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "fr"
}
-->
# Meilleures pratiques de sécurité

La sécurité est essentielle pour les implémentations MCP, en particulier dans les environnements d'entreprise. Il est important de garantir que les outils et les données sont protégés contre les accès non autorisés, les fuites de données et autres menaces de sécurité.

## Introduction

Le Model Context Protocol (MCP) nécessite des considérations spécifiques en matière de sécurité en raison de son rôle dans l’accès des LLM aux données et aux outils. Cette leçon explore les meilleures pratiques de sécurité pour les implémentations MCP, basées sur les directives officielles du MCP et les modèles de sécurité établis.

MCP suit des principes clés de sécurité pour assurer des interactions sûres et fiables :

- **Consentement et contrôle utilisateur** : Les utilisateurs doivent donner un consentement explicite avant que toute donnée soit consultée ou qu’une opération soit effectuée. Offrez un contrôle clair sur les données partagées et les actions autorisées.
  
- **Confidentialité des données** : Les données utilisateur ne doivent être exposées qu’avec un consentement explicite et doivent être protégées par des contrôles d’accès appropriés. Protégez contre toute transmission non autorisée des données.
  
- **Sécurité des outils** : Avant d’invoquer un outil, un consentement explicite de l’utilisateur est requis. Les utilisateurs doivent comprendre clairement la fonctionnalité de chaque outil, et des limites de sécurité robustes doivent être appliquées.

## Objectifs d’apprentissage

À la fin de cette leçon, vous serez capable de :

- Mettre en œuvre des mécanismes d’authentification et d’autorisation sécurisés pour les serveurs MCP.
- Protéger les données sensibles grâce au chiffrement et au stockage sécurisé.
- Assurer l’exécution sécurisée des outils avec des contrôles d’accès appropriés.
- Appliquer les meilleures pratiques pour la protection des données et la conformité à la vie privée.
- Identifier et atténuer les vulnérabilités courantes de sécurité MCP telles que les problèmes de confused deputy, le token passthrough et le détournement de session.

## Authentification et autorisation

L’authentification et l’autorisation sont essentielles pour sécuriser les serveurs MCP. L’authentification répond à la question « Qui êtes-vous ? » tandis que l’autorisation répond à « Que pouvez-vous faire ? ».

Selon la spécification de sécurité MCP, voici les points critiques à considérer :

1. **Validation des tokens** : Les serveurs MCP NE DOIVENT PAS accepter de tokens qui n’ont pas été explicitement émis pour le serveur MCP. Le « token passthrough » est un anti-pattern formellement interdit.

2. **Vérification de l’autorisation** : Les serveurs MCP qui implémentent l’autorisation DOIVENT vérifier toutes les requêtes entrantes et NE DOIVENT PAS utiliser les sessions pour l’authentification.

3. **Gestion sécurisée des sessions** : Lorsqu’ils utilisent des sessions pour l’état, les serveurs MCP DOIVENT utiliser des identifiants de session sécurisés, non déterministes, générés avec des générateurs de nombres aléatoires sécurisés. Les identifiants de session DEVRAIENT être liés à des informations spécifiques à l’utilisateur.

4. **Consentement explicite de l’utilisateur** : Pour les serveurs proxy, les implémentations MCP DOIVENT obtenir le consentement de l’utilisateur pour chaque client enregistré dynamiquement avant de transmettre aux serveurs d’autorisation tiers.

Voyons des exemples d’implémentation d’authentification et d’autorisation sécurisées dans des serveurs MCP avec .NET et Java.

### Intégration .NET Identity

ASP .NET Core Identity offre un cadre robuste pour gérer l’authentification et l’autorisation des utilisateurs. Nous pouvons l’intégrer aux serveurs MCP pour sécuriser l’accès aux outils et ressources.

Voici quelques concepts clés à comprendre lors de l’intégration d’ASP.NET Core Identity avec les serveurs MCP :

- **Configuration d’Identity** : Mise en place d’ASP.NET Core Identity avec les rôles et revendications des utilisateurs. Une revendication est une information sur l’utilisateur, comme son rôle ou ses permissions, par exemple « Admin » ou « User ».
- **Authentification JWT** : Utilisation des JSON Web Tokens (JWT) pour un accès API sécurisé. Le JWT est une norme pour transmettre des informations de manière sécurisée entre parties sous forme d’objet JSON, vérifiable et fiable car signé numériquement.
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
- Mis en place l’authentification JWT pour un accès API sécurisé. Nous avons spécifié les paramètres de validation du token, incluant l’émetteur, le public et la clé de signature.
- Défini des politiques d’autorisation pour contrôler l’accès aux outils selon les rôles des utilisateurs. Par exemple, la politique « CanUseAdminTools » exige que l’utilisateur ait le rôle « Admin », tandis que la politique « CanUseBasic » requiert que l’utilisateur soit authentifié.
- Enregistré les outils MCP avec des exigences d’autorisation spécifiques, garantissant que seuls les utilisateurs avec les rôles appropriés peuvent y accéder.

### Intégration Java Spring Security

Pour Java, nous utiliserons Spring Security pour implémenter une authentification et une autorisation sécurisées pour les serveurs MCP. Spring Security fournit un cadre de sécurité complet qui s’intègre parfaitement aux applications Spring.

Les concepts clés sont :

- **Configuration Spring Security** : Mise en place des configurations de sécurité pour l’authentification et l’autorisation.
- **OAuth2 Resource Server** : Utilisation d’OAuth2 pour un accès sécurisé aux outils MCP. OAuth2 est un cadre d’autorisation permettant aux services tiers d’échanger des tokens d’accès pour un accès API sécurisé.
- **Intercepteurs de sécurité** : Implémentation d’intercepteurs pour appliquer les contrôles d’accès lors de l’exécution des outils.
- **Contrôle d’accès basé sur les rôles** : Utilisation des rôles pour contrôler l’accès à des outils et ressources spécifiques.
- **Annotations de sécurité** : Utilisation d’annotations pour sécuriser les méthodes et points d’entrée.

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

- Configuré Spring Security pour sécuriser les points d’accès MCP, permettant un accès public à la découverte des outils tout en exigeant une authentification pour leur exécution.
- Utilisé OAuth2 en tant que serveur de ressources pour gérer l’accès sécurisé aux outils MCP.
- Implémenté un intercepteur de sécurité pour appliquer les contrôles d’accès lors de l’exécution des outils, vérifiant les rôles et permissions des utilisateurs avant d’autoriser l’accès à des outils spécifiques.
- Défini un contrôle d’accès basé sur les rôles pour restreindre l’accès aux outils d’administration et aux données sensibles selon les rôles des utilisateurs.

## Protection des données et confidentialité

La protection des données est cruciale pour garantir que les informations sensibles sont traitées de manière sécurisée. Cela inclut la protection des informations personnelles identifiables (PII), des données financières et autres informations sensibles contre les accès non autorisés et les fuites.

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

- Implémenté une classe `PiiDetector` pour analyser les textes et paramètres à la recherche d’informations personnelles identifiables (PII).
- Créé une classe `EncryptionService` pour gérer le chiffrement et le déchiffrement des données sensibles en utilisant la bibliothèque `cryptography`.
- Défini un décorateur `secure_tool` qui enveloppe l’exécution des outils pour vérifier la présence de PII, enregistrer les accès et chiffrer les données sensibles si nécessaire.
- Appliqué le décorateur `secure_tool` à un outil d’exemple (`SecureCustomerDataTool`) pour garantir qu’il traite les données sensibles de manière sécurisée.

## Risques de sécurité spécifiques au MCP

Selon la documentation officielle de sécurité MCP, il existe des risques spécifiques que les implémenteurs MCP doivent connaître :

### 1. Problème de confused deputy

Cette vulnérabilité survient lorsqu’un serveur MCP agit comme proxy vers des API tierces, permettant potentiellement à des attaquants d’exploiter la relation de confiance entre le serveur MCP et ces API.

**Atténuation :**
- Les serveurs proxy MCP utilisant des IDs clients statiques DOIVENT obtenir le consentement de l’utilisateur pour chaque client enregistré dynamiquement avant de transmettre aux serveurs d’autorisation tiers.
- Implémenter un flux OAuth correct avec PKCE (Proof Key for Code Exchange) pour les requêtes d’autorisation.
- Valider strictement les URI de redirection et les identifiants clients.

### 2. Vulnérabilités de token passthrough

Le token passthrough se produit lorsqu’un serveur MCP accepte des tokens d’un client MCP sans valider que ces tokens ont été correctement émis pour le serveur MCP, puis les transmet aux API en aval.

### Risques
- Contournement des contrôles de sécurité (bypass des limites de taux, validation des requêtes)
- Problèmes de responsabilité et de traçabilité
- Violation des frontières de confiance
- Risques de compatibilité future

**Atténuation :**
- Les serveurs MCP NE DOIVENT PAS accepter de tokens qui n’ont pas été explicitement émis pour le serveur MCP.
- Toujours valider les revendications d’audience des tokens pour s’assurer qu’elles correspondent au service attendu.

### 3. Détournement de session

Cela se produit lorsqu’une partie non autorisée obtient un identifiant de session et l’utilise pour usurper l’identité du client original, pouvant entraîner des actions non autorisées.

**Atténuation :**
- Les serveurs MCP qui implémentent l’autorisation DOIVENT vérifier toutes les requêtes entrantes et NE DOIVENT PAS utiliser les sessions pour l’authentification.
- Utiliser des identifiants de session sécurisés, non déterministes, générés avec des générateurs de nombres aléatoires sécurisés.
- Lier les identifiants de session à des informations spécifiques à l’utilisateur avec un format de clé comme `<user_id>:<session_id>`.
- Mettre en place des politiques appropriées d’expiration et de rotation des sessions.

## Autres bonnes pratiques de sécurité pour MCP

Au-delà des considérations de sécurité de base du MCP, envisagez d’appliquer ces pratiques supplémentaires :

- **Toujours utiliser HTTPS** : Chiffrez la communication entre client et serveur pour protéger les tokens contre l’interception.
- **Mettre en œuvre un contrôle d’accès basé sur les rôles (RBAC)** : Ne vous contentez pas de vérifier si un utilisateur est authentifié ; vérifiez ce qu’il est autorisé à faire.
- **Surveiller et auditer** : Enregistrez tous les événements d’authentification pour détecter et réagir aux activités suspectes.
- **Gérer la limitation de débit et le throttling** : Implémentez des mécanismes de backoff exponentiel et de retry pour gérer les limites de taux de manière élégante.
- **Stockage sécurisé des tokens** : Stockez les tokens d’accès et de rafraîchissement de manière sécurisée en utilisant les mécanismes de stockage sécurisé du système ou des services de gestion de clés sécurisés.
- **Envisager l’utilisation d’une gestion d’API** : Des services comme Azure API Management peuvent gérer automatiquement de nombreuses préoccupations de sécurité, y compris l’authentification, l’autorisation et la limitation de débit.

## Références

- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [MCP Core Concepts](https://modelcontextprotocol.io/docs/concepts/architecture)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)

## Et ensuite

- [5.9 Web search](../web-search-mcp/README.md)

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.