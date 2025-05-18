<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "788eb17750e970a0bc3b5e7f2e99975b",
  "translation_date": "2025-05-18T15:01:24+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "ja"
}
-->
# 📖 MCP コアコンセプト：AI統合のためのモデルコンテキストプロトコルの習得

Model Context Protocol（MCP）は、大規模言語モデル（LLM）と外部ツール、アプリケーション、データソース間の通信を最適化する強力で標準化されたフレームワークです。このSEO最適化されたガイドでは、MCPのクライアント・サーバーアーキテクチャ、主要コンポーネント、通信の仕組み、実装のベストプラクティスをわかりやすく解説します。

## 概要

このレッスンでは、Model Context Protocol（MCP）エコシステムを構成する基本的なアーキテクチャとコンポーネントを探ります。クライアント・サーバーアーキテクチャ、主要な構成要素、MCPのやり取りを支える通信メカニズムについて学びます。

## 👩‍🎓 主な学習目標

このレッスンを終える頃には、以下を理解できるようになります：

- MCPのクライアント・サーバーアーキテクチャの理解
- Hosts、Clients、Serversの役割と責任の識別
- MCPを柔軟な統合レイヤーにしているコア機能の分析
- MCPエコシステム内での情報の流れの理解
- .NET、Java、Python、JavaScriptでのコード例を通じた実践的な知見の習得

## 🔎 MCPアーキテクチャ：より深く掘り下げる

MCPエコシステムはクライアント・サーバーモデルに基づいて構築されています。このモジュラー構造により、AIアプリケーションはツール、データベース、API、コンテキストリソースと効率的に連携できます。ここではこのアーキテクチャの主要な構成要素を分解して説明します。

### 1. Hosts

Model Context Protocol（MCP）におけるHostsは、ユーザーがプロトコルとやり取りする主要なインターフェースとして重要な役割を担います。HostsはMCPサーバーへの接続を開始し、データ、ツール、プロンプトにアクセスするアプリケーションや環境です。例としては、Visual Studio Codeのような統合開発環境（IDE）、Claude DesktopのようなAIツール、または特定のタスク向けにカスタム構築されたエージェントが挙げられます。

**Hosts**はLLMアプリケーションで、接続を開始します。主な役割は：

- AIモデルを実行または対話し、応答を生成する
- MCPサーバーへの接続を開始する
- 会話の流れやユーザーインターフェースを管理する
- 権限やセキュリティ制約を制御する
- データ共有やツール実行に関するユーザー同意を管理する

### 2. Clients

ClientsはHostsとMCPサーバー間のやり取りを円滑にする重要なコンポーネントです。Clientsは仲介者として機能し、HostsがMCPサーバーの機能を利用できるようにします。MCPアーキテクチャ内でのスムーズな通信と効率的なデータ交換を支えます。

**Clients**はホストアプリケーション内のコネクタです。主な役割は：

- サーバーへプロンプトや指示を含むリクエストを送信する
- サーバーとの機能交渉を行う
- モデルからのツール実行要求を管理する
- ユーザーへの応答を処理し表示する

### 3. Servers

ServersはMCPクライアントからのリクエストを処理し、適切な応答を提供する役割を担います。データ取得、ツール実行、プロンプト生成などの操作を管理し、クライアントとHosts間の通信を効率的かつ信頼性高く維持します。

**Servers**はコンテキストと機能を提供するサービスです。主な役割は：

- 利用可能な機能（リソース、プロンプト、ツール）を登録する
- クライアントからのツール呼び出しを受け取り実行する
- モデルの応答を強化するためのコンテキスト情報を提供する
- 出力をクライアントに返す
- 必要に応じてやり取りの状態を維持する

Serversは誰でも開発可能で、専門的な機能を追加してモデルの能力を拡張できます。

### 4. Server Features

Model Context Protocol（MCP）のServersは、クライアント、ホスト、言語モデル間の豊かな対話を可能にする基本的な構成要素を提供します。これらの機能は、構造化されたコンテキスト、ツール、プロンプトを提供することでMCPの能力を強化します。

MCPサーバーが提供できる主な機能は以下の通りです。

#### 📑 Resources

