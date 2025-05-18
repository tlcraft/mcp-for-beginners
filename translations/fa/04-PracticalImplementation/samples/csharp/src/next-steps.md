<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:14:04+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "fa"
}
-->
# مراحل بعدی پس از `azd init`

## فهرست مطالب

1. [مراحل بعدی](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [چه چیزی اضافه شد](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [صورتحساب](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [عیب‌یابی](../../../../../../04-PracticalImplementation/samples/csharp/src)

## مراحل بعدی

### آماده‌سازی زیرساخت و استقرار کد برنامه

اجرای `azd up` زیرساخت شما را آماده کرده و به Azure در یک مرحله مستقر می‌کند (یا `azd provision` و سپس `azd deploy` را اجرا کنید تا وظایف را جداگانه انجام دهید). به نقاط پایانی سرویس فهرست شده مراجعه کنید تا برنامه خود را در حال اجرا ببینید!

برای عیب‌یابی مشکلات، به [عیب‌یابی](../../../../../../04-PracticalImplementation/samples/csharp/src) مراجعه کنید.

### پیکربندی خط لوله CI/CD

اجرای `azd pipeline config -e <environment name>` خط لوله استقرار را برای اتصال امن به Azure پیکربندی می‌کند. در اینجا یک نام محیط مشخص شده است تا خط لوله را با محیطی متفاوت برای اهداف جداسازی پیکربندی کند. پس از این مرحله، `azd env list` و `azd env set` را اجرا کنید تا محیط پیش‌فرض را مجدداً انتخاب کنید.

- استقرار با `GitHub Actions`: هنگام درخواست برای ارائه‌دهنده، `GitHub` را انتخاب کنید. اگر پروژه شما فاقد فایل `azure-dev.yml` است، درخواست اضافه کردن آن را بپذیرید و با پیکربندی خط لوله ادامه دهید.

- استقرار با `Azure DevOps Pipeline`: هنگام درخواست برای ارائه‌دهنده، `Azure DevOps` را انتخاب کنید. اگر پروژه شما فاقد فایل `azure-dev.yml` است، درخواست اضافه کردن آن را بپذیرید و با پیکربندی خط لوله ادامه دهید.

## چه چیزی اضافه شد

### پیکربندی زیرساخت

برای توصیف زیرساخت و برنامه، یک `azure.yaml` با ساختار دایرکتوری زیر اضافه شد:

```yaml
- azure.yaml     # azd project configuration
```

این فایل شامل یک سرویس واحد است که به میزبان برنامه پروژه شما اشاره دارد. در صورت نیاز، `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` را اجرا کنید تا آن را روی دیسک ذخیره کنید.

اگر این کار را انجام دهید، برخی دایرکتوری‌های اضافی ایجاد خواهند شد:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

علاوه بر این، برای هر منبع پروژه که توسط میزبان برنامه شما اشاره شده است، یک `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` پروژه، به [مستندات](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert) رسمی ما مراجعه کنید.

**سلب مسئولیت**:  
این سند با استفاده از خدمات ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما برای دقت تلاش می‌کنیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نادرستی‌هایی باشند. سند اصلی به زبان بومی آن باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حساس، ترجمه انسانی حرفه‌ای توصیه می‌شود. ما مسئولیتی در قبال سوء تفاهم‌ها یا تفسیرهای نادرست ناشی از استفاده از این ترجمه نداریم.