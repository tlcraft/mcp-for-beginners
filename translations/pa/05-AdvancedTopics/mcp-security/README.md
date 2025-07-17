<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e363328861e6e00258187f731a773411",
  "translation_date": "2025-07-17T00:49:41+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "pa"
}
-->
# ਸੁਰੱਖਿਆ ਲਈ ਵਧੀਆ ਅਮਲ

ਸੁਰੱਖਿਆ MCP ਇੰਪਲੀਮੈਂਟੇਸ਼ਨਾਂ ਲਈ ਬਹੁਤ ਜਰੂਰੀ ਹੈ, ਖਾਸ ਕਰਕੇ ਉਦਯੋਗਿਕ ਮਾਹੌਲਾਂ ਵਿੱਚ। ਇਹ ਯਕੀਨੀ ਬਣਾਉਣਾ ਮਹੱਤਵਪੂਰਨ ਹੈ ਕਿ ਟੂਲਾਂ ਅਤੇ ਡਾਟਾ ਨੂੰ ਬਿਨਾਂ ਅਧਿਕਾਰ ਦੇ ਪਹੁੰਚ, ਡਾਟਾ ਚੋਰੀਆਂ ਅਤੇ ਹੋਰ ਸੁਰੱਖਿਆ ਖਤਰਿਆਂ ਤੋਂ ਬਚਾਇਆ ਜਾਵੇ।

## ਪਰਿਚਯ

ਮਾਡਲ ਕਾਂਟੈਕਸਟ ਪ੍ਰੋਟੋਕੋਲ (MCP) ਨੂੰ ਖਾਸ ਸੁਰੱਖਿਆ ਧਿਆਨ ਦੀ ਲੋੜ ਹੁੰਦੀ ਹੈ ਕਿਉਂਕਿ ਇਹ LLMs ਨੂੰ ਡਾਟਾ ਅਤੇ ਟੂਲਾਂ ਤੱਕ ਪਹੁੰਚ ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ। ਇਹ ਪਾਠ MCP ਇੰਪਲੀਮੈਂਟੇਸ਼ਨਾਂ ਲਈ ਸਰਕਾਰੀ MCP ਦਿਸ਼ਾ-ਨਿਰਦੇਸ਼ਾਂ ਅਤੇ ਸਥਾਪਿਤ ਸੁਰੱਖਿਆ ਪੈਟਰਨਾਂ ਦੇ ਆਧਾਰ 'ਤੇ ਸੁਰੱਖਿਆ ਲਈ ਵਧੀਆ ਅਮਲਾਂ ਦੀ ਜਾਂਚ ਕਰਦਾ ਹੈ।

MCP ਕੁਝ ਮੁੱਖ ਸੁਰੱਖਿਆ ਸਿਧਾਂਤਾਂ ਦੀ ਪਾਲਣਾ ਕਰਦਾ ਹੈ ਤਾਂ ਜੋ ਸੁਰੱਖਿਅਤ ਅਤੇ ਭਰੋਸੇਯੋਗ ਇੰਟਰੈਕਸ਼ਨ ਹੋ ਸਕਣ:

- **ਉਪਭੋਗਤਾ ਦੀ ਸਹਿਮਤੀ ਅਤੇ ਨਿਯੰਤਰਣ**: ਕਿਸੇ ਵੀ ਡਾਟਾ ਤੱਕ ਪਹੁੰਚ ਜਾਂ ਕਾਰਵਾਈ ਕਰਨ ਤੋਂ ਪਹਿਲਾਂ ਉਪਭੋਗਤਾ ਦੀ ਸਪਸ਼ਟ ਸਹਿਮਤੀ ਲੈਣੀ ਜਰੂਰੀ ਹੈ। ਇਹ ਸਪਸ਼ਟ ਕਰੋ ਕਿ ਕਿਹੜਾ ਡਾਟਾ ਸਾਂਝਾ ਕੀਤਾ ਜਾ ਰਿਹਾ ਹੈ ਅਤੇ ਕਿਹੜੀਆਂ ਕਾਰਵਾਈਆਂ ਮਨਜ਼ੂਰ ਹਨ।
  
