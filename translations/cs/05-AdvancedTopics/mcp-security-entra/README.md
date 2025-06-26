<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0abf26a6c4dbe905d5d49ccdc0ccfe92",
  "translation_date": "2025-06-26T16:39:12+00:00",
  "source_file": "05-AdvancedTopics/mcp-security-entra/README.md",
  "language_code": "cs"
}
-->
# Zabezpečení AI pracovních toků: Entra ID autentizace pro servery Model Context Protocol

## Úvod
Zabezpečení vašeho serveru Model Context Protocol (MCP) je stejně důležité jako zamknout dveře u vašeho domu. Nechráněný MCP server vystavuje vaše nástroje a data neoprávněnému přístupu, což může vést k bezpečnostním incidentům. Microsoft Entra ID nabízí robustní cloudové řešení pro správu identit a přístupu, které zajistí, že pouze oprávnění uživatelé a aplikace budou moci komunikovat s vaším MCP serverem. V této části se naučíte, jak chránit své AI pracovní toky pomocí autentizace Entra ID.

## Cíle učení
Na konci této části budete schopni:

- Pochopit důležitost zabezpečení MCP serverů.
- Vysvětlit základy Microsoft Entra ID a autentizace OAuth 2.0.
- Rozlišit mezi veřejnými a důvěrnými klienty.
- Implementovat autentizaci Entra ID v lokálních (veřejný klient) i vzdálených (důvěrný klient) scénářích MCP serveru.
- Uplatnit osvědčené bezpečnostní postupy při vývoji AI pracovních toků.

## Bezpečnost a MCP

Stejně jako byste nenechali otevřené dveře svého domu, neměli byste nechat váš MCP server přístupný komukoliv. Zabezpečení AI pracovních toků je nezbytné pro vytváření spolehlivých, důvěryhodných a bezpečných aplikací. Tato kapitola vás seznámí s použitím Microsoft Entra ID k ochraně vašich MCP serverů, aby s vašimi nástroji a daty mohli komunikovat pouze oprávnění uživatelé a aplikace.

## Proč je bezpečnost důležitá pro MCP servery

Představte si, že váš MCP server má nástroj, který může odesílat e-maily nebo přistupovat k databázi zákazníků. Nezabezpečený server by znamenal, že kdokoliv by mohl tento nástroj použít, což by mohlo vést k neoprávněnému přístupu k datům, spamu nebo jiným škodlivým aktivitám.

Implementací autentizace zajistíte, že každá žádost na váš server bude ověřena, čímž potvrdíte identitu uživatele nebo aplikace, která žádost odesílá. To je první a nejdůležitější krok k zabezpečení vašich AI pracovních toků.

## Úvod do Microsoft Entra ID

