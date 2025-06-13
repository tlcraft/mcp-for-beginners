<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bf05718d019040cf0c7d4ccc6d6a1a88",
  "translation_date": "2025-06-13T06:04:50+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "ms"
}
-->
### -2- Create  project

ഇപ്പോൾ നിങ്ങൾക്ക് SDK ഇൻസ്റ്റാൾ ചെയ്തിട്ടുണ്ട്, അടുത്തതായി ഒരു പ്രോജക്റ്റ് സൃഷ്ടിക്കാം: 

### -3- Create project files

### -4- Create server code

### -5- Adding a tool and a resource

താഴെ കാണുന്ന കോഡ് ചേർത്ത് ഒരു ടൂൾ കൂടാതെ ഒരു റിസോഴ്‌സ് കൂടി ചേർക്കുക:

### -6 Final code

സർവർ ആരംഭിക്കാൻ ആവശ്യമായ അവസാന കോഡ് ചേർക്കാം:

### -7- Test the server

താഴെ കാണുന്ന കമാൻഡ് ഉപയോഗിച്ച് സർവർ ആരംഭിക്കുക:

### -8- Run using the inspector

Inspector ഒരു മികച്ച ഉപകരണം ആണ്, ഇത് നിങ്ങളുടെ സർവർ ആരംഭിക്കുകയും അതുമായി ഇടപഴകാനും സഹായിക്കും, അതിലൂടെ നിങ്ങൾ ടെസ്റ്റ് ചെയ്യാം അത് ശരിയായി പ്രവർത്തിക്കുന്നുണ്ടോ എന്ന്. അതിനായി തുടക്കം കുറിക്കാം:

> [!NOTE]
> "command" ഫീൽഡിൽ കാണുന്നത് നിങ്ങളുടെ റൺടൈം അനുസരിച്ച് സർവർ റൺ ചെയ്യാനുള്ള കമാൻഡ് ആയിരിക്കും, അതിനാൽ അത് വ്യത്യസ്തമായി കാണാം

നിങ്ങൾക്ക് താഴെ കാണുന്ന യൂസർ ഇന്റർഫേസ് കാണാൻ സാധിക്കും:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ms.png)

1. Connect ബട്ടൺ തിരഞ്ഞെടുക്കുക, സർവറുമായി കണക്ട് ചെയ്യുക  
  സർവറുമായി കണക്ട് ചെയ്ത ശേഷം, നിങ്ങൾക്ക് താഴെ കാണുന്ന ദൃശ്യവും കാണാനാകും:

  ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.ms.png)

2. "Tools" സെക്ഷനിൽ "listTools" തിരഞ്ഞെടുക്കുക, "Add" എന്ന ഓപ്ഷൻ കാണാം, അത് തിരഞ്ഞെടുക്കുക, പിന്നീട് പാരാമീറ്റർ മൂല്യങ്ങൾ പൂരിപ്പിക്കുക.

  നിങ്ങൾക്ക് "add" ടൂളിൽ നിന്നുള്ള ഫലമായി താഴെ കാണുന്ന പ്രതികരണം ലഭിക്കും:

  ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.ms.png)

അഭിനന്ദനങ്ങൾ, നിങ്ങൾ ആദ്യ MCP സർവർ വിജയകരമായി സൃഷ്ടിക്കുകയും പ്രവർത്തിപ്പിക്കുകയും ചെയ്തു!

### Official SDKs

MCP പല ഭാഷകളിലും ഔദ്യോഗിക SDKകൾ നൽകുന്നു:  
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft-ഉം സഹകരിച്ച് പരിപാലിക്കുന്നു  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI-യുമായി സഹകരിച്ച് പരിപാലിക്കുന്നു  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - ഔദ്യോഗിക TypeScript ഇംപ്ലിമെന്റേഷൻ  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - ഔദ്യോഗിക Python ഇംപ്ലിമെന്റേഷൻ  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - ഔദ്യോഗിക Kotlin ഇംപ്ലിമെന്റേഷൻ  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI-യുമായി സഹകരിച്ച് പരിപാലിക്കുന്നു  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - ഔദ്യോഗിക Rust ഇംപ്ലിമെന്റേഷൻ  

## Key Takeaways

- MCP ഡവലപ്പ്മെന്റ് എൻവയോൺമെന്റ് സജ്ജമാക്കുന്നത് ഭാഷാനുസൃത SDKകളോടെ എളുപ്പമാണ്  
- MCP സർവർ നിർമ്മാണത്തിൽ വ്യക്തമായ സ്കീമകളോടെ ടൂളുകൾ സൃഷ്ടിക്കുകയും രജിസ്റ്റർ ചെയ്യുകയും ചെയ്യുന്നു  
- വിശ്വാസയോഗ്യമായ MCP ഇംപ്ലിമെന്റേഷനുകൾക്കായി ടെസ്റ്റിംഗ്, ഡീബഗ്ഗിംഗ് അനിവാര്യമാണ്  

## Samples 

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## Assignment

നിങ്ങളുടെ ഇഷ്ടമുള്ള ടൂളുമായി ഒരു ലളിതമായ MCP സർവർ സൃഷ്ടിക്കുക:  
1. നിങ്ങളുടെ ഇഷ്ടഭാഷയിൽ ടൂൾ ഇംപ്ലിമെന്റ് ചെയ്യുക (.NET, Java, Python, അല്ലെങ്കിൽ JavaScript).  
2. ഇൻപുട്ട് പാരാമീറ്ററുകളും റിട്ടേൺ മൂല്യങ്ങളും നിർവ്വചിക്കുക.  
3. സർവർ ഉദ്ദേശിച്ചതുപോലെ പ്രവർത്തിക്കുന്നുണ്ടോ എന്ന് ഉറപ്പാക്കാൻ Inspector ഉപകരണം റൺ ചെയ്യുക.  
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
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.