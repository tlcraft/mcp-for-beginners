<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "37563349cd6894fe00489bf3b4d488ae",
  "translation_date": "2025-06-02T10:39:21+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "ms"
}
-->
### -2- Create  project

SDK-നു് ഇൻസ്റ്റാൾ ചെയ്തതിനു ശേഷം, ഇനി ഒരു പ്രോജക്റ്റ് സൃഷ്ടിക്കാം:

### -3- Create project files

### -4- Create server code

### -5- Adding a tool and a resource

താഴെ കൊടുത്തിരിക്കുന്ന കോഡ് ചേർത്ത് ഒരു ടൂൾക്കും ഒരു റിസോഴ്സിനും ചേർക്കുക:

### -6 Final code

സെർവർ ആരംഭിക്കാനുള്ള അവസാന കോഡ് ചേർക്കാം:

### -7- Test the server

താഴെ കൊടുത്തിരിക്കുന്ന കമാൻഡ് ഉപയോഗിച്ച് സെർവർ ആരംഭിക്കുക:

### -8- Run using the inspector

ഇൻസ്പെക്ടർ ഒരു മികച്ച ടൂൾ ആണ്, ഇത് നിങ്ങളുടെ സെർവർ ആരംഭിച്ച് അതുമായി ഇടപഴകാനും, പ്രവർത്തനം പരിശോധിക്കാനും സഹായിക്കുന്നു. ഇത് ആരംഭിക്കാം:

> [!NOTE]
> "command" ഫീൽഡിൽ കാണുന്നത് നിങ്ങളുടെ റൺടൈം അനുസരിച്ചുള്ള സെർവർ റൺ ചെയ്യാനുള്ള കമാൻഡ് ആയിരിക്കും, അതിനാൽ വ്യത്യസ്തമായി കാണാൻ സാധ്യതയുണ്ട്

നിങ്ങൾക്ക് താഴെ കാണുന്ന യൂസർ ഇന്റർഫേസ് കാണാൻ സാധിക്കും:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ms.png)

1. Connect ബട്ടൺ തിരഞ്ഞെടുക്കുക സെർവറുമായി കണക്ട് ചെയ്യാൻ  
   കണക്ട് ചെയ്ത ശേഷം, താഴെ കാണുന്ന സ്ക്രീൻ കാണാം:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.ms.png)

2. "Tools" സെക്ഷനിൽ "listTools" തിരഞ്ഞെടുക്കുക, "Add" കാണാൻ തുടങ്ങും, അതിനെ തിരഞ്ഞെടുക്കുക, ശേഷം പാരാമീറ്റർ മൂല്യങ്ങൾ പൂരിപ്പിക്കുക.

   "add" ടൂൾ പ്രവർത്തിച്ച ഫലം താഴെ കാണാം:

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.ms.png)

അഭിനന്ദനങ്ങൾ, നിങ്ങൾ ആദ്യ MCP സെർവർ സൃഷ്ടിച്ച് പ്രവർത്തിപ്പിക്കാൻ കഴിഞ്ഞു!

### Official SDKs

MCP വിവിധ ഭാഷകളിൽ ഔദ്യോഗിക SDKകൾ നൽകുന്നു:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft-നുമായി സഹകരിച്ച് സംരക്ഷിക്കപ്പെടുന്നു
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI-യുമായി സഹകരിച്ച് സംരക്ഷിക്കപ്പെടുന്നു
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - ഔദ്യോഗിക TypeScript ഇംപ്ലിമെന്റേഷൻ
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - ഔദ്യോഗിക Python ഇംപ്ലിമെന്റേഷൻ
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - ഔദ്യോഗിക Kotlin ഇംപ്ലിമെന്റേഷൻ
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI-യുമായി സഹകരിച്ച് സംരക്ഷിക്കപ്പെടുന്നു
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - ഔദ്യോഗിക Rust ഇംപ്ലിമെന്റേഷൻ

## Key Takeaways

- MCP ഡെവലപ്പ്മെന്റ് എൻവയ്റൺമെന്റ് ഭാഷാ-നിഷ്ഠ SDKകളോടെ എളുപ്പത്തിൽ സജ്ജമാക്കാം
- MCP സെർവർ നിർമ്മാണം ടൂളുകൾ സൃഷ്ടിക്കുകയും വ്യക്തമായ സ്കീമകൾ ഉപയോഗിച്ച് രജിസ്റ്റർ ചെയ്യുകയും ചെയ്യുന്നതാണ്
- വിശ്വസനീയമായ MCP ഇംപ്ലിമെന്റേഷനുകൾക്ക് ടെസ്റ്റിംഗ്, ഡീബഗ്ഗിംഗ് അനിവാര്യമാണ്

## Samples 

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Assignment

താങ്കളുടെ ഇഷ്ടമുള്ള ടൂൾ ഉപയോഗിച്ച് ഒരു ലളിതമായ MCP സെർവർ സൃഷ്ടിക്കുക:  
1. നിങ്ങളുടെ പ്രിയപ്പെട്ട ഭാഷയിൽ (.NET, Java, Python, അല്ലെങ്കിൽ JavaScript) ടൂൾ ഇംപ്ലിമെന്റ് ചെയ്യുക.  
2. ഇൻപുട്ട് പാരാമീറ്ററുകളും റിട്ടേൺ മൂല്യങ്ങളും നിർവ്വചിക്കുക.  
3. ഇൻസ്പെക്ടർ ടൂൾ പ്രവർത്തിപ്പിച്ച് സെർവർ ശരിയായി പ്രവർത്തിക്കുന്നുണ്ടോ എന്ന് ഉറപ്പാക്കുക.  
4. വ്യത്യസ്ത ഇൻപുട്ടുകൾ ഉപയോഗിച്ച് ഇംപ്ലിമെന്റേഷൻ ടെസ്റ്റ് ചെയ്യുക.

## Solution

[Solution](./solution/README.md)

## Additional Resources

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## What's next

അടുത്തത്: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.