<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-07-14T04:15:32+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "ja"
}
-->
# 先行導入者からの教訓

## 概要

このレッスンでは、先行導入者がModel Context Protocol（MCP）を活用して実際の課題を解決し、さまざまな業界でイノベーションを推進してきた事例を探ります。詳細なケーススタディや実践的なプロジェクトを通じて、MCPがどのように標準化され、安全かつスケーラブルなAI統合を実現し、大規模言語モデル、ツール、企業データを統一されたフレームワークでつなげているかを理解できます。MCPベースのソリューションの設計・構築を実践的に学び、実績のある実装パターンから学び、運用環境でのMCP展開におけるベストプラクティスを発見します。また、新たなトレンドや将来の方向性、オープンソースリソースも紹介し、MCP技術とその進化するエコシステムの最前線に立つための知識を提供します。

## 学習目標

- さまざまな業界における実際のMCP実装を分析する
- 完全なMCPベースのアプリケーションを設計・構築する
- MCP技術の新興トレンドと将来の方向性を探る
- 実際の開発シナリオでベストプラクティスを適用する

## 実際のMCP実装事例

### ケーススタディ1：企業向けカスタマーサポート自動化

多国籍企業がMCPベースのソリューションを導入し、カスタマーサポートシステム全体でAIとのやり取りを標準化しました。これにより以下を実現しました：

- 複数のLLMプロバイダーに対する統一インターフェースの構築
- 部門間で一貫したプロンプト管理の維持
- 強固なセキュリティとコンプライアンス管理の実装
- 特定のニーズに応じたAIモデルの簡単な切り替え

**技術的実装：**  
```python
# Python MCP server implementation for customer support
import logging
import asyncio
from modelcontextprotocol import create_server, ServerConfig
from modelcontextprotocol.server import MCPServer
from modelcontextprotocol.transports import create_http_transport
from modelcontextprotocol.resources import ResourceDefinition
from modelcontextprotocol.prompts import PromptDefinition
from modelcontextprotocol.tool import ToolDefinition

# Configure logging
logging.basicConfig(level=logging.INFO)

async def main():
    # Create server configuration
    config = ServerConfig(
        name="Enterprise Customer Support Server",
        version="1.0.0",
        description="MCP server for handling customer support inquiries"
    )
    
    # Initialize MCP server
    server = create_server(config)
    
    # Register knowledge base resources
    server.resources.register(
        ResourceDefinition(
            name="customer_kb",
            description="Customer knowledge base documentation"
        ),
        lambda params: get_customer_documentation(params)
    )
    
    # Register prompt templates
    server.prompts.register(
        PromptDefinition(
            name="support_template",
            description="Templates for customer support responses"
        ),
        lambda params: get_support_templates(params)
    )
    
    # Register support tools
    server.tools.register(
        ToolDefinition(
            name="ticketing",
            description="Create and update support tickets"
        ),
        handle_ticketing_operations
    )
    
    # Start server with HTTP transport
    transport = create_http_transport(port=8080)
    await server.run(transport)

if __name__ == "__main__":
    asyncio.run(main())
```

**結果：** モデルコストが30%削減、応答の一貫性が45%向上し、グローバルな運用でのコンプライアンスも強化されました。

### ケーススタディ2：医療診断アシスタント

医療機関がMCPインフラを構築し、複数の専門的な医療AIモデルを統合しつつ、患者の機微なデータを保護しました：

- 一般医療モデルと専門医療モデルのシームレスな切り替え
- 厳格なプライバシー管理と監査ログの保持
- 既存の電子カルテ（EHR）システムとの統合
- 医療用語に対応した一貫したプロンプト設計

