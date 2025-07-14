<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-07-14T02:38:22+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "pa"
}
-->
# ਸੁਰੱਖਿਆ ਲਈ ਵਧੀਆ ਅਭਿਆਸ

MCP ਇੰਪਲੀਮੈਂਟੇਸ਼ਨਾਂ ਲਈ ਸੁਰੱਖਿਆ ਬਹੁਤ ਜਰੂਰੀ ਹੈ, ਖਾਸ ਕਰਕੇ ਉਦਯੋਗਿਕ ਮਾਹੌਲ ਵਿੱਚ। ਇਹ ਯਕੀਨੀ ਬਣਾਉਣਾ ਮਹੱਤਵਪੂਰਨ ਹੈ ਕਿ ਟੂਲਾਂ ਅਤੇ ਡਾਟਾ ਨੂੰ ਬਿਨਾਂ ਅਧਿਕਾਰ ਦੇ ਪਹੁੰਚ, ਡਾਟਾ ਚੋਰੀ ਅਤੇ ਹੋਰ ਸੁਰੱਖਿਆ ਖਤਰਿਆਂ ਤੋਂ ਬਚਾਇਆ ਜਾਵੇ।

## ਪਰਿਚਯ

ਇਸ ਪਾਠ ਵਿੱਚ, ਅਸੀਂ MCP ਇੰਪਲੀਮੈਂਟੇਸ਼ਨਾਂ ਲਈ ਸੁਰੱਖਿਆ ਦੇ ਵਧੀਆ ਅਭਿਆਸਾਂ ਬਾਰੇ ਜਾਣੂ ਹੋਵਾਂਗੇ। ਅਸੀਂ ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ, ਡਾਟਾ ਸੁਰੱਖਿਆ, ਸੁਰੱਖਿਅਤ ਟੂਲ ਚਲਾਉਣਾ, ਅਤੇ ਡਾਟਾ ਪ੍ਰਾਈਵੇਸੀ ਨਿਯਮਾਂ ਦੀ ਪਾਲਣਾ ਬਾਰੇ ਚਰਚਾ ਕਰਾਂਗੇ।

## ਸਿੱਖਣ ਦੇ ਲਕੜੀ

ਇਸ ਪਾਠ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਸਮਰੱਥ ਹੋਵੋਗੇ:

- MCP ਸਰਵਰਾਂ ਲਈ ਸੁਰੱਖਿਅਤ ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ ਮਕੈਨਿਜ਼ਮ ਲਾਗੂ ਕਰਨ।
- ਸੰਵੇਦਨਸ਼ੀਲ ਡਾਟਾ ਨੂੰ ਇਨਕ੍ਰਿਪਸ਼ਨ ਅਤੇ ਸੁਰੱਖਿਅਤ ਸਟੋਰੇਜ ਨਾਲ ਬਚਾਉਣ।
- ਸਹੀ ਪਹੁੰਚ ਨਿਯੰਤਰਣ ਨਾਲ ਟੂਲਾਂ ਦੀ ਸੁਰੱਖਿਅਤ ਚਲਾਉਣ ਨੂੰ ਯਕੀਨੀ ਬਣਾਉਣ।
- ਡਾਟਾ ਸੁਰੱਖਿਆ ਅਤੇ ਪ੍ਰਾਈਵੇਸੀ ਪਾਲਣਾ ਲਈ ਵਧੀਆ ਅਭਿਆਸ ਲਾਗੂ ਕਰਨ।

## ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ

ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ MCP ਸਰਵਰਾਂ ਦੀ ਸੁਰੱਖਿਆ ਲਈ ਬਹੁਤ ਜਰੂਰੀ ਹਨ। ਪ੍ਰਮਾਣਿਕਤਾ ਸਵਾਲ ਦਾ ਜਵਾਬ ਦਿੰਦੀ ਹੈ "ਤੁਸੀਂ ਕੌਣ ਹੋ?" ਜਦਕਿ ਅਧਿਕਾਰ ਸਵਾਲ ਦਾ ਜਵਾਬ ਦਿੰਦੀ ਹੈ "ਤੁਸੀਂ ਕੀ ਕਰ ਸਕਦੇ ਹੋ?".