MCPにおけるResourcesは、ユーザーやAIモデルが利用可能なさまざまな種類のコンテキストやデータを指します。具体的には：

- **コンテキストデータ**：ユーザーやAIモデルが意思決定やタスク実行に活用できる情報や背景
- **ナレッジベースやドキュメントリポジトリ**：記事、マニュアル、研究論文などの構造化・非構造化データのコレクション
- **ローカルファイルやデータベース**：デバイスやデータベース内に保存されたデータで、処理や分析のためにアクセス可能
- **APIやWebサービス**：外部のインターフェースやサービスで、追加のデータや機能を提供し、オンラインリソースやツールとの統合を可能にする

リソースの例として、以下のようなデータベーススキーマやファイルが挙げられます。

```text
file://log.txt
database://schema
```

### 🤖 Prompts

MCPにおけるPromptsは、ユーザーのワークフローを効率化しコミュニケーションを円滑にするための事前定義されたテンプレートや対話パターンです。具体的には：

- **テンプレート化されたメッセージやワークフロー**：特定のタスクや対話を案内する構造化されたメッセージやプロセス
- **事前定義された対話パターン**：一貫性のある効率的なコミュニケーションを促進する標準化されたアクションと応答のシーケンス
- **専門的な会話テンプレート**：特定の会話タイプに合わせてカスタマイズ可能なテンプレートで、関連性が高く文脈に適した対話を実現

プロンプトテンプレートの例は以下の通りです。

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Tools

MCPのToolsは、AIモデルが特定のタスクを実行するために呼び出せる関数群です。これらは構造化され信頼性の高い操作を提供し、AIモデルの能力を拡張します。主な特徴は：

- **AIモデルが実行可能な関数**：ツールはAIモデルが呼び出してタスクを遂行するための実行可能な関数
- **固有の名前と説明**：各ツールは独自の名前と、その目的や機能を説明する詳細な説明を持つ
- **パラメータと出力**：ツールは特定のパラメータを受け取り、構造化された出力を返すことで一貫性と予測可能性を確保
- **独立した機能**：ウェブ検索、計算、データベースクエリなどの個別機能を実行

ツールの例は以下のようになります。

```typescript
server.tool(
  "GetProducts"
  {
    pageSize: z.string().optional(),
    pageCount: z.string().optional()
  }, () => {
    // return results from API
  }
)
```

## Client Features

MCPにおけるクライアントは、サーバーへのいくつかの重要な機能を提供し、プロトコル内の全体的な機能とやり取りを強化します。代表的な機能の一つがSamplingです。

### 👉 Sampling

- **サーバー主導のエージェント的動作**：クライアントはサーバーが特定のアクションや動作を自律的に開始できるようにし、システムの動的な能力を高める
- **再帰的なLLMとの対話**：この機能により、大規模言語モデル（LLM）との複雑かつ反復的なやり取りが可能になる
- **追加のモデル完了要求**：サーバーはモデルに追加の応答生成を要求でき、より充実した文脈に沿った回答を得られる

## MCPにおける情報の流れ

Model Context Protocol（MCP）は、Hosts、Clients、Servers、モデル間の情報の構造化された流れを定義しています。この流れを理解することで、ユーザーのリクエストがどのように処理され、外部ツールやデータがモデルの応答に統合されるかが明確になります。

- **Hostが接続を開始**  
  IDEやチャットインターフェースなどのホストアプリケーションが、通常STDIO、WebSocket、または他の対応トランスポート経由でMCPサーバーへの接続を確立します。

- **機能交渉**  
  ホストに組み込まれたクライアントとサーバーが、対応可能な機能、ツール、リソース、プロトコルバージョンについて情報交換します。これにより、双方が利用可能な機能を把握し、セッションに適応します。

- **ユーザーリクエスト**  
  ユーザーがホストに対してプロンプトやコマンドを入力します。ホストはこの入力をクライアントに渡して処理します。

- **リソースまたはツールの利用**  
  - クライアントは、モデルの理解を深めるためにサーバーから追加のコンテキストやリソース（ファイル、データベースエントリ、ナレッジベース記事など）を要求することがあります。
  - モデルがツールの利用が必要と判断した場合（例：データ取得、計算、API呼び出し）、クライアントはツール名とパラメータを指定してサーバーにツール呼び出しリクエストを送信します。

