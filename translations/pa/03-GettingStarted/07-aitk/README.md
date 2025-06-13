<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1980763f2a545ca6648363bf5757b5a",
  "translation_date": "2025-06-13T02:18:01+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "pa"
}
-->
# Visual Studio Code ਲਈ AI Toolkit ਵਿਸ਼ਤਾਰ ਤੋਂ ਸਰਵਰ ਦੀ ਵਰਤੋਂ ਕਰਨਾ

ਜਦੋਂ ਤੁਸੀਂ ਇੱਕ AI ਏਜੰਟ ਬਣਾ ਰਹੇ ਹੋ, ਤਾਂ ਸਿਰਫ ਸਮਝਦਾਰ ਜਵਾਬ ਬਣਾਉਣਾ ਹੀ ਨਹੀਂ, ਬਲਕਿ ਆਪਣੇ ਏਜੰਟ ਨੂੰ ਕਾਰਵਾਈ ਕਰਨ ਦੀ ਸਮਰੱਥਾ ਦੇਣਾ ਵੀ ਜਰੂਰੀ ਹੁੰਦਾ ਹੈ। ਇੱਥੇ Model Context Protocol (MCP) ਕੰਮ ਆਉਂਦਾ ਹੈ। MCP ਏਜੰਟਾਂ ਨੂੰ ਬਾਹਰੀ ਟੂਲਾਂ ਅਤੇ ਸਰਵਿਸਜ਼ ਤੱਕ ਸਥਿਰ ਢੰਗ ਨਾਲ ਪਹੁੰਚ ਦੇਣਾ ਆਸਾਨ ਬਣਾਉਂਦਾ ਹੈ। ਇਸਨੂੰ ਇਸ ਤਰ੍ਹਾਂ ਸੋਚੋ ਜਿਵੇਂ ਤੁਸੀਂ ਆਪਣੇ ਏਜੰਟ ਨੂੰ ਇੱਕ ਐਸੇ ਟੂਲਬਾਕਸ ਨਾਲ ਜੋੜ ਰਹੇ ਹੋ ਜੋ ਉਹ ਅਸਲ ਵਿੱਚ ਵਰਤ ਸਕਦਾ ਹੈ।

ਮਾਨ ਲਓ ਤੁਸੀਂ ਆਪਣੇ ਏਜੰਟ ਨੂੰ ਕੈਲਕੂਲੇਟਰ MCP ਸਰਵਰ ਨਾਲ ਜੋੜਦੇ ਹੋ। ਅਚਾਨਕ, ਤੁਹਾਡਾ ਏਜੰਟ ਸਿਰਫ ਪ੍ਰਾਂਪਟ "47 ਗੁਣਾ 89 ਕਿੰਨਾ ਹੁੰਦਾ ਹੈ?" ਲੈ ਕੇ ਗਣਿਤੀ ਕਾਰਵਾਈਆਂ ਕਰ ਸਕਦਾ ਹੈ—ਕੋਈ ਲਾਜਿਕ ਹਾਰਡਕੋਡ ਕਰਨ ਜਾਂ ਕਸਟਮ API ਬਣਾਉਣ ਦੀ ਲੋੜ ਨਹੀਂ।

## ਝਲਕ

