<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0abf26a6c4dbe905d5d49ccdc0ccfe92",
  "translation_date": "2025-06-26T16:26:52+00:00",
  "source_file": "05-AdvancedTopics/mcp-security-entra/README.md",
  "language_code": "pt"
}
-->
# Proteger Workflows de IA: Autenticação Entra ID para Servidores Model Context Protocol

## Introdução  
Proteger o seu servidor Model Context Protocol (MCP) é tão importante quanto trancar a porta da frente da sua casa. Deixar o seu servidor MCP aberto expõe as suas ferramentas e dados a acessos não autorizados, o que pode resultar em falhas de segurança. O Microsoft Entra ID oferece uma solução robusta de gestão de identidade e acesso baseada na cloud, ajudando a garantir que apenas utilizadores e aplicações autorizadas possam interagir com o seu servidor MCP. Nesta secção, irá aprender como proteger os seus workflows de IA utilizando autenticação Entra ID.

## Objetivos de Aprendizagem  
No final desta secção, será capaz de:

- Compreender a importância de proteger os servidores MCP.  
- Explicar os conceitos básicos do Microsoft Entra ID e da autenticação OAuth 2.0.  
- Reconhecer a diferença entre clientes públicos e confidenciais.  
- Implementar autenticação Entra ID em cenários de servidores MCP locais (cliente público) e remotos (cliente confidencial).  
- Aplicar as melhores práticas de segurança no desenvolvimento de workflows de IA.

## Segurança e MCP  

Assim como não deixaria a porta da frente da sua casa destrancada, também não deve deixar o seu servidor MCP aberto para qualquer pessoa aceder. Proteger os seus workflows de IA é essencial para construir aplicações robustas, confiáveis e seguras. Este capítulo irá apresentar-lhe como usar o Microsoft Entra ID para proteger os seus servidores MCP, garantindo que apenas utilizadores e aplicações autorizadas possam interagir com as suas ferramentas e dados.

## Por que a Segurança é Importante para Servidores MCP  

Imagine que o seu servidor MCP tem uma ferramenta que pode enviar emails ou aceder a uma base de dados de clientes. Um servidor não seguro significaria que qualquer pessoa poderia potencialmente usar essa ferramenta, levando a acessos não autorizados a dados, spam ou outras atividades maliciosas.

Ao implementar autenticação, garante que cada pedido ao seu servidor é verificado, confirmando a identidade do utilizador ou aplicação que faz o pedido. Este é o primeiro e mais importante passo para proteger os seus workflows de IA.

## Introdução ao Microsoft Entra ID  

