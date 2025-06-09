<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "262e6e510f0c3fe1e36180eadcd67c33",
  "translation_date": "2025-06-02T17:41:31+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "ms"
}
-->
### -2- Create project

ഇപ്പോൾ നിങ്ങൾക്ക് SDK ഇൻസ്റ്റാൾ ചെയ്തിട്ടുണ്ട്, അടുത്തതായി ഒരു പ്രോജക്ട് സൃഷ്ടിക്കാം: 

### -3- Create project files

### -4- Create server code

### -5- Adding a tool and a resource

താഴെ കൊടുത്തിരിക്കുന്ന കോഡ് ചേർത്ത് ഒരു ടൂൾയും ഒരു റിസോഴ്സും ചേർക്കുക:

### -6 Final code

സർവർ സ്റ്റാർട്ട് ചെയ്യാൻ ആവശ്യമായ അവസാന കോഡ് ചേർക്കാം:

### -7- Test the server

താഴെ കൊടുത്ത കമാൻഡ് ഉപയോഗിച്ച് സർവർ ആരംഭിക്കുക:

### -8- Run using the inspector

Inspector ഒരു മികച്ച ടൂൾ ആണ്, ഇത് നിങ്ങളുടെ സർവർ ആരംഭിപ്പിക്കുകയും അതിൽ ഇടപഴകാനും സഹായിക്കുന്നു, അതിലൂടെ സർവർ ശരിയായി പ്രവർത്തിക്കുന്നുണ്ടോ എന്ന് പരിശോധിക്കാം. ഇത് ആരംഭിക്കാം:

> [!NOTE]
> "command" ഫീൽഡിൽ കാണുന്നത് നിങ്ങളുടെ റൺടൈമിനനുസരിച്ച് സർവർ പ്രവർത്തിപ്പിക്കുന്ന കമാൻഡ് ആകാം, അതിനാൽ വ്യത്യസ്തമായിരിക്കാം

നിങ്ങൾക്ക് താഴെ കാണുന്ന യൂസർ ഇന്റർഫേസ് കാണാൻ സാധിക്കും:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ms.png)

1. Connect ബട്ടൺ സെലക്ട് ചെയ്ത് സർവറുമായി കണക്ട് ചെയ്യുക  
   സർവറുമായി കണക്ട് ചെയ്ത ശേഷം താഴെ കാണുന്നവ നിങ്ങൾക്ക് കാണാം:

  ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.ms.png)

1. "Tools" സെക്ഷനിൽ "listTools" സെലക്ട് ചെയ്യുക, "Add" കാണാൻ സാധിക്കും, "Add" സെലക്ട് ചെയ്ത് പാരാമീറ്റർ മൂല്യങ്ങൾ നൽകുക.

  "add" ടൂളിൽ നിന്നുള്ള ഫലമായ താഴെ കാണുന്ന റിസ്പോൺസ് നിങ്ങൾക്ക് ലഭിക്കും:

  ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.ms.png)

അഭിനന്ദനങ്ങൾ, നിങ്ങൾ നിങ്ങളുടെ ആദ്യ MCP സർവർ സൃഷ്ടിച്ച് പ്രവർത്തിപ്പിക്കാൻ കഴിഞ്ഞു!

### Official SDKs

MCP വിവിധ ഭാഷകളിൽ ഔദ്യോഗിക SDKകൾ നൽകുന്നു:  
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft-നൊപ്പം സംരക്ഷിക്കുന്നു  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI-യുമായി സംരക്ഷിക്കുന്നു  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - ഔദ്യോഗിക TypeScript ഇംപ്ലിമെന്റേഷൻ  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - ഔദ്യോഗിക Python ഇംപ്ലിമെന്റേഷൻ  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - ഔദ്യോഗിക Kotlin ഇംപ്ലിമെന്റേഷൻ  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI-യുമായി സംരക്ഷിക്കുന്നു  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - ഔദ്യോഗിക Rust ഇംപ്ലിമെന്റേഷൻ  

## Key Takeaways

- MCP ഡെവലപ്പ്മെന്റ് എൻവയോൺമെന്റ് ഭാഷാനുസരിച്ചുള്ള SDKകളിലൂടെ എളുപ്പത്തിൽ സജ്ജമാക്കാം  
- MCP സർവർ നിർമ്മാണം ടൂളുകളും സ്കീമകളും സൃഷ്ടിച്ച് രജിസ്റ്റർ ചെയ്യുന്നതിൽ അടിസ്ഥിതമാണ്  
- പരീക്ഷണവും ഡീബഗിംഗും വിശ്വസനീയമായ MCP ഇംപ്ലിമെന്റേഷനുകൾക്ക് അനിവാര്യമാണ്  

## Samples 

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## Assignment

താങ്കളുടെ ഇഷ്ടമുള്ള ഒരു ടൂൾ ഉപയോഗിച്ച് ഒരു ലളിതമായ MCP സർവർ സൃഷ്ടിക്കുക:  
1. നിങ്ങളുടെ ഇഷ്ടഭാഷയിൽ ടൂൾ ഇംപ്ലിമെന്റ് ചെയ്യുക (.NET, Java, Python, അല്ലെങ്കിൽ JavaScript).  
2. ഇൻപുട്ട് പാരാമീറ്ററുകളും റിട്ടേൺ മൂല്യങ്ങളും നിർവചിക്കുക.  
3. ഇൻസ്പെക്ടർ ടൂൾ ഉപയോഗിച്ച് സർവർ ശരിയായി പ്രവർത്തിക്കുന്നുണ്ടോ എന്ന് ഉറപ്പാക്കുക.  
4. വ്യത്യസ്ത ഇൻപുട്ടുകൾ ഉപയോഗിച്ച് ഇംപ്ലിമെന്റേഷൻ ടെസ്റ്റ് ചെയ്യുക.  

## Solution

[Solution](./solution/README.md)

## Additional Resources

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)  
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)  
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)  

## What's next

Next: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab terhadap sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.