<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3dd2f1e39277c31b0e57e29d165354d6",
  "translation_date": "2025-06-13T00:36:08+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "ms"
}
-->
ഇപ്പോൾ നമുക്ക് SSE കുറിച്ച് കുറച്ച് കൂടി അറിയാമെങ്കിൽ, അടുത്തതായി ഒരു SSE സെർവർ നിർമ്മിക്കാം.

## അഭ്യാസം: ഒരു SSE സെർവർ സൃഷ്ടിക്കൽ

നമ്മുടെ സെർവർ സൃഷ്ടിക്കാൻ, രണ്ട് കാര്യങ്ങൾ മനസ്സിൽ വെക്കണം:

- കണക്ഷനും സന്ദേശങ്ങളും എക്സ്പോസ് ചെയ്യാൻ വെബ് സെർവർ ഉപയോഗിക്കണം.
- stdio ഉപയോഗിച്ചപ്പോലെ ടൂൾസ്, റിസോഴ്സുകൾ, പ്രോംപ്റ്റുകൾ ഉപയോഗിച്ച് സെർവർ നിർമ്മിക്കണം.

### -1- സെർവർ ഇൻസ്റ്റൻസ് സൃഷ്ടിക്കുക

സെർവർ സൃഷ്ടിക്കാൻ, stdio ഉപയോഗിച്ച പോലെ തന്നെ ടൈപ്പുകൾ ഉപയോഗിക്കുന്നു. എന്നാൽ, ട്രാൻസ്പോർട്ടായി SSE തിരഞ്ഞെടുക്കണം.

---

അടുത്തതായി ആവശ്യമായ റൂട്ടുകൾ ചേർക്കാം.

### -2- റൂട്ടുകൾ ചേർക്കുക

കണക്ഷനും വരുന്ന സന്ദേശങ്ങളും കൈകാര്യം ചെയ്യുന്ന റൂട്ടുകൾ ചേർക്കാം:

---

ഇപ്പോൾ സെർവറിന് ശേഷിക്കുന്ന കഴിവുകൾ ചേർക്കാം.

### -3- സെർവർ കഴിവുകൾ ചേർക്കൽ

SSE-യുമായി ബന്ധപ്പെട്ട എല്ലാം നിർവചിച്ചതിനുശേഷം, ടൂൾസ്, പ്രോംപ്റ്റുകൾ, റിസോഴ്സുകൾ പോലുള്ള സെർവർ കഴിവുകൾ ചേർക്കാം.

---

നിങ്ങളുടെ പൂർണ്ണ കോഡ് ഇങ്ങനെ കാണണം:

---

സൂപ്പർ, നമുക്ക് SSE ഉപയോഗിക്കുന്ന ഒരു സെർവർ ഉണ്ടായി, ഇനി അത് പരീക്ഷിക്കാം.

## അഭ്യാസം: Inspector ഉപയോഗിച്ച് SSE സെർവർ ഡീബഗ് ചെയ്യൽ

Inspector ഒരു മികച്ച ടൂൾ ആണ്, ഇത് നാം മുമ്പത്തെ പാഠത്തിൽ [Creating your first server](/03-GettingStarted/01-first-server/README.md) കണ്ടിട്ടുണ്ട്. ഇതെന്തെന്ന് നോക്കാം, ഇവിടെ ഉപയോഗിക്കാമോ:

### -1- Inspector പ്രവർത്തിപ്പിക്കൽ

Inspector പ്രവർത്തിപ്പിക്കാൻ, ആദ്യം ഒരു SSE സെർവർ പ്രവർത്തിക്കണം, അതിനാൽ അത് പ്രവർത്തിപ്പിക്കാം:

1. സെർവർ റൺ ചെയ്യുക

---

