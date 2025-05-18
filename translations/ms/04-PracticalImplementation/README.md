<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-17T13:57:55+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "ms"
}
-->
# Pelaksanaan Praktikal

Pelaksanaan praktikal adalah di mana kekuatan Protokol Konteks Model (MCP) menjadi nyata. Walaupun memahami teori dan seni bina di sebalik MCP adalah penting, nilai sebenar muncul apabila anda menggunakan konsep-konsep ini untuk membina, menguji, dan menyebarkan penyelesaian yang menyelesaikan masalah dunia sebenar. Bab ini menjembatani jurang antara pengetahuan konseptual dan pembangunan secara langsung, membimbing anda melalui proses membawa aplikasi berasaskan MCP ke kehidupan.

Sama ada anda membangunkan pembantu pintar, mengintegrasikan AI ke dalam aliran kerja perniagaan, atau membina alat khusus untuk pemprosesan data, MCP menyediakan asas yang fleksibel. Reka bentuknya yang bebas bahasa dan SDK rasmi untuk bahasa pengaturcaraan popular menjadikannya mudah diakses oleh pelbagai pemaju. Dengan memanfaatkan SDK ini, anda boleh dengan cepat membuat prototaip, iterasi, dan menskalakan penyelesaian anda di pelbagai platform dan persekitaran.

Dalam bahagian berikut, anda akan menemui contoh praktikal, kod contoh, dan strategi penyebaran yang menunjukkan cara melaksanakan MCP dalam C#, Java, TypeScript, JavaScript, dan Python. Anda juga akan belajar cara menyahpepijat dan menguji pelayan MCP anda, menguruskan API, dan menyebarkan penyelesaian ke awan menggunakan Azure. Sumber-sumber praktikal ini direka untuk mempercepatkan pembelajaran anda dan membantu anda membina aplikasi MCP yang mantap dan siap untuk produksi dengan yakin.

## Gambaran Keseluruhan

Pelajaran ini menumpukan kepada aspek praktikal pelaksanaan MCP merentasi pelbagai bahasa pengaturcaraan. Kami akan meneroka cara menggunakan SDK MCP dalam C#, Java, TypeScript, JavaScript, dan Python untuk membina aplikasi yang mantap, menyahpepijat dan menguji pelayan MCP, serta mencipta sumber, petunjuk, dan alat yang boleh digunakan semula.

## Objektif Pembelajaran

Menjelang akhir pelajaran ini, anda akan dapat:
- Melaksanakan penyelesaian MCP menggunakan SDK rasmi dalam pelbagai bahasa pengaturcaraan
- Menyahpepijat dan menguji pelayan MCP secara sistematik
- Mencipta dan menggunakan ciri pelayan (Sumber, Petunjuk, dan Alat)
- Mereka bentuk aliran kerja MCP yang berkesan untuk tugas yang kompleks
- Mengoptimumkan pelaksanaan MCP untuk prestasi dan kebolehpercayaan

## Sumber SDK Rasmi

Protokol Konteks Model menawarkan SDK rasmi untuk pelbagai bahasa:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Bekerja dengan SDK MCP

Bahagian ini menyediakan contoh praktikal pelaksanaan MCP merentasi pelbagai bahasa pengaturcaraan. Anda boleh menemui kod contoh dalam direktori `samples` yang disusun mengikut bahasa.

### Contoh Tersedia

Repositori ini termasuk pelaksanaan contoh dalam bahasa berikut:

- C#
- Java
- TypeScript
- JavaScript
- Python

Setiap contoh menunjukkan konsep MCP utama dan corak pelaksanaan untuk bahasa dan ekosistem tertentu.

## Ciri Pelayan Teras

Pelayan MCP boleh melaksanakan mana-mana kombinasi ciri-ciri ini:

### Sumber
Sumber menyediakan konteks dan data untuk digunakan oleh pengguna atau model AI:
- Repositori dokumen
- Pangkalan pengetahuan
- Sumber data berstruktur
- Sistem fail

### Petunjuk
Petunjuk adalah mesej templat dan aliran kerja untuk pengguna:
- Templat perbualan pra-didefinisikan
- Corak interaksi berpandu
- Struktur dialog khusus

### Alat
Alat adalah fungsi untuk model AI melaksanakan:
- Utiliti pemprosesan data
- Integrasi API luaran
- Keupayaan pengiraan
- Fungsi carian

## Pelaksanaan Contoh: C#