**技術的実装：**  
```csharp
// C# MCP host application implementation in healthcare application
using Microsoft.Extensions.DependencyInjection;
using ModelContextProtocol.SDK.Client;
using ModelContextProtocol.SDK.Security;
using ModelContextProtocol.SDK.Resources;

public class DiagnosticAssistant
{
    private readonly MCPHostClient _mcpClient;
    private readonly PatientContext _patientContext;
    
    public DiagnosticAssistant(PatientContext patientContext)
    {
        _patientContext = patientContext;
        
        // Configure MCP client with healthcare-specific settings
        var clientOptions = new ClientOptions
        {
            Name = "Healthcare Diagnostic Assistant",
            Version = "1.0.0",
            Security = new SecurityOptions
            {
                Encryption = EncryptionLevel.Medical,
                AuditEnabled = true
            }
        };
        
        _mcpClient = new MCPHostClientBuilder()
            .WithOptions(clientOptions)
            .WithTransport(new HttpTransport("https://healthcare-mcp.example.org"))
            .WithAuthentication(new HIPAACompliantAuthProvider())
            .Build();
    }
    
    public async Task<DiagnosticSuggestion> GetDiagnosticAssistance(
        string symptoms, string patientHistory)
    {
        // Create request with appropriate resources and tool access
        var resourceRequest = new ResourceRequest
        {
            Name = "patient_records",
            Parameters = new Dictionary<string, object>
            {
                ["patientId"] = _patientContext.PatientId,
                ["requestingProvider"] = _patientContext.ProviderId
            }
        };
        
        // Request diagnostic assistance using appropriate prompt
        var response = await _mcpClient.SendPromptRequestAsync(
            promptName: "diagnostic_assistance",
            parameters: new Dictionary<string, object>
            {
                ["symptoms"] = symptoms,
                patientHistory = patientHistory,
                relevantGuidelines = _patientContext.GetRelevantGuidelines()
            });
            
        return DiagnosticSuggestion.FromMCPResponse(response);
    }
}
```

**結果：** 医師への診断支援が向上し、HIPAA完全準拠を維持しつつ、システム間のコンテキスト切り替えが大幅に削減されました。

### ケーススタディ3：金融サービスのリスク分析

金融機関がMCPを導入し、部門横断でリスク分析プロセスを標準化しました：

- 信用リスク、詐欺検出、投資リスクモデルに対する統一インターフェースの構築
- 厳格なアクセス制御とモデルのバージョン管理の実装
- すべてのAI推奨の監査可能性の確保
- 多様なシステム間での一貫したデータフォーマットの維持

**技術的実装：**  
```java
// Java MCP server for financial risk assessment
import org.mcp.server.*;
import org.mcp.security.*;

public class FinancialRiskMCPServer {
    public static void main(String[] args) {
        // Create MCP server with financial compliance features
        MCPServer server = new MCPServerBuilder()
            .withModelProviders(
                new ModelProvider("risk-assessment-primary", new AzureOpenAIProvider()),
                new ModelProvider("risk-assessment-audit", new LocalLlamaProvider())
            )
            .withPromptTemplateDirectory("./compliance/templates")
            .withAccessControls(new SOCCompliantAccessControl())
            .withDataEncryption(EncryptionStandard.FINANCIAL_GRADE)
            .withVersionControl(true)
            .withAuditLogging(new DatabaseAuditLogger())
            .build();
            
        server.addRequestValidator(new FinancialDataValidator());
        server.addResponseFilter(new PII_RedactionFilter());
        
        server.start(9000);
        
        System.out.println("Financial Risk MCP Server running on port 9000");
    }
}
```

**結果：** 規制遵守が強化され、モデル展開サイクルが40%高速化し、部門間でのリスク評価の一貫性が向上しました。

### ケーススタディ4：Microsoft Playwright MCPサーバーによるブラウザ自動化

