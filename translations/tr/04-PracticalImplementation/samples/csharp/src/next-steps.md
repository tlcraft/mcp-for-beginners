<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:16:49+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "tr"
}
-->
# `azd init` Sonrası Adımlar

## İçindekiler

1. [Sonraki Adımlar](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [Neler Eklendi](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [Faturalama](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [Sorun Giderme](../../../../../../04-PracticalImplementation/samples/csharp/src)

## Sonraki Adımlar

### Altyapıyı hazırlayın ve uygulama kodunu dağıtın

Altyapınızı hazırlamak ve Azure'a tek adımda dağıtmak için `azd up` çalıştırın (veya görevleri ayrı ayrı gerçekleştirmek için önce `azd provision` ardından `azd deploy` çalıştırın). Uygulamanızın çalıştığını görmek için listelenen servis uç noktalarını ziyaret edin!

Herhangi bir sorunu gidermek için [sorun giderme](../../../../../../04-PracticalImplementation/samples/csharp/src) bölümüne bakın.

### CI/CD hattını yapılandırın

Azure'a güvenli bir şekilde bağlanmak için dağıtım hattını yapılandırmak için `azd pipeline config -e <environment name>` çalıştırın. İzolasyon amacıyla farklı bir ortamla hattı yapılandırmak için burada bir ortam adı belirtilir. Bu adımdan sonra varsayılan ortamı yeniden seçmek için `azd env list` ve `azd env set` çalıştırın.

- `GitHub Actions` ile dağıtım: Sağlayıcı için sorulduğunda `GitHub` seçin. Projenizde `azure-dev.yml` dosyası yoksa, ekleme isteğini kabul edin ve hat yapılandırmasına devam edin.

- `Azure DevOps Pipeline` ile dağıtım: Sağlayıcı için sorulduğunda `Azure DevOps` seçin. Projenizde `azure-dev.yml` dosyası yoksa, ekleme isteğini kabul edin ve hat yapılandırmasına devam edin.

## Neler Eklendi

### Altyapı yapılandırması

Altyapıyı ve uygulamayı tanımlamak için aşağıdaki dizin yapısıyla bir `azure.yaml` eklendi:

```yaml
- azure.yaml     # azd project configuration
```

Bu dosya, projenizin Uygulama Sunucusuna referans veren tek bir servis içerir. Gerektiğinde, `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` kullanarak diske kaydedebilirsiniz.

Bunu yaparsanız, bazı ek dizinler oluşturulacaktır:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

Ek olarak, uygulama sunucunuzun referans verdiği her proje kaynağı için bir `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` projesi oluşturulacaktır. Resmi [dokümanlarımıza](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert) göz atın.

**Feragatname**: 
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hata veya yanlışlık içerebileceğini unutmayın. Belgenin kendi dilindeki orijinali yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımından kaynaklanan yanlış anlamalar veya yanlış yorumlamalardan sorumlu değiliz.