<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9abe1d303ab126f9a8b87f03cebe5213",
  "translation_date": "2025-06-26T14:41:50+00:00",
  "source_file": "05-AdvancedTopics/mcp-security-entra/README.md",
  "language_code": "mr"
}
-->
# AI वर्कफ्लोज सुरक्षित करणे: Model Context Protocol सर्व्हरसाठी Entra ID प्रमाणीकरण

## परिचय  
तुमच्या Model Context Protocol (MCP) सर्व्हरचे संरक्षण करणे हे तुमच्या घराच्या मुख्य दरवाजाला लॉक करण्याइतकेच महत्त्वाचे आहे. तुमचा MCP सर्व्हर उघडा ठेवल्यास, तुमची साधने आणि डेटा अनधिकृत प्रवेशासाठी उघडे राहतात, ज्यामुळे सुरक्षा भंग होऊ शकतो. Microsoft Entra ID ही एक मजबूत क्लाउड-आधारित ओळख आणि प्रवेश व्यवस्थापन सेवा आहे, जी सुनिश्चित करते की फक्त अधिकृत वापरकर्ते आणि अनुप्रयोगच तुमच्या MCP सर्व्हरशी संवाद साधू शकतील. या विभागात, तुम्हाला Entra ID प्रमाणीकरण वापरून तुमच्या AI वर्कफ्लोज कसे सुरक्षित करायचे ते शिकवले जाईल.

## शिकण्याचे उद्दिष्टे  
या विभागाच्या शेवटी, तुम्ही खालील गोष्टी करू शकाल:

- MCP सर्व्हर सुरक्षित करण्याचे महत्त्व समजून घेणे.  
- Microsoft Entra ID आणि OAuth 2.0 प्रमाणीकरणाची मूलतत्त्वे समजावून सांगणे.  
- सार्वजनिक आणि गोपनीय क्लायंटमधील फरक ओळखणे.  
- स्थानिक (सार्वजनिक क्लायंट) आणि रिमोट (गोपनीय क्लायंट) MCP सर्व्हर परिस्थितीत Entra ID प्रमाणीकरण अंमलात आणणे.  
- AI वर्कफ्लोज विकसित करताना सुरक्षा सर्वोत्तम पद्धती वापरणे.

# AI वर्कफ्लोज सुरक्षित करणे: Model Context Protocol सर्व्हरसाठी Entra ID प्रमाणीकरण

जसे तुम्ही तुमच्या घराचा मुख्य दरवाजा अनलॉक करून ठेवणार नाही, तसंच तुमचा MCP सर्व्हर कोणालाही प्रवेशासाठी खुला ठेवू नका. तुमचे AI वर्कफ्लोज सुरक्षित करणे हे विश्वासार्ह, मजबूत आणि सुरक्षित अनुप्रयोग तयार करण्यासाठी अत्यावश्यक आहे. या प्रकरणात, तुम्हाला Microsoft Entra ID वापरून तुमच्या MCP सर्व्हरचे संरक्षण कसे करायचे ते शिकवले जाईल, ज्यामुळे फक्त अधिकृत वापरकर्ते आणि अनुप्रयोग तुमच्या साधने आणि डेटाशी संवाद साधू शकतील.

## MCP सर्व्हरसाठी सुरक्षा का महत्त्वाची आहे

कल्पना करा की तुमच्या MCP सर्व्हरमध्ये अशी साधन आहे जी ईमेल पाठवू शकते किंवा ग्राहक डेटाबेसमध्ये प्रवेश करू शकते. जर सर्व्हर सुरक्षित नसेल, तर कोणालाही ती साधन वापरण्याची संधी मिळेल, ज्यामुळे अनधिकृत डेटापर्यंत प्रवेश, स्पॅम किंवा इतर हानिकारक क्रिया होऊ शकतात.

प्रमाणीकरण अंमलात आणल्याने, तुम्ही सुनिश्चित करता की प्रत्येक विनंतीची खात्री होते, म्हणजे वापरकर्त्याची किंवा अनुप्रयोगाची ओळख पडताळली जाते. हीच तुमच्या AI वर्कफ्लोज सुरक्षित करण्याची पहिली आणि सर्वात महत्त्वाची पायरी आहे.

