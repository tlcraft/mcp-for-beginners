<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:14:19+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "ur"
}
-->
# `azd init` کے بعد اگلے اقدامات

## فہرست

1. [اگلے اقدامات](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [کیا شامل کیا گیا](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [بلنگ](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [مسائل کا حل](../../../../../../04-PracticalImplementation/samples/csharp/src)

## اگلے اقدامات

### انفراسٹرکچر کی فراہمی اور ایپلیکیشن کوڈ کو تعینات کرنا

اپنے انفراسٹرکچر کو فراہم کرنے اور Azure پر ایک قدم میں تعینات کرنے کے لئے `azd up` چلائیں (یا `azd provision` اور پھر `azd deploy` چلائیں تاکہ کام کو الگ الگ انجام دیا جا سکے)۔ اپنی ایپلیکیشن کو چلتا ہوا دیکھنے کے لئے درج کردہ سروس اینڈ پوائنٹس پر جائیں!

کسی بھی مسئلے کو حل کرنے کے لئے، [مسائل کا حل](../../../../../../04-PracticalImplementation/samples/csharp/src) دیکھیں۔

### CI/CD پائپ لائن کو ترتیب دینا

Azure کے ساتھ محفوظ طریقے سے جڑنے کے لئے تعیناتی پائپ لائن کو ترتیب دینے کے لئے `azd pipeline config -e <environment name>` چلائیں۔ یہاں ایک ماحول کا نام دیا گیا ہے تاکہ الگ تھلگ کرنے کے مقاصد کے لئے مختلف ماحول کے ساتھ پائپ لائن کو ترتیب دیا جا سکے۔ اس قدم کے بعد ڈیفالٹ ماحول کو دوبارہ منتخب کرنے کے لئے `azd env list` اور `azd env set` چلائیں۔

- `GitHub Actions` کے ساتھ تعیناتی: فراہم کنندہ کے لئے پوچھنے پر `GitHub` منتخب کریں۔ اگر آپ کے پروجیکٹ میں `azure-dev.yml` فائل نہیں ہے، تو اسے شامل کرنے کے لئے پرامپٹ کو قبول کریں اور پائپ لائن ترتیب کے ساتھ آگے بڑھیں۔

- `Azure DevOps Pipeline` کے ساتھ تعیناتی: فراہم کنندہ کے لئے پوچھنے پر `Azure DevOps` منتخب کریں۔ اگر آپ کے پروجیکٹ میں `azure-dev.yml` فائل نہیں ہے، تو اسے شامل کرنے کے لئے پرامپٹ کو قبول کریں اور پائپ لائن ترتیب کے ساتھ آگے بڑھیں۔

## کیا شامل کیا گیا

### انفراسٹرکچر ترتیب

انفراسٹرکچر اور ایپلیکیشن کو بیان کرنے کے لئے ایک `azure.yaml` شامل کیا گیا ہے جس کی ڈائریکٹری ساخت درج ذیل ہے:

```yaml
- azure.yaml     # azd project configuration
```

یہ فائل ایک سروس پر مشتمل ہے، جو آپ کے پروجیکٹ کے ایپ ہوسٹ کا حوالہ دیتی ہے۔ جب ضرورت ہو، `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` اسے ڈسک پر برقرار رکھنے کے لئے۔

اگر آپ ایسا کرتے ہیں، تو کچھ اضافی ڈائریکٹریز بنائی جائیں گی:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

اس کے علاوہ، آپ کے ایپ ہوسٹ کے ذریعہ حوالہ کردہ ہر پروجیکٹ وسائل کے لئے، ایک `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` پروجیکٹ، ہمارے آفیشل [docs](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert) پر جائیں۔

**دستبرداری**:
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کا استعمال کرتے ہوئے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا عدم درستگی ہو سکتی ہیں۔ اصل دستاویز کو اس کی مقامی زبان میں مستند ماخذ سمجھا جانا چاہیے۔ اہم معلومات کے لیے، پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ ہم اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کے ذمہ دار نہیں ہیں۔