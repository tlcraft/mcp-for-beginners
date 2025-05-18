<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:13:55+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "ar"
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

قم بتشغيل `azd up` لتوفير البنية التحتية الخاصة بك والنشر إلى Azure في خطوة واحدة (أو قم بتشغيل `azd provision` ثم `azd deploy` لإنجاز المهام بشكل منفصل). قم بزيارة نقاط النهاية المدرجة لرؤية تطبيقك يعمل!

لاستكشاف أي مشكلات، انظر [استكشاف الأخطاء وإصلاحها](../../../../../../04-PracticalImplementation/samples/csharp/src).

### تكوين خط الأنابيب CI/CD

قم بتشغيل `azd pipeline config -e <environment name>` لتكوين خط أنابيب النشر للاتصال بشكل آمن مع Azure. يتم تحديد اسم البيئة هنا لتكوين خط الأنابيب ببيئة مختلفة لأغراض العزل. قم بتشغيل `azd env list` و`azd env set` لإعادة تحديد البيئة الافتراضية بعد هذه الخطوة.

- النشر باستخدام `GitHub Actions`: اختر `GitHub` عندما يُطلب منك تحديد موفر. إذا كان مشروعك يفتقر إلى ملف `azure-dev.yml`، فاقبل المطالبة لإضافته واستمر في تكوين خط الأنابيب.

- النشر باستخدام `Azure DevOps Pipeline`: اختر `Azure DevOps` عندما يُطلب منك تحديد موفر. إذا كان مشروعك يفتقر إلى ملف `azure-dev.yml`، فاقبل المطالبة لإضافته واستمر في تكوين خط الأنابيب.

## ما تم إضافته

### تكوين البنية التحتية

لوصف البنية التحتية والتطبيق، تم إضافة `azure.yaml` مع هيكل الدليل التالي:

```yaml
- azure.yaml     # azd project configuration
```

يحتوي هذا الملف على خدمة واحدة، والتي تشير إلى مضيف التطبيق الخاص بمشروعك. عند الحاجة، `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` لحفظها على القرص.

إذا قمت بذلك، سيتم إنشاء بعض الأدلة الإضافية:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

بالإضافة إلى ذلك، لكل مورد مشروع يشير إليه مضيف التطبيق الخاص بك، `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` المشروع، قم بزيارة [الوثائق](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert) الرسمية الخاصة بنا.

**إخلاء المسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة بالذكاء الاصطناعي [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق. للحصول على معلومات حاسمة، يُوصى بالترجمة البشرية الاحترافية. نحن غير مسؤولين عن أي سوء فهم أو تفسيرات خاطئة ناتجة عن استخدام هذه الترجمة.