## Microsoft Entra ID परिचय

**Microsoft Entra ID** ही क्लाउड-आधारित ओळख आणि प्रवेश व्यवस्थापन सेवा आहे. याला तुमच्या अनुप्रयोगांसाठी एक सार्वत्रिक सुरक्षा रक्षक समजा. हे वापरकर्त्यांच्या ओळखीची पडताळणी (प्रमाणीकरण) आणि त्यांना काय करण्याची परवानगी आहे ते ठरवण्याचे (प्राधिकरण) गुंतागुंतीचे काम सांभाळते.

Entra ID वापरून तुम्ही:

- वापरकर्त्यांसाठी सुरक्षित साइन-इन सक्षम करू शकता.  
- API आणि सेवा सुरक्षित करू शकता.  
- प्रवेश धोरणे एका केंद्रस्थानी व्यवस्थापित करू शकता.

MCP सर्व्हरसाठी, Entra ID ही एक मजबूत आणि विश्वासार्ह उपाय आहे ज्यामुळे कोण MCP सर्व्हरच्या कार्यक्षमतेपर्यंत प्रवेश करू शकतो हे नियंत्रित करता येते.

---

## जादू समजून घेणे: Entra ID प्रमाणीकरण कसे कार्य करते

Entra ID प्रमाणीकरणासाठी **OAuth 2.0** सारख्या खुले मानक वापरते. तपशील जरा गुंतागुंतीचे असू शकतात, पण मूळ संकल्पना सोपी आहे आणि ती तुम्हाला एक उदाहरण देऊन समजावून सांगता येईल.

### OAuth 2.0 ची साधी ओळख: Valet Key

OAuth 2.0 ला तुमच्या कारसाठी वालेट सेवा समजा. जेव्हा तुम्ही रेस्टॉरंटला जाता, तेव्हा तुम्ही वालेटला तुमची मुख्य चावी देत नाही. त्याऐवजी, तुम्ही एक **वालेट की** देता ज्यात मर्यादित परवानग्या असतात — ती कार सुरू करू शकते आणि दरवाजे लॉक करू शकते, पण ट्रंक किंवा ग्लोव्ह कम्पार्टमेंट उघडू शकत नाही.

या उदाहरणात:

- **तुम्ही** म्हणजे **वापरकर्ता**.  
- **तुमची कार** म्हणजे **MCP सर्व्हर** ज्यात मौल्यवान साधने आणि डेटा आहे.  
- **वालेट** म्हणजे **Microsoft Entra ID**.  
- **पार्किंग अटेंडंट** म्हणजे **MCP क्लायंट** (जो अनुप्रयोग सर्व्हरशी संवाद साधत आहे).  
- **वालेट की** म्हणजे **Access Token**.

Access token हा एक सुरक्षित टेक्स्ट स्ट्रिंग आहे जो MCP क्लायंटला Entra ID कडून साइन-इन नंतर मिळतो. क्लायंट नंतर हा टोकन प्रत्येक विनंतीसह MCP सर्व्हरला सादर करतो. सर्व्हर हा टोकन पडताळून खात्री करतो की विनंती वैध आहे आणि क्लायंटकडे आवश्यक परवानग्या आहेत, तेही तुमचे मूळ संकेतशब्द न वापरता.

### प्रमाणीकरण प्रवाह

हे प्रक्रियात्मकपणे कसे कार्य करते:

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

### Microsoft Authentication Library (MSAL) ची ओळख

कोडमध्ये पुढे जाण्यापूर्वी, एक महत्त्वाचा घटक ओळखून घेणे गरजेचे आहे: **Microsoft Authentication Library (MSAL)**.

MSAL ही Microsoft द्वारे विकसित केलेली लायब्ररी आहे जी डेव्हलपर्ससाठी प्रमाणीकरण हाताळणे खूप सोपे करते. तुम्हाला सुरक्षा टोकन हाताळण्यासाठी, साइन-इनसाठी किंवा सत्र ताजेतवाने करण्यासाठी गुंतागुंतीचा कोड लिहिण्याची गरज नाही, MSAL हे काम आपोआप करते.

MSAL वापरण्याची शिफारस कारणे:

