<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0abf26a6c4dbe905d5d49ccdc0ccfe92",
  "translation_date": "2025-06-26T16:44:26+00:00",
  "source_file": "05-AdvancedTopics/mcp-security-entra/README.md",
  "language_code": "uk"
}
-->
# Захист AI робочих процесів: Аутентифікація Entra ID для серверів Model Context Protocol

## Вступ  
Захист вашого сервера Model Context Protocol (MCP) так само важливий, як замикати вхідні двері у вашому будинку. Якщо залишити сервер MCP відкритим, ваші інструменти та дані можуть стати доступними для несанкціонованого використання, що може призвести до порушень безпеки. Microsoft Entra ID пропонує надійне хмарне рішення для управління ідентичністю та доступом, допомагаючи гарантувати, що лише авторизовані користувачі та додатки можуть взаємодіяти з вашим сервером MCP. У цьому розділі ви дізнаєтеся, як захистити ваші AI робочі процеси за допомогою аутентифікації Entra ID.

## Цілі навчання  
Після завершення цього розділу ви зможете:

- Усвідомити важливість захисту серверів MCP.
- Пояснити основи Microsoft Entra ID та аутентифікації OAuth 2.0.
- Розрізняти публічних і конфіденційних клієнтів.
- Впроваджувати аутентифікацію Entra ID як для локальних (публічний клієнт), так і для віддалених (конфіденційний клієнт) сценаріїв роботи MCP серверів.
- Застосовувати найкращі практики безпеки при розробці AI робочих процесів.

## Безпека та MCP  

Якщо ви не залишаєте вхідні двері свого будинку незамкненими, так само не варто залишати сервер MCP відкритим для всіх. Захист AI робочих процесів є ключовим для створення надійних, довірених і безпечних додатків. У цій главі ми познайомимо вас із використанням Microsoft Entra ID для захисту серверів MCP, щоб лише авторизовані користувачі та додатки могли взаємодіяти з вашими інструментами та даними.

## Чому безпека важлива для серверів MCP  

Уявіть, що ваш сервер MCP має інструмент, який може надсилати електронні листи або отримувати доступ до бази даних клієнтів. Якщо сервер не захищений, будь-хто може скористатися цим інструментом, що призведе до несанкціонованого доступу до даних, спаму або інших шкідливих дій.

Впроваджуючи аутентифікацію, ви гарантуєте, що кожен запит до сервера перевіряється, підтверджуючи особу користувача або додатку, що робить запит. Це перший і найважливіший крок у захисті ваших AI робочих процесів.

## Вступ до Microsoft Entra ID  

