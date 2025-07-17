<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e363328861e6e00258187f731a773411",
  "translation_date": "2025-07-17T06:55:12+00:00",
  "source_file": "05-AdvancedTopics/mcp-security/README.md",
  "language_code": "fi"
}
-->
# Turvallisuuden parhaat käytännöt

Turvallisuus on ratkaisevan tärkeää MCP-toteutuksissa, erityisesti yritysympäristöissä. On tärkeää varmistaa, että työkalut ja tiedot ovat suojattuja luvattomalta käytöltä, tietomurroilta ja muilta turvallisuusuhkilta.

## Johdanto

Model Context Protocol (MCP) vaatii erityisiä turvallisuusnäkökohtia, koska se tarjoaa LLM-malleille pääsyn tietoihin ja työkaluihin. Tässä oppitunnissa käsitellään MCP-toteutusten turvallisuuden parhaita käytäntöjä virallisten MCP-ohjeiden ja vakiintuneiden turvallisuusmallien pohjalta.

MCP noudattaa keskeisiä turvallisuusperiaatteita varmistaakseen turvalliset ja luotettavat vuorovaikutukset:

- **Käyttäjän suostumus ja hallinta**: Käyttäjän on annettava nimenomainen suostumus ennen kuin mitään tietoja käytetään tai toimintoja suoritetaan. Tarjoa selkeä hallinta siitä, mitä tietoja jaetaan ja mitkä toimet ovat sallittuja.
  
- **Tietosuoja**: Käyttäjätiedot tulee paljastaa vain nimenomaisella suostumuksella ja suojata asianmukaisin käyttöoikeuksin. Estä luvaton tiedonsiirto.
  
- **Työkalujen turvallisuus**: Ennen työkalun kutsumista vaaditaan käyttäjän nimenomainen suostumus. Käyttäjien tulee ymmärtää kunkin työkalun toiminnallisuus, ja tiukat turvallisuusrajat on toteutettava.

## Oppimistavoitteet

Tämän oppitunnin jälkeen osaat:

- Toteuttaa turvalliset todennus- ja valtuutusmekanismit MCP-palvelimille.
- Suojata arkaluontoiset tiedot salauksella ja turvallisella tallennuksella.
- Varmistaa työkalujen turvallisen suorittamisen asianmukaisin käyttöoikeuksin.
- Soveltaa parhaita käytäntöjä tietosuojaan ja tietosuojavaatimusten noudattamiseen.
- Tunnistaa ja ehkäistä yleisiä MCP-turvallisuusongelmia, kuten confused deputy -ongelma, token passthrough ja istunnon kaappaus.

## Todennus ja valtuutus

Todennus ja valtuutus ovat olennaisia MCP-palvelimien suojaamisessa. Todennus vastaa kysymykseen "Kuka olet?" ja valtuutus kysymykseen "Mitä voit tehdä?".

MCP:n turvallisuusmäärittelyn mukaan nämä ovat kriittisiä turvallisuusnäkökohtia:

1. **Tokenin validointi**: MCP-palvelimet EIVÄT SAA HYVÄKSYÄ mitään tokeneita, joita ei ole nimenomaisesti myönnetty kyseiselle MCP-palvelimelle. "Token passthrough" on nimenomaan kielletty anti-malli.

2. **Valtuutuksen tarkistus**: MCP-palvelimet, jotka toteuttavat valtuutuksen, TÄYTYY tarkistaa kaikki saapuvat pyynnöt, eikä niiden tule käyttää istuntoja todennukseen.

3. **Turvallinen istunnonhallinta**: Käytettäessä istuntoja tilan hallintaan MCP-palvelimien TÄYTYY käyttää turvallisia, ei-deterministisiä istuntotunnuksia, jotka on luotu turvallisilla satunnaislukugeneraattoreilla. Istuntotunnukset TULISI sitoa käyttäjäkohtaisiin tietoihin.

4. **Nimenomainen käyttäjän suostumus**: Välityspalvelimissa MCP-toteutusten TÄYTYY hankkia käyttäjän suostumus jokaiselle dynaamisesti rekisteröidylle asiakkaalle ennen pyyntöjen välittämistä kolmannen osapuolen valtuutuspalvelimille.

Katsotaan esimerkkejä siitä, miten toteuttaa turvallinen todennus ja valtuutus MCP-palvelimissa .NET- ja Java-ympäristöissä.

### .NET Identity -integraatio

ASP .NET Core Identity tarjoaa vankan kehyksen käyttäjien todennuksen ja valtuutuksen hallintaan. Voimme integroida sen MCP-palvelimiin työkalujen ja resurssien turvallisen käytön varmistamiseksi.

Tässä muutamia keskeisiä käsitteitä, jotka on hyvä ymmärtää ASP.NET Core Identityn integroinnissa MCP-palvelimiin:

- **Identityn konfigurointi**: ASP.NET Core Identityn määrittäminen käyttäjärooleineen ja -väitteineen. Väite on tieto käyttäjästä, kuten rooli tai käyttöoikeus, esimerkiksi "Admin" tai "User".
- **JWT-todennus**: JSON Web Tokenien (JWT) käyttö turvalliseen API-pääsyyn. JWT on standardi tietojen turvalliseen siirtoon osapuolten välillä JSON-objektina, joka voidaan varmentaa ja johon voidaan luottaa, koska se on digitaalisesti allekirjoitettu.
- **Valtuutuspolitiikat**: Politiikkojen määrittely, joilla hallitaan pääsyä tiettyihin työkaluihin käyttäjäroolien perusteella. MCP käyttää valtuutuspolitiikkoja määrittämään, ketkä käyttäjät pääsevät mihinkin työkaluihin rooliensa ja väitteidensä perusteella.

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

Edellisessä koodissa olemme:

- Konfiguroineet ASP.NET Core Identityn käyttäjähallintaa varten.
- Määrittäneet JWT-todennuksen turvallista API-pääsyä varten. Määrittelimme tokenin validointiparametrit, kuten julkaisijan, vastaanottajan ja allekirjoitusavaimen.
- Määritelleet valtuutuspolitiikat työkalujen käyttöoikeuksien hallintaan käyttäjäroolien perusteella. Esimerkiksi "CanUseAdminTools" -politiikka vaatii käyttäjältä "Admin"-roolin, kun taas "CanUseBasic" -politiikka edellyttää käyttäjän olevan todennettu.
- Rekisteröineet MCP-työkaluja, joilla on erityiset valtuutusvaatimukset, varmistaen että vain oikeilla rooleilla varustetut käyttäjät pääsevät niihin käsiksi.

### Java Spring Security -integraatio

Javassa käytämme Spring Securityä toteuttamaan turvallisen todennuksen ja valtuutuksen MCP-palvelimille. Spring Security tarjoaa kattavan turvallisuuskehyksen, joka integroituu saumattomasti Spring-sovelluksiin.

Keskeiset käsitteet ovat:

- **Spring Securityn konfigurointi**: Turvallisuusasetusten määrittäminen todennusta ja valtuutusta varten.
- **OAuth2-resurssipalvelin**: OAuth2:n käyttö MCP-työkalujen turvalliseen käyttöön. OAuth2 on valtuutuskehys, joka mahdollistaa kolmansien osapuolien vaihtaa käyttöoikeustokeneita turvallista API-pääsyä varten.
- **Turvallisuusinterseptorit**: Turvallisuusinterseptorien toteutus työkalujen käytön valvontaan.
- **Roolipohjainen pääsynhallinta**: Roolien käyttö pääsyn rajoittamiseen tiettyihin työkaluihin ja resursseihin.
- **Turvallisuusannotaatiot**: Annotaatiot metodien ja päätepisteiden suojaamiseen.

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

Edellisessä koodissa olemme:

- Konfiguroineet Spring Securityn suojaamaan MCP-päätepisteitä, sallien julkisen pääsyn työkalujen löytämiseen, mutta vaativat todennuksen työkalujen suorittamiseen.
- Käyttäneet OAuth2:ta resurssipalvelimena MCP-työkalujen turvallisen käytön hallintaan.
- Toteuttaneet turvallisuusinterseptorin, joka valvoo pääsyä työkalujen suorittamiseen tarkistamalla käyttäjäroolit ja -oikeudet ennen pääsyn myöntämistä.
- Määritelleet roolipohjaisen pääsynhallinnan rajoittamaan pääsyä ylläpitäjätyökaluihin ja arkaluontoisiin tietoihin käyttäjäroolien perusteella.

## Tietosuoja ja yksityisyys

Tietosuoja on ratkaisevan tärkeää arkaluontoisten tietojen turvallisessa käsittelyssä. Tämä koskee henkilötietoja (PII), taloustietoja ja muita arkaluontoisia tietoja, jotka on suojattava luvattomalta käytöltä ja tietomurroilta.

### Python-esimerkki tietosuojasta

Katsotaan esimerkki tietosuojan toteuttamisesta Pythonilla salauksen ja PII-tunnistuksen avulla.

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

Edellisessä koodissa olemme:

- Toteuttaneet `PiiDetector`-luokan, joka skannaa tekstiä ja parametreja henkilötietojen (PII) varalta.
- Luoneet `EncryptionService`-luokan, joka hoitaa arkaluontoisten tietojen salauksen ja purun `cryptography`-kirjaston avulla.
- Määritelleet `secure_tool`-koristelijan, joka käärii työkalun suorituksen tarkistaen PII:n, kirjaa käytön ja salaa arkaluontoiset tiedot tarvittaessa.
- Käyttäneet `secure_tool`-koristelijaa esimerkkityökalussa (`SecureCustomerDataTool`) varmistaaksemme, että se käsittelee arkaluontoisia tietoja turvallisesti.

