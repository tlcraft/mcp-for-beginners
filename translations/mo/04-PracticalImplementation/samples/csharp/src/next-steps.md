<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:14:31+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "mo"
}
-->
# الخطوات التالية بعد `azd init`

## جدول المحتويات

1. [الخطوات التالية](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [ما تم إضافته](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [الفوترة](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [استكشاف الأخطاء وإصلاحها](../../../../../../04-PracticalImplementation/samples/csharp/src)

## الخطوات التالية

### توفير البنية التحتية ونشر كود التطبيق

قم بتشغيل `azd up` لتوفير البنية التحتية الخاصة بك والنشر إلى Azure في خطوة واحدة (أو قم بتشغيل `azd provision` ثم `azd deploy` لإتمام المهام بشكل منفصل). قم بزيارة نقاط النهاية المدرجة لرؤية التطبيق الخاص بك يعمل!

لاستكشاف أي مشاكل، انظر [استكشاف الأخطاء وإصلاحها](../../../../../../04-PracticalImplementation/samples/csharp/src).

### تكوين خط أنابيب CI/CD

قم بتشغيل `azd pipeline config -e <environment name>` لتكوين خط الأنابيب للنشر للاتصال بشكل آمن بـ Azure. يتم تحديد اسم البيئة هنا لتكوين خط الأنابيب ببيئة مختلفة لأغراض العزل. قم بتشغيل `azd env list` و `azd env set` لإعادة اختيار البيئة الافتراضية بعد هذه الخطوة.

- النشر باستخدام `GitHub Actions`: اختر `GitHub` عندما يُطلب منك تحديد مزود. إذا كان مشروعك يفتقر إلى ملف `azure-dev.yml`، اقبل الطلب لإضافته واستمر في تكوين خط الأنابيب.

- النشر باستخدام `Azure DevOps Pipeline`: اختر `Azure DevOps` عندما يُطلب منك تحديد مزود. إذا كان مشروعك يفتقر إلى ملف `azure-dev.yml`، اقبل الطلب لإضافته واستمر في تكوين خط الأنابيب.

## ما تم إضافته

### تكوين البنية التحتية

لوصف البنية التحتية والتطبيق، تم إضافة `azure.yaml` مع الهيكل الدليل التالي:

```yaml
- azure.yaml     # azd project configuration
```

يحتوي هذا الملف على خدمة واحدة، والتي تشير إلى App Host لمشروعك. عند الحاجة، `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` للاحتفاظ بها على القرص.

إذا قمت بذلك، سيتم إنشاء بعض الدلائل الإضافية:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

بالإضافة إلى ذلك، لكل مورد مشروع يشير إليه مضيف التطبيق الخاص بك، مشروع `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd`، قم بزيارة [الوثائق الرسمية](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert).

It seems there might be a typo or misunderstanding in your request. "Mo" is not a recognized language. If you meant a specific language, please clarify. If you intended to translate the text into a language like Maori (mi) or another language, please specify which language you'd like the translation in, and I'll be happy to assist you.