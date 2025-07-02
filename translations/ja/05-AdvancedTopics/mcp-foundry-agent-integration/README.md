<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-02T10:11:19+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "ja"
}
-->
# Model Context Protocol (MCP) と Azure AI Foundry の統合

このガイドでは、Model Context Protocol (MCP) サーバーを Azure AI Foundry エージェントと統合し、強力なツールのオーケストレーションとエンタープライズ向けAI機能を実現する方法を説明します。

## はじめに

Model Context Protocol (MCP) は、AIアプリケーションが外部のデータソースやツールに安全に接続できるようにするオープンスタンダードです。Azure AI Foundry と統合することで、エージェントはさまざまな外部サービス、API、データソースに標準化された方法でアクセスし、操作できるようになります。

この統合は、MCPの柔軟なツールエコシステムと Azure AI Foundry の堅牢なエージェントフレームワークを組み合わせ、幅広いカスタマイズが可能なエンタープライズ向けAIソリューションを提供します。

**Note:** Azure AI Foundry Agent Service で MCP を使用する場合、現在サポートされているリージョンは westus、westus2、uaenorth、southindia、switzerlandnorth のみです。

## 学習目標

このガイドを終えるまでに、以下ができるようになります：

- Model Context Protocol の概要と利点を理解する
- Azure AI Foundry エージェントで使用する MCP サーバーをセットアップする
- MCPツール統合を含むエージェントを作成・設定する
- 実際の MCP サーバーを使った実用例を実装する
- エージェントの会話内でツールの応答や引用を処理する

## 前提条件

開始する前に、以下を準備してください：

- AI Foundry アクセス付きの Azure サブスクリプション
- Python 3.10 以上
- Azure CLI がインストールされ設定済みであること
- AIリソースを作成するための適切な権限

## Model Context Protocol (MCP) とは？

Model Context Protocol は、AIアプリケーションが外部のデータソースやツールに接続するための標準化された手法です。主な利点は以下の通りです：

- **標準化された統合**：異なるツールやサービス間で一貫したインターフェースを提供
- **セキュリティ**：安全な認証・認可メカニズムを備える
- **柔軟性**：さまざまなデータソース、API、カスタムツールに対応
- **拡張性**：新しい機能や統合を簡単に追加可能

## Azure AI Foundry での MCP セットアップ

### 1. 環境設定

まず、環境変数や依存関係を設定します：

```python
import os
import time
import json
from azure.ai.agents.models import MessageTextContent, ListSortOrder
from azure.ai.projects import AIProjectClient
from azure.identity import DefaultAzureCredential


### 1. Initialize the AI Project Client

```python
project_client = AIProjectClient(
    endpoint="https://your-project-endpoint.services.ai.azure.com/api/projects/your-project",
    credential=DefaultAzureCredential(),
)
```

### 2. Create an Agent with MCP Tools

Configure an agent with MCP server integration:

```python
with project_client:
    agent = project_client.agents.create_agent(
        model="gpt-4.1-nano", 
        name="mcp_agent", 
        instructions="You are a helpful assistant. Use the tools provided to answer questions. Be sure to cite your sources.",
        tools=[
            {
                "type": "mcp",
                "server_label": "microsoft_docs",
                "server_url": "https://learn.microsoft.com/api/mcp",
                "require_approval": "never"
            }
        ],
        tool_resources=None
    )
    print(f"Created agent, agent ID: {agent.id}")
```

## MCP Tool Configuration Options

When configuring MCP tools for your agent, you can specify several important parameters:

### Configuration

```python
mcp_tool = {
    "type": "mcp",
    "server_label": "unique_server_name",      # MCPサーバーの識別子
    "server_url": "https://api.example.com/mcp", # MCPサーバーのエンドポイント
    "require_approval": "never"                 # 承認ポリシー：現時点では "never" のみ対応
}
```

## Complete Example: Using Microsoft Learn MCP Server

Here's a complete example that demonstrates creating an agent with MCP integration and processing a conversation:

```python
import time
import json
import os
from azure.ai.agents.models import MessageTextContent, ListSortOrder
from azure.ai.projects import AIProjectClient
from azure.identity import DefaultAzureCredential

def create_mcp_agent_example():

    project_client = AIProjectClient(
        endpoint="https://your-endpoint.services.ai.azure.com/api/projects/your-project",
        credential=DefaultAzureCredential(),
    )

    with project_client:
        # MCPツールを使ったエージェントを作成
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="You are a helpful assistant specializing in Microsoft documentation. Use the Microsoft Learn MCP server to search for accurate, up-to-date information. Always cite your sources.",
            tools=[
                {
                    "type": "mcp",
                    "server_label": "mslearn",
                    "server_url": "https://learn.microsoft.com/api/mcp",
                    "require_approval": "never"
                }
            ],
            tool_resources=None
        )
        print(f"Created agent, agent ID: {agent.id}")    
        
        # 会話スレッドを作成
        thread = project_client.agents.threads.create()
        print(f"Created thread, thread ID: {thread.id}")

        # メッセージを送信
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content=".NET MAUIとは何ですか？Xamarin.Formsと比べてどう違いますか？",
        )
        print(f"Created message, message ID: {message.id}")

        # エージェントを実行
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # 完了までポーリング
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Run status: {run.status}")

        # 実行ステップとツール呼び出しを確認
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Run step: {step.id}, status: {step.status}, type: {step.type}")
            if step.type == "tool_calls":
                print("Tool call details:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # 会話内容を表示
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()
```

## よくある問題のトラブルシューティング

### 1. 接続の問題
- MCPサーバーのURLがアクセス可能か確認する
- 認証情報を確認する
- ネットワーク接続を確認する

### 2. ツール呼び出しの失敗
- ツールの引数やフォーマットを見直す
- サーバー固有の要件を確認する
- 適切なエラーハンドリングを実装する

### 3. パフォーマンスの問題
- ツール呼び出しの頻度を最適化する
- 適宜キャッシュを利用する
- サーバーの応答時間を監視する

## 次のステップ

MCP統合をさらに強化するために：

1. **カスタム MCP サーバーの構築**：独自のデータソース向けに MCP サーバーを作成する
2. **高度なセキュリティの実装**：OAuth2やカスタム認証メカニズムを追加する
3. **モニタリングと分析**：ツール利用状況のログ収集や監視を行う
4. **ソリューションのスケールアップ**：負荷分散や分散型 MCP サーバー構成を検討する

## 参考資料

- [Azure AI Foundry Documentation](https://learn.microsoft.com/azure/ai-foundry/)
- [Model Context Protocol Samples](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Azure AI Foundry Agents Overview](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)

## サポート

追加のサポートや質問については：

- [Azure AI Foundry ドキュメント](https://learn.microsoft.com/azure/ai-foundry/) をご覧ください
- [MCP コミュニティリソース](https://modelcontextprotocol.io/) を確認してください

## 次に進む

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**免責事項**:  
本書類はAI翻訳サービス[Co-op Translator](https://github.com/Azure/co-op-translator)を使用して翻訳されました。正確性を期しておりますが、自動翻訳には誤りや不正確な箇所が含まれる可能性があることをご承知おきください。原文の言語によるオリジナル文書が正式な情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の使用に起因するいかなる誤解や誤訳についても、当方は責任を負いかねます。