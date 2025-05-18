<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:20:27+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "bg"
}
-->
# Следващи стъпки след `azd init`

## Съдържание

1. [Следващи стъпки](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [Какво беше добавено](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [Фактуриране](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [Отстраняване на проблеми](../../../../../../04-PracticalImplementation/samples/csharp/src)

## Следващи стъпки

### Осигуряване на инфраструктура и разгръщане на код на приложението

Изпълнете `azd up`, за да осигурите вашата инфраструктура и да разположите на Azure в една стъпка (или изпълнете `azd provision`, след това `azd deploy`, за да изпълните задачите отделно). Посетете изброените крайни точки на услугата, за да видите вашето приложение в действие!

За да отстраните проблеми, вижте [отстраняване на проблеми](../../../../../../04-PracticalImplementation/samples/csharp/src).

### Конфигуриране на CI/CD тръбопровод

Изпълнете `azd pipeline config -e <environment name>`, за да конфигурирате тръбопровода за разгръщане за сигурна връзка с Azure. Тук се посочва име на среда, за да се конфигурира тръбопровода с различна среда за целите на изолация. Изпълнете `azd env list` и `azd env set`, за да изберете отново стандартната среда след тази стъпка.

- Разгръщане с `GitHub Actions`: Изберете `GitHub`, когато бъдете попитани за доставчик. Ако вашият проект няма файл `azure-dev.yml`, приемете подкана да го добавите и продължете с конфигурацията на тръбопровода.

- Разгръщане с `Azure DevOps Pipeline`: Изберете `Azure DevOps`, когато бъдете попитани за доставчик. Ако вашият проект няма файл `azure-dev.yml`, приемете подкана да го добавите и продължете с конфигурацията на тръбопровода.

## Какво беше добавено

### Конфигурация на инфраструктурата

За да опишете инфраструктурата и приложението, беше добавен `azure.yaml` със следната структура на директорията:

```yaml
- azure.yaml     # azd project configuration
```

Този файл съдържа една услуга, която препраща към App Host на вашия проект. Когато е необходимо, `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth`, за да го запазите на диск.

Ако направите това, ще бъдат създадени някои допълнителни директории:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

Освен това, за всеки ресурс на проекта, който се препраща от вашия App Host, `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` проект, посетете нашите официални [документи](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert).

**Отказ от отговорност**:
Този документ е преведен с помощта на AI услуга за превод [Co-op Translator](https://github.com/Azure/co-op-translator). Докато се стремим към точност, моля, имайте предвид, че автоматизираните преводи може да съдържат грешки или неточности. Оригиналният документ на неговия роден език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за каквито и да било недоразумения или погрешни интерпретации, произтичащи от използването на този превод.