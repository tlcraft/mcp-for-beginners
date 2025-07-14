<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:27:46+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "ja"
}
-->
# ケーススタディ：API ManagementでREST APIをMCPサーバーとして公開する

Azure API Managementは、APIエンドポイントの上にゲートウェイを提供するサービスです。仕組みとしては、Azure API ManagementがAPIの前にプロキシとして動作し、受信したリクエストに対してどのように処理するかを決定します。

これを利用することで、以下のような多くの機能を追加できます：

- **セキュリティ**：APIキー、JWT、マネージドIDなど、さまざまな認証方式を利用可能です。
- **レート制限**：一定時間あたりに通過させる呼び出し回数を制御できる優れた機能です。これにより、すべてのユーザーが快適に利用できるだけでなく、サービスがリクエストで過負荷になるのを防げます。
- **スケーリング＆ロードバランシング**：複数のエンドポイントを設定して負荷を分散でき、ロードバランスの方法も選択可能です。
- **AI機能（セマンティックキャッシュ、トークン制限、トークン監視など）**：応答性を向上させるだけでなく、トークンの使用状況を把握するのに役立つ優れた機能です。[詳細はこちら](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities)。

## なぜMCP + Azure API Managementなのか？

Model Context Protocolは、エージェント型AIアプリケーションやツール・データを一貫した方法で公開するための標準として急速に普及しています。APIを「管理」する必要がある場合、Azure API Managementは自然な選択肢です。MCPサーバーはしばしば他のAPIと連携してツールへのリクエストを解決するため、Azure API ManagementとMCPを組み合わせることは非常に理にかなっています。

## 概要

この具体的なユースケースでは、APIエンドポイントをMCPサーバーとして公開する方法を学びます。これにより、これらのエンドポイントをエージェント型アプリの一部として簡単に組み込みつつ、Azure API Managementの機能も活用できます。

## 主な機能

- 公開したいエンドポイントのメソッドをツールとして選択できます。
- 追加機能はAPIのポリシーセクションで設定した内容に依存しますが、ここではレート制限の追加方法を紹介します。

## 事前準備：APIのインポート

すでにAzure API ManagementにAPIがある場合はこのステップはスキップできます。まだの場合は、こちらのリンクを参照してください：[Azure API ManagementへのAPIインポート](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api)。

## APIをMCPサーバーとして公開する

APIエンドポイントを公開するには、以下の手順に従います：

1. Azureポータルにアクセスし、次のURLに移動します <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
   API Managementインスタンスに移動します。

1. 左側のメニューで「APIs」＞「MCP Servers」＞「+ Create new MCP Server」を選択します。

1. 「API」からMCPサーバーとして公開したいREST APIを選択します。

