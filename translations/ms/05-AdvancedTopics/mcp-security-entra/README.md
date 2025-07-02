<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6e562d7e5a77c8982da4aa8f762ad1d8",
  "translation_date": "2025-07-02T09:44:49+00:00",
  "source_file": "05-AdvancedTopics/mcp-security-entra/README.md",
  "language_code": "ms"
}
-->
# Memastikan Keselamatan Aliran Kerja AI: Pengesahan Entra ID untuk Pelayan Model Context Protocol

## Pengenalan  
Memastikan keselamatan pelayan Model Context Protocol (MCP) anda adalah sama penting seperti mengunci pintu depan rumah anda. Membiarkan pelayan MCP anda terbuka boleh mendedahkan alat dan data anda kepada akses tanpa kebenaran, yang boleh menyebabkan pelanggaran keselamatan. Microsoft Entra ID menyediakan penyelesaian pengurusan identiti dan akses berasaskan awan yang kukuh, membantu memastikan hanya pengguna dan aplikasi yang diberi kuasa dapat berinteraksi dengan pelayan MCP anda. Dalam bahagian ini, anda akan belajar cara melindungi aliran kerja AI anda menggunakan pengesahan Entra ID.

## Objektif Pembelajaran  
Pada akhir bahagian ini, anda akan dapat:

- Memahami kepentingan memastikan keselamatan pelayan MCP.  
- Menerangkan asas Microsoft Entra ID dan pengesahan OAuth 2.0.  
- Mengenal pasti perbezaan antara klien awam dan rahsia.  
- Melaksanakan pengesahan Entra ID dalam senario pelayan MCP tempatan (klien awam) dan jauh (klien rahsia).  
- Mengaplikasikan amalan keselamatan terbaik semasa membangunkan aliran kerja AI.

## Keselamatan dan MCP  
Seperti mana anda tidak akan membiarkan pintu depan rumah anda terbuka, anda juga tidak harus membiarkan pelayan MCP anda boleh diakses oleh sesiapa sahaja. Memastikan keselamatan aliran kerja AI anda adalah penting untuk membina aplikasi yang kukuh, boleh dipercayai, dan selamat. Bab ini akan memperkenalkan anda kepada penggunaan Microsoft Entra ID untuk mengamankan pelayan MCP anda, memastikan hanya pengguna dan aplikasi yang diberi kuasa dapat berinteraksi dengan alat dan data anda.

## Mengapa Keselamatan Penting untuk Pelayan MCP  
Bayangkan pelayan MCP anda mempunyai alat yang boleh menghantar emel atau mengakses pangkalan data pelanggan. Pelayan yang tidak selamat bermakna sesiapa sahaja berpotensi menggunakan alat tersebut, menyebabkan akses data tanpa kebenaran, spam, atau aktiviti berniat jahat lain.

Dengan melaksanakan pengesahan, anda memastikan setiap permintaan ke pelayan anda disahkan, mengesahkan identiti pengguna atau aplikasi yang membuat permintaan tersebut. Ini adalah langkah pertama dan paling penting dalam memastikan keselamatan aliran kerja AI anda.

