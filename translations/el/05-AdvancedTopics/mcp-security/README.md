<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e363328861e6e00258187f731a773411",
  "translation_date": "2025-07-17T05:43:15+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "el"
}
-->
# Καλύτερες Πρακτικές Ασφαλείας

Η ασφάλεια είναι κρίσιμη για τις υλοποιήσεις MCP, ειδικά σε επιχειρησιακά περιβάλλοντα. Είναι σημαντικό να διασφαλίζεται ότι τα εργαλεία και τα δεδομένα προστατεύονται από μη εξουσιοδοτημένη πρόσβαση, παραβιάσεις δεδομένων και άλλες απειλές ασφαλείας.

## Εισαγωγή

Το Model Context Protocol (MCP) απαιτεί συγκεκριμένες παραμέτρους ασφαλείας λόγω του ρόλου του στην παροχή πρόσβασης σε LLMs σε δεδομένα και εργαλεία. Αυτό το μάθημα εξερευνά τις καλύτερες πρακτικές ασφαλείας για υλοποιήσεις MCP βασισμένες στις επίσημες οδηγίες MCP και καθιερωμένα πρότυπα ασφαλείας.

Το MCP ακολουθεί βασικές αρχές ασφαλείας για να διασφαλίσει ασφαλείς και αξιόπιστες αλληλεπιδράσεις:

- **Συναίνεση και Έλεγχος Χρήστη**: Οι χρήστες πρέπει να παρέχουν ρητή συναίνεση πριν από την πρόσβαση σε δεδομένα ή την εκτέλεση λειτουργιών. Παρέχετε σαφή έλεγχο σχετικά με τα δεδομένα που μοιράζονται και τις εξουσιοδοτημένες ενέργειες.
  
- **Ιδιωτικότητα Δεδομένων**: Τα δεδομένα των χρηστών πρέπει να εκτίθενται μόνο με ρητή συναίνεση και να προστατεύονται με κατάλληλους μηχανισμούς ελέγχου πρόσβασης. Προστατέψτε από μη εξουσιοδοτημένη μετάδοση δεδομένων.
  
- **Ασφάλεια Εργαλείων**: Πριν από την κλήση οποιουδήποτε εργαλείου, απαιτείται ρητή συναίνεση του χρήστη. Οι χρήστες πρέπει να κατανοούν τη λειτουργικότητα κάθε εργαλείου και να επιβάλλονται αυστηρά όρια ασφαλείας.

## Στόχοι Μάθησης

Στο τέλος αυτού του μαθήματος, θα μπορείτε να:

- Υλοποιείτε ασφαλείς μηχανισμούς αυθεντικοποίησης και εξουσιοδότησης για MCP servers.
- Προστατεύετε ευαίσθητα δεδομένα με κρυπτογράφηση και ασφαλή αποθήκευση.
- Εξασφαλίζετε ασφαλή εκτέλεση εργαλείων με κατάλληλους ελέγχους πρόσβασης.
- Εφαρμόζετε βέλτιστες πρακτικές για προστασία δεδομένων και συμμόρφωση με την ιδιωτικότητα.
- Αναγνωρίζετε και αντιμετωπίζετε κοινές ευπάθειες ασφαλείας MCP όπως το πρόβλημα confused deputy, token passthrough και hijacking συνεδρίας.

## Αυθεντικοποίηση και Εξουσιοδότηση

Η αυθεντικοποίηση και η εξουσιοδότηση είναι απαραίτητες για την ασφάλεια των MCP servers. Η αυθεντικοποίηση απαντά στο "Ποιος είσαι;" ενώ η εξουσιοδότηση στο "Τι μπορείς να κάνεις;".

Σύμφωνα με τις προδιαγραφές ασφαλείας MCP, αυτές είναι κρίσιμες παράμετροι ασφαλείας:

1. **Επικύρωση Token**: Οι MCP servers ΔΕΝ ΠΡΕΠΕΙ να αποδέχονται tokens που δεν έχουν εκδοθεί ρητά για τον MCP server. Το "token passthrough" είναι ρητά απαγορευμένο αντι-πρότυπο.

2. **Επαλήθευση Εξουσιοδότησης**: Οι MCP servers που υλοποιούν εξουσιοδότηση ΠΡΕΠΕΙ να επαληθεύουν όλα τα εισερχόμενα αιτήματα και ΔΕΝ ΠΡΕΠΕΙ να χρησιμοποιούν συνεδρίες για αυθεντικοποίηση.

