<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9abe1d303ab126f9a8b87f03cebe5213",
  "translation_date": "2025-06-26T14:34:23+00:00",
  "source_file": "05-AdvancedTopics/mcp-security-entra/README.md",
  "language_code": "fa"
}
-->
# ایمن‌سازی جریان‌های کاری هوش مصنوعی: احراز هویت Entra ID برای سرورهای پروتکل مدل کانتکست

## مقدمه  
امن نگه داشتن سرور Model Context Protocol (MCP) به اندازه قفل کردن درب ورودی خانه شما اهمیت دارد. باز گذاشتن سرور MCP باعث می‌شود ابزارها و داده‌های شما در معرض دسترسی غیرمجاز قرار بگیرند که می‌تواند به نفوذهای امنیتی منجر شود. Microsoft Entra ID یک راهکار مدیریت هویت و دسترسی مبتنی بر ابر ارائه می‌دهد که کمک می‌کند فقط کاربران و برنامه‌های مجاز بتوانند با سرور MCP شما تعامل داشته باشند. در این بخش، یاد می‌گیرید چگونه با استفاده از احراز هویت Entra ID، جریان‌های کاری هوش مصنوعی خود را محافظت کنید.

## اهداف آموزشی  
تا پایان این بخش قادر خواهید بود:

- اهمیت ایمن‌سازی سرورهای MCP را درک کنید.  
- اصول پایه‌ای Microsoft Entra ID و احراز هویت OAuth 2.0 را توضیح دهید.  
- تفاوت بین کلاینت‌های عمومی و محرمانه را بشناسید.  
- احراز هویت Entra ID را در سناریوهای سرور MCP محلی (کلاینت عمومی) و راه دور (کلاینت محرمانه) پیاده‌سازی کنید.  
- بهترین شیوه‌های امنیتی را هنگام توسعه جریان‌های کاری هوش مصنوعی به کار ببرید.

# ایمن‌سازی جریان‌های کاری هوش مصنوعی: احراز هویت Entra ID برای سرورهای پروتکل مدل کانتکست

همانطور که درب ورودی خانه خود را باز نمی‌گذارید، نباید سرور MCP خود را برای دسترسی آزاد بگذارید. امنیت جریان‌های کاری هوش مصنوعی برای ساخت برنامه‌های مقاوم، قابل اعتماد و امن ضروری است. این فصل شما را با استفاده از Microsoft Entra ID برای ایمن‌سازی سرورهای MCP آشنا می‌کند تا فقط کاربران و برنامه‌های مجاز بتوانند به ابزارها و داده‌های شما دسترسی داشته باشند.

## چرا امنیت برای سرورهای MCP اهمیت دارد

تصور کنید سرور MCP شما ابزاری دارد که می‌تواند ایمیل ارسال کند یا به پایگاه داده مشتریان دسترسی پیدا کند. یک سرور بدون امنیت یعنی هر کسی می‌تواند از آن ابزار استفاده کند که منجر به دسترسی غیرمجاز به داده‌ها، ارسال هرزنامه یا فعالیت‌های مخرب دیگر می‌شود.

با پیاده‌سازی احراز هویت، اطمینان حاصل می‌کنید که هر درخواست به سرور شما تأیید شده است و هویت کاربر یا برنامه‌ای که درخواست را ارسال می‌کند، تأیید می‌شود. این اولین و مهم‌ترین گام در ایمن‌سازی جریان‌های کاری هوش مصنوعی است.

## معرفی Microsoft Entra ID

**Microsoft Entra ID** یک سرویس مدیریت هویت و دسترسی مبتنی بر ابر است. آن را مانند یک نگهبان امنیتی جهانی برای برنامه‌های خود تصور کنید. این سرویس فرآیند پیچیده تأیید هویت کاربران (احراز هویت) و تعیین مجوزهای آن‌ها (مجوزدهی) را مدیریت می‌کند.

با استفاده از Entra ID می‌توانید:

- ورود امن کاربران را فعال کنید.  
- APIها و سرویس‌ها را محافظت کنید.  
- سیاست‌های دسترسی را از یک نقطه مرکزی مدیریت کنید.

برای سرورهای MCP، Entra ID یک راهکار قوی و مورد اعتماد برای مدیریت دسترسی به قابلیت‌های سرور شما فراهم می‌کند.

---

## درک عملکرد جادویی: چگونه احراز هویت Entra ID کار می‌کند

Entra ID از استانداردهای باز مانند **OAuth 2.0** برای مدیریت احراز هویت استفاده می‌کند. اگرچه جزئیات ممکن است پیچیده باشد، مفهوم اصلی ساده است و می‌توان آن را با یک تشبیه فهمید.

