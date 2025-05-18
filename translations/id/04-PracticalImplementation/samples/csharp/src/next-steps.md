<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:18:51+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "id"
}
-->
# Langkah Selanjutnya setelah `azd init`

## Daftar Isi

1. [Langkah Selanjutnya](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [Apa yang Ditambahkan](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [Penagihan](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [Pemecahan Masalah](../../../../../../04-PracticalImplementation/samples/csharp/src)

## Langkah Selanjutnya

### Menyediakan infrastruktur dan menerapkan kode aplikasi

Jalankan `azd up` untuk menyediakan infrastruktur Anda dan menerapkan ke Azure dalam satu langkah (atau jalankan `azd provision` kemudian `azd deploy` untuk menyelesaikan tugas secara terpisah). Kunjungi titik akhir layanan yang terdaftar untuk melihat aplikasi Anda berjalan!

Untuk memecahkan masalah apa pun, lihat [pemecahan masalah](../../../../../../04-PracticalImplementation/samples/csharp/src).

### Konfigurasi pipeline CI/CD

Jalankan `azd pipeline config -e <environment name>` untuk mengkonfigurasi pipeline penerapan agar terhubung dengan aman ke Azure. Nama lingkungan ditentukan di sini untuk mengkonfigurasi pipeline dengan lingkungan yang berbeda untuk tujuan isolasi. Jalankan `azd env list` dan `azd env set` untuk memilih kembali lingkungan default setelah langkah ini.

- Menerapkan dengan `GitHub Actions`: Pilih `GitHub` saat diminta untuk penyedia. Jika proyek Anda tidak memiliki file `azure-dev.yml`, terima prompt untuk menambahkannya dan lanjutkan dengan konfigurasi pipeline.

- Menerapkan dengan `Azure DevOps Pipeline`: Pilih `Azure DevOps` saat diminta untuk penyedia. Jika proyek Anda tidak memiliki file `azure-dev.yml`, terima prompt untuk menambahkannya dan lanjutkan dengan konfigurasi pipeline.

## Apa yang Ditambahkan

### Konfigurasi Infrastruktur

Untuk menggambarkan infrastruktur dan aplikasi, sebuah `azure.yaml` ditambahkan dengan struktur direktori berikut:

```yaml
- azure.yaml     # azd project configuration
```

File ini berisi satu layanan, yang merujuk ke App Host proyek Anda. Ketika diperlukan, `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` untuk menyimpannya ke disk.

Jika Anda melakukan ini, beberapa direktori tambahan akan dibuat:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

Selain itu, untuk setiap sumber daya proyek yang dirujuk oleh app host Anda, sebuah `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` proyek, kunjungi [dokumentasi](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert) resmi kami.

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk akurasi, harap diingat bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang berwenang. Untuk informasi yang kritis, disarankan menggunakan terjemahan manusia profesional. Kami tidak bertanggung jawab atas kesalahpahaman atau salah penafsiran yang timbul dari penggunaan terjemahan ini.