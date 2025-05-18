<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:16:20+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "br"
}
-->
# Próximos Passos após `azd init`

## Índice

1. [Próximos Passos](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [O que foi adicionado](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [Cobrança](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [Solução de Problemas](../../../../../../04-PracticalImplementation/samples/csharp/src)

## Próximos Passos

### Provisione a infraestrutura e faça o deploy do código da aplicação

Execute `azd up` para provisionar sua infraestrutura e fazer o deploy no Azure em um único passo (ou execute `azd provision` e depois `azd deploy` para realizar as tarefas separadamente). Visite os endpoints de serviço listados para ver sua aplicação funcionando!

Para solucionar quaisquer problemas, veja [solução de problemas](../../../../../../04-PracticalImplementation/samples/csharp/src).

### Configure o pipeline de CI/CD

Execute `azd pipeline config -e <environment name>` para configurar o pipeline de deploy para se conectar de forma segura ao Azure. Um nome de ambiente é especificado aqui para configurar o pipeline com um ambiente diferente para fins de isolamento. Execute `azd env list` e `azd env set` para reconfigurar o ambiente padrão após esta etapa.

- Fazendo deploy com `GitHub Actions`: Selecione `GitHub` quando solicitado por um provedor. Se seu projeto não tiver o arquivo `azure-dev.yml`, aceite a solicitação para adicioná-lo e prossiga com a configuração do pipeline.

- Fazendo deploy com `Azure DevOps Pipeline`: Selecione `Azure DevOps` quando solicitado por um provedor. Se seu projeto não tiver o arquivo `azure-dev.yml`, aceite a solicitação para adicioná-lo e prossiga com a configuração do pipeline.

## O que foi adicionado

### Configuração de infraestrutura

Para descrever a infraestrutura e a aplicação, um `azure.yaml` foi adicionado com a seguinte estrutura de diretórios:

```yaml
- azure.yaml     # azd project configuration
```

Este arquivo contém um único serviço, que faz referência ao App Host do seu projeto. Quando necessário, `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` para persistir no disco.

Se você fizer isso, alguns diretórios adicionais serão criados:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

Além disso, para cada recurso de projeto referenciado pelo seu app host, um `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` projeto, visite nossa [documentação oficial](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert).

**Aviso Legal**:  
Este documento foi traduzido usando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automatizadas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autoritativa. Para informações críticas, é recomendada a tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações errôneas decorrentes do uso desta tradução.