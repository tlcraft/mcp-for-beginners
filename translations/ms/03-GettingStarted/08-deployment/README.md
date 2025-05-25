<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-17T12:54:41+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "ms"
}
-->
# Melancarkan Pelayan MCP

Melancarkan pelayan MCP anda membolehkan orang lain mengakses alat dan sumbernya di luar persekitaran tempatan anda. Terdapat beberapa strategi pelancaran yang boleh dipertimbangkan, bergantung kepada keperluan anda untuk kebolehskalaan, kebolehpercayaan, dan kemudahan pengurusan. Di bawah ini anda akan menemui panduan untuk melancarkan pelayan MCP secara tempatan, dalam kontena, dan ke awan.

## Gambaran Keseluruhan

Pelajaran ini meliputi cara melancarkan aplikasi Pelayan MCP anda.

## Objektif Pembelajaran

Menjelang akhir pelajaran ini, anda akan dapat:

- Menilai pendekatan pelancaran yang berbeza.
- Melancarkan aplikasi anda.

## Pembangunan dan pelancaran tempatan

Jika pelayan anda bertujuan untuk digunakan dengan menjalankannya pada mesin pengguna, anda boleh mengikuti langkah-langkah berikut:

1. **Muat turun pelayan**. Jika anda tidak menulis pelayan tersebut, maka muat turunnya terlebih dahulu ke mesin anda.
1. **Mulakan proses pelayan**: Jalankan aplikasi pelayan MCP anda

Untuk SSE (tidak diperlukan untuk pelayan jenis stdio)

1. **Konfigurasi rangkaian**: Pastikan pelayan boleh diakses pada port yang dijangka
1. **Sambung pelanggan**: Gunakan URL sambungan tempatan seperti `http://localhost:3000`

## Pelancaran Awan

Pelayan MCP boleh dilancarkan ke pelbagai platform awan:

- **Fungsi Tanpa Pelayan**: Lancarkan pelayan MCP ringan sebagai fungsi tanpa pelayan
- **Perkhidmatan Kontena**: Gunakan perkhidmatan seperti Azure Container Apps, AWS ECS, atau Google Cloud Run
- **Kubernetes**: Lancarkan dan urus pelayan MCP dalam kluster Kubernetes untuk ketersediaan tinggi

### Contoh: Azure Container Apps

Azure Container Apps menyokong pelancaran Pelayan MCP. Ia masih dalam proses kerja dan kini menyokong pelayan SSE.

Berikut adalah cara untuk melakukannya:

1. Klon repo:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Jalankannya secara tempatan untuk menguji:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. Untuk mencubanya secara tempatan, buat fail *mcp.json* dalam direktori *.vscode* dan tambah kandungan berikut:

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

  Sebaik sahaja pelayan SSE dimulakan, anda boleh klik ikon main dalam fail JSON, anda kini sepatutnya melihat alat pada pelayan diambil oleh GitHub Copilot, lihat ikon Alat.

1. Untuk melancarkan, jalankan arahan berikut:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

Itulah dia, lancarkan secara tempatan, lancarkan ke Azure melalui langkah-langkah ini.

## Sumber Tambahan

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Artikel Azure Container Apps](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Repo MCP Azure Container Apps](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## Apa Seterusnya

- Seterusnya: [Pelaksanaan Praktikal](/04-PracticalImplementation/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk memastikan ketepatan, sila maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang berwibawa. Untuk maklumat penting, terjemahan manusia profesional adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.