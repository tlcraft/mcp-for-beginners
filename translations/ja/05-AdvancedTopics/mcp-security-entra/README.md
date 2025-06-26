<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0abf26a6c4dbe905d5d49ccdc0ccfe92",
  "translation_date": "2025-06-26T16:21:35+00:00",
  "source_file": "05-AdvancedTopics/mcp-security-entra/README.md",
  "language_code": "ja"
}
-->
# AIワークフローのセキュリティ強化：モデルコンテキストプロトコルサーバーのEntra ID認証

## はじめに  
モデルコンテキストプロトコル（MCP）サーバーのセキュリティは、自宅の玄関の鍵をかけるのと同じくらい重要です。MCPサーバーを無防備にしておくと、ツールやデータが不正アクセスにさらされ、セキュリティ侵害につながる恐れがあります。Microsoft Entra IDは、強力なクラウドベースのIDおよびアクセス管理ソリューションを提供し、認可されたユーザーやアプリケーションだけがMCPサーバーとやり取りできるように支援します。このセクションでは、Entra ID認証を使ってAIワークフローを保護する方法を学びます。

## 学習目標  
このセクションを終える頃には、以下のことができるようになります：

- MCPサーバーのセキュリティの重要性を理解する。
- Microsoft Entra IDとOAuth 2.0認証の基本を説明できる。
- パブリッククライアントとコンフィデンシャルクライアントの違いを認識する。
- ローカル（パブリッククライアント）およびリモート（コンフィデンシャルクライアント）のMCPサーバーシナリオでEntra ID認証を実装する。
- AIワークフロー開発時にセキュリティのベストプラクティスを適用する。

## セキュリティとMCP

自宅の玄関の鍵をかけずに放置しないように、MCPサーバーも誰でもアクセスできる状態にしてはいけません。AIワークフローのセキュリティは、堅牢で信頼性の高い安全なアプリケーションを構築するために不可欠です。本章ではMicrosoft Entra IDを使ってMCPサーバーを保護し、認可されたユーザーやアプリケーションだけがツールやデータにアクセスできるようにする方法を紹介します。

## MCPサーバーにおけるセキュリティの重要性

例えば、MCPサーバーにメール送信や顧客データベースにアクセスできるツールがあるとします。セキュリティが不十分なサーバーでは、誰でもそのツールを使えてしまい、不正なデータアクセスやスパム、その他悪意のある行為につながる可能性があります。

認証を実装することで、サーバーへのすべてのリクエストが検証され、リクエストを行うユーザーやアプリケーションの身元が確認されます。これがAIワークフローを守るための最初で最も重要なステップです。

## Microsoft Entra IDの紹介