Microsoftは[Playwright MCPサーバー](https://github.com/microsoft/playwright-mcp)を開発し、Model Context Protocolを通じて安全かつ標準化されたブラウザ自動化を実現しました。このソリューションにより、AIエージェントやLLMが制御可能で監査可能、拡張性のある方法でウェブブラウザと連携でき、自動化テスト、データ抽出、エンドツーエンドのワークフローなどのユースケースを可能にします。

- ブラウザ自動化機能（ナビゲーション、フォーム入力、スクリーンショット取得など）をMCPツールとして公開
- 不正操作を防ぐ厳格なアクセス制御とサンドボックス化を実装
- すべてのブラウザ操作に対する詳細な監査ログを提供
- Azure OpenAIや他のLLMプロバイダーとの統合をサポートし、エージェント駆動の自動化を実現

**技術的実装：**  
```typescript
// TypeScript: Registering Playwright browser automation tools in an MCP server
import { createServer, ToolDefinition } from 'modelcontextprotocol';
import { launch } from 'playwright';

const server = createServer({
  name: 'Playwright MCP Server',
  version: '1.0.0',
  description: 'MCP server for browser automation using Playwright'
});

// Register a tool for navigating to a URL and capturing a screenshot
server.tools.register(
  new ToolDefinition({
    name: 'navigate_and_screenshot',
    description: 'Navigate to a URL and capture a screenshot',
    parameters: {
      url: { type: 'string', description: 'The URL to visit' }
    }
  }),
  async ({ url }) => {
    const browser = await launch();
    const page = await browser.newPage();
    await page.goto(url);
    const screenshot = await page.screenshot();
    await browser.close();
    return { screenshot };
  }
);

// Start the MCP server
server.listen(8080);
```

**結果：**  
- AIエージェントとLLMによる安全なプログラム的ブラウザ自動化を実現  
- 手動テスト工数の削減とウェブアプリケーションのテストカバレッジ向上  
- 企業環境でのブラウザベースツール統合のための再利用可能で拡張性の高いフレームワークを提供

**参考資料：**  
- [Playwright MCP Server GitHubリポジトリ](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AIおよび自動化ソリューション](https://azure.microsoft.com/en-us/products/ai-services/)

### ケーススタディ5：Azure MCP – エンタープライズグレードのModel Context Protocol as a Service

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) は、Microsoftが提供する管理されたエンタープライズグレードのModel Context Protocol実装で、スケーラブルで安全かつコンプライアンス対応のMCPサーバー機能をクラウドサービスとして提供します。Azure MCPにより、組織はMCPサーバーを迅速に展開・管理し、Azure AI、データ、セキュリティサービスと統合することで運用負荷を軽減し、AI導入を加速できます。

- スケーリング、監視、セキュリティを備えたフルマネージドのMCPサーバーホスティング
- Azure OpenAI、Azure AI Search、その他Azureサービスとのネイティブ統合
- Microsoft Entra IDによるエンタープライズ認証・認可
- カスタムツール、プロンプトテンプレート、リソースコネクターのサポート
- エンタープライズのセキュリティおよび規制要件への準拠

**技術的実装：**  
```yaml
# Example: Azure MCP server deployment configuration (YAML)
apiVersion: mcp.microsoft.com/v1
kind: McpServer
metadata:
  name: enterprise-mcp-server
spec:
  modelProviders:
    - name: azure-openai
      type: AzureOpenAI
      endpoint: https://<your-openai-resource>.openai.azure.com/
      apiKeySecret: <your-azure-keyvault-secret>
  tools:
    - name: document_search
      type: AzureAISearch
      endpoint: https://<your-search-resource>.search.windows.net/
      apiKeySecret: <your-azure-keyvault-secret>
  authentication:
    type: EntraID
    tenantId: <your-tenant-id>
  monitoring:
    enabled: true
    logAnalyticsWorkspace: <your-log-analytics-id>
```

**結果：**  
- すぐに使えるコンプライアントなMCPサーバープラットフォームにより、企業のAIプロジェクトの価値創出までの時間を短縮  
- LLM、ツール、企業データソースの統合を簡素化  
- MCPワークロードのセキュリティ、可観測性、運用効率を向上

**参考資料：**  
- [Azure MCPドキュメント](https://aka.ms/azmcp)  
- [Azure AIサービス](https://azure.microsoft.com/en-us/products/ai-services/)

## ケーススタディ6：NLWeb

MCP（Model Context Protocol）は、チャットボットやAIアシスタントがツールと連携するための新しいプロトコルです。すべてのNLWebインスタンスはMCPサーバーでもあり、自然言語でウェブサイトに質問するためのコアメソッドaskをサポートしています。返される応答は、ウェブデータ記述に広く使われるschema.orgを活用しています。ざっくり言えば、MCPはHttpがHTMLに対するようにNLWebに対するものです。NLWebはプロトコル、Schema.orgフォーマット、サンプルコードを組み合わせ、サイトが迅速にこれらのエンドポイントを作成できるよう支援し、人間には会話型インターフェースを、機械には自然なエージェント間のやり取りを提供します。

NLWebには2つの主要なコンポーネントがあります。  
- 非常にシンプルなプロトコルで、自然言語でサイトとやり取りし、jsonとschema.orgを活用したフォーマットで回答を返します。REST APIのドキュメントを参照してください。  
- (1)のシンプルな実装で、商品、レシピ、観光地、レビューなどのリストとして抽象化可能なサイト向け。ユーザーインターフェースウィジェットと組み合わせて、サイトが簡単に会話型インターフェースを提供できます。チャットクエリのライフサイクルに関するドキュメントもご覧ください。

**参考資料：**  
- [Azure MCPドキュメント](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### ケーススタディ7：Foundry向けMCP – Azure AIエージェントの統合

Azure AI Foundry MCPサーバーは、MCPを使って企業環境でAIエージェントやワークフローをオーケストレーション・管理する方法を示しています。MCPとAzure AI Foundryを統合することで、エージェント間のやり取りを標準化し、Foundryのワークフロー管理を活用し、安全でスケーラブルな展開を実現します。このアプローチにより、迅速なプロトタイピング、堅牢なモニタリング、Azure AIサービスとのシームレスな統合が可能となり、知識管理やエージェント評価などの高度なシナリオをサポートします。開発者はエージェントパイプラインの構築・展開・監視を統一インターフェースで行え、ITチームはセキュリティ、コンプライアンス、運用効率の向上を享受できます。複雑なエージェント駆動プロセスの管理とAI導入の加速を目指す企業に最適なソリューションです。

**参考資料：**  
- [MCP Foundry GitHubリポジトリ](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Azure AIエージェントとMCPの統合（Microsoft Foundryブログ）](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### ケーススタディ8：Foundry MCP Playground – 実験とプロトタイピング

Foundry MCP Playgroundは、MCPサーバーとAzure AI Foundry統合の実験環境をすぐに利用できる形で提供します。開発者はAzure AI Foundryカタログやラボのリソースを使って、AIモデルやエージェントワークフローのプロトタイピング、テスト、評価を迅速に行えます。セットアップが簡単で、サンプルプロジェクトを提供し、共同開発をサポートするため、複雑なインフラなしでベストプラクティスや新しいシナリオを気軽に試せます。アイデアの検証、実験の共有、学習の加速を目指すチームに特に有用で、MCPとAzure AI Foundryのエコシステムにおけるイノベーションとコミュニティ貢献を促進します。

**参考資料：**  
- [Foundry MCP Playground GitHubリポジトリ](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### ケーススタディ9：Microsoft Docs MCPサーバー – 学習とスキリング

Microsoft Docs MCPサーバーは、Model Context Protocol（MCP）サーバーを実装し、AIアシスタントにMicrosoft公式ドキュメントへのリアルタイムアクセスを提供します。Microsoft公式の技術ドキュメントに対するセマンティック検索を実行します。

**参考資料：**  
- [Microsoft Learn Docs MCPサーバー](https://github.com/MicrosoftDocs/mcp)

## ハンズオンプロジェクト

### プロジェクト1：マルチプロバイダーMCPサーバーの構築

**目的：** 特定の条件に基づいて複数のAIモデルプロバイダーにリクエストをルーティングできるMCPサーバーを作成する。

**要件：**  
- 少なくとも3つの異なるモデルプロバイダー（例：OpenAI、Anthropic、ローカルモデル）をサポート  
- リクエストのメタデータに基づくルーティング機構の実装  
- プロバイダー認証情報を管理する設定システムの作成  
- パフォーマンスとコスト最適化のためのキャッシュ機能の追加  
- 使用状況を監視するシンプルなダッシュボードの構築

**実装手順：**  
1. 基本的なMCPサーバーインフラのセットアップ  
2. 各AIモデルサービス向けのプロバイダーアダプターの実装  
3. リクエスト属性に基づくルーティングロジックの作成  
4. 頻繁なリクエスト向けのキャッシュ機構の追加  
5. 監視ダッシュボードの開発  
6. さまざまなリクエストパターンでのテスト

**技術スタック：** Python（.NET/Java/Pythonはお好みで）、Redisによるキャッシュ、ダッシュボード用のシンプルなウェブフレームワーク

### プロジェクト2：企業向けプロンプト管理システム

**目的：** 組織全体でプロンプトテンプレートの管理、バージョン管理、展開を行うMCPベースのシステムを開発する。

**要件：**  
- プロンプトテンプレートの集中リポジトリの作成  
- バージョン管理と承認ワークフローの実装  
- サンプル入力によるテンプレートテスト機能の構築  
- 役割ベースのアクセス制御の開発  
- テンプレート取得・展開用APIの作成

**実装手順：**  
1. テンプレート保存用のデータベーススキーマ設計  
2. テンプレートのCRUD操作用コアAPIの作成  
3. バージョン管理システムの実装  
4. 承認ワークフローの構築  
5. テストフレームワークの開発  
6. 管理用のシンプルなウェブインターフェース作成  
7. MCPサーバーとの統合

**技術スタック：** お好みのバックエンドフレームワーク、SQLまたはNoSQLデータベース、管理インターフェース用のフロントエンドフレームワーク

### プロジェクト3：MCPベースのコンテンツ生成プラットフォーム

**目的：** MCPを活用し、異なるコンテンツタイプで一貫した結果を提供するコンテンツ生成プラットフォームを構築する。

**要件：**  
- 複数のコンテンツフォーマット（ブログ記事、ソーシャルメディア、マーケティングコピー）をサポート  
- カスタマイズ可能なテンプレートベースの生成機能の実装  
- コンテンツレビューとフィードバックシステムの構築  
- コンテンツパフォーマンス指標の追跡  
- コンテンツのバージョン管理と反復対応

**実装手順：**  
1. MCPクライアントインフラのセットアップ  
2. 各コンテンツタイプ用テンプレートの作成  
3. コンテンツ生成パイプラインの構築  
4. レビューシステムの実装  
5. 指標追跡システムの開発  
6. テンプレート管理とコンテンツ生成用のユーザーインターフェース作成

**技術スタック：** お好みのプログラミング言語、ウェブフレームワーク、データベースシステム

## MCP技術の将来展望

### 新興トレンド

1. **マルチモーダルMCP**  
   - 画像、音声、動画モデルとのやり取りを標準化するMCPの拡張  
   - クロスモーダル推論機能の開発  
   - 各モダリティに対応した標準化されたプロンプトフォーマット

2. **フェデレ
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Azure FunctionsでのRemote MCP Server実装のランディングページで、言語別リポジトリへのリンクを含む  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Pythonを使ったAzure FunctionsでのカスタムRemote MCPサーバー構築とデプロイのクイックスタートテンプレート  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - .NET/C#を使ったAzure FunctionsでのカスタムRemote MCPサーバー構築とデプロイのクイックスタートテンプレート  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - TypeScriptを使ったAzure FunctionsでのカスタムRemote MCPサーバー構築とデプロイのクイックスタートテンプレート  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Pythonを使ったAzure API ManagementによるRemote MCPサーバーへのAIゲートウェイ  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - MCP機能を含むAPIM ❤️ AI実験で、Azure OpenAIやAI Foundryとの統合  

これらのリポジトリは、Model Context Protocolをさまざまなプログラミング言語やAzureサービスで扱うための実装例、テンプレート、リソースを提供しています。基本的なサーバー実装から認証、クラウド展開、エンタープライズ統合シナリオまで幅広いユースケースをカバーしています。

#### MCPリソースディレクトリ

公式Microsoft MCPリポジトリの[MCP Resourcesディレクトリ](https://github.com/microsoft/mcp/tree/main/Resources)は、Model Context Protocolサーバーで使えるサンプルリソース、プロンプトテンプレート、ツール定義の厳選コレクションを提供しています。このディレクトリは、再利用可能なビルディングブロックやベストプラクティスの例を通じて、開発者がMCPを素早く始められるよう設計されています。

- **プロンプトテンプレート:** 一般的なAIタスクやシナリオ向けの使いやすいプロンプトテンプレートで、自身のMCPサーバー実装に応用可能です。  
- **ツール定義:** ツールの統合や呼び出しを標準化するための例示的なツールスキーマやメタデータ。  
- **リソースサンプル:** MCPフレームワーク内でデータソース、API、外部サービスに接続するためのリソース定義例。  
- **リファレンス実装:** 実際のMCPプロジェクトでリソース、プロンプト、ツールをどのように構成・整理するかを示す実践的なサンプル。  

これらのリソースは開発を加速し、標準化を促進し、MCPベースのソリューション構築と展開におけるベストプラクティスの遵守を支援します。

#### MCPリソースディレクトリ
- [MCP Resources（サンプルプロンプト、ツール、リソース定義）](https://github.com/microsoft/mcp/tree/main/Resources)

### 研究の機会

- MCPフレームワーク内での効率的なプロンプト最適化技術  
- マルチテナントMCP展開のためのセキュリティモデル  
- 異なるMCP実装間のパフォーマンスベンチマーク  
- MCPサーバーの形式的検証手法  

## 結論

Model Context Protocol（MCP）は、業界全体で標準化され、安全かつ相互運用可能なAI統合の未来を急速に形作っています。このレッスンのケーススタディや実践プロジェクトを通じて、MicrosoftやAzureをはじめとする初期導入者が、MCPを活用して実際の課題を解決し、AIの導入を加速し、コンプライアンス、セキュリティ、スケーラビリティを確保している様子を見てきました。MCPのモジュラーアプローチにより、組織は大規模言語モデル、ツール、エンタープライズデータを統一された監査可能なフレームワークで接続できます。MCPが進化し続ける中、コミュニティとの関わりを持ち、オープンソースリソースを探求し、ベストプラクティスを適用することが、堅牢で将来に備えたAIソリューション構築の鍵となります。

## 追加リソース

- [MCP Foundry GitHubリポジトリ](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Foundry MCP Playground](https://github.com/azure-ai-foundry/foundry-mcp-playground)  
- [Azure AIエージェントとMCPの統合（Microsoft Foundryブログ）](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)  
- [MCP GitHubリポジトリ（Microsoft）](https://github.com/microsoft/mcp)  
- [MCP Resourcesディレクトリ（サンプルプロンプト、ツール、リソース定義）](https://github.com/microsoft/mcp/tree/main/Resources)  
- [MCPコミュニティ＆ドキュメント](https://modelcontextprotocol.io/introduction)  
- [Azure MCPドキュメント](https://aka.ms/azmcp)  
- [Playwright MCP Server GitHubリポジトリ](https://github.com/microsoft/playwright-mcp)  
- [Files MCP Server（OneDrive）](https://github.com/microsoft/files-mcp-server)  
- [Azure-Samples MCP](https://github.com/Azure-Samples/mcp)  
- [MCP Auth Servers（Azure-Samples）](https://github.com/Azure-Samples/mcp-auth-servers)  
- [Remote MCP Functions（Azure-Samples）](https://github.com/Azure-Samples/remote-mcp-functions)  
- [Remote MCP Functions Python（Azure-Samples）](https://github.com/Azure-Samples/remote-mcp-functions-python)  
- [Remote MCP Functions .NET（Azure-Samples）](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)  
- [Remote MCP Functions TypeScript（Azure-Samples）](https://github.com/Azure-Samples/remote-mcp-functions-typescript)  
- [Remote MCP APIM Functions Python（Azure-Samples）](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)  
- [AI-Gateway（Azure-Samples）](https://github.com/Azure-Samples/AI-Gateway)  
- [Microsoft AIおよび自動化ソリューション](https://azure.microsoft.com/en-us/products/ai-services/)

## 演習

1. ケーススタディの一つを分析し、代替の実装アプローチを提案してください。  
2. プロジェクトアイデアの一つを選び、詳細な技術仕様を作成してください。  
3. ケーススタディで扱われていない業界を調査し、その業界特有の課題にMCPがどのように対応できるかを概説してください。  
4. 将来の方向性の一つを探求し、それをサポートする新しいMCP拡張のコンセプトを作成してください。  

次へ: [Best Practices](../08-BestPractices/README.md)

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性を期しておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語による文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じた誤解や誤訳について、当方は一切の責任を負いかねます。