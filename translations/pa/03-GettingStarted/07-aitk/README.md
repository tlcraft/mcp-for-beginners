<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-04T16:52:29+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "pa"
}
-->
# Visual Studio Code ਲਈ AI Toolkit ਐਕਸਟੈਂਸ਼ਨ ਤੋਂ ਸਰਵਰ ਦੀ ਵਰਤੋਂ ਕਰਨਾ

ਜਦੋਂ ਤੁਸੀਂ ਇੱਕ AI ਏਜੰਟ ਬਣਾਉਂਦੇ ਹੋ, ਤਾਂ ਸਿਰਫ਼ ਸਮਝਦਾਰ ਜਵਾਬ ਬਣਾਉਣਾ ਹੀ ਨਹੀਂ, ਬਲਕਿ ਆਪਣੇ ਏਜੰਟ ਨੂੰ ਕਾਰਵਾਈ ਕਰਨ ਦੀ ਸਮਰੱਥਾ ਦੇਣਾ ਵੀ ਜਰੂਰੀ ਹੁੰਦਾ ਹੈ। ਇੱਥੇ Model Context Protocol (MCP) ਕੰਮ ਵਿੱਚ ਆਉਂਦਾ ਹੈ। MCP ਏਜੰਟਾਂ ਨੂੰ ਬਾਹਰੀ ਟੂਲਾਂ ਅਤੇ ਸੇਵਾਵਾਂ ਤੱਕ ਇੱਕ ਸਥਿਰ ਢੰਗ ਨਾਲ ਪਹੁੰਚ ਦੇਣਾ ਆਸਾਨ ਬਣਾਉਂਦਾ ਹੈ। ਇਸਨੂੰ ਇਸ ਤਰ੍ਹਾਂ ਸੋਚੋ ਜਿਵੇਂ ਤੁਸੀਂ ਆਪਣੇ ਏਜੰਟ ਨੂੰ ਇੱਕ ਐਸੇ ਟੂਲਬਾਕਸ ਨਾਲ ਜੋੜ ਰਹੇ ਹੋ ਜੋ ਉਹ *ਅਸਲ ਵਿੱਚ* ਵਰਤ ਸਕਦਾ ਹੈ।

ਮਾਨ ਲਓ ਤੁਸੀਂ ਆਪਣੇ ਏਜੰਟ ਨੂੰ ਕੈਲਕੂਲੇਟਰ MCP ਸਰਵਰ ਨਾਲ ਜੋੜਦੇ ਹੋ। ਅਚਾਨਕ, ਤੁਹਾਡਾ ਏਜੰਟ ਸਿਰਫ਼ ਇਹ ਪ੍ਰਾਂਪਟ ਮਿਲਣ ‘ਤੇ “47 ਗੁਣਾ 89 ਕਿੰਨਾ ਹੁੰਦਾ ਹੈ?” ਵਰਗੀਆਂ ਗਣਿਤੀ ਕਾਰਵਾਈਆਂ ਕਰ ਸਕਦਾ ਹੈ—ਕੋਈ ਲਾਜਿਕ ਹਾਰਡਕੋਡ ਕਰਨ ਜਾਂ ਕਸਟਮ API ਬਣਾਉਣ ਦੀ ਲੋੜ ਨਹੀਂ।

## ਝਲਕ

