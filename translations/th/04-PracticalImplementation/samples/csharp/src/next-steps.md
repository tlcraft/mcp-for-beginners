<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:17:11+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "th"
}
-->
# ขั้นตอนต่อไปหลังจาก `azd init`

## สารบัญ

1. [ขั้นตอนต่อไป](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [สิ่งที่ถูกเพิ่มเข้ามา](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [การเรียกเก็บเงิน](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [การแก้ไขปัญหา](../../../../../../04-PracticalImplementation/samples/csharp/src)

## ขั้นตอนต่อไป

### จัดเตรียมโครงสร้างพื้นฐานและปรับใช้โค้ดแอปพลิเคชัน

รัน `azd up` เพื่อจัดเตรียมโครงสร้างพื้นฐานและปรับใช้กับ Azure ในขั้นตอนเดียว (หรือรัน `azd provision` แล้ว `azd deploy` เพื่อทำงานแยกต่างหาก) เยี่ยมชมจุดสิ้นสุดของบริการที่ระบุเพื่อดูแอปพลิเคชันของคุณทำงาน!

หากมีปัญหาใดๆ ให้ดูที่ [การแก้ไขปัญหา](../../../../../../04-PracticalImplementation/samples/csharp/src)

### ตั้งค่า CI/CD pipeline

รัน `azd pipeline config -e <environment name>` เพื่อกำหนดค่า pipeline การปรับใช้ให้เชื่อมต่อกับ Azure อย่างปลอดภัย ชื่อของสภาพแวดล้อมจะถูกระบุที่นี่เพื่อกำหนดค่า pipeline ด้วยสภาพแวดล้อมที่แตกต่างกันเพื่อจุดประสงค์ในการแยก รัน `azd env list` และ `azd env set` เพื่อเลือกสภาพแวดล้อมเริ่มต้นอีกครั้งหลังจากขั้นตอนนี้

- การปรับใช้ด้วย `GitHub Actions`: เลือก `GitHub` เมื่อถูกถามหาผู้ให้บริการ หากโครงการของคุณไม่มีไฟล์ `azure-dev.yml` ให้ยอมรับการแจ้งเตือนเพื่อเพิ่มไฟล์และดำเนินการกำหนดค่า pipeline

- การปรับใช้ด้วย `Azure DevOps Pipeline`: เลือก `Azure DevOps` เมื่อถูกถามหาผู้ให้บริการ หากโครงการของคุณไม่มีไฟล์ `azure-dev.yml` ให้ยอมรับการแจ้งเตือนเพื่อเพิ่มไฟล์และดำเนินการกำหนดค่า pipeline

## สิ่งที่ถูกเพิ่มเข้ามา

### การกำหนดค่าโครงสร้างพื้นฐาน

เพื่ออธิบายโครงสร้างพื้นฐานและแอปพลิเคชัน, `azure.yaml` ถูกเพิ่มเข้ามาพร้อมกับโครงสร้างไดเรกทอรีดังนี้:

```yaml
- azure.yaml     # azd project configuration
```

ไฟล์นี้ประกอบด้วยบริการเดียว ซึ่งอ้างอิงถึง App Host ของโครงการของคุณ เมื่อจำเป็น, `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` เพื่อบันทึกมันลงดิสก์

หากคุณทำเช่นนี้ ไดเรกทอรีเพิ่มเติมบางแห่งจะถูกสร้างขึ้น:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

นอกจากนี้ สำหรับทรัพยากรโครงการแต่ละรายการที่อ้างอิงโดย App Host ของคุณ, `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` project, เยี่ยมชม [เอกสาร](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert) อย่างเป็นทางการของเรา

**คำปฏิเสธความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษา AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้มีความถูกต้อง แต่โปรดทราบว่าการแปลโดยอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาที่ใช้งานควรถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ แนะนำให้ใช้บริการแปลภาษามนุษย์มืออาชีพ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดที่เกิดจากการใช้การแปลนี้