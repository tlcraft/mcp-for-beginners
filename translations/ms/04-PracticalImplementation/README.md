<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d88dbf928fa0f159b82312e9a6757ba0",
  "translation_date": "2025-06-18T09:22:56+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "ms"
}
-->
# Pelaksanaan Praktikal

Pelaksanaan praktikal adalah di mana kuasa Model Context Protocol (MCP) menjadi nyata. Walaupun memahami teori dan seni bina di sebalik MCP adalah penting, nilai sebenar muncul apabila anda menerapkan konsep ini untuk membina, menguji, dan melaksanakan penyelesaian yang menyelesaikan masalah dunia sebenar. Bab ini menjembatani jurang antara pengetahuan konseptual dan pembangunan praktikal, membimbing anda melalui proses membawa aplikasi berasaskan MCP menjadi kenyataan.

Sama ada anda sedang membangunkan pembantu pintar, mengintegrasikan AI ke dalam aliran kerja perniagaan, atau membina alat khusus untuk pemprosesan data, MCP menyediakan asas yang fleksibel. Reka bentuknya yang bebas bahasa dan SDK rasmi untuk bahasa pengaturcaraan popular menjadikannya boleh diakses oleh pelbagai pembangun. Dengan memanfaatkan SDK ini, anda boleh dengan cepat membuat prototaip, mengulangi, dan mengembangkan penyelesaian anda merentasi pelbagai platform dan persekitaran.

Dalam bahagian berikut, anda akan menemui contoh praktikal, kod contoh, dan strategi pelaksanaan yang menunjukkan cara melaksanakan MCP dalam C#, Java, TypeScript, JavaScript, dan Python. Anda juga akan belajar cara mengesan dan menguji pelayan MCP anda, mengurus API, dan melaksanakan penyelesaian ke awan menggunakan Azure. Sumber praktikal ini direka untuk mempercepatkan pembelajaran anda dan membantu anda membina aplikasi MCP yang kukuh dan sedia produksi dengan yakin.

## Gambaran Keseluruhan

Pelajaran ini memfokuskan pada aspek praktikal pelaksanaan MCP merentasi pelbagai bahasa pengaturcaraan. Kami akan meneroka cara menggunakan SDK MCP dalam C#, Java, TypeScript, JavaScript, dan Python untuk membina aplikasi yang kukuh, mengesan dan menguji pelayan MCP, serta mencipta sumber, prompt, dan alat yang boleh digunakan semula.

## Objektif Pembelajaran

Menjelang akhir pelajaran ini, anda akan dapat:
- Melaksanakan penyelesaian MCP menggunakan SDK rasmi dalam pelbagai bahasa pengaturcaraan
- Mengesan dan menguji pelayan MCP secara sistematik
- Mencipta dan menggunakan ciri pelayan (Sumber, Prompt, dan Alat)
- Mereka bentuk aliran kerja MCP yang berkesan untuk tugasan kompleks
- Mengoptimumkan pelaksanaan MCP untuk prestasi dan kebolehpercayaan

## Sumber SDK Rasmi

Model Context Protocol menawarkan SDK rasmi untuk pelbagai bahasa:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Bekerja dengan SDK MCP

Bahagian ini menyediakan contoh praktikal pelaksanaan MCP merentasi pelbagai bahasa pengaturcaraan. Anda boleh menemui kod contoh dalam direktori `samples` yang diatur mengikut bahasa.

### Contoh Tersedia

Repositori ini mengandungi [pelaksanaan contoh](../../../04-PracticalImplementation/samples) dalam bahasa berikut:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Setiap contoh menunjukkan konsep utama MCP dan corak pelaksanaan untuk bahasa dan ekosistem tertentu.

## Ciri Utama Pelayan

Pelayan MCP boleh melaksanakan apa-apa gabungan ciri berikut:

### Sumber  
Sumber menyediakan konteks dan data untuk digunakan oleh pengguna atau model AI:  
- Repositori dokumen  
- Pangkalan pengetahuan  
- Sumber data berstruktur  
- Sistem fail  

### Prompt  
Prompt adalah mesej dan aliran kerja berformat untuk pengguna:  
- Templat perbualan yang telah ditetapkan  
- Corak interaksi berpandu  
- Struktur dialog khusus  