### معرفی ساده OAuth 2.0: کلید پارکینگ

OAuth 2.0 را مانند سرویس پارکینگ برای ماشین خود تصور کنید. وقتی به رستوران می‌رسید، کلید اصلی ماشین خود را به پارکبان نمی‌دهید. در عوض، یک **کلید پارکینگ** به او می‌دهید که دسترسی محدودی دارد—می‌تواند ماشین را روشن کند و درها را قفل کند، اما نمی‌تواند صندوق عقب یا داشبورد را باز کند.

در این تشبیه:

- **شما** همان **کاربر** هستید.  
- **ماشین شما** همان **سرور MCP** با ابزارها و داده‌های ارزشمند است.  
- **پارکبان** همان **Microsoft Entra ID** است.  
- **سرایدار پارکینگ** همان **کلاینت MCP** (برنامه‌ای که می‌خواهد به سرور دسترسی پیدا کند) است.  
- **کلید پارکینگ** همان **توکن دسترسی** است.

توکن دسترسی رشته‌ای امن از متن است که کلاینت MCP پس از ورود شما از Entra ID دریافت می‌کند. سپس کلاینت این توکن را با هر درخواست به سرور MCP ارائه می‌دهد. سرور می‌تواند توکن را تأیید کند تا اطمینان یابد درخواست مشروع است و کلاینت مجوزهای لازم را دارد، بدون اینکه نیازی به پردازش مستقیم اطلاعات محرمانه شما (مانند رمز عبور) باشد.

### جریان احراز هویت

فرآیند به این صورت کار می‌کند:

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

### معرفی کتابخانه احراز هویت مایکروسافت (MSAL)

قبل از ورود به کد، مهم است که یک جزء کلیدی را معرفی کنیم که در مثال‌ها خواهید دید: **کتابخانه احراز هویت مایکروسافت (MSAL)**.

MSAL کتابخانه‌ای است که توسط مایکروسافت توسعه یافته و کار توسعه‌دهندگان را برای مدیریت احراز هویت بسیار ساده‌تر می‌کند. به جای اینکه خودتان کد پیچیده مدیریت توکن‌های امنیتی، ورود کاربران و تازه‌سازی نشست‌ها را بنویسید، MSAL این کارهای سنگین را بر عهده می‌گیرد.

استفاده از کتابخانه‌ای مانند MSAL بسیار توصیه می‌شود زیرا:

- **امن است:** پروتکل‌های استاندارد صنعتی و بهترین شیوه‌های امنیتی را پیاده‌سازی می‌کند و ریسک آسیب‌پذیری‌ها را کاهش می‌دهد.  
- **توسعه را ساده می‌کند:** پیچیدگی‌های پروتکل‌های OAuth 2.0 و OpenID Connect را پنهان می‌کند و اجازه می‌دهد فقط با چند خط کد احراز هویت قدرتمند به برنامه خود اضافه کنید.  
- **نگهداری می‌شود:** مایکروسافت به‌طور فعال MSAL را به‌روزرسانی می‌کند تا تهدیدات امنیتی جدید و تغییرات پلتفرم را پوشش دهد.

MSAL از زبان‌ها و فریم‌ورک‌های متنوعی پشتیبانی می‌کند، از جمله .NET، JavaScript/TypeScript، Python، Java، Go و پلتفرم‌های موبایل مانند iOS و Android. این یعنی می‌توانید از الگوهای احراز هویت یکسان در کل فناوری خود استفاده کنید.

برای کسب اطلاعات بیشتر در مورد MSAL، می‌توانید به مستندات رسمی [MSAL overview documentation](https://learn.microsoft.com/entra/identity-platform/msal-overview) مراجعه کنید.

---

## ایمن‌سازی سرور MCP با Entra ID: راهنمای گام‌به‌گام

حال بیایید قدم به قدم ببینیم چگونه یک سرور MCP محلی (که از طریق `stdio`) using Entra ID. This example uses a **public client**, which is suitable for applications running on a user's machine, like a desktop app or a local development server.

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
- **`AcquireTokenAsync` ارتباط برقرار می‌کند) را ایمن کنیم: این متد اصلی است. ابتدا سعی می‌کند به صورت بی‌صدا توکن دریافت کند (یعنی اگر کاربر جلسه معتبری داشته باشد نیازی به ورود مجدد ندارد). اگر نتواند توکن بی‌صدا بگیرد، از کاربر می‌خواهد به صورت تعاملی وارد شود.

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
- **`GetUserDetailsFromGraph` tool**: This tool requires an instance of `AuthenticationService`. Before it does anything, it calls `authService.AcquireTokenAsync()` برای دریافت توکن دسترسی معتبر استفاده می‌کند. اگر احراز هویت موفق باشد، با استفاده از توکن به Microsoft Graph API درخواست می‌فرستد و جزئیات کاربر را دریافت می‌کند.

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

