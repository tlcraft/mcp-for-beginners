<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-06-13T01:31:10+00:00",
  "source_file": "03-GettingStarted/09-deployment/README.md",
  "language_code": "id"
}
-->
# Men-deploy Server MCP

Men-deploy server MCP Anda memungkinkan orang lain mengakses alat dan sumber dayanya di luar lingkungan lokal Anda. Ada beberapa strategi deployment yang bisa dipertimbangkan, tergantung pada kebutuhan Anda untuk skalabilitas, keandalan, dan kemudahan pengelolaan. Di bawah ini Anda akan menemukan panduan untuk men-deploy server MCP secara lokal, dalam container, dan ke cloud.

## Ikhtisar

Pelajaran ini membahas cara men-deploy aplikasi MCP Server Anda.

## Tujuan Pembelajaran

Pada akhir pelajaran ini, Anda akan dapat:

- Mengevaluasi berbagai pendekatan deployment.
- Men-deploy aplikasi Anda.

## Pengembangan dan Deployment Lokal

Jika server Anda dimaksudkan untuk digunakan dengan menjalankan di mesin pengguna, Anda bisa mengikuti langkah-langkah berikut:

1. **Unduh server**. Jika Anda tidak menulis server tersebut, unduh terlebih dahulu ke mesin Anda.  
1. **Mulai proses server**: Jalankan aplikasi MCP server Anda

Untuk SSE (tidak diperlukan untuk server tipe stdio)

1. **Konfigurasi jaringan**: Pastikan server dapat diakses pada port yang diharapkan  
1. **Hubungkan klien**: Gunakan URL koneksi lokal seperti `http://localhost:3000`

## Deployment ke Cloud

Server MCP dapat di-deploy ke berbagai platform cloud:

- **Serverless Functions**: Deploy server MCP ringan sebagai fungsi serverless  
- **Layanan Container**: Gunakan layanan seperti Azure Container Apps, AWS ECS, atau Google Cloud Run  
- **Kubernetes**: Deploy dan kelola server MCP di klaster Kubernetes untuk ketersediaan tinggi

### Contoh: Azure Container Apps

Azure Container Apps mendukung deployment Server MCP. Ini masih dalam tahap pengembangan dan saat ini mendukung server SSE.

Berikut cara melakukannya:

1. Clone sebuah repo:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Jalankan secara lokal untuk menguji:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. Untuk mencoba secara lokal, buat file *mcp.json* di direktori *.vscode* dan tambahkan konten berikut:

  ```json
  {
      "inputs": [
          {
              "type": "promptString",
              "id": "weather-api-key",
              "description": "Weather API Key",
              "password": true
          }
      ],
      "servers": {
          "weather-sse": {
              "type": "sse",
              "url": "http://localhost:8000/sse",
              "headers": {
                  "x-api-key": "${input:weather-api-key}"
              }
          }
      }
  }
  ```

  Setelah server SSE dijalankan, Anda dapat mengklik ikon play di file JSON tersebut, Anda sekarang harus melihat alat di server terdeteksi oleh GitHub Copilot, lihat ikon Tool.

1. Untuk melakukan deployment, jalankan perintah berikut:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

Itulah, deploy secara lokal, deploy ke Azure melalui langkah-langkah ini.

## Sumber Daya Tambahan

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Artikel Azure Container Apps](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Repo Azure Container Apps MCP](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## Selanjutnya

- Selanjutnya: [Implementasi Praktis](/04-PracticalImplementation/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk akurasi, harap diingat bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau salah tafsir yang timbul dari penggunaan terjemahan ini.