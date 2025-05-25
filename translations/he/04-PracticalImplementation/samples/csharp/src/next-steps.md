<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:18:22+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "he"
}
-->
# השלבים הבאים אחרי `azd init`

## תוכן עניינים

1. [השלבים הבאים](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [מה נוסף](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [חיוב](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [פתרון בעיות](../../../../../../04-PracticalImplementation/samples/csharp/src)

## השלבים הבאים

### הקמת תשתית ופריסת קוד יישום

הרץ את `azd up` כדי להקים את התשתית שלך ולפרוס ל-Azure בצעד אחד (או הרץ את `azd provision` ואז `azd deploy` כדי לבצע את המשימות בנפרד). בקר בנקודות הקצה של השירות המופיעות כדי לראות את היישום שלך פועל!

לפתרון בעיות כלשהן, ראה [פתרון בעיות](../../../../../../04-PracticalImplementation/samples/csharp/src).

### הגדרת צינור CI/CD

הרץ את `azd pipeline config -e <environment name>` כדי להגדיר את צינור הפריסה להתחבר בצורה מאובטחת ל-Azure. שם סביבה מצוין כאן כדי להגדיר את הצינור עם סביבה שונה לצורכי בידוד. הרץ את `azd env list` ו-`azd env set` כדי לבחור מחדש את הסביבה ברירת המחדל אחרי שלב זה.

- פריסה עם `GitHub Actions`: בחר `GitHub` כאשר תתבקש לספק. אם הפרויקט שלך חסר את קובץ `azure-dev.yml`, קבל את ההנחיה להוסיפו והמשך בהגדרת הצינור.

- פריסה עם `Azure DevOps Pipeline`: בחר `Azure DevOps` כאשר תתבקש לספק. אם הפרויקט שלך חסר את קובץ `azure-dev.yml`, קבל את ההנחיה להוסיפו והמשך בהגדרת הצינור.

## מה נוסף

### הגדרת תשתית

כדי לתאר את התשתית והיישום, נוסף `azure.yaml` עם מבנה הספרייה הבא:

```yaml
- azure.yaml     # azd project configuration
```

קובץ זה מכיל שירות יחיד, אשר מתייחס למארח האפליקציה של הפרויקט שלך. כאשר נדרש, `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` כדי לשמור אותו לדיסק.

אם תעשה זאת, ייווצרו כמה ספריות נוספות:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

בנוסף, עבור כל משאב פרויקט שמוזכר על ידי מארח האפליקציה שלך, `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` פרויקט, בקר במסמכים הרשמיים שלנו [docs](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert).

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום AI [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש להיות מודעים לכך שתרגומים אוטומטיים עלולים להכיל שגיאות או אי דיוקים. המסמך המקורי בשפתו המקורית יש להחשיב כמקור הסמכותי. עבור מידע קריטי, מומלץ להשתמש בתרגום אנושי מקצועי. איננו אחראים לאי הבנות או לפרשנויות מוטעות הנובעות משימוש בתרגום זה.