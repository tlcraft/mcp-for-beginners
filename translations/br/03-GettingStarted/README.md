<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9191921de355cd9c8f46ebe21bdd52fd",
  "translation_date": "2025-06-12T23:37:19+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "br"
}
-->
## Kemm Da Zaba  

Wannan sashe yana dauke da darussa da dama:

- **1 Server dinka na farko**, a wannan darasin na farko, za ka koyi yadda ake ƙirƙirar server dinka na farko da kuma duba shi ta amfani da kayan aikin inspector, wata hanya mai amfani wajen gwaji da gyara server ɗinka, [zuwa darasin](/03-GettingStarted/01-first-server/README.md)

- **2 Client**, a wannan darasin, za ka koyi yadda ake rubuta client wanda zai iya haɗawa da server ɗinka, [zuwa darasin](/03-GettingStarted/02-client/README.md)

- **3 Client tare da LLM**, hanya mafi kyau wajen rubuta client shine ta hanyar ƙara LLM a ciki domin ya iya "tattaunawa" da server ɗinka kan abin da za a yi, [zuwa darasin](/03-GettingStarted/03-llm-client/README.md)

- **4 Amfani da yanayin GitHub Copilot Agent na server a Visual Studio Code**. Anan, muna duban yadda ake gudanar da MCP Server ɗinmu daga cikin Visual Studio Code, [zuwa darasin](/03-GettingStarted/04-vscode/README.md)

- **5 Amfani daga SSE (Server Sent Events)** SSE wata ka'ida ce ta isar da bayanai daga server zuwa client kai tsaye, tana ba server damar turawa clients sabbin bayanai a lokaci guda ta HTTP [zuwa darasin](/03-GettingStarted/05-sse-server/README.md)

- **6 HTTP Streaming tare da MCP (Streamable HTTP)**. Koyi game da zamani na HTTP streaming, sanarwar ci gaba, da yadda ake aiwatar da MCP servers da clients masu iya aiki kai tsaye da yawa ta amfani da Streamable HTTP. [zuwa darasin](/03-GettingStarted/06-http-streaming/README.md)

- **7 Amfani da AI Toolkit don VSCode** don amfani da gwaji MCP Clients da Servers ɗinka [zuwa darasin](/03-GettingStarted/07-aitk/README.md)

- **8 Gwaji**. Anan za mu mayar da hankali musamman yadda za mu gwada server da client ɗinmu ta hanyoyi daban-daban, [zuwa darasin](/03-GettingStarted/08-testing/README.md)

- **9 Tura aikace-aikace**. Wannan babin zai dubi hanyoyi daban-daban na tura mafita MCP ɗinka, [zuwa darasin](/03-GettingStarted/09-deployment/README.md)


Model Context Protocol (MCP) wata hanya ce ta bude da ke daidaita yadda aikace-aikace ke samar da mahallin aiki ga LLMs. Ka ɗauki MCP kamar tashar USB-C ce ga aikace-aikacen AI - tana ba da hanyar haɗi ta daidaita don haɗa samfuran AI zuwa tushen bayanai da kayan aiki daban-daban.

## Manufofin Koyo

A ƙarshen wannan darasin, za ka iya:

- Kafa yanayin ci gaba don MCP a C#, Java, Python, TypeScript, da JavaScript
- Gina da tura MCP servers na asali tare da siffofi na musamman (kayan aiki, tambayoyi, da kayan aiki)
- Ƙirƙirar aikace-aikacen mai masauki da ke haɗa zuwa MCP servers
- Gwaji da gyara MCP implementations
- Fahimtar matsalolin da aka fi fuskanta wajen saitawa da hanyoyin magance su
- Haɗa MCP implementations ɗinka zuwa sabis na LLM masu shahara

## Kafa Yanayin MCP ɗinka

Kafin ka fara aiki da MCP, yana da muhimmanci ka shirya yanayin ci gaban ka kuma ka fahimci tsarin aiki na asali. Wannan sashe zai jagorance ka ta matakan farko na saitawa don tabbatar da fara aiki cikin sauƙi da MCP.

### Abubuwan da ake buƙata

Kafin ka fara ci gaba da MCP, tabbatar ka na da:

- **Yanayin Ci Gaba**: Don harshen da ka zaɓa (C#, Java, Python, TypeScript, ko JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, ko kowanne sabon edita na lambar
- **Manajan Kunshin**: NuGet, Maven/Gradle, pip, ko npm/yarn
- **Maballan API**: Don kowanne sabis na AI da kake shirin amfani da su a aikace-aikacen mai masauki


### SDKs na Hukuma

A cikin babin da ke tafe za ka ga mafita da aka gina ta amfani da Python, TypeScript, Java da .NET. Ga dukkan SDKs na hukuma da ake tallafawa.

MCP na samar da SDKs na hukuma don harsuna da dama:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Ana kula da shi tare da Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Ana kula da shi tare da Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Tsarin TypeScript na hukuma
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Tsarin Python na hukuma
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Tsarin Kotlin na hukuma
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Ana kula da shi tare da Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Tsarin Rust na hukuma

## Muhimman Abubuwan da Za a Tuna

- Kafa yanayin ci gaba na MCP abu ne mai sauƙi tare da SDKs na musamman ga harshe
- Gina MCP servers na nufin ƙirƙira da rajistar kayan aiki tare da cikakken tsarin bayanai
- MCP clients suna haɗawa da servers da samfura don amfani da ƙarin fasaloli
- Gwaji da gyara suna da mahimmanci don tabbatar da ingancin MCP implementations
- Zaɓuɓɓukan tura aikace-aikace sun haɗa daga ci gaban gida zuwa mafita a girgije

## Yin Aiki

Muna da jerin misalai da suka cika aikin da za ka gani a dukkan babi a wannan sashe. Bugu da ƙari, kowanne babi yana da nasa ayyuka da ƙalubale

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Karin Albarkatu

- [Gina Agents ta amfani da Model Context Protocol a Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP tare da Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Me Zai Biyo Baya

Na gaba: [Ƙirƙirar MCP Server ɗinka na farko](/03-GettingStarted/01-first-server/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional realizada por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.