ਇਸ ਪਾਠ ਵਿੱਚ ਦਿਖਾਇਆ ਗਿਆ ਹੈ ਕਿ ਕਿਵੇਂ Visual Studio Code ਵਿੱਚ [AI Toolkit](https://aka.ms/AIToolkit) ਵਿਸ਼ਤਾਰ ਨਾਲ ਇੱਕ ਕੈਲਕੂਲੇਟਰ MCP ਸਰਵਰ ਨੂੰ ਏਜੰਟ ਨਾਲ ਜੋੜ ਕੇ ਤੁਹਾਡੇ ਏਜੰਟ ਨੂੰ ਕੁਦਰਤੀ ਭਾਸ਼ਾ ਰਾਹੀਂ ਜੋੜ, ਘਟਾ, ਗੁਣਾ ਅਤੇ ਭਾਗ ਕਰਨ ਵਰਗੀਆਂ ਗਣਿਤੀ ਕਾਰਵਾਈਆਂ ਕਰਨ ਦੇ ਯੋਗ ਬਣਾਇਆ ਜਾ ਸਕਦਾ ਹੈ।

AI Toolkit Visual Studio Code ਲਈ ਇੱਕ ਤਾਕਤਵਰ ਵਿਸ਼ਤਾਰ ਹੈ ਜੋ ਏਜੰਟ ਵਿਕਾਸ ਨੂੰ ਆਸਾਨ ਬਣਾਉਂਦਾ ਹੈ। AI ਇੰਜੀਨੀਅਰ ਸਥਾਨਕ ਜਾਂ ਕਲਾਉਡ ਵਿੱਚ ਜਨਰੇਟਿਵ AI ਮਾਡਲ ਬਣਾਉਣ ਅਤੇ ਟੈਸਟ ਕਰਨ ਰਾਹੀਂ ਆਸਾਨੀ ਨਾਲ AI ਐਪਲੀਕੇਸ਼ਨ ਤਿਆਰ ਕਰ ਸਕਦੇ ਹਨ। ਇਹ ਵਿਸ਼ਤਾਰ ਅੱਜ ਦੇ ਜ਼ਿਆਦਾਤਰ ਪ੍ਰਮੁੱਖ ਜਨਰੇਟਿਵ ਮਾਡਲਾਂ ਦਾ ਸਮਰਥਨ ਕਰਦਾ ਹੈ।

*ਨੋਟ*: AI Toolkit ਵਰਤਮਾਨ ਵਿੱਚ Python ਅਤੇ TypeScript ਨੂੰ ਸਮਰਥਿਤ ਕਰਦਾ ਹੈ।

## ਸਿੱਖਣ ਦੇ ਲਕੜੀ

ਇਸ ਪਾਠ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਸਮਰੱਥ ਹੋਵੋਗੇ:

- AI Toolkit ਰਾਹੀਂ MCP ਸਰਵਰ ਦੀ ਵਰਤੋਂ ਕਰਨਾ।
- ਏਜੰਟ ਦੀ ਸੰਰਚਨਾ ਇਸ ਤਰ੍ਹਾਂ ਸੈੱਟ ਕਰਨੀ ਕਿ ਉਹ MCP ਸਰਵਰ ਵੱਲੋਂ ਦਿੱਤੇ ਗਏ ਟੂਲਾਂ ਨੂੰ ਖੋਜ ਅਤੇ ਵਰਤ ਸਕੇ।
- ਕੁਦਰਤੀ ਭਾਸ਼ਾ ਰਾਹੀਂ MCP ਟੂਲਾਂ ਦੀ ਵਰਤੋਂ ਕਰਨੀ।

## ਤਰੀਕਾ

ਇਸ ਨੂੰ ਉੱਚ ਸਤਰ 'ਤੇ ਇਸ ਤਰ੍ਹਾਂ ਕਰਨਾ ਹੈ:

- ਇੱਕ ਏਜੰਟ ਬਣਾਓ ਅਤੇ ਉਸਦਾ ਸਿਸਟਮ ਪ੍ਰਾਂਪਟ ਪਰਿਭਾਸ਼ਿਤ ਕਰੋ।
- ਕੈਲਕੂਲੇਟਰ ਟੂਲਾਂ ਵਾਲਾ MCP ਸਰਵਰ ਬਣਾਓ।
- Agent Builder ਨੂੰ MCP ਸਰਵਰ ਨਾਲ ਜੋੜੋ।
- ਕੁਦਰਤੀ ਭਾਸ਼ਾ ਰਾਹੀਂ ਏਜੰਟ ਦੇ ਟੂਲ ਇੰਵੋਕੇਸ਼ਨ ਦੀ ਜਾਂਚ ਕਰੋ।

ਵਧੀਆ, ਹੁਣ ਜਦੋਂ ਅਸੀਂ ਪ੍ਰਕਿਰਿਆ ਸਮਝ ਗਏ ਹਾਂ, ਆਓ MCP ਰਾਹੀਂ ਬਾਹਰੀ ਟੂਲਾਂ ਨੂੰ ਵਰਤਣ ਲਈ AI ਏਜੰਟ ਨੂੰ ਕਨਫਿਗਰ ਕਰੀਏ, ਤਾਂ ਜੋ ਇਸ ਦੀ ਸਮਰੱਥਾ ਵਧੇ!

## ਲੋੜੀਂਦੇ ਸਾਧਨ

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## ਅਭਿਆਸ: ਸਰਵਰ ਦੀ ਵਰਤੋਂ ਕਰਨਾ

ਇਸ ਅਭਿਆਸ ਵਿੱਚ, ਤੁਸੀਂ Visual Studio Code ਵਿੱਚ AI Toolkit ਦੀ ਵਰਤੋਂ ਕਰਕੇ MCP ਸਰਵਰ ਤੋਂ ਟੂਲਾਂ ਨਾਲ ਇੱਕ AI ਏਜੰਟ ਬਣਾਉਂਦੇ, ਚਲਾਉਂਦੇ ਅਤੇ ਸੁਧਾਰਦੇ ਹੋ।

### -0- ਪਹਿਲਾਂ, OpenAI GPT-4o ਮਾਡਲ ਨੂੰ My Models ਵਿੱਚ ਸ਼ਾਮਲ ਕਰੋ

ਅਭਿਆਸ ਵਿੱਚ **GPT-4o** ਮਾਡਲ ਦੀ ਵਰਤੋਂ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਏਜੰਟ ਬਣਾਉਣ ਤੋਂ ਪਹਿਲਾਂ ਇਹ ਮਾਡਲ **My Models** ਵਿੱਚ ਸ਼ਾਮਲ ਹੋਣਾ ਚਾਹੀਦਾ ਹੈ।

![Visual Studio Code ਦੇ AI Toolkit ਵਿਸ਼ਤਾਰ ਵਿੱਚ ਮਾਡਲ ਚੋਣ ਇੰਟਰਫੇਸ ਦੀ ਸਕ੍ਰੀਨਸ਼ਾਟ। ਸਿਰਲੇਖ "Find the right model for your AI Solution" ਹੈ ਅਤੇ ਉਪਸਿਰਲੇਖ ਉਪਭੋਗਤਾਵਾਂ ਨੂੰ AI ਮਾਡਲਾਂ ਦੀ ਖੋਜ, ਟੈਸਟ ਅਤੇ ਡਿਪਲੌਇ ਕਰਨ ਲਈ ਪ੍ਰੇਰਿਤ ਕਰਦਾ ਹੈ। ਹੇਠਾਂ "Popular Models" ਵਿੱਚ ਛੇ ਮਾਡਲ ਕਾਰਡ ਹਨ: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), ਅਤੇ DeepSeek-R1 (Ollama-hosted)। ਹਰ ਕਾਰਡ 'Add' ਅਤੇ 'Try in Playground' ਵਿਕਲਪ ਦਿਖਾਉਂਦਾ ਹੈ।](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.pa.png)