- **サーバー実行**  
  サーバーはリソースやツールのリクエストを受け取り、必要な操作（関数実行、データベース問い合わせ、ファイル取得など）を行い、結果を構造化された形式でクライアントに返します。

- **応答生成**  
  クライアントはサーバーの応答（リソースデータ、ツール出力など）を現在のモデルとの対話に統合します。モデルはこれらの情報を使って包括的で文脈に合った応答を生成します。

- **結果提示**  
  ホストはクライアントから最終出力を受け取り、モデル生成テキストやツール実行結果を含めてユーザーに提示します。

この情報の流れにより、MCPはモデルと外部ツールやデータソースをシームレスに接続し、高度でインタラクティブ、かつ文脈認識型のAIアプリケーションを支援します。

## プロトコルの詳細

MCP（Model Context Protocol）は[JSON-RPC 2.0](https://www.jsonrpc.org/)をベースに構築されており、ホスト、クライアント、サーバー間の通信に標準化された言語非依存のメッセージフォーマットを提供します。この基盤により、多様なプラットフォームやプログラミング言語間で信頼性が高く構造化された拡張可能なやり取りが可能です。

### 主要なプロトコル機能

MCPはJSON-RPC 2.0を拡張し、ツール呼び出し、リソースアクセス、プロンプト管理のための追加規約を設けています。STDIO、WebSocket、SSEなど複数のトランスポート層をサポートし、コンポーネント間の安全で拡張性の高い言語非依存の通信を実現します。

#### 🧢 ベースプロトコル

- **JSON-RPCメッセージフォーマット**：すべてのリクエストとレスポンスはJSON-RPC 2.0仕様に準拠し、メソッド呼び出し、パラメータ、結果、エラー処理の一貫した構造を保証
- **ステートフル接続**：MCPセッションは複数のリクエストにまたがり状態を維持し、継続的な会話、コンテキストの蓄積、リソース管理をサポート
- **機能交渉**：接続確立時にクライアントとサーバーが対応可能な機能、プロトコルバージョン、利用可能なツールやリソースについて情報交換し、双方の能力を理解して適応

#### ➕ 追加ユーティリティ

MCPは開発者体験を向上させ、高度なシナリオを可能にする以下の追加ユーティリティやプロトコル拡張を提供します：

- **設定オプション**：ツールの権限、リソースアクセス、モデル設定などのセッションパラメータを動的に構成可能
- **進捗追跡**：長時間かかる処理の進捗を報告し、応答性の高いUIやユーザー体験を実現
- **リクエストキャンセル**：クライアントは進行中のリクエストをキャンセルでき、不要または時間がかかりすぎる処理を中断可能
- **エラー報告**：標準化されたエラーメッセージとコードで問題を診断し、失敗を適切に処理し、ユーザーや開発者に有用なフィードバックを提供
- **ログ記録**：クライアントとサーバーは監査、デバッグ、プロトコルのモニタリングのために構造化されたログを出力可能

これらの機能を活用することで、MCPは言語モデルと外部ツールやデータソース間の堅牢で安全かつ柔軟な通信を保証します。

### 🔐 セキュリティ上の考慮事項

MCPの実装では、安全で信頼できるやり取りを確保するために以下の主要なセキュリティ原則に従う必要があります：

- **ユーザーの同意とコントロール**：データアクセスや操作の実行前にユーザーから明示的な同意を得ること。共有するデータや許可するアクションをユーザーが明確に管理できるようにし、レビューや承認のための直感的なUIを提供すること。

- **データプライバシー**：ユーザーデータは明示的な同意がある場合にのみ公開され、適切なアクセス制御によって保護されること。MCP実装は不正なデータ送信を防ぎ、すべてのやり取りでプライバシーを維持する必要がある。

- **ツールの安全性**：ツール呼び出し前に明確なユーザー同意を必須とし、各ツールの機能をユーザーが理解できるようにすること。意図しないまたは危険なツール実行を防ぐための堅牢なセキュリティ境界を設けること。

これらの原則を守ることで、MCPはすべてのプロトコルやり取りにおいてユーザーの信頼、プライバシー、安全性を確保します。

## コード例：主要コンポーネント

以下に、主要なMCPサーバーコンポーネントやツールの実装例をいくつかの人気プログラミング言語で示します。

### .NET例：ツールを備えたシンプルなMCPサーバーの作成

以下は、カスタムツールを定義・登録し、リクエストを処理し、Model Context Protocolを使ってサーバーを接続する実践的な.NETコード例です。

```csharp
using System;
using System.Threading.Tasks;
using ModelContextProtocol.Server;
using ModelContextProtocol.Server.Transport;
using ModelContextProtocol.Server.Tools;

public class WeatherServer
{
    public static async Task Main(string[] args)
    {
        // Create an MCP server
        var server = new McpServer(
            name: "Weather MCP Server",
            version: "1.0.0"
        );
        
        // Register our custom weather tool
        server.AddTool<string, WeatherData>("weatherTool", 
            description: "Gets current weather for a location",
            execute: async (location) => {
                // Call weather API (simplified)
                var weatherData = await GetWeatherDataAsync(location);
                return weatherData;
            });
        
        // Connect the server using stdio transport
        var transport = new StdioServerTransport();
        await server.ConnectAsync(transport);
        
        Console.WriteLine("Weather MCP Server started");
        
        // Keep the server running until process is terminated
        await Task.Delay(-1);
    }
    
    private static async Task<WeatherData> GetWeatherDataAsync(string location)
    {
        // This would normally call a weather API
        // Simplified for demonstration
        await Task.Delay(100); // Simulate API call
        return new WeatherData { 
            Temperature = 72.5,
            Conditions = "Sunny",
            Location = location
        };
    }
}

public class WeatherData
{
    public double Temperature { get; set; }
    public string Conditions { get; set; }
    public string Location { get; set; }
}
```

### Java例：MCPサーバーコンポーネント

こちらの例は上記.NET例と同じMCPサーバーおよびツール登録をJavaで実装したものです。

```java
import io.modelcontextprotocol.server.McpServer;
import io.modelcontextprotocol.server.McpToolDefinition;
import io.modelcontextprotocol.server.transport.StdioServerTransport;
import io.modelcontextprotocol.server.tool.ToolExecutionContext;
import io.modelcontextprotocol.server.tool.ToolResponse;

public class WeatherMcpServer {
    public static void main(String[] args) throws Exception {
        // Create an MCP server
        McpServer server = McpServer.builder()
            .name("Weather MCP Server")
            .version("1.0.0")
            .build();
            
        // Register a weather tool
        server.registerTool(McpToolDefinition.builder("weatherTool")
            .description("Gets current weather for a location")
            .parameter("location", String.class)
            .execute((ToolExecutionContext ctx) -> {
                String location = ctx.getParameter("location", String.class);
                
                // Get weather data (simplified)
                WeatherData data = getWeatherData(location);
                
                // Return formatted response
                return ToolResponse.content(
                    String.format("Temperature: %.1f°F, Conditions: %s, Location: %s", 
                    data.getTemperature(), 
                    data.getConditions(), 
                    data.getLocation())
                );
            })
            .build());
        
        // Connect the server using stdio transport
        try (StdioServerTransport transport = new StdioServerTransport()) {
            server.connect(transport);
            System.out.println("Weather MCP Server started");
            // Keep server running until process is terminated
            Thread.currentThread().join();
        }
    }
    
    private static WeatherData getWeatherData(String location) {
        // Implementation would call a weather API
        // Simplified for example purposes
        return new WeatherData(72.5, "Sunny", location);
    }
}

class WeatherData {
    private double temperature;
    private String conditions;
    private String location;
    
    public WeatherData(double temperature, String conditions, String location) {
        this.temperature = temperature;
        this.conditions = conditions;
        this.location = location;
    }
    
    public double getTemperature() {
        return temperature;
    }
    
    public String getConditions() {
        return conditions;
    }
    
    public String getLocation() {
        return location;
    }
}
```



**免責事項**：  
本書類はAI翻訳サービス[Co-op Translator](https://github.com/Azure/co-op-translator)を使用して翻訳されました。正確性には努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語によるオリジナル文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間翻訳をご利用いただくことを推奨します。本翻訳の使用に起因するいかなる誤解や誤訳についても、当方は責任を負いかねます。