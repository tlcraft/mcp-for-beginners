<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:34:18+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "pa"
}
-->
# Visual Studio Code ਲਈ AI Toolkit ਐਕਸਟੈਂਸ਼ਨ ਤੋਂ ਸਰਵਰ ਦੀ ਵਰਤੋਂ ਕਰਨਾ

ਜਦੋਂ ਤੁਸੀਂ ਇੱਕ AI ਏਜੰਟ ਬਣਾਉਂਦੇ ਹੋ, ਤਾਂ ਸਿਰਫ਼ ਸਮਝਦਾਰ ਜਵਾਬ ਬਣਾਉਣਾ ਹੀ ਨਹੀਂ, ਬਲਕਿ ਆਪਣੇ ਏਜੰਟ ਨੂੰ ਕਾਰਵਾਈ ਕਰਨ ਦੀ ਸਮਰੱਥਾ ਦੇਣਾ ਵੀ ਜ਼ਰੂਰੀ ਹੁੰਦਾ ਹੈ। ਇੱਥੇ Model Context Protocol (MCP) ਕੰਮ ਵਿੱਚ ਆਉਂਦਾ ਹੈ। MCP ਏਜੰਟਾਂ ਨੂੰ ਬਾਹਰੀ ਟੂਲ ਅਤੇ ਸਰਵਿਸਿਜ਼ ਤੱਕ ਇੱਕਸਾਰ ਢੰਗ ਨਾਲ ਪਹੁੰਚਣ ਦੇਣ ਵਿੱਚ ਸਹਾਇਤਾ ਕਰਦਾ ਹੈ। ਇਸਨੂੰ ਇਸ ਤਰ੍ਹਾਂ ਸੋਚੋ ਜਿਵੇਂ ਤੁਸੀਂ ਆਪਣੇ ਏਜੰਟ ਨੂੰ ਇੱਕ ਐਸੇ ਟੂਲਬਾਕਸ ਨਾਲ ਜੋੜ ਰਹੇ ਹੋ ਜੋ ਉਹ ਅਸਲ ਵਿੱਚ ਵਰਤ ਸਕਦਾ ਹੈ।

ਮਿਸਾਲ ਵਜੋਂ, ਜੇ ਤੁਸੀਂ ਆਪਣੇ ਏਜੰਟ ਨੂੰ ਕੈਲਕੁਲੇਟਰ MCP ਸਰਵਰ ਨਾਲ ਜੋੜਦੇ ਹੋ, ਤਾਂ ਤੁਹਾਡਾ ਏਜੰਟ ਸਿੱਧਾ "47 ਗੁਣਾ 89 ਕਿੰਨਾ ਹੁੰਦਾ ਹੈ?" ਵਰਗਾ ਪ੍ਰਾਂਪਟ ਮਿਲਣ ਤੇ ਗਣਿਤ ਦੇ ਅੰਕੜੇ ਹਿਸਾਬ ਕਰ ਸਕਦਾ ਹੈ—ਬਿਨਾਂ ਲੋਜਿਕ ਹਾਰਡਕੋਡ ਕਰਨ ਜਾਂ ਕਸਟਮ API ਬਣਾਉਣ ਦੀ ਲੋੜ।

## ਝਲਕ

