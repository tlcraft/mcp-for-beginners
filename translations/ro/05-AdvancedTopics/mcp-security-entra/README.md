<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6e562d7e5a77c8982da4aa8f762ad1d8",
  "translation_date": "2025-07-02T09:55:14+00:00",
  "source_file": "05-AdvancedTopics/mcp-security-entra/README.md",
  "language_code": "ro"
}
-->
# Securizarea fluxurilor de lucru AI: Autentificarea Entra ID pentru serverele Model Context Protocol

## Introducere
Securizarea serverului tău Model Context Protocol (MCP) este la fel de importantă ca încuietorarea ușii de la intrare a casei tale. Lăsarea serverului MCP deschis expune uneltele și datele tale accesului neautorizat, ceea ce poate duce la breșe de securitate. Microsoft Entra ID oferă o soluție robustă de gestionare a identității și accesului în cloud, ajutând la asigurarea faptului că doar utilizatorii și aplicațiile autorizate pot interacționa cu serverul tău MCP. În această secțiune, vei învăța cum să protejezi fluxurile tale de lucru AI folosind autentificarea Entra ID.

## Obiective de învățare
La finalul acestei secțiuni, vei putea:

- Să înțelegi importanța securizării serverelor MCP.
- Să explici elementele de bază ale Microsoft Entra ID și autentificarea OAuth 2.0.
- Să recunoști diferența dintre clienți publici și clienți confidențiali.
- Să implementezi autentificarea Entra ID atât în scenarii locale (client public), cât și la distanță (client confidențial) pentru serverele MCP.
- Să aplici cele mai bune practici de securitate în dezvoltarea fluxurilor de lucru AI.

## Securitate și MCP

Așa cum nu ai lăsa ușa de la intrare a casei descuiată, nici serverul tău MCP nu ar trebui să fie accesibil oricui. Securizarea fluxurilor tale de lucru AI este esențială pentru construirea unor aplicații robuste, de încredere și sigure. Acest capitol îți va prezenta utilizarea Microsoft Entra ID pentru a proteja serverele MCP, asigurând că doar utilizatorii și aplicațiile autorizate pot interacționa cu uneltele și datele tale.

## De ce contează securitatea pentru serverele MCP

Imaginează-ți că serverul tău MCP are o unealtă care poate trimite emailuri sau accesa o bază de date a clienților. Un server nesecurizat ar însemna că oricine ar putea folosi acea unealtă, ceea ce ar duce la acces neautorizat la date, spam sau alte activități malițioase.

Prin implementarea autentificării, te asiguri că fiecare cerere către server este verificată, confirmând identitatea utilizatorului sau aplicației care face cererea. Acesta este primul și cel mai important pas în securizarea fluxurilor tale de lucru AI.

## Introducere în Microsoft Entra ID