#### ۳. نحوه عملکرد همه چیز با هم

1. وقتی کلاینت MCP سعی می‌کند از `GetUserDetailsFromGraph` tool, the tool first calls `AcquireTokenAsync`.
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
- **`/auth/callback` استفاده کند: این نقطه انتهایی پس از ورود کاربر به Entra ID، بازگشت را مدیریت می‌کند. کد مجوز را با توکن دسترسی و توکن تازه‌سازی مبادله می‌کند.

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

ابزار `Tools.ts`**

This file defines the tools that the MCP server provides. The `getUserDetails` مشابه نمونه قبلی است، اما توکن دسترسی را از نشست دریافت می‌کند.

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

وقتی ابزار `auth/EntraIdServerAuthProvider.ts`**

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
6. When the `getUserDetails` فراخوانی می‌شود، از توکن نشست برای یافتن توکن دسترسی Entra ID استفاده می‌کند و سپس با آن به Microsoft Graph API درخواست می‌فرستد.

این جریان پیچیده‌تر از جریان کلاینت عمومی است، اما برای نقاط انتهایی قابل دسترس از اینترنت لازم است. از آنجا که سرورهای MCP راه دور از طریق اینترنت عمومی قابل دسترسی هستند، به اقدامات امنیتی قوی‌تری برای محافظت در برابر دسترسی غیرمجاز و حملات احتمالی نیاز دارند.

## بهترین شیوه‌های امنیتی

- **همیشه از HTTPS استفاده کنید:** ارتباط بین کلاینت و سرور را رمزگذاری کنید تا توکن‌ها در معرض رهگیری قرار نگیرند.  
- **پیاده‌سازی کنترل دسترسی مبتنی بر نقش (RBAC):** فقط بررسی نکنید که کاربر احراز هویت شده است، بلکه بررسی کنید چه مجوزهایی دارد. می‌توانید نقش‌ها را در Entra ID تعریف کرده و در سرور MCP خود بررسی کنید.  
- **نظارت و ممیزی:** همه رویدادهای احراز هویت را ثبت کنید تا بتوانید فعالیت‌های مشکوک را شناسایی و واکنش نشان دهید.  
- **مدیریت نرخ درخواست و محدودسازی:** Microsoft Graph و سایر APIها محدودیت نرخ دارند تا از سوءاستفاده جلوگیری کنند. در سرور MCP خود از الگوریتم بازگشت نمایی و منطق تکرار برای مدیریت پاسخ‌های HTTP 429 استفاده کنید. همچنین، داده‌های پر استفاده را کش کنید تا تعداد درخواست‌ها کاهش یابد.  
- **ذخیره امن توکن‌ها:** توکن‌های دسترسی و تازه‌سازی را به صورت امن ذخیره کنید. برای برنامه‌های محلی از مکانیزم‌های ذخیره‌سازی امن سیستم استفاده کنید. برای برنامه‌های سروری، از ذخیره‌سازی رمزنگاری شده یا سرویس‌های مدیریت کلید امن مانند Azure Key Vault بهره ببرید.  
- **مدیریت انقضای توکن:** توکن‌های دسترسی عمر محدودی دارند. با استفاده از توکن‌های تازه‌سازی، به صورت خودکار توکن‌ها را به‌روزرسانی کنید تا تجربه کاربری بدون نیاز به ورود مجدد حفظ شود.  
- **استفاده از Azure API Management را در نظر بگیرید:** هرچند پیاده‌سازی امنیت مستقیماً در سرور MCP کنترل دقیق‌تری به شما می‌دهد، API Gatewayهایی مانند Azure API Management می‌توانند بسیاری از نگرانی‌های امنیتی مانند احراز هویت، مجوزدهی، محدودیت نرخ و نظارت را به صورت خودکار مدیریت کنند. آن‌ها لایه امنیتی مرکزی بین کلاینت‌ها و سرورهای MCP شما فراهم می‌کنند. برای جزئیات بیشتر درباره استفاده از API Gateway با MCP، به [Azure API Management Your Auth Gateway For MCP Servers](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) مراجعه کنید.

## نکات کلیدی

- ایمن‌سازی سرور MCP برای محافظت از داده‌ها و ابزارهای شما حیاتی است.  
- Microsoft Entra ID راهکار قوی و مقیاس‌پذیری برای احراز هویت و مجوزدهی ارائه می‌دهد.  
- برای برنامه‌های محلی از کلاینت **عمومی** و برای سرورهای راه دور از کلاینت **محرمانه** استفاده کنید.  
- جریان **Authorization Code Flow** امن‌ترین گزینه برای برنامه‌های وب است.

