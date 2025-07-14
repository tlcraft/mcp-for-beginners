<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "50d9cd44fa74ad04f716fe31daf0c850",
  "translation_date": "2025-07-14T02:39:56+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "el"
}
-->
# Καλύτερες Πρακτικές Ασφαλείας

Η ασφάλεια είναι κρίσιμη για τις υλοποιήσεις MCP, ειδικά σε επιχειρησιακά περιβάλλοντα. Είναι σημαντικό να διασφαλίσουμε ότι τα εργαλεία και τα δεδομένα προστατεύονται από μη εξουσιοδοτημένη πρόσβαση, παραβιάσεις δεδομένων και άλλες απειλές ασφαλείας.

## Εισαγωγή

Σε αυτό το μάθημα, θα εξερευνήσουμε τις καλύτερες πρακτικές ασφαλείας για τις υλοποιήσεις MCP. Θα καλύψουμε την αυθεντικοποίηση και εξουσιοδότηση, την προστασία δεδομένων, την ασφαλή εκτέλεση εργαλείων και τη συμμόρφωση με κανονισμούς προστασίας προσωπικών δεδομένων.

## Στόχοι Μάθησης

Στο τέλος αυτού του μαθήματος, θα μπορείτε να:

- Υλοποιείτε ασφαλείς μηχανισμούς αυθεντικοποίησης και εξουσιοδότησης για τους MCP servers.
- Προστατεύετε ευαίσθητα δεδομένα χρησιμοποιώντας κρυπτογράφηση και ασφαλή αποθήκευση.
- Εξασφαλίζετε την ασφαλή εκτέλεση εργαλείων με κατάλληλους ελέγχους πρόσβασης.
- Εφαρμόζετε βέλτιστες πρακτικές για την προστασία δεδομένων και τη συμμόρφωση με την ιδιωτικότητα.

## Αυθεντικοποίηση και Εξουσιοδότηση

Η αυθεντικοποίηση και η εξουσιοδότηση είναι απαραίτητες για την ασφάλεια των MCP servers. Η αυθεντικοποίηση απαντά στην ερώτηση «Ποιος είσαι;», ενώ η εξουσιοδότηση στην ερώτηση «Τι μπορείς να κάνεις;».

Ας δούμε παραδείγματα για το πώς να υλοποιήσουμε ασφαλή αυθεντικοποίηση και εξουσιοδότηση σε MCP servers χρησιμοποιώντας .NET και Java.

### Ενσωμάτωση .NET Identity

Το ASP .NET Core Identity παρέχει ένα ισχυρό πλαίσιο για τη διαχείριση της αυθεντικοποίησης και εξουσιοδότησης χρηστών. Μπορούμε να το ενσωματώσουμε με τους MCP servers για να ασφαλίσουμε την πρόσβαση σε εργαλεία και πόρους.

Υπάρχουν βασικές έννοιες που πρέπει να κατανοήσουμε κατά την ενσωμάτωση του ASP.NET Core Identity με τους MCP servers, συγκεκριμένα:

- **Ρύθμιση Identity**: Διαμόρφωση του ASP.NET Core Identity με ρόλους χρηστών και claims. Ένα claim είναι μια πληροφορία για τον χρήστη, όπως ο ρόλος ή τα δικαιώματά του, π.χ. «Admin» ή «User».
- **Αυθεντικοποίηση JWT**: Χρήση JSON Web Tokens (JWT) για ασφαλή πρόσβαση στο API. Το JWT είναι ένα πρότυπο για την ασφαλή μετάδοση πληροφοριών μεταξύ μερών ως αντικείμενο JSON, το οποίο μπορεί να επαληθευτεί και να εμπιστευτεί επειδή είναι ψηφιακά υπογεγραμμένο.
- **Πολιτικές Εξουσιοδότησης**: Ορισμός πολιτικών για τον έλεγχο πρόσβασης σε συγκεκριμένα εργαλεία βάσει ρόλων χρηστών. Το MCP χρησιμοποιεί πολιτικές εξουσιοδότησης για να καθορίσει ποιοι χρήστες μπορούν να έχουν πρόσβαση σε ποια εργαλεία, βάσει των ρόλων και claims τους.

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

Στον παραπάνω κώδικα, έχουμε:

- Διαμορφώσει το ASP.NET Core Identity για τη διαχείριση χρηστών.
- Ρυθμίσει την αυθεντικοποίηση JWT για ασφαλή πρόσβαση στο API. Ορίσαμε τις παραμέτρους επαλήθευσης του token, όπως τον εκδότη, το κοινό και το κλειδί υπογραφής.
- Ορίσει πολιτικές εξουσιοδότησης για τον έλεγχο πρόσβασης σε εργαλεία βάσει ρόλων χρηστών. Για παράδειγμα, η πολιτική "CanUseAdminTools" απαιτεί ο χρήστης να έχει τον ρόλο "Admin", ενώ η πολιτική "CanUseBasic" απαιτεί ο χρήστης να είναι αυθεντικοποιημένος.
- Καταχωρήσει τα εργαλεία MCP με συγκεκριμένες απαιτήσεις εξουσιοδότησης, διασφαλίζοντας ότι μόνο οι χρήστες με τους κατάλληλους ρόλους μπορούν να έχουν πρόσβαση σε αυτά.

