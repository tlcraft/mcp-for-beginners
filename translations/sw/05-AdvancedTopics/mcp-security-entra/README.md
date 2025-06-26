<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9abe1d303ab126f9a8b87f03cebe5213",
  "translation_date": "2025-06-26T14:56:24+00:00",
  "source_file": "05-AdvancedTopics/mcp-security-entra/README.md",
  "language_code": "sw"
}
-->
# Kuweka Usalama katika Mipango ya AI: Uthibitishaji wa Entra ID kwa Seva za Model Context Protocol

## Utangulizi  
Kuweka usalama kwenye seva yako ya Model Context Protocol (MCP) ni muhimu kama kufunga mlango wa mbele wa nyumba yako. Kuacha seva yako ya MCP wazi kunaweka zana zako na data kwa hatari ya kufikiwa na watu wasioidhinishwa, jambo linaloweza kusababisha uvunjifu wa usalama. Microsoft Entra ID hutoa suluhisho thabiti la utambuzi na usimamizi wa upatikanaji ulio katika wingu, kusaidia kuhakikisha kuwa watumiaji na programu zilizoidhinishwa pekee ndizo zinaweza kuwasiliana na seva yako ya MCP. Katika sehemu hii, utajifunza jinsi ya kulinda mipango yako ya AI kwa kutumia uthibitishaji wa Entra ID.

## Malengo ya Kujifunza  
Mwisho wa sehemu hii, utaweza:

- Kuelewa umuhimu wa kuweka usalama kwa seva za MCP.  
- Kueleza misingi ya Microsoft Entra ID na uthibitishaji wa OAuth 2.0.  
- Kutambua tofauti kati ya wateja wa umma na wateja wa siri.  
- Kutekeleza uthibitishaji wa Entra ID katika mazingira ya seva za MCP za ndani (mteja wa umma) na za mbali (mteja wa siri).  
- Kutumia mbinu bora za usalama wakati wa kuendeleza mipango ya AI.  

# Kuweka Usalama katika Mipango ya AI: Uthibitishaji wa Entra ID kwa Seva za Model Context Protocol

Kama vile hutaki kuacha mlango wa mbele wa nyumba yako wazi, vivyo hivyo haupaswi kuacha seva yako ya MCP wazi kwa mtu yeyote. Kuweka usalama kwenye mipango yako ya AI ni muhimu kwa kujenga programu thabiti, za kuaminika, na salama. Sura hii itakuonesha jinsi ya kutumia Microsoft Entra ID kuimarisha usalama wa seva zako za MCP, kuhakikisha kuwa watumiaji na programu zilizoidhinishwa pekee ndizo zinaweza kuwasiliana na zana zako na data zako.

## Kwa Nini Usalama ni Muhimu kwa Seva za MCP

Fikiria seva yako ya MCP ina zana inayoweza kutuma barua pepe au kufikia hifadhidata ya wateja. Seva isiyo na usalama inamaanisha mtu yeyote anaweza kutumia zana hiyo, na kusababisha ufikiaji usioidhinishwa wa data, barua taka, au shughuli nyingine za uharamia.

Kwa kutumia uthibitishaji, unahakikisha kila ombi kwa seva yako linathibitishwa, kuthibitisha utambulisho wa mtumiaji au programu inayofanya ombi hilo. Hii ni hatua ya kwanza na muhimu zaidi katika kuweka usalama wa mipango yako ya AI.

## Utangulizi kwa Microsoft Entra ID

**Microsoft Entra ID** ni huduma ya utambuzi na usimamizi wa upatikanaji inayotegemea wingu. Fikiria kama mlinzi wa usalama wa jumla kwa programu zako. Huduma hii inashughulikia mchakato mgumu wa kuthibitisha utambulisho wa watumiaji (uthibitishaji) na kuamua wanaruhusiwa kufanya nini (idhinishaji).

Kwa kutumia Entra ID, unaweza:

