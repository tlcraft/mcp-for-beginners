<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0abf26a6c4dbe905d5d49ccdc0ccfe92",
  "translation_date": "2025-06-26T16:40:51+00:00",
  "source_file": "05-AdvancedTopics/mcp-security-entra/README.md",
  "language_code": "bg"
}
-->
# Осигуряване на AI работни процеси: Entra ID удостоверяване за Model Context Protocol сървъри

## Въведение  
Осигуряването на вашия Model Context Protocol (MCP) сървър е също толкова важно, колкото и заключването на входната врата на вашия дом. Оставянето на MCP сървъра отворен излага инструментите и данните ви на неоторизиран достъп, което може да доведе до пробиви в сигурността. Microsoft Entra ID предлага стабилно облачно решение за управление на идентичности и достъп, което гарантира, че само упълномощени потребители и приложения могат да взаимодействат с вашия MCP сървър. В този раздел ще научите как да защитите AI работните си процеси с помощта на удостоверяване чрез Entra ID.

## Учебни цели  
В края на този раздел ще можете да:

- Разберете значението на осигуряването на MCP сървъри.  
- Обясните основите на Microsoft Entra ID и удостоверяването чрез OAuth 2.0.  
- Разпознавате разликата между публични и конфиденциални клиенти.  
- Прилагате удостоверяване чрез Entra ID както за локални (публични клиенти), така и за отдалечени (конфиденциални клиенти) MCP сървърни сценарии.  
- Използвате най-добрите практики за сигурност при разработването на AI работни процеси.

## Сигурност и MCP  

Точно както не бихте оставили входната врата на дома си отключена, така не трябва да оставяте MCP сървъра си достъпен за всеки. Осигуряването на вашите AI работни процеси е от съществено значение за изграждането на стабилни, надеждни и безопасни приложения. Тази глава ще ви запознае с използването на Microsoft Entra ID за защита на вашите MCP сървъри, като гарантира, че само упълномощени потребители и приложения имат достъп до вашите инструменти и данни.

## Защо сигурността е важна за MCP сървърите  

Представете си, че вашият MCP сървър разполага с инструмент, който може да изпраща имейли или да достъпва база данни с клиенти. Несигурен сървър би означавал, че всеки може да използва този инструмент, което води до неоторизиран достъп до данни, спам или други злонамерени действия.

Чрез въвеждане на удостоверяване вие гарантирате, че всяка заявка към сървъра се проверява, потвърждавайки самоличността на потребителя или приложението, което я изпраща. Това е първата и най-важна стъпка за осигуряване на вашите AI работни процеси.

## Въведение в Microsoft Entra ID  