### Ενσωμάτωση Java Spring Security

Για τη Java, θα χρησιμοποιήσουμε το Spring Security για να υλοποιήσουμε ασφαλή αυθεντικοποίηση και εξουσιοδότηση για τους MCP servers. Το Spring Security παρέχει ένα ολοκληρωμένο πλαίσιο ασφαλείας που ενσωματώνεται άψογα με εφαρμογές Spring.

Οι βασικές έννοιες εδώ είναι:

- **Διαμόρφωση Spring Security**: Ρύθμιση των ρυθμίσεων ασφαλείας για αυθεντικοποίηση και εξουσιοδότηση.
- **OAuth2 Resource Server**: Χρήση OAuth2 για ασφαλή πρόσβαση στα εργαλεία MCP. Το OAuth2 είναι ένα πλαίσιο εξουσιοδότησης που επιτρέπει σε τρίτες υπηρεσίες να ανταλλάσσουν access tokens για ασφαλή πρόσβαση στο API.
- **Security Interceptors**: Υλοποίηση interceptors ασφαλείας για την επιβολή ελέγχων πρόσβασης κατά την εκτέλεση εργαλείων.
- **Έλεγχος Πρόσβασης με Βάση Ρόλους**: Χρήση ρόλων για τον έλεγχο πρόσβασης σε συγκεκριμένα εργαλεία και πόρους.
- **Security Annotations**: Χρήση annotations για την ασφάλεια μεθόδων και endpoints.

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

Στον παραπάνω κώδικα, έχουμε:

- Διαμορφώσει το Spring Security για την ασφάλεια των MCP endpoints, επιτρέποντας δημόσια πρόσβαση στην ανακάλυψη εργαλείων ενώ απαιτείται αυθεντικοποίηση για την εκτέλεση εργαλείων.
- Χρησιμοποιήσει το OAuth2 ως resource server για τη διαχείριση ασφαλούς πρόσβασης στα εργαλεία MCP.
- Υλοποιήσει έναν security interceptor για την επιβολή ελέγχων πρόσβασης κατά την εκτέλεση εργαλείων, ελέγχοντας τους ρόλους και τα δικαιώματα των χρηστών πριν επιτραπεί η πρόσβαση σε συγκεκριμένα εργαλεία.
- Ορίσει έλεγχο πρόσβασης με βάση ρόλους για τον περιορισμό πρόσβασης σε εργαλεία διαχείρισης και ευαίσθητα δεδομένα, βάσει των ρόλων των χρηστών.

## Προστασία Δεδομένων και Ιδιωτικότητα

Η προστασία δεδομένων είναι κρίσιμη για να διασφαλιστεί ότι οι ευαίσθητες πληροφορίες διαχειρίζονται με ασφάλεια. Αυτό περιλαμβάνει την προστασία προσωπικών δεδομένων (PII), οικονομικών στοιχείων και άλλων ευαίσθητων πληροφοριών από μη εξουσιοδοτημένη πρόσβαση και παραβιάσεις.

### Παράδειγμα Προστασίας Δεδομένων σε Python

Ας δούμε ένα παράδειγμα για το πώς να υλοποιήσουμε προστασία δεδομένων σε Python χρησιμοποιώντας κρυπτογράφηση και ανίχνευση PII.

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

Στον παραπάνω κώδικα, έχουμε:

- Υλοποιήσει την κλάση `PiiDetector` για να σαρώσει κείμενο και παραμέτρους για προσωπικά αναγνωρίσιμες πληροφορίες (PII).
- Δημιουργήσει την κλάση `EncryptionService` για να χειρίζεται την κρυπτογράφηση και αποκρυπτογράφηση ευαίσθητων δεδομένων χρησιμοποιώντας τη βιβλιοθήκη `cryptography`.
- Ορίσει τον διακοσμητή `secure_tool` που τυλίγει την εκτέλεση εργαλείων για να ελέγχει για PII, να καταγράφει την πρόσβαση και να κρυπτογραφεί ευαίσθητα δεδομένα αν απαιτείται.
- Εφαρμόσει τον διακοσμητή `secure_tool` σε ένα δείγμα εργαλείου (`SecureCustomerDataTool`) για να διασφαλίσει ότι διαχειρίζεται τα ευαίσθητα δεδομένα με ασφάλεια.

## Τι ακολουθεί

- [5.9 Web search](../web-search-mcp/README.md)

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που επιδιώκουμε την ακρίβεια, παρακαλούμε να έχετε υπόψη ότι οι αυτόματες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη γλώσσα του θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.