- **ਡਾਟਾ ਦੀ ਗੋਪਨੀਯਤਾ**: ਉਪਭੋਗਤਾ ਦਾ ਡਾਟਾ ਸਿਰਫ ਸਪਸ਼ਟ ਸਹਿਮਤੀ ਨਾਲ ਹੀ ਪ੍ਰਗਟ ਕੀਤਾ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ ਅਤੇ ਇਸ ਨੂੰ ਉਚਿਤ ਪਹੁੰਚ ਨਿਯੰਤਰਣਾਂ ਨਾਲ ਸੁਰੱਖਿਅਤ ਕੀਤਾ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਬਿਨਾਂ ਅਧਿਕਾਰ ਦੇ ਡਾਟਾ ਪ੍ਰਸਾਰਣ ਤੋਂ ਬਚਾਅ ਕਰੋ।
  
- **ਟੂਲ ਸੁਰੱਖਿਆ**: ਕਿਸੇ ਵੀ ਟੂਲ ਨੂੰ ਕਾਲ ਕਰਨ ਤੋਂ ਪਹਿਲਾਂ ਉਪਭੋਗਤਾ ਦੀ ਸਪਸ਼ਟ ਸਹਿਮਤੀ ਲੈਣੀ ਜਰੂਰੀ ਹੈ। ਉਪਭੋਗਤਾਵਾਂ ਨੂੰ ਹਰ ਟੂਲ ਦੀ ਕਾਰਗੁਜ਼ਾਰੀ ਦੀ ਸਪਸ਼ਟ ਸਮਝ ਹੋਣੀ ਚਾਹੀਦੀ ਹੈ ਅਤੇ ਮਜ਼ਬੂਤ ਸੁਰੱਖਿਆ ਸੀਮਾਵਾਂ ਲਾਗੂ ਕੀਤੀਆਂ ਜਾਣ।

## ਸਿੱਖਣ ਦੇ ਲਕੜੇ

ਇਸ ਪਾਠ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਸਮਰੱਥ ਹੋਵੋਗੇ:

- MCP ਸਰਵਰਾਂ ਲਈ ਸੁਰੱਖਿਅਤ ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ ਪ੍ਰਣਾਲੀਆਂ ਲਾਗੂ ਕਰਨ।
- ਸੰਵੇਦਨਸ਼ੀਲ ਡਾਟਾ ਨੂੰ ਇਨਕ੍ਰਿਪਸ਼ਨ ਅਤੇ ਸੁਰੱਖਿਅਤ ਸਟੋਰੇਜ ਨਾਲ ਬਚਾਉਣ।
- ਟੂਲਾਂ ਦੀ ਸੁਰੱਖਿਅਤ ਕਾਰਗੁਜ਼ਾਰੀ ਯਕੀਨੀ ਬਣਾਉਣ ਲਈ ਉਚਿਤ ਪਹੁੰਚ ਨਿਯੰਤਰਣ ਲਾਗੂ ਕਰਨ।
- ਡਾਟਾ ਸੁਰੱਖਿਆ ਅਤੇ ਗੋਪਨੀਯਤਾ ਅਨੁਕੂਲਤਾ ਲਈ ਵਧੀਆ ਅਮਲ ਲਾਗੂ ਕਰਨ।
- ਆਮ MCP ਸੁਰੱਖਿਆ ਖਾਮੀਆਂ ਜਿਵੇਂ ਕਿ confused deputy ਸਮੱਸਿਆਵਾਂ, token passthrough, ਅਤੇ session hijacking ਦੀ ਪਛਾਣ ਅਤੇ ਰੋਕਥਾਮ ਕਰਨ।

## ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ

ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ MCP ਸਰਵਰਾਂ ਨੂੰ ਸੁਰੱਖਿਅਤ ਕਰਨ ਲਈ ਜਰੂਰੀ ਹਨ। ਪ੍ਰਮਾਣਿਕਤਾ ਸਵਾਲ ਦਾ ਜਵਾਬ ਦਿੰਦੀ ਹੈ "ਤੁਸੀਂ ਕੌਣ ਹੋ?" ਜਦਕਿ ਅਧਿਕਾਰ ਸਵਾਲ ਦਾ ਜਵਾਬ ਦਿੰਦਾ ਹੈ "ਤੁਸੀਂ ਕੀ ਕਰ ਸਕਦੇ ਹੋ?".

MCP ਸੁਰੱਖਿਆ ਵਿਸ਼ੇਸ਼ਤਾ ਅਨੁਸਾਰ, ਇਹ ਮਹੱਤਵਪੂਰਨ ਸੁਰੱਖਿਆ ਧਿਆਨ ਹਨ:

