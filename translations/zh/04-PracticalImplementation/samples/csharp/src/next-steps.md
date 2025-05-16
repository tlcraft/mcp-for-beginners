<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-16T15:42:35+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "zh"
}
-->
# `azd init` 之后的下一步

## 目录

1. [下一步](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [新增内容](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [计费](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [故障排除](../../../../../../04-PracticalImplementation/samples/csharp/src)

## 下一步

### 配置基础设施并部署应用代码

运行 `azd up` 一步完成基础设施的配置和部署到 Azure（或者先运行 `azd provision`，再运行 `azd deploy` 分别完成这两个任务）。访问列出的服务端点，查看您的应用是否已成功运行！

如需排查问题，请参阅 [故障排除](../../../../../../04-PracticalImplementation/samples/csharp/src)。

### 配置 CI/CD 流水线

运行 `azd pipeline config -e <environment name>` 配置部署流水线，以安全连接到 Azure。这里指定了环境名称，用于配置不同的环境以实现隔离。完成此步骤后，运行 `azd env list` 和 `azd env set` 重新选择默认环境。

- 使用 `GitHub Actions` 部署：提示选择提供者时请选择 `GitHub`。如果项目中缺少 `azure-dev.yml` 文件，请接受提示添加该文件，然后继续配置流水线。

- 使用 `Azure DevOps Pipeline` 部署：提示选择提供者时请选择 `Azure DevOps`。如果项目中缺少 `azure-dev.yml` 文件，请接受提示添加该文件，然后继续配置流水线。

## 新增内容

### 基础设施配置

为了描述基础设施和应用，新增了一个 `azure.yaml` 文件，目录结构如下：

```yaml
- azure.yaml     # azd project configuration
```

该文件包含一个服务，引用了您项目的 App Host。需要时，运行 `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` 将其保存到磁盘。

执行此操作后，会创建一些额外的目录：

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

此外，对于 App Host 引用的每个项目资源，会生成一个 `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` 项目，详情请访问我们的官方[文档](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert)。

**免责声明**：  
本文件由AI翻译服务[Co-op Translator](https://github.com/Azure/co-op-translator)翻译。尽管我们力求准确，但请注意自动翻译可能包含错误或不准确之处。原始语言版本的文件应被视为权威来源。对于重要信息，建议使用专业人工翻译。对于因使用本翻译而产生的任何误解或误释，我们概不负责。