- **सुरक्षित:** उद्योगमानक प्रोटोकॉल आणि सुरक्षा सर्वोत्तम पद्धती वापरते, ज्यामुळे तुमच्या कोडमधील धोके कमी होतात.  
- **विकास सुलभ करते:** OAuth 2.0 आणि OpenID Connect सारख्या प्रोटोकॉल्सची गुंतागुंत लपवून ठेऊन, काही ओळींच्या कोडने मजबूत प्रमाणीकरण जोडण्यास मदत करते.  
- **देखभाल केली जाते:** Microsoft MSAL नियमितपणे अपडेट करते जेणेकरून नवीन सुरक्षा धोके आणि प्लॅटफॉर्म बदल हाताळता येतील.

MSAL .NET, JavaScript/TypeScript, Python, Java, Go आणि iOS व Android सारख्या मोबाइल प्लॅटफॉर्मसाठी उपलब्ध आहे. त्यामुळे तुम्ही तुमच्या संपूर्ण तंत्रज्ञान संचात एकसारखे प्रमाणीकरण नमुने वापरू शकता.

MSAL विषयी अधिक जाणून घेण्यासाठी, अधिकृत [MSAL overview documentation](https://learn.microsoft.com/entra/identity-platform/msal-overview) पाहू शकता.

---

## Entra ID वापरून तुमचा MCP सर्व्हर सुरक्षित करणे: टप्प्याटप्प्याने मार्गदर्शक

आता, स्थानिक MCP सर्व्हर (जो `stdio`) using Entra ID. This example uses a **public client**, which is suitable for applications running on a user's machine, like a desktop app or a local development server.

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
- **`AcquireTokenAsync` वापरून संवाद साधतो) सुरक्षित करण्याची प्रक्रिया पाहूया: हा मुख्य पद्धत आहे. हे प्रथम शांतपणे टोकन मिळवण्याचा प्रयत्न करते (जर वापरकर्त्याचा वैध सत्र असेल तर पुन्हा साइन-इन करावे लागत नाही). जर शांत टोकन मिळाले नाही तर वापरकर्त्याला संवादात्मक साइन-इनसाठी विचारले जाते.

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
- **`GetUserDetailsFromGraph` tool**: This tool requires an instance of `AuthenticationService`. Before it does anything, it calls `authService.AcquireTokenAsync()` वापरून वैध access token मिळवते. प्रमाणीकरण यशस्वी झाल्यास, तो टोकन वापरून Microsoft Graph API कॉल करून वापरकर्त्याची माहिती मिळवते.

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

#### ३. हे सगळं एकत्र कसं काम करतं

1. जेव्हा MCP क्लायंट `GetUserDetailsFromGraph` tool, the tool first calls `AcquireTokenAsync`.
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
- **`/auth/callback` या endpoint ला कॉल करतो: हा endpoint वापरकर्त्याने Entra ID कडून प्रमाणीकरण केल्यानंतर redirect हाताळतो. तो authorization code चा access token आणि refresh token मध्ये बदल करतो.

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

This file defines the tools that the MCP server provides. The `getUserDetails` टूल मागील उदाहरणासारखाच आहे, पण तो access token सत्रातून मिळवतो.

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
6. When the `getUserDetails` टूल कॉल केल्यावर, सत्रातील टोकन वापरून Entra ID access token शोधतो आणि नंतर तो वापरून Microsoft Graph API कॉल करतो.

हा प्रवाह सार्वजनिक क्लायंट प्रवाहापेक्षा अधिक गुंतागुंतीचा आहे, पण इंटरनेटवरील endpoint साठी आवश्यक आहे. कारण रिमोट MCP सर्व्हर सार्वजनिक इंटरनेटवर उपलब्ध असतात, त्यांना अनधिकृत प्रवेश आणि संभाव्य हल्ल्यांपासून संरक्षणासाठी अधिक मजबूत सुरक्षा उपायांची गरज असते.

## सुरक्षा सर्वोत्तम पद्धती