1. **ਟੋਕਨ ਵੈਰੀਫਿਕੇਸ਼ਨ**: MCP ਸਰਵਰਾਂ ਨੂੰ ਉਹ ਟੋਕਨ ਕਦੇ ਵੀ ਸਵੀਕਾਰ ਨਹੀਂ ਕਰਨੇ ਚਾਹੀਦੇ ਜੋ ਖਾਸ MCP ਸਰਵਰ ਲਈ ਜਾਰੀ ਨਹੀਂ ਕੀਤੇ ਗਏ। "ਟੋਕਨ ਪਾਸਥਰੂ" ਇੱਕ ਸਪਸ਼ਟ ਤੌਰ 'ਤੇ ਮਨਾਹੀ ਕੀਤੀ ਗਈ ਗਲਤ ਪ੍ਰਥਾ ਹੈ।

2. **ਅਧਿਕਾਰ ਦੀ ਜਾਂਚ**: MCP ਸਰਵਰ ਜੋ ਅਧਿਕਾਰ ਲਾਗੂ ਕਰਦੇ ਹਨ, ਉਹ ਸਾਰੇ ਆਉਣ ਵਾਲੇ ਬੇਨਤੀਆਂ ਦੀ ਜਾਂਚ ਕਰਨੀ ਚਾਹੀਦੀ ਹੈ ਅਤੇ ਪ੍ਰਮਾਣਿਕਤਾ ਲਈ ਸੈਸ਼ਨ ਵਰਤਣ ਤੋਂ ਬਚਣਾ ਚਾਹੀਦਾ ਹੈ।

3. **ਸੁਰੱਖਿਅਤ ਸੈਸ਼ਨ ਪ੍ਰਬੰਧਨ**: ਜਦੋਂ ਸਟੇਟ ਲਈ ਸੈਸ਼ਨ ਵਰਤੇ ਜਾਂਦੇ ਹਨ, MCP ਸਰਵਰਾਂ ਨੂੰ ਸੁਰੱਖਿਅਤ, ਗੈਰ-ਨਿਰਧਾਰਿਤ ਸੈਸ਼ਨ ID ਵਰਤਣੇ ਚਾਹੀਦੇ ਹਨ ਜੋ ਸੁਰੱਖਿਅਤ ਰੈਂਡਮ ਨੰਬਰ ਜਨਰੇਟਰ ਨਾਲ ਬਣਾਏ ਗਏ ਹੋਣ। ਸੈਸ਼ਨ ID ਨੂੰ ਉਪਭੋਗਤਾ-ਵਿਸ਼ੇਸ਼ ਜਾਣਕਾਰੀ ਨਾਲ ਬੰਨ੍ਹਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ।

4. **ਸਪਸ਼ਟ ਉਪਭੋਗਤਾ ਸਹਿਮਤੀ**: ਪ੍ਰਾਕਸੀ ਸਰਵਰਾਂ ਲਈ, MCP ਇੰਪਲੀਮੈਂਟੇਸ਼ਨਾਂ ਨੂੰ ਹਰ ਡਾਇਨਾਮਿਕ ਰਜਿਸਟਰਡ ਕਲਾਇੰਟ ਲਈ ਉਪਭੋਗਤਾ ਦੀ ਸਹਿਮਤੀ ਲੈਣੀ ਚਾਹੀਦੀ ਹੈ, ਇਸ ਤੋਂ ਪਹਿਲਾਂ ਕਿ ਉਹ ਤੀਜੀ-ਪੱਖੀ ਅਧਿਕਾਰ ਸਰਵਰਾਂ ਨੂੰ ਅੱਗੇ ਭੇਜੇ ਜਾਣ।

ਆਓ ਵੇਖੀਏ ਕਿ .NET ਅਤੇ ਜਾਵਾ ਦੀ ਵਰਤੋਂ ਕਰਕੇ MCP ਸਰਵਰਾਂ ਵਿੱਚ ਸੁਰੱਖਿਅਤ ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ ਕਿਵੇਂ ਲਾਗੂ ਕੀਤੇ ਜਾ ਸਕਦੇ ਹਨ।

### .NET Identity ਇੰਟੀਗ੍ਰੇਸ਼ਨ

ASP .NET ਕੋਰ Identity ਉਪਭੋਗਤਾ ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ ਪ੍ਰਬੰਧਨ ਲਈ ਇੱਕ ਮਜ਼ਬੂਤ ਫਰੇਮਵਰਕ ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ। ਅਸੀਂ ਇਸਨੂੰ MCP ਸਰਵਰਾਂ ਨਾਲ ਜੋੜ ਕੇ ਟੂਲਾਂ ਅਤੇ ਸਰੋਤਾਂ ਤੱਕ ਸੁਰੱਖਿਅਤ ਪਹੁੰਚ ਯਕੀਨੀ ਬਣਾ ਸਕਦੇ ਹਾਂ।