ਇਸ ਪਾਠ ਵਿੱਚ ਦੱਸਿਆ ਗਿਆ ਹੈ ਕਿ ਕਿਵੇਂ Visual Studio Code ਵਿੱਚ [AI Toolkit](https://aka.ms/AIToolkit) ਐਕਸਟੈਂਸ਼ਨ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਇੱਕ ਕੈਲਕੂਲੇਟਰ MCP ਸਰਵਰ ਨੂੰ ਏਜੰਟ ਨਾਲ ਜੋੜਿਆ ਜਾਵੇ, ਜਿਸ ਨਾਲ ਤੁਹਾਡਾ ਏਜੰਟ ਕੁਦਰਤੀ ਭਾਸ਼ਾ ਰਾਹੀਂ ਜੋੜ, ਘਟਾਓ, ਗੁਣਾ ਅਤੇ ਭਾਗ ਵਰਗੀਆਂ ਗਣਿਤੀ ਕਾਰਵਾਈਆਂ ਕਰ ਸਕੇ।

AI Toolkit Visual Studio Code ਲਈ ਇੱਕ ਸ਼ਕਤੀਸ਼ਾਲੀ ਐਕਸਟੈਂਸ਼ਨ ਹੈ ਜੋ ਏਜੰਟ ਵਿਕਾਸ ਨੂੰ ਸਧਾਰਨ ਬਣਾਉਂਦਾ ਹੈ। AI ਇੰਜੀਨੀਅਰ ਆਸਾਨੀ ਨਾਲ ਜਨਰੇਟਿਵ AI ਮਾਡਲਾਂ ਨੂੰ ਵਿਕਸਿਤ ਅਤੇ ਟੈਸਟ ਕਰ ਸਕਦੇ ਹਨ—ਚਾਹੇ ਉਹ ਲੋਕਲ ਹੋਣ ਜਾਂ ਕਲਾਉਡ ਵਿੱਚ। ਇਹ ਐਕਸਟੈਂਸ਼ਨ ਅੱਜ ਮੌਜੂਦ ਜ਼ਿਆਦਾਤਰ ਪ੍ਰਮੁੱਖ ਜਨਰੇਟਿਵ ਮਾਡਲਾਂ ਨੂੰ ਸਹਿਯੋਗ ਦਿੰਦਾ ਹੈ।

*ਨੋਟ*: AI Toolkit ਇਸ ਸਮੇਂ Python ਅਤੇ TypeScript ਨੂੰ ਸਹਿਯੋਗ ਦਿੰਦਾ ਹੈ।

## ਸਿੱਖਣ ਦੇ ਲਕੜੇ

ਇਸ ਪਾਠ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਸਮਰੱਥ ਹੋਵੋਗੇ:

- AI Toolkit ਰਾਹੀਂ MCP ਸਰਵਰ ਦੀ ਵਰਤੋਂ ਕਰਨਾ।
- ਏਜੰਟ ਕਨਫਿਗਰੇਸ਼ਨ ਤਿਆਰ ਕਰਨਾ ਤਾਂ ਜੋ ਉਹ MCP ਸਰਵਰ ਵੱਲੋਂ ਦਿੱਤੇ ਗਏ ਟੂਲਾਂ ਨੂੰ ਖੋਜ ਅਤੇ ਵਰਤ ਸਕੇ।
- ਕੁਦਰਤੀ ਭਾਸ਼ਾ ਰਾਹੀਂ MCP ਟੂਲਾਂ ਦੀ ਵਰਤੋਂ ਕਰਨਾ।

## ਤਰੀਕਾ

ਇਸਨੂੰ ਉੱਚ ਸਤਰ ‘ਤੇ ਇਸ ਤਰ੍ਹਾਂ ਅਪਣਾਉਣਾ ਹੈ:

- ਇੱਕ ਏਜੰਟ ਬਣਾਓ ਅਤੇ ਉਸਦਾ ਸਿਸਟਮ ਪ੍ਰਾਂਪਟ ਪਰਿਭਾਸ਼ਿਤ ਕਰੋ।
- ਕੈਲਕੂਲੇਟਰ ਟੂਲਾਂ ਨਾਲ ਇੱਕ MCP ਸਰਵਰ ਬਣਾਓ।
- Agent Builder ਨੂੰ MCP ਸਰਵਰ ਨਾਲ ਜੋੜੋ।
- ਕੁਦਰਤੀ ਭਾਸ਼ਾ ਰਾਹੀਂ ਏਜੰਟ ਦੇ ਟੂਲ ਕਾਲ ਨੂੰ ਟੈਸਟ ਕਰੋ।

ਵਧੀਆ, ਹੁਣ ਜਦੋਂ ਅਸੀਂ ਪ੍ਰਕਿਰਿਆ ਨੂੰ ਸਮਝ ਗਏ ਹਾਂ, ਆਓ MCP ਰਾਹੀਂ ਬਾਹਰੀ ਟੂਲਾਂ ਦੀ ਵਰਤੋਂ ਲਈ AI ਏਜੰਟ ਨੂੰ ਕਨਫਿਗਰ ਕਰੀਏ ਅਤੇ ਇਸ ਦੀ ਸਮਰੱਥਾ ਵਧਾਈਏ!

## ਲੋੜੀਂਦੇ ਸਾਧਨ

- [Visual Studio Code](https://code.visualstudio.com/)
- [Visual Studio Code ਲਈ AI Toolkit](https://aka.ms/AIToolkit)

## ਅਭਿਆਸ: ਸਰਵਰ ਦੀ ਵਰਤੋਂ ਕਰਨਾ

ਇਸ ਅਭਿਆਸ ਵਿੱਚ, ਤੁਸੀਂ Visual Studio Code ਵਿੱਚ AI Toolkit ਦੀ ਵਰਤੋਂ ਕਰਕੇ MCP ਸਰਵਰ ਤੋਂ ਟੂਲਾਂ ਨਾਲ ਇੱਕ AI ਏਜੰਟ ਬਣਾਉਂਦੇ, ਚਲਾਉਂਦੇ ਅਤੇ ਸੁਧਾਰਦੇ ਹੋ।

### -0- ਪਹਿਲਾ ਕਦਮ, OpenAI GPT-4o ਮਾਡਲ ਨੂੰ My Models ਵਿੱਚ ਸ਼ਾਮਲ ਕਰੋ

ਇਹ ਅਭਿਆਸ **GPT-4o** ਮਾਡਲ ਦੀ ਵਰਤੋਂ ਕਰਦਾ ਹੈ। ਏਜੰਟ ਬਣਾਉਣ ਤੋਂ ਪਹਿਲਾਂ ਇਹ ਮਾਡਲ **My Models** ਵਿੱਚ ਸ਼ਾਮਲ ਹੋਣਾ ਚਾਹੀਦਾ ਹੈ।

![Visual Studio Code ਦੇ AI Toolkit ਐਕਸਟੈਂਸ਼ਨ ਵਿੱਚ ਮਾਡਲ ਚੋਣ ਇੰਟਰਫੇਸ ਦੀ ਸਕ੍ਰੀਨਸ਼ਾਟ। ਸਿਰਲੇਖ ਹੈ "Find the right model for your AI Solution" ਅਤੇ ਸਬਟਾਈਟਲ ਉਪਭੋਗਤਾਵਾਂ ਨੂੰ AI ਮਾਡਲਾਂ ਦੀ ਖੋਜ, ਟੈਸਟ ਅਤੇ ਡਿਪਲੋਇ ਕਰਨ ਲਈ ਪ੍ਰੇਰਿਤ ਕਰਦਾ ਹੈ। “Popular Models” ਹੇਠਾਂ ਛੇ ਮਾਡਲ ਕਾਰਡ ਦਿਖਾਏ ਗਏ ਹਨ: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), ਅਤੇ DeepSeek-R1 (Ollama-hosted)। ਹਰ ਕਾਰਡ ਵਿੱਚ “Add” ਅਤੇ “Try in Playground” ਦੇ ਵਿਕਲਪ ਹਨ।](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.pa.png)

1. **Activity Bar** ਤੋਂ **AI Toolkit** ਐਕਸਟੈਂਸ਼ਨ ਖੋਲ੍ਹੋ।
2. **Catalog** ਸੈਕਸ਼ਨ ਵਿੱਚ **Models** ਚੁਣੋ ਤਾਂ ਜੋ **Model Catalog** ਖੁਲ ਜਾਵੇ। ਇਹ ਨਵੀਂ ਐਡੀਟਰ ਟੈਬ ਵਿੱਚ ਖੁਲਦਾ ਹੈ।
3. **Model Catalog** ਦੀ ਖੋਜ ਬਾਰ ਵਿੱਚ **OpenAI GPT-4o** ਲਿਖੋ।
4. **+ Add** ‘ਤੇ ਕਲਿੱਕ ਕਰਕੇ ਮਾਡਲ ਨੂੰ **My Models** ਵਿੱਚ ਸ਼ਾਮਲ ਕਰੋ। ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਤੁਸੀਂ ਉਹ ਮਾਡਲ ਚੁਣਿਆ ਹੈ ਜੋ **GitHub ਵੱਲੋਂ ਹੋਸਟ ਕੀਤਾ ਗਿਆ ਹੈ**।
5. **Activity Bar** ਵਿੱਚ ਪੱਕਾ ਕਰੋ ਕਿ **OpenAI GPT-4o** ਮਾਡਲ ਸੂਚੀ ਵਿੱਚ ਦਿਖਾਈ ਦੇ ਰਿਹਾ ਹੈ।

### -1- ਏਜੰਟ ਬਣਾਓ

**Agent (Prompt) Builder** ਤੁਹਾਨੂੰ ਆਪਣੇ AI-ਚਲਿਤ ਏਜੰਟ ਬਣਾਉਣ ਅਤੇ ਕਸਟਮਾਈਜ਼ ਕਰਨ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ। ਇਸ ਹਿੱਸੇ ਵਿੱਚ, ਤੁਸੀਂ ਇੱਕ ਨਵਾਂ ਏਜੰਟ ਬਣਾਉਂਦੇ ਹੋ ਅਤੇ ਗੱਲਬਾਤ ਲਈ ਮਾਡਲ ਨਿਰਧਾਰਤ ਕਰਦੇ ਹੋ।

![Visual Studio Code ਲਈ AI Toolkit ਐਕਸਟੈਂਸ਼ਨ ਵਿੱਚ "Calculator Agent" ਬਿਲਡਰ ਇੰਟਰਫੇਸ ਦੀ ਸਕ੍ਰੀਨਸ਼ਾਟ। ਖੱਬੇ ਪੈਨਲ ਵਿੱਚ ਚੁਣਿਆ ਮਾਡਲ "OpenAI GPT-4o (via GitHub)" ਹੈ। ਸਿਸਟਮ ਪ੍ਰਾਂਪਟ ਹੈ "ਤੁਸੀਂ ਯੂਨੀਵਰਸਿਟੀ ਵਿੱਚ ਗਣਿਤ ਸਿਖਾਉਣ ਵਾਲੇ ਪ੍ਰੋਫੈਸਰ ਹੋ," ਅਤੇ ਯੂਜ਼ਰ ਪ੍ਰਾਂਪਟ ਹੈ "ਮੈਨੂੰ ਫੂਰੀਏ ਸਮੀਕਰਨ ਸਧਾਰਨ ਸ਼ਬਦਾਂ ਵਿੱਚ ਸਮਝਾਓ।" ਹੋਰ ਵਿਕਲਪਾਂ ਵਿੱਚ ਟੂਲ ਸ਼ਾਮਲ ਕਰਨ, MCP ਸਰਵਰ ਚਾਲੂ ਕਰਨ ਅਤੇ ਸਟ੍ਰਕਚਰਡ ਆਉਟਪੁੱਟ ਚੁਣਨ ਦੇ ਬਟਨ ਹਨ। ਹੇਠਾਂ ਨੀਲੇ ਰੰਗ ਦਾ “Run” ਬਟਨ ਹੈ। ਸੱਜੇ ਪੈਨਲ ਵਿੱਚ "Get Started with Examples" ਹੇਠਾਂ ਤਿੰਨ ਨਮੂਨਾ ਏਜੰਟ ਹਨ: Web Developer (MCP Server, Second-Grade Simplifier, Dream Interpreter ਸਮੇਤ)।](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.pa.png)

1. **Activity Bar** ਤੋਂ **AI Toolkit** ਐਕਸਟੈਂਸ਼ਨ ਖੋਲ੍ਹੋ।
2. **Tools** ਸੈਕਸ਼ਨ ਵਿੱਚ **Agent (Prompt) Builder** ਚੁਣੋ। ਇਹ ਨਵੀਂ ਐਡੀਟਰ ਟੈਬ ਵਿੱਚ ਖੁਲਦਾ ਹੈ।
3. **+ New Agent** ਬਟਨ ‘ਤੇ ਕਲਿੱਕ ਕਰੋ। ਐਕਸਟੈਂਸ਼ਨ **Command Palette** ਰਾਹੀਂ ਸੈਟਅਪ ਵਿਜ਼ਾਰਡ ਸ਼ੁਰੂ ਕਰੇਗਾ।
4. ਨਾਮ ਵਜੋਂ **Calculator Agent** ਦਿਓ ਅਤੇ **Enter** ਦਬਾਓ।
5. **Agent (Prompt) Builder** ਵਿੱਚ **Model** ਫੀਲਡ ਲਈ **OpenAI GPT-4o (via GitHub)** ਮਾਡਲ ਚੁਣੋ।

### -2- ਏਜੰਟ ਲਈ ਸਿਸਟਮ ਪ੍ਰਾਂਪਟ ਬਣਾਓ

ਏਜੰਟ ਬਣਾਉਣ ਤੋਂ ਬਾਅਦ, ਹੁਣ ਇਸ ਦੀ ਸ਼ਖਸੀਅਤ ਅਤੇ ਮਕਸਦ ਨਿਰਧਾਰਿਤ ਕਰਨ ਦਾ ਸਮਾਂ ਹੈ। ਇਸ ਹਿੱਸੇ ਵਿੱਚ, ਤੁਸੀਂ **Generate system prompt** ਫੀਚਰ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਏਜੰਟ ਦੇ ਵਰਤਾਰਾ ਦਾ ਵਰਣਨ ਕਰੋਗੇ—ਇਸ ਮਾਮਲੇ ਵਿੱਚ ਇੱਕ ਕੈਲਕੂਲੇਟਰ ਏਜੰਟ—ਅਤੇ ਮਾਡਲ ਤੁਹਾਡੇ ਲਈ ਸਿਸਟਮ ਪ੍ਰਾਂਪਟ ਲਿਖੇਗਾ।

![Visual Studio Code ਲਈ AI Toolkit ਵਿੱਚ "Calculator Agent" ਇੰਟਰਫੇਸ ਦੀ ਸਕ੍ਰੀਨਸ਼ਾਟ ਜਿਸ ਵਿੱਚ "Generate a prompt" ਨਾਮਕ ਮੋਡਲ ਵਿੰਡੋ ਖੁੱਲੀ ਹੋਈ ਹੈ। ਮੋਡਲ ਵਿੱਚ ਦੱਸਿਆ ਗਿਆ ਹੈ ਕਿ ਪ੍ਰਾਂਪਟ ਟੈਮਪਲੇਟ ਬੁਨਿਆਦੀ ਜਾਣਕਾਰੀ ਸਾਂਝੀ ਕਰਕੇ ਬਣਾਇਆ ਜਾ ਸਕਦਾ ਹੈ। ਟੈਕਸਟ ਬਾਕਸ ਵਿੱਚ ਨਮੂਨਾ ਸਿਸਟਮ ਪ੍ਰਾਂਪਟ ਹੈ: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." ਹੇਠਾਂ "Close" ਅਤੇ "Generate" ਬਟਨ ਹਨ। ਪਿਛੋਕੜ ਵਿੱਚ ਏਜੰਟ ਕਨਫਿਗਰੇਸ਼ਨ ਦਾ ਹਿੱਸਾ ਦਿਖਾਈ ਦੇ ਰਿਹਾ ਹੈ, ਜਿਸ ਵਿੱਚ ਚੁਣਿਆ ਮਾਡਲ "OpenAI GPT-4o (via GitHub)" ਅਤੇ ਸਿਸਟਮ ਅਤੇ ਯੂਜ਼ਰ ਪ੍ਰਾਂਪਟ ਫੀਲਡ ਹਨ।](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.pa.png)

1. **Prompts** ਸੈਕਸ਼ਨ ਵਿੱਚ **Generate system prompt** ਬਟਨ ‘ਤੇ ਕਲਿੱਕ ਕਰੋ। ਇਹ ਬਟਨ ਪ੍ਰਾਂਪਟ ਬਿਲਡਰ ਖੋਲ੍ਹਦਾ ਹੈ ਜੋ AI ਦੀ ਮਦਦ ਨਾਲ ਸਿਸਟਮ ਪ੍ਰਾਂਪਟ ਬਣਾਉਂਦਾ ਹੈ।
2. **Generate a prompt** ਵਿੰਡੋ ਵਿੱਚ ਇਹ ਲਿਖੋ: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. **Generate** ਬਟਨ ‘ਤੇ ਕਲਿੱਕ ਕਰੋ। ਨੋਟੀਫਿਕੇਸ਼ਨ ਨੀਵੇਂ-ਸੱਜੇ ਕੋਨੇ ਵਿੱਚ ਆਵੇਗੀ ਕਿ ਸਿਸਟਮ ਪ੍ਰਾਂਪਟ ਬਣਾਇਆ ਜਾ ਰਿਹਾ ਹੈ। ਜਦੋਂ ਪ੍ਰਕਿਰਿਆ ਮੁਕੰਮਲ ਹੋ ਜਾਵੇ, ਪ੍ਰਾਂਪਟ **Agent (Prompt) Builder** ਦੇ **System prompt** ਫੀਲਡ ਵਿੱਚ ਦਿਖਾਈ ਦੇਵੇਗਾ।
4. **System prompt** ਨੂੰ ਸਮੀਖਿਆ ਕਰੋ ਅਤੇ ਜਰੂਰਤ ਪੈਣ ‘ਤੇ ਸੋਧ ਕਰੋ।

### -3- MCP ਸਰਵਰ ਬਣਾਓ

ਹੁਣ ਜਦੋਂ ਤੁਸੀਂ ਆਪਣੇ ਏਜੰਟ ਦਾ ਸਿਸਟਮ ਪ੍ਰਾਂਪਟ ਨਿਰਧਾਰਿਤ ਕਰ ਲਿਆ ਹੈ—ਜੋ ਇਸ ਦੇ ਵਰਤਾਰਾ ਅਤੇ ਜਵਾਬਾਂ ਨੂੰ ਦਿਸ਼ਾ ਦਿੰਦਾ ਹੈ—ਹੁਣ ਇਸਨੂੰ ਕਾਰਗੁਜ਼ਾਰੀ ਦੇਣ ਦਾ ਸਮਾਂ ਹੈ। ਇਸ ਹਿੱਸੇ ਵਿੱਚ, ਤੁਸੀਂ ਜੋੜ, ਘਟਾਓ, ਗੁਣਾ ਅਤੇ ਭਾਗ ਕਰਨ ਵਾਲੇ ਟੂਲਾਂ ਨਾਲ ਇੱਕ ਕੈਲਕੂਲੇਟਰ MCP ਸਰਵਰ ਬਣਾਉਗੇ। ਇਹ ਸਰਵਰ ਤੁਹਾਡੇ ਏਜੰਟ ਨੂੰ ਕੁਦਰਤੀ ਭਾਸ਼ਾ ਪ੍ਰਾਂਪਟਾਂ ਦੇ ਜਵਾਬ ਵਿੱਚ ਤੁਰੰਤ ਗਣਿਤੀ ਕਾਰਵਾਈਆਂ ਕਰਨ ਦੇ ਯੋਗ ਬਣਾਏਗਾ।

![Visual Studio Code ਲਈ AI Toolkit ਐਕਸਟੈਂਸ਼ਨ ਵਿੱਚ Calculator Agent ਇੰਟਰਫੇਸ ਦੇ ਹੇਠਲੇ ਹਿੱਸੇ ਦੀ ਸਕ੍ਰੀਨਸ਼ਾਟ। ਇਸ ਵਿੱਚ “Tools” ਅਤੇ “Structure output” ਲਈ ਵਧਾਉਣ ਯੋਗ ਮੀਨੂ ਹਨ, ਨਾਲ ਹੀ “Choose output format” ਡ੍ਰਾਪਡਾਊਨ ਮੀਨੂ ਹੈ ਜੋ “text” ‘ਤੇ ਸੈੱਟ ਹੈ। ਸੱਜੇ ਪਾਸੇ, “+ MCP Server” ਬਟਨ ਹੈ ਜੋ Model Context Protocol ਸਰਵਰ ਸ਼ਾਮਲ ਕਰਨ ਲਈ ਹੈ। Tools ਸੈਕਸ਼ਨ ਦੇ ਉੱਪਰ ਇੱਕ ਇਮੇਜ ਆਈਕਨ ਪਲੇਸਹੋਲਡਰ ਵੀ ਹੈ।](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.pa.png)

AI Toolkit ਆਪਣੇ MCP ਸਰਵਰ ਬਣਾਉਣ ਲਈ ਟੈਮਪਲੇਟਾਂ ਨਾਲ ਲੈਸ ਹੈ। ਅਸੀਂ ਕੈਲਕੂਲੇਟਰ MCP ਸਰਵਰ ਬਣਾਉਣ ਲਈ Python ਟੈਮਪਲੇਟ ਦੀ ਵਰਤੋਂ ਕਰਾਂਗੇ।

*ਨੋਟ*: AI Toolkit ਇਸ ਸਮੇਂ Python ਅਤੇ TypeScript ਨੂੰ ਸਹਿਯੋਗ ਦਿੰਦਾ ਹੈ।

1. **Agent (Prompt) Builder** ਦੇ **Tools** ਸੈਕਸ਼ਨ ਵਿੱਚ **+ MCP Server** ਬਟਨ ‘ਤੇ ਕਲਿੱਕ ਕਰੋ। ਐਕਸਟੈਂਸ਼ਨ **Command Palette** ਰਾਹੀਂ ਸੈਟਅਪ ਵਿਜ਼ਾਰਡ ਸ਼ੁਰੂ ਕਰੇਗਾ।
2. **+ Add Server** ਚੁਣੋ।
3. **Create a New MCP Server** ਚੁਣੋ।
4. **python-weather** ਟੈਮਪਲੇਟ ਚੁਣੋ।
5. MCP ਸਰਵਰ ਟੈਮਪਲੇਟ ਸੇਵ ਕਰਨ ਲਈ **Default folder** ਚੁਣੋ।
6. ਸਰਵਰ ਲਈ ਇਹ ਨਾਮ ਦਿਓ: **Calculator**
7. ਇੱਕ ਨਵੀਂ Visual Studio Code ਵਿੰਡੋ ਖੁਲੇਗੀ। **Yes, I trust the authors** ਚੁਣੋ।
8. ਟਰਮੀਨਲ ਵਿੱਚ (Terminal > New Terminal) ਵਰਚੁਅਲ ਇਨਵਾਇਰਨਮੈਂਟ ਬਣਾਓ: `python -m venv .venv`
9. ਟਰਮੀਨਲ ਵਿੱਚ ਵਰਚੁਅਲ ਇਨਵਾਇਰਨਮੈਂਟ ਐਕਟੀਵੇਟ ਕਰੋ:
    - Windows: `.venv\Scripts\activate`
    - macOS/Linux: `source venv/bin/activate`
10. ਟਰਮੀਨਲ ਵਿੱਚ ਡਿਪੈਂਡੈਂਸੀਜ਼ ਇੰਸਟਾਲ ਕਰੋ: `pip install -e .[dev]`
11. **Activity Bar** ਦੇ **Explorer** ਵਿਊ ਵਿੱਚ **src** ਡਾਇਰੈਕਟਰੀ ਖੋਲ੍ਹੋ ਅਤੇ **server.py** ਫਾਈਲ ਖੋਲ੍ਹੋ।
12. **server.py** ਵਿੱਚ ਮੌਜੂਦਾ ਕੋਡ ਨੂੰ ਹਟਾ ਕੇ ਹੇਠਾਂ ਦਿੱਤਾ ਕੋਡ ਪੇਸਟ ਕਰੋ ਅਤੇ ਸੇਵ ਕਰੋ:

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

### -4- ਕੈਲਕੂਲੇਟਰ MCP ਸਰਵਰ ਨਾਲ ਏਜੰਟ ਚਲਾਓ

ਹੁਣ ਜਦੋਂ ਤੁਹਾਡੇ ਏਜੰਟ ਕੋਲ ਟੂਲ ਹਨ, ਉਨ੍ਹਾਂ ਦੀ ਵਰਤੋਂ ਕਰਨ ਦਾ ਸਮਾਂ ਹੈ! ਇਸ ਹਿੱਸੇ ਵਿੱਚ, ਤੁਸੀਂ ਏਜੰਟ ਨੂੰ ਪ੍ਰਾਂਪਟ ਭੇਜ ਕੇ ਟੈਸਟ ਕਰੋਗੇ ਕਿ ਕੀ ਇਹ ਕੈਲਕੂਲੇਟਰ MCP ਸਰਵਰ ਤੋਂ ਸਹੀ ਟੂਲ ਵਰਤ ਰਿਹਾ ਹੈ ਜਾਂ ਨਹੀਂ।

![Visual Studio Code ਲਈ AI Toolkit ਵਿੱਚ Calculator Agent ਇੰਟਰਫੇਸ ਦੀ ਸਕ੍ਰੀਨਸ਼ਾਟ। ਖੱਬੇ ਪੈਨਲ ਵਿੱਚ “Tools” ਹੇਠਾਂ ਇੱਕ MCP ਸਰਵਰ local-server-calculator_server ਸ਼ਾਮਲ ਹੈ, ਜਿਸ ਵਿੱਚ ਚਾਰ ਉਪਲਬਧ ਟੂਲ ਹਨ: add, subtract, multiply, ਅਤੇ divide। ਇੱਕ ਬੈਜ ਦਿਖਾ ਰਿਹਾ ਹੈ ਕਿ ਚਾਰ ਟੂਲ ਸਰਗਰਮ ਹਨ। ਹੇਠਾਂ “Structure output” ਸੈਕਸ਼ਨ ਕਲੋਜ਼ ਹੈ ਅਤੇ ਨੀਲਾ “Run” ਬਟਨ ਹੈ। ਸੱਜੇ ਪੈਨਲ ਵਿੱਚ “Model Response” ਹੇਠਾਂ ਏਜੰਟ multiply ਅਤੇ subtract ਟੂਲਾਂ ਨੂੰ ਇਨਪੁੱਟ {"a": 3, "b": 25} ਅਤੇ {"a": 75, "b": 20} ਦੇ ਨਾਲ ਕਾਲ ਕਰ ਰਿਹਾ ਹੈ। ਅੰਤਿਮ “Tool Response” 75.0 ਦਿਖਾਇਆ ਗਿਆ ਹੈ। ਹੇਠਾਂ “View Code” ਬਟਨ ਹੈ।](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.pa.png)

ਤੁਸੀਂ ਆਪਣੇ ਲੋਕਲ ਡਿਵੈਲਪਮੈਂਟ ਮਸ਼ੀਨ ‘ਤੇ **Agent Builder** ਰਾਹੀਂ MCP ਸਰਵਰ ਚਲਾਓਗੇ।

1. MCP ਸਰਵਰ ਡੀਬੱਗ ਕਰਨ ਲਈ `F5` ਦਬਾਓ। **Agent (Prompt) Builder** ਨਵੀਂ ਐਡੀਟਰ ਟੈਬ ਵਿੱਚ ਖੁਲ ਜਾਵੇਗਾ। ਟਰਮੀਨਲ ਵਿੱਚ ਸਰਵਰ ਦੀ ਸਥਿਤੀ ਦਿਖਾਈ ਦੇਵੇਗੀ।
2. **Agent (Prompt) Builder** ਦੇ **User prompt** ਫੀਲਡ ਵਿੱਚ ਇਹ ਪ੍ਰਾਂਪਟ ਦਿਓ: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
3. ਏਜੰਟ ਦਾ ਜਵਾਬ ਬਣਾਉਣ ਲਈ **Run** ਬਟਨ ‘ਤੇ ਕਲਿੱਕ ਕਰੋ।
4. ਏਜੰਟ ਦੇ ਆਉਟਪੁੱਟ ਦੀ ਸਮੀਖਿਆ ਕਰੋ। ਮਾਡਲ ਨੂੰ ਨਤੀਜਾ ਦੇਣਾ ਚਾਹੀਦਾ ਹੈ ਕਿ ਤੁਸੀਂ **$55** ਦਿੱਤੇ।
5. ਇਹ ਹੈ ਕਿ ਕੀ ਹੋਣਾ ਚਾਹੀਦਾ ਹੈ:
    - ਏਜੰਟ ਗਣਨਾ ਵਿੱਚ ਮਦਦ ਲਈ **multiply** ਅਤੇ **subtract** ਟੂਲਾਂ ਚੁਣਦਾ ਹੈ।
    - **multiply** ਟੂਲ ਲਈ `a` ਅਤੇ `b` ਮੁੱਲ ਦਿੱਤੇ ਜਾਂਦੇ ਹਨ।


**ਅਸਵੀਕਾਰੋਪਣ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਮਰਥਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਨਾਲ ਹੋਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀਆਂ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆਵਾਂ ਲਈ ਅਸੀਂ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।