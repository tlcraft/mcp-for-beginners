<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-06-10T07:15:23+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "id"
}
-->
# Weather MCP Server

Ini adalah contoh MCP Server dalam Python yang mengimplementasikan alat cuaca dengan respons tiruan. Ini bisa digunakan sebagai kerangka untuk MCP Server Anda sendiri. Fitur yang disertakan meliputi:

- **Weather Tool**: Alat yang menyediakan informasi cuaca tiruan berdasarkan lokasi yang diberikan.
- **Git Clone Tool**: Alat yang mengkloning repositori git ke folder yang ditentukan.
- **VS Code Open Tool**: Alat yang membuka folder di VS Code atau VS Code Insiders.
- **Connect to Agent Builder**: Fitur yang memungkinkan Anda menghubungkan server MCP ke Agent Builder untuk pengujian dan debugging.
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: Fitur yang memungkinkan Anda melakukan debug MCP Server menggunakan MCP Inspector.

## Mulai dengan template Weather MCP Server

> **Persyaratan**
>
> Untuk menjalankan MCP Server di mesin pengembangan lokal Anda, Anda memerlukan:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (Diperlukan untuk alat git_clone_repo)
> - [VS Code](https://code.visualstudio.com/) atau [VS Code Insiders](https://code.visualstudio.com/insiders/) (Diperlukan untuk alat open_in_vscode)
> - (*Opsional - jika Anda lebih suka uv*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Siapkan lingkungan

Ada dua cara untuk menyiapkan lingkungan untuk proyek ini. Anda bisa memilih salah satu sesuai preferensi Anda.

> Catatan: Muat ulang VSCode atau terminal untuk memastikan python dari lingkungan virtual digunakan setelah membuat lingkungan virtual.

| Pendekatan | Langkah |
| --------- | ------- |
| Menggunakan `uv` | 1. Buat lingkungan virtual: `uv venv` <br>2. Jalankan Perintah VSCode "***Python: Select Interpreter***" dan pilih python dari lingkungan virtual yang dibuat <br>3. Instal dependensi (termasuk dependensi dev): `uv pip install -r pyproject.toml --extra dev` |
| Menggunakan `pip` | 1. Buat lingkungan virtual: `python -m venv .venv` <br>2. Jalankan Perintah VSCode "***Python: Select Interpreter***" dan pilih python dari lingkungan virtual yang dibuat<br>3. Instal dependensi (termasuk dependensi dev): `pip install -e .[dev]` |

Setelah menyiapkan lingkungan, Anda bisa menjalankan server di mesin pengembangan lokal Anda melalui Agent Builder sebagai MCP Client untuk memulai:
1. Buka panel Debug VS Code. Pilih `Debug in Agent Builder` atau tekan `F5` untuk mulai melakukan debug server MCP.
2. Gunakan AI Toolkit Agent Builder untuk menguji server dengan [prompt ini](../../../../../../../../../../../open_prompt_builder). Server akan otomatis terhubung ke Agent Builder.
3. Klik `Run` untuk menguji server dengan prompt tersebut.

**Selamat!** Anda telah berhasil menjalankan Weather MCP Server di mesin pengembangan lokal Anda melalui Agent Builder sebagai MCP Client.  
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Apa saja yang termasuk dalam template

| Folder / File| Isi                                     |
| ------------ | -------------------------------------- |
| `.vscode`    | File VSCode untuk debugging           |
| `.aitk`      | Konfigurasi untuk AI Toolkit          |
| `src`        | Kode sumber untuk weather mcp server |

## Cara debug Weather MCP Server

> Catatan:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) adalah alat pengembang visual untuk pengujian dan debugging MCP server.
> - Semua mode debugging mendukung breakpoint, jadi Anda bisa menambahkan breakpoint pada kode implementasi alat.

## Alat yang tersedia

### Weather Tool  
Alat `get_weather` menyediakan informasi cuaca tiruan untuk lokasi yang ditentukan.

| Parameter | Tipe | Deskripsi |
| --------- | ---- | --------- |
| `location` | string | Lokasi untuk mendapatkan cuaca (misalnya, nama kota, provinsi, atau koordinat) |

### Git Clone Tool  
Alat `git_clone_repo` mengkloning repositori git ke folder yang ditentukan.

| Parameter | Tipe | Deskripsi |
| --------- | ---- | --------- |
| `repo_url` | string | URL repositori git yang akan dikloning |
| `target_folder` | string | Jalur ke folder tempat repositori akan dikloning |

Alat ini mengembalikan objek JSON dengan:  
- `success`: Boolean yang menunjukkan apakah operasi berhasil  
- `target_folder` atau `error`: Jalur repositori yang dikloning atau pesan error

### VS Code Open Tool  
Alat `open_in_vscode` membuka folder di aplikasi VS Code atau VS Code Insiders.

| Parameter | Tipe | Deskripsi |
| --------- | ---- | --------- |
| `folder_path` | string | Jalur ke folder yang akan dibuka |
| `use_insiders` | boolean (opsional) | Apakah menggunakan VS Code Insiders daripada VS Code biasa |

Alat ini mengembalikan objek JSON dengan:  
- `success`: Boolean yang menunjukkan apakah operasi berhasil  
- `message` atau `error`: Pesan konfirmasi atau pesan error

## Mode Debug | Deskripsi | Langkah untuk debug |
| ---------- | --------- | ------------------- |
| Agent Builder | Debug server MCP di Agent Builder melalui AI Toolkit. | 1. Buka panel Debug VS Code. Pilih `Debug in Agent Builder` dan tekan `F5` untuk mulai debug server MCP.<br>2. Gunakan AI Toolkit Agent Builder untuk menguji server dengan [prompt ini](../../../../../../../../../../../open_prompt_builder). Server akan otomatis terhubung ke Agent Builder.<br>3. Klik `Run` untuk menguji server dengan prompt. |
| MCP Inspector | Debug server MCP menggunakan MCP Inspector. | 1. Instal [Node.js](https://nodejs.org/)<br> 2. Siapkan Inspector: `cd inspector` && `npm install` <br> 3. Buka panel Debug VS Code. Pilih `Debug SSE in Inspector (Edge)` atau `Debug SSE in Inspector (Chrome)`. Tekan F5 untuk mulai debug.<br> 4. Saat MCP Inspector terbuka di browser, klik tombol `Connect` untuk menghubungkan MCP server ini.<br> 5. Kemudian Anda bisa `List Tools`, pilih alat, masukkan parameter, dan `Run Tool` untuk debug kode server Anda.<br> |

## Port Default dan kustomisasi

| Mode Debug | Port | Definisi | Kustomisasi | Catatan |
| ---------- | ---- | -------- | ----------- | ------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Edit [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) untuk mengubah port di atas. | N/A |
| MCP Inspector | 3001 (Server); 5173 dan 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Edit [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) untuk mengubah port di atas.| N/A |

## Masukan

Jika Anda memiliki masukan atau saran untuk template ini, silakan buka issue di [repository AI Toolkit GitHub](https://github.com/microsoft/vscode-ai-toolkit/issues)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk akurasi, harap diingat bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi yang penting, disarankan menggunakan jasa terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau salah tafsir yang timbul dari penggunaan terjemahan ini.