[**Microsoft Entra ID**](https://adoption.microsoft.com/microsoft-security/entra/) je cloudová služba pro správu identit a přístupu. Představte si ji jako univerzálního bezpečnostního strážce vašich aplikací. Zpracovává složitý proces ověřování identity uživatelů (autentizace) a určuje, co smí dělat (autorizace).

Používáním Entra ID můžete:

- Umožnit bezpečné přihlašování uživatelů.
- Chránit API a služby.
- Spravovat přístupové politiky z jednoho místa.

Pro MCP servery Entra ID nabízí spolehlivé a široce důvěryhodné řešení pro řízení přístupu k funkcím vašeho serveru.

---

## Jak funguje autentizace Entra ID

Entra ID využívá otevřené standardy jako **OAuth 2.0** pro autentizaci. I když jsou detaily složité, základní princip je jednoduchý a lze si ho představit na příkladu.

### Jemný úvod do OAuth 2.0: Klíč od parkoviště

Představte si OAuth 2.0 jako službu parkování vašeho auta. Když přijedete do restaurace, nedáte parkovacímu svůj hlavní klíč od auta. Místo toho mu předáte **parkovací klíč**, který má omezená oprávnění – může nastartovat auto a zamknout dveře, ale nemůže otevřít kufr nebo přihrádku.

V tomto přirovnání:

- **Vy** jste **uživatel**.
- **Vaše auto** je **MCP server** s cennými nástroji a daty.
- **Parkovací služba** je **Microsoft Entra ID**.
- **Parkovací asistent** je **MCP klient** (aplikace, která se snaží přistupovat k serveru).
- **Parkovací klíč** je **přístupový token**.

Přístupový token je bezpečný textový řetězec, který MCP klient obdrží od Entra ID po přihlášení uživatele. Klient pak tento token předkládá serveru při každém požadavku. Server může token ověřit, aby zajistil, že je žádost legitimní a že klient má potřebná oprávnění, a to bez nutnosti manipulovat s vašimi skutečnými přihlašovacími údaji (například heslem).

### Průběh autentizace

Proces v praxi vypadá takto:

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

### Představení Microsoft Authentication Library (MSAL)

Než se pustíme do kódu, je důležité představit klíčovou komponentu, kterou uvidíte v příkladech: **Microsoft Authentication Library (MSAL)**.

MSAL je knihovna vyvinutá Microsoftem, která vývojářům výrazně usnadňuje práci s autentizací. Místo toho, abyste psali složitý kód pro správu bezpečnostních tokenů, přihlašování a obnovování relací, MSAL tyto náročné úkoly vyřeší za vás.

Použití knihovny jako MSAL je velmi doporučováno, protože:

- **Je bezpečná:** Implementuje průmyslové standardy a osvědčené bezpečnostní postupy, čímž snižuje riziko zranitelností ve vašem kódu.
- **Zjednodušuje vývoj:** Abstrahuje složitost protokolů OAuth 2.0 a OpenID Connect, takže do aplikace můžete přidat robustní autentizaci s pár řádky kódu.
- **Je udržovaná:** Microsoft aktivně aktualizuje MSAL, aby řešil nové bezpečnostní hrozby a změny platforem.

MSAL podporuje širokou škálu jazyků a aplikačních frameworků, včetně .NET, JavaScript/TypeScript, Python, Java, Go a mobilních platforem jako iOS a Android. To znamená, že můžete používat konzistentní autentizační vzory napříč celým technologickým stackem.

Více o MSAL se dozvíte v oficiální [dokumentaci MSAL overview](https://learn.microsoft.com/entra/identity-platform/msal-overview).

---

## Zabezpečení vašeho MCP serveru pomocí Entra ID: krok za krokem

Nyní si projdeme, jak zabezpečit lokální MCP server (ten, který komunikuje přes `stdio`) using Entra ID. This example uses a **public client**, which is suitable for applications running on a user's machine, like a desktop app or a local development server.

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
- **`AcquireTokenAsync`**: Toto je klíčová metoda. Nejprve se pokusí získat token potichu (uživatel se nemusí znovu přihlašovat, pokud má platnou relaci). Pokud není možné token získat potichu, vyzve uživatele k interaktivnímu přihlášení.

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
- **`GetUserDetailsFromGraph` tool**: This tool requires an instance of `AuthenticationService`. Before it does anything, it calls `authService.AcquireTokenAsync()` použije platný přístupový token. Pokud je autentizace úspěšná, token použije k volání Microsoft Graph API a získání uživatelských údajů.

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

#### 3. Jak to všechno funguje dohromady

1. Když MCP klient zavolá `GetUserDetailsFromGraph` tool, the tool first calls `AcquireTokenAsync`.
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
- **`/auth/callback`**: Tento endpoint zpracovává přesměrování z Entra ID po autentizaci uživatele. Vymění autorizační kód za přístupový a obnovovací token.

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

This file defines the tools that the MCP server provides. The `getUserDetails` nástroj je podobný tomu v předchozím příkladu, ale získává přístupový token ze session.

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
6. When the `getUserDetails` nástroj je volán s tokenem ze session, který vyhledá přístupový token Entra ID a ten pak použije k volání Microsoft Graph API.

Tento tok je složitější než u veřejného klienta, ale je nezbytný pro internetově dostupné endpointy. Vzhledem k tomu, že vzdálené MCP servery jsou přístupné přes veřejný internet, vyžadují silnější bezpečnostní opatření k ochraně proti neoprávněnému přístupu a možným útokům.

## Osvědčené bezpečnostní postupy

- **Vždy používejte HTTPS**: Šifrujte komunikaci mezi klientem a serverem, aby se zabránilo zachycení tokenů.
- **Implementujte řízení přístupu na základě rolí (RBAC)**: Nekontrolujte jen *zda* je uživatel autentizován, ale i *co* má oprávnění dělat. Role můžete definovat v Entra ID a kontrolovat je na vašem MCP serveru.
- **Monitorujte a auditujte**: Logujte všechny autentizační události, abyste mohli odhalit a reagovat na podezřelou aktivitu.
- **Řešte omezení počtu požadavků a throttling**: Microsoft Graph a další API implementují omezení rychlosti, aby zabránily zneužití. V MCP serveru implementujte exponenciální zálohování a logiku opakování požadavků pro hladké zvládání HTTP 429 (Too Many Requests). Zvažte cachování často přistupovaných dat ke snížení počtu volání API.
- **Bezpečné uložení tokenů**: Přístupové a obnovovací tokeny ukládejte bezpečně. Pro lokální aplikace využijte zabezpečené úložiště systému. Pro serverové aplikace zvažte šifrované úložiště nebo služby správy klíčů, jako je Azure Key Vault.
- **Řízení expirace tokenů**: Přístupové tokeny mají omezenou platnost. Implementujte automatické obnovení tokenů pomocí obnovovacích tokenů, aby uživatel nemusel opakovaně zadávat přihlašovací údaje.
- **Zvažte použití Azure API Management**: I když přímá implementace zabezpečení v MCP serveru dává detailní kontrolu, API Gateway jako Azure API Management mohou automaticky řešit mnoho bezpečnostních aspektů včetně autentizace, autorizace, omezení rychlosti a monitoringu. Poskytují centralizovanou bezpečnostní vrstvu mezi klienty a MCP servery. Více informací o použití API Gateway s MCP naleznete v našem [Azure API Management Your Auth Gateway For MCP Servers](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690).

## Klíčové body

- Zabezpečení vašeho MCP serveru je zásadní pro ochranu dat a nástrojů.
- Microsoft Entra ID nabízí robustní a škálovatelné řešení pro autentizaci a autorizaci.
- Pro lokální aplikace používejte **veřejného klienta**, pro vzdálené servery **důvěrného klienta**.
- **Authorization Code Flow** je nejbezpečnější možnost pro webové aplikace.

## Cvičení

1. Zamyslete se nad MCP serverem, který byste mohli vytvořit. Bude to lokální nebo vzdálený server?
2. Na základě odpovědi, použijete veřejného nebo důvěrného klienta?
3. Jaká oprávnění by váš MCP server požadoval pro operace vůči Microsoft Graph?

## Praktická cvičení

### Cvičení 1: Registrace aplikace v Entra ID
Přejděte do Microsoft Entra portálu.  
Zaregistrujte novou aplikaci pro váš MCP server.  
Poznamenejte si Application (client) ID a Directory (tenant) ID.

### Cvičení 2: Zabezpečení lokálního MCP serveru (veřejný klient)
- Postupujte podle příkladu kódu a integrujte MSAL (Microsoft Authentication Library) pro autentizaci uživatelů.
- Otestujte autentizační tok voláním nástroje MCP, který získává uživatelské údaje z Microsoft Graph.

### Cvičení 3: Zabezpečení vzdáleného MCP serveru (důvěrný klient)
- Zaregistrujte důvěrného klienta v Entra ID a vytvořte klientské tajemství.
- Nakonfigurujte váš Express.js MCP server pro použití Authorization Code Flow.
- Otestujte chráněné endpointy a ověřte přístup na základě tokenu.

### Cvičení 4: Aplikace bezpečnostních osvědčených postupů
- Zapněte HTTPS pro váš lokální nebo vzdálený server.
- Implementujte řízení přístupu na základě rolí (RBAC) v logice serveru.
- Přidejte správu expirace tokenů a bezpečné ukládání tokenů.

## Zdroje

1. **MSAL Overview Documentation**  
   Naučte se, jak Microsoft Authentication Library (MSAL) umožňuje bezpečné získávání tokenů napříč platformami:  
   [MSAL Overview on Microsoft Learn](https://learn.microsoft.com/en-gb/entra/msal/overview)

2. **Azure-Samples/mcp-auth-servers GitHub Repository**  
   Referenční implementace MCP serverů demonstrující autentizační toky:  
   [Azure-Samples/mcp-auth-servers on GitHub](https://github.com/Azure-Samples/mcp-auth-servers)

3. **Managed Identities for Azure Resources Overview**  
   Pochopte, jak eliminovat tajemství pomocí spravovaných identit přiřazených systémem nebo uživatelem:  
   [Managed Identities Overview on Microsoft Learn](https://learn.microsoft.com/en-us/entra/identity/managed-identities-azure-resources/)

4. **Azure API Management: Your Auth Gateway for MCP Servers**  
   Podrobný pohled na použití APIM jako bezpečné OAuth2 brány pro MCP servery:  
   [Azure API Management Your Auth Gateway For MCP Servers](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

5. **Microsoft Graph Permissions Reference**  
   Kompletní seznam delegovaných a aplikačních oprávnění pro Microsoft Graph:  
   [Microsoft Graph Permissions Reference](https://learn.microsoft.com/zh-tw/graph/permissions-reference)

## Výsledky učení
Po dokončení této části budete schopni:

- Vysvětlit, proč je autentizace klíčová pro MCP servery a AI pracovní toky.
- Nastavit a konfigurovat autentizaci Entra ID pro lokální i vzdálené MCP servery.
- Vybrat správný typ klienta (veřejný nebo důvěrný) podle nasazení serveru.
- Implementovat bezpečnostní postupy včetně ukládání tokenů a autorizace na základě rolí.
- S jistotou chránit váš MCP server a jeho nástroje před neoprávněným přístupem.

## Co dál

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). Přestože usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Originální dokument v jeho mateřském jazyce by měl být považován za závazný zdroj. Pro důležité informace se doporučuje využít profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.