Repositori SDK rasmi C# mengandungi beberapa pelaksanaan contoh yang menunjukkan pelbagai aspek MCP:

- **Pelanggan MCP Asas**: Contoh mudah menunjukkan cara membuat pelanggan MCP dan memanggil alat
- **Pelayan MCP Asas**: Pelaksanaan pelayan minimal dengan pendaftaran alat asas
- **Pelayan MCP Lanjutan**: Pelayan lengkap dengan pendaftaran alat, pengesahan, dan pengendalian ralat
- **Integrasi ASP.NET**: Contoh menunjukkan integrasi dengan ASP.NET Core
- **Corak Pelaksanaan Alat**: Pelbagai corak untuk melaksanakan alat dengan tahap kerumitan yang berbeza

SDK MCP C# berada dalam pratonton dan API mungkin berubah. Kami akan sentiasa mengemas kini blog ini semasa SDK berkembang.

### Ciri Utama 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Membina [pelayan MCP pertama anda](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Untuk pelaksanaan C# lengkap, lawati [repositori sampel SDK C# rasmi](https://github.com/modelcontextprotocol/csharp-sdk)

## Pelaksanaan Contoh: Pelaksanaan Java

SDK Java menawarkan pilihan pelaksanaan MCP yang kukuh dengan ciri-ciri bertaraf perusahaan.

### Ciri Utama

- Integrasi Rangka Kerja Spring
- Keselamatan jenis yang kuat
- Sokongan pengaturcaraan reaktif
- Pengendalian ralat yang komprehensif

Untuk contoh pelaksanaan Java lengkap, lihat [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) dalam direktori sampel.

## Pelaksanaan Contoh: Pelaksanaan JavaScript

SDK JavaScript menyediakan pendekatan ringan dan fleksibel untuk pelaksanaan MCP.

### Ciri Utama

- Sokongan Node.js dan pelayar
- API berasaskan janji
- Integrasi mudah dengan Express dan rangka kerja lain
- Sokongan WebSocket untuk penstriman

Untuk contoh pelaksanaan JavaScript lengkap, lihat [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) dalam direktori sampel.

## Pelaksanaan Contoh: Pelaksanaan Python

SDK Python menawarkan pendekatan Pythonik untuk pelaksanaan MCP dengan integrasi rangka kerja ML yang cemerlang.

### Ciri Utama

- Sokongan async/await dengan asyncio
- Integrasi Flask dan FastAPI
- Pendaftaran alat yang mudah
- Integrasi asli dengan perpustakaan ML popular

Untuk contoh pelaksanaan Python lengkap, lihat [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) dalam direktori sampel.

## Pengurusan API 

Pengurusan API Azure adalah jawapan yang hebat untuk bagaimana kita boleh mengamankan Pelayan MCP. Idea adalah untuk meletakkan satu contoh Pengurusan API Azure di hadapan Pelayan MCP anda dan membiarkannya mengendalikan ciri-ciri yang anda mungkin mahu seperti:

- had kadar
- pengurusan token
- pemantauan
- imbangan beban
- keselamatan

### Sampel Azure

