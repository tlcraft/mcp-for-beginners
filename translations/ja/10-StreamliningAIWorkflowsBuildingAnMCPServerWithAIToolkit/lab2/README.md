<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a22b7dd11cd7690f99f9195877cafdc3",
  "translation_date": "2025-06-10T05:40:48+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab2/README.md",
  "language_code": "ja"
}
-->
# 🌐 モジュール 2: AI Toolkit 基礎を用いた MCP

[![Duration](https://img.shields.io/badge/Duration-20%20minutes-blue.svg)]()
[![Difficulty](https://img.shields.io/badge/Difficulty-Intermediate-yellow.svg)]()
[![Prerequisites](https://img.shields.io/badge/Prerequisites-Module%201%20Complete-orange.svg)]()

## 📋 学習目標

このモジュールの終了時には、以下ができるようになります：
- ✅ Model Context Protocol (MCP) のアーキテクチャと利点を理解する
- ✅ Microsoft の MCP サーバーエコシステムを探索する
- ✅ MCP サーバーを AI Toolkit Agent Builder と統合する
- ✅ Playwright MCP を使った実用的なブラウザ自動化エージェントを構築する
- ✅ エージェント内で MCP ツールを設定およびテストする
- ✅ MCP 搭載エージェントをエクスポートし、本番環境へ展開する

## 🎯 モジュール 1 の内容を踏まえて

モジュール 1 では AI Toolkit の基本を習得し、最初の Python エージェントを作成しました。ここからは、画期的な **Model Context Protocol (MCP)** を通じて、エージェントを外部ツールやサービスに接続し、**大幅に強化**していきます。

これは、単なる電卓から本格的なコンピューターへアップグレードするようなものです。あなたの AI エージェントは以下のことができるようになります：
- 🌐 ウェブサイトの閲覧や操作
- 📁 ファイルへのアクセスと操作
- 🔧 エンタープライズシステムとの連携
- 📊 API からのリアルタイムデータ処理

## 🧠 Model Context Protocol (MCP) の理解

### 🔍 MCP とは？

Model Context Protocol (MCP) は AI アプリケーション向けの **「USB-C」** とも言える革命的なオープンスタンダードです。大規模言語モデル（LLM）を外部ツールやデータソース、サービスに接続します。USB-C がケーブルの混乱を解消し一つのコネクタに統一したように、MCP は AI の統合の複雑さを一つの標準化されたプロトコルで解決します。

### 🎯 MCP が解決する課題

**MCP 導入前：**
- 🔧 ツールごとにカスタム統合が必要
- 🔄 ベンダーロックインによる独自ソリューション
- 🔒 臨時的な接続によるセキュリティリスク
- ⏱️ 基本的な統合でも数か月の開発期間

**MCP 導入後：**
- ⚡ プラグアンドプレイのツール統合
- 🔄 ベンダー非依存のアーキテクチャ
- 🛡️ セキュリティのベストプラクティスを組み込み
- 🚀 新機能追加が数分で完了

### 🏗️ MCP アーキテクチャの詳細

MCP は **クライアント・サーバーアーキテクチャ** を採用し、安全でスケーラブルなエコシステムを実現しています：

```mermaid
graph TB
    A[AI Application/Agent] --> B[MCP Client]
    B --> C[MCP Server 1: Files]
    B --> D[MCP Server 2: Web APIs]
    B --> E[MCP Server 3: Database]
    B --> F[MCP Server N: Custom Tools]
    
    C --> G[Local File System]
    D --> H[External APIs]
    E --> I[Database Systems]
    F --> J[Enterprise Systems]
```

**🔧 コアコンポーネント:**

| コンポーネント | 役割 | 例 |
|-----------|------|----------|
| **MCP Hosts** | MCP サービスを利用するアプリケーション | Claude Desktop、VS Code、AI Toolkit |
| **MCP Clients** | プロトコルハンドラー（サーバーと1対1） | ホストアプリに組み込み |
| **MCP Servers** | 標準プロトコルで機能を提供 | Playwright、Files、Azure、GitHub |
| **Transport Layer** | 通信手段 | stdio、HTTP、WebSockets |


## 🏢 Microsoft の MCP サーバーエコシステム

Microsoft は実ビジネスのニーズに応える企業向けの MCP サーバー群でエコシステムをリードしています。

### 🌟 Microsoft の注目 MCP サーバー

#### 1. ☁️ Azure MCP Server
**🔗 リポジトリ**: [azure/azure-mcp](https://github.com/azure/azure-mcp)  
**🎯 目的**: AI 統合を備えた包括的な Azure リソース管理

**✨ 主な機能:**
- 宣言型インフラ構築
- リアルタイムリソース監視
- コスト最適化の提案
- セキュリティコンプライアンスチェック

**🚀 利用例:**
- AI 支援による Infrastructure-as-Code
- 自動リソーススケーリング
- クラウドコストの最適化
- DevOps ワークフローの自動化

#### 2. 📊 Microsoft Dataverse MCP
**📚 ドキュメント**: [Microsoft Dataverse Integration](https://go.microsoft.com/fwlink/?linkid=2320176)  
**🎯 目的**: ビジネスデータの自然言語インターフェース

**✨ 主な機能:**
- 自然言語によるデータベースクエリ
- ビジネスコンテキストの理解
- カスタムプロンプトテンプレート
- エンタープライズデータガバナンス

**🚀 利用例:**
- ビジネスインテリジェンスレポート
- 顧客データ分析
- セールスパイプラインの洞察
- コンプライアンスデータクエリ

#### 3. 🌐 Playwright MCP Server
**🔗 リポジトリ**: [microsoft/playwright-mcp](https://github.com/microsoft/playwright-mcp)  
**🎯 目的**: ブラウザ自動化とウェブ操作機能

**✨ 主な機能:**
- クロスブラウザ自動化（Chrome、Firefox、Safari）
- インテリジェントな要素検出
- スクリーンショットおよび PDF 生成
- ネットワークトラフィック監視

**🚀 利用例:**
- 自動テストワークフロー
- ウェブスクレイピングとデータ抽出
- UI/UX 監視
- 競合分析の自動化

#### 4. 📁 Files MCP Server
**🔗 リポジトリ**: [microsoft/files-mcp-server](https://github.com/microsoft/files-mcp-server)  
**🎯 目的**: インテリジェントなファイルシステム操作

**✨ 主な機能:**
- 宣言的ファイル管理
- コンテンツ同期
- バージョン管理統合
- メタデータ抽出

**🚀 利用例:**
- ドキュメント管理
- コードリポジトリの整理
- コンテンツ公開ワークフロー
- データパイプラインのファイル処理

#### 5. 📝 MarkItDown MCP Server
**🔗 リポジトリ**: [microsoft/markitdown](https://github.com/microsoft/markitdown)  
**🎯 目的**: 高度な Markdown 処理と操作

**✨ 主な機能:**
- 高度な Markdown パース
- フォーマット変換 (MD ↔ HTML ↔ PDF)
- コンテンツ構造解析
- テンプレート処理

**🚀 利用例:**
- 技術文書のワークフロー
- コンテンツ管理システム
- レポート生成
- ナレッジベースの自動化

#### 6. 📈 Clarity MCP Server
**📦 パッケージ**: [@microsoft/clarity-mcp-server](https://www.npmjs.com/package/@microsoft/clarity-mcp-server)  
**🎯 目的**: ウェブ解析とユーザー行動の洞察

**✨ 主な機能:**
- ヒートマップデータ解析
- ユーザーセッション録画
- パフォーマンス指標
- コンバージョンファネル分析

**🚀 利用例:**
- ウェブサイト最適化
- ユーザーエクスペリエンス調査
- A/B テスト解析
- ビジネスインテリジェンスダッシュボード

### 🌍 コミュニティエコシステム

Microsoft のサーバーに加え、MCP エコシステムには以下も含まれます：
- **🐙 GitHub MCP**: リポジトリ管理とコード解析
- **🗄️ データベース MCP**: PostgreSQL、MySQL、MongoDB 統合
- **☁️ クラウドプロバイダー MCP**: AWS、GCP、Digital Ocean ツール
- **📧 コミュニケーション MCP**: Slack、Teams、メール統合

## 🛠️ ハンズオンラボ: ブラウザ自動化エージェントの構築

**🎯 プロジェクト目標**: Playwright MCP サーバーを使い、ウェブサイトのナビゲーション、情報抽出、複雑なウェブ操作を行うインテリジェントなブラウザ自動化エージェントを作成する。

### 🚀 フェーズ 1: エージェント基盤セットアップ

#### ステップ 1: エージェントの初期化
1. **AI Toolkit Agent Builder を開く**
2. **新規エージェント作成** し、以下の設定を行う：
   - **名前**: `BrowserAgent`
   - **Model**: Choose GPT-4o 

![BrowserAgent](../../../../translated_images/BrowserAgent.09c1adde5e136573b64ab1baecd830049830e295eac66cb18bebb85fb386e00a.ja.png)


### 🔧 Phase 2: MCP Integration Workflow

#### Step 3: Add MCP Server Integration
1. **Navigate to Tools Section** in Agent Builder
2. **Click "Add Tool"** to open the integration menu
3. **Select "MCP Server"** from available options

![AddMCP](../../../../translated_images/AddMCP.afe3308ac20aa94469a5717b632d77b2197b9838a438b05d39aeb2db3ec47ef1.ja.png)

**🔍 Understanding Tool Types:**
- **Built-in Tools**: Pre-configured AI Toolkit functions
- **MCP Servers**: External service integrations
- **Custom APIs**: Your own service endpoints
- **Function Calling**: Direct model function access

#### Step 4: MCP Server Selection
1. **Choose "MCP Server"** option to proceed
![AddMCPServer](../../../../translated_images/AddMCPServer.69b911ccef872cbd0d0c0c2e6a00806916e1673e543b902a23dee23e6ff54b4c.ja.png)

2. **Browse MCP Catalog** to explore available integrations
![MCPCatalog](../../../../translated_images/MCPCatalog.a817d053145699006264f5a475f2b48fbd744e43633f656b6453c15a09ba5130.ja.png)


### 🎮 Phase 3: Playwright MCP Configuration

#### Step 5: Select and Configure Playwright
1. **Click "Use Featured MCP Servers"** to access Microsoft's verified servers
2. **Select "Playwright"** from the featured list
3. **Accept Default MCP ID** or customize for your environment

![MCPID](../../../../translated_images/MCPID.67d446052979e819c945ff7b6430196ef587f5217daadd3ca52fa9659c1245c9.ja.png)

#### Step 6: Enable Playwright Capabilities
**🔑 Critical Step**: Select **ALL** available Playwright methods for maximum functionality

![Tools](../../../../translated_images/Tools.3ea23c447b4d9feccbd7101e6dcf9e27cb0e5273f351995fde62c5abf9a78b4c.ja.png)

**🛠️ Essential Playwright Tools:**
- **Navigation**: `goto`, `goBack`, `goForward`, `reload`
- **Interaction**: `click`, `fill`, `press`, `hover`, `drag`
- **Extraction**: `textContent`, `innerHTML`, `getAttribute`
- **Validation**: `isVisible`, `isEnabled`, `waitForSelector`
- **Capture**: `screenshot`, `pdf`, `video`
- **Network**: `setExtraHTTPHeaders`, `route`, `waitForResponse`

#### ステップ 7: 統合成功の確認
**✅ 成功の目安:**
- すべてのツールが Agent Builder のインターフェースに表示される
- 統合パネルにエラーメッセージがない
- Playwright サーバーのステータスが「Connected」と表示される

![AgentTools](../../../../translated_images/AgentTools.053cfb96a17e02199dcc6563010d2b324d4fc3ebdd24889657a6950647a52f63.ja.png)

**🔧 よくある問題の対処法:**
- **接続失敗**: インターネット接続やファイアウォール設定を確認
- **ツールが表示されない**: 設定時にすべての機能が選択されているか確認
- **権限エラー**: VS Code に必要なシステム権限があるか確認

### 🎯 フェーズ 4: 高度なプロンプト設計

#### ステップ 8: インテリジェントなシステムプロンプトの設計
Playwright の全機能を活用する洗練されたプロンプトを作成する：

```markdown
# Web Automation Expert System Prompt

## Core Identity
You are an advanced web automation specialist with deep expertise in browser automation, web scraping, and user experience analysis. You have access to Playwright tools for comprehensive browser control.

## Capabilities & Approach
### Navigation Strategy
- Always start with screenshots to understand page layout
- Use semantic selectors (text content, labels) when possible
- Implement wait strategies for dynamic content
- Handle single-page applications (SPAs) effectively

### Error Handling
- Retry failed operations with exponential backoff
- Provide clear error descriptions and solutions
- Suggest alternative approaches when primary methods fail
- Always capture diagnostic screenshots on errors

### Data Extraction
- Extract structured data in JSON format when possible
- Provide confidence scores for extracted information
- Validate data completeness and accuracy
- Handle pagination and infinite scroll scenarios

### Reporting
- Include step-by-step execution logs
- Provide before/after screenshots for verification
- Suggest optimizations and alternative approaches
- Document any limitations or edge cases encountered

## Ethical Guidelines
- Respect robots.txt and rate limiting
- Avoid overloading target servers
- Only extract publicly available information
- Follow website terms of service
```

#### ステップ 9: ダイナミックなユーザープロンプトの作成
さまざまな機能を示すプロンプトをデザインする：

**🌐 ウェブ分析の例:**
```markdown
Navigate to github.com/kinfey and provide a comprehensive analysis including:
1. Repository structure and organization
2. Recent activity and contribution patterns  
3. Documentation quality assessment
4. Technology stack identification
5. Community engagement metrics
6. Notable projects and their purposes

Include screenshots at key steps and provide actionable insights.
```

![Prompt](../../../../translated_images/Prompt.bfc846605db4999f4d9c1b09c710ef63cae7b3057444e68bf07240fb142d9f8f.ja.png)

### 🚀 フェーズ 5: 実行とテスト

#### ステップ 10: 最初の自動化を実行
1. **「Run」ボタンをクリック** して自動化シーケンスを開始
2. **リアルタイム実行をモニター**：
   - Chrome ブラウザが自動起動
   - エージェントがターゲットサイトに移動
   - 主要なステップごとにスクリーンショットを取得
   - 分析結果がリアルタイムで表示される

![Browser](../../../../translated_images/Browser.ec011d0bd64d0d112c8a29bd8cc44c76d0bbfd0b019cb2983ef679328435ce5d.ja.png)

#### ステップ 11: 結果と洞察を分析
Agent Builder のインターフェースで詳細な分析結果を確認：

![Result](../../../../translated_images/Result.8638f2b6703e9ea6d58d4e4475e39456b6a51d4c787f9bf481bae694d370a69a.ja.png)

### 🌟 フェーズ 6: 高度な機能と展開

#### ステップ 12: エクスポートと本番展開
Agent Builder は複数の展開オプションをサポート：

![Code](../../../../translated_images/Code.d9eeeead0b96db0ca19c5b10ad64cfea8c1d0d1736584262970a4d43e1403d13.ja.png)

## 🎓 モジュール 2 のまとめと次のステップ

### 🏆 達成したスキル：MCP 統合マスター

**✅ 習得した内容:**
- [ ] MCP のアーキテクチャと利点の理解
- [ ] Microsoft の MCP サーバーエコシステムの把握
- [ ] Playwright MCP と AI Toolkit の統合
- [ ] 高度なブラウザ自動化エージェントの構築
- [ ] ウェブ自動化のための高度なプロンプト設計

### 📚 追加リソース

- **🔗 MCP 仕様**: [公式プロトコルドキュメント](https://modelcontextprotocol.io/)
- **🛠️ Playwright API**: [メソッドリファレンス](https://playwright.dev/docs/api/class-playwright)
- **🏢 Microsoft MCP サーバー**: [企業向け統合ガイド](https://github.com/microsoft/mcp-servers)
- **🌍 コミュニティ事例**: [MCP サーバーギャラリー](https://github.com/modelcontextprotocol/servers)

**🎉 おめでとうございます！** MCP 統合をマスターし、外部ツール対応の本番環境対応 AI エージェントを構築できるようになりました！


### 🔜 次のモジュールへ進む

MCP スキルをさらに高めたいですか？次の **[モジュール 3: AI Toolkit を使った高度な MCP 開発](../lab3/README.md)** では、以下を学びます：
- 独自のカスタム MCP サーバーの作成
- 最新の MCP Python SDK の設定と使用
- MCP Inspector を使ったデバッグ
- 高度な MCP サーバー開発ワークフローの習得
- ゼロからの Weather MCP Server の構築

**免責事項**：  
本書類はAI翻訳サービス[Co-op Translator](https://github.com/Azure/co-op-translator)を使用して翻訳されています。正確性には努めておりますが、自動翻訳には誤りや不正確な箇所が含まれる可能性があることをご了承ください。原文はあくまで正式な情報源としてご参照ください。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じた誤解や誤訳について、当方は一切の責任を負いかねます。