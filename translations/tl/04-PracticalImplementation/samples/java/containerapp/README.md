<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e5ea5e7582f70008ea9bec3b3820f20a",
  "translation_date": "2025-05-17T14:30:00+00:00",
  "source_file": "04-PracticalImplementation/samples/java/containerapp/README.md",
  "language_code": "tl"
}
-->
## Arkitektura ng Sistema

Ipinapakita ng proyektong ito ang isang web application na gumagamit ng pagsusuri sa kaligtasan ng nilalaman bago ipasa ang mga user prompt sa isang calculator service sa pamamagitan ng Model Context Protocol (MCP).

### Paano Ito Gumagana

1. **Pag-input ng User**: Ang user ay naglalagay ng calculation prompt sa web interface
2. **Pag-susuri sa Kaligtasan ng Nilalaman (Input)**: Sinusuri ang prompt ng Azure Content Safety API
3. **Desisyon sa Kaligtasan (Input)**:
   - Kung ligtas ang nilalaman (severity < 2 sa lahat ng kategorya), ito ay magpapatuloy sa calculator
   - Kung ang nilalaman ay may potensyal na mapanganib, ititigil ang proseso at magbibigay ng babala
4. **Pagsasama ng Calculator**: Ang ligtas na nilalaman ay pinoproseso ng LangChain4j, na nakikipag-ugnayan sa MCP calculator server
5. **Pag-susuri sa Kaligtasan ng Nilalaman (Output)**: Sinusuri ng Azure Content Safety API ang tugon ng bot
6. **Desisyon sa Kaligtasan (Output)**:
   - Kung ligtas ang tugon ng bot, ito ay ipapakita sa user
   - Kung ang tugon ng bot ay may potensyal na mapanganib, ito ay papalitan ng babala
7. **Tugon**: Ang mga resulta (kung ligtas) ay ipapakita sa user kasama ang parehong pagsusuri sa kaligtasan

## Paggamit ng Model Context Protocol (MCP) sa Mga Serbisyo ng Calculator

Ipinapakita ng proyektong ito kung paano gamitin ang Model Context Protocol (MCP) upang tawagan ang mga calculator MCP services mula sa LangChain4j. Ang implementasyon ay gumagamit ng lokal na MCP server na tumatakbo sa port 8080 upang magbigay ng mga operasyon ng calculator.

### Pag-set up ng Azure Content Safety Service

Bago gamitin ang mga tampok sa kaligtasan ng nilalaman, kailangan mong lumikha ng isang Azure Content Safety service resource:

1. Mag-sign in sa [Azure Portal](https://portal.azure.com)
2. I-click ang "Create a resource" at hanapin ang "Content Safety"
3. Piliin ang "Content Safety" at i-click ang "Create"
4. Maglagay ng natatanging pangalan para sa iyong resource
5. Piliin ang iyong subscription at resource group (o lumikha ng bago)
6. Pumili ng suportadong rehiyon (tingnan ang [Region availability](https://azure.microsoft.com/en-us/global-infrastructure/services/?products=cognitive-services) para sa mga detalye)
7. Piliin ang naaangkop na pricing tier
8. I-click ang "Create" upang i-deploy ang resource
9. Kapag kumpleto na ang deployment, i-click ang "Go to resource"
10. Sa kaliwang pane, sa ilalim ng "Resource Management", piliin ang "Keys and Endpoint"
11. Kopyahin ang alinman sa mga key at ang endpoint URL para gamitin sa susunod na hakbang

### Pag-configure ng Environment Variables

Itakda ang `GITHUB_TOKEN` environment variable para sa GitHub models authentication:
```sh
export GITHUB_TOKEN=<your_github_token>
```

Para sa mga tampok sa kaligtasan ng nilalaman, itakda:
```sh
export CONTENT_SAFETY_ENDPOINT=<your_content_safety_endpoint>
export CONTENT_SAFETY_KEY=<your_content_safety_key>
```

Ang mga environment variable na ito ay ginagamit ng application upang mag-authenticate sa Azure Content Safety service. Kung ang mga variable na ito ay hindi nakatakda, gagamit ang application ng placeholder values para sa mga layunin ng pagpapakita, ngunit ang mga tampok sa kaligtasan ng nilalaman ay hindi gagana ng maayos.

### Pag-simula ng Calculator MCP Server

Bago patakbuhin ang client, kailangan mong simulan ang calculator MCP server sa SSE mode sa localhost:8080.

## Paglalarawan ng Proyekto

Ipinapakita ng proyektong ito ang pagsasama ng Model Context Protocol (MCP) sa LangChain4j upang tawagan ang mga serbisyo ng calculator. Ang mga pangunahing tampok ay kinabibilangan ng:

- Paggamit ng MCP upang kumonekta sa isang calculator service para sa mga pangunahing operasyon ng matematika
- Dalawang-layer na pagsusuri sa kaligtasan ng nilalaman sa parehong user prompts at bot responses
- Pagsasama sa gpt-4.1-nano model ng GitHub sa pamamagitan ng LangChain4j
- Paggamit ng Server-Sent Events (SSE) para sa MCP transport

## Pagsasama ng Kaligtasan ng Nilalaman

Kasama sa proyekto ang komprehensibong mga tampok sa kaligtasan ng nilalaman upang matiyak na ang parehong mga input ng user at mga tugon ng sistema ay walang mapanganib na nilalaman:

1. **Pag-susuri ng Input**: Ang lahat ng user prompts ay sinusuri para sa mga kategorya ng mapanganib na nilalaman tulad ng hate speech, karahasan, self-harm, at sexual content bago iproseso.

2. **Pag-susuri ng Output**: Kahit na gumagamit ng mga potensyal na hindi na-censor na modelo, sinusuri ng sistema ang lahat ng mga nabuong tugon sa pamamagitan ng parehong mga filter ng kaligtasan ng nilalaman bago ipakita sa user.

Ang dalawang-layer na pamamaraan na ito ay nagsisiguro na ang sistema ay nananatiling ligtas anuman ang AI model na ginagamit, pinoprotektahan ang mga user mula sa parehong mapanganib na input at potensyal na problema na mga output na nabuong AI.

## Web Client

Kasama sa application ang isang user-friendly na web interface na nagpapahintulot sa mga user na makipag-ugnayan sa Content Safety Calculator system:

### Mga Tampok ng Web Interface

- Simple, madaling gamitin na form para sa pagpasok ng calculation prompts
- Dalawang-layer na pagsusuri sa kaligtasan ng nilalaman (input at output)
- Real-time na feedback sa kaligtasan ng prompt at tugon
- Mga color-coded na tagapagpahiwatig ng kaligtasan para sa madaling interpretasyon
- Malinis, tumutugon na disenyo na gumagana sa iba't ibang mga aparato
- Mga halimbawa ng ligtas na prompt upang gabayan ang mga user

### Paggamit ng Web Client

1. Simulan ang application:
   ```sh
   mvn spring-boot:run
   ```

2. Buksan ang iyong browser at pumunta sa `http://localhost:8087`

3. Maglagay ng calculation prompt sa ibinigay na text area (hal., "Calculate the sum of 24.5 and 17.3")

4. I-click ang "Submit" upang iproseso ang iyong kahilingan

5. Tingnan ang mga resulta, na maglalaman ng:
   - Pagsusuri sa kaligtasan ng nilalaman ng iyong prompt
   - Ang na-calculate na resulta (kung ligtas ang prompt)
   - Pagsusuri sa kaligtasan ng nilalaman ng tugon ng bot
   - Anumang babala sa kaligtasan kung alinman ang input o output ay may flag

Ang web client ay awtomatikong humahawak sa parehong mga proseso ng pag-verify ng kaligtasan ng nilalaman, na tinitiyak na ang lahat ng mga pakikipag-ugnayan ay ligtas at naaangkop anuman ang AI model na ginagamit.

**Paunawa**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Habang sinisikap naming maging tumpak, mangyaring tandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi tumpak na impormasyon. Ang orihinal na dokumento sa kanyang katutubong wika ay dapat ituring na mapagkakatiwalaang sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot para sa anumang hindi pagkakaintindihan o maling interpretasyon na dulot ng paggamit ng pagsasaling ito.