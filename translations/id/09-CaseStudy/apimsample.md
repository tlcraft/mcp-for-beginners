<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:34:46+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "id"
}
-->
# Studi Kasus: Mengekspos REST API di API Management sebagai server MCP

Azure API Management adalah layanan yang menyediakan Gateway di atas Endpoint API Anda. Cara kerjanya adalah Azure API Management bertindak seperti proxy di depan API Anda dan dapat memutuskan apa yang harus dilakukan dengan permintaan yang masuk.

Dengan menggunakannya, Anda menambahkan berbagai fitur seperti:

- **Keamanan**, Anda dapat menggunakan segala sesuatu mulai dari API keys, JWT hingga managed identity.
- **Pembatasan laju (rate limiting)**, fitur hebat yang memungkinkan Anda menentukan berapa banyak panggilan yang diperbolehkan dalam satuan waktu tertentu. Ini membantu memastikan semua pengguna mendapatkan pengalaman yang baik dan juga agar layanan Anda tidak kewalahan dengan permintaan.
- **Skalabilitas & Load balancing**. Anda dapat mengatur beberapa endpoint untuk menyeimbangkan beban dan juga menentukan cara "load balance".
- **Fitur AI seperti semantic caching**, batas token dan pemantauan token, dan lainnya. Fitur-fitur ini meningkatkan responsivitas sekaligus membantu Anda mengontrol pengeluaran token. [Baca lebih lanjut di sini](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## Mengapa MCP + Azure API Management?

Model Context Protocol dengan cepat menjadi standar untuk aplikasi AI agentik dan cara mengekspos alat serta data secara konsisten. Azure API Management adalah pilihan alami saat Anda perlu "mengelola" API. Server MCP sering terintegrasi dengan API lain untuk menyelesaikan permintaan ke sebuah alat, misalnya. Oleh karena itu, menggabungkan Azure API Management dan MCP sangat masuk akal.

## Gambaran Umum

Dalam kasus penggunaan ini, kita akan belajar cara mengekspos endpoint API sebagai Server MCP. Dengan melakukan ini, kita dapat dengan mudah menjadikan endpoint ini bagian dari aplikasi agentik sekaligus memanfaatkan fitur dari Azure API Management.

## Fitur Utama

- Anda memilih metode endpoint yang ingin diekspos sebagai alat.
- Fitur tambahan yang Anda dapatkan bergantung pada konfigurasi di bagian kebijakan (policy) untuk API Anda. Namun di sini kami akan menunjukkan cara menambahkan pembatasan laju.

## Langkah Awal: impor API

Jika Anda sudah memiliki API di Azure API Management, bagus, Anda bisa melewati langkah ini. Jika belum, lihat tautan ini, [mengimpor API ke Azure API Management](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## Mengekspos API sebagai Server MCP

Untuk mengekspos endpoint API, ikuti langkah-langkah berikut:

1. Buka Azure Portal dan alamat berikut <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
   Arahkan ke instance API Management Anda.

1. Di menu sebelah kiri, pilih APIs > MCP Servers > + Create new MCP Server.

1. Pada bagian API, pilih REST API yang ingin diekspos sebagai server MCP.

1. Pilih satu atau lebih Operasi API yang ingin diekspos sebagai alat. Anda bisa memilih semua operasi atau hanya operasi tertentu.

    ![Pilih metode untuk diekspos](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. Pilih **Create**.

1. Arahkan ke menu **APIs** dan **MCP Servers**, Anda akan melihat seperti berikut:

    ![Lihat MCP Server di panel utama](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    Server MCP telah dibuat dan operasi API diekspos sebagai alat. Server MCP terdaftar di panel MCP Servers. Kolom URL menunjukkan endpoint server MCP yang dapat Anda panggil untuk pengujian atau dalam aplikasi klien.

## Opsional: Konfigurasi kebijakan

Azure API Management memiliki konsep inti kebijakan (policies) di mana Anda mengatur aturan berbeda untuk endpoint Anda, misalnya pembatasan laju atau semantic caching. Kebijakan ini ditulis dalam format XML.

Berikut cara mengatur kebijakan untuk membatasi laju Server MCP Anda:

1. Di portal, di bawah APIs, pilih **MCP Servers**.

1. Pilih server MCP yang sudah Anda buat.

1. Di menu sebelah kiri, di bawah MCP, pilih **Policies**.

1. Di editor kebijakan, tambahkan atau edit kebijakan yang ingin diterapkan pada alat server MCP. Kebijakan didefinisikan dalam format XML. Misalnya, Anda bisa menambahkan kebijakan untuk membatasi panggilan ke alat server MCP (dalam contoh ini, 5 panggilan per 30 detik per alamat IP klien). Berikut XML yang akan menyebabkan pembatasan laju:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    Berikut gambar editor kebijakan:

    ![Editor kebijakan](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## Coba Jalankan

Mari pastikan Server MCP kita berfungsi sesuai harapan.

Untuk ini, kita akan menggunakan Visual Studio Code dan GitHub Copilot dengan mode Agent. Kita akan menambahkan server MCP ke *mcp.json*. Dengan begitu, Visual Studio Code akan bertindak sebagai klien dengan kemampuan agentik dan pengguna akhir dapat mengetik prompt dan berinteraksi dengan server tersebut.

Berikut cara menambahkan server MCP di Visual Studio Code:

1. Gunakan perintah MCP: **Add Server dari Command Palette**.

1. Saat diminta, pilih tipe server: **HTTP (HTTP atau Server Sent Events)**.

1. Masukkan URL server MCP di API Management. Contoh: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (untuk endpoint SSE) atau **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (untuk endpoint MCP), perhatikan perbedaan transportnya adalah `/sse` atau `/mcp`.

1. Masukkan ID server sesuai pilihan Anda. Ini bukan nilai penting tapi membantu Anda mengingat instance server ini.

1. Pilih apakah konfigurasi disimpan ke pengaturan workspace atau pengaturan pengguna.

  - **Workspace settings** - Konfigurasi server disimpan ke file .vscode/mcp.json yang hanya tersedia di workspace saat ini.

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    atau jika Anda memilih streaming HTTP sebagai transport, akan sedikit berbeda:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **User settings** - Konfigurasi server ditambahkan ke file *settings.json* global Anda dan tersedia di semua workspace. Konfigurasinya mirip seperti berikut:

    ![Pengaturan pengguna](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. Anda juga perlu menambahkan konfigurasi header untuk memastikan autentikasi yang benar ke Azure API Management. Header yang digunakan bernama **Ocp-Apim-Subscription-Key**.

    - Berikut cara menambahkannya ke pengaturan:

    ![Menambahkan header untuk autentikasi](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png), ini akan memunculkan prompt untuk memasukkan nilai API key yang bisa Anda temukan di Azure Portal untuk instance Azure API Management Anda.

   - Untuk menambahkannya ke *mcp.json*, Anda bisa menambahkannya seperti ini:

    ```json
    "inputs": [
      {
        "type": "promptString",
        "id": "apim_key",
        "description": "API Key for Azure API Management",
        "password": true
      }
    ]
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp",
            "headers": {
                "Ocp-Apim-Subscription-Key": "Bearer ${input:apim_key}"
            }
        }
    }
    ```

### Gunakan mode Agent

Sekarang kita sudah siap baik di pengaturan atau di *.vscode/mcp.json*. Mari coba jalankan.

Seharusnya ada ikon Tools seperti ini, di mana alat yang diekspos dari server Anda terdaftar:

![Alat dari server](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Klik ikon tools dan Anda akan melihat daftar alat seperti ini:

    ![Alat](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. Masukkan prompt di chat untuk memanggil alat tersebut. Misalnya, jika Anda memilih alat untuk mendapatkan informasi tentang pesanan, Anda bisa bertanya kepada agen tentang pesanan tersebut. Berikut contoh prompt:

    ```text
    get information from order 2
    ```

    Anda sekarang akan melihat ikon tools yang meminta Anda untuk melanjutkan memanggil alat. Pilih untuk melanjutkan menjalankan alat, Anda akan melihat output seperti ini:

    ![Hasil dari prompt](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **apa yang Anda lihat di atas tergantung alat yang Anda siapkan, tapi idenya adalah Anda mendapatkan respons teks seperti di atas**


## Referensi

Berikut cara Anda bisa belajar lebih lanjut:

- [Tutorial tentang Azure API Management dan MCP](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Contoh Python: Amankan server MCP jarak jauh menggunakan Azure API Management (eksperimental)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [Lab otorisasi klien MCP](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [Gunakan ekstensi Azure API Management untuk VS Code untuk mengimpor dan mengelola API](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Daftarkan dan temukan server MCP jarak jauh di Azure API Center](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Repo hebat yang menunjukkan banyak kemampuan AI dengan Azure API Management
- [Workshop AI Gateway](https://azure-samples.github.io/AI-Gateway/) Berisi workshop menggunakan Azure Portal, cara yang bagus untuk mulai mengevaluasi kemampuan AI.

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk akurasi, harap diketahui bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sah. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang salah yang timbul dari penggunaan terjemahan ini.