[**Microsoft Entra ID**](https://adoption.microsoft.com/microsoft-security/entra/) é um serviço de gestão de identidade e acesso baseado na cloud. Pense nele como um segurança universal para as suas aplicações. Ele trata do processo complexo de verificar identidades de utilizadores (autenticação) e determinar o que eles estão autorizados a fazer (autorização).

Ao usar o Entra ID, pode:

- Permitir um início de sessão seguro para os utilizadores.  
- Proteger APIs e serviços.  
- Gerir políticas de acesso a partir de um local centralizado.

Para servidores MCP, o Entra ID oferece uma solução robusta e amplamente confiável para gerir quem pode aceder às capacidades do seu servidor.

---

## Entendendo a Magia: Como Funciona a Autenticação Entra ID  

O Entra ID usa padrões abertos como **OAuth 2.0** para gerir a autenticação. Embora os detalhes possam ser complexos, o conceito principal é simples e pode ser entendido através de uma analogia.

### Uma Introdução Simples ao OAuth 2.0: A Chave do Estacionamento  

Pense no OAuth 2.0 como um serviço de manobrista para o seu carro. Quando chega a um restaurante, não entrega a chave mestra ao manobrista. Em vez disso, fornece uma **chave de manobrista** com permissões limitadas — pode ligar o carro e trancar as portas, mas não pode abrir o porta-bagagens ou a caixa de luvas.

Nesta analogia:

- **Você** é o **Utilizador**.  
- **O seu carro** é o **Servidor MCP** com as suas ferramentas e dados valiosos.  
- O **Manobrista** é o **Microsoft Entra ID**.  
- O **Atendente do Estacionamento** é o **Cliente MCP** (a aplicação que tenta aceder ao servidor).  
- A **Chave de Manobrista** é o **Token de Acesso**.

O token de acesso é uma cadeia segura de texto que o cliente MCP recebe do Entra ID depois de iniciar sessão. O cliente apresenta este token ao servidor MCP em cada pedido. O servidor pode verificar o token para garantir que o pedido é legítimo e que o cliente tem as permissões necessárias, tudo isto sem nunca ter de lidar com as suas credenciais reais (como a sua palavra-passe).

### O Fluxo de Autenticação  

Aqui está como o processo funciona na prática:

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

### Apresentando a Microsoft Authentication Library (MSAL)  

Antes de entrarmos no código, é importante apresentar um componente chave que verá nos exemplos: a **Microsoft Authentication Library (MSAL)**.

A MSAL é uma biblioteca desenvolvida pela Microsoft que facilita muito o trabalho dos programadores ao lidar com autenticação. Em vez de ter de escrever todo o código complexo para gerir tokens de segurança, iniciar sessões e atualizar sessões, a MSAL trata de tudo isso.

Usar uma biblioteca como a MSAL é altamente recomendado porque:

- **É Seguro:** Implementa protocolos padrão da indústria e as melhores práticas de segurança, reduzindo o risco de vulnerabilidades no seu código.  
- **Simplifica o Desenvolvimento:** Abstrai a complexidade dos protocolos OAuth 2.0 e OpenID Connect, permitindo adicionar autenticação robusta à sua aplicação com apenas algumas linhas de código.  
- **É Mantida:** A Microsoft mantém e atualiza ativamente a MSAL para responder a novas ameaças de segurança e mudanças nas plataformas.

A MSAL suporta uma grande variedade de linguagens e frameworks, incluindo .NET, JavaScript/TypeScript, Python, Java, Go e plataformas móveis como iOS e Android. Isto significa que pode usar os mesmos padrões de autenticação consistentes em toda a sua stack tecnológica.

Para saber mais sobre a MSAL, pode consultar a documentação oficial [Visão geral da MSAL](https://learn.microsoft.com/entra/identity-platform/msal-overview).

---

## Proteger o Seu Servidor MCP com Entra ID: Guia Passo a Passo  

Agora, vamos ver como proteger um servidor MCP local (que comunica através de `stdio`) using Entra ID. This example uses a **public client**, which is suitable for applications running on a user's machine, like a desktop app or a local development server.

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
- **`AcquireTokenAsync`**: Este é o método principal. Primeiro tenta obter um token silenciosamente (significando que o utilizador não terá de iniciar sessão novamente se já tiver uma sessão válida). Se não conseguir obter um token silencioso, irá pedir ao utilizador para iniciar sessão interativamente.

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
- **`GetUserDetailsFromGraph` tool**: This tool requires an instance of `AuthenticationService`. Before it does anything, it calls `authService.AcquireTokenAsync()` para obter um token de acesso válido. Se a autenticação for bem-sucedida, usa o token para chamar a Microsoft Graph API e obter os detalhes do utilizador.

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

#### 3. Como Tudo Funciona em Conjunto  

1. Quando o cliente MCP tenta usar o `GetUserDetailsFromGraph` tool, the tool first calls `AcquireTokenAsync`.
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
- **`/auth/callback`**: Este endpoint trata do redirecionamento do Entra ID depois do utilizador se autenticar. Troca o código de autorização por um token de acesso e um token de atualização.

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

This file defines the tools that the MCP server provides. The `getUserDetails` a ferramenta é semelhante à do exemplo anterior, mas obtém o token de acesso da sessão.

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
6. When the `getUserDetails` a ferramenta é chamada, usa o token da sessão para procurar o token de acesso Entra ID e depois usa-o para chamar a Microsoft Graph API.

Este fluxo é mais complexo do que o fluxo de cliente público, mas é necessário para endpoints expostos na internet. Como os servidores MCP remotos são acessíveis pela internet pública, precisam de medidas de segurança mais fortes para se protegerem contra acessos não autorizados e potenciais ataques.

## Melhores Práticas de Segurança  

- **Use sempre HTTPS**: Encripte a comunicação entre cliente e servidor para proteger os tokens contra interceptações.  
- **Implemente Controlo de Acesso Baseado em Funções (RBAC)**: Não verifique apenas *se* um utilizador está autenticado; verifique *o que* ele está autorizado a fazer. Pode definir funções no Entra ID e verificá-las no seu servidor MCP.  
- **Monitorize e audite**: Registe todos os eventos de autenticação para poder detetar e responder a atividades suspeitas.  
- **Gerencie limitações e restrições de taxa**: A Microsoft Graph e outras APIs aplicam limitações para prevenir abusos. Implemente lógica de retentativa com backoff exponencial no seu servidor MCP para lidar graciosamente com respostas HTTP 429 (Too Many Requests). Considere armazenar em cache dados frequentemente acedidos para reduzir chamadas à API.  
- **Armazenamento seguro de tokens**: Guarde tokens de acesso e de atualização de forma segura. Para aplicações locais, use os mecanismos de armazenamento seguro do sistema. Para aplicações servidor, considere usar armazenamento encriptado ou serviços de gestão de chaves seguros como o Azure Key Vault.  
- **Gestão da expiração de tokens**: Os tokens de acesso têm um tempo de vida limitado. Implemente atualização automática dos tokens usando tokens de atualização para manter uma experiência de utilizador fluida sem necessidade de reautenticação.  
- **Considere usar o Azure API Management**: Embora implementar segurança diretamente no seu servidor MCP lhe dê controlo detalhado, gateways de API como o Azure API Management podem tratar muitas destas preocupações automaticamente, incluindo autenticação, autorização, limitação de taxa e monitorização. Eles fornecem uma camada de segurança centralizada entre os seus clientes e os seus servidores MCP. Para mais detalhes sobre o uso de gateways de API com MCP, consulte o nosso [Azure API Management Your Auth Gateway For MCP Servers](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690).

## Principais Conclusões  

- Proteger o seu servidor MCP é fundamental para proteger os seus dados e ferramentas.  
- O Microsoft Entra ID oferece uma solução robusta e escalável para autenticação e autorização.  
- Use um **cliente público** para aplicações locais e um **cliente confidencial** para servidores remotos.  
- O **Authorization Code Flow** é a opção mais segura para aplicações web.

## Exercício  

1. Pense num servidor MCP que possa criar. Seria um servidor local ou remoto?  
2. Com base na sua resposta, usaria um cliente público ou confidencial?  
3. Que permissões o seu servidor MCP pediria para executar ações contra a Microsoft Graph?

## Exercícios Práticos  

### Exercício 1: Registar uma Aplicação no Entra ID  
Navegue até ao portal Microsoft Entra.  
Registe uma nova aplicação para o seu servidor MCP.  
Anote o ID da Aplicação (cliente) e o ID do Diretório (inquilino).

### Exercício 2: Proteger um Servidor MCP Local (Cliente Público)  
- Siga o exemplo de código para integrar a MSAL (Microsoft Authentication Library) para autenticação de utilizadores.  
- Teste o fluxo de autenticação chamando a ferramenta MCP que obtém detalhes do utilizador da Microsoft Graph.

### Exercício 3: Proteger um Servidor MCP Remoto (Cliente Confidencial)  
- Registe um cliente confidencial no Entra ID e crie um segredo de cliente.  
- Configure o seu servidor MCP Express.js para usar o Authorization Code Flow.  
- Teste os endpoints protegidos e confirme o acesso baseado em token.

### Exercício 4: Aplicar Melhores Práticas de Segurança  
- Ative HTTPS para o seu servidor local ou remoto.  
- Implemente controlo de acesso baseado em funções (RBAC) na lógica do seu servidor.  
- Adicione gestão de expiração de tokens e armazenamento seguro de tokens.

## Recursos  

1. **Documentação de Visão Geral da MSAL**  
   Aprenda como a Microsoft Authentication Library (MSAL) permite a aquisição segura de tokens em várias plataformas:  
   [Visão Geral da MSAL na Microsoft Learn](https://learn.microsoft.com/en-gb/entra/msal/overview)

2. **Repositório GitHub Azure-Samples/mcp-auth-servers**  
   Implementações de referência de servidores MCP que demonstram fluxos de autenticação:  
   [Azure-Samples/mcp-auth-servers no GitHub](https://github.com/Azure-Samples/mcp-auth-servers)

3. **Visão Geral de Identidades Geridas para Recursos Azure**  
   Compreenda como eliminar segredos usando identidades geridas atribuídas pelo sistema ou pelo utilizador:  
   [Visão Geral de Identidades Geridas na Microsoft Learn](https://learn.microsoft.com/en-us/entra/identity/managed-identities-azure-resources/)

4. **Azure API Management: O Seu Gateway de Autenticação para Servidores MCP**  
   Uma análise aprofundada do uso do APIM como gateway OAuth2 seguro para servidores MCP:  
   [Azure API Management Your Auth Gateway For MCP Servers](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

5. **Referência de Permissões Microsoft Graph**  
   Lista abrangente de permissões delegadas e de aplicação para Microsoft Graph:  
   [Referência de Permissões Microsoft Graph](https://learn.microsoft.com/zh-tw/graph/permissions-reference)

## Resultados de Aprendizagem  
Após concluir esta secção, será capaz de:

- Explicar por que a autenticação é crítica para servidores MCP e workflows de IA.  
- Configurar e implementar autenticação Entra ID para cenários de servidores MCP locais e remotos.  
- Escolher o tipo de cliente apropriado (público ou confidencial) com base na implementação do seu servidor.  
- Implementar práticas de codificação seguras, incluindo armazenamento de tokens e autorização baseada em funções.  
- Proteger com confiança o seu servidor MCP e as suas ferramentas contra acessos não autorizados.

## Próximos Passos  

- [6. Contribuições da Comunidade](../../06-CommunityContributions/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos pela precisão, por favor tenha em conta que traduções automáticas podem conter erros ou imprecisões. O documento original na sua língua nativa deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional feita por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes da utilização desta tradução.