ਇਸ ਪਾਠ ਵਿੱਚ ਦੱਸਿਆ ਗਿਆ ਹੈ ਕਿ ਕਿਵੇਂ Visual Studio Code ਵਿੱਚ [AI Toolkit](https://aka.ms/AIToolkit) ਐਕਸਟੈਂਸ਼ਨ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਇੱਕ ਕੈਲਕੁਲੇਟਰ MCP ਸਰਵਰ ਨੂੰ ਏਜੰਟ ਨਾਲ ਜੋੜਿਆ ਜਾਵੇ, ਤਾਂ ਜੋ ਤੁਹਾਡਾ ਏਜੰਟ ਕੁਦਰਤੀ ਭਾਸ਼ਾ ਰਾਹੀਂ ਜੋੜ, ਘਟਾਓ, ਗੁਣਾ ਅਤੇ ਭਾਗ ਕਰਨ ਵਰਗੇ ਗਣਿਤ ਦੇ ਕੰਮ ਕਰ ਸਕੇ।

AI Toolkit Visual Studio Code ਲਈ ਇੱਕ ਸ਼ਕਤੀਸ਼ਾਲੀ ਐਕਸਟੈਂਸ਼ਨ ਹੈ ਜੋ ਏਜੰਟ ਵਿਕਾਸ ਨੂੰ ਆਸਾਨ ਬਣਾਉਂਦਾ ਹੈ। AI ਇੰਜੀਨੀਅਰ ਸਥਾਨਕ ਜਾਂ ਕਲਾਉਡ ਵਿੱਚ ਜਨਰੇਟਿਵ AI ਮਾਡਲਾਂ ਨੂੰ ਵਿਕਸਤ ਅਤੇ ਟੈਸਟ ਕਰਕੇ ਆਸਾਨੀ ਨਾਲ AI ਐਪਲੀਕੇਸ਼ਨ ਬਣਾ ਸਕਦੇ ਹਨ। ਇਹ ਐਕਸਟੈਂਸ਼ਨ ਅੱਜ ਮੌਜੂਦ ਜ਼ਿਆਦਾਤਰ ਪ੍ਰਮੁੱਖ ਜਨਰੇਟਿਵ ਮਾਡਲਾਂ ਨੂੰ ਸਹਿਯੋਗ ਦਿੰਦਾ ਹੈ।

*ਨੋਟ*: AI Toolkit ਇਸ ਸਮੇਂ Python ਅਤੇ TypeScript ਨੂੰ ਸਹਿਯੋਗ ਦਿੰਦਾ ਹੈ।

## ਸਿੱਖਣ ਦੇ ਮਕਸਦ

ਇਸ ਪਾਠ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਸਮਰੱਥ ਹੋਵੋਗੇ:

- AI Toolkit ਰਾਹੀਂ MCP ਸਰਵਰ ਦੀ ਵਰਤੋਂ ਕਰਨਾ।
- ਏਜੰਟ ਸੰਰਚਨਾ ਨੂੰ ਇਸ ਤਰ੍ਹਾਂ ਕਨਫਿਗਰ ਕਰਨਾ ਕਿ ਉਹ MCP ਸਰਵਰ ਵੱਲੋਂ ਦਿੱਤੇ ਟੂਲਾਂ ਨੂੰ ਲੱਭ ਅਤੇ ਵਰਤ ਸਕੇ।
- ਕੁਦਰਤੀ ਭਾਸ਼ਾ ਰਾਹੀਂ MCP ਟੂਲਾਂ ਦੀ ਵਰਤੋਂ ਕਰਨਾ।

## ਤਰੀਕਾ

ਉੱਚ ਸਤਰ 'ਤੇ ਅਸੀਂ ਇਸ ਤਰ੍ਹਾਂ ਅੱਗੇ ਵਧਾਂਗੇ:

- ਇੱਕ ਏਜੰਟ ਬਣਾਓ ਅਤੇ ਉਸਦਾ ਸਿਸਟਮ ਪ੍ਰਾਂਪਟ ਪਰਿਭਾਸ਼ਿਤ ਕਰੋ।
- ਕੈਲਕੁਲੇਟਰ ਟੂਲਾਂ ਨਾਲ MCP ਸਰਵਰ ਬਣਾਓ।
- Agent Builder ਨੂੰ MCP ਸਰਵਰ ਨਾਲ ਜੋੜੋ।
- ਕੁਦਰਤੀ ਭਾਸ਼ਾ ਰਾਹੀਂ ਏਜੰਟ ਦੇ ਟੂਲ ਕਾਲ ਦੀ ਜਾਂਚ ਕਰੋ।

ਵਧੀਆ, ਹੁਣ ਜਦੋਂ ਅਸੀਂ ਪ੍ਰਕਿਰਿਆ ਸਮਝ ਗਏ ਹਾਂ, ਆਓ MCP ਰਾਹੀਂ ਬਾਹਰੀ ਟੂਲਾਂ ਦਾ ਫਾਇਦਾ ਲੈਣ ਲਈ ਇੱਕ AI ਏਜੰਟ ਨੂੰ ਕਨਫਿਗਰ ਕਰੀਏ, ਜਿਸ ਨਾਲ ਇਸ ਦੀ ਸਮਰੱਥਾ ਵਧੇਗੀ!

## ਲੋੜੀਂਦੇ ਸਾਧਨ

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## ਅਭਿਆਸ: ਸਰਵਰ ਦੀ ਵਰਤੋਂ

ਇਸ ਅਭਿਆਸ ਵਿੱਚ, ਤੁਸੀਂ Visual Studio Code ਵਿੱਚ AI Toolkit ਦੀ ਵਰਤੋਂ ਕਰਕੇ MCP ਸਰਵਰ ਤੋਂ ਟੂਲਾਂ ਨਾਲ ਇੱਕ AI ਏਜੰਟ ਬਣਾਉਣ, ਚਲਾਉਣ ਅਤੇ ਸੁਧਾਰ ਕਰਨਗੇ।

### -0- ਪਹਿਲਾ ਕਦਮ, OpenAI GPT-4o ਮਾਡਲ ਨੂੰ My Models ਵਿੱਚ ਸ਼ਾਮਿਲ ਕਰੋ

ਅਭਿਆਸ ਵਿੱਚ **GPT-4o** ਮਾਡਲ ਦੀ ਵਰਤੋਂ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਏਜੰਟ ਬਣਾਉਣ ਤੋਂ ਪਹਿਲਾਂ ਇਸ ਮਾਡਲ ਨੂੰ **My Models** ਵਿੱਚ ਸ਼ਾਮਿਲ ਕਰਨਾ ਜਰੂਰੀ ਹੈ।

![Visual Studio Code ਦੇ AI Toolkit ਐਕਸਟੈਂਸ਼ਨ ਵਿੱਚ ਮਾਡਲ ਚੋਣ ਇੰਟਰਫੇਸ ਦਾ ਸਕ੍ਰੀਨਸ਼ਾਟ। ਸਿਰਲੇਖ "Find the right model for your AI Solution" ਹੈ, ਜਿਸਦੇ ਹੇਠਾਂ ਉਪਸਿਰਲੇਖ ਹੈ ਜੋ ਉਪਭੋਗਤਾਵਾਂ ਨੂੰ AI ਮਾਡਲ ਲੱਭਣ, ਟੈਸਟ ਕਰਨ ਅਤੇ ਡਿਪਲੋਇ ਕਰਨ ਲਈ ਪ੍ਰੇਰਿਤ ਕਰਦਾ ਹੈ। "Popular Models" ਹਿੱਸੇ ਵਿੱਚ ਛੇ ਮਾਡਲ ਕਾਰਡ ਹਨ: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), ਅਤੇ DeepSeek-R1 (Ollama-hosted)। ਹਰ ਕਾਰਡ 'ਤੇ "Add" ਅਤੇ "Try in Playground" ਦੇ ਵਿਕਲਪ ਹਨ।](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.pa.png)

1. **Activity Bar** ਤੋਂ **AI Toolkit** ਐਕਸਟੈਂਸ਼ਨ ਖੋਲ੍ਹੋ।
1. **Catalog** ਸੈਕਸ਼ਨ ਵਿੱਚ **Models** ਚੁਣੋ, ਜਿਸ ਨਾਲ **Model Catalog** ਨਵੇਂ ਐਡੀਟਰ ਟੈਬ ਵਿੱਚ ਖੁਲ ਜਾਵੇਗਾ।
1. **Model Catalog** ਦੀ ਖੋਜ ਪੱਟੀ ਵਿੱਚ **OpenAI GPT-4o** ਲਿਖੋ।
1. **+ Add** 'ਤੇ ਕਲਿੱਕ ਕਰਕੇ ਮਾਡਲ ਨੂੰ **My Models** ਸੂਚੀ ਵਿੱਚ ਸ਼ਾਮਿਲ ਕਰੋ। ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਤੁਸੀਂ ਉਹ ਮਾਡਲ ਚੁਣਿਆ ਹੈ ਜੋ **GitHub ਦੁਆਰਾ ਹੋਸਟ ਕੀਤਾ ਗਿਆ ਹੈ**।
1. **Activity Bar** ਵਿੱਚ ਯਕੀਨ ਕਰੋ ਕਿ **OpenAI GPT-4o** ਮਾਡਲ ਸੂਚੀ ਵਿੱਚ ਦਿਖਾਈ ਦੇ ਰਿਹਾ ਹੈ।

### -1- ਏਜੰਟ ਬਣਾਓ

**Agent (Prompt) Builder** ਤੁਹਾਨੂੰ ਆਪਣੇ AI-ਚਲਿਤ ਏਜੰਟ ਬਣਾਉਣ ਅਤੇ ਕਸਟਮਾਈਜ਼ ਕਰਨ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ। ਇਸ ਹਿੱਸੇ ਵਿੱਚ, ਤੁਸੀਂ ਇੱਕ ਨਵਾਂ ਏਜੰਟ ਬਣਾਉਂਦੇ ਹੋ ਅਤੇ ਗੱਲਬਾਤ ਚਲਾਉਣ ਲਈ ਮਾਡਲ ਨਿਰਧਾਰਿਤ ਕਰਦੇ ਹੋ।

![AI Toolkit ਐਕਸਟੈਂਸ਼ਨ ਵਿੱਚ "Calculator Agent" ਬਿਲਡਰ ਇੰਟਰਫੇਸ ਦਾ ਸਕ੍ਰੀਨਸ਼ਾਟ। ਖੱਬੇ ਪੈਨਲ ਵਿੱਚ ਮਾਡਲ "OpenAI GPT-4o (via GitHub)" ਚੁਣਿਆ ਗਿਆ ਹੈ। ਸਿਸਟਮ ਪ੍ਰਾਂਪਟ "ਤੁਸੀਂ ਯੂਨੀਵਰਸਿਟੀ ਵਿੱਚ ਗਣਿਤ ਪੜ੍ਹਾਉਣ ਵਾਲੇ ਪ੍ਰੋਫੈਸਰ ਹੋ" ਦੱਸਦਾ ਹੈ, ਅਤੇ ਯੂਜ਼ਰ ਪ੍ਰਾਂਪਟ "ਮੈਨੂੰ ਸਧਾਰਣ ਸ਼ਬਦਾਂ ਵਿੱਚ Fourier ਸਮੀਕਰਨ ਸਮਝਾਓ" ਹੈ। ਹੋਰ ਵਿਕਲਪਾਂ ਵਿੱਚ ਟੂਲ ਸ਼ਾਮਿਲ ਕਰਨ, MCP ਸਰਵਰ ਚਾਲੂ ਕਰਨ ਅਤੇ ਸਟ੍ਰਕਚਰਡ ਆਉਟਪੁੱਟ ਚੁਣਨ ਦੇ ਬਟਨ ਹਨ। ਹੇਠਾਂ ਨੀਲੇ ਰੰਗ ਦਾ "Run" ਬਟਨ ਹੈ। ਸੱਜੇ ਪੈਨਲ ਵਿੱਚ "Get Started with Examples" ਹੇਠਾਂ ਤਿੰਨ ਨਮੂਨਾ ਏਜੰਟਾਂ ਦੀ ਸੂਚੀ ਹੈ।](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.pa.png)

1. **Activity Bar** ਤੋਂ **AI Toolkit** ਐਕਸਟੈਂਸ਼ਨ ਖੋਲ੍ਹੋ।
1. **Tools** ਸੈਕਸ਼ਨ ਵਿੱਚ **Agent (Prompt) Builder** ਚੁਣੋ, ਜੋ ਨਵੇਂ ਐਡੀਟਰ ਟੈਬ ਵਿੱਚ ਖੁਲ ਜਾਵੇਗਾ।
1. **+ New Agent** ਬਟਨ 'ਤੇ ਕਲਿੱਕ ਕਰੋ। ਇਹ ਕਮਾਂਡ ਪੈਲੇਟ ਰਾਹੀਂ ਸੈਟਅੱਪ ਵਿਜ਼ਾਰਡ ਖੋਲ੍ਹੇਗਾ।
1. ਨਾਮ ਵਜੋਂ **Calculator Agent** ਦਰਜ ਕਰੋ ਅਤੇ **Enter** ਦਬਾਓ।
1. **Agent (Prompt) Builder** ਵਿੱਚ **Model** ਖੇਤਰ ਲਈ **OpenAI GPT-4o (via GitHub)** ਮਾਡਲ ਚੁਣੋ।

### -2- ਏਜੰਟ ਲਈ ਸਿਸਟਮ ਪ੍ਰਾਂਪਟ ਬਣਾਓ

ਏਜੰਟ ਤਿਆਰ ਹੋਣ ਤੋਂ ਬਾਅਦ, ਹੁਣ ਇਸ ਦੀ ਸ਼ਖਸੀਅਤ ਅਤੇ ਮਕਸਦ ਪਰਿਭਾਸ਼ਿਤ ਕਰਨ ਦਾ ਸਮਾਂ ਹੈ। ਇਸ ਹਿੱਸੇ ਵਿੱਚ, ਤੁਸੀਂ **Generate system prompt** ਫੀਚਰ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਏਜੰਟ ਦੇ ਵਰਤਾਰਿਆਂ ਦਾ ਵਰਣਨ ਕਰੋਗੇ—ਇਸ ਮਾਮਲੇ ਵਿੱਚ ਇੱਕ ਕੈਲਕੁਲੇਟਰ ਏਜੰਟ—ਅਤੇ ਮਾਡਲ ਨੂੰ ਸਿਸਟਮ ਪ੍ਰਾਂਪਟ ਲਿਖਵਾਉਂਗੇ।

![AI Toolkit ਵਿੱਚ "Calculator Agent" ਇੰਟਰਫੇਸ ਦਾ ਸਕ੍ਰੀਨਸ਼ਾਟ ਜਿਸ ਵਿੱਚ "Generate a prompt" ਮੋਡਲ ਖੁਲਾ ਹੋਇਆ ਹੈ। ਮੋਡਲ ਵਿੱਚ ਦੱਸਿਆ ਗਿਆ ਹੈ ਕਿ ਬੁਨਿਆਦੀ ਜਾਣਕਾਰੀ ਸਾਂਝੀ ਕਰਕੇ ਪ੍ਰਾਂਪਟ ਟੈਮਪਲੇਟ ਤਿਆਰ ਕੀਤਾ ਜਾ ਸਕਦਾ ਹੈ। ਟੈਕਸਟ ਬਾਕਸ ਵਿੱਚ ਨਮੂਨਾ ਸਿਸਟਮ ਪ੍ਰਾਂਪਟ ਹੈ: "ਤੁਸੀਂ ਇੱਕ ਮਦਦਗਾਰ ਅਤੇ ਪ੍ਰਭਾਵਸ਼ਾਲੀ ਗਣਿਤ ਸਹਾਇਕ ਹੋ। ਜਦੋਂ ਤੁਹਾਨੂੰ ਬੁਨਿਆਦੀ ਅੰਕਗਣਿਤ ਵਾਲਾ ਪ੍ਰਸ਼ਨ ਮਿਲਦਾ ਹੈ, ਤੁਸੀਂ ਸਹੀ ਨਤੀਜਾ ਦਿੰਦੇ ਹੋ।" ਹੇਠਾਂ "Close" ਅਤੇ "Generate" ਬਟਨ ਹਨ।](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.pa.png)

1. **Prompts** ਸੈਕਸ਼ਨ ਵਿੱਚ **Generate system prompt** ਬਟਨ 'ਤੇ ਕਲਿੱਕ ਕਰੋ। ਇਹ ਪ੍ਰਾਂਪਟ ਬਿਲਡਰ ਖੋਲ੍ਹਦਾ ਹੈ ਜੋ AI ਦੀ ਮਦਦ ਨਾਲ ਸਿਸਟਮ ਪ੍ਰਾਂਪਟ ਤਿਆਰ ਕਰਦਾ ਹੈ।
1. **Generate a prompt** ਵਿੰਡੋ ਵਿੱਚ ਹੇਠਾਂ ਦਿੱਤਾ ਗਿਆ ਟੈਕਸਟ ਦਰਜ ਕਰੋ: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. **Generate** ਬਟਨ 'ਤੇ ਕਲਿੱਕ ਕਰੋ। ਨੋਟੀਫਿਕੇਸ਼ਨ ਨੀਵੇਂ-ਸੱਜੇ ਕੋਨੇ ਵਿੱਚ ਆਏਗੀ ਜੋ ਪ੍ਰਾਂਪਟ ਤਿਆਰ ਹੋਣ ਦੀ ਪੁਸ਼ਟੀ ਕਰੇਗੀ। ਜਦੋਂ ਤਿਆਰੀ ਮੁਕੰਮਲ ਹੋ ਜਾਵੇਗੀ, ਪ੍ਰਾਂਪਟ **Agent (Prompt) Builder** ਦੇ **System prompt** ਖੇਤਰ ਵਿੱਚ ਦਿਖਾਈ ਦੇਵੇਗਾ।
1. **System prompt** ਨੂੰ ਸਮੀਖਿਆ ਕਰੋ ਅਤੇ ਜੇ ਲੋੜ ਹੋਵੇ ਤਾਂ ਸੋਧ ਕਰੋ।

### -3- MCP ਸਰਵਰ ਬਣਾਓ

ਹੁਣ ਜਦੋਂ ਤੁਸੀਂ ਆਪਣੇ ਏਜੰਟ ਦਾ ਸਿਸਟਮ ਪ੍ਰਾਂਪਟ ਨਿਰਧਾਰਿਤ ਕਰ ਲਿਆ ਹੈ—ਜੋ ਇਸ ਦੇ ਵਰਤਾਰੇ ਅਤੇ ਜਵਾਬਾਂ ਨੂੰ ਰਾਹਦਾਰੀ ਦਿੰਦਾ ਹੈ—ਤਦ ਇਸਨੂੰ ਪ੍ਰਯੋਗਿਕ ਸਮਰੱਥਾਵਾਂ ਨਾਲ ਸਜਾਉਣ ਦਾ ਸਮਾਂ ਹੈ। ਇਸ ਹਿੱਸੇ ਵਿੱਚ, ਤੁਸੀਂ ਕੈਲਕੁਲੇਟਰ MCP ਸਰਵਰ ਬਣਾਉਗੇ ਜੋ ਜੋੜ, ਘਟਾਓ, ਗੁਣਾ ਅਤੇ ਭਾਗ ਕਰਨ ਵਾਲੇ ਟੂਲਾਂ ਨਾਲ ਲੈਸ ਹੋਵੇਗਾ। ਇਹ ਸਰਵਰ ਤੁਹਾਡੇ ਏਜੰਟ ਨੂੰ ਕੁਦਰਤੀ ਭਾਸ਼ਾ ਪ੍ਰਾਂਪਟਾਂ ਦੇ ਜਵਾਬ ਵਿੱਚ ਤੁਰੰਤ ਗਣਿਤੀ ਕਾਰਵਾਈਆਂ ਕਰਨ ਦੇ ਯੋਗ ਬਣਾਏਗਾ।

![Calculator Agent ਇੰਟਰਫੇਸ ਦੇ ਹੇਠਲੇ ਹਿੱਸੇ ਦਾ ਸਕ੍ਰੀਨਸ਼ਾਟ ਜਿਸ ਵਿੱਚ “Tools” ਅਤੇ “Structure output” ਲਈ ਵਿਸਥਾਰਯੋਗ ਮੀਨੂਜ਼ ਹਨ, ਅਤੇ ਇੱਕ ਡ੍ਰਾਪਡਾਊਨ ਮੀਨੂ ਹੈ ਜੋ "Choose output format" ਲਈ "text" 'ਤੇ ਸੈੱਟ ਹੈ। ਸੱਜੇ ਪਾਸੇ "+ MCP Server" ਬਟਨ ਹੈ ਜੋ Model Context Protocol ਸਰਵਰ ਜੋੜਨ ਲਈ ਹੈ।](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.pa.png)

AI Toolkit ਵਿੱਚ ਆਪਣੇ MCP ਸਰਵਰ ਬਣਾਉਣ ਲਈ ਟੈਮਪਲੇਟ ਹਨ। ਅਸੀਂ ਕੈਲਕੁਲੇਟਰ MCP ਸਰਵਰ ਬਣਾਉਣ ਲਈ Python ਟੈਮਪਲੇਟ ਦੀ ਵਰਤੋਂ ਕਰਾਂਗੇ।

*ਨੋਟ*: AI Toolkit ਇਸ ਸਮੇਂ Python ਅਤੇ TypeScript ਨੂੰ ਸਹਿਯੋਗ ਦਿੰਦਾ ਹੈ।

1. **Agent (Prompt) Builder** ਦੇ **Tools** ਸੈਕਸ਼ਨ ਵਿੱਚ **+ MCP Server** ਬਟਨ 'ਤੇ ਕਲਿੱਕ ਕਰੋ। ਇਹ ਕਮਾਂਡ ਪੈਲੇਟ ਰਾਹੀਂ ਸੈਟਅੱਪ ਵਿਜ਼ਾਰਡ ਖੋਲ੍ਹੇਗਾ।
1. **+ Add Server** ਚੁਣੋ।
1. **Create a New MCP Server** ਚੁਣੋ।
1. **python-weather** ਟੈਮਪਲੇਟ ਚੁਣੋ।
1. MCP ਸਰਵਰ ਟੈਮਪਲੇਟ ਸੇਵ ਕਰਨ ਲਈ **Default folder** ਚੁਣੋ।
1. ਸਰਵਰ ਲਈ ਨਾਮ ਦਰਜ ਕਰੋ: **Calculator**
1. ਇੱਕ ਨਵੀਂ Visual Studio Code ਵਿੰਡੋ ਖੁਲੇਗੀ। **Yes, I trust the authors** ਚੁਣੋ।
1. ਟਰਮੀਨਲ ਵਿੱਚ ਜਾ ਕੇ ਵਰਚੁਅਲ ਇਨਵਾਇਰਨਮੈਂਟ ਬਣਾਓ: `python -m venv .venv`
1. ਵਰਚੁਅਲ ਇਨਵਾਇਰਨਮੈਂਟ ਐਕਟੀਵੇਟ ਕਰੋ:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. ਡਿਪੈਂਡੇੰਸੀਜ਼ ਇੰਸਟਾਲ ਕਰੋ: `pip install -e .[dev]`
1. **Explorer** ਵਿਚ **src** ਡਾਇਰੈਕਟਰੀ ਖੋਲ੍ਹੋ ਅਤੇ **server.py** ਫਾਇਲ ਖੋਲ੍ਹੋ।
1. **server.py** ਦੀ ਕੋਡ ਨੂੰ ਹੇਠਾਂ ਦਿੱਤੇ ਕੋਡ ਨਾਲ ਬਦਲੋ ਅਤੇ ਸੇਵ ਕਰੋ:

    ```python
    """
    Sample MCP Calculator Server implementation in Python.

    
    This module demonstrates how to create a simple MCP server with calculator tools
    that can perform basic arithmetic operations (add, subtract, multiply, divide).
    """
    
    from mcp.server.fastmcp import FastMCP
    
    server = FastMCP("calculator")
    
    @server.tool()
    def add(a: float, b: float) -> float:
        """Add two numbers together and return the result."""
        return a + b
    
    @server.tool()
    def subtract(a: float, b: float) -> float:
        """Subtract b from a and return the result."""
        return a - b
    
    @server.tool()
    def multiply(a: float, b: float) -> float:
        """Multiply two numbers together and return the result."""
        return a * b
    
    @server.tool()
    def divide(a: float, b: float) -> float:
        """
        Divide a by b and return the result.
        
        Raises:
            ValueError: If b is zero
        """
        if b == 0:
            raise ValueError("Cannot divide by zero")
        return a / b
    ```

### -4- ਕੈਲਕੁਲੇਟਰ MCP ਸਰਵਰ ਨਾਲ ਏਜੰਟ ਚਲਾਓ

ਹੁਣ ਜਦੋਂ ਤੁਹਾਡੇ ਏਜੰਟ ਕੋਲ ਟੂਲ ਹਨ, ਤਾਂ ਉਹਨਾਂ ਦੀ ਵਰਤੋਂ ਕਰਨ ਦਾ ਸਮਾਂ ਹੈ! ਇਸ ਹਿੱਸੇ ਵਿੱਚ, ਤੁਸੀਂ ਏਜੰਟ ਨੂੰ ਪ੍ਰਾਂਪਟ ਭੇਜ ਕੇ ਜਾਂਚੋਗੇ ਕਿ ਕੀ ਇਹ ਸਹੀ ਟੂਲਾਂ ਦੀ ਵਰਤੋਂ ਕਰਦਾ ਹੈ ਜਾਂ ਨਹੀਂ।

![Calculator Agent ਇੰਟਰਫੇਸ ਦਾ ਸਕ੍ਰੀਨਸ਼ਾਟ ਜਿਸ ਵਿੱਚ ਖੱਬੇ ਪੈਨਲ ਵਿੱਚ “Tools” ਹੇਠ MCP ਸਰਵਰ local-server-calculator_server ਜੋੜਿਆ ਗਿਆ ਹੈ, ਜਿਸ ਵਿੱਚ add, subtract, multiply ਅਤੇ divide ਟੂਲ ਦਿਖਾਈ ਦੇ ਰਹੇ ਹਨ। ਹੇਠਾਂ "Structure output" ਸੈਕਸ਼ਨ ਸੰਕੁਚਿਤ ਹੈ ਅਤੇ ਨੀਲਾ "Run" ਬਟਨ ਹੈ। ਸੱਜੇ ਪੈਨਲ ਵਿੱਚ "Model Response" ਹੇਠ ਏਜੰਟ multiply ਅਤੇ subtract ਟੂਲਾਂ ਨੂੰ ਕਾਲ ਕਰ ਰਿਹਾ ਹੈ, ਅਤੇ ਆਖਰੀ "Tool Response" 75.0 ਦਿਖਾ ਰਿਹਾ ਹੈ।](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.pa.png)

ਤੁਸੀਂ ਆਪਣੇ ਲੋਕਲ ਡਿਵੈਲਪਮੈਂਟ ਮਸ਼ੀਨ 'ਤੇ Agent Builder ਰਾਹੀਂ ਕੈਲਕੁਲੇਟਰ MCP ਸਰਵਰ ਚਲਾਓਗੇ।

1. `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` ਮੁੱਲ **subtract** ਟੂਲ ਲਈ ਦਿੱਤੇ ਜਾਂਦੇ ਹਨ।
    - ਹਰ ਟੂਲ ਤੋਂ ਪ੍ਰਾਪਤ ਜਵਾਬ **Tool Response** ਵਿੱਚ ਦਿੱਤਾ ਜਾਂਦਾ ਹੈ।
    - ਮਾਡਲ ਤੋਂ ਆਖਰੀ ਨਤੀਜਾ **Model Response** ਵਿੱਚ ਮਿਲਦਾ ਹੈ।
1. ਹੋਰ ਪ੍ਰਾਂਪਟ ਭੇਜ ਕੇ ਏਜੰਟ ਦੀ ਵਧੇਰੇ ਜਾਂਚ ਕਰੋ। ਤੁਸੀਂ **User prompt** ਖੇਤਰ ਵਿੱਚ ਮੌਜੂਦਾ ਪ੍ਰਾਂਪਟ ਨੂੰ ਸੋਧ ਕੇ ਨਵਾਂ ਪ੍ਰਾਂਪਟ ਦੇ ਸਕਦੇ ਹੋ।
1. ਟੈਸਟਿੰਗ ਮੁਕੰਮਲ ਹੋਣ ਤੇ, ਟਰਮੀਨਲ ਵਿੱਚ **CTRL/CMD+C** ਦਬਾ ਕੇ ਸਰਵਰ ਬੰਦ ਕਰੋ।

## ਅਸਾਈਨਮੈਂਟ

ਆਪਣੇ **server.py** ਫਾਇਲ ਵਿੱਚ ਇੱਕ ਹੋਰ ਟੂਲ ਸ਼ਾਮਿਲ ਕਰਨ ਦੀ ਕੋਸ਼ਿਸ਼ ਕਰੋ (ਜਿਵੇਂ ਕਿ ਕਿਸੇ ਨੰਬਰ ਦਾ ਵਰਗਮੂਲ ਵਾਪਸ ਕਰਨਾ)। ਐਸੇ ਪ੍ਰਾਂਪਟ ਭੇਜੋ ਜੋ ਤੁਹਾਡੇ ਨਵੇਂ ਜਾਂ ਮੌਜੂਦਾ ਟੂਲ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਜਵਾਬ ਦੇ ਸਕਣ। ਨਵਾਂ ਟੂਲ ਲੋਡ ਕਰਨ ਲਈ ਸਰਵਰ ਰੀਸਟਾਰਟ ਕਰਨਾ ਯਕੀਨੀ ਬਣਾਓ।

## ਹੱਲ

[Solution](./solution/README.md)

## ਮੁੱਖ ਗੱਲਾਂ

ਇਸ ਅਧਿਆਇ ਤੋਂ ਮੁੱਖ ਸਿੱਖਣ ਵਾਲੀਆਂ ਗੱਲਾਂ ਹਨ:

- AI Toolkit ਐਕਸਟੈਂਸ਼ਨ ਇੱਕ ਵਧੀਆ ਕਲਾਇੰਟ ਹੈ ਜੋ MCP ਸਰਵਰਾਂ ਅਤੇ ਉਨ੍ਹਾਂ ਦੇ ਟੂਲਾਂ ਦੀ ਵਰਤੋਂ ਕਰਨ ਦਿੰਦਾ ਹੈ।
- ਤੁਸੀਂ MCP ਸਰਵਰਾਂ ਵਿੱਚ ਨਵੇਂ ਟੂਲ ਸ਼ਾਮਿਲ ਕਰਕੇ ਏਜੰ

**ਅਸਵੀਕਾਰੋक्ति**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਆਟੋਮੈਟਿਕ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਣਸਹੀਤੀਆਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਹੀ ਅਧਿਕਾਰਤ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਜ਼ਰੂਰੀ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਨਾਲ ਪੈਦਾ ਹੋਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀਆਂ ਜਾਂ ਭ੍ਰਮਾਂ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।