1. **Activity Bar** ਤੋਂ **AI Toolkit** ਵਿਸ਼ਤਾਰ ਖੋਲ੍ਹੋ।
1. **Catalog** ਸੈਕਸ਼ਨ ਵਿੱਚ **Models** ਚੁਣੋ ਤਾਂ ਜੋ **Model Catalog** ਖੁਲੇ। ਇਹ ਨਵੀਂ ਟੈਬ ਵਿੱਚ ਖੁਲਦਾ ਹੈ।
1. **Model Catalog** ਦੀ ਖੋਜ ਬਾਰ ਵਿੱਚ **OpenAI GPT-4o** ਲਿਖੋ।
1. **+ Add** 'ਤੇ ਕਲਿੱਕ ਕਰਕੇ ਮਾਡਲ ਨੂੰ ਆਪਣੇ **My Models** ਵਿੱਚ ਸ਼ਾਮਲ ਕਰੋ। ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਤੁਸੀਂ ਉਹ ਮਾਡਲ ਚੁਣਿਆ ਹੈ ਜੋ **GitHub ਵੱਲੋਂ ਹੋਸਟ ਕੀਤਾ ਗਿਆ ਹੈ**।
1. **Activity Bar** ਵਿੱਚ ਜਾਂਚ ਕਰੋ ਕਿ **OpenAI GPT-4o** ਮਾਡਲ ਸੂਚੀ ਵਿੱਚ ਦਿਖਾਈ ਦੇ ਰਿਹਾ ਹੈ।

