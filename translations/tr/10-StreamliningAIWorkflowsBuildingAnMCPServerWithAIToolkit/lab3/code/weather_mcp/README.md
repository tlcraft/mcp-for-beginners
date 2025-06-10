<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "999c5e7623c1e2d5e5a07c2feb39eb67",
  "translation_date": "2025-06-10T06:30:17+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/README.md",
  "language_code": "tr"
}
-->
# Weather MCP Server

Bu, sahte yanıtlarla hava durumu araçlarını uygulayan Python'da örnek bir MCP Server'dır. Kendi MCP Server'ınız için bir iskelet olarak kullanılabilir. Aşağıdaki özellikleri içerir:

- **Weather Tool**: Verilen konuma göre sahte hava durumu bilgisi sağlayan bir araç.
- **Agent Builder'a Bağlanma**: MCP sunucusunu test ve hata ayıklama için Agent Builder'a bağlamanızı sağlayan bir özellik.
- **[MCP Inspector](https://github.com/modelcontextprotocol/inspector) ile Hata Ayıklama**: MCP Server'ı MCP Inspector kullanarak hata ayıklamanızı sağlayan bir özellik.

## Weather MCP Server şablonuyla başlayın

> **Önkoşullar**
>
> MCP Server'ı yerel geliştirme makinenizde çalıştırmak için ihtiyacınız olanlar:
>
> - [Python](https://www.python.org/)
> - (*İsteğe bağlı - uv tercih ederseniz*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Ortamı hazırlama

Bu proje için ortamı kurmanın iki yöntemi vardır. Tercihinize göre birini seçebilirsiniz.

> Not: Sanal ortam oluşturduktan sonra VSCode veya terminali yeniden yükleyerek sanal ortamın python'unun kullanıldığından emin olun.

| Yöntem | Adımlar |
| -------- | ----- |
| `uv` kullanarak | 1. Sanal ortam oluşturun: `uv venv` <br>2. VSCode Komutunu çalıştırın "***Python: Select Interpreter***" ve oluşturulan sanal ortamın python'unu seçin <br>3. Bağımlılıkları (geliştirme bağımlılıkları dahil) yükleyin: `uv pip install -r pyproject.toml --extra dev` |
| `pip` kullanarak | 1. Sanal ortam oluşturun: `python -m venv .venv` <br>2. VSCode Komutunu çalıştırın "***Python: Select Interpreter***" ve oluşturulan sanal ortamın python'unu seçin<br>3. Bağımlılıkları (geliştirme bağımlılıkları dahil) yükleyin: `pip install -e .[dev]` |

Ortamı kurduktan sonra, MCP Client olarak Agent Builder üzerinden yerel geliştirme makinenizde sunucuyu çalıştırabilirsiniz:
1. VS Code Hata Ayıklama panelini açın. MCP sunucusunu hata ayıklamaya başlamak için `Debug in Agent Builder` seçin veya `F5` tuşuna basın.
2. AI Toolkit Agent Builder'ı kullanarak [bu istemle](../../../../../../../../../../../open_prompt_builder) sunucuyu test edin. Sunucu otomatik olarak Agent Builder'a bağlanacaktır.
3. İstemi test etmek için `Run` öğesine tıklayın.

**Tebrikler**! Weather MCP Server'ı Agent Builder üzerinden MCP Client olarak yerel geliştirme makinenizde başarıyla çalıştırdınız.  
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Şablonda neler var

| Klasör / Dosya | İçerik                                     |
| -------------- | ------------------------------------------ |
| `.vscode`    | Hata ayıklama için VSCode dosyaları         |
| `.aitk`      | AI Toolkit için yapılandırmalar              |
| `src`        | Weather MCP server'ın kaynak kodu             |

## Weather MCP Server nasıl hata ayıklanır

> Notlar:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector), MCP sunucularını test etmek ve hata ayıklamak için görsel bir geliştirici aracıdır.
> - Tüm hata ayıklama modları breakpoint destekler, böylece araç uygulama koduna breakpoint ekleyebilirsiniz.

| Hata Ayıklama Modu | Açıklama | Hata Ayıklama Adımları |
| ------------------ | -------- | ---------------------- |
| Agent Builder | MCP sunucusunu AI Toolkit üzerinden Agent Builder'da hata ayıklama. | 1. VS Code Hata Ayıklama panelini açın. MCP sunucusunu hata ayıklamaya başlamak için `Debug in Agent Builder` seçin ve `F5` tuşuna basın.<br>2. AI Toolkit Agent Builder'ı kullanarak [bu istemle](../../../../../../../../../../../open_prompt_builder) sunucuyu test edin. Sunucu otomatik olarak Agent Builder'a bağlanacaktır.<br>3. İstemi test etmek için `Run` öğesine tıklayın. |
| MCP Inspector | MCP Inspector kullanarak MCP sunucusunu hata ayıklama. | 1. [Node.js](https://nodejs.org/) yükleyin<br> 2. Inspector'ı kurun: `cd inspector` && `npm install` <br> 3. VS Code Hata Ayıklama panelini açın. `Debug SSE in Inspector (Edge)` veya `Debug SSE in Inspector (Chrome)` seçin. Hata ayıklamayı başlatmak için F5'e basın.<br> 4. MCP Inspector tarayıcıda açıldığında, bu MCP sunucusuna bağlanmak için `Connect` butonuna tıklayın.<br> 5. Ardından `List Tools` yapabilir, bir araç seçebilir, parametre girebilir ve `Run Tool` ile sunucu kodunuzu hata ayıklayabilirsiniz.<br> |

## Varsayılan Portlar ve Özelleştirmeler

| Hata Ayıklama Modu | Portlar | Tanımlar | Özelleştirmeler | Not |
| ------------------ | ------- | -------- | --------------- | --- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | Yukarıdaki portları değiştirmek için [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) dosyalarını düzenleyin. | Yok |
| MCP Inspector | 3001 (Sunucu); 5173 ve 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | Yukarıdaki portları değiştirmek için [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) dosyalarını düzenleyin. | Yok |

## Geri bildirim

Bu şablonla ilgili herhangi bir geri bildiriminiz veya öneriniz varsa, lütfen [AI Toolkit GitHub deposunda](https://github.com/microsoft/vscode-ai-toolkit/issues) bir issue açın.

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yorum farklılıklarından sorumlu değiliz.