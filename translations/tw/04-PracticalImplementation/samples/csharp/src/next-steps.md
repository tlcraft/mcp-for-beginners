<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:14:55+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "tw"
}
-->
# 使用 `azd init` 之後的下一步

## 目錄

1. [下一步](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [新增了什麼](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [計費](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [故障排除](../../../../../../04-PracticalImplementation/samples/csharp/src)

## 下一步

### 配置基礎設施並部署應用程式代碼

運行 `azd up` 以一步完成基礎設施配置並部署到 Azure（或者分別運行 `azd provision` 和 `azd deploy` 來單獨完成這些任務）。訪問列出的服務端點，查看你的應用程式是否正常運行！

如需故障排除，請參閱[故障排除](../../../../../../04-PracticalImplementation/samples/csharp/src)。

### 配置 CI/CD 管道

運行 `azd pipeline config -e <environment name>` 以配置部署管道，安全地連接到 Azure。此處指定了一個環境名稱，以便為隔離目的配置管道使用不同的環境。運行 `azd env list` 和 `azd env set` 以在此步驟後重新選擇默認環境。

- 使用 `GitHub Actions` 部署：在提示選擇提供者時，選擇 `GitHub`。如果你的項目缺少 `azure-dev.yml` 文件，請接受提示添加並繼續進行管道配置。

- 使用 `Azure DevOps Pipeline` 部署：在提示選擇提供者時，選擇 `Azure DevOps`。如果你的項目缺少 `azure-dev.yml` 文件，請接受提示添加並繼續進行管道配置。

## 新增了什麼

### 基礎設施配置

為描述基礎設施和應用程式，新增了一個 `azure.yaml`，具有以下目錄結構：

```yaml
- azure.yaml     # azd project configuration
```

此文件包含一個服務，引用了你的項目的 App Host。如有需要，運行 `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` 以將其保存到磁碟。

如果你這樣做，將創建一些額外的目錄：

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

此外，對於你的應用程式主機所引用的每個項目資源，運行 `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` 項目，請訪問我們的官方[文檔](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert)。

**免責聲明**：
本文件已使用AI翻譯服務[Co-op Translator](https://github.com/Azure/co-op-translator)進行翻譯。儘管我們努力追求準確性，但請注意自動翻譯可能包含錯誤或不準確之處。應將原文件的本地語言版本視為權威來源。對於關鍵信息，建議尋求專業人工翻譯。對於因使用此翻譯而產生的任何誤解或誤讀，我們不承擔任何責任。