### -1- ਏਜੰਟ ਬਣਾਓ

**Agent (Prompt) Builder** ਤੁਹਾਨੂੰ ਆਪਣੇ AI-ਚਲਿਤ ਏਜੰਟ ਬਣਾਉਣ ਅਤੇ ਕਸਟਮਾਈਜ਼ ਕਰਨ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ। ਇਸ ਹਿੱਸੇ ਵਿੱਚ, ਤੁਸੀਂ ਨਵਾਂ ਏਜੰਟ ਬਣਾਉਂਦੇ ਹੋ ਅਤੇ ਗੱਲਬਾਤ ਲਈ ਮਾਡਲ ਨਿਰਧਾਰਿਤ ਕਰਦੇ ਹੋ।

![AI Toolkit ਵਿਸ਼ਤਾਰ ਵਿੱਚ "Calculator Agent" ਬਿਲਡਰ ਇੰਟਰਫੇਸ ਦੀ ਸਕ੍ਰੀਨਸ਼ਾਟ। ਖੱਬੇ ਪੈਨਲ ਵਿੱਚ ਮਾਡਲ "OpenAI GPT-4o (via GitHub)" ਚੁਣਿਆ ਗਿਆ ਹੈ। ਸਿਸਟਮ ਪ੍ਰਾਂਪਟ ਵਿੱਚ "You are a professor in university teaching math" ਹੈ ਅਤੇ ਯੂਜ਼ਰ ਪ੍ਰਾਂਪਟ ਵਿੱਚ "Explain to me the Fourier equation in simple terms" ਹੈ। ਹੋਰ ਵਿਕਲਪਾਂ ਵਿੱਚ ਟੂਲ ਜੋੜਨਾ, MCP Server ਚਾਲੂ ਕਰਨਾ ਅਤੇ ਸੰਰਚਿਤ ਆਉਟਪੁੱਟ ਚੁਣਨਾ ਸ਼ਾਮਲ ਹਨ। ਹੇਠਾਂ ਨੀਲੇ ਰੰਗ ਦਾ "Run" ਬਟਨ ਹੈ। ਸੱਜੇ ਪਾਸੇ "Get Started with Examples" ਵਿੱਚ ਤਿੰਨ ਨਮੂਨੇ ਵਾਲੇ ਏਜੰਟ ਹਨ: Web Developer (MCP Server, Second-Grade Simplifier, Dream Interpreter ਸਮੇਤ)।](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.pa.png)

1. **Activity Bar** ਤੋਂ **AI Toolkit** ਵਿਸ਼ਤਾਰ ਖੋਲ੍ਹੋ।
1. **Tools** ਸੈਕਸ਼ਨ ਵਿੱਚ **Agent (Prompt) Builder** ਚੁਣੋ। ਇਹ ਨਵੀਂ ਟੈਬ ਵਿੱਚ ਖੁਲਦਾ ਹੈ।
1. **+ New Agent** ਬਟਨ 'ਤੇ ਕਲਿੱਕ ਕਰੋ। ਵਿਸ਼ਤਾਰ **Command Palette** ਰਾਹੀਂ ਸੈਟਅਪ ਵਿਜ਼ਾਰਡ ਸ਼ੁਰੂ ਕਰੇਗਾ।
1. ਨਾਮ ਵਜੋਂ **Calculator Agent** ਦਰਜ ਕਰੋ ਅਤੇ **Enter** ਦਬਾਓ।
1. **Agent (Prompt) Builder** ਵਿੱਚ **Model** ਖੇਤਰ ਲਈ **OpenAI GPT-4o (via GitHub)** ਮਾਡਲ ਚੁਣੋ।

### -2- ਏਜੰਟ ਲਈ ਸਿਸਟਮ ਪ੍ਰਾਂਪਟ ਬਣਾਓ

ਏਜੰਟ ਬਣਾਉਣ ਤੋਂ ਬਾਅਦ, ਹੁਣ ਇਸ ਦੀ ਵਿਅਕਤੀਗਤਤਾ ਅਤੇ ਮਕਸਦ ਪਰਿਭਾਸ਼ਿਤ ਕਰਨ ਦਾ ਸਮਾਂ ਹੈ। ਇਸ ਹਿੱਸੇ ਵਿੱਚ, ਤੁਸੀਂ **Generate system prompt** ਫੀਚਰ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਕੈਲਕੂਲੇਟਰ ਏਜੰਟ ਲਈ ਮਾਡਲ ਨੂੰ ਸਿਸਟਮ ਪ੍ਰਾਂਪਟ ਲਿਖਵਾਉਂਦੇ ਹੋ।