- **नेहमी HTTPS वापरा:** क्लायंट आणि सर्व्हरमधील संवाद एन्क्रिप्ट करा जेणेकरून टोकन चोरी होणार नाहीत.  
- **Role-Based Access Control (RBAC) लागू करा:** फक्त वापरकर्ता प्रमाणीकरण झाला आहे का ते तपासू नका; त्याला काय परवानगी आहे तेही तपासा. Entra ID मध्ये भूमिका परिभाषित करा आणि MCP सर्व्हरमध्ये त्यांची पडताळणी करा.  
- **नियंत्रण आणि लेखा परीक्षण करा:** सर्व प्रमाणीकरण घटना लॉग करा, ज्यामुळे संशयास्पद क्रियाकलाप शोधता येतील आणि प्रतिसाद देता येईल.  
- **रेट लिमिटिंग आणि थ्रॉटलिंग हाताळा:** Microsoft Graph आणि इतर API मध्ये दुरुपयोग टाळण्यासाठी रेट लिमिटिंग असते. MCP सर्व्हरमध्ये HTTP 429 (Too Many Requests) प्रतिसादासाठी एक्स्पोनेंशियल बॅकऑफ आणि पुनर्प्रयत्न लॉजिक लागू करा. वारंवार वापरल्या जाणाऱ्या डेटासाठी कॅशिंगचा विचार करा.  
- **टोकन सुरक्षित साठवण:** Access tokens आणि refresh tokens सुरक्षित ठिकाणी साठवा. स्थानिक अनुप्रयोगांसाठी सिस्टमच्या सुरक्षित साठवण प्रणाली वापरा. सर्व्हर अनुप्रयोगांसाठी एन्क्रिप्टेड साठवण किंवा Azure Key Vault सारख्या सुरक्षित की व्यवस्थापन सेवा वापरण्याचा विचार करा.  
- **टोकन कालबाह्यता हाताळणी:** Access tokens ची मर्यादित आयुष्य असते. पुनरावृत्ती न करता वापरकर्ता अनुभव राखण्यासाठी refresh tokens वापरून टोकन आपोआप ताजेतवाने करा.  
- **Azure API Management वापरण्याचा विचार करा:** MCP सर्व्हरमध्ये थेट सुरक्षा लागू करणे तुम्हाला अधिक नियंत्रण देते, पण API गेटवे जसे Azure API Management प्रमाणीकरण, प्राधिकरण, रेट लिमिटिंग आणि मॉनिटरिंग स्वयंचलितपणे हाताळू शकतात. हे तुमच्या क्लायंट्स आणि MCP सर्व्हरमधील मध्यवर्ती सुरक्षा स्तर पुरवतात. MCP साठी API गेटवे वापरण्याबद्दल अधिक माहितीसाठी [Azure API Management Your Auth Gateway For MCP Servers](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) पहा.

## मुख्य मुद्दे

- तुमचा MCP सर्व्हर सुरक्षित करणे तुमच्या डेटा आणि साधनांचे संरक्षण करण्यासाठी अत्यंत आवश्यक आहे.  
- Microsoft Entra ID प्रमाणीकरण आणि प्राधिकरणासाठी एक मजबूत आणि स्केलेबल उपाय आहे.  
- स्थानिक अनुप्रयोगांसाठी **सार्वजनिक क्लायंट** आणि रिमोट सर्व्हरसाठी **गोपनीय क्लायंट** वापरा.  
- वेब अनुप्रयोगांसाठी **Authorization Code Flow** हा सर्वात सुरक्षित पर्याय आहे.

## सराव

1. तुमच्या कल्पनेतील MCP सर्व्हर स्थानिक असेल की रिमोट?  
2. तुमच्या उत्तरानुसार, तुम्ही सार्वजनिक क्लायंट वापराल की गोपनीय क्लायंट?  
3. Microsoft Graph विरुद्ध क्रिया करण्यासाठी तुमचा MCP सर्व्हर कोणती परवानगी मागेल?

## व्यावहारिक सराव

### सराव 1: Entra ID मध्ये अनुप्रयोग नोंदणी करा  
Microsoft Entra पोर्टलवर जा.  
तुमच्या MCP सर्व्हरसाठी नवीन अनुप्रयोग नोंदणी करा.  
Application (client) ID आणि Directory (tenant) ID नोंद करा.