ASP.NET ਕੋਰ Identity ਨੂੰ MCP ਸਰਵਰਾਂ ਨਾਲ ਜੋੜਦੇ ਸਮੇਂ ਕੁਝ ਮੁੱਖ ਧਾਰਣਾਵਾਂ ਹਨ:

- **Identity ਸੰਰਚਨਾ**: ASP.NET ਕੋਰ Identity ਨੂੰ ਉਪਭੋਗਤਾ ਭੂਮਿਕਾਵਾਂ ਅਤੇ ਦਾਅਵਿਆਂ ਨਾਲ ਸੈੱਟ ਕਰਨਾ। ਦਾਅਵਾ ਉਪਭੋਗਤਾ ਬਾਰੇ ਜਾਣਕਾਰੀ ਦਾ ਇੱਕ ਟੁਕੜਾ ਹੁੰਦਾ ਹੈ, ਜਿਵੇਂ ਕਿ ਉਹਨਾਂ ਦੀ ਭੂਮਿਕਾ ਜਾਂ ਅਧਿਕਾਰ, ਉਦਾਹਰਨ ਲਈ "Admin" ਜਾਂ "User"।
- **JWT ਪ੍ਰਮਾਣਿਕਤਾ**: ਸੁਰੱਖਿਅਤ API ਪਹੁੰਚ ਲਈ JSON Web Tokens (JWT) ਦੀ ਵਰਤੋਂ। JWT ਇੱਕ ਮਿਆਰੀ ਤਰੀਕਾ ਹੈ ਜੋ ਪਾਰਟੀਆਂ ਵਿਚਕਾਰ ਜਾਣਕਾਰੀ ਨੂੰ JSON ਆਬਜੈਕਟ ਵਜੋਂ ਸੁਰੱਖਿਅਤ ਤਰੀਕੇ ਨਾਲ ਭੇਜਦਾ ਹੈ, ਜਿਸ ਨੂੰ ਡਿਜੀਟਲ ਤੌਰ 'ਤੇ ਸਾਈਨ ਕੀਤਾ ਜਾਂਦਾ ਹੈ ਅਤੇ ਇਸ ਲਈ ਭਰੋਸੇਯੋਗ ਹੁੰਦਾ ਹੈ।
- **ਅਧਿਕਾਰ ਨੀਤੀਆਂ**: ਉਪਭੋਗਤਾ ਭੂਮਿਕਾਵਾਂ ਦੇ ਆਧਾਰ 'ਤੇ ਖਾਸ ਟੂਲਾਂ ਤੱਕ ਪਹੁੰਚ ਨੂੰ ਨਿਯੰਤਰਿਤ ਕਰਨ ਲਈ ਨੀਤੀਆਂ ਬਣਾਉਣਾ। MCP ਅਧਿਕਾਰ ਨੀਤੀਆਂ ਦੀ ਵਰਤੋਂ ਕਰਦਾ ਹੈ ਇਹ ਨਿਰਧਾਰਿਤ ਕਰਨ ਲਈ ਕਿ ਕਿਹੜੇ ਉਪਭੋਗਤਾ ਕਿਹੜੇ ਟੂਲਾਂ ਤੱਕ ਪਹੁੰਚ ਸਕਦੇ ਹਨ।

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