1. ツールとして公開したいAPI操作を1つ以上選択します。すべての操作を選択することも、特定の操作だけを選択することも可能です。

    ![公開するメソッドを選択](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. **Create** を選択します。

1. メニューの「APIs」＞「MCP Servers」に移動すると、以下のように表示されます：

    ![メインペインに表示されたMCPサーバー](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    MCPサーバーが作成され、API操作がツールとして公開されました。MCPサーバーはMCP Serversペインに一覧表示されます。URL列には、テストやクライアントアプリケーション内で呼び出せるMCPサーバーのエンドポイントが表示されます。

## オプション：ポリシーの設定

Azure API Managementには、レート制限やセマンティックキャッシュなど、エンドポイントに対してさまざまなルールを設定できる「ポリシー」というコア概念があります。これらのポリシーはXMLで記述されます。

MCPサーバーのレート制限ポリシーを設定する方法は以下の通りです：

1. ポータルで「APIs」＞「MCP Servers」を選択します。

1. 作成したMCPサーバーを選択します。

1. 左メニューの「MCP」内の「Policies」を選択します。

1. ポリシーエディターで、MCPサーバーのツールに適用したいポリシーを追加または編集します。ポリシーはXML形式で定義します。例えば、クライアントIPアドレスごとに30秒あたり5回の呼び出しに制限するポリシーは以下のようになります：

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    ポリシーエディターの画面は以下の通りです：

    ![ポリシーエディター](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## 試してみる

MCPサーバーが意図した通りに動作しているか確認しましょう。

ここではVisual Studio CodeとGitHub CopilotのAgentモードを使います。MCPサーバーを*mcp.json*に追加することで、Visual Studio Codeがエージェント機能を持つクライアントとして動作し、エンドユーザーはプロンプトを入力してサーバーと対話できるようになります。

Visual Studio CodeにMCPサーバーを追加する手順は以下の通りです：

1. コマンドパレットからMCP: **Add Serverコマンド**を実行します。

1. サーバーの種類を選択するよう求められたら、**HTTP (HTTPまたはServer Sent Events)** を選択します。

1. API ManagementのMCPサーバーのURLを入力します。例：**https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse**（SSEエンドポイントの場合）または**https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp**（MCPエンドポイントの場合）。トランスポートの違いは`/sse`か`/mcp`かで区別されます。

1. 任意のサーバーIDを入力します。重要な値ではありませんが、このサーバーインスタンスを識別するのに役立ちます。

1. 設定をワークスペース設定かユーザー設定のどちらに保存するか選択します。

  - **ワークスペース設定** - サーバー設定は現在のワークスペース内のみで利用可能な.vscode/mcp.jsonファイルに保存されます。

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    ストリーミングHTTPをトランスポートに選んだ場合は少し異なります：

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **ユーザー設定** - サーバー設定はグローバルな*settings.json*ファイルに追加され、すべてのワークスペースで利用可能です。設定は以下のようになります：

    ![ユーザー設定](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. Azure API Managementに正しく認証するために、ヘッダーを追加する必要があります。ヘッダー名は**Ocp-Apim-Subscription-Key**です。

    - 設定に追加する方法は以下の通りです：

    ![認証用ヘッダーの追加](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png)  
    これにより、APIキーの値を入力するプロンプトが表示されます。APIキーはAzureポータルのAzure API Managementインスタンスで確認できます。

   - *mcp.json*に直接追加する場合は以下のように記述します：

    ```json
    "inputs": [
      {
        "type": "promptString",
        "id": "apim_key",
        "description": "API Key for Azure API Management",
        "password": true
      }
    ]
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp",
            "headers": {
                "Ocp-Apim-Subscription-Key": "Bearer ${input:apim_key}"
            }
        }
    }
    ```

### Agentモードの利用

設定が完了したら、実際に試してみましょう。

サーバーから公開されたツールが一覧表示されるツールアイコンが表示されるはずです：

![サーバーのツール](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. ツールアイコンをクリックすると、以下のようにツールのリストが表示されます：

    ![ツール一覧](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. チャットにプロンプトを入力してツールを呼び出します。例えば、注文情報を取得するツールを選択している場合、エージェントに注文について尋ねることができます。以下は例のプロンプトです：

    ```text
    get information from order 2
    ```

    ツールを呼び出すかどうかの確認アイコンが表示されます。続行を選択すると、以下のような出力が表示されます：

    ![プロンプトの結果](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **上記の表示は設定したツールによって異なりますが、基本的にはテキスト形式の応答が得られます。**

## 参考資料

さらに詳しく学びたい方はこちら：

- [Azure API ManagementとMCPのチュートリアル](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Pythonサンプル：Azure API Managementを使った安全なリモートMCPサーバー（実験的）](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [MCPクライアント認証ラボ](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)
- [VS Code用Azure API Management拡張機能でAPIをインポート・管理する方法](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)
- [Azure API CenterでリモートMCPサーバーを登録・検出する](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Azure API Managementの多彩なAI機能を紹介する優れたリポジトリ
- [AI Gatewayワークショップ](https://azure-samples.github.io/AI-Gateway/) Azureポータルを使ったワークショップで、AI機能の評価を始めるのに最適です。

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性を期しておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語によるオリジナル文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じた誤解や誤訳について、当方は一切の責任を負いかねます。