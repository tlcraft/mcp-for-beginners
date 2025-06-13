<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "64645691bf0985f1760b948123edf269",
  "translation_date": "2025-06-13T10:54:50+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "ms"
}
-->
ഇപ്പോൾ നമുക്ക് SSE കുറിച്ച് കുറച്ചുകൂടി അറിയാമാകുമ്പോൾ, അടുത്തതായി ഒരു SSE സെർവർ നിർമ്മിക്കാം.

## അഭ്യാസം: ഒരു SSE സെർവർ സൃഷ്ടിക്കൽ

ഞങ്ങളുടെ സെർവർ സൃഷ്ടിക്കാൻ, രണ്ട് കാര്യങ്ങൾ മനസ്സിൽ വെക്കണം:

- കണക്ഷനും സന്ദേശങ്ങളും എക്സ്പോസ് ചെയ്യാൻ ഒരു വെബ് സെർവർ ഉപയോഗിക്കണം.
- stdio ഉപയോഗിച്ചിരുന്ന പോലെ തന്നെ ടൂളുകൾ, റിസോഴ്സുകൾ, പ്രോംപ്റ്റുകൾ എന്നിവ ഉപയോഗിച്ച് സെർവർ നിർമ്മിക്കണം.

### -1- ഒരു സെർവർ ഇൻസ്റ്റൻസ് സൃഷ്ടിക്കുക

സെർവർ സൃഷ്ടിക്കാൻ, stdio ഉപയോഗിച്ച പോലെ തന്നെ ടൈപ്പുകൾ ഉപയോഗിക്കുന്നു. എന്നാൽ, ട്രാൻസ്പോർട്ടായി SSE തിരഞ്ഞെടുക്കണം.

---

അടുത്തതായി ആവശ്യമായ റൂട്ടുകൾ ചേർക്കാം.

### -2- റൂട്ടുകൾ ചേർക്കുക

കണക്ഷനും ഇൻകമിംഗ് സന്ദേശങ്ങളും കൈകാര്യം ചെയ്യുന്ന റൂട്ടുകൾ ചേർക്കാം:

---

അടുത്തതായി സെർവർക്ക് ശേഷിപ്പുകൾ ചേർക്കാം.

### -3- സെർവർ ശേഷിപ്പുകൾ ചേർക്കൽ

SSE-ന് പ്രത്യേകമായി നിർവചിച്ച എല്ലാ കാര്യങ്ങളും കഴിഞ്ഞപ്പോൾ, ടൂളുകൾ, പ്രോംപ്റ്റുകൾ, റിസോഴ്സുകൾ പോലുള്ള സെർവർ ശേഷിപ്പുകൾ ചേർക്കാം.

---

നിങ്ങളുടെ പൂർണ്ണ കോഡ് ഇപ്രകാരം കാണപ്പെടണം:

---

അറിഞ്ഞു, SSE ഉപയോഗിച്ച് ഒരു സെർവർ ഉണ്ടാക്കി, ഇപ്പോൾ അത് പരീക്ഷിക്കാം.

## അഭ്യാസം: Inspector ഉപയോഗിച്ച് SSE സെർവർ ഡീബഗ് ചെയ്യൽ

Inspector ഒരു മികച്ച ടൂൾ ആണ്, ഇത് നമുക്ക് മുമ്പത്തെ പാഠത്തിൽ [Creating your first server](/03-GettingStarted/01-first-server/README.md) കണ്ടിട്ടുണ്ട്. ഇതിൽ തന്നെ Inspector ഉപയോഗിക്കാമോ നോക്കാം:

### -1- Inspector പ്രവർത്തിപ്പിക്കുക

Inspector പ്രവർത്തിപ്പിക്കാൻ, ആദ്യം SSE സെർവർ പ്രവർത്തനത്തിൽ വേണം, അതിനാൽ അത് നടത്താം:

1. സെർവർ പ്രവർത്തിപ്പിക്കുക

---

