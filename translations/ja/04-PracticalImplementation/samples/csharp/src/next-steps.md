<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-16T15:42:12+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "ja"
}
-->
# `azd init` の次のステップ

## 目次

1. [次のステップ](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [追加された内容](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [請求](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [トラブルシューティング](../../../../../../04-PracticalImplementation/samples/csharp/src)

## 次のステップ

### インフラをプロビジョニングしてアプリケーションコードをデプロイする

`azd up` を実行すると、インフラのプロビジョニングと Azure へのデプロイを一度に行えます（または `azd provision` を実行してから `azd deploy` を実行して、別々に作業を行うことも可能です）。サービスエンドポイントにアクセスして、アプリケーションが稼働していることを確認してください！

問題が発生した場合は、[トラブルシューティング](../../../../../../04-PracticalImplementation/samples/csharp/src)をご覧ください。

### CI/CD パイプラインの設定

`azd pipeline config -e <environment name>` を実行して、Azure に安全に接続するデプロイパイプラインを設定します。ここで環境名を指定すると、分離のために異なる環境でパイプラインが設定されます。この手順の後、`azd env list` と `azd env set` を実行してデフォルト環境を再選択してください。

- `GitHub Actions` を使ったデプロイの場合: プロバイダーの選択時に `GitHub` を選択します。プロジェクトに `azure-dev.yml` ファイルがない場合は、追加するかどうかのプロンプトが表示されるので、承諾してパイプラインの設定を続行してください。

- `Azure DevOps Pipeline` を使ったデプロイの場合: プロバイダーの選択時に `Azure DevOps` を選択します。プロジェクトに `azure-dev.yml` ファイルがない場合は、追加するかどうかのプロンプトが表示されるので、承諾してパイプラインの設定を続行してください。

## 追加された内容

### インフラ構成

インフラとアプリケーションを記述するために、以下のディレクトリ構造を持つ `azure.yaml` が追加されました：

```yaml
- azure.yaml     # azd project configuration
```

このファイルには単一のサービスが含まれており、プロジェクトの App Host を参照しています。必要に応じて、`azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` を実行してディスクに保存してください。

これを行うと、追加のディレクトリが作成されます：

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

さらに、アプリホストが参照する各プロジェクトリソースごとに、`containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

*Note*: Once you have synthesized your infrastructure to disk, changes made to your App Host will not be reflected in the infrastructure. You can re-generate the infrastructure by running `azd infra synth` again. It will prompt you before overwriting files. You can pass `--force` to force `azd infra synth` to overwrite the files without prompting.

*Note*: `azd infra synth` is currently an alpha feature and must be explicitly enabled by running `azd config set alpha.infraSynth on`. You only need to do this once.

## Billing

Visit the *Cost Management + Billing* page in Azure Portal to track current spend. For more information about how you're billed, and how you can monitor the costs incurred in your Azure subscriptions, visit [billing overview](https://learn.microsoft.com/azure/developer/intro/azure-developer-billing).

## Troubleshooting

Q: I visited the service endpoint listed, and I'm seeing a blank page, a generic welcome page, or an error page.

A: Your service may have failed to start, or it may be missing some configuration settings. To investigate further:

1. Run `azd show`. Click on the link under "View in Azure Portal" to open the resource group in Azure Portal.
2. Navigate to the specific Container App service that is failing to deploy.
3. Click on the failing revision under "Revisions with Issues".
4. Review "Status details" for more information about the type of failure.
5. Observe the log outputs from Console log stream and System log stream to identify any errors.
6. If logs are written to disk, use *Console* in the navigation to connect to a shell within the running container.

For more troubleshooting information, visit [Container Apps troubleshooting](https://learn.microsoft.com/azure/container-apps/troubleshooting). 

### Additional information

For additional information about setting up your `azd` プロジェクトについては、公式の[ドキュメント](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert)をご参照ください。

**免責事項**：  
本書類はAI翻訳サービス[Co-op Translator](https://github.com/Azure/co-op-translator)を使用して翻訳されています。正確性を期しておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。正式な情報源としては、原文の原言語版を参照してください。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の使用により生じた誤解や誤訳について、当方は一切の責任を負いかねます。