## Pengenalan kepada Microsoft Entra ID  
[**Microsoft Entra ID**](https://adoption.microsoft.com/microsoft-security/entra/) adalah perkhidmatan pengurusan identiti dan akses berasaskan awan. Anggap ia sebagai pengawal keselamatan sejagat untuk aplikasi anda. Ia mengendalikan proses kompleks pengesahan identiti pengguna (authentication) dan menentukan apa yang mereka dibenarkan lakukan (authorization).

Dengan menggunakan Entra ID, anda boleh:

- Mengaktifkan log masuk selamat untuk pengguna.  
- Melindungi API dan perkhidmatan.  
- Mengurus dasar akses dari satu lokasi pusat.

Untuk pelayan MCP, Entra ID menyediakan penyelesaian yang kukuh dan dipercayai secara meluas untuk mengurus siapa yang boleh mengakses keupayaan pelayan anda.

---

## Memahami Mekanisme: Bagaimana Pengesahan Entra ID Berfungsi  
Entra ID menggunakan piawaian terbuka seperti **OAuth 2.0** untuk mengendalikan pengesahan. Walaupun butiran boleh menjadi kompleks, konsep asasnya mudah dan boleh difahami melalui analogi.

### Pengenalan Ringkas kepada OAuth 2.0: Kunci Valet  
Fikirkan OAuth 2.0 seperti perkhidmatan valet untuk kereta anda. Apabila anda tiba di restoran, anda tidak memberikan kunci utama anda kepada valet. Sebaliknya, anda memberikan **kunci valet** yang mempunyai kebenaran terhad—ia boleh menghidupkan kereta dan mengunci pintu, tetapi tidak boleh membuka but atau petak sarung tangan.

Dalam analogi ini:

- **Anda** adalah **Pengguna**.  
- **Kereta anda** adalah **Pelayan MCP** dengan alat dan data berharga.  
- **Valet** adalah **Microsoft Entra ID**.  
- **Pengawal Letak Kereta** adalah **Klien MCP** (aplikasi yang cuba mengakses pelayan).  
- **Kunci Valet** adalah **Token Akses**.

Token akses adalah rentetan teks yang selamat yang diterima oleh klien MCP dari Entra ID selepas anda log masuk. Klien kemudian membentangkan token ini kepada pelayan MCP setiap kali membuat permintaan. Pelayan boleh mengesahkan token tersebut untuk memastikan permintaan itu sah dan klien mempunyai kebenaran yang diperlukan, semua ini tanpa perlu mengendalikan kelayakan sebenar anda (seperti kata laluan).

### Aliran Pengesahan  
Berikut adalah cara proses ini berfungsi dalam praktik:

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

### Memperkenalkan Microsoft Authentication Library (MSAL)  
Sebelum kita menyelami kod, penting untuk memperkenalkan komponen utama yang akan anda lihat dalam contoh: **Microsoft Authentication Library (MSAL)**.

MSAL adalah perpustakaan yang dibangunkan oleh Microsoft yang memudahkan pembangun mengendalikan pengesahan. Daripada anda perlu menulis semua kod kompleks untuk mengurus token keselamatan, log masuk, dan penyegaran sesi, MSAL menguruskan tugas berat ini.

Menggunakan perpustakaan seperti MSAL sangat disyorkan kerana:

- **Ia Selamat:** Ia melaksanakan protokol piawaian industri dan amalan keselamatan terbaik, mengurangkan risiko kelemahan dalam kod anda.  
- **Memudahkan Pembangunan:** Ia menyederhanakan kerumitan protokol OAuth 2.0 dan OpenID Connect, membolehkan anda menambah pengesahan kukuh ke aplikasi dengan hanya beberapa baris kod.  
- **Sentiasa Dikemaskini:** Microsoft secara aktif mengekalkan dan mengemas kini MSAL untuk menangani ancaman keselamatan baru dan perubahan platform.

MSAL menyokong pelbagai bahasa dan rangka kerja aplikasi, termasuk .NET, JavaScript/TypeScript, Python, Java, Go, dan platform mudah alih seperti iOS dan Android. Ini bermakna anda boleh menggunakan corak pengesahan yang konsisten di seluruh tumpukan teknologi anda.

Untuk maklumat lanjut tentang MSAL, anda boleh rujuk dokumentasi rasmi [gambaran keseluruhan MSAL](https://learn.microsoft.com/entra/identity-platform/msal-overview).

---

## Memastikan Keselamatan Pelayan MCP Anda dengan Entra ID: Panduan Langkah demi Langkah  
Sekarang, mari kita lihat bagaimana untuk mengamankan pelayan MCP tempatan (yang berkomunikasi melalui `stdio`) using Entra ID. This example uses a **public client**, which is suitable for applications running on a user's machine, like a desktop app or a local development server.

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
- **`AcquireTokenAsync`**: Ini adalah kaedah utama. Ia pertama kali cuba mendapatkan token secara senyap (bermaksud pengguna tidak perlu log masuk semula jika sudah ada sesi yang sah). Jika token senyap tidak dapat diperoleh, ia akan meminta pengguna log masuk secara interaktif.

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
- **`GetUserDetailsFromGraph` tool**: This tool requires an instance of `AuthenticationService`. Before it does anything, it calls `authService.AcquireTokenAsync()` untuk mendapatkan token akses yang sah. Jika pengesahan berjaya, token digunakan untuk memanggil Microsoft Graph API dan mengambil butiran pengguna.

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

#### 3. Bagaimana Keseluruhan Proses Berfungsi  
1. Apabila klien MCP cuba menggunakan `GetUserDetailsFromGraph` tool, the tool first calls `AcquireTokenAsync`.
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
- **`/auth/callback`**: Titik akhir ini mengendalikan pengalihan dari Entra ID selepas pengguna mengesahkan identiti. Ia menukar kod kebenaran kepada token akses dan token penyegaran.

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

This file defines the tools that the MCP server provides. The `getUserDetails` alat ini serupa dengan contoh sebelum ini, tetapi ia mendapatkan token akses dari sesi.

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
6. When the `getUserDetails` alat ini dipanggil, ia menggunakan token sesi untuk mencari token akses Entra ID dan kemudian menggunakan token tersebut untuk memanggil Microsoft Graph API.

Aliran ini lebih kompleks berbanding aliran klien awam, tetapi diperlukan untuk titik akhir yang boleh diakses melalui internet. Oleh kerana pelayan MCP jauh boleh diakses melalui internet awam, mereka memerlukan langkah keselamatan yang lebih kukuh untuk melindungi daripada akses tanpa kebenaran dan serangan berpotensi.

## Amalan Terbaik Keselamatan  

- **Sentiasa gunakan HTTPS**: Sulitkan komunikasi antara klien dan pelayan untuk melindungi token daripada dipintas.  
- **Laksanakan Kawalan Akses Berdasarkan Peranan (RBAC)**: Jangan hanya semak *jika* pengguna disahkan; semak *apa* yang mereka dibenarkan lakukan. Anda boleh mentakrifkan peranan dalam Entra ID dan memeriksanya dalam pelayan MCP anda.  
- **Pantau dan audit**: Logkan semua acara pengesahan supaya anda boleh mengesan dan bertindak balas terhadap aktiviti mencurigakan.  
- **Urus had kadar dan pengehadan**: Microsoft Graph dan API lain melaksanakan had kadar untuk mengelakkan penyalahgunaan. Laksanakan logik penangguhan eksponen dan cubaan semula dalam pelayan MCP anda untuk mengendalikan respons HTTP 429 (Terlalu Banyak Permintaan) dengan baik. Pertimbangkan untuk menyimpan data yang sering diakses untuk mengurangkan panggilan API.  
- **Simpan token dengan selamat**: Simpan token akses dan token penyegaran dengan selamat. Untuk aplikasi tempatan, gunakan mekanisme penyimpanan selamat sistem. Untuk aplikasi pelayan, pertimbangkan menggunakan penyimpanan terenkripsi atau perkhidmatan pengurusan kunci selamat seperti Azure Key Vault.  
- **Urus tamat tempoh token**: Token akses mempunyai jangka hayat terhad. Laksanakan penyegaran token automatik menggunakan token penyegaran untuk memastikan pengalaman pengguna yang lancar tanpa perlu pengesahan semula.  
- **Pertimbangkan menggunakan Azure API Management**: Walaupun melaksanakan keselamatan terus dalam pelayan MCP memberi anda kawalan terperinci, Pintu Gerbang API seperti Azure API Management boleh mengendalikan banyak isu keselamatan ini secara automatik, termasuk pengesahan, kebenaran, had kadar, dan pemantauan. Ia menyediakan lapisan keselamatan berpusat yang terletak di antara klien anda dan pelayan MCP. Untuk maklumat lanjut mengenai penggunaan Pintu Gerbang API dengan MCP, lihat [Azure API Management Your Auth Gateway For MCP Servers](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690).

## Perkara Penting yang Perlu Diingat  

- Memastikan keselamatan pelayan MCP anda adalah penting untuk melindungi data dan alat anda.  
- Microsoft Entra ID menyediakan penyelesaian kukuh dan boleh skala untuk pengesahan dan kebenaran.  
- Gunakan **klien awam** untuk aplikasi tempatan dan **klien rahsia** untuk pelayan jauh.  
- **Aliran Kod Kebenaran (Authorization Code Flow)** adalah pilihan paling selamat untuk aplikasi web.

## Latihan  

1. Fikirkan tentang pelayan MCP yang mungkin anda bina. Adakah ia pelayan tempatan atau pelayan jauh?  
2. Berdasarkan jawapan anda, adakah anda akan menggunakan klien awam atau rahsia?  
3. Apakah kebenaran yang akan diminta oleh pelayan MCP anda untuk melakukan tindakan terhadap Microsoft Graph?

## Latihan Praktikal  

### Latihan 1: Daftar Aplikasi dalam Entra ID  
Navigasi ke portal Microsoft Entra.  
Daftarkan aplikasi baru untuk pelayan MCP anda.  
Catatkan ID Aplikasi (klien) dan ID Direktori (penyewa).

### Latihan 2: Amankan Pelayan MCP Tempatan (Klien Awam)  
- Ikuti contoh kod untuk mengintegrasikan MSAL (Microsoft Authentication Library) untuk pengesahan pengguna.  
- Uji aliran pengesahan dengan memanggil alat MCP yang mengambil butiran pengguna dari Microsoft Graph.

### Latihan 3: Amankan Pelayan MCP Jauh (Klien Rahsia)  
- Daftarkan klien rahsia dalam Entra ID dan cipta rahsia klien.  
- Konfigurasikan pelayan MCP Express.js anda untuk menggunakan Aliran Kod Kebenaran.  
- Uji titik akhir yang dilindungi dan sahkan akses berdasarkan token.

### Latihan 4: Terapkan Amalan Keselamatan Terbaik  
- Aktifkan HTTPS untuk pelayan tempatan atau jauh anda.  
- Laksanakan kawalan akses berdasarkan peranan (RBAC) dalam logik pelayan anda.  
- Tambah pengurusan tamat tempoh token dan penyimpanan token yang selamat.

## Sumber  

1. **Dokumentasi Gambaran Keseluruhan MSAL**  
   Pelajari bagaimana Microsoft Authentication Library (MSAL) membolehkan pemerolehan token yang selamat merentas platform:  
   [Gambaran Keseluruhan MSAL di Microsoft Learn](https://learn.microsoft.com/en-gb/entra/msal/overview)

2. **Repositori GitHub Azure-Samples/mcp-auth-servers**  
   Implementasi rujukan pelayan MCP yang menunjukkan aliran pengesahan:  
   [Azure-Samples/mcp-auth-servers di GitHub](https://github.com/Azure-Samples/mcp-auth-servers)

3. **Gambaran Keseluruhan Identiti Terurus untuk Sumber Azure**  
   Fahami bagaimana menghapuskan rahsia dengan menggunakan identiti terurus yang ditetapkan sistem atau pengguna:  
   [Gambaran Keseluruhan Identiti Terurus di Microsoft Learn](https://learn.microsoft.com/en-us/entra/identity/managed-identities-azure-resources/)

4. **Azure API Management: Pintu Gerbang Pengesahan Anda untuk Pelayan MCP**  
   Penjelasan mendalam mengenai penggunaan APIM sebagai pintu gerbang OAuth2 yang selamat untuk pelayan MCP:  
   [Azure API Management Your Auth Gateway For MCP Servers](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

5. **Rujukan Kebenaran Microsoft Graph**  
   Senarai komprehensif kebenaran delegasi dan aplikasi untuk Microsoft Graph:  
   [Rujukan Kebenaran Microsoft Graph](https://learn.microsoft.com/zh-tw/graph/permissions-reference)

## Hasil Pembelajaran  
Selepas melengkapkan bahagian ini, anda akan dapat:

- Menjelaskan mengapa pengesahan adalah kritikal untuk pelayan MCP dan aliran kerja AI.  
- Menyediakan dan mengkonfigurasi pengesahan Entra ID untuk senario pelayan MCP tempatan dan jauh.  
- Memilih jenis klien yang sesuai (awam atau rahsia) berdasarkan penyebaran pelayan anda.  
- Melaksanakan amalan pengkodan selamat, termasuk penyimpanan token dan kebenaran berdasarkan peranan.  
- Melindungi pelayan MCP dan alatnya daripada akses tanpa kebenaran dengan yakin.

## Apa Seterusnya  

- [5.13 Integrasi Model Context Protocol (MCP) dengan Azure AI Foundry](../mcp-foundry-agent-integration/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk memastikan ketepatan, sila ambil maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya hendaklah dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan oleh penterjemah manusia profesional adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.