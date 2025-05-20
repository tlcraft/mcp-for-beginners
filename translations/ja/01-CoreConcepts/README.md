<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4bf553c18e7e226c3d76ab0cde627d26",
  "translation_date": "2025-05-20T20:47:29+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "ja"
}
-->
# 📖 MCP Core Concepts: AI統合のためのModel Context Protocolの習得

Model Context Protocol（MCP）は、Large Language Models（LLM）と外部ツール、アプリケーション、データソース間の通信を最適化する強力で標準化されたフレームワークです。このSEO最適化ガイドでは、MCPのクライアントサーバーアーキテクチャ、主要コンポーネント、通信メカニズム、実装のベストプラクティスを理解できるように解説します。

## 概要

このレッスンでは、Model Context Protocol（MCP）エコシステムを構成する基本的なアーキテクチャとコンポーネントについて学びます。クライアントサーバーアーキテクチャ、主要な構成要素、MCPインタラクションを支える通信メカニズムについて理解を深めましょう。

## 👩‍🎓 主な学習目標

このレッスンを終える頃には、以下のことができるようになります：

- MCPのクライアントサーバーアーキテクチャを理解する。
- Hosts、Clients、Serversの役割と責任を識別する。
- MCPが柔軟な統合レイヤーとなる核心的な特徴を分析する。
- MCPエコシステム内での情報の流れを学ぶ。
- .NET、Java、Python、JavaScriptのコード例を通じて実践的な知見を得る。

## 🔎 MCPアーキテクチャ：詳細解説

MCPエコシステムはクライアントサーバーモデルに基づいて構築されています。このモジュラー構造により、AIアプリケーションはツール、データベース、API、コンテキストリソースと効率的に連携できます。ここでアーキテクチャの主要コンポーネントを分解して説明します。

### 1. Hosts

Model Context Protocol（MCP）において、Hostsはユーザーがプロトコルとやり取りするための主要なインターフェースとして重要な役割を果たします。Hostsは、MCPサーバーとの接続を開始し、データ、ツール、プロンプトにアクセスするアプリケーションや環境です。例としては、Visual Studio Codeのような統合開発環境（IDE）、Claude DesktopのようなAIツール、特定のタスク向けに設計されたカスタムエージェントなどがあります。

**Hosts**はLLMアプリケーションであり、以下の役割を持ちます：

- AIモデルを実行または操作して応答を生成する。
- MCPサーバーへの接続を開始する。
- 会話の流れやユーザーインターフェースを管理する。
- 権限やセキュリティ制約を制御する。
- データ共有やツール実行に関するユーザーの同意を扱う。

### 2. Clients

ClientsはHostsとMCPサーバー間のやり取りを円滑にする重要なコンポーネントです。Clientsは仲介役として機能し、HostsがMCPサーバーの機能を利用できるようにします。MCPアーキテクチャ内でのスムーズな通信と効率的なデータ交換を支えています。

**Clients**はホストアプリケーション内のコネクターであり、以下の役割を持ちます：

- プロンプトや指示を含むリクエストをサーバーに送信する。
- サーバーとの機能交渉を行う。
- モデルからのツール実行リクエストを管理する。
- 応答を処理し、ユーザーに表示する。

### 3. Servers

ServersはMCPクライアントからのリクエストを処理し、適切な応答を提供します。データ取得、ツール実行、プロンプト生成などのさまざまな操作を管理し、クライアントとHosts間の通信が効率的かつ信頼性の高いものになるように維持します。

**Servers**はコンテキストと機能を提供するサービスで、以下の役割があります：

- 利用可能な機能（リソース、プロンプト、ツール）を登録する。
- クライアントからのツール呼び出しを受け取り実行する。
- モデルの応答を強化するためのコンテキスト情報を提供する。
- 出力をクライアントに返す。
- 必要に応じて対話の状態を維持する。

Serversは誰でも開発可能で、専門的な機能でモデルの能力を拡張できます。

### 4. Server Features

Model Context Protocol（MCP）のServersは、クライアント、ホスト、言語モデル間の豊かなインタラクションを可能にする基本的なビルディングブロックを提供します。これらの機能は、構造化されたコンテキスト、ツール、プロンプトを提供し、MCPの能力を高めるよう設計されています。

MCPサーバーは以下の機能を提供できます：

#### 📑 Resources 

MCPにおけるResourcesは、ユーザーやAIモデルが活用できるさまざまなタイプのコンテキストやデータを含みます。具体的には：

