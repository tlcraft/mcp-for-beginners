<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ba9c96a7c7901faa1d26c8ec7ad56d2c",
  "translation_date": "2025-06-02T20:12:44+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "pa"
}
-->
# ਸੁਰੱਖਿਆ ਦੀਆਂ ਸਭ ਤੋਂ ਵਧੀਆ ਪ੍ਰਥਾਵਾਂ

MCP ਇੰਪਲੀਮੈਂਟੇਸ਼ਨਾਂ ਲਈ ਸੁਰੱਖਿਆ ਬਹੁਤ ਜਰੂਰੀ ਹੈ, ਖਾਸ ਕਰਕੇ ਐਂਟਰਪ੍ਰਾਈਜ਼ ਮਾਹੌਲਾਂ ਵਿੱਚ। ਇਹ ਯਕੀਨੀ ਬਣਾਉਣਾ ਮਹੱਤਵਪੂਰਨ ਹੈ ਕਿ ਟੂਲਾਂ ਅਤੇ ਡਾਟਾ ਨੂੰ ਬਿਨਾਂ ਅਧਿਕਾਰਤ ਪਹੁੰਚ, ਡਾਟਾ ਚੋਰੀਆਂ ਅਤੇ ਹੋਰ ਸੁਰੱਖਿਆ ਖ਼ਤਰਿਆਂ ਤੋਂ ਬਚਾਇਆ ਜਾਵੇ।

## ਪਰਚਿਆ

ਇਸ ਪਾਠ ਵਿੱਚ, ਅਸੀਂ MCP ਇੰਪਲੀਮੈਂਟੇਸ਼ਨਾਂ ਲਈ ਸੁਰੱਖਿਆ ਦੀਆਂ ਸਭ ਤੋਂ ਵਧੀਆ ਪ੍ਰਥਾਵਾਂ ਬਾਰੇ ਜਾਣੂ ਹੋਵਾਂਗੇ। ਅਸੀਂ ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ, ਡਾਟਾ ਸੁਰੱਖਿਆ, ਸੁਰੱਖਿਅਤ ਟੂਲ ਚਲਾਉਣ ਅਤੇ ਡਾਟਾ ਪ੍ਰਾਈਵੇਸੀ ਨਿਯਮਾਂ ਦੀ ਪਾਲਣਾ ਬਾਰੇ ਵਿਚਾਰ ਕਰਾਂਗੇ।

## ਸਿੱਖਣ ਦੇ ਉਦੇਸ਼

ਇਸ ਪਾਠ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਸਮਰੱਥ ਹੋਵੋਗੇ:

- MCP ਸਰਵਰਾਂ ਲਈ ਸੁਰੱਖਿਅਤ ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ ਮਕੈਨਿਜ਼ਮ ਲਾਗੂ ਕਰਨ ਲਈ।
- ਇੰਕ੍ਰਿਪਸ਼ਨ ਅਤੇ ਸੁਰੱਖਿਅਤ ਸਟੋਰੇਜ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਸੰਵੇਦਨਸ਼ੀਲ ਡਾਟਾ ਦੀ ਰੱਖਿਆ ਕਰਨ ਲਈ।
- ਸਹੀ ਪਹੁੰਚ ਨਿਯੰਤਰਣ ਨਾਲ ਟੂਲਾਂ ਦੀ ਸੁਰੱਖਿਅਤ ਚਲਾਉਣ ਨੂੰ ਯਕੀਨੀ ਬਣਾਉਣ ਲਈ।
- ਡਾਟਾ ਸੁਰੱਖਿਆ ਅਤੇ ਪ੍ਰਾਈਵੇਸੀ ਪਾਲਣਾ ਲਈ ਸਭ ਤੋਂ ਵਧੀਆ ਪ੍ਰਥਾਵਾਂ ਲਾਗੂ ਕਰਨ ਲਈ।

## ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ

ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ MCP ਸਰਵਰਾਂ ਨੂੰ ਸੁਰੱਖਿਅਤ ਬਣਾਉਣ ਲਈ ਜਰੂਰੀ ਹਨ। ਪ੍ਰਮਾਣਿਕਤਾ ਇਹ ਸਵਾਲ ਦਾ ਜਵਾਬ ਦਿੰਦੀ ਹੈ "ਤੁਸੀਂ ਕੌਣ ਹੋ?" ਜਦਕਿ ਅਧਿਕਾਰ ਇਸ ਦਾ ਜਵਾਬ ਦਿੰਦਾ ਹੈ "ਤੁਸੀਂ ਕੀ ਕਰ ਸਕਦੇ ਹੋ?".

ਆਓ ਵੇਖੀਏ ਕਿ ਕਿਵੇਂ .NET ਅਤੇ Java ਦੀ ਵਰਤੋਂ ਕਰਕੇ MCP ਸਰਵਰਾਂ ਵਿੱਚ ਸੁਰੱਖਿਅਤ ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ ਲਾਗੂ ਕਰ ਸਕਦੇ ਹਾਂ।

### .NET Identity ਇੰਟੀਗ੍ਰੇਸ਼ਨ

ASP .NET Core Identity ਇੱਕ ਮਜ਼ਬੂਤ ਫਰੇਮਵਰਕ ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ ਜੋ ਯੂਜ਼ਰ ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ ਨੂੰ ਪ੍ਰਬੰਧਿਤ ਕਰਦਾ ਹੈ। ਅਸੀਂ ਇਸਨੂੰ MCP ਸਰਵਰਾਂ ਨਾਲ ਜੋੜ ਕੇ ਟੂਲਾਂ ਅਤੇ ਸਰੋਤਾਂ ਤੱਕ ਪਹੁੰਚ ਸੁਰੱਖਿਅਤ ਕਰ ਸਕਦੇ ਹਾਂ।

ASP.NET Core Identity ਨੂੰ MCP ਸਰਵਰਾਂ ਨਾਲ ਜੋੜਦੇ ਸਮੇਂ ਕੁਝ ਮੁੱਖ ਧਾਰਣਾਵਾਂ ਸਮਝਣੀਆਂ ਲਾਜ਼ਮੀ ਹਨ:

- **Identity Configuration**: ASP.NET Core Identity ਨੂੰ ਯੂਜ਼ਰ ਰੋਲ ਅਤੇ ਕਲੇਮਾਂ ਨਾਲ ਸੈੱਟਅੱਪ ਕਰਨਾ। ਕਲੇਮ ਇੱਕ ਜਾਣਕਾਰੀ ਦਾ ਹਿੱਸਾ ਹੁੰਦਾ ਹੈ ਜੋ ਯੂਜ਼ਰ ਬਾਰੇ ਹੁੰਦਾ ਹੈ, ਜਿਵੇਂ ਉਹਨਾਂ ਦਾ ਰੋਲ ਜਾਂ ਅਧਿਕਾਰ, ਉਦਾਹਰਨ ਵਜੋਂ "Admin" ਜਾਂ "User"।
- **JWT Authentication**: JSON Web Tokens (JWT) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਸੁਰੱਖਿਅਤ API ਪਹੁੰਚ। JWT ਇੱਕ ਮਿਆਰੀ ਤਰੀਕਾ ਹੈ ਜਿਸ ਨਾਲ ਦੋ ਪੱਖਾਂ ਵਿੱਚ ਜਾਣਕਾਰੀ ਨੂੰ JSON ਆਬਜੈਕਟ ਵਜੋਂ ਸੁਰੱਖਿਅਤ ਤਰੀਕੇ ਨਾਲ ਭੇਜਿਆ ਜਾਂਦਾ ਹੈ, ਜੋ ਡਿਜੀਟਲੀ ਸਾਈਨ ਕੀਤਾ ਹੁੰਦਾ ਹੈ ਅਤੇ ਇਸਦਾ ਸੱਚਾਪਣ ਜਾਂਚਿਆ ਜਾ ਸਕਦਾ ਹੈ।
- **Authorization Policies**: ਯੂਜ਼ਰ ਰੋਲਾਂ ਦੇ ਆਧਾਰ 'ਤੇ ਖਾਸ ਟੂਲਾਂ ਤੱਕ ਪਹੁੰਚ ਨੂੰ ਨਿਯੰਤਰਿਤ ਕਰਨ ਲਈ ਨੀਤੀਆਂ ਬਣਾਉਣਾ। MCP ਅਧਿਕਾਰ ਨੀਤੀਆਂ ਦੀ ਵਰਤੋਂ ਕਰਦਾ ਹੈ ਇਹ ਤੈਅ ਕਰਨ ਲਈ ਕਿ ਕਿਹੜੇ ਯੂਜ਼ਰ ਕਿਹੜੇ ਟੂਲਾਂ ਤੱਕ ਪਹੁੰਚ ਸਕਦੇ ਹਨ, ਉਹਨਾਂ ਦੇ ਰੋਲਾਂ ਅਤੇ ਕਲੇਮਾਂ ਦੇ ਅਧਾਰ 'ਤੇ।

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