3. **Ασφαλής Διαχείριση Συνεδριών**: Όταν χρησιμοποιούνται συνεδρίες για κατάσταση, οι MCP servers ΠΡΕΠΕΙ να χρησιμοποιούν ασφαλή, μη-ντετερμινιστικά IDs συνεδρίας που παράγονται με ασφαλείς γεννήτριες τυχαίων αριθμών. Τα IDs συνεδρίας ΠΡΕΠΕΙ να συνδέονται με πληροφορίες συγκεκριμένου χρήστη.

4. **Ρητή Συναίνεση Χρήστη**: Για proxy servers, οι υλοποιήσεις MCP ΠΡΕΠΕΙ να λαμβάνουν τη συναίνεση του χρήστη για κάθε δυναμικά εγγεγραμμένο πελάτη πριν την προώθηση σε τρίτους εξουσιοδοτικούς servers.

Ας δούμε παραδείγματα υλοποίησης ασφαλούς αυθεντικοποίησης και εξουσιοδότησης σε MCP servers με χρήση .NET και Java.

### Ενσωμάτωση .NET Identity

Το ASP .NET Core Identity παρέχει ένα ισχυρό πλαίσιο για τη διαχείριση αυθεντικοποίησης και εξουσιοδότησης χρηστών. Μπορούμε να το ενσωματώσουμε με MCP servers για να ασφαλίσουμε την πρόσβαση σε εργαλεία και πόρους.

Υπάρχουν βασικές έννοιες που πρέπει να κατανοήσουμε κατά την ενσωμάτωση του ASP.NET Core Identity με MCP servers, συγκεκριμένα:

- **Διαμόρφωση Identity**: Ρύθμιση του ASP.NET Core Identity με ρόλους και claims χρηστών. Ένα claim είναι μια πληροφορία για τον χρήστη, όπως ο ρόλος ή τα δικαιώματά του, π.χ. "Admin" ή "User".
- **Αυθεντικοποίηση JWT**: Χρήση JSON Web Tokens (JWT) για ασφαλή πρόσβαση API. Το JWT είναι ένα πρότυπο για ασφαλή μετάδοση πληροφοριών μεταξύ μερών ως JSON αντικείμενο, το οποίο μπορεί να επαληθευτεί και να εμπιστευτεί επειδή είναι ψηφιακά υπογεγραμμένο.
- **Πολιτικές Εξουσιοδότησης**: Ορισμός πολιτικών για τον έλεγχο πρόσβασης σε συγκεκριμένα εργαλεία βάσει ρόλων χρηστών. Το MCP χρησιμοποιεί πολιτικές εξουσιοδότησης για να καθορίσει ποιοι χρήστες μπορούν να έχουν πρόσβαση σε ποια εργαλεία βάσει των ρόλων και claims τους.

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

- Διαμορφώσει το ASP.NET Core Identity για διαχείριση χρηστών.
- Ρυθμίσει την αυθεντικοποίηση JWT για ασφαλή πρόσβαση API. Ορίσαμε τις παραμέτρους επικύρωσης token, συμπεριλαμβανομένου του εκδότη, του κοινού και του κλειδιού υπογραφής.
- Ορίσει πολιτικές εξουσιοδότησης για τον έλεγχο πρόσβασης σε εργαλεία βάσει ρόλων χρηστών. Για παράδειγμα, η πολιτική "CanUseAdminTools" απαιτεί ο χρήστης να έχει ρόλο "Admin", ενώ η πολιτική "CanUseBasic" απαιτεί ο χρήστης να είναι αυθεντικοποιημένος.
- Καταχωρήσει εργαλεία MCP με συγκεκριμένες απαιτήσεις εξουσιοδότησης, διασφαλίζοντας ότι μόνο χρήστες με κατάλληλους ρόλους μπορούν να έχουν πρόσβαση.

### Ενσωμάτωση Java Spring Security

Για Java, θα χρησιμοποιήσουμε το Spring Security για να υλοποιήσουμε ασφαλή αυθεντικοποίηση και εξουσιοδότηση για MCP servers. Το Spring Security παρέχει ένα ολοκληρωμένο πλαίσιο ασφαλείας που ενσωματώνεται άψογα με εφαρμογές Spring.

Οι βασικές έννοιες εδώ είναι:

- **Διαμόρφωση Spring Security**: Ρύθμιση παραμέτρων ασφαλείας για αυθεντικοποίηση και εξουσιοδότηση.
- **OAuth2 Resource Server**: Χρήση OAuth2 για ασφαλή πρόσβαση σε εργαλεία MCP. Το OAuth2 είναι ένα πλαίσιο εξουσιοδότησης που επιτρέπει σε τρίτες υπηρεσίες να ανταλλάσσουν access tokens για ασφαλή πρόσβαση API.
- **Security Interceptors**: Υλοποίηση interceptors ασφαλείας για επιβολή ελέγχων πρόσβασης στην εκτέλεση εργαλείων.
- **Έλεγχος Πρόσβασης Βασισμένος σε Ρόλους**: Χρήση ρόλων για τον έλεγχο πρόσβασης σε συγκεκριμένα εργαλεία και πόρους.
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
- Χρησιμοποιήσει το OAuth2 ως resource server για τη διαχείριση ασφαλούς πρόσβασης σε εργαλεία MCP.
- Υλοποιήσει security interceptor για την επιβολή ελέγχων πρόσβασης στην εκτέλεση εργαλείων, ελέγχοντας ρόλους και δικαιώματα πριν επιτραπεί η πρόσβαση σε συγκεκριμένα εργαλεία.
- Ορίσει έλεγχο πρόσβασης βάσει ρόλων για τον περιορισμό πρόσβασης σε εργαλεία διαχείρισης και ευαίσθητα δεδομένα βάσει ρόλων χρηστών.

## Προστασία Δεδομένων και Ιδιωτικότητα

Η προστασία δεδομένων είναι κρίσιμη για να διασφαλιστεί ότι οι ευαίσθητες πληροφορίες διαχειρίζονται με ασφάλεια. Αυτό περιλαμβάνει την προστασία προσωπικών δεδομένων (PII), οικονομικών δεδομένων και άλλων ευαίσθητων πληροφοριών από μη εξουσιοδοτημένη πρόσβαση και παραβιάσεις.

### Παράδειγμα Προστασίας Δεδομένων σε Python

Ας δούμε ένα παράδειγμα υλοποίησης προστασίας δεδομένων σε Python με χρήση κρυπτογράφησης και ανίχνευσης PII.

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

- Υλοποιήσει την κλάση `PiiDetector` για σάρωση κειμένου και παραμέτρων για προσωπικά αναγνωρίσιμες πληροφορίες (PII).
- Δημιουργήσει την κλάση `EncryptionService` για την κρυπτογράφηση και αποκρυπτογράφηση ευαίσθητων δεδομένων χρησιμοποιώντας τη βιβλιοθήκη `cryptography`.
- Ορίσει τον διακοσμητή `secure_tool` που τυλίγει την εκτέλεση εργαλείων για να ελέγχει για PII, να καταγράφει την πρόσβαση και να κρυπτογραφεί ευαίσθητα δεδομένα αν απαιτείται.
- Εφαρμόσει τον διακοσμητή `secure_tool` σε ένα δείγμα εργαλείου (`SecureCustomerDataTool`) για να διασφαλίσει ότι διαχειρίζεται τα ευαίσθητα δεδομένα με ασφάλεια.

## Ειδικοί Κίνδυνοι Ασφαλείας MCP

Σύμφωνα με την επίσημη τεκμηρίωση ασφαλείας MCP, υπάρχουν συγκεκριμένοι κίνδυνοι ασφαλείας που πρέπει να γνωρίζουν οι υλοποιητές MCP:

### 1. Πρόβλημα Confused Deputy

Αυτή η ευπάθεια εμφανίζεται όταν ένας MCP server λειτουργεί ως proxy σε τρίτα APIs, επιτρέποντας ενδεχομένως σε επιτιθέμενους να εκμεταλλευτούν τη σχέση εμπιστοσύνης μεταξύ MCP server και αυτών των APIs.

**Αντιμετώπιση:**
- Οι MCP proxy servers που χρησιμοποιούν στατικά client IDs ΠΡΕΠΕΙ να λαμβάνουν τη συναίνεση του χρήστη για κάθε δυναμικά εγγεγραμμένο πελάτη πριν την προώθηση σε τρίτους εξουσιοδοτικούς servers.
- Υλοποίηση σωστού OAuth flow με PKCE (Proof Key for Code Exchange) για αιτήματα εξουσιοδότησης.
- Αυστηρή επικύρωση των redirect URIs και των client identifiers.

