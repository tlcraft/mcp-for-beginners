<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8fdd5786214b32ad33d8b5cf9012a0f7",
  "translation_date": "2025-05-17T08:16:26+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "sl"
}
-->
## ආරම්භක මාර්ගෝපදේශය  

මෙම කොටස විභාග කිහිපයක් අඩංගු වේ:

- **-1- ඔබේ පළමු සේවාදායකය**: පළමු විභාගයේදී, ඔබේ පළමු සේවාදායකය නිර්මාණය කර, පරීක්ෂක මෙවලම සමඟ පරීක්ෂා කරන ආකාරය ඉගෙන ගනිමු. මෙය ඔබේ සේවාදායකය පරීක්ෂා කිරීම සහ නිරාකරණය කිරීම සඳහා වටිනා ක්‍රමයකි, [විභාගය වෙත](/03-GettingStarted/01-first-server/README.md)

- **-2- සේවාලාභියා**: මෙම විභාගයේදී, ඔබේ සේවාදායකය සමඟ සම්බන්ධ විය හැකි සේවාලාභියෙක් ලිවීමේ ආකාරය ඉගෙන ගනිමු, [විභාගය වෙත](/03-GettingStarted/02-client/README.md)

- **-3- LLM සමඟ සේවාලාභියා**: සේවාලාභියෙක් ලිවීමේ වඩා හොඳ ක්‍රමයක් ලෙස, LLM එකක් එකතු කිරීමෙන්, ඔබේ සේවාදායකය සමඟ "ගණුදෙනු" කිරීමේ හැකියාවක් ලබා දෙන ආකාරය, [විභාගය වෙත](/03-GettingStarted/03-llm-client/README.md)

- **-4- Visual Studio Code හි GitHub Copilot Agent මාදිලිය සමඟ සේවාදායකය භාවිතා කිරීම**: මෙහිදී, Visual Studio Code තුළින් අපගේ MCP සේවාදායකය ක්‍රියාත්මක කිරීම ගැන කතා කරමු, [විභාගය වෙත](/03-GettingStarted/04-vscode/README.md)

- **-5- SSE (Server Sent Events) මඟින් භාවිතා කිරීම**: SSE යනු සේවාදායක-සේවාලාභි සම්බන්ධීකරණය සඳහා සම්මතයක් වන අතර, HTTP මඟින් සේවාදායකයන්ට සේවාලාභීන්ට සජීවී යාවත්කාලීන කිරීම් දැන්වීමේ හැකියාව ලබා දෙයි, [විභාගය වෙත](/03-GettingStarted/05-sse-server/README.md)

- **-6- AI Toolkit for VSCode භාවිතා කිරීම**: ඔබේ MCP සේවාලාභීන් සහ සේවාදායකයන් පරීක්ෂා කිරීම සඳහා [විභාගය වෙත](/03-GettingStarted/06-aitk/README.md)

- **-7- පරීක්ෂා කිරීම**: මෙහිදී, විවිධ ක්‍රම වලින් ඔබේ සේවාදායකය සහ සේවාලාභිය පරීක්ෂා කිරීමේ ආකාරය විශේෂයෙන් අවධානය යොමු කරමු, [විභාගය වෙත](/03-GettingStarted/07-testing/README.md)

- **-8- නිකුතුව**: මෙම පරිච්ඡේදය ඔබේ MCP විසඳුම් නිකුත් කිරීමේ විවිධ ක්‍රම සොයා බැලීමේදී, [විභාගය වෙත](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) යනු AI මොඩල සඳහා විවිධ දත්ත මූලාශ්‍ර හා මෙවලම් සමඟ සම්බන්ධ වීමේ සම්මත ක්‍රමයක් සපයන විවෘත සම්මතයකි. MCP සම්බන්ධිත AI යෙදුම් සඳහා USB-C වර්ගයක් ලෙස සලකා බලන්න.

## ඉගෙනුම් අරමුණු

මෙම පාඩම අවසානයේදී, ඔබට හැකිවනු ඇත:

- C#, Java, Python, TypeScript, සහ JavaScript වල MCP සංවර්ධන පරිසර සැකසීම
- අභිරුචි විශේෂාංග (සම්පත්, ප්‍රතිලාභ, සහ මෙවලම්) සහිත මූලික MCP සේවාදායකයන් සාදා නිකුත් කිරීම
- MCP සේවාදායකයන් සමඟ සම්බන්ධ වන සත්කාරක යෙදුම් නිර්මාණය කිරීම
- MCP ක්‍රියාත්මක කිරීම් පරීක්ෂා කිරීම සහ නිරාකරණය කිරීම
- පොදු සැකසුම් අභියෝග සහ ඒවාට විසඳුම් අවබෝධ කර ගැනීම
- ඔබේ MCP ක්‍රියාත්මක කිරීම් ජනප්‍රිය LLM සේවා සමඟ සම්බන්ධ කිරීම

