<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6e562d7e5a77c8982da4aa8f762ad1d8",
  "translation_date": "2025-07-02T08:51:19+00:00",
  "source_file": "05-AdvancedTopics/mcp-security-entra/README.md",
  "language_code": "de"
}
-->
# Absicherung von KI-Workflows: Entra ID-Authentifizierung für Model Context Protocol-Server

## Einführung  
Die Absicherung Ihres Model Context Protocol (MCP)-Servers ist genauso wichtig wie das Abschließen der Haustür. Ein offener MCP-Server setzt Ihre Werkzeuge und Daten unbefugtem Zugriff aus, was zu Sicherheitsverletzungen führen kann. Microsoft Entra ID bietet eine leistungsstarke cloudbasierte Lösung für Identitäts- und Zugriffsmanagement, die sicherstellt, dass nur autorisierte Benutzer und Anwendungen mit Ihrem MCP-Server interagieren können. In diesem Abschnitt erfahren Sie, wie Sie Ihre KI-Workflows mithilfe der Entra ID-Authentifizierung schützen.

## Lernziele  
Am Ende dieses Abschnitts können Sie:

- Die Bedeutung der Absicherung von MCP-Servern verstehen.  
- Die Grundlagen von Microsoft Entra ID und OAuth 2.0-Authentifizierung erklären.  
- Den Unterschied zwischen öffentlichen und vertraulichen Clients erkennen.  
- Die Entra ID-Authentifizierung in lokalen (öffentlicher Client) und entfernten (vertraulicher Client) MCP-Server-Szenarien implementieren.  
- Sicherheitsbest Practices bei der Entwicklung von KI-Workflows anwenden.  

## Sicherheit und MCP  

So wie Sie Ihre Haustür nicht unverschlossen lassen würden, sollten Sie Ihren MCP-Server nicht für jedermann zugänglich machen. Die Absicherung Ihrer KI-Workflows ist entscheidend, um robuste, vertrauenswürdige und sichere Anwendungen zu erstellen. Dieses Kapitel zeigt Ihnen, wie Sie Microsoft Entra ID nutzen, um Ihre MCP-Server abzusichern und sicherzustellen, dass nur autorisierte Benutzer und Anwendungen auf Ihre Werkzeuge und Daten zugreifen können.

## Warum Sicherheit für MCP-Server wichtig ist  

Stellen Sie sich vor, Ihr MCP-Server verfügt über ein Tool, das E-Mails versenden oder auf eine Kundendatenbank zugreifen kann. Ein ungesicherter Server bedeutet, dass jeder dieses Tool potenziell nutzen könnte, was zu unbefugtem Datenzugriff, Spam oder anderen böswilligen Aktivitäten führt.

Durch die Implementierung von Authentifizierung stellen Sie sicher, dass jede Anfrage an Ihren Server überprüft wird und die Identität des Benutzers oder der Anwendung bestätigt wird. Dies ist der erste und wichtigste Schritt, um Ihre KI-Workflows zu sichern.

## Einführung in Microsoft Entra ID  

