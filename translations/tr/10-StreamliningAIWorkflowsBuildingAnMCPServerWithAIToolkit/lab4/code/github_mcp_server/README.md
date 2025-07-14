<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-07-14T08:57:41+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "tr"
}
-->
# Weather MCP Server

Bu, sahte yanıtlarla hava durumu araçlarını uygulayan Python'da örnek bir MCP Server'dır. Kendi MCP Server'ınız için bir iskelet olarak kullanılabilir. Aşağıdaki özellikleri içerir:

- **Weather Tool**: Verilen konuma göre sahte hava durumu bilgisi sağlayan bir araç.
- **Git Clone Tool**: Bir git deposunu belirtilen klasöre klonlayan araç.
- **VS Code Open Tool**: Bir klasörü VS Code veya VS Code Insiders'da açan araç.
- **Connect to Agent Builder**: MCP sunucusunu test ve hata ayıklama için Agent Builder'a bağlamanızı sağlayan özellik.
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: MCP Server'ı MCP Inspector kullanarak hata ayıklamanızı sağlayan özellik.

## Weather MCP Server şablonuna başlama

> **Önkoşullar**
>
> MCP Server'ı yerel geliştirme makinenizde çalıştırmak için ihtiyacınız olacak:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (git_clone_repo aracı için gerekli)
> - [VS Code](https://code.visualstudio.com/) veya [VS Code Insiders](https://code.visualstudio.com/insiders/) (open_in_vscode aracı için gerekli)
> - (*İsteğe bağlı - uv tercih ederseniz*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Ortamı hazırlama

Bu proje için ortamı kurmanın iki yolu vardır. Tercihinize göre birini seçebilirsiniz.

> Not: Sanal ortam oluşturduktan sonra VSCode veya terminali yeniden yükleyerek sanal ortam python'unun kullanıldığından emin olun.

| Yöntem | Adımlar |
| -------- | ----- |
| `uv` kullanarak | 1. Sanal ortam oluşturun: `uv venv` <br>2. VSCode Komutunu çalıştırın "***Python: Select Interpreter***" ve oluşturulan sanal ortamın python'unu seçin <br>3. Bağımlılıkları (geliştirme bağımlılıkları dahil) yükleyin: `uv pip install -r pyproject.toml --extra dev` |
| `pip` kullanarak | 1. Sanal ortam oluşturun: `python -m venv .venv` <br>2. VSCode Komutunu çalıştırın "***Python: Select Interpreter***" ve oluşturulan sanal ortamın python'unu seçin<br>3. Bağımlılıkları (geliştirme bağımlılıkları dahil) yükleyin: `pip install -e .[dev]` |

Ortamı kurduktan sonra, MCP Client olarak Agent Builder üzerinden yerel geliştirme makinenizde sunucuyu çalıştırabilirsiniz:
1. VS Code Hata Ayıklama panelini açın. `Debug in Agent Builder` seçin veya MCP sunucusunu hata ayıklamaya başlamak için `F5` tuşuna basın.
2. AI Toolkit Agent Builder'ı kullanarak [bu prompt](../../../../../../../../../../open_prompt_builder) ile sunucuyu test edin. Sunucu otomatik olarak Agent Builder'a bağlanacaktır.
3. Prompt ile sunucuyu test etmek için `Run` butonuna tıklayın.

**Tebrikler**! Weather MCP Server'ı yerel geliştirme makinenizde Agent Builder üzerinden MCP Client olarak başarıyla çalıştırdınız.  
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Şablonda neler var

| Klasör / Dosya | İçerik                                      |
| -------------- | ------------------------------------------ |
| `.vscode`      | Hata ayıklama için VSCode dosyaları       |
| `.aitk`        | AI Toolkit yapılandırmaları                 |
| `src`          | Weather MCP server için kaynak kod          |

## Weather MCP Server nasıl hata ayıklanır

> Notlar:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector), MCP sunucularını test ve hata ayıklama için görsel bir geliştirici aracıdır.
> - Tüm hata ayıklama modları breakpoint destekler, böylece araç uygulama koduna breakpoint ekleyebilirsiniz.

## Kullanılabilir Araçlar

### Weather Tool
`get_weather` aracı, belirtilen konum için sahte hava durumu bilgisi sağlar.

| Parametre | Tür | Açıklama |
| --------- | --- | -------- |
| `location` | string | Hava durumu alınacak konum (örneğin, şehir adı, eyalet veya koordinatlar) |

### Git Clone Tool
`git_clone_repo` aracı, bir git deposunu belirtilen klasöre klonlar.

| Parametre | Tür | Açıklama |
| --------- | --- | -------- |
| `repo_url` | string | Klonlanacak git deposunun URL'si |
| `target_folder` | string | Depo klonlanacak klasörün yolu |

Araç şu JSON nesnesini döner:
- `success`: İşlemin başarılı olup olmadığını belirten boolean
- `target_folder` veya `error`: Klonlanan deponun yolu veya hata mesajı

### VS Code Open Tool
`open_in_vscode` aracı, bir klasörü VS Code veya VS Code Insiders uygulamasında açar.

| Parametre | Tür | Açıklama |
| --------- | --- | -------- |
| `folder_path` | string | Açılacak klasörün yolu |
| `use_insiders` | boolean (isteğe bağlı) | Normal VS Code yerine VS Code Insiders kullanılıp kullanılmayacağı |

Araç şu JSON nesnesini döner:
- `success`: İşlemin başarılı olup olmadığını belirten boolean
- `message` veya `error`: Onay mesajı veya hata mesajı

## Hata Ayıklama Modu | Açıklama | Hata Ayıklama Adımları |
| ---------------- | -------- | --------------------- |
| Agent Builder | MCP sunucusunu AI Toolkit üzerinden Agent Builder'da hata ayıklayın. | 1. VS Code Hata Ayıklama panelini açın. `Debug in Agent Builder` seçin ve MCP sunucusunu hata ayıklamaya başlamak için `F5` tuşuna basın.<br>2. AI Toolkit Agent Builder'ı kullanarak [bu prompt](../../../../../../../../../../open_prompt_builder) ile sunucuyu test edin. Sunucu otomatik olarak Agent Builder'a bağlanacaktır.<br>3. Prompt ile sunucuyu test etmek için `Run` butonuna tıklayın. |
| MCP Inspector | MCP sunucusunu MCP Inspector kullanarak hata ayıklayın. | 1. [Node.js](https://nodejs.org/) yükleyin<br>2. Inspector'ı kurun: `cd inspector` && `npm install` <br>3. VS Code Hata Ayıklama panelini açın. `Debug SSE in Inspector (Edge)` veya `Debug SSE in Inspector (Chrome)` seçin. Hata ayıklamayı başlatmak için F5'e basın.<br>4. MCP Inspector tarayıcıda açıldığında, bu MCP sunucusuna bağlanmak için `Connect` butonuna tıklayın.<br>5. Ardından `List Tools` yapabilir, bir araç seçebilir, parametreleri girebilir ve `Run Tool` ile sunucu kodunuzu hata ayıklayabilirsiniz.<br> |

## Varsayılan Portlar ve Özelleştirmeler

| Hata Ayıklama Modu | Portlar | Tanımlar | Özelleştirmeler | Not |
| ------------------ | ------- | -------- | --------------- | --- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Yukarıdaki portları değiştirmek için [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) dosyalarını düzenleyin. | Yok |
| MCP Inspector | 3001 (Sunucu); 5173 ve 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Yukarıdaki portları değiştirmek için [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) dosyalarını düzenleyin. | Yok |

## Geri Bildirim

Bu şablonla ilgili herhangi bir geri bildiriminiz veya öneriniz varsa, lütfen [AI Toolkit GitHub deposunda](https://github.com/microsoft/vscode-ai-toolkit/issues) bir issue açın.

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba gösterilse de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.