- Kuwezesha kuingia salama kwa watumiaji.  
- Kulinda API na huduma.  
- Kusimamia sera za upatikanaji kutoka mahali pamoja.  

Kwa seva za MCP, Entra ID hutoa suluhisho thabiti na lenye kuaminika la kusimamia nani anaweza kufikia uwezo wa seva yako.

---

## Kuelewa Sanaa: Jinsi Uthibitishaji wa Entra ID Unavyofanya Kazi

Entra ID hutumia viwango vya wazi kama **OAuth 2.0** kushughulikia uthibitishaji. Ingawa maelezo yake yanaweza kuwa magumu, dhana kuu ni rahisi na inaweza kueleweka kwa mfano.

### Utangulizi Rahisi kwa OAuth 2.0: Ufunguzi wa Valet

Fikiria OAuth 2.0 kama huduma ya valet kwa gari lako. Unapofika mgahawani, hutoi valet ufunguo wako mkuu. Badala yake, unampa **ufunguo wa valet** wenye ruhusa ndogo—unaweza kuwasha gari na kufunga milango, lakini hauwezi kufungua sehemu ya mizigo au sanduku la glovu.

Katika mfano huu:

- **Wewe** ni **Mtumiaji**.  
- **Gari lako** ni **Seva ya MCP** yenye zana na data muhimu.  
- **Valet** ni **Microsoft Entra ID**.  
- **Msaidizi wa Maegesho** ni **Mteja wa MCP** (programu inayojaribu kufikia seva).  
- **Ufunguzi wa Valet** ni **Tokeni ya Upatikanaji**.  

Tokeni ya upatikanaji ni mfululizo salama wa maandishi ambao mteja wa MCP hupokea kutoka Entra ID baada ya wewe kuingia. Kisha mteja huwasilisha tokeni hii kwa seva ya MCP kila mara anapofanya ombi. Seva inaweza kuthibitisha tokeni kuhakikisha ombi ni halali na kwamba mteja ana ruhusa zinazohitajika, yote haya bila kushughulikia nywila zako halisi (kama nenosiri lako).

### Mtiririko wa Uthibitishaji

Hivi ndivyo mchakato unavyofanya kazi kwa vitendo:

```mermaid
sequenceDiagram
    actor User as 👤 User
    participant Client as 🖥️ MCP Client
    participant Entra as 🔐 Microsoft Entra ID
    participant Server as 🔧 MCP Server

    Client->>+User: Please sign in to continue.
    User->>+Entra: Enters credentials (username/password).
    Entra-->>Client: Here is your access token.
    User-->>-Client: (Returns to the application)

    Client->>+Server: I need to use a tool. Here is my access token.
    Server->>+Entra: Is this access token valid?
    Entra-->>-Server: Yes, it is.
    Server-->>-Client: Token is valid. Here is the result of the tool.
```

### Utangulizi wa Maktaba ya Uthibitishaji ya Microsoft (MSAL)

Kabla hatujaingia kwenye msimbo, ni muhimu kuanzisha sehemu muhimu utakayokutana nayo mifano: **Maktaba ya Uthibitishaji ya Microsoft (MSAL)**.

MSAL ni maktaba iliyotengenezwa na Microsoft inayorahisisha sana kwa watengenezaji kushughulikia uthibitishaji. Badala ya wewe kuandika msimbo mgumu wote wa kushughulikia tokeni za usalama, kusimamia kuingia, na kufufua vikao, MSAL hufanya kazi hii nzito.

Kutumia maktaba kama MSAL kunapendekezwa sana kwa sababu:

- **Ni Salama:** Inatekeleza itifaki za viwandani na mbinu bora za usalama, kupunguza hatari ya udhaifu katika msimbo wako.  
- **Inarahisisha Maendeleo:** Inaficha ugumu wa itifaki za OAuth 2.0 na OpenID Connect, ikikuwezesha kuongeza uthibitishaji thabiti kwa programu yako kwa mistari michache tu ya msimbo.  
- **Inadumishwa:** Microsoft inaendelea kudumisha na kusasisha MSAL kukabiliana na vitisho vipya vya usalama na mabadiliko ya jukwaa.  

