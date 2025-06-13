<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-06-12T23:33:22+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "pa"
}
-->
# ਸੁਰੱਖਿਆ ਦੀਆਂ ਸਭ ਤੋਂ ਵਧੀਆ ਪ੍ਰਥਾਵਾਂ

ਸੁਰੱਖਿਆ MCP ਇੰਪਲੀਮੈਂਟੇਸ਼ਨਾਂ ਲਈ ਬਹੁਤ ਜ਼ਰੂਰੀ ਹੈ, ਖਾਸ ਕਰਕੇ ਉਦਯੋਗਿਕ ਵਾਤਾਵਰਨਾਂ ਵਿੱਚ। ਇਹ ਯਕੀਨੀ ਬਣਾਉਣਾ ਮਹੱਤਵਪੂਰਨ ਹੈ ਕਿ ਟੂਲਾਂ ਅਤੇ ਡੇਟਾ ਬਿਨਾਂ ਅਧਿਕਾਰ ਦੇ ਪਹੁੰਚ, ਡੇਟਾ ਚੋਰੀਆਂ ਅਤੇ ਹੋਰ ਸੁਰੱਖਿਆ ਖਤਰਿਆਂ ਤੋਂ ਸੁਰੱਖਿਅਤ ਰਹਿਣ।

## ਪਰਿਚਯ

ਇਸ ਪਾਠ ਵਿੱਚ, ਅਸੀਂ MCP ਇੰਪਲੀਮੈਂਟੇਸ਼ਨਾਂ ਲਈ ਸੁਰੱਖਿਆ ਦੀਆਂ ਸਭ ਤੋਂ ਵਧੀਆ ਪ੍ਰਥਾਵਾਂ ਦਾ ਅਧਿਐਨ ਕਰਾਂਗੇ। ਅਸੀਂ ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ, ਡੇਟਾ ਸੁਰੱਖਿਆ, ਸੁਰੱਖਿਅਤ ਟੂਲ ਚਲਾਉਣਾ, ਅਤੇ ਡੇਟਾ ਪ੍ਰਾਈਵੇਸੀ ਨਿਯਮਾਂ ਦੀ ਪਾਲਣਾ ਨੂੰ ਕਵਰ ਕਰਾਂਗੇ।

## ਸਿੱਖਣ ਦੇ ਲਕੜ

ਇਸ ਪਾਠ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਸਮਰੱਥ ਹੋਵੋਗੇ:

- MCP ਸਰਵਰਾਂ ਲਈ ਸੁਰੱਖਿਅਤ ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ ਮਕੈਨਿਜ਼ਮ ਲਾਗੂ ਕਰਨਾ।
- ਇਨਕ੍ਰਿਪਸ਼ਨ ਅਤੇ ਸੁਰੱਖਿਅਤ ਸਟੋਰੇਜ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਸੰਵੇਦਨਸ਼ੀਲ ਡੇਟਾ ਦੀ ਰੱਖਿਆ ਕਰਨੀ।
- ਸਹੀ ਪਹੁੰਚ ਨਿਯੰਤਰਣਾਂ ਨਾਲ ਟੂਲਾਂ ਦੀ ਸੁਰੱਖਿਅਤ ਚਲਾਉਣ ਨੂੰ ਯਕੀਨੀ ਬਣਾਉਣਾ।
- ਡੇਟਾ ਸੁਰੱਖਿਆ ਅਤੇ ਪ੍ਰਾਈਵੇਸੀ ਪਾਲਣਾ ਲਈ ਸਭ ਤੋਂ ਵਧੀਆ ਪ੍ਰਥਾਵਾਂ ਲਾਗੂ ਕਰਨਾ।

## ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ

ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ MCP ਸਰਵਰਾਂ ਨੂੰ ਸੁਰੱਖਿਅਤ ਕਰਨ ਲਈ ਬੁਨਿਆਦੀ ਹਨ। ਪ੍ਰਮਾਣਿਕਤਾ ਇਸ ਸਵਾਲ ਦਾ ਜਵਾਬ ਦਿੰਦੀ ਹੈ "ਤੁਸੀਂ ਕੌਣ ਹੋ?" ਜਦਕਿ ਅਧਿਕਾਰ ਇਸ ਦਾ ਕਿੱਤਾ ਹੈ "ਤੁਸੀਂ ਕੀ ਕਰ ਸਕਦੇ ਹੋ?"।

ਆਓ ਦੇਖੀਏ ਕਿ ਕਿਵੇਂ .NET ਅਤੇ Java ਦੀ ਵਰਤੋਂ ਕਰਕੇ MCP ਸਰਵਰਾਂ ਵਿੱਚ ਸੁਰੱਖਿਅਤ ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ ਲਾਗੂ ਕੀਤੇ ਜਾ ਸਕਦੇ ਹਨ।

### .NET Identity ਇੰਟੀਗ੍ਰੇਸ਼ਨ

ASP .NET Core Identity ਉਪਭੋਗਤਾ ਦੀ ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ ਪ੍ਰਬੰਧਨ ਲਈ ਇੱਕ ਮਜ਼ਬੂਤ ਫਰੇਮਵਰਕ ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ। ਅਸੀਂ ਇਸਨੂੰ MCP ਸਰਵਰਾਂ ਨਾਲ ਇੰਟੀਗ੍ਰੇਟ ਕਰਕੇ ਟੂਲਾਂ ਅਤੇ ਸਰੋਤਾਂ ਦੀ ਪਹੁੰਚ ਸੁਰੱਖਿਅਤ ਕਰ ਸਕਦੇ ਹਾਂ।

ASP.NET Core Identity ਨੂੰ MCP ਸਰਵਰਾਂ ਨਾਲ ਇੰਟੀਗ੍ਰੇਟ ਕਰਨ ਵੇਲੇ ਕੁਝ ਮੁੱਖ ਸੰਕਲਪ ਸਮਝਣੇ ਜ਼ਰੂਰੀ ਹਨ:

- **Identity Configuration**: ASP.NET Core Identity ਨੂੰ ਉਪਭੋਗਤਾ ਭੂਮਿਕਾਵਾਂ ਅਤੇ ਦਾਅਵਿਆਂ ਨਾਲ ਸੈੱਟ ਕਰਨਾ। ਦਾਅਵਾ ਉਪਭੋਗਤਾ ਬਾਰੇ ਜਾਣਕਾਰੀ ਦਾ ਇੱਕ ਟੁਕੜਾ ਹੁੰਦਾ ਹੈ, ਜਿਵੇਂ ਉਨ੍ਹਾਂ ਦੀ ਭੂਮਿਕਾ ਜਾਂ ਅਨੁਮਤੀਆਂ, ਉਦਾਹਰਨ ਲਈ "Admin" ਜਾਂ "User"।
- **JWT Authentication**: ਸੁਰੱਖਿਅਤ API ਪਹੁੰਚ ਲਈ JSON Web Tokens (JWT) ਦੀ ਵਰਤੋਂ। JWT ਇੱਕ ਮਿਆਰੀ ਢੰਗ ਹੈ ਜੋ ਪਾਰਟੀਆਂ ਵਿਚਕਾਰ ਜਾਣਕਾਰੀ ਨੂੰ JSON ਆਬਜੈਕਟ ਵਜੋਂ ਸੁਰੱਖਿਅਤ ਤਰੀਕੇ ਨਾਲ ਭੇਜਦਾ ਹੈ, ਜੋ ਡਿਜੀਟਲੀ ਸਾਈਨ ਕੀਤਾ ਹੁੰਦਾ ਹੈ ਇਸ ਲਈ ਇਸਦੀ ਪੁਸ਼ਟੀ ਅਤੇ ਭਰੋਸਾ ਕੀਤਾ ਜਾ ਸਕਦਾ ਹੈ।
- **Authorization Policies**: ਉਪਭੋਗਤਾ ਭੂਮਿਕਾਵਾਂ ਦੇ ਆਧਾਰ 'ਤੇ ਖਾਸ ਟੂਲਾਂ ਦੀ ਪਹੁੰਚ ਨਿਯੰਤਰਿਤ ਕਰਨ ਲਈ ਨੀਤੀਆਂ ਤਿਆਰ ਕਰਨਾ। MCP ਅਧਿਕਾਰ ਨੀਤੀਆਂ ਦੀ ਵਰਤੋਂ ਕਰਦਾ ਹੈ ਇਹ ਨਿਰਧਾਰਿਤ ਕਰਨ ਲਈ ਕਿ ਕਿਹੜੇ ਉਪਭੋਗਤਾ ਕਿਹੜੇ ਟੂਲਾਂ ਨੂੰ ਉਨ੍ਹਾਂ ਦੀਆਂ ਭੂਮਿਕਾਵਾਂ ਅਤੇ ਦਾਅਵਿਆਂ ਦੇ ਆਧਾਰ 'ਤੇ ਪਹੁੰਚ ਸਕਦੇ ਹਨ।

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