[**Microsoft Entra ID**](https://adoption.microsoft.com/microsoft-security/entra/)は、クラウドベースのIDおよびアクセス管理サービスです。アプリケーションのための万能なセキュリティガードマンのような存在と考えてください。ユーザーの身元確認（認証）や、何が許可されているかの判断（認可）という複雑な処理を担当します。

Entra IDを使うことで：

- ユーザーの安全なサインインを可能にし、
- APIやサービスを保護し、
- アクセスポリシーを一元管理できます。

MCPサーバーにおいては、誰がサーバーの機能にアクセスできるかを管理するための信頼性の高いソリューションを提供します。

---

## 魔法の仕組み：Entra ID認証の動作原理

Entra IDは**OAuth 2.0**のようなオープンスタンダードを使って認証を処理します。詳細は複雑ですが、基本的な考え方はアナロジーで理解できます。

### OAuth 2.0のやさしい紹介：バレイキーの例え

OAuth 2.0は車のバレイサービスのようなものです。レストランに着いた時、マスターキーを渡すわけではなく、限定的な権限を持つ**バレイキー**を渡します。このキーは車を始動してドアをロックできますが、トランクやグローブボックスは開けられません。

この例えでいうと：

- **あなた**は**ユーザー**。
- **あなたの車**は価値あるツールやデータを持つ**MCPサーバー**。
- **バレイ**は**Microsoft Entra ID**。
- **パーキング係**は**MCPクライアント**（サーバーにアクセスしようとするアプリ）。
- **バレイキー**は**アクセストークン**。

アクセストークンは、ユーザーがサインインした後にEntra IDからMCPクライアントに渡される安全な文字列です。クライアントはこのトークンをサーバーにリクエストごとに提示し、サーバーはトークンの正当性とクライアントの権限を検証します。実際のパスワードなどの認証情報を扱う必要はありません。

### 認証の流れ

実際の流れは以下の通りです：

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

### Microsoft Authentication Library (MSAL)の紹介

コード例に入る前に重要なコンポーネントを紹介します：**Microsoft Authentication Library (MSAL)**。

MSALはMicrosoftが開発したライブラリで、開発者が認証を簡単に扱えるようにします。セキュリティトークンの管理やサインイン処理、セッションの更新など複雑なコードを書く代わりに、MSALがこれらの処理を肩代わりします。

MSALを使うメリットは：

- **安全性が高い**：業界標準のプロトコルとセキュリティベストプラクティスを実装しており、脆弱性のリスクを減らせます。
- **開発が簡単**：OAuth 2.0やOpenID Connectの複雑さを抽象化し、少ないコードで堅牢な認証を追加できます。
- **メンテナンスされている**：Microsoftが積極的に更新し、新しい脅威やプラットフォームの変更に対応しています。

MSALは.NET、JavaScript/TypeScript、Python、Java、Go、iOSやAndroidなど多くの言語やプラットフォームをサポートしており、技術スタック全体で一貫した認証パターンを使えます。

MSALについて詳しくは公式の[MSAL概要ドキュメント](https://learn.microsoft.com/entra/identity-platform/msal-overview)をご覧ください。

---

## Entra IDでMCPサーバーを保護する：ステップバイステップガイド

ここからは、ローカルのMCPサーバー（`stdio`) using Entra ID. This example uses a **public client**, which is suitable for applications running on a user's machine, like a desktop app or a local development server.

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
- **`AcquireTokenAsync`メソッドを使う例）を保護する方法を説明します。これはまずサイレントにトークン取得を試み（有効なセッションがあれば再サインイン不要）、できなければユーザーに対話的にサインインを促します。

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
- **`GetUserDetailsFromGraph` tool**: This tool requires an instance of `AuthenticationService`. Before it does anything, it calls `authService.AcquireTokenAsync()`は有効なアクセストークンを取得します。認証成功後、そのトークンを使ってMicrosoft Graph APIからユーザー情報を取得します。

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

#### 3. 全体の流れ

1. MCPクライアントが`GetUserDetailsFromGraph` tool, the tool first calls `AcquireTokenAsync`.
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
- **`/auth/callback`エンドポイントを使おうとします。これはユーザーが認証後にEntra IDからリダイレクトされる場所で、認可コードをアクセストークンとリフレッシュトークンに交換します。

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

This file defines the tools that the MCP server provides. The `getUserDetails`ツールは前の例と似ていますが、アクセストークンはセッションから取得します。

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
6. When the `getUserDetails`ツールが呼ばれると、セッショントークンを使ってEntra IDアクセストークンを参照し、それを使ってMicrosoft Graph APIを呼び出します。

このフローはパブリッククライアントのものより複雑ですが、インターネットに公開されるリモートMCPサーバーには強力なセキュリティが必要です。不正アクセスや攻撃から守るための措置となります。

## セキュリティのベストプラクティス

- **常にHTTPSを使用する**：クライアントとサーバー間の通信を暗号化し、トークンの傍受を防ぎます。
- **ロールベースアクセス制御（RBAC）を実装する**：ユーザーが認証されているかだけでなく、何が許可されているかもチェックしましょう。Entra IDでロールを定義し、MCPサーバーでそれを確認できます。
- **監視と監査を行う**：認証イベントをすべてログに記録し、不審な活動を検出・対応できるようにします。
- **レート制限とスロットリングに対応する**：Microsoft GraphなどのAPIは濫用防止のためレート制限を実施しています。HTTP 429（Too Many Requests）に対して指数的バックオフとリトライ処理を実装し、APIコールを減らすために頻繁に使うデータはキャッシュを検討してください。
- **トークンの安全な保管**：アクセストークンやリフレッシュトークンは安全に保管しましょう。ローカルアプリではシステムの安全なストレージを使い、サーバーアプリでは暗号化ストレージやAzure Key Vaultなどの安全なキー管理サービスの利用を検討してください。
- **トークンの有効期限管理**：アクセストークンは有効期限があるため、リフレッシュトークンを使って自動的にトークンを更新し、ユーザーが再認証不要で継続利用できるようにします。
- **Azure API Managementの活用を検討する**：MCPサーバー内で直接セキュリティを実装することで細かな制御が可能ですが、APIゲートウェイ（Azure API Managementなど）を使うと認証・認可、レート制限、監視など多くのセキュリティ課題を自動的に処理でき、クライアントとMCPサーバーの間に一元的なセキュリティレイヤーを設けられます。MCPでのAPIゲートウェイ活用については[Azure API Management Your Auth Gateway For MCP Servers](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)をご参照ください。

## 重要なポイントまとめ

- MCPサーバーのセキュリティは、データやツールを守るために欠かせません。
- Microsoft Entra IDは認証と認可のための強力でスケーラブルなソリューションを提供します。
- ローカルアプリケーションには**パブリッククライアント**、リモートサーバーには**コンフィデンシャルクライアント**を使い分けましょう。
- ウェブアプリケーションには最も安全な**Authorization Code Flow**を推奨します。

## 演習

1. 自分が構築するかもしれないMCPサーバーはローカルサーバーですか、それともリモートサーバーですか？
2. その答えに基づいて、パブリッククライアントとコンフィデンシャルクライアントのどちらを使いますか？
3. Microsoft Graphに対してどのような権限をMCPサーバーに要求させますか？

## ハンズオン演習

### 演習1：Entra IDでアプリケーションを登録する  
Microsoft Entraポータルにアクセスし、MCPサーバー用の新しいアプリケーションを登録します。  
アプリケーション（クライアント）IDとディレクトリ（テナント）IDを控えておきましょう。

### 演習2：ローカルMCPサーバーの保護（パブリッククライアント）  
- MSAL（Microsoft Authentication Library）を使ったユーザー認証の統合をコード例に従って行います。  
- Microsoft Graphからユーザー情報を取得するMCPツールを呼び出して認証フローをテストします。

### 演習3：リモートMCPサーバーの保護（コンフィデンシャルクライアント）  
- Entra IDでコンフィデンシャルクライアントを登録し、クライアントシークレットを作成します。  
- Express.jsのMCPサーバーをAuthorization Code Flowで設定します。  
- 保護されたエンドポイントをテストし、トークンベースのアクセスを確認します。

### 演習4：セキュリティのベストプラクティス適用  
- ローカルまたはリモートサーバーでHTTPSを有効にします。  
- サーバーロジックにロールベースアクセス制御（RBAC）を実装します。  
- トークンの有効期限管理と安全なトークン保管を追加します。

## 参考資料

1. **MSAL概要ドキュメント**  
   Microsoft Authentication Library（MSAL）がプラットフォームを超えた安全なトークン取得を可能にする仕組みを学べます：  
   [MSAL Overview on Microsoft Learn](https://learn.microsoft.com/en-gb/entra/msal/overview)

2. **Azure-Samples/mcp-auth-servers GitHubリポジトリ**  
   認証フローを示すMCPサーバーのリファレンス実装：  
   [Azure-Samples/mcp-auth-servers on GitHub](https://github.com/Azure-Samples/mcp-auth-servers)

3. **AzureリソースのマネージドID概要**  
   シークレットを使わずにシステムまたはユーザー割り当てのマネージドIDを利用する方法：  
   [Managed Identities Overview on Microsoft Learn](https://learn.microsoft.com/en-us/entra/identity/managed-identities-azure-resources/)

4. **Azure API Management: MCPサーバーの認証ゲートウェイ**  
   MCPサーバー向けの安全なOAuth2ゲートウェイとしてAPIMを活用する詳細：  
   [Azure API Management Your Auth Gateway For MCP Servers](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

5. **Microsoft Graphの権限リファレンス**  
   Microsoft Graphの委任およびアプリケーション権限の包括的リスト：  
   [Microsoft Graph Permissions Reference](https://learn.microsoft.com/zh-tw/graph/permissions-reference)

## 学習成果  
このセクションを修了すると、以下ができるようになります：

- MCPサーバーおよびAIワークフローにおける認証の重要性を説明できる。  
- ローカルおよびリモートMCPサーバーのシナリオでEntra ID認証を設定・構成できる。  
- サーバーの展開に応じて適切なクライアントタイプ（パブリックまたはコンフィデンシャル）を選択できる。  
- トークン保管やロールベース認可を含む安全なコーディングプラクティスを実装できる。  
- MCPサーバーとそのツールを不正アクセスから自信を持って保護できる。

## 次のステップ

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**免責事項**:  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されています。正確性の確保に努めておりますが、自動翻訳には誤りや不正確な箇所が含まれる可能性があることをご理解ください。原文の母国語版が正式な情報源として優先されます。重要な情報については、専門の人間翻訳を推奨いたします。本翻訳の使用により生じたいかなる誤解や誤訳についても、当方は責任を負いかねます。