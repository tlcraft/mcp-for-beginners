<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a05fb941810e539147fec53aaadbb6fd",
  "translation_date": "2025-07-14T06:38:02+00:00",
  "source_file": "09-CaseStudy/docs-mcp/solution/python/README.md",
  "language_code": "ja"
}
-->
# Chainlit と Microsoft Learn Docs MCP を使った学習計画ジェネレーター

## 前提条件

- Python 3.8 以上
- pip（Python パッケージマネージャー）
- Microsoft Learn Docs MCP サーバーに接続するためのインターネット接続

## インストール

1. このリポジトリをクローンするか、プロジェクトファイルをダウンロードします。
2. 必要な依存関係をインストールします：

   ```bash
   pip install -r requirements.txt
   ```

## 使い方

### シナリオ 1: Docs MCP へのシンプルなクエリ
Docs MCP サーバーに接続し、クエリを送信して結果を表示するコマンドラインクライアントです。

1. スクリプトを実行します：
   ```bash
   python scenario1.py
   ```
2. プロンプトでドキュメントに関する質問を入力します。

### シナリオ 2: 学習計画ジェネレーター（Chainlit Web アプリ）
Chainlit を使ったウェブインターフェースで、任意の技術トピックに対して週ごとのパーソナライズされた学習計画を作成できます。

1. Chainlit アプリを起動します：
   ```bash
   chainlit run scenario2.py
   ```
2. ターミナルに表示されるローカル URL（例: http://localhost:8000）をブラウザで開きます。
3. チャットウィンドウに学習したいトピックと期間（例：「AI-900 certification, 8 weeks」）を入力します。
4. アプリが週ごとの学習計画を返し、関連する Microsoft Learn のドキュメントへのリンクも表示します。

**必要な環境変数：**

シナリオ 2（Azure OpenAI を使った Chainlit Web アプリ）を利用するには、`python` ディレクトリ内の `.env` ファイルに以下の環境変数を設定してください：

```
AZURE_OPENAI_CHAT_DEPLOYMENT_NAME=
AZURE_OPENAI_API_KEY=
AZURE_OPENAI_ENDPOINT=
AZURE_OPENAI_API_VERSION=
```

アプリを実行する前に、Azure OpenAI リソースの詳細を入力してください。

> **Tip:** [Azure AI Foundry](https://ai.azure.com/) を使えば、自分のモデルを簡単にデプロイできます。

### シナリオ 3: VS Code 内で MCP サーバーを使ったドキュメント参照

ブラウザのタブを切り替える代わりに、Microsoft Learn Docs を VS Code 内に直接取り込めます。これにより以下が可能です：
- VS Code 内でドキュメントを検索・閲覧し、コーディング環境を離れずに作業できる。
- ドキュメントを参照しながら README やコースファイルにリンクを直接挿入できる。
- GitHub Copilot と MCP を組み合わせて、AI を活用したシームレスなドキュメントワークフローを実現。

**利用例：**
- コースやプロジェクトのドキュメント作成中に README に参照リンクを素早く追加。
- Copilot でコードを生成しつつ、MCP で関連ドキュメントを即座に検索・引用。
- エディター内に集中し、生産性を向上。

> [!IMPORTANT]
> ワークスペースに有効な [`mcp.json`](../../../../../../09-CaseStudy/docs-mcp/solution/scenario3/mcp.json) 設定ファイルがあることを確認してください（場所は `.vscode/mcp.json`）。

## なぜシナリオ 2 に Chainlit を使うのか？

Chainlit は会話型ウェブアプリケーションを構築するための最新のオープンソースフレームワークです。Microsoft Learn Docs MCP サーバーのようなバックエンドサービスと連携したチャットベースのユーザーインターフェースを簡単に作成できます。このプロジェクトでは、Chainlit を使ってリアルタイムでパーソナライズされた学習計画を生成するシンプルでインタラクティブな方法を提供しています。Chainlit を活用することで、生産性と学習効果を高めるチャットツールを素早く構築・展開できます。

## このアプリの機能

このアプリは、トピックと期間を入力するだけでパーソナライズされた学習計画を作成します。入力内容を解析し、Microsoft Learn Docs MCP サーバーに関連コンテンツを問い合わせ、週ごとに整理された計画を作成します。各週の推奨内容はチャットで表示され、進捗を簡単に追跡できます。常に最新かつ関連性の高い学習リソースを提供することが保証されています。

## サンプルクエリ

チャットウィンドウで以下のクエリを試して、アプリの応答を確認してみてください：

- `AI-900 certification, 8 weeks`
- `Learn Azure Functions, 4 weeks`
- `Azure DevOps, 6 weeks`
- `Data engineering on Azure, 10 weeks`
- `Microsoft security fundamentals, 5 weeks`
- `Power Platform, 7 weeks`
- `Azure AI services, 12 weeks`
- `Cloud architecture, 9 weeks`

これらの例は、さまざまな学習目標や期間に対応できる柔軟性を示しています。

## 参考資料

- [Chainlit Documentation](https://docs.chainlit.io/)
- [MCP Documentation](https://github.com/MicrosoftDocs/mcp)

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性を期しておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語による文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じた誤解や誤訳について、当方は一切の責任を負いかねます。