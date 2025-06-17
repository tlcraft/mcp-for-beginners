<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-06-17T17:06:26+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "my"
}
-->
# `azd init` ပြီးနောက် လုပ်ဆောင်ရမည့် နောက်တစ်ဆင့်များ

## အကြောင်းအရာ စာရင်း

1. [နောက်တစ်ဆင့်များ](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [ထည့်သွင်းထားသော အရာများ](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [ဘီလ်ချိန်းခြင်း](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [ပြဿနာဖြေရှင်းခြင်း](../../../../../../04-PracticalImplementation/samples/csharp/src)

## နောက်တစ်ဆင့်များ

### အင်ဖရာစထရပ်ချာကို ပြင်ဆင်ပြီး အက်ပလီကေးရှင်း ကုဒ် တင်သွင်းခြင်း

`azd up` ကို အသုံးပြု၍ သင့်အင်ဖရာစထရပ်ချာကို တစ်ဆင့်တည်း ပြင်ဆင်ပြီး Azure သို့ တင်သွင်းနိုင်သည် (သို့မဟုတ် `azd provision` ပြီးနောက် `azd deploy` ကို သီးခြားအဆင့်ဖြင့် အလုပ်လုပ်နိုင်သည်)။ သင့်အက်ပလီကေးရှင်း တက်ကြွစွာ လည်ပတ်နေမှုကို ကြည့်ရှုရန် ဝန်ဆောင်မှု အဆုံးအချက်များကို လည်ပတ်ကြည့်ပါ။

ပြဿနာတစ်ခုခု ဖြစ်ပေါ်ပါက [ပြဿနာဖြေရှင်းခြင်း](../../../../../../04-PracticalImplementation/samples/csharp/src) ကို ကြည့်ပါ။

### CI/CD လမ်းကြောင်းကို ဆက်တင်ခြင်း

`azd pipeline config -e <environment name>` ကို အသုံးပြု၍ Azure နှင့် လုံခြုံစိတ်ချစွာ ချိတ်ဆက်ထားသော တင်သွင်းမှု လမ်းကြောင်းကို ဆက်တင်နိုင်သည်။ ပတ်ဝန်းကျင်အမည်ကို ဒီမှာ သတ်မှတ်ထားပြီး isolation ရည်ရွယ်ချက်ဖြင့် အခြားပတ်ဝန်းကျင်ဖြင့် လမ်းကြောင်းကို ဆက်တင်သည်။ ဒီအဆင့်ပြီးလျှင် `azd env list` နှင့် `azd env set` ကို ပြန်လည်ရွေးချယ်ရန် အသုံးပြုပါ။

- `GitHub Actions` ဖြင့် တင်သွင်းခြင်း: provider မေးမြန်းသောအခါ `GitHub` ကို ရွေးချယ်ပါ။ သင့်ပရောဂျက်တွင် `azure-dev.yml` ဖိုင် မရှိပါက ထည့်သွင်းရန် မေးမြန်းမှုကို လက်ခံပြီး လမ်းကြောင်း ဆက်တင်ခြင်းကို ဆက်လက်လုပ်ဆောင်ပါ။

- `Azure DevOps Pipeline` ဖြင့် တင်သွင်းခြင်း: provider မေးမြန်းသောအခါ `Azure DevOps` ကို ရွေးချယ်ပါ။ သင့်ပရောဂျက်တွင် `azure-dev.yml` ဖိုင် မရှိပါက ထည့်သွင်းရန် မေးမြန်းမှုကို လက်ခံပြီး လမ်းကြောင်း ဆက်တင်ခြင်းကို ဆက်လက်လုပ်ဆောင်ပါ။

## ထည့်သွင်းထားသော အရာများ

### အင်ဖရာစထရပ်ချာ ဆက်တင်ခြင်း

အင်ဖရာစထရပ်ချာနှင့် အက်ပလီကေးရှင်းကို ဖော်ပြရန် `azure.yaml` တစ်ခုကို အောက်ပါ ဖိုင်ဖွဲ့စည်းမှုဖြင့် ထည့်သွင်းထားသည်-

```yaml
- azure.yaml     # azd project configuration
```

ဤဖိုင်တွင် တစ်ခုတည်းသော ဝန်ဆောင်မှုတစ်ခု ပါဝင်ပြီး သင့်ပရောဂျက်၏ App Host ကို ရည်ညွှန်းထားသည်။ လိုအပ်ပါက `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` ကို အသုံးပြု၍ ဒစ်စခ်တွင် သိမ်းဆည်းထားနိုင်သည်။

ဒါလုပ်ပါက အောက်ပါ ဖိုင်ဖိုဒါများ အပိုထပ်မံဖန်တီးမည်-

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

ထို့အပြင် သင့် app host မှ ရည်ညွှန်းထားသော ပရောဂျက် အရင်းအမြစ်တိုင်းအတွက် `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` ပရောဂျက်များရှိပါက ကျွန်ုပ်တို့၏ တရားဝင် [စာတမ်းများ](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert) တွင် လေ့လာနိုင်ပါသည်။

**အချက်ပေးချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ခြင်းဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးပမ်းပါသော်လည်း အလိုအလျောက်ဘာသာပြန်ခြင်းများတွင် အမှားများ သို့မဟုတ် မှားယွင်းမှုများ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူလစာတမ်းကို မူရင်းဘာသာဖြင့်သာ အတည်ပြုရမည့် အချက်အလက်အရင်းအမြစ်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူကြီးမင်းသည် ပရော်ဖက်ရှင်နယ် လူ့ဘာသာပြန်ခြင်းကို အသုံးပြုရန် အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားခြင်းများ သို့မဟုတ် အဓိပ္ပာယ်မှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မခံပါ။