## MCP-kohtaiset turvallisuusriskit

Virallisen MCP-turvallisuusdokumentaation mukaan MCP-toteuttajien tulee olla tietoisia seuraavista erityisistä turvallisuusriskeistä:

### 1. Confused Deputy -ongelma

Tämä haavoittuvuus ilmenee, kun MCP-palvelin toimii välityspalvelimena kolmansien osapuolten API:ille, mikä voi antaa hyökkääjille mahdollisuuden hyödyntää MCP-palvelimen ja näiden API:iden välistä luottamussuhdetta.

**Ehkäisy:**
- MCP-välityspalvelimien, jotka käyttävät staattisia asiakastunnuksia, TÄYTYY hankkia käyttäjän suostumus jokaiselle dynaamisesti rekisteröidylle asiakkaalle ennen pyyntöjen välittämistä kolmannen osapuolen valtuutuspalvelimille.
- Toteuta asianmukainen OAuth-prosessi PKCE:n (Proof Key for Code Exchange) kanssa valtuutuspyyntöihin.
- Tarkista tiukasti uudelleenohjaus-URI:t ja asiakastunnukset.

### 2. Token Passthrough -haavoittuvuudet

Token passthrough tapahtuu, kun MCP-palvelin hyväksyy tokeneita MCP-asiakkaalta ilman, että se varmistaa, että tokenit on myönnetty oikein kyseiselle MCP-palvelimelle, ja välittää ne edelleen alaspäin oleville API:ille.

### Riskit
- Turvallisuusvalvonnan kiertäminen (esim. rajoitusten ja pyyntöjen validoinnin ohittaminen)
- Vastuu- ja auditointiongelmat
- Luottamusrajojen rikkominen
- Tulevaisuuden yhteensopivuusongelmat

**Ehkäisy:**
- MCP-palvelimet EIVÄT SAA HYVÄKSYÄ mitään tokeneita, joita ei ole nimenomaisesti myönnetty kyseiselle MCP-palvelimelle.
- Varmista aina tokenin vastaanottajaväitteiden (audience claims) vastaavuus odotettuun palveluun.

### 3. Istunnon kaappaus

Tämä tapahtuu, kun luvaton osapuoli saa haltuunsa istuntotunnuksen ja käyttää sitä esiintyäkseen alkuperäisenä asiakkaana, mikä voi johtaa luvattomiin toimiin.

**Ehkäisy:**
- MCP-palvelimet, jotka toteuttavat valtuutuksen, TÄYTYY tarkistaa kaikki saapuvat pyynnöt, eikä niiden tule käyttää istuntoja todennukseen.
- Käytä turvallisia, ei-deterministisiä istuntotunnuksia, jotka on luotu turvallisilla satunnaislukugeneraattoreilla.
- Sido istuntotunnukset käyttäjäkohtaisiin tietoihin esimerkiksi muodossa `<user_id>:<session_id>`.
- Toteuta asianmukaiset istunnon vanhentumis- ja kierrätyskäytännöt.

## Lisäturvallisuuden parhaat käytännöt MCP:lle

Ydinturvallisuusnäkökohtien lisäksi harkitse seuraavia lisäkäytäntöjä:

- **Käytä aina HTTPS-yhteyttä**: Salaa asiakas- ja palvelinvälinen liikenne suojataksesi tokeneita sieppaukselta.
- **Toteuta roolipohjainen pääsynhallinta (RBAC)**: Älä pelkästään tarkista, onko käyttäjä todennettu, vaan myös mitä hän saa tehdä.
- **Seuraa ja auditoi**: Kirjaa kaikki todennustapahtumat epäilyttävän toiminnan havaitsemiseksi ja siihen reagoimiseksi.
- **Käsittele rajoitukset ja kuormituksen hallinta**: Toteuta eksponentiaalinen takaisinotto ja uudelleenyritykset rajoitusten hallintaan.
- **Säilytä tokenit turvallisesti**: Tallenna käyttö- ja päivitystokenit turvallisesti järjestelmän suojausmekanismeilla tai avainhallintapalveluilla.
- **Harkitse API-hallinnan käyttöä**: Palvelut kuten Azure API Management voivat hoitaa monia turvallisuusasioita automaattisesti, mukaan lukien todennus, valtuutus ja kuormituksen hallinta.

## Viitteet

- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [MCP Core Concepts](https://modelcontextprotocol.io/docs/concepts/architecture)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)

## Mitä seuraavaksi

- [5.9 Web search](../web-search-mcp/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.