- ਉਪਭੋਗਤਾ ਪ੍ਰਬੰਧਨ ਲਈ ASP.NET Core Identity ਨੂੰ ਕਨਫਿਗਰ ਕੀਤਾ ਹੈ।
- ਸੁਰੱਖਿਅਤ API ਪਹੁੰਚ ਲਈ JWT ਪ੍ਰਮਾਣਿਕਤਾ ਸੈੱਟ ਕੀਤੀ ਹੈ। ਅਸੀਂ ਟੋਕਨ ਵੈਰੀਫਿਕੇਸ਼ਨ ਪੈਰਾਮੀਟਰ, ਜਿਵੇਂ issuer, audience ਅਤੇ ਸਾਈਨਿੰਗ ਕੀ, ਨਿਰਧਾਰਤ ਕੀਤੇ ਹਨ।
- ਉਪਭੋਗਤਾ ਭੂਮਿਕਾਵਾਂ ਦੇ ਆਧਾਰ 'ਤੇ ਟੂਲਾਂ ਦੀ ਪਹੁੰਚ ਨਿਯੰਤਰਿਤ ਕਰਨ ਲਈ ਅਧਿਕਾਰ ਨੀਤੀਆਂ ਤਿਆਰ ਕੀਤੀਆਂ ਹਨ। ਉਦਾਹਰਨ ਲਈ, "CanUseAdminTools" ਨੀਤੀ ਲਈ ਉਪਭੋਗਤਾ ਕੋਲ "Admin" ਭੂਮਿਕਾ ਹੋਣੀ ਜ਼ਰੂਰੀ ਹੈ, ਜਦਕਿ "CanUseBasic" ਨੀਤੀ ਲਈ ਉਪਭੋਗਤਾ ਦਾ ਪ੍ਰਮਾਣਿਕ ਹੋਣਾ ਲਾਜ਼ਮੀ ਹੈ।
- MCP ਟੂਲਾਂ ਨੂੰ ਖਾਸ ਅਧਿਕਾਰ ਲੋੜਾਂ ਨਾਲ ਰਜਿਸਟਰ ਕੀਤਾ ਹੈ, ਇਹ ਯਕੀਨੀ ਬਣਾਉਂਦੇ ਹੋਏ ਕਿ ਸਿਰਫ਼ ਉਪਭੋਗਤਾ ਜਿਨ੍ਹਾਂ ਕੋਲ ਮੋਹੱਈਆ ਭੂਮਿਕਾਵਾਂ ਹਨ, ਉਹਨਾਂ ਨੂੰ ਪਹੁੰਚ ਮਿਲੇ।

### Java Spring Security ਇੰਟੀਗ੍ਰੇਸ਼ਨ

