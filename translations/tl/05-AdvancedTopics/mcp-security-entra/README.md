<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9abe1d303ab126f9a8b87f03cebe5213",
  "translation_date": "2025-06-26T14:55:46+00:00",
  "source_file": "05-AdvancedTopics/mcp-security-entra/README.md",
  "language_code": "tl"
}
-->
# Pagpapatibay ng Seguridad sa AI Workflows: Entra ID Authentication para sa Model Context Protocol Servers

## Panimula  
Ang pagpapatibay ng seguridad sa iyong Model Context Protocol (MCP) server ay kasinghalaga ng pagsasara ng pintuan ng iyong bahay. Kapag iniwan mong bukas ang iyong MCP server, nagiging bukas ito sa hindi awtorisadong pag-access na maaaring magdulot ng mga paglabag sa seguridad. Nagbibigay ang Microsoft Entra ID ng matibay na cloud-based na solusyon para sa identity at access management, na tumutulong upang matiyak na tanging mga awtorisadong user at aplikasyon lamang ang makakagamit ng iyong MCP server. Sa bahaging ito, matututuhan mo kung paano protektahan ang iyong AI workflows gamit ang Entra ID authentication.

## Mga Layunin sa Pagkatuto  
Sa pagtatapos ng bahaging ito, magagawa mong:

- Maunawaan ang kahalagahan ng pagpapatibay ng seguridad sa MCP servers.  
- Ipaliwanag ang mga batayan ng Microsoft Entra ID at OAuth 2.0 authentication.  
- Kilalanin ang pagkakaiba ng public at confidential clients.  
- Ipatupad ang Entra ID authentication sa parehong lokal (public client) at remote (confidential client) na mga senaryo ng MCP server.  
- Ilapat ang mga pinakamahusay na kasanayan sa seguridad kapag bumubuo ng AI workflows.  

# Pagpapatibay ng Seguridad sa AI Workflows: Entra ID Authentication para sa Model Context Protocol Servers

Katulad ng hindi mo iiwanang nakabukas ang pintuan ng iyong bahay, hindi mo rin dapat iwanang bukas ang iyong MCP server para ma-access ng kahit sino. Mahalaga ang pagpapatibay ng seguridad sa iyong AI workflows upang makabuo ng matibay, mapagkakatiwalaan, at ligtas na mga aplikasyon. Ipapakilala sa kabanatang ito kung paano gamitin ang Microsoft Entra ID upang maprotektahan ang iyong MCP servers, tinitiyak na tanging mga awtorisadong user at aplikasyon lamang ang makakagamit ng iyong mga kagamitan at datos.

## Bakit Mahalaga ang Seguridad para sa MCP Servers

Isipin mo na ang iyong MCP server ay may kasangkapang makakapagpadala ng mga email o makaka-access sa isang customer database. Kapag hindi ito naprotektahan, maaaring gamitin ito ng kahit sino, na magdudulot ng hindi awtorisadong pag-access sa datos, spam, o iba pang malisyosong gawain.

Sa pamamagitan ng pagpapatupad ng authentication, tinitiyak mo na bawat kahilingan sa iyong server ay sinusuri upang kumpirmahin ang pagkakakilanlan ng user o aplikasyon na gumagawa ng kahilingan. Ito ang unang at pinakamahalagang hakbang sa pagpapatibay ng seguridad ng iyong AI workflows.

## Panimula sa Microsoft Entra ID

**Microsoft Entra ID** ay isang cloud-based na serbisyo para sa identity at access management. Isipin mo itong isang unibersal na guwardiya para sa iyong mga aplikasyon. Ito ang humahawak sa komplikadong proseso ng pagpapatunay ng pagkakakilanlan ng user (authentication) at pagtukoy kung ano ang pinapayagan nilang gawin (authorization).

Sa paggamit ng Entra ID, maaari kang:

- Magbigay ng ligtas na pag-sign in para sa mga user.  
- Protektahan ang mga API at serbisyo.  
- Pamahalaan ang mga polisiya sa access mula sa isang sentral na lokasyon.  

Para sa MCP servers, nagbibigay ang Entra ID ng matibay at malawak na pinagkakatiwalaang solusyon para kontrolin kung sino ang maaaring gumamit ng kakayahan ng iyong server.

---

