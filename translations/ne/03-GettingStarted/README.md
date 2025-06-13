<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9191921de355cd9c8f46ebe21bdd52fd",
  "translation_date": "2025-06-12T23:26:34+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "ne"
}
-->
## Getting Started  

Yo hissa ma kayi paath haru sametiyeko cha:

- **1 Your first server**, yo pahilo paath ma, tapai le afno pahilo server kasari banaune ra inspector tool bata kasari herne siknu hunchha, yo ek dam upayogi tarika ho server test ra debug garna, [to the lesson](/03-GettingStarted/01-first-server/README.md)

- **2 Client**, yo paath ma, tapai le client kasari lekne siknu hunchha jasle tapai ko server sanga connect garna sakos, [to the lesson](/03-GettingStarted/02-client/README.md)

- **3 Client with LLM**, client lekne arko ramro tarika ho LLM jodne, jasle tapai ko server sanga "samjhauta" garera ke garne bhanne kura tayar garna sakos, [to the lesson](/03-GettingStarted/03-llm-client/README.md)

- **4 Consuming a server GitHub Copilot Agent mode in Visual Studio Code**. Yo hissa ma, haami Visual Studio Code bhitra bata hamro MCP Server kasari chalauchha bhanne kura heriraheka chhau, [to the lesson](/03-GettingStarted/04-vscode/README.md)

- **5 Consuming from a SSE (Server Sent Events)** SSE ek standard ho server dekhi client samma streaming garna ko lagi, jasle server haru lai real-time update haru client haru samma HTTP ma pathauna dincha [to the lesson](/03-GettingStarted/05-sse-server/README.md)

- **6 HTTP Streaming with MCP (Streamable HTTP)**. Aadhunik HTTP streaming, progress notification haru, ra kasari scalable, real-time MCP servers ra clients Streamable HTTP ko madhyam bata banaune bhanne kura siknu hos. [to the lesson](/03-GettingStarted/06-http-streaming/README.md)

- **7 Utilising AI Toolkit for VSCode** tapai ko MCP Clients ra Servers lai test ra use garna ko lagi [to the lesson](/03-GettingStarted/07-aitk/README.md)

- **8 Testing**. Yo hissa ma, haami bises gari herne chau kasari server ra client haru lai bibhinna tarikale test garne, [to the lesson](/03-GettingStarted/08-testing/README.md)

- **9 Deployment**. Yo adhyaay ma, haami MCP solutions haru kasari deploy garne bhanne bibhinna tarika haru herne chau, [to the lesson](/03-GettingStarted/09-deployment/README.md)


Model Context Protocol (MCP) ek khulla protocol ho jasle LLM haru lai context dina ko lagi application haru kasari kaam garne bhanne kura standard banaucha. MCP lai AI applications ko lagi USB-C port jasto sochnu hos - yo AI models lai bibhinna data sources ra tools sanga jodne ek standard tarika ho.

## Learning Objectives

Yo paath ko antim samma, tapai le:

- MCP ko lagi C#, Java, Python, TypeScript, ra JavaScript ma development environment set up garna saknu hunchha
- Basic MCP servers banaune ra deploy garne jas ma custom features haru (resources, prompts, ra tools) samet hunchhan
- Host applications banaune jasle MCP servers sanga connect garna sakos
- MCP implementation haru test ra debug garna saknu hunchha
- Samanya setup sambandhi samasya haru ra tinka samadhan bujhna saknu hunchha
- Tapai ko MCP implementation haru lai popular LLM services sanga connect garna saknu hunchha

## Setting Up Your MCP Environment

MCP sanga kaam garnu agadi, development environment tayar garnu ra basic workflow bujhnu jaruri cha. Yo hissa le suru ko setup ko kadam haru batauncha jasle MCP sanga ramro suru garna madat garnecha.

### Prerequisites

MCP development ma lagna agadi, nischit garnu hos ki:

- **Development Environment**: Tapai le chuneko language ko lagi (C#, Java, Python, TypeScript, wa JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, wa kunai modern code editor
- **Package Managers**: NuGet, Maven/Gradle, pip, wa npm/yarn
- **API Keys**: Kunai pani AI services jasko upayog tapai le tapai ko host applications ma garne plan garnu bhaeko cha

### Official SDKs

Agaami adhyaay haru ma tapai le Python, TypeScript, Java ra .NET use gari banayeka solutions hernu hunchha. Yo sabai official rup ma support garne SDK haru ho.

MCP le bibhinna language haru ko lagi official SDK haru pradan garcha:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft sanga sahayog ma maintain garine
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI sanga sahayog ma maintain garine
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Official TypeScript implementation
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Official Python implementation
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Official Kotlin implementation
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI sanga sahayog ma maintain garine
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Official Rust implementation

## Key Takeaways

- MCP development environment set up garnu language-specific SDK haru sanga sajilo cha
- MCP servers banauna tools create ra register garne jasle clear schemas sametcha
- MCP clients servers ra models sanga connect hune jasle extended capabilities ko upayog garna sakos
- Testing ra debugging MCP implementation haru ko bishwasniyata ko lagi awashyak cha
- Deployment ko bibhinna option haru chan, local development dekhi cloud-based solutions samma

## Practicing

Hamro sanga samples ko ek set cha jasle yo section ko sabai adhyaay haru ma dekhaune exercises lai purak dincha. Pratyek adhyaay ma afnai exercises ra assignments pani chan.

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Additional Resources

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## What's next

Next: [Creating your first MCP Server](/03-GettingStarted/01-first-server/README.md)

**अस्वीकरण**:  
यो दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरेर अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटिहरू वा असत्यताहरू हुन सक्छन्। मूल दस्तावेज़ यसको मूल भाषामा आधिकारिक स्रोत मानिनु पर्छ। महत्वपूर्ण जानकारीको लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न हुने कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।