[**Microsoft Entra ID**](https://adoption.microsoft.com/microsoft-security/entra/) е облачна услуга за управление на идентичности и достъп. Можете да го разглеждате като универсален охранител за вашите приложения. Той се грижи за сложния процес на проверка на потребителските идентичности (удостоверяване) и определяне на правата им (авторизация).

С помощта на Entra ID можете да:

- Позволите сигурно влизане за потребителите.  
- Защитите API-та и услуги.  
- Управлявате политики за достъп от централно място.

За MCP сървъри Entra ID осигурява стабилно и широко доверено решение за управление на достъпа до възможностите на сървъра ви.

---

## Разбиране на магията: Как работи удостоверяването с Entra ID  

Entra ID използва отворени стандарти като **OAuth 2.0** за управление на удостоверяването. Въпреки че детайлите могат да са сложни, основната идея е проста и може да бъде разбрана чрез аналогия.

### Нежно въведение в OAuth 2.0: Ключът за паркиране  

Представете си OAuth 2.0 като услуга за паркиране на кола. Когато пристигате в ресторант, не давате на паркирача главния ключ. Вместо това му предоставяте **ключ за паркиране**, който има ограничени права – може да запали колата и да заключи вратите, но не може да отвори багажника или жабката.

В тази аналогия:

- **Вие** сте **Потребителят**.  
- **Вашата кола** е **MCP сървърът** с ценните му инструменти и данни.  
- **Паркирачът** е **Microsoft Entra ID**.  
- **Паркинг служителят** е **MCP клиентът** (приложението, което се опитва да достъпи сървъра).  
- **Ключът за паркиране** е **Access Token**.

Access token е защитен текстов низ, който MCP клиентът получава от Entra ID след вашето влизане. Клиентът след това представя този токен на MCP сървъра при всяка заявка. Сървърът може да провери токена, за да гарантира, че заявката е легитимна и че клиентът има необходимите права, без никога да се налага да обработва вашите реални идентификационни данни (като паролата ви).

### Потокът на удостоверяване  

Ето как процесът работи на практика:

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

### Запознаване с Microsoft Authentication Library (MSAL)  

Преди да навлезем в кода, важно е да ви запознаем с ключов компонент, който ще видите в примерите: **Microsoft Authentication Library (MSAL)**.

MSAL е библиотека, разработена от Microsoft, която улеснява значително работата на разработчиците с удостоверяването. Вместо да пишете сложен код за управление на сигурностните токени, влизания и обновяване на сесиите, MSAL се грижи за всичко това.

Използването на библиотека като MSAL е силно препоръчително, защото:

- **Е сигурна:** Прилага индустриални стандарти и най-добри практики за сигурност, намалявайки риска от уязвимости в кода ви.  
- **Опрощава разработката:** Скрива сложността на протоколите OAuth 2.0 и OpenID Connect, позволявайки ви да добавите стабилно удостоверяване към приложението си с няколко реда код.  
- **Поддържа се:** Microsoft активно поддържа и обновява MSAL, за да се справя с нови заплахи за сигурността и промени в платформите.

MSAL поддържа множество езици и рамки за разработка, включително .NET, JavaScript/TypeScript, Python, Java, Go и мобилни платформи като iOS и Android. Това ви позволява да използвате еднакви модели за удостоверяване във всички технологии, които използвате.

За повече информация относно MSAL, можете да разгледате официалната [документация за MSAL](https://learn.microsoft.com/entra/identity-platform/msal-overview).

---

## Осигуряване на вашия MCP сървър с Entra ID: Стъпка по стъпка  

Сега ще разгледаме как да защитите локален MCP сървър (който комуникира през `stdio`) using Entra ID. This example uses a **public client**, which is suitable for applications running on a user's machine, like a desktop app or a local development server.

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
- **`AcquireTokenAsync`**: Това е основният метод. Първо опитва да получи токен тихомълком (т.е. потребителят няма да се налага да влиза отново, ако вече има валидна сесия). Ако тихомълком не може да бъде получен токен, ще подканва потребителя за интерактивно влизане.

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
- **`GetUserDetailsFromGraph` tool**: This tool requires an instance of `AuthenticationService`. Before it does anything, it calls `authService.AcquireTokenAsync()` използва за получаване на валиден access token. Ако удостоверяването е успешно, токенът се използва за извикване на Microsoft Graph API и извличане на детайлите за потребителя.

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

#### 3. Как всичко работи заедно  

1. Когато MCP клиентът се опита да използва `GetUserDetailsFromGraph` tool, the tool first calls `AcquireTokenAsync`.
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
- **`/auth/callback`**: Този крайна точка обработва пренасочването от Entra ID след като потребителят се е удостоверил. Тя обменя кода за разрешение за access token и refresh token.

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

This file defines the tools that the MCP server provides. The `getUserDetails` инструментът е подобен на този в предишния пример, но взима access token-а от сесията.

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
6. When the `getUserDetails` инструментът се извиква, използвайки сесийния токен, за да намери Entra ID access token и след това го използва за извикване на Microsoft Graph API.

Този поток е по-сложен от този на публичния клиент, но е необходим за интернет-достъпни крайни точки. Тъй като отдалечените MCP сървъри са достъпни през публичния интернет, те се нуждаят от по-силни мерки за сигурност, за да се предпазят от неоторизиран достъп и потенциални атаки.

## Най-добри практики за сигурност

- **Винаги използвайте HTTPS:** Криптирайте комуникацията между клиента и сървъра, за да предпазите токените от прихващане.  
- **Прилагайте контрол на достъпа на базата на роли (RBAC):** Не проверявайте само дали потребителят е удостоверен, а и какво е упълномощен да прави. Можете да дефинирате роли в Entra ID и да ги проверявате в MCP сървъра.  
- **Наблюдавайте и одитирайте:** Записвайте всички събития по удостоверяване, за да можете да откривате и реагирате на подозрителна активност.  
- **Обработвайте ограничаването на честотата и натоварването:** Microsoft Graph и други API-та прилагат ограничение на честотата, за да предотвратят злоупотреби. Внедрете експоненциално изчакване и логика за повторен опит в MCP сървъра, за да обработвате плавно HTTP 429 (Твърде много заявки). Обмислете кеширане на често използвани данни, за да намалите броя на API повикванията.  
- **Сигурно съхранение на токени:** Съхранявайте access и refresh токени сигурно. За локални приложения използвайте системните механизми за защитено съхранение. За сървърни приложения обмислете криптирано съхранение или услуги за управление на ключове като Azure Key Vault.  
- **Обработка на изтичане на токени:** Access токените имат ограничен живот. Внедрете автоматично обновяване на токените с помощта на refresh токени, за да осигурите безпроблемно потребителско изживяване без необходимост от повторно удостоверяване.  
- **Обмислете използването на Azure API Management:** Докато прилагането на сигурност директно в MCP сървъра ви дава фина настройка, API шлюзове като Azure API Management могат автоматично да се справят с много от тези задачи, включително удостоверяване, авторизация, ограничаване на честотата и мониторинг. Те осигуряват централен слой за сигурност между клиентите и MCP сървърите ви. За повече информация относно използването на API шлюзове с MCP вижте [Azure API Management Your Auth Gateway For MCP Servers](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690).

## Основни изводи

- Осигуряването на MCP сървъра е ключово за защитата на вашите данни и инструменти.  
- Microsoft Entra ID предлага стабилно и мащабируемо решение за удостоверяване и авторизация.  
- Използвайте **публичен клиент** за локални приложения и **конфиденциален клиент** за отдалечени сървъри.  
- **Authorization Code Flow** е най-сигурният вариант за уеб приложения.

## Упражнение

1. Помислете за MCP сървър, който бихте създали. Ще бъде ли той локален или отдалечен?  
2. Въз основа на отговора си, бихте ли използвали публичен или конфиденциален клиент?  
3. Какви разрешения би поискал вашият MCP сървър, за да извършва действия срещу Microsoft Graph?

## Практически упражнения

### Упражнение 1: Регистрирайте приложение в Entra ID  
Отидете в портала на Microsoft Entra.  
Регистрирайте ново приложение за вашия MCP сървър.  
Запишете Application (client) ID и Directory (tenant) ID.

### Упражнение 2: Защитете локален MCP сървър (публичен клиент)  
- Следвайте примерния код за интегриране на MSAL (Microsoft Authentication Library) за удостоверяване на потребителите.  
- Тествайте потока на удостоверяване, като извикате MCP инструмента, който извлича детайли за потребителя от Microsoft Graph.

### Упражнение 3: Защитете отдалечен MCP сървър (конфиденциален клиент)  
- Регистрирайте конфиденциален клиент в Entra ID и създайте клиентска тайна.  
- Конфигурирайте Express.js MCP сървъра да използва Authorization Code Flow.  
- Тествайте защитените крайни точки и потвърдете достъпа чрез токен.

### Упражнение 4: Прилагайте най-добрите практики за сигурност  
- Активирайте HTTPS за вашия локален или отдалечен сървър.  
- Прилагайте контрол на достъпа на базата на роли (RBAC) в логиката на сървъра.  
- Добавете обработка на изтичане на токени и сигурно съхранение на токените.

## Ресурси

1. **MSAL Overview Documentation**  
   Научете как Microsoft Authentication Library (MSAL) осигурява сигурно получаване на токени на различни платформи:  
   [MSAL Overview on Microsoft Learn](https://learn.microsoft.com/en-gb/entra/msal/overview)

2. **Azure-Samples/mcp-auth-servers GitHub Repository**  
   Примерни реализации на MCP сървъри, демонстриращи потоци на удостоверяване:  
   [Azure-Samples/mcp-auth-servers on GitHub](https://github.com/Azure-Samples/mcp-auth-servers)

3. **Managed Identities for Azure Resources Overview**  
   Разберете как да елиминирате тайни, като използвате системно или потребителски присвоени управлявани идентичности:  
   [Managed Identities Overview on Microsoft Learn](https://learn.microsoft.com/en-us/entra/identity/managed-identities-azure-resources/)

4. **Azure API Management: Your Auth Gateway for MCP Servers**  
   Подробен преглед на използването на APIM като защитен OAuth2 шлюз за MCP сървъри:  
   [Azure API Management Your Auth Gateway For MCP Servers](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

5. **Microsoft Graph Permissions Reference**  
   Изчерпателен списък с делегирани и приложни разрешения за Microsoft Graph:  
   [Microsoft Graph Permissions Reference](https://learn.microsoft.com/zh-tw/graph/permissions-reference)

## Учебни резултати  
След завършване на този раздел ще можете да:

- Обясните защо удостоверяването е критично за MCP сървъри и AI работни процеси.  
- Настроите и конфигурирате удостоверяване с Entra ID за локални и отдалечени MCP сървърни сценарии.  
- Изберете подходящия тип клиент (публичен или конфиденциален) според разгръщането на сървъра.  
- Прилагате сигурни практики при кодиране, включително съхранение на

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматизираните преводи могат да съдържат грешки или неточности. Оригиналният документ на неговия първичен език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за каквито и да е недоразумения или погрешни тълкувания, произтичащи от използването на този превод.