MSAL inaunga mkono lugha na mifumo mingi ya programu, ikiwa ni pamoja na .NET, JavaScript/TypeScript, Python, Java, Go, na majukwaa ya simu kama iOS na Android. Hii inamaanisha unaweza kutumia mifumo ya uthibitishaji inayolingana katika teknolojia yako yote.

Ili kujifunza zaidi kuhusu MSAL, unaweza kutembelea [nyaraka rasmi za MSAL](https://learn.microsoft.com/entra/identity-platform/msal-overview).

---

## Kuweka Usalama wa Seva Yako ya MCP kwa Entra ID: Mwongozo wa Hatua kwa Hatua

Sasa, tuchukue hatua kwa hatua jinsi ya kuimarisha seva ya MCP ya ndani (inayozungumza kupitia `stdio`) using Entra ID. This example uses a **public client**, which is suitable for applications running on a user's machine, like a desktop app or a local development server.

### Scenario 1: Securing a Local MCP Server (with a Public Client)

In this scenario, we'll look at an MCP server that runs locally, communicates over `stdio`, and uses Entra ID to authenticate the user before allowing access to its tools. The server will have a single tool that fetches the user's profile information from the Microsoft Graph API.

#### 1. Setting Up the Application in Entra ID

Before writing any code, you need to register your application in Microsoft Entra ID. This tells Entra ID about your application and grants it permission to use the authentication service.

1. Navigate to the **[Microsoft Entra portal](https://entra.microsoft.com/)**.
2. Go to **App registrations** and click **New registration**.
3. Give your application a name (e.g., "My Local MCP Server").
4. For **Supported account types**, select **Accounts in this organizational directory only**.
5. You can leave the **Redirect URI** blank for this example.
6. Click **Register**.

Once registered, take note of the **Application (client) ID** and **Directory (tenant) ID**. You'll need these in your code.

#### 2. The Code: A Breakdown

Let's look at the key parts of the code that handle authentication. The full code for this example is available in the [Entra ID - Local - WAM](https://github.com/Azure-Samples/mcp-auth-servers/tree/main/src/entra-id-local-wam) folder of the [mcp-auth-servers GitHub repository](https://github.com/Azure-Samples/mcp-auth-servers).

**`AuthenticationService.cs`**

This class is responsible for handling the interaction with Entra ID.

- **`CreateAsync`**: This method initializes the `PublicClientApplication` from the MSAL (Microsoft Authentication Library). It's configured with your application's `clientId` and `tenantId`.
- **`WithBroker`**: This enables the use of a broker (like the Windows Web Account Manager), which provides a more secure and seamless single sign-on experience.
- **`AcquireTokenAsync`**: Hii ni njia kuu. Kwanza inajaribu kupata tokeni kimya kimya (maana mtumiaji hatahitaji kuingia tena ikiwa tayari ana kikao halali). Ikiwa tokeni ya kimya haiwezi kupatikana, itaomba mtumiaji aingie kwa njia ya mwingiliano.

```csharp
// Simplified for clarity
public static async Task<AuthenticationService> CreateAsync(ILogger<AuthenticationService> logger)
{
    var msalClient = PublicClientApplicationBuilder
        .Create(_clientId) // Your Application (client) ID
        .WithAuthority(AadAuthorityAudience.AzureAdMyOrg)
        .WithTenantId(_tenantId) // Your Directory (tenant) ID
        .WithBroker(new BrokerOptions(BrokerOptions.OperatingSystems.Windows))
        .Build();

    // ... cache registration ...

    return new AuthenticationService(logger, msalClient);
}

public async Task<string> AcquireTokenAsync()
{
    try
    {
        // Try silent authentication first
        var accounts = await _msalClient.GetAccountsAsync();
        var account = accounts.FirstOrDefault();

        AuthenticationResult? result = null;

        if (account != null)
        {
            result = await _msalClient.AcquireTokenSilent(_scopes, account).ExecuteAsync();
        }
        else
        {
            // If no account, or silent fails, go interactive
            result = await _msalClient.AcquireTokenInteractive(_scopes).ExecuteAsync();
        }

        return result.AccessToken;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "An error occurred while acquiring the token.");
        throw; // Optionally rethrow the exception for higher-level handling
    }
}
```

**`Program.cs`**

This is where the MCP server is set up and the authentication service is integrated.

- **`AddSingleton<AuthenticationService>`**: This registers the `AuthenticationService` with the dependency injection container, so it can be used by other parts of the application (like our tool).
- **`GetUserDetailsFromGraph` tool**: This tool requires an instance of `AuthenticationService`. Before it does anything, it calls `authService.AcquireTokenAsync()` kupata tokeni halali ya upatikanaji. Ikiwa uthibitishaji unafanikiwa, hutumia tokeni hii kupiga API ya Microsoft Graph na kupata maelezo ya mtumiaji.

```csharp
// Simplified for clarity
[McpServerTool(Name = "GetUserDetailsFromGraph")]
public static async Task<string> GetUserDetailsFromGraph(
    AuthenticationService authService)
{
    try
    {
        // This will trigger the authentication flow
        var accessToken = await authService.AcquireTokenAsync();

        // Use the token to create a GraphServiceClient
        var graphClient = new GraphServiceClient(
            new BaseBearerTokenAuthenticationProvider(new TokenProvider(authService)));

        var user = await graphClient.Me.GetAsync();

        return System.Text.Json.JsonSerializer.Serialize(user);
    }
    catch (Exception ex)
    {
        return $"Error: {ex.Message}";
    }
}
```

#### 3. Jinsi Kazi Zinavyoshirikiana

1. Mteja wa MCP anapojaribu kutumia `GetUserDetailsFromGraph` tool, the tool first calls `AcquireTokenAsync`.
2. `AcquireTokenAsync` triggers the MSAL library to check for a valid token.
3. If no token is found, MSAL, through the broker, will prompt the user to sign in with their Entra ID account.
4. Once the user signs in, Entra ID issues an access token.
5. The tool receives the token and uses it to make a secure call to the Microsoft Graph API.
6. The user's details are returned to the MCP client.

This process ensures that only authenticated users can use the tool, effectively securing your local MCP server.

### Scenario 2: Securing a Remote MCP Server (with a Confidential Client)

When your MCP server is running on a remote machine (like a cloud server) and communicates over a protocol like HTTP Streaming, the security requirements are different. In this case, you should use a **confidential client** and the **Authorization Code Flow**. This is a more secure method because the application's secrets are never exposed to the browser.

This example uses a TypeScript-based MCP server that uses Express.js to handle HTTP requests.

#### 1. Setting Up the Application in Entra ID

The setup in Entra ID is similar to the public client, but with one key difference: you need to create a **client secret**.

1. Navigate to the **[Microsoft Entra portal](https://entra.microsoft.com/)**.
2. In your app registration, go to the **Certificates & secrets** tab.
3. Click **New client secret**, give it a description, and click **Add**.
4. **Important:** Copy the secret value immediately. You will not be able to see it again.
5. You also need to configure a **Redirect URI**. Go to the **Authentication** tab, click **Add a platform**, select **Web**, and enter the redirect URI for your application (e.g., `http://localhost:3001/auth/callback`).

> **⚠️ Important Security Note:** For production applications, Microsoft strongly recommends using **secretless authentication** methods such as **Managed Identity** or **Workload Identity Federation** instead of client secrets. Client secrets pose security risks as they can be exposed or compromised. Managed identities provide a more secure approach by eliminating the need to store credentials in your code or configuration.
>
> For more information about managed identities and how to implement them, see the [Managed identities for Azure resources overview](https://learn.microsoft.com/entra/identity/managed-identities-azure-resources/overview).

#### 2. The Code: A Breakdown

This example uses a session-based approach. When the user authenticates, the server stores the access token and refresh token in a session and gives the user a session token. This session token is then used for subsequent requests. The full code for this example is available in the [Entra ID - Confidential client](https://github.com/Azure-Samples/mcp-auth-servers/tree/main/src/entra-id-cca-session) folder of the [mcp-auth-servers GitHub repository](https://github.com/Azure-Samples/mcp-auth-servers).

**`Server.ts`**

This file sets up the Express server and the MCP transport layer.

- **`requireBearerAuth`**: This is middleware that protects the `/sse` and `/message` endpoints. It checks for a valid bearer token in the `Authorization` header of the request.
- **`EntraIdServerAuthProvider`**: This is a custom class that implements the `McpServerAuthorizationProvider` interface. It's responsible for handling the OAuth 2.0 flow.
- **`/auth/callback`**: Kituo hiki kinashughulikia mwelekeo kutoka Entra ID baada ya mtumiaji kuthibitishwa. Kinabadili msimbo wa idhini kuwa tokeni ya upatikanaji na tokeni ya kufufua.

```typescript
// Simplified for clarity
const app = express();
const { server } = createServer();
const provider = new EntraIdServerAuthProvider();

// Protect the SSE endpoint
app.get("/sse", requireBearerAuth({
  provider,
  requiredScopes: ["User.Read"]
}), async (req, res) => {
  // ... connect to the transport ...
});

// Protect the message endpoint
app.post("/message", requireBearerAuth({
  provider,
  requiredScopes: ["User.Read"]
}), async (req, res) => {
  // ... handle the message ...
});

// Handle the OAuth 2.0 callback
app.get("/auth/callback", (req, res) => {
  provider.handleCallback(req.query.code, req.query.state)
    .then(result => {
      // ... handle success or failure ...
    });
});
```

**`Tools.ts`**

This file defines the tools that the MCP server provides. The `getUserDetails` zana ni sawa na ile ya mfano uliopita, lakini hupata tokeni ya upatikanaji kutoka kikao.

```typescript
// Simplified for clarity
server.setRequestHandler(CallToolRequestSchema, async (request) => {
  const { name } = request.params;
  const context = request.params?.context as { token?: string } | undefined;
  const sessionToken = context?.token;

  if (name === ToolName.GET_USER_DETAILS) {
    if (!sessionToken) {
      throw new AuthenticationError("Authentication token is missing or invalid. Ensure the token is provided in the request context.");
    }

    // Get the Entra ID token from the session store
    const tokenData = tokenStore.getToken(sessionToken);
    const entraIdToken = tokenData.accessToken;

    const graphClient = Client.init({
      authProvider: (done) => {
        done(null, entraIdToken);
      }
    });

    const user = await graphClient.api('/me').get();

    // ... return user details ...
  }
});
```

**`auth/EntraIdServerAuthProvider.ts`**

This class handles the logic for:

- Redirecting the user to the Entra ID sign-in page.
- Exchanging the authorization code for an access token.
- Storing the tokens in the `tokenStore`.
- Refreshing the access token when it expires.

#### 3. How It All Works Together

1. When a user first tries to connect to the MCP server, the `requireBearerAuth` middleware will see that they don't have a valid session and will redirect them to the Entra ID sign-in page.
2. The user signs in with their Entra ID account.
3. Entra ID redirects the user back to the `/auth/callback` endpoint with an authorization code.
4. The server exchanges the code for an access token and a refresh token, stores them, and creates a session token which is sent to the client.
5. The client can now use this session token in the `Authorization` header for all future requests to the MCP server.
6. When the `getUserDetails` zana inapoitwa, hutumia tokeni ya kikao kutafuta tokeni ya upatikanaji ya Entra ID kisha hutumia hiyo kupiga Microsoft Graph API.

Mtiririko huu ni mgumu zaidi kuliko wa mteja wa umma, lakini unahitajika kwa vituo vinavyoelekezwa mtandaoni. Kwa kuwa seva za MCP za mbali zinapatikana kupitia intaneti ya umma, zinahitaji hatua madhubuti za usalama ili kuzuia ufikiaji usioidhinishwa na mashambulizi yanayoweza kutokea.

## Mbinu Bora za Usalama

- **Daima tumia HTTPS**: Ficha mawasiliano kati ya mteja na seva ili kulinda tokeni zisikamatwe.  
- **Tekeleza Udhibiti wa Upatikanaji kwa Kazi (RBAC)**: Usijaribu tu kuthibitisha *ikiwa* mtumiaji ameingia; hakikisha unachunguza *nini* wanaruhusiwa kufanya. Unaweza kufafanua majukumu katika Entra ID na kuyakagua kwenye seva yako ya MCP.  
- **Fuatilia na kagua**: Andika matukio yote ya uthibitishaji ili uweze kugundua na kujibu shughuli za kutiliwa shaka.  
- **Shughulikia mipaka ya kasi na kupunguza mzigo**: Microsoft Graph na API nyingine zinaweka mipaka ya maombi ili kuzuia matumizi mabaya. Tekeleza mbinu za kurudi nyuma kwa mzunguko na jaribu tena ili kushughulikia kwa heshima majibu ya HTTP 429 (Maombi Mengi Sana). Fikiria kuhifadhi data inayotumiwa mara kwa mara ili kupunguza maombi ya API.  
- **Hifadhi tokeni kwa usalama**: Hifadhi tokeni za upatikanaji na tokeni za kufufua kwa usalama. Kwa programu za ndani, tumia mifumo ya kuhifadhi salama ya mfumo. Kwa programu za seva, fikiria kutumia uhifadhi uliosimbwa au huduma za usimamizi wa funguo kama Azure Key Vault.  
- **Shughulikia muda wa kumalizika kwa tokeni**: Tokeni za upatikanaji zina muda mfupi wa matumizi. Tekeleza uhuishaji wa tokeni kiotomatiki kwa kutumia tokeni za kufufua ili kudumisha uzoefu wa mtumiaji bila kuhitaji kuingia tena.  
- **Fikiria kutumia Azure API Management**: Ingawa kutekeleza usalama moja kwa moja kwenye seva yako ya MCP kunakupa udhibiti wa kina, API Gateways kama Azure API Management zinaweza kushughulikia changamoto nyingi za usalama kiotomatiki, ikiwa ni pamoja na uthibitishaji, idhinisho, mipaka ya kasi, na ufuatiliaji. Hutoa safu ya usalama iliyojikita kati ya wateja wako na seva zako za MCP. Kwa maelezo zaidi kuhusu kutumia API Gateways na MCP, angalia [Azure API Management Your Auth Gateway For MCP Servers](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690).

## Muhimu Kukumbuka

- Kuweka usalama kwenye seva yako ya MCP ni muhimu kwa kulinda data na zana zako.  
- Microsoft Entra ID hutoa suluhisho thabiti na linaloweza kupanuka kwa uthibitishaji na idhinisho.  
- Tumia **mteja wa umma** kwa programu za ndani na **mteja wa siri** kwa seva za mbali.  
- **Mtiririko wa Msimbo wa Idhini** ni chaguo salama zaidi kwa programu za wavuti.  

## Mazoezi

1. Fikiria seva ya MCP unayoweza kuijenga. Je, itakuwa seva ya ndani au ya mbali?  
2. Kulingana na jibu lako, je, utatumia mteja wa umma au wa siri?  
3. Seva yako ya MCP itahitaji ruhusa gani kwa ajili ya kufanya shughuli dhidi ya Microsoft Graph?  

## Mazoezi ya Vitendo

### Zoezi 1: Jisajili Programu katika Entra ID  
Tembelea lango la Microsoft Entra.  
Jisajili programu mpya kwa seva yako ya MCP.  
Andika ID ya Programu (mteja) na ID ya Saraka (mpangaji).  

### Zoezi 2: Linde Seva ya MCP ya Ndani (Mteja wa Umma)  
Fuata mfano wa msimbo kuingiza MSAL (Maktaba ya Uthibitishaji ya Microsoft) kwa uthibitishaji wa mtumiaji.  
Jaribu mtiririko wa uthibitishaji kwa kupiga zana ya MCP inayopata maelezo ya mtumiaji kutoka Microsoft Graph.  

### Zoezi 3: Linde Seva ya MCP ya Mbali (Mteja wa Siri)  
Jisajili mteja wa siri katika Entra ID na tengeneza siri ya mteja.  
Sanidi seva yako ya MCP ya Express.js kutumia Mtiririko wa Msimbo wa Idhini.  
Jaribu vituo vilivyo na ulinzi na thibitisha upatikanaji kwa tokeni.  

### Zoezi 4: Tumia Mbinu Bora za Usalama  
Wezesha HTTPS kwa seva yako ya ndani au ya mbali.  
Tekeleza udhibiti wa upatikanaji kwa msingi wa majukumu (RBAC) katika mantiki ya seva yako.  
Ongeza usimamizi wa muda wa kumalizika kwa tokeni na uhifadhi salama wa tokeni.  

## Rasilimali

1. **Nyaraka za Muhtasari wa MSAL**  
   Jifunze jinsi Maktaba ya Uthibitishaji ya Microsoft (MSAL) inavyorahisisha upatikanaji wa tokeni salama katika majukwaa mbalimbali:  
   [Muhtasari wa MSAL kwenye Microsoft Learn](https://learn.microsoft.com/en-gb/entra/msal/overview)  

2. **Azure-Samples/mcp-auth-servers GitHub Repository**  
   Mfano wa utekelezaji wa seva za MCP unaoonyesha mitiririko ya uthibitishaji:  
   [Azure-Samples/mcp-auth-servers kwenye GitHub](https://github.com/Azure-Samples/mcp-auth-servers)  

3. **Muhtasari wa Managed Identities kwa Rasilimali za Azure**  
   Elewa jinsi ya kuondoa siri kwa kutumia utambulisho unaosimamiwa na mfumo au mtumiaji:  
   [Muhtasari wa Managed Identities kwenye Microsoft Learn](https://learn.microsoft.com/en-us/entra/identity/managed-identities-azure-resources/)  

4. **Azure API Management: Lango lako la Uthibitishaji kwa Seva za MCP**  
   Uchambuzi wa kina wa kutumia APIM kama lango salama la OAuth2 kwa seva za MCP:  
   [Azure API Management Your Auth Gateway For MCP Servers](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)  

5. **Rejeleo la Ruhusa za Microsoft Graph**  
   Orodha kamili ya ruhusa za kupewa na programu kwa Microsoft Graph:  
   [Rejeleo la Ruhusa za Microsoft Graph](https://learn.microsoft.com/zh-tw/graph/permissions-reference)  

## Matokeo ya Kujifunza  
Baada ya kumaliza sehemu hii, utaweza:

- Eleza kwa nini uthibitishaji ni muhimu kwa seva za MCP na mipango ya AI.  
- Sanidi na usanidi uthibitishaji wa Entra ID kwa mazingira ya seva za MCP za ndani na mbali.  
- Chagua aina sahihi ya mteja (mteja wa umma au wa siri) kulingana na uendeshaji wa seva yako.  
- Tekeleza mbinu salama za uandishi wa msimbo, ikiwa ni pamoja na uhifadhi wa tokeni na idhinisho kwa msingi wa majukumu.  
- Linda kwa ujasiri seva yako ya MCP na zana zake dhidi ya ufikiaji usioidhinishwa.  

## Nini Kifuatacho  

- [6. Michango ya Jamii](../../06-CommunityContributions/README.md)

**Kiasi cha Hukumu**:  
Nyaraka hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuwa sahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au ukosefu wa usahihi. Nyaraka ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu ya binadamu inashauriwa. Hatubeba dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.