ਆਓ ਵੇਖੀਏ ਕਿ .NET ਅਤੇ ਜਾਵਾ ਦੀ ਵਰਤੋਂ ਕਰਕੇ MCP ਸਰਵਰਾਂ ਵਿੱਚ ਸੁਰੱਖਿਅਤ ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ ਕਿਵੇਂ ਲਾਗੂ ਕੀਤੇ ਜਾ ਸਕਦੇ ਹਨ।

### .NET Identity ਇੰਟੀਗ੍ਰੇਸ਼ਨ

ASP .NET Core Identity ਉਪਭੋਗਤਾ ਦੀ ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ ਪ੍ਰਬੰਧਨ ਲਈ ਇੱਕ ਮਜ਼ਬੂਤ ਫਰੇਮਵਰਕ ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ। ਅਸੀਂ ਇਸਨੂੰ MCP ਸਰਵਰਾਂ ਨਾਲ ਜੋੜ ਕੇ ਟੂਲਾਂ ਅਤੇ ਸਰੋਤਾਂ ਦੀ ਪਹੁੰਚ ਸੁਰੱਖਿਅਤ ਕਰ ਸਕਦੇ ਹਾਂ।

ASP.NET Core Identity ਨੂੰ MCP ਸਰਵਰਾਂ ਨਾਲ ਜੋੜਦੇ ਸਮੇਂ ਕੁਝ ਮੁੱਖ ਧਾਰਣਾਵਾਂ ਨੂੰ ਸਮਝਣਾ ਜਰੂਰੀ ਹੈ:

- **Identity Configuration**: ASP.NET Core Identity ਨੂੰ ਉਪਭੋਗਤਾ ਭੂਮਿਕਾਵਾਂ ਅਤੇ ਦਾਅਵਿਆਂ ਨਾਲ ਸੈੱਟ ਕਰਨਾ। ਦਾਅਵਾ ਉਪਭੋਗਤਾ ਬਾਰੇ ਜਾਣਕਾਰੀ ਦਾ ਇੱਕ ਹਿੱਸਾ ਹੁੰਦਾ ਹੈ, ਜਿਵੇਂ ਕਿ ਉਹਨਾਂ ਦੀ ਭੂਮਿਕਾ ਜਾਂ ਅਧਿਕਾਰ, ਉਦਾਹਰਨ ਲਈ "Admin" ਜਾਂ "User"।
- **JWT Authentication**: ਸੁਰੱਖਿਅਤ API ਪਹੁੰਚ ਲਈ JSON Web Tokens (JWT) ਦੀ ਵਰਤੋਂ। JWT ਇੱਕ ਮਿਆਰੀ ਤਰੀਕਾ ਹੈ ਜੋ ਪਾਰਟੀਆਂ ਵਿਚਕਾਰ ਜਾਣਕਾਰੀ ਨੂੰ JSON ਆਬਜੈਕਟ ਵਜੋਂ ਸੁਰੱਖਿਅਤ ਤਰੀਕੇ ਨਾਲ ਭੇਜਦਾ ਹੈ, ਜਿਸ ਨੂੰ ਡਿਜੀਟਲ ਤੌਰ 'ਤੇ ਸਾਈਨ ਕੀਤਾ ਜਾਂਦਾ ਹੈ ਅਤੇ ਇਸ ਲਈ ਭਰੋਸੇਯੋਗ ਹੁੰਦਾ ਹੈ।
- **Authorization Policies**: ਉਪਭੋਗਤਾ ਭੂਮਿਕਾਵਾਂ ਦੇ ਆਧਾਰ 'ਤੇ ਖਾਸ ਟੂਲਾਂ ਦੀ ਪਹੁੰਚ ਨੂੰ ਨਿਯੰਤਰਿਤ ਕਰਨ ਲਈ ਨੀਤੀਆਂ ਤੈਅ ਕਰਨਾ। MCP ਅਧਿਕਾਰ ਨੀਤੀਆਂ ਦੀ ਵਰਤੋਂ ਕਰਦਾ ਹੈ ਇਹ ਨਿਰਧਾਰਿਤ ਕਰਨ ਲਈ ਕਿ ਕਿਹੜੇ ਉਪਭੋਗਤਾ ਕਿਹੜੇ ਟੂਲਾਂ ਤੱਕ ਪਹੁੰਚ ਸਕਦੇ ਹਨ।

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

ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ, ਅਸੀਂ:

- ਉਪਭੋਗਤਾ ਪ੍ਰਬੰਧਨ ਲਈ ASP.NET Core Identity ਨੂੰ ਸੰਰਚਿਤ ਕੀਤਾ ਹੈ।
- ਸੁਰੱਖਿਅਤ API ਪਹੁੰਚ ਲਈ JWT ਪ੍ਰਮਾਣਿਕਤਾ ਸੈੱਟ ਕੀਤੀ ਹੈ। ਅਸੀਂ ਟੋਕਨ ਵੈਰੀਫਿਕੇਸ਼ਨ ਪੈਰਾਮੀਟਰ, ਜਿਵੇਂ ਕਿ issuer, audience, ਅਤੇ ਸਾਈਨਿੰਗ ਕੀ, ਨਿਰਧਾਰਿਤ ਕੀਤੇ ਹਨ।
- ਉਪਭੋਗਤਾ ਭੂਮਿਕਾਵਾਂ ਦੇ ਆਧਾਰ 'ਤੇ ਟੂਲਾਂ ਦੀ ਪਹੁੰਚ ਨੂੰ ਨਿਯੰਤਰਿਤ ਕਰਨ ਲਈ ਅਧਿਕਾਰ ਨੀਤੀਆਂ ਤੈਅ ਕੀਤੀਆਂ ਹਨ। ਉਦਾਹਰਨ ਵਜੋਂ, "CanUseAdminTools" ਨੀਤੀ ਲਈ ਉਪਭੋਗਤਾ ਕੋਲ "Admin" ਭੂਮਿਕਾ ਹੋਣੀ ਲਾਜ਼ਮੀ ਹੈ, ਜਦਕਿ "CanUseBasic" ਨੀਤੀ ਲਈ ਉਪਭੋਗਤਾ ਦਾ ਪ੍ਰਮਾਣਿਤ ਹੋਣਾ ਜਰੂਰੀ ਹੈ।
- MCP ਟੂਲਾਂ ਨੂੰ ਖਾਸ ਅਧਿਕਾਰ ਲੋੜਾਂ ਨਾਲ ਰਜਿਸਟਰ ਕੀਤਾ ਹੈ, ਇਹ ਯਕੀਨੀ ਬਣਾਉਂਦੇ ਹੋਏ ਕਿ ਸਿਰਫ਼ ਉਹੀ ਉਪਭੋਗਤਾ ਜਿਨ੍ਹਾਂ ਕੋਲ ਸਹੀ ਭੂਮਿਕਾਵਾਂ ਹਨ, ਉਹਨਾਂ ਨੂੰ ਪਹੁੰਚ ਮਿਲੇ।

### ਜਾਵਾ ਸਪ੍ਰਿੰਗ ਸੁਰੱਖਿਆ ਇੰਟੀਗ੍ਰੇਸ਼ਨ

ਜਾਵਾ ਲਈ, ਅਸੀਂ MCP ਸਰਵਰਾਂ ਲਈ ਸੁਰੱਖਿਅਤ ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ ਲਾਗੂ ਕਰਨ ਲਈ Spring Security ਦੀ ਵਰਤੋਂ ਕਰਾਂਗੇ। Spring Security ਇੱਕ ਵਿਸਤ੍ਰਿਤ ਸੁਰੱਖਿਆ ਫਰੇਮਵਰਕ ਹੈ ਜੋ Spring ਐਪਲੀਕੇਸ਼ਨਾਂ ਨਾਲ ਬਿਨਾਂ ਕਿਸੇ ਰੁਕਾਵਟ ਦੇ ਜੁੜਦਾ ਹੈ।

ਇੱਥੇ ਮੁੱਖ ਧਾਰਣਾਵਾਂ ਹਨ:

- **Spring Security Configuration**: ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ ਲਈ ਸੁਰੱਖਿਆ ਸੰਰਚਨਾਵਾਂ ਸੈੱਟ ਕਰਨਾ।
- **OAuth2 Resource Server**: MCP ਟੂਲਾਂ ਲਈ ਸੁਰੱਖਿਅਤ ਪਹੁੰਚ ਲਈ OAuth2 ਦੀ ਵਰਤੋਂ। OAuth2 ਇੱਕ ਅਧਿਕਾਰ ਫਰੇਮਵਰਕ ਹੈ ਜੋ ਤੀਜੀ ਪੱਖ ਦੀਆਂ ਸੇਵਾਵਾਂ ਨੂੰ ਸੁਰੱਖਿਅਤ API ਪਹੁੰਚ ਲਈ ਟੋਕਨ ਬਦਲਣ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ।
- **Security Interceptors**: ਟੂਲ ਚਲਾਉਣ 'ਤੇ ਪਹੁੰਚ ਨਿਯੰਤਰਣ ਲਾਗੂ ਕਰਨ ਲਈ ਸੁਰੱਖਿਆ ਇੰਟਰਸੈਪਟਰ ਲਾਗੂ ਕਰਨਾ।
- **Role-Based Access Control**: ਖਾਸ ਟੂਲਾਂ ਅਤੇ ਸਰੋਤਾਂ ਲਈ ਭੂਮਿਕਾਵਾਂ ਦੇ ਆਧਾਰ 'ਤੇ ਪਹੁੰਚ ਨਿਯੰਤਰਿਤ ਕਰਨਾ।
- **Security Annotations**: ਮੈਥਡਾਂ ਅਤੇ ਐਂਡਪੌਇੰਟਾਂ ਨੂੰ ਸੁਰੱਖਿਅਤ ਕਰਨ ਲਈ ਐਨੋਟੇਸ਼ਨਾਂ ਦੀ ਵਰਤੋਂ।

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

ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ, ਅਸੀਂ:

- MCP ਐਂਡਪੌਇੰਟਾਂ ਨੂੰ ਸੁਰੱਖਿਅਤ ਕਰਨ ਲਈ Spring Security ਨੂੰ ਸੰਰਚਿਤ ਕੀਤਾ ਹੈ, ਟੂਲ ਖੋਜ ਲਈ ਜਨਤਕ ਪਹੁੰਚ ਦੀ ਆਗਿਆ ਦਿੰਦੇ ਹੋਏ ਟੂਲ ਚਲਾਉਣ ਲਈ ਪ੍ਰਮਾਣਿਕਤਾ ਲਾਜ਼ਮੀ ਬਣਾਈ ਹੈ।
- MCP ਟੂਲਾਂ ਲਈ ਸੁਰੱਖਿਅਤ ਪਹੁੰਚ ਸੰਭਾਲਣ ਲਈ OAuth2 ਨੂੰ ਰਿਸੋਰਸ ਸਰਵਰ ਵਜੋਂ ਵਰਤਿਆ ਹੈ।
- ਟੂਲ ਚਲਾਉਣ 'ਤੇ ਪਹੁੰਚ ਨਿਯੰਤਰਣ ਲਾਗੂ ਕਰਨ ਲਈ ਸੁਰੱਖਿਆ ਇੰਟਰਸੈਪਟਰ ਲਾਗੂ ਕੀਤਾ ਹੈ, ਜੋ ਖਾਸ ਟੂਲਾਂ ਲਈ ਪਹੁੰਚ ਦੇਣ ਤੋਂ ਪਹਿਲਾਂ ਉਪਭੋਗਤਾ ਦੀ ਭੂਮਿਕਾ ਅਤੇ ਅਧਿਕਾਰਾਂ ਦੀ ਜਾਂਚ ਕਰਦਾ ਹੈ।
- ਉਪਭੋਗਤਾ ਭੂਮਿਕਾਵਾਂ ਦੇ ਆਧਾਰ 'ਤੇ ਐਡਮਿਨ ਟੂਲਾਂ ਅਤੇ ਸੰਵੇਦਨਸ਼ੀਲ ਡਾਟਾ ਪਹੁੰਚ ਨੂੰ ਸੀਮਿਤ ਕਰਨ ਲਈ ਭੂਮਿਕਾ-ਆਧਾਰਿਤ ਪਹੁੰਚ ਨਿਯੰਤਰਣ ਤੈਅ ਕੀਤਾ ਹੈ।

## ਡਾਟਾ ਸੁਰੱਖਿਆ ਅਤੇ ਪ੍ਰਾਈਵੇਸੀ