- ਉਪਭੋਗਤਾ ਪ੍ਰਬੰਧਨ ਲਈ ASP.NET ਕੋਰ Identity ਸੰਰਚਿਤ ਕੀਤਾ ਹੈ।
- ਸੁਰੱਖਿਅਤ API ਪਹੁੰਚ ਲਈ JWT ਪ੍ਰਮਾਣਿਕਤਾ ਸੈੱਟ ਕੀਤੀ ਹੈ। ਅਸੀਂ ਟੋਕਨ ਵੈਰੀਫਿਕੇਸ਼ਨ ਪੈਰਾਮੀਟਰ ਜਿਵੇਂ ਕਿ ਜਾਰੀ ਕਰਨ ਵਾਲਾ, ਦਰਸ਼ਕ ਅਤੇ ਸਾਈਨਿੰਗ ਕੀ ਨਿਰਧਾਰਤ ਕੀਤੇ ਹਨ।
- ਉਪਭੋਗਤਾ ਭੂਮਿਕਾਵਾਂ ਦੇ ਆਧਾਰ 'ਤੇ ਟੂਲਾਂ ਤੱਕ ਪਹੁੰਚ ਨੂੰ ਨਿਯੰਤਰਿਤ ਕਰਨ ਲਈ ਅਧਿਕਾਰ ਨੀਤੀਆਂ ਬਣਾਈਆਂ ਹਨ। ਉਦਾਹਰਨ ਵਜੋਂ, "CanUseAdminTools" ਨੀਤੀ ਲਈ ਉਪਭੋਗਤਾ ਕੋਲ "Admin" ਭੂਮਿਕਾ ਹੋਣੀ ਲਾਜ਼ਮੀ ਹੈ, ਜਦਕਿ "CanUseBasic" ਨੀਤੀ ਲਈ ਉਪਭੋਗਤਾ ਦਾ ਪ੍ਰਮਾਣਿਤ ਹੋਣਾ ਜਰੂਰੀ ਹੈ।
- MCP ਟੂਲਾਂ ਨੂੰ ਖਾਸ ਅਧਿਕਾਰ ਲੋੜਾਂ ਨਾਲ ਰਜਿਸਟਰ ਕੀਤਾ ਹੈ, ਇਹ ਯਕੀਨੀ ਬਣਾਉਂਦੇ ਹੋਏ ਕਿ ਸਿਰਫ ਉਹੀ ਉਪਭੋਗਤਾ ਜਿਨ੍ਹਾਂ ਕੋਲ ਉਚਿਤ ਭੂਮਿਕਾਵਾਂ ਹਨ, ਉਹਨਾਂ ਨੂੰ ਪਹੁੰਚ ਮਿਲੇ।

### ਜਾਵਾ ਸਪ੍ਰਿੰਗ ਸੁਰੱਖਿਆ ਇੰਟੀਗ੍ਰੇਸ਼ਨ

ਜਾਵਾ ਲਈ, ਅਸੀਂ MCP ਸਰਵਰਾਂ ਲਈ ਸੁਰੱਖਿਅਤ ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ ਲਾਗੂ ਕਰਨ ਲਈ Spring Security ਦੀ ਵਰਤੋਂ ਕਰਾਂਗੇ। Spring Security ਇੱਕ ਵਿਸ਼ਤ੍ਰਿਤ ਸੁਰੱਖਿਆ ਫਰੇਮਵਰਕ ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ ਜੋ Spring ਐਪਲੀਕੇਸ਼ਨਾਂ ਨਾਲ ਬਿਨਾਂ ਰੁਕਾਵਟ ਦੇ ਇੰਟੀਗ੍ਰੇਟ ਹੁੰਦਾ ਹੈ।

ਇੱਥੇ ਕੁਝ ਮੁੱਖ ਧਾਰਣਾਵਾਂ ਹਨ:

- **Spring Security ਸੰਰਚਨਾ**: ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ ਲਈ ਸੁਰੱਖਿਆ ਸੰਰਚਨਾਵਾਂ ਸੈੱਟ ਕਰਨਾ।
- **OAuth2 ਰਿਸੋਰਸ ਸਰਵਰ**: MCP ਟੂਲਾਂ ਲਈ ਸੁਰੱਖਿਅਤ ਪਹੁੰਚ ਲਈ OAuth2 ਦੀ ਵਰਤੋਂ। OAuth2 ਇੱਕ ਅਧਿਕਾਰ ਫਰੇਮਵਰਕ ਹੈ ਜੋ ਤੀਜੀ-ਪੱਖੀ ਸੇਵਾਵਾਂ ਨੂੰ ਸੁਰੱਖਿਅਤ API ਪਹੁੰਚ ਲਈ ਟੋਕਨ ਬਦਲਣ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ।
- **ਸੁਰੱਖਿਆ ਇੰਟਰਸੈਪਟਰ**: ਟੂਲ ਕਾਰਗੁਜ਼ਾਰੀ 'ਤੇ ਪਹੁੰਚ ਨਿਯੰਤਰਣ ਲਾਗੂ ਕਰਨ ਲਈ ਸੁਰੱਖਿਆ ਇੰਟਰਸੈਪਟਰ ਬਣਾਉਣਾ।
- **ਭੂਮਿਕਾ-ਆਧਾਰਿਤ ਪਹੁੰਚ ਨਿਯੰਤਰਣ**: ਖਾਸ ਟੂਲਾਂ ਅਤੇ ਸਰੋਤਾਂ ਤੱਕ ਪਹੁੰਚ ਨੂੰ ਨਿਯੰਤਰਿਤ ਕਰਨ ਲਈ ਭੂਮਿਕਾਵਾਂ ਦੀ ਵਰਤੋਂ।
- **ਸੁਰੱਖਿਆ ਐਨੋਟੇਸ਼ਨ**: ਮੈਥਡਾਂ ਅਤੇ ਐਂਡਪੌਇੰਟਾਂ ਨੂੰ ਸੁਰੱਖਿਅਤ ਕਰਨ ਲਈ ਐਨੋਟੇਸ਼ਨਾਂ ਦੀ ਵਰਤੋਂ।

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