[**Microsoft Entra ID**](https://adoption.microsoft.com/microsoft-security/entra/) este un serviciu cloud de gestionare a identității și accesului. Gândește-l ca pe un agent de securitate universal pentru aplicațiile tale. El gestionează procesul complex de verificare a identității utilizatorilor (autentificare) și determină ce au voie să facă (autorizare).

Folosind Entra ID, poți:

- Permite autentificare sigură pentru utilizatori.
- Proteja API-urile și serviciile.
- Gestiona politicile de acces dintr-un singur loc.

Pentru serverele MCP, Entra ID oferă o soluție robustă și larg recunoscută pentru a gestiona cine poate accesa funcționalitățile serverului tău.

---

## Înțelegerea mecanismului: Cum funcționează autentificarea Entra ID

Entra ID folosește standarde deschise precum **OAuth 2.0** pentru gestionarea autentificării. Deși detaliile pot fi complexe, conceptul de bază este simplu și poate fi înțeles printr-o analogie.

### O introducere simplă în OAuth 2.0: Cheia valetului

Gândește-te la OAuth 2.0 ca la un serviciu de valet pentru mașina ta. Când ajungi la un restaurant, nu dai valetului cheia ta principală. În schimb, îi oferi o **cheie de valet** care are permisiuni limitate – poate porni mașina și încuia ușile, dar nu poate deschide portbagajul sau torpedoul.

În această analogie:

- **Tu** ești **Utilizatorul**.
- **Mașina ta** este **Serverul MCP** cu uneltele și datele sale valoroase.
- **Valetul** este **Microsoft Entra ID**.
- **Atendentul de parcare** este **Clientul MCP** (aplicația care încearcă să acceseze serverul).
- **Cheia de valet** este **Tokenul de acces**.

Tokenul de acces este un șir securizat de text pe care clientul MCP îl primește de la Entra ID după ce te autentifici. Clientul apoi prezintă acest token serverului MCP la fiecare cerere. Serverul poate verifica tokenul pentru a se asigura că cererea este legitimă și că clientul are permisiunile necesare, toate acestea fără a manipula efectiv datele tale de autentificare (cum ar fi parola).

### Fluxul de autentificare

Iată cum funcționează procesul în practică:

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

### Prezentarea Microsoft Authentication Library (MSAL)

Înainte să intrăm în cod, este important să prezentăm un element cheie pe care îl vei vedea în exemple: **Microsoft Authentication Library (MSAL)**.

MSAL este o bibliotecă dezvoltată de Microsoft care face mult mai ușoară gestionarea autentificării pentru dezvoltatori. În loc să scrii tot codul complex pentru gestionarea token-urilor de securitate, a autentificărilor și reîmprospătărilor sesiunilor, MSAL se ocupă de toate acestea.

Utilizarea unei biblioteci precum MSAL este recomandată pentru că:

- **Este sigură:** implementează protocoale standard din industrie și cele mai bune practici de securitate, reducând riscul vulnerabilităților în codul tău.
- **Simplifică dezvoltarea:** ascunde complexitatea protocoalelor OAuth 2.0 și OpenID Connect, permițându-ți să adaugi autentificare robustă aplicației tale cu doar câteva linii de cod.
- **Este întreținută:** Microsoft actualizează activ MSAL pentru a răspunde noilor amenințări de securitate și schimbărilor de platformă.

MSAL suportă o gamă largă de limbaje și cadre de aplicații, inclusiv .NET, JavaScript/TypeScript, Python, Java, Go și platforme mobile precum iOS și Android. Aceasta înseamnă că poți folosi aceleași modele consistente de autentificare pe întregul tău stack tehnologic.

Pentru a afla mai multe despre MSAL, poți consulta documentația oficială [MSAL overview documentation](https://learn.microsoft.com/entra/identity-platform/msal-overview).

---

## Securizarea serverului MCP cu Entra ID: Ghid pas cu pas

Acum, să parcurgem cum să securizezi un server MCP local (care comunică prin `stdio``) using Entra ID. This example uses a **public client**, which is suitable for applications running on a user's machine, like a desktop app or a local development server.

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
- **`AcquireTokenAsync`**: Aceasta este metoda principală. Mai întâi încearcă să obțină un token în mod silențios (adică utilizatorul nu va trebui să se autentifice din nou dacă are deja o sesiune validă). Dacă nu poate obține un token silențios, va solicita utilizatorului să se autentifice interactiv.

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
- **`GetUserDetailsFromGraph` tool**: This tool requires an instance of `AuthenticationService`. Before it does anything, it calls `authService.AcquireTokenAsync()` pentru a obține un token de acces valid. Dacă autentificarea are succes, folosește tokenul pentru a apela Microsoft Graph API și a prelua detaliile utilizatorului.

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

#### 3. Cum funcționează totul împreună

1. Când clientul MCP încearcă să folosească `GetUserDetailsFromGraph` tool, the tool first calls `AcquireTokenAsync`.
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
- **`/auth/callback`**: Acest endpoint gestionează redirecționarea de la Entra ID după ce utilizatorul s-a autentificat. Schimbă codul de autorizare pentru un token de acces și un token de reîmprospătare.

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

This file defines the tools that the MCP server provides. The `getUserDetails` unealta este similară cu cea din exemplul anterior, dar obține tokenul de acces din sesiune.

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
6. When the `getUserDetails` când este apelată, folosește tokenul din sesiune pentru a căuta tokenul de acces Entra ID și apoi îl folosește pentru a apela Microsoft Graph API.

Acest flux este mai complex decât cel pentru clientul public, dar este necesar pentru endpoint-urile expuse pe internet. Deoarece serverele MCP la distanță sunt accesibile prin internetul public, ele necesită măsuri de securitate mai stricte pentru a se proteja împotriva accesului neautorizat și a potențialelor atacuri.

## Cele mai bune practici de securitate

- **Folosește întotdeauna HTTPS**: Criptează comunicația între client și server pentru a proteja tokenurile de interceptare.
- **Implementează controlul accesului bazat pe roluri (RBAC)**: Nu verifica doar *dacă* un utilizator este autentificat; verifică *ce* este autorizat să facă. Poți defini roluri în Entra ID și să le verifici în serverul tău MCP.
- **Monitorizează și auditează**: Înregistrează toate evenimentele de autentificare pentru a detecta și răspunde la activități suspecte.
- **Gestionează limitarea ratei și throttling-ul**: Microsoft Graph și alte API-uri implementează limitarea ratei pentru a preveni abuzurile. Implementează logica de backoff exponențial și retry în serverul tău MCP pentru a gestiona elegant răspunsurile HTTP 429 (Too Many Requests). Ia în considerare cache-ul pentru datele accesate frecvent pentru a reduce apelurile API.
- **Stocarea securizată a tokenurilor**: Depozitează tokenurile de acces și cele de reîmprospătare în mod sigur. Pentru aplicații locale, folosește mecanismele de stocare securizată ale sistemului. Pentru aplicațiile server, ia în considerare utilizarea stocării criptate sau a serviciilor de gestionare a cheilor securizate precum Azure Key Vault.
- **Gestionarea expirării tokenurilor**: Tokenurile de acces au o durată limitată. Implementează reîmprospătarea automată a tokenurilor folosind tokenurile de reîmprospătare pentru a menține o experiență de utilizator fără întreruperi, fără a necesita reautentificare.
- **Ia în considerare utilizarea Azure API Management**: Deși implementarea securității direct în serverul MCP îți oferă control detaliat, API Gateways precum Azure API Management pot gestiona automat multe dintre aceste aspecte de securitate, inclusiv autentificarea, autorizarea, limitarea ratei și monitorizarea. Ele oferă un strat centralizat de securitate între clienții tăi și serverele MCP. Pentru mai multe detalii despre utilizarea API Gateways cu MCP, vezi [Azure API Management Your Auth Gateway For MCP Servers](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690).

## Concluzii cheie

- Securizarea serverului MCP este esențială pentru protejarea datelor și uneltelor tale.
- Microsoft Entra ID oferă o soluție robustă și scalabilă pentru autentificare și autorizare.
- Folosește un **client public** pentru aplicații locale și un **client confidențial** pentru servere la distanță.
- **Authorization Code Flow** este cea mai sigură opțiune pentru aplicațiile web.

## Exercițiu

1. Gândește-te la un server MCP pe care ai putea să-l construiești. Ar fi un server local sau unul la distanță?
2. În funcție de răspunsul tău, ai folosi un client public sau unul confidențial?
3. Ce permisiuni ar solicita serverul tău MCP pentru a efectua acțiuni împotriva Microsoft Graph?

## Exerciții practice

### Exercițiul 1: Înregistrează o aplicație în Entra ID
Accesează portalul Microsoft Entra.  
Înregistrează o aplicație nouă pentru serverul tău MCP.  
Notează Application (client) ID și Directory (tenant) ID.

### Exercițiul 2: Securizează un server MCP local (client public)
- Urmează exemplul de cod pentru a integra MSAL (Microsoft Authentication Library) pentru autentificarea utilizatorului.
- Testează fluxul de autentificare apelând unealta MCP care preia detalii despre utilizator din Microsoft Graph.

### Exercițiul 3: Securizează un server MCP la distanță (client confidențial)
- Înregistrează un client confidențial în Entra ID și creează un secret de client.
- Configurează serverul tău MCP Express.js să folosească Authorization Code Flow.
- Testează endpoint-urile protejate și confirmă accesul bazat pe token.

### Exercițiul 4: Aplică cele mai bune practici de securitate
- Activează HTTPS pentru serverul tău local sau la distanță.
- Implementează controlul accesului bazat pe roluri (RBAC) în logica serverului.
- Adaugă gestionarea expirării tokenurilor și stocarea securizată a tokenurilor.

## Resurse

1. **Documentația MSAL Overview**  
   Află cum Microsoft Authentication Library (MSAL) permite achiziția securizată de tokenuri pe diverse platforme:  
   [MSAL Overview on Microsoft Learn](https://learn.microsoft.com/en-gb/entra/msal/overview)

2. **Repository GitHub Azure-Samples/mcp-auth-servers**  
   Implementări de referință pentru servere MCP care demonstrează fluxurile de autentificare:  
   [Azure-Samples/mcp-auth-servers on GitHub](https://github.com/Azure-Samples/mcp-auth-servers)

3. **Prezentare Managed Identities pentru resurse Azure**  
   Înțelege cum să elimini secretele folosind identități gestionate de sistem sau utilizator:  
   [Managed Identities Overview on Microsoft Learn](https://learn.microsoft.com/en-us/entra/identity/managed-identities-azure-resources/)

4. **Azure API Management: Poarta ta de autentificare pentru serverele MCP**  
   O analiză detaliată despre utilizarea APIM ca poartă OAuth2 securizată pentru serverele MCP:  
   [Azure API Management Your Auth Gateway For MCP Servers](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

5. **Referință permisiuni Microsoft Graph**  
   Listă completă de permisiuni delegate și de aplicație pentru Microsoft Graph:  
   [Microsoft Graph Permissions Reference](https://learn.microsoft.com/zh-tw/graph/permissions-reference)

## Rezultate de învățare
După parcurgerea acestei secțiuni, vei putea:

- Explica de ce autentificarea este critică pentru serverele MCP și fluxurile AI.
- Configura și seta autentificarea Entra ID pentru scenarii locale și la distanță ale serverelor MCP.
- Alege tipul potrivit de client (public sau confidențial) în funcție de implementarea serverului tău.
- Implementa practici de codare securizată, inclusiv stocarea tokenurilor și autorizarea bazată pe roluri.
- Proteja cu încredere serverul MCP și uneltele sale împotriva accesului neautorizat.

## Ce urmează

- [5.13 Integrarea Model Context Protocol (MCP) cu Azure AI Foundry](../mcp-foundry-agent-integration/README.md)

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original, în limba sa nativă, trebuie considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.