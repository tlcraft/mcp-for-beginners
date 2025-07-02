<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-02T10:18:21+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "id"
}
-->
# Integrasi Model Context Protocol (MCP) dengan Azure AI Foundry

Panduan ini menunjukkan cara mengintegrasikan server Model Context Protocol (MCP) dengan agen Azure AI Foundry, memungkinkan orkestrasi alat yang kuat dan kemampuan AI untuk perusahaan.

## Pendahuluan

Model Context Protocol (MCP) adalah standar terbuka yang memungkinkan aplikasi AI untuk terhubung secara aman ke sumber data dan alat eksternal. Saat diintegrasikan dengan Azure AI Foundry, MCP memungkinkan agen mengakses dan berinteraksi dengan berbagai layanan eksternal, API, dan sumber data secara terstandarisasi.

Integrasi ini menggabungkan fleksibilitas ekosistem alat MCP dengan kerangka kerja agen Azure AI Foundry yang tangguh, memberikan solusi AI kelas perusahaan dengan kemampuan kustomisasi yang luas.

**Note:** Jika Anda ingin menggunakan MCP di Azure AI Foundry Agent Service, saat ini hanya wilayah berikut yang didukung: westus, westus2, uaenorth, southindia, dan switzerlandnorth

## Tujuan Pembelajaran

Di akhir panduan ini, Anda akan mampu:

- Memahami Model Context Protocol dan manfaatnya
- Menyiapkan server MCP untuk digunakan dengan agen Azure AI Foundry
- Membuat dan mengonfigurasi agen dengan integrasi alat MCP
- Menerapkan contoh praktis menggunakan server MCP nyata
- Menangani respons alat dan kutipan dalam percakapan agen

## Prasyarat

Sebelum memulai, pastikan Anda memiliki:

- Langganan Azure dengan akses AI Foundry
- Python 3.10+
- Azure CLI yang terpasang dan terkonfigurasi
- Izin yang sesuai untuk membuat sumber daya AI

## Apa itu Model Context Protocol (MCP)?

Model Context Protocol adalah cara standar bagi aplikasi AI untuk terhubung ke sumber data dan alat eksternal. Manfaat utamanya meliputi:

- **Integrasi Terstandarisasi**: Antarmuka yang konsisten di berbagai alat dan layanan
- **Keamanan**: Mekanisme otentikasi dan otorisasi yang aman
- **Fleksibilitas**: Mendukung berbagai sumber data, API, dan alat kustom
- **Ekstensibilitas**: Mudah menambahkan kemampuan dan integrasi baru

## Menyiapkan MCP dengan Azure AI Foundry

### 1. Konfigurasi Lingkungan

Pertama, atur variabel lingkungan dan dependensi Anda:

```python
import os
import time
import json
from azure.ai.agents.models import MessageTextContent, ListSortOrder
from azure.ai.projects import AIProjectClient
from azure.identity import DefaultAzureCredential


### 1. Initialize the AI Project Client

```python
project_client = AIProjectClient(
    endpoint="https://your-project-endpoint.services.ai.azure.com/api/projects/your-project",
    credential=DefaultAzureCredential(),
)
```

### 2. Create an Agent with MCP Tools

Configure an agent with MCP server integration:

```python
with project_client:
    agent = project_client.agents.create_agent(
        model="gpt-4.1-nano", 
        name="mcp_agent", 
        instructions="You are a helpful assistant. Use the tools provided to answer questions. Be sure to cite your sources.",
        tools=[
            {
                "type": "mcp",
                "server_label": "microsoft_docs",
                "server_url": "https://learn.microsoft.com/api/mcp",
                "require_approval": "never"
            }
        ],
        tool_resources=None
    )
    print(f"Created agent, agent ID: {agent.id}")
```

## MCP Tool Configuration Options

When configuring MCP tools for your agent, you can specify several important parameters:

### Configuration

```python
mcp_tool = {
    "type": "mcp",
    "server_label": "unique_server_name",      # Identifier untuk server MCP
    "server_url": "https://api.example.com/mcp", # Endpoint server MCP
    "require_approval": "never"                 # Kebijakan persetujuan: saat ini hanya mendukung "never"
}
```

## Complete Example: Using Microsoft Learn MCP Server

Here's a complete example that demonstrates creating an agent with MCP integration and processing a conversation:

```python
import time
import json
import os
from azure.ai.agents.models import MessageTextContent, ListSortOrder
from azure.ai.projects import AIProjectClient
from azure.identity import DefaultAzureCredential

def create_mcp_agent_example():

    project_client = AIProjectClient(
        endpoint="https://your-endpoint.services.ai.azure.com/api/projects/your-project",
        credential=DefaultAzureCredential(),
    )

    with project_client:
        # Membuat agen dengan alat MCP
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="You are a helpful assistant specializing in Microsoft documentation. Use the Microsoft Learn MCP server to search for accurate, up-to-date information. Always cite your sources.",
            tools=[
                {
                    "type": "mcp",
                    "server_label": "mslearn",
                    "server_url": "https://learn.microsoft.com/api/mcp",
                    "require_approval": "never"
                }
            ],
            tool_resources=None
        )
        print(f"Created agent, agent ID: {agent.id}")    
        
        # Membuat thread percakapan
        thread = project_client.agents.threads.create()
        print(f"Created thread, thread ID: {thread.id}")

        # Mengirim pesan
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="What is .NET MAUI? How does it compare to Xamarin.Forms?",
        )
        print(f"Created message, message ID: {message.id}")

        # Menjalankan agen
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # Memantau hingga selesai
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Run status: {run.status}")

        # Memeriksa langkah run dan panggilan alat
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Run step: {step.id}, status: {step.status}, type: {step.type}")
            if step.type == "tool_calls":
                print("Tool call details:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # Menampilkan percakapan
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()
  

## Pemecahan Masalah Umum

### 1. Masalah Koneksi
- Pastikan URL server MCP dapat diakses
- Periksa kredensial otentikasi
- Pastikan konektivitas jaringan

### 2. Kegagalan Panggilan Alat
- Tinjau argumen dan format panggilan alat
- Periksa persyaratan khusus server
- Terapkan penanganan kesalahan yang tepat

### 3. Masalah Performa
- Optimalkan frekuensi panggilan alat
- Terapkan caching jika perlu
- Pantau waktu respons server

## Langkah Selanjutnya

Untuk meningkatkan integrasi MCP Anda:

1. **Jelajahi Server MCP Kustom**: Bangun server MCP sendiri untuk sumber data milik Anda
2. **Terapkan Keamanan Lanjutan**: Tambahkan OAuth2 atau mekanisme otentikasi kustom
3. **Pantau dan Analitik**: Terapkan logging dan monitoring penggunaan alat
4. **Skalakan Solusi Anda**: Pertimbangkan load balancing dan arsitektur server MCP terdistribusi

## Sumber Daya Tambahan

- [Dokumentasi Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- [Contoh Model Context Protocol](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Ikhtisar Agen Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [Spesifikasi MCP](https://spec.modelcontextprotocol.io/)

## Dukungan

Untuk dukungan dan pertanyaan tambahan:
- Tinjau [dokumentasi Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- Periksa [sumber daya komunitas MCP](https://modelcontextprotocol.io/)


## Selanjutnya

- [6. Kontribusi Komunitas](../../06-CommunityContributions/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk akurasi, harap diperhatikan bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau salah tafsir yang timbul dari penggunaan terjemahan ini.