- ਯੂਜ਼ਰ ਪ੍ਰਬੰਧਨ ਲਈ ASP.NET Core Identity ਨੂੰ ਸੰਰਚਿਤ ਕੀਤਾ ਹੈ।
- ਸੁਰੱਖਿਅਤ API ਪਹੁੰਚ ਲਈ JWT ਪ੍ਰਮਾਣਿਕਤਾ ਸੈੱਟ ਕੀਤੀ ਹੈ। ਅਸੀਂ ਟੋਕਨ ਵੈਰੀਫਿਕੇਸ਼ਨ ਪੈਰਾਮੀਟਰ, ਜਿਵੇਂ issuer, audience ਅਤੇ ਸਾਈਨਿੰਗ ਕੀ ਦਰਜ ਕੀਤੇ ਹਨ।
- ਯੂਜ਼ਰ ਰੋਲਾਂ ਦੇ ਆਧਾਰ 'ਤੇ ਟੂਲਾਂ ਤੱਕ ਪਹੁੰਚ ਨੂੰ ਨਿਯੰਤਰਿਤ ਕਰਨ ਲਈ ਅਧਿਕਾਰ ਨੀਤੀਆਂ ਬਣਾਈਆਂ ਹਨ। ਉਦਾਹਰਨ ਵਜੋਂ, "CanUseAdminTools" ਨੀਤੀ ਲਈ ਯੂਜ਼ਰ ਕੋਲ "Admin" ਰੋਲ ਹੋਣਾ ਲਾਜ਼ਮੀ ਹੈ, ਜਦਕਿ "CanUseBasic" ਨੀਤੀ ਲਈ ਯੂਜ਼ਰ ਦਾ ਪ੍ਰਮਾਣਿਤ ਹੋਣਾ ਜ਼ਰੂਰੀ ਹੈ।
- MCP ਟੂਲਾਂ ਨੂੰ ਖਾਸ ਅਧਿਕਾਰ ਲੋੜਾਂ ਨਾਲ ਰਜਿਸਟਰ ਕੀਤਾ ਹੈ, ਇਹ ਯਕੀਨੀ ਬਣਾਉਂਦੇ ਹੋਏ ਕਿ ਸਿਰਫ ਉਹੀ ਯੂਜ਼ਰ ਜਿਨ੍ਹਾਂ ਕੋਲ ਉਚਿਤ ਰੋਲ ਹਨ, ਉਹਨਾਂ ਤੱਕ ਪਹੁੰਚ ਹੋਵੇ।

### Java Spring Security ਇੰਟੀਗ੍ਰੇਸ਼ਨ