Java ਲਈ, ਅਸੀਂ MCP ਸਰਵਰਾਂ ਲਈ ਸੁਰੱਖਿਅਤ ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ ਲਾਗੂ ਕਰਨ ਲਈ Spring Security ਦੀ ਵਰਤੋਂ ਕਰਾਂਗੇ। Spring Security ਇੱਕ ਵਿਆਪਕ ਸੁਰੱਖਿਆ ਫਰੇਮਵਰਕ ਹੈ ਜੋ Spring ਐਪਲੀਕੇਸ਼ਨਾਂ ਨਾਲ ਬੇਹੱਦ ਅਚੁੱਕ ਤਰੀਕੇ ਨਾਲ ਇੰਟੀਗ੍ਰੇਟ ਹੁੰਦਾ ਹੈ।

ਇੱਥੇ ਮੁੱਖ ਸੰਕਲਪ ਹਨ:

- **Spring Security Configuration**: ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ ਲਈ ਸੁਰੱਖਿਆ ਕਨਫਿਗਰੇਸ਼ਨ ਸੈੱਟ ਕਰਨਾ।
- **OAuth2 Resource Server**: MCP ਟੂਲਾਂ ਲਈ ਸੁਰੱਖਿਅਤ ਪਹੁੰਚ ਲਈ OAuth2 ਦੀ ਵਰਤੋਂ। OAuth2 ਇੱਕ ਅਧਿਕਾਰ ਫਰੇਮਵਰਕ ਹੈ ਜੋ ਤੀਜੇ ਪੱਖੀ ਸੇਵਾਵਾਂ ਨੂੰ ਸੁਰੱਖਿਅਤ API ਪਹੁੰਚ ਲਈ ਐਕਸੈਸ ਟੋਕਨ ਬਦਲਣ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ।
- **Security Interceptors**: ਟੂਲ ਚਲਾਉਣ 'ਤੇ ਪਹੁੰਚ ਨਿਯੰਤਰਣ ਲਾਗੂ ਕਰਨ ਲਈ ਸੁਰੱਖਿਆ ਇੰਟਰਸੈਪਟਰ ਲਾਗੂ ਕਰਨਾ।
- **Role-Based Access Control**: ਖਾਸ ਟੂਲਾਂ ਅਤੇ ਸਰੋਤਾਂ ਦੀ ਪਹੁੰਚ ਨੂੰ ਭੂਮਿਕਾਵਾਂ ਦੇ ਆਧਾਰ 'ਤੇ ਨਿਯੰਤਰਿਤ ਕਰਨਾ।
- **Security Annotations**: ਮੈਥਡਾਂ ਅਤੇ ਐਂਡਪੌਇੰਟਾਂ ਨੂੰ ਸੁਰੱਖਿਅਤ ਕਰਨ ਲਈ ਐਨੋਟੇਸ਼ਨ ਦੀ ਵਰਤੋਂ।

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

- MCP ਐਂਡਪੌਇੰਟਾਂ ਨੂੰ ਸੁਰੱਖਿਅਤ ਕਰਨ ਲਈ Spring Security ਕਨਫਿਗਰ ਕੀਤਾ ਹੈ, ਜਿਸ ਨਾਲ ਟੂਲ ਖੋਜ ਲਈ ਸਰਵਜਨਿਕ ਪਹੁੰਚ ਮੁਹੱਈਆ ਕਰਵਾਈ ਜਾਂਦੀ ਹੈ ਜਦਕਿ ਟੂਲ ਚਲਾਉਣ ਲਈ ਪ੍ਰਮਾਣਿਕਤਾ ਲਾਜ਼ਮੀ ਬਣਾਈ ਗਈ ਹੈ।
- MCP ਟੂਲਾਂ ਲਈ ਸੁਰੱਖਿਅਤ ਪਹੁੰਚ ਸੰਭਾਲਣ ਲਈ OAuth2 ਨੂੰ ਰਿਸੋਰਸ ਸਰਵਰ ਵਜੋਂ ਵਰਤਿਆ ਹੈ।
- ਟੂਲ ਚਲਾਉਣ 'ਤੇ ਪਹੁੰਚ ਨਿਯੰਤਰਣ ਲਾਗੂ ਕਰਨ ਲਈ ਸੁਰੱਖਿਆ ਇੰਟਰਸੈਪਟਰ ਲਾਗੂ ਕੀਤਾ ਹੈ, ਜੋ ਖਾਸ ਟੂਲਾਂ ਲਈ ਪਹੁੰਚ ਦੇਣ ਤੋਂ ਪਹਿਲਾਂ ਉਪਭੋਗਤਾ ਭੂਮਿਕਾਵਾਂ ਅਤੇ ਅਨੁਮਤੀਆਂ ਦੀ ਜਾਂਚ ਕਰਦਾ ਹੈ।
- ਐਡਮਿਨ ਟੂਲਾਂ ਅਤੇ ਸੰਵੇਦਨਸ਼ੀਲ ਡੇਟਾ ਪਹੁੰਚ ਨੂੰ ਉਪਭੋਗਤਾ ਭੂਮਿਕਾਵਾਂ ਦੇ ਆਧਾਰ 'ਤੇ ਸੀਮਿਤ ਕਰਨ ਲਈ ਭੂਮਿਕਾ-ਆਧਾਰਿਤ ਪਹੁੰਚ ਨਿਯੰਤਰਣ ਨਿਰਧਾਰਤ ਕੀਤਾ ਹੈ।