[**Microsoft Entra ID**](https://adoption.microsoft.com/microsoft-security/entra/) ist ein cloudbasierter Dienst für Identitäts- und Zugriffsmanagement. Man kann es sich wie einen universellen Sicherheitsdienst für Ihre Anwendungen vorstellen. Es übernimmt den komplexen Prozess der Verifizierung von Benutzeridentitäten (Authentifizierung) und der Festlegung, was diese tun dürfen (Autorisierung).

Mit Entra ID können Sie:

- Sichere Anmeldungen für Benutzer ermöglichen.  
- APIs und Dienste schützen.  
- Zugriffsrichtlinien zentral verwalten.  

Für MCP-Server bietet Entra ID eine robuste und weithin vertrauenswürdige Lösung, um zu steuern, wer auf die Funktionen Ihres Servers zugreifen darf.

---

## Das Prinzip verstehen: Wie Entra ID-Authentifizierung funktioniert  

Entra ID verwendet offene Standards wie **OAuth 2.0** zur Handhabung der Authentifizierung. Obwohl die Details komplex sein können, ist das Grundprinzip einfach und lässt sich gut mit einer Analogie erklären.

### Eine einfache Einführung in OAuth 2.0: Der Parkschlüssel  

Stellen Sie sich OAuth 2.0 wie einen Parkservice für Ihr Auto vor. Wenn Sie in einem Restaurant ankommen, geben Sie dem Parkservice nicht Ihren Hauptschlüssel. Stattdessen übergeben Sie einen **Parkschlüssel**, der nur eingeschränkte Berechtigungen hat – er kann das Auto starten und die Türen verriegeln, aber nicht den Kofferraum oder das Handschuhfach öffnen.

In dieser Analogie:

- **Sie** sind der **Benutzer**.  
- **Ihr Auto** ist der **MCP-Server** mit seinen wertvollen Werkzeugen und Daten.  
- Der **Parkservice** ist **Microsoft Entra ID**.  
- Der **Parkplatzwärter** ist der **MCP-Client** (die Anwendung, die auf den Server zugreifen möchte).  
- Der **Parkschlüssel** ist das **Access Token**.  

Das Access Token ist ein sicherer Textstring, den der MCP-Client von Entra ID erhält, nachdem Sie sich angemeldet haben. Der Client übermittelt dieses Token bei jeder Anfrage an den MCP-Server. Der Server kann das Token überprüfen, um sicherzustellen, dass die Anfrage legitim ist und der Client die notwendigen Berechtigungen besitzt – ohne jemals Ihre tatsächlichen Anmeldedaten (wie Ihr Passwort) verarbeiten zu müssen.

### Der Authentifizierungsablauf  

So funktioniert der Prozess in der Praxis:

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

### Vorstellung der Microsoft Authentication Library (MSAL)  

Bevor wir uns den Code ansehen, ist es wichtig, eine zentrale Komponente vorzustellen, die in den Beispielen verwendet wird: die **Microsoft Authentication Library (MSAL)**.

MSAL ist eine von Microsoft entwickelte Bibliothek, die Entwicklern die Handhabung der Authentifizierung erheblich erleichtert. Anstatt selbst komplexen Code für Sicherheitstoken, Anmeldungen und Sitzungserneuerungen zu schreiben, übernimmt MSAL diese Aufgaben für Sie.

Der Einsatz einer Bibliothek wie MSAL wird dringend empfohlen, weil:

- **Sie sicher ist:** MSAL implementiert branchenübliche Protokolle und Sicherheitsbest Practices, was das Risiko von Sicherheitslücken im Code reduziert.  
- **Sie die Entwicklung vereinfacht:** Sie abstrahiert die Komplexität von OAuth 2.0 und OpenID Connect, sodass Sie robuste Authentifizierung mit wenigen Codezeilen hinzufügen können.  
- **Sie gepflegt wird:** Microsoft aktualisiert MSAL aktiv, um auf neue Sicherheitsbedrohungen und Plattformänderungen zu reagieren.  

MSAL unterstützt viele Programmiersprachen und Frameworks, darunter .NET, JavaScript/TypeScript, Python, Java, Go sowie mobile Plattformen wie iOS und Android. So können Sie ein einheitliches Authentifizierungsmuster über Ihren gesamten Technologie-Stack hinweg nutzen.

Weitere Informationen zu MSAL finden Sie in der offiziellen [MSAL-Übersichtsdokumentation](https://learn.microsoft.com/entra/identity-platform/msal-overview).

---

## Absicherung Ihres MCP-Servers mit Entra ID: Schritt-für-Schritt-Anleitung  

Nun schauen wir uns an, wie Sie einen lokalen MCP-Server absichern (einen, der über `stdio`) using Entra ID. This example uses a **public client**, which is suitable for applications running on a user's machine, like a desktop app or a local development server.

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
- **`AcquireTokenAsync`** kommuniziert: Dies ist die Kernmethode. Sie versucht zunächst, ein Token stillschweigend zu erhalten (das heißt, der Benutzer muss sich nicht erneut anmelden, wenn bereits eine gültige Sitzung besteht). Falls kein stillschweigendes Token verfügbar ist, wird der Benutzer interaktiv zur Anmeldung aufgefordert.

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
- **`GetUserDetailsFromGraph` tool**: This tool requires an instance of `AuthenticationService`. Before it does anything, it calls `authService.AcquireTokenAsync()`** wird verwendet, um ein gültiges Zugriffstoken zu erhalten. Wenn die Authentifizierung erfolgreich ist, nutzt es das Token, um die Microsoft Graph API aufzurufen und die Benutzerdetails abzurufen.

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

#### 3. Wie alles zusammenarbeitet  

1. Wenn der MCP-Client versucht, die `GetUserDetailsFromGraph` tool, the tool first calls `AcquireTokenAsync`.
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
- **`/auth/callback`**-Schnittstelle zu nutzen: Dieser Endpunkt verarbeitet die Weiterleitung von Entra ID, nachdem der Benutzer sich authentifiziert hat. Er tauscht den Autorisierungscode gegen ein Zugriffstoken und ein Refresh Token aus.

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

This file defines the tools that the MCP server provides. The `getUserDetails`**-Tool ist ähnlich wie im vorherigen Beispiel, holt aber das Zugriffstoken aus der Sitzung.

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
6. When the `getUserDetails`**-Tool wird aufgerufen, verwendet das Sitzungstoken, um das Entra ID-Zugriffstoken nachzuschlagen und ruft damit dann die Microsoft Graph API auf.

Dieser Ablauf ist komplexer als der für öffentliche Clients, ist aber für internetzugängliche Endpunkte notwendig. Da entfernte MCP-Server über das öffentliche Internet erreichbar sind, benötigen sie stärkere Sicherheitsmaßnahmen, um unbefugten Zugriff und mögliche Angriffe zu verhindern.

## Sicherheitsbest Practices  

- **Immer HTTPS verwenden:** Verschlüsseln Sie die Kommunikation zwischen Client und Server, um Tokens vor Abfangen zu schützen.  
- **Rollengesteuerte Zugriffskontrolle (RBAC) implementieren:** Prüfen Sie nicht nur, *ob* ein Benutzer authentifiziert ist, sondern auch, *was* er darf. Rollen können in Entra ID definiert und im MCP-Server überprüft werden.  
- **Überwachen und protokollieren:** Loggen Sie alle Authentifizierungsereignisse, um verdächtige Aktivitäten zu erkennen und darauf reagieren zu können.  
- **Rate Limiting und Drosselung handhaben:** Microsoft Graph und andere APIs setzen Rate Limits, um Missbrauch zu verhindern. Implementieren Sie in Ihrem MCP-Server exponentielles Backoff und Wiederholungslogik, um HTTP 429 (Too Many Requests) elegant zu verarbeiten. Cachen Sie häufig abgefragte Daten, um API-Aufrufe zu reduzieren.  
- **Sichere Token-Speicherung:** Speichern Sie Access- und Refresh-Tokens sicher. Für lokale Anwendungen nutzen Sie die sicheren Speichermechanismen des Systems. Für Serveranwendungen empfiehlt sich verschlüsselter Speicher oder sichere Schlüsselverwaltungsdienste wie Azure Key Vault.  
- **Umgang mit Token-Ablauf:** Access Tokens haben eine begrenzte Lebensdauer. Implementieren Sie eine automatische Token-Erneuerung mittels Refresh Tokens, um eine nahtlose Benutzererfahrung ohne erneute Anmeldung zu gewährleisten.  
- **Einsatz von Azure API Management erwägen:** Während die direkte Sicherheit im MCP-Server eine feinkörnige Kontrolle ermöglicht, können API-Gateways wie Azure API Management viele Sicherheitsaspekte automatisch übernehmen, darunter Authentifizierung, Autorisierung, Rate Limiting und Monitoring. Sie bieten eine zentrale Sicherheitsschicht zwischen Ihren Clients und MCP-Servern. Weitere Informationen zur Nutzung von API-Gateways mit MCP finden Sie in unserem [Azure API Management Your Auth Gateway For MCP Servers](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690).

## Wichtige Erkenntnisse  

- Die Absicherung Ihres MCP-Servers ist entscheidend zum Schutz Ihrer Daten und Werkzeuge.  
- Microsoft Entra ID bietet eine robuste und skalierbare Lösung für Authentifizierung und Autorisierung.  
- Verwenden Sie einen **öffentlichen Client** für lokale Anwendungen und einen **vertraulichen Client** für entfernte Server.  
- Der **Authorization Code Flow** ist die sicherste Option für Webanwendungen.  

## Übung  

1. Überlegen Sie, welchen MCP-Server Sie erstellen würden. Wäre es ein lokaler oder ein entfernter Server?  
2. Basierend auf Ihrer Antwort: Würden Sie einen öffentlichen oder vertraulichen Client verwenden?  
3. Welche Berechtigung würde Ihr MCP-Server anfordern, um Aktionen gegen Microsoft Graph auszuführen?  

## Praktische Übungen  

### Übung 1: Registrierung einer Anwendung in Entra ID  
Navigieren Sie zum Microsoft Entra-Portal.  
Registrieren Sie eine neue Anwendung für Ihren MCP-Server.  
Notieren Sie die Application (Client) ID und Directory (Tenant) ID.

### Übung 2: Absicherung eines lokalen MCP-Servers (öffentlicher Client)  
- Folgen Sie dem Codebeispiel zur Integration von MSAL (Microsoft Authentication Library) für die Benutzeranmeldung.  
- Testen Sie den Authentifizierungsablauf, indem Sie das MCP-Tool aufrufen, das Benutzerdetails von Microsoft Graph abruft.

### Übung 3: Absicherung eines entfernten MCP-Servers (vertraulicher Client)  
- Registrieren Sie einen vertraulichen Client in Entra ID und erstellen Sie ein Client-Geheimnis.  
- Konfigurieren Sie Ihren Express.js MCP-Server so, dass er den Authorization Code Flow verwendet.  
- Testen Sie die geschützten Endpunkte und bestätigen Sie den tokenbasierten Zugriff.

### Übung 4: Anwenden von Sicherheitsbest Practices  
- Aktivieren Sie HTTPS für Ihren lokalen oder entfernten Server.  
- Implementieren Sie rollengesteuerte Zugriffskontrolle (RBAC) in Ihrer Serverlogik.  
- Fügen Sie Token-Ablaufbehandlung und sichere Token-Speicherung hinzu.

## Ressourcen  

1. **MSAL Übersichtsdokumentation**  
   Erfahren Sie, wie die Microsoft Authentication Library (MSAL) die sichere Token-Akquise plattformübergreifend ermöglicht:  
   [MSAL Overview on Microsoft Learn](https://learn.microsoft.com/en-gb/entra/msal/overview)

2. **Azure-Samples/mcp-auth-servers GitHub Repository**  
   Referenzimplementierungen von MCP-Servern, die Authentifizierungsabläufe demonstrieren:  
   [Azure-Samples/mcp-auth-servers on GitHub](https://github.com/Azure-Samples/mcp-auth-servers)

3. **Managed Identities für Azure-Ressourcen Übersicht**  
   Erfahren Sie, wie Sie Geheimnisse durch system- oder benutzerzugewiesene Managed Identities eliminieren:  
   [Managed Identities Overview on Microsoft Learn](https://learn.microsoft.com/en-us/entra/identity/managed-identities-azure-resources/)

4. **Azure API Management: Ihr Auth-Gateway für MCP-Server**  
   Eine detaillierte Betrachtung der Nutzung von APIM als sicheres OAuth2-Gateway für MCP-Server:  
   [Azure API Management Your Auth Gateway For MCP Servers](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

5. **Microsoft Graph Berechtigungsreferenz**  
   Umfassende Liste der delegierten und Anwendungsberechtigungen für Microsoft Graph:  
   [Microsoft Graph Permissions Reference](https://learn.microsoft.com/zh-tw/graph/permissions-reference)

## Lernergebnisse  
Nach Abschluss dieses Abschnitts können Sie:

- Erläutern, warum Authentifizierung für MCP-Server und KI-Workflows entscheidend ist.  
- Entra ID-Authentifizierung für lokale und entfernte MCP-Server-Szenarien einrichten und konfigurieren.  
- Den passenden Client-Typ (öffentlich oder vertraulich) basierend auf der Serverbereitstellung auswählen.  
- Sichere Programmierpraktiken umsetzen, einschließlich Token-Speicherung und rollenbasierter Autorisierung.  
- Ihren MCP-Server und dessen Werkzeuge sicher vor unbefugtem Zugriff schützen.

## Was kommt als Nächstes  

- [5.13 Model Context Protocol (MCP) Integration mit Azure AI Foundry](../mcp-foundry-agent-integration/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir auf Genauigkeit achten, bitten wir zu beachten, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die durch die Verwendung dieser Übersetzung entstehen.