## Pag-unawa sa Proseso: Paano Gumagana ang Entra ID Authentication

Gumagamit ang Entra ID ng mga bukas na pamantayan tulad ng **OAuth 2.0** para sa authentication. Bagaman maaaring maging kumplikado ang mga detalye, simple ang pangunahing konsepto at maiintindihan gamit ang isang halimbawa.

### Isang Magaan na Panimula sa OAuth 2.0: Ang Valet Key

Isipin ang OAuth 2.0 bilang valet service para sa iyong sasakyan. Kapag dumating ka sa isang restawran, hindi mo ibibigay sa valet ang iyong master key. Sa halip, bibigyan mo siya ng **valet key** na may limitadong pahintulot—maaari nitong paandarin ang sasakyan at isara ang mga pinto, ngunit hindi nito mabubuksan ang trunk o glove compartment.

Sa halimbawa na ito:

- **Ikaw** ang **User**.  
- **Ang iyong sasakyan** ay ang **MCP Server** na may mahahalagang kagamitan at datos.  
- Ang **Valet** ay ang **Microsoft Entra ID**.  
- Ang **Parking Attendant** ay ang **MCP Client** (ang aplikasyon na sumusubok mag-access sa server).  
- Ang **Valet Key** ay ang **Access Token**.  

Ang access token ay isang secure na string ng teksto na natatanggap ng MCP client mula sa Entra ID pagkatapos mong mag-sign in. Ipinapasa ng client ang token na ito sa MCP server sa bawat kahilingan. Maaaring beripikahin ng server ang token upang matiyak na lehitimo ang kahilingan at may sapat na pahintulot ang client, nang hindi kailangang hawakan ang iyong tunay na kredensyal (tulad ng password).

### Ang Daloy ng Authentication

Ganito ang proseso sa aktwal na gamit:

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

### Pagpapakilala sa Microsoft Authentication Library (MSAL)

Bago tayo sumabak sa code, mahalagang ipakilala ang isang pangunahing bahagi na makikita mo sa mga halimbawa: ang **Microsoft Authentication Library (MSAL)**.

Ang MSAL ay isang library na ginawa ng Microsoft na nagpapadali para sa mga developer ang paghawak ng authentication. Sa halip na ikaw ang magsulat ng kumplikadong code para sa security tokens, pamamahala ng pag-sign in, at pag-refresh ng session, inaalagaan ito ng MSAL.

Inirerekomenda ang paggamit ng MSAL dahil:

- **Ligtas ito:** Ipinapatupad nito ang mga industry-standard na protocol at pinakamahusay na kasanayan sa seguridad, na nagpapababa ng panganib ng mga kahinaan sa iyong code.  
- **Pinapadali nito ang Pag-develop:** Nilalayo nito ang komplikasyon ng OAuth 2.0 at OpenID Connect protocols, kaya madali kang makakapagdagdag ng matibay na authentication sa iyong aplikasyon gamit lamang ang ilang linya ng code.  
- **Pinananatili ito:** Aktibong inaalagaan at ina-update ng Microsoft ang MSAL upang tugunan ang mga bagong banta sa seguridad at mga pagbabago sa platform.  

Sinusuportahan ng MSAL ang iba't ibang wika at application frameworks, kabilang ang .NET, JavaScript/TypeScript, Python, Java, Go, at mga mobile platform tulad ng iOS at Android. Nangangahulugan ito na maaari mong gamitin ang pare-parehong pattern ng authentication sa buong technology stack mo.

