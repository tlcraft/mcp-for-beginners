<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-06-17T17:06:37+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "uk"
}
-->
# Наступні кроки після `azd init`

## Зміст

1. [Наступні кроки](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [Що було додано](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [Білінг](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [Вирішення проблем](../../../../../../04-PracticalImplementation/samples/csharp/src)

## Наступні кроки

### Підготувати інфраструктуру та розгорнути код додатку

Запустіть `azd up`, щоб підготувати інфраструктуру та розгорнути додаток в Azure за один крок (або спочатку `azd provision`, а потім `azd deploy`, щоб виконати ці завдання окремо). Перейдіть за вказаними кінцевими точками сервісу, щоб побачити свій додаток у роботі!

Щоб усунути можливі проблеми, дивіться [вирішення проблем](../../../../../../04-PracticalImplementation/samples/csharp/src).

### Налаштувати CI/CD pipeline

Запустіть `azd pipeline config -e <environment name>`, щоб налаштувати конвеєр розгортання з безпечним підключенням до Azure. Тут вказується ім’я середовища, щоб налаштувати конвеєр для іншого середовища з метою ізоляції. Після цього кроку запустіть `azd env list` і `azd env set`, щоб повторно вибрати середовище за замовчуванням.

- Розгортання за допомогою `GitHub Actions`: виберіть `GitHub`, коли буде запропоновано провайдера. Якщо у вашому проєкті немає файлу `azure-dev.yml`, погодьтеся додати його та продовжуйте налаштування конвеєра.

- Розгортання за допомогою `Azure DevOps Pipeline`: виберіть `Azure DevOps`, коли буде запропоновано провайдера. Якщо у вашому проєкті немає файлу `azure-dev.yml`, погодьтеся додати його та продовжуйте налаштування конвеєра.

## Що було додано

### Конфігурація інфраструктури

Для опису інфраструктури та додатку було додано `azure.yaml` з такою структурою директорій:

```yaml
- azure.yaml     # azd project configuration
```

Цей файл містить один сервіс, який посилається на App Host вашого проєкту. За потреби виконайте `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth`, щоб зберегти його на диск.

Якщо ви це зробите, будуть створені додаткові директорії:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

Крім того, для кожного ресурсу проєкту, на який посилається ваш App Host, створюється `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd`. Для детальнішої інформації про підтримку сумісності проєкту відвідайте нашу офіційну [документацію](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert).

**Відмова від відповідальності**:  
Цей документ було перекладено за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоч ми і прагнемо до точності, просимо враховувати, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння чи неправильні тлумачення, що виникли внаслідок використання цього перекладу.