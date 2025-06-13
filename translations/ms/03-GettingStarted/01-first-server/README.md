<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d90651bcd1df019768921d531653638a",
  "translation_date": "2025-06-13T00:35:37+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "ms"
}
-->
### -2- Create  project

ഇപ്പോൾ നിങ്ങളുടെ SDK ഇൻസ്റ്റാൾ ചെയ്തതിനുശേഷം, അടുത്തതായി ഒരു പ്രോജക്ട് സൃഷ്ടിക്കാം:

### -3- Create project files

### -4- Create server code

### -5- Adding a tool and a resource

താഴെ കൊടുത്തിരിക്കുന്ന കോഡ് ചേർത്തു ഒരു ടൂൾ കൂടാതെ ഒരു റിസോഴ്‌സ് ചേർക്കുക:

### -6 Final code

സെർവർ ആരംഭിക്കാൻ ആവശ്യമായ അവസാന കോഡ് ചേർക്കാം:

### -7- Test the server

താഴെ കാണുന്ന കമാൻഡ് ഉപയോഗിച്ച് സെർവർ ആരംഭിക്കുക:

### -8- Run using the inspector

Inspector ഒരു മികച്ച ടൂൾ ആണ്, ഇത് നിങ്ങളുടെ സെർവർ ആരംഭിച്ച് അതുമായി സംവദിക്കാൻ സഹായിക്കുന്നു, അങ്ങനെ നിങ്ങൾക്ക് അത് ശരിയായി പ്രവർത്തിക്കുന്നുവെന്ന് പരിശോധിക്കാം. അത് ആരംഭിക്കാം:

> [!NOTE]
> "command" ഫീൽഡിൽ കാണുന്നത് നിങ്ങളുടെ റൺടൈം അനുസരിച്ച് സെർവർ ഓടിക്കുന്ന കമാൻഡ് വ്യത്യസ്തമായിരിക്കും.

നിങ്ങൾക്ക് താഴെ കാണുന്ന യൂസർ ഇന്റർഫേസ് കാണാൻ സാധിക്കും:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ms.png)

1. Connect ബട്ടൺ തിരഞ്ഞെടുക്കുക സെർവറുമായി കണക്റ്റ് ചെയ്യാൻ  
   കണക്റ്റ് ചെയ്ത ശേഷം താഴെ കാണുന്ന ഇന്റർഫേസ് നിങ്ങൾക്ക് കാണാം:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.ms.png)

2. "Tools" എന്നത് തിരഞ്ഞെടുത്ത് "listTools" തിരഞ്ഞെടുക്കുക, "Add" കാണാനാകും, അതിൽ ക്ലിക്ക് ചെയ്ത് പാരാമീറ്റർ മൂല്യങ്ങൾ നൽകുക.

   "Add" ടൂളിൽ നിന്നുള്ള ഫലം താഴെ കാണുന്ന പോലെ കാണാൻ സാധിക്കും:

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.ms.png)

അഭിനന്ദനങ്ങൾ, നിങ്ങൾ ആദ്യ MCP സെർവർ സൃഷ്ടിച്ച് പ്രവർത്തിപ്പിച്ചു!

### Official SDKs

MCP വിവിധ ഭാഷകൾക്കായി ഔദ്യോഗിക SDKകൾ നൽകുന്നു:  
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft നുമായി സഹകരിച്ച് പരിപാലിക്കുന്നു  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI യുമായി സഹകരിച്ച് പരിപാലിക്കുന്നു  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - ഔദ്യോഗിക TypeScript ഇംപ്ലിമെന്റേഷൻ  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - ഔദ്യോഗിക Python ഇംപ്ലിമെന്റേഷൻ  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - ഔദ്യോഗിക Kotlin ഇംപ്ലിമെന്റേഷൻ  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI യുമായി സഹകരിച്ച് പരിപാലിക്കുന്നു  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - ഔദ്യോഗിക Rust ഇംപ്ലിമെന്റേഷൻ  

## Key Takeaways

- MCP ഡെവലപ്പ്മെന്റ് പരിസ്ഥിതി ഭാഷാനുസൃത SDKകളോടെ എളുപ്പത്തിൽ സജ്ജീകരിക്കാം  
- MCP സെർവർ നിർമ്മാണം ടൂളുകൾ സൃഷ്ടിക്കുകയും സ്പഷ്ടമായ സ്കീമകൾ ഉപയോഗിച്ച് രജിസ്റ്റർ ചെയ്യുകയും ചെയ്യുന്നതിലാണു്  
- വിശ്വാസയോഗ്യമായ MCP ഇംപ്ലിമെന്റേഷനുകൾക്ക് ടെസ്റ്റിംഗും ഡീബഗ്ഗിംഗും അത്യന്താപേക്ഷിതമാണ്  

## Samples 

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## Assignment

നിങ്ങളുടെ ഇഷ്ടഭാഷയിൽ ഒരു ലളിതമായ MCP സെർവർ ഒരു ടൂൾ ഉപയോഗിച്ച് സൃഷ്ടിക്കുക:  
1. ടൂൾ നിങ്ങളുടെ ഇഷ്ടഭാഷയിൽ (.NET, Java, Python, അല്ലെങ്കിൽ JavaScript) ഇംപ്ലിമെന്റ് ചെയ്യുക.  
2. ഇൻപുട്ട് പാരാമീറ്ററുകളും റിട്ടേൺ വാല്യുകളും നിർവചിക്കുക.  
3. സെർവർ ശരിയായി പ്രവർത്തിക്കുന്നുണ്ടോ എന്ന് ഉറപ്പാക്കാൻ inspector ടൂൾ റൺ ചെയ്യുക.  
4. വിവിധ ഇൻപുട്ടുകളുമായി ഇംപ്ലിമെന്റേഷൻ ടെസ്റ്റ് ചെയ്യുക.  

## Solution

[Solution](./solution/README.md)

## Additional Resources

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)  
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)  
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)  

## What's next

അടുത്തത്: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sah. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau tafsiran yang timbul daripada penggunaan terjemahan ini.