- MCP ਐਂਡਪੌਇੰਟਾਂ ਨੂੰ ਸੁਰੱਖਿਅਤ ਕਰਨ ਲਈ Spring Security ਸੰਰਚਿਤ ਕੀਤਾ ਹੈ, ਟੂਲ ਖੋਜ ਲਈ ਜਨਤਕ ਪਹੁੰਚ ਦੀ ਆਗਿਆ ਦਿੰਦੇ ਹੋਏ ਟੂਲ ਕਾਰਗੁਜ਼ਾਰੀ ਲਈ ਪ੍ਰਮਾਣਿਕਤਾ ਲਾਜ਼ਮੀ ਬਣਾਈ ਹੈ।
- MCP ਟੂਲਾਂ ਲਈ ਸੁਰੱਖਿਅਤ ਪਹੁੰਚ ਸੰਭਾਲਣ ਲਈ OAuth2 ਨੂੰ ਰਿਸੋਰਸ ਸਰਵਰ ਵਜੋਂ ਵਰਤਿਆ ਹੈ।
- ਟੂਲ ਕਾਰਗੁਜ਼ਾਰੀ 'ਤੇ ਪਹੁੰਚ ਨਿਯੰਤਰਣ ਲਾਗੂ ਕਰਨ ਲਈ ਸੁਰੱਖਿਆ ਇੰਟਰਸੈਪਟਰ ਬਣਾਇਆ ਹੈ, ਜੋ ਖਾਸ ਟੂਲਾਂ ਤੱਕ ਪਹੁੰਚ ਦੇਣ ਤੋਂ ਪਹਿਲਾਂ ਉਪਭੋਗਤਾ ਭੂਮਿਕਾਵਾਂ ਅਤੇ ਅਧਿਕਾਰਾਂ ਦੀ ਜਾਂਚ ਕਰਦਾ ਹੈ।
- ਉਪਭੋਗਤਾ ਭੂਮਿਕਾਵਾਂ ਦੇ ਆਧਾਰ 'ਤੇ ਐਡਮਿਨ ਟੂਲਾਂ ਅਤੇ ਸੰਵੇਦਨਸ਼ੀਲ ਡਾਟਾ ਤੱਕ ਪਹੁੰਚ ਨੂੰ ਸੀਮਿਤ ਕਰਨ ਲਈ ਭੂਮਿਕਾ-ਆਧਾਰਿਤ ਪਹੁੰਚ ਨਿਯੰਤਰਣ ਨਿਰਧਾਰਿਤ ਕੀਤਾ ਹੈ।

## ਡਾਟਾ ਸੁਰੱਖਿਆ ਅਤੇ ਗੋਪਨੀਯਤਾ

ਡਾਟਾ ਸੁਰੱਖਿਆ ਇਹ ਯਕੀਨੀ ਬਣਾਉਣ ਲਈ ਬਹੁਤ ਜਰੂਰੀ ਹੈ ਕਿ ਸੰਵੇਦਨਸ਼ੀਲ ਜਾਣਕਾਰੀ ਨੂੰ ਸੁਰੱਖਿਅਤ ਤਰੀਕੇ ਨਾਲ ਸੰਭਾਲਿਆ ਜਾਵੇ। ਇਸ ਵਿੱਚ ਨਿੱਜੀ ਪਛਾਣਯੋਗ ਜਾਣਕਾਰੀ (PII), ਵਿੱਤੀ ਡਾਟਾ ਅਤੇ ਹੋਰ ਸੰਵੇਦਨਸ਼ੀਲ ਜਾਣਕਾਰੀ ਨੂੰ ਬਿਨਾਂ ਅਧਿਕਾਰ ਦੇ ਪਹੁੰਚ ਅਤੇ ਚੋਰੀ ਤੋਂ ਬਚਾਉਣਾ ਸ਼ਾਮਲ ਹੈ।

### Python ਡਾਟਾ ਸੁਰੱਖਿਆ ਉਦਾਹਰਨ