![AI Toolkit ਵਿੱਚ "Calculator Agent" ਇੰਟਰਫੇਸ ਦੀ ਸਕ੍ਰੀਨਸ਼ਾਟ ਜਿਸ ਵਿੱਚ "Generate a prompt" ਨਾਮਕ ਮੋਡਲ ਖੁਲਿਆ ਹੋਇਆ ਹੈ। ਮੋਡਲ ਵਿੱਚ ਲਿਖਿਆ ਹੈ ਕਿ ਪ੍ਰਾਂਪਟ ਟੈਂਪਲੇਟ ਬੁਨਿਆਦੀ ਜਾਣਕਾਰੀ ਸਾਂਝੀ ਕਰਕੇ ਬਣਾਇਆ ਜਾ ਸਕਦਾ ਹੈ। ਟੈਕਸਟ ਬਾਕਸ ਵਿੱਚ ਨਮੂਨਾ ਸਿਸਟਮ ਪ੍ਰਾਂਪਟ ਹੈ: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." ਹੇਠਾਂ "Close" ਅਤੇ "Generate" ਬਟਨ ਹਨ। ਪਿਛੋਕੜ ਵਿੱਚ ਏਜੰਟ ਸੰਰਚਨਾ ਦਿਖਾਈ ਦੇ ਰਹੀ ਹੈ, ਜਿਸ ਵਿੱਚ ਚੁਣਿਆ ਹੋਇਆ ਮਾਡਲ "OpenAI GPT-4o (via GitHub)" ਅਤੇ ਸਿਸਟਮ ਅਤੇ ਯੂਜ਼ਰ ਪ੍ਰਾਂਪਟ ਖੇਤਰ ਹਨ।](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.pa.png)

1. **Prompts** ਸੈਕਸ਼ਨ ਵਿੱਚ **Generate system prompt** ਬਟਨ 'ਤੇ ਕਲਿੱਕ ਕਰੋ। ਇਹ ਪ੍ਰਾਂਪਟ ਬਿਲਡਰ ਖੋਲ੍ਹਦਾ ਹੈ ਜੋ AI ਦੀ ਮਦਦ ਨਾਲ ਸਿਸਟਮ ਪ੍ਰਾਂਪਟ ਬਣਾਉਂਦਾ ਹੈ।
1. **Generate a prompt** ਵਿੰਡੋ ਵਿੱਚ ਇਹ ਲਿਖੋ: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. **Generate** ਬਟਨ 'ਤੇ ਕਲਿੱਕ ਕਰੋ। ਨੋਟੀਫਿਕੇਸ਼ਨ ਹੇਠਲੇ ਸੱਜੇ ਕੋਨੇ ਵਿੱਚ ਪ੍ਰਗਟ ਹੋਏਗੀ ਕਿ ਸਿਸਟਮ ਪ੍ਰਾਂਪਟ ਬਣਾਇਆ ਜਾ ਰਿਹਾ ਹੈ। ਜਦੋਂ ਇਹ ਮੁਕੰਮਲ ਹੋ ਜਾਵੇ, ਪ੍ਰਾਂਪਟ **Agent (Prompt) Builder** ਦੇ **System prompt** ਖੇਤਰ ਵਿੱਚ ਆ ਜਾਵੇਗਾ।
1. **System prompt** ਨੂੰ ਵੇਖੋ ਅਤੇ ਜਰੂਰਤ ਮੁਤਾਬਕ ਸੋਧ ਕਰੋ।

### -3- MCP ਸਰਵਰ ਬਣਾਓ

ਹੁਣ ਜਦੋਂ ਤੁਸੀਂ ਆਪਣੇ ਏਜੰਟ ਦਾ ਸਿਸਟਮ ਪ੍ਰਾਂਪਟ ਤੈਅ ਕਰ ਲਿਆ ਹੈ ਜੋ ਇਸ ਦੇ ਵਿਹਾਰ ਅਤੇ ਜਵਾਬਾਂ ਨੂੰ ਦਿਸਦਾ ਹੈ, ਤਾਂ ਹੁਣ ਏਜੰਟ ਨੂੰ ਵਰਤਣ ਯੋਗ ਬਣਾਉਣ ਲਈ ਅਮਲੀ ਸਮਰੱਥਾਵਾਂ ਨਾਲ ਸਜਾਓ। ਇਸ ਹਿੱਸੇ ਵਿੱਚ, ਤੁਸੀਂ ਜੋੜ, ਘਟਾਅ, ਗੁਣਾ ਅਤੇ ਭਾਗ ਕਰਨ ਵਾਲੇ ਟੂਲਾਂ ਨਾਲ ਕੈਲਕੂਲੇਟਰ MCP ਸਰਵਰ ਬਣਾਉਂਦੇ ਹੋ। ਇਹ ਸਰਵਰ ਤੁਹਾਡੇ ਏਜੰਟ ਨੂੰ ਕੁਦਰਤੀ ਭਾਸ਼ਾ ਪ੍ਰਾਂਪਟਾਂ ਦੇ ਜਵਾਬ ਵਿੱਚ ਤੁਰੰਤ ਗਣਿਤੀ ਕਾਰਵਾਈਆਂ ਕਰਨ ਦੇ ਯੋਗ ਬਣਾਏਗਾ।

![Calculator Agent ਇੰਟਰਫੇਸ ਦੇ ਹੇਠਲੇ ਹਿੱਸੇ ਦੀ ਸਕ੍ਰੀਨਸ਼ਾਟ ਜਿਸ ਵਿੱਚ “Tools” ਅਤੇ “Structure output” ਲਈ ਵਧਾਉਣਯੋਗ ਮੀਨੂਜ਼ ਹਨ। "Choose output format" ਡ੍ਰੌਪਡਾਊਨ "text" 'ਤੇ ਸੈੱਟ ਹੈ। ਸੱਜੇ ਪਾਸੇ "+ MCP Server" ਬਟਨ ਹੈ ਜੋ Model Context Protocol ਸਰਵਰ ਜੋੜਨ ਲਈ ਹੈ। Tools ਸੈਕਸ਼ਨ ਦੇ ਉੱਪਰ ਇਮੇਜ ਆਈਕਨ ਪਲੇਸਹੋਲਡਰ ਹੈ।](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.pa.png)

AI Toolkit ਵਿੱਚ ਆਪਣੇ MCP ਸਰਵਰ ਬਣਾਉਣ ਲਈ ਟੈਂਪਲੇਟ ਹੁੰਦੇ ਹਨ। ਅਸੀਂ ਕੈਲਕੂਲੇਟਰ MCP ਸਰਵਰ ਬਣਾਉਣ ਲਈ Python ਟੈਂਪਲੇਟ ਦੀ ਵਰਤੋਂ ਕਰਾਂਗੇ।

*ਨੋਟ*: AI Toolkit ਵਰਤਮਾਨ ਵਿੱਚ Python ਅਤੇ TypeScript ਨੂੰ ਸਮਰਥਿਤ ਕਰਦਾ ਹੈ।

1. **Agent (Prompt) Builder** ਦੇ **Tools** ਸੈਕਸ਼ਨ ਵਿੱਚ **+ MCP Server** ਬਟਨ 'ਤੇ ਕਲਿੱਕ ਕਰੋ। ਵਿਸ਼ਤਾਰ **Command Palette** ਰਾਹੀਂ ਸੈਟਅਪ ਵਿਜ਼ਾਰਡ ਸ਼ੁਰੂ ਕਰੇਗਾ।
1. **+ Add Server** ਚੁਣੋ।
1. **Create a New MCP Server** ਚੁਣੋ।
1. ਟੈਂਪਲੇਟ ਵਜੋਂ **python-weather** ਚੁਣੋ।
1. MCP ਸਰਵਰ ਟੈਂਪਲੇਟ ਸੇਵ ਕਰਨ ਲਈ **Default folder** ਚੁਣੋ।
1. ਸਰਵਰ ਲਈ ਇਹ ਨਾਮ ਦਿਓ: **Calculator**
1. ਇੱਕ ਨਵੀਂ Visual Studio Code ਵਿੰਡੋ ਖੁਲੇਗੀ। **Yes, I trust the authors** ਚੁਣੋ।
1. ਟਰਮੀਨਲ ਵਿੱਚ (**Terminal** > **New Terminal**) ਵਰਚੁਅਲ ਵਾਤਾਵਰਣ ਬਣਾਓ: `python -m venv .venv`
1. ਟਰਮੀਨਲ ਵਿੱਚ ਵਰਚੁਅਲ ਵਾਤਾਵਰਣ ਐਕਟੀਵੇਟ ਕਰੋ:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. ਟਰਮੀਨਲ ਵਿੱਚ ਡਿਪੈਂਡੈਂਸੀਜ਼ ਇੰਸਟਾਲ ਕਰੋ: `pip install -e .[dev]`
1. **Activity Bar** ਦੇ **Explorer** ਵਿਊ ਵਿੱਚ **src** ਡਾਇਰੈਕਟਰੀ ਖੋਲ੍ਹੋ ਅਤੇ **server.py** ਫਾਇਲ ਖੋਲ੍ਹੋ।
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

### -4- ਕੈਲਕੂਲੇਟਰ MCP ਸਰਵਰ ਨਾਲ ਏਜੰਟ ਚਲਾਓ

ਹੁਣ ਜਦੋਂ ਤੁਹਾਡੇ ਏਜੰਟ ਕੋਲ ਟੂਲ ਹਨ, ਤਾਂ ਉਨ੍ਹਾਂ ਦੀ ਵਰਤੋਂ ਕਰਨ ਦਾ ਸਮਾਂ ਹੈ! ਇਸ ਹਿੱਸੇ ਵਿੱਚ, ਤੁਸੀਂ ਏਜੰਟ ਨੂੰ ਪ੍ਰਾਂਪਟ ਸੌਂਪ ਕੇ ਜਾਂਚੋਗੇ ਕਿ ਕੀ ਇਹ ਕੈਲਕੂਲੇਟਰ MCP ਸਰਵਰ ਤੋਂ ਸਹੀ ਟੂਲ ਵਰਤਦਾ ਹੈ ਜਾਂ ਨਹੀਂ।

![Calculator Agent ਇੰਟਰਫੇਸ ਦੀ ਸਕ੍ਰੀਨਸ਼ਾਟ ਜਿਸ ਵਿੱਚ ਖੱਬੇ ਪੈਨਲ 'ਚ “Tools” ਹੇਠਾਂ ਇੱਕ MCP ਸਰਵਰ local-server-calculator_server ਜੋੜਿਆ ਗਿਆ ਹੈ, ਜਿਸ ਵਿੱਚ ਚਾਰ ਉਪਲਬਧ ਟੂਲ ਹਨ: add, subtract, multiply, ਅਤੇ divide। ਇੱਕ ਬੈਜ ਦਿਖਾਉਂਦਾ ਹੈ ਕਿ ਚਾਰ ਟੂਲ ਐਕਟਿਵ ਹਨ। ਹੇਠਾਂ "Structure output" ਸੈਕਸ਼ਨ ਕਲੋਜ਼ਡ ਹੈ ਅਤੇ ਇੱਕ ਨੀਲਾ "Run" ਬਟਨ ਹੈ। ਸੱਜੇ ਪੈਨਲ ਵਿੱਚ "Model Response" ਹੇਠਾਂ ਏਜੰਟ ਨੇ multiply ਅਤੇ subtract ਟੂਲਾਂ ਨੂੰ ਇਨਪੁੱਟ {"a": 3, "b": 25} ਅਤੇ {"a": 75, "b": 20} ਨਾਲ ਕਾਲ ਕੀਤਾ ਹੈ। ਅੰਤਿਮ "Tool Response" 75.0 ਹੈ। ਹੇਠਾਂ "View Code" ਬਟਨ ਹੈ।](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.pa.png)

ਤੁਸੀਂ ਆਪਣੇ ਸਥਾਨਕ ਵਿਕਾਸ ਮਸ਼ੀਨ 'ਤੇ Agent Builder ਰਾਹੀਂ MCP ਕਲਾਇੰਟ ਵਜੋਂ ਕੈਲਕੂਲੇਟਰ MCP ਸਰਵਰ ਚਲਾਓਗੇ।

1. `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` ਮੁੱਲ **subtract** ਟੂਲ ਲਈ ਸੌਂਪੇ ਜਾਂਦੇ ਹਨ।
    - ਹਰ ਟੂਲ ਤੋਂ ਜਵਾਬ ਸੰਬੰਧਿਤ **Tool Response** ਵਿੱਚ ਦਿੱਤਾ ਜਾਂਦਾ ਹੈ।
    - ਮਾਡਲ ਦਾ ਅੰਤਿਮ ਆਉਟਪੁੱਟ ਅੰਤਿਮ **Model Response** ਵਿੱਚ ਦਿੱਤਾ ਜਾਂਦਾ ਹੈ।
1. ਹੋਰ ਪ੍ਰਾਂਪਟ ਭੇਜ ਕੇ ਏਜੰਟ ਦੀ ਜਾਂਚ ਕਰੋ। ਤੁਸੀਂ **User prompt** ਖੇਤਰ ਵਿੱਚ ਮੌਜੂਦਾ ਪ੍ਰਾਂਪਟ 'ਤੇ ਕਲਿੱਕ ਕਰਕੇ ਇਸ ਨੂੰ ਬਦਲ ਸਕਦੇ ਹੋ।
1. ਜਦੋਂ ਤੁਸੀਂ ਟੈਸਟਿੰਗ ਮੁਕੰਮਲ ਕਰ ਲਵੋ, ਤਾਂ ਟਰਮੀਨਲ ਵਿੱਚ **CTRL/CMD+C** ਦਬਾ ਕੇ ਸਰਵਰ ਬੰਦ ਕਰੋ।

## ਅਸਾਈਨਮੈਂਟ

ਆਪਣੇ **server.py** ਫਾਇਲ ਵਿੱਚ ਇੱਕ ਹੋਰ ਟੂਲ ਇੰਟਰੀ ਸ਼ਾਮਲ ਕਰਨ ਦੀ ਕੋਸ਼ਿਸ਼ ਕਰੋ (ਜਿਵੇਂ ਕਿ ਕਿਸੇ ਸੰਖਿਆ ਦਾ ਵਰਗਮੂਲ ਵਾਪਸ ਕਰਨਾ)। ਐਸੇ ਹੋਰ ਪ੍ਰਾਂਪਟ ਭੇਜੋ ਜੋ ਤੁਹਾਡੇ ਨਵੇਂ (ਜਾਂ ਮੌਜੂਦਾ) ਟੂਲ ਦੀ ਵਰਤੋਂ ਮੰਗਦੇ ਹੋਣ। ਨਵੇਂ ਟੂਲ ਲੋਡ ਕਰਨ ਲਈ ਸਰਵਰ ਨੂੰ ਦੁਬਾਰਾ ਸ਼ੁਰੂ ਕਰਨਾ ਯਕੀਨੀ ਬਣਾਓ।

## ਸਮਾਧਾਨ

[Solution](./solution/README.md)

## ਮੁੱਖ ਸਿੱਖਿਆ

ਇਸ ਅਧਿਆਇ ਤੋਂ ਪ੍ਰਾਪਤ ਮੁੱਖ ਗੱਲਾਂ ਇਹ ਹਨ:

- AI Toolkit ਵਿਸ਼ਤਾਰ ਇੱਕ ਬਹੁਤ ਵਧੀਆ ਕਲਾਇੰਟ ਹੈ ਜੋ ਤੁਹਾਨੂੰ MCP ਸਰਵਰਾਂ ਅਤੇ ਉਹਨਾਂ ਦੇ ਟੂਲਾਂ ਦੀ ਵਰਤੋਂ

**ਅਸਵੀਕਾਰੋक्ति**:  
ਇਸ ਦਸਤਾਵੇਜ਼ ਦਾ ਅਨੁਵਾਦ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਨਾਲ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਅਤ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਵਿੱਚ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਮਰਥਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਅਧਿਕਾਰਤ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਪੈਦਾ ਹੋਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀਆਂ ਜਾਂ ਭ੍ਰਮਾਂ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।