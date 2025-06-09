<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b547c992c056d4296d641ed8ec2cc4cb",
  "translation_date": "2025-06-02T17:27:38+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "ne"
}
-->
## Getting Started  

Yo section ma kehi lessons haru chan:

- **-1- Timi ko pahilo server**, yo pahilo lesson ma timi kasari timro pahilo server banaune ra inspector tool le kasari inspect garne sikne chau, yo server test ra debug garna ekdam upyogi chha, [to the lesson](/03-GettingStarted/01-first-server/README.md)

- **-2- Client**, yo lesson ma timi kasari client le server sanga connect garne code lekhne sikne chau, [to the lesson](/03-GettingStarted/02-client/README.md)

- **-3- Client with LLM**, client lekhne aro ramro tarika ho LLM add garera jun server sanga "negotiate" garna sakos, [to the lesson](/03-GettingStarted/03-llm-client/README.md)

- **-4- Consuming a server GitHub Copilot Agent mode in Visual Studio Code**. Yo ma haami Visual Studio Code bhitra bata MCP Server kasari run garne herne chau, [to the lesson](/03-GettingStarted/04-vscode/README.md)

- **-5- Consuming from a SSE (Server Sent Events)** SSE server-to-client streaming ko standard ho, jasle server le HTTP ma realtime updates client haru lai push garna dincha [to the lesson](/03-GettingStarted/05-sse-server/README.md)

- **-6- Utilising AI Toolkit for VSCode** le timro MCP Clients ra Servers lai consume garna ra test garna madat garcha [to the lesson](/03-GettingStarted/06-aitk/README.md)

- **-7 Testing**. Yo ma haami kasari hami le server ra client lai bibhinna tarikale test garna sakincha bhanera focus garne chau, [to the lesson](/03-GettingStarted/07-testing/README.md)

- **-8- Deployment**. Yo chapter ma hami MCP solutions kasari deploy garne bhanera herne chau, [to the lesson](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) ek open protocol ho jun le applications haru lai LLMs sanga context provide garna standard banaucha. MCP lai AI applications ko lagi USB-C port jasto sochnu, jasle AI models lai bibhinna data sources ra tools sanga connect garna standardized tarika dincha.

## Learning Objectives

Yo lesson ko antim samma, timi yei garna sakne chau:

- MCP ko lagi C#, Java, Python, TypeScript, ra JavaScript ma development environment setup garne
- Custom features (resources, prompts, ra tools) sanga basic MCP servers build ra deploy garne
- MCP servers sanga connect garne host applications create garne
- MCP implementations test ra debug garne
- Common setup challenges ra tinka solutions bujhne
- Popular LLM services sanga timro MCP implementations connect garne

## Setting Up Your MCP Environment

MCP sanga kaam garnu agadi, development environment prepare garnu ra basic workflow bujhnu jaruri chha. Yo section le initial setup ko steps haru guide garne cha jasle MCP sanga smoothly suru garna dincha.

### Prerequisites

MCP development ma utarna agadi, tapai le sure garnu parcha ki:

- **Development Environment**: Tapai le chune ko language ko lagi (C#, Java, Python, TypeScript, or JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, wa kunai modern code editor
- **Package Managers**: NuGet, Maven/Gradle, pip, wa npm/yarn
- **API Keys**: Kunai pani AI services jaslai tapai le host applications ma use garna chahanu huncha bhane

### Official SDKs

Aghami chapters ma timi le Python, TypeScript, Java ra .NET use gareka solutions herna pauhcha. Yo haamro officially supported SDK haru ko list ho.

MCP le dherai languages ko lagi official SDKs provide garcha:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft sanga milera maintain gareko
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI sanga milera maintain gareko
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Official TypeScript implementation
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Official Python implementation
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Official Kotlin implementation
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI sanga milera maintain gareko
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Official Rust implementation

## Key Takeaways

- MCP development environment setup garnu language-specific SDK haru sanga sajilo chha
- MCP servers build garnu ko matlab tools create ra register garne jasle clear schemas follow garcha
- MCP clients servers ra models sanga connect garera extended capabilities use garcha
- Testing ra debugging MCP implementations ko lagi dherai jaruri chha
- Deployment options local development dekhi cloud-based solutions samma cha

## Practicing

Hamro sanga samples ko set cha jun exercises haru lai supplement garcha jaslai tapai le yo section ko sabai chapters ma herna pauhcha. Sabai chapter haru ma afno exercises ra assignments pani chan.

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
यो दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) को प्रयोग गरेर अनुवाद गरिएको हो। हामी सटीकता को लागि प्रयासरत छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटिहरू वा अशुद्धिहरू हुन सक्छन्। मूल दस्तावेज़ यसको मूल भाषामा अधिकारिक स्रोत मानिनु पर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानवीय अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न हुने कुनै पनि गलतफहमी वा गलत व्याख्याको लागि हामी जिम्मेवार छैनौं।