### सराव 2: स्थानिक MCP सर्व्हर सुरक्षित करा (सार्वजनिक क्लायंट)  
वापरकर्ता प्रमाणीकरणासाठी MSAL (Microsoft Authentication Library) समाकलित करण्यासाठी कोड उदाहरणाचा अवलंब करा.  
Microsoft Graph कडून वापरकर्त्याचे तपशील मिळवणाऱ्या MCP टूलला कॉल करून प्रमाणीकरण प्रवाह तपासा.

### सराव 3: रिमोट MCP सर्व्हर सुरक्षित करा (गोपनीय क्लायंट)  
Entra ID मध्ये गोपनीय क्लायंट नोंदणी करा आणि client secret तयार करा.  
Authorization Code Flow वापरून तुमचा Express.js MCP सर्व्हर कॉन्फिगर करा.  
संरक्षित endpoints चाचणी करा आणि टोकन-आधारित प्रवेशाची पुष्टी करा.

### सराव 4: सुरक्षा सर्वोत्तम पद्धती लागू करा  
तुमच्या स्थानिक किंवा रिमोट सर्व्हरसाठी HTTPS सक्षम करा.  
सर्व्हर लॉजिकमध्ये role-based access control (RBAC) लागू करा.  
टोकन कालबाह्यता हाताळणी आणि सुरक्षित टोकन साठवण जोडा.

## संसाधने

1. **MSAL Overview Documentation**  
   Microsoft Authentication Library (MSAL) कसे सुरक्षित टोकन प्राप्ती सुलभ करते हे जाणून घ्या:  
   [MSAL Overview on Microsoft Learn](https://learn.microsoft.com/en-gb/entra/msal/overview)

2. **Azure-Samples/mcp-auth-servers GitHub Repository**  
   MCP सर्व्हरचे प्रमाणीकरण प्रवाह दाखवणारे संदर्भ अंमलबजावणी:  
   [Azure-Samples/mcp-auth-servers on GitHub](https://github.com/Azure-Samples/mcp-auth-servers)

3. **Managed Identities for Azure Resources Overview**  
   सिस्टम किंवा वापरकर्ता-नियुक्त व्यवस्थापित ओळखी वापरून गुपिते कशी टाळायची ते समजून घ्या:  
   [Managed Identities Overview on Microsoft Learn](https://learn.microsoft.com/en-us/entra/identity/managed-identities-azure-resources/)

4. **Azure API Management: Your Auth Gateway for MCP Servers**  
   MCP सर्व्हरसाठी APIM वापरून OAuth2 गेटवे कसे सुरक्षित करायचे यावर सखोल माहिती:  
   [Azure API Management Your Auth Gateway For MCP Servers](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

5. **Microsoft Graph Permissions Reference**  
   Microsoft Graph साठी प्रतिनिधीत्व आणि अनुप्रयोग परवानग्यांची संपूर्ण यादी:  
   [Microsoft Graph Permissions Reference](https://learn.microsoft.com/zh-tw/graph/permissions-reference)

## शिकण्याचे परिणाम  
या विभागानंतर, तुम्ही:

- MCP सर्व्हर आणि AI वर्कफ्लोजसाठी प्रमाणीकरण का आवश्यक आहे हे स्पष्ट करू शकाल.  
- स्थानिक आणि रिमोट MCP सर्व्हर परिस्थितीसाठी Entra ID प्रमाणीकरण सेटअप आणि कॉन्फिगर करू शकाल.  
- तुमच्या सर्व्हरच्या तैनातीवर आधारित योग्य क्लायंट प्रकार (सार्वजनिक किंवा गोपनीय) निवडू शकाल.  
- टोकन साठवण आणि भूमिका-आधारित प्राधिकरण यांसह सुरक्षित कोडिंग पद्धती अंमलात आणू शकाल.  
- तुमचा MCP सर्व्हर आणि त्याची साधने अनधिकृत प्रवेशापासून आत्मविश्वासाने सुरक्षित करू शकाल.

## पुढे काय

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अपूर्णता असू शकते. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद करण्याची शिफारस केली जाते. या अनुवादाच्या वापरामुळे उद्भवलेल्या कोणत्याही गैरसमजुती किंवा चुकीसाठी आम्ही जबाबदार नाही.