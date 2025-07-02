<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-02T10:18:36+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "ms"
}
-->
# Model Context Protocol (MCP) Integrasi dengan Azure AI Foundry

Panduan ini menunjukkan cara mengintegrasikan pelayan Model Context Protocol (MCP) dengan ejen Azure AI Foundry, membolehkan orkestrasi alat yang berkuasa dan keupayaan AI perusahaan.

## Pengenalan

Model Context Protocol (MCP) adalah standard terbuka yang membolehkan aplikasi AI menyambung dengan selamat ke sumber data dan alat luaran. Apabila digabungkan dengan Azure AI Foundry, MCP membolehkan ejen mengakses dan berinteraksi dengan pelbagai perkhidmatan luaran, API, dan sumber data secara berstandard.

Integrasi ini menggabungkan fleksibiliti ekosistem alat MCP dengan rangka kerja ejen Azure AI Foundry yang mantap, menyediakan penyelesaian AI bertaraf perusahaan dengan keupayaan penyesuaian yang meluas.

**Note:** Jika anda ingin menggunakan MCP dalam Azure AI Foundry Agent Service, buat masa ini hanya wilayah berikut yang disokong: westus, westus2, uaenorth, southindia dan switzerlandnorth

## Objektif Pembelajaran

Pada akhir panduan ini, anda akan dapat:

- Memahami Model Context Protocol dan manfaatnya  
- Menyediakan pelayan MCP untuk digunakan dengan ejen Azure AI Foundry  
- Mencipta dan mengkonfigurasi ejen dengan integrasi alat MCP  
- Melaksanakan contoh praktikal menggunakan pelayan MCP sebenar  
- Mengendalikan tindak balas alat dan sitasi dalam perbualan ejen  

## Prasyarat

Sebelum memulakan, pastikan anda mempunyai:

- Langganan Azure dengan akses AI Foundry  
- Python 3.10+  
- Azure CLI dipasang dan dikonfigurasi  
- Kebenaran yang sesuai untuk mencipta sumber AI  

## Apakah Model Context Protocol (MCP)?

Model Context Protocol ialah cara berstandard untuk aplikasi AI menyambung ke sumber data dan alat luaran. Manfaat utama termasuk:

- **Integrasi Berstandard**: Antara muka yang konsisten merentasi pelbagai alat dan perkhidmatan  
- **Keselamatan**: Mekanisme pengesahan dan kebenaran yang selamat  
- **Fleksibiliti**: Menyokong pelbagai sumber data, API, dan alat tersuai  
- **Kebolehpanjangan**: Mudah untuk menambah keupayaan dan integrasi baru  

## Menyediakan MCP dengan Azure AI Foundry

### 1. Konfigurasi Persekitaran

Mula-mula, tetapkan pemboleh ubah persekitaran dan kebergantungan anda:

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
    "server_label": "unique_server_name",      # Pengenal untuk pelayan MCP
    "server_url": "https://api.example.com/mcp", # Titik akhir pelayan MCP
    "require_approval": "never"                 # Polisi kelulusan: buat masa ini hanya sokong "never" 
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
        # Cipta ejen dengan alat MCP
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
        
        # Cipta benang perbualan
        thread = project_client.agents.threads.create()
        print(f"Created thread, thread ID: {thread.id}")

        # Hantar mesej
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="What is .NET MAUI? How does it compare to Xamarin.Forms?",
        )
        print(f"Created message, message ID: {message.id}")

        # Jalankan ejen
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # Semak status sehingga selesai
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Run status: {run.status}")

        # Periksa langkah run dan panggilan alat
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Run step: {step.id}, status: {step.status}, type: {step.type}")
            if step.type == "tool_calls":
                print("Tool call details:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # Papar perbualan
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()
  

## Menyelesaikan Masalah Biasa

### 1. Masalah Sambungan
- Sahkan URL pelayan MCP boleh diakses  
- Semak kelayakan pengesahan  
- Pastikan rangkaian berfungsi  

### 2. Kegagalan Panggilan Alat
- Semak argumen dan format alat  
- Periksa keperluan khusus pelayan  
- Laksanakan pengendalian ralat yang betul  

### 3. Masalah Prestasi
- Optimumkan kekerapan panggilan alat  
- Gunakan caching jika sesuai  
- Pantau masa tindak balas pelayan  

## Langkah Seterusnya

Untuk meningkatkan lagi integrasi MCP anda:

1. **Terokai Pelayan MCP Tersuai**: Bangunkan pelayan MCP anda sendiri untuk sumber data proprietari  
2. **Laksanakan Keselamatan Lanjutan**: Tambah OAuth2 atau mekanisme pengesahan tersuai  
3. **Pantauan dan Analitik**: Laksanakan logging dan pemantauan penggunaan alat  
4. **Skalakan Penyelesaian Anda**: Pertimbangkan pengimbangan beban dan seni bina pelayan MCP teragih  

## Sumber Tambahan

- [Azure AI Foundry Documentation](https://learn.microsoft.com/azure/ai-foundry/)  
- [Model Context Protocol Samples](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)  
- [Azure AI Foundry Agents Overview](https://learn.microsoft.com/azure/ai-foundry/agents/)  
- [MCP Specification](https://spec.modelcontextprotocol.io/)  

## Sokongan

Untuk sokongan dan pertanyaan tambahan:  
- Semak [dokumentasi Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)  
- Rujuk [sumber komuniti MCP](https://modelcontextprotocol.io/)  


## Apa seterusnya

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya hendaklah dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.