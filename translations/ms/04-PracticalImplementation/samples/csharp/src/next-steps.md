<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:19:01+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "ms"
}
-->
# Langkah Seterusnya selepas `azd init`

## Kandungan

1. [Langkah Seterusnya](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [Apa yang Ditambah](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [Penagihan](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [Penyelesaian Masalah](../../../../../../04-PracticalImplementation/samples/csharp/src)

## Langkah Seterusnya

### Sediakan infrastruktur dan lancarkan kod aplikasi

Jalankan `azd up` untuk menyediakan infrastruktur anda dan melancarkan ke Azure dalam satu langkah (atau jalankan `azd provision` kemudian `azd deploy` untuk menyelesaikan tugas secara berasingan). Lawati titik akhir perkhidmatan yang disenaraikan untuk melihat aplikasi anda berfungsi!

Untuk menyelesaikan sebarang masalah, lihat [penyelesaian masalah](../../../../../../04-PracticalImplementation/samples/csharp/src).

### Konfigurasi saluran paip CI/CD

Jalankan `azd pipeline config -e <environment name>` untuk mengkonfigurasi saluran paip pelancaran supaya bersambung dengan selamat ke Azure. Nama persekitaran ditentukan di sini untuk mengkonfigurasi saluran paip dengan persekitaran yang berbeza untuk tujuan pengasingan. Jalankan `azd env list` dan `azd env set` untuk memilih semula persekitaran lalai selepas langkah ini.

- Melancarkan dengan `GitHub Actions`: Pilih `GitHub` apabila diminta untuk penyedia. Jika projek anda tidak mempunyai fail `azure-dev.yml`, terima permintaan untuk menambahkannya dan teruskan dengan konfigurasi saluran paip.

- Melancarkan dengan `Azure DevOps Pipeline`: Pilih `Azure DevOps` apabila diminta untuk penyedia. Jika projek anda tidak mempunyai fail `azure-dev.yml`, terima permintaan untuk menambahkannya dan teruskan dengan konfigurasi saluran paip.

## Apa yang Ditambah

### Konfigurasi Infrastruktur

Untuk menerangkan infrastruktur dan aplikasi, satu `azure.yaml` telah ditambah dengan struktur direktori berikut:

```yaml
- azure.yaml     # azd project configuration
```

Fail ini mengandungi satu perkhidmatan, yang merujuk kepada App Host projek anda. Apabila diperlukan, `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` untuk menyimpannya ke cakera.

Jika anda melakukan ini, beberapa direktori tambahan akan dicipta:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

Sebagai tambahan, untuk setiap sumber projek yang dirujuk oleh hos aplikasi anda, satu `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` projek, lawati [dokumentasi rasmi](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert) kami.

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk mencapai ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang berwibawa. Untuk maklumat penting, terjemahan manusia profesional adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.