- **コンテキストデータ**：意思決定やタスク実行に役立つ情報や文脈。
- **ナレッジベースやドキュメントリポジトリ**：記事、マニュアル、研究論文などの構造化・非構造化データの集合。
- **ローカルファイルやデータベース**：デバイスやデータベース内に保存されているデータで、処理や分析に利用可能。
- **APIやウェブサービス**：追加のデータや機能を提供する外部インターフェースやサービスで、さまざまなオンラインリソースやツールと統合可能。

リソースの例として、データベーススキーマやファイルがあり、以下のようにアクセスできます：

```text
file://log.txt
database://schema
```

### 🤖 Prompts

MCPにおけるPromptsは、ユーザーのワークフローを効率化しコミュニケーションを円滑にするための事前定義されたテンプレートや対話パターンを含みます。具体例は以下の通りです：

- **テンプレート化されたメッセージやワークフロー**：特定のタスクや対話をガイドする構造化されたメッセージやプロセス。
- **事前定義された対話パターン**：一貫性と効率性を高める標準化されたアクションと応答のシーケンス。
- **専門的な会話テンプレート**：特定の会話タイプに合わせてカスタマイズ可能なテンプレートで、関連性の高い適切な対話を実現。

プロンプトテンプレートの例は以下の通りです：

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Tools

MCPにおけるToolsは、AIモデルが特定のタスクを実行するために呼び出せる関数です。これらのツールは、構造化され信頼性の高い操作を提供し、AIモデルの能力を拡張します。主な特徴は以下の通りです：

- **AIモデルが実行可能な関数**：ツールはAIモデルが呼び出してタスクを実行するための関数。
- **固有の名前と説明**：各ツールには目的と機能を説明する固有の名前と詳細な説明がある。
- **パラメーターと出力**：ツールは特定のパラメーターを受け取り、構造化された出力を返すため、一貫性と予測可能な結果を保証。
- **個別の機能**：ウェブ検索、計算、データベースクエリなど、明確に区別された機能を実行。

ツールの例は以下のようになります：

```typescript
server.tool(
  "GetProducts",
  {
    pageSize: z.string().optional(),
    pageCount: z.string().optional()
  }, () => {
    // return results from API
  }
)
```

## Client Features

MCPにおけるClientsは、サーバーとのやり取りを強化するいくつかの主要な機能を提供します。その中でも特に注目すべきはSamplingです。

### 👉 Sampling

- **サーバー主導のエージェント的動作**：クライアントはサーバーが自律的に特定のアクションや動作を開始できるようにし、システムの動的な能力を高める。
- **再帰的なLLMインタラクション**：この機能により、LLMとの複雑で反復的な処理が可能になる。
- **追加のモデル補完要求**：サーバーはモデルに対して追加の補完を要求でき、応答がより完全かつ文脈に沿ったものとなる。

## MCPにおける情報の流れ

Model Context Protocol（MCP）は、Hosts、Clients、Servers、モデル間の情報の流れを構造化して定義しています。この流れを理解することで、ユーザーのリクエストがどのように処理され、外部ツールやデータがモデルの応答に統合されるかが明確になります。

- **Hostが接続を開始**  
  Hostアプリケーション（IDEやチャットインターフェースなど）が、通常STDIO、WebSocket、または他のサポートされる通信手段を介してMCPサーバーへの接続を確立します。

- **機能交渉**  
  Host内のクライアントとサーバーが、それぞれのサポートする機能、ツール、リソース、プロトコルバージョンに関する情報を交換し、双方が利用可能な機能を理解します。

- **ユーザーリクエスト**  
  ユーザーがHostとやり取り（プロンプトやコマンド入力）し、その入力がクライアントに渡され処理されます。

- **リソースやツールの利用**  
  - クライアントはモデルの理解を深めるために、サーバーから追加のコンテキストやリソース（ファイル、データベースエントリ、ナレッジベース記事など）を要求することがあります。  
  - モデルがツールの利用を判断した場合（例：データ取得、計算、API呼び出し）、クライアントはツール名とパラメーターを指定してサーバーにツール呼び出しリクエストを送信します。

- **サーバーの実行**  
  サーバーはリソースまたはツールリクエストを受け取り、必要な操作（関数の実行、データベース問い合わせ、ファイル取得など）を行い、結果を構造化された形式でクライアントに返します。

- **応答生成**  
  クライアントはサーバーからの応答（リソースデータ、ツール出力など）をモデルとの対話に統合し、これらの情報を用いて包括的かつ文脈に即した応答を生成します。

- **結果の提示**  
  Hostはクライアントから最終出力を受け取り、モデル生成テキストやツール実行結果を含めてユーザーに表示します。