Berikut adalah Sampel Azure yang melakukan perkara itu, iaitu [mencipta Pelayan MCP dan mengamankannya dengan Pengurusan API Azure](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Lihat bagaimana aliran kebenaran berlaku dalam imej di bawah:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Dalam imej yang terdahulu, perkara berikut berlaku:

- Pengesahan/Pemberian kuasa berlaku menggunakan Microsoft Entra.
- Pengurusan API Azure bertindak sebagai pintu masuk dan menggunakan dasar untuk mengarahkan dan menguruskan trafik.
- Azure Monitor merekodkan semua permintaan untuk analisis lanjut.

#### Aliran kebenaran

Mari kita lihat aliran kebenaran dengan lebih terperinci:

![Rajah Urutan](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Spesifikasi kebenaran MCP

Ketahui lebih lanjut tentang [spesifikasi Kebenaran MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Menyebarkan Pelayan MCP Jauh ke Azure

Mari kita lihat jika kita boleh menyebarkan sampel yang kita sebutkan sebelum ini:

1. Klon repositori

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Daftar `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` selepas beberapa masa untuk memeriksa jika pendaftaran selesai.

2. Jalankan perintah [azd](https://aka.ms/azd) ini untuk menyediakan perkhidmatan pengurusan api, aplikasi fungsi (dengan kod) dan semua sumber Azure lain yang diperlukan

    ```shell
    azd up
    ```

    Perintah ini sepatutnya menyebarkan semua sumber awan di Azure

### Menguji pelayan anda dengan MCP Inspector

1. Dalam **tetingkap terminal baru**, pasang dan jalankan MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Anda sepatutnya melihat antara muka yang serupa dengan:

    ![Sambung ke Node inspector](../../../translated_images/connect.126df3a6deef0d2e0850b1a5cf0547c8fc4e2e9e0b354238d0a9dbe7893726fa.ms.png)

1. Klik CTRL untuk memuatkan aplikasi web MCP Inspector dari URL yang dipaparkan oleh aplikasi (contoh: http://127.0.0.1:6274/#resources)
1. Tetapkan jenis pengangkutan kepada `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` dan **Sambung**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Senaraikan Alat**. Klik pada alat dan **Jalankan Alat**.  

Jika semua langkah telah berjaya, anda sepatutnya kini bersambung ke pelayan MCP dan anda telah dapat memanggil alat.

## Pelayan MCP untuk Azure 

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Set repositori ini adalah templat permulaan cepat untuk membina dan menyebarkan pelayan MCP (Model Context Protocol) jauh yang khusus menggunakan Fungsi Azure dengan Python, C# .NET atau Node/TypeScript. 

Sampel menyediakan penyelesaian lengkap yang membolehkan pembangun untuk:

- Membina dan menjalankan secara tempatan: Membangun dan menyahpepijat pelayan MCP pada mesin tempatan
- Menyebarkan ke Azure: Mudah menyebarkan ke awan dengan perintah azd up yang mudah
- Menyambung dari pelanggan: Sambung ke pelayan MCP dari pelbagai pelanggan termasuk mod ejen Copilot VS Code dan alat MCP Inspector

### Ciri Utama:

- Keselamatan melalui reka bentuk: Pelayan MCP diamankan menggunakan kunci dan HTTPS
- Pilihan pengesahan: Menyokong OAuth menggunakan pengesahan terbina dalam dan/atau Pengurusan API
- Pengasingan rangkaian: Membolehkan pengasingan rangkaian menggunakan Rangkaian Maya Azure (VNET)
- Seni bina tanpa pelayan: Memanfaatkan Fungsi Azure untuk pelaksanaan yang boleh diskalakan dan didorong oleh peristiwa
- Pembangunan tempatan: Sokongan pembangunan dan penyahpepijatan tempatan yang komprehensif
- Penyebaran mudah: Proses penyebaran yang dipermudah ke Azure

Repositori ini termasuk semua fail konfigurasi yang diperlukan, kod sumber, dan definisi infrastruktur untuk memulakan pelaksanaan pelayan MCP yang siap untuk produksi dengan cepat.

- [Fungsi MCP Jauh Azure Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Pelaksanaan contoh MCP menggunakan Fungsi Azure dengan Python

- [Fungsi MCP Jauh Azure .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Pelaksanaan contoh MCP menggunakan Fungsi Azure dengan C# .NET

- [Fungsi MCP Jauh Azure Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Pelaksanaan contoh MCP menggunakan Fungsi Azure dengan Node/TypeScript.

## Poin Penting

- SDK MCP menyediakan alat khusus bahasa untuk melaksanakan penyelesaian MCP yang mantap
- Proses penyahpepijatan dan pengujian adalah kritikal untuk aplikasi MCP yang boleh dipercayai
- Templat petunjuk yang boleh digunakan semula membolehkan interaksi AI yang konsisten
- Aliran kerja yang direka dengan baik boleh mengatur tugas yang kompleks menggunakan pelbagai alat
- Melaksanakan penyelesaian MCP memerlukan pertimbangan keselamatan, prestasi, dan pengendalian ralat

## Latihan

Reka bentuk aliran kerja MCP praktikal yang menangani masalah dunia sebenar dalam domain anda:

1. Kenal pasti 3-4 alat yang akan berguna untuk menyelesaikan masalah ini
2. Cipta rajah aliran kerja yang menunjukkan bagaimana alat-alat ini berinteraksi
3. Laksanakan versi asas salah satu alat menggunakan bahasa pilihan anda
4. Cipta templat petunjuk yang akan membantu model menggunakan alat anda dengan berkesan

## Sumber Tambahan

---

Seterusnya: [Topik Lanjutan](../05-AdvancedTopics/README.md)

**Penafian**: 
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang berwibawa. Untuk maklumat kritikal, terjemahan manusia profesional adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau tafsiran yang salah yang timbul daripada penggunaan terjemahan ini.