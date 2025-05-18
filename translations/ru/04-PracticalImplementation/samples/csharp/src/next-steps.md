<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:13:44+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "ru"
}
-->
# Следующие шаги после `azd init`

## Содержание

1. [Следующие шаги](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [Что было добавлено](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [Оплата](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [Устранение неполадок](../../../../../../04-PracticalImplementation/samples/csharp/src)

## Следующие шаги

### Подготовка инфраструктуры и развертывание кода приложения

Запустите `azd up`, чтобы подготовить инфраструктуру и развернуть на Azure за один шаг (или выполните `azd provision`, затем `azd deploy`, чтобы выполнить задачи отдельно). Посетите перечисленные конечные точки сервиса, чтобы увидеть ваше приложение в действии!

Для устранения любых проблем смотрите раздел [устранение неполадок](../../../../../../04-PracticalImplementation/samples/csharp/src).

### Настройка CI/CD конвейера

Запустите `azd pipeline config -e <environment name>`, чтобы настроить конвейер развертывания для безопасного подключения к Azure. Здесь указывается имя окружения для настройки конвейера с другим окружением в целях изоляции. Выполните `azd env list` и `azd env set`, чтобы повторно выбрать окружение по умолчанию после этого шага.

- Развертывание с `GitHub Actions`: выберите `GitHub` при запросе провайдера. Если в вашем проекте отсутствует файл `azure-dev.yml`, примите запрос на его добавление и продолжайте настройку конвейера.

- Развертывание с `Azure DevOps Pipeline`: выберите `Azure DevOps` при запросе провайдера. Если в вашем проекте отсутствует файл `azure-dev.yml`, примите запрос на его добавление и продолжайте настройку конвейера.

## Что было добавлено

### Конфигурация инфраструктуры

Для описания инфраструктуры и приложения был добавлен `azure.yaml` со следующей структурой каталогов:

```yaml
- azure.yaml     # azd project configuration
```

Этот файл содержит единственный сервис, который ссылается на App Host вашего проекта. При необходимости используйте `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth`, чтобы сохранить его на диск.

Если вы это сделаете, будут созданы некоторые дополнительные каталоги:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

Кроме того, для каждого ресурса проекта, на который ссылается ваш App Host, будет создан `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` проект. Посетите нашу официальную [документацию](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert).

**Отказ от ответственности**:  
Этот документ был переведен с помощью службы автоматического перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Хотя мы стремимся к точности, пожалуйста, учитывайте, что автоматические переводы могут содержать ошибки или неточности. Оригинальный документ на его родном языке следует считать авторитетным источником. Для критически важной информации рекомендуется профессиональный перевод человеком. Мы не несем ответственности за любые недоразумения или неправильные толкования, возникшие в результате использования этого перевода.