Java ਲਈ, ਅਸੀਂ MCP ਸਰਵਰਾਂ ਲਈ ਸੁਰੱਖਿਅਤ ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ ਲਾਗੂ ਕਰਨ ਲਈ Spring Security ਦੀ ਵਰਤੋਂ ਕਰਾਂਗੇ। Spring Security ਇੱਕ ਵਿਸਤ੍ਰਿਤ ਸੁਰੱਖਿਆ ਫਰੇਮਵਰਕ ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ ਜੋ Spring ਐਪਲੀਕੇਸ਼ਨਾਂ ਨਾਲ ਬਿਨਾਂ ਰੁਕਾਵਟ ਦੇ ਜੁੜਦਾ ਹੈ।

ਇੱਥੇ ਮੁੱਖ ਧਾਰਣਾਵਾਂ ਹਨ:

- **Spring Security Configuration**: ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ ਲਈ ਸੁਰੱਖਿਆ ਸੰਰਚਨਾਵਾਂ ਸੈੱਟ ਕਰਨਾ।
- **OAuth2 Resource Server**: MCP ਟੂਲਾਂ ਤੱਕ ਸੁਰੱਖਿਅਤ ਪਹੁੰਚ ਲਈ OAuth2 ਦੀ ਵਰਤੋਂ। OAuth2 ਇੱਕ ਅਧਿਕਾਰ ਫਰੇਮਵਰਕ ਹੈ ਜੋ ਤੀਜੀ ਪੱਖ ਦੀਆਂ ਸੇਵਾਵਾਂ ਨੂੰ ਸੁਰੱਖਿਅਤ API ਪਹੁੰਚ ਲਈ ਟੋਕਨ ਬਦਲਣ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ।
- **Security Interceptors**: ਟੂਲ ਚਲਾਉਣ 'ਤੇ ਪਹੁੰਚ ਨਿਯੰਤਰਣ ਲਾਗੂ ਕਰਨ ਲਈ ਸੁਰੱਖਿਆ ਇੰਟਰਸੈਪਟਰ ਬਣਾਉਣਾ।
- **Role-Based Access Control**: ਖਾਸ ਟੂਲਾਂ ਅਤੇ ਸਰੋਤਾਂ ਤੱਕ ਪਹੁੰਚ ਨੂੰ ਰੋਲਾਂ ਦੇ ਆਧਾਰ 'ਤੇ ਨਿਯੰਤਰਿਤ ਕਰਨਾ।
- **Security Annotations**: ਮੈਥਡਾਂ ਅਤੇ ਐਂਡਪੋਇੰਟਾਂ ਨੂੰ ਸੁਰੱਖਿਅਤ ਕਰਨ ਲਈ ਐਨੋਟੇਸ਼ਨ ਦੀ ਵਰਤੋਂ।

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

- MCP ਐਂਡਪੋਇੰਟਾਂ ਨੂੰ ਸੁਰੱਖਿਅਤ ਕਰਨ ਲਈ Spring Security ਨੂੰ ਸੰਰਚਿਤ ਕੀਤਾ ਹੈ, ਜਿੱਥੇ ਟੂਲ ਖੋਜ ਨੂੰ ਜਨਤਕ ਪਹੁੰਚ ਮਿਲਦੀ ਹੈ ਪਰ ਟੂਲ ਚਲਾਉਣ ਲਈ ਪ੍ਰਮਾਣਿਕਤਾ ਜ਼ਰੂਰੀ ਹੈ।
- MCP ਟੂਲਾਂ ਲਈ ਸੁਰੱਖਿਅਤ ਪਹੁੰਚ ਸੰਭਾਲਣ ਲਈ OAuth2 ਨੂੰ ਰਿਸੋਰਸ ਸਰਵਰ ਵਜੋਂ ਵਰਤਿਆ ਹੈ।
- ਟੂਲ ਚਲਾਉਣ 'ਤੇ ਪਹੁੰਚ ਨਿਯੰਤਰਣ ਲਾਗੂ ਕਰਨ ਲਈ ਸੁਰੱਖਿਆ ਇੰਟਰਸੈਪਟਰ ਬਣਾਇਆ ਹੈ, ਜੋ ਖਾਸ ਟੂਲਾਂ ਤੱਕ ਪਹੁੰਚ ਦੇਣ ਤੋਂ ਪਹਿਲਾਂ ਯੂਜ਼ਰ ਦੇ ਰੋਲ ਅਤੇ ਅਧਿਕਾਰਾਂ ਦੀ ਜਾਂਚ ਕਰਦਾ ਹੈ।
- ਐਡਮਿਨ ਟੂਲਾਂ ਅਤੇ ਸੰਵੇਦਨਸ਼ੀਲ ਡਾਟਾ ਤੱਕ ਪਹੁੰਚ ਨੂੰ ਯੂਜ਼ਰ ਰੋਲਾਂ ਦੇ ਅਧਾਰ 'ਤੇ ਸੀਮਿਤ ਕਰਨ ਲਈ ਰੋਲ-ਆਧਾਰਿਤ ਪਹੁੰਚ ਨਿਯੰਤਰਣ ਨੂੰ ਪਰਿਭਾਸ਼ਿਤ ਕੀਤਾ ਹੈ।