1. Inspector റൺ ചെയ്യുക

    > ![NOTE]
    > സെർവർ പ്രവർത്തിക്കുന്ന ടെർമിനലിനേക്കാൾ വേറിട്ട ഒരു ടെർമിനൽ വിൻഡോയിൽ ഇത് റൺ ചെയ്യുക. കൂടാതെ, താഴെയുള്ള കമാൻഡ് നിങ്ങളുടെ സെർവർ പ്രവർത്തിക്കുന്ന URL-നുസരിച്ച് ക്രമീകരിക്കേണ്ടതുണ്ട്.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    എല്ലാ റൺടൈമുകളിലും Inspector പ്രവർത്തനം ഒരുപോലെയാണ്. സെർവർ ആരംഭിക്കാൻ പാതയും കമാൻഡും പാസാക്കുന്നതിനുപകരം, സെർവർ പ്രവർത്തിക്കുന്ന URL-യും `/sse` റൂട്ടും നൽകുന്നത് ശ്രദ്ധിക്കുക.

### -2- ടൂൾ പരീക്ഷിക്കൽ

SSE തിരഞ്ഞെടുക്കുക, സെർവർ പ്രവർത്തിക്കുന്ന URL ഫീൽഡിൽ, ഉദാഹരണത്തിന് http:localhost:4321/sse നൽകുക. "Connect" ബട്ടൺ അമർത്തുക. മുൻപുപോലെ, ടൂൾ ലിസ്റ്റ് ചെയ്യുക, ഒരു ടൂൾ തിരഞ്ഞെടുക്കുക, ഇൻപുട്ട് നൽകുക. താഴെയുള്ള പോലെ ഫലം കാണണം:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.ms.png)

സുപ്രഭാതം, Inspector ഉപയോഗിക്കാൻ കഴിയുന്നു, ഇനി Visual Studio Code-ൽ എങ്ങനെ പ്രവർത്തിക്കാമെന്ന് നോക്കാം.

## അസൈൻമെന്റ്

നിങ്ങളുടെ സെർവർ കൂടുതൽ കഴിവുകൾ കൊണ്ട് വികസിപ്പിക്കാൻ ശ്രമിക്കുക. ഉദാഹരണത്തിന്, [ഈ പേജ്](https://api.chucknorris.io/) സന്ദർശിച്ച് ഒരു API വിളിക്കുന്ന ടൂൾ ചേർക്കാം, സെർവർ എങ്ങനെ കാണണം നിങ്ങൾ തീരുമാനിക്കുക. സന്തോഷത്തോടെ പ്രവർത്തിക്കൂ :)

## പരിഹാരം

[പരിഹാരം](./solution/README.md) പ്രവർത്തനക്ഷമമായ കോഡോടെ ഒരു സാധ്യത പരിഹാരമാണ്.

## പ്രധാന സാരാംശങ്ങൾ

ഈ അധ്യായത്തിലെ പ്രധാന സാരാംശങ്ങൾ:

- SSE stdio-യ്ക്ക് പുറമേ രണ്ടാമത്തെ പിന്തുണയുള്ള ട്രാൻസ്പോർട്ട് ആണ്.
- SSE പിന്തുണയ്ക്കാൻ, വെബ് ഫ്രെയിംവർക്കിൽ കണക്ഷനുകളും സന്ദേശങ്ങളും കൈകാര്യം ചെയ്യണം.
- Inspector-യും Visual Studio Code-ഉം SSE സെർവർ ഉപയോഗിക്കാൻ കഴിയും, stdio സെർവറുകളുപോലെ. stdio-യുമായി SSE-യുടെ വ്യത്യാസം ശ്രദ്ധിക്കുക. SSE-യിൽ, സെർവർ സ്വതന്ത്രമായി ആരംഭിച്ച് Inspector ടൂൾ റൺ ചെയ്യണം. Inspector ടൂളിൽ URL നിർദ്ദേശിക്കേണ്ടതും ഉണ്ട്.

## സാമ്പിളുകൾ

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## അധിക സ്രോതസ്സുകൾ

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## അടുത്തത്

- അടുത്തത്: [HTTP Streaming with MCP (Streamable HTTP)](/03-GettingStarted/06-http-streaming/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.