Para matuto pa tungkol sa MSAL, maaari mong bisitahin ang opisyal na [MSAL overview documentation](https://learn.microsoft.com/entra/identity-platform/msal-overview).

---

## Pagpapatibay ng Seguridad sa Iyong MCP Server gamit ang Entra ID: Isang Hakbang-hakbang na Gabay

Ngayon, tatalakayin natin kung paano i-secure ang isang lokal na MCP server (isang server na nakikipag-usap gamit ang `stdio`) using Entra ID. This example uses a **public client**, which is suitable for applications running on a user's machine, like a desktop app or a local development server.

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
- **`AcquireTokenAsync`**: Ito ang pangunahing method. Una nitong sinusubukang kumuha ng token nang tahimik (silent), ibig sabihin hindi na kailangang mag-sign in muli ang user kung may valid na session pa siya. Kung hindi makakuha ng silent token, ipapakita nito ang prompt para sa interactive sign-in.

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
- **`GetUserDetailsFromGraph` tool**: This tool requires an instance of `AuthenticationService`. Before it does anything, it calls `authService.AcquireTokenAsync()` upang makakuha ng valid na access token. Kapag matagumpay ang authentication, gagamitin nito ang token para tawagan ang Microsoft Graph API at kunin ang detalye ng user.

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

#### 3. Paano Nagtutulungan ang Lahat ng Ito

1. Kapag sinubukang gamitin ng MCP client ang `GetUserDetailsFromGraph` tool, the tool first calls `AcquireTokenAsync`.
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
- **`/auth/callback`**: Ang endpoint na ito ang humahawak sa redirect mula sa Entra ID pagkatapos mag-authenticate ang user. Pinapalitan nito ang authorization code para sa access token at refresh token.

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

This file defines the tools that the MCP server provides. The `getUserDetails` tool ay katulad ng nasa naunang halimbawa, ngunit kinukuha nito ang access token mula sa session.

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
6. When the `getUserDetails` tool ay tinatawag, ginagamit nito ang session token upang hanapin ang Entra ID access token at pagkatapos ay ginagamit ito para tawagan ang Microsoft Graph API.

Mas kumplikado ang daloy na ito kumpara sa public client flow, ngunit kinakailangan ito para sa mga endpoint na nakaharap sa internet. Dahil ang mga remote MCP server ay naa-access sa publiko, kailangan nila ng mas matibay na seguridad upang maprotektahan laban sa hindi awtorisadong pag-access at posibleng mga pag-atake.

## Mga Pinakamahusay na Kasanayan sa Seguridad

- **Laging gumamit ng HTTPS**: I-encrypt ang komunikasyon sa pagitan ng client at server upang maprotektahan ang mga token mula sa interception.  
- **Magpatupad ng Role-Based Access Control (RBAC)**: Huwag lamang tingnan kung *authenticated* ang user; alamin kung *ano* ang pinapayagan nilang gawin. Maaari kang magtakda ng mga role sa Entra ID at suriin ito sa iyong MCP server.  
- **Mag-monitor at mag-audit**: I-log ang lahat ng authentication events para makita at tugunan ang mga kahina-hinalang aktibidad.  
- **Pamahalaan ang rate limiting at throttling**: Nagpapatupad ang Microsoft Graph at iba pang API ng rate limiting upang maiwasan ang pang-aabuso. Magpatupad ng exponential backoff at retry logic sa iyong MCP server upang maayos na harapin ang HTTP 429 (Too Many Requests) na mga tugon. Isaalang-alang ang pag-cache ng madalas gamitin na datos upang mabawasan ang API calls.  
- **Secure na pag-iimbak ng token**: Itago ang access tokens at refresh tokens nang ligtas. Para sa lokal na aplikasyon, gamitin ang secure storage ng system. Para sa mga server application, isaalang-alang ang paggamit ng encrypted storage o secure key management services tulad ng Azure Key Vault.  
- **Pag-handle ng expiration ng token**: May hangganan ang buhay ng access tokens. Magpatupad ng awtomatikong pag-refresh ng token gamit ang refresh tokens upang mapanatili ang tuloy-tuloy na karanasan ng user nang hindi na kailangang muling mag-authenticate.  
- **Isaalang-alang ang paggamit ng Azure API Management**: Bagaman ang direktang pagpapatupad ng seguridad sa iyong MCP server ay nagbibigay ng mas detalyadong kontrol, ang mga API Gateway tulad ng Azure API Management ay maaaring awtomatikong humawak ng maraming isyu sa seguridad, kabilang ang authentication, authorization, rate limiting, at monitoring. Nagbibigay sila ng sentralisadong layer ng seguridad sa pagitan ng iyong mga client at MCP servers. Para sa karagdagang detalye sa paggamit ng API Gateways sa MCP, tingnan ang aming [Azure API Management Your Auth Gateway For MCP Servers](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690).

## Mga Mahahalagang Punto

- Mahalaga ang pagpapatibay ng seguridad sa iyong MCP server upang maprotektahan ang iyong datos at kagamitan.  
- Nagbibigay ang Microsoft Entra ID ng matibay at scalable na solusyon para sa authentication at authorization.  
- Gumamit ng **public client** para sa mga lokal na aplikasyon at **confidential client** para sa mga remote server.  
- Ang **Authorization Code Flow** ang pinakaligtas na opsyon para sa mga web application.  

## Pagsasanay

1. Isipin ang isang MCP server na maaari mong gawin. Ito ba ay lokal o remote?  
2. Batay sa sagot mo, gagamit ka ba ng public o confidential client?  
3. Anong permiso ang hihingin ng iyong MCP server para sa pagsasagawa ng mga aksyon laban sa Microsoft Graph?  

## Mga Hands-on na Pagsasanay

### Pagsasanay 1: Magrehistro ng Aplikasyon sa Entra ID  
Pumunta sa Microsoft Entra portal.  
Magrehistro ng bagong aplikasyon para sa iyong MCP server.  
Itala ang Application (client) ID at Directory (tenant) ID.  

### Pagsasanay 2: I-secure ang Lokal na MCP Server (Public Client)  
Sundan ang code example upang isama ang MSAL (Microsoft Authentication Library) para sa user authentication.  
Subukan ang authentication flow sa pamamagitan ng pagtawag sa MCP tool na kumukuha ng user details mula sa Microsoft Graph.  

### Pagsasanay 3: I-secure ang Remote MCP Server (Confidential Client)  
Magrehistro ng confidential client sa Entra ID at gumawa ng client secret.  
I-configure ang iyong Express.js MCP server upang gamitin ang Authorization Code Flow.  
Subukan ang mga protektadong endpoint at kumpirmahin ang token-based na access.  

### Pagsasanay 4: Ilapat ang Pinakamahusay na Kasanayan sa Seguridad  
I-enable ang HTTPS para sa iyong lokal o remote server.  
Ipatupad ang role-based access control (RBAC) sa iyong server logic.  
Magdagdag ng token expiration handling at secure token storage.  

## Mga Sanggunian

1. **MSAL Overview Documentation**  
   Alamin kung paano pinapadali ng Microsoft Authentication Library (MSAL) ang secure token acquisition sa iba't ibang platform:  
   [MSAL Overview on Microsoft Learn](https://learn.microsoft.com/en-gb/entra/msal/overview)  

2. **Azure-Samples/mcp-auth-servers GitHub Repository**  
   Mga halimbawa ng implementasyon ng MCP servers na nagpapakita ng authentication flows:  
   [Azure-Samples/mcp-auth-servers on GitHub](https://github.com/Azure-Samples/mcp-auth-servers)  

3. **Managed Identities for Azure Resources Overview**  
   Unawain kung paano alisin ang paggamit ng mga secret sa pamamagitan ng paggamit ng system- o user-assigned managed identities:  
   [Managed Identities Overview on Microsoft Learn](https://learn.microsoft.com/en-us/entra/identity/managed-identities-azure-resources/)  

4. **Azure API Management: Your Auth Gateway for MCP Servers**  
   Masusing pagtalakay sa paggamit ng APIM bilang secure OAuth2 gateway para sa MCP servers:  
   [Azure API Management Your Auth Gateway For MCP Servers](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)  

5. **Microsoft Graph Permissions Reference**  
   Komprehensibong listahan ng delegated at application permissions para sa Microsoft Graph:  
   [Microsoft Graph Permissions Reference](https://learn.microsoft.com/zh-tw/graph/permissions-reference)  

## Mga Resulta ng Pagkatuto  
Pagkatapos makumpleto ang bahaging ito, magagawa mong:

- Ipaliwanag kung bakit mahalaga ang authentication para sa MCP servers at AI workflows.  
- I-set up at i-configure ang Entra ID authentication para sa parehong lokal at remote na MCP server na mga senaryo.  
- Piliin ang angkop na uri ng client (public o confidential) batay sa deployment ng iyong server.  
- Ipatupad ang ligtas na coding practices, kabilang ang token storage at role-based authorization.  
- May kumpiyansang maprotektahan ang iyong MCP server at mga kagamitan mula sa hindi awtorisadong pag-access.  

## Ano ang Susunod  

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**Paunawa**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong salin ay maaaring maglaman ng mga pagkakamali o hindi pagkakatugma. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasaling-tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng salin na ito.