[**Microsoft Entra ID**](https://adoption.microsoft.com/microsoft-security/entra/) — це хмарний сервіс для управління ідентичністю та доступом. Уявіть його як універсального охоронця безпеки для ваших додатків. Він обробляє складний процес перевірки ідентичності користувачів (аутентифікація) та визначення їх прав (авторизація).

Використовуючи Entra ID, ви можете:

- Забезпечити безпечний вхід користувачів.
- Захистити API та сервіси.
- Керувати політиками доступу з єдиного центру.

Для серверів MCP Entra ID пропонує надійне і широко визнане рішення для управління тим, хто може отримати доступ до можливостей вашого сервера.

---

## Розуміння принципу роботи: як працює аутентифікація Entra ID  

Entra ID використовує відкриті стандарти, такі як **OAuth 2.0**, для обробки аутентифікації. Хоча деталі можуть бути складними, основна ідея проста і зрозуміла на прикладі аналогії.

### Легка інтродукція до OAuth 2.0: ключ для парковщика  

Уявіть OAuth 2.0 як службу парковки для вашого автомобіля. Коли ви приходите до ресторану, ви не даєте парковщику свій головний ключ. Натомість ви надаєте **ключ для парковщика**, який має обмежені права — він може завести машину та зачинити двері, але не може відкрити багажник або бардачок.

У цій аналогії:

- **Ви** — це **Користувач**.
- **Ваш автомобіль** — це **сервер MCP** з його цінними інструментами та даними.
- **Парковщик** — це **Microsoft Entra ID**.
- **Працівник паркінгу** — це **клієнт MCP** (додаток, що намагається отримати доступ до сервера).
- **Ключ для парковщика** — це **токен доступу**.

Токен доступу — це захищений рядок тексту, який клієнт MCP отримує від Entra ID після вашого входу. Клієнт потім передає цей токен серверу MCP з кожним запитом. Сервер може перевірити токен, щоб переконатися, що запит є легітимним і клієнт має необхідні права, і все це без необхідності обробляти ваші реальні облікові дані (наприклад, пароль).

### Потік аутентифікації  

Ось як цей процес працює на практиці:

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

### Знайомство з Microsoft Authentication Library (MSAL)  

Перш ніж перейти до коду, важливо познайомитися з ключовим компонентом, який ви побачите в прикладах: **Microsoft Authentication Library (MSAL)**.

MSAL — це бібліотека, розроблена Microsoft, яка значно полегшує розробникам роботу з аутентифікацією. Замість того, щоб писати весь складний код для обробки токенів безпеки, керування входами та оновлення сесій, MSAL бере на себе ці завдання.

Використання бібліотеки MSAL настійно рекомендується, тому що:

- **Вона безпечна:** реалізує протоколи галузевого стандарту та найкращі практики безпеки, знижуючи ризик вразливостей у вашому коді.
- **Спрощує розробку:** приховує складність протоколів OAuth 2.0 та OpenID Connect, дозволяючи додати надійну аутентифікацію до вашого додатку всього кількома рядками коду.
- **Підтримується:** Microsoft активно підтримує та оновлює MSAL для боротьби з новими загрозами безпеки та змінами платформ.

MSAL підтримує широкий спектр мов програмування та фреймворків, включно з .NET, JavaScript/TypeScript, Python, Java, Go, а також мобільні платформи iOS та Android. Це означає, що ви можете використовувати однакові патерни аутентифікації по всьому вашому технологічному стеку.

Детальніше про MSAL можна дізнатися в офіційній [документації MSAL overview](https://learn.microsoft.com/entra/identity-platform/msal-overview).

---

## Захист вашого MCP сервера за допомогою Entra ID: покрокова інструкція  

Тепер розглянемо, як захистити локальний сервер MCP (той, що спілкується через `stdio`) using Entra ID. This example uses a **public client**, which is suitable for applications running on a user's machine, like a desktop app or a local development server.

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
- **`AcquireTokenAsync`**: це основний метод. Спочатку він намагається отримати токен тихо (тобто користувачу не потрібно повторно входити, якщо сесія дійсна). Якщо отримати токен тихо не вдається, користувач буде запрошений увійти інтерактивно.

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
- **`GetUserDetailsFromGraph` tool**: This tool requires an instance of `AuthenticationService`. Before it does anything, it calls `authService.AcquireTokenAsync()` отримує дійсний токен доступу. Якщо аутентифікація успішна, цей токен використовується для виклику Microsoft Graph API та отримання деталей користувача.

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

#### 3. Як це працює разом  

1. Коли клієнт MCP викликає `GetUserDetailsFromGraph` tool, the tool first calls `AcquireTokenAsync`.
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
- **`/auth/callback`**: цей ендпоінт обробляє перенаправлення від Entra ID після аутентифікації користувача. Він обмінює код авторизації на токен доступу та токен оновлення.

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

This file defines the tools that the MCP server provides. The `getUserDetails` інструмент схожий на попередній приклад, але отримує токен доступу з сесії.

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
6. When the `getUserDetails` інструмент викликається, він використовує токен сесії для пошуку токена доступу Entra ID, а потім виконує виклик Microsoft Graph API.

Цей потік складніший за публічний клієнт, але необхідний для інтернет-доступних ендпоінтів. Оскільки віддалені сервери MCP доступні через публічний інтернет, їм потрібні більш надійні заходи безпеки для захисту від несанкціонованого доступу та потенційних атак.

## Найкращі практики безпеки  

- **Завжди використовуйте HTTPS**: шифруйте зв’язок між клієнтом і сервером, щоб захистити токени від перехоплення.
- **Впроваджуйте контроль доступу на основі ролей (RBAC)**: перевіряйте не лише *чи* користувач аутентифікований, а й *що* йому дозволено робити. Ви можете визначати ролі в Entra ID і перевіряти їх у вашому MCP сервері.
- **Моніторинг та аудит**: ведіть журнал усіх подій аутентифікації, щоб виявляти та реагувати на підозрілі дії.
- **Обробка обмежень та лімітів**: Microsoft Graph та інші API застосовують обмеження на кількість запитів, щоб уникнути зловживань. Реалізуйте логіку експоненціального відновлення та повторних спроб у вашому MCP сервері для коректної обробки відповіді HTTP 429 (Забагато запитів). Розгляньте кешування часто використовуваних даних для зменшення кількості викликів API.
- **Безпечне зберігання токенів**: зберігайте токени доступу та оновлення безпечно. Для локальних додатків використовуйте системні механізми безпечного зберігання. Для серверних додатків розгляньте шифроване зберігання або сервіси керування ключами, наприклад Azure Key Vault.
- **Обробка терміну дії токенів**: токени доступу мають обмежений термін дії. Впровадьте автоматичне оновлення токенів за допомогою токенів оновлення, щоб забезпечити безперебійну роботу без повторної аутентифікації.
- **Розгляньте використання Azure API Management**: хоча реалізація безпеки безпосередньо в MCP сервері дає тонкий контроль, API шлюзи, як Azure API Management, можуть автоматично обробляти багато питань безпеки, включно з аутентифікацією, авторизацією, обмеженням кількості запитів та моніторингом. Вони забезпечують централізований рівень захисту між вашими клієнтами та MCP серверами. Детальніше про використання API шлюзів із MCP дивіться в нашому [Azure API Management Your Auth Gateway For MCP Servers](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690).

## Основні висновки  

- Захист вашого MCP сервера є критично важливим для безпеки ваших даних та інструментів.
- Microsoft Entra ID пропонує надійне та масштабоване рішення для аутентифікації та авторизації.
- Використовуйте **публічного клієнта** для локальних додатків та **конфіденційного клієнта** для віддалених серверів.
- **Потік коду авторизації (Authorization Code Flow)** — найнадійніший варіант для веб-додатків.

## Вправа  

1. Подумайте про сервер MCP, який ви могли б створити. Чи буде це локальний сервер, чи віддалений?  
2. Виходячи з відповіді, який тип клієнта ви б використали: публічний чи конфіденційний?  
3. Які дозволи ваш MCP сервер буде запитувати для роботи з Microsoft Graph?

## Практичні завдання  

### Завдання 1: Зареєструйте додаток у Entra ID  
Перейдіть до порталу Microsoft Entra.  
Зареєструйте новий додаток для вашого MCP сервера.  
Запишіть Ідентифікатор додатка (client ID) та Ідентифікатор каталогу (tenant ID).

### Завдання 2: Захист локального MCP сервера (публічний клієнт)  
- Виконайте інтеграцію MSAL (Microsoft Authentication Library) для аутентифікації користувача за кодом прикладу.  
- Перевірте процес аутентифікації, викликавши інструмент MCP, який отримує деталі користувача з Microsoft Graph.

### Завдання 3: Захист віддаленого MCP сервера (конфіденційний клієнт)  
- Зареєструйте конфіденційного клієнта в Entra ID та створіть секрет клієнта.  
- Налаштуйте сервер MCP на Express.js для використання потоку коду авторизації (Authorization Code Flow).  
- Перевірте захищені кінцеві точки та підтвердіть доступ на основі токенів.

### Завдання 4: Застосування найкращих практик безпеки  
- Увімкніть HTTPS для вашого локального або віддаленого сервера.  
- Впровадьте контроль доступу на основі ролей (RBAC) у логіці сервера.  
- Додайте обробку терміну дії токенів і безпечне зберігання токенів.

## Ресурси  

1. **Огляд документації MSAL**  
   Дізнайтеся, як Microsoft Authentication Library (MSAL) забезпечує безпечне отримання токенів на різних платформах:  
   [MSAL Overview на Microsoft Learn](https://learn.microsoft.com/en-gb/entra/msal/overview)

2. **Репозиторій Azure-Samples/mcp-auth-servers на GitHub**  
   Приклади реалізацій серверів MCP з демонстрацією потоків аутентифікації:  
   [Azure-Samples/mcp-auth-servers на GitHub](https://github.com/Azure-Samples/mcp-auth-servers)

3. **Огляд керованих ідентичностей для ресурсів Azure**  
   Як позбутися секретів, використовуючи системні або призначені користувачем керовані ідентичності:  
   [Огляд керованих ідентичностей на Microsoft Learn](https://learn.microsoft.com/en-us/entra/identity/managed-identities-azure-resources/)

4. **Azure API Management: Ваш шлюз аутентифікації для серверів MCP**  
   Детальний розгляд використання APIM як безпечного шлюзу OAuth2 для серверів MCP:  
   [Azure API Management Your Auth Gateway For MCP Servers](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

5. **Довідник дозволів Microsoft Graph**  
   Повний перелік делегованих та прикладних дозволів для Microsoft Graph:  
   [Microsoft Graph Permissions Reference](https://learn.microsoft.com/zh-tw/graph/permissions-reference)

## Результати навчання  
Після завершення цього розділу ви зможете:

- Пояснити, чому аутентифікація є критичною для серверів MCP та AI робочих процесів.  
- Налаштувати та

**Відмова від відповідальності**:  
Цей документ був перекладений за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоча ми прагнемо до точності, будь ласка, майте на увазі, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критичної інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння або неправильні тлумачення, що виникли внаслідок використання цього перекладу.