### Alat  
Alat adalah fungsi yang boleh dijalankan oleh model AI:  
- Utiliti pemprosesan data  
- Integrasi API luaran  
- Keupayaan pengiraan  
- Fungsi carian  

## Pelaksanaan Contoh: C#

Repositori SDK C# rasmi mengandungi beberapa pelaksanaan contoh yang menunjukkan pelbagai aspek MCP:

- **Klien MCP Asas**: Contoh ringkas menunjukkan cara mencipta klien MCP dan memanggil alat  
- **Pelayan MCP Asas**: Pelaksanaan pelayan minimum dengan pendaftaran alat asas  
- **Pelayan MCP Lanjutan**: Pelayan lengkap dengan pendaftaran alat, pengesahan, dan pengendalian ralat  
- **Integrasi ASP.NET**: Contoh yang menunjukkan integrasi dengan ASP.NET Core  
- **Corak Pelaksanaan Alat**: Pelbagai corak untuk melaksanakan alat dengan tahap kerumitan berbeza  

SDK MCP C# masih dalam pratonton dan API mungkin berubah. Kami akan sentiasa mengemas kini blog ini selaras dengan evolusi SDK.

### Ciri Utama  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Membina [Pelayan MCP pertama anda](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Untuk contoh pelaksanaan C# lengkap, lawati [repositori contoh SDK C# rasmi](https://github.com/modelcontextprotocol/csharp-sdk)

## Pelaksanaan Contoh: Pelaksanaan Java

SDK Java menawarkan pilihan pelaksanaan MCP yang kukuh dengan ciri tahap perusahaan.

### Ciri Utama

- Integrasi Spring Framework  
- Keselamatan jenis yang kuat  
- Sokongan pengaturcaraan reaktif  
- Pengendalian ralat yang komprehensif  

Untuk contoh pelaksanaan Java lengkap, lihat [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) dalam direktori contoh.

## Pelaksanaan Contoh: Pelaksanaan JavaScript

SDK JavaScript menyediakan pendekatan ringan dan fleksibel untuk pelaksanaan MCP.

### Ciri Utama

- Sokongan Node.js dan pelayar  
- API berasaskan janji (Promise)  
- Integrasi mudah dengan Express dan rangka kerja lain  
- Sokongan WebSocket untuk penstriman  

Untuk contoh pelaksanaan JavaScript lengkap, lihat [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) dalam direktori contoh.

## Pelaksanaan Contoh: Pelaksanaan Python

SDK Python menawarkan pendekatan Pythonik untuk pelaksanaan MCP dengan integrasi rangka kerja ML yang cemerlang.

### Ciri Utama

- Sokongan async/await dengan asyncio  
- Integrasi Flask dan FastAPI  
- Pendaftaran alat yang mudah  
- Integrasi asli dengan perpustakaan ML popular  

Untuk contoh pelaksanaan Python lengkap, lihat [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) dalam direktori contoh.

## Pengurusan API

Azure API Management adalah jawapan yang baik untuk bagaimana kita boleh mengamankan Pelayan MCP. Idéanya adalah untuk meletakkan instans Azure API Management di hadapan Pelayan MCP anda dan membiarkannya mengendalikan ciri-ciri yang anda mungkin perlukan seperti:

- had kadar  
- pengurusan token  
- pemantauan  
- pengimbangan beban  
- keselamatan  

### Contoh Azure