ਆਓ ਵੇਖੀਏ ਕਿ ਕਿਵੇਂ Python ਵਿੱਚ ਇਨਕ੍ਰਿਪਸ਼ਨ ਅਤੇ PII ਪਛਾਣ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਡਾਟਾ ਸੁਰੱਖਿਆ ਲਾਗੂ ਕੀਤੀ ਜਾ ਸਕਦੀ ਹੈ।

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

- `PiiDetector` ਕਲਾਸ ਬਣਾਈ ਹੈ ਜੋ ਲਿਖਤ ਅਤੇ ਪੈਰਾਮੀਟਰਾਂ ਵਿੱਚ ਨਿੱਜੀ ਪਛਾਣਯੋਗ ਜਾਣਕਾਰੀ (PII) ਦੀ ਸਕੈਨਿੰਗ ਕਰਦੀ ਹੈ।
- `EncryptionService` ਕਲਾਸ ਬਣਾਈ ਹੈ ਜੋ `cryptography` ਲਾਇਬ੍ਰੇਰੀ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਸੰਵੇਦਨਸ਼ੀਲ ਡਾਟਾ ਦੀ ਇਨਕ੍ਰਿਪਸ਼ਨ ਅਤੇ ਡੀਕ੍ਰਿਪਸ਼ਨ ਸੰਭਾਲਦੀ ਹੈ।
- `secure_tool` ਡੈਕੋਰੇਟਰ ਬਣਾਇਆ ਹੈ ਜੋ ਟੂਲ ਦੀ ਕਾਰਗੁਜ਼ਾਰੀ ਨੂੰ ਲਪੇਟਦਾ ਹੈ ਤਾਂ ਜੋ PII ਦੀ ਜਾਂਚ, ਪਹੁੰਚ ਦਾ ਲੌਗਿੰਗ ਅਤੇ ਜਰੂਰਤ ਪੈਣ 'ਤੇ ਸੰਵੇਦਨਸ਼ੀਲ ਡਾਟਾ ਦੀ ਇਨਕ੍ਰਿਪਸ਼ਨ ਕੀਤੀ ਜਾ ਸਕੇ।
- `secure_tool` ਡੈਕੋਰੇਟਰ ਨੂੰ ਇੱਕ ਨਮੂਨਾ ਟੂਲ (`SecureCustomerDataTool`) 'ਤੇ ਲਾਗੂ ਕੀਤਾ ਹੈ ਤਾਂ ਜੋ ਇਹ ਯਕੀਨੀ ਬਣਾਇਆ ਜਾ ਸਕੇ ਕਿ ਇਹ ਸੰਵੇਦਨਸ਼ੀਲ ਡਾਟਾ ਨੂੰ ਸੁਰੱਖਿਅਤ ਤਰੀਕੇ ਨਾਲ ਸੰਭਾਲਦਾ ਹੈ।

## MCP-ਵਿਸ਼ੇਸ਼ ਸੁਰੱਖਿਆ ਖਤਰੇ

ਸਰਕਾਰੀ MCP ਸੁਰੱਖਿਆ ਦਸਤਾਵੇਜ਼ਾਂ ਅਨੁਸਾਰ, ਕੁਝ ਖਾਸ ਸੁਰੱਖਿਆ ਖਤਰੇ ਹਨ ਜਿਨ੍ਹਾਂ ਤੋਂ MCP ਇੰਪਲੀਮੈਂਟਰਾਂ ਨੂੰ ਸਾਵਧਾਨ ਰਹਿਣਾ ਚਾਹੀਦਾ ਹੈ:

### 1. Confused Deputy ਸਮੱਸਿਆ

ਇਹ ਖਾਮੀ ਉਸ ਵੇਲੇ ਹੁੰਦੀ ਹੈ ਜਦੋਂ MCP ਸਰਵਰ ਤੀਜੀ-ਪੱਖੀ APIਜ਼ ਲਈ ਪ੍ਰਾਕਸੀ ਵਜੋਂ ਕੰਮ ਕਰਦਾ ਹੈ, ਜਿਸ ਨਾਲ ਹਮਲਾਵਰ MCP ਸਰਵਰ ਅਤੇ ਇਹਨਾਂ APIਜ਼ ਵਿਚਕਾਰ ਭਰੋਸੇਯੋਗ ਸੰਬੰਧ ਦਾ ਦੁਰਪਯੋਗ ਕਰ ਸਕਦੇ ਹਨ।