1. Inspector പ്രവർത്തിപ്പിക്കുക

    > ![NOTE]
    > സെർവർ പ്രവർത്തിക്കുന്ന ടെർമിനൽ വിൻഡോയിലല്ല, വേറെ ടെർമിനൽ വിൻഡോയിൽ ഇത് പ്രവർത്തിപ്പിക്കുക. കൂടാതെ, നിങ്ങളുടെ സെർവർ പ്രവർത്തിക്കുന്ന URL-നുസരിച്ച് താഴെ കാണിച്ച കമാൻഡ് ക്രമീകരിക്കുക.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    എല്ലാ റൺടൈംസിലും Inspector പ്രവർത്തിപ്പിക്കൽ ഒരുപോലെ ആണ്. സെർവർ ആരംഭിക്കുന്ന കമാൻഡ് നൽകുന്നതിനുപകരം, സെർവർ പ്രവർത്തിക്കുന്ന URLയും `/sse` റൂട്ടും നാം നൽകുന്നു എന്നത് ശ്രദ്ധിക്കുക.

### -2- ടൂൾ പരീക്ഷിക്കുക

SSE തിരഞ്ഞെടുക്കുക, നിങ്ങളുടെ സെർവർ പ്രവർത്തിക്കുന്ന URL ഫീൽഡിൽ പൂരിപ്പിക്കുക, ഉദാഹരണത്തിന് http:localhost:4321/sse. "Connect" ബട്ടൺ ക്ലിക്ക് ചെയ്യുക. മുൻപുള്ള പോലെ, ടൂളുകൾ പട്ടികയിൽ നിന്ന് തിരഞ്ഞെടുക്കുക, ഒരു ടൂൾ തിരഞ്ഞെടുക്കുക, ഇൻപുട്ട് നൽകുക. താഴെ കാണുന്ന പോലെ ഫലം കാണാം:

![Inspector-ൽ പ്രവർത്തിക്കുന്ന SSE സെർവർ](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.ms.png)

നല്ലത്, Inspector ഉപയോഗിച്ച് പ്രവർത്തിക്കാൻ കഴിഞ്ഞു, ഇനി Visual Studio Code-ൽ എങ്ങനെ പ്രവർത്തിക്കാമെന്ന് നോക്കാം.

## അസൈൻമെന്റ്

നിങ്ങളുടെ സെർവർ കൂടുതൽ ശേഷിപ്പുകൾ ചേർത്ത് വികസിപ്പിക്കാൻ ശ്രമിക്കുക. ഉദാഹരണത്തിന് API വിളിക്കുന്ന ഒരു ടൂൾ ചേർക്കാൻ [ഈ പേജ്](https://api.chucknorris.io/) കാണുക, സെർവർ എങ്ങനെയിരിക്കണം എന്ന് നിങ്ങൾ തീരുമാനിക്കുക. സന്തോഷത്തോടെ പരീക്ഷിക്കുക :)

## പരിഹാരം

[പരിഹാരം](./solution/README.md) പ്രവർത്തിക്കുന്ന കോഡോടെ ഒരു സാധ്യതാപരമായ പരിഹാരമാണ് ഇത്.

## പ്രധാന takeaway-കൾ

ഈ അധ്യായത്തിൽ നിന്നുള്ള പ്രധാന takeaway-കൾ:

- SSE stdio-വിന് ശേഷം രണ്ടാമത്തെ പിന്തുണയുള്ള ട്രാൻസ്പോർട്ടാണ്.
- SSE പിന്തുണയ്ക്കാൻ, വെബ് ഫ്രെയിംവർക്ക് ഉപയോഗിച്ച് കണക്ഷനുകളും സന്ദേശങ്ങളും കൈകാര്യം ചെയ്യണം.
- Inspector-ഉം Visual Studio Code-ഉം SSE സെർവർ ഉപയോഗിക്കാൻ കഴിയും, stdio സെർവറുകളുപോലെ. stdio-യുമായുള്ള വ്യത്യാസം ശ്രദ്ധിക്കുക: SSE-യിൽ സെർവർ സ്വതന്ത്രമായി ആരംഭിക്കണം, ശേഷം Inspector ടൂൾ പ്രവർത്തിപ്പിക്കണം. Inspector-ൽ URL നിർദ്ദിഷ്ടമാക്കേണ്ടതും വേർതിരിവ് ഉണ്ട്.

## സാമ്പിൾസ്

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## അധിക റിസോഴ്സുകൾ

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## അടുത്തത്

- അടുത്തത്: [HTTP Streaming with MCP (Streamable HTTP)](/03-GettingStarted/06-http-streaming/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.