Berikut adalah Contoh Azure yang melakukan perkara tersebut, iaitu [mencipta Pelayan MCP dan mengamankannya dengan Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Lihat bagaimana aliran pengesahan berlaku dalam imej di bawah:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Dalam imej di atas, perkara berikut berlaku:

- Pengesahan/Pemberian kebenaran berlaku menggunakan Microsoft Entra.  
- Azure API Management bertindak sebagai pintu masuk dan menggunakan polisi untuk mengarahkan dan mengurus trafik.  
- Azure Monitor merekod semua permintaan untuk analisis lanjut.  

#### Aliran Pemberian Kebenaran

Mari kita lihat lebih terperinci aliran pemberian kebenaran:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Spesifikasi Pemberian Kebenaran MCP

Ketahui lebih lanjut tentang [spesifikasi Pemberian Kebenaran MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Melaksanakan Pelayan MCP Jauh ke Azure

Mari kita lihat jika kita boleh melaksanakan contoh yang disebutkan sebelum ini:

1. Klon repositori

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. Daftar `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` selepas beberapa ketika untuk memeriksa jika pendaftaran selesai.

3. Jalankan arahan [azd](https://aka.ms/azd) ini untuk menyediakan perkhidmatan pengurusan API, fungsi app (dengan kod) dan semua sumber Azure lain yang diperlukan

    ```shell
    azd up
    ```

    Arahan ini akan melaksanakan semua sumber awan di Azure

### Menguji pelayan anda dengan MCP Inspector

1. Dalam **tetingkap terminal baru**, pasang dan jalankan MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Anda akan melihat antara muka seperti berikut:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ms.png) 

2. CTRL klik untuk memuatkan aplikasi web MCP Inspector dari URL yang dipaparkan oleh aplikasi (contoh http://127.0.0.1:6274/#resources)  
3. Tetapkan jenis pengangkutan kepada `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` dan **Sambung**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Senaraikan Alat**. Klik pada alat dan **Jalankan Alat**.  

Jika semua langkah berjaya, anda kini harus bersambung ke pelayan MCP dan telah berjaya memanggil sebuah alat.

## Pelayan MCP untuk Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Set repositori ini adalah templat permulaan pantas untuk membina dan melaksanakan pelayan MCP jauh khusus menggunakan Azure Functions dengan Python, C# .NET atau Node/TypeScript.

Contoh menyediakan penyelesaian lengkap yang membolehkan pembangun untuk:

- Membina dan menjalankan secara tempatan: Membangun dan mengesan pelayan MCP di mesin tempatan  
- Melaksanakan ke Azure: Mudah melaksanakan ke awan dengan arahan azd up yang ringkas  
- Bersambung dari klien: Bersambung ke pelayan MCP dari pelbagai klien termasuk mod ejen Copilot VS Code dan alat MCP Inspector  

### Ciri Utama:

- Keselamatan secara reka bentuk: Pelayan MCP dilindungi menggunakan kunci dan HTTPS  
- Pilihan pengesahan: Menyokong OAuth menggunakan pengesahan terbina dalam dan/atau Pengurusan API  
- Pengasingan rangkaian: Membolehkan pengasingan rangkaian menggunakan Azure Virtual Networks (VNET)  
- Seni bina tanpa pelayan: Menggunakan Azure Functions untuk pelaksanaan berskala dan dipacu acara  
- Pembangunan tempatan: Sokongan pembangunan dan pengesanan tempatan yang komprehensif  
- Pelaksanaan mudah: Proses pelaksanaan yang dipermudahkan ke Azure  

Repositori mengandungi semua fail konfigurasi, kod sumber, dan definisi infrastruktur yang diperlukan untuk memulakan pelaksanaan pelayan MCP yang sedia produksi dengan cepat.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Pelaksanaan contoh MCP menggunakan Azure Functions dengan Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Pelaksanaan contoh MCP menggunakan Azure Functions dengan C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Pelaksanaan contoh MCP menggunakan Azure Functions dengan Node/TypeScript.

## Kesimpulan Utama

- SDK MCP menyediakan alat khusus bahasa untuk melaksanakan penyelesaian MCP yang kukuh  
- Proses pengesanan dan pengujian adalah penting untuk aplikasi MCP yang boleh dipercayai  
- Templat prompt yang boleh digunakan semula membolehkan interaksi AI yang konsisten  
- Aliran kerja yang direka dengan baik boleh mengatur tugasan kompleks menggunakan pelbagai alat  
- Melaksanakan penyelesaian MCP memerlukan pertimbangan keselamatan, prestasi, dan pengendalian ralat  

## Latihan

Reka aliran kerja MCP praktikal yang menangani masalah dunia sebenar dalam bidang anda:

1. Kenal pasti 3-4 alat yang berguna untuk menyelesaikan masalah ini  
2. Cipta diagram aliran kerja yang menunjukkan bagaimana alat-alat ini berinteraksi  
3. Laksanakan versi asas salah satu alat menggunakan bahasa pilihan anda  
4. Cipta templat prompt yang membantu model menggunakan alat anda dengan berkesan  

## Sumber Tambahan


---

Seterusnya: [Topik Lanjutan](../05-AdvancedTopics/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya hendaklah dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.