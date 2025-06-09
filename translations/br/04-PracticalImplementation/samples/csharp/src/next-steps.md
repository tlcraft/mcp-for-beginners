<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-29T20:26:39+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "br"
}
-->
# Próximos passos após `azd init`

## Índice

1. [Próximos passos](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [O que foi adicionado](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [Cobrança](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [Solução de problemas](../../../../../../04-PracticalImplementation/samples/csharp/src)

## Próximos passos

### Provisionar infraestrutura e implantar o código da aplicação

Execute `azd up` para provisionar sua infraestrutura e implantar no Azure em um único passo (ou execute `azd provision` e depois `azd deploy` para realizar as tarefas separadamente). Acesse os endpoints do serviço listados para ver sua aplicação funcionando!

Para resolver quaisquer problemas, consulte [solução de problemas](../../../../../../04-PracticalImplementation/samples/csharp/src).

### Configurar pipeline de CI/CD

Execute `azd pipeline config -e <environment name>` para configurar o pipeline de implantação para se conectar de forma segura ao Azure. Um nome de ambiente é especificado aqui para configurar o pipeline com um ambiente diferente para fins de isolamento. Execute `azd env list` e `azd env set` para reselecionar o ambiente padrão após esta etapa.

- Implantação com `GitHub Actions`: selecione `GitHub` quando for solicitado um provedor. Se seu projeto não tiver o arquivo `azure-dev.yml`, aceite a solicitação para adicioná-lo e continue com a configuração do pipeline.

- Implantação com `Azure DevOps Pipeline`: selecione `Azure DevOps` quando for solicitado um provedor. Se seu projeto não tiver o arquivo `azure-dev.yml`, aceite a solicitação para adicioná-lo e continue com a configuração do pipeline.

## O que foi adicionado

### Configuração da infraestrutura

Para descrever a infraestrutura e a aplicação, foi adicionado um `azure.yaml` com a seguinte estrutura de diretórios:

```yaml
- azure.yaml     # azd project configuration
```

Este arquivo contém um único serviço, que referencia o App Host do seu projeto. Quando necessário, use `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` para salvar no disco.

Se fizer isso, alguns diretórios adicionais serão criados:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

Além disso, para cada recurso do projeto referenciado pelo seu app host, um projeto `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` será criado. Para mais informações, visite nossa documentação oficial [docs](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert).

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, por favor, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte oficial. Para informações críticas, recomenda-se a tradução profissional feita por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.