**ਰੋਕਥਾਮ:**
- MCP ਪ੍ਰਾਕਸੀ ਸਰਵਰਾਂ ਨੂੰ ਹਰ ਡਾਇਨਾਮਿਕ ਰਜਿਸਟਰਡ ਕਲਾਇੰਟ ਲਈ ਉਪਭੋਗਤਾ ਦੀ ਸਹਿਮਤੀ ਲੈਣੀ ਚਾਹੀਦੀ ਹੈ, ਇਸ ਤੋਂ ਪਹਿਲਾਂ ਕਿ ਉਹ ਤੀਜੀ-ਪੱਖੀ ਅਧਿਕਾਰ ਸਰਵਰਾਂ ਨੂੰ ਅੱਗੇ ਭੇਜੇ ਜਾਣ।
- ਅਧਿਕਾਰ ਬੇਨਤੀਆਂ ਲਈ PKCE (Proof Key for Code Exchange) ਨਾਲ ਠੀਕ OAuth ਫਲੋ ਲਾਗੂ ਕਰੋ।
- ਰੀਡਾਇਰੈਕਟ URI ਅਤੇ ਕਲਾਇੰਟ ਪਹਿਚਾਣਕਾਰਾਂ ਦੀ ਸਖ਼ਤ ਤਸਦੀਕ ਕਰੋ।

### 2. Token Passthrough ਖਾਮੀਆਂ

ਟੋਕਨ ਪਾਸਥਰੂ ਉਸ ਵੇਲੇ ਹੁੰਦਾ ਹੈ ਜਦ MCP ਸਰਵਰ MCP ਕਲਾਇੰਟ ਤੋਂ ਟੋਕਨ ਸਵੀਕਾਰ ਕਰਦਾ ਹੈ ਬਿਨਾਂ ਇਹ ਜਾਂਚੇ ਕਿ ਟੋਕਨ MCP ਸਰਵਰ ਲਈ ਠੀਕ ਤਰੀਕੇ ਨਾਲ ਜਾਰੀ ਕੀਤੇ ਗਏ ਹਨ ਅਤੇ ਫਿਰ ਉਹਨਾਂ ਨੂੰ ਹੇਠਾਂਲੇ APIਜ਼ ਨੂੰ ਭੇਜਦਾ ਹੈ।

### ਖਤਰੇ
- ਸੁਰੱਖਿਆ ਨਿਯੰਤਰਣਾਂ ਦੀ ਚਾਲਾਕੀ ਨਾਲ ਚਾਲਨਾ (ਜਿਵੇਂ ਕਿ ਰੇਟ ਲਿਮਿਟਿੰਗ, ਬੇਨਤੀ ਵੈਰੀਫਿਕੇਸ਼ਨ)
- ਜਵਾਬਦੇਹੀ ਅਤੇ ਆਡਿਟ ਟ੍ਰੇਲ ਸਮੱਸਿਆਵਾਂ
- ਭਰੋਸਾ ਸੀਮਾ ਉਲੰਘਣਾ
- ਭਵਿੱਖ ਦੀ ਅਨੁਕੂਲਤਾ ਖਤਰੇ

**ਰੋਕਥਾਮ:**
- MCP ਸਰਵਰਾਂ ਨੂੰ ਉਹ ਟੋਕਨ ਕਦੇ ਵੀ ਸਵੀਕਾਰ ਨਹੀਂ ਕਰਨੇ ਚਾਹੀਦੇ ਜੋ ਖਾਸ MCP ਸਰਵਰ ਲਈ ਜਾਰੀ ਨਹੀਂ ਕੀਤੇ ਗਏ।
- ਹਮੇਸ਼ਾ ਟੋਕਨ ਦਰਸ਼ਕ ਦਾਅਵਿਆਂ ਦੀ ਜਾਂਚ ਕਰੋ ਤਾਂ ਜੋ ਇਹ ਯਕੀਨੀ ਬਣਾਇਆ ਜਾ ਸਕੇ ਕਿ ਉਹ ਉਮੀਦ ਕੀਤੀ ਸੇਵਾ ਨਾਲ ਮੇਲ ਖਾਂਦੇ ਹਨ।

### 3. ਸੈਸ਼ਨ ਹਾਈਜੈਕਿੰਗ

ਇਹ ਉਸ ਵੇਲੇ ਹੁੰਦਾ ਹੈ ਜਦੋਂ ਬਿਨਾਂ ਅਧਿਕਾਰ ਵਾਲਾ ਪਾਰਟੀ ਸੈਸ਼ਨ ID ਪ੍ਰਾਪਤ ਕਰ

**ਅਸਵੀਕਾਰੋਪਣ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਅਤ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਮਰਥਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉਤਪੰਨ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।