この情報の流れにより、MCPはモデルと外部ツール・データソースをシームレスに接続し、高度で対話的かつコンテキスト対応のAIアプリケーションをサポートします。

## プロトコルの詳細

MCP（Model Context Protocol）は[JSON-RPC 2.0](https://www.jsonrpc.org/)を基盤に構築されており、Hosts、Clients、Servers間の通信に標準化され言語非依存のメッセージフォーマットを提供します。この基盤により、多様なプラットフォームやプログラミング言語間で信頼性が高く構造化された拡張可能なインタラクションが可能です。

### 主なプロトコル機能

MCPはJSON-RPC 2.0に加え、ツール呼び出し、リソースアクセス、プロンプト管理のための追加規約を拡張しています。複数のトランスポート層（STDIO、WebSocket、SSE）をサポートし、安全で拡張性があり言語非依存の通信を実現します。

#### 🧢 ベースプロトコル

- **JSON-RPCメッセージフォーマット**：すべてのリクエストとレスポンスはJSON-RPC 2.0仕様に準拠し、メソッド呼び出し、パラメーター、結果、エラー処理の一貫した構造を保証。
- **ステートフル接続**：MCPセッションは複数リクエストにわたり状態を維持し、継続的な会話、コンテキストの蓄積、リソース管理をサポート。
- **機能交渉**：接続設定時にクライアントとサーバーが対応可能な機能、プロトコルバージョン、利用可能なツールやリソースを交換し、双方の能力を理解し適応。

#### ➕ 追加ユーティリティ

MCPが提供する開発者体験向上や高度なシナリオ対応のための追加機能：

- **構成オプション**：ツール権限、リソースアクセス、モデル設定などのセッションパラメーターを動的に設定可能。
- **進捗追跡**：長時間かかる処理の進捗更新を報告し、応答性の高いユーザーインターフェースを実現。
- **リクエストキャンセル**：クライアントは進行中のリクエストをキャンセルでき、不要または時間のかかりすぎる操作を中断可能。
- **エラー報告**：標準化されたエラーメッセージとコードにより問題の診断、障害の適切な処理、ユーザーや開発者への実用的なフィードバックを提供。
- **ログ記録**：クライアントとサーバーの双方が構造化ログを出力し、監査、デバッグ、プロトコルインタラクションの監視に活用。

これらのプロトコル機能を活用することで、MCPは言語モデルと外部ツールやデータソース間の堅牢で安全かつ柔軟な通信を実現します。

### 🔐 セキュリティ考慮事項

MCPの実装は、安全で信頼性のあるインタラクションを確保するために以下の主要なセキュリティ原則に従うべきです：

- **ユーザーの同意とコントロール**：データアクセスや操作の前にユーザーの明示的な同意が必要です。ユーザーは共有データや許可されたアクションを明確に管理でき、直感的なUIで活動の確認と承認が可能であるべきです。

- **データプライバシー**：ユーザーデータは明示的な同意がある場合のみ開示され、適切なアクセス制御で保護される必要があります。MCP実装は不正なデータ送信を防ぎ、すべてのやり取りでプライバシーを維持します。

- **ツールの安全性**：ツール呼び出し前には必ずユーザーの明示的同意を得る必要があります。ユーザーは各ツールの機能を明確に理解し、不意のまたは危険なツール実行を防ぐために堅牢なセキュリティ境界が適用されなければなりません。

これらの原則を遵守することで、MCPはすべてのプロトコルインタラクションにおいてユーザーの信頼、プライバシー、安全性を維持します。

## コード例：主要コンポーネント

以下は、主要なMCPサーバーコンポーネントとツールの実装例を示す、いくつかの主要プログラミング言語でのコード例です。

### .NET例：シンプルなMCPサーバーとツールの作成

以下は、カスタムツールを備えたシンプルなMCPサーバーを実装する実践的な.NETコード例です。ツールの定義と登録、リクエストの処理、Model Context Protocolを使ったサーバー接続方法を示します。

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

この例は、上記の.NET例と同じMCPサーバーとツール登録をJavaで実装したものです。

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

### Python例：MCPサーバーの構築

この例では、PythonでMCPサーバーを構築する方法を示します。ツールの作成方法を2通り紹介しています。

@@CODE_BLOCK_

**免責事項**:  
本書類はAI翻訳サービス[Co-op Translator](https://github.com/Azure/co-op-translator)を使用して翻訳されています。正確性の確保に努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があることをご承知おきください。原文（原言語版）が正式な情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じたいかなる誤解や誤訳についても、一切の責任を負いかねます。