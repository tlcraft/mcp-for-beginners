<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a05fb941810e539147fec53aaadbb6fd",
  "translation_date": "2025-07-14T06:42:49+00:00",
  "source_file": "09-CaseStudy/docs-mcp/solution/python/README.md",
  "language_code": "tl"
}
-->
# Study Plan Generator gamit ang Chainlit at Microsoft Learn Docs MCP

## Mga Kinakailangan

- Python 3.8 pataas
- pip (Python package manager)
- Internet para makakonekta sa Microsoft Learn Docs MCP server

## Pag-install

1. I-clone ang repository na ito o i-download ang mga file ng proyekto.
2. I-install ang mga kinakailangang dependencies:

   ```bash
   pip install -r requirements.txt
   ```

## Paggamit

### Scenario 1: Simpleng Query sa Docs MCP
Isang command-line client na kumokonekta sa Docs MCP server, nagpapadala ng query, at ipinapakita ang resulta.

1. Patakbuhin ang script:
   ```bash
   python scenario1.py
   ```
2. I-type ang iyong tanong tungkol sa dokumentasyon sa prompt.

### Scenario 2: Study Plan Generator (Chainlit Web App)
Isang web-based na interface (gamit ang Chainlit) na nagpapahintulot sa mga user na gumawa ng personalized, linggo-linggong study plan para sa anumang teknikal na paksa.

1. Simulan ang Chainlit app:
   ```bash
   chainlit run scenario2.py
   ```
2. Buksan ang lokal na URL na ipinakita sa iyong terminal (halimbawa, http://localhost:8000) sa iyong browser.
3. Sa chat window, ilagay ang iyong paksa sa pag-aaral at ang bilang ng linggo na nais mong mag-aral (halimbawa, "AI-900 certification, 8 weeks").
4. Sasagutin ka ng app ng isang linggo-linggong study plan, kasama ang mga link sa kaugnay na Microsoft Learn documentation.

**Mga Kinakailangang Environment Variables:**

Para magamit ang Scenario 2 (ang Chainlit web app na may Azure OpenAI), kailangan mong itakda ang mga sumusunod na environment variables sa isang `.env` file sa `python` directory:

```
AZURE_OPENAI_CHAT_DEPLOYMENT_NAME=
AZURE_OPENAI_API_KEY=
AZURE_OPENAI_ENDPOINT=
AZURE_OPENAI_API_VERSION=
```

Punan ang mga ito gamit ang detalye ng iyong Azure OpenAI resource bago patakbuhin ang app.

> **Tip:** Madali kang makakapag-deploy ng sarili mong mga modelo gamit ang [Azure AI Foundry](https://ai.azure.com/).

### Scenario 3: In-Editor Docs gamit ang MCP Server sa VS Code

Sa halip na magpalipat-lipat ng browser tabs para maghanap ng dokumentasyon, maaari mong dalhin ang Microsoft Learn Docs diretso sa iyong VS Code gamit ang MCP server. Pinapahintulutan ka nitong:
- Maghanap at magbasa ng docs sa loob ng VS Code nang hindi umaalis sa iyong coding environment.
- Mag-refer ng dokumentasyon at maglagay ng mga link diretso sa iyong README o mga course files.
- Gamitin ang GitHub Copilot at MCP nang sabay para sa isang seamless, AI-powered na workflow sa dokumentasyon.

**Mga Halimbawa ng Paggamit:**
- Mabilis na magdagdag ng reference links sa README habang nagsusulat ng course o project documentation.
- Gamitin ang Copilot para gumawa ng code at MCP para agad na maghanap at mag-cite ng kaugnay na docs.
- Manatiling nakatutok sa iyong editor at pataasin ang produktibidad.

> [!IMPORTANT]
> Siguraduhing may valid kang [`mcp.json`](../../../../../../09-CaseStudy/docs-mcp/solution/scenario3/mcp.json) configuration sa iyong workspace (ang lokasyon ay `.vscode/mcp.json`).

## Bakit Chainlit para sa Scenario 2?

Ang Chainlit ay isang modernong open-source framework para sa paggawa ng conversational web applications. Pinapadali nito ang paglikha ng chat-based na user interfaces na kumokonekta sa mga backend services tulad ng Microsoft Learn Docs MCP server. Ginagamit ng proyektong ito ang Chainlit para magbigay ng simple at interactive na paraan upang makagawa ng personalized study plans nang real time. Sa tulong ng Chainlit, mabilis kang makakagawa at makakapag-deploy ng mga chat-based na tools na nagpapahusay ng produktibidad at pagkatuto.

## Ano ang Ginagawa Nito

Pinapahintulutan ng app na ito ang mga user na gumawa ng personalized study plan sa pamamagitan lang ng paglagay ng paksa at tagal ng pag-aaral. Ina-parse ng app ang iyong input, nagse-send ng query sa Microsoft Learn Docs MCP server para sa kaugnay na nilalaman, at inaayos ang mga resulta sa isang nakaayos na linggo-linggong plano. Ipinapakita ang mga rekomendasyon bawat linggo sa chat, kaya madali itong sundan at subaybayan ang progreso. Tinitiyak ng integration na palagi kang makakakuha ng pinakabagong at pinaka-angkop na mga learning resources.

## Mga Halimbawang Query

Subukan ang mga query na ito sa chat window para makita kung paano sumasagot ang app:

- `AI-900 certification, 8 weeks`
- `Learn Azure Functions, 4 weeks`
- `Azure DevOps, 6 weeks`
- `Data engineering on Azure, 10 weeks`
- `Microsoft security fundamentals, 5 weeks`
- `Power Platform, 7 weeks`
- `Azure AI services, 12 weeks`
- `Cloud architecture, 9 weeks`

Ipinapakita ng mga halimbawang ito ang kakayahan ng app para sa iba't ibang layunin at tagal ng pag-aaral.

## Mga Sanggunian

- [Chainlit Documentation](https://docs.chainlit.io/)
- [MCP Documentation](https://github.com/MicrosoftDocs/mcp)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.