## ඔබේ MCP පරිසරය සැකසීම

MCP සමඟ කටයුතු කිරීමට පෙර, ඔබේ සංවර්ධන පරිසරය සකස් කර, මූලික වැඩ ප්‍රවේශය අවබෝධ කර ගැනීම වැදගත්ය. මෙම කොටස MCP සමඟ සුමුදු ආරම්භයක් සඳහා ආරම්භක සැකසුම් පියවර මඟ පෙන්වනු ඇත.

### පෙරනිමි අවශ්‍යතා

MCP සංවර්ධනයට මුලින්ම පෙර, ඔබට තිබිය යුතුයි:

- **සංවර්ධන පරිසරය**: ඔබේ තෝරාගත් භාෂාව සඳහා (C#, Java, Python, TypeScript, හෝ JavaScript)
- **IDE/සංස්කාරකය**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, හෝ කාලීන කේත සංස්කාරකය
- **පැකේජ කළමනාකරුවන්**: NuGet, Maven/Gradle, pip, හෝ npm/yarn
- **API යතුරු**: ඔබේ සත්කාරක යෙදුම් සඳහා භාවිතා කිරීමට සැලසුම් කරන AI සේවා සඳහා


### නිල SDK

ඉදිරියේ පරිච්ඡේදවල, Python, TypeScript, Java සහ .NET භාවිතා කරන විසඳුම් දැකිය හැකිය. මෙන්න නිල අනුමත සියලුම SDK.

MCP බහු භාෂාවන් සඳහා නිල SDK සපයයි:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft සමඟ එක්ව නඩත්තු කෙරේ
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI සමඟ එක්ව නඩත්තු කෙරේ
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - නිල TypeScript ක්‍රියාත්මක කිරීම
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - නිල Python ක්‍රියාත්මක කිරීම
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - නිල Kotlin ක්‍රියාත්මක කිරීම
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI සමඟ එක්ව නඩත්තු කෙරේ
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - නිල Rust ක්‍රියාත්මක කිරීම

## ප්‍රධාන අවබෝධ

- MCP සංවර්ධන පරිසරයක් සැකසීම භාෂාව අනුව SDK සමඟ සරලයි
- MCP සේවාදායකයන් ගොඩනැගීම සජීවීව සහිත මෙවලම් නිර්මාණය සහ ලියාපදිංචි කිරීම සම්බන්ධ වේ
- MCP සේවාලාභීන් සේවාදායකයන් හා මොඩල සමඟ සම්බන්ධ වී ව්‍යාප්ත හැකියාවන් අත්කර ගැනේ
- විශ්වාසදායක MCP ක්‍රියාත්මක කිරීම් සඳහා පරීක්ෂා කිරීම සහ නිරාකරණය කිරීම අත්‍යවශ්‍ය වේ
- නිකුත් කිරීමේ විකල්ප ස්ථානාන්ත සංවර්ධනයේ සිට වලාකුළු මත පදනම් වූ විසඳුම් දක්වා පවති

## පුහුණුව

මෙම කොටසේ සියලුම පරිච්ඡේදවල දැකිය හැකි විභාගයන්ට අමතරව, අපට උදාහරණ පෙළක් ඇත. අමතරව, සෑම පරිච්ඡේදයකම තමන්ගේම විභාග සහ කාර්යයන් ඇත

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## අමතර සම්පත්

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## ඉදිරියෙහි

ඉදිරිපස: [ඔබේ පළමු MCP සේවාදායකය නිර්මාණය කිරීම](/03-GettingStarted/01-first-server/README.md)

**Omejitev odgovornosti**:
Ta dokument je bil preveden z uporabo storitve AI prevajanja [Co-op Translator](https://github.com/Azure/co-op-translator). Medtem ko si prizadevamo za natančnost, vas prosimo, da upoštevate, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem maternem jeziku naj bo obravnavan kot avtoritativni vir. Za kritične informacije se priporoča profesionalni človeški prevod. Ne prevzemamo odgovornosti za kakršne koli nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.