ਡਾਟਾ ਸੁਰੱਖਿਆ ਇਹ ਯਕੀਨੀ ਬਣਾਉਣ ਲਈ ਬਹੁਤ ਜਰੂਰੀ ਹੈ ਕਿ ਸੰਵੇਦਨਸ਼ੀਲ ਜਾਣਕਾਰੀ ਨੂੰ ਸੁਰੱਖਿਅਤ ਤਰੀਕੇ ਨਾਲ ਸੰਭਾਲਿਆ ਜਾਵੇ। ਇਸ ਵਿੱਚ ਨਿੱਜੀ ਪਛਾਣਯੋਗ ਜਾਣਕਾਰੀ (PII), ਵਿੱਤੀ ਡਾਟਾ, ਅਤੇ ਹੋਰ ਸੰਵੇਦਨਸ਼ੀਲ ਜਾਣਕਾਰੀ ਨੂੰ ਬਿਨਾਂ ਅਧਿਕਾਰ ਦੇ ਪਹੁੰਚ ਅਤੇ ਚੋਰੀ ਤੋਂ ਬਚਾਉਣਾ ਸ਼ਾਮਲ ਹੈ।

### Python ਡਾਟਾ ਸੁਰੱਖਿਆ ਉਦਾਹਰਨ

ਆਓ ਵੇਖੀਏ ਕਿ Python ਵਿੱਚ ਇਨਕ੍ਰਿਪਸ਼ਨ ਅਤੇ PII ਪਛਾਣ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਡਾਟਾ ਸੁਰੱਖਿਆ ਕਿਵੇਂ ਲਾਗੂ ਕੀਤੀ ਜਾ ਸਕਦੀ ਹੈ।

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

ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ, ਅਸੀਂ:

- `PiiDetector` ਕਲਾਸ ਲਿਖੀ ਹੈ ਜੋ ਟੈਕਸਟ ਅਤੇ ਪੈਰਾਮੀਟਰਾਂ ਵਿੱਚ ਨਿੱਜੀ ਪਛਾਣਯੋਗ ਜਾਣਕਾਰੀ (PII) ਦੀ ਸਕੈਨਿੰਗ ਕਰਦੀ ਹੈ।
- `EncryptionService` ਕਲਾਸ ਬਣਾਈ ਹੈ ਜੋ `cryptography` ਲਾਇਬ੍ਰੇਰੀ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਸੰਵੇਦਨਸ਼ੀਲ ਡਾਟਾ ਦੀ ਇਨਕ੍ਰਿਪਸ਼ਨ ਅਤੇ ਡੀਕ੍ਰਿਪਸ਼ਨ ਸੰਭਾਲਦੀ ਹੈ।
- `secure_tool` ਡੈਕੋਰੇਟਰ ਤਿਆਰ ਕੀਤਾ ਹੈ ਜੋ ਟੂਲ ਚਲਾਉਣ ਨੂੰ ਲਪੇਟਦਾ ਹੈ, PII ਦੀ ਜਾਂਚ ਕਰਦਾ ਹੈ, ਪਹੁੰਚ ਲਾਗ ਕਰਦਾ ਹੈ, ਅਤੇ ਜਰੂਰਤ ਪੈਣ 'ਤੇ ਸੰਵੇਦਨਸ਼ੀਲ ਡਾਟਾ ਨੂੰ ਇਨਕ੍ਰਿਪਟ ਕਰਦਾ ਹੈ।
- `secure_tool` ਡੈਕੋਰੇਟਰ ਨੂੰ ਇੱਕ ਨਮੂਨਾ ਟੂਲ (`SecureCustomerDataTool`) 'ਤੇ ਲਾਗੂ ਕੀਤਾ ਹੈ ਤਾਂ ਜੋ ਇਹ ਯਕੀਨੀ ਬਣਾਇਆ ਜਾ ਸਕੇ ਕਿ ਇਹ ਸੰਵੇਦਨਸ਼ੀਲ ਡਾਟਾ ਨੂੰ ਸੁਰੱਖਿਅਤ ਤਰੀਕੇ ਨਾਲ ਸੰਭਾਲਦਾ ਹੈ।

## ਅਗਲਾ ਕੀ ਹੈ

- [5.9 Web search](../web-search-mcp/README.md)

**ਅਸਵੀਕਾਰੋਪਣ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਮਰਥਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉਤਪੰਨ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।