## ਡਾਟਾ ਸੁਰੱਖਿਆ ਅਤੇ ਪ੍ਰਾਈਵੇਸੀ

ਡਾਟਾ ਸੁਰੱਖਿਆ ਇਹ ਯਕੀਨੀ ਬਣਾਉਣ ਲਈ ਬਹੁਤ ਜਰੂਰੀ ਹੈ ਕਿ ਸੰਵੇਦਨਸ਼ੀਲ ਜਾਣਕਾਰੀ ਸੁਰੱਖਿਅਤ ਤਰੀਕੇ ਨਾਲ ਸੰਭਾਲੀ ਜਾਵੇ। ਇਸ ਵਿੱਚ ਵਿਅਕਤੀਗਤ ਪਛਾਣ ਯੋਗ ਜਾਣਕਾਰੀ (PII), ਵਿੱਤੀ ਡਾਟਾ ਅਤੇ ਹੋਰ ਸੰਵੇਦਨਸ਼ੀਲ ਜਾਣਕਾਰੀ ਨੂੰ ਬਿਨਾਂ ਅਧਿਕਾਰਤ ਪਹੁੰਚ ਅਤੇ ਚੋਰੀ ਤੋਂ ਬਚਾਉਣਾ ਸ਼ਾਮਲ ਹੈ।

### Python ਡਾਟਾ ਸੁਰੱਖਿਆ ਉਦਾਹਰਨ

ਆਓ ਵੇਖੀਏ ਕਿ ਕਿਵੇਂ Python ਵਿੱਚ ਇੰਕ੍ਰਿਪਸ਼ਨ ਅਤੇ PII ਪਛਾਣ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਡਾਟਾ ਸੁਰੱਖਿਆ ਲਾਗੂ ਕੀਤੀ ਜਾ ਸਕਦੀ ਹੈ।

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
- Applied the `secure_tool` decorator to a sample tool (`SecureCustomerDataTool` ਨੂੰ ਲਾਗੂ ਕੀਤਾ ਹੈ, ਇਹ ਯਕੀਨੀ ਬਣਾਉਣ ਲਈ ਕਿ ਇਹ ਸੰਵੇਦਨਸ਼ੀਲ ਡਾਟਾ ਨੂੰ ਸੁਰੱਖਿਅਤ ਤਰੀਕੇ ਨਾਲ ਸੰਭਾਲਦਾ ਹੈ।

## ਅਗਲਾ ਕੀ ਹੈ

- [Web search](../web-search-mcp/README.md)

**ਇਨਕਾਰ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਅਤ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਹੀਤੀਆਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਹੀ ਅਧਿਕਾਰਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਿਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਪੈਦਾ ਹੋਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀਆਂ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆਵਾਂ ਲਈ ਅਸੀਂ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।