## تمرین

1. به سرور MCP که ممکن است بسازید فکر کنید. آیا سرور محلی است یا راه دور؟  
2. بر اساس پاسخ خود، از کلاینت عمومی استفاده می‌کنید یا محرمانه؟  
3. سرور MCP شما برای انجام عملیات روی Microsoft Graph چه مجوزهایی درخواست می‌کند؟

## تمرین‌های عملی

### تمرین ۱: ثبت یک برنامه در Entra ID  
وارد پورتال Microsoft Entra شوید.  
یک برنامه جدید برای سرور MCP خود ثبت کنید.  
شناسه برنامه (client ID) و شناسه دایرکتوری (tenant ID) را یادداشت کنید.

### تمرین ۲: ایمن‌سازی یک سرور MCP محلی (کلاینت عمومی)  
از مثال کد استفاده کنید تا MSAL (کتابخانه احراز هویت مایکروسافت) را برای احراز هویت کاربران ادغام کنید.  
فرآیند احراز هویت را با فراخوانی ابزاری که جزئیات کاربر را از Microsoft Graph دریافت می‌کند، تست کنید.

### تمرین ۳: ایمن‌سازی یک سرور MCP راه دور (کلاینت محرمانه)  
یک کلاینت محرمانه در Entra ID ثبت کنید و یک کلید مخفی ایجاد کنید.  
سرور Express.js خود را برای استفاده از Authorization Code Flow پیکربندی کنید.  
نقاط انتهایی محافظت شده را تست کرده و دسترسی مبتنی بر توکن را تأیید کنید.

### تمرین ۴: اعمال بهترین شیوه‌های امنیتی  
برای سرور محلی یا راه دور خود HTTPS را فعال کنید.  
کنترل دسترسی مبتنی بر نقش (RBAC) را در منطق سرور پیاده کنید.  
مدیریت انقضای توکن و ذخیره امن توکن‌ها را اضافه کنید.

## منابع

1. **مستندات معرفی MSAL**  
   بیاموزید چگونه کتابخانه احراز هویت مایکروسافت (MSAL) امکان دریافت امن توکن در پلتفرم‌های مختلف را فراهم می‌کند:  
   [معرفی MSAL در Microsoft Learn](https://learn.microsoft.com/en-gb/entra/msal/overview)

2. **مخزن GitHub نمونه‌های Azure-Samples/mcp-auth-servers**  
   پیاده‌سازی‌های مرجع سرورهای MCP که جریان‌های احراز هویت را نشان می‌دهند:  
   [Azure-Samples/mcp-auth-servers در GitHub](https://github.com/Azure-Samples/mcp-auth-servers)

3. **مروری بر Managed Identities برای منابع Azure**  
   بیاموزید چگونه با استفاده از هویت‌های مدیریت شده سیستم یا کاربر، نیازی به نگهداری اسرار ندارید:  
   [مروری بر Managed Identities در Microsoft Learn](https://learn.microsoft.com/en-us/entra/identity/managed-identities-azure-resources/)

4. **Azure API Management: دروازه احراز هویت شما برای سرورهای MCP**  
   بررسی عمیق استفاده از APIM به عنوان دروازه امن OAuth2 برای سرورهای MCP:  
   [Azure API Management Your Auth Gateway For MCP Servers](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

5. **مرجع مجوزهای Microsoft Graph**  
   فهرست کامل مجوزهای تفویض شده و برنامه‌ای برای Microsoft Graph:  
   [مرجع مجوزهای Microsoft Graph](https://learn.microsoft.com/zh-tw/graph/permissions-reference)

## نتایج یادگیری  
پس از تکمیل این بخش، قادر خواهید بود:

- اهمیت احراز هویت برای سرورهای MCP و جریان‌های کاری هوش مصنوعی را بیان کنید.  
- احراز هویت Entra ID را برای سناریوهای سرور MCP محلی و راه دور راه‌اندازی و پیکربندی کنید.  
- بر اساس نوع استقرار سرور، کلاینت مناسب (عمومی یا محرمانه) را انتخاب کنید.  
- بهترین شیوه‌های برنامه‌نویسی امن از جمله ذخیره توکن و مجوزدهی مبتنی بر نقش را پیاده‌سازی کنید.  
- با اطمینان سرور MCP و ابزارهای آن را در برابر دسترسی غیرمجاز محافظت کنید.

## ادامه مسیر

- [۶. مشارکت‌های جامعه](../../06-CommunityContributions/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما برای دقت تلاش می‌کنیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است شامل اشتباهات یا نواقصی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا تفسیر نادرستی که از استفاده این ترجمه ناشی شود، نیستیم.