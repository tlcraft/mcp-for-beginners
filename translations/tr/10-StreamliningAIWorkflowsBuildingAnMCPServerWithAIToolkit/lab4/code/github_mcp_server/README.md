<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-06-10T07:10:14+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "tr"
}
-->
# Weather MCP Sunucusu

Bu, sahte yanıtlar ile hava durumu araçlarını uygulayan Python'da örnek bir MCP Sunucusudur. Kendi MCP Sunucunuz için bir iskelet olarak kullanılabilir. Aşağıdaki özellikleri içerir:

- **Weather Tool**: Verilen konuma göre sahte hava durumu bilgisi sağlayan bir araç.
- **Git Clone Tool**: Bir git deposunu belirtilen klasöre klonlayan araç.
- **VS Code Open Tool**: Bir klasörü VS Code veya VS Code Insiders'da açan araç.
- **Agent Builder’a Bağlanma**: MCP sunucusunu test ve hata ayıklama için Agent Builder’a bağlamanızı sağlayan özellik.
- **[MCP Inspector](https://github.com/modelcontextprotocol/inspector) ile Hata Ayıklama**: MCP Sunucusunu MCP Inspector kullanarak hata ayıklamanıza olanak tanıyan özellik.

## Weather MCP Sunucusu şablonuna başlama

> **Ön Koşullar**
>
> MCP Sunucusunu yerel geliştirme makinenizde çalıştırmak için ihtiyacınız olacak:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (git_clone_repo aracı için gerekli)
> - [VS Code](https://code.visualstudio.com/) veya [VS Code Insiders](https://code.visualstudio.com/insiders/) (open_in_vscode aracı için gerekli)
> - (*İsteğe bağlı - uv tercih ederseniz*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Ortamı hazırlama

Bu proje için ortamı kurmanın iki yöntemi vardır. Tercihinize göre birini seçebilirsiniz.

> Not: Sanal ortam oluşturduktan sonra VSCode veya terminali yeniden yükleyerek sanal ortam python'unun kullanıldığından emin olun.

| Yöntem | Adımlar |
| -------- | ----- |
| `uv` kullanarak | 1. Sanal ortam oluşturun: `uv venv` <br>2. VSCode Komutunu çalıştırın "***Python: Select Interpreter***" ve oluşturulan sanal ortamın python'unu seçin <br>3. Bağımlılıkları (geliştirme bağımlılıkları dahil) yükleyin: `uv pip install -r pyproject.toml --extra dev` |
| `pip` kullanarak | 1. Sanal ortam oluşturun: `python -m venv .venv` <br>2. VSCode Komutunu çalıştırın "***Python: Select Interpreter***" ve oluşturulan sanal ortamın python'unu seçin<br>3. Bağımlılıkları (geliştirme bağımlılıkları dahil) yükleyin: `pip install -e .[dev]` | 

Ortamı kurduktan sonra, MCP İstemcisi olarak Agent Builder üzerinden yerel geliştirme makinenizde sunucuyu çalıştırabilirsiniz:
1. VS Code Hata Ayıklama panelini açın. MCP sunucusunu hata ayıklamaya başlamak için `Debug in Agent Builder` seçin veya `F5` tuşuna basın.
2. AI Toolkit Agent Builder kullanarak [bu prompt](../../../../../../../../../../../open_prompt_builder) ile sunucuyu test edin. Sunucu otomatik olarak Agent Builder’a bağlanacaktır.
3. Prompt ile sunucuyu test etmek için `Run` tıklayın.

**Tebrikler**! Weather MCP Sunucusunu yerel geliştirme makinenizde Agent Builder üzerinden MCP İstemcisi olarak başarıyla çalıştırdınız.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Şablonda neler var

| Klasör / Dosya | İçerikler                                   |
| -------------- | ------------------------------------------ |
| `.vscode`    | Hata ayıklama için VSCode dosyaları          |
| `.aitk`      | AI Toolkit için yapılandırmalar               |
| `src`        | Weather MCP sunucusunun kaynak kodu            |

## Weather MCP Sunucusunu nasıl hata ayıklarsınız

> Notlar:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector), MCP sunucularını test ve hata ayıklama için görsel bir geliştirici aracıdır.
> - Tüm hata ayıklama modları breakpoint desteği sunar, böylece araç uygulama koduna breakpoint ekleyebilirsiniz.

## Mevcut Araçlar

### Weather Tool
`get_weather` aracı, belirtilen konum için sahte hava durumu bilgisi sağlar.

| Parametre | Tür | Açıklama |
| --------- | --- | -------- |
| `location` | string | Hava durumu alınacak konum (örneğin, şehir adı, eyalet veya koordinatlar) |

### Git Clone Tool
`git_clone_repo` aracı, bir git deposunu belirtilen klasöre klonlar.

| Parametre | Tür | Açıklama |
| --------- | --- | -------- |
| `repo_url` | string | Klonlanacak git deposunun URL’si |
| `target_folder` | string | Depo klonlanacak klasörün yolu |

Araç şu şekilde bir JSON nesnesi döner:
- `success`: İşlemin başarılı olup olmadığını belirten Boolean
- `target_folder` veya `error`: Klonlanan deponun yolu veya hata mesajı

### VS Code Open Tool
`open_in_vscode` aracı, bir klasörü VS Code veya VS Code Insiders uygulamasında açar.

| Parametre | Tür | Açıklama |
| --------- | --- | -------- |
| `folder_path` | string | Açılacak klasörün yolu |
| `use_insiders` | boolean (isteğe bağlı) | Normal VS Code yerine VS Code Insiders kullanılıp kullanılmayacağı |

Araç şu şekilde bir JSON nesnesi döner:
- `success`: İşlemin başarılı olup olmadığını belirten Boolean
- `message` veya `error`: Onay mesajı veya hata mesajı

## Hata Ayıklama Modu | Açıklama | Hata Ayıklama Adımları |
| -------------- | --------- | --------------------- |
| Agent Builder | AI Toolkit üzerinden Agent Builder’da MCP sunucusunu hata ayıklama. | 1. VS Code Hata Ayıklama panelini açın. MCP sunucusunu hata ayıklamaya başlamak için `Debug in Agent Builder` seçin ve `F5` tuşuna basın.<br>2. AI Toolkit Agent Builder kullanarak [bu prompt](../../../../../../../../../../../open_prompt_builder) ile sunucuyu test edin. Sunucu otomatik olarak Agent Builder’a bağlanacaktır.<br>3. Prompt ile sunucuyu test etmek için `Run` tıklayın. |
| MCP Inspector | MCP Inspector kullanarak MCP sunucusunu hata ayıklama. | 1. [Node.js](https://nodejs.org/) yükleyin<br> 2. Inspector’ı kurun: `cd inspector` && `npm install` <br> 3. VS Code Hata Ayıklama panelini açın. `Debug SSE in Inspector (Edge)` veya `Debug SSE in Inspector (Chrome)` seçin. Hata ayıklamayı başlatmak için F5’e basın.<br> 4. MCP Inspector tarayıcıda açıldığında, bu MCP sunucusuna bağlanmak için `Connect` düğmesine tıklayın.<br> 5. Daha sonra `List Tools` yapabilir, bir araç seçebilir, parametre girebilir ve `Run Tool` ile sunucu kodunuzu hata ayıklayabilirsiniz.<br> |

## Varsayılan Portlar ve Özelleştirmeler

| Hata Ayıklama Modu | Portlar | Tanımlar | Özelleştirmeler | Not |
| ------------------ | ------- | -------- | --------------- | --- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Yukarıdaki portları değiştirmek için [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) dosyalarını düzenleyin. | N/A |
| MCP Inspector | 3001 (Sunucu); 5173 ve 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Yukarıdaki portları değiştirmek için [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) dosyalarını düzenleyin. | N/A |

## Geri Bildirim

Bu şablonla ilgili herhangi bir geri bildiriminiz veya öneriniz varsa, lütfen [AI Toolkit GitHub deposunda](https://github.com/microsoft/vscode-ai-toolkit/issues) bir issue açın.

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hata veya yanlışlık içerebileceğini lütfen unutmayın. Orijinal belge, kendi ana dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu ortaya çıkabilecek yanlış anlamalar veya yanlış yorumlamalar nedeniyle sorumluluk kabul edilmemektedir.