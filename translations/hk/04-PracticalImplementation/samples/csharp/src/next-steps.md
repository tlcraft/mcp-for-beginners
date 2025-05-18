<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:14:45+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "hk"
}
-->
# 下一步措施在 `azd init`

## 目录

1. [下一步措施](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [添加了什么](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [计费](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [故障排除](../../../../../../04-PracticalImplementation/samples/csharp/src)

## 下一步措施

### 配置基础设施和部署应用程序代码

运行 `azd up` 以一步完成基础设施的配置和部署到 Azure（或者先运行 `azd provision` 然后 `azd deploy` 来分别完成这些任务）。访问列出的服务端点以查看您的应用程序是否正常运行！

若需排除故障，请参阅[故障排除](../../../../../../04-PracticalImplementation/samples/csharp/src)。

### 配置 CI/CD 管道

运行 `azd pipeline config -e <environment name>` 来配置部署管道以安全连接到 Azure。这里指定了一个环境名称，以便配置管道使用不同的环境以达到隔离目的。完成此步骤后，运行 `azd env list` 和 `azd env set` 重新选择默认环境。

- 使用 `GitHub Actions` 部署：当提示选择提供者时，选择 `GitHub`。如果您的项目缺少 `azure-dev.yml` 文件，请接受添加提示并继续进行管道配置。

- 使用 `Azure DevOps Pipeline` 部署：当提示选择提供者时，选择 `Azure DevOps`。如果您的项目缺少 `azure-dev.yml` 文件，请接受添加提示并继续进行管道配置。

## 添加了什么

### 基础设施配置

为了描述基础设施和应用程序，添加了一个 `azure.yaml`，具有以下目录结构：

```yaml
- azure.yaml     # azd project configuration
```

该文件包含一个服务，引用了您项目的应用程序主机。当需要时，运行 `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` 以将其持久化到磁盘。

如果您这样做，会创建一些额外的目录：

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

此外，对于应用程序主机引用的每个项目资源，一个 `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` 项目，请访问我们的官方[文档](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert)。

**免責聲明**：
本文檔已使用AI翻譯服務[Co-op Translator](https://github.com/Azure/co-op-translator)進行翻譯。我們努力確保翻譯準確，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於關鍵信息，建議使用專業人工翻譯。我們不對使用此翻譯所產生的任何誤解或誤釋負責。