## ਡੇਟਾ ਸੁਰੱਖਿਆ ਅਤੇ ਪ੍ਰਾਈਵੇਸੀ

ਡੇਟਾ ਸੁਰੱਖਿਆ ਇਹ ਯਕੀਨੀ ਬਣਾਉਂਦੀ ਹੈ ਕਿ ਸੰਵੇਦਨਸ਼ੀਲ ਜਾਣਕਾਰੀ ਸੁਰੱਖਿਅਤ ਢੰਗ ਨਾਲ ਸੰਭਾਲੀ ਜਾਵੇ। ਇਸ ਵਿੱਚ ਵਿਅਕਤੀਗਤ ਪਛਾਣਯੋਗ ਜਾਣਕਾਰੀ (PII), ਵਿੱਤੀ ਡੇਟਾ ਅਤੇ ਹੋਰ ਸੰਵੇਦਨਸ਼ੀਲ ਜਾਣਕਾਰੀ ਨੂੰ ਬਿਨਾਂ ਅਧਿਕਾਰ ਪਹੁੰਚ ਅਤੇ ਚੋਰੀ ਤੋਂ ਬਚਾਉਣਾ ਸ਼ਾਮਲ ਹੈ।

### Python ਡੇਟਾ ਸੁਰੱਖਿਆ ਉਦਾਹਰਨ

ਆਓ ਵੇਖੀਏ ਕਿ ਕਿਵੇਂ Python ਵਿੱਚ ਇਨਕ੍ਰਿਪਸ਼ਨ ਅਤੇ PII ਡਿਟੈਕਸ਼ਨ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਡੇਟਾ ਸੁਰੱਖਿਆ ਲਾਗੂ ਕੀਤੀ ਜਾ ਸਕਦੀ ਹੈ।

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

- `PiiDetector` class to scan text and parameters for personally identifiable information (PII).
- Created an `EncryptionService` class to handle encryption and decryption of sensitive data using the `cryptography` library.
- Defined a `secure_tool` decorator that wraps tool execution to check for PII, log access, and encrypt sensitive data if required.
- Applied the `secure_tool` decorator to a sample tool (`SecureCustomerDataTool` ਲਾਗੂ ਕੀਤਾ ਹੈ ਤਾਂ ਜੋ ਇਹ ਸੰਵੇਦਨਸ਼ੀਲ ਡੇਟਾ ਨੂੰ ਸੁਰੱਖਿਅਤ ਢੰਗ ਨਾਲ ਸੰਭਾਲੇ।

## ਅਗਲਾ ਕੀ ਹੈ

- [5.9 Web search](../web-search-mcp/README.md)

**ਅਸਵੀਕਾਰੋਪੱਤਰ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਹੀਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੇ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਹੀ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪ੍ਰੋਫੈਸ਼ਨਲ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉਤਪੰਨ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।