### 2. Ευπάθειες Token Passthrough

Το token passthrough συμβαίνει όταν ένας MCP server αποδέχεται tokens από έναν MCP client χωρίς να επαληθεύει ότι τα tokens έχουν εκδοθεί σωστά για τον MCP server και τα προωθεί σε downstream APIs.

### Κίνδυνοι
- Παράκαμψη ελέγχων ασφαλείας (π.χ. περιορισμός ρυθμού, επικύρωση αιτημάτων)
- Προβλήματα λογοδοσίας και καταγραφής
- Παραβιάσεις ορίων εμπιστοσύνης
- Κίνδυνοι συμβατότητας στο μέλλον

**Αντιμετώπιση:**
- Οι MCP servers ΔΕΝ ΠΡΕΠΕΙ να αποδέχονται tokens που δεν έχουν εκδοθεί ρητά για τον MCP server.
- Πάντα επικυρώνετε τα claims του κοινού (audience) του token για να βεβαιωθείτε ότι ταιριάζουν με την αναμενόμενη υπηρεσία.

### 3. Hijacking Συνεδρίας

Αυτό συμβαίνει όταν ένα μη εξουσιοδοτημένο μέρος αποκτά ένα session ID και το χρησιμοποιεί για να προσποιηθεί τον αρχικό πελάτη, ενδεχομένως οδηγώντας σε μη εξουσιοδοτημένες ενέργειες.

**Αντιμετώπιση:**
- Οι MCP servers που υλοποιούν εξουσιοδότηση ΠΡΕΠΕΙ να επαληθεύουν όλα τα εισερχόμενα αιτήματα και ΔΕΝ ΠΡΕΠΕΙ να χρησιμοποιούν συνεδρίες για αυθεντικοποίηση.
- Χρησιμοποιήστε ασφαλή, μη-ντετερμινιστικά IDs συνεδρίας που παράγονται με ασφαλείς γεννήτριες τυχαίων αριθμών.
- Συνδέστε τα IDs συνεδρίας με πληροφορίες συγκεκριμένου χρήστη χρησιμοποιώντας μορφή κλειδιού όπως `<user_id>:<session_id>`.
- Υλοποιήστε σωστές πολιτικές λήξης και ανανέωσης συνεδριών.

## Επιπλέον Καλύτερες Πρακτικές Ασφαλείας για MCP

Πέρα από τις βασικές παραμέτρους ασφαλείας MCP, εξετάστε την υλοποίηση των παρακάτω πρακτικών:

- **Χρησιμοποιείτε πάντα HTTPS**: Κρυπτογραφήστε την επικοινωνία μεταξύ πελάτη και server για να προστατεύσετε τα tokens από υποκλοπή.
- **Εφαρμόστε Έλεγχο Πρόσβασης Βασισμένο σε Ρόλους (RBAC)**: Μην ελέγχετε μόνο αν ο χρήστης είναι αυθεντικοποιημένος, αλλά και τι δικαιώματα έχει.
- **Παρακολούθηση και καταγραφή**: Καταγράψτε όλα τα γεγονότα αυθεντικοποίησης για να ανιχνεύσετε και να ανταποκριθείτε σε ύποπτη δραστηριότητα.
- **Διαχείριση περιορισμού ρυθμού και throttling**: Υλοποιήστε εκθετική απόσβεση και λογική επανάληψη για ομαλή διαχείριση περιορισμών ρυθμού.
- **Ασφαλής αποθήκευση tokens**: Αποθηκεύστε access tokens και refresh tokens με ασφάλεια χρησιμοποιώντας μηχανισμούς ασφαλούς αποθήκευσης συστήματος ή υπηρεσίες ασφαλούς διαχείρισης κλειδιών.
- **Σκεφτείτε τη χρήση API Management**: Υπηρεσίες όπως το Azure API Management μπορούν να διαχειριστούν αυτόματα πολλά θέματα ασφαλείας, συμπεριλαμβανομένης της αυθεντικοποίησης, εξουσιοδότησης και περιορισμού ρυθμού.

## Αναφορές

- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [MCP Core Concepts](https://modelcontextprotocol.io/docs/concepts/architecture)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)

## Τι ακολουθεί

- [5.9 Web search](../web-search-mcp/README.md)

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που επιδιώκουμε την ακρίβεια, παρακαλούμε να γνωρίζετε ότι οι αυτόματες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη μητρική του γλώσσα πρέπει να θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.